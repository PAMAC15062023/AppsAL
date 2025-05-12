using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using YesBank;

namespace ChangeManagement
{
    public partial class CM_MenuPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                Object SaveUSERInfo = (Object)Session["UserInfo"];

                if (Session["UserInfo"] == null)
                {
                    Response.Redirect("CM_Login.aspx", true);



                    if (Session["RoleId"] != null)
                    {
                        string RoleID = Convert.ToString(Session["RoleId"]);
                        string currentPageName = Request.Url.Segments[Request.Url.Segments.Length - 1];
                        RolePageAuth rpa = new RolePageAuth();
                        bool result = rpa.CheckRolePageAuth(RoleID, currentPageName.Trim());

                        if (!result)
                        {
                            Response.Redirect("Login.aspx", false);
                        }
                    }
                }
                else
                {
                    if (!IsPostBack)
                    {
                        CR_Initiation.Visible = false;
                        VH_Approval.Visible = false;
                        Reviewer.Visible = false;
                        int RoleID = Convert.ToInt32(Session["RoleId"]);
                        if (RoleID == 1)
                        {
                            CR_Initiation.Visible = true;
                            VH_Approval.Visible = false;
                            Reviewer.Visible = false;
                            DevelopmentActivities.Visible = false;
                            ProductManager.Visible = false;
                            Supervisor.Visible = false;
                        }
                        else if (RoleID == 2)
                        {
                            CR_Initiation.Visible = false;
                            VH_Approval.Visible = true;
                            Reviewer.Visible = false;
                            DevelopmentActivities.Visible = false;
                            ProductManager.Visible = false;
                            Supervisor.Visible = false;
                        }
                        else if (RoleID == 3)
                        {
                            CR_Initiation.Visible = false;
                            VH_Approval.Visible = false;
                            Reviewer.Visible = true;
                            DevelopmentActivities.Visible = false;
                            ProductManager.Visible = false;
                            Supervisor.Visible = false;
                        }
                        else if(RoleID == 4)
                        {
                            CR_Initiation.Visible = false;
                            VH_Approval.Visible = false;
                            Reviewer.Visible = false;
                            DevelopmentActivities.Visible = true;
                            ProductManager.Visible = false;
                            Supervisor.Visible = false;
                        }
                        else if(RoleID == 5)
                        {
                            CR_Initiation.Visible = false;
                            VH_Approval.Visible = false;
                            Reviewer.Visible = false;
                            DevelopmentActivities.Visible = false;
                            ProductManager.Visible = true;
                            Supervisor.Visible = false;
                        }
                        else if (RoleID == 6)
                        {
                            CR_Initiation.Visible = false;
                            VH_Approval.Visible = false;
                            Reviewer.Visible = false;
                            DevelopmentActivities.Visible = false;
                            ProductManager.Visible = false;
                            Supervisor.Visible = true;
                        }
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