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
/// Summary description for CCCenterMaster
/// </summary>
public class CCCenterMaster
{
    private CCommon oCmn;

    private string strCenterCode;
    private string strCenterName;
   
    private string strClusterID;
    private string strSelectedHierachyID;
    private string strCentreID;
    private string strMassage;
    private string strClusterHierID;

    public string CenterCode
    {
        get { return strCenterCode; }
        set { strCenterCode = value; }
    }

    public string CenterName
    {
        get { return strCenterName; }
        set { strCenterName = value; }
    }
    
    public string ClusterID
    {
        get { return strClusterID; }
        set { strClusterID = value; }
    }

    public string SelectedHierachyID
    {
        get { return strSelectedHierachyID; }
        set { strSelectedHierachyID = value; }
    }
    public string CentreID
    {
        get { return strCentreID; }
        set { strCentreID = value; }
    }
    public string Massage
    {
        get { return strMassage; }
        set { strMassage = value; }
    }

    public string ClusterHierID
    {
        get { return strClusterHierID; }
        set { strClusterHierID = value; }
    }
	public CCCenterMaster()
	{
        oCmn = new CCommon();
	}
  
    public void InsertCenterMaster()
    {
        OleDbConnection sqlConn = new OleDbConnection(oCmn.ConnectionString);
        sqlConn.Open();
       string strPrefix = "101";
       string strCenterId;
       string strPrefix1="";

       string sql2 = "select max(CAST ( prefix AS numeric )) from company_centre_prefix";
       object objPrefix;
       objPrefix = OleDbHelper.ExecuteScalar(sqlConn,CommandType.Text, sql2);
       if (objPrefix != null)
       {
           Int32 j;
           j = Convert.ToInt32(objPrefix) + 1;


           strPrefix1 = j.ToString();
       }
        OleDbTransaction sqlTrans = sqlConn.BeginTransaction();
        try
        {
            strCenterId = oCmn.GetUniqueID("CENTRE_MASTER", strPrefix).ToString();
            string sql = "insert into CENTRE_MASTER (CENTRE_ID,CENTRE_CODE,CENTRE_NAME,CLUSTER_ID) VALUES(?,?,?,?)";
            OleDbParameter[] paramCenter = new OleDbParameter[4];

            paramCenter[0] = new OleDbParameter("@CenterId", OleDbType.VarChar, 15);
            paramCenter[0].Value = strCenterId;
            paramCenter[1] = new OleDbParameter("@CenterCode", OleDbType.VarChar, 10);
            paramCenter[1].Value = strCenterCode;
            paramCenter[2] = new OleDbParameter("@CenterName", OleDbType.VarChar, 100);
            paramCenter[2].Value = strCenterName;
            paramCenter[3] = new OleDbParameter("@ClusterId", OleDbType.VarChar, 15);
            paramCenter[3].Value = strClusterID;
            OleDbHelper.ExecuteNonQuery(sqlTrans, CommandType.Text, sql, paramCenter);

            //insert for prefix in company_centre_prfix


           
            string sql1 = "insert into company_centre_prefix values(?,?,?)";

            OleDbParameter[] paramCenter1 = new OleDbParameter[3];

            paramCenter1[0] = new OleDbParameter("@CompanyId", OleDbType.VarChar, 15);
            paramCenter1[0].Value = 1;

            paramCenter1[1] = new OleDbParameter("@CenterId", OleDbType.VarChar, 15);
            paramCenter1[1].Value = strCenterId;
            paramCenter1[2] = new OleDbParameter("@prefix", OleDbType.VarChar, 15);
            paramCenter1[2].Value = strPrefix1;

            OleDbHelper.ExecuteNonQuery(sqlTrans, CommandType.Text, sql1, paramCenter1);
            string[] strHierId = strSelectedHierachyID.Split(',');

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
                    paramHierarchy[1].Value = strCenterId;
                    paramHierarchy[2] = new OleDbParameter("@HIER_LEVEL", OleDbType.Numeric);
                    paramHierarchy[2].Value = 3;
                    paramHierarchy[3] = new OleDbParameter("@PARENT_ID", OleDbType.VarChar, 50);
                    paramHierarchy[3].Value = str;
                    paramHierarchy[4] = new OleDbParameter("@TYPE", OleDbType.VarChar, 5);
                    paramHierarchy[4].Value = "CE";

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
            throw new Exception("An error occurred while executing the insert Company", ex);


        }



    }
    public void GetCentre()
    {
        OleDbConnection sqlConn = new OleDbConnection(oCmn.ConnectionString);
        String sql = "";
        OleDbDataReader ord;
        sql = "select * from centre_master where centre_id=?";
        OleDbParameter[] paramCentre = new OleDbParameter[1];
        paramCentre[0] = new OleDbParameter("@centre_id", OleDbType.VarChar, 50);
        paramCentre[0].Value = strCentreID;
        ord = OleDbHelper.ExecuteReader(sqlConn, CommandType.Text, sql, paramCentre);
        if (ord.HasRows)
        {
            while (ord.Read())
            {

                CenterName = ord["centre_name"].ToString();
                ClusterID = ord["cluster_id"].ToString();
            }
        }
        ord.Close(); 
    }
    public void UpdateCentre()
    {
         OleDbConnection sqlConn = new OleDbConnection(oCmn.ConnectionString);
        sqlConn.Open();

       
        OleDbTransaction sqlTrans = sqlConn.BeginTransaction();
        try
        {
            String sql = "";
            sql = "update centre_master set centre_name=? where centre_id=?";
            OleDbParameter[] paramCentre = new OleDbParameter[2];
            paramCentre[0] = new OleDbParameter("@CentreName", OleDbType.VarChar, 100);
            paramCentre[0].Value = strCenterName;
            paramCentre[1] = new OleDbParameter("@CentreId", OleDbType.VarChar, 50);
            paramCentre[1].Value = strCentreID;

            OleDbHelper.ExecuteNonQuery(sqlTrans, CommandType.Text, sql, paramCentre);
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
    public void ChangeCentre()
    {
        OleDbConnection sqlConn = new OleDbConnection(oCmn.ConnectionString);
         sqlConn.Open();
         string strPrefix = "101";
         //string strCenterId;
        OleDbTransaction sqlTrans = sqlConn.BeginTransaction();
       
            String sql = "";
            
            //string[] strHierId = strSelectedHierachyID.Split(',');
            string[] strCLHierID= strClusterHierID.Split(',');
            try
            {
                
                      
                                sql = "delete from company_hierarchy_master where ref_id=? and type='CE'";
                                OleDbParameter[] paramCentre = new OleDbParameter[1];
                                paramCentre[0] = new OleDbParameter("@REF_ID", OleDbType.VarChar, 50);
                                paramCentre[0].Value = strCentreID;
                                OleDbHelper.ExecuteNonQuery(sqlTrans, CommandType.Text, sql, paramCentre);
                                
                                //To get Unique Hier_Id.
                                foreach (string str1 in strCLHierID)
                                {
                                    if (str1 != "")
                                    {
                                string strUniqueHierId = oCmn.GetUniqueID("COMPANY_HIERARCHY_MASTER", strPrefix).ToString();
                               // strCenterId = oCmn.GetUniqueID("CENTRE_MASTER", strPrefix).ToString();
                                //Insert record in COMPANY_HIERARCHY_MASTER.

                                string strHierarchy = "Insert into COMPANY_HIERARCHY_MASTER values (?, ?, ?, ?, ?)";
                                OleDbParameter[] paramHierarchy = new OleDbParameter[5];
                                paramHierarchy[0] = new OleDbParameter("@HIER_ID", OleDbType.VarChar, 50);
                                paramHierarchy[0].Value = strUniqueHierId;
                                paramHierarchy[1] = new OleDbParameter("@REF_ID", OleDbType.VarChar, 50);
                                paramHierarchy[1].Value = strCentreID;
                                paramHierarchy[2] = new OleDbParameter("@HIER_LEVEL", OleDbType.Numeric);
                                paramHierarchy[2].Value = 3;
                                paramHierarchy[3] = new OleDbParameter("@PARENT_ID", OleDbType.VarChar, 50);
                                paramHierarchy[3].Value = str1;
                                paramHierarchy[4] = new OleDbParameter("@TYPE", OleDbType.VarChar, 5);
                                paramHierarchy[4].Value = "CE";

                                OleDbHelper.ExecuteNonQuery(sqlTrans, CommandType.Text, strHierarchy, paramHierarchy);
                              
                                strMassage = "Centre changed successfully";   
                              
                            }
                         }
                         string sql1 = "update centre_master set cluster_id =? where centre_id=?";
                         OleDbParameter[] paramUpdate = new OleDbParameter[2];
                         paramUpdate[0] = new OleDbParameter("@CLUSTER_ID", OleDbType.VarChar, 50);
                         paramUpdate[0].Value = strClusterID;
                         paramUpdate[1] = new OleDbParameter("@CENTRE_ID", OleDbType.VarChar, 50);
                         paramUpdate[1].Value = strCentreID;

                         OleDbHelper.ExecuteNonQuery(sqlTrans, CommandType.Text, sql1, paramUpdate);

                sqlTrans.Commit();
                sqlConn.Close();

            }
            catch (System.Exception ex)
            {
                sqlTrans.Rollback();
                sqlConn.Close();
                //throw new Exception("An error occurred while executing Changing the Centre ", ex);
                strMassage = "Centre can not be changed";
            }

            
            
        }


}
