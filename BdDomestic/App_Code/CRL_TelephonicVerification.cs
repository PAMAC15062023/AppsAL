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
/// Summary description for CRL_TelephonicVerification
/// </summary>
public class CRL_TelephonicVerification
{
    private CCommon objCon;
	public CRL_TelephonicVerification()
	{
        objCon = new CCommon();
		//
		// TODO: Add constructor logic here
		//
	}
    #region Properties Declaration
    //added by hemangi kambli on 01/10/2007 ----
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
    //Start of Properties for table CPV_CC_VERI_ATTEMPTS and in form for TELECALL LOG
    private string strCaseID;
    public string CaseID
    {
        get
        {
            return strCaseID;
        }
        set
        {
            strCaseID = value;
        }
    }
    private string strVerificationType;
    public string VerificationType
    {
        get
        {
            return strVerificationType;
        }
        set
        {
            strVerificationType = value;
        }
    }
    private string strVerificationTypeID;
    public string VerificationTypeID
    {
        get
        {
            return strVerificationTypeID;
        }
        set
        {
            strVerificationTypeID = value;
        }
    }
    private string strVerifierID;
    public string VerifierID
    {
        get
        {
            return strVerifierID;
        }
        set
        {
            strVerifierID = value;
        }
    }
    private string attemptDateTime;
    public string AttemptDateTime
    {
        get
        {
            return attemptDateTime;
        }
        set
        {
            attemptDateTime = value;
        }
    }
    private string strRemark;
    public string Remark
    {
        get
        {
            return strRemark;
        }
        set
        {
            strRemark = value;
        }
    }
    private string strTelephoneNo;

    public string TelePhoneNo
    {
        get
        {
            return strTelephoneNo;
        }
        set
        {
            strTelephoneNo = value;
        }
    }
    //End of Properties for table CPV_CC_VERI_ATTEMPTS and in form for TELECALL LOG


    private string strVerificationDateAndTime;
    public string VerificationDateAndTime
    {
        get
        {
            return strVerificationDateAndTime;
        }
        set
        {
            strVerificationDateAndTime = value;
        }
    }

    private string strDate;
    public string Date
    {
        get
        {
            return strDate;
        }
        set
        {
            strDate = value;
        }
    }
    private string strRefNo;
    public string RefNo
    {
        get
        {
            return strRefNo;
        }
        set
        {
            strRefNo = value;
        }
    }
    private string strArea;
    public string Area
    {
        get
        {
            return strArea;
        }
        set
        {
            strArea = value;
        }
    }
    private string strNameOfTheApplicant;
    public string NameOfTheApplicant
    {
        get
        {
            return strNameOfTheApplicant;
        }
        set
        {
            strNameOfTheApplicant = value;
        }
    }
    private string strResidencePhoneNo;
    public string ResidencePhoneNo
    {
        get
        {
            return strResidencePhoneNo;
        }
        set
        {
            strResidencePhoneNo = value;
        }
    }
    private string strResidenceAddressAsPerApplication;
    public string ResidenceAddressAsPerApplication
    {
        get
        {
            return strResidenceAddressAsPerApplication;
        }
        set
        {
            strResidenceAddressAsPerApplication = value;
        }
    }


    private string strPersonContactedResiTeleConfirmsApplicantStaysAddress;
    public string PersonContactedResiTeleConfirmsApplicantStaysAddress
    {
        get
        {
            return strPersonContactedResiTeleConfirmsApplicantStaysAddress;
        }
        set
        {
            strPersonContactedResiTeleConfirmsApplicantStaysAddress = value;
        }
    }
    private string strPersonContactedOffiTeleConfirmsApplicantWorksAddress;
    public string PersonContactedOffiTeleConfirmsApplicantWorksAddress
    {
        get
        {
            return strPersonContactedOffiTeleConfirmsApplicantWorksAddress;
        }
        set
        {
            strPersonContactedOffiTeleConfirmsApplicantWorksAddress = value;
        }
    }

    private string strAddressDifferent;
    public string AddressDifferent 
    {
        get
        {
            return strAddressDifferent;
        }
        set
        {
            strAddressDifferent = value;
        }
    }

    private string strAltPh;
    public string AltPh
    {
        get
        {
            return strAltPh; 
        }
        set
        {
            strAltPh = value;
        }
    }

    private string strrelantion;
    public string relantion
    {
        get
        {
            return strrelantion;
        }
        set
        {
            strrelantion = value;
        }
    }

    private string strPersonContacted;
    public string PersonContacted
    {
        get
        {
            return strPersonContacted;
        }
        set
        {
            strPersonContacted = value;
        }
    }
    private string strRelationshipWithApplicant;
    public string RelationshipWithApplicant
    {
        get
        {
            return strRelationshipWithApplicant;
        }
        set
        {
            strRelationshipWithApplicant = value;
        }
    }
    private string strResidenceAddressAsPerCall;
    public string ResidenceAddressAsPerCall
    {
        get
        {
            return strResidenceAddressAsPerCall;
        }
        set
        {
            strResidenceAddressAsPerCall = value;
        }
    }
    private string strNumberofYearsAtResidence;
    public string NumberofYearsAtResidence
    {
        get
        {
            return strNumberofYearsAtResidence;
        }
        set
        {
            strNumberofYearsAtResidence = value;
        }
    }
    private string strNameOfEmployer;
    public string NameOfEmployer
    {
        get
        {
            return strNameOfEmployer;
        }
        set
        {
            strNameOfEmployer = value;
        }
    }
    private string strPermanentAddress;
    public string PermanentAddress
    {
        get
        {
            return strPermanentAddress;
        }
        set
        {
            strPermanentAddress = value;
        }
    }
    private string strOverallRemarks;
    public string OverallRemarks
    {
        get
        {
            return strOverallRemarks;
        }
        set
        {
            strOverallRemarks = value;
        }
    }
    private string strRating;
    public string Rating
    {
        get
        {
            return strRating;
        }
        set
        {
            strRating = value;
        }
    }

    private string strOwnershipRESIDENCE;
    public string OwnershipRESIDENCE
    {
        get
        {
            return strOwnershipRESIDENCE;
        }
        set
        {
            strOwnershipRESIDENCE = value;
        }
    }

    private string strmake;
    public string make
    {
        get
        {
            return strmake;
        }
        set
        {
            strmake = value;
        }
    }
    private string strloanAmt;
    public string loanAmt
    {
        get
        {
            return strloanAmt;
        }
        set
        {
            strloanAmt = value;
        }
    }
    private string strtenure;
    public string tenure
    {
        get
        {
            return strtenure;
        }
        set
        {
            strtenure = value;
        }
    }
    private string strmonth;
    public string month
    {
        get
        {
            return strmonth;
        }
        set
        {
            strmonth = value;
        }
    }

    private string strStayingSince;
    public string StayingSince
    {
        get
        {
            return strStayingSince;
        }
        set
        {
            strStayingSince = value;
        }
    }
    private string strTelecallersName;
    public string TelecallersName
    {
        get
        {
            return strTelecallersName;
        }
        set
        {
            strTelecallersName = value;
        }
    }
    private string strOfficeTelephoneNumber;
    public string OfficeTelephoneNumber
    {
        get
        {
            return strOfficeTelephoneNumber;
        }
        set
        {
            strOfficeTelephoneNumber = value;
        }
    }
    private string strExactCompanyname;
    public string ExactCompanyname
    {
        get
        {
            return strExactCompanyname;
        }
        set
        {
            strExactCompanyname = value;
        }
    }
    private string strExactCompanyAddress;
    public string ExactCompanyAddress
    {
        get
        {
            return strExactCompanyAddress;
        }
        set
        {
            strExactCompanyAddress = value;
        }
    }
    private string strDesignationOfPersonContacted;
    public string DesignationOfPersonContacted
    {
        get
        {
            return strDesignationOfPersonContacted;
        }
        set
        {
            strDesignationOfPersonContacted = value;
        }
    }
    private string strExactDesignationOfApplicant;
    public string ExactDesignationOfApplicant
    {
        get
        {
            return strExactDesignationOfApplicant;
        }
        set
        {
            strExactDesignationOfApplicant = value;
        }
    }
    private string strNoOfYearsWithTheCompany;
    public string NoOfYearsWithTheCompany
    {
        get
        {
            return strNoOfYearsWithTheCompany;
        }
        set
        {
            strNoOfYearsWithTheCompany = value;
        }
    }
    private string strNatureOfBusiness;
    public string NatureOfBusiness
    {
        get
        {
            return strNatureOfBusiness;
        }
        set
        {
            strNatureOfBusiness = value;
        }
    }
    private string strMainlineBusinessOfTheCompany;
    public string MainlineBusinessOfTheCompany
    {
        get
        {
            return strMainlineBusinessOfTheCompany;
        }
        set
        {
            strMainlineBusinessOfTheCompany = value;
        }
    }
    private string strCategoryOfCompany;
    public string CategoryOfCompany
    {
        get
        {
            return strCategoryOfCompany;
        }
        set
        {
            strCategoryOfCompany = value;
        }
    }
    private string strOfficeBusinessAddressAsPerCall;
    public string OfficeBusinessAddressAsPerCall
    {
        get
        {
            return strOfficeBusinessAddressAsPerCall;
        }
        set
        {
            strOfficeBusinessAddressAsPerCall = value;
        }
    }
    private string strInBusinessSince;
    public string InBusinessSince
    {
        get
        {
            return strInBusinessSince;
        }
        set
        {
            strInBusinessSince = value;
        }
    }
    private string strUnsatisfactoryReason;
    public string UnsatisfactoryReason
    {
        get
        {
            return strUnsatisfactoryReason;
        }
        set
        {
            strUnsatisfactoryReason = value;
        }
    }

    //added by hemangi kambli on 07/09/2007------
    private string sAddedBy;
    private string sModifiedBy;
    private DateTime dtAdded;
    private DateTime dtModify;
    public DateTime AddedOn
    {
        get { return dtAdded; }
        set { dtAdded = value; }
    }

    public string AddedBy
    {
        get { return sAddedBy; }
        set { sAddedBy = value; }
    }

    public DateTime ModifyOn
    {
        get { return dtModify; }
        set { dtModify = value; }
    }
//Naresh 16/06/08 Start
    private string StrStaying_Whom;
public string Staying_Whom
{
    get { return StrStaying_Whom;}
    set { StrStaying_Whom = value; }
}
    private string StrPP_Number;
public string PP_Number
{
    get { return StrPP_Number; }
    set { StrPP_Number = value; }
}
    private string StrAny_Other_Resi_Phone;
public string Any_Other_Resi_Phone
    {
        get { return StrAny_Other_Resi_Phone; }
        set { StrAny_Other_Resi_Phone = value; }
    }
    private string StrApplicant_Availbility;
public string Applicant_Availbility
{
    get { return StrApplicant_Availbility; }
    set { StrApplicant_Availbility = value; }
}
    private string StrDir_Check;
public string Dir_Check
{
    get { return StrDir_Check; }
    set { StrDir_Check = value; }
}
    private string StrName_of_Applicant_Conf;
public string Name_of_Applicant_Conf
{
    get { return StrName_of_Applicant_Conf; }
    set { StrName_of_Applicant_Conf = value; }
}
    private string StrMismatch_Add_Tel;
public string Mismatch_Add_Tel
{
    get { return StrMismatch_Add_Tel; }
    set { StrMismatch_Add_Tel = value; }
}
    private string Str_Years_At_Residence;
    public string Years_At_Residence
    {
        get { return Str_Years_At_Residence; }
        set { Str_Years_At_Residence = value; }
    }
    private string Str_Type_Office;
    public string Type_Office
    {
        get { return Str_Type_Office; }
        set { Str_Type_Office = value;}
    }
    private string Str_Ownership;
    public string Ownership
    {
        get { return Str_Ownership; }
        set { Str_Ownership = value; }
    }

    //Naresh 16/06/08 End

    public string ModifyBy
    {
        get { return sModifiedBy; }
        set { sModifiedBy = value; }
    }
    //---------------------------------------
    #endregion Properties Declaration

    public Int32 InsertTeleCallLog(ArrayList arrTeleCallLog)
    {
        OleDbConnection oledbConn = new OleDbConnection(objCon.ConnectionString);
        oledbConn.Open();
        OleDbTransaction oledbTrans = oledbConn.BeginTransaction();
        OleDbDataReader objoledbDR;
        String sqlSelectQuery = "";
        String sqlQuery = "";
        Int32 returnValue = 0;

        try
        {

            sqlSelectQuery = "Select CASE_ID,VERIFICATION_TYPE_ID from CPV_RL_VERIFICATION_ATTEMPT where CASE_ID='" + CaseID + "'" + "and VERIFICATION_TYPE_ID='" + VerificationTypeID + "'";
            objoledbDR = OleDbHelper.ExecuteReader(objCon.ConnectionString, CommandType.Text, sqlSelectQuery);
            OleDbParameter[] oledbParam = new OleDbParameter[6];

            if (objoledbDR.Read() == true)
            {
                sqlQuery = "Delete from CPV_RL_VERIFICATION_ATTEMPT where CASE_ID='" + CaseID + "'" +
                           " AND VERIFICATION_TYPE_ID='" + VerificationTypeID + "'";
                OleDbHelper.ExecuteNonQuery(oledbTrans, CommandType.Text, sqlQuery);
            }
            foreach (ArrayList item in arrTeleCallLog)
            {
                AttemptDateTime = item[0].ToString();
                Remark = item[1].ToString();
                TelePhoneNo = item[2].ToString();
                VerifierID = item[3].ToString();

                //////////////////////////////Inserting in table CPV_RL_VERIFICATION_ATTEMPT                 

                sqlQuery = "Insert into CPV_RL_VERIFICATION_ATTEMPT (Case_id,Attempt_Datetime,Attempt_Remark,TELEPHONE_NO,Verification_type_id,VERIFIER_ID)" +
                          "Values(?,?,?,?,?,?)";


                oledbParam[0] = new OleDbParameter("@CaseID", OleDbType.VarChar, 15);
                oledbParam[0].Value = CaseID;

                oledbParam[1] = new OleDbParameter("@AttemptDateTime", OleDbType.VarChar);
                oledbParam[1].Value = AttemptDateTime;

                oledbParam[2] = new OleDbParameter("@Remark", OleDbType.VarChar, 255);
                oledbParam[2].Value = Remark;

                oledbParam[3] = new OleDbParameter("@TelePhoneNo", OleDbType.VarChar, 50);
                oledbParam[3].Value = TelePhoneNo;

                oledbParam[4] = new OleDbParameter("@VerificationTypeID", OleDbType.VarChar, 15);
                oledbParam[4].Value = VerificationTypeID;

                oledbParam[5] = new OleDbParameter("@VerifierID", OleDbType.VarChar, 15);
                oledbParam[5].Value = VerifierID;


                OleDbHelper.ExecuteNonQuery(oledbTrans, CommandType.Text, sqlQuery, oledbParam);
                


            }

            oledbTrans.Commit();
            oledbConn.Close();
            return returnValue;
        }
        catch (Exception ex)
        {
            oledbTrans.Rollback();
            oledbConn.Close();
            throw new Exception("Error found During Insertion" + ex.Message);

        }

    }


    public string InsertResiTelephonicVerification()
    {
        OleDbConnection oledbConn = new OleDbConnection(objCon.ConnectionString);
        oledbConn.Open();
        OleDbTransaction oledbTrans = oledbConn.BeginTransaction();
        OleDbDataReader oledbDR;
        string sqlQuery = "";
        string sql = "";
        string msg = "";
        
        try
        {
            sqlQuery = " Select Case_ID,VERIFICATION_TYPE_ID from CPV_RL_VERIFICATION_RVRT " +
                       " where Case_ID = '" + CaseID + "'" + " And VERIFICATION_TYPE_ID='" + VerificationTypeID + "'";

            oledbDR = OleDbHelper.ExecuteReader(objCon.ConnectionString, CommandType.Text, sqlQuery);
//Naresh  Start 14/03/08
            OleDbParameter[] oledbParam = new OleDbParameter[30];
            if (oledbDR.Read() == false)
            {
                sql = "Insert into CPV_RL_VERIFICATION_RVRT (Case_ID,VERIFICATION_TYPE_ID,TEL_NO_TYPE_PHONE,Address_Confirmed," +
                       " PERSON_CONTACTED,Relationship,Address,YEARS_AT_RESIDENCE,Company_name,Permanent_address," +
                       " Verifier_Comments,Verification_status,Staying_Since,VERIFICATION_DATETIME,Area,Unsatisfactory_Reason,ADD_BY,ADD_DATE,Staying_Whom, " +
                       " PP_Number,Any_Other_Resi_Phone,Applicant_Availbility,Dir_Check,Name_of_Applicant_Conf,Mismatch_Add_Tel,Ownership_RESIDENCE,make,loan_Amt,tenure,months)" +
                       " values (?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)";

                oledbParam[0] = new OleDbParameter("@CaseID", OleDbType.VarChar, 15);
                oledbParam[0].Value = CaseID;

                oledbParam[1] = new OleDbParameter("@VerificationTypeID", OleDbType.VarChar, 15);
                oledbParam[1].Value = VerificationTypeID;

                oledbParam[2] = new OleDbParameter("@ResidencePhoneNo", OleDbType.VarChar, 100);
                oledbParam[2].Value = ResidencePhoneNo;

                oledbParam[3] = new OleDbParameter("@PersonContactedResiTeleConfirmsApplicantStaysAddress", OleDbType.VarChar, 50);
                oledbParam[3].Value = PersonContactedResiTeleConfirmsApplicantStaysAddress;

                oledbParam[4] = new OleDbParameter("@PersonContacted", OleDbType.VarChar, 100);
                oledbParam[4].Value = PersonContacted;

                oledbParam[5] = new OleDbParameter("@RelationshipWithApplicant", OleDbType.VarChar, 100);
                oledbParam[5].Value = RelationshipWithApplicant;

                oledbParam[6] = new OleDbParameter("@ResidenceAddressAsPerCall", OleDbType.VarChar, 255);
                oledbParam[6].Value = ResidenceAddressAsPerCall;

                oledbParam[7] = new OleDbParameter("@NumberofYearsAtResidence", OleDbType.VarChar, 20);
                oledbParam[7].Value = NumberofYearsAtResidence;

                oledbParam[8] = new OleDbParameter("@NameOfEmployer", OleDbType.VarChar, 100);
                oledbParam[8].Value = NameOfEmployer;

                oledbParam[9] = new OleDbParameter("@PermanentAddress", OleDbType.VarChar, 255);
                oledbParam[9].Value = PermanentAddress;

                oledbParam[10] = new OleDbParameter("@OverallRemarks", OleDbType.VarChar, 255);
                oledbParam[10].Value = OverallRemarks;

                oledbParam[11] = new OleDbParameter("@Rating", OleDbType.VarChar, 50);
                oledbParam[11].Value = Rating;

                oledbParam[12] = new OleDbParameter("@StayingSince", OleDbType.VarChar, 50);
                oledbParam[12].Value = StayingSince;

                oledbParam[13] = new OleDbParameter("@VerificationDateAndTime", OleDbType.VarChar, 50);
                oledbParam[13].Value = VerificationDateAndTime;

                oledbParam[14] = new OleDbParameter("@Area", OleDbType.VarChar, 50);
                oledbParam[14].Value = Area;

                oledbParam[15] = new OleDbParameter("@UnsatisfactoryReason", OleDbType.VarChar, 255);
                oledbParam[15].Value = UnsatisfactoryReason;

                oledbParam[16] = new OleDbParameter("@AddedBy", OleDbType.VarChar, 15);
                oledbParam[16].Value = AddedBy;
                
                oledbParam[17] = new OleDbParameter("@AddedOn", OleDbType.DBTimeStamp);
                oledbParam[17].Value = AddedOn;

                oledbParam[18] = new OleDbParameter("@Staying_Whom", OleDbType.VarChar,50 );
                oledbParam[18].Value = Staying_Whom;

                oledbParam[19] = new OleDbParameter("@PP_Number", OleDbType.VarChar, 50);
                oledbParam[19].Value = PP_Number;

                oledbParam[20] = new OleDbParameter("@Any_Other_Resi_Phone", OleDbType.VarChar, 50);
                oledbParam[20].Value = Any_Other_Resi_Phone;

                oledbParam[21] = new OleDbParameter("@Applicant_Availbility", OleDbType.VarChar, 50);
                oledbParam[21].Value = Applicant_Availbility;

                oledbParam[22] = new OleDbParameter("@Dir_Check", OleDbType.VarChar, 50);
                oledbParam[22].Value = Dir_Check;

                oledbParam[23] = new OleDbParameter("Name_of_Applicant_Conf", OleDbType.VarChar, 50);
                oledbParam[23].Value = Name_of_Applicant_Conf;

                oledbParam[24] = new OleDbParameter("@Mismatch_Add_Tel", OleDbType.VarChar, 150);
                oledbParam[24].Value = Mismatch_Add_Tel;

                oledbParam[25] = new OleDbParameter("@Ownership_RESIDENCE", OleDbType.VarChar, 150);
                oledbParam[25].Value = OwnershipRESIDENCE;

                oledbParam[26] = new OleDbParameter("@make", OleDbType.VarChar, 150);
                oledbParam[26].Value = make;

                oledbParam[27] = new OleDbParameter("@loan_amt", OleDbType.VarChar, 150);
                oledbParam[27].Value = loanAmt;

                oledbParam[28] = new OleDbParameter("@tenure", OleDbType.VarChar, 150);
                oledbParam[28].Value = tenure; 

                oledbParam[29] = new OleDbParameter("@month", OleDbType.VarChar, 150);
                oledbParam[29].Value = month;   


                //,,,,,
                msg = "Record Added Sucessfully";

               
                       
            }
            else
            {
                sql = "Update CPV_RL_VERIFICATION_RVRT Set TEL_NO_TYPE_PHONE=?,Address_Confirmed=?," +
                      " PERSON_CONTACTED=?,Relationship=?,Address=?,YEARS_AT_RESIDENCE=?,Company_name=?,Permanent_address=?," +
                      " Verifier_Comments=?,Verification_status=?,Staying_Since=?,VERIFICATION_DATETIME=?,Area=?,Unsatisfactory_Reason=?,MODIFY_BY=?,MODIFY_DATE=?,Staying_Whom=?,"+
                      " PP_Number=?,Any_Other_Resi_Phone=?,Applicant_Availbility=?,Dir_Check=?,Name_of_Applicant_Conf=?,Mismatch_Add_Tel=?,Ownership_RESIDENCE=?,make=?,loan_Amt=?,tenure=?,months=? " +
                      " where Case_ID=? and VERIFICATION_TYPE_ID=? ";
                //,Staying_Whom=?
                oledbParam[0] = new OleDbParameter("@ResidencePhoneNo", OleDbType.VarChar, 100);
                oledbParam[0].Value = ResidencePhoneNo;

                oledbParam[1] = new OleDbParameter("@PersonContactedResiTeleConfirmsApplicantStaysAddress", OleDbType.VarChar, 50);
                oledbParam[1].Value = PersonContactedResiTeleConfirmsApplicantStaysAddress;

                oledbParam[2] = new OleDbParameter("@PersonContacted", OleDbType.VarChar, 100);
                oledbParam[2].Value = PersonContacted;

                oledbParam[3] = new OleDbParameter("@RelationshipWithApplicant", OleDbType.VarChar, 100);
                oledbParam[3].Value = RelationshipWithApplicant;

                oledbParam[4] = new OleDbParameter("@ResidenceAddressAsPerCall", OleDbType.VarChar, 255);
                oledbParam[4].Value = ResidenceAddressAsPerCall;

                oledbParam[5] = new OleDbParameter("@NumberofYearsAtResidence", OleDbType.VarChar, 20);
                oledbParam[5].Value = NumberofYearsAtResidence;

                oledbParam[6] = new OleDbParameter("@NameOfEmployer", OleDbType.VarChar, 100);
                oledbParam[6].Value = NameOfEmployer;

                oledbParam[7] = new OleDbParameter("@PermanentAddress", OleDbType.VarChar, 255);
                oledbParam[7].Value = PermanentAddress;

                oledbParam[8] = new OleDbParameter("@OverallRemarks", OleDbType.VarChar, 255);
                oledbParam[8].Value = OverallRemarks;

                oledbParam[9] = new OleDbParameter("@Rating", OleDbType.VarChar, 50);
                oledbParam[9].Value = Rating;

                oledbParam[10] = new OleDbParameter("@StayingSince", OleDbType.VarChar, 50);
                oledbParam[10].Value = StayingSince;

                oledbParam[11] = new OleDbParameter("@VerificationDateAndTime", OleDbType.VarChar, 50);
                oledbParam[11].Value = VerificationDateAndTime;

                oledbParam[12] = new OleDbParameter("@Area", OleDbType.VarChar, 50);
                oledbParam[12].Value = Area;

                oledbParam[13] = new OleDbParameter("@UnsatisfactoryReason", OleDbType.VarChar, 255);
                oledbParam[13].Value = UnsatisfactoryReason;

                oledbParam[14] = new OleDbParameter("@ModifyBy", OleDbType.VarChar, 15);
                oledbParam[14].Value = ModifyBy;

                oledbParam[15] = new OleDbParameter("@ModifyOn", OleDbType.DBTimeStamp);
                oledbParam[15].Value = ModifyOn;

                oledbParam[16] = new OleDbParameter("@Staying_Whom", OleDbType.VarChar, 50);
                oledbParam[16].Value = Staying_Whom;


                oledbParam[17] = new OleDbParameter("@PP_Number", OleDbType.VarChar, 50);
                oledbParam[17].Value = PP_Number;

                oledbParam[18] = new OleDbParameter("@Any_Other_Resi_Phone", OleDbType.VarChar, 50);
                oledbParam[18].Value = Any_Other_Resi_Phone;

                oledbParam[19] = new OleDbParameter("@Applicant_Availbility", OleDbType.VarChar, 50);
                oledbParam[19].Value = Applicant_Availbility;

                oledbParam[20] = new OleDbParameter("@Dir_Check", OleDbType.VarChar, 50);
                oledbParam[20].Value = Dir_Check;

                oledbParam[21] = new OleDbParameter("Name_of_Applicant_Conf", OleDbType.VarChar, 50);
                oledbParam[21].Value = Name_of_Applicant_Conf;

                oledbParam[22] = new OleDbParameter("@Mismatch_Add_Tel", OleDbType.VarChar, 150);
                oledbParam[22].Value = Mismatch_Add_Tel;

                oledbParam[23] = new OleDbParameter("@Ownership_RESIDENCE", OleDbType.VarChar, 150);
                oledbParam[23].Value = OwnershipRESIDENCE;

                oledbParam[24] = new OleDbParameter("@make", OleDbType.VarChar, 150);
                oledbParam[24].Value = make;

                oledbParam[25] = new OleDbParameter("@loan_amt", OleDbType.VarChar, 150);
                oledbParam[25].Value = loanAmt;

                oledbParam[26] = new OleDbParameter("@tenure", OleDbType.VarChar, 150);
                oledbParam[26].Value = tenure;

                oledbParam[27] = new OleDbParameter("@month", OleDbType.VarChar, 150);
                oledbParam[27].Value = month;   

                oledbParam[28] = new OleDbParameter("@CaseID", OleDbType.VarChar, 15);
                oledbParam[28].Value = CaseID;

                oledbParam[29] = new OleDbParameter("@VerificationTypeID", OleDbType.VarChar, 15);
                oledbParam[29].Value = VerificationTypeID;

                msg = "Record Updated Sucessfully";

            }
            OleDbHelper.ExecuteNonQuery(oledbTrans, CommandType.Text, sql, oledbParam);

            //Start Insert into CASE_TRANSACTION_LOG -------------------
            sql = "";
            sql = "Insert into CASE_TRANSACTION_LOG(CASE_ID,VERIFICATION_TYPE_ID,USER_ID,TRANS_START,TRANS_END," +
                 "CENTRE_ID,PRODUCT_ID,CLIENT_ID) VALUES(?,?,?,?,?,?,?,?)";

            OleDbParameter[] paramTransLog = new OleDbParameter[8];
            paramTransLog[0] = new OleDbParameter("@CaseID", OleDbType.VarChar, 15);
            paramTransLog[0].Value = CaseID;
            paramTransLog[1] = new OleDbParameter("@VerficationTypeID", OleDbType.VarChar, 15);
            paramTransLog[1].Value = VerificationTypeID;
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

            OleDbHelper.ExecuteNonQuery(oledbTrans, CommandType.Text, sql, paramTransLog);

            //End  Insert into CASE_TRANSACTION_LOG --------------------
            //Update CPV_CC_Case_details with status 'Y' ---------------
            //if (IsVerificationComplete(oledbTrans, CaseID, ClientId, CentreId) == "true")
            //{
            //    VerificationComplete(oledbTrans, CaseID);
            //    msg += " Case verification data entry completed.";
            //}


            if (VerificationTypeID == "25" || VerificationTypeID == "26" || VerificationTypeID == "27" || VerificationTypeID == "28")
            {
                if (IsQCVerificationComplete(oledbTrans, CaseID, ClientId, CentreId) == "true")
                {
                    QCVerificationComplete(oledbTrans, CaseID);
                    msg += " Case verification data entry completed.";
                }
            }
            else
            {
                if (IsVerificationComplete(oledbTrans, CaseID, ClientId, CentreId) == "true")
                {
                    VerificationComplete(oledbTrans, CaseID);
                    msg += " Case verification data entry completed.";

                }
            }




            /////////////////////////////////////////////////////////////////////////////////////////////

            oledbTrans.Commit();
            oledbConn.Close();
            return msg;
        }
        catch (Exception ex)
        {
            oledbTrans.Rollback();
            oledbConn.Close();
            throw new Exception("ErrorFound During App_Code/CRl_TelephonicVerification.cs In InsertTelephonicVerification Method" + ex.Message);
        }
    }
    public OleDbDataReader GetResiTelephonicVerification(string sCaseId, string sVerificationTypeID)
    {
        string sSql = "";
        sSql = " SELECT TEL_NO_TYPE_PHONE,Address_Confirmed," +
               " PERSON_CONTACTED,Relationship,Address,YEARS_AT_RESIDENCE,Company_name,Permanent_address," +
               " Verifier_Comments,Verification_status,Staying_Since,VERIFICATION_DATETIME,Area,Unsatisfactory_Reason,Staying_Whom,"+
               " PP_Number,Any_Other_Resi_Phone ,Applicant_Availbility,Dir_Check,Name_of_Applicant_Conf,Mismatch_Add_Tel,Ownership_RESIDENCE,make,loan_Amt,tenure,months " +
               " From CPV_RL_VERIFICATION_RVRT where Case_ID='" + sCaseId + "'" + " and VERIFICATION_TYPE_ID='" + sVerificationTypeID + "'";
        return OleDbHelper.ExecuteReader(objCon.ConnectionString, CommandType.Text, sSql);

    }

    public OleDbDataReader GetResiCaseDetail(string sCaseId)
    {
        string sSql = "";
        sSql = "SELECT RES_PHONE,OFF_NAME,(isNull(RES_ADD_LINE_1,'')+' '+isnull(RES_ADD_LINE_2,'')+' '+isnull(RES_ADD_LINE_3,'')) as Residence_Address " +
                "  from CPV_RL_CASE_DETAILS where Case_ID='" + sCaseId + "'";
        return OleDbHelper.ExecuteReader(objCon.ConnectionString, CommandType.Text, sSql);


    }



    public OleDbDataReader GetCaseDetail(string sCaseId)
    {
        string sSql = "";
        sSql = "SELECT (isNull(FIRST_NAME,'')+' '+isnull(MIDDLE_NAME,'')+' '+isnull(LAST_NAME,'')) as FULL_NAME," +
                " REF_NO, CASE_REC_DATETIME " +
                " FROM CPV_RL_CASE_DETAILS WHERE CASE_ID='" + sCaseId + "'";
        return OleDbHelper.ExecuteReader(objCon.ConnectionString, CommandType.Text, sSql);
    }

    public string InsertBusiTelephonicVerification()
    {
        OleDbConnection oledbConn = new OleDbConnection(objCon.ConnectionString);
        oledbConn.Open();
        OleDbTransaction oledbTrans = oledbConn.BeginTransaction();
        OleDbDataReader oledbDR;
        string sqlQuery = "";
        string sql = "";
        string msg = "";
       
        try
        {
            sqlQuery = " Select case_id,verification_type_id from CPV_RL_VERIFICATION_BVBT " +
                       " where Case_ID = '" + CaseID + "'" + " And VERIFICATION_TYPE_ID='" + VerificationTypeID + "'";

            oledbDR = OleDbHelper.ExecuteReader(objCon.ConnectionString, CommandType.Text, sqlQuery);

            OleDbParameter[] oledbParam = new OleDbParameter[30];
            if (oledbDR.Read() == false)
            {
                sql = "Insert into CPV_RL_VERIFICATION_BVBT (Case_ID,VERIFICATION_TYPE_ID," +
                       " Person_Contacted,Designation_contacted_person,Designation,No_year_service,Nature_Business," +
                       " Type_Industry,Type_Office,Office_Address,Remarks,Rating,In_Bussiness_since,PERSON_CONFIRM_ADDRESS," +
                       " Is_address_same,Unsatisfactory_Reason,VERIFICATION_DATETIME,Area,ADD_BY,ADD_DATE,Applicant_Availbility, " +
                       " Dir_Check,YEARS_AT_RESIDENCE,Office_Ownership,telephone_check,Relationship_applicant,make,loan_amt,tenure,months) " +
                       " values (?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)";

                oledbParam[0] = new OleDbParameter("@CaseID", OleDbType.VarChar, 15);
                oledbParam[0].Value = CaseID;

                oledbParam[1] = new OleDbParameter("@VerificationTypeID", OleDbType.VarChar, 15);
                oledbParam[1].Value = VerificationTypeID;

                oledbParam[2] = new OleDbParameter("@PersonContacted", OleDbType.VarChar, 50);
                oledbParam[2].Value = PersonContacted;

                oledbParam[3] = new OleDbParameter("@DesignationOfPersonContacted", OleDbType.VarChar, 100);
                oledbParam[3].Value = DesignationOfPersonContacted;

                oledbParam[4] = new OleDbParameter("@ExactDesignationOfApplicant", OleDbType.VarChar, 100);
                oledbParam[4].Value = ExactDesignationOfApplicant;

                oledbParam[5] = new OleDbParameter("@NoOfYearsWithTheCompany", OleDbType.VarChar, 50);
                oledbParam[5].Value = NoOfYearsWithTheCompany;

                oledbParam[6] = new OleDbParameter("@NatureOfBusiness", OleDbType.VarChar, 100);
                oledbParam[6].Value = NatureOfBusiness;

                oledbParam[7] = new OleDbParameter("@MainlineBusinessOfTheCompany", OleDbType.VarChar, 100);
                oledbParam[7].Value = MainlineBusinessOfTheCompany;

                oledbParam[8] = new OleDbParameter("@CategoryOfCompany", OleDbType.VarChar, 50);
                oledbParam[8].Value = CategoryOfCompany;

                oledbParam[9] = new OleDbParameter("@OfficeBusinessAddressAsPerCall", OleDbType.VarChar, 100);
                oledbParam[9].Value = OfficeBusinessAddressAsPerCall;

                oledbParam[10] = new OleDbParameter("@OverallRemarks", OleDbType.VarChar, 255);
                oledbParam[10].Value = OverallRemarks;

                oledbParam[11] = new OleDbParameter("@Rating", OleDbType.VarChar, 50);
                if (Rating == "")
                {
                    oledbParam[11].Value = DBNull.Value;

                }
                else
                {
                    oledbParam[11].Value = Rating;
                }

                oledbParam[12] = new OleDbParameter("@InBusinessSince", OleDbType.VarChar, 30);
                oledbParam[12].Value = InBusinessSince;

                oledbParam[13] = new OleDbParameter("@PersonContactedOffiTeleConfirmsApplicantWorksAddress", OleDbType.VarChar, 50);
                oledbParam[13].Value = PersonContactedOffiTeleConfirmsApplicantWorksAddress;

                oledbParam[14] = new OleDbParameter("@AddressDifferent", OleDbType.VarChar, 50);
                oledbParam[14].Value = AddressDifferent;

                oledbParam[15] = new OleDbParameter("@UnsatisfactoryReason", OleDbType.VarChar, 255);
                oledbParam[15].Value = UnsatisfactoryReason;

                oledbParam[16] = new OleDbParameter("@VerificationDateAndTime", OleDbType.VarChar, 50);
                oledbParam[16].Value = VerificationDateAndTime;

                oledbParam[17] = new OleDbParameter("@Area", OleDbType.VarChar, 50);
                oledbParam[17].Value = Area;

                oledbParam[18] = new OleDbParameter("@AddedBy", OleDbType.VarChar, 15);
                oledbParam[18].Value = AddedBy;

                oledbParam[19] = new OleDbParameter("@AddedOn", OleDbType.DBTimeStamp);
                oledbParam[19].Value = AddedOn;

                oledbParam[20] = new OleDbParameter("@Applicant_Availbility", OleDbType.VarChar, 50);
                oledbParam[20].Value = Applicant_Availbility;

                oledbParam[21] = new OleDbParameter("Dir_Check", OleDbType.VarChar, 50);
                oledbParam[21].Value = Dir_Check;

                oledbParam[22] = new OleDbParameter("@Years_At_Residence", OleDbType.VarChar, 50);
                oledbParam[22].Value = Years_At_Residence;

                oledbParam[23] = new OleDbParameter("@Ownership", OleDbType.VarChar, 50);
                oledbParam[23].Value = Ownership;

                oledbParam[24] = new OleDbParameter("@telephone_check", OleDbType.VarChar, 50);
                oledbParam[24].Value = AltPh;

                oledbParam[25] = new OleDbParameter("@Relationship_applicant", OleDbType.VarChar, 50);
                oledbParam[25].Value = relantion;

                oledbParam[26] = new OleDbParameter("@make", OleDbType.VarChar, 150);
                oledbParam[26].Value = make;

                oledbParam[27] = new OleDbParameter("@loan_amt", OleDbType.VarChar, 150);
                oledbParam[27].Value = loanAmt;

                oledbParam[28] = new OleDbParameter("@tenure", OleDbType.VarChar, 150);
                oledbParam[28].Value = tenure;

                oledbParam[29] = new OleDbParameter("@month", OleDbType.VarChar, 150);
                oledbParam[29].Value = month;   


                msg = "Record Added Sucessfully";
           


            }
            else
            {

                sql = "Update CPV_RL_VERIFICATION_BVBT Set Person_Contacted=?,Designation_contacted_person=?," +
                      " Designation=?,No_year_service=?,Nature_Business=?,Type_Industry=?,Type_Office=?,Office_Address=?," +
                      " Remarks=?,Rating=?,In_Bussiness_since=?,PERSON_CONFIRM_ADDRESS=?,Is_address_same=?,Unsatisfactory_Reason=?," +
                      " VERIFICATION_DATETIME=?,Area=?,MODIFY_BY=?,MODIFY_DATE=?,Applicant_Availbility=?,Dir_Check=?,YEARS_AT_RESIDENCE=?, " +
                      " Office_Ownership=?,telephone_check=?,Relationship_applicant=?,make=?,loan_amt=?,tenure=?,months=? where Case_ID=? and VERIFICATION_TYPE_ID=? ";


               
                oledbParam[0] = new OleDbParameter("@PersonContacted", OleDbType.VarChar, 50);
                oledbParam[0].Value = PersonContacted;

                oledbParam[1] = new OleDbParameter("@DesignationOfPersonContacted", OleDbType.VarChar, 100);
                oledbParam[1].Value = DesignationOfPersonContacted;

                oledbParam[2] = new OleDbParameter("@ExactDesignationOfApplicant", OleDbType.VarChar, 100);
                oledbParam[2].Value = ExactDesignationOfApplicant;

                oledbParam[3] = new OleDbParameter("@NoOfYearsWithTheCompany", OleDbType.VarChar, 50);
                oledbParam[3].Value = NoOfYearsWithTheCompany;

                oledbParam[4] = new OleDbParameter("@NatureOfBusiness", OleDbType.VarChar, 100);
                oledbParam[4].Value = NatureOfBusiness;

                oledbParam[5] = new OleDbParameter("@MainlineBusinessOfTheCompany", OleDbType.VarChar, 100);
                oledbParam[5].Value = MainlineBusinessOfTheCompany;

                oledbParam[6] = new OleDbParameter("Type_Office", OleDbType.VarChar, 50);
                oledbParam[6].Value = Type_Office;

              //  oledbParam[6] = new OleDbParameter("@CategoryOfCompany", OleDbType.VarChar, 50);
               // oledbParam[6].Value = CategoryOfCompany;

                oledbParam[7] = new OleDbParameter("@OfficeBusinessAddressAsPerCall", OleDbType.VarChar, 100);
                oledbParam[7].Value = OfficeBusinessAddressAsPerCall;

                oledbParam[8] = new OleDbParameter("@OverallRemarks", OleDbType.VarChar, 255);
                oledbParam[8].Value = OverallRemarks;

                oledbParam[9] = new OleDbParameter("@Rating", OleDbType.VarChar, 50);
                if (Rating == "")
                {
                    oledbParam[9].Value = DBNull.Value;

                }
                else
                {
                    oledbParam[9].Value = Rating;
                }

                oledbParam[10] = new OleDbParameter("@InBusinessSince", OleDbType.VarChar, 30);
                oledbParam[10].Value = InBusinessSince;

                oledbParam[11] = new OleDbParameter("@PersonContactedOffiTeleConfirmsApplicantWorksAddress", OleDbType.VarChar, 50);
                oledbParam[11].Value = PersonContactedOffiTeleConfirmsApplicantWorksAddress;

                oledbParam[12] = new OleDbParameter("@AddressDifferent", OleDbType.VarChar, 50);
                oledbParam[12].Value = AddressDifferent;

                oledbParam[13] = new OleDbParameter("@UnsatisfactoryReason", OleDbType.VarChar, 255);
                oledbParam[13].Value = UnsatisfactoryReason;

                oledbParam[14] = new OleDbParameter("@VerificationDateAndTime", OleDbType.VarChar, 50);
                oledbParam[14].Value = VerificationDateAndTime;

                oledbParam[15] = new OleDbParameter("@Area", OleDbType.VarChar, 50);
                oledbParam[15].Value = Area;

                oledbParam[16] = new OleDbParameter("@ModifyBy", OleDbType.VarChar, 15);
                oledbParam[16].Value = ModifyBy;

                oledbParam[17] = new OleDbParameter("@ModifyOn", OleDbType.DBTimeStamp);
                oledbParam[17].Value = ModifyOn;

                oledbParam[18] = new OleDbParameter("@Applicant_Availbility", OleDbType.VarChar, 50);
                oledbParam[18].Value = Applicant_Availbility;

                oledbParam[19] = new OleDbParameter("Dir_Check", OleDbType.VarChar, 50);
                oledbParam[19].Value = Dir_Check;

                oledbParam[20] = new OleDbParameter("@Years_At_Residence", OleDbType.VarChar, 50);
                oledbParam[20].Value = Years_At_Residence;

                oledbParam[21] = new OleDbParameter("@Ownership", OleDbType.VarChar, 50);
                oledbParam[21].Value = Ownership;

                oledbParam[22] = new OleDbParameter("@telephone_check", OleDbType.VarChar, 50);
                oledbParam[22].Value = AltPh;

                oledbParam[23] = new OleDbParameter("@Relationship_applicant", OleDbType.VarChar, 50);
                oledbParam[23].Value = relantion;

                oledbParam[24] = new OleDbParameter("@make", OleDbType.VarChar, 150);
                oledbParam[24].Value = make;

                oledbParam[25] = new OleDbParameter("@loan_amt", OleDbType.VarChar, 150);
                oledbParam[25].Value = loanAmt;

                oledbParam[26] = new OleDbParameter("@tenure", OleDbType.VarChar, 150);
                oledbParam[26].Value = tenure;

                oledbParam[27] = new OleDbParameter("@month", OleDbType.VarChar, 150);
                oledbParam[27].Value = month;   

                oledbParam[28] = new OleDbParameter("@CaseID", OleDbType.VarChar, 15);
                oledbParam[28].Value = CaseID;

                oledbParam[29] = new OleDbParameter("@VerificationTypeID", OleDbType.VarChar, 15);
                oledbParam[29].Value = VerificationTypeID;

                msg = "Record Updated Sucessfully";


            }
            OleDbHelper.ExecuteNonQuery(oledbTrans, CommandType.Text, sql, oledbParam);

            //Start Insert into CASE_TRANSACTION_LOG -------------------
            sql = "";
            sql = "Insert into CASE_TRANSACTION_LOG(CASE_ID,VERIFICATION_TYPE_ID,USER_ID,TRANS_START,TRANS_END," +
                 "CENTRE_ID,PRODUCT_ID,CLIENT_ID) VALUES(?,?,?,?,?,?,?,?)";

            OleDbParameter[] paramTransLog = new OleDbParameter[8];
            paramTransLog[0] = new OleDbParameter("@CaseID", OleDbType.VarChar, 15);
            paramTransLog[0].Value = CaseID;
            paramTransLog[1] = new OleDbParameter("@VerficationTypeID", OleDbType.VarChar, 15);
            paramTransLog[1].Value = VerificationTypeID;
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


            OleDbHelper.ExecuteNonQuery(oledbTrans, CommandType.Text, sql, paramTransLog);

            //End  Insert into CASE_TRANSACTION_LOG --------------------

            //Update CPV_CC_Case_details with status 'Y' ---------------
            //if (IsVerificationComplete(oledbTrans, CaseID, ClientId, CentreId) == "true")
            //{
            //    VerificationComplete(oledbTrans, CaseID);
            //    msg += " Case verification data entry completed.";
            //}

            if (VerificationTypeID == "25" || VerificationTypeID == "26" || VerificationTypeID == "27" || VerificationTypeID == "28")
            {
                if (IsQCVerificationComplete(oledbTrans, CaseID, ClientId, CentreId) == "true")
                {
                    QCVerificationComplete(oledbTrans, CaseID);
                    msg += " Case verification data entry completed.";
                }
            }
            else
            {
                if (IsVerificationComplete(oledbTrans, CaseID, ClientId, CentreId) == "true")
                {
                    VerificationComplete(oledbTrans, CaseID);
                    msg += " Case verification data entry completed.";

                }
            }





            /////////////////////////////////////////////////////////////////////////////////////////////
            oledbTrans.Commit();
            oledbConn.Close();
            return msg;
        }
        catch (Exception ex)
        {
            oledbTrans.Rollback();
            oledbConn.Close();
            throw new Exception("ErrorFound During App_Code/CRl_TelephonicVerification.cs In InsertTelephonicVerification Method" + ex.Message);
        }
    }
    public OleDbDataReader GetBusiTelephonicVerification(string sCaseId, string sVerificationTypeID)
    {
        string sSql = "";
        sSql = "SELECT Type_oF_Phone,Office_Name,Office_Address,Person_Contacted,Designation_contacted_person," +
               " Designation,No_year_service,Nature_Business,Type_Industry,Type_Office,Office_Address," +
               " Remarks ,Rating,In_Bussiness_since,PERSON_CONFIRM_ADDRESS,Is_address_same,Unsatisfactory_Reason,"+
               "Applicant_Availbility,Dir_Check,YEARS_AT_RESIDENCE,Office_Ownership,Type_Office,"+
               "VERIFICATION_DATETIME,Area,telephone_check,Relationship_applicant,make,loan_amt,tenure,months from CPV_RL_VERIFICATION_BVBT where Case_ID='" + sCaseId + "'" + " and VERIFICATION_TYPE_ID='" + sVerificationTypeID + "'";
        return OleDbHelper.ExecuteReader(objCon.ConnectionString, CommandType.Text, sSql);
        

    }

    public OleDbDataReader GetBusiCaseDetail(string sCaseId)
    {
        string sSql = "";
        sSql = "SELECT OFF_PHONE,OFF_NAME,(isNull(OFF_ADD_LINE_1,'')+' '+isnull(OFF_ADD_LINE_2,'')+' '+isnull(OFF_ADD_LINE_3,'')) as Office_Address  " +
                "  from CPV_RL_CASE_DETAILS where Case_ID='" + sCaseId + "'" ;
        return OleDbHelper.ExecuteReader(objCon.ConnectionString, CommandType.Text, sSql);


    }


    public DataSet GetTeleCallLogDetail(string sCaseID, string sVerificationTypeID)
    {
        string sSql = "";

        sSql = "SELECT Attempt_Datetime,Attempt_Remark ,TELEPHONE_NO,VERIFIER_ID from CPV_RL_VERIFICATION_ATTEMPT " +
              " where Case_id='" + sCaseID + "'" + "and Verification_type_id='" + sVerificationTypeID + "'";
        return OleDbHelper.ExecuteDataset(objCon.ConnectionString, CommandType.Text, sSql);
    }

    public DataTable GetTeleCallerName()
    {
        string sSql = "";
        DataTable dt = new DataTable();
        sSql = "Select EMP_ID,FULLNAME from TC_VW ";
        OleDbDataAdapter oledbDa = new OleDbDataAdapter(sSql, objCon.ConnectionString);
        DataSet ds = new DataSet();
        oledbDa.Fill(ds, "TC_VW");
        dt = ds.Tables["TC_VW"];
        return dt;

    }

    public DataTable GetCaseStatus()
    {
        string sSql = "";
    
        DataTable dt = new DataTable();
        sSql = "SELECT [CASE_STATUS_ID], [STATUS_NAME] FROM [CASE_STATUS_MASTER] WHERE ([PRODUCT_ID] =  '" + HttpContext.Current.Session["ProductId"] + "' ) ORDER BY STATUS_CODE";
        OleDbDataAdapter oledbDa = new OleDbDataAdapter(sSql, objCon.ConnectionString);
        DataSet ds = new DataSet();
        oledbDa.Fill(ds, "Status");
        dt = ds.Tables["Status"];
        return dt;

    }

    #region IsVerificationComplete
    //Name             :   IsVerificationComplete
    //Create By		   :   Gargi Srivastava
    //Create Date	   :   12 Nov 2007
    //Remarks 		   :   This method is used to check whether verification of case is completed or not.

    public string IsVerificationComplete(OleDbTransaction oledbTrans, string sCaseId, string sClientId, string sCenterId)
    {
        string sSql = "";
        OleDbDataReader oledbRead;
        string bComplete = "";
        //sSql = " Select * from CPV_RL_CASE_STATUS_NULL " +
        //       " where case_id='" + sCaseId + "' and Client_id='" + sClientId + "'" +
        //       " and Centre_id='" + sCenterId + "'";

        sSql = "Select case (select count(*) from CPV_RL_CASE_VERIFICATIONTYPE " +
               " where case_id='" + sCaseId + "') " +
               " when (select count(*) from CPV_RL_CASE_STATUS_VIEW where case_id='" + sCaseId + "') " +
               " then 'true' else 'false' end as IsComplete";

        oledbRead = OleDbHelper.ExecuteReader(oledbTrans, CommandType.Text, sSql);
        if (oledbRead.Read() == true)
            bComplete = oledbRead["IsComplete"].ToString();

        return bComplete;
    }

    #endregion IsVerificationComplete

    #region IsQCVerificationComplete
    public string IsQCVerificationComplete(OleDbTransaction oledbTrans, string sCaseId, string sClientId, string sCenterId)
    {
        string sSql = "";
        OleDbDataReader oledbRead;
        string bComplete = "";
        sSql = "Select case (select count(*) from CPV_RL_CASE_VERIFICATIONTYPE " +
        " where case_id='" + sCaseId + "') " +
        " when (select count(*) from CPV_RL_CASE_STATUS_VIEW where case_id='" + sCaseId + "' and CASE_STATUS_ID <> '' )" +
        " then 'true' else 'false' end as IsComplete";

        oledbRead = OleDbHelper.ExecuteReader(oledbTrans, CommandType.Text, sSql);
        if (oledbRead.Read() == true)
            bComplete = oledbRead["IsComplete"].ToString();

        return bComplete;
    }
    #endregion IsQCVerificationComplete

    #region VerificationComplete after completing verification IS_CASE_COMPLETE='Y'
    public void VerificationComplete(OleDbTransaction oledbTrans, string sCaseId)
    {
        string sSql = "";
        sSql = "Update CPV_RL_CASE_DETAILS SET IS_CASE_COMPLETE='Y' WHERE CASE_ID='" + sCaseId + "'";
        OleDbHelper.ExecuteNonQuery(oledbTrans, CommandType.Text, sSql);
    }
    #endregion VerificationComplete

    //added by kamal matekar.....for QC...
    #region QCVerificationComplete after completing verification IS_CASE_COMPLETE='Y'
    public void QCVerificationComplete(OleDbTransaction oledbTrans, string sCaseId)
    {
        string sSql = "";
        sSql = "Update CPV_QC_Case_Details SET IS_CASE_COMPLETE='Y' WHERE CASE_ID='" + sCaseId + "'";
        OleDbHelper.ExecuteNonQuery(oledbTrans, CommandType.Text, sSql);
    }
    #endregion QCVerificationComplete



}