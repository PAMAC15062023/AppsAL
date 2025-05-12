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
/// Summary description for KYCreports
/// </summary>
public class KYCreports
{
    CCommon objCmn = new CCommon();
	public KYCreports()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    # region GetKYC_PendingListReport()
    public DataSet GetKYCPendingReportList(string sFromDate, String sToDate, string sClientId, string sCentreId)
    {
        string dtToDate;
        string dtFromDate;
        dtToDate = Convert.ToDateTime(sToDate).AddDays(-1.0).ToString("dd-MMM-yyyy");
        //dtFromDate = Convert.ToDateTime(sFromDate).AddDays(-1.0).ToString("dd-MMM-yyyy");
        string sSql = "SELECT (vtm. VERIFICATION_type_code) As [Verification Type],cd.ref_no as[Ref no],cm.client_name as[Client name], cd.Case_ID as [Case ID], (isNull(cd.FIRST_NAME,'')+' '+isnull(cd.MIDDLE_NAME,'')+' '+isnull(cd.LAST_NAME,'')) as [Name]," +
                      "CONVERT(Varchar(24), cd.CASE_REC_DATETIME, 103) As  [Recieved on] , " +
                      "'" + sFromDate  + "' as FROMDATE, " +
                      "'" + dtToDate + "' as TODATE, " +
                      "'PAMAC Online' as COMPANYNAME, fev.FULLNAME AS [FE Name],cd.TYPE AS [TYPE]  FROM client_master cm inner join  CPV_KYC_CASE_DETAILS cd on(cd.client_id=cm.client_id) inner join cpv_KYC_verification_type vt on(cd.case_id=vt.case_id) inner join verification_type_master vtm on(vt.verification_type_id=vtm.verification_type_id) inner join CPV_KYC_FE_MAPPING fem on(fem.VERIFICATION_TYPE_ID=vtm.verification_type_id) and (fem.Case_id=cd.Case_id) inner join FE_VW fev on(fev.EMP_ID=FEM.FE_ID) WHERE (cd.SEND_DATETIME IS NULL)" +
                      "AND cd.CASE_REC_DATETIME >= '" + sFromDate + "' AND cd.CASE_REC_DATETIME <= '" + sToDate + "' AND cd.CLIENT_ID='" + sClientId + "' " +
                      "AND CD.CENTRE_ID='" + sCentreId + "'";
        return OleDbHelper.ExecuteDataset(objCmn.ConnectionString, CommandType.Text, sSql);
    }
    # endregion GetKYC_PendingListReport()



    # region GetKYC_TATMIS()
    public DataSet GetKYC_TATMIS(string sFromDate, String sToDate, string sClientId, string sCentreId)
    {

        DataSet ds = new DataSet();
        OleDbConnection con = new OleDbConnection(objCmn.ConnectionString);
        con.Open();
        string dtToDate;
        dtToDate = Convert.ToDateTime(sToDate).AddDays(-1.0).ToString("dd-MMM-yyyy");
        //CHECK ABOUT CLIENT..(THIS IS FOR CLIENT =1013)...........
        string str = "SELECT Convert(varchar(24),CASE_REC_DATETIME,103) as CASE_REC_DATETIME, COUNT(CASE_REC_DATETIME) AS NO, SUM(GRATER) AS WITHIN_TAT, SUM(STANDARD) AS GRATER_THAN_TAT, SUM(PENDING)AS PENDING, TYPE," +
                     "CAST((CAST(SUM(GRATER)AS DECIMAL(18,2))/CAST(COUNT(CASE_REC_DATETIME)AS DECIMAL(18,2)))* 100 AS DECIMAL(18,2)) AS PER_WITHIN, " +
                     "CAST(CAST(SUM(STANDARD)AS DECIMAL(18,2))/CAST(COUNT(CASE_REC_DATETIME)AS DECIMAL(18,2))* 100 AS DECIMAL(18,2)) AS PER_GRATER_TAT, " +
                      "'" + Convert.ToDateTime(sFromDate).ToString("dd/MM/yyyy") + "' as FROMDATE, " +
                      "'" + Convert.ToDateTime(dtToDate).ToString("dd/MM/yyyy") + "' as TODATE, " +
                     "CAST(CAST(SUM(PENDING)AS DECIMAL(18,2))/CAST(COUNT(CASE_REC_DATETIME)AS DECIMAL(18,2))* 100 AS DECIMAL(18,2)) AS PER_PENDING ,'PAMAC Online' as COMPANYNAME  FROM  " +
                     "(SELECT Convert(varchar(24),CASE_REC_DATETIME,103) as CASE_REC_DATETIME, CASE WITHIN_TAT WHEN 1 THEN 1 ELSE 0 END AS 'GRATER',  " +
                     "CASE WITHIN_TAT WHEN 0 THEN 1 ELSE 0 END AS 'STANDARD', SEND_DATETIME,type, CASE SEND_DATETIME WHEN ISNULL(SEND_DATETIME, '') THEN 0 ELSE 1 END AS 'PENDING' FROM CPV_KYC_CASE_DETAILS  " +
                     "WHERE CASE_REC_DATETIME  >= '" + sFromDate + "' AND CASE_REC_DATETIME <'" + sToDate + "' and Client_Id='" + sClientId + "' and centre_id='" + sCentreId + "')AS DERIVETABLE_1  " +
                     "GROUP BY CASE_REC_DATETIME, type " +
                     "order by CASE_REC_DATETIME";
        ds = OleDbHelper.ExecuteDataset(con, CommandType.Text, str);
        return ds;
    }
    #endregion GetKYC_TATMIS()


    #region GetKYCCoveringLetterDtl() for CoverLetter Report
    public DataSet GetKYCCoveringLetterDtl(string sFromDate, String sToDate, string sClientId, string sCentreId)
    {
        string dtToDate;
        dtToDate = Convert.ToDateTime(sToDate).AddDays(-1.0).ToString("dd-MMM-yyyy");

        string sSql = "";
        string strveriid = "";

        sSql = "SELECT  DISTINCT(CD.CASE_ID) as [Case ID],CD.REF_NO AS [Ref no],CD.REF_NO as REFNO ,Convert(varchar(24),CD.CASE_REC_DATETIME,103)" +
                " as CASERECDATETIME ,cm.client_name as [Client name], (ISNULL(FIRST_NAME,'') + ' ' + ISNULL(MIDDLE_NAME,'') + ' ' + ISNULL(LAST_NAME,'')) as NAME" +
                " ,Convert(varchar(24),CD.SEND_DATETIME,103) as SENDDATETIME,'" + Convert.ToDateTime(sFromDate).ToString("dd/MM/yyyy") + "'  as FromDate" +
                " , '" + Convert.ToDateTime(dtToDate).ToString("dd/MM/yyyy") + "' as Todate, 'Pamac Online' as [Company Name] " +
                " ,csm.status_name as Status,VTM.VERIFICATION_TYPE AS Verification " +
                ",CNM.CENTRE_NAME AS CenterName,cd.TYPE as [TYPE] "+ 
                " FROM   client_master cm inner join  CPV_KYC_CASE_DETAILS CD on(cd.client_id=cm.client_id) INNER JOIN " +
                " CPV_KYC_CASE_VERIFICATION CIV ON CD.CASE_ID = CIV.CASE_ID INNER JOIN " +
                " CPV_KYC_VERIFICATION_TYPE VT ON CD.CASE_ID = VT.CASE_ID INNER JOIN " +
                " CASE_STATUS_MASTER CSM ON CD.CASE_STATUS_ID = CSM.CASE_STATUS_ID INNER JOIN " +
                " VERIFICATION_TYPE_MASTER VTM ON " +
                " CIV.VERIFICATION_TYPE_ID = VTM.VERIFICATION_TYPE_ID AND " +
                " VT.VERIFICATION_TYPE_ID = VTM.VERIFICATION_TYPE_ID  INNER JOIN" +
                " CENTRE_MASTER CNM ON CD.CENTRE_ID=CNM.CENTRE_ID " +
                " WHERE CD.SEND_DATETIME >= '" + sFromDate + "' AND CD.SEND_DATETIME < '" + sToDate + "' " +
                " AND CD.SEND_DATETIME IS NOT NULL AND CD.CLIENT_ID='" + sClientId + "' AND CD.CENTRE_ID='" + sCentreId + "' " +
                " ORDER BY CASERECDATETIME ASC  ,CD.CASE_ID , SENDDATETIME";


        
        return OleDbHelper.ExecuteDataset(objCmn.ConnectionString, CommandType.Text, sSql);
    }
    #endregion GetKYCCoveringLetterDtl() for CoverLetter Report



    # region GetKYC_claimMISReport()
    public DataSet GetKYCClaimMISReport(string sFromDate, String sToDate, string sClientId, string sCentreId)
    {
        string sSql = "";

        string dtToDate;
        dtToDate = Convert.ToDateTime(sToDate).AddDays(-1.0).ToString("dd-MMM-yyyy");
        sSql = "select distinct Convert(varchar(24),cd.CASE_REC_DATETIME,103)as [Received Date], cd.CASE_ID as [CASE ID],cd.REF_NO as BANK_REF_NO," +
                "(isNull(cd.FIRST_NAME,'')+' '+isnull(cd.MIDDLE_NAME,'')+' '+isnull(cd.LAST_NAME,'')) as [Applicant Name]," +
                "Convert(varchar(24),cd.SEND_DATETIME,103)as [Send Date],vtm.VERIFICATION_TYPE_CODE as [VARIFICATION TYPE CODE],vtm.VERIFICATION_TYPE as [VARIFICATION TYPE]," +
                "csm.status_name as [STATUS NAME], " +
                "'" + Convert.ToDateTime(sFromDate).ToString("dd/MM/yyyy") + "' as FromDate, " +
                "'" + Convert.ToDateTime(dtToDate).ToString("dd/MM/yyyy") + "' as Todate, " +
                "'Pamac Online' as CompanyName,cm.CLIENT_NAME as CLIENTNAME,cd.TYPE as [TYPE],em.FullName as 'Fe Name',civ.Remark,ka.Attempt_date_time as 'AttemptDate' " +
                " From CPV_KYC_CASE_DETAILS as cd  " +
                " inner join CPV_KYC_VERIFICATION_TYPE as cvt on cd.CASE_ID=cvt.CASE_ID inner join VERIFICATION_TYPE_MASTER as vtm  " +
                " on cvt.VERIFICATION_TYPE_ID=vtm.VERIFICATION_TYPE_ID inner join CPV_KYC_CASE_VERIFICATION as civ on civ.case_id=cd.case_id inner join CPV_KYC_VERI_ATTEMPTS as ka " +
                " on ka.case_id=civ.case_id and cd.case_id=ka.case_id and civ.VERIFICATION_TYPE_ID=ka.VERIFICATION_TYPE_ID and cvt.VERIFICATION_TYPE_ID=ka.VERIFICATION_TYPE_ID " +
                " inner join CPV_KYC_FE_MAPPING as fe on fe.case_id=ka.case_id and fe.case_id=civ.case_id and fe.case_id=cvt.case_id and fe.case_id=cd.case_id and fe.VERIFICATION_TYPE_ID=civ.VERIFICATION_TYPE_ID" +
                " and fe.VERIFICATION_TYPE_ID=ka.VERIFICATION_TYPE_ID and fe.VERIFICATION_TYPE_ID=cvt.VERIFICATION_TYPE_ID inner join employee_master as em on em.emp_id=fe.fe_id inner join CASE_STATUS_MASTER as csm on cd.case_status_id=csm.case_status_id inner join CLIENT_MASTER as cm on cd.CLIENT_ID=cm.CLIENT_ID  " +
                " where cd.SEND_DATETIME >= " +
                "'" + sFromDate + "'" +
                " and cd.SEND_DATETIME < " +
                "'" + sToDate + "'" +
                " AND cd.CLIENT_ID='" + sClientId + "'" +
                " AND cd.CENTRE_ID='" + sCentreId + "'";


        return OleDbHelper.ExecuteDataset(objCmn.ConnectionString, CommandType.Text, sSql);
    }

    # endregion GetKYC_claimMISReport()


      public DataSet GetFEAssignmentReport(string sFromDate, string sToDate, string sClientId, string sCentreId)
    {
        string dtToDate;
        dtToDate = Convert.ToDateTime(sToDate).AddDays(-1.0).ToString("dd-MMM-yyyy");
        string sSql = "";
        sSql = "SELECT count(cd.case_id) NOOFCASES,(isnull(EM.FIRSTNAME,' ')+' '+isnull(EM.Middlename,' ')+' '+isnull(EM.lastname,' '))" +
              "as FENAME , VM.VERIFICATION_TYPE_CODE as VERIFICATIONTYPE, cm.client_name as Client , " +
                 "'" + Convert.ToDateTime(sFromDate).ToString("dd/MM/yyyy") + "' as FROMDATE, " +
               "'" + Convert.ToDateTime(dtToDate).ToString("dd/MM/yyyy") + "' as TODATE, " +
                " 'PAMAC Online' as COMPANYNAME " +
              "FROM CPV_KYC_FE_MAPPING FE INNER JOIN CPV_KYC_CASE_DETAILS CD ON FE.CASE_ID = CD.CASE_ID " +
              "INNER JOIN VERIFICATION_TYPE_MASTER VM ON FE.VERIFICATION_TYPE_ID = VM.VERIFICATION_TYPE_ID " +
              "INNER JOIN EMPLOYEE_MASTER EM ON FE.FE_ID = EM.EMP_ID  inner join client_master cm on(cm.client_id=cd.client_id) " +
              "WHERE CD.CLIENT_ID='" + sClientId + "' AND CD.CENTRE_ID='" + sCentreId + "'" +
              "AND fe.date_time >='" + sFromDate + "' AND fe.date_time <'" + sToDate + "'" +
              "group by VM.verification_type,EM.FIRSTNAME,EM.Middlename,EM.lastname,cm.client_name,cd.TYPE,VM.VERIFICATION_TYPE_CODE " +
              "order by EM.FIRSTNAME";
        return OleDbHelper.ExecuteDataset(objCmn.ConnectionString, CommandType.Text, sSql);
    }


    public DataSet GetBifurcationOfCases(string sFromDate, String sToDate, string sClientId, string sCentreId)
    {
        string dtToDate;
        dtToDate = Convert.ToDateTime(sToDate).AddDays(-1.0).ToString("dd-MMM-yyyy");

        DataSet ds = new DataSet();
        OleDbConnection con = new OleDbConnection(objCmn.ConnectionString);
        con.Open();

        string str = "SELECT " +
                     "'" + Convert.ToDateTime(sFromDate).ToString("dd/MM/yyyy") + "' as FROMDATE, " +
                     "'" + Convert.ToDateTime(dtToDate).ToString("dd/MM/yyyy") + "' as TODATE, " +
                     "'PAMAC Online' as [COMPANYNAME],CONVERT(VARCHAR,CASE_REC_DATETIME,103) as [RECDATE], " +
                     " convert(varchar,CASE_REC_DATETIME,103) as [RECD DATE],count(case_id) as [RECD CASES],SUM(Day0)as day0," +
                     " SUM(Day1)as day1,SUM(Day2)as day2,SUM(Day3)as day3,SUM(Day4)as day4,SUM(Day5)as day5, " +
                     " SUM(Day6)as day6,SUM(Day7)as day7,SUM(Day8)as day8,SUM(Day9)as day9," +
                     " SUM(After9Day) as after9day,SUM(PENDING)as pending , " +
                     "convert(varchar,dateAdd(day,1,CASE_REC_DATETIME),103) as date1, " +
                     "convert(varchar,dateAdd(day,2,CASE_REC_DATETIME),103) as date2, " +
                     "convert(varchar,dateAdd(day,3,CASE_REC_DATETIME),103) as date3, " +
                     "convert(varchar,dateAdd(day,4,CASE_REC_DATETIME),103) as date4, " +
                     "convert(varchar,dateAdd(day,5,CASE_REC_DATETIME),103) as date5, " +
                     "convert(varchar,dateAdd(day,6,CASE_REC_DATETIME),103) as date6, " +
                     "convert(varchar,dateAdd(day,7,CASE_REC_DATETIME),103) as date7, " +
                     "convert(varchar,dateAdd(day,8,CASE_REC_DATETIME),103) as date8, " +
                     "convert(varchar,dateAdd(day,9,CASE_REC_DATETIME),103) as date9,TYPE AS [TYPE]" +
                     " FROM (SELECT CASE_REC_DATETIME,SEND_DATETIME,CASE_ID,TYPE, " +
                     " CASE WHEN (datediff(day,CASE_REC_DATETIME,SEND_DATETIME))= 0 THEN 1 ELSE 0  END as 'Day0', " +
                     " CASE WHEN (datediff(day,CASE_REC_DATETIME,SEND_DATETIME))= 1 THEN 1 ELSE 0  END as 'Day1', " +
                     " CASE WHEN (datediff(day,CASE_REC_DATETIME,SEND_DATETIME)) = 2 THEN 1 ELSE 0  END as 'Day2'," +
                     " CASE WHEN (datediff(day,CASE_REC_DATETIME,SEND_DATETIME))= 3 THEN 1 ELSE 0  END as 'Day3'," +
                     " CASE WHEN (datediff(day,CASE_REC_DATETIME,SEND_DATETIME)) = 4 THEN 1 ELSE 0  END as 'Day4'," +
                     " CASE WHEN (datediff(day,CASE_REC_DATETIME,SEND_DATETIME)) = 5 THEN 1 ELSE 0  END as 'Day5'," +
                     " CASE WHEN (datediff(day,CASE_REC_DATETIME,SEND_DATETIME)) = 6 THEN 1 ELSE 0  END as 'Day6'," +
                     " CASE WHEN (datediff(day,CASE_REC_DATETIME,SEND_DATETIME)) = 7 THEN 1 ELSE 0  END as 'Day7'," +
                     " CASE WHEN (datediff(day,CASE_REC_DATETIME,SEND_DATETIME)) = 8 THEN 1 ELSE 0  END as 'Day8'," +
                     " CASE WHEN (datediff(day,CASE_REC_DATETIME,SEND_DATETIME)) = 9 THEN 1 ELSE 0  END as 'Day9'," +
                     " CASE WHEN (datediff(day,CASE_REC_DATETIME,SEND_DATETIME)) > 9 THEN 1 ELSE 0  END as 'After9Day', " +
                     " CASE SEND_DATETIME WHEN ISNULL(SEND_DATETIME, '') THEN 0 ELSE 1 END AS 'PENDING' " +
                     " FROM CPV_KYC_CASE_DETAILS " +
                     " WHERE CASE_REC_DATETIME >= '" + sFromDate + "' AND  CASE_REC_DATETIME <'" + sToDate + "'" +
                     " AND Client_Id='" + sClientId + "'and centre_id='" + sCentreId + "') AS EXP1 " +
                     " GROUP BY convert(varchar,CASE_REC_DATETIME,103),TYPE  ,convert(varchar,dateAdd(day,1,CASE_REC_DATETIME),103), " +
                     "convert(varchar,dateAdd(day,2,CASE_REC_DATETIME),103),convert(varchar,dateAdd(day,3,CASE_REC_DATETIME),103), " +
                     "convert(varchar,dateAdd(day,4,CASE_REC_DATETIME),103),convert(varchar,dateAdd(day,5,CASE_REC_DATETIME),103), " +
                     "convert(varchar,dateAdd(day,6,CASE_REC_DATETIME),103),convert(varchar,dateAdd(day,7,CASE_REC_DATETIME),103), " +
                     "convert(varchar,dateAdd(day,8,CASE_REC_DATETIME),103),convert(varchar,dateAdd(day,9,CASE_REC_DATETIME),103) ";

        ds = OleDbHelper.ExecuteDataset(con, CommandType.Text, str);
        return ds;
    }




}
