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

public partial class CPV_RL_RL_REF1Verification : System.Web.UI.Page
{
    string verificationType = "REF1";
    CRL_REF1 objRef = new CRL_REF1();
    CGet objCGet = new CGet();
    CCommon objComm = new CCommon();
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
            GetRef1();
            GetRefCaseDetail();
            FillRatingStatus();
            if (hidMode.Value == "View")
            {
                IfIsEditFalse();
                LikButtonVisibility();


            }

        }

    }
    private void GetRef1()
    {
        OleDbDataReader oledbDR;
        oledbDR = objRef.GetRef(hidCaseID.Value, hidVerificationTypeID.Value);
        if (oledbDR.Read())
        {
            if (!(oledbDR["Person_Contacted"].ToString().Trim().Length.Equals(0)))
                txtNameoftheReferencepersonContacted.Text = oledbDR["Person_Contacted"].ToString();

            if (!(oledbDR["Relationship"].ToString().Trim().Length.Equals(0)))
                txtRelationshipofReferencewithApplicant.Text = oledbDR["Relationship"].ToString();


            if (!(oledbDR["Applicant_Know_Since"].ToString().Trim().Length.Equals(0)))
                txtApplicantKnowSinceMMAndYYbytheReference.Text = oledbDR["Applicant_Know_Since"].ToString();



            if (!(oledbDR["Phone_number"].ToString().Trim().Length.Equals(0)))
                txtPhoneNumberoftheReference.Text = oledbDR["Phone_number"].ToString();

            if (!(oledbDR["Residence_Address"].ToString().Trim().Length.Equals(0)))
                txtReferenceResidenceAddressasperCall.Text = oledbDR["Residence_Address"].ToString();

            if (!(oledbDR["Number_Years_Residence"].ToString().Trim().Length.Equals(0)))
                txtNumberofYearsatResidence.Text = oledbDR["Number_Years_Residence"].ToString();



            if (!(oledbDR["Occupation"].ToString().Trim().Length.Equals(0)))
                txtOccupationType.Text = oledbDR["Occupation"].ToString();

            if (!(oledbDR["Emp_and_Business"].ToString().Trim().Length.Equals(0)))
                txtNameofEmpOrNatureBusiness.Text = oledbDR["Emp_and_Business"].ToString();

            if (!(oledbDR["Designation_applicant"].ToString().Trim().Length.Equals(0)))
                txtDesignationoftheApplicant.Text = oledbDR["Designation_applicant"].ToString();



            if (!(oledbDR["MTNL_Check"].ToString().Trim().Length.Equals(0)))
                ddlMTNLCheck.SelectedValue = oledbDR["MTNL_Check"].ToString();

            if (!(oledbDR["Purpose"].ToString().Trim().Length.Equals(0)))
                txtPurpose.Text = oledbDR["Purpose"].ToString();


            if (!(oledbDR["Rating"].ToString().Trim().Length.Equals(0)))
           
                ddlRating.SelectedValue = oledbDR["Rating"].ToString();


            if (!(oledbDR["Ref_Contacted_Confirms_App_Stay"].ToString().Trim().Length.Equals(0)))

                ddlRefContactedConfirmsAppStayGivenAddress.SelectedValue = oledbDR["Ref_Contacted_Confirms_App_Stay"].ToString();

            if (!(oledbDR["Address_Different"].ToString().Trim().Length.Equals(0)))

                ddlAddressDifferent.SelectedValue = oledbDR["Address_Different"].ToString();


            if (!(oledbDR["Area"].ToString().Trim().Length.Equals(0)))

                txtArea.Text = oledbDR["Area"].ToString();


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

            if (!(oledbDR["Residence_Address_Application"].ToString().Trim().Length.Equals(0)))

                txtResidenceAddressasperApplication.Text = oledbDR["Residence_Address_Application"].ToString();

            if (!(oledbDR["Unsatisfactory_Reason"].ToString().Trim().Length.Equals(0)))
                txtProvidereasonforunsatisfactoryrating.Text = oledbDR["Unsatisfactory_Reason"].ToString();


        }
        oledbDR.Close();
    }


    private void GetRefCaseDetail()
    {
        OleDbDataReader oledbDR;
        oledbDR = objRef.GetCaseDetail(hidCaseID.Value);
        if (oledbDR.Read())
        {
            if (!(oledbDR["FULL_NAME"].ToString().Trim().Length.Equals(0)))
                txtNameoftheApplicant.Text = oledbDR["FULL_NAME"].ToString();

            if (!(oledbDR["REF_NO"].ToString().Trim().Length.Equals(0)))
                txtRefNo.Text = oledbDR["REF_NO"].ToString();


            if (!(oledbDR["CASE_REC_DATETIME"].ToString().Trim().Length.Equals(0)))
                txtDate.Text = oledbDR["CASE_REC_DATETIME"].ToString();



            if (!(oledbDR["Residence_Address"].ToString().Trim().Length.Equals(0)))
                txtResidenceAddressofApplicant.Text = oledbDR["Residence_Address"].ToString();

            
            
        }
        oledbDR.Close();
    }


    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        int iCount = 0;
        string msg = "";
        try
        {
            PropertySet();
            msg = objRef.InsertRef();
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
            Response.Redirect("RL_VerificationView.aspx?Msg=" + lblMessage.Text);
        }
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("RL_VerificationView.aspx");
    }

    private void PropertySet()
    {
        objRef.CaseID = hidCaseID.Value.ToString();
        objRef.VerificationTypeID = hidVerificationTypeID.Value.ToString();
        objRef.NameOfRefPersonContacted = txtNameoftheReferencepersonContacted.Text.Trim().ToString();
        objRef.RelationshipOfReferenceWithApplicant = txtRelationshipofReferencewithApplicant.Text.Trim().ToString();
        objRef.ApplicantKnowSinceByTheReference = txtApplicantKnowSinceMMAndYYbytheReference.Text.Trim().ToString();
        objRef.PhoneNoOfReference = txtPhoneNumberoftheReference.Text.Trim().ToString();
        objRef.ReferenceResidenceAddressAsPerCall = txtReferenceResidenceAddressasperCall.Text.Trim().ToString();
        objRef.NumberOfYearsAtResidence = txtNumberofYearsatResidence.Text.Trim().ToString();
        objRef.OccupationType = txtOccupationType.Text.Trim().ToString();
        objRef.NameOfEmpNatureOfBusiness = txtNameofEmpOrNatureBusiness.Text.Trim().ToString();
        objRef.DesignationOfTheApplicant = txtDesignationoftheApplicant.Text.Trim().ToString();
        objRef.MTNLCheck = ddlMTNLCheck.SelectedValue.ToString();
        objRef.Purpose = txtPurpose.Text.Trim().ToString();
        objRef.Rating = ddlRating.SelectedValue.ToString();
        objRef.RefContactedConfirmsAppStayGivenAddress = ddlRefContactedConfirmsAppStayGivenAddress.SelectedValue.ToString();
        objRef.AddressDifferent = ddlAddressDifferent.SelectedValue.ToString();
        objRef.Area = txtArea.Text.Trim().ToString();
        if ((txtDateOfVerification.Text != string.Empty) && (txtVerificationTime.Text != string.Empty))
        {
            objRef.VerificationDateAndTime = objComm.strDate(txtDateOfVerification.Text.Trim()) + " " + txtVerificationTime.Text.Trim() + " " + ddlVerificationTimeType.SelectedValue.Trim();

        }
        objRef.ResidenceAddressasPerApplication = txtResidenceAddressasperApplication.Text.Trim().ToString();

        if (ddlRating.SelectedItem.Text == "UnSatisfactory")
        {
            objRef.UnsatisfactoryReason = txtProvidereasonforunsatisfactoryrating.Text.Trim().ToString();
        }
        else
        {
            objRef.UnsatisfactoryReason = "";
        }
        
       
        objRef.AddedBy1 = Session["UserId"].ToString();
        objRef.AddedOn1 = DateTime.Now;
        objRef.UpdatedBy1 = Session["UserId"].ToString();
        objRef.UpdatedOn1 = DateTime.Now;
        //Added by hemangi kambli on 01/10/2007 
        if (hdnTransStart.Value != "")
            objRef.TransStart = Convert.ToDateTime(hdnTransStart.Value);
        objRef.TransEnd = Convert.ToDateTime(DateTime.Now.ToString());//"dd/MM/yyyy hh:mm:ss tt"));
        objRef.CentreId = Session["CentreId"].ToString();
        objRef.ProductId = Session["ProductId"].ToString();
        objRef.ClientId = Session["ClientId"].ToString();
        objRef.UserId = Session["UserId"].ToString();
        ///------------------------------------------------------

    }
    private void IfIsEditFalse()
    {
        txtNameoftheReferencepersonContacted.Enabled = false;
        txtRelationshipofReferencewithApplicant.Enabled = false;
        txtApplicantKnowSinceMMAndYYbytheReference.Enabled = false;
        txtPhoneNumberoftheReference.Enabled = false;
        txtReferenceResidenceAddressasperCall.Enabled = false;
        txtNumberofYearsatResidence.Enabled = false;
        txtOccupationType.Enabled = false;
        txtNameofEmpOrNatureBusiness.Enabled = false;
        txtDesignationoftheApplicant.Enabled = false;
        ddlMTNLCheck.Enabled = false;
        txtPurpose.Enabled = false;
        ddlRating.Enabled = false;
        ddlRefContactedConfirmsAppStayGivenAddress.Enabled = false;
        btnCancel.Enabled = false;
        btnSubmit.Enabled = false;
        txtDate.Enabled = false;
        txtArea.Enabled = false;
        txtRefNo.Enabled = false;
        txtNameoftheApplicant.Enabled = false;
        txtResidenceAddressofApplicant.Enabled = false;
        txtResidenceAddressasperApplication.Enabled = false;
        txtProvidereasonforunsatisfactoryrating.Enabled = false;
        txtDateOfVerification.Enabled = false;
        txtVerificationTime.Enabled = false;
        ddlVerificationTimeType.Enabled = false;
    }

    private void FillRatingStatus()
    {
        DataTable dtStatus = new DataTable();
        dtStatus = objRef.GetCaseStatus();
        ddlRating.DataTextField = "STATUS_NAME";
        ddlRating.DataValueField = "CASE_STATUS_ID";
        ddlRating.DataSource = dtStatus;
        ddlRating.DataBind();
        //ListItem liRating = new ListItem("NA", "0");
        //ddlRating.Items.Add(liRating);
        ListItem lstItem1 = new ListItem("NA", "");
        ddlRating.Items.Insert(0, lstItem1);
    }


    public void funShowPanel()
    {
        string strClientID = Session["ClientId"].ToString();
        string strActivityID = Session["ActivityId"].ToString();
        string strProductID = Session["ProductId"].ToString();
        string strVerificationType = "12";
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
                    objPlaceHolder = (PlaceHolder)(tblRef1Veri.Rows[0].Cells[0].FindControl(strPlaceHolderName));
                    if (objPlaceHolder != null)
                    {

                        Panel objPanel = new Panel();
                        //objPanel.EnableViewState = false;
                        objPanel = (Panel)(tblRef1Veri.Rows[1].Cells[0].FindControl(strPanelName));
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

