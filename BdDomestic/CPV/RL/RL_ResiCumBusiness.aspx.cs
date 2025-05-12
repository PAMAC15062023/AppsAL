using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.OleDb;

public partial class CPV_RL_RL_ResiCumBusiness : System.Web.UI.Page
{
    CGet objCGet = new CGet();
    CRL_ResiCumBusiness objResiCumBusi = new CRL_ResiCumBusiness();
    CCommon objComm = new CCommon();
    string verificationType = "RCO";
    protected void Page_Init(object sender, EventArgs e)
    {
        funShowPanel();
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //To Show the Panels add By Manoj            
            funShowPanel();

            hdnTransStart.Value = DateTime.Now.ToString();//"dd/MM/yyyy hh:mm:ss tt");

            if ((Request.QueryString["CaseID"] != null) && (Request.QueryString["CaseID"] != ""))
            {
                if (Session["isEdit"].ToString() != "1")
                {
                   
                    
                }
               
                hidCaseID.Value = Request.QueryString["CaseID"].ToString();
                Session["CaseID"] = hidCaseID.Value;

            }
            if ((Request.QueryString["VerTypeId"] != null) && (Request.QueryString["VerTypeId"] != ""))
            {
                hidVerificationTypeID.Value = Request.QueryString["VerTypeId"].ToString();
            }
            if ((Request.QueryString["Mode"] != null) && (Request.QueryString["Mode"] != ""))
            {
                hidMode.Value = Request.QueryString["Mode"].ToString();
            }
            if ((Request.QueryString["VerificationTypeCode"] != null) && (Request.QueryString["VerificationTypeCode"] != ""))
            {
                hidVerificationTypeCode.Value = Request.QueryString["VerificationTypeCode"].ToString();
            }
            //FillSupervisorName();
            GetResiCumBusiVerification();
            FillRatingStatus();
            GetResiCumBusiCaseDetail();
            GetFeId();
            if (hidMode.Value == "View")
            {
                IfIsEditFalse();
                LikButtonVisibility();


            }
          
        }

    }
    private void PropertySet()
    {
        objResiCumBusi.CaseID = hidCaseID.Value.ToString();
        objResiCumBusi.VerificationTypeID = hidVerificationTypeID.Value.ToString();
        objResiCumBusi.NameOfNeighbour1 = txtNameOfNeighbour1.Text.Trim().ToString();
        objResiCumBusi.AddressOfNeighbour1 = txtAddressOfNeighbour1.Text.Trim().ToString();
        objResiCumBusi.DoestheApplicantWorkHere1 = ddlDoesTheApplicantWorkHere1.SelectedValue.ToString();
        objResiCumBusi.MonthsOfWorkAtOffice1 = txtMonthsOfWorkAtOffice1.Text.Trim().ToString();
        objResiCumBusi.MarketReputation1 = ddlMarketReputation1.SelectedValue.ToString();
        objResiCumBusi.IstheOfficeSelfOwned1 = ddlIsTheOfficeSelfOwned1.SelectedValue.ToString();
        objResiCumBusi.CommentsOfNeighbour1 = txtCommentsOfNeighbour1.Text.Trim().ToString();

        objResiCumBusi.NameOfNeighbour2 = txtNameOfNeighbour2.Text.Trim().ToString();
        objResiCumBusi.AddressOfNeighbour2 = txtAddressOfNeighbour2.Text.Trim().ToString();
        objResiCumBusi.DoestheApplicantWorkHere2 = ddlDoestheApplicantWorkHere2.SelectedValue.ToString();
        objResiCumBusi.MonthsOfWorkAtOffice2 = txtMonthsofWorkatOffice2.Text.Trim().ToString();
        objResiCumBusi.MarketReputation2 = ddlMarketReputation2.SelectedValue.ToString();
        objResiCumBusi.IstheOfficeSelfOwned2 = ddlIstheOfficeselfowned2.SelectedValue.ToString();
        objResiCumBusi.CommentsOfNeighbour2 = txtCommentsofNeighbour2.Text.Trim().ToString();

        //objResiCumBusi.LocalitySurroundings = ddlLocalityOrSurroundings.SelectedValue.ToString();
        if (ddlLocalityOrSurroundings.SelectedValue.ToString() == "Others")
            objResiCumBusi.LocalitySurroundings = "Others" + "+" + txtOtherLocality.Text.Trim();
        else
            objResiCumBusi.LocalitySurroundings = ddlLocalityOrSurroundings.SelectedValue.ToString();
        objResiCumBusi.Landmark = txtLandMark.Text.Trim().ToString();
        objResiCumBusi.TypeOfBusinessActivity = txtTypeOfBusinessActivity.Text.Trim().ToString();
        objResiCumBusi.LevelOfBusinessActivity = ddlLevelOfBusinessActivity.SelectedValue.ToString();
        objResiCumBusi.StockSeen = ddlStockSeen.SelectedValue.ToString();
        objResiCumBusi.NoOfEmployeesSeen = txtNoOfEmployeesSeen.Text.Trim().ToString();
        objResiCumBusi.Accessibility = ddlAccessibility.SelectedValue.ToString();
        objResiCumBusi.EntranceMotorable = ddlEntranceMotorable.SelectedValue.ToString();
        objResiCumBusi.ClearDemarcationBetweenResidenceAndOffice = ddlClearDemarcationBetweenResidenceAndOffice.SelectedValue.ToString();
        objResiCumBusi.InternalCondition = ddlInternalCondition.SelectedValue.ToString();
        objResiCumBusi.ExternalCondition = ddlExternalCondition.SelectedValue.ToString();
        objResiCumBusi.NamePlateSightedResi = ddlNamePlateSightedResi.SelectedValue.ToString();
        objResiCumBusi.EntryPermittedResi = ddlEntryPermittedResi.SelectedValue.ToString();
        objResiCumBusi.ApproxAreaResi = txtApproxAreaResi.Text.Trim().ToString();
        objResiCumBusi.NamePlateSightedOffice = ddlNamePlateSightedOffice.SelectedValue.ToString();
        objResiCumBusi.EntryPermittedOffice = ddlEntryPermittedOffice.SelectedValue.ToString();
        objResiCumBusi.ApproxAreaOffice = txtApproxAreaOffice.Text.Trim().ToString();
        objResiCumBusi.OfficeName = txtOfficeName.Text.Trim().ToString();
        //objResiCumBusi.AssetSeen = ddlAssetSeen.SelectedValue.ToString();

        string sAssets = "";
        if (chkAssetSeen.Items.Count > 0)
        {
            foreach (ListItem li in chkAssetSeen.Items)
            {
                if (li.Text.Trim() == "Other" && li.Selected == true)
                    sAssets += li.Value + "," + txtOtherAssetSeen.Text.Trim();
                else
                    if (li.Selected == true)
                        sAssets += li.Value + ",";
            }
        }

        objResiCumBusi.AssetSeen = sAssets.TrimEnd(',');   
        objResiCumBusi.NameOfPersonContacted = txtNameOfPersonContacted.Text.Trim().ToString();
        objResiCumBusi.RelationshipWithApplicant = txtRelationshipWithApplicant.Text.Trim().ToString();
        objResiCumBusi.IdentityProofSeen = ddlIdentityProofSeen.SelectedValue.ToString();
        objResiCumBusi.BusinessProofSeen = ddlBusinessProofSeen.SelectedValue.ToString();
        objResiCumBusi.NatureOfBusiness = txtNatureofBusiness.Text.Trim().ToString();
        objResiCumBusi.TypeOfOrganization = ddlTypeOfOrganization.SelectedValue.ToString();
        objResiCumBusi.StatusOfResidence = ddlStatusOfResidence.SelectedValue.ToString();
        objResiCumBusi.MonthsOfWorkAtCurrentOffice = txtMonthsOfWorkatCurrentOffice.Text.Trim().ToString();
        objResiCumBusi.MonthsOfStayAtResidence = txtMonthsOfStayatResidence.Text.Trim().ToString();
        objResiCumBusi.ApplicantsIncome = txtApplicantIncome.Text.Trim().ToString();
        objResiCumBusi.OtherSourceOfIncome = txtOtherSourceOfIncome.Text.Trim().ToString();
        objResiCumBusi.DetailsOfPreviousOccupation = txtDetailOfPreviousOccupation.Text.Trim().ToString();
        objResiCumBusi.FatherOrSpousesName = txtFatherOrSpouseName.Text.Trim().ToString();
        objResiCumBusi.MothersName = txtMotherName.Text.Trim().ToString();
        objResiCumBusi.MaritalStatus = ddlMaritalStatus.SelectedValue.ToString();
        objResiCumBusi.NoOfDependents = txtNoOfDependents.Text.Trim().ToString();
        objResiCumBusi.OtherInvestments = txtOtherInvestments.Text.Trim().ToString();
        objResiCumBusi.AnyOtherLoansBeingTaken = txtAnyOtherLoansBeingTaken.Text.Trim().ToString();
        objResiCumBusi.PurposeOfLoanBeingTaken = txtPurposeOfLoanBeingTaken.Text.Trim().ToString();
        objResiCumBusi.BehaviourOfPersonContacted = ddlBehaviourOfPersonContacted.SelectedValue.ToString();
        objResiCumBusi.EducationBackground = ddlEducationBackground.SelectedValue.ToString();
        objResiCumBusi.VerifiersComments = txtVerifierComments.Text.Trim().ToString();
        objResiCumBusi.ColourOfDoor = txtColourOfDoor.Text.Trim().ToString();
        objResiCumBusi.ProofOfBusinessActivity = txtProofOfBusinessAcitivity.Text.Trim().ToString();
        objResiCumBusi.OverallVerification = ddlOverallVerification.SelectedValue.ToString();
        objResiCumBusi.Rating = ddlRating.SelectedValue.ToString();
        objResiCumBusi.DOB = txtAgeOfApplicant.Text.Trim().ToString();
        objResiCumBusi.AgencyCode = txtVerificationAgency.Text.Trim().ToString();
        if ((txtDateOfVerification.Text != string.Empty) && (txtVerificationTime.Text != string.Empty))
        {
            objResiCumBusi.DateOfVerification = objComm.strDate(txtDateOfVerification.Text.Trim()) + " " + txtVerificationTime.Text.Trim() + " " + ddlVerificationTimeType.SelectedValue.Trim();

        }
        if (ddlRating.SelectedItem.Text == "UnSatisfactory")
        {
            objResiCumBusi.UnsatisfactoryReason = txtProvidereasonforunsatisfactoryrating.Text.Trim().ToString();
        }
        else
        {
            objResiCumBusi.UnsatisfactoryReason = "";
        }

        objResiCumBusi.MonthofStayatResidenceNeigh1 = txtMonthofStayatResidenceNeigh1.Text.Trim().ToString();
        objResiCumBusi.MonthofStayatResidenceNeigh2 = txtMonthofStayatResidenceNeigh2.Text.Trim().ToString();


        objResiCumBusi.AddedBy1  = Session["UserId"].ToString();
        objResiCumBusi.AddedOn1 = DateTime.Now;
        objResiCumBusi.UpdatedBy1 = Session["UserId"].ToString();
        objResiCumBusi.UpdatedOn1 = DateTime.Now;


        //Added by hemangi kambli on 01/10/2007 
        if (hdnTransStart.Value != "")
            objResiCumBusi.TransStart = Convert.ToDateTime(hdnTransStart.Value);
        objResiCumBusi.TransEnd = Convert.ToDateTime(DateTime.Now.ToString());//"dd/MM/yyyy hh:mm:ss tt"));
        objResiCumBusi.CentreId = Session["CentreId"].ToString();
        objResiCumBusi.ProductId = Session["ProductId"].ToString();
        objResiCumBusi.ClientId = Session["ClientId"].ToString();
        objResiCumBusi.UserId = Session["UserId"].ToString();
        ///------------------------------------------------------
        //Added by hemangi kambli on 03/10/2007 
        objResiCumBusi.SeparateBathroom = ddlSepBathroom.SelectedValue.ToString();
        objResiCumBusi.FamilySeen = ddlFamilySeen.SelectedValue.ToString();
        objResiCumBusi.SupervisorComment = txtSupervisorComments.Text.Trim();
        objResiCumBusi.RoofType = ddlRoofType.SelectedValue.ToString();
        //---------------------------------------------
    }

    private void GetResiCumBusiVerification()
    {
        OleDbDataReader oledbDR;
        oledbDR = objResiCumBusi.GetResiCumBusiness(hidCaseID.Value, hidVerificationTypeID.Value);
        if (oledbDR.Read())
        {
            if (!(oledbDR["Name_Neighbour1"].ToString().Trim().Length.Equals(0)))
                txtNameOfNeighbour1.Text = oledbDR["Name_Neighbour1"].ToString();

            if (!(oledbDR["Address_Neighbour1"].ToString().Trim().Length.Equals(0)))
                txtAddressOfNeighbour1.Text = oledbDR["Address_Neighbour1"].ToString();

            if (!(oledbDR["Neighbour1_confirmation"].ToString().Trim().Length.Equals(0)))
                ddlDoesTheApplicantWorkHere1.SelectedValue = oledbDR["Neighbour1_confirmation"].ToString();

            if (!(oledbDR["Month_at_office"].ToString().Trim().Length.Equals(0)))
                txtMonthsOfWorkAtOffice1.Text = oledbDR["Month_at_office"].ToString();

            if (!(oledbDR["Market_Reputation_Neighbour1"].ToString().Trim().Length.Equals(0)))
                ddlMarketReputation1.SelectedValue = oledbDR["Market_Reputation_Neighbour1"].ToString();

            if (!(oledbDR["Office_self_owned1"].ToString().Trim().Length.Equals(0)))
                ddlIsTheOfficeSelfOwned1.SelectedValue = oledbDR["Office_self_owned1"].ToString();

            if (!(oledbDR["Comments_Neighbour1"].ToString().Trim().Length.Equals(0)))
                txtCommentsOfNeighbour1.Text = oledbDR["Comments_Neighbour1"].ToString();

            if (!(oledbDR["Name_Neighbour2"].ToString().Trim().Length.Equals(0)))
                txtNameOfNeighbour2.Text = oledbDR["Name_Neighbour2"].ToString();

            if (!(oledbDR["Address_Neighbour2"].ToString().Trim().Length.Equals(0)))
                txtAddressOfNeighbour2.Text = oledbDR["Address_Neighbour2"].ToString();

            if (!(oledbDR["Neighbour1_confirmation2"].ToString().Trim().Length.Equals(0)))
                ddlDoestheApplicantWorkHere2.SelectedValue = oledbDR["Neighbour1_confirmation2"].ToString();

            if (!(oledbDR["Month_at_office1"].ToString().Trim().Length.Equals(0)))
                txtMonthsofWorkatOffice2.Text = oledbDR["Month_at_office1"].ToString();

            if (!(oledbDR["Market_Reputation_Neighbour2"].ToString().Trim().Length.Equals(0)))
                ddlMarketReputation2.SelectedValue = oledbDR["Market_Reputation_Neighbour2"].ToString();

            if (!(oledbDR["Office_self_owned2"].ToString().Trim().Length.Equals(0)))
                ddlIstheOfficeselfowned2.SelectedValue = oledbDR["Office_self_owned2"].ToString();

            if (!(oledbDR["Comments_Neighbour2"].ToString().Trim().Length.Equals(0)))
                txtCommentsofNeighbour2.Text = oledbDR["Comments_Neighbour2"].ToString();

            //if (!(oledbDR["Locality"].ToString().Trim().Length.Equals(0)))
            //    ddlLocalityOrSurroundings.SelectedValue = oledbDR["Locality"].ToString();

            string sLocality = oledbDR["Locality"].ToString();
            if (sLocality.Trim() != "")
            {
                string[] arrLocality = sLocality.Split('+');
                if (arrLocality.Length > 0)
                {
                    if (arrLocality[0].ToString() == "Others" && arrLocality.Length > 1)
                    {
                        ddlLocalityOrSurroundings.SelectedValue = "Others";
                        txtOtherLocality.Text = arrLocality[1].ToString();
                    }
                    else
                    {
                        ddlLocalityOrSurroundings.SelectedValue = arrLocality[0].ToString();
                    }
                }
            }

            if (!(oledbDR["Landmark"].ToString().Trim().Length.Equals(0)))
                txtLandMark.Text = oledbDR["Landmark"].ToString();

            if (!(oledbDR["Type_Business_Activity"].ToString().Trim().Length.Equals(0)))
                txtTypeOfBusinessActivity.Text = oledbDR["Type_Business_Activity"].ToString();

            if (!(oledbDR["Level_Business_Activity"].ToString().Trim().Length.Equals(0)))
                ddlLevelOfBusinessActivity.SelectedValue = oledbDR["Level_Business_Activity"].ToString();

            if (!(oledbDR["Stock_Seen"].ToString().Trim().Length.Equals(0)))
                ddlStockSeen.SelectedValue = oledbDR["Stock_Seen"].ToString();

            if (!(oledbDR["NO_EMP_SEEN"].ToString().Trim().Length.Equals(0)))
                txtNoOfEmployeesSeen.Text = oledbDR["NO_EMP_SEEN"].ToString();

            if (!(oledbDR["Accessibility"].ToString().Trim().Length.Equals(0)))
                ddlAccessibility.SelectedValue = oledbDR["Accessibility"].ToString();

            if (!(oledbDR["Entrance_Motorable"].ToString().Trim().Length.Equals(0)))
                ddlEntranceMotorable.SelectedValue = oledbDR["Entrance_Motorable"].ToString();

            if (!(oledbDR["Clear_demarcation_RES_OFFICE"].ToString().Trim().Length.Equals(0)))
                ddlClearDemarcationBetweenResidenceAndOffice.SelectedValue = oledbDR["Clear_demarcation_RES_OFFICE"].ToString();

            if (!(oledbDR["Internal_condition"].ToString().Trim().Length.Equals(0)))
                ddlInternalCondition.SelectedValue = oledbDR["Internal_condition"].ToString();

            if (!(oledbDR["External_Condition"].ToString().Trim().Length.Equals(0)))
                ddlExternalCondition.SelectedValue = oledbDR["External_Condition"].ToString();

            if (!(oledbDR["Name_Plate_Sighted_Resi"].ToString().Trim().Length.Equals(0)))
                ddlNamePlateSightedResi.SelectedValue = oledbDR["Name_Plate_Sighted_Resi"].ToString();

            if (!(oledbDR["Entry_permitted_Resi"].ToString().Trim().Length.Equals(0)))
                ddlEntryPermittedResi.SelectedValue = oledbDR["Entry_permitted_Resi"].ToString();

            if (!(oledbDR["Approx_Area_Resi"].ToString().Trim().Length.Equals(0)))
                txtApproxAreaResi.Text = oledbDR["Approx_Area_Resi"].ToString();

            //if (!(oledbDR["Asset_Seen"].ToString().Trim().Length.Equals(0)))
            //    ddlAssetSeen.SelectedValue = oledbDR["Asset_Seen"].ToString();
            ///For Asset Checkboxes---------------------------------------------------
            string sTmpAsset = oledbDR["Asset_Seen"].ToString();
            string[] arrAsset = sTmpAsset.Split(',');
            int iOtherAssetCtr = 0;
            if (arrAsset.Length > 0)
            {
                for (int i = 0; i < arrAsset.Length; i++)
                {
                    foreach (ListItem li in chkAssetSeen.Items)
                    {
                        if (li.Value == arrAsset.GetValue(i).ToString())
                            li.Selected = true;
                        if (arrAsset.GetValue(i).ToString() == "Other")
                        {
                            iOtherAssetCtr = i;
                        }
                    }
                }
            }
            for (int j = iOtherAssetCtr + 1; j < arrAsset.Length; j++)
            {
                txtOtherAssetSeen.Text += arrAsset.GetValue(j) + ",";
            }
            if (!(oledbDR["Person_contacted"].ToString().Trim().Length.Equals(0)))
                txtNameOfPersonContacted.Text = oledbDR["Person_contacted"].ToString();

            if (!(oledbDR["Relationship"].ToString().Trim().Length.Equals(0)))
                txtRelationshipWithApplicant.Text = oledbDR["Relationship"].ToString();

            if (!(oledbDR["Identity_proof_seen"].ToString().Trim().Length.Equals(0)))
                ddlIdentityProofSeen.SelectedValue = oledbDR["Identity_proof_seen"].ToString();

            if (!(oledbDR["Business_proof_seen"].ToString().Trim().Length.Equals(0)))
                ddlBusinessProofSeen.SelectedValue = oledbDR["Business_proof_seen"].ToString();

            if (!(oledbDR["Nature_Business"].ToString().Trim().Length.Equals(0)))
                txtNatureofBusiness.Text = oledbDR["Nature_Business"].ToString();

            if (!(oledbDR["Type_Organization"].ToString().Trim().Length.Equals(0)))
                ddlTypeOfOrganization.SelectedValue = oledbDR["Type_Organization"].ToString();

            if (!(oledbDR["Status_Residence"].ToString().Trim().Length.Equals(0)))
                ddlStatusOfResidence.SelectedValue = oledbDR["Status_Residence"].ToString();

            if (!(oledbDR["Months_work_current_office"].ToString().Trim().Length.Equals(0)))
                txtMonthsOfWorkatCurrentOffice.Text = oledbDR["Months_work_current_office"].ToString();

            if (!(oledbDR["Months_stay_residencE"].ToString().Trim().Length.Equals(0)))
                txtMonthsOfStayatResidence.Text = oledbDR["Months_stay_residencE"].ToString();

            if (!(oledbDR["Applicant_Income"].ToString().Trim().Length.Equals(0)))
                txtApplicantIncome.Text = oledbDR["Applicant_Income"].ToString();

            if (!(oledbDR["Other_sources_income"].ToString().Trim().Length.Equals(0)))
                txtOtherSourceOfIncome.Text = oledbDR["Other_sources_income"].ToString();

            if (!(oledbDR["previous_occupation"].ToString().Trim().Length.Equals(0)))
                txtDetailOfPreviousOccupation.Text = oledbDR["previous_occupation"].ToString();

            if (!(oledbDR["FATHER_Spouse_Name"].ToString().Trim().Length.Equals(0)))
                txtFatherOrSpouseName.Text = oledbDR["FATHER_Spouse_Name"].ToString();

            if (!(oledbDR["MOTHER_NAME"].ToString().Trim().Length.Equals(0)))
                txtMotherName.Text = oledbDR["MOTHER_NAME"].ToString();

            if (!(oledbDR["Marital_Status"].ToString().Trim().Length.Equals(0)))
                ddlMaritalStatus.SelectedValue = oledbDR["Marital_Status"].ToString();

            if (!(oledbDR["No_of_dependents"].ToString().Trim().Length.Equals(0)))
                txtNoOfDependents.Text = oledbDR["No_of_dependents"].ToString();

            if (!(oledbDR["Other_Investments"].ToString().Trim().Length.Equals(0)))
                txtOtherInvestments.Text = oledbDR["Other_Investments"].ToString();

            if (!(oledbDR["other_loans_TAKEN"].ToString().Trim().Length.Equals(0)))
                txtAnyOtherLoansBeingTaken.Text = oledbDR["other_loans_TAKEN"].ToString();

            if (!(oledbDR["Purpose_Loan"].ToString().Trim().Length.Equals(0)))
                txtPurposeOfLoanBeingTaken.Text = oledbDR["Purpose_Loan"].ToString();

            if (!(oledbDR["behaviour_person_contacted"].ToString().Trim().Length.Equals(0)))
                ddlBehaviourOfPersonContacted.SelectedValue = oledbDR["behaviour_person_contacted"].ToString();

            if (!(oledbDR["Education_Background"].ToString().Trim().Length.Equals(0)))
                ddlEducationBackground.SelectedValue = oledbDR["Education_Background"].ToString();

            if (!(oledbDR["Verifier_Comments"].ToString().Trim().Length.Equals(0)))
                txtVerifierComments.Text = oledbDR["Verifier_Comments"].ToString();

            if (!(oledbDR["Colour_Door"].ToString().Trim().Length.Equals(0)))
                txtColourOfDoor.Text = oledbDR["Colour_Door"].ToString();

            if (!(oledbDR["Proof_Business_Acitivity"].ToString().Trim().Length.Equals(0)))
                txtProofOfBusinessAcitivity.Text = oledbDR["Proof_Business_Acitivity"].ToString();

            if (!(oledbDR["Overall_Verification"].ToString().Trim().Length.Equals(0)))
                ddlOverallVerification.SelectedValue = oledbDR["Overall_Verification"].ToString();


            if (!(oledbDR["Verification_status"].ToString().Trim().Length.Equals(0)))
                ddlRating.SelectedValue = oledbDR["Verification_status"].ToString();

            if (!(oledbDR["Office_Name"].ToString().Trim().Length.Equals(0)))
                txtOfficeName.Text = oledbDR["Office_Name"].ToString();

            if (!(oledbDR["Name_Plate_Sighted_Office"].ToString().Trim().Length.Equals(0)))
                ddlNamePlateSightedOffice.SelectedValue = oledbDR["Name_Plate_Sighted_Office"].ToString();

            if (!(oledbDR["Entry_permitted_Office"].ToString().Trim().Length.Equals(0)))
                ddlEntryPermittedOffice.SelectedValue = oledbDR["Entry_permitted_Office"].ToString();

            if (!(oledbDR["Approx_Area_Office"].ToString().Trim().Length.Equals(0)))
                txtApproxAreaOffice.Text = oledbDR["Approx_Area_Office"].ToString();

            if (!(oledbDR["Agency_Code"].ToString().Trim().Length.Equals(0)))
                txtVerificationAgency.Text = oledbDR["Agency_Code"].ToString();

            if (!(oledbDR["VERIFICATION_DATETIME"].ToString().Trim().Length.Equals(0)))
            {

                string sVerification = oledbDR["VERIFICATION_DATETIME"].ToString();
                if (sVerification != string.Empty)
                {
                    string[] sarrayVerification = sVerification.Split(' ');
                    if (sarrayVerification[0].ToString() != "")
                    {
                        txtDateOfVerification.Text = Convert.ToDateTime(sarrayVerification[0].ToString()).ToString("dd/MM/yyyy");
                    }
                    if (sarrayVerification[1].ToString() != "")
                    {
                        txtVerificationTime.Text = Convert.ToDateTime(sarrayVerification[1].ToString()).ToString("hh:mm");
                    }

                    ddlVerificationTimeType.SelectedValue = sarrayVerification[2].ToString();



                }

            }

            if (!(oledbDR["Unsatisfactory_Reason"].ToString().Trim().Length.Equals(0)))
                txtProvidereasonforunsatisfactoryrating.Text = oledbDR["Unsatisfactory_Reason"].ToString();

            if (!(oledbDR["Month_Stay_Resi_Neigh1"].ToString().Trim().Length.Equals(0)))
                txtMonthofStayatResidenceNeigh1.Text = oledbDR["Month_Stay_Resi_Neigh1"].ToString();


            if (!(oledbDR["Month_Stay_Resi_Neigh2"].ToString().Trim().Length.Equals(0)))
                txtMonthofStayatResidenceNeigh2.Text = oledbDR["Month_Stay_Resi_Neigh2"].ToString();

            //added by hemangi kambli on 03/10/2007
            ddlSepBathroom.SelectedValue = oledbDR["SEP_BATHROOM_SEEN"].ToString();
            ddlFamilySeen.SelectedValue = oledbDR["FAMILY_SEEN"].ToString();
            txtSupervisorComments.Text = oledbDR["SUPERVISOR_COMMENTS"].ToString();
            ddlRoofType.SelectedValue = oledbDR["ROOF_TYPE"].ToString();
        }
        oledbDR.Close();
    }

    private void GetResiCumBusiCaseDetail()
    {
        OleDbDataReader oledbDR;
        oledbDR = objResiCumBusi.GetCaseDetail(hidCaseID.Value);
        if (oledbDR.Read())
        {

            if (!(oledbDR["REF_NO"].ToString().Trim().Length.Equals(0)))
                txtRefNo.Text = oledbDR["REF_NO"].ToString();

            if (!(oledbDR["FULL_NAME"].ToString().Trim().Length.Equals(0)))
                txtApplicantName.Text = oledbDR["FULL_NAME"].ToString();

            

            if (!(oledbDR["Applicant_Address"].ToString().Trim().Length.Equals(0)))
                txtApplicantAddress.Text = oledbDR["Applicant_Address"].ToString();



            //if (!(oledbDR["CASE_REC_DATETIME"].ToString().Trim().Length.Equals(0)))
            //    txtDateOfVerification.Text = oledbDR["CASE_REC_DATETIME"].ToString();

            if (!(oledbDR["DOB"].ToString().Trim().Length.Equals(0)))
               txtAgeOfApplicant.Text = oledbDR["DOB"].ToString();

           


        }
        oledbDR.Close();
    }

    private void GetFeId()
    {
        OleDbDataReader oledbDR;
        oledbDR = objResiCumBusi.GetFEID(hidCaseID.Value);

        if (oledbDR.Read())
        {


            if (!(oledbDR["FULLNAME"].ToString().Trim().Length.Equals(0)))
                txtVerifierName.Text = oledbDR["FULLNAME"].ToString();

 
        }
        oledbDR.Close();
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        int iCount = 0;
        string msg = "";
        try
        {
            PropertySet();
            msg = objResiCumBusi.InsertResiCumBusiness();
            iCount = 1;
            lblMessage.Text = msg;
        }
        catch (Exception ex)
        {
            lblMessage.Visible = true;
            lblMessage.ForeColor = System.Drawing.Color.Red;
            lblMessage.Text = "Error:" + ex.Message;
        }
        if (iCount == 1)
        {
            Response.Redirect("RL_VerificationView.aspx?Msg=" + lblMessage.Text);
        }
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("RL_VerificationView.aspx");
    }

    private void IfIsEditFalse()
    {
        chkAssetSeen.Enabled = false;
        txtOtherAssetSeen.Enabled = false;
        txtApplicantName.Enabled = false;
        txtAgeOfApplicant.Enabled = false;
        txtVerifierName.Enabled = false;
        txtVerificationAgency.Enabled = false;
        txtDateOfVerification.Enabled = false;
        txtVerificationTime.Enabled = false;
        ddlVerificationTimeType.Enabled = false;
        txtMonthofStayatResidenceNeigh2.Enabled = false;
        txtMonthofStayatResidenceNeigh1.Enabled = false;
        txtOtherLocality.Enabled = false;
        txtProvidereasonforunsatisfactoryrating.Enabled = false;
        ddlSepBathroom.Enabled = false;
        ddlFamilySeen.Enabled = false;
        txtSupervisorComments.Enabled = false;
        ddlRoofType.Enabled = false;
        ddlRating.Enabled = false;
        txtNameOfNeighbour1.Enabled=false;
        txtAddressOfNeighbour1.Enabled=false;
        ddlDoesTheApplicantWorkHere1.Enabled=false;
        txtMonthsOfWorkAtOffice1.Enabled=false;
        ddlMarketReputation1.Enabled=false;
        ddlIsTheOfficeSelfOwned1.Enabled=false;
        txtCommentsOfNeighbour1.Enabled=false;

        txtNameOfNeighbour2.Enabled=false;
        txtAddressOfNeighbour2.Enabled=false;
        ddlDoestheApplicantWorkHere2.Enabled=false;
        txtMonthsofWorkatOffice2.Enabled=false;
        ddlMarketReputation2.Enabled=false;
        ddlIstheOfficeselfowned2.Enabled=false;
        txtCommentsofNeighbour2.Enabled=false;

        ddlLocalityOrSurroundings.Enabled=false;
        txtLandMark.Enabled=false;
        txtTypeOfBusinessActivity.Enabled=false;
        ddlLevelOfBusinessActivity.Enabled=false;
        ddlStockSeen.Enabled=false;
        txtNoOfEmployeesSeen.Enabled=false;
        ddlAccessibility.Enabled=false;
        ddlEntranceMotorable.Enabled=false;
        ddlClearDemarcationBetweenResidenceAndOffice.Enabled=false;
        ddlInternalCondition.Enabled=false;
        ddlExternalCondition.Enabled=false;
        ddlNamePlateSightedResi.Enabled=false;
        ddlEntryPermittedResi.Enabled=false;
        txtApproxAreaResi.Enabled=false;
        ddlNamePlateSightedOffice.Enabled = false;
        ddlEntryPermittedOffice.Enabled = false;
        txtApproxAreaOffice.Enabled = false;
        txtOfficeName.Enabled = false;
        
        txtNameOfPersonContacted.Enabled=false;
        txtRelationshipWithApplicant.Enabled=false;
        ddlIdentityProofSeen.Enabled=false;
        ddlBusinessProofSeen.Enabled=false;
        txtNatureofBusiness.Enabled=false;
        ddlTypeOfOrganization.Enabled=false;
        ddlStatusOfResidence.Enabled=false;
        txtMonthsOfWorkatCurrentOffice.Enabled=false;
        txtMonthsOfStayatResidence.Enabled=false;
        txtApplicantIncome.Enabled=false;
        txtOtherSourceOfIncome.Enabled=false;
        txtDetailOfPreviousOccupation.Enabled=false;
        txtFatherOrSpouseName.Enabled=false;
        txtMotherName.Enabled=false;
        ddlMaritalStatus.Enabled=false;
        txtNoOfDependents.Enabled=false;
        txtOtherInvestments.Enabled=false;
        txtAnyOtherLoansBeingTaken.Enabled=false;
        txtPurposeOfLoanBeingTaken.Enabled=false;
        ddlBehaviourOfPersonContacted.Enabled=false;
        ddlEducationBackground.Enabled = false;
        txtVerifierComments.Enabled=false;
        txtColourOfDoor.Enabled=false;
        txtProofOfBusinessAcitivity.Enabled=false;
        ddlOverallVerification.Enabled=false;
        btnCancel.Enabled = false;
        btnSubmit.Enabled = false;
        txtRefNo.Enabled = false;
        txtApplicantAddress.Enabled = false;
        
 
    }

    public void funShowPanel()
    {
        string strClientID = Session["ClientId"].ToString();
        string strActivityID = Session["ActivityId"].ToString();
        string strProductID = Session["ProductId"].ToString();
        string strVerificationType = "14";
        string strPanelName = "";
        string strPlaceHolderName = "";
        int nCount = 1;

        DataSet dsPanel = objCGet.getPanels(strActivityID, strProductID, strClientID, strVerificationType);
        if (dsPanel != null)
        {
            if (dsPanel.Tables[0].Rows.Count != 0)
            {

                for (int i = 0; i < dsPanel.Tables[0].Rows.Count; i++)
                {
                    //CountBonusRows += 1;
                    strPanelName = dsPanel.Tables[0].Rows[i]["PANEL_NAME"].ToString();
                    strPlaceHolderName = "PlaceHolder" + nCount.ToString();


                    PlaceHolder objPlaceHolder = new PlaceHolder();
                    objPlaceHolder = (PlaceHolder)(tblResiCumBusinessVeri.Rows[0].Cells[0].FindControl(strPlaceHolderName));
                    if (objPlaceHolder != null)
                    {

                        Panel objPanel = new Panel();
                        //objPanel.EnableViewState = false;
                        objPanel = (Panel)(tblResiCumBusinessVeri.Rows[1].Cells[0].FindControl(strPanelName));
                        if (objPanel != null)
                        {
                            objPanel.Visible = true;

                            objPlaceHolder.Controls.Add(objPanel);
                        }
                    }
                    //ViewState["strPlaceHolder"+nCount.ToString()] = objPlaceHolder;
                    nCount++;

                }

            }
        }
    }
    protected void vsResiCumBusiness_Init(object sender, EventArgs e)
    {

    }
    private void FillRatingStatus()
    {
        DataTable dtStatus = new DataTable();
        dtStatus = objResiCumBusi.GetCaseStatus();
        ddlRating.DataTextField = "STATUS_NAME";
        ddlRating.DataValueField = "CASE_STATUS_ID";
        ddlRating.DataSource = dtStatus;
        ddlRating.DataBind();
        //ListItem liRating = new ListItem("NA", "0");
        //ddlRating.Items.Add(liRating);
        ListItem lstItem1 = new ListItem("NA", "");
        ddlRating.Items.Insert(0, lstItem1);
    }

    //private void FillSupervisorName()
    //{
    //    DataTable dtSupName = new DataTable();
    //    dtSupName = objResiCumBusi.GetSupervisorName();
    //    ddlSupervisorName.DataTextField = "FULLNAME";
    //    ddlSupervisorName.DataValueField = "EMP_ID";
    //    ddlSupervisorName.DataSource = dtSupName;
    //    ddlSupervisorName.DataBind();

    //}

    private void LikButtonVisibility()
    {
        string verificationTypeCode = hidVerificationTypeCode.Value;
        string[] arrVerificationTypeCode = verificationTypeCode.Split(' ');
        for (int i = 0; i < arrVerificationTypeCode.Length; i++)
        {
            if (arrVerificationTypeCode[i].Length > 0)
            {
                if (verificationType == arrVerificationTypeCode[i].ToString())
                {
                }
                else
                    MatchVerificationType(arrVerificationTypeCode[i].ToString());

            }

        }
    }
    private void MatchVerificationType(string code)
    {
        switch (code)
        {
            case "RV":
                lbRV.Visible = true;
                break;
            case "BV":
                lbBV.Visible = true;
                break;
            case "RT":
                lbRT.Visible = true;
                break;
            case "BT":
                lbBT.Visible = true;
                break;
            case "PRV":
                lbPRV.Visible = true;
                break;
            case "REF1":
                lbREF1.Visible = true;
                break;
            case "REF2":
                lbREF2.Visible = true;
                break;
            case "RCO":
                lbRCO.Visible = true;
                break;

        }

    }
    protected void lbRV_Click(object sender, EventArgs e)
    {
        Response.Redirect("RL_ResidenceVerification.aspx?CaseID=" + hidCaseID.Value + "&VerTypeId=1&VerificationTypeCode=" + hidVerificationTypeCode.Value + "&Mode=View");
    }
    protected void lbBV_Click(object sender, EventArgs e)
    {
        Response.Redirect("RL_BusinessVerification.aspx?CaseID=" + hidCaseID.Value + "&VerTypeId=2&VerificationTypeCode=" + hidVerificationTypeCode.Value + "&Mode=View");
    }
    protected void lbRT_Click(object sender, EventArgs e)
    {
        Response.Redirect("RL_ResidenceTelephonicVerification.aspx?CaseID=" + hidCaseID.Value + "&VerTypeId=4&VerificationTypeCode=" + hidVerificationTypeCode.Value + "&Mode=View");

    }
    protected void lbBT_Click(object sender, EventArgs e)
    {
        Response.Redirect("RL_BusinessTelephonicVerification.aspx?CaseID=" + hidCaseID.Value + "&VerTypeId=3&VerificationTypeCode=" + hidVerificationTypeCode.Value + "&Mode=View");

    }
    protected void lbPRV_Click(object sender, EventArgs e)
    {
        Response.Redirect("RL_ResidenceVerification.aspx?CaseID=" + hidCaseID.Value + "&VerTypeId=10&VerificationTypeCode=" + hidVerificationTypeCode.Value + "&Mode=View");
    }
    protected void lbREF1_Click(object sender, EventArgs e)
    {
        Response.Redirect("RL_REF1Verification.aspx?CaseID=" + hidCaseID.Value + "&VerTypeId=12&VerificationTypeCode=" + hidVerificationTypeCode.Value + "&Mode=View");

    }
    protected void lbREF2_Click(object sender, EventArgs e)
    {
        Response.Redirect("RL_REF2Verification.aspx?CaseID=" + hidCaseID.Value + "&VerTypeId=13&VerificationTypeCode=" + hidVerificationTypeCode.Value + "&Mode=View");

    }

    protected void lbRCO_Click(object sender, EventArgs e)
    {
        Response.Redirect("RL_ResiCumBusiness.aspx?CaseID=" + hidCaseID.Value + "&VerTypeId=14&VerificationTypeCode=" + hidVerificationTypeCode.Value + "&Mode=View");
    }
}
