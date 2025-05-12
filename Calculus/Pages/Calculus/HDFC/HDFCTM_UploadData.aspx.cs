using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;

public partial class Pages_Calculus_HDFC_HDFCTM_UploadData : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnImport_Click(object sender, EventArgs e)
    {
        if (xslFileUpload.PostedFile.FileName == "")
        {
            lblMsgXls.Text = "Please select a file to Import";
            return;
        }

        try
        {
            btnImport.Enabled = false;
            lblMsgXls.Text = "";
            //Upload and save the file
            string excelPath = Server.MapPath("~/Pages/Calculus/HDFC/UploadFile/") + Path.GetFileName(xslFileUpload.PostedFile.FileName);
            string fileName = Path.GetFileNameWithoutExtension(excelPath);
            string fileExtension = Path.GetExtension(excelPath);

            string datetime = DateTime.Now.ToString("yyyy-MM-dd HH mm ss");

            string newxlsfilename = "HDFC_" + datetime + fileExtension;

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

                string[] StandardColumns = new string[3];
                StandardColumns[0] = "Customer Name";
                StandardColumns[1] = "Application Id";
                StandardColumns[2] = "File Status";

                // Validating columns in excel file

                if (dt.Columns.Count < 3)
                {
                    lblMsgXls.Text = "Upload format is not as per standard format";
                    return;
                }

                foreach (DataColumn dc in dt.Columns)
                {
                    if (!StandardColumns.Contains(dc.ColumnName))
                    {
                        lblMsgXls.Text = "Upload format is not as per standard format";
                        return;
                    }
                }

                lblMsgXls.Text = "";
				
				DataTable finalDT = new DataTable();
                finalDT.Columns.Add("Customer Name",typeof(string));
                finalDT.Columns.Add("Application Id", typeof(string));
                finalDT.Columns.Add("File Status", typeof(string));
                finalDT.Columns.Add("CreatedBy", typeof(string));
                finalDT.AcceptChanges();

                foreach (DataRow dr in dt.Rows)
                {
                    finalDT.Rows.Add(dr.ItemArray);
                }
                finalDT.AcceptChanges();

                if (dt != null && dt.Rows.Count > 0)
                {
                    Object SaveUSERInfo = (Object)Session["UserInfo"];

                    DataColumn newColumn = new DataColumn("CreatedBy", typeof(System.String));
                    newColumn.DefaultValue = (((UserInfo.structUSERInfo)(SaveUSERInfo)).UserId);
                    dt.Columns.Add(newColumn);
                    dt.AcceptChanges();

                    dt = dt.Rows.Cast<DataRow>().Where(row => !row.ItemArray.All(field => field is DBNull ||
                        string.IsNullOrWhiteSpace(field as string))).CopyToDataTable();
                    dt.AcceptChanges();


                    SqlConnection sqlCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);

                    SqlCommand sqlCom = new SqlCommand();
                    sqlCom.Connection = sqlCon;
                    sqlCom.CommandType = CommandType.StoredProcedure;
                    sqlCom.CommandText = "HDFCTM_UploadData_SP";

                    sqlCom.Parameters.AddWithValue("@HDFC_TM_Upload", finalDT);

                    SqlDataAdapter sqlDA = new SqlDataAdapter();
                    sqlDA.SelectCommand = sqlCom;
                    sqlDA.Fill(dt);
                    sqlCon.Close();

                    //ExportToExcel(dt.Tables[0]);

                    if (dt != null)
                    {
                        lblMsgXls.Text = "Data Inserted Successfully, Records Inserted Count : " + dt.Rows.Count;
                    }
                    else
                    {
                        lblMsgXls.Text = "No Record Found To Insert";
                    }

                }
                else
                {
                    lblMsgXls.Text = "Error .......!!!!!!";
                }

                // if (File.Exists(newxlsfilename))
                // {
                    // File.Delete(newxlsfilename);
                // }
            }

        }
        catch (Exception ex)
        {
			lblMsgXls.Text = ex.ToString();
            ex.ToString();
        }

    }





    private List<string> returnColumns()
    {
        throw new NotImplementedException();
    }
    protected void btnDownloadUploadFormat_Click(object sender, EventArgs e)
    {
        Response.ContentType = "application/XLS";
        Response.AppendHeader("Content-Disposition", "attachment; filename=HDFC_CD_UPLOADFORMAT.xls");
        Response.TransmitFile(Server.MapPath("~/Pages/Calculus/HDFC/UploadFormat/HDFC_CD_UPLOADFORMAT.xls"));
        Response.End();
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect(Request.RawUrl);
    }
    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Pages/Menu.aspx", true);
    }
}