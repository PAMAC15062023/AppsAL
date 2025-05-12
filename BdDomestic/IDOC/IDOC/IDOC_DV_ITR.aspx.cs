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



public partial class IDOC_IDOC_IDOC_DV_ITR : System.Web.UI.Page
{
    CIDOC_DV_ITR objITR = new CIDOC_DV_ITR();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            hdnTransStart.Value = DateTime.Now.ToString();//"dd/MM/yyyy hh:mm:ss tt");
            if (Session["isAdd"].ToString() != "1")
               Response.Redirect("NoAccess.aspx");

           if (Context.Request.QueryString["Op"] != null && Context.Request.QueryString["Op"] != "")
           {
               if (Request.QueryString["Op"].ToString() == "search")
               {
                   ReadOnlyFields();
               }
               //Added By : Gargi Srivastava
               //Purpose  : For Enableing The buttons visibility false of the Pop up
               //Added Date: 11-Dec-2007
               if (Request.QueryString["Op"].ToString() == "View")
               {
                   btnSubmit.Enabled = false;
                   btnCancel.Enabled = false;
                  
               }
               //End
               
           }
           
            if ((Request.QueryString["CaseID"] != null) && (Request.QueryString["CaseID"] != ""))
            {
               if (Session["isEdit"].ToString() != "1")
                  Response.Redirect("NoAccess.aspx");

                Session["CaseID"] = Request.QueryString["CaseID"].ToString();
                hidCaseID.Value = Request.QueryString["CaseID"].ToString();

            }
            if ((Request.QueryString["VerTypeId"] != null) && (Request.QueryString["VerTypeId"] != ""))
            {
                hidVerificationTypeID.Value = Request.QueryString["VerTypeId"].ToString();
            }
            ddlPANLogicAndCorrectness.Focus();
            GetFEName();
            //GetIDOCVeriAttempts();
            GetITRIDOCCaseDetail();
            GetIDOCVerificationReport();
            GetFieldVerificationOfITR();
            
        }
    }
    private void PropertySet()
    {
         objITR.CaseID = hidCaseID.Value.ToString();
         objITR.VerificationTypeID = hidVerificationTypeID.Value.ToString();
         objITR.PANLogicAndCorrectness=ddlPANLogicAndCorrectness.SelectedValue.ToString();
         objITR.IsIt10DigitsAlphabet = ddlIsIt10DigitsAlphabet.SelectedValue.ToString();
         objITR.AreThe6th7th8thAnd9thDigitsNumeri = ddlAredigitsnumeri.SelectedValue.ToString();
         objITR.IsTheFourthDigit = ddlIsTheFourthDigit.SelectedValue.ToString();
         objITR.ComputationCorrect = ddlComputationCorrect.SelectedValue.ToString();
         objITR.IncomeCalculationsCorrect = ddlIncomeCalculationsCorrect.SelectedValue.ToString();
         objITR.TaxCalculationsCorrect = ddlTaxCalculationsCorrect.SelectedValue.ToString();
         objITR.AlphabetFallsUnderWardCircleRangeJurisdiction = ddlAlphabetFallsUnderWard.SelectedValue.ToString();
         objITR.WhetherOKToSendForFieldVerification = ddlWhetherOKToSendForFieldVerification.SelectedValue.ToString();
         objITR.OtherObservation = txtOtherObservation.Text.ToString();
         objITR.FinalStatus = ddlFinalStatus.SelectedValue.ToString();
         objITR.Remarks = txtRemarks.Text.ToString();
         objITR.AgencyCode = txtAgencyCode.Text.ToString();
         objITR.AddressFallsUnderWard = ddlAddrressFallsUnderWard.SelectedValue.ToString();
         string aa = "Y";
         objITR.IsCase = aa.ToString();

         
        // objITR.FECode = txtFECode.Text.ToString();
         //objITR.NameOfFE = txtNameOfFE.Text.ToString();
         //objITR.CPVAgentsName = txtCPVAgentName.Text.ToString();
         if (txtDateofVerification.Text.Trim() != "")
          objITR.DateOfVerification = txtDateofVerification.Text.Trim();
         //objITR.CPVAgentSign = txtCPVAgentSign.Text.ToString();

      objITR.AddedBy = Session["UserId"].ToString();
      objITR.ModifyBy = Session["UserId"].ToString();
      objITR.AddedOn = DateTime.Now;
      objITR.ModifyOn = DateTime.Now;

      //Added by hemangi kambli on 01/10/2007 
      if (hdnTransStart.Value != "")
          objITR.TransStart = Convert.ToDateTime(hdnTransStart.Value);
      objITR.TransEnd = Convert.ToDateTime(DateTime.Now.ToString());//"dd/MM/yyyy hh:mm:ss tt"));
      objITR.CentreId = Session["CentreId"].ToString();
      objITR.ProductId = Session["ProductId"].ToString();
      objITR.ClientId = Session["ClientId"].ToString();
      objITR.UserId = Session["UserId"].ToString();
      ///------------------------------------------------------
    }
    private void InsertFieldVerificationOfITR()
    {
     try
    {
        ArrayList arrVerificationOfITR = new ArrayList();
        ArrayList arrWardNumber = new ArrayList();
        ArrayList arrSerialNumber = new ArrayList();
        ArrayList arrDateOfFiling = new ArrayList();
        ArrayList arrTotalTaxableIncome = new ArrayList();
        ArrayList arrApplicantsName = new ArrayList();

        string strCaseID = hidCaseID.Value;
        objITR.CaseID = strCaseID;
        objITR.VerificationTypeID = hidVerificationTypeID.Value;

        arrWardNumber.Clear();
        arrWardNumber.Add(lblWardNumber.Text.Trim());
        arrWardNumber.Add(ddlCOMPUTERRECORDSWardNumber.SelectedItem.Text.Trim());
        arrWardNumber.Add(ddlINWARDREGISTERWNWardNumber.SelectedItem.Text.Trim());
        arrWardNumber.Add(ddlBLUEREGISTERWardNumber.SelectedItem.Text.Trim());
        arrWardNumber.Add(ddlINDEXREGISTERWardNumber.SelectedItem.Text.Trim());
        arrWardNumber.Add(ddlORALLYOKBYCLERKWardNumber.SelectedItem.Text.Trim());
        arrVerificationOfITR.Add(arrWardNumber);

        arrSerialNumber.Clear();
        arrSerialNumber.Add(lblSerialNumber.Text.Trim());
        arrSerialNumber.Add(ddlCOMPUTERRECORDSSerialNumber.SelectedItem.Text.Trim());
        arrSerialNumber.Add(ddlINWARDREGISTERWNSerialNumber.SelectedItem.Text.Trim());
        arrSerialNumber.Add(ddlBLUEREGISTERSerialNumber.SelectedItem.Text.Trim());
        arrSerialNumber.Add(ddlINDEXREGISTERSerialNumber.SelectedItem.Text.Trim());
        arrSerialNumber.Add(ddlORALLYOKBYCLERKSerialNumber.SelectedItem.Text.Trim());
        arrVerificationOfITR.Add(arrSerialNumber);

        arrDateOfFiling.Clear();
        arrDateOfFiling.Add(lblDateOfFiling.Text.Trim());
        arrDateOfFiling.Add(ddlCOMPUTERRECORDSDateOfFiling.SelectedItem.Text.Trim());
        arrDateOfFiling.Add(ddlINWARDREGISTERWNDateOfFiling.SelectedItem.Text.Trim());
        arrDateOfFiling.Add(ddlBLUEREGISTERDateOfFiling.SelectedItem.Text.Trim());
        arrDateOfFiling.Add(ddlINDEXREGISTERDateOfFiling.SelectedItem.Text.Trim());
        arrDateOfFiling.Add(ddlORALLYOKBYCLERKDateOfFiling.SelectedItem.Text.Trim());
        arrVerificationOfITR.Add(arrDateOfFiling);

        arrTotalTaxableIncome.Clear();
        arrTotalTaxableIncome.Add(lblTotalTaxableIncome.Text.Trim());
        arrTotalTaxableIncome.Add(ddlCOMPUTERRECORDSTotalTaxableIncome.SelectedItem.Text.Trim());
        arrTotalTaxableIncome.Add(ddlINWARDREGISTERWNTotalTaxableIncome.SelectedItem.Text.Trim());
        arrTotalTaxableIncome.Add(ddlBLUEREGISTERTotalTaxableIncome.SelectedItem.Text.Trim());
        arrTotalTaxableIncome.Add(ddlINDEXREGISTERTotalTaxableIncome.SelectedItem.Text.Trim());
        arrTotalTaxableIncome.Add(ddlORALLYOKBYCLERKTotalTaxableIncome.SelectedItem.Text.Trim());
        arrVerificationOfITR.Add(arrTotalTaxableIncome);

        arrApplicantsName.Clear();
        arrApplicantsName.Add(lblAppName.Text.Trim());
        arrApplicantsName.Add(ddlCOMPUTERRECORDSAppName.SelectedItem.Text.Trim());
        arrApplicantsName.Add(ddlINWARDREGISTERAppName.SelectedItem.Text.Trim());
        arrApplicantsName.Add(ddlBLUEREGISTERAppName.SelectedItem.Text.Trim());
        arrApplicantsName.Add(ddlINDEXREGISTERAppName.SelectedItem.Text.Trim());
        arrApplicantsName.Add(ddlORALLYOKBYCLERKAppName.SelectedItem.Text.Trim());
        arrVerificationOfITR.Add(arrApplicantsName);

        objITR.InsertFieldVerificationOfITR(arrVerificationOfITR);

         

    
    }
    catch(Exception ex)
    {
        throw new Exception("Error Found during Inseration" + ex.Message);
        
    }
       
    }
    //private void GetIDOCVeriAttempts()
    //{
    //    OleDbDataReader oledbDRGet;
    //    oledbDRGet = objITR.GetIDOCATTEMPTS(hidCaseID.Value,hidVerificationTypeID.Value);
    //    if (oledbDRGet.Read())
    //    {
    //        //if (!(oledbDRGet["VERIFIER_ID"].ToString().Trim().Length.Equals(0)))
    //        //   txtNameOfFE.Text = oledbDRGet["VERIFIER_ID"].ToString();

           
    //        if (!(oledbDRGet["Remark"].ToString().Trim().Length.Equals(0)))
    //            txtRemarks.Text = oledbDRGet["Remark"].ToString();


    //    }
    //    oledbDRGet.Close();
    //}
    private void GetFEName()
    {
        string empId = "";
       OleDbDataReader oledbDRGet;
        oledbDRGet = objITR.GetFEName(hidCaseID.Value,hidVerificationTypeID.Value);
        if (oledbDRGet.Read())
        {
            

            if (!(oledbDRGet["FULLNAME"].ToString().Trim().Length.Equals(0)))
                txtNameOfFE.Text = oledbDRGet["FULLNAME"].ToString();

            if (!(oledbDRGet["DATE_TIME"].ToString().Trim().Length.Equals(0)))
                txtDateofVerification.Text = Convert.ToDateTime(oledbDRGet["DATE_TIME"].ToString()).ToString("dd/MM/yyyy");


           

        }
        oledbDRGet.Close();
    }
    private void GetITRIDOCCaseDetail()
    {
        OleDbDataReader oledbDRGet;
        oledbDRGet = objITR.GetIDOCCaseDetail(hidCaseID.Value);
        if (oledbDRGet.Read())
        {
            if (!(oledbDRGet["FULL_NAME"].ToString().Trim().Length.Equals(0)))
                txtApplicantsName.Text = oledbDRGet["FULL_NAME"].ToString();

            if (!(oledbDRGet["REF_NO"].ToString().Trim().Length.Equals(0)))
                txtCDMRefNo.Text = oledbDRGet["REF_NO"].ToString();

            if (!(oledbDRGet["Case_REC_DATETIME"].ToString().Trim().Length.Equals(0)))
                txtDateOfInitiation.Text = Convert.ToDateTime(oledbDRGet["Case_REC_DATETIME"].ToString()).ToString("dd/MM/yyyy hh:mm tt");

            if (!(oledbDRGet["TOTAL_AMOUNT"].ToString().Trim().Length.Equals(0)))
                txtTotalIncomeasperITR.Text = oledbDRGet["TOTAL_AMOUNT"].ToString();

           
        }
        oledbDRGet.Close();

    }
    private void GetIDOCVerificationReport()
    {
        OleDbDataReader oledbDRGet;
        oledbDRGet = objITR.GetIDOCVerificationITR(hidCaseID.Value,hidVerificationTypeID.Value);
        if (oledbDRGet.Read())
        {
            

            if (!(oledbDRGet["Pan_correct"].ToString().Trim().Length.Equals(0)))
                ddlPANLogicAndCorrectness.SelectedValue = oledbDRGet["Pan_correct"].ToString();

            if (!(oledbDRGet["computation_correct"].ToString().Trim().Length.Equals(0)))
                ddlComputationCorrect.SelectedValue = oledbDRGet["computation_correct"].ToString();

             if (!(oledbDRGet["Tax_cal_correct"].ToString().Trim().Length.Equals(0)))
                 ddlTaxCalculationsCorrect.SelectedValue = oledbDRGet["Tax_cal_correct"].ToString();

             if (!(oledbDRGet["OK_field_verification"].ToString().Trim().Length.Equals(0)))
                 ddlWhetherOKToSendForFieldVerification.SelectedValue = oledbDRGet["OK_field_verification"].ToString();

            if (!(oledbDRGet["Other_observation"].ToString().Trim().Length.Equals(0)))
                txtOtherObservation.Text = oledbDRGet["Other_observation"].ToString();

            if (!(oledbDRGet["INCOME_CAL_CORRECT"].ToString().Trim().Length.Equals(0)))
               ddlIncomeCalculationsCorrect.SelectedValue = oledbDRGet["INCOME_CAL_CORRECT"].ToString();

            if (!(oledbDRGet["Is_Fourth_Digit"].ToString().Trim().Length.Equals(0)))
                ddlIsTheFourthDigit.SelectedValue = oledbDRGet["Is_Fourth_Digit"].ToString();

            if (!(oledbDRGet["Are_Digit_Numeric"].ToString().Trim().Length.Equals(0)))
                ddlAredigitsnumeri.SelectedValue = oledbDRGet["Are_Digit_Numeric"].ToString();

            if (!(oledbDRGet["Is_It_Ten_Digit_Alpha"].ToString().Trim().Length.Equals(0)))
                ddlIsIt10DigitsAlphabet.SelectedValue = oledbDRGet["Is_It_Ten_Digit_Alpha"].ToString();

            if (!(oledbDRGet["Alpha_Falls_Under_Ward"].ToString().Trim().Length.Equals(0)))
                ddlAlphabetFallsUnderWard.SelectedValue = oledbDRGet["Alpha_Falls_Under_Ward"].ToString();

            if (!(oledbDRGet["Agency_Name"].ToString().Trim().Length.Equals(0)))
                txtAgencyCode.Text = oledbDRGet["Agency_Name"].ToString();

            if (!(oledbDRGet["FE_VISIT_DATE"].ToString().Trim().Length.Equals(0)))
                txtDateofVerification.Text = oledbDRGet["FE_VISIT_DATE"].ToString();



            if (!(oledbDRGet["CASE_STATUS_ID"].ToString().Trim().Length.Equals(0)))
                ddlFinalStatus.SelectedValue = oledbDRGet["CASE_STATUS_ID"].ToString();


            if (!(oledbDRGet["FE_REMARK"].ToString().Trim().Length.Equals(0)))
                txtRemarks.Text = oledbDRGet["FE_REMARK"].ToString();

            if (!(oledbDRGet["Address_Falls_Under_Ward"].ToString().Trim().Length.Equals(0)))
                ddlAddrressFallsUnderWard.SelectedValue = oledbDRGet["Address_Falls_Under_Ward"].ToString();

        }
        oledbDRGet.Close();

    }
    private void GetFieldVerificationOfITR()
    {
        DataSet dsFieldVerificationOfITR = new DataSet();
        string sCaseId = hidCaseID.Value;
        if (sCaseId != "")
        {
            dsFieldVerificationOfITR = objITR.GetFieldVerificationOfITR(sCaseId, hidVerificationTypeID.Value);
            if (dsFieldVerificationOfITR.Tables[0].Rows.Count > 0)
            {

                for (int i = 0; i < dsFieldVerificationOfITR.Tables[0].Rows.Count; i++)
                {
                    if (i == 0)
                    {

                        ddlCOMPUTERRECORDSWardNumber.SelectedValue = dsFieldVerificationOfITR.Tables[0].Rows[i]["Computer_Record"].ToString();
                        ddlINWARDREGISTERWNWardNumber.SelectedValue = dsFieldVerificationOfITR.Tables[0].Rows[i]["Inward_register"].ToString();
                        ddlBLUEREGISTERWardNumber.SelectedValue = dsFieldVerificationOfITR.Tables[0].Rows[i]["Blue_register"].ToString();
                        ddlINDEXREGISTERWardNumber.SelectedValue = dsFieldVerificationOfITR.Tables[0].Rows[i]["index_register"].ToString();
                        ddlORALLYOKBYCLERKWardNumber.SelectedValue = dsFieldVerificationOfITR.Tables[0].Rows[i]["Orally_by_clerck"].ToString();
                    }
                    if (i == 1)
                    {
                        ddlCOMPUTERRECORDSSerialNumber.SelectedValue = dsFieldVerificationOfITR.Tables[0].Rows[i]["Computer_Record"].ToString();
                        ddlINWARDREGISTERWNSerialNumber.SelectedValue = dsFieldVerificationOfITR.Tables[0].Rows[i]["Inward_register"].ToString();
                        ddlBLUEREGISTERSerialNumber.SelectedValue = dsFieldVerificationOfITR.Tables[0].Rows[i]["Blue_register"].ToString();
                        ddlINDEXREGISTERSerialNumber.SelectedValue = dsFieldVerificationOfITR.Tables[0].Rows[i]["index_register"].ToString();
                        ddlORALLYOKBYCLERKSerialNumber.SelectedValue = dsFieldVerificationOfITR.Tables[0].Rows[i]["Orally_by_clerck"].ToString();
                    }
                    if (i == 2)
                    {
                        ddlCOMPUTERRECORDSDateOfFiling.SelectedValue = dsFieldVerificationOfITR.Tables[0].Rows[i]["Computer_Record"].ToString();
                        ddlINWARDREGISTERWNDateOfFiling.SelectedValue = dsFieldVerificationOfITR.Tables[0].Rows[i]["Inward_register"].ToString();
                        ddlBLUEREGISTERDateOfFiling.SelectedValue = dsFieldVerificationOfITR.Tables[0].Rows[i]["Blue_register"].ToString();
                        ddlINDEXREGISTERDateOfFiling.SelectedValue = dsFieldVerificationOfITR.Tables[0].Rows[i]["index_register"].ToString();
                        ddlORALLYOKBYCLERKDateOfFiling.SelectedValue = dsFieldVerificationOfITR.Tables[0].Rows[i]["Orally_by_clerck"].ToString();
                    }
                    if (i == 3)
                    {
                        ddlCOMPUTERRECORDSTotalTaxableIncome.SelectedValue = dsFieldVerificationOfITR.Tables[0].Rows[i]["Computer_Record"].ToString();
                        ddlINWARDREGISTERWNTotalTaxableIncome.SelectedValue = dsFieldVerificationOfITR.Tables[0].Rows[i]["Inward_register"].ToString();
                        ddlBLUEREGISTERTotalTaxableIncome.SelectedValue = dsFieldVerificationOfITR.Tables[0].Rows[i]["Blue_register"].ToString();
                        ddlINDEXREGISTERTotalTaxableIncome.SelectedValue = dsFieldVerificationOfITR.Tables[0].Rows[i]["index_register"].ToString();
                        ddlORALLYOKBYCLERKTotalTaxableIncome.SelectedValue = dsFieldVerificationOfITR.Tables[0].Rows[i]["Orally_by_clerck"].ToString();
                    }
                    if (i == 4)
                    {
                        ddlCOMPUTERRECORDSAppName.SelectedValue = dsFieldVerificationOfITR.Tables[0].Rows[i]["Computer_Record"].ToString();
                        ddlINWARDREGISTERAppName.SelectedValue = dsFieldVerificationOfITR.Tables[0].Rows[i]["Inward_register"].ToString();
                        ddlBLUEREGISTERAppName.SelectedValue = dsFieldVerificationOfITR.Tables[0].Rows[i]["Blue_register"].ToString();
                        ddlINDEXREGISTERAppName.SelectedValue = dsFieldVerificationOfITR.Tables[0].Rows[i]["index_register"].ToString();
                        ddlORALLYOKBYCLERKAppName.SelectedValue = dsFieldVerificationOfITR.Tables[0].Rows[i]["Orally_by_clerck"].ToString();
                    }
                }
            }
        }

    }
    private string InsertIDOCITRReport()
    {
        string sMsg = "";
        try
        {

           PropertySet();
           sMsg = objITR.InsertIDOCITR();
           return sMsg;


        }
        catch (Exception ex)
        {
            throw new Exception("Error Found During Insertion" + ex.Message);
        }


    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
       
        int iCount = 0;
        string sMsg = "";
        try
        {
            sMsg=InsertIDOCITRReport();
            InsertFieldVerificationOfITR();
            iCount = 1;
            lblMessage.Text = sMsg;
        }
        catch (Exception ex)
        {
            lblMessage.Visible = true;
            lblMessage.ForeColor = System.Drawing.Color.Red;
            lblMessage.Text = "Error:" + ex.Message;
        }
        if (iCount == 1)
        {
            Response.Redirect("IDOC_VerificationView.aspx?Msg=" + lblMessage.Text);
        }
    }
    //private void FillTelecallerName()
    //{
    //    DataTable dtTeleCallerName = new DataTable();
    //    dtTeleCallerName = objITR.GetFEName();
    //    txtNameOfFE.Text = dtTeleCallerName;
    //    //ddlNameOfFE.DataTextField = "FULLNAME";
    //    //ddlNameOfFE.DataValueField = "EMP_ID";
    //    //ddlNameOfFE.DataSource = dtTeleCallerName;
    //    //ddlNameOfFE.DataBind();

    //}

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        if (Context.Request.QueryString["Op"] != null && Context.Request.QueryString["Op"] != "")
        {
            if (Request.QueryString["Op"].ToString() == "search")
            {
                string sCaseId = Request.QueryString["CaseID"].ToString();
                string sVerifyTypeId = Request.QueryString["VerTypeId"].ToString();
                string sName = Request.QueryString["Name"].ToString();
                string sDOB = Request.QueryString["DOB"].ToString();
                string sVerificationTypeId = Request.QueryString["VerificationTypeId"].ToString();
                Response.Redirect("IDOC_DeDupSearch.aspx?CaseID=" + sCaseId + "&VerTypeId=" + sVerifyTypeId + "&Name=" + sName + "&VerificationTypeId=" + sVerificationTypeId + "&DOB=" + sDOB + "&Op=search");
            }
            
        }
        else
            Response.Redirect("IDOC_VerificationView.aspx");
    }
    private void ReadOnlyFields()
    {
           
                txtNameOfFE.ReadOnly = true;
                txtDateofVerification.ReadOnly = true;
                txtApplicantsName.ReadOnly = true;
                txtCDMRefNo.ReadOnly = true;
                txtDateOfInitiation.ReadOnly = true;
                txtTotalIncomeasperITR.ReadOnly = true;
                ddlPANLogicAndCorrectness.Enabled = false;
                ddlComputationCorrect.Enabled = false;
                ddlTaxCalculationsCorrect.Enabled = false;
                ddlWhetherOKToSendForFieldVerification.Enabled = false;
                txtOtherObservation.ReadOnly = true;
                ddlIncomeCalculationsCorrect.Enabled = false;
                ddlIsTheFourthDigit.Enabled = false;
                ddlAredigitsnumeri.Enabled = false;
                ddlIsIt10DigitsAlphabet.Enabled = false;
                ddlAlphabetFallsUnderWard.Enabled = false;
                txtAgencyCode.ReadOnly = true;
                txtDateofVerification.ReadOnly = true;
                ddlFinalStatus.Enabled = false;            
                txtRemarks.ReadOnly=true;

                ddlAddrressFallsUnderWard.Enabled = false;

                ddlCOMPUTERRECORDSWardNumber.Enabled = false;
                ddlINWARDREGISTERWNWardNumber.Enabled = false;
                ddlBLUEREGISTERWardNumber.Enabled = false;
                ddlINDEXREGISTERWardNumber.Enabled = false;
                ddlORALLYOKBYCLERKWardNumber.Enabled = false;

                ddlCOMPUTERRECORDSSerialNumber.Enabled = false;
                ddlINWARDREGISTERWNSerialNumber.Enabled = false;
                ddlBLUEREGISTERSerialNumber.Enabled = false;
                ddlINDEXREGISTERSerialNumber.Enabled = false;
                ddlORALLYOKBYCLERKSerialNumber.Enabled = false;

                ddlCOMPUTERRECORDSDateOfFiling.Enabled = false;
                ddlINWARDREGISTERWNDateOfFiling.Enabled = false;
                ddlBLUEREGISTERDateOfFiling.Enabled = false;
                ddlINDEXREGISTERDateOfFiling.Enabled = false;
                ddlORALLYOKBYCLERKDateOfFiling.Enabled = false;

                ddlCOMPUTERRECORDSTotalTaxableIncome.Enabled = false;
                ddlINWARDREGISTERWNTotalTaxableIncome.Enabled = false;
                ddlBLUEREGISTERTotalTaxableIncome.Enabled = false;
                ddlINDEXREGISTERTotalTaxableIncome.Enabled = false;
                ddlORALLYOKBYCLERKTotalTaxableIncome.Enabled = false;

                ddlCOMPUTERRECORDSAppName.Enabled = false;
                ddlINWARDREGISTERAppName.Enabled = false;
                ddlBLUEREGISTERAppName.Enabled = false;
                ddlINDEXREGISTERAppName.Enabled = false;
                ddlORALLYOKBYCLERKAppName.Enabled = false;
                btnSubmit.Enabled = false;
    }
}
