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

public partial class CPV_RL_RL_QC_CaseStatusView : System.Web.UI.Page
{
    CCaseStatusView objCaseStatus = new CCaseStatusView();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

        }
    }

    private void GetSearchCases()
    {

        DataTable dt = new DataTable();
        dt = objCaseStatus.RLGetSearch_Qc();
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

    private struct GridPosition
    {
        public const int CASEID = 0;
        public const int REFNO = 1;
        public const int APPLICANTNAME = 2;
        public const int VERIFICATIONTYPE = 3;
        public const int SELECTVERIFICATIONTYPE = 4;


    }

    protected void gvCaseStatusView_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvCaseStatusView.PageIndex = e.NewPageIndex;
        PropertySet();
        GetSearchCases();
    }
    protected void gvCaseStatusView_RowCommand(object sender, GridViewCommandEventArgs e)
    {

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
        Label lblRT = (Label)gvRow.Cells[GridPosition.SELECTVERIFICATIONTYPE].FindControl("lblRT");
        Label lblBT = (Label)gvRow.Cells[GridPosition.SELECTVERIFICATIONTYPE].FindControl("lblBT");
        Label lblPRV = (Label)gvRow.Cells[GridPosition.SELECTVERIFICATIONTYPE].FindControl("lblPRV");
        Label lblREF1 = (Label)gvRow.Cells[GridPosition.SELECTVERIFICATIONTYPE].FindControl("lblREF1");
        Label lblREF2 = (Label)gvRow.Cells[GridPosition.SELECTVERIFICATIONTYPE].FindControl("lblREF2");
        Label lblRCO = (Label)gvRow.Cells[GridPosition.SELECTVERIFICATIONTYPE].FindControl("lblRCO");

        //////////////add new code for QC releted////////////////////////////////////
        Label lblQRV = (Label)gvRow.Cells[GridPosition.SELECTVERIFICATIONTYPE].FindControl("lblQRV");
        Label lblQBV = (Label)gvRow.Cells[GridPosition.SELECTVERIFICATIONTYPE].FindControl("lblQBV");
        Label lblQRT = (Label)gvRow.Cells[GridPosition.SELECTVERIFICATIONTYPE].FindControl("lblQRT");
        Label lblQBT = (Label)gvRow.Cells[GridPosition.SELECTVERIFICATIONTYPE].FindControl("lblQBT");
        Label lblQTRV = (Label)gvRow.Cells[GridPosition.SELECTVERIFICATIONTYPE].FindControl("lblQTRV");
        Label lblQTBV = (Label)gvRow.Cells[GridPosition.SELECTVERIFICATIONTYPE].FindControl("lblQTBV");
        ///////////////////end code///////////////////////////////////////

        Label lblSlashRV = (Label)gvRow.Cells[GridPosition.SELECTVERIFICATIONTYPE].FindControl("lblSlashRV");
        Label lblSlashBV = (Label)gvRow.Cells[GridPosition.SELECTVERIFICATIONTYPE].FindControl("lblSlashBV");
        Label lblSlashRT = (Label)gvRow.Cells[GridPosition.SELECTVERIFICATIONTYPE].FindControl("lblSlashRT");
        Label lblSlashBT = (Label)gvRow.Cells[GridPosition.SELECTVERIFICATIONTYPE].FindControl("lblSlashBT");
        Label lblSlashPRV = (Label)gvRow.Cells[GridPosition.SELECTVERIFICATIONTYPE].FindControl("lblSlashPRV");
        Label lblSlashREF1 = (Label)gvRow.Cells[GridPosition.SELECTVERIFICATIONTYPE].FindControl("lblSlashREF1");
        Label lblSlashREF2 = (Label)gvRow.Cells[GridPosition.SELECTVERIFICATIONTYPE].FindControl("lblSlashREF2");
        Label lblSlashRCO = (Label)gvRow.Cells[GridPosition.SELECTVERIFICATIONTYPE].FindControl("lblSlashRCO");

        /////////////////////add new code for Qc releted/////////////////////
        Label lblSlashQRV = (Label)gvRow.Cells[GridPosition.SELECTVERIFICATIONTYPE].FindControl("lblSlashQRV");
        Label lblSlashQBV = (Label)gvRow.Cells[GridPosition.SELECTVERIFICATIONTYPE].FindControl("lblSlashQBV");
        Label lblSlashQRT = (Label)gvRow.Cells[GridPosition.SELECTVERIFICATIONTYPE].FindControl("lblSlashQRT");
        Label lblSlashQBT = (Label)gvRow.Cells[GridPosition.SELECTVERIFICATIONTYPE].FindControl("lblSlashQBT");
        Label lblSlashQTRV = (Label)gvRow.Cells[GridPosition.SELECTVERIFICATIONTYPE].FindControl("lblSlashQTRV");
        Label lblSlashQTBV = (Label)gvRow.Cells[GridPosition.SELECTVERIFICATIONTYPE].FindControl("lblSlashQTBV");
        /////////////////////end code for Qc releted/////////////////////

     
        string verificationType = code;

        switch (code)
        {
            case "RV":
                string str = "RL_ResidenceVerification.aspx?CaseID=" + caseID + "&VerTypeId=1&VerificationTypeCode=" + verificationTypeCode + "&Mode=View";
                lblRV.Text = "<A href='#' onClick=winOpen('" + str + "')>RV</A>";
                lblRV.Visible = true;
                lblSlashRV.Visible = true;
                break;
            case "BV":
                string str1 = "RL_BusinessVerification.aspx?CaseID=" + caseID + "&VerTypeId=2&VerificationTypeCode=" + verificationTypeCode + "&Mode=View";
                lblBV.Text = "<A href='#' onClick=winOpen('" + str1 + "')>BV</A>";
                lblBV.Visible = true;
                lblSlashBV.Visible = true;
                break;

            case "RT":
                string str2 = "RL_ResidenceTelephonicVerification.aspx?CaseID=" + caseID + "&VerTypeId=4&VerificationTypeCode=" + verificationTypeCode + "&Mode=View";
                lblRT.Text = "<A href='#' onClick=winOpen('" + str2 + "')>RT</A>";
                lblRT.Visible = true;
                lblSlashRT.Visible = true;
                break;
            case "BT":
                string str3 = "RL_BusinessTelephonicVerification.aspx?CaseID=" + caseID + "&VerTypeId=3&VerificationTypeCode=" + verificationTypeCode + "&Mode=View";
                lblBT.Text = "<A href='#' onClick=winOpen('" + str3 + "')>BT</>";
                lblBT.Visible = true;
                lblSlashBT.Visible = true;
                break;

            case "PRV":
                string str4 = "RL_ResidenceVerification.aspx?CaseID=" + caseID + "&VerTypeId=10&VerificationTypeCode=" + verificationTypeCode + "&Mode=View";
                lblPRV.Text = "<A href='#' onClick=winOpen('" + str4 + "')>PRV</A>";
                lblPRV.Visible = true;
                lblSlashPRV.Visible = true;
                break;

            case "REF1":
                string str5 = "RL_REF1Verification.aspx?CaseID=" + caseID + "&VerTypeId=12&VerificationTypeCode=" + verificationTypeCode + "&Mode=View";
                lblREF1.Text = "<A href='#' onClick=winOpen('" + str5 + "')>REF1</A>";
                lblREF1.Visible = true;
                lblSlashREF1.Visible = true;
                break;

            case "REF2":
                string str6 = "RL_REF2Verification.aspx?CaseID=" + caseID + "&VerTypeId=13&VerificationTypeCode=" + verificationTypeCode + "&Mode=View";
                lblREF2.Text = "<A href='#' onClick=winOpen('" + str6 + "')>REF2</A>";
                lblREF2.Visible = true;
                lblSlashREF2.Visible = true;
                break;

            case "RCO":
                string str7 = "RL_ResiCumBusiness.aspx?CaseID=" + caseID + "&VerTypeId=14&VerificationTypeCode=" + verificationTypeCode + "&Mode=View";
                lblRCO.Text = "<A href='#' onClick=winOpen('" + str7 + "')>RCO</A>";
                lblRCO.Visible = true;
                lblSlashRCO.Visible = true;
                break;

                ////////////////////////////add new code for QC releted//////////////////////////////////////
            case "QRV":
                string str8 = "RL_QCResidenceVerification.aspx?CaseID=" + caseID + "&VerTypeId=25&VerificationTypeCode=" + verificationTypeCode + "&Mode=View";
                lblQRV.Text = "<A href='#' onClick=winOpen('" + str8 + "')>QRV</A>";
                lblQRV.Visible = true;
                lblSlashQRV.Visible = true;
                break;
            case "QBV":
                string str9 = "RL_QCBusinessVerification.aspx?CaseID=" + caseID + "&VerTypeId=26&VerificationTypeCode=" + verificationTypeCode + "&Mode=View";
                lblQBV.Text = "<A href='#' onClick=winOpen('" + str9 + "')>QBV</A>";
                lblQBV.Visible = true;
                lblSlashQBV.Visible = true;
                break;

            case "QRT":
                string str10 = "RL_QCResidenceTelephonicVerification.aspx?CaseID=" + caseID + "&VerTypeId=27&VerificationTypeCode=" + verificationTypeCode + "&Mode=View";
                lblQRT.Text = "<A href='#' onClick=winOpen('" + str10 + "')>QRT</A>";
                lblQRT.Visible = true;
                lblSlashRT.Visible = true;
                break;

            case "QBT":
                string str11 = "RL_QCBusinessTelephonicVerification.aspx?CaseID=" + caseID + "&VerTypeId=28&VerificationTypeCode=" + verificationTypeCode + "&Mode=View";
                lblQBT.Text = "<A href='#' onClick=winOpen('" + str11 + "')>QBT</>";
                lblQBT.Visible = true;
                lblSlashQBT.Visible = true;
                break;

            case "QTRV":
                string str12 = "RL_QCTeleResidenceVerification.aspx?CaseID=" + caseID + "&VerTypeId=29&VerificationTypeCode=" + verificationTypeCode + "&Mode=View";
                lblQTRV.Text = "<A href='#' onClick=winOpen('" + str12 + "')>QTRV</A>";
                lblQTRV.Visible = true;
                lblSlashQTRV.Visible = true;
                break;

            case "QTBV":
                string str13 = "RL_QCTeleResidenceVerification.aspx?CaseID=" + caseID + "&VerTypeId=30&VerificationTypeCode=" + verificationTypeCode + "&Mode=View";
                lblQTBV.Text = "<A href='#' onClick=winOpen('" + str13 + "')>QTBV</>";
                lblQTBV.Visible = true;
                lblSlashQTBV.Visible = true;
                break;
                /////////////////////////////////end code///////////////////////////////////////////
        }

    }

}
