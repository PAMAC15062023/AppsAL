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

public partial class CC_CC_ResidenceVerification : System.Web.UI.Page
{
    string verificationType = "RV";
    CGet objCGet = new CGet();
    CCreditCardVerification objCCVer = new CCreditCardVerification();
    //
    private CCreditCard objCC = new CCreditCard();
    DataSet dsCC = new DataSet();
    DataSet dsAttempt = new DataSet();

    //funShowPanel();
    protected void Page_Init(object sender, EventArgs e)
    {
        funShowPanel();
    }
    protected void Page_Load(object sender, EventArgs e)
    {
       
        //pnlOutcome.Visible = false;
        //pnlDeclineReason.Visible = false;
        if (!IsPostBack)
        {
            try
            {
                //Comented By Gargi at 31-May-2007

                //if (Session["isAdd"].ToString() != "1")
                //    Response.Redirect("NoAccess.aspx");
                //End

                //To Show the Panels add By Manoj            
                funShowPanel();
                //End
                hdnTransStart.Value = DateTime.Now.ToString();//"dd/MM/yyyy hh:mm:ss tt");
                ///FOR CASE DETAIL------------------------------
                if (Context.Request.QueryString["CaseID"] != null && Context.Request.QueryString["CaseID"] != "" && Context.Request.QueryString["VerTypeId"] != null && Context.Request.QueryString["VerTypeId"] != "")
                {
                    //Modified By Gargi at 31-May-2007
                    if (Session["isEdit"].ToString() != "1")

                        ISEditFalse();
                    //Response.Redirect("NoAccess.aspx");

                    txtAgencyCode.Focus();

                    string sCaseId = Request.QueryString["CaseID"].ToString();
                    hidCaseID.Value = sCaseId;
                    string sVerifyTypeId = Request.QueryString["VerTypeId"].ToString();
                    hidVerificationTypeID.Value = sVerifyTypeId;
                    if ((sVerifyTypeId == "1") || (sVerifyTypeId == "RV"))  //for RV
                        lblHead.Text = "Residence Verification";
                    else if ((sVerifyTypeId == "10") || (sVerifyTypeId == "PRV"))
                        lblHead.Text = "Permanent Residence Verification";

                    Session["CaseID"] = Request.QueryString["CaseID"].ToString();
                    //END
                    dsCC = objCC.GetCreditCaseEntry(sCaseId, Session["CentreId"].ToString(), Session["ClientId"].ToString());
                    dsAttempt = objCCVer.GetAttemptDtl(sCaseId, sVerifyTypeId);
                    //START Attempt Details ------------------------------------
                    if (sCaseId != "")
                    {
                        txtAttemptDate1.Text = DateTime.Now.ToString("dd/MM/yyyy");
                        txtAttemptDate2.Text = DateTime.Now.ToString("dd/MM/yyyy");
                        txtAttemptDate3.Text = DateTime.Now.ToString("dd/MM/yyyy");

                        if (dsAttempt.Tables[0].Rows.Count > 0)
                        {
                            //ddlCaseStatus.SelectedValue = dsAttempt.Tables[0].Rows[0]["Case_Status_ID"].ToString();

                            for (int i = 0; i < dsAttempt.Tables[0].Rows.Count; i++)
                            {
                                if (i == 0)
                                {
                                    string sTmp = dsAttempt.Tables[0].Rows[i]["Attempt_Date_Time"].ToString();
                                    string[] arrAttemptDateTime = sTmp.Split(' ');
                                    txtAttemptDate1.Text = Convert.ToDateTime(arrAttemptDateTime[0].ToString()).ToString("dd/MM/yyyy");
                                    txtAttemptTime1.Text = Convert.ToDateTime(arrAttemptDateTime[1].ToString()).ToString("hh:mm");
                                    ddlAttemptTimeType1.SelectedValue = arrAttemptDateTime[2].ToString();
                                    txtAttemptRemark1.Text = dsAttempt.Tables[0].Rows[i]["Remark"].ToString();
                                }
                                if (i == 1)
                                {
                                    string sTmp = dsAttempt.Tables[0].Rows[i]["Attempt_Date_Time"].ToString();
                                    string[] arrAttemptDateTime = sTmp.Split(' ');
                                    txtAttemptDate2.Text = Convert.ToDateTime(arrAttemptDateTime[0].ToString()).ToString("dd/MM/yyyy");
                                    txtAttemptTime2.Text = Convert.ToDateTime(arrAttemptDateTime[1].ToString()).ToString("hh:mm");
                                    ddlAttemptTimeType2.SelectedValue = arrAttemptDateTime[2].ToString();
                                    txtAttemptRemark2.Text = dsAttempt.Tables[0].Rows[i]["Remark"].ToString();
                                }
                                if (i == 2)
                                {
                                    string sTmp = dsAttempt.Tables[0].Rows[i]["Attempt_Date_Time"].ToString();
                                    string[] arrAttemptDateTime = sTmp.Split(' ');
                                    txtAttemptDate3.Text = Convert.ToDateTime(arrAttemptDateTime[0].ToString()).ToString("dd/MM/yyyy");
                                    txtAttemptTime3.Text = Convert.ToDateTime(arrAttemptDateTime[1].ToString()).ToString("hh:mm");
                                    ddlAttemptTimeType3.SelectedValue = arrAttemptDateTime[2].ToString();
                                    txtAttemptRemark3.Text = dsAttempt.Tables[0].Rows[i]["Remark"].ToString();
                                }
                            }
                           
                        }
                       
                    }
                   
                    //END Attempt Details ------------------------------------
                    ///START CASE DETAIL------------------------------------
                    OleDbDataReader oledbReadCaseDtl;
                    oledbReadCaseDtl = objCCVer.GetCaseDetail(Request.QueryString["CaseID"].ToString());
                    if (oledbReadCaseDtl.Read())
                    {
                        txtAppName.Text = oledbReadCaseDtl["Full_Name"].ToString();
                        txtRefNo.Text = oledbReadCaseDtl["Ref_No"].ToString();
                        txtResAddress.Text = oledbReadCaseDtl["RES_Address"].ToString();
                        txtPincode.Text = oledbReadCaseDtl["RES_PIN_CODE"].ToString();
                        txtLandmark.Text = oledbReadCaseDtl["RES_LAND_MARK"].ToString();
                        txtTelPPNormal.Text = oledbReadCaseDtl["RES_PHONE"].ToString();
                        txtMobile.Text = oledbReadCaseDtl["MOBILE"].ToString();
                        txtOfficeAddress.Text = oledbReadCaseDtl["OFFICE_ADDRESS"].ToString();
                        txtVerOfficePhone.Text = oledbReadCaseDtl["OFFICE_PHONEEXTN"].ToString();
                        txtPerAddress.Text = oledbReadCaseDtl["Permanent_ADDRESS"].ToString(); //add for view/edit                    
                        //if (oledbReadCaseDtl["DOB"].ToString().Trim() != "")
                        //    txtDOB.Text = Convert.ToDateTime(oledbReadCaseDtl["DOB"].ToString()).ToString("dd-MMM-yyyy");
                        //else
                        //    txtDOB.Text = "";
                        txtDesignationAtOffice.Text = oledbReadCaseDtl["DESIGNATION"].ToString();

                        if (oledbReadCaseDtl["Case_Rec_DateTime"].ToString().Trim() != "")
                            txtInitiationDate.Text = Convert.ToDateTime(oledbReadCaseDtl["Case_Rec_DateTime"].ToString()).ToString("dd/MM/yyyy");
                        else
                        {
                            txtInitiationDate.Text = "";
                        }
                     }
                    oledbReadCaseDtl.Close();
                    ///END CASE DETAIL------------------------------------
                }
                txtAmountDefault.Text = "0";
                

                ///-------------------------------------------------------
                //////START FOR RESIDENTIAL VERIFICATION(CPV_CC_VERI_DESCRIPTION) CASE DETAIL------------------
                if (Context.Request.QueryString["CaseID"] != null && Context.Request.QueryString["CaseID"] != "" && Context.Request.QueryString["VerTypeId"] != null && Context.Request.QueryString["VerTypeId"] != "")
                {
                    OleDbDataReader oledbCaseDescRead;
                    oledbCaseDescRead = objCCVer.GetCaseVerDescriptionRV(Request.QueryString["CaseID"].ToString(), Request.QueryString["VerTypeId"].ToString());
                    if (oledbCaseDescRead.Read())
                    {
                        ddlTelPPNormal.SelectedValue = oledbCaseDescRead["PP_NORMAL"].ToString();
                        //For Qualification dropdown---------------------
                        //////add by santosh shelar put the value other quali 11-09-08//////// 
                        string sQual = oledbCaseDescRead["QUALIFICATION"].ToString();
                        if (sQual.Trim() != "")
                        {
                            string[] arrQual = sQual.Split(':');
                        if (arrQual.Length > 0)
                            {
                                //if (arrQual[0].ToString() == "Others" && arrQual.Length > 1)
                                 if(arrQual[0].ToString() != "Others" && arrQual.Length >= 1)
                                 {
                                     ddlQualification.SelectedValue = arrQual[0].ToString();
                                    
                                 }
                                else if (arrQual[0].ToString() == "Others" || arrQual.Length >= 1)
                                        
                                {
                                    ddlQualification.SelectedValue = "Others";
                                    txtOtherQualification.Text = sQual.Remove(0,7).ToString(); 
                                }
                              
                            }
                                else
                                {
                                    ddlQualification.SelectedValue = arrQual[0].ToString();
                                }
                            
                        }
                        //--------------------------------------------------

                        //////For Time curr---------------
                        string sTmp = oledbCaseDescRead["TIME_AT_CURR_Y_M"].ToString();
                        if (sTmp.Trim() != "")
                        {
                            string[] arrTimeAtCurrY_M = sTmp.Split('.');
                            txtTimeCurrYrs.Text = arrTimeAtCurrY_M[0].ToString();
                            if (arrTimeAtCurrY_M.Length > 1)
                                txtTimeCurrMths.Text = arrTimeAtCurrY_M[1].ToString();
                        }
                        /////////////------------------------

                        //For Marital status dropdown---------------------
                        string sMarStatus = oledbCaseDescRead["MARITAL_STATUS"].ToString();
                        if (sMarStatus.Trim() != "")
                        {
                            string[] arrMarStatus = sMarStatus.Split('+');
                            if (arrMarStatus.Length > 0)
                            {
                                if (arrMarStatus[0].ToString() == "Other" && arrMarStatus.Length > 1)
                                {
                                    ddlMaritalStatus.SelectedValue = "Other";
                                    txtOtherMaritalStatus.Text = arrMarStatus[1].ToString();
                                }
                                else
                                {
                                    ddlMaritalStatus.SelectedValue = arrMarStatus[0].ToString();
                                }
                            }
                        }
                        //--------------------------------------------------

                        ddlIfSpouseWorking.SelectedValue = oledbCaseDescRead["IS_SPOUSE_WORKING"].ToString();
                        txtSpouseCompanyName.Text = oledbCaseDescRead["S_COMPANY_NAME"].ToString();
                        txtSpouseSalary.Text = oledbCaseDescRead["S_SALARY"].ToString();
                        txtSpouseTelephoneNo.Text = oledbCaseDescRead["S_TELEPHONE"].ToString();
                        txtNoDependent.Text = oledbCaseDescRead["NO_OF_DEPENDENT"].ToString();
                        ddlVehicleType.SelectedValue = oledbCaseDescRead["VEHICLE_TYPE"].ToString();
                        txtVehicleMake.Text = oledbCaseDescRead["VEHICLE_MAKE"].ToString();
                        //for working and children------02/08/2007----
                        txtWorking.Text = oledbCaseDescRead["WORKING"].ToString();
                        txtChildren.Text = oledbCaseDescRead["CHILDREN"].ToString();
                        ///---------
                        //For Vehicle IS dropdown---------------------
                        string sVehicleIs = oledbCaseDescRead["VEHICLE_IS"].ToString();
                        if (sVehicleIs.Trim() != "")
                        {
                            string[] arrVehicleIs = sVehicleIs.Split('+');
                            if (arrVehicleIs.Length > 0)
                            {
                                if (arrVehicleIs[0].ToString() == "Others(specify)" && arrVehicleIs.Length > 1)
                                {
                                    ddlVehicleIs.SelectedValue = "Others(specify)";
                                    txtOtherVehicleIs.Text = arrVehicleIs[1].ToString();
                                }
                                else
                                {
                                    ddlVehicleIs.SelectedValue = arrVehicleIs[0].ToString();
                                }
                            }
                        }
                        //--------------------------------------------------

                        //txtOtherVehicleIs.Text = oledbCaseDescRead["VEHICLE_OTHER"].ToString();
                        ddlCreditCards.SelectedValue = oledbCaseDescRead["IS_CREDIT_CARD"].ToString();
                        txtCardType.Text = oledbCaseDescRead["CARD_TYPE"].ToString();
                        txtCardNo.Text = oledbCaseDescRead["CARD_NO"].ToString();
                        txtCardLimit.Text = oledbCaseDescRead["CARD_LIMIT"].ToString();
                        txtCardExpiry.Text = oledbCaseDescRead["CARD_EXPIRY"].ToString();
                        txtAppAvailbleAt.Text = oledbCaseDescRead["APPLICANT_AVAILABILITY"].ToString();
                        //////For Time curr Resi---------------
                        string sTmpTimeCurrResi = oledbCaseDescRead["TIME_AT_CURR_RESIDANCE"].ToString();
                        if (sTmpTimeCurrResi.Trim() != "")
                        {
                            string[] arrTimeAtCurrResiY_M = sTmpTimeCurrResi.Split('.');
                            txtTimeCurrResYrs.Text = arrTimeAtCurrResiY_M[0].ToString();
                            if (arrTimeAtCurrResiY_M.Length > 1)
                                txtTimeCurrResMths.Text = arrTimeAtCurrResiY_M[1].ToString();
                        }
                        /////////////------------------------
                        txtApplicantWorkAt.Text = oledbCaseDescRead["APPLICANT_WORKS_AT"].ToString();

                        //For verified from dropdown---------------------
                        string sVerifyFrom = oledbCaseDescRead["VERIFIED_NEIGHBOUR"].ToString();
                        if (sVerifyFrom.Trim() != "")
                        {
                            string[] arrVerifyFrom = sVerifyFrom.Split('+');
                            if (arrVerifyFrom.Length > 0)
                            {
                                if (arrVerifyFrom[0].ToString() == "Others(specify)" && arrVerifyFrom.Length > 1)
                                {
                                    ddlVerifiedFrom.SelectedValue = "Others(specify)";
                                    txtOtherVerified.Text = arrVerifyFrom[1].ToString();
                                }
                                else
                                {
                                    ddlVerifiedFrom.SelectedValue = arrVerifyFrom[0].ToString();
                                }
                            }
                        }
                        //--------------------------------------------------

                        txtApproxArea.Text = oledbCaseDescRead["APPROXIMATE_AREA"].ToString();
                        ddlGeneralApp.SelectedValue = oledbCaseDescRead["GENRAL_APPEARANCE"].ToString();
                        ddlLocatingAdd.SelectedValue = oledbCaseDescRead["LOCATING_ADDRESS"].ToString();
                        ///For AssetVisible Checkboxes---------------------------------------------------
                        string sTmpAssetVisible = oledbCaseDescRead["ASSETS_VISIBLE"].ToString();
                        string[] arrAssetVisible = sTmpAssetVisible.Split(',');
                        int iOtherAssetCtr = 0;
                        if (arrAssetVisible.Length > 0)
                        {
                            for (int i = 0; i < arrAssetVisible.Length; i++)
                            {
                                foreach (ListItem li in chkAssetsVisible.Items)
                                {
                                    if (li.Value == arrAssetVisible.GetValue(i).ToString())
                                        li.Selected = true;
                                    if (arrAssetVisible.GetValue(i).ToString() == "Others(specify)")
                                    {
                                        iOtherAssetCtr = i;
                                    }
                                }
                            }
                        }
                        for (int j = iOtherAssetCtr + 1; j < arrAssetVisible.Length; j++)
                        {
                            txtOtherAssetVisible.Text += arrAssetVisible.GetValue(j) + ",";
                        }
                        ////--------------------------------------------------------------------
                        
                        ddlVisitProof.SelectedValue = oledbCaseDescRead["PROOF_OF_VISIT_COLLECTED"].ToString();
                        ddlRouteMap.SelectedValue = oledbCaseDescRead["ROUTE_MAP_DRAWN"].ToString();
                        ddlTPCDone.SelectedValue = oledbCaseDescRead["TPC_DONE"].ToString();
                        txtTPCDetail.Text = oledbCaseDescRead["TPC_DETAILS"].ToString();
                        txtAnyInfo.Text = oledbCaseDescRead["ANY_OTHER_INFO_OBT"].ToString();
                        ddlAddConfirmation.SelectedValue = oledbCaseDescRead["ADRESS_CONFIRMATION"].ToString();
                        txtContactability.Text = oledbCaseDescRead["CONTACTABILITY"].ToString();
                        txtConfirmationApp.Text = oledbCaseDescRead["CONFIRMATION_IF_APPLICANT_MET"].ToString();
                        txtProfile.Text = oledbCaseDescRead["PROFILE"].ToString();
                        txtReputation.Text = oledbCaseDescRead["REPUTATION"].ToString();
                        txtPersonContacted.Text = oledbCaseDescRead["PERSON_CONTACTED_MET"].ToString();
                        txtIssuingBank.Text = oledbCaseDescRead["ISSUING_BANK"].ToString();
                        //txtCooperativeCustomer.Text = oledbCaseDescRead["CUSTOMER_COOPERATION"].ToString();
                        ddlCooperativeCustomer.SelectedValue = oledbCaseDescRead["CUSTOMER_COOPERATION"].ToString();
                        ddlConstructionOfResi.SelectedValue = oledbCaseDescRead["CONSTRUCTION_OF_RESIDANCE"].ToString();
                        ///For Exterior comments Checkboxes---------------------------------------------------
                        string sTmpExteriorComment = oledbCaseDescRead["COMMENTS_EXTERIORS"].ToString();
                        string[] arrExteriorComment = sTmpExteriorComment.Split(',');
                        int iOtherExtComment = 0;
                        if (arrExteriorComment.Length > 0)
                        {
                            for (int i = 0; i < arrExteriorComment.Length; i++)
                            {
                                foreach (ListItem li in chkExteriorComments.Items)
                                {
                                    if (li.Value == arrExteriorComment.GetValue(i).ToString())
                                        li.Selected = true;
                                    if (arrExteriorComment.GetValue(i).ToString() == "Others(P1. Specify)")
                                    {
                                        iOtherExtComment = i;
                                    }
                                }
                            }
                        }
                        for (int k = iOtherExtComment + 1; k < arrExteriorComment.Length; k++)
                        {
                            txtIfOtherExteriorComments.Text += arrExteriorComment.GetValue(k) + ",";
                        }
                        ////--------------------------------------------------------------------                    
                        //txtDoesAppStay.Text = oledbCaseDescRead["APPLICANT_STAYED_RESIDANCE"].ToString();
                        //if (oledbCaseDescRead["APPLICANT_STAYED_RESIDANCE"].ToString() == "Y")
                        //    ddlDoesAppStay.SelectedValue = "Yes";
                        //else
                        //    ddlDoesAppStay.SelectedValue = "No";
                        ddlDoesAppStay.SelectedValue = oledbCaseDescRead["APPLICANT_STAYED_RESIDANCE"].ToString();
                        txtApproxAgeOfApp.Text = oledbCaseDescRead["APPLICANT_AGE"].ToString();
                        txtNoOfFamilyMem.Text = oledbCaseDescRead["FAMILY_MEMBERS"].ToString();
                        ddlAppNameplateSight.SelectedValue = oledbCaseDescRead["NAMEPLATE_VISIBLE"].ToString();
                        txtOwenershipApp1.Text = oledbCaseDescRead["OWNERSHIP_APPLICANT_RESIDANCE_1"].ToString();
                        txtEmpStatus1.Text = oledbCaseDescRead["EMPLOYMENT_STATUS_1"].ToString();
                        txtOwenershipApp2.Text = oledbCaseDescRead["OWNERSHIP_APPLICANT_RESIDANCE_2"].ToString();
                        txtEmpStatus2.Text = oledbCaseDescRead["EMPLOYMENT_STATUS_2"].ToString();
                        //txtBankNameCC.Text = oledbCaseDescRead["BANK_NAME_CC"].ToString();
                        //txtProductName.Text = oledbCaseDescRead["PRODUCT_NAME"].ToString();
                        txtIfNeighRentedthenAmt.Text = oledbCaseDescRead["RENT_AMOUNT"].ToString();
                        txtPriorityCustomer.Text = oledbCaseDescRead["PRIORITY_CUSTOMER"].ToString();
                        txtSegment.Text = oledbCaseDescRead["SEGMENT"].ToString();
                        txtInfoRequired.Text = oledbCaseDescRead["INFO_REQUIRED"].ToString();
                        txtChangeAdd.Text = oledbCaseDescRead["CHANGE_IN_ADRESS"].ToString();
                        txtReasonForChange.Text = oledbCaseDescRead["REASON_FOR_CHANGE"].ToString();
                        //txtOutcome.Text = oledbCaseDescRead["OUTCOME"].ToString();
                        txtTrackNo.Text = oledbCaseDescRead["TRACK_NO"].ToString();
                        txtEntryPermitted.Text = oledbCaseDescRead["ENTRY_PERMITTED"].ToString();
                        txtAddConfBy.Text = oledbCaseDescRead["ADDRESS_CONFIRMED_BY"].ToString();
                        txtNoOfFamMemEarning.Text = oledbCaseDescRead["NO_OF_EARNING_FAMILY_MEMBER"].ToString();
                        txtOfficeTelephone.Text = oledbCaseDescRead["OFFICE_TELEPHONE"].ToString();
                        txtApproxValIfOwned.Text = oledbCaseDescRead["APROX_VALUE_IF_OWNED"].ToString();
                        txtBranch.Text = oledbCaseDescRead["BRANCH"].ToString();
                        txtInfoRefused.Text = oledbCaseDescRead["INFO_REFUSED"].ToString();
                        txtOccupation2.Text = oledbCaseDescRead["OCCUPATION"].ToString();
                        txtReasonForAddNotConfirm.Text = oledbCaseDescRead["REASON_ADD_NOT_CONFIRM"].ToString();
                        //modified by hemangi kambli on 23/7/2007 for Adding Other in DDL--
                        //ddlLocality.SelectedValue = oledbCaseDescRead["LOCALITY"].ToString(); 
                        //For Locality dropdown---------------------
                        string sLocality = oledbCaseDescRead["LOCALITY"].ToString();
                        if (sLocality.Trim() != "")
                        {
                            string[] arrLocality = sLocality.Split('+');
                            if (arrLocality.Length > 0)
                            {
                                if (arrLocality[0].ToString() == "Others" && arrLocality.Length > 1)
                                {
                                    ddlLocality.SelectedValue = "Others";
                                    txtOtherLocality.Text = arrLocality[1].ToString();
                                }
                                else
                                {
                                    ddlLocality.SelectedValue = arrLocality[0].ToString();
                                }
                            }
                        }
                        //--------------------------------------------------
                        //Temporary commented by hemangi kambli on 15-May-2007
                        //txtLocalityInfo.Text = oledbCaseDescRead["LOCALITY"].ToString();
                        //------------------------------------------------------------------
                        txtResultOfCalling.Text = oledbCaseDescRead["RESULT_CALLING"].ToString();
                        txtMismatchInResAdd.Text = oledbCaseDescRead["MISMATCH_RESI_ADD"].ToString();
                        txtIsAppKnownToPerson.Text = oledbCaseDescRead["IS_APP_KNOWN_PERSON"].ToString();
                        txtToWhomAddBelong.Text = oledbCaseDescRead["ADDRESS_BELONG"].ToString();
                        txtVerificationContactAt.Text = oledbCaseDescRead["VERIFICATION_CONDUCTED"].ToString();
                        txtAccomodation.Text = oledbCaseDescRead["ACCOMODATION"].ToString();
                        //txtInterior.Text = oledbCaseDescRead["INTERIOR"].ToString();
                        ///For Interior conditions Checkboxes---------------------------------------------------
                        string sTmpInteriorCondition = oledbCaseDescRead["INTERIOR"].ToString();
                        string[] arrInteriorCondition = sTmpInteriorCondition.Split(',');
                        int iOtherInteriorCondition = 0;
                        if (arrInteriorCondition.Length > 0)
                        {
                            for (int i = 0; i < arrInteriorCondition.Length; i++)
                            {
                                foreach (ListItem li in chkInterior.Items)
                                {
                                    if (li.Value == arrInteriorCondition.GetValue(i).ToString())
                                        li.Selected = true;
                                    if (arrInteriorCondition.GetValue(i).ToString() == "Others(P1. Specify)")
                                    {
                                        iOtherInteriorCondition = i;
                                    }
                                }
                            }
                        }
                        for (int k = iOtherInteriorCondition + 1; k < arrInteriorCondition.Length; k++)
                        {
                            txtIfOtherInteriorConditions.Text += arrInteriorCondition.GetValue(k) + ",";
                        }
                        ////--------------------------------------------------------------------  
                        //ddlInterior.SelectedValue = oledbCaseDescRead["INTERIOR"].ToString();
                        txtExterior.Text = oledbCaseDescRead["EXTERIOR"].ToString();
                        txtTPCBy.Text = oledbCaseDescRead["TPC_BY"].ToString();
                        txtObservation.Text = oledbCaseDescRead["OBSERVATION"].ToString();
                        txtTPC2.Text = oledbCaseDescRead["TPC2"].ToString();
                        txtPersonMet2.Text = oledbCaseDescRead["PERSON_MET2"].ToString();
                        txtAdd2.Text = oledbCaseDescRead["ADDRESS2"].ToString();
                        txtAppAge2.Text = oledbCaseDescRead["APPLICANT_AGE2"].ToString();
                        txtNoOfResAtHome2.Text = oledbCaseDescRead["NO_OF_RES_AT_HOME2"].ToString();
                        txtYearLiveAtAdd2.Text = oledbCaseDescRead["YEARS_LIVE_AT_ADD2"].ToString();
                        txtSpouseSalary.Text = oledbCaseDescRead["S_SALARY"].ToString();
                        txtResStatus2.Text = oledbCaseDescRead["RESIDANCE_STATUS2"].ToString();
                        txtDOB.Text = oledbCaseDescRead["App_dob_approx_Age"].ToString();
                        

                       
                    }
                    
                    oledbCaseDescRead.Close();
                    //////END FOR RESIDENTIAL VERIFICATION(CPV_CC_VERI_DESCRIPTION) CASE DETAIL------------------
                    
                    //////Added By NAresh Sabbani/////////////////
                    OleDbDataReader oledbCaseSocRead;
                    oledbCaseSocRead = objCCVer.GetCaseVerSocietyRV(Request.QueryString["CaseID"].ToString(), Request.QueryString["vertypeid"].ToString());
                    if (oledbCaseSocRead.Read())
                    {
                        string sTmpSociety = oledbCaseSocRead["Type_Of_Society"].ToString() + "";
                        string[] arrScoiety = sTmpSociety.Split(',');
                        int iSociety = 0;
                        if (arrScoiety.Length > 0)
                        {
                            for (int i = 0; i < arrScoiety.Length; i++)
                            {
                                foreach (ListItem li in ChkTypeofSociety.Items)
                                {
                                    if (li.Value == arrScoiety.GetValue(i).ToString())
                                        li.Selected = true;
                                }
                            }
                        }
                        string sTmpOther = oledbCaseSocRead["Other_Facilities"].ToString() + "";
                        string[] arrOther = sTmpOther.Split(',');
                        int iOther = 0;
                        if (arrOther.Length > 0)
                        {
                            for (int i = 0; i < arrOther.Length; i++)
                            {
                                foreach (ListItem li in ChkOtherFacilities.Items)
                                {
                                    if (li.Value == arrOther.GetValue(i).ToString())
                                        li.Selected = true;
                                }
                            }
                        }
                        string sTmpMarket = oledbCaseSocRead["Market_Value"].ToString() + "";
                        string[] arrMarket = sTmpMarket.Split(',');
                        int iMarket = 0;
                        if (arrMarket.Length > 0)
                        {
                            for (int i = 0; i < arrMarket.Length; i++)
                            {
                                foreach (ListItem li in ChkMarketValue.Items)
                                {
                                    if (li.Value == arrMarket.GetValue(i).ToString())
                                        li.Selected = true;
                                }
                            }
                        }
                        string sTmpBuiltup = oledbCaseSocRead["Builtup_Area"].ToString() + "";
                        string[] arrBuiltup = sTmpBuiltup.Split(',');
                        int iBuiltup = 0;
                        if (arrBuiltup.Length > 0)
                        {
                            for (int i = 0; i < arrBuiltup.Length; i++)
                            {
                                foreach (ListItem li in ChkBuiltupArea.Items)
                                {
                                    if (li.Value == arrBuiltup.GetValue(i).ToString())
                                        li.Selected = true;
                                }
                            }
                        }
                        string sTmpNoOfFlats = oledbCaseSocRead["No_Of_Flats"].ToString() + "";
                        string[] arrNoOfFlats = sTmpNoOfFlats.Split(',');
                        int iNoOfFlats = 0;
                        if (arrNoOfFlats.Length > 0)
                        {
                            for (int i = 0; i < arrNoOfFlats.Length; i++)
                            {
                                foreach (ListItem li in ChkNoOfFlatsSociety.Items)
                                {
                                    if (li.Value == arrNoOfFlats.GetValue(i).ToString())
                                        li.Selected = true;
                                }
                            }
                        }
                        string sTmpBedroom = oledbCaseSocRead["Bedroom"].ToString() + "";
                        string[] arrBedroom = sTmpBedroom.Split(',');
                        int iBedroom = 0;
                        if (arrBedroom.Length > 0)
                        {
                            for (int i = 0; i < arrBedroom.Length; i++)
                            {
                                foreach (ListItem li in ChkBedroom.Items)
                                {
                                    if (li.Value == arrBedroom.GetValue(i).ToString())
                                        li.Selected = true;
                                }
                            }
                        }
                        string sTmpNegative = oledbCaseSocRead["Negative_Area"].ToString() + "";
                        string[] arrNegative = sTmpNegative.Split(',');
                        int iNegative = 0;
                        if (arrNegative.Length > 0)
                        {
                            for (int i = 0; i < arrNegative.Length; i++)
                            {
                                foreach (ListItem li in ChkNegativeAreaSociety.Items)
                                {
                                    if (li.Value == arrNegative.GetValue(i).ToString())
                                        li.Selected = true;
                                }
                            }
                        }
                        TxtDetailstakenbytpc.Text = oledbCaseSocRead["Tpc_Name"].ToString() + "";
                        TxtPhoneNumbersoftpc.Text = oledbCaseSocRead["Tpc_Phone"].ToString() + "";
                        TxtHistory.Text = oledbCaseSocRead["History"].ToString() + "";
                        TxtNoOfEmployeesSociety.Text = oledbCaseSocRead["No_Of_Employee"].ToString() + "";
                        TxtRemarkSociey.Text = oledbCaseSocRead["Remark"].ToString() + "";
                    }

                    //////End Details Added By Naresh Sabbani//////////
                    
                    //////START FOR RESIDENTIAL VERIFICATION(CPV_CC_VERI_DESCRIPTION1) CASE DETAIL------------------
                    OleDbDataReader oledbCaseDesc1Read;
                    oledbCaseDesc1Read = objCCVer.GetCaseVerDescription1RV(Request.QueryString["CaseID"].ToString(), Request.QueryString["VerTypeId"].ToString());
                    if (oledbCaseDesc1Read.Read())
                    {
                        if (oledbCaseDesc1Read["PERMANENT_ADDRESS"].ToString() != "")
                            txtPerAddress.Text = oledbCaseDesc1Read["PERMANENT_ADDRESS"].ToString();
                        txtPerAddLandmark.Text = oledbCaseDesc1Read["LAND_MARK_OBSERVED"].ToString();
                        txtDesignationAtOffice.Text = oledbCaseDesc1Read["CONTACTED_PERSON_DESIGN"].ToString();
                        txtIncomeDoc.Text = oledbCaseDesc1Read["INCOME_DOC_SUBMITTED_WITH_APLICATION"].ToString();
                        txtNewInfoFERemark.Text = oledbCaseDesc1Read["FE_REMARK"].ToString();
                        txtAppCompName.Text = oledbCaseDesc1Read["CO_APP_NAME"].ToString();
                        txtPriorityCustomer.Text = oledbCaseDesc1Read["PRIORITY_CUSTOMER"].ToString();
                        txtInfoRequired.Text = oledbCaseDesc1Read["INFO_REQUIRED"].ToString();
                        txtRelationApplicant.Text = oledbCaseDesc1Read["RELATION_PERSON_CONTACTED"].ToString();
                        //ddlAddConfirmation.SelectedValue = oledbCaseDesc1Read["IS_ADD_NOT_CONFIRMED"].ToString();
                        txtUntraceableReason.Text = oledbCaseDesc1Read["UNREACHABLE_REASON"].ToString();
                        txtVerificationContactAt.Text = oledbCaseDesc1Read["VERIFICATION_CONDUCTED_AT"].ToString();
                        txtLandmark.Text = oledbCaseDesc1Read["LAND_MARK_OBSERVED"].ToString();
                        txtAppCompName.Text = oledbCaseDesc1Read["COMPANY_NAME"].ToString();
                        txtOfficeExtn.Text = oledbCaseDesc1Read["OFFICE_EXT"].ToString();
                        txtDesignationAtOffice.Text = oledbCaseDesc1Read["DESIGNATION"].ToString();
                        //txtDOB.Text = oledbCaseDesc1Read["DOB_APPLICANT"].ToString();
                        txtAppAvaAtHome.Text = oledbCaseDesc1Read["APPLICANT_IS_AVAILABLE_AT"].ToString();
                        ddlPoliticalPic.SelectedValue = oledbCaseDesc1Read["Affilation_Political_Party_Seen"].ToString();

                        //For RESIDANCE_STATUS dropdown---------------------
                        string sResiStatus = oledbCaseDesc1Read["RESIDANCE_STATUS"].ToString();
                        if (sResiStatus.Trim() != "")
                        {
                            string[] arrResiStatus = sResiStatus.Split('+');
                            if (arrResiStatus.Length > 0)
                            {
                                if (arrResiStatus[0].ToString() == "Others" && arrResiStatus.Length > 1)
                                {
                                    ddlResidenceIsStatus.SelectedValue = "Others";
                                    txtOtherResidenceIsStatus.Text = arrResiStatus[1].ToString();
                                }
                                else
                                {
                                    ddlResidenceIsStatus.SelectedValue = arrResiStatus[0].ToString();
                                }
                            }
                        }
                        //--------------------------------------------------

                        txtOfficeAddress.Text = oledbCaseDesc1Read["OFFICE_ADDRESS"].ToString();
                        txtStayTPC2.Text = oledbCaseDesc1Read["STAY"].ToString();
                        txtPerAddPinCode.Text = oledbCaseDesc1Read["PINCODE"].ToString();
                        //txtNeighbourRef.Text = oledbCaseDesc1Read["NEIGHBOUR_REFERENCE"].ToString();
                        ddlNeighbourRef.SelectedValue = oledbCaseDesc1Read["NEIGHBOUR_REFERENCE"].ToString();
                        //For RESIDANCE_IS dropdown---------------------
                        string sResiIs = oledbCaseDesc1Read["RESIDANCE_IS"].ToString();
                        if (sResiIs.Trim() != "")
                        {
                            string[] arrResiIs = sResiIs.Split('+');
                            if (arrResiIs.Length > 0)
                            {
                                if (arrResiIs[0].ToString() == "Others" && arrResiIs.Length > 1)
                                {
                                    ddlNeighResidenceIs.SelectedValue = "Others";
                                    txtOtherResidenceIsStatus.Text = arrResiIs[1].ToString();
                                }
                                else
                                {
                                    ddlNeighResidenceIs.SelectedValue = arrResiIs[0].ToString();
                                }
                            }
                        }
                        //--------------------------------------------------
                        
                    }
                    
                    oledbCaseDesc1Read.Close();
                    //////END FOR RESIDENTIAL VERIFICATION(CPV_CC_VERI_DESCRIPTION1) CASE DETAIL------------------

                    //////START FOR RESIDENTIAL VERIFICATION(CPV_CC_VERI_OTHER_DETAILS) CASE DETAIL------------------
                    OleDbDataReader oledbCaseVerOtherDtlRead;
                    oledbCaseVerOtherDtlRead = objCCVer.GetCaseVerOtherDtlRV(Request.QueryString["CaseID"].ToString(), Request.QueryString["VerTypeId"].ToString());
                    if (oledbCaseVerOtherDtlRead.Read())
                    {
                        txtRelationApplicant.Text = oledbCaseVerOtherDtlRead["REL_WITH_APPLICANT"].ToString();
                        txtPersonContacted.Text = oledbCaseVerOtherDtlRead["PERSON_CONTACTED"].ToString();
                        ///
                        //txtDoesAppStay.Text = oledbCaseVerOtherDtlRead["IS_RESIDANT"].ToString();
                        //txtPerAddress.Text = oledbCaseVerOtherDtlRead["PERMANENT_ADDRESS"].ToString();
                        ddlNegativeArea.SelectedValue = oledbCaseVerOtherDtlRead["IS_NEGATIVE_AREA"].ToString();
                        ddlOCL.SelectedValue = oledbCaseVerOtherDtlRead["IS_OCL"].ToString();

                        //For RES_TYPE dropdown---------------------
                        string sResiType = oledbCaseVerOtherDtlRead["RES_TYPE"].ToString();
                        if (sResiType.Trim() != "")
                        {
                            string[] arrResiType = sResiType.Split('+');
                            if (arrResiType.Length > 0)
                            {
                                if (arrResiType[0].ToString() == "Others" && arrResiType.Length > 1)
                                {
                                    ddlTypeOfResidence.SelectedValue = "Others";
                                    txtOtherResiType.Text = arrResiType[1].ToString();
                                }
                                else
                                {
                                    ddlTypeOfResidence.SelectedValue = arrResiType[0].ToString();
                                }
                            }
                        }
                        //--------------------------------------------------

                        ddlAppNameplateSight.SelectedValue = oledbCaseVerOtherDtlRead["IS_APP_NAME_ON_DOOR"].ToString();
                        txtAgencyCode.Text = oledbCaseVerOtherDtlRead["AGENCY_NAME"].ToString();
                        
                        //ddlResidenceIsStatus.SelectedValue = oledbCaseVerOtherDtlRead["APPLICANT_IS_AVAILABLE_AT"].ToString();                    
                    }
                   
                    oledbCaseVerOtherDtlRead.Close();
                    //////END FOR RESIDENTIAL VERIFICATION(CPV_CC_VERI_OTHER_DETAILS) CASE DETAIL------------------
                    //////START FOR RESIDENTIAL VERIFICATION(CPV_CC_VERI_DETAILS) CASE DETAIL------------------
                    OleDbDataReader oledbCaseVerDtlRead;
                    oledbCaseVerDtlRead = objCCVer.GetCaseVerDtlRV(Request.QueryString["CaseID"].ToString(), Request.QueryString["VerTypeId"].ToString());
                    if (oledbCaseVerDtlRead.Read())
                    {
                        //txtOutcome.Text = oledbCaseVerDtlRead["DECLINED_CODE"].ToString();
                        ddlCaseStatus.DataBind();
                        if (oledbCaseVerDtlRead["CASE_STATUS_ID"].ToString().Trim() == "")
                            ddlCaseStatus.SelectedValue = "0";
                        else
                            ddlCaseStatus.SelectedValue = oledbCaseVerDtlRead["CASE_STATUS_ID"].ToString();

                        //ddlCaseStatus.SelectedValue = oledbCaseVerDtlRead["CASE_STATUS_ID"].ToString();
                        ddlOutcome.DataBind();
                        if (oledbCaseVerDtlRead["DECLINED_CODE"].ToString().Trim() == "")
                            ddlOutcome.SelectedValue = "0";
                        else
                            ddlOutcome.SelectedValue = oledbCaseVerDtlRead["DECLINED_CODE"].ToString();
                        txtDeclineReason.Text = oledbCaseVerDtlRead["DECLINED_REASON"].ToString();
                        //added by hemangi kambli to freeze the while updation.
                        if (ddlCaseStatus.SelectedItem.Text.Trim() == "Accept" || ddlCaseStatus.SelectedItem.Text.Trim() == "Positive" ||
                            ddlCaseStatus.SelectedItem.Text.Trim() == "Refer To Bank" || ddlCaseStatus.SelectedItem.Text.Trim() == "Neutral")
                        {
                            ddlOutcome.Enabled = false;
                            txtDeclineReason.Enabled = false;
                        }
                        else if (ddlCaseStatus.SelectedItem.Text.Trim() == "Decline" || ddlCaseStatus.SelectedItem.Text.Trim() == "Negative")
                        {
                            ddlOutcome.Enabled = true;
                            txtDeclineReason.Enabled = true;
                        }

                        ///------------------------------------------------------
                        txtOverallAsst.Text = oledbCaseVerDtlRead["OVERALL_ASSESMENT"].ToString();
                        txtAsstReason.Text = oledbCaseVerDtlRead["OVERALL_ASSESMENT_REASON"].ToString();
                        txtBankNameCC.Text = oledbCaseVerDtlRead["DEFAULTED_WITH"].ToString();
                        txtProductName.Text = oledbCaseVerDtlRead["DEFAULTED_PRODUCT"].ToString();
                        txtAmountDefault.Text = oledbCaseVerDtlRead["DEFAULT_AMOUNT"].ToString();
                        txtCPVScore.Text = oledbCaseVerDtlRead["RATING"].ToString();
                        txtSupervisorName.Text = oledbCaseVerDtlRead["SUPERVISOR_ID"].ToString();
                        txtSupervisorRemark.Text = oledbCaseVerDtlRead["SUPERVISOR_REMARKS"].ToString();

                       
                    }
                    
                    oledbCaseVerDtlRead.Close();

                   
                    //////END FOR RESIDENTIAL VERIFICATION(CPV_CC_VERI_DETAILS) CASE DETAIL------------------
                }
              
                
                if ((Request.QueryString["Mode"] != null) && (Request.QueryString["Mode"] != ""))
                {
                    hidMode.Value = Request.QueryString["Mode"].ToString();
                }

                if ((Request.QueryString["VerificationTypeCode"] != null) && (Request.QueryString["VerificationTypeCode"] != ""))
                {
                    hidVerificationTypeCode.Value = Request.QueryString["VerificationTypeCode"].ToString();
                }
                if (hidMode.Value == "View")
                {
                    btnCancel.Enabled = false;
                    btnSubmit.Enabled = false;
                    LikButtonVisibility();

                }
            }
            catch (Exception ex)
            {
                lblMsg.Visible = true;
                lblMsg.Text = "Error while retrieving data: " + ex.Message;
            }
        }
        
    }

    //public int CountBonusRows
    //{
    //    get
    //    {
    //        if (ViewState["cntBonusRows"] == null)
    //            return 0;
    //        else
    //            return (int)ViewState["cntBonusRows"];
    //    }
    //    set
    //    {
    //        ViewState["cntBonusRows"] = value;
    //    }
    //}

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        int iCount = 0;
        try
        {
            ////for CPV_CC_VERI_DESCRIPTION table--------------------------------------
            
            objCCVer.CaseId = Request.QueryString["CaseId"].ToString();
            objCCVer.VerificationType = Request.QueryString["VerTypeId"].ToString();
            objCCVer.VerficationTypeID = Request.QueryString["VerTypeId"].ToString();
            objCCVer.PPNormal = ddlTelPPNormal.SelectedItem.Text.Trim();

            if (ddlQualification.SelectedItem.Text.Trim() == "Others")
                objCCVer.Qualification = "Others" + ":" + txtOtherQualification.Text.Trim();
            else
                objCCVer.Qualification = ddlQualification.SelectedItem.Text.Trim();
            objCCVer.TimeCurrYrsMths = txtTimeCurrYrs.Text.Trim() + "." + txtTimeCurrMths.Text.Trim();
            if (ddlMaritalStatus.SelectedItem.Text.Trim() == "Other")
                objCCVer.MaritalStatus = "Other" + ":" + txtOtherMaritalStatus.Text.Trim();
            else
                objCCVer.MaritalStatus = ddlMaritalStatus.SelectedItem.Text.Trim();
            objCCVer.SpouseWorking = ddlIfSpouseWorking.SelectedItem.Text.Trim();
            objCCVer.SpouseCompName = txtSpouseCompanyName.Text.Trim();
            objCCVer.SpouseSalary = txtSpouseSalary.Text.Trim();
            objCCVer.TelephoneSpouse = txtSpouseTelephoneNo.Text.Trim();
            objCCVer.NoOfDependent = txtNoDependent.Text.Trim();
            objCCVer.VehicleType = ddlVehicleType.SelectedItem.Text.Trim();
            objCCVer.VehicleMake = txtVehicleMake.Text.Trim();
            if (ddlVehicleIs.SelectedItem.Text.Trim() == "Others(specify)")
            {
                objCCVer.VehicleIs = "Others(specify)" + ":" + txtOtherVehicleIs.Text.Trim();
                objCCVer.VehicleOther = txtOtherVehicleIs.Text.Trim();
            }
            else
                objCCVer.VehicleIs = ddlVehicleIs.SelectedItem.Text.Trim();
            ///for working and children-----02/08/2007---
            objCCVer.Working = txtWorking.Text.Trim();
            objCCVer.Children = txtChildren.Text.Trim();
            //----
            objCCVer.IsCreditCard = ddlCreditCards.SelectedItem.Text.Trim();
            objCCVer.CardNo = txtCardNo.Text.Trim();
            objCCVer.CardType = txtCardType.Text.Trim();
            objCCVer.CardLimit = txtCardLimit.Text.Trim();
            objCCVer.CardExpiry = txtCardExpiry.Text.Trim();
            objCCVer.AppAvailableAt = txtAppAvailbleAt.Text.Trim();
            objCCVer.TimeCurrResiYrsMths = txtTimeCurrResYrs.Text.Trim() + "." + txtTimeCurrResMths.Text.Trim();
            objCCVer.AppWorksAt = txtApplicantWorkAt.Text.Trim();
            if (ddlVerifiedFrom.SelectedItem.Text.Trim() == "Others(specify)")
                objCCVer.VerifiedFrom = "Others(specify)" + ":" + txtOtherVerified.Text.Trim();
            else
                objCCVer.VerifiedFrom = ddlVerifiedFrom.SelectedItem.Text.Trim();

            objCCVer.ApproxArea = txtApproxArea.Text.Trim();
            objCCVer.GeneralAppearance = ddlGeneralApp.SelectedItem.Text.Trim();
            objCCVer.LocatingAddress = ddlLocatingAdd.SelectedItem.Text.Trim();
            
            //////////////Modifing Santosh Shelar 16th May 2008///////////////////

            string sAssetsVisible = "";
            string sAss_vis_TV = "";
            string sAss_Vis_AC = "";
            string sAss_Vis_Refri = "";
            string sAss_Vis_MusSys = "";
            string sAss_Vis_Comp = "";
            string sAss_Vis_Cool = "";
            string sAss_Vis_PH = "";
            string sAss_Vis_PhotCop = "";

            if (chkAssetsVisible.Items.Count > 0)
            {
                foreach (ListItem li in chkAssetsVisible.Items)
                {
                    if (li.Text.Trim() == "A/C" && li.Selected == true)
                    {
                        sAss_Vis_AC = "Yes";
                    }

                    else if (li.Text.Trim() == "TV" && li.Selected == true)
                    {
                        sAss_vis_TV = "Yes";
                    }

                    else if (li.Text.Trim() == "Refrigerator" && li.Selected == true)
                    {
                        sAss_Vis_Refri = "Yes";
                    }

                    else if (li.Text.Trim() == "Music System" && li.Selected == true)
                    {
                        sAss_Vis_MusSys = "Yes";
                    }

                    else if (li.Text.Trim() == "Computer" && li.Selected == true)
                    {
                        sAss_Vis_Comp = "Yes";
                    }

                    else if (li.Text.Trim() == "Cooler" && li.Selected == true)
                    {
                        sAss_Vis_Cool = "Yes";
                    }

                    else if (li.Text.Trim() == "Phone" && li.Selected == true)
                    {
                        sAss_Vis_PH = "Yes";
                    }

                    else if (li.Text.Trim() == "Photocopier" && li.Selected == true)
                    {
                        sAss_Vis_PhotCop = "Yes";
                    }

                    if (li.Text.Trim() == "Others(specify)" && li.Selected == true)
                    {
                        sAssetsVisible += li.Value + "," + txtOtherAssetVisible.Text.Trim();
                    }
                    else if (li.Selected == true)
                    {
                        sAssetsVisible += li.Value + ",";
                    }

                }
            }

            if (sAss_Vis_AC == "")
            {
                sAss_Vis_AC = "N/C";
            }
            if (sAss_vis_TV == "")
            {
                sAss_vis_TV = "N/C";
            }
            if (sAss_Vis_Refri == "")
            {
                sAss_Vis_Refri = "N/C";
            }
            if (sAss_Vis_MusSys == "")
            {
                sAss_Vis_MusSys = "N/C";
            }
            if (sAss_Vis_Comp == "")
            {
                sAss_Vis_Comp = "N/C";
            }
            if (sAss_Vis_Cool == "")
            {
                sAss_Vis_Cool = "N/C";
            }
            if (sAss_Vis_PH == "")
            {
                sAss_Vis_PH = "N/C";
            }
            if (sAss_Vis_PhotCop == "")
            {
                sAss_Vis_PhotCop = "N/C";
            }

            objCCVer.AssetsVisible = sAssetsVisible.TrimEnd(',');
            objCCVer.Ass_Vis_AC = sAss_Vis_AC.TrimEnd();
            objCCVer.Ass_Vis_Comp = sAss_Vis_Comp.TrimEnd();
            objCCVer.Ass_Vis_Cool = sAss_Vis_Cool.TrimEnd();
            objCCVer.Ass_Vis_MusSys = sAss_Vis_MusSys.TrimEnd();
            objCCVer.Ass_Vis_PH = sAss_Vis_PH.TrimEnd();
            objCCVer.Ass_Vis_PhotCop = sAss_Vis_PhotCop.TrimEnd();
            objCCVer.Ass_Vis_Refri = sAss_Vis_Refri.TrimEnd();
            objCCVer.Ass_Vis_Tv = sAss_vis_TV.TrimEnd();
            ///////////////////////////////////////////////////////////////////////////////////////////////
            //objCCVer.Ass_Vis_MusSys = sAss_Vis_MusSys.Trim();

            objCCVer.PoliticalLeadderPortrait = ddlPoliticalPic.SelectedItem.Text.Trim();        
            objCCVer.VisitProof = ddlVisitProof.SelectedItem.Text.Trim();
            objCCVer.RouteMap = ddlRouteMap.SelectedItem.Text.Trim();
            objCCVer.TPCDone = ddlTPCDone.SelectedItem.Text.Trim();
            objCCVer.TPCDetail = txtTPCDetail.Text.Trim();
            objCCVer.AnyInformation = txtAnyInfo.Text.Trim();
            objCCVer.AddressConfirmation = ddlAddConfirmation.SelectedItem.Text.Trim();
            objCCVer.Contactability = txtContactability.Text.Trim();
            objCCVer.ApplicationConfirm = txtConfirmationApp.Text.Trim();
            objCCVer.Profile = txtProfile.Text.Trim();
            objCCVer.Reputation = txtReputation.Text.Trim();
            objCCVer.PersonContacted = txtPersonContacted.Text.Trim();
            objCCVer.IssuingBank = txtIssuingBank.Text.Trim();
            //objCCVer.CooperativeCus = txtCooperativeCustomer.Text.Trim();
            objCCVer.CooperativeCus = ddlCooperativeCustomer.SelectedValue.ToString();
            objCCVer.ConstructionOfResi = ddlConstructionOfResi.SelectedItem.Text.Trim();
            string sExteriorComments = "";
            if (chkExteriorComments.Items.Count > 0)
            {
                foreach (ListItem li in chkExteriorComments.Items)
                {
                    if (li.Text.Trim() == "Others(P1. Specify)" && li.Selected == true)
                        sExteriorComments += li.Value + "," + txtIfOtherExteriorComments.Text.Trim();
                    else
                        if (li.Selected == true)
                            sExteriorComments += li.Value + ",";
                }
            }

            objCCVer.ExteriorComments = sExteriorComments.TrimEnd(',');
            //objCCVer.IsApplicantStay = txtDoesAppStay.Text.Trim();
            //if (ddlDoesAppStay.SelectedValue == "Yes")
            //    objCCVer.IsApplicantStay = "Y";
            //else
            //    objCCVer.IsApplicantStay = "N";
            objCCVer.IsApplicantStay = ddlDoesAppStay.SelectedValue.ToString();
            objCCVer.ApproxAgeOfApp = txtApproxAgeOfApp.Text.Trim();
            objCCVer.NoOfFamilyMem = txtNoOfFamilyMem.Text.Trim();
            objCCVer.NameplateSighted = ddlAppNameplateSight.SelectedItem.Text.Trim();
            objCCVer.OwnerResiApp1 = txtOwenershipApp1.Text.Trim();
            objCCVer.EmpStatus1 = txtEmpStatus1.Text.Trim();
            objCCVer.OwnerResiApp2 = txtOwenershipApp2.Text.Trim();
            objCCVer.EmpStatus2 = txtEmpStatus2.Text.Trim();
            if (ddlNeighResidenceIs.SelectedItem.Text.Trim() == "Others")
                objCCVer.ResidenceIs = "Others" + ":" + txtOtherNeighResidenceIs.Text.Trim();
            else
                objCCVer.ResidenceIs = ddlNeighResidenceIs.SelectedItem.Text.Trim();
            //objCCVer.ResidenceIs = ddlNeighResidenceIs.SelectedItem.Text.Trim();
            objCCVer.RentAmount = txtIfNeighRentedthenAmt.Text.Trim();
            objCCVer.PriorityCustomer = txtPriorityCustomer.Text.Trim();
            objCCVer.Segment = txtSegment.Text.Trim();
            objCCVer.InfoRequired = txtInfoRequired.Text.Trim();
            objCCVer.ChangeInAdd = txtChangeAdd.Text.Trim();
            objCCVer.ReasonOfChange = txtReasonForChange.Text.Trim();
            //objCCVer.Outcome = txtOutcome.Text.Trim();    //replace with decline code.
            objCCVer.TrackNo = txtTrackNo.Text.Trim();
            objCCVer.EntryPermit = txtEntryPermitted.Text.Trim();
            objCCVer.AddConfBy = txtAddConfBy.Text.Trim();
            objCCVer.NoOfEarnFamMem = txtNoOfFamMemEarning.Text.Trim();
            objCCVer.OfficePhone = txtOfficeTelephone.Text.Trim();
            objCCVer.ApproxValIfOwn = txtApproxValIfOwned.Text.Trim();
            objCCVer.Branch = txtBranch.Text.Trim();
            objCCVer.InfoRefused = txtInfoRefused.Text.Trim();
            objCCVer.Occupation2 = txtOccupation2.Text.Trim();
            objCCVer.ReasonAddNotConfirm = txtReasonForAddNotConfirm.Text.Trim();
            //modified by hemangi kambli on 23/7/2007 for adding Other in DDL
            //objCCVer.Locality = ddlLocality.SelectedValue.ToString();
            if (ddlLocality.SelectedItem.Text.Trim() == "Others")
                objCCVer.Locality = "Others" + ":" + txtOtherLocality.Text.Trim();
            else
                objCCVer.Locality = ddlLocality.SelectedItem.Text.Trim();
            
            //Temporary commented by hemangi kambli on 15-May-2007=----
            //objCCVer.Locality = txtLocalityInfo.Text.Trim();         
            //---------------------------------   
            objCCVer.ResultOfCalling = txtResultOfCalling.Text.Trim();
            objCCVer.MismatchResiAdd = txtMismatchInResAdd.Text.Trim();
            objCCVer.IsAppKnown = txtIsAppKnownToPerson.Text.Trim();
            objCCVer.ToWhomAddBelong = txtToWhomAddBelong.Text.Trim();
            objCCVer.VerificationConductAt = txtVerificationContactAt.Text.Trim();
            objCCVer.Accomodation = txtAccomodation.Text.Trim();
            //objCCVer.Interior = txtInterior.Text.Trim();
            string sInterior = "";
            if (chkInterior.Items.Count > 0)
            {
                foreach (ListItem li in chkInterior.Items)
                {
                    if (li.Text.Trim() == "Others(P1. Specify)" && li.Selected == true)
                        sInterior += li.Value + "," + txtIfOtherInteriorConditions.Text.Trim();
                    else
                        if (li.Selected == true)
                            sInterior += li.Value + ",";
                }
            }

            objCCVer.Interior = sInterior.TrimEnd(',');
            //objCCVer.Interior = ddlInterior.SelectedValue.ToString();
            
            //Added By Naresh Sabbani//
            
            string sTypeOfSociety = "";
            objCCVer.Type_Of_Society = "";
            if (ChkTypeofSociety.Items.Count > 0)
            {
                foreach (ListItem li in ChkTypeofSociety.Items)
                {
                    if (li.Selected == true)
                        sTypeOfSociety += li.Value + ",";
                }
            }
            objCCVer.Type_Of_Society = sTypeOfSociety.TrimEnd(',');

            string sOtherFacilities = "";
            objCCVer.Other_Facilities = "";
            if (ChkOtherFacilities.Items.Count > 0)
            {
                foreach (ListItem li in ChkOtherFacilities.Items)
                {
                    if (li.Selected == true)
                        sOtherFacilities += li.Value + ",";
                }
            }
            objCCVer.Other_Facilities = sOtherFacilities.TrimEnd(',');

            string sMarketValue = "";
            objCCVer.Market_Value = "";
            if (ChkMarketValue.Items.Count > 0)
            {
                foreach (ListItem li in ChkMarketValue.Items)
                {
                    if (li.Selected == true)
                        sMarketValue += li.Value + ",";
                }
            }
            objCCVer.Market_Value = sMarketValue.TrimEnd(',');

            string sBuiltupArea = "";
            objCCVer.Builtup_Area = "";
            if (ChkBuiltupArea.Items.Count > 0)
            {
                foreach (ListItem li in ChkBuiltupArea.Items)
                {
                    if (li.Selected == true)
                        sBuiltupArea += li.Value + ",";
                }
            }
            objCCVer.Builtup_Area = sBuiltupArea.TrimEnd(',');

            string sNoOfFlats = "";
            objCCVer.No_Of_Flats = "";
            if (ChkNoOfFlatsSociety.Items.Count > 0)
            {
                foreach (ListItem li in ChkNoOfFlatsSociety.Items)
                {
                    if (li.Selected == true)
                        sNoOfFlats += li.Value + ",";
                }
            }
            objCCVer.No_Of_Flats = sNoOfFlats.TrimEnd(',');

            string sBedroom = "";
            objCCVer.Bedroom = "";
            if (ChkBedroom.Items.Count > 0)
            {
                foreach (ListItem li in ChkBedroom.Items)
                {
                    if (li.Selected == true)
                        sBedroom += li.Value + ",";
                }
            }
            objCCVer.Bedroom = sBedroom.TrimEnd(',');

            string sNegative_Area = "";
            objCCVer.Negative_Area = "";
            if (ChkNegativeAreaSociety.Items.Count > 0)
            {
                foreach (ListItem li in ChkNegativeAreaSociety.Items)
                {
                    if (li.Selected == true)
                        sNegative_Area += li.Value + ",";
                }
            }
            objCCVer.Negative_Area = sNegative_Area.TrimEnd(',');

            objCCVer.Tpc_Name = TxtDetailstakenbytpc.Text.Trim();
            objCCVer.Tpc_Phone = TxtPhoneNumbersoftpc.Text.Trim();
            objCCVer.History = TxtHistory.Text.Trim();
            objCCVer.No_Of_Employee = TxtNoOfEmployeesSociety.Text.Trim();
            objCCVer.Remark = TxtRemarkSociey.Text.Trim();

            //Addition Ended Naresh Sabbani//

            objCCVer.Exterior = txtExterior.Text.Trim();
            objCCVer.TPCBy = txtTPCBy.Text.Trim();
            objCCVer.Observation = txtObservation.Text.Trim();
            objCCVer.TPC2 = txtTPC2.Text.Trim();
            objCCVer.PersonMet2 = txtPersonMet2.Text.Trim();
            objCCVer.Add2 = txtAdd2.Text.Trim();
            objCCVer.AppAge2 = txtAppAge2.Text.Trim();
            objCCVer.NoOfResiAtHome2 = txtNoOfResAtHome2.Text.Trim();
            objCCVer.YrsLiveAtAdd2 = txtYearLiveAtAdd2.Text.Trim();
            objCCVer.ResiStatus2 = txtResStatus2.Text.Trim();
            ////////CPV_CC_VERI_DESCRIPTION1---------------------------------
            objCCVer.DesgnAtOffice = txtDesignationAtOffice.Text.Trim();
            objCCVer.IncomeDocs = txtIncomeDoc.Text.Trim();
            objCCVer.FERemark = txtNewInfoFERemark.Text.Trim();
            objCCVer.CoAppName = txtAppCompName.Text.Trim();
            objCCVer.PriorityCustomer = txtPriorityCustomer.Text.Trim();
            objCCVer.InfoRequired = txtInfoRequired.Text.Trim();
            objCCVer.RelationWithApplicant = txtRelationApplicant.Text.Trim();
            //objCCVer.AddressConfirmation = ddlAddConfirmation.SelectedItem.Text.Trim();
            objCCVer.UntraceableReason = txtUntraceableReason.Text.Trim();
            objCCVer.VerificationConductAt = txtVerificationContactAt.Text.Trim();
            //If Permanent address panel is invisible and data not there -----------------------           
            if (txtPerAddress.Text.Trim() != "")
                objCCVer.PermanentAddress = txtPerAddress.Text.Trim();
            else
            {
                OleDbDataReader oledbReadPerAdd;
                oledbReadPerAdd = objCCVer.GetCaseDetail(Request.QueryString["CaseID"].ToString());
                if (oledbReadPerAdd.Read())
                {
                    objCCVer.PermanentAddress = oledbReadPerAdd["Permanent_ADDRESS"].ToString();
                }
                oledbReadPerAdd.Close();
            }
            ///-----------------------------------------------------------------------------------
            objCCVer.PinCode = txtPerAddPinCode.Text.Trim();
            objCCVer.LandmarkObserved = txtPerAddLandmark.Text.Trim();
            objCCVer.CompanyName = txtAppCompName.Text.Trim();
            objCCVer.OfficeExtn = txtOfficeExtn.Text.Trim();
            objCCVer.DesgnAtOffice = txtDesignationAtOffice.Text.Trim();
            //if(txtDOB.Text.Trim()!="")
            //    objCCVer.DateOfBirth = Convert.ToDateTime(txtDOB.Text.Trim());
            objCCVer.DateOfBirth = txtDOB.Text.Trim();
            objCCVer.AppAvailableAtHome = txtAppAvaAtHome.Text.Trim();

            if (ddlNeighResidenceIs.SelectedItem.Text.Trim() == "Others")
                objCCVer.ResiIsStatus = "Others" + ":" + txtOtherResidenceIsStatus.Text.Trim();
            else
                objCCVer.ResiIsStatus = ddlResidenceIsStatus.SelectedItem.Text.Trim();

            objCCVer.OfficeAddress = txtOfficeAddress.Text.Trim();
            objCCVer.Stay = txtStayTPC2.Text.Trim();
            objCCVer.Neighbour2Name = txtNameTPC2.Text.Trim();
            //objCCVer.NeighbourReferance = txtNeighbourRef.Text.Trim();
            objCCVer.NeighbourReferance = ddlNeighbourRef.SelectedValue.ToString();
            ////////for CPV_CC_VERI_OTHER_DETAILS table--------------------

            objCCVer.RelationWithApplicant = txtRelationApplicant.Text.Trim();
            objCCVer.PersonContacted = txtPersonContacted.Text.Trim();
            //objCCVer.IsApplicantStay = txtDoesAppStay.Text.Trim();
            objCCVer.PermanentAddress = txtPerAddress.Text.Trim();
            objCCVer.NegativeArea = ddlNegativeArea.SelectedItem.Text.Trim();
            objCCVer.OCL = ddlOCL.SelectedItem.Text.Trim();
            if (ddlTypeOfResidence.SelectedItem.Text.Trim() == "Others(specify)")
                objCCVer.ResidenceType = "Others(specify)" + ":" + txtOtherResiType.Text.Trim();
            else
                objCCVer.ResidenceType = ddlTypeOfResidence.SelectedItem.Text.Trim();


            objCCVer.NameplateSighted = ddlAppNameplateSight.SelectedItem.Text.Trim();
            //objCCVer.ResiIsStatus = ddlResidenceIsStatus.SelectedItem.Text.Trim();            

            ////////for CPV_CC_VERI_DETAILS
            //objCCVer.DeclineCode = txtOutcome.Text.Trim();

            //ddlCaseStatus.DataBind();
            //ddlOutcome.DataBind();
            objCCVer.CaseStatusId = ddlCaseStatus.SelectedValue.ToString();
            objCCVer.DeclineCode = ddlOutcome.SelectedValue.ToString();
            objCCVer.DeclineReason = txtDeclineReason.Text.Trim();
            objCCVer.BankNameCC = txtBankNameCC.Text.Trim();
            objCCVer.ProductName = txtProductName.Text.Trim();
            objCCVer.AmountDefult = txtAmountDefault.Text.Trim();
            objCCVer.CPVScore = txtCPVScore.Text.Trim();
            objCCVer.SupervisorId = txtSupervisorName.Text.Trim();
            objCCVer.SupervisorRemark = txtSupervisorRemark.Text.Trim();
            objCCVer.OverallAssessment = txtOverallAsst.Text.Trim();
            objCCVer.AssesstReason = txtAsstReason.Text.Trim();
            objCCVer.AgencyCode = txtAgencyCode.Text.Trim();
            ////////////////////------------------------
            ////START Attempt Details
            ArrayList arrAttempt = new ArrayList();
            ArrayList arrAttempt1 = new ArrayList();
            ArrayList arrAttempt2 = new ArrayList();
            ArrayList arrAttempt3 = new ArrayList();
            if (IsValidAttempt() == true)
            {
                string strCaseID = Request.QueryString["CaseID"].ToString();
                objCC.CaseId = strCaseID;

                //objCC.VerifierID = ddlVerifier.SelectedValue.ToString();
                ////objCC.VerificationTypeID = ddlVeriType.SelectedValue.ToString();

                //objCC.CaseStatusID = ddlCaseStatus.SelectedValue.ToString();
                //if (ddlCaseStatus.SelectedItem.Text.ToString() == "NEGATIVE")
                //    objCC.DeclineCode = ddlDeclinedCode.SelectedValue.ToString();
                //else
                //    objCC.DeclineCode = "";

                //objCC.DeclineReason = txtDeclineReason.Text.Trim();

                CCommon objCmn = new CCommon();
                if (txtAttemptDate1.Text.Trim() != "" && txtAttemptTime1.Text.Trim() != "")
                {
                    arrAttempt1.Clear();
                    arrAttempt1.Add(objCmn.strDate(txtAttemptDate1.Text.Trim()) + " " + txtAttemptTime1.Text.Trim() + " " + ddlAttemptTimeType1.SelectedItem.Text.Trim());
                    arrAttempt1.Add(txtAttemptRemark1.Text.Trim());
                    arrAttempt.Add(arrAttempt1);
                }

                if (txtAttemptDate2.Text.Trim() != "" && txtAttemptTime2.Text.Trim() != "")
                {
                    arrAttempt2.Clear();
                    arrAttempt2.Add(objCmn.strDate(txtAttemptDate2.Text.Trim()) + " " + txtAttemptTime2.Text.Trim() + " " + ddlAttemptTimeType2.SelectedItem.Text.Trim());
                    arrAttempt2.Add(txtAttemptRemark2.Text.Trim());
                    arrAttempt.Add(arrAttempt2);
                }

                if (txtAttemptDate3.Text.Trim() != "" && txtAttemptTime3.Text.Trim() != "")
                {
                    arrAttempt3.Clear();
                    arrAttempt3.Add(objCmn.strDate(txtAttemptDate3.Text.Trim()) + " " + txtAttemptTime3.Text.Trim() + " " + ddlAttemptTimeType3.SelectedItem.Text.Trim());
                    arrAttempt3.Add(txtAttemptRemark3.Text.Trim());
                    arrAttempt.Add(arrAttempt3);
                }
                ///End Attempt Details--------------------
                ////////Call insert/update function--------------------------            
                string IsCase = "Y";
                objCCVer.IsCaseComp = IsCase.ToString();
  
                string sMsg = "";
                //added by hemangi kambli on 07/09/2007--------------
                objCCVer.AddedBy = Session["UserId"].ToString();
                objCCVer.AddedOn = DateTime.Now;
                objCCVer.ModifyBy = Session["UserId"].ToString();
                objCCVer.ModifyOn = DateTime.Now;
                ///------------------------------------------------------
                //Added by hemangi kambli on 03/10/2007 
                if (hdnTransStart.Value != "")
                    objCCVer.TransStart = Convert.ToDateTime(hdnTransStart.Value);
                objCCVer.TransEnd = Convert.ToDateTime(DateTime.Now.ToString());//"dd/MM/yyyy hh:mm:ss tt"));
                objCCVer.CentreId = Session["CentreId"].ToString();
                objCCVer.ProductId = Session["ProductId"].ToString();
                objCCVer.ClientId = Session["ClientId"].ToString();
                objCCVer.UserId = Session["UserId"].ToString();
                ///------------------------------------------------------
                objCCVer.VerifierID = Request.QueryString["VerifierId"].ToString();
                sMsg = objCCVer.InsertUpdateCCResiVerificationEntry(arrAttempt);
                if ((objCCVer.Error != "") && (objCCVer.Error!=null))
                {
                   
                    pnlMsg.Visible = true;
                    tblMsg.Visible = true;
                    lblMsg.Text = objCCVer.Error;
                }
                else
                {
                    pnlMsg.Visible = true;
                    tblMsg.Visible = true;
                    lblMsg.ForeColor = System.Drawing.Color.Red;
                    lblMsg.Text = sMsg.Trim();
                    iCount = 1;
                }
                ///-------------------------------------------------------------
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
            Response.Redirect("CC_VerificationView.aspx?Msg=" + lblMsg.Text);
        }
    }

    //protected void btnSearch_Click(object sender, EventArgs e)
    //{
    //    string sCaseId = txtCaseId.Text.Trim();
    //    string sVerifyType = ddlVerifyType.SelectedValue.ToString();
    //    OleDbDataReader oledbRead;
    //    oledbRead = objCCVer.GetVerificationDetail(sCaseId, sVerifyType);
    //    switch (sVerifyType)
    //    {
    //        case "1":                
    //            if (oledbRead.Read() == true)
    //                Response.Redirect("CC_ResidenceVerification.aspx?CaseID=" + sCaseId + "&VerTypeId=" + sVerifyType);                
    //                break;
    //        case "10":
    //            if (oledbRead.Read() == true)
    //                Response.Redirect("CC_PermanentResidenceVerification.aspx?CaseID=" + sCaseId + "&VerTypeId=" + sVerifyType);                
    //            break;
    //        case "2":
    //            if (oledbRead.Read() == true)
    //                Response.Redirect("CC_BusinessVerification.aspx?CaseID=" + sCaseId + "&VerTypeId=" + sVerifyType);                
    //            break;
    //        case "3":
    //            if (oledbRead.Read() == true)
    //                Response.Redirect("CC_BusinessVerificationTelephonic.aspx?CaseID=" + sCaseId + "&VerTypeId=" + sVerifyType);                
    //            break;
    //        case "4":
    //            if (oledbRead.Read() == true)
    //                Response.Redirect("CC_ResidenceVerificationTelephonic.aspx");
    //            break;
    //    }

    //}
    //protected void ddlVerifyType_DataBound(object sender, EventArgs e)
    //{
    //    ddlVerifyType.Items.Insert(0, new ListItem("Select", "0"));        
    //}

    //protected void cvSelectVerifyType_ServerValidate(object source, ServerValidateEventArgs args)
    //{
    //    if (source.ToString() == "0")
    //    {
    //        lblMsg.Visible = true;
    //        lblMsg.Text = "Please select verification Type.";
    //    }
    //}
    private bool IsValidAttempt()
    {
        bool IsValid = true;
        try
        {
            if (txtAttemptTime1.Text.Trim() != "" && IsValid == true)
            {
                if (txtAttemptDate1.Text == "")
                {
                    IsValid = false;
                    lblMsg.Visible = true;
                    lblMsg.ForeColor = System.Drawing.Color.Red;
                    lblMsg.Text = "Enter date in first attempt.";
                    txtAttemptDate1.Focus();
                }
                //Commented By Gargi Srivastava at 31-May-2007

                //if (txtAttemptRemark1.Text == "")
                //{
                //    IsValid = false;
                //    lblMsg.Visible = true;
                //    lblMsg.Text = "Enter remark in first attempt.";
                //    txtAttemptRemark1.Focus();
                //}

                //End
            }
            if (txtAttemptRemark1.Text.Trim() != "" && IsValid == true)
            {
                if (txtAttemptDate1.Text == "")
                {
                    IsValid = false;
                    lblMsg.Visible = true;
                    lblMsg.ForeColor = System.Drawing.Color.Red;
                    lblMsg.Text = "Enter date in first attempt.";
                    txtAttemptDate1.Focus();
                }
                if (txtAttemptTime1.Text == "")
                {
                    IsValid = false;
                    lblMsg.Visible = true;
                    lblMsg.ForeColor = System.Drawing.Color.Red;
                    lblMsg.Text = "Enter time in first attempt.";
                    txtAttemptTime1.Focus();
                }
                if (txtAttemptRemark1.Text.Length > 500)
                {
                    IsValid = false;
                    lblMsg.Visible = true;
                    lblMsg.ForeColor = System.Drawing.Color.Red;
                    lblMsg.Text = "Remark should not be greater than 255 characters in first attempt.";
                    txtAttemptRemark1.Focus();
                }

            }

            if (txtAttemptTime2.Text != "" && IsValid == true)
            {
                if (txtAttemptDate2.Text == "")
                {
                    IsValid = false;
                    lblMsg.Visible = true;
                    lblMsg.ForeColor = System.Drawing.Color.Red;
                    lblMsg.Text = "Enter date in second attempt.";
                    txtAttemptDate2.Focus();
                }
                //Commented By Gargi srivastava at 31-May-2007
                //if (txtAttemptRemark2.Text == "")
                //{
                //    IsValid = false;
                //    lblMsg.Visible = true;
                //    lblMsg.Text = "Enter remark in second attempt.";
                //    txtAttemptRemark2.Focus();
                //}
                //End
            }

            if (txtAttemptRemark2.Text != "" && IsValid == true)
            {
                if (txtAttemptDate2.Text == "")
                {
                    IsValid = false;
                    lblMsg.Visible = true;
                    lblMsg.ForeColor = System.Drawing.Color.Red;
                    lblMsg.Text = "Enter date in second attempt.";
                    txtAttemptDate2.Focus();
                }
                if (txtAttemptTime2.Text == "")
                {
                    IsValid = false;
                    lblMsg.Visible = true;
                    lblMsg.ForeColor = System.Drawing.Color.Red;
                    lblMsg.Text = "Enter time in second attempt.";
                    txtAttemptTime2.Focus();
                }
                if (txtAttemptRemark2.Text.Length > 500)
                {
                    IsValid = false;
                    lblMsg.Visible = true;
                    lblMsg.ForeColor = System.Drawing.Color.Red;
                    lblMsg.Text = "Remark should not be greater than 255 characters in second attempt.";
                    txtAttemptRemark2.Focus();
                }
            }

            if (txtAttemptTime3.Text != "" && IsValid == true)
            {
                if (txtAttemptDate3.Text == "")
                {
                    IsValid = false;
                    lblMsg.Visible = true;
                    lblMsg.ForeColor = System.Drawing.Color.Red;
                    lblMsg.Text = "Enter date in third attempt.";
                    txtAttemptDate3.Focus();
                }
                //Commented By Gargi Srivastava at 31-May-2007
                //if (txtAttemptRemark3.Text == "")
                //{
                //    IsValid = false;
                //    lblMsg.Visible = true;
                //    lblMsg.Text = "Enter remark in third attempt.";
                //    txtAttemptRemark3.Focus();
                //}
                //End

            }

            if (txtAttemptRemark3.Text != "" && IsValid == true)
            {
                if (txtAttemptDate3.Text == "")
                {
                    IsValid = false;
                    lblMsg.Visible = true;
                    lblMsg.ForeColor = System.Drawing.Color.Red;
                    lblMsg.Text = "Enter date in third attempt.";
                    txtAttemptDate3.Focus();
                }
                if (txtAttemptTime3.Text == "")
                {
                    IsValid = false;
                    lblMsg.Visible = true;
                    lblMsg.Text = "Enter time in third attempt.";
                    txtAttemptTime3.Focus();
                }
                if (txtAttemptRemark3.Text.Length > 500)
                {
                    IsValid = false;
                    lblMsg.Visible = true;
                    lblMsg.ForeColor = System.Drawing.Color.Red;
                    lblMsg.Text = "Remark should not be greater than 255 characters in third attempt.";
                    txtAttemptRemark3.Focus();
                }
            }

            //if (txtAddress1.Text != "")
            //{
            //    if (txtAddress1.Text.Length > 500)
            //    {
            //        IsValid = false;
            //        lblMsg.Visible = true;
            //        lblMsg.Text = "Billing address should not be greater than 500 characters.";
            //        txtattAddress1.Focus();
            //    }
            //}
            if (txtAttemptTime1.Text.Trim() == "" && txtAttemptTime2.Text.Trim() == "" && txtAttemptTime3.Text.Trim() == "")
            {
                pnlMsg.Visible = true;
                IsValid = false;
                lblMsg.Visible = true;
                lblMsg.ForeColor = System.Drawing.Color.Red;
                lblMsg.Text = "Enter atleast one record for attempt.";
                txtAttemptTime1.Focus();
            }

        }
        catch (Exception ex)
        {
            pnlMsg.Visible = true;
            tblMsg.Visible = true;
            lblMsg.ForeColor = System.Drawing.Color.Red;
            lblMsg.Text = "Error:" + ex.Message;
        }
        return IsValid;
    }
    protected void ddlOutcome_DataBound(object sender, EventArgs e)
    {
        ddlOutcome.Items.Insert(0, new ListItem("Select", "0"));
    }

    protected void ddlCaseStatus_DataBound(object sender, EventArgs e)
    {
        ddlCaseStatus.Items.Insert(0, new ListItem("Select", "0"));
    }

    protected void cvSelectCaseStatus_ServerValidate(object source, ServerValidateEventArgs args)
    {
        if (source.ToString() == "0")
        {
            pnlMsg.Visible = true;
            tblMsg.Visible = true;
            lblMsg.ForeColor = System.Drawing.Color.Red;
            lblMsg.Text = "Please select case status.";
        }
    }
    protected void ddlCaseStatus_SelectedIndexChanged(object sender, EventArgs e)
    {
        //if (ddlCaseStatus.SelectedItem.Text.Trim() == "NEGATIVE")
        //{
        //    //pnlOutcome.Visible = true;
        //    ddlOutcome.Visible = true;
        //    txtDeclineReason.Visible = true;
        //    //pnlDeclineReason.Visible = true;
        //}
        //else
        //{
        //    ddlOutcome.Visible = true;
        //    txtDeclineReason.Visible = true;
        //    //pnlOutcome.Visible = false;
        //    //pnlDeclineReason.Visible = false;
        //}
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("CC_VerificationView.aspx");
    }
    public void funShowPanel()
    {
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
                    objPlaceHolder = (PlaceHolder)(tblResiVeri.Rows[0].Cells[0].FindControl(strPlaceHolderName));
                    if (objPlaceHolder != null)
                    {

                        Panel objPanel = new Panel();
                        //objPanel.EnableViewState = false;
                        objPanel = (Panel)(tblResiVeri.Rows[1].Cells[0].FindControl(strPanelName));
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
    private void ISEditFalse()
    {
        ////for CPV_CC_VERI_DESCRIPTION table--------------------------------------
        txtAppName.Enabled = false;
        txtRefNo.Enabled = false;
        txtResAddress.Enabled = false;
        ddlTelPPNormal.Enabled = false;
        ddlQualification.Enabled = false;
        txtOtherQualification.Enabled = false;
        ddlQualification.Enabled = false;
        txtTimeCurrYrs.Enabled = false;
        txtTimeCurrMths.Enabled = false;
        ddlMaritalStatus.Enabled = false;
        txtOtherMaritalStatus.Enabled = false;
        ddlMaritalStatus.Enabled = false;
        ddlIfSpouseWorking.Enabled = false;
        txtSpouseCompanyName.Enabled = false;
        txtSpouseSalary.Enabled = false;
        txtSpouseTelephoneNo.Enabled = false;
        txtNoDependent.Enabled = false;
        ddlVehicleType.Enabled = false;
        txtVehicleMake.Enabled = false;
        ddlVehicleIs.Enabled = false;
        txtOtherVehicleIs.Enabled = false;
        ddlVehicleIs.Enabled = false;
        ddlCreditCards.Enabled = false;
        txtCardNo.Enabled = false;
        txtCardType.Enabled = false;
        txtCardLimit.Enabled = false;
        txtCardExpiry.Enabled = false;
        txtAppAvailbleAt.Enabled = false;
        txtTimeCurrResYrs.Enabled = false;
        txtTimeCurrResMths.Enabled = false;
        txtApplicantWorkAt.Enabled = false;
        ddlVerifiedFrom.Enabled = false;
        txtOtherVerified.Enabled = false;
        ddlVerifiedFrom.Enabled = false;
        txtApproxArea.Enabled = false;
        ddlGeneralApp.Enabled = false;
        ddlLocatingAdd.Enabled = false;
        chkAssetsVisible.Enabled = false; ;
        txtOtherAssetVisible.Enabled = false;
        ddlPoliticalPic.Enabled = false;
        ddlVisitProof.Enabled = false;
        ddlRouteMap.Enabled = false;
        ddlTPCDone.Enabled = false;
        txtTPCDetail.Enabled = false;
        txtAnyInfo.Enabled = false;
        ddlAddConfirmation.Enabled = false;
        txtContactability.Enabled = false;
        txtConfirmationApp.Enabled = false;
        txtProfile.Enabled = false;
        txtReputation.Enabled = false;
        txtPersonContacted.Enabled = false;
        txtIssuingBank.Enabled = false;
        ddlCooperativeCustomer.Enabled = false;
        ddlConstructionOfResi.Enabled = false;
        chkExteriorComments.Enabled = false; ;
        txtIfOtherExteriorComments.Enabled = false;
        ddlDoesAppStay.Enabled = false;
        txtApproxAgeOfApp.Enabled = false;
        txtNoOfFamilyMem.Enabled = false;
        ddlAppNameplateSight.Enabled = false;
        txtOwenershipApp1.Enabled = false;
        txtEmpStatus1.Enabled = false;
        txtOwenershipApp2.Enabled = false;
        txtEmpStatus2.Enabled = false;
        ddlNeighResidenceIs.Enabled = false;
        txtOtherNeighResidenceIs.Enabled = false;
        ddlNeighResidenceIs.Enabled = false;
        txtIfNeighRentedthenAmt.Enabled = false;
        txtPriorityCustomer.Enabled = false;
        txtSegment.Enabled = false;
        txtInfoRequired.Enabled = false;
        txtChangeAdd.Enabled = false;
        txtReasonForChange.Enabled = false;
        txtTrackNo.Enabled = false;
        txtEntryPermitted.Enabled = false;
        txtAddConfBy.Enabled = false;
        txtNoOfFamMemEarning.Enabled = false;
        txtOfficeTelephone.Enabled = false;
        txtApproxValIfOwned.Enabled = false;
        txtBranch.Enabled = false;
        txtInfoRefused.Enabled = false;
        txtOccupation2.Enabled = false;
        txtReasonForAddNotConfirm.Enabled = false;
        ddlLocality.Enabled = false;
        txtResultOfCalling.Enabled = false;
        txtMismatchInResAdd.Enabled = false;
        txtIsAppKnownToPerson.Enabled = false;
        txtToWhomAddBelong.Enabled = false;
        txtVerificationContactAt.Enabled = false;
        txtAccomodation.Enabled = false;
        chkInterior.Enabled = false; ;
        txtIfOtherInteriorConditions.Enabled = false;
        txtExterior.Enabled = false;
        txtTPCBy.Enabled = false;
        txtObservation.Enabled = false;
        txtTPC2.Enabled = false;
        txtPersonMet2.Enabled = false;
        txtAdd2.Enabled = false;
        txtAppAge2.Enabled = false;
        txtNoOfResAtHome2.Enabled = false;
        txtYearLiveAtAdd2.Enabled = false;
        txtResStatus2.Enabled = false;

        ////////CPV_CC_VERI_DESCRIPTION1---------------------------------

        txtDesignationAtOffice.Enabled = false;
        txtIncomeDoc.Enabled = false;
        txtNewInfoFERemark.Enabled = false;
        txtAppCompName.Enabled = false;
        txtPriorityCustomer.Enabled = false;
        txtInfoRequired.Enabled = false;
        txtRelationApplicant.Enabled = false;
        txtUntraceableReason.Enabled = false;
        txtVerificationContactAt.Enabled = false;
        txtPerAddress.Enabled = false;
        txtPerAddPinCode.Enabled = false;
        txtPerAddLandmark.Enabled = false;
        txtAppCompName.Enabled = false;
        txtOfficeExtn.Enabled = false;
        txtDesignationAtOffice.Enabled = false;
        txtDOB.Enabled = false;
        txtAppAvaAtHome.Enabled = false;
        ddlNeighResidenceIs.Enabled = false;
        txtOtherResidenceIsStatus.Enabled = false;
        ddlResidenceIsStatus.Enabled = false;
        txtOfficeAddress.Enabled = false;
        txtStayTPC2.Enabled = false;
        txtNameTPC2.Enabled = false;
        ddlNeighbourRef.Enabled = false;

        ////////for CPV_CC_VERI_OTHER_DETAILS table--------------------

        txtRelationApplicant.Enabled = false;
        txtPersonContacted.Enabled = false;
        txtPerAddress.Enabled = false;
        ddlNegativeArea.Enabled = false;
        ddlOCL.SelectedItem.Enabled = false;
        ddlTypeOfResidence.Enabled = false;
        txtOtherResiType.Enabled = false;
        ddlTypeOfResidence.Enabled = false;
        ddlAppNameplateSight.Enabled = false;
        ddlCaseStatus.Enabled = false;
        ddlOutcome.Enabled = false;
        txtDeclineReason.Text.Trim();
        txtBankNameCC.Enabled = false;
        txtProductName.Enabled = false;
        txtAmountDefault.Enabled = false;
        txtCPVScore.Enabled = false;
        txtSupervisorName.Enabled = false;
        txtSupervisorRemark.Enabled = false;
        txtOverallAsst.Enabled = false;
        txtAsstReason.Enabled = false;
        txtAgencyCode.Enabled = false;

        ////////////////////------------------------
        ////START Attempt Details

        txtAttemptDate1.Enabled = false;
        txtAttemptTime1.Enabled = false;
        ddlAttemptTimeType1.Enabled = false;
        txtAttemptRemark1.Enabled = false;
        txtAttemptDate2.Enabled = false;
        txtAttemptTime2.Enabled = false;
        ddlAttemptTimeType2.Enabled = false;
        txtAttemptRemark2.Enabled = false;
        txtAttemptDate3.Enabled = false;
        txtAttemptTime3.Enabled = false;
        ddlAttemptTimeType3.Enabled = false;
        txtAttemptRemark3.Enabled = false;
        txtWorking.Enabled = false;
        txtChildren.Enabled = false;
        txtDeclineReason.Enabled = false;
        txtPincode.Enabled = false;
        txtLandmark.Enabled = false;
        txtTelPPNormal.Enabled = false;
        txtVerOfficePhone.Enabled = false;
        txtOtherLocality.Enabled = false;
        ddlOCL.Enabled = false;
        txtLocalityInfo.Enabled = false;
        btnSubmit.Enabled = false;
        btnCancel.Enabled = false;
        txtMobile.Enabled = false;
        }
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
                case "PRTV":
                    lbPRTV.Visible = true;
                    break;

            }

        }

        
    protected void lbRV_Click(object sender, EventArgs e)
    {
        Response.Redirect("CC_ResidenceVerification.aspx?CaseID=" + hidCaseID.Value + "&VerTypeId=1&VerificationTypeCode=" + hidVerificationTypeCode.Value + "&Mode=View");
    }
    protected void lbRT_Click(object sender, EventArgs e)
    {
        Response.Redirect("CC_ResidenceVerificationTelephonic.aspx?CaseID=" + hidCaseID.Value + "&VerTypeId=4&VerificationTypeCode=" + hidVerificationTypeCode.Value + "&Mode=View");
    }
    protected void lbBV_Click(object sender, EventArgs e)
    {
        Response.Redirect("CC_BusinessVerification.aspx?CaseID=" + hidCaseID.Value + "&VerTypeId=2&VerificationTypeCode=" + hidVerificationTypeCode.Value + "&Mode=View");
    }
    protected void lbBT_Click(object sender, EventArgs e)
    {
        Response.Redirect("CC_BusinessVerificationTelephonic.aspx?CaseID=" + hidCaseID.Value + "&VerTypeId=3&VerificationTypeCode=" + hidVerificationTypeCode.Value + "&Mode=View");
    }
    protected void lbPRV_Click(object sender, EventArgs e)
    {
        Response.Redirect("CC_ResidenceVerification.aspx?CaseID=" + hidCaseID.Value + "&VerTypeId=10&VerificationTypeCode=" + hidVerificationTypeCode.Value + "&Mode=View");
    }
    protected void lbPRTV_Click(object sender, EventArgs e)
    {
        //Response.Redirect("CC_ResidenceVerification.aspx?CaseID=" + hidCaseID + "&VerTypeId=" + hidVerificationTypeID + "&VerificationTypeCode" + hidVerificationTypeCode + "&Mode=View");
    }

    protected void ValidateDeclineCaseStatus(object source, ServerValidateEventArgs args)
    {
        if (source.ToString() == "0")
        {
            if (ddlCaseStatus.SelectedItem.Text.Trim().ToLower() == "decline" || ddlCaseStatus.SelectedItem.Text.Trim().ToLower() == "negative")
            {
                if (ddlOutcome.SelectedItem.Text.Trim().ToLower() == "select")
                {
                    pnlMsg.Visible = true;
                    tblMsg.Visible = true;
                    lblMsg.ForeColor = System.Drawing.Color.Red;
                    lblMsg.Text = "Please select Decline code/Outcome.";
                }
                if (txtDeclineReason.Text.Trim() == "")
                {
                    pnlMsg.Visible = true;
                    tblMsg.Visible = true;
                    lblMsg.ForeColor = System.Drawing.Color.Red;
                    lblMsg.Text = "Please enter Supervisor Remark.";
                }
            }

        }
    }

   
}
