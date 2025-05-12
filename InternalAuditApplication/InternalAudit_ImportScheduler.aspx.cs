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

namespace InternalAuditApplication
{
    public partial class InternalAudit_ImportScheduler : System.Web.UI.Page
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
                    Response.Redirect("Login.aspx", false);
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
            if (RoleID == 3)
            {
                Response.Redirect("MFEDL_SuperMenuPage.aspx", false);
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

                string newxlsfilename = "InternalAudit_" + datetime + fileExtension;

                newxlsfilename = excelPath.Replace(Path.GetFileName(xslFileUpload.PostedFile.FileName), newxlsfilename);
                //if (fileName.ToUpper().StartsWith("INVOICE MANAGEMENT"))
                //{
                if (fileExtension.ToUpper() == ".XLS" || fileExtension.ToUpper() == ".XLSX")
                {
                    xslFileUpload.SaveAs(newxlsfilename);

                    ImportExcel ie = new ImportExcel();
                    DataTable dt = new DataTable();
                    DataSet ds = ie.ExcelDataReader(newxlsfilename);
                    if (ds.Tables.Count > 0)
                    {
                        dt = ds.Tables[0];
                    }
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        // Validating if all columns exists in format
                        int colCount = dt.Columns.Count;  // 8
                        if (colCount != 9)    //Modified on 30/08/2023 
                        {
                            lblMsgXls.Text = "Uploaded Excel Not As Per Standard Format Column Mismatch";

                            return;
                        }

                        List<string> Columns = returnColumns();  // 8

                        int i = 0;
                        foreach (var col in Columns)
                        {
                            if (Columns[i] != Convert.ToString(dt.Columns[i].ColumnName))
                            {
                                lblMsgXls.Text = Columns[i] + "!=" + Convert.ToString(dt.Columns[i].ColumnName)
                                  + "  Uploaded Excel Not As Per Standard Format Column Name Mismatch";

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
                            SqlCommand cmd = new SqlCommand("InternalAudit_InsertUploadedDataInTemTable_SP", sqlCon);

                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@FinancialYear", Convert.ToString(row["FinancialYear"]).Normalize());
                            cmd.Parameters.AddWithValue("@QuarterHalfYear", Convert.ToString(row["Quarter_HalfYear"]).Normalize());
                            cmd.Parameters.AddWithValue("@Branch", Convert.ToString(row["Branch"]).Normalize());
                            cmd.Parameters.AddWithValue("@Vertical", Convert.ToString(row["Vertical"]).Normalize());
                            cmd.Parameters.AddWithValue("@Unit", Convert.ToString(row["Unit"]).Normalize());
                            cmd.Parameters.AddWithValue("@ScheduleDate", Convert.ToString(row["ScheduleDate"]).Normalize());
                            cmd.Parameters.AddWithValue("@Auditor", Convert.ToString(row["Auditor"]).Normalize());
                            cmd.Parameters.AddWithValue("@Auditee", Convert.ToString(row["Auditee"]).Normalize());
                            cmd.Parameters.AddWithValue("@CreatedBy ", Convert.ToString(row["CreatedBy"]).Normalize());
                            cmd.Parameters.AddWithValue("@ScopeORNonscope ", Convert.ToString(row["ScopeORNonscope"]).Normalize());

                            sqlCon.Open();
                            Result = cmd.ExecuteNonQuery();
                            sqlCon.Close();
                        }
                        lblMsgXls.Text = "Imported Successfully";

                        if (Result > 0)
                        {


                            SqlCommand cmd1 = new SqlCommand("InternalAudit_InsertDataIntoTrackingTable_SP", sqlCon);
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
            column.Add("Financial Year");
            column.Add("Quarter_HalfYear");
            column.Add("Location/Branch");
            column.Add("Vertical");
            column.Add("Unit");
            column.Add("Schedule date");
            column.Add("Auditor");
            column.Add("Auditee");
            column.Add("ScopeORNonscope");
            return column;
        }
        private List<string> ReNameColumns()
        {
            List<string> column = new List<string>();
            // mdifed column names in view of changed format
            column.Add("FinancialYear");
            column.Add("Quarter_HalfYear");
            column.Add("Branch");
            column.Add("Vertical");
            column.Add("Unit");
            column.Add("ScheduleDate");
            column.Add("Auditor");
            column.Add("Auditee");
            column.Add("ScopeORNonscope");
            return column;
        }

        protected void btnDownloadUploadFormat_Click(object sender, EventArgs e)
        {

            Response.ContentType = "application/XLSX";
            Response.AppendHeader("Content-Disposition", "attachment; filename=UploadFormat.xls");
            Response.TransmitFile(Server.MapPath("~/UploadFormat/InternalAuditScheduler_UploadFormat.xls"));
            Response.End();

        }

        public void ExportToExcel(DataTable dt)
        {
            if (dt.Rows.Count > 0)
            {
                string currentDateTime = DateTime.Now.Ticks.ToString();
                string filename = "InternalAuditUploadMIS_" + currentDateTime + ".xls";
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

        protected void btnBack_Click1(object sender, EventArgs e)
        {
            Response.Redirect("InternalAudit_Menu.aspx", false);
        }
    }
}
