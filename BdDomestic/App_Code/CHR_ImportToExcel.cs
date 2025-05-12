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
/// Summary description for CHR_ImportToExcel
/// </summary>
public class CHR_ImportToExcel
{
    CCommon objconn = new CCommon();
	public CHR_ImportToExcel()
	{
		//
		// TODO: Add constructor logic here
		//
    }
    public bool CheckFirstUser()
    {
        bool chkUser = false;
        try
        {
            OleDbConnection sqlConn = new OleDbConnection(objconn.ConnectionString);
            string strChkEmp = "SELECT COUNT(EMP_CODE) FROM EMPLOYEE_MASTER";
            OleDbCommand sqlCmd = new OleDbCommand(strChkEmp, sqlConn);

            sqlConn.Open();
            int i = (int)sqlCmd.ExecuteScalar();
            sqlConn.Close();

            if (i > 0)
            {
                chkUser = true;
            }
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
        return chkUser;
    }

    public string SelMaxEmpId()
    {
        string strEmpMaxId = "";
        OleDbConnection sqlConn = new OleDbConnection(objconn.ConnectionString);
        try
        {
            bool chkUser = (bool)CheckFirstUser();
            if (chkUser == true)
            {
                string strSqlMaxId = "SELECT MAX(EMP_ID) FROM EMPLOYEE_MASTER";
                OleDbCommand sqlCmd = new OleDbCommand(strSqlMaxId, sqlConn);

                sqlConn.Open();
                strEmpMaxId = sqlCmd.ExecuteScalar().ToString();
                sqlConn.Close();
            }
            else
            {
                strEmpMaxId = "1010";
            }

        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
        return strEmpMaxId;

    }

    public DataSet CheckEmpExistence(string strEmpCode)
    {
        DataSet ds = null;
        OleDbConnection sqlConn = new OleDbConnection(objconn.ConnectionString);
        try
        {
            string strSqlSelectEmp = "SELECT EMP_ID FROM EMPLOYEE_MASTER WHERE EMP_CODE='" + strEmpCode + "'";
            OleDbDataAdapter sqlDa = new OleDbDataAdapter(strSqlSelectEmp, sqlConn);
            ds = new DataSet();
            sqlDa.Fill(ds, "EMPLOYEE_MASTER");
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
        return ds;
    }

    public string CreateCustomeEmpId(string strCustID)
    {
        string strCustId = "";
      
        try
        {
            if (strCustID != "")
            {
                string strPrifix = strCustID.Substring(0, 3).ToString();
                string strSufix = strCustID.Substring(3).ToString();

                strCustId = strPrifix + (Convert.ToInt64(strSufix) + 1);
            }
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
        return strCustId;
    }
}
