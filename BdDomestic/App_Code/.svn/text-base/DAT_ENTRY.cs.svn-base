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
/// Summary description for DAT_ENTRY
/// </summary>
public class DAT_ENTRY
{
    CCommon con = new CCommon();
    DataSet ds = new DataSet();

    bool bColumnFlag;
    public bool ColumnFlag
    {
        get { return bColumnFlag; }
        set { bColumnFlag = value; }
    }
    string strMessage;
    public string Message
    {
        get { return strMessage; }
        set { strMessage = value; }
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
	public DAT_ENTRY()
	{
		//
		// TODO: Add constructor logic here
		// if (!IsPostBack)
        
	}
    public DataSet Fill_Grid()
    {
        DataSet ds1 = new DataSet();
        string sqlStr = "";
            //sqlStr = " select  distinct em.emp_id,emp_code as[Emp Code],(ISNULL(FIRSTNAME + ' ', '') +ISNULL(MIDDLENAME + ' ', '') + ISNULL(LASTNAME + ' ', '')) " +
            //         " AS Pamecian,ATTENDANCE,DEPARTMENT,DESIGNATION,UNIT from employee_master EM left outer join DATILY_ATTENDANCE DE on(de.emp_id=em.emp_id and [DATE]='" + System.DateTime.Now.ToString("dd-MMM-yyyy") + "') inner join CENTRE_MASTER cm on(em.centre_id=cm.centre_id)" +
            //         " left outer join DEPARTMENT_MASTER DM on(EM.DEPARTMENT_ID=DM.DEPT_ID)" +
            //         " left outer join DESIGNATION_MASTER DES on(DES.DESIGNATION_ID=EM.DESIGNATION_ID) " +
            //         " where   EM.centre_id='" + CentreID + "' and SUBCENTRE_ID='" + SubCentreID + "' and cm.cluster_id='" + ClusterID + "' and APPROVED_BY_HOHR='Y' and " +
            //         "(DOL >= '" + System.DateTime.Now.ToString("dd-MMM-yyyy") + "' or DOl is null) ";
        string strselectcriteria = "";
        if (SubCentreID != "0" && CentreID != "0" && ClusterID != "0")
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
        if (EMPCODE != null)
        {
            strselectcriteria += " and emp_code='" + EMPCODE + "'";
        }
        if (EMPNAME != null)
        {
            strselectcriteria += " and ( ISNULL(FIRSTNAME + ' ', '') +ISNULL(MIDDLENAME + ' ', '') + ISNULL(LASTNAME + ' ', '') like '%" + EMPNAME + "%') ";
        }
        if (DateTime.Now.Day <= 20)
        {
            sqlStr = " DECLARE @current_month CHAR(6) " +
                    " DECLARE @previous_month CHAR(6) " +
                    " SET @current_month = CONVERT(CHAR(6), GETDATE(), 112) " +
                    " SET @previous_month = CONVERT(CHAR(6), DATEADD(MONTH, -1, GETDATE()), 112) " +
                    " select  distinct em.emp_id,emp_code as[Emp Code],(ISNULL(FIRSTNAME +' ', '') +ISNULL(MIDDLENAME + ' ', '') + ISNULL(LASTNAME + ' ', '')) AS Pamecian, " +
                    " ATTENDANCE,DEPARTMENT,DESIGNATION,UNIT,Centre_name,SubcentreName from employee_master EM  " +
                    " left outer join DATILY_ATTENDANCE DE on(de.emp_id=em.emp_id and [DATE]='" + System.DateTime.Now.ToString("dd-MMM-yyyy") + "') " +
                    " inner join CENTRE_MASTER cm on(em.centre_id=cm.centre_id) " +
                     " inner join Subcentremaster scm on(em.SUBCENTRE_ID=scm.subcentreid) " +
                    " left outer join DEPARTMENT_MASTER DM on(EM.DEPARTMENT_ID=DM.DEPT_ID) " +
                    " left outer join DESIGNATION_MASTER DES on(DES.DESIGNATION_ID=EM.DESIGNATION_ID) " +
                    " where   1=1 " + strselectcriteria + " and (APPROVED_BY_HOHR='Y' OR APPROVED_BY_HOHR IS NULL) and " +
                    " (DOL >= '" + System.DateTime.Now.ToString("dd-MMM-yyyy") + "' or DOl is null) and DOJ<=CAST(@previous_month + '21' AS datetime)";
        }
        else
        {
            sqlStr = " DECLARE @current_month CHAR(6) " +
                   " DECLARE @previous_month CHAR(6) " +
                   " SET @current_month = CONVERT(CHAR(6), GETDATE(), 112) " +
                   " SET @previous_month = CONVERT(CHAR(6), DATEADD(MONTH, 1, GETDATE()), 112) " +
                   " select  distinct em.emp_id,emp_code as[Emp Code],(ISNULL(FIRSTNAME +' ', '') +ISNULL(MIDDLENAME + ' ', '') + ISNULL(LASTNAME + ' ', '')) AS Pamecian, " +
                   " ATTENDANCE,DEPARTMENT,DESIGNATION,UNIT,Centre_name,SubcentreName from employee_master EM  " +
                   " left outer join DATILY_ATTENDANCE DE on(de.emp_id=em.emp_id and [DATE]='" + System.DateTime.Now.ToString("dd-MMM-yyyy") + "') " +
                   " inner join CENTRE_MASTER cm on(em.centre_id=cm.centre_id) " +
                    " inner join Subcentremaster scm on(em.SUBCENTRE_ID=scm.subcentreid) " +
                   " left outer join DEPARTMENT_MASTER DM on(EM.DEPARTMENT_ID=DM.DEPT_ID) " +
                   " left outer join DESIGNATION_MASTER DES on(DES.DESIGNATION_ID=EM.DESIGNATION_ID) " +
                   " where  1=1 " + strselectcriteria + " and cm.cluster_id='" + ClusterID + "' and (APPROVED_BY_HOHR='Y' OR APPROVED_BY_HOHR IS NULL) and " +
                   " (DOL >= '" + System.DateTime.Now.ToString("dd-MMM-yyyy") + "' or DOl is null) and DOJ<=CAST(@current_month + '21' AS datetime)";
        }
        ds = OleDbHelper.ExecuteDataset(con.ConnectionString, CommandType.Text, sqlStr);
        if (ds.Tables[0].Rows.Count == 0)
        {
            if (DateTime.Now.Day <= 20)
            {
                sqlStr = " DECLARE @current_month CHAR(6) " +
                          " DECLARE @previous_month CHAR(6) " +
                          " SET @current_month = CONVERT(CHAR(6), GETDATE(), 112) " +
                          " SET @previous_month = CONVERT(CHAR(6), DATEADD(MONTH, -1, GETDATE()), 112) " +
                          " select distinct em.emp_id,emp_code as[Emp Code],(ISNULL(FIRSTNAME + ' ', '') +ISNULL(MIDDLENAME + ' ', '') + ISNULL(LASTNAME + ' ', '')) " +
                          " AS Pamecian,DEPARTMENT ,DESIGNATION,UNIT,Centre_name,SubcentreName from employee_master  EM left outer join DATILY_ATTENDANCE DE on(de.emp_id=em.emp_id) inner join CENTRE_MASTER cm on(em.centre_id=cm.centre_id)" +
                           " inner join Subcentremaster scm on(em.SUBCENTRE_ID=scm.subcentreid) " +
                          " left outer join DEPARTMENT_MASTER DM on(EM.DEPARTMENT_ID=DM.DEPT_ID)" +
                          " left outer join DESIGNATION_MASTER DES on(DES.DESIGNATION_ID=EM.DESIGNATION_ID) " +
                          " where  1=1 " + strselectcriteria + " and (APPROVED_BY_HOHR='Y' OR APPROVED_BY_HOHR IS NULL) and" +
                         " (DOL >= '" + System.DateTime.Now.ToString("dd-MMM-yyyy") + "' or DOl is null) and DOJ<=CAST(@previous_month + '21' AS datetime)";
            }
            else
            {
                sqlStr = " DECLARE @current_month CHAR(6) " +
                         " DECLARE @previous_month CHAR(6) " +
                         " SET @current_month = CONVERT(CHAR(6), GETDATE(), 112) " +
                         " SET @previous_month = CONVERT(CHAR(6), DATEADD(MONTH, 1, GETDATE()), 112) " +
                         " select distinct em.emp_id,emp_code as[Emp Code],(ISNULL(FIRSTNAME + ' ', '') +ISNULL(MIDDLENAME + ' ', '') + ISNULL(LASTNAME + ' ', '')) " +
                         " AS Pamecian,DEPARTMENT ,DESIGNATION,UNIT,Centre_name,SubcentreName from employee_master  EM left outer join DATILY_ATTENDANCE DE on(de.emp_id=em.emp_id) inner join CENTRE_MASTER cm on(em.centre_id=cm.centre_id)" +
                          " inner join Subcentremaster scm on(em.SUBCENTRE_ID=scm.subcentreid) " +
                         " left outer join DEPARTMENT_MASTER DM on(EM.DEPARTMENT_ID=DM.DEPT_ID)" +
                         " left outer join DESIGNATION_MASTER DES on(DES.DESIGNATION_ID=EM.DESIGNATION_ID) " +
                         " where  1=1 " + strselectcriteria + " and (APPROVED_BY_HOHR='Y' OR APPROVED_BY_HOHR IS NULL) and" +
                        " (DOL >= '" + System.DateTime.Now.ToString("dd-MMM-yyyy") + "' or DOl is null) and DOJ<=CAST(@current_month + '21' AS datetime)";
            }
            ds1 = OleDbHelper.ExecuteDataset(con.ConnectionString, CommandType.Text, sqlStr);
        }
        if (ds.Tables[0].Rows.Count != 0)
        { 
        return ds;
        }
        else
        return ds1;
    }
    public DataSet EditGrid(string sdate)
    {
        DataSet ds1 = new DataSet();
        string sqlStr = "";
        string strselectcriteria = "";
        if (EMPCODE != null)
        {
            strselectcriteria += " and emp_code='" + EMPCODE + "'";
        }
        if (EMPNAME != null)
        {
            strselectcriteria += " and ( ISNULL(FIRSTNAME + ' ', '') +ISNULL(MIDDLENAME + ' ', '') + ISNULL(LASTNAME + ' ', '') like '%" + EMPNAME + "%') ";
        }
        if (DateTime.Now.Day <= 20)
        {
            sqlStr = " DECLARE @current_month CHAR(6) " +
                          " DECLARE @previous_month CHAR(6) " +
                          " SET @current_month = CONVERT(CHAR(6), GETDATE(), 112) " +
                          " SET @previous_month = CONVERT(CHAR(6), DATEADD(MONTH, -1, GETDATE()), 112) " +
                          " select distinct em.emp_id,emp_code as[Emp Code],(ISNULL(FIRSTNAME + ' ', '') +ISNULL(MIDDLENAME + ' ', '') + ISNULL(LASTNAME + ' ', '')) " +
                          " AS Pamecian,ATTENDANCE,DEPARTMENT ,DESIGNATION,UNIT,Centre_name,SubcentreName from employee_master EM left outer join DATILY_ATTENDANCE DE on(de.emp_id=em.emp_id  and [DATE]='" + sdate + "') inner join CENTRE_MASTER cm on(em.centre_id=cm.centre_id)" +
                           " inner join Subcentremaster scm on(em.SUBCENTRE_ID=scm.subcentreid) " +
                          " left outer join DEPARTMENT_MASTER DM on(EM.DEPARTMENT_ID=DM.DEPT_ID)" +
                          " left outer join DESIGNATION_MASTER DES on(DES.DESIGNATION_ID=EM.DESIGNATION_ID) " +
                          " where   EM.centre_id='" + CentreID + "' and SUBCENTRE_ID='" + SubCentreID + "'   and (APPROVED_BY_HOHR='Y' OR APPROVED_BY_HOHR IS NULL) and" +
                         " (DOL >= '" + System.DateTime.Now.ToString("dd-MMM-yyyy") + "' or DOl is null) and DOJ<=CAST(@previous_month + '21' AS datetime)"+strselectcriteria+" ";
        }
        else
        {
            sqlStr = " DECLARE @current_month CHAR(6) " +
                          " DECLARE @previous_month CHAR(6) " +
                          " SET @current_month = CONVERT(CHAR(6), GETDATE(), 112) " +
                          " SET @previous_month = CONVERT(CHAR(6), DATEADD(MONTH, 1, GETDATE()), 112) " +
                          " select distinct em.emp_id,emp_code as[Emp Code],(ISNULL(FIRSTNAME + ' ', '') +ISNULL(MIDDLENAME + ' ', '') + ISNULL(LASTNAME + ' ', '')) " +
                          " AS Pamecian,ATTENDANCE,DEPARTMENT ,DESIGNATION,UNIT,Centre_name,SubcentreName from employee_master EM left outer join DATILY_ATTENDANCE DE on(de.emp_id=em.emp_id  and [DATE]='" + sdate + "') inner join CENTRE_MASTER cm on(em.centre_id=cm.centre_id)" +
                           " inner join Subcentremaster scm on(em.SUBCENTRE_ID=scm.subcentreid) " +
                          " left outer join DEPARTMENT_MASTER DM on(EM.DEPARTMENT_ID=DM.DEPT_ID)" +
                          " left outer join DESIGNATION_MASTER DES on(DES.DESIGNATION_ID=EM.DESIGNATION_ID) " +
                          " where   EM.centre_id='" + CentreID + "' and SUBCENTRE_ID='" + SubCentreID + "'    and (APPROVED_BY_HOHR='Y' OR APPROVED_BY_HOHR IS NULL) and" +
                         " (DOL >= '" + System.DateTime.Now.ToString("dd-MMM-yyyy") + "' or DOl is null) and DOJ<=CAST(@current_month + '21' AS datetime)" + strselectcriteria + " ";
        }
        ds = OleDbHelper.ExecuteDataset(con.ConnectionString, CommandType.Text, sqlStr);
        if (ds.Tables[0].Rows.Count == 0)
        {
            if (DateTime.Now.Day <= 20)
            {
                sqlStr = " DECLARE @current_month CHAR(6) " +
                         " DECLARE @previous_month CHAR(6) " +
                         " SET @current_month = CONVERT(CHAR(6), GETDATE(), 112) " +
                         " SET @previous_month = CONVERT(CHAR(6), DATEADD(MONTH, -1, GETDATE()), 112) " +
                        " select distinct em.emp_id,emp_code as[Emp Code],(ISNULL(FIRSTNAME + ' ', '') +ISNULL(MIDDLENAME + ' ', '') + ISNULL(LASTNAME + ' ', '')) " +
                        " AS Pamecian,ATTENDANCE,DEPARTMENT ,DESIGNATION,UNIT,Centre_name,SubcentreName from employee_master EM left outer join DATILY_ATTENDANCE DE on(de.emp_id=em.emp_id  and [DATE]='" + sdate + "') inner join CENTRE_MASTER cm on(em.centre_id=cm.centre_id)" +
                         " inner join Subcentremaster scm on(em.SUBCENTRE_ID=scm.subcentreid) " +
                        " left outer join DEPARTMENT_MASTER DM on(EM.DEPARTMENT_ID=DM.DEPT_ID)" +
                        " left outer join DESIGNATION_MASTER DES on(DES.DESIGNATION_ID=EM.DESIGNATION_ID) " +
                        " where   EM.centre_id='" + CentreID + "' and SUBCENTRE_ID='" + SubCentreID + "'   and (APPROVED_BY_HOHR='Y' OR APPROVED_BY_HOHR IS NULL) and" +
                       " (DOL >= '" + System.DateTime.Now.ToString("dd-MMM-yyyy") + "' or DOl is null) and DOJ<=CAST(@previous_month + '21' AS datetime) " + strselectcriteria + " ";
            }
            else
            {
                sqlStr = " DECLARE @current_month CHAR(6) " +
                        " DECLARE @previous_month CHAR(6) " +
                        " SET @current_month = CONVERT(CHAR(6), GETDATE(), 112) " +
                        " SET @previous_month = CONVERT(CHAR(6), DATEADD(MONTH, 1, GETDATE()), 112) " +
                       " select distinct em.emp_id,emp_code as[Emp Code],(ISNULL(FIRSTNAME + ' ', '') +ISNULL(MIDDLENAME + ' ', '') + ISNULL(LASTNAME + ' ', '')) " +
                       " AS Pamecian,ATTENDANCE,DEPARTMENT ,DESIGNATION,UNIT,Centre_name,SubcentreName from employee_master EM left outer join DATILY_ATTENDANCE DE on(de.emp_id=em.emp_id  and [DATE]='" + sdate + "') inner join CENTRE_MASTER cm on(em.centre_id=cm.centre_id)" +
                        " inner join Subcentremaster scm on(em.SUBCENTRE_ID=scm.subcentreid) " +
                       " left outer join DEPARTMENT_MASTER DM on(EM.DEPARTMENT_ID=DM.DEPT_ID)" +
                       " left outer join DESIGNATION_MASTER DES on(DES.DESIGNATION_ID=EM.DESIGNATION_ID) " +
                       " where   EM.centre_id='" + CentreID + "' and SUBCENTRE_ID='" + SubCentreID + "'   and (APPROVED_BY_HOHR='Y' OR APPROVED_BY_HOHR IS NULL) and" +
                      " (DOL >= '" + System.DateTime.Now.ToString("dd-MMM-yyyy") + "' or DOl is null) and DOJ<=CAST(@current_month + '21' AS datetime) " + strselectcriteria + " ";
            }
            ds1 = OleDbHelper.ExecuteDataset(con.ConnectionString, CommandType.Text, sqlStr);
 
        }
        if (ds.Tables[0].Rows.Count != 0)
        {
            return ds;
        }
        else
            return ds1;
    }
    public DataSet GetToDayAttenance()
    {
        DataSet ds1 = new DataSet();
        string sqlStr = "";
        string strselectcriteria = "";
        if (SubCentreID != "0" && CentreID != "0" && ClusterID != "0")
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
        if (System.DateTime.Now.AddDays(-1).DayOfWeek.ToString() != "Sunday")
        {
            if (DateTime.Now.Day <= 20)
            {
                sqlStr = " DECLARE @current_month CHAR(6) " +
                         " DECLARE @previous_month CHAR(6) " +
                         " SET @current_month = CONVERT(CHAR(6), GETDATE(), 112) " +
                         " SET @previous_month = CONVERT(CHAR(6), DATEADD(MONTH, -1, GETDATE()), 112) " +
                         " select em.emp_id,ATTENDANCE,DEPARTMENT ,DESIGNATION,UNIT,Centre_name,SubcentreName from employee_master EM left outer join DATILY_ATTENDANCE DE on(de.emp_id=em.emp_id and [DATE]='" + System.DateTime.Now.AddDays(-1).ToString("dd-MMM-yyyy") + "') inner join CENTRE_MASTER cm on(em.centre_id=cm.centre_id) " +
                          " inner join Subcentremaster scm on(em.SUBCENTRE_ID=scm.subcentreid) " +
                         " left outer join DEPARTMENT_MASTER DM on(EM.DEPARTMENT_ID=DM.DEPT_ID)" +
                         " left outer join DESIGNATION_MASTER DES on(DES.DESIGNATION_ID=EM.DESIGNATION_ID) " +
                         " where 1=1 "+ strselectcriteria +"  and (APPROVED_BY_HOHR='Y' OR APPROVED_BY_HOHR IS NULL) and" +
                        " (DOL >= '" + System.DateTime.Now.ToString("dd-MMM-yyyy") + "' or DOl is null) and DOJ<=CAST(@previous_month + '21' AS datetime)";
            }
            else
            {
                sqlStr = " DECLARE @current_month CHAR(6) " +
                         " DECLARE @previous_month CHAR(6) " +
                         " SET @current_month = CONVERT(CHAR(6), GETDATE(), 112) " +
                         " SET @previous_month = CONVERT(CHAR(6), DATEADD(MONTH, 1, GETDATE()), 112) " +
                         " select em.emp_id,ATTENDANCE,DEPARTMENT ,DESIGNATION,UNIT,Centre_name,SubcentreName from employee_master EM left outer join DATILY_ATTENDANCE DE on(de.emp_id=em.emp_id and [DATE]='" + System.DateTime.Now.AddDays(-1).ToString("dd-MMM-yyyy") + "') inner join CENTRE_MASTER cm on(em.centre_id=cm.centre_id) " +
                          " inner join Subcentremaster scm on(em.SUBCENTRE_ID=scm.subcentreid) " +
                         " left outer join DEPARTMENT_MASTER DM on(EM.DEPARTMENT_ID=DM.DEPT_ID)" +
                         " left outer join DESIGNATION_MASTER DES on(DES.DESIGNATION_ID=EM.DESIGNATION_ID) " +
                         " where  1=1 " + strselectcriteria + " and (APPROVED_BY_HOHR='Y' OR APPROVED_BY_HOHR IS NULL) and" +
                        " (DOL >= '" + System.DateTime.Now.ToString("dd-MMM-yyyy") + "' or DOl is null) and DOJ<=CAST(@current_month + '21' AS datetime)";
            }
        }
        else
        {
            if (DateTime.Now.Day <= 20)
            {
                sqlStr = " DECLARE @current_month CHAR(6) " +
                         " DECLARE @previous_month CHAR(6) " +
                         " SET @current_month = CONVERT(CHAR(6), GETDATE(), 112) " +
                         " SET @previous_month = CONVERT(CHAR(6), DATEADD(MONTH, -1, GETDATE()), 112) " +
                         " select em.emp_id,ATTENDANCE,DEPARTMENT ,DESIGNATION,UNIT,Centre_name,SubcentreName from employee_master EM left outer join DATILY_ATTENDANCE DE on(de.emp_id=em.emp_id and [DATE]='" + System.DateTime.Now.AddDays(-2).ToString("dd-MMM-yyyy") + "') inner join CENTRE_MASTER cm on(em.centre_id=cm.centre_id) " +
                          " inner join Subcentremaster scm on(em.SUBCENTRE_ID=scm.subcentreid) " +
                         " left outer join DEPARTMENT_MASTER DM on(EM.DEPARTMENT_ID=DM.DEPT_ID)" +
                         " left outer join DESIGNATION_MASTER DES on(DES.DESIGNATION_ID=EM.DESIGNATION_ID) " +
                         " where  1=1 " + strselectcriteria + " and (APPROVED_BY_HOHR='Y' OR APPROVED_BY_HOHR IS NULL) and" +
                        " (DOL >= '" + System.DateTime.Now.ToString("dd-MMM-yyyy") + "' or DOl is null) and DOJ<=CAST(@previous_month + '21' AS datetime)";
            }
            else
            {
                sqlStr = " DECLARE @current_month CHAR(6) " +
                        " DECLARE @previous_month CHAR(6) " +
                        " SET @current_month = CONVERT(CHAR(6), GETDATE(), 112) " +
                        " SET @previous_month = CONVERT(CHAR(6), DATEADD(MONTH, 1, GETDATE()), 112) " +
                        " select em.emp_id,ATTENDANCE,DEPARTMENT ,DESIGNATION,UNIT,Centre_name,SubcentreName from employee_master EM left outer join DATILY_ATTENDANCE DE on(de.emp_id=em.emp_id and [DATE]='" + System.DateTime.Now.AddDays(-2).ToString("dd-MMM-yyyy") + "') inner join CENTRE_MASTER cm on(em.centre_id=cm.centre_id) " +
                         " inner join Subcentremaster scm on(em.SUBCENTRE_ID=scm.subcentreid) " +
                        " left outer join DEPARTMENT_MASTER DM on(EM.DEPARTMENT_ID=DM.DEPT_ID)" +
                        " left outer join DESIGNATION_MASTER DES on(DES.DESIGNATION_ID=EM.DESIGNATION_ID) " +
                        " where  1=1 " + strselectcriteria + "  and (APPROVED_BY_HOHR='Y' OR APPROVED_BY_HOHR IS NULL) and" +
                       " (DOL >= '" + System.DateTime.Now.ToString("dd-MMM-yyyy") + "' or DOl is null) and DOJ<=CAST(@current_month + '21' AS datetime)";
            }
        }
        ds1 = OleDbHelper.ExecuteDataset(con.ConnectionString, CommandType.Text, sqlStr);
        return ds1;
    }
    ////////////////////public void InsertAttendence(ArrayList ArrListEmp, ArrayList ArrListAtten, ArrayList ArrPreAtten, string AlistCreBy, DateTime AlistCreDate, string AlistModBy, DateTime AlistModDate)
    ////////////////////{

    ////////////////////        OleDbParameter[] paramGrid = new OleDbParameter[7];
    
    ////////////////////        OleDbParameter[] paramGrid1 = new OleDbParameter[7];
           
    ////////////////////        for (int i = 0; i <= ArrListEmp.Count-1; i++)
    ////////////////////        {
               
    ////////////////////            string strSql = "";
    ////////////////////            OleDbConnection conn = new OleDbConnection(con.ConnectionString);
    ////////////////////            conn.Open();
    ////////////////////            OleDbTransaction oledbTrans = conn.BeginTransaction();
    ////////////////////            int k = 0;
    ////////////////////            try
    ////////////////////            {


    ////////////////////                strSql = " select count(emp_id) from DATILY_ATTENDANCE where [Date]='" + System.DateTime.Now.ToString("dd-MMM-yyyy") + "' and emp_id=" + ArrListEmp[i].ToString() + "";
    ////////////////////                     k = Convert.ToInt32(OleDbHelper.ExecuteScalar(oledbTrans, CommandType.Text, strSql));
                    
    ////////////////////            if (k == 0)
    ////////////////////            {
    ////////////////////                strSql = "insert into DATILY_ATTENDANCE (EMP_ID,[DATE],ATTENDANCE,CreateBy,CreateDate,ModifyBy,ModifyDate) values(?,?,?,?,?,?,?)";
    ////////////////////                paramGrid[0] = new OleDbParameter("@EMP_ID", OleDbType.VarChar);
    ////////////////////                paramGrid[0].Value = ArrListEmp[i].ToString();
    ////////////////////                paramGrid[1] = new OleDbParameter("@[DATE]", OleDbType.Date);
    ////////////////////                paramGrid[1].Value = System.DateTime.Now.ToShortDateString();
    ////////////////////                paramGrid[2] = new OleDbParameter("@ATTENDANCE", OleDbType.VarChar);
    ////////////////////                paramGrid[2].Value = ArrListAtten[i].ToString();
    ////////////////////                paramGrid[3] = new OleDbParameter("@CreateBy", OleDbType.VarChar);
    ////////////////////                paramGrid[3].Value = AlistCreBy.ToString();
    ////////////////////                paramGrid[4] = new OleDbParameter("@CreateDate", OleDbType.Date);
    ////////////////////                paramGrid[4].Value = System.DateTime.Now.ToShortDateString();
    ////////////////////                paramGrid[5] = new OleDbParameter("@ModBy", OleDbType.VarChar);
    ////////////////////                paramGrid[5].Value = AlistModBy.ToString();
    ////////////////////                paramGrid[6] = new OleDbParameter("@ModDate", OleDbType.Date);
    ////////////////////                paramGrid[6].Value = System.DateTime.Now.ToShortDateString();
    ////////////////////               OleDbHelper.ExecuteNonQuery(oledbTrans, CommandType.Text, strSql, paramGrid);
    ////////////////////                Message = "Saved successfully !!!";
    ////////////////////            }
    ////////////////////            else
    ////////////////////            {
    ////////////////////                strSql = "update  DATILY_ATTENDANCE   SET  ATTENDANCE='" + ArrListAtten[i].ToString() + "',ModifyBy='" + AlistModBy.ToString() + "',ModifyDate='" + System.DateTime.Now.ToShortDateString() + "' where    [Date]='" + System.DateTime.Now.ToString("dd-MMM-yyyy") + "' and emp_id=" + ArrListEmp[i].ToString() + " ";
                  
    ////////////////////                OleDbHelper.ExecuteNonQuery(oledbTrans, CommandType.Text, strSql);
    ////////////////////                Message = "Updated successfully !!!";
    ////////////////////            }
    ////////////////////            oledbTrans.Commit();
    ////////////////////            conn.Close();
    ////////////////////            }
    ////////////////////            catch(Exception ex)
    ////////////////////            {
    ////////////////////            oledbTrans.Rollback();
    ////////////////////            conn.Close();
    ////////////////////            Message = ex.Message;
    ////////////////////            }
    ////////////////////            if (ColumnFlag == true)
    ////////////////////            {
    ////////////////////                OleDbConnection conn1 = new OleDbConnection(con.ConnectionString);
    ////////////////////                conn.Open();
    ////////////////////                OleDbTransaction oledbTrans1 = conn.BeginTransaction();
    ////////////////////                try
    ////////////////////                {


    ////////////////////                    if (System.DateTime.Now.AddDays(-1).DayOfWeek.ToString() != "Sunday")
    ////////////////////                    {
    ////////////////////                        strSql = " select count(emp_id) from DATILY_ATTENDANCE where   [DATE]='" + System.DateTime.Now.AddDays(-1).ToString("dd-MMM-yyyy") + "'  and emp_id=" + ArrListEmp[i].ToString() + " ";
    ////////////////////                    }
    ////////////////////                    else
    ////////////////////                        strSql = " select count(emp_id) from DATILY_ATTENDANCE where   [DATE]='" + System.DateTime.Now.AddDays(-2).ToString("dd-MMM-yyyy") + "'  and emp_id=" + ArrListEmp[i].ToString() + " ";
    ////////////////////                        k = Convert.ToInt32(OleDbHelper.ExecuteScalar(oledbTrans1, CommandType.Text, strSql));
                        
    ////////////////////                    if (k == 0)
    ////////////////////                    {
    ////////////////////                        strSql = "insert into DATILY_ATTENDANCE (EMP_ID,[DATE],ATTENDANCE) values(?,?,?)";
    ////////////////////                        paramGrid1[0] = new OleDbParameter("@EMP_ID", OleDbType.VarChar);
    ////////////////////                        paramGrid1[0].Value = ArrListEmp[i].ToString();
    ////////////////////                        paramGrid1[1] = new OleDbParameter("@[DATE]", OleDbType.Date);
    ////////////////////                        if (System.DateTime.Now.AddDays(-1).DayOfWeek.ToString() != "Sunday")
    ////////////////////                        {
    ////////////////////                            paramGrid1[1].Value = System.DateTime.Now.AddDays(-1).ToShortDateString();
    ////////////////////                        }
    ////////////////////                        else
    ////////////////////                            paramGrid1[1].Value = System.DateTime.Now.AddDays(-2).ToShortDateString();
    ////////////////////                        paramGrid1[2] = new OleDbParameter("@ATTENDANCE", OleDbType.VarChar);
    ////////////////////                        paramGrid1[2].Value = ArrPreAtten[i].ToString();
    ////////////////////                        OleDbHelper.ExecuteNonQuery(oledbTrans1, CommandType.Text, strSql, paramGrid1);
    ////////////////////                        Message = "Saved successfully !!!";
    ////////////////////                    }
    ////////////////////                    else
    ////////////////////                    {
    ////////////////////                        if (System.DateTime.Now.AddDays(-1).DayOfWeek.ToString() != "Sunday")
    ////////////////////                        {
    ////////////////////                            strSql = "update  DATILY_ATTENDANCE   SET  ATTENDANCE='" + ArrPreAtten[i].ToString() + "' where   [DATE]>='" + System.DateTime.Now.AddDays(-1).ToString("dd-MMM-yyyy") + "' and [DATE]<'" + System.DateTime.Now.ToString("dd-MMM-yyyy") + "' AND EMP_ID=" + ArrListEmp[i].ToString() + " ";
    ////////////////////                        }
    ////////////////////                        else
    ////////////////////                            strSql = "update  DATILY_ATTENDANCE   SET  ATTENDANCE='" + ArrPreAtten[i].ToString() + "' where   [DATE]>='" + System.DateTime.Now.AddDays(-2).ToString("dd-MMM-yyyy") + "' and [DATE]<'" + System.DateTime.Now.ToString("dd-MMM-yyyy") + "' AND EMP_ID=" + ArrListEmp[i].ToString() + " ";
                           
    ////////////////////                        OleDbHelper.ExecuteNonQuery(oledbTrans1, CommandType.Text, strSql );
    ////////////////////                        Message = "Updated successfully !!!";
    ////////////////////                    }
    ////////////////////                    oledbTrans1.Commit();
    ////////////////////                    conn1.Close();
    ////////////////////                }
    ////////////////////                catch (Exception ex)
    ////////////////////                {
    ////////////////////                    oledbTrans1.Rollback();
    ////////////////////                    conn1.Close();
    ////////////////////                    Message = ex.Message;
    ////////////////////                }
    ////////////////////            }
    ////////////////////        }
        
    ////////////////////}

    public void InsertAttendence(ArrayList ArrListEmp, ArrayList ArrListAtten, ArrayList ArrPreAtten, string AlistCreBy, DateTime AlistCreDate)
    {

        OleDbParameter[] paramGrid = new OleDbParameter[5];

        OleDbParameter[] paramGrid1 = new OleDbParameter[5];

        for (int i = 0; i <= ArrListEmp.Count - 1; i++)
        {

            string strSql = "";
            OleDbConnection conn = new OleDbConnection(con.ConnectionString);
            conn.Open();
            OleDbTransaction oledbTrans = conn.BeginTransaction();
            int k = 0;
            try
            {


                strSql = " select count(emp_id) from DATILY_ATTENDANCE where [Date]='" + System.DateTime.Now.ToString("dd-MMM-yyyy") + "' and emp_id=" + ArrListEmp[i].ToString() + "";
                k = Convert.ToInt32(OleDbHelper.ExecuteScalar(oledbTrans, CommandType.Text, strSql));

                if (k == 0)
                {
                    strSql = "insert into DATILY_ATTENDANCE (EMP_ID,[DATE],ATTENDANCE,CreateBy,CreateDate) values(?,?,?,?,?)";
                    paramGrid[0] = new OleDbParameter("@EMP_ID", OleDbType.VarChar);
                    paramGrid[0].Value = ArrListEmp[i].ToString();
                    paramGrid[1] = new OleDbParameter("@[DATE]", OleDbType.Date);
                    paramGrid[1].Value = System.DateTime.Now.ToShortDateString();
                    paramGrid[2] = new OleDbParameter("@ATTENDANCE", OleDbType.VarChar);
                    paramGrid[2].Value = ArrListAtten[i].ToString();
                    //paramGrid[3] = new OleDbParameter("@ModifyBy", OleDbType.VarChar);
                    // paramGrid[3].Value = AlistModBy.ToString();
                    //paramGrid[4] = new OleDbParameter("@ModifyDate", OleDbType.Date);
                    // paramGrid[4].Value = System.DateTime.Now.ToShortDateString();
                    paramGrid[3] = new OleDbParameter("@CreateBy", OleDbType.VarChar);
                    paramGrid[3].Value = AlistCreBy.ToString();
                    paramGrid[4] = new OleDbParameter("@CreateDate", OleDbType.Date);
                    paramGrid[4].Value = System.DateTime.Now.ToShortDateString();
                    OleDbHelper.ExecuteNonQuery(oledbTrans, CommandType.Text, strSql, paramGrid);
                    Message = "Saved successfully !!!";
                }
                else
                {
                    strSql = "update  DATILY_ATTENDANCE   SET  ATTENDANCE='" + ArrListAtten[i].ToString() + "',CreateBy='" + AlistCreBy.ToString() + "',CreateDate='" + System.DateTime.Now.ToString("dd-MMM-yyyy") + "' where    [Date]='" + System.DateTime.Now.ToString("dd-MMM-yyyy") + "' and emp_id=" + ArrListEmp[i].ToString() + " ";

                    OleDbHelper.ExecuteNonQuery(oledbTrans, CommandType.Text, strSql);
                    Message = "Updated successfully !!!";
                }
                oledbTrans.Commit();
                conn.Close();
            }
            catch (Exception ex)
            {
                oledbTrans.Rollback();
                conn.Close();
                Message = ex.Message;
            }
            if (ColumnFlag == true)
            {
                OleDbConnection conn1 = new OleDbConnection(con.ConnectionString);
                conn.Open();
                OleDbTransaction oledbTrans1 = conn.BeginTransaction();
                try
                {


                    if (System.DateTime.Now.AddDays(-1).DayOfWeek.ToString() != "Sunday")
                    {
                        strSql = " select count(emp_id) from DATILY_ATTENDANCE where   [DATE]='" + System.DateTime.Now.AddDays(-1).ToString("dd-MMM-yyyy") + "'  and emp_id=" + ArrListEmp[i].ToString() + " ";
                    }
                    else
                        strSql = " select count(emp_id) from DATILY_ATTENDANCE where   [DATE]='" + System.DateTime.Now.AddDays(-2).ToString("dd-MMM-yyyy") + "'  and emp_id=" + ArrListEmp[i].ToString() + " ";
                    k = Convert.ToInt32(OleDbHelper.ExecuteScalar(oledbTrans1, CommandType.Text, strSql));

                    if (k == 0)
                    {
                        strSql = "insert into DATILY_ATTENDANCE (EMP_ID,[DATE],ATTENDANCE,CreateBy,CreateDate) values(?,?,?,?,?)";
                        paramGrid1[0] = new OleDbParameter("@EMP_ID", OleDbType.VarChar);
                        paramGrid1[0].Value = ArrListEmp[i].ToString();
                        paramGrid1[1] = new OleDbParameter("@[DATE]", OleDbType.Date);
                        paramGrid1[1].Value = System.DateTime.Now.ToShortDateString();

                        //paramGrid[2] = new OleDbParameter("@Modify_id", OleDbType.VarChar);
                        //paramGrid[2].Value = AlistCreBy.ToString();
                        //paramGrid[3] = new OleDbParameter("@Modify_date", OleDbType.Date);
                        //paramGrid[3].Value = System.DateTime.Now.ToShortDateString();

                        paramGrid1[3] = new OleDbParameter("@CreateBy", OleDbType.VarChar);
                        paramGrid1[3].Value = AlistCreBy.ToString();
                        paramGrid1[4] = new OleDbParameter("@CreateDate", OleDbType.Date);
                        paramGrid1[4].Value = System.DateTime.Now.ToShortDateString();
                        if (System.DateTime.Now.AddDays(-1).DayOfWeek.ToString() != "Sunday")
                        {
                            paramGrid1[1].Value = System.DateTime.Now.AddDays(-1).ToShortDateString();
                        }
                        else
                            paramGrid1[1].Value = System.DateTime.Now.AddDays(-2).ToShortDateString();
                        paramGrid1[2] = new OleDbParameter("@ATTENDANCE", OleDbType.VarChar);
                        paramGrid1[2].Value = ArrPreAtten[i].ToString();
                        OleDbHelper.ExecuteNonQuery(oledbTrans1, CommandType.Text, strSql, paramGrid1);
                        Message = "Saved successfully !!!";
                    }
                    else
                    {
                        if (System.DateTime.Now.AddDays(-1).DayOfWeek.ToString() != "Sunday")
                        {
                            strSql = "update  DATILY_ATTENDANCE   SET  ATTENDANCE='" + ArrPreAtten[i].ToString() + "',CreateBy='" + AlistCreBy.ToString() + "',CreateDate='" + System.DateTime.Now.ToString("dd-MMM-yyyy") + "' where   [DATE]>='" + System.DateTime.Now.AddDays(-1).ToString("dd-MMM-yyyy") + "' and [DATE]<'" + System.DateTime.Now.ToString("dd-MMM-yyyy") + "' AND EMP_ID=" + ArrListEmp[i].ToString() + " ";
                        }
                        else
                            strSql = "update  DATILY_ATTENDANCE   SET  ATTENDANCE='" + ArrPreAtten[i].ToString() + "',CreateBy='" + AlistCreBy.ToString() + "',CreateDate='" + System.DateTime.Now.ToString("dd-MMM-yyyy") + "' where   [DATE]>='" + System.DateTime.Now.AddDays(-2).ToString("dd-MMM-yyyy") + "' and [DATE]<'" + System.DateTime.Now.ToString("dd-MMM-yyyy") + "' AND EMP_ID=" + ArrListEmp[i].ToString() + " ";

                        OleDbHelper.ExecuteNonQuery(oledbTrans1, CommandType.Text, strSql);
                        Message = "Updated successfully !!!";
                    }
                    oledbTrans1.Commit();
                    conn1.Close();
                }
                catch (Exception ex)
                {
                    oledbTrans1.Rollback();
                    conn1.Close();
                    Message = ex.Message;
                }
            }
        }
    }

    public DataSet GetHier()
    {
        DataSet ds = new DataSet();
        string strSql = "";
        strSql = " select cm.CENTRE_NAME,clm.cluster_name,SubCentreName from  centre_master cm " +
                        " inner join SubCentreMaster scb on(cm.CENTRE_ID=scb.CentreId) " +
                        " inner join cluster_master clm on(clm.cluster_id=cm.cluster_id) where SubCentreId = " + SubCentreID + " ";
        if (SubCentreID == "" || SubCentreID == null)
        {
             strSql = " select cm.CENTRE_NAME,clm.cluster_name from  centre_master cm " +

                           " inner join cluster_master clm on(clm.cluster_id=cm.cluster_id) where centre_id = " + CentreID + " ";
        }
        ds = OleDbHelper.ExecuteDataset(con.ConnectionString, CommandType.Text, strSql);
        return ds;
    }
    ////////////////////public void UpdateAttendaceByHO(ArrayList ArrListEmp, ArrayList ArrListAtten,string Date)
    ////////////////////{
    ////////////////////    OleDbConnection conn = new OleDbConnection(con.ConnectionString);
    ////////////////////    conn.Open();
    ////////////////////    OleDbTransaction oledbTrans = conn.BeginTransaction();
    ////////////////////    OleDbParameter[] paramGrid = new OleDbParameter[3];
    ////////////////////    string strSql = "";
      
    ////////////////////    try
    ////////////////////    {
    ////////////////////        for (int i = 0; i <= ArrListEmp.Count - 1; i++)
    ////////////////////        {
    ////////////////////            strSql = " select count(da.emp_id) from DATILY_ATTENDANCE DA  inner join employee_master em on (em.emp_id=da.emp_id) where   [DATE]='" + Date + "' and SUBCENTRE_ID=" + SubCentreID + " and da.emp_id='" + ArrListEmp[i].ToString() + "'";
    ////////////////////            int k = (int)OleDbHelper.ExecuteScalar(oledbTrans, CommandType.Text, strSql);
    ////////////////////            if (k != 0)
    ////////////////////            {
    ////////////////////                strSql = "update  DATILY_ATTENDANCE   SET  ATTENDANCE='" + ArrListAtten[i].ToString() + "' where    [DATE]='" + Date + "' AND EMP_ID=" + ArrListEmp[i].ToString() + "  "; 
    ////////////////////                OleDbHelper.ExecuteNonQuery(oledbTrans, CommandType.Text, strSql);
    ////////////////////                Message = "Updated successfully !!!";
    ////////////////////            }
    ////////////////////            else
    ////////////////////            {
    ////////////////////                strSql = "insert into DATILY_ATTENDANCE (EMP_ID,[DATE],ATTENDANCE) values(?,?,?)";
    ////////////////////                paramGrid[0] = new OleDbParameter("@EMP_ID", OleDbType.VarChar);
    ////////////////////                paramGrid[0].Value = ArrListEmp[i].ToString();
    ////////////////////                paramGrid[1] = new OleDbParameter("@[DATE]", OleDbType.VarChar);
    ////////////////////                paramGrid[1].Value = Date;
    ////////////////////                paramGrid[2] = new OleDbParameter("@ATTENDANCE", OleDbType.VarChar);
    ////////////////////                paramGrid[2].Value = ArrListAtten[i].ToString();
    ////////////////////                OleDbHelper.ExecuteNonQuery(oledbTrans, CommandType.Text, strSql, paramGrid);
    ////////////////////                Message = "Saved successfully !!!";
    ////////////////////            }
               
               
    ////////////////////        }
    ////////////////////        oledbTrans.Commit();
    ////////////////////        conn.Close();
          
    ////////////////////    }
    ////////////////////    catch (Exception ex)
    ////////////////////    {
    ////////////////////        oledbTrans.Rollback();
    ////////////////////        conn.Close();
    ////////////////////        Message = ex.Message;
    ////////////////////    }
    ////////////////////}

    public void UpdateAttendaceByHO(ArrayList ArrListEmp, ArrayList ArrListAtten, string Date, string AlistCreBy, DateTime AlistCreDate, string AlistModBy, DateTime AlistModDate)
    {
        OleDbConnection conn = new OleDbConnection(con.ConnectionString);
        conn.Open();
        OleDbTransaction oledbTrans = conn.BeginTransaction();
        OleDbParameter[] paramGrid = new OleDbParameter[7];
        string strSql = "";

        try
        {
            for (int i = 0; i <= ArrListEmp.Count - 1; i++)
            {
                strSql = " select count(da.emp_id) from DATILY_ATTENDANCE DA  inner join employee_master em on (em.emp_id=da.emp_id) where   [DATE]='" + Date + "' and SUBCENTRE_ID=" + SubCentreID + " and da.emp_id='" + ArrListEmp[i].ToString() + "'";
                int k = (int)OleDbHelper.ExecuteScalar(oledbTrans, CommandType.Text, strSql);
                if (k != 0)
                {
                    strSql = "update  DATILY_ATTENDANCE   SET  ATTENDANCE='" + ArrListAtten[i].ToString() + "',ModifyBy='" + AlistModBy.ToString() + "',ModifyDate='" + System.DateTime.Now.ToShortDateString() + "' where [DATE]='" + Date + "' AND EMP_ID=" + ArrListEmp[i].ToString() + "  ";
                    OleDbHelper.ExecuteNonQuery(oledbTrans, CommandType.Text, strSql);
                    Message = "Updated successfully !!!";
                }
                else
                {
                    strSql = "insert into DATILY_ATTENDANCE (EMP_ID,[DATE],ATTENDANCE,CreateBy,CreateDate,ModifyBy,ModifyDate) values(?,?,?,?,?,?,?)";
                    paramGrid[0] = new OleDbParameter("@EMP_ID", OleDbType.VarChar);
                    paramGrid[0].Value = ArrListEmp[i].ToString();
                    paramGrid[1] = new OleDbParameter("@[DATE]", OleDbType.VarChar);
                    paramGrid[1].Value = Date;
                    paramGrid[2] = new OleDbParameter("@ATTENDANCE", OleDbType.VarChar);
                    paramGrid[2].Value = ArrListAtten[i].ToString();
                    paramGrid[3] = new OleDbParameter("@ModifyBy", OleDbType.VarChar);
                    paramGrid[3].Value = AlistModBy.ToString();
                    paramGrid[4] = new OleDbParameter("@ModifyDate", OleDbType.Date);
                    paramGrid[4].Value = System.DateTime.Now.ToShortDateString();
                    paramGrid[5] = new OleDbParameter("@CreateBy", OleDbType.VarChar);
                    paramGrid[5].Value = AlistCreBy.ToString();
                    paramGrid[6] = new OleDbParameter("@CreateDate", OleDbType.Date);
                    paramGrid[6].Value = System.DateTime.Now.ToShortDateString();
                    OleDbHelper.ExecuteNonQuery(oledbTrans, CommandType.Text, strSql, paramGrid);
                    Message = "Saved successfully !!!";
                }


            }
            oledbTrans.Commit();
            conn.Close();

        }
        catch (Exception ex)
        {
            oledbTrans.Rollback();
            conn.Close();
            Message = ex.Message;
        }
    }
}
