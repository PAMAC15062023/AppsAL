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
using System.Data.SqlClient;
using System.IO;

public partial class Pages_ChequeProcessing_Reports_ProcessMIS : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnUpload_Click(object sender, EventArgs e)
    {
        try
        {
            if (chkFileUploaded.Checked == true)
            {
                if (Session["UploadFilesPath"] != null)
                {
                    Get_ReportFormat();
                }
            }
            else
            {
                if (Validate_UploadFiles())
                {
                    UploadFiles_OnServer();
                }
            }
        }
        catch (Exception ex)
        {
            lblMessage.Visible = true;
            lblMessage.Text = ex.Message;
            lblMessage.CssClass = "ErrorMessage";
        }
    }
    private void UploadFiles_OnServer()
    {
        try
        {
            string fullSitePath = Convert.ToString(ConfigurationSettings.AppSettings["ProcessMIS"]); //this.Request.PhysicalApplicationPath;
            fullSitePath = fullSitePath.Trim();

            string FileSavePath = "";
            

            string[] UploadFilesPath=new string[6];

             

            string[] FileFormat_MDB = FileUpload_MDB.FileName.Split('.');
            string FileName_MBB = Convert.ToString(DateTime.Now.ToString("yyyyMMddHHmmss")) + "_ValidMDB." + FileFormat_MDB[FileFormat_MDB.Length - 1];
            FileSavePath = fullSitePath + FileName_MBB;
            FileUpload_MDB.SaveAs(FileSavePath);            
            UploadFilesPath[0] = FileSavePath;


            string[] FileFormat_UpDBF = FileUpload_Upcoutry.FileName.Split('.');
            string FileName_UpCountryDBF = Convert.ToString(DateTime.Now.ToString("yyyyMMddHHmmss")) + "_UpContDBF." + FileFormat_UpDBF[FileFormat_UpDBF.Length - 1];
            FileSavePath = fullSitePath + FileName_UpCountryDBF;
            FileUpload_Upcoutry.SaveAs(FileSavePath);            
            UploadFilesPath[1] = FileSavePath;

            string[] FileFormat_INVDBF = FileUpload_Suspense.FileName.Split('.');
            string FileName_INVALIDDBF = Convert.ToString(DateTime.Now.ToString("yyyyMMddHHmmss")) + "_InvalidDBF." + FileFormat_INVDBF[FileFormat_INVDBF.Length - 1];
            FileSavePath = fullSitePath + FileName_INVALIDDBF;
            FileUpload_Suspense.SaveAs(FileSavePath);
            UploadFilesPath[2] = FileSavePath;

            string[] FileFormat_OTHDBF = FileUpload_OtherBankDBF.FileName.Split('.');
            string FileName_OTHDBF = Convert.ToString(DateTime.Now.ToString("yyyyMMddHHmmss")) + "_OthDBF." + FileFormat_OTHDBF[FileFormat_OTHDBF.Length - 1];
            FileSavePath = fullSitePath + FileName_OTHDBF;
            FileUpload_OtherBankDBF.SaveAs(FileSavePath);
            UploadFilesPath[3] = FileSavePath;

            string[] FileFormat_PDCReport = FileUpload_PDCReport.FileName.Split('.');
            string FileName_PDCReport = Convert.ToString(DateTime.Now.ToString("yyyyMMddHHmmss")) + "_ExcelDBF." + FileFormat_PDCReport[FileFormat_PDCReport.Length - 1];
            FileSavePath = fullSitePath + FileName_PDCReport;
            FileUpload_PDCReport.SaveAs(FileSavePath);
            UploadFilesPath[4] = FileSavePath;

            UploadFilesPath[5] = FileUpload_MDB.FileName.Trim();
           
            Session["UploadFilesPath"] = UploadFilesPath;
            

            Get_ReportFormat();
             

        }
        catch (Exception ex)
        {
            lblMessage.Visible = true;
            lblMessage.Text = ex.Message;
            lblMessage.CssClass = "ErrorMessage";
        }
    }
    protected void btnExport_Click(object sender, EventArgs e)
    {
                try
                {
                    Generate_ExcelFile();
                }

                catch (Exception ex)
                {
                    Display_Error(ex.Message, "Error");                 
                }
    }
    private void Generate_ExcelFile()
    {
        Object SaveUSERInfo = (Object)Session["UserInfo"];
        String strBranchName = ((UserInfo.structUSERInfo)(SaveUSERInfo)).BranchName;
           
        String attachment = "attachment; filename=ProcessMIS.xls";
        Response.AddHeader("content-disposition", attachment);
        Response.ContentType = "application/ms-excel";
        StringWriter sw = new System.IO.StringWriter();
        HtmlTextWriter htw = new HtmlTextWriter(sw);
        Table tblSpace = new Table();
        TableRow tblRow = new TableRow();
        TableCell tblCell = new TableCell();
        tblCell.Text = " ";

        TableRow tblRow1 = new TableRow();
        TableCell tblCell1 = new TableCell();
        tblCell1.ColumnSpan = 20;// 10;
        tblCell1.Text = "<b><font size='3'>PAMAC FINSERVE PVT. LTD., " + strBranchName + "</font></b> <br/>" +
                        "<b><font size='2' color='blue'>ProcessMIS For Date : " + txtDepositFromDate.Text + " </font></b> <br/>";
        
        tblRow.Cells.Add(tblCell);
        tblRow1.Cells.Add(tblCell1);
        tblRow.Height = 20;
        tblSpace.Rows.Add(tblRow);
        tblSpace.Rows.Add(tblRow1);
        tblSpace.RenderControl(htw);

        Table tbl = new Table();
        gvUploadedDATA.EnableViewState = false;
        gvUploadedDATA.GridLines = GridLines.Both;
        tbExport.RenderControl(htw);
        Response.Write(sw.ToString());

        Response.End();
    }
    protected void btnClose_Click(object sender, EventArgs e)
    {

        try
        {
            Response.Redirect("~/pages/Menu.aspx", false);

        }
        catch (Exception ex)
        {
            lblMessage.Visible = true;
            lblMessage.Text = ex.Message;
            lblMessage.CssClass = "ErrorMessage";
        }
    }
    private Boolean Validate_UploadFiles()
    {
        try
        {
            Boolean ReturnValue = true;

            if (FileUpload_MDB.FileName != "")
            {

                string[] FileFormat = FileUpload_MDB.FileName.Split('.');
                if (FileFormat[FileFormat.Length - 1] != "mdb")
                {
                    Display_Error("Please Select Valid MDB File!", "Error"); 
                    return false;
                }
            }
            else 
             {
                Display_Error("Please select MDB File!", "Error");                 
                return false; 
             }

             if (FileUpload_OtherBankDBF.FileName != "")
             {

                 string[] FileFormat = FileUpload_OtherBankDBF.FileName.Split('.');
                 if (FileFormat[FileFormat.Length - 1] != "dbf")
                 {
                     Display_Error("Please Select Valid OtherBank DBF File!", "Error");
                     return false;
                 }
             }
             else
             {
                 Display_Error("Please select OtherBank DBF File!", "Error");
                 return false;
             }
              

             if (FileUpload_Suspense.FileName != "")
             {

                 string[] FileFormat = FileUpload_Suspense.FileName.Split('.');
                 if (FileFormat[FileFormat.Length - 1] != "xls")
                 {
                     Display_Error("Please Select Suspense Bounce Excel File!", "Error"); 
                     return false;
                 }
             }
             else
             {
                 Display_Error("Please select Suspense Bounce Excel File!", "Error"); 
                 return false;
             }

             if (FileUpload_Upcoutry.FileName != "")
             {

                 string[] FileFormat = FileUpload_Upcoutry.FileName.Split('.');
                 if (FileFormat[FileFormat.Length - 1] != "dbf")
                 {
                     Display_Error("Please Select Valid Upcoutry DBF File!", "Error");
                     return false;
                 }
             }
             else
             {
                 Display_Error("Please select Upcoutry DBF File!", "Error");
                 return false;
             }


             if (FileUpload_PDCReport.FileName != "")
             {

                 string[] FileFormat = FileUpload_PDCReport.FileName.Split('.');
                 if (FileFormat[FileFormat.Length - 1] != "xls")
                 {
                     Display_Error("Please Select Valid PDC Excel File!", "Error");
                     return false;
                 }
             }
             else
             {
                 Display_Error("Please select PDC Excel File!", "Error");
                 return false;
             }

            

            return ReturnValue;
        }
        catch (Exception ex)
        {
            lblMessage.Visible = true;
            lblMessage.Text = ex.Message;
            lblMessage.CssClass = "ErrorMessage";
            return false;
        }
    }
    private void Display_Error(string ErrorMessage,string MessageType)
    {
      try
        {
          if (MessageType=="Error")
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
    private int Get_MDB_Details_Count(string SQLstring)
    { 
          try
            {
              //SELECT Count(*) FROM trxnheader Where tranType in('PRU','PRT')
                string[] strUploadFileName = (string[])Session["UploadFilesPath"];

               string pFilePath = strUploadFileName[0].ToString();
               int TotalCount = 0;
               if (pFilePath != "")
               {
                   string strCon = "Provider=Microsoft.Jet.OLEDB.4.0;data source=" + pFilePath;
                   OleDbConnection oleCon = new OleDbConnection(strCon);
                   oleCon.Open();

                   OleDbCommand oleCom = new OleDbCommand(SQLstring);
                   oleCom.Connection = oleCon;

                   TotalCount =Convert.ToInt32(oleCom.ExecuteScalar());                     

                   oleCon.Close();
               }
               return TotalCount;

            }
            catch (Exception ex)
            {
                Display_Error(ex.Message, "Error");
                return 0;
            }

    }
    private int Get_UpCountry_Count(string SQLString)
    {
        try
        {
            int Count=0;
            string DBFMaster = Convert.ToString(ConfigurationSettings.AppSettings["ProcessMIS"]); //this.Request.PhysicalApplicationPath;

            System.Data.Odbc.OdbcConnection oConn = new System.Data.Odbc.OdbcConnection();
            oConn.ConnectionString = @"Driver={Microsoft Visual FoxPro Driver};SourceType=DBF;SourceDB=" + Convert.ToString(ConfigurationSettings.AppSettings["ProcessMIS"]) + ";Exclusive=No; Collate=Machine;NULL=NO;DELETED=NO;BACKGROUNDFETCH=NO;";
            oConn.Open();
            System.Data.Odbc.OdbcCommand oCmd = oConn.CreateCommand();


            string[] strUploadFileName = (string[])Session["UploadFilesPath"];
            string pFilePath = strUploadFileName[1].ToString();
            string[] strTableName = pFilePath.Split('\\');
            string TableName = "";
            if (strTableName.Length > 0)
            {
                TableName = strTableName[strTableName.Length - 1];

            }
            pFilePath = pFilePath.Trim();
            pFilePath = pFilePath.Replace("\\\\", "\\");

            oCmd.CommandText = @"Select  Count(*) from " + TableName + " where between(pickup_dt,{^" + Get_DateFormat(txtDepositFromDate.Text.Trim(), "yyyy/MM/dd") + "},{^" + Get_DateFormat(txtDepositFromDate.Text.Trim(), "yyyy/MM/dd") + "})  ";

            Count =Convert.ToInt32(oCmd.ExecuteScalar());
              
            oConn.Close();

            return Count;
        }
 
        catch (Exception ex)
        {
            Display_Error(ex.Message, "Error");
            return 0;
        }
    
    }
    private int Get_OtherParty_Count(string SQLString)
    {
        try
        {
            int Count = 0;
            string DBFMaster = Convert.ToString(ConfigurationSettings.AppSettings["ProcessMIS"]); //this.Request.PhysicalApplicationPath;

            System.Data.Odbc.OdbcConnection oConn = new System.Data.Odbc.OdbcConnection();
            oConn.ConnectionString = @"Driver={Microsoft Visual FoxPro Driver};SourceType=DBF;SourceDB=" + Convert.ToString(ConfigurationSettings.AppSettings["ProcessMIS"]) + ";Exclusive=No; Collate=Machine;NULL=NO;DELETED=NO;BACKGROUNDFETCH=NO;";
            oConn.Open();
            System.Data.Odbc.OdbcCommand oCmd = oConn.CreateCommand();


            string[] strUploadFileName = (string[])Session["UploadFilesPath"];
            string pFilePath = strUploadFileName[3].ToString();
            string[] strTableName = pFilePath.Split('\\');
            string TableName = "";
            if (strTableName.Length > 0)
            {
                TableName = strTableName[strTableName.Length - 1];

            }
            pFilePath = pFilePath.Trim();
            pFilePath = pFilePath.Replace("\\\\", "\\");

            oCmd.CommandText = @"Select  Count(*) from " + TableName + " where between(pickup_dt,{^" + Get_DateFormat(txtDepositFromDate.Text.Trim(), "yyyy/MM/dd") + "},{^" + Get_DateFormat(txtDepositFromDate.Text.Trim(), "yyyy/MM/dd") + "})  ";

            Count =Convert.ToInt32( oCmd.ExecuteScalar());

            oConn.Close();

            return Count;
        }

        catch (Exception ex)
        {
            Display_Error(ex.Message, "Error");
            return 0;
        }

    }
    private int Get_ExcelFileRecord(int intFileNameIndex, string SQLstring)    {
        try
        {
            //SELECT Count(*) FROM trxnheader Where tranType in('PRU','PRT')
            string[] strUploadFileName = (string[])Session["UploadFilesPath"];

            string pFilePath = strUploadFileName[intFileNameIndex].ToString();
            int TotalCount = 0;
            if (pFilePath != "")
            {
                string strCon = "Provider=Microsoft.Jet.OLEDB.4.0;data source=" + pFilePath + @";Extended Properties=""Excel 8.0;IMEX=1"""; ;
                
                OleDbConnection oleCon = new OleDbConnection(strCon);
                oleCon.Open();

                OleDbCommand oleCom = new OleDbCommand(SQLstring);
                oleCom.Connection = oleCon;

                TotalCount = Convert.ToInt32(oleCom.ExecuteScalar());

                oleCon.Close();
            }
            return TotalCount;

        }
        catch (Exception ex)
        {
            Display_Error(ex.Message, "Error");
            return 0;
        }
    
    
    } 
    private void Get_ReportFormat()
    { 
      try
        {
   

            SqlConnection sqlCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);

            sqlCon.Open();
            SqlCommand sqlCom = new SqlCommand();
            sqlCom.Connection = sqlCon;
            sqlCom.CommandType = CommandType.Text;
            sqlCom.CommandText = "Select * from ProcessMIS";
            SqlDataAdapter sqlDA = new SqlDataAdapter();
            sqlDA.SelectCommand = sqlCom;
            DataTable dt = new DataTable();
            sqlDA.Fill(dt);
            sqlCon.Close();

            DataTable dtnew = Insert_valueInTable(dt, 0, "Mumbai");
                    
    }
  
        catch (Exception ex)
        {
            Display_Error(ex.Message, "Error");
             
        }
    }
    private DataTable Insert_valueInTable(DataTable dt,int ColumnIndex,string ColumnValue)
    {
        try
        {
            Object SaveUSERInfo = (Object)Session["UserInfo"];
            String strBranchName = ((UserInfo.structUSERInfo)(SaveUSERInfo)).BranchName;
            
                    DataRow dtRow;
                    dtRow = dt.NewRow();


                    string[] strUploadFileName = (string[])Session["UploadFilesPath"];
                    string MDBFileName = strUploadFileName[5].ToString();


                    dtRow["City"] = "";
                    dtRow["Date"] = txtDepositFromDate.Text.Trim();
                    dtRow["Collection_from_SBI_Branch_boxes_and_GE_Office"] = Get_MDB_Details_Count(" SELECT Count(*) from trxnheader ");
                    dtRow["Collection_from_PAMACBoxes"] = 0;  //Default Zeo
                    dtRow["Matured_PDC_for_the_day_Valid"] = Get_ExcelFileRecord(4, "Select Count(*) from [sheet1$]");
                    dtRow["Returns_from_Bank_Total_Bounces_including_Direct"] = (Get_MDB_Details_Count("SELECT Count(*) FROM trxnheader Where tranType in('PRU','PRT','PRL','PRM')") + Get_ExcelFileRecord(2, "Select Count(*) from [sheet1$]"));
                    dtRow["No_of_cash_entries_recd"] = 0;   //Default Zeo
                    dtRow["Bounce_to_be_represented_for_the_day"] = Get_MDB_Details_Count(" SELECT Count(*) from trxnheader Where dropboxid ='MUM135' ");
                    dtRow["Total_Incoming"] = 0;
                    dtRow["Valid_cheques"] = Get_MDB_Details_Count("Select Count(*) from trxnheader where insttype='C' and trantype in ('N11','NP6','N50','KH1','N33','N25','NP9','N49','N16') and dsnumber <>''");
                    dtRow["DD_And_Payorder"] = Get_MDB_Details_Count("SELECT Count(*) from trxnheader Where insttype ='D'");
                    dtRow["No_of_cash_entries"] = 0;        //Default Zeo
                    dtRow["Bounce_captured_Direct"] = 0;    //Default Zeo
                    dtRow["Bounce_processed"] = Get_MDB_Details_Count("SELECT Count(*) FROM trxnheader Where tranType in('PRU','PRT')"); ;
                    dtRow["Valid_PDC_cheques"] = Get_MDB_Details_Count("SELECT Count(*) from trxnheader Where remarks Like 'PDC CHEQUE'");
                    dtRow["Invalid_cheques_to_be_banked"] = 0;//Default Zeo
                    dtRow["Invalid_cheques_to_be_given_to_GE"] = Get_MDB_Details_Count("SELECT Count(*) FROM trxnheader Where invalidtrxnyn='Y'And Remarks not in( 'PDC CHEQUE', 'OUTSTATION CHQS NOT ACCEPTED' ) ");
                    dtRow["Upcountry_cheques"] = Get_UpCountry_Count("");
                    dtRow["Other_party_cheques"] = Get_OtherParty_Count("");
                    dtRow["Suspense_cheques"] = Get_MDB_Details_Count("SELECT Count(*) from trxnheader Where trantype ='SP1'  ");
                    dtRow["Invalid_Cheque_Outstation"] = Get_MDB_Details_Count("SELECT Count(*) FROM trxnheader Where  Remarks in  ( 'OUTSTATION CHQS NOT ACCEPTED' ) ");
                    dtRow["PDC_With_SBI_BANK_for_the_day"] = Get_ExcelFileRecord(4, "Select Count(*) from [sheet1$]");
                    dtRow["Suspense_Pdc"] = 0;//Default Zeo
                    dtRow["Suspense_Bounce"] = Get_ExcelFileRecord(2, "Select Count(*) from [sheet1$]");
                    dtRow["Total_Chq_processed"] = 0;
                    dtRow["Total_for_Banking"] = Get_MDB_Details_Count("SELECT Count(*) FROM trxnheader Where dsnumber<>''");
                    dtRow["Total_handed_to_GE"] = 0;
                    dtRow["To_GE_Excluding_Bounces"] = 0;
                    dtRow["Bounce_Total_stored_at_SBI"] = Get_MDB_Details_Count("SELECT Count(*) FROM trxnheader Where tranType in('PRU','PRT','PRL','PRM')"); ;
                    dtRow["MDB_Total"] = Get_MDB_Details_Count("SELECT Count(*) FROM trxnheader");
                    dtRow["MDB_file_name"] = MDBFileName.Trim();
                    dtRow["Difference_in_Inflows_and_Outflows"] = 0;

                    dt.Rows.Add(dtRow);
                    //------------------------------------
                    dt.Rows[0]["Collection_from_SBI_Branch_boxes_and_GE_Office"] = (Convert.ToInt32(dt.Rows[0]["Collection_from_SBI_Branch_boxes_and_GE_Office"]) + Convert.ToInt32(dt.Rows[0]["Upcountry_cheques"].ToString()) + Convert.ToInt32(dt.Rows[0]["Other_party_cheques"]) + Get_ExcelFileRecord(2, "Select Count(*) from [sheet1$]")) - (Convert.ToInt32(dt.Rows[0]["Matured_PDC_for_the_day_Valid"]) + Convert.ToInt32(dt.Rows[0]["Returns_from_Bank_Total_Bounces_including_Direct"]) + Convert.ToInt32(dt.Rows[0]["Bounce_to_be_represented_for_the_day"]));
                    dt.Rows[0]["Total_Incoming"] = Convert.ToInt32(dt.Rows[0]["Collection_from_SBI_Branch_boxes_and_GE_Office"]) + Convert.ToInt32(dt.Rows[0]["Collection_from_PAMACBoxes"]) + Convert.ToInt32(dt.Rows[0]["Matured_PDC_for_the_day_Valid"]) + Convert.ToInt32(dt.Rows[0]["Returns_from_Bank_Total_Bounces_including_Direct"]) + Convert.ToInt32(dt.Rows[0]["No_of_cash_entries_recd"]) + Convert.ToInt32(dt.Rows[0]["Bounce_to_be_represented_for_the_day"]);
                    dt.Rows[0]["Valid_cheques"] = (Convert.ToInt32(dt.Rows[0]["Valid_cheques"]) - Convert.ToInt32(dt.Rows[0]["Matured_PDC_for_the_day_Valid"]));
                    dt.Rows[0]["To_GE_Excluding_Bounces"] = (Convert.ToInt32(dt.Rows[0]["Invalid_cheques_to_be_given_to_GE"]) + Convert.ToInt32(dt.Rows[0]["Upcountry_cheques"]) + Convert.ToInt32(dt.Rows[0]["Other_party_cheques"]) + Convert.ToInt32(dt.Rows[0]["Invalid_Cheque_Outstation"]));

                    dt.Rows[0]["Total_handed_to_GE"] = (Convert.ToInt32(dt.Rows[0]["No_of_cash_entries_recd"]) + Convert.ToInt32(dt.Rows[0]["Bounce_captured_Direct"]) + Convert.ToInt32(dt.Rows[0]["Bounce_processed"]) + Convert.ToInt32(dt.Rows[0]["To_GE_Excluding_Bounces"]) + Convert.ToInt32(dt.Rows[0]["Suspense_Bounce"]));

                    dt.Rows[0]["Total_Chq_processed"] = (Convert.ToInt32(dt.Rows[0]["Valid_cheques"]) + Convert.ToInt32(dt.Rows[0]["DD_And_Payorder"]) + Convert.ToInt32(dt.Rows[0]["No_of_cash_entries"]) + Convert.ToInt32(dt.Rows[0]["Bounce_captured_Direct"]) + Convert.ToInt32(dt.Rows[0]["Bounce_processed"]) + Convert.ToInt32(dt.Rows[0]["Valid_PDC_cheques"]) + Convert.ToInt32(dt.Rows[0]["Invalid_cheques_to_be_banked"]) + Convert.ToInt32(dt.Rows[0]["Invalid_cheques_to_be_given_to_GE"]) + Convert.ToInt32(dt.Rows[0]["Upcountry_cheques"]) + Convert.ToInt32(dt.Rows[0]["Other_party_cheques"]) + Convert.ToInt32(dt.Rows[0]["Suspense_cheques"]) + Convert.ToInt32(dt.Rows[0]["Invalid_Cheque_Outstation"]) + Convert.ToInt32(dt.Rows[0]["PDC_With_SBI_BANK_for_the_day"]) + Convert.ToInt32(dt.Rows[0]["Suspense_Pdc"]) + Convert.ToInt32(dt.Rows[0]["Suspense_Bounce"]));
                 


             


            gvUploadedDATA.DataSource = dt;
            gvUploadedDATA.DataBind(); 
            return dt;
        }
        catch (Exception ex)
        {
            Display_Error(ex.Message, "Error");
            return null;
        }
    }
    public override void VerifyRenderingInServerForm(Control control)
    {

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
     
}