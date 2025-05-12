

/*----------------------------------------------------------------------------------------
Scope of Program	:	
File Name			:	CC_CaseEntry.aspx.cs
Create By			:	Hemangi Kambli
Create Date		    :	5th April 2007
Remarks 		    :	This class is used for CreditCardCaseEntry.
						
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

public partial class CC_CC_CaseEntry : System.Web.UI.Page
{
    CCreditCard objCreditCard = new CCreditCard();
    DataSet dsCreditCard = new DataSet();
    DataSet dsVerification = new DataSet();

    protected void Page_Load(object sender, EventArgs e)
    {           
        if (!IsPostBack)
        {
            if (Session["isAdd"].ToString() != "1")
                Response.Redirect("NoAccess.aspx");
            //string sActivityID = "1011";
            string sActivityID = Session["ActivityId"].ToString();
            chkCaseVerification.DataSource = objCreditCard.GetCaseVerificationType(sActivityID);
            chkCaseVerification.DataValueField = "Verification_type_Id";
            chkCaseVerification.DataTextField = "Verification_type_code";
            chkCaseVerification.DataBind();
            
            ddCaseType.Focus();

            if (Context.Request.QueryString["CaseID"] != null && Context.Request.QueryString["CaseID"] != "")
            {
                if (Session["isEdit"].ToString() != "1")
                    Response.Redirect("NoAccess.aspx");

                string sCaseId = Request.QueryString["CaseID"].ToString();
                if (sCaseId != "")
                {
                    dsCreditCard = objCreditCard.GetCreditCaseEntry(sCaseId, Session["CentreId"].ToString(), Session["ClientId"].ToString());
                    dsVerification = objCreditCard.GetAllVerificationId(sCaseId);

                    if (dsCreditCard.Tables[0].Rows.Count > 0)
                    {
                        if (dsVerification.Tables[0].Rows.Count > 0)
                        {
                            for (int i = 0; i < dsVerification.Tables[0].Rows.Count; i++)
                            {
                                foreach (ListItem li in chkCaseVerification.Items)
                                {
                                    if (li.Value == dsVerification.Tables[0].Rows[i][0].ToString())
                                        li.Selected = true;
                                }
                            }
                        }
                        string sTmp = dsCreditCard.Tables[0].Rows[0]["CASE_REC_DATETime"].ToString();
                        if (sTmp != "")
                        {
                            string[] arrRecDateTime = sTmp.Split(' ');
                            if (arrRecDateTime[0].ToString() != "")
                                txtRecDate.Text = Convert.ToDateTime(arrRecDateTime[0].ToString()).ToString("dd/MM/yyyy");
                            if (arrRecDateTime[1].ToString() != "")
                                txtRecTime.Text = Convert.ToDateTime(arrRecDateTime[1].ToString()).ToString("hh:mm");

                            ddlTimeType.SelectedValue = arrRecDateTime[2].ToString();
                        }
                        ddCaseType.Text = dsCreditCard.Tables[0].Rows[0]["CASE_TYPE"].ToString();
                        txtRefNo.Text = dsCreditCard.Tables[0].Rows[0]["Ref_No"].ToString();
                        txtTitle.Text = dsCreditCard.Tables[0].Rows[0]["Title"].ToString();
                        txtFirstNm.Text = dsCreditCard.Tables[0].Rows[0]["First_Name"].ToString();
                        txtMiddleNm.Text = dsCreditCard.Tables[0].Rows[0]["Middle_Name"].ToString();
                        txtLastNm.Text = dsCreditCard.Tables[0].Rows[0]["Last_Name"].ToString();
                        if (dsCreditCard.Tables[0].Rows[0]["DOB"].ToString() != "")
                            txtDOB.Text = dsCreditCard.Tables[0].Rows[0]["DOB"].ToString();
                        txtResAdd1.Text = dsCreditCard.Tables[0].Rows[0]["RES_ADD_LINE_1"].ToString();
                        txtResAdd2.Text = dsCreditCard.Tables[0].Rows[0]["RES_ADD_LINE_2"].ToString();
                        txtResAdd3.Text = dsCreditCard.Tables[0].Rows[0]["RES_ADD_LINE_3"].ToString();
                        txtResCity.Text = dsCreditCard.Tables[0].Rows[0]["RES_CITY"].ToString();
                        txtResState.Text = dsCreditCard.Tables[0].Rows[0]["RES_STATE"].ToString();
                        txtResPin.Text = dsCreditCard.Tables[0].Rows[0]["RES_PIN_CODE"].ToString();
                        txtLandMark.Text = dsCreditCard.Tables[0].Rows[0]["RES_LAND_MARK"].ToString();
                        txtResPhone.Text = dsCreditCard.Tables[0].Rows[0]["RES_PHONE"].ToString();
                        txtResMob.Text = dsCreditCard.Tables[0].Rows[0]["MOBILE"].ToString();
                        txtOffName.Text = dsCreditCard.Tables[0].Rows[0]["OFF_NAME"].ToString();
                        txtOffAdd1.Text = dsCreditCard.Tables[0].Rows[0]["OFF_ADD_LINE_1"].ToString();
                        txtOffAdd2.Text = dsCreditCard.Tables[0].Rows[0]["OFF_ADD_LINE_2"].ToString();
                        txtOffAdd3.Text = dsCreditCard.Tables[0].Rows[0]["OFF_ADD_LINE_3"].ToString();
                        txtOffCity.Text = dsCreditCard.Tables[0].Rows[0]["OFF_CITY"].ToString();
                        txtOffPhone.Text = dsCreditCard.Tables[0].Rows[0]["OFF_PHONE"].ToString();
                        txtOffExtn.Text = dsCreditCard.Tables[0].Rows[0]["OFF_EXTN"].ToString();
                        txtOffState.Text = dsCreditCard.Tables[0].Rows[0]["OFF_STATE"].ToString();
                        txtOffPin.Text = dsCreditCard.Tables[0].Rows[0]["OFF_PIN_CODE"].ToString();
                        txtDesgn.Text = dsCreditCard.Tables[0].Rows[0]["DESIGNATION"].ToString();
                        txtDept.Text = dsCreditCard.Tables[0].Rows[0]["DEPARTMENT"].ToString();
                        txtOccupation.Text = dsCreditCard.Tables[0].Rows[0]["OCCUPATION"].ToString();
                        txtOffPriority.Text = dsCreditCard.Tables[0].Rows[0]["PRIORITY"].ToString();
                        txtregion.Text = dsCreditCard.Tables[0].Rows[0]["REGION"].ToString();
                        txtSplInst.Text = dsCreditCard.Tables[0].Rows[0]["SPL_INSTRUCTION"].ToString();
                        txtPmtAdd1.Text = dsCreditCard.Tables[0].Rows[0]["PMT_ADD_LINE_1"].ToString();
                        txtPmtAdd2.Text = dsCreditCard.Tables[0].Rows[0]["PMT_ADD_LINE_2"].ToString();
                        txtPmtAdd3.Text = dsCreditCard.Tables[0].Rows[0]["PMT_ADD_LINE_3"].ToString();
                        txtPmtCity.Text = dsCreditCard.Tables[0].Rows[0]["PMT_CITY"].ToString();
                        txtPmtState.Text = dsCreditCard.Tables[0].Rows[0]["PMT_STATE"].ToString();
                        txtPmtpin.Text = dsCreditCard.Tables[0].Rows[0]["PMT_PIN_CODE"].ToString();
                        txtPmtLand.Text = dsCreditCard.Tables[0].Rows[0]["PMT_LANDMARK"].ToString();
                        txtPmtPhone.Text = dsCreditCard.Tables[0].Rows[0]["PMT_PHONE"].ToString();
                    }
                }
            }
        }
    }

    #region ClearControl()
    private void ClearControl()
    {
        if (chkCaseVerification.Items.Count > 0)
        {
            foreach (ListItem li in chkCaseVerification.Items)
            {
                li.Selected = false;
            }
        }
        txtOffName.Text = "";
        ddCaseType.SelectedIndex = 0;
        ddlTimeType.SelectedIndex = 0;
        txtTitle.Text = "";
        txtOffCity.Text = "";
        txtRefNo.Text = "";
        txtRecDate.Text = "";
        txtRecTime.Text = "";
        txtResAdd1.Text = "";
        txtResAdd2.Text = "";
        txtResAdd3.Text = "";
        txtResCity.Text = "";
        txtResState.Text = "";
        txtResPin.Text = "";
        txtResPhone.Text = "";
        txtResMob.Text = "";
        txtOffAdd1.Text = "";
        txtOffAdd2.Text = "";
        txtOffAdd3.Text = "";
        txtOffPhone.Text = "";
        txtOffPin.Text = "";
        txtOffExtn.Text = "";
        txtLandMark.Text = "";
        txtDept.Text = "";
        txtDesgn.Text = "";
        txtDOB.Text = "";
        txtFirstNm.Text = "";
        txtLastNm.Text = "";
        txtMiddleNm.Text = "";
        txtOccupation.Text = "";
        txtOffPriority.Text = "";
        txtregion.Text = "";
        txtSplInst.Text = "";
        txtPmtAdd1.Text = "";
        txtPmtAdd2.Text = "";
        txtPmtAdd3.Text = "";
        txtPmtCity.Text = "";
        txtPmtState.Text = "";
        txtPmtpin.Text = "";
        txtPmtLand.Text = "";
        txtPmtPhone.Text = "";
    }

    #endregion ClearControl()
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        bool bValidSPL = true;
        int iCount = 0;
        string sSPLInstruction = "";
        sSPLInstruction = txtSplInst.Text.Trim();
        try
        {
            if (sSPLInstruction.Trim() != "")
            {
                if (sSPLInstruction.Length > 255)
                {
                    lblMsg.Visible = true;
                    lblMsg.ForeColor = System.Drawing.Color.Red;
                    lblMsg.Font.Bold = true;
                    lblMsg.Text = "SPL Instruction should not be greater than 255 characters.";
                    bValidSPL = false;
                }
            }
            if (bValidSPL == true)
            {
                ArrayList arrVerType = new ArrayList();
                string sVerTypeCode = "";
                CCommon objCmn = new CCommon();
                if (txtDOB.Text.Trim() != "")
                    objCreditCard.DOB = txtDOB.Text.Trim();
                if (txtRecDate.Text.Trim() != "" && txtRecTime.Text.Trim() != "")
                    objCreditCard.ReceivedDateTime = Convert.ToDateTime(objCmn.strDate(txtRecDate.Text.Trim()) + " " + txtRecTime.Text.Trim() + " " + ddlTimeType.SelectedItem.Text.Trim());

                objCreditCard.CentreId = Session["CentreId"].ToString();
                objCreditCard.ClusterId = Session["ClusterId"].ToString();
                objCreditCard.ClientId = Session["ClientId"].ToString();
                objCreditCard.CaseType = ddCaseType.SelectedItem.Text.Trim();
                objCreditCard.RefNo = txtRefNo.Text.Trim();
                objCreditCard.Title = txtTitle.Text.Trim();
                objCreditCard.FirstName = txtFirstNm.Text.Trim();
                objCreditCard.MiddleName = txtMiddleNm.Text.Trim();
                objCreditCard.LastName = txtLastNm.Text.Trim();
                objCreditCard.FullName = txtFirstNm.Text.Trim() + " " + txtMiddleNm.Text.Trim() + " " + txtLastNm.Text.Trim();
                objCreditCard.ResAdd1 = txtResAdd1.Text.Trim();
                objCreditCard.ResAdd2 = txtResAdd2.Text.Trim();
                objCreditCard.ResAdd3 = txtResAdd3.Text.Trim();
                objCreditCard.ResCity = txtResCity.Text.Trim();
                objCreditCard.ResState = txtResState.Text.Trim();/*Adding  by chinu*/
                objCreditCard.ResPin = txtResPin.Text.Trim();
                objCreditCard.ResLandMark = txtLandMark.Text.Trim();
                objCreditCard.ResPhone = txtResPhone.Text.Trim();
                objCreditCard.ResMobile = txtResMob.Text.Trim();/*Adding by Chinu*/
                objCreditCard.OfficeName = txtOffName.Text.Trim();
                objCreditCard.OfficeAdd1 = txtOffAdd1.Text.Trim();
                objCreditCard.OfficeAdd2 = txtOffAdd2.Text.Trim();
                objCreditCard.OfficeAdd3 = txtOffAdd3.Text.Trim();
                objCreditCard.OfficeCity = txtOffCity.Text.Trim();
                objCreditCard.OfficePin = txtOffPin.Text.Trim();
                objCreditCard.OfficePhone = txtOffPhone.Text.Trim();
                objCreditCard.OfficeExtn = txtOffExtn.Text.Trim();
                objCreditCard.OfficeState = txtOffState.Text.Trim();
                objCreditCard.Designation = txtDesgn.Text.Trim();
                objCreditCard.Department = txtDept.Text.Trim();
                objCreditCard.Occupation = txtOccupation.Text.Trim();
                objCreditCard.Priority = txtOffPriority.Text.Trim();/* Adding by chinu(begin...)*/
                objCreditCard.Region = txtregion.Text.Trim();
                objCreditCard.SplInstruction = txtSplInst.Text.Trim();
                objCreditCard.PmtAdd1 = txtPmtAdd1.Text.Trim();
                objCreditCard.PmtAdd2 = txtPmtAdd2.Text.Trim();
                objCreditCard.PmtAdd3 = txtPmtAdd3.Text.Trim();
                objCreditCard.PmtCity = txtPmtCity.Text.Trim();
                objCreditCard.PmtState = txtPmtState.Text.Trim();
                objCreditCard.PmtPinCode = txtPmtpin.Text.Trim();
                objCreditCard.PmtLandMark = txtPmtLand.Text.Trim();
                objCreditCard.PmtPhone = txtPmtPhone.Text.Trim();
                /*--------------------------End-------------------------*/
                objCreditCard.AddedBy = Session["UserId"].ToString();
                objCreditCard.AddedOn = DateTime.Now;
                objCreditCard.ModifyBy = Session["UserId"].ToString();
                objCreditCard.ModifyOn = DateTime.Now;

                if (chkCaseVerification.Items.Count > 0)
                {
                    foreach (ListItem li in chkCaseVerification.Items)
                    {
                        if (li.Selected == true)
                        {
                            arrVerType.Add(li.Value);
                            sVerTypeCode += li.Text.Trim() + "+";
                        }
                    }
                }
                objCreditCard.VerificationCode = sVerTypeCode.TrimEnd('+');
                OleDbDataReader oledbRead;
                if (Context.Request.QueryString["CaseID"] != null && Context.Request.QueryString["CaseID"] != "")
                {
                    oledbRead = objCreditCard.GetCreditCase(Request.QueryString["CaseID"].ToString());
                    if (oledbRead.Read() == false)
                    {
                        if (objCreditCard.InsertCreditCardCaseEntry(arrVerType, Session["Prefix"].ToString()) == 1)
                        {
                            lblMsg.Visible = true;
                            lblMsg.Text = "Record added successfully.";
                            ClearControl();
                            if (Request.QueryString["CaseID"].ToString() == "Add")
                                iCount = 1;
                        }
                    }
                    else
                    {

                        if (objCreditCard.UpdateCreditCardCaseEntry(arrVerType, Request.QueryString["CaseID"].ToString()) == 1)
                        {
                            lblMsg.Visible = true;
                            lblMsg.Text = "Record updated successfully.";
                            ClearControl();
                            iCount = 1;
                        }
                    }
                    oledbRead.Close();
                }
                else
                {
                    if (objCreditCard.InsertCreditCardCaseEntry(arrVerType, Session["Prefix"].ToString()) == 1)
                    {
                        lblMsg.Visible = true;
                        lblMsg.Text = "Record added successfully.";
                        ClearControl();
                    }
                }

                sdsCreditCard.SelectCommand = objCreditCard.GetCreditCaseEntry(Session["CentreId"].ToString(), Session["ClientId"].ToString());
            }
        }
        catch (Exception ex)
        {
            lblMsg.Visible = true;
            lblMsg.Text = ex.Message.ToString();
        }

        if (iCount == 1)
            Response.Redirect("CC_CaseView.aspx?Msg=" + lblMsg.Text);
    }

    protected void gvCreditCard_RowCommand(object sender, GridViewCommandEventArgs e)
    {        
        lblMsg.Visible = false;

        if (e.CommandName == "Edit")
        {
            
        }
        if (e.CommandName == "DeleteCC")
        {
            if(objCreditCard.DeleteCreditCardCaseEntry(e.CommandArgument.ToString())==1)
            {
                lblMsg.Visible=true;
                lblMsg.Text="Record deleted successfully.";
            }
        }
        sdsCreditCard.SelectCommand = objCreditCard.GetCreditCaseEntry(Session["CentreId"].ToString(), Session["ClientId"].ToString());
    }

    protected void gvCreditCard_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            LinkButton l = (LinkButton)e.Row.FindControl("lnkDeleteCreditCard");
            l.Attributes.Add("onclick", "javascript:return " +
                          "confirm('Are you sure you want to delete this record')");
        }
    }


    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("CC_CaseView.aspx");
    }
}
