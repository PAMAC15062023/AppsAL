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

public partial class CPV_RL_RL_ResidenceTelephonicVerification : System.Web.UI.Page
{
    CRL_TelephonicVerification objTeleVer = new CRL_TelephonicVerification();
    CGet objCGet = new CGet();
    CCommon objComm = new CCommon();
    string verificationType = "RT";
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
            txtDate1stCall.Text = DateTime.Now.ToString("dd/MM/yyyy");
            txtDate2ndCall.Text = DateTime.Now.ToString("dd/MM/yyyy");
            txtDate3rdCall.Text = DateTime.Now.ToString("dd/MM/yyyy");
            txtDate4thCall.Text = DateTime.Now.ToString("dd/MM/yyyy");
            txtDate5thCall.Text = DateTime.Now.ToString("dd/MM/yyyy");
            FillRatingStatus();
            GetTelephonicVerification();
            GetCaseDetail();
            GetResiCaseDetail();
            FillTelecallerName();
            GetTeleCallLog();
            if (hidMode.Value == "View")
            {
                IfIsEditFalse();
                LikButtonVisibility();
            }
        }
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
            dsTeleCallLog = objTeleVer.GetTeleCallLogDetail(sCaseId, hidVerificationTypeID.Value);
            if (dsTeleCallLog.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < dsTeleCallLog.Tables[0].Rows.Count; i++)
                {
                    if (i == 0)
                    {
                        string sAttemptDateTime = dsTeleCallLog.Tables[0].Rows[i]["Attempt_Datetime"].ToString();
                        string[] arrAttemptDateTime = sAttemptDateTime.Split(' ');
                        txtDate1stCall.Text = Convert.ToDateTime(arrAttemptDateTime[0].ToString()).ToString("dd/MM/yyyy");
                        txtTime1stCall.Text = Convert.ToDateTime(arrAttemptDateTime[1].ToString()).ToString("hh:mm");
                        ddlTime1stCall.SelectedValue = arrAttemptDateTime[2].ToString();
                        txtTelNo1stCall.Text = dsTeleCallLog.Tables[0].Rows[i]["TELEPHONE_NO"].ToString();
                        ddlRemarks1stCall.SelectedValue = dsTeleCallLog.Tables[0].Rows[i]["Attempt_Remark"].ToString();
                        ddlTeleCallersName.SelectedValue = dsTeleCallLog.Tables[0].Rows[i]["VERIFIER_ID"].ToString();
                    }
                    if (i == 1)
                    {
                        string sAttemptDateTime = dsTeleCallLog.Tables[0].Rows[i]["Attempt_Datetime"].ToString();
                        string[] arrAttemptDateTime = sAttemptDateTime.Split(' ');
                        txtDate2ndCall.Text = Convert.ToDateTime(arrAttemptDateTime[0].ToString()).ToString("dd/MM/yyyy");
                        txtTime2ndCall.Text = Convert.ToDateTime(arrAttemptDateTime[1].ToString()).ToString("hh:mm");
                        ddlTime2ndCall.SelectedValue = arrAttemptDateTime[2].ToString();
                        txtTelNo2ndCall.Text = dsTeleCallLog.Tables[0].Rows[i]["TELEPHONE_NO"].ToString();
                        ddlRemarks2ndCall.SelectedValue = dsTeleCallLog.Tables[0].Rows[i]["Attempt_Remark"].ToString();
                        ddlTeleCallersName.SelectedValue = dsTeleCallLog.Tables[0].Rows[i]["VERIFIER_ID"].ToString();
                    }
                    if (i == 2)
                    {
                        string sAttemptDateTime = dsTeleCallLog.Tables[0].Rows[i]["Attempt_Datetime"].ToString();
                        string[] arrAttemptDateTime = sAttemptDateTime.Split(' ');
                        txtDate3rdCall.Text = Convert.ToDateTime(arrAttemptDateTime[0].ToString()).ToString("dd/MM/yyyy");
                        txtTime3rdCall.Text = Convert.ToDateTime(arrAttemptDateTime[1].ToString()).ToString("hh:mm");
                        ddlTime3rdCall.SelectedValue = arrAttemptDateTime[2].ToString();
                        txtTelNo3rdCall.Text = dsTeleCallLog.Tables[0].Rows[i]["TELEPHONE_NO"].ToString();
                        ddlRemarks3rdCall.SelectedValue = dsTeleCallLog.Tables[0].Rows[i]["Attempt_Remark"].ToString();
                        ddlTeleCallersName.SelectedValue = dsTeleCallLog.Tables[0].Rows[i]["VERIFIER_ID"].ToString();
                    }
                    if (i == 3)
                    {
                        string sAttemptDateTime = dsTeleCallLog.Tables[0].Rows[i]["Attempt_Datetime"].ToString();
                        string[] arrAttemptDateTime = sAttemptDateTime.Split(' ');
                        txtDate4thCall.Text = Convert.ToDateTime(arrAttemptDateTime[0].ToString()).ToString("dd/MM/yyyy");
                        txtTime4thCall.Text = Convert.ToDateTime(arrAttemptDateTime[1].ToString()).ToString("hh:mm");
                        ddlTime4thCall.SelectedValue = arrAttemptDateTime[2].ToString();
                        txtTelNo4thCall.Text = dsTeleCallLog.Tables[0].Rows[i]["TELEPHONE_NO"].ToString();
                        ddlRemarks4thCall.SelectedValue = dsTeleCallLog.Tables[0].Rows[i]["Attempt_Remark"].ToString();
                        ddlTeleCallersName.SelectedValue = dsTeleCallLog.Tables[0].Rows[i]["VERIFIER_ID"].ToString();
                    }
                    if (i == 4)
                    {
                        string sAttemptDateTime = dsTeleCallLog.Tables[0].Rows[i]["Attempt_Datetime"].ToString();
                        string[] arrAttemptDateTime = sAttemptDateTime.Split(' ');
                        txtDate5thCall.Text = Convert.ToDateTime(arrAttemptDateTime[0].ToString()).ToString("dd/MM/yyyy");
                        txtTime5thCall.Text = Convert.ToDateTime(arrAttemptDateTime[1].ToString()).ToString("hh:mm");
                        ddlTime5thCall.SelectedValue = arrAttemptDateTime[2].ToString();
                        txtTelNo5thCall.Text = dsTeleCallLog.Tables[0].Rows[i]["TELEPHONE_NO"].ToString();
                        ddlRemarks5thCall.SelectedValue = dsTeleCallLog.Tables[0].Rows[i]["Attempt_Remark"].ToString();
                        ddlTeleCallersName.SelectedValue = dsTeleCallLog.Tables[0].Rows[i]["VERIFIER_ID"].ToString();
                    }
                }
            }
        }

    }

    private void GetTelephonicVerification()
    {
        OleDbDataReader oledbDR;
        oledbDR = objTeleVer.GetResiTelephonicVerification(hidCaseID.Value, hidVerificationTypeID.Value);
        if (oledbDR.Read())
        {
            if (!(oledbDR["TEL_NO_TYPE_PHONE"].ToString().Trim().Length.Equals(0)))
                //txtResidentPhoneNo.Text = oledbDR["TEL_NO_TYPE_PHONE"].ToString();

            if (!(oledbDR["Address_Confirmed"].ToString().Trim().Length.Equals(0)))
                ddlPersonContactedatResidencetelephoneConfirms.SelectedValue = oledbDR["Address_Confirmed"].ToString();

            if (!(oledbDR["PERSON_CONTACTED"].ToString().Trim().Length.Equals(0)))
                txtPersonContacted.Text = oledbDR["PERSON_CONTACTED"].ToString();

            if (!(oledbDR["Relationship"].ToString().Trim().Length.Equals(0)))
                txtRelationshipwithApplicant.Text = oledbDR["Relationship"].ToString();

            if (!(oledbDR["Address"].ToString().Trim().Length.Equals(0)))
                txtResidenceAddressasperCall.Text = oledbDR["Address"].ToString();

            if (!(oledbDR["YEARS_AT_RESIDENCE"].ToString().Trim().Length.Equals(0)))
                txtNumberofYearsatResidence.Text = oledbDR["YEARS_AT_RESIDENCE"].ToString();

            if (!(oledbDR["Company_name"].ToString().Trim().Length.Equals(0)))
                txtNameOftheEmployer.Text = oledbDR["Company_name"].ToString();

            if (!(oledbDR["Permanent_address"].ToString().Trim().Length.Equals(0)))
                txtPermanentAddress.Text = oledbDR["Permanent_address"].ToString();

            if (!(oledbDR["Verifier_Comments"].ToString().Trim().Length.Equals(0)))
                txtOverallRemarks.Text = oledbDR["Verifier_Comments"].ToString();

            if (!(oledbDR["Verification_status"].ToString().Trim().Length.Equals(0)))
                ddlRating.SelectedValue = oledbDR["Verification_status"].ToString();

            if (!(oledbDR["Staying_Since"].ToString().Trim().Length.Equals(0)))
                txtStayingSince.Text = oledbDR["Staying_Since"].ToString();

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

            if (!(oledbDR["Area"].ToString().Trim().Length.Equals(0)))
                //txtArea.Text = oledbDR["Area"].ToString();

            if (!(oledbDR["Unsatisfactory_Reason"].ToString().Trim().Length.Equals(0)))
                txtProvidereasonforunsatisfactoryrating.Text = oledbDR["Unsatisfactory_Reason"].ToString();
//Naresh 16/06/2008 Start
        if (!(oledbDR["Staying_Whom"].ToString().Trim().Length.Equals(0)))
            txtStaying.Text = oledbDR["Staying_Whom"].ToString();

        if (!(oledbDR["PP_Number"].ToString().Trim().Length.Equals(0)))
            txtPPNo.Text = oledbDR["PP_Number"].ToString();

        if (!(oledbDR["Any_Other_Resi_Phone"].ToString().Trim().Length.Equals(0)))
            txtAnyotherResiPhoneNo.Text = oledbDR["Any_Other_Resi_Phone"].ToString();

        if (!(oledbDR["Applicant_Availbility"].ToString().Trim().Length.Equals(0)))
            txtAppAvailable.Text = oledbDR["Applicant_Availbility"].ToString();

        if (!(oledbDR["Dir_Check"].ToString().Trim().Length.Equals(0)))
            txtDirectoryCheck.Text = oledbDR["Dir_Check"].ToString();

        if (!(oledbDR["Name_of_Applicant_Conf"].ToString().Trim().Length.Equals(0)))
            ddlNameofApplicantConfirmedatgivenPhoneNo.Text  = oledbDR["Name_of_Applicant_Conf"].ToString();

        if (!(oledbDR["Mismatch_Add_Tel"].ToString().Trim().Length.Equals(0)))
            ddlMismatchedInAddTelNo.Text = oledbDR["Mismatch_Add_Tel"].ToString();

//Naresh 16/06/2008 End

            }
        oledbDR.Close();
    }

    private void GetResiCaseDetail()
    {
        OleDbDataReader oledbDR;
        oledbDR = objTeleVer.GetResiCaseDetail(hidCaseID.Value);
        if (oledbDR.Read())
        {
            //if (!(oledbDR["RES_PHONE"].ToString().Trim().Length.Equals(0)))
                //txtResidentPhoneNo.Text = oledbDR["RES_PHONE"].ToString();

            if (!(oledbDR["OFF_NAME"].ToString().Trim().Length.Equals(0)))
                txtNameOftheEmployer.Text = oledbDR["OFF_NAME"].ToString();

            //if (!(oledbDR["Residence_Address"].ToString().Trim().Length.Equals(0)))
                //txtResidenceAddressasperApplication.Text = oledbDR["Residence_Address"].ToString();


        }
        oledbDR.Close();
    }



    private void GetCaseDetail()
    {
        OleDbDataReader oledbDR;
        oledbDR = objTeleVer.GetCaseDetail(hidCaseID.Value);
        if (oledbDR.Read())
        {
            //if (!(oledbDR["FULL_NAME"].ToString().Trim().Length.Equals(0)))
                //txtNameoftheApplicant.Text = oledbDR["FULL_NAME"].ToString();

            //if (!(oledbDR["REF_NO"].ToString().Trim().Length.Equals(0)))
                //txtRefNo.Text = oledbDR["REF_NO"].ToString();


            //if (!(oledbDR["CASE_REC_DATETIME"].ToString().Trim().Length.Equals(0)))
                //txtDateRecieved.Text = oledbDR["CASE_REC_DATETIME"].ToString();



        }
        oledbDR.Close();
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
            ArrayList arrLog4thCall = new ArrayList();
            ArrayList arrLog5thCall = new ArrayList();

            string strCaseID = hidCaseID.Value;
            objTeleVer.CaseID = strCaseID;


            objTeleVer.VerificationType = "RVT";
            CCommon objCom = new CCommon();
            if (txtDate1stCall.Text.Trim() != "" && txtTime1stCall.Text.Trim() != "")
            {
                arrLog1stCall.Clear();
                arrLog1stCall.Add(objCom.strDate(txtDate1stCall.Text.Trim()) + " " + txtTime1stCall.Text.Trim() + " " + ddlTime1stCall.SelectedItem.Text.Trim());
                arrLog1stCall.Add(ddlRemarks1stCall.SelectedValue.ToString());
                arrLog1stCall.Add(txtTelNo1stCall.Text.Trim());
                arrLog1stCall.Add(ddlTeleCallersName.SelectedValue.Trim());
                arrTeleCallLog.Add(arrLog1stCall);
            }

            if (txtDate2ndCall.Text.Trim() != "" && txtTime2ndCall.Text.Trim() != "")
            {
                arrLog2ndCall.Clear();
                arrLog2ndCall.Add(objCom.strDate(txtDate2ndCall.Text.Trim()) + " " + txtTime2ndCall.Text.Trim() + " " + ddlTime2ndCall.SelectedItem.Text.Trim());
                arrLog2ndCall.Add(ddlRemarks2ndCall.SelectedValue.ToString());
                arrLog2ndCall.Add(txtTelNo2ndCall.Text.Trim());
                arrLog2ndCall.Add(ddlTeleCallersName.SelectedValue.Trim());
                arrTeleCallLog.Add(arrLog2ndCall);
            }

            if (txtDate3rdCall.Text.Trim() != "" && txtTime3rdCall.Text.Trim() != "")
            {
                arrLog3rdCall.Clear();
                arrLog3rdCall.Add(objCom.strDate(txtDate3rdCall.Text.Trim()) + " " + txtTime3rdCall.Text.Trim() + " " + ddlTime3rdCall.SelectedItem.Text.Trim());
                arrLog3rdCall.Add(ddlRemarks3rdCall.SelectedValue.ToString());
                arrLog3rdCall.Add(txtTelNo3rdCall.Text.Trim());
                arrLog3rdCall.Add(ddlTeleCallersName.SelectedValue.Trim());
                arrTeleCallLog.Add(arrLog3rdCall);
            }
            if (txtDate4thCall.Text.Trim() != "" && txtTime4thCall.Text.Trim() != "")
            {
                arrLog4thCall.Clear();
                arrLog4thCall.Add(objCom.strDate(txtDate4thCall.Text.Trim()) + " " + txtTime4thCall.Text.Trim() + " " + ddlTime4thCall.SelectedItem.Text.Trim());
                arrLog4thCall.Add(ddlRemarks4thCall.SelectedValue.ToString());
                arrLog4thCall.Add(txtTelNo4thCall.Text.Trim());
                arrLog4thCall.Add(ddlTeleCallersName.SelectedValue.Trim());
                arrTeleCallLog.Add(arrLog4thCall);
            }
            if (txtDate5thCall.Text.Trim() != "" && txtTime5thCall.Text.Trim() != "")
            {
                arrLog5thCall.Clear();
                arrLog5thCall.Add(objCom.strDate(txtDate5thCall.Text.Trim()) + " " + txtTime5thCall.Text.Trim() + " " + ddlTime5thCall.SelectedItem.Text.Trim());
                arrLog5thCall.Add(ddlRemarks5thCall.SelectedValue.ToString());
                arrLog5thCall.Add(txtTelNo5thCall.Text.Trim());
                arrLog5thCall.Add(ddlTeleCallersName.SelectedValue.Trim());
                arrTeleCallLog.Add(arrLog5thCall);
            }

            if (objTeleVer.InsertTeleCallLog(arrTeleCallLog) == 1)
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
        int iCount = 0;
        string msg = "";
       
        int itemcount =ddlRating.Items.Count;
        try
        {

            PropertySet();
            msg = objTeleVer.InsertResiTelephonicVerification();
            InsertTeleCallLog();
            iCount = 1;
            lblMessage.Text = msg;
        }
        catch (Exception ex)
        {
            //lblMessage.Visible = true;
            //lblMessage.ForeColor = System.Drawing.Color.Red;
            //lblMessage.Text = "Error:" + ex.Message;
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

    private void PropertySet()
    {
        objTeleVer.CaseID = hidCaseID.Value.ToString();
        objTeleVer.VerificationTypeID = hidVerificationTypeID.Value.ToString();
        //objTeleVer.ResidencePhoneNo = txtResidentPhoneNo.Text.Trim().ToString();
        objTeleVer.PersonContactedResiTeleConfirmsApplicantStaysAddress = ddlPersonContactedatResidencetelephoneConfirms.SelectedValue.ToString();
        objTeleVer.PersonContacted = txtPersonContacted.Text.Trim().ToString();
        objTeleVer.RelationshipWithApplicant = txtRelationshipwithApplicant.Text.Trim().ToString();
        objTeleVer.ResidenceAddressAsPerCall = txtResidenceAddressasperCall.Text.Trim().ToString();
        objTeleVer.NumberofYearsAtResidence = txtNumberofYearsatResidence.Text.Trim().ToString();
        objTeleVer.NameOfEmployer = txtNameOftheEmployer.Text.Trim().ToString();
        objTeleVer.PermanentAddress = txtPermanentAddress.Text.Trim().ToString();
        objTeleVer.OverallRemarks = txtOverallRemarks.Text.Trim().ToString();
        objTeleVer.Rating = ddlRating.SelectedValue.ToString();
        
       
        objTeleVer.StayingSince = txtStayingSince.Text.Trim().ToString();
        objTeleVer.TelecallersName = ddlTeleCallersName.SelectedValue.ToString();

        if ((txtDateOfVerification.Text != string.Empty) && (txtVerificationTime.Text != string.Empty))
        {
            objTeleVer.VerificationDateAndTime = objComm.strDate(txtDateOfVerification.Text.Trim()) + " " + txtVerificationTime.Text.Trim() + " " + ddlVerificationTimeType.SelectedValue.Trim();

        }
        //objTeleVer.Area = txtArea.Text.Trim().ToString();

        if (ddlRating.SelectedItem.Text == "UnSatisfactory")
        {
            objTeleVer.UnsatisfactoryReason = txtProvidereasonforunsatisfactoryrating.Text.Trim().ToString();
        }
        else
        {
            objTeleVer.UnsatisfactoryReason = "";
        }
        //added by hemangi kambli on 07/09/2007--------------
        objTeleVer.AddedBy = Session["UserId"].ToString();
        objTeleVer.AddedOn = DateTime.Now;
        objTeleVer.ModifyBy = Session["UserId"].ToString();
        objTeleVer.ModifyOn = DateTime.Now;
        //Naresh 14/06/08
        objTeleVer.Staying_Whom = txtStaying.Text.Trim().ToString();

        objTeleVer.PP_Number = txtPPNo.Text.Trim().ToString();
        objTeleVer.Any_Other_Resi_Phone = txtAnyotherResiPhoneNo.Text.Trim().ToString();
        objTeleVer.Applicant_Availbility = txtAppAvailable.Text.Trim().ToString();
        objTeleVer.Dir_Check  = txtDirectoryCheck.Text.Trim().ToString();
        objTeleVer.Name_of_Applicant_Conf = ddlNameofApplicantConfirmedatgivenPhoneNo.Text.Trim().ToString();
        objTeleVer.Mismatch_Add_Tel=ddlMismatchedInAddTelNo.Text.Trim().ToString();
        //PP_Number,Any_Other_Resi_Phone,Applicant_Availbility,Dir_Check,Name_of_Applicant_Conf,Mismatch_Add_Tel
        ///------------------------------------------------------
        /// //Added by hemangi kambli on 01/10/2007 
        if (hdnTransStart.Value != "")
            objTeleVer.TransStart = Convert.ToDateTime(hdnTransStart.Value);
        objTeleVer.TransEnd = Convert.ToDateTime(DateTime.Now.ToString());//"dd/MM/yyyy hh:mm:ss tt"));
        objTeleVer.CentreId = Session["CentreId"].ToString();
        objTeleVer.ProductId = Session["ProductId"].ToString();
        objTeleVer.ClientId = Session["ClientId"].ToString();
        objTeleVer.UserId = Session["UserId"].ToString();
        ///------------------------------------------------------

    }

    private void IfIsEditFalse()
    {
        //txtResidentPhoneNo.Enabled = false;
        ddlPersonContactedatResidencetelephoneConfirms.Enabled = false;
        txtPersonContacted.Enabled = false;
        txtRelationshipwithApplicant.Enabled = false;
        txtResidenceAddressasperCall.Enabled = false;
        txtNumberofYearsatResidence.Enabled = false;
        txtNameOftheEmployer.Enabled = false;
        txtPermanentAddress.Enabled = false;
        txtOverallRemarks.Enabled = false;
        ddlRating.Enabled = false;
        txtStayingSince.Enabled = false;
        ddlTeleCallersName.Enabled = false;
        txtDateOfVerification.Enabled = false;
        txtVerificationTime.Enabled = false;
        btnCancel.Enabled = false;
        btnSubmit.Enabled = false;
        //txtResidenceAddressasperApplication.Enabled = false;
        //txtNameoftheApplicant.Enabled = false;
        //txtDateRecieved.Enabled = false;
        //txtRefNo.Enabled = false;
        //txtArea.Enabled = false;
        txtDate1stCall.Enabled = false;
        txtTime1stCall.Enabled = false;
        ddlTime1stCall.Enabled = false;
        txtTelNo1stCall.Enabled = false;
        ddlRemarks1stCall.Enabled = false;
        txtDate2ndCall.Enabled = false;
        txtTime2ndCall.Enabled = false;
        ddlTime2ndCall.Enabled = false;
        txtTelNo2ndCall.Enabled = false;
        ddlRemarks2ndCall.Enabled = false;
        txtDate3rdCall.Enabled = false;
        txtTime3rdCall.Enabled = false;
        ddlTime3rdCall.Enabled = false;
        txtTelNo3rdCall.Enabled = false;
        ddlRemarks3rdCall.Enabled = false;
        txtDate4thCall.Enabled = false;
        txtTime4thCall.Enabled = false;
        ddlTime4thCall.Enabled = false;
        txtTelNo4thCall.Enabled = false;
        txtNewInfoObt.Enabled = false;
        txtDate5thCall.Enabled = false;
        txtTime5thCall.Enabled = false;
        ddlTime5thCall.Enabled = false;
        txtTelNo5thCall.Enabled = false;
        ddlRemarks5thCall.Enabled = false;
        ddlRemarks4thCall.Enabled = false;
        txtProvidereasonforunsatisfactoryrating.Enabled = false;

    }

    private void FillTelecallerName()
    {
        DataTable dtTeleCallerName = new DataTable();
        dtTeleCallerName = objTeleVer.GetTeleCallerName();
        ddlTeleCallersName.DataTextField = "FULLNAME";
        ddlTeleCallersName.DataValueField = "EMP_ID";
        ddlTeleCallersName.DataSource = dtTeleCallerName;
        ddlTeleCallersName.DataBind();

    }

    private void FillRatingStatus()
    {
        DataTable dtStatus = new DataTable();
        dtStatus = objTeleVer.GetCaseStatus();
        ddlRating.DataTextField = "STATUS_NAME";
        ddlRating.DataValueField = "CASE_STATUS_ID";
        ddlRating.DataSource = dtStatus;
        ddlRating.DataBind();
       
        ListItem lstItem1 = new ListItem("NA", "");
        ddlRating.Items.Insert(0, lstItem1);
    }
    

     public void funShowPanel()
    {
        string strClientID = Session["ClientId"].ToString();
        string strActivityID = Session["ActivityId"].ToString();
        string strProductID = Session["ProductId"].ToString();
        string strVerificationType = "4";
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
                    objPlaceHolder = (PlaceHolder)(tblResiTelVeri.Rows[0].Cells[0].FindControl(strPlaceHolderName));
                    if (objPlaceHolder != null)
                    {

                        Panel objPanel = new Panel();
                        //objPanel.EnableViewState = false;
                        objPanel = (Panel)(tblResiTelVeri.Rows[1].Cells[0].FindControl(strPanelName));
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
