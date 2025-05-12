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

public partial class Pages_CFS_CFS_CustomerResponse_Manual : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindCustomerDetails();
            BindQuestionnaireGrid();
        }
    }
    protected void BindCustomers(string CustomerId)
    {
        SqlConnection sqlCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);

        

        SqlCommand sqlCom = new SqlCommand();
        sqlCom.Connection = sqlCon;
        sqlCom.CommandType = CommandType.StoredProcedure;
        sqlCom.CommandText = "CFS_GetCutomerListForSurvey_SP";
        SqlDataAdapter sqlDA = new SqlDataAdapter();
        sqlDA.SelectCommand = sqlCom;


        SqlParameter value1 = new SqlParameter();
        value1.SqlDbType = SqlDbType.VarChar;
        value1.Value = CustomerId;
        value1.ParameterName = "@CustomerId";
        sqlCom.Parameters.Add(value1);


        SqlDataAdapter adp = new SqlDataAdapter(sqlCom);
        DataSet ds = new DataSet();
        adp.Fill(ds);

        if (ds != null)
        {
            lblClientName.Text = ds.Tables[0].Rows[0]["Client_Name"].ToString();
            lblDate.Text = Convert.ToString(DateTime.Now);
            lblCleintRepresentative.Text = ds.Tables[0].Rows[0]["Name_contact_person"].ToString();
            lblPAMACCenter.Text = ds.Tables[0].Rows[0]["Centre"].ToString();
            hfemailId.Value = ds.Tables[0].Rows[0]["EmailAddress"].ToString();
        }
    }
    protected void BindQuestionnaireGrid()
    {
        SqlConnection sqlCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);

       
        SqlCommand sqlCom = new SqlCommand();
        sqlCom.Connection = sqlCon;
        sqlCom.CommandType = CommandType.StoredProcedure;
        sqlCom.CommandText = "CFS_BindQuestionnaire_SP";
        SqlDataAdapter sqlDA = new SqlDataAdapter();
        sqlDA.SelectCommand = sqlCom;


        SqlDataAdapter adp = new SqlDataAdapter(sqlCom);
        DataSet ds = new DataSet();
        adp.Fill(ds);

        if (ds != null)
        {
            lblque1.Text = ds.Tables[0].Rows[0]["Question"].ToString();

            lblque2.Text = ds.Tables[0].Rows[1]["Question"].ToString();

            lblque3.Text = ds.Tables[0].Rows[2]["Question"].ToString();

            lblque4.Text = ds.Tables[0].Rows[3]["Question"].ToString();

            lblque5.Text = ds.Tables[0].Rows[4]["Question"].ToString();

            ddlAnw.DataTextField = "Answer";
            ddlAnw.DataValueField = "Answer_No";
            ddlAnw.DataSource = ds.Tables[1];
            ddlAnw.DataBind();


            ddlAnw2.DataTextField = "Answer";
            ddlAnw2.DataValueField = "Answer_No";
            ddlAnw2.DataSource = ds.Tables[2];
            ddlAnw2.DataBind();

            ddlAnw3.DataTextField = "Answer";
            ddlAnw3.DataValueField = "Answer_No";
            ddlAnw3.DataSource = ds.Tables[3];
            ddlAnw3.DataBind();

            ddlAnw4.DataTextField = "Answer";
            ddlAnw4.DataValueField = "Answer_No";
            ddlAnw4.DataSource = ds.Tables[4];
            ddlAnw4.DataBind();

            ddlAnw5.DataTextField = "Answer";
            ddlAnw5.DataValueField = "Answer_No";
            ddlAnw5.DataSource = ds.Tables[5];
            ddlAnw5.DataBind();

        }
        else
        {

        }
    }

    protected void btnsubmit_Click(object sender, EventArgs e)
    {

        //        ============
        //qnno1 = maxmars 20  select score from ans where qnno = 1 and ans 11



        int max_marks = 0;
        string answer_11 = "N";
        string answer_12 = "N";
        string answer_13 = "N";
        string answer_14 = "N";
        string answer_15 = "N";

        if (rbtnYes.Checked == true)
        {
            max_marks = 20;
            answer_11 = "Y";
        }
        if (rbtnNo.Checked == true)
        {
            int count1 = 0;
            max_marks = 20;

            foreach (ListItem item in ddlAnw.Items)
            {
                if (item.Selected == true)
                {
                    string item1 = item.Value;
                    if (item1 == "12")
                    {
                        answer_12 = "Y";
                    }
                    if (item1 == "13")
                    {
                        answer_13 = "Y";
                    }
                    if (item1 == "14")
                    {
                        answer_14 = "Y";
                    }
                    if (item1 == "15")
                    {
                        answer_15 = "Y";
                    }


                    max_marks = max_marks - 5;  // total score
                    count1 = count1 + 1;

                }
            }
        }

        if (rbtnNo.Checked == true)
        {
            if (max_marks == 20)
            {
                lblMsg.Text = "Please Select Atlest One Item ";
                return;
            }
        }


        int max_marks2 = 0;
        string answer_21 = "N";
        string answer_22 = "N";
        string answer_23 = "N";
        string answer_24 = "N";

        if (rbtnYes2.Checked == true)
        {
            max_marks2 = 15;
            answer_21 = "Y";
        }
        if (rbtnNo2.Checked == true)
        {
            int count2 = 0;
            max_marks2 = 15;

            foreach (ListItem item in ddlAnw2.Items)
            {
                if (item.Selected == true)
                {
                    string item1 = item.Value;
                    if (item1 == "22")
                    {
                        answer_22 = "Y";
                    }
                    if (item1 == "23")
                    {
                        answer_23 = "Y";
                    }
                    if (item1 == "24")
                    {
                        answer_24 = "Y";
                    }



                    max_marks2 = max_marks2 - 5;  // total score
                    count2 = count2 + 1;

                }
            }
        }

        if (rbtnNo2.Checked == true)
        {
            if (max_marks2 == 15)
            {
                lblMsg.Text = "Please Select Atlest One Item ";
                return;
            }
        }

        int max_marks3 = 0;
        string answer_31 = "N";
        string answer_32 = "N";
        string answer_33 = "N";
        string answer_34 = "N";
        string answer_35 = "N";

        if (rbtnYes3.Checked == true)
        {
            max_marks3 = 20;
            answer_31 = "Y";
        }
        if (rbtnNo3.Checked == true)
        {
            int count3 = 0;
            max_marks3 = 20;

            foreach (ListItem item in ddlAnw3.Items)
            {
                if (item.Selected == true)
                {
                    string item1 = item.Value;
                    if (item1 == "32")
                    {
                        answer_32 = "Y";
                    }
                    if (item1 == "33")
                    {
                        answer_33 = "Y";
                    }
                    if (item1 == "34")
                    {
                        answer_34 = "Y";
                    }
                    if (item1 == "35")
                    {
                        answer_35 = "Y";
                    }

                    max_marks3 = max_marks3 - 5;  // total score
                    count3 = count3 + 1;

                }
            }
        }

        if (rbtnNo3.Checked == true)
        {
            if (max_marks3 == 20)
            {
                lblMsg.Text = "Please Select Atlest One Item ";
                return;
            }
        }



        int max_marks4 = 0;
        string answer_41 = "N";
        string answer_42 = "N";
        string answer_43 = "N";
        string answer_44 = "N";
        string answer_45 = "N";

        if (rbtnYes4.Checked == true)
        {
            max_marks4 = 20;
            answer_41 = "Y";
        }
        if (rbtnNo4.Checked == true)
        {
            int count4 = 0;
            max_marks4 = 20;

            foreach (ListItem item in ddlAnw4.Items)
            {
                if (item.Selected == true)
                {
                    string item1 = item.Value;
                    if (item1 == "42")
                    {
                        answer_42 = "Y";
                    }
                    if (item1 == "43")
                    {
                        answer_43 = "Y";
                    }
                    if (item1 == "44")
                    {
                        answer_44 = "Y";
                    }
                    if (item1 == "45")
                    {
                        answer_45 = "Y";
                    }

                    max_marks4 = max_marks4 - 5;  // total score
                    count4 = count4 + 1;

                }
            }
        }

        if (rbtnNo4.Checked == true)
        {
            if (max_marks4 == 20)
            {
                lblMsg.Text = "Please Select Atlest One Item ";
                return;
            }
        }

        int count5 = 0;
        int max_marks5 = 25;
        string answer_51 = "N";
        string answer_52 = "N";
        string answer_53 = "N";
        string answer_54 = "N";

        if (ddlAnw5.SelectedValue == "51")
        {
            answer_51 = "Y";
            max_marks5 = 25;
        }
        if (ddlAnw5.SelectedValue == "52")
        {
            answer_52 = "Y";
            max_marks5 = 16;
        }
        if (ddlAnw5.SelectedValue == "53")
        {
            answer_53 = "Y";
            max_marks5 = 8;
        }
        if (ddlAnw5.SelectedValue == "54")
        {
            answer_54 = "Y";
            max_marks5 = 0;
        }


        SqlConnection sqlCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);

        sqlCon.Open();

        SqlCommand sqlCom = new SqlCommand();
        sqlCom.Connection = sqlCon;
        sqlCom.CommandType = CommandType.StoredProcedure;
        sqlCom.CommandText = "CFS_UpdateScore_SP";
        SqlDataAdapter sqlDA = new SqlDataAdapter();
        sqlDA.SelectCommand = sqlCom;

        SqlParameter Ans11 = new SqlParameter();
        Ans11.SqlDbType = SqlDbType.VarChar;
        Ans11.Value = answer_11;
        Ans11.ParameterName = "@Answer_11";
        sqlCom.Parameters.Add(Ans11);

        SqlParameter Ans12 = new SqlParameter();
        Ans12.SqlDbType = SqlDbType.VarChar;
        Ans12.Value = answer_12;
        Ans12.ParameterName = "@Answer_12";
        sqlCom.Parameters.Add(Ans12);

        SqlParameter Ans13 = new SqlParameter();
        Ans13.SqlDbType = SqlDbType.VarChar;
        Ans13.Value = answer_13;
        Ans13.ParameterName = "@Answer_13";
        sqlCom.Parameters.Add(Ans13);

        SqlParameter Ans14 = new SqlParameter();
        Ans14.SqlDbType = SqlDbType.VarChar;
        Ans14.Value = answer_14;
        Ans14.ParameterName = "@Answer_14";
        sqlCom.Parameters.Add(Ans14);

        SqlParameter Ans15 = new SqlParameter();
        Ans15.SqlDbType = SqlDbType.VarChar;
        Ans15.Value = answer_15;
        Ans15.ParameterName = "@Answer_15";
        sqlCom.Parameters.Add(Ans15);

        SqlParameter Qn_Score_01 = new SqlParameter();
        Qn_Score_01.SqlDbType = SqlDbType.VarChar;
        Qn_Score_01.Value = max_marks;
        Qn_Score_01.ParameterName = "@Qn_Score_01";
        sqlCom.Parameters.Add(Qn_Score_01);

        SqlParameter Ans21 = new SqlParameter();
        Ans21.SqlDbType = SqlDbType.VarChar;
        Ans21.Value = answer_21;
        Ans21.ParameterName = "@Answer_21";
        sqlCom.Parameters.Add(Ans21);

        SqlParameter Ans22 = new SqlParameter();
        Ans22.SqlDbType = SqlDbType.VarChar;
        Ans22.Value = answer_22;
        Ans22.ParameterName = "@Answer_22";
        sqlCom.Parameters.Add(Ans22);

        SqlParameter Ans23 = new SqlParameter();
        Ans23.SqlDbType = SqlDbType.VarChar;
        Ans23.Value = answer_23;
        Ans23.ParameterName = "@Answer_23";
        sqlCom.Parameters.Add(Ans23);

        SqlParameter Ans24 = new SqlParameter();
        Ans24.SqlDbType = SqlDbType.VarChar;
        Ans24.Value = answer_24;
        Ans24.ParameterName = "@Answer_24";
        sqlCom.Parameters.Add(Ans24);

        SqlParameter Qn_Score_02 = new SqlParameter();
        Qn_Score_02.SqlDbType = SqlDbType.VarChar;
        Qn_Score_02.Value = max_marks2;
        Qn_Score_02.ParameterName = "@Qn_Score_02";
        sqlCom.Parameters.Add(Qn_Score_02);

        SqlParameter Ans31 = new SqlParameter();
        Ans31.SqlDbType = SqlDbType.VarChar;
        Ans31.Value = answer_31;
        Ans31.ParameterName = "@Answer_31";
        sqlCom.Parameters.Add(Ans31);

        SqlParameter Ans32 = new SqlParameter();
        Ans32.SqlDbType = SqlDbType.VarChar;
        Ans32.Value = answer_32;
        Ans32.ParameterName = "@Answer_32";
        sqlCom.Parameters.Add(Ans32);

        SqlParameter Ans33 = new SqlParameter();
        Ans33.SqlDbType = SqlDbType.VarChar;
        Ans33.Value = answer_33;
        Ans33.ParameterName = "@Answer_33";
        sqlCom.Parameters.Add(Ans33);

        SqlParameter Ans34 = new SqlParameter();
        Ans34.SqlDbType = SqlDbType.VarChar;
        Ans34.Value = answer_34;
        Ans34.ParameterName = "@Answer_34";
        sqlCom.Parameters.Add(Ans34);

        SqlParameter Ans35 = new SqlParameter();
        Ans35.SqlDbType = SqlDbType.VarChar;
        Ans35.Value = answer_35;
        Ans35.ParameterName = "@Answer_35";
        sqlCom.Parameters.Add(Ans35);

        SqlParameter Qn_Score_03 = new SqlParameter();
        Qn_Score_03.SqlDbType = SqlDbType.VarChar;
        Qn_Score_03.Value = max_marks3;
        Qn_Score_03.ParameterName = "@Qn_Score_03";
        sqlCom.Parameters.Add(Qn_Score_03);

        SqlParameter Ans41 = new SqlParameter();
        Ans41.SqlDbType = SqlDbType.VarChar;
        Ans41.Value = answer_41;
        Ans41.ParameterName = "@Answer_41";
        sqlCom.Parameters.Add(Ans41);

        SqlParameter Ans42 = new SqlParameter();
        Ans42.SqlDbType = SqlDbType.VarChar;
        Ans42.Value = answer_42;
        Ans42.ParameterName = "@Answer_42";
        sqlCom.Parameters.Add(Ans42);

        SqlParameter Ans43 = new SqlParameter();
        Ans43.SqlDbType = SqlDbType.VarChar;
        Ans43.Value = answer_43;
        Ans43.ParameterName = "@Answer_43";
        sqlCom.Parameters.Add(Ans43);

        SqlParameter Ans44 = new SqlParameter();
        Ans44.SqlDbType = SqlDbType.VarChar;
        Ans44.Value = answer_44;
        Ans44.ParameterName = "@Answer_44";
        sqlCom.Parameters.Add(Ans44);

        SqlParameter Ans45 = new SqlParameter();
        Ans45.SqlDbType = SqlDbType.VarChar;
        Ans45.Value = answer_45;
        Ans45.ParameterName = "@Answer_45";
        sqlCom.Parameters.Add(Ans45);

        SqlParameter Qn_Score_04 = new SqlParameter();
        Qn_Score_04.SqlDbType = SqlDbType.VarChar;
        Qn_Score_04.Value = max_marks4;
        Qn_Score_04.ParameterName = "@Qn_Score_04";
        sqlCom.Parameters.Add(Qn_Score_04);


        SqlParameter Ans51 = new SqlParameter();
        Ans51.SqlDbType = SqlDbType.VarChar;
        Ans51.Value = answer_51;
        Ans51.ParameterName = "@Answer_51";
        sqlCom.Parameters.Add(Ans51);

        SqlParameter Ans52 = new SqlParameter();
        Ans52.SqlDbType = SqlDbType.VarChar;
        Ans52.Value = answer_52;
        Ans52.ParameterName = "@Answer_52";
        sqlCom.Parameters.Add(Ans52);

        SqlParameter Ans53 = new SqlParameter();
        Ans53.SqlDbType = SqlDbType.VarChar;
        Ans53.Value = answer_53;
        Ans53.ParameterName = "@Answer_53";
        sqlCom.Parameters.Add(Ans53);

        SqlParameter Ans54 = new SqlParameter();
        Ans54.SqlDbType = SqlDbType.VarChar;
        Ans54.Value = answer_54;
        Ans54.ParameterName = "@Answer_54";
        sqlCom.Parameters.Add(Ans54);

        SqlParameter Qn_Score_05 = new SqlParameter();
        Qn_Score_05.SqlDbType = SqlDbType.VarChar;
        Qn_Score_05.Value = max_marks5;
        Qn_Score_05.ParameterName = "@Qn_Score_05";
        sqlCom.Parameters.Add(Qn_Score_05);

        SqlParameter CustomerId = new SqlParameter();
        CustomerId.SqlDbType = SqlDbType.VarChar;
        CustomerId.ParameterName = "@CustomerID";
        CustomerId.Value = hfCustomerId.Value;
        sqlCom.Parameters.Add(CustomerId);



        int result = sqlCom.ExecuteNonQuery();


        sqlCon.Close();


        if (result > 0)
        {
            lblMsg.Visible = true;
            lblMsg.Text = "Thank You - Response Accepted";

            SendMail(hfCustomerId.Value);

            BindCustomerDetails();

            Response.Write("<script type=\"text/javascript\">window.close();</script>");

            //window.close();
            //this.ClientScript.RegisterClientScriptBlock(this.GetType(), "Close", "window.close()", true);
        }
        else
        {
            lblMsg.Visible = true;
            lblMsg.Text = "Error";
        }
    }
    protected void SendMail(string CustomerId)
    {
        string email = hfemailId.Value;
        string ContactName = lblCleintRepresentative.Text;

        try
        {


            string MailTo = email;

            //string MailCC = "ramakrishnan.v@pamac.com";


            //string filename = "PAMAC CFS Format for Offline Feedback";


            //string fileDirectory = Server.MapPath("~/Pages/CFS/UploadFile/");

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
            mail.Subject = "PAMAC Customer Survey Report - Response";
            mail.From = new MailAddress("csat@pamac.com");

            mail.To.Add(MailTo.TrimEnd(','));
           // mail.CC.Add(MailCC.TrimEnd(','));

            mail.Body = "<p>Dear " + ContactName + ",</p><br/><p>We thank you for your response to our questionnaire." + '\n' +
                         "We will take your feed back to improve our services.<p/> " +
                          "<br />  <br />  <br />  PAMAC Finserve Pvt.Ltd <br />  Management Team <br />  Mumbai – Head Office";




            mail.IsBodyHtml = true;

            //    mail.Attachments.Add(new Attachment(@"C:\Users\dell\Desktop\CFS\NANO-PRO-App_Csharp_Calculus(08May2016)\Pages\CFS\UploadFile\" + "\\" + filename));
            SmtpClient smtp = new SmtpClient("mail.pamac.com", 587);
            smtp.Credentials = new System.Net.NetworkCredential("csat@pamac.com", "#14zfr@693");
            smtp.EnableSsl = false;
            smtp.Send(mail);
        }
        catch (Exception ex)
        {
            string logsDirectory = Path.Combine(Environment.CurrentDirectory, "ErrorLog\\ErrorLog.txt");

            using (StreamWriter writer = new StreamWriter(logsDirectory, true))
            {
                writer.WriteLine("Message :" + ex.Message + "<br/>" + Environment.NewLine + "StackTrace :" + ex.StackTrace +
                   "" + Environment.NewLine + "Date :" + DateTime.Now.ToString());
                writer.WriteLine(Environment.NewLine + "-----------------------------------------------------------------------------" + Environment.NewLine);
            }
        }

    }
    protected void rbtnNo_CheckedChanged(object sender, EventArgs e)
    {
        if (rbtnNo.Checked == true)
        {
            ddlAnw.Visible = true;
        }
        else
        {
            ddlAnw.Visible = false;
        }
    }

    protected void rbtnYes_CheckedChanged(object sender, EventArgs e)
    {
        if (rbtnYes.Checked == true)
        {
            ddlAnw.Visible = false;
        }
        else
        {
            ddlAnw.Visible = true;
        }
    }

    protected void rbtnYes2_CheckedChanged(object sender, EventArgs e)
    {
        if (rbtnYes2.Checked == true)
        {
            ddlAnw2.Visible = false;
        }
        else
        {
            ddlAnw2.Visible = true;
        }
    }

    protected void rbtnNo2_CheckedChanged(object sender, EventArgs e)
    {
        if (rbtnNo2.Checked == true)
        {
            ddlAnw2.Visible = true;
        }
        else
        {
            ddlAnw2.Visible = false;
        }
    }

    protected void rbtnYes3_CheckedChanged(object sender, EventArgs e)
    {
        if (rbtnYes3.Checked == true)
        {
            ddlAnw3.Visible = false;
        }
        else
        {
            ddlAnw3.Visible = true;
        }
    }

    protected void rbtnNo3_CheckedChanged(object sender, EventArgs e)
    {
        if (rbtnNo3.Checked == true)
        {
            ddlAnw3.Visible = true;
        }
        else
        {
            ddlAnw3.Visible = false;
        }
    }

    protected void rbtnYes4_CheckedChanged(object sender, EventArgs e)
    {
        if (rbtnYes4.Checked == true)
        {
            ddlAnw4.Visible = false;
        }
        else
        {
            ddlAnw4.Visible = true;
        }
    }

    protected void rbtnNo4_CheckedChanged(object sender, EventArgs e)
    {
        if (rbtnNo4.Checked == true)
        {
            ddlAnw4.Visible = true;
        }
        else
        {
            ddlAnw4.Visible = false;
        }
    }
    protected void BindCustomerDetails()
    {
        SqlConnection sqlCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);

        
        SqlCommand sqlCom = new SqlCommand();
        sqlCom.Connection = sqlCon;
        sqlCom.CommandType = CommandType.StoredProcedure;
        sqlCom.CommandText = "CFS_GetCustomerNameForSurvey_SP";
        SqlDataAdapter sqlDA = new SqlDataAdapter();
        sqlDA.SelectCommand = sqlCom;


        SqlDataAdapter adp = new SqlDataAdapter(sqlCom);
        DataSet ds = new DataSet();
        adp.Fill(ds);

        if (ds != null)
        {
            ddlCustomerList.DataTextField = "Name";
            ddlCustomerList.DataValueField = "CustomerID";
            ddlCustomerList.DataSource = ds;
            ddlCustomerList.DataBind();
            ddlCustomerList.Items.Insert(0, "--Select--");
        }
    }

    protected void ddlCustomerList_SelectedIndexChanged(object sender, EventArgs e)
    {
        string CustomerId = ddlCustomerList.SelectedValue;

        hfCustomerId.Value = ddlCustomerList.SelectedValue;
        BindCustomers(CustomerId);
        btnsubmit.Visible = true;
        btnCalcel.Visible = true;
    }

    protected void btnCalcel_Click(object sender, EventArgs e)
    {
        Response.Redirect("CFS.aspx", true);
    }
}