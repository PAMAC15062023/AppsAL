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
/// Summary description for CCClusterMaster
/// </summary>
public class CCClusterMaster
{
    private CCommon oCmn;
    private string strClusterName;
    private string strClusterId;
    private string strselectedCompany;


    public string ClusterName
    {
        get { return strClusterName;}
        set { strClusterName = value;}
    }
    public string SelectedID
    {
        get { return strselectedCompany; }
        set { strselectedCompany = value; }
    }
    public string ClusterID 
    {
        get { return strClusterId; }
        set { strClusterId = value; }
    }


	public CCClusterMaster()
	{
        oCmn = new CCommon();
	}
    public void insertClustermaster()
    {

        OleDbConnection sqlConn = new OleDbConnection(oCmn.ConnectionString);
        sqlConn.Open();
       string strPrefix = "101";
        OleDbTransaction sqlTrans = sqlConn.BeginTransaction();
        try
        {
            strClusterId = oCmn.GetUniqueID("CLUSTER_MASTER", strPrefix).ToString();
            string sql = "insert into cluster_master(cluster_id,cluster_name) values(?,?)";
            OleDbParameter[] paramCluster = new OleDbParameter[2];
            paramCluster[0] = new OleDbParameter("@ClusterId", OleDbType.VarChar, 50);
            paramCluster[0].Value = strClusterId;
            paramCluster[1] = new OleDbParameter("@ClusterName", OleDbType.VarChar, 100);
            paramCluster[1].Value = strClusterName;
            OleDbHelper.ExecuteNonQuery(sqlTrans, CommandType.Text, sql, paramCluster);


            string[] strHierId = strselectedCompany.Split(',');
            foreach (string str in strHierId)
            {
                if (str != "")
                {
                    //To get Unique Hier_Id.
                    string strUniqueHierId = oCmn.GetUniqueID("COMPANY_HIERARCHY_MASTER", strPrefix).ToString();

                    //Insert record in COMPANY_HIERARCHY_MASTER.
                    string strHierarchy = "Insert into COMPANY_HIERARCHY_MASTER values (?, ?, ?, ?, ?)";
                    OleDbParameter[] paramHierarchy = new OleDbParameter[5];
                    paramHierarchy[0] = new OleDbParameter("@HIER_ID", OleDbType.VarChar, 50);
                    paramHierarchy[0].Value = strUniqueHierId;
                    paramHierarchy[1] = new OleDbParameter("@REF_ID", OleDbType.VarChar, 50);
                    paramHierarchy[1].Value = strClusterId;
                    paramHierarchy[2] = new OleDbParameter("@HIER_LEVEL", OleDbType.Numeric);
                    paramHierarchy[2].Value = 2;
                    paramHierarchy[3] = new OleDbParameter("@PARENT_ID", OleDbType.VarChar, 50);
                    paramHierarchy[3].Value = str;
                    paramHierarchy[4] = new OleDbParameter("@TYPE", OleDbType.VarChar, 5);
                    paramHierarchy[4].Value = "CL";

                    OleDbHelper.ExecuteNonQuery(sqlTrans, CommandType.Text, strHierarchy, paramHierarchy);
                }
            }
            sqlTrans.Commit();
            sqlConn.Close();

        }
        catch (System.Exception ex)
        {
            sqlTrans.Rollback();
            sqlConn.Close();
            throw new Exception("An error occurred while executing the insert Cluster", ex);
        }

    }
    public void GetCluster()
    {

        OleDbConnection sqlConn = new OleDbConnection(oCmn.ConnectionString);
        String sql = "";
        OleDbDataReader ord;
        sql = "select * from cluster_master where cluster_id=?";
        OleDbParameter[] paramCompany = new OleDbParameter[1];
        paramCompany[0] = new OleDbParameter("@cluster_id", OleDbType.VarChar, 50);
        paramCompany[0].Value = strClusterId;
        ord = OleDbHelper.ExecuteReader(sqlConn, CommandType.Text, sql, paramCompany);
        if (ord.HasRows)
        {
            while (ord.Read())
            {

                ClusterName = ord["cluster_name"].ToString();

            }
        }
        ord.Close(); 
    }
    public void UpdateCluster()
    {
        OleDbConnection sqlConn = new OleDbConnection(oCmn.ConnectionString);
        sqlConn.Open();
        OleDbTransaction sqlTrans = sqlConn.BeginTransaction();
        try
        {
            String sql = "";
            sql = "update cluster_master set cluster_name=? where cluster_id=?";
            OleDbParameter[] paramCluster = new OleDbParameter[2];
            paramCluster[0] = new OleDbParameter("@ClusterName", OleDbType.VarChar, 100);
            paramCluster[0].Value = strClusterName;
            paramCluster[1] = new OleDbParameter("@ClusterId", OleDbType.VarChar, 50);
            paramCluster[1].Value = strClusterId;
            
            OleDbHelper.ExecuteNonQuery(sqlTrans, CommandType.Text, sql, paramCluster);
            sqlTrans.Commit();
            sqlConn.Close();

        }
        catch (System.Exception ex)
        {
            sqlTrans.Rollback();
            sqlConn.Close();
            throw new Exception("An error occurred while executing the update Cluster", ex);

        }
    }
    public void DeletCluster(string unselectCompanyID)
    {
        string sql = "";

        OleDbConnection sqlConn = new OleDbConnection(oCmn.ConnectionString);
        sqlConn.Open();
        OleDbTransaction sqlTrans = sqlConn.BeginTransaction();
        string[] CompanyID = unselectCompanyID.Split(',');

        try
        {

            foreach (string str in CompanyID)
            {
                if (str != "")
                {

                    string sSql = "select hier_id from company_hierarchy_master  where ref_id=? and type='CO'";

                    OleDbParameter[] paramCluster = new OleDbParameter[1];
                    OleDbParameter[] paramCluster1 = new OleDbParameter[2];
                    paramCluster[0] = new OleDbParameter("@companyID", OleDbType.VarChar, 50);
                    paramCluster[0].Value = str;

                    OleDbDataReader dr;
                    dr = OleDbHelper.ExecuteReader(sqlTrans, CommandType.Text, sSql, paramCluster);


                    while (dr.Read())
                    {
                        sql = "delete from company_hierarchy_master where parent_id=? and ref_id=? and type='CL'";
                        paramCluster1[0] = new OleDbParameter("@HierID", OleDbType.VarChar, 50);
                        paramCluster1[0].Value = dr["hier_id"];

                        paramCluster1[1] = new OleDbParameter("@refID", OleDbType.VarChar, 50);
                        paramCluster1[1].Value = strClusterId;
                        OleDbHelper.ExecuteNonQuery(sqlTrans, CommandType.Text, sql, paramCluster1);

                    }


                }

            }
            sqlTrans.Commit();
            sqlConn.Close();
            
        }
        catch (Exception ex)
        {
            sqlTrans.Rollback();
            sqlConn.Close();
          
        }

    }
    public void changeCluster(string selecteCompany)
    {
        string sql = "";

        OleDbConnection sqlConn = new OleDbConnection(oCmn.ConnectionString);
        sqlConn.Open();
        OleDbTransaction sqlTrans = sqlConn.BeginTransaction();
        string[] CompanyID = selecteCompany.Split(',');
        string strPrefix = "101";
        try
        {

            foreach (string str in CompanyID)
            {
                if (str != "")
                {

                    string sSql = "select hier_id from company_hierarchy_master  where ref_id=? and type='CO'";

                    OleDbParameter[] paramCluster = new OleDbParameter[1];
                    OleDbParameter[] paramCluster1 = new OleDbParameter[2];
                    paramCluster[0] = new OleDbParameter("@companyID", OleDbType.VarChar, 50);
                    paramCluster[0].Value = str;

                    OleDbDataReader dr;
                    dr = OleDbHelper.ExecuteReader(sqlTrans, CommandType.Text, sSql, paramCluster);
                    while (dr.Read())
                    {
                        string strUniqueHierId = oCmn.GetUniqueID("COMPANY_HIERARCHY_MASTER", strPrefix).ToString();

                        //Insert record in COMPANY_HIERARCHY_MASTER.
                        string strHierarchy = "Insert into COMPANY_HIERARCHY_MASTER values (?, ?, ?, ?, ?)";
                        OleDbParameter[] paramHierarchy = new OleDbParameter[5];
                        paramHierarchy[0] = new OleDbParameter("@HIER_ID", OleDbType.VarChar, 50);
                        paramHierarchy[0].Value = strUniqueHierId;
                        paramHierarchy[1] = new OleDbParameter("@REF_ID", OleDbType.VarChar, 50);
                        paramHierarchy[1].Value = ClusterID;
                        paramHierarchy[2] = new OleDbParameter("@HIER_LEVEL", OleDbType.Numeric);
                        paramHierarchy[2].Value = 2;
                        paramHierarchy[3] = new OleDbParameter("@PARENT_ID", OleDbType.VarChar, 50);
                        paramHierarchy[3].Value = dr["hier_id"];
                        paramHierarchy[4] = new OleDbParameter("@TYPE", OleDbType.VarChar, 5);
                        paramHierarchy[4].Value = "CL";

                        OleDbHelper.ExecuteNonQuery(sqlTrans, CommandType.Text, strHierarchy, paramHierarchy);
                    }
                }
            }
            sqlTrans.Commit();
            sqlConn.Close();
        }
        catch (Exception ex)
        {
            sqlTrans.Rollback();
            sqlConn.Close();
            //throw new Exception("An error occurred while executing Changing the Centre ", ex);
           
        }

    }
}
