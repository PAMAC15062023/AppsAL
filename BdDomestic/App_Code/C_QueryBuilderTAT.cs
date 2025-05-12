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
/// Summary description for C_QueryBuilderTAT
/// </summary>
public class C_QueryBuilderTAT
{
    CCommon connobj = new CCommon();
	public C_QueryBuilderTAT()
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


    public string GetCenter(string UserId)
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
        //End Of Code
        
        con.Open();
        OleDbParameter[] objParam = new OleDbParameter[1];
        objParam[0] = new OleDbParameter("UserType", OleDbType.VarChar, 8000, "UserType");
        objParam[0].Value = UserId;
        objParam[0].Direction = ParameterDirection.Input;

        DataTable dt = new DataTable();
        dt = OleDbHelper.ExecuteDataset(con, CommandType.StoredProcedure, "GetCentre", objParam).Tables[0];
        //OleDbDataReader Odr;
        //Odr = OleDbHelper.ExecuteReader(con, CommandType.StoredProcedure, "GetCentre", objParam);
        //Odr.Read();
        //while(Odr.Read())
        //{
        //    CenterID = CenterID + ',' + Odr["CENTRE_ID"].ToString();
        //    Odr.Read();
        //}
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            CenterID = CenterID + ',' + dt.Rows[i]["CENTRE_ID"].ToString();
        }
        CenterID = CenterID.TrimStart(',');
        return CenterID;
    }

    public DataTable Centers(string strCentreId)
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
        DataTable dt = new DataTable();
        OleDbTransaction trans = con.BeginTransaction();
        try
        {
            string str = "SELECT  '0' AS CENTRE_ID, 'Select Centre' AS CENTRE_NAME FROM CENTRE_MASTER "+
                         "UNION SELECT CENTRE_ID, CENTRE_NAME FROM CENTRE_MASTER WHERE CENTRE_ID in (" + strCentreId + ")";
            dt = OleDbHelper.ExecuteDataset(trans, CommandType.Text, str).Tables[0];
            trans.Commit();
            con.Close();
            return dt;
        }
        catch (Exception ex)
        {
            trans.Rollback();
            con.Close();
            throw new Exception("Error While Selecting Centers:", ex);
        }
    }
    public DataTable rptCentreWise(string CentreId)
    {
        CCommon ObjCommon=new CCommon();
        //Description   :  This Code is used To distingusish Repository PMS Database and PMS.
        //Created By    :  Gargi Srivastava
        //Created On    :  23-Nov-2007
        OleDbConnection con;
        //string Fdate = ObjCommon.string_mm_dd_yy(FromDate);
        //string Tdate = ObjCommon.string_mm_dd_yy(ToDate);
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
        OleDbParameter[] objParam = new OleDbParameter[3];
        objParam[0] = new OleDbParameter("@FromDate", OleDbType.VarChar, 50);
        objParam[0].Value ="'"+ FromDate+"'" ;
        objParam[0].Direction = ParameterDirection.Input;

        objParam[1] = new OleDbParameter("@ToDate", OleDbType.VarChar, 50);
        objParam[1].Value = "'"+ ToDate+"'" ;
        objParam[1].Direction = ParameterDirection.Input;

        objParam[2] = new OleDbParameter("@CentreId", OleDbType.VarChar, 8000);
        objParam[2].Value = CentreId ;
        objParam[2].Direction = ParameterDirection.Input;

        //OleDbDataReader Odr;
        //Odr = OleDbHelper.ExecuteReader(con, CommandType.StoredProcedure, "Tat_CentreWise", objParam);
        DataTable dt = new DataTable();
        dt = OleDbHelper.ExecuteDataset(con, CommandType.StoredProcedure, "Tat_CentreWise", objParam).Tables[0];
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
        objParam[0] = new OleDbParameter("UserType", OleDbType.VarChar, 8000, "UserType");
        objParam[0].Value = CenterId;
        objParam[0].Direction = ParameterDirection.Input;

        OleDbDataReader Odr;
        Odr = OleDbHelper.ExecuteReader(con, CommandType.StoredProcedure, "GetClient", objParam);
        Odr.Read();
        while (Odr.Read())
        {
            ClientId = ClientId + ',' + Odr["CLIENT_ID"].ToString();
        }
        //DataTable dt = new DataTable();
        //dt = OleDbHelper.ExecuteDataset(con, CommandType.StoredProcedure, "GetClient", objParam).Tables[0];
        ClientId = ClientId.TrimStart(',');
        return ClientId;
 
    }

    public DataTable rptClient_CentreWise(string ClientId,string CentreId)
    {
        CCommon ObjCommon = new CCommon();
        //Description   :  This Code is used To distingusish Repository PMS Database and PMS.
        //Created By    :  Gargi Srivastava
        //Created On    :  23-Nov-2007
        OleDbConnection con;
        try
        {
            //string Fdate = ObjCommon.string_mm_dd_yy(FromDate);
            //string Tdate = ObjCommon.string_mm_dd_yy(ToDate);
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
            OleDbParameter[] objParam = new OleDbParameter[4];
            objParam[0] = new OleDbParameter("@FromDate", OleDbType.VarChar, 50);
            objParam[0].Value = "'" + FromDate + "'";
            objParam[0].Direction = ParameterDirection.Input;

            objParam[1] = new OleDbParameter("@ToDate", OleDbType.VarChar, 50);
            objParam[1].Value = "'" + ToDate + "'";
            objParam[1].Direction = ParameterDirection.Input;

            objParam[2] = new OleDbParameter("@ClientId", OleDbType.VarChar, 8000);
            objParam[2].Value = ClientId;
            objParam[2].Direction = ParameterDirection.Input;

            objParam[3] = new OleDbParameter("@CentreId", OleDbType.VarChar, 8000);
            objParam[3].Value = CentreId;
            objParam[3].Direction = ParameterDirection.Input;

            //OleDbDataReader Odr;
            //Odr = OleDbHelper.ExecuteReader(con, CommandType.StoredProcedure, "Tat_Client_CentreWise ", objParam);
            DataTable dt = new DataTable();
            dt = OleDbHelper.ExecuteDataset(con, CommandType.StoredProcedure, "Tat_Client_CentreWise ", objParam).Tables[0];
            return dt;
        }
        catch (Exception ex)
        {
            throw new Exception("Error While Retrieving Data:", ex);
        }

    }


    public void rptClient_Centre_MonthWise(string FromDate, string ToDate, string ClientId)
    {
        CCommon ObjCommon = new CCommon();
        OleDbConnection con;
        string Fdate = ObjCommon.string_mm_dd_yy(FromDate);
        string Tdate = ObjCommon.string_mm_dd_yy(ToDate);
        //Description   :  This Code is used To distingusish Repository PMS Database and PMS.
        //Created By    :  Gargi Srivastava
        //Created On    :  23-Nov-2007
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
        //End OF Code
        con.Open();
        OleDbParameter[] objParam = new OleDbParameter[3];
        objParam[0] = new OleDbParameter("@FromDate", OleDbType.VarChar, 50);
        objParam[0].Value = "'" + Fdate + "'";
        objParam[0].Direction = ParameterDirection.Input;

        objParam[1] = new OleDbParameter("@ToDate", OleDbType.VarChar, 50);
        objParam[1].Value = "'" + Tdate + "'";
        objParam[1].Direction = ParameterDirection.Input;

        objParam[2] = new OleDbParameter("@ClientId ", OleDbType.VarChar, 50);
        objParam[2].Value = ClientId;
        objParam[2].Direction = ParameterDirection.Input;

        //OleDbDataReader Odr;
        DataSet ds = new DataSet();
        ds = OleDbHelper.ExecuteDataset(con, CommandType.StoredProcedure, "Tat_Client_Centre_MonthWise ", objParam);

    }


}
