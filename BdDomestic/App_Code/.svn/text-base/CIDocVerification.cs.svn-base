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
/// Summary description for CIDocVerification
/// </summary>
public class CIDocVerification
{
    private CCommon oCmn;

    #region Property Declaration
    private string strCaseID;
    private string strCaseStatusId;
    private string strVerificationTypeId;
    private string strApplicantName;
    private string strCDMREFNo;
    private string strDOI;
    private string strNameofCompany;
    private decimal decTotalIncome;
    private string strOverWritingTempring;
    private string strPanCorrect;
    private string strTanCorrect;
    private string strOverallComputationCorrect;
    private string strIncomeCalculationCorrect;
    private string strTaxCalculationCorrect;
    private string strF16TaxPaybleISCorrect;
    private string strSendForVerification;
    private string strSpellMistake;
    private string strOtherVerification;
    private string strNameOfPersonContacted;
    private string strDesignationDepartment;
    private string strApplicantDesignation;
    private string strApplicationDepartment;
    private decimal decApplicantYearService;
    private decimal decApplicantGrossAnnualMonthlyIncome;
    private int iNumberOfEmployeeinOrg;
    private string strTypeOfOrg;
    private string strDocumentConf;
    private string strSealOfOrg;
    private string strSigOfIssAuth;
    private string strStanForOrg;
    private string strDtSSSPSC;
    private string strAmtSSSPSC;
    private string strAppOffCorrect;
    private string strBusinessActivitySeen;
    private string sNoEmployess;
    private string strStock;
    private string strNameBoard;
    private string strFERemarks;

    private string strDate1;
    private string strTime1;
    private string strRemarks1;
    private string strStatus;
    private string strFEName;
    private string strSupName;
    private string strVeriDate;
    private string strTeleremark;
    private string strVerifierID;
    private string strTellNO;
    private string strTellRemark;
    private string strAtemptDateTime;
    private string strSalary;
   
    public string CaseID
    {
        get { return strCaseID; }
        set { strCaseID = value; }
    }

    public string CaseStatusID
    {
        get { return strCaseStatusId; }
        set { strCaseStatusId = value; }
    }

    public string VerificationTypeId
    {
        get { return strVerificationTypeId; }
        set { strVerificationTypeId = value; }
    }

    public string ApplicantName
    {
        get { return strApplicantName; }
        set { strApplicantName = value; }
    }
    public string CDMREFNo
    {
        get { return strCDMREFNo; }
        set { strCDMREFNo = value; }
    }

    public string DOI
    {
        get { return strDOI; }
        set { strDOI = value; }
    }
    public string NameofCompany
    {
        get { return strNameofCompany; }
        set { strNameofCompany = value; }
    }
    public decimal TotalIncome
    {
        get { return decTotalIncome; }
        set { decTotalIncome = value; }
    }
    public string OverWritingTempring
    {
        get { return strOverWritingTempring; }
        set { strOverWritingTempring = value; }
    }
    public string PanCorrect
    {
        get { return strPanCorrect; }
        set { strPanCorrect = value; }
    }
    public string TanCorrect
    {
        get { return strTanCorrect; }
        set { strTanCorrect = value; }
    }
    public string IncomeCalculationCorrect
    {
        get { return strIncomeCalculationCorrect; }
        set { strIncomeCalculationCorrect = value; }
    }
    public string TaxCalculationCorrect
    {
        get { return strTaxCalculationCorrect; }
        set { strTaxCalculationCorrect = value; }
    }

    public string F16PaybleISCorrect
    {
        get { return strF16TaxPaybleISCorrect; }
        set { strF16TaxPaybleISCorrect = value; }
    }
    public string OkSendForVerification
    {
        get { return strSendForVerification; }
        set { strSendForVerification = value; }
    }
    public string SpellMistake
    {
        get { return strSpellMistake; }
        set { strSpellMistake = value; }
    }
    public string OtherVerification
    {
        get { return strOtherVerification; }
        set { strOtherVerification = value; }
    }
    public string NameOfPersonContacted
    {
        get { return strNameOfPersonContacted; }
        set { strNameOfPersonContacted = value; }
    }
    public string Cont_DesignationDepartment
    {
        get { return strDesignationDepartment; }
        set { strDesignationDepartment = value; }
     }

    public string ApplicantDesignation
    {
        get { return strApplicantDesignation; }
        set { strApplicantDesignation = value; }
    }
    public string ApplicationDepartment
    {
        get { return strApplicationDepartment; }
        set { strApplicationDepartment = value; }
    }
    public decimal ApplicantYearService
    {
        get { return decApplicantYearService; }
        set { decApplicantYearService = value; }
    }
    public decimal ApplicantGrossAnnualMonthlyIncome
    {
        get { return decApplicantGrossAnnualMonthlyIncome; }
        set { decApplicantGrossAnnualMonthlyIncome = value; }
    }
    public int NumberOfEmployeeinOrg
    {
        get { return iNumberOfEmployeeinOrg; }
        set { iNumberOfEmployeeinOrg = value; }
    }

    public string TypeOfOrg
    {
        get { return strTypeOfOrg; }
        set { strTypeOfOrg = value; }
    }
    public string DocumentConf
    {
        get { return strDocumentConf; }
        set { strDocumentConf = value; }
    }
    public string SealOfOrg
    {
        get { return strSealOfOrg; }
        set { strSealOfOrg = value; }
    }

    public string SigOfIssAuth
    {
        get { return strSigOfIssAuth; }
        set { strSigOfIssAuth = value; }
    }
    public string StanForOrg
    {
        get { return strStanForOrg; }
        set { strStanForOrg = value; }
    }
    public string DtSSSPSC
    {
        get { return strDtSSSPSC; }
        set { strDtSSSPSC = value; }
    }
    public string AmtSSSPSC
    {
        get { return strAmtSSSPSC; }
        set { strAmtSSSPSC = value; }
    }
    public string AppOffCorrect
    {
        get { return strAppOffCorrect; }
        set { strAppOffCorrect = value; }
    }
    public string BusinessActivitySeen
    {
        get { return strBusinessActivitySeen; }
        set { strBusinessActivitySeen = value; }
    }
    public string NoEmployess
    {
        get { return sNoEmployess; }
        set { sNoEmployess = value; }
    }
    public string Stock
    {
        get { return strStock; }
        set { strStock = value; }
    }

    public string NameBoard
    {
        get { return strNameBoard; }
        set { strNameBoard = value; }
    }
    public string FERemarks
    {
        get { return strFERemarks; }
        set { strFERemarks = value; }
    }
    public string Date1
    {
        get { return strDate1; }
        set { strDate1 = value; }
    }
    public string Time1
    {
        get { return strTime1; }
        set { strTime1 = value; }
    }
    public string Remarks1
    {
        get { return strRemarks1; }
        set { strRemarks1 = value; }
    }
    public string Status
    {
        get { return strStatus; }
        set { strStatus = value; }
    }
    public string FEName
    {
        get { return strFEName; }
        set { strFEName = value; }
    }
    public string SupName
    {
        get { return strSupName; }
        set { strSupName = value; }
    }
    public string VeriDate
    {
        get { return strVeriDate; }
        set { strVeriDate = value; }
    }
    
    public string OverallComputationCorrect
    {
        get { return strOverallComputationCorrect; }
        set { strOverallComputationCorrect = value; }
    }
    public string TeleRemarks
    {
        get { return strTeleremark; }
        set { strTeleremark = value; }
    }

    public string VerifierID
    {
        get { return strVerifierID ;}
        set { strVerifierID = value ;}
    }
    public string TellNo
    {
        get { return strTellNO; }
        set { strTellNO = value; }
    }
    public string TellPhoneRemark
    {
        get { return strTellRemark; }
        set { strTellRemark = value; }
    }
    public string AttempDateTime
    {
        get { return strAtemptDateTime; }
        set { strAtemptDateTime = value; }
    }
    public string strIsAcctCorrect;
    public string IsAcctCorrect
    {
        get { return strIsAcctCorrect; }
        set { strIsAcctCorrect = value; }
    }
    public string Salary
    {
        get { return strSalary; }
        set { strSalary = value; }
    }
    
    //added by hemangi kambli on 17/09/2007------
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

    public string ModifyBy
    {
        get { return sModifiedBy; }
        set { sModifiedBy = value; }
    }
    //---------------------------------------
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
    #endregion Property Declaration

    public CIDocVerification()
	{
        oCmn = new CCommon();
		
	}
   
    #region GetVerificationDetail()
    //Name              :   GetVerificationDetail
    //Create By			:	Hemangi Kambli
    //Create Date		:	25th May,2007

    public OleDbDataReader GetVerificationDetail(string sCaseId, string sVerifyType, string sClientId, string sCentreId)
    {
        string sSql = "";
        sSql = "select CD.Case_Id,CIDOC.Verification_type_id from  CPV_IDOC_CASE_DETAILS CD " +
               " INNER JOIN CPV_IDOC_VERIFICATION_TYPE CIDOC ON CD.Case_ID=CIDOC.Case_ID " +
               " WHERE CIDOC.case_id='" + sCaseId + "' " +
               " And CIDOC.verification_type_id='" + sVerifyType + "'" +
               " AND CD.Client_ID='" + sClientId + "'" +
               " AND CD.Centre_Id='" + sCentreId + "'" +
               " AND CD.SEND_DATETIME IS NULL ";

        return OleDbHelper.ExecuteReader(oCmn.ConnectionString, CommandType.Text, sSql);
    }
    #endregion GetVerificationDetail()

    # region GetIDOCsCaseDetail()
    //Name              :   GetIDOCsCaseDetail
    //Create By			:	Hemangi Kambli
    //Create Date		:	25th May,2007
    //Remarks 		    :	This return records of particular caseId.

    public OleDbDataReader GetIDOCsCaseDetail(string sCaseId)
    {
        string sSql = "";
        sSql = "select ISNULL(TITLE,'')+' ' +ISNULL(FIRST_NAME,'')+' ' +ISNULL(MIDDLE_NAME,'')+ ' ' +ISNULL(LAST_NAME,'') AS [FULL NAME], " +
             " REF_NO,CASE_REC_DATETIME AS RECD_DATE,BANK_NAME,BANK_ADDRESS,BANK_PIN,BANK_CITY FROM CPV_IDOC_CASE_DETAILS " +
             " WHERE CASE_ID='" + sCaseId + "'";
        return OleDbHelper.ExecuteReader(oCmn.ConnectionString, CommandType.Text, sSql);
    }

    #endregion GetIDOCsCaseDetail()

    # region GetFEName()
    //Name              :   GetFEName
    //Create By			:	Hemangi Kambli
    //Create Date		:	1st June,2007
    
    public OleDbDataReader GetFEName(string sCaseId, string sVeriTypeId)
    {
        string sSql = "";
        sSql = "select distinct fullname,date_time, emp_id from fe_vw fv inner join CPV_IDOC_FE_CASE_MAPPING cifcm on(cifcm.fe_id=fv.emp_id)  where case_id='" + sCaseId + "' and Verification_Type_id='" + sVeriTypeId + "' order by fv.fullname";
        return OleDbHelper.ExecuteReader(oCmn.ConnectionString, CommandType.Text, sSql);
    }

    #endregion GetFEName()


    #region GetIDOCsCaseVerificationDetail()
    public OleDbDataReader GetIDOCsCaseVerificationDetail(string sCaseId,string sVerifyTypeId)
    {
        string sSql = "";
        sSql = "SELECT Person_contacted,Cont_Designation_dept,ACCOUNT_CORRECT,DOCUMENT_AS_PER_STANDARD, "+
               " AMOUNT_ON_DOC,FE_REMARK,FE_VISIT_DATE,CASE_STATUS_ID FROM CPV_IDOC_VERIFICATION " +
               " WHERE CASE_ID='" + sCaseId + "' AND VERIFICATION_TYPE_ID='" + sVerifyTypeId + "'";
                     
        return OleDbHelper.ExecuteReader(oCmn.ConnectionString, CommandType.Text, sSql);
    }
    #endregion GetIDOCsCaseVerificationDetail()

    #region InsertIDocForm16()
    public string InsertIDocForm16()
    {
        string sSql = "";
        string sSql1 = "";
        string sRetVal = "";
        OleDbConnection sqlConn = new OleDbConnection(oCmn.ConnectionString);
        sqlConn.Open();

        OleDbTransaction sqlTrans = sqlConn.BeginTransaction();
        try
        {
            sSql = "insert into cpv_idoc_verification(case_id,TOTAL_INCOME,Overwriting,Pan_correct,Tan_correcT,computation_correct,Calculation_correct,Tax_cal_correct,Tax_payble_correct,OK_field_verification,IS_spelling_mistake,Other_observation,Person_contacted,Cont_Designation_dept,APP_DESIGNATION,APP_DEPARTMENT,APP_YEAR_IN_SERVICE,MONTH_INCOME,NO_of_Employee,TYPE_OF_INDUSTRY,ORGANIZATION_SEAL,AUTHORITY_SIGNATURE,DOCUMENT_AS_PER_STANDARD,DATE_ON_DOC,AMOUNT_ON_DOC,APP_ADDRESS_CORRECT,BUSSINESS_ACTIVITY_SEEN,STOCK_SIGHTED,NO_OF_EMP_SEEN,NAME_BOARD_SEEN,FE_REMARK,TELE_REMARK,VERIFICATION_TYPE_ID,FE_VISIT_DATE,CASE_STATUS_ID,Gross_salary_Momthly_Annual_Income,ADD_BY,ADD_DATE) values (?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?) ";
            
            OleDbParameter[] ParamVerification = new OleDbParameter[38];

            ParamVerification[0] = new OleDbParameter("@CaseId", OleDbType.VarChar, 15);
            ParamVerification[0].Value = CaseID;
            ParamVerification[1] = new OleDbParameter("@TOTAL_INCOME", OleDbType.Decimal, 9);
            ParamVerification[1].Value = TotalIncome;
            ParamVerification[2] = new OleDbParameter("@Overwriting", OleDbType.VarChar, 10);
            ParamVerification[2].Value = OverWritingTempring;
            ParamVerification[3] = new OleDbParameter("@Pan_correct", OleDbType.VarChar, 10);
            ParamVerification[3].Value = PanCorrect;
            ParamVerification[4] = new OleDbParameter("@Tan_correct", OleDbType.VarChar, 10);
            ParamVerification[4].Value = TanCorrect;
            ParamVerification[5] = new OleDbParameter("@computation_correct", OleDbType.VarChar, 10);
            ParamVerification[5].Value = OverallComputationCorrect;
            ParamVerification[6] = new OleDbParameter("@Calculation_correct", OleDbType.VarChar, 10);
            ParamVerification[6].Value = IncomeCalculationCorrect;
            ParamVerification[7] = new OleDbParameter("@Tax_cal_correct", OleDbType.VarChar, 10);
            ParamVerification[7].Value = TaxCalculationCorrect;
            ParamVerification[8] = new OleDbParameter("@Tax_payble_correct", OleDbType.VarChar, 10);
            ParamVerification[8].Value = F16PaybleISCorrect;
            ParamVerification[9] = new OleDbParameter("@OK_field_verification", OleDbType.VarChar, 10);
            ParamVerification[9].Value = OkSendForVerification;
            ParamVerification[10] = new OleDbParameter("@IS_spelling_mistake", OleDbType.VarChar, 10);
            ParamVerification[10].Value = SpellMistake;
            ParamVerification[11] = new OleDbParameter("@Other_observation", OleDbType.VarChar, 255);
            ParamVerification[11].Value = OtherVerification;
            ParamVerification[12] = new OleDbParameter("@Person_contacted", OleDbType.VarChar, 100);
            ParamVerification[12].Value = NameOfPersonContacted;
            ParamVerification[13] = new OleDbParameter("@Cont_Designation_dept", OleDbType.VarChar, 100);
            ParamVerification[13].Value = Cont_DesignationDepartment;
            ParamVerification[14] = new OleDbParameter("@APP_DESIGNATION", OleDbType.VarChar, 100);
            ParamVerification[14].Value = ApplicantDesignation;
            ParamVerification[15] = new OleDbParameter("@APP_DEPARTMENT", OleDbType.VarChar, 100);
            ParamVerification[15].Value = ApplicationDepartment;
            ParamVerification[16] = new OleDbParameter("@APP_YEAR_IN_SERVICE", OleDbType.Decimal, 9);
            ParamVerification[16].Value = ApplicantYearService;
            ParamVerification[17] = new OleDbParameter("@MONTH_INCOME", OleDbType.Decimal, 9);
            ParamVerification[17].Value = ApplicantGrossAnnualMonthlyIncome;
            ParamVerification[18] = new OleDbParameter("@NO_of_Employee", OleDbType.Numeric, 9);
            ParamVerification[18].Value = NumberOfEmployeeinOrg;
            ParamVerification[19] = new OleDbParameter("@TYPE_OF_INDUSTRY", OleDbType.VarChar, 100);
            ParamVerification[19].Value = TypeOfOrg;
            ParamVerification[20] = new OleDbParameter("@ORGANIZATION_SEAL", OleDbType.VarChar, 15);
            ParamVerification[20].Value = SealOfOrg;
            ParamVerification[21] = new OleDbParameter("@AUTHORITY_SIGNATURE", OleDbType.VarChar, 15);
            ParamVerification[21].Value = SigOfIssAuth;
            ParamVerification[22] = new OleDbParameter("@DOCUMENT_AS_PER_STANDARD", OleDbType.VarChar, 15);
            ParamVerification[22].Value = StanForOrg;
            ParamVerification[23] = new OleDbParameter("@DATE_ON_DOC", OleDbType.VarChar, 15);
            ParamVerification[23].Value = DtSSSPSC;
            ParamVerification[24] = new OleDbParameter("@AMOUNT_ON_DOC", OleDbType.VarChar, 15);
            ParamVerification[24].Value = AmtSSSPSC;
            ParamVerification[25] = new OleDbParameter("@APP_ADDRESS_CORRECT", OleDbType.VarChar, 15);
            ParamVerification[25].Value = AppOffCorrect;
            ParamVerification[26] = new OleDbParameter("@BUSSINESS_ACTIVITY_SEEN", OleDbType.VarChar, 10);
            ParamVerification[26].Value = BusinessActivitySeen;
            ParamVerification[27] = new OleDbParameter("@STOCK_SIGHTED", OleDbType.VarChar, 255);
            ParamVerification[27].Value = Stock;
            ParamVerification[28] = new OleDbParameter("@NO_OF_EMP_SEEN", OleDbType.VarChar, 10);
            ParamVerification[28].Value = NoEmployess;
            ParamVerification[29] = new OleDbParameter("@NAME_BOARD_SEEN", OleDbType.VarChar, 10);
            ParamVerification[29].Value = NameBoard;
            ParamVerification[30] = new OleDbParameter("@FE_REMARK", OleDbType.VarChar, 600);
            ParamVerification[30].Value = FERemarks;
            ParamVerification[31] = new OleDbParameter("@TELE_REMARK", OleDbType.VarChar, 255);
            ParamVerification[31].Value = TeleRemarks;
            ParamVerification[32] = new OleDbParameter("@verification_type_id", OleDbType.VarChar, 255);
            ParamVerification[32].Value = VerificationTypeId;
            ParamVerification[33] = new OleDbParameter("@FE_VISIT_DATE", OleDbType.VarChar, 11);
            ParamVerification[33].Value = VeriDate;
            ParamVerification[34] = new OleDbParameter("@CASE_STATUS_ID", OleDbType.VarChar, 15);
            ParamVerification[34].Value = CaseStatusID;
            ParamVerification[35] = new OleDbParameter("@GrosssSalary", OleDbType.VarChar, 50);
            ParamVerification[35].Value = Salary;
            ParamVerification[36] = new OleDbParameter("@AddedBy", OleDbType.VarChar, 15);
            ParamVerification[36].Value = AddedBy;
            ParamVerification[37] = new OleDbParameter("@AddedOn", OleDbType.DBTimeStamp);
            ParamVerification[37].Value = AddedOn;

            OleDbHelper.ExecuteNonQuery(sqlTrans, CommandType.Text, sSql, ParamVerification);

            //Start Insert into CASE_TRANSACTION_LOG -------------------
            sSql = "";
            sSql = "Insert into CASE_TRANSACTION_LOG(CASE_ID,VERIFICATION_TYPE_ID,USER_ID,TRANS_START,TRANS_END," +
                 "CENTRE_ID,PRODUCT_ID,CLIENT_ID) VALUES(?,?,?,?,?,?,?,?)";

            OleDbParameter[] paramTransLog = new OleDbParameter[8];
            paramTransLog[0] = new OleDbParameter("@CaseID", OleDbType.VarChar, 15);
            paramTransLog[0].Value = CaseID;
            paramTransLog[1] = new OleDbParameter("@VerficationTypeID", OleDbType.VarChar, 15);
            paramTransLog[1].Value = VerificationTypeId;
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

            if (IsVerificationComplete(sqlTrans, CaseID) == "true")
            {
                VerificationComplete(sqlTrans, CaseID);
                sRetVal += " Case verification data entry completed.";
            }
            /////
            //End  Insert into CASE_TRANSACTION_LOG --------------------
            sqlTrans.Commit();
            sqlConn.Close();
        }
        catch (Exception ex)
        {
            sqlTrans.Rollback();
            sqlConn.Close();
            throw new Exception("An error occurred while executing the insert string", ex);
 
        }
        return sRetVal;
    }
    #endregion InsertIDocForm16()

    #region InsertTelelog()
    public void InsertTeleLog()
    {
        string sSql1 = "";
        OleDbConnection sqlConn = new OleDbConnection(oCmn.ConnectionString);
        sqlConn.Open();
        string sSql = "";
        //sSql = "select verifier_id from CPV_IDOC_VERI_ATTEMPTS where case_id=" + CaseID;
        //string sVerifierID = OleDbHelper.ExecuteScalar(sqlConn, CommandType.Text, sSql).ToString();
        OleDbTransaction sqlTrans = sqlConn.BeginTransaction();
        try
        {
            sSql1 = "insert into CPV_IDOC_VERI_ATTEMPTS (Case_id,ATTEMPT_DATE_TIME,TELEPHONE_NO,REMARK,VERIFICATION_TYPE_ID)Values(?,?,?,?,?)";
            OleDbParameter[] ParamAttempt = new OleDbParameter[5];
            ParamAttempt[0] = new OleDbParameter("@CaseId", OleDbType.VarChar, 15);
            ParamAttempt[0].Value = CaseID;
           
            ParamAttempt[1] = new OleDbParameter("@ATTEMPT_DATE_TIME", OleDbType.VarChar);
            ParamAttempt[1].Value = AttempDateTime;
            ParamAttempt[2] = new OleDbParameter("@TELEPHONE_NO", OleDbType.VarChar, 50);
            ParamAttempt[2].Value = TellNo;
            ParamAttempt[3] = new OleDbParameter("@REMARK", OleDbType.VarChar, 255);
            ParamAttempt[3].Value = TellPhoneRemark;

            ParamAttempt[4] = new OleDbParameter("@VerificationTypeID", OleDbType.VarChar, 255);
            ParamAttempt[4].Value = VerificationTypeId;
            OleDbHelper.ExecuteNonQuery(sqlTrans, CommandType.Text, sSql1, ParamAttempt);
            sqlTrans.Commit();
            sqlConn.Close();
        }
        catch (Exception ex)
        {
            sqlTrans.Rollback();
            sqlConn.Close();
            throw new Exception("An error occurred while executing the insert string", ex);

        }

    }
    #endregion InsertTelelog()

    #region InsertUpdateBankStatement()
    public string InsertUpdateBankStatement()
    {
        OleDbConnection oledbConn = new OleDbConnection(oCmn.ConnectionString);
        oledbConn.Open();
        OleDbTransaction oledbTrans = oledbConn.BeginTransaction();
        string sRetVal = "";
        try
        {
            string sSql = "";
            string sSqlRead = "";
            OleDbDataReader oledbRead;
            sSqlRead = "SELECT CASE_ID FROM CPV_IDOC_VERIFICATION " +
                       " WHERE CASE_ID='" + CaseID + "'" +
                       " AND VERIFICATION_TYPE_ID='" + VerificationTypeId + "'";
            oledbRead= OleDbHelper.ExecuteReader(oledbTrans, CommandType.Text, sSqlRead);

            OleDbParameter[] paramBankStat = new OleDbParameter[12];
            if (oledbRead.Read() == false)
            {
                sSql = "INSERT INTO CPV_IDOC_VERIFICATION(CASE_ID,VERIFICATION_TYPE_ID,Person_contacted," +
                      "Cont_Designation_dept,ACCOUNT_CORRECT,DOCUMENT_AS_PER_STANDARD,AMOUNT_ON_DOC,FE_REMARK,FE_VISIT_DATE,CASE_STATUS_ID," +
                      "ADD_BY,ADD_DATE) "+
                      " VALUES(?,?,?,?,?,?,?,?,?,?,?,?)";

                paramBankStat[0] = new OleDbParameter("@CASE_ID", OleDbType.VarChar, 15);
                paramBankStat[0].Value = CaseID;
                paramBankStat[1] = new OleDbParameter("@VERIFICATION_TYPE_ID", OleDbType.VarChar, 10);
                paramBankStat[1].Value = VerificationTypeId;
                paramBankStat[2] = new OleDbParameter("@Person_contacted", OleDbType.VarChar, 100);
                paramBankStat[2].Value = NameOfPersonContacted;
                paramBankStat[3] = new OleDbParameter("@Cont_Designation_dept", OleDbType.VarChar, 200);
                paramBankStat[3].Value = Cont_DesignationDepartment;
                paramBankStat[4] = new OleDbParameter("@ACCOUNT_CORRECT", OleDbType.VarChar, 15);
                paramBankStat[4].Value = IsAcctCorrect;
                paramBankStat[5] = new OleDbParameter("@DOCUMENT_AS_PER_STANDARD", OleDbType.VarChar, 15);
                paramBankStat[5].Value = StanForOrg;
                paramBankStat[6] = new OleDbParameter("@AMOUNT_ON_DOC", OleDbType.VarChar, 15);
                paramBankStat[6].Value = AmtSSSPSC;
                paramBankStat[7] = new OleDbParameter("@FE_REMARK", OleDbType.VarChar, 255);
                paramBankStat[7].Value = FERemarks;
                paramBankStat[8] = new OleDbParameter("@VeriDate", OleDbType.VarChar, 11);
                paramBankStat[8].Value = VeriDate;
                paramBankStat[9] = new OleDbParameter("@CaseStatusID", OleDbType.VarChar, 15);
                paramBankStat[9].Value = CaseStatusID;
                paramBankStat[10] = new OleDbParameter("@AddedBy", OleDbType.VarChar, 15);
                paramBankStat[10].Value = AddedBy;
                paramBankStat[11] = new OleDbParameter("@AddedOn", OleDbType.DBTimeStamp);
                paramBankStat[11].Value = AddedOn;



                sRetVal = "Record added successfully.";

            }
            else
            {
                sSql = "UPDATE CPV_IDOC_VERIFICATION SET Person_contacted=?," +
                     " Cont_Designation_dept=?,ACCOUNT_CORRECT=?,DOCUMENT_AS_PER_STANDARD=?,AMOUNT_ON_DOC=?," +
                     " FE_REMARK=?,FE_VISIT_DATE=?,CASE_STATUS_ID=?,MODIFY_BY=?,MODIFY_DATE=? " +
                     " WHERE CASE_ID=? AND VERIFICATION_TYPE_ID=?";

                paramBankStat[0] = new OleDbParameter("@Person_contacted", OleDbType.VarChar, 100);
                paramBankStat[0].Value = NameOfPersonContacted;
                paramBankStat[1] = new OleDbParameter("@Cont_Designation_dept", OleDbType.VarChar, 200);
                paramBankStat[1].Value = Cont_DesignationDepartment;
                paramBankStat[2] = new OleDbParameter("@ACCOUNT_CORRECT", OleDbType.VarChar, 15);
                paramBankStat[2].Value = IsAcctCorrect;
                paramBankStat[3] = new OleDbParameter("@DOCUMENT_AS_PER_STANDARD", OleDbType.VarChar, 15);
                paramBankStat[3].Value = StanForOrg;
                paramBankStat[4] = new OleDbParameter("@AMOUNT_ON_DOC", OleDbType.VarChar, 15);
                paramBankStat[4].Value = AmtSSSPSC;
                paramBankStat[5] = new OleDbParameter("@FE_REMARK", OleDbType.VarChar, 255);
                paramBankStat[5].Value = FERemarks;
                paramBankStat[6] = new OleDbParameter("@VeriDate", OleDbType.VarChar, 11);
                paramBankStat[6].Value = VeriDate;
                paramBankStat[7] = new OleDbParameter("@CaseStatusID", OleDbType.VarChar, 15);
                paramBankStat[7].Value = CaseStatusID;
                paramBankStat[8] = new OleDbParameter("@ModifyBy", OleDbType.VarChar, 15);
                paramBankStat[8].Value = ModifyBy;
                paramBankStat[9] = new OleDbParameter("@ModifyOn", OleDbType.DBTimeStamp);
                paramBankStat[9].Value = ModifyOn;
                paramBankStat[10] = new OleDbParameter("@CASE_ID", OleDbType.VarChar, 15);
                paramBankStat[10].Value = CaseID;
                paramBankStat[11] = new OleDbParameter("@VERIFICATION_TYPE_ID", OleDbType.VarChar, 11);
                paramBankStat[11].Value = VerificationTypeId;

                sRetVal = "Record updated successfully.";
            }
            OleDbHelper.ExecuteNonQuery(oledbTrans, CommandType.Text, sSql, paramBankStat);
            //////////add by santosh shelar/////////////////////
            //sSql = "Update CPV_IDOC_CASE_DETAILS SET IS_CASE_COMPLETE='Y' WHERE CASE_ID='" + CaseID + "'";
            ///OleDbHelper.ExecuteNonQuery(oledbTrans, CommandType.Text, sSql);
            //Start Insert into CASE_TRANSACTION_LOG -------------------
            sSql = "";
            sSql = "Insert into CASE_TRANSACTION_LOG(CASE_ID,VERIFICATION_TYPE_ID,USER_ID,TRANS_START,TRANS_END," +
                 "CENTRE_ID,PRODUCT_ID,CLIENT_ID) VALUES(?,?,?,?,?,?,?,?)";

            OleDbParameter[] paramTransLog = new OleDbParameter[8];
            paramTransLog[0] = new OleDbParameter("@CaseID", OleDbType.VarChar, 15);
            paramTransLog[0].Value = CaseID;
            paramTransLog[1] = new OleDbParameter("@VerficationTypeID", OleDbType.VarChar, 15);
            paramTransLog[1].Value = VerificationTypeId;
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

            OleDbHelper.ExecuteNonQuery(oledbTrans, CommandType.Text, sSql, paramTransLog);

            //End  Insert into CASE_TRANSACTION_LOG --------------------
            if (IsVerificationComplete(oledbTrans, CaseID) == "true")
            {
                VerificationComplete(oledbTrans, CaseID);
                sRetVal += " Case verification data entry completed.";
            }
            /////
            oledbTrans.Commit();
            oledbConn.Close();

            return sRetVal;
        }
        catch (Exception ex)
        {
            oledbTrans.Rollback();
            oledbConn.Close();
            throw new Exception("Error while Inserting Bank statement Detail " + ex.Message);
        }
    }

    #endregion InsertBankStatement()

    #region GetVerifierID()
    public OleDbDataReader GetVerifierID(string sCaseId, string sVerifyType)
    {
        string sSql = "";
        sSql = "select FE_ID from CPV_IDOC_FE_CASE_MAPPING where case_id='" + sCaseId + "' " +
             " And verification_type_id='" + sVerifyType + "'";

        return OleDbHelper.ExecuteReader(oCmn.ConnectionString, CommandType.Text, sSql);
    }
    #endregion GetVerifierID()

    public OleDbDataReader GetIdocVerification(string sCaseID, string sVerificationTypeID)
    {
        OleDbConnection oledbConn = new OleDbConnection(oCmn.ConnectionString);
        string sql = "select TOTAL_INCOME,Overwriting,Pan_correct,Tan_correcT,computation_correct," +
        "Calculation_correct,Tax_cal_correct,Tax_payble_correct,OK_field_verification,IS_spelling_mistake," +
        "Other_observation,Person_contacted,Cont_Designation_dept,APP_DESIGNATION,APP_DEPARTMENT," +
        "APP_YEAR_IN_SERVICE,MONTH_INCOME,NO_of_Employee,TYPE_OF_INDUSTRY,ORGANIZATION_SEAL,AUTHORITY_SIGNATURE," +
        "DOCUMENT_AS_PER_STANDARD,DATE_ON_DOC,AMOUNT_ON_DOC,APP_ADDRESS_CORRECT,BUSSINESS_ACTIVITY_SEEN,STOCK_SIGHTED," +
        "NO_OF_EMP_SEEN,NAME_BOARD_SEEN,FE_REMARK,TELE_REMARK ,CASE_STATUS_ID,FE_VISIT_DATE,Gross_salary_Momthly_Annual_Income from cpv_idoc_verification where CASE_ID=" + sCaseID + " and VERIFICATION_TYPE_ID=" + sVerificationTypeID;
        return OleDbHelper.ExecuteReader(oledbConn, CommandType.Text, sql);

    }
    public OleDbDataReader GetIdocVeriAttempt(string sCaseID, string sVerificationTypeID)
    {
        OleDbConnection oledbConn = new OleDbConnection(oCmn.ConnectionString);
        string sql = "select Attempt_date_time,TELEPHONE_NO,REMARK from CPV_IDOC_VERI_ATTEMPTS where case_id=" + sCaseID + " and verification_type_id=" + sVerificationTypeID;
        return OleDbHelper.ExecuteReader(oledbConn, CommandType.Text, sql);

    }
    public string UpdateIdocVerification(string sCaseID, string sVerificationTypeID)
    { 
        OleDbConnection sqlConn = new OleDbConnection(oCmn.ConnectionString);
        sqlConn.Open();
        string sRetVal = "";
        OleDbTransaction sqlTrans = sqlConn.BeginTransaction();
        try
        {
            string sSql = "update cpv_idoc_verification set TOTAL_INCOME=?,Overwriting=?,Pan_correct=?,Tan_correcT=?,computation_correct=?," +
        "Calculation_correct=?,Tax_cal_correct=?,Tax_payble_correct=?,OK_field_verification=?,IS_spelling_mistake=?," +
        "Other_observation=?,Person_contacted=?,Cont_Designation_dept=?,APP_DESIGNATION=?,APP_DEPARTMENT=?," +
        "APP_YEAR_IN_SERVICE=?,MONTH_INCOME=?,NO_of_Employee=?,TYPE_OF_INDUSTRY=?,ORGANIZATION_SEAL=?,AUTHORITY_SIGNATURE=?," +
        "DOCUMENT_AS_PER_STANDARD=?,DATE_ON_DOC=?,AMOUNT_ON_DOC=?,APP_ADDRESS_CORRECT=?,BUSSINESS_ACTIVITY_SEEN=?,STOCK_SIGHTED=?," +
        "NO_OF_EMP_SEEN=?,NAME_BOARD_SEEN=?,FE_REMARK=?,TELE_REMARK=?,FE_VISIT_DATE=?,CASE_STATUS_ID=?,Gross_salary_Momthly_Annual_Income=?, "+
        "MODIFY_BY=?,MODIFY_DATE=? " +
        " where CASE_ID=" + sCaseID + " and VERIFICATION_TYPE_ID=" + sVerificationTypeID;

            OleDbParameter[] ParamVerification = new OleDbParameter[36];
           
            ParamVerification[0] = new OleDbParameter("@TOTAL_INCOME", OleDbType.Decimal, 9);
            ParamVerification[0].Value = TotalIncome;
            ParamVerification[1] = new OleDbParameter("@Overwriting", OleDbType.VarChar, 10);
            ParamVerification[1].Value = OverWritingTempring;
            ParamVerification[2] = new OleDbParameter("@Pan_correct", OleDbType.VarChar, 10);
            ParamVerification[2].Value = PanCorrect;
            ParamVerification[3] = new OleDbParameter("@Tan_correct", OleDbType.VarChar, 10);
            ParamVerification[3].Value = TanCorrect;
            ParamVerification[4] = new OleDbParameter("@computation_correct", OleDbType.VarChar, 10);
            ParamVerification[4].Value = OverallComputationCorrect;
            ParamVerification[5] = new OleDbParameter("@Calculation_correct", OleDbType.VarChar, 10);
            ParamVerification[5].Value = IncomeCalculationCorrect;
            ParamVerification[6] = new OleDbParameter("@Tax_cal_correct", OleDbType.VarChar, 10);
            ParamVerification[6].Value = TaxCalculationCorrect;
            ParamVerification[7] = new OleDbParameter("@Tax_payble_correct", OleDbType.VarChar, 10);
            ParamVerification[7].Value = F16PaybleISCorrect;
            ParamVerification[8] = new OleDbParameter("@OK_field_verification", OleDbType.VarChar, 10);
            ParamVerification[8].Value = OkSendForVerification;
            ParamVerification[9] = new OleDbParameter("@IS_spelling_mistake", OleDbType.VarChar, 10);
            ParamVerification[9].Value = SpellMistake;
            ParamVerification[10] = new OleDbParameter("@Other_observation", OleDbType.VarChar, 255);
            ParamVerification[10].Value = OtherVerification;
            ParamVerification[11] = new OleDbParameter("@Person_contacted", OleDbType.VarChar, 100);
            ParamVerification[11].Value = NameOfPersonContacted;
            ParamVerification[12] = new OleDbParameter("@Cont_Designation_dept", OleDbType.VarChar, 100);
            ParamVerification[12].Value = Cont_DesignationDepartment;
            ParamVerification[13] = new OleDbParameter("@APP_DESIGNATION", OleDbType.VarChar, 100);
            ParamVerification[13].Value = ApplicantDesignation;
            ParamVerification[14] = new OleDbParameter("@APP_DEPARTMENT", OleDbType.VarChar, 100);
            ParamVerification[14].Value = ApplicationDepartment;
            ParamVerification[15] = new OleDbParameter("@APP_YEAR_IN_SERVICE", OleDbType.Decimal, 9);
            ParamVerification[15].Value = ApplicantYearService;
            ParamVerification[16] = new OleDbParameter("@MONTH_INCOME", OleDbType.Decimal, 9);
            ParamVerification[16].Value = ApplicantGrossAnnualMonthlyIncome;
            ParamVerification[17] = new OleDbParameter("@NO_of_Employee", OleDbType.Numeric, 9);
            ParamVerification[17].Value = NoEmployess;
            ParamVerification[18] = new OleDbParameter("@TYPE_OF_INDUSTRY", OleDbType.VarChar, 100);
            ParamVerification[18].Value = TypeOfOrg;
            ParamVerification[19] = new OleDbParameter("@ORGANIZATION_SEAL", OleDbType.VarChar, 15);
            ParamVerification[19].Value = SealOfOrg;
            ParamVerification[20] = new OleDbParameter("@AUTHORITY_SIGNATURE", OleDbType.VarChar, 15);
            ParamVerification[20].Value = SigOfIssAuth;
            ParamVerification[21] = new OleDbParameter("@DOCUMENT_AS_PER_STANDARD", OleDbType.VarChar, 15);
            ParamVerification[21].Value = StanForOrg;
            ParamVerification[22] = new OleDbParameter("@DATE_ON_DOC", OleDbType.VarChar, 15);
            ParamVerification[22].Value = DtSSSPSC;
            ParamVerification[23] = new OleDbParameter("@AMOUNT_ON_DOC", OleDbType.VarChar, 15);
            ParamVerification[23].Value = AmtSSSPSC;
            ParamVerification[24] = new OleDbParameter("@APP_ADDRESS_CORRECT", OleDbType.VarChar, 15);
            ParamVerification[24].Value = AppOffCorrect;
            ParamVerification[25] = new OleDbParameter("@BUSSINESS_ACTIVITY_SEEN", OleDbType.VarChar, 10);
            ParamVerification[25].Value = BusinessActivitySeen;
            ParamVerification[26] = new OleDbParameter("@STOCK_SIGHTED", OleDbType.VarChar, 255);
            ParamVerification[26].Value = Stock;
            ParamVerification[27] = new OleDbParameter("@NO_OF_EMP_SEEN", OleDbType.VarChar, 10);
            ParamVerification[27].Value = NumberOfEmployeeinOrg;
            ParamVerification[28] = new OleDbParameter("@NAME_BOARD_SEEN", OleDbType.VarChar, 10);
            ParamVerification[28].Value = NameBoard;
            ParamVerification[29] = new OleDbParameter("@FE_REMARK", OleDbType.VarChar, 255);
            ParamVerification[29].Value = FERemarks;
            ParamVerification[30] = new OleDbParameter("@TELE_REMARK", OleDbType.VarChar, 255);
            ParamVerification[30].Value = TeleRemarks;
            ParamVerification[31] = new OleDbParameter("@FE_VISIT_DATE", OleDbType.VarChar, 255);
            ParamVerification[31].Value = VeriDate;
            ParamVerification[32] = new OleDbParameter("@CASE_STATUS_ID", OleDbType.VarChar, 255);
            ParamVerification[32].Value = CaseStatusID;
            ParamVerification[33] = new OleDbParameter("@Salary", OleDbType.VarChar, 50);
            ParamVerification[33].Value = Salary;
            ParamVerification[34] = new OleDbParameter("@ModifyBy", OleDbType.VarChar, 15);
            ParamVerification[34].Value = ModifyBy;
            ParamVerification[35] = new OleDbParameter("@ModifyOn", OleDbType.DBTimeStamp);
            ParamVerification[35].Value = ModifyOn;

            OleDbHelper.ExecuteNonQuery(sqlTrans, CommandType.Text, sSql, ParamVerification);

            //////add by santosh shelar///////////////////////
            //sSql = "Update CPV_IDOC_CASE_DETAILS SET IS_CASE_COMPLETE='Y' WHERE CASE_ID='" + CaseID + "'";
            //OleDbHelper.ExecuteNonQuery(sqlTrans, CommandType.Text, sSql);
            //Start Insert into CASE_TRANSACTION_LOG -------------------
            sSql = "";
            sSql = "Insert into CASE_TRANSACTION_LOG(CASE_ID,VERIFICATION_TYPE_ID,USER_ID,TRANS_START,TRANS_END," +
                 "CENTRE_ID,PRODUCT_ID,CLIENT_ID) VALUES(?,?,?,?,?,?,?,?)";

            OleDbParameter[] paramTransLog = new OleDbParameter[8];
            paramTransLog[0] = new OleDbParameter("@CaseID", OleDbType.VarChar, 15);
            paramTransLog[0].Value = CaseID;
            paramTransLog[1] = new OleDbParameter("@VerficationTypeID", OleDbType.VarChar, 15);
            paramTransLog[1].Value = VerificationTypeId;
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
            if (IsVerificationComplete(sqlTrans, CaseID) == "true")
            {
                VerificationComplete(sqlTrans, CaseID);
                sRetVal += " Case verification data entry completed.";
            }
            /////
            sqlTrans.Commit();
            sqlConn.Close();

        }
        catch (Exception ex)
        {
            sqlTrans.Rollback();
            sqlConn.Close();
            throw new Exception("Error while updating Verrification " + ex.Message);
        }
        return sRetVal;
    }
    public void updateVeriAttempt(string sCaseID, string sVerificationTypeID)
    {
        OleDbConnection sqlConn = new OleDbConnection(oCmn.ConnectionString);

        sqlConn.Open();
      
        OleDbTransaction sqlTrans = sqlConn.BeginTransaction();
        try
        {
            string sSql = "delete from  CPV_IDOC_VERI_ATTEMPTS where  case_id=" + sCaseID + " and   verification_type_id=" + sVerificationTypeID;
            //OleDbParameter[] ParamAttempt = new OleDbParameter[3];
            
           
            //ParamAttempt[0] = new OleDbParameter("@ATTEMPT_DATE_TIME", OleDbType.VarChar);
            //ParamAttempt[0].Value = AttempDateTime;
            //ParamAttempt[1] = new OleDbParameter("@TELEPHONE_NO", OleDbType.VarChar, 50);
            //ParamAttempt[1].Value = TellNo;
            //ParamAttempt[2] = new OleDbParameter("@REMARK", OleDbType.VarChar, 255);
            //ParamAttempt[2].Value = TellPhoneRemark;

           
            OleDbHelper.ExecuteNonQuery(sqlTrans, CommandType.Text, sSql);
            sqlTrans.Commit();
            sqlConn.Close();
        }
        catch (Exception ex)
        {
            sqlTrans.Rollback();
            sqlConn.Close();
            throw new Exception("Error while updating VerrificationAttempt " + ex.Message);
        }
    }
    public object getveriAttemptRecord(string sCaseID1, string sAttempDateTime1, string sVerificationTypeId1, string sTellNo1, string sTellPhoneRemark1)
    {
        OleDbConnection sqlConn = new OleDbConnection(oCmn.ConnectionString);

        sqlConn.Open();
        string sSql = "select count(*) from CPV_IDOC_VERI_ATTEMPTS where case_id=" + sCaseID1 + " and verification_type_id=" + sVerificationTypeId1 + " and ATTEMPT_DATE_TIME ='" + sAttempDateTime1 + "' and TELEPHONE_NO='" + sTellNo1 + "' and REMARK='" + sTellPhoneRemark1 + "' ";
       return( OleDbHelper.ExecuteScalar(sqlConn, CommandType.Text, sSql));
    }

    #region IsVerificationComplete
    //Name             :   IsVerificationComplete
    //Create By		   :   Hemangi Kambli
    //Create Date	   :   09 Oct 2007
    //Remarks 		   :   This method is used to check whether verification of case is completed or not.

    public string IsVerificationComplete(OleDbTransaction oledbTrans, string sCaseId)
    {
        string sSql = "";
        OleDbDataReader oledbRead;
        string bComplete = "";
        sSql = " Select case (select count(*) from CPV_IDOC_VERIFICATION_TYPE " +
              " where case_id='" + sCaseId + "') " +
              " when (select count(*) from (select distinct verification_type_id from " +
              " IDOC_IODC_CASE_OUTPUT_VW where case_id='" + sCaseId + "') AS A )" +
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
        sSql = "Update CPV_IDOC_CASE_DETAILS SET IS_CASE_COMPLETE='Y' WHERE CASE_ID='" + sCaseId + "'";
        OleDbHelper.ExecuteNonQuery(oledbTrans, CommandType.Text, sSql);
    }
    #endregion VerificationComplete

}
