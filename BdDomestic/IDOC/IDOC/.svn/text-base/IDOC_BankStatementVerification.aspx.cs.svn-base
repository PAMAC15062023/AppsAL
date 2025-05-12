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

public partial class IDOC_IDOC_BankStatementVerification : System.Web.UI.Page
{
    CIDOC objIdoc = new CIDOC();
    CIDocVerification objIDocVer = new CIDocVerification();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["isAdd"].ToString() != "1")
            Response.Redirect("NoAccess.aspx");
        txtNameOfContPerson.Focus();

        if (!IsPostBack)
        {
            try
            {
                hdnTransStart.Value = DateTime.Now.ToString();//"dd/MM/yyyy hh:mm:ss tt");
                if (Context.Request.QueryString["Op"] != null && Context.Request.QueryString["Op"] != "")
                {
                    if (Request.QueryString["Op"].ToString() == "search")
                    {
                        SetReadOnlyFields();
                    }
                    //Added By : Gargi Srivastava
                    //Purpose  : For Enableing The buttons visibility false of the Pop up
                    //Added Date: 11-Dec-2007
                    if (Request.QueryString["Op"].ToString() == "View")
                    {
                        btnSubmit.Enabled = false;
                        btnCancel.Enabled = false;
                       
                    }
                    //End
                    
                }
                
                if (Context.Request.QueryString["CaseID"] != null && Context.Request.QueryString["CaseID"] != "" && Context.Request.QueryString["VerTypeId"] != null && Context.Request.QueryString["VerTypeId"] != "")
                {
                    if (Session["isEdit"].ToString() != "1")
                        Response.Redirect("NoAccess.aspx");

                    string sCaseId = Request.QueryString["CaseID"].ToString();
                    string sVerifyTypeId = Request.QueryString["VerTypeId"].ToString();
                    Session["CaseID"] = sCaseId;
                    OleDbDataReader oledbFERead;
                    oledbFERead = objIDocVer.GetFEName(sCaseId, sVerifyTypeId);
                    if (oledbFERead.Read())
                    {
                        txtFEName.Text = oledbFERead["FullName"].ToString();
                        if (oledbFERead["date_time"].ToString().Trim() != "")
                            txtVerificationDate.Text = Convert.ToDateTime(oledbFERead["date_time"].ToString()).ToString("dd/MM/yyyy");
                    }
                    oledbFERead.Close();

                    if (sCaseId != "")
                    {
                        OleDbDataReader oledbRead;
                        oledbRead = objIDocVer.GetIDOCsCaseDetail(sCaseId);
                        if (oledbRead.Read() == true)
                        {
                            txtAppName.Text = oledbRead["FULL NAME"].ToString();
                            txtRefNo.Text = oledbRead["REF_NO"].ToString();
                            txtInitiationDate.Text = Convert.ToDateTime(oledbRead["RECD_DATE"].ToString()).ToString("dd/MM/yyyy hh:mm tt");
                            txtBankName.Text = oledbRead["BANK_NAME"].ToString();
                            txtBankAddress.Text = oledbRead["BANK_ADDRESS"].ToString() + " " + oledbRead["BANK_CITY"].ToString() + " " + oledbRead["BANK_PIN"].ToString();
                        }
                        oledbRead.Close();

                        OleDbDataReader oledbIDocVerRead;
                        oledbIDocVerRead = objIDocVer.GetIDOCsCaseVerificationDetail(sCaseId, sVerifyTypeId);
                        if (oledbIDocVerRead.Read() == true)
                        {
                            txtNameOfContPerson.Text = oledbIDocVerRead["Person_contacted"].ToString();
                            string[] sArrDesgnDept = oledbIDocVerRead["Cont_Designation_dept"].ToString().Split('+');
                            if (sArrDesgnDept.Length > 0)
                            {
                                txtDeptOfContPerson.Text = sArrDesgnDept[0].ToString();
                                if (sArrDesgnDept.Length > 1)
                                    txtDesgnOfContPerson.Text = sArrDesgnDept[1].ToString();
                            }
                            ddlBankStatAsPerFormat.SelectedValue = oledbIDocVerRead["DOCUMENT_AS_PER_STANDARD"].ToString();
                            ddlCorrectAmtAsPerBankStat.SelectedValue = oledbIDocVerRead["AMOUNT_ON_DOC"].ToString();
                            ddlIsCorrectAcctNo.SelectedValue = oledbIDocVerRead["ACCOUNT_CORRECT"].ToString();
                            txtRemarks.Text = oledbIDocVerRead["FE_REMARK"].ToString();
                            txtVerificationDate.Text = oledbIDocVerRead["FE_VISIT_DATE"].ToString();
                            ddlCaseStatus.DataBind();
                            ddlCaseStatus.SelectedValue = oledbIDocVerRead["CASE_STATUS_ID"].ToString();

                        }
                    }

                }
            }
            catch (Exception ex)
            {
                lblMsg.Visible = true;
                lblMsg.Text = "Error while retreiving data: " + ex.Message;
            }
        }
    }

    private void SetReadOnlyFields()
    {
        txtDeptOfContPerson.ReadOnly = true;
        txtDesgnOfContPerson.ReadOnly = true;
        txtNameOfContPerson.ReadOnly = true;
        txtRemarks.ReadOnly = true;
        txtVerificationDate.ReadOnly = true;
        ddlBankStatAsPerFormat.Enabled = false;
        ddlCaseStatus.Enabled = false;
        ddlIsCorrectAcctNo.Enabled = false;
        btnSubmit.Enabled = false;
        ddlCorrectAmtAsPerBankStat.Enabled = false;
        
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        int iCount = 0;
        try
        {
        bool iValidRemark = true;
        string sRemark="";
        sRemark = txtRemarks.Text;
        if (sRemark.Trim() != "")
        {
            if (sRemark.Length > 600)
            {
                lblMsg.Visible = true;
                lblMsg.ForeColor = System.Drawing.Color.Red;
                lblMsg.Font.Bold = true;
                lblMsg.Text = "Remark should not be greater than 600 characters.";
                iValidRemark = false;
            }
        }
        if (iValidRemark == true)
        {
            
            string sMsg = "";

            objIDocVer.CaseID = Request.QueryString["CaseID"].ToString();
            objIDocVer.CaseStatusID = ddlCaseStatus.SelectedValue.ToString();
            objIDocVer.VerificationTypeId = Request.QueryString["VerTypeId"].ToString();
            objIDocVer.NameOfPersonContacted = txtNameOfContPerson.Text.Trim();
            objIDocVer.Cont_DesignationDepartment = txtDesgnOfContPerson.Text.Trim() + "+" + txtDeptOfContPerson.Text.Trim();
            objIDocVer.IsAcctCorrect = ddlIsCorrectAcctNo.SelectedValue.ToString();
            objIDocVer.AmtSSSPSC = ddlCorrectAmtAsPerBankStat.SelectedValue.ToString();
            objIDocVer.StanForOrg = ddlBankStatAsPerFormat.SelectedValue.ToString();
            objIDocVer.VeriDate = txtVerificationDate.Text.Trim();
            objIDocVer.FERemarks = txtRemarks.Text.Trim();
            objIDocVer.AddedBy = Session["UserId"].ToString();
            objIDocVer.ModifyBy = Session["UserId"].ToString();
            objIDocVer.AddedOn = DateTime.Now;
            objIDocVer.ModifyOn = DateTime.Now;
            //Added by hemangi kambli on 03/10/2007 
            if (hdnTransStart.Value != "")
                objIDocVer.TransStart = Convert.ToDateTime(hdnTransStart.Value);
            objIDocVer.TransEnd = Convert.ToDateTime(DateTime.Now.ToString());//"dd/MM/yyyy hh:mm:ss tt"));
            objIDocVer.CentreId = Session["CentreId"].ToString();
            objIDocVer.ProductId = Session["ProductId"].ToString();
            objIDocVer.ClientId = Session["ClientId"].ToString();
            objIDocVer.UserId = Session["UserId"].ToString();
            ///------------------------------------------------------

            sMsg = objIDocVer.InsertUpdateBankStatement();
            if (sMsg != "")
            {
                lblMsg.Text = sMsg.Trim();
                iCount = 1;
            }
            
        }
    }
    catch (Exception ex)
    {
        lblMsg.Visible = true;
        lblMsg.Text = "Error while retreiving data: " + ex.Message;
    }
    if (iCount == 1)
    {
        Response.Redirect("IDOC_VerificationView.aspx?Msg=" + lblMsg.Text);
    }
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
      

        if (Context.Request.QueryString["Op"] != null && Context.Request.QueryString["Op"] != "")
        {
            if (Request.QueryString["Op"].ToString() == "search")
            {
                string sCaseId = Request.QueryString["CaseID"].ToString();
                string sVerifyTypeId = Request.QueryString["VerTypeId"].ToString();
                string sName = Request.QueryString["Name"].ToString();
                string sDOB = Request.QueryString["DOB"].ToString();
                string sVerificationTypeId = Request.QueryString["VerificationTypeId"].ToString();
                Response.Redirect("IDOC_DeDupSearch.aspx?CaseID=" + sCaseId + "&VerTypeId=" + sVerifyTypeId + "&Name=" + sName + "&VerificationTypeId="  + sVerificationTypeId + "&DOB=" + sDOB + "&Op=search");
            }
            
        }
        else
            Response.Redirect("IDOC_VerificationView.aspx");
   
    }
}
    

