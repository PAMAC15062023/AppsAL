using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data.OleDb;
using System.IO;
using System.Data;
using System.Configuration;
using System.Net.Mail;
using System.Threading;
using System.Text;

public partial class Pages_Calculus_ImportTransaction : System.Web.UI.Page
{
    string strlos = string.Empty;
    string strlos1 = string.Empty;
    string smsg = string.Empty;
    int count = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindTransactionType();
        }
    }

    protected void BindTransactionType()
    {
        Common common = new Common();
        DataSet ds = new DataSet();

        ds = common.GetCalOnlineTransMasterSearchCode("TransnType", 1);
        if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            ddlTranstype.DataSource = ds;
            ddlTranstype.DataValueField = "Code_Id";
            ddlTranstype.DataTextField = "Description";
            ddlTranstype.DataBind();
            ddlTranstype.Items.Insert(0, new ListItem("--Select--", "0"));
        }
    }
    protected void btnupload_Click(object sender, EventArgs e)
    {
        try
        {
            if (xslFileUpload.HasFile)
            {
                String strPath = "";
                String MyFile = "";
                string strDateTime = DateTime.Now.ToString("ddMMyyyyhhmmss");

                strPath = Server.MapPath("~/Pages/Calculus/IMPORT/");
                MyFile = strDateTime + ".xls";
                strPath = (strPath + MyFile);
                xslFileUpload.PostedFile.SaveAs(strPath);

                string strFileName = xslFileUpload.FileName.ToString();

                FileInfo fi = new FileInfo(strFileName);
                string strExt = fi.Extension;

                if (strExt.ToLower() == ".xls")
                {
                    string strConn = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + strPath + @";Extended Properties=""Excel 8.0;IMEX=1""";

                    OleDbConnection oleCon = new OleDbConnection(strConn);
                    oleCon.Open();

                    OleDbCommand oleCom = new OleDbCommand("SELECT * FROM [sheet1$]");
                    oleCom.Connection = oleCon;

                    OleDbDataAdapter oleDA = new OleDbDataAdapter();
                    oleDA.SelectCommand = oleCom;

                    DataTable dt = new DataTable();
                    oleDA.Fill(dt);
                    oleCon.Close();

                    if (dt.Rows.Count > 0)
                    {
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            if (ddlTranstype.SelectedItem.Value != "0")
                            {
                                Update_Into_MainCaseDetails(dt.Rows[i]);
                            }
                            else
                            {
                                lblMsgXls.Text = "Select Transaction Type....!!";
                                return;
                            }

                        }
                        if (strlos1 != "")
                        {
                            lblMsgXls.Text += "Following Transaction ID Status have not been Accepted :-" + " " + strlos1;
                        }

                        lblMsgXls1.Text += "IMPORTED Count" + " " + smsg;
                        //lblMsgXls.Text = "Data Import Successfully!!";

                    }

                    string strFile = Server.MapPath("~/Pages/Calculus/IMPORT/") + MyFile;
                    if (File.Exists(strFile))
                    {
                        File.Delete(strFile);
                    }
                }
                else
                {
                    lblMsgXls.Visible = true;
                    lblMsgXls.Text = "It's Not An Excel File...!!!";
                }
            }
            else
            {
                lblMsgXls.Visible = true;
                lblMsgXls.Text = "Please Select Excel File To Import...!!!";
            }
        }
        catch (Exception ex)
        {
            lblMsgXls.Visible = true;
            lblMsgXls.Text = "Error :" + ex.Message;
        }

    }

    public string strDate(string strInDate)
    {
        string strDD = strInDate.Substring(0, 2);

        string strMM = strInDate.Substring(3, 2);

        string strYYYY = strInDate.Substring(6, 4);

        string strhh = strInDate.Substring(11, 2);

        string strmmm = strInDate.Substring(14, 2);

        string strss = strInDate.Substring(17, 2);

        string strMMDDYYYY = strMM + "/" + strDD + "/" + strYYYY + " " + strhh + ":" + strmmm + ":" + strss;

        DateTime dtConvertDate = Convert.ToDateTime(strMMDDYYYY);

        string strOutDate = dtConvertDate.ToString("dd-MMM-yyyy HH:mm:ss");

        return strOutDate;
    }
    protected void Update_Into_MainCaseDetails(DataRow dr)
    {
        Object SaveUSERInfo = (Object)Session["UserInfo"];

        SqlConnection sqlCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);
        try
        {

            string trnid = dr["TransactionID"].ToString().Trim();

            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlCon;
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.CommandText = "CalOnlineTrans_PayedNEFTNew_SP";
            sqlcmd.CommandTimeout = 0;

            SqlParameter Transaction_Id = new SqlParameter();
            Transaction_Id.SqlDbType = SqlDbType.VarChar;
            Transaction_Id.Value = trnid;
            Transaction_Id.ParameterName = "@transactionid";
            sqlcmd.Parameters.Add(Transaction_Id);

            SqlParameter PaymentStatusID = new SqlParameter();
            PaymentStatusID.SqlDbType = SqlDbType.VarChar;
            PaymentStatusID.Value = dr["PaymentStatusID"].ToString().Trim();
            PaymentStatusID.ParameterName = "@PaymentStatusID";
            sqlcmd.Parameters.Add(PaymentStatusID);

            SqlParameter Amount = new SqlParameter();
            Amount.SqlDbType = SqlDbType.VarChar;
            Amount.Value = dr["Amount"].ToString().Trim();
            Amount.ParameterName = "@NEFTAmount";
            sqlcmd.Parameters.Add(Amount);



            //added by abhijeet 11/01/2019/////////////


            SqlParameter transferdate = new SqlParameter();
            transferdate.SqlDbType = SqlDbType.VarChar;
            transferdate.Value = dr["TransferDate"].ToString().Trim();
            transferdate.ParameterName = "@import_date";
            sqlcmd.Parameters.Add(transferdate);





            ///////ended by abhijeet ///////////

            SqlParameter TransType = new SqlParameter();
            TransType.SqlDbType = SqlDbType.VarChar;
            TransType.Value = ddlTranstype.SelectedItem.Value;
            TransType.ParameterName = "@TransType";
            sqlcmd.Parameters.Add(TransType);

            sqlCon.Open();
            int RowEffected = 0;

            RowEffected = sqlcmd.ExecuteNonQuery();
            sqlCon.Close();

            if (RowEffected > 0)
            {
                lblMsgXls.Visible = true;
                count++;
                smsg = Convert.ToString(count);
                //get_payeename(trnid);
                //Email(trnid);
            }
            else
            {
                SqlCommand sqlCom = new SqlCommand();
                sqlCom.Connection = sqlCon;
                sqlCom.CommandType = CommandType.StoredProcedure;
                sqlCom.CommandText = "CalOnlineTrans_Check_Transaction_ID__SP";
                sqlCom.CommandTimeout = 0;

                SqlParameter BranchId = new SqlParameter();
                BranchId.SqlDbType = SqlDbType.VarChar;
                BranchId.Value = dr["TransactionID"].ToString().Trim();
                BranchId.ParameterName = "@transactionid";
                sqlCom.Parameters.Add(BranchId);

                sqlCon.Open();

                SqlDataAdapter sqlDA = new SqlDataAdapter();
                sqlDA.SelectCommand = sqlCom;

                DataTable dt = new DataTable();
                sqlDA.Fill(dt);
                sqlCon.Close();

                if (dt.Rows.Count > 0)
                {
                    strlos1 += dr["TransactionID"].ToString().Trim() + " --  ";
                }
                else
                {
                    //strlos += dr["TransactionID"].ToString().Trim() + " --  ";
                }

            }
        }
        catch (Exception ex)
        {
            lblMsgXls.Visible = true;
            lblMsgXls.Text = "Error :" + ex.Message;
        }
        finally
        {
            sqlCon.Close();
            sqlCon.Dispose();
        }
    }

    //protected void Update_Into_MainCaseDetails(DataRow dr)
    //{
    //    Object SaveUSERInfo = (Object)Session["UserInfo"];

    //    SqlConnection sqlCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);

    //    string trnid = dr["TransactionID"].ToString().Trim();

    //    SqlCommand sqlcmd = new SqlCommand();
    //    sqlcmd.Connection = sqlCon;
    //    sqlcmd.CommandType = CommandType.StoredProcedure;
    //    sqlcmd.CommandText = "sp_payed_NEFT_New";
    //    sqlcmd.CommandTimeout = 0;

    //    SqlParameter Transaction_Id = new SqlParameter();
    //    Transaction_Id.SqlDbType = SqlDbType.VarChar;
    //    Transaction_Id.Value = trnid;
    //    Transaction_Id.ParameterName = "@transactionid";
    //    sqlcmd.Parameters.Add(Transaction_Id);

    //    SqlParameter PaymentStatusID = new SqlParameter();
    //    PaymentStatusID.SqlDbType = SqlDbType.VarChar;
    //    PaymentStatusID.Value = dr["PaymentStatusID"].ToString().Trim();
    //    PaymentStatusID.ParameterName = "@PaymentStatusID";
    //    sqlcmd.Parameters.Add(PaymentStatusID);

    //    SqlParameter Amount = new SqlParameter();
    //    Amount.SqlDbType = SqlDbType.VarChar;
    //    Amount.Value = dr["Amount"].ToString().Trim();
    //    Amount.ParameterName = "@NEFTAmount";
    //    sqlcmd.Parameters.Add(Amount);

    //    SqlParameter TransType = new SqlParameter();
    //    TransType.SqlDbType = SqlDbType.VarChar;
    //    TransType.Value = ddlTranstype.SelectedItem.Value;
    //    TransType.ParameterName = "@TransType";
    //    sqlcmd.Parameters.Add(TransType);

        
    //    sqlCon.Open();
    //    int RowEffected = 0;

    //    RowEffected = sqlcmd.ExecuteNonQuery();

    //    if (RowEffected > 0)
    //    {
    //        get_payeename(trnid);
    //        Email(trnid);
    //    }

    //    sqlCon.Close();
    //}

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Pages/menu.aspx", true);
    }

    private void Email(string trnid)
    {

        Object SaveUSERInfo = (Object)Session["UserInfo"];

        SqlConnection sqlCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);

        SqlCommand sqlcmd = new SqlCommand();
        sqlcmd.Connection = sqlCon;
        sqlcmd.CommandType = CommandType.StoredProcedure;
        sqlcmd.CommandText = "CalOnlineTrans_Get_MailId_SP";
        sqlcmd.CommandTimeout = 0;

        SqlParameter Transaction_Id = new SqlParameter();
        Transaction_Id.SqlDbType = SqlDbType.VarChar;
        Transaction_Id.Value = trnid;
        Transaction_Id.ParameterName = "@transactionid";
        sqlcmd.Parameters.Add(Transaction_Id);

        SqlDataAdapter da = new SqlDataAdapter();
        da.SelectCommand = sqlcmd;

        DataTable dt = new DataTable();
        da.Fill(dt);

        //string Emailid = "software.support@pamac.com";
        //string CCEmailid = "edp@pamac.com";
        string Emailid = dt.Rows[0]["email_id"].ToString();
        string CCEmailid = dt.Rows[0]["CC_email_id"].ToString();

        string Emailidrr = "rupesh.zodage@pamac.com";

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
            mail.CC.Add(Emailidrr);

            mail.Subject = "PAMAC Accounts : Vendor Payment Confirmation!!! ";

            string strBody =
                    "<html><body><font color=\"Navy\"><P>=====================================================================================================================</P>" +

                    "<P>                                                                                               </P>" +
                    " <P>Hi PAMACian,</P>" +
                    "<P>                                                                                         </P>" +
                    "<P>This is an automated response to update you that following  Transaction  " + trnid + " request raised  Against " +HiddenField1.Value+ " vender in the PAMAC Calculus has got processed successfully.</P>" +
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
            lblMsgXls.Text = "Email Successfully Sent.";

        }

        catch (Exception ex)
        {
            lblMsgXls.Text = "Email Failed." + ex.Message;
        }


    }

    public void get_payeename( string tranid)
    {
        Object SaveUSERInfo = (Object)Session["UserInfo"];
        SqlConnection sqlCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);

        SqlCommand sqlCom = new SqlCommand();
        sqlCom.Connection = sqlCon;
        sqlCom.CommandType = CommandType.StoredProcedure;
        sqlCom.CommandText = "CalOnlineTrans_GetPayeeName_SP";
        sqlCom.CommandTimeout = 0;


        SqlParameter losno = new SqlParameter();
        losno.SqlDbType = SqlDbType.NVarChar;
        losno.Value = tranid;
        losno.ParameterName = "@transactionid";
        sqlCom.Parameters.Add(losno);

        sqlCon.Open();

        SqlDataAdapter sqlDA = new SqlDataAdapter();
        sqlDA.SelectCommand = sqlCom;

        DataTable dt = new DataTable();
        sqlDA.Fill(dt);

        sqlCon.Close();

        if (dt.Rows.Count > 0)
        {

            HiddenField1.Value = dt.Rows[0]["payee_name"].ToString();
            
        }
        else
        {
            HiddenField1.Value = null;
            
        }

    }


    protected void btnSample_Click1(object sender, EventArgs e)
    {
        string filename = "Import_Transaction.xls";
        Response.ContentType = "application/octect-stream";
        Response.AppendHeader("Content-Disposition", "attachment;filename=" + filename);
        Response.TransmitFile(Server.MapPath("~/Pages/Calculus/files/" + filename));
        Response.End();
    }
}

   