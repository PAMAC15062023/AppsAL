using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IncidentTracker.Pages
{
    public partial class IT_MenuPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                maker.Visible = false;
                approver.Visible = false;

                Object SaveUSERInfo = (Object)Session["UserInfo"];

                if (Session["UserInfo"] == null)
                {
                    Response.Redirect("../IT_InvalidRequest.aspx", true);
                }
                else if (((UserInfo.structUSERInfo)(SaveUSERInfo)).AuthorizePassword == "0")
                {
                    Response.Redirect("../IT_ChangePassword.aspx?Err=Please Change your password!", true);
                }
                else
                {

                    if (!IsPostBack)
                    {
                        Load_UserStatus();

                        lblWelcome.Text = "Welcome " + Convert.ToString(((UserInfo.structUSERInfo)(SaveUSERInfo)).UserName) + " to " + Convert.ToString(((UserInfo.structUSERInfo)(SaveUSERInfo)).BranchName) + " Branch";


                        int RoleId = Convert.ToInt32(((UserInfo.structUSERInfo)(SaveUSERInfo)).RoleId);

                        if (RoleId == 1)
                        {
                            maker.Visible = true;
                            approver.Visible = false;
                        }
                        else if (RoleId == 2)
                        {
                            approver.Visible = true;
                            maker.Visible = false;
                        }
                        else
                        {
                            approver.Visible = false;
                            maker.Visible = false;
                        }
                    }
                }
            }
            catch
            {

            }
        }
        private void Load_UserStatus()
        {
            try
            {
                if (Session["UserInfo"] == null)
                {
                    Response.Redirect("../IT_InvalidRequest.aspx", false);
                }
                else
                {
                    Object SaveUSERInfo = (Object)Session["UserInfo"];
                    lblUserName.Text = Convert.ToString(((UserInfo.structUSERInfo)(SaveUSERInfo)).UserId);
                    lblBranch.Text = Convert.ToString(((UserInfo.structUSERInfo)(SaveUSERInfo)).BranchName);
                    lblRole.Text = Convert.ToString(((UserInfo.structUSERInfo)(SaveUSERInfo)).RoleName);
                    lblClient.Text = Convert.ToString(((UserInfo.structUSERInfo)(SaveUSERInfo)).ClientName);

                    int intMonth = Convert.ToInt32(DateTime.Now.Month);

                    lblMonth.Text = Get_MonthName(intMonth);
                    lblDate.Text = DateTime.Now.Day.ToString();
                }
            }
            catch (Exception ex)
            {

            }
        }
        private string Get_MonthName(int intMonth)
        {
            string Month = "";
            if (intMonth == 1)
            {
                Month = "Jan";
            }
            else if (intMonth == 2)
            {
                Month = "Feb";
            }
            else if (intMonth == 3)
            {
                Month = "Mar";
            }
            else if (intMonth == 4)
            {
                Month = "Apr";
            }
            else if (intMonth == 5)
            {
                Month = "May";
            }
            else if (intMonth == 6)
            {
                Month = "Jun";
            }
            else if (intMonth == 7)
            {
                Month = "Jul";
            }
            else if (intMonth == 8)
            {
                Month = "Aug";
            }
            else if (intMonth == 9)
            {
                Month = "Sep";
            }
            else if (intMonth == 10)
            {
                Month = "Oct";
            }
            else if (intMonth == 11)
            {
                Month = "Nov";
            }
            else if (intMonth == 12)
            {
                Month = "Dec";
            }


            return Month;
        }

        protected void lnkChangePassword_Click(object sender, EventArgs e)
        {
            Response.Redirect("../IT_ChangePassword.aspx", true);
        }
        protected void lnkLogOut_Click(object sender, EventArgs e)
        {
            if (Session["UserInfo"] != null)
            {
                check_logout();
                Session.Clear();
                Response.Redirect("../IT_LoginPage.aspx", false);

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
    }
}