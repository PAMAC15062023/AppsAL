using System;
using System.Data;
using System.Data.OleDb;
using System.Data.OleDb;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;


/// <summary>
/// Summary description for C_QuerryBuilder_MIS_FE
/// </summary>
public class C_QuerryBuilder_MIS_FE
{
    CCommon connobj = new CCommon();
	public C_QuerryBuilder_MIS_FE()
	{
	}

    private string strFromDate;
    public string FromDate
    {
        get { return strFromDate; }
        set { strFromDate = value; }
    }

    private string strToDate;
    public string ToDate
    {
        get { return strToDate; }
        set { strToDate = value; }
    }
    private string strVerificationTypeWise;
    public string VerificationTypeWise
    {
        get { return strVerificationTypeWise; }
        set { strVerificationTypeWise = value; }
    }
    public DataTable GetCenter(string UserId)
    {
        string CenterID = "";
        //Description   :  This Code is used To distingusish Repository PMS Database and PMS.
        //Created By    :  Gargi Srivastava
        //Created On    :  23-Nov-2007
        OleDbConnection con;
        if (HttpContext.Current.Session["DataBase"] != null)
        {

            if (HttpContext.Current.Session["DataBase"].ToString() == "RepositoryPMS")
            {
                con = new OleDbConnection(connobj.RepositoryConnectionString);
            }
            else
            {
                con = new OleDbConnection(connobj.ConnectionString);
            }
        }
        else
        {
            con = new OleDbConnection(connobj.ConnectionString);
        }
        con.Open();
        OleDbParameter[] objParam = new OleDbParameter[1];
        objParam[0] = new OleDbParameter("UserType", OleDbType.VarChar, 50, "UserType");
        objParam[0].Value = UserId;
        objParam[0].Direction = ParameterDirection.Input;

        DataTable dt = new DataTable();
        dt = OleDbHelper.ExecuteDataset(con, CommandType.StoredProcedure, "GetCentre", objParam).Tables[0];
        con.Close();
        return dt;
    }

    public DataTable GetClient(string CenterId)
    {
        string ClientId = "";
        //Description   :  This Code is used To distingusish Repository PMS Database and PMS.
        //Created By    :  Gargi Srivastava
        //Created On    :  23-Nov-2007
        OleDbConnection con;
        if (HttpContext.Current.Session["DataBase"] != null)
        {

            if (HttpContext.Current.Session["DataBase"].ToString() == "RepositoryPMS")
            {
                con = new OleDbConnection(connobj.RepositoryConnectionString);
            }
            else
            {
                con = new OleDbConnection(connobj.ConnectionString);
            }
        }
        else
        {
            con = new OleDbConnection(connobj.ConnectionString);
        }
        con.Open();
        OleDbParameter[] objParam = new OleDbParameter[1];
        objParam[0] = new OleDbParameter("UserType", OleDbType.VarChar, 50, "UserType");
        objParam[0].Value = CenterId;
        objParam[0].Direction = ParameterDirection.Input;
        DataTable dt = new DataTable();
        dt = OleDbHelper.ExecuteDataset(con, CommandType.StoredProcedure, "GetClient", objParam).Tables[0];
        con.Close();
        return dt;
    }
    public string All_FE_Id()
    {
        string FE_Id="";
        //Description   :  This Code is used To distingusish Repository PMS Database and PMS.
        //Created By    :  Gargi Srivastava
        //Created On    :  23-Nov-2007
        OleDbConnection con;
        if (HttpContext.Current.Session["DataBase"] != null)
        {

            if (HttpContext.Current.Session["DataBase"].ToString() == "RepositoryPMS")
            {
                con = new OleDbConnection(connobj.RepositoryConnectionString);
            }
            else
            {
                con = new OleDbConnection(connobj.ConnectionString);
            }
        }
        else
        {
            con = new OleDbConnection(connobj.ConnectionString);
        }
        con.Open();
        OleDbDataReader Odr;
        //string str = " SELECT EMPLOYEE_MASTER.EMP_ID AS USER_ID, ISNULL(EMPLOYEE_MASTER.FIRSTNAME, '') + ' ' + ISNULL(EMPLOYEE_MASTER.MIDDLENAME, '') + ' ' + ISNULL(EMPLOYEE_MASTER.LASTNAME, '') AS NAME FROM EMPLOYEE_MASTER INNER JOIN USER_MASTER ON EMPLOYEE_MASTER.EMP_ID = USER_MASTER.USERID INNER JOIN DESIGNATION_MASTER ON EMPLOYEE_MASTER.DESIGNATION_ID = DESIGNATION_MASTER.DESIGNATION_ID WHERE (EMPLOYEE_MASTER.DESIGNATION_ID = '3') ";
        string str = "select emp_id as USER_ID,fullname AS NAME from fe_vw";
        //Odr = OleDbHelper.ExecuteReader(con, CommandType.Text, str);
        //Odr.Read();
        //while(Odr.Read())
        //{
        //    FE_Id = FE_Id + "," + Odr["USER_ID"].ToString();
        //    Odr.Read();
        //}
        DataTable dt = new DataTable();
        dt = OleDbHelper.ExecuteDataset(con, CommandType.Text, str).Tables[0];
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            FE_Id = FE_Id + "," + dt.Rows[i]["USER_ID"].ToString();
        }
        FE_Id = FE_Id.TrimStart(',');
        con.Close();
        //Odr.Close();
        return FE_Id;
    }

    public string All_VerificationType_Id()
    {
        string VerificationType_Id = "";
        //Description   :  This Code is used To distingusish Repository PMS Database and PMS.
        //Created By    :  Gargi Srivastava
        //Created On    :  23-Nov-2007
        OleDbConnection con;
        if (HttpContext.Current.Session["DataBase"] != null)
        {

            if (HttpContext.Current.Session["DataBase"].ToString() == "RepositoryPMS")
            {
                con = new OleDbConnection(connobj.RepositoryConnectionString);
            }
            else
            {
                con = new OleDbConnection(connobj.ConnectionString);
            }
        }
        else
        {
            con = new OleDbConnection(connobj.ConnectionString);
        }
        //End Of Code
        con.Open();
        OleDbDataReader Odr;
        string str = "  SELECT DISTINCT CONVERT(numeric(30), CASE_TRANSACTION_LOG.VERIFICATION_TYPE_ID) as VERIFICATION_TYPE_ID, VERIFICATION_TYPE_MASTER.VERIFICATION_TYPE_CODE " +
                     "  FROM VERIFICATION_TYPE_MASTER INNER JOIN "+
                     "  CASE_TRANSACTION_LOG ON VERIFICATION_TYPE_MASTER.VERIFICATION_TYPE_ID = CASE_TRANSACTION_LOG.VERIFICATION_TYPE_ID "+
                     "  ORDER BY CONVERT(numeric(30), CASE_TRANSACTION_LOG.VERIFICATION_TYPE_ID) ";
        Odr = OleDbHelper.ExecuteReader(con, CommandType.Text, str);
        Odr.Read();
        while (Odr.Read())
        {
            VerificationType_Id = VerificationType_Id + "," + Odr["VERIFICATION_TYPE_ID"].ToString();
        }
        VerificationType_Id = VerificationType_Id.TrimStart(',');
        con.Close();
        Odr.Close();
        return VerificationType_Id;
    }
    public DataTable rpt_ProductivityMIS(string CentreId,string ClientId,string UserId)
    {
        //Description   :  This Code is used To distingusish Repository PMS Database and PMS.
        //Created By    :  Gargi Srivastava
        //Created On    :  23-Nov-2007
        OleDbConnection con;
        if (HttpContext.Current.Session["DataBase"] != null)
        {

            if (HttpContext.Current.Session["DataBase"].ToString() == "RepositoryPMS")
            {
                con = new OleDbConnection(connobj.RepositoryConnectionString);
            }
            else
            {
                con = new OleDbConnection(connobj.ConnectionString);
            }
        }
        else
        {
            con = new OleDbConnection(connobj.ConnectionString);
        }
       //End of Code
        con.Open();
        OleDbParameter[] objParam = new OleDbParameter[5];
        objParam[0] = new OleDbParameter("@FromDate", OleDbType.VarChar, 20);
        objParam[0].Value = "'" + strFromDate + "'";
        objParam[0].Direction = ParameterDirection.Input;

        objParam[1] = new OleDbParameter("@ToDate", OleDbType.VarChar, 20);
        objParam[1].Value = "'" + strToDate + "'";
        objParam[1].Direction = ParameterDirection.Input;

        objParam[2] = new OleDbParameter("@CentreId ", OleDbType.VarChar, 8000);
        objParam[2].Value = CentreId;
        objParam[2].Direction = ParameterDirection.Input;

        objParam[3] = new OleDbParameter("@ClientId ", OleDbType.VarChar, 8000);
        objParam[3].Value = ClientId;
        objParam[3].Direction = ParameterDirection.Input;

        objParam[4] = new OleDbParameter("@UserId ", OleDbType.VarChar, 8000);
        objParam[4].Value = UserId;
        objParam[4].Direction = ParameterDirection.Input;

        //OleDbDataReader Odr;
        //Odr = OleDbHelper.ExecuteReader(con, CommandType.StoredProcedure, "MIS_FE", objParam); 
        DataTable dt = new DataTable();
        dt = OleDbHelper.ExecuteDataset(con, CommandType.StoredProcedure, "MIS_FE", objParam).Tables[0]; 
        con.Close();
        return dt;
    }
    public DataTable rpt_VerificationTypeWise_MIS(string UserId,string VerificationTypeWise)
    {
        //Description   :  This Code is used To distingusish Repository PMS Database and PMS.
        //Created By    :  Gargi Srivastava
        //Created On    :  23-Nov-2007
        OleDbConnection con;
        if (HttpContext.Current.Session["DataBase"] != null)
        {

            if (HttpContext.Current.Session["DataBase"].ToString() == "RepositoryPMS")
            {
                con = new OleDbConnection(connobj.RepositoryConnectionString);
            }
            else
            {
                con = new OleDbConnection(connobj.ConnectionString);
            }
        }
        else
        {
            con = new OleDbConnection(connobj.ConnectionString);
        }
        //End of Code
        con.Open();
        OleDbParameter[] objParam = new OleDbParameter[4];
        objParam[0] = new OleDbParameter("@FromDate", OleDbType.VarChar, 20);
        objParam[0].Value = "'" + strFromDate + "'";
        objParam[0].Direction = ParameterDirection.Input;

        objParam[1] = new OleDbParameter("@ToDate", OleDbType.VarChar, 20);
        objParam[1].Value = "'" + strToDate + "'";
        objParam[1].Direction = ParameterDirection.Input;

        objParam[2] = new OleDbParameter("@UserId ", OleDbType.VarChar, 8000);
        objParam[2].Value = UserId;
        objParam[2].Direction = ParameterDirection.Input;

        objParam[3] = new OleDbParameter("@VERIFICATION_TYPE_ID ", OleDbType.VarChar, 1000);
        objParam[3].Value = VerificationTypeWise;
        objParam[3].Direction = ParameterDirection.Input;

        //OleDbDataReader Odr;
        //Odr = OleDbHelper.ExecuteReader(con, CommandType.StoredProcedure, "MIS_FE", objParam); 
        DataTable dt = new DataTable();
        dt = OleDbHelper.ExecuteDataset(con, CommandType.StoredProcedure, "VerificationTypeWiseMIS ", objParam).Tables[0];
        con.Close();
        return dt;
    }
    public DataTable rpt(string CentreId, string ClientId, string UserId)
    {
        //Description   :  This Code is used To distingusish Repository PMS Database and PMS.
        //Created By    :  Gargi Srivastava
        //Created On    :  23-Nov-2007
        OleDbConnection con;
        if (HttpContext.Current.Session["DataBase"] != null)
        {

            if (HttpContext.Current.Session["DataBase"].ToString() == "RepositoryPMS")
            {
                con = new OleDbConnection(connobj.RepositoryConnectionString);
            }
            else
            {
                con = new OleDbConnection(connobj.ConnectionString);
            }
        }
        else
        {
            con = new OleDbConnection(connobj.ConnectionString);
        }
        //End of Code
        con.Open();
        DataTable dt = new DataTable();
        string str = "SELECT CASE_TRANSACTION_LOG.CASE_ID, CASE_TRANSACTION_LOG.USER_ID, CASE_TRANSACTION_LOG.CLIENT_ID, EMPLOYEE_MASTER.FIRSTNAME, " +
                     " CASE_TRANSACTION_LOG.TRANS_START, CASE_TRANSACTION_LOG.TRANS_END, CLIENT_MASTER.CLIENT_NAME, " +
                     " CENTRE_MASTER.CENTRE_NAME " +
                     " FROM  CASE_TRANSACTION_LOG INNER JOIN " +
                     " EMPLOYEE_MASTER ON CASE_TRANSACTION_LOG.USER_ID = EMPLOYEE_MASTER.EMP_ID INNER JOIN " +
                     " CLIENT_MASTER ON CASE_TRANSACTION_LOG.CLIENT_ID = CLIENT_MASTER.CLIENT_ID INNER JOIN " +
                     " CENTRE_MASTER ON CASE_TRANSACTION_LOG.CENTRE_ID = CENTRE_MASTER.CENTRE_ID " +
                     " WHERE (CLIENT_MATER.CLIENT_ID IN (" + ClientId + ")) AND (CASE_TRANSACTION_LOG.CENTRE_ID = " + CentreId + ") AND (CASE_TRANSACTION_LOG.USER_ID IN (" + UserId + "))" +
                     "AND (CASE_TRANSACTION_LOG.TRANS_END >="+FromDate+") AND (CASE_TRANSACTION_LOG.TRANS_END < "+ToDate+")";
        dt = OleDbHelper.ExecuteDataset(con, CommandType.Text, str).Tables[0];

        con.Close();
        return dt;

    }

    public DataTable AllDEO()
    {
        //Description   :  This Code is used To distingusish Repository PMS Database and PMS.
        //Created By    :  Gargi Srivastava
        //Created On    :  23-Nov-2007
        OleDbConnection con;
        if (HttpContext.Current.Session["DataBase"] != null)
        {

            if (HttpContext.Current.Session["DataBase"].ToString() == "RepositoryPMS")
            {
                con = new OleDbConnection(connobj.RepositoryConnectionString);
            }
            else
            {
                con = new OleDbConnection(connobj.ConnectionString);
            }
        }
        else
        {
            con = new OleDbConnection(connobj.ConnectionString);
        }
        //End of Code
        con.Open();
        string strGetALLDEO = " SELECT '0' AS USER_ID, '--All DEO--' AS NAME FROM         EMPLOYEE_MASTER AS A INNER JOIN "+
                              " USER_ROLE AS C ON A.EMP_ID = C.USER_ID INNER JOIN ROLE_MASTER AS B ON C.ROLE_ID = B.ROLE_ID "+
                              " UNION "+
                              " SELECT C.USER_ID, ISNULL(A.FIRSTNAME + ' ', '') + ISNULL(A.MIDDLENAME + ' ', '') + ISNULL(A.LASTNAME + ' ', '') AS NAME "+
                              " FROM EMPLOYEE_MASTER AS A INNER JOIN USER_ROLE AS C ON A.EMP_ID = C.USER_ID INNER JOIN "+
                              " ROLE_MASTER AS B ON C.ROLE_ID = B.ROLE_ID WHERE     (B.ROLE_CODE = 'DE') ORDER BY NAME";
        DataTable dt = new DataTable();
        dt = OleDbHelper.ExecuteDataset(con, CommandType.Text, strGetALLDEO).Tables[0]; 
        con.Close();
        return dt;
    }



}
