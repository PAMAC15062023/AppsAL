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
/// Summary description for EBC_StandardOutPut
/// </summary>
public class EBC_StandardOutPut
{
	public EBC_StandardOutPut()
	{
		//
		// TODO: Add constructor logic here

		//
        oCmn = new CCommon();
	}
    private CCommon oCmn;
   
    #region StandardOutputReport(Verification) Report
    public DataTable GetGAP_Verification(string strWhere)
    {

        DataSet ds = new DataSet();
        string strSQL = "";

        strSQL = "SELECT CD.EMP_CODE, ISNULL(CD.FIRST_NAME,'')+'  '+ISNULL(CD.MIDDLE_NAME,'')+'  '+ISNULL(CD.LAST_NAME,'') AS APPLICANT_NAME,CV.Gap_Identified ,cv.Period_Of_Gap, CV.Reason_Of_Gap,CV.Address_Gap," +
                 "CV.Police_Verification_GAP,CV.Police_Verification from  CPV_EBC_VERIFICATION cv inner join CPV_EBC_CASE_DETAILS cd on " +
                 " CV.case_id=CD.case_id where CD.CASE_ID IN ('" + strWhere + "') AND cv.verification_type_id='17'";

        ds = OleDbHelper.ExecuteDataset(oCmn.ConnectionString, CommandType.Text, strSQL);
        DataTable dt = new DataTable();
        dt = ds.Tables[0];
        ds.Tables.Clear();
        ds.Clear();
        return dt;
    }
    public DataTable GetResidenceVerification(string strWhere)
    {
       

        DataSet ds = new DataSet();
        DataSet ds1 = new DataSet();
        string strSQL = "";
        strSQL = " select RELATIONSHIP FROM CPV_EBC_RELATIONSHIP WHERE CASE_ID='" + strWhere + "'";
        ds1 = OleDbHelper.ExecuteDataset(oCmn.ConnectionString, CommandType.Text, strSQL);

        DataTable dt = new DataTable();
        if (ds1.Tables[0].Rows.Count > 0)
        {


            strSQL = "SELECT  ISNULL(CD.FIRST_NAME,'')+'  '+ISNULL(CD.MIDDLE_NAME,'')+'  '+ISNULL(CD.LAST_NAME,'') " +
               " AS APPLICANT_NAME,CV.CONTACT_PERSON_DESIGNATION,ISNULL(CD.ADD_LINE_1,'')+'  '+ISNULL(CD.ADD_LINE_2,'')+'  '+ISNULL(CD.ADD_LINE_3,'') AS ADDRESS" +
               ",CV.CONTACT_PERSON,CV.RELATIONSHIP,CV.TELEPHONE_NO,CV.YEAR_AT_RESIDENCE,CV.LANDMARK,CV.ACCESSIBILITY,CV.LOCALITY" +
               " ,ER.RELATIONSHIP AS FAMILY_RELATIONSHIP,ER.OCCUPATION,CV.Residence_Type,CV.PREVIOUS_JOB_DETAIL,CV.NEIGHBOUR_NAME,CV.NEIGHBOUR_FEEDBACK,CV.REMARK,CV.ORGANIZATION_NAME" +
                " ,CV.TEL_NO2,CV.Permanent_Address from CPV_EBC_VERIFICATION cv inner join CPV_EBC_CASE_DETAILS cd on CV.case_id=CD.case_id inner join CPV_EBC_RELATIONSHIP ER on ER.CASE_ID=CD.CASE_ID" +
                " where CD.CASE_ID IN ('" + strWhere + "') AND cv.verification_type_id='1'";


        }



        else
        {
            strSQL = "  SELECT  ISNULL(CD.FIRST_NAME,'')+'  '+ISNULL(CD.MIDDLE_NAME,'')+'  '+ISNULL(CD.LAST_NAME,'')  AS APPLICANT_NAME,CV.CONTACT_PERSON_DESIGNATION,ISNULL(CD.ADD_LINE_1,'')+'  '+ISNULL(CD.ADD_LINE_2,'')+'  '+ISNULL(CD.ADD_LINE_3,'') AS ADDRESS,CV.CONTACT_PERSON,CV.RELATIONSHIP,CV.TELEPHONE_NO,CV.YEAR_AT_RESIDENCE,CV.LANDMARK,CV.ACCESSIBILITY,CV.LOCALITY ,CV.Residence_Type,CV.PREVIOUS_JOB_DETAIL,CV.NEIGHBOUR_NAME,CV.NEIGHBOUR_FEEDBACK,CV.REMARK,CV.ORGANIZATION_NAME ,CV.TEL_NO2,CV.Permanent_Address from CPV_EBC_VERIFICATION cv inner join CPV_EBC_CASE_DETAILS cd on CV.case_id=CD.case_id AND cv.verification_type_id='1'";
        }

        ds = OleDbHelper.ExecuteDataset(oCmn.ConnectionString, CommandType.Text, strSQL);

        
        dt = ds.Tables[0];
        ds.Tables.Clear();
        ds.Clear();
        return dt;
    }
    public DataTable GetDegree_Verification(string strWhere)
    {

        DataSet ds = new DataSet();
        string strSQL = "";
        strSQL = " SELECT  ISNULL(CD.FIRST_NAME,'')+'  '+ISNULL(CD.MIDDLE_NAME,'')+'  '+ISNULL(CD.LAST_NAME,'') AS APPLICANT_NAME,convert(varchar(11), CD.DOB,104) as DOB ,CV.CONTACT_PERSON,CV.CONTACT_PERSON_DESIGNATION,WV.FULLNAME,convert(varchar(11), CV.VERIFICATION_DATETIME,104) as VERIFICATION_DATETIME ," +
                    "CV.INSTITUTE_NAME,CV.DATE_ATTEND,CSM.STATUS_CODE,CV.QULAIFICATION_GAINED,CV.REMARK from " +
                    
                    " CPV_EBC_VERIFICATION cv inner join CPV_EBC_CASE_DETAILS cd on CV.case_id=CD.case_id INNER JOIN "+
                    "CPV_EBC_FE_MAPPING CF ON CV.CASE_ID=CF.CASE_ID INNER JOIN FE_VW WV ON CF.FE_ID=WV.EMP_ID"+
                    " INNER JOIN CASE_STATUS_MASTER CSM ON CV.CASE_STATUS_ID=CSM.CASE_STATUS_ID where CD.CASE_ID IN ('" + strWhere + "') AND cv.verification_type_id='16'";
        ds = OleDbHelper.ExecuteDataset(oCmn.ConnectionString, CommandType.Text, strSQL);
        DataTable dt = new DataTable();
        dt = ds.Tables[0];
        ds.Tables.Clear();
        ds.Clear();
        return dt;
    }
    public DataTable GetEmployment_Verification(string strWhere)
    {
        DataSet ds = new DataSet();
        string strSQL = "";
        strSQL = "SELECT  ISNULL(CD.FIRST_NAME,'')+'  '+ISNULL(CD.MIDDLE_NAME,'')+'  '+ISNULL(CD.LAST_NAME,'') AS APPLICANT_NAME,"+
                 "CV.CONTACT_PERSON,CV.CONTACT_PERSON_DESIGNATION,CSM.STATUS_CODE" +
                 ",CV.INSTITUTE_NAME,convert(varchar(11), CV.EMPLOYMENT_DATE,104) as EMPLOYMENT_DATE ,CV.LAST_POSITION_HELD,CV.REPORTING_MANAGER,CV.REMARK  from " +
                 "CPV_EBC_VERIFICATION cv inner join CPV_EBC_CASE_DETAILS cd on CV.case_id=CD.case_id INNER JOIN CASE_STATUS_MASTER CSM ON CV.CASE_STATUS_ID=CSM.CASE_STATUS_ID" +
                 " where   CD.CASE_ID IN ('" + strWhere + "') AND cv.verification_type_id='18'";
        ds = OleDbHelper.ExecuteDataset(oCmn.ConnectionString, CommandType.Text, strSQL);
       
        DataTable dt = new DataTable();
        dt = ds.Tables[0];
        ds.Tables.Clear();
        ds.Clear();
        return dt;
    }   
    public DataTable GetCaseIdforReport(string strWhere)
    {

        DataSet ds = new DataSet();
        //string strSQL = "Select count(v.case_id) as verified, Case_Id from CPV_CC_CASE_DETAILS c, CPV_CC_VERI_OTHER_DETAILS v WHERE (CASE_ID in(" + strWhere + ")) ";
        string strSQL = "Select count(*) as verified, Case_Id from CPV_EBC_VAERIFICATION_TYPE where case_id in(" + strWhere + ") group by case_id";
        ds = OleDbHelper.ExecuteDataset(oCmn.ConnectionString, CommandType.Text, strSQL);
        DataTable dt = new DataTable();
        dt = ds.Tables[0];
        ds.Tables.Clear();
        ds.Clear();
        return dt;
    }
    public OleDbDataReader GetRefNoByCaseId(string sCaseId)
    {
        string sSql = "SELECT REF_NO from CPV_EBC_CASE_DETAILS where case_id='" + sCaseId + "'";
        return OleDbHelper.ExecuteReader(oCmn.ConnectionString, CommandType.Text, sSql);
    }

    #endregion StandardOutputReport(Verification) Report

}
