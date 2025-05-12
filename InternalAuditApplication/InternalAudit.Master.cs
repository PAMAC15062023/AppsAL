using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace InternalAuditApplication
{
    public partial class InternalAudit : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["UserName"] != null)
                {
                    lblWelcome.Text = "Internal Audit Application";

                    lblUserName.Text = Convert.ToString(Session["UserName"]);

                    /*if (Session["RoleID"] != null)
                    {
                        string RoleID = Convert.ToString(Session["RoleID"]);
                        string currentPageName = Request.Url.Segments[Request.Url.Segments.Length - 1];
                        RolePageAuth rpa = new RolePageAuth();
                        bool result = rpa.CheckRolePageAuth(RoleID, currentPageName.Trim());

                        if (!result)
                        {
                            Response.Redirect("MFEDL_AuthorizeFailed.aspx", false);
                        }
                    }*/
                }
                else
                {
                    Session.Clear();
                    Response.Redirect("Login.aspx", false);
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }

        protected void lnkLogOut_Click(object sender, EventArgs e)
        {
            try
            {
                if (Session["UserName"] != null)
                {
                    CommonMaster commonMaster = new CommonMaster();
                    int Result = commonMaster.UserLogOut(Convert.ToString(Session["UserID"]));

                    if (Result == 1)
                    {
                        Session.Clear();
                        Response.Redirect("Login.aspx", false);
                    }
                }
                else
                {
                    Session.Clear();
                    Response.Redirect("Login.aspx", false);
                }
            }
            catch (Exception ex)
            {

            }
        }
        protected void lnkChangePassword_Click(object sender, EventArgs e)
        {
            Response.Redirect("ChangePassword.aspx", false);
        }
    }
}