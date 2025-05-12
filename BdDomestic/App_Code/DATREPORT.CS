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
public class DATREPORT
{
    CCommon con = new CCommon();
    DataSet ds = new DataSet();


    private string sFromDt;
    public string FromDt
    {
        get { return sFromDt; }
        set { sFromDt = value; }
    }

    private string SToDt;
    public string ToDt
    {
        get { return SToDt; }
        set { SToDt = value; }
    }


    public DATREPORT()
    {
        //
        // TODO: Add constructor logic here
        // if (!IsPostBack)

    }

    public OleDbDataReader Fill_RoleDropDown(string strFillDropDown)
    {
        OleDbDataReader dr;
        dr = OleDbHelper.ExecuteReader(con.ConnectionString, CommandType.Text, strFillDropDown);
        return dr;
    }

    public OleDbDataReader Fill_Centre()
    {
        OleDbDataReader dr;
        string sqlStr = "";
        sqlStr = " select  centre_id,centre_name from centre_master order by centre_name ";
        dr = OleDbHelper.ExecuteReader(con.ConnectionString, CommandType.Text, sqlStr);
        return dr;
    }
    public OleDbDataReader Fill_CentrewithClusterID(string strFillDependentDropDown)
    {
        OleDbDataReader dr;
        dr = OleDbHelper.ExecuteReader(con.ConnectionString, CommandType.Text, strFillDependentDropDown);
        return dr;
    }


    public OleDbDataReader Fill_Sub_Centre(String Centreid)
    {
        OleDbDataReader Subcentredr;
        string sqlStr = "";
        sqlStr = " select subcentreid,subcentrename from subcentremaster where centreid=" + Centreid + " order by subcentrename ";
        Subcentredr = OleDbHelper.ExecuteReader(con.ConnectionString, CommandType.Text, sqlStr);
        return Subcentredr;
    }

    public string ShowSubCenterData(string SubcenterId)
    {
        OleDbDataReader subcenterDr;
        string strRetID = "";
        string strSubCenter = "";

        strSubCenter += " select subcentreid,subcentrename from subcentremaster where subcentreid in (select subcentre_id from employee_master where emp_id='" + SubcenterId + "') ";
        subcenterDr = OleDbHelper.ExecuteReader(con.ConnectionString, CommandType.Text, strSubCenter);

        if (subcenterDr.HasRows)
        {
            while (subcenterDr.Read())
            {
                strRetID = subcenterDr["SubCentreId"].ToString() + ',' + subcenterDr["subcentrename"].ToString();
            }
        }

        return strRetID;

    }

    public OleDbDataReader ShowEmployeedata(string Centreid, String Subcentreid)
    {
        OleDbDataReader Empdr;
        string strEmp = "";
        string strSubcentre = "";
        string strCentre = "";
        string strOrderclause = " ORDER BY a.FULLNAME ";

        if (Centreid != "")
        {
            strCentre = " and a.centre_id=" + Centreid + " ";
        }
        else
        {
            strOrderclause = " ORDER BY B.centre_name ASC,a.FULLNAME";
        }

        if (Subcentreid != "")
        {
            strSubcentre = " and a.subcentre_id=" + Subcentreid + " ";
        }

        strEmp += " select distinct a.emp_code,a.fullname,b.centre_name,c.subcentrename, ";
        strEmp += " (select count(*) from datily_attendance d where a.emp_id=d.emp_id ";
        strEmp += " and d.date between '" + FromDt + "'  and  '" + ToDt + "'  and d.attendance in('A')) as ABSENT,";
        strEmp += " (select count(*) from datily_attendance d where a.emp_id=d.emp_id ";
        strEmp += " and d.date between '" + FromDt + "'  and  '" + ToDt + "'  and d.attendance in('P')) as PRESENT";
        strEmp += " from employee_master a,";
        strEmp += " centre_master b,subcentremaster c where a.centre_id=b.centre_id and a.subcentre_id=c.subcentreid";
        strEmp += "  and (a.dol>= '" + FromDt + "' or a.dol is null) " + strCentre + " " + strSubcentre + " ";
        strEmp += " and upper(a.APPROVED_BY_HOHR)='Y' " + strOrderclause + "  ";
        Empdr = OleDbHelper.ExecuteReader(con.ConnectionString, CommandType.Text, strEmp);
        return Empdr;
    }

    public OleDbDataReader ShowEmplSalaryStatus(string Centreid, String Subcentreid, String ReportType)
    {
        OleDbDataReader Empdr;
        string strEmp = "";
        string strSubcentre = "";
        string strCentre = "";
        string strOrderclause = " ORDER BY a.FULLNAME ";

        if (Centreid != "")
        {
            strCentre = " and a.centre_id=" + Centreid + " ";
        }
        else
        {
            strOrderclause = " ORDER BY B.centre_name ASC,a.FULLNAME";
        }

        if (Subcentreid != "")
        {
            strSubcentre = " and a.subcentre_id=" + Subcentreid + " ";
        }

        if (ReportType == "With Data")
        {
            strEmp += " select distinct a.emp_code,a.fullname,b.centre_name,c.subcentrename,a.suvidha_ac,'' as Category,a.unit,a.company_id,'' as  ARemark,'' as SPAllowance ,";

            strEmp += " (select count(*) from datily_attendance d where a.emp_id=d.emp_id ";
            strEmp += " and d.date between '" + FromDt + "'  and  '" + ToDt + "'  and d.attendance in('A')) as ABSENT,";
            strEmp += " (select count(*) from datily_attendance d where a.emp_id=d.emp_id ";
            strEmp += " and d.date between '" + FromDt + "'  and  '" + ToDt + "'  and d.attendance in('P')) as PRESENT,";

            strEmp += " 0 as  SpAllowance,0 as OTDAYS, ";
            strEmp += " 0 as  Deduction,'' as Dremarks,e.department ";
            strEmp += " from employee_master a,";
            strEmp += " centre_master b,subcentremaster c,department_master e where a.centre_id=b.centre_id and a.subcentre_id=c.subcentreid";
            strEmp += " and e.dept_id=a.department_id  " + strCentre + "   and upper(a.APPROVED_BY_HOHR)='Y' " + strSubcentre + " ";
            strEmp += " and (a.dol>= '" + FromDt + "' or a.dol is null)  " + strOrderclause + "  ";
            Empdr = OleDbHelper.ExecuteReader(con.ConnectionString, CommandType.Text, strEmp);
            return Empdr;
        }
        else
        {
            strEmp += " select distinct a.emp_code,a.fullname,b.centre_name,c.subcentrename,'' as suvidha_ac,'' as Category,'' as unit,'' as company_id,'' as  ARemark, ";

            /*            strEmp += " (select count(*) from datily_attendance d where a.emp_id=d.emp_id ";
                        strEmp += " and d.date between '" + FromDt + "'  and  '" + ToDt + "'  and d.attendance in('A')) as ABSENT,";
                        strEmp += " (select count(*) from datily_attendance d where a.emp_id=d.emp_id ";
                        strEmp += " and d.date between '" + FromDt + "'  and  '" + ToDt + "'  and d.attendance in('P')) as PRESENT,";
            */
            strEmp += " 0 as ABSENT,";
            strEmp += " 0 as PRESENT,";

            strEmp += " '' as  SpAllowance,'' as OTDAYS, ";
            strEmp += " '' as  Deduction,'' as Dremarks ";
            strEmp += " from employee_master a,";
            strEmp += " centre_master b,subcentremaster c where a.centre_id=b.centre_id and a.subcentre_id=c.subcentreid";
            strEmp += " and (a.dol>= '" + FromDt + "' or a.dol is null) " + strCentre + " " + strSubcentre + " ";
            strEmp += " " + strOrderclause + "  ";
            Empdr = OleDbHelper.ExecuteReader(con.ConnectionString, CommandType.Text, strEmp);
            return Empdr;
        }
    }
    /*
        public OleDbDataReader ShowRolewiseEmplSalaryStatus(string Centreid, String Subcentreid,String ReportType,String Clusterid)
        {
            OleDbDataReader Empdr;
            string strEmp = "";
            string strSubcentre = "";
            string strCentre = "";
            string strCluster = "";
            string strOrderclause = " ORDER BY a.FULLNAME ";

            if (Clusterid != "")
            {
                strCluster = " and b.cluster_id= " + Clusterid + " ";
            }
       
           if (Centreid != "")
            {
                strCentre = " and a.centre_id=" + Centreid + " ";
            }
            else
            {
                strOrderclause = " ORDER BY B.centre_name ASC,a.FULLNAME";
            }

            if (Subcentreid != "")
            {
                strSubcentre = " and a.subcentre_id=" + Subcentreid + " ";
            }

            if (ReportType == "With Data")
            {
                strEmp += " select a.emp_code,a.fullname,b.centre_name,c.subcentrename,a.suvidha_ac,'' as Category,a.unit,a.company_id,'' as  ARemark, ";

                strEmp += " (select count(*) from datily_attendance d where a.emp_id=d.emp_id ";
                strEmp += " and d.date between '" + FromDt + "'  and  '" + ToDt + "'  and d.attendance in('A')) as ABSENT,";
                strEmp += " (select count(*) from datily_attendance d where a.emp_id=d.emp_id ";
                strEmp += " and d.date between '" + FromDt + "'  and  '" + ToDt + "'  and d.attendance in('P')) as PRESENT,";                     
            
                strEmp += " 0 as  SpAllowance,0 as OTDAYS, ";
                strEmp += " 0 as  Deduction,'' as Dremarks ";
                strEmp += " from employee_master a,";
                strEmp += " centre_master b,subcentremaster c where a.centre_id=b.centre_id and a.subcentre_id=c.subcentreid";
                strEmp += " " + strCluster + "  " + strCentre + " " + strSubcentre + " ";
                strEmp += " " + strOrderclause + "  ";
                Empdr = OleDbHelper.ExecuteReader(con.ConnectionString, CommandType.Text, strEmp);
                return Empdr;
            }
            else
            {
                strEmp += " select a.emp_code,a.fullname,'' as centre_name,'' as subcentrename,'' as suvidha_ac,'' as Category,'' as unit,'' as company_id,'' as  ARemark, ";
                strEmp += " case d.attendance when 'A' then '' else '' end as Absent,";
                strEmp += " case d.attendance when 'P' then '' else '' end as Present,";
                strEmp += " '' as  SpAllowance,'' as OTDAYS, ";
                strEmp += " '' as  Deduction,'' as Dremarks ";
                strEmp += " from employee_master a,";
                strEmp += " centre_master b,subcentremaster c ,datily_attendance d where a.centre_id=b.centre_id and a.subcentre_id=c.subcentreid";
                strEmp += " and d.attendance in('P','A') AND  a.emp_id=d.emp_id " + strCentre + " " + strSubcentre + " ";
                strEmp += " and d.date between '" + FromDt + "'  and  '" + ToDt + "'  " + strOrderclause + "  ";
                Empdr = OleDbHelper.ExecuteReader(con.ConnectionString, CommandType.Text, strEmp);
                return Empdr;
            }
        }*/
    public OleDbDataReader ShowRolewiseEmplSalaryStatus(string Centreid, String Subcentreid, String ReportType, String Clusterid)
    {
        OleDbDataReader Empdr;
        string strEmp = "";
        string strSubcentre = "";
        string strCentre = "";
        string strCluster = "";
        string strOrderclause = " ORDER BY a.emp_code,c.Centreid ";

        if (Clusterid != "")
        {
            strCluster = " and b.cluster_id= " + Clusterid + " ";
        }

        if (Centreid != "")
        {
            strCentre = " and a.centre_id=" + Centreid + " ";
        }
        else
        {
            //            strOrderclause = " ORDER BY B.centre_name ASC,a.FULLNAME";
        }

        if (Subcentreid != "")
        {
            strSubcentre = " and a.subcentre_id=" + Subcentreid + " ";
        }

        if (ReportType == "With Data")
        {
            strEmp += " select e.department,substring(datename(dw,d.date),1,3) + ' '+ cast(day(d.date) as varchar) as Att_Date,a.emp_code,a.fullname,b.centre_name ,c.subcentrename ,a.suvidha_ac,'' as Category,'' as  ARemark, ";
            strEmp += " case d.attendance when 'A' then 'A' when 'P' then 'P' when 'U' then 'A'  end as 'status',DOL,";
            strEmp += " 0 as  SpAllowance,0 as OTDAYS, ";
            strEmp += " 0 as  Deduction,'' as Dremarks ";
            strEmp += " from employee_master a,";
            strEmp += " centre_master b,subcentremaster c ,datily_attendance d,department_master e,COMPANY_MASTER g  where a.centre_id=b.centre_id and a.subcentre_id=c.subcentreid  ";
            strEmp += "  AND  a.emp_id=d.emp_id  " + strCluster + "  " + strCentre + " " + strSubcentre + " ";
            strEmp += " and (a.dol>= '" + FromDt + "' or a.dol is null) and a.department_id=e.dept_id  and d.date between '" + FromDt + "'  and  '" + ToDt + "'  and upper(a.APPROVED_BY_HOHR)='Y' " + strOrderclause + "  ";
            Empdr = OleDbHelper.ExecuteReader(con.ConnectionString, CommandType.Text, strEmp);
            //            Empdr = OleDbHelper.ExecuteReader(con.ConnectionString, CommandType.Text, strEmp);            
        }
        else
        {
            strEmp += " select e.department,a.emp_code,a.fullname,b.centre_name,c.subcentrename,'' as suvidha_ac,'' as Category,'' as  ARemark, ";
            strEmp += " ''as 'status',";
            strEmp += " '' as  SpAllowance,'' as OTDAYS, ";
            strEmp += " '' as  Deduction,'' as Dremarks ";
            strEmp += " from employee_master a,";
            strEmp += " centre_master b,subcentremaster c ,datily_attendance d,department_master e,COMPANY_MASTER g  where a.centre_id=b.centre_id and a.subcentre_id=c.subcentreid  ";
            strEmp += "  and (a.dol>= '" + FromDt + "' or a.dol is null) " + strCentre + " " + strSubcentre + " ";
            strEmp += " and a.department_id=e.dept_id  " + strOrderclause + "  ";
            Empdr = OleDbHelper.ExecuteReader(con.ConnectionString, CommandType.Text, strEmp);

        }
        return Empdr;
    }
    public OleDbDataReader ShowAttendanceCountReport(string Centreid, String Subcentreid)
    {
        OleDbDataReader Empdr;
        string strEmp = "";
        string strSubcentre = "";
        string strCentre = "";
        //string strCluster = "";
        string strOrderclause = " ORDER BY a.emp_code,c.Centreid ";

        //if (Clusterid != "")
        //{
        //strCluster = " and b.cluster_id= " + Clusterid + " ";
        //}

        if (Centreid != "")
        {
            strCentre = " and a.centre_id=" + Centreid + " ";
        }
        else
        {
            //strOrderclause = " ORDER BY B.centre_name ASC,a.FULLNAME";
        }

        if (Subcentreid != "")
        {
            strSubcentre = " and a.subcentre_id=" + Subcentreid + " ";
        }

        //if (ReportType == "With Data")
        //{
        strEmp += " select e.department,substring(datename(dw,d.date),1,3) + ' '+ cast(day(d.date) as varchar) as Att_Date,a.emp_code,a.fullname,b.centre_name ,c.subcentrename ,a.suvidha_ac,'' as Category,'' as  ARemark, ";
        strEmp += " case d.attendance when 'A' then 'A' when 'P' then 'P' when 'U' then 'A' else 'left' end as 'status',";
        strEmp += " 0 as  SpAllowance,0 as OTDAYS, ";
        strEmp += " 0 as  Deduction,'' as Dremarks ";
        strEmp += " from employee_master a,";
        strEmp += " centre_master b,subcentremaster c ,datily_attendance d,department_master e,COMPANY_MASTER g  where a.centre_id=b.centre_id and a.subcentre_id=c.subcentreid  ";
        strEmp += "  AND  a.emp_id=d.emp_id  "  + strCentre + " " + strSubcentre + " ";
        strEmp += " and (a.dol>= '" + FromDt + "' or a.dol is null) and a.department_id=e.dept_id  and d.date between '" + FromDt + "'  and  '" + ToDt + "'  and upper(a.APPROVED_BY_HOHR)='Y' " + strOrderclause + "  ";
        Empdr = OleDbHelper.ExecuteReader(con.ConnectionString, CommandType.Text, strEmp);
        //            Empdr = OleDbHelper.ExecuteReader(con.ConnectionString, CommandType.Text, strEmp);            
        //}
        //else
        //{
        //    strEmp += " select e.department,a.emp_code,a.fullname,b.centre_name,c.subcentrename,'' as suvidha_ac,'' as Category,'' as unit,'' as company_id,'' as  ARemark, ";
        //    strEmp += " ''as 'status',";
        //    strEmp += " '' as  SpAllowance,'' as OTDAYS, ";
        //    strEmp += " '' as  Deduction,'' as Dremarks ";
        //    strEmp += " from employee_master a,";
        //    strEmp += " centre_master b,subcentremaster c ,department_master e  where a.centre_id=b.centre_id and a.subcentre_id=c.subcentreid";
        //    strEmp += "  and (a.dol>= '" + FromDt + "' or a.dol is null) " + strCentre + " " + strSubcentre + " ";
        //    strEmp += " and a.department_id=e.dept_id  " + strOrderclause + "  ";
        //    Empdr = OleDbHelper.ExecuteReader(con.ConnectionString, CommandType.Text, strEmp);

        //}
        return Empdr;
    }


    public OleDbDataReader ShowAttendanceDumpReport(string Centreid, String Subcentreid)
    {
        OleDbDataReader Empdr;
        string strEmp = "";
        string strSubcentre = "";
        string strCentre = "";
        //string strCluster = "";
        string strOrderclause = " ORDER BY a.emp_code,c.Centreid ";

        //if (Clusterid != "")
        //{
        //    strCluster = " and b.cluster_id= " + Clusterid + " ";
        //}

        if (Centreid != "")
        {
            strCentre = " and a.centre_id=" + Centreid + " ";
        }
        else
        {
            //            strOrderclause = " ORDER BY B.centre_name ASC,a.FULLNAME";
        }

        if (Subcentreid != "")
        {
            strSubcentre = " and a.subcentre_id=" + Subcentreid + " ";
        }

        //if (ReportType == "With Data")
        //{
        strEmp += " select e.department,substring(datename(dw,d.date),1,3) + ' '+ cast(day(d.date) as varchar) as Att_Date,a.emp_code,a.fullname,b.centre_name ,c.subcentrename ,a.suvidha_ac,'' as Category,'' as  ARemark, ";
        strEmp += " case d.attendance when 'A' then 'A' when 'P' then 'P' when 'U' then 'A' else 'left' end as 'status',";
        strEmp += " 0 as  SpAllowance,0 as OTDAYS, ";
        strEmp += " 0 as  Deduction,'' as Dremarks ";
        strEmp += " from employee_master a,";
        strEmp += " centre_master b,subcentremaster c ,datily_attendance d,department_master e,COMPANY_MASTER g  where a.centre_id=b.centre_id and a.subcentre_id=c.subcentreid  ";
        strEmp += "  AND  a.emp_id=d.emp_id  " + strCentre + " " + strSubcentre + " ";
        strEmp += " and (a.dol>= '" + FromDt + "' or a.dol is null) and a.department_id=e.dept_id  and d.date between '" + FromDt + "'  and  '" + ToDt + "'  and upper(a.APPROVED_BY_HOHR)='Y' " + strOrderclause + "  ";
        Empdr = OleDbHelper.ExecuteReader(con.ConnectionString, CommandType.Text, strEmp);
        //            Empdr = OleDbHelper.ExecuteReader(con.ConnectionString, CommandType.Text, strEmp);            
        //}
        //else
        //{
        //    strEmp += " select e.department,a.emp_code,a.fullname,b.centre_name,c.subcentrename,'' as suvidha_ac,'' as Category,'' as unit,'' as company_id,'' as  ARemark, ";
        //    strEmp += " ''as 'status',";
        //    strEmp += " '' as  SpAllowance,'' as OTDAYS, ";
        //    strEmp += " '' as  Deduction,'' as Dremarks ";
        //    strEmp += " from employee_master a,";
        //    strEmp += " centre_master b,subcentremaster c ,department_master e  where a.centre_id=b.centre_id and a.subcentre_id=c.subcentreid";
        //    strEmp += "  and (a.dol>= '" + FromDt + "' or a.dol is null) " + strCentre + " " + strSubcentre + " ";
        //    strEmp += " and a.department_id=e.dept_id  " + strOrderclause + "  ";
        //    Empdr = OleDbHelper.ExecuteReader(con.ConnectionString, CommandType.Text, strEmp);

        //}
        return Empdr;
    }


}
