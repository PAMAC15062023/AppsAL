using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
//using Microsoft.ApplicationBlocks.Data;
using System.Net.Mail;
using System.Configuration;
using System.IO;

namespace LNTFinance
{
    public partial class LNT_PurgingEmailSend : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected bool Successful()
        {

            DateTime CurrentDatetime = DateTime.Now;
            int hour = CurrentDatetime.Hour;
            string MailTo = "";
            string MailCC = "";
            bool validation = false;
           
            try
            {
                SqlConnection sqlCon = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);

                SqlCommand cmd = new SqlCommand("LNT_SendDataPurgeMail_SP", sqlCon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adp.Fill(ds);
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    MailTo = ds.Tables[0].Rows[0]["ToEmail"].ToString();

                    MailCC = ds.Tables[0].Rows[0]["CCEmail"].ToString();
                }

                string TIME = string.Empty;

                if (hour == 18)
                {
                    TIME = "06:00 pm.";
                }
                else
                {
                    TIME = "12:00 noon.";
                }

                System.Net.Mail.MailMessage mail = new System.Net.Mail.MailMessage();
                mail.Subject = "Data Purge Confirmation";
                mail.From = new MailAddress("tpu.support04@pamac.com");


                mail.To.Add(MailTo.TrimEnd(','));
                mail.CC.Add(MailCC.TrimEnd(','));

                string strBody =
                       "<html><body><font color=\"0E0F44\" style=\"font-family=Times New Roman;font-size=85%\" >" +
                       "<P>                                                                                               </P>" +
                       "<P> Dear All,</P>" +
                       "</font></html></body>" +

                       "<html><body><font color=\"002060\" style=\"font-family=Times New Roman;font-size=85%\" >" +
                       "<P>This is to confirm that the data has been purged from the systems for the day.</P>" +
                       "</font></html></body>" +

                       "<html><body><font color=\"002060\" style=\"font-family=Times New Roman;font-size=85%\" >" +
                       "<P>This is an automatically generated email, please don't respond to this email address.</P>" +
                       "<P>                                                                                         </P>" +
                       "</font></html></body>" +
                       "</br>" +
                     //line-height: 0.1 
                     "<html><body><font color=\"002060\" style=\"font-family=Times New Roman;font-size=85%\" >" +
                       "<P>Thanks & Regards,</P>" +
                       "<P>PTPU - LTFS Support Team</P> " +
                       "<P>Email: <U>tpu.support04@pamac.com</U></P> " +
                       "</font></html></body>" +
                       "</br>" +
                        //line-height: 0.1;
                        "<html><body><font color=\"002060\" style=\"font-family=Times New Roman;font-size=90%;font-weight=bold\" >" +
                       "<P>PAMAC Group, BANKING ON OUR CREDENTIALS - 5000+ Employee Base|2 Countries|42 </P>" +
                       "<P>Locations|150+ Clients|25+ Years in Business</P>" +
                       "</font></html></body>" +
                       "<html><body><font color=\"002060\" style=\"font-family=Times New Roman;font-size=85%;font-weight=bold\" >" +
                       "<P>WE are spreading our wings, do visit our revamped website for more details – <U>www.pamac.com</U></P>" +
                          "</font></html></body>";
               

                mail.Body = strBody;
                mail.IsBodyHtml = true;
                SmtpClient smtp = new SmtpClient("mail.pamac.com", 587);
                smtp.Credentials = new System.Net.NetworkCredential("tpu.support04@pamac.com", "a$px2uvnV");
                smtp.EnableSsl = false;
                smtp.Send(mail);
                validation = true;
            }
            catch (Exception ex)
            {

                 lblMsgXls.Text = ex.Message;
                validation = false;

                //objProgram.SendMail(Message);
            }
            return validation;
        }

        protected bool Failed()
        {

            DateTime CurrentDatetime = DateTime.Now;
            int hour = CurrentDatetime.Hour;
            string MailTo = "";
            string MailCC = "";
            bool validation = false;


            try
            {
                SqlConnection sqlCon = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);

                SqlCommand cmd = new SqlCommand("LNT_SendDataPurgeMail_SP", sqlCon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adp.Fill(ds);
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    MailTo = ds.Tables[0].Rows[0]["ToEmail"].ToString();

                    MailCC = ds.Tables[0].Rows[0]["CCEmail"].ToString();
                }

                string TIME = string.Empty;

                if (hour == 18)
                {
                    TIME = "06:00 pm.";
                }
                else
                {
                    TIME = "12:00 noon.";
                }

                System.Net.Mail.MailMessage mail = new System.Net.Mail.MailMessage();
                mail.Subject = "Data Purge Confirmation";
                mail.From = new MailAddress("tpu.support04@pamac.com");


                mail.To.Add(MailTo.TrimEnd(','));
                mail.CC.Add(MailCC.TrimEnd(','));

                string strBody =
                       "<html><body><font color=\"Navy\" style=\"font-style=Italic;font-weight=bold\">" +
                       "<P>                                                                                               </P>" +
                       "<P>Dear All,</P>" +
                       "<P>Due to the technical glitch, the data has not been purged by the system for the time:-" + TIME + ".</P>" +
                       "<P>*This Is An Automatically Generated Email, Please Do Not Reply*</P>" +
                       "<P>                                                                                         </P>" +
                       "<P>Thanks & Regards,</P>" +
                       "<P>LTFS - Support Team.</P> " +
                       "</font></html></body>";

                mail.Body = strBody;
                mail.IsBodyHtml = true;
                SmtpClient smtp = new SmtpClient("mail.pamac.com", 587);
                smtp.Credentials = new System.Net.NetworkCredential("tpu.support04@pamac.com", "a$px2uvnV");
                smtp.EnableSsl = false;
                smtp.Send(mail);
                validation = true;
            }
            catch (Exception ex)
            {

                lblMsgXls.Text = ex.Message;
                validation = false;
            }
            return validation;
        }

        protected void ClearData()
        {
            ddlPurgingStatus.SelectedIndex = 0;
        }
        protected void btnOk_Click(object sender, EventArgs e)
        {
            lblMsgXls.Text = "";

            if (ddlPurgingStatus.SelectedItem.Text == "Success")
            {
                bool result = Successful();
                if (result)
                {
                    SentMailLog("Success:Mail Sent Successfully");
                    ClearData();
                    lblMsgXls.Text = "Mail Sent Successfully";
                }
                else
                {
                    SentMailLog("Sending Mail Fail");
                }
                
            }
            if (ddlPurgingStatus.SelectedItem.Text == "Failed")
            {
                bool result = Failed();
                if (result)
                {
                    SentMailLog("Failed: Mail Sent Successfully");
                    ClearData();
                    lblMsgXls.Text = "Mail Sent Successfully";
                }
                else
                {
                    SentMailLog("Sending Mail Fail");
                }
            }
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("MenuPage.aspx", false);
        }

        protected void SentMailLog(string Mailstatus)
        {
            SqlConnection sqlCon = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);

            SqlCommand cmd = new SqlCommand("LNT_InsertSentMailLog_SP", sqlCon);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Status", Mailstatus);
            cmd.Parameters.AddWithValue("@UserID", Convert.ToString(Session["LoginName"]));
            

            sqlCon.Open();
            cmd.ExecuteNonQuery();
            sqlCon.Close();

            
          
        }

    }
}