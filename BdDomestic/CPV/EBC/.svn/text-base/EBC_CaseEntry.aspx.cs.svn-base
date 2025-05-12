
/*----------------------------------------------------------------------------------------
Scope of Program	:	
File Name			:	EBC_CaseEntry.aspx.cs
Create By			:	Hemangi Kambli
Create Date		    :	11th April 2007
Remarks 		    :	This class is used for EBC CaseEntry.
						
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

public partial class EBC_EBC_CaseEntry : System.Web.UI.Page
{
    private CEBC objEBC = new CEBC();
    DataSet dsEBC = new DataSet();
    CCommon objcon = new CCommon();
    DataTable dt = new DataTable();
    int j = 0;
    
    bool boolAdd = true;
    protected void Page_Load(object sender, EventArgs e)
    {
      
        if (Session.Count == 0)
            Response.Redirect("Default.aspx");

        if (!IsPostBack)
        {
            txtRecDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
            txtRecTime.Text = DateTime.Now.ToString("hh:mm");
            if (Context.Request.QueryString["CaseID"] != null && Context.Request.QueryString["CaseID"] != "")
            {
                
                
                string sCaseId = Request.QueryString["CaseID"].ToString();
                if (sCaseId != "Add")
                {
                    txtRefNo.ReadOnly = true;
                }
                if (sCaseId != "")
                {
                    dsEBC = objEBC.GetEBCCaseEntry(sCaseId);
                    
                    if (dsEBC.Tables[0].Rows.Count > 0)
                    {
                        string sTmp = dsEBC.Tables[0].Rows[0]["CASE_REC_DATETime"].ToString();
                        if (sTmp != "")
                        {
                            string[] arrRecDateTime = sTmp.Split(' ');
                            if (arrRecDateTime[0].ToString() != "")
                                txtRecDate.Text = Convert.ToDateTime(arrRecDateTime[0].ToString()).ToString("dd/MM/yyyy");
                            if (arrRecDateTime[1].ToString() != "")
                                txtRecTime.Text = Convert.ToDateTime(arrRecDateTime[1].ToString()).ToString("hh:mm");
                            ddlTimeType.SelectedValue = arrRecDateTime[2].ToString();
                        }
                        txtEmpCode.Text = dsEBC.Tables[0].Rows[0]["Emp_Code"].ToString();
                        txtRefNo.Text = dsEBC.Tables[0].Rows[0]["Ref_No"].ToString();
                        txtTitle.Text = dsEBC.Tables[0].Rows[0]["Title"].ToString();
                        txtFirstNm.Text = dsEBC.Tables[0].Rows[0]["First_Name"].ToString();
                        txtMiddleNm.Text = dsEBC.Tables[0].Rows[0]["Middle_Name"].ToString();
                        txtLastNm.Text = dsEBC.Tables[0].Rows[0]["Last_Name"].ToString();
                        if(dsEBC.Tables[0].Rows[0]["DOB"].ToString()!="")
                          txtDOB.Text = Convert.ToDateTime(dsEBC.Tables[0].Rows[0]["DOB"].ToString()).ToString("dd/MM/yyyy");

                        txtResAdd1.Text = dsEBC.Tables[0].Rows[0]["ADD_LINE_1"].ToString();
                        txtResAdd2.Text = dsEBC.Tables[0].Rows[0]["ADD_LINE_2"].ToString();
                        txtResAdd3.Text = dsEBC.Tables[0].Rows[0]["ADD_LINE_3"].ToString();
                        txtResCity.Text = dsEBC.Tables[0].Rows[0]["CITY"].ToString();
                        txtPhone1.Text = dsEBC.Tables[0].Rows[0]["PHONE1"].ToString();
                        txtPhone2.Text = dsEBC.Tables[0].Rows[0]["PHONE2"].ToString();
                        txtResPin.Text = dsEBC.Tables[0].Rows[0]["PIN_CODE"].ToString();
                        txtDOJ.Text = dsEBC.Tables[0].Rows[0]["DATE_OF_JOINING"].ToString();
                        txtLocation.Text = dsEBC.Tables[0].Rows[0]["LOCATION"].ToString();
                        txtDesignation.Text = dsEBC.Tables[0].Rows[0]["DESIGNATION"].ToString();
                        txtStaffname.Text = dsEBC.Tables[0].Rows[0]["STAFF_NAME"].ToString();
                        txtFathername.Text = dsEBC.Tables[0].Rows[0]["FATHER_NAME"].ToString();
                        txtPreEmpName.Text = dsEBC.Tables[0].Rows[0]["Previous_Employer_Name"].ToString();
                        txtPreEmpAdd.Text = dsEBC.Tables[0].Rows[0]["Previous_Employer_Address"].ToString();
                        txtPreDsig.Text = dsEBC.Tables[0].Rows[0]["Previous_Designation"].ToString();
                        txtRefID.Text = dsEBC.Tables[0].Rows[0]["Reference_Name_Number"].ToString();
                        txtProject.Text = dsEBC.Tables[0].Rows[0]["Project"].ToString();
                        ddlVeriType.SelectedValue = objEBC.GetVerificationType(sCaseId);
                    }
                    OleDbDataReader dr;
                    dr = objEBC.GetQualification(sCaseId);
                    dt.Columns.Add("Qulification");
                    dt.Columns.Add("Specilization");
                    dt.Columns.Add("Roll.No.");
                    dt.Columns.Add("University");
                    dt.Columns.Add("Year Of Passing");
                    DataRow row;
                    row = dt.NewRow();
                     while(dr.Read())
                     {
                         dt.Rows.Add();
                         dt.Rows[dt.Rows.Count - 1]["Qulification"] = dr["Qualification"].ToString();
                         dt.Rows[dt.Rows.Count - 1]["Specilization"] = dr["Specialization"].ToString();
                         dt.Rows[dt.Rows.Count - 1]["Roll.No."] = dr["Roll_No"].ToString();
                         dt.Rows[dt.Rows.Count - 1]["University"] = dr["University"].ToString();
                         dt.Rows[dt.Rows.Count - 1]["Year Of Passing"] = dr["Year_Passing"].ToString();
                        
                        ViewState["v1"] = dt;
                        gvQualifivation.DataSource = dt;
                        gvQualifivation.DataBind();
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
        txtRefNo.Text = "";
        txtRecDate.Text = "";
        txtRecTime.Text = "";
        txtResAdd1.Text = "";
        txtResAdd2.Text = "";
        txtResAdd3.Text = "";
        txtResCity.Text = "";
        txtResPin.Text = "";
        txtPhone1.Text = "";
        txtPhone2.Text = "";
        txtDOB.Text = "";
        txtFirstNm.Text = "";
        txtLastNm.Text = "";
        txtMiddleNm.Text = "";
        txtDOJ.Text = "";
        txtLocation.Text = "";
        txtDesignation.Text = "";
        txtStaffname.Text = "";
        txtFathername.Text = "";
        txtPreEmpName.Text = "";
        txtPreEmpAdd.Text = "";
        txtPreDsig.Text = "";
        txtRefID.Text = "";
        txtProject.Text = "";
        txtEmpCode.Text = "";
        txtQualification.Text = "";
        txtSpecilization.Text = "";
        txtUniversity.Text = "";
        txtRollNo.Text = "";
        txtYearOfPassing.Text = "";

    }
    #endregion ClearControl()

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        
        int iCount = 0;
        try
        {
            if (txtDOB.Text.Trim() != "")
                objEBC.DOB = objcon.strDate(txtDOB.Text.Trim());
            if (txtRecDate.Text.Trim() != "" && txtRecTime.Text.Trim() != "")
                objEBC.ReceivedDateTime = Convert.ToDateTime(objcon.strDate(txtRecDate.Text.Trim()) + " " + txtRecTime.Text.Trim() + " " + ddlTimeType.SelectedItem.Text.Trim());

            objEBC.CentreId = Session["CentreId"].ToString();
            objEBC.ClusterId = Session["ClusterId"].ToString();
            objEBC.ClientId = Session["ClientId"].ToString();
            objEBC.RefNo = txtRefNo.Text.Trim();
            objEBC.Title = txtTitle.Text.Trim();
            objEBC.FirstName = txtFirstNm.Text.Trim();
            objEBC.MiddleName = txtMiddleNm.Text.Trim();
            objEBC.LastName = txtLastNm.Text.Trim();
            objEBC.FullName = txtFirstNm.Text.Trim() + " " + txtMiddleNm.Text.Trim() + " " + txtLastNm.Text.Trim();
            objEBC.ResAdd1 = txtResAdd1.Text.Trim();
            objEBC.ResAdd2 = txtResAdd2.Text.Trim();
            objEBC.ResAdd3 = txtResAdd3.Text.Trim();
            objEBC.ResCity = txtResCity.Text.Trim();
            objEBC.ResPin = txtResPin.Text.Trim();
            objEBC.ResPhone = txtPhone1.Text.Trim();
            objEBC.OfficePhone = txtPhone2.Text.Trim();
            objEBC.EmpCode = txtEmpCode.Text.Trim();
            objEBC.AddedBy = "1";
            objEBC.AddedOn = DateTime.Now;
            objEBC.ModifyBy = "1";
            objEBC.ModifyOn = DateTime.Now;
            objEBC.DOJ = txtDOJ.Text.Trim();
            objEBC.Location = txtLocation.Text.Trim();
            objEBC.StaffName = txtStaffname.Text.Trim();
            objEBC.Designation = txtDesignation.Text.Trim();
            objEBC.FathersName = txtFathername.Text.Trim();
            objEBC.PreEmpName = txtPreEmpName.Text.Trim();
            objEBC.PreEmpAdd = txtPreEmpAdd.Text.Trim();
            objEBC.PreviousDesignation = txtPreDsig.Text.Trim();
            objEBC.RefNameNum = txtRefID.Text.Trim();
            objEBC.Project = txtProject.Text.Trim();
            objEBC.VerificationTypeID = ddlVeriType.SelectedValue;
            OleDbDataReader oledbRead;
            Validation1();
            if (boolAdd)
            {
                if (Context.Request.QueryString["CaseID"] != null && Context.Request.QueryString["CaseID"] != "")
                {
                    oledbRead = objEBC.GetEBCCase(Request.QueryString["CaseID"].ToString());
                    if (oledbRead.Read() == false)
                    {
                        if (objEBC.InsertEBCCaseEntry("101") == 1)
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

                        if (objEBC.UpdateEBCCaseEntry(Request.QueryString["CaseID"].ToString()) == 1)
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
                    if (objEBC.InsertEBCCaseEntry("101") == 1)
                    {
                        lblMsg.Visible = true;
                        lblMsg.Text = "Record added successfully.";
                        ClearControl();

                    }
                }
            }
            sdsEBC.SelectCommand = objEBC.GetEBCCaseEntry();
        }
        catch (Exception ex)
        {
            lblMsg.Visible=true;
            lblMsg.Text = ex.Message.ToString();
        }
        //--------code for Qualification----------//
        try
        {
            dt = (DataTable)ViewState["v1"];
            if (Context.Request.QueryString["CaseID"] != null && Context.Request.QueryString["CaseID"] != "")
            {
                objEBC.DeleteQualiRecord();
            }
            if (boolAdd)
            {
                if (ViewState["v1"] != null)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {

                        objEBC.Qualification = dt.Rows[i]["Qulification"].ToString();
                        objEBC.Specilization = dt.Rows[i]["Specilization"].ToString();
                        objEBC.RollNo = dt.Rows[i]["Roll.No."].ToString();
                        objEBC.University = dt.Rows[i]["University"].ToString();
                        objEBC.YearOfPassing = dt.Rows[i]["Year Of Passing"].ToString();
                        objEBC.InsertQualification();
                    }
                }
            }
            dt = null;
            gvQualifivation.DataBind();
            if (iCount == 1)
                Response.Redirect("EBC_CaseView.aspx?Msg=" + lblMsg.Text);
        }
        catch (Exception ex)
        {
            lblMsg.Visible = true;
            lblMsg.Text = ex.Message.ToString();
        }
            
       
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("EBC_CaseView.aspx");
    }
    protected void btnAddNew_Click(object sender, EventArgs e)
    {

        try
        {
            if (ViewState["v1"] != null)
            {
                dt = (DataTable)ViewState["v1"];
            }
            if (ViewState["v1"] != null && Session["Str"]=="Edit")
            {
               
                if (hidIndex.Value != "" )
                {
                    j = Convert.ToInt32(hidIndex.Value);
                    dt.Rows[j].Delete();


                }

            }
            Session["Str"] = "";
            if (ViewState["v1"] == null)
            {
                dt.Columns.Add("Qulification");
                dt.Columns.Add("Specilization");
                dt.Columns.Add("Roll.No.");
                dt.Columns.Add("University");
                dt.Columns.Add("Year Of Passing");

            }
            DataRow row;
            row = dt.NewRow();
            row["Qulification"] = txtQualification.Text.Trim();
            row["Specilization"] = txtSpecilization.Text.Trim();
            row["Roll.No."] = txtRollNo.Text.Trim();
            row["University"] = txtUniversity.Text.Trim();
            row["Year Of Passing"] = txtYearOfPassing.Text.Trim();
            dt.Rows.Add(row);

            ViewState["v1"] = dt;
            gvQualifivation.DataSource = dt;
            gvQualifivation.DataBind();
            txtQualification.Text = "";
            txtSpecilization.Text = "";
            txtRollNo.Text = "";
            txtUniversity.Text = "";
            txtYearOfPassing.Text = "";
            txtQualification.Focus();
        }
        catch (Exception ex)
        {
            lblMsg.Visible = true;
            lblMsg.Text = ex.Message.ToString();
        }
    }
    protected void gvQualifivation_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            dt = (DataTable)ViewState["v1"];
            dt.Rows[e.RowIndex].Delete();
            gvQualifivation.DataSource = dt;
            gvQualifivation.DataBind();
            ViewState["v1"] = dt;
        }
        catch (Exception ex)
        {
            lblMsg.Visible = true;
            lblMsg.Text = ex.Message.ToString();
        }
    }
    protected void gvQualifivation_RowEditing(object sender, GridViewEditEventArgs e)
    {
        try
        {
            dt = (DataTable)ViewState["v1"];
            txtQualification.Text = dt.Rows[e.NewEditIndex]["Qulification"].ToString();
            txtSpecilization.Text = dt.Rows[e.NewEditIndex]["Specilization"].ToString();
            txtRollNo.Text = dt.Rows[e.NewEditIndex]["Roll.No."].ToString();
            txtUniversity.Text = dt.Rows[e.NewEditIndex]["University"].ToString();
            txtYearOfPassing.Text = dt.Rows[e.NewEditIndex]["Year Of Passing"].ToString();
            j = e.NewEditIndex;
            Session["Str"] = "Edit";
            hidIndex.Value = j.ToString();

            gvQualifivation.DataSource = dt;

            gvQualifivation.DataBind();
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
      
        if (txtQualification.Text != "" && txtSpecilization.Text != "" && txtRollNo.Text != "" && txtUniversity.Text != "" && txtYearOfPassing.Text != "")
        {
            boolAdd = false;
            lblMsg.Visible = true;
            lblMsg.Text = "Please Enter data in table by Add New button.";
        }
        
    }

    protected void ddlVeriType_DataBound(object sender, EventArgs e)
    {
        DropDownList ddl = (DropDownList)sender;
        ddl.Items.Insert(0, new ListItem("--Select Verification Type--", "0"));
    }
}
