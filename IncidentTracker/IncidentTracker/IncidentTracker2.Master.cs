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
    public partial class IncidentTracker : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["UserInfo"] == null)
                {

                }
                else
                {
                    Object SaveUSERInfo = (Object)Session["UserInfo"];
                    lblWelcome.Text = "Welcome " + Convert.ToString(((UserInfo.structUSERInfo)(SaveUSERInfo)).UserName) + " to " + Convert.ToString(((UserInfo.structUSERInfo)(SaveUSERInfo)).BranchName) + " Branch";
                }
            }
            catch (Exception ex)
            {

            }
        }
        private void check_logout()
        {
            Object SaveUSERInfo = (Object)Session["UserInfo"];
            SqlConnection sqlCon = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);
            try
            {
                if (sqlCon.State == ConnectionState.Closed)
                {
                    sqlCon.Open();

                    SqlCommand sqlCom = new SqlCommand();
                    sqlCom.Connection = sqlCon;
                    sqlCom.CommandType = CommandType.StoredProcedure;
                    sqlCom.CommandText = "IT_SaveLogoutData_SP";
                    sqlCom.CommandTimeout = 0;

                    sqlCom.Parameters.AddWithValue("@emp_id", Convert.ToString(((UserInfo.structUSERInfo)(SaveUSERInfo)).UserId));
                    //sqlCom.Parameters.AddWithValue("@Token", HttpContext.Current.Session["Token"].ToString());
                    sqlCom.Parameters.AddWithValue("@LOG_DET_ID", HttpContext.Current.Session.SessionID.ToString());
                    SqlDataAdapter sqlDA = new SqlDataAdapter();
                    sqlDA.SelectCommand = sqlCom;

                    int SqlRow = 0;
                    SqlRow = sqlCom.ExecuteNonQuery();

                    if (SqlRow > 0)
                    {

                    }
                    else
                    {
                    }
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
        protected void lnkChangePassword_Click(object sender, EventArgs e)
        {
            Response.Redirect("IT_ChangePassword.aspx", true);
        }

        protected void lnkLogOut_Click(object sender, EventArgs e)
        {
            if (Session["UserInfo"] != null)
            {
                check_logout();
                Session.Clear();
                Response.Redirect("IT_LoginPage.aspx", false);

            }

        }
    }
}