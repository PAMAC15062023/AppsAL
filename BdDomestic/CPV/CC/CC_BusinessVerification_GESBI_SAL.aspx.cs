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

public partial class CC_BusinessVerification_GESBI_SAL : System.Web.UI.Page
{
    CGet objCGet = new CGet();
    CCreditCardVerification objCCVer = new CCreditCardVerification();
    CCreditCardTelephonicVerification objRVT = new CCreditCardTelephonicVerification();
    DataSet dsAttempt = new DataSet();
    private CCreditCard objCC = new CCreditCard();
    protected void Page_Load(object sender, EventArgs e)
    {
        lblMsg.Text = "";
         try
            {
                if (!IsPostBack)
                {
                    if (Context.Request.QueryString["CaseID"] != null && Context.Request.QueryString["CaseID"] != "" && Context.Request.QueryString["VerTypeId"] != null && Context.Request.QueryString["VerTypeId"] != "")
                    {
                        txtCaseId.Text = Context.Request.QueryString["CaseID"];
                        hidVerifierID.Value = Context.Request.QueryString["VerTypeId"];
                        if (Context.Request.QueryString["Type"] == "S")
                        {
                            lblType.Text = "Salaried";
                            Panel1.Visible = false;
                        }
                        else
                        {
                            lblType.Text = "Self Employed";
                            Panel1.Visible = true;
                           
                        }
                        Get_BVSALARIED_Details(txtCaseId.Text.Trim(), Convert.ToInt32(Session["ClientId"]));

                        FillSupervisorName();
                    }



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
                        string StrScript = "<script language='javascript'> javascript:Page_load_validation(); </script>";
                        Page.RegisterStartupScript("OnLoad_21", StrScript);
              
                    }

                }
               
               
            }
            catch (Exception Ex)
            {
                lblMsg.Text = Ex.Message;
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
                    lblMsg.Visible = true;
                    lblMsg.ForeColor = System.Drawing.Color.Red;
                    lblMsg.Text = "Enter date in first attempt.";
                    txtAttemptDate1.Focus();
                }
               
            }
            if (ddlVerifierRemarks1.Text.Trim() != "" && IsValid == true)
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
                if (ddlVerifierRemarks1.Text.Length > 500)
                {
                    IsValid = false;
                    lblMsg.Visible = true;
                    lblMsg.ForeColor = System.Drawing.Color.Red;
                    lblMsg.Text = "Remark should not be greater than 255 characters in first attempt.";
                    ddlVerifierRemarks1.Focus();
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
               
            }

            if (ddlVerifierRemarks2.Text != "" && IsValid == true)
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
                if (ddlVerifierRemarks2.Text.Length > 500)
                {
                    IsValid = false;
                    lblMsg.Visible = true;
                    lblMsg.ForeColor = System.Drawing.Color.Red;
                    lblMsg.Text = "Remark should not be greater than 255 characters in second attempt.";
                    ddlVerifierRemarks2.Focus();
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
             

            }

            if (ddlVerifierRemarks3.Text != "" && IsValid == true)
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
                if (ddlVerifierRemarks3.Text.Length > 500)
                {
                    IsValid = false;
                    lblMsg.Visible = true;
                    lblMsg.ForeColor = System.Drawing.Color.Red;
                    lblMsg.Text = "Remark should not be greater than 255 characters in third attempt.";
                    ddlVerifierRemarks3.Focus();
                }
            }


            if (txtAttemptTime1.Text.Trim() == "" && txtAttemptTime2.Text.Trim() == "" && txtAttemptTime3.Text.Trim() == "")
            {

            }

        }
        catch (Exception ex)
        {
            lblMsg.Text = ex.Message;
        }
        return IsValid;
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
    private void Insert_BVSalaried_Details_For_GESBI()
    {
        try
        {
            SqlConnection sqlCon = new SqlConnection(ConfigurationManager.AppSettings["constring"]);

            sqlCon.Open();
            SqlCommand sqlCom = new SqlCommand();
            sqlCom.Connection = sqlCon;
            sqlCom.CommandType = CommandType.StoredProcedure;
            sqlCom.CommandText = "Insert_BVDetails_GESBI_Sal";
            sqlCom.CommandTimeout = 0;

            SqlParameter Case_Id = new SqlParameter();
            Case_Id.SqlDbType = SqlDbType.VarChar;
            Case_Id.ParameterName = "@Case_Id";
            Case_Id.Value = txtCaseId.Text.Trim();
            sqlCom.Parameters.Add(Case_Id);

            SqlParameter Verification_Id = new SqlParameter();
            Verification_Id.SqlDbType = SqlDbType.VarChar;
            Verification_Id.ParameterName = "@Verification_Type_Id";
            Verification_Id.Value = hidVerifierID.Value;
            sqlCom.Parameters.Add(Verification_Id);


            SqlParameter Application_Number = new SqlParameter();
            Application_Number.SqlDbType = SqlDbType.VarChar;
            Application_Number.ParameterName = "@Application_Numer";
            Application_Number.Value = txtApplicationNo.Text.Trim();
            sqlCom.Parameters.Add(Application_Number);

            SqlParameter Address_Confirmed = new SqlParameter();
            Address_Confirmed.SqlDbType = SqlDbType.VarChar;
            Address_Confirmed.ParameterName = "@Address_Confirmed";
            Address_Confirmed.Value = ddlAddressConfirm.Text.Trim();
            sqlCom.Parameters.Add(Address_Confirmed);

           
            SqlParameter Person_Met = new SqlParameter();
            Person_Met.SqlDbType = SqlDbType.VarChar;
            Person_Met.ParameterName = "@Person_Met";
            Person_Met.Value = txtNameOfPersonMet.Text.Trim();
            sqlCom.Parameters.Add(Person_Met);

            SqlParameter Designation_Of_Person_Met = new SqlParameter();
            Designation_Of_Person_Met.SqlDbType = SqlDbType.VarChar;
            Designation_Of_Person_Met.ParameterName = "@Designation_Of_Person_Met";
            Designation_Of_Person_Met.Value = txtDesignationofPerMet.Text.Trim();
            sqlCom.Parameters.Add(Designation_Of_Person_Met);

 

            SqlParameter Relationship = new SqlParameter();
            Relationship.SqlDbType = SqlDbType.VarChar;
            Relationship.ParameterName = "@Relationship_with_Applicant";
            Relationship.Value = txtrelationwithapplicant.Text.Trim(); 
            sqlCom.Parameters.Add(Relationship);

            
          
            SqlParameter App_Designation = new SqlParameter();
            App_Designation.SqlDbType = SqlDbType.VarChar;
            App_Designation.ParameterName = "@App_Designation";
            App_Designation.Value = txtdesignationofapplicant.Text.Trim();
            sqlCom.Parameters.Add(App_Designation);



            SqlParameter Department = new SqlParameter();
            Department.SqlDbType = SqlDbType.VarChar;
            Department.ParameterName = "@Department";
            Department.Value = txtdesignationofapplicant.Text.Trim();
            sqlCom.Parameters.Add(Department);
         
            SqlParameter Name_of_Business = new SqlParameter();
            Name_of_Business.SqlDbType = SqlDbType.VarChar;
            Name_of_Business.ParameterName = "@Name_Of_Business";
            Name_of_Business.Value = txtNameofBusiness.Text.Trim();
            sqlCom.Parameters.Add(Name_of_Business);


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
              
            SqlParameter DOB = new SqlParameter();
            DOB.SqlDbType = SqlDbType.VarChar;
            DOB.ParameterName = "@Approx_Age_Applicant_DOB";
            //DOB.Value = txtApplicantAge_DOB.Text.Trim();
            DOB.Value = strApplicantAge;
            sqlCom.Parameters.Add(DOB);

            SqlParameter Employer_Address = new SqlParameter();
            Employer_Address.SqlDbType = SqlDbType.VarChar;
            Employer_Address.ParameterName = "@Employer_Address";
            Employer_Address.Value = txtEmployerAddress.Text.Trim();
            sqlCom.Parameters.Add(Employer_Address);

            SqlParameter Telephone_No_Office = new SqlParameter();
            Telephone_No_Office.SqlDbType = SqlDbType.VarChar;
            Telephone_No_Office.ParameterName = "@Telephone_No_Office";
            Telephone_No_Office.Value = txtTelephoneNo.Text.Trim();
            sqlCom.Parameters.Add(Telephone_No_Office);

            SqlParameter Ext = new SqlParameter();
            Ext.SqlDbType = SqlDbType.VarChar;
            Ext.ParameterName = "@Extension";
            Ext.Value = txtExtension.Text.Trim();
            sqlCom.Parameters.Add(Ext);

            SqlParameter Residence = new SqlParameter();
            Residence.SqlDbType = SqlDbType.VarChar;
            Residence.ParameterName = "@Telephone_No_Residence";
            Residence.Value = txtResidence.Text.Trim();
            sqlCom.Parameters.Add(Residence);


            SqlParameter Office_Address = new SqlParameter();
            Office_Address.SqlDbType = SqlDbType.VarChar;
            Office_Address.ParameterName = "@Office_Address";
            Office_Address.Value = txtOfficeAddress.Text.Trim();
            sqlCom.Parameters.Add(Office_Address);

            string strYCE = "";
            if (chk_YCE.Checked == true)
            {
                strYCE = chk_YCE.Text.Trim();
            }
            else
            {

                strYCE = txtYearinEmployment.Text.Trim() + ":" + txtMonth.Text.Trim();

            }
             
            SqlParameter Yrs_in_Current_Employement = new SqlParameter();
            Yrs_in_Current_Employement.SqlDbType = SqlDbType.VarChar;
            Yrs_in_Current_Employement.ParameterName = "@Year_in_Current_Employement";
            Yrs_in_Current_Employement.Value = strYCE; //txtYearinEmployment.Text.Trim() + ":" + txtMonth.Text.Trim();
            sqlCom.Parameters.Add(Yrs_in_Current_Employement);

            SqlParameter Type_of_company = new SqlParameter();
            Type_of_company.SqlDbType = SqlDbType.VarChar;
            Type_of_company.ParameterName = "@Type_of_Company";
            Type_of_company.Value = ddlTypeofCompany.Text.Trim();
            sqlCom.Parameters.Add(Type_of_company);

            SqlParameter Nature_of_Business = new SqlParameter();
            Nature_of_Business.SqlDbType = SqlDbType.VarChar;
            Nature_of_Business.ParameterName = "@Nature_of_Business";
            Nature_of_Business.Value = ddlNature_of_Business.Text.Trim();
            sqlCom.Parameters.Add(Nature_of_Business);

            SqlParameter Business_Description = new SqlParameter();
            Business_Description.SqlDbType = SqlDbType.VarChar;
            Business_Description.ParameterName = "@Business_Description";
            Business_Description.Value = txtBusinessDescription.Text.Trim();
            sqlCom.Parameters.Add(Business_Description);

            SqlParameter No_Of_Employees = new SqlParameter();
            No_Of_Employees.SqlDbType = SqlDbType.VarChar;
            No_Of_Employees.ParameterName = "@No_of_Employees";
            No_Of_Employees.Value = txtNoOfEmployees.Text.Trim();
            sqlCom.Parameters.Add(No_Of_Employees);

            SqlParameter Branches = new SqlParameter();
            Branches.SqlDbType = SqlDbType.VarChar;
            Branches.ParameterName = "@Branches";
            Branches.Value = ""; //txtbranches.Text.Trim();
            sqlCom.Parameters.Add(Branches);

            SqlParameter If_the_Applicant_is_Full_time_Employee = new SqlParameter();
            If_the_Applicant_is_Full_time_Employee.SqlDbType = SqlDbType.VarChar;
            If_the_Applicant_is_Full_time_Employee.ParameterName = "@If_the_Applicant_is_Full_time_Employee";
            If_the_Applicant_is_Full_time_Employee.Value = ddlAppFullTimeEmployee.Text.Trim();// ddlAppFullTimeEmployee.Text.Trim();
            sqlCom.Parameters.Add(If_the_Applicant_is_Full_time_Employee);

            SqlParameter Information_Refused = new SqlParameter();
            Information_Refused.SqlDbType = SqlDbType.VarChar;
            Information_Refused.ParameterName = "@Information_Refused";
            Information_Refused.Value = ddlInformationProvided.Text.Trim();
            sqlCom.Parameters.Add(Information_Refused);

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
         
            
            SqlParameter TPC1_Applicant_Name = new SqlParameter();
            TPC1_Applicant_Name.SqlDbType = SqlDbType.VarChar;
            TPC1_Applicant_Name.ParameterName = "@TPC1_Applicant_Name";
            TPC1_Applicant_Name.Value = txtTPC1_ApplicantName.Text.Trim();
            sqlCom.Parameters.Add(TPC1_Applicant_Name);

            string str_TPC1AppAge;
            if (chk_TPC1_age.Checked == true)
            {
                str_TPC1AppAge = chk_TPC1_age.Text.Trim();
            }
            else
            {

                str_TPC1AppAge = txtTPC1_AgeYear.Text.Trim() + ":" + txtTPC1_AgeMonth.Text.Trim();

            }

            SqlParameter TPC1_Applicant_Age = new SqlParameter();
            TPC1_Applicant_Age.SqlDbType = SqlDbType.VarChar;
            TPC1_Applicant_Age.ParameterName = "@TPC1_Applicant_Age";         
            //TPC1_Applicant_Age.Value = txtTPC1_AgeYear.Text.Trim() + ":" + txtTPC1_AgeMonth.Text.Trim();
            TPC1_Applicant_Age.Value = str_TPC1AppAge;
            sqlCom.Parameters.Add(TPC1_Applicant_Age);

             

            SqlParameter TPC1_Employment = new SqlParameter();
            TPC1_Employment.SqlDbType = SqlDbType.VarChar;
            TPC1_Employment.ParameterName = "@TPC1_Employment";
            TPC1_Employment.Value = ddlTPC1_Employment.Text.Trim();            
            sqlCom.Parameters.Add(TPC1_Employment);
                      
            SqlParameter TPC1_Designation_of_Applicant = new SqlParameter();
            TPC1_Designation_of_Applicant.SqlDbType = SqlDbType.VarChar;
            TPC1_Designation_of_Applicant.ParameterName = "@TPC1_Designation_of_Applicant";           
            TPC1_Designation_of_Applicant.Value =txtTPC1_designationOfApp.Text.Trim();          
            sqlCom.Parameters.Add(TPC1_Designation_of_Applicant);

            string str_TPC1_App_YCR;
            if (chk_TPC1AppYCE.Checked == true)
            {
                str_TPC1_App_YCR = chk_TPC1AppYCE.Text.Trim();
            }
            else
            {

                str_TPC1_App_YCR = txtTPC1_Year.Text.Trim() + ":" + txtTPC1_Month.Text.Trim();

            }

            SqlParameter TPC1_App_YCR = new SqlParameter();
            TPC1_App_YCR.SqlDbType = SqlDbType.VarChar;
            TPC1_App_YCR.ParameterName = "@TPC1_App_YCR";             
            //TPC1_App_YCR.Value = txtTPC1_Year.Text.Trim() + ":" + txtTPC1_Month.Text.Trim();
            TPC1_App_YCR.Value = str_TPC1_App_YCR;
            sqlCom.Parameters.Add(TPC1_App_YCR);

            SqlParameter TPC1_Telephone_No_Office = new SqlParameter();
            TPC1_Telephone_No_Office.SqlDbType = SqlDbType.VarChar;
            TPC1_Telephone_No_Office.ParameterName = "@TPC1_Telephone_No_Office";
            TPC1_Telephone_No_Office.Value = "";/////txtTelephoneNoOffice.Text.Trim();
            sqlCom.Parameters.Add(TPC1_Telephone_No_Office);

            SqlParameter TPC1_Extension_No = new SqlParameter();
            TPC1_Extension_No.SqlDbType = SqlDbType.VarChar;
            TPC1_Extension_No.ParameterName = "@TPC1_Extension_No";
            TPC1_Extension_No.Value = "";//////txtExtensionNo.Text.Trim();
            sqlCom.Parameters.Add(TPC1_Extension_No);

            SqlParameter TPC1_Type_of_Company = new SqlParameter();
            TPC1_Type_of_Company.SqlDbType = SqlDbType.VarChar;
            TPC1_Type_of_Company.ParameterName = "@TPC1_Type_of_Company";
            TPC1_Type_of_Company.Value = ddl_TCP_TypeofCompany.Text.Trim();
            sqlCom.Parameters.Add(TPC1_Type_of_Company);

            SqlParameter TPC1_Nature_of_Business = new SqlParameter();
            TPC1_Nature_of_Business.SqlDbType = SqlDbType.VarChar;
            TPC1_Nature_of_Business.ParameterName = "@TPC1_Nature_of_Business";
            TPC1_Nature_of_Business.Value = ddl_TCP_NatureOfBusiness.Text.Trim();
            sqlCom.Parameters.Add(TPC1_Nature_of_Business);

            SqlParameter Reason_for_the_address_not_confirmed = new SqlParameter();
            Reason_for_the_address_not_confirmed.SqlDbType = SqlDbType.VarChar;
            Reason_for_the_address_not_confirmed.ParameterName = "@Reason_for_the_address_not_confirmed";
            Reason_for_the_address_not_confirmed.Value = ddl_ReasonAddNotConf.Text.Trim();
            sqlCom.Parameters.Add(Reason_for_the_address_not_confirmed);

            SqlParameter Locality = new SqlParameter();
            Locality.SqlDbType = SqlDbType.VarChar;
            Locality.ParameterName = "@Locality";
            Locality.Value = "";///ddlAddLocality.Text.Trim();
            sqlCom.Parameters.Add(Locality);


            SqlParameter Result_of_Calling = new SqlParameter();
            Result_of_Calling.SqlDbType = SqlDbType.VarChar;
            Result_of_Calling.ParameterName = "@Result_of_Calling";
            Result_of_Calling.Value = txtResultofCalling.Text.Trim();
            sqlCom.Parameters.Add(Result_of_Calling);

            SqlParameter Mismatched_in_Residence_Address = new SqlParameter();
            Mismatched_in_Residence_Address.SqlDbType = SqlDbType.VarChar;
            Mismatched_in_Residence_Address.ParameterName = "@Mismatched_in_Residence_Address";
            Mismatched_in_Residence_Address.Value = ""; //txtMismatchinResAdd.Text.Trim();
            sqlCom.Parameters.Add(Mismatched_in_Residence_Address);

            SqlParameter Is_Applicant_Known_to_the_person = new SqlParameter();
            Is_Applicant_Known_to_the_person.SqlDbType = SqlDbType.VarChar;
            Is_Applicant_Known_to_the_person.ParameterName = "@Is_Applicant_Known_to_the_person";
            Is_Applicant_Known_to_the_person.Value = ""; //ddlApplicantKnown.Text.Trim();
            sqlCom.Parameters.Add(Is_Applicant_Known_to_the_person);

            SqlParameter To_whom_does_the_address_belong = new SqlParameter();
            To_whom_does_the_address_belong.SqlDbType = SqlDbType.VarChar;
            To_whom_does_the_address_belong.ParameterName = "@To_whom_does_the_address_belong";
            To_whom_does_the_address_belong.Value = txtWhomaddBelong.Text.Trim();
            sqlCom.Parameters.Add(To_whom_does_the_address_belong);

            SqlParameter Company_board_Seen_Outside_the_Building_Office = new SqlParameter();
            Company_board_Seen_Outside_the_Building_Office.SqlDbType = SqlDbType.VarChar;
            Company_board_Seen_Outside_the_Building_Office.ParameterName = "@Company_board_Seen_Outside_the_Building_Office";
            Company_board_Seen_Outside_the_Building_Office.Value = ddlCompanyboardSeen.Text.Trim();
            sqlCom.Parameters.Add(Company_board_Seen_Outside_the_Building_Office);


            SqlParameter Applicant_Name_Confirmed_with = new SqlParameter();
            Applicant_Name_Confirmed_with.SqlDbType = SqlDbType.VarChar;
            Applicant_Name_Confirmed_with.ParameterName = "@Applicant_Name_Confirmed_with";
            Applicant_Name_Confirmed_with.Value =ddlApplicantConfirmedwith.Text.Trim();
            sqlCom.Parameters.Add(Applicant_Name_Confirmed_with);

            SqlParameter Applicant_Met_At = new SqlParameter();
            Applicant_Met_At.SqlDbType = SqlDbType.VarChar;
            Applicant_Met_At.ParameterName = "@Applicant_Met_At";
            Applicant_Met_At.Value = ""; //ddlApplicantMetAt.Text.Trim();
            sqlCom.Parameters.Add(Applicant_Met_At);

            SqlParameter Ease_Of_Location_Office = new SqlParameter();
            Ease_Of_Location_Office.SqlDbType = SqlDbType.VarChar;
            Ease_Of_Location_Office.ParameterName = "@Ease_Of_Location_Office";
            Ease_Of_Location_Office.Value = ddlEaseOfLocationOffice.Text.Trim();
            sqlCom.Parameters.Add(Ease_Of_Location_Office);

            SqlParameter Type_Office_Locality = new SqlParameter();
            Type_Office_Locality.SqlDbType = SqlDbType.VarChar;
            Type_Office_Locality.ParameterName = "@Type_Office_Locality";
            Type_Office_Locality.Value =ddlTypeOfficeLocality.Text.Trim();
            sqlCom.Parameters.Add(Type_Office_Locality);

            SqlParameter Office_Status = new SqlParameter();
            Office_Status.SqlDbType = SqlDbType.VarChar;
            Office_Status.ParameterName = "@Office_Status";
            Office_Status.Value = ddl_OfficeStatus.Text.Trim();
            sqlCom.Parameters.Add(Office_Status);

            SqlParameter LandMark = new SqlParameter();
            LandMark.SqlDbType = SqlDbType.VarChar;
            LandMark.ParameterName = "@LandMark";
            LandMark.Value = txtLandmark.Text.Trim();
            sqlCom.Parameters.Add(LandMark);

            SqlParameter Office_Area = new SqlParameter();
            Office_Area.SqlDbType = SqlDbType.VarChar;
            Office_Area.ParameterName = "@Office_Area";
            Office_Area.Value = ddlAreaOfOffice.Text.Trim();
            sqlCom.Parameters.Add(Office_Area);

            SqlParameter Type_Of_Proof = new SqlParameter();
            Type_Of_Proof.SqlDbType = SqlDbType.VarChar;
            Type_Of_Proof.ParameterName = "@Type_Of_Proof";
            Type_Of_Proof.Value = ddlTypeOfProof.Text.Trim();
            sqlCom.Parameters.Add(Type_Of_Proof);


            SqlParameter Area_type = new SqlParameter();
            Area_type.SqlDbType = SqlDbType.VarChar;
            Area_type.ParameterName = "@Area_type";
            Area_type.Value = ""; //ddlAreaType.Text.Trim();
            sqlCom.Parameters.Add(Area_type);

            SqlParameter Attempt_Details = new SqlParameter();
            Attempt_Details.SqlDbType = SqlDbType.VarChar;
            Attempt_Details.ParameterName = "@Attempt_Details";
            Attempt_Details.Value = Get_Attempt_details();
            sqlCom.Parameters.Add(Attempt_Details);

            SqlParameter Verifier_Name = new SqlParameter();
            Verifier_Name.SqlDbType = SqlDbType.VarChar;
            Verifier_Name.ParameterName = "@Verifier_Name";
            Verifier_Name.Value = txtVerifierName.Text.Trim();
            sqlCom.Parameters.Add(Verifier_Name);


            SqlParameter Verification_Conducted_At = new SqlParameter();
            Verification_Conducted_At.SqlDbType = SqlDbType.VarChar;
            Verification_Conducted_At.ParameterName = "@Verification_Conducted_At";
            Verification_Conducted_At.Value = ddlVerification_conductedAt.Text.Trim();
            sqlCom.Parameters.Add(Verification_Conducted_At);


            SqlParameter Address_Confirmed2 = new SqlParameter();
            Address_Confirmed2.SqlDbType = SqlDbType.VarChar;
            Address_Confirmed2.ParameterName = "@Address_Confirmed2";
            Address_Confirmed2.Value = "";//ddlAddressConfirmed.Text.Trim();
            sqlCom.Parameters.Add(Address_Confirmed2);

            SqlParameter Entry_permitted = new SqlParameter();
            Entry_permitted.SqlDbType = SqlDbType.VarChar;
            Entry_permitted.ParameterName = "@Entry_permitted";
            Entry_permitted.Value = ddlEntryPermitted.Text.Trim();
            sqlCom.Parameters.Add(Entry_permitted);

            SqlParameter Activity_Seen = new SqlParameter();
            Activity_Seen.SqlDbType = SqlDbType.VarChar;
            Activity_Seen.ParameterName = "@Activity_Seen";
            Activity_Seen.Value = ddlActivitySeen.Text.Trim();
            sqlCom.Parameters.Add(Activity_Seen);

            SqlParameter Stock_Seen = new SqlParameter();
            Stock_Seen.SqlDbType = SqlDbType.VarChar;
            Stock_Seen.ParameterName = "@Stock_Seen";
            Stock_Seen.Value = ddlStockSeen.Text.Trim();
            sqlCom.Parameters.Add(Stock_Seen);

            SqlParameter Office_Set_Up_Seen = new SqlParameter();
            Office_Set_Up_Seen.SqlDbType = SqlDbType.VarChar;
            Office_Set_Up_Seen.ParameterName = "@Office_Set_Up_Seen";
            Office_Set_Up_Seen.Value = ddlOfficesetupseen.Text.Trim();
            sqlCom.Parameters.Add(Office_Set_Up_Seen);

            SqlParameter Verifier_Remarks = new SqlParameter();
            Verifier_Remarks.SqlDbType = SqlDbType.VarChar;
            Verifier_Remarks.ParameterName = "@Verifier_Remarks";
            Verifier_Remarks.Value = txtVerifierRemark.Text.Trim();
            sqlCom.Parameters.Add(Verifier_Remarks);


            SqlParameter Address_Updation = new SqlParameter();
            Address_Updation.SqlDbType = SqlDbType.VarChar;
            Address_Updation.ParameterName = "@Address_Updation";
            Address_Updation.Value = ddlAddressUpdation.Text.Trim();
            sqlCom.Parameters.Add(Address_Updation);


            SqlParameter Correct_Address = new SqlParameter();
            Correct_Address.SqlDbType = SqlDbType.VarChar;
            Correct_Address.ParameterName = "@Correct_Address";
            Correct_Address.Value = txtCorrectAddress.Text.Trim();
            sqlCom.Parameters.Add(Correct_Address);

            SqlParameter Directory_Checked = new SqlParameter();
            Directory_Checked.SqlDbType = SqlDbType.VarChar;
            Directory_Checked.ParameterName = "@Directory_Checked";
            Directory_Checked.Value = ddlDirectoryChecked.Text.Trim();
            sqlCom.Parameters.Add(Directory_Checked);

            SqlParameter Supervisor_Name = new SqlParameter();
            Supervisor_Name.SqlDbType = SqlDbType.VarChar;
            Supervisor_Name.ParameterName = "@Supervisor_Name";
            Supervisor_Name.Value = ddlSupervisorName.SelectedItem.Value.Trim();
            sqlCom.Parameters.Add(Supervisor_Name);

            SqlParameter SuperVisor_Remark = new SqlParameter();
            SuperVisor_Remark.SqlDbType = SqlDbType.VarChar;
            SuperVisor_Remark.ParameterName = "@SuperVisor_Remark";
            SuperVisor_Remark.Value = txtSuperVisorRemark.Text.Trim();
            sqlCom.Parameters.Add(SuperVisor_Remark);


            SqlParameter Proprietor_recommendation = new SqlParameter();
            Proprietor_recommendation.SqlDbType = SqlDbType.VarChar;
            Proprietor_recommendation.ParameterName = "@Proprietor_recommendation";
            Proprietor_recommendation.Value = ddlProprietorRecomm.Text.Trim();
            sqlCom.Parameters.Add(Proprietor_recommendation);



            SqlParameter Decline_Code = new SqlParameter();
            Decline_Code.SqlDbType = SqlDbType.VarChar;
            Decline_Code.ParameterName = "@Decline_Code";
            Decline_Code.Value = "";/////txtDeclineCode.Text.Trim();
            sqlCom.Parameters.Add(Decline_Code);

            SqlParameter Auth_Signature = new SqlParameter();
            Auth_Signature.SqlDbType = SqlDbType.VarChar;
            Auth_Signature.ParameterName = "@Auth_Signature";
            Auth_Signature.Value = "";/////txtAuthSign.Text.Trim();
            sqlCom.Parameters.Add(Auth_Signature);


            SqlParameter Designation_of_Applicant_Confirm = new SqlParameter();
            Designation_of_Applicant_Confirm.SqlDbType = SqlDbType.VarChar;
            Designation_of_Applicant_Confirm.ParameterName = "@Designation_of_Applicant_Confirm";
            Designation_of_Applicant_Confirm.Value = ddldesignationofApplicant.Text.Trim();
            sqlCom.Parameters.Add(Designation_of_Applicant_Confirm);

            SqlParameter Relation_with_Applicant_Confirm = new SqlParameter();
            Relation_with_Applicant_Confirm.SqlDbType = SqlDbType.VarChar;
            Relation_with_Applicant_Confirm.ParameterName = "@Relation_with_Applicant_Confirm";
            Relation_with_Applicant_Confirm.Value = ddlrelationwithapplicant.Text.Trim();
            sqlCom.Parameters.Add(Relation_with_Applicant_Confirm);

            SqlParameter Department_of_Applicant_Confirm = new SqlParameter();
            Department_of_Applicant_Confirm.SqlDbType = SqlDbType.VarChar;
            Department_of_Applicant_Confirm.ParameterName = "@Department_of_Applicant_Confirm";
            Department_of_Applicant_Confirm.Value = ddldepartmentofApplicant.Text.Trim();
            sqlCom.Parameters.Add(Department_of_Applicant_Confirm);

            SqlParameter CompanyName_Confirm = new SqlParameter();
            CompanyName_Confirm.SqlDbType = SqlDbType.VarChar;
            CompanyName_Confirm.ParameterName = "@CompanyName_Confirm";
            CompanyName_Confirm.Value = ddlCompanyName.Text.Trim();
            sqlCom.Parameters.Add(CompanyName_Confirm);

            SqlParameter EmailId = new SqlParameter();
            EmailId.SqlDbType = SqlDbType.VarChar;
            EmailId.ParameterName = "@EmailId";
            EmailId.Value = txtEmailId.Text.Trim();
            sqlCom.Parameters.Add(EmailId);


            SqlParameter TCP1_Applicant_Name_Confirm = new SqlParameter();
            TCP1_Applicant_Name_Confirm.SqlDbType = SqlDbType.VarChar;
            TCP1_Applicant_Name_Confirm.ParameterName = "@TCP1_Name_Confirm";
            TCP1_Applicant_Name_Confirm.Value = ddlTPC1_Name.Text.Trim();
            sqlCom.Parameters.Add(TCP1_Applicant_Name_Confirm);

            SqlParameter Defaulter = new SqlParameter();
            Defaulter.SqlDbType = SqlDbType.VarChar;
            Defaulter.ParameterName = "@Defaulter";
            Defaulter.Value = txtdefaulter.Text.Trim();
            sqlCom.Parameters.Add(Defaulter);

            SqlParameter Resi_Cum_Business = new SqlParameter();
            Resi_Cum_Business.SqlDbType = SqlDbType.VarChar;
            Resi_Cum_Business.ParameterName = "@Resi_Cum_Business";
            Resi_Cum_Business.Value = ddl_ResiCumBusi.Text.Trim();
            sqlCom.Parameters.Add(Resi_Cum_Business);

            SqlParameter Seperate_Office_Area = new SqlParameter();
            Seperate_Office_Area.SqlDbType = SqlDbType.VarChar;
            Seperate_Office_Area.ParameterName = "@Seperate_Office_Area";
            Seperate_Office_Area.Value = ddlSeperateAreaSeen.Text.Trim();
            sqlCom.Parameters.Add(Seperate_Office_Area);

            SqlParameter TCP1_Designation_Of_Applicant = new SqlParameter();
            TCP1_Designation_Of_Applicant.SqlDbType = SqlDbType.VarChar;
            TCP1_Designation_Of_Applicant.ParameterName = "@TCP1_Designation_Of_Applicant";
            TCP1_Designation_Of_Applicant.Value = ddlTPC1_DesignofApplicant.Text.Trim();
            sqlCom.Parameters.Add(TCP1_Designation_Of_Applicant);

            SqlParameter Tcp1_Applicant_Name_Confirmed = new SqlParameter();
            Tcp1_Applicant_Name_Confirmed.SqlDbType = SqlDbType.VarChar;
            Tcp1_Applicant_Name_Confirmed.ParameterName = "@Tcp1_Applicant_Name_Confirmed";
            Tcp1_Applicant_Name_Confirmed.Value = ddlTcpApplicantName.Text.Trim();
            sqlCom.Parameters.Add(Tcp1_Applicant_Name_Confirmed);

            SqlParameter PersonMet_Confirmed = new SqlParameter();
            PersonMet_Confirmed.SqlDbType = SqlDbType.VarChar;
            PersonMet_Confirmed.ParameterName = "@PersonMet_Confirmed";
            PersonMet_Confirmed.Value = ddlNameOfPersonMet.Text.Trim();
            sqlCom.Parameters.Add(PersonMet_Confirmed);

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

            SqlParameter TPC2_ByWhom = new SqlParameter();
            TPC2_ByWhom.SqlDbType = SqlDbType.VarChar;
            TPC2_ByWhom.ParameterName = "@TPC2_ByWhom";
            TPC2_ByWhom.Value = ddlTPC2_ByWhom.Text.Trim();
            sqlCom.Parameters.Add(TPC2_ByWhom);

            SqlParameter TPC2_Address = new SqlParameter();
            TPC2_Address.SqlDbType = SqlDbType.VarChar;
            TPC2_Address.ParameterName = "@TPC2_Address";
            TPC2_Address.Value = txtTPC2_Address.Text.Trim();
            sqlCom.Parameters.Add(TPC2_Address);

            SqlParameter TPC2_AppName = new SqlParameter();
            TPC2_AppName.SqlDbType = SqlDbType.VarChar;
            TPC2_AppName.ParameterName = "@TPC2_AppName";
            TPC2_AppName.Value = ddlTPC2_AppName.Text.Trim();
            sqlCom.Parameters.Add(@TPC2_AppName);

            SqlParameter TPC2_AppName_Confirm = new SqlParameter();
            TPC2_AppName_Confirm.SqlDbType = SqlDbType.VarChar;
            TPC2_AppName_Confirm.ParameterName = "@TPC2_AppName_Confirm";
            TPC2_AppName_Confirm.Value = txtTPC2_AppName.Text.Trim();
            sqlCom.Parameters.Add(TPC2_AppName_Confirm);

            SqlParameter TPC2_employment = new SqlParameter();
            TPC2_employment.SqlDbType = SqlDbType.VarChar;
            TPC2_employment.ParameterName = "@TPC2_employment";
            TPC2_employment.Value = ddlTPC2_employment.Text.Trim();
            sqlCom.Parameters.Add(TPC2_employment);

            SqlParameter TPC2_Desig_App = new SqlParameter();
            TPC2_Desig_App.SqlDbType = SqlDbType.VarChar;
            TPC2_Desig_App.ParameterName = "@TPC2_Desig_App";
            TPC2_Desig_App.Value = ddl_TPC2Desig_App.Text.Trim();
            sqlCom.Parameters.Add(TPC2_Desig_App);

            SqlParameter TPC2_typeofComp = new SqlParameter();
            TPC2_typeofComp.SqlDbType = SqlDbType.VarChar;
            TPC2_typeofComp.ParameterName = "@TPC2_typeofComp";
            TPC2_typeofComp.Value = ddlTPC2_typeofComp.Text.Trim();
            sqlCom.Parameters.Add(TPC2_typeofComp);

            SqlParameter TPC2_NatureofBusi = new SqlParameter();
            TPC2_NatureofBusi.SqlDbType = SqlDbType.VarChar;
            TPC2_NatureofBusi.ParameterName = "@TPC2_NatureofBusi";
            TPC2_NatureofBusi.Value = ddlTPC2_NatureofBusi.Text.Trim();
            sqlCom.Parameters.Add(TPC2_NatureofBusi);

            string str_TPC2_Age;
            if (chkTPC2_age.Checked == true)
            {
                str_TPC2_Age = chkTPC2_age.Text.Trim();
            }
            else
            {

                str_TPC2_Age = txtTPC2_AgeYear.Text.Trim() + ":" + txtTPC2_AgeMonth.Text.Trim();

            }


            SqlParameter TPC2_Age = new SqlParameter();
            TPC2_Age.SqlDbType = SqlDbType.VarChar;
            TPC2_Age.ParameterName = "@TPC2_Age";
            TPC2_Age.Value = str_TPC2_Age;
            sqlCom.Parameters.Add(TPC2_Age);

            string str_TPC2_YCE;
            if (chk_TPC2_YCE.Checked == true)
            {
                str_TPC2_YCE = chk_TPC2_YCE.Text.Trim();
            }
            else
            {

                str_TPC2_YCE = txtTPC2_YCEYear.Text.Trim() + ":" + txtTPC2_Month.Text.Trim();

            }


            SqlParameter TPC2_YCE = new SqlParameter();
            TPC2_YCE.SqlDbType = SqlDbType.VarChar;
            TPC2_YCE.ParameterName = "@TPC2_YCE";
            TPC2_YCE.Value = str_TPC2_YCE;
            sqlCom.Parameters.Add(TPC2_YCE);


            SqlParameter OBSERVATION = new SqlParameter();
            OBSERVATION.SqlDbType = SqlDbType.VarChar;
            OBSERVATION.ParameterName = "@OBSERVATION";
            OBSERVATION.Value = txtObservation.Text.Trim() ;
            sqlCom.Parameters.Add(OBSERVATION);

            int intRow = sqlCom.ExecuteNonQuery();
            sqlCon.Close();

            if (intRow > 0)
            {
                lblMsg.CssClass = "UpdateMessage";
                lblMsg.Text = "Record Successfully Updated!";
                lblMsg.Visible = true;
            }


        }
        catch (Exception Ex)
        {
            lblMsg.CssClass = "ErrorMessage";
            lblMsg.Text = Ex.Message;
            lblMsg.Visible = true;
        }

    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {

            Insert_BVSalaried_Details_For_GESBI();
            
        }
        catch (Exception Ex)
        {
            lblMsg.CssClass = "ErrorMessage";
            lblMsg.Text = Ex.Message;
            lblMsg.Visible = true;
        }


    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
            
    }    
    private void Register_Control_for_Javascript()
    {
        try
        {
            ddlAddressConfirm.Attributes.Add("onchange", "javascript:ValidationOn_Address_Confirmed();");
            ddlApplicantConfirmedwith.Attributes.Add("onchange", "javascript:Enabled_validation_ApplicantName();");
            ddlInformationProvided.Attributes.Add("onchange", "javascript:information_Provided();");
            ddl_ReasonAddNotConf.Attributes.Add("onchange", "javascript:Address_Not_Confirmed();");
            ddlEntryPermitted.Attributes.Add("onchange", "javascript:Entry_Permitted();");
            ddlTPC1_Name.Attributes.Add("onchange", "javascript:TPC_Not_Confirmed();");
            ddlTPC2_Name.Attributes.Add("onchange", "javascript:TPC2_Not_Confirmed();");
            ddlAddressUpdation.Attributes.Add("onchange", "javascript:Enable_Validation_On_AddressUpdation();");
            ddlNameOfPersonMet.Attributes.Add("onchange", "javascript:Name_of_person_met();");
            ddlrelationwithapplicant.Attributes.Add("onchange", "javascript:Enabled_Validation_Confirmation('" + ddlrelationwithapplicant.ClientID + "'," + "'Confirmed'" + ",'" + txtrelationwithapplicant.ClientID + "');");
            ddldesignationofApplicant.Attributes.Add("onchange", "javascript:Enabled_Validation_Confirmation('" + ddldesignationofApplicant.ClientID + "'," + "'Confirmed'" + ",'" + txtdesignationofapplicant.ClientID + "');");
            ddldepartmentofApplicant.Attributes.Add("onchange", "javascript:Enabled_Validation_Confirmation('" + ddldepartmentofApplicant.ClientID + "'," + "'Confirmed'" + ",'" + txtDepartment.ClientID + "');");
            ddlCompanyName.Attributes.Add("onchange", "javascript:Enabled_Validation_Confirmation('" + ddlCompanyName.ClientID + "'," + "'Confirmed'" + ",'" + txtNameofBusiness.ClientID + "');");
            ddlTcpApplicantName.Attributes.Add("onchange", "javascript:Enabled_Validation_Confirmation('" + ddlTcpApplicantName.ClientID + "'," + "'Confirmed'" + ",'" + txtTPC1_ApplicantName.ClientID + "');");
            ddlTPC1_DesignofApplicant.Attributes.Add("onchange", "javascript:Enabled_Validation_Confirmation('" + ddlTPC1_DesignofApplicant.ClientID + "'," + "'Confirmed'" + ",'" + txtTPC1_designationOfApp.ClientID + "');");
            ddlTPC2_AppName.Attributes.Add("onchange", "javascript:Enabled_Validation_Confirmation('" + ddlTPC2_AppName.ClientID + "'," + "'Confirmed'" + ",'" + txtTPC2_AppName.ClientID + "');");
            ddl_TPC2Desig_App.Attributes.Add("onchange", "javascript:Enabled_Validation_Confirmation('" + ddl_TPC2Desig_App.ClientID + "'," + "'Confirmed'" + ",'" + txtTPC2_dsigApp.ClientID + "');");
            chkApplicant_DOBAGE_NotConf.Attributes.Add("onclick", "javascript:Enabled_Validation_YY_MM(" + chkApplicant_DOBAGE_NotConf.ClientID + ",true," + txtApplicantAge_DOB.ClientID + "," + txtApplicantAge_DOB_YY.ClientID + "," + txtApplicantAge_DOB_MM.ClientID + ");");
            chk_Exit_Company.Attributes.Add("onclick", "javascript:Enabled_Validation_YY_MM(" + chk_Exit_Company.ClientID + ",true,null," + txtNoofExistenceYear.ClientID + "," + txtNoOfExistenceMonth.ClientID + ");");
            chk_YCE.Attributes.Add("onclick", "javascript:Enabled_Validation_YY_MM(" + chk_YCE.ClientID + ",true,null," + txtYearinEmployment.ClientID + "," + txtMonth.ClientID + ");");
            chk_TPC2_YCE.Attributes.Add("onclick", "javascript:Enabled_Validation_YY_MM(" + chk_TPC2_YCE.ClientID + ",true,null," + txtTPC2_YCEYear.ClientID + "," + txtTPC2_Month.ClientID + ");");
            chk_TPC1AppYCE.Attributes.Add("onclick", "javascript:Enabled_Validation_YY_MM(" + chk_TPC1AppYCE.ClientID + ",true,null," + txtTPC1_Year.ClientID + "," + txtTPC1_Month.ClientID + ");");
            chk_TPC1_age.Attributes.Add("onclick", "javascript:Enabled_Validation_YY_MM(" + chk_TPC1_age.ClientID + ",true,null," + txtTPC1_AgeYear.ClientID + "," + txtTPC1_AgeMonth.ClientID + ");");
            chkTPC2_age.Attributes.Add("onclick", "javascript:Enabled_Validation_YY_MM(" + chkTPC2_age.ClientID + ",true,null," + txtTPC2_AgeYear.ClientID + "," + txtTPC2_AgeMonth.ClientID + ");");
            ddlProprietorRecomm.Attributes.Add("onchange", "javascript:Enable_Validation_Confirmed(" + ddlProprietorRecomm.ClientID + ",'Defaulter',false," + txtdefaulter.ClientID + ",'TextBox');");
            txtVerifierRemark.Attributes.Add("onDblclick", "javascript:Enable_validation_on_Remark_for_Salaried();");

            if (Panel1.Visible == true)
            {
                ddl_ResiCumBusi.Attributes.Add("onchange", "javascript:Enable_Validation_Confirmed(" + ddl_ResiCumBusi.ClientID + ",'Yes',false," + ddlSeperateAreaSeen.ClientID + ",'DropDown');");
            }

            if (Context.Request.QueryString["Type"] == "S")
            {
                ddlTcpApplicantName.Attributes.Add("onchange", "javascript:Enable_validation_on_TPC_ApplicantName_ForSalaried();");
                ddlTPC2_AppName.Attributes.Add("onchange", "javascript:Enable_validation_on_TPC2_ApplicantName_ForSalaried();");
            }
            else
            {
                ddlTcpApplicantName.Attributes.Add("onchange", "javascript:Enable_validation_on_TPC_ApplicantName();");
                ddlTPC2_AppName.Attributes.Add("onchange", "javascript:Enable_validation_on_TPC2_ApplicantName();");
            
            }

            btnSave.Attributes.Add("onclick", "javascript:return Enable_Validation_On_Submit();");
            txtSuperVisorRemark.Attributes.Add("onDblclick", "javascript:Enable_SupervisorAutoPopulate_Remark();");

            txtObservation.Attributes.Add("onkeypress", "javascript:CountLength();");


        }
        catch (Exception Ex)
        {
            lblMsg.CssClass = "ErrorMessage";
            lblMsg.Text = Ex.Message;
            lblMsg.Visible = true;
        }
    }
    private void Get_BVSALARIED_Details(string pCaseId, int pClientId)
    {
        try
        {
            SqlConnection sqlCon = new SqlConnection(ConfigurationManager.AppSettings["constring"]);

            sqlCon.Open();
            SqlCommand sqlCom = new SqlCommand();
            sqlCom.Connection = sqlCon;
            sqlCom.CommandType = CommandType.StoredProcedure;
            sqlCom.CommandText = "Get_BV_SALARIED_Details_For_GESBI";
            sqlCom.CommandTimeout = 0;

            SqlParameter Case_Id = new SqlParameter();
            Case_Id.SqlDbType = SqlDbType.VarChar;
            Case_Id.ParameterName = "@Case_Id";
            Case_Id.Value = pCaseId;
            sqlCom.Parameters.Add(Case_Id);

            SqlParameter ClientId = new SqlParameter();
            ClientId.SqlDbType = SqlDbType.Int;
            ClientId.ParameterName = "@ClientId";
            ClientId.Value = pClientId;
            sqlCom.Parameters.Add(ClientId);

            SqlDataAdapter sqlDA = new SqlDataAdapter();
            sqlDA.SelectCommand = sqlCom;
            DataSet ds = new DataSet();
            sqlDA.Fill(ds);
            sqlCon.Close();
            if (ds.Tables[0].Rows.Count > 0)
            {
                Assign_BV_Details(ds.Tables[0]);
            }
            else
            {
                lblMsg.Text = "No Details found!!!!";
            }
        }
        catch (Exception ex)
        {

            lblMsg.CssClass = "ErrorMessage";
            lblMsg.Text = ex.Message;
            lblMsg.Visible = true;
        }


    }
    private void Assign_BV_Details(DataTable dt)
    {
        try
        {
            txtObservation.Text = dt.Rows[0]["OBSERVATION"].ToString().Trim();
            txtApplicationNo.Text = dt.Rows[0]["Ref_No"].ToString().Trim();
            txtApplicantNAme.Text = dt.Rows[0]["CustomerName"].ToString().Trim();
            ddlAddressConfirm.SelectedValue = dt.Rows[0]["ADRESS_CONFIRMATION"].ToString().Trim();
            txtOfficeAddress.Text = dt.Rows[0]["OFFICE_ADDRESS"].ToString().Trim();
            ddlTypeOfProof.SelectedValue = dt.Rows[0]["DETAILS_PROOF_COLLECTED"].ToString().Trim();
            //ddlAddConfBy.SelectedValue = dt.Rows[0]["VERIFIED_NEIGHBOUR"].ToString().Trim();
            txtNameOfPersonMet.Text = dt.Rows[0]["Contacted_Person_Name"].ToString().Trim();
            txtdesignationofapplicant.Text = dt.Rows[0]["DESIGNATION"].ToString().Trim();
            txtrelationwithapplicant.Text = dt.Rows[0]["RELATION_PERSON_CONTACTED"].ToString().Trim();
            txtDesignationofPerMet.Text = dt.Rows[0]["OTHER_CONTACTED_DESIGNATION"].ToString().Trim();
            txtNameofBusiness.Text = dt.Rows[0]["COMPANY_NAME"].ToString().Trim();
            //txtApplicantAge_DOB.Text = dt.Rows[0]["APPLICANT_AGE"].ToString().Trim();
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
            txtEmployerAddress.Text = dt.Rows[0]["EMPLOYER_ADD"].ToString().Trim();
            txtTelephoneNo.Text = dt.Rows[0]["OFFICE_TELEPHONE"].ToString().Trim();
            txtExtension.Text = dt.Rows[0]["OFFICE_EXT"].ToString().Trim();
            txtResidence.Text = dt.Rows[0]["Change_In_Phone_No"].ToString().Trim();
            txtDepartment.Text = dt.Rows[0]["EMPLOYMENT_STATUS_2"].ToString().Trim();
             
            string strNoOfYearsCurrEmp = dt.Rows[0]["NO_OF_YEARS_AT_CURRENT_EMPLOYMENT"].ToString().Trim();
            string[] arrYCR_YYMM = strNoOfYearsCurrEmp.Split(':');
            if (strNoOfYearsCurrEmp == chk_YCE.Text.Trim())
            {
                chk_YCE.Checked = true;
            }
            else
            {
                if (arrYCR_YYMM.Length > 0)
                {
                    txtYearinEmployment.Text = arrYCR_YYMM[0].Trim();
                }
                if (arrYCR_YYMM.Length > 1)
                {
                    txtMonth.Text = arrYCR_YYMM[1].Trim();
                }
            }
            ddlTypeofCompany.SelectedValue = dt.Rows[0]["Business_Type"].ToString().Trim();
            ddlNature_of_Business.SelectedValue = dt.Rows[0]["Nature_Business"].ToString().Trim();
            txtBusinessDescription.Text = dt.Rows[0]["OTHER_NATURE_OF_BUSINESS"].ToString().Trim();
            txtNoOfEmployees.Text = dt.Rows[0]["NO_OF_EMP"].ToString().Trim();            
            ddlAppFullTimeEmployee.SelectedValue = dt.Rows[0]["IS_APPLICANT_FULL_TIME"].ToString().Trim();
            ddlInformationProvided.SelectedValue = dt.Rows[0]["INFO_REFUSED"].ToString().Trim();
            txtTPC1_Name.Text = dt.Rows[0]["TPC_Name"].ToString().Trim();
            ddlTPC1_ByWHOM.SelectedValue = dt.Rows[0]["TPC_By"].ToString().Trim();
            txtTPC1_Address.Text = dt.Rows[0]["TPC_DETAILS"].ToString().Trim();

            string strTPC1_Age = dt.Rows[0]["APPLICANT_AGE2"].ToString().Trim();
            string[] arrTPC1Age_YYMM = strTPC1_Age.Split(':');
            if (strTPC1_Age == chk_TPC1_age.Text.Trim())
            {
                chk_TPC1_age.Checked = true;
            }
            else
            {
                if (arrTPC1Age_YYMM.Length > 0)
                {
                    txtTPC1_AgeYear.Text = arrTPC1Age_YYMM[0].Trim();
                }
                if (arrTPC1Age_YYMM.Length > 1)
                {
                    txtTPC1_AgeMonth.Text = arrTPC1Age_YYMM[1].Trim();
                }
            }
            //ddlTPC1_AppYCR.SelectedValue = dt.Rows[0]["YCR"].ToString().Trim();
            string strTPC1_YCE = dt.Rows[0]["YCR"].ToString().Trim();
            string[] arrTPC1YCR_YYMM = strTPC1_YCE.Split(':');
            if (strTPC1_YCE == chk_TPC1AppYCE.Text.Trim())
            {
                chk_TPC1AppYCE.Checked = true;
            }
            else
            {
                if (arrTPC1YCR_YYMM.Length > 0)
                {
                    txtTPC1_Year.Text = arrTPC1YCR_YYMM[0].Trim();
                }
                if (arrTPC1YCR_YYMM.Length > 1)
                {
                    txtTPC1_Month.Text = arrTPC1YCR_YYMM[1].Trim();
                }
            }

            ddl_TCP_TypeofCompany.SelectedValue = dt.Rows[0]["TPC_TYPE_COMPANY"].ToString().Trim();
            ddl_TCP_NatureOfBusiness.SelectedValue = dt.Rows[0]["TPC_TYPE_BUSINESS"].ToString().Trim();
            ddl_ReasonAddNotConf.SelectedValue = dt.Rows[0]["REASON_ADD_NOT_CONFIRM"].ToString().Trim();           
            txtResultofCalling.Text = dt.Rows[0]["RESULT_CALLING"].ToString().Trim();                      
            txtWhomaddBelong.Text = dt.Rows[0]["ADDRESS_BELONG"].ToString().Trim();
            ddlCompanyboardSeen.SelectedValue = dt.Rows[0]["OFF_NAME_ON_BOARD"].ToString().Trim();
            ddlApplicantConfirmedwith.SelectedValue = dt.Rows[0]["APPLICANT_NAME_VERIFIED_FROM"].ToString().Trim();            
            ddlEaseOfLocationOffice.SelectedValue = dt.Rows[0]["LOCATING_ADDRESS"].ToString().Trim();
            ddlTypeOfficeLocality.SelectedValue = dt.Rows[0]["OFFICE_LOCALITY"].ToString().Trim();
            ddl_OfficeStatus.SelectedValue = dt.Rows[0]["OFFICE_REPUTATION"].ToString().Trim();
            txtLandmark.Text = dt.Rows[0]["LAND_MARK_OBSERVED"].ToString().Trim();
            ddlAreaOfOffice.SelectedValue = dt.Rows[0]["APPROXIMATE_AREA"].ToString().Trim();                       
            txtVerifierName.Text = dt.Rows[0]["VERIFIER_COMMENTS"].ToString().Trim();
            ddlVerification_conductedAt.SelectedValue = dt.Rows[0]["VERIFICATION_CONDUCTED_AT"].ToString().Trim();           
            ddlEntryPermitted.SelectedValue = dt.Rows[0]["ENTRY_PERMITTED"].ToString().Trim();
            ddlActivitySeen.SelectedValue = dt.Rows[0]["BUSINESS_ACTIVITY_SEEN"].ToString().Trim();
            ddlStockSeen.SelectedValue = dt.Rows[0]["BUSINESS_STOCK_SEEN"].ToString().Trim();
            ddlOfficesetupseen.SelectedValue = dt.Rows[0]["OFFICE_IS_IN"].ToString().Trim();
            txtVerifierRemark.Text = dt.Rows[0]["Fe_Remark"].ToString().Trim();
            ddlAddressUpdation.SelectedValue = dt.Rows[0]["ADDRESS2"].ToString().Trim();
            txtCorrectAddress.Text = dt.Rows[0]["MAILING_ADDRESS"].ToString().Trim();
            ddlDirectoryChecked.SelectedValue = dt.Rows[0]["Directory_Check"].ToString().Trim();
            string str_SupervisorName = dt.Rows[0]["SUPERVISOR_NAME"].ToString().Trim();
            if (str_SupervisorName!="")
            {
              ddlSupervisorName.SelectedValue = dt.Rows[0]["SUPERVISOR_NAME"].ToString().Trim();
            }
            txtSuperVisorRemark.Text = dt.Rows[0]["SUPERVISOR_REMARKS"].ToString().Trim();
            ddlProprietorRecomm.SelectedValue = dt.Rows[0]["RECOMMENDATION"].ToString().Trim();

            ddldesignationofApplicant.SelectedValue = dt.Rows[0]["Designation_of_Applicant_Confirm"].ToString().Trim();
            ddlrelationwithapplicant.SelectedValue = dt.Rows[0]["Relation_with_Applicant_Confirm"].ToString().Trim();
            ddldepartmentofApplicant.SelectedValue = dt.Rows[0]["Department_of_Applicant_Confirm"].ToString().Trim();
            ddlCompanyName.SelectedValue = dt.Rows[0]["CompanyName_Confirm"].ToString().Trim();
            txtEmailId.Text = dt.Rows[0]["EmailId"].ToString().Trim();            
            txtdefaulter.Text = dt.Rows[0]["Defaulter"].ToString().Trim();
            ddl_ResiCumBusi.SelectedValue = dt.Rows[0]["Resi_Cum_Business"].ToString().Trim();
            ddlSeperateAreaSeen.SelectedValue = dt.Rows[0]["Seperate_Office_Area"].ToString().Trim();

            ddlTPC1_Name.SelectedValue = dt.Rows[0]["TCP1_Name_Confirm"].ToString().Trim();
            txtTPC1_ApplicantName.Text = dt.Rows[0]["APPLICANT_NAME_CONFIRMED_AT_GIVEN_NO"].ToString().Trim();
            txtTPC1_designationOfApp.Text = dt.Rows[0]["Employment_Confirmed_With_Designation"].ToString().Trim();
            ddlTPC1_DesignofApplicant.SelectedValue = dt.Rows[0]["TCP1_Designation_Of_Applicant"].ToString().Trim();
            ddlTPC1_Employment.SelectedValue = dt.Rows[0]["EMPLOYMENT_STATUS_1"].ToString().Trim();
            ddlTcpApplicantName.SelectedValue = dt.Rows[0]["Tcp1_Applicant_Name_Confirmed"].ToString().Trim();
            ddlNameOfPersonMet.SelectedValue = dt.Rows[0]["Person_met_confirmed"].ToString().Trim();


            ddlTPC2_Name.SelectedValue = dt.Rows[0]["TPC2_Name"].ToString().Trim();
            txtTPC2_Name.Text = dt.Rows[0]["TPC2_Name_Confirm"].ToString().Trim();

            ddlTPC2_ByWhom.SelectedValue = dt.Rows[0]["TPC2_ByWhom"].ToString().Trim();
            txtTPC2_Address.Text = dt.Rows[0]["TPC2_Address"].ToString().Trim();
            ddlTPC2_AppName.SelectedValue = dt.Rows[0]["TPC2_AppName"].ToString().Trim();
            txtTPC2_AppName.Text = dt.Rows[0]["TPC2_AppName_Confirm"].ToString().Trim();
            ddlTPC2_NatureofBusi.SelectedValue = dt.Rows[0]["TPC2_NatureofBusi"].ToString().Trim();
            ddlTPC2_employment.SelectedValue = dt.Rows[0]["TPC2_employment"].ToString().Trim();
            ddl_TPC2Desig_App.SelectedValue = dt.Rows[0]["TPC2_Desig_App"].ToString().Trim();
            txtTPC2_dsigApp.Text = "";
            ddlTPC2_typeofComp.SelectedValue = dt.Rows[0]["TPC2_typeofComp"].ToString().Trim();



            string strTPC2_YCE = dt.Rows[0]["TPC2_YCE"].ToString().Trim();
            string[] arrstrTPC2_YCE = strTPC2_YCE.Split(':');
            if (strTPC2_YCE == chk_TPC2_YCE.Text.Trim())
            {
                chk_TPC2_YCE.Checked = true;
            }
            else
            {
                if (arrstrTPC2_YCE.Length > 0)
                {
                    txtTPC2_YCEYear.Text = arrstrTPC2_YCE[0].Trim();
                }
                if (arrstrTPC2_YCE.Length > 1)
                {
                    txtTPC2_Month.Text = arrstrTPC2_YCE[1].Trim();
                }
            }

            


            string strTPC2_Age = dt.Rows[0]["TPC2_Age"].ToString().Trim();
            string[] arrstrTPC2_Age_YYMM = strTPC2_Age.Split(':');
            if (strTPC2_Age == chkTPC2_age.Text.Trim())
            {
                chkTPC2_age.Checked = true;
            }
            else
            {
                if (arrstrTPC2_Age_YYMM.Length > 0)
                {
                    txtTPC2_AgeYear.Text = arrstrTPC2_Age_YYMM[0].Trim();
                }
                if (arrstrTPC2_Age_YYMM.Length > 1)
                {
                    txtTPC2_AgeMonth.Text = arrstrTPC2_Age_YYMM[1].Trim();
                }
            }




            dsAttempt = objCCVer.GetAttemptDtl1(txtCaseId.Text.Trim(), hidVerifierID.Value.Trim());
            
            //START Attempt Details ------------------------------------
            if (txtCaseId.Text != "")
            {
                txtAttemptDate1.Text = DateTime.Now.ToString("dd/MM/yyyy");
                txtAttemptDate2.Text = DateTime.Now.ToString("dd/MM/yyyy");
                txtAttemptDate3.Text = DateTime.Now.ToString("dd/MM/yyyy");

                if (dsAttempt.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < dsAttempt.Tables[0].Rows.Count; i++)
                    {
                        if (i == 0)
                        {
                            string sTmp = dsAttempt.Tables[0].Rows[i]["Attempt_Date_Time"].ToString();
                            string[] arrAttemptDateTime = sTmp.Split(' ');
                            txtAttemptDate1.Text = Convert.ToDateTime(arrAttemptDateTime[0].ToString()).ToString("dd/MM/yyyy");
                            txtAttemptTime1.Text = Convert.ToDateTime(arrAttemptDateTime[1].ToString()).ToString("hh:mm");
                            ddlAttemptTimeType1.SelectedValue = arrAttemptDateTime[2].ToString();
                            ddlVerifierRemarks1.SelectedValue = dsAttempt.Tables[0].Rows[i]["Remark"].ToString();
                        }
                        if (i == 1)
                        {
                            string sTmp = dsAttempt.Tables[0].Rows[i]["Attempt_Date_Time"].ToString();
                            string[] arrAttemptDateTime = sTmp.Split(' ');
                            txtAttemptDate2.Text = Convert.ToDateTime(arrAttemptDateTime[0].ToString()).ToString("dd/MM/yyyy");
                            txtAttemptTime2.Text = Convert.ToDateTime(arrAttemptDateTime[1].ToString()).ToString("hh:mm");
                            ddlAttemptTimeType2.SelectedValue = arrAttemptDateTime[2].ToString();
                            ddlVerifierRemarks2.SelectedValue = dsAttempt.Tables[0].Rows[i]["Remark"].ToString();
                        }
                        if (i == 2)
                        {
                            string sTmp = dsAttempt.Tables[0].Rows[i]["Attempt_Date_Time"].ToString();
                            string[] arrAttemptDateTime = sTmp.Split(' ');
                            txtAttemptDate3.Text = Convert.ToDateTime(arrAttemptDateTime[0].ToString()).ToString("dd/MM/yyyy");
                            txtAttemptTime3.Text = Convert.ToDateTime(arrAttemptDateTime[1].ToString()).ToString("hh:mm");
                            ddlAttemptTimeType3.SelectedValue = arrAttemptDateTime[2].ToString();
                            ddlVerifierRemarks3.SelectedValue = dsAttempt.Tables[0].Rows[i]["Remark"].ToString();
                        }
                    }


                }


            }
            //END Attempt Details ------------------------------------
            dsAttempt.Clear();
            dsAttempt.Dispose();

        }
        catch (Exception Ex)
        {
            lblMsg.Text = Ex.Message;
        }
    }
    private string Get_Attempt_details()
    {
        try
        {

            string strAttempt = "";
            strAttempt = strAttempt + txtAttemptDate1.Text.Trim() + "|" + txtAttemptTime1.Text.Trim() + "|" + ddlAttemptTimeType1.Text.Trim() + "|" + ddlVerifierRemarks1.Text.Trim() + "^" + txtAttemptDate2.Text.Trim() + "|" + txtAttemptTime2.Text.Trim() + "|" + ddlAttemptTimeType2.Text.Trim() + "|" + ddlVerifierRemarks2.Text.Trim() + "^" + txtAttemptDate3.Text.Trim() + "|" + txtAttemptTime3.Text.Trim() + "|" + ddlAttemptTimeType3.Text.Trim() + "|" + ddlVerifierRemarks3.Text.Trim() + "^";

            return strAttempt;

        }
        catch (Exception Ex)
        {
            lblMsg.Text = Ex.Message;
            return "";
        }

    } 
}


