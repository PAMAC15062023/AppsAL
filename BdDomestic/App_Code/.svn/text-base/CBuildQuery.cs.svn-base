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
/// Summary description for CBuildQuery
/// Made by : Gargi Srivastava at 29-OCt-2007
/// Purpose : Class for Performing Various Get Methods ans Insert and Update 
/// Methods for Query Definitions
/// </summary>
public class CBuildQuery
{
    CCommon objConn = new CCommon();
	public CBuildQuery()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    private Int32 queryID;
    public Int32 QueryID
    {
        get
        {
            return queryID;
        }
        set
        {
            queryID = value;
        }
    }
    private Int32 assignID;
    public Int32 AssignID
    {
        get
        {
            return assignID;
        }
        set
        {
            assignID = value;
        }
    }
    private string queryDefination;
    public string QueryDefination
    {
        get
        {
            return queryDefination;
        }
        set
        {
            queryDefination = value;
        }
    }
    private string queryType;
    public string QueryType
    {
        get
        {
            return queryType;
        }
        set
        {
            queryType = value;
        }
    }
    private string queryText;
    public string QueryText
    {
        get
        {
            return queryText;
        }
        set
        {
            queryText = value;
        }
    }
    private string isCreteria;
    public string IsCreteria
    {
        get
        {
            return isCreteria;
        }
        set
        {
            isCreteria = value;
        }
    }

    private string alias;
    public string Alias
    {
        get
        {
            return alias;
        }
        set
        {
            alias = value;
        }
    }
    private string addedBy;
    public string AddedBy
    {
        get
        {
            return addedBy;
        }
        set
        {
            addedBy = value;
        }
    }
    private string modifiedBy;
    public string ModifiedBy
    {
        get
        {
            return modifiedBy;
        }
        set
        {
            modifiedBy = value;
        }
    }

    private string addedDate;
    public string AddedDate
    {
        get
        {
            return addedDate;
        }
        set
        {
            addedDate = value;
        }
    }
    private string modifiedDate;
    public string ModifiedDate
    {
        get
        {
            return modifiedDate;
        }
        set
        {
            modifiedDate = value;
        }
    }
    private string userID;
    public string UserID
    {
        get
        {
            return userID;
        }
        set
        {
            userID = value;
        }
    }

    private string userName;
    public string UserName
    {
        get
        {
            return userName;
        }
        set
        {
            userName = value;
        }
    }

    private string centreID;
    public string CentreID
    {
        get
        {
            return centreID;
        }
        set
        {
            centreID = value;
        }
    }

    public string InsertQuery()
    {
        OleDbConnection oledbConn = new OleDbConnection(objConn.ConnectionString);
        oledbConn.Open();
        OleDbTransaction oledbTrans = oledbConn.BeginTransaction();
        OleDbDataReader objoledbDR;
        String sqlSelectQuery = "";
        String sqlQuery = "";
        string msg = "";
      

        try
        {
            //////////////////////////////Inserting in table QUERY_MASTER
            
            sqlSelectQuery = "Select Query_Defination from QUERY_MASTER "+
                               "where Query_Defination='" + QueryDefination + "'" ;
            objoledbDR = OleDbHelper.ExecuteReader(objConn.ConnectionString, CommandType.Text, sqlSelectQuery);
            OleDbParameter[] oledbParam = new OleDbParameter[7];

            if (objoledbDR.Read() == false)
            {
                sqlQuery = " Insert into QUERY_MASTER (Query_Defination,Query_Type,Query_Text_File, " +
                           " Is_Creteria,Alias,Added_By,Added_Date) "+
                           " Values(?,?,?,?,?,?,?)";

                
                oledbParam[0] = new OleDbParameter("@QueryDefination", OleDbType.VarChar, 100);
                oledbParam[0].Value = QueryDefination;

                oledbParam[1] = new OleDbParameter("@QueryType", OleDbType.VarChar, 1);
                oledbParam[1].Value = QueryType;

                oledbParam[2] = new OleDbParameter("@QueryTextFile", OleDbType.VarChar, 110);
                oledbParam[2].Value = QueryText ;

                oledbParam[3] = new OleDbParameter("@IsCreteria", OleDbType.VarChar, 1);
                oledbParam[3].Value = IsCreteria;
              
                oledbParam[4] = new OleDbParameter("@Alias", OleDbType.VarChar, 50);
                oledbParam[4].Value = Alias;

                oledbParam[5] = new OleDbParameter("@AddedBy", OleDbType.VarChar, 20);
                oledbParam[5].Value = AddedBy;

                oledbParam[6] = new OleDbParameter("@AddedDate", OleDbType.DBTimeStamp, 8);
                oledbParam[6].Value = AddedDate;

                msg="Record Saved Sucessfully.";
                OleDbHelper.ExecuteNonQuery(oledbTrans, CommandType.Text, sqlQuery, oledbParam);
                oledbTrans.Commit();
                oledbConn.Close();

            }
            else
            {
               msg="Query Definition Already Exist.";
            }
           
            return msg;
        }
        catch (Exception ex)
        {
            oledbTrans.Rollback();
            oledbConn.Close();
            throw new Exception("Error found During AppCode/CBuildQuery/InsertQuery" + ex.Message);

        }

    }

    public string UpdateQuery()
    {
        OleDbConnection oledbConn = new OleDbConnection(objConn.ConnectionString);
        oledbConn.Open();
        OleDbTransaction oledbTrans = oledbConn.BeginTransaction();
        
        String sqlQuery = "";
        string msg = "";


        try
        {
            //////////////////////////////Updating in table QUERY_MASTER

            
            OleDbParameter[] oledbParam = new OleDbParameter[7];


            sqlQuery = "Update QUERY_MASTER set Query_Defination=?,Query_Text_File=?, " +
                       " Alias=?,Modified_By=?,Modified_Date=?,Is_Creteria=? where Query_ID=? ";
                           


                oledbParam[0] = new OleDbParameter("@QueryDefination", OleDbType.VarChar, 100);
                oledbParam[0].Value = QueryDefination;

                oledbParam[1] = new OleDbParameter("@QueryTextFile", OleDbType.VarChar, 110);
                oledbParam[1].Value = QueryText;

                oledbParam[2] = new OleDbParameter("@Alias", OleDbType.VarChar, 50);
                oledbParam[2].Value = Alias;

                oledbParam[3] = new OleDbParameter("@AddedBy", OleDbType.VarChar, 20);
                oledbParam[3].Value = AddedBy;

                oledbParam[4] = new OleDbParameter("@AddedDate", OleDbType.DBTimeStamp, 8);
                oledbParam[4].Value = AddedDate;

                oledbParam[5] = new OleDbParameter("@IsCreteria", OleDbType.VarChar, 1);
                oledbParam[5].Value = IsCreteria;

                oledbParam[6] = new OleDbParameter("@QueryID", OleDbType.Integer, 4);
                oledbParam[6].Value = QueryID;

                msg = "Record Updated Sucessfully.";

           
           
            OleDbHelper.ExecuteNonQuery(oledbTrans, CommandType.Text, sqlQuery, oledbParam);
            oledbTrans.Commit();
            oledbConn.Close();
            return msg;
        }
        catch (Exception ex)
        {
            oledbTrans.Rollback();
            oledbConn.Close();
            throw new Exception("Error found During AppCode/CBuildQuery/UpdateQuery" + ex.Message);

        }

    }

    public string DeleteQuery(string queryID)
    {
        OleDbConnection oledbConn = new OleDbConnection(objConn.ConnectionString);
        oledbConn.Open();
        OleDbTransaction oledbTrans = oledbConn.BeginTransaction();
        OleDbDataReader objoledbDR;
        OleDbDataReader objoledbDR1;
        string sqlSelectQuery = "";
        string sqlSelectQuery1 = "";
        String sqlQuery = "";
        string query = "";
        string msg = "";



        sqlSelectQuery = "Select Query_ID from QUERY_MASTER " +
                               "where Query_ID='" + queryID + "'" + " and Query_Type='0'";
        objoledbDR = OleDbHelper.ExecuteReader(objConn.ConnectionString, CommandType.Text, sqlSelectQuery);

        sqlSelectQuery1 = "Select Query_ID from ASSIGN_QUERY " +
                          "where Query_ID='" + queryID + "'" ;
        objoledbDR1 = OleDbHelper.ExecuteReader(objConn.ConnectionString, CommandType.Text, sqlSelectQuery1);

        try
        {
            if (objoledbDR.Read())
            {

                sqlQuery = " Delete QUERY_MASTER where Query_ID='" + queryID + "'" + " and Query_Type='0'";
                if (objoledbDR1.Read())
                {
                    query = " Delete ASSIGN_QUERY where Query_ID='" + queryID + "'";
                    OleDbHelper.ExecuteNonQuery(oledbTrans, CommandType.Text, query);
                }
                msg = "Record Deleted Sucessfully.";
                OleDbHelper.ExecuteNonQuery(oledbTrans, CommandType.Text, sqlQuery);
                oledbTrans.Commit();
                oledbConn.Close();

            }
            else
            {
                msg = "Record Can't Be Deleted";
            }

  
            return msg;
        }
        catch (Exception ex)
        {
            oledbTrans.Rollback();
            oledbConn.Close();
            throw new Exception("Error found During AppCode/CBuildQuery/DeleteQuery" + ex.Message);

        }


    }


    public string AppendQuery(string QueryText, bool isCriteria, string strAlias, string strFromDate, string strToDate, string strDateField)
    {
        string strSQL = string.Empty;
        try
        {
            if (isCriteria == true)
            {
                strSQL = QueryText.Trim();
                strSQL = strSQL.Replace("@ONWHICHDATE", strAlias + "." + strDateField);
                strSQL = strSQL.Replace("@FROMDATE", "'" + strFromDate + "'");
                strSQL = strSQL.Replace("@TODATE", "'" + strToDate + "'");

            }
            return strSQL;
        }
        catch (Exception ex)
        {
            throw new Exception("Error found During AppCode/CBuildQuery/Append Query Method" + ex.Message);
        }
        

    }

    public DataSet ExecuteQuery(string query)
    {
        string sSql = "";
        try
        {
            DataTable dt = new DataTable();
            sSql = query;
            OleDbDataAdapter oledbDa = new OleDbDataAdapter(sSql, objConn.ConnectionString);
            DataSet ds = new DataSet();
            oledbDa.Fill(ds, "ExecuteQuery");
            return ds;
        }
        catch (Exception ex)
        {
            throw new Exception("Error found During AppCode/CBuildQuery/Execute Query Method" + ex.Message);
        }
        

    }

    public DataTable SearchQuery()
    {
        string sSql = "";
        try
        {
            DataTable dtSearch = new DataTable();
            sSql = "Select Query_Text_File,Query_ID,Query_Defination as [Query Defination],Added_Date as [Created Date] from QUERY_MASTER  " +
                   "WHERE QUERY_TYPE='0'";
            if ((AddedDate != "") && (AddedDate != null))
            {
                sSql += " AND Added_Date >='" + AddedDate + "'";
                if ((QueryDefination != "") && (QueryDefination != null))
                {
                    sSql += " and Query_Defination like '%" + objConn.FixQuotes(QueryDefination) + "%'";
                }
            }
            else if ((QueryDefination != "") && (QueryDefination != null))
            {
                sSql += " AND Query_Defination like '%" + objConn.FixQuotes(QueryDefination) + "%'";
                if ((AddedDate != "") && (AddedDate != null))
                {
                    sSql += " and Added_Date >='" + AddedDate + "'";
                }
            }
            sSql += " Order BY Query_Defination DESC";

            OleDbDataAdapter oledbDA = new OleDbDataAdapter(sSql, objConn.ConnectionString);
            DataSet ds = new DataSet();
            oledbDA.Fill(ds, "Search");
            dtSearch = ds.Tables["Search"];
            return dtSearch;
        }
        catch (Exception ex)
        {
            throw new Exception("Error Found During AppCode/CBuildQuery/SearchQuery Method" + ex.Message);
        }

    }

    public OleDbDataReader ReadQueryRecords(string queryID)
    {
        string sSql = "";
        try
        {
            sSql = "Select Query_Defination,Query_Text_File,Is_Creteria,Alias from QUERY_MASTER where Query_ID='" + queryID + "'";
            return OleDbHelper.ExecuteReader(objConn.ConnectionString, CommandType.Text, sSql);
        }
        catch (Exception ex)
        {
            throw new Exception("Error Found During AppCode/CBuildQuery/ReadQueryRecords Method" + ex.Message);
        }

         
    }

    public DataSet SelectQuery()
    {
        string sSql = "";
        try
        {
            sSql = "Select Query_ID,Query_Defination from QUERY_MASTER";
            OleDbDataAdapter oledbDa = new OleDbDataAdapter(sSql, objConn.ConnectionString);
            DataSet ds = new DataSet();
            oledbDa.Fill(ds, "SelectQuery");
            return ds;
        }
        catch (Exception ex)
        {
            throw new Exception("Error Found During AppCode/CBuildQuery/SelectQuery Method" + ex.Message);
        }
    }

    public DataSet SelectRole()
    {
        string sSql = "";
        try
        {
            sSql = "select CENTRE_ID,CENTRE_NAME from CENTRE_MASTER";
            OleDbDataAdapter oledbDa = new OleDbDataAdapter(sSql, objConn.ConnectionString);
            DataSet ds = new DataSet();
            oledbDa.Fill(ds, "SelectQuery");
            return ds;
        }
        catch (Exception ex)
        {
            throw new Exception("Error Found During AppCode/CBuildQuery/SelectRole Method" + ex.Message);
        }
    }

  
    public DataSet SelectUsers(string centreID)
    {
        string sSql = "";
        try
        {
            sSql = " select EMP_ID,FULLNAME + ' ['+ EMP_CODE + ']' as EMP_Name from employee_master " +
                    "where Designation_ID NOT IN(3,11) and CENTRE_ID in (" + centreID + ") order by FULLNAME + ' ['+ EMP_CODE + ']'";

            OleDbDataAdapter oledbDa = new OleDbDataAdapter(sSql, objConn.ConnectionString);
            DataSet ds = new DataSet();
            oledbDa.Fill(ds, "SelectUsers");
            return ds;
        }
        catch (Exception ex)
        {
            throw new Exception("Error Found During AppCode/CBuildQuery/SelectUsers Method" + ex.Message);
        }
    }
    public DataSet CancelUsers()
    {
        string sSql = "";
        try
        {
            sSql = "select EMP_ID,FULLNAME + ' ['+ EMP_CODE + ']' as EMP_Name from employee_master " +
                    "where Designation_ID NOT IN(3,8,11) and CENTRE_ID in ('') ";
            OleDbDataAdapter oledbDa = new OleDbDataAdapter(sSql, objConn.ConnectionString);
            DataSet ds = new DataSet();
            oledbDa.Fill(ds, "CancelUsers");
            return ds;
        }
        catch (Exception ex)
        {
            throw new Exception("Error Found During AppCode/CBuildQuery/SelectUsers Method" + ex.Message);
        }
    }

    public OleDbDataReader ReadCentreAndUserExist(string centreID,string empID)
    {
        string sSql = "";
        try
        {
             sSql = " select EMP_ID from employee_master " +
                   "where Designation_ID NOT IN(3,11) and CENTRE_ID in (" + centreID + ")" + " and EMP_ID in (" + empID + ")";
            return OleDbHelper.ExecuteReader(objConn.ConnectionString, CommandType.Text, sSql);
        }
        catch (Exception ex)
        {
            throw new Exception("Error Found During AppCode/CBuildQuery/ReadQueryRecords Method" + ex.Message);
        }


    }

    public string InsertAssignUsers()
    {
        OleDbConnection oledbConn = new OleDbConnection(objConn.ConnectionString);
        oledbConn.Open();
        OleDbTransaction oledbTrans = oledbConn.BeginTransaction();
        string sql = "";
        string msg = "";
        try
        {
           
            OleDbParameter[] oledbParam = new OleDbParameter[3];


            sql = "Insert into ASSIGN_QUERY (Query_ID,EMP_ID,Centre_ID ) " +
                      " values (?,?,?)";

                oledbParam[0] = new OleDbParameter("@QueryID", OleDbType.Integer, 4);
                oledbParam[0].Value = QueryID;

                oledbParam[1] = new OleDbParameter("@UserID", OleDbType.VarChar, 20);
                oledbParam[1].Value = UserID;

                oledbParam[2] = new OleDbParameter("@CentreID", OleDbType.VarChar, 15);
                oledbParam[2].Value = CentreID;

                msg = "Record Assigned Sucessfully";
                
            OleDbHelper.ExecuteNonQuery(oledbTrans, CommandType.Text, sql, oledbParam);
           

            oledbTrans.Commit();
            oledbConn.Close();
            return msg;
        }
        catch (Exception ex)
        {
            oledbTrans.Rollback();
            oledbConn.Close();
            throw new Exception("ErrorFound During AppCode/CBuildQuery/InsertAssignUsers Method" + ex.Message);
        }
    }

    public string DeleteAssignUsers()
    {
        OleDbConnection oledbConn = new OleDbConnection(objConn.ConnectionString);
        oledbConn.Open();
        OleDbTransaction oledbTrans = oledbConn.BeginTransaction();
        OleDbDataReader oledbDR;
        string sqlQuery = "";
      
        string msg = "";
        string deleteQuery = "";
        

        try
        {
            sqlQuery = " Select Query_ID from ASSIGN_QUERY " +
                      " where Query_ID = '" + QueryID + "'";

            oledbDR = OleDbHelper.ExecuteReader(objConn.ConnectionString, CommandType.Text, sqlQuery);

            if (oledbDR.Read())
            {
                deleteQuery = "Delete from ASSIGN_QUERY where Query_ID = '" + QueryID + "'";
                OleDbHelper.ExecuteNonQuery(oledbTrans, CommandType.Text, deleteQuery);
               
            }
            


            oledbTrans.Commit();
            oledbConn.Close();
            return msg;
        }
        catch (Exception ex)
        {
            oledbTrans.Rollback();
            oledbConn.Close();
            throw new Exception("ErrorFound During AppCode/CBuildQuery/DeleteAssignUsers Method" + ex.Message);
        }
    }

    public string DeleteUniqueAssignUsers(string assignID)
    {
        OleDbConnection oledbConn = new OleDbConnection(objConn.ConnectionString);
        oledbConn.Open();
        OleDbTransaction oledbTrans = oledbConn.BeginTransaction();
        OleDbDataReader oledbDR;
        string sqlQuery = "";

        string msg = "";
        string deleteQuery = "";


        try
        {
            sqlQuery = " Select Assign_ID from ASSIGN_QUERY " +
                      " where Assign_ID = '" + assignID + "'";
                      
            oledbDR = OleDbHelper.ExecuteReader(objConn.ConnectionString, CommandType.Text, sqlQuery);

            if (oledbDR.Read())
            {
                deleteQuery = "Delete from ASSIGN_QUERY " +
                              " where Assign_ID = '" + assignID + "'";
                              
                OleDbHelper.ExecuteNonQuery(oledbTrans, CommandType.Text, deleteQuery);
                msg = "Assigned User Deleted Sucessfully..";
            }



            oledbTrans.Commit();
            oledbConn.Close();
            return msg;
        }
        catch (Exception ex)
        {
            oledbTrans.Rollback();
            oledbConn.Close();
            throw new Exception("ErrorFound During AppCode/CBuildQuery/DeleteAssignUsers Method" + ex.Message);
        }
    }


    public DataSet SelectUsersToEdit(string roleID)
    {
        string sSql = "";
        try
        {
            sSql = " Select EMP_ID from ASSIGN_QUERY ";

            OleDbDataAdapter oledbDa = new OleDbDataAdapter(sSql, objConn.ConnectionString);
            DataSet ds = new DataSet();
            oledbDa.Fill(ds, "SelectUsers");
            return ds;
        }
        catch (Exception ex)
        {
            throw new Exception("Error Found During AppCode/CBuildQuery/SelectUsersToEdit Method" + ex.Message);
        }
    }

    public DataTable SearchForAssignedUsers()
    {
        string sSql = "";
        DataTable dt = new DataTable();
        try
        {
            sSql = "select AQ.Assign_ID,QM.Query_Defination as [Query]," +
                  "CM.CENTRE_NAME as [Centre Name]," +
                  "EM.FULLNAME as [Assigned User] from ASSIGN_QUERY as AQ " +
                  "inner join QUERY_MASTER as QM on AQ.Query_ID=QM.Query_ID " +
                  "inner join CENTRE_MASTER as CM on AQ.Centre_ID=CM.CENTRE_ID " +
                  "inner join EMPLOYEE_MASTER as EM on AQ.EMP_ID=EM.EMP_ID ";

            if ((QueryDefination != "") && (QueryDefination != null))
            {
                sSql += " where QM.Query_Defination like '%" + objConn.FixQuotes(QueryDefination) + "%'";
                if ((UserName != "") && (UserName != null))
                {
                    sSql += " and EM.FULLNAME like '%" + objConn.FixQuotes(UserName) + "%'";
                }
            }
            else if ((UserName != "") && (UserName != null))
            {
                sSql += " where EM.FULLNAME like '%" + objConn.FixQuotes(UserName) + "%'";
                if ((QueryDefination != "") && (QueryDefination != null))
                {
                    sSql += " and QM.Query_Defination like '%" + objConn.FixQuotes(QueryDefination) + "%'";
                }
            }
            sSql += " Order BY QM.Query_Defination DESC";

            OleDbDataAdapter oledbDa = new OleDbDataAdapter(sSql, objConn.ConnectionString);
            DataSet ds = new DataSet();
            oledbDa.Fill(ds, "AssignedUserrs");
            dt = ds.Tables["AssignedUserrs"];
            return dt;
        }
        catch (Exception ex)
        {
            throw new Exception("Error Found During AppCode/CBuildQuery/SearchForAssignedUsers Method" + ex.Message);
        }

    }

    public DataTable GetAssignedUsers()
    {
        string sSql = "";
        DataTable dt = new DataTable();
        try
        {
            sSql = "Select Centre_ID,EMP_ID from ASSIGN_QUERY where Query_ID=" + QueryID;
            OleDbDataAdapter oledbDa = new OleDbDataAdapter(sSql, objConn.ConnectionString);
            DataSet ds = new DataSet();
            oledbDa.Fill(ds, "GetAssignedUsers");
            dt = ds.Tables["GetAssignedUsers"];
            return dt;
        }
        catch (Exception ex)
        {
            throw new Exception("Error Found During AppCode/CBuildQuery/GetAssignedUsers Method" + ex.Message);
        }
    }
    /// <summary>
    /// This function is used to check duplicate Record in Assign_Query table wether 
    /// it is assign to same emp or not
    /// </summary>
    /// <returns></returns>
    public string funCheckDuplicateRights()
    {
        string strSQL = string.Empty;
        string strTF = "FALSE";
        OleDbConnection oledbConn = new OleDbConnection(objConn.ConnectionString);
        oledbConn.Open();
        OleDbDataReader oledbDR;
        try
        {

            strSQL = "SELECT EMP_ID FROM ASSIGN_QUERY WHERE QUERY_ID='" + QueryID + "' AND EMP_ID='" + UserID + "' AND CENTRE_ID='" + CentreID + "'";
            oledbDR = OleDbHelper.ExecuteReader(objConn.ConnectionString, CommandType.Text, strSQL);
            if (oledbDR.Read())
            {
                strTF = "TRUE";
            }
            oledbDR.Close();
            oledbDR.Dispose();
            oledbConn.Close();
            return strTF;
        }
        catch (Exception exp)
        {
            return strTF;
            oledbDR.Close();
            oledbDR.Dispose();
            oledbConn.Close();
            throw new Exception(exp.Message);
        }

    }
}
        