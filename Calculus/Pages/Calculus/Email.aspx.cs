using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using System.IO;
using System.Net.Mail;
using System.Threading;
using System.Text;

public partial class Pages_Calculus_Email : System.Web.UI.Page
{
    string Emailid;

    String allData;
    protected void Page_Load(object sender, EventArgs e)
    {
     Application_start();
          
    }

    void Application_start()
    {
        Thread thread = new Thread(CronThread);
        thread.IsBackground = true;
        thread.Start();
                     
        
    }

    private void CronThread()
    {
        while (true)
        {
            Thread.Sleep(TimeSpan.FromMinutes(5));
            // Do something every half hour
            Email();
                


        }
    }

    private void Email()
    {
        allData = string.Empty;
        Object SaveUSERInfo = (Object)Session["UserInfo"];

        SqlConnection sqlcon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);

        sqlcon.Open();
        SqlCommand sqlcmd = new SqlCommand();
        sqlcmd.Connection = sqlcon;
        sqlcmd.CommandType = CommandType.StoredProcedure;
        sqlcmd.CommandText = "CalOnlineTrans_GetEmail_SP";

        SqlParameter UserID = new SqlParameter();
        UserID.SqlDbType = SqlDbType.VarChar;
        //UserID.Value = Convert.ToString(((UserInfo.structUSERInfo)(SaveUSERInfo)).UserId);
        UserID.Value = "P01390";
        UserID.ParameterName = "@UserID";
        sqlcmd.Parameters.Add(UserID);

        SqlParameter BranchId = new SqlParameter();
        BranchId.SqlDbType = SqlDbType.Int;
        BranchId.Value = "85";
        BranchId.ParameterName = "@BranchId";
        sqlcmd.Parameters.Add(BranchId);

        SqlDataAdapter da = new SqlDataAdapter();
        da.SelectCommand = sqlcmd;

        DataTable dt = new DataTable();
        da.Fill(dt);

        int Count = dt.Rows.Count;

        sqlcon.Close();


        string Emailstatus=string.Empty;
        string LapsedDate;
        string TransactionId=string.Empty;
        string User=string.Empty;
        string newData = string.Empty;
        for (int i = 0; i < Count; i++)
        {
             User = dt.Rows[i]["UserID"].ToString();
             TransactionId = dt.Rows[i]["transactionid"].ToString();
             LapsedDate = dt.Rows[i]["LapsedDate"].ToString();
             Emailstatus = dt.Rows[i]["EmailStatus"].ToString();
             if (allData == string.Empty)
             {
                 allData = TransactionId;
             }
             else
             {
                 string[] transid = allData.Split(',');
                 foreach (string a in transid)
                 {
                    if (a != TransactionId)
                     {
                         if (newData != TransactionId)
                         {
                             allData = allData + "," + TransactionId;
                         }
                     }
                    newData = TransactionId;
                 }
                
             }
        }

        lblMessage.Text = allData;

        //if (User == "P00024")
        //{
        //    Emailid = "sachin.tirlotkar@pamac.com";
        //    //  Emailid = "edp@pamac.com";
        //}
        //else if (User == "P00013")
        //{
        //    Emailid = "sameer.kudalkar@pamac.com";
        //}
        //else if (User == "P00004")
        //{
        //    Emailid = "shankar.devare@pamac.com";
        //}
        //else if (User == "P14003")
        //{
        //    Emailid = "maulik.tikariya@pamac.com";
        //}
        //else if (User == "P00201")
        //{
        //    Emailid = "rajesh.patel@pamac.com";
        //}
        //else if (User == "P16021")
        //{
        //    Emailid = "samson.wilson@pamac.com";
        //}
        //else if (User == "P00020")
        //{
        //    Emailid = "murugan.odiyar@pamac.com";
        //}
        //else if (User == "P00008")
        //{
        //    Emailid = "Pravin.shinde@pamac.com";
        //}
        //else if (User == "P49660")
        //{
        //    Emailid = "Niteen.badhan@pamac.com";
        //}

        Emailid = "rupesh.zodage@pamac.com";

           string strTime = System.DateTime.Now.TimeOfDay.ToString().Remove(5);
           string strhh = strTime.Remove(2);
           string strmm = strTime.Remove(0, 3);

           //string LapsedDate = System.DateTime.Now.AddDays(3).Date.ToString().Remove(10); // At the time of saving save in Datelimit Column
           string Current = System.DateTime.Now.Date.ToString().Remove(10);
           if (Count > 0)
           {
               if (allData != null)
               {
                   if (Emailstatus != "Sent")
                   {
                       try
                       {
                           MailMessage mail = new MailMessage();
                           //SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com",25);
                           SmtpClient smtp = new SmtpClient("69.64.70.36", 25);
                           //SmtpServer.Host = "69.64.70.36";

                           mail.From = new MailAddress("calculus@pamac.com", "PAMAC Account"); //you have to provide your gmail address as from addres

                           mail.To.Add(Emailid);
                           //////mail.CC.Add("helpdesk@pamac.com");
                           ////mail.To.Add("ganesh.sawant@pamac.com");
                           //mail.Bcc.Add("info@pamac.com");


                           mail.Subject = "PAMAC Accounts : Vendor Payment Lapsed due to delay in approval ";

                           string strBody =
                                   "<html><body><font color=\"Navy\"><P>=====================================================================================================================</P>" +

                                   "<P>                                                                                               </P>" +
                                   " <P>Hi PAMACian,</P>" +
                                   "<P>                                                                                         </P>" +
                                   "<P>This is an automated response to update you that following  Transaction  " + allData + " request raised in the PAMACCalculus has got lapsed due the approval not given within stipulated time frame.</P>" +
                                   "<P>                                                                                         </P>" +
                                   " <P>Please look into the matter and approved within 3 working days.</P>" +
                                   "<P>                                                                                        </P>" +
                                   "<P>“This is computer generated mail and hence do not reply to this mail”  </P>" +
                                   "<P>                                                                                         </P>" +
                                   "<P>Regards,</P>" +
                                   "<P>PAMAC Calculus Helpdesk</P> " +

                              "<P>=====================================================================================================================</P></font></html></body>";

                           mail.Body = strBody;

                           mail.IsBodyHtml = true;

                           smtp.Port = 25;
                           smtp.Credentials = new System.Net.NetworkCredential("calculus@pamac.com", "HW76$$mm");  //you have to provide you gamil username and password
                           smtp.EnableSsl = false;/// Main line :SSL should be false

                           smtp.Send(mail);
                           lblMessage.Text = "Email successfully sent.";

                           StatusLapsed(allData);
                       }

                       catch (Exception ex)
                       {
                           lblMessage.Text = "Email Failed." + ex.Message;
                       }
                   }
               }
           }
    }

    private void StatusLapsed(string TransactionId)
    {
        Object SaveUSERInfo = (Object)Session["UserInfo"];

        SqlConnection sqlcon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);
              

        string [] transid=allData.Split(',');
        sqlcon.Open();
        foreach (string a in transid)
        {
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlcon;
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.CommandText = "CalOnlineTrans_StatusLapsed_SP";

            SqlParameter Transaction = new SqlParameter();
            Transaction.SqlDbType = SqlDbType.VarChar;
            Transaction.Value = a;
            Transaction.ParameterName = "@TransactionId";
            sqlcmd.Parameters.Add(Transaction);

            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = sqlcmd;

            DataTable dt = new DataTable();
            da.Fill(dt);
           
        }
        sqlcon.Close();
       
    }
    
 protected void BtnMail_Click(object sender, EventArgs e)
    {
       Email();
    }

}