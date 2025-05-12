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
using System.IO;

public partial class Pages_ChequeProcessing_FileCashReceiptUpload : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnUpload_Click(object sender, EventArgs e)
    {
        Upload_FilesOn_Server();
    }
    private void Upload_FilesOn_Server()
    {
        try
        {
            /////////NEW PAGE     
            

            string fullSitePath = Convert.ToString(ConfigurationSettings.AppSettings["FileUploadPath"]); //this.Request.PhysicalApplicationPath;
            fullSitePath = fullSitePath.Trim();
            string FileSavePath = "";

            string[] UploadFilesPath = new string[5];

            string FileName_ValidDBF = Convert.ToString(FileUpload_ValidExcel.FileName.Trim());
            FileSavePath = fullSitePath + FileName_ValidDBF;

            FileInfo FFileName_ValidDBF = new FileInfo(FileSavePath);
            if (FFileName_ValidDBF.Exists)
            {
                File.Delete(FileSavePath);
            }

            UploadFilesPath[0] = FileSavePath;
            FileUpload_ValidExcel.SaveAs(FileSavePath);

            Get_ExcelFileRecord(2, FileSavePath);    

        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
            lblMessage.CssClass = "ErrorMessage";
        } 
    }
    private void Get_ExcelFileRecord(int intFileNameIndex, string pFileName)
    {
        try
        {  
            string pFilePath = pFileName;
             
            if (pFilePath != "")
            {
                string strCon = "Provider=Microsoft.Jet.OLEDB.4.0;data source=" + pFilePath + @";Extended Properties=""Excel 8.0;IMEX=1"""; ;

                OleDbConnection oleCon = new OleDbConnection(strCon);
                oleCon.Open();

                OleDbCommand oleCom = new OleDbCommand(@"Select '' As batch_no,'MCP' as loca_code,'' as col_pt_cd,'' as srno,'1' as sub_srno,'1' as no_of_ent,'' as valid_stub,'NOR' as tran_type,'' as sus_flag,[Card number (16 digit)] as card_no,'Cash' as pymt_mode,'C' as pymt_type,'' as cr_card_no,'' as author_no,'' as cc_type,'" + txtPickupDate.Text.Trim() + "' as pickup_dt, '" + txtDepositFromDate.Text.Trim() + "' as deposit_dt, '' as chq_no,'" + txtPickupDate.Text.Trim()+"' as chq_dt ,[Transaction Amount] as chq_amt,[Transaction Amount] as tot_amt, '' as bank_id,'' as bank_code,'' as branch_id,'' as branch_cd,'' as micr_code,'' as acno,'' as dep_slip,'' as deposit_ty,'FALSE' as dat_create,'' as dat_dt, [Receipt Number] as remark,'KALPANA004' as ent_by,'VIJAY006' as ver_by,'' as pdc_conv,'' as pdc,'' as captime,'' as captime1,'' as lot_no, '' As IsValid,[Agency Name] as Agency  from [sheet1$]");
                oleCom.Connection = oleCon;

                OleDbDataAdapter da = new OleDbDataAdapter();
                da.SelectCommand = oleCom;

                DataTable dtMain = new DataTable();
                da.Fill(dtMain);

              
                oleCon.Close();
                DataTable dtBinLogo = new DataTable();
                DataTable dtCashMaster = new DataTable();

                dtBinLogo = Upload_RecordTo_Grid("binlogo.dbf","Select Bincode,logocode from binlogo.dbf");
                dtCashMaster = Upload_RecordTo_Grid("drpbxmst_Cash.dbf", "Select DropCode,DropName from drpbxmst_Cash.dbf");

                string Agency_Name="";
                string CardNo="";
                string BinLogo="";
                for (int i = 0; i <= dtMain.Rows.Count - 1; i++)
                {
                    Agency_Name = dtMain.Rows[i]["Agency"].ToString();
                    CardNo = dtMain.Rows[i]["card_no"].ToString();
                    if (CardNo.Length > 0)
                    {
                        CardNo = CardNo.Substring(0, 9);
                    }
                        if (CardNo != "")
                        {
                            for (int j = 0; j <= dtBinLogo.Rows.Count - 1; j++)
                            {

                                BinLogo = dtBinLogo.Rows[j]["BinCode"].ToString() + dtBinLogo.Rows[j]["LogoCode"].ToString();
                                if (BinLogo.Trim() == CardNo.Trim())
                                {
                                    if (dtMain.Rows[i]["card_no"].ToString().Length==16)
                                    {
                                        dtMain.Rows[i]["IsValid"] = Validate_CreditCardNo(dtMain.Rows[i]["card_no"].ToString());
                                    }
                                }
                                  
                                 

                            }
                        }
                    dtMain.Rows[i]["card_no"] = "'"+dtMain.Rows[i]["card_no"].ToString();

                    for (int m = 0; m <= dtCashMaster.Rows.Count - 1; m++)
                    {
                        if (Agency_Name.ToUpper().Trim() == dtCashMaster.Rows[m]["DropName"].ToString().ToUpper().Trim())
                        {
                            dtMain.Rows[i]["col_pt_cd"] = dtCashMaster.Rows[m]["DropCode"].ToString().Trim() ;
                            break;
                        }
                    }
                }
                
                //for (int m = 0; m <= dtCashMaster.Rows.Count - 1; m++)
                //    {
                //        DataView dv = new DataView(); 
                        
                //        DataTable dtTemp = new DataTable();    
                        
                //        dv.RowFilter = "col_pt_cd= '" + dtCashMaster.Rows[0]["DropCode"].ToString().Trim()+"'";
                //        dtTemp = dv.Table ;
                        
                // }

                gvUploadedDATA.DataSource = dtMain;
                gvUploadedDATA.DataBind(); 
            }
        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
            lblMessage.CssClass = "ErrorMessage";
        }


    }
    //private DataTable  Upload_RecordTo_Grid(string pFilePath)
    //{
    //    try
    //    {
    //        if (pFilePath != "")
    //        {

    //            System.Data.Odbc.OdbcConnection oConn = new System.Data.Odbc.OdbcConnection();
    //            oConn.ConnectionString = @"Driver={Microsoft Visual FoxPro Driver};SourceType=DBF;SourceDB=" + Convert.ToString(ConfigurationSettings.AppSettings["MasterDBFFiles"]) + ";Exclusive=No; Collate=Machine;NULL=NO;DELETED=NO;BACKGROUNDFETCH=NO;";
    //            oConn.Open();
    //            System.Data.Odbc.OdbcCommand oCmd = oConn.CreateCommand();

    //            string[] strTableName = pFilePath.Split('\\');
    //            string TableName = "";
    //            if (strTableName.Length > 0)
    //            {
    //                TableName = strTableName[strTableName.Length - 1];

    //            }
    //            pFilePath = pFilePath.Trim();
    //            pFilePath = pFilePath.Replace("\\\\", "\\");
    //            //oCmd.CommandText = "Select '' as sr_no,Col_pt_Cd,CapTime, '' as Dropbox_Master, '' as Source,Card_No,Chq_no,chq_amt,chq_dt,MICR_code,'MUMBAI' as City,'Maharashtra' as State,Reason, '' as ContactDetails,'' as Remark from " + TableName + "  where between(deposit_dt,{^" + Get_DateFormat(txtDepositFromDate.Text.Trim(), "yyyy/MM/dd") + "},{^" + Get_DateFormat(txtDepositToDate.Text.Trim(), "yyyy/MM/dd") + "})";
    //            oCmd.CommandText = @"Select Bincode,logocode from binlogo.dbf ";                 

    //            DataTable dt = new DataTable();
    //            dt.Load(oCmd.ExecuteReader());
    //            oConn.Close();
    //            return dt;
    //        }
    //        return null;
    //    }
    //    catch (Exception ex)
    //    {
    //        lblMessage.Text = ex.Message;
    //        lblMessage.CssClass = "ErrorMessage";
    //        lblMessage.Visible = true;
    //        return null;
    //    }



    //}
    protected void btnGenerate_Click(object sender, EventArgs e)
    {
        Generate_ExcelFile();
    }
    private void Generate_ExcelFile()
    {



        String attachment = "attachment; filename=CashValidate.xls";
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
        tblCell1.Text = "<b><font size='3'>PAMAC FINSERVE PVT. LTD., MUMBAI</font></b> <br/>" +
                        "<b><font size='2' color='blue'>Cash Validated For Pickupdate Date : " + txtPickupDate.Text + ", Deposit Date :" + txtDepositFromDate.Text + " </font></b> <br/>";
        tblCell1.CssClass = "SuccessMessage";
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
    public override void VerifyRenderingInServerForm(Control control)
    {

    }
    private string Validate_CreditCardNo(string CardNo)
    {
        string IsValidate = "";
        //ArrayList ComapareList[]=new ArrayList[16];
        int[] ComapareList = new int[CardNo.Length];
        ComapareList[0] = 1;
        ComapareList[1] = 2;
        ComapareList[2] = 1;
        ComapareList[3] = 2;
        ComapareList[4] = 1;
        ComapareList[5] = 2;
        ComapareList[6] = 1;
        ComapareList[7] = 2;
        ComapareList[8] = 1;
        ComapareList[9] = 2;
        ComapareList[10] = 1;
        ComapareList[11] = 2;
        ComapareList[12] = 1;
        ComapareList[13] = 2;
        ComapareList[14] = 1;
        ComapareList[15] = 2;



        int intCDigit = 0;
        int SumOfValue = 0;
        int ArrayCount = 15;
        if (CardNo.Length == 16)
        {
            for (int i = 0; i <= CardNo.Length - 1; i++)
            {
                intCDigit = Convert.ToInt32(CardNo[i].ToString());
                intCDigit = intCDigit * ComapareList[ArrayCount];                
                ArrayCount = ArrayCount - 1;

                if (intCDigit < 10)
                {
                    SumOfValue = SumOfValue + intCDigit;
                }
                else
                {
                    intCDigit = intCDigit / 10 + (intCDigit % 10);

                    SumOfValue = SumOfValue + intCDigit;
                }
            }

            if (SumOfValue % 10 == 0)
            {
                IsValidate = "true";
            }
            else
            {
                IsValidate = "false";
            }
        }
        return IsValidate;
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Pages/Menu.aspx",true);
    }
    private DataTable Upload_RecordTo_Grid(string pFilePath,string strCommand)
    {
        try
        {
            if (pFilePath != "")
            {

                System.Data.Odbc.OdbcConnection oConn = new System.Data.Odbc.OdbcConnection();
                oConn.ConnectionString = @"Driver={Microsoft Visual FoxPro Driver};SourceType=DBF;SourceDB=" + Convert.ToString(ConfigurationSettings.AppSettings["MasterDBFFiles"]) + ";Exclusive=No; Collate=Machine;NULL=NO;DELETED=NO;BACKGROUNDFETCH=NO;";
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
                //oCmd.CommandText = "Select '' as sr_no,Col_pt_Cd,CapTime, '' as Dropbox_Master, '' as Source,Card_No,Chq_no,chq_amt,chq_dt,MICR_code,'MUMBAI' as City,'Maharashtra' as State,Reason, '' as ContactDetails,'' as Remark from " + TableName + "  where between(deposit_dt,{^" + Get_DateFormat(txtDepositFromDate.Text.Trim(), "yyyy/MM/dd") + "},{^" + Get_DateFormat(txtDepositToDate.Text.Trim(), "yyyy/MM/dd") + "})";
                oCmd.CommandText=strCommand.Trim();
                //oCmd.CommandText = @"Select Bincode,logocode from binlogo.dbf ";

                DataTable dt = new DataTable();
                dt.Load(oCmd.ExecuteReader());
                oConn.Close();
                return dt;
            }
            return null;
        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
            lblMessage.CssClass = "ErrorMessage";
            lblMessage.Visible = true;
            return null;
        }



    }
}
