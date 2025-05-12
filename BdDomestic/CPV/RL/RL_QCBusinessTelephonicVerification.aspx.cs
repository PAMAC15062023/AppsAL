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

public partial class CPV_RL_RL_QCBusinessTelephonicVerification : System.Web.UI.Page
{
    CRL_TelephonicVerification objTeleVeri = new CRL_TelephonicVerification();
    CGet objCGet = new CGet();
    CCommon objComm = new CCommon();
    string verificationType = "QBT";

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
            GetBusiCaseDetail();
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
            dsTeleCallLog = objTeleVeri.GetTeleCallLogDetail(sCaseId, hidVerificationTypeID.Value);
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
        oledbDR = objTeleVeri.GetBusiTelephonicVerification(hidCaseID.Value, hidVerificationTypeID.Value);
        if (oledbDR.Read())
        {
            if (!(oledbDR["Type_oF_Phone"].ToString().Trim().Length.Equals(0)))
                txtOfficeTelephoneNo.Text = oledbDR["Type_oF_Phone"].ToString();

            if (!(oledbDR["Office_Name"].ToString().Trim().Length.Equals(0)))
                txtExactCompanyName.Text = oledbDR["Office_Name"].ToString();

            if (!(oledbDR["Office_Address"].ToString().Trim().Length.Equals(0)))
                txtExactCompanyAddress.Text = oledbDR["Office_Address"].ToString();

            if (!(oledbDR["Person_Contacted"].ToString().Trim().Length.Equals(0)))
                txtPersonContacted.Text = oledbDR["Person_Contacted"].ToString();

            if (!(oledbDR["Designation_contacted_person"].ToString().Trim().Length.Equals(0)))
                txtDesignationOfPersonContacted.Text = oledbDR["Designation_contacted_person"].ToString();

            if (!(oledbDR["Designation"].ToString().Trim().Length.Equals(0)))
                txtExactDesignationOftheApplicant.Text = oledbDR["Designation"].ToString();

            if (!(oledbDR["No_year_service"].ToString().Trim().Length.Equals(0)))
                txtNoofyrswiththeCompany.Text = oledbDR["No_year_service"].ToString();

            if (!(oledbDR["Nature_Business"].ToString().Trim().Length.Equals(0)))
                txtNatureOfBusiness.Text = oledbDR["Nature_Business"].ToString();

            if (!(oledbDR["Type_Industry"].ToString().Trim().Length.Equals(0)))
                txtMainlineBusinessoftheCompany.Text = oledbDR["Type_Industry"].ToString();

            if (!(oledbDR["Type_Office"].ToString().Trim().Length.Equals(0)))
                txtCategoryofCompany.Text = oledbDR["Type_Office"].ToString();

            if (!(oledbDR["Office_Address"].ToString().Trim().Length.Equals(0)))
                txtOfficeOrBusinessAddressasperCall.Text = oledbDR["Office_Address"].ToString();

            if (!(oledbDR["Remarks"].ToString().Trim().Length.Equals(0)))
                txtOverallRemarks.Text = oledbDR["Remarks"].ToString();

            if (!(oledbDR["Rating"].ToString().Trim().Length.Equals(0)))
                ddlRating.SelectedValue = oledbDR["Rating"].ToString();

            if (!(oledbDR["In_Bussiness_since"].ToString().Trim().Length.Equals(0)))
                txtInBusinessSince.Text = oledbDR["In_Bussiness_since"].ToString();

            if (!(oledbDR["PERSON_CONFIRM_ADDRESS"].ToString().Trim().Length.Equals(0)))
                ddlPersoncontactedOfficeTeleConfirmsAppWork.SelectedValue = oledbDR["PERSON_CONFIRM_ADDRESS"].ToString();

            if (!(oledbDR["Is_address_same"].ToString().Trim().Length.Equals(0)))
                ddlAddressDifferent.SelectedValue = oledbDR["Is_address_same"].ToString();

            if (!(oledbDR["Unsatisfactory_Reason"].ToString().Trim().Length.Equals(0)))
                txtProvidereasonforunsatisfactoryrating.Text = oledbDR["Unsatisfactory_Reason"].ToString();
//Naresh Start 17/06/08
            if (!(oledbDR["Applicant_Availbility"].ToString().Trim().Length.Equals(0)))
                txtAppAvailable.Text = oledbDR["Applicant_Availbility"].ToString();

            if (!(oledbDR["Dir_Check"].ToString().Trim().Length.Equals(0)))
                txtDirectoryCheck.Text = oledbDR["Dir_Check"].ToString();

            if (!(oledbDR["YEARS_AT_RESIDENCE"].ToString().Trim().Length.Equals(0)))
                txtCurrentResidencePeriod.Text = oledbDR["YEARS_AT_RESIDENCE"].ToString();

            if (!(oledbDR["Office_Ownership"].ToString().Trim().Length.Equals(0)))
                ddlOffOwner.Text = oledbDR["Office_Ownership"].ToString();
//Naresh End   17/06/08


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
                txtArea.Text = oledbDR["Area"].ToString();



        }
        oledbDR.Close();
    }


    private void GetCaseDetail()
    {
        OleDbDataReader oledbDR;
        oledbDR = objTeleVeri.GetCaseDetail(hidCaseID.Value);
        if (oledbDR.Read())
        {
            if (!(oledbDR["FULL_NAME"].ToString().Trim().Length.Equals(0)))
                txtNameoftheApplicant.Text = oledbDR["FULL_NAME"].ToString();

            if (!(oledbDR["REF_NO"].ToString().Trim().Length.Equals(0)))
                txtRefNo.Text = oledbDR["REF_NO"].ToString();


            if (!(oledbDR["CASE_REC_DATETIME"].ToString().Trim().Length.Equals(0)))
                txtDateRecieved.Text = oledbDR["CASE_REC_DATETIME"].ToString();




        }
        oledbDR.Close();
    }


    private void GetBusiCaseDetail()
    {
        OleDbDataReader oledbDR;
        oledbDR = objTeleVeri.GetBusiCaseDetail(hidCaseID.Value);
        if (oledbDR.Read())
        {
            if (!(oledbDR["OFF_PHONE"].ToString().Trim().Length.Equals(0)))
                txtOfficeTelephoneNo.Text = oledbDR["OFF_PHONE"].ToString();

            if (!(oledbDR["OFF_NAME"].ToString().Trim().Length.Equals(0)))
                txtExactCompanyName.Text = oledbDR["OFF_NAME"].ToString();

            if (!(oledbDR["Office_Address"].ToString().Trim().Length.Equals(0)))
                txtExactCompanyAddress.Text = oledbDR["Office_Address"].ToString();



        }
        oledbDR.Close();
    }


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
            objTeleVeri.CaseID = strCaseID;


            objTeleVeri.VerificationType = "QBT";
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

            if (objTeleVeri.InsertTeleCallLog(arrTeleCallLog) == 1)
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
        try
        {
            PropertySet();
            msg = objTeleVeri.InsertBusiTelephonicVerification() ;
            InsertTeleCallLog();
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
            Response.Redirect("RL_QCVerificationView.aspx?Msg=" + lblMessage.Text);
        }
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("RL_QCVerificationView.aspx");
    }

    private void PropertySet()
    {
        objTeleVeri.CaseID = hidCaseID.Value.ToString();
        objTeleVeri.VerificationTypeID = hidVerificationTypeID.Value.ToString();
        objTeleVeri.PersonContacted = txtPersonContacted.Text.Trim().ToString();
        objTeleVeri.DesignationOfPersonContacted = txtDesignationOfPersonContacted.Text.Trim().ToString();
        objTeleVeri.ExactDesignationOfApplicant = txtExactDesignationOftheApplicant.Text.Trim().ToString();
        objTeleVeri.NoOfYearsWithTheCompany = txtNoofyrswiththeCompany.Text.Trim().ToString();
        objTeleVeri.NatureOfBusiness = txtNatureOfBusiness.Text.Trim().ToString();
        objTeleVeri.MainlineBusinessOfTheCompany = txtMainlineBusinessoftheCompany.Text.Trim().ToString();
        objTeleVeri.CategoryOfCompany = txtCategoryofCompany.Text.Trim().ToString();
        objTeleVeri.OfficeBusinessAddressAsPerCall = txtOfficeOrBusinessAddressasperCall.Text.Trim().ToString();
        objTeleVeri.OverallRemarks = txtOverallRemarks.Text.Trim().ToString();
        objTeleVeri.Rating = ddlRating.SelectedValue.ToString();
        objTeleVeri.TelecallersName = ddlTeleCallersName.SelectedValue.ToString();
        objTeleVeri.InBusinessSince = txtInBusinessSince.Text.Trim().ToString();
        objTeleVeri.PersonContactedOffiTeleConfirmsApplicantWorksAddress = ddlPersoncontactedOfficeTeleConfirmsAppWork.SelectedValue.ToString();
        objTeleVeri.AddressDifferent = ddlAddressDifferent.SelectedValue.ToString();
        if (ddlRating.SelectedItem.Text == "UnSatisfactory")
        {
            objTeleVeri.UnsatisfactoryReason = txtProvidereasonforunsatisfactoryrating.Text.Trim().ToString();
        }
        else
        {
            objTeleVeri.UnsatisfactoryReason = "";
        }

        if ((txtDateOfVerification.Text != string.Empty) && (txtVerificationTime.Text != string.Empty))
        {
            objTeleVeri.VerificationDateAndTime = objComm.strDate(txtDateOfVerification.Text.Trim()) + " " + txtVerificationTime.Text.Trim() + " " + ddlVerificationTimeType.SelectedValue.Trim();

        }
        objTeleVeri.Area = txtArea.Text.Trim().ToString();
        //added by hemangi kambli on 07/09/2007--------------
        objTeleVeri.AddedBy = Session["UserId"].ToString();
        objTeleVeri.AddedOn = DateTime.Now;
        objTeleVeri.ModifyBy = Session["UserId"].ToString();
        objTeleVeri.ModifyOn = DateTime.Now;
        ///------------------------------------------------------
        /// //Added by hemangi kambli on 01/10/2007 
        if (hdnTransStart.Value != "")
            objTeleVeri.TransStart = Convert.ToDateTime(hdnTransStart.Value);
        objTeleVeri.TransEnd = Convert.ToDateTime(DateTime.Now.ToString());//"dd/MM/yyyy hh:mm:ss tt"));
        objTeleVeri.CentreId = Session["CentreId"].ToString();
        objTeleVeri.ProductId = Session["ProductId"].ToString();
        objTeleVeri.ClientId = Session["ClientId"].ToString();
        objTeleVeri.UserId = Session["UserId"].ToString();
        ///------------------------------------------------------
        // Sabbani Naresh Start 17/06/08
        objTeleVeri.Applicant_Availbility = txtAppAvailable.Text.Trim().ToString();
        objTeleVeri.Dir_Check = txtDirectoryCheck.Text.Trim().ToString();
        objTeleVeri.Years_At_Residence = txtCurrentResidencePeriod.Text.Trim().ToString();
        objTeleVeri.Type_Office = ddlForSelfEmployedTypeOrganisation.Text.Trim().ToString();
        objTeleVeri.Ownership = ddlOffOwner.Text.Trim().ToString();
        // Sabbani Naresh End 17/06/08
    }
    private void IfIsEditFalse()
    {
        txtPersonContacted.Enabled = false;
        txtDesignationOfPersonContacted.Enabled = false;
        txtExactDesignationOftheApplicant.Enabled = false;
        txtNoofyrswiththeCompany.Enabled = false;
        txtNatureOfBusiness.Enabled = false;
        txtMainlineBusinessoftheCompany.Enabled = false;
        txtCategoryofCompany.Enabled = false;
        txtOfficeOrBusinessAddressasperCall.Enabled = false;
        txtOverallRemarks.Enabled = false;
        ddlRating.Enabled = false;
        ddlTeleCallersName.Enabled = false;
        txtInBusinessSince.Enabled = false;
        ddlPersoncontactedOfficeTeleConfirmsAppWork.Enabled = false;
        ddlAddressDifferent.Enabled = false;
        btnCancel.Enabled = false;
        btnSubmit.Enabled = false;
        txtDateRecieved.Enabled = false;
        txtRefNo.Enabled = false;
        txtArea.Enabled = false;
        txtNameoftheApplicant.Enabled = false;
        txtOfficeTelephoneNo.Enabled = false;
        txtExactCompanyName.Enabled = false;
        txtExactCompanyAddress.Enabled = false;
        txtProvidereasonforunsatisfactoryrating.Enabled = false;
        txtNewInfoObt.Enabled = false;
        txtDateOfVerification.Enabled = false;
        txtVerificationTime.Enabled = false;
        ddlVerificationTimeType.Enabled = false;
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
        txtDate5thCall.Enabled = false;
        txtTime5thCall.Enabled = false;
        ddlTime5thCall.Enabled = false;
        txtTelNo5thCall.Enabled = false;
        ddlRemarks5thCall.Enabled = false;
        ddlRemarks4thCall.Enabled = false;

    }

    private void FillTelecallerName()
    {
        DataTable dtTeleCallerName = new DataTable();
        dtTeleCallerName = objTeleVeri.GetTeleCallerName();
        ddlTeleCallersName.DataTextField = "FULLNAME";
        ddlTeleCallersName.DataValueField = "EMP_ID";
        ddlTeleCallersName.DataSource = dtTeleCallerName;
        ddlTeleCallersName.DataBind();

    }

    private void FillRatingStatus()
    {
        DataTable dtStatus = new DataTable();
        dtStatus = objTeleVeri.GetCaseStatus();
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
                    objPlaceHolder = (PlaceHolder)(tblBusiTelVeri.Rows[0].Cells[0].FindControl(strPlaceHolderName));
                    if (objPlaceHolder != null)
                    {

                        Panel objPanel = new Panel();
                        //objPanel.EnableViewState = false;
                        objPanel = (Panel)(tblBusiTelVeri.Rows[1].Cells[0].FindControl(strPanelName));
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
            case "QRV":
                lbRV.Visible = true;
                break;
            case "QBV":
                lbBV.Visible = true;
                break;
            case "QRT":
                lbRT.Visible = true;
                break;
            case "QBT":
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
        Response.Redirect("RL_QCResidenceVerification.aspx?CaseID=" + hidCaseID.Value + "&VerTypeId=1&VerificationTypeCode=" + hidVerificationTypeCode.Value + "&Mode=View");
    }
    protected void lbBV_Click(object sender, EventArgs e)
    {
        Response.Redirect("RL_QCBusinessVerification.aspx?CaseID=" + hidCaseID.Value + "&VerTypeId=2&VerificationTypeCode=" + hidVerificationTypeCode.Value + "&Mode=View");
    }
    protected void lbRT_Click(object sender, EventArgs e)
    {
        Response.Redirect("RL_QCResidenceTelephonicVerification.aspx?CaseID=" + hidCaseID.Value + "&VerTypeId=4&VerificationTypeCode=" + hidVerificationTypeCode.Value + "&Mode=View");

    }
    protected void lbBT_Click(object sender, EventArgs e)
    {
        Response.Redirect("RL_QCBusinessTelephonicVerification.aspx?CaseID=" + hidCaseID.Value + "&VerTypeId=3&VerificationTypeCode=" + hidVerificationTypeCode.Value + "&Mode=View");

    }
    protected void lbPRV_Click(object sender, EventArgs e)
    {
        Response.Redirect("RL_QCResidenceVerification.aspx?CaseID=" + hidCaseID.Value + "&VerTypeId=10&VerificationTypeCode=" + hidVerificationTypeCode.Value + "&Mode=View");
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

