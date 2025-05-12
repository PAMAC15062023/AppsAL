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
using System.Drawing;


public partial class Pages_Login : System.Web.UI.Page
{
    //SingleUserLogin Login = new SingleUserLogin();
    public string Success = "";
    public string userID = "";
    public string userName = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                txtUserName.Focus();
                Get_BranchList();
                Get_ClientList();

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

            SqlConnection sqlCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);

            sqlCon.Open();
            SqlCommand sqlCom = new SqlCommand();
            sqlCom.Connection = sqlCon;
            sqlCom.CommandType = CommandType.StoredProcedure;
            sqlCom.CommandText = "Get_AllBranchList";
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
    public static bool IsLower(string str)
    {
        foreach (char ch in str)
        {
            if (char.IsLower(ch))
                return true;
        }
        return false;
    }
    protected void btnLogin_Click(object sender, EventArgs e)
    {
        try
        {
            if (txtCaptcha.Text.Trim() != "" && txtCaptcha.Text.Trim() != null)
            {


                captcha1.ValidateCaptcha(txtCaptcha.Text.Trim());
                if (captcha1.UserValidated)
                {
                    if (IsLower(txtCaptcha.Text.Trim()))
                    {
                        lblError.Visible = true;
                        lblError.ForeColor = Color.Red;
                        lblError.Text = "InValid Captha Captcha is case sensitive";
                        txtCaptcha.Text = "";
                        return;
                    }
                    int valid = Check_Auth_user();

                    if (valid == 1)
                    {
                        int isMFA_Applicable = Convert.ToInt32(Session["MFA_applicable"]);

                        if (isMFA_Applicable == 1)
                        {
                            if (IsUserGrid(txtUserName.Text.Trim()))
                            {
                                Autorole();
                                Response.Redirect("grid_authentication.aspx", false);
                            }
                            else
                            {
                                int otp = GenerateRandomNo();
                                bool result = Email(otp, Convert.ToString(Session["UserId"]), Convert.ToString(Session["UserName"]), Convert.ToString(Session["EmailId"]));

                                if (result == true)
                                {
                                    Autorole();
                                    Update_OTP(otp, Convert.ToString(Session["UserId"]));
                                    Response.Redirect("otp_authentication.aspx", false);
                                }
                                else
                                {
                                    lblError.Visible = true;
                                    lblError.Text = "Invalid Email ID";
                                }
                            }
                        }
                        else
                        {
                            Autorole();
                            Session["isMFA_Valid"] = "Yes";
                            Response.Redirect("Menu.aspx", false);
                        }

                    }
                    //check_login();
                    // if (Session["UserInfo"] != null)
                    // Login.InsertTokenLoginDetails();
                }
                else
                {
                    lblError.Visible = true;
                    lblError.ForeColor = Color.Red;
                    lblError.Text = "InValid Captha";
                    txtCaptcha.Text = "";
                }
            }
            else
            {
                lblError.Visible = true;
                lblError.ForeColor = Color.Red;
                lblError.Text = "Please enter Captha";
            }
        }
        catch (Exception ex)
        {
            lblError.Visible = true;
            lblError.Text = ex.Message;
        }

    }



    private void check_login()
    {
        Object SaveUSERInfo = (Object)Session["UserInfo"];
        SqlConnection sqlCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);
        try
        {
            if (sqlCon.State == ConnectionState.Closed)
            {
                sqlCon.Open();
                SqlCommand sqlCom = new SqlCommand();
                sqlCom.Connection = sqlCon;
                sqlCom.CommandType = CommandType.StoredProcedure;
                sqlCom.CommandText = "getlogindetails";
                sqlCom.CommandTimeout = 0;

                sqlCom.Parameters.AddWithValue("@emp_id", txtUserName.Text.Trim());

                SqlDataAdapter sda = new SqlDataAdapter();
                sda.SelectCommand = sqlCom;
                DataTable MyDs = new DataTable();
                sda.Fill(MyDs);

                if (MyDs.Rows.Count > 0)
                {

                    lblError.Text = "User Already Login.......";
                    Response.Redirect("~/Pages/Error20.aspx", false);

                }

                else
                {
                    savelogindetails();
                    //Check_Auth_user();
                    Autorole();


                }
            }
        }
        catch (Exception ex)
        {

        }

        finally
        {
            if (sqlCon.State == ConnectionState.Open)
            {
                sqlCon.Close();
            }
        }


    }

    public void savelogindetails()
    {
        Object SaveUSERInfo = (Object)Session["UserInfo"];
        SqlConnection sqlCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);

        SqlCommand sqlCom = new SqlCommand();
        sqlCom.Connection = sqlCon;
        sqlCom.CommandType = CommandType.StoredProcedure;
        sqlCom.CommandText = "save_loginstatus12";
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



    public void Autorole()
    {
        Object SaveUSERInfo = (Object)Session["UserInfo"];

        SqlConnection sqlCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);

        SqlCommand sqlCom = new SqlCommand();
        sqlCom.Connection = sqlCon;
        sqlCom.CommandType = CommandType.StoredProcedure;
        sqlCom.CommandText = "Sp_AutoRole12";//"Sp_AutoRole";
        sqlCom.CommandTimeout = 0;

        SqlDataAdapter sqlDA = new SqlDataAdapter();
        sqlDA.SelectCommand = sqlCom;

        sqlCon.Open();

        int SqlRow = 0;
        SqlRow = sqlCom.ExecuteNonQuery();

        sqlCon.Close();

        if (SqlRow > 0)
        {

        }
    }

    public void logdetails()
    {

        Object SaveUSERInfo = (Object)Session["UserInfo"];

        SqlConnection sqlCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);

        SqlCommand sqlCom = new SqlCommand();
        sqlCom.Connection = sqlCon;
        sqlCom.CommandType = CommandType.StoredProcedure;
        sqlCom.CommandText = "Sp_AssignAttendance12";
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
        SqlConnection sqlCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);

        SqlCommand sqlCom = new SqlCommand();
        sqlCom.Connection = sqlCon;
        sqlCom.CommandType = CommandType.StoredProcedure;
        sqlCom.CommandText = "save_loginstatus_password";
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


    private int Check_Auth_user()
    {
        int isValid = 0;
        try
        {
            SqlConnection sqlCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);

            sqlCon.Open();
            SqlCommand sqlCom = new SqlCommand();
            sqlCom.Connection = sqlCon;
            sqlCom.CommandType = CommandType.StoredProcedure;
            sqlCom.CommandText = "Auth_user12";

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


            int failedAttempts = Convert.ToInt32(dt.Rows[0]["FailedLoginAttempts"]); //add on 25/01/2025
            string msg = Convert.ToString(dt.Rows[0]["MSG"]); //add on 25/01/2025

            if (dt.Rows.Count > 0 && failedAttempts <= 3 && msg == "TRUE") //add on 25/01/2025
            {
                string MasterDBFFile = Convert.ToString(ConfigurationSettings.AppSettings["MasterDBFFiles"]);

                UserInfo.structUSERInfo SaveUSERInfo = new UserInfo.structUSERInfo();
                SaveUSERInfo.BranchId = Convert.ToInt32(dt.Rows[0]["BranchId"]);
                SaveUSERInfo.BranchName = Convert.ToString(dt.Rows[0]["BranchName"]);
                SaveUSERInfo.UserId = Convert.ToString(dt.Rows[0]["UserId"]);
                SaveUSERInfo.MasterLastUpdatedDate = System.IO.Directory.GetLastAccessTime(MasterDBFFile).ToString();
                SaveUSERInfo.MasterFileCreatedDate = System.IO.Directory.GetCreationTime(MasterDBFFile).ToString();
                SaveUSERInfo.GroupName = Convert.ToString(dt.Rows[0]["GroupName"]);
                SaveUSERInfo.GroupId = Convert.ToInt32(dt.Rows[0]["GroupID"]);
                SaveUSERInfo.PageAccessString = IsAuthorizeUser_ForPage(SaveUSERInfo.GroupName);
                SaveUSERInfo.ActivityID = Convert.ToInt32(dt.Rows[0]["VerticalID"]);
                SaveUSERInfo.UserName = Convert.ToString(dt.Rows[0]["UserName"]);
                //  SaveUSERInfo.Product =

                SaveUSERInfo.ActivityName = Convert.ToString(dt.Rows[0]["Product"]);

                SaveUSERInfo.AuthorizeUSERID = "";

                SaveUSERInfo.ClientName = Convert.ToString(ddlClientList.SelectedItem);
                SaveUSERInfo.ClientId = Convert.ToInt32(ddlClientList.SelectedValue);

                Session["MFA_applicable"] = Convert.ToString(dt.Rows[0]["MFA_applicable"]);


                Session["EmailId"] = Convert.ToString(dt.Rows[0]["EmailId"]);
                Session["UserId"] = Convert.ToString(dt.Rows[0]["UserId"]);
                Session["UserName"] = Convert.ToString(dt.Rows[0]["UserName"]);

                lblError.Visible = false;
                lblError.Text = "";

                if (Check_IsSystem())
                {
                    isValid = 1;
                    SaveUSERInfo.AuthorizePassword = "1";
                    Session["USERInfo"] = SaveUSERInfo;
                    // Response.Redirect("Menu.aspx", false); // 21/12/2024
                    logdetails();
                    QCTrackAutoAssign();

                }
                else
                {
                    isValid = 0;
                    SaveUSERInfo.AuthorizePassword = "0";
                    Session["USERInfo"] = SaveUSERInfo;
                    Response.Redirect("Change_Password.aspx?Err=" + lblError.Text.Trim(), false);
                    savelogindetails12();

                }
            }
            else
            {
                isValid = 0;
                txtCaptcha.Text = "";
                //lblError.Visible = true;
                //lblError.Text = "Incorrect UserId or Password,[Please enter Your PAMAC EMPLOYEE Code]!";
                savelogindetails12();

                failedAttempts = Convert.ToInt32(dt.Rows[0]["FailedLoginAttempts"]);  //add on 25/01/2025
                                                                                     
                int remainingAttempts = 3 - failedAttempts;   // Show the remaining login attempts
                lblError.Visible = true;
                lblError.ForeColor = System.Drawing.Color.Red;
                //lblError.Text = $"Incorrect username or password. You have {remainingAttempts} remaining attempts.";
                lblError.Text = "Incorrect username or password. You have " + remainingAttempts + " remaining attempts.";


                if (failedAttempts >= 3) //add on 25/01/2025
                {
                    lblError.Visible = true;
                    lblError.ForeColor = System.Drawing.Color.Red;
                    //lblError.Text = $"Your account has been locked, Please contact to Core Daily MIS Automation SPOC.";
                    lblError.Text = "Your account has been locked, Please contact to Calculus SPOC.";

                }
            }
        }
        catch (Exception ex)
        {
            lblError.Visible = true;
            lblError.Text = ex.Message;
        }

        return isValid;
    }






    private Boolean Check_IsSystem()
    {
        try
        {
            Object SaveUSERInfo = (Object)Session["UserInfo"];

            SqlConnection sqlCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);

            sqlCon.Open();
            SqlCommand sqlCom = new SqlCommand();
            sqlCom.Connection = sqlCon;
            sqlCom.CommandType = CommandType.StoredProcedure;
            sqlCom.CommandText = "Get_UserPasswordStatus";

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
            sqlCon.Close();

        }
        catch (Exception exp)
        {

            lblError.Text = exp.Message;
            return false;
            //Response.Redirect("EmployeeMaster.aspx?" + exp.Message);
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


    private string IsAuthorizeUser_ForPage(string pGroupName)
    {
        DataSet ds = new DataSet();

        string strReturnValue = "~/pages/menu.aspx,~/pages/calculus/makebranchpayment.aspx,~/pages/calculus/branchpettycashpaymentadd.aspx,~/pages/dda/dda_discrepancyadd.aspx,~/pages/helpdesk/Report.aspx;~/Pages/JFS/ImportFile.aspx;~/Pages/JFS/Import_statusUpdate.aspx;~/Pages/JFS/Scanning.aspx;~/Pages/RPC_OP/LocationMaster.aspx;~/Pages/JFS/Receipt_for_DDE.aspx;~/Pages/JFS/Assignment.aspx;~/Pages/JFS/DDE.aspx;~/Pages/JFS/DA_user_assign.aspx;~/Pages/JFS/DataEntry_Authorized.aspx;~/Pages/JFS/Quality_control.aspx;~/Pages/JFS/MIS.aspx;~/Pages/JFS/re_assign.aspx;~/pages/helpdesk/ticketstatus.aspx,~/pages/chequeprocessingnew/chequedataentry.aspx,~/pages/change_password.aspx,~/pages/chequeprocessingnew/chequebounceentry.aspx;~/Pages/LOSTracker/CPV.aspx;~/Pages/LOSTracker/QDE.aspx;~/Pages/LOSTracker/LOS_Search.aspx;~/pages/calculus/otherthanpettycash_amounttransfer.aspx;~/pages/calculus/otherthanpettycash_submitdetails.aspx;~/pages/chequeprocessingnew/validatechequedataentry.aspx;~/Pages/LOSTracker/ImportFile.aspx;~/Pages/Calculus/EPMAddRequest.aspx;~/Pages/Calculus/EPMViewRequest.aspx;~/Pages/LOSTracker/MIS.aspx;~/Pages/LOSTracker/Indexing.aspx;~/Pages/LOSTracker/DDEEntry.aspx;~/Pages/LOSTracker/DDEEntry.aspx;~/Pages/LOSTracker/Error_Update.aspx;~/Pages/Calculus/ImportTransaction.aspx;~/Pages/LOSTracker/SuperAdmin.aspx;~/Pages/LOSTracker/Attendance.aspx;~/Pages/LOSTracker/credit_manager.aspx;~/Pages/LOSTracker/RoleMaster.aspx;~/Pages/LOSTracker/LocationMaster.aspx;~/pages/chequeprocessingnew/GenerateMDBFile.aspx;~/pages/RPC_OP/MIS.aspx;~/pages/RPC_OP/Search.aspx;~/pages/chequeprocessingnew/generatedepositslip.aspx;~/pages/chequeprocessingnew/otherchequedataentry.aspx;~/pages/chequeprocessingnew/modifychequeentry.aspx;~/pages/chequeprocessingnew/chequeentrynew.aspx;~/pages/chequeprocessingnew/MDBDetails_master.aspx;~/pages/calculus/branchutilitypaymentrequest.aspx;~/Pages/Calculus/BranchUtilityPaymentRequest_View.aspx;~/pages/calculus/billstatusapproval.aspx;~/Pages/Calculus/updateTax.aspx;~/pages/calculus/reports/calculususerdefinedreports.aspx;~/Pages/LOSTracker/Import_MDR.aspx;~Pages/RPC_OP/ImportFile.aspx;~/Pages/RPC_OP/Indexing.aspx;~/Pages/RPC_OP/DID.aspx;~/Pages/LOSTracker/MRD_Update.aspx;~/pages/chequeprocessingnew/validatechequeentrysbi.aspx;~/Pages/RPC_OP/PDOC.aspx;~/Pages/RPC_OP/supervisor.aspx;~/Pages/ICICIBank-BLGActivityMIS/First.aspx;~/Pages/ICICIBank-BLGActivityMIS/Second.aspx;~/Pages/ICICIBank-BLGActivityMIS/Third.aspx;~/Pages/ICICIBank-BLGActivityMIS/Fourth.aspx;~/Pages/ICICIBank-BLGActivityMIS/MIS.aspx;~/Pages/ICICIBank-BLGActivityMIS/MyTray.aspx;~/Pages/LOSTracker/LocationMaster_Scanappr.aspx;~/Pages/LOSTracker/LocationMaster_WPO.aspx;~/Pages/PFT/Default.aspx;~/Pages/PFT/Default2.aspx;~/Pages/PFT/MISNew.aspx;~/Pages/PFT/Default3.aspx;~/Pages/PFT/importfile.aspx;~/Pages/PFT/Search.aspx;~/Pages/PFT/dataentry_page.aspx;~/Pages/PFT/elibility_check.aspx;~/Pages/PFT/DDE_stage.aspx;~/Pages/PFT/CPV.aspx;~/Pages/PFT/SendToCredit.aspx;~/Pages/PFT/recepivedfrm_bank.aspx;~/Pages/PFT/ops_login.aspx;~/Pages/PFT/maudit.aspx;~/Pages/PFT/ops_dde.aspx;~/Pages/PFT/ops_sendtobank.aspx;~/Pages/PFT/pft_Clientmaster.aspx;~/Pages/PFT/bank_analysis.aspx;~/Pages/PFT/bank_calculation.aspx;~/pages/PFT/mis.aspx;~/pages/chequeprocessingnew/adi_filegeneration.aspx;~/pages/PFT/pftbranch.aspx;~/pages/PFT/subbranch_master.aspx;~/Pages/LOSTracker/LocationMaster_BL.aspx;~/Pages/PFT/Dsa_page.aspx;~/Pages/PFT/ops_dataentry.aspx;~/Pages/PFT/hl_activity.aspx;~/Pages/Aspire/DataEntry.aspx;~/Pages/Aspire/LeadGen.aspx;~/Pages/Aspire/DealNo.aspx;~/Pages/Aspire/AspireMIS.aspx;~/Pages/PFT/cpvagency_master.aspx;~/Pages/JFS/query_resol.aspx;~/Pages/JFS/supervisor.aspx;~/Pages/JFS/cisc_number.aspx;~/Pages/PFT/import_qde.aspx;~/Pages/DCHComplains/Complants_page.aspx;~/Pages/DCHComplains/compla_display.aspx;~/Pages/DCHComplains/dch_display.aspx;~/Pages/DCHComplains/genral_display.aspx;~/Pages/DCHComplains/Report.aspx;~/Pages/online_test/add_qustions.aspx;~/Pages/online_test/mannual_papaer.aspx;~/Pages/Aspire/CPV.aspx;~/Pages/Aspire/PD.aspx;~/Pages/ICICIRPC/importfile.aspx;~/Pages/ICICIRPC/Manualentry.aspx;~/Pages/ICICIRPC/CPV.aspx;~/Pages/ICICIRPC/CAM.aspx;~/Pages/ICICIRPC/BDE.aspx;~/Pages/ICICIRPC/Search.aspx;~/Pages/ICICIRPC/ICICI_MIS.aspx;~/Pages/ICICIRPC/Superadmin.aspx;~/Pages/ICICIRPC/QCError.aspx;~/Pages/ICICIRPC/Rolemaster.aspx;~/Pages/PFT/RoleMaster.aspx;~/Pages/ICICIRPC/did_edit.aspx;~/Pages/ICICIRPC/Doc_import.aspx;~/Pages/ICICIRPC/Bank_Cal.aspx;~/Pages/JFS/LocationMaster.aspx;~/Pages/ICICIRPC/LocationMaster.aspx;~/Pages/PFT/Error_Update.aspx;~/Pages/PFT/cc_crstatus.aspx;~/Pages/HDFC/CaseEntry.aspx;~/Pages/HDFC/DPE.aspx;~/Pages/HDFC/PSDRE.aspx;~/Pages/HDFC/PAE.aspx;~/Pages/HDFC/SuperAdmin.aspx;~/Pages/HDFC/RoleMaster.aspx;~/Pages/HDFC/MISforHDFC.aspx;~/Pages/LOSTracker/creditmrg.aspx;~/Pages/RPC_OP/bank_cal.aspx;~/Pages/LOSTracker/bothhold.aspx;~/Pages/LOSTracker/DownTimeTracker.aspx;~/Pages/ICICIRPC/HLlocation.aspx;~/Pages/ICICIRPC/AL_locationmaster.aspx;~/Pages/WFM/Import.aspx;~/Pages/WFM/super_admin.aspx;~/Pages/WFM/TVR_wfm.aspx;~/Pages/WFM/devition.aspx;~/Pages/WFM/Holdpage.aspx;~/Pages/WFM/login.aspx;~/Pages/WFM/FI.aspx;~/Pages/WFM/FIstatus_new.aspx;~/Pages/WFM/report.aspx;~/Pages/PFT/holiday.aspx;~/Pages/IDFC/IDFC.aspx;~/Pages/IDFC/Discrepancy.aspx;~/Pages/IDFC/IDFCMIS.aspx;~/Pages/IDFC/FI_Form.aspx;~/Pages/IDFC/IDFCCreditManager.aspx;~/Pages/SREI_CPA/Import.aspx;~/Pages/SREI_CPA/Leadgeneration.aspx;~/Pages/SREI_CPA/Superadmin.aspx;~/Pages/SREI_CPA/QCTracking.aspx;~/Pages/ICICINDC/DEO.aspx;~/Pages/ICICINDC/Import.aspx;~/Pages/ICICINDC/QCTracking.aspx;~/Pages/ICICINDC/Superadmin.aspx;~/Pages/ICICINDC/MIS.aspx;~/Pages/SREI_CPA/ImportContract.aspx;~/Pages/IDFC/IDFCAgencymanager.aspx;~/Pages/SREI_CPA/Import1.aspx;~/Pages/SREI_CPA/LeadFTNR.aspx;~/Pages/SREI_CPA/MIS.aspx;~/Pages/ICICINDC/RoleMaster.aspx;~/Pages/SREI_CPA/Rolemaster.aspx;~/Pages/TSF/tsf_mis.aspx;~/Pages/TSF/tsfimport.aspx;~/Pages/CNHI/CaseEntry.aspx;~/Pages/CNHI/MIS.aspx;~/Pages/CNHI/ImportFile.aspx;~/Pages/CNHI/CaseSearch.aspx;~/Pages/IndiaBull/Import.aspx;~/Pages/IndiaBull/Cam.aspx;~/Pages/IndiaBull/CAMQC.aspx;~/Pages/IndiaBull/RoleMaster.aspx;~/Pages/IndiaBull/Superadmin.aspx;~/Pages/TCFSL_CDLOAN/IMPORT.aspx;~/Pages/TCFSL_CDLOAN/SFDC_Screening.aspx;~/Pages/TCFSL_CDLOAN/Maker.aspx;~/Pages/TCFSL_CDLOAN/Author.aspx;~/Pages/TCFSL_CDLOAN/Superadmin.aspx;~/Pages/TCFSL_CDLOAN/Role_Master.aspx;~/Pages/TCFSL_CDLOAN/MIS.aspx;~/Pages/TCFSL_CDLOAN/QCTracker.aspx;~/Pages/Calculus/UpdateWithdrawalHOAmt.aspx;~/Pages/TVS/Initial_Stage.aspx;~/Pages/TVS/TWL_Stage.aspx;~/Pages/TVS/DIYA_Stage.aspx;~/Pages/TVS/CDE_Stage.aspx;~/Pages/TVS/DEDUP_Stage.aspx;~/Pages/TVS/CIBIL_Stage.aspx;~/Pages/TVS/FI_Stage.aspx;~/Pages/TVS/Superadmin_TVS.aspx;~/Pages/TVS/MIS_TVS.aspx;~/pages/grid_authentication.aspx;~/pages/otp_authentication.aspx";//UpdateHoWithdrwal

        string FileSavePath = this.Request.PhysicalApplicationPath + ConfigurationSettings.AppSettings["MasterMenu"].ToString() + pGroupName + ".xml";
        FileInfo FFileName = new FileInfo(FileSavePath);
        if (FFileName.Exists)
        {
            ds.ReadXml(FileSavePath);
            if (ds.Tables[0].Rows.Count > 0)
            {

                for (int i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
                {
                    strReturnValue = strReturnValue + "," + ds.Tables[0].Rows[i][3].ToString().ToLower();
                }

            }
        }

        return strReturnValue;

    }

    private void Get_ClientList()
    {
        try
        {

            SqlConnection sqlCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);

            sqlCon.Open();
            SqlCommand sqlCom = new SqlCommand();
            sqlCom.Connection = sqlCon;
            sqlCom.CommandType = CommandType.StoredProcedure;
            sqlCom.CommandText = "Get_ClientList";
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



    public void QCTrackAutoAssign()
    {
        try
        {
            SqlConnection sqlCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);

            sqlCon.Open();
            SqlCommand sqlCom = new SqlCommand();
            sqlCom.Connection = sqlCon;
            sqlCom.CommandType = CommandType.StoredProcedure;
            sqlCom.CommandText = "uspQCTrackAutoAssign";

            sqlCom.ExecuteNonQuery();
        }
        catch (Exception ex)
        {

        }

    }


    protected void lnkForgetPassowrd_Click(object sender, EventArgs e)
    {
        if (txtUserName.Text.ToString().Trim() != "")
        {
            string NewPassword = "";
            Success = checkUserIDAndPassword();
            if (Success == "OK")
            {
                try
                {
                    //lblChangePassword.Text = "New Password Generated: " + strPassword;
                    NewPassword = Generate_AutoPassword();

                    SqlConnection sqlCon = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);

                    SqlCommand cmd = new SqlCommand("Calculus_ForgetPassword_SP", sqlCon);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@UserId", txtUserName.Text.Trim());
                    cmd.Parameters.AddWithValue("@Password", CEncDec.Encrypt(NewPassword, NewPassword));
                    SqlDataAdapter adp = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    adp.Fill(ds);


                    if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                    {
                        if (Convert.ToBoolean(ds.Tables[0].Rows[0]["ISSUCCESS"]) == true)
                        {
                            lblError.Visible = true;
                            lblError.ForeColor = System.Drawing.Color.Green;
                            lblError.Text = ds.Tables[0].Rows[0]["MESSAGE"].ToString();
                            lblError.ForeColor = System.Drawing.Color.Red;

                            string UserName = ds.Tables[0].Rows[0]["UserName"].ToString();
                            string EmailId = ds.Tables[0].Rows[0]["EmailId"].ToString();

                            SendMail(NewPassword, EmailId, UserName);

                            return;
                        }
                        else
                        {
                            lblError.Visible = true;
                            lblError.Text = "";
                            lblError.Text = ds.Tables[0].Rows[0]["MESSAGE"].ToString();
                            return;
                        }
                    }
                    else
                    {
                        lblError.Visible = true;
                        lblError.Text = "";
                        lblError.Text = "Please Contact Admin For Password Reset ....!";
                        return;
                    }
                }
                catch (Exception ex)
                {
                    string st = ex.Message;

                }

                //lblError.Visible = true;
                //lblError.Text = "";
                //lblError.Text = "Please Contact Admin For Password Reset ....!";
                //return;
            }
            else
            {
                if (Success == "NOT OK")
                {
                    lblError.Visible = true;
                    lblError.Text = "Please enter valid UseID....!";
                    return;
                }
                else
                {
                    lblError.Visible = true;
                    lblError.Text = Success;
                    return;
                }
            }
        }
        else
        {
            lblError.Visible = true;
            lblError.Text = "";
            lblError.Text = "Please Enter  UserID..!";
            return;
        }
    }
    public string Generate_AutoPassword()
    {
        try
        {
            int i;
            int CharLength = Convert.ToInt16(ConfigurationSettings.AppSettings["CharLength"]);
            int SpecialCharLength = Convert.ToInt16(ConfigurationSettings.AppSettings["SpecialCharLength"]); ;
            int NumericLength = Convert.ToInt16(ConfigurationSettings.AppSettings["NumLength"]); ;

            string strPassword = "";
            Random Rn = new Random();

            for (i = 0; i < CharLength; i++)
            {
                if (i == 0)
                {
                    strPassword = strPassword + Convert.ToChar(Rn.Next(65, 90));
                }
                else
                {
                    strPassword = strPassword + Convert.ToChar(Rn.Next(97, 122));
                }
            }

            for (i = 0; i < SpecialCharLength; i++)
            {
                strPassword = strPassword + Convert.ToChar(Rn.Next(64, 64));
            }

            for (i = 0; i < NumericLength; i++)
            {
                strPassword = strPassword + Convert.ToChar(Rn.Next(48, 57));
            }

            //lblChangePassword.Text = "New Password Generated: " + strPassword;
            return strPassword;

        }
        catch (Exception ex)
        {
            string st = ex.Message;
            return "";
        }

    }
    public void SendMail(string Password, string EmailId, string UserName)
    {
        try
        {
            System.Net.Mail.MailMessage mail = new System.Net.Mail.MailMessage();
            mail.Subject = "Calculus Password";
            mail.From = new MailAddress("software.support@pamac.com");
            mail.To.Add(EmailId);
            mail.Body = "This is YOUR PASSWORD : " + Password + " for " + UserName;


            SmtpClient smtp = new SmtpClient("mail.pamac.com", 587);
            smtp.Credentials = new System.Net.NetworkCredential("software.support@pamac.com", "_ug7rogzH");
            smtp.EnableSsl = false;/// Main line :SSL should be false
            smtp.Send(mail);

            // result.Value = "E-mail sent!";
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message);
        }


    }
    public string checkUserIDAndPassword()
    {
        try
        {
            SqlConnection sqlCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);
            Object SaveUSERInfo = (Object)Session["UserInfo"];
            SqlCommand sqlCom = new SqlCommand();
            sqlCom.Connection = sqlCon;
            sqlCom.CommandType = CommandType.StoredProcedure;
            sqlCom.CommandText = "getUserIdAndEmail";
            sqlCom.CommandTimeout = 0;

            if (txtUserName.Text.ToString().Trim() != "")
            {
                SqlParameter Application_no = new SqlParameter();
                Application_no.SqlDbType = SqlDbType.VarChar;
                Application_no.Value = txtUserName.Text.ToString().Trim();
                Application_no.ParameterName = "@UserID";
                sqlCom.Parameters.Add(Application_no);

            }
            sqlCon.Open();

            SqlDataAdapter sqlDA = new SqlDataAdapter();
            sqlDA.SelectCommand = sqlCom;
            DataTable dt = new DataTable();
            sqlDA.Fill(dt);
            sqlCon.Close();
            if (dt.Rows.Count > 0)
            {
                Success = dt.Rows[0]["Success"].ToString();
            }
            else
            {
                Success = "NOT OK";
            }
        }
        catch (Exception ex)
        {
            lblError.Visible = true;
            lblError.Text = ex.ToString();
        }
        return Success;
    }
    private Boolean IsUserGrid(string Userid)
    {
        try
        {
            Object SaveUSERInfo = (Object)Session["UserInfo"];

            SqlConnection sqlCon = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"].ToString());

            sqlCon.Open();
            SqlCommand sqlCom = new SqlCommand();
            sqlCom.Connection = sqlCon;
            sqlCom.CommandType = CommandType.StoredProcedure;
            sqlCom.CommandText = "Check_IsUserGrid";

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
                return true;
            }
            else
            {
                return false;
            }
        }
        catch (Exception exp)
        {
            lblError.Text = exp.Message;
            return false;
        }
    }
    public int GenerateRandomNo()
    {
        int _min = 1000;
        int _max = 9999;
        Random _rdm = new Random();
        return _rdm.Next(_min, _max);
    }
    private static bool Email(int OTP, string UserId, string UserName, string EmailId)
    {
        string Emailid = EmailId;
        string strTime = System.DateTime.Now.TimeOfDay.ToString().Remove(5);
        string strhh = strTime.Remove(2);
        string strmm = strTime.Remove(0, 3);

        string Current = System.DateTime.Now.Date.ToString().Remove(10);

        try
        {
            MailMessage mail = new MailMessage();
            SmtpClient smtp = new SmtpClient("mail.pamac.com", 587);
            smtp.Credentials = new System.Net.NetworkCredential("calculus@pamac.com", "pamac@123");
            mail.From = new MailAddress("calculus@pamac.com", "Calculus");
            mail.To.Add(Emailid);
            mail.Subject = "Login OTP for User Id " + UserId;
            string strBody =
                       "<html><body><font color=\"Navy\" style=\"font-style=Italic;font-weight=bold\">" +
                       "<P>                                                                                               </P>" +
                       "<P>Dear " + UserName + " ,</P>" +
                       "<P>This is your one-time login OTP " + OTP + " for User ID " + UserId + ".</P>" +
                       "<P>*Kindly log in within 2 minutes, after which it will expire.*</P>" +
                       "<P>*This is an automatically generated email, please do not reply*</P>" +
                       "<P>        </P>" +
                       "<P>Regards,</P>" +
                       "<P>Calculus  Team</P> " +
                       "</font></html></body>";

            mail.Body = strBody;
            mail.IsBodyHtml = true;
            smtp.Port = 587;
            smtp.Credentials = new System.Net.NetworkCredential("calculus@pamac.com", "pamac@123");
            smtp.EnableSsl = false;
            smtp.Send(mail);

            return true;
        }
        catch (Exception ex)
        {
            string msg = "Email Failed." + ex.Message;

            return false;
        }
    }
    private void Update_OTP(int OTP, string UserID)
    {

        SqlConnection sqlCon = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"].ToString());
        try
        {
            if (sqlCon.State == ConnectionState.Closed)
            {

                SqlCommand sqlCom = new SqlCommand();
                sqlCom.Connection = sqlCon;
                sqlCom.CommandType = CommandType.StoredProcedure;
                sqlCom.CommandText = "Cal_Update_OTP_SP";
                sqlCom.CommandTimeout = 0;
                sqlCom.Parameters.AddWithValue("@OTP", OTP);
                sqlCom.Parameters.AddWithValue("@UserId", UserID);

                sqlCon.Open();
                int Result = sqlCom.ExecuteNonQuery();
                sqlCon.Close();
            }
        }
        catch (Exception ex)
        {

        }
    }
}