using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace ChangeManagement
{
    public partial class CM_UserMaster : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindRole();
                BindBranch();
                Register_ControlsWithJavaScript();
                BindReportingManager();
            }
        }

        protected void BindRole()
        {
            try
            {
                SqlConnection sqlCon = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());

                SqlCommand sqlCom = new SqlCommand();
                sqlCom.Connection = sqlCon;
                sqlCom.CommandType = CommandType.StoredProcedure;
                sqlCom.CommandText = "CM_RoleMaster_SP";
                sqlCom.CommandTimeout = 0;

                SqlDataAdapter da = new SqlDataAdapter(sqlCom);
                DataSet ds = new DataSet();
                da.Fill(ds);

                if (ds != null && ds.Tables.Count > 0)
                {
                    ddlRoleId.DataTextField = "RoleDescription";
                    ddlRoleId.DataValueField = "RoleId";
                    ddlRoleId.DataSource = ds.Tables[0];
                    ddlRoleId.DataBind();

                    ddlRoleId.Items.Insert(0, "--Select--");
                    ddlRoleId.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
            }
        }

        protected void BindBranch()
        {
            try
            {
                SqlConnection sqlCon = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());

                SqlCommand sqlCom = new SqlCommand();
                sqlCom.Connection = sqlCon;
                sqlCom.CommandType = CommandType.StoredProcedure;
                sqlCom.CommandText = "CM_Branch_Master_SP";
                sqlCom.CommandTimeout = 0;

                SqlDataAdapter da = new SqlDataAdapter(sqlCom);
                DataSet ds = new DataSet();
                da.Fill(ds);

                if (ds != null && ds.Tables.Count > 0)
                {
                    ddlBranch.DataTextField = "BranchName";
                    ddlBranch.DataValueField = "BranchId";
                    ddlBranch.DataSource = ds.Tables[0];
                    ddlBranch.DataBind();

                    ddlBranch.Items.Insert(0, "--Select Branch--");
                    ddlBranch.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
            }
        }

        private void Register_ControlsWithJavaScript()
        {
            btnAddNew.Attributes.Add("onclick", "javascript:return Validate_AddNEW();");
            btnSave.Attributes.Add("onclick", "javascript:return Validate_Save();");

        }

        protected void GetUserDetails(string UserId)
        {
            SqlConnection sqlCon = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());

            SqlCommand cmd = new SqlCommand("CM_GetUserDetails", sqlCon);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@UserId", UserId);
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
        protected void lnkAutoGenerate_Click(object sender, EventArgs e)
        {
            txtPassword.Text = GenerateAutoPassword();
        }
        private void Insert_UserInfo()
        {
            try
            {

                SqlConnection sqlCon = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());

                SqlCommand sqlCom = new SqlCommand();
                sqlCom.Connection = sqlCon;
                sqlCom.CommandType = CommandType.StoredProcedure;
                sqlCom.CommandText = "CM_InsertUserMaster";

                //SqlParameter ID = new SqlParameter();
                //ID.SqlDbType = SqlDbType.VarChar;
                //ID.Value = Convert.ToInt32(hdnUserId.Value);
                //ID.ParameterName = "@ID";
                //sqlCom.Parameters.Add(ID);

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
                Password.ParameterName = "@Password";
                sqlCom.Parameters.Add(Password);

                SqlParameter RoleID = new SqlParameter();
                RoleID.SqlDbType = SqlDbType.Int;
                RoleID.Value = ddlRoleId.SelectedValue.ToString();
                RoleID.ParameterName = "@RoleID";
                sqlCom.Parameters.Add(RoleID);

                SqlParameter IsActive = new SqlParameter();
                IsActive.SqlDbType = SqlDbType.Bit;
                IsActive.Value = Convert.ToBoolean(ddlIsActivate.SelectedItem.Value);
                IsActive.ParameterName = "@IsActive";
                sqlCom.Parameters.Add(IsActive);

                SqlParameter Branch = new SqlParameter();
                Branch.SqlDbType = SqlDbType.Int;
                Branch.Value = ddlBranch.SelectedValue.ToString();
                Branch.ParameterName = "@Branch";
                sqlCom.Parameters.Add(Branch);

                //SqlParameter Location = new SqlParameter();
                //Location.SqlDbType = SqlDbType.VarChar;
                //Location.Value = Convert.ToString(Session["Location"]);
                //Location.ParameterName = "@Location";
                //sqlCom.Parameters.Add(Location);


                //SqlParameter APSID = new SqlParameter();
                //APSID.SqlDbType = SqlDbType.VarChar;
                //APSID.Value = txtUserAPSID.Text.Trim();
                //APSID.ParameterName = "@UserAPSID";
                //sqlCom.Parameters.Add(APSID);

                SqlParameter RightsBy = new SqlParameter();
                RightsBy.SqlDbType = SqlDbType.VarChar;
                RightsBy.Value = Convert.ToString(Session["UserID"]);
                RightsBy.ParameterName = "@RightsBy";
                sqlCom.Parameters.Add(RightsBy);

                SqlParameter RM = new SqlParameter();
                RM.SqlDbType = SqlDbType.VarChar;
                RM.Value = ddlReportingManager.SelectedValue.ToString();
                RM.ParameterName = "@ReportingManager";
                sqlCom.Parameters.Add(RM);

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

        protected void grv_GroupInfo_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes.Add("onclick", "javascript:Pro_SelectRow('" + e.Row.RowIndex + "','" + e.Row.Cells[0].Text + "')");
                e.Row.Attributes.Add("onmouseover", "javascript:hover('in','" + e.Row.RowIndex + "');");
                e.Row.Attributes.Add("onmouseout", "javascript:hover('out','" + e.Row.RowIndex + "');");
            }
        }
        protected void ClearAllText()
        {
            txtUserName.Text = "";
            txtUserID.Text = "";
            txtEmail.Text = "";
            txtPassword.Text = "";
            ddlRoleId.SelectedIndex = 0;
            ddlIsActivate.SelectedIndex = 0;
            ddlBranch.SelectedIndex = 0;
            hdnUserId.Value = "0";
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (txtUserName.Text != "")
            {
                if (txtUserID.Text != "")
                {
                    if (txtPassword.Text != "")
                    {
                        if (ddlIsActivate.SelectedIndex != 0 && ddlIsActivate.SelectedItem.Text != "--Select--")
                        {
                            if (ddlRoleId.SelectedIndex != 0 && ddlRoleId.SelectedItem.Text != "--Select--")
                            {
                                if (ddlBranch.SelectedIndex != 0 && ddlBranch.SelectedItem.Text != "--Select Branch--")
                                {
                                    if (ddlReportingManager.SelectedIndex != 0 && ddlReportingManager.SelectedItem.Text != "--Select--")
                                    {
                                        Insert_UserInfo();
                                    }
                                    else
                                    {
                                        lblMessage.Visible = true;
                                        lblMessage.Text = "Please Select Reporting Manager";
                                        return;
                                    }
                                }
                                else
                                {
                                    lblMessage.Visible = true;
                                    lblMessage.Text = "Please Select Branch";
                                    return;
                                }
                            }
                            else
                            {
                                lblMessage.Visible = true;
                                lblMessage.Text = "Please Select Role";
                                return;
                            }
                        }
                        else
                        {
                            lblMessage.Visible = true;
                            lblMessage.Text = "Please Select Is Active";
                            return;
                        }
                    }
                    else
                    {
                        lblMessage.Visible = true;
                        lblMessage.Text = "Please Enter Password";
                        return;
                    }

                }
                else
                {
                    lblMessage.Visible = true;
                    lblMessage.Text = "Please Enter Employee Code";
                    return;
                }
            }
            else
            {
                lblMessage.Visible = true;
                lblMessage.Text = "Please Enter Employee Name";
                return;
            }
            ClearAllText();
        }

        protected void btnAddNew_Click(object sender, EventArgs e)
        {
            if (txtUserName.Text != "")
            {
                if (txtUserID.Text != "")
                {
                    if (txtPassword.Text != "")
                    {
                        if (ddlIsActivate.SelectedIndex != 0 && ddlIsActivate.SelectedItem.Text != "--Select--")
                        {
                            if (ddlRoleId.SelectedIndex != 0 && ddlRoleId.SelectedItem.Text != "--Select--")
                            {
                                if (ddlBranch.SelectedIndex != 0 && ddlBranch.SelectedItem.Text != "--Select Branch--")
                                {
                                    Insert_UserInfo();
                                }
                                else
                                {
                                    lblMessage.Visible = true;
                                    lblMessage.Text = "Please Select Branch";
                                    return;
                                }
                            }
                            else
                            {
                                lblMessage.Visible = true;
                                lblMessage.Text = "Please Select Role";
                                return;
                            }
                        }
                        else
                        {
                            lblMessage.Visible = true;
                            lblMessage.Text = "Please Select Is Active";
                            return;
                        }
                    }
                    else
                    {
                        lblMessage.Visible = true;
                        lblMessage.Text = "Please Enter Password";
                        return;
                    }

                }
                else
                {
                    lblMessage.Visible = true;
                    lblMessage.Text = "Please Enter Employee Code";
                    return;
                }
            }
            else
            {
                lblMessage.Visible = true;
                lblMessage.Text = "Please Enter Employee Name";
                return;
            }
            ClearAllText();
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            ClearAllText();
            Response.Redirect("CM_MenuPage.aspx", true);
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
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
                sqlCom.CommandText = "CM_BindReportingManagerList_SP";
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