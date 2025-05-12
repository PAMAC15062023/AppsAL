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
using System.IO;
using System.Drawing;
using System.Drawing.Printing;




public partial class Administrator_CompanyViewMaster : System.Web.UI.Page
{
    
    protected void Page_Load(object sender, EventArgs e)
    {
        lblMsg.Text = (string)Session["msg"];
    }
    protected void gvCompanyMaster_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {

    }
    protected void gvCompanyMaster_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        String strCompanyID = "";
        if (e.CommandName == "Edit")
        {
            strCompanyID = e.CommandArgument.ToString();
            //if (Session["isEdit"].ToString() == "1")
            //{
                if (strCompanyID != "")
                {
                    Response.Redirect("CompanyMaster.aspx?Company_Id=" + strCompanyID);
                }
            //}
            else
            {
                lblMsg.Text = "Access denied!";
            }

        }

    }
   
  

    public override void VerifyRenderingInServerForm(Control control)
    {
                   
    }
    protected void btnAddMultiColumn_Click(object sender, EventArgs e)
    {
        Response.Redirect("CompanyMaster.aspx");
        
    }
}
