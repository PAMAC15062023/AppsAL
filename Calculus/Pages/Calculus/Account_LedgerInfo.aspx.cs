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

public partial class Pages_Calculus_Account_LedgerInfo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Get_AccLedInfo();
            Get_AccLedGridData();
            Register_Validation_On_Field();
            BindIsActive();
        }
    }

    private void Register_Validation_On_Field()
    {
        btnSave.Attributes.Add("onclick", "javascript:return Validation_AllField();");
    }
    protected void BindIsActive()
    {
        SqlConnection sqlCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);

        SqlCommand cmd = new SqlCommand("KMPL_Searchcodemaster_sp", sqlCon);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@Types", "CMIsActiveType");
        cmd.Parameters.AddWithValue("@Level", 1);
        SqlDataAdapter adp = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        adp.Fill(ds);

        if (ds != null && ds.Tables[0].Rows.Count > 0)
        {
            ddlIsActive.DataSource = ds;
            ddlIsActive.DataValueField = "Code_Id";
            ddlIsActive.DataTextField = "Description";
            ddlIsActive.DataBind();
            ddlIsActive.Items.Insert(0, new ListItem("--Select--", "0"));
        }
    }
    private void Get_AccLedInfo()
    {

        try
        {
            SqlConnection sqlcon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);

            sqlcon.Open();
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlcon;
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.CommandText = "AdminMaster_Get_AccountLedgerInfo_SP";
            SqlDataAdapter sqlda = new SqlDataAdapter();
            sqlda.SelectCommand = sqlcmd;
            DataTable dt = new DataTable();
            sqlda.Fill(dt);
            sqlcon.Close();

            ddlGroupName.DataTextField = "AccountLedgerGroupName";
            ddlGroupName.DataValueField = "AccountledgergroupId";
            ddlGroupName.DataSource = dt;
            ddlGroupName.DataBind();

            ddlGroupName.Items.Insert(0, "-Select-");
            ddlGroupName.SelectedIndex = 0;

        }
        catch (Exception ex)
        {
            lblMessage.Visible = true;
            lblMessage.Text = ex.Message;
            lblMessage.CssClass = "ErrorMessage";

        }

    }

    private void Get_AccLedGridData()
    {
        try
        {
            SqlConnection SqlCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);

            SqlCon.Open();
            SqlCommand SqlCmd = new SqlCommand();
            SqlCmd.Connection = SqlCon;
            SqlCmd.CommandType = CommandType.StoredProcedure;
            SqlCmd.CommandText = "AdminMaster_Get_GridAccountLedgerInfo_SP";

            SqlDataAdapter sqlDA = new SqlDataAdapter();
            sqlDA.SelectCommand = SqlCmd;


            DataTable dt = new DataTable();
            sqlDA.Fill(dt);
            SqlCon.Close();

            Gv_AccountLed.DataSource = dt;
            Gv_AccountLed.DataBind();

        }
        catch (Exception ex)
        {
            lblMessage.Visible = true;
            lblMessage.Text = ex.Message;
            lblMessage.CssClass = "Error Message";

        }
    }

    protected void Gv_AccountLed_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Attributes.Add("onclick", "javascript:GV_RowSelection('" + e.Row.RowIndex + "','" + e.Row.Cells[0].Text + "');");


        }

    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        Insert_AccountHeadDetail();
        Get_AccLedGridData();
        ClearAllTextData();
    }

    private void Insert_AccountHeadDetail()
    {
        Object SaveUSERInfo = (Object)Session["UserInfo"];

        SqlConnection sqlCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);

        sqlCon.Open();
        SqlCommand sqlCmd = new SqlCommand();
        sqlCmd.Connection = sqlCon;
        sqlCmd.CommandType = CommandType.StoredProcedure;
        sqlCmd.CommandText = "AdminMaster_Insert_AccountLedgetInfo_SP";

        SqlParameter AccountLedgerId = new SqlParameter();
        AccountLedgerId.SqlDbType = SqlDbType.Int;
        AccountLedgerId.Value = hdnAccountLedger.Value;
        AccountLedgerId.ParameterName = "@AccountLedgerId";
        sqlCmd.Parameters.Add(AccountLedgerId);

        SqlParameter AccountLedgerName = new SqlParameter();
        AccountLedgerName.SqlDbType = SqlDbType.VarChar;
        AccountLedgerName.Value = txtLedgerName.Text.Trim();
        AccountLedgerName.ParameterName = "@AccountledgerName";
        sqlCmd.Parameters.Add(AccountLedgerName);

        SqlParameter AccountLedgerGroupID = new SqlParameter();
        AccountLedgerGroupID.SqlDbType = SqlDbType.Int;
        AccountLedgerGroupID.Value = ddlGroupName.SelectedItem.Value;
        AccountLedgerGroupID.ParameterName = "@AccountLedgerGroupID";
        sqlCmd.Parameters.Add(AccountLedgerGroupID);

        SqlParameter Is_Active = new SqlParameter();
        Is_Active.SqlDbType = SqlDbType.Bit;
        Is_Active.Value = Convert.ToBoolean(ddlIsActive.SelectedItem.Value); 
        Is_Active.ParameterName = "@Is_Active";
        sqlCmd.Parameters.Add(Is_Active);

        SqlParameter UserID = new SqlParameter();
        UserID.SqlDbType = SqlDbType.VarChar;
        UserID.Value = Convert.ToString(((UserInfo.structUSERInfo)(SaveUSERInfo)).UserId);
        UserID.ParameterName = "@UserId";
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
    protected void ClearAllTextData()
    {
        txtLedgerName.Text = "";
        ddlGroupName.SelectedIndex = 0;
        ddlIsActive.SelectedIndex = 0;
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        ClearAllTextData();
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Pages/Menu.aspx", true);

    }
}
