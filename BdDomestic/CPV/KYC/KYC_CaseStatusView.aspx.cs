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

public partial class CPV_KYC_KYC_CaseStatusView : System.Web.UI.Page
{
    CCaseStatusView objCaseStatus = new CCaseStatusView();

    protected void Page_Load(object sender, EventArgs e)
    {

    }
    private void GetSearchCases()
    {

        DataTable dt = new DataTable();
        dt = objCaseStatus.KYCGetSearch();
        if (dt.Rows.Count > 0)
        {
            gvCaseStatusView.DataSource = dt;
            gvCaseStatusView.DataBind();
            gvCaseStatusView.Visible = true;
        }
        else
        {
            gvCaseStatusView.Visible = false;
            lblMessage.Text = "Records not found!";
        }
    }
    private void PropertySet()
    {
        objCaseStatus.CaseID = txtCaseID.Text.Trim().ToString();
        objCaseStatus.RefNO = txtRefNo.Text.Trim().ToString();
        objCaseStatus.ApplicantName = txtApplicantName.Text.Trim().ToString();
        objCaseStatus.CentreID = Session["CentreId"].ToString();
        objCaseStatus.ClientID = Session["ClientId"].ToString();

    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        lblMessage.Text = "";
        PropertySet();
        GetSearchCases();

    }
    protected void gvCaseStatusView_RowCommand(object sender, GridViewCommandEventArgs e)
    {
    }
    private struct GridPosition
    {
        public const int CASEID = 0;
        public const int REFNO = 1;
        public const int APPLICANTNAME = 2;
        public const int VERIFICATIONTYPE = 3;
        public const int SELECTVERIFICATIONTYPE = 4;


    }
    protected void gvCaseStatusView_RowCreated(object sender, GridViewRowEventArgs e)
    {

    }
    protected void gvCaseStatusView_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        foreach (GridViewRow row in gvCaseStatusView.Rows)
        {
            string veriCode = row.Cells[GridPosition.VERIFICATIONTYPE].Text;
            string strCaseID = row.Cells[GridPosition.CASEID].Text;

            for (Int32 rowTypeCount = 0; rowTypeCount < gvCaseStatusView.Rows.Count; rowTypeCount++)
            {
                GridViewRow gvRow = gvCaseStatusView.Rows[rowTypeCount];

                string[] arrVerificationTypeCode = veriCode.Split('+');
                for (int i = 0; i < arrVerificationTypeCode.Length; i++)
                {
                    if (arrVerificationTypeCode[i].Length > 0)
                    {

                        MatchVerificationType(arrVerificationTypeCode[i].ToString(), row, veriCode, strCaseID);

                    }

                }
            }

        }

    }

    private void MatchVerificationType(string code, GridViewRow gvRow, string verificationTypeCode, string caseID)
    {

        Label lblRV = (Label)gvRow.Cells[GridPosition.SELECTVERIFICATIONTYPE].FindControl("lblRV");
        Label lblBV = (Label)gvRow.Cells[GridPosition.SELECTVERIFICATIONTYPE].FindControl("lblBV");
        Label lblCA = (Label)gvRow.Cells[GridPosition.SELECTVERIFICATIONTYPE].FindControl("lblCA");
       

        Label lblSlashRV = (Label)gvRow.Cells[GridPosition.SELECTVERIFICATIONTYPE].FindControl("lblSlashRV");
        Label lblSlashBV = (Label)gvRow.Cells[GridPosition.SELECTVERIFICATIONTYPE].FindControl("lblSlashBV");
        
        string verificationType = code;

        switch (code)
        {
            case "RV":
                string str = "KYC_RV_VERI.aspx?CaseID=" + caseID + "&VerTypeId=1&VerificationTypeCode=" + verificationTypeCode + "&Mode=View";
                lblRV.Text = "<A href='#' onClick=winOpen('" + str + "')>RV</A>";
                lblRV.Visible = true;
                lblSlashRV.Visible = true;
                break;
            case "BV":
                string str1 = "KYC_BUSINESS_VERI.aspx?CaseID=" + caseID + "&VerTypeId=2&VerificationTypeCode=" + verificationTypeCode + "&Mode=View";
                lblBV.Text = "<A href='#' onClick=winOpen('" + str1 + "')>BV</A>";
                lblBV.Visible = true;
                lblSlashBV.Visible = true;
                break;

            case "CA":
                string str2 = "KYC_CA_VERI.aspx?CaseID=" + caseID + "&VerTypeId=19&VerificationTypeCode=" + verificationTypeCode + "&Mode=View";
                lblCA.Text = "<A href='#' onClick=winOpen('" + str2 + "')>CA</A>";
                lblCA.Visible = true;
                
                break;

        }

    }
    protected void gvCaseStatusView_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvCaseStatusView.PageIndex = e.NewPageIndex;
        PropertySet();
        GetSearchCases();
    }
}
