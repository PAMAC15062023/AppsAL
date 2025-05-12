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

public partial class CPV_Cellular_CEL_FEAssignmentTracking : System.Web.UI.Page
{
    CCommon objComm;
    protected void Page_Load(object sender, EventArgs e)
    {
        objComm = new CCommon();
    }
    protected void ddlSearchFE_DataBound(object sender, EventArgs e)
    {
        ((DropDownList)sender).Items.Insert(0, new ListItem("--Select--", "0"));

    }
    protected void btnsearch_Click(object sender, EventArgs e)
    {
        DoDatabind();
        DisplayMessage();
    }
    protected void ddlType_DataBound(object sender, EventArgs e)
    {
        ddlType.SelectedIndex = 0;
    }
    protected void btnAssign_Click(object sender, EventArgs e)
    {

        CFEAssignment oFE = new CFEAssignment();
        oFE.AssignedTo = ddlSearchFE.SelectedValue.ToString();
        oFE.VerificationType = ddlType.SelectedValue.ToString();
        bool boCheck = true;
        if (txtCaseId.Text.Trim() != "")
        {
            oFE.arrCaseID = txtCaseId.Text.Trim().Split(',');
            boCheck = oFE.ChkFeAssignment_cell(txtCaseId.Text.Trim());
            if (boCheck)
            {
                oFE.InsertFeCaseMapping_Cel("'" + txtCaseId.Text.Trim() + "'");
                lblMsg.Text = "FE assigned successfully";
            }
            else
            {
                lblMsg.Text = "Case not found or FE is assigned for this case";
            }
        }
        else
        {
            if (txtRefNo.Text.Trim() != "")
            {
                oFE.arrCaseID = txtRefNo.Text.Trim().Split(',');
                boCheck = oFE.ChkFeAssignment(txtRefNo.Text.Trim(), "1");
                if (boCheck)
                {
                    oFE.InsertFeCaseMapping(txtRefNo.Text.Trim(), "1");
                    lblMsg.Text = "FE assigned successfully";
                }
                else
                {
                    lblMsg.Text = "Case not found or FE is assigned for this case";
                }
            }
            else
            {
                lblMsg.Text = "Case not found or FE is assigned for this case";
            }


        }
        DoDatabind();
    }

    private void DoDatabind()
    {
        sdsGV.SelectCommand = " SELECT  CD.CASE_ID, CD.REF_NO,VTM.VERIFICATION_TYPE_CODE,CPV_CELLULAR_CASE_TYPE_MASTER.CASE_TYPE,  " +
                              " ISNULL(CD.APP_FNAME + ' ', '')  +  ISNULL(CD.APP_MNAME + ' ', '')  " +
                              " + ISNULL(CD.APP_LNAME, '') AS ApplicantName  , " +

                              "  isnull(CD.APP_ADDR1 + ' ' , '')  + isnull(CD.APP_ADDR2 + ' ' , '')  + isnull(CD.APP_ADDR3 , '') As Address, " +

                              " Case When FPM.DATE_TIME is NULL Then 'Auto'   " +
                              " When FPM.DATE_TIME is NOT NULL Then 'Manual' END as IsAuto " +
                              " FROM CPV_CELLULAR_CASES CD INNER JOIN " +
                              " CPV_CELLULAR_FE_CASE_MAPPING FPM ON CD.CASE_ID = FPM.CASE_ID INNER JOIN " +

                              " VERIFICATION_TYPE_MASTER VTM ON  " +
                              " FPM.VERIFICATION_TYPE_ID = VTM.VERIFICATION_TYPE_ID INNER JOIN " +
                              " FE_VW ON FPM.FE_ID = FE_VW.EMP_ID " +
                              "INNER JOIN CPV_CELLULAR_CASE_TYPE_MASTER ON CD.CASE_TYPE_ID = CPV_CELLULAR_CASE_TYPE_MASTER.CASE_TYPE_ID " +
                              " WHERE (CD.CLIENT_ID = '" + Session["ClientId"].ToString() + "') AND (CD.CENTRE_ID = '" + Session["CentreId"].ToString() + "') AND (CD.SEND_DATETIME IS NULL)";
        string strFilter = " AND (FE_VW.EMP_ID = '" + ddlSearchFE.SelectedValue + "')";
        if (txtDate.Text != "")
        {
            strFilter += " AND (CASE_REC_DATETIME >= '" + objComm.strDate(txtDate.Text) + "') and (CASE_REC_DATETIME <= '" + Convert.ToDateTime(objComm.strDate(txtDate.Text)).AddDays(1.0).ToString("dd-MMM-yyyy") + "')";
        }
        sdsGV.SelectCommand += strFilter + " order by ApplicantName";
        gvFEAssignedList.DataBind();
        lblCount.Text = "Cases assigned:" + gvFEAssignedList.Rows.Count;
    }
    private void DisplayMessage()
    {
        if (gvFEAssignedList.Rows.Count == 0)
            lblMsg.Text = "No record found.";
        else
            lblMsg.Text = "";

    }
    protected void gvFEAssignedList_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Delete")
        {
            int index =Convert.ToInt32( e.CommandArgument);
            string strCaseId = (gvFEAssignedList.Rows[index].Cells[1]).Text;
            //string strCaseId = ((HiddenField)((GridView)sender).Rows[index].FindControl("hidCaseId")).Value;
            CFEAssignment oFE = new CFEAssignment();
            oFE.DoDelete_cell(strCaseId, ddlType.SelectedValue, ddlSearchFE.SelectedValue);
           
            lblMsg.Text = "Record deleted successfully.";
            
            DoDatabind();
        }
    }
   
}
