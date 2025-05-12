
/*----------------------------------------------------------------------------------------
Scope of Program	:	
File Name			:	KYC_KYC_CaseVerificationEntry.aspx.cs
Create By			:	Hemangi Kambli
Create Date		    :	16th April 2007
Remarks 		    :	This class is used for KYC Case verification entry.
						
----------------------------------------------------------------------------------------*/
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

public partial class KYC_KYC_CaseVerificationEntry : System.Web.UI.Page
{
    private CKYC objKYC = new CKYC();
    DataSet dsKYC = new DataSet();
    DataSet dsAttempt = new DataSet();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session.Count == 0)
            Response.Redirect("Default.aspx");

        if (!IsPostBack)
        {
            if (Context.Request.QueryString["CaseID"] != null && Context.Request.QueryString["CaseID"] != "")
            {
                string sCaseId = Request.QueryString["CaseID"].ToString();
                if (sCaseId != "")
                {
                    dsKYC = objKYC.GetKYCCaseEntry(sCaseId);
                    dsAttempt = objKYC.GetAttemptDtl(sCaseId);
                    
                    txtAttemptDate1.Text = DateTime.Now.ToString("dd-MMM-yyyy");
                    txtAttemptDate2.Text = DateTime.Now.ToString("dd-MMM-yyyy");
                    txtAttemptDate3.Text = DateTime.Now.ToString("dd-MMM-yyyy");

                    if (dsKYC.Tables[0].Rows.Count > 0)
                    {
                        lblRefNo.Text = dsKYC.Tables[0].Rows[0]["Ref_No"].ToString();
                        lblAddress.Text = dsKYC.Tables[0].Rows[0]["Address"].ToString();
                        lblName.Text = dsKYC.Tables[0].Rows[0]["Name"].ToString();
                    }
                    if (dsAttempt.Tables[0].Rows.Count > 0)
                    {                        
                        ddlVerifier.SelectedValue = dsAttempt.Tables[0].Rows[0]["Emp_Id"].ToString();
                        ddlCaseStatus.SelectedValue = dsAttempt.Tables[0].Rows[0]["Case_Status_ID"].ToString();
                        ///////////
                        for (int i = 0; i < dsAttempt.Tables[0].Rows.Count; i++)
                        {
                            if (i == 0)
                            {
                                string sTmp = dsAttempt.Tables[0].Rows[i]["Attempt_Date_Time"].ToString();
                                string[] arrAttemptDateTime = sTmp.Split(' ');
                                txtAttemptDate1.Text = Convert.ToDateTime(arrAttemptDateTime[0].ToString()).ToString("dd-MMM-yyyy");
                                txtAttemptTime1.Text = Convert.ToDateTime(arrAttemptDateTime[1].ToString()).ToString("hh:mm");
                                ddlAttemptTimeType1.SelectedValue = arrAttemptDateTime[2].ToString();
                                txtAttemptRemark1.Text = dsAttempt.Tables[0].Rows[i]["Remark"].ToString();
                            }
                            if (i == 1)
                            {
                                string sTmp = dsAttempt.Tables[0].Rows[i]["Attempt_Date_Time"].ToString();
                                string[] arrAttemptDateTime = sTmp.Split(' ');
                                txtAttemptDate2.Text = Convert.ToDateTime(arrAttemptDateTime[0].ToString()).ToString("dd-MMM-yyyy");
                                txtAttemptTime2.Text = Convert.ToDateTime(arrAttemptDateTime[1].ToString()).ToString("hh:mm");
                                ddlAttemptTimeType2.SelectedValue = arrAttemptDateTime[2].ToString();
                                txtAttemptRemark2.Text = dsAttempt.Tables[0].Rows[i]["Remark"].ToString();                                
                            }
                            if (i == 2)
                            {
                                string sTmp = dsAttempt.Tables[0].Rows[i]["Attempt_Date_Time"].ToString();
                                string[] arrAttemptDateTime = sTmp.Split(' ');
                                txtAttemptDate3.Text = Convert.ToDateTime(arrAttemptDateTime[0].ToString()).ToString("dd-MMM-yyyy");
                                txtAttemptTime3.Text = Convert.ToDateTime(arrAttemptDateTime[1].ToString()).ToString("hh:mm");
                                ddlAttemptTimeType3.SelectedValue = arrAttemptDateTime[2].ToString();
                                txtAttemptRemark3.Text = dsAttempt.Tables[0].Rows[i]["Remark"].ToString();
                            }
                        }
                    }
                }
            }
        }
    }

    private bool IsValidAttempt()
    {
        try
        {
            bool IsValid = true;

            if (txtAttemptTime1.Text.Trim() != "" && IsValid == true)
            {
                if (txtAttemptDate1.Text == "")
                {
                    IsValid = false;
                    lblMsg.Visible = true;
                    lblMsg.Text = "Enter date in first attempt.";
                    txtAttemptDate1.Focus();
                }
                if (txtAttemptRemark1.Text == "")
                {
                    IsValid = false;
                    lblMsg.Visible = true;
                    lblMsg.Text = "Enter remark in first attempt.";
                    txtAttemptRemark1.Focus();
                }
            }
            if (txtAttemptRemark1.Text.Trim() != "" && IsValid == true)
            {
                if (txtAttemptDate1.Text == "")
                {
                    IsValid = false;
                    lblMsg.Visible = true;
                    lblMsg.Text = "Enter date in first attempt.";
                    txtAttemptDate1.Focus();
                }
                if (txtAttemptTime1.Text == "")
                {
                    IsValid = false;
                    lblMsg.Visible = true;
                    lblMsg.Text = "Enter time in first attempt.";
                    txtAttemptTime1.Focus();
                }
                if (txtAttemptRemark1.Text.Length > 500)
                {
                    IsValid = false;
                    lblMsg.Visible = true;
                    lblMsg.Text = "Remark should not be greater than 500 characters in first attempt.";
                    txtAttemptRemark1.Focus();
                }

            }

            if (txtAttemptTime2.Text != "" && IsValid == true)
            {
                if (txtAttemptDate2.Text == "")
                {
                    IsValid = false;
                    lblMsg.Visible = true;
                    lblMsg.Text = "Enter date in second attempt.";
                    txtAttemptDate2.Focus();
                }
                if (txtAttemptRemark2.Text == "")
                {
                    IsValid = false;
                    lblMsg.Visible = true;
                    lblMsg.Text = "Enter remark in second attempt.";
                    txtAttemptRemark2.Focus();
                }
            }

            if (txtAttemptRemark2.Text != "" && IsValid == true)
            {
                if (txtAttemptDate2.Text == "")
                {
                    IsValid = false;
                    lblMsg.Visible = true;
                    lblMsg.Text = "Enter date in second attempt.";
                    txtAttemptDate2.Focus();
                }
                if (txtAttemptTime2.Text == "")
                {
                    IsValid = false;
                    lblMsg.Visible = true;
                    lblMsg.Text = "Enter time in second attempt.";
                    txtAttemptTime2.Focus();
                }
                if (txtAttemptRemark2.Text.Length > 500)
                {
                    IsValid = false;
                    lblMsg.Visible = true;
                    lblMsg.Text = "Remark should not be greater than 500 characters in second attempt.";
                    txtAttemptRemark2.Focus();
                }
            }

            if (txtAttemptTime3.Text != "" && IsValid == true)
            {
                if (txtAttemptDate3.Text == "")
                {
                    IsValid = false;
                    lblMsg.Visible = true;
                    lblMsg.Text = "Enter date in third attempt.";
                    txtAttemptDate3.Focus();
                }
                if (txtAttemptRemark3.Text == "")
                {
                    IsValid = false;
                    lblMsg.Visible = true;
                    lblMsg.Text = "Enter remark in third attempt.";
                    txtAttemptRemark3.Focus();
                }

            }

            if (txtAttemptRemark3.Text != "" && IsValid == true)
            {
                if (txtAttemptDate3.Text == "")
                {
                    IsValid = false;
                    lblMsg.Visible = true;
                    lblMsg.Text = "Enter date in third attempt.";
                    txtAttemptDate3.Focus();
                }
                if (txtAttemptTime3.Text == "")
                {
                    IsValid = false;
                    lblMsg.Visible = true;
                    lblMsg.Text = "Enter time in third attempt.";
                    txtAttemptTime3.Focus();
                }
                if (txtAttemptRemark3.Text.Length > 500)
                {
                    IsValid = false;
                    lblMsg.Visible = true;
                    lblMsg.Text = "Remark should not be greater than 500 characters in third attempt.";
                    txtAttemptRemark3.Focus();
                }
            }
            //if (txtAddress1.Text != "")
            //{
            //    if (txtAddress1.Text.Length > 500)
            //    {
            //        IsValid = false;
            //        lblMsg.Visible = true;
            //        lblMsg.Text = "Billing address should not be greater than 500 characters.";
            //        txtattAddress1.Focus();
            //    }
            //}
            if (txtAttemptTime1.Text.Trim() == "" && txtAttemptTime2.Text.Trim() == "" && txtAttemptTime3.Text.Trim() == "")
            {
                IsValid = false;
                lblMsg.Visible = true;
                lblMsg.Text = "Enter atleast one record.";
                txtAttemptTime1.Focus();
            }
            return IsValid;
        }
        catch (Exception ex)
        {
            throw new Exception("Error while validation", ex);
        }
    }

    #region ClearControl()
    private void ClearControl()
    {
        ddlVerifier.SelectedIndex = 0;      
        txtAttemptDate1.Text = "";
        txtAttemptDate2.Text = "";
        txtAttemptDate3.Text = "";
        txtAttemptRemark1.Text = "";
        txtAttemptRemark2.Text = "";
        txtAttemptRemark3.Text = "";
        txtAttemptTime1.Text = "";
        txtAttemptTime2.Text = "";
        txtAttemptTime3.Text = "";
  
    }
    #endregion ClearControl()

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        int iCount = 0;
        //if (Session["isEdit"].ToString() != "1")
        //    iCount = 1;
        //if(iCount==1)
        //    Response.Redirect("NoAccess.aspx");
        try
        {
            ArrayList arrAttempt = new ArrayList();
            ArrayList arrAttempt1 = new ArrayList();
            ArrayList arrAttempt2 = new ArrayList();
            ArrayList arrAttempt3 = new ArrayList();
            if (IsValidAttempt() == true)
            {
                string strCaseID = Request.QueryString["CaseID"].ToString();
                objKYC.CaseId = strCaseID;

                objKYC.VerifierID = ddlVerifier.SelectedValue.ToString();
                //objKYC.VerificationTypeID = ddlVeriType.SelectedValue.ToString();
                objKYC.CaseStatusID = ddlCaseStatus.SelectedValue.ToString();
                

                if (txtAttemptDate1.Text.Trim() != "" && txtAttemptTime1.Text.Trim() != "")
                {
                    arrAttempt1.Clear();
                    arrAttempt1.Add(txtAttemptDate1.Text.Trim() + " " + txtAttemptTime1.Text.Trim() + " " + ddlAttemptTimeType1.SelectedItem.Text.Trim());
                    arrAttempt1.Add(txtAttemptRemark1.Text.Trim());
                    arrAttempt.Add(arrAttempt1);
                }

                if (txtAttemptDate2.Text.Trim() != "" && txtAttemptTime2.Text.Trim() != "")
                {
                    arrAttempt2.Clear();
                    arrAttempt2.Add(txtAttemptDate2.Text.Trim() + " " + txtAttemptTime2.Text.Trim() + " " + ddlAttemptTimeType2.SelectedItem.Text.Trim());
                    arrAttempt2.Add(txtAttemptRemark2.Text.Trim());
                    arrAttempt.Add(arrAttempt2);
                }

                if (txtAttemptDate3.Text.Trim() != "" && txtAttemptTime3.Text.Trim() != "")
                {
                    arrAttempt3.Clear();
                    arrAttempt3.Add(txtAttemptDate3.Text.Trim() + " " + txtAttemptTime3.Text.Trim() + " " + ddlAttemptTimeType3.SelectedItem.Text.Trim());
                    arrAttempt3.Add(txtAttemptRemark3.Text.Trim());
                    arrAttempt.Add(arrAttempt3);
                }

                OleDbDataReader oledbRead = objKYC.GetKYCCaseVerify(strCaseID);
                if (oledbRead.Read() == true)
                {
                    if (objKYC.UpdateKYCCaseVerification(arrAttempt) == 1)
                    {
                        ClearControl();
                        lblMsg.Visible = true;
                        lblMsg.Text = "Record updated successfully.";
                        iCount = 1;
                    }
                }
                else
                {
                    if (objKYC.InsertKYCCaseVerification(arrAttempt) == 1)
                    {
                        ClearControl();
                        lblMsg.Visible = true;
                        lblMsg.Text = "Record added successfully.";
                        iCount = 1;
                    }
                }
            }
        }
        catch (Exception ex)
        {
            lblMsg.Visible = true;
            lblMsg.Text = ex.Message.ToString();
        }
        if (iCount == 1)
            Response.Redirect("KYC_CaseVeriView.aspx?OperationId=" + Request.QueryString["OperationId"] + "&Msg=" + lblMsg.Text);

    }
    protected void ddlVeriType_SelectedIndexChanged(object sender, EventArgs e)
    {
        //if ((ddlVeriType.SelectedValue.ToString() == "1") || (ddlVeriType.SelectedValue.ToString() == "2"))
        //{
        //    sdsVerifier.SelectCommand = objKYC.GetVerifier("3");
        //    ddlVerifier.DataBind();
        //}
    }


    protected void ddlVerifier_DataBound(object sender, EventArgs e)
    {
        ddlVerifier.Items.Insert(0, new ListItem("Select Verifier", "0"));
    }

    protected void cvSelectverifier_ServerValidate(object source, ServerValidateEventArgs args)
    {
        if (source.ToString() == "0")
        {
            lblMsg.Text = "Please select verifier.";
        }
    }

    protected void cvSelectveriType_ServerValidate(object source, ServerValidateEventArgs args)
    {
        if (source.ToString() == "0")
        {
            lblMsg.Text = "Please select verification type.";
        }
    }

    protected void ddlVeriType_DataBound(object sender, EventArgs e)
    {
        //ddlVeriType.Items.Insert(0, new ListItem("Select Type", "0"));
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("KYC_CaseVeriView.aspx");
    }

}

