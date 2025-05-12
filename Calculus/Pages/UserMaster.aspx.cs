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


public partial class UserMaster : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserInfo"] == null)
        {
            Response.Redirect("~/Pages/InvalidRequest.aspx", false);
        }

        if (!IsPostBack)
        {
            Get_BranchList();
            Get_GroupMaster();
            //Get_UserInfo("");
            Register_ControlsWithJavaScript();
            BindReportingManager(); //add on 25/01/2025
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        Insert_UserInfo();
        Get_UserInfo(txtUserID.Text);
        Reset_Controls();
    }
    protected void btnAddNew_Click(object sender, EventArgs e)
    {

    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Pages/Menu.aspx", true);
    }
    private void Get_GroupMaster()
    {
        try
        {
            Object SaveUSERInfo = (Object)Session["UserInfo"];

            SqlConnection sqlCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);

            sqlCon.Open();
            SqlCommand sqlCom = new SqlCommand();
            sqlCom.Connection = sqlCon;
            sqlCom.CommandType = CommandType.StoredProcedure;
            sqlCom.CommandText = "AdminMaster_Get_GroupMaster_SP";

            int pBranchId = 0;
            if (ddlBranchList.SelectedIndex != 0)
            {
                pBranchId = Convert.ToInt32(ddlBranchList.SelectedItem.Value);
            }


            SqlParameter BranchId = new SqlParameter();
            BranchId.SqlDbType = SqlDbType.Int;
            BranchId.Value = pBranchId; //Convert.ToInt32(((UserInfo.structUSERInfo)(SaveUSERInfo)).BranchId);
            BranchId.ParameterName = "@BranchId";
            sqlCom.Parameters.Add(BranchId);

            SqlDataAdapter sqlDA = new SqlDataAdapter();
            sqlDA.SelectCommand = sqlCom;
            DataTable dt = new DataTable();
            sqlDA.Fill(dt);
            sqlCon.Close();

            ddlUserGroupList.DataTextField = "GroupName";
            ddlUserGroupList.DataValueField = "GroupId";

            ddlUserGroupList.DataSource = dt;
            ddlUserGroupList.DataBind();

            ddlUserGroupList.Items.Insert(0, "--Select--");
            ddlUserGroupList.SelectedIndex = 0;



        }
        catch (Exception ex)
        {
            lblMessage.Visible = true;
            lblMessage.Text = ex.Message;
            lblMessage.CssClass = "ErrorMessage";
        }
    }
    private void Get_UserInfo(string pUserID)
    {
        Object SaveUSERInfo = (Object)Session["UserInfo"];
        SqlConnection sqlCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);

        try
        {
            if (sqlCon.State == ConnectionState.Closed)
            {
                sqlCon.Open();

                SqlCommand sqlCom = new SqlCommand();
                sqlCom.Connection = sqlCon;
                sqlCom.CommandType = CommandType.StoredProcedure;
                //sqlCom.CommandText = "Get_UserInfo";
                sqlCom.CommandText = "AdminMaster_UserInfo05082020_SP";//Get_UserInfo1

                int pBranchId = 0;
                if (ddlBranchList.SelectedIndex != 0)
                {
                    pBranchId = Convert.ToInt32(ddlBranchList.SelectedItem.Value);
                }

                SqlParameter BranchId = new SqlParameter();
                BranchId.SqlDbType = SqlDbType.Int;
                BranchId.Value = pBranchId;
                BranchId.ParameterName = "@BranchId";
                sqlCom.Parameters.Add(BranchId);

                SqlParameter UserID = new SqlParameter();
                UserID.SqlDbType = SqlDbType.VarChar;
                UserID.Value = pUserID.Trim();
                UserID.ParameterName = "@UserID";
                sqlCom.Parameters.Add(UserID);

                SqlDataAdapter sqlDA = new SqlDataAdapter();
                sqlDA.SelectCommand = sqlCom;

                DataTable dt = new DataTable();
                sqlDA.Fill(dt);
                sqlCon.Close();

                grv_GroupInfo.DataSource = dt;
                grv_GroupInfo.DataBind();
            }
        }
        catch (SqlException sqlex)
        {
            lblMessage.Text = sqlex.Message.ToString();
        }
        catch (Exception ex)
        {
            lblMessage.Visible = true;
            lblMessage.Text = ex.Message;
            lblMessage.CssClass = "ErrorMessage";
        }
        finally
        {
            if (sqlCon.State == ConnectionState.Open)
            {
                sqlCon.Close();
            }
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
        }
    }

    protected void ddlBranchList_SelectedIndexChanged(object sender, EventArgs e)
    {

        if (ddlBranchList.SelectedIndex != 0)
        {
            Get_GroupMaster();
            Get_UserInfo("");
        }

    }

    protected void grv_GroupInfo_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Attributes.Add("onclick", "javascript:Pro_SelectRow('" + e.Row.RowIndex + "','" + e.Row.Cells[0].Text + "')");
            e.Row.Attributes.Add("onmouseover", "javascript:hover('in','" + e.Row.RowIndex + "');");
            e.Row.Attributes.Add("onmouseout", "javascript:hover('out','" + e.Row.RowIndex + "');");
        }
        //e.Row.Cells[6].CssClass = "grv_Column_hidden";
        //e.Row.Cells[7].CssClass = "grv_Column_hidden";
    }
    private void Reset_Controls()
    {
        txtUserName.Text = "";
        txtUserID.Text = "";
        txtEmail.Text = "";
        txtPassword.Text = "";
        ddlBranchList.SelectedIndex = 0;
        ddlIsActivate.SelectedIndex = 0;
        ddlUserGroupList.SelectedIndex = 0;
        ddlProduct.ClearSelection();
    }

    private void Insert_UserInfo()
    {
        try
        {
            Object SaveUSERInfo = (Object)Session["UserInfo"];

            SqlConnection sqlCon = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);

            sqlCon.Open();
            SqlCommand sqlCom = new SqlCommand();
            sqlCom.Connection = sqlCon;
            sqlCom.CommandType = CommandType.StoredProcedure;
            //sqlCom.CommandText = "Insert_UserInfo";
            sqlCom.CommandText = "AdminMaster_InsertUserInfo05082020_SP";//Insert_UserInfo1

            int pBranchId = 0;
            if (ddlBranchList.SelectedIndex != 0)
            {
                pBranchId = Convert.ToInt32(ddlBranchList.SelectedItem.Value);
            }

            SqlParameter BranchId = new SqlParameter();
            BranchId.SqlDbType = SqlDbType.Int;
            BranchId.Value = pBranchId;
            BranchId.ParameterName = "@BranchID";
            sqlCom.Parameters.Add(BranchId);

            SqlParameter UserName = new SqlParameter();
            UserName.SqlDbType = SqlDbType.VarChar;
            UserName.Value = txtUserName.Text.Trim();
            UserName.ParameterName = "@UserName";
            sqlCom.Parameters.Add(UserName);

            SqlParameter UserId = new SqlParameter();
            UserId.SqlDbType = SqlDbType.VarChar;
            UserId.Value = txtUserID.Text.Trim();
            UserId.ParameterName = "@UserId";
            sqlCom.Parameters.Add(UserId);

            SqlParameter EmailId = new SqlParameter();
            EmailId.SqlDbType = SqlDbType.VarChar;
            EmailId.Value = txtEmail.Text.Trim();
            EmailId.ParameterName = "@EmailId";
            sqlCom.Parameters.Add(EmailId);

            SqlParameter Password = new SqlParameter();
            Password.SqlDbType = SqlDbType.VarChar;
            Password.Value = CEncDec.Encrypt(txtPassword.Text.Trim(), txtPassword.Text.Trim());
            //Password.Value =txtPassword.Text.Trim();
            Password.ParameterName = "@Password";
            sqlCom.Parameters.Add(Password);

            SqlParameter GroupId = new SqlParameter();
            GroupId.SqlDbType = SqlDbType.Int;
            GroupId.Value = Convert.ToInt32(ddlUserGroupList.SelectedItem.Value);
            GroupId.ParameterName = "@GroupId";
            sqlCom.Parameters.Add(GroupId);

            SqlParameter IsActive = new SqlParameter();
            IsActive.SqlDbType = SqlDbType.Bit;
            IsActive.Value = Convert.ToBoolean(ddlIsActivate.SelectedItem.Value);
            IsActive.ParameterName = "@IsActive";
            sqlCom.Parameters.Add(IsActive);

            SqlParameter Product = new SqlParameter();
            Product.SqlDbType = SqlDbType.VarChar;
            Product.Value = ddlProduct.SelectedItem.Text.ToString().Trim();
            Product.ParameterName = "@Product";
            sqlCom.Parameters.Add(Product);

            SqlParameter IsSysAdmin = new SqlParameter();
            IsSysAdmin.SqlDbType = SqlDbType.Bit;
            IsSysAdmin.Value = 1;
            IsSysAdmin.ParameterName = "@IsSysAdmin";
            sqlCom.Parameters.Add(IsSysAdmin);

            SqlParameter RightsBy = new SqlParameter();
            RightsBy.SqlDbType = SqlDbType.VarChar;
            RightsBy.Value = Convert.ToString(((UserInfo.structUSERInfo)(SaveUSERInfo)).UserId);
            RightsBy.ParameterName = "@RightsBy";
            sqlCom.Parameters.Add(RightsBy);

            SqlParameter ReportingManager = new SqlParameter(); //add on 25/01/2025
            ReportingManager.SqlDbType = SqlDbType.VarChar;
            ReportingManager.Value = ddlReportingManager.SelectedValue.ToString();
            ReportingManager.ParameterName = "@ReportingManager";
            sqlCom.Parameters.Add(ReportingManager);

            int Rows = 0;

            Rows = sqlCom.ExecuteNonQuery();

            if (Rows > 0)
            {
                lblMessage.Text = "Update Successfully!";
                lblMessage.CssClass = "UpdateMessage";
                lblMessage.Visible = true;
            }

            sqlCon.Close();

        }
        catch (Exception ex)
        {
            lblMessage.Visible = true;
            lblMessage.Text = ex.Message;
            lblMessage.CssClass = "ErrorMessage";
        }
    }
    private void Register_ControlsWithJavaScript()
    {
        btnAddNew.Attributes.Add("onclick", "javascript:return Validate_AddNEW();");
        btnSave.Attributes.Add("onclick", "javascript:return Validate_Save();");

    }

    protected void btnGo_Click(object sender, EventArgs e)
    {
        Get_UserInfo(txtSearchUserID.Text.Trim());
    }
    protected void lnkAutoGenetae_Click(object sender, EventArgs e)
    {
        txtPassword.Text = Generate_AutoPassword();

    }
    public string Generate_AutoPassword()
    {
        try
        {
            int i;
            int CharLength = Convert.ToInt16(ConfigurationSettings.AppSettings["CharLength"]);
            int SpecialCharLength = Convert.ToInt16(ConfigurationSettings.AppSettings["SpecialCharLength"]); ;
            int NumericLength = Convert.ToInt16(ConfigurationSettings.AppSettings["NumLength"]); ;

            string strPassword = "";
            Random Rn = new Random();

            for (i = 0; i < CharLength; i++)
            {
                if (i == 0)
                {
                    strPassword = strPassword + Convert.ToChar(Rn.Next(65, 90));
                }
                else
                {
                    strPassword = strPassword + Convert.ToChar(Rn.Next(97, 122));
                }
            }

            for (i = 0; i < SpecialCharLength; i++)
            {
                strPassword = strPassword + Convert.ToChar(Rn.Next(64, 64));
            }

            for (i = 0; i < NumericLength; i++)
            {
                strPassword = strPassword + Convert.ToChar(Rn.Next(48, 57));
            }

            //lblChangePassword.Text = "New Password Generated: " + strPassword;
            return strPassword;

        }
        catch (Exception ex)
        {
            string st = ex.Message;
            return "";
        }

    }

    protected void BindReportingManager() //add on 25/01/2025
    {
        try
        {
            SqlConnection sqlCon = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);

            SqlCommand sqlCom = new SqlCommand();
            sqlCom.Connection = sqlCon;
            sqlCom.CommandType = CommandType.StoredProcedure;
            sqlCom.CommandText = "Cal_BindReportingManagerList_SP";
            sqlCom.CommandTimeout = 0;

            SqlDataAdapter da = new SqlDataAdapter(sqlCom);
            DataSet ds = new DataSet();
            da.Fill(ds);

            if (ds != null && ds.Tables.Count > 0)
            {

                ddlReportingManager.DataValueField = "UserId";
                ddlReportingManager.DataTextField = "UserName";
                ddlReportingManager.DataSource = ds.Tables[0];
                ddlReportingManager.DataBind();

                ddlReportingManager.Items.Insert(0, "--Select--");
                ddlReportingManager.SelectedIndex = 0;
            }
        }
        catch (Exception ex)
        {
            string msg = ex.Message;
        }
    }

}
