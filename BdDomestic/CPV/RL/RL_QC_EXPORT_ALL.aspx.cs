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
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using Excel;
using Microsoft.Office.Core;
using System.Text;
using System.IO;

public partial class CPV_RL_RL_QC_EXPORT_ALL : System.Web.UI.Page
{
    CCommon objCmn = new CCommon();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["isView"].ToString() != "1")
        Response.Redirect("NoAccess.aspx");
        txtFromDate.Focus();
        lblMsg.Text = "";
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        try
        {
            String strCentreID = Session["CentreId"].ToString(); //"1011";
            String strClientID = Session["ClientId"].ToString(); //"1013";
            //String strDateCriteria = "";
            string ToDate = "";
            string FromDate = "";

            if (rdoFromToDate.Checked == true)
            {
                if (txtToDate.Text.Trim() != "")
                    ToDate = Convert.ToDateTime(objCmn.strDate(txtToDate.Text.Trim())).AddDays(1.0).ToString("dd-MMM-yyyy");

                if (txtFromDate.Text.Trim() != "")
                    FromDate = objCmn.strDate(txtFromDate.Text.Trim());
            }
            else if (rdoDateTime.Checked == true)
            {
                FromDate = objCmn.strDate(txtDate.Text.Trim()) + ' ' + txtTime.Text.Trim() + ' ' + ddlTimeType.SelectedItem.Text.Trim();
                ToDate = Convert.ToDateTime(objCmn.strDate(txtDate.Text.Trim()) + ' ' + txtTime.Text.Trim() + ' ' + ddlTimeType.SelectedItem.Text.Trim()).AddMinutes(1.0).ToString("dd-MMM-yyyy hh:mm tt");
            }
            hdFromDate.Value = FromDate;
            hdToDate.Value = ToDate;
            //----------------------------------------------------------------------------

            if (strCentreID != "" && strClientID != "")
            {


                //string sSql = "SELECT Count(*) as TotalCount FROM [CPV_RL_CASE_DETAILS] " +
                //              "WHERE (([SEND_DATETIME] IS NOT NULL) AND ([CENTRE_ID] = '" + strCentreID + "') AND ([CLIENT_ID] = '" + strClientID + "')and (SEND_DATETIME >='" + FromDate + "' and SEND_DATETIME<'" + ToDate + "' ))";
                string sSql = "SELECT Count(*) as TotalCount FROM [CPV_QC_CASE_DETAILS] " +
                              "WHERE (([case_SEND_DATE] IS NOT NULL) AND ([CENTRE_ID] = '" + strCentreID + "') AND ([CLIENT_ID] = '" + strClientID + "')and (case_SEND_DATE >='" + FromDate + "' and case_SEND_DATE<'" + ToDate + "' ))";

                OleDbDataReader oledbRead;
                oledbRead = OleDbHelper.ExecuteReader(objCmn.ConnectionString, CommandType.Text, sSql);
                if (oledbRead.Read() == true)
                    lblCaseCount.Text = "Number of cases : " + oledbRead["TotalCount"].ToString();
                oledbRead.Close();

                gvOutput.DataBind();


                if (gvOutput.Rows.Count > 0)
                {
                    tblCaseCount.Visible = true;
                    lblMsg.Visible = false;
                }
                else
                {
                    tblCaseCount.Visible = false;
                    lblCaseCount.Text = "";
                    lblMsg.Visible = true;
                    lblMsg.Text = "Record not found.";
                }
            }
        }
        catch (Exception ex)
        {
            lblMsg.Visible = true;
            lblMsg.Text = "Error while retreiving data: " + ex.Message;
        }
    }
    protected void btnExport1_Click(object sender, EventArgs e)
    {
        try
        {
            //getting selected rows caseid
            HiddenField hdnCaseID;
            System.Web.UI.WebControls.CheckBox chkCaseID;
            String strSelectedCaseID = "";
            foreach (GridViewRow row in gvOutput.Rows)
            {
                hdnCaseID = (HiddenField)row.FindControl("hidCaseId");
                chkCaseID = (System.Web.UI.WebControls.CheckBox)row.FindControl("chkCaseId");
                if (chkCaseID.Checked)
                {
                    strSelectedCaseID += hdnCaseID.Value + ",";
                }
            }

            if (strSelectedCaseID != "")
            {
                String[] arrCaseID = (strSelectedCaseID.TrimEnd(',')).Split(',');
                //passed caseid's in array to generate excel 
                GetExport(ddlSelectFormat1.SelectedValue.ToString(), arrCaseID);
            }
            else
            {
                lblMsg.Visible = true;
                lblMsg.Text = "Please select case to Export.";
                hplDownload.Visible = false;
                hplDownload.NavigateUrl = "";
                gvOutput.DataBind();
            }
        }
        catch (Exception exp)
        {
            lblMsg.Visible = true;
            lblMsg.Text = exp.Message;
            hplDownload.Visible = false;
            hplDownload.NavigateUrl = "";
        }
    }

    public void GetExport(string strFormat, String[] arrCaseID)
    {
        if (ddlSelectFormat.SelectedValue.ToString() == "6" || ddlSelectFormat1.SelectedValue.ToString() == "6")
            GenerateReliFormat(arrCaseID);
        else if (ddlSelectFormat.SelectedValue.ToString() == "7" || ddlSelectFormat1.SelectedValue.ToString() == "7")
            GenerateUbiFormat(arrCaseID);
        //else if (ddlSelectFormat.SelectedValue.ToString() == "9" || ddlSelectFormat1.SelectedValue.ToString() == "9")
        //    GenerateScbHLFormat(arrCaseID);
        else if (ddlSelectFormat.SelectedValue.ToString() == "0" && ddlSelectFormat1.SelectedValue.ToString() == "0")
        {
            lblMsg.Visible = true;
            lblMsg.Text = "Please select format.";
            hplDownload.Visible = false;
            hplDownload.NavigateUrl = "";
        }
        gvOutput.DataBind();
    }

    public void GenerateReliFormat(string[] arrCaseId)
    {
        int iCount = 0;
        try
        {
            if (arrCaseId.Length > 0)
            {
                DataSet dsStdOutput = new DataSet();
                CReport objReport = new CReport();
                System.Data.DataTable dtCaseId = new System.Data.DataTable();
                System.Data.DataTable dtOfficeVerify = new System.Data.DataTable();
                System.Data.DataTable dtResiVerify = new System.Data.DataTable();

                string strMapPath = Server.MapPath("../../ExportToUTI/RL/") + Session["UserName"].ToString() + "/";
                string strDateTime = DateTime.Now.ToString("ddMMyyyyhhmmss");

                if (!Directory.Exists(strMapPath + strDateTime))
                    Directory.CreateDirectory(strMapPath + strDateTime);

                for (int i = 0; i < arrCaseId.Length; i++)
                {
                    dsStdOutput.Tables.Clear();
                    dsStdOutput.Clear();
                    string sRefNo = "";
                    OleDbDataReader oledbRead;
                    oledbRead = objReport.GetRefNoByCaseIdRL_Qc(arrCaseId[i].ToString());
                    if (oledbRead.Read())
                        sRefNo = oledbRead["Case_id"].ToString();

                    oledbRead.Close();
                    dtCaseId = objReport.GetCaseIdforReportRL1(arrCaseId[i].ToString());
                    dtOfficeVerify = objReport.GetBusiVeriDtlRL_Qc(arrCaseId[i].ToString());
                    dtResiVerify = objReport.GetResiVeriDtlRL_Qc(arrCaseId[i].ToString());

                    dsStdOutput.Tables.Add(dtCaseId);
                    dsStdOutput.Tables[0].TableName = "Main";

                    dsStdOutput.Tables.Add(dtOfficeVerify);
                    dsStdOutput.Tables[1].TableName = "RL_Reli_BV";

                    dsStdOutput.Tables.Add(dtResiVerify);
                    dsStdOutput.Tables[2].TableName = "RL_Reli_RV";

                    CrystalReportDocument myReportDocument;
                    myReportDocument = new CrystalReportDocument();
                    myReportDocument.Load(Server.MapPath("RL_Reli_Export.rpt"));
                    myReportDocument.SetDataSource(dsStdOutput);

                    Session["Path"] = Server.MapPath("RL_Reli_Export.rpt");
                    myReportDocument.ExportToDisk(ExportFormatType.PortableDocFormat, strMapPath + strDateTime + "/" + sRefNo + ".pdf");
                    //myReportDocument.ExportToDisk(ExportFormatType.PortableDocFormat,"D:\\Santosh\\Source\\PMS_CPV\\Application\\ExportToUTI" + "//KYC//" + strDateTime + "/" + sRefNo + ".pdf");

                    myReportDocument.Dispose();
                    GC.Collect();
                }

                lblMsg.Visible = true;
                lblMsg.Text = "Export Completed successfully.";
                hplDownload.Visible = true;
                //hplDownload.NavigateUrl = "D:\\Santosh\\Source\\PMS_CPV\\Application\\ExportToUTI" + "//KYC//" + Session["UserName"].ToString() + "//" + strDateTime + "//";
                hplDownload.NavigateUrl = ConfigurationManager.AppSettings["FtpPath"] + "//RL//" + Session["UserName"].ToString() + "//" + strDateTime + "//";
                dtCaseId.Clear();
                dtOfficeVerify.Clear();
                dtResiVerify.Clear();

                dtCaseId.Dispose();
                dtOfficeVerify.Dispose();
                dtResiVerify.Dispose();

                dsStdOutput.Clear();
                dsStdOutput.Dispose();
            }
        }
        catch (Exception exp)
        {
            lblMsg.Visible = true;
            lblMsg.Text = exp.Message;
            hplDownload.Visible = false;
            hplDownload.NavigateUrl = "";
        }
    }

    public void GenerateUbiFormat(string[] arrCaseId)
    {
        int iCount = 0;
        try
        {
            if (arrCaseId.Length > 0)
            {
                DataSet dsStdOutput = new DataSet();
                CReport objReport = new CReport();
                System.Data.DataTable dtCaseId = new System.Data.DataTable();
                System.Data.DataTable dtOfficeVerify = new System.Data.DataTable();
                System.Data.DataTable dtResiVerify = new System.Data.DataTable();
                System.Data.DataTable dtResiTele = new System.Data.DataTable();

                string strMapPath = Server.MapPath("../../ExportToUTI/RL/") + Session["UserName"].ToString() + "/";
                string strDateTime = DateTime.Now.ToString("ddMMyyyyhhmmss");

                if (!Directory.Exists(strMapPath + strDateTime))
                    Directory.CreateDirectory(strMapPath + strDateTime);

                for (int i = 0; i < arrCaseId.Length; i++)
                {
                    dsStdOutput.Tables.Clear();
                    dsStdOutput.Clear();
                    string sRefNo = "";
                    OleDbDataReader oledbRead;
                    oledbRead = objReport.GetRefNoByCaseIdRL_Qc(arrCaseId[i].ToString());
                    if (oledbRead.Read())
                        sRefNo = oledbRead["Case_id"].ToString();

                    oledbRead.Close();
                    dtCaseId = objReport.GetCaseIdforReportRL1(arrCaseId[i].ToString());
                    dtOfficeVerify = objReport.GetBusiVeriDtlRLubi_Qc(arrCaseId[i].ToString());
                    dtResiVerify = objReport.GetResiVeriDtlRLubi_Qc(arrCaseId[i].ToString());
                    dtResiTele = objReport.GetResiTeleDtlRLubi(arrCaseId[i].ToString());

                    dsStdOutput.Tables.Add(dtCaseId);
                    dsStdOutput.Tables[0].TableName = "Main";

                    dsStdOutput.Tables.Add(dtOfficeVerify);
                    dsStdOutput.Tables[1].TableName = "RL_Ubi_BV";

                    dsStdOutput.Tables.Add(dtResiVerify);
                    dsStdOutput.Tables[2].TableName = "RL_Ubi_RV";

                    dsStdOutput.Tables.Add(dtResiTele);
                    dsStdOutput.Tables[3].TableName = "RL_Ubi_RT";

                    CrystalReportDocument myReportDocument;
                    myReportDocument = new CrystalReportDocument();
                    myReportDocument.Load(Server.MapPath("RL_Ubi_Export.rpt"));
                    myReportDocument.SetDataSource(dsStdOutput);

                    Session["Path"] = Server.MapPath("RL_Ubi_Export.rpt");
                    myReportDocument.ExportToDisk(ExportFormatType.PortableDocFormat, strMapPath + strDateTime + "/" + sRefNo + ".pdf");
                    //myReportDocument.ExportToDisk(ExportFormatType.PortableDocFormat,"D:\\Santosh\\Source\\PMS_CPV\\Application\\ExportToUTI" + "//KYC//" + strDateTime + "/" + sRefNo + ".pdf");

                    myReportDocument.Dispose();
                    GC.Collect();
                }

                lblMsg.Visible = true;
                lblMsg.Text = "Export Completed successfully.";
                hplDownload.Visible = true;
                //hplDownload.NavigateUrl = "D:\\Santosh\\Source\\PMS_CPV\\Application\\ExportToUTI" + "//KYC//" + Session["UserName"].ToString() + "//" + strDateTime + "//";
                hplDownload.NavigateUrl = ConfigurationManager.AppSettings["FtpPath"] + "//RL//" + Session["UserName"].ToString() + "//" + strDateTime + "//";
                dtCaseId.Clear();
                dtOfficeVerify.Clear();
                dtResiVerify.Clear();
                dtResiTele.Clear();

                dtCaseId.Dispose();
                dtOfficeVerify.Dispose();
                dtResiVerify.Dispose();
                dtResiTele.Dispose();

                dsStdOutput.Clear();
                dsStdOutput.Dispose();
            }
        }
        catch (Exception exp)
        {
            lblMsg.Visible = true;
            lblMsg.Text = exp.Message;
            hplDownload.Visible = false;
            hplDownload.NavigateUrl = "";
        }
    }

    protected void btnExport_Click1(object sender, EventArgs e)
    {

        try
        {
            //getting selected rows caseid
            HiddenField hdnCaseID;
            System.Web.UI.WebControls.CheckBox chkCaseID;
            String strSelectedCaseID = "";
            foreach (GridViewRow row in gvOutput.Rows)
            {
                hdnCaseID = (HiddenField)row.FindControl("hidCaseId");
                chkCaseID = (System.Web.UI.WebControls.CheckBox)row.FindControl("chkCaseId");
                if (chkCaseID.Checked)
                {
                    strSelectedCaseID += hdnCaseID.Value + ",";
                }
            }

            if (strSelectedCaseID != "")
            {
                String[] arrCaseID = (strSelectedCaseID.TrimEnd(',')).Split(',');
                //passed caseid's in array to generate excel 
                GetExport(ddlSelectFormat1.SelectedValue.ToString(), arrCaseID);
            }
            else
            {
                lblMsg.Visible = true;
                lblMsg.Text = "Please select case to Export.";
                hplDownload.Visible = false;
                hplDownload.NavigateUrl = "";
                gvOutput.DataBind();
            }
        }
        catch (Exception exp)
        {
            lblMsg.Visible = true;
            lblMsg.Text = exp.Message;
            hplDownload.Visible = false;
            hplDownload.NavigateUrl = "";
        }
    }
    protected void gvOutput_DataBound(object sender, EventArgs e)
    {
        // Each time the data is bound to the grid we need to build up the CheckBoxIDs array
        // Get the header CheckBox
        if (gvOutput.Rows.Count <= 0)
        {
            //lblMsg.Text = "No record found";
        }
        else
        {
            tblCaseCount.Visible = true;
            System.Web.UI.WebControls.CheckBox cbHeader = ((System.Web.UI.WebControls.CheckBox)(gvOutput.HeaderRow.FindControl("HeaderLevelCheckBox")));
            cbHeader.Attributes["onclick"] = "ChangeAllCheckBoxStates(this.checked);";
            foreach (GridViewRow gvr in gvOutput.Rows)
            {
                // Get a programmatic reference to the CheckBox control
                System.Web.UI.WebControls.CheckBox cb = ((System.Web.UI.WebControls.CheckBox)(gvr.FindControl("chkCaseId")));
                ClientScript.RegisterArrayDeclaration("CheckBoxIDs", string.Concat("\'", cb.ClientID, "\'"));
            }
        }
    }

    protected void gvOutput_PageIndexChanged(object sender, EventArgs e)
    {
        gvOutput.DataBind();
    }
    protected void gvOutput_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvOutput.DataBind();
    }
}
