using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using YesBank;

namespace MFEDL_Demo
{
    public partial class MFEDL_UploadFile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["UserName"] != null)
                {

                }
                else
                {
                    Response.Redirect("MFEDL_LoginPage.aspx", false);
                }
            }
            catch (Exception ex)
            {

            }
        }
        protected void btnBack_Click(object sender, EventArgs e)
        {
            Object SaveUSERInfo = (Object)Session["UserInfo"];

            int RoleID = Convert.ToInt32(((UserInfo.structUSERInfo)(SaveUSERInfo)).RoleID);

            if (RoleID == 1)
            {
                Response.Redirect("MFEDL_MenuPage.aspx", false);
            }
            if (RoleID == 5)
            {
                Response.Redirect("MFEDL_MenuPage.aspx", false);
            }
        }
        protected void btnImport_Click(object sender, EventArgs e)
        {
            SqlConnection sqlCon = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            try
            {
                lblMsgXls.Text = "";
                //Upload and save the file
                string excelPath = Server.MapPath("~/UploadedFiles/") + Path.GetFileName(xslFileUpload.PostedFile.FileName);
                string fileName = Path.GetFileNameWithoutExtension(excelPath);
                string fileExtension = Path.GetExtension(excelPath);

                string datetime = DateTime.Now.ToString("yyyy-MM-dd HH mm ss");

                string newxlsfilename = "MFEDL_" + datetime + fileExtension;

                newxlsfilename = excelPath.Replace(Path.GetFileName(xslFileUpload.PostedFile.FileName), newxlsfilename);
                //if (fileName.ToUpper().StartsWith("INVOICE MANAGEMENT"))
                //{
                if (fileExtension.ToUpper() == ".XLS" || fileExtension.ToUpper() == ".XLSX")
                {
                    xslFileUpload.SaveAs(newxlsfilename);

                    ImportExcel ie = new ImportExcel();
                    DataTable dt = new DataTable();
                   /* DataSet ds = ie.ExcelDataReader(newxlsfilename);
                    if (ds.Tables.Count > 0)
                    {
                        dt = ds.Tables[0];
                    }*/
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        // Validating if all columns exists in format
                        int colCount = dt.Columns.Count;  // 25
                        if (colCount != 25)    //Modified to 18 on 28/08/2022 
                        {
                            lblMsgXls.Text = "Uploaded Excel Not As Per Standard Format Column Mismatch";

                            return;
                        }

                        List<string> Columns = returnColumns();  // 18

                        int i = 0;
                        foreach (var col in Columns)
                        {
                            if (Columns[i] != Convert.ToString(dt.Columns[i].ColumnName))
                            {
                                lblMsgXls.Text = Columns[i] + "-" + Convert.ToString(dt.Columns[i].ColumnName)
                                  + "Uploaded Excel Not As Per Standard Format Column Name Mismatc";

                                return;
                            }
                            i++;
                        }

                        //dt.Columns.Add("UserName").DefaultValue = Session["UserName"];
                        DataColumn newColumn = new DataColumn("CreatedBy", typeof(System.String));
                        newColumn.DefaultValue = Convert.ToString(Session["UserID"]);
                        dt.Columns.Add(newColumn);


                        i = 0;
                        List<string> renameColumns = ReNameColumns();
                        foreach (var col in renameColumns)
                        {
                            dt.Columns[i].ColumnName = renameColumns[i];

                            i++;
                        }

                        dt.AcceptChanges();

                        int Result = 0;

                        foreach (DataRow row in dt.Rows)
                        {
                            // structure changed replacing old structure
                            SqlCommand cmd = new SqlCommand("MFEDL_Pre_InsertUploadedDataInTemTable_SP", sqlCon);

                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@ApplicationID ", Convert.ToString(row["ApplicationID"]).Normalize());
                            cmd.Parameters.AddWithValue("@ApplicationFormNumber", Convert.ToString(row["ApplicationFormNumber"]).Normalize());
                            cmd.Parameters.AddWithValue("@NeoCustID ", Convert.ToString(row["NeoCustID"]).Normalize());
                            cmd.Parameters.AddWithValue("@IdentificationNo", Convert.ToString(row["IdentificationNo"]).Normalize());
                            cmd.Parameters.AddWithValue("@CustomerName ", Convert.ToString(row["CustomerName"]).Normalize());
                            cmd.Parameters.AddWithValue("@LoanAmount", Convert.ToString(row["LoanAmount"]).Normalize());
                            cmd.Parameters.AddWithValue("@Stage", Convert.ToString(row["Stage"]).Normalize());
                            cmd.Parameters.AddWithValue("@InQueueStatus", Convert.ToString(row["InQueueStatus"]).Normalize());
                            cmd.Parameters.AddWithValue("@RequestType ", Convert.ToString(row["RequestType"]).Normalize());
                            cmd.Parameters.AddWithValue("@SourcingDate", Convert.ToString(row["SourcingDate"]).Normalize());
                            cmd.Parameters.AddWithValue("@LastUpdated ", Convert.ToString(row["LastUpdated"]).Normalize());
                            cmd.Parameters.AddWithValue("@SourcingChannel ", Convert.ToString(row["SourcingChannel"]));
                            cmd.Parameters.AddWithValue("@BranchNoneSelected ", Convert.ToString(row["BranchNoneSelected"]));
                            cmd.Parameters.AddWithValue("@ProductTypeNoneSelected ", Convert.ToString(row["ProductTypeNoneSelected"]).Normalize());
                            cmd.Parameters.AddWithValue("@ProductNameNoneSelected", Convert.ToString(row["ProductNameNoneSelected"]).Normalize());
                            cmd.Parameters.AddWithValue("@SchemeNoneSelected ", Convert.ToString(row["SchemeNoneSelected"]).Normalize());
                            cmd.Parameters.AddWithValue("@CreatedOn", Convert.ToString(row["CreatedOn"]).Normalize());
                            cmd.Parameters.AddWithValue("@PriorityNoneSelected ", Convert.ToString(row["PriorityNoneSelected"]).Normalize());
                            cmd.Parameters.AddWithValue("@ImageBasedProcessing", Convert.ToString(row["ImageBasedProcessing"]).Normalize());
                            cmd.Parameters.AddWithValue("@AgreementBookletSNo", Convert.ToString(row["AgreementBookletSNo"]).Normalize());
                            cmd.Parameters.AddWithValue("@ProductProcessorNoneSelected", Convert.ToString(row["ProductProcessorNoneSelected"]).Normalize());
                            cmd.Parameters.AddWithValue("@FIStatus", Convert.ToString(row["FIStatus"]).Normalize());
                            cmd.Parameters.AddWithValue("@CollateralStatus", Convert.ToString(row["CollateralStatus"]).Normalize());
                            cmd.Parameters.AddWithValue("@RCUStatus", Convert.ToString(row["RCUStatus"]).Normalize());
                            cmd.Parameters.AddWithValue("@Actions", Convert.ToString(row["Actions"]).Normalize());
                            cmd.Parameters.AddWithValue("@CreatedBy ", Convert.ToString(row["CreatedBy"]).Normalize());

                            sqlCon.Open();
                            Result = cmd.ExecuteNonQuery();
                            sqlCon.Close();
                        }
                        lblMsgXls.Text = "Imported Successfully";

                        if (Result > 0)
                        {


                            SqlCommand cmd1 = new SqlCommand("MFEDL_Pre_InsertDataIntoTrackingTable_SP", sqlCon);
                            cmd1.CommandType = CommandType.StoredProcedure;
                            SqlDataAdapter dp2 = new SqlDataAdapter(cmd1);
                            DataSet ds2 = new DataSet();
                            dp2.Fill(ds2);


                            ExportToExcel(ds2.Tables[0]);

                            if (Result > 0)
                            {
                                lblMsgXls.Text = "Data Inserted Successfully";
                            }
                            else
                            {
                                lblMsgXls.Text = "No Record Found To Insert";
                            }
                        }
                        else
                        {
                            lblMsgXls.Text = "No Records Found to Import, Kindly check the Excel !";
                            lblMsgXls.ForeColor = System.Drawing.Color.Red;
                            return;
                        }

                        if (File.Exists(newxlsfilename))
                        {
                            File.Delete(newxlsfilename);
                        }
                    }
                }
                else
                {
                    lblMsgXls.Text = "Invalid File Extension, Only .xls and .xlsx file are allowed !";
                    lblMsgXls.ForeColor = System.Drawing.Color.Red;
                    return;
                }

            }
            catch (Exception ex)
            {
                lblMsgXls.Text = "Error:" + ex.Message;
                lblMsgXls.ForeColor = System.Drawing.Color.Red;
            }
        }
        private List<string> returnColumns()
        {
            List<string> column = new List<string>();
            //  New fields added as per changed format
            column.Add("Application ID");
            column.Add("Application Form Number");
            column.Add("Neo Cust ID");
            column.Add("Identification No.");
            column.Add("Customer Name");
            column.Add("Loan Amount");
            column.Add("Stage");
            column.Add("In-Queue Status");
            column.Add("Request Type");
            column.Add("Sourcing Date");
            column.Add("Last Updated");
            column.Add("Sourcing Channel");
            column.Add("BranchNone Selected");
            column.Add("Product TypeNone Selected");
            column.Add("Product NameNone Selected");
            column.Add("SchemeNone Selected");
            column.Add("Created On");
            column.Add("PriorityNone Selected");
            column.Add("Image Based Processing");
            column.Add("Agreement Booklet SNo");
            column.Add("Product ProcessorNone Selected");
            column.Add("FI Status");
            column.Add("Collateral Status");
            column.Add("RCU Status");
            column.Add("Actions");
            return column;
        }
        private List<string> ReNameColumns()
        {
            List<string> column = new List<string>();
            // mdifed column names in view of changed format
            column.Add("ApplicationID");
            column.Add("ApplicationFormNumber");
            column.Add("NeoCustID");
            column.Add("IdentificationNo");
            column.Add("CustomerName");
            column.Add("LoanAmount");
            column.Add("Stage");
            column.Add("InQueueStatus");
            column.Add("RequestType");
            column.Add("SourcingDate");
            column.Add("LastUpdated");
            column.Add("SourcingChannel");
            column.Add("BranchNoneSelected");
            column.Add("ProductTypeNoneSelected");
            column.Add("ProductNameNoneSelected");
            column.Add("SchemeNoneSelected");
            column.Add("CreatedOn");
            column.Add("PriorityNoneSelected");
            column.Add("ImageBasedProcessing");
            column.Add("AgreementBookletSNo");
            column.Add("ProductProcessorNoneSelected");
            column.Add("FIStatus");
            column.Add("CollateralStatus");
            column.Add("RCUStatus");
            column.Add("Actions");

            return column;
        }

        protected void btnDownloadUploadFormat_Click(object sender, EventArgs e)
        {

            Response.ContentType = "application/XLSX";
            Response.AppendHeader("Content-Disposition", "attachment; filename=UploadFormat.xls");
            Response.TransmitFile(Server.MapPath("~/UploadFormat/UploadFormat.xls"));
            Response.End();

        }

        public void ExportToExcel(DataTable dt)
        {
            if (dt.Rows.Count > 0)
            {
                string currentDateTime = DateTime.Now.Ticks.ToString();
                string filename = "UploadMIS_" + currentDateTime + ".xls";
                System.IO.StringWriter tw = new System.IO.StringWriter();
                System.Web.UI.HtmlTextWriter hw = new System.Web.UI.HtmlTextWriter(tw);
                DataGrid dgGrid = new DataGrid();
                dgGrid.DataSource = dt;
                dgGrid.DataBind();

                //Get the HTML for the control.
                dgGrid.RenderControl(hw);
                //Write the HTML back to the browser.
                //Response.ContentType = application/vnd.ms-excel;
                Response.ContentType = "application/vnd.ms-excel";
                Response.AppendHeader("Content-Disposition", "attachment; filename=" + filename + "");
                this.EnableViewState = false;
                Response.Write(tw.ToString());
                Response.End();
            }
        }
    }
}