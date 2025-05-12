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

public partial class CPV_CC_CC_TC_ManuAssign : System.Web.UI.Page
{
    CTCReAssignment oTC = new CTCReAssignment();
    protected void Page_Load(object sender, EventArgs e)
    {

        if (Session["isAdd"].ToString() != "1")
            Response.Redirect("NoAccess.aspx");

        lblMsg.Text = "";
        if (!IsPostBack)
        {
            try
            {
                //ddlType.DataBind();
                FillView();
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
            String strSql = "";
            String strCentreID = "";
            String strClientID = "";
            strCentreID = Session["CentreId"].ToString();
            strClientID = Session["ClientId"].ToString();
            
            CCommon objCommon = new CCommon();

            strSql = "select * from tcdump order by recieveddate";
            //strSql = "select ca.Case_Id,ca.Applicant_Name,ca.office_address as 'Address',cd.Mobile,ca.case_rec_datetime as" +
            //      "'Receive Date',vm.verification_type_code as 'Verification Type' from tcdump CA inner join" +
            //      " cpv_cc_case_details cd on ca.case_id=cd.case_id inner join CPV_CC_CASE_VERIFICATIONTYPE cv" +
            //      " on ca.case_id=cv.case_id inner join VERIFICATION_TYPE_MASTER vm on" +
            //      " cv.VERIFICATION_TYPE_ID=vm.VERIFICATION_TYPE_ID WHERE(CD.SEND_DATETIME IS NULL) AND" +
            //      " CD.CLIENT_ID='" + strClientID + "' AND CD.CENTRE_ID='" + strCentreID + "'";
                            
            sdsGV.SelectCommand = strSql;
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
            FillView1();
            gvFEAssignmentCases_DataBound(sender, e);
        }
        catch (Exception exp)
        {
            lblMsg.Text = "Error occured operation faild";
        }
    }
    public void FillView1()
    {
        try
        {
            String strSql = "";
            String strCentreID = "";
            String strClientID = "";
            strCentreID = Session["CentreId"].ToString();
            strClientID = Session["ClientId"].ToString();
            CCommon objCommon = new CCommon();

            ////////strSql = "select ca.CaseId,ca.ApplicantName,ca.officeAddress as 'Address',cd.Mobile,ca.RecievedDate as" + 
            ////////         "'Receive Date',vm.verification_type_code as 'Verification Type' from tcdump CA inner join" +
            ////////         " cpv_cc_case_details cd on ca.caseId=cd.case_id inner join cpv_cc_tc_case_mapping tm on cd.case_id=tm.case_id inner join CPV_CC_CASE_VERIFICATIONTYPE cv" + 
            ////////         " on ca.caseId=cv.case_id inner join VERIFICATION_TYPE_MASTER vm on" + 
            ////////         " cv.VERIFICATION_TYPE_ID=vm.VERIFICATION_TYPE_ID WHERE(CD.SEND_DATETIME IS NULL) AND" + 
            ////////         " CD.CLIENT_ID in('10111','10140')  AND " + 
            ////////         "(CONVERT(VARCHAR, CD.CASE_REC_DATETIME,103)>='" + txtDate.Text + "'AND " + 
            ////////         "(CONVERT(VARCHAR, CD.CASE_REC_DATETIME,103)<='" + txtToDate.Text + "')) AND " +
            ////////         "CV.VERIFICATION_TYPE_ID in('RT','BT') And tm.status not in ('A','R','M')order by cd.case_id";
            
            //strSql = "select * from tcdump where RecievedDate >= '" + txtDate.Text + "' and RecievedDate < '" + txtToDate.Text + "'";

            //sdsGV.SelectCommand = strSql;
            //gvFEAssignmentCases.DataBind();
            //if (gvFEAssignmentCases.Rows.Count <= 0)
            //{
            //    lblMsg.Text = "No record found";
            //}
        }
        catch (Exception ex)
        {
            lblMsg.Visible = true;
            lblMsg.Text = "Error while retreiving data: " + ex.Message;
        }
    }
    private struct gridposition
    {
        public const int caseid = 0;
        public const int refno = 1;
        public const int appli = 2;
        public const int residenceadd = 3;
        public const int city = 4;
        public const int oadd = 5;
        public const int ocity = 6;
        public const int date = 7;
        public const int verification = 9;
    }
    protected void btnAssign_Click(object sender, EventArgs e)
    {
        string veri;
        try
        {
            HiddenField hdnCaseID;
            CheckBox chkCaseID;
            String strSelectedCaseID = "";
            foreach (GridViewRow row in gvFEAssignmentCases.Rows)
            {
                hdnCaseID = (HiddenField)row.FindControl("hidCaseId");
                chkCaseID = (CheckBox)row.FindControl("chkCaseId");
                veri = row.Cells[gridposition.verification].Text;
                if (chkCaseID.Checked)
                {
                    strSelectedCaseID += "'" + hdnCaseID.Value + "'" + ",";
                    oTC.VerificationType = veri;
                }
            }

                if (strSelectedCaseID != "")
                {
                   
                    oTC.arrCaseID = (strSelectedCaseID.TrimEnd(',')).Split(',');
                    oTC.AssignedTo = ddlTc.SelectedValue.ToString();
                   
                    //oTC.VerificationType = ddlType.SelectedValue.ToString();//hdnVerificatioTypeID.Value.ToString();
                    oTC.InsertMuTcCaseMapping(strSelectedCaseID.TrimEnd(','));
                    lblMsg.Text = "TeleCaller assigned successfully";
                }
                else
                    lblMsg.Text = "Please select case to assign";
                //ddlType.SelectedValue = hdnVerificatioTypeID.Value.ToString();
        
            FillView();
      
        }
        catch (Exception exp)
        {
            lblMsg.Visible = true;
            lblMsg.Text = "Error occured, TeleCaller assignment faild";
        }
    }
    protected void gvFEAssignmentCases_DataBound(object sender, EventArgs e)
    {
        if (gvFEAssignmentCases.Rows.Count <= 0)
        {
            //lblMsg.Text = "No record found";
        }
        else
        {
            //tblCaseCount.Visible = true;
            System.Web.UI.WebControls.CheckBox cbHeader = ((System.Web.UI.WebControls.CheckBox)(gvFEAssignmentCases.HeaderRow.FindControl("HeaderLevelCheckBox")));
            cbHeader.Attributes["onclick"] = "ChangeAllCheckBoxStates(this.checked);";
            foreach (GridViewRow gvr in gvFEAssignmentCases.Rows)
            {
                // Get a programmatic reference to the CheckBox control
                System.Web.UI.WebControls.CheckBox cb = ((System.Web.UI.WebControls.CheckBox)(gvr.FindControl("chkCaseId")));
                ClientScript.RegisterArrayDeclaration("CheckBoxIDs", string.Concat("\'", cb.ClientID, "\'"));
            }
        }
    }
}
