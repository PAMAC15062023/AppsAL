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

public partial class NegativeDedup_NegativeDedupRemarkUpdation : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            FillProduct();
        }
    }

    #region Property Declaration
    private string sCaseID;
    public string CaseID
    {
        get { return sCaseID; }
        set { sCaseID = value; }
    }

    private string sDedupRemark;
    public string DedupRemark
    {
        get { return sDedupRemark; }
        set { sDedupRemark = value; }
    }

    private DateTime dtDedupEntryDate;
    public DateTime DedupEntryDate
    {
        get { return dtDedupEntryDate; }
        set { dtDedupEntryDate = value; }
    }
    #endregion

    private void FillProduct()
    {
        try
        {
            CCommon objCmn = new CCommon();
            DataSet dsProduct = new DataSet();
            string sSql = "SELECT '0' AS PRODUCT_ID,'-Select-' AS PRODUCT_NAME FROM PRODUCT_MASTER UNION " +
                          "SELECT PRODUCT_ID,PRODUCT_NAME FROM PRODUCT_MASTER WHERE PRODUCT_ID IS NOT NULL " +
                          "ORDER BY PRODUCT_ID,PRODUCT_NAME ";

            dsProduct = OleDbHelper.ExecuteDataset(objCmn.ConnectionString, CommandType.Text, sSql);

            if (dsProduct.Tables[0].Rows.Count > 0)
            {
                ddlProduct.DataSource = dsProduct;
                ddlProduct.DataTextField = "PRODUCT_NAME";
                ddlProduct.DataValueField = "PRODUCT_ID";
                ddlProduct.DataBind();

                ddlSearchProduct.DataSource = dsProduct;
                ddlSearchProduct.DataTextField = "PRODUCT_NAME";
                ddlSearchProduct.DataValueField = "PRODUCT_ID";
                ddlSearchProduct.DataBind();
            }
            dsProduct.Clear();
            dsProduct.Dispose();
        }
        catch (Exception ex)
        {
            lblMSg.Visible = true;
            lblMSg.Text = "Error while fill Product dropdown: " + ex.Message;
        }
    }    

    private void FillCentre(string strProductiD)
    {
        try
        {
            CCommon objCmn = new CCommon();
            DataSet dsCentre = new DataSet();
            string sSql = "SELECT '0' AS CENTRE_ID,'-All-' AS CENTRE_NAME FROM ce_ac_pr_ct_vw UNION " +
                          "SELECT CENTRE_ID,CENTRE_NAME FROM ce_ac_pr_ct_vw " +
                          "WHERE PRODUCT_ID='" + strProductiD + "' AND CENTRE_ID IS NOT NULL " +
                          "ORDER BY CENTRE_ID,CENTRE_NAME";

            dsCentre = OleDbHelper.ExecuteDataset(objCmn.ConnectionString, CommandType.Text, sSql);

            if (dsCentre.Tables[0].Rows.Count > 0)
            {
                ddlSearchCentre.DataSource = dsCentre;
                ddlSearchCentre.DataTextField = "CENTRE_NAME";
                ddlSearchCentre.DataValueField = "CENTRE_ID";
                ddlSearchCentre.DataBind();
            }
            dsCentre.Clear();
            dsCentre.Dispose();
        }
        catch (Exception ex)
        {
            lblMSg.Visible = true;
            lblMSg.Text = "Error while fill Centre dropdown: " + ex.Message;
        }
    }
    protected void ddlSearchProduct_SelectedIndexChanged(object sender, EventArgs e)
    {
        FillCentre(ddlSearchProduct.SelectedValue.ToString());
    }
        
    protected void btnInsert_Click(object sender, EventArgs e)
    {
        try
        {
            string sSql = "";
            CCommon objCmn = new CCommon();
            string strProduct = "";
            strProduct = ddlProduct.SelectedItem.ToString();

            string strTableName = "";

            switch (strProduct)
            {
                case "CC":
                    strTableName = "CPV_CC_CASE_DETAILS";
                    break;
                case "IDOC":
                    strTableName = "CPV_IDOC_CASE_DETAILS";
                    break;
                case "RL":
                    strTableName = "CPV_RL_CASE_DETAILS";
                    break;
                case "EBC":
                    strTableName = "CPV_EBC_CASE_DETAILS";
                    break;
                case "KYC":
                    strTableName = "CPV_KYC_CASE_DETAILS";
                    break;
                case "CELLULAR":
                    strTableName = "CPV_CELLULAR_CASES";
                    break;
                default:
                    break;
            }
            DedupEntryDate = System.DateTime.Now;
            DedupRemark = txtDedupRemark.Text.Trim();
            CaseID = txtCaseId.Text.Trim();

            sSql = "UPDATE " + strTableName + " SET Neg_Dedup_Remark=?,Neg_Dedup_Date=? WHERE CASE_ID=? ";

            OleDbParameter[] paramDedupRemark = new OleDbParameter[3];

            paramDedupRemark[0] = new OleDbParameter("@DedupRemark", OleDbType.VarChar,2000);
            paramDedupRemark[0].Value = DedupRemark;
            paramDedupRemark[1] = new OleDbParameter("@DedupEntryDate", OleDbType.DBTimeStamp);
            paramDedupRemark[1].Value = DedupEntryDate;
            paramDedupRemark[2] = new OleDbParameter("@CaseID", OleDbType.VarChar);
            paramDedupRemark[2].Value = CaseID;

            if (OleDbHelper.ExecuteNonQuery(objCmn.ConnectionString, CommandType.Text, sSql, paramDedupRemark) == 0)
            {
                lblMSg.Visible = true;
                lblMSg.Text = "Invalid Case Id";
            }
            else
            {
                lblMSg.Visible = true;
                lblMSg.Text = "Record inserted Successfully.";
            }
        }
        catch (Exception ex)
        {
            lblMSg.Visible = true;
            lblMSg.Text = "Error while updating data: " + ex.Message;
        }
    }

    protected void cvProduct_ServerValidate(object source, ServerValidateEventArgs args)
    {
        if (source.ToString() == "0")
        {
            lblMSg.Visible = true;
            lblMSg.Text = "Please select Product.";
        }
    }

    private DataSet BindData()
    {
        DataSet dsDedupRemark = new DataSet();
        try
        {
            string sSql = "";
            CCommon objCmn = new CCommon();
            string strProduct = "";
            strProduct = ddlSearchProduct.SelectedItem.ToString();
            string strNegFDedupDate = "";
            string strNegTDedupDate = "";
            strNegFDedupDate = txtDedupEntryDate.Text.Trim();
            if (txtDedupEntryDate.Text.Trim() != "")
                strNegTDedupDate = Convert.ToDateTime(objCmn.strDate(txtDedupEntryDate.Text.Trim())).AddDays(1.0).ToString("dd-MMM-yyyy");

            string strTableName = "";

            switch (strProduct)
            {
                case "CC":
                    strTableName = "CPV_CC_CASE_DETAILS";
                    break;
                case "IDOC":
                    strTableName = "CPV_IDOC_CASE_DETAILS";
                    break;
                case "RL":
                    strTableName = "CPV_RL_CASE_DETAILS";
                    break;
                case "EBC":
                    strTableName = "CPV_EBC_CASE_DETAILS";
                    break;
                case "KYC":
                    strTableName = "CPV_KYC_CASE_DETAILS";
                    break;
                case "CELLULAR":
                    strTableName = "CPV_CELLULAR_CASES";
                    break;
                default:
                    break;
            }

            sSql = "SELECT CM.CENTRE_NAME as Centre,CL.CLIENT_NAME as Client,CD.CASE_ID as CaseId,CD.NEG_DEDUP_DATE as DedupEntryDate,CD.NEG_DEDUP_REMARK aS DedupRemark " +
                 " FROM " + strTableName + " CD " +
                 " LEFT OUTER JOIN CENTRE_MASTER CM ON CD.CENTRE_ID=CM.CENTRE_ID" +
                 " LEFT OUTER JOIN CLIENT_MASTER CL ON CD.CLIENT_ID=CL.CLIENT_ID" +
                 " WHERE CD.NEG_DEDUP_REMARK IS NOT NULL AND CD.NEG_DEDUP_DATE IS NOT NULL ";

            if (ddlSearchCentre.SelectedValue.ToString() != "0")
                sSql += " AND CD.CENTRE_ID='" + ddlSearchCentre.SelectedValue.ToString() + "'";
            if (txtSearchCaseId.Text.Trim() != "")
                sSql += " AND CASE_ID='" + txtSearchCaseId.Text.Trim() + "'";
            if (txtDedupEntryDate.Text.Trim() != "")
                sSql += " AND NEG_DEDUP_DATE>='" + objCmn.strDate(strNegFDedupDate) + "'" +
                         " AND NEG_DEDUP_DATE<'" + strNegTDedupDate + "'";
            
            dsDedupRemark = OleDbHelper.ExecuteDataset(objCmn.ConnectionString, CommandType.Text, sSql);
            
        }
        catch (Exception ex)
        {
            lblSearchMsg.Visible = true;
            lblSearchMsg.Text = "Error while retrieving data: " + ex.Message;
        }
        return dsDedupRemark;
    }

    protected void btnGet_Click(object sender, EventArgs e)
    {
        try
        {
            DataSet ds = new DataSet();
            ds = BindData();
            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    gvDeupRecords.Visible = true;
                    lblSearchMsg.Visible = false;
                    gvDeupRecords.DataSource = ds;
                    gvDeupRecords.DataBind();
                }
                else
                {
                    gvDeupRecords.Visible = false;
                    lblSearchMsg.Visible = true;
                    lblSearchMsg.Text = "Record not found.";
                }
            }
            else
            {
                gvDeupRecords.Visible = false;
                lblSearchMsg.Visible = true;
                lblSearchMsg.Text = "Record not found.";
            }
            ds.Clear();
            ds.Dispose();
        }        
        catch (Exception ex)
        {
            lblMSg.Visible = true;
            lblMSg.Text = "Error while searching records: " + ex.Message;
        }
    }

    //protected void lnkEditDedupRemark_Click(object sender, EventArgs e)
    //{
    //    CCommon objCmn = new CCommon();
    //    LinkButton Lnkbtn = (sender) as LinkButton;
    //    Label lblCaseId = Lnkbtn.FindControl("lblCaseId") as Label;
    //    string sSql = "";
    //    string strProduct = "";
    //    strProduct = ddlSearchProduct.SelectedItem.ToString();

    //    string strTableName = "";

    //    switch (strProduct)
    //    {
    //        case "CC":
    //            strTableName = "CPV_CC_CASE_DETAILS";
    //            break;
    //        case "IDOC":
    //            strTableName = "CPV_IDOC_CASE_DETAILS";
    //            break;
    //        case "RL":
    //            strTableName = "CPV_RL_CASE_DETAILS";
    //            break;
    //        case "EBC":
    //            strTableName = "CPV_EBC_CASE_DETAILS";
    //            break;
    //        case "KYC":
    //            strTableName = "CPV_KYC_CASE_DETAILS";
    //            break;
    //        case "CELLULAR":
    //            strTableName = "CPV_CELLULAR_CASES";
    //            break;
    //        default:
    //            break;
    //    }
        
    //    DedupRemark = txtDedupRemark.Text.Trim();
    //    CaseID = lblCaseId.Text.Trim();

    //    sSql = "UPDATE " + strTableName + " SET Neg_Dedup_Remark=? WHERE CASE_ID=? ";

    //    OleDbParameter[] paramDedupRemark = new OleDbParameter[2];

    //    paramDedupRemark[0] = new OleDbParameter("@DedupRemark", OleDbType.VarChar);
    //    paramDedupRemark[0].Value = DedupRemark;
    //    paramDedupRemark[1] = new OleDbParameter("@CaseID", OleDbType.VarChar);
    //    paramDedupRemark[1].Value = CaseID;

    //    if (OleDbHelper.ExecuteNonQuery(objCmn.ConnectionString, CommandType.Text, sSql, paramDedupRemark) == 0)
    //    {
    //        lblMSg.Visible = true;
    //        lblMSg.Text = "Invalid Case Id";
    //    }
    //    else
    //    {
    //        lblMSg.Visible = true;
    //        lblMSg.Text = "Record inserted Successfully.";
    //        txtCaseId.Text = "";
    //        txtDedupEntryDate.Text = "";
    //        txtDedupRemark.Text = "";
    //    }
    //}
    
    protected void gvDeupRecords_RowEditing(object sender, GridViewEditEventArgs e)
    {
        try
        {
            gvDeupRecords.EditIndex = e.NewEditIndex;
            DataSet ds = new DataSet();
            ds = BindData();
            if (ds.Tables[0].Rows.Count > 0)
            {
                gvDeupRecords.Visible = true;
                lblSearchMsg.Visible = false;
                gvDeupRecords.DataSource = ds;
                gvDeupRecords.DataBind();
            }
            else
            {
                gvDeupRecords.Visible = false;
                lblSearchMsg.Visible = true;
                lblSearchMsg.Text = "Record not found.";
            }
            ds.Clear();
            ds.Dispose();
        }
        catch (Exception ex)
        {
            lblMSg.Text = "Error while editing the record: " + ex.Message;
            lblMSg.Visible = true;
        }
    }

    protected void gvDeupRecords_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        try
        {
            CCommon objCmn = new CCommon();
            string sSql = "";
            GridViewRow row = gvDeupRecords.Rows[e.RowIndex];
            if (row != null)
            {
                Label lblCaseID = ((Label)row.FindControl("lblCaseId"));
                TextBox txtDedupRemark = ((TextBox)row.FindControl("txtDedupRemark"));
                string strProduct = "";
                strProduct = ddlSearchProduct.SelectedItem.ToString();
                string strTableName = "";

                switch (strProduct)
                {
                    case "CC":
                        strTableName = "CPV_CC_CASE_DETAILS";
                        break;
                    case "IDOC":
                        strTableName = "CPV_IDOC_CASE_DETAILS";
                        break;
                    case "RL":
                        strTableName = "CPV_RL_CASE_DETAILS";
                        break;
                    case "EBC":
                        strTableName = "CPV_EBC_CASE_DETAILS";
                        break;
                    case "KYC":
                        strTableName = "CPV_KYC_CASE_DETAILS";
                        break;
                    case "CELLULAR":
                        strTableName = "CPV_CELLULAR_CASES";
                        break;
                    default:
                        break;
                }
                CaseID = lblCaseID.Text.Trim().ToString();
                DedupRemark = txtDedupRemark.Text.ToString();

                sSql = "UPDATE " + strTableName + " SET Neg_Dedup_Remark=? WHERE CASE_ID=? ";

                OleDbParameter[] paramDedupRemark = new OleDbParameter[2];

                paramDedupRemark[0] = new OleDbParameter("@DedupRemark", OleDbType.VarChar);
                paramDedupRemark[0].Value = DedupRemark;
                paramDedupRemark[1] = new OleDbParameter("@CaseID", OleDbType.VarChar);
                paramDedupRemark[1].Value = CaseID;

                OleDbHelper.ExecuteNonQuery(objCmn.ConnectionString, CommandType.Text, sSql, paramDedupRemark);
                DataSet ds = new DataSet();
                ds = BindData();
                gvDeupRecords.EditIndex = -1;
                gvDeupRecords.DataSource = ds;
                gvDeupRecords.DataBind();
                ds.Clear();
                ds.Dispose();
            }
        }
        catch (Exception ex)
        {
            lblSearchMsg.Visible = true;
            lblSearchMsg.Text = "Error while updating record. : " + ex.Message;
        }   
    }

    protected void gvDeupRecords_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        try
        {
            gvDeupRecords.EditIndex = -1;
            DataSet ds = new DataSet();
            ds = BindData();
            gvDeupRecords.DataSource = ds;
            gvDeupRecords.DataBind();
            ds.Clear();
            ds.Dispose();
        }
        catch (Exception ex)
        {
            lblMSg.Visible = true;
            lblMSg.Text = "Error while canceling the record: " + ex.Message;
        }
    }
    protected void gvDeupRecords_Sorting(object sender, GridViewSortEventArgs e)
    {
        try
        {
            DataSet ds = new DataSet();
            ds = BindData();
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
                gvDeupRecords.DataSource = dv;
                gvDeupRecords.DataBind();
            }
            ds.Clear();
            ds.Dispose();
        }
        catch (Exception ex)
        {
            lblMSg.Visible = true;
            lblMSg.Text = "Error while sorting the records: " + ex.Message;
        }
    }
    protected void gvDeupRecords_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            gvDeupRecords.PageIndex = e.NewPageIndex;
            DataSet ds = new DataSet();
            ds = BindData();
            gvDeupRecords.DataSource = ds;
            gvDeupRecords.DataBind();
            ds.Clear();
            ds.Dispose();
        }
        catch (Exception ex)
        {
            lblMSg.Visible = true;
            lblMSg.Text = "Error while paging the records: " + ex.Message;
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
}
