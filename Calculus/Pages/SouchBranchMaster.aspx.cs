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

public partial class Pages_SouchBranchMaster : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (Session["UserInfo"] == null)
            {
                Response.Redirect("InvalidRequest.aspx", false);
            }


            if (!IsPostBack)
            {
                Get_BranchList();
                Get_SourceBranchList();
            }

        }
        catch (Exception ex)
        {
            lblMessage.Visible = true;
            lblMessage.Text = ex.Message;
            lblMessage.CssClass = "ErrorMessage";
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
    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            Insert_SourceBranch();
        }
        catch (Exception ex)
        {
            lblMessage.Visible = true;
            lblMessage.Text = ex.Message;
            lblMessage.CssClass = "ErrorMessage";
        }
    }
    private void Insert_SourceBranch()
    {
        try
        {
            Object SaveUSERInfo = (Object)Session["UserInfo"];
            SqlConnection sqlCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);

            sqlCon.Open();
            SqlCommand sqlCom = new SqlCommand();
            sqlCom.Connection = sqlCon;
            sqlCom.CommandType = CommandType.StoredProcedure;
            sqlCom.CommandText = "CommonMaster_Insert_SourceBranch_SP";

            SqlParameter BranchId = new SqlParameter();
            BranchId.SqlDbType = SqlDbType.Int;
            BranchId.Value = Convert.ToInt32(((UserInfo.structUSERInfo)(SaveUSERInfo)).BranchId);
            BranchId.ParameterName = "@BranchId";
            sqlCom.Parameters.Add(BranchId);

            SqlParameter SourceBranchName = new SqlParameter();
            SourceBranchName.SqlDbType = SqlDbType.VarChar;
            SourceBranchName.Value =txtSourceBranchName.Text.Trim();
            SourceBranchName.ParameterName = "@SourceBranchName";
            sqlCom.Parameters.Add(SourceBranchName);

            sqlCom.ExecuteNonQuery();
         
                lblMessage.CssClass = "UpdateMessage";
                lblMessage.Visible = true;
                lblMessage.Text = "Updated Successfully!";
                Get_SourceBranchList();
                txtSourceBranchName.Text = "";
                ddlBranchList.SelectedIndex = 0;
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
        try
        {
            Response.Redirect("Menu.aspx",false);
        }
        catch (Exception ex)
        {
            lblMessage.Visible = true;
            lblMessage.Text = ex.Message;
            lblMessage.CssClass = "ErrorMessage";
        }
    }

    private void Get_SourceBranchList()
    {
        try
        {
            Object SaveUSERInfo = (Object)Session["UserInfo"];
            
            SqlConnection sqlCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);

            sqlCon.Open();
            SqlCommand sqlCom = new SqlCommand();
            sqlCom.Connection = sqlCon;
            sqlCom.CommandType = CommandType.StoredProcedure;
            sqlCom.CommandText = "Get_SourceBranhList";

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
 
            grvBranchList.DataSource = dt;
            grvBranchList.DataBind();
 



        }
        catch (Exception ex)
        {
            lblMessage.Visible = true;
            lblMessage.Text = ex.Message;
            lblMessage.CssClass = "ErrorMessage";
        }
    }
    
}
