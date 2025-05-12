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

public partial class CPV_KYC_KYC_CA_VERI : System.Web.UI.Page
{
    CKYCVerification objKYC = new CKYCVerification();
    string verificationType = "CA";
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
            //End     
            hdnTransStart.Value = DateTime.Now.ToString();//"dd/MM/yyyy hh:mm:ss tt");
            if (Context.Request.QueryString["CaseID"] != null && Context.Request.QueryString["CaseID"] != "" && Context.Request.QueryString["VerTypeId"] != null && Context.Request.QueryString["VerTypeId"] != "")
            {
                hidCaseID.Value = Request.QueryString["CaseID"].ToString();
                hidVerificationTypeID.Value = Request.QueryString["VerTypeId"].ToString();
                Session["CaseID"] = Request.QueryString["CaseID"].ToString();

                if ((Request.QueryString["Mode"] != null) && (Request.QueryString["Mode"] != ""))
                {
                    hidMode.Value = Request.QueryString["Mode"].ToString();
                }
                if ((Request.QueryString["VerificationTypeCode"] != null) && (Request.QueryString["VerificationTypeCode"] != ""))
                {
                    hidVerificationTypeCode.Value = Request.QueryString["VerificationTypeCode"].ToString();
                }
                OleDbDataReader oledbCaseDtl;
                oledbCaseDtl = objKYC.GetCASEDetail(hidCaseID.Value, hidVerificationTypeID.Value);
                if (oledbCaseDtl.Read() == true)
                {
                    txtRefNo.Text = oledbCaseDtl["REF_NO"].ToString();
                    txtInitiationDate.Text = oledbCaseDtl["CASE_REC_DATETIME"].ToString();
                    if (!(oledbCaseDtl["CASE_STATUS_ID"].ToString().Trim().Length.Equals(0)))
                        ddlStatus.SelectedValue = oledbCaseDtl["CASE_STATUS_ID"].ToString();
                }
                FillStatus();
                txtDate1.Text = DateTime.Now.ToString("dd/MM/yyyy");
                txtDate2.Text = DateTime.Now.ToString("dd/MM/yyyy");
                txtDate3.Text = DateTime.Now.ToString("dd/MM/yyyy");

                GetKYCVerificationEntry();
                GetVerifierName();
                GetCaseDetail();
                GetTeleCallLog();
                if (hidMode.Value == "View")
                {
                    ReadOnly();
                    LikButtonVisibility();


                }
            }
        }
    }

    private void GetTeleCallLog()
    {
        DataSet dsTeleCallLog = new DataSet();
        string sCaseId = hidCaseID.Value;
        if (sCaseId != "")
        {
            dsTeleCallLog = objKYC.GetTeleCallLogDetail(sCaseId, hidVerificationTypeID.Value);
            if (dsTeleCallLog.Tables[0].Rows.Count > 0)
            {

                for (int i = 0; i < dsTeleCallLog.Tables[0].Rows.Count; i++)
                {
                    if (i == 0)
                    {
                        string sAttemptDateTime = dsTeleCallLog.Tables[0].Rows[i]["ATTEMPT_DATE_TIME"].ToString();
                        string[] arrAttemptDateTime = sAttemptDateTime.Split(' ');
                        txtDate1.Text = Convert.ToDateTime(arrAttemptDateTime[0].ToString()).ToString("dd/MM/yyyy");
                        txtTime1.Text = Convert.ToDateTime(arrAttemptDateTime[1].ToString()).ToString("hh:mm");
                        ddlTimeType1.SelectedValue = arrAttemptDateTime[2].ToString().Trim();
                        txtRemark1.Text = dsTeleCallLog.Tables[0].Rows[i]["REMARK"].ToString();
                        //ddlVerifierName.SelectedValue = dsTeleCallLog.Tables[0].Rows[i]["VERIFIER_ID"].ToString();
                    }
                    if (i == 1)
                    {
                        string sAttemptDateTime = dsTeleCallLog.Tables[0].Rows[i]["ATTEMPT_DATE_TIME"].ToString();
                        string[] arrAttemptDateTime = sAttemptDateTime.Split(' ');
                        txtDate2.Text = Convert.ToDateTime(arrAttemptDateTime[0].ToString()).ToString("dd/MM/yyyy");
                        txtTime2.Text = Convert.ToDateTime(arrAttemptDateTime[1].ToString()).ToString("hh:mm");
                        ddlTimeType2.SelectedValue = arrAttemptDateTime[2].ToString().Trim();

                        txtRemark2.Text = dsTeleCallLog.Tables[0].Rows[i]["REMARK"].ToString();
                        //ddlVerifierName.SelectedValue = dsTeleCallLog.Tables[0].Rows[i]["VERIFIER_ID"].ToString();
                    }
                    if (i == 2)
                    {
                        string sAttemptDateTime = dsTeleCallLog.Tables[0].Rows[i]["ATTEMPT_DATE_TIME"].ToString();
                        string[] arrAttemptDateTime = sAttemptDateTime.Split(' ');
                        txtDate3.Text = Convert.ToDateTime(arrAttemptDateTime[0].ToString()).ToString("dd/MM/yyyy");
                        txtTime3.Text = Convert.ToDateTime(arrAttemptDateTime[1].ToString()).ToString("hh:mm");
                        ddlTimeType3.SelectedValue = arrAttemptDateTime[2].ToString().Trim();

                        txtRemark3.Text = dsTeleCallLog.Tables[0].Rows[i]["REMARK"].ToString();
                        //ddlVerifierName.Text = dsTeleCallLog.Tables[0].Rows[i]["VERIFIER_ID"].ToString();
                    }

                }
            }
        }

    }

    private void GetKYCVerificationEntry()
    {
        OleDbDataReader oledbDR;
        oledbDR = objKYC.GetKYCVerificationEntry(hidCaseID.Value, hidVerificationTypeID.Value);
        if (oledbDR.Read())
        {
            string sTmp1 = oledbDR["veri_date_time"].ToString();
            if (sTmp1 != "")
            {
                string[] arrveridatetime = sTmp1.Split(' ');
                if (arrveridatetime[0].ToString() != "")
                    txtVerifierDate.Text = Convert.ToDateTime(arrveridatetime[0].ToString()).ToString("dd/MM/yyyy");
                if (arrveridatetime[1].ToString() != "")
                    txtVerifierTime.Text = Convert.ToDateTime(arrveridatetime[1].ToString()).ToString("hh:mm");

                ddlVerifierTimeType.SelectedValue = arrveridatetime[2].ToString();
            }
            if (!(oledbDR["Tlele_Remark"].ToString().Trim().Length.Equals(0)))
                txtRemark.Text = oledbDR["Tlele_Remark"].ToString();
                        
            //if (!(oledbDR["Status"].ToString().Trim().Length.Equals(0)))
            //    ddlStatus.SelectedItem.Text = oledbDR["Status"].ToString();

            if (!(oledbDR["Name_Account"].ToString().Trim().Length.Equals(0)))
                txtNameOfAccount.Text = oledbDR["Name_Account"].ToString();

            if (!(oledbDR["Request_No"].ToString().Trim().Length.Equals(0)))
                txtRequestNo.Text = oledbDR["Request_No"].ToString();
            
            if (!(oledbDR["Name_CA_firms"].ToString().Trim().Length.Equals(0)))
                txtNameOfCAFirm.Text = oledbDR["Name_CA_firms"].ToString();

            if (!(oledbDR["Address_CA_Firm"].ToString().Trim().Length.Equals(0)))
                txtAddressOfCAFirm.Text = oledbDR["Address_CA_Firm"].ToString();

            if (!(oledbDR["firm_Exist_Address"].ToString().Trim().Length.Equals(0)))
                ddlDoesFirmExistAtAddress.SelectedValue = oledbDR["firm_Exist_Address"].ToString();
            
            if (!(oledbDR["IS_CA_firm"].ToString().Trim().Length.Equals(0)))
                ddlIsFirmACAFirm.Text = oledbDR["IS_CA_firm"].ToString();

            if (!(oledbDR["Name_Person_CA_Certificate"].ToString().Trim().Length.Equals(0)))
                txtNameOfPersonWhoIssuedCACertificate.Text = oledbDR["Name_Person_CA_Certificate"].ToString();

            if (!(oledbDR["IS_person_case_praticing"].ToString().Trim().Length.Equals(0)))
                ddlIsPersonOneOfPractising.SelectedValue = oledbDR["IS_person_case_praticing"].ToString();
            
            if (!(oledbDR["Person_issued_Cerificate_spoken"].ToString().Trim().Length.Equals(0)))
                ddlWasPersonSpokenTo.SelectedValue = oledbDR["Person_issued_Cerificate_spoken"].ToString();

            if (!(oledbDR["Cerificate_person_confirm"].ToString().Trim().Length.Equals(0)))
                ddlConfirmCACertificateIssued.SelectedValue = oledbDR["Cerificate_person_confirm"].ToString();

            if (!(oledbDR["inconclusive_Reason"].ToString().Trim().Length.Equals(0)))
                txtIfInconclusiveReason.Text = oledbDR["inconclusive_Reason"].ToString();
                        
            if (!(oledbDR["Tele_No_CA_Firm"].ToString().Trim().Length.Equals(0)))
                txtTelNoOfCAFirm.Text = oledbDR["Tele_No_CA_Firm"].ToString();

            if (!(oledbDR["Remark"].ToString().Trim().Length.Equals(0)))
                txtoverallRemark.Text = oledbDR["Remark"].ToString();
        }
        oledbDR.Close();
    }

    private void GetVerifierName()
    {
        OleDbDataReader oledbDR;
        oledbDR = objKYC.GetVerifierID(hidCaseID.Value);
        if (oledbDR.Read())
        {
            if (!(oledbDR["EMP_ID"].ToString().Trim().Length.Equals(0)))
                hidVerifierID.Value = oledbDR["EMP_ID"].ToString();

            if (!(oledbDR["FULLNAME"].ToString().Trim().Length.Equals(0)))
                txtVerifierName.Text = oledbDR["FULLNAME"].ToString();



        }
        oledbDR.Close();
    }

    private void GetCaseDetail()
    {
        OleDbDataReader oledbDR;
        oledbDR = objKYC.GetKYCCaseDetail(hidCaseID.Value);
        if (oledbDR.Read())
        {
            if (!(oledbDR["REF_NO"].ToString().Trim().Length.Equals(0)))
                txtRefNo.Text = oledbDR["REF_NO"].ToString();
            
            if (!(oledbDR["CASE_REC_DATETIME"].ToString().Trim().Length.Equals(0)))
                txtInitiationDate.Text = oledbDR["CASE_REC_DATETIME"].ToString();
            
        }
        oledbDR.Close();
    }

    private void FillStatus()
    {
        DataTable dtStatus = new DataTable();
        dtStatus = objKYC.GetCaseStatus();
        ddlStatus.DataTextField = "STATUS_NAME";
        ddlStatus.DataValueField = "CASE_STATUS_ID";
        ddlStatus.DataSource = dtStatus;
        ddlStatus.DataBind();

        //ListItem lstItem1 = new ListItem("NA", "");
        //ddlStatus.Items.Insert(0, lstItem1);
    }

    private void InsertTeleCallLog()
    {
        try
        {
            ArrayList arrTeleCallLog = new ArrayList();
            ArrayList arrLog1stCall = new ArrayList();
            ArrayList arrLog2ndCall = new ArrayList();
            ArrayList arrLog3rdCall = new ArrayList();

            string strCaseID = hidCaseID.Value;
            objKYC.CaseId = strCaseID;


            objKYC.VerificationTypeId = Request.QueryString["VerTypeId"].ToString();
            CCommon objCom = new CCommon();
            if (txtDate1.Text.Trim() != "" && txtTime1.Text.Trim() != "")
            {
                arrLog1stCall.Clear();
                arrLog1stCall.Add(objCom.strDate(txtDate1.Text.Trim()) + " " + txtTime1.Text.Trim() + " " + ddlTimeType1.SelectedItem.Text.Trim());
                arrLog1stCall.Add(txtRemark1.Text.Trim());

                arrLog1stCall.Add(hidVerifierID.Value);
                arrTeleCallLog.Add(arrLog1stCall);
            }

            if (txtDate2.Text.Trim() != "" && txtTime2.Text.Trim() != "")
            {
                arrLog2ndCall.Clear();
                arrLog2ndCall.Add(objCom.strDate(txtDate2.Text.Trim()) + " " + txtTime2.Text.Trim() + " " + ddlTimeType2.SelectedItem.Text.Trim());
                arrLog2ndCall.Add(txtRemark2.Text.Trim());

                arrLog2ndCall.Add(hidVerifierID.Value);
                arrTeleCallLog.Add(arrLog2ndCall);
            }

            if (txtDate3.Text.Trim() != "" && txtTime3.Text.Trim() != "")
            {
                arrLog3rdCall.Clear();
                arrLog3rdCall.Add(objCom.strDate(txtDate3.Text.Trim()) + " " + txtTime3.Text.Trim() + " " + ddlTimeType3.SelectedItem.Text.Trim());
                arrLog3rdCall.Add(txtRemark3.Text.Trim());

                arrLog3rdCall.Add(hidVerifierID.Value);
                arrTeleCallLog.Add(arrLog3rdCall);
            }


            if (objKYC.InsertTeleCallLog(arrTeleCallLog) == 1)
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
        CKYCVerification objKYC = new CKYCVerification();
        int iCount = 0;
        string sMsg = "";
        CCommon objCom = new CCommon();
        try
        {
            objKYC.CaseId = Request.QueryString["CaseId"].ToString();
            objKYC.VerificationTypeId = hidVerificationTypeID.Value;           
            
            if (txtVerifierDate.Text.Trim() != "" && txtVerifierDate.Text.Trim() != null && txtVerifierTime.Text.Trim() != "" && txtVerifierTime.Text.Trim() != null)
            {
                objKYC.VerifierDatetime = objCom.strDate(txtVerifierDate.Text.Trim()) + " " + txtVerifierTime.Text.Trim() + " " + ddlVerifierTimeType.SelectedValue;
            }
            
            objKYC.TeleRemark = txtRemark.Text.Trim();
            objKYC.TelephoneNoOfCAFirm = txtTelNoOfCAFirm.Text.Trim().ToString();
            objKYC.OverallRemark = txtoverallRemark.Text.Trim();
            string sBusinessEquipSighted = "";
            
            objKYC.BusinessEquipSighted = sBusinessEquipSighted.TrimEnd(',');
            objKYC.VerifierName = txtVerifierName.Text.Trim();
           
           
                objKYC.Status = ddlStatus.SelectedItem.Text.Trim();


                objKYC.CaseStatusId = ddlStatus.SelectedValue.ToString();
            
           
            objKYC.NameOfAccount = txtNameOfAccount.Text.Trim();
            objKYC.RequestNo = txtRequestNo.Text.Trim();
            objKYC.NameOfCAFirm = txtNameOfCAFirm.Text.Trim();
            objKYC.AddressOfCAFirm = txtAddressOfCAFirm.Text.Trim();
            if (ddlDoesFirmExistAtAddress.SelectedIndex != 0)
            {
                objKYC.DoesFirmExistAtAddress = ddlDoesFirmExistAtAddress.SelectedItem.Text.Trim();
            }
            if (ddlIsFirmACAFirm.SelectedIndex != 0)
            {
                objKYC.IsFirmCAFirm = ddlIsFirmACAFirm.SelectedItem.Text.Trim();
            }
            objKYC.NameOfPersonWhoIssuedCACertificate = txtNameOfPersonWhoIssuedCACertificate.Text.Trim();
            if (ddlIsPersonOneOfPractising.SelectedIndex != 0)
            {
                objKYC.IsPersonPractisingCasInFirm = ddlIsPersonOneOfPractising.SelectedItem.Text.Trim();
            }
            if (ddlWasPersonSpokenTo.SelectedIndex != 0)
            {
                objKYC.WasPersonSpokenTo = ddlWasPersonSpokenTo.SelectedItem.Text.Trim();
            }
            if (ddlConfirmCACertificateIssued.SelectedIndex != 0)
            {
                objKYC.ConfirmCACertificateIssued = ddlConfirmCACertificateIssued.SelectedItem.Text.Trim();
            }
            objKYC.InConclusiveReason = txtIfInconclusiveReason.Text.Trim();
            //Added by hemangi kambli on 03/10/2007 
            if (hdnTransStart.Value != "")
                objKYC.TransStart = Convert.ToDateTime(hdnTransStart.Value);
            objKYC.TransEnd = Convert.ToDateTime(DateTime.Now.ToString());//"dd/MM/yyyy hh:mm:ss tt"));
            objKYC.CentreId = Session["CentreId"].ToString();
            objKYC.ProductId = Session["ProductId"].ToString();
            objKYC.ClientId = Session["ClientId"].ToString();
            objKYC.UserId = Session["UserId"].ToString();
            ///------------------------------------------------------

            sMsg = objKYC.InsertKYCVerificationEntry();
            InsertTeleCallLog();
            if (sMsg != "")
            {
                pnlMsg.Visible = true;
                tblMsg.Visible = true;
                lblMsg.Text = sMsg.Trim();
                lblMsg.ForeColor = System.Drawing.Color.Red;
                iCount = 1;
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
            Response.Redirect("KYC_VerificationView.aspx?Msg=" + lblMsg.Text);
        }
        
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("KYC_VerificationView.aspx");
    }

    public void funShowPanel()
    {
        CGet objCGet = new CGet();
        string strClientID = Session["ClientId"].ToString();
        string strActivityID = Session["ActivityId"].ToString();
        string strProductID = Session["ProductId"].ToString();
        string strVerificationType = "19";
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
                    objPlaceHolder = (PlaceHolder)(tblKYCVerification.Rows[0].Cells[0].FindControl(strPlaceHolderName));
                    if (objPlaceHolder != null)
                    {

                        Panel objPanel = new Panel();
                        //objPanel.EnableViewState = false;
                        objPanel = (Panel)(tblKYCVerification.Rows[1].Cells[0].FindControl(strPanelName));
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
                if ( verificationType == arrVerificationTypeCode[i].ToString())
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
            case "CA":
                lbCA.Visible = true;
                break;

        }

    }
    protected void lbRV_Click(object sender, EventArgs e)
    {
        Response.Redirect("KYC_RV_VERI.aspx?CaseID=" + hidCaseID.Value + "&VerTypeId=1&VerificationTypeCode=" + hidVerificationTypeCode.Value + "&Mode=View");
    }
    protected void lbBV_Click(object sender, EventArgs e)
    {
        Response.Redirect("KYC_BUSINESS_VERI.aspx?CaseID=" + hidCaseID.Value + "&VerTypeId=2&VerificationTypeCode=" + hidVerificationTypeCode.Value + "&Mode=View");
    }

    protected void lbCA_Click(object sender, EventArgs e)
    {
        Response.Redirect("KYC_CA_VERI.aspx?CaseID=" + hidCaseID.Value + "&VerTypeId=19&VerificationTypeCode=" + hidVerificationTypeCode.Value + "&Mode=View");
    }

    private void ReadOnly()
    {
        txtRefNo.Enabled=false;
        txtInitiationDate.Enabled=false;
        ddlStatus.Enabled=false;
        txtDate1.Enabled=false;
        txtTime1.Enabled=false;
        ddlTimeType1.Enabled=false;
        txtRemark1.Enabled=false;
        txtDate2.Enabled=false;
        txtTime2.Enabled=false;
        ddlTimeType2.Enabled=false;
        txtRemark2.Enabled=false;
        txtDate3.Enabled=false;
        txtTime3.Enabled=false;
        ddlTimeType3.Enabled=false;
        txtRemark3.Enabled=false;
        txtVerifierDate.Enabled=false;
        txtVerifierTime.Enabled=false;
        ddlVerifierTimeType.Enabled=false;
        txtRemark.Enabled=false;
        txtNameOfAccount.Enabled=false;
        txtRequestNo.Enabled=false;
        txtNameOfCAFirm.Enabled=false;
        txtAddressOfCAFirm.Enabled=false;
        ddlDoesFirmExistAtAddress.Enabled=false;
        ddlIsFirmACAFirm.Enabled=false;
        txtNameOfPersonWhoIssuedCACertificate.Enabled=false;
        ddlIsPersonOneOfPractising.Enabled=false;
        ddlWasPersonSpokenTo.Enabled=false;
        ddlConfirmCACertificateIssued.Enabled=false;
        txtIfInconclusiveReason.Enabled=false;
        txtTelNoOfCAFirm.Enabled=false;                        
        txtVerifierName.Enabled=false;
        txtRefNo.Enabled=false;
        txtInitiationDate.Enabled = false;
        btnCancel.Enabled = false;
        btnSubmit.Enabled = false;
    }
}
