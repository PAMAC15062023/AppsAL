using System;
using System.Data;
using System.Data.OleDb;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

/// <summary>
/// Summary description for CStandard_Output
/// </summary>
public class CStandard_Output
{
	public CStandard_Output()
	{
        oCmn = new CCommon();
	}
    private CCommon oCmn;

    public DataTable Select_Record_Office(string strWhere)
    {
        OleDbConnection sqlConn = new OleDbConnection(oCmn.ConnectionString);
        DataSet ds = new DataSet();
        string strSQL = "";

        strSQL = "SELECT  TOP 100 PERCENT vd.VERIFICATION_TYPE_ID, ISNULL(cd.FIRST_NAME + ' ', '') + ISNULL(cd.MIDDLE_NAME + ' ', '') + ISNULL(cd.LAST_NAME + ' ', '') "+
                      "AS APPLICANT_NAME, cd.REF_NO, d3.AGENCY_NAME, cd.RES_ADD_LINE_1, cd.RES_ADD_LINE_2, cd.RES_ADD_LINE_3, cd.RES_PIN_CODE, "+
                      "cd.RES_PHONE, cd.MOBILE, cd.CASE_ID, d2.DESIGNATION, d2.COMPANY_NAME, d1.OFFICE_TELEPHONE, d2.OFFICE_EXT, d1.LOCALITY, "+
                      "d1.PORTRAIT, cd.CENTRE_ID, cd.CLIENT_ID, d2.CONTACTED_PERSON_NAME, d2.CONTACTED_PERSON_DESIGN, d2.OFFICE_SIZE, "+
                      "d2.BUSINESS_TYPE, d2.BUSINESS_ACTIVITY_SEEN, d2.NO_OF_EMP_SIGHTED_IN_PERMISES, d2.CO_APP_NAME, d2.NO_CUSTOMER_PERDAY, "+
                      "d2.APPLICANT_JOB_TRANSFERABLE, d2.CONSTRUCTION_OFFICE, d2.NO_CUSTOMER_SEEN, d2.JOB_DESC, d2.JOB_TYPE, d2.OFFICE_TYPE, "+
                      "d2.PARTICULARS, d2.VISITING_CARD_OBTAINED, d2.EASE_OF_LOCATING_OFFICE, d2.ITEM_SEEN_IN_PERMISES, "+
                      "d2.BUSINESS_BOARD_SEEN_OUTSIDE_BUILDING, CONVERT(char(24), MAX(cvt.ATTEMPT_DATE_TIME), 103) AS VisitDate, "+
                      "SUBSTRING(CONVERT(varchar(24), MAX(cvt.ATTEMPT_DATE_TIME), 100), 12, 12) AS Time_Of_calling, cvt.VERIFIER_ID, "+
                      "EMPLOYEE_MASTER.FULLNAME AS Verifier_Name, d2.OFFICE_OWNERSHIP, d1.BRANCH, d1.APPROXIMATE_AREA, d2.RECOMENDATION_NO, "+
                      "d2.NO_OF_EMP, d2.BUSINESS_NATURE, d2.AVG_MONTH_TURNOVER, d2.OFFICE_LOCALITY, d2.APPLICANT_NAME_VERIFIED_FROM, "+
                      "d1.ADRESS_CONFIRMATION, d1.INTERIOR, d1.EXTERIOR " +
                      "FROM  EMPLOYEE_MASTER INNER JOIN "+
                      "CPV_CC_VERI_ATTEMPTS AS cvt ON EMPLOYEE_MASTER.EMP_ID = cvt.VERIFIER_ID RIGHT OUTER JOIN "+
                      "CPV_CC_VERI_DETAILS AS vd INNER JOIN "+
                      "CPV_CC_CASE_DETAILS AS cd ON vd.CASE_ID = cd.CASE_ID LEFT OUTER JOIN "+
                      "CASE_STATUS_MASTER AS cs ON vd.CASE_STATUS_ID = cs.CASE_STATUS_ID LEFT OUTER JOIN "+
                      "VERIFICATION_TYPE_MASTER AS vt ON vd.VERIFICATION_TYPE_ID = vt.VERIFICATION_TYPE_ID LEFT OUTER JOIN "+
                      "CPV_CC_VERI_DESCRIPTION AS d1 ON vd.CASE_ID = d1.CASE_ID AND vd.VERIFICATION_TYPE_ID = d1.VERIFICATION_TYPE_ID LEFT OUTER JOIN "+
                      "CPV_CC_VERI_DESCRIPTION1 AS d2 ON vd.CASE_ID = d2.CASE_ID AND vd.VERIFICATION_TYPE_ID = d2.VERIFICATION_TYPE_ID LEFT OUTER JOIN "+
                      "CPV_CC_VERI_OTHER_DETAILS AS d3 ON vd.CASE_ID = d3.CASE_ID AND vd.VERIFICATION_TYPE_ID = d3.VERIFICATION_TYPE_ID ON  "+
                      "cvt.CASE_ID = d3.CASE_ID AND cvt.VERIFICATION_TYPE_ID = vd.VERIFICATION_TYPE_ID "+
                      "WHERE (cd.CASE_ID IN (" + strWhere + ")) AND (vt.VERIFICATION_TYPE_CODE = 'BV') " +
                      "GROUP BY vd.VERIFICATION_TYPE_ID, ISNULL(cd.FIRST_NAME + ' ', '') + ISNULL(cd.MIDDLE_NAME + ' ', '') + ISNULL(cd.LAST_NAME + ' ', ''), cd.REF_NO,  "+
                      "d3.AGENCY_NAME, cd.RES_ADD_LINE_1, cd.RES_ADD_LINE_2, cd.RES_ADD_LINE_3, cd.RES_PIN_CODE, cd.RES_PHONE, cd.MOBILE, cd.CASE_ID,  "+
                      "d2.DESIGNATION, d2.COMPANY_NAME, d1.OFFICE_TELEPHONE, d2.OFFICE_EXT, d1.LOCALITY, d1.PORTRAIT, cd.CENTRE_ID, cd.CLIENT_ID,  "+
                      "d2.CONTACTED_PERSON_NAME, d2.CONTACTED_PERSON_DESIGN, d2.OFFICE_SIZE, d2.BUSINESS_TYPE, d2.BUSINESS_ACTIVITY_SEEN,  "+
                      "d2.NO_OF_EMP_SIGHTED_IN_PERMISES, d2.CO_APP_NAME, d2.NO_CUSTOMER_PERDAY, d2.APPLICANT_JOB_TRANSFERABLE, "+
                      "d2.CONSTRUCTION_OFFICE, d2.NO_CUSTOMER_SEEN, d2.JOB_DESC, d2.JOB_TYPE, d2.OFFICE_TYPE, d2.PARTICULARS, "+
                      "d2.VISITING_CARD_OBTAINED, d2.EASE_OF_LOCATING_OFFICE, d2.ITEM_SEEN_IN_PERMISES, d2.BUSINESS_BOARD_SEEN_OUTSIDE_BUILDING, "+
                      "cvt.VERIFIER_ID, EMPLOYEE_MASTER.FULLNAME, d2.OFFICE_OWNERSHIP, d1.BRANCH, d1.APPROXIMATE_AREA, d2.RECOMENDATION_NO,  "+
                      "d2.NO_OF_EMP, d2.BUSINESS_NATURE, d2.AVG_MONTH_TURNOVER, d2.OFFICE_LOCALITY, d2.APPLICANT_NAME_VERIFIED_FROM, "+
                      "d1.ADRESS_CONFIRMATION, cd.DESIGNATION,d1.INTERIOR, d1.EXTERIOR";
        
        ds = OleDbHelper.ExecuteDataset(sqlConn, CommandType.Text, strSQL);
        DataTable dt = new DataTable();
        dt = ds.Tables[0];
        ds.Tables.Clear();
        ds.Clear();
        return dt;
    }

    public DataTable Select_Record_Residence(string strWhere)
    {
        OleDbConnection sqlConn = new OleDbConnection(oCmn.ConnectionString);
        DataSet ds = new DataSet();
        string strSQL = "";
        strSQL = "SELECT TOP 100 PERCENT vd.VERIFICATION_TYPE_ID, ISNULL(cd.FIRST_NAME + ' ', '') + ISNULL(cd.MIDDLE_NAME + ' ', '') + ISNULL(cd.LAST_NAME + ' ', '') "+
                      "AS APPLICANT_NAME, cd.REF_NO, d3.AGENCY_NAME, cd.RES_ADD_LINE_1, cd.RES_ADD_LINE_2, cd.RES_ADD_LINE_3, cd.RES_PIN_CODE, "+
                      "cd.RES_LAND_MARK, cd.RES_PHONE, cd.MOBILE, d2.PINCODE, cd.CASE_ID, cd.DOB, d1.MARITAL_STATUS, d1.NO_OF_DEPENDENT, "+
                      "d2.DESIGNATION, d1.APPLICANT_AVAILABILITY, d1.IS_SPOUSE_WORKING, d1.VERIFIED_NEIGHBOUR, d1.LOCALITY, d1.ASSETS_VISIBLE, "+
                      "d1.PORTRAIT, d3.IS_OCL, cd.CENTRE_ID, cd.CLIENT_ID, ISNULL(cd.OFF_ADD_LINE_1 + ' ', '') + ISNULL(cd.OFF_ADD_LINE_2 + ' ', '') "+
                      "+ ISNULL(cd.OFF_ADD_LINE_3 + ' ', '') AS OFF_ADD_LINE, d2.CONTACTED_PERSON_NAME, d2.CONTACTED_PERSON_DESIGN, "+
                      "d3.PERSON_CONTACTED, d3.REL_WITH_APPLICANT, d2.DOB_APPLICANT, d2.APPLICANT_IS_AVAILABLE_AT, d1.APPLICANT_AGE, d2.SPK_TO, "+
                      "d2.APPLICANT_NAME_VERIFIED_FROM, d2.APP_QUALIFICATION, d2.NAME_OF_PERSON_CONTACTED, d1.PERSON_CONTACTED_MET, "+
                      "d1.CUSTOMER_COOPERATION, d1.COMMENTS_EXTERIORS, d1.FAMILY_MEMBERS, d1.NO_OF_EARNING_FAMILY_MEMBER, d1.INTERIOR, "+ 
                      "d1.EXTERIOR, d1.APP_DOB_APPROX_AGE, d1.RECOMMENDATION, CONVERT(char(24), MAX(cvt.ATTEMPT_DATE_TIME), 103) AS VisitDate, "+
                      "SUBSTRING(CONVERT(varchar(24), MAX(cvt.ATTEMPT_DATE_TIME), 100), 12, 12) AS Time_Of_calling, cvt.VERIFIER_ID, "+
                      "EMPLOYEE_MASTER.FULLNAME AS Verifier_Name, d2.SPECIAL_INSTRUCTIONS, d1.IS_CREDIT_CARD, d1.CARD_TYPE, d1.CARD_NO, "+ 
                      "d1.CARD_LIMIT, d1.CARD_EXPIRY, d1.ISSUING_BANK, d2.RESIDANCE_STATUS, d2.RECOMENDATION_NO, d2.NEIGHBOUR_REFERENCE, "+
                      "d2.CURRENT_RESIDENCE_PERIOD, cd.SPL_INSTRUCTION, d2.RELATION_PERSON_CONTACTED, d1.TIME_AT_CURR_RESIDANCE, "+
                      "d1.APPROXIMATE_AREA, d1.LOCATING_ADDRESS, d1.CONSTRUCTION_OF_RESIDANCE, d1.APPLICANT_STAYED_RESIDANCE,d1.ADRESS_CONFIRMATION " +
                      "FROM EMPLOYEE_MASTER INNER JOIN "+
                      "CPV_CC_VERI_ATTEMPTS AS cvt ON EMPLOYEE_MASTER.EMP_ID = cvt.VERIFIER_ID RIGHT OUTER JOIN "+
                      "CPV_CC_VERI_DETAILS AS vd INNER JOIN "+
                      "CPV_CC_CASE_DETAILS AS cd ON vd.CASE_ID = cd.CASE_ID LEFT OUTER JOIN "+
                      "CASE_STATUS_MASTER AS cs ON vd.CASE_STATUS_ID = cs.CASE_STATUS_ID LEFT OUTER JOIN "+
                      "VERIFICATION_TYPE_MASTER AS vt ON vd.VERIFICATION_TYPE_ID = vt.VERIFICATION_TYPE_ID LEFT OUTER JOIN "+
                      "CPV_CC_VERI_DESCRIPTION AS d1 ON vd.CASE_ID = d1.CASE_ID AND vd.VERIFICATION_TYPE_ID = d1.VERIFICATION_TYPE_ID LEFT OUTER JOIN "+
                      "CPV_CC_VERI_DESCRIPTION1 AS d2 ON vd.CASE_ID = d2.CASE_ID AND vd.VERIFICATION_TYPE_ID = d2.VERIFICATION_TYPE_ID LEFT OUTER JOIN "+
                      "CPV_CC_VERI_OTHER_DETAILS AS d3 ON vd.CASE_ID = d3.CASE_ID AND vd.VERIFICATION_TYPE_ID = d3.VERIFICATION_TYPE_ID ON  "+
                      "cvt.CASE_ID = d3.CASE_ID AND cvt.VERIFICATION_TYPE_ID = vd.VERIFICATION_TYPE_ID "+
                      "WHERE (cd.CASE_ID IN (" + strWhere + ")) AND (vt.VERIFICATION_TYPE_CODE = 'RV') " +
                      "GROUP BY vd.VERIFICATION_TYPE_ID, ISNULL(cd.FIRST_NAME + ' ', '') + ISNULL(cd.MIDDLE_NAME + ' ', '') + ISNULL(cd.LAST_NAME + ' ', ''), cd.REF_NO,  "+
                      "d3.AGENCY_NAME, cd.RES_ADD_LINE_1, cd.RES_ADD_LINE_2, cd.RES_ADD_LINE_3, cd.RES_PIN_CODE, cd.RES_LAND_MARK, cd.RES_PHONE,  "+
                      "cd.MOBILE, d2.PINCODE, cd.CASE_ID, cd.DOB, d1.MARITAL_STATUS, d1.NO_OF_DEPENDENT, d2.DESIGNATION, d1.APPLICANT_AVAILABILITY, "+
                      "d1.IS_SPOUSE_WORKING, d1.VERIFIED_NEIGHBOUR, d1.LOCALITY, d1.ASSETS_VISIBLE, d1.PORTRAIT, d3.IS_OCL, cd.CENTRE_ID, cd.CLIENT_ID, "+
                      "ISNULL(cd.OFF_ADD_LINE_1 + ' ', '') + ISNULL(cd.OFF_ADD_LINE_2 + ' ', '') + ISNULL(cd.OFF_ADD_LINE_3 + ' ', ''), d2.CONTACTED_PERSON_NAME, "+
                      "d2.CONTACTED_PERSON_DESIGN, d3.PERSON_CONTACTED, d3.REL_WITH_APPLICANT, d2.DOB_APPLICANT, d2.APPLICANT_IS_AVAILABLE_AT, "+
                      "d1.APPLICANT_AGE, d2.SPK_TO, d2.APPLICANT_NAME_VERIFIED_FROM, d2.APP_QUALIFICATION, d2.NAME_OF_PERSON_CONTACTED, "+
                      "d1.PERSON_CONTACTED_MET, d1.CUSTOMER_COOPERATION, d1.COMMENTS_EXTERIORS, d1.FAMILY_MEMBERS, "+
                      "d1.NO_OF_EARNING_FAMILY_MEMBER, d1.INTERIOR, d1.EXTERIOR, d1.APP_DOB_APPROX_AGE, d1.RECOMMENDATION, cvt.VERIFIER_ID, "+
                      "EMPLOYEE_MASTER.FULLNAME, d2.SPECIAL_INSTRUCTIONS, d1.IS_CREDIT_CARD, d1.CARD_TYPE, d1.CARD_NO, d1.CARD_LIMIT, "+
                      "d1.CARD_EXPIRY, d1.ISSUING_BANK, d2.RESIDANCE_STATUS, d2.RECOMENDATION_NO, d2.NEIGHBOUR_REFERENCE, "+
                      "d2.CURRENT_RESIDENCE_PERIOD, cd.SPL_INSTRUCTION, d2.RELATION_PERSON_CONTACTED, d1.TIME_AT_CURR_RESIDANCE, " +
                      "d1.APPROXIMATE_AREA, d1.LOCATING_ADDRESS, d1.CONSTRUCTION_OF_RESIDANCE, d1.APPLICANT_STAYED_RESIDANCE,d1.ADRESS_CONFIRMATION";
        
        ds = OleDbHelper.ExecuteDataset(sqlConn, CommandType.Text, strSQL);
        
        DataTable dt = new DataTable();
        dt = ds.Tables[0];
        ds.Tables.Clear();
        ds.Clear();
        return dt;
     }

    public DataTable Select_Record_Residence_Telephone(string strWhere)
    {
        OleDbConnection sqlConn = new OleDbConnection(oCmn.ConnectionString);
        DataSet ds = new DataSet();
        string strSQL = "";        

        strSQL="SELECT TOP 100 PERCENT vd.VERIFICATION_TYPE_ID, ISNULL(cd.FIRST_NAME + ' ', '') + ISNULL(cd.MIDDLE_NAME + ' ', '') + ISNULL(cd.LAST_NAME + ' ', '') "+
                      "AS APPLICANT_NAME, cd.REF_NO, d3.AGENCY_NAME, cd.RES_ADD_LINE_1, cd.RES_ADD_LINE_2, cd.RES_ADD_LINE_3, cd.RES_PIN_CODE, "+
                      "cd.RES_LAND_MARK, cd.RES_PHONE, cd.MOBILE, cd.CASE_ID, cd.DOB, d2.DESIGNATION, cd.CENTRE_ID, cd.CLIENT_ID, "+
                      "ISNULL(cd.OFF_ADD_LINE_1 + ' ', '') + ISNULL(cd.OFF_ADD_LINE_2 + ' ', '') + ISNULL(cd.OFF_ADD_LINE_3 + ' ', '') AS OFF_ADD_LINE, "+
                      "d2.CONTACTED_PERSON_NAME, d3.PERSON_CONTACTED, d3.REL_WITH_APPLICANT, d2.DOB_APPLICANT, d2.APPLICANT_IS_AVAILABLE_AT, "+
                      "d2.SPK_TO, CONVERT(char(24), MAX(cvt.ATTEMPT_DATE_TIME), 103) AS VisitDate, SUBSTRING(CONVERT(varchar(24), "+
                      "MAX(cvt.ATTEMPT_DATE_TIME), 100), 12, 12) AS Time_Of_calling, cvt.VERIFIER_ID, EMPLOYEE_MASTER.FULLNAME AS Verifier_Name, "+
                      "d2.SPECIAL_INSTRUCTIONS, cd.SPL_INSTRUCTION, d2.RELATION_PERSON_CONTACTED, cd.PMT_ADD_LINE_1, cd.PMT_ADD_LINE_2, "+
                      "cd.PMT_ADD_LINE_3, cd.PMT_CITY, cd.PMT_STATE, cd.PMT_PIN_CODE, d1.EMP_CONFIRMED_OR_NOT_CONFIRMED, "+
                      "d1.TELE_VERIFICATION_RESULT "+
                      "FROM EMPLOYEE_MASTER INNER JOIN "+
                      "CPV_CC_VERI_ATTEMPTS AS cvt ON EMPLOYEE_MASTER.EMP_ID = cvt.VERIFIER_ID RIGHT OUTER JOIN "+
                      "CPV_CC_VERI_DETAILS AS vd INNER JOIN "+
                      "CPV_CC_CASE_DETAILS AS cd ON vd.CASE_ID = cd.CASE_ID LEFT OUTER JOIN "+
                      "CASE_STATUS_MASTER AS cs ON vd.CASE_STATUS_ID = cs.CASE_STATUS_ID LEFT OUTER JOIN "+
                      "VERIFICATION_TYPE_MASTER AS vt ON vd.VERIFICATION_TYPE_ID = vt.VERIFICATION_TYPE_ID LEFT OUTER JOIN "+
                      "CPV_CC_VERI_DESCRIPTION AS d1 ON vd.CASE_ID = d1.CASE_ID AND vd.VERIFICATION_TYPE_ID = d1.VERIFICATION_TYPE_ID LEFT OUTER JOIN "+
                      "CPV_CC_VERI_DESCRIPTION1 AS d2 ON vd.CASE_ID = d2.CASE_ID AND vd.VERIFICATION_TYPE_ID = d2.VERIFICATION_TYPE_ID LEFT OUTER JOIN "+
                      "CPV_CC_VERI_OTHER_DETAILS AS d3 ON vd.CASE_ID = d3.CASE_ID AND vd.VERIFICATION_TYPE_ID = d3.VERIFICATION_TYPE_ID ON  "+
                      "cvt.CASE_ID = d3.CASE_ID AND cvt.VERIFICATION_TYPE_ID = vd.VERIFICATION_TYPE_ID "+
                      "WHERE (cd.CASE_ID IN (" + strWhere + ")) AND (vt.VERIFICATION_TYPE_CODE = 'RT') " +
                      "GROUP BY vd.VERIFICATION_TYPE_ID, ISNULL(cd.FIRST_NAME + ' ', '') + ISNULL(cd.MIDDLE_NAME + ' ', '') + ISNULL(cd.LAST_NAME + ' ', ''), cd.REF_NO,  "+
                      "d3.AGENCY_NAME, cd.RES_ADD_LINE_1, cd.RES_ADD_LINE_2, cd.RES_ADD_LINE_3, cd.RES_PIN_CODE, cd.RES_LAND_MARK, cd.RES_PHONE,  "+
                      "cd.MOBILE, cd.CASE_ID, cd.DOB, d2.DESIGNATION, cd.CENTRE_ID, cd.CLIENT_ID, ISNULL(cd.OFF_ADD_LINE_1 + ' ', '') "+
                      "+ ISNULL(cd.OFF_ADD_LINE_2 + ' ', '') + ISNULL(cd.OFF_ADD_LINE_3 + ' ', ''), d2.CONTACTED_PERSON_NAME, d3.PERSON_CONTACTED, "+
                      "d3.REL_WITH_APPLICANT, d2.DOB_APPLICANT, d2.APPLICANT_IS_AVAILABLE_AT, d2.SPK_TO, cvt.VERIFIER_ID, EMPLOYEE_MASTER.FULLNAME, "+
                      "d2.SPECIAL_INSTRUCTIONS, cd.SPL_INSTRUCTION, d2.RELATION_PERSON_CONTACTED, cd.PMT_ADD_LINE_1, cd.PMT_ADD_LINE_2, "+
                      "cd.PMT_ADD_LINE_3, cd.PMT_CITY, cd.PMT_STATE, cd.PMT_PIN_CODE, d1.EMP_CONFIRMED_OR_NOT_CONFIRMED, " +
                      "d1.TELE_VERIFICATION_RESULT ";

        ds = OleDbHelper.ExecuteDataset(sqlConn, CommandType.Text, strSQL);
        DataTable dt = new DataTable();
        dt = ds.Tables[0];
        ds.Tables.Clear();
        ds.Clear();
        return dt;
    }

    public DataSet Select_Date_Time_Calling(string strWhere)
    {
        OleDbConnection sqlConn = new OleDbConnection(oCmn.ConnectionString);
        DataSet ds = new DataSet();
        string strSQL = "";
        strSQL = "SELECT CASE_ID, VERIFICATION_TYPE_ID, CONVERT(char(24), ATTEMPT_DATE_TIME, 103) AS Date_Of_Calling, SUBSTRING(CONVERT(varchar(24), " +
                "ATTEMPT_DATE_TIME, 100), 12, 12) AS Time_Of_calling " +
                "FROM CPV_CC_VERI_ATTEMPTS " +
                "WHERE (CPV_CC_VERI_ATTEMPTS.CASE_ID in(" + strWhere + "))AND (VERIFICATION_TYPE_ID = 4) ";
        ds = OleDbHelper.ExecuteDataset(sqlConn, CommandType.Text, strSQL);
        return ds;
    }
    
    public DataTable Select_Record_Office_Telephone(string strWhere)
    {
        OleDbConnection sqlConn = new OleDbConnection(oCmn.ConnectionString);
        DataSet ds = new DataSet();
        string strSQL = "SELECT TOP 100 PERCENT vd.VERIFICATION_TYPE_ID, ISNULL(cd.FIRST_NAME + ' ', '') + ISNULL(cd.MIDDLE_NAME + ' ', '') + ISNULL(cd.LAST_NAME + ' ', '') "+
                      "AS APPLICANT_NAME, cd.REF_NO, cd.CASE_ID, d2.DESIGNATION, cd.CENTRE_ID, cd.CLIENT_ID, ISNULL(cd.OFF_ADD_LINE_1 + ' ', '') "+
                      "+ ISNULL(cd.OFF_ADD_LINE_2 + ' ', '') + ISNULL(cd.OFF_ADD_LINE_3 + ' ', '') AS OFF_ADD_LINE, d3.PERSON_CONTACTED, "+
                      "d3.REL_WITH_APPLICANT, d2.SPK_TO, CONVERT(char(24), MAX(cvt.ATTEMPT_DATE_TIME), 103) AS VisitDate, SUBSTRING(CONVERT(varchar(24), "+
                      "MAX(cvt.ATTEMPT_DATE_TIME), 100), 12, 12) AS Time_Of_calling, cvt.VERIFIER_ID, EMPLOYEE_MASTER.FULLNAME AS Verifier_Name, "+
                      "d2.SPECIAL_INSTRUCTIONS, cd.SPL_INSTRUCTION, d2.RELATION_PERSON_CONTACTED, d1.TELE_VERIFICATION_RESULT, cd.OFF_PHONE, "+
                      "cd.OFF_EXTN, cd.FIRST_NAME, cd.MIDDLE_NAME, cd.LAST_NAME, cd.FULL_NAME, cd.OFF_ADD_LINE_1, cd.OFF_ADD_LINE_2, cd.OFF_ADD_LINE_3, "+
                      "cd.OFF_CITY, cd.OFF_STATE, cd.OFF_PIN_CODE, cd.DESIGNATION AS Expr1, cd.DEPARTMENT, d2.TIME_AT_CURRENT_EMPL_Y_M "+
                      "FROM  EMPLOYEE_MASTER INNER JOIN "+
                      "CPV_CC_VERI_ATTEMPTS AS cvt ON EMPLOYEE_MASTER.EMP_ID = cvt.VERIFIER_ID RIGHT OUTER JOIN "+
                      "CPV_CC_VERI_DETAILS AS vd INNER JOIN "+
                      "CPV_CC_CASE_DETAILS AS cd ON vd.CASE_ID = cd.CASE_ID LEFT OUTER JOIN "+
                      "CASE_STATUS_MASTER AS cs ON vd.CASE_STATUS_ID = cs.CASE_STATUS_ID LEFT OUTER JOIN "+
                      "VERIFICATION_TYPE_MASTER AS vt ON vd.VERIFICATION_TYPE_ID = vt.VERIFICATION_TYPE_ID LEFT OUTER JOIN "+
                      "CPV_CC_VERI_DESCRIPTION AS d1 ON vd.CASE_ID = d1.CASE_ID AND vd.VERIFICATION_TYPE_ID = d1.VERIFICATION_TYPE_ID LEFT OUTER JOIN "+
                      "CPV_CC_VERI_DESCRIPTION1 AS d2 ON vd.CASE_ID = d2.CASE_ID AND vd.VERIFICATION_TYPE_ID = d2.VERIFICATION_TYPE_ID LEFT OUTER JOIN "+
                      "CPV_CC_VERI_OTHER_DETAILS AS d3 ON vd.CASE_ID = d3.CASE_ID AND vd.VERIFICATION_TYPE_ID = d3.VERIFICATION_TYPE_ID ON  "+
                      "cvt.CASE_ID = d3.CASE_ID AND cvt.VERIFICATION_TYPE_ID = vd.VERIFICATION_TYPE_ID "+
                      "WHERE (cd.CASE_ID IN (" + strWhere + ")) AND (vt.VERIFICATION_TYPE_CODE = 'BT') " +
                       "GROUP BY vd.VERIFICATION_TYPE_ID, ISNULL(cd.FIRST_NAME + ' ', '') + ISNULL(cd.MIDDLE_NAME + ' ', '') + ISNULL(cd.LAST_NAME + ' ', ''), cd.REF_NO,  "+
                      "cd.CASE_ID, d2.DESIGNATION, cd.CENTRE_ID, cd.CLIENT_ID, ISNULL(cd.OFF_ADD_LINE_1 + ' ', '') + ISNULL(cd.OFF_ADD_LINE_2 + ' ', '')  "+
                      "+ ISNULL(cd.OFF_ADD_LINE_3 + ' ', ''), d3.PERSON_CONTACTED, d3.REL_WITH_APPLICANT, d2.SPK_TO, cvt.VERIFIER_ID, "+
                      "EMPLOYEE_MASTER.FULLNAME, d2.SPECIAL_INSTRUCTIONS, cd.SPL_INSTRUCTION, d2.RELATION_PERSON_CONTACTED, "+
                      "d1.TELE_VERIFICATION_RESULT, cd.OFF_PHONE, cd.OFF_EXTN, cd.FIRST_NAME, cd.MIDDLE_NAME, cd.LAST_NAME, cd.FULL_NAME, "+
                      "cd.OFF_ADD_LINE_1, cd.OFF_ADD_LINE_2, cd.OFF_ADD_LINE_3, cd.OFF_CITY, cd.OFF_STATE, cd.OFF_PIN_CODE, cd.DESIGNATION, "+
                      "cd.DEPARTMENT, d2.TIME_AT_CURRENT_EMPL_Y_M";
        ds = OleDbHelper.ExecuteDataset(sqlConn, CommandType.Text, strSQL);
        DataTable dt = new DataTable();
        dt = ds.Tables[0];
        ds.Tables.Clear();
        ds.Clear();
        return dt;
    }
    public DataTable Select_CaseId(string strWhere)
    {
        OleDbConnection sqlConn = new OleDbConnection(oCmn.ConnectionString);
        DataSet ds = new DataSet();
        //string strSQL = "Select count(v.case_id) as verified, Case_Id from CPV_CC_CASE_DETAILS c, CPV_CC_VERI_OTHER_DETAILS v WHERE (CASE_ID in(" + strWhere + ")) ";
        string strSQL="Select count(*) as verified, Case_Id from CPV_CC_VERI_OTHER_DETAILS where case_id in(" + strWhere + ") group by case_id" ;
        ds = OleDbHelper.ExecuteDataset(sqlConn, CommandType.Text, strSQL);
        DataTable dt = new DataTable();        
        dt = ds.Tables[0];
        ds.Tables.Clear();
        ds.Clear();
        return dt;
      
    }

}
