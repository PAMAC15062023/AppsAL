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
using System.Collections;

/// <summary>
/// Summary description for CBISENTRY
/// </summary>
public class CBISENTRY
{
    CCommon con = new CCommon();
	public CBISENTRY()
	{
		//
		// TODO: Add constructor logic here
		//
	}
  private  string strKitRecievedDate;
    public string KitReceivedDate
    {
        get { return strKitRecievedDate; }
        set { strKitRecievedDate = value; }
    }
    private string strApproval;
    public string Approval
    {
        get { return strApproval; }
        set { strApproval = value; }
    }

  private   string strEMPID;
    public string EMPID
    {
        get { return strEMPID; }
        set { strEMPID = value; }
    }
    private string strEMPCODE;
    public string EMPCODE
    {
        get { return strEMPCODE; }
        set { strEMPCODE = value; }
    }
    private string strEMPNAME;
    public string EMPNAME   
    {
        get { return strEMPNAME; }
        set { strEMPNAME = value; }
    }
    private string strPF;
    public string PF
    {
        get { return strPF; }
        set { strPF = value; }
    }
    private string strESIC;
    public string ESIC
    {
        get { return strESIC; }
        set { strESIC = value; }
    }
    private string strDolReason;
    public string DolReason
    {
        get { return strDolReason; }
        set { strDolReason = value; }
    }
    private string strDOL;
    public string DOL
    {
        get { return strDOL; }
        set
        {
            if (value == "")
            {
                strDOL = null;
            }
            else
            {
                strDOL = value;
            }
        }
    }

    string strSubCentreID;
    public string SubCentreID
    {
        get { return strSubCentreID; }
        set { strSubCentreID = value; }
    }

    string strCentreID;
    public string CentreID
    {
        get { return strCentreID; }
        set { strCentreID = value; }
    }
    string strClusterID;
    public string ClusterID
    {
        get { return strClusterID; }
        set { strClusterID = value; }
    }
    string strApprovalOfCL;
    public string ApprovalOfCL
    {
        get { return strApprovalOfCL; }
        set { strApprovalOfCL = value; }
    }
    string strApprovalofHO;
    public string ApprovalOfHO
    {
        get { return strApprovalofHO; }
        set { strApprovalofHO = value; }
    }
    string strRemark;
    public string Remark
    {
        get { return strRemark; }
        set { strRemark = value; }
    }
    string strUserRole;
    public string UserRole
    {
        get { return strUserRole; }
        set { strUserRole = value; }
    }
    string strUserRole1;
    public string UserRole1
    {
        get { return strUserRole1; }
        set { strUserRole1 = value; }
    }
    string strUserIDOfCluster;
    public string UserIDCluster
    {
        get { return strUserIDOfCluster; }
        set { strUserIDOfCluster = value; }
    }
    string strUserIDOfHO;
    public string UserIDHO
    {
        get { return strUserIDOfHO; }
        set { strUserIDOfHO = value; }
    }
    public DataSet FillBISView(string strFromDate,string strToDate)
    {
       
        DataSet ds = new DataSet();
        string sqlStr = "";
        string strselectcriteria = "";
        string strselectcriteria1 = "";
        if(SubCentreID != "0" && CentreID!="0" && ClusterID !="0")
        {
            strselectcriteria = " and EM.centre_id='" + CentreID + "' and SUBCENTRE_ID='" + SubCentreID + "' and cm.cluster_id='" + ClusterID + "'";
           
        }
        if (SubCentreID == "0" && CentreID != "0" && ClusterID != "0")
        
        {
            strselectcriteria = " and EM.centre_id='" + CentreID + "'  and cm.cluster_id='" + ClusterID + "'";
        }
        if (SubCentreID == "0" && CentreID == "0" && ClusterID != "0")
        {
            strselectcriteria = "  and cm.cluster_id='" + ClusterID + "'";
        }
        if (SubCentreID != "0" && CentreID == "0" && ClusterID != "0")
        {
            strselectcriteria = "and SUBCENTRE_ID='" + SubCentreID + "'  and cm.cluster_id='" + ClusterID + "'";
        }
        if (SubCentreID != "0" && CentreID != "0" && ClusterID == "0")
        {
            strselectcriteria = "and SUBCENTRE_ID='" + SubCentreID + "'  and cm.cluster_id='" + ClusterID + "'";
        }
        if (strFromDate != "" && strToDate != "")
        {
            strselectcriteria += " and  DOJ >='" + Convert.ToDateTime(con.strDate(strFromDate)).ToString("dd-MMM-yyyy") + "' and DOJ < '" + Convert.ToDateTime(con.strDate(strToDate)).AddDays(1.0).ToString("dd-MMM-yyyy") + "' ";
        }
        if (UserRole1 != "HO-HR")
        {
            strselectcriteria1 = " and (APPROVED_BY_CLUSTER is null or APPROVED_BY_CLUSTER='NS' or APPROVED_BY_CLUSTER='N') and  ( APPROVED_BY_HOHR is null or APPROVED_BY_HOHR='NS' or APPROVED_BY_HOHR='N')";

        }
       
            if (EMPCODE != null)
            {
                strselectcriteria += " and emp_code='" + EMPCODE + "'";
            }
            if (EMPNAME != null)
            {
                strselectcriteria += " and ( ISNULL(FIRSTNAME + ' ', '') +ISNULL(MIDDLENAME + ' ', '') + ISNULL(LASTNAME + ' ', '') like '%"+EMPNAME+"%') ";
            }
        
        //sqlStr = " select distinct emp_code as[EMP CODE],DOJ,DOL,TEMP_EMP_CODE, CLM.CLUSTER_NAME,CM.CENTRE_NAME,SCM.SubCentreName ,  cast( em.emp_id as numeric)as emp_id ,APPROVED_BY_CLUSTER,APPROVED_BY_HOHR,emp_code as[EMP CODE],(ISNULL(FIRSTNAME + ' ', '') +ISNULL(MIDDLENAME + ' ', '') + ISNULL(LASTNAME + ' ', '')) " +
        //             " AS PAMACIAN,DEPARTMENT,DESIGNATION,ACTIVITY_NAME as UNIT from employee_master EM  inner join CENTRE_MASTER cm on(em.centre_id=cm.centre_id)inner join CLUSTER_MASTER CLM on(CLM.CLUSTER_ID=CM.CLUSTER_ID)INNER JOIN SubCentreMaster SCM ON(EM.SUBCENTRE_ID=SCM.SubCentreId)" +
        //             " left outer join DEPARTMENT_MASTER DM on(EM.DEPARTMENT_ID=DM.DEPT_ID)" +
        //             " left outer join DESIGNATION_MASTER DES on(DES.DESIGNATION_ID=EM.DESIGNATION_ID) left outer join Activity_master am on(am.activity_id=em.activity_id)" +
        //             " where 1=1  " + strselectcriteria + " and 1=1 "+strselectcriteria1+"    order by cast( emp_id as numeric) desc";
            sqlStr = " select distinct emp_code as[EMP CODE],DOJ,DOL,TEMP_EMP_CODE, CLM.CLUSTER_NAME,CM.CENTRE_NAME,SCM.SubCentreName ,  cast( em.emp_id as numeric)as emp_id ,APPROVED_BY_CLUSTER,APPROVED_BY_HOHR,emp_code as[EMP CODE],(ISNULL(FIRSTNAME + ' ', '') +ISNULL(MIDDLENAME + ' ', '') + ISNULL(LASTNAME + ' ', '')) " +
                         " AS PAMACIAN,DEPARTMENT,DESIGNATION,ACTIVITY_NAME as UNIT from employee_master EM  inner join CENTRE_MASTER cm on(em.centre_id=cm.centre_id)inner join CLUSTER_MASTER CLM on(CLM.CLUSTER_ID=CM.CLUSTER_ID)INNER JOIN SubCentreMaster SCM ON(EM.SUBCENTRE_ID=SCM.SubCentreId)" +
                         " left outer join DEPARTMENT_MASTER DM on(EM.DEPARTMENT_ID=DM.DEPT_ID)" +
                         " left outer join DESIGNATION_MASTER DES on(DES.DESIGNATION_ID=EM.DESIGNATION_ID) left outer join Activity_master am on(am.activity_id=em.activity_id)" +
                         " where 1=1  " + strselectcriteria + " and 1=1 " + strselectcriteria1 + "    order by cast( emp_id as numeric) desc";            

        
        if (Approval == "Approval")
        {
            if (UserRole1 == "SubCentreHead")
            {
                strselectcriteria += " and(APPROVED_BY_CLUSTER is null or APPROVED_BY_CLUSTER='NS' or APPROVED_BY_HOHR is null or APPROVED_BY_HOHR='NS' or APPROVED_BY_HOHR='N')";
            }
            if (UserRole1 == "CentreHead")
            {
                strselectcriteria += " and (APPROVED_BY_CLUSTER is null or APPROVED_BY_CLUSTER='NS' or APPROVED_BY_HOHR is null or APPROVED_BY_HOHR='NS' or APPROVED_BY_HOHR='N')";
            }
            if (UserRole1 == "HO-HR")
            {
                strselectcriteria += " and ( APPROVED_BY_HOHR is null or APPROVED_BY_HOHR='NS' or APPROVED_BY_HOHR='N')";

            }
            if (UserRole1 == "Cluster-HR")
            {
                strselectcriteria += " and (APPROVED_BY_CLUSTER is null or APPROVED_BY_CLUSTER='NS' or APPROVED_BY_CLUSTER='N')";
            }

            //sqlStr = " select distinct emp_code as[EMP CODE],DOJ,DOL,TEMP_EMP_CODE, CLM.CLUSTER_NAME,CM.CENTRE_NAME,SCM.SubCentreName , cast( em.emp_id as numeric)as emp_id ,APPROVED_BY_CLUSTER,APPROVED_BY_HOHR,emp_code as[EMP CODE],(ISNULL(FIRSTNAME + ' ', '') +ISNULL(MIDDLENAME + ' ', '') + ISNULL(LASTNAME + ' ', '')) " +
            //         " AS PAMACIAN,DEPARTMENT,DESIGNATION,ACTIVITY_NAME as UNIT from employee_master EM  inner join CENTRE_MASTER cm on(em.centre_id=cm.centre_id)inner join CLUSTER_MASTER CLM on(CLM.CLUSTER_ID=CM.CLUSTER_ID)INNER JOIN SubCentreMaster SCM ON(EM.SUBCENTRE_ID=SCM.SubCentreId)" +
            //         " left outer join DEPARTMENT_MASTER DM on(EM.DEPARTMENT_ID=DM.DEPT_ID)" +
            //         " left outer join DESIGNATION_MASTER DES on(DES.DESIGNATION_ID=EM.DESIGNATION_ID) left outer join Activity_master am on(am.activity_id=em.activity_id)" +
            //         " where 1=1  " + strselectcriteria + " order by cast( emp_id as numeric) desc";
            sqlStr = " select distinct emp_code as[EMP CODE],DOJ,DOL,TEMP_EMP_CODE, CLM.CLUSTER_NAME,CM.CENTRE_NAME,SCM.SubCentreName , cast( em.emp_id as numeric)as emp_id ,APPROVED_BY_CLUSTER,APPROVED_BY_HOHR,emp_code as[EMP CODE],(ISNULL(FIRSTNAME + ' ', '') +ISNULL(MIDDLENAME + ' ', '') + ISNULL(LASTNAME + ' ', '')) " +
            " AS PAMACIAN,DEPARTMENT,DESIGNATION,ACTIVITY_NAME as UNIT from employee_master EM  inner join CENTRE_MASTER cm on(em.centre_id=cm.centre_id)inner join CLUSTER_MASTER CLM on(CLM.CLUSTER_ID=CM.CLUSTER_ID)INNER JOIN SubCentreMaster SCM ON(EM.SUBCENTRE_ID=SCM.SubCentreId)" +
            " left outer join DEPARTMENT_MASTER DM on(EM.DEPARTMENT_ID=DM.DEPT_ID)" +
            " left outer join DESIGNATION_MASTER DES on(DES.DESIGNATION_ID=EM.DESIGNATION_ID) left outer join Activity_master am on(am.activity_id=em.activity_id)" +
            " where 1=1  " + strselectcriteria + " order by cast( emp_id as numeric) desc";
        }
                         
        ds = OleDbHelper.ExecuteDataset(con.ConnectionString, CommandType.Text, sqlStr);
        return ds;
    }

    public void UpdateApproval(DataTable dt)
    {
        string strSql = "";

        try
        {
            if (UserRole == "Both")
            {
                OleDbParameter[] ParamBIS = new OleDbParameter[5];
                for (int i = 0; i <= dt.Rows.Count - 1; i++)
                {
                    OleDbConnection oledbConn = new OleDbConnection(con.ConnectionString);
                    oledbConn.Open();
                    OleDbTransaction oledbTrans = oledbConn.BeginTransaction();
                    try
                    {
                        strSql = " update employee_master set  APPROVED_BY_CLUSTER =?,APPROVED_BY_HOHR=?,USERID_OF_CLUSTER=?,USERID_OF_HO=? where EMP_ID=?";


                        ParamBIS[0] = new OleDbParameter("@ApprovalofCL", OleDbType.Char, 3);
                        ParamBIS[0].Value = dt.Rows[i]["APPRCL"];
                        ParamBIS[1] = new OleDbParameter("@ApprovalHR", OleDbType.Char, 3);
                        ParamBIS[1].Value = dt.Rows[i]["APPRHO"];
                        ParamBIS[2] = new OleDbParameter("@USERIDOFCLUSTER", OleDbType.VarChar, 15);
                        ParamBIS[2].Value = UserIDCluster;
                        ParamBIS[3] = new OleDbParameter("@USERIDOFHO", OleDbType.VarChar, 15);
                        ParamBIS[3].Value = UserIDHO;
                        ParamBIS[4] = new OleDbParameter("@EMPID", OleDbType.VarChar, 15);
                        ParamBIS[4].Value = dt.Rows[i]["EMPID_CL"];
                        OleDbHelper.ExecuteNonQuery(oledbTrans, CommandType.Text, strSql, ParamBIS);
                        oledbTrans.Commit();
                        oledbConn.Close();
                    }
                    catch (Exception ex)
                    {
                        oledbTrans.Rollback();
                        oledbConn.Close();
                    }

                }
            }
            if (UserRole == "Cluster")
            {
                OleDbParameter[] ParamBIS = new OleDbParameter[3];

               
                for (int i = 0; i <= dt.Rows.Count - 1; i++)
                {
                    OleDbConnection oledbConn = new OleDbConnection(con.ConnectionString);
                    oledbConn.Open();
                    OleDbTransaction oledbTrans = oledbConn.BeginTransaction();
                    try
                    {
                        strSql = " update employee_master set  APPROVED_BY_CLUSTER =?, USERID_OF_CLUSTER=? where EMP_ID=?";
                        ParamBIS[0] = new OleDbParameter("@ApprovalofCL", OleDbType.Char, 3);
                        ParamBIS[0].Value = dt.Rows[i]["APPRCL"];
                        ParamBIS[1] = new OleDbParameter("@USERIDOFCLUSTER", OleDbType.VarChar, 15);
                        ParamBIS[1].Value = UserIDCluster;
                        ParamBIS[2] = new OleDbParameter("@EMPID", OleDbType.VarChar, 15);
                        ParamBIS[2].Value = dt.Rows[i]["EMPID_Cl"];
                        OleDbHelper.ExecuteNonQuery(oledbTrans, CommandType.Text, strSql, ParamBIS);
                        oledbTrans.Commit();
                        oledbConn.Close();
                    }
                    catch (Exception ex)
                    {
                        oledbTrans.Rollback();
                        oledbConn.Close();
                    }
                }

            }
            if (UserRole == "HO")
            {
                OleDbParameter[] ParamBIS = new OleDbParameter[3];
            
                for (int i = 0; i <= dt.Rows.Count - 1; i++)
                {
                    OleDbConnection oledbConn = new OleDbConnection(con.ConnectionString);
                    oledbConn.Open();
                    OleDbTransaction oledbTrans = oledbConn.BeginTransaction();
                    try
                    {
                        strSql = " update employee_master set APPROVED_BY_HOHR=?,USERID_OF_HO=? where EMP_ID=?";
                        ParamBIS[0] = new OleDbParameter("@ApprovalHR", OleDbType.Char, 3);
                        ParamBIS[0].Value = dt.Rows[i]["APPRHO"];
                        ParamBIS[1] = new OleDbParameter("@USERIDOFHO", OleDbType.VarChar, 15);
                        ParamBIS[1].Value = UserIDHO;
                        ParamBIS[2] = new OleDbParameter("@USERIDOFHO", OleDbType.VarChar, 15);
                        ParamBIS[2].Value = dt.Rows[i]["EMPID_HO"];
                        OleDbHelper.ExecuteNonQuery(oledbTrans, CommandType.Text, strSql, ParamBIS);
                        oledbTrans.Commit();
                        oledbConn.Close();
                    }
                    catch (Exception ex)
                    {
                        oledbTrans.Rollback();
                        oledbConn.Close();
                    }

                }

            }
        }
        catch (Exception ex)
        {
           
        }
    }
    public OleDbDataReader GetEMPCODE(string str)
    {
        OleDbDataReader dr;
        OleDbConnection oledbConn = new OleDbConnection(con.ConnectionString);
        string strSql = "select emp_code,(isNull(FIRSTNAME,'')+' '+isNull(MIDDLENAME,'')+' '+isNull(LASTNAME,''))as emp_name,TEMP_EMP_CODE from employee_master where emp_id='" + str + "'";

       dr= OleDbHelper.ExecuteReader(oledbConn, CommandType.Text, strSql);
       return dr;

    }
    public void Updatephoto(string sEMPID ,string strPhotoPath)
    {
        OleDbConnection oledbConn = new OleDbConnection(con.ConnectionString);
        string strSql = "update employee_master set PHOTO_PATH='" + strPhotoPath + "' where emp_id='" + sEMPID + "' ";
        OleDbHelper.ExecuteNonQuery(oledbConn, CommandType.Text, strSql);
    }
   
    public DataSet DedupSearch(string strFirstName,string strLastName)
    {
        string strSql = "";
        string strCriteria = "";
        if (UserRole1 == "HO-HR")
        {
            strCriteria = "1=1";
        }
        else if (UserRole1 == "Cluster-HR")
        {
            strCriteria = "CM.CLUSTER_ID=" + ClusterID + " ";
        }
        else
            strCriteria = "CM.CENTRE_ID=" + CentreID + " ";
        DataSet ds = new DataSet();
         OleDbConnection oledbConn = new OleDbConnection(con.ConnectionString);
        //strSql = " select ISNULL(FIRSTNAME, '') + ' ' + ISNULL(MIDDLENAME, '') + ' ' + ISNULL(LASTNAME, '')as EMPName, "+
        //         " DOB,DOJ,DOL,CLUSTER_NAME,CENTRE_NAME,SubCentreName,Department from employee_master em inner join subcentremaster sc " +
        //         " on(sc.SubCentreId=em.SUBCENTRE_ID) inner join CENTRE_MASTER cm on(em.centre_id=cm.centre_id)inner join CLUSTER_MASTER CLM on(CLM.CLUSTER_ID=CM.CLUSTER_ID) " +
        //         " left outer join DEPARTMENT_MASTER DM on (DM.DEPT_ID=em.DEPARTMENT_ID) where " + strCriteria + " " +
        //         " and (FIRSTNAME='" + strFirstName + "' or FIRSTNAME='" + strLastName + "') and (LASTNAME='" + strFirstName + "'or LASTNAME='" + strLastName + "')";
         strSql = " select ISNULL(FIRSTNAME, '') + ' ' + ISNULL(MIDDLENAME, '') + ' ' + ISNULL(LASTNAME, '')as EMPName, " +
                  " DOB,DOJ,DOL,DOL_Reason,CLUSTER_NAME,CENTRE_NAME,SubCentreName,Department from employee_master em inner join subcentremaster sc " +
                  " on(sc.SubCentreId=em.SUBCENTRE_ID) inner join CENTRE_MASTER cm on(em.centre_id=cm.centre_id)inner join CLUSTER_MASTER CLM on(CLM.CLUSTER_ID=CM.CLUSTER_ID) " +
                  " left outer join DEPARTMENT_MASTER DM on (DM.DEPT_ID=em.DEPARTMENT_ID) where " + strCriteria + " " +
                  " and (FIRSTNAME='" + strFirstName + "' or FIRSTNAME='" + strLastName + "') and (LASTNAME='" + strFirstName + "'or LASTNAME='" + strLastName + "')";
        ds = OleDbHelper.ExecuteDataset(oledbConn, CommandType.Text, strSql);
        return ds;
 
    }
    public void ApproveCluster()
    {
        OleDbConnection sqlConn = new OleDbConnection(con.ConnectionString);
        sqlConn.Open();
        OleDbTransaction sqlTrans = sqlConn.BeginTransaction();
        string sSql = "";
        try
        {
            sSql = "update EMPLOYEE_MASTER set APPROVED_BY_CLUSTER=?, USERID_OF_CLUSTER=? , APPROVAL_DATE_CLUSTER=? where emp_id=? ";
            OleDbParameter[] param = new OleDbParameter[4];
            param[0] = new OleDbParameter("APPROVED_BY_CLUSTER", OleDbType.VarChar, 15);
            param[0].Value = ApprovalOfCL;
            param[1] = new OleDbParameter("USERID_OF_CLUSTER", OleDbType.VarChar, 15);
            param[1].Value = UserIDCluster;
            param[2] = new OleDbParameter("APPROVAL_DATE_CLUSTER", OleDbType.VarChar, 50);
            param[2].Value = System.DateTime.Now.ToString();
            param[3] = new OleDbParameter("emp_id", OleDbType.VarChar, 15);
            param[3].Value = EMPID;
            OleDbHelper.ExecuteNonQuery(sqlTrans, CommandType.Text, sSql, param);
            sqlTrans.Commit();
            sqlConn.Close();

        }
        catch (Exception ex)
        {
            sqlTrans.Rollback();
            sqlConn.Close();


        }
    }

    public void ApproveByHO()
    {
        OleDbConnection sqlConn = new OleDbConnection(con.ConnectionString);
        sqlConn.Open();
        OleDbTransaction sqlTrans = sqlConn.BeginTransaction();
        string sSql = "";
        try
        {
            sSql = "update EMPLOYEE_MASTER set USERID_OF_HO=?,APPROVED_BY_HOHR=?,KIT_RECEIVED_DATE=?,APPROVAL_DATE_HOHR=?,EMP_CODE=?,DOL=?,PF#=?,ESIC#=?,dol_reason=? where emp_id=? ";
            OleDbParameter[] param = new OleDbParameter[10];

            param[0] = new OleDbParameter("USERID_OF_HO", OleDbType.VarChar, 15);
            param[0].Value = UserIDHO;
            param[1] = new OleDbParameter("APPROVED_BY_HOHR", OleDbType.Char, 1);
            param[1].Value = ApprovalOfHO;
            param[2] = new OleDbParameter("KIT_RECEIVED_DATE", OleDbType.VarChar, 10);
            param[2].Value = KitReceivedDate;
            param[3] = new OleDbParameter("APPROVAL_DATE_HOHR", OleDbType.VarChar, 50);
            param[3].Value = System.DateTime.Now.ToString();
            param[4] = new OleDbParameter("MPCODE", OleDbType.VarChar, 15);
            param[4].Value = EMPCODE;
            param[5] = new OleDbParameter("DOL", OleDbType.Date);
            if (DOL != null )
                param[5].Value = Convert.ToDateTime(con.strDate(DOL));
            else
                param[5].Value = DOL;
            param[6] = new OleDbParameter("PF", OleDbType.VarChar, 50);
            param[6].Value = PF;
            param[7] = new OleDbParameter("ESIC", OleDbType.VarChar, 50);
            param[7].Value = ESIC;
            param[8] = new OleDbParameter("dol_reason", OleDbType.VarChar, 50);
            param[8].Value = DolReason;
            param[9] = new OleDbParameter("EMPID", OleDbType.VarChar, 15);
            param[9].Value = EMPID;
            OleDbHelper.ExecuteNonQuery(sqlTrans, CommandType.Text, sSql, param);
            sqlTrans.Commit();
            sqlConn.Close();

        }
        catch (Exception ex)
        {
            sqlTrans.Rollback();
            sqlConn.Close();


        }
    }
    public int GetSearch(string strEMPID,string strTable)
    {
        OleDbConnection oledbConn = new OleDbConnection(con.ConnectionString);
        string strSql = "select count(*) from " + strTable + " where emp_id=" + strEMPID + "";
       int i= (int) OleDbHelper.ExecuteScalar(oledbConn, CommandType.Text, strSql);
       return i;
    }
}
