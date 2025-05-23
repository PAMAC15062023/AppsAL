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
/// Summary description for CRL_VisitVerification
/// </summary>
public class CRL_VisitVerification
{
    CCommon objCmn = new CCommon();
	public CRL_VisitVerification()
	{
        objCmn = new CCommon();
    }

    #region common Property form RV & BV
    private string sSupervisorComment;
    public string SupervisorComment
    {
        get { return sSupervisorComment; }
        set { sSupervisorComment = value; }
    }

    private string sAttemptDateTime;
    public string AttemptDateTime
    {
        get { return sAttemptDateTime; }
        set { sAttemptDateTime = value; }
    }

    private string sRemark;
    public string Remark
    {
        get { return sRemark; }
        set { sRemark = value; }
    }

    private string sSubRemark;
    public string SubRemark
    {
        get { return sSubRemark; }
        set { sSubRemark = value; }
    }

    private string sVerifierID;
    public string VerifierID
    {
        get { return sVerifierID; }
        set { sVerifierID = value; }
    }

    private string sVerifier;
    public string Verifier
    {
        get { return sVerifier; }
        set { sVerifier = value; }
    }
    private string sRoofType;
    public string RoofType
    {
        get { return sRoofType; }
        set { sRoofType = value; }
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

    public string ModifyBy
    {
        get { return sModifiedBy; }
        set { sModifiedBy = value; }
    }
    //---------------------------------------
    //added by hemangi kambli on 01/10/2007 ----
    private string sTypeOfRoof;
    public string TypeOfRoof
    {
        get { return sTypeOfRoof; }
        set { sTypeOfRoof = value; }
    }
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

    private string sCaseId;
    public string CaseId
    {
        get { return sCaseId; }
        set { sCaseId = value; }
    }

    private string sVerificationTypeId;
    public string VerificationTypeId
    {
        get { return sVerificationTypeId; }
        set { sVerificationTypeId = value; }
    }

    private string sDateTimeOfVerification;
    public string DateTimeOfVerification
    {
        get { return sDateTimeOfVerification; }
        set { sDateTimeOfVerification = value; }
    }

    private string sVerifierName;
    public string VerifierName
    {
        get { return sVerifierName; }
        set { sVerifierName = value; }
    }
    private string sNameOfPersonMet;
    public string NameOfPersonMet
    {
        get { return sNameOfPersonMet; }
        set { sNameOfPersonMet = value; }
    }

    private string sLandmark;
    public string Landmark
    {
        get { return sLandmark; }
        set { sLandmark = value; }
    }

    private string sTeleNoType;
    public string TeleNoType
    {
        get { return sTeleNoType; }
        set { sTeleNoType = value; }
    }

    private string sMobileNoType;
    public string MobileNoType
    {
        get { return sMobileNoType; }
        set { sMobileNoType = value; }
    }

    private string sLoanAmount;
    public string LoanAmount
    {
        get { return sLoanAmount; }
        set { sLoanAmount = value; }
    }

    private string sUseOfLoan;
    public string UseOfLoan
    {
        get { return sUseOfLoan; }
        set { sUseOfLoan = value; }
    }

    private string sProduct;
    public string Product
    {
        get { return sProduct; }
        set { sProduct = value; }
    }

    private string sLocationOfProduct;
    public string LocationOfProduct
    {
        get { return sLocationOfProduct; }
        set { sLocationOfProduct = value; }
    }

    private string sDOB;
    public string DateOfBirth
    {
        get { return sDOB; }
        set { sDOB = value; }
    }

    private string sMaritalStatus;
    public string MaritalStatus
    {
        get { return sMaritalStatus; }
        set { sMaritalStatus = value; }
    }

    private string sEducation;
    public string Education
    {
        get { return sEducation; }
        set { sEducation = value; }
    }

    private string sLoanCancellation;
    public string LoanCancellation
    {
        get { return sLoanCancellation; }
        set { sLoanCancellation = value; }
    }

    private string sAnyCreditCard;
    public string AnyCreditCard
    {
        get { return sAnyCreditCard; }
        set { sAnyCreditCard = value; }
    }

    private string sAnyOtherLoan;
    public string AnyOtherLoan
    {
        get { return sAnyOtherLoan; }
        set { sAnyOtherLoan = value; }
    }

    private string sAssets;
    public string Assets
    {
        get { return sAssets; }
        set { sAssets = value; }
    }

    private string sVisibleItem;
    public string VisibleItem
    {
        get { return sVisibleItem; }
        set { sVisibleItem = value; }
    }

    private string sDetailsOfFurnitureSeen;
    public string DetailsOfFurnitureSeen
    {
        get { return sDetailsOfFurnitureSeen; }
        set { sDetailsOfFurnitureSeen = value; }
    }

    private string sLocality;
    public string Locality
    {
        get { return sLocality; }
        set { sLocality = value; }
    }

    private string sNameOfNeighbour1;
    public string NameOfNeighbour1
    {
        get { return sNameOfNeighbour1; }
        set { sNameOfNeighbour1 = value; }
    }

    private string sAddressOfNeighbour1;
    public string AddressOfNeighbour1
    {
        get { return sAddressOfNeighbour1; }
        set { sAddressOfNeighbour1 = value; }
    }

    private string sDoesAppWorkHere1;
    public string DoesAppWorkHere1
    {
        get { return sDoesAppWorkHere1; }
        set { sDoesAppWorkHere1 = value; }
    }

    private string sMthsOfWorkAtOffice1;
    public string MthsOfWorkAtOffice1
    {
        get { return sMthsOfWorkAtOffice1; }
        set { sMthsOfWorkAtOffice1 = value; }
    }

    private string sNameOfNeighbour2;
    public string NameOfNeighbour2
    {
        get { return sNameOfNeighbour2; }
        set { sNameOfNeighbour2 = value; }
    }

    private string sAddressOfNeighbour2;
    public string AddressOfNeighbour2
    {
        get { return sAddressOfNeighbour2; }
        set { sAddressOfNeighbour2 = value; }
    }

    private string sDoesAppWorkHere2;
    public string DoesAppWorkHere2
    {
        get { return sDoesAppWorkHere2; }
        set { sDoesAppWorkHere2 = value; }
    }

    private string sMthsOfWorkAtOffice2;
    public string MthsOfWorkAtOffice2
    {
        get { return sMthsOfWorkAtOffice2; }
        set { sMthsOfWorkAtOffice2 = value; }
    }

    private string sTypeOfAccmodation;
    public string TypeOfAccmodation
    {
        get { return sTypeOfAccmodation; }
        set { sTypeOfAccmodation = value; }
    }

    private string sEntryPermitted;
    public string EntryPermitted
    {
        get { return sEntryPermitted; }
        set { sEntryPermitted = value; }
    }

    private string sIsIdentityProofSeen;
    public string IsIdentityProofSeen
    {
        get { return sIsIdentityProofSeen; }
        set { sIsIdentityProofSeen = value; }
    }

    private string sOtherInvestment;
    public string OtherInvestment
    {
        get { return sOtherInvestment; }
        set { sOtherInvestment = value; }
    }

    private string sPurposeOfLoanTaken;
    public string PurposeOfLoanTaken
    {
        get { return sPurposeOfLoanTaken; }
        set { sPurposeOfLoanTaken = value; }
    }

    private string sEducationalBackground;
    public string EducationalBackground
    {
        get { return sEducationalBackground; }
        set { sEducationalBackground = value; }
    }

    private string sClourOnDoor;
    public string ClourOnDoor
    {
        get { return sClourOnDoor; }
        set { sClourOnDoor = value; }
    }

    private string sMatchInNegativeList;
    public string MatchInNegativeList
    {
        get { return sMatchInNegativeList; }
        set { sMatchInNegativeList = value; }
    }

    private string sNeighbourhoodLocality;
    public string NeighbourhoodLocality
    {
        get { return sNeighbourhoodLocality; }
        set { sNeighbourhoodLocality = value; }
    }

    private string sIsAddOfAppSame;
    public string IsAddOfAppSame
    {
        get { return sIsAddOfAppSame; }
        set { sIsAddOfAppSame = value; }
    }

    private string sIsCompanyNameBoardSeen;
    public string IsCompanyNameBoardSeen
    {
        get { return sIsCompanyNameBoardSeen; }
        set { sIsCompanyNameBoardSeen = value; }
    }

    private string sNoOfMembers;
    public string NoOfMembers
    {
        get { return sNoOfMembers; }
        set { sNoOfMembers = value; }
    }

    private string sAgeOfApplicant;
    public string AgeOfApplicant
    {
        get { return sAgeOfApplicant; }
        set { sAgeOfApplicant = value; }
    }

    private string sNameAddOfThirdParty;
    public string NameAddOfThirdParty
    {
        get { return sNameAddOfThirdParty; }
        set { sNameAddOfThirdParty = value; }
    }

    private string sThirdPartyComments;
    public string ThirdPartyComments
    {
        get { return sThirdPartyComments; }
        set { sThirdPartyComments = value; }
    }

    private string sIsNegativeArea;
    public string IsNegativeArea
    {
        get { return sIsNegativeArea; }
        set { sIsNegativeArea = value; }
    }

    private string sIsAffilatedToPoliticalParty;
    public string IsAffilatedToPoliticalParty
    {
        get { return sIsAffilatedToPoliticalParty; }
        set { sIsAffilatedToPoliticalParty = value; }
    }

    private string sProfile;
    public string Profile
    {
        get { return sProfile; }
        set { sProfile = value; }
    }

   
    #endregion
    
    #region PropertyDeclaration for RV
    private string sSepBathroom;
    public string SeparateBathroom
    {
        get { return sSepBathroom; }
        set { sSepBathroom = value; }
    }

    private string sFamilySeen;
    public string FamilySeen
    {
        get { return sFamilySeen; }
        set { sFamilySeen = value; }
    }


    private string sAppName;
    public string ApplicantName
    {
        get { return sAppName; }
        set { sAppName = value; }
    }

    private string sFatherSpouseName;
    public string FatherSpouseName
    {
        get { return sFatherSpouseName; }
        set { sFatherSpouseName = value; }
    }

    private string sAgencyCode;
    public string AgencyCode
    {
        get { return sAgencyCode; }
        set { sAgencyCode = value; }
    }

    private string sIfDoctors;
    public string IfDoctors
    {
        get { return sIfDoctors; }
        set { sIfDoctors = value; }
    }
    private string sNoOfPatientsPerDay;
    public string NoOfPatientsPerDay
    {
        get { return sNoOfPatientsPerDay; }
        set { sNoOfPatientsPerDay = value; }
    }
    private string sAvgFeePerPatient;
    public string AvgFeePerPatient
    {
        get { return sAvgFeePerPatient; }
        set { sAvgFeePerPatient = value; }
    }
    private string sOtherClinicVisited;
    public string OtherClinicVisited
    {
        get { return sOtherClinicVisited; }
        set { sOtherClinicVisited = value; }
    }
    private string sNameOfClinic;
    public string NameOfClinic
    {
        get { return sNameOfClinic; }
        set { sNameOfClinic = value; }
    }
    private string sIfArchitectureCA;
    public string IfArchitectureCA
    {
        get { return sIfArchitectureCA; }
        set { sIfArchitectureCA = value; }
    }
    private string sIndependentlyYrs;
    public string IndependentlyYrs
    {
        get { return sIndependentlyYrs; }
        set { sIndependentlyYrs = value; }
    }
    private string sKeyClientName1;
    public string KeyClientName1
    {
        get { return sKeyClientName1; }
        set { sKeyClientName1 = value; }
    }
    private string sKeyClientName2;
    public string KeyClientName2
    {
        get { return sKeyClientName2; }
        set { sKeyClientName2 = value; }
    }
    private string sKeyClientName3;
    public string KeyClientName3
    {
        get { return sKeyClientName3; }
        set { sKeyClientName3 = value; }

    }
    private string sSocietyBoardSighted;
    public string SocietyBoardSighted
    {
        get { return sSocietyBoardSighted; }
        set { sSocietyBoardSighted = value; }
    }

    private string sMothersName;
    public string MothersName
    {
        get { return sMothersName; }
        set { sMothersName = value; }
    }

    private string sAddressOfCompany;
    public string AddressOfCompany
    {
        get { return sAddressOfCompany; }
        set { sAddressOfCompany = value; }
    }

    private string sNoOfEaringMembers;
    public string NoOfEaringMembers
    {
        get { return sNoOfEaringMembers; }
        set { sNoOfEaringMembers = value; }
    }

    private string sIfVehicleExist;
    public string IfVehicleExist
    {
        get { return sIfVehicleExist; }
        set { sIfVehicleExist = value; }
    }

    private string sVehicleType;
    public string VehicleType
    {
        get { return sVehicleType; }
        set { sVehicleType = value; }
    }


    private string sDoorLocked;
    public string DoorLocked
    {
        get { return sDoorLocked; }
        set { sDoorLocked = value; }
    }

    private string sRelationship;
    public string Relationship
    {
        get { return sRelationship; }
        set { sRelationship = value; }
    }

    private string sTotalYrsInCity;
    public string TotalYrsInCity
    {
        get { return sTotalYrsInCity; }
        set { sTotalYrsInCity = value; }
    }

    private string sNameAddOf1Reference;
    public string NameAddOf1Reference
    {
        get { return sNameAddOf1Reference; }
        set { sNameAddOf1Reference = value; }
    }


    private string sParkingFacility;
    public string ParkingFacility
    {
        get { return sParkingFacility; }
        set { sParkingFacility = value; }
    }

    private string sLocationOfHouse;
    public string LocationOfHouse
    {
        get { return sLocationOfHouse; }
        set { sLocationOfHouse = value; }
    }


    private string sAddress;
    public string Address
    {
        get { return sAddress; }
        set { sAddress = value; }
    }

    private string sCity;
    public string City
    {
        get { return sCity; }
        set { sCity = value; }
    }

    private string sIdentityProofSeen;
    public string IdentityProofSeen
    {
        get { return sIdentityProofSeen; }
        set { sIdentityProofSeen = value; }
    }

    private string sApproachToResidence;
    public string ApproachToResidence
    {
        get { return sApproachToResidence; }
        set { sApproachToResidence = value; }
    }

    private string sPinCode;
    public string PinCode
    {
        get { return sPinCode; }
        set { sPinCode = value; }
    }
    
    private string sFamilyDetails;
    public string FamilyDetails
    {
        get { return sFamilyDetails; }
        set { sFamilyDetails = value; }
    }

    private string sDetailsOfWorkingMemberSpouse;
    public string DetailsOfWorkingMemberSpouse
    {
        get { return sDetailsOfWorkingMemberSpouse; }
        set { sDetailsOfWorkingMemberSpouse = value; }
    }

    private string sInteriorConditions;
    public string InteriorConditions
    {
        get { return sInteriorConditions; }
        set { sInteriorConditions = value; }
    }

    private string sDetailsOfWorkingMembersOthers;
    public string DetailsOfWorkingMembersOthers
    {
        get { return sDetailsOfWorkingMembersOthers; }
        set { sDetailsOfWorkingMembersOthers = value; }
    }

    private string sAreaOfHouse;
    public string AreaOfHouse
    {
        get { return sAreaOfHouse; }
        set { sAreaOfHouse = value; }
    }

    private string sCityLimit;
    public string CityLimit
    {
        get { return sCityLimit;}
        set { sCityLimit = value; }
    }

    private string sCustomerSeen;
    public string CustomerSeen
    {
        get { return sCustomerSeen; }
        set { sCustomerSeen = value; }
    }

    private string sVehiOwn;
    public string VehiOwn
    {
        get { return sVehiOwn; }
        set { sVehiOwn = value; }
    }

    private string sBussPrem;
    public string BussPrem
    {
        get { return sBussPrem; }
        set { sBussPrem = value; }
    }

    private string sRefName;
    public string RefName
    {
        get { return sRefName; }
        set { sRefName = value; }
    }

    private string sRefAdd;
    public string RefAdd
    {
        get { return sRefAdd; }
        set { sRefAdd = value; }
    }

    private string sMonthTurn;
    public string MonthTurn
    {
        get { return sMonthTurn; }
        set { sMonthTurn = value; }
    }

    private string sNumberBed;
    public string NumberBed
    {
        get { return sNumberBed; }
        set { sNumberBed = value; }
    }

    private string sNeighCheck;
    public string NeighCheck
    {
        get { return sNeighCheck; }
        set { sNeighCheck = value; }
    }

    private string sClinicYear;
    public string ClinicYear
    {
        get { return sClinicYear; }
        set { sClinicYear = value; }
    }

    private string sSeparateResi;
    public string SeparateResi
    {
        get { return sSeparateResi; }
        set { sSeparateResi = value; }
    }

    private string sSeparateFactory;
    public string SeparateFactory
    {
        get { return sSeparateFactory; }
        set { sSeparateFactory = value; }
    }

    private string sSeparateEntrance;
    public string SeparateEntrance
    {
        get { return sSeparateEntrance; }
        set { sSeparateEntrance = value; }
    }

    private string sSeparateOffice;
    public string SeparateOffice
    {
        get { return sSeparateOffice; }
        set { sSeparateOffice = value; }
    }

    private string sOfficeLimit;
    public string OfficeLimit
    {
        get { return sOfficeLimit; }
        set { sOfficeLimit = value; }
    }

    private string sTypeJob;
    public string TypeJob
    {
        get { return sTypeJob; }
        set { sTypeJob = value; }
    }

    private string sAppliWork;
    public string AppliWork
    {
        get { return sAppliWork; }
        set { sAppliWork = value; }
    }

    private string sAppliJobTrans;
    public string AppliJobTrans
    {
        get { return sAppliJobTrans; }
        set { sAppliJobTrans = value; }
    }

    private string sOffExit;
    public string OffExit
    {
        get { return sOffExit; }
        set { sOffExit = value; }
    }
/// <summary>
/// //////////////add code for hdfcNoc////////////////
    private string sSellConfMem;
    public string SellConfMem
    {
        get { return sSellConfMem; }
        set { sSellConfMem = value; }
    }

    private string sSellTran;
    public string SellTran
    {
        get { return sSellTran; }
        set { sSellTran = value; }
    }

    private string sSellProp;
    public string SellProp
    {
        get { return sSellProp; }
        set { sSellProp = value; }
    }

    private string sFlatNo;
    public string FlatNo
    {
        get { return sFlatNo; }
        set { sFlatNo = value; }
    }

    private string sNameBuy;
    public string NameBuy
    {
        get { return sNameBuy; }
        set { sNameBuy = value; }
    }

    private string sSellKnow;
    public string SellKnow
    {
        get { return sSellKnow; }
        set { sSellKnow = value; }
    }

    private string sSellLoan;
    public string SellLoan
    {
        get { return sSellLoan; }
        set { sSellLoan = value; }
    }

    private string sOutLoan;
    public string OutLoan
    {
        get { return sOutLoan; }
        set { sOutLoan = value; }
    }

    private string sSellMorg;
    public string SellMorg
    {
        get { return sSellMorg; }
        set { sSellMorg = value; }
    }

    private string sAuthen;
    public string Authen
    {
        get { return sAuthen; }
        set { sAuthen = value; }
    }

    private string sSellDoc;
    public string SellDoc
    {
        get { return sSellDoc; }
        set { sSellDoc = value; }
    }

    private string sSellPhoto;
    public string SellPhoto
    {
        get { return sSellPhoto; }
        set { sSellPhoto = value; }
    }
    /////////////end code
/// </summary>
/// 
    private string sTotalFamIncome;
    public string TotalFamIncome
    {
        get { return sTotalFamIncome; }
        set { sTotalFamIncome = value; }
    }

    private string sNoOfYrsAtResidence;
    public string NoOfYrsAtResidence
    {
        get { return sNoOfYrsAtResidence; }
        set { sNoOfYrsAtResidence = value; }
    }

    private string sOwnershipOfResidence;
    public string OwnershipOfResidence
    {
        get { return sOwnershipOfResidence; }
        set { sOwnershipOfResidence = value; }
    }

    private string sStayingWithWhom;
    public string StayingWithWhom
    {
        get { return sStayingWithWhom; }
        set { sStayingWithWhom = value; }
    }

    private string sDSA;
    public string DSA
    {
        get { return sDSA; }
        set { sDSA = value; }
    }

    private string sTenure;
    public string Tenure
    {
        get { return sTenure; }
        set { sTenure = value; }
    }

    private string sMonths;
    public string Months
    {
        get { return sMonths; }
        set { sMonths = value; }
    }

    private string sType;
    public string Type
    {
        get { return sType; }
        set { sType = value; }
    }

    private string sNameOnSocietyAddressBoard;
    public string NameOnSocietyAddressBoard
    {
        get { return sNameOnSocietyAddressBoard; }
        set { sNameOnSocietyAddressBoard = value; }
    }

    private string sNameplateOnDoor;
    public string NameplateOnDoor
    {
        get { return sNameplateOnDoor; }
        set { sNameplateOnDoor = value; }
    }

    private string sOwnershipDetail;
    public string OwnershipDetail
    {
        get { return sOwnershipDetail; }
        set { sOwnershipDetail = value; }
    }

    private string sPermanentAddress;
    public string PermanentAddress
    {
        get { return sPermanentAddress; }
        set { sPermanentAddress = value; }
    }

   
    private string sNoOfRooms;
    public string NoOfRooms
    {
        get { return sNoOfRooms; }
        set { sNoOfRooms = value; }
    }

    private string sApproximateValue;
    public string ApproximateValue
    {
        get { return sApproximateValue; }
        set { sApproximateValue = value; }
    }

    private string sBachelorAccomodation;
    public string BachelorAccomodation
    {
        get { return sBachelorAccomodation; }
        set { sBachelorAccomodation = value; }
    }

    private string sVehiclesCurrentlyUsed;
    public string VehiclesCurrentlyUsed
    {
        get { return sVehiclesCurrentlyUsed; }
        set { sVehiclesCurrentlyUsed = value; }
    }

    private string sVehiclesFinancedNFinancerName;
    public string VehiclesFinancedNFinancerName
    {
        get { return sVehiclesFinancedNFinancerName; }
        set { sVehiclesFinancedNFinancerName = value; }
    }

    private string sDescribeExteriorPremises;
    public string DescribeExteriorPremises
    {
        get { return sDescribeExteriorPremises; }
        set { sDescribeExteriorPremises = value; }
    }

    private string sDescribeInteriorPremises;
    public string DescribeInteriorPremises
    {
        get { return sDescribeInteriorPremises; }
        set { sDescribeInteriorPremises = value; }
    }

    private string sStatusOfResidence1;
    public string StatusOfResidence1
    {
        get { return sStatusOfResidence1; }
        set { sStatusOfResidence1 = value; }
    }

    private string sStatusOfResidence2;
    public string StatusOfResidence2
    {
        get { return sStatusOfResidence2; }
        set { sStatusOfResidence2 = value; }
    }


    private string sApplicantIncome;
    public string ApplicantIncome
    {
        get { return sApplicantIncome; }
        set { sApplicantIncome = value; }
    }

    private string sNameOfCompany;
    public string NameOfCompany
    {
        get { return sNameOfCompany; }
        set { sNameOfCompany = value; }
    }

    private string sOtherSourceOfIncome;
    public string OtherSourceOfIncome
    {
        get { return sOtherSourceOfIncome; }
        set { sOtherSourceOfIncome = value; }
    }

    private string sRoomType;
    public string RoomType
    {
        get { return sRoomType; }
        set { sRoomType = value; }
    }

    private string sTypeOfHouse;
    public string TypeOfHouse
    {
        get { return sTypeOfHouse; }
        set { sTypeOfHouse = value; }
    }

    private string sAnyOtherLoanOnApplicantName;
    public string AnyOtherLoanOnApplicantName
    {
        get { return sAnyOtherLoanOnApplicantName; }
        set { sAnyOtherLoanOnApplicantName = value; }
    }

    private string sVehiclesOwnership;
    public string VehiclesOwnership
    {
        get { return sVehiclesOwnership; }
        set { sVehiclesOwnership = value; }
    }

    private string sResiAddressIsWithInAreaLimit;
    public string ResiAddressIsWithInAreaLimit
    {
        get { return sResiAddressIsWithInAreaLimit; }
        set { sResiAddressIsWithInAreaLimit = value; }
    }

    private string sApporachToHouse;
    public string ApporachToHouse
    {
        get { return sApporachToHouse; }
        set { sApporachToHouse = value; }
    }

    private string sStandardOfLiving;
    public string StandardOfLiving
    {
        get { return sStandardOfLiving; }
        set { sStandardOfLiving = value; }
    }

    private string sWalls;
    public string Walls
    {
        get { return sWalls; }
        set { sWalls = value; }
    }

    private string sTypeOfResidence;
    public string TypeOfResidence
    {
        get { return sTypeOfResidence; }
        set { sTypeOfResidence = value; }
    }

    private string sFlooring;
    public string Flooring
    {
        get { return sFlooring; }
        set { sFlooring = value; }
    }

    private string sNoOfYrsOfCurrentResidence;
    public string NoOfYrsOfCurrentResidence
    {
        get { return sNoOfYrsOfCurrentResidence; }
        set { sNoOfYrsOfCurrentResidence = value; }
    }

    private string sTimeWhenAppIsHome;
    public string TimeWhenAppIsHome
    {
        get { return sTimeWhenAppIsHome; }
        set { sTimeWhenAppIsHome = value; }
    }

    private string sAddressProofSighted;
    public string AddressProofSighted
    {
        get { return sAddressProofSighted; }
        set { sAddressProofSighted = value; }
    }

    private string sTalliesWithCurrentAddress;
    public string TalliesWithCurrentAddress
    {
        get { return sTalliesWithCurrentAddress; }
        set { sTalliesWithCurrentAddress = value; }
    }

    private string sTypeOfAddProof;
    public string TypeOfAddProof
    {
        get { return sTypeOfAddProof; }
        set { sTypeOfAddProof = value; }
    }

    private string sResiOCL;
    public string ResiOCL
    {
        get { return sResiOCL; }
        set { sResiOCL = value; }
    }

    private string sBlackArea;
    public string BlackArea
    {
        get { return sBlackArea; }
        set { sBlackArea = value; }
    }

    private string sAddressConfirmed;
    public string AddressConfirmed
    {
        get { return sAddressConfirmed; }
        set { sAddressConfirmed = value; }
    }

    private string sHowCooperativeCustomer;
    public string HowCooperativeCustomer
    {
        get { return sHowCooperativeCustomer; }
        set { sHowCooperativeCustomer = value; }
    }

    private string sEaseOfLocation;
    public string EaseOfLocation
    {
        get { return sEaseOfLocation; }
        set { sEaseOfLocation = value; }
    }
    //added by kamal matekar for RV
    private string sPagerNo;
    public string PagerNo
    {
        get { return sPagerNo; }
        set { sPagerNo = value; }
    }
    private string sVisibleItems;
    public string VisibleItems
    {
        get { return sVisibleItems; }
        set { sVisibleItems = value; }
    }

    private string sNoOfWindow;
    public string NoOfWindow
    {
        get { return sNoOfWindow; }
        set { sNoOfWindow = value; }
    }
    private string sEmpDesignation;
    public string EmpDesignation
    {
        get { return sEmpDesignation; }
        set { sEmpDesignation = value; }
    }

    private string sChildren;
    public string Children
    {
        get { return sChildren; }
        set { sChildren = value; }
    }

    private string sCarPark;
    public string CarPark
    {
        get { return sCarPark; }
        set { sCarPark = value; }
    }

    private string sResiExti;
    public string ResiExti
    {
        get { return sResiExti; }
        set { sResiExti = value; }
    }

    private string sResiIntl;
    public string ResiIntl
    {
        get { return sResiIntl; }
        set { sResiIntl = value; }
    }

    private string sConsHouse;
    public string ConsHouse
    {
        get { return sConsHouse; }
        set { sConsHouse = value; }
    }

    private string sResiExt;
    public string ResiExt
    {
        get { return sResiExt; }
        set { sResiExt = value; }
    }

    #endregion
    
    #region PropertyDeclaration for BV
    private string sNameOfCollegue;
    public string NameOfCollegue
    {
        get { return sNameOfCollegue; }
        set { sNameOfCollegue = value; }
    }
    private string sDesgnDeptCollegue;
    public string DesgnDeptCollegue
    {
        get { return sDesgnDeptCollegue; }
        set { sDesgnDeptCollegue = value; }
    }
    private string sMthOfCompExistAtAddress;
    public string MthOfCompExistAtAddress
    {
        get { return sMthOfCompExistAtAddress; }
        set { sMthOfCompExistAtAddress = value; }
    }
    private string sProfileCoNeighbour;
    public string ProfileCoNeighbour
    {
        get { return sProfileCoNeighbour; }
        set { sProfileCoNeighbour = value; }
    }
    private string sAppNameVerifiedFrom;
    public string AppNameVerifiedFrom
    {
        get { return sAppNameVerifiedFrom; }
        set { sAppNameVerifiedFrom = value; }
    }
    
    ///----
    private string sNameOfPersonMetDesgn;
    public string NameOfPersonMetDesgn
    {
        get { return sNameOfPersonMetDesgn; }
        set { sNameOfPersonMetDesgn = value; }
    }

    private string sApplicantWorkedAgGivenAddress;
    public string ApplicantWorkedAgGivenAddress
    {
        get { return sApplicantWorkedAgGivenAddress; }
        set { sApplicantWorkedAgGivenAddress = value; }
    }

    private string sNameOfBusiness;
    public string NameOfBusiness
    {
        get { return sNameOfBusiness; }
        set { sNameOfBusiness = value; }
    }

    private string sNoOfYrsInservice;
    public string NoOfYrsInservice
    {
        get { return sNoOfYrsInservice; }
        set { sNoOfYrsInservice = value; }
    }

    private string sAppDesignation;
    public string AppDesignation
    {
        get { return sAppDesignation; }
        set { sAppDesignation = value; }
    }

    private string sNoOfEmpSeen;
    public string NoOfEmployeeSeen
    {
        get { return sNoOfEmpSeen; }
        set { sNoOfEmpSeen = value; }
    }

    private string sConstitutencyOfBusiness;
    public string ConstitutencyOfBusiness
    {
        get { return sConstitutencyOfBusiness; }
        set { sConstitutencyOfBusiness = value; }
    }

    private string sTypeOfOffice;
    public string TypeOfOffice
    {
        get { return sTypeOfOffice; }
        set { sTypeOfOffice = value; }
    }

    private string sLocatingOffice;
    public string LocatingOffice
    {
        get { return sLocatingOffice; }
        set { sLocatingOffice = value; }
    }

    private string sIsResiCumOffice;
    public string IsResiCumOffice
    {
        get { return sIsResiCumOffice; }
        set { sIsResiCumOffice = value; }
    }

    private string sNameBoardSeen;
    public string NameBoardSeen
    {
        get { return sNameBoardSeen; }
        set { sNameBoardSeen = value; }
    }
        
    private string sIsBusinessActivityseen;
    public string IsBusinessActivityseen
    {
        get { return sIsBusinessActivityseen; }
        set { sIsBusinessActivityseen = value; }
    }
        
    private string sIsEuipStockSighted;
    public string IsEuipStockSighted
    {
        get { return sIsEuipStockSighted; }
        set { sIsEuipStockSighted = value; }
    }

    private string sNatureOfJob;
    public string NatureOfJob
    {
        get { return sNatureOfJob; }
        set { sNatureOfJob = value; }
    }

    private string sVisitCardAsProofOfVisit;
    public string VisitCardAsProofOfVisit
    {
        get { return sVisitCardAsProofOfVisit; }
        set { sVisitCardAsProofOfVisit = value; }
    }

    private string sRemarks;
    public string Remarks
    {
        get { return sRemarks; }
        set { sRemarks = value; }
    }

    private string sRating;
    public string Rating
    {
        get { return sRating; }
        set { sRating = value; }
    }
       

    private string sVerifierDate;
    public string VerifierDate
    {
        get { return sVerifierDate; }
        set { sVerifierDate = value; }
    }

    private string sVerifierTime;
    public string VerifierTime
    {
        get { return sVerifierTime; }
        set { sVerifierTime = value; }
    }

    private string sSupervisorName;
    public string SupervisorName
    {
        get { return sSupervisorName; }
        set { sSupervisorName = value; }
    }

    private string sSupervisorDate;
    public string SupervisorDate
    {
        get { return sSupervisorDate; }
        set { sSupervisorDate = value; }
    }

    private string sSupervisorTime;
    public string SupervisorTime
    {
        get { return sSupervisorTime; }
        set { sSupervisorTime = value; }
    }


    private string sNameOfBankDefaultedWith;
    public string NameOfBankDefaultedWith
    {
        get { return sNameOfBankDefaultedWith; }
        set { sNameOfBankDefaultedWith = value; }
    }

    private string sProductName;
    public string ProductName
    {
        get { return sProductName; }
        set { sProductName = value; }
    }

    private string sDefaultInWhichBucket;
    public string DefaultInWhichBucket
    {
        get { return sDefaultInWhichBucket; }
        set { sDefaultInWhichBucket = value; }
    }

    private string sAmountOfDefaultINR;
    public string AmountOfDefaultINR
    {
        get { return sAmountOfDefaultINR; }
        set { sAmountOfDefaultINR = value; }
    }

    private string sTeleCDRomCheck;
    public string TeleCDRomCheck
    {
        get { return sTeleCDRomCheck; }
        set { sTeleCDRomCheck = value; }
    }

    private string sOffTelNoInNameOf;
    public string OffTelNoInNameOf
    {
        get { return sOffTelNoInNameOf; }
        set { sOffTelNoInNameOf = value; }
    }

    private string sNoOfYrsAtPrevEmployment;
    public string NoOfYrsAtPrevEmployment
    {
        get { return sNoOfYrsAtPrevEmployment; }
        set { sNoOfYrsAtPrevEmployment = value; }
    }

    private string sOwnership;
    public string Ownership
    {
        get { return sOwnership; }
        set { sOwnership = value; }
    }

    private string sLocationOfOffice;
    public string LocationOfOffice
    {
        get { return sLocationOfOffice; }
        set { sLocationOfOffice = value; }
    }

    private string sApproachToOffice;
    public string ApproachToOffice
    {
        get { return sApproachToOffice; }
        set { sApproachToOffice = value; }
    }

    private string sAreaAroundOffice;
    public string AreaAroundOffice
    {
        get { return sAreaAroundOffice; }
        set { sAreaAroundOffice = value; }
    }

    private string sOfficeAmbience;
    public string OfficeAmbience
    {
        get { return sOfficeAmbience; }
        set { sOfficeAmbience = value; }
    }

    private string sOfficeOCL;
    public string OfficeOCL
    {
        get { return sOfficeOCL; }
        set { sOfficeOCL = value; }
    }

    private string sExteriorConditions;
    public string ExteriorConditions
    {
        get { return sExteriorConditions; }
        set { sExteriorConditions = value; }
    }


    private string sNoOfYrsAtCurrentOffice;
    public string NoOfYrsAtCurrentOffice
    {
        get { return sNoOfYrsAtCurrentOffice; }
        set { sNoOfYrsAtCurrentOffice = value; }
    }

    private string sTimeWhenAppIsInOffice;
    public string TimeWhenAppIsInOffice
    {
        get { return sTimeWhenAppIsInOffice; }
        set { sTimeWhenAppIsInOffice = value; }
    }

    
    private string sAgencyRecommandation;
    public string AgencyRecommandation
    {
        get { return sAgencyRecommandation; }
        set { sAgencyRecommandation = value; }
    }

    private string sScoretoolRecommandation;
    public string ScoretoolRecommandation
    {
        get { return sScoretoolRecommandation; }
        set { sScoretoolRecommandation = value; }
    }

    
    private string sMarketReputation1;
    public string MarketReputation1
    {
        get { return sMarketReputation1; }
        set { sMarketReputation1 = value; }
    }

    private string sIsOfficeSelfOwnedNeigh1;
    public string IsOfficeSelfOwnedNeigh1
    {
        get { return sIsOfficeSelfOwnedNeigh1; }
        set { sIsOfficeSelfOwnedNeigh1 = value; }
    }

    private string sIsOfficeSelfOwnedNeigh2;
    public string IsOfficeSelfOwnedNeigh2
    {
        get { return sIsOfficeSelfOwnedNeigh2; }
        set { sIsOfficeSelfOwnedNeigh2 = value; }
    }
    private string sCommentsOfNeighbour1;
    public string CommentsOfNeighbour1
    {
        get { return sCommentsOfNeighbour1; }
        set { sCommentsOfNeighbour1 = value; }
    }
        
    private string sMarketReputation2;
    public string MarketReputation2
    {
        get { return sMarketReputation2; }
        set { sMarketReputation2 = value; }
    }

    private string sCommentsOfNeighbour2;
    public string CommentsOfNeighbour2
    {
        get { return sCommentsOfNeighbour2; }
        set { sCommentsOfNeighbour2 = value; }
    }

    private string sAccessibility;
    public string Accessibility
    {
        get { return sAccessibility; }
        set { sAccessibility = value; }
    }

    private string sBusinessBoardSighted;
    public string BusinessBoardSighted
    {
        get { return sBusinessBoardSighted; }
        set { sBusinessBoardSighted = value; }
    }
        
    private string sApproxArea;
    public string ApproximateArea
    {
        get { return sApproxArea; }
        set { sApproxArea = value; }
    }

    private string sBriefJobResponsibilities;
    public string BriefJobResponsibilities
    {
        get { return sBriefJobResponsibilities; }
        set { sBriefJobResponsibilities = value; }
    }

    private string sBehavourOfPersonContact;
    public string BehavourOfPersonContact
    {
        get { return sBehavourOfPersonContact; }
        set { sBehavourOfPersonContact = value; }
    }
    
    private string sTypeOfIndustry;
    public string TypeOfIndustry
    {
        get { return sTypeOfIndustry; }
        set { sTypeOfIndustry = value; }
    }

    private string sNatureOfBusiness;
    public string NatureOfBusiness
    {
        get { return sNatureOfBusiness; }
        set { sNatureOfBusiness = value; }
    }

    private string sNoOfBranches;
    public string NoOfBranches
    {
        get { return sNoOfBranches; }
        set { sNoOfBranches = value; }
    }

    private string sNoOfCustomerPerDay;
    public string NoOfCustomerPerDay
    {
        get { return sNoOfCustomerPerDay; }
        set { sNoOfCustomerPerDay = value; }
    }

    private string sOfficeName;
    public string OfficeName
    {
        get { return sOfficeName; }
        set { sOfficeName = value; }
    }

    private string sOfficeAddress;
    public string OfficeAddress
    {
        get { return sOfficeAddress; }
        set { sOfficeAddress = value; }
    }

    private string sIsOfficeSelfOwned;
    public string IsOfficeSelfOwned
    {
        get { return sIsOfficeSelfOwned; }
        set { sIsOfficeSelfOwned = value; }
    }

    private string sTypeOfBusinessActivity;
    public string TypeOfBusinessActivity
    {
        get { return sTypeOfBusinessActivity; }
        set { sTypeOfBusinessActivity = value; }
    }

    private string sEntranceMotorable;
    public string EntranceMotorable
    {
        get { return sEntranceMotorable; }
        set { sEntranceMotorable = value; }
    }

    private string sRelationWithApplicant;
    public string RelationWithApplicant
    {
        get { return sRelationWithApplicant; }
        set { sRelationWithApplicant = value; }
    }   

    private string sDetailOfPreviousOccupation;
    public string DetailOfPreviousOccupation
    {
        get { return sDetailOfPreviousOccupation; }
        set { sDetailOfPreviousOccupation = value; }
    }

    private string sIsBusinessProofSeen;
    public string IsBusinessProofSeen
    {
        get { return sIsBusinessProofSeen; }
        set { sIsBusinessProofSeen = value; }
    }

    private string sResidenceAddress;
    public string ResidenceAddress
    {
        get { return sResidenceAddress; }
        set { sResidenceAddress = value; }
    }

    

    private string sProofOfBusinessActivity;
    public string ProofOfBusinessActivity
    {
        get { return sProofOfBusinessActivity; }
        set { sProofOfBusinessActivity = value; }
    }
    
    private string sTypeOfOrganization;
    public string TypeOfOrganization
    {
        get { return sTypeOfOrganization; }
        set { sTypeOfOrganization = value; }
    }


    private string sStatusOfOffice;
    public string StatusOfOffice
    {
        get { return sStatusOfOffice; }
        set { sStatusOfOffice = value; }
    }


    private string sShifOfWork;
    public string ShifOfWork
    {
        get { return sShifOfWork; }
        set { sShifOfWork = value; }
    }


    private string sVerifierComments;
    public string VerifierComments
    {
        get { return sVerifierComments; }
        set { sVerifierComments = value; }
    }


    private string sOverallVerification;
    public string OverallVerification
    {
        get { return sOverallVerification; }
        set { sOverallVerification = value; }
    }

    private string sTotalNoOfEmployees;
    public string TotalNoOfEmployees
    {
        get { return sTotalNoOfEmployees; }
        set { sTotalNoOfEmployees = value; }
    }

    private string sReasonNotCollectingVistingCard;
    public string ReasonNotCollectingVistingCard
    {
        get { return sReasonNotCollectingVistingCard; }
        set { sReasonNotCollectingVistingCard = value; }
    }

    private string sIsOfficeDoorLocked;
    public string IsOfficeDoorLocked
    {
        get { return sIsOfficeDoorLocked; }
        set { sIsOfficeDoorLocked = value; }
    }

    private string sWhereContacted;
    public string WhereContacted
    {
        get { return sWhereContacted; }
        set { sWhereContacted = value; }
    }

    private string sSendDate;
    public string SendDate
    {
        get { return sSendDate; }
        set { sSendDate = value; }
    }

    private string sNameOfBank;
    public string NameOfBank
    {
        get { return sNameOfBank; }
        set { sNameOfBank = value; }
    }

    private string sPrevEmploymentDesgn;
    public string PrevEmploymentDesgn
    {
        get { return sPrevEmploymentDesgn; }
        set { sPrevEmploymentDesgn = value; }
    }

    private string sConstructionOfOffice;
    public string ConstructionOfOffice
    {
        get { return sConstructionOfOffice; }
        set { sConstructionOfOffice = value; }
    }

    private string sEasyOfLocatingOffice;
    public string EasyOfLocatingOffice
    {
        get { return sEasyOfLocatingOffice; }
        set { sEasyOfLocatingOffice = value; }
    }

    private string sNegmatch;
    public string Negmatch
    {
        get { return sNegmatch; }
        set { sNegmatch = value; }
    }

    private string sReasonForNotRecomdNReferred;
    public string ReasonForNotRecomdNReferred
    {
        get { return sReasonForNotRecomdNReferred; }
        set { sReasonForNotRecomdNReferred = value; }
    }

    private string sIfOCLDistance;
    public string IfOCLDistance
    {
        get { return sIfOCLDistance; }
        set { sIfOCLDistance = value; }
    }
    //Newly added fields ----
    private string sLevelOfBusActivity;
    public string LevelOfBusActivity
    {
        get { return sLevelOfBusActivity; }
        set { sLevelOfBusActivity = value; }
    }

    private string sIsResiCumOfficeSelfOwned;
    public string IsResiCumOfficeSelfOwned
    {
        get { return sIsResiCumOfficeSelfOwned; }
        set { sIsResiCumOfficeSelfOwned = value; }
    }

    private string sStockSeen;
    public string StockSeen
    {
        get { return sStockSeen; }
        set { sStockSeen = value; }
    }

    private string sMthOfWorkCurrentOffice;
    public string MthOfWorkCurrentOffice
    {
        get { return sMthOfWorkCurrentOffice; }
        set { sMthOfWorkCurrentOffice = value; }
    }

    //added by kamal matekar..

    private string sMainlineBusiness;
    public string MainlineBusiness
    {
        get { return sMainlineBusiness; }
        set { sMainlineBusiness = value; }
    }

    private string sValueofNostocksighted;
    public string ValueofNostocksighted
    {
        get { return sValueofNostocksighted; }
        set { sValueofNostocksighted = value; }
    }

    private string sCategoryofCompany;
    public string CategoryofCompany
    {
        get { return sCategoryofCompany; }
        set { sCategoryofCompany = value; }
    }

    private string sNormalOfficeJob;
    public string NormalOfficeJob
    {
        get { return sNormalOfficeJob; }
        set { sNormalOfficeJob = value; }
    }
    //ended...


    #endregion 
        
    #region GetVerificationDetail()
    //Name              :   GetVerificationDetail
    //Create By			:	Hemangi Kambli
    //Create Date		:	3July,2007

    public OleDbDataReader GetVerificationDetail(string sCaseId, string sVerifyType, string sClientId, string sCentreId)
    {
        string sSql = "";
        sSql = "select CD.Case_Id,CRL.Verification_type_id from  CPV_RL_CASE_DETAILS CD " +
               " INNER JOIN CPV_RL_CASE_VERIFICATIONTYPE CRL ON CD.Case_ID=CRL.Case_ID " +
               " WHERE CRL.case_id='" + sCaseId + "' " +
               " And CRL.verification_type_id='" + sVerifyType + "'" +
               " AND CD.Client_ID='" + sClientId + "'" +
               " AND CD.Centre_Id='" + sCentreId + "'" +
               " AND CD.SEND_DATETIME IS NULL ";

        return OleDbHelper.ExecuteReader(objCmn.ConnectionString, CommandType.Text, sSql);
    }
    #endregion GetVerificationDetail()

    #region GetQCVerificationDetail()
    public OleDbDataReader GetQCVerificationDetail(string sCaseId, string sVerifyType, string sClientId, string sCentreId)
    {
        string sSql = "";
        sSql = "select CD.Case_Id,CCV.Verification_type_id from  CPV_QC_Case_Details CD " +
               " INNER JOIN CPV_QC_Case_VerificationType CCV ON CD.Case_ID=CCV.Case_ID " +
               " WHERE CCV.case_id='" + sCaseId + "' " +
               " And CCV.verification_type_id='" + sVerifyType + "'" +
               " AND CD.Client_ID='" + sClientId + "'" +
               " AND CD.Centre_Id='" + sCentreId + "'" +
               " AND CD.Case_SEND_DATE IS NULL ";

        return OleDbHelper.ExecuteReader(objCmn.ConnectionString, CommandType.Text, sSql);
    }
    #endregion GetVerificationDetail()

    #region GetVerifierID()
    public OleDbDataReader GetVerifierID(string sCaseId, string sVerifyType)
    {
        string sSql = "";
        sSql = "select FE_ID from CPV_RL_CASE_FE_MAPPING where case_id='" + sCaseId + "' " +
             " And verification_type_id='" + sVerifyType + "'";

        return OleDbHelper.ExecuteReader(objCmn.ConnectionString, CommandType.Text, sSql);
    }
    #endregion GetVerifierID()

    #region GetRVDetail()
    public OleDbDataReader GetRVDetail(string sCaseId, string sVerifyType)
    {
        string sSql = "";
        sSql = "select * from CPV_RL_VERIFICATION_RVRT where case_id='" + sCaseId + "' " +
             " And verification_type_id='" + sVerifyType + "'";

        return OleDbHelper.ExecuteReader(objCmn.ConnectionString, CommandType.Text, sSql);
    }
    #endregion GetRVDetail()

    #region GetBVDetail()
    public OleDbDataReader GetBVDetail(string sCaseId, string sVerifyType)
    {
        string sSql = "";
        sSql = "select * from CPV_RL_VERIFICATION_BVBT where case_id='" + sCaseId + "' " +
             " And verification_type_id='" + sVerifyType + "'";

        return OleDbHelper.ExecuteReader(objCmn.ConnectionString, CommandType.Text, sSql);
    }
    #endregion GetBVDetail()

    #region GetCASEDetail()
    public OleDbDataReader GetCASEDetail(string sCaseId, string sVerifyType)
    {
        string sSql = "";
        sSql = "SELECT CD.REF_NO," +
               " CONVERT(CHAR(10), cd.CASE_REC_DATETIME,103) + ' ' + " +
               " LTRIM(SUBSTRING(CONVERT( VARCHAR(210),cd.CASE_REC_DATETIME, 22), 10, 5) + " +
               " RIGHT(CONVERT(VARCHAR(20), cd.CASE_REC_DATETIME, 22), 3)) as CASE_REC_DATETIME, " +
               " ISNULL(CD.FIRST_NAME,'') + ' ' + ISNULL(CD.MIDDLE_NAME,'')+ISNULL(CD.LAST_NAME,'') AS NAME, "+
               " ISNULL(CD.RES_ADD_LINE_1,'')+ ' ' + ISNULL(CD.RES_ADD_LINE_2,'')+ ' ' + ISNULL(CD.RES_ADD_LINE_3,'') " +
               " AS RESIADDRESS, CD.RES_CITY, CD.RES_PIN_CODE,CD.DOB,CD.RES_LAND_MARK,CD.EMPLOYEE_TYPE, " +
               " ISNULL(CD.OFF_ADD_LINE_1,'')+ ' ' + ISNULL(CD.OFF_ADD_LINE_2,'')+ ' ' + ISNULL(CD.OFF_ADD_LINE_3,'') + ' ' + " +
               " ISNULL(CD.OFF_CITY,'') + ISNULL(CD.OFF_PIN_CODE,'') AS OFFADDRESS, CD.OFF_PHONE,CD.OFF_LAND_MARK,CD.OFF_NAME " +
               " FROM CPV_RL_CASE_DETAILS CD  INNER JOIN " +
               " CPV_RL_CASE_VERIFICATIONTYPE CV ON CD.CASE_ID = CV.CASE_ID " +
               " where CV.case_id='" + sCaseId + "' " +
               " And CV.verification_type_id='" + sVerifyType + "'";

        return OleDbHelper.ExecuteReader(objCmn.ConnectionString, CommandType.Text, sSql);
    }
    #endregion GetCASEDetail()

    public OleDbDataReader GetCASEDetail_Vend(string sCaseId, string sVerifyType)
    {
        string sSql = "";
        sSql = " select File_No,Service_Center,Name_Seller_conf_neigh,Seller_aware,whom_sell_prop,buyer_name, " +
               " sell_get_know_buy,sell_finan_institution,out_loan,mortgage,poss_doc,photo_Iden,flat_no, " +
               " Authenticity from CPV_RL_VERIFICATION_REF where case_id='" + sCaseId + "' " +
               " And verification_type_id='" + sVerifyType + "'";

        return OleDbHelper.ExecuteReader(objCmn.ConnectionString, CommandType.Text, sSql);
    }

    public OleDbDataReader GetCASEDetail_Noc(string sCaseId, string sVerifyType)
    {
        string sSql = "";
        sSql = " select File_No,Service_Center,Name_Seller_conf_neigh,flat_no,Authenticity,Seller_aware, " +
               " sell_finan_institution from CPV_RL_VERIFICATION_REF where case_id='" + sCaseId + "' " +
               " And verification_type_id='" + sVerifyType + "'";

        return OleDbHelper.ExecuteReader(objCmn.ConnectionString, CommandType.Text, sSql);
    }

    public DataSet GetTeleCallLogDetail(string sCaseID, string sVerificationTypeID)
    {
        string sSql = "";

        sSql = "SELECT ATTEMPT_DATETIME,Attempt_REMARK,VERIFIER_ID,SubRemark from CPV_RL_VERIFICATION_ATTEMPT a" +
              " where CASE_ID='" + sCaseID + "'" + "and VERIFICATION_TYPE_ID='" + sVerificationTypeID + "'";
        return OleDbHelper.ExecuteDataset(objCmn.ConnectionString, CommandType.Text, sSql);
    }

    public DataSet GetTeleCallLogDetail1(string sCaseID, string sVerificationTypeID)
    {
        string sSql = "";

        sSql = "select top 3 a.case_id,a.verification_type_id, c.fullname,a.ASSIGN_DATETIME from CPV_RL_CASE_FE_MAPPING a,employee_master c where " +
               " a.fe_id=c.emp_id and a.case_id='" + sCaseID + "' and a.verification_type_id='" + sVerificationTypeID + "' union all " +
               " select top 3 b.case_id,b.verification_type_id,c.fullname,b.DATE_TIME from cpv_rl_fe_case_mapping_history b,employee_master c " +
               " where b.fe_id=c.emp_id and b.case_id='" + sCaseID + "' and b.verification_type_id='" + sVerificationTypeID + "' order by ASSIGN_DATETIME asc";

        return OleDbHelper.ExecuteDataset(objCmn.ConnectionString, CommandType.Text, sSql);
    }

    public Int32 InsertTeleCallLog(ArrayList arrTeleCallLog)
    {
        OleDbConnection oledbConn = new OleDbConnection(objCmn.ConnectionString);
        oledbConn.Open();
        OleDbTransaction oledbTrans = oledbConn.BeginTransaction();
        OleDbDataReader objoledbDR;
        String sqlSelectQuery = "";
        String sqlQuery = "";
        Int32 returnValue = 0;

        try
        {

            sqlSelectQuery = "Select CASE_ID,VERIFICATION_TYPE_ID from CPV_RL_VERIFICATION_ATTEMPT where CASE_ID='" + CaseId + "'" + "and VERIFICATION_TYPE_ID='" + VerificationTypeId + "'";
            objoledbDR = OleDbHelper.ExecuteReader(objCmn.ConnectionString, CommandType.Text, sqlSelectQuery);
            OleDbParameter[] oledbParam = new OleDbParameter[6];

            if (objoledbDR.Read() == true)
            {
                sqlQuery = "Delete from CPV_RL_VERIFICATION_ATTEMPT where CASE_ID='" + CaseId + "'" +
                           " AND VERIFICATION_TYPE_ID='" + VerificationTypeId + "'";
                OleDbHelper.ExecuteNonQuery(oledbTrans, CommandType.Text, sqlQuery);
            }
            foreach (ArrayList item in arrTeleCallLog)
            {
                AttemptDateTime = item[0].ToString();
                Remark = item[1].ToString();
                SubRemark = item[2].ToString();
                VerifierID = item[3].ToString();

                //////////////////////////////Inserting in table CPV_RL_VERIFICATION_ATTEMPT                 

                sqlQuery = "Insert into CPV_RL_VERIFICATION_ATTEMPT(CASE_ID,ATTEMPT_DATETIME,Attempt_REMARK,VERIFICATION_TYPE_ID,VERIFIER_ID,SubRemark) " +
                          "Values(?,?,?,?,?,?)";


                oledbParam[0] = new OleDbParameter("@CaseID", OleDbType.VarChar, 15);
                oledbParam[0].Value = CaseId;

                oledbParam[1] = new OleDbParameter("@AttemptDateTime", OleDbType.VarChar);
                oledbParam[1].Value = AttemptDateTime;

                oledbParam[2] = new OleDbParameter("@Remark", OleDbType.VarChar, 255);
                oledbParam[2].Value = Remark;

                oledbParam[3] = new OleDbParameter("@VerificationTypeID", OleDbType.VarChar, 15);
                oledbParam[3].Value = VerificationTypeId;

                oledbParam[4] = new OleDbParameter("@VerifierID", OleDbType.VarChar, 15);
                oledbParam[4].Value = VerifierID;

                oledbParam[5] = new OleDbParameter("@SubRemark", OleDbType.VarChar, 300);
                oledbParam[5].Value = SubRemark;


                OleDbHelper.ExecuteNonQuery(oledbTrans, CommandType.Text, sqlQuery, oledbParam);

            }

            string sSql = "";
            sSql = "Update CPV_RL_CASE_DETAILS SET IS_CASE_COMPLETE='Y' WHERE CASE_ID='" + sCaseId + "'";
            OleDbHelper.ExecuteNonQuery(oledbTrans, CommandType.Text, sSql);

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

    #region InsertUpdateRLResiVerificationEntry() Residence verification(RV)
    //Function Name    :   InsertUpdateRLResiVerificationEntry
    //Create By		   :   Hemangi Kambli
    //Create Date	   :   02 July 2007.
    //Remarks 		   :   This method is used to insert new verification entry for RL.

    public string InsertUpdateRLResiVerificationEntry()
    {
        OleDbConnection oledbConn = new OleDbConnection(objCmn.ConnectionString);
        oledbConn.Open();
        OleDbTransaction oledbTrans = oledbConn.BeginTransaction();
        string sRetVal = "";
        try
        {
            string sSql = "";
            string sSqlRead = "";
            OleDbDataReader oledbRead;

            sSqlRead = "SELECT Case_ID,VERIFICATION_TYPE_ID from CPV_RL_VERIFICATION_RVRT " +
                       " WHERE Case_ID='" + CaseId + "'" +
                       " AND VERIFICATION_TYPE_ID='" + VerificationTypeId + "'"; 

            oledbRead = OleDbHelper.ExecuteReader(oledbTrans, CommandType.Text, sSqlRead);

            OleDbParameter[] paramRV = new OleDbParameter[135];
            
            if (oledbRead.Read() == false)
            {
                //insert query
                sSql = "INSERT INTO CPV_RL_VERIFICATION_RVRT(CASE_ID,VERIFICATION_TYPE_ID,PERSON_CONTACTED,Relationship," +
                     "Address,CITY,PINCODE,Landmark,TEL_NO_TYPE_PHONE,Mobile_No_type_phone,Loan_Amount,Use_of_loan,Product,Location_Product," +
                     "DOB,MARITAL_STATUS,EDUCATION_BACKGROUND,FAMILY_DETAILS,SPOUSE_DETAILS,FAMILY_INCOME," +
                     "OTHER_DETAILS,Loan_Cancellation,CREDIT_CARD_LIMIT,OTHER_LOAN_DATAIL,YEARS_AT_RESIDENCE," +
                     "Area_of_House,ASSETS,DETAIL_FURNITURE_SEEN,Ownership_RESIDENCE,STAYING_WHOM,DSA,Tenure," +
                     "Months,Type,Name_Society_Board,Nameplate_on_door,Ownership_Details,Permanent_address," +
                     "Number_rooms,Approximate_Value,Bachelor_Accomodation,Locality,Vehicles_used,Vehicles_financed," +
                     "Exterior_Premises,interior_Premises,Name_Neighbour1,ADD_Neighbour1,CONFIRM_Neighbour1,RESSTATUS_Neighbour1," +
                     "Stay_Res_Neighbour1,Comments_Neighbour1,Name_Neighbour2,ADD_Neighbour2,CONFIRM_Neighbour2,RESSTATUS_Neighbour2," +
                     "Stay_Res_Neighbour2,Comments_Neighbour2,Type_Accmodation,Entry_Permitted,Identity_Proof_Seen," +
                     "Applicant_income,Company_name,Purpose_loan,other_source_income,Other_Investment,Colour_of_Door," +
                     "Room_Type,Type_of_House,loan_applicant_name,Vehicles_Ownership,Residence_address_negative," +
                     "Approch_Residence,Type_Roof,Telephone_check,Location_house,approch_to_house," +
                     "Standard_of_Living,Walls,Flooring,IS_appname_address,No_of_dependent,age_applicant,Name_add_third_party," +
                     "Time_app_at_home,Third_party_comment,Address_Proof_Sighted,Tallies_current_Address,Type_of_Add_Proof," +
                     "Resi_OCL,Affliated_Political_Party,Profile,Address_Confirmed,How_Cooperative,Locating_address," +
                     "Agency_Code,Accessibility,Entrance_Motorable,Society_Board_Sighted,Mother_Name,Address_Company," +
                     "Behavior_Person_Contacted,Verifier_Comments,Verification_status,No_of_earning_member,If_Vehicle_exist," +
                     "Vehicle_Type,Door_Locked,Sent_Datetime,Totals_Yrs_City,Name_add_Ref1,OCL_than_distance,Parking_Facility," +
                     "Neg_match,Reason_Notrecommended,Father_Spouse_Name,VERIFICATION_DATETIME,ADD_BY,ADD_DATE,"+
                     "SEP_BATHROOM_SEEN,FAMILY_SEEN,SUPERVISOR_COMMENTS,ROOF_TYPE,Verifier,City_Limit,Pager_No,Visible_Items, " +
                     "No_of_Windows,Children,Emp_Designation,Car_Park,Resi_Exti,Resi_Intl,Cons_House,Resi_Ext) " +
                     "VALUES(" +
                     "?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?," +
                     "?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?," +
                     "?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?," +
                     "?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?, " +
                     "?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?) ";

                paramRV[0] = new OleDbParameter("@CaseID", OleDbType.VarChar, 15);
                paramRV[0].Value = CaseId;
                paramRV[1] = new OleDbParameter("@VerificationTypeId", OleDbType.VarChar, 15);
                paramRV[1].Value = VerificationTypeId;
                paramRV[2] = new OleDbParameter("@NameOfPersonMet", OleDbType.VarChar, 100);
                paramRV[2].Value = NameOfPersonMet;
                paramRV[3] = new OleDbParameter("@Relationship", OleDbType.VarChar, 100);
                paramRV[3].Value = Relationship;
                paramRV[4] = new OleDbParameter("@Address", OleDbType.VarChar, 255);
                paramRV[4].Value = Address;
                paramRV[5] = new OleDbParameter("@City", OleDbType.VarChar, 100);
                paramRV[5].Value = City;
                paramRV[6] = new OleDbParameter("@PinCode", OleDbType.VarChar, 20);
                paramRV[6].Value = PinCode;
                paramRV[7] = new OleDbParameter("@Landmark", OleDbType.VarChar, 100);
                paramRV[7].Value = Landmark;
                paramRV[8] = new OleDbParameter("@TeleNoType", OleDbType.VarChar, 100);
                paramRV[8].Value = TeleNoType;
                paramRV[9] = new OleDbParameter("@MobileNoType", OleDbType.VarChar, 100);
                paramRV[9].Value = MobileNoType;
                paramRV[10] = new OleDbParameter("@LoanAmount", OleDbType.VarChar, 50);
                paramRV[10].Value = LoanAmount;
                paramRV[11] = new OleDbParameter("@UseOfLoan", OleDbType.VarChar, 255);
                paramRV[11].Value = UseOfLoan;
                paramRV[12] = new OleDbParameter("@Product", OleDbType.VarChar, 100);
                paramRV[12].Value = Product;
                paramRV[13] = new OleDbParameter("@LocationOfProduct", OleDbType.VarChar, 100);
                paramRV[13].Value = LocationOfProduct;
                paramRV[14] = new OleDbParameter("@DateOfBirth", OleDbType.VarChar, 30);
                paramRV[14].Value = DateOfBirth;
                paramRV[15] = new OleDbParameter("@MaritalStatus", OleDbType.VarChar, 50);
                paramRV[15].Value = MaritalStatus;
                paramRV[16] = new OleDbParameter("@EducationalBackground", OleDbType.VarChar, 100);
                paramRV[16].Value = EducationalBackground;
                paramRV[17] = new OleDbParameter("@FamilyDetails", OleDbType.VarChar, 255);
                paramRV[17].Value = FamilyDetails;
                paramRV[18] = new OleDbParameter("@DetailsOfWorkingMemberSpouse", OleDbType.VarChar, 255);
                paramRV[18].Value = DetailsOfWorkingMemberSpouse;
                paramRV[19] = new OleDbParameter("@TotalFamIncome", OleDbType.VarChar, 50);
                paramRV[19].Value = TotalFamIncome;
                paramRV[20] = new OleDbParameter("@DetailsOfWorkingMembersOthers", OleDbType.VarChar, 255);
                paramRV[20].Value = DetailsOfWorkingMembersOthers;
                paramRV[21] = new OleDbParameter("@LoanCancellation", OleDbType.VarChar, 50);
                paramRV[21].Value = LoanCancellation;
                paramRV[22] = new OleDbParameter("@AnyCreditCard", OleDbType.VarChar, 255);
                paramRV[22].Value = AnyCreditCard;
                paramRV[23] = new OleDbParameter("@AnyOtherLoan", OleDbType.VarChar, 255);
                paramRV[23].Value = AnyOtherLoan;
                paramRV[24] = new OleDbParameter("@NoOfYrsAtResidence", OleDbType.VarChar, 20);
                paramRV[24].Value = NoOfYrsAtResidence;
                paramRV[25] = new OleDbParameter("@AreaOfHouse", OleDbType.VarChar, 20);
                paramRV[25].Value = AreaOfHouse;
                paramRV[26] = new OleDbParameter("@Assets", OleDbType.VarChar, 100);
                paramRV[26].Value = Assets;
                paramRV[27] = new OleDbParameter("@DetailsOfFurnitureSeen", OleDbType.VarChar, 255);
                paramRV[27].Value = DetailsOfFurnitureSeen;
                paramRV[28] = new OleDbParameter("@OwnershipOfResidence", OleDbType.VarChar, 50);
                paramRV[28].Value = OwnershipOfResidence;
                paramRV[29] = new OleDbParameter("@StayingWithWhom", OleDbType.VarChar, 100);
                paramRV[29].Value = StayingWithWhom;
                paramRV[30] = new OleDbParameter("@DSA", OleDbType.VarChar, 50);
                paramRV[30].Value = DSA;
                paramRV[31] = new OleDbParameter("@Tenure", OleDbType.VarChar, 100);
                paramRV[31].Value = Tenure;
                paramRV[32] = new OleDbParameter("@Months", OleDbType.VarChar, 10);
                paramRV[32].Value = Months;
                paramRV[33] = new OleDbParameter("@TotalFamIncome", OleDbType.VarChar, 50);
                paramRV[33].Value = Type;
                paramRV[34] = new OleDbParameter("@NameOnSocietyAddressBoard", OleDbType.VarChar, 100);
                paramRV[34].Value = NameOnSocietyAddressBoard;
                paramRV[35] = new OleDbParameter("@NameplateOnDoor", OleDbType.VarChar, 50);
                paramRV[35].Value = NameplateOnDoor;
                paramRV[36] = new OleDbParameter("@OwnershipDetail", OleDbType.VarChar, 100);
                paramRV[36].Value = OwnershipDetail;
                paramRV[37] = new OleDbParameter("@PermanentAddress", OleDbType.VarChar, 255);
                paramRV[37].Value = PermanentAddress;
                paramRV[38] = new OleDbParameter("@NoOfRooms", OleDbType.VarChar, 50);
                paramRV[38].Value = NoOfRooms;
                paramRV[39] = new OleDbParameter("@ApproximateValue", OleDbType.VarChar, 50);
                paramRV[39].Value = ApproximateValue;
                paramRV[40] = new OleDbParameter("@BachelorAccomodation", OleDbType.VarChar, 50);
                paramRV[40].Value = BachelorAccomodation;
                paramRV[41] = new OleDbParameter("@Locality", OleDbType.VarChar, 50);
                paramRV[41].Value = Locality;
                paramRV[42] = new OleDbParameter("@VehiclesCurrentlyUsed", OleDbType.VarChar, 100);
                paramRV[42].Value = VehiclesCurrentlyUsed;
                paramRV[43] = new OleDbParameter("@VehiclesFinancedNFinancerName", OleDbType.VarChar, 100);
                paramRV[43].Value = VehiclesFinancedNFinancerName;
                paramRV[44] = new OleDbParameter("@DescribeExteriorPremises", OleDbType.VarChar, 100);
                paramRV[44].Value = DescribeExteriorPremises;
                paramRV[45] = new OleDbParameter("@DescribeInteriorPremises", OleDbType.VarChar, 100);
                paramRV[45].Value = DescribeInteriorPremises;
                paramRV[46] = new OleDbParameter("@NameOfNeighbour1", OleDbType.VarChar, 100);
                paramRV[46].Value = NameOfNeighbour1;
                paramRV[47] = new OleDbParameter("@AddressOfNeighbour1", OleDbType.VarChar, 255);
                paramRV[47].Value = AddressOfNeighbour1;
                paramRV[48] = new OleDbParameter("@DoesAppWorkHere1", OleDbType.VarChar, 100);
                paramRV[48].Value = DoesAppWorkHere1;
                paramRV[49] = new OleDbParameter("@StatusOfResidence1", OleDbType.VarChar, 50);
                paramRV[49].Value = StatusOfResidence1;
                paramRV[50] = new OleDbParameter("@MthsOfWorkAtOffice1", OleDbType.VarChar, 50);
                paramRV[50].Value = MthsOfWorkAtOffice1;
                paramRV[51] = new OleDbParameter("@CommentsOfNeighbour1", OleDbType.VarChar, 255);
                paramRV[51].Value = CommentsOfNeighbour1;
                paramRV[52] = new OleDbParameter("@NameOfNeighbour2", OleDbType.VarChar, 100);
                paramRV[52].Value = NameOfNeighbour2;
                paramRV[53] = new OleDbParameter("@AddressOfNeighbour2", OleDbType.VarChar, 255);
                paramRV[53].Value = AddressOfNeighbour2;
                paramRV[54] = new OleDbParameter("@DoesAppWorkHere2", OleDbType.VarChar, 100);
                paramRV[54].Value = DoesAppWorkHere2;
                paramRV[55] = new OleDbParameter("@StatusOfResidence2", OleDbType.VarChar, 50);
                paramRV[55].Value = StatusOfResidence2;
                paramRV[56] = new OleDbParameter("@MthsOfWorkAtOffice2", OleDbType.VarChar, 50);
                paramRV[56].Value = MthsOfWorkAtOffice2;
                paramRV[57] = new OleDbParameter("@CommentsOfNeighbour2", OleDbType.VarChar, 255);
                paramRV[57].Value = CommentsOfNeighbour2;
                paramRV[58] = new OleDbParameter("@TypeOfAccmodation", OleDbType.VarChar, 100);
                paramRV[58].Value = TypeOfAccmodation;
                paramRV[59] = new OleDbParameter("@EntryPermitted", OleDbType.VarChar, 50);
                paramRV[59].Value = EntryPermitted;
                paramRV[60] = new OleDbParameter("@IdentityProofSeen", OleDbType.VarChar, 50);
                paramRV[60].Value = IdentityProofSeen;
                paramRV[61] = new OleDbParameter("@ApplicantIncome", OleDbType.VarChar, 50);
                paramRV[61].Value = ApplicantIncome;
                paramRV[62] = new OleDbParameter("@NameOfCompany", OleDbType.VarChar, 100);
                paramRV[62].Value = NameOfCompany;
                paramRV[63] = new OleDbParameter("@PurposeOfLoanTaken", OleDbType.VarChar, 255);
                paramRV[63].Value = PurposeOfLoanTaken;
                paramRV[64] = new OleDbParameter("@OtherSourceOfIncome", OleDbType.VarChar, 100);
                paramRV[64].Value = OtherSourceOfIncome;
                paramRV[65] = new OleDbParameter("@OtherInvestment", OleDbType.VarChar, 100);
                paramRV[65].Value = OtherInvestment;
                paramRV[66] = new OleDbParameter("@ClourOnDoor", OleDbType.VarChar, 50);
                paramRV[66].Value = ClourOnDoor;
                paramRV[67] = new OleDbParameter("@RoomType", OleDbType.VarChar, 100);
                paramRV[67].Value = RoomType;
                paramRV[68] = new OleDbParameter("@TypeOfHouse", OleDbType.VarChar, 50);
                paramRV[68].Value = TypeOfHouse;
                paramRV[69] = new OleDbParameter("@AnyOtherLoanOnApplicantName", OleDbType.VarChar, 100);
                paramRV[69].Value = AnyOtherLoanOnApplicantName;
                paramRV[70] = new OleDbParameter("@VehiclesOwnership", OleDbType.VarChar, 100);
                paramRV[70].Value = VehiclesOwnership;
                paramRV[71] = new OleDbParameter("@MatchInNegativeList", OleDbType.VarChar, 100);
                paramRV[71].Value = MatchInNegativeList;              
                paramRV[72] = new OleDbParameter("@ApproachToResidence", OleDbType.VarChar, 100);
                paramRV[72].Value = ApproachToResidence;
                paramRV[73] = new OleDbParameter("@TypeOfRoof", OleDbType.VarChar, 100);
                paramRV[73].Value = TypeOfRoof;
                paramRV[74] = new OleDbParameter("@TeleCDRomCheck", OleDbType.VarChar, 50);
                paramRV[74].Value = TeleCDRomCheck;
                paramRV[75] = new OleDbParameter("@LocationOfHouse", OleDbType.VarChar, 100);
                paramRV[75].Value = LocationOfHouse;
                paramRV[76] = new OleDbParameter("@ApporachToHouse", OleDbType.VarChar, 50);
                paramRV[76].Value = ApporachToHouse;
                paramRV[77] = new OleDbParameter("@StandardOfLiving", OleDbType.VarChar, 100);
                paramRV[77].Value = StandardOfLiving;
                paramRV[78] = new OleDbParameter("@Walls", OleDbType.VarChar, 100);
                paramRV[78].Value = Walls;
                paramRV[79] = new OleDbParameter("@Flooring", OleDbType.VarChar, 100);
                paramRV[79].Value = Flooring;
                paramRV[80] = new OleDbParameter("@IsAddOfAppSame", OleDbType.VarChar, 50);
                paramRV[80].Value = IsAddOfAppSame;
                paramRV[81] = new OleDbParameter("@NoOfMembers", OleDbType.VarChar, 50);
                paramRV[81].Value = NoOfMembers;
                paramRV[82] = new OleDbParameter("@AgeOfApplicant", OleDbType.VarChar, 50);
                paramRV[82].Value = AgeOfApplicant;
                paramRV[83] = new OleDbParameter("@NameAddOfThirdParty", OleDbType.VarChar, 255);
                paramRV[83].Value = NameAddOfThirdParty;
                paramRV[84] = new OleDbParameter("@TimeWhenAppIsHome", OleDbType.VarChar, 50);
                paramRV[84].Value = TimeWhenAppIsHome;
                paramRV[85] = new OleDbParameter("@ThirdPartyComments", OleDbType.VarChar, 255);
                paramRV[85].Value = ThirdPartyComments;
                paramRV[86] = new OleDbParameter("@AddressProofSighted", OleDbType.VarChar, 50);
                paramRV[86].Value = AddressProofSighted;
                paramRV[87] = new OleDbParameter("@TalliesWithCurrentAddress", OleDbType.VarChar, 50);
                paramRV[87].Value = TalliesWithCurrentAddress;
                paramRV[88] = new OleDbParameter("@TypeOfAddProof", OleDbType.VarChar, 50);
                paramRV[88].Value = TypeOfAddProof;
                paramRV[89] = new OleDbParameter("@ResiOCL", OleDbType.VarChar, 50);
                paramRV[89].Value = ResiOCL;
                paramRV[90] = new OleDbParameter("@IsAffilatedToPoliticalParty", OleDbType.VarChar, 50);
                paramRV[90].Value = IsAffilatedToPoliticalParty;
                paramRV[91] = new OleDbParameter("@Profile", OleDbType.VarChar, 255);
                paramRV[91].Value = Profile;
                paramRV[92] = new OleDbParameter("@AddressConfirmed", OleDbType.VarChar, 50);
                paramRV[92].Value = AddressConfirmed;
                paramRV[93] = new OleDbParameter("@HowCooperativeCustomer", OleDbType.VarChar, 100);
                paramRV[93].Value = HowCooperativeCustomer;
                paramRV[94] = new OleDbParameter("@EaseOfLocation", OleDbType.VarChar, 255);
                paramRV[94].Value = EaseOfLocation;
                paramRV[95] = new OleDbParameter("@AgencyCode", OleDbType.VarChar, 100);
                paramRV[95].Value = AgencyCode;
                paramRV[96] = new OleDbParameter("@Accessibility", OleDbType.VarChar, 100);
                paramRV[96].Value = Accessibility;
                paramRV[97] = new OleDbParameter("@EntranceMotorable", OleDbType.VarChar, 50);
                paramRV[97].Value = EntranceMotorable;
                paramRV[98] = new OleDbParameter("@SocietyBoardSighted", OleDbType.VarChar, 50);
                paramRV[98].Value = SocietyBoardSighted;
                paramRV[99] = new OleDbParameter("@MothersName", OleDbType.VarChar, 100);
                paramRV[99].Value = MothersName;
                paramRV[100] = new OleDbParameter("@AddressOfCompany", OleDbType.VarChar, 255);
                paramRV[100].Value = AddressOfCompany;
                paramRV[101] = new OleDbParameter("@BehavourOfPersonContact", OleDbType.VarChar, 100);
                paramRV[101].Value = BehavourOfPersonContact;
                paramRV[102] = new OleDbParameter("@VerifierComments", OleDbType.VarChar, 2000);
                paramRV[102].Value = VerifierComments;
                paramRV[103] = new OleDbParameter("@OverallVerification", OleDbType.VarChar, 50);
                paramRV[103].Value = OverallVerification;
                paramRV[104] = new OleDbParameter("@NoOfEaringMembers", OleDbType.VarChar, 10);
                paramRV[104].Value = NoOfEaringMembers;
                paramRV[105] = new OleDbParameter("@IfVehicleExist", OleDbType.VarChar, 10);
                paramRV[105].Value = IfVehicleExist;
                paramRV[106] = new OleDbParameter("@VehicleType", OleDbType.VarChar, 50);
                paramRV[106].Value = VehicleType;
                paramRV[107] = new OleDbParameter("@DoorLocked", OleDbType.VarChar, 50);
                paramRV[107].Value = DoorLocked;
                paramRV[108] = new OleDbParameter("@SendDate", OleDbType.VarChar, 50);
                paramRV[108].Value = SendDate;
                paramRV[109] = new OleDbParameter("@TotalYrsInCity", OleDbType.VarChar, 50);
                paramRV[109].Value = TotalYrsInCity;
                paramRV[110] = new OleDbParameter("@NameAddOf1Reference", OleDbType.VarChar, 255);
                paramRV[110].Value = NameAddOf1Reference;
                paramRV[111] = new OleDbParameter("@IfOCLDistance", OleDbType.VarChar, 50);
                paramRV[111].Value = IfOCLDistance;
                paramRV[112] = new OleDbParameter("@ParkingFacility", OleDbType.VarChar, 50);
                paramRV[112].Value = ParkingFacility;
                paramRV[113] = new OleDbParameter("@Negmatch", OleDbType.VarChar, 10);
                paramRV[113].Value = Negmatch;
                paramRV[114] = new OleDbParameter("@ReasonForNotRecomdNReferred", OleDbType.VarChar, 255);
                paramRV[114].Value = ReasonForNotRecomdNReferred;
                paramRV[115] = new OleDbParameter("@FatherSpouseName", OleDbType.VarChar, 100);
                paramRV[115].Value = FatherSpouseName;
                paramRV[116] = new OleDbParameter("@DateTimeOfVerification", OleDbType.VarChar, 50);
                paramRV[116].Value = DateTimeOfVerification;
                paramRV[117] = new OleDbParameter("@AddedBy", OleDbType.VarChar, 15);
                paramRV[117].Value = AddedBy;
                paramRV[118] = new OleDbParameter("@AddedOn", OleDbType.DBTimeStamp);
                paramRV[118].Value = AddedOn;
                paramRV[119] = new OleDbParameter("@SeparateBathroom", OleDbType.VarChar, 15);
                paramRV[119].Value = SeparateBathroom;
                paramRV[120] = new OleDbParameter("@FamilySeen", OleDbType.VarChar, 15);
                paramRV[120].Value = FamilySeen;
                paramRV[121] = new OleDbParameter("@SupervisorComment", OleDbType.VarChar, 250);
                paramRV[121].Value = SupervisorComment;
                paramRV[122] = new OleDbParameter("@RoofType", OleDbType.VarChar, 50);
                paramRV[122].Value = RoofType;
                paramRV[123] = new OleDbParameter("@Verifier", OleDbType.VarChar, 100);
                paramRV[123].Value = Verifier;
                paramRV[124] = new OleDbParameter("@CityLimit", OleDbType.VarChar, 100);
                paramRV[124].Value = CityLimit;
                //added by kamal matekar...
                paramRV[125] = new OleDbParameter("@Pager_No", OleDbType.VarChar, 100);
                paramRV[125].Value = PagerNo;
                paramRV[126] = new OleDbParameter("@Visible_Items", OleDbType.VarChar, 100);
                paramRV[126].Value = VisibleItems;
                paramRV[127] = new OleDbParameter("@No_of_Windows", OleDbType.VarChar, 100);
                paramRV[127].Value = NoOfWindow;
                paramRV[128] = new OleDbParameter("@Children", OleDbType.VarChar, 100);
                paramRV[128].Value = NoOfWindow;
                paramRV[129] = new OleDbParameter("@Emp_Designation", OleDbType.VarChar, 500);
                paramRV[129].Value = EmpDesignation;
                paramRV[130] = new OleDbParameter("@Car_Park", OleDbType.VarChar, 500);
                paramRV[130].Value = CarPark;
                paramRV[131] = new OleDbParameter("@Resi_Exti", OleDbType.VarChar, 500);
                paramRV[131].Value = ResiExti;
                paramRV[132] = new OleDbParameter("@Resi_Intl", OleDbType.VarChar, 500);
                paramRV[132].Value = ResiIntl;
                paramRV[133] = new OleDbParameter("@Cons_House", OleDbType.VarChar, 500);
                paramRV[133].Value = ConsHouse;
                paramRV[134] = new OleDbParameter("@Resi_Ext", OleDbType.VarChar, 500);
                paramRV[134].Value = ResiExt;    
                //ended by kamal matekar...........


                sRetVal = "Record added successfully.";
            }
            else
            {
                //update query
                sSql = "UPDATE CPV_RL_VERIFICATION_RVRT SET PERSON_CONTACTED=?,Relationship=?," +
                     "Address=?,CITY=?,PINCODE=?,Landmark=?,TEL_NO_TYPE_PHONE=?,Mobile_No_type_phone=?,Loan_Amount=?,Use_of_loan=?,Product=?,Location_Product=?," +
                     "DOB=?,MARITAL_STATUS=?,EDUCATION_BACKGROUND=?,FAMILY_DETAILS=?,SPOUSE_DETAILS=?,FAMILY_INCOME=?," +
                     "OTHER_DETAILS=?,Loan_Cancellation=?,CREDIT_CARD_LIMIT=?,OTHER_LOAN_DATAIL=?,YEARS_AT_RESIDENCE=?," +
                     "Area_of_House=?,ASSETS=?,DETAIL_FURNITURE_SEEN=?,Ownership_RESIDENCE=?,STAYING_WHOM=?,DSA=?,Tenure=?," +
                     "Months=?,Type=?,Name_Society_Board=?,Nameplate_on_door=?,Ownership_Details=?,Permanent_address=?," +
                     "Number_rooms=?,Approximate_Value=?,Bachelor_Accomodation=?,Locality=?,Vehicles_used=?,Vehicles_financed=?," +
                     "Exterior_Premises=?,interior_Premises=?,Name_Neighbour1=?,ADD_Neighbour1=?,CONFIRM_Neighbour1=?,RESSTATUS_Neighbour1=?," +
                     "Stay_Res_Neighbour1=?,Comments_Neighbour1=?,Name_Neighbour2=?,ADD_Neighbour2=?,CONFIRM_Neighbour2=?,RESSTATUS_Neighbour2=?," +
                     "Stay_Res_Neighbour2=?,Comments_Neighbour2=?,Type_Accmodation=?,Entry_Permitted=?,Identity_Proof_Seen=?," +
                     "Applicant_income=?,Company_name=?,Purpose_loan=?,other_source_income=?,Other_Investment=?,Colour_of_Door=?," +
                     "Room_Type=?,Type_of_House=?,loan_applicant_name=?,Vehicles_Ownership=?,Residence_address_negative=?," +
                     "Approch_Residence=?,Type_Roof=?,Telephone_check=?,Location_house=?,approch_to_house=?," +
                     "Standard_of_Living=?,Walls=?,Flooring=?,IS_appname_address=?,No_of_dependent=?,age_applicant=?,Name_add_third_party=?," +
                     "Time_app_at_home=?,Third_party_comment=?,Address_Proof_Sighted=?,Tallies_current_Address=?,Type_of_Add_Proof=?," +
                     "Resi_OCL=?,Affliated_Political_Party=?,Profile=?,Address_Confirmed=?,How_Cooperative=?,Locating_address=?," +
                     "Agency_Code=?,Accessibility=?,Entrance_Motorable=?,Society_Board_Sighted=?,Mother_Name=?,Address_Company=?," +
                     "Behavior_Person_Contacted=?,Verifier_Comments=?,Verification_status=?,No_of_earning_member=?,If_Vehicle_exist=?," +
                     "Vehicle_Type=?,Door_Locked=?,Sent_Datetime=?,Totals_Yrs_City=?,Name_add_Ref1=?,OCL_than_distance=?,Parking_Facility=?," +
                     "Neg_match=?,Reason_Notrecommended=?,Father_Spouse_Name=?,VERIFICATION_DATETIME=?,MODIFY_BY=?,MODIFY_DATE=?, " +
                     "SEP_BATHROOM_SEEN=?,FAMILY_SEEN=?,SUPERVISOR_COMMENTS=?,ROOF_TYPE=?,Verifier=?,City_Limit=?,Pager_No=?,Visible_Items=?, " +
                     "No_of_Windows=?,Children=?,Emp_Designation=?,Car_Park=?,Resi_Exti=?,Resi_Intl=?,Cons_House=?,Resi_Ext=? " +
                     " WHERE CASE_ID=? and VERIFICATION_TYPE_ID=? ";
                
                paramRV[0] = new OleDbParameter("@NameOfPersonMet", OleDbType.VarChar, 100);
                paramRV[0].Value = NameOfPersonMet;
                paramRV[1] = new OleDbParameter("@Relationship", OleDbType.VarChar, 100);
                paramRV[1].Value = Relationship;
                paramRV[2] = new OleDbParameter("@Address", OleDbType.VarChar, 255);
                paramRV[2].Value = Address;
                paramRV[3] = new OleDbParameter("@City", OleDbType.VarChar, 100);
                paramRV[3].Value = City;
                paramRV[4] = new OleDbParameter("@PinCode", OleDbType.VarChar, 20);
                paramRV[4].Value = PinCode;
                paramRV[5] = new OleDbParameter("@Landmark", OleDbType.VarChar, 100);
                paramRV[5].Value = Landmark;
                paramRV[6] = new OleDbParameter("@TeleNoType", OleDbType.VarChar, 100);
                paramRV[6].Value = TeleNoType;
                paramRV[7] = new OleDbParameter("@MobileNoType", OleDbType.VarChar, 100);
                paramRV[7].Value = MobileNoType;
                paramRV[8] = new OleDbParameter("@LoanAmount", OleDbType.VarChar, 50);
                paramRV[8].Value = LoanAmount;
                paramRV[9] = new OleDbParameter("@UseOfLoan", OleDbType.VarChar, 255);
                paramRV[9].Value = UseOfLoan;
                paramRV[10] = new OleDbParameter("@Product", OleDbType.VarChar, 100);
                paramRV[10].Value = Product;
                paramRV[11] = new OleDbParameter("@LocationOfProduct", OleDbType.VarChar, 100);
                paramRV[11].Value = LocationOfProduct;
                paramRV[12] = new OleDbParameter("@DateOfBirth", OleDbType.VarChar, 30);
                paramRV[12].Value = DateOfBirth;
                paramRV[13] = new OleDbParameter("@MaritalStatus", OleDbType.VarChar, 50);
                paramRV[13].Value = MaritalStatus;
                paramRV[14] = new OleDbParameter("@EducationalBackground", OleDbType.VarChar, 100);
                paramRV[14].Value = EducationalBackground;
                paramRV[15] = new OleDbParameter("@FamilyDetails", OleDbType.VarChar, 255);
                paramRV[15].Value = FamilyDetails;
                paramRV[16] = new OleDbParameter("@DetailsOfWorkingMemberSpouse", OleDbType.VarChar, 255);
                paramRV[16].Value = DetailsOfWorkingMemberSpouse;
                paramRV[17] = new OleDbParameter("@TotalFamIncome", OleDbType.VarChar, 50);
                paramRV[17].Value = TotalFamIncome;
                paramRV[18] = new OleDbParameter("@DetailsOfWorkingMembersOthers", OleDbType.VarChar, 255);
                paramRV[18].Value = DetailsOfWorkingMembersOthers;
                paramRV[19] = new OleDbParameter("@LoanCancellation", OleDbType.VarChar, 50);
                paramRV[19].Value = LoanCancellation;
                paramRV[20] = new OleDbParameter("@AnyCreditCard", OleDbType.VarChar, 255);
                paramRV[20].Value = AnyCreditCard;
                paramRV[21] = new OleDbParameter("@AnyOtherLoan", OleDbType.VarChar, 255);
                paramRV[21].Value = AnyOtherLoan;
                paramRV[22] = new OleDbParameter("@NoOfYrsAtResidence", OleDbType.VarChar, 20);
                paramRV[22].Value = NoOfYrsAtResidence;
                paramRV[23] = new OleDbParameter("@AreaOfHouse", OleDbType.VarChar, 20);
                paramRV[23].Value = AreaOfHouse;
                paramRV[24] = new OleDbParameter("@Assets", OleDbType.VarChar, 100);
                paramRV[24].Value = Assets;
                paramRV[25] = new OleDbParameter("@DetailsOfFurnitureSeen", OleDbType.VarChar, 255);
                paramRV[25].Value = DetailsOfFurnitureSeen;
                paramRV[26] = new OleDbParameter("@OwnershipOfResidence", OleDbType.VarChar, 50);
                paramRV[26].Value = OwnershipOfResidence;
                paramRV[27] = new OleDbParameter("@StayingWithWhom", OleDbType.VarChar, 100);
                paramRV[27].Value = StayingWithWhom;
                paramRV[28] = new OleDbParameter("@DSA", OleDbType.VarChar, 50);
                paramRV[28].Value = DSA;
                paramRV[29] = new OleDbParameter("@Tenure", OleDbType.VarChar, 100);
                paramRV[29].Value = Tenure;
                paramRV[30] = new OleDbParameter("@Months", OleDbType.VarChar, 10);
                paramRV[30].Value = Months;
                paramRV[31] = new OleDbParameter("@TotalFamIncome", OleDbType.VarChar, 50);
                paramRV[31].Value = Type;
                paramRV[32] = new OleDbParameter("@NameOnSocietyAddressBoard", OleDbType.VarChar, 100);
                paramRV[32].Value = NameOnSocietyAddressBoard;
                paramRV[33] = new OleDbParameter("@NameplateOnDoor", OleDbType.VarChar, 50);
                paramRV[33].Value = NameplateOnDoor;
                paramRV[34] = new OleDbParameter("@OwnershipDetail", OleDbType.VarChar, 100);
                paramRV[34].Value = OwnershipDetail;
                paramRV[35] = new OleDbParameter("@PermanentAddress", OleDbType.VarChar, 255);
                paramRV[35].Value = PermanentAddress;
                paramRV[36] = new OleDbParameter("@NoOfRooms", OleDbType.VarChar, 50);
                paramRV[36].Value = NoOfRooms;
                paramRV[37] = new OleDbParameter("@ApproximateValue", OleDbType.VarChar, 50);
                paramRV[37].Value = ApproximateValue;
                paramRV[38] = new OleDbParameter("@BachelorAccomodation", OleDbType.VarChar, 50);
                paramRV[38].Value = BachelorAccomodation;
                paramRV[39] = new OleDbParameter("@Locality", OleDbType.VarChar, 50);
                paramRV[39].Value = Locality;
                paramRV[40] = new OleDbParameter("@VehiclesCurrentlyUsed", OleDbType.VarChar, 100);
                paramRV[40].Value = VehiclesCurrentlyUsed;
                paramRV[41] = new OleDbParameter("@VehiclesFinancedNFinancerName", OleDbType.VarChar, 100);
                paramRV[41].Value = VehiclesFinancedNFinancerName;
                paramRV[42] = new OleDbParameter("@DescribeExteriorPremises", OleDbType.VarChar, 100);
                paramRV[42].Value = DescribeExteriorPremises;
                paramRV[43] = new OleDbParameter("@DescribeInteriorPremises", OleDbType.VarChar, 100);
                paramRV[43].Value = DescribeInteriorPremises;
                paramRV[44] = new OleDbParameter("@NameOfNeighbour1", OleDbType.VarChar, 100);
                paramRV[44].Value = NameOfNeighbour1;
                paramRV[45] = new OleDbParameter("@AddressOfNeighbour1", OleDbType.VarChar, 255);
                paramRV[45].Value = AddressOfNeighbour1;
                paramRV[46] = new OleDbParameter("@DoesAppWorkHere1", OleDbType.VarChar, 100);
                paramRV[46].Value = DoesAppWorkHere1;
                paramRV[47] = new OleDbParameter("@StatusOfResidence1", OleDbType.VarChar, 50);
                paramRV[47].Value = StatusOfResidence1;
                paramRV[48] = new OleDbParameter("@MthsOfWorkAtOffice1", OleDbType.VarChar, 50);
                paramRV[48].Value = MthsOfWorkAtOffice1;
                paramRV[49] = new OleDbParameter("@CommentsOfNeighbour1", OleDbType.VarChar, 255);
                paramRV[49].Value = CommentsOfNeighbour1;
                paramRV[50] = new OleDbParameter("@NameOfNeighbour2", OleDbType.VarChar, 100);
                paramRV[50].Value = NameOfNeighbour2;
                paramRV[51] = new OleDbParameter("@AddressOfNeighbour2", OleDbType.VarChar, 255);
                paramRV[51].Value = AddressOfNeighbour2;
                paramRV[52] = new OleDbParameter("@DoesAppWorkHere2", OleDbType.VarChar, 100);
                paramRV[52].Value = DoesAppWorkHere2;
                paramRV[53] = new OleDbParameter("@StatusOfResidence2", OleDbType.VarChar, 50);
                paramRV[53].Value = StatusOfResidence2;
                paramRV[54] = new OleDbParameter("@MthsOfWorkAtOffice2", OleDbType.VarChar, 50);
                paramRV[54].Value = MthsOfWorkAtOffice2;
                paramRV[55] = new OleDbParameter("@CommentsOfNeighbour2", OleDbType.VarChar, 255);
                paramRV[55].Value = CommentsOfNeighbour2;
                paramRV[56] = new OleDbParameter("@TypeOfAccmodation", OleDbType.VarChar, 100);
                paramRV[56].Value = TypeOfAccmodation;
                paramRV[57] = new OleDbParameter("@EntryPermitted", OleDbType.VarChar, 50);
                paramRV[57].Value = EntryPermitted;
                paramRV[58] = new OleDbParameter("@IdentityProofSeen", OleDbType.VarChar, 50);
                paramRV[58].Value = IdentityProofSeen;
                paramRV[59] = new OleDbParameter("@ApplicantIncome", OleDbType.VarChar, 50);
                paramRV[59].Value = ApplicantIncome;
                paramRV[60] = new OleDbParameter("@NameOfCompany", OleDbType.VarChar, 100);
                paramRV[60].Value = NameOfCompany;
                paramRV[61] = new OleDbParameter("@PurposeOfLoanTaken", OleDbType.VarChar, 255);
                paramRV[61].Value = PurposeOfLoanTaken;
                paramRV[62] = new OleDbParameter("@OtherSourceOfIncome", OleDbType.VarChar, 100);
                paramRV[62].Value = OtherSourceOfIncome;
                paramRV[63] = new OleDbParameter("@OtherInvestment", OleDbType.VarChar, 100);
                paramRV[63].Value = OtherInvestment;
                paramRV[64] = new OleDbParameter("@ClourOnDoor", OleDbType.VarChar, 50);
                paramRV[64].Value = ClourOnDoor;
                paramRV[65] = new OleDbParameter("@RoomType", OleDbType.VarChar, 100);
                paramRV[65].Value = RoomType;
                paramRV[66] = new OleDbParameter("@TypeOfHouse", OleDbType.VarChar, 50);
                paramRV[66].Value = TypeOfHouse;
                paramRV[67] = new OleDbParameter("@AnyOtherLoanOnApplicantName", OleDbType.VarChar, 100);
                paramRV[67].Value = AnyOtherLoanOnApplicantName;
                paramRV[68] = new OleDbParameter("@VehiclesOwnership", OleDbType.VarChar, 100);
                paramRV[68].Value = VehiclesOwnership;
                paramRV[69] = new OleDbParameter("@MatchInNegativeList", OleDbType.VarChar, 100);
                paramRV[69].Value = MatchInNegativeList;                
                paramRV[70] = new OleDbParameter("@ApproachToResidence", OleDbType.VarChar, 100);
                paramRV[70].Value = ApproachToResidence;
                paramRV[71] = new OleDbParameter("@TypeOfRoof", OleDbType.VarChar, 100);
                paramRV[71].Value = TypeOfRoof;
                paramRV[72] = new OleDbParameter("@TeleCDRomCheck", OleDbType.VarChar, 50);
                paramRV[72].Value = TeleCDRomCheck;
                paramRV[73] = new OleDbParameter("@LocationOfHouse", OleDbType.VarChar, 100);
                paramRV[73].Value = LocationOfHouse;
                paramRV[74] = new OleDbParameter("@ApporachToHouse", OleDbType.VarChar, 50);
                paramRV[74].Value = ApporachToHouse;
                paramRV[75] = new OleDbParameter("@StandardOfLiving", OleDbType.VarChar, 100);
                paramRV[75].Value = StandardOfLiving;
                paramRV[76] = new OleDbParameter("@Walls", OleDbType.VarChar, 100);
                paramRV[76].Value = Walls;
                paramRV[77] = new OleDbParameter("@Flooring", OleDbType.VarChar, 100);
                paramRV[77].Value = Flooring;
                paramRV[78] = new OleDbParameter("@IsAddOfAppSame", OleDbType.VarChar, 50);
                paramRV[78].Value = IsAddOfAppSame;
                paramRV[79] = new OleDbParameter("@NoOfMembers", OleDbType.VarChar, 50);
                paramRV[79].Value = NoOfMembers;
                paramRV[80] = new OleDbParameter("@AgeOfApplicant", OleDbType.VarChar, 50);
                paramRV[80].Value = AgeOfApplicant;
                paramRV[81] = new OleDbParameter("@NameAddOfThirdParty", OleDbType.VarChar, 255);
                paramRV[81].Value = NameAddOfThirdParty;
                paramRV[82] = new OleDbParameter("@TimeWhenAppIsHome", OleDbType.VarChar, 50);
                paramRV[82].Value = TimeWhenAppIsHome;
                paramRV[83] = new OleDbParameter("@ThirdPartyComments", OleDbType.VarChar, 255);
                paramRV[83].Value = ThirdPartyComments;
                paramRV[84] = new OleDbParameter("@AddressProofSighted", OleDbType.VarChar, 50);
                paramRV[84].Value = AddressProofSighted;
                paramRV[85] = new OleDbParameter("@TalliesWithCurrentAddress", OleDbType.VarChar, 50);
                paramRV[85].Value = TalliesWithCurrentAddress;
                paramRV[86] = new OleDbParameter("@TypeOfAddProof", OleDbType.VarChar, 50);
                paramRV[86].Value = TypeOfAddProof;
                paramRV[87] = new OleDbParameter("@ResiOCL", OleDbType.VarChar, 50);
                paramRV[87].Value = ResiOCL;
                paramRV[88] = new OleDbParameter("@IsAffilatedToPoliticalParty", OleDbType.VarChar, 50);
                paramRV[88].Value = IsAffilatedToPoliticalParty;
                paramRV[89] = new OleDbParameter("@Profile", OleDbType.VarChar, 255);
                paramRV[89].Value = Profile;
                paramRV[90] = new OleDbParameter("@AddressConfirmed", OleDbType.VarChar, 50);
                paramRV[90].Value = AddressConfirmed;
                paramRV[91] = new OleDbParameter("@HowCooperativeCustomer", OleDbType.VarChar, 100);
                paramRV[91].Value = HowCooperativeCustomer;
                paramRV[92] = new OleDbParameter("@EaseOfLocation", OleDbType.VarChar, 255);
                paramRV[92].Value = EaseOfLocation;
                paramRV[93] = new OleDbParameter("@AgencyCode", OleDbType.VarChar, 100);
                paramRV[93].Value = AgencyCode;
                paramRV[94] = new OleDbParameter("@Accessibility", OleDbType.VarChar, 100);
                paramRV[94].Value = Accessibility;
                paramRV[95] = new OleDbParameter("@EntranceMotorable", OleDbType.VarChar, 50);
                paramRV[95].Value = EntranceMotorable;
                paramRV[96] = new OleDbParameter("@SocietyBoardSighted", OleDbType.VarChar, 50);
                paramRV[96].Value = SocietyBoardSighted;
                paramRV[97] = new OleDbParameter("@MothersName", OleDbType.VarChar, 100);
                paramRV[97].Value = MothersName;
                paramRV[98] = new OleDbParameter("@AddressOfCompany", OleDbType.VarChar, 255);
                paramRV[98].Value = AddressOfCompany;
                paramRV[99] = new OleDbParameter("@BehavourOfPersonContact", OleDbType.VarChar, 100);
                paramRV[99].Value = BehavourOfPersonContact;
                paramRV[100] = new OleDbParameter("@VerifierComments", OleDbType.VarChar, 2000);
                paramRV[100].Value = VerifierComments;
                paramRV[101] = new OleDbParameter("@OverallVerification", OleDbType.VarChar, 50);
                paramRV[101].Value = OverallVerification;
                paramRV[102] = new OleDbParameter("@NoOfEaringMembers", OleDbType.VarChar, 10);
                paramRV[102].Value = NoOfEaringMembers;
                paramRV[103] = new OleDbParameter("@IfVehicleExist", OleDbType.VarChar, 10);
                paramRV[103].Value = IfVehicleExist;
                paramRV[104] = new OleDbParameter("@VehicleType", OleDbType.VarChar, 50);
                paramRV[104].Value = VehicleType;
                paramRV[105] = new OleDbParameter("@DoorLocked", OleDbType.VarChar, 50);
                paramRV[105].Value = DoorLocked;
                paramRV[106] = new OleDbParameter("@SendDate", OleDbType.VarChar, 50);
                paramRV[106].Value = SendDate;
                paramRV[107] = new OleDbParameter("@TotalYrsInCity", OleDbType.VarChar, 50);
                paramRV[107].Value = TotalYrsInCity;
                paramRV[108] = new OleDbParameter("@NameAddOf1Reference", OleDbType.VarChar, 255);
                paramRV[108].Value = NameAddOf1Reference;
                paramRV[109] = new OleDbParameter("@IfOCLDistance", OleDbType.VarChar, 50);
                paramRV[109].Value = IfOCLDistance;
                paramRV[110] = new OleDbParameter("@ParkingFacility", OleDbType.VarChar, 50);
                paramRV[110].Value = ParkingFacility;
                paramRV[111] = new OleDbParameter("@Negmatch", OleDbType.VarChar, 10);
                paramRV[111].Value = Negmatch;
                paramRV[112] = new OleDbParameter("@ReasonForNotRecomdNReferred", OleDbType.VarChar, 255);
                paramRV[112].Value = ReasonForNotRecomdNReferred;
                paramRV[113] = new OleDbParameter("@FatherSpouseName", OleDbType.VarChar, 100);
                paramRV[113].Value = FatherSpouseName;
                paramRV[114] = new OleDbParameter("@DateTimeOfVerification", OleDbType.VarChar, 50);
                paramRV[114].Value = DateTimeOfVerification;
                paramRV[115] = new OleDbParameter("@ModifyBy", OleDbType.VarChar, 15);
                paramRV[115].Value = ModifyBy;
                paramRV[116] = new OleDbParameter("@ModifyOn", OleDbType.DBTimeStamp);
                paramRV[116].Value = ModifyOn;
                paramRV[117] = new OleDbParameter("@SeparateBathroom", OleDbType.VarChar, 15);
                paramRV[117].Value = SeparateBathroom;
                paramRV[118] = new OleDbParameter("@FamilySeen", OleDbType.VarChar, 15);
                paramRV[118].Value = FamilySeen;
                paramRV[119] = new OleDbParameter("@SupervisorComment", OleDbType.VarChar, 250);
                paramRV[119].Value = SupervisorComment;
                paramRV[120] = new OleDbParameter("@RoofType", OleDbType.VarChar, 50);
                paramRV[120].Value = RoofType;
                paramRV[121] = new OleDbParameter("@Verifier", OleDbType.VarChar, 100);
                paramRV[121].Value = Verifier;
                paramRV[122] = new OleDbParameter("@CityLimit", OleDbType.VarChar, 100);
                paramRV[122].Value = CityLimit; 
                //add by kamal matekar.....
                paramRV[123] = new OleDbParameter("@Pager_No", OleDbType.VarChar, 100);
                paramRV[123].Value = PagerNo;
                paramRV[124] = new OleDbParameter("@Visible_Items", OleDbType.VarChar, 100);
                paramRV[124].Value = VisibleItems;
                paramRV[125] = new OleDbParameter("@No_of_Windows", OleDbType.VarChar, 100);
                paramRV[125].Value = NoOfWindow;
                paramRV[126] = new OleDbParameter("@Children", OleDbType.VarChar, 100);
                paramRV[126].Value = Children;
                paramRV[127] = new OleDbParameter("@Emp_Designation", OleDbType.VarChar, 500);
                paramRV[127].Value = EmpDesignation;
                paramRV[128] = new OleDbParameter("@Car_Park", OleDbType.VarChar, 500);
                paramRV[128].Value = CarPark;
                paramRV[129] = new OleDbParameter("@Resi_Exti", OleDbType.VarChar, 500);
                paramRV[129].Value = ResiExti;
                paramRV[130] = new OleDbParameter("@Resi_Intl", OleDbType.VarChar, 500);
                paramRV[130].Value = ResiIntl;
                paramRV[131] = new OleDbParameter("@Cons_House", OleDbType.VarChar, 500);
                paramRV[131].Value = ConsHouse;
                paramRV[132] = new OleDbParameter("@Resi_Ext", OleDbType.VarChar, 500);
                paramRV[132].Value = ResiExt;

                //ended by kamal matekar........
                paramRV[133] = new OleDbParameter("@CaseID", OleDbType.VarChar, 15);
                paramRV[133].Value = CaseId;
                paramRV[134] = new OleDbParameter("@VerificationTypeId", OleDbType.VarChar, 15);
                paramRV[134].Value = VerificationTypeId;

                sRetVal = "Record updated successfully.";

            }
            OleDbHelper.ExecuteNonQuery(oledbTrans, CommandType.Text, sSql, paramRV);

            //Start Insert into CASE_TRANSACTION_LOG -------------------
            sSql = "";
            sSql = "Insert into CASE_TRANSACTION_LOG(CASE_ID,VERIFICATION_TYPE_ID,USER_ID,TRANS_START,TRANS_END," +
                 "CENTRE_ID,PRODUCT_ID,CLIENT_ID) VALUES(?,?,?,?,?,?,?,?)";

            OleDbParameter[] paramTransLog = new OleDbParameter[8];
            paramTransLog[0] = new OleDbParameter("@CaseID", OleDbType.VarChar, 15);
            paramTransLog[0].Value = CaseId;
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

            //Update CPV_CC_Case_details with status 'Y' ---------------
            if (VerificationTypeId == "25" || VerificationTypeId == "26" || VerificationTypeId == "27" || VerificationTypeId == "28")
            {
                if (IsQCVerificationComplete(oledbTrans, CaseId, ClientId, CentreId) == "true")
                {
                    QCVerificationComplete(oledbTrans, CaseId);
                    sRetVal += " Case verification data entry completed.";
                }
            }
            else
            {
                if (IsVerificationComplete(oledbTrans, CaseId, ClientId, CentreId) == "true")
                {
                    VerificationComplete(oledbTrans, CaseId);
                    sRetVal += " Case verification data entry completed.";

                }
            }
            /////////////////////////////////////////////////////////////////////////////////////////////
            //End  Insert into CASE_TRANSACTION_LOG --------------------
            oledbTrans.Commit();
            oledbConn.Close();

            return sRetVal;
        }
        catch (Exception ex)
        {
            oledbTrans.Rollback();
            oledbConn.Close();
            throw new Exception("Error while Inserting/updating Verification entry. " + ex.Message);
        }
    }
    #endregion

    public string InsertUpdateRLResiVerificationEntry_Vend()
    {
        OleDbConnection oledbConn = new OleDbConnection(objCmn.ConnectionString);
        oledbConn.Open();
        OleDbTransaction oledbTrans = oledbConn.BeginTransaction();
        string sRetVal = "";
        try
        {
            string sSql = "";
            string sSqlRead = "";
            OleDbDataReader oledbRead;

            sSqlRead = "SELECT Case_ID,VERIFICATION_TYPE_ID from CPV_RL_VERIFICATION_REF " +
                       " WHERE Case_ID='" + CaseId + "'" +
                       " AND VERIFICATION_TYPE_ID='" + VerificationTypeId + "'";

            oledbRead = OleDbHelper.ExecuteReader(oledbTrans, CommandType.Text, sSqlRead);

            OleDbParameter[] paramRV = new OleDbParameter[12];

            if (oledbRead.Read() == false)
            {
                //insert query
                sSql = "INSERT INTO CPV_RL_VERIFICATION_REF(CASE_ID,VERIFICATION_TYPE_ID,Name_Seller_conf_neigh,Seller_aware, " +
                       " whom_sell_prop,buyer_name,sell_get_know_buy,sell_finan_institution,out_loan,mortgage,poss_doc,photo_Iden) " +
                       " VALUES(?,?,?,?,?,?,?,?,?,?,?,?) ";

                paramRV[0] = new OleDbParameter("@CaseID", OleDbType.VarChar, 15);
                paramRV[0].Value = CaseId;
                paramRV[1] = new OleDbParameter("@VerificationTypeId", OleDbType.VarChar, 15);
                paramRV[1].Value = VerificationTypeId;
                paramRV[2] = new OleDbParameter("@SellConfMem", OleDbType.VarChar, 500);
                paramRV[2].Value = SellConfMem;
                paramRV[3] = new OleDbParameter("@SellTran", OleDbType.VarChar, 500);
                paramRV[3].Value = SellTran;
                paramRV[4] = new OleDbParameter("@SellProp", OleDbType.VarChar, 500);
                paramRV[4].Value = SellProp;
                paramRV[5] = new OleDbParameter("@NameBuy", OleDbType.VarChar, 500);
                paramRV[5].Value = NameBuy;
                paramRV[6] = new OleDbParameter("@SellKnow", OleDbType.VarChar, 500);
                paramRV[6].Value = SellKnow;
                paramRV[7] = new OleDbParameter("@SellLoan", OleDbType.VarChar, 500);
                paramRV[7].Value = SellLoan;
                paramRV[8] = new OleDbParameter("@OutLoan", OleDbType.VarChar, 500);
                paramRV[8].Value = OutLoan;
                paramRV[9] = new OleDbParameter("@SellMorg", OleDbType.VarChar, 500);
                paramRV[9].Value = SellMorg;
                paramRV[10] = new OleDbParameter("@SellDoc", OleDbType.VarChar, 500);
                paramRV[10].Value = SellDoc;
                paramRV[11] = new OleDbParameter("@SellPhoto", OleDbType.VarChar, 500);
                paramRV[11].Value = SellPhoto;
                
               sRetVal = "Record added successfully.";
            }
            else
            {
                //update query
                sSql = "UPDATE CPV_RL_VERIFICATION_REF SET Name_Seller_conf_neigh=?,Seller_aware=?,whom_sell_prop=?, " +
                       " buyer_name=?,sell_get_know_buy=?,sell_finan_institution=?,out_loan=?,mortgage=?,poss_doc=?,photo_Iden=? " +
                       " WHERE CASE_ID=? and VERIFICATION_TYPE_ID=? ";

                paramRV[0] = new OleDbParameter("@SellConfMem", OleDbType.VarChar, 500);
                paramRV[0].Value = SellConfMem;
                paramRV[1] = new OleDbParameter("@SellTran", OleDbType.VarChar, 500);
                paramRV[1].Value = SellTran;
                paramRV[2] = new OleDbParameter("@SellProp", OleDbType.VarChar, 500);
                paramRV[2].Value = SellProp;
                paramRV[3] = new OleDbParameter("@NameBuy", OleDbType.VarChar, 500);
                paramRV[3].Value = NameBuy;
                paramRV[4] = new OleDbParameter("@SellKnow", OleDbType.VarChar, 500);
                paramRV[4].Value = SellKnow;
                paramRV[5] = new OleDbParameter("@SellLoan", OleDbType.VarChar, 500);
                paramRV[5].Value = SellLoan;
                paramRV[6] = new OleDbParameter("@OutLoan", OleDbType.VarChar, 500);
                paramRV[6].Value = OutLoan;
                paramRV[7] = new OleDbParameter("@SellMorg", OleDbType.VarChar, 500);
                paramRV[7].Value = SellMorg;
                paramRV[8] = new OleDbParameter("@SellDoc", OleDbType.VarChar, 500);
                paramRV[8].Value = SellDoc;
                paramRV[9] = new OleDbParameter("@SellPhoto", OleDbType.VarChar, 500);
                paramRV[9].Value = SellPhoto;
                paramRV[10] = new OleDbParameter("@CaseID", OleDbType.VarChar, 15);
                paramRV[10].Value = CaseId;
                paramRV[11] = new OleDbParameter("@VerificationTypeId", OleDbType.VarChar, 15);
                paramRV[11].Value = VerificationTypeId;


                sRetVal = "Record updated successfully.";

            }
            OleDbHelper.ExecuteNonQuery(oledbTrans, CommandType.Text, sSql, paramRV);

            //Start Insert into CASE_TRANSACTION_LOG -------------------
            sSql = "";
            sSql = "Insert into CASE_TRANSACTION_LOG(CASE_ID,VERIFICATION_TYPE_ID,USER_ID,TRANS_START,TRANS_END," +
                 "CENTRE_ID,PRODUCT_ID,CLIENT_ID) VALUES(?,?,?,?,?,?,?,?)";

            OleDbParameter[] paramTransLog = new OleDbParameter[8];
            paramTransLog[0] = new OleDbParameter("@CaseID", OleDbType.VarChar, 15);
            paramTransLog[0].Value = CaseId;
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

            //Update CPV_CC_Case_details with status 'Y' ---------------
            if (VerificationTypeId == "31" || VerificationTypeId == "25" || VerificationTypeId == "26" || VerificationTypeId == "27" || VerificationTypeId == "28")
            {
                if (IsQCVerificationComplete(oledbTrans, CaseId, ClientId, CentreId) == "true")
                {
                    QCVerificationComplete(oledbTrans, CaseId);
                    sRetVal += " Case verification data entry completed.";
                }
            }
            else
            {
                if (IsVerificationComplete(oledbTrans, CaseId, ClientId, CentreId) == "true")
                {
                    VerificationComplete(oledbTrans, CaseId);
                    sRetVal += " Case verification data entry completed.";

                }
            }
            /////////////////////////////////////////////////////////////////////////////////////////////
            //End  Insert into CASE_TRANSACTION_LOG --------------------
            oledbTrans.Commit();
            oledbConn.Close();

            return sRetVal;
        }
        catch (Exception ex)
        {
            oledbTrans.Rollback();
            oledbConn.Close();
            throw new Exception("Error while Inserting/updating Verification entry. " + ex.Message);
        }
    }

    public string InsertUpdateRLResiVerificationEntry_Noc()
    {
        OleDbConnection oledbConn = new OleDbConnection(objCmn.ConnectionString);
        oledbConn.Open();
        OleDbTransaction oledbTrans = oledbConn.BeginTransaction();
        string sRetVal = "";
        try
        {
            string sSql = "";
            string sSqlRead = "";
            OleDbDataReader oledbRead;

            sSqlRead = "SELECT Case_ID,VERIFICATION_TYPE_ID from CPV_RL_VERIFICATION_REF " +
                       " WHERE Case_ID='" + CaseId + "'" +
                       " AND VERIFICATION_TYPE_ID='" + VerificationTypeId + "'";

            oledbRead = OleDbHelper.ExecuteReader(oledbTrans, CommandType.Text, sSqlRead);

            OleDbParameter[] paramRV = new OleDbParameter[7];

            if (oledbRead.Read() == false)
            {
                //insert query
                sSql = "INSERT INTO CPV_RL_VERIFICATION_REF(CASE_ID,VERIFICATION_TYPE_ID,Name_Seller_conf_neigh,flat_no,Authenticity, " +
                       " Seller_aware,sell_finan_institution) " +
                       " VALUES(?,?,?,?,?,?,?) ";

                paramRV[0] = new OleDbParameter("@CaseID", OleDbType.VarChar, 15);
                paramRV[0].Value = CaseId;
                paramRV[1] = new OleDbParameter("@VerificationTypeId", OleDbType.VarChar, 15);
                paramRV[1].Value = VerificationTypeId;
                paramRV[2] = new OleDbParameter("@SellConfMem", OleDbType.VarChar, 500);
                paramRV[2].Value = SellConfMem;
                paramRV[3] = new OleDbParameter("@FlatNo", OleDbType.VarChar, 500);
                paramRV[3].Value = FlatNo;
                paramRV[4] = new OleDbParameter("@Authen", OleDbType.VarChar, 500);
                paramRV[4].Value = Authen;
                paramRV[5] = new OleDbParameter("@SellTran", OleDbType.VarChar, 500);
                paramRV[5].Value = SellTran; 
                paramRV[6] = new OleDbParameter("@SellLoan", OleDbType.VarChar, 500);
                paramRV[6].Value = SellLoan;

                sRetVal = "Record added successfully.";
            }
            else
            {
                //update query
                sSql = "UPDATE CPV_RL_VERIFICATION_REF SET Name_Seller_conf_neigh=?,flat_no=?,Authenticity=?,Seller_aware=?, " +
                       " sell_finan_institution=? WHERE CASE_ID=? and VERIFICATION_TYPE_ID=? ";

                paramRV[0] = new OleDbParameter("@SellConfMem", OleDbType.VarChar, 500);
                paramRV[0].Value = SellConfMem;
                paramRV[1] = new OleDbParameter("@FlatNo", OleDbType.VarChar, 500);
                paramRV[1].Value = FlatNo;
                paramRV[2] = new OleDbParameter("@Authen", OleDbType.VarChar, 500);
                paramRV[2].Value = Authen;
                paramRV[3] = new OleDbParameter("@SellTran", OleDbType.VarChar, 500);
                paramRV[3].Value = SellTran;
                paramRV[4] = new OleDbParameter("@SellLoan", OleDbType.VarChar, 500);
                paramRV[4].Value = SellLoan;
                paramRV[5] = new OleDbParameter("@CaseID", OleDbType.VarChar, 15);
                paramRV[5].Value = CaseId;
                paramRV[6] = new OleDbParameter("@VerificationTypeId", OleDbType.VarChar, 15);
                paramRV[6].Value = VerificationTypeId;


                sRetVal = "Record updated successfully.";

            }
            OleDbHelper.ExecuteNonQuery(oledbTrans, CommandType.Text, sSql, paramRV);

            //Start Insert into CASE_TRANSACTION_LOG -------------------
            sSql = "";
            sSql = "Insert into CASE_TRANSACTION_LOG(CASE_ID,VERIFICATION_TYPE_ID,USER_ID,TRANS_START,TRANS_END," +
                 "CENTRE_ID,PRODUCT_ID,CLIENT_ID) VALUES(?,?,?,?,?,?,?,?)";

            OleDbParameter[] paramTransLog = new OleDbParameter[8];
            paramTransLog[0] = new OleDbParameter("@CaseID", OleDbType.VarChar, 15);
            paramTransLog[0].Value = CaseId;
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

            //Update CPV_CC_Case_details with status 'Y' ---------------
            if (VerificationTypeId == "31" || VerificationTypeId == "25" || VerificationTypeId == "26" || VerificationTypeId == "27" || VerificationTypeId == "28")
            {
                if (IsQCVerificationComplete(oledbTrans, CaseId, ClientId, CentreId) == "true")
                {
                    QCVerificationComplete(oledbTrans, CaseId);
                    sRetVal += " Case verification data entry completed.";
                }
            }
            else
            {
                if (IsVerificationComplete(oledbTrans, CaseId, ClientId, CentreId) == "true")
                {
                    VerificationComplete(oledbTrans, CaseId);
                    sRetVal += " Case verification data entry completed.";

                }
            }
            /////////////////////////////////////////////////////////////////////////////////////////////
            //End  Insert into CASE_TRANSACTION_LOG --------------------
            oledbTrans.Commit();
            oledbConn.Close();

            return sRetVal;
        }
        catch (Exception ex)
        {
            oledbTrans.Rollback();
            oledbConn.Close();
            throw new Exception("Error while Inserting/updating Verification entry. " + ex.Message);
        }
    }

    #region InsertUpdateRLBusiVerificationEntry() Business verification(BV)
    //Function Name    :   InsertCCVerificationEntry
    //Create By		   :   Hemangi Kambli
    //Create Date	   :   02 July 2007.
    //Remarks 		   :   This method is used to insert new verification entry for RL.

    public string InsertUpdateRLBusiVerificationEntry()
    {
        OleDbConnection oledbConn = new OleDbConnection(objCmn.ConnectionString);
        oledbConn.Open();
        OleDbTransaction oledbTrans = oledbConn.BeginTransaction();
        string sRetVal = "";
        try
        {
            string sSql = "";
            string sSqlRead = "";
            OleDbDataReader oledbRead;

            sSqlRead = "SELECT Case_ID,VERIFICATION_TYPE_ID from CPV_RL_VERIFICATION_BVBT " +
                       " WHERE Case_ID='" + CaseId + "'" +
                       " AND VERIFICATION_TYPE_ID='" + VerificationTypeId + "'"; 
            oledbRead= OleDbHelper.ExecuteReader(oledbTrans, CommandType.Text, sSqlRead);

            OleDbParameter[] paramBV = new OleDbParameter[171];
            if (oledbRead.Read() == false)
            {
                sSql = "INSERT INTO CPV_RL_VERIFICATION_BVBT(CASE_ID, VERIFICATION_TYPE_ID, Person_Contacted,Designation_contacted_person,PERSON_CONFIRM_ADDRESS,  Name_business, " +
                      "No_year_service,Designation, No_of_emp_seen,Constitutency_business,Type_Office, Locating_Office, IS_res_com_office, Nam_Plate_sighted, " +
                      "Business_Activity_seen, Landmark, Equipment_Stock_sighted, Nature_Job, VisitingCard_obtained, Remarks, Rating,VERIFICATION_DATETIME, Verifier, Supervisor, " +
                      "Match_Negative_List, Name_bank_defaulted, Product_name, Default_which_bucket, AMT_DEFAULT_INR, Telephone_check, OFF_TELL_NO_NAME, " +
                      "Type_oF_Phone, TYPE_OF_MOBILE, Loan_Amount, USE_OF_LOAN, Product, Location_Product, DOB, Marital_Status, Education, Applicant_Income, " +
                      "No_yrs_previous_Employment, Loan_Cancellation, Any_credit_card, Any_other_Loan, Assets_Seen, Furniture_seen, Ownership, Location_OFFICE, " +
                      "Approach_office, Area_around_office, Office_Ambience, Office_OCL, Exterior_conditions, Interior_conditions, Company_Name_board_seen, " +
                      "Is_address_same, No_of_Members, No_of_current_office, Age_applicant, Name_add_third_party, TIME_APP_OFFICE, Third_party_Comment, " +
                      "Is_Negative_area, affilated_political_party, IS_black_area, Profile, Agency_Recommandation, Scoretool_Recommandation, Name_Neighbour1," +
                      "Address_Neighbour1, Confirmation_Neighbour1, Month_at_office1, Market_Reputaion_Neighbour1, Comments_Neighbour1, Name_Neighbour2, " +
                      "Address_Neighbour2, Confirmation_Neighbour2, Month_at_office2, Market_Reputaion_Neighbour2, Comments_Neighbour2, Locality, Accessibility, " +
                      "Business_board_sighted, entry_permited, Aprox_area, Brief_Job_Responsibilities, Behavour_person_contacted, Colour_Door, Type_Industry, " +
                      "Nature_Business, No_of_branches, customer_per_day, If_doctors, Patients_per_day, fees_per_Patient, clinic_visited, Name_Clinic, Architecture, " +
                      "How_long_praticing, Key_Client1, Key_Client2, key_Client3, Office_Address, Office_Name, Business_activity, Enterance_Motorable, " +
                      "Relationship_applicant, Identity_Proof_Seen, Type_Organization, Status_Office, WORK_SHIFT, Business_Proof_Seen, Residential_Address, " +
                      "Other_Investment, Verifier_Comment, Proof_Buss_Activity, Overall_Verification, Total_No_employee, Reason_not_collecting_VC, "+
                      "Office_Door_Locked, Where_Contacted, " +
                      "Sent_Date, Name_Bank, Previous_Employeement_Details, Previous_Emp_Designation, Construction_Office, Easy_Locating_Office, Neg_Match, " +
                      "Reason_Notrecommended, OCL_distance,Agency_name,IS_office_self_Neighbour1,IS_office_self_Neighbour2," +
                      "Level_Business_Activity,IS_res_cum_office_self_owned,Stock_Seen,Months_work_current_office,Purpose_loan,ADD_BY,ADD_DATE, " +
                      "NAME_COLLEGUE,DESGN_DEPT_COLLEGUE,MONTH_COMP_EXIST_ADDRESS,PROFILE_CO_NEIGHBOUR,APPLICANT_NAME_VERIFIED_FROM,ROOF_TYPE,SUPERVISOR_COMMENTS, " +
                      "City_Limit,MainlineBusiness,ValueofNostocksighted,CategoryofCompany,NormalOfficeJob,Customer_Seen,Type_Job,Appli_Work,Appli_JobTrans,Off_Exit, " +
                      "Vehi_Own,Buss_Prem,Ref_Name,Ref_Add,Month_Turn,Number_Bed,Neigh_Check,Clinic_Year,Separate_Resi,Separate_Factory,Separate_Entrance,Separate_Office,Office_Limit) " +
                      "VALUES(" +
                      "?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, " +
                      "?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, " +
                      "?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, " +
                      "?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, " +
                      "?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, " +
                      "?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?,?,?,?,?,?,?,?, " +
                      "?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)";

                paramBV[0] = new OleDbParameter("@CaseID", OleDbType.VarChar, 15);
                paramBV[0].Value = CaseId;
                paramBV[1] = new OleDbParameter("@VerificationTypeId", OleDbType.VarChar, 15);
                paramBV[1].Value = VerificationTypeId;
                paramBV[2] = new OleDbParameter("@NameOfPersonMet", OleDbType.VarChar, 50);
                paramBV[2].Value = NameOfPersonMet;
                paramBV[3] = new OleDbParameter("@NameOfPersonMetDesgn", OleDbType.VarChar, 100);
                paramBV[3].Value = NameOfPersonMetDesgn;
                paramBV[4] = new OleDbParameter("@ApplicantWorkedAgGivenAddress", OleDbType.VarChar, 50);
                paramBV[4].Value = ApplicantWorkedAgGivenAddress;
                paramBV[5] = new OleDbParameter("@NameOfBusiness", OleDbType.VarChar, 100);
                paramBV[5].Value = NameOfBusiness;
                paramBV[6] = new OleDbParameter("@NoOfYrsInservice", OleDbType.VarChar, 50);
                paramBV[6].Value = NoOfYrsInservice;
                paramBV[7] = new OleDbParameter("@AppDesignation", OleDbType.VarChar, 100);
                paramBV[7].Value = AppDesignation;
                paramBV[8] = new OleDbParameter("@NoOfEmployeeSeen", OleDbType.VarChar, 50);
                paramBV[8].Value = NoOfEmployeeSeen;
                paramBV[9] = new OleDbParameter("@ConstitutencyOfBusiness", OleDbType.VarChar, 100);
                paramBV[9].Value = ConstitutencyOfBusiness;
                paramBV[10] = new OleDbParameter("@TypeOfOffice", OleDbType.VarChar, 50);
                paramBV[10].Value = TypeOfOffice;
                paramBV[11] = new OleDbParameter("@LocatingOffice", OleDbType.VarChar, 100);
                paramBV[11].Value = LocatingOffice;
                paramBV[12] = new OleDbParameter("@IsResiCumOffice", OleDbType.VarChar, 10);
                paramBV[12].Value = IsResiCumOffice;
                paramBV[13] = new OleDbParameter("@NameplateOnDoor", OleDbType.VarChar, 10);
                paramBV[13].Value = NameplateOnDoor;
                paramBV[14] = new OleDbParameter("@IsBusinessActivityseen", OleDbType.VarChar, 50);
                paramBV[14].Value = IsBusinessActivityseen;
                paramBV[15] = new OleDbParameter("@Landmark", OleDbType.VarChar, 100);
                paramBV[15].Value = Landmark;
                paramBV[16] = new OleDbParameter("@IsEuipStockSighted", OleDbType.VarChar, 100);
                paramBV[16].Value = IsEuipStockSighted;
                paramBV[17] = new OleDbParameter("@NatureOfJob", OleDbType.VarChar, 100);
                paramBV[17].Value = NatureOfJob;
                paramBV[18] = new OleDbParameter("@VisitCardAsProofOfVisit", OleDbType.VarChar, 100);
                paramBV[18].Value = VisitCardAsProofOfVisit;
                paramBV[19] = new OleDbParameter("@Remarks", OleDbType.VarChar, 255);
                paramBV[19].Value = Remarks;
                paramBV[20] = new OleDbParameter("@Rating", OleDbType.VarChar, 50);
                paramBV[20].Value = Rating;
                paramBV[21] = new OleDbParameter("@DateTimeOfVerification", OleDbType.VarChar, 50);
                paramBV[21].Value = DateTimeOfVerification;               
                paramBV[22] = new OleDbParameter("@VerifierName", OleDbType.VarChar, 100);
                paramBV[22].Value = VerifierName;
                paramBV[23] = new OleDbParameter("@SupervisorName", OleDbType.VarChar, 100);
                paramBV[23].Value = SupervisorName;
                paramBV[24] = new OleDbParameter("@MatchInNegativeList", OleDbType.VarChar, 50);
                paramBV[24].Value = MatchInNegativeList;
                paramBV[25] = new OleDbParameter("@NameOfBankDefaultedWith", OleDbType.VarChar, 50);
                paramBV[25].Value = NameOfBankDefaultedWith;
                paramBV[26] = new OleDbParameter("@ProductName", OleDbType.VarChar, 100);
                paramBV[26].Value = ProductName;
                paramBV[27] = new OleDbParameter("@DefaultInWhichBucket", OleDbType.VarChar, 50);
                paramBV[27].Value = DefaultInWhichBucket;
                paramBV[28] = new OleDbParameter("@AmountOfDefaultINR", OleDbType.VarChar, 50);
                paramBV[28].Value = AmountOfDefaultINR;
                paramBV[29] = new OleDbParameter("@TeleCDRomCheck", OleDbType.VarChar, 50);
                paramBV[29].Value = TeleCDRomCheck;
                paramBV[30] = new OleDbParameter("@OffTelNoInNameOf", OleDbType.VarChar, 100);
                paramBV[30].Value = OffTelNoInNameOf;
                paramBV[31] = new OleDbParameter("@TeleNoType", OleDbType.VarChar, 100);
                paramBV[31].Value = TeleNoType;
                paramBV[32] = new OleDbParameter("@MobileNoType", OleDbType.VarChar, 100);
                paramBV[32].Value = MobileNoType;
                paramBV[33] = new OleDbParameter("@LoanAmount", OleDbType.VarChar, 50);
                paramBV[33].Value = LoanAmount;
                paramBV[34] = new OleDbParameter("@UseOfLoan", OleDbType.VarChar, 100);
                paramBV[34].Value = UseOfLoan;
                paramBV[35] = new OleDbParameter("@Product", OleDbType.VarChar, 100);
                paramBV[35].Value = Product;
                paramBV[36] = new OleDbParameter("@LocationOfProduct", OleDbType.VarChar, 100);
                paramBV[36].Value = LocationOfProduct;
                paramBV[37] = new OleDbParameter("@DateOfBirth", OleDbType.VarChar, 50);
                paramBV[37].Value = DateOfBirth;
                paramBV[38] = new OleDbParameter("@MaritalStatus", OleDbType.VarChar, 50);
                paramBV[38].Value = MaritalStatus;
                paramBV[39] = new OleDbParameter("@Education", OleDbType.VarChar, 100);
                paramBV[39].Value = Education;
                paramBV[40] = new OleDbParameter("@ApplicantIncome", OleDbType.VarChar, 50);
                paramBV[40].Value = ApplicantIncome;
                paramBV[41] = new OleDbParameter("@NoOfYrsAtPrevEmployment", OleDbType.VarChar, 50);
                paramBV[41].Value = NoOfYrsAtPrevEmployment;
                paramBV[42] = new OleDbParameter("@LoanCancellation", OleDbType.VarChar, 50);
                paramBV[42].Value = LoanCancellation;
                paramBV[43] = new OleDbParameter("@AnyCreditCard", OleDbType.VarChar, 100);
                paramBV[43].Value = AnyCreditCard;
                paramBV[44] = new OleDbParameter("@AnyOtherLoan", OleDbType.VarChar, 100);
                paramBV[44].Value = AnyOtherLoan;
                paramBV[45] = new OleDbParameter("@Assets", OleDbType.VarChar, 100);
                paramBV[45].Value = Assets;
                paramBV[46] = new OleDbParameter("@DetailsOfFurnitureSeen", OleDbType.VarChar, 100);
                paramBV[46].Value = DetailsOfFurnitureSeen;
                paramBV[47] = new OleDbParameter("@Ownership", OleDbType.VarChar, 100);
                paramBV[47].Value = Ownership;
                paramBV[48] = new OleDbParameter("@LocationOfOffice", OleDbType.VarChar, 100);
                paramBV[48].Value = LocationOfOffice;
                paramBV[49] = new OleDbParameter("@ApproachToOffice", OleDbType.VarChar, 50);
                paramBV[49].Value = ApproachToOffice;
                paramBV[50] = new OleDbParameter("@AreaAroundOffice", OleDbType.VarChar, 50);
                paramBV[50].Value = AreaAroundOffice;
                paramBV[51] = new OleDbParameter("@OfficeAmbience", OleDbType.VarChar, 100);
                paramBV[51].Value = OfficeAmbience;
                paramBV[52] = new OleDbParameter("@OfficeOCL", OleDbType.VarChar, 50);
                paramBV[52].Value = OfficeOCL;
                paramBV[53] = new OleDbParameter("@ExteriorConditions", OleDbType.VarChar, 50);
                paramBV[53].Value = ExteriorConditions;
                paramBV[54] = new OleDbParameter("@InteriorConditions", OleDbType.VarChar, 50);
                paramBV[54].Value = InteriorConditions;
                paramBV[55] = new OleDbParameter("@IsCompanyNameBoardSeen", OleDbType.VarChar, 50);
                paramBV[55].Value = IsCompanyNameBoardSeen;
                paramBV[56] = new OleDbParameter("@IsAddOfAppSame", OleDbType.VarChar, 50);
                paramBV[56].Value = IsAddOfAppSame;
                paramBV[57] = new OleDbParameter("@NoOfMembers", OleDbType.VarChar, 50);
                paramBV[57].Value = NoOfMembers;
                paramBV[58] = new OleDbParameter("@NoOfYrsAtCurrentOffice", OleDbType.VarChar, 50);
                paramBV[58].Value = NoOfYrsAtCurrentOffice;
                paramBV[59] = new OleDbParameter("@AgeOfApplicant", OleDbType.VarChar, 50);
                paramBV[59].Value = AgeOfApplicant;
                paramBV[60] = new OleDbParameter("@NameAddOfThirdParty", OleDbType.VarChar, 255);
                paramBV[60].Value = NameAddOfThirdParty;
                paramBV[61] = new OleDbParameter("@TimeWhenAppIsInOffice", OleDbType.VarChar, 50);
                paramBV[61].Value = TimeWhenAppIsInOffice;
                paramBV[62] = new OleDbParameter("@ThirdPartyComments", OleDbType.VarChar, 255);
                paramBV[62].Value = ThirdPartyComments;
                paramBV[63] = new OleDbParameter("@IsNegativeArea", OleDbType.VarChar, 20);
                paramBV[63].Value = IsNegativeArea;
                paramBV[64] = new OleDbParameter("@IsAffilatedToPoliticalParty", OleDbType.VarChar, 50);
                paramBV[64].Value = IsAffilatedToPoliticalParty;
                paramBV[65] = new OleDbParameter("@BlackArea", OleDbType.VarChar, 50);
                paramBV[65].Value = BlackArea;
                paramBV[66] = new OleDbParameter("@Profile", OleDbType.VarChar, 100);
                paramBV[66].Value = Profile;
                paramBV[67] = new OleDbParameter("@AgencyRecommandation", OleDbType.VarChar, 100);
                paramBV[67].Value = AgencyRecommandation;
                paramBV[68] = new OleDbParameter("@ScoretoolRecommandation", OleDbType.VarChar, 100);
                paramBV[68].Value = ScoretoolRecommandation;
                paramBV[69] = new OleDbParameter("@NameOfNeighbour1", OleDbType.VarChar, 100);
                paramBV[69].Value = NameOfNeighbour1;
                paramBV[70] = new OleDbParameter("@AddressOfNeighbour1", OleDbType.VarChar, 255);
                paramBV[70].Value = AddressOfNeighbour1;
                paramBV[71] = new OleDbParameter("@DoesAppWorkHere1", OleDbType.VarChar, 50);
                paramBV[71].Value = DoesAppWorkHere1;
                paramBV[72] = new OleDbParameter("@MthsOfWorkAtOffice1", OleDbType.VarChar, 10);
                paramBV[72].Value = MthsOfWorkAtOffice1;
                paramBV[73] = new OleDbParameter("@MarketReputation1", OleDbType.VarChar, 100);
                paramBV[73].Value = MarketReputation1;
                paramBV[74] = new OleDbParameter("@CommentsOfNeighbour1", OleDbType.VarChar, 255);
                paramBV[74].Value = CommentsOfNeighbour1;
                paramBV[75] = new OleDbParameter("@NameOfNeighbour2", OleDbType.VarChar, 100);
                paramBV[75].Value = NameOfNeighbour2;
                paramBV[76] = new OleDbParameter("@AddressOfNeighbour2", OleDbType.VarChar, 50);
                paramBV[76].Value = AddressOfNeighbour2;
                paramBV[77] = new OleDbParameter("@DoesAppWorkHere2", OleDbType.VarChar, 50);
                paramBV[77].Value = DoesAppWorkHere2;
                paramBV[78] = new OleDbParameter("@MthsOfWorkAtOffice2", OleDbType.VarChar, 10);
                paramBV[78].Value = MthsOfWorkAtOffice2;
                paramBV[79] = new OleDbParameter("@MarketReputation2", OleDbType.VarChar, 100);
                paramBV[79].Value = MarketReputation2;
                paramBV[80] = new OleDbParameter("@CommentsOfNeighbour2", OleDbType.VarChar, 255);
                paramBV[80].Value = CommentsOfNeighbour2;
                paramBV[81] = new OleDbParameter("@Locality", OleDbType.VarChar, 100);
                paramBV[81].Value = Locality;
                paramBV[82] = new OleDbParameter("@Accessibility", OleDbType.VarChar, 50);
                paramBV[82].Value = Accessibility;
                paramBV[83] = new OleDbParameter("@BusinessBoardSighted", OleDbType.VarChar, 50);
                paramBV[83].Value = BusinessBoardSighted;
                paramBV[84] = new OleDbParameter("@EntryPermitted", OleDbType.VarChar, 50);
                paramBV[84].Value = EntryPermitted;
                paramBV[85] = new OleDbParameter("@ApproximateArea", OleDbType.VarChar, 50);
                paramBV[85].Value = ApproximateArea;
                paramBV[86] = new OleDbParameter("@BriefJobResponsibilities", OleDbType.VarChar, 50);
                paramBV[86].Value = BriefJobResponsibilities;
                paramBV[87] = new OleDbParameter("@BehavourOfPersonContact", OleDbType.VarChar, 50);
                paramBV[87].Value = BehavourOfPersonContact;
                paramBV[88] = new OleDbParameter("@ClourOnDoor", OleDbType.VarChar, 50);
                paramBV[88].Value = ClourOnDoor;
                paramBV[89] = new OleDbParameter("@TypeOfIndustry", OleDbType.VarChar, 100);
                paramBV[89].Value = TypeOfIndustry;
                paramBV[90] = new OleDbParameter("@NatureOfBusiness", OleDbType.VarChar, 100);
                paramBV[90].Value = NatureOfBusiness;
                paramBV[91] = new OleDbParameter("@NoOfBranches", OleDbType.VarChar, 50);
                paramBV[91].Value = NoOfBranches;
                paramBV[92] = new OleDbParameter("@NoOfCustomerPerDay", OleDbType.VarChar, 50);
                paramBV[92].Value = NoOfCustomerPerDay;
                paramBV[93] = new OleDbParameter("@IfDoctors", OleDbType.VarChar, 10);
                paramBV[93].Value = IfDoctors;
                paramBV[94] = new OleDbParameter("@NoOfPatientsPerDay", OleDbType.VarChar, 10);
                paramBV[94].Value = NoOfPatientsPerDay;
                paramBV[95] = new OleDbParameter("@AvgFeePerPatient", OleDbType.VarChar, 10);
                paramBV[95].Value = AvgFeePerPatient;
                paramBV[96] = new OleDbParameter("@OtherClinicVisited", OleDbType.VarChar, 50);
                paramBV[96].Value = OtherClinicVisited;
                paramBV[97] = new OleDbParameter("@NameOfClinic", OleDbType.VarChar, 100);
                paramBV[97].Value = NameOfClinic;
                paramBV[98] = new OleDbParameter("@IfArchitectureCA", OleDbType.VarChar, 50);
                paramBV[98].Value = IfArchitectureCA;
                paramBV[99] = new OleDbParameter("@IndependentlyYrs", OleDbType.VarChar, 50);
                paramBV[99].Value = IndependentlyYrs;
                paramBV[100] = new OleDbParameter("@KeyClientName1", OleDbType.VarChar, 100);
                paramBV[100].Value = KeyClientName1;
                paramBV[101] = new OleDbParameter("@KeyClientName2", OleDbType.VarChar, 100);
                paramBV[101].Value = KeyClientName2;
                paramBV[102] = new OleDbParameter("@KeyClientName3", OleDbType.VarChar, 100);
                paramBV[102].Value = KeyClientName3;
                paramBV[103] = new OleDbParameter("@OfficeAddress", OleDbType.VarChar, 100);
                paramBV[103].Value = OfficeAddress;
                paramBV[104] = new OleDbParameter("@OfficeName", OleDbType.VarChar, 100);
                paramBV[104].Value = OfficeName;
                paramBV[105] = new OleDbParameter("@TypeOfBusinessActivity", OleDbType.VarChar, 100);
                paramBV[105].Value = TypeOfBusinessActivity;
                paramBV[106] = new OleDbParameter("@EntranceMotorable", OleDbType.VarChar, 100);
                paramBV[106].Value = EntranceMotorable;
                paramBV[107] = new OleDbParameter("@RelationWithApplicant", OleDbType.VarChar, 50);
                paramBV[107].Value = RelationWithApplicant;
                paramBV[108] = new OleDbParameter("@IsIdentityProofSeen", OleDbType.VarChar, 50);
                paramBV[108].Value = IsIdentityProofSeen;                
                paramBV[109] = new OleDbParameter("@TypeOfOrganization", OleDbType.VarChar, 100);
                paramBV[109].Value = TypeOfOrganization;
                paramBV[110] = new OleDbParameter("@StatusOfOffice", OleDbType.VarChar, 50);
                paramBV[110].Value = StatusOfOffice;
                paramBV[111] = new OleDbParameter("@ShifOfWork", OleDbType.VarChar, 50);
                paramBV[111].Value = ShifOfWork;
                paramBV[112] = new OleDbParameter("@IsBusinessProofSeen", OleDbType.VarChar, 50);
                paramBV[112].Value = IsBusinessProofSeen;
                paramBV[113] = new OleDbParameter("@ResidenceAddress", OleDbType.VarChar, 255);
                paramBV[113].Value = ResidenceAddress;
                paramBV[114] = new OleDbParameter("@OtherInvestment", OleDbType.VarChar, 100);
                paramBV[114].Value = OtherInvestment;
                paramBV[115] = new OleDbParameter("@VerifierComments", OleDbType.VarChar, 2000);
                paramBV[115].Value = VerifierComments;
                paramBV[116] = new OleDbParameter("@ProofOfBusinessActivity", OleDbType.VarChar, 100);
                paramBV[116].Value = ProofOfBusinessActivity;
                paramBV[117] = new OleDbParameter("@OverallVerification", OleDbType.VarChar, 255);
                paramBV[117].Value = OverallVerification;
                paramBV[118] = new OleDbParameter("@TotalNoOfEmployees", OleDbType.VarChar, 10);
                paramBV[118].Value = TotalNoOfEmployees;
                paramBV[119] = new OleDbParameter("@ReasonNotCollectingVistingCard", OleDbType.VarChar, 100);
                paramBV[119].Value = ReasonNotCollectingVistingCard;
                paramBV[120] = new OleDbParameter("@IsOfficeDoorLocked", OleDbType.VarChar, 100);
                paramBV[120].Value = IsOfficeDoorLocked;
                paramBV[121] = new OleDbParameter("@WhereContacted", OleDbType.VarChar, 100);
                paramBV[121].Value = WhereContacted;
                paramBV[122] = new OleDbParameter("@SendDate", OleDbType.VarChar, 50);
                paramBV[122].Value = SendDate;                
                paramBV[123] = new OleDbParameter("@NameOfBank", OleDbType.VarChar, 50);
                paramBV[123].Value = NameOfBank;
                paramBV[124] = new OleDbParameter("@DetailOfPreviousOccupation", OleDbType.VarChar, 255);
                paramBV[124].Value = DetailOfPreviousOccupation;
                paramBV[125] = new OleDbParameter("@PrevEmploymentDesgn", OleDbType.VarChar, 100);
                paramBV[125].Value = PrevEmploymentDesgn;
                paramBV[126] = new OleDbParameter("@ConstructionOfOffice", OleDbType.VarChar, 100);
                paramBV[126].Value = ConstructionOfOffice;
                paramBV[127] = new OleDbParameter("@EasyOfLocatingOffice", OleDbType.VarChar, 100);
                paramBV[127].Value = EasyOfLocatingOffice;
                paramBV[128] = new OleDbParameter("@Negmatch", OleDbType.VarChar, 50);
                paramBV[128].Value = Negmatch;
                paramBV[129] = new OleDbParameter("@ReasonForNotRecomdNReferred", OleDbType.VarChar, 255);
                paramBV[129].Value = ReasonForNotRecomdNReferred;
                paramBV[130] = new OleDbParameter("@IfOCLDistance", OleDbType.VarChar, 50);
                paramBV[130].Value = IfOCLDistance;
                paramBV[131] = new OleDbParameter("@AgencyCode", OleDbType.VarChar, 100);
                paramBV[131].Value = AgencyCode;
                paramBV[132] = new OleDbParameter("@IsOfficeSelfOwnedNeigh1", OleDbType.VarChar, 50);
                paramBV[132].Value = IsOfficeSelfOwnedNeigh1;
                paramBV[133] = new OleDbParameter("@IsOfficeSelfOwnedNeigh2", OleDbType.VarChar, 50);
                paramBV[133].Value = IsOfficeSelfOwnedNeigh2;
                paramBV[134] = new OleDbParameter("@LevelOfBusActivity", OleDbType.VarChar, 100);
                paramBV[134].Value = LevelOfBusActivity;
                paramBV[135] = new OleDbParameter("@IsResiCumOfficeSelfOwned", OleDbType.VarChar, 10);
                paramBV[135].Value = IsResiCumOfficeSelfOwned;
                paramBV[136] = new OleDbParameter("@StockSeen", OleDbType.VarChar, 200);
                paramBV[136].Value = StockSeen;
                paramBV[137] = new OleDbParameter("@MthOfWorkCurrentOffice", OleDbType.VarChar, 50);
                paramBV[137].Value = MthOfWorkCurrentOffice;
                paramBV[138] = new OleDbParameter("@PurposeOfLoanTaken", OleDbType.VarChar, 255);
                paramBV[138].Value = PurposeOfLoanTaken;
                paramBV[139] = new OleDbParameter("@AddedBy", OleDbType.VarChar, 15);
                paramBV[139].Value = AddedBy;
                paramBV[140] = new OleDbParameter("@AddedOn", OleDbType.DBTimeStamp);
                paramBV[140].Value = AddedOn;
                paramBV[141] = new OleDbParameter("@NameOfCollegue", OleDbType.VarChar, 50);
                paramBV[141].Value = NameOfCollegue;
                paramBV[142] = new OleDbParameter("@DesgnDeptCollegue", OleDbType.VarChar, 50);
                paramBV[142].Value = DesgnDeptCollegue;
                paramBV[143] = new OleDbParameter("@MthOfCompExistAtAddress", OleDbType.VarChar, 15);
                paramBV[143].Value = MthOfCompExistAtAddress;
                paramBV[144] = new OleDbParameter("@ProfileCoNeighbour", OleDbType.VarChar, 100);
                paramBV[144].Value = ProfileCoNeighbour;
                paramBV[145] = new OleDbParameter("@AppNameVerifiedFrom", OleDbType.VarChar, 50);
                paramBV[145].Value = AppNameVerifiedFrom;
                paramBV[146] = new OleDbParameter("@RoofType", OleDbType.VarChar, 50);
                paramBV[146].Value = RoofType;
                paramBV[147] = new OleDbParameter("@SupervisorComment", OleDbType.VarChar, 250);
                paramBV[147].Value = SupervisorComment;
                paramBV[148] = new OleDbParameter("@CityLimit", OleDbType.VarChar, 250);
                paramBV[148].Value = CityLimit;
                //added by kamal matekar fro frederal finance
                paramBV[149] = new OleDbParameter("@MainlineBusiness", OleDbType.VarChar, 250);
                paramBV[149].Value = MainlineBusiness;
                paramBV[150] = new OleDbParameter("@ValueofNostocksighted", OleDbType.VarChar, 250);
                paramBV[150].Value = ValueofNostocksighted;
                paramBV[151] = new OleDbParameter("@CategoryofCompany", OleDbType.VarChar, 250);
                paramBV[151].Value = CategoryofCompany;
                paramBV[152] = new OleDbParameter("@NormalOfficeJob", OleDbType.VarChar, 250);
                paramBV[152].Value = NormalOfficeJob;
                paramBV[153] = new OleDbParameter("@CustomerSeen", OleDbType.VarChar, 500);
                paramBV[153].Value = CustomerSeen;
                paramBV[154] = new OleDbParameter("@TypeJob", OleDbType.VarChar, 500);
                paramBV[154].Value = TypeJob;
                paramBV[155] = new OleDbParameter("@Appli_Work", OleDbType.VarChar, 500);
                paramBV[155].Value = AppliWork;
                paramBV[156] = new OleDbParameter("@Appli_JobTrans", OleDbType.VarChar, 500);
                paramBV[156].Value = AppliJobTrans;
                paramBV[157] = new OleDbParameter("@Off_Exit", OleDbType.VarChar, 500);
                paramBV[157].Value = OffExit;
                paramBV[158] = new OleDbParameter("@VehiOwn", OleDbType.VarChar, 500);
                paramBV[158].Value = VehiOwn;
                paramBV[159] = new OleDbParameter("@BussPrem", OleDbType.VarChar, 500);
                paramBV[159].Value = BussPrem;
                paramBV[160] = new OleDbParameter("@RefName", OleDbType.VarChar, 500);
                paramBV[160].Value = RefName;
                paramBV[161] = new OleDbParameter("@RefAdd", OleDbType.VarChar, 500);
                paramBV[161].Value = RefAdd;
                paramBV[162] = new OleDbParameter("@MonthTurn", OleDbType.VarChar, 500);
                paramBV[162].Value = MonthTurn;
                paramBV[163] = new OleDbParameter("@NumberBed", OleDbType.VarChar, 500);
                paramBV[163].Value = NumberBed;
                paramBV[164] = new OleDbParameter("@NeighCheck", OleDbType.VarChar, 500);
                paramBV[164].Value = NeighCheck;
                paramBV[165] = new OleDbParameter("@ClinicYear", OleDbType.VarChar, 500);
                paramBV[165].Value = ClinicYear;
                paramBV[166] = new OleDbParameter("@SeparateResi", OleDbType.VarChar, 500);
                paramBV[166].Value = SeparateResi;
                paramBV[167] = new OleDbParameter("@SeparateFactory", OleDbType.VarChar, 500);
                paramBV[167].Value = SeparateFactory;
                paramBV[168] = new OleDbParameter("@SeparateEntrance", OleDbType.VarChar, 500);
                paramBV[168].Value = SeparateEntrance;
                paramBV[169] = new OleDbParameter("@SeparateOffice", OleDbType.VarChar, 500);
                paramBV[169].Value = SeparateOffice;
                paramBV[170] = new OleDbParameter("@OfficeLimit", OleDbType.VarChar, 500);
                paramBV[170].Value = OfficeLimit;


                ////ended


                sRetVal = "Record added successfully.";
            }
            else
            {
                //update query
                sSql = "UPDATE CPV_RL_VERIFICATION_BVBT SET Person_Contacted=?,Designation_contacted_person=?,PERSON_CONFIRM_ADDRESS=?,  Name_business=?, " +
                      "No_year_service=?,Designation=?, No_of_emp_seen=?,Constitutency_business=?,Type_Office=?, Locating_Office=?, IS_res_com_office=?, Nam_Plate_sighted=?, " +
                      "Business_Activity_seen=?, Landmark=?, Equipment_Stock_sighted=?, Nature_Job=?, VisitingCard_obtained=?, Remarks=?, Rating=?, VERIFICATION_DATETIME=?,Verifier=?, Supervisor=?, " +
                      "Match_Negative_List=?, Name_bank_defaulted=?, Product_name=?, Default_which_bucket=?, AMT_DEFAULT_INR=?, Telephone_check=?, OFF_TELL_NO_NAME=?, " +
                      "Type_oF_Phone=?, TYPE_OF_MOBILE=?, Loan_Amount=?, USE_OF_LOAN=?, Product=?, Location_Product=?, DOB=?, Marital_Status=?, Education=?, Applicant_Income=?, " +
                      "No_yrs_previous_Employment=?, Loan_Cancellation=?, Any_credit_card=?, Any_other_Loan=?, Assets_Seen=?, Furniture_seen=?, Ownership=?, Location_OFFICE=?, " +
                      "Approach_office=?, Area_around_office=?, Office_Ambience=?, Office_OCL=?, Exterior_conditions=?, Interior_conditions=?, Company_Name_board_seen=?, " +
                      "Is_address_same=?, No_of_Members=?, No_of_current_office=?, Age_applicant=?, Name_add_third_party=?, TIME_APP_OFFICE=?, Third_party_Comment=?, " +
                      "Is_Negative_area=?, affilated_political_party=?, IS_black_area=?, Profile=?, Agency_Recommandation=?, Scoretool_Recommandation=?, Name_Neighbour1=?," +
                      "Address_Neighbour1=?, Confirmation_Neighbour1=?, Month_at_office1=?, Market_Reputaion_Neighbour1=?, Comments_Neighbour1=?, Name_Neighbour2=?, " +
                      "Address_Neighbour2=?, Confirmation_Neighbour2=?, Month_at_office2=?, Market_Reputaion_Neighbour2=?, Comments_Neighbour2=?, Locality=?, Accessibility=?, " +
                      "Business_board_sighted=?, entry_permited=?, Aprox_area=?, Brief_Job_Responsibilities=?, Behavour_person_contacted=?, Colour_Door=?, Type_Industry=?, " +
                      "Nature_Business=?, No_of_branches=?, customer_per_day=?, If_doctors=?, Patients_per_day=?, fees_per_Patient=?, clinic_visited=?, Name_Clinic=?, Architecture=?, " +
                      "How_long_praticing=?, Key_Client1=?, Key_Client2=?, key_Client3=?, Office_Address=?, Office_Name=?, Business_activity=?, Enterance_Motorable=?, " +
                      "Relationship_applicant=?, Identity_Proof_Seen=?, Type_Organization=?, Status_Office=?, WORK_SHIFT=?, Business_Proof_Seen=?, Residential_Address=?, " +
                      "Other_Investment=?, Verifier_Comment=?, Proof_Buss_Activity=?, Overall_Verification=?, Total_No_employee=?, Reason_not_collecting_VC=?, " +
                      "Office_Door_Locked=?, Where_Contacted=?, " +
                      "Sent_Date=?, Name_Bank=?, Previous_Employeement_Details=?, Previous_Emp_Designation=?, Construction_Office=?, Easy_Locating_Office=?, Neg_Match=?, " +
                      "Reason_Notrecommended=?, OCL_distance=?,Agency_name=?,IS_office_self_Neighbour1=?,IS_office_self_Neighbour2=?, " +
                      "Level_Business_Activity=?,IS_res_cum_office_self_owned=?,Stock_Seen=?,Months_work_current_office=?,Purpose_loan=?,MODIFY_BY=?,MODIFY_DATE=?, " +
                      "NAME_COLLEGUE=?,DESGN_DEPT_COLLEGUE=?,MONTH_COMP_EXIST_ADDRESS=?,PROFILE_CO_NEIGHBOUR=?,APPLICANT_NAME_VERIFIED_FROM=?,ROOF_TYPE=?,SUPERVISOR_COMMENTS=?, " +
                      "City_Limit=?,MainlineBusiness=?,ValueofNostocksighted=?,CategoryofCompany=?,NormalOfficeJob=?,Customer_Seen=?,Type_Job=?,Appli_Work=?,Appli_JobTrans=?, " +
                      "Off_Exit=?,Vehi_Own=?,Buss_Prem=?,Ref_Name=?,Ref_Add=?,Month_Turn=?,Number_Bed=?,Neigh_Check=?,Clinic_Year=?,Separate_Resi=?,Separate_Factory=?, " +
                      "Separate_Entrance=?,Separate_Office=?,Office_Limit=? " +
                      " WHERE CASE_ID=? AND VERIFICATION_TYPE_ID=?";

                paramBV[0] = new OleDbParameter("@NameOfPersonMet", OleDbType.VarChar, 50);
                paramBV[0].Value = NameOfPersonMet;
                paramBV[1] = new OleDbParameter("@NameOfPersonMetDesgn", OleDbType.VarChar, 100);
                paramBV[1].Value = NameOfPersonMetDesgn;
                paramBV[2] = new OleDbParameter("@ApplicantWorkedAgGivenAddress", OleDbType.VarChar, 50);
                paramBV[2].Value = ApplicantWorkedAgGivenAddress;
                paramBV[3] = new OleDbParameter("@NameOfBusiness", OleDbType.VarChar, 100);
                paramBV[3].Value = NameOfBusiness;
                paramBV[4] = new OleDbParameter("@NoOfYrsInservice", OleDbType.VarChar, 50);
                paramBV[4].Value = NoOfYrsInservice;
                paramBV[5] = new OleDbParameter("@AppDesignation", OleDbType.VarChar, 100);
                paramBV[5].Value = AppDesignation;
                paramBV[6] = new OleDbParameter("@NoOfEmployeeSeen", OleDbType.VarChar, 50);
                paramBV[6].Value = NoOfEmployeeSeen;
                paramBV[7] = new OleDbParameter("@ConstitutencyOfBusiness", OleDbType.VarChar, 100);
                paramBV[7].Value = ConstitutencyOfBusiness;
                paramBV[8] = new OleDbParameter("@TypeOfOffice", OleDbType.VarChar, 50);
                paramBV[8].Value = TypeOfOffice;
                paramBV[9] = new OleDbParameter("@LocatingOffice", OleDbType.VarChar, 100);
                paramBV[9].Value = LocatingOffice;
                paramBV[10] = new OleDbParameter("@IsResiCumOffice", OleDbType.VarChar, 10);
                paramBV[10].Value = IsResiCumOffice;
                paramBV[11] = new OleDbParameter("@NameplateOnDoor", OleDbType.VarChar, 10);
                paramBV[11].Value = NameplateOnDoor;
                paramBV[12] = new OleDbParameter("@IsBusinessActivityseen", OleDbType.VarChar, 50);
                paramBV[12].Value = IsBusinessActivityseen;
                paramBV[13] = new OleDbParameter("@Landmark", OleDbType.VarChar, 100);
                paramBV[13].Value = Landmark;
                paramBV[14] = new OleDbParameter("@IsEuipStockSighted", OleDbType.VarChar, 100);
                paramBV[14].Value = IsEuipStockSighted;
                paramBV[15] = new OleDbParameter("@NatureOfJob", OleDbType.VarChar, 100);
                paramBV[15].Value = NatureOfJob;
                paramBV[16] = new OleDbParameter("@VisitCardAsProofOfVisit", OleDbType.VarChar, 100);
                paramBV[16].Value = VisitCardAsProofOfVisit;
                paramBV[17] = new OleDbParameter("@Remarks", OleDbType.VarChar, 255);
                paramBV[17].Value = Remarks;
                paramBV[18] = new OleDbParameter("@Rating", OleDbType.VarChar, 50);
                paramBV[18].Value = Rating;
                paramBV[19] = new OleDbParameter("@DateTimeOfVerification", OleDbType.VarChar, 50);
                paramBV[19].Value = DateTimeOfVerification;               
                paramBV[20] = new OleDbParameter("@VerifierName", OleDbType.VarChar, 100);
                paramBV[20].Value = VerifierName;
                paramBV[21] = new OleDbParameter("@SupervisorName", OleDbType.VarChar, 100);
                paramBV[21].Value = SupervisorName;
                paramBV[22] = new OleDbParameter("@MatchInNegativeList", OleDbType.VarChar, 50);
                paramBV[22].Value = MatchInNegativeList;
                paramBV[23] = new OleDbParameter("@NameOfBankDefaultedWith", OleDbType.VarChar, 50);
                paramBV[23].Value = NameOfBankDefaultedWith;
                paramBV[24] = new OleDbParameter("@ProductName", OleDbType.VarChar, 100);
                paramBV[24].Value = ProductName;
                paramBV[25] = new OleDbParameter("@DefaultInWhichBucket", OleDbType.VarChar, 50);
                paramBV[25].Value = DefaultInWhichBucket;
                paramBV[26] = new OleDbParameter("@AmountOfDefaultINR", OleDbType.VarChar, 50);
                paramBV[26].Value = AmountOfDefaultINR;
                paramBV[27] = new OleDbParameter("@TeleCDRomCheck", OleDbType.VarChar, 50);
                paramBV[27].Value = TeleCDRomCheck;
                paramBV[28] = new OleDbParameter("@OffTelNoInNameOf", OleDbType.VarChar, 100);
                paramBV[28].Value = OffTelNoInNameOf;
                paramBV[29] = new OleDbParameter("@TeleNoType", OleDbType.VarChar, 100);
                paramBV[29].Value = TeleNoType;
                paramBV[30] = new OleDbParameter("@MobileNoType", OleDbType.VarChar, 100);
                paramBV[30].Value = MobileNoType;
                paramBV[31] = new OleDbParameter("@LoanAmount", OleDbType.VarChar, 50);
                paramBV[31].Value = LoanAmount;
                paramBV[32] = new OleDbParameter("@UseOfLoan", OleDbType.VarChar, 100);
                paramBV[32].Value = UseOfLoan;
                paramBV[33] = new OleDbParameter("@Product", OleDbType.VarChar, 100);
                paramBV[33].Value = Product;
                paramBV[34] = new OleDbParameter("@LocationOfProduct", OleDbType.VarChar, 100);
                paramBV[34].Value = LocationOfProduct;
                paramBV[35] = new OleDbParameter("@DateOfBirth", OleDbType.VarChar, 50);
                paramBV[35].Value = DateOfBirth;
                paramBV[36] = new OleDbParameter("@MaritalStatus", OleDbType.VarChar, 50);
                paramBV[36].Value = MaritalStatus;
                paramBV[37] = new OleDbParameter("@Education", OleDbType.VarChar, 100);
                paramBV[37].Value = Education;
                paramBV[38] = new OleDbParameter("@ApplicantIncome", OleDbType.VarChar, 50);
                paramBV[38].Value = ApplicantIncome;
                paramBV[39] = new OleDbParameter("@NoOfYrsAtPrevEmployment", OleDbType.VarChar, 50);
                paramBV[39].Value = NoOfYrsAtPrevEmployment;
                paramBV[40] = new OleDbParameter("@LoanCancellation", OleDbType.VarChar, 50);
                paramBV[40].Value = LoanCancellation;
                paramBV[41] = new OleDbParameter("@AnyCreditCard", OleDbType.VarChar, 100);
                paramBV[41].Value = AnyCreditCard;
                paramBV[42] = new OleDbParameter("@AnyOtherLoan", OleDbType.VarChar, 100);
                paramBV[42].Value = AnyOtherLoan;
                paramBV[43] = new OleDbParameter("@Assets", OleDbType.VarChar, 100);
                paramBV[43].Value = Assets;
                paramBV[44] = new OleDbParameter("@DetailsOfFurnitureSeen", OleDbType.VarChar, 100);
                paramBV[44].Value = DetailsOfFurnitureSeen;
                paramBV[45] = new OleDbParameter("@Ownership", OleDbType.VarChar, 100);
                paramBV[45].Value = Ownership;
                paramBV[46] = new OleDbParameter("@LocationOfOffice", OleDbType.VarChar, 100);
                paramBV[46].Value = LocationOfOffice;
                paramBV[47] = new OleDbParameter("@ApproachToOffice", OleDbType.VarChar, 50);
                paramBV[47].Value = ApproachToOffice;
                paramBV[48] = new OleDbParameter("@AreaAroundOffice", OleDbType.VarChar, 50);
                paramBV[48].Value = AreaAroundOffice;
                paramBV[49] = new OleDbParameter("@OfficeAmbience", OleDbType.VarChar, 100);
                paramBV[49].Value = OfficeAmbience;
                paramBV[50] = new OleDbParameter("@OfficeOCL", OleDbType.VarChar, 50);
                paramBV[50].Value = OfficeOCL;
                paramBV[51] = new OleDbParameter("@ExteriorConditions", OleDbType.VarChar, 50);
                paramBV[51].Value = ExteriorConditions;
                paramBV[52] = new OleDbParameter("@InteriorConditions", OleDbType.VarChar, 50);
                paramBV[52].Value = InteriorConditions;
                paramBV[53] = new OleDbParameter("@IsCompanyNameBoardSeen", OleDbType.VarChar, 50);
                paramBV[53].Value = IsCompanyNameBoardSeen;
                paramBV[54] = new OleDbParameter("@IsAddOfAppSame", OleDbType.VarChar, 50);
                paramBV[54].Value = IsAddOfAppSame;
                paramBV[55] = new OleDbParameter("@NoOfMembers", OleDbType.VarChar, 50);
                paramBV[55].Value = NoOfMembers;
                paramBV[56] = new OleDbParameter("@NoOfYrsAtCurrentOffice", OleDbType.VarChar, 50);
                paramBV[56].Value = NoOfYrsAtCurrentOffice;
                paramBV[57] = new OleDbParameter("@AgeOfApplicant", OleDbType.VarChar, 50);
                paramBV[57].Value = AgeOfApplicant;
                paramBV[58] = new OleDbParameter("@NameAddOfThirdParty", OleDbType.VarChar, 255);
                paramBV[58].Value = NameAddOfThirdParty;
                paramBV[59] = new OleDbParameter("@TimeWhenAppIsInOffice", OleDbType.VarChar, 50);
                paramBV[59].Value = TimeWhenAppIsInOffice;
                paramBV[60] = new OleDbParameter("@ThirdPartyComments", OleDbType.VarChar, 255);
                paramBV[60].Value = ThirdPartyComments;
                paramBV[61] = new OleDbParameter("@IsNegativeArea", OleDbType.VarChar, 20);
                paramBV[61].Value = IsNegativeArea;
                paramBV[62] = new OleDbParameter("@IsAffilatedToPoliticalParty", OleDbType.VarChar, 50);
                paramBV[62].Value = IsAffilatedToPoliticalParty;
                paramBV[63] = new OleDbParameter("@BlackArea", OleDbType.VarChar, 50);
                paramBV[63].Value = BlackArea;
                paramBV[64] = new OleDbParameter("@Profile", OleDbType.VarChar, 100);
                paramBV[64].Value = Profile;
                paramBV[65] = new OleDbParameter("@AgencyRecommandation", OleDbType.VarChar, 100);
                paramBV[65].Value = AgencyRecommandation;
                paramBV[66] = new OleDbParameter("@ScoretoolRecommandation", OleDbType.VarChar, 100);
                paramBV[66].Value = ScoretoolRecommandation;
                paramBV[67] = new OleDbParameter("@NameOfNeighbour1", OleDbType.VarChar, 100);
                paramBV[67].Value = NameOfNeighbour1;
                paramBV[68] = new OleDbParameter("@AddressOfNeighbour1", OleDbType.VarChar, 255);
                paramBV[68].Value = AddressOfNeighbour1;
                paramBV[69] = new OleDbParameter("@DoesAppWorkHere1", OleDbType.VarChar, 50);
                paramBV[69].Value = DoesAppWorkHere1;
                paramBV[70] = new OleDbParameter("@MthsOfWorkAtOffice1", OleDbType.VarChar, 10);
                paramBV[70].Value = MthsOfWorkAtOffice1;
                paramBV[71] = new OleDbParameter("@MarketReputation1", OleDbType.VarChar, 100);
                paramBV[71].Value = MarketReputation1;
                paramBV[72] = new OleDbParameter("@CommentsOfNeighbour1", OleDbType.VarChar, 255);
                paramBV[72].Value = CommentsOfNeighbour1;
                paramBV[73] = new OleDbParameter("@NameOfNeighbour2", OleDbType.VarChar, 100);
                paramBV[73].Value = NameOfNeighbour2;
                paramBV[74] = new OleDbParameter("@AddressOfNeighbour2", OleDbType.VarChar, 50);
                paramBV[74].Value = AddressOfNeighbour2;
                paramBV[75] = new OleDbParameter("@DoesAppWorkHere2", OleDbType.VarChar, 50);
                paramBV[75].Value = DoesAppWorkHere2;
                paramBV[76] = new OleDbParameter("@MthsOfWorkAtOffice2", OleDbType.VarChar, 10);
                paramBV[76].Value = MthsOfWorkAtOffice2;
                paramBV[77] = new OleDbParameter("@MarketReputation2", OleDbType.VarChar, 100);
                paramBV[77].Value = MarketReputation2;
                paramBV[78] = new OleDbParameter("@CommentsOfNeighbour2", OleDbType.VarChar, 255);
                paramBV[78].Value = CommentsOfNeighbour2;
                paramBV[79] = new OleDbParameter("@Locality", OleDbType.VarChar, 100);
                paramBV[79].Value = Locality;
                paramBV[80] = new OleDbParameter("@Accessibility", OleDbType.VarChar, 50);
                paramBV[80].Value = Accessibility;
                paramBV[81] = new OleDbParameter("@BusinessBoardSighted", OleDbType.VarChar, 50);
                paramBV[81].Value = BusinessBoardSighted;
                paramBV[82] = new OleDbParameter("@EntryPermitted", OleDbType.VarChar, 50);
                paramBV[82].Value = EntryPermitted;
                paramBV[83] = new OleDbParameter("@ApproximateArea", OleDbType.VarChar, 50);
                paramBV[83].Value = ApproximateArea;
                paramBV[84] = new OleDbParameter("@BriefJobResponsibilities", OleDbType.VarChar, 50);
                paramBV[84].Value = BriefJobResponsibilities;
                paramBV[85] = new OleDbParameter("@BehavourOfPersonContact", OleDbType.VarChar, 50);
                paramBV[85].Value = BehavourOfPersonContact;
                paramBV[86] = new OleDbParameter("@ClourOnDoor", OleDbType.VarChar, 50);
                paramBV[86].Value = ClourOnDoor;
                paramBV[87] = new OleDbParameter("@TypeOfIndustry", OleDbType.VarChar, 100);
                paramBV[87].Value = TypeOfIndustry;
                paramBV[88] = new OleDbParameter("@NatureOfBusiness", OleDbType.VarChar, 100);
                paramBV[88].Value = NatureOfBusiness;
                paramBV[89] = new OleDbParameter("@NoOfBranches", OleDbType.VarChar, 50);
                paramBV[89].Value = NoOfBranches;
                paramBV[90] = new OleDbParameter("@NoOfCustomerPerDay", OleDbType.VarChar, 50);
                paramBV[90].Value = NoOfCustomerPerDay;
                paramBV[91] = new OleDbParameter("@IfDoctors", OleDbType.VarChar, 10);
                paramBV[91].Value = IfDoctors;
                paramBV[92] = new OleDbParameter("@NoOfPatientsPerDay", OleDbType.VarChar, 10);
                paramBV[92].Value = NoOfPatientsPerDay;
                paramBV[93] = new OleDbParameter("@AvgFeePerPatient", OleDbType.VarChar, 10);
                paramBV[93].Value = AvgFeePerPatient;
                paramBV[94] = new OleDbParameter("@OtherClinicVisited", OleDbType.VarChar, 50);
                paramBV[94].Value = OtherClinicVisited;
                paramBV[95] = new OleDbParameter("@NameOfClinic", OleDbType.VarChar, 100);
                paramBV[95].Value = NameOfClinic;
                paramBV[96] = new OleDbParameter("@IfArchitectureCA", OleDbType.VarChar, 50);
                paramBV[96].Value = IfArchitectureCA;
                paramBV[97] = new OleDbParameter("@IndependentlyYrs", OleDbType.VarChar, 50);
                paramBV[97].Value = IndependentlyYrs;
                paramBV[98] = new OleDbParameter("@KeyClientName1", OleDbType.VarChar, 100);
                paramBV[98].Value = KeyClientName1;
                paramBV[99] = new OleDbParameter("@KeyClientName2", OleDbType.VarChar, 100);
                paramBV[99].Value = KeyClientName2;
                paramBV[100] = new OleDbParameter("@KeyClientName3", OleDbType.VarChar, 100);
                paramBV[100].Value = KeyClientName3;
                paramBV[101] = new OleDbParameter("@OfficeAddress", OleDbType.VarChar, 100);
                paramBV[101].Value = OfficeAddress;
                paramBV[102] = new OleDbParameter("@OfficeName", OleDbType.VarChar, 100);
                paramBV[102].Value = OfficeName;
                paramBV[103] = new OleDbParameter("@TypeOfBusinessActivity", OleDbType.VarChar, 100);
                paramBV[103].Value = TypeOfBusinessActivity;
                paramBV[104] = new OleDbParameter("@EntranceMotorable", OleDbType.VarChar, 100);
                paramBV[104].Value = EntranceMotorable;
                paramBV[105] = new OleDbParameter("@RelationWithApplicant", OleDbType.VarChar, 50);
                paramBV[105].Value = RelationWithApplicant;
                paramBV[106] = new OleDbParameter("@IsIdentityProofSeen", OleDbType.VarChar, 50);
                paramBV[106].Value = IsIdentityProofSeen;
                paramBV[107] = new OleDbParameter("@TypeOfOrganization", OleDbType.VarChar, 100);
                paramBV[107].Value = TypeOfOrganization;
                paramBV[108] = new OleDbParameter("@StatusOfOffice", OleDbType.VarChar, 50);
                paramBV[108].Value = StatusOfOffice;
                paramBV[109] = new OleDbParameter("@ShifOfWork", OleDbType.VarChar, 50);
                paramBV[109].Value = ShifOfWork;
                paramBV[110] = new OleDbParameter("@IsBusinessProofSeen", OleDbType.VarChar, 50);
                paramBV[110].Value = IsBusinessProofSeen;
                paramBV[111] = new OleDbParameter("@ResidenceAddress", OleDbType.VarChar, 255);
                paramBV[111].Value = ResidenceAddress;
                paramBV[112] = new OleDbParameter("@OtherInvestment", OleDbType.VarChar, 100);
                paramBV[112].Value = OtherInvestment;
                paramBV[113] = new OleDbParameter("@VerifierComments", OleDbType.VarChar, 2000);
                paramBV[113].Value = VerifierComments;
                paramBV[114] = new OleDbParameter("@ProofOfBusinessActivity", OleDbType.VarChar, 100);
                paramBV[114].Value = ProofOfBusinessActivity;
                paramBV[115] = new OleDbParameter("@OverallVerification", OleDbType.VarChar, 255);
                paramBV[115].Value = OverallVerification;
                paramBV[116] = new OleDbParameter("@TotalNoOfEmployees", OleDbType.VarChar, 10);
                paramBV[116].Value = TotalNoOfEmployees;
                paramBV[117] = new OleDbParameter("@ReasonNotCollectingVistingCard", OleDbType.VarChar, 100);
                paramBV[117].Value = ReasonNotCollectingVistingCard;
                paramBV[118] = new OleDbParameter("@IsOfficeDoorLocked", OleDbType.VarChar, 100);
                paramBV[118].Value = IsOfficeDoorLocked;
                paramBV[119] = new OleDbParameter("@WhereContacted", OleDbType.VarChar, 100);
                paramBV[119].Value = WhereContacted;
                paramBV[120] = new OleDbParameter("@SendDate", OleDbType.VarChar, 50);
                paramBV[120].Value = SendDate;
                paramBV[121] = new OleDbParameter("@NameOfBank", OleDbType.VarChar, 50);
                paramBV[121].Value = NameOfBank;
                paramBV[122] = new OleDbParameter("@DetailOfPreviousOccupation", OleDbType.VarChar, 255);
                paramBV[122].Value = DetailOfPreviousOccupation;
                paramBV[123] = new OleDbParameter("@PrevEmploymentDesgn", OleDbType.VarChar, 100);
                paramBV[123].Value = PrevEmploymentDesgn;
                paramBV[124] = new OleDbParameter("@ConstructionOfOffice", OleDbType.VarChar, 100);
                paramBV[124].Value = ConstructionOfOffice;
                paramBV[125] = new OleDbParameter("@EasyOfLocatingOffice", OleDbType.VarChar, 100);
                paramBV[125].Value = EasyOfLocatingOffice;
                paramBV[126] = new OleDbParameter("@Negmatch", OleDbType.VarChar, 50);
                paramBV[126].Value = Negmatch;
                paramBV[127] = new OleDbParameter("@ReasonForNotRecomdNReferred", OleDbType.VarChar, 255);
                paramBV[127].Value = ReasonForNotRecomdNReferred;
                paramBV[128] = new OleDbParameter("@IfOCLDistance", OleDbType.VarChar, 50);
                paramBV[128].Value = IfOCLDistance;
                paramBV[129] = new OleDbParameter("@AgencyCode", OleDbType.VarChar, 100);
                paramBV[129].Value = AgencyCode;
                paramBV[130] = new OleDbParameter("@IsOfficeSelfOwnedNeigh1", OleDbType.VarChar, 50);
                paramBV[130].Value = IsOfficeSelfOwnedNeigh1;
                paramBV[131] = new OleDbParameter("@IsOfficeSelfOwnedNeigh2", OleDbType.VarChar, 50);
                paramBV[131].Value = IsOfficeSelfOwnedNeigh2;
                paramBV[132] = new OleDbParameter("@LevelOfBusActivity", OleDbType.VarChar, 100);
                paramBV[132].Value = LevelOfBusActivity;
                paramBV[133] = new OleDbParameter("@IsResiCumOfficeSelfOwned", OleDbType.VarChar, 10);
                paramBV[133].Value = IsResiCumOfficeSelfOwned;
                paramBV[134] = new OleDbParameter("@StockSeen", OleDbType.VarChar, 200);
                paramBV[134].Value = StockSeen;
                paramBV[135] = new OleDbParameter("@MthOfWorkCurrentOffice", OleDbType.VarChar, 50);
                paramBV[135].Value = MthOfWorkCurrentOffice;
                paramBV[136] = new OleDbParameter("@PurposeOfLoanTaken", OleDbType.VarChar, 255);
                paramBV[136].Value = PurposeOfLoanTaken;
                paramBV[137] = new OleDbParameter("@ModifyBy", OleDbType.VarChar, 15);
                paramBV[137].Value = ModifyBy;
                paramBV[138] = new OleDbParameter("@ModifyOn", OleDbType.DBTimeStamp);
                paramBV[138].Value = ModifyOn;
                paramBV[139] = new OleDbParameter("@NameOfCollegue", OleDbType.VarChar, 50);
                paramBV[139].Value = NameOfCollegue;
                paramBV[140] = new OleDbParameter("@DesgnDeptCollegue", OleDbType.VarChar, 50);
                paramBV[140].Value = DesgnDeptCollegue;
                paramBV[141] = new OleDbParameter("@MthOfCompExistAtAddress", OleDbType.VarChar, 15);
                paramBV[141].Value = MthOfCompExistAtAddress;
                paramBV[142] = new OleDbParameter("@ProfileCoNeighbour", OleDbType.VarChar, 100);
                paramBV[142].Value = ProfileCoNeighbour;
                paramBV[143] = new OleDbParameter("@AppNameVerifiedFrom", OleDbType.VarChar, 50);
                paramBV[143].Value = AppNameVerifiedFrom;
                paramBV[144] = new OleDbParameter("@RoofType", OleDbType.VarChar, 50);
                paramBV[144].Value = RoofType;
                paramBV[145] = new OleDbParameter("@SupervisorComment", OleDbType.VarChar, 250);
                paramBV[145].Value = SupervisorComment;
                paramBV[146] = new OleDbParameter("@CityLimit", OleDbType.VarChar, 250);
                paramBV[146].Value = CityLimit; 
                //added by kamal matekar....
                paramBV[147] = new OleDbParameter("@MainlineBusiness", OleDbType.VarChar, 250);
                paramBV[147].Value = MainlineBusiness;
                paramBV[148] = new OleDbParameter("@ValueofNostocksighted", OleDbType.VarChar, 250);
                paramBV[148].Value = ValueofNostocksighted;
                paramBV[149] = new OleDbParameter("@CategoryofCompany", OleDbType.VarChar, 250);
                paramBV[149].Value = CategoryofCompany;
                paramBV[150] = new OleDbParameter("@NormalOfficeJob", OleDbType.VarChar, 250);
                paramBV[150].Value = NormalOfficeJob;
                paramBV[151] = new OleDbParameter("@CustomerSeen", OleDbType.VarChar, 500);
                paramBV[151].Value = CustomerSeen;
                paramBV[152] = new OleDbParameter("@TypeJob", OleDbType.VarChar, 500);
                paramBV[152].Value = TypeJob;
                paramBV[153] = new OleDbParameter("@AppliWork", OleDbType.VarChar, 500);
                paramBV[153].Value = AppliWork;
                paramBV[154] = new OleDbParameter("@Appli_JobTrans", OleDbType.VarChar, 500);
                paramBV[154].Value = AppliJobTrans;
                paramBV[155] = new OleDbParameter("@OffExit", OleDbType.VarChar, 500);
                paramBV[155].Value = OffExit;
                paramBV[156] = new OleDbParameter("@VehiOwn", OleDbType.VarChar, 500);
                paramBV[156].Value = VehiOwn;
                paramBV[157] = new OleDbParameter("@BussPrem", OleDbType.VarChar, 500);
                paramBV[157].Value = BussPrem;
                paramBV[158] = new OleDbParameter("@RefName", OleDbType.VarChar, 500);
                paramBV[158].Value = RefName;
                paramBV[159] = new OleDbParameter("@RefAdd", OleDbType.VarChar, 500);
                paramBV[159].Value = RefAdd;
                paramBV[160] = new OleDbParameter("@MonthTurn", OleDbType.VarChar, 500);
                paramBV[160].Value = MonthTurn;
                paramBV[161] = new OleDbParameter("@NumberBed", OleDbType.VarChar, 500);
                paramBV[161].Value = NumberBed;
                paramBV[162] = new OleDbParameter("@NeighCheck", OleDbType.VarChar, 500);
                paramBV[162].Value = NeighCheck;
                paramBV[163] = new OleDbParameter("@ClinicYear", OleDbType.VarChar, 500);
                paramBV[163].Value = ClinicYear;
                paramBV[164] = new OleDbParameter("@SeparateResi", OleDbType.VarChar, 500);
                paramBV[164].Value = SeparateResi;
                paramBV[165] = new OleDbParameter("@SeparateFactory", OleDbType.VarChar, 500);
                paramBV[165].Value = SeparateFactory;
                paramBV[166] = new OleDbParameter("@SeparateEntrance", OleDbType.VarChar, 500);
                paramBV[166].Value = SeparateEntrance;
                paramBV[167] = new OleDbParameter("@SeparateOffice", OleDbType.VarChar, 500);
                paramBV[167].Value = SeparateOffice;
                paramBV[168] = new OleDbParameter("@OfficeLimit", OleDbType.VarChar, 500);
                paramBV[168].Value = OfficeLimit;

                //ended by kamal matekar....
                paramBV[169] = new OleDbParameter("@CaseID", OleDbType.VarChar, 15);
                paramBV[169].Value = CaseId;
                paramBV[170] = new OleDbParameter("@VerificationTypeId", OleDbType.VarChar, 15);
                paramBV[170].Value = VerificationTypeId;

                sRetVal = "Record updated successfully.";
            }
            OleDbHelper.ExecuteNonQuery(oledbTrans, CommandType.Text, sSql, paramBV);

            //Start Insert into CASE_TRANSACTION_LOG -------------------
            sSql = "";
            sSql = "Insert into CASE_TRANSACTION_LOG(CASE_ID,VERIFICATION_TYPE_ID,USER_ID,TRANS_START,TRANS_END," +
                 "CENTRE_ID,PRODUCT_ID,CLIENT_ID) VALUES(?,?,?,?,?,?,?,?)";

            OleDbParameter[] paramTransLog = new OleDbParameter[8];
            paramTransLog[0] = new OleDbParameter("@CaseID", OleDbType.VarChar, 15);
            paramTransLog[0].Value = CaseId;
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
            //Update CPV_CC_Case_details with status 'Y' ---------------
            /////added by kamal matekar.....
            if (VerificationTypeId == "25" || VerificationTypeId == "26" || VerificationTypeId == "27" || VerificationTypeId == "28")
            {
                if (IsQCVerificationComplete(oledbTrans, CaseId, ClientId, CentreId) == "true")
                {
                    QCVerificationComplete(oledbTrans, CaseId);
                    sRetVal += " Case verification data entry completed.";
                }
            }
            else
            {
                if (IsVerificationComplete(oledbTrans, CaseId, ClientId, CentreId) == "true")
                {
                    VerificationComplete(oledbTrans, CaseId);
                    sRetVal += " Case verification data entry completed.";

                }
            }
            /////////////////////////////////////////////////////////////////////////////////////////////
            oledbTrans.Commit();
            oledbConn.Close();

            return sRetVal;
        }
        catch (Exception ex)
        {
            oledbTrans.Rollback();
            oledbConn.Close();
            throw new Exception("Error while Inserting/updating Verification entry. " + ex.Message);
        }
    }
    #endregion

    # region GetFEName()
    
    public OleDbDataReader GetFEName(string sCaseId, string sVeriTypeId)
    {
        string sSql = "";
        sSql = "select distinct fullname,FE_ID from fe_vw fv inner join CPV_RL_CASE_FE_MAPPING cifcm on(cifcm.fe_id=fv.emp_id)  where case_id='" + sCaseId + "' and Verification_Type_id='" + sVeriTypeId + "' order by fv.fullname";
        return OleDbHelper.ExecuteReader(objCmn.ConnectionString, CommandType.Text, sSql);
    }

    #endregion GetFEName()

    #region IsVerificationComplete
    //Name             :   IsVerificationComplete
    //Create By		   :   Hemangi Kambli
    //Create Date	   :   05 Aug 2007
    //Remarks 		   :   This method is used to check whether verification of case is completed or not.

    public string IsVerificationComplete(OleDbTransaction oledbTrans, string sCaseId, string sClientId, string sCenterId)
    {
        string sSql = "";
        OleDbDataReader oledbRead;
        string bComplete="";
        //sSql = " Select * from CPV_RL_CASE_STATUS_NULL " +
        //       " where case_id='" + sCaseId + "' and Client_id='" + sClientId + "'" +
        //       " and Centre_id='" + sCenterId + "'";

        sSql = "Select case (select count(*) from CPV_RL_CASE_VERIFICATIONTYPE " +
               " where case_id='" + sCaseId + "') " +
               " when (select count(*) from CPV_RL_CASE_STATUS_VIEW where case_id='" + sCaseId + "')" +
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
