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
/// <summary>
/// Made By Gargi Srivastava
/// On Date 13-Oct-2007
/// </summary>
public partial class CPV_CC_CC_OverallCaseStatus : System.Web.UI.Page
{
    COverallCaseStatus objOverallCaseStatus = new COverallCaseStatus();
    int indexCount;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            PropertySet();
            FillGrid();
        }

    }

    private void FillGrid()
    {
        DataTable dt = new DataTable();
        dt = objOverallCaseStatus.CCGetSearch();
        if (dt.Rows.Count > 0)
        {
            gvOverallStatus.DataSource = dt;
            gvOverallStatus.DataBind();
            gvOverallStatus.Visible = true;
            
        }
        else
        {
            gvOverallStatus.Visible = false;
            lblMessage.Text = "Records are not found";
        }
    }

    private void PropertySet()
    {
        objOverallCaseStatus.Fromdate = txtFromDate.Text.Trim().ToString();
        objOverallCaseStatus.Todate = txtToDate.Text.Trim().ToString();
        objOverallCaseStatus.ProductID = Session["ProductId"].ToString();
        objOverallCaseStatus.ClientID = Session["ClientId"].ToString();
        objOverallCaseStatus.CentreID = Session["CentreId"].ToString();

    }
    private struct GridPosition
    {
        public const int CASEID = 0;
        public const int APPLICANTNAME = 1;
        public const int REFNO = 2;
        public const int OVERALLSTATUS = 3;
        public const int COMMENTS = 4;
        public const int EDIT = 5;
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        lblMessage.Text = "";
        gvOverallStatus.EditIndex = -1;
        PropertySet();
        FillGrid();

    }

    protected void gvOverallStatus_RowEditing(object sender, GridViewEditEventArgs e)
    {
        gvOverallStatus.EditIndex = e.NewEditIndex;
        PropertySet();
        FillGrid();
        InitializeFunctionWithTextArea();
    }
    protected void gvOverallStatus_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {

            DropDownList ddlOverallStatus = (DropDownList)e.Row.FindControl("ddlOverallStatus");

            if (ddlOverallStatus != null)
            {
                ddlOverallStatus.DataSource = objOverallCaseStatus.FillOverallStatus();
                ddlOverallStatus.DataBind();
                ddlOverallStatus.SelectedValue = gvOverallStatus.DataKeys[e.Row.RowIndex].Values[1].ToString();
            }
        }


    }

    protected void gvOverallStatus_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        gvOverallStatus.EditIndex = -1;
        PropertySet();
        FillGrid();
        
    }
    protected void gvOverallStatus_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        GridViewRow row = gvOverallStatus.Rows[e.RowIndex];
        if (row != null)
        {
            Label lblCaseID = ((Label)row.FindControl("lblCaseID"));
            DropDownList ddlOverallStatus = ((DropDownList)row.FindControl("ddlOverallStatus"));
            TextBox txtOverallComments = ((TextBox)row.FindControl("txtOverallComments"));

            objOverallCaseStatus.CaseID = lblCaseID.Text.Trim().ToString();
            objOverallCaseStatus.OverallStatus = ddlOverallStatus.SelectedValue.ToString();
            objOverallCaseStatus.OverallComments = txtOverallComments.Text.Trim().ToString();

            string StrMsg = objOverallCaseStatus.UpdateGridItems();
            gvOverallStatus.EditIndex = -1;
            PropertySet();
            FillGrid();

        }

    }

    protected void gvOverallStatus_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvOverallStatus.PageIndex = e.NewPageIndex;
        PropertySet();
        FillGrid();
    }
    private void InitializeFunctionWithTextArea()
    {
        for (int i = 0; i < gvOverallStatus.Rows.Count; i++)
        {
            TextBox txtOverallComments;
            txtOverallComments = (TextBox)gvOverallStatus.Rows[i].FindControl("txtOverallComments");
            if(txtOverallComments!=null)
            {
            //this javascript function allowed 200 charcter only into textbox.
            txtOverallComments.Attributes.Add("onkeypress", "return PreventCharacterToAdd('" + txtOverallComments.ClientID + "');");
            txtOverallComments.Attributes.Add("onkeyup", "return PreventCharacterToAdd('" + txtOverallComments.ClientID + "');");
            }
        }
    }

}
