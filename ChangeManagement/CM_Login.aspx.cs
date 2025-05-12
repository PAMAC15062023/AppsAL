using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Net.Mail;

namespace ChangeManagement
{
    public partial class CM_Login : System.Web.UI.Page
    {
        public string Success = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            int isValidUser = Check_Auth_user();
            if (isValidUser == 1)
            {
                int isMFA_Applicable = Convert.ToInt32(Session["MFA_applicable"]);

                if (isMFA_Applicable == 1)
                {
                    if (IsUserGrid(txtUserName.Text.Trim()))
                    {

                        Response.Redirect("grid_authentication.aspx", false);
                    }
                    else
                    {
                        int otp = GenerateRandomNo();
                        bool result = Email(otp, Convert.ToString(Session["UserId"]), Convert.ToString(Session["UserName"]), Convert.ToString(Session["EmailId"]));

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
                    int roleid = Convert.ToInt32(Session["Roleid"].ToString());
                    Response.Redirect("CM_MenuPage.aspx", false);
                }
            }
            else if (isValidUser == 2)
            {
                Response.Redirect("CM_ChangePassword.aspx?Err=" + lblError.Text.Trim(), false);
            }
        }

        protected void lkbtnforgotPassword_Click(object sender, EventArgs e)
        {
            //lblError.Visible = true;
            //lblError.Text = "";
            //lblError.Text = "Please Contact Admin For Password Reset ....!";
            //return;

            if (txtUserName.Text.ToString().Trim() != "")
            {
                string NewPassword = "";
                Success = checkUserIDAndPassword();
                if (Success == "OK")
                {
                    try
                    {
                        //lblChangePassword.Text = "New Password Generated: " + strPassword;
                        NewPassword = Generate_AutoPassword();

                        SqlConnection sqlCon = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());

                        SqlCommand cmd = new SqlCommand("CM_ForgetPassword_SP", sqlCon);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@UserId", txtUserName.Text.Trim());
                        cmd.Parameters.AddWithValue("@Password", CEncDec.Encrypt(NewPassword, NewPassword));
                        SqlDataAdapter adp = new SqlDataAdapter(cmd);
                        DataSet ds = new DataSet();
                        adp.Fill(ds);


                        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                        {
                            if (Convert.ToBoolean(ds.Tables[0].Rows[0]["ISSUCCESS"]) == true)
                            {
                                lblError.Visible = true;
                                lblError.ForeColor = System.Drawing.Color.Green;
                                lblError.Text = ds.Tables[0].Rows[0]["MESSAGE"].ToString();
                                lblError.ForeColor = System.Drawing.Color.Red;

                                string UserName = ds.Tables[0].Rows[0]["UserName"].ToString();
                                string EmailId = ds.Tables[0].Rows[0]["EmailId"].ToString();

                                SendMail(NewPassword, EmailId, UserName);

                                return;
                            }
                            else
                            {
                                lblError.Visible = true;
                                lblError.Text = "";
                                lblError.Text = ds.Tables[0].Rows[0]["MESSAGE"].ToString();
                                return;
                            }
                        }
                        else
                        {
                            lblError.Visible = true;
                            lblError.Text = "";
                            lblError.Text = "Please Contact Admin For Password Reset ....!";
                            return;
                        }
                    }
                    catch (Exception ex)
                    {
                        string st = ex.Message;

                    }

                    //lblError.Visible = true;
                    //lblError.Text = "";
                    //lblError.Text = "Please Contact Admin For Password Reset ....!";
                    //return;
                }
                else
                {
                    if (Success == "NOT OK")
                    {
                        lblError.Visible = true;
                        lblError.Text = "Please enter valid UseID....!";
                        return;
                    }
                    else
                    {
                        lblError.Visible = true;
                        lblError.Text = Success;
                        return;
                    }
                }
            }
            else
            {
                lblError.Visible = true;
                lblError.Text = "";
                lblError.Text = "Please Enter  UserID..!";
                return;
            }
        }

        private Boolean Check_IsSystem() //add on 23/04/2024
        {
            try
            {
                Object SaveUSERInfo = (Object)Session["UserInfo"];

                SqlConnection sqlCon = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);

                sqlCon.Open();
                SqlCommand sqlCom = new SqlCommand();
                sqlCom.Connection = sqlCon;
                sqlCom.CommandType = CommandType.StoredProcedure;
                sqlCom.CommandText = "Get_UserPasswordStatus";

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
                    lblError.Text = "Please Change your Password ,Your Password has been Expired!";
                    return false;

                }
                else if (Return == 2)
                {
                    lblError.Text = "Please Change your Password , your password is set by admin!";
                    return false;
                }
                else if (Return == 3)
                {
                    lblError.Text = "Please Change your Password , your reached the days limit!";
                    return false;
                }
                else
                {
                    if (Check_Password(txtPassword.Text.Trim()))
                    {

                        return true;
                    }
                    else
                    {
                        lblError.Text = "Your password is not complying with Standard Password Policy!";
                        return false;
                    }

                }


            }

            catch (Exception exp)
            {

                lblError.Text = exp.Message;
                return false;
            }
        }

        private Boolean Check_Password(string pstrPassword) //add on 23/04/2024
        {
            try
            {
                lblError.Text = "";
                Boolean IsNumeric = false;
                Boolean IsSpecialChar = false;
                Boolean IsChar = false;

                string strPass = pstrPassword;
                if (strPass.Length < 8)
                {
                    lblError.Text = "Password Length should be minimum equals to 8 char";
                    return false;

                }
                int i;
                int Out;

                string[] SpecialChar = new string[6];
                SpecialChar[0] = "@";
                SpecialChar[1] = "#";
                SpecialChar[2] = "$";
                SpecialChar[3] = "%";
                SpecialChar[4] = "_";
                SpecialChar[5] = "^";
                SpecialChar[5] = "*";

                for (Out = 0; Out <= SpecialChar.Length - 1; Out++)
                {
                    for (i = 0; i <= strPass.Length - 1; i++)
                    {
                        if (Convert.ToString(strPass[i]) == SpecialChar[Out].ToString())
                        {
                            IsSpecialChar = true;
                        }
                    }
                }

                if (IsSpecialChar == false)
                {

                    lblError.Text = "your password should contains any of the special char!";
                    return false;

                }



                string[] AlphaChar = new string[26];
                AlphaChar[0] = "Z";
                AlphaChar[1] = "A";
                AlphaChar[2] = "B";
                AlphaChar[3] = "C";
                AlphaChar[4] = "D";
                AlphaChar[5] = "E";
                AlphaChar[6] = "F";
                AlphaChar[7] = "G";
                AlphaChar[8] = "H";
                AlphaChar[9] = "I";
                AlphaChar[10] = "J";
                AlphaChar[11] = "K";
                AlphaChar[12] = "L";
                AlphaChar[13] = "M";
                AlphaChar[14] = "N";
                AlphaChar[15] = "O";
                AlphaChar[16] = "P";
                AlphaChar[17] = "Q";
                AlphaChar[18] = "R";
                AlphaChar[19] = "S";
                AlphaChar[20] = "T";
                AlphaChar[21] = "U";
                AlphaChar[22] = "V";
                AlphaChar[23] = "W";
                AlphaChar[24] = "X";
                AlphaChar[25] = "Y";


                for (Out = 0; Out <= AlphaChar.Length - 1; Out++)
                {
                    for (i = 0; i <= strPass.Length - 1; i++)
                    {
                        if (Convert.ToString(strPass[i].ToString().ToUpper()) == AlphaChar[Out].ToString())
                        {
                            IsChar = true;
                        }

                    }
                }
                if (IsChar == false)
                {
                    lblError.Text = "your password should contains any of the Alphabets!";
                    return false;
                }


                int[] Numeric = new int[10];
                Numeric[0] = 0;
                Numeric[1] = 1;
                Numeric[2] = 2;
                Numeric[3] = 3;
                Numeric[4] = 4;
                Numeric[5] = 5;
                Numeric[6] = 6;
                Numeric[7] = 7;
                Numeric[8] = 8;
                Numeric[9] = 9;

                for (Out = 0; Out <= Numeric.Length - 1; Out++)
                {
                    for (i = 0; i <= strPass.Length - 1; i++)
                    {
                        if (strPass[i].ToString() == Numeric[Out].ToString())
                        {
                            IsNumeric = true;
                        }
                    }
                }
                if (IsNumeric == false)
                {
                    lblError.Text = "your password should contains any of the Numeric!";
                    return false;
                }

                return true;
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
                return false;
            }
        }

        public void SendMail(string Password, string EmailId, string UserName)
        {
            try
            {
                System.Net.Mail.MailMessage mail = new System.Net.Mail.MailMessage();
                mail.Subject = "Change Management Password";
                mail.From = new MailAddress("software.support@pamac.com");
                mail.To.Add(EmailId);
                mail.Body = "This is YOUR PASSWORD : " + Password + " for " + UserName;


                SmtpClient smtp = new SmtpClient("mail.pamac.com", 587);
                smtp.Credentials = new System.Net.NetworkCredential("software.support@pamac.com", "_ug7rogzH");
                smtp.EnableSsl = false;/// Main line :SSL should be false
                smtp.Send(mail);
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
        }

        public string checkUserIDAndPassword()
        {
            try
            {
                SqlConnection sqlCon = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
                Object SaveUSERInfo = (Object)Session["UserInfo"];
                SqlCommand sqlCom = new SqlCommand();
                sqlCom.Connection = sqlCon;
                sqlCom.CommandType = CommandType.StoredProcedure;
                sqlCom.CommandText = "CM_getUserIdAndEmail";
                sqlCom.CommandTimeout = 0;

                if (txtUserName.Text.ToString().Trim() != "")
                {
                    SqlParameter LoginID = new SqlParameter();
                    LoginID.SqlDbType = SqlDbType.VarChar;
                    LoginID.Value = txtUserName.Text.ToString().Trim();
                    LoginID.ParameterName = "@UserID";
                    sqlCom.Parameters.Add(LoginID);

                }
                sqlCon.Open();

                SqlDataAdapter sqlDA = new SqlDataAdapter();
                sqlDA.SelectCommand = sqlCom;
                DataTable dt = new DataTable();
                sqlDA.Fill(dt);
                sqlCon.Close();
                if (dt.Rows.Count > 0)
                {
                    Success = dt.Rows[0]["Success"].ToString();
                }
                else
                {
                    Success = "NOT OK";
                }
            }
            catch (Exception ex)
            {
                lblError.Visible = true;
                lblError.Text = ex.ToString();
            }
            return Success;
        }

        public string Generate_AutoPassword()
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
        private int Check_Auth_user()
        {
            int isValidUser = 0;

            if (txtCaptcha.Text.Trim().ToUpper().Equals(Session["Captcha"].ToString().ToUpper())) //add on /06/2024up
            {
                SqlConnection sqlCon = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());

                sqlCon.Open();
                SqlCommand sqlCom = new SqlCommand();
                sqlCom.Connection = sqlCon;
                sqlCom.CommandType = CommandType.StoredProcedure;
                sqlCom.CommandText = "SP_getRoleid";

                SqlParameter LoginName = new SqlParameter();
                LoginName.SqlDbType = SqlDbType.VarChar;
                LoginName.Value = txtUserName.Text.Trim();
                LoginName.ParameterName = "@userid";
                sqlCom.Parameters.Add(LoginName);
                SqlDataAdapter sqlDA = new SqlDataAdapter();
                sqlDA.SelectCommand = sqlCom;

                SqlParameter Password = new SqlParameter();
                Password.SqlDbType = SqlDbType.VarChar;
                Password.Value = CEncDec.Encrypt(txtPassword.Text.Trim(), txtPassword.Text.Trim());
                Password.ParameterName = "@password";
                sqlCom.Parameters.Add(Password);

                DataTable dt = new DataTable();
                sqlDA.Fill(dt);
                sqlCon.Close();


                int failedAttempts = Convert.ToInt32(dt.Rows[0]["FailedLoginAttempts"]);
                string MSG = Convert.ToString(dt.Rows[0]["MSG"]);

                if (dt.Rows.Count > 0 && failedAttempts <= 3 && MSG == "TRUE")
                {
                    UserInfo.structUSERInfo SaveUSERInfo = new UserInfo.structUSERInfo();
                    Session["Rolename"] = dt.Rows[0]["RoleName"];
                    Session["Roleid"] = Convert.ToInt32(dt.Rows[0]["Roleid"]);
                    Session["fullName"] = Convert.ToString(dt.Rows[0]["fullName"]);
                    Session["UserName"] = Convert.ToString(dt.Rows[0]["UserName"]);
                    Session["UserId"] = txtUserName.Text;
                    Session["MFA_applicable"] = Convert.ToString(dt.Rows[0]["MFA_applicable"]);
                    Session["EmailId"] = Convert.ToString(dt.Rows[0]["EmailId"]);
                    SaveUSERInfo.UserID = txtUserName.Text;

                    lblError.Visible = false;

                    SaveUSERInfo.AuthorizeUSERID = "";

                    lblError.Visible = false;
                    if (Check_IsSystem())
                    {
                        SaveUSERInfo.AuthorizePassword = "1";
                        Session["USERInfo"] = SaveUSERInfo;

                        isValidUser = 1;

                    }
                    else
                    {
                        SaveUSERInfo.AuthorizePassword = "0";
                        Session["USERInfo"] = SaveUSERInfo;
                        isValidUser = 2;
                    }
                }
                else
                {
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
                        lblError.Text = $"Your account has been locked, Please contact to Calculus SPOC.";
                    }
                    isValidUser = 0;
                }
            }
            else
            {
                txtCaptcha.Text = "";
                lblError.Visible = true;
                lblError.ForeColor = System.Drawing.Color.Red;
                lblError.Text = "Invalid Captcha! Please try again.";
                isValidUser = 0;
            }

            return isValidUser;
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
                smtp.Credentials = new System.Net.NetworkCredential("calculus@pamac.com", "pamac@123");
                mail.From = new MailAddress("calculus@pamac.com", "PAMAC-Tata Capital Ltd");
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
                           "<P>Software  Team</P> " +
                           "</font></html></body>";

                mail.Body = strBody;
                mail.IsBodyHtml = true;
                smtp.Port = 587;
                smtp.Credentials = new System.Net.NetworkCredential("calculus@pamac.com", "pamac@123");
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
    }
}