/*----------------------------------------------------------------------------------------
Scope of Program	:	
File Name			:	IDOC_IDOC_VerificationView
Create By			:	Hemangi Kambli
Create Date		    :	25th May 2007
Remarks 		    :	This class is used for view all IDOC Case entry.
						
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

public partial class IDOC_IDOC_VerificationView : System.Web.UI.Page
{
    
    CIDocVerification objIDocVer = new CIDocVerification();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["isView"].ToString() != "1")
            Response.Redirect("NoAccess.aspx");

        if (Session["CaseID"] != null)
        {
            if (txtCaseId.Text == "")
                txtCaseId.Text = Session["CaseID"].ToString();
        }

        lblMsg.Visible = false;
        txtCaseId.Focus();
        if (!IsPostBack)
        {
            if (Context.Request.QueryString["Msg"] != null && Context.Request.QueryString["Msg"] != "")
            {                
                lblMsg.ForeColor = System.Drawing.Color.Yellow;
                lblMsg.BackColor = System.Drawing.Color.Black;
                lblMsg.Font.Bold = true;
                lblMsg.Visible = true;
                lblMsg.Text = "&nbsp;" + Request.QueryString["Msg"].ToString();

                //if (objIDocVer.IsVerificationComplete(txtCaseId.Text.ToString()) == "true")
                //{
                //    objIDocVer.VerificationComplete(txtCaseId.Text.ToString());
                //    lblMsg.Text += " Case verification data entry completed.";
                //}
            }
            else
            {
                lblMsg.Text = "";
            }
        }
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        int blnN = 0;
        string sCaseId = txtCaseId.Text.Trim();
       
        string sClientId=Session["ClientId"].ToString();
        string sCentreId=Session["CentreId"].ToString();

        string sVerifyType = ddlVerifyType.SelectedValue.ToString();
        OleDbDataReader oledbRead;
        oledbRead = objIDocVer.GetVerificationDetail(sCaseId, sVerifyType, sClientId, sCentreId);
        ////for temporary use..to get case status id in IDOC verification form
        //Session["ProductId"] = "1017";
        /////
        OleDbDataReader oledbReadFEId;
        oledbReadFEId=objIDocVer.GetVerifierID(sCaseId, sVerifyType);
        if (oledbReadFEId.Read() == true)
        {
            hdnFEID.Value = oledbReadFEId["FE_ID"].ToString();
        }
        if (hdnFEID.Value.Trim() != "")
        {
            if (oledbRead.Read() == true)
            {
                switch (sVerifyType)
                {
                    case "6":   //ITR
                        Response.Redirect("IDOC_DV_ITR.aspx?CaseID=" + sCaseId + "&VerTypeId=" + sVerifyType);
                        break;
                    case "7":   //Bank Statement
                        Response.Redirect("IDOC_BankStatementVerification.aspx?CaseID=" + sCaseId + "&VerTypeId=" + sVerifyType);
                        break;
                    case "5":   //Salary Slip
                        Response.Redirect("IDOC_F16.aspx?CaseID=" + sCaseId + "&VerTypeId=" + sVerifyType);
                        break;
                    case "8":   //F16
                        Response.Redirect("IDOC_F16.aspx?CaseID=" + sCaseId + "&VerTypeId=" + sVerifyType);
                        break;
                    case "9":   //RC
                        Response.Redirect("IDOC_RCVerification.aspx?CaseID=" + sCaseId + "&VerTypeId=" + sVerifyType);
                        break;
                    case "11":   //Salary Certificate
                        Response.Redirect("IDOC_F16.aspx?CaseID=" + sCaseId + "&VerTypeId=" + sVerifyType);
                        break;
                }
            }
        }
        
        if (blnN == 0)
        {
            lblMsg.Visible = true;
            lblMsg.Text = "No record found.";
        }
        //END





        //else
        //{
        //    lblMsg.Visible = true;
        //    lblMsg.Text = "No record found.";
        //}
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
            lblMsg.Text = "Please select verification Type.";
        }
    }
}
