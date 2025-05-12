
/*----------------------------------------------------------------------------------------
Scope of Program	:	
File Name			:	EBC_CaseView.aspx.cs
Create By			:	Hemangi Kambli
Create Date		    :	11th April 2007
Remarks 		    :	This class is used for view all EBC Case entries.
						
----------------------------------------------------------------------------------------*/
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

public partial class EBC_EBC_CaseView : System.Web.UI.Page
{
    CEBC objEBC = new CEBC();
    CCommon objcon = new CCommon();
    protected void Page_Load(object sender, EventArgs e)
    {
        objEBC.CentreId = Session["CentreID"].ToString();
        objEBC.ClientId = Session["ClientID"].ToString();
        if (Session.Count == 0)
            Response.Redirect("Default.aspx");

        lblMsg.Visible = false;
        if (Context.Request.QueryString["Msg"] != null && Context.Request.QueryString["Msg"] != "")
        {
            lblMsg.Visible = true;
            lblMsg.Text = Request.QueryString["Msg"].ToString();
        }
        else
        {
            lblMsg.Text = "";
        }
    }
    protected void btnNewCase_Click(object sender, EventArgs e)
    {
        Response.Redirect("EBC_CaseEntry.aspx?CaseID=Add");
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        try
        {
            lblMsg.Text = "";
            lblMsg.Visible = false;
            if (chkName.Checked == true)
                sdsEBC.SelectCommand = objEBC.GetEBCCaseEntry(txtRefNo.Text.Trim(), txtName.Text.Trim(), true, txtFromDate.Text.Trim(), txtToDate.Text.Trim());
            else
                sdsEBC.SelectCommand = objEBC.GetEBCCaseEntry(txtRefNo.Text.Trim(), txtName.Text.Trim(), false, txtFromDate.Text.Trim(), txtToDate.Text.Trim());

            gvEBC.DataBind();
            if (gvEBC.Rows.Count == 0)
            {
                lblMsg.Visible = true;

                lblMsg.Text = "Record not found.";
            }
        }
        catch (Exception ex)
        {
            lblMsg.Visible = true;

            lblMsg.Text = "Error while generating report: " + ex.Message;
                
        }

        //try catch is added by supriya on 14th Nov2007 

    }
    protected void gvEBC_RowCommand(object sender, GridViewCommandEventArgs e)
    {
       
        string sCaseId = e.CommandArgument.ToString();
        if (e.CommandName == "Edit")
        {
            if (sCaseId != "")
            {
                Response.Redirect("EBC_CaseEntry.aspx?CaseID=" + sCaseId);
            }
        }
        if (e.CommandName == "DeleteEBC")
        {
            if (objEBC.DeleteEBCaseEntry(sCaseId) == 1)
            {
                lblMsg.Visible = true;
                lblMsg.Text = "Record deleted successfully.";
            }
        }
        sdsEBC.SelectCommand = objEBC.GetEBCCaseEntry();
        
    }
    protected void gvEBC_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            LinkButton l = (LinkButton)e.Row.FindControl("lnkDeleteEBC");
            l.Attributes.Add("onclick", "javascript:return " +
                          "confirm('Are you sure you want to delete this record')");
        }
    }
}
