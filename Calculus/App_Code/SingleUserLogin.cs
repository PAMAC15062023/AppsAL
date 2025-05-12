using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;


/// <summary>
/// Summary description for SingleUserLogin
/// </summary>
public class SingleUserLogin
{
    int tokenstring = 0;
	public SingleUserLogin()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    UserInfo UserInfo = new UserInfo();

    public void InsertTokenLoginDetails()
    {
        Random objrnd = new Random();
        tokenstring = objrnd.Next();

        HttpContext.Current.Session["Token"] = tokenstring;
        InsertLoginDetail1();
        InsertTokenDetail();
        token();
        Call();
    }

    public void ValidateTokenLoginDetails()
    {
        InsertLoginDetail();
        InsertTokenDetail();
        token();
        Call();
    }


    public void token()
    {
        //string getToken = obj.GetRandomString(10);

        DataSet ds = new DataSet();
        ds = Get_TokenUpdate();
        if (ds.Tables[0].Rows.Count > 0)
        {
            string abc = HttpContext.Current.Session["Token"].ToString();
            if (HttpContext.Current.Session["Token"].ToString() == ds.Tables[0].Rows[0]["Token"].ToString())
            {

                HttpContext.Current.Session.Remove("Token");

                Random objrnd = new Random();
                int tokenstring = objrnd.Next();
                UpdateTokenDetail(tokenstring);

                HttpContext.Current.Session["Token"] = tokenstring;
            }
            else
            {

                HttpContext.Current.Response.Redirect("https://www.pamaconline.com/Calculus/Pages/SingleUserLogin.aspx");//, true);

                //  HttpContext.Current.Response.Redirect("http://localhost:16028/NANO-PRO-App_Csharp_Calculus(28-Apr-2014)/Pages/SingleUserLogin.aspx");

            }
        }
    }
    public void UpdateTokenDetail(int tokenupdate)
    {
        SqlConnection con = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);
        Object SaveUSERInfo = (Object)HttpContext.Current.Session["UserInfo"];

        string UserId = ((UserInfo.structUSERInfo)(SaveUSERInfo)).UserId;
        string LoginId = HttpContext.Current.Session.SessionID.ToString();
        //string Token = HttpContext.Current.Session["Token"].ToString();

        SqlCommand command = new SqlCommand("sp_TokenUpdate12", con);
        command.CommandType = CommandType.StoredProcedure;

        command.Parameters.AddWithValue("@userid", UserId);
        command.Parameters.AddWithValue("@login_id", LoginId);
        //command.Parameters.AddWithValue("@token", Token);
        command.Parameters.AddWithValue("@token2", tokenupdate);

        con.Open();
        int i = command.ExecuteNonQuery();
        con.Close();
    }

    public DataSet Get_TokenUpdate()
    {

        Object SaveUSERInfo = (Object)HttpContext.Current.Session["UserInfo"];

        string UserId = ((UserInfo.structUSERInfo)(SaveUSERInfo)).UserId.ToString();

        string LoginId = HttpContext.Current.Session.SessionID.ToString();
        //string Token = HttpContext.Current.Session["Token"].ToString();

        SqlConnection con = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);

        SqlCommand command1 = new SqlCommand("Get_TokenUpdate12", con);
        command1.CommandType = CommandType.StoredProcedure;

        command1.Parameters.AddWithValue("@userid", UserId);
        command1.Parameters.AddWithValue("@login_id", LoginId);
        //command1.Parameters.AddWithValue("@token2", tokenupdate);

        SqlDataAdapter sda = new SqlDataAdapter();
        sda.SelectCommand = command1;

        DataSet ds = new DataSet();
        sda.Fill(ds);


        return ds;

    }


    public void Call()
    {
        Object SaveUSERInfo = (Object)HttpContext.Current.Session["UserInfo"];

        string UserId = ((UserInfo.structUSERInfo)(SaveUSERInfo)).UserId;
        try
        {

            DataSet MyDataSet = new DataSet();
            MyDataSet = NewMethod(UserId);


            string OldSession = string.Empty;
            if (MyDataSet.Tables[0].Rows.Count > 0)
            {
                OldSession = MyDataSet.Tables[0].Rows[0]["log_det_id"].ToString();

            }
            if (HttpContext.Current.Session.SessionID.ToString() != OldSession.ToString())
            {
                //Response.Redirect("~/Pages/Error20.aspx", false);
                if (HttpContext.Current.Session["UserInfo"] != null)
                {
                    HttpContext.Current.Response.Redirect("https://www.pamaconline.com/Calculus/Pages/SingleUserLogin.aspx");

                    // HttpContext.Current.Response.Redirect("http://localhost:16028/NANO-PRO-App_Csharp_Calculus(28-Apr-2014)/Pages/SingleUserLogin.aspx");
                    HttpContext.Current.Session.Abandon();
                }

            }
        }
        catch (Exception ex)
        {
            HttpContext.Current.Response.Redirect("https://www.pamaconline.com/Calculus/Pages/SingleUserLogin.aspx");
            //HttpContext.Current.Response.Redirect("~/Error20.aspx");
        }
    }
    public DataSet NewMethod(string UserId)//kanchan
    {

        using (SqlConnection con = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]))
        {
            SqlCommand command = new SqlCommand("Sp_Login_Details_212", con);
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@LoginName", UserId);

            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter();
            sda.SelectCommand = command;

            DataSet MyDataSet = new DataSet();
            sda.Fill(MyDataSet);

            con.Close();

            return MyDataSet;

        }


    }
    public void InsertLoginDetail1()
    {
        try
        {
            Object SaveUSERInfo = (Object)HttpContext.Current.Session["UserInfo"];
            string UserId = Convert.ToString(((UserInfo.structUSERInfo)(SaveUSERInfo)).UserId);
            string LoginId = HttpContext.Current.Session.SessionID.ToString();

            string Token = HttpContext.Current.Session["Token"].ToString();

            using (SqlConnection con = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]))
            {
                SqlCommand command = new SqlCommand("InsertLoginDetail1234", con);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@LOGIN_ID", UserId);
                command.Parameters.AddWithValue("@LOG_DET_ID", LoginId);


                con.Open();
                int i = command.ExecuteNonQuery();
                con.Close();
            }

        }
        catch (Exception ex)
        {

        }
    }
    public void InsertLoginDetail()
    {
        try
        {
            Object SaveUSERInfo = (Object)HttpContext.Current.Session["UserInfo"];
            string UserId = Convert.ToString(((UserInfo.structUSERInfo)(SaveUSERInfo)).UserId);
            string LoginId = HttpContext.Current.Session.SessionID.ToString();

            string Token = HttpContext.Current.Session["Token"].ToString();

            using (SqlConnection con = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]))
            {
                SqlCommand command = new SqlCommand("InsertLoginDetail12345", con);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@LOGIN_ID", UserId);
                command.Parameters.AddWithValue("@LOG_DET_ID", LoginId);


                con.Open();
                int i = command.ExecuteNonQuery();
                con.Close();
            }

        }
        catch (Exception ex)
        {

        }
    }
    public void InsertTokenDetail()
    {
        try
        {
            Object SaveUSERInfo = (Object)HttpContext.Current.Session["UserInfo"];
            string UserId = Convert.ToString(((UserInfo.structUSERInfo)(SaveUSERInfo)).UserId);
            string LoginId = HttpContext.Current.Session.SessionID.ToString();

            string Token = HttpContext.Current.Session["Token"].ToString();

            using (SqlConnection con = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]))
            {
                SqlCommand command = new SqlCommand("sp_InsertToken123", con);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@userid", UserId);
                command.Parameters.AddWithValue("@login_id", LoginId);
                command.Parameters.AddWithValue("@Token", Token);

                con.Open();
                int i = command.ExecuteNonQuery();
                con.Close();
            }

        }
        catch
        {

        }
    }
}