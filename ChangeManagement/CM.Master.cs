using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using YesBank;

namespace ChangeManagement
{
    public partial class CM : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserInfo"] == null)
            {
                Response.Redirect("CM_InvalidRequest.aspx", false);
                return;
            }
            try
            {
                Object SaveUSERInfo = (Object)Session["UserInfo"];

                if (Session["UserInfo"] == null)
                {
                    Response.Redirect("CM_InvalidRequest.aspx", true);
                    return;
                }
                else
                {
                    if (!IsPostBack)
                    {
                        lblWelcome.Text = "Change Management";

                        string UserName = Convert.ToString(((UserInfo.structUSERInfo)(SaveUSERInfo)).UserName);
                        lblUserName.Text = UserName;
                    }
                }
                if (Session["RoleId"] != null)
                {
                    string RoleID = Convert.ToString(Session["RoleId"]);
                    string currentPageName = Request.Url.Segments[Request.Url.Segments.Length - 1];
                    RolePageAuth rpa = new RolePageAuth();
                    bool result = rpa.CheckRolePageAuth(RoleID, currentPageName.Trim());

                    if (!result)
                    {
                        Response.Redirect("CM_AuthorizeFailed.aspx", false);
                    }
                }
            }
            catch
            {

            }
        }

        protected void lnkChangePassword_Click(object sender, EventArgs e)
        {
            Response.Redirect("CM_ChangePassword.aspx", false);
        }

        protected void lnkLogOut_Click(object sender, EventArgs e)
        {
            try
            {
                if (Session["UserName"] != null)
                {
                    Object SaveUSERInfo = (Object)Session["UserInfo"];
                    CommonMaster commonMaster = new CommonMaster();
                    int Result = commonMaster.UserLogOut(Convert.ToString(((UserInfo.structUSERInfo)(SaveUSERInfo)).UserID));

                    if (Result == 1)
                    {
                        Session.Clear();
                        Response.Redirect("CM_Login.aspx", false);
                    }
                }
                else
                {
                    Session.Clear();
                    Response.Redirect("CM_Login.aspx", false);
                }
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
            }
        }
    }
}