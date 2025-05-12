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

public partial class Pages_GroupMaster : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        { 
            if(!IsPostBack)
            {
                Get_BranchList();
                Get_GroupInfo();
                Register_ControlswithJavascript();
            }
        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
            lblMessage.CssClass = "ErrorMessage";
            lblMessage.Visible = true;
        }

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
            sqlCom.CommandText = "Get_AllBranchList";
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
            lblMessage.CssClass = "ErrorMessage";
        }
    }
    private void Get_GroupInfo()
    {
        try
        {
            Object SaveUSERInfo = (Object)Session["UserInfo"];

            SqlConnection sqlCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);

            sqlCon.Open();
            SqlCommand sqlCom = new SqlCommand();
            sqlCom.Connection = sqlCon;
            sqlCom.CommandType = CommandType.StoredProcedure;
            sqlCom.CommandText = "AdminMaster_Get_GroupInfo_SP";

            SqlParameter BranchId = new SqlParameter();
            BranchId.SqlDbType = SqlDbType.Int;
            BranchId.Value = Convert.ToInt32(((UserInfo.structUSERInfo)(SaveUSERInfo)).BranchId);
            BranchId.ParameterName = "@BranchId";
            sqlCom.Parameters.Add(BranchId);

            SqlDataAdapter sqlDA = new SqlDataAdapter();
            sqlDA.SelectCommand = sqlCom;


            DataTable dt = new DataTable();
            sqlDA.Fill(dt);
            sqlCon.Close();

            grv_GroupInfo.DataSource = dt;
            grv_GroupInfo.DataBind();




        }
        catch (Exception ex)
        {
            lblMessage.Visible = true;
            lblMessage.Text = ex.Message;
            lblMessage.CssClass = "ErrorMessage";
        }
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Pages/Menu.aspx", true);
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        Insert_GroupInfo();
        Get_GroupInfo();
        Reset_Control();
    }
    private void Insert_GroupInfo()
    {
        Object SaveUSERInfo = (Object)Session["UserInfo"];

        SqlConnection sqlCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);

        sqlCon.Open();
        SqlCommand sqlCom = new SqlCommand();
        sqlCom.Connection = sqlCon;
        sqlCom.CommandType = CommandType.StoredProcedure;
        sqlCom.CommandText = "AdminMaster_Insert_GroupInfo_SP";

        SqlParameter BranchId = new SqlParameter();
        BranchId.SqlDbType = SqlDbType.Int;
        BranchId.Value = ddlBranchList.SelectedItem.Value;
        BranchId.ParameterName = "@BranchId";
        sqlCom.Parameters.Add(BranchId);

        SqlParameter GroupID = new SqlParameter();
        GroupID.SqlDbType = SqlDbType.Int;
        GroupID.Value = hdnGroupID.Value ;
        GroupID.ParameterName = "@GroupID";
        sqlCom.Parameters.Add(GroupID);

        SqlParameter UserId = new SqlParameter();
        UserId.SqlDbType = SqlDbType.VarChar;
        UserId.Value = Convert.ToString(((UserInfo.structUSERInfo)(SaveUSERInfo)).UserId);
        UserId.ParameterName = "@UserId";
        sqlCom.Parameters.Add(UserId);
        //

        SqlParameter GroupName = new SqlParameter();
        GroupName.SqlDbType = SqlDbType.VarChar;
        GroupName.Value = txtGroupName.Text.Trim();
        GroupName.ParameterName = "@GroupName";
        sqlCom.Parameters.Add(GroupName);

        SqlParameter GroupDescription = new SqlParameter();
        GroupDescription.SqlDbType = SqlDbType.VarChar;
        GroupDescription.Value = txtGroupDescription.Text.Trim();
        GroupDescription.ParameterName = "@GroupDescription";
        sqlCom.Parameters.Add(GroupDescription);

        SqlParameter IsActivate = new SqlParameter();
        IsActivate.SqlDbType = SqlDbType.Bit;
        IsActivate.Value =Convert.ToBoolean(ddlIsActivate.SelectedItem.Value) ;
        IsActivate.ParameterName = "@IsActivate";
        sqlCom.Parameters.Add(IsActivate);

        int Rows = 0;

        Rows = sqlCom.ExecuteNonQuery();

        if (Rows > 0)
        {
            lblMessage.Text = "Update Successfully!";
            lblMessage.CssClass = "UpdateMessage";
            lblMessage.Visible = true;
        }


    
    }
    private void Reset_Control()
    {
        hdnGroupID.Value = "0";
        txtGroupDescription.Text = "";
        txtGroupName.Text = "";
        ddlBranchList.SelectedIndex = 0;
        ddlIsActivate.SelectedIndex = 0;

    }
    protected void grv_GroupInfo_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Attributes.Add("onclick", "javascript:Pro_SelectRow('" + e.Row.RowIndex + "','" + e.Row.Cells[0].Text + "')");
            e.Row.Attributes.Add("onmouseover", "javascript:hover('in','" + e.Row.RowIndex + "');");
            e.Row.Attributes.Add("onmouseout", "javascript:hover('out','" + e.Row.RowIndex + "');");
            
        }
    }
    private void Register_ControlswithJavascript()
    {
        btnSave.Attributes.Add("onclick", "javascript:return ValidateSave();");
        btnAddNew.Attributes.Add("onclick", "javascript:return ValidateAddNew();");
   
    
    }
    protected void btnAddNew_Click(object sender, EventArgs e)
    {

    }
}
