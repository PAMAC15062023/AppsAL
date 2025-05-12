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
/// Summary description for CSubCentreMaster
/// </summary>
public class CSubCentreMaster
{

     CCommon oCmn =new CCommon();
    private string strClusterId;
    private string strCentreId;
    private string strSubCentreId;
    private string strSubCentreName;
   // private string strSubCentreCode;
    private string strAddress;

    public string  ClusterId
    {
        get { return strClusterId; }
        set { strClusterId = value; }
    }
    public string CentreId
    {
        get { return strCentreId; }
        set { strCentreId = value; }
    }

    public string SubCentreId
    {
        get { return strSubCentreId; }
        set { strSubCentreId = value; }
    }

    public string SubCentreName
    {
        get { return strSubCentreName; }
        set { strSubCentreName = value; }
    }

    //public string SubCentreCode
    //{
    //    get { return strSubCentreCode; }
    //    set { strSubCentreCode = value; }
    //}

    public string Address
    {
        get { return strAddress; }
        set { strAddress = value; }
    }

   
   


	public CSubCentreMaster()
	{
		//
		// TODO: Add constructor logic here
		//
	}


    public void InsertSubCentre()
    {
        OleDbConnection sqlConn = new OleDbConnection(oCmn.ConnectionString);
        sqlConn.Open();
        string strPrefix = "101";

        OleDbTransaction sqlTrans = sqlConn.BeginTransaction();

        try
        {
            if (SubCentreId == "0")
            {
                strSubCentreId = oCmn.GetUniqueID("SubCentreMaster", strPrefix).ToString();
            }
            else
            {
                strSubCentreId = SubCentreId;
            }

              string sql = "insert into SubCentreMaster(SubCentreId,ClusterId,CentreId,SubCentreName,Address)values(?,?,?,?,?)";
            OleDbParameter[] paramSubCentre = new OleDbParameter[5];
            paramSubCentre[0] = new OleDbParameter("@SubCentreId", OleDbType.VarChar, 50);
            paramSubCentre[0].Value = strSubCentreId;

            paramSubCentre[1] = new OleDbParameter("@ClusterId", OleDbType.VarChar, 15);
            paramSubCentre[1].Value =ClusterId;

            paramSubCentre[2] = new OleDbParameter("@CentreId", OleDbType.VarChar, 50);
            paramSubCentre[2].Value = CentreId;

            paramSubCentre[3] = new OleDbParameter("@SubCentreName", OleDbType.VarChar, 100);
            paramSubCentre[3].Value = SubCentreName ;

           // paramSubCentre[4] = new OleDbParameter("@SubCentreCode", OleDbType.VarChar, 50);
           // paramSubCentre[4].Value = SubCentreCode;

            paramSubCentre[4] = new OleDbParameter("@Address", OleDbType.VarChar, 200);
            paramSubCentre[4].Value = Address;


            OleDbHelper.ExecuteNonQuery(sqlTrans, CommandType.Text, sql, paramSubCentre);
            sqlTrans.Commit();
            sqlConn.Close();


        }
        catch (Exception ex)
        {
            sqlTrans.Rollback();
            sqlConn.Close();
            throw new Exception("An error occurred while executing the insert Activity", ex);
        }

    }
    public void GetSubCentre(string strCentreId)
    {

        OleDbConnection sqlConn = new OleDbConnection(oCmn.ConnectionString);
        String sql = "";
        OleDbDataReader ord;
        sql = "select * from SubCentreMaster where  SubCentreId=? and  CentreId='" + strCentreId + "'";
        OleDbParameter[] paramSubCentre = new OleDbParameter[1];
        paramSubCentre[0] = new OleDbParameter("@SubCentreId", OleDbType.VarChar, 50);
        paramSubCentre[0].Value = SubCentreId;
        ord = OleDbHelper.ExecuteReader(sqlConn, CommandType.Text, sql, paramSubCentre);
        if (ord.HasRows)
        {
            while (ord.Read())
            {

                //DeclineCode = ord["declined_code"].ToString();
                //Description = ord["description"].ToString();
                //ClientID = ord["client_id"].ToString();
                SubCentreId = ord["SubCentreId"].ToString();
                SubCentreName = ord["SubCentreName"].ToString();
                //SubCentreCode = ord["SubCentreCode"].ToString();
                Address = ord["Address"].ToString();
            }
        }
        ord.Close();
    }
    public void DeleteSubCentre(string strSubCentreId)
    {

        OleDbConnection sqlConn = new OleDbConnection(oCmn.ConnectionString);
        String sql = "";
        OleDbDataReader ord;
        sql = "Delete from SubCentreMaster where  SubCentreId='" + strSubCentreId + "'";
      
        ord = OleDbHelper.ExecuteReader(sqlConn, CommandType.Text, sql);
       
        ord.Close();
    }
    public int GetDulplicateSubCentre(string strCentreId)
    {

        OleDbConnection sqlConn = new OleDbConnection(oCmn.ConnectionString);
        String sql1= "";
        OleDbDataReader ord;
        int count=0;
        sql1 = "select count(*) from SubCentreMaster where SubCentreName=? " +
                                 " AND CentreId='" + strCentreId + "'";
        OleDbParameter[] paramSubCentre1 = new OleDbParameter[1];
        paramSubCentre1[0] = new OleDbParameter("@SubCentreName", OleDbType.VarChar, 50);
        paramSubCentre1[0].Value =SubCentreName;
      //  paramSubCentre1[1] = new OleDbParameter("@SubCentreCode", OleDbType.VarChar, 50);
      //  paramSubCentre1[1].Value = SubCentreCode;
        ord = OleDbHelper.ExecuteReader(sqlConn, CommandType.Text, sql1, paramSubCentre1);
        if (ord.HasRows)
        {
            while (ord.Read())
            {

               
                count = Convert.ToInt32( ord[0].ToString());
               
            }
        }

        return count;
        ord.Close();
    }
    public void updateSubCentre()
    {
        OleDbConnection sqlConn = new OleDbConnection(oCmn.ConnectionString);
        sqlConn.Open();
        OleDbTransaction sqlTrans = sqlConn.BeginTransaction();
        try
        {
            string sql = "Update SubCentreMaster SET SubCentreName=?,Address=? WHERE SubCentreId=?";
            //string sql = "delete from declined_code_master where declined_code=?";
            OleDbParameter[] paramSubCentre = new OleDbParameter[3];
            
            paramSubCentre[0] = new OleDbParameter("@SubCentreName", OleDbType.VarChar, 50);
            paramSubCentre[0].Value = SubCentreName;
           // paramSubCentre[1] = new OleDbParameter("@SubCentreCode", OleDbType.VarChar, 50);
           // paramSubCentre[1].Value = SubCentreCode;
            paramSubCentre[1] = new OleDbParameter("@Address", OleDbType.VarChar, 50);
            paramSubCentre[1].Value = Address;
            paramSubCentre[2] = new OleDbParameter("@SubCentreId", OleDbType.VarChar, 50);
            paramSubCentre[2].Value = SubCentreId;

            OleDbHelper.ExecuteNonQuery(sqlTrans, CommandType.Text, sql, paramSubCentre);
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
