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

public partial class CPV_RL_RL_CaseEntry : System.Web.UI.Page
{
    CRL_CaseEntry objRL = new CRL_CaseEntry();
    DataSet dsRL = new DataSet();
    DataSet dsVerification = new DataSet();
    protected void Page_Load(object sender, EventArgs e)
    {
      
        if (!IsPostBack)
        {
            if (Session["isAdd"].ToString() != "1")
                Response.Redirect("NoAccess.aspx");
            //string sActivityID = "1011";
            string sActivityID = Session["ActivityId"].ToString();
            chkCaseVerification.DataSource = objRL.GetCaseVerificationType(sActivityID);
            chkCaseVerification.DataValueField = "Verification_type_Id";
            chkCaseVerification.DataTextField = "Verification_type_code";
            chkCaseVerification.DataBind();

            ddCaseType.Focus();
            txtRecDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
            txtRecTime.Text = DateTime.Now.ToString("hh:mm");
            if (Context.Request.QueryString["CaseID"] != null && Context.Request.QueryString["CaseID"] != "")
            {
                if (Session["isEdit"].ToString() != "1")
                    Response.Redirect("NoAccess.aspx");
                txtRefNo.ReadOnly = true;
                string sCaseId = Request.QueryString["CaseID"].ToString();
                if (sCaseId != "")
                {
                    dsRL = objRL.GetRLCaseEntry(sCaseId, Session["CentreId"].ToString(), Session["ClientId"].ToString());
                    dsVerification = objRL.GetAllVerificationId(sCaseId);

                    if (dsRL.Tables[0].Rows.Count > 0)
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
                        string sTmp = dsRL.Tables[0].Rows[0]["CASE_REC_DATETime"].ToString();
                        if (sTmp != "")
                        {
                            string[] arrRecDateTime = sTmp.Split(' ');
                            if (arrRecDateTime[0].ToString() != "")
                                txtRecDate.Text = Convert.ToDateTime(arrRecDateTime[0].ToString()).ToString("dd/MM/yyyy");
                            if (arrRecDateTime[1].ToString() != "")
                                txtRecTime.Text = Convert.ToDateTime(arrRecDateTime[1].ToString()).ToString("hh:mm");

                            ddlTimeType.SelectedValue = arrRecDateTime[2].ToString();
                        }
                        ddCaseType.Text = dsRL.Tables[0].Rows[0]["CASE_TYPE"].ToString();
                        txtRefNo.Text = dsRL.Tables[0].Rows[0]["Ref_No"].ToString();
                        txtTitle.Text = dsRL.Tables[0].Rows[0]["Title"].ToString();
                        txtFirstNm.Text = dsRL.Tables[0].Rows[0]["First_Name"].ToString();
                        txtMiddleNm.Text = dsRL.Tables[0].Rows[0]["Middle_Name"].ToString();
                        txtLastNm.Text = dsRL.Tables[0].Rows[0]["Last_Name"].ToString();
                        if (dsRL.Tables[0].Rows[0]["DOB"].ToString() != "")
                            txtDOB.Text = dsRL.Tables[0].Rows[0]["DOB"].ToString();
                        txtResAdd1.Text = dsRL.Tables[0].Rows[0]["RES_ADD_LINE_1"].ToString();
                        txtResAdd2.Text = dsRL.Tables[0].Rows[0]["RES_ADD_LINE_2"].ToString();
                        txtResAdd3.Text = dsRL.Tables[0].Rows[0]["RES_ADD_LINE_3"].ToString();
                        txtResCity.Text = dsRL.Tables[0].Rows[0]["RES_CITY"].ToString();
                       
                        txtResPin.Text = dsRL.Tables[0].Rows[0]["RES_PIN_CODE"].ToString();
                        txtLandMark.Text = dsRL.Tables[0].Rows[0]["RES_LAND_MARK"].ToString();
                        txtResPhone.Text = dsRL.Tables[0].Rows[0]["RES_PHONE"].ToString();
                        txtResMob.Text = dsRL.Tables[0].Rows[0]["MOBILE"].ToString();
                        txtOffName.Text = dsRL.Tables[0].Rows[0]["OFF_NAME"].ToString();
                        txtOffAdd1.Text = dsRL.Tables[0].Rows[0]["OFF_ADD_LINE_1"].ToString();
                        txtOffAdd2.Text = dsRL.Tables[0].Rows[0]["OFF_ADD_LINE_2"].ToString();
                        txtOffAdd3.Text = dsRL.Tables[0].Rows[0]["OFF_ADD_LINE_3"].ToString();
                        txtOffCity.Text = dsRL.Tables[0].Rows[0]["OFF_CITY"].ToString();
                        txtOffPhone.Text = dsRL.Tables[0].Rows[0]["OFF_PHONE"].ToString();
                        txtOffExtn.Text = dsRL.Tables[0].Rows[0]["OFF_EXTN"].ToString();
                       
                        txtOffPin.Text = dsRL.Tables[0].Rows[0]["OFF_PIN_CODE"].ToString();
                        txtDesgn.Text = dsRL.Tables[0].Rows[0]["DESIGNATION"].ToString();
                        txtDept.Text = dsRL.Tables[0].Rows[0]["DEPARTMENT"].ToString();
                        txtOccupation.Text = dsRL.Tables[0].Rows[0]["OCCUPATION"].ToString();
                        txtOffPriority.Text = dsRL.Tables[0].Rows[0]["PRIORITY"].ToString();
                        txtregion.Text = dsRL.Tables[0].Rows[0]["REGION"].ToString();
                        txtSplInst.Text = dsRL.Tables[0].Rows[0]["SPL_INSTRUCTION"].ToString();
                        txtProductTyoe.Text = dsRL.Tables[0].Rows[0]["PRODUCT_TYPE"].ToString();
                        txtProductName.Text = dsRL.Tables[0].Rows[0]["PRODUCT_NAME"].ToString();
                        txtProducPrice.Text = dsRL.Tables[0].Rows[0]["PRODUCT_PRICE"].ToString();
                        ddlEmpType.SelectedValue = dsRL.Tables[0].Rows[0]["EMPLOYEE_TYPE"].ToString();
                        txtRef1.Text = dsRL.Tables[0].Rows[0]["REFERENCE1"].ToString();
                        txtRef2.Text = dsRL.Tables[0].Rows[0]["REFERENCE2"].ToString();
                        txtTel1.Text = dsRL.Tables[0].Rows[0]["REFERENCE1_TEL"].ToString();
                        txtTel2.Text = dsRL.Tables[0].Rows[0]["REFERENCE2_TEL"].ToString();
                        txtChannelName.Text = dsRL.Tables[0].Rows[0]["channel_name"].ToString();
                    }
                }
            }
        }
       
    }
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
        
        txtProducPrice.Text = "";
        txtProductName.Text = "";
        txtRef1.Text = "";
        txtRef2.Text = "";
        txtTel1.Text = "";
        txtTel2.Text = "";
        txtProductTyoe.Text = "";
        txtChannelName.Text = "";
    }

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
                    objRL.DOB = txtDOB.Text.Trim();
                if (txtRecDate.Text.Trim() != "" && txtRecTime.Text.Trim() != "")
                    objRL.ReceivedDateTime = Convert.ToDateTime(objCmn.strDate(txtRecDate.Text.Trim()) + " " + txtRecTime.Text.Trim() + " " + ddlTimeType.SelectedItem.Text.Trim());

                objRL.CentreId = Session["CentreId"].ToString();
                objRL.ClusterId = Session["ClusterId"].ToString();
                objRL.ClientId = Session["ClientId"].ToString();
                objRL.CaseType = ddCaseType.SelectedItem.Text.Trim();
                objRL.RefNo = txtRefNo.Text.Trim();
                objRL.Title = txtTitle.Text.Trim();
                objRL.FirstName = txtFirstNm.Text.Trim();
                objRL.MiddleName = txtMiddleNm.Text.Trim();
                objRL.LastName = txtLastNm.Text.Trim();
                objRL.FullName = txtFirstNm.Text.Trim() + " " + txtMiddleNm.Text.Trim() + " " + txtLastNm.Text.Trim();
                objRL.ResAdd1 = txtResAdd1.Text.Trim();
                objRL.ResAdd2 = txtResAdd2.Text.Trim();
                objRL.ResAdd3 = txtResAdd3.Text.Trim();
                objRL.ResCity = txtResCity.Text.Trim();
            
                objRL.ResPin = txtResPin.Text.Trim();
                objRL.ResLandMark = txtLandMark.Text.Trim();
                objRL.ResPhone = txtResPhone.Text.Trim();
                objRL.ResMobile = txtResMob.Text.Trim();
                objRL.OfficeName = txtOffName.Text.Trim();
                objRL.OfficeAdd1 = txtOffAdd1.Text.Trim();
                objRL.OfficeAdd2 = txtOffAdd2.Text.Trim();
                objRL.OfficeAdd3 = txtOffAdd3.Text.Trim();
                objRL.OfficeCity = txtOffCity.Text.Trim();
                objRL.OfficePin = txtOffPin.Text.Trim();
                objRL.OfficePhone = txtOffPhone.Text.Trim();
                objRL.OfficeExtn = txtOffExtn.Text.Trim();
                objRL.EmployeeType = ddlEmpType.SelectedValue;
                objRL.ProductName = txtProductName.Text.Trim();
                objRL.ProductPrice = txtProducPrice.Text.Trim();
                objRL.ProductType = txtProductTyoe.Text.Trim();
                objRL.Designation = txtDesgn.Text.Trim();
                objRL.Department = txtDept.Text.Trim();
                objRL.Occupation = txtOccupation.Text.Trim();
                objRL.Priority = txtOffPriority.Text.Trim();
                objRL.Region = txtregion.Text.Trim();
                objRL.SplInstruction = txtSplInst.Text.Trim();
               
                objRL.Reference1 = txtRef1.Text.Trim();
                objRL.Reference2 = txtRef2.Text.Trim();
                objRL.Telephone1 = txtTel1.Text.Trim();
                objRL.Telephone2 = txtTel2.Text.Trim();
                objRL.ChannelName = txtChannelName.Text.Trim();

                /*--------------------------End-------------------------*/
                objRL.AddedBy = Session["UserId"].ToString();
                objRL.AddedOn = DateTime.Now;
                objRL.ModifyBy = Session["UserId"].ToString();
                objRL.ModifyOn = DateTime.Now;

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
                objRL.VerificationCode = sVerTypeCode.TrimEnd('+');
                OleDbDataReader oledbRead;
                if (Context.Request.QueryString["CaseID"] != null && Context.Request.QueryString["CaseID"] != "")
                {
                    oledbRead = objRL.GetRLCase(Request.QueryString["CaseID"].ToString());
                    if (oledbRead.Read() == false)
                    {
                        if (objRL.InsertRLCaseEntry(arrVerType, Session["Prefix"].ToString()) == 1)
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

                        if (objRL.UpdateRLCaseEntry(arrVerType, Request.QueryString["CaseID"].ToString()) == 1)
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
                    if (objRL.InsertRLCaseEntry(arrVerType, Session["Prefix"].ToString()) == 1)
                    {
                        lblMsg.Visible = true;
                        lblMsg.Text = "Record added successfully.";
                        ClearControl();
                    }
                }

                sdsRL.SelectCommand = objRL.GetRLCaseEntry(Session["CentreId"].ToString(), Session["ClientId"].ToString());
            }
        }
        catch (Exception ex)
        {
            lblMsg.Visible = true;
            lblMsg.Text = ex.Message.ToString();
        }

        if (iCount == 1)
            Response.Redirect("RL_ViewCase.aspx?Msg=" + lblMsg.Text);
    }
    protected void gvRL_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        lblMsg.Visible = false;

        if (e.CommandName == "Edit")
        {

        }
        if (e.CommandName == "DeleteCC")
        {
            if (objRL.DeleteRLCaseEntry(e.CommandArgument.ToString()) == 1)
            {
                lblMsg.Visible = true;
                lblMsg.Text = "Record deleted successfully.";
            }
        }
        sdsRL.SelectCommand = objRL.GetRLCaseEntry(Session["CentreId"].ToString(), Session["ClientId"].ToString());
    }

    protected void gvRL_RowDataBound(object sender, GridViewRowEventArgs e)
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
        Response.Redirect("RL_ViewCase.aspx");
    }
}
