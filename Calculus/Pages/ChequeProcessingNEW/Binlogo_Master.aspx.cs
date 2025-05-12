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

public partial class Pages_Calculus_Binlogo_Master : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {

                Get_BinLogoDetails();
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

    private void Get_BinLogoDetails()
    {
        try
        {
            Object SaveUSERInfo = (Object)Session["UserInfo"];

            SqlConnection SqlCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);

            SqlCon.Open();
            SqlCommand SqlCmd = new SqlCommand();
            SqlCmd.Connection = SqlCon;
            SqlCmd.CommandType = CommandType.StoredProcedure;
            SqlCmd.CommandText = "CommonMaster_Get_BinlogoData_SP";

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
        Insert_BinLogoDetails();
        Get_BinLogoDetails();
        Clear_textfield();
        
    }

    protected void Insert_BinLogoDetails()
    {
        Object SaveUSERInfo = (Object)Session["UserInfo"];
        SqlConnection sqlCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);

        sqlCon.Open();
        SqlCommand sqlCmd = new SqlCommand();
        sqlCmd.Connection = sqlCon;
        sqlCmd.CommandType = CommandType.StoredProcedure;
        sqlCmd.CommandText = "CommonMaster_Insert_BinLogoDetail_SP";

        SqlParameter binlogoID = new SqlParameter();
        binlogoID.SqlDbType = SqlDbType.Int;
        binlogoID.Value = hdnBinID.Value;
        binlogoID.ParameterName = "@binlogoID";
        sqlCmd.Parameters.Add(binlogoID);

        SqlParameter BinCode = new SqlParameter();
        BinCode.SqlDbType = SqlDbType.NVarChar;
        BinCode.Value = txtBinCode.Text.Trim();
        BinCode.ParameterName = "@BinCode";
        sqlCmd.Parameters.Add(BinCode);

        SqlParameter Logo_Code = new SqlParameter();
        Logo_Code.SqlDbType = SqlDbType.NVarChar;
        Logo_Code.Value = txtBinlogo.Text.Trim();
        Logo_Code.ParameterName = "@Logo_Code";
        sqlCmd.Parameters.Add(Logo_Code);

        SqlParameter Description = new SqlParameter();
        Description.SqlDbType = SqlDbType.NVarChar;
        Description.Value = txtBinDescription.Text.Trim();
        Description.ParameterName = "@Description";
        sqlCmd.Parameters.Add(Description);

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
        txtBinCode.Text = "";
        txtBinlogo.Text = "";
        txtBinDescription.Text = "";
        hdnBinID.Value = "0";



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
