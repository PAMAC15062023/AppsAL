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
using System.Web.SessionState;
using System.IO;

public partial class MasterPage : System.Web.UI.MasterPage
{     
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        { 
            if (Session["UserInfo"] == null)
            {
                lnkLogOut.Visible = false;               
            }
            else
            {
                Object SaveUSERInfo = (Object)Session["UserInfo"];
                lblWelcome.Text = "Welcome " + Convert.ToString(((UserInfo.structUSERInfo)(SaveUSERInfo)).UserName) + " to " + Convert.ToString(((UserInfo.structUSERInfo)(SaveUSERInfo)).BranchName) + " Branch";                
                IsAuthorizeUser_ForPage();
                 
            }
        }
        catch (Exception ex)
        { 
           
        }       

    }
    protected void lnkLogOut_Click(object sender, EventArgs e)
    {
        
            if (Session["UserInfo"] != null)
            { 
                Session.Clear();
                Response.Redirect("~/pages/Logout.aspx", false);
          
            }
 
    }
    private void IsAuthorizeUser_ForPage()
    {
        Boolean ReturnValue = false;
        Object SaveUSERInfo = (Object)Session["UserInfo"];
               

                if (((UserInfo.structUSERInfo)(SaveUSERInfo)).PageAccessString.Contains(Request.AppRelativeCurrentExecutionFilePath.ToLower()))
                {
                    ReturnValue = true;
                }
                if (ReturnValue == false)
                {
                    Response.Redirect("~/Pages/Menu.aspx",true);
                } 

    }

    protected void lnkPMS_Click(object sender, EventArgs e)
    {
        Response.Redirect("https://www.pamaconline.com/", true);
    }
}
