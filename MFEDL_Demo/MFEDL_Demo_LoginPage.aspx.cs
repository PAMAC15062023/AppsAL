using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace MFEDL_Demo
{
    public partial class MFEDL_Demo_LoginPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
            if (!IsPostBack)
            {
                //Check_Auth_User();
           
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
                sqlCom.CommandText = "MFEDL_UserLogin";

                SqlParameter LoginName = new SqlParameter();
                LoginName.SqlDbType = SqlDbType.VarChar;
                LoginName.Value = txtUserName.Text.Trim(); //UserName.Value.Trim(); // 
                LoginName.ParameterName = "@UserID";
                sqlCom.Parameters.Add(LoginName);

                SqlParameter Password = new SqlParameter();
                Password.SqlDbType = SqlDbType.VarChar; 
                Password.Value = CEncDec.Encrypt(txtPassword.Text, txtPassword.Text.Trim()); //txtPassword.Text.trim //(Password.Value.ToString(), Password.Value.ToString()
                Password.ParameterName = "@Password";
                sqlCom.Parameters.Add(Password); 



                SqlDataAdapter sqlDA = new SqlDataAdapter();
                sqlDA.SelectCommand = sqlCom;

                DataTable dt = new DataTable();
                sqlDA.Fill(dt);
                sqlCon.Close();

                

                if (dt.Rows.Count > 0)
                {
                    Session["ID"] = Convert.ToString(dt.Rows[0]["ID"]);
                    Session["UserName"] = Convert.ToString(dt.Rows[0]["UserName"]);
                    Session["UserID"] = Convert.ToString(dt.Rows[0]["UserID"]);
                    Session["RoleID"] = Convert.ToInt32(dt.Rows[0]["RoleID"]);
                    Session["CPC"] = Convert.ToString(dt.Rows[0]["CPC"]);
                    


                    //Session["Email"] = Convert.ToString(dt.Rows[0]["Email"]);
                    //Session["LoanType"] = Convert.ToString(ddlloantype.SelectedItem.Text);
                    //Session["Branch_Hub_Id"] = Convert.ToString(dt.Rows[0]["Branch_Hub_Id"]);
                    //Session["Location_Id"] = Convert.ToString(dt.Rows[0]["Location_Id"]);

                    //Session["IsFirstTime"] = Convert.ToString(dt.Rows[0]["IsFirstTime"]);

                    UserInfo.structUSERInfo SaveUSERInfo = new UserInfo.structUSERInfo();

                    SaveUSERInfo.ID = Convert.ToString(dt.Rows[0]["ID"]);
                    SaveUSERInfo.UserName = Convert.ToString(dt.Rows[0]["UserName"]);
                    SaveUSERInfo.UserID = Convert.ToString(dt.Rows[0]["UserID"]);
                    SaveUSERInfo.RoleID = Convert.ToInt32(dt.Rows[0]["RoleID"]);
                    SaveUSERInfo.CPC = Convert.ToString(dt.Rows[0]["CPC"]);
                    

                    // SaveUSERInfo.Email = Convert.ToString(dt.Rows[0]["Email"]);
                    //  SaveUSERInfo.LoanType = Convert.ToString(ddlloantype.SelectedItem.Text);
                    // SaveUSERInfo.Branch_Hub_Id = Convert.ToString(dt.Rows[0]["Branch_Hub_Id"]);
                    // SaveUSERInfo.Location_Id = Convert.ToString(dt.Rows[0]["Location_Id"]);

                    // SaveUSERInfo.AuthorizeUSERID = "";
                    //SaveUSERInfo.ClientName = "Yes Bank";
                    Session["USERInfo"] = SaveUSERInfo;

                }
               else
                {
                    lblError.Visible = true;
                    lblError.Text = "Incorrect UserId or Password,[Please Enter Correct UserId and Password]!";
                    returnVal = 0;
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

           /* if (Check_Auth_User() == 1)
            {
                if (Convert.ToBoolean(Session["IsFirstTime"]) == true)
                {
                    Response.Redirect("YBL_ChnagePassWord.aspx", false);
                    return;
                }
            }*/


            if (Check_Auth_User() == 0)
            {
                Session.Clear();
                return;
            }


            int RoleID = Convert.ToInt32(Session["RoleID"]);

           /* if (Check_Login() == 0 && RoleId != 5)
            {
                Response.Redirect("YBL_Error20.aspx", false);
                return;
            }*/

            if (RoleID == 1)
            {
                Response.Redirect("MFEDL_MenuPage.aspx", true);
            }
            else if (RoleID == 2)
            {
                Response.Redirect("MFEDL_Post_MenuPage.aspx", false);
            }
           /* else if (RoleId == 3)
            {
                Response.Redirect("YBL_DEDUP_Stage.aspx", false);
            }
            else if (RoleId == 4)
            {
                Response.Redirect("YBL_QC_Stage.aspx", false);
            }
            else if (RoleId == 5)
            {
                Response.Redirect("YBL_SupervisorMenu.aspx", false);
            }
            else if (RoleId == 6)
            {

                if (Check_Login_dde() == 0)
                {
                    Response.Redirect("YBL_LoginStageHomePage.aspx", false);
                    //   return;
                }
                else
                {
                    Response.Redirect("YBL_QDE_DDE_CAM_Stage.aspx", false);
                }*/
            }
        }

       /* protected void lkbtnforgotPassword_Click(object sender, EventArgs e)
        {
            lblError.Visible = true;
            lblError.Text = "Please Contact Your Supervisor";
        }
        private int Check_Login()
        {
            int returnVal = 1;//1 valid 0 invalid
            SqlConnection sqlCon = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            try
            {
                if (sqlCon.State == ConnectionState.Closed)
                {

                    SqlCommand sqlCom = new SqlCommand();
                    sqlCom.Connection = sqlCon;
                    sqlCom.CommandType = CommandType.StoredProcedure;
                    sqlCom.CommandText = "YBL_AssignAttendance_SP";
                    sqlCom.CommandTimeout = 0;

                    sqlCom.Parameters.AddWithValue("@UserID", txtUserName.Text.Trim());

                    sqlCon.Open();
                    int Result = sqlCom.ExecuteNonQuery();

                    if (Result > 0)
                    {

                    }
                    else
                    {
                        //lblError.Text = "User Already Login.......";
                        returnVal = 0;
                        Response.Redirect("YBL_Error20.aspx", false);

                    }
                }
            }
            catch (Exception ex)
            {

            }
            return returnVal;
        }
        private int Check_Login_dde()
        {
            int returnVal = 1;//1 valid 0 invalid
            SqlConnection sqlCon = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            try
            {
                if (sqlCon.State == ConnectionState.Closed)
                {

                    SqlCommand sqlCom = new SqlCommand();
                    sqlCom.Connection = sqlCon;
                    sqlCom.CommandType = CommandType.StoredProcedure;
                    sqlCom.CommandText = "YBL_rolecheck_SP";
                    sqlCom.CommandTimeout = 0;

                    sqlCom.Parameters.AddWithValue("@UserID", txtUserName.Text.Trim());


                    SqlDataAdapter adp = new SqlDataAdapter(sqlCom);
                    DataSet ds = new DataSet();

                    adp.Fill(ds);

                    int Result = Convert.ToInt32(ds.Tables[0].Rows[0]["Counts"]);

                    if (Result > 0)
                    {
                        returnVal = 1;
                    }
                    else
                    {
                        //lblError.Text = "User Already Login.......";
                        returnVal = 0;
                        //      Response.Redirect("YBL_Error20.aspx", false);

                    }
                }
            }
            catch (Exception ex)
            {

            }
            return returnVal;
        }
    }
}
    }*/
}