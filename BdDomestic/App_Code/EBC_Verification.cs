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
/// Summary description for EBC_Verification
/// </summary>
public class EBC_Verification
{
    private CCommon oCmn;
    private string sCaseID;
    private string sVerificationID;
    private string sEmployeeName;
    private string sAddress;
    private string sNameOfPersonContacted;
     
    private string sRelationshipToEmp;
    private string sTelephoneno1;
    private string sNumberOfYear;
    private string sResidenceType;
    private string sLandmark;
    private string sAccessbility;
    private string sFamilyMember;
    private string spermanentAdd;
    private string sTelephone2;
    private string sDetailAbtPreviousJob;
    private string sNeighbourName;
    private string sNeighbourFeedbackOnEmp;
    private string sRemark;
    private string sEmpEcn;
    private string sGapIdentified;
    private string sPeriodOfGap;
    private string sReasonOfGap;
    private string sAddressDuringGap;
    private string spoliceVerificationGap;
    private string sPoliceVerification;
    private string sRespomdentName;
    private string sRespondentDesignation;
    private string sOrganisationName;
    private string sEmployeeDates;
    private string sLastposition;
    private string sReportingManager;
    private string sStatus;
    private string sSubjectName;
    private string sDOB;
    private string sVerificationName;
    private string sInstitutionName;
    private string sDatesAttented;
    private string sQualificationGained;
    private string sVerificationDateTime;
    private string sPreviousJobDetail;
    private string sLocality;
    private string sRelatioship;
    private string sOccupation;
    //added by hemangi kambli on 03/10/2007 ----
    private DateTime dtTransStart;
    private DateTime dtTransEnd;
    private string sUserId;
    private string sCentreId;
    private string sProductId;
    private string sClientId;


    public DateTime TransStart
    {
        get { return dtTransStart; }
        set { dtTransStart = value; }
    }

    public DateTime TransEnd
    {
        get { return dtTransEnd; }
        set { dtTransEnd = value; }
    }

    public string UserId
    {
        get { return sUserId; }
        set { sUserId = value; }
    }

    public string CentreId
    {
        get { return sCentreId; }
        set { sCentreId = value; }
    }

    public string ProductId
    {
        get { return sProductId; }
        set { sProductId = value; }
    }

    public string ClientId
    {
        get { return sClientId; }
        set { sClientId = value; }
    }
    ////------------------------------------------------


    public string CaseID
    {
        get { return sCaseID; }
        set { sCaseID = value; }
    }

    public string VerificationID
    {
        get { return sVerificationID; }
        set { sVerificationID = value; }
    }
    public string EmployeeName
    {
        get { return sEmployeeName; }
        set { sEmployeeName = value; }
    }
    public string Address
    {
        get { return sAddress; }
        set { sAddress = value; }
    }
    public string NameOfPersonContated
    {
        get { return sNameOfPersonContacted; }
        set { sNameOfPersonContacted = value; }
    }
    public string RelationshipToEmp
    {
        get { return sRelationshipToEmp; }
        set { sRelationshipToEmp = value; }
    }
    public string TelephoneNo1
    {
        get { return sTelephoneno1; }
        set { sTelephoneno1 = value; }
    }
    public string NumberOfYear
    {
        get { return sNumberOfYear; }
        set { sNumberOfYear = value; }
    }
    public string ResidenceType
    {
        get { return sResidenceType; }
        set { sResidenceType = value; }
    }
    public string LandMark
    {
        get { return sLandmark; }
        set { sLandmark = value; }
    }
    public string Accessbility
    {
        get { return sAccessbility; }
        set { sAccessbility = value; }
    }
    public string FamilyMember
    {
        get { return sFamilyMember; }
        set { sFamilyMember = value; }
    }
    public string PemanentAdd
    {
        get { return spermanentAdd; }
        set { spermanentAdd = value; }
    }
    public string TelephoneNo2
    {
        get { return sTelephone2; }
        set { sTelephone2 = value; }
    }
    public string DetailAbtPreviousJob
    {
        get { return sDetailAbtPreviousJob; }
        set { sDetailAbtPreviousJob = value; }
    }
    public string NeighbourName
    {
        get { return sNeighbourName; }
        set { sNeighbourName = value; }
    }
    public string NeighbourFeedBackOfEmp
    {
        get { return sNeighbourFeedbackOnEmp; }
        set { sNeighbourFeedbackOnEmp = value; }
    }
    public string Remark
    {
        get { return sRemark; }
        set { sRemark = value; }
    }
    public string EmpEcn
    {
        get { return sEmpEcn; }
        set { sEmpEcn = value; }
    }
    public string GapIdentified
    {
        get { return sGapIdentified; }
        set { sGapIdentified = value; }
    }
    public string PeriodOfGap
    {
        get { return sPeriodOfGap; }
        set { sPeriodOfGap = value; }
    }
    public string ReasoinOfGap
    {
        get { return sReasonOfGap; }
        set { sReasonOfGap = value; }
    }
    public string AddressDuringGap
    {
        get { return sAddressDuringGap; }
        set { sAddressDuringGap = value; }
    }
    public string policaVerification
    {
        get { return sPoliceVerification; }
        set { sPoliceVerification = value; }
    }
    public string policaVerificationGap
    {
        get { return spoliceVerificationGap; }
        set { spoliceVerificationGap = value; }
    }
    public string RespondentName
    {
        get { return sRespomdentName; }
        set { sRespomdentName = value; }
    }
    public string RespondentDesignation
    {
        get { return sRespondentDesignation; }
        set { sRespondentDesignation = value; }
    }
    
    public string OrganisationName
    {
        get { return sOrganisationName; }
        set { sOrganisationName = value; }
    }
    public string EmployeeDates
    {
        get { return sEmployeeDates; }
        set { sEmployeeDates = value; }
    }
    public string LastPosition
    {
        get { return sLastposition; }
        set { sLastposition = value; }
    }
    public string ReportingManager
    {
        get { return sReportingManager; }
        set { sReportingManager = value; }
    }
    public string Status
    {
        get { return sStatus; }
        set { sStatus = value; }
    }
    public string SubjectName
    {
        get { return sSubjectName; }
        set { sSubjectName = value; }
    }
    public string DOB
    {
        get { return sDOB; }
        set { sDOB = value; }
    }
   
    public string VerificationName
    {
        get { return sVerificationName; }
        set { sVerificationName = value; }
    }
    public string DatesAttended
    {
        get { return sDatesAttented; }
        set { sDatesAttented = value; }
    }
    public string QualificationGained
    {
        get { return sQualificationGained; }
        set { sQualificationGained = value; }
    }
    public string InstitutionName
    {
        get { return sInstitutionName; }
        set { sInstitutionName = value; }
    }
    public string VerificationDateTime
    {
        get { return sVerificationDateTime; }
        set { sVerificationDateTime = value; }
    }
    public string previosJobDetail
    {
        get { return sPreviousJobDetail; }
        set { sPreviousJobDetail = value; }
    }
    public string Locality
    {
        get { return sLocality; }
        set { sLocality = value; }
    }
    public string Relationship
    {
        get { return sRelatioship; }
        set { sRelatioship = value; }
    }
    public string Occupation
    {
        get { return sOccupation; }
        set { sOccupation = value; }
    }
	public EBC_Verification()
	{
        oCmn = new CCommon();
	}

     public OleDbDataReader GetVerificationDetail(string sCaseId, string sClientId, string sCentreId)
    {
        string sSql = "";
        sSql = "select CD.Case_Id,CRL.Verification_type_id from  CPV_EBC_CASE_DETAILS CD " +
               " INNER JOIN CPV_EBC_VAERIFICATION_TYPE CRL ON CD.Case_ID=CRL.Case_ID " +
               " WHERE CRL.case_id='" + sCaseId + "' " +
               " AND CD.Client_ID='" + sClientId + "'" +
               " AND CD.Centre_Id='" + sCentreId + "'" +
               " AND CD.SEND_DATETIME IS NULL ";

        return OleDbHelper.ExecuteReader(oCmn.ConnectionString, CommandType.Text, sSql);
    }
   

   
    public OleDbDataReader GetVerifierID(string sCaseId )
    {
        string sSql = "";
        sSql = "select FE_ID from CPV_EBC_FE_MAPPING where case_id='" + sCaseId + "' ";
             

        return OleDbHelper.ExecuteReader(oCmn.ConnectionString, CommandType.Text, sSql);
    }

    public string GetVerificationTypeID()
    {
        string sql = " select verification_type_id from CPV_EBC_VAERIFICATION_TYPE where case_id='" + CaseID + "' ";
        string str = (string)OleDbHelper.ExecuteScalar(oCmn.ConnectionString, CommandType.Text, sql);
        return str;
    }

    public string GetVerificationTypeID1(string sCaseID)
    {
        string sql = " select verification_type_id from CPV_EBC_VAERIFICATION_TYPE where case_id='" + sCaseID + "' ";
        string str = (string)OleDbHelper.ExecuteScalar(oCmn.ConnectionString, CommandType.Text, sql);
        return str;
    }
    public OleDbDataReader GetEBCDetail(string sCaseId)
    {
        string sSql = "";
        sSql = "select * from CPV_EBC_VERIFICATION where case_id='" + sCaseId + "' ";
             

        return OleDbHelper.ExecuteReader(oCmn.ConnectionString, CommandType.Text, sSql);
    }
    public OleDbDataReader GetFEName(string sCaseId)
    {
        string sSql = "";
        sSql = "select distinct fullname,FE_ID from fe_vw fv inner join CPV_EBC_FE_MAPPING cifcm on(cifcm.fe_id=fv.emp_id)  where case_id='" + sCaseId + "'  order by fv.fullname";
        return OleDbHelper.ExecuteReader(oCmn.ConnectionString, CommandType.Text, sSql);
    }
    public OleDbDataReader GetCASEDetail(string sCaseId)
    {
        string sSql = "";
        sSql = "SELECT CD.REF_NO," +
               " CONVERT(CHAR(10), cd.CASE_REC_DATETIME,103) + ' ' + " +
               " LTRIM(SUBSTRING(CONVERT( VARCHAR(210),cd.CASE_REC_DATETIME, 22), 10, 5) + " +
               " RIGHT(CONVERT(VARCHAR(20), cd.CASE_REC_DATETIME, 22), 3)) as CASE_REC_DATETIME, " +
               " ISNULL(CD.FIRST_NAME,'') + ' ' + ISNULL(CD.MIDDLE_NAME,'')+ISNULL(CD.LAST_NAME,'') AS NAME, " +
               " ISNULL(CD.ADD_LINE_1,'') + ' ' + ISNULL(CD.ADD_LINE_2,'')+ISNULL(CD.ADD_LINE_3,'') AS Address, EMP_CODE,DOB,CASE_REC_DATETIME" +
               " FROM CPV_EBC_CASE_DETAILS CD  INNER JOIN " +
               " CPV_EBC_VAERIFICATION_TYPE CV ON CD.CASE_ID = CV.CASE_ID " +
               " where CV.case_id='" + sCaseId + "' " ;
               

        return OleDbHelper.ExecuteReader(oCmn.ConnectionString, CommandType.Text, sSql);
    }
    public string InsertEBCVerificationType()
    {
         string sSql = "";
        string sSql1 = "";
        OleDbConnection sqlConn = new OleDbConnection(oCmn.ConnectionString);
        sqlConn.Open();

        OleDbTransaction sqlTrans = sqlConn.BeginTransaction();
        string sRetVal = "";
        try
        {
             string sSqlRead = "";
            OleDbDataReader oledbRead;

            sSqlRead = "SELECT Case_ID,VERIFICATION_TYPE_ID from CPV_EBC_VERIFICATION " +
                       " WHERE Case_ID='" + CaseID + "'";
                       

            oledbRead = OleDbHelper.ExecuteReader(sqlTrans, CommandType.Text, sSqlRead);

          
            OleDbParameter[] ParamVerification = new OleDbParameter[35];
            if (oledbRead.Read() == false)
            {

                sSql = "insert into CPV_EBC_VERIFICATION (case_id,verification_type_id,verification_datetime,Contact_person,Contact_person_designation,Institute_name,Employment_Date,Date_attend,Qulaification_gained,Organization_name,Last_Position_Held,Reporting_Manager,Gap_Identified,Period_Of_Gap,Reason_Of_Gap,Address_Gap,Police_Verification_GAP,Police_Verification,Telephone_No,Year_At_Residence, " +
                     " Residence_Type,Landmark,Accessibility,Family_relation_Ocupation,Relationship,Permanent_Address,Previous_job_Detail,Locality,Neighbour_Name,Neighbour_Feedback,Tel_No2,Remark,CASE_STATUS_ID,ADD_BY,ADD_DATE) values(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)";
                
                ParamVerification[0] = new OleDbParameter("@CaseId", OleDbType.VarChar, 15);
                ParamVerification[0].Value = CaseID;
                ParamVerification[1] = new OleDbParameter("@VerificationTypeID", OleDbType.VarChar, 15);
                ParamVerification[1].Value = GetVerificationTypeID();
                ParamVerification[2] = new OleDbParameter("@VerificationTypeDateTime", OleDbType.VarChar, 50);
                ParamVerification[2].Value = VerificationDateTime;
                ParamVerification[3] = new OleDbParameter("@ContactedPerson", OleDbType.VarChar, 100);
                ParamVerification[3].Value = NameOfPersonContated;
                ParamVerification[4] = new OleDbParameter("@ContactedPersonDesignation", OleDbType.VarChar, 100);
                ParamVerification[4].Value = RespondentDesignation;
                ParamVerification[5] = new OleDbParameter("@InstituteName", OleDbType.VarChar, 100);
                ParamVerification[5].Value = InstitutionName;
                ParamVerification[6] = new OleDbParameter("@EmploymentDate", OleDbType.VarChar, 50);
                ParamVerification[6].Value = EmployeeDates;
                ParamVerification[7] = new OleDbParameter("@DateAttented", OleDbType.VarChar, 50);
                ParamVerification[7].Value = DatesAttended;
                ParamVerification[8] = new OleDbParameter("@QualificationGained", OleDbType.VarChar, 100);
                ParamVerification[8].Value = QualificationGained;
                ParamVerification[9] = new OleDbParameter("@OrganisationName", OleDbType.VarChar, 100);
                ParamVerification[9].Value = OrganisationName;
                ParamVerification[10] = new OleDbParameter("@LastPositionHeld", OleDbType.VarChar, 100);
                ParamVerification[10].Value = LastPosition;
                ParamVerification[11] = new OleDbParameter("@ReportingManager", OleDbType.VarChar, 100);
                ParamVerification[11].Value = ReportingManager;
                ParamVerification[12] = new OleDbParameter("@GapIdentified", OleDbType.VarChar, 50);
                ParamVerification[12].Value = GapIdentified;
                ParamVerification[13] = new OleDbParameter("@PeriodOfGap", OleDbType.VarChar, 50);
                ParamVerification[13].Value = PeriodOfGap;
                ParamVerification[14] = new OleDbParameter("@ResonOfGap", OleDbType.VarChar, 255);
                ParamVerification[14].Value = ReasoinOfGap;
                ParamVerification[15] = new OleDbParameter("@AddressGap", OleDbType.VarChar, 255);
                ParamVerification[15].Value = AddressDuringGap;
                ParamVerification[16] = new OleDbParameter("@PoliceVerificationGap", OleDbType.VarChar, 50);
                ParamVerification[16].Value = policaVerificationGap;
                ParamVerification[17] = new OleDbParameter("@PoliceVerification", OleDbType.VarChar, 50);
                ParamVerification[17].Value = policaVerification;
                ParamVerification[18] = new OleDbParameter("@TelephoneNo1", OleDbType.VarChar, 50);
                ParamVerification[18].Value = TelephoneNo1;
                ParamVerification[19] = new OleDbParameter("@YearAtResidence", OleDbType.VarChar, 50);
                ParamVerification[19].Value = NumberOfYear;
                ParamVerification[20] = new OleDbParameter("@ResidenceType", OleDbType.VarChar, 50);
                ParamVerification[20].Value = ResidenceType;
                ParamVerification[21] = new OleDbParameter("@ResidenceType", OleDbType.VarChar, 100);
                ParamVerification[21].Value = LandMark;
                ParamVerification[22] = new OleDbParameter("@Accessbility", OleDbType.VarChar, 100);
                ParamVerification[22].Value = Accessbility;
                ParamVerification[23] = new OleDbParameter("@FamilyRelationOccupation", OleDbType.VarChar, 255);
                ParamVerification[23].Value = FamilyMember;

                ParamVerification[24] = new OleDbParameter("@Relatioship", OleDbType.VarChar, 100);
                ParamVerification[24].Value = RelationshipToEmp;

                ParamVerification[25] = new OleDbParameter("@PermanentAdd", OleDbType.VarChar, 255);
                ParamVerification[25].Value = PemanentAdd;
                ParamVerification[26] = new OleDbParameter("@PreviousJobDetail", OleDbType.VarChar, 255);
                ParamVerification[26].Value = previosJobDetail;
                ParamVerification[27] = new OleDbParameter("@Localty", OleDbType.VarChar, 100);
                ParamVerification[27].Value = Locality;
                ParamVerification[28] = new OleDbParameter("@NeighbourName", OleDbType.VarChar, 100);
                ParamVerification[28].Value = NeighbourName;
                ParamVerification[29] = new OleDbParameter("@NeighbourFeedBack", OleDbType.VarChar, 255);
                ParamVerification[29].Value = NeighbourFeedBackOfEmp;
                ParamVerification[30] = new OleDbParameter("@TellNo2", OleDbType.VarChar, 50);
                ParamVerification[30].Value = TelephoneNo2;
                ParamVerification[31] = new OleDbParameter("@Remark", OleDbType.VarChar, 750);
                ParamVerification[31].Value = Remark;
                ParamVerification[32] = new OleDbParameter("@Status", OleDbType.VarChar, 15);
                ParamVerification[32].Value = Status;

                ParamVerification[33] = new OleDbParameter("@AddedBy", OleDbType.VarChar, 15);
                ParamVerification[33].Value = HttpContext.Current.Session["UserId"].ToString();

                ParamVerification[34] = new OleDbParameter("@Addedon", OleDbType.DBTimeStamp, 8);
                ParamVerification[34].Value = System.DateTime.Now;
                sRetVal = "Record added successfully.";
            }
            else
            {
                sSql = "update CPV_EBC_VERIFICATION set verification_datetime=?,Contact_person=?,Contact_person_designation=?,Institute_name=?," +
                       "Employment_Date=?,Date_attend=?,Qulaification_gained =?,Organization_name=? ,Last_Position_Held=?,Reporting_Manager=?,Gap_Identified =?," +
                       "Period_Of_Gap=?,Reason_Of_Gap=?,Address_Gap=?,Police_Verification_GAP=?,Police_Verification=?,Telephone_No=?,Year_At_Residence=? ," +
                       "Residence_Type=?,Landmark=?,Accessibility=?,Family_relation_Ocupation=?,Relationship=?,Permanent_Address=?,Previous_job_Detail=?,Locality=?,Neighbour_Name=?,Neighbour_Feedback=?,Tel_No2=?,Remark=? ,CASE_STATUS_ID=?,MODIFY_BY=?,MODIFY_DATE=? " +
                       "where case_id=? and verification_type_id=?";

                ParamVerification[0] = new OleDbParameter("@VerificationTypeDateTime", OleDbType.VarChar, 50);
                ParamVerification[0].Value = VerificationDateTime;
                ParamVerification[1] = new OleDbParameter("@ContactedPerson", OleDbType.VarChar, 100);
                ParamVerification[1].Value = NameOfPersonContated;
                ParamVerification[2] = new OleDbParameter("@ContactedPersonDesignation", OleDbType.VarChar, 100);
                ParamVerification[2].Value = RespondentDesignation;
                ParamVerification[3] = new OleDbParameter("@InstituteName", OleDbType.VarChar, 100);
                ParamVerification[3].Value = InstitutionName;
                ParamVerification[4] = new OleDbParameter("@EmploymentDate", OleDbType.VarChar, 50);
                ParamVerification[4].Value = EmployeeDates;
                ParamVerification[5] = new OleDbParameter("@DateAttented", OleDbType.VarChar, 50);
                ParamVerification[5].Value = DatesAttended;
                ParamVerification[6] = new OleDbParameter("@QualificationGained", OleDbType.VarChar, 100);
                ParamVerification[6].Value = QualificationGained;
                ParamVerification[7] = new OleDbParameter("@OrganisationName", OleDbType.VarChar, 100);
                ParamVerification[7].Value = OrganisationName;
                ParamVerification[8] = new OleDbParameter("@LastPositionHeld", OleDbType.VarChar, 100);
                ParamVerification[8].Value = LastPosition;
                ParamVerification[9] = new OleDbParameter("@ReportingManager", OleDbType.VarChar, 100);
                ParamVerification[9].Value = ReportingManager;
                ParamVerification[10] = new OleDbParameter("@GapIdentified", OleDbType.VarChar, 50);
                ParamVerification[10].Value = GapIdentified;
                ParamVerification[11] = new OleDbParameter("@PeriodOfGap", OleDbType.VarChar, 50);
                ParamVerification[11].Value = PeriodOfGap;
                ParamVerification[12] = new OleDbParameter("@ResonOfGap", OleDbType.VarChar, 255);
                ParamVerification[12].Value = ReasoinOfGap;
                ParamVerification[13] = new OleDbParameter("@AddressGap", OleDbType.VarChar, 255);
                ParamVerification[13].Value = AddressDuringGap;
                ParamVerification[14] = new OleDbParameter("@PoliceVerificationGap", OleDbType.VarChar, 50);
                ParamVerification[14].Value = policaVerificationGap;
                ParamVerification[15] = new OleDbParameter("@PoliceVerification", OleDbType.VarChar, 50);
                ParamVerification[15].Value = policaVerification;
                ParamVerification[16] = new OleDbParameter("@TelephoneNo1", OleDbType.VarChar, 50);
                ParamVerification[16].Value = TelephoneNo1;
                ParamVerification[17] = new OleDbParameter("@YearAtResidence", OleDbType.VarChar, 50);
                ParamVerification[17].Value = NumberOfYear;
                ParamVerification[18] = new OleDbParameter("@ResidenceType", OleDbType.VarChar, 50);
                ParamVerification[18].Value = ResidenceType;
                ParamVerification[19] = new OleDbParameter("@ResidenceType", OleDbType.VarChar, 100);
                ParamVerification[19].Value = LandMark;
                ParamVerification[20] = new OleDbParameter("@Accessbility", OleDbType.VarChar, 100);
                ParamVerification[20].Value = Accessbility;
                ParamVerification[21] = new OleDbParameter("@FamilyRelationOccupation", OleDbType.VarChar, 255);
                ParamVerification[21].Value = FamilyMember;

                ParamVerification[22] = new OleDbParameter("@Relatioship", OleDbType.VarChar, 100);
                ParamVerification[22].Value = RelationshipToEmp;

                ParamVerification[23] = new OleDbParameter("@PermanentAdd", OleDbType.VarChar, 255);
                ParamVerification[23].Value = PemanentAdd;
                ParamVerification[24] = new OleDbParameter("@PreviousJobDetail", OleDbType.VarChar, 255);
                ParamVerification[24].Value = previosJobDetail;
                ParamVerification[25] = new OleDbParameter("@Localty", OleDbType.VarChar, 100);
                ParamVerification[25].Value = Locality;
                ParamVerification[26] = new OleDbParameter("@NeighbourName", OleDbType.VarChar, 100);
                ParamVerification[26].Value = NeighbourName;
                ParamVerification[27] = new OleDbParameter("@NeighbourFeedBack", OleDbType.VarChar, 255);
                ParamVerification[27].Value = NeighbourFeedBackOfEmp;
                ParamVerification[28] = new OleDbParameter("@TellNo2", OleDbType.VarChar, 50);
                ParamVerification[28].Value = TelephoneNo2;
                ParamVerification[29] = new OleDbParameter("@Remark", OleDbType.VarChar, 750);
                ParamVerification[29].Value = Remark;
                ParamVerification[30] = new OleDbParameter("@Status", OleDbType.VarChar, 15);
                ParamVerification[30].Value = Status;

                ParamVerification[31] = new OleDbParameter("@ModifyBy", OleDbType.VarChar, 15);
                ParamVerification[31].Value = HttpContext.Current.Session["UserId"].ToString();

                ParamVerification[32] = new OleDbParameter("@ModifyDate", OleDbType.DBTimeStamp, 8);
                ParamVerification[32].Value = System.DateTime.Now;

                ParamVerification[33] = new OleDbParameter("@CaseId", OleDbType.VarChar, 15);
                ParamVerification[33].Value = CaseID;
                ParamVerification[34] = new OleDbParameter("@VerificationTypeID", OleDbType.VarChar, 15);
                ParamVerification[34].Value = GetVerificationTypeID();
                sRetVal = "Record updated successfully.";
            }
            OleDbHelper.ExecuteNonQuery(sqlTrans, CommandType.Text, sSql, ParamVerification);
            sSql1 = "update CPV_EBC_CASE_DETAILS set CASE_STATUS_ID= " + Status + " Where case_id=" + CaseID + " ";
            OleDbHelper.ExecuteNonQuery(sqlTrans, CommandType.Text, sSql1);

            //Start Insert into CASE_TRANSACTION_LOG -------------------
            sSql = "";
            sSql = "Insert into CASE_TRANSACTION_LOG(CASE_ID,VERIFICATION_TYPE_ID,USER_ID,TRANS_START,TRANS_END," +
                 "CENTRE_ID,PRODUCT_ID,CLIENT_ID) VALUES(?,?,?,?,?,?,?,?)";

            OleDbParameter[] paramTransLog = new OleDbParameter[8];
            paramTransLog[0] = new OleDbParameter("@CaseID", OleDbType.VarChar, 15);
            paramTransLog[0].Value = CaseID.Trim();
            paramTransLog[1] = new OleDbParameter("@VerficationTypeID", OleDbType.VarChar, 15);
            paramTransLog[1].Value = GetVerificationTypeID();
            paramTransLog[2] = new OleDbParameter("@UserId", OleDbType.VarChar, 15);
            paramTransLog[2].Value = UserId;
            paramTransLog[3] = new OleDbParameter("@TransStart", OleDbType.DBTimeStamp);
            paramTransLog[3].Value = TransStart;
            paramTransLog[4] = new OleDbParameter("@TransEnd", OleDbType.DBTimeStamp);
            paramTransLog[4].Value = TransEnd;
            paramTransLog[5] = new OleDbParameter("@CentreId", OleDbType.VarChar, 15);
            paramTransLog[5].Value = CentreId;
            paramTransLog[6] = new OleDbParameter("@ProductId", OleDbType.VarChar, 15);
            paramTransLog[6].Value = ProductId;
            paramTransLog[7] = new OleDbParameter("@ClientId", OleDbType.VarChar, 15);
            paramTransLog[7].Value = ClientId;

            OleDbHelper.ExecuteNonQuery(sqlTrans, CommandType.Text, sSql, paramTransLog);
            //End  Insert into CASE_TRANSACTION_LOG --------------------
            //Update CPV_CC_Case_details with status 'Y' ---------------
            if (IsVerificationComplete(sqlTrans, CaseID) == "true")
            {
                VerificationComplete(sqlTrans,CaseID);
                sRetVal += " Case verification data entry completed.";
            }
            //------------------------------------------------------------

            sqlTrans.Commit();
            sqlConn.Close();
            return sRetVal;
        }
        catch (Exception ex)
        {
            sqlTrans.Rollback();
            sqlConn.Close();
            
            throw new Exception("Error while Inserting/updating Verification entry. " + ex.Message);
        }
    }
    public void InsertFamilyRecord()
    {
        OleDbConnection oledbConn = new OleDbConnection(oCmn.ConnectionString);
        oledbConn.Open();
        OleDbTransaction oledbTrans = oledbConn.BeginTransaction();

        string sSql = "";

        try
        {

            sSql = "insert into CPV_EBC_RELATIONSHIP (case_id,verification_type_id,Relationship,Occupation) values(?,?,?,?)";
            OleDbParameter[] paramRelationship = new OleDbParameter[4];
            paramRelationship[0] = new OleDbParameter("@CaseID", OleDbType.VarChar, 15);
            paramRelationship[0].Value = CaseID;
            paramRelationship[1] = new OleDbParameter("@Qualification", OleDbType.VarChar, 15);
            paramRelationship[1].Value = GetVerificationTypeID();
            paramRelationship[2] = new OleDbParameter("@Specilization", OleDbType.VarChar, 100);
            paramRelationship[2].Value = Relationship;
            paramRelationship[3] = new OleDbParameter("@University", OleDbType.VarChar, 100);
            paramRelationship[3].Value = Occupation;

            OleDbHelper.ExecuteNonQuery(oledbTrans, CommandType.Text, sSql, paramRelationship);
            oledbTrans.Commit();
            oledbConn.Close();
        }
        catch (Exception ex)
        {
            oledbTrans.Rollback();
            oledbConn.Close();
            throw new Exception("An error occurred while inserting the value of Qualification", ex);
        }
    }
    public void DeleteRelatioship()
    {
        OleDbConnection oledbConn = new OleDbConnection(oCmn.ConnectionString);
        oledbConn.Open();
        OleDbTransaction oledbTrans = oledbConn.BeginTransaction();
        string sSql1 = "";
        try
        {
            sSql1 = "delete from CPV_EBC_RELATIONSHIP where case_id='" + CaseID + "' ";
            OleDbHelper.ExecuteNonQuery(oledbTrans, CommandType.Text, sSql1);
            oledbTrans.Commit();
            oledbConn.Close();
        }
        catch (Exception ex)
        {
            oledbTrans.Rollback();
            oledbConn.Close();
            throw new Exception("An error occurred while Deleting the value of Qualification", ex);
        }
    }
    public OleDbDataReader GetRelationship(string sCaseID)
    {
        OleDbConnection oledbConn = new OleDbConnection(oCmn.ConnectionString);
        oledbConn.Open();
        OleDbTransaction oledbTrans = oledbConn.BeginTransaction();
        string sSql = "";

        sSql = "select Relationship,Occupation from CPV_EBC_RELATIONSHIP where case_id='" + sCaseID + "' ";
        return OleDbHelper.ExecuteReader(oCmn.ConnectionString, CommandType.Text, sSql);
    }

    #region IsVerificationComplete
    //Name             :   IsVerificationComplete
    //Create By		   :   Hemangi Kambli
    //Create Date	   :   03 Aug 2007
    //Remarks 		   :   This method is used to check whether verification of case is completed or not.

    public string IsVerificationComplete(OleDbTransaction oledbTrans, string sCaseId)
    {
        string sSql = "";
        OleDbDataReader oledbRead;
        string bComplete = "";
        sSql = " Select case (select count(*) from CPV_EBC_VAERIFICATION_TYPE " +
              " where case_id='" + sCaseId + "') " +
              " when (select count(*) from CPV_EBC_CASE_OUTPUT_VW where case_id='" + sCaseId + "') " +
              " then 'true' else 'false' end as IsComplete";

        oledbRead = OleDbHelper.ExecuteReader(oledbTrans, CommandType.Text, sSql);
        if (oledbRead.Read() == true)
            bComplete = oledbRead["IsComplete"].ToString();

        return bComplete;
    }

    #endregion IsVerificationComplete

    #region VerificationComplete after completing verification IS_CASE_COMPLETE='Y'
    public void VerificationComplete(OleDbTransaction oledbTrans,string sCaseId)
    {
        string sSql = "";
        sSql = "Update CPV_EBC_CASE_DETAILS SET IS_CASE_COMPLETE='Y' WHERE CASE_ID='" + sCaseId + "'";
        OleDbHelper.ExecuteNonQuery(oledbTrans, CommandType.Text, sSql);
    }
    #endregion VerificationComplete
}
