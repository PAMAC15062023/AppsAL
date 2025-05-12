using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for CommonMaster
/// </summary>
public class CommonMaster
{
    public CommonMaster()
    {
        //
        // TODO: Add constructor logic here
        //

    }
    public int UserLogOut(string UserId)
    {
        int IsValid = 0;
        try
        {
            SqlConnection sqlCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);

            SqlCommand sqlCom = new SqlCommand();
            sqlCom.Connection = sqlCon;
            sqlCom.CommandType = CommandType.StoredProcedure;
            sqlCom.CommandText = "LNT_UserLogOut";

            SqlParameter LoginName = new SqlParameter();
            LoginName.SqlDbType = SqlDbType.VarChar;
            LoginName.Value = UserId;
            LoginName.ParameterName = "@LoginName";
            sqlCom.Parameters.Add(LoginName);

            sqlCon.Open();
            int Result = sqlCom.ExecuteNonQuery();
            sqlCon.Close();

            if (Result > 0)
            {
                IsValid = 1;
            }
        }
        catch (Exception ex)
        {
            ex.ToString();
        }
        return IsValid;
    }
    public void UpdateLastLogin(string UserId)
    {
        try
        {
            SqlConnection sqlCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);

            SqlCommand sqlCom = new SqlCommand();
            sqlCom.Connection = sqlCon;
            sqlCom.CommandType = CommandType.StoredProcedure;
            sqlCom.CommandText = "LNT_UpdateLastLogin";

            SqlParameter LoginName = new SqlParameter();
            LoginName.SqlDbType = SqlDbType.VarChar;
            LoginName.Value = UserId;
            LoginName.ParameterName = "@LoginName";
            sqlCom.Parameters.Add(LoginName);

            sqlCon.Open();
            sqlCom.ExecuteNonQuery();
            sqlCon.Close();

        }
        catch (Exception ex)
        {
            ex.ToString();
        }
    }
}