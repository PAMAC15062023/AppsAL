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

public partial class MasterPage : System.Web.UI.MasterPage
{     
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        { 
            if (Session["UserInfo"] == null)
            {
                   
            }
            else
            {
                Object SaveUSERInfo = (Object)Session["UserInfo"];
                lblWelcome.Text = "Welcome " + Convert.ToString(((UserInfo.structUSERInfo)(SaveUSERInfo)).UserName) + " to " + Convert.ToString(((UserInfo.structUSERInfo)(SaveUSERInfo)).BranchName) + " Branch";
                
                IsAuthorizeUser_ForPage();
                 
            }
        }
        catch (Exception ex)
        { 
           
        }       

    }
    protected void lnkLogOut_Click(object sender, EventArgs e)
    {
        
            if (Session["UserInfo"] != null)
            {
                check_logout();
                Session.Clear();
                Response.Redirect("~/pages/Logout.aspx", false);
          
            }
 
    }


    //private void check_logout()
    //{
    //    Object SaveUSERInfo = (Object)Session["UserInfo"];
    //    SqlConnection sqlCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);
    //    try
    //    {
    //        if (sqlCon.State == ConnectionState.Closed)
    //        {
    //            sqlCon.Open();

    //            SqlCommand sqlCom = new SqlCommand();
    //            sqlCom.Connection = sqlCon;
    //            sqlCom.CommandType = CommandType.StoredProcedure;
    //            sqlCom.CommandText = "save_logoutdata";
    //            sqlCom.CommandTimeout = 0;

    //            sqlCom.Parameters.AddWithValue("@emp_id", Convert.ToString(((UserInfo.structUSERInfo)(SaveUSERInfo)).UserId));

    //            SqlDataAdapter sqlDA = new SqlDataAdapter();
    //            sqlDA.SelectCommand = sqlCom;

    //            int SqlRow = 0;
    //            SqlRow = sqlCom.ExecuteNonQuery();

    //            if (SqlRow > 0)
    //            {

    //            }
    //            else
    //            {
    //                //lblError.Text = "User Already Login.......";
    //            }
    //        }
    //    }
    //    catch (Exception ex)
    //    {
    //    }
    //    finally
    //    {
    //        if (sqlCon.State == ConnectionState.Open)
    //        {
    //            sqlCon.Close();
    //        }
    //    }


    //}


    private void check_logout()
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
                sqlCom.CommandText = "save_logoutdataNew";//save_logoutdata1234
                sqlCom.CommandTimeout = 0;

                sqlCom.Parameters.AddWithValue("@emp_id", Convert.ToString(((UserInfo.structUSERInfo)(SaveUSERInfo)).UserId));
                //sqlCom.Parameters.AddWithValue("@Token", HttpContext.Current.Session["Token"].ToString());
                sqlCom.Parameters.AddWithValue("@LOG_DET_ID", HttpContext.Current.Session.SessionID.ToString());
                SqlDataAdapter sqlDA = new SqlDataAdapter();
                sqlDA.SelectCommand = sqlCom;

                int SqlRow = 0;
                SqlRow = sqlCom.ExecuteNonQuery();

                if (SqlRow > 0)
                {

                }
                else
                {
                    //lblError.Text = "User Already Login.......";
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


    private void IsAuthorizeUser_ForPage()
    {
        Boolean ReturnValue = false;
        Object SaveUSERInfo = (Object)Session["UserInfo"];
               

                if (((UserInfo.structUSERInfo)(SaveUSERInfo)).PageAccessString.Contains(Request.AppRelativeCurrentExecutionFilePath.ToLower()))
                {
                    ReturnValue = true;
                }
                if (ReturnValue == false)
                {
                    if (Request.AppRelativeCurrentExecutionFilePath.ToString() == "~/Pages/SingleUserLogin.aspx")
                    {
                    }
                    else
                    Response.Redirect("~/Pages/Menu.aspx",true);
                } 

    }   

}
