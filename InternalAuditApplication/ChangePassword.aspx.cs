using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace InternalAuditApplication
{
    public partial class ChangePassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnConfirm_Click(object sender, EventArgs e)
        {
            lblMsg.Text = "";

            SqlConnection sqlCon = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "InternalAudit_ChangePassWord_SP";
                cmd.Connection = sqlCon;
                cmd.Parameters.AddWithValue("@UserId", Session["UserID"].ToString());
                cmd.Parameters.AddWithValue("@mode", "Update");
                SqlParameter OldPassword = new SqlParameter();
                OldPassword.SqlDbType = SqlDbType.VarChar;
                OldPassword.Value = CEncDec.Encrypt(txtOldPassword.Text.Trim(), txtOldPassword.Text.Trim()); ;
                OldPassword.ParameterName = "@OldPassWord ";
                cmd.Parameters.Add(OldPassword);
                SqlParameter Password = new SqlParameter();
                Password.SqlDbType = SqlDbType.VarChar;
                Password.Value = CEncDec.Encrypt(txtNewPassword.Text.Trim(), txtNewPassword.Text.Trim()); ;
                Password.ParameterName = "@NewPassword";
                cmd.Parameters.Add(Password);

                sqlCon.Open();
                int i = cmd.ExecuteNonQuery();

                if (i > 0)
                {

                    // ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Record Update Successfully Successfully')", true);

                    lblMsg.Visible = true;
                    lblMsg.Text = "Record Update Successfully Successfully";
                    return;
                }
                else
                {
                    //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('OldPassWord Does not match Please Check Old Password')", true);

                    lblMsg.Visible = true;
                    lblMsg.Text = "OldPassWord Does not match Please Check Old Password";
                    return;

                }


            }
            catch (Exception ex)
            {

                ex.ToString();
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
            if (Session["UserID"] != null)
            {
                Session.Clear();
                Response.Redirect("Login.aspx", false);
            }
        }
    }
}