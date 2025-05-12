/*----------------------------------------------------------------------------------------
Scope of Program	:	
File Name			:	EBC_CaseView.aspx.cs
Create By			:	Hemangi Kambli
Create Date		    :	14th April 2007
Remarks 		    :	This class is used for view all EBC Cases for verification.
						
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

public partial class EBC_EBC_CaseVeriView : System.Web.UI.Page
{
    CEBC objEBC = new CEBC();
    protected void Page_Load(object sender, EventArgs e)
    {
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
    
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        lblMsg.Text = "";
        lblMsg.Visible = false;
        if (chkName.Checked == true)
            sdsEBC.SelectCommand = objEBC.GetEBCCaseEntry(txtRefNo.Text.Trim(), txtName.Text.Trim(), true, txtFromDate.Text.Trim(), txtToDate.Text.Trim());
        else
            sdsEBC.SelectCommand = objEBC.GetEBCCaseEntry(txtRefNo.Text.Trim(), txtName.Text.Trim(), false, txtFromDate.Text.Trim(), txtToDate.Text.Trim());
    }
    protected void gvEBC_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        string sCaseId = e.CommandArgument.ToString();
        if (e.CommandName == "Edit")
        {
            if (sCaseId != "")
            {
                Response.Redirect("EBC_CaseVerificationEntry.aspx?CaseID=" + sCaseId);
            }
        }
        
        sdsEBC.SelectCommand = objEBC.GetEBCCaseEntry();
    }
    
}

