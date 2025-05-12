using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using YesBank;

namespace MFDE_Demo
{
    public partial class MFEDL : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["UserName"] != null)
                {
                    lblWelcome.Text = "Muthoot Fincorp ED Loans";

                    lblUserName.Text = Session["UserName"].ToString();


                    if (Session["RoleID"] != null)
                    {
                        string RoleID = Convert.ToString(Session["RoleID"]);
                        string currentPageName = Request.Url.Segments[Request.Url.Segments.Length - 1];
                       // RolePageAuth rpa = new RolePageAuth();
                       // bool result = rpa.CheckRolePageAuth(RoleID, currentPageName.Trim());

                        //if (result)
                        //{
                        //    Response.Redirect("MFEDL_AuthorizeFailed.aspx", false);
                        //}
                    }
                }

                else
                {
                    Session.Clear();
                    Response.Redirect("MFEDL_LoginPage.aspx", false);
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
                    int Result = commonMaster.UserLogOut(Convert.ToString(Session["LoginName"]));

                    if (Result == 1)
                    {
                        Session.Clear();
                        Response.Redirect("MFEDL_LoginPage.aspx", false);
                    }
                }
                else
                {
                    Session.Clear();
                    Response.Redirect("MFEDL_LoginPage.aspx", false);
                }
            }
            catch (Exception ex)
            {

            }
        }
        protected void lkbtnchangePassword_Click(object sender, EventArgs e)
        {
            //Response.Redirect("YBL_ChangePassword.aspx", false);
        }

        protected void lnkChangePassword_Click(object sender, EventArgs e)
        {
            Response.Redirect("MFEDL_ChnagePassWord.aspx", false);
        }
    }
}
