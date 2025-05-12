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
using System.Data.SqlClient;

public partial class CC_ResidenceVerification_GESBI : System.Web.UI.Page
{
    CCreditCardVerification objCCVer = new CCreditCardVerification();
    CCreditCardTelephonicVerification objRVT = new CCreditCardTelephonicVerification();
        
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                if (Context.Request.QueryString["CaseID"] != null && Context.Request.QueryString["CaseID"] != "" && Context.Request.QueryString["VerTypeId"] != null && Context.Request.QueryString["VerTypeId"] != "")
                {

                    txtCaseID.Text = Context.Request.QueryString["CaseID"];
                    hdnVeriTypeId.Value = Context.Request.QueryString["VerTypeId"];
                    FillSupervisorName();
                    Get_RV_Details_For_GESBI(txtCaseID.Text.Trim(), Convert.ToInt32(Session["ClientId"]));
                    hdnTransStart.Value = DateTime.Now.ToString();
                   }
                   // Register_Control_for_Javascript();
            }
            if (Context.Request.QueryString["Mode"] != null)
            {
                if (Context.Request.QueryString["Mode"] == "View")
                {
                    PnlView.Enabled = false;
                }
                else
                {
                    PnlView.Enabled = true;
                    Register_Control_for_Javascript();
                    string StrScript = "<script language='javascript'> javascript:Page_Load_Validation(); </script>";
                    Page.RegisterStartupScript("OnLoad_21", StrScript);

                }

            }

            //string StrScript = "<script language='javascript'> javascript:Page_Load_Validation(); </script>";
            //Page.RegisterStartupScript("OnLoad_21", StrScript);
             

            //Below is Working Properly
            //string StrScript = "<script language='javascript'>Enable_Validation_on_EntryPermitted();Enable_Validation_on_Proof();Enable_Validation_on_InfoRefused();Enable_Validation_on_AddressNotConfirmed(); Enable_Validation_On_TPC1_Name();Enable_Validation_On_AddressUpdation();Enabled_Validation_PersonMet();Enabled_Validation_CompanyDetails();Enable_Validation_on_AddConfirm(); </script>";
            //Page.RegisterStartupScript("OnLoad_21", StrScript);
        }
        catch (Exception Ex)
        {
            lblMessage.Text = Ex.Message;
        }

         
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            if (IsValidAttempt())
            {
            Insert_RV_Details_For_GESBI();
            Get_RV_Details_For_GESBI(txtCaseID.Text.Trim(), Convert.ToInt32(Session["ClientId"]));
              
            }
        }
        catch (Exception Ex)
        {
            lblMessage.Text = Ex.Message;
        }

    }
    private void Insert_RV_Details_For_GESBI()
    {
        try
        {
          

                SqlConnection sqlCon = new SqlConnection(ConfigurationManager.AppSettings["constring"]);
                sqlCon.Open();
                SqlCommand sqlCom = new SqlCommand();
                sqlCom.Connection = sqlCon;
                sqlCom.CommandType = CommandType.StoredProcedure;
                sqlCom.CommandText = "Insert_RVDetails_GESBI";
                sqlCom.CommandTimeout = 0;

                SqlParameter Case_Id = new SqlParameter();
                Case_Id.SqlDbType = SqlDbType.VarChar;
                Case_Id.ParameterName = "@Case_Id";
                Case_Id.Value = txtCaseID.Text.Trim();
                sqlCom.Parameters.Add(Case_Id);

                SqlParameter Resi_Add = new SqlParameter();
                Resi_Add.SqlDbType = SqlDbType.VarChar;
                Resi_Add.ParameterName = "@Resi_Add";
                Resi_Add.Value = txtCaseID.Text.Trim();
                sqlCom.Parameters.Add(Resi_Add);


                SqlParameter Verification_Type_Id = new SqlParameter();
                Verification_Type_Id.SqlDbType = SqlDbType.Int;
                Verification_Type_Id.ParameterName = "@Verification_Type_Id";
                Verification_Type_Id.Value = "1";
                sqlCom.Parameters.Add(Verification_Type_Id);

                SqlParameter Address_Confirm = new SqlParameter();
                Address_Confirm.SqlDbType = SqlDbType.VarChar;
                Address_Confirm.ParameterName = "@Address_Confirm";
                Address_Confirm.Value = ddlAddressConfirm.Text.Trim();
                sqlCom.Parameters.Add(Address_Confirm);

                SqlParameter Add_Conf_By = new SqlParameter();
                Add_Conf_By.SqlDbType = SqlDbType.VarChar;
                Add_Conf_By.ParameterName = "@Add_Conf_By";
                Add_Conf_By.Value = ddlAddConfBy.Text.Trim();
                sqlCom.Parameters.Add(Add_Conf_By);

                string strYCR = "";
                if (chk_YCR.Checked == true)
                {
                    strYCR = chk_YCR.Text.Trim();
                }
                else
                {

                    strYCR =  txtYearsLivedAtResi_YY.Text.Trim() + ":" + txtYearsLivedAtResi_MM.Text.Trim();
                    
                }
             
                    

                SqlParameter Years_Lives_at_Resi = new SqlParameter();
                Years_Lives_at_Resi.SqlDbType = SqlDbType.VarChar;
                Years_Lives_at_Resi.ParameterName = "@Years_Lives_at_Resi";
                Years_Lives_at_Resi.Value = strYCR;
                sqlCom.Parameters.Add(Years_Lives_at_Resi);

                SqlParameter Name_of_Person_Met = new SqlParameter();
                Name_of_Person_Met.SqlDbType = SqlDbType.VarChar;
                Name_of_Person_Met.ParameterName = "@Name_of_Person_Met";
                Name_of_Person_Met.Value = txtNameOfThePersonMet.Text.Trim();
                sqlCom.Parameters.Add(Name_of_Person_Met);

                SqlParameter Relation_with_App = new SqlParameter();
                Relation_with_App.SqlDbType = SqlDbType.VarChar;
                Relation_with_App.ParameterName = "@Relation_with_App";
                Relation_with_App.Value = ddlRelationShipWithApp.Text.Trim();
                sqlCom.Parameters.Add(Relation_with_App);

                SqlParameter Information_Refused = new SqlParameter();
                Information_Refused.SqlDbType = SqlDbType.VarChar;
                Information_Refused.ParameterName = "@Information_Refused";
                Information_Refused.Value = ddl_InfoRefused.Text.Trim();
                sqlCom.Parameters.Add(Information_Refused);

                SqlParameter ApplicantNameConfirmed = new SqlParameter();
                ApplicantNameConfirmed.SqlDbType = SqlDbType.VarChar;
                ApplicantNameConfirmed.ParameterName = "@ApplicantNameConfirm";
                ApplicantNameConfirmed.Value = ddlApplicantNameConfirmed.Text.Trim();
                sqlCom.Parameters.Add(ApplicantNameConfirmed);
    

                
                string strApplicantAge = "";
                if (chkApplicant_DOBAGE_NotConf.Checked == true)
                {
                    strApplicantAge = chkApplicant_DOBAGE_NotConf.Text.Trim();
                }
                else
                {
                    if (txtApplicantAge_DOB.Text != "")
                    {
                        strApplicantAge = txtApplicantAge_DOB.Text.Trim();
                    }
                    else
                    {
                        strApplicantAge = txtApplicantAge_DOB_YY.Text.Trim() + ":" + txtApplicantAge_DOB_MM.Text.Trim();
                    }
                }
             

                SqlParameter Approx_Age = new SqlParameter();
                Approx_Age.SqlDbType = SqlDbType.VarChar;
                Approx_Age.ParameterName = "@Approx_Age";
                Approx_Age.Value = strApplicantAge;
                sqlCom.Parameters.Add(Approx_Age);

                SqlParameter App_Stay_Confirm = new SqlParameter();
                App_Stay_Confirm.SqlDbType = SqlDbType.VarChar;
                App_Stay_Confirm.ParameterName = "@App_Stay_Confirm";
                App_Stay_Confirm.Value = ddlApplicantStayConfirm.Text.Trim();
                sqlCom.Parameters.Add(App_Stay_Confirm);

                SqlParameter Resi_Status = new SqlParameter();
                Resi_Status.SqlDbType = SqlDbType.VarChar;
                Resi_Status.ParameterName = "@Resi_Status";
                Resi_Status.Value = ddlResiStatus.Text.Trim();
                sqlCom.Parameters.Add(Resi_Status);

                SqlParameter No_Of_Family_Mem = new SqlParameter();
                No_Of_Family_Mem.SqlDbType = SqlDbType.VarChar;
                No_Of_Family_Mem.ParameterName = "@No_Of_Family_Mem";
                No_Of_Family_Mem.Value = ddlNoOfFamilyMembers.Text.Trim();
                sqlCom.Parameters.Add(No_Of_Family_Mem);

                SqlParameter Earn_Family_Mem = new SqlParameter();
                Earn_Family_Mem.SqlDbType = SqlDbType.VarChar;
                Earn_Family_Mem.ParameterName = "@Earn_Family_Mem";
                Earn_Family_Mem.Value = ddlEaringFamilyMembers.Text.Trim();
                sqlCom.Parameters.Add(Earn_Family_Mem);

                SqlParameter YCR_App = new SqlParameter();
                YCR_App.SqlDbType = SqlDbType.VarChar;
                YCR_App.ParameterName = "@YCR_App";
                YCR_App.Value = "";
                sqlCom.Parameters.Add(YCR_App);

                SqlParameter Approx_Value_Own = new SqlParameter();
                Approx_Value_Own.SqlDbType = SqlDbType.VarChar;
                Approx_Value_Own.ParameterName = "@Approx_Value_Own";
                Approx_Value_Own.Value = "";//txtApproxValueOwn.Text.Trim();
                sqlCom.Parameters.Add(Approx_Value_Own);

                SqlParameter Approx_Value_Rent = new SqlParameter();
                Approx_Value_Rent.SqlDbType = SqlDbType.VarChar;
                Approx_Value_Rent.ParameterName = "@Approx_Value_Rent";
                Approx_Value_Rent.Value = "";//txtApproxValueRent.Text.Trim();
                sqlCom.Parameters.Add(Approx_Value_Rent);


                //string strVehicle = "";
                //for (int i = 0; i <= ChkVehicleType.Items.Count - 1; i++)
                //{
                //    if (ChkVehicleType.Items[i].Selected == true)
                //    {
                //        strVehicle = strVehicle + ChkVehicleType.Items[i].Text + ",";
                //    }

                //}

                SqlParameter Vehicle = new SqlParameter();
                Vehicle.SqlDbType = SqlDbType.VarChar;
                Vehicle.ParameterName = "@Vehicle";
                Vehicle.Value = ""; //strVehicle;
                sqlCom.Parameters.Add(Vehicle);

                SqlParameter Make_Type = new SqlParameter();
                Make_Type.SqlDbType = SqlDbType.VarChar;
                Make_Type.ParameterName = "@Make_Type";
                Make_Type.Value = "";// txtMakeAndType.Text.Trim();
                sqlCom.Parameters.Add(Make_Type);

                SqlParameter Company_Name = new SqlParameter();
                Company_Name.SqlDbType = SqlDbType.VarChar;
                Company_Name.ParameterName = "@Company_Name";
                Company_Name.Value = txtCompanyName.Text.Trim();
                sqlCom.Parameters.Add(Company_Name);

                SqlParameter Office_Add = new SqlParameter();
                Office_Add.SqlDbType = SqlDbType.VarChar;
                Office_Add.ParameterName = "@Office_Add";
                Office_Add.Value = txtOfficeAdd.Text.Trim();
                sqlCom.Parameters.Add(Office_Add);

                SqlParameter Design_at_Office = new SqlParameter();
                Design_at_Office.SqlDbType = SqlDbType.VarChar;
                Design_at_Office.ParameterName = "@Design_at_Office";
                Design_at_Office.Value = txtDesignation.Text.Trim();
                sqlCom.Parameters.Add(Design_at_Office);


                string strYCE = "";
                if (chk_YCE.Checked == true)
                {
                    strYCE = chk_YCE.Text.Trim();
                }
                else
                {

                    strYCE = txtYrsInEMP_YY.Text.Trim() + ":" + txtYrsInEMP_MM.Text.Trim();

                }    
                    

                SqlParameter Yrs_in_Current_Employement = new SqlParameter();
                Yrs_in_Current_Employement.SqlDbType = SqlDbType.VarChar;
                Yrs_in_Current_Employement.ParameterName = "@Yrs_in_Current_Employement";
                Yrs_in_Current_Employement.Value = strYCE;
                sqlCom.Parameters.Add(Yrs_in_Current_Employement);


                SqlParameter Department = new SqlParameter();
                Department.SqlDbType = SqlDbType.VarChar;
                Department.ParameterName = "@Department";
                Department.Value = txtDepartMent.Text.Trim();
                sqlCom.Parameters.Add(Department);

                SqlParameter Off_Phone = new SqlParameter();
                Off_Phone.SqlDbType = SqlDbType.VarChar;
                Off_Phone.ParameterName = "@Off_Phone";
                Off_Phone.Value = txtOfficePhone.Text.Trim();
                sqlCom.Parameters.Add(Off_Phone);

                SqlParameter Resi_Phone = new SqlParameter();
                Resi_Phone.SqlDbType = SqlDbType.VarChar;
                Resi_Phone.ParameterName = "@Resi_Phone";
                Resi_Phone.Value = txtResiPhone.Text.Trim();
                sqlCom.Parameters.Add(Resi_Phone);


                SqlParameter Permanent_Add = new SqlParameter();
                Permanent_Add.SqlDbType = SqlDbType.VarChar;
                Permanent_Add.ParameterName = "@Permanent_Add";
                Permanent_Add.Value = txtPermenantAddress.Text.Trim();
                sqlCom.Parameters.Add(Permanent_Add);

                SqlParameter Permanent_Phone = new SqlParameter();
                Permanent_Phone.SqlDbType = SqlDbType.VarChar;
                Permanent_Phone.ParameterName = "@Permanent_Phone";
                Permanent_Phone.Value = txtPermenantNo.Text.Trim();
                sqlCom.Parameters.Add(Permanent_Phone);

                SqlParameter Proof_Attached = new SqlParameter();
                Proof_Attached.SqlDbType = SqlDbType.VarChar;
                Proof_Attached.ParameterName = "@Proof_Attached";
                Proof_Attached.Value = ddlTypeOfProof.Text.Trim();
                sqlCom.Parameters.Add(Proof_Attached);

                SqlParameter Proof_Id_Type = new SqlParameter();
                Proof_Id_Type.SqlDbType = SqlDbType.VarChar;
                Proof_Id_Type.ParameterName = "@Proof_Id_Type";
                Proof_Id_Type.Value = ddlTypeOfIDProof.Text.Trim();
                sqlCom.Parameters.Add(Proof_Id_Type);

                SqlParameter LandMark = new SqlParameter();
                LandMark.SqlDbType = SqlDbType.VarChar;
                LandMark.ParameterName = "@LandMark";
                LandMark.Value = txtLandmark.Text.Trim();
                sqlCom.Parameters.Add(LandMark);

                SqlParameter TPC1_Name = new SqlParameter();
                TPC1_Name.SqlDbType = SqlDbType.VarChar;
                TPC1_Name.ParameterName = "@TPC1_Name";
                TPC1_Name.Value = txtTPC1_Name.Text.Trim();
                sqlCom.Parameters.Add(TPC1_Name);

                SqlParameter TPC1_By_Whom = new SqlParameter();
                TPC1_By_Whom.SqlDbType = SqlDbType.VarChar;
                TPC1_By_Whom.ParameterName = "@TPC1_By_Whom";
                TPC1_By_Whom.Value = ddlTPC1_ByWHOM.Text.Trim();
                sqlCom.Parameters.Add(TPC1_By_Whom);

                SqlParameter TPC1_Address = new SqlParameter();
                TPC1_Address.SqlDbType = SqlDbType.VarChar;
                TPC1_Address.ParameterName = "@TPC1_Address";
                TPC1_Address.Value = txtTPC1_Address.Text.Trim();
                sqlCom.Parameters.Add(TPC1_Address);


                SqlParameter TPC1_App_Available_at_Home = new SqlParameter();
                TPC1_App_Available_at_Home.SqlDbType = SqlDbType.VarChar;
                TPC1_App_Available_at_Home.ParameterName = "@TPC1_App_Available_at_Home";
                TPC1_App_Available_at_Home.Value = txtTPC1_AppHomeConfirm.Text.Trim();
                sqlCom.Parameters.Add(TPC1_App_Available_at_Home);

                SqlParameter TPC1_App_Name_Confirm = new SqlParameter();
                TPC1_App_Name_Confirm.SqlDbType = SqlDbType.VarChar;
                TPC1_App_Name_Confirm.ParameterName = "@TPC1_App_Name_Confirm";
                TPC1_App_Name_Confirm.Value = ddlTPC1_AppNameConfirmed.Text.Trim();
                sqlCom.Parameters.Add(TPC1_App_Name_Confirm);

                SqlParameter TPC1_App_Stay_Confirm = new SqlParameter();
                TPC1_App_Stay_Confirm.SqlDbType = SqlDbType.VarChar;
                TPC1_App_Stay_Confirm.ParameterName = "@TPC1_App_Stay_Confirm";
                TPC1_App_Stay_Confirm.Value = ddlTPC1_AppStayConfirmed.Text.Trim();
                sqlCom.Parameters.Add(TPC1_App_Stay_Confirm);


                string strTPC1_App_YCR = "";
                if (chkTPC1_AppYCR.Checked == true)
                {
                    strTPC1_App_YCR = chkTPC1_AppYCR.Text;
                }
                else
                {
                    strTPC1_App_YCR = txtTPC1_AppYCR_YY.Text.Trim() + ":" + txtTPC1_AppYCR_MM.Text.Trim();
                }

                

                SqlParameter TPC1_App_YCR = new SqlParameter();
                TPC1_App_YCR.SqlDbType = SqlDbType.VarChar;
                TPC1_App_YCR.ParameterName = "@TPC1_App_YCR";
                TPC1_App_YCR.Value = strTPC1_App_YCR;
                sqlCom.Parameters.Add(TPC1_App_YCR);


                SqlParameter TPC1_App_Own_Status = new SqlParameter();
                TPC1_App_Own_Status.SqlDbType = SqlDbType.VarChar;
                TPC1_App_Own_Status.ParameterName = "@TPC1_App_Own_Status";
                TPC1_App_Own_Status.Value = ddlTCP1_AppOwnershipStatus.Text.Trim();
                sqlCom.Parameters.Add(TPC1_App_Own_Status);

                SqlParameter Entry_Permitted = new SqlParameter();
                Entry_Permitted.SqlDbType = SqlDbType.VarChar;
                Entry_Permitted.ParameterName = "@Entry_Permitted";
                Entry_Permitted.Value = ddlEntryPermitted.Text.Trim();
                sqlCom.Parameters.Add(Entry_Permitted);

                SqlParameter Standard_of_Living = new SqlParameter();
                Standard_of_Living.SqlDbType = SqlDbType.VarChar;
                Standard_of_Living.ParameterName = "@Standard_of_Living";
                Standard_of_Living.Value = ddlStandardOfLiving.Text.Trim();
                sqlCom.Parameters.Add(Standard_of_Living);


                string strInterior = "";
                for (int i = 0; i <= chkInterior.Items.Count - 1; i++)
                {
                    if (chkInterior.Items[i].Selected == true)
                    {
                        strInterior = strInterior + chkInterior.Items[i].Text + ",";
                    }

                }

                SqlParameter Interior_Condition = new SqlParameter();
                Interior_Condition.SqlDbType = SqlDbType.VarChar;
                Interior_Condition.ParameterName = "@Interior_Condition";
                Interior_Condition.Value = strInterior;
                sqlCom.Parameters.Add(Interior_Condition);



                string strAssetSeen = "";
                for (int i = 0; i <= chkAssetsVisible.Items.Count - 1; i++)
                {
                    if (chkAssetsVisible.Items[i].Selected == true)
                    {
                        strAssetSeen = strAssetSeen + chkAssetsVisible.Items[i].Text + ",";
                    }

                }

                SqlParameter Asset_Seen = new SqlParameter();
                Asset_Seen.SqlDbType = SqlDbType.VarChar;
                Asset_Seen.ParameterName = "@Asset_Seen";
                Asset_Seen.Value = strAssetSeen;
                sqlCom.Parameters.Add(Asset_Seen);

                SqlParameter Exterior_Condition = new SqlParameter();
                Exterior_Condition.SqlDbType = SqlDbType.VarChar;
                Exterior_Condition.ParameterName = "@Exterior_Condition";
                Exterior_Condition.Value = ddlExteriorCondition.Text.Trim();
                sqlCom.Parameters.Add(Exterior_Condition);

                SqlParameter Locality = new SqlParameter();
                Locality.SqlDbType = SqlDbType.VarChar;
                Locality.ParameterName = "@Locality";
                Locality.Value = ddlLocality.Text.Trim();
                sqlCom.Parameters.Add(Locality);

                SqlParameter Area_Type = new SqlParameter();
                Area_Type.SqlDbType = SqlDbType.VarChar;
                Area_Type.ParameterName = "@Area_Type";
                Area_Type.Value = ddlAreaType.Text.Trim();
                sqlCom.Parameters.Add(Area_Type);

                SqlParameter Type_of_Accommodation = new SqlParameter();
                Type_of_Accommodation.SqlDbType = SqlDbType.VarChar;
                Type_of_Accommodation.ParameterName = "@Type_of_Accommodation";
                Type_of_Accommodation.Value = ddlTypeAcco.Text.Trim();
                sqlCom.Parameters.Add(Type_of_Accommodation);

                SqlParameter Ease_of_locating_house = new SqlParameter();
                Ease_of_locating_house.SqlDbType = SqlDbType.VarChar;
                Ease_of_locating_house.ParameterName = "@Ease_of_locating_house";
                Ease_of_locating_house.Value = ddlEaseOfLocatingHouse.Text.Trim();
                sqlCom.Parameters.Add(Ease_of_locating_house);

                SqlParameter Area_of_the_house = new SqlParameter();
                Area_of_the_house.SqlDbType = SqlDbType.VarChar;
                Area_of_the_house.ParameterName = "@Area_of_the_house";
                Area_of_the_house.Value = ddlAreaOfHouse.Text.Trim();
                sqlCom.Parameters.Add(Area_of_the_house);

                SqlParameter Directory_Checked = new SqlParameter();
                Directory_Checked.SqlDbType = SqlDbType.VarChar;
                Directory_Checked.ParameterName = "@Directory_Checked";
                Directory_Checked.Value = ddlDirectory_Check.Text.Trim();
                sqlCom.Parameters.Add(Directory_Checked);

                SqlParameter Attempt_Details = new SqlParameter();
                Attempt_Details.SqlDbType = SqlDbType.VarChar;
                Attempt_Details.ParameterName = "@Attempt_Details";
                Attempt_Details.Value = Get_Attempt_details();
                sqlCom.Parameters.Add(Attempt_Details);

                SqlParameter Vefier_Name = new SqlParameter();
                Vefier_Name.SqlDbType = SqlDbType.VarChar;
                Vefier_Name.ParameterName = "@Vefier_Name";
                Vefier_Name.Value = txtVerifierName.Text.Trim();
                sqlCom.Parameters.Add(Vefier_Name);

                SqlParameter Veri_Conducted_At = new SqlParameter();
                Veri_Conducted_At.SqlDbType = SqlDbType.VarChar;
                Veri_Conducted_At.ParameterName = "@Veri_Conducted_At";
                Veri_Conducted_At.Value = ddlVeri_Conduct_At.Text.Trim();
                sqlCom.Parameters.Add(Veri_Conducted_At);

                SqlParameter Verifier_Remarks = new SqlParameter();
                Verifier_Remarks.SqlDbType = SqlDbType.VarChar;
                Verifier_Remarks.ParameterName = "@Verifier_Remarks";
                Verifier_Remarks.Value = txtVerifierRemark.Text.Trim();
                sqlCom.Parameters.Add(Verifier_Remarks);

                SqlParameter SupervisorName_EmpID = new SqlParameter();
                SupervisorName_EmpID.SqlDbType = SqlDbType.VarChar;
                SupervisorName_EmpID.ParameterName = "@SupervisorName_EmpID";
                SupervisorName_EmpID.Value = ddlSupervisorName.SelectedItem.Value.Trim();
                sqlCom.Parameters.Add(SupervisorName_EmpID);


                SqlParameter SuperVisor_Remark = new SqlParameter();
                SuperVisor_Remark.SqlDbType = SqlDbType.VarChar;
                SuperVisor_Remark.ParameterName = "@SuperVisor_Remark";
                SuperVisor_Remark.Value = txtSuperVisorRemark.Text.Trim();
                sqlCom.Parameters.Add(SuperVisor_Remark);

                SqlParameter RECOMMENDATION = new SqlParameter();
                RECOMMENDATION.SqlDbType = SqlDbType.VarChar;
                RECOMMENDATION.ParameterName = "@RECOMMENDATION";
                RECOMMENDATION.Value = ddlProprietor_recomm.Text.Trim();
                sqlCom.Parameters.Add(RECOMMENDATION);

                SqlParameter Decline_Code = new SqlParameter();
                Decline_Code.SqlDbType = SqlDbType.VarChar;
                Decline_Code.ParameterName = "@Decline_Code";
                Decline_Code.Value = txtDeclineCode.Text.Trim();
                sqlCom.Parameters.Add(Decline_Code);

                SqlParameter Auth_Signature = new SqlParameter();
                Auth_Signature.SqlDbType = SqlDbType.VarChar;
                Auth_Signature.ParameterName = "@Auth_Signature";
                Auth_Signature.Value = txtAuthSign.Text.Trim();
                sqlCom.Parameters.Add(Auth_Signature);

                SqlParameter Address_Updation = new SqlParameter();
                Address_Updation.SqlDbType = SqlDbType.VarChar;
                Address_Updation.ParameterName = "@Address_Updation";
                Address_Updation.Value = ddlAddressUpdation.Text.Trim();
                sqlCom.Parameters.Add(Address_Updation);

                SqlParameter Correct_Address = new SqlParameter();
                Correct_Address.SqlDbType = SqlDbType.VarChar;
                Correct_Address.ParameterName = "@Correct_Address";
                Correct_Address.Value = txtAddressUpdation.Text.Trim();
                sqlCom.Parameters.Add(Correct_Address);

                SqlParameter ReasonForAddNotConfirmed = new SqlParameter();
                ReasonForAddNotConfirmed.SqlDbType = SqlDbType.VarChar;
                ReasonForAddNotConfirmed.ParameterName = "@ReasonForAddNotConfirmed";
                ReasonForAddNotConfirmed.Value =ddlReasonForAddNotConfirmed.Text.Trim();
                sqlCom.Parameters.Add(ReasonForAddNotConfirmed);

                SqlParameter WhomtheAddBelongsTo = new SqlParameter();
                WhomtheAddBelongsTo.SqlDbType = SqlDbType.VarChar;
                WhomtheAddBelongsTo.ParameterName = "@WhomtheAddBelongsTo";
                WhomtheAddBelongsTo.Value =txtWhomtheAddBelongsTo.Text.Trim();
                sqlCom.Parameters.Add(WhomtheAddBelongsTo);

                SqlParameter ResultOfCalling = new SqlParameter();
                ResultOfCalling.SqlDbType = SqlDbType.VarChar;
                ResultOfCalling.ParameterName = "@ResultOfCalling";
                ResultOfCalling.Value = txtResultOfCalling.Text.Trim();
                sqlCom.Parameters.Add(ResultOfCalling);

                SqlParameter Is_Person_met = new SqlParameter();
                Is_Person_met.SqlDbType = SqlDbType.VarChar;
                Is_Person_met.ParameterName = "@Is_Person_met";
                Is_Person_met.Value = ddlNameOfPersonMet.Text.Trim();
                sqlCom.Parameters.Add(Is_Person_met);

                SqlParameter Company_Details = new SqlParameter();
                Company_Details.SqlDbType = SqlDbType.VarChar;
                Company_Details.ParameterName = "@Company_Details";
                Company_Details.Value = ddlCompanyDetails.Text.Trim();
                sqlCom.Parameters.Add(Company_Details);

                SqlParameter TPC1_Name_Confirm = new SqlParameter();
                TPC1_Name_Confirm.SqlDbType = SqlDbType.VarChar;
                TPC1_Name_Confirm.ParameterName = "@TPC1_Name_Confirm";
                TPC1_Name_Confirm.Value = ddlTPC1_Name.Text.Trim();
                sqlCom.Parameters.Add(TPC1_Name_Confirm);



                SqlParameter TPC2_Name = new SqlParameter();
                TPC2_Name.SqlDbType = SqlDbType.VarChar;
                TPC2_Name.ParameterName = "@TPC2_Name";
                TPC2_Name.Value = ddlTPC2_Name.Text.Trim();
                sqlCom.Parameters.Add(TPC2_Name);


                SqlParameter TPC2_Name_Confirm = new SqlParameter();
                TPC2_Name_Confirm.SqlDbType = SqlDbType.VarChar;
                TPC2_Name_Confirm.ParameterName = "@TPC2_Name_Confirm";
                TPC2_Name_Confirm.Value = txtTPC2_Name.Text.Trim();
                sqlCom.Parameters.Add(TPC2_Name_Confirm);

                SqlParameter TPC2_By_Whom = new SqlParameter();
                TPC2_By_Whom.SqlDbType = SqlDbType.VarChar;
                TPC2_By_Whom.ParameterName = "@TPC2_By_Whom";
                TPC2_By_Whom.Value = ddlTPC2_ByWhom.Text.Trim();
                sqlCom.Parameters.Add(TPC2_By_Whom);

                SqlParameter TPC2_Address = new SqlParameter();
                TPC2_Address.SqlDbType = SqlDbType.VarChar;
                TPC2_Address.ParameterName = "@TPC2_Address";
                TPC2_Address.Value = txtTPC2_Address.Text.Trim();
                sqlCom.Parameters.Add(TPC2_Address);

                SqlParameter TPC2_App_Available_at_Home = new SqlParameter();
                TPC2_App_Available_at_Home.SqlDbType = SqlDbType.VarChar;
                TPC2_App_Available_at_Home.ParameterName = "@TPC2_App_Available_at_Home";
                TPC2_App_Available_at_Home.Value = txtTPC2_AppHomeConfirm.Text.Trim();
                sqlCom.Parameters.Add(TPC2_App_Available_at_Home);

                SqlParameter TPC2_App_Name_Confirm = new SqlParameter();
                TPC2_App_Name_Confirm.SqlDbType = SqlDbType.VarChar;
                TPC2_App_Name_Confirm.ParameterName = "@TPC2_App_Name_Confirm";
                TPC2_App_Name_Confirm.Value = ddlTPC2_AppNameConfirmed.Text.Trim();
                sqlCom.Parameters.Add(TPC2_App_Name_Confirm);

                SqlParameter TPC2_App_Stay_Confirm = new SqlParameter();
                TPC2_App_Stay_Confirm.SqlDbType = SqlDbType.VarChar;
                TPC2_App_Stay_Confirm.ParameterName = "@TPC2_App_Stay_Confirm";
                TPC2_App_Stay_Confirm.Value = ddlTPC2_AppStayConfirmed.Text.Trim();
                sqlCom.Parameters.Add(TPC2_App_Stay_Confirm);


                string strTPC2_App_YCR = "";
                if (chkTPC2_AppYCR.Checked == true)
                {
                    strTPC2_App_YCR = chkTPC2_AppYCR.Text;
                }
                else
                {
                    strTPC2_App_YCR = txtTPC2_AppYCR_YY.Text.Trim() + ":" + txtTPC2_AppYCR_MM.Text.Trim();
                } 
            
                SqlParameter TPC2_App_YCR = new SqlParameter();
                TPC2_App_YCR.SqlDbType = SqlDbType.VarChar;
                TPC2_App_YCR.ParameterName = "@TPC2_App_YCR";
                TPC2_App_YCR.Value = strTPC2_App_YCR;
                sqlCom.Parameters.Add(TPC2_App_YCR);


                SqlParameter TPC2_App_Own_Status = new SqlParameter();
                TPC2_App_Own_Status.SqlDbType = SqlDbType.VarChar;
                TPC2_App_Own_Status.ParameterName = "@TPC2_App_Own_Status";
                TPC2_App_Own_Status.Value = ddlTCP2_AppOwnershipStatus.Text.Trim() ;
                sqlCom.Parameters.Add(TPC2_App_Own_Status);

                SqlParameter Observation = new SqlParameter();
                Observation.SqlDbType = SqlDbType.VarChar;
                Observation.ParameterName = "@Observation";
                Observation.Value = txtObservation.Text.Trim();
                sqlCom.Parameters.Add(Observation);

                SqlParameter OtherRelationship = new SqlParameter();
                OtherRelationship.SqlDbType = SqlDbType.VarChar;
                OtherRelationship.ParameterName = "@OtherRelationship";
                OtherRelationship.Value = txtRelationship_Other.Text.Trim();
                sqlCom.Parameters.Add(OtherRelationship); 


                int intRow = sqlCom.ExecuteNonQuery();
                sqlCon.Close();
                if (intRow>0)
                {
                lblMessage.CssClass = "UpdateMessage";
                lblMessage.Text = "Record Successfully Updated!!!!";           
                    }
            
        }
        catch (Exception Ex)
        {
            lblMessage.Text = Ex.Message; 
        }

    } 
    private void Get_RV_Details_For_GESBI(string pCaseId,int pClientId)
    {
        try
        {

            SqlConnection sqlCon = new SqlConnection(ConfigurationManager.AppSettings["constring"]);

            sqlCon.Open();
            SqlCommand sqlCom = new SqlCommand();
            sqlCom.Connection = sqlCon;
            sqlCom.CommandType = CommandType.StoredProcedure;
            sqlCom.CommandText = "Get_RV_Details_For_GESBI";
            sqlCom.CommandTimeout = 0;

            SqlParameter Case_Id = new SqlParameter();
            Case_Id.SqlDbType = SqlDbType.VarChar;
            Case_Id.ParameterName = "@Case_Id";
            Case_Id.Value = pCaseId;
            sqlCom.Parameters.Add(Case_Id);

            SqlParameter ClientId = new SqlParameter();
            ClientId.SqlDbType = SqlDbType.Int;
            ClientId.ParameterName = "@ClientId";
            ClientId.Value = pClientId ;
            sqlCom.Parameters.Add(ClientId);

            SqlDataAdapter sqlDA = new SqlDataAdapter();
            sqlDA.SelectCommand = sqlCom;
            DataSet ds = new DataSet();
            sqlDA.Fill(ds);
            sqlCon.Close();
            if (ds.Tables[0].Rows.Count > 0)
            {
                Assign_RV_Details(ds.Tables[0]);
            }
            else 
            {
                lblMessage.CssClass = "ErrorMessage";
                lblMessage.Text = "No Details found!!!!";            
            }
        }
        catch (Exception Ex)
        {
            lblMessage.Text = Ex.Message;
        }
    
    }
    private void Assign_RV_Details(DataTable dt)
    {
        try 
        {
            txtRelationship_Other.Text = dt.Rows[0]["OtherRelationship"].ToString().Trim();

            txtApplicationNo.Text = dt.Rows[0]["Ref_No"].ToString().Trim() ;
            txtApplicantNAme.Text = dt.Rows[0]["CustomerName"].ToString().Trim();
            txtResiAdd.Text = dt.Rows[0]["Resi_Add"].ToString(); 
            ddlAddressConfirm.SelectedValue = dt.Rows[0]["ADRESS_CONFIRMATION"].ToString().Trim();
            ddlAddConfBy.SelectedValue = dt.Rows[0]["ADDRESS_CONFIRMED_BY"].ToString().Trim();
            txtNameOfThePersonMet.Text = dt.Rows[0]["PERSON_CONTACTED_MET"].ToString().Trim();
            ddlRelationShipWithApp.SelectedValue = dt.Rows[0]["RELATION_PERSON_CONTACTED"].ToString().Trim();
            ddl_InfoRefused.SelectedValue = dt.Rows[0]["INFO_REFUSED"].ToString().Trim();
            //Added by Avinash Wankhede 10 July 2009
            ddlApplicantNameConfirmed.SelectedValue = dt.Rows[0]["Applicant_Name_Confim"].ToString().Trim();
            ddlNameOfPersonMet.SelectedValue = dt.Rows[0]["Is_Person_met"].ToString().Trim();
            ddlCompanyDetails.SelectedValue = dt.Rows[0]["Company_Details"].ToString().Trim();
            ddlTPC1_Name.SelectedValue = dt.Rows[0]["TPC1_Name_Confirm"].ToString().Trim();          
            
            string strAPPLICANT_AGE = dt.Rows[0]["APPLICANT_AGE"].ToString().Trim();
            if (strAPPLICANT_AGE == "Not Confirmed")
            {
                chkApplicant_DOBAGE_NotConf.Checked = true;
            }
            else
            {
                string[] arrstrAPPLICANT_AGE = strAPPLICANT_AGE.Split(':');
                if (strAPPLICANT_AGE.Length > 5)
                {
                    if (arrstrAPPLICANT_AGE.Length == 1)
                    {
                        txtApplicantAge_DOB.Text = arrstrAPPLICANT_AGE[0];

                    }
                }
                else
                {
                    txtApplicantAge_DOB_YY.Text = arrstrAPPLICANT_AGE[0];
                    if (arrstrAPPLICANT_AGE.Length > 1)
                    {
                        txtApplicantAge_DOB_MM.Text = arrstrAPPLICANT_AGE[1];
                    }

                }
            }
            //  End 10 July 2009  
            ddlApplicantStayConfirm.SelectedValue = dt.Rows[0]["IS_ADD_NOT_CONFIRMED"].ToString().Trim();
            ddlResiStatus.SelectedValue = dt.Rows[0]["RESIDANCE_STATUS"].ToString().Trim();
            ddlNoOfFamilyMembers.SelectedValue = dt.Rows[0]["FAMILY_MEMBERS"].ToString().Trim();
            ddlEaringFamilyMembers.SelectedValue = dt.Rows[0]["NO_OF_EARNING_FAMILY_MEMBER"].ToString().Trim();

            string strYCR = dt.Rows[0]["YCR"].ToString().Trim();
            string[] arrYCR_YYMM =strYCR.Split(':');

            if (strYCR == chk_YCR.Text.Trim())
            {
                chk_YCR.Checked = true;                
            } 
            else
                {
                    if (arrYCR_YYMM.Length > 0)
                    {
                        txtYearsLivedAtResi_YY.Text = arrYCR_YYMM[0].Trim();
                    }

                    if (arrYCR_YYMM.Length > 1)
                    {
                        txtYearsLivedAtResi_MM.Text = arrYCR_YYMM[1].Trim();
                    }
             }
           
           
           txtCompanyName.Text = dt.Rows[0]["Company_Name"].ToString().Trim();
           txtOfficeAdd.Text = dt.Rows[0]["OFFICE_ADDRESS"].ToString().Trim();
           txtDesignation.Text = dt.Rows[0]["DESIGNATION"].ToString().Trim();


           string strYCE = dt.Rows[0]["NO_OF_YEARS_AT_CURRENT_EMPLOYMENT"].ToString().Trim();
           string[] arrYCE_YYMM = strYCE.Split(':');

           if (strYCE == chk_YCE.Text.Trim())
           {
               chk_YCE.Checked = true;
           }
           else
           {
               if (arrYCE_YYMM.Length > 0)
               {
                   txtYrsInEMP_YY.Text = arrYCE_YYMM[0].Trim();
               }

               if (arrYCR_YYMM.Length > 1)
               {
                   txtYrsInEMP_MM.Text = arrYCE_YYMM[1].Trim();
               }
           }

           //txtYrsInEMP_YY.Text = dt.Rows[0]["NO_OF_YEARS_AT_CURRENT_EMPLOYMENT"].ToString().Trim();



           txtDepartMent.Text = dt.Rows[0]["DEPARTMENT"].ToString().Trim();
           txtOfficePhone.Text = dt.Rows[0]["OFFICE_TELEPHONE"].ToString().Trim();
           txtPermenantAddress.Text = dt.Rows[0]["PERMANENT_ADDRESS"].ToString().Trim();
           txtPermenantNo.Text = dt.Rows[0]["NO_OF_RES_AT_HOME2"].ToString().Trim();
           txtResiPhone.Text = dt.Rows[0]["RSIDENCE_PHONE_NO"].ToString().Trim();
           ddlTypeOfProof.SelectedValue = dt.Rows[0]["PROOF_OF_VISIT_COLLECTED"].ToString().Trim();
           ddlTypeOfIDProof.SelectedValue = dt.Rows[0]["Door_colour"].ToString().Trim();
           txtLandmark.Text = dt.Rows[0]["land_mark_observed"].ToString().Trim();
           txtTPC1_Name.Text = dt.Rows[0]["TPC_NAME"].ToString().Trim();
           ddlTPC1_ByWHOM.SelectedValue = dt.Rows[0]["TPC_BY"].ToString().Trim();           
           txtTPC1_Address.Text = dt.Rows[0]["TPC_DETAILS"].ToString().Trim();
           txtTPC1_AppHomeConfirm.Text = dt.Rows[0]["APPLICANT_IS_AVAILABLE_AT"].ToString().Trim();
           ddlTPC1_AppNameConfirmed.SelectedValue = dt.Rows[0]["APPLICANT_NAME_CONFIRMED_AT_GIVEN_NO"].ToString().Trim();
           ddlTPC1_AppStayConfirmed.SelectedValue = dt.Rows[0]["APPLICANT_STAYED_RESIDANCE"].ToString().Trim();
           //ddlTPC1_AppYCR.SelectedValue = dt.Rows[0]["YEARS_LIVE_AT_ADD2"].ToString().Trim();

           string strTPC1_AppYCR = dt.Rows[0]["YEARS_LIVE_AT_ADD2"].ToString().Trim();

           if (strTPC1_AppYCR == "Not Confirmed")
           {
               chkTPC1_AppYCR.Checked = true;
           }
           else
           {
               string[] arrTPC1_AppYCR = strTPC1_AppYCR.Split(':');

               if (arrTPC1_AppYCR.Length > 0)
               {
                   txtTPC1_AppYCR_YY.Text = arrTPC1_AppYCR[0].Trim();
               }

               if (arrTPC1_AppYCR.Length > 1)
               {
                   txtTPC1_AppYCR_MM.Text = arrTPC1_AppYCR[1].Trim();
               }
           }



           ddlTCP1_AppOwnershipStatus.SelectedValue = dt.Rows[0]["OWNERSHIP_APPLICANT_RESIDANCE_1"].ToString().Trim();
           ddlEntryPermitted.SelectedValue = dt.Rows[0]["ENTRY_PERMITTED"].ToString().Trim();
           ddlStandardOfLiving.SelectedValue = dt.Rows[0]["DOOR_LOCK"].ToString().Trim();

           string strInterior = Convert.ToString(dt.Rows[0]["INTERIOR"].ToString());
           string[] arrINTERIOR = strInterior.Split(',');

           for (int i = 0; i <= arrINTERIOR.Length - 1; i++)
           {
               for (int j = 0; j <= chkInterior.Items.Count - 1; j++)
               {
                   if (arrINTERIOR[i].Trim() == chkInterior.Items[j].Value)
                   {
                       chkInterior.Items[j].Selected = true;
                   }
               }
           }

           string strAssetSeen = Convert.ToString(dt.Rows[0]["ASSETS_VISIBLE"].ToString());
           string[] arrAssetSeen = strAssetSeen.Split(',');

           for (int i = 0; i <= arrAssetSeen.Length - 1; i++)
           {
               for (int j = 0; j <= chkAssetsVisible.Items.Count - 1; j++)
               {
                   if (arrAssetSeen[i].Trim() == chkAssetsVisible.Items[j].Value)
                   {
                       chkAssetsVisible.Items[j].Selected = true;
                   }
               }
           }

            
                ddlExteriorCondition.SelectedValue = dt.Rows[0]["COMMENTS_EXTERIORS"].ToString().Trim();
                ddlLocality.SelectedValue = dt.Rows[0]["LOCALITY"].ToString().Trim();
                ddlAreaType.SelectedValue = dt.Rows[0]["TYPE_OF_OFFICE"].ToString().Trim();
                ddlTypeAcco.SelectedValue = dt.Rows[0]["ACCOMODATION"].ToString().Trim();

                ddlEaseOfLocatingHouse.SelectedValue = dt.Rows[0]["LOCATING_ADDRESS"].ToString().Trim();
                ddlAreaOfHouse.SelectedValue = dt.Rows[0]["APPROXIMATE_AREA"].ToString().Trim();
                ddlDirectory_Check.SelectedValue = dt.Rows[0]["DIRECTORY_CHECK"].ToString().Trim();
                ///Attemp Details 
                txtVerifierName.Text = dt.Rows[0]["VERIFIER_COMMENTS"].ToString().Trim();
                ddlVeri_Conduct_At.SelectedValue = dt.Rows[0]["VERIFICATION_CONDUCTED_AT"].ToString().Trim();
                txtVerifierRemark.Text = dt.Rows[0]["FE_remark"].ToString().Trim();
                if ((dt.Rows[0]["SupervisorName_EmpID"] != null) || (dt.Rows[0]["SupervisorName_EmpID"]!=""))
                {
                    ddlSupervisorName.SelectedValue = dt.Rows[0]["SupervisorName_EmpID"].ToString().Trim();
                }
                txtSuperVisorRemark.Text = dt.Rows[0]["SUPERVISOR_REMARKS"].ToString().Trim();
                ddlProprietor_recomm.SelectedValue = dt.Rows[0]["RECOMMENDATION"].ToString().Trim();
                txtDeclineCode.Text = dt.Rows[0]["DECLINED_CODE"].ToString().Trim();
                txtAuthSign.Text = dt.Rows[0]["Job_desc"].ToString().Trim();
                txtAddressUpdation.Text = dt.Rows[0]["Correct_Address"].ToString().Trim();
                ddlAddressUpdation.Text = dt.Rows[0]["Address_Updation"].ToString().Trim();

                txtResultOfCalling.Text = dt.Rows[0]["RESULT_CALLING"].ToString().Trim();
                txtWhomtheAddBelongsTo.Text = dt.Rows[0]["ADDRESS_BELONG"].ToString().Trim();
                ddlReasonForAddNotConfirmed.SelectedValue = dt.Rows[0]["REASON_ADD_NOT_CONFIRM"].ToString().Trim();

                ddlTPC2_Name.SelectedValue = dt.Rows[0]["TPC2_Name"].ToString().Trim();
                txtTPC2_Name.Text = dt.Rows[0]["TPC2_Name_Confirm"].ToString().Trim();
                ddlTPC2_ByWhom.SelectedValue = dt.Rows[0]["TPC2_By_Whom"].ToString().Trim();
                txtTPC2_Address.Text = dt.Rows[0]["TPC2_Address"].ToString().Trim();
                txtTPC2_AppHomeConfirm.Text = dt.Rows[0]["TPC2_App_Available_at_Home"].ToString().Trim();
                ddlTPC2_AppNameConfirmed.SelectedValue = dt.Rows[0]["TPC2_App_Name_Confirm"].ToString().Trim();
                ddlTPC2_AppStayConfirmed.SelectedValue = dt.Rows[0]["TPC2_App_Stay_Confirm"].ToString().Trim();
                ddlTCP2_AppOwnershipStatus.SelectedValue = dt.Rows[0]["TPC2_App_Own_Status"].ToString().Trim();

                string strTPC2_AppYCR = dt.Rows[0]["TPC2_App_YCR"].ToString().Trim();

                if (strTPC2_AppYCR == "Not Confirmed")
                {
                    chkTPC2_AppYCR.Checked = true;
                }
                else
                {
                    string[] arrTPC2_AppYCR = strTPC2_AppYCR.Split(':');

                    if (arrTPC2_AppYCR.Length > 0)
                    {
                        txtTPC2_AppYCR_YY.Text = arrTPC2_AppYCR[0].Trim();
                    }

                    if (arrTPC2_AppYCR.Length > 1)
                    {
                        txtTPC2_AppYCR_MM.Text = arrTPC2_AppYCR[1].Trim();
                    }
                }

                txtObservation.Text = dt.Rows[0]["Observation"].ToString().Trim();



                DataSet dsAttempt;
                dsAttempt = objCCVer.GetAttemptDtl(txtCaseID.Text.Trim() , "1");
                //START Attempt Details ------------------------------------
                if (txtCaseID.Text.Trim() != "")
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
                                ddlVerifierRemarks1.Text = dsAttempt.Tables[0].Rows[i]["Remark"].ToString();
                            }
                            if (i == 1)
                            {
                                string sTmp = dsAttempt.Tables[0].Rows[i]["Attempt_Date_Time"].ToString();
                                string[] arrAttemptDateTime = sTmp.Split(' ');
                                txtAttemptDate2.Text = Convert.ToDateTime(arrAttemptDateTime[0].ToString()).ToString("dd/MM/yyyy");
                                txtAttemptTime2.Text = Convert.ToDateTime(arrAttemptDateTime[1].ToString()).ToString("hh:mm");
                                ddlAttemptTimeType2.SelectedValue = arrAttemptDateTime[2].ToString();
                                ddlVerifierRemarks2.Text = dsAttempt.Tables[0].Rows[i]["Remark"].ToString();
                            }
                            if (i == 2)
                            {
                                string sTmp = dsAttempt.Tables[0].Rows[i]["Attempt_Date_Time"].ToString();
                                string[] arrAttemptDateTime = sTmp.Split(' ');
                                txtAttemptDate3.Text = Convert.ToDateTime(arrAttemptDateTime[0].ToString()).ToString("dd/MM/yyyy");
                                txtAttemptTime3.Text = Convert.ToDateTime(arrAttemptDateTime[1].ToString()).ToString("hh:mm");
                                ddlAttemptTimeType3.SelectedValue = arrAttemptDateTime[2].ToString();
                                ddlVerifierRemarks3.Text = dsAttempt.Tables[0].Rows[i]["Remark"].ToString();
                            }
                        }

                    }

                }


                //if (dt.Rows[0]["Attempt1"].ToString() != "")
                //{
                //    txtAttemptDate1.Text = dt.Rows[0]["Attempt1"].ToString().Substring(0, 10);
                //    txtAttemptTime1.Text = dt.Rows[0]["Attempt1"].ToString().Substring(11, 5);
                
                //}
                //if (dt.Rows[0]["Attempt2"].ToString() != "")
                //{
                //    txtAttemptDate2.Text = dt.Rows[0]["Attempt2"].ToString().Substring(0, 10);
                //    txtAttemptTime2.Text = dt.Rows[0]["Attempt2"].ToString().Substring(11, 5);
                //}

                //if (dt.Rows[0]["Attempt3"].ToString() != "")
                //{
                //    txtAttemptDate3.Text = dt.Rows[0]["Attempt3"].ToString().Substring(0, 10);
                //    txtAttemptTime3.Text = dt.Rows[0]["Attempt3"].ToString().Substring(11, 5);
                //}
                 
    
        }
        catch (Exception Ex)
        {
            lblMessage.Text = Ex.Message;
        }
    }
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
                    lblMessage.Visible = true;
                    lblMessage.ForeColor = System.Drawing.Color.Red;
                    lblMessage.Text = "Enter date in first attempt.";
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
            if (ddlVerifierRemarks1.Text.Trim() != "" && IsValid == true)
            {
                if (txtAttemptDate1.Text == "")
                {
                    IsValid = false;
                    lblMessage.Visible = true;
                    lblMessage.ForeColor = System.Drawing.Color.Red;
                    lblMessage.Text = "Enter date in first attempt.";
                    txtAttemptDate1.Focus();
                }
                if (txtAttemptTime1.Text == "")
                {
                    IsValid = false;
                    lblMessage.Visible = true;
                    lblMessage.ForeColor = System.Drawing.Color.Red;
                    lblMessage.Text = "Enter time in first attempt.";
                    txtAttemptTime1.Focus();
                }
                if (ddlVerifierRemarks1.Text.Length > 500)
                {
                    IsValid = false;
                    lblMessage.Visible = true;
                    lblMessage.ForeColor = System.Drawing.Color.Red;
                    lblMessage.Text = "Remark should not be greater than 255 characters in first attempt.";
                    ddlVerifierRemarks1.Focus();
                }

            }

            if (txtAttemptTime2.Text != "" && IsValid == true)
            {
                if (txtAttemptDate2.Text == "")
                {
                    IsValid = false;
                    lblMessage.Visible = true;
                    lblMessage.ForeColor = System.Drawing.Color.Red;
                    lblMessage.Text = "Enter date in second attempt.";
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

            if (ddlVerifierRemarks2.Text != "" && IsValid == true)
            {
                if (txtAttemptDate2.Text == "")
                {
                    IsValid = false;
                    lblMessage.Visible = true;
                    lblMessage.ForeColor = System.Drawing.Color.Red;
                    lblMessage.Text = "Enter date in second attempt.";
                    txtAttemptDate2.Focus();
                }
                if (txtAttemptTime2.Text == "")
                {
                    IsValid = false;
                    lblMessage.Visible = true;
                    lblMessage.ForeColor = System.Drawing.Color.Red;
                    lblMessage.Text = "Enter time in second attempt.";
                    txtAttemptTime2.Focus();
                }
                if (ddlVerifierRemarks2.Text.Length > 500)
                {
                    IsValid = false;
                    lblMessage.Visible = true;
                    lblMessage.ForeColor = System.Drawing.Color.Red;
                    lblMessage.Text = "Remark should not be greater than 255 characters in second attempt.";
                    ddlVerifierRemarks2.Focus();
                }
            }

            if (txtAttemptTime3.Text != "" && IsValid == true)
            {
                if (txtAttemptDate3.Text == "")
                {
                    IsValid = false;
                    lblMessage.Visible = true;
                    lblMessage.ForeColor = System.Drawing.Color.Red;
                    lblMessage.Text = "Enter date in third attempt.";
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

            if (ddlVerifierRemarks3.Text != "" && IsValid == true)
            {
                if (txtAttemptDate3.Text == "")
                {
                    IsValid = false;
                    lblMessage.Visible = true;
                    lblMessage.ForeColor = System.Drawing.Color.Red;
                    lblMessage.Text = "Enter date in third attempt.";
                    txtAttemptDate3.Focus();
                }
                if (txtAttemptTime3.Text == "")
                {
                    IsValid = false;
                    lblMessage.Visible = true;
                    lblMessage.Text = "Enter time in third attempt.";
                    txtAttemptTime3.Focus();
                }
                if (ddlVerifierRemarks3.Text.Length > 500)
                {
                    IsValid = false;
                    lblMessage.Visible = true;
                    lblMessage.ForeColor = System.Drawing.Color.Red;
                    lblMessage.Text = "Remark should not be greater than 255 characters in third attempt.";
                    ddlVerifierRemarks3.Focus();
                }
            }

         
            if (txtAttemptTime1.Text.Trim() == "" && txtAttemptTime2.Text.Trim() == "" && txtAttemptTime3.Text.Trim() == "")
            {
                
            }

        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message; 
        }
        return IsValid;
    }
    private string Get_Attempt_details()
    { 
            try
            {

                string strAttempt = "";
                strAttempt = strAttempt + txtAttemptDate1.Text.Trim() + "|" + txtAttemptTime1.Text.Trim() + "|" + ddlAttemptTimeType1.Text.Trim() + "|" + ddlVerifierRemarks1.Text.Trim() + "^" + txtAttemptDate2.Text.Trim() + "|" + txtAttemptTime2.Text.Trim() + "|" + ddlAttemptTimeType2.Text.Trim() + "|" + ddlVerifierRemarks2.Text.Trim() + "^" + txtAttemptDate3.Text.Trim() + "|" + txtAttemptTime3.Text.Trim() + "|" +ddlAttemptTimeType3.Text.Trim() + "|" + ddlVerifierRemarks3.Text.Trim() + "^";

                return strAttempt;

            }   
            catch (Exception Ex)
            {
                lblMessage.Text = Ex.Message;
                return "";
            }

    }
    private void Register_Control_for_Javascript()
    { 
        try 
        {
             
             
            ddlAddressConfirm.Attributes.Add("onchange", "javascript:Enable_Validation_on_AddConfirm();");
            ddlEntryPermitted.Attributes.Add("onchange", "javascript:Enable_Validation_on_EntryPermitted();");
            ddlTypeOfProof.Attributes.Add("onchange", "javascript:Enable_Validation_on_Proof();"); 
            ddlReasonForAddNotConfirmed.Attributes.Add("onchange", "javascript:Enable_Validation_on_AddressNotConfirmed();");
            ddl_InfoRefused.Attributes.Add("onchange", "javascript:Enable_Validation_on_InfoRefused();");
            ddlTPC1_Name.Attributes.Add("onchange", "javascript:Enable_Validation_On_TPC1_Name();");
            ddlAddressUpdation.Attributes.Add("onchange", "javascript:Enable_Validation_On_AddressUpdation();");
            btnSave.Attributes.Add("onclick", "javascript:return Enable_Validation_Final_Submit();");
            ddlProprietor_recomm.Attributes.Add("onchange", "javascript:Enable_Validation_Confirmed(" + ddlProprietor_recomm.ClientID + ",'Defaulter',false," + txtDefault.ClientID + ",'TextBox');");
            ddlNameOfPersonMet.Attributes.Add("onchange", "javascript:Enabled_Validation_PersonMet();");
            chkApplicant_DOBAGE_NotConf.Attributes.Add("onclick", "javascript:Enabled_Validation_YY_MM(" + chkApplicant_DOBAGE_NotConf.ClientID + ",true," + txtApplicantAge_DOB.ClientID + "," + txtApplicantAge_DOB_YY.ClientID + "," + txtApplicantAge_DOB_MM.ClientID + ");");
            chk_YCR.Attributes.Add("onclick", "javascript:Enabled_Validation_YY_MM(" + chk_YCR.ClientID + ",true,null," + txtYearsLivedAtResi_YY.ClientID + "," + txtYearsLivedAtResi_MM.ClientID + ");");
            chk_YCE.Attributes.Add("onclick", "javascript:Enabled_Validation_YY_MM(" + chk_YCE.ClientID + ",true,null," + txtYrsInEMP_YY.ClientID + "," + txtYrsInEMP_MM.ClientID + ");");
            ddlCompanyDetails.Attributes.Add("onchange", "javascript:Enabled_Validation_CompanyDetails();");
            chkTPC1_AppYCR.Attributes.Add("onclick", "javascript:Enabled_Validation_YY_MM(" + chkTPC1_AppYCR.ClientID + ",true,null," + txtTPC1_AppYCR_YY.ClientID + "," + txtTPC1_AppYCR_MM.ClientID + ");");
            chkTPC2_AppYCR.Attributes.Add("onclick", "javascript:Enabled_Validation_YY_MM(" + chkTPC2_AppYCR.ClientID + ",true,null," + txtTPC2_AppYCR_YY.ClientID + "," + txtTPC2_AppYCR_MM.ClientID + ");");
            ddlTPC2_Name.Attributes.Add("onchange", "javascript:Enable_Validation_On_TPC2_Name();");
            ddlTPC1_AppNameConfirmed.Attributes.Add("onchange", "javascript:Enable_Validation_On_TPC1_Application_Name_Confirmed();");
            ddlTPC2_AppNameConfirmed.Attributes.Add("onchange", "javascript:Enable_Validation_On_TPC2_Application_Name_Confirmed();");
            ddlTPC1_AppStayConfirmed.Attributes.Add("onchange", "javascript:Enable_Validation_On_TPC1_Application_Stay_Confirmed();");
            ddlTPC2_AppStayConfirmed.Attributes.Add("onchange", "javascript:Enable_Validation_On_TPC2_Application_Stay_Confirmed();");
            txtVerifierRemark.Attributes.Add("onDblClick", "javascript:Enable_validation_On_AutoPopulate_Remark();");

            txtSuperVisorRemark.Attributes.Add("onDblClick", "javascript:Enable_validation_On_SupervisorAutoPopulate_Remark();");

            ddlAddConfBy.Attributes.Add("onchange", "javascript:Enable_validation_AddressConfirmBy();");
            ddlRelationShipWithApp.Attributes.Add("onchange", "javascript:Enable_Validation_ResidanceNo_Confirmed(" + ddlRelationShipWithApp.ClientID + ",'Others',false," + txtRelationship_Other.ClientID + ",'TextBox');");
            txtObservation.Attributes.Add("onkeypress", "javascript:CountLength();");
            
        }    
        catch (Exception Ex)
            {
                lblMessage.Text = Ex.Message;
             
            }
    }     
    private void FillSupervisorName()
    {
        DataTable dtSupName = new DataTable();        
        dtSupName = objRVT.GetSupervisorName(Session["CentreId"].ToString());
        ddlSupervisorName.DataTextField = "FULLNAME";
        ddlSupervisorName.DataValueField = "EMP_ID";
        ddlSupervisorName.DataSource = dtSupName;
        ddlSupervisorName.DataBind();

           
    }
}
