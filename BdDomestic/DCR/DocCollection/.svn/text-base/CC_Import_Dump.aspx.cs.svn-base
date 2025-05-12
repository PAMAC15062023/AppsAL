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


public partial class CPV_CC_CC_Import_Dump : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnUplaod_Click(object sender, EventArgs e)
    {
        if (xslFileUpload.HasFile)
        {
            CDataDump oDataDump = new CDataDump();
            oDataDump.GetBatchID();            
            String strPath = "";
            String MyFile = "";
            
            //to get the file extention
            String strFileName = xslFileUpload.FileName.ToString();

            FileInfo fi = new FileInfo(strFileName);
            String strExt = fi.Extension;

            if (strExt.ToLower() == ".xls")
            {
                lblMsgXls.Text = "";
                //Uploading file start.
                strPath = Server.MapPath("../../ImportFiles/");
                MyFile = oDataDump.BatchId.ToString().Trim() + ".xls";
                strPath = strPath + MyFile;
                xslFileUpload.PostedFile.SaveAs(strPath);
                //Uploading end.
                
                //oDataDump.CentreID = Session["CentreId"].ToString();
                oDataDump.AddedBy = Session["UserId"].ToString();
                oDataDump.AddOn = DateTime.Now.Date.ToShortDateString() + " " + DateTime.Now.Date.ToShortTimeString();

                oDataDump.ActivityId = Session["ActivityId"].ToString();//ddlActivity.SelectedValue;
                oDataDump.CentreID = Session["CentreId"].ToString();
                oDataDump.ClientId = Session["ClientId"].ToString();
                oDataDump.ProductId = Session["ProductId"].ToString();
                oDataDump.ClusterID = Session["ClusterId"].ToString();
                //oDataDump;
                oDataDump.Prefix = Session["Prefix"].ToString();

                bool isValidFile = oDataDump.ImportExcel(); //To call import
                gvLog.DataSource = oDataDump.ImportLog;
                gvLog.DataBind();
                if (isValidFile == true)
                    lblMsgXls.Text = "Import data dump done successfully!!! " + oDataDump.TotalCases + " Case imported.";
                
                //To delete excel after import
                String strFile = Server.MapPath("../../ImportFiles/") + MyFile;
                if (File.Exists(strFile))
                {
                    File.Delete(strFile);
                }
            }
            else
            {
                lblMsgXls.Text = "Please select proper excel";
            }
        }

    }
}
