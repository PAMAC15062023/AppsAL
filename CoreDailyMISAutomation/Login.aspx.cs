using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASPSnippets.Captcha;

namespace CoreDailyMISAutomation
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //Check_Auth_User();
                BindBranch();
                GenerateCaptcha();
            }
        }

        protected void BindBranch()
        {
            try
            {
                SqlConnection sqlCon = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);

                SqlCommand sqlCom = new SqlCommand();
                sqlCom.Connection = sqlCon;
                sqlCom.CommandType = CommandType.StoredProcedure;
                sqlCom.CommandText = "CDMA_BindBranchMaster";
                sqlCom.CommandTimeout = 0;

                SqlDataAdapter da = new SqlDataAdapter(sqlCom);
                DataSet ds = new DataSet();
                da.Fill(ds);

                if (ds != null && ds.Tables.Count > 0)
                {
                    ddlBranchList.DataTextField = "BranchName";
                    ddlBranchList.DataValueField = "ID";
                    ddlBranchList.DataSource = ds.Tables[0];
                    ddlBranchList.DataBind();

                    ddlBranchList.Items.Insert(0, "--Select--");
                    ddlBranchList.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                string MSG = ex.ToString();
            }
        }
        protected int Check_Auth_User()
        {
            int returnVal = 1;//1 valid 0 invalid
            try
            {
                SqlConnection sqlCon = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());

                sqlCon.Open();
                SqlCommand sqlCom = new SqlCommand();
                sqlCom.Connection = sqlCon;
                sqlCom.CommandType = CommandType.StoredProcedure;
                sqlCom.CommandText = "CDMA_UserLogin";

                SqlParameter LoginName = new SqlParameter();
                LoginName.SqlDbType = SqlDbType.VarChar;
                LoginName.Value = txtUserName.Text.Trim();
                LoginName.ParameterName = "@UserID";
                sqlCom.Parameters.Add(LoginName);

                SqlParameter Password = new SqlParameter();
                Password.SqlDbType = SqlDbType.VarChar;
                Password.Value = CEncDec.Encrypt(txtPassword.Text.Trim(), txtPassword.Text.Trim());
                Password.ParameterName = "@Password";
                sqlCom.Parameters.Add(Password);

                SqlParameter Branch = new SqlParameter();
                Branch.SqlDbType = SqlDbType.VarChar;
                Branch.Value = ddlBranchList.SelectedValue;
                Branch.ParameterName = "@Branch";
                sqlCom.Parameters.Add(Branch);



                SqlDataAdapter sqlDA = new SqlDataAdapter();
                sqlDA.SelectCommand = sqlCom;

                DataTable dt = new DataTable();
                sqlDA.Fill(dt);
                sqlCon.Close();

                int failedAttempts = Convert.ToInt32(dt.Rows[0]["FailedLoginAttempts"]); //add on 25/01/2025
                string msg = Convert.ToString(dt.Rows[0]["MSG"]); //add on 25/01/2025

                if (dt.Rows.Count > 0 && failedAttempts <= 3 && msg == "TRUE") //add on 25/01/2025
                {
                    Session["ID"] = Convert.ToString(dt.Rows[0]["ID"]);
                    Session["UserName"] = Convert.ToString(dt.Rows[0]["UserName"]);
                    Session["UserID"] = Convert.ToString(dt.Rows[0]["UserID"]);
                    Session["RoleID"] = Convert.ToInt32(dt.Rows[0]["RoleID"]);
                    Session["BranchName"] = Convert.ToString(dt.Rows[0]["CPC"]);
                    //Session["Vertical"] = Convert.ToString(dt.Rows[0]["Vertical"]);
                    Session["IsFirstTime"] = Convert.ToString(dt.Rows[0]["IsFirstTime"]);
                    Session["Branch_Name"] = Convert.ToString(dt.Rows[0]["Branch_Name"]);

                    //Session["Email"] = Convert.ToString(dt.Rows[0]["Email"]);
                    //Session["LoanType"] = Convert.ToString(ddlloantype.SelectedItem.Text);
                    //Session["Branch_Hub_Id"] = Convert.ToString(dt.Rows[0]["Branch_Hub_Id"]);
                    //Session["Location_Id"] = Convert.ToString(dt.Rows[0]["Location_Id"]);

                    Session["MFA_applicable"] = Convert.ToString(dt.Rows[0]["MFA_applicable"]);


                    UserInfo.structUSERInfo SaveUSERInfo = new UserInfo.structUSERInfo();

                    SaveUSERInfo.ID = Convert.ToString(dt.Rows[0]["ID"]);
                    SaveUSERInfo.UserName = Convert.ToString(dt.Rows[0]["UserName"]);
                    SaveUSERInfo.UserID = Convert.ToString(dt.Rows[0]["UserID"]);
                    SaveUSERInfo.RoleID = Convert.ToInt32(dt.Rows[0]["RoleID"]);
                    SaveUSERInfo.BranchName = Convert.ToString(dt.Rows[0]["CPC"]);
                    //SaveUSERInfo.Vertical = Convert.ToString(dt.Rows[0]["Vertical"]);
                    SaveUSERInfo.Branch_Name = Convert.ToString(dt.Rows[0]["Branch_Name"]);


                    // SaveUSERInfo.Email = Convert.ToString(dt.Rows[0]["Email"]);
                    //  SaveUSERInfo.LoanType = Convert.ToString(ddlloantype.SelectedItem.Text);
                    // SaveUSERInfo.Branch_Hub_Id = Convert.ToString(dt.Rows[0]["Branch_Hub_Id"]);
                    // SaveUSERInfo.Location_Id = Convert.ToString(dt.Rows[0]["Location_Id"]);

                    SaveUSERInfo.AuthorizeUSERID = "";
                    SaveUSERInfo.ClientName = "Yes Bank";
                    Session["USERInfo"] = SaveUSERInfo;

                }
                else
                {
                    //lblError.Visible = true;  //comment on 25/01/2025
                    //lblError.Text = "Incorrect UserId or Password,[Please Enter Correct UserId and Password]!";
                    
                    returnVal = 0;

                    failedAttempts = Convert.ToInt32(dt.Rows[0]["FailedLoginAttempts"]);  //add on 25/01/2025
                    // Show the remaining login attempts
                    int remainingAttempts = 3 - failedAttempts;
                    lblError.Visible = true;
                    lblError.ForeColor = System.Drawing.Color.Red;
                    lblError.Text = $"Incorrect username or password. You have {remainingAttempts} remaining attempts.";

                    if (failedAttempts >= 3) //add on 25/01/2025
                    {
                        lblError.Visible = true;
                        lblError.ForeColor = System.Drawing.Color.Red;
                        lblError.Text = $"Your account has been locked, Please contact to Core Daily MIS Automation SPOC.";
                    }
                }
            }
            catch (Exception ex)
            {
                returnVal = 0;
                lblError.Visible = true;
                lblError.Text = ex.Message;
            }

            return returnVal;
        }
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            bool CaptchaIsValid = Captcha.IsValid(txtCaptchaAnswer.Text.Trim());
            int isValid = 0;

            if (CaptchaIsValid)
            {

                isValid = Check_Auth_User();

                if (isValid == 1)
                {
                    if (Convert.ToBoolean(Session["IsFirstTime"]) == true)
                    {
                        Response.Redirect("ChangePassword.aspx", false);
                        return;
                    }
                }


                if (isValid == 0)
                {
                    Session.Clear();
                    return;

                }

                int MFA_applicable = Convert.ToInt32(Session["MFA_applicable"]);

                if (MFA_applicable == 1)
                {
                    Response.Redirect("grid_authentication.aspx", false);
                }
                else
                {
                    int RoleID = Convert.ToInt32(Session["RoleID"]);
                    if (RoleID == 1)
                    {
                        Response.Redirect("CDMA_Menu.aspx", true);
                    }
                    else if (RoleID == 2)
                    {
                        Response.Redirect("CDMA_Menu.aspx", true);
                    }
                }
            }
            else
            {
                lblError.Visible = true;
                lblError.Text = "Invalid Captcha";
                GenerateCaptcha();
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