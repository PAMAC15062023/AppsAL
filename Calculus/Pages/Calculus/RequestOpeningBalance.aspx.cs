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

public partial class Pages_Calculus_Opening_Balance : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                Get_BranchIDInfo();
                Get_GridOpeningBalanceData();
                Register_Validation_On_Field();
                Get_BranchList();
                BindYear();
                BindMonth();
            }
        }
        catch (Exception ex)
        {
            lblMessage.Visible = true;
            lblMessage.Text = ex.Message;
            lblMessage.CssClass = "ErrorMessage";


        }
    }
    void BindYear()
    {
        DataSet dsYear = new DataSet();
        Common common = new Common();
        dsYear = common.GetCalOnlineTransMasterSearchCode("YearType", 1);
        if (dsYear.Tables.Count > 0 && dsYear.Tables[0].Rows.Count > 0)
        {
            ddlYear.DataSource = dsYear;
            ddlYear.DataValueField = "Code_Id";
            ddlYear.DataTextField = "Description";
            ddlYear.DataBind();
            ddlYear.Items.Insert(0, new ListItem("--Select--", "0"));
        }

    }
    protected void BindMonth()
    {
        Common common = new Common();
        DataSet ds = new DataSet();

        ds = common.GetCalOnlineTransMasterSearchCode("MonthType", 1);
        if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            ddlMonth.DataSource = ds;
            ddlMonth.DataValueField = "Code_Id";
            ddlMonth.DataTextField = "Description";
            ddlMonth.DataBind();
            ddlMonth.Items.Insert(0, new ListItem("--Select--", "0"));
        }
    }
    private void Register_Validation_On_Field()
    {
        btnSave.Attributes.Add("onclick", "javascript:return Validation_AllField();");
        //btnSave.Attributes.Add("onclick", "javascript:return CheckStatus();");
        ddlYear.Attributes.Add("onblur", "javascript:return dropdown_validator();");
    }

    private void Get_BranchIDInfo()
    {
        Object SaveUSERInfo = (Object)Session["UserInfo"];

        lblBranchName.Text = Convert.ToString(((UserInfo.structUSERInfo)(SaveUSERInfo)).BranchName);

    }

    private void Get_BranchList()
    {
        try
        {

            SqlConnection sqlCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);

            sqlCon.Open();
            SqlCommand sqlCom = new SqlCommand();
            sqlCom.Connection = sqlCon;
            sqlCom.CommandType = CommandType.StoredProcedure;
            sqlCom.CommandText = "CalOnlineTrans_Get_All_Branch_List_SP";
            SqlDataAdapter sqlDA = new SqlDataAdapter();
            sqlDA.SelectCommand = sqlCom;
            DataTable dt = new DataTable();
            sqlDA.Fill(dt);
            sqlCon.Close();

            ddlBranchList.DataTextField = "BranchName";
            ddlBranchList.DataValueField = "BranchId";
            ddlBranchList.DataSource = dt;
            ddlBranchList.DataBind();

            ddlBranchList.Items.Insert(0, "--Select--");
            ddlBranchList.SelectedIndex = 0;

        }
        catch (Exception ex)
        {
            lblMessage.Visible = true;
            lblMessage.Text = ex.Message;
        }
    }

    protected void Gv_Opening_Balance_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Attributes.Add("onclick", "javascript:GV_RowSelection('" + e.Row.RowIndex + "','" + e.Row.Cells[0].Text + "');");

        }

    }

    private void Get_GridOpeningBalanceData()
    {

        try
        {

            Object SaveUSERInfo = (Object)Session["UserInfo"];

            SqlConnection SqlCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);

            SqlCon.Open();
            SqlCommand SqlCmd = new SqlCommand();
            SqlCmd.Connection = SqlCon;
            SqlCmd.CommandType = CommandType.StoredProcedure;
            SqlCmd.CommandText = "CalOnlineTrans_GetRequestOpeningBalanceDataNew_SP";

            SqlParameter BranchID = new SqlParameter();
            BranchID.SqlDbType = SqlDbType.Int;
            BranchID.Value = ((UserInfo.structUSERInfo)(SaveUSERInfo)).BranchId;
            BranchID.ParameterName = "@BranchID";
            SqlCmd.Parameters.Add(BranchID);

            #region Code By Amrita on 22-Apr-2014 As per Client Requirement
            SqlParameter ClientId = new SqlParameter();
            ClientId.SqlDbType = SqlDbType.Int;
            ClientId.Value = Convert.ToInt32(((UserInfo.structUSERInfo)(SaveUSERInfo)).ClientId);
            ClientId.ParameterName = "@ClientId";
            SqlCmd.Parameters.Add(ClientId);
            #endregion


            SqlDataAdapter sqlDA = new SqlDataAdapter();
            sqlDA.SelectCommand = SqlCmd;

            DataTable dt = new DataTable();
            sqlDA.Fill(dt);
            SqlCon.Close();

            Gr_Ope_Bal.DataSource = dt;
            Gr_Ope_Bal.DataBind();
        }
        catch (Exception ex)
        {
            lblMessage.Visible = true;
            lblMessage.Text = ex.Message;
            lblMessage.CssClass = "Error Message";
        }     
    }
    
    protected void btnSave_Click(object sender, EventArgs e)
    {
        Insert_OpeningBalanceData();
        Get_GridOpeningBalanceData();
        ClearAllTextField();

    }

    protected void Insert_OpeningBalanceData()
    {
        Object SaveUSERInfo = (Object)Session["UserInfo"];

        SqlConnection sqlCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);

        sqlCon.Open();
        SqlCommand sqlCmd = new SqlCommand();
        sqlCmd.Connection = sqlCon;
        sqlCmd.CommandType = CommandType.StoredProcedure;
        sqlCmd.CommandText = "CalOnlineTrans_InsertOpeningBalanceRequestNew_SP";

        SqlParameter openingBalanceID = new SqlParameter();
        openingBalanceID.SqlDbType = SqlDbType.Int;
        openingBalanceID.Value = hndOpeningBalId.Value;
        openingBalanceID.ParameterName = "@openingBalanceID";
        sqlCmd.Parameters.Add(openingBalanceID);

        SqlParameter BranchID = new SqlParameter();
        BranchID.SqlDbType = SqlDbType.Int;
        BranchID.Value = ddlBranchList.SelectedValue.ToString();
        BranchID.ParameterName = "@BranchID";
        sqlCmd.Parameters.Add(BranchID);

        SqlParameter OpeningBalanceYrMonth = new SqlParameter();
        OpeningBalanceYrMonth.SqlDbType = SqlDbType.VarChar;
        OpeningBalanceYrMonth.Value = ddlYear.Text.Trim()+ ddlMonth.Text.Trim();
        OpeningBalanceYrMonth.ParameterName = "@OpeningBalanceYrMonth";
        sqlCmd.Parameters.Add(OpeningBalanceYrMonth);

        SqlParameter OpeningBalanceAmount = new SqlParameter();
        OpeningBalanceAmount.SqlDbType = SqlDbType.Decimal;
        OpeningBalanceAmount.Value = txtAmount.Text.Trim();
        OpeningBalanceAmount.ParameterName = "@OpeningBalanceAmount";
        sqlCmd.Parameters.Add(OpeningBalanceAmount);

        SqlParameter RequestType = new SqlParameter();
        RequestType.SqlDbType = SqlDbType.VarChar;
        RequestType.Value = ddlRequestType.SelectedItem.Value;
        RequestType.ParameterName = "@RequestType";
        sqlCmd.Parameters.Add(RequestType);

        SqlParameter Status = new SqlParameter();
        Status.SqlDbType = SqlDbType.Int;
        Status.Value = 1;
        Status.ParameterName = "@Status";
        sqlCmd.Parameters.Add(Status);

        SqlParameter Remark = new SqlParameter();
        Remark.SqlDbType = SqlDbType.VarChar;
        Remark.Value = txtRemark.Text.Trim();
        Remark.ParameterName = "@Remark";
        sqlCmd.Parameters.Add(Remark);

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
        UserID.ParameterName = "@User_ID";
        sqlCmd.Parameters.Add(UserID);

        int SqlRow = 0;
        SqlRow = sqlCmd.ExecuteNonQuery();

        if (SqlRow > 0)
        {
            lblMessage.Text = "Update Successfully!";
            lblMessage.CssClass = "UpdateMessage";
            lblMessage.Visible = true;
        }
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        ClearAllTextField();
    }

    protected void ClearAllTextField()
    {   
        ddlYear.SelectedIndex =0;
        ddlMonth.SelectedIndex =0;
        txtAmount.Text ="";
        txtRemark.Text = "";
        //lblMessage.Text = "";
        ddlRequestType.SelectedIndex = 0;
        hndOpeningBalId.Value ="0";
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Pages/Menu.aspx", true);
    }  
}
