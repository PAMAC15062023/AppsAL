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
/// Summary description for CRL_ResiCumBusiness
/// </summary>
public class CRL_ResiCumBusiness
{
    private CCommon objCon;
 
	public CRL_ResiCumBusiness()
	{
        objCon = new CCommon();
		//
		// TODO: Add constructor logic here
		//
    }
    #region Properties Declaration
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
    private string sSupervisorComment;
    public string SupervisorComment
    {
        get { return sSupervisorComment; }
        set { sSupervisorComment = value; }
    }
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

    private string  strMonthofStayatResidenceNeigh1;
    public string MonthofStayatResidenceNeigh1
    {
        get
        {
            return strMonthofStayatResidenceNeigh1;
        }
        set
        {
            strMonthofStayatResidenceNeigh1 = value;
        }
    }
    private string strMonthofStayatResidenceNeigh2;
    public string MonthofStayatResidenceNeigh2
    {
        get
        {
            return strMonthofStayatResidenceNeigh2;
        }
        set
        {
            strMonthofStayatResidenceNeigh2 = value;
        }
    }

    private string strNamePlateSightedResi;
    public string NamePlateSightedResi
    {
        get
        {
            return strNamePlateSightedResi;
        }
        set
        {
            strNamePlateSightedResi = value;
        }
    }

    private string strNamePlateSightedOffice;
    public string NamePlateSightedOffice
    {
        get
        {
            return strNamePlateSightedOffice;
        }
        set
        {
            strNamePlateSightedOffice = value;
        }
    }
    private string strEntryPermittedResi;
    public string EntryPermittedResi
    {
        get
        {
            return strEntryPermittedResi;
        }
        set
        {
            strEntryPermittedResi = value;
        }
    }
    private string strEntryPermittedOffice;
    public string EntryPermittedOffice
    {
        get
        {
            return strEntryPermittedOffice;
        }
        set
        {
            strEntryPermittedOffice = value;
        }
    }
    private string strApproxAreaResi;
    public string ApproxAreaResi
    {
        get
        {
            return strApproxAreaResi;
        }
        set
        {
            strApproxAreaResi = value;
        }
    }
    private string strApproxAreaOffice;
    public string ApproxAreaOffice
    {
        get
        {
            return strApproxAreaOffice;
        }
        set
        {
            strApproxAreaOffice = value;
        }
    }
    private string strOfficeName;
    public string OfficeName
    {
        get
        {
            return strOfficeName;
        }
        set
        {
            strOfficeName = value;
        }
    }

    private string strAgencyCode;
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

    private string strDateOfVerification;
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

    private string strTimeOfVerification;
    public string TimeOfVerification
    {
        get
        {
            return strTimeOfVerification;
        }
        set
        {
            strTimeOfVerification = value;
        }
    }
 
 
    
    private string strVerificationAgency;
    public string VerificationAgency
    {
        get
        {
            return strVerificationAgency;
        }
        set
        {
            strVerificationAgency = value;
        }
    }
    private string strVerificationAgent;
    public string VerificationAgent
    {
        get
        {
            return strVerificationAgent;
        }
        set
        {
            strVerificationAgent = value;
        }
    }
    private string strCustomerName;
    public string CustomerName
    {
        get
        {
            return strCustomerName;
        }
        set
        {
            strCustomerName = value;
        }
    }
    private string strAddress;
    public string Address
    {
        get
        {
            return strAddress;
        }
        set
        {
            strAddress = value;
        }
    }
    private string strNameOfNeighbour1;
    public string NameOfNeighbour1
    {
        get
        {
            return strNameOfNeighbour1;
        }
        set
        {
            strNameOfNeighbour1 = value;
        }
    }
    private string strAddressOfNeighbour1;
    public string AddressOfNeighbour1
    {
        get
        {
            return strAddressOfNeighbour1;
        }
        set
        {
            strAddressOfNeighbour1 = value;
        }
    }
    private string strDoestheApplicantWorkHere1;
    public string DoestheApplicantWorkHere1
    {
        get
        {
            return strDoestheApplicantWorkHere1;
        }
        set
        {
            strDoestheApplicantWorkHere1 = value;
        }
    }
    private string strMonthsOfWorkAtOffice1;
    public string MonthsOfWorkAtOffice1
    {
        get
        {
            return strMonthsOfWorkAtOffice1;
        }
        set
        {
            strMonthsOfWorkAtOffice1 = value;
        }
    }
    private string strMarketReputation1;
    public string MarketReputation1
    {
        get
        {
            return strMarketReputation1;
        }
        set
        {
            strMarketReputation1 = value;
        }
    }
    private string strIstheOfficeSelfOwned1;
    public string IstheOfficeSelfOwned1
    {
        get
        {
            return strIstheOfficeSelfOwned1;
        }
        set
        {
            strIstheOfficeSelfOwned1 = value;
        }
    }
    private string strCommentsOfNeighbour1;
    public string CommentsOfNeighbour1
    {
        get
        {
            return strCommentsOfNeighbour1;
        }
        set
        {
            strCommentsOfNeighbour1 = value;
        }
    }
    private string strNameOfNeighbour2;
    public string NameOfNeighbour2
    {
        get
        {
            return strNameOfNeighbour2;
        }
        set
        {
            strNameOfNeighbour2 = value;
        }
    }
    private string strAddressOfNeighbour2;
    public string AddressOfNeighbour2
    {
        get
        {
            return strAddressOfNeighbour2;
        }
        set
        {
            strAddressOfNeighbour2 = value;
        }
    }
    private string strDoestheApplicantWorkHere2;
    public string DoestheApplicantWorkHere2
    {
        get
        {
            return strDoestheApplicantWorkHere2;
        }
        set
        {
            strDoestheApplicantWorkHere2 = value;
        }
    }
    private string strMonthsOfWorkAtOffice2;
    public string MonthsOfWorkAtOffice2
    {
        get
        {
            return strMonthsOfWorkAtOffice2;
        }
        set
        {
            strMonthsOfWorkAtOffice2 = value;
        }
    }
    private string strMarketReputation2;
    public string MarketReputation2
    {
        get
        {
            return strMarketReputation2;
        }
        set
        {
            strMarketReputation2 = value;
        }
    }
    private string strIstheOfficeSelfOwned2;
    public string IstheOfficeSelfOwned2
    {
        get
        {
            return strIstheOfficeSelfOwned2;
        }
        set
        {
            strIstheOfficeSelfOwned2 = value;
        }
    }
    private string strCommentsOfNeighbour2;
    public string CommentsOfNeighbour2
    {
        get
        {
            return strCommentsOfNeighbour2;
        }
        set
        {
            strCommentsOfNeighbour2 = value;
        }
    }
    private string strLocalitySurroundings;
    public string LocalitySurroundings
    {
        get
        {
            return strLocalitySurroundings;
        }
        set
        {
            strLocalitySurroundings = value;
        }
    }
    private string strLandmark;
    public string Landmark
    {
        get
        {
            return strLandmark;
        }
        set
        {
            strLandmark = value;
        }
    }
    private string strTypeOfBusinessActivity;
    public string TypeOfBusinessActivity
    {
        get
        {
            return strTypeOfBusinessActivity;
        }
        set
        {
            strTypeOfBusinessActivity = value;
        }
    }
    private string strLevelOfBusinessActivity;
    public string LevelOfBusinessActivity
    {
        get
        {
            return strLevelOfBusinessActivity;
        }
        set
        {
            strLevelOfBusinessActivity = value;
        }
    }
    private string strStockSeen;
    public string StockSeen
    {
        get
        {
            return strStockSeen;
        }
        set
        {
            strStockSeen = value;
        }
    }
    private string strNoOfEmployeesSeen;
    public string NoOfEmployeesSeen
    {
        get
        {
            return strNoOfEmployeesSeen;
        }
        set
        {
            strNoOfEmployeesSeen = value;
        }
    }
    private string strAccessibility;
    public string Accessibility
    {
        get
        {
            return strAccessibility;
        }
        set
        {
            strAccessibility = value;
        }
    }
    private string strEntranceMotorable;
    public string EntranceMotorable
    {
        get
        {
            return strEntranceMotorable;
        }
        set
        {
            strEntranceMotorable = value;
        }
    }
    private string strClearDemarcationBetweenResidenceAndOffice;
    public string ClearDemarcationBetweenResidenceAndOffice
    {
        get
        {
            return strClearDemarcationBetweenResidenceAndOffice;
        }
        set
        {
            strClearDemarcationBetweenResidenceAndOffice = value;
        }
    }
    private string strInternalCondition;
    public string InternalCondition
    {
        get
        {
            return strInternalCondition;
        }
        set
        {
            strInternalCondition = value;
        }
    }
    private string strExternalCondition;
    public string ExternalCondition
    {
        get
        {
            return strExternalCondition;
        }
        set
        {
            strExternalCondition = value;
        }
    }
    
    private string strAssetSeen;
    public string AssetSeen
    {
        get
        {
            return strAssetSeen;
        }
        set
        {
            strAssetSeen = value;
        }
    }
    private string strNameOfPersonContacted;
    public string NameOfPersonContacted
    {
        get
        {
            return strNameOfPersonContacted;
        }
        set
        {
            strNameOfPersonContacted = value;
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
    private string strIdentityProofSeen;
    public string IdentityProofSeen
    {
        get
        {
            return strIdentityProofSeen;
        }
        set
        {
            strIdentityProofSeen = value;
        }
    }
    private string strBusinessProofSeen;
    public string BusinessProofSeen
    {
        get
        {
            return strBusinessProofSeen;
        }
        set
        {
            strBusinessProofSeen = value;
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
    private string strTypeOfOrganization;
    public string TypeOfOrganization
    {
        get
        {
            return strTypeOfOrganization;
        }
        set
        {
            strTypeOfOrganization = value;
        }
    }
    private string strStatusOfResidence;
    public string StatusOfResidence
    {
        get
        {
            return strStatusOfResidence;
        }
        set
        {
            strStatusOfResidence = value;
        }
    }
    private string strMonthsOfWorkAtCurrentOffice;
    public string MonthsOfWorkAtCurrentOffice
    {
        get
        {
            return strMonthsOfWorkAtCurrentOffice;
        }
        set
        {
            strMonthsOfWorkAtCurrentOffice = value;
        }
    }
    private string strMonthsOfStayAtResidence;
    public string MonthsOfStayAtResidence
    {
        get
        {
            return strMonthsOfStayAtResidence;
        }
        set
        {
            strMonthsOfStayAtResidence = value;
        }
    }
    private string strApplicantsIncome;
    public string ApplicantsIncome
    {
        get
        {
            return strApplicantsIncome;
        }
        set
        {
            strApplicantsIncome = value;
        }
    }
    private string strOtherSourceOfIncome;
    public string OtherSourceOfIncome
    {
        get
        {
            return strOtherSourceOfIncome;
        }
        set
        {
            strOtherSourceOfIncome = value;
        }
    }
    private string strDetailsOfPreviousOccupation;
    public string DetailsOfPreviousOccupation
    {
        get
        {
            return strDetailsOfPreviousOccupation;
        }
        set
        {
            strDetailsOfPreviousOccupation = value;
        }
    }
    private string strFatherOrSpousesName;
    public string FatherOrSpousesName
    {
        get
        {
            return strFatherOrSpousesName;
        }
        set
        {
            strFatherOrSpousesName = value;
        }
    }
    private string strMothersName;
    public string MothersName
    {
        get
        {
            return strMothersName;
        }
        set
        {
            strMothersName = value;
        }
    }
    private string strMaritalStatus;
    public string MaritalStatus
    {
        get
        {
            return strMaritalStatus;
        }
        set
        {
            strMaritalStatus = value;
        }
    }
    private string strNoOfDependents;
    public string NoOfDependents
    {
        get
        {
            return strNoOfDependents;
        }
        set
        {
            strNoOfDependents = value;
        }
    }
    private string strOtherInvestments;
    public string OtherInvestments
    {
        get
        {
            return strOtherInvestments;
        }
        set
        {
            strOtherInvestments = value;
        }
    }
    private string strAnyOtherLoansBeingTaken;
    public string AnyOtherLoansBeingTaken
    {
        get
        {
            return strAnyOtherLoansBeingTaken;
        }
        set
        {
            strAnyOtherLoansBeingTaken = value;
        }
    }
    private string strPurposeOfLoanBeingTaken;
    public string PurposeOfLoanBeingTaken
    {
        get
        {
            return strPurposeOfLoanBeingTaken;
        }
        set
        {
            strPurposeOfLoanBeingTaken = value;
        }
    }
    private string strBehaviourOfPersonContacted;
    public string BehaviourOfPersonContacted
    {
        get
        {
            return strBehaviourOfPersonContacted;
        }
        set
        {
            strBehaviourOfPersonContacted = value;
        }
    }
    private string strEducationBackground;
    public string EducationBackground
    {
        get
        {
            return strEducationBackground;
        }
        set
        {
            strEducationBackground = value;
        }
    }
    private string strVerifiersComments;
    public string VerifiersComments
    {
        get
        {
            return strVerifiersComments;
        }
        set
        {
            strVerifiersComments = value;
        }
    }
    private string strColourOfDoor;
    public string ColourOfDoor
    {
        get
        {
            return strColourOfDoor;
        }
        set
        {
            strColourOfDoor = value;
        }
    }
    private string strProofOfBusinessActivity;
    public string ProofOfBusinessActivity
    {
        get
        {
            return strProofOfBusinessActivity;
        }
        set
        {
            strProofOfBusinessActivity = value;
        }
    }
    private string strOverallVerification;
    public string OverallVerification
    {
        get
        {
            return strOverallVerification;
        }
        set
        {
            strOverallVerification = value;
        }
    }
    private string strLanNo;
    public string LanNo
    {
        get
        {
            return strLanNo;
        }
        set
        {
            strLanNo = value;
        }
    }
    private string strTelNoTypeOfPhone;
    public string TelNoTypeOfPhone
    {
        get
        {
            return strTelNoTypeOfPhone;
        }
        set
        {
            strTelNoTypeOfPhone = value;
        }
    }
    private string strMobileNoTypeOfPhone;
    public string MobileNoTypeOfPhone
    {
        get
        {
            return strMobileNoTypeOfPhone;
        }
        set
        {
            strMobileNoTypeOfPhone = value;
        }
    }
    private string strLoanAmount;
    public string LoanAmount
    {
        get
        {
            return strLoanAmount;
        }
        set
        {
            strLoanAmount = value;
        }
    }
    private string strUseOfLoan;
    public string UseOfLoan
    {
        get
        {
            return strUseOfLoan;
        }
        set
        {
            strUseOfLoan = value;
        }
    }
    private string strProduct;
    public string Product
    {
        get
        {
            return strProduct;
        }
        set
        {
            strProduct = value;
        }
    }
    private string strLocationOfProduct;
    public string LocationOfProduct
    {
        get
        {
            return strLocationOfProduct;
        }
        set
        {
            strLocationOfProduct = value;
        }
    }
    private string strDOB;
    public string DOB
    {
        get
        {
            return strDOB;
        }
        set
        {
            strDOB = value;
        }
    }
    private string strFamilyDetails;
    public string FamilyDetails
    {
        get
        {
            return strFamilyDetails;
        }
        set
        {
            strFamilyDetails = value;
        }
    }
    private string strTotalFamilyIncome;
    public string TotalFamilyIncome
    {
        get
        {
            return strTotalFamilyIncome;
        }
        set
        {
            strTotalFamilyIncome = value;
        }
    }
    private string strDetailsOfWorkingMembersOthers;
    public string DetailsOfWorkingMembersOthers
    {
        get
        {
            return strDetailsOfWorkingMembersOthers;
        }
        set
        {
            strDetailsOfWorkingMembersOthers = value;
        }
    }
    private string strLoanCancellation;
    public string LoanCancellation
    {
        get
        {
            return strLoanCancellation;
        }
        set
        {
            strLoanCancellation = value;
        }
    }
    private string strAnyCreditCardIfYesProvideNameAndLimitOnEach;
    public string AnyCreditCardIfYesProvideNameAndLimitOnEach
    {
        get
        {
            return strAnyCreditCardIfYesProvideNameAndLimitOnEach;
        }
        set
        {
            strAnyCreditCardIfYesProvideNameAndLimitOnEach = value;
        }
    }
    private string strAnyotherLoansIfYesProvidedetailsOfAmountCompanyAndEMI;
    public string AnyotherLoansIfYesProvidedetailsOfAmountCompanyAndEMI
    {
        get
        {
            return strAnyotherLoansIfYesProvidedetailsOfAmountCompanyAndEMI;
        }
        set
        {
            strAnyotherLoansIfYesProvidedetailsOfAmountCompanyAndEMI = value;
        }
    }
    private string strNoOfYrsAtResidence;
    public string NoOfYrsAtResidence
    {
        get
        {
            return strNoOfYrsAtResidence;
        }
        set
        {
            strNoOfYrsAtResidence = value;
        }
    }
    private string strAreaOfHouse;
    public string AreaOfHouse
    {
        get
        {
            return strAreaOfHouse;
        }
        set
        {
            strAreaOfHouse = value;
        }
    }
    private string strAreaOfOffice;
    public string AreaOfOffice
    {
        get
        {
            return strAreaOfOffice;
        }
        set
        {
            strAreaOfOffice = value;
        }
    }
    private string strNoOfYrsSinceTheBizEstablishment;
    public string NoOfYrsSinceTheBizEstablishment
    {
        get
        {
            return strNoOfYrsSinceTheBizEstablishment;
        }
        set
        {
            strNoOfYrsSinceTheBizEstablishment = value;
        }
    }
    private string strSeparateAreaForOfficeAvailable;
    public string SeparateAreaForOfficeAvailable
    {
        get
        {
            return strSeparateAreaForOfficeAvailable;
        }
        set
        {
            strSeparateAreaForOfficeAvailable = value;
        }
    }
    private string strOwnershipOfresidence;
    public string OwnershipOfresidence
    {
        get
        {
            return strOwnershipOfresidence;
        }
        set
        {
            strOwnershipOfresidence = value;
        }
    }
    private string strTypeOfCompany;
    public string TypeOfCompany
    {
        get
        {
            return strTypeOfCompany;
        }
        set
        {
            strTypeOfCompany = value;
        }
    }
    private string strLocationOfHouse;
    public string LocationOfHouse
    {
        get
        {
            return strLocationOfHouse;
        }
        set
        {
            strLocationOfHouse = value;
        }
    }
    private string strApproachToHouse;
    public string ApproachToHouse
    {
        get
        {
            return strApproachToHouse;
        }
        set
        {
            strApproachToHouse = value;
        }
    }
    private string strStandardOfLiving;
    public string StandardOfLiving
    {
        get
        {
            return strStandardOfLiving;
        }
        set
        {
            strStandardOfLiving = value;
        }
    }
    private string strWalls;
    public string Walls
    {
        get
        {
            return strWalls;
        }
        set
        {
            strWalls = value;
        }
    }
    private string strRoofType;
    public string RoofType
    {
        get
        {
            return strRoofType;
        }
        set
        {
            strRoofType = value;
        }
    }
    private string strExteriorConditions;
    public string ExteriorConditions
    {
        get
        {
            return strExteriorConditions;
        }
        set
        {
            strExteriorConditions = value;
        }
    }
    private string strInteriorConditions;
    public string InteriorConditions
    {
        get
        {
            return strInteriorConditions;
        }
        set
        {
            strInteriorConditions = value;
        }
    }
    private string strTypeOfResidence;
    public string TypeOfResidence
    {
        get
        {
            return strTypeOfResidence;
        }
        set
        {
            strTypeOfResidence = value;
        }
    }
    private string strFlooring;
    public string Flooring
    {
        get
        {
            return strFlooring;
        }
        set
        {
            strFlooring = value;
        }
    }
    private string strOfficeAmbience;
    public string OfficeAmbience
    {
        get
        {
            return strOfficeAmbience;
        }
        set
        {
            strOfficeAmbience = value;
        }
    }
    private string strQuantityOfStock;
    public string QuantityOfStock
    {
        get
        {
            return strQuantityOfStock;
        }
        set
        {
            strQuantityOfStock = value;
        }
    }
    private string strCompanyNameBoardSeen;
    public string CompanyNameBoardSeen
    {
        get
        {
            return strCompanyNameBoardSeen;
        }
        set
        {
            strCompanyNameBoardSeen = value;
        }
    }
    private string strIfSmallTimerLetterHeadOrBizCardSeen;
    public string IfSmallTimerLetterHeadOrBizCardSeen
    {
        get
        {
            return strIfSmallTimerLetterHeadOrBizCardSeen;
        }
        set
        {
            strIfSmallTimerLetterHeadOrBizCardSeen = value;
        }
    }
    private string strNoEmployeeSeen;
    public string NoEmployeeSeen
    {
        get
        {
            return strNoEmployeeSeen;
        }
        set
        {
            strNoEmployeeSeen = value;
        }
    }
    private string strNoOfCustomerSeen;
    public string NoOfCustomerSeen
    {
        get
        {
            return strNoOfCustomerSeen;
        }
        set
        {
            strNoOfCustomerSeen = value;
        }
    }
    private string strIsTheAddressOfApplicantSame;
    public string IsTheAddressOfApplicantSame
    {
        get
        {
            return strIsTheAddressOfApplicantSame;
        }
        set
        {
            strIsTheAddressOfApplicantSame = value;
        }
    }
    private string strNoOfMembers;
    public string NoOfMembers
    {
        get
        {
            return strNoOfMembers;
        }
        set
        {
            strNoOfMembers = value;
        }
    }
    private string strNoOfYrsAtCurrentResidence;
    public string NoOfYrsAtCurrentResidence
    {
        get
        {
            return strNoOfYrsAtCurrentResidence;
        }
        set
        {
            strNoOfYrsAtCurrentResidence = value;
        }
    }
    private string strAgeOfApplicant;
    public string AgeOfApplicant
    {
        get
        {
            return strAgeOfApplicant;
        }
        set
        {
            strAgeOfApplicant = value;
        }
    }
    private string strNameAndAddressOfThirdParty;
    public string NameAndAddressOfThirdParty
    {
        get
        {
            return strNameAndAddressOfThirdParty;
        }
        set
        {
            strNameAndAddressOfThirdParty = value;
        }
    }
    private string strTimeWhenApplicantIsHome;
    public string TimeWhenApplicantIsHome
    {
        get
        {
            return strTimeWhenApplicantIsHome;
        }
        set
        {
            strTimeWhenApplicantIsHome = value;
        }
    }
    private string strThirdPartyComment;
    public string ThirdPartyComment
    {
        get
        {
            return strThirdPartyComment;
        }
        set
        {
            strThirdPartyComment = value;
        }
    }
    private string strAddressProofSighted;
    public string AddressProofSighted
    {
        get
        {
            return strAddressProofSighted;
        }
        set
        {
            strAddressProofSighted = value;
        }
    }
    private string strTypeOfAddressProof;
    public string TypeOfAddressProof
    {
        get
        {
            return strTypeOfAddressProof;
        }
        set
        {
            strTypeOfAddressProof = value;
        }
    }
    private string strTallieswithTheCurrentAddress;
    public string TallieswithTheCurrentAddress
    {
        get
        {
            return strTallieswithTheCurrentAddress;
        }
        set
        {
            strTallieswithTheCurrentAddress = value;
        }
    }
    private string strResidentOCL;
    public string ResidentOCL
    {
        get
        {
            return strResidentOCL;
        }
        set
        {
            strResidentOCL = value;
        }
    }
    private string strIsItANegativeArea;
    public string IsItANegativeArea
    {
        get
        {
            return strIsItANegativeArea;
        }
        set
        {
            strIsItANegativeArea = value;
        }
    }
    private string strIsHeAffliatedToAnyPoliticalParty;
    public string IsHeAffliatedToAnyPoliticalParty
    {
        get
        {
            return strIsHeAffliatedToAnyPoliticalParty;
        }
        set
        {
            strIsHeAffliatedToAnyPoliticalParty = value;
        }
    }
    private string strIsItABlackArea;
    public string IsItABlackArea
    {
        get
        {
            return strIsItABlackArea;
        }
        set
        {
            strIsItABlackArea = value;
        }
    }
    private string strProfile;
    public string Profile
    {
        get
        {
            return strProfile;
        }
        set
        {
            strProfile = value;
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

    public string InsertResiCumBusiness()
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
            sqlQuery = " Select case_id,verification_type_id from CPV_RL_VERIVICATION_RESBUSI " +
                       " where case_id = '" + CaseID + "'" + " And verification_type_id='" + VerificationTypeID + "'";

            oledbDR = OleDbHelper.ExecuteReader(objCon.ConnectionString, CommandType.Text, sqlQuery);

            OleDbParameter[] oledbParam = new OleDbParameter[72];
            if (oledbDR.Read() == false)
            {
                sql = "Insert into CPV_RL_VERIVICATION_RESBUSI (case_id,verification_type_id,Name_Neighbour1,Address_Neighbour1," +
                       " Neighbour1_confirmation,Month_at_office,Market_Reputation_Neighbour1,Office_self_owned1,Comments_Neighbour1," +
                       " Name_Neighbour2,Address_Neighbour2,Neighbour1_confirmation2,Month_at_office1,Market_Reputation_Neighbour2," +
                       " Office_self_owned2,Comments_Neighbour2,Locality,Landmark,Type_Business_Activity,Level_Business_Activity," +
                       " Stock_Seen,NO_EMP_SEEN,Accessibility,Entrance_Motorable,Clear_demarcation_RES_OFFICE,Internal_condition," +
                       " External_Condition,Name_Plate_Sighted_Resi,Entry_permitted_Resi,Approx_Area_Resi,Asset_Seen,Person_contacted,Relationship," +
                       " Identity_proof_seen,Business_proof_seen,Nature_Business,Type_Organization,Status_Residence,Months_work_current_office," +
                       " Months_stay_residencE,Applicant_Income,Other_sources_income,previous_occupation,FATHER_Spouse_Name,MOTHER_NAME,Marital_Status," +
                       " No_of_dependents,Other_Investments,other_loans_TAKEN,Purpose_Loan,behaviour_person_contacted,Education_Background,Verifier_Comments," +
                       " Colour_Door,Proof_Business_Acitivity,Overall_Verification,Verification_status,Office_Name,Name_Plate_Sighted_Office,Entry_permitted_Office," +
                       " Approx_Area_Office,Agency_Code,VERIFICATION_DATETIME,Unsatisfactory_Reason,Month_Stay_Resi_Neigh1,Month_Stay_Resi_Neigh2,ADD_BY,ADD_DATE," +
                       " SEP_BATHROOM_SEEN,FAMILY_SEEN,SUPERVISOR_COMMENTS,Roof_Type)"+
                       " values (?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)";

                oledbParam[0] = new OleDbParameter("@CaseID", OleDbType.VarChar, 15);
                oledbParam[0].Value = CaseID;

                oledbParam[1] = new OleDbParameter("@VerificationTypeID", OleDbType.VarChar, 15);
                oledbParam[1].Value = VerificationTypeID;

                oledbParam[2] = new OleDbParameter("@NameOfNeighbour1", OleDbType.VarChar, 100);
                oledbParam[2].Value = NameOfNeighbour1;

                oledbParam[3] = new OleDbParameter("@AddressOfNeighbour1", OleDbType.VarChar, 100);
                oledbParam[3].Value = AddressOfNeighbour1;

                oledbParam[4] = new OleDbParameter("@DoestheApplicantWorkHere1", OleDbType.VarChar, 50);
                oledbParam[4].Value = DoestheApplicantWorkHere1;

                oledbParam[5] = new OleDbParameter("@MonthsOfWorkAtOffice1", OleDbType.VarChar, 50);
                oledbParam[5].Value = MonthsOfWorkAtOffice1;

                oledbParam[6] = new OleDbParameter("@MarketReputation1", OleDbType.VarChar, 100);
                oledbParam[6].Value = MarketReputation1;

                oledbParam[7] = new OleDbParameter("@IstheOfficeSelfOwned1", OleDbType.VarChar, 50);
                oledbParam[7].Value = IstheOfficeSelfOwned1;

                oledbParam[8] = new OleDbParameter("@CommentsOfNeighbour1", OleDbType.VarChar, 750);
                oledbParam[8].Value = CommentsOfNeighbour1;

                oledbParam[9] = new OleDbParameter("@NameOfNeighbour2", OleDbType.VarChar, 100);
                oledbParam[9].Value = NameOfNeighbour2;

                oledbParam[10] = new OleDbParameter("@AddressOfNeighbour2", OleDbType.VarChar, 100);
                oledbParam[10].Value = AddressOfNeighbour2;

                oledbParam[11] = new OleDbParameter("@DoestheApplicantWorkHere2", OleDbType.VarChar, 50);
                oledbParam[11].Value = DoestheApplicantWorkHere2;

                oledbParam[12] = new OleDbParameter("@MonthsOfWorkAtOffice2", OleDbType.VarChar, 50);
                oledbParam[12].Value = MonthsOfWorkAtOffice2;

                oledbParam[13] = new OleDbParameter("@MarketReputation2", OleDbType.VarChar, 100);
                oledbParam[13].Value = MarketReputation2;

                oledbParam[14] = new OleDbParameter("@IstheOfficeSelfOwned2", OleDbType.VarChar, 50);
                oledbParam[14].Value = IstheOfficeSelfOwned2;

                oledbParam[15] = new OleDbParameter("@CommentsOfNeighbour2", OleDbType.VarChar, 750);
                oledbParam[15].Value = CommentsOfNeighbour2;

                oledbParam[16] = new OleDbParameter("@LocalitySurroundings", OleDbType.VarChar, 100);
                oledbParam[16].Value = LocalitySurroundings;

                oledbParam[17] = new OleDbParameter("@Landmark", OleDbType.VarChar, 100);
                oledbParam[17].Value = Landmark;

                oledbParam[18] = new OleDbParameter("@TypeOfBusinessActivity", OleDbType.VarChar, 100);
                oledbParam[18].Value = TypeOfBusinessActivity;

                oledbParam[19] = new OleDbParameter("@LevelOfBusinessActivity", OleDbType.VarChar, 100);
                oledbParam[19].Value = LevelOfBusinessActivity;

                oledbParam[20] = new OleDbParameter("@StockSeen", OleDbType.VarChar, 200);
                oledbParam[20].Value = StockSeen;

                oledbParam[21] = new OleDbParameter("@NoOfEmployeesSeen", OleDbType.VarChar, 50);
                oledbParam[21].Value = NoOfEmployeesSeen;

                oledbParam[22] = new OleDbParameter("@Accessibility", OleDbType.VarChar, 100);
                oledbParam[22].Value = Accessibility;

                oledbParam[23] = new OleDbParameter("@EntranceMotorable", OleDbType.VarChar, 100);
                oledbParam[23].Value = EntranceMotorable;

                oledbParam[24] = new OleDbParameter("@ClearDemarcationBetweenResidenceAndOffice", OleDbType.VarChar, 100);
                oledbParam[24].Value = ClearDemarcationBetweenResidenceAndOffice;

                oledbParam[25] = new OleDbParameter("@InternalCondition", OleDbType.VarChar, 100);
                oledbParam[25].Value = InternalCondition;

                oledbParam[26] = new OleDbParameter("@ExternalCondition", OleDbType.VarChar, 100);
                oledbParam[26].Value =ExternalCondition;

                oledbParam[27] = new OleDbParameter("@NamePlateSightedResi", OleDbType.VarChar, 50);
                oledbParam[27].Value = NamePlateSightedResi;

                oledbParam[28] = new OleDbParameter("@EntryPermittedResi", OleDbType.VarChar, 50);
                oledbParam[28].Value = EntryPermittedResi;

                oledbParam[29] = new OleDbParameter("@ApproxAreaResi", OleDbType.VarChar, 50);
                oledbParam[29].Value = ApproxAreaResi;

                oledbParam[30] = new OleDbParameter("@AssetSeen", OleDbType.VarChar, 200);
                oledbParam[30].Value = AssetSeen;

                oledbParam[31] = new OleDbParameter("@NameOfPersonContacted", OleDbType.VarChar, 100);
                oledbParam[31].Value = NameOfPersonContacted;

                oledbParam[32] = new OleDbParameter("@RelationshipWithApplicant", OleDbType.VarChar, 50);
                oledbParam[32].Value = RelationshipWithApplicant;

                oledbParam[33] = new OleDbParameter("@IdentityProofSeen", OleDbType.VarChar, 50);
                oledbParam[33].Value = IdentityProofSeen;

                oledbParam[34] = new OleDbParameter("@BusinessProofSeen", OleDbType.VarChar, 50);
                oledbParam[34].Value = BusinessProofSeen;

                oledbParam[35] = new OleDbParameter("@NatureOfBusiness", OleDbType.VarChar, 50);
                oledbParam[35].Value = NatureOfBusiness;

                oledbParam[36] = new OleDbParameter("@TypeOfOrganization", OleDbType.VarChar, 50);
                oledbParam[36].Value = TypeOfOrganization;


                oledbParam[37] = new OleDbParameter("@StatusOfResidence", OleDbType.VarChar, 50);
                oledbParam[37].Value = StatusOfResidence;

                oledbParam[38] = new OleDbParameter("@MonthsOfWorkAtCurrentOffice", OleDbType.VarChar, 50);
                oledbParam[38].Value = MonthsOfWorkAtCurrentOffice;

                oledbParam[39] = new OleDbParameter("@MonthsOfStayAtResidence", OleDbType.VarChar, 50);
                oledbParam[39].Value = MonthsOfStayAtResidence;

                oledbParam[40] = new OleDbParameter("@ApplicantsIncome", OleDbType.VarChar, 50);
                oledbParam[40].Value = ApplicantsIncome;

                oledbParam[41] = new OleDbParameter("@OtherSourceOfIncome", OleDbType.VarChar, 50);
                oledbParam[41].Value = OtherSourceOfIncome;

                oledbParam[42] = new OleDbParameter("@VerificationTypeID", OleDbType.VarChar, 100);
                oledbParam[42].Value = DetailsOfPreviousOccupation;

                oledbParam[43] = new OleDbParameter("@FatherOrSpousesName", OleDbType.VarChar, 100);
                oledbParam[43].Value = FatherOrSpousesName;

                oledbParam[44] = new OleDbParameter("@MothersName", OleDbType.VarChar, 100);
                oledbParam[44].Value = MothersName;

                oledbParam[45] = new OleDbParameter("@MaritalStatus", OleDbType.VarChar, 30);
                oledbParam[45].Value = MaritalStatus;

                oledbParam[46] = new OleDbParameter("@NoOfDependents", OleDbType.VarChar, 50);
                oledbParam[46].Value = NoOfDependents;

                oledbParam[47] = new OleDbParameter("@VerificationTypeID", OleDbType.VarChar, 100);
                oledbParam[47].Value = OtherInvestments;

                oledbParam[48] = new OleDbParameter("@AnyOtherLoansBeingTaken", OleDbType.VarChar, 50);
                oledbParam[48].Value = AnyOtherLoansBeingTaken;

                oledbParam[49] = new OleDbParameter("@PurposeOfLoanBeingTaken", OleDbType.VarChar, 50);
                oledbParam[49].Value = PurposeOfLoanBeingTaken;

                oledbParam[50] = new OleDbParameter("@BehaviourOfPersonContacted", OleDbType.VarChar, 50);
                oledbParam[50].Value = BehaviourOfPersonContacted;

                oledbParam[51] = new OleDbParameter("@EducationBackground", OleDbType.VarChar, 100);
                oledbParam[51].Value = EducationBackground;

                oledbParam[52] = new OleDbParameter("@VerifiersComments", OleDbType.VarChar, 750);
                oledbParam[52].Value = VerifiersComments;

                oledbParam[53] = new OleDbParameter("@ColourOfDoor", OleDbType.VarChar, 50);
                oledbParam[53].Value = ColourOfDoor;

                oledbParam[54] = new OleDbParameter("@ProofOfBusinessActivity", OleDbType.VarChar, 50);
                oledbParam[54].Value = ProofOfBusinessActivity;

                oledbParam[55] = new OleDbParameter("@OverallVerification", OleDbType.VarChar, 255);
                oledbParam[55].Value = OverallVerification;

                oledbParam[56] = new OleDbParameter("@Rating", OleDbType.VarChar, 50);

                if (Rating == "")
                {
                    oledbParam[56].Value = DBNull.Value;

                }
                else
                {
                    oledbParam[56].Value = Rating;
                }

                oledbParam[57] = new OleDbParameter("@OfficeName", OleDbType.VarChar, 100);
                oledbParam[57].Value = OfficeName;

                oledbParam[58] = new OleDbParameter("@NamePlateSightedOffice", OleDbType.VarChar, 50);
                oledbParam[58].Value = NamePlateSightedOffice;

                oledbParam[59] = new OleDbParameter("@EntryPermittedOffice", OleDbType.VarChar, 50);
                oledbParam[59].Value = EntryPermittedOffice;

                oledbParam[60] = new OleDbParameter("@ApproxAreaOffice", OleDbType.VarChar, 50);
                oledbParam[60].Value = ApproxAreaOffice;

                oledbParam[61] = new OleDbParameter("@AgencyCode", OleDbType.VarChar, 100);
                oledbParam[61].Value = AgencyCode;

                oledbParam[62] = new OleDbParameter("@DateOfVerification", OleDbType.VarChar, 50);
                oledbParam[62].Value = DateOfVerification;

                oledbParam[63] = new OleDbParameter("@UnsatisfactoryReason", OleDbType.VarChar, 255);
                oledbParam[63].Value = UnsatisfactoryReason;

                oledbParam[64] = new OleDbParameter("@MonthofStayatResidenceNeigh1", OleDbType.VarChar, 50);
                oledbParam[64].Value = MonthofStayatResidenceNeigh1;

                oledbParam[65] = new OleDbParameter("@MonthofStayatResidenceNeigh2", OleDbType.VarChar, 50);
                oledbParam[65].Value = MonthofStayatResidenceNeigh2;

                oledbParam[66] = new OleDbParameter("@AddedBy1", OleDbType.VarChar, 50);
                oledbParam[66].Value = AddedBy1;

                oledbParam[67] = new OleDbParameter("@AddedOn1", OleDbType.DBTimeStamp);
                oledbParam[67].Value = AddedOn1;

                oledbParam[68] = new OleDbParameter("@SeparateBathroom", OleDbType.VarChar, 15);
                oledbParam[68].Value = SeparateBathroom;
                
                oledbParam[69] = new OleDbParameter("@FamilySeen", OleDbType.VarChar, 15);
                oledbParam[69].Value = FamilySeen;
                
                oledbParam[70] = new OleDbParameter("@SupervisorComment", OleDbType.VarChar, 250);
                oledbParam[70].Value = SupervisorComment;

                oledbParam[71] = new OleDbParameter("@RoofType", OleDbType.VarChar, 50);
                oledbParam[71].Value = RoofType;

                msg = "Record Added Successfully";
                
            }
            else
            {

                sql = "Update CPV_RL_VERIVICATION_RESBUSI set Name_Neighbour1=?,Address_Neighbour1=?," +
                       " Neighbour1_confirmation=?,Month_at_office=?,Market_Reputation_Neighbour1=?,Office_self_owned1=?,Comments_Neighbour1=?," +
                       " Name_Neighbour2=?,Address_Neighbour2=?,Neighbour1_confirmation2=?,Month_at_office1=?,Market_Reputation_Neighbour2=?," +
                       " Office_self_owned2=?,Comments_Neighbour2=?,Locality=?,Landmark=?,Type_Business_Activity=?,Level_Business_Activity=?," +
                       " Stock_Seen=?,NO_EMP_SEEN=?,Accessibility=?,Entrance_Motorable=?,Clear_demarcation_RES_OFFICE=?,Internal_condition=?," +
                       " External_Condition=?,Name_Plate_Sighted_Resi=?,Entry_permitted_Resi=?,Approx_Area_Resi=?,Asset_Seen=?,Person_contacted=?,Relationship=?," +
                       " Identity_proof_seen=?,Business_proof_seen=?,Nature_Business=?,Type_Organization=?,Status_Residence=?,Months_work_current_office=?," +
                       " Months_stay_residencE=?,Applicant_Income=?,Other_sources_income=?,previous_occupation=?,FATHER_Spouse_Name=?,MOTHER_NAME=?,Marital_Status=?," +
                       " No_of_dependents=?,Other_Investments=?,other_loans_TAKEN=?,Purpose_Loan=?,behaviour_person_contacted=?,Education_Background=?,Verifier_Comments=?," +
                       " Colour_Door=?,Proof_Business_Acitivity=?,Overall_Verification=?,Verification_status=?,Office_Name=?,Name_Plate_Sighted_Office=?,Entry_permitted_Office=?, " +
                       " Approx_Area_Office=?,Agency_Code=?,VERIFICATION_DATETIME=?,Unsatisfactory_Reason=?,Month_Stay_Resi_Neigh1=?,Month_Stay_Resi_Neigh2=? ,MODIFY_BY=?,MODIFY_DATE=?, "+
                       " SEP_BATHROOM_SEEN=?,FAMILY_SEEN=?,SUPERVISOR_COMMENTS=?,Roof_Type=? " +
                       " where case_id=? and verification_type_id=? ";
               

                
                oledbParam[0] = new OleDbParameter("@NameOfNeighbour1", OleDbType.VarChar, 100);
                oledbParam[0].Value = NameOfNeighbour1;

                oledbParam[1] = new OleDbParameter("@AddressOfNeighbour1", OleDbType.VarChar, 100);
                oledbParam[1].Value = AddressOfNeighbour1;

                oledbParam[2] = new OleDbParameter("@DoestheApplicantWorkHere1", OleDbType.VarChar, 50);
                oledbParam[2].Value = DoestheApplicantWorkHere1;

                oledbParam[3] = new OleDbParameter("@MonthsOfWorkAtOffice1", OleDbType.VarChar, 50);
                oledbParam[3].Value = MonthsOfWorkAtOffice1;

                oledbParam[4] = new OleDbParameter("@MarketReputation1", OleDbType.VarChar, 100);
                oledbParam[4].Value = MarketReputation1;

                oledbParam[5] = new OleDbParameter("@IstheOfficeSelfOwned1", OleDbType.VarChar, 50);
                oledbParam[5].Value = IstheOfficeSelfOwned1;

                oledbParam[6] = new OleDbParameter("@CommentsOfNeighbour1", OleDbType.VarChar, 750);
                oledbParam[6].Value = CommentsOfNeighbour1;

                oledbParam[7] = new OleDbParameter("@NameOfNeighbour2", OleDbType.VarChar, 100);
                oledbParam[7].Value = NameOfNeighbour2;

                oledbParam[8] = new OleDbParameter("@AddressOfNeighbour2", OleDbType.VarChar, 100);
                oledbParam[8].Value = AddressOfNeighbour2;

                oledbParam[9] = new OleDbParameter("@DoestheApplicantWorkHere2", OleDbType.VarChar, 50);
                oledbParam[9].Value = DoestheApplicantWorkHere2;

                oledbParam[10] = new OleDbParameter("@MonthsOfWorkAtOffice2", OleDbType.VarChar, 50);
                oledbParam[10].Value = MonthsOfWorkAtOffice2;

                oledbParam[11] = new OleDbParameter("@MarketReputation2", OleDbType.VarChar, 100);
                oledbParam[11].Value = MarketReputation2;

                oledbParam[12] = new OleDbParameter("@IstheOfficeSelfOwned2", OleDbType.VarChar, 50);
                oledbParam[12].Value = IstheOfficeSelfOwned2;

                oledbParam[13] = new OleDbParameter("@CommentsOfNeighbour2", OleDbType.VarChar, 750);
                oledbParam[13].Value = CommentsOfNeighbour2;

                oledbParam[14] = new OleDbParameter("@LocalitySurroundings", OleDbType.VarChar, 100);
                oledbParam[14].Value = LocalitySurroundings;

                oledbParam[15] = new OleDbParameter("@Landmark", OleDbType.VarChar, 100);
                oledbParam[15].Value = Landmark;

                oledbParam[16] = new OleDbParameter("@TypeOfBusinessActivity", OleDbType.VarChar, 100);
                oledbParam[16].Value = TypeOfBusinessActivity;

                oledbParam[17] = new OleDbParameter("@LevelOfBusinessActivity", OleDbType.VarChar, 100);
                oledbParam[17].Value = LevelOfBusinessActivity;

                oledbParam[18] = new OleDbParameter("@StockSeen", OleDbType.VarChar, 200);
                oledbParam[18].Value = StockSeen;

                oledbParam[19] = new OleDbParameter("@NoOfEmployeesSeen", OleDbType.VarChar, 50);
                oledbParam[19].Value = NoOfEmployeesSeen;

                oledbParam[20] = new OleDbParameter("@Accessibility", OleDbType.VarChar, 100);
                oledbParam[20].Value = Accessibility;

                oledbParam[21] = new OleDbParameter("@EntranceMotorable", OleDbType.VarChar, 100);
                oledbParam[21].Value = EntranceMotorable;

                oledbParam[22] = new OleDbParameter("@ClearDemarcationBetweenResidenceAndOffice", OleDbType.VarChar, 100);
                oledbParam[22].Value = ClearDemarcationBetweenResidenceAndOffice;

                oledbParam[23] = new OleDbParameter("@InternalCondition", OleDbType.VarChar, 100);
                oledbParam[23].Value = InternalCondition;

                oledbParam[24] = new OleDbParameter("@ExternalCondition", OleDbType.VarChar, 100);
                oledbParam[24].Value = ExternalCondition;

                oledbParam[25] = new OleDbParameter("@NamePlateSightedResi", OleDbType.VarChar, 50);
                oledbParam[25].Value = NamePlateSightedResi;

                oledbParam[26] = new OleDbParameter("@EntryPermittedResi", OleDbType.VarChar, 50);
                oledbParam[26].Value = EntryPermittedResi;

                oledbParam[27] = new OleDbParameter("@ApproxAreaResi", OleDbType.VarChar, 50);
                oledbParam[27].Value = ApproxAreaResi;

                oledbParam[28] = new OleDbParameter("@AssetSeen", OleDbType.VarChar, 200);
                oledbParam[28].Value = AssetSeen;

                oledbParam[29] = new OleDbParameter("@NameOfPersonContacted", OleDbType.VarChar, 100);
                oledbParam[29].Value = NameOfPersonContacted;

                oledbParam[30] = new OleDbParameter("@RelationshipWithApplicant", OleDbType.VarChar, 50);
                oledbParam[30].Value = RelationshipWithApplicant;

                oledbParam[31] = new OleDbParameter("@IdentityProofSeen", OleDbType.VarChar, 50);
                oledbParam[31].Value = IdentityProofSeen;

                oledbParam[32] = new OleDbParameter("@BusinessProofSeen", OleDbType.VarChar, 50);
                oledbParam[32].Value = BusinessProofSeen;

                oledbParam[33] = new OleDbParameter("@NatureOfBusiness", OleDbType.VarChar, 50);
                oledbParam[33].Value = NatureOfBusiness;

                oledbParam[34] = new OleDbParameter("@TypeOfOrganization", OleDbType.VarChar, 50);
                oledbParam[34].Value = TypeOfOrganization;


                oledbParam[35] = new OleDbParameter("@StatusOfResidence", OleDbType.VarChar, 50);
                oledbParam[35].Value = StatusOfResidence;

                oledbParam[36] = new OleDbParameter("@MonthsOfWorkAtCurrentOffice", OleDbType.VarChar, 50);
                oledbParam[36].Value = MonthsOfWorkAtCurrentOffice;

                oledbParam[37] = new OleDbParameter("@MonthsOfStayAtResidence", OleDbType.VarChar, 50);
                oledbParam[37].Value = MonthsOfStayAtResidence;

                oledbParam[38] = new OleDbParameter("@ApplicantsIncome", OleDbType.VarChar, 50);
                oledbParam[38].Value = ApplicantsIncome;

                oledbParam[39] = new OleDbParameter("@OtherSourceOfIncome", OleDbType.VarChar, 50);
                oledbParam[39].Value = OtherSourceOfIncome;

                oledbParam[40] = new OleDbParameter("@VerificationTypeID", OleDbType.VarChar, 100);
                oledbParam[40].Value = DetailsOfPreviousOccupation;

                oledbParam[41] = new OleDbParameter("@FatherOrSpousesName", OleDbType.VarChar, 100);
                oledbParam[41].Value = FatherOrSpousesName;

                oledbParam[42] = new OleDbParameter("@MothersName", OleDbType.VarChar, 100);
                oledbParam[42].Value = MothersName;

                oledbParam[43] = new OleDbParameter("@MaritalStatus", OleDbType.VarChar, 30);
                oledbParam[43].Value = MaritalStatus;

                oledbParam[44] = new OleDbParameter("@NoOfDependents", OleDbType.VarChar, 50);
                oledbParam[44].Value = NoOfDependents;

                oledbParam[45] = new OleDbParameter("@VerificationTypeID", OleDbType.VarChar, 100);
                oledbParam[45].Value = OtherInvestments;

                oledbParam[46] = new OleDbParameter("@AnyOtherLoansBeingTaken", OleDbType.VarChar, 50);
                oledbParam[46].Value = AnyOtherLoansBeingTaken;

                oledbParam[47] = new OleDbParameter("@PurposeOfLoanBeingTaken", OleDbType.VarChar, 50);
                oledbParam[47].Value = PurposeOfLoanBeingTaken;

                oledbParam[48] = new OleDbParameter("@BehaviourOfPersonContacted", OleDbType.VarChar, 50);
                oledbParam[48].Value = BehaviourOfPersonContacted;

                oledbParam[49] = new OleDbParameter("@EducationBackground", OleDbType.VarChar, 100);
                oledbParam[49].Value = EducationBackground;

                oledbParam[50] = new OleDbParameter("@VerifiersComments", OleDbType.VarChar, 750);
                oledbParam[50].Value = VerifiersComments;

                oledbParam[51] = new OleDbParameter("@ColourOfDoor", OleDbType.VarChar, 50);
                oledbParam[51].Value = ColourOfDoor;

                oledbParam[52] = new OleDbParameter("@ProofOfBusinessActivity", OleDbType.VarChar, 50);
                oledbParam[52].Value = ProofOfBusinessActivity;

                oledbParam[53] = new OleDbParameter("@OverallVerification", OleDbType.VarChar, 255);
                oledbParam[53].Value = OverallVerification;

                oledbParam[54] = new OleDbParameter("@Rating", OleDbType.VarChar, 50);
                if (Rating == "")
                {
                    oledbParam[54].Value = DBNull.Value;

                }
                else
                {
                    oledbParam[54].Value = Rating;
                }

                oledbParam[55] = new OleDbParameter("@OfficeName", OleDbType.VarChar, 100);
                oledbParam[55].Value = OfficeName;

                oledbParam[56] = new OleDbParameter("@NamePlateSightedOffice", OleDbType.VarChar, 50);
                oledbParam[56].Value = NamePlateSightedOffice;

                oledbParam[57] = new OleDbParameter("@EntryPermittedOffice", OleDbType.VarChar, 50);
                oledbParam[57].Value = EntryPermittedOffice;

                oledbParam[58] = new OleDbParameter("@ApproxAreaOffice", OleDbType.VarChar, 50);
                oledbParam[58].Value = ApproxAreaOffice;

                oledbParam[59] = new OleDbParameter("@AgencyCode", OleDbType.VarChar, 100);
                oledbParam[59].Value = AgencyCode;


                oledbParam[60] = new OleDbParameter("@DateOfVerification", OleDbType.VarChar, 50);
                oledbParam[60].Value = DateOfVerification;

                oledbParam[61] = new OleDbParameter("@UnsatisfactoryReason", OleDbType.VarChar, 255);
                oledbParam[61].Value = UnsatisfactoryReason;

                oledbParam[62] = new OleDbParameter("@MonthofStayatResidenceNeigh1", OleDbType.VarChar, 50);
                oledbParam[62].Value = MonthofStayatResidenceNeigh1;

                oledbParam[63] = new OleDbParameter("@MonthofStayatResidenceNeigh2", OleDbType.VarChar, 50);
                oledbParam[63].Value = MonthofStayatResidenceNeigh2;

                oledbParam[64] = new OleDbParameter("@UpdatedBy1", OleDbType.VarChar, 50);
                oledbParam[64].Value = UpdatedBy1;

                oledbParam[65] = new OleDbParameter("@UpdatedOn1", OleDbType.DBTimeStamp);
                oledbParam[65].Value = UpdatedOn1;

                oledbParam[66] = new OleDbParameter("@SeparateBathroom", OleDbType.VarChar, 15);
                oledbParam[66].Value = SeparateBathroom;

                oledbParam[67] = new OleDbParameter("@FamilySeen", OleDbType.VarChar, 15);
                oledbParam[67].Value = FamilySeen;

                oledbParam[68] = new OleDbParameter("@SupervisorComment", OleDbType.VarChar, 250);
                oledbParam[68].Value = SupervisorComment;

                oledbParam[69] = new OleDbParameter("@RoofType", OleDbType.VarChar, 50);
                oledbParam[69].Value = RoofType;

                oledbParam[70] = new OleDbParameter("@CaseID", OleDbType.VarChar, 15);
                oledbParam[70].Value = CaseID;

                oledbParam[71] = new OleDbParameter("@VerificationTypeID", OleDbType.VarChar, 15);
                oledbParam[71].Value = VerificationTypeID;


                msg = "Record Updated Successfully";
            }
            OleDbHelper.ExecuteNonQuery(oledbTrans, CommandType.Text, sql, oledbParam);


            OleDbParameter[] oledbParamCaseDetail = new OleDbParameter[2];

            sqlQuery = "Update CPV_RL_CASE_DETAILS set  DOB=?   " +
                       " where CASE_ID=? ";

            oledbParamCaseDetail[0] = new OleDbParameter("@DOB", OleDbType.VarChar, 100);
            oledbParamCaseDetail[0].Value = DOB;       

            oledbParamCaseDetail[1] = new OleDbParameter("@CaseID", OleDbType.VarChar, 15);
            oledbParamCaseDetail[1].Value = CaseID;

            OleDbHelper.ExecuteNonQuery(oledbTrans, CommandType.Text, sqlQuery, oledbParamCaseDetail);

            //msg = "Record Updated Sucessfully";

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

    public OleDbDataReader GetResiCumBusiness(string sCaseID, string sVerificationTypeID)
    {
        string sSql = "";
        

        sSql = "Select Name_Neighbour1,Address_Neighbour1," +
               " Neighbour1_confirmation,Month_at_office,Market_Reputation_Neighbour1,Office_self_owned1,Comments_Neighbour1," +
               " Name_Neighbour2,Address_Neighbour2,Neighbour1_confirmation2,Month_at_office1,Market_Reputation_Neighbour2," +
               " Office_self_owned2,Comments_Neighbour2,Locality,Landmark,Type_Business_Activity,Level_Business_Activity," +
               " Stock_Seen,NO_EMP_SEEN,Accessibility,Entrance_Motorable,Clear_demarcation_RES_OFFICE,Internal_condition," +
               " External_Condition,Name_Plate_Sighted_Resi,Entry_permitted_Resi,Approx_Area_Resi,Asset_Seen,Person_contacted,Relationship," +
               " Identity_proof_seen,Business_proof_seen,Nature_Business,Type_Organization,Status_Residence,Months_work_current_office," +
               " Months_stay_residencE,Applicant_Income,Other_sources_income,previous_occupation,FATHER_Spouse_Name,MOTHER_NAME,Marital_Status," +
               " No_of_dependents,Other_Investments,other_loans_TAKEN,Purpose_Loan,behaviour_person_contacted,Education_Background,Verifier_Comments," +
               " Colour_Door,Proof_Business_Acitivity,Overall_Verification,Verification_status,Office_Name,Name_Plate_Sighted_Office,Entry_permitted_Office," +
               " Approx_Area_Office,Agency_Code,VERIFICATION_DATETIME,Unsatisfactory_Reason, " +
               " SEP_BATHROOM_SEEN,FAMILY_SEEN,SUPERVISOR_COMMENTS,ROOF_TYPE, "+
               " Month_Stay_Resi_Neigh1,Month_Stay_Resi_Neigh2  from CPV_RL_VERIVICATION_RESBUSI  " +
               " where case_id='" + sCaseID + "'" + "and verification_type_id='" + sVerificationTypeID + "'";
        return OleDbHelper.ExecuteReader(objCon.ConnectionString, CommandType.Text, sSql);
    }

    public OleDbDataReader GetCaseDetail(string sCaseId)
    {
        string sSql = "";
        sSql = "SELECT REF_NO,(isNull(FIRST_NAME,'')+' '+isnull(MIDDLE_NAME,'')+' '+isnull(LAST_NAME,'')) as FULL_NAME," +
                " (isNull(RES_ADD_LINE_1,'')+' '+isnull(RES_ADD_LINE_2,'')+' '+isnull(RES_ADD_LINE_3,'')) as Applicant_Address,DOB  " +
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

    public OleDbDataReader GetFEID(string sCaseID)
    {
        string sSql = "";
        sSql = "SELECT VW.FULLNAME,CMAP.FE_ID from FE_VW AS VW INNER JOIN  CPV_RL_CASE_FE_MAPPING AS CMAP ON (VW.EMP_ID=CMAP.FE_ID) WHERE CMAP.CASE_ID='" + sCaseID + "'";
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
