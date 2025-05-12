using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASPSnippets.Captcha;

namespace IncidentTracker
{
    public partial class IT_LoginPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    txtUserName.Focus();
                    Get_BranchList();
                    Get_ClientList();
                    GenerateCaptcha();
                }

            }
            catch (Exception ex)
            {
                lblError.Visible = true;
                lblError.Text = ex.Message;
            }
        }
        private void Get_BranchList()
        {
            try
            {

                SqlConnection sqlCon = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);

                sqlCon.Open();
                SqlCommand sqlCom = new SqlCommand();
                sqlCom.Connection = sqlCon;
                sqlCom.CommandType = CommandType.StoredProcedure;
                sqlCom.CommandText = "IT_BindBranchInfo_SP";
                SqlDataAdapter sqlDA = new SqlDataAdapter();
                sqlDA.SelectCommand = sqlCom;
                DataTable dt = new DataTable();
                sqlDA.Fill(dt);
                sqlCon.Close();

                ddlBranchList.DataTextField = "BranchName";
                ddlBranchList.DataValueField = "BranchId";
                ddlBranchList.DataSource = dt;
                ddlBranchList.DataBind();

                ddlBranchList.Items.Insert(0, "--Select--");
                ddlBranchList.SelectedIndex = 0;

            }
            catch (Exception ex)
            {
                lblError.Visible = true;
                lblError.Text = ex.Message;
            }
        }
        private void Get_ClientList()
        {
            try
            {

                SqlConnection sqlCon = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);

                sqlCon.Open();
                SqlCommand sqlCom = new SqlCommand();
                sqlCom.Connection = sqlCon;
                sqlCom.CommandType = CommandType.StoredProcedure;
                sqlCom.CommandText = "IT_BindClientDetails_SP";
                SqlDataAdapter sqlDA = new SqlDataAdapter();
                sqlDA.SelectCommand = sqlCom;
                DataTable dt = new DataTable();
                sqlDA.Fill(dt);
                sqlCon.Close();

                ddlClientList.DataTextField = "Client_Name";
                ddlClientList.DataValueField = "ClientID";
                ddlClientList.DataSource = dt;
                ddlClientList.DataBind();

                ddlClientList.Items.Insert(0, "--Select--");
                ddlClientList.SelectedIndex = 0;

            }
            catch (Exception ex)
            {
                lblError.Visible = true;
                lblError.Text = ex.Message;
            }
        }
        private void Check_Auth_user()
        {
            try
            {
                SqlConnection sqlCon = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);

                sqlCon.Open();
                SqlCommand sqlCom = new SqlCommand();
                sqlCom.Connection = sqlCon;
                sqlCom.CommandType = CommandType.StoredProcedure;
                sqlCom.CommandText = "IT_UserLogin_SP";

                SqlParameter varUserId = new SqlParameter();
                varUserId.SqlDbType = SqlDbType.VarChar;
                varUserId.Value = txtUserName.Text.Trim();
                varUserId.ParameterName = "@varUserId";
                sqlCom.Parameters.Add(varUserId);

                SqlParameter varPassword = new SqlParameter();
                varPassword.SqlDbType = SqlDbType.VarChar;
                varPassword.Value = CEncDec.Encrypt(txtPassword.Text.Trim(), txtPassword.Text.Trim());
                varPassword.ParameterName = "@varPassword";
                sqlCom.Parameters.Add(varPassword);

                SqlParameter intBranchId = new SqlParameter();
                intBranchId.SqlDbType = SqlDbType.Int;
                intBranchId.Value = ddlBranchList.SelectedValue;
                intBranchId.ParameterName = "@intBranchId";
                sqlCom.Parameters.Add(intBranchId);


                SqlDataAdapter sqlDA = new SqlDataAdapter();
                sqlDA.SelectCommand = sqlCom;

                DataTable dt = new DataTable();
                sqlDA.Fill(dt);
                sqlCon.Close();

                int failedAttempts = Convert.ToInt32(dt.Rows[0]["FailedLoginAttempts"]); //add on 24/01/2025
                string msg = Convert.ToString(dt.Rows[0]["MSG"]); //add on 24/01/2025

                if (dt.Rows.Count > 0 && failedAttempts <= 3 && msg == "TRUE") //add on 24/01/2025
                {

                    UserInfo.structUSERInfo SaveUSERInfo = new UserInfo.structUSERInfo();
                    SaveUSERInfo.BranchId = Convert.ToInt32(dt.Rows[0]["BranchId"]);
                    SaveUSERInfo.BranchName = Convert.ToString(dt.Rows[0]["BranchName"]);
                    SaveUSERInfo.UserId = Convert.ToString(dt.Rows[0]["UserId"]);
                    SaveUSERInfo.UserName = Convert.ToString(dt.Rows[0]["UserName"]);

                    SaveUSERInfo.RoleName = Convert.ToString(dt.Rows[0]["RoleName"]);
                    SaveUSERInfo.RoleId = Convert.ToInt32(dt.Rows[0]["RoleId"]);
                    SaveUSERInfo.AuthorizeUSERID = "";

                    SaveUSERInfo.ClientName = Convert.ToString(ddlClientList.SelectedItem);
                    SaveUSERInfo.ClientId = Convert.ToInt32(ddlClientList.SelectedValue);

                    SaveUSERInfo.MFA_applicable = Convert.ToInt32(dt.Rows[0]["MFA_applicable"]);

                    lblError.Visible = false;
                    lblError.Text = "";

                    if (Check_IsSystem())
                    {
                        SaveUSERInfo.AuthorizePassword = "1";
                        Session["USERInfo"] = SaveUSERInfo;
                        logdetails();

                        if (Convert.ToInt32(dt.Rows[0]["MFA_applicable"]) == 1)
                        {
                            Response.Redirect("grid_authentication.aspx", false);
                        }
                        else
                        {
                            Response.Redirect("~/Pages/IT_MenuPage.aspx", false);
                        }
                    }
                    else
                    {
                        SaveUSERInfo.AuthorizePassword = "0";
                        Session["USERInfo"] = SaveUSERInfo;
                        Response.Redirect("IT_ChangePassword.aspx?Err=" + lblError.Text.Trim(), false);
                        savelogindetails12();
                    }
                }
                else
                {
                    //lblError.Visible = true;  //comment on 24/01/2025
                    //lblError.Text = "Incorrect UserId or Password,[Please enter Your PAMAC EMPLOYEE Code]!";
                    
                    savelogindetails12();

                    failedAttempts = Convert.ToInt32(dt.Rows[0]["FailedLoginAttempts"]);  //add on 24/01/2025
                    // Show the remaining login attempts
                    int remainingAttempts = 3 - failedAttempts;
                    lblError.Visible = true;
                    lblError.ForeColor = System.Drawing.Color.Red;
                    lblError.Text = $"Incorrect username or password. You have {remainingAttempts} remaining attempts.";

                    if (failedAttempts >= 3) //add on 24/01/2025
                    {
                        lblError.Visible = true;
                        lblError.ForeColor = System.Drawing.Color.Red;
                        lblError.Text = $"Your account has been locked, Please contact to Incident Tracker SPOC.";
                    }
                }
            }
            catch (Exception ex)
            {
                lblError.Visible = true;
                lblError.Text = ex.Message;
            }
        }
        private Boolean Check_IsSystem()
        {
            try
            {
                Object SaveUSERInfo = (Object)Session["UserInfo"];

                SqlConnection sqlCon = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);

                sqlCon.Open();
                SqlCommand sqlCom = new SqlCommand();
                sqlCom.Connection = sqlCon;
                sqlCom.CommandType = CommandType.StoredProcedure;
                sqlCom.CommandText = "IT_GetUserPasswordStatus_SP";

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
        private Boolean Check_Password(string pstrPassword)
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
        public void logdetails()
        {

            Object SaveUSERInfo = (Object)Session["UserInfo"];

            SqlConnection sqlCon = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);

            SqlCommand sqlCom = new SqlCommand();
            sqlCom.Connection = sqlCon;
            sqlCom.CommandType = CommandType.StoredProcedure;
            sqlCom.CommandText = "IT_AssignAttendance_SP";
            sqlCom.CommandTimeout = 0;

            SqlDataAdapter sqlDA = new SqlDataAdapter();
            sqlDA.SelectCommand = sqlCom;

            SqlParameter CreatedBy = new SqlParameter();
            CreatedBy.SqlDbType = SqlDbType.VarChar;
            CreatedBy.Value = Convert.ToString(((UserInfo.structUSERInfo)(SaveUSERInfo)).UserId);
            CreatedBy.ParameterName = "@CreatedBy";
            sqlCom.Parameters.Add(CreatedBy);

            sqlCon.Open();

            int SqlRow = 0;
            SqlRow = sqlCom.ExecuteNonQuery();

            sqlCon.Close();

            if (SqlRow > 0)
            {

            }

        }
        public void savelogindetails12()
        {
            Object SaveUSERInfo = (Object)Session["UserInfo"];
            SqlConnection sqlCon = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);

            SqlCommand sqlCom = new SqlCommand();
            sqlCom.Connection = sqlCon;
            sqlCom.CommandType = CommandType.StoredProcedure;
            sqlCom.CommandText = "IT_SaveLoginStatusPassword_SP";
            sqlCom.CommandTimeout = 0;

            SqlDataAdapter sqlDA = new SqlDataAdapter();
            sqlDA.SelectCommand = sqlCom;
            sqlCom.Parameters.AddWithValue("@emp_id", txtUserName.Text.ToString().Trim());

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

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                bool CaptchaIsValid = Captcha.IsValid(txtCaptchaAnswer.Text.Trim());
                if (CaptchaIsValid)
                {
                    Check_Auth_user();
                }
                else
                {
                    lblError.Visible = true;
                    lblError.Text = "Invalid Captcha";
                    GenerateCaptcha();
                }
            }
            catch (Exception ex)
            {
                lblError.Visible = true;
                lblError.Text = ex.Message;
            }
        }
        private Captcha Captcha
        {
            get
            {
                return (Captcha)ViewState["Captcha"];
            }
            set
            {
                ViewState["Captcha"] = value;
            }
        }
        private void GenerateCaptcha()
        {
            // Regenerate the CAPTCHA image by creating a new instance
            this.Captcha = new Captcha(150, 40, 20f, "#FFFFFF", "#61028D", Mode.AlphaNumeric);
            imgCaptcha.ImageUrl = this.Captcha.ImageData;  // Set the CAPTCHA image URL
        }
    }
}