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


public partial class ChequeEntryReport : System.Web.UI.Page 
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserInfo"] == null)
        {
            Response.Redirect("../InvalidRequest.aspx", false);
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
            UploadTo_Server();
            
        }
        catch
        { 
        
        }
    }
    private void UploadTo_Server()
    { 
        if (FileUpload1.FileName != "")
            {
               string[] FileFormat = FileUpload1.FileName.Split('.');

               if (FileUpload1.FileName.Contains(".mdb"))
               {
                   
                   string Filename = FileUpload1.FileName.Trim();
                   string fullSitePath =Convert.ToString(ConfigurationSettings.AppSettings["FileUploadPath"]); //this.Request.PhysicalApplicationPath;
                   fullSitePath =fullSitePath; 
                   string fileName = Convert.ToString(DateTime.Now.ToString("yyyyMMddHHmmss")) + "." + FileFormat[FileFormat.Length - 1];
                   string FileSavePath = fullSitePath + fileName;
                   FileUpload1.SaveAs(FileSavePath);
                   Session["MDBFile"] = FileSavePath;
                   Upload_RecordTo_Grid(Session["MDBFile"].ToString());
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
            if (pFilePath!="")
            {
                string strCon="Provider=Microsoft.Jet.OLEDB.4.0;data source="+pFilePath ;
                OleDbConnection oleCon = new OleDbConnection(strCon);      
                oleCon.Open();

                OleDbCommand oleCom = new OleDbCommand("SELECT * FROM trxndetail INNER JOIN trxnheader ON trxndetail.serialno = trxnheader.serialno Where (BankName <> 'STATE BANK OF INDIA (SBI)'  ) Or (BankName = 'STATE BANK OF INDIA (SBI)'  And  InstType ='D' ) ");
                oleCom.Connection=oleCon;

                OleDbDataAdapter oleDA=new OleDbDataAdapter();
                oleDA.SelectCommand=oleCom;

                DataTable dt = new DataTable(); 
                oleDA.Fill(dt);

                oleCon.Close();
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
        catch
        { 
        
        }


    
    }
    protected void btnExport_Click(object sender, EventArgs e)
    {
        try
        {
            DataTable dt = (DataTable)Session["ExportData"];
            
            
            lblMessage.Text = "File Generated Successfully!";
            string FileName = Convert.ToString(GenerateExportFile(dt));
     
            Response.AppendHeader("Content-Disposition", "attachment; filename=" + FileName.Trim());
            Response.ContentType = "text/plain";
            Response.Flush();
            Response.WriteFile(FileName.Trim(), true);

            HttpContext.Current.Response.End();

        }
        catch (Exception ex)
        {
            lblMessage.CssClass = "ErrorMessage";
            lblMessage.Text = ex.Message;

        }

    }
    private string GenerateExportFile(DataTable dt)
    {
        try
        {
            string ActualFileWithPath = "";
            string strWrite = "";

            int i = 0;
            for (i = 0; i <= dt.Rows.Count - 1; i++)
            {
                strWrite = strWrite + Trim_TEXT("0", 0, 6);
                strWrite = strWrite + Trim_TEXT(Convert.ToString(dt.Rows[i]["accountno"]), 0, 11);
                strWrite = strWrite + Trim_TEXT("0", 0, 3);
                //Changes Done 

                string strAmount = Convert.ToString(dt.Rows[i]["trxnamount"]);
                if (strAmount.Contains("."))
                {
                    string[] arrAmount = strAmount.Split('.');
                    if (arrAmount.Length == 2)
                    {
                        if (arrAmount[arrAmount.Length - 1].Length == 1)
                        {
                            arrAmount[arrAmount.Length - 1] = arrAmount[arrAmount.Length - 1] + 0;
                        }

                        strAmount = arrAmount[0] + arrAmount[1];
                    }

                }
                else
                {
                    strAmount = strAmount + "00";
                }

                strWrite = strWrite + Trim_TEXT(strAmount, 0, 13);
           
                //Avinash 

                strWrite = strWrite + Trim_TEXT("0", 0, 1);
                strWrite = strWrite + Trim_TEXT("0", 0, 1);
                strWrite = strWrite + Trim_TEXT(Convert.ToString(dt.Rows[i]["remarks"]), 0, 2);
                strWrite = strWrite + Trim_TEXT("0", 0, 4);
                strWrite = strWrite + Trim_TEXT(Convert.ToString(dt.Rows[i]["instno"]), 0, 6);
                strWrite = strWrite + Trim_TEXT(Convert.ToString(dt.Rows[i]["micrcode"]), 0, 9);
              
                //Line Commented 
                //strWrite = strWrite + Trim_TEXT("400", 0, 3);
                //strWrite = strWrite + Trim_TEXT("002", 0, 3);
                //strWrite = strWrite + Trim_TEXT("020", 0, 3);
                //Line Commented  END Here

                string strInstDate = Convert.ToString(txtDepositDate.Text.Trim()); //Convert.ToString(dt.Rows[i]["instdate"]);
                strInstDate = strInstDate.Replace("/", "");
                //strInstDate = strInstDate.Substring(0, 8);

                strWrite = strWrite + Trim_TEXT(strInstDate, 0, 8);

                strWrite = strWrite + Trim_TEXT("0", 0, 41);

                //string  strCityCode =Convert.ToString(dt.Rows[i]["micrcode"]);
                //strCityCode = strCityCode.Substring(0, 3);

                //strWrite = strWrite + Trim_TEXT(strCityCode.Trim(), 0, 3);
                //strWrite = strWrite + Trim_TEXT("2020", 0, 6);
                strWrite = strWrite + Trim_TEXT(Convert.ToString(dt.Rows[i]["micrcode"]), 0, 9);
              


                strWrite = strWrite + Trim_TEXT("0", 0, 28);
                strWrite = strWrite + Trim_TEXT("ByClearing", 0, 10);
                strWrite = strWrite + Trim_TEXT(Convert.ToString(dt.Rows[i]["instno"]), 0, 6);


                string strBANKNBRANCHCode = Convert.ToString(dt.Rows[i]["micrcode"]);
                strBANKNBRANCHCode = strBANKNBRANCHCode.Substring(3, 6);

                strWrite = strWrite + Trim_TEXT(strBANKNBRANCHCode.Trim(), 0, 6);
                strWrite = strWrite + Trim_TEXT("N", 0, 1);
                strWrite = strWrite + "\r\n";
            }
            string FileName = "";
            string FileSAVEPath = "";
            FileName = Convert.ToString(DateTime.Now.ToString("yyyyMMddHHmmss"));
            FileSAVEPath =Convert.ToString(ConfigurationSettings.AppSettings["FileDownloadPath"]); //Convert.ToString(System.Configuration.ConfigurationManager.AppSettings["GESBI_ExportFilePath"]);
            ActualFileWithPath = FileSAVEPath + FileName + ".txt";

            TextWriter tw = new StreamWriter(ActualFileWithPath);
            tw.WriteLine(strWrite);
            tw.Close();

            return ActualFileWithPath;
        }
        catch (Exception ex)
        {
            lblMessage.CssClass = "ErrorMessage";
            lblMessage.Text = ex.Message;
            return "";


        }          
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
            btnUpload.Attributes.Add("onclick", "javascript:return Validate_Upload()");
            btnExport.Attributes.Add("onclick", "javascript:return Validate_Export()");
            
        }
        catch (Exception ex)
        {
            lblMessage.CssClass = "ErrorMessage";
            lblMessage.Text = ex.Message;
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
}
