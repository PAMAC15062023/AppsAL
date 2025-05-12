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
using System.IO;
using System.Data.Odbc;
using System.Data.OleDb;
using System.Text;
using System.Data.SqlClient;

public partial class Pages_ChequeProcessing_Reports_InvalidChequeMIS : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserInfo"] == null)
        {
            Response.Redirect("~/Pages/InvalidRequest.aspx", false);
        }
    }
    protected void btnUpload_Click(object sender, EventArgs e)
    {
        //UploadTo_Server();
        Object SaveUSERInfo = (Object)Session["UserInfo"];
        String strBranchName = ((UserInfo.structUSERInfo)(SaveUSERInfo)).BranchName;
        string FileName = strBranchName + "_invldchq.dbf";
        Upload_RecordTo_Grid(FileName.Trim());
    }
    protected void btnExport_Click(object sender, EventArgs e)
    {
        Generate_ExcelFile();
    }
    private void Generate_ExcelFile()
    {

        Object SaveUSERInfo = (Object)Session["UserInfo"];
        String strBranchName = ((UserInfo.structUSERInfo)(SaveUSERInfo)).BranchName;
      

        String attachment = "attachment; filename=InvalidChequeMIS.xls";
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
        tblCell1.Text = "<b><font size='3'>PAMAC FINSERVE PVT. LTD., " + strBranchName + " </font></b> <br/>" +
                        "<b><font size='2' color='blue'>Invalid Cheque MIS For Date : " + txtDepositFromDate.Text + " To :" + txtDepositToDate.Text + " </font></b> <br/>";
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
    protected void btnClose_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/pages/Menu.aspx", false);
    }
    //private void UploadTo_Server()
    //{
    //    if (FileUpload1.FileName != "")
    //    {
    //        string[] FileFormat = FileUpload1.FileName.Split('.');

    //        if (FileUpload1.FileName.Contains(".dbf"))
    //        {

    //            string strName = FileUpload1.FileName.Trim();

             

    //            string fullSitePath = Convert.ToString(ConfigurationSettings.AppSettings["FileUploadPath"]); //this.Request.PhysicalApplicationPath;
                 
                             
    //            string fileName = Convert.ToString(DateTime.Now.ToString("yyyyMMddHHmmss")) + "." + FileFormat[FileFormat.Length - 1];
    //            string FileSavePath = fullSitePath + fileName;
                 

    //            FileUpload1.SaveAs(FileSavePath);
    //            Session["DBFFile"] = FileSavePath;
                 
    //            Upload_RecordTo_Grid(Session["DBFFile"].ToString());
    //        }
    //        else
    //        {
    //            lblMessage.Text = "Please select valid file!";
    //            lblMessage.CssClass = "ErrorMessage";
    //        }
    //    }

    //}
    private void Upload_RecordTo_Grid(string pFilePath)
    {
        try
        {
            if (pFilePath != "")
            {
                Object SaveUSERInfo = (Object)Session["UserInfo"];
                String strBranchName = ((UserInfo.structUSERInfo)(SaveUSERInfo)).BranchName;
      
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
                oCmd.CommandText = @"Select '' As Sr_no,DMY(pickup_dt) as PickupDate, dbMst.Dropname, 'SBI    ' as Source,""'""+Card_No as CardNO,""'""+Chq_no as ChequeNo,chq_amt,DMY(chq_dt) as ChequeDate ,MICR_code,'" + strBranchName + "' as City,'Maharashtra' as State,Reason, Contact_de  as ContactDetails,'' as Remark from " + TableName + " invalid left outer join DrpBxMst.DBF dbMst on invalid.Col_pt_Cd=dbMst.Dropcode  where between(deposit_dt,{^" + Get_DateFormat(txtDepositFromDate.Text.Trim(), "yyyy/MM/dd") + "},{^" + Get_DateFormat(txtDepositToDate.Text.Trim(), "yyyy/MM/dd") + "}) And invalid.Col_pt_Cd not in ('MUM130','MUM129') And  Reason not in('PDC CHEQUE','SUSPENSE CHEQUE')  ";
                oCmd.CommandText += @" Union Select '' As Sr_no,DMY(pickup_dt) as PickupDate, dbMst.Dropname, 'NonSBI  ' as Source,""'""+Card_No as CardNO,""'""+Chq_no as ChequeNo,chq_amt,DMY(chq_dt) as ChequeDate,MICR_code,'" + strBranchName + "' as City,'Maharashtra' as State,Reason, Contact_de as ContactDetails,'' as Remark from " + TableName + " invalid left outer join DrpBxMst.DBF dbMst on invalid.Col_pt_Cd=dbMst.Dropcode  where between(deposit_dt,{^" + Get_DateFormat(txtDepositFromDate.Text.Trim(), "yyyy/MM/dd") + "},{^" + Get_DateFormat(txtDepositToDate.Text.Trim(), "yyyy/MM/dd") + "}) And invalid.Col_pt_Cd in ('MUM130','MUM129') And Reason not in('PDC CHEQUE','SUSPENSE CHEQUE') ";

 
                DataTable dt = new DataTable();
                dt.Load(oCmd.ExecuteReader());
                oConn.Close();
                  
                if (dt.Rows.Count > 0)
                {
                    lblMessage.Text = "Total Records Found " + dt.Rows.Count.ToString();
                    lblMessage.CssClass = "SuccessMessage";
                    lblMessage.Visible = true;
                    
                    Session["ExportData"] = dt;
                    gvUploadedDATA.DataSource = dt;
                    gvUploadedDATA.DataBind();
                }
                else
                {
                    lblMessage.Text = "No Records found";
                    lblMessage.CssClass = "ErrorMessage";
                    lblMessage.Visible = true;

                    Session["ExportData"] = dt;
                    gvUploadedDATA.DataSource = null;
                    gvUploadedDATA.DataBind();

                }
            }
        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
            lblMessage.CssClass="ErrorMessage";
            lblMessage.Visible = true;
        }



    }
    private string Get_DateFormat(string cDate,string cDateFormat)
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
    public override void VerifyRenderingInServerForm(Control control)
    {

    }
    public void Get_DropBoxMaster()
    {
        try
        {
            SqlConnection sqlCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);

            sqlCon.Open();
            SqlCommand sqlCom = new SqlCommand();
            sqlCom.Connection = sqlCon;
            sqlCom.CommandType = CommandType.StoredProcedure;
            sqlCom.CommandText = "Get_DropBoxList";
            SqlDataAdapter sqlDA = new SqlDataAdapter();
            sqlDA.SelectCommand = sqlCom;
            DataTable dt = new DataTable();
            sqlDA.Fill(dt);
            sqlCon.Close();

            Session["MASTER"] = dt;
            
        }
        catch (Exception ex)
        { 
            
        }    
    }

    private DataTable Merge_DropBoxWith_Data(DataTable InvalidDB, DataTable DropBoxMstDB)
    {
        DataSet ds = new DataSet();

            //DataRelation requires two DataColumn 
            //(parent and child) and a name.
           
            ds.Tables.Add(DropBoxMstDB);
            ds.Tables.Add(InvalidDB);

            DataColumn  parentColumn = DropBoxMstDB.Columns["DropBox_Code"];
            DataColumn childColumn = InvalidDB.Columns["col_pt_cd"];
            DataRelation relation = new DataRelation("parent2Child", parentColumn, childColumn);

            ds.Tables[1].ParentRelations.Add(relation);




            return ds.Tables[0];
    }

   
}
