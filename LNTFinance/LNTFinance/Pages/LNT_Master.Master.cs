using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LNTFinance.Pages
{
    public partial class LNT_User : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                Object SaveUSERInfo = (Object)Session["UserInfo"];

                if (Session["UserInfo"] == null)
                {
                    Session.Clear();
                    Response.Redirect("../LoginPage.aspx", false);
                }
                else
                {
                    if (!IsPostBack)
                    {
                        //lblWelcome.Text = "LNT Finance";

                        string UserName = Convert.ToString(((UserInfo.structUSERInfo)(SaveUSERInfo)).UserName);
                        string ClientID = Convert.ToString(((UserInfo.structUSERInfo)(SaveUSERInfo)).ClientID);
                        int role = Convert.ToInt32(((UserInfo.structUSERInfo)(SaveUSERInfo)).RoleId);
                        string ClientName = Convert.ToString(((UserInfo.structUSERInfo)(SaveUSERInfo)).ClientName);
                        string UserId = Convert.ToString(((UserInfo.structUSERInfo)(SaveUSERInfo)).LoginName);

                        lblWelcome.Text = ClientName;

                        if (role == 1 && ClientID == "LNT")
                        {
                            LNT_AdminMenu.Visible = true;
                            LNT_UserMenu.Visible = false;
                            LNT_SupervisorMenu.Visible = true;
                            CLL_UserMenu.Visible = false;
                            CLL_Admin.Visible = false;
                            CLL_Supervisor.Visible = false;
                            LFTSTL_UserMenu.Visible = false;
                            LFTSTL_Admin.Visible = false;
                            LFTSTL_Supervisor.Visible = false;
                            IP_UserMenu.Visible = false;
                            IP_Admin.Visible = false;
                            IP_Supervisor.Visible = false;
                            PMS_Admin.Visible = false;
                            FL_UserManu.Visible = false;
                            FL_Admin.Visible = false;
                            FL_Supervisor.Visible = false;
                        }
                        else if (role == 2 && ClientID == "LNT")
                        {
                            LNT_SupervisorMenu.Visible = true;
                            LNT_UserMenu.Visible = false;
                            LNT_AdminMenu.Visible = false;
                            CLL_UserMenu.Visible = false;
                            CLL_Admin.Visible = false;
                            CLL_Supervisor.Visible = false;
                            LFTSTL_UserMenu.Visible = false;
                            LFTSTL_Admin.Visible = false;
                            LFTSTL_Supervisor.Visible = false;
                            IP_UserMenu.Visible = false;
                            IP_Admin.Visible = false;
                            IP_Supervisor.Visible = false;
                            PMS_Admin.Visible = false;
                            FL_UserManu.Visible = false;
                            FL_Admin.Visible = false;
                            FL_Supervisor.Visible = false;
                        }
                        else if (role == 3 && ClientID == "LNT")
                        {
                            LNT_UserMenu.Visible = true;
                            LNT_AdminMenu.Visible = false;
                            LNT_SupervisorMenu.Visible = false;
                            CLL_UserMenu.Visible = false;
                            CLL_Admin.Visible = false;
                            CLL_Supervisor.Visible = false;
                            LFTSTL_UserMenu.Visible = false;
                            LFTSTL_Admin.Visible = false;
                            LFTSTL_Supervisor.Visible = false;
                            IP_UserMenu.Visible = false;
                            IP_Admin.Visible = false;
                            IP_Supervisor.Visible = false;
                            PMS_Admin.Visible = false;
                            FL_UserManu.Visible = false;
                            FL_Admin.Visible = false;
                            FL_Supervisor.Visible = false;
                        }
                        else if (role == 1 && ClientID == "CLL")
                        {
                            CLL_Admin.Visible = true;
                            CLL_UserMenu.Visible = false;
                            CLL_Supervisor.Visible = true;
                            LNT_UserMenu.Visible = false;
                            LNT_AdminMenu.Visible = false;
                            LNT_SupervisorMenu.Visible = false;
                            LFTSTL_UserMenu.Visible = false;
                            LFTSTL_Admin.Visible = false;
                            LFTSTL_Supervisor.Visible = false;
                            IP_UserMenu.Visible = false;
                            IP_Admin.Visible = false;
                            IP_Supervisor.Visible = false;
                            PMS_Admin.Visible = false;
                            FL_UserManu.Visible = false;
                            FL_Admin.Visible = false;
                            FL_Supervisor.Visible = false;
                        }
                        else if (role == 2 && ClientID == "CLL")
                        {
                            CLL_Supervisor.Visible = true;
                            CLL_UserMenu.Visible = false;
                            CLL_Admin.Visible = false;
                            LNT_UserMenu.Visible = false;
                            LNT_AdminMenu.Visible = false;
                            LNT_SupervisorMenu.Visible = false;
                            LFTSTL_UserMenu.Visible = false;
                            LFTSTL_Admin.Visible = false;
                            LFTSTL_Supervisor.Visible = false;
                            IP_UserMenu.Visible = false;
                            IP_Admin.Visible = false;
                            IP_Supervisor.Visible = false;
                            PMS_Admin.Visible = false;
                            FL_UserManu.Visible = false;
                            FL_Admin.Visible = false;
                            FL_Supervisor.Visible = false;
                        }
                        else if (role == 3 && ClientID == "CLL")
                        {
                            CLL_UserMenu.Visible = true;
                            CLL_Admin.Visible = false;
                            CLL_Supervisor.Visible = false;
                            LNT_UserMenu.Visible = false;
                            LNT_AdminMenu.Visible = false;
                            LNT_SupervisorMenu.Visible = false;
                            LFTSTL_UserMenu.Visible = false;
                            LFTSTL_Admin.Visible = false;
                            LFTSTL_Supervisor.Visible = false;
                            IP_UserMenu.Visible = false;
                            IP_Admin.Visible = false;
                            IP_Supervisor.Visible = false;
                            PMS_Admin.Visible = false;
                            FL_UserManu.Visible = false;
                            FL_Admin.Visible = false;
                            FL_Supervisor.Visible = false;
                        }
                        else if (role == 1 && ClientID == "TWI")
                        {
                            LFTSTL_UserMenu.Visible = false;
                            LFTSTL_Admin.Visible = true;
                            LFTSTL_Supervisor.Visible = true;
                            LNT_UserMenu.Visible = false;
                            LNT_AdminMenu.Visible = false;
                            LNT_SupervisorMenu.Visible = false;
                            CLL_UserMenu.Visible = false;
                            CLL_Admin.Visible = false;
                            CLL_Supervisor.Visible = false;
                            IP_UserMenu.Visible = false;
                            IP_Admin.Visible = false;
                            IP_Supervisor.Visible = false;
                            PMS_Admin.Visible = false;
                            FL_UserManu.Visible = false;
                            FL_Admin.Visible = false;
                            FL_Supervisor.Visible = false;
                        }
                        else if (role == 2 && ClientID == "TWI")
                        {
                            LFTSTL_UserMenu.Visible = false;
                            LFTSTL_Admin.Visible = false;
                            LFTSTL_Supervisor.Visible = true;
                            LNT_UserMenu.Visible = false;
                            LNT_AdminMenu.Visible = false;
                            LNT_SupervisorMenu.Visible = false;
                            CLL_UserMenu.Visible = false;
                            CLL_Admin.Visible = false;
                            CLL_Supervisor.Visible = false;
                            IP_UserMenu.Visible = false;
                            IP_Admin.Visible = false;
                            IP_Supervisor.Visible = false;
                            PMS_Admin.Visible = false;
                            FL_UserManu.Visible = false;
                            FL_Admin.Visible = false;
                            FL_Supervisor.Visible = false;
                        }
                        else if (role == 3 && ClientID == "TWI")
                        {
                            LFTSTL_UserMenu.Visible = true;
                            LFTSTL_Admin.Visible = false;
                            LFTSTL_Supervisor.Visible = false;
                            LNT_UserMenu.Visible = false;
                            LNT_AdminMenu.Visible = false;
                            LNT_SupervisorMenu.Visible = false;
                            CLL_UserMenu.Visible = false;
                            CLL_Admin.Visible = false;
                            CLL_Supervisor.Visible = false;
                            IP_UserMenu.Visible = false;
                            IP_Admin.Visible = false;
                            IP_Supervisor.Visible = false;
                            PMS_Admin.Visible = false;
                            FL_UserManu.Visible = false;
                            FL_Admin.Visible = false;
                            FL_Supervisor.Visible = false;
                        }
                        else if (role == 1 && ClientID == "IP")
                        {
                            IP_UserMenu.Visible = false;
                            IP_Admin.Visible = true;
                            IP_Supervisor.Visible = true;
                            LNT_UserMenu.Visible = false;
                            LNT_AdminMenu.Visible = false;
                            LNT_SupervisorMenu.Visible = false;
                            CLL_UserMenu.Visible = false;
                            CLL_Admin.Visible = false;
                            CLL_Supervisor.Visible = false;
                            LFTSTL_UserMenu.Visible = false;
                            LFTSTL_Admin.Visible = false;
                            LFTSTL_Supervisor.Visible = false;
                            PMS_Admin.Visible = false;
                            FL_UserManu.Visible = false;
                            FL_Admin.Visible = false;
                            FL_Supervisor.Visible = false;
                        }
                        else if (role == 2 && ClientID == "IP")
                        {
                            IP_UserMenu.Visible = false;
                            IP_Admin.Visible = false;
                            IP_Supervisor.Visible = true;
                            LNT_UserMenu.Visible = false;
                            LNT_AdminMenu.Visible = false;
                            LNT_SupervisorMenu.Visible = false;
                            CLL_UserMenu.Visible = false;
                            CLL_Admin.Visible = false;
                            CLL_Supervisor.Visible = false;
                            LFTSTL_UserMenu.Visible = false;
                            LFTSTL_Admin.Visible = false;
                            LFTSTL_Supervisor.Visible = false;
                            PMS_Admin.Visible = false;
                            FL_UserManu.Visible = false;
                            FL_Admin.Visible = false;
                            FL_Supervisor.Visible = false;
                        }
                        else if (role == 3 && ClientID == "IP")
                        {
                            IP_UserMenu.Visible = true;
                            IP_Admin.Visible = false;
                            IP_Supervisor.Visible = false;
                            LNT_UserMenu.Visible = false;
                            LNT_AdminMenu.Visible = false;
                            LNT_SupervisorMenu.Visible = false;
                            CLL_UserMenu.Visible = false;
                            CLL_Admin.Visible = false;
                            CLL_Supervisor.Visible = false;
                            LFTSTL_UserMenu.Visible = false;
                            LFTSTL_Admin.Visible = false;
                            LFTSTL_Supervisor.Visible = false;
                            PMS_Admin.Visible = false;
                            FL_UserManu.Visible = false;
                            FL_Admin.Visible = false;
                            FL_Supervisor.Visible = false;
                        }
                        if (role == 1 && ClientID == "FL")
                        {
                            LNT_AdminMenu.Visible = false;
                            LNT_UserMenu.Visible = false;
                            LNT_SupervisorMenu.Visible = false;
                            CLL_UserMenu.Visible = false;
                            CLL_Admin.Visible = false;
                            CLL_Supervisor.Visible = false;
                            LFTSTL_UserMenu.Visible = false;
                            LFTSTL_Admin.Visible = false;
                            LFTSTL_Supervisor.Visible = false;
                            IP_UserMenu.Visible = false;
                            IP_Admin.Visible = false;
                            IP_Supervisor.Visible = false;
                            PMS_Admin.Visible = false;
                            FL_UserManu.Visible = false;
                            FL_Admin.Visible = true;
                            FL_Supervisor.Visible = true;
                        }
                        else if (role == 2 && ClientID == "FL")
                        {
                            LNT_SupervisorMenu.Visible = false;
                            LNT_UserMenu.Visible = false;
                            LNT_AdminMenu.Visible = false;
                            CLL_UserMenu.Visible = false;
                            CLL_Admin.Visible = false;
                            CLL_Supervisor.Visible = false;
                            LFTSTL_UserMenu.Visible = false;
                            LFTSTL_Admin.Visible = false;
                            LFTSTL_Supervisor.Visible = false;
                            IP_UserMenu.Visible = false;
                            IP_Admin.Visible = false;
                            IP_Supervisor.Visible = false;
                            PMS_Admin.Visible = false;
                            FL_UserManu.Visible = false;
                            FL_Admin.Visible = false;
                            FL_Supervisor.Visible = true;
                        }
                        else if (role == 3 && ClientID == "FL")
                        {
                            LNT_UserMenu.Visible = false;
                            LNT_AdminMenu.Visible = false;
                            LNT_SupervisorMenu.Visible = false;
                            CLL_UserMenu.Visible = false;
                            CLL_Admin.Visible = false;
                            CLL_Supervisor.Visible = false;
                            LFTSTL_UserMenu.Visible = false;
                            LFTSTL_Admin.Visible = false;
                            LFTSTL_Supervisor.Visible = false;
                            IP_UserMenu.Visible = false;
                            IP_Admin.Visible = false;
                            IP_Supervisor.Visible = false;
                            PMS_Admin.Visible = false;
                            FL_UserManu.Visible = true;
                            FL_Admin.Visible = false;
                            FL_Supervisor.Visible = false;
                        }
                        else if (role == 1 && ClientID == "PMS")
                        {
                            IP_UserMenu.Visible = false;
                            IP_Admin.Visible = false;
                            PMS_Admin.Visible = true;
                            IP_Supervisor.Visible = false;
                            LNT_UserMenu.Visible = false;
                            LNT_AdminMenu.Visible = false;
                            LNT_SupervisorMenu.Visible = false;
                            CLL_UserMenu.Visible = false;
                            CLL_Admin.Visible = false;
                            CLL_Supervisor.Visible = false;
                            LFTSTL_UserMenu.Visible = false;
                            LFTSTL_Admin.Visible = false;
                            LFTSTL_Supervisor.Visible = false;
                            FL_UserManu.Visible = false;
                            FL_Admin.Visible = false;
                            FL_Supervisor.Visible = false;
                        }

                        lblUserName.Text = " Welcome " + UserName;
                    }
                }
            }
            catch
            {

            }
        }

        protected void lnkLogOut_Click(object sender, EventArgs e)
        {
            try
            {
                if (Session["UserName"] != null)
                {
                    //CommonMaster commonMaster = new CommonMaster();
                    //int Result = commonMaster.UserLogOut(Convert.ToString(Session["LoginName"]));

                    //if (Result == 1)
                    //{
                    Session.Clear();
                    Response.Redirect("../LoginPage.aspx", false);
                    //}
                }
                else
                {
                    Session.Clear();
                    Response.Redirect("../LoginPage.aspx", false);
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }

        protected void lnkChangePassword_Click(object sender, EventArgs e)
        {
            Response.Redirect("LNT_ChangePassWord.aspx", false);
        }
    }
}