/*----------------------------------------------------------------------------------------
Scope of Program	:	
File Name			:	CPersonalDetail.cs
Create By			:	Hemangi Kambli
Create Date		    :	7th April 2007
Remarks 		    :	This class is used as Base Class for all other classes in CPV module
                    :   (i.e.CCreditCard,CEBC,CKYC,CIDOC)
						
----------------------------------------------------------------------------------------*/
using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;


public class CCPVDetail
{
    private CCommon objCon;
    public CCPVDetail()
    {
        objCon = new CCommon();
    }

    #region Property Decalaration

    private string sCaseId;
    private string sClusterId;
    private string sCenterId;
    private string sClientId;
    private string sRefId;
    private DateTime dtRec;
    private string sCaseType;
    private string sTitle;
    private string sFirstNm;
    private string sMiddleNm;
    private string sLastNm;
    private string sFullName;
    private string dtDOB;
    private string sResAdd1;
    private string sResAdd2;
    private string sResAdd3;
    private string sResCity;
    private string sResState;/* Add Residencnce State*/ 
    private string sResPin;
    private string sResLandMark;
    private string sResPhone;
    private string sResMobile;/* Add Residencnce Mobile*/
    private string sOffName;
    private string sOffAdd1;
    private string sOffAdd2;
    private string sOffAdd3;
    private string sOffCity;
    private string sOffState;
    private string sOffPin;
    private string sOffPhone;
    private string sOffExtn;
    private string sDesgn;
    private string sDept;
    private string sOccupation;
    /* Adding priority,region,splInstruction*/
    private string sPriority;
    private string sRegion;
    private string sSplInstruction;
    /* Adding Totally Permanent Address*/
    private string sPmtAdd1;
    private string sPmtAdd2;
    private string sPmtAdd3;
    private string spmtCity;
    private string sPmtState;
    private string spmtPinCode;
    private string sPmtLandMark;
    private string sPmtPhone;
    /*------End--------*/
    private string sAddedBy;
    private string sModifiedBy;
    private DateTime dtAdded;
    private DateTime dtModify;
    /* Some property for RL*/

    private string sProductType;
    private string sProductName;
    private string sProductPrice;
    private string sEmployeeType;
    private string sReference1;
    private string sReference2;
    private string sTelephone1;
    private string sTelephone2;
    /* Some property for EBC*/
    private string sDOJ;
    private string sLocation;
    private string sDisgnation;
    private string sStaffName;
    private string sFathersName;
    private string sPreEmpName;
    private string sPreEmpAdd;
    private string sPreDesignation;
    private string sRefNameNo;
    private string sProjects;
    private string sQualification;
    private string sSpecilization;
    private string sUniversity;
    private string sRollNo;
    private string sYearoffPassing;
    

    /*----------------------------------------------------------------------------------------
           
                           Created By			:	Gargi Srivastava
                           Created Date		:	22 May 2007
      /*------ Properties for Some Additional Fields Starts --------*/          
  

    private string srtITO;
    private DateTime caseRecievedDate;
    private DateTime caseRecievedTime;
    private Decimal totalAmount;
    private Decimal taxAmount;
    private string strRefProductID;
    private string strRefCaseID;
    private string strRemark;
    private string strCaseStatusID;
    private string strBankName;
    private string strBankAddress;
    private string strBankPin;
    private string strBankCity;
    private string strVerificationCharges;
    private string strRegistrationNumberOfVechicle;
    private string strRTOOffice;
    private string strAsstYear;
    private string strReceiptNo;

    public string RegistrationNumberOfVechicle
    {
        get { return strRegistrationNumberOfVechicle; }
        set { strRegistrationNumberOfVechicle = value; }
    }

    public string AsstYear
    {
        get { return strAsstYear; }
        set { strAsstYear = value; }
    }
    public string ReceiptNo
    {
        get { return strReceiptNo; }
        set { strReceiptNo = value; }
    }
    private string sPanNo;
    public string PanNo
    {
        get { return sPanNo; }
        set { sPanNo = value; }
    }
    private string sVerificationTypeCode;
    public string VerificationTypeCode
    {
        get { return sVerificationTypeCode; }
        set { sVerificationTypeCode = value; }
    }
    
    public string RTOOffice
    {
        get { return strRTOOffice; }
        set { strRTOOffice = value; }
    }

    
    public string VerificationCharges
    {
        get { return strVerificationCharges; }
        set { strVerificationCharges = value; }
    }

    public string BankName
    {
        get { return strBankName; }
        set { strBankName = value; }
    }

    public string BankAddress
    {
        get { return strBankAddress; }
        set { strBankAddress = value; }
    }

    public string BankPin
    {
        get { return strBankPin; }
        set { strBankPin = value; }
    }

    public string BankCity
    {
        get { return strBankCity; }
        set { strBankCity = value; }
    }

    public string CaseStatusID
    {
        get { return strCaseStatusID; }
        set { strCaseStatusID = value; }
    }
    public string Remark
    {
        get { return strRemark; }
        set { strRemark = value; }
    }
    public string RefProductID
    {
        get { return strRefProductID; }
        set { strRefProductID = value; }
    }
    public string RefCaseID
    {
        get { return strRefCaseID; }
        set { strRefCaseID = value; }
    }

    public DateTime CaseRecievedDate
    {
        get { return caseRecievedDate; }
        set { caseRecievedDate = value; }
    }
    public DateTime CaseRecievedTime
    {
        get { return caseRecievedTime; }
        set { caseRecievedTime = value; }
    }
    public Decimal TotalAmount
    {
        get { return totalAmount; }
        set { totalAmount = value; }
    }
    public Decimal TaxAmount
    {
        get { return taxAmount; }
        set { taxAmount = value; }
    }
    public string ITO
    {
        get { return srtITO; }
        set { srtITO = value; }
    }
    /*------ Properties for Some Additional Fields End --------*/
    public string RefNo
    {
        get { return sRefId; }
        set { sRefId = value; }
    }
    public string CaseId
    {
        get { return sCaseId; }
        set { sCaseId = value; }
    }
    private string sVerificationType;
    public string VerificationTypeID
    {
        get { return sVerificationType; }
        set { sVerificationType = value; }
    }

    public string ClusterId
    {
        get { return sClusterId; }
        set { sClusterId = value; }
    }

    public string CentreId
    {
        get { return sCenterId; }
        set { sCenterId = value; }
    }
    public string ClientId
    {
        get { return sClientId; }
        set { sClientId = value; }
    }
    public string CaseType
    {
        get { return sCaseType; }
        set { sCaseType = value;}
    }
    public string Title
    {
        get { return sTitle; }
        set { sTitle = value; }
    }
    private string Rec1; 
    public string ReceivedDateTime1
    {
        get { return Rec1; }
        set { Rec1 = value; }
    }

    public DateTime ReceivedDateTime
    {
        get { return dtRec; }
        set { dtRec = value; }
    }
    public string FirstName
    {
        get { return sFirstNm; }
        set { sFirstNm = value; }
    }

    public string MiddleName
    {
        get { return sMiddleNm; }
        set { sMiddleNm = value; }
    }

    public string LastName
    {
        get { return sLastNm; }
        set { sLastNm = value; }
    }

    public string FullName
    {
        get { return sFullName; }
        set { sFullName = value; }
    }
    public string DOB
    {
        get { return dtDOB; }
        set 
        {
            //if (value != "")
            //{
                dtDOB = value;
            //}
            //else
            //{
            //    dtDOB = null;
            //}
        }
    }
    DateTime dtDateOfBirth;
    public DateTime DateOfBirth
    {
        get { return dtDateOfBirth; }
        set { dtDateOfBirth = value; }
    }
    public string Designation
    {
        get { return sDesgn; }
        set { sDesgn = value; }
    }

    public string Department
    {
        get { return sDept; }
        set { sDept = value; }
    }

    public string Occupation
    {
        get { return sOccupation; }
        set { sOccupation = value; }
    }

    public string ResAdd1
    {
        get { return sResAdd1; }
        set { sResAdd1 = value; }
    }

    public string ResAdd2
    {
        get { return sResAdd2; }
        set { sResAdd2 = value; }
    }

    public string ResAdd3
    {
        get { return sResAdd3; }
        set { sResAdd3 = value; }
    }

    public string ResCity
    {
        get { return sResCity; }
        set { sResCity = value; }
    }
    /* Adding Res.. State*/
    public string ResState
    {
        get { return sResState; }
        set { sResState = value; }
    }

    public string ResPin
    {
        get { return sResPin; }
        set { sResPin = value; }
    }

    public string ResLandMark
    {
        get { return sResLandMark; }
        set { sResLandMark = value; }
    }

    public string ResPhone
    {
        get { return sResPhone; }
        set { sResPhone = value; }
    }
    public string ResMobile
    {
        get { return sResMobile; }
        set { sResMobile = value; }
    }
    public string OfficeName
    {
        get { return sOffName;  }
        set { sOffName = value; }
    }

    public string OfficeAdd1
    {
        get { return sOffAdd1; }
        set { sOffAdd1 = value; }
    }

    public string OfficeAdd2
    {
        get { return sOffAdd2; }
        set { sOffAdd2 = value; }
    }

    public string OfficeAdd3
    {
        get { return sOffAdd3; }
        set { sOffAdd3 = value; }
    }

    public string OfficeCity
    {
        get { return sOffCity; }
        set { sOffCity = value; }
    }
    /*Adding property of Office State*/
    public string OfficeState
    {
        get { return sOffState; }
        set { sOffState = value; }
    }

    public string OfficePin
    {
        get { return sOffPin; }
        set { sOffPin = value; }
    }

    public string OfficePhone
    {
        get { return sOffPhone; }
        set { sOffPhone = value; }
    }

    public string OfficeExtn
    {
        get { return sOffExtn; }
        set { sOffExtn = value; }
    }
   /* Adding Properties*/
    public string Priority
    {
        get { return sPriority; }
        set { sPriority = value; }
    }
    public string Region
    {
        get { return sRegion; }
        set { sRegion = value;}
    }
    public string SplInstruction
    {
        get { return sSplInstruction; }
        set { sSplInstruction = value; }
    }
    /*----------------------------------*/
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
    /* Adding Permanent Address*/
    public string PmtAdd1
    {
        get { return sPmtAdd1; }
        set { sPmtAdd1 = value; }
    }
    public string PmtAdd2
    {
        get { return sPmtAdd2; }
        set { sPmtAdd2 = value; }
    }
    public string PmtAdd3
    {
        get { return sPmtAdd3;}
        set { sPmtAdd3 = value;}
    }
    
    public string PmtCity
    {
        get { return spmtCity; }
        set { spmtCity = value; }
    }
    public string PmtState
    {
        get { return sPmtState;}
        set { sPmtState = value;}
    }
    public string PmtPinCode
    {
        get { return spmtPinCode; }
        set { spmtPinCode = value; }
    }
    public string PmtLandMark
    {
        get { return sPmtLandMark; }
        set { sPmtLandMark = value;}
    }
    public string PmtPhone
    {
        get { return sPmtPhone; }
        set { sPmtPhone = value; }
    }
    private string sVerificationCode;
    public string VerificationCode
    {
        get { return sVerificationCode; }
        set { sVerificationCode = value; }
    }
    /*----Property for RL---------*/

    public string ProductType
    {
        get { return sProductType; }
        set { sProductType = value; }
    }
    public string ProductName
    {
        get { return sProductName; }
        set { sProductName = value; }
    }
    public string ProductPrice
    {
        get { return sProductPrice; }
        set { sProductPrice = value; }
    }
    public string EmployeeType
    {
        get { return sEmployeeType; }
        set { sEmployeeType = value; }
    }
    public string Reference1
    {
        get { return sReference1; }
        set { sReference1 = value; }
    }
    public string Reference2
    {
        get { return sReference2; }
        set { sReference2 = value; }
    }
    public string Telephone1
    {
        get { return sTelephone1; }
        set { sTelephone1 = value; }
    }
    public string Telephone2
    {
        get { return sTelephone2; }
        set { sTelephone2 = value; }
    }
    /*Some Additional Property EBC */
    public string DOJ
    {
        get { return sDOJ; }
        set { sDOJ = value; }
    }
    public string Location
    {
        get { return sLocation; }
        set { sLocation = value; }
    }
    public string Designation1
    {
        get { return sDisgnation; }
        set { sDisgnation = value; }
    }
    public string StaffName
    {
        get { return sStaffName; }
        set { sStaffName = value; }
    }
    public string FathersName
    {
        get { return sFathersName; }
        set { sFathersName = value; }
    }
    public string PreEmpName
    {
        get { return sPreEmpName; }
        set { sPreEmpName = value; }
    }
    public string PreEmpAdd
    {
        get { return sPreEmpAdd; }
        set { sPreEmpAdd = value; }
    }
    public string PreviousDesignation
    {
        get { return sPreDesignation; }
        set { sPreDesignation = value; }
    }
    public string Project
    {
        get { return sProjects; }
        set { sProjects = value; }
    }
    public string RefNameNum
    {
        get { return sRefNameNo; }
        set { sRefNameNo = value; }
    }
    
    public string Qualification
    {
        get { return sQualification; }
        set { sQualification = value; }
    }
    public string Specilization
    {
        get { return sSpecilization; }
        set { sSpecilization = value; }
    }
    public string University
    {
        get { return sUniversity; }
        set { sUniversity = value; }
    }
    public string RollNo
    {
        get { return sRollNo; }
        set { sRollNo = value; }
    }
    public string YearOfPassing
    {
        get { return sYearoffPassing; }
        set { sYearoffPassing = value; }
    }
    #endregion Property Decalaration

    public string GetCaseDetail(string sCPVType, string sFrom, string sTo)
    {
        string sSql = "";
        sSql = "Select Case_Id,Ref_No,Case_Rec_DateTime,(RES_ADD_LINE_1+ ' ' +RES_ADD_LINE_2+ ' ' +RES_ADD_LINE_3+ ' ' + RES_LAND_MARK+ ' ' + RES_CITY + ' ' +RES_PIN_CODE) as ResidenceAddress, " +
                 "(OFF_ADD_LINE_1+ ' ' +OFF_ADD_LINE_2+ ' ' +OFF_ADD_LINE_3+' ' +OFF_CITY +' ' + OFF_PIN_CODE) as OfficeAddress, " +
                 " Full_Name as Name FROM ";

        if (sCPVType == "CC")
            sSql += "CPV_CC_CASE_DETAILS";
        else if (sCPVType == "EBC")
        {
            sSql = "";
            sSql = "Select Case_Id,Ref_No,Case_Rec_DateTime,(ADD1+ ' ' +ADD2+ ' ' +ADD3+ ' ' + CITY + ' ' +PIN_CODE) as ResidenceAddress, null as OfficeAddress, " +
                   "Full_Name as Name FROM ";
            sSql += "CPV_EBC_CASE_DETAILS";
        }
        else if (sCPVType == "KYC")
            sSql += "CPV_KYC_CASE_DETAILS";
        else if (sCPVType == "IDOC")
            sSql += "CPV_IDOC_CASE_DETAILS";
            //Add by Sandeep khare 
        else if (sCPVType == "RL")
            sSql += "CPV_RL_CASE_DETAILS";
        //for Case_Rec_date
        if (sFrom != "" && sTo != "")
        {
            sSql += " WHERE (Case_Rec_dateTime BETWEEN '" + objCon.FixQuotes(sFrom) + "'" + "and '" + objCon.FixQuotes(sTo) + "')";
        }
        else if (sFrom != "" && sTo == "")
        {
            sSql += " WHERE (Case_Rec_dateTime BETWEEN '" + objCon.FixQuotes(sFrom) + "'" + "and '" + objCon.FixQuotes(sFrom) + "')";
        }
        else if (sFrom == "" && sTo != "")
        {
            sSql += " WHERE (Case_Rec_dateTime BETWEEN '" + objCon.FixQuotes(sTo) + "'" + "and '" + objCon.FixQuotes(sTo) + "')";
        }
        ///////////////////////////////////////

        return sSql;
    }
}

