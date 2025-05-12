using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASPSnippets.Captcha;

namespace LNTFinance
{
    public partial class LoginPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    Get_ClientList();
                    GenerateCaptcha();
                }

            }
            catch (Exception ex)
            {
                lblError.Visible = true;
                lblError.Text = ex.Message;
            }
        }

        private void Get_ClientList()
        {
            try
            {

                SqlConnection sqlCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);

                sqlCon.Open();
                SqlCommand sqlCom = new SqlCommand();
                sqlCom.Connection = sqlCon;
                sqlCom.CommandType = CommandType.StoredProcedure;
                sqlCom.CommandText = "Get_ClientList";
                SqlDataAdapter sqlDA = new SqlDataAdapter();
                sqlDA.SelectCommand = sqlCom;
                DataTable dt = new DataTable();
                sqlDA.Fill(dt);
                sqlCon.Close();

                ddlClientList.DataTextField = "ClientName";
                ddlClientList.DataValueField = "ClientID";
                ddlClientList.DataSource = dt;
                ddlClientList.DataBind();

                ddlClientList.Items.Insert(0, "--Select--");
                ddlClientList.SelectedIndex = 0;

            }
            catch (Exception ex)
            {
                lblError.Visible = true;
                lblError.Text = ex.Message;
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
                sqlCom.CommandText = "LNT_UserLogin";

                SqlParameter LoginName = new SqlParameter();
                LoginName.SqlDbType = SqlDbType.VarChar;
                LoginName.Value = txtUserName.Text.Trim();
                LoginName.ParameterName = "@LoginName";
                sqlCom.Parameters.Add(LoginName);

                SqlParameter Password = new SqlParameter();
                Password.SqlDbType = SqlDbType.VarChar;
                Password.Value = CEncDec.Encrypt(txtPassword.Text.Trim(), txtPassword.Text.Trim());
                Password.ParameterName = "@Password";
                sqlCom.Parameters.Add(Password);

                //SqlParameter LoanType = new SqlParameter();
                //LoanType.SqlDbType = SqlDbType.Int;
                //LoanType.Value = ddlloantype.SelectedValue;
                //LoanType.ParameterName = "@LoanType";
                //sqlCom.Parameters.Add(LoanType);

                SqlParameter ClientID = new SqlParameter();
                ClientID.SqlDbType = SqlDbType.VarChar;
                ClientID.Value = ddlClientList.SelectedValue;
                ClientID.ParameterName = "@ClientID";
                sqlCom.Parameters.Add(ClientID);

                SqlDataAdapter sqlDA = new SqlDataAdapter();
                sqlDA.SelectCommand = sqlCom;

                DataTable dt = new DataTable();
                sqlDA.Fill(dt);
                sqlCon.Close();

                int failedAttempts = Convert.ToInt32(dt.Rows[0]["FailedLoginAttempts"]);
                string msg = Convert.ToString(dt.Rows[0]["MSG"]);
                if (dt.Rows.Count > 0 && failedAttempts <= 3 && msg == "TRUE")
                {
                    Session["ClientID"] = Convert.ToString(dt.Rows[0]["ClientID"]); /*Added on 19/07/2022*/
                    //Session["UserId"] = Convert.ToString(dt.Rows[0]["UserId"]);
                    Session["UserName"] = Convert.ToString(dt.Rows[0]["UserName"]);
                    Session["LoginName"] = Convert.ToString(dt.Rows[0]["LoginName"]);
                    Session["RoleID"] = Convert.ToInt32(dt.Rows[0]["RoleID"]);
                    Session["ClientName"] = Convert.ToString(dt.Rows[0]["ClientName"]);/*Added on 19/07/2022*/
                    UserInfo.structUSERInfo SaveUSERInfo = new UserInfo.structUSERInfo();


                    SaveUSERInfo.ClientID = Convert.ToString(dt.Rows[0]["ClientID"]);/*Added on 19/07/2022*/
                    SaveUSERInfo.ClientName = Convert.ToString(dt.Rows[0]["ClientName"]);/*Added on 19/07/2022*/
                    //SaveUSERInfo.UserId = Convert.ToString(dt.Rows[0]["UserId"]); Changed on 19/07/2022
                    SaveUSERInfo.UserName = Convert.ToString(dt.Rows[0]["UserName"]);
                    SaveUSERInfo.LoginName = Convert.ToString(dt.Rows[0]["LoginName"]);
                    SaveUSERInfo.RoleId = Convert.ToInt32(dt.Rows[0]["RoleId"]);
                    SaveUSERInfo.Branch_Hub_Id = "Mumbai";
                    SaveUSERInfo.AuthorizeUSERID = "";
                    //SaveUSERInfo.ClientName = "LNT Finance"; Changed on 19/07/2022
                    Session["USERInfo"] = SaveUSERInfo;

                    Session["MFA_applicable"] = Convert.ToInt32(dt.Rows[0]["MFA_applicable"]);

                    CommonMaster commonMaster = new CommonMaster();
                    commonMaster.UpdateLastLogin(Convert.ToString(((UserInfo.structUSERInfo)(SaveUSERInfo)).LoginName));


                    lblError.Visible = false;
                    lblError.Text = "";
                    returnVal = 1;
                }
                else
                {
                    //lblError.Visible = true;
                    //lblError.Text = "Incorrect UserId or Password,[Please Enter Correct UserId and Password]!";
                    
                    returnVal = 0;

                    failedAttempts = Convert.ToInt32(dt.Rows[0]["FailedLoginAttempts"]);
                    // Show the remaining login attempts
                    int remainingAttempts = 3 - failedAttempts;
                    lblError.Visible = true;
                    lblError.ForeColor = System.Drawing.Color.Red;
                    lblError.Text = $"Incorrect username or password. You have {remainingAttempts} remaining attempts.";

                    if (failedAttempts >= 3)
                    {
                        lblError.Visible = true;
                        lblError.ForeColor = System.Drawing.Color.Red;
                        lblError.Text = $"Your account has been locked, Please contact to LNT SPOC.";
                    }
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
        private int Check_Login()
        {
            int returnVal = 1;//1 valid 0 invalid
            SqlConnection sqlCon = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            try
            {
                if (sqlCon.State == ConnectionState.Closed)
                {

                    SqlCommand sqlCom = new SqlCommand();
                    sqlCom.Connection = sqlCon;
                    sqlCom.CommandType = CommandType.StoredProcedure;
                    sqlCom.CommandText = "LNT_AssignAttendance_SP";
                    sqlCom.CommandTimeout = 0;

                    sqlCom.Parameters.AddWithValue("@UserID", txtUserName.Text.Trim());

                    sqlCon.Open();
                    int Result = sqlCom.ExecuteNonQuery();
                    sqlCon.Close(); // Added on 30/09/2022

                    if (Result > 0)
                    {

                    }
                    else
                    {
                        returnVal = 0;
                        Response.Redirect("LNT_Error20.aspx", false);
                    }
                }
            }
            catch (Exception ex)
            {

            }
            return returnVal;
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {

            bool CaptchaIsValid = Captcha.IsValid(txtCaptchaAnswer.Text.Trim());

            if (CaptchaIsValid)
            {
                int isValid = Check_Auth_User();

                if (isValid == 1)
                {
                    if (Convert.ToBoolean(Session["IsFirstTime"]) == true)
                    {
                        Response.Redirect("LNT_ChnagePassWord.aspx", false);
                        return;
                    }
                }


                if (isValid == 0)
                {
                    Session.Clear();
                    return;
                }

                int RoleId = Convert.ToInt32(Session["RoleId"]);


                int MFA_applicable = Convert.ToInt32(Session["MFA_applicable"]);

                if (MFA_applicable == 1)
                {
                    Response.Redirect("Pages/grid_authentication.aspx", false);
                }
                else
                {
                    Response.Redirect("Pages/MenuPage.aspx", false);
                }


                

                //if (Check_Login() == 0)
                //{
                //    Response.Redirect("LNT_Error20.aspx?Message=" + "User Already Logined !!!!!!!!!!!!!!", false);

                //    return;
                //}
                //else
                //{
                //    Response.Redirect("Pages/MenuPage.aspx", false);
                //}
            }
            else
            {
                lblError.Visible = true;
                lblError.Text = "Invalid Captcha";
                GenerateCaptcha();
            }
        }

        protected void lkbtnforgotPassword_Click(object sender, EventArgs e)
        {
            lblError.Visible = true;
            lblError.Text = "Please contact to your admin";
        }
        private Captcha Captcha
        {
            get
            {
                return (Captcha)ViewState["Captcha"];
            }
            set
            {
                ViewState["Captcha"] = value;
            }
        }
        private void GenerateCaptcha()
        {
            // Regenerate the CAPTCHA image by creating a new instance
            this.Captcha = new Captcha(150, 40, 20f, "#FFFFFF", "#61028D", Mode.AlphaNumeric);
            imgCaptcha.ImageUrl = this.Captcha.ImageData;  // Set the CAPTCHA image URL
        }
    }
}