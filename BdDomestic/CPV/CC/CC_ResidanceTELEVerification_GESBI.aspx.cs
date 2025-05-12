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


public partial class CPV_CC_CC_ResidanceTELEVerification_GESBI : System.Web.UI.Page
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
                    Get_RV_Details_For_GESBI(txtCaseId.Text.Trim(), Convert.ToInt32(Session["ClientId"]));
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
                    RegisterControls_For_Javascript();
                    
                   string StrScript = "<script language='javascript'> javascript:Page_Load_Validation(); </script>";
                   Page.RegisterStartupScript("OnLoad_Validation", StrScript);
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
            ddlResiTeleNo_Confirmed.Attributes.Add("onchange", "javascript:Enabled_Validation_On_ResiPhone_Confirm();");
            ddlPersonSpokenTo.Attributes.Add("onchange", "javascript:Enable_Validation_On_PersonSPOKEN();");
            ddlResiAddress.Attributes.Add("onchange", "javascript:Enable_Validation_ResidanceNo_Confirmed(" + ddlResiAddress.ClientID + ",'Mismatch in Address',false," + txtResidanceAddress.ClientID + ",'TextBox');");
            ddlAdditionResi_No.Attributes.Add("onchange", "javascript:Enable_Validation_ResidanceNo_Confirmed(" + ddlAdditionResi_No.ClientID + ",'No',true," + txtAdditionalNo.ClientID + ",'TextBox');");
            ddlEmployerName.Attributes.Add("onchange", "javascript:Enable_Validation_ResidanceNo_Confirmed(" + ddlEmployerName.ClientID + ",'Not Confirmed',true," + txtEmployerName.ClientID + ",'TextBox');");
            ddlEmployerAddress.Attributes.Add("onchange", "javascript:Enable_Validation_ResidanceNo_Confirmed(" + ddlEmployerAddress.ClientID + ",'Not Confirmed',true," + txtEmployerAddress.ClientID + ",'TextBox');");
            ddlInfo_Provided.Attributes.Add("onchange", "javascript:Enabled_Validation_on_InfoProvided();");
            ddlProprietor_recomm.Attributes.Add("onchange", "javascript:Enable_Validation_ResidanceNo_Confirmed(" + ddlProprietor_recomm.ClientID + ",'Defaulter',false," + txtDefault.ClientID + ",'TextBox');");
            ddlApplicantStay_Confirm.Attributes.Add("onchange", "javascript:Enable_Validation_On_Applicant_Stay_Confirm();");
            ddlApplicantName_Confirmed.Attributes.Add("onchange", "javascript:Enable_Validation_On_ApplicantName_Confirm();");
            chkAGE_DOB.Attributes.Add("onclick", "javascript:Enabled_Validation_YY_MM(" + chkAGE_DOB.ClientID + ",true," + txtApplicantAge_DOB.ClientID + "," + txtApplicantAge_DOB_YY.ClientID + "," + txtApplicantAge_DOB_MM.ClientID + ");");
            chkYCR.Attributes.Add("onclick", "javascript:Enabled_Validation_YY_MM(" + chkYCR.ClientID + ",true,null," + txtYearsLivedAtResi_YY.ClientID + "," + txtYearsLivedAtResi_MM.ClientID + ");");
            txtTeleCallerRemark.Attributes.Add("onDblClick", "javascript:Enable_validation_On_AutoPopulate_Remark();");

            btnSubmit.Attributes.Add("onclick", "javascript:return Enable_Validation_On_Submit();");
            
    
              
            
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
        dtTeleCallerName = objRVT.GetTeleCallerName(Session["CentreId"].ToString(), Session["UserId"].ToString(), txtCaseId.Text.Trim(), hdnVeriTypeId.Value);
        ddlTeleCallerName.DataTextField = "FULLNAME";
        ddlTeleCallerName.DataValueField = "EMP_ID";
        ddlTeleCallerName.DataSource = dtTeleCallerName;
        ddlTeleCallerName.DataBind();


    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            Insert_RT_DetailsFor_GESBI();
        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
        }

    }     
    private void Insert_RT_DetailsFor_GESBI()
     {
         try
         {
             SqlConnection sqlCon = new SqlConnection(ConfigurationManager.AppSettings["constring"]);
             sqlCon.Open();
             SqlCommand sqlCom = new SqlCommand();
             sqlCom.Connection = sqlCon;
             sqlCom.CommandType = CommandType.StoredProcedure;
             sqlCom.CommandText = "Insert_RTDetails_GESBI";
             sqlCom.CommandTimeout = 0;

             SqlParameter Case_Id = new SqlParameter();
             Case_Id.SqlDbType = SqlDbType.VarChar;
             Case_Id.ParameterName = "@Case_Id";
             Case_Id.Value = txtCaseId.Text.Trim();
             sqlCom.Parameters.Add(Case_Id);

             SqlParameter Verification_Type_Id = new SqlParameter();
             Verification_Type_Id.SqlDbType = SqlDbType.Int;
             Verification_Type_Id.ParameterName = "@Verification_Type_Id";
             Verification_Type_Id.Value = hdnVeriTypeId.Value;
             sqlCom.Parameters.Add(Verification_Type_Id);

             SqlParameter App_No = new SqlParameter();
             App_No.SqlDbType = SqlDbType.VarChar;
             App_No.ParameterName = "@Application_Number";
             App_No.Value = txtApplicantionNumber.Text.Trim();
             sqlCom.Parameters.Add(App_No);

             SqlParameter ResiTeleNo = new SqlParameter();
             ResiTeleNo.SqlDbType = SqlDbType.VarChar;
             ResiTeleNo.ParameterName = "@Residence_No_Confirmed";
             ResiTeleNo.Value = ddlResiTeleNo_Confirmed.Text.Trim();
             sqlCom.Parameters.Add(ResiTeleNo);

             SqlParameter Reason_Not_Conf = new SqlParameter();
             Reason_Not_Conf.SqlDbType = SqlDbType.VarChar;
             Reason_Not_Conf.ParameterName = "@Reason_for_Residence_No_if_Not_Confirmed";
             Reason_Not_Conf.Value = ddlReasonForResiNo_NotConf.Text.Trim();
             sqlCom.Parameters.Add(Reason_Not_Conf);

             SqlParameter Residence_no = new SqlParameter();
             Residence_no.SqlDbType = SqlDbType.VarChar;
             Residence_no.ParameterName = "@Residence_Telephone_No";
             Residence_no.Value = txtResidance_Number.Text.Trim();
             sqlCom.Parameters.Add(Residence_no);

             SqlParameter Person_spoken = new SqlParameter();
             Person_spoken.SqlDbType = SqlDbType.VarChar;
             Person_spoken.ParameterName = "@Person_Spoken";
             Person_spoken.Value = ddlPersonSpokenTo.Text.Trim();
             sqlCom.Parameters.Add(Person_spoken);

             SqlParameter Person_spoken_to = new SqlParameter();
             Person_spoken_to.SqlDbType = SqlDbType.VarChar;
             Person_spoken_to.ParameterName = "@Person_Spoken_To_Name";
             Person_spoken_to.Value = txtPersonSpokenTo.Text.Trim();
             sqlCom.Parameters.Add(Person_spoken_to);

             SqlParameter Info_Provided = new SqlParameter();
             Info_Provided.SqlDbType = SqlDbType.VarChar;
             Info_Provided.ParameterName = "@Information_provided";
             Info_Provided.Value = ddlInfo_Provided.Text.Trim();
             sqlCom.Parameters.Add(Info_Provided);

             SqlParameter Rel_with_App = new SqlParameter();
             Rel_with_App.SqlDbType = SqlDbType.VarChar;
             Rel_with_App.ParameterName = "@Relationship_with_Applicant";
             Rel_with_App.Value = txtRelationWithApplicant.Text.Trim();
             sqlCom.Parameters.Add(Rel_with_App);

             SqlParameter AppName_Conf = new SqlParameter();
             AppName_Conf.SqlDbType = SqlDbType.VarChar;
             AppName_Conf.ParameterName = "@Applicant_Name_Confirmed";
             AppName_Conf.Value = ddlApplicantName_Confirmed.Text.Trim();
             sqlCom.Parameters.Add(AppName_Conf);

             SqlParameter AppStay_Conf = new SqlParameter();
             AppStay_Conf.SqlDbType = SqlDbType.VarChar;
             AppStay_Conf.ParameterName = "@Applicant_Stay_Confirmed";
             AppStay_Conf.Value = ddlApplicantStay_Confirm.Text.Trim();
             sqlCom.Parameters.Add(AppStay_Conf);

             SqlParameter ResiStatus = new SqlParameter();
             ResiStatus.SqlDbType = SqlDbType.VarChar;
             ResiStatus.ParameterName = "@Residence_Status_of_Applicant";
             ResiStatus.Value = ddlResiStatus.Text.Trim();
             sqlCom.Parameters.Add(ResiStatus);

             string strYCR = "";
             if (chkYCR.Checked == true)
             {
                 strYCR = chkYCR.Text.Trim();
             }
             else
             {

                 strYCR = txtYearsLivedAtResi_YY.Text.Trim() + ":" + txtYearsLivedAtResi_MM.Text.Trim();

             }

             SqlParameter YCR = new SqlParameter();
             YCR.SqlDbType = SqlDbType.VarChar;
             YCR.ParameterName = "@Y_C_R";
             YCR.Value = strYCR;
             sqlCom.Parameters.Add(YCR);

             SqlParameter NoOf_FamilyMem = new SqlParameter();
             NoOf_FamilyMem.SqlDbType = SqlDbType.VarChar;
             NoOf_FamilyMem.ParameterName = "@No_Of_Family_Members";
             NoOf_FamilyMem.Value = ddlNoOfFamilyMembers.Text.Trim();
             sqlCom.Parameters.Add(NoOf_FamilyMem);

             SqlParameter Earning_Mem = new SqlParameter();
             Earning_Mem.SqlDbType = SqlDbType.VarChar;
             Earning_Mem.ParameterName = "@Earning_Family_Members";
             Earning_Mem.Value = ddlEaringFamilyMembers.Text.Trim();
             sqlCom.Parameters.Add(Earning_Mem);

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

             SqlParameter App_Age = new SqlParameter();
             App_Age.SqlDbType = SqlDbType.VarChar;
             App_Age.ParameterName = "@Age_DOB";
             App_Age.Value = strApplicantAge;
             sqlCom.Parameters.Add(App_Age);

             SqlParameter Resi_add = new SqlParameter();
             Resi_add.SqlDbType = SqlDbType.VarChar;
             Resi_add.ParameterName = "@Residence_Address";
             Resi_add.Value = ddlResiAddress.Text.Trim();
             sqlCom.Parameters.Add(Resi_add);

             SqlParameter If_Mismatch_in_ResiAdd = new SqlParameter();
             If_Mismatch_in_ResiAdd.SqlDbType = SqlDbType.VarChar;
             If_Mismatch_in_ResiAdd.ParameterName = "@if_Mismatch_in_residence_Address";
             If_Mismatch_in_ResiAdd.Value = txtResidanceAddress.Text.Trim();
             sqlCom.Parameters.Add(If_Mismatch_in_ResiAdd);

             SqlParameter Add_No_ifCont = new SqlParameter();
             Add_No_ifCont.SqlDbType = SqlDbType.VarChar;
             Add_No_ifCont.ParameterName = "@Additional_residence_no_if_contacted";
             Add_No_ifCont.Value = ddlAdditionResi_No.Text.Trim();
             sqlCom.Parameters.Add(Add_No_ifCont);

             SqlParameter Add_Resi_No = new SqlParameter();
             Add_Resi_No.SqlDbType = SqlDbType.VarChar;
             Add_Resi_No.ParameterName = "@Additional_residence_No";
             Add_Resi_No.Value = txtAdditionalNo.Text.Trim();
             sqlCom.Parameters.Add(Add_Resi_No);

             SqlParameter Empl_Name_Conf = new SqlParameter();
             Empl_Name_Conf.SqlDbType = SqlDbType.VarChar;
             Empl_Name_Conf.ParameterName = "@Employer_Name_Confirmed";
             Empl_Name_Conf.Value = ddlEmployerName.Text.Trim();
             sqlCom.Parameters.Add(Empl_Name_Conf);

             SqlParameter Employer_Name = new SqlParameter();
             Employer_Name.SqlDbType = SqlDbType.VarChar;
             Employer_Name.ParameterName = "@Employer_Name";
             Employer_Name.Value = txtEmployerName.Text.Trim();
             sqlCom.Parameters.Add(Employer_Name);

             SqlParameter Emp_Phone_No = new SqlParameter();
             Emp_Phone_No.SqlDbType = SqlDbType.VarChar;
             Emp_Phone_No.ParameterName = "@Employer_Phone_No";
             Emp_Phone_No.Value = txtEmployerPhoneNo.Text.Trim();
             sqlCom.Parameters.Add(Emp_Phone_No);

             SqlParameter Emp_Add_Conf = new SqlParameter();
             Emp_Add_Conf.SqlDbType = SqlDbType.VarChar;
             Emp_Add_Conf.ParameterName = "@Employer_Address_Confirmed";
             Emp_Add_Conf.Value = ddlEmployerAddress.Text.Trim();
             sqlCom.Parameters.Add(Emp_Add_Conf);


             SqlParameter If_Emp_Add_Conf = new SqlParameter();
             If_Emp_Add_Conf.SqlDbType = SqlDbType.VarChar;
             If_Emp_Add_Conf.ParameterName = "@if_Employer_Address_Confirm";
             If_Emp_Add_Conf.Value = txtEmployerAddress.Text.Trim();
             sqlCom.Parameters.Add(If_Emp_Add_Conf);

             SqlParameter Attempt_detail = new SqlParameter();
             Attempt_detail.SqlDbType = SqlDbType.VarChar;
             Attempt_detail.ParameterName = "@Attempt_Details";
             Attempt_detail.Value = Get_AttemptDetails();
             sqlCom.Parameters.Add(Attempt_detail);


             SqlParameter Tele_Name = new SqlParameter();
             Tele_Name.SqlDbType = SqlDbType.VarChar;
             Tele_Name.ParameterName = "@Tele_Caller_Name";
             Tele_Name.Value = ddlTeleCallerName.Text.Trim();
             sqlCom.Parameters.Add(Tele_Name);

             SqlParameter Tele_Remark = new SqlParameter();
             Tele_Remark.SqlDbType = SqlDbType.VarChar;
             Tele_Remark.ParameterName = "@Tele_Caller_Remark";
             Tele_Remark.Value = txtTeleCallerRemark.Text.Trim();
             sqlCom.Parameters.Add(Tele_Remark);

             SqlParameter Super_Name = new SqlParameter();
             Super_Name.SqlDbType = SqlDbType.VarChar;
             Super_Name.ParameterName = "@Supervisor_Name";
             Super_Name.Value = ddlSupervisorName.Text.Trim();
             sqlCom.Parameters.Add(Super_Name);


             SqlParameter Super_Remark = new SqlParameter();
             Super_Remark.SqlDbType = SqlDbType.VarChar;
             Super_Remark.ParameterName = "@Supervisor_Remark";
             Super_Remark.Value = txtSuperVisorRemark.Text.Trim();
             sqlCom.Parameters.Add(Super_Remark);

             SqlParameter WebCheck = new SqlParameter();
             WebCheck.SqlDbType = SqlDbType.VarChar;
             WebCheck.ParameterName = "@Web_Checked";
             WebCheck.Value = ddlWebCheck.Text.Trim();
             sqlCom.Parameters.Add(WebCheck);

             SqlParameter Proprietor_Rec = new SqlParameter();
             Proprietor_Rec.SqlDbType = SqlDbType.VarChar;
             Proprietor_Rec.ParameterName = "@Proprietor_recommendation";
             Proprietor_Rec.Value = ddlProprietor_recomm.Text.Trim();
             sqlCom.Parameters.Add(Proprietor_Rec);

             SqlParameter defaulter_details = new SqlParameter();
             defaulter_details.SqlDbType = SqlDbType.VarChar;
             defaulter_details.ParameterName = "@If_defaulter_details";
             defaulter_details.Value = txtDefault.Text.Trim();
             sqlCom.Parameters.Add(defaulter_details);

             SqlParameter Super_id = new SqlParameter();
             Super_id.SqlDbType = SqlDbType.VarChar;
             Super_id.ParameterName = "@SupervisorName_EmpID";
             Super_id.Value = ddlSupervisorName.Text.Trim();
             sqlCom.Parameters.Add(Super_id);

             SqlParameter TeleCaller_Id = new SqlParameter();
             TeleCaller_Id.SqlDbType = SqlDbType.VarChar;
             TeleCaller_Id.ParameterName = "@TeleCaller_Id";
             TeleCaller_Id.Value = ddlTeleCallerName.SelectedItem.Value.Trim();
             sqlCom.Parameters.Add(TeleCaller_Id);


             int Rowcount = sqlCom.ExecuteNonQuery();
             sqlCon.Close();
             if (Rowcount > 0)
             {
                 lblMessage.CssClass = "UpdateMessage";
                 lblMessage.Text = "Record Successfully Updated";     
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

            string strAttemptDetails="";
            strAttemptDetails = strAttemptDetails + txtDate1stCall.Text.Trim() + "|" + txtTime1stCall.Text.Trim() + "|" + ddlTime1stCall.Text.Trim() + "|" + txtTelNo1stCall.Text.Trim() + "|" + ddlRemarks1stCall.Text.Trim() + "^" + txtDate2ndCall.Text.Trim() + "|" + txtTime2ndCall.Text.Trim() + "|" + ddlTime2ndCall.Text.Trim() + "|" + txtTelNo2ndCall.Text.Trim() + "|" + ddlRemarks2ndCall.Text.Trim() + "^"
    + txtDate3rdCall.Text.Trim() + "|" + txtTime3rdCall.Text.Trim() + "|" + ddlTime3rdCall.Text.Trim() + "|" + txtTelNo3rdCall.Text.Trim() + "|" + ddlRemarks3rdCall.Text.Trim() + "^"
      + txtDate4thCall.Text.Trim() + "|" + txtTime4thCall.Text.Trim() + "|" + ddlTime4thCall.Text.Trim() + "|" + txtTelNo4thCall.Text.Trim() + "|" + ddlRemarks4thCall.Text.Trim() + "^"
         + txtDate5thCall.Text.Trim() + "|" + txtTime5thCall.Text.Trim() + "|" + ddlTime5thCall.Text.Trim() + "|" + txtTelNo5thCall.Text.Trim() + "|" + ddlRemarks5thCall.Text.Trim() + "^"      ;

            return strAttemptDetails;
        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
            return "";

        }
    }
    private void Get_RV_Details_For_GESBI(string pCaseId, int pClientId)
    {
        try
        {

            SqlConnection sqlCon = new SqlConnection(ConfigurationManager.AppSettings["constring"]);

            sqlCon.Open();
            SqlCommand sqlCom = new SqlCommand();
            sqlCom.Connection = sqlCon;
            sqlCom.CommandType = CommandType.StoredProcedure;
            sqlCom.CommandText = "Get_RT_Details_For_GESBI";
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
                Assign_RT_Details(ds.Tables[0]);
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
    private void Assign_RT_Details(DataTable dt)
    {
        try
        {
            txtApplicantionNumber.Text = dt.Rows[0]["Application_Number"].ToString().Trim();
            txtApplicantName.Text = dt.Rows[0]["CustomerName"].ToString().Trim();
            ddlResiTeleNo_Confirmed.SelectedValue = dt.Rows[0]["Residence_No_Confirmed"].ToString().Trim();  
            ddlReasonForResiNo_NotConf.SelectedValue = dt.Rows[0]["Reason_For_Resi_not_Confirm"].ToString().Trim();
            txtResidance_Number.Text = dt.Rows[0]["Residence_Telephone_No"].ToString().Trim();

            ddlPersonSpokenTo.Text = dt.Rows[0]["Person_Spoken"].ToString().Trim();
            txtPersonSpokenTo.Text = dt.Rows[0]["Person_Spoken_To_Name"].ToString().Trim();
            ddlInfo_Provided.SelectedValue = dt.Rows[0]["Information_provided"].ToString().Trim();
            txtRelationWithApplicant.Text = dt.Rows[0]["Relationship_with_Applicant"].ToString().Trim();
            ddlApplicantName_Confirmed.SelectedValue = dt.Rows[0]["Applicant_Name_Confirmed"].ToString().Trim();

            ddlResiStatus.SelectedValue = dt.Rows[0]["RESIDANCE_STATUS"].ToString().Trim();

            string strYCR = dt.Rows[0]["YCR"].ToString().Trim();
            string[] arrYCR_YYMM = strYCR.Split(':');

            if (strYCR == chkYCR.Text.Trim())
            {
                chkYCR.Checked = true;
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

            ddlNoOfFamilyMembers.SelectedValue = dt.Rows[0]["FAMILY_MEMBERS"].ToString().Trim();
            ddlEaringFamilyMembers.SelectedValue = dt.Rows[0]["NO_OF_EARNING_FAMILY_MEMBER"].ToString().Trim();


            string strAPPLICANT_AGE = dt.Rows[0]["APPLICANT_AGE"].ToString().Trim();
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

            ddlResiAddress.SelectedValue = dt.Rows[0]["ADDRESS_MATCH"].ToString().Trim();
            txtResidanceAddress.Text = dt.Rows[0]["if_Mismatch_in_residence_Address"].ToString().Trim();
            ddlAdditionResi_No.SelectedValue = dt.Rows[0]["Additional_residence_no_if_contacted"].ToString().Trim();
            txtAdditionalNo.Text = dt.Rows[0]["APPLICANT_HOME_COUNTRY_PHONE"].ToString().Trim();
            ddlEmployerName.SelectedValue = dt.Rows[0]["Employer_Name_Confirmed"].ToString().Trim();

            txtEmployerName.Text = dt.Rows[0]["COMPANY_NAME"].ToString().Trim();
            txtEmployerPhoneNo.Text = dt.Rows[0]["OFFICE_TELEPHONE"].ToString().Trim();
            ddlEmployerAddress.SelectedValue = dt.Rows[0]["IS_ADD_NOT_CONFIRMED"].ToString().Trim();
            txtEmployerAddress.Text = dt.Rows[0]["OFFICE_ADDRESS"].ToString().Trim();
            ddlTeleCallerName.SelectedValue = dt.Rows[0]["Tele_Caller_Name"].ToString().Trim();
            txtTeleCallerRemark.Text = dt.Rows[0]["TELE_CALLER_REMARK"].ToString().Trim();
            ddlSupervisorName.SelectedValue = dt.Rows[0]["SUPERVISOR_ID"].ToString().Trim();
            txtSuperVisorRemark.Text = dt.Rows[0]["SUPERVISOR_REMARKS"].ToString().Trim();
            ddlWebCheck.SelectedValue = dt.Rows[0]["DIRECTORY_CHECK"].ToString().Trim();
            ddlProprietor_recomm.SelectedValue = dt.Rows[0]["RECOMMENDATION"].ToString().Trim();
            txtDefault.Text = dt.Rows[0]["DEFAULT_AMOUNT"].ToString().Trim();

            ddlApplicantStay_Confirm.SelectedValue = dt.Rows[0]["APPLICANT_STAYED_RESIDANCE"].ToString().Trim();

            GetTeleCallLog();  
                
 
        }
        catch (Exception Ex)
        {
            lblMessage.Text = Ex.Message;
        }
    }
    private void GetTeleCallLog()
    {
        DataSet dsTeleCallLog = new DataSet();

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
 
}
