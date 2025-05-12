    using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LNTFinance.Pages
{
    public partial class LNT_CommonMaster : System.Web.UI.MasterPage
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
                        string ClientName = Convert.ToString(((UserInfo.structUSERInfo)(SaveUSERInfo)).ClientName);
                        string ClientID = Convert.ToString(((UserInfo.structUSERInfo)(SaveUSERInfo)).ClientID);
                        lblWelcome.Text = ClientName;

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