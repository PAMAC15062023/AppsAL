using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.OleDb;
using System.IO;


public partial class InwardBTCheque : System.Web.UI.Page 
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserInfo"] == null)
        {
             Response.Redirect("~/pages/InvalidRequest.aspx", false);
            
        }

        if (!IsPostBack)
        {
            Register_Javascript_With_Control();
        }
    }
    protected void btnUpload_Click(object sender, EventArgs e)
    {
        try
        {
            Object SaveUSERInfo = (Object)Session["UserInfo"];
            String strBranchName = ((UserInfo.structUSERInfo)(SaveUSERInfo)).BranchName;
            string FileName = strBranchName + "_validchq.dbf";

            Upload_RecordTo_Grid(FileName.Trim());            
        }
        catch
        { 
            
        }
    }
    //private void UploadTo_Server()
    //{ 
    //    if (FileUpload1.FileName != "")
    //        {
    //           string[] FileFormat = FileUpload1.FileName.Split('.');

    //           if (FileUpload1.FileName.Contains(".dbf"))
    //           {
                   
    //               string Filename = FileUpload1.FileName.Trim();
    //               string fullSitePath =Convert.ToString(ConfigurationSettings.AppSettings["FileUploadPath"]); 
                    
    //               string fileName = Convert.ToString(DateTime.Now.ToString("yyyyMMddHHmmss")) + "." + FileFormat[FileFormat.Length - 1];
    //               string FileSavePath = fullSitePath + fileName;
    //               FileUpload1.SaveAs(FileSavePath);
    //               Session["DBFFile"] = FileSavePath;
    //               Upload_RecordTo_Grid(Session["DBFFile"].ToString());
    //           }
    //           else
    //           {
    //               lblMessage.Text = "Please select valid file!";
    //               lblMessage.CssClass = "ErrorMessage";
    //           }
    //        }

    //}
    private void Upload_RecordTo_Grid(string pFilePath)
    {         
        try
        {
            if (pFilePath!="")
            {
                Object SaveUSERInfo = (Object)Session["UserInfo"];
                String strBranchName = ((UserInfo.structUSERInfo)(SaveUSERInfo)).BranchName;
           
                string DBFMaster = Convert.ToString(ConfigurationSettings.AppSettings["MasterDBFFiles"]); //this.Request.PhysicalApplicationPath;

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

                oCmd.CommandText = @"Select '' As Sr_no,DMY(pickup_dt) as PickupDate, dbMst.Dropname, 'SBI    ' as Source,""'""+Card_No as CardNO,""'""+Chq_no as ChequeNo,chq_amt as ChequeAmount,DMY(chq_dt) as ChequeDate ,MICR_code,'" + strBranchName + "' as City,'Maharashtra' as State,  Contact_de as ContactDetails,'' as Remark from " + TableName + " invalid left outer join DrpBxMst.DBF dbMst on invalid.Col_pt_Cd=dbMst.Dropcode  where between(pickup_dt,{^" + Get_DateFormat(txtDepositDate.Text.Trim(), "yyyy/MM/dd") + "},{^" + Get_DateFormat(txtDepositDateTo.Text.Trim(), "yyyy/MM/dd") + "}) And Remark Like '%INW BT%' And  Col_pt_Cd not in ('MUM130','MUM129')  ";
                oCmd.CommandText += @"Union Select '' As Sr_no,DMY(pickup_dt) as PickupDate, dbMst.Dropname, 'NonSBI  ' as Source,""'""+Card_No as CardNO,""'""+Chq_no as ChequeNo,chq_amt as ChequeAmount,DMY(chq_dt) as ChequeDate,MICR_code,'" + strBranchName + "'  as City,'Maharashtra' as State,  Contact_de as ContactDetails,'' as Remark from " + TableName + " invalid left outer join DrpBxMst.DBF dbMst on invalid.Col_pt_Cd=dbMst.Dropcode  where between(pickup_dt,{^" + Get_DateFormat(txtDepositDate.Text.Trim(), "yyyy/MM/dd") + "},{^" + Get_DateFormat(txtDepositDateTo.Text.Trim(), "yyyy/MM/dd") + "}) And Remark Like '%INW BT%' And Col_pt_Cd in ('MUM130','MUM129')  ";


                DataTable dt = new DataTable();
                dt.Load(oCmd.ExecuteReader());
                oConn.Close();
 
                if (dt.Rows.Count > 0)
                {
                    lblMessage.Text = "Total Records Found " + dt.Rows.Count.ToString();
                    lblMessage.CssClass = "SuccessMessage";
                    Session["ExportData"] = dt;
                    gvUploadedDATA.DataSource = dt;
                    gvUploadedDATA.DataBind();
                }
                else
                {
                    lblMessage.Text = "No Records found";
                    lblMessage.CssClass = "ErrorMessage";
                    Session["ExportData"] = dt;
                    gvUploadedDATA.DataSource = null;
                    gvUploadedDATA.DataBind();

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
    protected void btnExport_Click(object sender, EventArgs e)
    {
        try
        {
            Generate_ExcelFile();
        }
        catch (Exception ex)
        {
            lblMessage.CssClass = "ErrorMessage";
            lblMessage.Text = ex.Message;

        }

    }
    private void Generate_ExcelFile()
    {
        Object SaveUSERInfo = (Object)Session["UserInfo"];
        String strBranchName = ((UserInfo.structUSERInfo)(SaveUSERInfo)).BranchName;
            

        String attachment = "attachment; filename=InwardBTChequeMIS.xls";
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
        tblCell1.Text = "<b> <font size='3' color='black' >PAMAC FINSERVE PVT. LTD., " + strBranchName + "</font> </b> <br/>" +
                        "<b><font size='2' color='blue'>PAMAC  InwardBT Cheque MIS For Date :" + txtDepositDate.Text.Trim() + " To :" + txtDepositDateTo.Text.Trim() +  " </font></b> <br/>";
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
    private string Trim_TEXT(string strTEXT, int IsNumeric, int Lenth)
    {
        try
        {
            string strFinalTEXT = "";
            int i = 0;
            int Len = strTEXT.Length;
            int Start = 0;

            if (IsNumeric == 1)
            {
                for (i = 0; i <= Lenth; i++)
                {
                    strFinalTEXT = strFinalTEXT + " ";

                }
                strTEXT = strTEXT + strFinalTEXT;
                strFinalTEXT = strTEXT.Substring(Start, Lenth);
            }
            else
            {
                Start = 1;
                for (i = 0; i <= Lenth - 1; i++)
                {
                    strFinalTEXT = "0" + strFinalTEXT;

                }
                strTEXT = strFinalTEXT + strTEXT;
                strFinalTEXT = strTEXT.Substring(Len, Lenth);
            }
            return strFinalTEXT;
        }
        catch (Exception ex)
        {
            lblMessage.CssClass = "ErrorMessage";
            lblMessage.Text = ex.Message;
            return "";
        }
    }
    private void Register_Javascript_With_Control()
    {
        try
        {
            //btnUpload.Attributes.Add("onclick", "javascript:return Validate_Upload()");
            btnExport.Attributes.Add("onclick", "javascript:return Validate_Export()");
            
        }
        catch (Exception ex)
        {
            lblMessage.CssClass = "ErrorMessage";
            lblMessage.Text = ex.Message;
        }
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
    protected void btnClose_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/pages/Menu.aspx", false);
    }
    protected void gvUploadedDATA_DataBound(object sender, EventArgs e)
    {
        //int i=0;
        //for (i=0;i<=gvUploadedDATA.Rows.Count-1;i++)
        //{
        //    gvUploadedDATA.Rows[i].Attributes.Add("onmouseover","this.style.backgroundColor='yellow'");
        //    gvUploadedDATA.Rows[i].Attributes.Add("onmouseout", "this.style.backgroundColor='white'");
        //}

        
        
        //GridViewRowEventArgs 

        //DataGridItemEventArgs  e1;

        //send


        // if ((e1.Item.ItemType == ListItemType.AlternatingItem) || (e1.Item.ItemType == ListItemType.Item))
        //{
        //        e1.Item.Attributes.Add("onmouseover", "this.style.backgroundColor='Silver'");
        //        e1.Item.Attributes.Add("onmouseout", "this.style.backgroundColor='white'");

        //}

    }
    public override void VerifyRenderingInServerForm(Control control)
    {

    }
}
