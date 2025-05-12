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
/// Summary description for CRL_REF1
/// </summary>
public class CRL_REF1
{
    private CCommon objCon;
	public CRL_REF1()
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
    private string strResidenceAddressOfApplicant;
    public string ResidenceAddressOfApplicant
    {
        get
        {
            return strResidenceAddressOfApplicant;
        }
        set
        {
            strResidenceAddressOfApplicant = value;
        }
    }
    private string strResidenceAddressasPerApplication;
    public string ResidenceAddressasPerApplication
    {
        get
        {
            return strResidenceAddressasPerApplication;
        }
        set
        {
            strResidenceAddressasPerApplication = value;
        }
    }
    private string strNameOfRefPersonContacted;
    public string NameOfRefPersonContacted
    {
        get
        {
            return strNameOfRefPersonContacted;
        }
        set
        {
            strNameOfRefPersonContacted = value;
        }
    }
    private string strRelationshipOfReferenceWithApplicant;
    public string RelationshipOfReferenceWithApplicant
    {
        get
        {
            return strRelationshipOfReferenceWithApplicant;
        }
        set
        {
            strRelationshipOfReferenceWithApplicant = value;
        }
    }
    private string strApplicantKnowSinceByTheReference;
    public string ApplicantKnowSinceByTheReference
    {
        get
        {
            return strApplicantKnowSinceByTheReference;
        }
        set
        {
            strApplicantKnowSinceByTheReference = value;
        }
    }
    private string strPhoneNoOfReference;
    public string PhoneNoOfReference
    {
        get
        {
            return strPhoneNoOfReference;
        }
        set
        {
            strPhoneNoOfReference = value;
        }
    }
    private string strReferenceResidenceAddressAsPerCall;
    public string ReferenceResidenceAddressAsPerCall
    {
        get
        {
            return strReferenceResidenceAddressAsPerCall;
        }
        set
        {
            strReferenceResidenceAddressAsPerCall = value;
        }
    }
    private string strNumberOfYearsAtResidence;
    public string NumberOfYearsAtResidence
    {
        get
        {
            return strNumberOfYearsAtResidence;
        }
        set
        {
            strNumberOfYearsAtResidence = value;
        }
    }
    private string strOccupationType;
    public string OccupationType
    {
        get
        {
            return strOccupationType;
        }
        set
        {
            strOccupationType = value;
        }
    }
    private string strNameOfEmpNatureOfBusiness;
    public string NameOfEmpNatureOfBusiness
    {
        get
        {
            return strNameOfEmpNatureOfBusiness;
        }
        set
        {
            strNameOfEmpNatureOfBusiness = value;
        }
    }
    private string strDesignationOfTheApplicant;
    public string DesignationOfTheApplicant
    {
        get
        {
            return strDesignationOfTheApplicant;
        }
        set
        {
            strDesignationOfTheApplicant = value;
        }
    }
    private string strMTNLCheck;
    public string MTNLCheck
    {
        get
        {
            return strMTNLCheck;
        }
        set
        {
            strMTNLCheck = value;
        }
    }
    private string strPurpose;
    public string Purpose
    {
        get
        {
            return strPurpose;
        }
        set
        {
            strPurpose = value;
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

    private string strRefContactedConfirmsAppStayGivenAddress;
    public string RefContactedConfirmsAppStayGivenAddress
    {
        get
        {
            return strRefContactedConfirmsAppStayGivenAddress;
        }
        set
        {
            strRefContactedConfirmsAppStayGivenAddress = value;
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
    // properties added by supriya on 7/9/2007
    //------------------------------
    private string strAddedBy;
    public string AddedBy1
    {
        get
        {
            return strAddedBy;
        }
        set
        {
            strAddedBy = value;
        }
    }

    private string strUpdatedBy;
    public string UpdatedBy1
    {
        get
        {
            return strUpdatedBy;
        }
        set
        {
            strUpdatedBy = value;
        }
    }

    private DateTime dtAddedOn;
    public DateTime AddedOn1
    {
        get
        {
            return dtAddedOn;
        }
        set
        {
            dtAddedOn = value;
        }
    }

    private DateTime dtUpdatedOn;
    public DateTime UpdatedOn1
    {
        get
        {
            return dtUpdatedOn;
        }
        set
        {
            dtUpdatedOn = value;
        }
    }
    //--------------------------------------------

    #endregion Properties Declaration

    public string InsertRef()
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
            sqlQuery = " Select case_id,verification_type_id from CPV_RL_VERIFICATION_REF " +
                       " where case_id = '" + CaseID + "'" + " And verification_type_id='" + VerificationTypeID + "'";

            oledbDR = OleDbHelper.ExecuteReader(objCon.ConnectionString, CommandType.Text, sqlQuery);

            OleDbParameter[] oledbParam = new OleDbParameter[22];

            if (oledbDR.Read() == false)
            {
                sql = "Insert into CPV_RL_VERIFICATION_REF (case_id,verification_type_id,Person_Contacted,Relationship," +
                       " Applicant_Know_Since,Phone_number,Residence_Address,Number_Years_Residence,Occupation," +
                       " Emp_and_Business,Designation_applicant,MTNL_Check,Purpose,Rating,Ref_Contacted_Confirms_App_Stay,Address_Different,Area,VERIFICATION_DATETIME,Residence_Address_Application,Unsatisfactory_Reason,ADD_BY,ADD_DATE )  " +
                       " values (?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)";

                oledbParam[0] = new OleDbParameter("@CaseID", OleDbType.VarChar, 15);
                oledbParam[0].Value = CaseID;

                oledbParam[1] = new OleDbParameter("@VerificationTypeID", OleDbType.VarChar, 15);
                oledbParam[1].Value = VerificationTypeID;

                oledbParam[2] = new OleDbParameter("@NameOfRefPersonContacted", OleDbType.VarChar, 100);
                oledbParam[2].Value = NameOfRefPersonContacted;

                oledbParam[3] = new OleDbParameter("@RelationshipOfReferenceWithApplicant", OleDbType.VarChar, 50);
                oledbParam[3].Value = RelationshipOfReferenceWithApplicant;

                oledbParam[4] = new OleDbParameter("@ApplicantKnowSinceByTheReference", OleDbType.VarChar, 50);
                oledbParam[4].Value = ApplicantKnowSinceByTheReference;

                oledbParam[5] = new OleDbParameter("@PhoneNoOfReference", OleDbType.VarChar, 50);
                oledbParam[5].Value = PhoneNoOfReference;

                oledbParam[6] = new OleDbParameter("@ReferenceResidenceAddressAsPerCall", OleDbType.VarChar, 255);
                oledbParam[6].Value = ReferenceResidenceAddressAsPerCall;

                oledbParam[7] = new OleDbParameter("@NumberOfYearsAtResidence", OleDbType.VarChar, 20);
                oledbParam[7].Value = NumberOfYearsAtResidence;

                oledbParam[8] = new OleDbParameter("@OccupationType", OleDbType.VarChar, 100);
                oledbParam[8].Value = OccupationType;

                oledbParam[9] = new OleDbParameter("@NameOfEmpNatureOfBusiness", OleDbType.VarChar, 255);
                oledbParam[9].Value = NameOfEmpNatureOfBusiness;

                oledbParam[10] = new OleDbParameter("@DesignationOfTheApplicant", OleDbType.VarChar, 100);
                oledbParam[10].Value = DesignationOfTheApplicant;

                oledbParam[11] = new OleDbParameter("@MTNLCheck", OleDbType.VarChar, 50);
                oledbParam[11].Value = MTNLCheck;

                oledbParam[12] = new OleDbParameter("@Purpose", OleDbType.VarChar, 255);
                oledbParam[12].Value = Purpose;

                oledbParam[13] = new OleDbParameter("@Rating", OleDbType.VarChar, 50);
                if (Rating == "")
                {
                    oledbParam[13].Value = DBNull.Value;

                }
                else
                {
                    oledbParam[13].Value = Rating;
                }

                oledbParam[14] = new OleDbParameter("@RefContactedConfirmsAppStayGivenAddress", OleDbType.VarChar, 50);
                oledbParam[14].Value = RefContactedConfirmsAppStayGivenAddress;

                oledbParam[15] = new OleDbParameter("@AddressDifferent", OleDbType.VarChar, 50);
                oledbParam[15].Value = AddressDifferent;

                oledbParam[16] = new OleDbParameter("@Area", OleDbType.VarChar, 255);
                oledbParam[16].Value = Area;

                oledbParam[17] = new OleDbParameter("@VerificationDateAndTime", OleDbType.VarChar, 50);
                oledbParam[17].Value = VerificationDateAndTime;

                oledbParam[18] = new OleDbParameter("@ResidenceAddressasPerApplication", OleDbType.VarChar, 255);
                oledbParam[18].Value = ResidenceAddressasPerApplication;

                oledbParam[19] = new OleDbParameter("@UnsatisfactoryReason", OleDbType.VarChar, 255);
                oledbParam[19].Value = UnsatisfactoryReason;

                oledbParam[20] = new OleDbParameter("@AddedBy1", OleDbType.VarChar, 50);
                oledbParam[20].Value = AddedBy1;

                oledbParam[21] = new OleDbParameter("@AddedOn1", OleDbType.DBTimeStamp);
                oledbParam[21].Value = AddedOn1;
              
                msg = "Record Added Successfully";

            }
            else
            {

                sql = "Update CPV_RL_VERIFICATION_REF set Person_Contacted=?,Relationship=?," +
                       " Applicant_Know_Since=?,Phone_number=?,Residence_Address=?,Number_Years_Residence=?,Occupation=?, " +
                       " Emp_and_Business=?,Designation_applicant=?,MTNL_Check=?,Purpose=?,Rating=?,Ref_Contacted_Confirms_App_Stay=?,Address_Different=?,Area=?,VERIFICATION_DATETIME=?,Residence_Address_Application=?,Unsatisfactory_Reason=?,MODIFY_BY=?,MODIFY_DATE=?   " +
                       " where case_id=? and verification_type_id=? ";

 

                oledbParam[0] = new OleDbParameter("@NameOfRefPersonContacted", OleDbType.VarChar, 100);
                oledbParam[0].Value = NameOfRefPersonContacted;

                oledbParam[1] = new OleDbParameter("@RelationshipOfReferenceWithApplicant", OleDbType.VarChar, 50);
                oledbParam[1].Value = RelationshipOfReferenceWithApplicant;

                oledbParam[2] = new OleDbParameter("@ApplicantKnowSinceByTheReference", OleDbType.VarChar, 50);
                oledbParam[2].Value = ApplicantKnowSinceByTheReference;

                oledbParam[3] = new OleDbParameter("@PhoneNoOfReference", OleDbType.VarChar, 50);
                oledbParam[3].Value = PhoneNoOfReference;

                oledbParam[4] = new OleDbParameter("@ReferenceResidenceAddressAsPerCall", OleDbType.VarChar, 255);
                oledbParam[4].Value = ReferenceResidenceAddressAsPerCall;

                oledbParam[5] = new OleDbParameter("@NumberOfYearsAtResidence", OleDbType.VarChar, 20);
                oledbParam[5].Value = NumberOfYearsAtResidence;

                oledbParam[6] = new OleDbParameter("@OccupationType", OleDbType.VarChar, 100);
                oledbParam[6].Value = OccupationType;

                oledbParam[7] = new OleDbParameter("@NameOfEmpNatureOfBusiness", OleDbType.VarChar, 255);
                oledbParam[7].Value = NameOfEmpNatureOfBusiness;

                oledbParam[8] = new OleDbParameter("@DesignationOfTheApplicant", OleDbType.VarChar, 100);
                oledbParam[8].Value = DesignationOfTheApplicant;

                oledbParam[9] = new OleDbParameter("@MTNLCheck", OleDbType.VarChar, 50);
                oledbParam[9].Value = MTNLCheck;

                oledbParam[10] = new OleDbParameter("@Purpose", OleDbType.VarChar, 255);
                oledbParam[10].Value = Purpose;

                oledbParam[11] = new OleDbParameter("@Rating", OleDbType.VarChar, 50);
                if (Rating == "")
                {
                    oledbParam[11].Value = DBNull.Value;

                }
                else
                {
                    oledbParam[11].Value = Rating;
                }

                oledbParam[12] = new OleDbParameter("@RefContactedConfirmsAppStayGivenAddress", OleDbType.VarChar, 50);
                oledbParam[12].Value = RefContactedConfirmsAppStayGivenAddress;

                oledbParam[13] = new OleDbParameter("@AddressDifferent", OleDbType.VarChar, 50);
                oledbParam[13].Value = AddressDifferent;

                oledbParam[14] = new OleDbParameter("@Area", OleDbType.VarChar, 255);
                oledbParam[14].Value = Area;

                oledbParam[15] = new OleDbParameter("@VerificationDateAndTime", OleDbType.VarChar, 50);
                oledbParam[15].Value = VerificationDateAndTime;

                oledbParam[16] = new OleDbParameter("@ResidenceAddressasPerApplication", OleDbType.VarChar, 255);
                oledbParam[16].Value = ResidenceAddressasPerApplication;

                oledbParam[17] = new OleDbParameter("@UnsatisfactoryReason", OleDbType.VarChar, 255);
                oledbParam[17].Value = UnsatisfactoryReason;

                oledbParam[18] = new OleDbParameter("@UpdatedBy1", OleDbType.VarChar, 50);
                oledbParam[18].Value = UpdatedBy1;

                oledbParam[19] = new OleDbParameter("@UpdatedOn1", OleDbType.DBTimeStamp);
                oledbParam[19].Value = UpdatedOn1;

                oledbParam[20] = new OleDbParameter("@CaseID", OleDbType.VarChar, 15);
                oledbParam[20].Value = CaseID;

                oledbParam[21] = new OleDbParameter("@VerificationTypeID", OleDbType.VarChar, 15);
                oledbParam[21].Value = VerificationTypeID;

                msg = "Record Updated Successfully";

                
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
            if (IsVerificationComplete(oledbTrans, CaseID, ClientId, CentreId) == "true")
            {
                VerificationComplete(oledbTrans, CaseID);
                msg += " Case verification data entry completed.";
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
            throw new Exception("Error Found During App_Code/CRl_TelephonicVerification.cs In InsertTelephonicVerification Method" + ex.Message);
        }
    }

    public OleDbDataReader GetRef(string sCaseID, string sVerificationTypeID)
    {
        string sSql = "";


        sSql = "Select Person_Contacted,Relationship," +
               " Applicant_Know_Since,Phone_number,Residence_Address,Number_Years_Residence,Occupation," +
               " Emp_and_Business,Designation_applicant,MTNL_Check,Purpose,Rating,Ref_Contacted_Confirms_App_Stay,Address_Different,Area,VERIFICATION_DATETIME,Residence_Address_Application,Unsatisfactory_Reason   " +
               " from CPV_RL_VERIFICATION_REF  " +
               " where case_id='" + sCaseID + "'" + " and verification_type_id='" + sVerificationTypeID + "'";
        return OleDbHelper.ExecuteReader(objCon.ConnectionString, CommandType.Text, sSql);
    }

   
    public OleDbDataReader GetCaseDetail(string sCaseId)
    {
        string sSql = "";
        sSql = "SELECT (isNull(FIRST_NAME,'')+' '+isnull(MIDDLE_NAME,'')+' '+isnull(LAST_NAME,'')) as FULL_NAME," +
                " REF_NO, CASE_REC_DATETIME,(isNull(RES_ADD_LINE_1,'')+' '+isnull(RES_ADD_LINE_2,'')+' '+isnull(RES_ADD_LINE_3,'')) as Residence_Address " +
                " FROM CPV_RL_CASE_DETAILS WHERE CASE_ID='" + sCaseId + "'";
        return OleDbHelper.ExecuteReader(objCon.ConnectionString, CommandType.Text, sSql);
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

    #region VerificationComplete after completing verification IS_CASE_COMPLETE='Y'
    public void VerificationComplete(OleDbTransaction oledbTrans, string sCaseId)
    {
        string sSql = "";
        sSql = "Update CPV_RL_CASE_DETAILS SET IS_CASE_COMPLETE='Y' WHERE CASE_ID='" + sCaseId + "'";
        OleDbHelper.ExecuteNonQuery(oledbTrans, CommandType.Text, sSql);
    }
    #endregion VerificationComplete
}
