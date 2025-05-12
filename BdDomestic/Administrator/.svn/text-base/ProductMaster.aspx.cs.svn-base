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
using System.Data.OleDb;

public partial class Administrator_ProductMaster : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
       
        if (Request.QueryString["Massage"] != "" && Request.QueryString["Massage"] != null)
        {
            lblMsg.Text = Request.QueryString["Massage"];
        }
    }
    protected void gvProductMaster_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        String strProduct_ID = "";
        if (e.CommandName == "Edit")
        {
            strProduct_ID = e.CommandArgument.ToString();
            if (strProduct_ID != "")
            {
                Response.Redirect("ProductMasterManage.aspx?Mode=E&NID=" + strProduct_ID);
            }
        }
    }
    

    protected void AddNew_Click(object sender, EventArgs e)
    {
        Response.Redirect("ProductMasterManage.aspx?Mode=A&NID=0");
    }
}
