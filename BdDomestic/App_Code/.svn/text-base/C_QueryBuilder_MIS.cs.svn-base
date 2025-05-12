using System;
using System.Data;
using System.Data.OleDb;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

/// <summary>
/// Summary description for C_QueryBuilder_MIS
/// </summary>
public class C_QueryBuilder_MIS
{
    CCommon connobj = new CCommon();
	public C_QueryBuilder_MIS()
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
    public DataTable GetVerificationType_Altc()
    {
        DataTable dt = new DataTable();
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
        string str = "select * from Remark_Master where parent_type_code='DC'";
        dt = OleDbHelper.ExecuteDataset(con, CommandType.Text, str).Tables[0];
        con.Close();
        return dt;
    }
    public DataTable GetVerificationType_VV()
    {
        DataTable dt = new DataTable();
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
        string str = "SELECT VERIFICATION_TYPE_ID, VERIFICATION_TYPE_CODE FROM VERIFICATION_TYPE_MASTER "+
                     "WHERE PARENT_TYPE_CODE = 'VV' ORDER BY CONVERT(numeric(8), VERIFICATION_TYPE_ID)";
        dt = OleDbHelper.ExecuteDataset(con, CommandType.Text, str).Tables[0];
        con.Close();
        return dt;
    }
    public DataTable GetVerificationType_TV()
    {
        DataTable dt = new DataTable();
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
        string str = "SELECT VERIFICATION_TYPE_ID, VERIFICATION_TYPE_CODE FROM VERIFICATION_TYPE_MASTER " +
                     "WHERE PARENT_TYPE_CODE = 'TV' ORDER BY CONVERT(numeric(8), VERIFICATION_TYPE_ID)";
        dt = OleDbHelper.ExecuteDataset(con, CommandType.Text, str).Tables[0];
        con.Close();
        return dt;
    }

    public DataTable GetVerificationType_DV()
    {
        DataTable dt = new DataTable();
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
        string str = "SELECT VERIFICATION_TYPE_ID, VERIFICATION_TYPE_CODE FROM VERIFICATION_TYPE_MASTER " +
                     "WHERE PARENT_TYPE_CODE = 'DV' ORDER BY CONVERT(numeric(8), VERIFICATION_TYPE_ID)";
        dt = OleDbHelper.ExecuteDataset(con, CommandType.Text, str).Tables[0];
        con.Close();
        return dt;
    }
    // At This time it returns all centers...... 
    public DataTable GetCenters(string CenterId)
    {
        DataTable dt = new DataTable();
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
        string str = "SELECT CENTRE_ID, CENTRE_CODE, CENTRE_NAME FROM CENTRE_MASTER WHERE (CENTRE_ID in("+CenterId+"))ORDER BY CENTRE_ID";
        dt = OleDbHelper.ExecuteDataset(con, CommandType.Text, str).Tables[0];
        con.Close();
        return dt;
    }

    public DataTable GetCentersDcr(string client, string fdate, string tdate)
    {
        DataTable dt = new DataTable();
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
        //string str = "SELECT CENTRE_ID, CENTRE_CODE, CENTRE_NAME FROM CENTRE_MASTER WHERE (CENTRE_ID in(" + CenterId + "))ORDER BY CENTRE_ID";
        string str = "select distinct(res_city) from cpv_cc_case_details where client_id=" + client + " and convert(varchar,case_rec_datetime,103)>='" + fdate + "' and convert(varchar,case_rec_datetime,103)<'" + tdate + "'";
        dt = OleDbHelper.ExecuteDataset(con, CommandType.Text, str).Tables[0];
        con.Close();
        return dt;
    }
    public DataTable GetClients(string ClientId)
    {
        DataTable dt = new DataTable();
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
        string str = "SELECT CLIENT_ID, CLIENT_NAME FROM CLIENT_MASTER WHERE (CLIENT_ID IN ("+ClientId+"))";
        dt = OleDbHelper.ExecuteDataset(con, CommandType.Text, str).Tables[0];
        con.Close();
        return dt;
    }

    public string GetClientId(string CenterId)
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
        //End Of Code
        con.Open();
        OleDbParameter[] objParam = new OleDbParameter[1];
        objParam[0] = new OleDbParameter("UserType", OleDbType.VarChar, 50, "UserType");
        objParam[0].Value = CenterId;
        objParam[0].Direction = ParameterDirection.Input;

        OleDbDataReader Odr;
        Odr = OleDbHelper.ExecuteReader(con, CommandType.StoredProcedure, "GetClient", objParam);
        Odr.Read();
        while (Odr.Read())
        {
            ClientId = ClientId + ',' + Odr["CLIENT_ID"].ToString();
            // ClientId = ClientId + Odr["CLIENT_ID"].ToString();
        }
        //DataTable dt = new DataTable();
        //dt = OleDbHelper.ExecuteDataset(con, CommandType.StoredProcedure, "GetClient", objParam).Tables[0];
        ClientId = ClientId.TrimStart(',');
        return ClientId;

    }

 public int GetSum_VerificationType_CentreWise(string VerificationTypeId, string CentreId)
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
        //End Of Code
        con.Open();
        OleDbParameter[] Param = new OleDbParameter[4];
        Param[0] = new OleDbParameter("@VerificationType", OleDbType.VarChar, 10);
        Param[0].Value = VerificationTypeId;
        Param[0].Direction = ParameterDirection.Input;

        Param[1] = new OleDbParameter("@CentreId", OleDbType.VarChar, 10);
        Param[1].Value = CentreId;
        Param[1].Direction = ParameterDirection.Input;

        Param[2] = new OleDbParameter("@FromDate", OleDbType.VarChar, 10);
        Param[2].Value = strFromDate;
        Param[2].Direction = ParameterDirection.Input;

        Param[3] = new OleDbParameter("@ToDate", OleDbType.VarChar, 10);
        Param[3].Value = strToDate;
        Param[3].Direction = ParameterDirection.Input;

        int Sum =Convert.ToInt32(OleDbHelper.ExecuteScalar(con, CommandType.StoredProcedure, "GetSUM_VerificationType_Centre_Wise", Param));
        con.Close();
        return Sum;
    }
    public int GetSum_VerificationType_CentreWise_Dcr(string VerificationTypeId, string CentreId)
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
        //End Of Code
        con.Open();
        OleDbParameter[] Param = new OleDbParameter[4];
        Param[0] = new OleDbParameter("@VerificationType", OleDbType.VarChar, 10);
        Param[0].Value = VerificationTypeId;
        Param[0].Direction = ParameterDirection.Input;

        Param[1] = new OleDbParameter("@CentreId", OleDbType.VarChar, 10);
        Param[1].Value = CentreId;
        Param[1].Direction = ParameterDirection.Input;

        Param[2] = new OleDbParameter("@FromDate", OleDbType.VarChar, 10);
        Param[2].Value = strFromDate;
        Param[2].Direction = ParameterDirection.Input;

        Param[3] = new OleDbParameter("@ToDate", OleDbType.VarChar, 10);
        Param[3].Value = strToDate;
        Param[3].Direction = ParameterDirection.Input;

        int Sum = Convert.ToInt32(OleDbHelper.ExecuteScalar(con, CommandType.StoredProcedure, "GetSUM_VerificationType_Centre_Wise_Dcr", Param));
        con.Close();
        return Sum;
    }
    public int GetSum_VerificationType_ClientWise(string VerificationTypeId, string ClientId)
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
        //End Of Code
        con.Open();
        OleDbParameter[] Param = new OleDbParameter[4];
        Param[0] = new OleDbParameter("@VerificationType", OleDbType.VarChar, 10);
        Param[0].Value = VerificationTypeId;
        Param[0].Direction = ParameterDirection.Input;

        Param[1] = new OleDbParameter("@ClientId", OleDbType.VarChar, 10);
        Param[1].Value = ClientId;
        Param[1].Direction = ParameterDirection.Input;

        Param[2] = new OleDbParameter("@FromDate", OleDbType.VarChar, 10);
        Param[2].Value = strFromDate;
        Param[2].Direction = ParameterDirection.Input;

        Param[3] = new OleDbParameter("@ToDate", OleDbType.VarChar, 10);
        Param[3].Value = strToDate;
        Param[3].Direction = ParameterDirection.Input;

        int Sum = Convert.ToInt32(OleDbHelper.ExecuteScalar(con, CommandType.StoredProcedure, "GetSUM_VerificationType_Client_Wise", Param));
        con.Close();
        return Sum;
    }
      public int GetSum_VerificationType_ClientWise1(string VerificationTypeId, string ClientId,string CentreId)
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
        //End Of Code
        con.Open();
        OleDbParameter[] Param = new OleDbParameter[5];
        Param[0] = new OleDbParameter("@VerificationType", OleDbType.VarChar, 10);
        Param[0].Value = VerificationTypeId;
        Param[0].Direction = ParameterDirection.Input;

        Param[1] = new OleDbParameter("@ClientId", OleDbType.VarChar, 10);
        Param[1].Value = ClientId;
        Param[1].Direction = ParameterDirection.Input;

        Param[2] = new OleDbParameter("@CentreId", OleDbType.VarChar, 10);
        Param[2].Value = CentreId;
        Param[2].Direction = ParameterDirection.Input;

     
        Param[3] = new OleDbParameter("@FromDate", OleDbType.VarChar, 10);
        Param[3].Value = strFromDate;
        Param[3].Direction = ParameterDirection.Input;

        Param[4] = new OleDbParameter("@ToDate", OleDbType.VarChar, 10);
        Param[4].Value = strToDate;
        Param[4].Direction = ParameterDirection.Input;

       
        int Sum = Convert.ToInt32(OleDbHelper.ExecuteScalar(con, CommandType.StoredProcedure, "GetSUM_VerificationType_Client_Wise_New", Param));
        con.Close();
        return Sum;
    }

}












