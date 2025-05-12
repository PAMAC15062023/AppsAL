
/*----------------------------------------------------------------------------------------
Scope of Program	:	
File Name			:	CC_CaseView.aspx.cs
Create By			:	Hemangi Kambli
Create Date		    :	5th April 2007
Remarks 		    :	This class is used for view all CreditCard Case entries.
						
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

public partial class CC_CC_CaseView : System.Web.UI.Page
{
    CCreditCard objCreditCard = new CCreditCard();
    CCommon objCmn = new CCommon();
    protected void Page_Load(object sender, EventArgs e)
    {
        txtRefNo.Focus();
        if (Session["isView"].ToString() != "1")
            Response.Redirect("NoAccess.aspx");
        if (Session["isDelete"].ToString() != "1")
            Response.Redirect("NoAccess.aspx");

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

    protected void gvCreditCard_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        DataSet dsCreditCard = new DataSet();
        DataSet dsVerification = new DataSet();

        string sCaseId = e.CommandArgument.ToString();
        if (e.CommandName == "Edit")
        {

            if (sCaseId != "")
            {
                Response.Redirect("CC_CaseEntry.aspx?CaseID=" + sCaseId);
                //Response.Redirect("Default2.aspx?CaseID=" + sCaseId);
            }
        }
        if (e.CommandName == "DeleteCC")
        {

            if (objCreditCard.DeleteCreditCardCaseEntry(sCaseId) == 1)
            {
                lblMsg.Visible = true;
                lblMsg.Text = "Record deleted successfully.";
            }
        }
        sdsCreditCard.SelectCommand = objCreditCard.GetCreditCaseEntry(Session["CentreId"].ToString(), Session["ClientId"].ToString());
    }

    protected void gvCreditCard_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {            
            LinkButton l = (LinkButton)e.Row.FindControl("lnkDeleteCreditCard");
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
            sdsCreditCard.SelectCommand = objCreditCard.GetCreditCaseEntry(txtRefNo.Text.Trim(), txtName.Text.Trim(), true, txtFromDate.Text.Trim(), txtToDate.Text.Trim(), Session["CentreId"].ToString(), Session["ClientId"].ToString());            
        }
        else
        {
            sdsCreditCard.SelectCommand = objCreditCard.GetCreditCaseEntry(txtRefNo.Text.Trim(), txtName.Text.Trim(), false, txtFromDate.Text.Trim(), txtToDate.Text.Trim(), Session["CentreId"].ToString(), Session["ClientId"].ToString());
        }
        gvCreditCard.DataBind();
        if (gvCreditCard.Rows.Count == 0)
        {
            lblMsg.Visible = true;
            lblMsg.ForeColor = System.Drawing.Color.Red;
            lblMsg.Text = "Record not found.";
        }
    }

    protected void btnNewCase_Click(object sender, EventArgs e)
    {
        Response.Redirect("CC_CaseEntry.aspx?CaseID=Add");
        //Response.Redirect("Default2.aspx?CaseID=Add");
    }
   
}
