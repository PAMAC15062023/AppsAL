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

public partial class CPV_EBC_EBC_VerificationView : System.Web.UI.Page
{
    EBC_Verification OnjEBC = new EBC_Verification();
   
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

                //if (OnjEBC.IsVerificationComplete(txtCaseId.Text.ToString()) == "true")
                //{
                //    OnjEBC.VerificationComplete(txtCaseId.Text.ToString());
                //    lblMsg.Text += " Case verification data entry completed.";
                //}
            }
            else
            {
                lblMsg.Text = "";
                lblMsg.Visible = false;
            }
            //if (Context.Request.QueryString["Msg"] != null && Context.Request.QueryString["Msg"] != "")
            //{
            //    lblMsg.Visible = true;
            //    lblMsg.Text = Request.QueryString["Msg"].ToString();
            //}
            //else
            //{
            //    lblMsg.Text = "";
            //}
        }
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        int blnN = 0;
        string sCaseId = txtCaseId.Text.Trim();
        Session.Remove("CaseID");
        Session["CaseID"] = txtCaseId.Text.Trim();
       
        string sClientId = Session["ClientId"].ToString();
        string sCentreId = Session["CentreId"].ToString();

        OleDbDataReader oledbRead;
        oledbRead = OnjEBC.GetVerificationDetail(sCaseId, sClientId, sCentreId);

        OleDbDataReader oledbReadFEId;
        oledbReadFEId = OnjEBC.GetVerifierID(sCaseId );
        if (oledbReadFEId.Read() == true)
        {
            hdnFEID.Value = oledbReadFEId["FE_ID"].ToString();
        }
        if (hdnFEID.Value.Trim() != "")
        {
            if (oledbRead.Read() == true)
            {
               
                   
                        Response.Redirect("EBC_Verification.aspx?CaseID=" + sCaseId + " &VerifierId=" + hdnFEID.Value);
                        blnN = 1;
                
            }
        }
        if (blnN == 0)
        {
            lblMsg.Visible = true;
            lblMsg.ForeColor = System.Drawing.Color.Red;
            lblMsg.Text = "No record found.";
        }
        oledbReadFEId.Close();
        oledbRead.Close();
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
