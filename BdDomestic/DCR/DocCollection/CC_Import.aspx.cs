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

public partial class CC_Import1 : System.Web.UI.Page
{
    CCommon con = new CCommon();
    //CImport oImport;
    CImport oImport = new CImport();
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {

            if (Session["isAdd"].ToString() == "0")
                Response.Redirect("NoAccess.aspx");

            if (!IsPostBack)
            {
                txtALC_Date.Text = DateTime.Now.ToString("dd/MM/yyyy");
                ddlTemplate.Focus();

                sdsTemplate.SelectCommand = oImport.TemplateSelect(Session["ActivityId"].ToString(), Session["ProductId"].ToString(), Session["ClientId"].ToString());
                ddlTemplate.DataSourceID = sdsTemplate.ID;
                ddlTemplate.DataTextField = "Template_Name";
                ddlTemplate.DataValueField = "Template_Id";
                ddlTemplate.DataBind();
            }
            string strcentreID = Session["CentreId"].ToString();
            string strclusterID = Session["ClusterId"].ToString();
            string strclientID = Session["ClientId"].ToString();
            string strimportedRecord = oImport.GetNumberOfRecord("CPV_CC_CASE_DETAILS", "CASE_REC_DATETIME", strcentreID, strclusterID, strclientID).ToString();
            if (strimportedRecord != "0")
            {
                lblRecordCount.ForeColor = System.Drawing.Color.Yellow;
                lblRecordCount.BackColor = System.Drawing.Color.Black;
                lblRecordCount.Font.Bold = true;
                lblRecordCount.Visible = true;
                lblRecordCount.Text = "&nbsp;" + strimportedRecord + "  " + " records are imported today ";
            }
        }
        catch (Exception ex)
        {
            lblMsgXls.Visible = true;
            lblMsgXls.Text = "Error while loading/retreiving data: " + ex.Message;
        }
        
    }
    protected void btnUplaod_Click(object sender, EventArgs e)
    {
        try
        {
            if (xslFileUpload.HasFile)
            {
                CImport oImport = new CImport();
                oImport.GetBatchID();
                String strSql = "";
                String strPath = "";
                String MyFile = "";
                string strCentreId = Session["CentreId"].ToString();
                string strClientId = Session["ClientId"].ToString();

                //to get the file extention
                String strFileName = xslFileUpload.FileName.ToString();

                FileInfo fi = new FileInfo(strFileName);
                String strExt = fi.Extension;

                if (strExt.ToLower() == ".xls")
                {
                    //Uploading file start.
                    strPath = Server.MapPath("../../ImportFiles/");
                    MyFile = oImport.BatchId.ToString().Trim() + ".xls";
                    strPath = strPath + MyFile;
                    xslFileUpload.PostedFile.SaveAs(strPath);
                    //Uploading end.

                    //oImport.CentreID = Session["CentreId"].ToString();
                    oImport.AddedBy = Session["UserId"].ToString();
                    oImport.AddOn = DateTime.Now.Date.ToShortDateString() + " " + DateTime.Now.Date.ToShortTimeString();

                    oImport.CaseType = ddlCaseType.Text;

                    oImport.ALCDate = con.strDate(txtALC_Date.Text.ToString().Trim());
                    oImport.ALCTime = txtACT_Time.Text.ToString().Trim();
                    oImport.ALCTimeType = ddlTimeType.SelectedValue.ToString().Trim();
                    oImport.ActivityId = Session["ActivityId"].ToString();//ddlActivity.SelectedValue;
                    oImport.CentreID = strCentreId;
                    oImport.ClientId = strClientId;
                    oImport.ClusterID = Session["ClusterId"].ToString();
                    oImport.Prefix = Session["Prefix"].ToString();

                    //if (txtActualDt.Text != "")
                    //    oImport.ActualDate = txtActualDt.Text + " " + txtActualTime.Text + " " + ddlTimeTypeAct.Text;

                    oImport.TemplateId = ddlTemplate.SelectedValue;
                    oImport.Redo = chkRedo.Checked;
                    bool isValidFile = oImport.ImportExcel(); //To call import
                    gvLog.DataSource = oImport.ImportLog;
                    gvLog.DataBind();
                    if (oImport.ImportLog.Rows.Count == 0)
                    {
                        string strCount = oImport.NumberOfCases(Session["ActivityId"].ToString(), Session["ProductId"].ToString());
                        lblMsgXls.Text = "Import done successfully!!! " + strCount + " cases imported.";
                        //oImport.AutoAssignment(Session["ActivityId"].ToString(), Session["ProductId"].ToString());
                    }
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
        catch (Exception ex)
        {
            lblMsgXls.Visible = true;
            lblMsgXls.Text = "Error while importing cases: " + ex.Message;
        }
    }


    protected void ddlTemplate_DataBound(object sender, EventArgs e)
    {
        DropDownList ddl = (DropDownList)sender;
        ddl.Items.Insert(0, new ListItem("--Select Template--", "0"));
    }
}
