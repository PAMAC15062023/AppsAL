using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.OleDb;

/// <summary>
/// Summary description for CResetPassword
/// </summary>
public class CResetPassword
{
    CCommon objcommon = new CCommon();
    OleDbConnection sqlcon;
    DataSet ds = new DataSet();    
	public CResetPassword()
	{
        sqlcon= new OleDbConnection(objcommon.ConnectionString);
        sqlcon.Open();
	}
    public DataSet GetRecords()
    {
        OleDbParameter[] oledbParam = new OleDbParameter[1];

        oledbParam[0] = new OleDbParameter("@DOLDate", OleDbType.Date, 10);
        oledbParam[0].Value = System.DateTime.Now;
        oledbParam[0].Direction = ParameterDirection.Input;

        ds = OleDbHelper.ExecuteDataset(sqlcon, CommandType.StoredProcedure, "SpLeavingEmployeeDetails", oledbParam);

        return ds;
    }
    public int UpdatePassword(string Password, string strUserId)
    {
        string sqlUser = "Update user_master set Password=? where UserId=?";

        OleDbParameter[] paramUserUpdate = new OleDbParameter[2];
        paramUserUpdate[0] = new OleDbParameter("Password", SqlDbType.NVarChar);
        paramUserUpdate[0].Value = CEncDec.Encrypt(Password, Password);
        paramUserUpdate[1] = new OleDbParameter("UserId", SqlDbType.VarChar);
        paramUserUpdate[1].Value = strUserId;

        int QueryReturn = OleDbHelper.ExecuteNonQuery(sqlcon, CommandType.Text, sqlUser, paramUserUpdate);
        if (QueryReturn > 0)
        {
            sqlUser = "Update Employee_Master set ResetPassword='1' where Emp_Id=?";

            OleDbParameter[] paramUser = new OleDbParameter[1];
            paramUser[0] = new OleDbParameter("UserId", SqlDbType.VarChar);
            paramUser[0].Value = strUserId;

          QueryReturn = OleDbHelper.ExecuteNonQuery(sqlcon, CommandType.Text, sqlUser, paramUser);
        }
        return QueryReturn;
    }
} 
