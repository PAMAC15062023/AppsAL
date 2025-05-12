using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using YesBank;

namespace CoreDailyMISAutomation
{
    public partial class UserMaster : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindRole();
                BindCPC();
                //BindSubVertical();
                BindReportingManager(); //add on 25/01/2025
            }
        }

        protected void BindRole()
        {
            try
            {
                SqlConnection sqlCon = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);

                SqlCommand sqlCom = new SqlCommand();
                sqlCom.Connection = sqlCon;
                sqlCom.CommandType = CommandType.StoredProcedure;
                sqlCom.CommandText = "CDMA_BindRole";
                sqlCom.CommandTimeout = 0;

                SqlDataAdapter da = new SqlDataAdapter(sqlCom);
                DataSet ds = new DataSet();
                da.Fill(ds);

                if (ds != null && ds.Tables.Count > 0)
                {
                    ddlRoleId.DataTextField = "Role";
                    ddlRoleId.DataValueField = "ID";
                    ddlRoleId.DataSource = ds.Tables[0];
                    ddlRoleId.DataBind();

                    ddlRoleId.Items.Insert(0, "--Select--");
                    ddlRoleId.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {

            }
        }

        protected void BindCPC()
        {
            try
            {
                SqlConnection sqlCon = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);

                SqlCommand sqlCom = new SqlCommand();
                sqlCom.Connection = sqlCon;
                sqlCom.CommandType = CommandType.StoredProcedure;
                sqlCom.CommandText = "CDMA_BindBranchMaster";
                sqlCom.CommandTimeout = 0;

                SqlDataAdapter da = new SqlDataAdapter(sqlCom);
                DataSet ds = new DataSet();
                da.Fill(ds);

                if (ds != null && ds.Tables.Count > 0)
                {
                    ddlCPC.DataTextField = "BranchName";
                    ddlCPC.DataValueField = "ID";
                    ddlCPC.DataSource = ds.Tables[0];
                    ddlCPC.DataBind();

                    ddlCPC.Items.Insert(0, "--Select--");
                    ddlCPC.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {

            }
        }

        //protected void BindSubVertical()
        //{
        //    try
        //    {
        //        SqlConnection sqlCon = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);

        //        SqlCommand sqlCom = new SqlCommand();
        //        sqlCom.Connection = sqlCon;
        //        sqlCom.CommandType = CommandType.StoredProcedure;
        //        sqlCom.CommandText = "CDMA_BindSubVertical";
        //        sqlCom.CommandTimeout = 0;

        //        SqlDataAdapter da = new SqlDataAdapter(sqlCom);
        //        DataSet ds = new DataSet();
        //        da.Fill(ds);

        //        if (ds != null && ds.Tables.Count > 0)
        //        {
        //            ddlVertical.DataTextField = "SubVertical";
        //            ddlVertical.DataValueField = "ID";
        //            ddlVertical.DataSource = ds.Tables[0];
        //            ddlVertical.DataBind();

        //            ddlVertical.Items.Insert(0, "--Select--");
        //            ddlVertical.SelectedIndex = 0;
        //        }
        //    }
        //    catch (Exception ex)
        //    {

        //    }
        //}

        protected void GetUserDetails(string UserID)
        {
            SqlConnection sqlCon = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);

            SqlCommand cmd = new SqlCommand("CDMA_GetUserDetails_SP", sqlCon);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@UserID", UserID);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            adp.Fill(ds);

            if (ds != null && ds.Tables.Count > 0)
            {
                grv_GroupInfo.DataSource = ds;
                grv_GroupInfo.DataBind();
            }
        }

        public string GenerateAutoPassword()
        {
            try
            {
                int i;
                int CharLength = Convert.ToInt16(ConfigurationManager.AppSettings["CharLength"]);
                int SpecialCharLength = Convert.ToInt16(ConfigurationManager.AppSettings["SpecialCharLength"]); ;
                int NumericLength = Convert.ToInt16(ConfigurationManager.AppSettings["NumLength"]); ;

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

        private void Insert_UserInfo()
        {
            try
            {
                string msg = string.Empty;

                if (txtUserName.Text.Trim() == "" || txtUserName.Text.Trim() == null)
                {
                    msg = msg + "Please Enter Employee Name !! ";
                }
                if (txtUserId.Text.Trim() == "" || txtUserId.Text.Trim() == null)
                {
                    msg = msg + "Please Enter Employee Code !! ";
                }
                if (txtPassword.Text.Trim() == "" || txtPassword.Text.Trim() == null)
                {
                    msg = msg + "Please Enter Password !! ";
                }

                if (ddlCPC.SelectedValue == "--Select--")
                {
                    msg = msg + "Please Select CPC !! ";
                }

                //if (ddlVertical.SelectedValue == "--Select--")
                //{
                //    msg = msg + "Please Select Vertical !! ";
                //}

                if (ddlIsActivate.SelectedValue == "--Select--")
                {
                    msg = msg + "Please Select Is Active!! ";
                }

                if (ddlRoleId.SelectedValue == "--Select--")
                {
                    msg = msg + "Please Select Role !! ";
                }

                if (ddlReportingManager.SelectedValue == "--Select--")
                {
                    msg = msg + "Please Select Reporting Manager !! ";
                }

                if (msg != "")
                {
                    ClientScript.RegisterStartupScript(Page.GetType(), "mykey", "alert('" + msg + "');", true);
                    return;
                }

                SqlConnection sqlCon = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);

                SqlCommand sqlCom = new SqlCommand();
                sqlCom.Connection = sqlCon;
                sqlCom.CommandType = CommandType.StoredProcedure;
                sqlCom.CommandText = "CDMA_InsertUserMaster_SP";

                SqlParameter ID = new SqlParameter();
                ID.SqlDbType = SqlDbType.VarChar;
                ID.Value = Convert.ToInt32(hdnId.Value);
                ID.ParameterName = "@ID";
                sqlCom.Parameters.Add(ID);

                SqlParameter UserName = new SqlParameter();
                UserName.SqlDbType = SqlDbType.VarChar;
                UserName.Value = txtUserName.Text.Trim();
                UserName.ParameterName = "@UserName";
                sqlCom.Parameters.Add(UserName);

                SqlParameter UserId = new SqlParameter();
                UserId.SqlDbType = SqlDbType.VarChar;
                UserId.Value = txtUserId.Text.Trim();
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
                Password.ParameterName = "@Password";
                sqlCom.Parameters.Add(Password);

                SqlParameter RoleID = new SqlParameter();
                RoleID.SqlDbType = SqlDbType.Int;
                RoleID.Value = ddlRoleId.SelectedValue;
                RoleID.ParameterName = "@RoleID";
                sqlCom.Parameters.Add(RoleID);

                SqlParameter IsActive = new SqlParameter();
                IsActive.SqlDbType = SqlDbType.Bit;
                IsActive.Value = Convert.ToBoolean(ddlIsActivate.SelectedItem.Value);
                IsActive.ParameterName = "@IsActive";
                sqlCom.Parameters.Add(IsActive);

                SqlParameter Branch_Hub_Id = new SqlParameter();
                Branch_Hub_Id.SqlDbType = SqlDbType.VarChar;
                Branch_Hub_Id.Value = ddlCPC.SelectedValue;
                Branch_Hub_Id.ParameterName = "@CPC";
                sqlCom.Parameters.Add(Branch_Hub_Id); 

                SqlParameter RightsBy = new SqlParameter();
                RightsBy.SqlDbType = SqlDbType.VarChar;
                RightsBy.Value = Convert.ToString(Session["UserId"]);
                RightsBy.ParameterName = "@RightsBy";
                sqlCom.Parameters.Add(RightsBy);

                SqlParameter ReportingManager = new SqlParameter(); //add on 25/01/2025
                ReportingManager.SqlDbType = SqlDbType.VarChar;
                ReportingManager.Value = ddlReportingManager.SelectedValue.ToString();
                ReportingManager.ParameterName = "@ReportingManager";
                sqlCom.Parameters.Add(ReportingManager);

                SqlDataAdapter adp = new SqlDataAdapter(sqlCom);
                DataSet ds = new DataSet();
                adp.Fill(ds);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    if (ds.Tables[0].Rows[0][0].ToString() == "TRUE")
                    {
                        lblMessage.Text = ds.Tables[0].Rows[0]["MESSAGE"].ToString();
                        GetUserDetails(txtSearchUserID.Text);
                    }
                    else
                    {
                        lblMessage.Text = ds.Tables[0].Rows[0]["MESSAGE"].ToString();
                    }

                }
                else
                {
                    lblMessage.Visible = true;
                    lblMessage.Text = "Error While Saving Record";
                }
            }
            catch (Exception ex)
            {
                lblMessage.Visible = true;
                lblMessage.Text = ex.Message;
                lblMessage.CssClass = "ErrorMessage";
            }
        }
        protected void ClearAllText()
        {
            txtUserName.Text = "";
            txtUserId.Text = "";
            txtEmail.Text = "";
            txtPassword.Text = "";
            ddlRoleId.SelectedIndex = 0;
            ddlIsActivate.SelectedIndex = 0;
            ddlCPC.SelectedIndex = 0;
            //txtVertical.Text = "";
            hdnId.Value = "0";
            ddlReportingManager.SelectedIndex = 0;
        }

        protected void lnkAutoGenetae_Click(object sender, EventArgs e)
        {
            txtPassword.Text = GenerateAutoPassword();
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
        protected void btnSave_Click(object sender, EventArgs e)
        {
            Insert_UserInfo();
            ClearAllText();
        }
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            ClearAllText();
            Response.Redirect("CDMA_Menu.aspx", true);
        }

        protected void btnGo_Click(object sender, EventArgs e)
        {
            lblMessage.Text = "";
            GetUserDetails(txtSearchUserID.Text);
        }

        protected void BindReportingManager()
        {
            try
            {
                SqlConnection sqlCon = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());

                SqlCommand sqlCom = new SqlCommand();
                sqlCom.Connection = sqlCon;
                sqlCom.CommandType = CommandType.StoredProcedure;
                sqlCom.CommandText = "CDMA_BindReportingManagerList_SP";
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
}