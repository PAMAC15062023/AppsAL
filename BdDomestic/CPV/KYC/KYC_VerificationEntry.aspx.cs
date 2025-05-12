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

public partial class KYC_KYC_VerificationEntry : System.Web.UI.Page
{

    //protected void Page_Init(object sender, EventArgs e)
    //{
    //    funShowPanel();
    //}
    CKYCVerification objKYC = new CKYCVerification();

    protected void Page_Load(object sender, EventArgs e)
    {
       
        if (!IsPostBack)
        {
            //To Show the Panels add By Manoj            
            //funShowPanel();
            //End            
            if (Context.Request.QueryString["CaseID"] != null && Context.Request.QueryString["CaseID"] != "" && Context.Request.QueryString["VerTypeId"] != null && Context.Request.QueryString["VerTypeId"] != "")
            {
                //if (Session["isEdit"].ToString() != "1")
                //    ISEditFalse();
                txtPersonContacted.Focus();
               
                hidCaseID.Value = Request.QueryString["CaseID"].ToString();
                hidVerificationTypeID.Value = Request.QueryString["VerTypeId"].ToString();
                Session["CaseID"] = Request.QueryString["CaseID"].ToString();
                OleDbDataReader oledbReadKYC;
                OleDbDataReader oledbCaseDtl;
                //oledbReadKYC = objKYC.GetBVDetail(sCaseId, sVerifyTypeId);
                oledbCaseDtl = objKYC.GetCASEDetail(hidCaseID.Value, hidVerificationTypeID.Value);
                
                if (oledbCaseDtl.Read() == true)
                {
                    txtRefNo.Text = oledbCaseDtl["REF_NO"].ToString();
                    txtInitiationDate.Text = oledbCaseDtl["CASE_REC_DATETIME"].ToString();
                    txtAppName.Text = oledbCaseDtl["NAME"].ToString();
                    txtSendDate.Text = oledbCaseDtl["SEND_DATETIME"].ToString();

                }
                txtDate1.Text = DateTime.Now.ToString("dd/MM/yyyy");
                txtDate2.Text = DateTime.Now.ToString("dd/MM/yyyy");
                txtDate3.Text = DateTime.Now.ToString("dd/MM/yyyy");
                FillStatus();
                GetCaseDetail();
                GetKYCVerificationEntry();
                GetTeleCallLog();
                GetVerifierName();
                
                
            }
        }
    }

    private void GetKYCVerificationEntry()
    {
        OleDbDataReader oledbDR;
        oledbDR = objKYC.GetKYCVerificationEntry(hidCaseID.Value, hidVerificationTypeID.Value);
        if (oledbDR.Read())
        {

            string sTmp = oledbDR["sup_date_time"].ToString();
            if (sTmp != "")
            {
                string[] arrsupdatetime = sTmp.Split(' ');
                if (arrsupdatetime[0].ToString() != "")
                    txtSupervisorDate.Text = Convert.ToDateTime(arrsupdatetime[0].ToString()).ToString("dd/MM/yyyy");
                if (arrsupdatetime[1].ToString() != "")
                    txtSupervisorTime.Text = Convert.ToDateTime(arrsupdatetime[1].ToString()).ToString("hh:mm");

                ddlSupervisorTimeType.SelectedValue = arrsupdatetime[2].ToString();
            }


            string sTmp1 = oledbDR["veri_date_time"].ToString();
            if (sTmp1 != "")
            {
                string[] arrveridatetime = sTmp1.Split(' ');
                if (arrveridatetime[0].ToString() != "")
                    txtVerifierDate.Text = Convert.ToDateTime(arrveridatetime[0].ToString()).ToString("dd/MM/yyyy");
                if (arrveridatetime[1].ToString() != "")
                    txtVerifierTime.Text = Convert.ToDateTime(arrveridatetime[1].ToString()).ToString("hh:mm");

                ddlVerifierTimeType.SelectedValue = arrveridatetime[2].ToString();
            }
            if (!(oledbDR["Tlele_Remark"].ToString().Trim().Length.Equals(0)))
                txtRemark.Text = oledbDR["Tlele_Remark"].ToString();

            if (!(oledbDR["supervisor_name"].ToString().Trim().Length.Equals(0)))
                txtSupervisorName.Text = oledbDR["supervisor_name"].ToString();

            if (!(oledbDR["Company_Type"].ToString().Trim().Length.Equals(0)))
                ddlCompanyType.SelectedValue = oledbDR["Company_Type"].ToString();


            if (!(oledbDR["Name_Firm"].ToString().Trim().Length.Equals(0)))
                txtNameOfFirm.Text = oledbDR["Name_Firm"].ToString();

            if (!(oledbDR["Business_Address"].ToString().Trim().Length.Equals(0)))
                txtBusinessAddress.Text = oledbDR["Business_Address"].ToString();

            if (!(oledbDR["Business_Pincode"].ToString().Trim().Length.Equals(0)))
                txtBusinessPincode.Text = oledbDR["Business_Pincode"].ToString();


            if (!(oledbDR["Bussiness_tel_no"].ToString().Trim().Length.Equals(0)))
                txtBusinessTelNo.Text = oledbDR["Bussiness_tel_no"].ToString();

            if (!(oledbDR["ContactPerson"].ToString().Trim().Length.Equals(0)))
                if (oledbDR["ContactPerson"].ToString().Trim() != "Neighbour" && oledbDR["ContactPerson"].ToString().Trim() != "Watchman")
                {
                    ddlContactPerson.SelectedIndex = 3;
                    txtIfOtherProvideDetail.Text = oledbDR["ContactPerson"].ToString();

                }
                else
                {
                    ddlContactPerson.SelectedValue = oledbDR["ContactPerson"].ToString();
                }

            if (!(oledbDR["Name_person_contacted"].ToString().Trim().Length.Equals(0)))
                txtNameOfPersonContacted.Text = oledbDR["Name_person_contacted"].ToString();



            if (!(oledbDR["Designation"].ToString().Trim().Length.Equals(0)))
                txtDesignation.Text = oledbDR["Designation"].ToString();

            if (!(oledbDR["Premise_Location"].ToString().Trim().Length.Equals(0)))
                ddlPremiseLocation.SelectedValue = oledbDR["Premise_Location"].ToString();

            if (!(oledbDR["Prominent_Landmark"].ToString().Trim().Length.Equals(0)))
                txtProminentLandmark.Text = oledbDR["Prominent_Landmark"].ToString();


            if (!(oledbDR["Address_Verified_is"].ToString().Trim().Length.Equals(0)))
                ddlAddressVerifiedIs.SelectedValue = oledbDR["Address_Verified_is"].ToString();

             if (!(oledbDR["How_long_Business"].ToString().Trim().Length.Equals(0)))
                txtHowLongInBusiness.Text = oledbDR["How_long_Business"].ToString();

            if (!(oledbDR["Area_Premises"].ToString().Trim().Length.Equals(0)))
                txtAreaPremises.Text = oledbDR["Area_Premises"].ToString();


            if (!(oledbDR["Ownership_Premises"].ToString().Trim().Length.Equals(0)) )
            {

                if (oledbDR["Ownership_Premises"].ToString().Trim() != "Owned" && oledbDR["Ownership_Premises"].ToString().Trim() != "Rented")
                {
                    ddlOwnershipOfPremises.SelectedIndex = 3;
                    txtIfOtherPlzSpecify.Text = oledbDR["Ownership_Premises"].ToString();
                    
                }
                else
                {
                 
                    ddlOwnershipOfPremises.SelectedValue = oledbDR["Ownership_Premises"].ToString();
                }
            }
            if (!(oledbDR["Type_Premise"].ToString().Trim().Length.Equals(0)))
                ddlTypeOfPremise.SelectedValue = oledbDR["Type_Premise"].ToString();

            if (!(oledbDR["Type_Premise_Other"].ToString().Trim().Length.Equals(0)))
                txtOtherTypeOfPremise.Text = oledbDR["Type_Premise_Other"].ToString();


            if (!(oledbDR["Nature_Business"].ToString().Trim().Length.Equals(0)))
                ddlNatureOfBusiness.SelectedValue = oledbDR["Nature_Business"].ToString();

            if (!(oledbDR["Firm_Signboard_Sighted"].ToString().Trim().Length.Equals(0)))
                ddlFirmSignBoardSighted.SelectedValue = oledbDR["Firm_Signboard_Sighted"].ToString();

            if (!(oledbDR["Sign_Sighted_Remark"].ToString().Trim().Length.Equals(0)))
                txtSignBoardSightedRemark.Text = oledbDR["Sign_Sighted_Remark"].ToString();


            if (!(oledbDR["Type_Document_Sighted"].ToString().Trim().Length.Equals(0)))
                ddlTypeOfDocSighted.SelectedValue = oledbDR["Type_Document_Sighted"].ToString();

            if (!(oledbDR["Document_Sighted_Remark"].ToString().Trim().Length.Equals(0)))
                txtIfOtherDocSightedRemark.Text = oledbDR["Document_Sighted_Remark"].ToString();

             if (!(oledbDR["Used_Pages_Sighted_Date"].ToString().Trim().Length.Equals(0)))
                txtUsedPageSightDate.Text = oledbDR["Used_Pages_Sighted_Date"].ToString();

            if (!(oledbDR["Issued_to"].ToString().Trim().Length.Equals(0)))
                txtIssuedTo.Text = oledbDR["Issued_to"].ToString();


            if (!(oledbDR["Initial_Invoice_Sighted_No"].ToString().Trim().Length.Equals(0)))
                txtInitialInvoiceSightedNo.Text = oledbDR["Initial_Invoice_Sighted_No"].ToString();

            if (!(oledbDR["Initial_Invoice_Sighted_Date"].ToString().Trim().Length.Equals(0)))
                txtInitialInvoiceSightedDate.Text = oledbDR["Initial_Invoice_Sighted_Date"].ToString();

            if (!(oledbDR["Initial_Invoice_issued_to"].ToString().Trim().Length.Equals(0)))
                txtInitialInvoiceSightedIssuedTo.Text = oledbDR["Initial_Invoice_issued_to"].ToString();


            if (!(oledbDR["Third_Party_Invoice_No"].ToString().Trim().Length.Equals(0)))
                txtThirdPartyInvoiceNo.Text = oledbDR["Third_Party_Invoice_No"].ToString();

            if (!(oledbDR["Third_Party_Invoice_Date"].ToString().Trim().Length.Equals(0)))
                txtThirdPartyInvoiceDate.Text = oledbDR["Third_Party_Invoice_Date"].ToString();

            if (!(oledbDR["Third_Party_Invoice_Issued_by"].ToString().Trim().Length.Equals(0)))
                txtThirdPartyInvoiceIssuedBy.Text = oledbDR["Third_Party_Invoice_Issued_by"].ToString();


            if (!(oledbDR["Third_Party_Address"].ToString().Trim().Length.Equals(0)))
                txtThirdPartyAddress.Text = oledbDR["Third_Party_Address"].ToString();

            if (!(oledbDR["Relationship_between"].ToString().Trim().Length.Equals(0)))
                if (oledbDR["Relationship_between"].ToString().Trim() != "Same Proprietor" && oledbDR["Relationship_between"].ToString().Trim() != "Common Partner")
                {
                    ddlRelationshipBtnEntity.SelectedIndex = 3;
                    txtIfOtherRelationship.Text = oledbDR["Relationship_between"].ToString();
                }
                else
                {
                    ddlRelationshipBtnEntity.SelectedValue = oledbDR["Relationship_between"].ToString();
                }

             if (!(oledbDR["Business_Ownership"].ToString().Trim().Length.Equals(0)))
                ddlBusinessOwnership.SelectedValue = oledbDR["Business_Ownership"].ToString();

            if (!(oledbDR["Level_Business_Activity"].ToString().Trim().Length.Equals(0)))
                ddlLevelOfBusinessActivity.SelectedValue = oledbDR["Level_Business_Activity"].ToString();


            if (!(oledbDR["No_Employees"].ToString().Trim().Length.Equals(0)))
                txtNoOfEmployee.Text = oledbDR["No_Employees"].ToString();

            if (!(oledbDR["Business_Equipment_Sighted"].ToString().Trim().Length.Equals(0)))
            {
                string sBusinessEquipSighted = oledbDR["Business_Equipment_Sighted"].ToString();
                string[] arrBusinessEquipSighted = sBusinessEquipSighted.Split(',');
                int iOthersBusinessEquipSightedCtr = 0;
                if (arrBusinessEquipSighted.Length > 0)
                {
                    for (int i = 0; i < arrBusinessEquipSighted.Length; i++)
                    {
                        foreach (ListItem li in chklBusinessEquipSighted.Items)
                        {
                            if (li.Value == arrBusinessEquipSighted.GetValue(i).ToString())
                                li.Selected = true;
                            if (arrBusinessEquipSighted.GetValue(i).ToString() == "Others")
                            {
                                iOthersBusinessEquipSightedCtr = i;
                            }
                        }
                    }
                }
                for (int j = iOthersBusinessEquipSightedCtr + 1; j < arrBusinessEquipSighted.Length; j++)
                {
                    txtIfOtherBusinessEquipment.Text += arrBusinessEquipSighted.GetValue(j) + ",";
                }
            }

            if (!(oledbDR["Marital_Status"].ToString().Trim().Length.Equals(0)))
                ddlMaritalStatus.SelectedValue = oledbDR["Marital_Status"].ToString();


            if (!(oledbDR["Name_Displayed_Board"].ToString().Trim().Length.Equals(0)))
                ddlNamePlateDisplay.SelectedValue = oledbDR["Name_Displayed_Board"].ToString();

            if (!(oledbDR["Relationship_with_Applicant"].ToString().Trim().Length.Equals(0)))
                txtRelationshipWithApp.Text = oledbDR["Relationship_with_Applicant"].ToString();

            if (!(oledbDR["Staying_since_Resi"].ToString().Trim().Length.Equals(0)))
                txtStayingSinceAtResi.Text = oledbDR["Staying_since_Resi"].ToString();


            if (!(oledbDR["Status_Demat_Account"].ToString().Trim().Length.Equals(0)))
                ddlStatusOfDematAcct.SelectedValue = oledbDR["Status_Demat_Account"].ToString();

            if (!(oledbDR["Name_Demat_Account"].ToString().Trim().Length.Equals(0)))
                txtNameOfDematAcct.Text = oledbDR["Name_Demat_Account"].ToString();

             if (!(oledbDR["Broking_through_other"].ToString().Trim().Length.Equals(0)))
                txtDoBrokeOtherThanSSKI.Text= oledbDR["Broking_through_other"].ToString();

            if (!(oledbDR["Attitude_Person_Contacted"].ToString().Trim().Length.Equals(0)))
                ddlAttituteOfContactPerson.SelectedValue = oledbDR["Attitude_Person_Contacted"].ToString();


            if (!(oledbDR["Rating"].ToString().Trim().Length.Equals(0)))
                ddlRating.SelectedValue = oledbDR["Rating"].ToString();

            if (!(oledbDR["Status"].ToString().Trim().Length.Equals(0)))
                ddlStatus.SelectedItem.Text = oledbDR["Status"].ToString();

            if (!(oledbDR["Product"].ToString().Trim().Length.Equals(0)))
                txtProduct.Text = oledbDR["Product"].ToString();


            if (!(oledbDR["Verification_Agent"].ToString().Trim().Length.Equals(0)))
                txtNameOfVerificationAgent.Text = oledbDR["Verification_Agent"].ToString();

            if (!(oledbDR["Residence_Address"].ToString().Trim().Length.Equals(0)))
                txtResidenceAddress.Text = oledbDR["Residence_Address"].ToString();

            if (!(oledbDR["Resi_Pincode"].ToString().Trim().Length.Equals(0)))
                txtResiPincode.Text = oledbDR["Resi_Pincode"].ToString();


            if (!(oledbDR["Resi_Tel_no"].ToString().Trim().Length.Equals(0)))
                txtResiTelNo.Text = oledbDR["Resi_Tel_no"].ToString();

            if (!(oledbDR["Resi_Landmark"].ToString().Trim().Length.Equals(0)))
                txtResiLandmark.Text = oledbDR["Resi_Landmark"].ToString();

             if (!(oledbDR["Permanent_Address"].ToString().Trim().Length.Equals(0)))
                txtPermanentAddress.Text = oledbDR["Permanent_Address"].ToString();

            if (!(oledbDR["Permanent_Pincode"].ToString().Trim().Length.Equals(0)))
                txtPermanentPincode.Text = oledbDR["Permanent_Pincode"].ToString();


            if (!(oledbDR["Permamnent_Tel_no"].ToString().Trim().Length.Equals(0)))
                txtPermanentTelNo.Text = oledbDR["Permamnent_Tel_no"].ToString();

            if (!(oledbDR["Business_Occupation_Details"].ToString().Trim().Length.Equals(0)))
                txtBusiOccupationDtl.Text = oledbDR["Business_Occupation_Details"].ToString();


            if (!(oledbDR["RV_COMMENT"].ToString().Trim().Length.Equals(0)))
                txtRvComment.Text = oledbDR["RV_COMMENT"].ToString();


            if (!(oledbDR["Place_Visited"].ToString().Trim().Length.Equals(0)))
            {
                if (oledbDR["Place_Visited"].ToString().Trim() != "Residence" && oledbDR["Place_Visited"].ToString().Trim() != "Office")
                {
                    ddlPlaceVisited.SelectedIndex = 3;
                    txtIfOthersSpecify.Text = oledbDR["Place_Visited"].ToString().Trim();
                }
                else
                {
                    ddlPlaceVisited.SelectedValue = oledbDR["Place_Visited"].ToString();
                }
            }

            if (!(oledbDR["Area_Residence"].ToString().Trim().Length.Equals(0)))
                txtAreaOfResidence.Text = oledbDR["Area_Residence"].ToString();

            if (!(oledbDR["Locating_Address"].ToString().Trim().Length.Equals(0)))
                ddlLocatingAddress.SelectedValue = oledbDR["Locating_Address"].ToString();

            if (!(oledbDR["Business_activity_Seen"].ToString().Trim().Length.Equals(0)))
                txtIfOfficeBusiActivity.Text = oledbDR["Business_activity_Seen"].ToString();


            if (!(oledbDR["Description_Res"].ToString().Trim().Length.Equals(0)))
                txtDescriptionOfResi.Text = oledbDR["Description_Res"].ToString();

            if (!(oledbDR["General_Comments"].ToString().Trim().Length.Equals(0)))
                txtGeneralComments.Text = oledbDR["General_Comments"].ToString();

             if (!(oledbDR["Name_Account"].ToString().Trim().Length.Equals(0)))
                txtNameOfAccount.Text = oledbDR["Name_Account"].ToString();

            if (!(oledbDR["Request_No"].ToString().Trim().Length.Equals(0)))
                txtRequestNo.Text = oledbDR["Request_No"].ToString();


            if (!(oledbDR["Name_CA_firms"].ToString().Trim().Length.Equals(0)))
                txtNameOfCAFirm.Text = oledbDR["Name_CA_firms"].ToString();

            if (!(oledbDR["Address_CA_Firm"].ToString().Trim().Length.Equals(0)))
                txtAddressOfCAFirm.Text = oledbDR["Address_CA_Firm"].ToString();

            if (!(oledbDR["firm_Exist_Address"].ToString().Trim().Length.Equals(0)))
                ddlDoesFirmExistAtAddress.SelectedValue = oledbDR["firm_Exist_Address"].ToString();


            if (!(oledbDR["IS_CA_firm"].ToString().Trim().Length.Equals(0)))
               ddlIsFirmACAFirm.Text = oledbDR["IS_CA_firm"].ToString();

            if (!(oledbDR["Name_Person_CA_Certificate"].ToString().Trim().Length.Equals(0)))
                txtNameOfPersonWhoIssuedCACertificate.Text = oledbDR["Name_Person_CA_Certificate"].ToString();

            if (!(oledbDR["IS_person_case_praticing"].ToString().Trim().Length.Equals(0)))
                ddlIsPersonOneOfPractising.SelectedValue= oledbDR["IS_person_case_praticing"].ToString();


            if (!(oledbDR["Person_issued_Cerificate_spoken"].ToString().Trim().Length.Equals(0)))
                ddlWasPersonSpokenTo.SelectedValue = oledbDR["Person_issued_Cerificate_spoken"].ToString();

            if (!(oledbDR["Cerificate_person_confirm"].ToString().Trim().Length.Equals(0)))
                ddlConfirmCACertificateIssued.SelectedValue = oledbDR["Cerificate_person_confirm"].ToString();

            if (!(oledbDR["inconclusive_Reason"].ToString().Trim().Length.Equals(0)))
                txtIfInconclusiveReason.Text = oledbDR["inconclusive_Reason"].ToString();

            if (!(oledbDR["Email_ID"].ToString().Trim().Length.Equals(0)))
                txtEmail.Text = oledbDR["Email_ID"].ToString();

            if (!(oledbDR["Name_On_Sign_Board"].ToString().Trim().Length.Equals(0)))
                txtNameOnSignBoard.Text = oledbDR["Name_On_Sign_Board"].ToString();

            if (!(oledbDR["Concern_Is_Related"].ToString().Trim().Length.Equals(0)))
                ddlProprietorPartner.SelectedValue = oledbDR["Concern_Is_Related"].ToString();

            if (!(oledbDR["Concern_Related_Name"].ToString().Trim().Length.Equals(0)))
                txtName.Text = oledbDR["Concern_Related_Name"].ToString();

            if (!(oledbDR["Family_Member_Is"].ToString().Trim().Length.Equals(0)))
                ddlFamilyMemberIs.SelectedValue = oledbDR["Family_Member_Is"].ToString();

            if (!(oledbDR["Family_Member_Name"].ToString().Trim().Length.Equals(0)))
                txtNameIs.Text = oledbDR["Family_Member_Name"].ToString();

            if (!(oledbDR["Family_Member_Relationship"].ToString().Trim().Length.Equals(0)))
                txtRelationshipIs.Text = oledbDR["Family_Member_Relationship"].ToString();

            if (!(oledbDR["Other_Institution_Demat_Account"].ToString().Trim().Length.Equals(0)))
                ddlHavingDematAcwithOtherInstitution.SelectedValue = oledbDR["Other_Institution_Demat_Account"].ToString();

            if (!(oledbDR["Name_Of_DP"].ToString().Trim().Length.Equals(0)))
                txtIfYesThenNameOfDP.Text = oledbDR["Name_Of_DP"].ToString();

            if (!(oledbDR["Name_Plate_Of_App_Sighted"].ToString().Trim().Length.Equals(0)))
                ddlNamePlateOfAppSighted.SelectedValue = oledbDR["Name_Plate_Of_App_Sighted"].ToString();

            if (!(oledbDR["Entity_Type"].ToString().Trim().Length.Equals(0)))
                ddlEntityType.SelectedValue = oledbDR["Entity_Type"].ToString();

            if (!(oledbDR["Tele_No_CA_Firm"].ToString().Trim().Length.Equals(0)))
                txtTelNoOfCAFirm.Text = oledbDR["Tele_No_CA_Firm"].ToString();

            if (!(oledbDR["No_Years_Current_Employment"].ToString().Trim().Length.Equals(0)))
                txtNoOfYearsInCurrentEmployment.Text = oledbDR["No_Years_Current_Employment"].ToString();

            if (!(oledbDR["Other_Institution_SME_Account"].ToString().Trim().Length.Equals(0)))
                ddlHavingSMEAccountWithOtherInstitution.SelectedValue = oledbDR["Other_Institution_SME_Account"].ToString();

            if (!(oledbDR["Name_Of_Institution"].ToString().Trim().Length.Equals(0)))
                txtNameOfInstitution.Text = oledbDR["Name_Of_Institution"].ToString();
            if(!(oledbDR["Person_Contacted"].ToString().Trim().Length.Equals(0)))
                txtPersonContacted.Text = oledbDR["Person_Contacted"].ToString();

        }
        oledbDR.Close();
    }

    private void GetVerifierName()
    {
        OleDbDataReader oledbDR;
        oledbDR = objKYC.GetVerifierID(hidCaseID.Value);
        if (oledbDR.Read())
        {
            if (!(oledbDR["EMP_ID"].ToString().Trim().Length.Equals(0)))
                hidVerifierID.Value = oledbDR["EMP_ID"].ToString();

            if (!(oledbDR["FULLNAME"].ToString().Trim().Length.Equals(0)))
                txtVerifierName.Text = oledbDR["FULLNAME"].ToString();


           
        }
        oledbDR.Close();
    }

    private void GetCaseDetail()
    {
        OleDbDataReader oledbDR;
        oledbDR = objKYC.GetKYCCaseDetail(hidCaseID.Value);
        if (oledbDR.Read())
        {
            if (!(oledbDR["REF_NO"].ToString().Trim().Length.Equals(0)))
                txtRefNo.Text = oledbDR["REF_NO"].ToString();

            if (!(oledbDR["Applicant_Name"].ToString().Trim().Length.Equals(0)))
                txtAppName.Text = oledbDR["Applicant_Name"].ToString();

            if (!(oledbDR["Address"].ToString().Trim().Length.Equals(0)))
                txtAddress.Text = oledbDR["Address"].ToString();

            if (!(oledbDR["CASE_REC_DATETIME"].ToString().Trim().Length.Equals(0)))
                txtInitiationDate.Text = oledbDR["CASE_REC_DATETIME"].ToString();

            if (!(oledbDR["DOB"].ToString().Trim().Length.Equals(0)))
                txtDOB.Text = oledbDR["DOB"].ToString();

            if (!(oledbDR["RES_PHONE"].ToString().Trim().Length.Equals(0)))
                txtPhone.Text = oledbDR["RES_PHONE"].ToString();

            if (!(oledbDR["MOBILE"].ToString().Trim().Length.Equals(0)))
                txtMobile.Text = oledbDR["MOBILE"].ToString();

        }
        oledbDR.Close();
    }


    /// <summary>
    /// This Method is Used to  Read the Records from the table CC_CPV_VERI_ATTAMPTS
    /// </summary>
    private void GetTeleCallLog()
    {
        DataSet dsTeleCallLog = new DataSet();
        string sCaseId = hidCaseID.Value;
        if (sCaseId != "")
        {
            dsTeleCallLog = objKYC.GetTeleCallLogDetail(sCaseId, hidVerificationTypeID.Value);
            if (dsTeleCallLog.Tables[0].Rows.Count > 0)
            {

                for (int i = 0; i < dsTeleCallLog.Tables[0].Rows.Count; i++)
                {
                    if (i == 0)
                    {
                        string sAttemptDateTime = dsTeleCallLog.Tables[0].Rows[i]["ATTEMPT_DATE_TIME"].ToString();
                        string[] arrAttemptDateTime = sAttemptDateTime.Split(' ');
                        txtDate1.Text = Convert.ToDateTime(arrAttemptDateTime[0].ToString()).ToString("dd/MM/yyyy");
                        txtTime1.Text = Convert.ToDateTime(arrAttemptDateTime[1].ToString()).ToString("hh:mm");
                        ddlTimeType1.SelectedValue = arrAttemptDateTime[2].ToString().Trim();
                        txtRemark1.Text = dsTeleCallLog.Tables[0].Rows[i]["REMARK"].ToString();
                       //ddlVerifierName.SelectedValue = dsTeleCallLog.Tables[0].Rows[i]["VERIFIER_ID"].ToString();
                    }
                    if (i == 1)
                    {
                        string sAttemptDateTime = dsTeleCallLog.Tables[0].Rows[i]["ATTEMPT_DATE_TIME"].ToString();
                        string[] arrAttemptDateTime = sAttemptDateTime.Split(' ');
                        txtDate2.Text = Convert.ToDateTime(arrAttemptDateTime[0].ToString()).ToString("dd/MM/yyyy");
                        txtTime2.Text = Convert.ToDateTime(arrAttemptDateTime[1].ToString()).ToString("hh:mm");
                        ddlTimeType2.SelectedValue = arrAttemptDateTime[2].ToString().Trim();

                        txtRemark2.Text = dsTeleCallLog.Tables[0].Rows[i]["REMARK"].ToString();
                        //ddlVerifierName.SelectedValue = dsTeleCallLog.Tables[0].Rows[i]["VERIFIER_ID"].ToString();
                    }
                    if (i == 2)
                    {
                        string sAttemptDateTime = dsTeleCallLog.Tables[0].Rows[i]["ATTEMPT_DATE_TIME"].ToString();
                        string[] arrAttemptDateTime = sAttemptDateTime.Split(' ');
                        txtDate3.Text = Convert.ToDateTime(arrAttemptDateTime[0].ToString()).ToString("dd/MM/yyyy");
                        txtTime3.Text = Convert.ToDateTime(arrAttemptDateTime[1].ToString()).ToString("hh:mm");
                        ddlTimeType3.SelectedValue = arrAttemptDateTime[2].ToString().Trim();
                        
                        txtRemark3.Text = dsTeleCallLog.Tables[0].Rows[i]["REMARK"].ToString();
                        //ddlVerifierName.Text = dsTeleCallLog.Tables[0].Rows[i]["VERIFIER_ID"].ToString();
                    }
                   
                }
            }
        }

    }

    /// <summary>
    ///  This Method is Used to  Insert the Records in the table CC_CPV_VERI_ATTAMPTS
    /// </summary>
    private void InsertTeleCallLog()
    {


        try
        {
            ArrayList arrTeleCallLog = new ArrayList();
            ArrayList arrLog1stCall = new ArrayList();
            ArrayList arrLog2ndCall = new ArrayList();
            ArrayList arrLog3rdCall = new ArrayList();
           
            string strCaseID = hidCaseID.Value;
            objKYC.CaseId = strCaseID;


            objKYC.VerificationTypeId = Request.QueryString["VerTypeId"].ToString();
            CCommon objCom = new CCommon();
            if (txtDate1.Text.Trim() != "" && txtTime1.Text.Trim() != "")
            {
                arrLog1stCall.Clear();
                arrLog1stCall.Add(objCom.strDate(txtDate1.Text.Trim()) + " " + txtTime1.Text.Trim() + " " + ddlTimeType1.SelectedItem.Text.Trim());
                arrLog1stCall.Add(txtRemark1.Text.Trim());

                arrLog1stCall.Add(hidVerifierID.Value);
                arrTeleCallLog.Add(arrLog1stCall);
            }

            if (txtDate2.Text.Trim() != "" && txtTime2.Text.Trim() != "")
            {
                arrLog2ndCall.Clear();
                arrLog2ndCall.Add(objCom.strDate(txtDate2.Text.Trim()) + " " + txtTime2.Text.Trim() + " " + ddlTimeType2.SelectedItem.Text.Trim());
                arrLog2ndCall.Add(txtRemark2.Text.Trim());

                arrLog2ndCall.Add(hidVerifierID.Value);
                arrTeleCallLog.Add(arrLog2ndCall);
            }

            if (txtDate3.Text.Trim() != "" && txtTime3.Text.Trim() != "")
            {
                arrLog3rdCall.Clear();
                arrLog3rdCall.Add(objCom.strDate(txtDate3.Text.Trim()) + " " + txtTime3.Text.Trim() + " " + ddlTimeType3.SelectedItem.Text.Trim());
                arrLog3rdCall.Add(txtRemark3.Text.Trim());

                arrLog3rdCall.Add(hidVerifierID.Value);
                arrTeleCallLog.Add(arrLog3rdCall);
            }
            

            if (objKYC.InsertTeleCallLog(arrTeleCallLog) == 1)
            {


            }

        }
        catch (Exception ex)
        {
            throw new Exception("Error found during Inserting records in TeleCallLog" + ex.Message);

        }
    }


    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        CKYCVerification objKYC = new CKYCVerification();
        int iCount = 0;
        string sMsg = "";
        CCommon objCom = new CCommon();
        try
        {
            objKYC.CaseId = Request.QueryString["CaseId"].ToString();
            objKYC.VerificationTypeId = hidVerificationTypeID.Value;
            if (ddlCompanyType.SelectedIndex != 0)
            {
                objKYC.CompanyType = ddlCompanyType.SelectedItem.Text.Trim();
            }
            objKYC.NameOfFirm = txtNameOfFirm.Text.Trim();
            objKYC.BusinessAddress = txtBusinessAddress.Text.Trim();
            objKYC.BusinessPicode = txtBusinessPincode.Text.Trim();
            objKYC.BusinessTelNo = txtBusinessTelNo.Text.Trim();
            
            objKYC.PersonContacted = txtPersonContacted.Text.Trim();

            objKYC.NameOfPersonContacted = txtNameOfPersonContacted.Text.Trim();
            objKYC.Designation = txtDesignation.Text.Trim();



            if ((txtSupervisorDate.Text.Trim() != "" && txtSupervisorDate.Text.Trim() != null) && (txtSupervisorTime.Text != "" && txtSupervisorTime.Text != null))
            {
                objKYC.SupervisorDateTime = objCom.strDate(txtSupervisorDate.Text.Trim()) + " " + txtSupervisorTime.Text.Trim() + " " + ddlSupervisorTimeType.SelectedValue;
            }
            if (txtVerifierDate.Text.Trim() != "" && txtVerifierDate.Text.Trim() !=null && txtVerifierTime.Text.Trim() != "" && txtVerifierTime.Text.Trim() !=null)
            {
                objKYC.VerifierDatetime = objCom.strDate(txtVerifierDate.Text.Trim()) + " " + txtVerifierTime.Text.Trim() + " " + ddlVerifierTimeType.SelectedValue;
            }
            if (txtSupervisorName.Text.Trim() != "")
            {
                objKYC.SupervisorName = txtSupervisorName.Text.Trim();
            }
            if (ddlPremiseLocation.SelectedIndex != 0)
            {
                objKYC.PremiseLocation = ddlPremiseLocation.SelectedItem.Text.Trim();
            }
            objKYC.ProminetLandmark = txtProminentLandmark.Text.Trim();
            objKYC.TeleRemark = txtRemark.Text.Trim();
            if (ddlAddressVerifiedIs.SelectedIndex != 0)
            {
                objKYC.AddressVerifiedIs = ddlAddressVerifiedIs.SelectedItem.Text.Trim();
            }
            objKYC.HowLongInBusiness = txtHowLongInBusiness.Text.Trim();
            objKYC.AreaOfPremises = txtAreaPremises.Text.Trim();
            if (ddlOwnershipOfPremises.SelectedIndex != 0)
            {
                objKYC.OwnershipOfPremises = ddlOwnershipOfPremises.SelectedItem.Text.Trim();
            }
            if (ddlOwnershipOfPremises.SelectedIndex == 3)
            {
                objKYC.OwnershipOfPremises = txtIfOtherPlzSpecify.Text.Trim();
            }
            if (ddlTypeOfPremise.SelectedIndex != 0)
            {
                objKYC.TypeOfPremises = ddlTypeOfPremise.SelectedItem.Text.Trim();
            }
            objKYC.IfOthersPremisespecify = txtOtherTypeOfPremise.Text.Trim();
            if (ddlContactPerson.SelectedIndex != 0)
            {
                objKYC.ContactPerson = ddlContactPerson.SelectedItem.Text.Trim();
            }
            if (ddlContactPerson.SelectedIndex== 3)
            {
                objKYC.ContactPerson = txtIfOtherProvideDetail.Text.Trim();
            }
            if (ddlNatureOfBusiness.SelectedIndex != 0)
            {
                objKYC.NatureOfBusiness = ddlNatureOfBusiness.SelectedItem.Text.Trim();
            }
            if (ddlFirmSignBoardSighted.SelectedIndex != 0)
            {
                objKYC.FirmSightedBoard = ddlFirmSignBoardSighted.SelectedItem.Text.Trim();
            }
            objKYC.SignBoardSightedRemark = txtSignBoardSightedRemark.Text.Trim();
            if (ddlTypeOfDocSighted.SelectedIndex != 0)
            {
                objKYC.TypeOfDocSighted = ddlTypeOfDocSighted.SelectedItem.Text.Trim();
            }
            objKYC.OtherDocSightedRemark = txtIfOtherDocSightedRemark.Text.Trim();
            objKYC.UsedPagesSightedDate = txtUsedPageSightDate.Text.Trim();
            objKYC.IssuedTo = txtIssuedTo.Text.Trim();
            objKYC.InitialInvoiceSightedNo = txtInitialInvoiceSightedNo.Text.Trim();
            objKYC.InitialInvoiceSightedDate = txtInitialInvoiceSightedDate.Text.Trim();
            objKYC.InitialInvoiceSightedIssuedTo = txtInitialInvoiceSightedIssuedTo.Text.Trim();
            objKYC.ThirdPartyInvoiceNo = txtThirdPartyInvoiceNo.Text.Trim();
            objKYC.ThirdPartyInvoiceDate = txtThirdPartyInvoiceDate.Text.Trim();
            objKYC.ThirdPartyInvoiceIssuedBy = txtThirdPartyInvoiceIssuedBy.Text.Trim();
            objKYC.ThirdPartyAddress = txtThirdPartyAddress.Text.Trim();
            if (ddlRelationshipBtnEntity.SelectedIndex != 0)
            {
                objKYC.RelationshipBTNEntity = ddlRelationshipBtnEntity.SelectedItem.Text.Trim();
            }
            if (ddlRelationshipBtnEntity.SelectedIndex== 3)
            {
                objKYC.RelationshipBTNEntity = txtIfOtherRelationship.Text.Trim();
            }
            if (ddlBusinessOwnership.SelectedIndex != 0)
            {
                objKYC.BusinessOwnership = ddlBusinessOwnership.SelectedItem.Text.Trim();
            }
            if (ddlLevelOfBusinessActivity.SelectedIndex != 0)
            {
                objKYC.LevelOfBusinssActivity = ddlLevelOfBusinessActivity.SelectedItem.Text.Trim();
            }
            objKYC.NoOfEmployees = txtNoOfEmployee.Text.Trim();
            if (ddlEntityType.SelectedIndex != 0)
            {
                objKYC.EntityType = ddlEntityType.SelectedValue.Trim().ToString();
            }
            objKYC.TelephoneNoOfCAFirm = txtTelNoOfCAFirm.Text.Trim().ToString();
            objKYC.NoOfYearsInCurrentEmployment = txtNoOfYearsInCurrentEmployment.Text.Trim().ToString();
            objKYC.NameRVComment = txtRvComment.Text.Trim().ToString();
          
            string sBusinessEquipSighted = "";
            if (chklBusinessEquipSighted.Items.Count > 0)
            {
                foreach (ListItem li in chklBusinessEquipSighted.Items)
                {
                    if (li.Text.Trim() == "Others" && li.Selected == true)
                        sBusinessEquipSighted+= li.Value + "," + txtIfOtherBusinessEquipment.Text.Trim();
                    else
                        if (li.Selected == true)
                            sBusinessEquipSighted += li.Value + ",";
                }
            }

            objKYC.BusinessEquipSighted = sBusinessEquipSighted.TrimEnd(',');
            objKYC.VerifierName = txtVerifierName.Text.Trim();
            
            objKYC.Address = txtAddress.Text.Trim();
            objKYC.PhoneNo = txtPhone.Text.Trim();
            objKYC.MobileNo = txtMobile.Text.Trim();
            objKYC.EmailId = txtEmail.Text.Trim();
            objKYC.DateOfBirth = txtDOB.Text.Trim();
            if (ddlMaritalStatus.SelectedIndex != 0)
            {
                objKYC.MaritalStatus = ddlMaritalStatus.SelectedItem.Text.Trim();
            }
            if (ddlNamePlateDisplay.SelectedIndex != 0)
            {
                objKYC.NameDisplayOnNameBoard = ddlNamePlateDisplay.SelectedItem.Text.Trim();
            }
            objKYC.RelationshipWithApplicant = txtRelationshipWithApp.Text.Trim();
            objKYC.StayingSinceAtResi = txtStayingSinceAtResi.Text.Trim();
            if (ddlStatusOfDematAcct.SelectedIndex != 0)
            {
                objKYC.StatusOfDematAcct = ddlStatusOfDematAcct.SelectedItem.Text.Trim();
            }
            objKYC.NameOfDematAcct = txtNameOfDematAcct.Text.Trim();
            objKYC.DoingBroken = txtDoBrokeOtherThanSSKI.Text.Trim();
            if (ddlAttituteOfContactPerson.SelectedIndex != 0)
            {
                objKYC.AttituteOfPersonContacted = ddlAttituteOfContactPerson.SelectedItem.Text.Trim();
            }
            if (ddlRating.SelectedIndex != 0)
            {
                objKYC.Rating = ddlRating.SelectedItem.Text.Trim();
            }
            if (ddlStatus.SelectedIndex != 0)
            {
                objKYC.Status = ddlStatus.SelectedItem.Text.Trim();


                objKYC.CaseStatusId = ddlStatus.SelectedValue.ToString();
            }
           
            objKYC.SendDate = txtSendDate.Text.Trim();
            objKYC.Product = txtProduct.Text.Trim();
            objKYC.NameOfVerifyAgent = txtNameOfVerificationAgent.Text.Trim();
            objKYC.ResidenceAddress = txtResidenceAddress.Text.Trim();
            objKYC.ResiPincode = txtResiPincode.Text.Trim();
            objKYC.ResiTelNo = txtResiTelNo.Text.Trim();
            objKYC.ResiLandmark = txtResiLandmark.Text.Trim();
            objKYC.PermanentAddress = txtPermanentAddress.Text.Trim();
            objKYC.PermanentPincode = txtPermanentPincode.Text.Trim();
            objKYC.PermanentTelNo = txtPermanentTelNo.Text.Trim();
            objKYC.BusinessOccupDetail = txtBusiOccupationDtl.Text.Trim();
            if (ddlPlaceVisited.SelectedIndex != 0)
            {
                objKYC.PlaceVisited = ddlPlaceVisited.SelectedItem.Text.Trim();
            }
            if (ddlPlaceVisited.SelectedIndex == 3)
            {
              objKYC.PlaceVisited = txtIfOthersSpecify.Text.Trim();
            }
            if (ddlNamePlateOfAppSighted.SelectedIndex != 0)
            {
                objKYC.NamePlateofApplicantSighted = ddlNamePlateOfAppSighted.SelectedItem.Text.Trim();
            }
            objKYC.AreaOfResidence = txtAreaOfResidence.Text.Trim();
            if (ddlLocatingAddress.SelectedIndex != 0)
            {
                objKYC.LocatingAddress = ddlLocatingAddress.SelectedItem.Text.Trim();
            }
            objKYC.IfOfficeBusiActivitySeen = txtIfOfficeBusiActivity.Text.Trim();
            objKYC.DescriptionOfResi = txtDescriptionOfResi.Text.Trim();
            objKYC.GeneralComment = txtGeneralComments.Text.Trim();
            objKYC.NameOfAccount = txtNameOfAccount.Text.Trim();
            objKYC.RequestNo = txtRequestNo.Text.Trim();
            objKYC.NameOfCAFirm = txtNameOfCAFirm.Text.Trim();
            objKYC.AddressOfCAFirm = txtAddressOfCAFirm.Text.Trim();
            if (ddlDoesFirmExistAtAddress.SelectedIndex != 0)
            {
                objKYC.DoesFirmExistAtAddress = ddlDoesFirmExistAtAddress.SelectedItem.Text.Trim();
            }
            if (ddlIsFirmACAFirm.SelectedIndex != 0)
            {
                objKYC.IsFirmCAFirm = ddlIsFirmACAFirm.SelectedItem.Text.Trim();
            }
            objKYC.NameOfPersonWhoIssuedCACertificate = txtNameOfPersonWhoIssuedCACertificate.Text.Trim();
            if (ddlIsPersonOneOfPractising.SelectedIndex != 0)
            {
                objKYC.IsPersonPractisingCasInFirm = ddlIsPersonOneOfPractising.SelectedItem.Text.Trim();
            }
            if (ddlWasPersonSpokenTo.SelectedIndex != 0)
            {
                objKYC.WasPersonSpokenTo = ddlWasPersonSpokenTo.SelectedItem.Text.Trim();
            }
            if (ddlConfirmCACertificateIssued.SelectedIndex != 0)
            {
                objKYC.ConfirmCACertificateIssued = ddlConfirmCACertificateIssued.SelectedItem.Text.Trim();
            }
            objKYC.InConclusiveReason = txtIfInconclusiveReason.Text.Trim();
            objKYC.NameOnSignBoard = txtNameOnSignBoard.Text.Trim();
            if (ddlProprietorPartner.SelectedIndex != 0)
            {
                objKYC.HowTheConcernIsRelated = ddlProprietorPartner.SelectedValue.ToString();
            }
            objKYC.ConcernRelatedName = txtName.Text.Trim();
            if (ddlFamilyMemberIs.SelectedIndex != 0)
            {
                objKYC.FamilyMemberIs = ddlFamilyMemberIs.SelectedValue.ToString();
            }
            objKYC.FamilyMemberName = txtNameIs.Text.Trim();
            objKYC.FamilyMemberRelationship = txtRelationshipIs.Text.Trim();
            if (ddlHavingDematAcwithOtherInstitution.SelectedIndex != 0)
            {
                objKYC.HavingDematAccountWithOtherInstitution = ddlHavingDematAcwithOtherInstitution.SelectedValue.ToString();
            }
            objKYC.NameOfDP = txtIfYesThenNameOfDP.Text.Trim();
            if (ddlNamePlateOfAppSighted.SelectedIndex != 0)
            {
                objKYC.NamePlateofApplicantSighted = ddlNamePlateOfAppSighted.SelectedValue.ToString();
            }
            if (ddlHavingSMEAccountWithOtherInstitution.SelectedIndex != 0)
            {
                objKYC.HavingSMEAccountWithOtherInstitution = ddlHavingSMEAccountWithOtherInstitution.SelectedValue.ToString();
            }
            objKYC.NameOfInstitution = txtNameOfInstitution.Text.Trim();
            objKYC.NameRVComment = txtRvComment.Text.Trim();

            sMsg = objKYC.InsertKYCVerificationEntry();
            InsertTeleCallLog();
            if (sMsg != "")
            {
                  pnlMsg.Visible = true;
                  tblMsg.Visible = true;
                  lblMsg.Text = sMsg.Trim();
                  lblMsg.ForeColor = System.Drawing.Color.Red;
                  iCount = 1;
            }         
        }
        catch (Exception ex)
        {
            pnlMsg.Visible = true;
            tblMsg.Visible = true;
            lblMsg.ForeColor = System.Drawing.Color.Red;
            lblMsg.Text = "Error:" + ex.Message;
        }
    if (iCount == 1)
    {
        Response.Redirect("KYC_VerificationView.aspx?Msg=" + lblMsg.Text);
    }
        
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("KYC_VerificationView.aspx");
    }

    private void FillStatus()
    {
        DataTable dtStatus = new DataTable();
        dtStatus = objKYC.GetCaseStatus();
        ddlStatus.DataTextField = "STATUS_NAME";
        ddlStatus.DataValueField = "CASE_STATUS_ID";
        ddlStatus.DataSource = dtStatus;
        ddlStatus.DataBind();

        ListItem lstItem1 = new ListItem("NA", "");
        ddlStatus.Items.Insert(0, lstItem1);
    }

    public void funShowPanel()
    {
        CGet objCGet = new CGet();
        string strClientID = Session["ClientId"].ToString();
        string strActivityID = Session["ActivityId"].ToString();
        string strProductID = Session["ProductId"].ToString();
        string strVerificationType = "1";
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
                    objPlaceHolder = (PlaceHolder)(tblKYCVerification.Rows[0].Cells[0].FindControl(strPlaceHolderName));
                    if (objPlaceHolder != null)
                    {

                        Panel objPanel = new Panel();
                        //objPanel.EnableViewState = false;
                        objPanel = (Panel)(tblKYCVerification.Rows[1].Cells[0].FindControl(strPanelName));
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

    
}
