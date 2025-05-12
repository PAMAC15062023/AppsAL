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
    public DataSet GetCommonMaster(string LoanType, string FieldName, int Level1, int Level2, int Level3, int Level4)
    {
        SqlConnection sqlCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);

        SqlCommand cmd = new SqlCommand("YBL_getcommonmaster", sqlCon);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@Loan_type", LoanType);
        cmd.Parameters.AddWithValue("@Field_name", FieldName);
        cmd.Parameters.AddWithValue("@Level_1", Level1);
        cmd.Parameters.AddWithValue("@Level_2", Level2);
        cmd.Parameters.AddWithValue("@Level_3", Level3);
        cmd.Parameters.AddWithValue("@Level_4", Level4);
        SqlDataAdapter adp = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        adp.Fill(ds);
        return ds;
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
            sqlCom.CommandText = "YBL_UserLogOut";

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

        }

        return IsValid;
    }

}