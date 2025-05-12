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

public partial class Pages_Calculus_Transaction_Master : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserInfo"] == null)
        {
            Response.Redirect("~/Pages/InvalidRequest.aspx");
        }
        try
        {
            if (!IsPostBack)
            {
                
                Get_BranchData();
                Get_TransactionDetail();
                Register_Validation();
            }
        }
        catch (Exception ex)
        {
            lblMessage.Visible = true;
            lblMessage.Text = ex.Message;
            lblMessage.CssClass = "ErrorMessage";


        }
    }



    private void Register_Validation()
    {
        btnSave.Attributes.Add("onclick", "javascript:return ValidationAllField();");

    }
    private void Get_BranchData()
    {
        try
        {
            SqlConnection sqlcon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);

            sqlcon.Open();
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlcon;
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.CommandText = "CommonMaster_Get_C_BranchData_SP";
            SqlDataAdapter sqlda = new SqlDataAdapter();
            sqlda.SelectCommand = sqlcmd;
            DataTable dt = new DataTable();
            sqlda.Fill(dt);
            sqlcon.Close();

            ddlBranchName.DataTextField = "BranchName";
            ddlBranchName.DataValueField = "BranchId";
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

        finally
        { 
        
        }

    }
    private void Get_TransactionDetail()
    {
        try
        {
            Object SaveUSERInfo = (Object)Session["UserInfo"];

            SqlConnection SqlCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);

            SqlCon.Open();
            SqlCommand SqlCmd = new SqlCommand();
            SqlCmd.Connection = SqlCon;
            SqlCmd.CommandType = CommandType.StoredProcedure;
            SqlCmd.CommandText = "CommonMaster_Get_TransactionDetail_mod_SP";

            SqlDataAdapter sqlDA = new SqlDataAdapter();
            sqlDA.SelectCommand = SqlCmd;

            DataTable dt = new DataTable();
            sqlDA.Fill(dt);
            SqlCon.Close();

            Gv_Search.DataSource = dt;
            Gv_Search.DataBind();
        }
        catch (Exception ex)
        {
            lblMessage.Visible = true;
            lblMessage.Text = ex.Message;
            lblMessage.CssClass = "Error Message";
        }

        finally
        { 
        
        }
    }

    protected void Gv_Search_RowDataBound(object sender,GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Attributes.Add("onclick", "javascript:GV_RowSelection('" + e.Row.RowIndex + "','" + e.Row.Cells[0].Text + "');");
             
        }

    }


 
    protected void btnSave_Click(object sender, EventArgs e)
    {
        lblMessage.Text = "";
        Insert_TransactionInfo();
        Get_TransactionDetail();
        Clear_textfield();
        
    }

    protected void Insert_TransactionInfo()
    {
        Object SaveUSERInfo = (Object)Session["UserInfo"];

        SqlConnection sqlCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);

        sqlCon.Open();
        SqlCommand sqlCmd = new SqlCommand();
        sqlCmd.Connection = sqlCon;
        sqlCmd.CommandType = CommandType.StoredProcedure;
        //sqlCmd.CommandText = "Insert_TransactionDetails_SBI";
        sqlCmd.CommandText = "CommonMaster_Insert_TransactionDetails_SBI_mod_SP";

        SqlParameter BranchId = new SqlParameter();
        BranchId.SqlDbType = SqlDbType.Int;
        BranchId.Value = ddlBranchName.SelectedItem.Value;
        BranchId.ParameterName = "@BranchId";
        sqlCmd.Parameters.Add(BranchId);

        SqlParameter NormalTypeCode = new SqlParameter();
        NormalTypeCode.SqlDbType = SqlDbType.VarChar;
        NormalTypeCode.Value = txtNormalTypeCode.Text.Trim();
        NormalTypeCode.ParameterName = "@NormalChequeType";
        sqlCmd.Parameters.Add(NormalTypeCode);

        SqlParameter ReturnWithFeeType = new SqlParameter();
        ReturnWithFeeType.SqlDbType = SqlDbType.VarChar;
        ReturnWithFeeType.Value = txtReturnWithFeeCode.Text.Trim();
        ReturnWithFeeType.ParameterName = "@ReturnWithFeeType";
        sqlCmd.Parameters.Add(ReturnWithFeeType);

        SqlParameter ReturnWithouFeeType = new SqlParameter();
        ReturnWithouFeeType.SqlDbType = SqlDbType.VarChar;
        ReturnWithouFeeType.Value = txtReturnWithoutFeeCode.Text.Trim();
        ReturnWithouFeeType.ParameterName = "@ReturnWithouFeeType";
        sqlCmd.Parameters.Add(ReturnWithouFeeType);

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
    }

    protected void Clear_textfield()
    {
        hdnBranchId.Value = "0";
        txtNormalTypeCode.Text = "";
        txtReturnWithFeeCode.Text = "";
        txtReturnWithoutFeeCode.Text = "";
        //ddlTranType.SelectedIndex = 0;
        ddlBranchName.SelectedIndex = 0;
     } 

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Pages/Menu.aspx", true);
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        lblMessage.Text = "";
        Clear_textfield();
    }
   
}
