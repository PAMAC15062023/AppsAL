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
                Get_BranchId();
                Get_GridOpeningBalanceData();
                Register_Validation_On_Field();
            }
        }
        catch (Exception ex)
        {
            lblMessage.Visible = true;
            lblMessage.Text = ex.Message;
            lblMessage.CssClass = "ErrorMessage";


        }
    }

    private void Register_Validation_On_Field()
    {
        btnSave.Attributes.Add("onclick", "javascript:return Validation_AllField();");
        ddlYear.Attributes.Add("onblur", "javascript:return dropdown_validator();");
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
            sqlcmd.CommandText = "Get_Region";
            SqlDataAdapter sqlda = new SqlDataAdapter();
            sqlda.SelectCommand = sqlcmd;
            DataTable dt = new DataTable();
            sqlda.Fill(dt);
            sqlcon.Close();

            ddlBranchName.DataTextField = "Region_Name";
            ddlBranchName.DataValueField = "Region_id";
            ddlBranchName.DataSource = dt;
            ddlBranchName.DataBind();

            ddlBranchName.Items.Insert(0, "-Select-");
            ddlBranchName.SelectedIndex = 0;

        }
        catch (Exception ex)
        {
            lblMessage.Visible = true;
            lblMessage.Text = ex.Message;
            lblMessage.CssClass = "ErrorMessage";

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

            //Object SaveUSERInfo = (Object)Session["UserInfo"];

            SqlConnection SqlCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);

            SqlCon.Open();
            SqlCommand SqlCmd = new SqlCommand();
            SqlCmd.Connection = SqlCon;
            SqlCmd.CommandType = CommandType.StoredProcedure;
            SqlCmd.CommandText = "Get_OpeningBalanceData";

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

    }

    protected void Insert_OpeningBalanceData()
    {
        Object SaveUSERInfo = (Object)Session["UserInfo"];

        SqlConnection sqlCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);

        sqlCon.Open();
        SqlCommand sqlCmd = new SqlCommand();
        sqlCmd.Connection = sqlCon;
        sqlCmd.CommandType = CommandType.StoredProcedure;
        sqlCmd.CommandText = "Insert_OpeningBalance";

        SqlParameter openingBalanceID = new SqlParameter();
        openingBalanceID.SqlDbType = SqlDbType.Int;
        openingBalanceID.Value = hndBranchId.Value;
        openingBalanceID.ParameterName = "@openingBalanceID";
        sqlCmd.Parameters.Add(openingBalanceID);

        SqlParameter BranchID = new SqlParameter();
        BranchID.SqlDbType = SqlDbType.Int;
        BranchID.Value = ddlBranchName.SelectedItem.Value;
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

        SqlParameter Remark = new SqlParameter();
        Remark.SqlDbType = SqlDbType.VarChar;
        Remark.Value = txtRemark.Text.Trim();
        Remark.ParameterName = "@Remark";
        sqlCmd.Parameters.Add(Remark);

        SqlParameter Is_Active = new SqlParameter();
        Is_Active.SqlDbType = SqlDbType.Bit;
        Is_Active.Value = Convert.ToBoolean(ddlIsActive.SelectedItem.Value);
        Is_Active.ParameterName = "@Is_Active";
        sqlCmd.Parameters.Add(Is_Active);

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
        ddlBranchName.SelectedIndex = 0;
        ddlYear.SelectedIndex =0;
        ddlMonth.SelectedIndex =0;
        txtAmount.Text ="";
        ddlIsActive.SelectedIndex=0;
        txtRemark.Text = "";
        lblMessage.Text = "";

    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Pages/Menu.aspx", true);
    }
}
