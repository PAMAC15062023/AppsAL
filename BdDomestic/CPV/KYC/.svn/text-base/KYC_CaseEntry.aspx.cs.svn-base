
/*----------------------------------------------------------------------------------------
Scope of Program	:	
File Name			:	KYCCaseEntry.aspx.cs
Create By			:	Hemangi Kambli
Create Date		    :	11th April 2007
Remarks 		    :	This class is used for KYCCaseEntry.
						
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

public partial class KYC_KYC_CaseEntry : System.Web.UI.Page
{
    CKYC objKYC = new CKYC();
    DataSet dsKYC = new DataSet();
    DataSet dsVerification = new DataSet();
    CCommon objcon = new CCommon();

    protected void Page_Load(object sender, EventArgs e)
    {
       
        if (Session.Count == 0)
            Response.Redirect("Default.aspx");

        txtRefNo.Focus();

          if (!IsPostBack)
            {  

              
            if (Context.Request.QueryString["CaseID"] != null && Context.Request.QueryString["CaseID"] != "")
            {
                string sCaseId = Request.QueryString["CaseID"].ToString();

                if (sCaseId != "")
                {
                    if (sCaseId == "Add")
                    {
                        txtRecDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
                        txtRecTime.Text = DateTime.Now.ToString("hh:mm");
                        ddlTimeType.SelectedValue = DateTime.Now.ToString("tt");
                    }
                    

                    dsKYC = objKYC.GetKYCCaseEntry(sCaseId);

                    if (dsKYC.Tables[0].Rows.Count > 0)
                    {
                        
                        string sTmp = dsKYC.Tables[0].Rows[0]["CASE_REC_DATETime"].ToString();
                        if (sTmp != "")
                        {
                            string[] arrRecDateTime = sTmp.Split(' ');
                            if(arrRecDateTime[0].ToString()!="")
                                txtRecDate.Text = Convert.ToDateTime(arrRecDateTime[0].ToString()).ToString("dd/MM/yyyy");
                            if(arrRecDateTime[1].ToString()!="")
                                txtRecTime.Text = Convert.ToDateTime(arrRecDateTime[1].ToString()).ToString("hh:mm");
                            ddlTimeType.SelectedValue = arrRecDateTime[2].ToString();
                        }
                        txtRefNo.Text = dsKYC.Tables[0].Rows[0]["Ref_No"].ToString();
                        txtTitle.Text = dsKYC.Tables[0].Rows[0]["Title"].ToString();
                        txtFirstNm.Text = dsKYC.Tables[0].Rows[0]["First_Name"].ToString();
                        txtMiddleNm.Text = dsKYC.Tables[0].Rows[0]["Middle_Name"].ToString();
                        txtLastNm.Text = dsKYC.Tables[0].Rows[0]["Last_Name"].ToString();
                        if(dsKYC.Tables[0].Rows[0]["DOB"].ToString()!="")
                            txtDOB.Text =dsKYC.Tables[0].Rows[0]["DOB"].ToString();

                        txtResAdd1.Text = dsKYC.Tables[0].Rows[0]["RES_ADD_LINE_1"].ToString();
                        txtResAdd2.Text = dsKYC.Tables[0].Rows[0]["RES_ADD_LINE_2"].ToString();
                        txtResAdd3.Text = dsKYC.Tables[0].Rows[0]["RES_ADD_LINE_3"].ToString();
                        txtResCity.Text = dsKYC.Tables[0].Rows[0]["RES_CITY"].ToString();
                        txtResPhone.Text = dsKYC.Tables[0].Rows[0]["RES_PHONE"].ToString();
                        txtResPin.Text = dsKYC.Tables[0].Rows[0]["RES_PIN_CODE"].ToString();
                        txtLandMark.Text = dsKYC.Tables[0].Rows[0]["RES_LAND_MARK"].ToString();
                        txtOffAdd1.Text = dsKYC.Tables[0].Rows[0]["OFF_ADD_LINE_1"].ToString();
                        txtOffAdd2.Text = dsKYC.Tables[0].Rows[0]["OFF_ADD_LINE_2"].ToString();
                        txtOffAdd3.Text = dsKYC.Tables[0].Rows[0]["OFF_ADD_LINE_3"].ToString();
                        txtOffCity.Text = dsKYC.Tables[0].Rows[0]["OFF_CITY"].ToString();
                        txtOffPhone.Text = dsKYC.Tables[0].Rows[0]["OFF_PHONE"].ToString();
                        txtOffExtn.Text = dsKYC.Tables[0].Rows[0]["OFF_EXTN"].ToString();
                        txtOffPin.Text = dsKYC.Tables[0].Rows[0]["OFF_PIN_CODE"].ToString();
                        txtDesgn.Text = dsKYC.Tables[0].Rows[0]["DESIGNATION"].ToString();
                        txtDept.Text = dsKYC.Tables[0].Rows[0]["DEPARTMENT"].ToString();
                        txtOccupation.Text = dsKYC.Tables[0].Rows[0]["OCCUPATION"].ToString();
                        ddlVeriType.SelectedValue = objKYC.GetVerificationType(sCaseId);

                    }
                }
            }
        }
    }

    #region ClearControl()
    private void ClearControl()
    {        
        ddlTimeType.SelectedIndex = 0;
        txtTitle.Text = "";
        txtOffCity.Text = "";
        txtRefNo.Text = "";
        txtRecDate.Text = "";
        txtRecTime.Text = "";
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
    }
    #endregion ClearControl()

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        int iCount = 0;
        ArrayList arrVerType = new ArrayList();
        try
        {
            
            if (txtDOB.Text.Trim() != "")
                objKYC.DOB = txtDOB.Text.Trim().ToString();
            if (txtRecDate.Text.Trim() != "" && txtRecTime.Text.Trim() != "")
               objKYC.ReceivedDateTime = Convert.ToDateTime(objcon.strDate(txtRecDate.Text.Trim()) + " " + txtRecTime.Text.Trim() + " " + ddlTimeType.SelectedItem.Text.Trim());
            //objKYC.ReceivedDateTime1 = txtRecDate.Text.Trim() + " " + txtRecTime.Text.Trim() + " " + ddlTimeType.SelectedItem.Text.Trim();
            objKYC.CentreId = Session["CentreId"].ToString();
            objKYC.ClusterId = Session["ClusterId"].ToString();
            objKYC.ClientId = Session["ClientId"].ToString();
            objKYC.RefNo = txtRefNo.Text.Trim();
            objKYC.Title = txtTitle.Text.Trim();
            objKYC.FirstName = txtFirstNm.Text.Trim();
            objKYC.MiddleName = txtMiddleNm.Text.Trim();
            objKYC.LastName = txtLastNm.Text.Trim();
            objKYC.FullName = txtFirstNm.Text.Trim() + " " + txtMiddleNm.Text.Trim() + " " + txtLastNm.Text.Trim();
            objKYC.ResAdd1 = txtResAdd1.Text.Trim();
            objKYC.ResAdd2 = txtResAdd2.Text.Trim();
            objKYC.ResAdd3 = txtResAdd3.Text.Trim();
            objKYC.ResCity = txtResCity.Text.Trim();
            objKYC.ResPin = txtResPin.Text.Trim();
            objKYC.ResLandMark = txtLandMark.Text.Trim();
            objKYC.ResPhone = txtResPhone.Text.Trim();
            objKYC.OfficeAdd1 = txtOffAdd1.Text.Trim();
            objKYC.OfficeAdd2 = txtOffAdd2.Text.Trim();
            objKYC.OfficeAdd3 = txtOffAdd3.Text.Trim();
            objKYC.OfficeCity = txtOffCity.Text.Trim();
            objKYC.OfficePin = txtOffPin.Text.Trim();
            objKYC.OfficePhone = txtOffPhone.Text.Trim();
            objKYC.OfficeExtn = txtOffExtn.Text.Trim();
            objKYC.Designation = txtDesgn.Text.Trim();
            objKYC.Department = txtDept.Text.Trim();
            objKYC.Occupation = txtOccupation.Text.Trim();
            objKYC.VerificationTypeID = ddlVeriType.SelectedValue.ToString();
            objKYC.AddedBy = Session["UserId"].ToString();
            objKYC.AddedOn = DateTime.Now;
            objKYC.ModifyBy = Session["UserId"].ToString();
            objKYC.ModifyOn = DateTime.Now;


            OleDbDataReader oledbRead;
            if (Context.Request.QueryString["CaseID"] != null && Context.Request.QueryString["CaseID"] != "")
            {
                oledbRead = objKYC.GetKYCCase(Request.QueryString["CaseID"].ToString());
                if (oledbRead.Read() == false)
                {
                    if (objKYC.InsertKYCCaseEntry(arrVerType, Session["Prefix"].ToString()) == 1)
                    {
                        lblMsg.Visible = true;
                        lblMsg.Text = "Record added successfully.";
                        ClearControl();
                        if (Request.QueryString["CaseID"].ToString() == "Add")
                            iCount = 1;

                    }
                }
                else
                {

                    if (objKYC.UpdateKYCCaseEntry(arrVerType, Request.QueryString["CaseID"].ToString()) == 1)
                    {
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
                if (objKYC.InsertKYCCaseEntry(arrVerType, Session["Prefix"].ToString()) == 1)
                {
                    lblMsg.Visible = true;
                    lblMsg.Text = "Record added successfully.";
                    ClearControl();
                }
            }

           
            sdsKYC.SelectCommand = objKYC.GetKYCCaseEntry(Session["CentreId"].ToString(), Session["ClientId"].ToString());
        }
        catch (Exception ex)
        {
            lblMsg.Visible = true;
            lblMsg.Text = ex.Message.ToString();
        }

        if(iCount==1)
            Response.Redirect("KYC_CaseView.aspx?Msg=" + lblMsg.Text);
    }

    //protected void gvKYC_RowCommand(object sender, GridViewCommandEventArgs e)
    //{
    //    lblMsg.Visible = false;

    //    if (e.CommandName == "Edit")
    //    {

    //    }
    //    if (e.CommandName == "DeleteCC")
    //    {
    //        if (objKYC.DeleteKYCCaseEntry(e.CommandArgument.ToString()) == 1)
    //        {
    //            lblMsg.Visible = true;
    //            lblMsg.Text = "Record deleted successfully.";
    //        }
    //    }
    //    sdsKYC.SelectCommand = objKYC.GetKYCCaseEntry();
    //}

    protected void gvKYC_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            LinkButton l = (LinkButton)e.Row.FindControl("lnkDeleteKYC");
            l.Attributes.Add("onclick", "javascript:return " +
                          "confirm('Are you sure you want to delete this record')");
        }
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("KYC_CaseView.aspx");
    }
    protected void ddlVeriType_DataBound(object sender, EventArgs e)
    {
        DropDownList ddl = (DropDownList)sender;
        ddl.Items.Insert(0, new ListItem("--Select Verification Type--", "0"));
    }
}
