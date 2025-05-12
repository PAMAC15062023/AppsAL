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

public partial class DropboxMIS : System.Web.UI.Page
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
        if (chkFileUploaded.Checked)
        {
            if (Session["DBFFile"] != null)
            {
                Upload_RecordTo_Grid(Session["DBFFile"].ToString());
            }
            else
            {
                lblMessage.Text = "No file found,Please select file again!";
                lblMessage.CssClass = "ErrorMessage";
                lblMessage.Visible = true;
            }
        }
        else
        {

            UploadTo_Server();
        }
    }
    protected void btnExport_Click(object sender, EventArgs e)
    {
        Generate_ExcelFile();
    }
    private void Generate_ExcelFile()
    {



        String attachment = "attachment; filename=DropBoxMIS.xls";
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
                        "<b><font size='2' color='blue'>DropBoxMIS Cheque MIS For Date : " + txtDepositFromDate.Text + " To :" + txtDepositToDate.Text + " </font></b> <br/>";
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
    private void UploadTo_Server()
    {
        if (FileUpload1.FileName != "")
        {
            string[] FileFormat = FileUpload1.FileName.Split('.');

            if (FileUpload1.FileName.Contains(".dbf"))
            {

                string strName = FileUpload1.FileName.Trim();

             

                string fullSitePath = Convert.ToString(ConfigurationSettings.AppSettings["FileUploadPath"]); //this.Request.PhysicalApplicationPath;
                 
                             
                string fileName = Convert.ToString(DateTime.Now.ToString("yyyyMMddHHmmss")) + "." + FileFormat[FileFormat.Length - 1];
                string FileSavePath = fullSitePath + fileName;
                 

                FileUpload1.SaveAs(FileSavePath);
                Session["DBFFile"] = FileSavePath;
                 
                Upload_RecordTo_Grid(Session["DBFFile"].ToString());
            }
            else
            {
                lblMessage.Text = "Please select valid file!";
                lblMessage.CssClass = "ErrorMessage";
            }
        }

    }
    private void Upload_RecordTo_Grid(string pFilePath)
    {
        try
        {
            if (pFilePath != "")
            {
                string DBFMaster = Convert.ToString(ConfigurationSettings.AppSettings["MasterDBFFiles"]); //this.Request.PhysicalApplicationPath;
               
                System.Data.Odbc.OdbcConnection oConn = new System.Data.Odbc.OdbcConnection();
                oConn.ConnectionString = @"Driver={Microsoft Visual FoxPro Driver};SourceType=DBF;SourceDB=" + Convert.ToString(ConfigurationSettings.AppSettings["FileUploadPath"]) + ";Exclusive=No; Collate=Machine;NULL=NO;DELETED=NO;BACKGROUNDFETCH=NO;";
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

                oCmd.CommandText = @"Select dropboxMast.DropName as DropboxName,add1 +','+add2 as Adddress,'Mumbai' as City,'' as CUTCARD,'' as UNCUTCR,'' as  BTRE,'' as QCORR,'' as CASH,'' as APPL,'' as NonSBIUpCntryChqs,dropboxMast.Dropcode,(No_of_vld+No_of_inv) as Total_Cheques,No_of_inv as Invalid_Cheque,Valid_chq,invldchq From \MasterDBFFiles\DrpBxMst.dbf dropboxMast Left Outer Join  " + TableName + " DropDetails On DropDetails.Col_pt_cd=dropboxMast.dropcode Where Loca_code='MUM'";
                oCmd.CommandText += @" And  between(pickup_dt,{^" + Get_DateFormat(txtDepositToDate.Text.Trim(), "yyyy/MM/dd") + "},{^" + Get_DateFormat(txtDepositToDate.Text.Trim(), "yyyy/MM/dd") + "})";
 
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
    protected int Get_TotalMonthCount(string dropCode)
    {
        int TotalCount = 0;
        string pFilePath=Session["DBFFile"].ToString();
        if ( pFilePath!= "")
        {
           
            string DBFMaster = Convert.ToString(ConfigurationSettings.AppSettings["MasterDBFFiles"]); //this.Request.PhysicalApplicationPath;

            System.Data.Odbc.OdbcConnection oConn = new System.Data.Odbc.OdbcConnection();
            oConn.ConnectionString = @"Driver={Microsoft Visual FoxPro Driver};SourceType=DBF;SourceDB=" + Convert.ToString(ConfigurationSettings.AppSettings["FileUploadPath"]) + ";Exclusive=No; Collate=Machine;NULL=NO;DELETED=NO;BACKGROUNDFETCH=NO;";
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
            
            oCmd.CommandText =@" Select (Sum(No_of_vld)+Sum(No_of_inv)) From " + TableName + " DropDetails  Left Outer Join \\MasterDBFFiles\\DrpBxMst.dbf dropboxMast On DropDetails.Col_pt_cd=dropboxMast.dropcode Where Loca_code='MUM'";
            oCmd.CommandText += @" And  between(pickup_dt,{^" + Get_DateFormat(txtDepositFromDate.Text.Trim(), "yyyy/MM/dd") + "},{^" + Get_DateFormat(txtDepositToDate.Text.Trim(), "yyyy/MM/dd") + "}) And DropDetails.Col_pt_cd='"+dropCode+"'";


            TotalCount = Convert.ToInt32(oCmd.ExecuteScalar());
            oConn.Close();
        }
        return TotalCount;
         
    }
   
}
