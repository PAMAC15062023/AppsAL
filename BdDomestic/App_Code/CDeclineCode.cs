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
/// Summary description for CDeclineCode
/// </summary>
public class CDeclineCode
{
    private CCommon oCmn;
    private string strdeclinecode;
    private string strdescription;
    private string strDeclineID;
    private string strClientID;

    public string DeclineCode
    {
        get { return strdeclinecode; }
        set { strdeclinecode = value; }
    }
    public string Description
    {
        get { return strdescription; }
        set { strdescription = value; }
    }

    public string ClientID
    {
        get { return strClientID; }
        set { strClientID = value; }
    }

    public string DeclinedID
    {
        get { return strDeclineID; }
        set { strDeclineID = value; }
    }
   
	public CDeclineCode()
	{
        oCmn = new CCommon();
	}
    public void InsertDeclineCode()
    {
        OleDbConnection sqlConn = new OleDbConnection(oCmn.ConnectionString);
        sqlConn.Open();
        string strPrefix = "101";
       
        OleDbTransaction sqlTrans = sqlConn.BeginTransaction();

        try
        {
            strDeclineID = oCmn.GetUniqueID("Declined_code_master", strPrefix).ToString();
            string sql = "insert into declined_code_master(id,client_id,declined_code,description)values(?,?,?,?)";
            OleDbParameter[] paramDecline = new OleDbParameter[4];
            paramDecline[0] = new OleDbParameter("@DeclineId", OleDbType.VarChar,50 );
            paramDecline[0].Value = strDeclineID;

            paramDecline[1] = new OleDbParameter("@ClientID", OleDbType.VarChar, 15);
            paramDecline[1].Value = strClientID;

            paramDecline[2] = new OleDbParameter("@DeclinedCode", OleDbType.VarChar, 50);
            paramDecline[2].Value = strdeclinecode;

            paramDecline[3] = new OleDbParameter("@Description", OleDbType.VarChar, 200);
            paramDecline[3].Value = strdescription;


            OleDbHelper.ExecuteNonQuery(sqlTrans, CommandType.Text, sql, paramDecline);
            sqlTrans.Commit();
            sqlConn.Close();


        }
        catch(Exception ex)
        {
            sqlTrans.Rollback();
            sqlConn.Close();
            throw new Exception("An error occurred while executing the insert Activity", ex);
        }
       
    }
    public void GetDeclined(string strClientId)
    {

        OleDbConnection sqlConn = new OleDbConnection(oCmn.ConnectionString);
        String sql = "";
        OleDbDataReader ord;
        sql = "select * from declined_code_master where declined_code=? AND Client_ID='" + strClientId + "'";
        OleDbParameter[] paramDecline = new OleDbParameter[1];
        paramDecline[0] = new OleDbParameter("@DeclinedCode", OleDbType.VarChar, 50);
        paramDecline[0].Value = strdeclinecode;
        ord = OleDbHelper.ExecuteReader(sqlConn, CommandType.Text, sql, paramDecline);
        if (ord.HasRows)
        {
            while (ord.Read())
            {

                DeclineCode = ord["declined_code"].ToString();
                Description = ord["description"].ToString();
                ClientID = ord["client_id"].ToString();
            }
        }
        ord.Close(); 
    }
    public void updateDeclineCode()
    {
        OleDbConnection sqlConn = new OleDbConnection(oCmn.ConnectionString);
        sqlConn.Open();
        OleDbTransaction sqlTrans = sqlConn.BeginTransaction();
        try
        {
            string sql = "Update declined_code_master SET DESCRIPTION=? WHERE declined_code=?";
            //string sql = "delete from declined_code_master where declined_code=?";
            OleDbParameter[] paramDecline = new OleDbParameter[2];
            paramDecline[0] = new OleDbParameter("@Description", OleDbType.VarChar, 50);
            paramDecline[0].Value = Description;
            paramDecline[1] = new OleDbParameter("@DeclineCode", OleDbType.VarChar, 50);
            paramDecline[1].Value = DeclineCode;

            OleDbHelper.ExecuteNonQuery(sqlTrans, CommandType.Text, sql, paramDecline);
            sqlTrans.Commit();
            sqlConn.Close();


        }
        catch (Exception ex)
        {
            sqlTrans.Rollback();
            sqlConn.Close();
            throw new Exception("An error occurred while executing the Delete Declined", ex);
        }
    }
}
