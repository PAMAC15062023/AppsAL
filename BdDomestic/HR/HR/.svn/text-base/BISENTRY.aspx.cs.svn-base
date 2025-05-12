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
using System.IO;
public partial class HR_HR_BISENTRY : System.Web.UI.Page
{
    CBISENTRY CBE = new CBISENTRY();
    CBISENTRYFORM CBEF = new CBISENTRYFORM();
    bool bflag = true;
    int j = 0;
    DataTable dt = new DataTable();
    C_Alert CA = new C_Alert();
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            
            string strRloeID = Session["RoleID"].ToString();
            string[] strRole1 = strRloeID.Split(',');
          
                OleDbDataReader dr = CBE.GetEMPCODE(Session["UserID"].ToString());
                while (dr.Read())
                {

                    txtEMPCodeActivityManager.Text = dr[0].ToString();
                    txtEMPNameActivityManager.Text = dr[1].ToString();
                    foreach (string str in strRole1)
                    {
                        if (str == "24")
                        {

                            tblHOHR.Visible = true;

                            txtEMPCodeOfHOHR.Text = dr[0].ToString();
                            txtEMPOfNameHOHR.Text = dr[1].ToString();
                            //comment for thi line Dol date & reason by Kamal
                            ///////////////hdfHOHR.Value = "true";
                            btnDedupHo.Visible = true;
                        }
                        if (str == "25")
                        {

                            tblClusterHR.Visible = true;

                            txtEMPCodeOfClusterHR.Text = dr[0].ToString();
                            txtEMPNameOfCluster.Text = dr[1].ToString();
                            btnDedupCluster.Visible = true;
                        }


                    }
                }
                dr.Close();
            
            if (Request.QueryString["CentreID"] != "" && Request.QueryString["CentreID"] != null && Request.QueryString["SubcentreID"] != "" && Request.QueryString["SubcentreID"] != null && Request.QueryString["ClusterID"] != "" && Request.QueryString["ClusterID"] != null)
            {
                hdfCentre.Value = Request.QueryString["CentreID"].ToString();
                hdfSubcentre.Value = Request.QueryString["SubcentreID"].ToString();
                hdfCluster.Value = Request.QueryString["ClusterID"].ToString();
            }
            if (Request.QueryString["CentreID"] != "" && Request.QueryString["CentreID"] != null && Request.QueryString["SubcentreID"] != "" && Request.QueryString["SubcentreID"] != null )
            {
                hdfCentre.Value = Request.QueryString["CentreID"].ToString();
                hdfSubcentre.Value = Request.QueryString["SubcentreID"].ToString();
            }
            if (Request.QueryString["SubcentreID"] != "" && Request.QueryString["SubcentreID"] != null )
            {
                hdfSubcentre.Value = Request.QueryString["SubcentreID"].ToString();
            }
           
            if (!IsPostBack)
            {
                if (Request.QueryString["EMP_ID"] != null && Request.QueryString["EMP_ID"] != "")
                {
                    lblMode.Text = "[Edit]";
                    DataSet ds = new DataSet();
                    DataSet dsSalary = new DataSet();
                    ds = CBEF.GetEmployeeDetail(Request.QueryString["EMP_ID"].ToString());
                    string str111 = ds.Tables[0].Rows[0]["APPROVED_BY_HOHR"].ToString().Trim();
                    ddlTitle.SelectedValue = ds.Tables[0].Rows[0]["Title"].ToString().Trim();

                    ddlNomineeTitle.SelectedValue = ds.Tables[0].Rows[0]["NOMINNE_TITLE"].ToString();
                    txtPan.Text = ds.Tables[0].Rows[0]["PAN#"].ToString();
                    hdfPhoto.Value = ds.Tables[0].Rows[0]["PHOTO_PATH"].ToString().Trim();

                    if (ds.Tables[0].Rows[0]["PHOTO_PATH"].ToString().Trim() != "" && ds.Tables[0].Rows[0]["PHOTO_PATH"].ToString().Trim() != null)
                    {
                        string strPhoto = ds.Tables[0].Rows[0]["PHOTO_PATH"].ToString().Trim();
                        PhotoImage.ImageUrl = "EmployeePhoto/" + ds.Tables[0].Rows[0]["PHOTO_PATH"].ToString().Trim();
                    }
                    if (ds.Tables[0].Rows[0]["APPROVED_BY_HOHR"].ToString().Trim() == "Y" || ds.Tables[0].Rows[0]["APPROVED_BY_CLUSTER"].ToString().Trim() == "Y")
                    {
                        bool bflagRead = true;
                        foreach (string str in strRole1)
                        {

                            if (str == "24" || str == "25")
                            {
                                bflagRead = false;

                            }

                        }
                        if (bflagRead == true)
                        {
                            ReadOnlyTrue();
                           
                                GVChildDetail.Columns[2].Visible = false;
                                GVChildDetail.Columns[3].Visible = false;
                                gvQualification.Columns[6].Visible = false;
                                gvQualification.Columns[7].Visible = false;
                                gvEmployementDetail.Columns[5].Visible = false;
                                gvEmployementDetail.Columns[6].Visible = false;
                                GVReferenceDetail.Columns[5].Visible = false;
                                gvEmployementDetail.Columns[6].Visible = false;
                                GVHobby.Columns[3].Visible = false;
                                GVHobby.Columns[4].Visible = false;
                        }

                    }
                    if (ds.Tables[0].Rows[0]["USER_ID_ACTIVITYMANAGER"].ToString() != "" && ds.Tables[0].Rows[0]["USER_ID_ACTIVITYMANAGER"].ToString() != null)
                    {
                        OleDbDataReader dr1 = CBE.GetEMPCODE(ds.Tables[0].Rows[0]["USER_ID_ACTIVITYMANAGER"].ToString());
                        while (dr1.Read())
                        {

                            txtEMPCodeActivityManager.Text = dr1[0].ToString();
                            txtEMPNameActivityManager.Text = dr1[1].ToString();

                        }
                        dr1.Close();
                    }
                   
                    if (ds.Tables[0].Rows[0]["USERID_OF_CLUSTER"].ToString() != "" && ds.Tables[0].Rows[0]["USERID_OF_CLUSTER"].ToString() != null)
                    {
                        OleDbDataReader dr1 = CBE.GetEMPCODE(ds.Tables[0].Rows[0]["USERID_OF_CLUSTER"].ToString());
                        while (dr1.Read())
                        {

                            txtEMPCodeOfClusterHR.Text = dr1[0].ToString();
                            txtEMPNameOfCluster.Text = dr1[1].ToString();

                        }
                        dr1.Close();
                    }
                  
                    if (ds.Tables[0].Rows[0]["USERID_OF_HO"].ToString() != "" && ds.Tables[0].Rows[0]["USERID_OF_HO"].ToString() != null)
                    {
                        OleDbDataReader dr1 = CBE.GetEMPCODE(ds.Tables[0].Rows[0]["USERID_OF_HO"].ToString());
                        while (dr1.Read())
                        {

                            txtEMPCodeOfHOHR.Text = dr1[0].ToString();
                            txtEMPOfNameHOHR.Text = dr1[1].ToString();

                        }
                        dr1.Close();
                    }
                  
                    txtEmpCode.Text = ds.Tables[0].Rows[0]["EMP_CODE"].ToString();
                    txtLastName.Text = ds.Tables[0].Rows[0]["LASTNAME"].ToString();
                    txtMiddileName.Text = ds.Tables[0].Rows[0]["MIDDLENAME"].ToString();
                    txtFirstName.Text = ds.Tables[0].Rows[0]["FIRSTNAME"].ToString();
                    ddlSex.SelectedValue = ds.Tables[0].Rows[0]["GENDER"].ToString();
                    txtFatherName.Text = ds.Tables[0].Rows[0]["FATHER_NAME"].ToString();
                    if (ds.Tables[0].Rows[0]["DOB"].ToString() != null && ds.Tables[0].Rows[0]["DOB"].ToString() != "")
                    {
                        txtDOB.Text = Convert.ToDateTime(ds.Tables[0].Rows[0]["DOB"]).ToString("dd/MM/yyyy");
                    }
                    string str3 = ds.Tables[0].Rows[0]["NAME_OF_BANK"].ToString();
                    if (str3 != "")
                    {
                        string[] arrBank = str3.Split('+');

                        if (arrBank.Length > 0)
                             {
                                 if (arrBank[0].ToString() == "OTHER" )
                                 {
                                     ddlNameOfBank.DataBind();
                                     ddlNameOfBank.SelectedValue = "OTHER";
                                     txtNameOfBank.Text = arrBank[1].ToString();
                                 }
                                 else
                                 {
                                     ddlNameOfBank.SelectedValue = arrBank[0].ToString();
                                 }
                             }
                        
                    }
                    txtAC.Text = ds.Tables[0].Rows[0]["SUVIDHA_AC"].ToString();
                    txtPresentAdd1.Text = ds.Tables[0].Rows[0]["Add1"].ToString();
                    txtPresentAdd2.Text = ds.Tables[0].Rows[0]["Add2"].ToString();
                    txtPresentAdd3.Text = ds.Tables[0].Rows[0]["Add3"].ToString();
                    txtPermanentAdd1.Text = ds.Tables[0].Rows[0]["PR_ADD1"].ToString();
                    txtPerMananetAdd2.Text = ds.Tables[0].Rows[0]["PR_ADD2"].ToString();
                    txtPermanentAdd3.Text = ds.Tables[0].Rows[0]["PR_ADD3"].ToString();
                    txtPhonepresentAdd.Text = ds.Tables[0].Rows[0]["PHONE_R"].ToString();
                    txtPermanentTelePhoneNo.Text = ds.Tables[0].Rows[0]["PHONE_PERMAENT_ADD"].ToString();
                    txtMobileNo.Text = ds.Tables[0].Rows[0]["MOBILE"].ToString();
                    txtHieght.Text = ds.Tables[0].Rows[0]["HEIGHT"].ToString();
                    txtWeight.Text = ds.Tables[0].Rows[0]["WEIGHT"].ToString();
                    txtBloodGroup.Text = ds.Tables[0].Rows[0]["BLOOD_GROUP"].ToString();
                    ddlMaritalStatus.SelectedValue = ds.Tables[0].Rows[0]["MARTAL_STATUS"].ToString();
                    txtLanguage.Text = ds.Tables[0].Rows[0]["LANGUAGE_KNOWN"].ToString();
                    txtWifeName.Text = ds.Tables[0].Rows[0]["WIFE_NAME"].ToString();
                    txtWifeAge.Text = ds.Tables[0].Rows[0]["WIFE_AGE"].ToString();
                    ddlRelation.SelectedValue = ds.Tables[0].Rows[0]["RELATION_WITH_EMPLOYEE"].ToString();
                    txtRelation.Text = ds.Tables[0].Rows[0]["RELATION_NAME_WITH_EMPLOYEE"].ToString();
                    ddllCourtProceeding.SelectedValue = ds.Tables[0].Rows[0]["COURT_PROCEEDING"].ToString();
                    txtCourtProceeding.Text = ds.Tables[0].Rows[0]["DETAIL_OF_COURT_PROCEEDING"].ToString();
                    ddlContagiousDisease.SelectedValue = ds.Tables[0].Rows[0]["CONTAGIOUS_DISEASE"].ToString();
                    txtCountagiosDisease.Text = ds.Tables[0].Rows[0]["CONTAGIOUS_DISEASE_DETAIL"].ToString();
                    txtNominee.Text = ds.Tables[0].Rows[0]["NOMINEE_NAME"].ToString();
                    txtPF.Text = ds.Tables[0].Rows[0]["PF#"].ToString();
                    txtESIC.Text = ds.Tables[0].Rows[0]["ESIC#"].ToString();
                    txtCity.Text = ds.Tables[0].Rows[0]["CITY"].ToString();
                    txtPin.Text = ds.Tables[0].Rows[0]["PIN"].ToString();
                    txtRelatveName.Text = ds.Tables[0].Rows[0]["RELATIVE_NAME"].ToString();
                    txtRelativeCode.Text = ds.Tables[0].Rows[0]["RELATIVE_CODE"].ToString();
                    if (ds.Tables[0].Rows[0]["KIT_RECEIVED_DATE"].ToString() != null && ds.Tables[0].Rows[0]["KIT_RECEIVED_DATE"].ToString() != "")
                    {
                        txtKitRedeivedDate.Text = ds.Tables[0].Rows[0]["KIT_RECEIVED_DATE"].ToString();
                    }

                    //if (ds.Tables[0].Rows[0]["DOL"].ToString() != null && ds.Tables[0].Rows[0]["DOL"].ToString() != "")
                    //{
                    //    txtLastWorkingDay.Text = Convert.ToDateTime(ds.Tables[0].Rows[0]["DOL"]).ToString("dd/MM/yyyy");
                    //}
                    if (ds.Tables[0].Rows[0]["DOL"].ToString() != null && ds.Tables[0].Rows[0]["DOL"].ToString() != "")
                    {
                        txtLastWorkingDay.Text = Convert.ToDateTime(ds.Tables[0].Rows[0]["DOL"]).ToString("dd/MM/yyyy");
                    }
                    if (ds.Tables[0].Rows[0]["DOJ"].ToString() != null && ds.Tables[0].Rows[0]["DOJ"].ToString() != "")
                    {
                        txtDOJ.Text = Convert.ToDateTime(ds.Tables[0].Rows[0]["DOJ"]).ToString("dd/MM/yyyy");
                    }
                    if (ds.Tables[0].Rows[0]["DESIGNATION_ID"].ToString() != "" && ds.Tables[0].Rows[0]["DESIGNATION_ID"].ToString() != null)
                    {
                        ddlDesignation.SelectedValue = ds.Tables[0].Rows[0]["DESIGNATION_ID"].ToString();
                    }
                    if (ds.Tables[0].Rows[0]["DEPARTMENT_ID"].ToString() != "" && ds.Tables[0].Rows[0]["DEPARTMENT_ID"].ToString() != null)
                    {
                        ddlDepartment.SelectedValue = ds.Tables[0].Rows[0]["DEPARTMENT_ID"].ToString();
                    }
                    ddlTypeOfCategory.SelectedValue = ds.Tables[0].Rows[0]["EMP_TYPE"].ToString();
                    if (ds.Tables[0].Rows[0]["ACTIVITY_ID"].ToString() != "" && ds.Tables[0].Rows[0]["ACTIVITY_ID"].ToString() != null)
                    {
                        ddlUnit.SelectedValue = ds.Tables[0].Rows[0]["ACTIVITY_ID"].ToString();
                    }
                    if (ds.Tables[0].Rows[0]["CLIENT_ID"].ToString() != "" && ds.Tables[0].Rows[0]["CLIENT_ID"].ToString() != null)
                    {
                        ddlClient.SelectedValue = ds.Tables[0].Rows[0]["CLIENT_ID"].ToString();
                    }
                    if (ds.Tables[0].Rows[0]["PRODUCT_ID"].ToString() != "" && ds.Tables[0].Rows[0]["PRODUCT_ID"].ToString() != null)
                    {
                        ddlProduct.SelectedValue = ds.Tables[0].Rows[0]["PRODUCT_ID"].ToString();
                    }
                    if (ds.Tables[0].Rows[0]["COMPANY_ID"].ToString() != "" && ds.Tables[0].Rows[0]["COMPANY_ID"].ToString() != null)
                    {
                        ddlCompany.SelectedValue = ds.Tables[0].Rows[0]["COMPANY_ID"].ToString();
                    }
                    if (ds.Tables[0].Rows[0]["APPROVAL_MAIL_DATE"].ToString() != null && ds.Tables[0].Rows[0]["APPROVAL_MAIL_DATE"].ToString() != "")
                    {
                        txtApprovalMailDate.Text = ds.Tables[0].Rows[0]["APPROVAL_MAIL_DATE"].ToString();
                    }
                    if (ds.Tables[0].Rows[0]["DOL_Reason"].ToString() != null && ds.Tables[0].Rows[0]["DOL_Reason"].ToString() != "")
                    {
                        ddldolreason.SelectedValue = ds.Tables[0].Rows[0]["DOL_reason"].ToString();
                    }

                    txtApprovedBy.Text = ds.Tables[0].Rows[0]["APPROVED_BY_OTHER"].ToString();
                    dsSalary = CBEF.GetSalary(Request.QueryString["EMP_ID"].ToString());
                    if (dsSalary.Tables[0].Rows.Count != 0)
                    {
                        txtBasic.Text = dsSalary.Tables[0].Rows[0]["Basic"].ToString();
                        txtHRA.Text = dsSalary.Tables[0].Rows[0]["HRA"].ToString();
                        txtSPAllo.Text = dsSalary.Tables[0].Rows[0]["SP_All"].ToString();
                        txtGrossAmt.Text = dsSalary.Tables[0].Rows[0]["Gross_Amt"].ToString();
                        bflag = false;
                    }
                    ds.Dispose();
                    dsSalary.Dispose();
                    hdfEMPID.Value = Request.QueryString["EMP_ID"].ToString();
                    GVChildDetail.DataBind();
                    gvEmployementDetail.DataBind();
                    GVHobby.DataBind();
                    gvQualification.DataBind();
                    GVReferenceDetail.DataBind();
                    DataSet dschild = new DataSet();
                    dschild = CBEF.GetChildDetail(hdfEMPID.Value.ToString());
                    DataRow row;
                    dt.Columns.Add("Child Name");
                    dt.Columns.Add("Child Age");
                    row = dt.NewRow();
                    if (dschild.Tables[0].Rows.Count > 0)
                    {
                        for (int i = 0; i < dschild.Tables[0].Rows.Count; i++)
                        {

                            dt.Rows.Add();
                            dt.Rows[i]["Child Name"] = dschild.Tables[0].Rows[i]["Child Name"].ToString();
                            dt.Rows[i]["Child Age"] = dschild.Tables[0].Rows[i]["Child Age"].ToString();
                        }
                    }
                    ViewState["v1"] = dt;
                    GVChildDetail.DataSource = dt;
                    GVChildDetail.DataBind();
                    dschild.Dispose();
                }
                else
                {
                    btnPersonal.Visible = false;
                    btnOther.Visible = false;
                   
                    lblMode.Text = "[Add]";
                }
            }
        }
        catch (Exception ex)
        {
            lblMsg.Text = ex.Message;
        }


    }




    
    protected void btnSavePersonal_Click(object sender, EventArgs e)
    
    {
        //Property Assignment
        
        try
        {
            CBEF.Title = ddlTitle.SelectedValue;
            CBEF.LName = txtLastName.Text.Trim();
            CBEF.MName = txtMiddileName.Text.Trim();
            CBEF.FName = txtFirstName.Text.Trim();
            CBEF.FathersName = txtFatherName.Text.Trim();
            CBEF.DoB = txtDOB.Text.Trim();
            btnPersonal.Visible = true;
            btnOther.Visible = true;
           
            CBEF.PANNO = txtPan.Text.Trim();
            bool bflagCluster = false;
            bool bflagCentre = false;
            bool bfHO = false;
            bool bfSubcentre=false;
           
            if (Request.QueryString["EMP_ID"] == null )
            {
                CBEF.CentreID = Session["CentreID"].ToString();
                    
                string strRole = Session["RoleID"].ToString();
                string[] strRole1 = strRole.Split(',');

                foreach (string str in strRole1)
                {

                    if (str == "25")
                    {
                        bflagCluster = true;
                        tblClusterHR.Visible = true;
                    }
                    if (str == "24")
                    {
                        bfHO = true;
                        tblHOHR.Visible = true;
                    }
                    if (str == "23")
                    {
                        bflagCentre = true;
                    }
                    if(str == "22")
                    {
                        bfSubcentre=true;
                    }
                }
                if (bfSubcentre == true)
                {
                    CBEF.CentreID = Session["CentreID"].ToString();
                    CBEF.SubCentreID = Request.QueryString["SubCentreID"].ToString();
                }
                if ( bflagCentre == true)
                {
                    CBEF.CentreID = Session["CentreID"].ToString();
                    CBEF.SubCentreID = Request.QueryString["SubCentreID"].ToString();
                }
                if (bflagCluster==true)
                {
                    CBEF.CentreID = Request.QueryString["CentreID"].ToString();
                    CBEF.SubCentreID = Request.QueryString["SubCentreID"].ToString();
                }
                if (bfHO == true)
                {
                    CBEF.CentreID = Request.QueryString["CentreID"].ToString();
                    CBEF.SubCentreID = Request.QueryString["SubCentreID"].ToString();

                }
               
               
                
            }
            if (ddlNameOfBank.SelectedIndex != 0)
            {
                CBEF.NameOfBank = ddlNameOfBank.SelectedValue;
                if (ddlNameOfBank.SelectedValue == "OTHER")
                {
                    CBEF.NameOfBank = "OTHER" + "+" + txtNameOfBank.Text.Trim();

                }
            }
            else
                CBEF.NameOfBank = "";

            CBEF.ACNO = txtAC.Text.Trim();
            CBEF.City = txtCity.Text.Trim();
            CBEF.Pin = txtPin.Text.Trim();
            CBEF.RelativeName = txtRelatveName.Text.Trim();
            CBEF.RelativeCode = txtRelativeCode.Text.Trim();
            CBEF.NominneTitle = ddlNomineeTitle.SelectedValue;
            CBEF.PresentAdd1 = txtPresentAdd1.Text.Trim();
            CBEF.PresentAdd2 = txtPresentAdd2.Text.Trim();
            CBEF.PresentAdd3 = txtPresentAdd3.Text.Trim();
            CBEF.Phone = txtPhonepresentAdd.Text.Trim();
            CBEF.PermanentAdd1 = txtPermanentAdd1.Text.Trim();
            CBEF.PernanentAdd2 = txtPerMananetAdd2.Text.Trim();
            CBEF.PermanentAdd3 = txtPermanentAdd3.Text.Trim();
            CBEF.PhonePermanentAdd = txtPermanentTelePhoneNo.Text.Trim();
            CBEF.Hieght = txtHieght.Text.Trim();
            CBEF.Weight = txtWeight.Text.Trim();
            CBEF.BloodGroup = txtBloodGroup.Text.Trim();
            CBEF.Gender = ddlSex.SelectedValue;
            CBEF.MarritalStatus = ddlMaritalStatus.Text.Trim();
            CBEF.LaguageKnown = txtLanguage.Text.Trim();
            CBEF.WifeName = txtWifeName.Text.Trim();
            CBEF.WifeAge = txtWifeAge.Text.Trim();
            CBEF.RelationWithEmployee = ddlRelation.SelectedValue;
            CBEF.RelationName = txtRelation.Text.Trim();
            CBEF.CourtProceeding = ddllCourtProceeding.SelectedValue;
            CBEF.DetailofCourtProceeding = txtCourtProceeding.Text.Trim();
            CBEF.ContagiousDisease = ddlContagiousDisease.SelectedValue;
            CBEF.DetailOfContagiousDisease = txtCountagiosDisease.Text.Trim();
            CBEF.NomineeName = txtNominee.Text.Trim();
            CBEF.AddedBy = Session["UserID"].ToString();
            CBEF.UserIDOfActivityManager = Session["UserID"].ToString();
            CBEF.Mobile = txtMobileNo.Text.Trim();

            if (hdfEMPID.Value!="")
            {
                CBEF.EmpID = hdfEMPID.Value;
                CBEF.ModifyBy = Session["UserID"].ToString();
                CBEF.UpdateEmployeeMaster();
                lblMsg.Text = "Record updated successfully";
            }

            else
            {
                CBEF.InsertEmployeePersonalDeatil();
                lblMsg.Text = "Record saved successfully";
            }
            hdfEMPID.Value = CBEF.EmpID;

            OleDbDataReader dr = CBE.GetEMPCODE(hdfEMPID.Value);
            string strCode = "";
            while (dr.Read())
            {
                strCode = dr[0].ToString();
            }
            dr.Close();
             if (FileUpload1.FileName != "")
            {
            if (FileUpload1.PostedFile.ContentType.Substring(0, FileUpload1.PostedFile.ContentType.IndexOf('/')) == "image")
            {
               

                    string strPath = Server.MapPath("EmployeePhoto/");


                    string strFile = strPath + strCode + FileUpload1.FileName.Remove(0, FileUpload1.FileName.IndexOf('.'));
                    FileUpload1.PostedFile.SaveAs(strFile);
                    //CBEF.PhotoPath =strCode + FileUpload1.FileName.Remove(0,FileUpload1.FileName.IndexOf('.'));
                    string strPhotoPath = strCode + FileUpload1.FileName.Remove(0, FileUpload1.FileName.IndexOf('.'));
                    CBE.Updatephoto(hdfEMPID.Value, strPhotoPath);
                    PhotoImage.ImageUrl = Server.MapPath("EmployeePhoto/") + strPhotoPath;
               }
                else
                CA.Show("Only image file can be uploaded.");
            }

            

            
        }
            catch (Exception ex)
        {
            lblMsg.Text = ex.Message;
        }
        try
        {
            CBEF.DoJ = txtDOJ.Text.Trim();
            CBEF.Designation = ddlDesignation.SelectedValue;
            CBEF.Department = ddlDepartment.SelectedValue;
            CBEF.ClientID = ddlClient.SelectedValue;
            CBEF.ProductID = ddlProduct.SelectedValue;
            CBEF.ActivityID = ddlUnit.SelectedValue;
            CBEF.CompanyID = ddlCompany.SelectedValue;
            CBEF.ModifyBy = Session["UserID"].ToString();
            CBEF.ApprovalMailDate = txtApprovalMailDate.Text.Trim();
            CBEF.ApprovalByOther = txtApprovedBy.Text.Trim();
            if (CBEF.EmpID == null)
            {
                CBEF.InsertEmployeePersonalDeatil();
                hdfEMPID.Value = CBEF.EmpID;
                OleDbDataReader dr = CBE.GetEMPCODE(hdfEMPID.Value);
                CBEF.EmpID = hdfEMPID.Value;//DALJIT
            }
            else
            {
                CBEF.EmpID = hdfEMPID.Value;
            }

            CBEF.EmpID = hdfEMPID.Value;
            CBEF.UserIDOfActivityManager = Session["UserID"].ToString();
            CBEF.HRA = txtHRA.Text.Trim();
            CBEF.Basic = txtBasic.Text.Trim();
            CBEF.SPAll = txtSPAllo.Text.Trim();
            if (txtHRA.Text !="" && txtSPAllo.Text != "")
            {
                CBEF.GrossAmt = Convert.ToString((Convert.ToDouble(txtHRA.Text.Trim()) + Convert.ToDouble(txtBasic.Text.Trim()) + Convert.ToDouble(txtSPAllo.Text.Trim())));
            }
            else
            CBEF.GrossAmt = Convert.ToDouble(txtBasic.Text.Trim()).ToString();
            CBEF.EmpType = ddlTypeOfCategory.SelectedValue;

            if (CBE.GetSearch(hdfEMPID.Value, "EMPLOYEE_SALARY_DETAIL") != 0)
            {
                CBEF.UpdateSalary();
                CBEF.InsertOfficailDetail();
                lblMsg.Text = "Record updated successfully";
            }
            else
            {
                CBEF.InsertSalary();
                CBEF.InsertOfficailDetail();
                lblMsg.Text = "Record saved successfully";
            }
            
        }
        catch (Exception ex)
        {
            lblMsg.Text = ex.Message;
        }
        dt = (DataTable)ViewState["v1"];
        if (ViewState["v1"] != null)
        {
            try
            {
                CBEF.DeleteChildInfo(hdfEMPID.Value);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    try
                    {
                        CBEF.ChildAge = dt.Rows[i]["Child Age"].ToString();
                        CBEF.ChildName = dt.Rows[i]["Child Name"].ToString();
                        CBEF.InsertChildDetail();
                    }
                    catch (Exception ex)
                    {
                        lblMsg.Text = ex.Message;
                    }
                }
            }
            catch (Exception ex)
            {
                lblMsg.Text = ex.Message;
            }
        }
        
        ddlQulfication.Focus();

    }

    public void ResetPersonalInfo()
    {
         txtLastName.Text="";
         txtMiddileName.Text="";
         txtFirstName.Text = "";
        txtFatherName.Text="";
        txtDOB.Text = "";
        ddlNameOfBank.SelectedIndex = 0;
        txtNameOfBank.Text = "";
        txtAC.Text = "";
        txtPresentAdd1.Text = "";
        txtPresentAdd2.Text = "";
        txtPermanentAdd3.Text = "";
        txtPhonepresentAdd.Text = "";
        txtPermanentAdd1.Text = "";
        txtPerMananetAdd2.Text = "";
        txtPermanentAdd3.Text = "";
        txtPermanentTelePhoneNo.Text="";
        txtHieght.Text = "";
        txtWeight.Text = "";
        txtBloodGroup.Text = "";
        ddlSex.SelectedIndex=0;
        ddlMaritalStatus.SelectedIndex=0;
        txtLanguage.Text="";
        txtWifeName.Text="";
        txtWifeAge.Text = "";
        ddlRelation.SelectedIndex=0;
        txtRelation.Text="";
        ddllCourtProceeding.SelectedIndex = 0;
        txtCourtProceeding.Text="";
        ddlContagiousDisease.SelectedIndex=0;
        txtCountagiosDisease.Text="";
        txtNominee.Text="";
        txtPan.Text = "";
        txtPresentAdd3.Text = "";
        txtMobileNo.Text = "";
        txtCity.Text = "";
        txtPin.Text = "";
        txtRelativeCode.Text = "";
        txtRelatveName.Text = "";
        txtDOJ.Text = "";
        ddlDesignation.SelectedIndex = 0;
        ddlDepartment.SelectedIndex = 0;
        ddlUnit.SelectedIndex = 0;
        ddlClient.SelectedIndex = 0;
        ddlProduct.SelectedIndex = 0;
        ddlCompany.SelectedIndex = 0;
        txtBasic.Text = "";
        txtHRA.Text = "";
        txtGrossAmt.Text = "";
        txtGrossInWord.Text = "";
        txtApprovalMailDate.Text = "";
        txtSPAllo.Text = "";
        txtApprovedBy.Text = "";
    }
    

    protected void ddlDesignation_DataBound(object sender, EventArgs e)
    {
        ddlDesignation.Items.Insert(0, new ListItem("--Select Designation--", "0"));

    }
    protected void ddlUnit_DataBound(object sender, EventArgs e)
    {
        ddlUnit.Items.Insert(0, new ListItem("--Select Unit--", "0"));

    }
    protected void ddlDepartment_DataBound(object sender, EventArgs e)
    {
        ddlDepartment.Items.Insert(0, new ListItem("--Select Department--", "0"));
    }
    protected void ddlClient_DataBound(object sender, EventArgs e)
    {
        ddlClient.Items.Insert(0, new ListItem("--Select Client--", "0"));
    }
    protected void ddlProduct_DataBound(object sender, EventArgs e)
    {
        ddlProduct.Items.Insert(0, new ListItem("--Select Product--", "0"));
    }
   
   
    protected void btnSaveChildInfo_Click(object sender, EventArgs e)
    {
        try
        {
            if (ViewState["v1"] != null)
            {
                dt = (DataTable)ViewState["v1"];
            }
            if (ViewState["v1"] != null && Session["Str"] == "Edit")
            {

                if (hdfInsUPChid.Value != "")
                {
                    j = Convert.ToInt32(hdfInsUPChid.Value);
                    dt.Rows[j].Delete();


                }

            }
            Session["Str"] = "";
            if (ViewState["v1"] == null)
            {
                dt.Columns.Add("Child Name");
                dt.Columns.Add("Child Age");
              
            }
            DataRow row;
            row = dt.NewRow();
            row["Child Name"] = txtNameOfChild.Text.Trim();
            row["Child Age"] = txtAgeOfChild.Text.Trim();
           
            dt.Rows.Add(row);

            ViewState["v1"] = dt;
            GVChildDetail.DataSource = dt;
            GVChildDetail.DataBind();
            txtNameOfChild.Text = "";
            txtAgeOfChild.Text = "";
            txtNameOfChild.Focus();
        }
        catch (Exception ex)
        {
           
            lblMsg.Text = ex.Message.ToString();
        }
        txtNameOfChild.Focus();
        //try
        //{
           
        //    CBEF.ChildName = txtNameOfChild.Text.Trim();
        //    CBEF.ChildAge = txtAgeOfChild.Text.Trim();

        //    CBEF.EmpID = hdfEMPID.Value;

        //    if (hdfInsUPChid.Value == "")
        //    {
        //        CBEF.InsertChildDetail();
        //    }
        //    else
        //    {
        //        CBEF.ChildrenDetailId = Convert.ToInt32(hdfInsUPChid.Value);
        //        CBEF.UpdateChildDetail();
        //    }
        //    txtNameOfChild.Text = "";
        //    txtAgeOfChild.Text = "";
        //    GVChildDetail.DataBind();
        //    hdfInsUPChid.Value = "";
        //}
        //catch (Exception ex)
        //{
        //    lblMsg.Text = ex.Message;
        //}
    }
    protected void btnSaveEducation_Click(object sender, EventArgs e)
    {
        try
        {
            CBEF.EmpID = hdfEMPID.Value;
            string strCode = "";
            if (FileUpload2.FileName != "")
            {
            if (FileUpload2.PostedFile.ContentType.Substring(0, FileUpload2.PostedFile.ContentType.IndexOf('/')) == "image")
            {
              
                    OleDbDataReader dr = CBE.GetEMPCODE(hdfEMPID.Value);

                    while (dr.Read())
                    {
                        strCode = dr[0].ToString();
                    }
                    dr.Close();
                    string strPath = Server.MapPath("EmployeeDocument/");

                    string strFile = strPath + strCode + FileUpload2.FileName;
                    FileUpload2.PostedFile.SaveAs(strFile);

             }
                else
                CA.Show("Only image file can be uploaded.");
            }
           

            if (ddlQulfication.SelectedIndex != 0)
            {
                CBEF.TypeOfQualification = ddlQulfication.SelectedValue;
            }
            CBEF.NameOfCollege = txtNameOfCollage.Text.Trim();
            CBEF.Duration = txtFromToYear.Text.Trim();
            CBEF.CertifcateExam = txtCertificate.Text.Trim();
            CBEF.DivMarks = txtDivMarks.Text.Trim();
            CBEF.copyAttached = ddlCopyAttached.SelectedValue;
            if (FileUpload2.PostedFile.ContentType.Substring(0, FileUpload2.PostedFile.ContentType.IndexOf('/')) == "image")
            {
                CBEF.FilePath = strCode + FileUpload2.FileName;
            }
            else
            {
                CBEF.FilePath = null;
                CBEF.copyAttached = "No";
            }

            if (hdfEducation.Value == "")
            {
                CBEF.InsertQualification();
                lblMsg.Text = "Record saved successfully";
            }
            else
            {
                CBEF.QualificationDetailId = Convert.ToInt32(hdfEducation.Value);
                CBEF.UpdateQualificationDetail();
                lblMsg.Text = "Record updated successfully";
            }

            gvQualification.DataBind();
            ResetQualification();
            hdfEducation.Value = "";
            ddlTypeOfCategory.Focus();
        }
        catch (Exception ex)
        {
            lblMsg.Text = ex.Message;
        }
        ddlQulfication.Focus();
    }
    public void ResetQualification()
    {
        txtNameOfCollage.Text = "";
        txtNameOfCollage.Text = "";
        txtCertificate.Text = "";
        txtDivMarks.Text = "";
        txtFromToYear.Text = "";
        ddlQulfication.SelectedIndex = 0;
    }
    
    protected void btnSaveEmployement_Click(object sender, EventArgs e)
    {
        try
        {
            CBEF.EmpID = hdfEMPID.Value;
            CBEF.EmployerName = txtEmployerName.Text.Trim();
            CBEF.EmployementDesignation = txtDesignation.Text.Trim();
            CBEF.EmployementDuration = txtFrom_To.Text.Trim();
            CBEF.EmployementSalary = txtSalary.Text.Trim();
            CBEF.ReasonForLeaving = txtReasonforLeaving.Text.Trim();
            CBEF.EmployementContactNo = txtEmploeeContact.Text.Trim();
            if (hdfEmployement.Value == "")
            {
                CBEF.InsertEmployementDetail();
                lblMsg.Text = "Record saved successfully";
            }
            else
            {
                CBEF.EmployementDetailId = Convert.ToInt32(hdfEmployement.Value);
                CBEF.UpdateEmployementDetail();
                lblMsg.Text = "Record updated successfully";
            }
            ResetEmployementDetail();
            gvEmployementDetail.DataBind();
            hdfEmployement.Value = "";
            txtEmployerName.Focus();
        }
        catch (Exception ex)
        {
            lblMsg.Text = ex.Message;
        }
        txtEmployerName.Focus();
    }
    public void ResetEmployementDetail()
    {
        txtReasonforLeaving.Text = "";
        txtEmployerName.Text = "";
        txtDesignation.Text = "";
        txtFrom_To.Text = "";
        txtSalary.Text = "";
        txtReasonforLeaving.Text = "";
        txtEmploeeContact.Text = "";
       
    }
  
    protected void btnSaveHobby_Click(object sender, EventArgs e)
    {
        try
        {
            CBEF.EmpID = hdfEMPID.Value;
            CBEF.LiteraryCulture = txtLiterary.Text.Trim();
            CBEF.Sport = txtSport.Text.Trim();
            CBEF.Hobbies = txtHobby.Text.Trim();
            if (hdfHobby.Value == "")
            {
                CBEF.InsertHobby();
                lblMsg.Text = "Record saved successfully";
            }
            else
            {
                CBEF.HobbytDetailId = Convert.ToInt32(hdfHobby.Value);
                CBEF.UpdateHobbyDetail();
                lblMsg.Text = "Record updated successfully";
            }
            ResetHobby();
            GVHobby.DataBind();
            hdfHobby.Value = "";
            txtLiterary.Focus();
        }
        catch (Exception ex)
        {
            lblMsg.Text = ex.Message;
        }
        txtLiterary.Focus();
    }

    public void ResetHobby()
    {
        txtLiterary.Text = "";
        txtSport.Text = "";
        txtHobby.Text = "";
       
    }

  
    protected void btnSaveReference_Click(object sender, EventArgs e)
    {
        try
        {
            CBEF.EmpID = hdfEMPID.Value;
            CBEF.ReferenceName = txtReferenceName.Text.Trim();
            CBEF.ReferenceAddress = txtReferenceAddress.Text.Trim();
            CBEF.ReferenceOccupation = txtOccupation.Text.Trim();
            CBEF.RefrenceContactNo = txtContactNo.Text.Trim();
            CBEF.RefrenceRelation = txtRelationReference.Text.Trim();
            if (hdfReference.Value == "")
            {
                CBEF.InsertReferenceDetail();
                lblMsg.Text = "Record saved successfully";
            }
            else
            {
                CBEF.ReferencetDetailId = Convert.ToInt32(hdfReference.Value);
                CBEF.UpdateReferenceDetail();
                lblMsg.Text = "Record updated sucessfully";
            }
            ResetReferenceDetail();
            hdfReference.Value = "";
            GVReferenceDetail.DataBind();
            txtReferenceName.Focus();
        }
        catch (Exception ex)
        {
            lblMsg.Text = ex.Message;
        }
        txtReferenceName.Focus();
    }
  
    public void ResetReferenceDetail()
    {
        txtRelationReference.Text = "";
        txtReferenceName.Text = "";
        txtReferenceAddress.Text = "";
        txtRelationReference.Text = "";
        txtOccupation.Text = "";
        txtContactNo.Text = "";
        
 
    }

   
    //protected void GVChildDetail_RowCommand(object sender, GridViewCommandEventArgs e)
    //{
    //    if (e.CommandName == "Ed")
    //    {
    //        try
    //        {
    //            dt = (DataTable)ViewState["v1"];
    //            txtAgeOfChild.Text = dt.Rows[e.NewEditIndex]["Child Name"].ToString();
    //            txtNameOfChild.Text = dt.Rows[e.NewEditIndex]["Child Age"].ToString();
               
    //            j = e.NewEditIndex;
    //            Session["Str"] = "Edit";
    //            hdfInsUPChid.Value = j.ToString();

    //            GVChildDetail.DataSource = dt;

    //            GVChildDetail.DataBind();
    //            ViewState["v1"] = dt;
    //        }
    //        catch (Exception ex)
    //        {
    //            lblMsg.Visible = true;
    //            lblMsg.Text = ex.Message.ToString();
    //        }
    //    }
    //    if (e.CommandName == "Del")
    //    {

    //        try
    //        {
    //            dt = (DataTable)ViewState["v1"];
    //            dt.Rows[e.RowIndex].Delete();
    //            GVChildDetail.DataSource = dt;
    //            GVChildDetail.DataBind();
    //            ViewState["v1"] = dt;
    //        }
    //        catch (Exception ex)
    //        {
                
    //            lblMsg.Text = ex.Message.ToString();
    //        }
    //    }
    //}
    
    protected void GVChildDetail_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            LinkButton link1 = (LinkButton)e.Row.FindControl("lnkTemplate");

            link1.Attributes.Add("onclick", "javascript:return " +
                          "confirm('Are you sure you want to delete this record')");
        }
    }
    protected void gvQualification_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        DataSet ds = new DataSet();
        ds = CBEF.GetQualificationDetail(hdfEMPID.Value, Convert.ToInt32(e.CommandArgument));
        if (e.CommandName == "Ed")
        {            
            
            CBEF.EmpID = hdfEMPID.Value;
            CBEF.QualificationDetailId = Convert.ToInt32(e.CommandArgument);
            txtNameOfCollage.Text = ds.Tables[0].Rows[0]["Name_of_College"].ToString();
            txtFromToYear.Text = ds.Tables[0].Rows[0]["Duration_of_Education"].ToString();
            txtCertificate.Text = ds.Tables[0].Rows[0]["Certificate_Examination"].ToString();
            txtDivMarks.Text = ds.Tables[0].Rows[0]["Div_Marks"].ToString();
            ddlCopyAttached.SelectedValue = ds.Tables[0].Rows[0]["Copies_Attached"].ToString();
            ddlQulfication.SelectedValue = ds.Tables[0].Rows[0]["Type_of_Qualification"].ToString();
            hdfEducation.Value = e.CommandArgument.ToString();
            ds.Dispose();
            ddlQulfication.Focus();
        }
        if (e.CommandName == "del")
        {
            
            CBEF.DeleteQualificationInfo(hdfEMPID.Value, Convert.ToInt32(e.CommandArgument));
            DirectoryInfo di = new DirectoryInfo(Server.MapPath("EmployeeDocument"));
            
            FileInfo[] Files = di.GetFiles();
            foreach (FileInfo fi in Files)
            {
                if (fi.ToString() ==  ds.Tables[0].Rows[0]["File_Path"].ToString())
                {
                    fi.Delete();
                }
            }
            
            gvQualification.DataBind();
            hdfEducation.Value = "";
            lblMsg.Text = "Record deleted sucessfully";
            ddlQulfication.Focus();
        }
    }
    protected void gvQualification_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            LinkButton link1 = (LinkButton)e.Row.FindControl("lnkdeleteEmpQualification");

            link1.Attributes.Add("onclick", "javascript:return " +
                          "confirm('Are you sure you want to delete this record')");

            HyperLink HypLink1 = (HyperLink)e.Row.FindControl("lnkView");
            
            if (e.Row.Cells[5].Text.ToString() == "No")
            {
                HypLink1.Visible = false;
            }
        }
    }
    protected void gvEmployementDetail_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Ed")
        {
            DataSet ds = new DataSet();
            ds = CBEF.GetEmployementDetail(hdfEMPID.Value, Convert.ToInt32(e.CommandArgument));
            CBEF.EmpID = hdfEMPID.Value;
            CBEF.EmployementDetailId = Convert.ToInt32(e.CommandArgument);
            txtEmployerName.Text = ds.Tables[0].Rows[0]["Employer_Name"].ToString();
            txtFrom_To.Text = ds.Tables[0].Rows[0]["Duration_of_Employment"].ToString();
            txtSalary.Text = ds.Tables[0].Rows[0]["Salary"].ToString();
            txtReasonforLeaving.Text = ds.Tables[0].Rows[0]["Reason_of_Leaving"].ToString();
            txtDesignation.Text = ds.Tables[0].Rows[0]["Designation_Nature_job"].ToString();
            txtEmploeeContact.Text = ds.Tables[0].Rows[0]["Contact_No"].ToString();
            hdfEmployement.Value = e.CommandArgument.ToString();
            ds.Dispose();
            txtEmployerName.Focus();
        }
        if (e.CommandName == "del")
        {

            CBEF.DeleteEmployementInfo(hdfEMPID.Value, Convert.ToInt32(e.CommandArgument));
            gvEmployementDetail.DataBind();
            hdfEmployement.Value = "";
            lblMsg.Text = "Record deleted sucessfully";
            txtEmployerName.Focus();
        }
    }
    protected void gvEmployementDetail_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            LinkButton link1 = (LinkButton)e.Row.FindControl("lnkdeleteEmpQualification");

            link1.Attributes.Add("onclick", "javascript:return " +
                          "confirm('Are you sure you want to delete this record')");
        }
    }
    protected void GVHobby_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Ed")
        {
            DataSet ds = new DataSet();
            ds = CBEF.GetHobbyDetail(hdfEMPID.Value, Convert.ToInt32(e.CommandArgument));
            CBEF.EmpID = hdfEMPID.Value;
            CBEF.HobbytDetailId = Convert.ToInt32(e.CommandArgument);
            txtLiterary.Text = ds.Tables[0].Rows[0]["Literary_Cultural_Art"].ToString();
            txtSport.Text = ds.Tables[0].Rows[0]["Sports"].ToString();
            txtHobby.Text = ds.Tables[0].Rows[0]["Hobbies"].ToString();
            hdfHobby.Value = e.CommandArgument.ToString();
            ds.Dispose();
            txtLiterary.Focus();
        }
        if (e.CommandName == "del")
        {

            CBEF.DeleteHobbyInfo(hdfEMPID.Value, Convert.ToInt32(e.CommandArgument));
            GVHobby.DataBind();
            hdfHobby.Value = "";
            lblMsg.Text = "Record deleted sucessfully";
            txtLiterary.Focus();
        }
    }
    protected void GVHobby_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            LinkButton link1 = (LinkButton)e.Row.FindControl("lnkdeleteEmpHobby");

            link1.Attributes.Add("onclick", "javascript:return " +
                          "confirm('Are you sure you want to delete this record')");
        }

    }
    protected void GVReferenceDetail_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Ed")
        {
            DataSet ds = new DataSet();
            ds = CBEF.GetReferenceDetail(hdfEMPID.Value, Convert.ToInt32(e.CommandArgument));
            CBEF.EmpID = hdfEMPID.Value;
            CBEF.ReferencetDetailId = Convert.ToInt32(e.CommandArgument);
            txtReferenceName.Text = ds.Tables[0].Rows[0]["Name"].ToString();
            txtReferenceAddress.Text = ds.Tables[0].Rows[0]["Address"].ToString();
            txtRelationReference.Text = ds.Tables[0].Rows[0]["Relation"].ToString();
            txtContactNo.Text = ds.Tables[0].Rows[0]["Contact_No"].ToString();
            txtOccupation.Text = ds.Tables[0].Rows[0]["Occupation"].ToString();
            hdfReference.Value = e.CommandArgument.ToString();
            ds.Dispose();
            txtReferenceName.Focus();
        }
        if (e.CommandName == "del")
        {

            CBEF.DeleteReferenceInfo(hdfEMPID.Value, Convert.ToInt32(e.CommandArgument));
            GVReferenceDetail.DataBind();
            hdfReference.Value = "";
            lblMsg.Text = "Record deleted sucessfully";
            txtReferenceName.Focus();
        }
    }
    protected void GVReferenceDetail_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            LinkButton link1 = (LinkButton)e.Row.FindControl("lnkdeleteEmpReference");

            link1.Attributes.Add("onclick", "javascript:return " +
                          "confirm('Are you sure you want to delete this record')");
        }

    }
    protected void btnApproveCluster_Click(object sender, EventArgs e)
    {
       CBE.EMPID = hdfEMPID.Value;
               CBE.UserIDCluster = Session["UserID"].ToString();
        CBE.ApprovalOfCL = "Y".Trim();
        CBE.ApproveCluster();
        lblMsg.Text = "Approved By Cluster HR successfully";
         bool bflg = true;
         string strRloeID1 = Session["RoleID"].ToString();
         string[] strRole2 = strRloeID1.Split(',');
         foreach (string str in strRole2)
         {
             if (str == "24")
             {
                 bflg = false;
             }
         }
         if (bflg == true)
         {
             if (Request.QueryString["ID"] != null && Request.QueryString["EMP_ID"] != "")
             {
                 Response.Redirect("BIS_APPROVAL_VIEW.aspx?SubCentreID1=" + hdfSubcentre.Value + " &CentreID1=" + hdfCentre.Value + " &ClusterID1=" + hdfCluster.Value);
             }
             else
                 Response.Redirect("BIS_ENTRY_VIEW.aspx?SubCentreID1=" + hdfSubcentre.Value + " &CentreID1=" + hdfCentre.Value + " &ClusterID1=" + hdfCluster.Value);
         }
    }
    protected void btnApproveHOHR_Click(object sender, EventArgs e)
    {
        CBE.EMPID = hdfEMPID.Value;
        //CBE.EMPID = Request.QueryString["EMP_ID"];
        CBE.UserIDHO = Session["UserID"].ToString();
        CBE.ApprovalOfHO = "Y".Trim();
        CBE.EMPCODE = txtEmpCode.Text.Trim();
        CBE.KitReceivedDate = txtKitRedeivedDate.Text.Trim();
        CBE.PF = txtPF.Text.Trim();
        CBE.ESIC = txtESIC.Text.Trim();
        CBE.DOL = txtLastWorkingDay.Text.Trim();

        if (txtLastWorkingDay.Text.Trim() == "" && ddldolreason.SelectedIndex == 0)
        {
            CBE.DolReason = ddldolreason.SelectedValue.ToString().Trim();

            CBE.ApproveByHO();
            lblMsg.Text = "Approved By HO-HR successfully";
            txtKitRedeivedDate.Text = "";
            txtPF.Text = "";
            txtESIC.Text = "";
            txtLastWorkingDay.Text = "";
            OleDbDataReader dr = CBE.GetEMPCODE(hdfEMPID.Value);
            string strCode = "";
            string strCode1 = "";


            if (Request.QueryString["ID"] != null && Request.QueryString["EMP_ID"] != "")
            {
                Response.Redirect("BIS_APPROVAL_VIEW.aspx?SubCentreID1=" + hdfSubcentre.Value + " &CentreID1=" + hdfCentre.Value + " &ClusterID1=" + hdfCluster.Value);
            }
            else
                Response.Redirect("BIS_ENTRY_VIEW.aspx?SubCentreID1=" + hdfSubcentre.Value + " &CentreID1=" + hdfCentre.Value + " &ClusterID1=" + hdfCluster.Value);

        }
        //else
        //{
          //  lblMsg.Text = "Please Check DOL and DOL Reason both are Selected or not.";
        //}
        ///////add by kamal//////////////////////////
        if (txtLastWorkingDay.Text.Trim() != "" && ddldolreason.SelectedIndex != 0)
        {
            CBE.DolReason = ddldolreason.SelectedValue.ToString().Trim();

            CBE.ApproveByHO();
            lblMsg.Text = "Approved By HO-HR successfully";
            txtKitRedeivedDate.Text = "";
            txtPF.Text = "";
            txtESIC.Text = "";
            txtLastWorkingDay.Text = "";
            OleDbDataReader dr = CBE.GetEMPCODE(hdfEMPID.Value);
            string strCode = "";
            string strCode1 = "";

        }

    }

    protected void ddlNameOfBank_DataBound(object sender, EventArgs e)
    {
        ddlNameOfBank.Items.Insert(0, new ListItem("OTHER", "OTHER"));
        ddlNameOfBank.Items.Insert(0, new ListItem("Select", "Select"));
        
    }
    public void ReadOnlyTrue()
    {
        txtAC.ReadOnly = true;
        txtAgeOfChild.ReadOnly = true;
        txtApprovalMailDate.ReadOnly = true;
        txtApprovedBy.ReadOnly = true;
        txtBasic.ReadOnly = true;
        txtBloodGroup.ReadOnly = true;
        txtCandidate.ReadOnly = true;
        txtCertificate.ReadOnly = true;
        txtContactNo.ReadOnly = true;
        txtCountagiosDisease.ReadOnly = true;
        txtCountagiosDisease.ReadOnly = true;
        txtCourtProceeding.ReadOnly = true;
        txtDesignation.ReadOnly = true;
        txtDivMarks.ReadOnly = true;
        txtDOB.ReadOnly = true;
        txtDOJ.ReadOnly = true;
        txtEmpCode.ReadOnly = true;
        txtEMPCodeActivityManager.ReadOnly = true;
        txtEMPCodeOfClusterHR.ReadOnly = true;
        txtEMPCodeOfHOHR.ReadOnly = true;
        txtEmployerName.ReadOnly = true;
        txtEMPNameActivityManager.ReadOnly = true;
        txtESIC.ReadOnly = true;
        txtFatherName.ReadOnly = true;
        txtFirstName.ReadOnly = true;
        txtFrom_To.ReadOnly = true;
        txtFromToYear.ReadOnly = true;
        txtGrossAmt.ReadOnly = true;
        txtGrossInWord.ReadOnly = true;
        txtHieght.ReadOnly = true;
        txtHobby.ReadOnly = true;
        txtHRA.ReadOnly = true;
        txtKitRedeivedDate.ReadOnly = true;
        txtLanguage.ReadOnly = true;
        txtLastName.ReadOnly = true;
        txtLastWorkingDay.ReadOnly = true;
        txtLiterary.ReadOnly = true;
        txtMiddileName.ReadOnly = true;
        txtMobileNo.ReadOnly = true;
        txtNameOfBank.ReadOnly = true;
        txtNameOfChild.ReadOnly = true;
        txtNameOfCollage.ReadOnly = true;
        txtNominee.ReadOnly = true;
        txtOccupation.ReadOnly = true;
        txtPerMananetAdd2.ReadOnly = true;
        txtPermanentAdd1.ReadOnly = true;
        txtPermanentAdd3.ReadOnly = true;
        txtPermanentTelePhoneNo.ReadOnly = true;
        txtPF.ReadOnly = true;
        txtPhonepresentAdd.ReadOnly = true;
        txtPresentAdd1.ReadOnly = true;
        txtPresentAdd2.ReadOnly = true;
        txtPresentAdd3.ReadOnly = true;
        txtReasonforLeaving.ReadOnly = true;
        txtReferenceAddress.ReadOnly = true;
        txtReferenceName.ReadOnly = true;
        txtRelation.ReadOnly = true;
        txtRelationReference.ReadOnly = true;
        txtSalary.ReadOnly = true;
        txtSPAllo.ReadOnly = true;
        txtSport.ReadOnly = true;
        txtWeight.ReadOnly = true;
        txtWifeAge.ReadOnly = true;
        txtWifeName.ReadOnly = true;
        ddlClient.Enabled = false;
        ddlCompany.Enabled = false;
        ddlContagiousDisease.Enabled = false;
        ddlCopyAttached.Enabled = false;
        ddlDepartment.Enabled = false;
        ddlDesignation.Enabled = false;
        ddllCourtProceeding.Enabled = false;
        ddlMaritalStatus.Enabled = false;
        ddlNameOfBank.Enabled = false;
        ddlNomineeTitle.Enabled = false;
        ddlProduct.Enabled = false;
        ddlQulfication.Enabled = false;
        ddlRelation.Enabled = false;
        ddlSex.Enabled = false;
        ddlTypeOfCategory.Enabled = false;
        ddlUnit.Enabled = false;
        btnSavePersonal.Visible = false;
       
        btnSaveChildInfo.Visible = false;
       
        btnSaveEducation.Visible = false;
        
        btnSaveEmployement.Visible = false;
        
        btnSaveHobby.Visible = false;
    
       
        btnSaveReference.Visible = false;
       
        btnApproveCluster.Visible = false;
        btnApproveHOHR.Visible = false;
        ddlTitle.Enabled = false;
    }

   
    protected void ddlCompany_DataBound(object sender, EventArgs e)
    {
        ddlCompany.Items.Insert(0, new ListItem("--Select Company--", "0"));
    }
    protected void GVChildDetail_RowEditing(object sender, GridViewEditEventArgs e)
    {
        try
        {
            dt = (DataTable)ViewState["v1"];
            txtAgeOfChild.Text = dt.Rows[e.NewEditIndex]["Child Age"].ToString();
            txtNameOfChild.Text = dt.Rows[e.NewEditIndex]["Child Name"].ToString();

            j = e.NewEditIndex;
            Session["Str"] = "Edit";
            hdfInsUPChid.Value = j.ToString();

            GVChildDetail.DataSource = dt;

            GVChildDetail.DataBind();
            ViewState["v1"] = dt;
        }
        catch (Exception ex)
        {
            lblMsg.Visible = true;
            lblMsg.Text = ex.Message.ToString();
        }
        txtNameOfChild.Focus();
    }
    protected void GVChildDetail_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            dt = (DataTable)ViewState["v1"];
            dt.Rows[e.RowIndex].Delete();
            GVChildDetail.DataSource = dt;
            GVChildDetail.DataBind();
            ViewState["v1"] = dt;
        }
        catch (Exception ex)
        {

            lblMsg.Text = ex.Message.ToString();
        }
        txtNameOfChild.Focus();
    }
    protected void btnConfirm_Click(object sender, EventArgs e)
    {
        string strRloeID1 = Session["RoleID"].ToString();
        string[] strRole2 = strRloeID1.Split(',');
        bool bhocl = true;
        foreach (string str in strRole2)
        {
          
            if (str == "24")
            {
                bhocl = false;
            }
            if (str == "25")
            {
                bhocl = false;
            }
        }
        if (bhocl == true)
        {
            if (Request.QueryString["ID"] != null && Request.QueryString["EMP_ID"] != "")
            {
                Response.Redirect("BIS_APPROVAL_VIEW.aspx?SubCentreID1=" + hdfSubcentre.Value + " &CentreID1=" + hdfCentre.Value + " &ClusterID1=" + hdfCluster.Value);
            }
            else
                Response.Redirect("BIS_ENTRY_VIEW.aspx?SubCentreID1=" + hdfSubcentre.Value + " &CentreID1=" + hdfCentre.Value + " &ClusterID1=" + hdfCluster.Value);
        }
        else
        lblMsg.Text = "Confirmed successfully";
    }
}
