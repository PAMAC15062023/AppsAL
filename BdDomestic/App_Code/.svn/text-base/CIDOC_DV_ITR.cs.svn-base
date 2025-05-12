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
/// Summary description for CIDOC_DV_ITR
/// </summary>
public class CIDOC_DV_ITR
{
    private CCommon objCon;

	public CIDOC_DV_ITR()
	{
        objCon = new CCommon();
		//
		// TODO: Add constructor logic here
		//
    }
    #region Properties Declaration

    private string strApplicantsName;
    private string strCDMReferanceNo;
    private string strDateOfInitiation;
    private string strAgencyCode;
    private decimal strTotalIncomeAsPerITR;
    private string strPANLogicAndCorrectness;
    private string strIsIt10DigitsAlphabet;
    private string strAreThe6th7th8thAnd9thDigitsNumeri;
    private string strIsTheFourthDigit;
    private string strComputationCorrect;
    private string strIncomeCalculationsCorrect;
    private string strTaxCalculationsCorrect;
    private string strAlphabetFallsUnderWardCircleRangeJurisdiction;
    private string strWhetherOKToSendForFieldVerification;
    private string strOtherObservation;
    private string strTalliedWith;
    private string strComputerRecords;
    private string strInwardRegister;
    private string strBlueRegister;
    private string strIndexRegister;
    private string strOrallyOkByClerk;
    private string strFinalStatus;
    private string strRemarks;
    private string strFECode;
    private string strNameOfFE;
    private string strCPVAgentsName;
    private string strDateOfVerification;
    private string strCPVAgentSign;
    private string strVerificationTypeID;
    private string strCaseID;
    private string strAddressFallsUnderWard;
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
    ///------------------------
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
    /// <summary>
    /// ////////////////////
    /// </summary>
    public string AddressFallsUnderWard
    {
        get
        {
            return strAddressFallsUnderWard;
        }

        set
        {
            strAddressFallsUnderWard = value;
        }
    }
    private string strIsCase;
    public string IsCase
    {
        get
        {
            return strIsCase; 
        }

        set
        {
            strIsCase = value;
        }
    }
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
    public string ApplicantsName
    {
        get
        {
            return strApplicantsName;
        }
        set
        {
            strApplicantsName = value;
        }
    }
    public string CDMReferanceNo
    {
        get
        {
            return strCDMReferanceNo;
        }
        set
        {
            strCDMReferanceNo = value;
        }
    }
    public string DateOfInitiation
    {
        get
        {
            return strDateOfInitiation;
        }
        set
        {
            strDateOfInitiation = value;
        }
    }
    public string AgencyCode
    {
        get
        {
            return strAgencyCode;
        }
        set
        {
            strAgencyCode = value;
        }
    }
    public decimal TotalIncomeAsPerITR
    {
        get
        {
            return strTotalIncomeAsPerITR;
        }
        set
        {
            strTotalIncomeAsPerITR = value;
        }
    }
    public string PANLogicAndCorrectness
    {
        get
        {
            return strPANLogicAndCorrectness;
        }
        set
        {
            strPANLogicAndCorrectness = value;
        }
    }
    public string IsIt10DigitsAlphabet
    {
        get
        {
            return strIsIt10DigitsAlphabet;
        }
        set
        {
            strIsIt10DigitsAlphabet = value;
        }
    }
    public string AreThe6th7th8thAnd9thDigitsNumeri
    {
        get
        {
            return strAreThe6th7th8thAnd9thDigitsNumeri;
        }
        set
        {
            strAreThe6th7th8thAnd9thDigitsNumeri = value;
        }
    }
    public string IsTheFourthDigit
    {
        get
        {
            return strIsTheFourthDigit;
        }
        set
        {
            strIsTheFourthDigit = value;
        }
    }
    public string ComputationCorrect
    {
        get
        {
            return strComputationCorrect;
        }
        set
        {
            strComputationCorrect = value;
        }
    }
    public string IncomeCalculationsCorrect
    {
        get
        {
            return  strIncomeCalculationsCorrect;
        }
        set
        {
            strIncomeCalculationsCorrect = value;
        }
    }
    public string TaxCalculationsCorrect
    {
        get
        {
            return strTaxCalculationsCorrect;
        }
        set
        {
            strTaxCalculationsCorrect = value;
        }
    }
    public string AlphabetFallsUnderWardCircleRangeJurisdiction
    {
        get
        {
            return strAlphabetFallsUnderWardCircleRangeJurisdiction;
        }
        set
        {
            strAlphabetFallsUnderWardCircleRangeJurisdiction = value;
        }
    }
    public string WhetherOKToSendForFieldVerification
    {
        get
        {
            return strWhetherOKToSendForFieldVerification;
        }
        set
        {
            strWhetherOKToSendForFieldVerification = value;
        }
    }
    public string OtherObservation
    {
        get
        {
            return strOtherObservation;
        }
        set
        {
            strOtherObservation = value;
        }
    }
    public string TalliedWith
    {
        get
        {
            return strTalliedWith;
        }
        set
        {
            strTalliedWith = value;
        }
    }
    public string ComputerRecords
    {
        get
        {
            return strComputerRecords;
        }
        set
        {
            strComputerRecords = value;
        }
    }
    public string InwardRegister
    {
        get
        {
            return strInwardRegister;
        }
        set
        {
            strInwardRegister = value;
        }
    }
    public string BlueRegister
    {
        get
        {
            return strBlueRegister;
        }
        set
        {
            strBlueRegister = value;
        }
    }
    public string IndexRegister
    {
        get
        {
            return strIndexRegister;
        }
        set
        {
            strIndexRegister = value;
        }
    }
    public string OrallyOkByClerk
    {
        get
        {
            return strOrallyOkByClerk;
        }
        set
        {
            strOrallyOkByClerk = value;
        }
    }
    public string FinalStatus
    {
        get
        {
            return strFinalStatus;
        }
        set
        {
            strFinalStatus = value;
        }
    }
    public string Remarks
    {
        get
        {
            return strRemarks;
        }
        set
        {
            strRemarks = value;
        }
    }
    public string FECode
    {
        get
        {
            return strFECode;
        }
        set
        {
            strFECode = value;
        }
    }
    public string NameOfFE
    {
        get
        {
            return strNameOfFE;
        }
        set
        {
            strNameOfFE = value;
        }
    }
    public string CPVAgentsName
    {
        get
        {
            return strCPVAgentsName;
        }
        set
        {
            strCPVAgentsName = value;
        }
    }

    public string DateOfVerification
    {
        get
        {
            return strDateOfVerification;
        }
        set
        {
            strDateOfVerification = value;
        }
    }
    public string CPVAgentSign
    {
        get
        {
            return strCPVAgentSign;
        }
        set
        {
            strCPVAgentSign = value;
        }
    }

    #endregion Properties Declaration

    public Int32 InsertFieldVerificationOfITR(ArrayList arrFieldVerificationOfITR)
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

            sqlSelectQuery = "Select CASE_ID,VERIFICATION_TYPE_ID from CPV_IDOC_VERIFICATION_DETAIL where CASE_ID='" + CaseID + "'" + "and VERIFICATION_TYPE_ID='" + VerificationTypeID + "'";
            objoledbDR = OleDbHelper.ExecuteReader(objCon.ConnectionString, CommandType.Text, sqlSelectQuery);
            OleDbParameter[] oledbParam = new OleDbParameter[8];

            if (objoledbDR.Read() == true)
            {
                sqlQuery = "Delete from CPV_IDOC_VERIFICATION_DETAIL where CASE_ID='" + CaseID + "'" +
                           " AND VERIFICATION_TYPE_ID='" + VerificationTypeID + "'";
                OleDbHelper.ExecuteNonQuery(oledbTrans, CommandType.Text, sqlQuery);
            }
            foreach (ArrayList item in arrFieldVerificationOfITR)
            {
                TalliedWith = item[0].ToString();
                ComputerRecords = item[1].ToString();
                InwardRegister = item[2].ToString();
                BlueRegister = item[3].ToString();
                IndexRegister = item[4].ToString();
                OrallyOkByClerk = item[5].ToString();
               
                //////////////////////////////Inserting in table CPV_CC_VERI_ATTEMPTS(Residence)                 

                sqlQuery = "Insert into CPV_IDOC_VERIFICATION_DETAIL (CASE_ID,Tallied_with,Computer_Record,Inward_register,Blue_register,index_register,Orally_by_clerck,VERIFICATION_TYPE_ID)" +
                          "Values(?,?,?,?,?,?,?,?)";


                oledbParam[0] = new OleDbParameter("@CaseID", OleDbType.VarChar, 15);
                oledbParam[0].Value = CaseID;

                oledbParam[1] = new OleDbParameter("@TalliedWith", OleDbType.VarChar, 50);
                oledbParam[1].Value = TalliedWith;

                oledbParam[2] = new OleDbParameter("@ComputerRecords", OleDbType.VarChar, 10);
                oledbParam[2].Value = ComputerRecords;

                oledbParam[3] = new OleDbParameter("@InwardRegister", OleDbType.VarChar,10);
                oledbParam[3].Value = InwardRegister;

                oledbParam[4] = new OleDbParameter("@BlueRegister", OleDbType.VarChar, 10);
                oledbParam[4].Value = BlueRegister;

                oledbParam[5] = new OleDbParameter("@IndexRegister", OleDbType.VarChar, 10);
                oledbParam[5].Value = IndexRegister;

                oledbParam[6] = new OleDbParameter("@IndexRegister", OleDbType.VarChar, 10);
                oledbParam[6].Value = IndexRegister;

                oledbParam[7] = new OleDbParameter("@VerificationTypeID", OleDbType.VarChar, 10);
                oledbParam[7].Value = VerificationTypeID;

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
    

    public string InsertIDOCITR()
    {
        OleDbConnection oledbConn = new OleDbConnection(objCon.ConnectionString);
        oledbConn.Open();
        OleDbTransaction oledbTrans = oledbConn.BeginTransaction();
        OleDbDataReader objoledbDR;
        String sqlSelectQuery = "";
        String sqlQuery,sSql = "";
        string sMsg = "";

        try
        {

            //////////////////////////////Inserting in table CPV_IDOC_VERIFICATION
           
            sqlSelectQuery = "Select CASE_ID,VERIFICATION_TYPE_ID from CPV_IDOC_VERIFICATION " +
                             "where CASE_ID='" + CaseID + "'" + "and VERIFICATION_TYPE_ID='" + VerificationTypeID + "'";
            objoledbDR = OleDbHelper.ExecuteReader(objCon.ConnectionString, CommandType.Text, sqlSelectQuery);
            OleDbParameter[] oledbParam = new OleDbParameter[20];
            if (objoledbDR.Read() == false)
            {
                sqlQuery = " Insert into CPV_IDOC_VERIFICATION (CASE_ID,VERIFICATION_TYPE_ID,TOTAL_INCOME,Pan_correct, " +
                           " computation_correct,Tax_cal_correct,OK_field_verification,Other_observation,INCOME_CAL_CORRECT," +
                           " Is_Fourth_Digit,Are_Digit_Numeric,Is_It_Ten_Digit_Alpha,Alpha_Falls_Under_Ward,Agency_Name," +
                           "FE_VISIT_DATE,CASE_STATUS_ID,FE_REMARK,Address_Falls_Under_Ward, " +
                           "ADD_BY,ADD_DATE) " +
                            " Values(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)";



                oledbParam[0] = new OleDbParameter("@CaseID", OleDbType.VarChar, 15);
                oledbParam[0].Value = CaseID;

                oledbParam[1] = new OleDbParameter("@VerificationTypeID", OleDbType.VarChar, 10);
                oledbParam[1].Value = VerificationTypeID;

                oledbParam[2] = new OleDbParameter("@TotalIncomeAsPerITR", OleDbType.Decimal);
                oledbParam[2].Value = TotalIncomeAsPerITR;

                oledbParam[3] = new OleDbParameter("@PANLogicAndCorrectness", OleDbType.VarChar, 10);
                oledbParam[3].Value = PANLogicAndCorrectness;

                oledbParam[4] = new OleDbParameter("@ComputationCorrect", OleDbType.VarChar, 10);
                oledbParam[4].Value = ComputationCorrect;

                oledbParam[5] = new OleDbParameter("@TaxCalculationsCorrect", OleDbType.VarChar, 10);
                oledbParam[5].Value = TaxCalculationsCorrect;

                oledbParam[6] = new OleDbParameter("@WhetherOKToSendForFieldVerification", OleDbType.VarChar, 10);
                oledbParam[6].Value = WhetherOKToSendForFieldVerification;

                oledbParam[7] = new OleDbParameter("@OtherObservation", OleDbType.VarChar, 255);
                oledbParam[7].Value = OtherObservation;

                oledbParam[8] = new OleDbParameter("@IncomeCalculationsCorrect", OleDbType.VarChar, 10);
                oledbParam[8].Value = IncomeCalculationsCorrect;

                oledbParam[9] = new OleDbParameter("@IsTheFourthDigit", OleDbType.VarChar, 10);
                oledbParam[9].Value = IsTheFourthDigit;

                oledbParam[10] = new OleDbParameter("@AreThe6th7th8thAnd9thDigitsNumeri", OleDbType.VarChar, 10);
                oledbParam[10].Value = AreThe6th7th8thAnd9thDigitsNumeri;

                oledbParam[11] = new OleDbParameter("@IsIt10DigitsAlphabet", OleDbType.VarChar, 10);
                oledbParam[11].Value = IsIt10DigitsAlphabet;

                oledbParam[12] = new OleDbParameter("@AlphabetFallsUnderWardCircleRangeJurisdiction", OleDbType.VarChar, 10);
                oledbParam[12].Value = AlphabetFallsUnderWardCircleRangeJurisdiction;

                oledbParam[13] = new OleDbParameter("@AgencyCode", OleDbType.VarChar, 50);
                oledbParam[13].Value = AgencyCode;

                oledbParam[14] = new OleDbParameter("@DateOfVerification", OleDbType.VarChar, 11);
                oledbParam[14].Value = DateOfVerification;

                oledbParam[15] = new OleDbParameter("@FinalStatus", OleDbType.VarChar, 15);
                oledbParam[15].Value = FinalStatus;

                oledbParam[16] = new OleDbParameter("@Remarks", OleDbType.VarChar, 255);
                oledbParam[16].Value = Remarks;

                oledbParam[17] = new OleDbParameter("@AddressFallsUnderWard", OleDbType.VarChar, 255);
                oledbParam[17].Value = AddressFallsUnderWard;

                oledbParam[18] = new OleDbParameter("@AddedBy", OleDbType.VarChar, 15);
                oledbParam[18].Value = AddedBy;

                oledbParam[19] = new OleDbParameter("@AddedOn", OleDbType.DBTimeStamp);
                oledbParam[19].Value = AddedOn;


                sMsg = "Record added successfully.";
            }
            else
            {
                //////////////////////////////Updating in table CPV_IDOC_VERIFICATION
                sqlQuery = "Update CPV_IDOC_VERIFICATION set TOTAL_INCOME=?,Pan_correct=?," +
                          "computation_correct=?,Tax_cal_correct=?,OK_field_verification=?,Other_observation=?, " +
                          "INCOME_CAL_CORRECT=?,Is_Fourth_Digit=?,Are_Digit_Numeric=?,Is_It_Ten_Digit_Alpha=?," +
                          "Alpha_Falls_Under_Ward=?,Agency_Name=?,FE_VISIT_DATE=?,CASE_STATUS_ID=?,FE_REMARK=?,Address_Falls_Under_Ward=?,MODIFY_BY=?,MODIFY_DATE=? " +
                          "where CASE_ID=? and VERIFICATION_TYPE_ID=?";



                oledbParam[0] = new OleDbParameter("@TotalIncomeAsPerITR", OleDbType.Decimal);
                oledbParam[0].Value = TotalIncomeAsPerITR;

                oledbParam[1] = new OleDbParameter("@PANLogicAndCorrectness", OleDbType.VarChar, 10);
                oledbParam[1].Value = PANLogicAndCorrectness;

                oledbParam[2] = new OleDbParameter("@ComputationCorrect", OleDbType.VarChar, 10);
                oledbParam[2].Value = ComputationCorrect;

                oledbParam[3] = new OleDbParameter("@TaxCalculationsCorrect", OleDbType.VarChar, 10);
                oledbParam[3].Value = TaxCalculationsCorrect;

                oledbParam[4] = new OleDbParameter("@WhetherOKToSendForFieldVerification", OleDbType.VarChar, 10);
                oledbParam[4].Value = WhetherOKToSendForFieldVerification;

                oledbParam[5] = new OleDbParameter("@OtherObservation", OleDbType.VarChar, 255);
                oledbParam[5].Value = OtherObservation;

                oledbParam[6] = new OleDbParameter("@IncomeCalculationsCorrect", OleDbType.VarChar, 10);
                oledbParam[6].Value = IncomeCalculationsCorrect;

                oledbParam[7] = new OleDbParameter("@IsTheFourthDigit", OleDbType.VarChar, 10);
                oledbParam[7].Value = IsTheFourthDigit;

                oledbParam[8] = new OleDbParameter("@AreThe6th7th8thAnd9thDigitsNumeri", OleDbType.VarChar, 10);
                oledbParam[8].Value = AreThe6th7th8thAnd9thDigitsNumeri;

                oledbParam[9] = new OleDbParameter("@IsIt10DigitsAlphabet", OleDbType.VarChar, 10);
                oledbParam[9].Value = IsIt10DigitsAlphabet;

                oledbParam[10] = new OleDbParameter("@AlphabetFallsUnderWardCircleRangeJurisdiction", OleDbType.VarChar, 10);
                oledbParam[10].Value = AlphabetFallsUnderWardCircleRangeJurisdiction;

                oledbParam[11] = new OleDbParameter("@AgencyCode", OleDbType.VarChar, 50);
                oledbParam[11].Value = AgencyCode;


                oledbParam[12] = new OleDbParameter("@DateOfVerification", OleDbType.VarChar, 11);
                oledbParam[12].Value = DateOfVerification;

                oledbParam[13] = new OleDbParameter("@FinalStatus", OleDbType.VarChar, 15);
                oledbParam[13].Value = FinalStatus;

                oledbParam[14] = new OleDbParameter("@Remarks", OleDbType.VarChar, 255);
                oledbParam[14].Value = Remarks;

                oledbParam[15] = new OleDbParameter("@AddressFallsUnderWard", OleDbType.VarChar, 255);
                oledbParam[15].Value = AddressFallsUnderWard;

                oledbParam[16] = new OleDbParameter("@ModifyBy", OleDbType.VarChar, 15);
                oledbParam[16].Value = ModifyBy;

                oledbParam[17] = new OleDbParameter("@ModifyOn", OleDbType.DBTimeStamp);
                oledbParam[17].Value = ModifyOn;

                oledbParam[18] = new OleDbParameter("@CaseID", OleDbType.VarChar, 15);
                oledbParam[18].Value = CaseID;

                oledbParam[19] = new OleDbParameter("@VerificationTypeID", OleDbType.VarChar, 10);
                oledbParam[19].Value = VerificationTypeID;

                sMsg = "Record updated successfully.";
        
            }
            OleDbHelper.ExecuteNonQuery(oledbTrans, CommandType.Text, sqlQuery, oledbParam);
            ////////add by santosh shelar///////////////
            ///sSql = "Update CPV_IDOC_CASE_DETAILS SET IS_CASE_COMPLETE='Y' WHERE CASE_ID='" + CaseID + "'";
            ////OleDbHelper.ExecuteNonQuery(oledbTrans, CommandType.Text, sSql);
            
            
            
            
            
            ////////////////////////////////////Inserting in table CPV_IDOC_VERI_ATTEMPTS 
            //sqlSelectQuery = "";
            //sqlSelectQuery = "Select CASE_ID,VERIFICATION_TYPE_ID from CPV_IDOC_VERI_ATTEMPTS " +
            //                 "where CASE_ID='" + CaseID + "' and VERIFICATION_TYPE_ID='" + VerificationTypeID + "'";
            //objoledbDR = OleDbHelper.ExecuteReader(objCon.ConnectionString, CommandType.Text, sqlSelectQuery);
            //OleDbParameter[] oledbParamAttempts = new OleDbParameter[3];
            //if (objoledbDR.Read() == false)
            //{
            //    sqlQuery = "Insert into CPV_IDOC_VERI_ATTEMPTS(CASE_ID,VERIFICATION_TYPE_ID," +
            //                "REMARK) Values(?,?,?)";



            //    oledbParamAttempts[0] = new OleDbParameter("@CaseID", OleDbType.VarChar, 15);
            //    oledbParamAttempts[0].Value = CaseID;

            //    oledbParamAttempts[1] = new OleDbParameter("@VerificationTypeID", OleDbType.VarChar, 10);
            //    oledbParamAttempts[1].Value = VerificationTypeID;

            //    //oledbParamAttempts[2] = new OleDbParameter("@NameOfFE", OleDbType.VarChar, 15);
            //    //oledbParamAttempts[2].Value = NameOfFE;

                
            //    oledbParamAttempts[2] = new OleDbParameter("@Remarks", OleDbType.VarChar,255);
            //    oledbParamAttempts[2].Value = Remarks;



            //}
            //else
            //{
            //    //////////////////////////////Updating in table CPV_CC_VERI_OTHER_DETAILS(Residence) 
            //    sqlQuery = "Update CPV_IDOC_VERI_ATTEMPTS  set REMARK=? " +
            //               "where CASE_ID=? and VERIFICATION_TYPE_ID=?";


            //    //oledbParamAttempts[0] = new OleDbParameter("@NameOfFE", OleDbType.VarChar, 15);
            //    //oledbParamAttempts[0].Value = NameOfFE;

            

            //    oledbParamAttempts[0] = new OleDbParameter("@Remarks", OleDbType.VarChar, 255);
            //    oledbParamAttempts[0].Value = Remarks;

            //    oledbParamAttempts[1] = new OleDbParameter("@CaseID", OleDbType.VarChar, 15);
            //    oledbParamAttempts[1].Value = CaseID;

            //    oledbParamAttempts[2] = new OleDbParameter("@VerificationTypeID", OleDbType.VarChar, 10);
            //    oledbParamAttempts[2].Value = VerificationTypeID;
            //}
            //OleDbHelper.ExecuteNonQuery(oledbTrans, CommandType.Text, sqlQuery, oledbParamAttempts);

            //Start Insert into CASE_TRANSACTION_LOG -------------------
            sqlQuery = "";
            sqlQuery = "Insert into CASE_TRANSACTION_LOG(CASE_ID,VERIFICATION_TYPE_ID,USER_ID,TRANS_START,TRANS_END," +
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

            

            OleDbHelper.ExecuteNonQuery(oledbTrans, CommandType.Text, sqlQuery, paramTransLog);

            //End  Insert into CASE_TRANSACTION_LOG --------------------
            //Update CPV_CC_Case_details with status 'Y' ---------------
            if (IsVerificationComplete(oledbTrans, CaseID, ClientId, CentreId) == "true")
            {
                VerificationComplete(oledbTrans, CaseID);
                sMsg += " Case verification data entry completed.";
            }
            /////////////////////////////////////////////////////////////////////////////////////////////


            oledbTrans.Commit();
            oledbConn.Close();
            return sMsg;
        }
        catch (Exception ex)
        {
            oledbTrans.Rollback();
            oledbConn.Close();
            throw new Exception("Error found During Insertion" + ex.Message);

        }

    }
    
    public DataSet GetFieldVerificationOfITR(string sCaseID, string sVerificationTypeID)
    {
        string sSql = "";

        sSql = "SELECT Tallied_with,Computer_Record,Inward_register,Blue_register,index_register,Orally_by_clerck from CPV_IDOC_VERIFICATION_DETAIL " +
              " where CASE_ID='" + sCaseID + "'" + "and VERIFICATION_TYPE_ID='" + sVerificationTypeID + "'";
        return OleDbHelper.ExecuteDataset(objCon.ConnectionString, CommandType.Text, sSql);
    }
    public OleDbDataReader GetIDOCCaseDetail(string sCaseId)
    {
        string sSql = "";
        sSql = "SELECT (ISNULL(TITLE,'')+' '+isNull(FIRST_NAME,'')+' '+isnull(MIDDLE_NAME,'')+' '+isnull(LAST_NAME,'')) as FULL_NAME,REF_NO, Case_REC_DATETIME,TOTAL_AMOUNT FROM CPV_IDOC_CASE_DETAILS WHERE CASE_ID='" + sCaseId + "'";
        return OleDbHelper.ExecuteReader(objCon.ConnectionString, CommandType.Text, sSql);
    }
    public OleDbDataReader GetIDOCVerificationITR(string sCaseID, string sVerificationTypeID)
    {
        string sSql = "";

        sSql = "SELECT Pan_correct,computation_correct,FE_VISIT_DATE,Tax_cal_correct,OK_field_verification,Other_observation," +
               "INCOME_CAL_CORRECT,Is_Fourth_Digit,Are_Digit_Numeric,Is_It_Ten_Digit_Alpha,Alpha_Falls_Under_Ward,Agency_Name,CASE_STATUS_ID,FE_REMARK,Address_Falls_Under_Ward from CPV_IDOC_VERIFICATION " +
               " where CASE_ID='" + sCaseID + "'" + "and VERIFICATION_TYPE_ID='" + sVerificationTypeID + "'";
        return OleDbHelper.ExecuteReader(objCon.ConnectionString, CommandType.Text, sSql);
    }
    //public OleDbDataReader GetIDOCATTEMPTS(string sCaseID, string sVerificationTypeID)
    //{
    //    string sSql = "";
    //    sSql = "SELECT Remark from CPV_IDOC_VERI_ATTEMPTS " +
    //          " where CASE_ID='" + sCaseID + "'" + "and VERIFICATION_TYPE_ID='" + sVerificationTypeID + "'";
    //    return OleDbHelper.ExecuteReader(objCon.ConnectionString, CommandType.Text, sSql);
 
    //}
    public OleDbDataReader GetFEName(string sCaseID, string sVerificationTypeID)
    {
        string sSql = "";
        DataTable dt = new DataTable();
        sSql = "Select FULLNAME,DATE_TIME from FE_VW as v inner join CPV_IDOC_FE_CASE_MAPPING as cm on v.EMP_ID=cm.FE_ID where CASE_ID='" + sCaseID + "'" + "and VERIFICATION_TYPE_ID='" + sVerificationTypeID + "'";
        return OleDbHelper.ExecuteReader(objCon.ConnectionString, CommandType.Text, sSql);
 
        

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

        //sSql = "Select case (select count(*) from CPV_IDOC_VERIFICATION_TYPE " +
        //       " where case_id='" + sCaseId + "') " +
        //       " when (select count(*) from IDOC_IODC_CASE_OUTPUT_VW where case_id='" + sCaseId + "') " +
        //       " then 'true' else 'false' end as IsComplete";
        //modified by hemangi kambli on 15-Nov-2007 -----
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


