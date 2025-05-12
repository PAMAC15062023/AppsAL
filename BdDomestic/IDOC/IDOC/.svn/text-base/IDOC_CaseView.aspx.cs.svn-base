
/*----------------------------------------------------------------------------------------
Scope of Program	:	
File Name			:	IDOC_CaseView.aspx.cs
Create By			:	Hemangi Kambli
Create Date		    :	12th April 2007
Remarks 		    :	This class is used for view all IDOC Case entries.
						
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

public partial class CPV_IDOC_IDOC_CaseView : System.Web.UI.Page
{
    CIDOC objIDoc = new CIDOC();
    CCommon objCmn = new CCommon();
    protected void Page_Load(object sender, EventArgs e)
    {
        txtRefNo.Focus();
        lblMsg.Text = "";
        if (Session["isView"].ToString() != "1")
            Response.Redirect("NoAccess.aspx");

        lblMsg.Visible = false;
        if (Context.Request.QueryString["Msg"] != null && Context.Request.QueryString["Msg"] != "")
        {
            lblMsg.ForeColor = System.Drawing.Color.Red;
            lblMsg.Visible = true;
            lblMsg.Text = Request.QueryString["Msg"].ToString();
        }
        else
        {
            lblMsg.Text = "";
        }
    }

    protected void gvIDOC_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        DataSet dsCreditCard = new DataSet();
        DataSet dsVerification = new DataSet();
        lblMsg.Text = "";
        string sCaseId = e.CommandArgument.ToString();
        if (e.CommandName == "Edit")
        {

            if (sCaseId != "")
            {
                Response.Redirect("IDOC_CaseEntry.aspx?CaseID=" + sCaseId);
            }
        }
        if (e.CommandName == "DeleteIDOC")
        {
            if (objIDoc.DeleteIDOCCaseEntry(sCaseId) == 1)
            {
                lblMsg.Visible = true;
                lblMsg.Text = "Record deleted successfully.";
            }
        }
        sdsCreditCard.SelectCommand = objIDoc.GetIDOCCaseEntry(Session["CentreId"].ToString(), Session["ClientId"].ToString());
    }

    protected void gvIDOC_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            LinkButton l = (LinkButton)e.Row.FindControl("lnkDeleteIDOC");
            l.Attributes.Add("onclick", "javascript:return " +
                          "confirm('Are you sure you want to delete this record')");
        }
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        lblMsg.Text = "";        
        lblMsg.Visible = false;

        if (chkName.Checked == true)
        {
            sdsCreditCard.SelectCommand = objIDoc.GetIDOCCaseEntry(txtRefNo.Text.Trim(), txtName.Text.Trim(), true, txtFromDate.Text.Trim(), txtToDate.Text.Trim(), Session["CentreId"].ToString(), Session["ClientId"].ToString(),txtCaseID.Text.Trim());
        }
        else
        {
            sdsCreditCard.SelectCommand = objIDoc.GetIDOCCaseEntry(txtRefNo.Text.Trim(), txtName.Text.Trim(), false, txtFromDate.Text.Trim(), txtToDate.Text.Trim(), Session["CentreId"].ToString(), Session["ClientId"].ToString(),txtCaseID.Text.Trim());
        }
        
        gvIDOC.DataBind();
        if (gvIDOC.Rows.Count == 0)
        {
            lblMsg.Visible = true;
            lblMsg.ForeColor = System.Drawing.Color.Red;
            lblMsg.Text = "Record not found.";
        }
    }

    protected void btnNewCase_Click(object sender, EventArgs e)
    {
        lblMsg.Text = "";
        Response.Redirect("IDOC_CaseEntry.aspx?CaseID=Add");
    }
}

