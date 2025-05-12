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

public partial class CPV_CC_CC_TC_ReAssign : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        if (Session["isAdd"].ToString() != "1")
            Response.Redirect("NoAccess.aspx");

        lblMsg.Text = "";
        if (!IsPostBack)
        {
            try
            {
                ddlType.DataBind();
                //FillView();
            }
            catch (Exception exp)
            {
                lblMsg.Text = "Error occured operation faild. Error:" + exp.Message;
            }
        }
    }
    public void FillView()
    {
        try
        {
            String strCentreID = "";
            String strClientID = "";
            String strSql = "";
            String strsql1 = "";
            String strsql2 = "";
            strCentreID = Session["CentreId"].ToString();
            strClientID = Session["ClientId"].ToString();

            CCommon objCommon = new CCommon();

            if (strClientID != "" && strCentreID != "")
            {
                String strCreteria = "";
                if (txtDate.Text != "" && txtToDate.Text != "")
                {
                    //strCreteria += " AND (CONVERT(VARCHAR, CD.CASE_REC_DATETIME,103)='" + Convert.ToDateTime(objCommon.strDate(txtDate.Text.Trim())).ToString("dd/MM/yyyy") + "')";
                    strCreteria += " AND (CONVERT(VARCHAR, a.CASE_REC_DATETIME,103)>='" + txtDate.Text + "'AND (CONVERT(VARCHAR, a.CASE_REC_DATETIME,103)<='" + txtToDate.Text + "')";
                }
                //if (txtCustName.Text != "")
                //{
                //    if (chkAbsolute.Checked)
                //        strCreteria += " AND (ISNULL(CD.FIRST_NAME + ' ', '') +ISNULL(CD.MIDDLE_NAME + ' ', '') + ISNULL(CD.LAST_NAME + ' ', '')='" + txtCustName.Text.Trim().ToString().Replace("'", "") + "')";
                //    else
                //        strCreteria += " AND (ISNULL(CD.FIRST_NAME + ' ', '') +ISNULL(CD.MIDDLE_NAME + ' ', '') + ISNULL(CD.LAST_NAME + ' ', '') Like'%" + txtCustName.Text.Trim().ToString().Replace("'", "") + "%')";
                //}
                if (ddlType.SelectedValue != "")
                {
                    strCreteria += " AND (b.VERIFICATION_TYPE_ID = '" + ddlType.SelectedValue.ToString() + "'))";
                }
                //if (ddlTc.SelectedValue != "")
                //{
                //    strCreteria += " AND FE.Tc_ID='" + ddlTc.SelectedValue.ToString() + "'";
                //}
                //else
                //{
                //    strCreteria += " AND FE.Tc_ID IS NULL";
                //}
                String strSelADD = "";
                if (ddlType.SelectedItem.ToString() == "RT")
                {
                    strSelADD = "(ISNULL(a.RES_ADD_LINE_1+' ','') + ISNULL(a.RES_ADD_LINE_2+' ','') + ISNULL(a.RES_ADD_LINE_3+' ','')) AS [Resident Address], a.RES_CITY AS [City], a.RES_STATE AS [State], a.RES_PIN_CODE AS [Pincode], ";
                }
                if (ddlType.SelectedItem.ToString() == "BT")
                {
                    strSelADD = "(ISNULL(a.OFF_ADD_LINE_1+' ','') + ISNULL(a.OFF_ADD_LINE_2+' ','') + ISNULL(a.OFF_ADD_LINE_3+' ','')) AS [Office Address], a.OFF_CITY AS [City], a.OFF_STATE AS [State], a.OFF_PIN_CODE AS [Pincode], ";
                }
                hdnVerificatioTypeID.Value = ddlType.SelectedValue.ToString();
                strSql = "SELECT a.CASE_ID AS [Case ID], a.REF_NO AS [Refrence No], ISNULL(a.TITLE + ' ', '') + ISNULL(a.FIRST_NAME + ' ', '') +ISNULL(a.MIDDLE_NAME + ' ', '') + ISNULL(a.LAST_NAME + ' ', '') AS [Applicant Name], " + strSelADD +
                                "CONVERT(VARCHAR, a.CASE_REC_DATETIME, 103) AS [Recieved Date] "+ 
                                "FROM CPV_CC_CASE_DETAILS a,cpv_cc_veri_details ce,cpv_cc_case_verificationtype c " +
                                "WHERE(a.SEND_DATETIME IS NULL) AND a.CLIENT_ID='" + strClientID + "' And a.CENTRE_ID='" + strCentreID + "'  AND a.case_id=ce.case_id and a.case_id=c.case_id "+
                                " and ce.verification_type_id=c.verification_type_id and ce.case_status_id='38' and ce.verification_type_id in('20','21','22','23','24') and CONVERT(VARCHAR, a.CASE_REC_DATETIME,103)>='" + txtDate.Text + "'AND CONVERT(VARCHAR, a.CASE_REC_DATETIME,103)<'" + txtToDate.Text + "' ";

                strsql1 = "select a.case_id,a.ref_no,isnull(a.title,'')+' '+ isnull(a.first_name,'')+' '+isnull(a.middle_name,'')+' '+isnull(a.last_name,'')as applicant_name," + strSelADD + "CONVERT(VARCHAR, a.CASE_REC_DATETIME, 103) AS [Recieved Date] " +
                            " from cpv_cC_case_details a,cpv_cc_tc_case_mapping b where a.case_id=b.case_id and b.status in('A','M') "+
                            " and b.case_id not in(select case_id from cpv_cc_veri_details where (case_status_id is null or case_status_id = '')"+
                            "  and verification_type_id in ('20','21','22','23','24')) and exists(select case_id from cpv_cc_tc_case_mapping where status not in('R')) and  CONVERT(VARCHAR, a.CASE_REC_DATETIME,103)>='" + txtDate.Text + "'and CONVERT(VARCHAR, a.CASE_REC_DATETIME,103)<'" + txtToDate.Text + "'";

                strsql2 = strSql + " " + "Union" + " " + strsql1;
            }
            sdsGV.SelectCommand = strsql2;
            gvFEAssignmentCases.DataBind();
            if (gvFEAssignmentCases.Rows.Count <= 0)
            {
                lblMsg.Text = "No record found";
            }
        }
        catch (Exception ex)
        {
            lblMsg.Visible = true;
            lblMsg.Text = "Error while retreiving data: " + ex.Message;
        }
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        try
        {
            FillView();
        }
        catch (Exception exp)
        {
            lblMsg.Text = "Error occured operation faild";
        }
    }
    protected void btnAssign_Click(object sender, EventArgs e)
    {
        try
        {
            HiddenField hdnCaseID;
            CheckBox chkCaseID;
            String strSelectedCaseID = "";
            foreach (GridViewRow row in gvFEAssignmentCases.Rows)
            {
                hdnCaseID = (HiddenField)row.FindControl("hidCaseId");
                chkCaseID = (CheckBox)row.FindControl("chkCaseId");
                if (chkCaseID.Checked)
                    strSelectedCaseID += "'" + hdnCaseID.Value + "'" + ",";
            }
            if (strSelectedCaseID != "")
            {
                CTCReAssignment oTC = new CTCReAssignment(); 
                oTC.arrCaseID = (strSelectedCaseID.TrimEnd(',')).Split(',');
                oTC.AssignedTo = ddlTc.SelectedValue.ToString();
                oTC.VerificationType = hdnVerificatioTypeID.Value.ToString();//ddlType.SelectedValue.ToString();
                oTC.InsertTcCaseMapping(strSelectedCaseID.TrimEnd(','));
                lblMsg.Text = "TeleCaller assigned successfully";
            }
            else
                lblMsg.Text = "Please select case to assign";
            ddlType.SelectedValue = hdnVerificatioTypeID.Value.ToString();

            FillView();
            //ddlFromPin.SelectedIndex = 0;
            //ddlToPin.SelectedIndex = 0;
            //FillFE();
        }
        catch (Exception exp)
        {
            lblMsg.Visible = true;
            lblMsg.Text = "Error occured, TeleCaller assignment faild";
        }
    }
    protected void ddlTc_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlType.SelectedIndex = 0;
    }
}
