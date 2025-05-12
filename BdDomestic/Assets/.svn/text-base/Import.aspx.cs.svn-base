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
public partial class Assets_Import : System.Web.UI.Page
{
    CCommon objcon = new CCommon();
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnupload_Click(object sender, EventArgs e)
    {

        if (Xlsfile.HasFile)
        {
           AImport AI = new AImport();
            AI.GetBatchID();
            String strPath = "";
            String MyFile = "";
            String filename = Xlsfile.FileName.ToString();
            FileInfo fil = new FileInfo(filename);
            String strext = fil.Extension;
            if (strext.ToLower() == ".xls")
            {
                LblXls.Text = "";
                strPath = Server.MapPath("../ImportFiles/");
                MyFile = AI.BatchId.ToString().Trim() + ".xls ";
                strPath = strPath + MyFile;
                Xlsfile.PostedFile.SaveAs(strPath);
                AI.AddedBy = Session["UserId"].ToString();
                AI.AddOn = DateTime.Now.Date.ToShortDateString() + " " + DateTime.Now.Date.ToShortTimeString();
                //AI.ActivityId = Session["ActivityId"].ToString();//ddlActivity.SelectedValue;
                //hr.CentreID = 
                AI.CentreID = Session["CentreId"].ToString();
                AI.ClientId = "101112";
                AI.ProductId = "10112";
                AI.ClusterID = Session["ClusterId"].ToString();
                AI.Prefix = Session["Prefix"].ToString();
                             bool isValidFile = AI.ImportExcel();
                            grdviw.DataSource = AI.ImportLog;
                            grdviw.DataBind();

                            if (isValidFile == true)
                            {
                                
                                LblXls.Text = "HR Payout Dump Imported Successfully!!! " +AI.TotalCases + " Rows imported.";
                            }
                        
                    
                String strFile = Server.MapPath("../ImportFiles/") + MyFile;
                if (File.Exists(strFile))
                {
                    File.Delete(strFile);
                }
            }
            else
            {

                LblXls.Text = "Please select proper excel";
            }
        }
    }
}
