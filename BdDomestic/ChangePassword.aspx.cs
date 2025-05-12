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

public partial class ChangePassword : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            if (Request.QueryString["Err"] != null)
            {
                lblMsg.Visible = true;
                lblMsg.CssClass = "ErrorMessage";
                lblMsg.Text = Request.QueryString["Err"].ToString();
                btnLogin.Visible = true;
                btnCancel.Visible = false;
            }
            else
            {
                btnLogin.Visible =false ;
                btnCancel.Visible = true;
            }
        }

        
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            CChangePwd objChange = new CChangePwd();
            objChange.NewPwd = txtNewPwd.Text;
            objChange.OldPwd = txtOldPwd.Text;
            objChange.UserId = Session["UserId"].ToString();
            objChange.UserAuthenticate();
            if (objChange.Status == "1")
            {
                lblMsg.Visible = true;
                lblMsg.CssClass = "UpdateMessage";
                lblMsg.Text = "Password has been reset,Please login Again!";
                btnCancel.Visible = false;
                btnLogin.Visible = true;
                txtNewPwd.ReadOnly = true;
                txtOldPwd.ReadOnly = true;
                txtConfirmPwd.ReadOnly = true;
                btnSave.Enabled = false;
            }
            else
            {
                lblMsg.Visible = true;
                lblMsg.CssClass = "ErrorMessage";
                lblMsg.Text = "Wrong Old Password";
            }
                

        }
        catch (Exception exp)
        {
            lblMsg.Visible = true;
            lblMsg.CssClass = "ErrorMessage";
            lblMsg.Text = exp.Message;
        }
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("OrganizationTree.aspx");
        
    }
    protected void btnLogin_Click(object sender, EventArgs e)
    {
        Response.Redirect("Default.aspx");
    }
}
