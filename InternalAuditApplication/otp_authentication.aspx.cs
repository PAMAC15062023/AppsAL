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
    public partial class otp_authentication : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnVerify_Click(object sender, EventArgs e)
        {
            SqlConnection sqlCon = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"].ToString());
            try
            {
                if (sqlCon.State == ConnectionState.Closed)
                {

                    SqlCommand sqlCom = new SqlCommand();
                    sqlCom.Connection = sqlCon;
                    sqlCom.CommandType = CommandType.StoredProcedure;
                    sqlCom.CommandText = "Cal_Check_OTP_SP";
                    sqlCom.CommandTimeout = 0;
                    sqlCom.Parameters.AddWithValue("@OTP", txtOTP.Text.Trim());
                    sqlCom.Parameters.AddWithValue("@UserId", Convert.ToString(Session["UserId"]));

                    SqlDataAdapter sqlDA = new SqlDataAdapter();
                    sqlDA.SelectCommand = sqlCom;

                    DataTable dt = new DataTable();
                    sqlDA.Fill(dt);

                    if (dt.Rows.Count > 0)
                    {
                        if (Convert.ToBoolean(dt.Rows[0]["msg"].ToString()) == true)
                        {
                            Session["isMFA_Valid"] = "Yes";
                            int RoleID = Convert.ToInt32(Session["RoleID"]);

                            if (RoleID == 1)
                            {
                                Response.Redirect("InternalAudit_Menu.aspx", true);
                            }
                            else if (RoleID == 2)
                            {
                                Response.Redirect("InternalAudit_Menu.aspx", true);
                            }
                            else if (RoleID == 1002)
                            {
                                Response.Redirect("InternalAudit_Menu.aspx", true);
                            }
                        }
                        else
                        {
                            lblMessage.Text = "Invalid OTP";
                        }
                    }
                    else
                    {
                        lblMessage.Text = "Invalid OTP";
                    }
                }
            }
            catch (Exception ex)
            {
                string msg = ex.ToString();
            }
        }
    }
}