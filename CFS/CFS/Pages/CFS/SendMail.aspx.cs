using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OleDb;
using System.Data;
using System.Configuration;
using System.IO;
using System.Drawing;
using System.Data.SqlClient;
using System.Net.Mail;
using System.Windows.Forms;

public partial class Pages_CFS_SendMail : System.Web.UI.Page
{


    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void ddlcustomerType_SelectedIndexChanged(object sender, EventArgs e)
    {

        SqlConnection sqlCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);

     

        SqlCommand sqlCom = new SqlCommand();
        sqlCom.Connection = sqlCon;
        sqlCom.CommandType = CommandType.StoredProcedure;
        sqlCom.CommandText = "CFS_Searchfilter";
        SqlDataAdapter sqlDA = new SqlDataAdapter();
        sqlDA.SelectCommand = sqlCom;

        SqlParameter value = new SqlParameter();
        value.SqlDbType = SqlDbType.VarChar;
        value.Value = ddlcustomerType.SelectedValue;
        value.ParameterName = "@value";
        sqlCom.Parameters.Add(value);


        SqlDataAdapter adp = new SqlDataAdapter(sqlCom);
        DataSet ds = new DataSet();
        adp.Fill(ds);

        if (ds != null)
        {
            ddlCustomerList.DataTextField = "Client_Name";
            ddlCustomerList.DataValueField = "Short_Name_Client";
            ddlCustomerList.DataSource = ds;
            ddlCustomerList.DataBind();
            ddlCustomerList.Items.Insert(0, "--Select--");
        }
    }

    protected void ddlCustomerList_SelectedIndexChanged(object sender, EventArgs e)
    {
        SqlConnection sqlCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);

         

        SqlCommand sqlCom = new SqlCommand();
        sqlCom.Connection = sqlCon;
        sqlCom.CommandType = CommandType.StoredProcedure;
        sqlCom.CommandText = "CFS_GridList_SP";
        SqlDataAdapter sqlDA = new SqlDataAdapter();
        sqlDA.SelectCommand = sqlCom;

        SqlParameter value1 = new SqlParameter();
        value1.SqlDbType = SqlDbType.VarChar;
        value1.Value = ddlcustomerType.SelectedValue;
        value1.ParameterName = "@value1";
        sqlCom.Parameters.Add(value1);

        SqlParameter value2 = new SqlParameter();
        value2.SqlDbType = SqlDbType.VarChar;
        value2.Value = ddlCustomerList.SelectedValue;
        value2.ParameterName = "@value2";
        sqlCom.Parameters.Add(value2);


        SqlDataAdapter adp = new SqlDataAdapter(sqlCom);
        DataSet ds = new DataSet();
        adp.Fill(ds);

        if (ds != null)
        {
            gvcustomerDetails.DataSource = ds;
            gvcustomerDetails.DataBind();
        }
        else
        {
            gvcustomerDetails.DataSource = null;
            gvcustomerDetails.DataBind();
        }
    }

    protected void btnsubmit_Click(object sender, EventArgs e)
    {
        lblMsg.Text = "";


        foreach (GridViewRow gvrow in gvcustomerDetails.Rows)
        {
            System.Web.UI.WebControls.CheckBox chk = (System.Web.UI.WebControls.CheckBox)gvrow.FindControl("chb");
            if (chk != null & chk.Checked)
            {
                string id = gvrow.Cells[1].Text;
                string ContactName = gvrow.Cells[15].Text;
                string ClientName = gvrow.Cells[4].Text;
                string CustomerId = gvrow.Cells[14].Text;
                string EmailID = gvrow.Cells[18].Text;

                SqlConnection sqlCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);

                

                SqlCommand sqlCom = new SqlCommand();
                sqlCom.Connection = sqlCon;
                sqlCom.CommandType = CommandType.StoredProcedure;
                sqlCom.CommandText = "CFS_CheckCusID_SP";
                SqlDataAdapter sqlDA = new SqlDataAdapter();
                sqlDA.SelectCommand = sqlCom;

                SqlParameter CustomerID1 = new SqlParameter();
                CustomerID1.SqlDbType = SqlDbType.VarChar;
                CustomerID1.Value = CustomerId;
                CustomerID1.ParameterName = "@CustomerId";
                sqlCom.Parameters.Add(CustomerID1);

                DataSet ds = new DataSet();
                SqlDataAdapter adp = new SqlDataAdapter(sqlCom);
                adp.Fill(ds);

                if (Convert.ToInt32(ds.Tables[0].Rows[0]["count"]) > 0)
                {
                    lblMsg.Text = lblMsg.Text + "  Survey already sent  " + ContactName + " ";
                }
                else
                {
                   bool Mail_Sentsuccessfully1 = SendMail(CustomerId, EmailID, ContactName);

                    bool Mail_Sentsuccessfully2 = false;

                    if (Mail_Sentsuccessfully1 == true)
                    {
                        Mail_Sentsuccessfully2 = SendMail1(CustomerId, ClientName, EmailID, ContactName);
                    }
                   
                    if (Mail_Sentsuccessfully1 == true && Mail_Sentsuccessfully2 == true)
                    {
                        insertdata(CustomerId);

                        lblMsg.Text = lblMsg.Text + " Emails Sent to  " + ContactName + " ";
                    }
                }

            }
        }
    }
    protected bool SendMail(string CustomerId, string email, string ContactName)
    {
        bool Mail_Sentsuccessfully = true;

        try
        {

            string appURL = System.Configuration.ConfigurationManager.AppSettings["appUrl"].ToString();
            appURL = appURL + "Pages/CFS/CFS_CustomerResponse.aspx?custid=" + CustomerId;
            string MailTo = email;

            string MailCC = "csat@pamac.com";

            string filename = "PAMAC CFS Format for Offline Feedback";

            string fileDirectory = Server.MapPath("~/Pages/CFS/UploadFile/");

            //SqlCommand cmd = new SqlCommand("USP_GetEMPMailIdForSSUReport", con);
            //cmd.CommandType = CommandType.StoredProcedure;
            //cmd.CommandType = CommandType.StoredProcedure;
            //SqlDataAdapter adp = new SqlDataAdapter(cmd);
            //DataSet ds = new DataSet();
            //adp.Fill(ds);
            //if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            //{
            //    MailTo = ds.Tables[0].Rows[0]["ToEmail"].ToString();
            //    MailCC = ds.Tables[0].Rows[0]["CCEmail"].ToString();
            //}


            //MailCC = "";

            System.Net.Mail.MailMessage mail = new System.Net.Mail.MailMessage();
            mail.Subject = "PAMAC Customer Survey Report";
            mail.From = new MailAddress("csat@pamac.com"); 
        


            mail.To.Add(MailTo.TrimEnd(','));
            mail.CC.Add(MailCC.TrimEnd(','));

            mail.Body = "<p>Dear " + ContactName + ",</p><br /><p>We thank you for giving us the opportunity to serve you better." + '\n' +
                         "We are currently running a review of our business practices & systems and are hoping you " +
                         "can help us improve our performance by answering a few questions.We appreciate your business and have " +
                         "designed this survey in a format that will not expect you to spend more than few minutes.<p/>" +
                          "<br /><a href='" + appURL + "'>Click at this link to access the survey</a>" +
                          "<br />  <br />  <br />  PAMAC Finserve Pvt.Ltd <br />  Management Team <br />  Mumbai – Head Office";
            mail.IsBodyHtml = true;

            //    mail.Attachments.Add(new Attachment(@"C:\Users\dell\Desktop\CFS\NANO-PRO-App_Csharp_Calculus(08May2016)\Pages\CFS\UploadFile\" + "\\" + filename));
            SmtpClient smtp = new SmtpClient("mail.pamac.com", 587);

            //smtp.Credentials = new System.Net.NetworkCredential("test.pamac@pamac.com", "hsu@z@123"); 

            smtp.Credentials = new System.Net.NetworkCredential("csat@pamac.com", "#14zfr@693");

            smtp.EnableSsl = false;
            smtp.Send(mail);
        }
        catch (Exception ex)
        {

            Mail_Sentsuccessfully = false;

            lblMsg.Text = "Error:" + ex.Message; 

            //string logsDirectory = Path.Combine(Environment.CurrentDirectory, "ErrorLog\\ErrorLog.txt");

            //using (StreamWriter writer = new StreamWriter(logsDirectory, true))
            //{
            //    writer.WriteLine("Message :" + ex.Message + "<br/>" + Environment.NewLine + "StackTrace :" + ex.StackTrace +
            //       "" + Environment.NewLine + "Date :" + DateTime.Now.ToString());
            //    writer.WriteLine(Environment.NewLine + "-----------------------------------------------------------------------------" + Environment.NewLine);
            //}
        }

        return Mail_Sentsuccessfully ;

    }

    protected bool SendMail1(string CustomerId, string ClientName, string email, string ContactName)
    {
       bool Mail_Sentsuccessfully = true;
         

        string verticalHeadEmailId = "";
        string DCHEmailId = "";
        string DCHCoordinatorEmailId = "";

        SqlConnection sqlCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);

     

        SqlCommand sqlCom = new SqlCommand();
        sqlCom.Connection = sqlCon;
        sqlCom.CommandType = CommandType.StoredProcedure;
        sqlCom.CommandText = "CFS_GetMailIds";
        SqlDataAdapter sqlDA = new SqlDataAdapter();
        sqlDA.SelectCommand = sqlCom;

        SqlParameter CustomerID1 = new SqlParameter();
        CustomerID1.SqlDbType = SqlDbType.VarChar;
        CustomerID1.Value = CustomerId;
        CustomerID1.ParameterName = "@CustomerID";
        sqlCom.Parameters.Add(CustomerID1);

        DataSet ds = new DataSet();
        SqlDataAdapter adp = new SqlDataAdapter(sqlCom);
        adp.Fill(ds);

        if (ds != null)
        {
             verticalHeadEmailId = ds.Tables[0].Rows[0]["Head_EmailID"].ToString();
             DCHEmailId = ds.Tables[0].Rows[0]["DCH_Email_id"].ToString();
             DCHCoordinatorEmailId = ds.Tables[0].Rows[0]["DCH_Corodinator_email_id"].ToString();
        }



        try
        {
            // vertical email id, DCH emailid, DCH_coordinator email id to be taken from above after UAT


            //string MailTo = "ramakrishnan.v@pamac.com";  // vertical

            // string MailCC = "yasir.siddiqui@pamac.com , ramki552@gmail.com"; // dch  & DCH_coordinator

            string MailTo = verticalHeadEmailId + ","+ DCHEmailId +","+ DCHCoordinatorEmailId;
            string MailCC = "csat@pamac.com";

            string filename = "PAMAC CFS Format for Offline Feedback";


            string fileDirectory = Server.MapPath("~/Pages/CFS/UploadFile/");

            //SqlCommand cmd = new SqlCommand("USP_GetEMPMailIdForSSUReport", con);
            //cmd.CommandType = CommandType.StoredProcedure;
            //cmd.CommandType = CommandType.StoredProcedure;
            //SqlDataAdapter adp = new SqlDataAdapter(cmd);
            //DataSet ds = new DataSet();
            //adp.Fill(ds);
            //if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            //{
            //    MailTo = ds.Tables[0].Rows[0]["ToEmail"].ToString();
            //    MailCC = ds.Tables[0].Rows[0]["CCEmail"].ToString();
            //}

            System.Net.Mail.MailMessage mail = new System.Net.Mail.MailMessage();
            mail.Subject = "PAMAC Customer Survey Report  - Sent to your customer";
            mail.From = new MailAddress("csat@pamac.com");//"csat@pamac.com"

            mail.To.Add(MailTo.TrimEnd(','));
            mail.CC.Add(MailCC.TrimEnd(','));

            mail.Body = "<p>Dear  Sir " + ",</p><br /><p>We would like to inform you that a Customer Survey Report is sent to your customer<p/>" +
                         "with id as " + CustomerId + "-"+ ClientName+ " to contact person " + ContactName +
                          "<br />  <br />  <br />  PAMAC Finserve Pvt.Ltd <br />  Management Team <br />  Mumbai – Head Office";

            mail.IsBodyHtml = true;

            //    mail.Attachments.Add(new Attachment(@"C:\Users\dell\Desktop\CFS\NANO-PRO-App_Csharp_Calculus(08May2016)\Pages\CFS\UploadFile\" + "\\" + filename));
            SmtpClient smtp = new SmtpClient("mail.pamac.com", 587);
            //smtp.Credentials = new System.Net.NetworkCredential("test.pamac@pamac.com", "hsu@z@123");
            
            
            smtp.Credentials = new System.Net.NetworkCredential("csat@pamac.com", "#14zfr@693");

            smtp.EnableSsl = false;
            smtp.Send(mail);
        }
        catch (Exception ex)
        {
            Mail_Sentsuccessfully = false;

            lblMsg.Text = "Error:" + ex.Message;

            //string logsDirectory = Path.Combine(Environment.CurrentDirectory, "ErrorLog\\ErrorLog.txt");

            //using (StreamWriter writer = new StreamWriter(logsDirectory, true))
            //{
            //    writer.WriteLine("Message :" + ex.Message + "<br/>" + Environment.NewLine + "StackTrace :" + ex.StackTrace +
            //       "" + Environment.NewLine + "Date :" + DateTime.Now.ToString());
            //    writer.WriteLine(Environment.NewLine + "-----------------------------------------------------------------------------" + Environment.NewLine);
            //}
        }
        return Mail_Sentsuccessfully;
    }

    protected void insertdata(string CustomerId)
    {
        SqlConnection sqlCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);

        sqlCon.Open();

        SqlCommand sqlCom = new SqlCommand();
        sqlCom.Connection = sqlCon;
        sqlCom.CommandType = CommandType.StoredProcedure;
        sqlCom.CommandText = "CFS_InsertSurvey_SP";
        SqlDataAdapter sqlDA = new SqlDataAdapter();
        sqlDA.SelectCommand = sqlCom;

        SqlParameter CustomerID1 = new SqlParameter();
        CustomerID1.SqlDbType = SqlDbType.VarChar;
        CustomerID1.Value = CustomerId;
        CustomerID1.ParameterName = "@CustomerId";
        sqlCom.Parameters.Add(CustomerID1);

        sqlCom.ExecuteNonQuery();

        sqlCon.Close();

    }

    protected void btnCalcel_Click(object sender, EventArgs e)
    {
        Response.Redirect("CFS.aspx", true);
    }
}