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


public partial class CPV_EBC_EBC_Verification : System.Web.UI.Page
{
    EBC_Verification objEBC = new EBC_Verification();
    DataTable dt = new DataTable();
    int j = 0;
    bool boolAdd = true;
    protected void Page_Load(object sender, EventArgs e)
    {
       
          

            if (Context.Request.QueryString["CaseID"] != null && Context.Request.QueryString["CaseID"] != "" )
            {

                hdnTransStart.Value = DateTime.Now.ToString();//"dd/MM/yyyy hh:mm:ss tt");
                string sCaseId = Request.QueryString["CaseID"].ToString();

                Session["CaseID"] = Request.QueryString["CaseID"].ToString();

                hidCaseID.Value = sCaseId;

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

                string VerificationID = objEBC.GetVerificationTypeID1(sCaseId);
                if ((VerificationID == "1") || (hidVerificationTypeID.Value== "RV"))
                {
                    lblHead.Text = "Residence Verification";
                }
                if ((VerificationID == "15") || (hidVerificationTypeID.Value == "PV"))
                {
                    lblHead.Text = "Police Verification";
                }
                if ((VerificationID == "16") || (hidVerificationTypeID.Value == "DGV"))
                {
                    lblHead.Text = "Degree Verification";
                }
                if ((VerificationID == "17") || (hidVerificationTypeID.Value == "GV"))
                {
                    lblHead.Text = "GAP Verification";
                }
                if ((VerificationID == "18") || (hidVerificationTypeID.Value == "EV"))
                {
                    lblHead.Text = "Employment Verification";
                }
                if (!IsPostBack)
                {
                
                OleDbDataReader oledbReadEBC;
                OleDbDataReader oledbCaseDtl;
                OleDbDataReader oledbFERead;
                oledbReadEBC = objEBC.GetEBCDetail(sCaseId);
                oledbCaseDtl = objEBC.GetCASEDetail(sCaseId);
                oledbFERead = objEBC.GetFEName(sCaseId);
                if (oledbFERead.Read())
                {
                    txtVerificatorName.Text = oledbFERead["FullName"].ToString();
                }
                if (oledbCaseDtl.Read() == true)
                {
                    txtLanNo.Text = oledbCaseDtl["REF_NO"].ToString();
                    txtDateAndTime.Text = oledbCaseDtl["CASE_REC_DATETIME"].ToString();
                    txtEmpName.Text = oledbCaseDtl["NAME"].ToString();
                    txtAddress.Text = oledbCaseDtl["Address"].ToString();
                    txtEmpECN.Text = oledbCaseDtl["Emp_code"].ToString();
                    txtDateAndTime.Text = oledbCaseDtl["CASE_REC_DATETIME"].ToString();
                    txtDOB.Text = Convert.ToDateTime( oledbCaseDtl["DOB"]).ToString("dd/MM/yyyy") ;
                }
                if (oledbReadEBC.Read() == true)
                {
                    string sTmpDate = oledbReadEBC["VERIFICATION_DATETIME"].ToString();
                    if (sTmpDate != "")
                    {
                        string[] arrVerDateTime = sTmpDate.Split(' ');
                        if (arrVerDateTime[0].ToString() != "")
                            txtDateOfVerification.Text = arrVerDateTime[0].ToString();
                        if (arrVerDateTime[1].ToString() != "")
                            txtTimeOfVerification.Text = arrVerDateTime[1].ToString();
                        if (arrVerDateTime[2].ToString() != "")
                            ddlDateTimeOfVerification.SelectedValue = arrVerDateTime[2].ToString();
                    }
                    txtNameofPersonContacted.Text = oledbReadEBC["Contact_person"].ToString();
                    txtRespondentDesignation.Text = oledbReadEBC["Contact_person_designation"].ToString();
                    txtInstitutionName.Text = oledbReadEBC["Institute_name"].ToString();
                    txtEmpDates.Text = oledbReadEBC["Employment_Date"].ToString();
                    txtDatesdAttended.Text = oledbReadEBC["Date_attend"].ToString();
                    txtQualificationGained.Text = oledbReadEBC["Qulaification_gained"].ToString();
                    txtOrganisationName.Text = oledbReadEBC["Organization_name"].ToString();
                    txtLastPosition.Text = oledbReadEBC["Last_Position_Held"].ToString();
                    txtReportingManager.Text = oledbReadEBC["Reporting_Manager"].ToString();
                    txtGapIdentified.Text = oledbReadEBC["Gap_Identified"].ToString();
                    txtPeriodOfGap.Text = oledbReadEBC["Period_Of_Gap"].ToString();
                    txtReasonOfGap.Text = oledbReadEBC["Reason_Of_Gap"].ToString();
                    txtAddressDuringGap.Text = oledbReadEBC["Address_Gap"].ToString();
                    txtpoliceVerification.Text = oledbReadEBC["Police_Verification"].ToString();
                    txtPoliceVerificationGap.Text = oledbReadEBC["Police_Verification_GAP"].ToString();
                    txtTeleNo.Text = oledbReadEBC["Telephone_No"].ToString();
                    txtNoOfYear.Text = oledbReadEBC["Year_At_Residence"].ToString();
                    ddlResidenceType.SelectedValue = oledbReadEBC["Residence_Type"].ToString();
                    txtLAndMark.Text = oledbReadEBC["Landmark"].ToString();
                    txtAccessbility.Text = oledbReadEBC["Accessibility"].ToString();
                    

                    txtRelationshipToEmp.Text = oledbReadEBC["Relationship"].ToString();
                    txtPermanentAdd.Text = oledbReadEBC["Permanent_Address"].ToString();
                    txtpreviuosJobDetail.Text = oledbReadEBC["Previous_job_Detail"].ToString();
                    txtlocalty.Text = oledbReadEBC["Locality"].ToString();
                    txtneighbourName.Text = oledbReadEBC["Neighbour_Name"].ToString();
                    txtNeighbourFeedBackOn.Text = oledbReadEBC["Neighbour_Feedback"].ToString();
                    txtTelNo.Text = oledbReadEBC["Tel_No2"].ToString();
                    txtRemk.Text = oledbReadEBC["Remark"].ToString();
                    ddlStatus.SelectedValue = oledbReadEBC["CASE_STATUS_ID"].ToString();

                    OleDbDataReader dr;
                    dr = objEBC.GetRelationship(sCaseId);
                    dt.Columns.Add("Relationship");
                    dt.Columns.Add("Occupation");
                   
                    DataRow row;
                    row = dt.NewRow();
                    while (dr.Read())
                    {
                        dt.Rows.Add();
                        dt.Rows[dt.Rows.Count - 1]["Relationship"] = dr["RELATIONSHIP"].ToString();
                        dt.Rows[dt.Rows.Count - 1]["Occupation"] = dr["OCCUPATION"].ToString();
                       

                        ViewState["v1"] = dt;
                        gvRelationship.DataSource = dt;
                        gvRelationship.DataBind();
                    }
                }
                if (hidMode.Value == "View")
                {
                    ReadOnly();
                }
            }
        }
    }
    public void SetProperty()
    {
        objEBC.VerificationDateTime = txtDateOfVerification.Text.Trim() + " " + txtTimeOfVerification.Text.Trim() + " " + ddlDateTimeOfVerification.SelectedItem.Text.Trim();
        objEBC.CaseID = Request.QueryString["CaseID"].ToString();
       
        objEBC.NameOfPersonContated = txtNameofPersonContacted.Text.Trim();
        objEBC.RespondentDesignation = txtRespondentDesignation.Text.Trim();
        objEBC.InstitutionName = txtInstitutionName.Text.Trim();
        objEBC.EmployeeDates = txtEmpDates.Text.Trim();
        objEBC.DatesAttended = txtDatesdAttended.Text.Trim();
        objEBC.QualificationGained = txtQualificationGained.Text.Trim();
        objEBC.OrganisationName = txtOrganisationName.Text.Trim();
        objEBC.LastPosition = txtLastPosition.Text.Trim();
        objEBC.ReportingManager = txtReportingManager.Text.Trim();
        objEBC.GapIdentified = txtGapIdentified.Text.Trim();
        objEBC.PeriodOfGap = txtPeriodOfGap.Text.Trim();
        objEBC.ReasoinOfGap = txtReasonOfGap.Text.Trim();
        objEBC.AddressDuringGap = txtAddressDuringGap.Text.Trim();

        objEBC.policaVerification = txtpoliceVerification.Text.Trim();
        objEBC.policaVerificationGap = txtPoliceVerificationGap.Text.Trim();
        objEBC.TelephoneNo1 = txtTeleNo.Text.Trim();
        objEBC.NumberOfYear = txtNoOfYear.Text.Trim();
        objEBC.ResidenceType = ddlResidenceType.SelectedValue;
        objEBC.LandMark = txtLAndMark.Text.Trim();
        objEBC.Accessbility = txtAccessbility.Text.Trim();
       
        objEBC.RelationshipToEmp = txtRelationshipToEmp.Text.Trim();
        objEBC.PemanentAdd = txtPermanentAdd.Text.Trim();
        objEBC.previosJobDetail = txtpreviuosJobDetail.Text.Trim();
        objEBC.Locality = txtlocalty.Text.Trim();
        objEBC.NeighbourName = txtneighbourName.Text.Trim();
        objEBC.NeighbourFeedBackOfEmp = txtNeighbourFeedBackOn.Text.Trim();
        objEBC.TelephoneNo2 = txtTelNo.Text.Trim();
        objEBC.Remark = txtRemk.Text.Trim();
        objEBC.Status = ddlStatus.SelectedValue.ToString();
        //Added by hemangi kambli on 01/10/2007 
        if (hdnTransStart.Value != "")
            objEBC.TransStart = Convert.ToDateTime(hdnTransStart.Value);
        objEBC.TransEnd = Convert.ToDateTime(DateTime.Now.ToString());//"dd/MM/yyyy hh:mm:ss tt"));
        objEBC.CentreId = Session["CentreId"].ToString();
        objEBC.ProductId = Session["ProductId"].ToString();
        objEBC.ClientId = Session["ClientId"].ToString();
        objEBC.UserId = Session["UserId"].ToString();
        ///------------------------------------------------------
    }
    public void ClearControl()
    {
        txtDateOfVerification.Text = "";
        txtTimeOfVerification.Text = "";
        txtNameofPersonContacted.Text = "";
        txtRespondentDesignation.Text="";
        txtInstitutionName.Text="";
        txtEmpDates.Text="";
        txtDatesdAttended.Text="";
        txtQualificationGained.Text="";
        txtOrganisationName.Text="";
        txtLastPosition.Text="";
        txtReportingManager.Text="";
        txtGapIdentified.Text="";
        txtPeriodOfGap.Text="";
        txtReasonOfGap.Text = "";
        txtAddressDuringGap.Text="";
        txtpoliceVerification.Text="";
        txtTeleNo.Text="";
        txtNoOfYear.Text="";
        ddlResidenceType.SelectedValue="0";
        txtLAndMark.Text="";


        txtAccessbility.Text = "";
        
         txtRelationshipToEmp.Text = "";
         txtPermanentAdd.Text = "";
         txtpreviuosJobDetail.Text = "";
         txtlocalty.Text = "";
         txtneighbourName.Text = "";
         txtNeighbourFeedBackOn.Text = "";
         txtTelNo.Text = "";
         txtRemk.Text = "";
         
    }
    private bool ValidateTextArea()
    {
        bool iValidate = true;
        string sPermanentAddress = "";
        
        string sNeighbourFeedBack = "";
        string sRemark = "";
        string sFamily = "";
        
        sPermanentAddress = txtPermanentAdd.Text;
        sNeighbourFeedBack = txtNeighbourFeedBackOn.Text;
        sRemark = txtRemk.Text;

        if (sPermanentAddress.Trim() != "")
        {
            if (sPermanentAddress.Length > 255)
            {
                pnlMsg.Visible = true;
                lblMsg.Visible = true;
                lblMsg.ForeColor = System.Drawing.Color.Red;
                lblMsg.Font.Bold = true;
                lblMsg.Text = "Permanent Address should not be greater than 255 characters.";
                iValidate = false;
            }
        }
        if (sNeighbourFeedBack.Trim() != "")
        {
            if (sNeighbourFeedBack.Length > 255)
            {
                pnlMsg.Visible = true;
                lblMsg.Visible = true;
                lblMsg.ForeColor = System.Drawing.Color.Red;
                lblMsg.Font.Bold = true;
                lblMsg.Text = "Comments of neighbour  should not be greater than 255 characters.";
                iValidate = false;
            }
        }
        if (sRemark.Trim() != "")
        {
            if (sRemark.Length > 750)
            {
                pnlMsg.Visible = true;
                lblMsg.Visible = true;
                lblMsg.ForeColor = System.Drawing.Color.Red;
                lblMsg.Font.Bold = true;
                lblMsg.Text = "Remark should not be greater than 750 characters.";
                iValidate = false;
            }
        }
        
        return iValidate;
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    { 
        int iCount = 0;
        string sMsg = "";
        try
        {
            if (ValidateTextArea() == true)
            {
                SetProperty();

                sMsg = objEBC.InsertEBCVerificationType();
                if (sMsg != "")
                {
                    pnlMsg.Visible = true;
                    tblMsg.Visible = true;
                    lblMsg.Text = sMsg.Trim();
                    lblMsg.ForeColor = System.Drawing.Color.Red;
                    iCount = 1;
                }
            }
        }
        catch (Exception ex)
        {
            pnlMsg.Visible = true;
            tblMsg.Visible = true;
            lblMsg.ForeColor = System.Drawing.Color.Red;
            lblMsg.Text = "Error:" + ex.Message;
        }

        try
        {
            dt = (DataTable)ViewState["v1"];
            if (Context.Request.QueryString["CaseID"] != null && Context.Request.QueryString["CaseID"] != "")
            {
                objEBC.DeleteRelatioship();
            }
            if (boolAdd)
            {
                if (ViewState["v1"] != null)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {

                        objEBC.Relationship = dt.Rows[i]["Relationship"].ToString();
                        objEBC.Occupation = dt.Rows[i]["Occupation"].ToString();

                        objEBC.InsertFamilyRecord();
                    }
                }
            }
            dt = null;
            gvRelationship.DataBind();
           
        }
        catch (Exception ex)
        {
            lblMsg.Visible = true;
            lblMsg.Text = ex.Message.ToString();
        }

        if (iCount == 1)
        {
            Response.Redirect("EBC_VerificationView.aspx?Msg=" + lblMsg.Text);
        }

    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("EBC_VerificationView.aspx");
    }
    protected void addbtn_Click(object sender, EventArgs e)
    {
        try
        {
            if (ViewState["v1"] != null)
            {
                dt = (DataTable)ViewState["v1"];
            }
            if (ViewState["v1"] != null && Session["Str"] == "Edit")
            {

                if (hidIndex1.Value != "")
                {
                    j = Convert.ToInt32(hidIndex1.Value);
                    dt.Rows[j].Delete();


                }

            }
            Session["Str"] = "";
            if (ViewState["v1"] == null)
            {
                dt.Columns.Add("Relationship");
                dt.Columns.Add("Occupation");
               
            }
            DataRow row;
            row = dt.NewRow();
            row["Relationship"] = txtRelation.Text.Trim();
            row["Occupation"] = txtOccupation.Text.Trim();
            
            dt.Rows.Add(row);

            ViewState["v1"] = dt;
            gvRelationship.DataSource = dt;
            gvRelationship.DataBind();
            txtRelation.Text = "";
            txtOccupation.Text = "";
           
            txtRelation.Focus();
        }
        catch (Exception ex)
        {
            lblMsg.Visible = true;
            lblMsg.Text = ex.Message.ToString();
        }
    }
    protected void gvRelationship_RowEditing(object sender, GridViewEditEventArgs e)
    {
        try
        {
            dt = (DataTable)ViewState["v1"];
            txtRelation.Text = dt.Rows[e.NewEditIndex]["Relationship"].ToString();
            txtOccupation.Text = dt.Rows[e.NewEditIndex]["Occupation"].ToString();
           
            j = e.NewEditIndex;
            Session["Str"] = "Edit";
            hidIndex1.Value = j.ToString();

            gvRelationship.DataSource = dt;

            gvRelationship.DataBind();
            ViewState["v1"] = dt;
        }
        catch (Exception ex)
        {
            lblMsg.Visible = true;
            lblMsg.Text = ex.Message.ToString();
        }

    }
    protected void gvRelationship_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            dt = (DataTable)ViewState["v1"];
            dt.Rows[e.RowIndex].Delete();
            gvRelationship.DataSource = dt;
            gvRelationship.DataBind();
            ViewState["v1"] = dt;
        }
        catch (Exception ex)
        {
            lblMsg.Visible = true;
            lblMsg.Text = ex.Message.ToString();
        }
    }
    public void Validation1()
    {

        if (txtRelation.Text != "" && txtOccupation.Text != "" )
        {
            boolAdd = false;
            lblMsg.Visible = true;
            lblMsg.Text = "Please Enter data in table by Add New button.";
        }

    }
    private void ReadOnly()
    {
       
        txtLanNo.Enabled = false;
        txtDateAndTime.Enabled = false;
        txtEmpName.Enabled = false;
        txtAddress.Enabled = false;
        txtEmpECN.Enabled = false;
        txtDateAndTime.Enabled = false;
        txtDOB.Enabled = false;
        txtDateOfVerification.Enabled = false;
        txtTimeOfVerification.Enabled = false;
        ddlDateTimeOfVerification.Enabled = false;
        txtNameofPersonContacted.Enabled = false;
        txtRespondentDesignation.Enabled = false;
        txtInstitutionName.Enabled = false;
        txtEmpDates.Enabled = false;
        txtDatesdAttended.Enabled = false;
        txtQualificationGained.Enabled = false;
        txtOrganisationName.Enabled = false;
        txtLastPosition.Enabled = false;
        txtReportingManager.Enabled = false;
        txtGapIdentified.Enabled = false;
        txtPeriodOfGap.Enabled = false;
        txtReasonOfGap.Enabled = false;
        txtAddressDuringGap.Enabled = false;
        txtpoliceVerification.Enabled = false;
        txtPoliceVerificationGap.Enabled = false;
        txtTeleNo.Enabled = false;
        txtNoOfYear.Enabled = false;
        ddlResidenceType.Enabled = false;
        txtLAndMark.Enabled = false;
        txtAccessbility.Enabled = false;
        txtRelationshipToEmp.Enabled = false;
        txtPermanentAdd.Enabled = false;
        txtpreviuosJobDetail.Enabled = false;
        txtlocalty.Enabled = false;
        txtneighbourName.Enabled = false;
        txtNeighbourFeedBackOn.Enabled = false;
        txtTelNo.Enabled = false;
        txtRemk.Enabled = false;
        addbtn.Enabled = false;
        ddlStatus.Enabled = false;
        txtVerificatorName.Enabled = false;
        btnCancel.Enabled = false;
        btnSubmit.Enabled = false;
        txtRelation.Enabled = false;
        txtOccupation.Enabled = false;
        gvRelationship.DataBind();
        gvRelationship.Columns[GridPosition.DELETE].Visible = false;
        gvRelationship.Columns[GridPosition.EDIT].Visible = false;
        
    }
    private struct GridPosition
    {
        public const int DELETE = 2;
        public const int EDIT = 3;
    }

}
