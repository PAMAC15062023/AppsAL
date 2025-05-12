
/*----------------------------------------------------------------------------------------
Scope of Program	:	
File Name			:	IDOC_CaseEntry.aspx.cs
Create By			:	Hemangi Kambli
Create Date		    :	5th April 2007
Remarks 		    :	This class is used for IDOCCaseEntry.
						
----------------------------------------------------------------------------------------*/
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

public partial class IDOC_IDOC_CaseEntry : System.Web.UI.Page
{
    CIDOC objIDoc = new CIDOC();
    DataSet dsIDoc = new DataSet();
    DataSet dsVerification = new DataSet();
    CCommon objCmn = new CCommon();

    protected void Page_Load(object sender, EventArgs e)
    {

        ////////////////Addjavascript_Control();
        txtRefNo.Focus();
        txtRecDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
        txtRecTime.Text = DateTime.Now.ToString("hh:mm");
        ddlTimeType.SelectedValue = DateTime.Now.ToString("tt");
        
        if (!IsPostBack)
        {
            
            if (Session["isAdd"].ToString() != "1")
                Response.Redirect("NoAccess.aspx");
            
            string sActivityID = Session["ActivityId"].ToString();
            chkVerDoc.DataSource = objIDoc.GetCaseVerificationType(sActivityID);
            chkVerDoc.DataValueField = "Verification_type_Id";
            chkVerDoc.DataTextField = "Verification_type_code";
            chkVerDoc.DataBind();

         

            FillReferenceProduct();

            if (Context.Request.QueryString["CaseID"] != null && Context.Request.QueryString["CaseID"] != "")
            {
                if (Session["isEdit"].ToString() != "1")
                    Response.Redirect("NoAccess.aspx");
                string sCaseId = Request.QueryString["CaseID"].ToString();
                if (sCaseId != "")
                {
                    dsIDoc = objIDoc.GetIDOCCaseEntry(sCaseId,Session["CentreId"].ToString(), Session["ClientId"].ToString());
                    dsVerification = objIDoc.GetAllVerificationId(sCaseId);

                    if (dsIDoc.Tables[0].Rows.Count > 0)
                    {
                        if (dsVerification.Tables[0].Rows.Count > 0)
                        {
                            for (int i = 0; i < dsVerification.Tables[0].Rows.Count; i++)
                            {
                                foreach (ListItem li in chkVerDoc.Items)
                                {
                                    if (li.Value == dsVerification.Tables[0].Rows[i][0].ToString())
                                        li.Selected = true;
                                }
                            }
                        }
                        string sTmp = dsIDoc.Tables[0].Rows[0]["CASE_REC_DATETime"].ToString();
                        if (sTmp != "")
                        {
                            string[] arrRecDateTime = sTmp.Split(' ');
                            if(arrRecDateTime[0].ToString()!="")
                                txtRecDate.Text = Convert.ToDateTime(arrRecDateTime[0].ToString()).ToString("dd/MM/yyyy");
                            if(arrRecDateTime[1].ToString()!="")
                                txtRecTime.Text = Convert.ToDateTime(arrRecDateTime[1].ToString()).ToString("hh:mm");
                            ddlTimeType.SelectedValue = arrRecDateTime[2].ToString();
                        }
                        
                        txtAsstYear.Text=dsIDoc.Tables[0].Rows[0]["ASST_YEAR"].ToString();
                        txtReceiptNo.Text = dsIDoc.Tables[0].Rows[0]["RECEIPT_NO"].ToString();
                        txtWard.Text = dsIDoc.Tables[0].Rows[0]["Ward"].ToString();
                        txtRefNo.Text = dsIDoc.Tables[0].Rows[0]["Ref_No"].ToString();
                        ddlTitle.SelectedValue = dsIDoc.Tables[0].Rows[0]["Title"].ToString();
                        txtFirstNm.Text = dsIDoc.Tables[0].Rows[0]["First_Name"].ToString();
                        txtMiddleNm.Text = dsIDoc.Tables[0].Rows[0]["Middle_Name"].ToString();
                        txtLastNm.Text = dsIDoc.Tables[0].Rows[0]["Last_Name"].ToString();
                        txtCompName.Text = dsIDoc.Tables[0].Rows[0]["OFF_NAME"].ToString();

                        if (dsIDoc.Tables[0].Rows[0]["DOB"].ToString() != "")
                            //txtDOB.Text = Convert.ToDateTime(dsIDoc.Tables[0].Rows[0]["DOB"].ToString()).ToString("dd-MMM-yyyy");
                            txtDOB.Text = dsIDoc.Tables[0].Rows[0]["DOB"].ToString();

                        //txtBankRefNo.Text = dsIDoc.Tables[0].Rows[0]["Bank_Ref_No"].ToString();

                        txtResAdd1.Text = dsIDoc.Tables[0].Rows[0]["RES_ADD_LINE_1"].ToString();
                        txtResAdd2.Text = dsIDoc.Tables[0].Rows[0]["RES_ADD_LINE_2"].ToString();
                        txtResAdd3.Text = dsIDoc.Tables[0].Rows[0]["RES_ADD_LINE_3"].ToString();
                        txtResCity.Text = dsIDoc.Tables[0].Rows[0]["RES_CITY"].ToString();
                        txtResPhone.Text = dsIDoc.Tables[0].Rows[0]["RES_PHONE"].ToString();
                        txtResPin.Text = dsIDoc.Tables[0].Rows[0]["RES_PIN_CODE"].ToString();
                        txtLandMark.Text = dsIDoc.Tables[0].Rows[0]["RES_LAND_MARK"].ToString();
                        txtOffAdd1.Text = dsIDoc.Tables[0].Rows[0]["OFF_ADD_LINE_1"].ToString();
                        txtOffAdd2.Text = dsIDoc.Tables[0].Rows[0]["OFF_ADD_LINE_2"].ToString();
                        txtOffAdd3.Text = dsIDoc.Tables[0].Rows[0]["OFF_ADD_LINE_3"].ToString();
                        txtOffCity.Text = dsIDoc.Tables[0].Rows[0]["OFF_CITY"].ToString();
                        txtOffPhone.Text = dsIDoc.Tables[0].Rows[0]["OFF_PHONE"].ToString();
                        txtOffExtn.Text = dsIDoc.Tables[0].Rows[0]["OFF_EXTN"].ToString();
                        txtOffPin.Text = dsIDoc.Tables[0].Rows[0]["OFF_PIN_CODE"].ToString();
                        txtDesgn.Text = dsIDoc.Tables[0].Rows[0]["DESIGNATION"].ToString();
                        txtDept.Text = dsIDoc.Tables[0].Rows[0]["DEPARTMENT"].ToString();
                        txtOccupation.Text = dsIDoc.Tables[0].Rows[0]["OCCUPATION"].ToString();
                        txtPanNo.Text = dsIDoc.Tables[0].Rows[0]["Pan_No"].ToString();     
                        /*----------------------------------------------------------------------------------------
           
                            Modified By			:	Gargi Srivastava
                            Modified Date		:	22 May 2007
                
                         ----------------------------------------------------------------------------------------*/

                        txtName.Text = dsIDoc.Tables[0].Rows[0]["FULL_NAME"].ToString();
                        ddlReferenceProduct.SelectedValue = dsIDoc.Tables[0].Rows[0]["REF_PRODUCT_ID"].ToString();
                        txtITO.Text = dsIDoc.Tables[0].Rows[0]["ITO"].ToString();
                        txtIncomeTaxAmt.Text = dsIDoc.Tables[0].Rows[0]["TAX_AMOUNT"].ToString();
                        txtTotalAmt.Text = dsIDoc.Tables[0].Rows[0]["TOTAL_AMOUNT"].ToString();
                        txtBankName.Text = dsIDoc.Tables[0].Rows[0]["BANK_NAME"].ToString();
                        txtBankAddress.Text = dsIDoc.Tables[0].Rows[0]["BANK_ADDRESS"].ToString();
                        txtBankPin.Text = dsIDoc.Tables[0].Rows[0]["BANK_PIN"].ToString();
                        txtBankCity.Text = dsIDoc.Tables[0].Rows[0]["BANK_CITY"].ToString();
                        ddlVerificationCharges.SelectedValue = dsIDoc.Tables[0].Rows[0]["VERIFICATION_CHARGES"].ToString();
                        txtRegistrationNumberOfVehicle.Text = dsIDoc.Tables[0].Rows[0]["Vehicle_Registration_Number"].ToString();
                        txtRTOOffice.Text = dsIDoc.Tables[0].Rows[0]["RTO_Office"].ToString();

                    }
                }
            }
        }
    }

    #region ClearControl()
    private void ClearControl()
    {
        if (chkVerDoc.Items.Count > 0)
        {
            foreach (ListItem li in chkVerDoc.Items)
            {
                li.Selected = false;
            }
        }
        
        ddlTimeType.SelectedIndex = 0;
        ddlTitle.SelectedIndex = 0;
        txtOffCity.Text = "";
        txtRefNo.Text = "";
       
        txtResAdd1.Text = "";
        txtResAdd2.Text = "";
        txtResAdd3.Text = "";
        txtResCity.Text = "";
        txtResPin.Text = "";
        txtResPhone.Text = "";
        txtOffAdd1.Text = "";
        txtOffAdd2.Text = "";
        txtOffAdd3.Text = "";
        txtOffPhone.Text = "";
        txtOffPin.Text = "";
        txtOffExtn.Text = "";
        txtLandMark.Text = "";
        txtDept.Text = "";
        txtDesgn.Text = "";
        txtDOB.Text = "";
        txtFirstNm.Text = "";
        txtLastNm.Text = "";
        txtMiddleNm.Text = "";
        txtOccupation.Text = "";
        //txtBankRefNo.Text = "";
        txtWard.Text = "";
        ddlVerificationCharges.SelectedIndex = 0;
        txtRTOOffice.Text = "";
        txtRegistrationNumberOfVehicle.Text = "";
        txtITO.Text = "";
        txtTotalAmt.Text = "";
        txtIncomeTaxAmt.Text = "";
        txtBankName.Text = "";
        txtBankAddress.Text = "";
        txtBankCity.Text = "";
        txtBankPin.Text = "";
        txtAsstYear.Text = "";
        txtReceiptNo.Text = "";
        txtCompName.Text = "";
        txtPanNo.Text = ""; 
    }
    #endregion ClearControl()

    private void Addjavascript_Control()
    {
        btnSubmit.Attributes.Add("onclick", "javascript:return chkPanNo()");  
    
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        int iCount = 0;
        bool bValid = true;
        try
        {
            ArrayList arrVerType = new ArrayList();
            string sVerificationTypeCode = "";
            if (chkVerDoc.Items.Count > 0)
            {
                foreach (ListItem li in chkVerDoc.Items)
                {
                    if (li.Selected == true)
                    {
                        arrVerType.Add(li.Value);
                        sVerificationTypeCode += li.Text.Trim() + "+";
                    }
                }
            }
            objIDoc.VerificationTypeCode = sVerificationTypeCode.TrimEnd('+');
            if (objIDoc.VerificationTypeCode == "")
                bValid = false;

            //if (txtDOB.Text.Trim() != "")
            //    objIDoc.DOB = Convert.ToDateTime(txtDOB.Text.Trim());
            //else
            //    objIDoc.DOB = null;


            /*----------------------------------------------------------------------------------------
           
                Modified By			:	Gargi Srivastava
                Modified Date		:	22 May 2007
                
            ----------------------------------------------------------------------------------------*/
            if (bValid == true)
            {
                objIDoc.CentreId = Session["CentreId"].ToString();
                objIDoc.ClusterId = Session["ClusterId"].ToString();
                objIDoc.ClientId = Session["ClientId"].ToString();
                objIDoc.RefNo = txtRefNo.Text.Trim();
                //objIDoc.BankRefNo = txtBankRefNo.Text.Trim();
                objIDoc.ITO = txtITO.Text.Trim();

                if (txtRecDate.Text.Trim() != "" && txtRecTime.Text.Trim() != "")
                    objIDoc.ReceivedDateTime = Convert.ToDateTime(objCmn.strDate(txtRecDate.Text.Trim()) + " " + txtRecTime.Text.Trim() + " " + ddlTimeType.SelectedItem.Text.Trim());

                objIDoc.Title = ddlTitle.SelectedValue.ToString();
                objIDoc.FirstName = txtFirstNm.Text.Trim();
                objIDoc.MiddleName = txtMiddleNm.Text.Trim();
                objIDoc.LastName = txtLastNm.Text.Trim();
                objIDoc.FullName = txtFirstNm.Text.Trim() + " " + txtMiddleNm.Text.Trim() + " " + txtLastNm.Text.Trim();


                if (txtDOB.Text.Trim() != "")
                    //objIDoc.DateOfBirth = Convert.ToDateTime(txtDOB.Text.Trim());
                    objIDoc.DOB = txtDOB.Text.Trim();


                objIDoc.ResAdd1 = txtResAdd1.Text.Trim();
                objIDoc.ResAdd2 = txtResAdd2.Text.Trim();
                objIDoc.ResAdd3 = txtResAdd3.Text.Trim();
                objIDoc.ResCity = txtResCity.Text.Trim();
                objIDoc.ResPin = txtResPin.Text.Trim();
                objIDoc.ResLandMark = txtLandMark.Text.Trim();
                objIDoc.ResPhone = txtResPhone.Text.Trim();
                objIDoc.OfficeName = txtCompName.Text.Trim();
                objIDoc.OfficeAdd1 = txtOffAdd1.Text.Trim();
                objIDoc.OfficeAdd2 = txtOffAdd2.Text.Trim();
                objIDoc.OfficeAdd3 = txtOffAdd3.Text.Trim();
                objIDoc.OfficeCity = txtOffCity.Text.Trim();
                objIDoc.OfficePin = txtOffPin.Text.Trim();
                objIDoc.OfficePhone = txtOffPhone.Text.Trim();
                objIDoc.OfficeExtn = txtOffExtn.Text.Trim();
                objIDoc.Designation = txtDesgn.Text.Trim();
                objIDoc.Department = txtDept.Text.Trim();
                objIDoc.Occupation = txtOccupation.Text.Trim();
                objIDoc.RefProductID = ddlReferenceProduct.SelectedValue.Trim();
                objIDoc.Ward = txtWard.Text.Trim();
                objIDoc.TotalAmount = txtTotalAmt.Text.Trim();
                objIDoc.TaxAmount = txtIncomeTaxAmt.Text.Trim();
                objIDoc.AddedBy = Session["UserId"].ToString();
                objIDoc.AddedOn = DateTime.Now;
                objIDoc.ModifyBy = Session["UserId"].ToString();
                objIDoc.ModifyOn = DateTime.Now;

                objIDoc.BankName = txtBankName.Text.Trim();
                objIDoc.BankAddress = txtBankAddress.Text.Trim();
                objIDoc.BankPin = txtBankPin.Text.Trim();
                objIDoc.BankCity = txtBankCity.Text.Trim();
                objIDoc.VerificationCharges = ddlVerificationCharges.SelectedValue.ToString();
                objIDoc.RegistrationNumberOfVechicle = txtRegistrationNumberOfVehicle.Text.Trim();
                objIDoc.RTOOffice = txtRTOOffice.Text.Trim();
                objIDoc.AsstYear = txtAsstYear.Text.Trim();
                objIDoc.ReceiptNo = txtReceiptNo.Text.Trim();
                objIDoc.PanNo = txtPanNo.Text.Trim();    



                //paramIDOC[18] = new OleDbParameter("@OfficeName", OleDbType.VarChar);
                //paramIDOC[18].Value = OfficeName;



                //paramIDOC[30] = new OleDbParameter("@RefCaseID", OleDbType.VarChar);
                //paramIDOC[30].Value = RefCaseID;




                //paramIDOC[34] = new OleDbParameter("@AddedBy", OleDbType.VarChar);
                //paramIDOC[34].Value = Remark;

                //paramIDOC[35] = new OleDbParameter("@AddedOn", OleDbType.DBTimeStamp);
                //paramIDOC[35].Value = CaseStatusID;



                OleDbDataReader oledbRead;
                if (Context.Request.QueryString["CaseID"] != null && Context.Request.QueryString["CaseID"] != "")
                {
                    oledbRead = objIDoc.GetIDOCCase(Request.QueryString["CaseID"].ToString());
                    if (oledbRead.Read() == false)
                    {
                        if (objIDoc.InsertIDOCCaseEntry(arrVerType, Session["Prefix"].ToString()) == 1)
                        {
                            lblMsg.Visible = true;
                            lblMsg.ForeColor = System.Drawing.Color.Red;
                            lblMsg.Text = "Record added successfully.";
                            ClearControl();
                            if (Request.QueryString["CaseID"].ToString() == "Add")
                                iCount = 1;
                        }
                    }
                    else
                    {

                        if (objIDoc.UpdateIDOCCaseEntry(arrVerType, Request.QueryString["CaseID"].ToString()) == 1)
                        {
                            lblMsg.ForeColor = System.Drawing.Color.Red;
                            lblMsg.Visible = true;
                            lblMsg.Text = "Record updated successfully.";
                            ClearControl();
                            iCount = 1;
                        }
                    }
                    oledbRead.Close();
                }
                else
                {
                    if (objIDoc.InsertIDOCCaseEntry(arrVerType, Session["Prefix"].ToString()) == 1)
                    {
                        lblMsg.Visible = true;
                        lblMsg.Text = "Record added successfully.";
                        ClearControl();
                    }
                }

                sdsIDOC.SelectCommand = objIDoc.GetIDOCCaseEntry(Session["CentreId"].ToString(), Session["ClientId"].ToString());
            }
            else
            {
                lblMsg.Text = "Select atleast one verification type.";
                lblMsg.Visible = true;
                lblMsg.ForeColor = System.Drawing.Color.Red;
            }
        }
        catch (Exception ex)
        {
            lblMsg.Visible = true;
            lblMsg.Text = ex.Message.ToString();
        }
        if(iCount==1)
            Response.Redirect("IDOC_CaseView.aspx?Msg=" + lblMsg.Text);
    }

    //protected void gvIDoc_RowCommand(object sender, GridViewCommandEventArgs e)
    //{
    //    lblMsg.Visible = false;
    //    string sCaseId = e.CommandArgument.ToString();
    //    if (e.CommandName == "Edit")
    //    {
    //        if (sCaseId != "")
    //        {
    //            Response.Redirect("IDOC_CaseEntry.aspx?CaseID=" + sCaseId);
    //        }
    //    }
    //    if (e.CommandName == "DeleteIDOC")
    //    {
    //        if (objIDoc.DeleteIDOCCaseEntry(e.CommandArgument.ToString()) == 1)
    //        {
    //            lblMsg.Visible = true;
    //            lblMsg.Text = "Record deleted successfully.";
    //        }
    //    }
    //    sdsIDOC.SelectCommand = objIDoc.GetIDOCCaseEntry();
    //}

    //protected void gvIDoc_RowDataBound(object sender, GridViewRowEventArgs e)
    //{
    //    if (e.Row.RowType == DataControlRowType.DataRow)
    //    {
    //        LinkButton l = (LinkButton)e.Row.FindControl("lnkDeleteIDoc");
    //        l.Attributes.Add("onclick", "javascript:return " +
    //                      "confirm('Are you sure you want to delete this record')");
    //    }
    //}

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        if (Context.Request.QueryString["CaseID"] != null && Context.Request.QueryString["CaseID"] != "")
        {
            Response.Redirect("IDOC_CaseView.aspx");
        }
        else
        {
            Response.Redirect("Default.aspx");
        }

    }
    private void FillReferenceProduct()
    {
        DataTable dtReferenceProduct = new DataTable();
        dtReferenceProduct = objIDoc.GetReferenceProduct();
        ddlReferenceProduct.DataTextField = "PRODUCT_NAME";
        ddlReferenceProduct.DataValueField = "PRODUCT_ID";
        ddlReferenceProduct.DataSource = dtReferenceProduct;
        ddlReferenceProduct.DataBind();

    }
    protected void chkVerDoc_DataBound(object sender, EventArgs e)
    {
        btnSubmit.Attributes["onclick"] = "CheckAtleastOne(this.checked);";
        if (chkVerDoc.Items.Count > 0)
        {
            foreach (ListItem li in chkVerDoc.Items)
            {
                ClientScript.RegisterArrayDeclaration("CheckBoxIDs", string.Concat("\'", chkVerDoc , "\'"));
            }
        }
    }
    protected void ddlReferenceProduct_DataBound(object sender, EventArgs e)
    {
        ddlReferenceProduct.Items.Insert(0, "Select");
    }
}

