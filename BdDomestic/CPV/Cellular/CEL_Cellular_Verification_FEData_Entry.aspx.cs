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

public partial class CPV_Cellular_CEL_Cellular_Verification_FEData_Entry : System.Web.UI.Page
{
    C_CELLULAR_ENTRY objCellular = new C_CELLULAR_ENTRY();
    CCommon objCom = new CCommon();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if ((Request.QueryString["CaseID"] != null) && (Request.QueryString["CaseID"] != ""))
            {

                hidCaseID.Value = Request.QueryString["CaseID"].ToString();
                Session["CaseID"] = hidCaseID.Value;

                int ClientId =Convert.ToInt32(Session["ClientId"]);
                int verification_type_id = 2;
                Get_Cellular_Details(hidCaseID.Value, ClientId, verification_type_id);
            }
        }

    }

    private void Get_Cellular_Details(string pCaseId, int pClientId, int pVeri_Type_Id)
    {
        try
        {
            SqlConnection sqlCon = new SqlConnection(ConfigurationManager.AppSettings["constring"]);

            sqlCon.Open();
            SqlCommand sqlCom = new SqlCommand();
            sqlCom.Connection = sqlCon;
            sqlCom.CommandType = CommandType.StoredProcedure;
            sqlCom.CommandText = "GET_Cellular_CASE_Details";
            sqlCom.CommandTimeout = 0;

            SqlParameter Case_Id = new SqlParameter();
            Case_Id.SqlDbType = SqlDbType.VarChar;
            Case_Id.ParameterName = "@Case_Id";
            Case_Id.Value = pCaseId;
            sqlCom.Parameters.Add(Case_Id);

            SqlParameter Verification_Type_Id = new SqlParameter();
            Verification_Type_Id.SqlDbType = SqlDbType.Int;
            Verification_Type_Id.ParameterName = "@Verification_Type_Id";
            Verification_Type_Id.Value = pVeri_Type_Id;
            sqlCom.Parameters.Add(Verification_Type_Id);

            SqlParameter ClientId = new SqlParameter();
            ClientId.SqlDbType = SqlDbType.Int;
            ClientId.ParameterName = "@Client_Id";
            ClientId.Value = pClientId;
            sqlCom.Parameters.Add(ClientId);

            SqlDataAdapter sqlDA = new SqlDataAdapter();
            sqlDA.SelectCommand = sqlCom;
            DataSet ds = new DataSet();
            sqlDA.Fill(ds);
            sqlCon.Close();
            if (ds.Tables[0].Rows.Count > 0)
            {
                Assign_Cellular_Details(ds.Tables[0]);
            }
            else
            {
                lblmessage.Text = "No Details found!!!!";
            }
        }
        catch (Exception ex)
        {

            lblmessage.CssClass = "ErrorMessage";
            lblmessage.Text = ex.Message;
            lblmessage.Visible = true;
        }


    }



    private void Assign_Cellular_Details(DataTable dt)
    {
        try
        {

            //Start CPV CC CASE Details 
            txtcaseid.Text = dt.Rows[0]["Case_Id"].ToString().Trim();

            txtRefNo.Text = dt.Rows[0]["Ref_no"].ToString().Trim();

            txtNameOftheApplicant.Text = dt.Rows[0]["ApplicantName"].ToString().Trim();
            txtAddressoftheApplicant.Text = dt.Rows[0]["Resi_Add"].ToString().Trim();

            //txtNameOftheApplicantupdatedbyFE.Text = dt.Rows[0]["CustomerName_By_FE"].ToString().Trim();
            //txtAddressoftheApplicantUpdatedbyFE.Text = dt.Rows[0]["Resi_Add_By_FE"].ToString().Trim();

            txtNameofPersonContacted.Text = dt.Rows[0]["MET_PERSON"].ToString().Trim();
            txtDesignationofpersoncontacted.Text = dt.Rows[0]["DESIG_PERSON_CON"].ToString().Trim();
            txtResiPincode.Text = dt.Rows[0]["ALT_PIN_CODE"].ToString().Trim();
            txtResiTelNo.Text = dt.Rows[0]["ALT_PHONE"].ToString().Trim();
            txtNoOfEmployee.Text = dt.Rows[0]["CSEMPLOYER"].ToString().Trim();
            ddlCommentOfNeighbour.SelectedValue = dt.Rows[0]["COMMENTS"].ToString().Trim();
            txtDateOfBirth.Text = dt.Rows[0]["DATE_OF_BIRTH"].ToString().Trim();
            txtNumberOfYearsinCurrentEmployment.Text = dt.Rows[0]["CURRENT_STATUS"].ToString().Trim();
            txtSimcardpurchasesfrom.Text = dt.Rows[0]["SIM_NUMBER"].ToString().Trim();
            txtPaymentMode.Text = dt.Rows[0]["If_Yes_Tick_payment_mode"].ToString().Trim();
            txtBillTo.Text = dt.Rows[0]["BILL_TO_ID"].ToString().Trim();
            txtBillPlanConfirmed.Text = dt.Rows[0]["BILL_PLAN"].ToString().Trim();
            txtpaymentOptions.Text = dt.Rows[0]["PAYMENT_DEVICE"].ToString().Trim();
            //End CPV CC CASE Details 

            //Start CPV CC CASE Verification Details 
            txtResidenceAddress.Text = dt.Rows[0]["ALT_ADDRESS"].ToString().Trim();
            txtEmail.Text = dt.Rows[0]["Email"].ToString().Trim();
            txtUserOfSim.Text = dt.Rows[0]["Sim_Used_By"].ToString().Trim();
            ddlNatureofBusiness.SelectedValue = dt.Rows[0]["NATURE_OF_BUSINESS"].ToString().Trim();
            txtIfNatureOfBusinessOtherSpecify.Text = dt.Rows[0]["NATURE_OF_BUSINESS"].ToString().Trim();//dt.Rows[0][""];
            txtPerferredmodeofcommunication.Text = dt.Rows[0]["IP_Comments"].ToString().Trim();
            txtlanguageofcommunication.Text = dt.Rows[0]["PV_Tag"].ToString().Trim();
            txtOccupation.Text = dt.Rows[0]["Occupation_id"].ToString().Trim();
            txtFirstBillExplanation.Text = dt.Rows[0]["FIRST_Bill_EXP"].ToString().Trim();
            txtBillingAddress.Text = dt.Rows[0]["BILLING_ADDRESS"].ToString().Trim();
            txtReasonforapplicantnotmet.Text = dt.Rows[0]["APP_MET"].ToString().Trim();
            //End CPV CC CASE Verification Details 


            //txtNameOftheApplicant.Text = dt.Rows[0]["Name_App"].ToString().Trim();
            //txtAddressoftheApplicant.Text = dt.Rows[0]["Add_App"].ToString().Trim();
            //txtDesignationofpersoncontacted.Text = dt.Rows[0]["Desig_person_con"].ToString().Trim();
            txtResiLandmark.Text = dt.Rows[0]["Resi_Landmark"].ToString().Trim();
            txtLandmarkObserved.Text = dt.Rows[0]["Land_observ"].ToString().Trim();
            txtNameOfCompany.Text = dt.Rows[0]["Name_comp"].ToString().Trim();
            txtAddressOfCompany.Text = dt.Rows[0]["Add_comp"].ToString().Trim();
            txtBusinessTelNo.Text = dt.Rows[0]["Buss_tel"].ToString().Trim();
            ddlTypeOfOffice.SelectedValue = dt.Rows[0]["Type_off"].ToString().Trim();
            txtIfOtherSpecify.Text = dt.Rows[0]["Type_off"].ToString().Trim();
            txtTypeOfOrganization.Text = dt.Rows[0]["Type_org"].ToString().Trim();
            txtiftypeoforgSpecify.Text = dt.Rows[0]["Type_org"].ToString().Trim();

            txtAnnualTurnover.Text = dt.Rows[0]["Annual_turn"].ToString().Trim();
            txtAddressOfNeighbour.Text = dt.Rows[0]["Add_neigh"].ToString().Trim();
            txtColoroftheBuilding.Text = dt.Rows[0]["colour_bldg"].ToString().Trim();
            txtNearestRailwayStation.Text = dt.Rows[0]["Near_rail"].ToString().Trim();
            txtNearestBusStop.Text = dt.Rows[0]["Near_bus"].ToString().Trim();
            ddlTypeOfCompany.Text = dt.Rows[0]["Type_comp"].ToString().Trim();
            ddlQualification.SelectedValue = dt.Rows[0]["Qualification"].ToString().Trim();
            txtIfQualificationOtherSpecify.Text = dt.Rows[0]["Qualification"].ToString().Trim();
            txtApplicantAvailableAt.Text = dt.Rows[0]["App_available"].ToString().Trim();
            txtStayingSinceAtResi.Text = dt.Rows[0]["Stay_resi"].ToString().Trim();
            txtTotalWorkExperience.Text = dt.Rows[0]["Total_exp"].ToString().Trim();
            txtNameOftheUser.Text = dt.Rows[0]["Name_user"].ToString().Trim();
            txtVodafoneNumberAppliedFor.Text = dt.Rows[0]["Voda_number"].ToString().Trim();
            txtApproximateArea.Text = dt.Rows[0]["Appro_area"].ToString().Trim();
            ddlEntryPermitted.SelectedValue = dt.Rows[0]["entry_per"].ToString().Trim();

            string strInterior = Convert.ToString(dt.Rows[0]["INTERIOR"].ToString());
            string[] arrINTERIOR = strInterior.Split(',');

            for (int i = 0; i <= arrINTERIOR.Length - 1; i++)
            {
                for (int j = 0; j <= chkDescribeInteriorofPremises.Items.Count - 1; j++)
                {
                    if (arrINTERIOR[i].Trim() == chkDescribeInteriorofPremises.Items[j].Value)
                    {
                        chkDescribeInteriorofPremises.Items[j].Selected = true;
                    }
                }
            }

            string strAssetSeen = Convert.ToString(dt.Rows[0]["assets"].ToString());
            string[] arrAssetSeen = strAssetSeen.Split(',');

            for (int i = 0; i <= arrAssetSeen.Length - 1; i++)
            {
                for (int j = 0; j <= ckhAssests.Items.Count - 1; j++)
                {
                    if (arrAssetSeen[i].Trim() == ckhAssests.Items[j].Value)
                    {
                        ckhAssests.Items[j].Selected = true;
                    }
                }
            }

            //ckhAssests
            // chkDescribeInteriorofPremises

            ddlBusinessboardsigghted.SelectedValue = dt.Rows[0]["Buss_sigh"].ToString().Trim();
            ddlLocatingtheaddress.SelectedValue = dt.Rows[0]["Locating_add"].ToString().Trim();
            txtDescribeExteriorofPremises.Text = dt.Rows[0]["Exterior"].ToString().Trim();
            txtCreditCard.Text = dt.Rows[0]["Make_payment"].ToString().Trim();
            ddlBusinessActivity.SelectedValue = dt.Rows[0]["Buss_act"].ToString().Trim();
            txtOwnedValue.Text = dt.Rows[0]["Own_value"].ToString().Trim();
            txtRentedValue.Text = dt.Rows[0]["Rent_value"].ToString().Trim();
            txtIfRetired.Text = dt.Rows[0]["If_retired"].ToString().Trim();
            txtPanCardNumber.Text = dt.Rows[0]["Pan_number"].ToString().Trim();
            txtAlternateNo.Text = dt.Rows[0]["Alternate_num"].ToString().Trim();
            txtSimcardReceived.Text = dt.Rows[0]["Sim_recd"].ToString().Trim();
            txtwelcomeKitDelivered.Text = dt.Rows[0]["Welcome_kit"].ToString().Trim();
            txtStandingInstructions.Text = dt.Rows[0]["Stand_inst"].ToString().Trim();
            txtECS.Text = dt.Rows[0]["Ecs"].ToString().Trim();
            txtEBill.Text = dt.Rows[0]["Ebill"].ToString().Trim();
            txtPhotographIdentified.Text = dt.Rows[0]["Photo_id"].ToString().Trim();
            ddlLocality.SelectedValue = dt.Rows[0]["Locality"].ToString().Trim();
            ddlBusinessStockSeen.SelectedValue = dt.Rows[0]["Buss_seen"].ToString().Trim();
            ddlTypeOfJob.SelectedValue = dt.Rows[0]["Type_job"].ToString().Trim();
            txtAnyotherbusinessinsamecity.Text = dt.Rows[0]["Any_buss"].ToString().Trim();
            txtPaymentresponsibility.Text = dt.Rows[0]["Payment_resp"].ToString().Trim();
            txtPreviousNumber.Text = dt.Rows[0]["Prev_num"].ToString().Trim();
            txtBillingAverage.Text = dt.Rows[0]["bill_avg"].ToString().Trim();
            txtRecomNumByFE.Text = dt.Rows[0]["Recomm_fe"].ToString().Trim();
            txtVodafoneMobileUsedBySelf.Text = dt.Rows[0]["Voda_use"].ToString().Trim();
            txtNoOfConnections.Text = dt.Rows[0]["Conn_req"].ToString().Trim();
            txtCOCP.Text = dt.Rows[0]["Ip_conn"].ToString().Trim();

            string strAttempt = Convert.ToString(dt.Rows[0]["Attempt_Datetime"].ToString());
            if (strAttempt != "")
            {
                string[] arrAttemptDateTime = strAttempt.Split(' ');
                txtDateTime.Text = Convert.ToDateTime(arrAttemptDateTime[0].ToString()).ToString("dd/MM/yyyy");
                txttime.Text = Convert.ToDateTime(arrAttemptDateTime[1].ToString()).ToString("hh:mm");
                ddldatetime.SelectedValue = arrAttemptDateTime[2].ToString();
            }
           
            txtFERemark.Text = dt.Rows[0]["FE_REMARK"].ToString().Trim();


        }
        catch (Exception ex)
        {
            lblmessage.Text = ex.Message;
            lblmessage.Visible = true;

        }

    }



    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            Insert_Cellular_FE_CASE_Details();

        }
        catch (Exception ex)
        {
            lblmessage.Text = ex.Message;
            lblmessage.Visible = true;
        }

    }

    private void Insert_Cellular_FE_CASE_Details()
    {
        try
        {

            SqlConnection sqlCon = new SqlConnection(ConfigurationManager.AppSettings["constring"]);

            sqlCon.Open();
            SqlCommand sqlCom = new SqlCommand();
            sqlCom.Connection = sqlCon;
            sqlCom.CommandType = CommandType.StoredProcedure;
            sqlCom.CommandText = "Insert_Cellular_CASE_Details";
            sqlCom.CommandTimeout = 0;

            SqlParameter Case_Id = new SqlParameter();
            Case_Id.SqlDbType = SqlDbType.VarChar;
            Case_Id.ParameterName = "@Case_Id";
            Case_Id.Value = txtcaseid.Text.Trim();//hidCaseID.Value;
            sqlCom.Parameters.Add(Case_Id);

            SqlParameter Verification_Id = new SqlParameter();
            Verification_Id.SqlDbType = SqlDbType.VarChar;
            Verification_Id.ParameterName = "@Verification_Type_Id";
            Verification_Id.Value = "2";
            sqlCom.Parameters.Add(Verification_Id);

            SqlParameter Name_of_the_Applicant = new SqlParameter();
            Name_of_the_Applicant.SqlDbType = SqlDbType.VarChar;
            Name_of_the_Applicant.ParameterName = "@Name_App";
            Name_of_the_Applicant.Value = txtNameOftheApplicant.Text.Trim();
            sqlCom.Parameters.Add(Name_of_the_Applicant);

            SqlParameter Address_of_the_applicant = new SqlParameter();
            Address_of_the_applicant.SqlDbType = SqlDbType.VarChar;
            Address_of_the_applicant.ParameterName = "@Add_App";
            Address_of_the_applicant.Value = txtAddressoftheApplicant.Text.Trim();
            sqlCom.Parameters.Add(Address_of_the_applicant);

            SqlParameter Name_of_person_contacted = new SqlParameter();
            Name_of_person_contacted.SqlDbType = SqlDbType.VarChar;
            Name_of_person_contacted.ParameterName = "@Name_of_person_contacted";
            Name_of_person_contacted.Value = txtNameofPersonContacted.Text.Trim();
            sqlCom.Parameters.Add(Name_of_person_contacted);

            SqlParameter Designation_of_person_contacted = new SqlParameter();
            Designation_of_person_contacted.SqlDbType = SqlDbType.VarChar;
            Designation_of_person_contacted.ParameterName = "@Designation_of_person_contacted";
            Designation_of_person_contacted.Value = txtDesignationofpersoncontacted.Text.Trim();
            sqlCom.Parameters.Add(Designation_of_person_contacted);

            SqlParameter Residence_Address = new SqlParameter();
            Residence_Address.SqlDbType = SqlDbType.VarChar;
            Residence_Address.ParameterName = "@Residence_Address";
            Residence_Address.Value = txtResidenceAddress.Text.Trim();
            sqlCom.Parameters.Add(Residence_Address);

            SqlParameter Resi_Pincode = new SqlParameter();
            Resi_Pincode.SqlDbType = SqlDbType.VarChar;
            Resi_Pincode.ParameterName = "@Resi_Pincode";
            Resi_Pincode.Value = txtResiPincode.Text.Trim();
            sqlCom.Parameters.Add(Resi_Pincode);

            SqlParameter Resi_Tel_No = new SqlParameter();
            Resi_Tel_No.SqlDbType = SqlDbType.VarChar;
            Resi_Tel_No.ParameterName = "@Resi_Tel_No";
            Resi_Tel_No.Value = txtResiTelNo.Text.Trim();
            sqlCom.Parameters.Add(Resi_Tel_No);

            SqlParameter Resi_Landmark = new SqlParameter();
            Resi_Landmark.SqlDbType = SqlDbType.VarChar;
            Resi_Landmark.ParameterName = "@Resi_Landmark";
            Resi_Landmark.Value = txtResiLandmark.Text.Trim();
            sqlCom.Parameters.Add(Resi_Landmark);

            SqlParameter Landmark_observed = new SqlParameter();
            Landmark_observed.SqlDbType = SqlDbType.VarChar;
            Landmark_observed.ParameterName = "@Landmark_observed";
            Landmark_observed.Value = txtLandmarkObserved.Text.Trim();
            sqlCom.Parameters.Add(Landmark_observed);

            SqlParameter Name_of_Company = new SqlParameter();
            Name_of_Company.SqlDbType = SqlDbType.VarChar;
            Name_of_Company.ParameterName = "@Name_of_Company";
            Name_of_Company.Value = txtNameOfCompany.Text.Trim();
            sqlCom.Parameters.Add(Name_of_Company);

            SqlParameter Address_of_company = new SqlParameter();
            Address_of_company.SqlDbType = SqlDbType.VarChar;
            Address_of_company.ParameterName = "@Address_of_company";
            Address_of_company.Value = txtAddressOfCompany.Text.Trim();
            sqlCom.Parameters.Add(Address_of_company);

            SqlParameter Business_Tel_No = new SqlParameter();
            Business_Tel_No.SqlDbType = SqlDbType.VarChar;
            Business_Tel_No.ParameterName = "@Business_Tel_No";
            Business_Tel_No.Value = txtBusinessTelNo.Text.Trim();
            sqlCom.Parameters.Add(Business_Tel_No);

            SqlParameter Type_of_Office = new SqlParameter();
            Type_of_Office.SqlDbType = SqlDbType.VarChar;
            Type_of_Office.ParameterName = "@Type_of_Office";
            Type_of_Office.Value = ddlTypeOfOffice.Text.Trim();
            sqlCom.Parameters.Add(Type_of_Office);

            SqlParameter Type_of_Organization = new SqlParameter();
            Type_of_Organization.SqlDbType = SqlDbType.VarChar;
            Type_of_Organization.ParameterName = "@Type_of_Organization";
            Type_of_Organization.Value = txtTypeOfOrganization.Text.Trim();
            sqlCom.Parameters.Add(Type_of_Organization);

            SqlParameter Number_of_employees = new SqlParameter();
            Number_of_employees.SqlDbType = SqlDbType.VarChar;
            Number_of_employees.ParameterName = "@Number_of_employees";
            Number_of_employees.Value = txtNoOfEmployee.Text.Trim();
            sqlCom.Parameters.Add(Number_of_employees);

            SqlParameter Annual_Turnover = new SqlParameter();
            Annual_Turnover.SqlDbType = SqlDbType.VarChar;
            Annual_Turnover.ParameterName = "@Annual_Turnover";
            Annual_Turnover.Value = txtAnnualTurnover.Text.Trim();
            sqlCom.Parameters.Add(Annual_Turnover);

            SqlParameter Email = new SqlParameter();
            Email.SqlDbType = SqlDbType.VarChar;
            Email.ParameterName = "@Email";
            Email.Value = txtEmail.Text.Trim();
            sqlCom.Parameters.Add(Email);

            SqlParameter Address_Of_Neighbour = new SqlParameter();
            Address_Of_Neighbour.SqlDbType = SqlDbType.VarChar;
            Address_Of_Neighbour.ParameterName = "@Address_Of_Neighbour";
            Address_Of_Neighbour.Value = txtAddressOfNeighbour.Text.Trim();
            sqlCom.Parameters.Add(Address_Of_Neighbour);

            SqlParameter Comments_of_Neighbour = new SqlParameter();
            Comments_of_Neighbour.SqlDbType = SqlDbType.VarChar;
            Comments_of_Neighbour.ParameterName = "@Comments_of_Neighbour";
            Comments_of_Neighbour.Value = ddlCommentOfNeighbour.Text.Trim();
            sqlCom.Parameters.Add(Comments_of_Neighbour);

            SqlParameter Colour_of_the_building = new SqlParameter();
            Colour_of_the_building.SqlDbType = SqlDbType.VarChar;
            Colour_of_the_building.ParameterName = "@Colour_of_the_building";
            Colour_of_the_building.Value = txtColoroftheBuilding.Text.Trim();
            sqlCom.Parameters.Add(Colour_of_the_building);

            SqlParameter Nearest_railway_station = new SqlParameter();
            Nearest_railway_station.SqlDbType = SqlDbType.VarChar;
            Nearest_railway_station.ParameterName = "@Nearest_railway_station";
            Nearest_railway_station.Value = txtNearestRailwayStation.Text.Trim();
            sqlCom.Parameters.Add(Nearest_railway_station);

            SqlParameter Nearest_bus_stop = new SqlParameter();
            Nearest_bus_stop.SqlDbType = SqlDbType.VarChar;
            Nearest_bus_stop.ParameterName = "@Nearest_bus_stop";
            Nearest_bus_stop.Value = txtNearestBusStop.Text.Trim();
            sqlCom.Parameters.Add(Nearest_bus_stop);

            SqlParameter Type_of_Company = new SqlParameter();
            Type_of_Company.SqlDbType = SqlDbType.VarChar;
            Type_of_Company.ParameterName = "@Type_of_Company";
            Type_of_Company.Value = ddlTypeOfCompany.Text.Trim();
            sqlCom.Parameters.Add(Type_of_Company);

            SqlParameter Qualification = new SqlParameter();
            Qualification.SqlDbType = SqlDbType.VarChar;
            Qualification.ParameterName = "@Qualification";
            Qualification.Value = ddlQualification.Text.Trim();
            sqlCom.Parameters.Add(Qualification);

            SqlParameter Date_of_Birth = new SqlParameter();
            Date_of_Birth.SqlDbType = SqlDbType.VarChar;
            Date_of_Birth.ParameterName = "@Date_of_Birth";
            Date_of_Birth.Value = txtDateOfBirth.Text.Trim();
            sqlCom.Parameters.Add(Date_of_Birth);

            SqlParameter Applicant_is_usually_available_at = new SqlParameter();
            Applicant_is_usually_available_at.SqlDbType = SqlDbType.VarChar;
            Applicant_is_usually_available_at.ParameterName = "@Applicant_is_usually_available_at";
            Applicant_is_usually_available_at.Value = txtApplicantAvailableAt.Text.Trim();
            sqlCom.Parameters.Add(Applicant_is_usually_available_at);

            SqlParameter Staying_since_at_Resi = new SqlParameter();
            Staying_since_at_Resi.SqlDbType = SqlDbType.VarChar;
            Staying_since_at_Resi.ParameterName = "@Staying_since_at_Resi";
            Staying_since_at_Resi.Value = txtStayingSinceAtResi.Text.Trim();
            sqlCom.Parameters.Add(Staying_since_at_Resi);

            SqlParameter User_of_Sim = new SqlParameter();
            User_of_Sim.SqlDbType = SqlDbType.VarChar;
            User_of_Sim.ParameterName = "@User_of_Sim";
            User_of_Sim.Value = txtUserOfSim.Text.Trim();
            sqlCom.Parameters.Add(User_of_Sim);

            SqlParameter Total_work_experience = new SqlParameter();
            Total_work_experience.SqlDbType = SqlDbType.VarChar;
            Total_work_experience.ParameterName = "@Total_work_experience";
            Total_work_experience.Value = txtTotalWorkExperience.Text.Trim();
            sqlCom.Parameters.Add(Total_work_experience);

            SqlParameter Name_of_the_User = new SqlParameter();
            Name_of_the_User.SqlDbType = SqlDbType.VarChar;
            Name_of_the_User.ParameterName = "@Name_of_the_User";
            Name_of_the_User.Value = txtNameOftheUser.Text.Trim();
            sqlCom.Parameters.Add(Name_of_the_User);

            SqlParameter Vodafone_number_applied_for = new SqlParameter();
            Vodafone_number_applied_for.SqlDbType = SqlDbType.VarChar;
            Vodafone_number_applied_for.ParameterName = "@Vodafone_number_applied_for";
            Vodafone_number_applied_for.Value = txtVodafoneNumberAppliedFor.Text.Trim();
            sqlCom.Parameters.Add(Vodafone_number_applied_for);

            SqlParameter Approximate_Area = new SqlParameter();
            Approximate_Area.SqlDbType = SqlDbType.VarChar;
            Approximate_Area.ParameterName = "@Approximate_Area";
            Approximate_Area.Value = txtApproximateArea.Text.Trim();
            sqlCom.Parameters.Add(Approximate_Area);

            SqlParameter Nature_of_Business = new SqlParameter();
            Nature_of_Business.SqlDbType = SqlDbType.VarChar;
            Nature_of_Business.ParameterName = "@Nature_of_Business";
            Nature_of_Business.Value = ddlNatureofBusiness.Text.Trim();
            sqlCom.Parameters.Add(Nature_of_Business);

            SqlParameter Number_of_Years_in_Current_Employment = new SqlParameter();
            Number_of_Years_in_Current_Employment.SqlDbType = SqlDbType.VarChar;
            Number_of_Years_in_Current_Employment.ParameterName = "@Number_of_Years_in_Current_Employment";
            Number_of_Years_in_Current_Employment.Value = txtNumberOfYearsinCurrentEmployment.Text.Trim();
            sqlCom.Parameters.Add(Number_of_Years_in_Current_Employment);

            SqlParameter Entry_Permitted = new SqlParameter();
            Entry_Permitted.SqlDbType = SqlDbType.VarChar;
            Entry_Permitted.ParameterName = "@Entry_Permitted";
            Entry_Permitted.Value = ddlEntryPermitted.Text.Trim();
            sqlCom.Parameters.Add(Entry_Permitted);

            SqlParameter Assets = new SqlParameter();
            Assets.SqlDbType = SqlDbType.VarChar;
            Assets.ParameterName = "@Assets";
            Assets.Value = ckhAssests.Text.Trim();
            sqlCom.Parameters.Add(Assets);

            SqlParameter Describe_Interior_of_Premises = new SqlParameter();
            Describe_Interior_of_Premises.SqlDbType = SqlDbType.VarChar;
            Describe_Interior_of_Premises.ParameterName = "@Describe_Interior_of_Premises";
            Describe_Interior_of_Premises.Value = chkDescribeInteriorofPremises.Text.Trim();
            sqlCom.Parameters.Add(Describe_Interior_of_Premises);

            SqlParameter Business_board_sigghted = new SqlParameter();
            Business_board_sigghted.SqlDbType = SqlDbType.VarChar;
            Business_board_sigghted.ParameterName = "@Business_board_sigghted";
            Business_board_sigghted.Value = ddlBusinessboardsigghted.Text.Trim();
            sqlCom.Parameters.Add(Business_board_sigghted);

            SqlParameter Locating_the_address = new SqlParameter();
            Locating_the_address.SqlDbType = SqlDbType.VarChar;
            Locating_the_address.ParameterName = "@Locating_the_address";
            Locating_the_address.Value = ddlLocatingtheaddress.Text.Trim();
            sqlCom.Parameters.Add(Locating_the_address);

            SqlParameter Describe_Exterior_of_Premises = new SqlParameter();
            Describe_Exterior_of_Premises.SqlDbType = SqlDbType.VarChar;
            Describe_Exterior_of_Premises.ParameterName = "@Describe_Exterior_of_Premises";
            Describe_Exterior_of_Premises.Value = txtDescribeExteriorofPremises.Text.Trim();
            sqlCom.Parameters.Add(Describe_Exterior_of_Premises);

            SqlParameter Sim_card_purchases_from = new SqlParameter();
            Sim_card_purchases_from.SqlDbType = SqlDbType.VarChar;
            Sim_card_purchases_from.ParameterName = "@Sim_card_purchases_from";
            Sim_card_purchases_from.Value = txtSimcardpurchasesfrom.Text.Trim();
            sqlCom.Parameters.Add(Sim_card_purchases_from);

            SqlParameter payments_through_credit_card = new SqlParameter();
            payments_through_credit_card.SqlDbType = SqlDbType.VarChar;
            payments_through_credit_card.ParameterName = "@payments_through_credit_card";
            payments_through_credit_card.Value = txtCreditCard.Text.Trim();
            sqlCom.Parameters.Add(payments_through_credit_card);

            SqlParameter If_Yes_Tick_payment_mode = new SqlParameter();
            If_Yes_Tick_payment_mode.SqlDbType = SqlDbType.VarChar;
            If_Yes_Tick_payment_mode.ParameterName = "@If_Yes_Tick_payment_mode";
            If_Yes_Tick_payment_mode.Value = txtPaymentMode.Text.Trim();
            sqlCom.Parameters.Add(If_Yes_Tick_payment_mode);

            SqlParameter Preferred_language_of_communication = new SqlParameter();
            Preferred_language_of_communication.SqlDbType = SqlDbType.VarChar;
            Preferred_language_of_communication.ParameterName = "@Preferred_language_of_communication";
            Preferred_language_of_communication.Value = txtPerferredmodeofcommunication.Text.Trim();
            sqlCom.Parameters.Add(Preferred_language_of_communication);

            SqlParameter Preferred_mode_of_communication = new SqlParameter();
            Preferred_mode_of_communication.SqlDbType = SqlDbType.VarChar;
            Preferred_mode_of_communication.ParameterName = "@Preferred_mode_of_communication";
            Preferred_mode_of_communication.Value = txtlanguageofcommunication.Text.Trim();
            sqlCom.Parameters.Add(Preferred_mode_of_communication);

            SqlParameter Business_Activity = new SqlParameter();
            Business_Activity.SqlDbType = SqlDbType.VarChar;
            Business_Activity.ParameterName = "@Business_Activity";
            Business_Activity.Value = ddlBusinessActivity.Text.Trim();
            sqlCom.Parameters.Add(Business_Activity);

            SqlParameter Owned_Value = new SqlParameter();
            Owned_Value.SqlDbType = SqlDbType.VarChar;
            Owned_Value.ParameterName = "@Owned_Value";
            Owned_Value.Value = txtOwnedValue.Text.Trim();
            sqlCom.Parameters.Add(Owned_Value);

            SqlParameter Rental_Value = new SqlParameter();
            Rental_Value.SqlDbType = SqlDbType.VarChar;
            Rental_Value.ParameterName = "@Rental_Value";
            Rental_Value.Value = txtRentedValue.Text.Trim();
            sqlCom.Parameters.Add(Rental_Value);

            SqlParameter Occupation = new SqlParameter();
            Occupation.SqlDbType = SqlDbType.VarChar;
            Occupation.ParameterName = "@Occupation";
            Occupation.Value = txtOccupation.Text.Trim();
            sqlCom.Parameters.Add(Occupation);

            SqlParameter if_Retired = new SqlParameter();
            if_Retired.SqlDbType = SqlDbType.VarChar;
            if_Retired.ParameterName = "@if_Retired";
            if_Retired.Value = txtIfRetired.Text.Trim();
            sqlCom.Parameters.Add(if_Retired);

            SqlParameter Pan_Card_Number = new SqlParameter();
            Pan_Card_Number.SqlDbType = SqlDbType.VarChar;
            Pan_Card_Number.ParameterName = "@Pan_Card_Number";
            Pan_Card_Number.Value = txtPanCardNumber.Text.Trim();
            sqlCom.Parameters.Add(Pan_Card_Number);

            SqlParameter Bill_To = new SqlParameter();
            Bill_To.SqlDbType = SqlDbType.VarChar;
            Bill_To.ParameterName = "@Bill_To";
            Bill_To.Value = txtBillTo.Text.Trim();
            sqlCom.Parameters.Add(Bill_To);

            SqlParameter Alternate_Contact_number = new SqlParameter();
            Alternate_Contact_number.SqlDbType = SqlDbType.VarChar;
            Alternate_Contact_number.ParameterName = "@Alternate_Contact_number";
            Alternate_Contact_number.Value = txtAlternateNo.Text.Trim();
            sqlCom.Parameters.Add(Alternate_Contact_number);

            SqlParameter Simcard_received = new SqlParameter();
            Simcard_received.SqlDbType = SqlDbType.VarChar;
            Simcard_received.ParameterName = "@Simcard_received";
            Simcard_received.Value = txtSimcardReceived.Text.Trim();
            sqlCom.Parameters.Add(Simcard_received);

            SqlParameter Welcome_Kit_Delivered = new SqlParameter();
            Welcome_Kit_Delivered.SqlDbType = SqlDbType.VarChar;
            Welcome_Kit_Delivered.ParameterName = "@Welcome_Kit_Delivered";
            Welcome_Kit_Delivered.Value = txtwelcomeKitDelivered.Text.Trim();
            sqlCom.Parameters.Add(Welcome_Kit_Delivered);

            SqlParameter Bill_Plan_confirmed = new SqlParameter();
            Bill_Plan_confirmed.SqlDbType = SqlDbType.VarChar;
            Bill_Plan_confirmed.ParameterName = "@Bill_Plan_confirmed";
            Bill_Plan_confirmed.Value = txtBillPlanConfirmed.Text.Trim();
            sqlCom.Parameters.Add(Bill_Plan_confirmed);

            SqlParameter First_Bill_explanation = new SqlParameter();
            First_Bill_explanation.SqlDbType = SqlDbType.VarChar;
            First_Bill_explanation.ParameterName = "@First_Bill_explanation";
            First_Bill_explanation.Value = txtFirstBillExplanation.Text.Trim();
            sqlCom.Parameters.Add(First_Bill_explanation);

            SqlParameter Payment_Options = new SqlParameter();
            Payment_Options.SqlDbType = SqlDbType.VarChar;
            Payment_Options.ParameterName = "@Payment_Options";
            Payment_Options.Value = txtpaymentOptions.Text.Trim();
            sqlCom.Parameters.Add(Payment_Options);

            SqlParameter Standing_Instructions = new SqlParameter();
            Standing_Instructions.SqlDbType = SqlDbType.VarChar;
            Standing_Instructions.ParameterName = "@Standing_Instructions";
            Standing_Instructions.Value = txtStandingInstructions.Text.Trim();
            sqlCom.Parameters.Add(Standing_Instructions);

            SqlParameter ECS = new SqlParameter();
            ECS.SqlDbType = SqlDbType.VarChar;
            ECS.ParameterName = "@ECS";
            ECS.Value = txtECS.Text.Trim();
            sqlCom.Parameters.Add(ECS);

            SqlParameter EBill = new SqlParameter();
            EBill.SqlDbType = SqlDbType.VarChar;
            EBill.ParameterName = "@EBill";
            EBill.Value = txtEBill.Text.Trim();
            sqlCom.Parameters.Add(EBill);

            SqlParameter Photograph_identified = new SqlParameter();
            Photograph_identified.SqlDbType = SqlDbType.VarChar;
            Photograph_identified.ParameterName = "@Photograph_identified";
            Photograph_identified.Value = txtPhotographIdentified.Text.Trim();
            sqlCom.Parameters.Add(Photograph_identified);

            SqlParameter Billing_address_is_owned_Rented = new SqlParameter();
            Billing_address_is_owned_Rented.SqlDbType = SqlDbType.VarChar;
            Billing_address_is_owned_Rented.ParameterName = "@Billing_address_is_owned_Rented";
            Billing_address_is_owned_Rented.Value = txtBillingAddress.Text.Trim();
            sqlCom.Parameters.Add(Billing_address_is_owned_Rented);

            SqlParameter Locality = new SqlParameter();
            Locality.SqlDbType = SqlDbType.VarChar;
            Locality.ParameterName = "@Locality";
            Locality.Value = ddlLocality.Text.Trim();
            sqlCom.Parameters.Add(Locality);

            SqlParameter Business_stock_seen = new SqlParameter();
            Business_stock_seen.SqlDbType = SqlDbType.VarChar;
            Business_stock_seen.ParameterName = "@Business_stock_seen";
            Business_stock_seen.Value = ddlBusinessStockSeen.Text.Trim();
            sqlCom.Parameters.Add(Business_stock_seen);

            SqlParameter Type_of_Job_Emp = new SqlParameter();
            Type_of_Job_Emp.SqlDbType = SqlDbType.VarChar;
            Type_of_Job_Emp.ParameterName = "@Type_of_Job_emp";
            Type_of_Job_Emp.Value = ddlTypeOfJob.Text.Trim();
            sqlCom.Parameters.Add(Type_of_Job_Emp);

            SqlParameter Reason_for_applicant_not_met = new SqlParameter();
            Reason_for_applicant_not_met.SqlDbType = SqlDbType.VarChar;
            Reason_for_applicant_not_met.ParameterName = "@Reason_for_applicant_not_met";
            Reason_for_applicant_not_met.Value = txtReasonforapplicantnotmet.Text.Trim();
            sqlCom.Parameters.Add(Reason_for_applicant_not_met);

            SqlParameter Any_other_business_in_same_city_another_city = new SqlParameter();
            Any_other_business_in_same_city_another_city.SqlDbType = SqlDbType.VarChar;
            Any_other_business_in_same_city_another_city.ParameterName = "@Any_other_business_in_same_city_another_city";
            Any_other_business_in_same_city_another_city.Value = txtAnyotherbusinessinsamecity.Text.Trim();
            sqlCom.Parameters.Add(Any_other_business_in_same_city_another_city);

            SqlParameter Payment_responsibility = new SqlParameter();
            Payment_responsibility.SqlDbType = SqlDbType.VarChar;
            Payment_responsibility.ParameterName = "@Payment_responsibility";
            Payment_responsibility.Value = txtPaymentresponsibility.Text.Trim();
            sqlCom.Parameters.Add(Payment_responsibility);

            SqlParameter Previous_number = new SqlParameter();
            Previous_number.SqlDbType = SqlDbType.VarChar;
            Previous_number.ParameterName = "@Previous_number";
            Previous_number.Value = txtPreviousNumber.Text.Trim();
            sqlCom.Parameters.Add(Previous_number);

            SqlParameter Billing_Average = new SqlParameter();
            Billing_Average.SqlDbType = SqlDbType.VarChar;
            Billing_Average.ParameterName = "@Billing_Average";
            Billing_Average.Value = txtBillingAverage.Text.Trim();
            sqlCom.Parameters.Add(Billing_Average);

            SqlParameter Recommended_number_of_connections_by_Field_Executive = new SqlParameter();
            Recommended_number_of_connections_by_Field_Executive.SqlDbType = SqlDbType.VarChar;
            Recommended_number_of_connections_by_Field_Executive.ParameterName = "@Recommended_number_of_connections_by_Field_Executive";
            Recommended_number_of_connections_by_Field_Executive.Value = txtRecomNumByFE.Text.Trim();
            sqlCom.Parameters.Add(Recommended_number_of_connections_by_Field_Executive);

            SqlParameter Vodafone_mobile_used_by_Self = new SqlParameter();
            Vodafone_mobile_used_by_Self.SqlDbType = SqlDbType.VarChar;
            Vodafone_mobile_used_by_Self.ParameterName = "@Vodafone_mobile_used_by_Self";
            Vodafone_mobile_used_by_Self.Value = txtVodafoneMobileUsedBySelf.Text.Trim();
            sqlCom.Parameters.Add(Vodafone_mobile_used_by_Self);

            SqlParameter No_of_connections_required = new SqlParameter();
            No_of_connections_required.SqlDbType = SqlDbType.VarChar;
            No_of_connections_required.ParameterName = "No_of_connections_required";
            No_of_connections_required.Value = txtNoOfConnections.Text.Trim();
            sqlCom.Parameters.Add(No_of_connections_required);

            SqlParameter COCP_IOIP_Connections = new SqlParameter();
            COCP_IOIP_Connections.SqlDbType = SqlDbType.VarChar;
            COCP_IOIP_Connections.ParameterName = "@COCP_IOIP_Connections";
            COCP_IOIP_Connections.Value = txtCOCP.Text.Trim();
            sqlCom.Parameters.Add(COCP_IOIP_Connections);

            SqlParameter Attempt_date_time = new SqlParameter();
            Attempt_date_time.SqlDbType = SqlDbType.VarChar;
            Attempt_date_time.ParameterName = "@Attempt_DateTime";
            Attempt_date_time.Value = txtDateTime.Text.Trim() + " " + txttime.Text.Trim() + " " + ddldatetime.Text.Trim();
            sqlCom.Parameters.Add(Attempt_date_time);

            SqlParameter FE_Response = new SqlParameter();
            FE_Response.SqlDbType = SqlDbType.VarChar;
            FE_Response.ParameterName = "@FE_Response";
            FE_Response.Value = "";//txtFERemark.Text.Trim();
            sqlCom.Parameters.Add(FE_Response);

            SqlParameter FE_Remark = new SqlParameter();
            FE_Remark.SqlDbType = SqlDbType.VarChar;
            FE_Remark.ParameterName = "@FE_Remark";
            FE_Remark.Value = txtFERemark.Text.Trim();
            sqlCom.Parameters.Add(FE_Remark);


            int intRow = sqlCom.ExecuteNonQuery();
            sqlCon.Close();

            if (intRow > 0)
            {
                lblmessage.CssClass = "UpdateMessage";
                lblmessage.Text = "Record Successfully Updated!";
                lblmessage.Visible = true;
            }
        }
        catch (Exception Ex)
        {
            lblmessage.CssClass = "ErrorMessage";
            lblmessage.Text = Ex.Message;
            lblmessage.Visible = true;
        }
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {

    }
    protected void lnkCellularVerificationEntry_Click(object sender, EventArgs e)
    {
        try
        { 
            
           string sCaseId = txtcaseid.Text.Trim();
            Response.Redirect("CEL_Cellular_Verification_Entry.aspx?CaseID=" + sCaseId,false);

        }
        catch (Exception Ex)
        {
            lblmessage.CssClass = "ErrorMessage";
            lblmessage.Text = Ex.Message;
            lblmessage.Visible = true;
        }
         
    }
  }