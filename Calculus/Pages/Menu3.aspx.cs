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

public partial class Pages_Menu : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (Session["UserInfo"] == null)
            {
                Response.Redirect("InvalidRequest.aspx", false);
            }
            else
            {
                Object SaveUSERInfo = (Object)Session["UserInfo"];
                lblUserName.Text = Convert.ToString(((UserInfo.structUSERInfo)(SaveUSERInfo)).UserId);
                lblBranch.Text = Convert.ToString(((UserInfo.structUSERInfo)(SaveUSERInfo)).BranchName);
                lblRole.Text = Convert.ToString(((UserInfo.structUSERInfo)(SaveUSERInfo)).GroupName);
                lblMasterFileInfo.Text = Convert.ToString(((UserInfo.structUSERInfo)(SaveUSERInfo)).MasterLastUpdatedDate);
                lblClient.Text = Convert.ToString(((UserInfo.structUSERInfo)(SaveUSERInfo)).ClientName);
                DateTime DateLastAccessTime=Convert.ToDateTime(lblMasterFileInfo.Text.Trim())  ;
             
                TimeSpan ts = DateTime.Now - DateLastAccessTime;
                if (Math.Round(ts.TotalHours) > 24)
                {
                    lblInfo.Visible = true;
                    lblMasterFileInfo.ForeColor = System.Drawing.Color.Red;
                    lblInfo.ToolTip = "DBF Files are more Old than 24 Hours.!";
                }
   
            } 
        }
        catch (Exception ex)
        {   
            
        }
    }
}
