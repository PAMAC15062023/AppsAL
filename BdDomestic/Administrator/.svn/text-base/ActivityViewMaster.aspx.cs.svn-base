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

public partial class Administrator_ActivityViewMaster : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        lblMsg.Text = "";
        lblMsg.Text = (string)Session["msg3"];
    }
    protected void gvActivityMaster_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        String strActivityID = "";
        if (e.CommandName == "Edit")
        {
            strActivityID = e.CommandArgument.ToString();
            //if (Session["isEdit"].ToString() == "1")
            //{
            if (strActivityID != "")
            {
                Response.Redirect("ActivityMaster.aspx?ACTIVITY_ID=" + strActivityID);
            }
            //}
            else
            {
                lblMsg.Text = "Access denied!";
            }

        }

    }
    protected void btnAddMultiColumn_Click(object sender, EventArgs e)
    {
        Response.Redirect("ActivityMaster.aspx");
    }
}
