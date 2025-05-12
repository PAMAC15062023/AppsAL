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
using CrystalDecisions.Shared;
using CrystalDecisions.CrystalReports.Engine;

public partial class CPV_CC_CC_Cover_Letter : System.Web.UI.Page
{
    CCommon oCom = new CCommon();
    CCompanyMaster oComp = new CCompanyMaster();
    public string CompanyName;

    protected void Page_Load(object sender, EventArgs e)
    {
        txtDateFrom.Focus();
        //if (Session["isView"].ToString() != "1")
        //    Response.Redirect("NoAccess.aspx");
        lblMessage.Text = "";
        if (IsPostBack)
        {
            
        }
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {      
        int iCount=0;
        try
        {
            CReport objReport = new CReport();
            DataSet dsCoverLetter = new DataSet();
            //DataSet dsPendingListHead = new DataSet();
            string FDate = "";
            string Tdate = "";
            if (rdoDateTime.Checked == true)
            {
                FDate = oCom.strDate(txtDate.Text.Trim()) + ' ' + txtTime.Text.Trim() + ' ' + ddlTimeType.SelectedItem.Text.Trim();
                Tdate = Convert.ToDateTime(oCom.strDate(txtDate.Text.Trim()) + ' ' + txtTime.Text.Trim() + ' ' + ddlTimeType.SelectedItem.Text.Trim()).AddMinutes(1.0).ToString("dd-MMM-yyyy hh:mm tt");
            }
            else if (rdoFromToDate.Checked == true)
            {
                FDate = oCom.strDate(txtDateFrom.Text.Trim());
                Tdate = Convert.ToDateTime(oCom.strDate(txtDateTo.Text.Trim())).AddDays(1.0).ToString("dd-MMM-yyyy");
            }
            dsCoverLetter = objReport.getRecords(FDate, Tdate, Session["ClientId"].ToString(), Session["CentreId"].ToString());
            //dsPendingListHead = objReport.GetPendingReportListHead(sFromDate, sToDate, "Pamac Online");

            if (dsCoverLetter.Tables[0].Rows.Count > 0)
            {
                //--this statement is very important, here the table name should 
                //--match with the XML Schema table name 
                dsCoverLetter.Tables[0].TableName = "COVERLETTER";


                //--For Heading of Report------------------

                //dsPendingListHead.Tables[0].TableName = "PENDINGLISTHEADING";
                //DataRow drPendingListHead = dsPendingListHead.Tables[0].NewRow();
                //drPendingListHead["COMPANYNAME"] = "PAMAC Online";
                //drPendingListHead["FROMDATE"] = txtFromDate.Text.Trim();
                //drPendingListHead["TODATE"] = txtToDate.Text.Trim();
                //dsPendingListHead.Tables[0].Rows.Add(drPendingListHead);
                ///-----------------------------------------------------
                Session["dataset"] = dsCoverLetter;

                //Session["datasetHead"] = dsPendingListHead;
                Session["Path"] = Server.MapPath("CoverLetter.rpt");
                Session.Remove("ParameterCollection");
                iCount = 1;
            }
            else
            {
                lblMessage.Visible = true;                
                lblMessage.Text = "No Record found.";
            }            
        }
        catch (Exception ex)
        {
            lblMessage.Visible = true;
            lblMessage.Text = "Error while generating report: " + ex.Message;
        }
        if(iCount==1)
            Response.Redirect("../../CrystalReportviewer.aspx?bckPgURL=CPV\\CC\\CC_Cover_Letter.aspx");
    }
}