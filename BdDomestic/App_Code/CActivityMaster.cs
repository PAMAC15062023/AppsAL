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
/// Summary description for CActivityMaster
/// </summary>
public class CActivityMaster
{

    private CCommon oCmn;

    //private string strActivityCode;
    private string strActivityName;
    private string strselectedCentre;
    private string strActivityID;
    private string strCentreID;
    private string strCentreHierID;
    private string strMassage;
    private string strkeycolumn;
    //public string ActivityCode
    //{
    //    get { return strActivityCode; }
    //    set { strActivityCode = value; }
    //}

    public string ActivityName
    {
        get { return strActivityName; }
        set { strActivityName = value; }
    }
    public string keycolumn
    {
        get { return strkeycolumn; }
        set { strkeycolumn = value; }
    }
    public string SelectedID
    {
        get { return strselectedCentre; }
        set { strselectedCentre = value; }
    }

    public string ActivityID
    {
        get { return strActivityID; }
        set { strActivityID = value; }
    }
    public string CentreID
    {
        get { return strCentreID; }
        set { strCentreID = value; }
    }
    public string CentreHierID
    {
        get { return strCentreHierID; }
        set { strCentreHierID = value; }
    }
    public string Massage
    {
        get { return strMassage; }
        set { strMassage = value; }
    }
	public CActivityMaster()
	{
        oCmn = new CCommon();
	}

    public void InsertActivityMaster()
    {
        OleDbConnection sqlConn = new OleDbConnection(oCmn.ConnectionString);
        sqlConn.Open();
       string strPrefix = "101";
       string strActivityId;
       string strCentre = "";
       string hier = "";
        OleDbTransaction sqlTrans = sqlConn.BeginTransaction();

        try
        {
            strActivityId = oCmn.GetUniqueID("ACTIVITY_MASTER", strPrefix).ToString();
            string sql = "insert into activity_master(activity_id,activity_name)values(?,?)";
            OleDbParameter[] paramActivity = new OleDbParameter[2];
            paramActivity[0] = new OleDbParameter("@ActivityId", OleDbType.VarChar, 15);
            paramActivity[0].Value = strActivityId;

            paramActivity[1] = new OleDbParameter("@ActivityName", OleDbType.VarChar, 100);
            paramActivity[1].Value = strActivityName;

            OleDbHelper.ExecuteNonQuery(sqlTrans, CommandType.Text, sql, paramActivity);


            string[] strHierId = strCentreHierID.Split(',');

               string sql1 = "select cm.Centre_Id, cm.Centre_Name, Centre_Code, CHM.Hier_Id from centre_master CM inner join Company_hierarchy_master CHM on CM.Centre_Id=CHM.Ref_Id and CHM.Type='CE'and chm.ref_id=?";
                
                OleDbParameter[] paramCentreID = new OleDbParameter[1];
                paramCentreID[0] = new OleDbParameter("@centre_id", OleDbType.VarChar, 50);
                paramCentreID[0].Value = strCentreID;
               OleDbDataReader ord;
               ord = OleDbHelper.ExecuteReader(sqlTrans, CommandType.Text, sql1, paramCentreID);
               while (ord.Read())
               {
                   hier = hier + ord[3].ToString()+',';
 
               }
               ord.Close();
               string[] hier1 = hier.Split(',');
               foreach (string str2 in hier1)
               {
                   if(str2!="")
                   {
                       foreach (string str1 in strHierId)
                       {
                           if (str1 != "")
                           {

                               if (str1 == str2)
                               {
                                   //To get Unique Hier_Id.
                                   string strUniqueHierId = oCmn.GetUniqueID("COMPANY_HIERARCHY_MASTER", strPrefix).ToString();

                                   //Insert record in COMPANY_HIERARCHY_MASTER.
                                   string strHierarchy = "Insert into COMPANY_HIERARCHY_MASTER values (?, ?, ?, ?, ?)";
                                   OleDbParameter[] paramHierarchy = new OleDbParameter[5];
                                   paramHierarchy[0] = new OleDbParameter("@HIER_ID", OleDbType.VarChar, 50);
                                   paramHierarchy[0].Value = strUniqueHierId;
                                   paramHierarchy[1] = new OleDbParameter("@REF_ID", OleDbType.VarChar, 50);
                                   paramHierarchy[1].Value = strActivityId;
                                   paramHierarchy[2] = new OleDbParameter("@HIER_LEVEL", OleDbType.Numeric);
                                   paramHierarchy[2].Value = 4;
                                   paramHierarchy[3] = new OleDbParameter("@PARENT_ID", OleDbType.VarChar, 50);
                                   paramHierarchy[3].Value = str1;
                                   paramHierarchy[4] = new OleDbParameter("@TYPE", OleDbType.VarChar, 5);
                                   paramHierarchy[4].Value = "AC";

                                   OleDbHelper.ExecuteNonQuery(sqlTrans, CommandType.Text, strHierarchy, paramHierarchy);
                               }
                           }
                       }
                   }
               }
               
              
               
               
            sqlTrans.Commit();
            sqlConn.Close();
            strMassage = "Inserted successfully";
        }
        catch (System.Exception ex)
        {
            
        
            sqlTrans.Rollback();
            sqlConn.Close();
          strMassage=  "An error occurred while executing the insert Activity";

 
        }
 
    }
    public void GetActivity()
    {
        OleDbConnection sqlConn = new OleDbConnection(oCmn.ConnectionString);
        String sql = "";
        OleDbDataReader ord;
        sql = "select * from activity_master where activity_id=?";
        OleDbParameter[] paramActivity = new OleDbParameter[1];
        paramActivity[0] = new OleDbParameter("@activity_id", OleDbType.VarChar, 50);
        paramActivity[0].Value = strActivityID;
        ord = OleDbHelper.ExecuteReader(sqlConn, CommandType.Text, sql, paramActivity);
        if (ord.HasRows)
        {
            while (ord.Read())
            {

                ActivityName = ord["activity_name"].ToString();

            }
        }
        ord.Close(); 
    }
  

    public void UpdateActivity()
    {
        OleDbConnection sqlConn = new OleDbConnection(oCmn.ConnectionString);
        sqlConn.Open();
        OleDbTransaction sqlTrans = sqlConn.BeginTransaction();
        try
        {
            String sql = "";
            sql = "update activity_master set activity_name=? where activity_id=?";
            OleDbParameter[] paramActivity = new OleDbParameter[2];
            paramActivity[0] = new OleDbParameter("@ActivityName", OleDbType.VarChar, 100);
            paramActivity[0].Value = strActivityName;
            paramActivity[1] = new OleDbParameter("@ActivityId", OleDbType.VarChar, 50);
            paramActivity[1].Value = strActivityID;

            OleDbHelper.ExecuteNonQuery(sqlTrans, CommandType.Text, sql, paramActivity);
            sqlTrans.Commit();
            sqlConn.Close();
            strMassage = "Updated successfully";

        }
        catch (System.Exception ex)
        {
            sqlTrans.Rollback();
            sqlConn.Close();
           strMassage = "An error occurred while executing the update Cluster ";

        }
    }
    public void DeletActivity(string unselectCentreID)
    {
        string sql = "";

        OleDbConnection sqlConn = new OleDbConnection(oCmn.ConnectionString);
        sqlConn.Open();
        OleDbTransaction sqlTrans = sqlConn.BeginTransaction();
        string[] centreID = unselectCentreID.Split(',');
       
        try
        {

             foreach (string str in centreID)
        {
            if (str != "")
            {

                string sSql = "select hier_id from company_hierarchy_master  where ref_id=? and type='CE'";

                OleDbParameter[] paramActivity = new OleDbParameter[1];
                OleDbParameter[] paramActivity1 = new OleDbParameter[2];
                paramActivity[0] = new OleDbParameter("@centreID", OleDbType.VarChar, 50);
                paramActivity[0].Value = str;

                OleDbDataReader dr;
                dr = OleDbHelper.ExecuteReader(sqlTrans, CommandType.Text, sSql, paramActivity);


                while (dr.Read())
                {
                    sql = "delete from company_hierarchy_master where parent_id=? and ref_id=? and type='AC'";
                    paramActivity1[0] = new OleDbParameter("@HierID", OleDbType.VarChar, 50);
                    paramActivity1[0].Value = dr["hier_id"];

                    paramActivity1[1] = new OleDbParameter("@refID", OleDbType.VarChar, 50);
                    paramActivity1[1].Value = strActivityID;
                    OleDbHelper.ExecuteNonQuery(sqlTrans, CommandType.Text, sql, paramActivity1);

                }

               
            }
          
        }
        sqlTrans.Commit();
        sqlConn.Close();
        strMassage = "Unassigned succecfully";
        }    
        catch(Exception ex)
        {
            sqlTrans.Rollback();
            sqlConn.Close();
            //strMassage = "First delete the Prodct which is assign to this activity";
        }
 
    }

    public void ChangeActivty(string strChange)
    {
        OleDbConnection sqlConn = new OleDbConnection(oCmn.ConnectionString);
        sqlConn.Open();
        string strPrefix = "101";
        //string strCenterId;
        OleDbTransaction sqlTrans = sqlConn.BeginTransaction();
       
        String sql = "";
        string hier = "";


        string[] strCERefID= strChange.Split(',');
        try
        {
           foreach(string str in strCERefID)
           {
         if(str!="")
         {
             sql = "select hier_id from company_hierarchy_master  where ref_id=? and type='CE'";
                OleDbParameter[] paramCentreID = new OleDbParameter[1];
                paramCentreID[0] = new OleDbParameter("@centre_id", OleDbType.VarChar, 50);
                paramCentreID[0].Value = str;
                  OleDbDataReader dr;
                dr = OleDbHelper.ExecuteReader(sqlTrans, CommandType.Text, sql, paramCentreID);
              
       
                     while(dr.Read())
                     {

                                   string strUniqueHierId = oCmn.GetUniqueID("COMPANY_HIERARCHY_MASTER", strPrefix).ToString();


                                   string strHierarchy = "Insert into COMPANY_HIERARCHY_MASTER values (?, ?, ?, ?, ?)";
                                   OleDbParameter[] paramHierarchy = new OleDbParameter[5];
                                   paramHierarchy[0] = new OleDbParameter("@HIER_ID", OleDbType.VarChar, 50);
                                   paramHierarchy[0].Value = strUniqueHierId;
                                   paramHierarchy[1] = new OleDbParameter("@REF_ID", OleDbType.VarChar, 50);
                                   paramHierarchy[1].Value = strActivityID;
                                   paramHierarchy[2] = new OleDbParameter("@HIER_LEVEL", OleDbType.Numeric);
                                   paramHierarchy[2].Value = 4;
                                   paramHierarchy[3] = new OleDbParameter("@PARENT_ID", OleDbType.VarChar, 50);
                                   paramHierarchy[3].Value = dr["hier_id"];
                                   paramHierarchy[4] = new OleDbParameter("@TYPE", OleDbType.VarChar, 5);
                                   paramHierarchy[4].Value = "AC";

                                   OleDbHelper.ExecuteNonQuery(sqlTrans, CommandType.Text, strHierarchy, paramHierarchy);

                                   strMassage = "Activity changed successfully";
                             
                           
                   }
                 }
              }  
            
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
