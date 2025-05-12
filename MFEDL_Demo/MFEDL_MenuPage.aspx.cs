using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using YesBank;

namespace MFEDL_Demo
{
    public partial class MFEDL_MenuPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                Object SaveUSERInfo = (Object)Session["UserInfo"];

                if (Session["UserInfo"] == null)
                {
                    Response.Redirect("MFEDL_InvalidRequest.aspx", true);
                


                    if (Session["RoleId"] != null)
                    {
                        string RoleID = Convert.ToString(Session["RoleId"]);
                        string currentPageName = Request.Url.Segments[Request.Url.Segments.Length - 1];
                       /* RolePageAuth rpa = new RolePageAuth();
                        bool result = rpa.CheckRolePageAuth(RoleID, currentPageName.Trim());

                        if (!result)
                        {
                            Response.Redirect("MFEDL_AuthorizeFailed.aspx", false);
                        }*/
                    }
                }
                else
                {
                    if (!IsPostBack)
                    {
                        lblWelcome.Text = "Muthoot Fincorp ED Loans";

                        string UserName = Convert.ToString(((UserInfo.structUSERInfo)(SaveUSERInfo)).UserName);

                       // string LoanType = Convert.ToString(((UserInfo.structUSERInfo)(SaveUSERInfo)).LoanType);

                        lblUserName.Text = UserName;
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
                    Object SaveUSERInfo = (Object)Session["UserInfo"];
                    CommonMaster commonMaster = new CommonMaster();
                    int Result = commonMaster.UserLogOut(Convert.ToString(((UserInfo.structUSERInfo)(SaveUSERInfo)).UserID));

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

        protected void lnkChangePassword_Click(object sender, EventArgs e)
        {
           // Response.Redirect("MFEDL_ChnagePassWord.aspx", false);
        }
    }
}