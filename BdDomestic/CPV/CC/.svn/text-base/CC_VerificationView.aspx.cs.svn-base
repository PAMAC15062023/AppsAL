/*----------------------------------------------------------------------------------------
Scope of Program	:	
File Name			:	CC_CaseView.aspx.cs
Create By			:	Hemangi Kambli
Create Date		    :	25th April 2007
Remarks 		    :	This class is used for view all CreditCard Case entries.
						
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

public partial class CC_CC_VerificationView : System.Web.UI.Page
{
    CCreditCardVerification objCCVer = new CCreditCardVerification();
    protected void Page_Load(object sender, EventArgs e)
    {

        if (Session["CaseID"] != null )
        {
            if (txtCaseId.Text=="")
                txtCaseId.Text = Session["CaseID"].ToString();
        }
        
        if (!IsPostBack)
        {
            if (Session["isView"].ToString() != "1")
                Response.Redirect("NoAccess.aspx");

            

            lblMsg.Visible = false;
            txtCaseId.Focus();
            if (Context.Request.QueryString["Msg"] != null && Context.Request.QueryString["Msg"] != "")
            {
                lblMsg.ForeColor = System.Drawing.Color.Yellow;
                lblMsg.BackColor = System.Drawing.Color.Black;
                lblMsg.Font.Bold = true;
                lblMsg.Visible = true;
                lblMsg.Text = "&nbsp;" + Request.QueryString["Msg"].ToString();

                //if (objCCVer.IsVerificationComplete(txtCaseId.Text.ToString()) == "true")
                //{
                //    objCCVer.VerificationComplete(txtCaseId.Text.ToString());
                //    lblMsg.Text += " Case verification data entry completed.";
                //}
            }
            else
            {
                lblMsg.Text = "";
                lblMsg.Visible = false;
            }
        }
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        int blnN = 0;
        string sCaseId = txtCaseId.Text.Trim();
        Session.Remove("CaseID");
        Session["CaseID"] = txtCaseId.Text.Trim();
        string sVerifyType = ddlVerifyType.SelectedValue.ToString();
        OleDbDataReader oledbRead;
        oledbRead = objCCVer.GetVerificationDetail(sCaseId, sVerifyType, Session["ClientId"].ToString(), Session["CentreId"].ToString());
        if (oledbRead.Read() == true)
        {
            OleDbDataReader oledbReadFEId;
            oledbReadFEId = objCCVer.GetVerifierID(sCaseId, sVerifyType);
            if (oledbReadFEId.Read() == true)
            {
                hdnFEID.Value = oledbReadFEId["FE_ID"].ToString();
            }

            if (hdnFEID.Value.Trim() != "")
            {
                bool bISFe = false;
                string[] arrRoleId = (Session["RoleId"].ToString()).Split(',');
                //check whether user has morethan one role with role FE then treat as FE..
                if (arrRoleId.Length > 0)
                {
                    for (int i = 0; i < arrRoleId.Length; i++)
                    {
                        if (bISFe == false)
                        {
                            if (arrRoleId[i].ToString() == "3")
                                bISFe = true;
                        }
                    }
                }
                if (bISFe == true)      //If logged in person is FE.
                {
                    OleDbDataReader oledbReadFE = objCCVer.GetFERecords(sCaseId, sVerifyType, Session["UserId"].ToString());
                    if (oledbReadFE.Read() == true)
                    {
                        sVerifyType = oledbReadFE["verification_type_id"].ToString();

                        switch (sVerifyType)
                        {
                            case "1":
                                Response.Redirect("CC_ResidenceVerification.aspx?CaseID=" + sCaseId + "&VerTypeId=" + sVerifyType + "&VerifierId=" + hdnFEID.Value);
                                blnN = 1;
                                break;
                            case "10":
                                Response.Redirect("CC_ResidenceVerification.aspx?CaseID=" + sCaseId + "&VerTypeId=" + sVerifyType + "&VerifierId=" + hdnFEID.Value);
                                blnN = 1;
                                break;
                            case "2":
                                Response.Redirect("CC_BusinessVerification.aspx?CaseID=" + sCaseId + "&VerTypeId=" + sVerifyType + "&VerifierId=" + hdnFEID.Value);
                                blnN = 1;
                                break;
                        }
                    }
                    oledbReadFE.Close();
                }
                else            //If logged in person is other than FE.
                {
                    switch (sVerifyType)
                    {
                        case "1":   //for RV
                            //if (oledbRead.Read() == true)
                            //{
                            Response.Redirect("CC_ResidenceVerification.aspx?CaseID=" + sCaseId + "&VerTypeId=" + sVerifyType + "&VerifierId=" + hdnFEID.Value);
                            blnN = 1;
                            //}
                            break;
                        case "10":  //for PRV
                            //if (oledbRead.Read() == true)
                            //{
                            Response.Redirect("CC_ResidenceVerification.aspx?CaseID=" + sCaseId + "&VerTypeId=" + sVerifyType + "&VerifierId=" + hdnFEID.Value);
                            blnN = 1;
                            //}
                            break;
                        case "2":   //for BV
                            //if (oledbRead.Read() == true)
                            //{
                            Response.Redirect("CC_BusinessVerification.aspx?CaseID=" + sCaseId + "&VerTypeId=" + sVerifyType + "&VerifierId=" + hdnFEID.Value);
                            blnN = 1;
                            //}
                            break;
                    }
                }
            }
            //Add by manoj to get the RT BT
            else
            {
                if (sVerifyType == "3")
                {
                    //if (oledbRead.Read() == true)
                    //{
                    Response.Redirect("CC_BusinessVerificationTelephonic.aspx?CaseID=" + sCaseId + "&VerTypeId=" + sVerifyType);
                    blnN = 1;
                    //}
                }
                else if (sVerifyType == "4")
                {
                    //if (oledbRead.Read() == true)
                    //{
                    Response.Redirect("CC_ResidenceVerificationTelephonic.aspx?CaseID=" + sCaseId + "&VerTypeId=" + sVerifyType);
                    blnN = 1;
                    //}
                }
            }
            //END
            //else
            //{
            //    lblMsg.Visible = true;
            //    lblMsg.Text = "No record found.";
            //}
            oledbReadFEId.Close();
        }
        else
        {
            if (blnN == 0)
            {
                lblMsg.Visible = true;
                lblMsg.ForeColor = System.Drawing.Color.Red;
                lblMsg.Text = "Record not found.";
            }
        }
        oledbRead.Close();
       
    }
    protected void ddlVerifyType_DataBound(object sender, EventArgs e)
    {
        //ddlVerifyType.Items.Insert(0, new ListItem("Select", "0"));
    }

    protected void cvSelectVerifyType_ServerValidate(object source, ServerValidateEventArgs args)
    {
        if (source.ToString() == "0")
        {
            lblMsg.Visible = true;
            lblMsg.ForeColor = System.Drawing.Color.Red;
            lblMsg.Text = "Please select verification Type.";
        }
    }

}
