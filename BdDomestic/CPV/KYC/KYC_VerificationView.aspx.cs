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

public partial class KYC_KYC_VerificationView : System.Web.UI.Page
{
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
                CKYCVerification objKYC = new CKYCVerification();
                lblMsg.ForeColor = System.Drawing.Color.Yellow;
                lblMsg.BackColor = System.Drawing.Color.Black;
                lblMsg.Font.Bold = true;
                lblMsg.Visible = true;
                lblMsg.Text = "&nbsp;" + Request.QueryString["Msg"].ToString();

                
            }
            else
            {
                lblMsg.Text = "";
            }
        }
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        CKYCVerification objKYC = new CKYCVerification();
        
        int blnN = 0;
        string sCaseId = txtCaseId.Text.Trim();
        string sVerifyType = ddlVerifyType.SelectedValue.ToString();
        string sClientId = Session["ClientId"].ToString();
        string sCentreId = Session["CentreId"].ToString();

        OleDbDataReader oledbRead;
        oledbRead = objKYC.GetVerificationDetail(sCaseId, sVerifyType, sClientId, sCentreId);
        
        OleDbDataReader oledbReadFEId;
        oledbReadFEId = objKYC.GetVerifierID(sCaseId, sVerifyType);
        if (oledbReadFEId.Read() == true)
        {
            hdnFEID.Value = oledbReadFEId["FE_ID"].ToString();
        }
        if (hdnFEID.Value.Trim() != "")
        {
            if (oledbRead.Read() == true)
            {
                if (sVerifyType == "1")
                {
                    Response.Redirect("KYC_RV_VERI.aspx?CaseID=" + sCaseId + "&VerTypeId=" + sVerifyType);
                }
                if (sVerifyType == "2")
                {
                    Response.Redirect("KYC_BUSINESS_VERI.aspx?CaseID=" + sCaseId + "&VerTypeId=" + sVerifyType);
                }
                if (sVerifyType == "19")
                {
                    Response.Redirect("KYC_CA_VERI.aspx?CaseID=" + sCaseId + "&VerTypeId=" + sVerifyType);
                }
                blnN = 1;
            }
        }

        if (blnN == 0)
        {
            lblMsg.Visible = true;
            lblMsg.Text = "No record found.";
        }
        //END
        oledbRead.Close();
    }
}
