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
using System.Net.Mail;

public partial class Pages_Helpdesk_TicketStatus : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserInfo"] == null)
        {
            Response.Redirect("~/Pages/InvalidRequest.aspx");

        }

        if (!IsPostBack)
        {
            if (Request.QueryString["Tk"] != null)
            {
               
                Get_HeaderDetails(Request.QueryString["Tk"].ToString().Trim());
                GetemailId();
               // Register_Controls();
            }
        }
    }
    private void Get_HeaderDetails(string pTicketNo)
    {
        //Get_SupportEngineerList();// assignment by dropdownlist bound cooment this
        lblTicketNo.Text = pTicketNo;
        Get_TicketStatusInfo(lblTicketNo.Text.Trim());
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        Insert_Update_TicketStatus(lblTicketNo.Text.Trim());
      
        Get_HeaderDetails(Request.QueryString["Tk"].ToString().Trim());
        Clear_Controls();
    }

    public void GetemailId()
    {
        try
        {
            SqlConnection sqlCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);

            sqlCon.Open();
            SqlCommand sqlCom = new SqlCommand();
            sqlCom.Connection = sqlCon;
            sqlCom.CommandType = CommandType.StoredProcedure;
            sqlCom.CommandText = "deptId_new";
            

            SqlParameter deptid = new SqlParameter();
            deptid.SqlDbType = SqlDbType.VarChar;
            deptid.Value = lblDepartment.Text;
            deptid.ParameterName = "@department";
            sqlCom.Parameters.Add(deptid);

            SqlDataAdapter sqlDA = new SqlDataAdapter();
            sqlDA.SelectCommand = sqlCom;
            SqlDataReader dr = sqlCom.ExecuteReader();
            if (dr.Read())
            {
                HiddenField1.Value = dr["Dept_MailId"].ToString();

            }
            //DataSet ds = new DataSet();
           // DataTable ds=new DataTable();
            //sqlDA.Fill(ds);

            //DataList1.Visible = false;
            //DataList2.DataSource = ds;
            //DataList2.DataBind();
           
            sqlCon.Close();
        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
        }

    
    }




    private void Email()
    {

        Object SaveUSERInfo = (Object)Session["UserInfo"];

        SqlConnection sqlCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);

        SqlCommand sqlcmd = new SqlCommand();
        sqlcmd.Connection = sqlCon;
        sqlcmd.CommandType = CommandType.StoredProcedure;
        sqlcmd.CommandText = "mailid_new";
        sqlcmd.CommandTimeout = 0;

        SqlParameter Transaction_Id = new SqlParameter();
        Transaction_Id.SqlDbType = SqlDbType.VarChar;
        Transaction_Id.Value = HiddenField2.Value;
        Transaction_Id.ParameterName = "@TicketNo";
        sqlcmd.Parameters.Add(Transaction_Id);

        SqlDataAdapter da = new SqlDataAdapter();
        da.SelectCommand = sqlcmd;

        DataTable dt = new DataTable();
        da.Fill(dt);

        //string Emailid = "software.support@pamac.com";
        //string CCEmailid = "edp@pamac.com";
        string Emailid = dt.Rows[0]["clientemail"].ToString();
        string CCEmailid = HiddenField1.Value;

        //string Emailidrr = "rupesh.zodage@pamac.com";

        string strTime = System.DateTime.Now.TimeOfDay.ToString().Remove(5);
        string strhh = strTime.Remove(2);
        string strmm = strTime.Remove(0, 3);

        string Current = System.DateTime.Now.Date.ToString().Remove(10);

        try
        {
            MailMessage mail = new MailMessage();
            SmtpClient smtp = new SmtpClient("103.13.99.137", 25);

            mail.From = new MailAddress("calculus@pamac.com", "PAMAC Account"); //you have to provide your gmail address as from addres

            mail.To.Add(Emailid);
            mail.CC.Add(CCEmailid);
            // mail.CC.Add(Emailidrr);

            mail.Subject = "PAMAC Accounts :helpdesk confirmation!!! ";

            string strBody =
                    "<html><body><font color=\"Navy\"><P>=====================================================================================================================</P>" +

                    "<P>                                                                                               </P>" +
                    " <P>Hi PAMACian,</P>" +
                    "<P>                                                                                         </P>" +
                    "<P>This is an automated response to update you that following  Transaction  " + HiddenField2.Value + " request raised  Against " + HiddenField1.Value + " vender in the PAMAC Calculus has got processed successfully.</P>" +
                    "<P>                                                                                         </P>" +
                    " <P>Please make note of the same and get in touch with  Accounts if payment not received.</P>" +
                    "<P>                                                                                        </P>" +
                    "<P>“This is computer generated mail and hence do not reply to this mail”  </P>" +
                    "<P>                                                                                         </P>" +
                    "<P>Regards,</P>" +
                    "<P>PAMAC Calculus Helpdesk</P> " +

               "<P>=====================================================================================================================</P></font></html></body>";

            mail.Body = strBody;

            mail.IsBodyHtml = true;

            smtp.Port = 25;
            smtp.Credentials = new System.Net.NetworkCredential("calculus@pamac.com", "pamac@123");  //you have to provide you gamil username and password
            smtp.EnableSsl = false;/// Main line :SSL should be false

            smtp.Send(mail);
            lblMessage.Text = "Email Successfully Sent.";

        }

        catch (Exception ex)
        {
            lblMessage.Text = "Email Failed." + ex.Message;
        }


    }

         
    private void Get_TicketStatusInfo(string pTicketNo)
    {
        try
        {
            SqlConnection sqlCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);

            sqlCon.Open();
            SqlCommand sqlCom = new SqlCommand();
            sqlCom.Connection = sqlCon;
            sqlCom.CommandType = CommandType.StoredProcedure;
            //sqlCom.CommandText = "Get_TicketStatusInfo";
            sqlCom.CommandText = "Get_TicketStatusInfo_new";

            SqlDataAdapter sqlDA = new SqlDataAdapter();
            sqlDA.SelectCommand = sqlCom;

            SqlParameter TicketNo = new SqlParameter();
            TicketNo.SqlDbType = SqlDbType.VarChar;
            TicketNo.Value = pTicketNo.Trim();
            TicketNo.ParameterName = "@TicketNo";
            sqlCom.Parameters.Add(TicketNo);

           

            DataSet ds = new DataSet();
            sqlDA.Fill(ds);
            sqlCon.Close();


            AssignHeaderValues(ds.Tables[0]); 

            if (ds.Tables.Count == 2)
            {
                DataList1.DataSource = ds.Tables[1];
                DataList1.DataBind();
                
            }
        }
        catch (Exception ex)
        {
            lblMessage.Visible = true;
            lblMessage.Text = ex.Message;
            lblMessage.CssClass = "ErrorMessage";
        }
    }
    private void AssignHeaderValues(DataTable dt)
    {

        lblTicketRaiseDate.Text = dt.Rows[0]["RequestDate"].ToString();
        lblBranch.Text = dt.Rows[0]["BranchName"].ToString();
        lblDepartment.Text = dt.Rows[0]["Department"].ToString();
        Label1.Text = dt.Rows[0]["vender_name"].ToString();
        Label2.Text = dt.Rows[0]["vender_prob_provider"].ToString();
        Label3.Text = dt.Rows[0]["vender_services"].ToString();
        lblRemark.Text = dt.Rows[0]["Remark"].ToString();
        
        lblUserName.Text = dt.Rows[0]["UserName"].ToString();
        ddlTicketStatus.SelectedValue = dt.Rows[0]["TicketStatus"].ToString();
        lblTicketStatus.Text = dt.Rows[0]["TicketStatus"].ToString().Trim();

        if (lblTicketStatus.Text.Trim() == "Close")
        {
            btnSave.Visible= false;
        }
        //ddlAssignedTo.SelectedValue = dt.Rows[0]["AssignedTo"].ToString();
    }
    private void Insert_Update_TicketStatus(string pTicketNo)
    {
        try
        {
            Object SaveUSERInfo = (Object)Session["UserInfo"];

            SqlConnection sqlCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);

            sqlCon.Open();
            SqlCommand sqlCom = new SqlCommand();
            sqlCom.Connection = sqlCon;
            sqlCom.CommandType = CommandType.StoredProcedure;
            //sqlCom.CommandText = "Insert_Update_TicketStatus";
            sqlCom.CommandText = "Insert_Update_TicketStatus_new";
            SqlDataAdapter sqlDA = new SqlDataAdapter();
            sqlDA.SelectCommand = sqlCom;

            SqlParameter BranchID = new SqlParameter();
            BranchID.SqlDbType = SqlDbType.Int;
            BranchID.Value = Convert.ToInt32(((UserInfo.structUSERInfo)(SaveUSERInfo)).BranchId);
            BranchID.ParameterName = "@BranchID";
            sqlCom.Parameters.Add(BranchID);

            SqlParameter TicketNo = new SqlParameter();
            TicketNo.SqlDbType = SqlDbType.VarChar;
            TicketNo.Value = lblTicketNo.Text.Trim();
            TicketNo.ParameterName = "@TicketNo";
            sqlCom.Parameters.Add(TicketNo);

            SqlParameter username = new SqlParameter();
            username.SqlDbType = SqlDbType.VarChar;
            username.Value = lblUserName.Text.Trim();
            username.ParameterName = "@username";
            sqlCom.Parameters.Add(username);

            HiddenField2.Value = lblTicketNo.Text.Trim();

            //SqlParameter AssignedBy = new SqlParameter();
            //AssignedBy.SqlDbType = SqlDbType.VarChar;
            //AssignedBy.Value = Convert.ToString(((UserInfo.structUSERInfo)(SaveUSERInfo)).UserId);
            //AssignedBy.ParameterName = "@AssignedBy";
            //sqlCom.Parameters.Add(AssignedBy);

            //SqlParameter AssignedTo = new SqlParameter();
            //AssignedTo.SqlDbType = SqlDbType.VarChar;
            //AssignedTo.Value =Convert.ToString(ddlAssignedTo.SelectedItem.Value);
            //AssignedTo.ParameterName = "@AssignedTo";
            //sqlCom.Parameters.Add(AssignedTo);


            SqlParameter TicketStatus = new SqlParameter();
            TicketStatus.SqlDbType = SqlDbType.VarChar;
            TicketStatus.Value = Convert.ToString(ddlTicketStatus.SelectedItem.Value);
            TicketStatus.ParameterName = "@TicketStatus";
            sqlCom.Parameters.Add(TicketStatus);

            SqlParameter UpdateStatus = new SqlParameter();
            UpdateStatus.SqlDbType = SqlDbType.VarChar;
            UpdateStatus.Value = txtUpdateRemark.Text.Trim();
            UpdateStatus.ParameterName = "@UpdateStatus";
            sqlCom.Parameters.Add(UpdateStatus);

            SqlParameter TicketType = new SqlParameter();
            TicketType.SqlDbType = SqlDbType.VarChar;
            TicketType.Value = ddlTicketType.SelectedItem.ToString();
            TicketType.ParameterName = "@TicketType";
            sqlCom.Parameters.Add(TicketType);

            SqlParameter VarResult = new SqlParameter();
            VarResult.SqlDbType = SqlDbType.VarChar;
            VarResult.Value = lblTicketNo.Text.Trim();
            VarResult.ParameterName = "@VarResult";
            VarResult.Size = 200;
            VarResult.Direction = ParameterDirection.Output;
            sqlCom.Parameters.Add(VarResult);

            //changed by sanket
            //string strPriority = "";
            //if (ddlPriority.SelectedIndex != 0)
            //{
            //    strPriority = ddlPriority.SelectedItem.Value;
            //}

            SqlParameter Priority = new SqlParameter();
            Priority.SqlDbType = SqlDbType.VarChar;
            Priority.Value = ddlPriority.SelectedItem.ToString();
            Priority.ParameterName = "@Priority";
            sqlCom.Parameters.Add(Priority);
            //changes end by sanket

            sqlCom.ExecuteNonQuery();
            string RowEffected = Convert.ToString(sqlCom.Parameters["@VarResult"].Value);

            sqlCon.Close();

            if (RowEffected != "")
            {
                lblMessage.Text = RowEffected;
                lblMessage.CssClass = "SuccessMessage";
              
                lblTicketNo.Text = RowEffected;
            }

            Email();
        }
        catch (Exception ex)
        {
            lblMessage.Visible = true;
            lblMessage.Text = ex.Message;
            lblMessage.CssClass = "ErrorMessage";
        }
    }
    //private void Get_SupportEngineerList() //comment this part
    //{
    //    try
    //    {

    //        SqlConnection sqlCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);

    //        sqlCon.Open();
    //        SqlCommand sqlCom = new SqlCommand();
    //        sqlCom.Connection = sqlCon;
    //        sqlCom.CommandType = CommandType.StoredProcedure;
    //        sqlCom.CommandText = "Get_SupportEngineerList";
    //        SqlDataAdapter sqlDA = new SqlDataAdapter();
    //        sqlDA.SelectCommand = sqlCom;  
             

    //        DataTable dt = new DataTable();
    //        sqlDA.Fill(dt);
    //        sqlCon.Close();

    //        ddlAssignedTo.DataTextField = "UserName";
    //        ddlAssignedTo.DataValueField = "UserID";
    //        ddlAssignedTo.DataSource = dt;
    //        ddlAssignedTo.DataBind();

    //        ddlAssignedTo.Items.Insert(0, "--Select--");
    //        ddlAssignedTo.SelectedIndex = 0;



    //    }
    //    catch (Exception ex)
    //    {
    //        lblMessage.Visible = true;
    //        lblMessage.Text = ex.Message;
    //        lblMessage.CssClass = "ErrorMessage";
    //    }
    //}
    private void Clear_Controls()
    {
        txtUpdateRemark.Text = "";
       // ddlAssignedTo.SelectedIndex = 0;
        ddlTicketStatus.SelectedIndex = 0;
        
            
    }
    //private void Register_Controls()
    //{
    //    btnSave.Attributes.Add("onclick", "javascript:return Validate_UpdateStatus();");
    //}
    protected void btnClose_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Pages/Helpdesk/TicketAssignment.aspx",true);
    }
  
}
