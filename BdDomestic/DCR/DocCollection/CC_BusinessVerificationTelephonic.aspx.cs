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

public partial class CPV_CC_BusinessVerificationTelephonic : System.Web.UI.Page
{
    string verificationType = "BT";
    CGet objCGet = new CGet();
    CCommon objcon = new CCommon();
    CCreditCardTelephonicVerification objBVT = new CCreditCardTelephonicVerification();
    
    protected void Page_Init(object sender, EventArgs e)
    {
        funShowPanel();
    }
     protected void Page_Load(object sender, EventArgs e)
    {
        lblMessage.Text = "";
        
        if (!IsPostBack)
        {
            //To Show the Panels add By Manoj            
            funShowPanel();
            //End
            //if (Session["isAdd"].ToString() != "1")
            //    Response.Redirect("NoAccess.aspx");
            hdnTransStart.Value = DateTime.Now.ToString();//"dd/MM/yyyy hh:mm:ss tt");

            if ((Request.QueryString["CaseID"] != null) && (Request.QueryString["CaseID"] != ""))
            {
                if (Session["isEdit"].ToString() != "1")
                {
                    //Response.Redirect("NoAccess.aspx");
                    FillTelecallerName();
                    FillSupervisorName();
                    GetBusinessVerificationCaseDetail();
                    GetVerificationDescription();
                    GetVerificationDescription1();
                    GetVerificationOtherDetails();
                    GetVerificationDetails();
                    GetCaseStatusRemark();
                    GetTeleCallLog();
                    IfIsEditFalse();
                   
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
            txtContactedNo.Focus();
            txtDate1stCall.Text = DateTime.Now.ToString("dd/MM/yyyy");
            txtDate2ndCall.Text = DateTime.Now.ToString("dd/MM/yyyy");
            txtDate3rdCall.Text = DateTime.Now.ToString("dd/MM/yyyy");
            txtDate4thCall.Text = DateTime.Now.ToString("dd/MM/yyyy");
            txtDate5thCall.Text = DateTime.Now.ToString("dd/MM/yyyy");
            FillTelecallerName();
            FillSupervisorName();
            GetBusinessVerificationCaseDetail();
            GetVerificationDescription();
            GetVerificationDescription1();
            GetVerificationOtherDetails();
            GetVerificationDetails();
            GetCaseStatusRemark();
            GetTeleCallLog();

            string aa, sql, bb1;

            aa = Session["ClientId"].ToString();
            sql = "select client_name from client_master where client_id='" + aa + "'";
            object bb = OleDbHelper.ExecuteScalar(objcon.ConnectionString, CommandType.Text, sql);
            bb1 = bb.ToString();
           
            if (bb1.Substring(0, 4) == "Axis" || bb1.Substring(0, 4) == "Barc")
            {
            txtAddressOffice.Visible = false;
            lblAddressOffice.Visible = false;  
            txtLandmarkObserved.Visible = false;
            lblLandmarkObserved.Visible = false;
            txtContactedNo.Enabled = false;
            txtBusiContactNo.Enabled = false; 
            }
            else
            {
                txtAddressOffice.Visible = true;
                lblAddressOffice.Visible = true;
                txtLandmarkObserved.Visible = true;
                lblLandmarkObserved.Visible = true;
                txtContactedNo.Enabled = true;
                txtBusiContactNo.Enabled = true;
            }
            if (hidMode.Value == "View")
            {
                btnCancel.Enabled = false;
                btnSubmit.Enabled = false;
                LikButtonVisibility();
                //////add by santosh shelar//////////
                txtAddressOffice.Visible = true;
                lblAddressOffice.Visible = true;  
                txtLandmarkObserved.Visible = true;
                lblLandmarkObserved.Visible = true;
                txtContactedNo.Enabled = true;
                txtBusiContactNo.Enabled = true; 
                
            }
            
        }
    }


    protected void ddlTeleverificationResults_DataBound(object sender, EventArgs e)
    {
        ddlTeleverificationResults.Items.Insert(0, new ListItem("Select", "0"));
    }

    protected void cvSelectCaseStatus_ServerValidate(object source, ServerValidateEventArgs args)
    {
        if (source.ToString() == "0")
        {
            lblMessage.Visible = true;            
            lblMessage.Text = "Please select televerification result.";
        }
    }
    /// <summary>
    /// This method is used to get records from table CPV_CC_Veri_Attempts.
    /// </summary>
    private void GetTeleCallLog()
    {
        try
        {
            DataSet dsTeleCallLog = new DataSet();
            string sCaseId = hidCaseID.Value;
            if (sCaseId != "")
            {
                dsTeleCallLog = objBVT.GetTeleCallLogDetail(sCaseId, hidVerificationTypeID.Value);
                if (dsTeleCallLog.Tables[0].Rows.Count > 0)
                {

                    for (int i = 0; i < dsTeleCallLog.Tables[0].Rows.Count; i++)
                    {
                        if (i == 0)
                        {
                            string sAttemptDateTime = dsTeleCallLog.Tables[0].Rows[i]["ATTEMPT_DATE_TIME"].ToString();
                            string[] arrAttemptDateTime = sAttemptDateTime.Split(' ');
                            txtDate1stCall.Text = Convert.ToDateTime(arrAttemptDateTime[0].ToString()).ToString("dd/MM/yyyy");
                            txtTime1stCall.Text = Convert.ToDateTime(arrAttemptDateTime[1].ToString()).ToString("hh:mm");
                            ddlTime1stCall.SelectedValue = arrAttemptDateTime[2].ToString();
                            txtTelNo1stCall.Text = dsTeleCallLog.Tables[0].Rows[i]["TELEPHONE_NO"].ToString();
                            ddlRemarks1stCall.Text = dsTeleCallLog.Tables[0].Rows[i]["Remark"].ToString();
                            //ddlTeleName.SelectedValue = dsTeleCallLog.Tables[0].Rows[i]["VERIFIER_ID"].ToString();
                        }
                        if (i == 1)
                        {
                            string sAttemptDateTime = dsTeleCallLog.Tables[0].Rows[i]["ATTEMPT_DATE_TIME"].ToString();
                            string[] arrAttemptDateTime = sAttemptDateTime.Split(' ');
                            txtDate2ndCall.Text = Convert.ToDateTime(arrAttemptDateTime[0].ToString()).ToString("dd/MM/yyyy");
                            txtTime2ndCall.Text = Convert.ToDateTime(arrAttemptDateTime[1].ToString()).ToString("hh:mm");
                            ddlTime2ndCall.SelectedValue = arrAttemptDateTime[2].ToString();
                            txtTelNo2ndCall.Text = dsTeleCallLog.Tables[0].Rows[i]["TELEPHONE_NO"].ToString();
                            ddlRemarks2ndCall.Text = dsTeleCallLog.Tables[0].Rows[i]["Remark"].ToString();
                            //ddlTeleName.SelectedValue = dsTeleCallLog.Tables[0].Rows[i]["VERIFIER_ID"].ToString();
                        }
                        if (i == 2)
                        {
                            string sAttemptDateTime = dsTeleCallLog.Tables[0].Rows[i]["ATTEMPT_DATE_TIME"].ToString();
                            string[] arrAttemptDateTime = sAttemptDateTime.Split(' ');
                            txtDate3rdCall.Text = Convert.ToDateTime(arrAttemptDateTime[0].ToString()).ToString("dd/MM/yyyy");
                            txtTime3rdCall.Text = Convert.ToDateTime(arrAttemptDateTime[1].ToString()).ToString("hh:mm");
                            ddlTime3rdCall.SelectedValue = arrAttemptDateTime[2].ToString();
                            txtTelNo3rdCall.Text = dsTeleCallLog.Tables[0].Rows[i]["TELEPHONE_NO"].ToString();
                            ddlRemarks3rdCall.Text = dsTeleCallLog.Tables[0].Rows[i]["Remark"].ToString();
                            //ddlTeleName.SelectedValue = dsTeleCallLog.Tables[0].Rows[i]["VERIFIER_ID"].ToString();
                        }
                        if (i == 3)
                        {
                            string sAttemptDateTime = dsTeleCallLog.Tables[0].Rows[i]["ATTEMPT_DATE_TIME"].ToString();
                            string[] arrAttemptDateTime = sAttemptDateTime.Split(' ');
                            txtDate4thCall.Text = Convert.ToDateTime(arrAttemptDateTime[0].ToString()).ToString("dd/MM/yyyy");
                            txtTime4thCall.Text = Convert.ToDateTime(arrAttemptDateTime[1].ToString()).ToString("hh:mm");
                            ddlTime4thCall.SelectedValue = arrAttemptDateTime[2].ToString();
                            txtTelNo4thCall.Text = dsTeleCallLog.Tables[0].Rows[i]["TELEPHONE_NO"].ToString();
                            ddlRemarks4thCall.Text = dsTeleCallLog.Tables[0].Rows[i]["Remark"].ToString();
                            //ddlTeleName.SelectedValue = dsTeleCallLog.Tables[0].Rows[i]["VERIFIER_ID"].ToString();
                        }
                        if (i == 4)
                        {
                            string sAttemptDateTime = dsTeleCallLog.Tables[0].Rows[i]["ATTEMPT_DATE_TIME"].ToString();
                            string[] arrAttemptDateTime = sAttemptDateTime.Split(' ');
                            txtDate5thCall.Text = Convert.ToDateTime(arrAttemptDateTime[0].ToString()).ToString("dd/MM/yyyy");
                            txtTime5thCall.Text = Convert.ToDateTime(arrAttemptDateTime[1].ToString()).ToString("hh:mm");
                            ddlTime5thCall.SelectedValue = arrAttemptDateTime[2].ToString();
                            txtTelNo5thCall.Text = dsTeleCallLog.Tables[0].Rows[i]["TELEPHONE_NO"].ToString();
                            ddlRemarks5thCall.Text = dsTeleCallLog.Tables[0].Rows[i]["Remark"].ToString();
                            //ddlTeleName.SelectedValue = dsTeleCallLog.Tables[0].Rows[i]["VERIFIER_ID"].ToString();
                        }
                    }
            }

            }
        }
        catch (Exception ex)
        {
            lblMessage.Visible = true;
            lblMessage.Text = "Error while retreiving records:GetTeleCallLog " + ex.Message;
        }
    }
    /// <summary>
    /// This method is used to get records from table CPV_CC_Case_Details.
    /// </summary>
    private void GetBusinessVerificationCaseDetail()
    {
        try
        {
            OleDbDataReader oledbDRGet;
            oledbDRGet = objBVT.GetBusinessCaseDetail(hidCaseID.Value);
            if (oledbDRGet.Read())
            {
                if (!(oledbDRGet["FULL_NAME"].ToString().Trim().Length.Equals(0)))
                    txtAppName.Text = oledbDRGet["FULL_NAME"].ToString();

                if (!(oledbDRGet["REF_NO"].ToString().Trim().Length.Equals(0)))
                    txtRefNo.Text = oledbDRGet["REF_NO"].ToString();

                if (!(oledbDRGet["MOBILE"].ToString().Trim().Length.Equals(0)))
                    txtBusiContactNo.Text = oledbDRGet["MOBILE"].ToString();
                
                if (!(oledbDRGet["Case_REC_DATETIME"].ToString().Trim().Length.Equals(0)))
                    txtInitiationDate.Text = Convert.ToDateTime(oledbDRGet["Case_REC_DATETIME"].ToString()).ToString("dd/MM/yyyy");

                if (!(oledbDRGet["OFF_ADD_LINE_1"].ToString().Trim().Length.Equals(0)))
                    txtAddressOffice.Text = oledbDRGet["OFF_ADD_LINE_1"].ToString();

                //if (!(oledbDRGet["mismatch_resi_add"].ToString().Trim().Length.Equals(0)))
                //    txtApplicantResidentialAddress.Text = oledbDRGet["mismatch_resi_add"].ToString();

                //if (!(oledbDRGet["DEPARTMENT"].ToString().Trim().Length.Equals(0)))
                //    txtDeptofApp.Text = oledbDRGet["DEPARTMENT"].ToString();

                //if (!(oledbDRGet["rsidence_phone_no"].ToString().Trim().Length.Equals(0)))
                //    txtResiPhoneNo.Text = oledbDRGet["rsidence_phone_no"].ToString();

                if (!(oledbDRGet["DESIGNATION"].ToString().Trim().Length.Equals(0)))
                    txtDesignation.Text = oledbDRGet["DESIGNATION"].ToString();

                if (!(oledbDRGet["OFF_PHONE"].ToString().Trim().Length.Equals(0)))
                    txtContactedNo.Text = oledbDRGet["OFF_PHONE"].ToString();
                /////add by santosh shelar 28-08-08///////////////////////
                if (!(oledbDRGet["OFF_NAME"].ToString().Trim().Length.Equals(0)))
                    txtNameOfCompany.Text = oledbDRGet["OFF_NAME"].ToString();
   
            }
            oledbDRGet.Close();
            oledbDRGet.Dispose();
        }
        catch (Exception ex)
        {
            lblMessage.Visible = true;
            lblMessage.Text = "Error while retreiving records:GetTeleCallLog " + ex.Message;
        }
    }
    /// <summary>
    /// This method is used to get records from table CPV_CC_Veri_OtherDetails.
    /// </summary>
    private void GetVerificationOtherDetails()
    {
        try
        {
            OleDbDataReader oledbDR;
            oledbDR = objBVT.GetVerificationBusinessOtherDetail(hidCaseID.Value, hidVerificationTypeID.Value);
            if (oledbDR.Read())
            {
                if (!(oledbDR["AGENCY_NAME"].ToString().Trim().Length.Equals(0)))
                    txtAgencyCode.Text = oledbDR["AGENCY_NAME"].ToString();

                if (!(oledbDR["PERMANENT_ADDRESS"].ToString().Trim().Length.Equals(0)))
                    txtPermanentAdd.Text = oledbDR["PERMANENT_ADDRESS"].ToString();

                if (!(oledbDR["REL_WITH_APPLICANT"].ToString().Trim().Length.Equals(0)))
                    ddlContactedpersonRelationshipWithApplicant.Text = oledbDR["REL_WITH_APPLICANT"].ToString();

                if (!(oledbDR["OTHERS_DESIGNATION"].ToString().Trim().Length.Equals(0)))
                    txtOtherContactedDesignation.Text = oledbDR["OTHERS_DESIGNATION"].ToString();
                ////////////add by santosh shelar////////////
                if (!(oledbDR["Address_Match"].ToString().Trim().Length.Equals(0)))
                txtAppliResiAdd.Text = oledbDR["Address_Match"].ToString();

            if (!(oledbDR["applicant_home_country_phone"].ToString().Trim().Length.Equals(0)))
                ddlNameofApplicantConfirmedatgivenPhoneNo1.SelectedValue = oledbDR["applicant_home_country_phone"].ToString();

            if (!(oledbDR["IS_RESIDANT"].ToString().Trim().Length.Equals(0)))
                ddlmismatch.SelectedValue = oledbDR["IS_RESIDANT"].ToString();


            }
           
            oledbDR.Close();
            oledbDR.Dispose();
        }
        catch (Exception ex)
        {
            lblMessage.Visible = true;
            lblMessage.Text = "Error while retreiving records:GetTeleCallLog " + ex.Message;
        }
    }
   
    /// <summary>
    /// This method is used to get records from the table cpv_cc_veri_description1
    /// </summary>
    private void GetVerificationDescription1()
    {
        try
        {
            OleDbDataReader oledbDR;
            ///////////Modified by Sunny Chauhan Field Added DIRECTORY_CHK_ADD_REASON /////////
            oledbDR = objBVT.GetBusinessVerificationDescription1(hidCaseID.Value, hidVerificationTypeID.Value);
            if (oledbDR.Read())
            {
                if (!(oledbDR["CONTACTED_PERSON_NAME"].ToString().Trim().Length.Equals(0)))
                    txtPersonContacted.Text = oledbDR["CONTACTED_PERSON_NAME"].ToString();

                if (!(oledbDR["INCOME_DOC_SUBMITTED_WITH_APLICATION"].ToString().Trim().Length.Equals(0)))
                    ddlIncomeDocsSub.SelectedValue = oledbDR["INCOME_DOC_SUBMITTED_WITH_APLICATION"].ToString();

                if (!(oledbDR["TIME_AT_CURRENT_EMPLOYMENT"].ToString().Trim().Length.Equals(0)))

                    txtTimeatCurrEmplApp.Text = oledbDR["TIME_AT_CURRENT_EMPLOYMENT"].ToString();


                if (!(oledbDR["OFFICE_EXT"].ToString().Trim().Length.Equals(0)))
                    txtExtNo.Text = oledbDR["OFFICE_EXT"].ToString();

                if (!(oledbDR["DESIGNATION"].ToString().Trim().Length.Equals(0)))
                    txtAppDesignation.Text = oledbDR["DESIGNATION"].ToString();


                if (!(oledbDR["DOB_APPLICANT"].ToString().Trim().Length.Equals(0)))
                    txtDOB.Text = oledbDR["DOB_APPLICANT"].ToString();

                if (!(oledbDR["APPLICANT_IS_AVAILABLE_AT"].ToString().Trim().Length.Equals(0)))
                    txtAppAvailable.Text = oledbDR["APPLICANT_IS_AVAILABLE_AT"].ToString();

                if (!(oledbDR["NEW_DETAILS_OBTAINED"].ToString().Trim().Length.Equals(0)))
                    txtNewDetailObt.Text = oledbDR["NEW_DETAILS_OBTAINED"].ToString();

                if (!(oledbDR["SPECIAL_INSTRUCTIONS"].ToString().Trim().Length.Equals(0)))
                    txtSpecialInstructions.Text = oledbDR["SPECIAL_INSTRUCTIONS"].ToString();

                if (!(oledbDR["IF_OFFICE_ADD_IS_IN_NEGATIVE_AREA"].ToString().Trim().Length.Equals(0)))
                    ddlIsofficeAreaNegativeArea.SelectedValue = oledbDR["IF_OFFICE_ADD_IS_IN_NEGATIVE_AREA"].ToString();

                if (!(oledbDR["BUSINESS_CONTACT_EXTN"].ToString().Trim().Length.Equals(0)))
                    txtExtnNumber.Text = oledbDR["BUSINESS_CONTACT_EXTN"].ToString();

                if (!(oledbDR["APPLICANT_NAME_CONFIRMED_AT_GIVEN_NO"].ToString().Trim().Length.Equals(0)))
                    ddlNameofApplicantConfirmedatgivenPhoneNo.SelectedValue = oledbDR["APPLICANT_NAME_CONFIRMED_AT_GIVEN_NO"].ToString();


                if (!(oledbDR["CHANGE_IN_PHONE_NO"].ToString().Trim().Length.Equals(0)))
                    ddlChangeinPhoneNumber.SelectedValue = oledbDR["CHANGE_IN_PHONE_NO"].ToString();

                if (!(oledbDR["REASON_FOR_CHANGE"].ToString().Trim().Length.Equals(0)))
                    ddlReasonforchange.SelectedValue = oledbDR["REASON_FOR_CHANGE"].ToString();

                if (!(oledbDR["YCR"].ToString().Trim().Length.Equals(0)))
                    txtYCR.Text = oledbDR["YCR"].ToString();

                if (!(oledbDR["SEGMENTATION"].ToString().Trim().Length.Equals(0)))
                    txtSegmentation.Text = oledbDR["SEGMENTATION"].ToString();

                if (!(oledbDR["RESIDANCE_IS"].ToString().Trim().Length.Equals(0)))
                    ddlResidenceIs.SelectedValue = oledbDR["RESIDANCE_IS"].ToString();

                if (!(oledbDR["MAILING_ADDRESS"].ToString().Trim().Length.Equals(0)))
                    ddlMailingAddress.SelectedValue = oledbDR["MAILING_ADDRESS"].ToString();

                if (!(oledbDR["RESI_COMOFF_OWNED"].ToString().Trim().Length.Equals(0)))
                    ddlResiCumOffice.SelectedValue = oledbDR["RESI_COMOFF_OWNED"].ToString();

                if (!(oledbDR["IS_RESI_ADD_IS_IN_NEGATIVE_AREA"].ToString().Trim().Length.Equals(0)))
                    ddlIsResidenceAddressNegativeArea.SelectedValue = oledbDR["IS_RESI_ADD_IS_IN_NEGATIVE_AREA"].ToString();


                if (!(oledbDR["DESIG_AND_DEPT_OF_CONTACTED_PERSON"].ToString().Trim().Length.Equals(0)))
                    txtDesigDeptContactedPerson.Text = oledbDR["DESIG_AND_DEPT_OF_CONTACTED_PERSON"].ToString();

                if (!(oledbDR["NATURE_BUSINESS_RESI_CUM_OFF"].ToString().Trim().Length.Equals(0)))
                    ddlNatureofBusinessofCompany.SelectedValue = oledbDR["NATURE_BUSINESS_RESI_CUM_OFF"].ToString();

                if (!(oledbDR["CALLED_UP_ON_OFFICE_TEL_NO"].ToString().Trim().Length.Equals(0)))
                    txtCalledupOffTelNo.Text = oledbDR["CALLED_UP_ON_OFFICE_TEL_NO"].ToString();


                if (!(oledbDR["NO_OF_YEARS_AT_CURRENT_EMPLOYMENT"].ToString().Trim().Length.Equals(0)))
                    txtNoOfYearscurrEmployment.Text = oledbDR["NO_OF_YEARS_AT_CURRENT_EMPLOYMENT"].ToString();

                if (!(oledbDR["TELE_COMMENTS"].ToString().Trim().Length.Equals(0)))
                    txtTeleComments.Text = oledbDR["TELE_COMMENTS"].ToString();


                if (!(oledbDR["TIME_AT_CURRENT_EMPL_Y_M"].ToString().Trim().Length.Equals(0)))
                {

                    string[] timeAtCurrentEmplYM = oledbDR["TIME_AT_CURRENT_EMPL_Y_M"].ToString().Split('.');
                    if (timeAtCurrentEmplYM[0].Length > 0)
                        txtTimeCurrEmplYrs.Text = timeAtCurrentEmplYM[0];
                    if (timeAtCurrentEmplYM[1].Length > 0)
                        txtTimeCurrEmplMths.Text = timeAtCurrentEmplYM[1];

                }

                if (!(oledbDR["COMPANY_NAME"].ToString().Trim().Length.Equals(0)))
                    txtNameOfCompany.Text = oledbDR["COMPANY_NAME"].ToString();

                if (!(oledbDR["LAND_MARK_OBSERVED"].ToString().Trim().Length.Equals(0)))
                    txtLandmarkObserved.Text = oledbDR["LAND_MARK_OBSERVED"].ToString();
                
                if (!(oledbDR["DIRECTORY_CHECK"].ToString().Trim().Length.Equals(0)))
                    ddlDirectoryCheck.SelectedValue = oledbDR["DIRECTORY_CHECK"].ToString();

                /////// Added By Sunny Chauhan : Start /////////////////////
                if (!(oledbDR["DIRECTORY_CHK_ADD_REASON"].ToString().Trim().Length.Equals(0)))
                    txtNoReason.Text = oledbDR["DIRECTORY_CHK_ADD_REASON"].ToString();
                /////// Addition End : Sunny Chauhan //////////////////////

                if (!(oledbDR["SPK_TO"].ToString().Trim().Length.Equals(0)))
                    txtSpkToAppReceiptColleague.Text = oledbDR["SPK_TO"].ToString();

                if (!(oledbDR["CURRENT_RESIDENCE_PERIOD"].ToString().Trim().Length.Equals(0)))
                    txtCurrentResidencePeriod.Text = oledbDR["CURRENT_RESIDENCE_PERIOD"].ToString();

                if (!(oledbDR["APP_QUALIFICATION"].ToString().Trim().Length.Equals(0)))
                    txtApplicantQualification.Text = oledbDR["APP_QUALIFICATION"].ToString();

                if (!(oledbDR["Appli_Dept"].ToString().Trim().Length.Equals(0)))
                    txtDeptofApp.Text = oledbDR["Appli_Dept"].ToString();

                if (!(oledbDR["dir_check"].ToString().Trim().Length.Equals(0)))
                    ddlDirCheck.SelectedValue = oledbDR["Dir_Check"].ToString();
                
            }
           
            oledbDR.Close();
            oledbDR.Dispose();
        }
        catch (Exception ex)
        {
            lblMessage.Visible = true;
            lblMessage.Text = "Error while retreiving records:GetTeleCallLog " + ex.Message;
        }
    }
    ///<summary>
    /// This method is used to get records from table CPV_CC_Veri_Description.
    /// </summary>
    private void GetVerificationDescription()
    {
        try
        {
            OleDbDataReader oledbDR;

            ////////Modified By Sunny Chauhan[GetBusinessVerificationDescription]//////////////////

            oledbDR = objBVT.GetBusinessVerificationDescription(hidCaseID.Value, hidVerificationTypeID.Value);
            if (oledbDR.Read())
            {
                if (!(oledbDR["QUALIFICATION"].ToString().Trim().Length.Equals(0)))
                    txtQualification.Text = oledbDR["QUALIFICATION"].ToString();

                ////////Added by Sunny Chauhan for CD ROM NAME CONFIRMED : Start/////////////
                if (!(oledbDR["Mismatch_Resi_Add"].ToString().Trim().Length.Equals(0)))
                    txtNoReason.Text = oledbDR["Mismatch_Resi_Add"].ToString();
                ////////Addition End Sunny Chauhan/////////////

                if (!(oledbDR["CONTACTABILITY"].ToString().Trim().Length.Equals(0)))
                    ddlContactability.SelectedValue = oledbDR["CONTACTABILITY"].ToString();

                if (!(oledbDR["PROFILE"].ToString().Trim().Length.Equals(0)))
                    ddlProfile.SelectedValue = oledbDR["PROFILE"].ToString();

                if (!(oledbDR["REPUTATION"].ToString().Trim().Length.Equals(0)))
                    ddlReputation.SelectedValue = oledbDR["REPUTATION"].ToString();

                if (!(oledbDR["INFO_REQUIRED"].ToString().Trim().Length.Equals(0)))
                    txtInfoRequired.Text = oledbDR["INFO_REQUIRED"].ToString();

                if (!(oledbDR["PRIORITY_CUSTOMER"].ToString().Trim().Length.Equals(0)))
                    ddlPriorityCustomer.SelectedValue = oledbDR["PRIORITY_CUSTOMER"].ToString();

                if (!(oledbDR["ADRESS_CONFIRMATION"].ToString().Trim().Length.Equals(0)))
                    ddlAddrConfirmation.SelectedValue = oledbDR["ADRESS_CONFIRMATION"].ToString();

                if (!(oledbDR["APPLICANT_AGE"].ToString().Trim().Length.Equals(0)))
                    txtAgeApproxApp.Text = oledbDR["APPLICANT_AGE"].ToString();

                if (!(oledbDR["TIME_AT_CURR_Y_M"].ToString().Trim().Length.Equals(0)))
                {

                    string[] timeAtCurrentResi = oledbDR["TIME_AT_CURR_Y_M"].ToString().Split('.');
                    if (timeAtCurrentResi[0].Length > 0)
                        txtTimeCurrResiYears.Text = timeAtCurrentResi[0];
                    if (timeAtCurrentResi[1].Length > 0)
                        txtTimeCurrResiMonth.Text = timeAtCurrentResi[1];

                }
                if (!(oledbDR["RECOMMENDATION"].ToString().Trim().Length.Equals(0)))
                    ddlRecommendation.SelectedValue = oledbDR["RECOMMENDATION"].ToString();

                if (!(oledbDR["CONFIRMATION_IF_APPLICANT_MET"].ToString().Trim().Length.Equals(0)))
                    ddlConfirmationApplication.SelectedValue = oledbDR["CONFIRMATION_IF_APPLICANT_MET"].ToString();

                if (!(oledbDR["TELE_CALLER_NAME"].ToString().Trim().Length.Equals(0)))
                    //txtTelecallerName.Text = oledbDR["TELE_CALLER_NAME"].ToString();
                    ddlTeleName.SelectedValue = oledbDR["TELE_CALLER_NAME"].ToString();

                if (!(oledbDR["FOR_SELF_EMPLOYED_TYPE_OF_ORGANIZATION"].ToString().Trim().Length.Equals(0)))
                    ddlForSelfEmployedTypeOrganisation.SelectedValue = oledbDR["FOR_SELF_EMPLOYED_TYPE_OF_ORGANIZATION"].ToString();

                if (!(oledbDR["EMP_PERMANENT_TEMP"].ToString().Trim().Length.Equals(0)))
                    txtEmpPermanentTemp.Text = oledbDR["EMP_PERMANENT_TEMP"].ToString();

                if (!(oledbDR["EMP_CONFIRMED_OR_NOT_CONFIRMED"].ToString().Trim().Length.Equals(0)))
                    txtEmpConfirmedNotconfirmed.Text = oledbDR["EMP_CONFIRMED_OR_NOT_CONFIRMED"].ToString();

                if (!(oledbDR["APP_DOB_APPROX_AGE"].ToString().Trim().Length.Equals(0)))
                    txtApplicantDOBApproxAge.Text = oledbDR["APP_DOB_APPROX_AGE"].ToString();

                if (!(oledbDR["RSIDENCE_PHONE_NO"].ToString().Trim().Length.Equals(0)))
                    txtResidencePhoneNo.Text = oledbDR["RSIDENCE_PHONE_NO"].ToString();

                if (!(oledbDR["OTHER_CONTACTED_DESIGNATION"].ToString().Trim().Length.Equals(0)))
                    txtOtherContactedDesignation.Text = oledbDR["OTHER_CONTACTED_DESIGNATION"].ToString();
                
                ///////////////////////////////////add by santosh shelar 11-09-08/////////////////
                if (!(oledbDR["OTHER_NATURE_OF_BUSINESS"].ToString().Trim().Length.Equals(0)))
                    ddlBusinessNature.SelectedValue = oledbDR["OTHER_NATURE_OF_BUSINESS"].ToString();

                if (!(oledbDR["Other_Nature_Buss"].ToString().Trim().Length.Equals(0)))
                    TextBox1.Text = oledbDR["Other_Nature_Buss"].ToString();    
                /////////////////////
                if (!(oledbDR["ADDITIONAL_REMARK"].ToString().Trim().Length.Equals(0)))
                    txtAdditionalRemark.Text = oledbDR["ADDITIONAL_REMARK"].ToString();

                if (!(oledbDR["EMPLOYERS_NAME"].ToString().Trim().Length.Equals(0)))
                    txtEmployersName.Text = oledbDR["EMPLOYERS_NAME"].ToString();
                
                if (!(oledbDR["Change_In_Adress"].ToString().Trim().Length.Equals(0)))
                    txtChangeAdd.Text = oledbDR["Change_In_Adress"].ToString();
                
            }
            oledbDR.Close();
            oledbDR.Dispose();
        }
        catch (Exception ex)
        {
            lblMessage.Visible = true;
            lblMessage.Text = "Error while retreiving records:GetTeleCallLog " + ex.Message;
        }
    }
    ///<summary>
    /// This method is used to get records from table CPV_CC_Veri_Details.
    /// </summary>
    /// 
    private void GetCaseStatusRemark()
    {
        try
        {
            DataSet ds = new DataSet();
            ds = objBVT.DataCaseStatusRemark(Session["UserID"].ToString(), Session["ProductId"].ToString());
            ddlTeleverificationResults.DataSource = ds;
            ddlTeleverificationResults.DataBind();
            //oledbDR.Close();
            //oledbDR.Dispose();
        }
        catch (Exception ex)
        {
            lblMessage.Visible = true;
            lblMessage.Text = "Error while retreiving records:GetTeleCallLog " + ex.Message;
        }
    }
    private void GetVerificationDetails()
    {
        try
        {
            OleDbDataReader oledbDR;
            oledbDR = objBVT.GetBusinessVerificationDetail(hidCaseID.Value, hidVerificationTypeID.Value);
            if (oledbDR.Read())
            {

                if (!(oledbDR["SUPERVISOR_REMARKS"].ToString().Trim().Length.Equals(0)))
                    txtSupervisorRemark.Text = oledbDR["SUPERVISOR_REMARKS"].ToString();

                if (!(oledbDR["Any_Info"].ToString().Trim().Length.Equals(0)))
                    txtNewInfoObt.Text = oledbDR["Any_Info"].ToString();
                ddlTeleverificationResults.DataBind();
                if (!(oledbDR["CASE_STATUS_ID"].ToString().Trim().Length.Equals(0)))
                    ddlTeleverificationResults.SelectedValue = oledbDR["CASE_STATUS_ID"].ToString();

                if (!(oledbDR["OVERALL_ASSESMENT"].ToString().Trim().Length.Equals(0)))
                    ddlOverallAssessment.Text = oledbDR["OVERALL_ASSESMENT"].ToString();

                if (!(oledbDR["OVERALL_ASSESMENT_REASON"].ToString().Trim().Length.Equals(0)))
                    txtReasonsforAssessment.Text = oledbDR["OVERALL_ASSESMENT_REASON"].ToString();
                
                ////////ADDED BY SUNNY CHAUHAN : START///////////////////////
                
                if (!(oledbDR["ACTUAL_NUM_TYPE"].ToString().Trim().Length.Equals(0)))
                    ddlActContNum.SelectedValue = oledbDR["ACTUAL_NUM_TYPE"].ToString();

                if (!(oledbDR["ACTUAL_NUMBER"].ToString().Trim().Length.Equals(0)))
                    txtActualNumber.Text = oledbDR["ACTUAL_NUMBER"].ToString();

                ////////ADDITION ENDED : SUNNY CHAUHAN//////////////////////
                ///////add by santosh shelar//////////////////
                if (!(oledbDR["SUPERVISOR_ID"].ToString().Trim().Length.Equals(0)))
                    ddlSupervisorName.SelectedValue = oledbDR["SUPERVISOR_ID"].ToString();

                if (!(oledbDR["declined_reason"].ToString().Trim().Length.Equals(0)))
                    txtDeclineReasons.Text = oledbDR["declined_reason"].ToString();

            
            }
           
            oledbDR.Close();
            oledbDR.Dispose();
        }
        catch (Exception ex)
        {
            lblMessage.Visible = true;
            lblMessage.Text = "Error while retreiving records:GetTeleCallLog " + ex.Message;
        }
    }

    /// <summary>
    /// In this Method Properties values are assigned through Related text and DropDown. 
    /// </summary>
    private void PropertySet()
    {
        try
        {
            //Common Properties for all Tables
            
            objBVT.CaseID = hidCaseID.Value.ToString();
            objBVT.VerificationTypeID = hidVerificationTypeID.Value.ToString();

            //for CPV_CC_VERI_DESCRIPTION1

            objBVT.PersonContacted = txtPersonContacted.Text.ToString();

            objBVT.IncomeDocsSubmittedWithApplication = ddlIncomeDocsSub.SelectedValue.ToString();

            objBVT.TimeAtCurrEmpl = txtTimeatCurrEmplApp.Text.ToString();

            objBVT.ExtnNo = txtExtNo.Text.ToString();

            objBVT.AppDesignation = txtAppDesignation.Text.ToString();
            objBVT.DirCheck = ddlDirCheck.SelectedValue.ToString();  

            //if (txtDOB.Text.Trim() != "")

            //    objBVT.DOBofApplicant = Convert.ToDateTime(txtDOB.Text.ToString());
            objBVT.DOBofApplicant = txtDOB.Text.ToString();

            objBVT.ApplicantAvailableAt = txtAppAvailable.Text.ToString();

            objBVT.NewDetailsObt = txtNewDetailObt.Text.ToString();

            objBVT.SpecialInstructions = txtSpecialInstructions.Text.ToString();

            objBVT.IsOfficeAreaIsNegativeArea = ddlIsofficeAreaNegativeArea.SelectedValue.ToString();

            //objBVT.BusinessContactNo = txtContactedNo.Text.ToString();
            objBVT.OfficePhone = txtContactedNo.Text.ToString();

            objBVT.BusinessExtnNo = txtExtnNumber.Text.ToString();

            objBVT.NameOfApplicantConfirmedAtGivenPhoneNo = ddlNameofApplicantConfirmedatgivenPhoneNo.SelectedValue.ToString();

            objBVT.ChangeInPhoneNumber = ddlChangeinPhoneNumber.SelectedValue.ToString();

            objBVT.ReasonForChange = ddlReasonforchange.SelectedValue.ToString();

            objBVT.YCR = txtYCR.Text.ToString();

            objBVT.Segmentation = txtSegmentation.Text.ToString();

            objBVT.DirectoryCheck = ddlDirectoryCheck.SelectedValue.ToString();
            ////////Added By Sunny Chauhan : Start /////////////////
            objBVT.NoReason = txtNoReason.Text.ToString();
            ///////Addition Ended : Sunny Chauhan //////////////////

            objBVT.TimeAtCurrEmpl = txtTimeatCurrEmplApp.Text.ToString();



            objBVT.SpkTo = txtSpkToAppReceiptColleague.Text.ToString();

            objBVT.ResidenceIs = ddlResidenceIs.SelectedValue.ToString();

            objBVT.MailingAddress = ddlMailingAddress.SelectedValue.ToString();

            objBVT.ResiCumOffice = ddlResiCumOffice.SelectedValue.ToString();

            objBVT.IsResidenceAddressIsNegativeArea = ddlIsResidenceAddressNegativeArea.SelectedValue.ToString();

            objBVT.DesigDeptOfContactedPerson = txtDesigDeptContactedPerson.Text.ToString();

            objBVT.NatureOfBusiness = ddlNatureofBusinessofCompany.SelectedValue.ToString();
            //////////add by santosh shelar 12-09-08////////////////////////
            objBVT.DeptOfApplicant = txtDeptofApp.Text.ToString();
            objBVT.OthNatureBuss = TextBox1.Text.ToString();  
            ////
            objBVT.CalledUpOnOffTelNo = txtCalledupOffTelNo.Text.ToString();

            objBVT.NoOfYearsAtCurrentEmployment = txtNoOfYearscurrEmployment.Text.ToString();

            objBVT.TeleComments = txtTeleComments.Text.ToString();

            objBVT.TimeAtCurrentEmplYearMonth = (txtTimeCurrEmplYrs.Text.ToString()) + "." + (txtTimeCurrEmplMths.Text.ToString());

            objBVT.NameOfCompany = txtNameOfCompany.Text.ToString();

            objBVT.LandmarkOberservered = txtLandmarkObserved.Text.ToString();

            objBVT.CurrentResidencePeriod = txtCurrentResidencePeriod.Text.ToString();

            objBVT.ApplicantQualification = txtApplicantQualification.Text.ToString();



            //for CPV_CC_VERI_DESCRIPTION

            objBVT.Contactability = ddlContactability.SelectedValue.ToString();
            objBVT.Profile = ddlProfile.SelectedValue.ToString();
            objBVT.Reputation = ddlReputation.SelectedValue.ToString();
            objBVT.Qualification = txtQualification.Text.ToString();
            objBVT.InfoRequired = txtInfoRequired.Text.ToString();
            objBVT.PriorityCustomer = ddlPriorityCustomer.SelectedValue.ToString();
            objBVT.AddressConfirmation = ddlAddrConfirmation.SelectedValue.ToString();
            objBVT.AgeApproxOfApplicant = txtAgeApproxApp.Text.ToString();

            objBVT.TimeAtCurrResiYearMonth = (txtTimeCurrResiYears.Text.ToString()) + "." + (txtTimeCurrResiMonth.Text.ToString());
            objBVT.Recommendation = ddlRecommendation.SelectedValue.ToString();
            objBVT.ConfirmApplication = ddlConfirmationApplication.SelectedValue.ToString();


            objBVT.ForSelfEmployedTypeOfOrganisation = ddlForSelfEmployedTypeOrganisation.SelectedValue.ToString();
            objBVT.EmpPermanentTemp = txtEmpPermanentTemp.Text.ToString();
            objBVT.EmpConfirmedNotConfirmed = txtEmpConfirmedNotconfirmed.Text.ToString();

            objBVT.AppDOBApproxAge = txtApplicantDOBApproxAge.Text.ToString();
            objBVT.ResidencePhoneNo = txtResidencePhoneNo.Text.ToString();
            objBVT.DesignationOfOtherContacted = txtOtherContactedDesignation.Text.ToString();
                        
            /////add by santosh shelar 11-09-08/////////////////
            objBVT.OthersNatureOfBusiness = ddlBusinessNature.SelectedValue.ToString();
            objBVT.OthNatureBuss = TextBox1.Text.ToString();    
 
            /////////////////////////////////////////////////////////////////////////////////
            objBVT.AdditionalRemark = txtAdditionalRemark.Text.ToString();

            objBVT.EmployersName = txtEmployersName.Text.ToString();
            objBVT.OverallAssessment = ddlOverallAssessment.SelectedValue.ToString();
            objBVT.ReasonsAssessment = txtReasonsforAssessment.Text.ToString();

            /////Santosh Shelar : Start //////////
            objBVT.ChangeAddress = txtChangeAdd.Text.ToString();
            //objBVT.TeleCallerName = ddlTeleName.SelectedValue.ToString();
            objBVT.TeleCallerName = ddlTeleName.SelectedItem.ToString();   
           
            /////Santosh Shelar : End ////////////

            //for CPV_CC_VERI_OTHER_DETAILS

            objBVT.PermanentAddress = txtPermanentAdd.Text.ToString();
            objBVT.Relationship = ddlContactedpersonRelationshipWithApplicant.SelectedValue.Trim().ToString();
            objBVT.OtherDesignation = txtOtherContactedDesignation.Text.ToString();
            objBVT.AppResiAdd = txtAppliResiAdd.Text.ToString();
            objBVT.NameofApplicantConfirmedatgivenPhoneNo1 = ddlNameofApplicantConfirmedatgivenPhoneNo1.SelectedValue.ToString();
            objBVT.MisMatch = ddlmismatch.SelectedValue.ToString();    

            //for CPV_CC_CASE_DETAILS
            objBVT.OfficeAddress = txtAddressOffice.Text.ToString();
            objBVT.ResiAddress = txtApplicantResidentialAddress.Text.ToString();
            objBVT.ResiPhone = txtResiPhoneNo.Text.ToString();
            objBVT.Designation = txtDesignation.Text.ToString();

            //for CPV_CC_VERI_DETAILS
            objBVT.AnyOtherInfo = txtNewInfoObt.Text.Trim();
            objBVT.SupervisorRemark = txtSupervisorRemark.Text.ToString();
            objBVT.TeleVerificationResult = ddlTeleverificationResults.SelectedValue.ToString();
            //////add by santosh shelar 25-08-08///////////////////
            objBVT.DeclineReasons = txtDeclineReasons.Text.Trim();
            objBVT.SupervisorName = ddlSupervisorName.SelectedValue.ToString(); 
            
            //////ADDED BY SUNNY CHAUHAN : START///////////////////////////
            objBVT.ACTNUMBER = txtActualNumber.Text.ToString();
            objBVT.ACTNUMTYPE = ddlActContNum.SelectedValue.ToString();
            ////ADDITION ENDED : SUNNY CHAUHAN////////////////////////////
            
            objBVT.AddedBy = Session["UserId"].ToString();
            objBVT.AddedOn = DateTime.Now;
            //added by hemangi kambli on 07/09/2007--------------
            objBVT.ModifyBy = Session["UserId"].ToString();
            objBVT.ModifyOn = DateTime.Now;
            ///------------------------------------------------------
            /// //Added by hemangi kambli on 03/10/2007 
            if (hdnTransStart.Value != "")
                objBVT.TransStart = Convert.ToDateTime(hdnTransStart.Value);
            objBVT.TransEnd = Convert.ToDateTime(DateTime.Now.ToString());//"dd/MM/yyyy hh:mm:ss tt"));
            objBVT.CentreId = Session["CentreId"].ToString();
            objBVT.ProductId = Session["ProductId"].ToString();
            objBVT.ClientId = Session["ClientId"].ToString();
            objBVT.UserId = Session["UserId"].ToString();
            ///------------------------------------------------------
        }
        catch (Exception ex)
        {
            lblMessage.Visible = true;
            lblMessage.Text = "Error while assigning property: " + ex.Message;
        }
    }
    /// <summary>
    /// This method is used to Fill the drop down of telecallar.
    /// </summary>
    private void FillTelecallerName()
    {
        try
        {
            DataTable dtTeleCallerName = new DataTable();
            dtTeleCallerName = objBVT.GetTeleCallerName(Session["CentreId"].ToString(), Session["UserId"].ToString(), hidCaseID.Value, hidVerificationTypeID.Value);
            ddlTeleName.DataTextField = "FULLNAME";
            ddlTeleName.DataValueField = "EMP_ID";
            ddlTeleName.DataSource = dtTeleCallerName;
            ddlTeleName.DataBind();
            //dtTeleCallerName.Clear();
            //dtTeleCallerName.Dispose();
        }
        catch (Exception ex)
        {
            lblMessage.Visible = true;
            lblMessage.Text = "Error while retreiving records:GetTeleCallLog " + ex.Message;
        }
    }
    /// <summary>
    /// This method is used to Insert the Records in the required table
    /// </summary>
    /// <returns></returns>
    //////////////add by santosh shelar 30-08-08///////////////////////////// 
    private void FillSupervisorName()
    {
        DataTable dtSupName = new DataTable();
        dtSupName = objBVT.GetSupervisorName(Session["CentreId"].ToString());
        ddlSupervisorName.DataTextField = "FULLNAME";
        ddlSupervisorName.DataValueField = "EMP_ID";
        ddlSupervisorName.DataSource = dtSupName;
        ddlSupervisorName.DataBind();

    }
   
    private string InsertBusinessVerificationDetail()
    {
        string msg = "";
        try
        {
            PropertySet();
            msg=objBVT.InsertBusinessVerificationDetails();
            return msg;
        }
        catch (Exception ex)
        {
            throw new Exception("Error Found During Insertion" + ex.Message);
        }


    }
    /// <summary>
    /// This method is used to Insert the Records in the CPV_CC_veri_Attempts
    /// </summary>
    private void InsertTeleCallLog()
    {


        try
        {
            ArrayList arrTeleCallLog = new ArrayList();
            ArrayList arrLog1stCall = new ArrayList();
            ArrayList arrLog2ndCall = new ArrayList();
            ArrayList arrLog3rdCall = new ArrayList();
            ArrayList arrLog4thCall = new ArrayList();
            ArrayList arrLog5thCall = new ArrayList();

            string strCaseID = hidCaseID.Value;
            objBVT.CaseID = strCaseID;

            CCommon objCom = new CCommon();
            objBVT.VerificationType = "BVT";



            if (txtDate1stCall.Text.Trim() != "" && txtTime1stCall.Text.Trim() != "")
            {
                arrLog1stCall.Clear();
                arrLog1stCall.Add(objCom.strDate(txtDate1stCall.Text.Trim()) + " " + txtTime1stCall.Text.Trim() + " " + ddlTime1stCall.SelectedItem.Text.Trim());
                arrLog1stCall.Add(ddlRemarks1stCall.SelectedItem.Text.Trim());
                arrLog1stCall.Add(txtTelNo1stCall.Text.Trim());
                arrLog1stCall.Add(ddlTeleName.SelectedValue.Trim());
                arrTeleCallLog.Add(arrLog1stCall);
            }

            if (txtDate2ndCall.Text.Trim() != "" && txtTime2ndCall.Text.Trim() != "")
            {
                arrLog2ndCall.Clear();
                arrLog2ndCall.Add(objCom.strDate(txtDate2ndCall.Text.Trim()) + " " + txtTime2ndCall.Text.Trim() + " " + ddlTime2ndCall.SelectedItem.Text.Trim());
                arrLog2ndCall.Add(ddlRemarks2ndCall.SelectedItem.Text.Trim());
                arrLog2ndCall.Add(txtTelNo2ndCall.Text.Trim());
                arrLog2ndCall.Add(ddlTeleName.SelectedValue.Trim());
                arrTeleCallLog.Add(arrLog2ndCall);
            }

            if (txtDate3rdCall.Text.Trim() != "" && txtTime3rdCall.Text.Trim() != "")
            {
                arrLog3rdCall.Clear();
                arrLog3rdCall.Add(objCom.strDate(txtDate3rdCall.Text.Trim()) + " " + txtTime3rdCall.Text.Trim() + " " + ddlTime3rdCall.SelectedItem.Text.Trim());
                arrLog3rdCall.Add(ddlRemarks3rdCall.SelectedItem.Text.Trim());
                arrLog3rdCall.Add(txtTelNo3rdCall.Text.Trim());
                arrLog3rdCall.Add(ddlTeleName.SelectedValue.Trim());
                arrTeleCallLog.Add(arrLog3rdCall);
            }
            if (txtDate4thCall.Text.Trim() != "" && txtTime4thCall.Text.Trim() != "")
            {
                arrLog4thCall.Clear();
                arrLog4thCall.Add(objCom.strDate(txtDate4thCall.Text.Trim()) + " " + txtTime4thCall.Text.Trim() + " " + ddlTime4thCall.SelectedItem.Text.Trim());
                arrLog4thCall.Add(ddlRemarks4thCall.SelectedItem.Text.Trim());
                arrLog4thCall.Add(txtTelNo4thCall.Text.Trim());
                arrLog4thCall.Add(ddlTeleName.SelectedValue.Trim());
                arrTeleCallLog.Add(arrLog4thCall);
            }
            if (txtDate5thCall.Text.Trim() != "" && txtTime5thCall.Text.Trim() != "")
            {
                arrLog5thCall.Clear();
                arrLog5thCall.Add(objCom.strDate(txtDate5thCall.Text.Trim()) + " " + txtTime5thCall.Text.Trim() + " " + ddlTime5thCall.SelectedItem.Text.Trim());
                arrLog5thCall.Add(ddlRemarks5thCall.SelectedItem.Text.Trim());
                arrLog5thCall.Add(txtTelNo5thCall.Text.Trim());
                arrLog5thCall.Add(ddlTeleName.SelectedValue.Trim());
                arrTeleCallLog.Add(arrLog5thCall);
            }


            string msg = objBVT.InsertTeleCallLog(arrTeleCallLog);
           

        }
        catch (Exception ex)
        {
            lblMessage.Visible = true;
            lblMessage.Text = "Error found during Inserting records in TeleCallLog:" + ex.Message;
        }        
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        sup_remarks sre = new sup_remarks();
        int iCount = 0;
        string msg = "";
        try
        {
            DataSet ds = new DataSet();
            DataSet ds1 = new DataSet();
            string sSQLChk = "";
            sSQLChk = "select desig_code from employee_master a,user_master b, designation_master c where" +
                " a.emp_id = b.userid and a.designation_id = c.designation_id and b.userid = '" + Session["UserID"].ToString() + "'";
            ds = OleDbHelper.ExecuteDataset(objcon.ConnectionString, CommandType.Text, sSQLChk);
            if (ds.Tables[0].Rows[0]["desig_code"].ToString() == "TC")
            {
                msg = InsertBusinessVerificationDetail();
                InsertTeleCallLog();
                if ((objBVT.Error != "") && (objBVT.Error != null))
                {
                    lblMessage.Text = objBVT.Error;
                }
                else
                {
                    iCount = 1;
                    lblMessage.Text = msg;
                }
            }
            else
            {
                if (txtSupervisorRemark.Text.Trim() == "")
                {
                    lblMessage.Text = "Please Enter Supervisor Remark.";
                }
                else
                {
                    msg = InsertBusinessVerificationDetail();
                    InsertTeleCallLog();
                    if ((objBVT.Error != "") && (objBVT.Error != null))
                    {
                        lblMessage.Text = objBVT.Error;
                    }
                    else
                    {
                        iCount = 1;
                        lblMessage.Text = msg;
                    }
                }
            }
           
        }
        catch (Exception ex)
        {

            lblMessage.Visible = true;            
            lblMessage.Text = "Error:" + ex.Message;
           
        }
        if (iCount == 1)
        {
            if (Context.Request.QueryString["FromDate"] != null && Context.Request.QueryString["FromDate"] != "" && Context.Request.QueryString["ToDate"] != null && Context.Request.QueryString["ToDate"] != "")
            {
                //string sCaseId;
                string Todate;
                string Fromdate;

                //sCaseId = Request.QueryString["CaseID"].ToString();
                Fromdate = Request.QueryString["FromDate"].ToString();
                Todate = Request.QueryString["ToDate"].ToString();
                // Txtcase.Text = sCaseId;
                txtfdate.Text = Fromdate;
                txttdate.Text = Todate;
                Response.Redirect("TcAssignedCasesQueue.aspx?FromDate=" + txtfdate.Text + "&ToDate=" + txttdate.Text + "");
            }
            else
            {
                Response.Redirect("CC_VerificationView.aspx?Msg=" + lblMessage.Text);
            }

           // Response.Redirect("CC_VerificationView.aspx?Msg=" + lblMessage.Text);
        }
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("CC_VerificationView.aspx");
    }
    /// <summary>
    /// This method is used for Pannel Visibility
    /// </summary>
    public void funShowPanel()
    {
        try
        {
            string strClientID = Session["ClientId"].ToString();
            string strActivityID = Session["ActivityId"].ToString();
            string strProductID = Session["ProductId"].ToString();
            string strVerificationType = "3";
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
                        objPlaceHolder = (PlaceHolder)(tblBusinessTelVeri.Rows[0].Cells[0].FindControl(strPlaceHolderName));
                        if (objPlaceHolder != null)
                        {

                            Panel objPanel = new Panel();
                            //objPanel.EnableViewState = false;
                            objPanel = (Panel)(tblBusinessTelVeri.Rows[1].Cells[0].FindControl(strPanelName));
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
        catch (Exception ex)
        {
            lblMessage.Visible = true;
            lblMessage.Text = "Error while setting panels:" + ex.Message;
        }   
    }
    private void IfIsEditFalse()
    {
        txtDate1stCall.Enabled = false;
        txtTime1stCall.Enabled = false;
        ddlTime1stCall.Enabled = false;
        ddlRemarks1stCall.Enabled = false;
        txtTelNo1stCall.Enabled = false;
        ddlTeleName.Enabled = false;
        txtDate2ndCall.Enabled = false;
        txtTime2ndCall.Enabled = false;
        ddlTime2ndCall.Enabled = false;
        ddlRemarks2ndCall.Enabled = false;
        txtTelNo2ndCall.Enabled = false;
        txtDate3rdCall.Enabled = false;
        txtTime3rdCall.Enabled = false;
        ddlTime3rdCall.Enabled = false;
        ddlRemarks3rdCall.Enabled = false;
        txtTelNo3rdCall.Enabled = false;
        txtDate4thCall.Enabled = false;
        txtTime4thCall.Enabled = false;
        ddlTime4thCall.Enabled = false;
        ddlRemarks4thCall.Enabled = false;
        txtTelNo4thCall.Enabled = false;
        txtDate5thCall.Enabled = false;
        txtTime5thCall.Enabled = false;
        ddlTime5thCall.Enabled = false;
        ddlRemarks5thCall.Enabled = false;
        txtTelNo5thCall.Enabled = false;



        //for CPV_CC_VERI_DESCRIPTION1

        txtPersonContacted.Enabled = false;

        ddlIncomeDocsSub.Enabled = false;

        txtTimeatCurrEmplApp.Enabled = false;

        txtExtNo.Enabled = false;

        txtAppDesignation.Enabled = false;



        txtDOB.Enabled = false;

        txtAppAvailable.Enabled = false;

        txtNewDetailObt.Enabled = false;

        txtSpecialInstructions.Enabled = false;

        ddlIsofficeAreaNegativeArea.Enabled = false;

        txtContactedNo.Enabled = false;

        txtExtnNumber.Enabled = false;

        ddlNameofApplicantConfirmedatgivenPhoneNo.Enabled = false;

        ddlChangeinPhoneNumber.Enabled = false;

        ddlReasonforchange.Enabled = false;

        txtYCR.Enabled = false;

        txtSegmentation.Enabled = false;

        ddlDirectoryCheck.Enabled = false;
        txtNoReason.Enabled = false;
        txtTimeatCurrEmplApp.Enabled = false;
                
        txtSpkToAppReceiptColleague.Enabled = false;

        ddlResidenceIs.Enabled = false;

        ddlMailingAddress.Enabled = false;

        ddlResiCumOffice.Enabled = false;

        ddlIsResidenceAddressNegativeArea.Enabled = false;

        txtDesigDeptContactedPerson.Enabled = false;

        ddlNatureofBusinessofCompany.Enabled = false;
        
        TextBox1.Enabled = false;  

        txtCalledupOffTelNo.Enabled = false;

        txtNoOfYearscurrEmployment.Enabled = false;

        txtTeleComments.Enabled = false;

        txtTimeCurrEmplYrs.Enabled = false;
        txtTimeCurrEmplMths.Enabled = false;

        txtNameOfCompany.Enabled = true; 

        txtLandmarkObserved.Enabled = false;

        txtCurrentResidencePeriod.Enabled = false;

        txtApplicantQualification.Enabled = false;
        
        //for CPV_CC_VERI_DESCRIPTION

        ddlContactability.Enabled = false;
        ddlProfile.Enabled = false;
        ddlReputation.Enabled = false;
        txtQualification.Enabled = false;
        txtInfoRequired.Enabled = false;
        ddlPriorityCustomer.Enabled = false;
        ddlAddrConfirmation.Enabled = false;
        txtAgeApproxApp.Enabled = false;

        txtTimeCurrResiYears.Enabled = false;
        txtTimeCurrResiMonth.Enabled = false;
        ddlRecommendation.Enabled = false;
        ddlConfirmationApplication.Enabled = false;
        ddlTeleName.Enabled = false;  

        ddlForSelfEmployedTypeOrganisation.Enabled = false;
        txtEmpPermanentTemp.Enabled = false;
        txtEmpConfirmedNotconfirmed.Enabled = false;

        txtApplicantDOBApproxAge.Enabled = false;
        txtResidencePhoneNo.Enabled = false;
        txtOtherContactedDesignation.Enabled = false;
        ddlBusinessNature.Enabled = false;
        TextBox1.Enabled = false;  
        txtAdditionalRemark.Enabled = false;

        txtEmployersName.Enabled = false;



        //for CPV_CC_VERI_OTHER_DETAILS

        txtPermanentAdd.Enabled = false;
        ddlContactedpersonRelationshipWithApplicant.Enabled = false;
        txtOtherContactedDesignation.Enabled = false;

        //for CPV_CC_CASE_DETAILS
        txtAddressOffice.Enabled = false;
        txtApplicantResidentialAddress.Enabled = false;
        txtDeptofApp.Enabled = false;
        txtResiPhoneNo.Enabled = false;
        txtDesignation.Enabled = false;

        //for CPV_CC_VERI_DETAILS
        txtNewInfoObt.Enabled = false;
        txtSupervisorRemark.Enabled = false;
        ddlTeleverificationResults.Enabled = false;
        txtAppName.Enabled = false;
        txtRefNo.Enabled = false;
        txtInitiationDate.Enabled = false;
        txtAgencyCode.Enabled = false;
        ddlNegmatch.Enabled = false;
        txtDetailsNegmatch.Enabled = false;
        ddlOverallAssessment.Enabled = false;
        txtReasonsforAssessment.Enabled = false;
        txtMismatchedInAddTelNo.Enabled = false;
        txtNegativeCode.Enabled = false;
        txtTeleCallerCode.Enabled = false;
        ///////ADDED BY SUNNY CHAUHAN : START//////////
        ddlActContNum.Enabled = false;
        txtActualNumber.Enabled = false;
        ///////ADDITION ENDED : SUNNY CHAUHAN//////////
        btnSubmit.Enabled = false;
        btnCancel.Enabled = false;
        /////////add by santosh shelar 25-08-08////////////////
        txtDeclineReasons.Enabled = false;
        ddlSupervisorName.Enabled = false;
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
    /// <summary>
    /// This Method is used to Match the verification Type and visible
    /// the link Button unlike the verification Type
    /// </summary>
    /// <param name="code"></param>
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
    protected void lbBV_Click(object sender, EventArgs e)
    {
        Response.Redirect("CC_BusinessVerification.aspx?CaseID=" + hidCaseID.Value + "&VerTypeId=2&VerificationTypeCode=" + hidVerificationTypeCode.Value + "&Mode=View");
        
    }
    protected void lbRT_Click(object sender, EventArgs e)
    {
        Response.Redirect("CC_ResidenceVerificationTelephonic.aspx?CaseID=" + hidCaseID.Value + "&VerTypeId=4&VerificationTypeCode=" + hidVerificationTypeCode.Value + "&Mode=View");
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

    }
    
}
