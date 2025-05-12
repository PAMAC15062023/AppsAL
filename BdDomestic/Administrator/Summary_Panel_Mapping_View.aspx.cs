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

public partial class Administrator_Summary_Panel_Mapping_View : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void grvSummaryTemplate_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            LinkButton l = (LinkButton)e.Row.FindControl("ImgbtnDel");

            l.Attributes.Add("onclick", "javascript:return " +
                          "confirm('Are you sure you want to delete this record')");
        }
    }
    protected void grvSummaryTemplate_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        string sTemplate_ID = e.CommandArgument.ToString();
        if (e.CommandName == "Edit")
        {
            if (sTemplate_ID != "")
            {
                Response.Redirect("Summary_Panel_Mapping.aspx?Template_ID=" + sTemplate_ID);
            }
        }
        else if (e.CommandName == "btnDelete")
        {
            if (sTemplate_ID != "")
            {
                try
                {
                    CAdmin_Summary_Panel_Mapping objADSPM = new CAdmin_Summary_Panel_Mapping();
                    objADSPM.pptTemplateID = sTemplate_ID;
                    objADSPM.deleteTemplate();
                    lblError.Text = "Template Deleted Successfully!";
                    grvSummaryTemplate.DataBind();
                }
                catch (Exception exp)
                {
                    lblError.Text = exp.Message;
                }
            }
        }
    }
    protected void btnNew_Click(object sender, EventArgs e)
    {

    }
}
