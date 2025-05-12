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

public partial class Pages_Calculus_Client_Master : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                BindIsActive();
                Get_GridBranchInfo();
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
    protected void BindIsActive()
    {
        SqlConnection sqlCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);

        SqlCommand cmd = new SqlCommand("KMPL_SearchCodeMaster_SP", sqlCon);
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
    private void Register_Validation()
    {
        btnSave.Attributes.Add("onclick", "javascript:return ValidationAllField();");

    }

    private void Get_GridBranchInfo()
    {
        try
        {
            Object SaveUSERInfo = (Object)Session["UserInfo"];

            SqlConnection SqlCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);


            SqlCommand SqlCmd = new SqlCommand();
            SqlCmd.Connection = SqlCon;
            SqlCmd.CommandType = CommandType.StoredProcedure;
            SqlCmd.CommandText = "CommonMaster_Get_ClientData_SP";

            SqlParameter BranchId = new SqlParameter();
            BranchId.SqlDbType = SqlDbType.Int;
            BranchId.Value = Convert.ToInt32(((UserInfo.structUSERInfo)(SaveUSERInfo)).BranchId);
            BranchId.ParameterName = "@ClientID";
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

    protected void Gv_Search_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Attributes.Add("onclick", "javascript:GV_RowSelection('" + e.Row.RowIndex + "','" + e.Row.Cells[0].Text + "');");


        }

    }



    protected void btnSave_Click(object sender, EventArgs e)
    {
        Insert_BranchInfo();
        Get_GridBranchInfo();
        Clear_textfield();

    }

    protected void Insert_BranchInfo()
    {
        Object SaveUSERInfo = (Object)Session["UserInfo"];
        SqlConnection sqlCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);


        SqlCommand sqlCmd = new SqlCommand();
        sqlCmd.Connection = sqlCon;
        sqlCmd.CommandType = CommandType.StoredProcedure;
        sqlCmd.CommandText = "CommonMaster_Insert_ClientInfo_SP";
        sqlCmd.CommandTimeout = 0;


        SqlParameter BranchID = new SqlParameter();
        BranchID.SqlDbType = SqlDbType.Int;
        BranchID.Value = hdnClientId.Value;
        BranchID.ParameterName = "@ClientId";
        sqlCmd.Parameters.Add(BranchID);

        SqlParameter BranchName = new SqlParameter();
        BranchName.SqlDbType = SqlDbType.VarChar;
        BranchName.Value = txtClientName.Text.Trim();
        BranchName.ParameterName = "@ClientName";
        sqlCmd.Parameters.Add(BranchName);

        SqlParameter BranchCode = new SqlParameter();
        BranchCode.SqlDbType = SqlDbType.VarChar;
        BranchCode.Value = txtClientCode.Text.Trim();
        BranchCode.ParameterName = "@ClientCode";
        sqlCmd.Parameters.Add(BranchCode);

        SqlParameter Is_Active = new SqlParameter();
        Is_Active.SqlDbType = SqlDbType.Bit;
        Is_Active.Value = Convert.ToBoolean(ddlIsActive.SelectedItem.Value);
        Is_Active.ParameterName = "@Is_Active";
        sqlCmd.Parameters.Add(Is_Active);

        SqlParameter RightsBy = new SqlParameter();
        RightsBy.SqlDbType = SqlDbType.VarChar;
        RightsBy.Value = Convert.ToString(((UserInfo.structUSERInfo)(SaveUSERInfo)).UserId);
        RightsBy.ParameterName = "@RightsBy";
        sqlCmd.Parameters.Add(RightsBy);

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
        hdnClientId.Value = "0";
        txtClientName.Text = "";
        txtClientCode.Text = "";
        ddlIsActive.SelectedIndex = 0;

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
