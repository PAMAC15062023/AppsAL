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

public partial class IDOC_IDOC_IDOC_FEAssignment : System.Web.UI.Page
{
    string str = "first";
    CCommon con = new CCommon();
    protected void Page_Load(object sender, EventArgs e)
    {
        txtCaseID.Focus();
        if (Session["isAdd"].ToString() != "1")
          Response.Redirect("NoAccess.aspx");
       
        if (!IsPostBack)
        {
            try
            {
                ddlType.DataBind();
                FillView();
            }
            catch (Exception exp)
            {
                
                lblMsg.Text = "Error occured operation faild";
            }
        }
        lblMsg.Text = "";
    }
    protected void ddlType_DataBound(object sender, EventArgs e)
    {
        //ddlType.Items.Insert(0, "All");   
    }
    protected void ddlSearchFE_DataBound(object sender, EventArgs e)
    {
        ddlSearchFE.Items.Insert(0, new ListItem("--Select--", ""));
    }
    protected void ddlFromPin_DataBound(object sender, EventArgs e)
    {
        ddlFromPin.Items.Insert(0, new ListItem("--Select--", ""));
    }
    protected void ddlToPin_DataBound(object sender, EventArgs e)
    {
        ddlToPin.Items.Insert(0, new ListItem("--Select--", ""));
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        try
        {
            FillView();
        }
        catch (Exception exp)
        {
           
            lblMsg.Text = "Error occured operation faild";
        }
    }
    protected void btnSearchFE_Click(object sender, EventArgs e)
    {
        try
        {
            FillFE();
        }
        catch (Exception exp)
        {
           
            lblMsg.Text = "Error occured operation faild";
        }
        SellectAl(gvFEAssignmentCases);
    }
    protected void btnAssign_Click(object sender, EventArgs e)
    {
        try
        {
            HiddenField hdnCaseID;
            CheckBox chkCaseID;
            String strSelectedCaseID = "";
            foreach (GridViewRow row in gvFEAssignmentCases.Rows)
            {
                hdnCaseID = (HiddenField)row.FindControl("hidCaseId");
                chkCaseID = (CheckBox)row.FindControl("chkCaseId");
                if (chkCaseID.Checked)
                    strSelectedCaseID += hdnCaseID.Value + ",";
            }
            if (strSelectedCaseID != "")
            {
                CIdoc_FEAssignment oFE = new CIdoc_FEAssignment();
                oFE.arrCaseID = (strSelectedCaseID.TrimEnd(',')).Split(',');
                oFE.AssignedTo = ddlFE.SelectedValue.ToString();
                oFE.VerificationType = hdnVerificatioTypeID.Value.ToString();//ddlType.SelectedValue.ToString();
                oFE.InsertFeCaseMapping(strSelectedCaseID.TrimEnd(','));
               
                lblMsg.Text = "FE assigned successfully";
            }
            else
                
                lblMsg.Text = "Please select case to assign";
            ddlType.SelectedValue = hdnVerificatioTypeID.Value.ToString();

            FillView();
            if (strSelectedCaseID != "")
            {
                lblMsg.Text = "FE assigned successfully";
            }
            else
            {
                lblMsg.Text = "Please select case to assign";
            }
            ddlFromPin.SelectedIndex = 0;
            ddlToPin.SelectedIndex = 0;
            FillFE();
        }
        catch (Exception exp)
        {
            
            lblMsg.Text = "Error occured, FE assignment faild";
        }
    }
    protected void ddlFE_DataBound(object sender, EventArgs e)
    {
        ddlFE.Items.Insert(0, new ListItem("--Select--", ""));
    }
    protected void gvFEAssignmentCases_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        FillView();
    }
    protected void gvFEAssignmentCases_Sorting(object sender, GridViewSortEventArgs e)
    {
        FillView();
    }
    public void FillView()
    {
        String strCentreID = "";
        String strClientID = "";
        String strSql = "";
        strCentreID = Session["CentreId"].ToString();
        strClientID = Session["ClientId"].ToString();


        if (strClientID != "" && strCentreID != "")
        {
            String strCreteria = "";
            if (txtDate.Text != "")
            {
                strCreteria += " AND (CONVERT(VARCHAR, CD.CASE_REC_DATETIME,103)='" + Convert.ToDateTime(con.strDate(txtDate.Text.Trim())).ToString("dd/MM/yyyy") + "')";
            }
            if (txtCustName.Text != "")
            {
                if (chkAbsolute.Checked)
                    strCreteria += " AND (ISNULL(CD.FIRST_NAME + ' ', '') +ISNULL(CD.MIDDLE_NAME + ' ', '') + ISNULL(CD.LAST_NAME + ' ', '')='" + txtCustName.Text.Trim().ToString().Replace("'", "") + "')";
                else
                    strCreteria += " AND (ISNULL(CD.FIRST_NAME + ' ', '') +ISNULL(CD.MIDDLE_NAME + ' ', '') + ISNULL(CD.LAST_NAME + ' ', '') Like'%" + txtCustName.Text.Trim().ToString().Replace("'", "") + "%')";
            }
            if (ddlType.SelectedValue.Trim() != "All")
            {
                strCreteria += " AND (CV.VERIFICATION_TYPE_ID = '" + ddlType.SelectedValue.ToString() + "')";
            }
            if (ddlSearchFE.SelectedValue != "")
            {
                strCreteria += " AND FE.FE_ID='" + ddlSearchFE.SelectedValue.ToString() + "'";
            }
            else
            {
                strCreteria += " AND FE.FE_ID IS NULL";
            }
            if (txtCaseID.Text != "")
            {
                strCreteria += " and cd.case_id='" + txtCaseID.Text.Trim() + "' ";
            }
           
            String strSelADD = "";
            if (ddlType.SelectedItem.ToString() == "Salary Certificate" || ddlType.SelectedItem.ToString()=="Salary Slip")
            {
                strSelADD = "(ISNULL(CD.OFF_ADD_LINE_1+' ','') + ISNULL(CD.OFF_ADD_LINE_2+' ','') + ISNULL(CD.OFF_ADD_LINE_3+' ','')) AS [Office Address], CD.OFF_CITY AS [City], CD.OFF_PIN_CODE AS [Pincode], ";
            }
            if (ddlType.SelectedItem.ToString() == "IT Return")
            {
                strSelADD = "(ISNULL(CD.RES_ADD_LINE_1+' ','') + ISNULL(CD.RES_ADD_LINE_2+' ','') + ISNULL(CD.RES_ADD_LINE_3+' ','')) AS [Resident Address], CD.RES_CITY AS [City], CD.RES_PIN_CODE AS [Pincode], ";
                
            }
            if (ddlType.SelectedItem.ToString() == "Bank Statment")
            {
                strSelADD = "(ISNULL(CD.BANK_NAME+' ','') + ISNULL(CD.BANK_ADDRESS+' ',''))  AS [Bank Address], CD.BANK_CITY AS [City], CD.BANK_PIN AS [Pincode], ";
            }
            if (ddlType.SelectedItem.ToString() == "FORM 16")

            {
                strSelADD = "(ISNULL(CD.OFF_ADD_LINE_1+' ','') + ISNULL(CD.OFF_ADD_LINE_2+' ','') + ISNULL(CD.OFF_ADD_LINE_3+' ','')) AS [Office Address], CD.OFF_CITY AS [City], CD.OFF_PIN_CODE AS [Pincode], ";
            }
            if (ddlType.SelectedItem.ToString() == "RC")
            {
                strSelADD = "(ISNULL(CD.RTO_Office+' ',''))  AS [RTO Address], CD.RES_CITY AS [City], CD.RES_PIN_CODE AS [Pincode], ";
            }
            hdnVerificatioTypeID.Value = ddlType.SelectedValue.ToString();
            strSql = "SELECT CD.CASE_ID AS [Case ID], CD.REF_NO AS [Refrence No], ISNULL(CD.TITLE + ' ', '') + ISNULL(CD.FIRST_NAME + ' ', '') +ISNULL(CD.MIDDLE_NAME + ' ', '') + ISNULL(CD.LAST_NAME + ' ', '') AS [Applicant Name], " + strSelADD +
                            "CONVERT(VARCHAR, CD.CASE_REC_DATETIME, 103) AS [Recieved Date], FV.FULLNAME AS [Assigned To] " +
                            "FROM CPV_IDOC_CASE_DETAILS CD LEFT OUTER JOIN " +
                            "CPV_IDOC_VERIFICATION_TYPE CV LEFT OUTER JOIN " +
                            "FE_VW FV INNER JOIN CPV_IDOC_FE_CASE_MAPPING FE ON FV.EMP_ID = FE.FE_ID ON CV.CASE_ID = FE.CASE_ID AND " +
                            "CV.VERIFICATION_TYPE_ID = FE.VERIFICATION_TYPE_ID ON CD.CASE_ID = CV.CASE_ID " +
                //"LEFT OUTER JOIN CPV_CC_VERI_DETAILS VD ON CD.CASE_ID = VD.CASE_ID " +
                            "WHERE(CD.SEND_DATETIME IS NULL) AND CD.CLIENT_ID='" + strClientID + "'  AND CD.CENTRE_ID='" + strCentreID + "'" + strCreteria;
        }
        sdsGV.SelectCommand = strSql;
        gvFEAssignmentCases.DataBind();
        if (str == "")
        {
            if (gvFEAssignmentCases.Rows.Count <= 0)
            {

                lblMsg.Text = "Record not found.";
            }
        }
       
    }
    public void FillFE()
    {
        String strQuery = "SELECT DISTINCT FULLNAME, FE_ID FROM FE_VW INNER JOIN FE_PINCODE_MAPPING ON EMP_ID=FE_ID WHERE 1=1 AND Centre_id=" + Session["CentreID"].ToString() + " ";
        if (ddlFromPin.SelectedValue != "" && ddlToPin.SelectedValue != "")
        {
            strQuery += " AND PINCODE BETWEEN '" + ddlFromPin.SelectedValue.ToString() + "' AND '" + ddlToPin.SelectedValue.ToString() + "'";
        }
        else
        {
            if (ddlFromPin.SelectedValue != "")
            {
                strQuery += " AND PINCODE = '" + ddlFromPin.SelectedValue.ToString() + "'";
            }
            if (ddlToPin.SelectedValue != "")
            {
                strQuery += " AND PINCODE = '" + ddlToPin.SelectedValue.ToString() + "' order by FULLNAME";
            }
        }
        sdsFE.SelectCommand = strQuery;
        ddlFE.DataBind();
    }
    protected void gvFEAssignmentCases_DataBound(object sender, EventArgs e)
    {
        if (gvFEAssignmentCases.Rows.Count <= 0)
        {
            lblMsg.Text = "Record not found.";
        }
        // Each time the data is bound to the grid we need to build up the CheckBoxIDs array
        // Get the header CheckBox
        else
        {
            SellectAl(gvFEAssignmentCases);
            //CheckBox cbHeader = ((CheckBox)(gvFEAssignmentCases.HeaderRow.FindControl("chkHeader")));
            //cbHeader.Attributes["onclick"] = "ChangeAllCheckBoxStates(this.checked);";
            //foreach (GridViewRow gvr in gvFEAssignmentCases.Rows)
            //{
            //    // Get a programmatic reference to the CheckBox control
            //    CheckBox cb = ((CheckBox)(gvr.FindControl("chkCaseId")));
            //    ClientScript.RegisterArrayDeclaration("CheckBoxIDs", string.Concat("\'", cb.ClientID, "\'"));
            //}
        }
    }
    public void SellectAl(GridView gv)
    {
        CheckBox cbHeader = ((CheckBox)(gvFEAssignmentCases.HeaderRow.FindControl("chkHeader")));
        cbHeader.Attributes["onclick"] = "ChangeAllCheckBoxStates(this.checked);";
        foreach (GridViewRow gvr in gv.Rows)
        {
            // Get a programmatic reference to the CheckBox control
            CheckBox cb = ((CheckBox)(gvr.FindControl("chkCaseId")));
            ClientScript.RegisterArrayDeclaration("CheckBoxIDs", string.Concat("\'", cb.ClientID, "\'"));
        }
    }
}
