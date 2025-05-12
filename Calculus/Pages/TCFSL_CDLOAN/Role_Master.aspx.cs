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

public partial class Pages_TCFSL_CDLOAN_Role_Master : System.Web.UI.Page
{
    //SingleUserLogin Login = new SingleUserLogin();
    protected void Page_Load(object sender, EventArgs e)
    {
        //Login.ValidateTokenLoginDetails();
        if (!IsPostBack)
        {
            Get_DataForRole();
        }
    }
    private void Get_DataForRole()
    {
        Object SaveUSERInfo = (Object)Session["UserInfo"];
        SqlConnection sqlCon = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);

        try
        {
            SqlCommand sqlCom = new SqlCommand();
            sqlCom.Connection = sqlCon;
            sqlCom.CommandType = CommandType.StoredProcedure;
            sqlCom.CommandText = "TCFSL_UserDetailsPresent_CD_SP";
            sqlCom.CommandTimeout = 0;

            SqlParameter BranchID = new SqlParameter();
            BranchID.SqlDbType = SqlDbType.VarChar;
            BranchID.Value = Convert.ToInt32(((UserInfo.structUSERInfo)(SaveUSERInfo)).BranchId);
            BranchID.ParameterName = "@BranchID";
            sqlCom.Parameters.Add(BranchID);

            sqlCon.Open();

            SqlDataAdapter sqlDA = new SqlDataAdapter();
            sqlDA.SelectCommand = sqlCom;

            DataTable dt = new DataTable();
            sqlDA.Fill(dt);

            sqlCon.Close();

            if (dt.Rows.Count > 0)
            {
                grdrole.DataSource = dt;
                grdrole.DataBind();

            }
            else
            {
                grdrole.DataSource = null;
                grdrole.DataBind();
            }
        }
        catch (Exception ex)
        {
            hiddenResult.Value = "Error :" + ex.Message;
        }
        finally
        {
            sqlCon.Close();
            sqlCon.Dispose();
        }

    }
    protected void ddlrole_SelectedIndexChanged(object sender, EventArgs e)
    {
        Object SaveUSERInfo = (Object)Session["UserInfo"];
        SqlConnection sqlCon = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);

        try
        {
            for (int i = 0; i <= grdrole.Rows.Count - 1; i++)
            {
                CheckBox chkSelect = (CheckBox)grdrole.Rows[i].FindControl("chkSelect");

                if (chkSelect.Checked == true)
                {
                    DropDownList Role1 = (DropDownList)grdrole.Rows[i].FindControl("ddlrole");

                    if (Role1.SelectedValue.ToString() != "0")
                    {
                        grdrole.Rows[i].Cells[4].Text = Role1.SelectedValue.ToString();

                        SqlCommand sqlCom = new SqlCommand();
                        sqlCom.Connection = sqlCon;
                        sqlCom.CommandType = CommandType.StoredProcedure;
                        sqlCom.CommandText = "TCFSL_Changed_Role_CD_SP";
                        sqlCom.CommandTimeout = 0;

                        SqlDataAdapter sqlDA = new SqlDataAdapter();
                        sqlDA.SelectCommand = sqlCom;

                        SqlParameter UseriD = new SqlParameter();
                        UseriD.SqlDbType = SqlDbType.VarChar;
                        UseriD.Value = grdrole.Rows[i].Cells[1].Text.Trim();
                        UseriD.ParameterName = "@UseriD";
                        sqlCom.Parameters.Add(UseriD);

                        SqlParameter Role = new SqlParameter();
                        Role.SqlDbType = SqlDbType.VarChar;
                        Role.Value = grdrole.Rows[i].Cells[4].Text.Trim();
                        Role.ParameterName = "@Role";
                        sqlCom.Parameters.Add(Role);

                        SqlParameter CreatedBy = new SqlParameter();
                        CreatedBy.SqlDbType = SqlDbType.VarChar;
                        CreatedBy.Value = Convert.ToString(((UserInfo.structUSERInfo)(SaveUSERInfo)).UserId);
                        CreatedBy.ParameterName = "@CreatedBy";
                        sqlCom.Parameters.Add(CreatedBy);

                        sqlCon.Open();

                        int SqlRow = 0;
                        SqlRow = sqlCom.ExecuteNonQuery();

                        sqlCon.Close();

                        if (SqlRow > 0)
                        {

                        }

                        else
                        {

                        }
                    }
                }
            }
        }
        catch (Exception ex)
        {
            hiddenResult.Value = "Error :" + ex.Message;
        }
        finally
        {
            sqlCon.Close();
            sqlCon.Dispose();
        }

    }
    protected void BtnCancel_Click(object sender, System.EventArgs e)
    {
        Response.Redirect("~/Pages/Menu.aspx", true);
    }
    protected void grdrole_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        SqlConnection sqlCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);

        if (e.Row.RowType == DataControlRowType.DataRow)
        {

            DropDownList ddlrole = (e.Row.FindControl("ddlrole") as DropDownList);

            SqlCommand cmd = new SqlCommand("TCFSL_MasterSearchCode_SP", sqlCon);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Types", "ChangeRoleType");
            cmd.Parameters.AddWithValue("@Level", 1);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            adp.Fill(ds);

            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                ddlrole.DataSource = ds;
                ddlrole.DataValueField = "Code_Id";
                ddlrole.DataTextField = "Description";
                ddlrole.DataBind();
                ddlrole.Items.Insert(0, new ListItem("--Select--", "0"));
            }
        }
    }
}