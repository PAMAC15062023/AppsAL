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

public partial class Pages_Calculus_MICR_Master : System.Web.UI.Page
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
                Get_MICRData();
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


            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlcon;
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.CommandText = "CommonMaster_Get_C_BranchData_SP";
            sqlcmd.CommandTimeout = 0;


            sqlcon.Open();
            SqlDataAdapter sqlda = new SqlDataAdapter();
            sqlda.SelectCommand = sqlcmd;
            DataTable dt = new DataTable();
            sqlda.Fill(dt);
            sqlcon.Close();

            ddlBranchID.DataTextField = "BranchName";
            ddlBranchID.DataValueField = "BranchId";
            ddlBranchID.DataSource = dt;
            ddlBranchID.DataBind();

            ddlBranchID.Items.Insert(0, "-Select-");
            ddlBranchID.SelectedIndex = 0;

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

    private void Get_MICRData()
    {
        try
        {
            Object SaveUSERInfo = (Object)Session["UserInfo"];

            SqlConnection SqlCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);


            SqlCommand SqlCmd = new SqlCommand();
            SqlCmd.Connection = SqlCon;
            SqlCmd.CommandType = CommandType.StoredProcedure;
            SqlCmd.CommandText = "CommonMaster_Get_MICRFullDetails_SP";
            SqlCmd.CommandTimeout = 0;

            SqlParameter BranchId = new SqlParameter();
            BranchId.SqlDbType = SqlDbType.Int;
            BranchId.Value = Convert.ToInt32(((UserInfo.structUSERInfo)(SaveUSERInfo)).BranchId);
            BranchId.ParameterName = "@BranchID";
            SqlCmd.Parameters.Add(BranchId);

            SqlCon.Open();

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
        Insert_MICRInfo();
        Get_MICRData();
        Clear_textfield();
        
    }

    protected void Insert_MICRInfo()
    {
        Object SaveUSERInfo = (Object)Session["UserInfo"];
        SqlConnection sqlCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);

  
        SqlCommand sqlCmd = new SqlCommand();
        sqlCmd.Connection = sqlCon;
        sqlCmd.CommandType = CommandType.StoredProcedure;
        sqlCmd.CommandText = "CommonMaster_Insert_MICRDetail_SP";
        sqlCmd.CommandTimeout = 0;

        SqlParameter MICR_ID = new SqlParameter();
        MICR_ID.SqlDbType = SqlDbType.Int;
        MICR_ID.Value = hdnMICRID.Value;
        MICR_ID.ParameterName = "@MICR_ID";
        sqlCmd.Parameters.Add(MICR_ID);

        SqlParameter BranchID = new SqlParameter();
        BranchID.SqlDbType = SqlDbType.NVarChar;
        BranchID.Value = ddlBranchID.SelectedItem.Value;
        BranchID.ParameterName = "@BranchID";
        sqlCmd.Parameters.Add(BranchID);

        SqlParameter MICR_Code = new SqlParameter();
        MICR_Code.SqlDbType = SqlDbType.NVarChar;
        MICR_Code.Value = txtMICRCode.Text.Trim();
        MICR_Code.ParameterName = "@MICR_Code";
        sqlCmd.Parameters.Add(MICR_Code);

        SqlParameter Bank_Name = new SqlParameter();
        Bank_Name.SqlDbType = SqlDbType.NVarChar;
        Bank_Name.Value = txtBankName.Text.Trim();
        Bank_Name.ParameterName = "@Bank_Name";
        sqlCmd.Parameters.Add(Bank_Name);

        SqlParameter City = new SqlParameter();
        City.SqlDbType = SqlDbType.NVarChar;
        City.Value = txtCity.Text.Trim();
        City.ParameterName = "@City";
        sqlCmd.Parameters.Add(City);

        SqlParameter Branch_Name = new SqlParameter();
        Branch_Name.SqlDbType = SqlDbType.NVarChar;
        Branch_Name.Value = txtBranchName.Text.Trim();
        Branch_Name.ParameterName = "@Branch_Name";
        sqlCmd.Parameters.Add(Branch_Name);

        sqlCon.Open();

        int SqlRow = 0;
        SqlRow = sqlCmd.ExecuteNonQuery();

        sqlCon.Close();


        if (SqlRow > 0)
        {
            lblMessage.Text = "Update Successfully!";
            lblMessage.CssClass = "UpdateMessage";
            lblMessage.Visible = true;
        }
    }

    protected void Clear_textfield()
    {
        hdnMICRID.Value = "0";
        txtMICRCode.Text = "";
        txtBankName.Text = "";
        txtCity.Text = "";
        ddlBranchID.SelectedIndex =0;
        txtBranchName.Text = "";

     } 

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Pages/Menu.aspx", true);
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        Clear_textfield();
    }
}
