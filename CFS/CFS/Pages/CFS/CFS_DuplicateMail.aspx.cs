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

public partial class Pages_CFS_CFS_DuplicateMail : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnsubmit_Click(object sender, EventArgs e)
    {
        lblMsg.Text = "";
        try
        {
            string msg = string.Empty;

            if (txtCustomerId.Text.Trim() == "" || txtCustomerId.Text.Trim() == null)
            {
                msg = msg + "Please Enter Customer Id ,";
            }
            if (txtContactName.Text.Trim() == "" || txtContactName.Text.Trim() == null)
            {
                msg = msg + "Please Enter Contact Name , ";
            }
            if (txtEmailID.Text.Trim() == "" || txtEmailID.Text.Trim() == null)
            {
                msg = msg + "Please Enter EmailID !";
            }
            if (msg != "")
            {
                lblMsg.Text = msg;
                return;
            }
            else
            {

                string ContactName = txtContactName.Text.Trim();
                string CustomerId = txtCustomerId.Text.Trim();
                string EmailID = txtEmailID.Text.Trim();
                string ClientName = "";

                SqlConnection sqlCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);

     
                SqlCommand sqlCom = new SqlCommand();
                sqlCom.Connection = sqlCon;
                sqlCom.CommandType = CommandType.StoredProcedure;
                sqlCom.CommandText = "CFS_CheckCusIDForDuplicateMailSend_SP";
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

                if (Convert.ToInt32(ds.Tables[0].Rows[0]["count"]) == 0)
                {
                    lblMsg.Text = lblMsg.Text + "  Please Note That Orignal Mail Is Not Sent To " + ContactName + " ";
                }
                else
                {
                    ClientName = Convert.ToString(ds.Tables[1].Rows[0]["ClientName"]);

                    bool Mail_Sentsuccessfully1 = SendMail(CustomerId, EmailID, ContactName);

                    bool Mail_Sentsuccessfully2 = false;

                    if (Mail_Sentsuccessfully1 == true)
                    {
                        Mail_Sentsuccessfully2 = SendMail1(CustomerId, ClientName, EmailID, ContactName);
                    }

                    if (Mail_Sentsuccessfully1 == true && Mail_Sentsuccessfully2 == true)
                    {
                        Updatedata(CustomerId);

                        lblMsg.Text = lblMsg.Text + " Emails Sent to  " + ContactName + " ";
                        ClearData();
                    }
                }
            }
        }
        catch (Exception ex)
        {
            lblMsg.Text = ex.ToString();
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


            SmtpClient smtp = new SmtpClient("mail.pamac.com", 587);
            smtp.Credentials = new System.Net.NetworkCredential("csat@pamac.com", "#14zfr@693");

            smtp.EnableSsl = false;
            smtp.Send(mail);
        }
        catch (Exception ex)
        {
            Mail_Sentsuccessfully = false;
            lblMsg.Text = "Error:" + ex.Message;
        }
        return Mail_Sentsuccessfully;
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

            string MailTo = verticalHeadEmailId + "," + DCHEmailId + "," + DCHCoordinatorEmailId;
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
                         "with id as " + CustomerId + "-" + ClientName + " to contact person " + ContactName +
                          "<br />  <br />  <br />  PAMAC Finserve Pvt.Ltd <br />  Management Team <br />  Mumbai – Head Office";

            mail.IsBodyHtml = true;


            SmtpClient smtp = new SmtpClient("mail.pamac.com", 587);



            smtp.Credentials = new System.Net.NetworkCredential("csat@pamac.com", "#14zfr@693");

            smtp.EnableSsl = false;
            smtp.Send(mail);
        }
        catch (Exception ex)
        {
            Mail_Sentsuccessfully = false;

            lblMsg.Text = "Error:" + ex.Message;

        }
        return Mail_Sentsuccessfully;
    }
    protected void Updatedata(string CustomerId)
    {
        SqlConnection sqlCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);

        sqlCon.Open();

        SqlCommand sqlCom = new SqlCommand();
        sqlCom.Connection = sqlCon;
        sqlCom.CommandType = CommandType.StoredProcedure;
        sqlCom.CommandText = "CFS_UpdateSurvey_SP";
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

    protected void txtCustomerId_TextChanged(object sender, EventArgs e)
    {
        lblMsg.Text = "";


        SqlConnection sqlCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);

        SqlCommand sqlcom = new SqlCommand("CFS_IsCustomerIDExists_SP", sqlCon);
        sqlcom.CommandType = CommandType.StoredProcedure;
        sqlcom.Parameters.AddWithValue("@CustomerId", txtCustomerId.Text.Trim());
        SqlDataAdapter adp = new SqlDataAdapter(sqlcom);
        DataSet ds = new DataSet();
        adp.Fill(ds);

        if (ds != null && ds.Tables.Count > 0)
        {
            txtContactName.Text = Convert.ToString(ds.Tables[0].Rows[0]["ContactName"]);
            txtEmailID.Text = Convert.ToString(ds.Tables[0].Rows[0]["EmailID"]);
        }
        else
        {
            lblMsg.Text = "Customer ID Not Exists !!!";
            ClearData();
        }
    }
    protected void ClearData()
    {
        txtCustomerId.Text = "";
        txtContactName.Text = "";
        txtEmailID.Text = "";
    }
}