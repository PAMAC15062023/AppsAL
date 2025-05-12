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
/// Summary description for C_GeneralQuery
/// </summary>
public class C_GeneralQuery
{
    CCommon objconn = new CCommon();
	public C_GeneralQuery()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public DataSet SelectSavedQuery(string centreID,string userID)
    {
        string sSql = "";
        OleDbDataAdapter oledbDa;
        try
        {
            sSql = "select QM.Query_ID,QM.Query_Defination as Query_Name " +
                    "from ASSIGN_QUERY as AQ " +
                    "inner join QUERY_MASTER as QM on AQ.Query_ID=QM.Query_ID " +
                    "inner join CENTRE_MASTER as CM on AQ.Centre_ID=CM.CENTRE_ID " +
                    "inner join EMPLOYEE_MASTER as EM on AQ.EMP_ID=EM.EMP_ID " +
                    "where AQ.Emp_Id='" + userID + "'" + " and AQ.Centre_ID='" + centreID + "' " +
                    "and QM.Query_Type=0 ";
            if (HttpContext.Current.Session["DataBase"] != null)
            {

                if (HttpContext.Current.Session["DataBase"].ToString() == "RepositoryPMS")
                {
                     oledbDa = new OleDbDataAdapter(sSql, objconn.RepositoryConnectionString);
                }
                else
                {
                    oledbDa = new OleDbDataAdapter(sSql, objconn.ConnectionString);
                }
            }
            else
            {
                oledbDa = new OleDbDataAdapter(sSql, objconn.ConnectionString);
            }

            
            DataSet ds = new DataSet();
            oledbDa.Fill(ds, "SelectSavedQuery");
            return ds;
        }
        catch (Exception ex)
        {
            throw new Exception("Error Found During AppCode/CBuildQuery/SelectUsers Method" + ex.Message);
        }
    }
    public OleDbDataReader ReadQueryType(string queryID)
    {
        string sSql = "";
        try
        {
            sSql = " Select Query_Type " +
                   " from QUERY_MASTER where Query_ID='" + queryID + "'";
            if (HttpContext.Current.Session["DataBase"] != null)
            {

                if (HttpContext.Current.Session["DataBase"].ToString() == "RepositoryPMS")
                {
                    return OleDbHelper.ExecuteReader(objconn.RepositoryConnectionString, CommandType.Text, sSql);
                }
                else
                {
                    return OleDbHelper.ExecuteReader(objconn.ConnectionString, CommandType.Text, sSql);
                }
            }
            else
            {
                return OleDbHelper.ExecuteReader(objconn.ConnectionString, CommandType.Text, sSql);
            }

          
        }
        catch (Exception ex)
        {
            throw new Exception("Error Found During AppCode/CBuildQuery/ReadQueryRecords Method" + ex.Message);
        }


    }
    public OleDbDataReader ReadData(string queryID,string queryType)
    {
        string sSql = "";
        try
        {
            sSql = " Select Query_Text_File,Is_Creteria,Alias " +
                   " from QUERY_MASTER where Query_ID='" + queryID + "'" +
                   " and Query_Type='" + queryType + "'";

            if (HttpContext.Current.Session["DataBase"] != null)
            {

                if (HttpContext.Current.Session["DataBase"].ToString() == "RepositoryPMS")
                {
                    return OleDbHelper.ExecuteReader(objconn.RepositoryConnectionString, CommandType.Text, sSql);
                }
                else
                {
                    return OleDbHelper.ExecuteReader(objconn.ConnectionString, CommandType.Text, sSql);
                }
            }
            else
            {
                return OleDbHelper.ExecuteReader(objconn.ConnectionString, CommandType.Text, sSql);
            }
            
        }
        catch (Exception ex)
        {
            throw new Exception("Error Found During AppCode/CBuildQuery/ReadQueryRecords Method" + ex.Message);
        }


    }

    public DataSet ExecuteQuery(string query)
    {
        string sSql = "";
        try
        {
            DataTable dt = new DataTable();
            sSql = query;
            OleDbDataAdapter oledbDa;
            if (HttpContext.Current.Session["DataBase"] != null)
            {

                if (HttpContext.Current.Session["DataBase"].ToString() == "RepositoryPMS")
                {
                    oledbDa = new OleDbDataAdapter(sSql, objconn.RepositoryConnectionString);
                }
                else
                {
                    oledbDa = new OleDbDataAdapter(sSql, objconn.ConnectionString);
                }
            }
            else
            {
                oledbDa = new OleDbDataAdapter(sSql, objconn.ConnectionString);
            }
            
            DataSet ds = new DataSet();
            oledbDa.Fill(ds, "ExecuteQuery");
            //dt = ds.Tables["ExecuteQuery"];
            return ds;
        }
        catch (Exception ex)
        {
            throw new Exception("Error found During AppCode/CBuildQuery/Execute Query Method" + ex.Message);
        }


    }

    public string AppendQuery(string QueryText, string strAlias, string strFromDate, string strToDate, string strDateField)
    {
        string strSQL = string.Empty;
        try
        {
            
                strSQL = QueryText.Trim();
                strSQL = strSQL.Replace("@ONWHICHDATE", strAlias + "." + strDateField);
                strSQL = strSQL.Replace("@FROMDATE", "'" + strFromDate + "'");
                strSQL = strSQL.Replace("@TODATE", "'" + strToDate + "'");

            
            return strSQL;
        }
        catch (Exception ex)
        {
            throw new Exception("Error found During AppCode/CBuildQuery/Append Query Method" + ex.Message);
        }


    }

    


}
