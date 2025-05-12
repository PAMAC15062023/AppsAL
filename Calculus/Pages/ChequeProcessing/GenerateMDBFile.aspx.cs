using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.OleDb; 
using ADOX; 


public partial class Pages_ChequeProcessing_GenerateMDBFile : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    private void Create_MDBFile(string ValidChequeUploadPath, string InvalidChequeUploadPath)
    {
        try
        {
            if (ValidChequeUploadPath != "")
            {
                string strCon = "Provider=Microsoft.Jet.OLEDB.4.0;data source=" + ValidChequeUploadPath;
                OleDbConnection oleCon = new OleDbConnection(strCon);
                oleCon.Open();

                OleDbCommand oleCom = new OleDbCommand("ALTER TABLE trxnheader ADD COLUMN  phoneno TEXT(100) , receiptno TEXT(100)");
                oleCom.Connection = oleCon;                
                oleCom.ExecuteNonQuery();
                oleCon.Close();

                Updating_ValidCheque_Info(ValidChequeUploadPath);
                Updating_InvalidCheque_Info(ValidChequeUploadPath,InvalidChequeUploadPath);

                   
         
            }
             
        }
        catch (Exception ex)
        {
            Display_Error(ex.Message, "Error");
           
        } 
         //Display_Error("Database Created Successfully","Error");

         
    
    }
    protected void btnUpload_Click(object sender, EventArgs e)
    { 
        if (FileUpload_ValidDBF.FileName != "")
        {

            UploadTo_Server();
            Download_MdbFile(FileUpload_ValidDBF.FileName.Trim());
        }
        else
        {
            Display_Error("Please select MDB and Invalid DBF file to Continue...!", "Error");
        }
            
    }
    protected void btnClose_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Pages/Menu.aspx",true);
    }
    private void UploadTo_Server()
    {

        string[] UploadFilesPath = new string[2];

       
            string[] FileFormat = FileUpload_ValidDBF.FileName.Split('.');

            if (FileUpload_ValidDBF.FileName.Contains(".mdb"))
            {

                string fullSitePath = Convert.ToString(ConfigurationSettings.AppSettings["FileUploadPath"]); //this.Request.PhysicalApplicationPath;
                string FileSavePath = "";
                string[] FileFormat_MDB = FileUpload_ValidDBF.FileName.Split('.');
                string FileName_MBB = Convert.ToString(DateTime.Now.ToString("yyyyMMddHHmmss")) + "_ValidMDB." + FileFormat_MDB[FileFormat_MDB.Length - 1];
                FileSavePath = fullSitePath + FileName_MBB;
                FileUpload_ValidDBF.SaveAs(FileSavePath);
                UploadFilesPath[0] = FileSavePath;

                string[] FileFormat_INVDBF = FileUpload_InvalidDBF.FileName.Split('.');
                string FileName_INVALIDDBF = Convert.ToString(DateTime.Now.ToString("yyyyMMddHHmmss")) + "_InvalidDBF." + FileFormat_INVDBF[FileFormat_INVDBF.Length - 1];
                FileSavePath = fullSitePath + FileName_INVALIDDBF;
                FileUpload_InvalidDBF.SaveAs(FileSavePath);
                UploadFilesPath[1] = FileSavePath;

                Session["UploadFilesPath"] = UploadFilesPath[0];
                Create_MDBFile(UploadFilesPath[0], UploadFilesPath[1]);
               
            }
         else
            {
                Display_Error("Please select MDB valid file!", "Error");
            }
     

    }
    private void Display_Error(string ErrorMessage, string MessageType)
    {
        try
        {
            if (MessageType == "Error")
            {
                lblMessage.Visible = true;
                lblMessage.Text = ErrorMessage.Trim();
                lblMessage.CssClass = "ErrorMessage";
            }
            else
            {
                lblMessage.Visible = true;
                lblMessage.Text = ErrorMessage.Trim();
                lblMessage.CssClass = "SuccessMessage";
            }


        }
        catch (Exception ex)
        {
            lblMessage.Visible = true;
            lblMessage.Text = ex.Message;
            lblMessage.CssClass = "ErrorMessage";
        }

    }    
    private void Updating_ValidCheque_Info(string pUploadFilePath)
    { 
        
                string strCon = "Provider=Microsoft.Jet.OLEDB.4.0;data source=" + pUploadFilePath;
                OleDbConnection oleCon = new OleDbConnection(strCon);
                oleCon.Open();

                OleDbCommand oleCom = new OleDbCommand("Select * from trxnheader Where invalidtrxnyn='N'");
                oleCom.Connection = oleCon;

                OleDbDataAdapter oleDA = new OleDbDataAdapter(oleCom);
        
                DataTable dt = new DataTable();
                oleDA.Fill(dt);                               
                oleCon.Close();

                string phoneNo = "";
                string ReceiptNo = "";
                string[] UpdateColumn = new string[2];
                string RemarkValue = "";

                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i <= dt.Rows.Count - 1; i++)
                    {
                        RemarkValue = dt.Rows[i]["remarks"].ToString();

                        RemarkValue = RemarkValue.Replace("'", "`");

                        UpdateColumn = RemarkValue.Split('*');
                            
                        phoneNo = "";
                        ReceiptNo ="";

                        if (UpdateColumn.Length == 1)
                        {
                            ReceiptNo = UpdateColumn[0];
                        }
                        else if (UpdateColumn.Length==2)
                        {   
                            ReceiptNo = UpdateColumn[0];
                            phoneNo = UpdateColumn[1];
                        }
                        else if (UpdateColumn.Length > 2)
                        {
                            ReceiptNo = UpdateColumn[0];
                            phoneNo = UpdateColumn[1];
                        }
                        if ((phoneNo!="")|| (ReceiptNo!=""))
                        {
                            
                            Update_Phone_ReceiptNo_From_Mdb(phoneNo, ReceiptNo, pUploadFilePath, dt.Rows[i]["serialno"].ToString());
                        }                
                    }
                }
    
    }
    private void Update_Phone_ReceiptNo_From_Mdb(string phoneNo, string ReceiptNo, string pUploadFilePath,string SerialNo)
    {
        string ReceiptNoNEW="";
        if (ReceiptNo!="")
        {
            if (ReceiptNo.Length >= 8)
            {
                ReceiptNoNEW = ReceiptNo.Substring(0, 8);
            }
        } 
        string strCon = "Provider=Microsoft.Jet.OLEDB.4.0;data source=" + pUploadFilePath;
        OleDbConnection oleCon = new OleDbConnection(strCon);
        oleCon.Open();

        OleDbCommand oleCom = new OleDbCommand("Update  trxnheader Set phoneno='" + phoneNo + "',receiptno='" + ReceiptNoNEW + "' Where serialno=" + SerialNo);
        oleCom.Connection = oleCon;
        oleCom.ExecuteNonQuery();
        oleCon.Close();    
    
    }
    private void Updating_InvalidCheque_Info(string pUploadFilePath,string pFilePath)
    {
        string DBFMaster = Convert.ToString(ConfigurationSettings.AppSettings["FileUploadPath"]);
        System.Data.Odbc.OdbcConnection oConn = new System.Data.Odbc.OdbcConnection();
        oConn.ConnectionString = @"Driver={Microsoft Visual FoxPro Driver};SourceType=DBF;SourceDB=" + DBFMaster + ";Exclusive=No; Collate=Machine;NULL=NO;DELETED=NO;BACKGROUNDFETCH=NO;";
        oConn.Open();
        System.Data.Odbc.OdbcCommand oCmd = oConn.CreateCommand();

        string[] strTableName = pFilePath.Split('\\');
        string TableName = "";
        if (strTableName.Length > 0)
        {
            TableName = strTableName[strTableName.Length - 1];

        }
        pFilePath = pFilePath.Trim();
        pFilePath = pFilePath.Replace("\\\\", "\\");

        oCmd.CommandText = @"Select * from " + TableName + "  where between(pickup_dt,{^" + Get_DateFormat(txtPickupDate.Text.Trim(), "yyyy/MM/dd") + "},{^" + Get_DateFormat(txtPickupDate.Text.Trim(), "yyyy/MM/dd") + "})  ";
       
        DataTable dt = new DataTable();
        dt.Load(oCmd.ExecuteReader());
        oConn.Close();
        string phoneNo = "";
        string ReceiptNo = "";
        string[] UpdateColumn = new string[2];
        string RemarkValue = "";

        if (dt.Rows.Count > 0)
        {
            for (int i = 0; i <= dt.Rows.Count - 1; i++)
            {
                RemarkValue = dt.Rows[i]["remark"].ToString();

                RemarkValue=RemarkValue.Replace("'", "`");

                UpdateColumn = RemarkValue.Split('*');
                
                phoneNo = "";
                ReceiptNo = "";

                if (UpdateColumn.Length == 1)
                {
                    ReceiptNo = UpdateColumn[0];
                }
                else if (UpdateColumn.Length == 2)
                {   
                    ReceiptNo = UpdateColumn[0];
                    phoneNo = UpdateColumn[1];
                }
                else if (UpdateColumn.Length > 2)
                {
                    ReceiptNo = UpdateColumn[0];
                    phoneNo = UpdateColumn[1];
                }
                if ((phoneNo != "") || (ReceiptNo != ""))
                {
                    Update_Phone_ReceiptNo_From_Invalid(phoneNo.Trim(), ReceiptNo.Trim(), pUploadFilePath.Trim(),Convert.ToInt32(dt.Rows[i]["Chq_no"].ToString().Trim()),Convert.ToDecimal(dt.Rows[i]["Chq_amt"].ToString().Trim()));
                }
            }
        }

    }
    private void Update_Phone_ReceiptNo_From_Invalid(string phoneNo, string ReceiptNo, string pUploadFilePath,Int32 ChequeNo,Decimal ChequeAmount)
    {

        string ReceiptNoNEW = "";
        if (ReceiptNo != "")
        {
            if (ReceiptNo.Length >= 8)
            {
                ReceiptNoNEW = ReceiptNo.Substring(0, 8);
            }
        } 
        string strCon = "Provider=Microsoft.Jet.OLEDB.4.0;data source=" + pUploadFilePath;
        OleDbConnection oleCon = new OleDbConnection(strCon);
        oleCon.Open();

        OleDbCommand oleCom = new OleDbCommand("Update  trxnheader Set phoneno='" + phoneNo + "', receiptno='" + ReceiptNoNEW + "' Where instno='" + ChequeNo + "' And trxnamount=" + ChequeAmount);
        oleCom.Connection = oleCon;
        oleCom.ExecuteNonQuery();
        oleCon.Close();

    }
    private string Get_DateFormat(string cDate, string cDateFormat)
        {
            try
            {
                string strDate = cDate;
                string[] strArrDate = strDate.Split('/');

                if (strArrDate.Length > 0)
                {
                    if (cDateFormat == "yyyy/MM/dd")
                    {
                        strDate = strArrDate[2] + "/" + strArrDate[1] + "/" + strArrDate[0];

                    }
                }

                return strDate;
            }
            catch (Exception ex)
            {
                lblMessage.Text = ex.Message;
                lblMessage.CssClass = "ErrorMessage";
                lblMessage.Visible = true;
                return "";
            }

        }
    private void Download_MdbFile(string strFileName)
    {
        if (Session["UploadFilesPath"] != null)
        {
            string FileNamePath = Session["UploadFilesPath"].ToString();
            string[] arrFileName = FileNamePath.Split('\\');

            //string strFileName = arrFileName[arrFileName.Length - 1];

            Response.AppendHeader("Content-Disposition", "attachment; filename=" + strFileName.Trim());
            //Response.Headers.Add(FileName,"");
            Response.ContentType = "application/Msaccess";//"application/x-msexcel";
            Response.Flush();

            Response.WriteFile(FileNamePath.Trim(), true);

            HttpContext.Current.Response.End();
        }
    }     
       
}
