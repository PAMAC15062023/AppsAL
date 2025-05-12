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

public partial class Administrator_ClientMaster : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["Massage"] != "" && Request.QueryString["Massage"] != null)
        {
            lblMsg.Text = Request.QueryString["Massage"];
        }
    }
    protected void gvClientMaster_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        String strClient_ID = "";
        if (e.CommandName == "Edit")
        {
            strClient_ID = e.CommandArgument.ToString();
            if (strClient_ID != "")
            {
                Response.Redirect("ClientMasterManage.aspx?Mode=E&NID=" + strClient_ID);
            }
        }

    }
   
    protected void AddNew_Click(object sender, EventArgs e)
    {
        Response.Redirect("ClientMasterManage.aspx?Mode=A&NID=0");
    }
}
