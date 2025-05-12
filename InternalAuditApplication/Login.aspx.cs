using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASPSnippets.Captcha;

namespace InternalAuditApplication
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                GenerateCaptcha();
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
                sqlCom.CommandText = "InternalAudit_UserLogin";

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


                int failedAttempts = Convert.ToInt32(dt.Rows[0]["FailedLoginAttempts"]); //add on 24/01/2025
                string msg = Convert.ToString(dt.Rows[0]["MSG"]); //add on 24/01/2025

                if (dt.Rows.Count > 0 && failedAttempts <= 3 && msg == "TRUE") //add on 24/01/2025
                {
                    Session["ID"] = Convert.ToString(dt.Rows[0]["ID"]);
                    Session["UserName"] = Convert.ToString(dt.Rows[0]["UserName"]);
                    Session["UserID"] = Convert.ToString(dt.Rows[0]["UserID"]);
                    Session["RoleID"] = Convert.ToInt32(dt.Rows[0]["RoleID"]);
                    Session["CPC"] = Convert.ToString(dt.Rows[0]["CPC"]);
                    Session["Vertical"] = Convert.ToString(dt.Rows[0]["Vertical"]);
                    Session["IsFirstTime"] = Convert.ToString(dt.Rows[0]["IsFirstTime"]);


                    //Session["Email"] = Convert.ToString(dt.Rows[0]["Email"]);
                    //Session["LoanType"] = Convert.ToString(ddlloantype.SelectedItem.Text);
                    //Session["Branch_Hub_Id"] = Convert.ToString(dt.Rows[0]["Branch_Hub_Id"]);
                    //Session["Location_Id"] = Convert.ToString(dt.Rows[0]["Location_Id"]);



                    UserInfo.structUSERInfo SaveUSERInfo = new UserInfo.structUSERInfo();

                    SaveUSERInfo.ID = Convert.ToString(dt.Rows[0]["ID"]);
                    SaveUSERInfo.UserName = Convert.ToString(dt.Rows[0]["UserName"]);
                    SaveUSERInfo.UserID = Convert.ToString(dt.Rows[0]["UserID"]);
                    SaveUSERInfo.RoleID = Convert.ToInt32(dt.Rows[0]["RoleID"]);
                    SaveUSERInfo.CPC = Convert.ToString(dt.Rows[0]["CPC"]);
                    SaveUSERInfo.Vertical = Convert.ToString(dt.Rows[0]["Vertical"]);

                    // SaveUSERInfo.Email = Convert.ToString(dt.Rows[0]["Email"]);
                    //  SaveUSERInfo.LoanType = Convert.ToString(ddlloantype.SelectedItem.Text);
                    // SaveUSERInfo.Branch_Hub_Id = Convert.ToString(dt.Rows[0]["Branch_Hub_Id"]);
                    // SaveUSERInfo.Location_Id = Convert.ToString(dt.Rows[0]["Location_Id"]);

                    Session["MFA_applicable"] = Convert.ToString(dt.Rows[0]["MFA_applicable"]);
                    Session["EmailId"] = Convert.ToString(dt.Rows[0]["Email"]);

                    SaveUSERInfo.AuthorizeUSERID = "";
                    SaveUSERInfo.ClientName = "Yes Bank";
                    Session["USERInfo"] = SaveUSERInfo;

                }
                else
                {
                    //lblError.Visible = true;  //comment on 24/01/2025
                    //lblError.Text = "Incorrect UserId or Password,[Please Enter Correct UserId and Password]!";

                    returnVal = 0;

                    failedAttempts = Convert.ToInt32(dt.Rows[0]["FailedLoginAttempts"]);  //add on 24/01/2025
                    // Show the remaining login attempts
                    int remainingAttempts = 3 - failedAttempts;
                    lblError.Visible = true;
                    lblError.ForeColor = System.Drawing.Color.Red;
                    lblError.Text = $"Incorrect username or password. You have {remainingAttempts} remaining attempts.";

                    if (failedAttempts >= 3) //add on 24/01/2025
                    {
                        lblError.Visible = true;
                        lblError.ForeColor = System.Drawing.Color.Red;
                        lblError.Text = $"Your account has been locked, Please contact to Internal Audit SPOC.";
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
                        Response.Redirect("ChangePassword.aspx", false);
                        return;
                    }
                }


                if (isValid == 0)
                {
                    Session.Clear();
                    return;
                }

                int MFA_applicable = Convert.ToInt32(Session["MFA_applicable"]);

                MFA_applicable = 0;

                if (MFA_applicable == 1)
                {

                    if (IsUserGrid(txtUserName.Text.Trim()))
                    {
                        Response.Redirect("grid_authentication.aspx", false);
                    }
                    else
                    {
                        int otp = GenerateRandomNo();
                        bool result = Email(otp, Convert.ToString(Session["UserID"]), Convert.ToString(Session["UserName"]), Convert.ToString(Session["EmailId"]));

                        if (result == true)
                        {
                            Update_OTP(otp, Convert.ToString(Session["UserId"]));
                            Response.Redirect("otp_authentication.aspx", false);
                        }
                        else
                        {
                            lblError.Visible = true;
                            lblError.Text = "Invalid Email ID";
                        }
                    }

                }
                else
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
            }
            else
            {
                lblError.Visible = true;
                lblError.Text = "Invalid Captcha";
                GenerateCaptcha();
            }
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
        private Boolean IsUserGrid(string Userid)
        {
            try
            {
                Object SaveUSERInfo = (Object)Session["UserInfo"];

                SqlConnection sqlCon = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"].ToString());

                sqlCon.Open();
                SqlCommand sqlCom = new SqlCommand();
                sqlCom.Connection = sqlCon;
                sqlCom.CommandType = CommandType.StoredProcedure;
                sqlCom.CommandText = "Check_IsUserGrid";

                SqlParameter UserId = new SqlParameter();
                UserId.SqlDbType = SqlDbType.VarChar;
                UserId.Value = txtUserName.Text.Trim();
                UserId.ParameterName = "@UserId";
                sqlCom.Parameters.Add(UserId);

                SqlParameter ReturnValue = new SqlParameter();
                ReturnValue.SqlDbType = SqlDbType.VarChar;
                ReturnValue.Value = null;
                ReturnValue.ParameterName = "@ReturnValue";
                sqlCom.Parameters.Add(ReturnValue);

                int Return = 0;

                Return = Convert.ToInt32(sqlCom.ExecuteScalar());

                sqlCon.Close();

                if (Return == 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception exp)
            {
                lblError.Text = exp.Message;
                return false;
            }
        }
        public int GenerateRandomNo()
        {
            int _min = 1000;
            int _max = 9999;
            Random _rdm = new Random();
            return _rdm.Next(_min, _max);
        }
        private static bool Email(int OTP, string UserId, string UserName, string EmailId)
        {
            string Emailid = EmailId;
            string strTime = System.DateTime.Now.TimeOfDay.ToString().Remove(5);
            string strhh = strTime.Remove(2);
            string strmm = strTime.Remove(0, 3);

            string Current = System.DateTime.Now.Date.ToString().Remove(10);

            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient smtp = new SmtpClient("mail.pamac.com", 587);
                smtp.Credentials = new System.Net.NetworkCredential("software.support@pamac.com", "_ug7rogzH");
                mail.From = new MailAddress("software.support@pamac.com", "Internal Audit");
                mail.To.Add(Emailid);
                mail.Subject = "Login OTP for User Id " + UserId;
                string strBody =
                           "<html><body><font color=\"Navy\" style=\"font-style=Italic;font-weight=bold\">" +
                           "<P>                                                                                               </P>" +
                           "<P>Dear " + UserName + " ,</P>" +
                           "<P>This is your one-time login OTP " + OTP + " for User ID " + UserId + ".</P>" +
                           "<P>*Kindly log in within 2 minutes, after which it will expire.*</P>" +
                           "<P>*This is an automatically generated email, please do not reply*</P>" +
                           "<P>        </P>" +
                           "<P>Regards,</P>" +
                           "<P>Internal Audit Team</P> " +
                           "</font></html></body>";

                mail.Body = strBody;
                mail.IsBodyHtml = true;
                smtp.Port = 587;
                smtp.Credentials = new System.Net.NetworkCredential("software.support@pamac.com", "_ug7rogzH");
                smtp.EnableSsl = false;
                smtp.Send(mail);

                return true;
            }
            catch (Exception ex)
            {
                string msg = "Email Failed." + ex.Message;

                return false;
            }
        }
        private void Update_OTP(int OTP, string UserID)
        {

            SqlConnection sqlCon = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"].ToString());
            try
            {
                if (sqlCon.State == ConnectionState.Closed)
                {

                    SqlCommand sqlCom = new SqlCommand();
                    sqlCom.Connection = sqlCon;
                    sqlCom.CommandType = CommandType.StoredProcedure;
                    sqlCom.CommandText = "Update_OTP_SP";
                    sqlCom.CommandTimeout = 0;
                    sqlCom.Parameters.AddWithValue("@OTP", OTP);
                    sqlCom.Parameters.AddWithValue("@UserId", UserID);

                    sqlCon.Open();
                    int Result = sqlCom.ExecuteNonQuery();
                    sqlCon.Close();
                }
            }
            catch (Exception ex)
            {

            }
        }
    }

}