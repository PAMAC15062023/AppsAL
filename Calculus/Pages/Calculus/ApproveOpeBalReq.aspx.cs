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
using System.IO;

public partial class Pages_Calculus_ApproveOpeBalReq : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                Get_BranchId();
                RegisterControls_WithJavascript();
                BindStatus();
            }
        }
        catch (Exception ex)
        {
            lblMessage.Visible = true;
            lblMessage.Text = ex.Message;
            lblMessage.CssClass = "ErrorMessage";
        }
    }
    protected void BindStatus()
    {
        Common common = new Common();
        DataSet ds = new DataSet();

        ds = common.GetCalOnlineTransMasterSearchCode("ARStatus", 1);
        if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            ddlStatus.DataSource = ds;
            ddlStatus.DataValueField = "Code_Id";
            ddlStatus.DataTextField = "Description";
            ddlStatus.DataBind();
            ddlStatus.Items.Insert(0, new ListItem("All", "0"));
        }
    }
    private void Get_BranchId()
    {
        try
        {
            SqlConnection sqlcon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);

            sqlcon.Open();
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlcon;
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.CommandText = "CalOnlineTrans_Get_All_Branch_List_SP";
            SqlDataAdapter sqlda = new SqlDataAdapter();
            sqlda.SelectCommand = sqlcmd;
            DataTable dt = new DataTable();
            sqlda.Fill(dt);
            sqlcon.Close();

            ddlBranchID.DataTextField = "BranchName";
            ddlBranchID.DataValueField = "BranchId";
            ddlBranchID.DataSource = dt;
            ddlBranchID.DataBind();

            ddlBranchID.Items.Insert(0, "-All-");
            ddlBranchID.SelectedIndex = 0;

        }
        catch (Exception ex)
        {
            lblMessage.Visible = true;
            lblMessage.Text = ex.Message;
            lblMessage.CssClass = "ErrorMessage";
        }
    }

    protected void GridApproval_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            CheckBox chkSelect = (CheckBox)e.Row.FindControl("chkSelect");
            chkSelect.Attributes.Add("onclick", "javascript:checkSelected('" + chkSelect.ClientID + "');");
 
        }

    }

    private void RegisterControls_WithJavascript()
    {
        btnAccept.Attributes.Add("onclick", "javascript:return Get_SelectedTransactionID(1);");
        btnReject.Attributes.Add("onclick", "javascript:return Get_SelectedTransactionID(1);");
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        InsertApprovalDataIntoGrid();
    }
    protected void btnReset_Click(object sender, EventArgs e)
    {
       ddlBranchID.SelectedIndex=0;
       ddlStatus.SelectedIndex = 0;

    }
    private void InsertApprovalDataIntoGrid()
    {
         Object SaveUSERInfo = (Object)Session["UserInfo"];

        SqlConnection sqlCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);

        sqlCon.Open();
        SqlCommand sqlCom = new SqlCommand();
        sqlCom.Connection = sqlCon;
        sqlCom.CommandType = CommandType.StoredProcedure;
        sqlCom.CommandText = "CalOnlineTrans_GetApproveOpeningBalanceDataNew_SP";

        int intBranchID = 0;
        if (ddlBranchID.SelectedIndex != 0)
        {
            intBranchID = Convert.ToInt32(ddlBranchID.SelectedItem.Value);
        }
        SqlParameter BranchId = new SqlParameter();
        BranchId.SqlDbType = SqlDbType.Int;
        BranchId.Value = intBranchID;
        BranchId.ParameterName = "@BranchId";
        sqlCom.Parameters.Add(BranchId);

        SqlParameter Status = new SqlParameter();
        Status.SqlDbType = SqlDbType.Int;
        Status.Value = ddlStatus.SelectedItem.Value;
        Status.ParameterName = "@Status";
        sqlCom.Parameters.Add(Status);


        #region Code By Amrita on 22-Apr-2014 As per Client Requirement
        SqlParameter ClientId = new SqlParameter();
        ClientId.SqlDbType = SqlDbType.Int;
        ClientId.Value = Convert.ToInt32(((UserInfo.structUSERInfo)(SaveUSERInfo)).ClientId);
        ClientId.ParameterName = "@ClientId";
        sqlCom.Parameters.Add(ClientId);
        #endregion

        SqlDataAdapter sqlDA = new SqlDataAdapter();
        sqlDA.SelectCommand = sqlCom;
        DataTable dt = new DataTable();
        sqlDA.Fill(dt);
        sqlCon.Close();
        if (dt.Rows.Count > 0)
        {
            GridApproval.DataSource = dt;
            GridApproval.DataBind();
            lblMessage.Text = "Total Records Found " + dt.Rows.Count;
            lblMessage.CssClass = "UpdateMessage";
        }
        else
        {
            GridApproval.DataSource = null;
            GridApproval.DataBind();
            lblMessage.Text = "No Records found!";
            lblMessage.CssClass = "ErrorMessage";
        }
    }
    protected void btnAccept_Click(object sender, EventArgs e)
    {
        bool isValid = false;
        foreach (GridViewRow row in GridApproval.Rows)
        {
            CheckBox chkSelect = (CheckBox)row.FindControl("chkSelect");
            if (chkSelect.Checked)
            {
                isValid = true;
                HiddenField hdfOperationID = (HiddenField)row.FindControl("hdfOperationID");
                hdnOperationID.Value = hdfOperationID.Value;
                break;
            }
        }
        if (isValid == false)
        {
            lblMessage.Text = "Please select atleast one record to continue! ";
            lblMessage.CssClass = "UpdateMessage";

            return;
        }
        else
        {
            AcceptPendingCases(2);
        }
    }

    private void AcceptPendingCases(int pStatus)
    {

        hdnOperationID.Value =  hdnOperationID.Value;



        Object SaveUSERInfo = (Object)Session["UserInfo"];

        SqlConnection sqlCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);

        sqlCon.Open();
        SqlCommand sqlCmd = new SqlCommand();
        sqlCmd.Connection = sqlCon;
        sqlCmd.CommandType = CommandType.StoredProcedure;
        sqlCmd.CommandText = "CalOnlineTrans_UpdateOpeningBalanceAcceptedNew_SP";
        sqlCmd.CommandTimeout = 0;


        SqlParameter RequestID = new SqlParameter();
        RequestID.SqlDbType = SqlDbType.Int;
        RequestID.Value = hdnOperationID.Value;
        RequestID.ParameterName = "@RequestID";
        sqlCmd.Parameters.Add(RequestID);

        SqlParameter Status = new SqlParameter();
        Status.SqlDbType = SqlDbType.Int;
        Status.Value = pStatus;
        Status.ParameterName = "@Status";
        sqlCmd.Parameters.Add(Status);

        #region Code By Amrita on 22-Apr-2014 As per Client Requirement
        SqlParameter ClientId = new SqlParameter();
        ClientId.SqlDbType = SqlDbType.Int;
        ClientId.Value = Convert.ToInt32(((UserInfo.structUSERInfo)(SaveUSERInfo)).ClientId);
        ClientId.ParameterName = "@ClientId";
        sqlCmd.Parameters.Add(ClientId);
        #endregion


        SqlParameter UserID = new SqlParameter();
        UserID.SqlDbType = SqlDbType.VarChar;
        UserID.Value = Convert.ToString(((UserInfo.structUSERInfo)(SaveUSERInfo)).UserId);
        UserID.ParameterName = "@UserID";
        sqlCmd.Parameters.Add(UserID);

        int SqlRow = 0;
        SqlRow = sqlCmd.ExecuteNonQuery();

        if (SqlRow > 0)
        {
            lblMessage.Text = "Update Successfully!";
            lblMessage.CssClass = "UpdateMessage";
            lblMessage.Visible = true;
         }

        InsertApprovalDataIntoGrid();
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Pages/Menu.aspx", true);
    }
    protected void btnReject_Click(object sender, EventArgs e)
    {
        bool isValid = false;
        foreach (GridViewRow row in GridApproval.Rows)
        {
            CheckBox chkSelect = (CheckBox)row.FindControl("chkSelect");
            if (chkSelect.Checked)
            {
                isValid = true;
                HiddenField hdfOperationID = (HiddenField)row.FindControl("hdfOperationID");
                hdnOperationID.Value = hdfOperationID.Value;
                break;
            }
        }
        if (isValid == false)
        {
            lblMessage.Text = "Please select atleast one record to continue! ";
            lblMessage.CssClass = "UpdateMessage";

            return;
        }
        else
        {
            AcceptPendingCases(3);
        }
       
    }
}
