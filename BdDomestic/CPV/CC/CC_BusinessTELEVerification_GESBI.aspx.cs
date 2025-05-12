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

public partial class CC_BusinessTELEVerification_GESBI : System.Web.UI.Page
{
    CCreditCardTelephonicVerification objRVT = new CCreditCardTelephonicVerification();
    
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            
            if (!IsPostBack)
            {
                if (Context.Request.QueryString["CaseID"] != null && Context.Request.QueryString["CaseID"] != "" && Context.Request.QueryString["VerTypeId"] != null && Context.Request.QueryString["VerTypeId"] != "")
                {

                    txtCaseId.Text = Context.Request.QueryString["CaseID"];
                    hdnVeriTypeId.Value = Context.Request.QueryString["VerTypeId"];
                    FillSupervisorName();
                    FillTelecallerName();
                    Get_BT_Details_For_GESBI(txtCaseId.Text.Trim(), Convert.ToInt32(Session["ClientId"]));
                    
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
                    RegisterControls_For_Javascript();
                    string StrScript = "<script language='javascript'> javascript:Page_Load_Validation(); </script>";
                    Page.RegisterStartupScript("OnLoad_21", StrScript);
          
                }

            }

             
        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;  
        }
    }
    private void RegisterControls_For_Javascript()
    {
        try
        {
           
            
            ddlInfo_Provided.Attributes.Add("onchange", "javascript:Enabled_Validation_on_InfoProvided();");   
         
            ddlAddition_No.Attributes.Add("onchange", "javascript:Enable_Validation_ResidanceNo_Confirmed(" + ddlAddition_No.ClientID + ",'No',true," + txtAdditionalNo.ClientID + ",'TextBox');");
            ddlEmployerName.Attributes.Add("onchange", "javascript:Enable_Validation_ResidanceNo_Confirmed(" + ddlEmployerName.ClientID + ",'Not Confirmed',true," + txtEmployerName.ClientID + ",'TextBox');");
            ddlResiAddress.Attributes.Add("onchange", "javascript:Enable_Validation_ResidanceNo_Confirmed(" + ddlResiAddress.ClientID + ",'Confirmed',false," + txtResidanceAddress.ClientID + ",'TextBox');");
            ddlEmployerAddress.Attributes.Add("onchange", "javascript:Enable_Validation_ResidanceNo_Confirmed(" + ddlEmployerAddress.ClientID + ",'Confirmed',false," + txtEmployerAddress.ClientID + ",'TextBox');");
            ddlDesignationOfPersonContatced.Attributes.Add("onchange", "javascript:Enable_Validation_ResidanceNo_Confirmed(" + ddlDesignationOfPersonContatced.ClientID + ",'Yes',false," + txtDesignationOfPersonContacted.ClientID + ",'TextBox');");
            ddlDesignationOfApplicant.Attributes.Add("onchange", "javascript:Enable_Validation_ResidanceNo_Confirmed(" + ddlDesignationOfApplicant.ClientID + ",'Not confirmed',true," + txtDesignationOfApplicant.ClientID + ",'TextBox');");
            ddlDepartmentOfApplicant.Attributes.Add("onchange", "javascript:Enable_Validation_ResidanceNo_Confirmed(" + ddlDepartmentOfApplicant.ClientID + ",'Not confirmed',true," + txtDepartmentOfApplicant.ClientID + ",'TextBox');");            
            ddlPersonSpokenTo.Attributes.Add("onchange", "javascript:Enabled_Validation_On_PersonContacted();");
            ddlOfficeTeleNo_Confirmed.Attributes.Add("onchange", "javascript:Enabled_Validation_On_OfficePhone_Confirm();");
            ddlProprietor_recomm.Attributes.Add("onchange", "javascript:Enable_Validation_ResidanceNo_Confirmed(" + ddlProprietor_recomm.ClientID + ",'Defaulter',false," + txtDefault.ClientID + ",'TextBox');");
            btnSubmit.Attributes.Add("onclick", "javascript:return Enabled_Validation_On_Submit();");
            ddlApplicantEmployment.Attributes.Add("onchange", "javascript:Enabled_Validation_on_ApplicantEmployment();");
            ddlNatureOfBusiness.Attributes.Add("onchange", "javascript:Enabled_Validation_on_NatureOfBusiness(" + ddlNatureOfBusiness.ClientID + "," + txtNaturaOfBusiness.ClientID + "," + txtDescOfBusiness.ClientID + ");");

            chkAGE_DOB.Attributes.Add("onclick", "javascript:Enabled_Validation_YY_MM(" + chkAGE_DOB.ClientID + ",true," + txtApplicantAge_DOB.ClientID + "," + txtApplicantAge_DOB_YY.ClientID + "," + txtApplicantAge_DOB_MM.ClientID + ");");
            chkYCE.Attributes.Add("onclick", "javascript:Enabled_Validation_YY_MM(" + chkYCE.ClientID + ",true,null," + txtYearsAtEmployement_YY.ClientID + "," + txtYearsAtEmployement_MM.ClientID + ");");

            txtTeleCallerRemark.Attributes.Add("onDblClick", "javascript:Autopopulate_Remarks();");           
           
                

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
    private void FillTelecallerName()
    {
        DataTable dtTeleCallerName = new DataTable();
        dtTeleCallerName = objRVT.GetTeleCallerName(Session["CentreId"].ToString(), Session["UserId"].ToString(), txtCaseId.Text.Trim() , hdnVeriTypeId.Value);
        ddlTeleCallerName.DataTextField = "FULLNAME";
        ddlTeleCallerName.DataValueField = "EMP_ID";
        ddlTeleCallerName.DataSource = dtTeleCallerName;
        ddlTeleCallerName.DataBind();
       

    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            Insert_BTDetails_GESBI();
        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message; 
        }
    }
    private void Insert_BTDetails_GESBI()
    {
        try
        {
            SqlConnection sqlCon = new SqlConnection(ConfigurationManager.AppSettings["constring"]);
            sqlCon.Open();
            SqlCommand sqlCom = new SqlCommand();
            sqlCom.Connection = sqlCon;
            sqlCom.CommandType = CommandType.StoredProcedure;
            sqlCom.CommandText = "Insert_BTDetails_GESBI";
            sqlCom.CommandTimeout = 0;

            SqlParameter Case_Id = new SqlParameter();
            Case_Id.SqlDbType = SqlDbType.VarChar;
            Case_Id.ParameterName = "@Case_Id";
            Case_Id.Value = txtCaseId.Text.Trim();
            sqlCom.Parameters.Add(Case_Id);

            SqlParameter Verification_Type_Id = new SqlParameter();
            Verification_Type_Id.SqlDbType = SqlDbType.Int;
            Verification_Type_Id.ParameterName = "@Verification_Type_Id";
            Verification_Type_Id.Value = hdnVeriTypeId.Value ;
            sqlCom.Parameters.Add(Verification_Type_Id);

            SqlParameter Office_No_Confimed = new SqlParameter();
            Office_No_Confimed.SqlDbType = SqlDbType.VarChar;
            Office_No_Confimed.ParameterName = "@Office_No_Confimed";
            Office_No_Confimed.Value = ddlOfficeTeleNo_Confirmed.Text.Trim();
            sqlCom.Parameters.Add(Office_No_Confimed);

            SqlParameter Reason_for_Office_No_if_Not_Confimed = new SqlParameter();
            Reason_for_Office_No_if_Not_Confimed.SqlDbType = SqlDbType.VarChar;
            Reason_for_Office_No_if_Not_Confimed.ParameterName = "@Reason_for_Office_No_if_Not_Confimed";
            Reason_for_Office_No_if_Not_Confimed.Value = ddlReasonForOffice_NotConf.Text.Trim();
            sqlCom.Parameters.Add(Reason_for_Office_No_if_Not_Confimed);
 
            SqlParameter Office_Telephone_No = new SqlParameter();
            Office_Telephone_No.SqlDbType = SqlDbType.VarChar;
            Office_Telephone_No.ParameterName = "@Office_Telephone_No";
            Office_Telephone_No.Value = txtEmployerPhoneNo.Text.Trim();
            sqlCom.Parameters.Add(Office_Telephone_No);

            SqlParameter Welcome_Message_Heard = new SqlParameter();
            Welcome_Message_Heard.SqlDbType = SqlDbType.VarChar;
            Welcome_Message_Heard.ParameterName = "@Welcome_Message_Heard";
            Welcome_Message_Heard.Value = ddlWelcomeMessageHeard.Text.Trim();
            sqlCom.Parameters.Add(Welcome_Message_Heard);

            SqlParameter Person_Spoken = new SqlParameter();
            Person_Spoken.SqlDbType = SqlDbType.VarChar;
            Person_Spoken.ParameterName = "@Person_Spoken";
            Person_Spoken.Value = ddlPersonSpokenTo.Text.Trim();
            sqlCom.Parameters.Add(Person_Spoken);

            SqlParameter Person_Spoken_To_Name = new SqlParameter();
            Person_Spoken_To_Name.SqlDbType = SqlDbType.VarChar;
            Person_Spoken_To_Name.ParameterName = "@Person_Spoken_To_Name";
            Person_Spoken_To_Name.Value = txtPersonSpokenTo.Text.Trim();
            sqlCom.Parameters.Add(Person_Spoken_To_Name);

            SqlParameter Information_provided = new SqlParameter();
            Information_provided.SqlDbType = SqlDbType.VarChar;
            Information_provided.ParameterName = "@Information_provided";
            Information_provided.Value = ddlInfo_Provided.Text.Trim();
            sqlCom.Parameters.Add(Information_provided);

            SqlParameter Employer_name_confimed = new SqlParameter();
            Employer_name_confimed.SqlDbType = SqlDbType.VarChar;
            Employer_name_confimed.ParameterName = "@Employer_name_confimed";
            Employer_name_confimed.Value = ddlEmployerName.Text.Trim();
            sqlCom.Parameters.Add(Employer_name_confimed);

            SqlParameter Employer_name_If_Confimed = new SqlParameter();
            Employer_name_If_Confimed.SqlDbType = SqlDbType.VarChar;
            Employer_name_If_Confimed.ParameterName = "@Employer_name_If_Confimed";
            Employer_name_If_Confimed.Value = txtEmployerName.Text.Trim();
            sqlCom.Parameters.Add(Employer_name_If_Confimed);

            SqlParameter Designation_of_person_contacted_Confirmed = new SqlParameter();
            Designation_of_person_contacted_Confirmed.SqlDbType = SqlDbType.VarChar;
            Designation_of_person_contacted_Confirmed.ParameterName = "@Designation_of_person_contacted_Confirmed";
            Designation_of_person_contacted_Confirmed.Value = ddlDesignationOfPersonContatced.Text.Trim();
            sqlCom.Parameters.Add(Designation_of_person_contacted_Confirmed);

            SqlParameter Designation_of_person_contacted = new SqlParameter();
            Designation_of_person_contacted.SqlDbType = SqlDbType.VarChar;
            Designation_of_person_contacted.ParameterName = "@Designation_of_person_contacted";
            Designation_of_person_contacted.Value = txtDesignationOfPersonContacted.Text.Trim();
            sqlCom.Parameters.Add(Designation_of_person_contacted);

            SqlParameter Applicant_Employment = new SqlParameter();
            Applicant_Employment.SqlDbType = SqlDbType.VarChar;
            Applicant_Employment.ParameterName = "@Applicant_Employment";
            Applicant_Employment.Value = ddlApplicantEmployment.Text.Trim();
            sqlCom.Parameters.Add(Applicant_Employment);

            SqlParameter Designation_of_Applicant_Confirmed = new SqlParameter();
            Designation_of_Applicant_Confirmed.SqlDbType = SqlDbType.VarChar;
            Designation_of_Applicant_Confirmed.ParameterName = "@Designation_of_Applicant_Confirmed";
            Designation_of_Applicant_Confirmed.Value = ddlDesignationOfApplicant.Text.Trim();
            sqlCom.Parameters.Add(Designation_of_Applicant_Confirmed);

            SqlParameter Designation_of_Applicant = new SqlParameter();
            Designation_of_Applicant.SqlDbType = SqlDbType.VarChar;
            Designation_of_Applicant.ParameterName = "@Designation_of_Applicant";
            Designation_of_Applicant.Value = txtDesignationOfApplicant.Text.Trim();
            sqlCom.Parameters.Add(Designation_of_Applicant);

            SqlParameter Department_of_Applicant_Confirmed = new SqlParameter();
            Department_of_Applicant_Confirmed.SqlDbType = SqlDbType.VarChar;
            Department_of_Applicant_Confirmed.ParameterName = "@Department_of_Applicant_Confirmed";
            Department_of_Applicant_Confirmed.Value = ddlDepartmentOfApplicant.Text.Trim();
            sqlCom.Parameters.Add(Department_of_Applicant_Confirmed);

            SqlParameter Department_of_Applicant = new SqlParameter();
            Department_of_Applicant.SqlDbType = SqlDbType.VarChar;
            Department_of_Applicant.ParameterName = "@Department_of_Applicant";
            Department_of_Applicant.Value = txtDepartmentOfApplicant.Text.Trim();
            sqlCom.Parameters.Add(Department_of_Applicant);

            SqlParameter Extension_No_of_applicant = new SqlParameter();
            Extension_No_of_applicant.SqlDbType = SqlDbType.VarChar;
            Extension_No_of_applicant.ParameterName = "@Extension_No_of_applicant";
            Extension_No_of_applicant.Value = txtExtNo.Text.Trim();
            sqlCom.Parameters.Add(Extension_No_of_applicant);

            SqlParameter Employer_Address_Confirmed = new SqlParameter();
            Employer_Address_Confirmed.SqlDbType = SqlDbType.VarChar;
            Employer_Address_Confirmed.ParameterName = "@Employer_Address_Confirmed";
            Employer_Address_Confirmed.Value = ddlEmployerAddress.Text.Trim();
            sqlCom.Parameters.Add(Employer_Address_Confirmed);

            SqlParameter If_Employer_Confirm = new SqlParameter();
            If_Employer_Confirm.SqlDbType = SqlDbType.VarChar;
            If_Employer_Confirm.ParameterName = "@If_Employer_Confirm";
            If_Employer_Confirm.Value = txtEmployerAddress.Text.Trim();
            sqlCom.Parameters.Add(If_Employer_Confirm);


          

            string strYCE = "";
            if (chkYCE.Checked == true)
            {
                strYCE = chkYCE.Text.Trim();
            }
            else
            {
                strYCE = txtYearsAtEmployement_YY.Text.Trim() + ":" + txtYearsAtEmployement_MM.Text.Trim();
            } 
            SqlParameter Y_C_E = new SqlParameter();
            Y_C_E.SqlDbType = SqlDbType.VarChar;
            Y_C_E.ParameterName = "@Y_C_E";
            Y_C_E.Value = strYCE;
            sqlCom.Parameters.Add(Y_C_E);

            string strApplicantAge = "";
            if (chkAGE_DOB.Checked == true)
            {
                strApplicantAge = chkAGE_DOB.Text.Trim();
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


            SqlParameter Age_DOB = new SqlParameter();
            Age_DOB.SqlDbType = SqlDbType.VarChar;
            Age_DOB.ParameterName = "@Age_DOB";
            Age_DOB.Value = strApplicantAge;
            sqlCom.Parameters.Add(Age_DOB);

            SqlParameter Additional_Office_no_if_contacted = new SqlParameter();
            Additional_Office_no_if_contacted.SqlDbType = SqlDbType.VarChar;
            Additional_Office_no_if_contacted.ParameterName = "@Additional_Office_no_if_contacted";
            Additional_Office_no_if_contacted.Value = ddlAddition_No.Text.Trim();
            sqlCom.Parameters.Add(Additional_Office_no_if_contacted);

            SqlParameter Additional_Office_no = new SqlParameter();
            Additional_Office_no.SqlDbType = SqlDbType.VarChar;
            Additional_Office_no.ParameterName = "@Additional_Office_no";
            Additional_Office_no.Value = txtAdditionalNo.Text.Trim();
            sqlCom.Parameters.Add(Additional_Office_no);

            SqlParameter Residence_Ph_no = new SqlParameter();
            Residence_Ph_no.SqlDbType = SqlDbType.VarChar;
            Residence_Ph_no.ParameterName = "@Residence_Ph_no";
            Residence_Ph_no.Value = txtResiPhone.Text.Trim();
            sqlCom.Parameters.Add(Residence_Ph_no);

            SqlParameter Residence_Address_Confirmed = new SqlParameter();
            Residence_Address_Confirmed.SqlDbType = SqlDbType.VarChar;
            Residence_Address_Confirmed.ParameterName = "@Residence_Address_Confirmed";
            Residence_Address_Confirmed.Value = ddlResiAddress.Text.Trim();
            sqlCom.Parameters.Add(Residence_Address_Confirmed);

            SqlParameter Residance_Address = new SqlParameter();
            Residance_Address.SqlDbType = SqlDbType.VarChar;
            Residance_Address.ParameterName = "@Residance_Address";
            Residance_Address.Value = txtResidanceAddress.Text.Trim();
            sqlCom.Parameters.Add(Residance_Address);

            SqlParameter Nature_of_Business = new SqlParameter();
            Nature_of_Business.SqlDbType = SqlDbType.VarChar;
            Nature_of_Business.ParameterName = "@Nature_of_Business";
            Nature_of_Business.Value = ddlNatureOfBusiness.Text.Trim();
            sqlCom.Parameters.Add(Nature_of_Business);

            SqlParameter If_Other = new SqlParameter();
            If_Other.SqlDbType = SqlDbType.VarChar;
            If_Other.ParameterName = "@If_Other";
            If_Other.Value = txtNaturaOfBusiness.Text.Trim();
            sqlCom.Parameters.Add(If_Other);

            SqlParameter Description_of_Business = new SqlParameter();
            Description_of_Business.SqlDbType = SqlDbType.VarChar;
            Description_of_Business.ParameterName = "@Description_of_Business";
            Description_of_Business.Value = txtDescOfBusiness.Text.Trim();
            sqlCom.Parameters.Add(Description_of_Business);

            SqlParameter Attempt_Details = new SqlParameter();
            Attempt_Details.SqlDbType = SqlDbType.VarChar;
            Attempt_Details.ParameterName = "@Attempt_Details";
            Attempt_Details.Value =Get_AttemptDetails();
            sqlCom.Parameters.Add(Attempt_Details);

            SqlParameter Tele_Caller_Name = new SqlParameter();
            Tele_Caller_Name.SqlDbType = SqlDbType.VarChar;
            Tele_Caller_Name.ParameterName = "@Tele_Caller_Name";
            Tele_Caller_Name.Value = ddlTeleCallerName.Text.Trim();
            sqlCom.Parameters.Add(Tele_Caller_Name);

            SqlParameter TeleCaller_ID = new SqlParameter();
            TeleCaller_ID.SqlDbType = SqlDbType.VarChar;
            TeleCaller_ID.ParameterName = "@TeleCaller_ID";
            TeleCaller_ID.Value = ddlTeleCallerName.SelectedItem.Value; 
            sqlCom.Parameters.Add(TeleCaller_ID);
            
            SqlParameter Tele_Caller_Remark = new SqlParameter();
            Tele_Caller_Remark.SqlDbType = SqlDbType.VarChar;
            Tele_Caller_Remark.ParameterName = "@Tele_Caller_Remark";
            Tele_Caller_Remark.Value = txtTeleCallerRemark.Text.Trim();
            sqlCom.Parameters.Add(Tele_Caller_Remark);

            SqlParameter Supervisor_Name = new SqlParameter();
            Supervisor_Name.SqlDbType = SqlDbType.VarChar;
            Supervisor_Name.ParameterName = "@Supervisor_Name";
            Supervisor_Name.Value = ddlSupervisorName.Text.Trim();
            sqlCom.Parameters.Add(Supervisor_Name);

            SqlParameter SupervisorName_EmpID = new SqlParameter();
            SupervisorName_EmpID.SqlDbType = SqlDbType.VarChar;
            SupervisorName_EmpID.ParameterName = "@SupervisorName_EmpID";
            SupervisorName_EmpID.Value = ddlSupervisorName.SelectedItem.Value;
            sqlCom.Parameters.Add(SupervisorName_EmpID);

            SqlParameter Supervisor_Remark = new SqlParameter();
            Supervisor_Remark.SqlDbType = SqlDbType.VarChar;
            Supervisor_Remark.ParameterName = "@Supervisor_Remark";
            Supervisor_Remark.Value = txtSuperVisorRemark.Text.Trim();
            sqlCom.Parameters.Add(Supervisor_Remark);

            SqlParameter Web_Checked = new SqlParameter();
            Web_Checked.SqlDbType = SqlDbType.VarChar;
            Web_Checked.ParameterName = "@Web_Checked";
            Web_Checked.Value = ddlWebCheck.Text.Trim();
            sqlCom.Parameters.Add(Web_Checked);

            SqlParameter Proprietor_Recommendation = new SqlParameter();
            Proprietor_Recommendation.SqlDbType = SqlDbType.VarChar;
            Proprietor_Recommendation.ParameterName = "@Proprietor_Recommendation";
            Proprietor_Recommendation.Value = ddlProprietor_recomm.Text.Trim();
            sqlCom.Parameters.Add(Proprietor_Recommendation);

            SqlParameter If_defaulter_details = new SqlParameter();
            If_defaulter_details.SqlDbType = SqlDbType.VarChar;
            If_defaulter_details.ParameterName = "@If_defaulter_details";
            If_defaulter_details.Value = txtDefault.Text.Trim();
            sqlCom.Parameters.Add(If_defaulter_details);


            int intRow = sqlCom.ExecuteNonQuery();
                sqlCon.Close();
                if (intRow > 0)
                {
                    lblMessage.CssClass = "UpdateMessage";
                    lblMessage.Text = "Record Successfully Updated!!!!";
                }
        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
        }
    
    }
    private string Get_AttemptDetails()
    {
        try
        {

            string strAttemptDetails = "";
            strAttemptDetails = strAttemptDetails + txtDate1stCall.Text.Trim() + "|" + txtTime1stCall.Text.Trim() + "|" + ddlTime1stCall.Text.Trim() + "|" + txtTelNo1stCall.Text.Trim() + "|" + ddlRemarks1stCall.Text.Trim() + "^" + txtDate2ndCall.Text.Trim() + "|" + txtTime2ndCall.Text.Trim() + "|" + ddlTime2ndCall.Text.Trim() + "|" + txtTelNo2ndCall.Text.Trim() + "|" + ddlRemarks2ndCall.Text.Trim() + "^"
    + txtDate3rdCall.Text.Trim() + "|" + txtTime3rdCall.Text.Trim() + "|" + ddlTime3rdCall.Text.Trim() + "|" + txtTelNo3rdCall.Text.Trim() + "|" + ddlRemarks3rdCall.Text.Trim() + "^"
      + txtDate4thCall.Text.Trim() + "|" + txtTime4thCall.Text.Trim() + "|" + ddlTime4thCall.Text.Trim() + "|" + txtTelNo4thCall.Text.Trim() + "|" + ddlRemarks4thCall.Text.Trim() + "^"
         + txtDate5thCall.Text.Trim() + "|" + txtTime5thCall.Text.Trim() + "|" + ddlTime5thCall.Text.Trim() + "|" + txtTelNo5thCall.Text.Trim() + "|" + ddlRemarks5thCall.Text.Trim() + "^";

            return strAttemptDetails;
        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
            return "";

        }
    }
    private void GetTeleCallLog()
    {

        DataSet dsTeleCallLog = new DataSet();
        txtDate1stCall.Text = DateTime.Now.ToString("dd/MM/yyyy");
        txtDate2ndCall.Text = DateTime.Now.ToString("dd/MM/yyyy");
        txtDate3rdCall.Text = DateTime.Now.ToString("dd/MM/yyyy");
        txtDate4thCall.Text = DateTime.Now.ToString("dd/MM/yyyy");
        txtDate5thCall.Text = DateTime.Now.ToString("dd/MM/yyyy");
           
        if (txtCaseId.Text != "")
        {
            dsTeleCallLog = objRVT.GetTeleCallLogDetail(txtCaseId.Text.Trim(), hdnVeriTypeId.Value);
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
                        ddlRemarks1stCall.SelectedValue = dsTeleCallLog.Tables[0].Rows[i]["Remark"].ToString();
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
                        ddlRemarks2ndCall.SelectedValue = dsTeleCallLog.Tables[0].Rows[i]["Remark"].ToString();
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
                        ddlRemarks3rdCall.SelectedValue = dsTeleCallLog.Tables[0].Rows[i]["Remark"].ToString();
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
                        ddlRemarks4thCall.SelectedValue = dsTeleCallLog.Tables[0].Rows[i]["Remark"].ToString();
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
                        ddlRemarks5thCall.SelectedValue = dsTeleCallLog.Tables[0].Rows[i]["Remark"].ToString();
                        //ddlTeleName.SelectedValue = dsTeleCallLog.Tables[0].Rows[i]["VERIFIER_ID"].ToString();
                    }
                }

            }

        }

    }
    private void Get_BT_Details_For_GESBI(string pCaseId, int pClientId)
    {
        try
        {

            SqlConnection sqlCon = new SqlConnection(ConfigurationManager.AppSettings["constring"]);

            sqlCon.Open();
            SqlCommand sqlCom = new SqlCommand();
            sqlCom.Connection = sqlCon;
            sqlCom.CommandType = CommandType.StoredProcedure;
            sqlCom.CommandText = "Get_BT_Details_For_GESBI";
            sqlCom.CommandTimeout = 0;

            SqlParameter Case_Id = new SqlParameter();
            Case_Id.SqlDbType = SqlDbType.VarChar;
            Case_Id.ParameterName = "@CaseId";
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
                Assign_BT_Details(ds.Tables[0]);
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
    private void Assign_BT_Details(DataTable dt)
    {
        try
        {
            txtApplicantionNumber.Text = dt.Rows[0]["Application_Number"].ToString().Trim();
            txtApplicantName.Text = dt.Rows[0]["CustomerName"].ToString().Trim();
            ddlOfficeTeleNo_Confirmed.SelectedValue = dt.Rows[0]["Office_No_Confimed"].ToString().Trim();
            ddlReasonForOffice_NotConf.SelectedValue = dt.Rows[0]["Reason_for_Office_No_if_Not_Confimed"].ToString().Trim();
            txtEmployerPhoneNo.Text = dt.Rows[0]["Office_Telephone_No"].ToString().Trim();
            ddlWelcomeMessageHeard.SelectedValue = dt.Rows[0]["Welcome_Message_Heard"].ToString().Trim();
            ddlPersonSpokenTo.SelectedValue = dt.Rows[0]["Person_Spoken"].ToString().Trim();
            txtPersonSpokenTo.Text = dt.Rows[0]["Person_Spoken_To_Name"].ToString().Trim();
            ddlInfo_Provided.SelectedValue = dt.Rows[0]["Information_provided"].ToString().Trim();
            ddlEmployerName.SelectedValue = dt.Rows[0]["Employer_name_confimed"].ToString().Trim();
            txtEmployerName.Text = dt.Rows[0]["Employer_name_If_Confimed"].ToString().Trim();

            ddlDesignationOfPersonContatced.SelectedValue = dt.Rows[0]["Designation_of_person_contacted_Confirmed"].ToString().Trim();
            txtDesignationOfPersonContacted.Text = dt.Rows[0]["Designation_of_person_contacted"].ToString().Trim();

            ddlApplicantEmployment.SelectedValue = dt.Rows[0]["Applicant_Employment"].ToString().Trim();

            ddlDesignationOfApplicant.SelectedValue = dt.Rows[0]["Designation_of_Applicant_Confirmed"].ToString().Trim();
            txtDesignationOfApplicant.Text = dt.Rows[0]["Designation_of_Applicant"].ToString().Trim();

            ddlDepartmentOfApplicant.SelectedValue = dt.Rows[0]["Department_of_Applicant_Confirmed"].ToString().Trim();
            txtDepartmentOfApplicant.Text = dt.Rows[0]["Department_of_Applicant"].ToString().Trim();

            txtExtNo.Text = dt.Rows[0]["Extension_No_of_applicant"].ToString().Trim();
            ddlEmployerAddress.SelectedValue = dt.Rows[0]["Employer_Address_Confirmed"].ToString().Trim();
            txtEmployerAddress.Text = dt.Rows[0]["If_Employer_Confirm"].ToString().Trim();

            string strYCE = dt.Rows[0]["Y_C_E"].ToString().Trim();
            string[] arrYCE_YYMM = strYCE.Split(':');

            if (strYCE == chkYCE.Text.Trim())
            {
                chkYCE.Checked = true;
            }
            else
            {
                if (arrYCE_YYMM.Length > 0)
                {
                    txtYearsAtEmployement_YY.Text = arrYCE_YYMM[0].Trim();
                }

                if (arrYCE_YYMM.Length > 1)
                {
                    txtYearsAtEmployement_MM.Text = arrYCE_YYMM[1].Trim();
                }
            }

            ddlAddition_No.SelectedValue = dt.Rows[0]["Additional_Office_no_if_contacted"].ToString().Trim();
            txtAdditionalNo.Text = dt.Rows[0]["Additional_Office_no"].ToString().Trim();
            txtResiPhone.Text = dt.Rows[0]["Residence_Ph_no"].ToString().Trim();


            string strAPPLICANT_AGE = dt.Rows[0]["Age_DOB"].ToString().Trim();
            if (strAPPLICANT_AGE == "Not Confirmed")
            {
                chkAGE_DOB.Checked = true;
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

            ddlResiAddress.SelectedValue = dt.Rows[0]["Residence_Address_Confirmed"].ToString().Trim();
            txtResidanceAddress.Text = dt.Rows[0]["Residance_Address"].ToString().Trim();
            ddlNatureOfBusiness.SelectedValue = dt.Rows[0]["Nature_of_Business"].ToString().Trim();
            txtNaturaOfBusiness.Text = dt.Rows[0]["If_Other"].ToString().Trim();
            txtDescOfBusiness.Text = dt.Rows[0]["Description_of_Business"].ToString().Trim();
            ddlTeleCallerName.SelectedValue = dt.Rows[0]["TeleCaller_ID"].ToString().Trim();
            txtTeleCallerRemark.Text = dt.Rows[0]["Tele_Caller_Remark"].ToString().Trim();
            ddlSupervisorName.SelectedValue = dt.Rows[0]["SupervisorName_EmpID"].ToString().Trim();
            txtSuperVisorRemark.Text = dt.Rows[0]["Supervisor_Remark"].ToString().Trim();
            ddlWebCheck.SelectedValue = dt.Rows[0]["Web_Checked"].ToString().Trim();
            ddlProprietor_recomm.SelectedValue = dt.Rows[0]["Proprietor_Recommendation"].ToString().Trim();
            txtDefault.Text = dt.Rows[0]["If_defaulter_details"].ToString().Trim();
            GetTeleCallLog();
             

        }
        catch (Exception Ex)
        {
            lblMessage.Text = Ex.Message;
        }
    }
}
    