using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IncidentTracker
{
    public partial class IT_ChangePassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["Err"] != null)
                {
                    lblMsg.Visible = true;
                    lblMsg.CssClass = "ErrorMessage";
                    lblMsg.Text = Request.QueryString["Err"].ToString();
                    btnLogin.Visible = false;
                    btnReset.Visible = false;

                }

            }
        }
        public void clearlog()
        {
            Object SaveUSERInfo = (Object)Session["UserInfo"];
            SqlConnection sqlCon = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);
            try
            {
                if (sqlCon.State == ConnectionState.Closed)
                    sqlCon.Open();

                SqlCommand command = new SqlCommand("IT_ClearLog_SP", sqlCon);
                command.CommandType = CommandType.StoredProcedure;

                int i = command.ExecuteNonQuery();
                sqlCon.Close();

                if (i > 0)
                {
                }
            }
            catch (Exception ex)
            {
            }
            finally
            {
                if (sqlCon.State == ConnectionState.Open)
                {
                    sqlCon.Close();
                }
            }
        }

        protected void btnConfirm_Click(object sender, EventArgs e)
        {
            try
            {
                Object SaveUSERInfo = (Object)Session["UserInfo"];

                SqlConnection sqlCon = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);

                sqlCon.Open();
                SqlCommand sqlCom = new SqlCommand();
                sqlCom.Connection = sqlCon;
                sqlCom.CommandType = CommandType.StoredProcedure;
                sqlCom.CommandText = "IT_UpdateUserInfo_SP";

                SqlParameter UserId = new SqlParameter();
                UserId.SqlDbType = SqlDbType.VarChar;
                UserId.Value = Convert.ToString(((UserInfo.structUSERInfo)(SaveUSERInfo)).UserId);
                UserId.ParameterName = "@UserId";
                sqlCom.Parameters.Add(UserId);

                SqlParameter OldPassword = new SqlParameter();
                OldPassword.SqlDbType = SqlDbType.VarChar;
                OldPassword.Value = CEncDec.Encrypt(txtOldPassword.Text.Trim(), txtOldPassword.Text.Trim()); ;
                OldPassword.ParameterName = "@OldPassword";
                sqlCom.Parameters.Add(OldPassword);

                SqlParameter Password = new SqlParameter();
                Password.SqlDbType = SqlDbType.VarChar;
                Password.Value = CEncDec.Encrypt(txtNewPassword.Text.Trim(), txtNewPassword.Text.Trim()); ;
                Password.ParameterName = "@NewPassword";
                sqlCom.Parameters.Add(Password);

                SqlParameter IsSysAdmin = new SqlParameter();
                IsSysAdmin.SqlDbType = SqlDbType.Bit;
                IsSysAdmin.Value = 0;
                IsSysAdmin.ParameterName = "@IsSysAdmin";
                sqlCom.Parameters.Add(IsSysAdmin);

                SqlParameter ModifyBy = new SqlParameter();
                ModifyBy.SqlDbType = SqlDbType.VarChar;
                ModifyBy.Value = Convert.ToString(((UserInfo.structUSERInfo)(SaveUSERInfo)).UserId);
                ModifyBy.ParameterName = "@ModifyBy";
                sqlCom.Parameters.Add(ModifyBy);

                SqlParameter BranchId = new SqlParameter();
                BranchId.SqlDbType = SqlDbType.VarChar;
                BranchId.Value = Convert.ToString(((UserInfo.structUSERInfo)(SaveUSERInfo)).BranchId);
                BranchId.ParameterName = "@BranchId";
                sqlCom.Parameters.Add(BranchId);

                SqlParameter VarResultOut = new SqlParameter();
                VarResultOut.SqlDbType = SqlDbType.Int;
                VarResultOut.Value = null;
                VarResultOut.ParameterName = "@VarResultOut";
                VarResultOut.Size = 200;
                VarResultOut.Direction = ParameterDirection.Output;
                sqlCom.Parameters.Add(VarResultOut);

                sqlCom.ExecuteNonQuery();
                int AddParameter = Convert.ToInt32(sqlCom.Parameters["@VarResultOut"].Value);

                sqlCon.Close();

                if (AddParameter == 1)
                {
                    lblMsg.Text = "Update Successfuly";
                    lblMsg.CssClass = "UpdateMessage";
                    lblMsg.Visible = true;
                    btnLogin.Visible = true;
                    btnReset.Visible = true;
                    btnConfirm.Visible = false;
                }
                else
                {
                    lblMsg.Text = "Wrong Old Password";
                    lblMsg.CssClass = "ErrorMessage";
                    lblMsg.Visible = true;

                }
            }
            catch (Exception ex)
            {
                lblMsg.Visible = true;
                lblMsg.Text = ex.Message;
                lblMsg.CssClass = "ErrorMessage";
            }
        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            txtOldPassword.Text = "";
            txtNewPassword.Text = "";
            txtConfirmPassword.Text = "";
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            if (Session["UserInfo"] != null)
            {
                Session.Clear();
                Response.Redirect("IT_LoginPage.aspx", false);
            }
        }

        protected void lnkclear_Click(object sender, EventArgs e)
        {
            clearlog();
        }
    }
}