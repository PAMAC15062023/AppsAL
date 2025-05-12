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

public partial class Administrator_ClusterViewMaster : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        lblMsg.Text="";

        lblMsg.Text = (string)Session["msg1"];
       
    }
    protected void gvClusterMaster_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        

    }
    protected void btnAddMultiColumn_Click(object sender, EventArgs e)
    {
        Response.Redirect("ClusterMaster.aspx");
    }
    protected void gvClusterMaster_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        String strClusterID = "";
        if (e.CommandName == "Edit")
        {
            strClusterID = e.CommandArgument.ToString();
            //if (Session["isEdit"].ToString() == "1")
            //{
            if (strClusterID != "")
            {
                Response.Redirect("ClusterMaster.aspx?Cluster_Id=" + strClusterID);
            }
            //}
            else
            {
                lblMsg.Text = "Access denied!";
            }

        }
    }
}
