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

public partial class Administrator_kyc_Export_Template : System.Web.UI.Page
{
    CKYC_Export objExport = new CKYC_Export();
    protected void Page_Load(object sender, EventArgs e)
    {
        lblMsg.Visible = false;
        if (!IsPostBack)
        {
            if (Context.Request.QueryString["Msg"] != null && Context.Request.QueryString["Msg"] != "")
            {
                lblMsg.Visible = true;
                lblMsg.ForeColor = System.Drawing.Color.Red;
                lblMsg.Text = Request.QueryString["Msg"].ToString();
            }
        }
        gvExportTemplate.DataBind();
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        Response.Redirect("kyc_Export_new_tempate.aspx?Op=Add");
    }
    protected void gvExportTemplate_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Edit")
        {
            Response.Redirect("kyc_Export_new_tempate.aspx?Op=Edit&TempId=" + e.CommandArgument);
        }
        if (e.CommandName == "Delete1")
        {
            objExport.TemplateId = e.CommandArgument.ToString();
            objExport.DeleteExportTemplate();
        }
        gvExportTemplate.DataBind();
    }
    protected void gvExportTemplate_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        lblMsg.Visible = false;
        lblMsg.Text = "";
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            LinkButton l = (LinkButton)e.Row.FindControl("lnkTemplateDelete");
            l.Attributes.Add("onclick", "javascript:return " +
                          "confirm('Are you sure you want to delete this record')");
        }   
    }
    protected void gvExportTemplate_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}
