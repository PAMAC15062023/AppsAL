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
using System.Data.SqlClient;
using System.Data.OleDb;
using System.IO;
using System.Drawing;

public partial class IDOC_IDOC_IDOC_DeDupSearch : System.Web.UI.Page
{
    CCommon objCmn = new CCommon();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["isView"].ToString() != "1")
            Response.Redirect("NoAccess.aspx");

        txtCaseId.Focus();
        lblMsg.Text = "";
        if (!IsPostBack)
        {
            if (Context.Request.QueryString["Op"] != null && Context.Request.QueryString["Op"] != "")
            {
                ddlVerifyType.DataBind();
                DataSet dsDedup = new DataSet();
                txtDOB.Text = "";
                txtName.Text = "";
                txtCaseId.Text = "";
                //ddlVerifyType.SelectedValue = Request.QueryString["VerificationTypeId"].ToString();
                if (txtDOB.Text.Trim() != "")
                    dsDedup = GetAutoDedup(txtCaseId.Text.Trim(), txtName.Text.Trim(), objCmn.strDate(txtDOB.Text.Trim()), ddlVerifyType.SelectedValue.ToString());
                else
                    dsDedup = GetAutoDedup(txtCaseId.Text.Trim(), txtName.Text.Trim(), "", ddlVerifyType.SelectedValue.ToString());

                gvIDOCDedup.DataSource = dsDedup;
                gvIDOCDedup.Visible = true;
                gvIDOCDedup.DataBind();

            }
        }
    }
    
    private DataSet GetAutoDedup(string sCaseId, string sName,string sDOB,string sVerificationTypeID)
    {
        string sSql = "";

        sSql = "SELECT CD.CASE_ID,CD.REF_NO,client_name,convert(varchar,CASE_REC_DATETIME,103) as [RECD DATE]," +
                        " (ISNULL(CD.TITLE,'')+' '+ ISNULL(CD.FIRST_NAME,'')+' ' + " +
                        " ISNULL(CD.MIDDLE_NAME,'')+' ' +ISNULL(CD.LAST_NAME,'')) AS APPLICANT_NAME, "+
                        " DOB,VM.VERIFICATION_TYPE,VM.VERIFICATION_TYPE_ID,STATUS_NAME " +
                        " FROM CPV_IDOC_CASE_DETAILS CD LEFT OUTER JOIN CPV_IDOC_VERIFICATION CV ON CD.CASE_ID=CV.CASE_ID " +
                        " LEFT OUTER JOIN VERIFICATION_TYPE_MASTER VM ON CV.VERIFICATION_TYPE_ID=VM.VERIFICATION_TYPE_ID " +
                        " LEFT OUTER JOIN CASE_STATUS_MASTER CSM ON CSM.CASE_STATUS_ID=CV.CASE_STATUS_ID left outer join client_master cm on(cm.client_id=cd.client_id) WHERE 1=1 ";

        if (sCaseId != "")
        {
            sSql += " AND CD.CASE_ID='" + sCaseId + "'";
        }
        if (sVerificationTypeID.Trim() !="")
        {
            if (sVerificationTypeID != "All")
                sSql += " AND CV.VERIFICATION_TYPE_ID='" + sVerificationTypeID + "'";
        }

        if(sDOB!="")
            sSql += " AND CD.DOB='" +  sDOB + "'";

        if(sName!="")
            sSql += " AND (ISNULL(CD.FIRST_NAME,'')+' ' + ISNULL(CD.MIDDLE_NAME,'')+' ' +ISNULL(CD.LAST_NAME,'')) LIKE '%" + sName + "%'";

        sSql += " AND CENTRE_ID='" + Session["CentreId"].ToString() + "'" ;
        //commented by hemangi kambli on 02/08/2007 --as per discussion ------
        //sSql += " AND CLIENT_ID='" + Session["ClientId"].ToString() + "'"; 

        sSql += " ORDER BY CD.CASE_ID";
        return OleDbHelper.ExecuteDataset(objCmn.ConnectionString, CommandType.Text, sSql);

    }    


    protected void btnDedupeSearch_Click(object sender, EventArgs e)
    {
        DataSet dsDedup = new DataSet();
        if(txtDOB.Text.Trim()!="")
            dsDedup = GetAutoDedup(txtCaseId.Text.Trim(),txtName.Text.Trim(), objCmn.strDate(txtDOB.Text.Trim()),ddlVerifyType.SelectedValue.ToString());
        else
            dsDedup = GetAutoDedup(txtCaseId.Text.Trim(), txtName.Text.Trim(), "", ddlVerifyType.SelectedValue.ToString());

        if (dsDedup.Tables[0].Rows.Count > 0)
        {
            gvIDOCDedup.Visible = true;
            gvIDOCDedup.DataSource = dsDedup;
            gvIDOCDedup.DataBind();
        }
        else
        {
            gvIDOCDedup.Visible = false;
            lblMsg.Visible = true;
            lblMsg.Text = "No record found.";
        }
        btnDedupeSearch.Focus();
    }
    
    protected void ddlVerifyType_DataBound(object sender, EventArgs e)
    {
        ddlVerifyType.Items.Insert(0, "All");
    }

    public SortDirection GridViewSortDirection
    {
        get
        {
            if (ViewState["sortDirection"] == null)
                ViewState["sortDirection"] = SortDirection.Ascending;
            return (SortDirection)ViewState["sortDirection"];
        }
        set { ViewState["sortDirection"] = value; }
    }

    protected void gvIDOCDedup_Sorting(object sender, GridViewSortEventArgs e)
    {
        DataSet dsDedup = new DataSet();
        if (txtDOB.Text.Trim() != "")
            dsDedup = GetAutoDedup(txtCaseId.Text.Trim(), txtName.Text.Trim(), objCmn.strDate(txtDOB.Text.Trim()), ddlVerifyType.SelectedValue.ToString());
        else
            dsDedup = GetAutoDedup(txtCaseId.Text.Trim(), txtName.Text.Trim(), "", ddlVerifyType.SelectedValue.ToString());

        if (dsDedup.Tables[0].Rows.Count > 0)
        {
            DataView dv = new DataView(dsDedup.Tables[0]);
            string sortExpression = e.SortExpression;
            if (GridViewSortDirection == SortDirection.Ascending)
            {
                GridViewSortDirection = SortDirection.Descending;
                dv.Sort = sortExpression + " " + "ASC";
            }
            else
            {
                GridViewSortDirection = SortDirection.Ascending;
                dv.Sort = sortExpression + " " + "DESC";
            }
            gvIDOCDedup.DataSource = dv;
            gvIDOCDedup.DataBind();

        }
    }
    
    protected void gvIDOCDedup_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        DataSet dsDedup = new DataSet();
        if (txtDOB.Text.Trim() != "")
            dsDedup = GetAutoDedup(txtCaseId.Text.Trim(), txtName.Text.Trim(), objCmn.strDate(txtDOB.Text.Trim()), ddlVerifyType.SelectedValue.ToString());
        else
            dsDedup = GetAutoDedup(txtCaseId.Text.Trim(), txtName.Text.Trim(), "", ddlVerifyType.SelectedValue.ToString());

        if (dsDedup.Tables[0].Rows.Count > 0)
        {
            gvIDOCDedup.Visible = true;
            gvIDOCDedup.PageIndex = e.NewPageIndex;
            gvIDOCDedup.DataSource = dsDedup;
            gvIDOCDedup.DataBind();
        }
        else
        {
            gvIDOCDedup.Visible = false;
            lblMsg.Visible = true;
            lblMsg.Text = "No record found.";
        }
        
    }
    protected void gvIDOCDedup_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "ShowDetail")
        {
            GridViewRow row = ((GridViewRow)(((Control)(e.CommandSource)).NamingContainer));
            string sCaseID = gvIDOCDedup.Rows[row.RowIndex].Cells[0].Text.Trim(); 
            string sVerifyTypeId = e.CommandArgument.ToString();
            string sName = txtName.Text.Trim();
            string sDOB = txtDOB.Text.Trim();
            
            switch (sVerifyTypeId)
            {
                case "6":   //ITR
                    Response.Redirect("IDOC_DV_ITR.aspx?CaseID=" + sCaseID + "&VerTypeId=" + sVerifyTypeId + "&Name=" + sName + "&DOB=" + sDOB + "&VerificationTypeId=" + ddlVerifyType.SelectedValue.ToString() + "&Op=search");
                    break;
                case "7":   //Bank Statement
                    Response.Redirect("IDOC_BankStatementVerification.aspx?CaseID=" + sCaseID + "&VerTypeId=" + sVerifyTypeId + "&Name=" + sName + "&DOB=" + sDOB + "&VerificationTypeId=" + ddlVerifyType.SelectedValue.ToString() + "&Op=search");
                    break;
                case "5":   //Salary Slip
                    Response.Redirect("IDOC_F16.aspx?CaseID=" + sCaseID + "&VerTypeId=" + sVerifyTypeId + "&Name=" + sName + "&DOB=" + sDOB + "&VerificationTypeId=" + ddlVerifyType.SelectedValue.ToString() + "&Op=search");
                    break;
                case "8":   //F16
                    Response.Redirect("IDOC_F16.aspx?CaseID=" + sCaseID + "&VerTypeId=" + sVerifyTypeId + "&Name=" + sName + "&DOB=" + sDOB + "&VerificationTypeId=" + ddlVerifyType.SelectedValue.ToString() + "&Op=search");
                    break;
                case "9":   //RC
                    Response.Redirect("IDOC_RCVerification.aspx?CaseID=" + sCaseID + "&VerTypeId=" + sVerifyTypeId + "&Name=" + sName + "&DOB=" + sDOB + "&VerificationTypeId=" + ddlVerifyType.SelectedValue.ToString() + "&Op=search");
                    break;
                case "11":   //Salary Certificate
                    Response.Redirect("IDOC_F16.aspx?CaseID=" + sCaseID + "&VerTypeId=" + sVerifyTypeId + "&Name=" + sName + "&DOB=" + sDOB + "&VerificationTypeId=" + ddlVerifyType.SelectedValue.ToString() + "&Op=search");
                    break;
                default:
                    lblMsg.Visible = true;
                    lblMsg.Text = "Verification of this case is not done.";
                    break;
            }
        }
    }
}

