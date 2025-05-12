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
/// Summary description for CBIS_ENTRY
/// </summary>
public class CBISENTRYFORM
{
    CCommon oCmn = new CCommon();
    public CBISENTRYFORM()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    private String strEmpCode;
    private String strTempEmpCode;
    private String strFName;          //2
    private String strMName;          //3
    private String strLName;          //4
    private String strDoB;
    //5
    private String strDoL;
            //6
    private String strPresentAdd1;           //7
    private String strPresentAdd2;           //8
    private String strPresentAdd3;
    private String strPerManentAdd1;           //7
    private String strPerManentAdd2;           //8
    private String strPerManentAdd3;           //9
    private String strCity;           //10
    private String strPin;            //11
    private String strMobile;         //12
    private String strPhone;          //13
    private String strEmpType;        //14
    private String strDesignation;    //15
    private String strDepartment;     //16    
    private String strCentreID;       //17
    private String strCompanyID;      //18   
    private String strAddOn;            //19
    private String strAddedBy;        //20
    private String strModifyOn;         //21
    private String strModifyBy;       //22  
    private String strFullName;       //23
    private String strEmpID;          //24
    private String strDoJ;            //25
    private String strActivityID;
    private String strProductID;
    private String strClientID;
    private String strSubCentreID;
    private String strFathersName;
    private String strHiegt;
    private String strWeight;
    private String strBloodGroup;
    private String strMarritalStatus;
    private String strWifeName;
    private String strWifeAge;
    private String strNameOfBank;
    private String strACNO;
    private String strLangKnown;
    private String strRelationWithEmployee;
    private String strRelationName;
    private String strContagiousDisease;
    private String strDetailOfContagiousDisease;
    private String strCourtProceeding;
    private String strDetailOfCourtProceeding;
    private String strNomineeName;
    private String strPANNO;
    private String strPhonePermanentAdd;
    private String strApprovalMailDate;
    private String strApprovalByOther;
    private String strUserIDOfCluster;
    private String strUserIDOfHOHR;
    private String strUserIDOfActivityManager;
    private String strApprovedByOther;
    private String strTypeOfCategory;
    private String strPhotoPath;
    private String strApprovalDateOfHOHR;
    private String strGender;
    //For Salary
    private String strHRA;
    private String strBasic;
    private String strSPALL;
    private String strGrossAmt;
    private String strNomineeTitle;
    private String strTitle;
    private String strRelativeName;
    private String strRelativeCode;
    private String strEmployementContactNo;
    public String EmployementContactNo    //1
    {
        get { return strEmployementContactNo; }
        set
        {
            if (value == "")
            {
                strEmployementContactNo = null;
            }
            else
            {
                strEmployementContactNo = value;
            }
        }
    }
    public String RelativeName    //1
    {
        get { return strRelativeName; }
        set
        {
            if (value == "")
            {
                strRelativeName = null;
            }
            else
            {
                strRelativeName = value;
            }
        }
    }
    public String RelativeCode    //1
    {
        get { return strRelativeCode; }
        set
        {
            if (value == "")
            {
                strRelativeCode = null;
            }
            else
            {
                strRelativeCode = value;
            }
        }
    }


    public String Title    //1
    {
        get { return strTitle; }
        set
        {
            if (value == "")
            {
                strTitle = null;
            }
            else
            {
                strTitle = value;
            }
        }
    }

    public String NominneTitle    //1
    {
        get { return strNomineeTitle; }
        set
        {
            if (value == "")
            {
                strNomineeTitle = null;
            }
            else
            {
                strNomineeTitle = value;
            }
        }
    }

    public String HRA    //1
    {
        get { return strHRA; }
        set
        {
            if (value == "")
            {
                strHRA = null;
            }
            else
            {
                strHRA = value;
            }
        }
    }
    public String Basic    //1
    {
        get { return strBasic; }
        set
        {
            if (value == "")
            {
                strBasic = null;
            }
            else
            {
                strBasic = value;
            }
        }
    }
    public String SPAll    //1
    {
        get { return strSPALL; }
        set
        {
            if (value == "")
            {
                strSPALL = null;
            }
            else
            {
                strSPALL = value;
            }
        }
    }
    public String GrossAmt    //1
    {
        get { return strGrossAmt; }
        set
        {
            if (value == "")
            {
                strGrossAmt = null;
            }
            else
            {
                strGrossAmt = value;
            }
        }
    }
    public String SubCentreID    //1
    {
        get { return strSubCentreID; }
        set
        {
            if (value == "")
            {
                strSubCentreID = null;
            }
            else
            {
                strSubCentreID = value;
            }
        }
    }
   //For Childre Detail
    private string strChildName;
    private string strChildAge;
    private int iChildrenDetailId;
    public String ChildName    //1
    {
        get { return strChildName; }
        set
        {
            if (value == "")
            {
                strChildName = null;
            }
            else
            {
                strChildName = value;
            }
        }
    }
    public String ChildAge    //1
    {
        get { return strChildAge; }
        set
        {
            if (value == "")
            {
                strChildAge = null;
            }
            else
            {
                strChildAge = value;
            }
        }
    }
    public int ChildrenDetailId    //1
    {
        get { return iChildrenDetailId; }
        set
        {
           iChildrenDetailId = value;           
        }
    }
    //For Qualification
    private String strTypeOfQualification;
    private String strNameofCollege;
    private String strDuration;
    private String strCertificateExam;
    private String strDivMarks;
    private String strCopyAttached;
    private String strFilepath;
    private int iQualificationDetailId;

    public int QualificationDetailId    //1
    {
        get { return iQualificationDetailId; }
        set
        {
            iQualificationDetailId = value;
        }
    }

    public String TypeOfQualification    //1
    {
        get { return strTypeOfQualification; }
        set
        {
            if (value == "")
            {
                strTypeOfQualification = null;
            }
            else
            {
                strTypeOfQualification = value;
            }
        }
    }
    public String NameOfCollege    //1
    {
        get { return strNameofCollege; }
        set
        {
            if (value == "")
            {
                strNameofCollege = null;
            }
            else
            {
                strNameofCollege = value;
            }
        }
    }
    public String Duration    //1
    {
        get { return strDuration; }
        set
        {
            if (value == "")
            {
                strDuration = null;
            }
            else
            {
                strDuration = value;
            }
        }
    }

    public String CertifcateExam    //1
    {
        get { return strCertificateExam; }
        set
        {
            if (value == "")
            {
                strCertificateExam = null;
            }
            else
            {
                strCertificateExam = value;
            }
        }
    }
    public String DivMarks   //1
    {
        get { return strDivMarks; }
        set
        {
            if (value == "")
            {
                strDivMarks = null;
            }
            else
            {
                strDivMarks = value;
            }
        }
    }
    public String copyAttached    //1
    {
        get { return strCopyAttached; }
        set
        {
            if (value == "")
            {
                strCopyAttached = null;
            }
            else
            {
                strCopyAttached = value;
            }
        }
    }
    public String FilePath    //1
    {
        get { return strFilepath; }
        set
        {
            if (value == "")
            {
                strFilepath = null;
            }
            else
            {
                strFilepath = value;
            }
        }
    }
    //For Employement Detail
    private String strEmployerName;
    private String strEmployementDuration;
    private String strEmployementSlary;
    private String strReasonForLeaving;
    private String strEmployementDesignation;
    private int iEmployementDetailID;

    public int EmployementDetailId    //1
    {
        get { return iEmployementDetailID; }
        set
        {
            iEmployementDetailID = value;
        }
    }

    public String EmployerName    //1
    {
        get { return strEmployerName; }
        set
        {
            if (value == "")
            {
                strEmployerName = null;
            }
            else
            {
                strEmployerName = value;
            }
        }
    }
    public String EmployementDuration    //1
    {
        get { return strEmployementDuration; }
        set
        {
            if (value == "")
            {
                strEmployementDuration = null;
            }
            else
            {
                strEmployementDuration = value;
            }
        }
    }
    public String EmployementSalary    //1
    {
        get { return strEmployementSlary; }
        set
        {
            if (value == "")
            {
                strEmployementSlary = null;
            }
            else
            {
                strEmployementSlary = value;
            }
        }
    }
    public String ReasonForLeaving    //1
    {
        get { return strReasonForLeaving; }
        set
        {
            if (value == "")
            {
                strReasonForLeaving = null;
            }
            else
            {
                strReasonForLeaving = value;
            }
        }
    }

    public String EmployementDesignation    //1
    {
        get { return strEmployementDesignation; }
        set
        {
            if (value == "")
            {
                strEmployementDesignation = null;
            }
            else
            {
                strEmployementDesignation = value;
            }
        }
    }
    //For Hobbies
    private String strLiterary;
    private String strSport;
    private String strhobbies;
    private int iHobbyDetailID;
    public int HobbytDetailId    //1
    {
        get { return iHobbyDetailID; }
        set
        {
            iHobbyDetailID = value;
        }
    }


    public String LiteraryCulture    //1
    {
        get { return strLiterary; }
        set
        {
            if (value == "")
            {
                strLiterary = null;
            }
            else
            {
                strLiterary = value;
            }
        }
    }
    public String Sport  //1
    {
        get { return strSport; }
        set
        {
            if (value == "")
            {
                strSport = null;
            }
            else
            {
                strSport = value;
            }
        }
    }
    public String Hobbies  //1
    {
        get { return strhobbies; }
        set
        {
            if (value == "")
            {
                strhobbies = null;
            }
            else
            {
                strhobbies = value;
            }
        }
    }

   //For Reference Detail
    public String strReferenceName;
    public String strReferenceAddress;
    public String strReferenceOccupation;
    public String strReferenceRelation;
    public String strReferenceContactNo;
    public int iReferenceDetailID;
    public int ReferencetDetailId    //1
    {
        get { return iReferenceDetailID; }
        set
        {
            iReferenceDetailID = value;
        }
    }
    public String ReferenceName  //1
    {
        get { return strReferenceName; }
        set
        {
            if (value == "")
            {
                strReferenceName = null;
            }
            else
            {
                strReferenceName = value;
            }
        }
    }

    public String ReferenceAddress  //1
    {
        get { return strReferenceAddress; }
        set
        {
            if (value == "")
            {
                strReferenceAddress = null;
            }
            else
            {
                strReferenceAddress = value;
            }
        }
    }
    public String ReferenceOccupation  //1
    {
        get { return strReferenceOccupation; }
        set
        {
            if (value == "")
            {
                strReferenceOccupation = null;
            }
            else
            {
                strReferenceOccupation = value;
            }
        }
    }
    public String RefrenceRelation  //1
    {
        get { return strReferenceRelation; }
        set
        {
            if (value == "")
            {
                strReferenceRelation = null;
            }
            else
            {
                strReferenceRelation = value;
            }
        }
    }
    public String RefrenceContactNo  //1
    {
        get { return strReferenceContactNo; }
        set
        {
            if (value == "")
            {
                strReferenceContactNo = null;
            }
            else
            {
                strReferenceContactNo = value;
            }
        }
    }

    public String ActivityID    //1
    {
        get { return strActivityID; }
        set
        {
            if (value == "")
            {
                strActivityID = null;
            }
            else
            {
                strActivityID = value;
            }
        }
    }

    public String ProductID    //1
    {
        get { return strProductID; }
        set
        {
            if (value == "")
            {
                strProductID = null;
            }
            else
            {
                strProductID = value;
            }
        }
    }
    public String ClientID    //1
    {
        get { return strClientID; }
        set
        {
            if (value == "")
            {
                strClientID = null;
            }
            else
            {
                strClientID = value;
            }
        }
    }

    public String FathersName    //1
    {
        get { return strFathersName; }
        set
        {
            if (value == "")
            {
                strFathersName = null;
            }
            else
            {
                strFathersName = value;
            }
        }
    }

    public String Hieght    //1
    {
        get { return strHiegt; }
        set
        {
            if (value == "")
            {
                strHiegt = null;
            }
            else
            {
                strHiegt = value;
            }
        }
    }

    public String Weight    //1
    {
        get { return strWeight; }
        set
        {
            if (value == "")
            {
                strWeight = null;
            }
            else
            {
                strWeight = value;
            }
        }
    }
    public String BloodGroup    //1
    {
        get { return strBloodGroup; }
        set
        {
            if (value == "")
            {
                strBloodGroup = null;
            }
            else
            {
                strBloodGroup = value;
            }
        }
    }

    public String MarritalStatus    //1
    {
        get { return strMarritalStatus; }
        set
        {
            if (value == "")
            {
                strMarritalStatus = null;
            }
            else
            {
                strMarritalStatus = value;
            }
        }
    }

    public String WifeName    //1
    {
        get { return strWifeName; }
        set
        {
            if (value == "")
            {
                strWifeName = null;
            }
            else
            {
                strWifeName = value;
            }
        }
    }

    public String WifeAge    //1
    {
        get { return strWifeAge; }
        set
        {
            if (value == "")
            {
                strWifeAge = null;
            }
            else
            {
                strWifeAge = value;
            }
        }
    }

    public String NameOfBank    //1
    {
        get { return strNameOfBank; }
        set
        {
            if (value == "")
            {
                strNameOfBank = null;
            }
            else
            {
                strNameOfBank = value;
            }
        }
    }

    public String ACNO    //1
    {
        get { return strACNO; }
        set
        {
            if (value == "")
            {
                strACNO = null;
            }
            else
            {
                strACNO = value;
            }
        }
    }


    public String LaguageKnown    //1
    {
        get { return strLangKnown; }
        set
        {
            if (value == "")
            {
                strLangKnown = null;
            }
            else
            {
                strLangKnown = value;
            }
        }
    }
    public String RelationWithEmployee    //1
    {
        get { return strRelationWithEmployee; }
        set
        {
            if (value == "")
            {
                strRelationWithEmployee = null;
            }
            else
            {
                strRelationWithEmployee = value;
            }
        }
    }

    public String RelationName    //1
    {
        get { return strRelationName; }
        set
        {
            if (value == "")
            {
                strRelationName = null;
            }
            else
            {
                strRelationName = value;
            }
        }
    }

    public String ContagiousDisease    //1
    {
        get { return strContagiousDisease; }
        set
        {
            if (value == "")
            {
                strContagiousDisease = null;
            }
            else
            {
                strContagiousDisease = value;
            }
        }
    }

    public String DetailOfContagiousDisease    //1
    {
        get { return strDetailOfContagiousDisease; }
        set
        {
            if (value == "")
            {
                strDetailOfContagiousDisease = null;
            }
            else
            {
                strDetailOfContagiousDisease = value;
            }
        }
    }
    public String NomineeName    //1
    {
        get { return strNomineeName; }
        set
        {
            if (value == "")
            {
                strNomineeName = null;
            }
            else
            {
                strNomineeName = value;
            }
        }
    }

    public String PANNO    //1
    {
        get { return strPANNO; }
        set
        {
            if (value == "")
            {
                strPANNO = null;
            }
            else
            {
                strPANNO = value;
            }
        }
    }
    public String PhonePermanentAdd    //1
    {
        get { return strPhonePermanentAdd; }
        set
        {
            if (value == "")
            {
                strPhonePermanentAdd = null;
            }
            else
            {
                strPhonePermanentAdd = value;
            }
        }
    }

    public String CourtProceeding    //1
    {
        get { return strCourtProceeding; }
        set
        {
            if (value == "")
            {
                strCourtProceeding = null;
            }
            else
            {
                strCourtProceeding = value;
            }
        }
    }
    public String DetailofCourtProceeding    //1
    {
        get { return strDetailOfCourtProceeding; }
        set
        {
            if (value == "")
            {
                strDetailOfCourtProceeding = null;
            }
            else
            {
                strDetailOfCourtProceeding = value;
            }
        }
    }

    public String ApprovalMailDate    //1
    {
        get { return strApprovalMailDate; }
        set
        {
            if (value == "")
            {
                strApprovalMailDate = null;
            }
            else
            {
                strApprovalMailDate = value;
            }
        }
    }


    public String ApprovalByOther    //1
    {
        get { return strApprovalByOther; }
        set
        {
            if (value == "")
            {
                strApprovalByOther = null;
            }
            else
            {
                strApprovalByOther = value;
            }
        }
    }

    public String ApprovalMailDateOfHOHR    //1
    {
        get { return strApprovalDateOfHOHR; }
        set
        {
            if (value == "")
            {
                strApprovalDateOfHOHR = null;
            }
            else
            {
                strApprovalDateOfHOHR = value;
            }
        }
    }



    public String UserIDOfHOHR    //1
    {
        get { return strUserIDOfHOHR; }
        set
        {
            if (value == "")
            {
                strUserIDOfHOHR = null;
            }
            else
            {
                strUserIDOfHOHR = value;
            }
        }
    }

    public String UserIDOfClusterHR    //1
    {
        get { return strUserIDOfCluster; }
        set
        {
            if (value == "")
            {
                strUserIDOfCluster = null;
            }
            else
            {
                strUserIDOfCluster = value;
            }
        }
    }
    public String UserIDOfActivityManager    //1
    {
        get { return strUserIDOfActivityManager; }
        set
        {
            if (value == "")
            {
                strUserIDOfActivityManager = null;
            }
            else
            {
                strUserIDOfActivityManager = value;
            }
        }
    }

   

   
    public String PhotoPath    //1
    {
        get { return strPhotoPath; }
        set
        {
            if (value == "")
            {
                strPhotoPath = null;
            }
            else
            {
                strPhotoPath = value;
            }
        }
    }

    private String strResignation;
    public String Resignation    //1
    {
        get { return strResignation; }
        set
        {
            if (value == "")
            {
                strResignation = null;
            }
            else
            {
                strResignation = value;
            }
        }
    }
    private String strLeftOrganisation;
    public String LeftOrganisation    //1
    {
        get { return strLeftOrganisation; }
        set
        {
            if (value == "")
            {
                strLeftOrganisation = null;
            }
            else
            {
                strLeftOrganisation = value;
            }
        }
    }

    public String EmpCode    //1
    {
        get { return strEmpCode; }
        set
        {
            if (value == "")
            {
                strEmpCode = null;
            }
            else
            {
                strEmpCode = value;
            }
        }
    }

    public String TempEmpCode    //1
    {
        get { return strTempEmpCode; }
        set
        {
            if (value == "")
            {
                strTempEmpCode = null;
            }
            else
            {
                strTempEmpCode = value;
            }
        }
    }
    public String FName    //2
    {
        get { return strFName; }
        set
        {
            //if (value == "")
            //{
            //    sFName = null;
            //}
            //else
            //{
            strFName = value;
            //}
        }
    }
    public String MName    //3
    {
        get { return strMName; }
        set
        {
            if (value == "")
            {
                strMName = null;
            }
            else
            {
                strMName = value;
            }
        }
    }
    //Changed by Prashant Rewale
    public String LName    //4
    {
        get { return strLName; }
        set
        {
            //if (value == "")
            //{
            //    sLName = null;
            //}
            //else
            //{
            strLName = value;
            //}
        }
    }
    public String DoB    //5
    {
        get { return strDoB; }
        set
        {
            if (value == "")
            {
                strDoB = null;
            }
            else
            {
                strDoB = value;
            }
        }
    }
    public String DoL    //5
    {
        get { return strDoL; }
        set
        {
            if (value == "")
            {
                strDoL = null;
            }
            else
            {
                strDoL = value;
            }
        }
    }
    public String Gender    //6
    {
        get { return strGender; }
        set
        {
            if (value == "")
            {
                strGender = null;
            }
            else
            {
                strGender = value;
            }
        }
    }
    public String PresentAdd1    //7
    {
        get { return strPresentAdd1; }
        set
        {
            if (value == "")
            {
                strPresentAdd1 = null;
            }
            else
            {
                strPresentAdd1 = value;
            }
        }
    }
    public String PresentAdd2    //8
    {
        get { return strPresentAdd2; }
        set
        {
            if (value == "")
            {
                strPresentAdd2 = null;
            }
            else
            {
                strPresentAdd2 = value;
            }
        }
    }
    public String PresentAdd3    //9
    {
        get { return strPresentAdd3; }
        set
        {
            if (value == "")
            {
                strPresentAdd3 = null;
            }
            else
            {
                strPresentAdd3 = value;
            }
        }
    }


    public String PermanentAdd1    //7
    {
        get { return strPerManentAdd1; }
        set
        {
            if (value == "")
            {
                strPerManentAdd1 = null;
            }
            else
            {
                strPerManentAdd1 = value;
            }
        }
    }
    public String PernanentAdd2    //8
    {
        get { return strPerManentAdd2; }
        set
        {
            if (value == "")
            {
                strPerManentAdd2 = null;
            }
            else
            {
                strPerManentAdd2 = value;
            }
        }
    }
    public String PermanentAdd3    //9
    {
        get { return strPerManentAdd3; }
        set
        {
            if (value == "")
            {
                strPerManentAdd3 = null;
            }
            else
            {
                strPerManentAdd3 = value;
            }
        }
    }

    public String City    //10
    {
        get { return strCity; }
        set
        {
            if (value == "")
            {
                strCity = null;
            }
            else
            {
                strCity = value;
            }
        }
    }
    public String Pin    //11
    {
        get { return strPin; }
        set
        {
            if (value == "")
            {
                strPin = null;
            }
            else
            {
                strPin = value;
            }
        }
    }
    public String Mobile    //12
    {
        get { return strMobile; }
        set
        {
            if (value == "")
            {
                strMobile = null;
            }
            else
            {
                strMobile = value;
            }
        }
    }
    public String Phone    //13
    {
        get { return strPhone; }
        set
        {
            if (value == "")
            {
                strPhone = null;
            }
            else
            {
                strPhone = value;
            }
        }
    }
    public String EmpType    //14
    {
        get { return strEmpType; }
        set
        {
            if (value == "")
            {
                strEmpType = null;
            }
            else
            {
                strEmpType = value;
            }
        }
    }
    public String Designation    //15
    {
        get { return strDesignation; }
        set
        {
            if (value == "")
            {
                strDesignation = null;
            }
            else
            {
                strDesignation = value;
            }
        }
    }
    public String Department    //16
    {
        get { return strDepartment; }
        set
        {
            if (value == "")
            {
                strDepartment = null;
            }
            else
            {
                strDepartment = value;
            }
        }
    }
    public String CentreID    //17
    {
        get { return strCentreID; }
        set
        {
            if (value == "")
            {
                strCentreID = null;
            }
            else
            {
                strCentreID = value;
            }
        }
    }
    public String CompanyID    //18
    {
        get { return strCompanyID; }
        set
        {
            if (value == "")
            {
                strCompanyID = null;
            }
            else
            {
                strCompanyID = value;
            }
        }
    }

    public String AddOn    //19
    {
        get { return strAddOn; }
        set
        {
            if (value == "")
            {
                strAddOn = null;
            }
            else
            {
                strAddOn = value;
            }
        }
    }
    public String AddedBy    //20
    {
        get { return strAddedBy; }
        set
        {
            if (value == "")
            {
                strAddedBy = null;
            }
            else
            {
                strAddedBy = value;
            }
        }
    }
    public String ModifyOn    //21
    {
        get { return strModifyOn; }
        set
        {
            if (value == "")
            {
                strModifyOn = null;
            }
            else
            {
                strModifyOn = value;
            }
        }
    }
    public String ModifyBy    //22
    {
        get { return strModifyBy; }
        set
        {
            if (value == "")
            {
                strModifyBy = null;
            }
            else
            {
                strModifyBy = value;
            }
        }
    }
    public String FullName    //23
    {
        get { return strFullName; }
        set
        {
            if (value == "")
            {
                strFullName = null;
            }
            else
            {
                strFullName = value;
            }
        }
    }
    public String EmpID    //24
    {
        get { return strEmpID; }
        set
        {
            if (value == "")
            {
                strEmpID = null;
            }
            else
            {
                strEmpID = value;
            }
        }
    }
    public String DoJ    //25
    {
        get { return strDoJ; }
        set
        {
            if (value == "")
            {
                strDoJ = null;
            }
            else
            {
                strDoJ = value;
            }
        }
    }
    public void InsertEmployeePersonalDeatil()
    {
        String sSql1 = "";
        String sSql2 = "";
        //Create and open Connection
        OleDbConnection sqlConn = new OleDbConnection(oCmn.ConnectionString);
        OleDbConnection sqlConn1 = new OleDbConnection(oCmn.ConnectionString);
        sqlConn.Open();
        sqlConn1.Open();
        //Create and open Transaction
        OleDbParameter[] param = new OleDbParameter[2];
        param[0] = new OleDbParameter("CentreID", OleDbType.VarChar, 15);

        //if (CentreID == null)
        //{
        //    param[0].Value = "";
        //}
       
            param[0].Value = CentreID;
        param[1] = new OleDbParameter("TempCode1", OleDbType.VarChar, 15);
        //param[1].Direction = ParameterDirection.Output;
        if (TempEmpCode == null)
        {
            param[1].Value = "";
        }
        else
            param[1].Value = TempEmpCode;

        OleDbHelper.ExecuteNonQuery(sqlConn, CommandType.StoredProcedure, "sp_TempCode", param);


        object c = "";
        string qry1 = "";
        qry1 = "Select code from tempcode";
        c = OleDbHelper.ExecuteScalar(sqlConn, CommandType.Text, qry1);
        string d = "";
        d = c.ToString();
        OleDbTransaction sqlTrans = sqlConn.BeginTransaction();
        OleDbTransaction sqlTrans1 = sqlConn1.BeginTransaction();
        try
        {
            //To Get Unique CaseID
            EmpID = oCmn.GetUniqueID("EMPLOYEE_MASTER", "101").ToString();
            if (FName != null)
                FullName = FName + " ";
            if (LName != null)
                FullName = FullName + MName + " ";
            if (LName != null)
                FullName = FullName + LName;

            FullName = FullName.Trim();

            //Case Master Insert Query
            sSql1 = " INSERT INTO EMPLOYEE_MASTER(EMP_ID, EMP_CODE,TEMP_EMP_CODE, FIRSTNAME, MIDDLENAME,  LASTNAME, FULLNAME, " +
                    " GENDER, DOB , ADD1, ADD2, ADD3,PHONE_R,PR_ADD1,PR_ADD2,PR_ADD3,PHONE_PERMAENT_ADD,FATHER_NAME,HEIGHT,WEIGHT,BLOOD_GROUP,MOBILE, " +
                    " MARTAL_STATUS,WIFE_NAME,WIFE_AGE,RELATION_WITH_EMPLOYEE,RELATION_NAME_WITH_EMPLOYEE,"+
                    " COURT_PROCEEDING,DETAIL_OF_COURT_PROCEEDING,CONTAGIOUS_DISEASE,CONTAGIOUS_DISEASE_DETAIL,  " +
                    " NOMINEE_NAME,PAN#,NAME_OF_BANK ,LANGUAGE_KNOWN , ADD_DATE, ADD_USER_ID,USER_ID_ACTIVITYMANAGER,SUVIDHA_AC ,CENTRE_ID,SUBCENTRE_ID,NOMINNE_TITLE,PHOTO_PATH,Title,CITY,PIN,RELATIVE_NAME,RELATIVE_CODE)" +
                                
                    " VALUES (?, ?, ?, ?, ?, ?, " +
                    " ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, " +
                    " ?, ?, ?, ?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)";

            ////////OleDbParameter[] param = new OleDbParameter[2];
            ////////param[0] = new OleDbParameter("CentreID", OleDbType.VarChar,15);
            
            ////////if (CentreID == null)
            ////////{
            ////////    param[0].Value = "";
            ////////}
            ////////else
            ////////    param[0].Value = CentreID;
            ////////param[1] = new OleDbParameter("TempCode1", OleDbType.VarChar,15);
            //////////param[1].Direction = ParameterDirection.Output;
            ////////if (TempEmpCode == null)
            ////////{
            ////////    param[1].Value = "";
            ////////}
            ////////else
            ////////    param[1].Value = TempEmpCode;

            ////////OleDbHelper.ExecuteNonQuery(sqlTrans1, CommandType.StoredProcedure, "sp_TempCode", param);
            
            OleDbParameter[] param_Employee_Master = new OleDbParameter[48];
            param_Employee_Master[0] = new OleDbParameter("EMP_ID", OleDbType.VarChar,15);
            param_Employee_Master[0].Value = EmpID;
            param_Employee_Master[1] = new OleDbParameter("EMP_CODE", OleDbType.VarChar,15);
            param_Employee_Master[1].Value = d;
            param_Employee_Master[2] = new OleDbParameter("TEMP_EMP_CODE", OleDbType.VarChar,25);
            param_Employee_Master[2].Value = d;
            param_Employee_Master[3] = new OleDbParameter("FIRSTNAME", OleDbType.VarChar,100);
            param_Employee_Master[3].Value = FName;
            param_Employee_Master[4] = new OleDbParameter("MIDDLENAME", OleDbType.VarChar,100);
            param_Employee_Master[4].Value = MName;
            param_Employee_Master[5] = new OleDbParameter("LASTNAME", OleDbType.VarChar,100);
            param_Employee_Master[5].Value = LName;
            param_Employee_Master[6] = new OleDbParameter("FULLNAME", OleDbType.VarChar,200);
            param_Employee_Master[6].Value = FullName;
            param_Employee_Master[7] = new OleDbParameter("GENDER", OleDbType.VarChar,1);
            param_Employee_Master[7].Value = Gender;
            param_Employee_Master[8] = new OleDbParameter("DOB", OleDbType.Date);
            if (DoB != null)
                param_Employee_Master[8].Value = Convert.ToDateTime(oCmn.strDate(DoB));
            else
                param_Employee_Master[8].Value = Convert.ToDateTime(oCmn.strDate(DoB));

            //param_Employee_Master[8] = new OleDbParameter("DOJ", OleDbType.Date);
            //if (DoJ != null)
            //    param_Employee_Master[8].Value = Convert.ToDateTime(oCmn.strDate(DoJ));
            //else
            //    param_Employee_Master[8].Value = DoJ;

            param_Employee_Master[9] = new OleDbParameter("PRESENTADD1", OleDbType.VarChar,200);
            param_Employee_Master[9].Value = PresentAdd1;
            param_Employee_Master[10] = new OleDbParameter("PRESENTADD2", OleDbType.VarChar,200);
            param_Employee_Master[10].Value = PresentAdd2;
            param_Employee_Master[11] = new OleDbParameter("PRESENTADD3", OleDbType.VarChar,200);
            param_Employee_Master[11].Value = PresentAdd3;
            param_Employee_Master[12] = new OleDbParameter("PHONE_R", OleDbType.VarChar,30);
            param_Employee_Master[12].Value = Phone;
            param_Employee_Master[13] = new OleDbParameter("PERMANENTADD1", OleDbType.VarChar,200);
            param_Employee_Master[13].Value = PermanentAdd1;
            param_Employee_Master[14] = new OleDbParameter("PERMANENTADD2", OleDbType.VarChar,200);
            param_Employee_Master[14].Value = PernanentAdd2;
            param_Employee_Master[15] = new OleDbParameter("PERMANENTADD3", OleDbType.VarChar,200);
            param_Employee_Master[15].Value = PermanentAdd3;
            param_Employee_Master[16] = new OleDbParameter("PHONEPERMANENTADD", OleDbType.VarChar,50);
            param_Employee_Master[16].Value = PhonePermanentAdd;
            param_Employee_Master[17] = new OleDbParameter("FATHERSNAME", OleDbType.VarChar,100);
            param_Employee_Master[17].Value = FathersName;
            param_Employee_Master[18] = new OleDbParameter("HIEGHT", OleDbType.VarChar,10);
            param_Employee_Master[18].Value = Hieght;
            param_Employee_Master[19] = new OleDbParameter("WEIGHT", OleDbType.VarChar,10);
            param_Employee_Master[19].Value = Weight;
            param_Employee_Master[20] = new OleDbParameter("BLOODGRUOP", OleDbType.VarChar,10);
            param_Employee_Master[20].Value = BloodGroup;
            param_Employee_Master[21] = new OleDbParameter("mobile", OleDbType.VarChar,30);
            param_Employee_Master[21].Value = Mobile;
            param_Employee_Master[22] = new OleDbParameter("MARRITALSTATUS", OleDbType.VarChar,25);
            param_Employee_Master[22].Value = MarritalStatus;
            param_Employee_Master[23] = new OleDbParameter("WIFENAME", OleDbType.VarChar,100);
            param_Employee_Master[23].Value = WifeName;
            param_Employee_Master[24] = new OleDbParameter("WIFEAGE", OleDbType.VarChar,10);
            param_Employee_Master[24].Value = WifeAge;
            param_Employee_Master[25] = new OleDbParameter("RELATIONWITHEMP", OleDbType.VarChar,10);
            param_Employee_Master[25].Value =RelationWithEmployee;
            param_Employee_Master[26] = new OleDbParameter("RELATIONNAME", OleDbType.VarChar,100);
            param_Employee_Master[26].Value = RelationName;
            param_Employee_Master[27] = new OleDbParameter("COURTPROCEEDING", OleDbType.VarChar,10);
            param_Employee_Master[27].Value = CourtProceeding;
            param_Employee_Master[28] = new OleDbParameter("DEATAILOFCOURTPROCEEDING", OleDbType.VarChar,250);
            param_Employee_Master[28].Value = DetailofCourtProceeding;
            param_Employee_Master[29] = new OleDbParameter("CONTAGIOUSDISEASE", OleDbType.VarChar,10);
            param_Employee_Master[29].Value = ContagiousDisease;

            param_Employee_Master[30] = new OleDbParameter("DEATAILOFCOURTPROCEEDING", OleDbType.VarChar,250);
            param_Employee_Master[30].Value = DetailOfContagiousDisease;

            param_Employee_Master[31] = new OleDbParameter("NAMOMINE", OleDbType.VarChar,100);
            param_Employee_Master[31].Value = NomineeName;

            param_Employee_Master[32] = new OleDbParameter("PANNO", OleDbType.VarChar,25);
            param_Employee_Master[32].Value = PANNO;

            param_Employee_Master[33] = new OleDbParameter("NAMEOFBANK", OleDbType.VarChar,100);
            param_Employee_Master[33].Value = NameOfBank;

            param_Employee_Master[34] = new OleDbParameter("LANGUAGEKNOWN", OleDbType.VarChar,100);
            param_Employee_Master[34].Value = LaguageKnown;

            


            param_Employee_Master[35] = new OleDbParameter("ADD_DATE", OleDbType.Date);
            param_Employee_Master[35].Value = DateTime.Now; 

           
            
            param_Employee_Master[36] = new OleDbParameter("ADD_USER_ID", OleDbType.VarChar,15);
            param_Employee_Master[36].Value = AddedBy;

            param_Employee_Master[37] = new OleDbParameter("ACTIVITYMANAGERID", OleDbType.VarChar,15);
            param_Employee_Master[37].Value = UserIDOfActivityManager;
                    
            param_Employee_Master[38] = new OleDbParameter("SUVIDHA_AC", OleDbType.VarChar, 50);
            param_Employee_Master[38].Value = ACNO;

            param_Employee_Master[39] = new OleDbParameter("CENTREID", OleDbType.VarChar, 15);
            param_Employee_Master[39].Value = CentreID;

            param_Employee_Master[40] = new OleDbParameter("SubcentreID", OleDbType.VarChar, 15);
            param_Employee_Master[40].Value = SubCentreID;
            param_Employee_Master[41] = new OleDbParameter("NomineeTitle", OleDbType.VarChar, 50);
            param_Employee_Master[41].Value = NominneTitle;
            param_Employee_Master[42] = new OleDbParameter("PhotoPath", OleDbType.VarChar, 250);
            param_Employee_Master[42].Value = PhotoPath;
            param_Employee_Master[43] = new OleDbParameter("Title", OleDbType.VarChar, 15);
            param_Employee_Master[43].Value = Title;
            param_Employee_Master[44] = new OleDbParameter("City", OleDbType.VarChar, 100);
            param_Employee_Master[44].Value = City;
            param_Employee_Master[45] = new OleDbParameter("Pin", OleDbType.VarChar, 10);
            param_Employee_Master[45].Value = Pin;
            param_Employee_Master[46] = new OleDbParameter("RelativeName", OleDbType.VarChar, 100);
            param_Employee_Master[46].Value = RelativeName;
            param_Employee_Master[47] = new OleDbParameter("RelativeName", OleDbType.VarChar, 15);
            param_Employee_Master[47].Value = RelativeCode;
            OleDbHelper.ExecuteNonQuery(sqlTrans, CommandType.Text, sSql1, param_Employee_Master);
            sSql1 = "insert into user_master (userid) values ('" + EmpID + "')";
            OleDbHelper.ExecuteNonQuery(sqlTrans, CommandType.Text, sSql1);
            sqlTrans.Commit();
            sqlConn.Close();
        }
        catch (System.Exception exp)
        {
            sqlTrans.Rollback();
            sqlConn.Close();
            throw new Exception("An error occurred while executing the Insert", exp);
        }
    }
    public void InsertOfficailDetail()
    {
        String sSql1 = "";
        String sSql2 = "";
        //Create and open Connection
        OleDbConnection sqlConn = new OleDbConnection(oCmn.ConnectionString);
        sqlConn.Open();
        //Create and open Transaction
        OleDbTransaction sqlTrans = sqlConn.BeginTransaction();
        try
        {
           
           
            //Employee Master Insert Query
            sSql1 = " UPDATE EMPLOYEE_MASTER SET   " +
                    " DOJ = ?, EMP_TYPE = ?, DESIGNATION_ID = ?,DEPARTMENT_ID = ?," +
                    " ACTIVITY_ID=?,CLIENT_ID=?,PRODUCT_ID=?, COMPANY_ID = ?, "+
                    " APPROVAL_MAIL_DATE=?,APPROVED_BY_OTHER=?," +
                    " MODIFY_DATE = ?, MODIFY_USER_ID = ?,USER_ID_ACTIVITYMANAGER=?  WHERE EMP_ID = ? ";

            OleDbParameter[] param_Employee_Master = new OleDbParameter[14];

            param_Employee_Master[0] = new OleDbParameter("DOJ", OleDbType.Date);
            if (DoJ != null)
                param_Employee_Master[0].Value = Convert.ToDateTime(oCmn.strDate(DoJ));
            else
                param_Employee_Master[0].Value = DoJ;
            param_Employee_Master[1] = new OleDbParameter("EMP_TYPE", OleDbType.VarChar, 50);
            param_Employee_Master[1].Value = EmpType;
            param_Employee_Master[2] = new OleDbParameter("DESIGNATION_ID", OleDbType.VarChar, 15);
            param_Employee_Master[2].Value = Designation;
            param_Employee_Master[3] = new OleDbParameter("DEPARTMENT_ID", OleDbType.VarChar, 15);
            param_Employee_Master[3].Value = Department;
            param_Employee_Master[4] = new OleDbParameter("ACTIVITY_ID", OleDbType.VarChar, 15);
            param_Employee_Master[4].Value = ActivityID;
            param_Employee_Master[5] = new OleDbParameter("CLIENT_ID", OleDbType.VarChar, 15);
            param_Employee_Master[5].Value = ClientID;
            param_Employee_Master[6] = new OleDbParameter("PRODUCT_ID", OleDbType.VarChar, 15);
            param_Employee_Master[6].Value =ProductID;
            param_Employee_Master[7] = new OleDbParameter("COMPANY_ID", OleDbType.VarChar, 15);
            param_Employee_Master[7].Value = CompanyID;
            param_Employee_Master[8] = new OleDbParameter("APPROVAL_MAIL_DATE", OleDbType.VarChar,50);
            param_Employee_Master[8].Value =ApprovalMailDate;


            param_Employee_Master[9] = new OleDbParameter("APPROVED_BY_OTHER", OleDbType.VarChar, 100);
            param_Employee_Master[9].Value = ApprovalByOther;
            param_Employee_Master[10] = new OleDbParameter("MODIFY_DATE", OleDbType.Date);
            param_Employee_Master[10].Value = DateTime.Now; ;
            param_Employee_Master[11] = new OleDbParameter("MODIFY_USER_ID", OleDbType.VarChar, 15);
            param_Employee_Master[11].Value = ModifyBy;
            param_Employee_Master[12] = new OleDbParameter("USER_ID_ACTIVITYMANAGER", OleDbType.VarChar, 15);
            param_Employee_Master[12].Value = UserIDOfActivityManager;
            param_Employee_Master[13] = new OleDbParameter("EMP_ID", OleDbType.VarChar, 15);
            param_Employee_Master[13].Value = EmpID;

            OleDbHelper.ExecuteNonQuery(sqlTrans, CommandType.Text, sSql1, param_Employee_Master);

            //sSql2 = "INSERT INTO EMPLOYEE_SALARY_DETAIL (Emp_id,HRA,Basic,SP_All,Gross_Amt) VALUES(?,?,?,?,?)";
            //OleDbParameter[] param = new OleDbParameter[5];
            //param[0] = new OleDbParameter("Emp_id", OleDbType.VarChar, 15);
            //param[0].Value = EmpID;
            //param[1] = new OleDbParameter("HRA", OleDbType.VarChar, 15);
            //param[1].Value = HRA;
            //param[2] = new OleDbParameter("Basic", OleDbType.VarChar, 15);
            //param[2].Value= Basic;
            //param[3] = new OleDbParameter("SPALL", OleDbType.VarChar, 15);
            //param[3].Value = SPAll;
            //param[4] = new OleDbParameter("Gross_Amt", OleDbType.VarChar, 15);
            //param[4].Value = GrossAmt;
            //OleDbHelper.ExecuteNonQuery(sqlTrans, CommandType.Text, sSql2, param);
            sqlTrans.Commit();
            sqlConn.Close();
           
        }
        catch (System.Exception exp)
        {
            sqlTrans.Rollback();
            sqlConn.Close();
            throw new Exception("An error occurred while executing the Update", exp);
        }

    }

    public void InsertChildDetail()
    {
        OleDbConnection sqlConn = new OleDbConnection(oCmn.ConnectionString);
        sqlConn.Open();
        OleDbTransaction sqlTrans = sqlConn.BeginTransaction();
        try
        {
            String sSql1 = "";
            
            sSql1 = "insert into EMPLOYEE_CHILDREN_DETAIL (Emp_id,Name,Age) values(?,?,?)";

            OleDbParameter[] param = new OleDbParameter[3];
            param[0] = new OleDbParameter("Emp_id", OleDbType.VarChar, 15);
            param[0].Value = EmpID;
            param[1] = new OleDbParameter("Name", OleDbType.VarChar, 250);
            param[1].Value = ChildName;
            param[2] = new OleDbParameter("Age", OleDbType.VarChar, 50);
            param[2].Value = ChildAge;

            OleDbHelper.ExecuteNonQuery(sqlTrans, CommandType.Text, sSql1, param);
            sqlTrans.Commit();
            sqlConn.Close();
        }
        catch (System.Exception exp)
        {
            sqlTrans.Rollback();
            sqlConn.Close();
            throw new Exception("An error occurred while executing the Insert", exp);
        }
     
    }
    public void InsertQualification()
    {
        OleDbConnection sqlConn = new OleDbConnection(oCmn.ConnectionString);
        sqlConn.Open();
        OleDbTransaction sqlTrans = sqlConn.BeginTransaction();
        try
        {
            String sSql1 = "";

            sSql1 = " insert into EMPLOYEE_EDUCATION_QUALIFICATION "+
                    " (Emp_id,Name_of_College,Duration_of_Education,Certificate_Examination,Div_Marks,Copies_Attached,File_Path,Type_of_Qualification) values(?,?,?,?,?,?,?,?)";

            OleDbParameter[] param = new OleDbParameter[8];
            param[0] = new OleDbParameter("Emp_id", OleDbType.VarChar, 15);
            param[0].Value = EmpID;
            param[1] = new OleDbParameter("Name_of_College", OleDbType.VarChar, 1000);
            param[1].Value = NameOfCollege;
            param[2] = new OleDbParameter("Duration_of_Education", OleDbType.VarChar, 250);
            param[2].Value = Duration;
            param[3] = new OleDbParameter("Certificate_Examination", OleDbType.VarChar, 1000);
            param[3].Value = CertifcateExam;
            param[4] = new OleDbParameter("Div_Marks", OleDbType.VarChar, 500);
            param[4].Value = DivMarks;
            param[5] = new OleDbParameter("Copies_Attached", OleDbType.VarChar, 10);
            param[5].Value = copyAttached;
            param[6] = new OleDbParameter("File_Path", OleDbType.VarChar, 1000);
            param[6].Value = FilePath;
            param[7] = new OleDbParameter("Type_of_Qualification", OleDbType.VarChar, 50);
            param[7].Value = TypeOfQualification;

            OleDbHelper.ExecuteNonQuery(sqlTrans, CommandType.Text, sSql1, param);
            sqlTrans.Commit();
            sqlConn.Close();
        }
        catch (System.Exception exp)
        {
            sqlTrans.Rollback();
            sqlConn.Close();
            throw new Exception("An error occurred while executing the Insert", exp);
        }
    }
    public void InsertEmployementDetail()
    {
        OleDbConnection sqlConn = new OleDbConnection(oCmn.ConnectionString);
        sqlConn.Open();
        OleDbTransaction sqlTrans = sqlConn.BeginTransaction();
        try
        {
            String sSql1 = "";

            sSql1 = " insert into EMPLOYEE_EMPLOYMENT_DETAIL " +
                    " (Emp_id,Employer_Name,Duration_of_Employment,Salary,Reason_of_Leaving,Designation_Nature_job,Contact_No) values(?,?,?,?,?,?,?)";

            OleDbParameter[] param = new OleDbParameter[7];
            param[0] = new OleDbParameter("Emp_id", OleDbType.VarChar, 15);
            param[0].Value = EmpID;
            param[1] = new OleDbParameter("Employer_Name", OleDbType.VarChar, 250);
            param[1].Value = EmployerName;
            param[2] = new OleDbParameter("Duration_of_Education", OleDbType.VarChar, 100);
            param[2].Value = EmployementDuration;
            param[3] = new OleDbParameter("Salary", OleDbType.VarChar, 50);
            param[3].Value = EmployementSalary;
            param[4] = new OleDbParameter("Reason_of_Leaving", OleDbType.VarChar, 250);
            param[4].Value = ReasonForLeaving;
            param[5] = new OleDbParameter("EmployementDesignation", OleDbType.VarChar, 100);
            param[5].Value = EmployementDesignation;
            param[6] = new OleDbParameter("EmployeeContact", OleDbType.VarChar, 30);
            param[6].Value = EmployementContactNo;

            OleDbHelper.ExecuteNonQuery(sqlTrans, CommandType.Text, sSql1, param);
            sqlTrans.Commit();
            sqlConn.Close();
        }
        catch (System.Exception exp)
        {
            sqlTrans.Rollback();
            sqlConn.Close();
            throw new Exception("An error occurred while executing the Insert", exp);
        }
    }
    public void InsertHobby()
    {
        OleDbConnection sqlConn = new OleDbConnection(oCmn.ConnectionString);
        sqlConn.Open();
        OleDbTransaction sqlTrans = sqlConn.BeginTransaction();
        try
        {
            String sSql1 = "";

            sSql1 = " insert into EMPLOYEE_HOBBY " +
                    " (Emp_id,Literary_Cultural_Art,Sports,Hobbies) values(?,?,?,?)";

            OleDbParameter[] param = new OleDbParameter[4];
            param[0] = new OleDbParameter("Emp_id", OleDbType.VarChar, 15);
            param[0].Value = EmpID;
            param[1] = new OleDbParameter("Literary_Cultural_Art", OleDbType.VarChar, 250);
            param[1].Value = LiteraryCulture;
            param[2] = new OleDbParameter("Sports", OleDbType.VarChar, 250);
            param[2].Value = Sport;
            param[3] = new OleDbParameter("Hobbies", OleDbType.VarChar, 50);
            param[3].Value = Hobbies;
            


            OleDbHelper.ExecuteNonQuery(sqlTrans, CommandType.Text, sSql1, param);
            sqlTrans.Commit();
            sqlConn.Close();
        }
        catch (System.Exception exp)
        {
            sqlTrans.Rollback();
            sqlConn.Close();
            throw new Exception("An error occurred while executing the Insert", exp);
        }
    }
    public void InsertReferenceDetail()
    {
        OleDbConnection sqlConn = new OleDbConnection(oCmn.ConnectionString);
        sqlConn.Open();
        OleDbTransaction sqlTrans = sqlConn.BeginTransaction();
        try
        {
            String sSql1 = "";

            sSql1 = " insert into EMPLOYEE_REFERENCE_DETAIL " +
                    " (Emp_id,Name,Address,Occupation,Relation,Contact_No) values(?,?,?,?,?,?)";

            OleDbParameter[] param = new OleDbParameter[6];
            param[0] = new OleDbParameter("Emp_id", OleDbType.VarChar, 15);
            param[0].Value = EmpID;
            param[1] = new OleDbParameter("Name", OleDbType.VarChar, 250);
            param[1].Value = ReferenceName;
            param[2] = new OleDbParameter("Address", OleDbType.VarChar, 100);
            param[2].Value = ReferenceAddress;
            param[3] = new OleDbParameter("Occupation", OleDbType.VarChar, 50);
            param[3].Value = ReferenceOccupation;
            param[4] = new OleDbParameter("Relation", OleDbType.VarChar, 750);
            param[4].Value = RefrenceRelation;
            param[5] = new OleDbParameter("Contact_No", OleDbType.VarChar, 250);
            param[5].Value = RefrenceContactNo;


            OleDbHelper.ExecuteNonQuery(sqlTrans, CommandType.Text, sSql1, param);
            sqlTrans.Commit();
            sqlConn.Close();
        }
        catch (System.Exception exp)
        {
            sqlTrans.Rollback();
            sqlConn.Close();
            throw new Exception("An error occurred while executing the Insert", exp);
        }
    }
    public DataSet GetEmployeeDetail(string strEmpID)
    {
        DataSet ds = new DataSet();
        OleDbConnection oledbConn = new OleDbConnection(oCmn.ConnectionString);
        string strSql = "";
        strSql = " SELECT EMP_CODE, NOMINNE_TITLE, USERID_OF_CLUSTER,USERID_OF_HO, TEMP_EMP_CODE, FIRSTNAME,MIDDLENAME,LASTNAME,GENDER,DOB,DOJ,ADD1,ADD2,ADD3,PR_ADD1,PR_ADD2,PR_ADD3,MOBILE, " +
                 " PHONE_R,EMP_TYPE,DESIGNATION_ID,DEPARTMENT_ID,CENTRE_ID,SUBCENTRE_ID,COMPANY_ID,SUVIDHA_AC,FATHER_NAME, " +
                 " HEIGHT,WEIGHT,BLOOD_GROUP,MARTAL_STATUS,WIFE_NAME,WIFE_AGE,KIT_RECEIVED_DATE,APPROVED_BY_CLUSTER,APPROVED_BY_HOHR, " +
                 " RELATION_WITH_EMPLOYEE,RELATION_NAME_WITH_EMPLOYEE,COURT_PROCEEDING,DETAIL_OF_COURT_PROCEEDING,CONTAGIOUS_DISEASE, " +
                 " CONTAGIOUS_DISEASE_DETAIL,NOMINEE_NAME,PAN#,NAME_OF_BANK,ACTIVITY_ID,CLIENT_ID,PRODUCT_ID,PHONE_PERMAENT_ADD, " +
                 " APPROVAL_MAIL_DATE,USERID_OF_CLUSTER,USERID_OF_HO,LANGUAGE_KNOWN,PF#,ESIC#,USER_ID_ACTIVITYMANAGER,APPROVED_BY_OTHER, " +
                 " PHOTO_PATH,Title,DOL,RELATIVE_NAME,RELATIVE_CODE,CITY,PIN,dol_reason FROM EMPLOYEE_MASTER WHERE EMP_ID='" + strEmpID + "' ";

        ds = OleDbHelper.ExecuteDataset(oledbConn, CommandType.Text, strSql);
        return ds;


    }
    public void UpdateEmployeeMaster()
    {
        String sSql1 = "";
        String sSql2 = "";
        //Create and open Connection
        OleDbConnection sqlConn = new OleDbConnection(oCmn.ConnectionString);
      
        sqlConn.Open();
      
        //Create and open Transaction
        OleDbTransaction sqlTrans = sqlConn.BeginTransaction();
        
        try
        {
            //To Get Unique CaseID
            
            if (FName != null)
                FullName = FName + " ";
            if (LName != null)
                FullName = FullName + MName + " ";
            if (LName != null)
                FullName = FullName + LName;

            FullName = FullName.Trim();

            //Case Master Insert Query
            sSql1 = " update  EMPLOYEE_MASTER SET FIRSTNAME=?, MIDDLENAME=?,  LASTNAME=?, FULLNAME=?, " +
                    " GENDER=?, DOB =?, ADD1=?, ADD2=?, ADD3=?,PHONE_R=?,PR_ADD1=?,PR_ADD2=?,PR_ADD3=?,PHONE_PERMAENT_ADD=?,FATHER_NAME=?,HEIGHT=?,WEIGHT=?,BLOOD_GROUP=?,MOBILE=?, " +
                    " MARTAL_STATUS=?,WIFE_NAME=?,WIFE_AGE=?,RELATION_WITH_EMPLOYEE=?,RELATION_NAME_WITH_EMPLOYEE=?," +
                    " COURT_PROCEEDING=?,DETAIL_OF_COURT_PROCEEDING=?,CONTAGIOUS_DISEASE=?,CONTAGIOUS_DISEASE_DETAIL=?,  " +
                    " NOMINEE_NAME=?,PAN#=?,NAME_OF_BANK=? ,LANGUAGE_KNOWN=? , MODIFY_DATE=?, MODIFY_USER_ID=?,USER_ID_ACTIVITYMANAGER=?,SUVIDHA_AC =?,NOMINNE_TITLE=?,PHOTO_PATH=?,Title=?,CITY=?,PIN=?,RELATIVE_NAME=?,RELATIVE_CODE=? where EMP_ID=? ";

                    
            

            OleDbParameter[] param_Employee_Master = new OleDbParameter[44];
            
            param_Employee_Master[0] = new OleDbParameter("FIRSTNAME", OleDbType.VarChar, 100);
            param_Employee_Master[0].Value = FName;
            param_Employee_Master[1] = new OleDbParameter("MIDDLENAME", OleDbType.VarChar, 100);
            param_Employee_Master[1].Value = MName;
            param_Employee_Master[2] = new OleDbParameter("LASTNAME", OleDbType.VarChar, 100);
            param_Employee_Master[2].Value = LName;
            param_Employee_Master[3] = new OleDbParameter("FULLNAME", OleDbType.VarChar, 200);
            param_Employee_Master[3].Value = FullName;
            param_Employee_Master[4] = new OleDbParameter("GENDER", OleDbType.VarChar, 1);
            param_Employee_Master[4].Value = Gender;
            param_Employee_Master[5] = new OleDbParameter("DOB", OleDbType.Date);
            if (DoB != null)
                param_Employee_Master[5].Value = Convert.ToDateTime(oCmn.strDate(DoB));
            else
                param_Employee_Master[5].Value = DoB;

            //param_Employee_Master[8] = new OleDbParameter("DOJ", OleDbType.Date);
            //if (DoJ != null)
            //    param_Employee_Master[8].Value = Convert.ToDateTime(oCmn.strDate(DoJ));
            //else
            //    param_Employee_Master[8].Value = DoJ;

            param_Employee_Master[6] = new OleDbParameter("PRESENTADD1", OleDbType.VarChar, 200);
            param_Employee_Master[6].Value = PresentAdd1;
            param_Employee_Master[7] = new OleDbParameter("PRESENTADD2", OleDbType.VarChar, 200);
            param_Employee_Master[7].Value = PresentAdd2;
            param_Employee_Master[8] = new OleDbParameter("PRESENTADD3", OleDbType.VarChar, 200);
            param_Employee_Master[8].Value = PresentAdd3;
            param_Employee_Master[9] = new OleDbParameter("PHONE_R", OleDbType.VarChar, 30);
            param_Employee_Master[9].Value = Phone;
            param_Employee_Master[10] = new OleDbParameter("PERMANENTADD1", OleDbType.VarChar, 200);
            param_Employee_Master[10].Value = PermanentAdd1;
            param_Employee_Master[11] = new OleDbParameter("PERMANENTADD2", OleDbType.VarChar, 200);
            param_Employee_Master[11].Value = PernanentAdd2;
            param_Employee_Master[12] = new OleDbParameter("PERMANENTADD3", OleDbType.VarChar, 200);
            param_Employee_Master[12].Value = PermanentAdd3;
            param_Employee_Master[13] = new OleDbParameter("PHONEPERMANENTADD", OleDbType.VarChar, 50);
            param_Employee_Master[13].Value = PhonePermanentAdd;
            param_Employee_Master[14] = new OleDbParameter("FATHERSNAME", OleDbType.VarChar, 100);
            param_Employee_Master[14].Value = FathersName;
            param_Employee_Master[15] = new OleDbParameter("HIEGHT", OleDbType.VarChar, 10);
            param_Employee_Master[15].Value = Hieght;
            param_Employee_Master[16] = new OleDbParameter("WEIGHT", OleDbType.VarChar, 10);
            param_Employee_Master[16].Value = Weight;
            param_Employee_Master[17] = new OleDbParameter("BLOODGRUOP", OleDbType.VarChar, 10);
            param_Employee_Master[17].Value = BloodGroup;
            param_Employee_Master[18] = new OleDbParameter("Mobile", OleDbType.VarChar, 30);
            param_Employee_Master[18].Value = Mobile;
            param_Employee_Master[19] = new OleDbParameter("MARRITALSTATUS", OleDbType.VarChar, 25);
            param_Employee_Master[19].Value = MarritalStatus;
            param_Employee_Master[20] = new OleDbParameter("WIFENAME", OleDbType.VarChar, 100);
            param_Employee_Master[20].Value = WifeName;
            param_Employee_Master[21] = new OleDbParameter("WIFEAGE", OleDbType.VarChar, 10);
            param_Employee_Master[21].Value = WifeAge;
            param_Employee_Master[22] = new OleDbParameter("RELATIONWITHEMP", OleDbType.VarChar, 10);
            param_Employee_Master[22].Value = RelationWithEmployee;
            param_Employee_Master[23] = new OleDbParameter("RELATIONNAME", OleDbType.VarChar, 100);
            param_Employee_Master[23].Value = RelationName;
            param_Employee_Master[24] = new OleDbParameter("COURTPROCEEDING", OleDbType.VarChar, 10);
            param_Employee_Master[24].Value = CourtProceeding;
            param_Employee_Master[25] = new OleDbParameter("DEATAILOFCOURTPROCEEDING", OleDbType.VarChar, 250);
            param_Employee_Master[25].Value = DetailofCourtProceeding;
            param_Employee_Master[26] = new OleDbParameter("CONTAGIOUSDISEASE", OleDbType.VarChar, 10);
            param_Employee_Master[26].Value = ContagiousDisease;

            param_Employee_Master[27] = new OleDbParameter("DEATAILOFCOURTPROCEEDING", OleDbType.VarChar, 250);
            param_Employee_Master[27].Value = DetailOfContagiousDisease;

            param_Employee_Master[28] = new OleDbParameter("NAMOMINE", OleDbType.VarChar, 100);
            param_Employee_Master[28].Value = NomineeName;

            param_Employee_Master[29] = new OleDbParameter("PANNO", OleDbType.VarChar, 25);
            param_Employee_Master[29].Value = PANNO;

            param_Employee_Master[30] = new OleDbParameter("NAMEOFBANK", OleDbType.VarChar, 100);
            param_Employee_Master[30].Value = NameOfBank;

            param_Employee_Master[31] = new OleDbParameter("LANGUAGEKNOWN", OleDbType.VarChar, 100);
            param_Employee_Master[31].Value = LaguageKnown;




            param_Employee_Master[32] = new OleDbParameter("MODIFY_DATE", OleDbType.Date);
            param_Employee_Master[32].Value = DateTime.Now;



            param_Employee_Master[33] = new OleDbParameter("MODIFY_USER_ID", OleDbType.VarChar, 15);
            param_Employee_Master[33].Value = ModifyBy;

            param_Employee_Master[34] = new OleDbParameter("ACTIVITYMANAGERID", OleDbType.VarChar, 15);
            param_Employee_Master[34].Value = UserIDOfActivityManager;

            param_Employee_Master[35] = new OleDbParameter("SUVIDHA_AC", OleDbType.VarChar, 50);
            param_Employee_Master[35].Value = ACNO;

           

            param_Employee_Master[36] = new OleDbParameter("NomineeTitle", OleDbType.VarChar, 50);
            param_Employee_Master[36].Value = NominneTitle;

            param_Employee_Master[37] = new OleDbParameter("PhotoPath", OleDbType.VarChar, 250);
            param_Employee_Master[37].Value = PhotoPath;

            param_Employee_Master[38] = new OleDbParameter("Title", OleDbType.VarChar, 15);
            param_Employee_Master[38].Value = Title;
            param_Employee_Master[39] = new OleDbParameter("CITY", OleDbType.VarChar, 100);
            param_Employee_Master[39].Value = City;
            param_Employee_Master[40] = new OleDbParameter("Pin", OleDbType.VarChar, 10);
            param_Employee_Master[40].Value = Pin;
            param_Employee_Master[41] = new OleDbParameter("RelativeName", OleDbType.VarChar, 100);
            param_Employee_Master[41].Value = RelativeName;
            param_Employee_Master[42] = new OleDbParameter("RelativeCode", OleDbType.VarChar, 15);
            param_Employee_Master[42].Value = RelativeCode;


            param_Employee_Master[43] = new OleDbParameter("EMPID", OleDbType.VarChar, 15);
            param_Employee_Master[43].Value = EmpID;
            OleDbHelper.ExecuteNonQuery(sqlTrans, CommandType.Text, sSql1, param_Employee_Master);

            sqlTrans.Commit();
            sqlConn.Close();
        }
        catch (System.Exception exp)
        {
            sqlTrans.Rollback();
            sqlConn.Close();
            throw new Exception("An error occurred while executing the Insert", exp);
        }
    }
    public DataSet GetSalary(string strEmpID)
    {
        DataSet ds = new DataSet();
        OleDbConnection oledbConn = new OleDbConnection(oCmn.ConnectionString);
        string strSql = "select Salary_Detail_id,HRA,Basic,SP_All,Gross_Amt from EMPLOYEE_SALARY_DETAIL where emp_id = '"+ strEmpID+"' ";
        ds = OleDbHelper.ExecuteDataset(oledbConn, CommandType.Text, strSql);
        return ds;
    }
    public void UpdateSalary()
    {
        OleDbConnection sqlConn = new OleDbConnection(oCmn.ConnectionString);
        sqlConn.Open();
        OleDbTransaction sqlTrans = sqlConn.BeginTransaction();
        try
        {
            

           string  sSql2 = "update  EMPLOYEE_SALARY_DETAIL set HRA=?,Basic=?,SP_All=?,Gross_Amt=? where emp_id=? ";
            OleDbParameter[] param = new OleDbParameter[5];
          
            param[0] = new OleDbParameter("HRA", OleDbType.VarChar, 15);
            param[0].Value = HRA;
            param[1] = new OleDbParameter("Basic", OleDbType.VarChar, 15);
            param[1].Value = Basic;
            param[2] = new OleDbParameter("SPALL", OleDbType.VarChar, 15);
            param[2].Value = SPAll;
            param[3] = new OleDbParameter("Gross_Amt", OleDbType.VarChar, 15);
            param[3].Value = GrossAmt;
            param[4] = new OleDbParameter("Emp_id", OleDbType.VarChar, 15);
            param[4].Value = EmpID;
            OleDbHelper.ExecuteNonQuery(sqlTrans, CommandType.Text, sSql2, param);
            sqlTrans.Commit();
            sqlConn.Close();
        }
        catch (Exception ex)
        {
            sqlTrans.Rollback();
            sqlConn.Close();
        }
    }
    public void InsertSalary()
    {
        OleDbConnection sqlConn = new OleDbConnection(oCmn.ConnectionString);
        sqlConn.Open();
        //Create and open Transaction
        OleDbTransaction sqlTrans = sqlConn.BeginTransaction();
        try
        {
           string sSql2 = "INSERT INTO EMPLOYEE_SALARY_DETAIL (Emp_id,HRA,Basic,SP_All,Gross_Amt) VALUES(?,?,?,?,?)";
            OleDbParameter[] param = new OleDbParameter[5];
            param[0] = new OleDbParameter("Emp_id", OleDbType.VarChar, 15);
            param[0].Value = EmpID;
            param[1] = new OleDbParameter("HRA", OleDbType.VarChar, 15);
            param[1].Value = HRA;
            param[2] = new OleDbParameter("Basic", OleDbType.VarChar, 15);
            param[2].Value = Basic;
            param[3] = new OleDbParameter("SPALL", OleDbType.VarChar, 15);
            param[3].Value = SPAll;
            param[4] = new OleDbParameter("Gross_Amt", OleDbType.VarChar, 15);
            param[4].Value = GrossAmt;
            OleDbHelper.ExecuteNonQuery(sqlTrans, CommandType.Text, sSql2, param);
            sqlTrans.Commit();
            sqlConn.Close();
        }
        catch (Exception ex)
        {
            sqlTrans.Rollback();
            sqlConn.Close();
            
        }
    }

    public DataSet GetChildDetail(string strEmpID)
    {
        DataSet ds = new DataSet();
        OleDbConnection sqlConn = new OleDbConnection(oCmn.ConnectionString);
        sqlConn.Open();
        string strSql = "select Name as [Child Name],Age as [Child Age] from  EMPLOYEE_CHILDREN_DETAIL where Emp_id='" + strEmpID + "' ";
       ds = OleDbHelper.ExecuteDataset(sqlConn, CommandType.Text, strSql);
       return ds;
    }

    //Update and delete for Child Information
    public void UpdateChildDetail()
    {
        OleDbConnection sqlConn = new OleDbConnection(oCmn.ConnectionString);
        sqlConn.Open();
        OleDbTransaction sqlTrans = sqlConn.BeginTransaction();
        try
        {
            String sSql1 = "";

            sSql1 = "update  EMPLOYEE_CHILDREN_DETAIL set Name=?,Age=? where  emp_id=? and Children_Detail_Id=?";

            OleDbParameter[] param = new OleDbParameter[4];
           
            param[0] = new OleDbParameter("Name", OleDbType.VarChar, 250);
            param[0].Value = ChildName;
            param[1] = new OleDbParameter("Age", OleDbType.VarChar, 50);
            param[1].Value = ChildAge;
            param[2] = new OleDbParameter("Emp_id", OleDbType.VarChar,15);
            param[2].Value = EmpID;
            param[3] = new OleDbParameter("Children_Detail_Id", OleDbType.Integer);
            param[3].Value = ChildrenDetailId;
            OleDbHelper.ExecuteNonQuery(sqlTrans, CommandType.Text, sSql1, param);
            sqlTrans.Commit();
            sqlConn.Close();
        }
        catch (System.Exception exp)
        {
            sqlTrans.Rollback();
            sqlConn.Close();
            throw new Exception("An error occurred while executing the Insert", exp);
        }
    }
    public void DeleteChildInfo(String strEMPID)
    {
        OleDbConnection sqlConn = new OleDbConnection(oCmn.ConnectionString);
        sqlConn.Open();
       
        try
        {
             String sSql1 = "";
             sSql1 = "delete from EMPLOYEE_CHILDREN_DETAIL where emp_id='" + strEMPID + "' ";
             OleDbHelper.ExecuteNonQuery(sqlConn, CommandType.Text, sSql1);
        }
        catch (Exception ex)
        {
 
        }
    }
    //Update and delete for Qualification
    public DataSet GetQualificationDetail(string strEmpID, int i)
    {
        DataSet ds = new DataSet();
        OleDbConnection sqlConn = new OleDbConnection(oCmn.ConnectionString);
        sqlConn.Open();
        string strSql = " select EM.TEMP_EMP_CODE, Name_of_College,Duration_of_Education,Certificate_Examination,Div_Marks ,Copies_Attached,File_Path,Type_of_Qualification from " +
                        " EMPLOYEE_EDUCATION_QUALIFICATION EDQ INNER JOIN EMPLOYEE_MASTER EM ON(EDQ.EMP_ID=EM.EMP_ID) where EDQ.Emp_id='" + strEmpID + "' and Education_Qualification_Id =" + i;
        ds = OleDbHelper.ExecuteDataset(sqlConn, CommandType.Text, strSql);
        return ds;
    }
    public void UpdateQualificationDetail()
    {
        OleDbConnection sqlConn = new OleDbConnection(oCmn.ConnectionString);
        sqlConn.Open();
        OleDbTransaction sqlTrans = sqlConn.BeginTransaction();
        try
        {
            String sSql1 = "";

            sSql1 = " update  EMPLOYEE_EDUCATION_QUALIFICATION set Name_of_College=?,Duration_of_Education=?,"+
                    " Certificate_Examination=?,Div_Marks=?,Copies_Attached=?,File_Path=?,Type_of_Qualification=? where  emp_id=? and Education_Qualification_Id=?";

            OleDbParameter[] param = new OleDbParameter[9];

            param[0] = new OleDbParameter("Name_of_College", OleDbType.VarChar, 250);
            param[0].Value = NameOfCollege;
            param[1] = new OleDbParameter("Duration_of_Education", OleDbType.VarChar, 250);
            param[1].Value = Duration;
            param[2] = new OleDbParameter("Certificate_Examination", OleDbType.VarChar,100);
            param[2].Value = CertifcateExam;
            param[3] = new OleDbParameter("Div_Marks", OleDbType.VarChar, 50);
            param[3].Value = DivMarks;
            param[4] = new OleDbParameter("Copies_Attached", OleDbType.VarChar, 10);
            param[4].Value = copyAttached;
            param[5] = new OleDbParameter("File_Path", OleDbType.VarChar, 250);
            param[5].Value = FilePath;
            param[6] = new OleDbParameter("Type_of_Qualification", OleDbType.VarChar, 50);
            param[6].Value = TypeOfQualification;
            param[7] = new OleDbParameter("emp_id", OleDbType.VarChar, 15);
            param[7].Value = EmpID;
            param[8] = new OleDbParameter("Education_Qualification_Id", OleDbType.Integer);
            param[8].Value = QualificationDetailId;
            OleDbHelper.ExecuteNonQuery(sqlTrans, CommandType.Text, sSql1, param);
            sqlTrans.Commit();
            sqlConn.Close();
        }
        catch (System.Exception exp)
        {
            sqlTrans.Rollback();
            sqlConn.Close();
            throw new Exception("An error occurred while executing the Update", exp);
        }
    }
    public void DeleteQualificationInfo(String strEMPID, int iQualificationID)
    {
        OleDbConnection sqlConn = new OleDbConnection(oCmn.ConnectionString);
        sqlConn.Open();

        try
        {
            String sSql1 = "";
            sSql1 = "delete from EMPLOYEE_EDUCATION_QUALIFICATION where emp_id=" + strEMPID + " and Education_Qualification_Id=" + iQualificationID;
            OleDbHelper.ExecuteNonQuery(sqlConn, CommandType.Text, sSql1);
        }
        catch (Exception ex)
        {

        }
    }
    //Update and delete for Employement
    public DataSet GetEmployementDetail(string strEmpID, int i)
    {
        DataSet ds = new DataSet();
        OleDbConnection sqlConn = new OleDbConnection(oCmn.ConnectionString);
        sqlConn.Open();
        string strSql = " select Employer_Name,Duration_of_Employment,Salary,Reason_of_Leaving ,Designation_Nature_job,Contact_No from " +
                        " EMPLOYEE_EMPLOYMENT_DETAIL where Emp_id='" + strEmpID + "' and Employement_Detail_Id =" + i;
        ds = OleDbHelper.ExecuteDataset(sqlConn, CommandType.Text, strSql);
        return ds;
    }
    public void UpdateEmployementDetail()
    {
        OleDbConnection sqlConn = new OleDbConnection(oCmn.ConnectionString);
        sqlConn.Open();
        OleDbTransaction sqlTrans = sqlConn.BeginTransaction();
        try
        {
            String sSql1 = "";

            sSql1 = " update  EMPLOYEE_EMPLOYMENT_DETAIL set Employer_Name=?,Duration_of_Employment=?," +
                    " Salary=?,Reason_of_Leaving=?,Designation_Nature_job=?,Contact_No=? where  emp_id=? and Employement_Detail_Id=?";

            OleDbParameter[] param = new OleDbParameter[8];

            param[0] = new OleDbParameter("Employer_Name", OleDbType.VarChar, 250);
            param[0].Value = EmployerName;
            param[1] = new OleDbParameter("Duration_of_Employment", OleDbType.VarChar, 250);
            param[1].Value = EmployementDuration;
            param[2] = new OleDbParameter("Salary", OleDbType.VarChar, 100);
            param[2].Value =EmployementSalary;
            param[3] = new OleDbParameter("Reason_of_Leaving", OleDbType.VarChar, 50);
            param[3].Value = ReasonForLeaving;
            param[4] = new OleDbParameter("Designation_Nature_job", OleDbType.VarChar, 10);
            param[4].Value = EmployementDesignation;
            param[5] = new OleDbParameter("Employement_Contact_no", OleDbType.VarChar, 30);
            param[5].Value = EmployementContactNo;
            param[6] = new OleDbParameter("emp_id", OleDbType.VarChar, 15);
            param[6].Value = EmpID;
            param[7] = new OleDbParameter("Education_Qualification_Id", OleDbType.Integer);
            param[7].Value = EmployementDetailId;
            OleDbHelper.ExecuteNonQuery(sqlTrans, CommandType.Text, sSql1, param);
            sqlTrans.Commit();
            sqlConn.Close();
        }
        catch (System.Exception exp)
        {
            sqlTrans.Rollback();
            sqlConn.Close();
            throw new Exception("An error occurred while executing the Update", exp);
        }
    }
    public void DeleteEmployementInfo(String strEMPID, int iEmployementID)
    {
        OleDbConnection sqlConn = new OleDbConnection(oCmn.ConnectionString);
        sqlConn.Open();

        try
        {
            String sSql1 = "";
            sSql1 = "delete from EMPLOYEE_EMPLOYMENT_DETAIL where emp_id='" + strEMPID + "' and Employement_Detail_Id=" + iEmployementID;
            OleDbHelper.ExecuteNonQuery(sqlConn, CommandType.Text, sSql1);
        }
        catch (Exception ex)
        {

        }
    }
    //Update and delete for Hobby
    public DataSet GetHobbyDetail(string strEmpID, int i)
    {
        DataSet ds = new DataSet();
        OleDbConnection sqlConn = new OleDbConnection(oCmn.ConnectionString);
        sqlConn.Open();
        string strSql = " select Literary_Cultural_Art,Sports,Hobbies from " +
                        " EMPLOYEE_HOBBY where Emp_id='" + strEmpID + "' and Hobby_Interest_Detail_id =" + i;
        ds = OleDbHelper.ExecuteDataset(sqlConn, CommandType.Text, strSql);
        return ds;
    }
    public void UpdateHobbyDetail()
    {
        OleDbConnection sqlConn = new OleDbConnection(oCmn.ConnectionString);
        sqlConn.Open();
        OleDbTransaction sqlTrans = sqlConn.BeginTransaction();
        try
        {
            String sSql1 = "";

            sSql1 = " update  EMPLOYEE_HOBBY set Literary_Cultural_Art=?,Sports=?," +
                    " Hobbies=? where  emp_id=? and Hobby_Interest_Detail_id=?";

            OleDbParameter[] param = new OleDbParameter[5];

            param[0] = new OleDbParameter("Literary_Cultural_Art", OleDbType.VarChar, 250);
            param[0].Value = LiteraryCulture;
            param[1] = new OleDbParameter("Sports", OleDbType.VarChar, 250);
            param[1].Value = Sport;
            param[2] = new OleDbParameter("Hobbies", OleDbType.VarChar, 250);
            param[2].Value = Hobbies;
          

            param[3] = new OleDbParameter("emp_id", OleDbType.VarChar, 15);
            param[3].Value = EmpID;
            param[4] = new OleDbParameter("Hobby_Interest_Detail_id", OleDbType.Integer);
            param[4].Value = HobbytDetailId;
            OleDbHelper.ExecuteNonQuery(sqlTrans, CommandType.Text, sSql1, param);
            sqlTrans.Commit();
            sqlConn.Close();
        }
        catch (System.Exception exp)
        {
            sqlTrans.Rollback();
            sqlConn.Close();
            throw new Exception("An error occurred while executing the Update", exp);
        }
    }
    public void DeleteHobbyInfo(String strEMPID, int iHobbyID)
    {
        OleDbConnection sqlConn = new OleDbConnection(oCmn.ConnectionString);
        sqlConn.Open();

        try
        {
            String sSql1 = "";
            sSql1 = "delete from EMPLOYEE_HOBBY where emp_id='" + strEMPID + "' and Hobby_Interest_Detail_id=" + iHobbyID;
            OleDbHelper.ExecuteNonQuery(sqlConn, CommandType.Text, sSql1);
        }
        catch (Exception ex)
        {

        }
    }
    //Update and delete for reference 
    public DataSet GetReferenceDetail(string strEmpID, int i)
    {
        DataSet ds = new DataSet();
        OleDbConnection sqlConn = new OleDbConnection(oCmn.ConnectionString);
        sqlConn.Open();
        string strSql = " select Name,Address ,Occupation ,Relation,Contact_No from " +
                        " EMPLOYEE_REFERENCE_DETAIL where Emp_id='" + strEmpID + "' and Reference_Detail_id =" + i;
        ds = OleDbHelper.ExecuteDataset(sqlConn, CommandType.Text, strSql);
        return ds;
    }
    public void UpdateReferenceDetail()
    {
        OleDbConnection sqlConn = new OleDbConnection(oCmn.ConnectionString);
        sqlConn.Open();
        OleDbTransaction sqlTrans = sqlConn.BeginTransaction();
        try
        {
            String sSql1 = "";

            sSql1 = " update  EMPLOYEE_REFERENCE_DETAIL set Name=?,Address=?," +
                    " Occupation=?,Relation=?,Contact_No=? where  emp_id=? and Reference_Detail_id=?";

            OleDbParameter[] param = new OleDbParameter[7];

            param[0] = new OleDbParameter("Name", OleDbType.VarChar, 250);
            param[0].Value = ReferenceName;
            param[1] = new OleDbParameter("Address", OleDbType.VarChar, 750);
            param[1].Value = ReferenceAddress;
            param[2] = new OleDbParameter("Occupation", OleDbType.VarChar, 250);
            param[2].Value = ReferenceOccupation;
            param[3] = new OleDbParameter("Relation", OleDbType.VarChar, 250);
            param[3].Value = RefrenceRelation;
            param[4] = new OleDbParameter("Contact_No", OleDbType.VarChar, 250);
            param[4].Value = RefrenceContactNo;

            param[5] = new OleDbParameter("emp_id", OleDbType.VarChar, 15);
            param[5].Value = EmpID;
            param[6] = new OleDbParameter("Reference_Detail_id", OleDbType.Integer);
            param[6].Value = ReferencetDetailId;
            OleDbHelper.ExecuteNonQuery(sqlTrans, CommandType.Text, sSql1, param);
            sqlTrans.Commit();
            sqlConn.Close();
        }
        catch (System.Exception exp)
        {
            sqlTrans.Rollback();
            sqlConn.Close();
            throw new Exception("An error occurred while executing the Update", exp);
        }
    }

    public void DeleteReferenceInfo(String strEMPID, int iReferenceID)
    {
        OleDbConnection sqlConn = new OleDbConnection(oCmn.ConnectionString);
        sqlConn.Open();

        try
        {
            String sSql1 = "";
            sSql1 = "delete from EMPLOYEE_REFERENCE_DETAIL where emp_id=" + strEMPID + " and Reference_Detail_id=" + iReferenceID;
            OleDbHelper.ExecuteNonQuery(sqlConn, CommandType.Text, sSql1);
        }
        catch (Exception ex)
        {

        }
    }

   
}
