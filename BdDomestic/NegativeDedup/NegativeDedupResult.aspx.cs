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

public partial class NegativeDedup_NegativeDedupResult : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            FillActivity();
        }
    }

    private void FillActivity()
    {
        try
        {
            CCommon objCmn = new CCommon();
            DataSet dsActivity = new DataSet();
            string sSql = "SELECT '0' AS ACTIVITY_ID,'-Select-' AS ACTIVITY_NAME FROM ACTIVITY_MASTER  UNION " +
                          "SELECT ACTIVITY_ID,ACTIVITY_NAME FROM ACTIVITY_MASTER WHERE ACTIVITY_ID IS NOT NULL ORDER BY ACTIVITY_ID,ACTIVITY_NAME";
            dsActivity = OleDbHelper.ExecuteDataset(objCmn.ConnectionString, CommandType.Text, sSql);

            if (dsActivity.Tables[0].Rows.Count > 0)
            {
                ddlActivity.DataSource = dsActivity;

                ddlActivity.DataTextField = "ACTIVITY_NAME";
                ddlActivity.DataValueField = "ACTIVITY_ID";
                ddlActivity.DataBind();
            }
            dsActivity.Clear();
            dsActivity.Dispose();
        }
        catch (Exception ex)
        {
            lblMsg.Visible = true;
            lblMsg.Text = "Error while fill Activity dropdown: " + ex.Message;
        }
    }

    private void FillProduct(string strActivityId)
    {
        try
        {
            CCommon objCmn = new CCommon();
            DataSet dsProduct = new DataSet();
            string sSql = "SELECT '0' AS PRODUCT_ID,'-Select-' AS PRODUCT_NAME FROM PRODUCT_MASTER UNION " +
                          "SELECT DISTINCT [PRODUCT_ID],[PRODUCT_NAME] FROM [CE_AC_PR_CT_VW] " +
                          " WHERE [ACTIVITY_ID]='" + strActivityId + "' AND PRODUCT_ID IS NOT NULL " +
                          " ORDER BY PRODUCT_ID,PRODUCT_NAME ";

            dsProduct = OleDbHelper.ExecuteDataset(objCmn.ConnectionString, CommandType.Text, sSql);

            if (dsProduct.Tables[0].Rows.Count > 0)
            {
                ddlProduct.DataSource = dsProduct;
                ddlProduct.DataTextField = "PRODUCT_NAME";
                ddlProduct.DataValueField = "PRODUCT_ID";
                ddlProduct.DataBind();
            }
            dsProduct.Clear();
            dsProduct.Dispose();
        }
        catch (Exception ex)
        {
            lblMsg.Visible = true;
            lblMsg.Text = "Error while fill Product dropdown: " + ex.Message;
        }
    }

    private void FillCentre(string strProductiD)
    {
        try
        {
            CCommon objCmn = new CCommon();
            DataSet dsCentre = new DataSet();
            string sSql = "SELECT '0' AS CENTRE_ID,'-Select-' AS CENTRE_NAME UNION " +
                         "SELECT '1' AS CENTRE_ID,'-All-' AS CENTRE_NAME FROM ce_ac_pr_ct_vw UNION " +
                         "SELECT CENTRE_ID,CENTRE_NAME FROM ce_ac_pr_ct_vw " +
                         "WHERE PRODUCT_ID='" + strProductiD + "' " +
                         "AND CENTRE_ID IS NOT NULL ORDER BY CENTRE_ID,CENTRE_NAME ";
            dsCentre = OleDbHelper.ExecuteDataset(objCmn.ConnectionString, CommandType.Text, sSql);

            if (dsCentre.Tables[0].Rows.Count > 0)
            {
                ddlCentre.DataSource = dsCentre;
                ddlCentre.DataTextField = "CENTRE_NAME";
                ddlCentre.DataValueField = "CENTRE_ID";
                ddlCentre.DataBind();
            }
            dsCentre.Clear();
            dsCentre.Dispose();
        }
        catch (Exception ex)
        {
            lblMsg.Visible = true;
            lblMsg.Text = "Error while fill Centre dropdown: " + ex.Message;
        }
    }

    protected void ddlActivity_SelectedIndexChanged(object sender, EventArgs e)
    {
        FillProduct(ddlActivity.SelectedValue.ToString());
    }
    protected void ddlProduct_SelectedIndexChanged(object sender, EventArgs e)
    {
        FillCentre(ddlProduct.SelectedValue.ToString());
    }
    protected void ddlCentre_SelectedIndexChanged(object sender, EventArgs e)
    {
        btnShowCompletedCases.Visible = true;
    }

    private DataSet GetAllRecords()
    {
        DataSet dsImportCases = new DataSet();
        try
        {
            CCommon objCmn = new CCommon();
            string strProduct = "";
            strProduct = ddlProduct.SelectedItem.ToString();
            string strCaseRecdDate = "";
            strCaseRecdDate = Convert.ToDateTime(objCmn.strDate(txtRecdDate.Text.Trim())).AddDays(1.0).ToString("dd-MMM-yyyy");
            string sSql = "";
            string strTableName = "";

            switch (strProduct)
            {
                case "CC":
                    strTableName = "CPV_CC_CASE_DETAILS CD";
                    break;
                case "IDOC":
                    strTableName = "CPV_IDOC_CASE_DETAILS CD";
                    break;
                case "RL":
                    strTableName = "CPV_RL_CASE_DETAILS CD";
                    break;
                case "EBC":
                    strTableName = "CPV_EBC_CASE_DETAILS CD";
                    break;
                case "KYC":
                    strTableName = "CPV_KYC_CASE_DETAILS CD";
                    break;
                case "CELLULAR":
                    strTableName = "CPV_CELLULAR_CASES CD";
                    break;
                default:
                    break;
            }
            sSql = "SELECT DISTINCT A.CASE_REC_DATETIME,A.CASES, A.ClientId, A.Client, A.CENTREID, A.Centre,A.Product,A.UID, " +
                   " CASE WHEN N.DEDUP_STATUS is null THEN 'Pending' ELSE 'Complete' END as CheckStatus FROM( " +
                   " SELECT CM.CENTRE_ID AS CENTREID,'" + strProduct + "' AS PRODUCT, '" + Session["UserId"].ToString() + "' as UID, " +
                   " CM.CENTRE_NAME AS Centre,COUNT(CASE_ID) as Cases, CL.CLIENT_ID as ClientId,CL.CLIENT_NAME as Client," +
                   " CD.CASE_REC_DATETIME FROM " + strTableName +
                   " LEFT OUTER JOIN CENTRE_MASTER CM ON CD.CENTRE_ID=CM.CENTRE_ID " +
                   " LEFT OUTER JOIN CLIENT_MASTER CL ON CD.CLIENT_ID=CL.CLIENT_ID " +
                   " WHERE SEND_DATETIME IS NULL AND" +
                   " CASE_REC_DATETIME>='" + objCmn.strDate(txtRecdDate.Text.Trim()) + "'" +
                   " AND CASE_REC_DATETIME<'" + strCaseRecdDate + "'";


            if (ddlCentre.SelectedValue.ToString() != "1")
                sSql += " AND CD.CENTRE_ID='" + ddlCentre.SelectedValue.ToString() + "'";

            sSql += " GROUP BY CM.CENTRE_NAME,CL.CLIENT_NAME,CD.CASE_REC_DATETIME,CM.CENTRE_ID,CL.CLIENT_ID) A ";

            sSql += " LEFT OUTER JOIN NEGTIVE_DEDUP_LOG N ON N.CLIENT_ID=A.ClientId AND N.CENTRE_ID=A.CentreId WHERE N.DEDUP_STATUS='C' ";
            
            dsImportCases = OleDbHelper.ExecuteDataset(objCmn.ConnectionString, CommandType.Text, sSql);
                        
        }
        catch (Exception ex)
        {
            lblMsg.Visible = true;
            lblMsg.Text = "Error while retrieving data: " + ex.Message;
        }        
        return dsImportCases;
    }

    protected void btnShowCompletedCases_Click(object sender, EventArgs e)
    {
        try
        {
            DataSet ds = new DataSet();
            ds = GetAllRecords();
            if (ds.Tables[0].Rows.Count > 0)
            {
                lblMsg.Visible = false;
                lblMsg.Text = "";
                gvImportCases.Visible = true;
                gvImportCases.DataSource = ds;
                gvImportCases.DataBind();
            }
            else
            {
                gvImportCases.Visible = false;
                lblMsg.Visible = true;
                lblMsg.Text = "Record not found.";
            }
            ds.Clear();
            ds.Dispose();
        }
        catch (Exception ex)
        {
            lblMsg.Visible = true;
            lblMsg.Text = "Error while searching completed cases: " + ex.Message;
        }
    }

    protected void gvImportCases_Sorting(object sender, GridViewSortEventArgs e)
    {
        try
        {
            DataSet ds = new DataSet();
            ds = GetAllRecords();
            if (ds.Tables[0].Rows.Count > 0)
            {
                DataView dv = new DataView(ds.Tables[0]);
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
                gvImportCases.DataSource = dv;
                gvImportCases.DataBind();
            }
            ds.Clear();
            ds.Dispose();
        }
        catch (Exception ex)
        {
            lblMsg.Visible = true;
            lblMsg.Text = "Error while sortin import cases: " + ex.Message;
        }
    }
    protected void gvImportCases_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            gvImportCases.PageIndex = e.NewPageIndex;
            gvImportCases.DataSource = GetAllRecords();
            gvImportCases.DataBind();
        }
        catch (Exception ex)
        {
            lblMsg.Visible = true;
            lblMsg.Text = "Error while paging import cases: " + ex.Message;
        }
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
    protected void cv_ServerValidate(object source, ServerValidateEventArgs args)
    {
        if (source.ToString() == "0")
        {
            lblMsg.Visible = true;
            lblMsg.Text = "Please select Product.";
        }
    }
}
