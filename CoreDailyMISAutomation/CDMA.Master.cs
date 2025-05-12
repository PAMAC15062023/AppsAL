using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CoreDailyMISAutomation
{
    public partial class CDMA : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["UserName"] != null)
                {
                    lblWelcome.Text = "Core - Daily MIS Automation";

                    lblUserName.Text = "Welcome " + Convert.ToString(Session["UserName"]) + " to " + Convert.ToString(Session["Branch_Name"]) + " Branch.";

                   
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

        //protected void lnkLogOut_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        if (Session["UserName"] != null)
        //        {
        //            CommonMaster commonMaster = new CommonMaster();
        //            int Result = commonMaster.UserLogOut(Convert.ToString(Session["UserID"]));

        //            if (Result == 1)
        //            {
        //                Session.Clear();
        //                Response.Redirect("Login.aspx", false);
        //            }
        //        }
        //        else
        //        {
        //            Session.Clear();
        //            Response.Redirect("Login.aspx", false);
        //        }
        //    }
        //    catch (Exception ex)
        //    {

        //    }
        //}

        protected void lnkChangePassword_Click(object sender, EventArgs e)
        {
            Response.Redirect("ChangePassword.aspx", false);
        }

        protected void lnkLogOut_Click1(object sender, EventArgs e)
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
    }
}