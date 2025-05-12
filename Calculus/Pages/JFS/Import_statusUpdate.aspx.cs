using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Data.OleDb;
using System.IO;
using System.Configuration;


public partial class Pages_JFS_Import_statusUpdate : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
         
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/pages/menu.aspx", true);
    }
    protected void btnImport_Click(object sender, EventArgs e)
    {
        try
        {
            if (xslFileUpload.HasFile)
            {
                String strPath = "";
                String MyFile = "";
                string strDateTime = DateTime.Now.ToString("ddMMyyyyhhmmss");

                strPath = Server.MapPath("~/Pages/JFS/ImportFiles/");
                MyFile = strDateTime + ".xls";
                strPath = (strPath + MyFile);
                xslFileUpload.PostedFile.SaveAs(strPath);

                string strFileName = xslFileUpload.FileName.ToString();

                FileInfo fi = new FileInfo(strFileName);
                string strExt = fi.Extension;

                if (strExt.ToLower() == ".xls")
                {
                    string strConn = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + strPath + @";Extended Properties=""Excel 8.0;IMEX=1""";

                    OleDbConnection oleCon = new OleDbConnection(strConn);
                    oleCon.Open();

                    OleDbCommand oleCom = new OleDbCommand("SELECT * FROM [sheet1$]");
                    oleCom.Connection = oleCon;

                    OleDbDataAdapter oleDA = new OleDbDataAdapter();
                    oleDA.SelectCommand = oleCom;

                    DataTable dt = new DataTable();
                    oleDA.Fill(dt);
                    oleCon.Close();

                    if (dt.Rows.Count > 0)
                    {
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            
                            Update_Into_JFS_StatusUpdate(dt.Rows[i]);

                        }
                        lblMsgXls.Text = "Data Import Successfully!!";
                    }

                    string strFile = Server.MapPath("~/Pages/JFS/ImportFiles/") + MyFile;
                    if (File.Exists(strFile))
                    {
                        File.Delete(strFile);
                       
                    }
                }
                else
                {
                    lblMsgXls.Visible = true;
                    lblMsgXls.Text = "It's Not An Excel File...!!!";
                }
            }
            else
            {
                lblMsgXls.Visible = true;
                lblMsgXls.Text = "Please Select Excel File To Import...!!!";
            }
        }
        catch (Exception ex)
        {
            lblMsgXls.Visible = true;
            lblMsgXls.Text = "Error :" + ex.Message;
        }
    }

    protected void Update_Into_JFS_StatusUpdate(DataRow dr)
    {

        Object SaveUSERInfo = (Object)Session["UserInfo"];

        SqlConnection sqlCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);

        SqlCommand sqlcmd = new SqlCommand();
        sqlcmd.Connection = sqlCon;
        sqlcmd.CommandType = CommandType.StoredProcedure;
        sqlcmd.CommandText = "sp_Update_Status";
        sqlcmd.CommandTimeout = 0;

        SqlParameter Auto_Application_No = new SqlParameter();
        Auto_Application_No.SqlDbType = SqlDbType.VarChar;
        Auto_Application_No.Value = dr["Auto Application No"].ToString().Trim();
        Auto_Application_No.ParameterName = "@Auto_Application_No";
        sqlcmd.Parameters.Add(Auto_Application_No);

        SqlParameter Data_Entry_Reason = new SqlParameter();
        Data_Entry_Reason.SqlDbType = SqlDbType.VarChar;
        Data_Entry_Reason.Value = dr["On Hold Data Entry Reason"].ToString().Trim();
        Data_Entry_Reason.ParameterName = "@Data_Entry_Reason";
        sqlcmd.Parameters.Add(Data_Entry_Reason);

        SqlParameter Application_Status = new SqlParameter();
        Application_Status.SqlDbType = SqlDbType.VarChar;
        Application_Status.Value = dr["Application Status"].ToString().Trim();
        Application_Status.ParameterName = "@Application_Status";
        sqlcmd.Parameters.Add(Application_Status);

        sqlCon.Open();
        int RowEffected = 0;

        RowEffected = sqlcmd.ExecuteNonQuery();

        sqlCon.Close();
    }
}