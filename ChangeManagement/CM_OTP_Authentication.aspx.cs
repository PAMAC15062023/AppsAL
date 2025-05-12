using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ChangeManagement
{
    public partial class CM_OTP_Authentication : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int returnvalue = Check_EmailID();
                if (returnvalue == 0)
                {
                    Reverse_OTP();
                    //Response.Redirect("OTP_Authentication.aspx", false); //add on 01/07/2024
                    lblOTP.Visible = false;
                    lblMessage.Visible = true;
                    lnkLoginAgain.Visible = true;
                    lblMessage.ForeColor = System.Drawing.Color.Red;
                    lblMessage.Text = "Not allowed to Login.Please Contact to Admin!..";
                    return;

                }
                else
                {

                    int otp = GenerateRandomNo();

                    Session["OTP"] = otp;
                    Session["OTPSendDatetime"] = DateTime.Now;
                    bool result = Email(otp, Convert.ToString(Session["UserId"]), Convert.ToString(Session["UserName"]), Convert.ToString(Session["Email"]));
                    if (result == true)
                    {
                        txtOTP.Visible = true;
                        btnVerify.Visible = true;
                    }
                    else
                    {
                        //Response.Redirect("SCM_MenuPage.aspx", false);
                        lblOTP.Visible = false;
                        lblMessage.Visible = true;
                        lnkLoginAgain.Visible = true;
                        lblMessage.ForeColor = System.Drawing.Color.Red;
                        lblMessage.Text = "Not allowed to Login.Please Contact to Admin!..";
                        return;
                    }

                }
            }
        }
        protected void btnVerify_Click(object sender, EventArgs e)
        {
            try
            {

                Session["Attempt"] = Convert.ToInt32(Session["Attempt"]) + 1;

                int attempts = Convert.ToInt32(Session["Attempt"]);

                DateTime OTPSendDatetime = Convert.ToDateTime(Session["OTPSendDatetime"]);
                DateTime OTP_Valid_Datetime = OTPSendDatetime.AddMinutes(2);

                if (attempts < 4)
                {

                    if (txtOTP.Text.Trim() == Convert.ToString(Session["OTP"]))
                    {
                        if (Convert.ToDateTime(OTP_Valid_Datetime.ToString("HH:mm")) >= Convert.ToDateTime(DateTime.Now.ToString("HH:mm")))
                        {
                            Response.Redirect("CM_MenuPage.aspx", false);
                        }
                        else
                        {
                            Reverse_OTP();
                            lblMessage.Visible = true;
                            lblMessage.Text = "OTP Expired";
                            Session.Clear();
                            Response.Redirect("CM_Login.aspx", false);
                        }
                    }

                    else
                    {

                        lblMessage.Visible = true;
                        int remainingAttempts = 3 - attempts;
                        txtOTP.Text = "";
                        lblMessage.Text = "Invalid OTP - Please try  again  "; //  + remainingAttempts + " attempts remaining ";

                    }
                }

                if (attempts == 4)
                {
                    Reverse_OTP();
                    lblMessage.Visible = true;
                    lblMessage.Text = "You have exceeded the maximum number of attempts.";
                    Session.Clear();
                    Response.Redirect("SCM_Login.aspx", false);
                }
            }
            catch (Exception ex)
            {
                lblMessage.Text = ex.ToString();
            }
        }

        protected void lnkLoginAgain_Click(object sender, EventArgs e)
        {
            try
            {

                Session.Clear();
                Response.Redirect("CM_Login.aspx", false);

            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }

        private int Check_EmailID()
        {
            int returnVal = 0;
            SqlConnection sqlCon = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            //SqlConnection sqlCon = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);
            try
            {
                if (sqlCon.State == ConnectionState.Closed)
                {

                    SqlCommand sqlCom = new SqlCommand();
                    sqlCom.Connection = sqlCon;
                    sqlCom.CommandType = CommandType.StoredProcedure;
                    sqlCom.CommandText = "SP_GetEmailId";
                    sqlCom.CommandTimeout = 0;

                    sqlCom.Parameters.AddWithValue("@UserID", Convert.ToString(Session["UserId"]));


                    SqlDataAdapter sqlDA = new SqlDataAdapter();
                    sqlDA.SelectCommand = sqlCom;

                    DataTable dt = new DataTable();
                    sqlDA.Fill(dt);

                    if (dt.Rows.Count > 0)
                    {
                        if (Convert.ToString(dt.Rows[0]["EmailID"]) != "" && Convert.ToString(dt.Rows[0]["EmailID"]) != null)
                        {
                            Session["Email"] = Convert.ToString(dt.Rows[0]["EmailID"]);
                            returnVal = 1;
                        }
                        else
                        {
                            returnVal = 0;
                        }
                    }
                    else
                    {
                        returnVal = 0;
                    }
                }
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
            }
            return returnVal;
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
                smtp.Credentials = new System.Net.NetworkCredential("test.pamac@pamac.com", "hsu@z@123");
                mail.From = new MailAddress("calculus@pamac.com", "PAMAC SSU");
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

        public void Reverse_OTP()
        {
            Object SaveUSERInfo = (Object)Session["UserInfo"];
            SqlConnection sqlCon = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            //SqlConnection sqlCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);
            SqlCommand sqlCom = new SqlCommand();
            sqlCom.Connection = sqlCon;
            sqlCom.CommandType = CommandType.StoredProcedure;
            sqlCom.CommandText = "SP_Reverse";
            sqlCom.CommandTimeout = 0;

            SqlDataAdapter sqlDA = new SqlDataAdapter();
            sqlDA.SelectCommand = sqlCom;

            sqlCom.Parameters.AddWithValue("@UserID", Convert.ToString(Session["UserId"]));

            sqlCon.Open();

            int SqlRow = 0;
            SqlRow = sqlCom.ExecuteNonQuery();

            sqlCon.Close();

            if (SqlRow > 0)
            {
            }
            else
            {
            }
        }
    }
}