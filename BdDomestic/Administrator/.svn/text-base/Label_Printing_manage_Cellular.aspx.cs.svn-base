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

public partial class Administrator_Label_Printing_manage_Cellular : System.Web.UI.Page
{
    CCommon objCom = new CCommon();
    OleDbDataAdapter da;
    OleDbDataReader dr;
    DataSet ds = new DataSet();


    protected void Page_Load(object sender, EventArgs e)
    {

    }
  
    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        string templateID = "";
        templateID = e.CommandArgument.ToString();
        if (e.CommandName == "Edit")
        {
            if (templateID != "")
            {
                Response.Redirect("Label_Template_View_Cellular.aspx?templateID=" + templateID + " ");
            }
        }
        else if (e.CommandName == "del")
        {
            if (templateID != "")
            {
                try
                {
                    CLabelTemplate objLabel = new CLabelTemplate();
                    objLabel.TemplateId = templateID;
                    objLabel.deleteTemplate();
                    lblError.Text = "Template Deleted Successfully!";
                    GridView1.DataBind();
                }
                catch (Exception exp)
                {
                    lblError.Text = exp.Message;
                }
            }
        }
    }


    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            ImageButton l = (ImageButton)e.Row.FindControl("ImageButton2");

            l.Attributes.Add("onclick", "javascript:return " +
                          "confirm('Are you sure you want to delete this record')");
        }
    }

    protected void btnnewtemplate_Click(object sender, EventArgs e)
    {
        Response.Redirect("Label_Template_View_Cellular.aspx");
    }
}
