using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

public partial class Pages_SingleUserLogin : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        if (Session["UserInfo"] != null)
        {
            check_logout();

           // Response.Cookies.Add(new HttpCookie("ASP.NET_SessionId", ""));
            Session.Abandon();

        }
    }
    protected void lnkLogin_Click(object sender, EventArgs e)
    {
        Response.Redirect("Logout.aspx", false);

    }
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
                sqlCom.CommandText = "save_logoutdata1234";
                sqlCom.CommandTimeout = 0;

                sqlCom.Parameters.AddWithValue("@emp_id", Convert.ToString(((UserInfo.structUSERInfo)(SaveUSERInfo)).UserId));
                sqlCom.Parameters.AddWithValue("@LOG_DET_ID", HttpContext.Current.Session.SessionID.ToString());
                sqlCom.Parameters.AddWithValue("@Token", HttpContext.Current.Session["Token"].ToString());
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
}