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

namespace AUMVD
{
    public partial class AUMVD_Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

            }
        }

        protected int Check_Auth_User()
        {
            int returnVal = 1;//1 valid 0 invalid
            try
            {
                SqlConnection sqlCon = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());

                sqlCon.Open();
                SqlCommand sqlCom = new SqlCommand();
                sqlCom.Connection = sqlCon;
                sqlCom.CommandType = CommandType.StoredProcedure;
                sqlCom.CommandText = "ActiveUserMIS_UserLogin";

                SqlParameter LoginName = new SqlParameter();
                LoginName.SqlDbType = SqlDbType.VarChar;
                LoginName.Value = txtUserName.Text.Trim();
                LoginName.ParameterName = "@UserID";
                sqlCom.Parameters.Add(LoginName);

                SqlParameter Password = new SqlParameter();
                Password.SqlDbType = SqlDbType.VarChar;
                Password.Value = CEncDec.Encrypt(txtPassword.Text.Trim(), txtPassword.Text.Trim());
                Password.ParameterName = "@Password";
                sqlCom.Parameters.Add(Password);

                SqlDataAdapter sqlDA = new SqlDataAdapter();
                sqlDA.SelectCommand = sqlCom;

                DataTable dt = new DataTable();
                sqlDA.Fill(dt);
                sqlCon.Close();



                if (dt.Rows.Count > 0)
                {
                    //Session["ID"] = Convert.ToString(dt.Rows[0]["ID"]);
                    Session["UserName"] = Convert.ToString(dt.Rows[0]["UserName"]);
                    Session["UserID"] = Convert.ToString(dt.Rows[0]["UserID"]);
                    //Session["RoleID"] = Convert.ToInt32(dt.Rows[0]["RoleID"]);
                    //Session["BranchName"] = Convert.ToString(dt.Rows[0]["CPC"]);
                    //Session["Vertical"] = Convert.ToString(dt.Rows[0]["Vertical"]);
                    //Session["IsFirstTime"] = Convert.ToString(dt.Rows[0]["IsFirstTime"]);
                    //Session["Branch_Name"] = Convert.ToString(dt.Rows[0]["Branch_Name"]);

                    UserInfo.structUSERInfo SaveUSERInfo = new UserInfo.structUSERInfo();

                    //SaveUSERInfo.ID = Convert.ToString(dt.Rows[0]["ID"]);
                    SaveUSERInfo.UserName = Convert.ToString(dt.Rows[0]["UserName"]);
                    SaveUSERInfo.UserID = Convert.ToString(dt.Rows[0]["UserID"]);
                    //SaveUSERInfo.RoleID = Convert.ToInt32(dt.Rows[0]["RoleID"]);
                    //SaveUSERInfo.BranchName = Convert.ToString(dt.Rows[0]["CPC"]);
                    ////SaveUSERInfo.Vertical = Convert.ToString(dt.Rows[0]["Vertical"]);
                    //SaveUSERInfo.Branch_Name = Convert.ToString(dt.Rows[0]["Branch_Name"]);

                    SaveUSERInfo.AuthorizeUSERID = "";
                    SaveUSERInfo.ClientName = "Yes Bank";
                    Session["USERInfo"] = SaveUSERInfo;

                }
                else
                {
                    lblError.Visible = true;
                    lblError.Text = "Incorrect UserId or Password,[Please Enter Correct UserId and Password]!";
                    returnVal = 0;
                }
            }
            catch (Exception ex)
            {
                returnVal = 0;
                lblError.Visible = true;
                lblError.Text = ex.Message;
            }

            return returnVal;
        }
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            if (Check_Auth_User() == 1)
            {
                Response.Redirect("AUMVD_Reports.aspx", false);
                return;
            }
            if (Check_Auth_User() == 0)
            {
                Session.Clear();
                return;

            }
        }
    }
}