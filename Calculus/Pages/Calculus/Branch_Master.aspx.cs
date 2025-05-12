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

public partial class Pages_Calculus_Branch_Master : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                Get_RegionID();
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

            SqlCon.Open();
            SqlCommand SqlCmd = new SqlCommand();
            SqlCmd.Connection = SqlCon;
            SqlCmd.CommandType = CommandType.StoredProcedure;
            SqlCmd.CommandText = "Get_BranchData";

            SqlParameter BranchId = new SqlParameter();
            BranchId.SqlDbType = SqlDbType.Int;
            BranchId.Value = Convert.ToInt32(((UserInfo.structUSERInfo)(SaveUSERInfo)).BranchId);
            BranchId.ParameterName = "@BranchId";
            SqlCmd.Parameters.Add(BranchId);

            SqlDataAdapter sqlDA = new SqlDataAdapter();
            sqlDA.SelectCommand = SqlCmd;


            DataTable dt = new DataTable();
            sqlDA.Fill(dt);
            SqlCon.Close();

            Gv_Search.DataSource = dt;
            Gv_Search.DataBind();
        }
        catch(Exception ex)
        {
            lblMessage.Visible = true;
            lblMessage.Text = ex.Message;
            lblMessage.CssClass = "Error Message";
        }


    }

    protected void Gv_Search_RowDataBound(object sender,GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Attributes.Add("onclick", "javascript:GV_RowSelection('" + e.Row.RowIndex + "','" + e.Row.Cells[0].Text + "');");
           
            
        }

    }


  private void Get_RegionID()
 {
     try
     {
         SqlConnection sqlcon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);

         sqlcon.Open();
         SqlCommand sqlcmd = new SqlCommand();
         sqlcmd.Connection = sqlcon;
         sqlcmd.CommandType=CommandType.StoredProcedure;
         sqlcmd.CommandText = "Get_Region";
         SqlDataAdapter sqlda=new SqlDataAdapter();
         sqlda.SelectCommand =sqlcmd ;
         DataTable dt = new DataTable();
         sqlda.Fill(dt);
         sqlcon.Close();

         ddlRegion.DataTextField = "Region_Name";
         ddlRegion.DataValueField = "Region_id";
         ddlRegion.DataSource=dt;
         ddlRegion.DataBind();

         ddlRegion.Items.Insert(0,"-Select-");
         ddlRegion.SelectedIndex = 0;

     }
     catch (Exception ex)
     {
         lblMessage.Visible = true;
         lblMessage.Text = ex.Message;
         lblMessage.CssClass = "ErrorMessage";

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
        SqlConnection sqlCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);

        sqlCon.Open();
        SqlCommand sqlCmd = new SqlCommand();
        sqlCmd.Connection = sqlCon;
        sqlCmd.CommandType = CommandType.StoredProcedure;
        sqlCmd.CommandText = "Insert_BranchInfo";

        SqlParameter BranchID = new SqlParameter();
        BranchID.SqlDbType = SqlDbType.Int;
        BranchID.Value = hdnBranchId.Value;
        BranchID.ParameterName = "@BranchId";
        sqlCmd.Parameters.Add(BranchID);

        SqlParameter BranchName = new SqlParameter();
        BranchName.SqlDbType = SqlDbType.VarChar;
        BranchName.Value = txtBranchName.Text.Trim();
        BranchName.ParameterName = "@BranchName";
        sqlCmd.Parameters.Add(BranchName);

        SqlParameter BranchCode = new SqlParameter();
        BranchCode.SqlDbType = SqlDbType.VarChar;
        BranchCode.Value = txtBranchCode.Text.Trim();
        BranchCode.ParameterName = "@BranchCode";
        sqlCmd.Parameters.Add(BranchCode);

        SqlParameter Region_id = new SqlParameter();
        Region_id.SqlDbType = SqlDbType.Int;
        Region_id.Value = ddlRegion.SelectedItem.Value;
        Region_id.ParameterName = "@Region_id";
        sqlCmd.Parameters.Add(Region_id);

        SqlParameter Is_Active = new SqlParameter();
        Is_Active.SqlDbType = SqlDbType.Bit;
        Is_Active.Value = Convert.ToBoolean(ddlIsActive.SelectedItem.Value);
        Is_Active.ParameterName = "@Is_Active";
        sqlCmd.Parameters.Add(Is_Active);

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
       txtBranchName.Text = "";
       txtBranchCode.Text = "";
       ddlIsActive.SelectedIndex = 0;
       ddlRegion.SelectedIndex = 0;
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
