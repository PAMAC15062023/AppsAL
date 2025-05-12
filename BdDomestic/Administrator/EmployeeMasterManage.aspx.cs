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

public partial class EmployeeMasterManage : System.Web.UI.Page
{
    CEmployeeMaster oEmpMaster = new CEmployeeMaster();
    protected void Page_Load(object sender, EventArgs e)
    {
        lblMsg.Text = "";
        if (!IsPostBack)
        {
            if (Request.QueryString["EMP_ID"] != null && Request.QueryString["EMP_ID"] != "")
            {
                if (Session.Count <= 0)
                {
                    Response.Redirect("Logout.aspx");
                }
                else
                {
                    oEmpMaster.EmpID = Request.QueryString["EMP_ID"].ToString();
                    hdnEmpID.Value = Request.QueryString["EMP_ID"].ToString();
                    lblMode.Text = "EDIT";
                    oEmpMaster.GetEmployee();
                    txtAdd1.Text = oEmpMaster.Add1;
                    txtAdd2.Text = oEmpMaster.Add2;
                    txtAdd3.Text = oEmpMaster.Add3;
                    txtCity.Text = oEmpMaster.City;
                    if (oEmpMaster.DoB == null)
                    {
                        txtDoB.Text = "";
                    }
                    else
                        //txtDoB.Text = Convert.ToDateTime(oEmpMaster.DoB).ToString("dd/MM/yyyy");
                        txtDoB.Text = oEmpMaster.DoB;
                    if (oEmpMaster.DoJ == null)
                    {
                        txtDoJ.Text = "";
                    }
                    else
                        // txtDoJ.Text = Convert.ToDateTime(oEmpMaster.DoJ).ToString("dd/MM/yyyy"); ;
                        txtDoJ.Text = oEmpMaster.DoJ;
                    if (oEmpMaster.DoL == null)
                    {
                        txtDOL.Text = "";
                    }
                    else
                        //txtDOL.Text = Convert.ToDateTime(oEmpMaster.DoL).ToString("dd/MM/yyyy");
                        txtDOL.Text = oEmpMaster.DoL;
                    txtEmpCode.Text = oEmpMaster.EmpCode;
                    txtFName.Text = oEmpMaster.FName;
                    txtLName.Text = oEmpMaster.LName;
                    txtLogin.Text = oEmpMaster.LoginName;
                    txtMName.Text = oEmpMaster.MName;
                    txtMobile.Text = oEmpMaster.Mobile;
                    txtPhone.Text = oEmpMaster.Phone;
                    txtPin.Text = oEmpMaster.Pin;
                    rblGender.SelectedValue = oEmpMaster.Gender;
                    ddlDept.SelectedValue = oEmpMaster.Department;
                    ddlDsgn.SelectedValue = oEmpMaster.Designation;
                    ddlEmpType.SelectedValue = oEmpMaster.EmpType;
                    if (oEmpMaster.SubCentreID == null)
                    {
                        ddlSubCentre.SelectedIndex = 0;
                    }
                    else
                    {
                        ddlSubCentre.SelectedValue = oEmpMaster.SubCentreID;
                    }

                    txtUnit.Text = oEmpMaster.Unit;
                    txtSuvidhaAC.Text = oEmpMaster.SuvidhaAC;
                    if (oEmpMaster.Resignation == "Y")
                    {
                        chkResignation.Checked = true;
                    }
                    if (oEmpMaster.LeftOrganisation == "Y")
                    {
                        chkLeftOrganisation.Checked = true;
                    }
                }
            }

            else
            {
                if (Session.Count <= 0)
                {
                    Response.Redirect("Logout.aspx");
                }
                else
                {
                    lblMode.Text = "ADD";
                    hdnEmpID.Value = "";
                }
            }
        }
    }

    protected void btnCheck_Click(object sender, EventArgs e)
    {
        Boolean chkFound = true;
        oEmpMaster.LoginName = txtLogin.Text.ToString().Trim();
        chkFound = oEmpMaster.chkLoginName();
        if (chkFound)
            lblLoginMsg.Text = "Login name is not available. Please try other.";
        else
            lblLoginMsg.Text = "Login name is available.";
    }
    protected void btnConfirm_Click(object sender, EventArgs e)
    {
        try
        {
            Boolean chkLoginName = true;
            Boolean chkEmpCode = true;
            oEmpMaster.EmpCode = txtEmpCode.Text.ToString().Trim();
            oEmpMaster.LoginName = txtLogin.Text.ToString().Trim();
            oEmpMaster.EmpID = hdnEmpID.Value.ToString();
            chkEmpCode = oEmpMaster.chkEmpCode();
            if (chkEmpCode)
            {
                lblMsg.Text = "Emp Code already exist.";
            }
            else
            {
                chkLoginName = oEmpMaster.chkLoginName();
                if (chkLoginName)
                {
                    lblMsg.Text = "Login name is not available. Please try other.";
                }
                else
                {

                    oEmpMaster.FName = txtFName.Text.ToString().Trim();
                    oEmpMaster.MName = txtMName.Text.ToString().Trim();
                    oEmpMaster.LName = txtLName.Text.ToString().Trim();
                    oEmpMaster.Gender = rblGender.SelectedValue.ToString();
                    oEmpMaster.Add1 = txtAdd1.Text.ToString().Trim();
                    oEmpMaster.Add2 = txtAdd2.Text.ToString().Trim();
                    oEmpMaster.Add3 = txtAdd3.Text.ToString().Trim();
                    oEmpMaster.CentreID = Session["CentreId"].ToString().Trim();
                    oEmpMaster.City = txtCity.Text.ToString().Trim();
                    oEmpMaster.Pin = txtPin.Text.ToString().Trim();
                    oEmpMaster.Phone = txtPhone.Text.ToString().Trim();
                    oEmpMaster.Mobile = txtMobile.Text.ToString().Trim();
                    oEmpMaster.LoginName = txtLogin.Text.ToString().Trim();
                    oEmpMaster.CompanyID = "1";
                    oEmpMaster.Department = ddlDept.SelectedValue.ToString();
                    oEmpMaster.Designation = ddlDsgn.SelectedValue.ToString();
                    oEmpMaster.DoB = txtDoB.Text.ToString().Trim();
                    oEmpMaster.DoL = txtDOL.Text.ToString().Trim();
                    oEmpMaster.DoJ = txtDoJ.Text.ToString().Trim();
                    oEmpMaster.EmpCode = txtEmpCode.Text.ToString().Trim();
                    oEmpMaster.EmpType = ddlEmpType.SelectedValue.ToString();
                    

                    if (ddlSubCentre.SelectedIndex == 0)
                    {
                        oEmpMaster.SubCentreID = null;
                    }
                    else
                    {
                        oEmpMaster.SubCentreID = ddlSubCentre.SelectedValue;
                    }
                    oEmpMaster.Unit = txtUnit.Text;
                    oEmpMaster.SuvidhaAC = txtSuvidhaAC.Text;
                    if (chkResignation.Checked == true)
                    {
                        oEmpMaster.Resignation = "Y";
                    }
                    else
                    {
                        oEmpMaster.Resignation = "N";
                    }

                    if (chkLeftOrganisation.Checked == true)
                    {
                        oEmpMaster.LeftOrganisation = "Y";
                    }
                    else
                    {
                        oEmpMaster.LeftOrganisation = "N";
                    }

                    //Below Line Added By Avinash Wankhede [PAMAC Finserve Pvt Ltd.] Dated 02 May 2009
                    //By Default Password Set as User Login Name
                    oEmpMaster.Password = Generate_AutoPassword();

                    //End Here --Avinash Wankhede [PAMAC Finserve Pvt Ltd.] Dated 02 May 2009


                    if (lblMode.Text == "ADD")
                    {
                        oEmpMaster.AddedBy = Session["UserId"].ToString().Trim();
                        oEmpMaster.InsertEmployee();
                        lblMsg.Text = "Employee details added successfully.";
                    }
                    else
                    {
                        oEmpMaster.ModifyBy = Session["UserId"].ToString().Trim();
                        oEmpMaster.UpdateEmployee();
                        lblMsg.Text = "Employee details updated successfully.";
                    }
                    Reset();
                }

            }

        }
        catch (Exception exp)
        {
            lblMsg.Text = "Error : " + exp.Message;
        }
    }
    public void Reset()
    {
        txtAdd1.Text = "";
        txtAdd2.Text = "";
        txtAdd3.Text = "";
        txtCity.Text = "";
        txtDoB.Text = "";
        txtDoJ.Text = "";
        txtEmpCode.Text = "";
        txtFName.Text = "";
        txtLName.Text = "";
        txtLogin.Text = "";
        txtMName.Text = "";
        txtMobile.Text = "";
        txtPhone.Text = "";
        txtPin.Text = "";
        ddlDept.SelectedIndex = 0;
        ddlDsgn.SelectedIndex = 0;
        ddlEmpType.SelectedIndex = 0;
        rblGender.SelectedValue = "M";
        lblMode.Text = "ADD";
        hdnEmpID.Value = "";
        txtUnit.Text = "";
        txtSuvidhaAC.Text = "";
        ddlSubCentre.SelectedIndex = 0;
        txtDOL.Text = "";
        chkLeftOrganisation.Checked = false;
        chkResignation.Checked = false;
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("EmployeeMaster.aspx?OperationId=" + Request.QueryString["OperationId"]);
    }
    protected void ddlDsgn_DataBound(object sender, EventArgs e)
    {
        ddlDsgn.Items.Insert(0, new ListItem("--Select--", ""));
    }
    protected void ddlDept_DataBound(object sender, EventArgs e)
    {
        ddlDept.Items.Insert(0, new ListItem("--Select--", ""));
    }
    protected void ddlSubCentre_DataBound(object sender, EventArgs e)
    {
        ddlSubCentre.Items.Insert(0, new ListItem("--Select--", "0"));
    }

    public string Generate_AutoPassword()
    {
        try
        {
            int i;
            int CharLength = Convert.ToInt16(ConfigurationSettings.AppSettings["CharLength"]);
            int SpecialCharLength = Convert.ToInt16(ConfigurationSettings.AppSettings["SpecialCharLength"]); ;
            int NumericLength = Convert.ToInt16(ConfigurationSettings.AppSettings["NumLength"]); ;

            string strPassword = "";
            Random Rn = new Random();

            for (i = 0; i < CharLength; i++)
            {
                if (i == 0)
                {
                    strPassword = strPassword + Convert.ToChar(Rn.Next(65, 90));
                }
                else
                {
                    strPassword = strPassword + Convert.ToChar(Rn.Next(97, 122));
                }
            }

            for (i = 0; i < SpecialCharLength; i++)
            {
                strPassword = strPassword + Convert.ToChar(Rn.Next(64, 64));
            }

            for (i = 0; i < NumericLength; i++)
            {
                strPassword = strPassword + Convert.ToChar(Rn.Next(48, 57));
            }

            lblChangePassword.Text = "New Password Generated: " + strPassword;
            return strPassword;

        }
        catch (Exception ex)
        {
            string st = ex.Message;
            return "";
        }

    }
}
