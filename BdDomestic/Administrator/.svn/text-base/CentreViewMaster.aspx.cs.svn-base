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

public partial class Administrator_CentreViewMaster : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        lblMsg.Text = "";
        lblMsg.Text = (string)Session["msg2"];

    }
    protected void gvCentreMaster_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        String strCentreID = "";
        if (e.CommandName == "Edit")
        {
            strCentreID = e.CommandArgument.ToString();
            //if (Session["isEdit"].ToString() == "1")
            //{
            if (strCentreID != "")
            {
                Response.Redirect("CenterMaster.aspx?Centre_Id=" + strCentreID);
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
        Response.Redirect("CenterMaster.aspx");
    }
}
