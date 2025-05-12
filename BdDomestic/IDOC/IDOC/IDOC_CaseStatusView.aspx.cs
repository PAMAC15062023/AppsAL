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

public partial class IDOC_IDOC_IDOC_CaseStatusView : System.Web.UI.Page
{
    CCommon objCmn = new CCommon();
    protected void Page_Load(object sender, EventArgs e)
    {
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        try
        {
            DataSet dsSearch = new DataSet();

            dsSearch = GetAutoDedup(txtCaseID.Text.Trim(), txtRefNo.Text.Trim(), txtApplicantName.Text.Trim());

             if (dsSearch.Tables[0].Rows.Count > 0)
            {
                gvIDOCDedup.Visible = true;
                gvIDOCDedup.DataSource = dsSearch;
                gvIDOCDedup.DataBind();
                lblMessage.Visible = false;
            }
            else
            {
                gvIDOCDedup.Visible = false;
                lblMessage.Visible = true;
                lblMessage.Text = "No record found.";
            }
        }
        catch (Exception exp)
        {
            lblMessage.Text = exp.Message;
        }

    }

    private DataSet GetAutoDedup(string sCaseId, string sRefNo,string strApplicantName )
    {
       
        string sSql = "";

        sSql = "SELECT CD.CASE_ID,CD.REF_NO,client_name,convert(varchar,CASE_REC_DATETIME,103) as [RECD DATE]," +
                        " (ISNULL(CD.TITLE,'')+' '+ ISNULL(CD.FIRST_NAME,'')+' ' + " +
                        " ISNULL(CD.MIDDLE_NAME,'')+' ' +ISNULL(CD.LAST_NAME,'')) AS APPLICANT_NAME, " +
                        " DOB,VM.VERIFICATION_TYPE,VM.VERIFICATION_TYPE_ID,STATUS_NAME " +
                        " FROM CPV_IDOC_CASE_DETAILS CD LEFT OUTER JOIN CPV_IDOC_VERIFICATION CV ON CD.CASE_ID=CV.CASE_ID " +
                        " LEFT OUTER JOIN VERIFICATION_TYPE_MASTER VM ON CV.VERIFICATION_TYPE_ID=VM.VERIFICATION_TYPE_ID " +
                        " LEFT OUTER JOIN CASE_STATUS_MASTER CSM ON CSM.CASE_STATUS_ID=CV.CASE_STATUS_ID left outer join client_master cm on(cm.client_id=cd.client_id) WHERE 1=1 ";

        if (sCaseId != "")
        {
            sSql += " AND CD.CASE_ID='" + sCaseId + "'";
        }
       

        if (sRefNo != "")
            sSql += " AND CD.REF_NO='" + sRefNo + "'";
            
        if (strApplicantName != "")
            sSql += " AND (ISNULL(CD.FIRST_NAME,'')+' ' + ISNULL(CD.MIDDLE_NAME,'')+' ' +ISNULL(CD.LAST_NAME,'')) LIKE '%" + strApplicantName + "%'";
        sSql += " AND CD.CENTRE_ID='" + Session["CentreId"].ToString() + "'";
        //commented by hemangi kambli on 02/08/2007 --as per discussion ------
        sSql += " AND CD.CLIENT_ID='" + Session["ClientId"].ToString() + "'"; 

        sSql += " ORDER BY CD.CASE_ID";
        return OleDbHelper.ExecuteDataset(objCmn.ConnectionString, CommandType.Text, sSql);

        

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
        DataSet dsSearch = new DataSet();

        dsSearch = GetAutoDedup(txtCaseID.Text.Trim(), txtRefNo.Text.Trim(), txtApplicantName.Text.Trim());

        if (dsSearch.Tables[0].Rows.Count > 0)
        {
            DataView dv = new DataView(dsSearch.Tables[0]);
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
       try
       {
        DataSet dsSearch = new DataSet();

        dsSearch = GetAutoDedup(txtCaseID.Text.Trim(), txtRefNo.Text.Trim(), txtApplicantName.Text.Trim());

        if (dsSearch.Tables[0].Rows.Count > 0)
        {
            gvIDOCDedup.Visible = true;
            gvIDOCDedup.PageIndex = e.NewPageIndex;
            gvIDOCDedup.DataSource = dsSearch;
            gvIDOCDedup.DataBind();
        }
        else
        {
            gvIDOCDedup.Visible = false;
            lblMessage.Visible = true;
            lblMessage.Text = "No record found.";
        }
        }
        catch (Exception exp)
        {
            lblMessage.Text = exp.Message;
        }

    }
    protected void gvIDOCDedup_RowCommand(object sender, GridViewCommandEventArgs e)
   {
   }
    //Added By : Gargi Srivastava
    //Purpose  : For Opening the Pop up
    //Added Date: 11-Dec-2007
    protected void gvIDOCDedup_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
           
            foreach (GridViewRow row in gvIDOCDedup.Rows)
            {
              
                string sCaseID = gvIDOCDedup.Rows[row.RowIndex].Cells[0].Text.Trim();
                HiddenField hdnVerificationTypeID = (HiddenField)gvIDOCDedup.Rows[row.RowIndex].Cells[8].FindControl("hdnVerificationTypeID");
                string sVerifyTypeId = hdnVerificationTypeID.Value;
                string strApplicantName = txtApplicantName.Text.Trim();
                Label lblShowDetail = (Label)gvIDOCDedup.Rows[row.RowIndex].Cells[8].FindControl("lblShowDetail");
                
                
                switch (sVerifyTypeId)
                {

                    case "6":   //ITR
                        string str = "IDOC_DV_ITR.aspx?CaseID=" + sCaseID + "&VerTypeId=" + sVerifyTypeId + "&Name=" + strApplicantName + "&Op=View";
                        lblShowDetail.Text = "<A href='#' onClick=winOpen('" + str + "')>MoreDetails</A>";
                        lblShowDetail.Visible = true;
                        lblMessage.Visible = false;
                        
                        break;
                    
                    case "7":   //Bank Statement
                        string str1 = "IDOC_BankStatementVerification.aspx?CaseID=" + sCaseID + "&VerTypeId=" + sVerifyTypeId + "&Name=" + strApplicantName + "&Op=View";
                        lblShowDetail.Text = "<A href='#' onClick=winOpen('" + str1 + "')>MoreDetails</A>";
                        lblShowDetail.Visible = true;
                        lblMessage.Visible = false;
                        
                        break;
                    case "5":   //Salary Slip
                        string str2 = "IDOC_F16.aspx?CaseID=" + sCaseID + "&VerTypeId=" + sVerifyTypeId + "&Name=" + strApplicantName + "&Op=View";
                        lblShowDetail.Text = "<A href='#' onClick=winOpen('" + str2 + "')>MoreDetails</A>";
                        lblShowDetail.Visible = true;
                        lblMessage.Visible = false;
                        
                        break;
                    case "8":   //F16
                        string str3 = "IDOC_F16.aspx?CaseID=" + sCaseID + "&VerTypeId=" + sVerifyTypeId + "&Name=" + strApplicantName + "&Op=View";
                        lblShowDetail.Text = "<A href='#' onClick=winOpen('" + str3 + "')>MoreDetails</A>";
                        lblShowDetail.Visible = true;
                        lblMessage.Visible = false;
                        
                        break;
                    case "9":   //RC
                        string str4 = "IDOC_RCVerification.aspx?CaseID=" + sCaseID + "&VerTypeId=" + sVerifyTypeId + "&Name=" + strApplicantName + "&Op=View";
                        lblShowDetail.Text = "<A href='#' onClick=winOpen('" + str4 + "')>MoreDetails</A>";
                        lblShowDetail.Visible = true;
                        lblMessage.Visible = false;
                        
                        break;
                    case "11":   //Salary Certificate
                        string str5 = "IDOC_F16.aspx?CaseID=" + sCaseID + "&VerTypeId=" + sVerifyTypeId + "&Name=" + strApplicantName + "&Op=View";
                        lblShowDetail.Text = "<A href='#' onClick=winOpen('" + str5 + "')>MoreDetails</A>";
                        lblShowDetail.Visible = true;
                        lblMessage.Visible = false;
                       
                        break;
                    default:
                        lblMessage.Visible = true;
                        lblMessage.Text = "Verification of this case is not done.";
                        break;
                }
               
            }
           
        }

        catch (Exception exp)
        {
            lblMessage.Text = exp.Message;
        }

       
    }
    //End
}
