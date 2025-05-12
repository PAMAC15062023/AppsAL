using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AUMVD
{
    public partial class AUMVD_Master : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["UserName"] != null)
                {
                    lblWelcome.Text = "Active User MIS";

                    lblUserName.Text = "Welcome " + Convert.ToString(Session["UserName"]);


                }
                else
                {
                    Session.Clear();
                    Response.Redirect("AUMVD_Login.aspx", false);
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }

        protected void lnkLogOut_Click(object sender, EventArgs e)
        {
            Response.Redirect("AUMVD_Login.aspx", false);
            
        }

    }
}