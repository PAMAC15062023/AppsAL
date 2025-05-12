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
using System.Web.Mail;
using System.Drawing;
using System.Data.SqlClient;

public partial class Login : System.Web.UI.Page
{
    int Flag;
    int failedAttempts;
    protected void Page_Load(object sender, EventArgs e)
    {
        //Response.Expires = 0;
        Response.CacheControl = "no-cache";
        Session.Clear();
        lblMsg.Text = "";
        txtUserName.Focus();
        //Session.Abandon();
        if (Request.QueryString["Message"] == null)
        {
            if (Request.QueryString["HelpId"] == null)
            {

            }
            else
            {
                //string HelpId = Request.QueryString["HelpId"].ToString();
                //switch (HelpId)
                //{
                //    case "1":
                //        pnlHelpDesk.Visible = false;
                //        pnlHelpForgot.Visible = false;
                //        pnlHelpUsing.Visible = true;
                //        break;
                //    case "2":
                //        pnlHelpDesk.Visible = false;
                //        pnlHelpForgot.Visible = true;
                //        pnlHelpUsing.Visible = false;
                //        break;
                //    case "3":
                //        pnlHelpDesk.Visible = true;
                //        pnlHelpForgot.Visible = false;
                //        pnlHelpUsing.Visible = false;
                //        break;
                //}
            }
        }
        else
            lblMsg.Text = Request.QueryString["Message"].ToString();
    }
    protected void Session_Start(Object sender, EventArgs e)
    {
        // Session.Timeout = 30000;
    }
    protected void btnLogin_Click(object sender, EventArgs e)
    {
        try
        {
            bool isValid = captcha1.Validate(txtCaptcha.Text.Trim());
            if (isValid)
            {

                //method
                Flag = 2;
                Check_Login_Attempt(); //add on 27/01/2025

                //failedAttempts = Convert.ToInt32(dt.Rows[0]["FailedLoginAttempts"]); //add on 24/01/2025
                if (failedAttempts < 3)
                {


                    CLogin objLogin = new CLogin();
                    objLogin.UserName = txtUserName.Text;
                    objLogin.Password = txtPassword.Text;
                    objLogin.CentreId = ddlCenter.SelectedValue;
                    String strAuthenticated = objLogin.UserAuthenticate();
                    //int caseSwitch = (int)strAuthenticated;
                    if (strAuthenticated == "0")
                    {
                        if (objLogin.RoleId == null)
                        {
                            strAuthenticated = "2";
                        }
                    }
                    switch (strAuthenticated)
                    {
                        case "0":
                            objLogin.LogInfo();
                            Session["CentreId"] = objLogin.CentreId;
                            Session["SubCentreID"] = objLogin.GetSubCenter();
                            Session["Prefix"] = objLogin.Prefix;
                            Session["HierarchyId"] = objLogin.HierarchyId;
                            Session["HierLevel"] = objLogin.UserLevel.ToString();
                            Session["RoleId"] = objLogin.RoleId;
                            Session["UserId"] = objLogin.UserId;
                            Session["LogId"] = objLogin.LogId;
                            Session["FLName"] = objLogin.FLName;
                            Session["UserName"] = objLogin.UserName;
                            Session["CentreCode"] = ddlCenter.SelectedItem.Text;
                            Session["ClusterId"] = objLogin.GetCluster();
                            Session["MFA_applicable"] = objLogin.MFA_applicable;

                            objLogin.InsertLoginDetail();
                            Session["LogID"] = objLogin.LogId;


                            if (Check_SystemPassword())
                            {
                                //method
                                Flag = 0;
                                Check_Login_Attempt(); //add on 27/01/2025
                                int MFA_applicable = Convert.ToInt32(Session["MFA_applicable"]);

                                if (MFA_applicable == 1)
                                {
                                    Response.Redirect("grid_authentication.aspx", false);
                                }
                                else
                                {
                                    Response.Redirect("OrganizationTree.aspx", false);
                                }
                            }
                            else
                            {
                                Response.Redirect("ChangePassword.aspx?Err=" + lblMsg.Text.Trim(), false);
                            }

                            break;
                        case "1":
                            //method
                            Flag = 1;
                            Check_Login_Attempt(); //add on 27/01/2025
                                                   //lblMsg.Text = "Invalid Username or Password";

                            break;
                        case "2":
                            lblMsg.Text = "Please verify your centre as you are not authorised for this centre";
                            break;
                        default:
                            lblMsg.Text = "Invalid input";
                            break;
                    }
                }
                else
                {
                    lblMsg.Text = "Your account has been locked, Please contact to BD Domestic SPOC.";
                }
            }
            else
            {
                lblMsg.Text = "Invalid Captcha !";
                lblMsg.ForeColor = Color.Red;
            }
        }
        catch (Exception exp)
        {
            lblMsg.Text = exp.Message;
            //Response.Redirect("EmployeeMaster.aspx?" + exp.Message);
        }
    }

    //protected void btnHelpDesk_OnClick(object sender, EventArgs e)
    //{

    //    try
    //    {
    //        String strTo = "manoj@tasaa.com";
    //        String strMsg = " Dear <b>HelpDesk Executive</b>, " + "<br/>" + txtMsg.Text;
    //        String strSubject = txtSubject.Text;
    //        String strFrom = "prashant_r@tasaa.com";//ADMIN ID

    //        MailMessage objMMsg = new MailMessage();
    //        if ((strTo != "") && (strFrom != ""))
    //        {
    //            objMMsg.To = strTo;
    //            //objMMsg.Cc = strCc;
    //            objMMsg.From = strFrom;
    //            objMMsg.Subject = strSubject;
    //            objMMsg.BodyFormat = MailFormat.Html;
    //            objMMsg.Body = strMsg;
    //            SmtpMail.Send(objMMsg);
    //            lblHelpdesk.Text = "Successfully sent request to HelpDesk ";
    //            txtSubject.Text = "";
    //            txtMsg.Text = "";
    //        }
    //    }
    //    catch (Exception exp)
    //    {
    //        lblHelpdesk.Text = exp.Message;
    //    }
    //}

    //protected void btnForGot_OnClick(object sender, EventArgs e)
    //{

    //    try
    //    {
    //        String strTo = "manoj@tasaa.com";
    //        String MainMsg = "You have received a mail from <br/> Employee code <b><u>" + txtEmployeeCode.Text + "</u></b> <br><br/>Please resend his password to access PAMAC ONLINE SERVICE APPLICATUON to his mailbox";
    //        String strMsg = " Dear <b>Administrator</b>, " + "<br/><br/>" + MainMsg;
    //        String strSubject = "Employee code: " + txtEmployeeCode.Text + " forgot password ";
    //        String strFrom = "prashant_r@tasaa.com";//ADMIN ID

    //        MailMessage objMMsg = new MailMessage();
    //        if ((strTo != "") && (strFrom != ""))
    //        {
    //            objMMsg.To = strTo;
    //            //objMMsg.Cc = strCc;
    //            objMMsg.From = strFrom;
    //            objMMsg.Subject = strSubject;
    //            objMMsg.BodyFormat = MailFormat.Html;
    //            objMMsg.Body = strMsg;
    //            SmtpMail.Send(objMMsg);
    //            lblHelpdesk.Text = "PAMAC ONLINE SERVICE APPLICATION administrator will contact you soon!!!";
    //            txtEmployeeCode.Text = "";
    //        }
    //    }
    //    catch (Exception exp)
    //    {
    //        lblHelpdesk.Text = exp.Message;
    //    }
    //}
    private Boolean Check_SystemPassword()
    {
        try
        {
            CCommon objConn = new CCommon();
            //OleDbConnection sqlConn = new OleDbConnection(objConn.ConnectionString);
            //sqlConn.Open();


            string strSqlCluster = "Exec Get_UserPasswordStatus @LoginId='" + txtUserName.Text.Trim() + "' ,@ReturnValue=null ";


            int Return = Convert.ToInt16(OleDbHelper.ExecuteScalar(objConn.ConnectionString, CommandType.Text, strSqlCluster));
            if (Return == 1)
            {
                lblMsg.Text = "Please Change your Password ,Your Password has been Expired!";
                return false;

            }
            else if (Return == 2)
            {
                lblMsg.Text = "Please Change your Password , your password is set by admin!";
                return false;
            }
            else if (Return == 3)
            {
                lblMsg.Text = "Please Change your Password , your reached the days limit!";
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
                    lblMsg.Text = "Your password is not complying with Standard Password Policy!";
                    return false;
                }

            }

        }
        catch (Exception exp)
        {

            lblMsg.Text = exp.Message;
            return false;
            //Response.Redirect("EmployeeMaster.aspx?" + exp.Message);
        }
    }
    private Boolean Check_Password(string pstrPassword)
    {
        try
        {
            lblMsg.Text = "";
            Boolean IsNumeric = false;
            Boolean IsSpecialChar = false;
            Boolean IsChar = false;

            string strPass = pstrPassword;
            if (strPass.Length < 8)
            {
                lblMsg.Text = "Password Length should be minimum equals to 8 char";
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

                lblMsg.Text = "your password should contains any of the special char!";
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
                lblMsg.Text = "your password should contains any of the Alphabets!";
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
                lblMsg.Text = "your password should contains any of the Numeric!";
                return false;
            }

            return true;
        }
        catch (Exception ex)
        {
            lblMsg.Text = ex.Message;
            return false;
        }
    }

    private void Check_Login_Attempt() //add on 27/01/2025
    {
        try
        {
            SqlConnection sqlCon = new SqlConnection(ConfigurationManager.AppSettings["constring"]);

            sqlCon.Open();
            SqlCommand sqlCom = new SqlCommand();
            sqlCom.Connection = sqlCon;
            sqlCom.CommandType = CommandType.StoredProcedure;
            sqlCom.CommandText = "BD_Domestic_Login_Attempt_SP";

            SqlParameter UserId = new SqlParameter();
            UserId.SqlDbType = SqlDbType.VarChar;
            UserId.Value = txtUserName.Text.Trim();
            UserId.ParameterName = "@userid";
            sqlCom.Parameters.Add(UserId);

            SqlParameter flag = new SqlParameter();
            flag.SqlDbType = SqlDbType.Int;
            flag.Value = Flag;
            flag.ParameterName = "@flag";
            sqlCom.Parameters.Add(flag);
            
            SqlDataAdapter sqlDA = new SqlDataAdapter();
            sqlDA.SelectCommand = sqlCom;

            DataTable dt = new DataTable();
            sqlDA.Fill(dt);
            sqlCon.Close();

            failedAttempts = Convert.ToInt32(dt.Rows[0]["FailedLoginAttempts"]); //add on 24/01/2025
            string msg = Convert.ToString(dt.Rows[0]["MSG"]); //add on 24/01/2025

            if (dt.Rows.Count > 0 && failedAttempts <= 3 && msg == "TRUE") //add on 24/01/2025
            {
                
            }
            else
            {
                failedAttempts = Convert.ToInt32(dt.Rows[0]["FailedLoginAttempts"]);  //add on 24/01/2025
                                                                                      // Show the remaining login attempts
                int remainingAttempts = 3 - failedAttempts;
                lblMsg.Visible = true;
                lblMsg.ForeColor = System.Drawing.Color.Red;
                lblMsg.Text = string.Format("Incorrect username or password. You have {0} remaining attempts.", remainingAttempts);


                if (failedAttempts >=3) //add on 24/01/2025
                {
                    lblMsg.Visible = true;
                    lblMsg.ForeColor = System.Drawing.Color.Red;
                    lblMsg.Text = "Your account has been locked, Please contact to BD Domestic SPOC.";
                }
            }
        }
        catch (Exception ex)
        {
            lblMsg.Visible = true;
            lblMsg.Text = ex.Message;
        }
    }

}
