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

public partial class CPV_EBC_EBC_Standard_Output : System.Web.UI.Page
{
    CCommon objCmn = new CCommon();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["isView"].ToString() != "1")
            Response.Redirect("NoAccess.aspx");

        txtFromDate.Focus();
        lblMsg.Text = "";
    }
    //search to fill database between from to SEND_DATETIME
    protected void btnSearch_Click(object sender, EventArgs e)
    {

        try
        {
            String strCentreID = Session["CentreId"].ToString(); //"1011";
            String strClientID = Session["ClientId"].ToString(); //"1013";
            //String strDateCriteria = "";
            string ToDate = "";
            string FromDate = "";
            //By Ashish...
            if (txtToDate.Text.Trim() != "")
                ToDate = Convert.ToDateTime(objCmn.strDate(txtToDate.Text.Trim())).AddDays(1.0).ToString("dd-MMM-yyyy");

            if (txtFromDate.Text.Trim() != "")
                FromDate = objCmn.strDate(txtFromDate.Text.Trim());
            if (strCentreID != "" && strClientID != "")
            {
                hdFromDate.Value = FromDate;
                hdToDate.Value = ToDate;
                //sdsOutput.SelectCommand = "SELECT CD.[CASE_ID], ISNULL(CD.FIRST_NAME + ' ', '') +ISNULL(CD.MIDDLE_NAME + ' ', '') + ISNULL(CD.LAST_NAME + ' ', '') AS "+
                //                           "[APPLICANT_NAME],  Convert(varchar(24),CD.CASE_REC_DATETIME,103)+ ' ' + "+
                //                           "LTRIM(SUBSTRING(CONVERT( VARCHAR(20),CD.CASE_REC_DATETIME, 22), 10, 5)  + "+
                //                          " RIGHT(CONVERT(VARCHAR(20), CD.CASE_REC_DATETIME, 22), 3))as [CASE_REC_DATETIME],  Convert(varchar(24),CD.SEND_DATETIME,103)"+
                //                           "+ ' ' + LTRIM(SUBSTRING(CONVERT( VARCHAR(20),CD.SEND_DATETIME, 22), 10, 5) "+
                //                          " + RIGHT(CONVERT(VARCHAR(20), CD.SEND_DATETIME, 22), 3))as [SEND_DATETIME],VM.VERIFICATION_TYPE_CODE AS VERIFICATION_CODE" +
                //                          " FROM [CPV_EBC_CASE_DETAILS] CD INNER JOIN "+
                //                          " CPV_EBC_VERIFICATION CV ON CD.CASE_ID=CV.CASE_ID INNER JOIN VERIFICATION_TYPE_MASTER VM ON CV.VERIFICATION_TYPE_ID= VM.VERIFICATION_TYPE_ID"+
                //                          " WHERE ((CD.[SEND_DATETIME] IS NOT NULL) AND (CD.CASE_STATUS_ID IS NOT NULL)"+
                //                           "AND (CD.[CENTRE_ID] = '" + strCentreID + "') AND (CD.[CLIENT_ID] = '" + strClientID + "')AND " +
                //                           "(CD.SEND_DATETIME >='" + FromDate + "' and CD.SEND_DATETIME<'" + ToDate + "' ))";
                gvOutput.DataBind();
                if (gvOutput.Rows.Count > 0)
                {
                    lblCaseCount.Text = "Number of cases: " + gvOutput.Rows.Count;
                    pnlView.Visible = true;
                    lblMsg.Visible = false;
                }
                else
                {
                    lblCaseCount.Text = "";
                    lblMsg.Visible = true;
                    lblMsg.Text = "Record not found.";
                    lblMsg.ForeColor = System.Drawing.Color.Red;
                    pnlView.Visible = false;
                }

            }
        }
        catch (Exception ex)
        {
            lblMsg.Visible = true;
            lblMsg.Text = "Error : " + ex.Message;
            lblMsg.ForeColor = System.Drawing.Color.Red;
        }
        //try catch is added by supriya on 15th Nov2007 
    }
    protected void btnReport_Click(object sender, EventArgs e)
    {
        //try
        //{
        //    //getting selected rows caseid
        //    HiddenField hdnCaseID;
        //    System.Web.UI.WebControls.CheckBox chkCaseID;
        //    String strSelectedCaseID = "";
        //    foreach (GridViewRow row in gvOutput.Rows)
        //    {
        //        hdnCaseID = (HiddenField)row.FindControl("hidCaseId");
        //        chkCaseID = (System.Web.UI.WebControls.CheckBox)row.FindControl("chkCaseId");
        //        if (chkCaseID.Checked)
        //        {
        //            strSelectedCaseID += hdnCaseID.Value + ",";
        //        }
        //    }
        //    //strSelectedCaseID ="101112938";// "101114613";
        //    if (strSelectedCaseID != "")
        //    {
        //        String[] arrCaseID = (strSelectedCaseID.TrimEnd(',')).Split(',');
        //        //passed caseid's in array to generate excel
        //        GenerateExcel(arrCaseID);
        //        lblMsg.Text = "Export completed successfully";
        //        hplDownload.Visible = true;
        //        hplDownload.NavigateUrl = ConfigurationManager.AppSettings["FtpPath"] + "//EBC//" + Session["UserName"].ToString() + "//";
        //    }
        //    else
        //    {
        //        lblMsg.Text = "Please select case to assign";
        //        hplDownload.Visible = false;
        //        hplDownload.NavigateUrl = "";
        //    }
        //}
        //catch (Exception exp)
        //{
        //    lblMsg.Text = exp.Message;
        //    hplDownload.Visible = false;
        //    hplDownload.NavigateUrl = "";
        //}
    }


    //public void GenerateExcel(String[] arrCaseID)
    //{

    //    System.Data.DataTable dtCaseId = new System.Data.DataTable();
    //    System.Data.DataTable GetGAP_Verificationdt = new System.Data.DataTable();
    //    System.Data.DataTable GetResidenceVerificationdt = new System.Data.DataTable();
    //    System.Data.DataTable GetDegree_Verificationdt = new System.Data.DataTable();
    //    System.Data.DataTable GetEmployment_Verificationdt = new System.Data.DataTable();
    //    EBC_StandardOutPut objReport = new EBC_StandardOutPut();         
        
        
    //    //declaring excel variables
    //    Excel.Application oExcelApp;
    //    Excel.Workbooks oBooks;
    //    Excel._Workbook oBook;
    //    Excel._Worksheet oSheet;
    //    Excel._Worksheet oSheet1;
    //    Excel.Range oexcelRange;
    //    object oMissing;
    //    //for getting connection string
    //    CCommon oCmn;
    //    try
    //    {
    //        String strCentreID = Session["CentreId"].ToString(); //"1011";"1011";
    //        String strClientID = Session["ClientId"].ToString(); //"1013";"10111";
    //        if (strCentreID != "" && strClientID != "")
    //        {
    //            oCmn = new CCommon();
    //            //dataset for main data
    //            DataSet ds;
    //            //dataset for attempt details
    //            DataSet ds1;
    //            OleDbConnection conn = new OleDbConnection(oCmn.ConnectionString);
    //            String strRefID = "";
    //            String strExcel = Server.MapPath("excelstanderoutput.xls");

    //            foreach (String strCaseID in arrCaseID)
    //            {
    //                String strTypeID = "";
    //                try
    //                {
    //                    //getting main data
    //                    ds.Tables.Clear();
    //                    ds.Clear();
    //                    string sRefNo = "";
    //                    OleDbDataReader oledbRead;
    //                    oledbRead = objReport.GetRefNoByCaseId(strCaseID);
    //                    if (oledbRead.Read())
    //                        sRefNo = oledbRead["Ref_No"].ToString();

    //                    oledbRead.Close();

    //                    GetGAP_Verificationdt = objReport.GetGAP_Verification(strCaseID);
    //                    GetResidenceVerificationdt = objReport.GetResidenceVerification(strCaseID);
    //                    GetDegree_Verificationdt = objReport.GetDegree_Verification(strCaseID);
    //                    GetEmployment_Verificationdt = objReport.GetEmployment_Verification(strCaseID);


    //                    String strSQL1 = "";


    //                    ds.Tables.Add(dtCaseId);
    //                    ds.Tables[0].TableName = "Main";

    //                    ds.Tables.Add(GetGAP_Verificationdt);
    //                    ds.Tables[1].TableName = "GAP";
    //                    if (ds.Tables["GAP"].Rows.Count > 0)
    //                    {
    //                        String strSQL1 = 1;

    //                    }

    //                    ds.Tables.Add(GetResidenceVerificationdt);
    //                    ds.Tables[2].TableName = "RESIDENCERECORD";

    //                    if (ds.Tables["RESIDENCERECORD"].Rows.Count > 0)
    //                    {
    //                        String strSQL1 = 2;

    //                    }

    //                    ds.Tables.Add(GetDegree_Verificationdt);
    //                    ds.Tables[3].TableName = "DEGREE";
    //                    if (ds.Tables["DEGREE"].Rows.Count > 0)
    //                    {
    //                        String strSQL1 = 3;

    //                    }

    //                    ds.Tables.Add(GetEmployment_Verificationdt);
    //                    ds.Tables[4].TableName = "EmploymentVerification";

    //                    if (ds.Tables["EmploymentVerification"].Rows.Count > 0)
    //                    {
    //                        String strSQL1 = 4;

    //                    }





    //                    //conn.Open();
    //                    //String strSQL = "SELECT * FROM CPV_CC_CASE_OUTPUT_VW " +
    //                    //         "WHERE (CENTRE_ID = '" + strCentreID + "') AND (CLIENT_ID = '" + strClientID + "') AND (CASE_ID = '" + strCaseID + "')";
    //                    //ds = OleDbHelper.ExecuteDataset(conn, CommandType.Text, strSQL);
    //                    //conn.Close();
    //                    //excel setting

    //                    //if (ds.Tables[0].Rows.Count > 0)
    //                    //    strRefID = ds.Tables[0].Rows[0]["REF_NO"].ToString();


    //                    if (!Directory.Exists(Server.MapPath("../../ExportToEBC/EBC/" + Session["UserName"].ToString())))
    //                        Directory.CreateDirectory(Server.MapPath("../../ExportToEBC/EBC/" + Session["UserName"].ToString()));
    //                    String strFileName = Server.MapPath("../../ExportToEBC/EBC/" + Session["UserName"].ToString()) + "/" + strRefID + ".xls";

    //                    if (File.Exists(strFileName))
    //                        File.Delete(strFileName);

    //                    File.Copy(strExcel, strFileName);

    //                    oMissing = System.Reflection.Missing.Value;
    //                    oExcelApp = new Excel.Application();
    //                    oExcelApp.Visible = false;
    //                    oBooks = oExcelApp.Workbooks;
    //                    oMissing = System.Reflection.Missing.Value;
    //                    oExcelApp.Visible = false;
    //                    oBook = oBooks._Open(strFileName, oMissing, oMissing, oMissing, oMissing, oMissing, oMissing, oMissing, oMissing, oMissing, oMissing, oMissing, oMissing);
    //                    oExcelApp.Visible = false;
    //                    oExcelApp.UserControl = false;

    //                    //getting data from dataset to insert it in excel cells
    //                    if (ds != null)
    //                    {
    //                        if (ds.Tables[0].Rows.Count > 0)
    //                        {
    //                            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
    //                            {
    //                                //strTypeID = ds.Tables[0].Rows[i]["VERIFICATION_TYPE_ID"].ToString();
    //                                ////assign ref id

    //                                ////getting attempt details 
    //                                //conn.Open();
    //                                //String strSQL1 = "";
    //                                //if (strTypeID == "1" || strTypeID == "2")
    //                                //{
    //                                //    strSQL1 = "SELECT VERIFIER_ID, ATTEMPT_DATE_TIME, FULLNAME FROM VERIFIER_LAST_ATTEMPT_VW INNER JOIN FE_VW ON VERIFIER_ID=EMP_ID " +
    //                                //              "WHERE CASE_ID='" + strCaseID + "' AND VERIFICATION_TYPE_ID='" + strTypeID + "'";
    //                                //}

    //                                //if (strTypeID == "3" || strTypeID == "4")
    //                                //{
    //                                //    strSQL1 = "SELECT VERIFIER_ID, ATTEMPT_DATE_TIME, TELEPHONE_NO, REMARK, FULLNAME FROM CPV_CC_VERI_ATTEMPTS INNER JOIN TC_VW ON VERIFIER_ID=EMP_ID " +
    //                                //              "WHERE CASE_ID='" + strCaseID + "' AND VERIFICATION_TYPE_ID='" + strTypeID + "'";
    //                                //}
    //                                //ds1 = OleDbHelper.ExecuteDataset(conn, CommandType.Text, strSQL1);
    //                                //conn.Close();
    //                                // SUMMARY
    //                                oSheet1 = (Excel._Worksheet)oBook.Worksheets["Summary"];
    //                                oSheet1.Visible = Excel.XlSheetVisibility.xlSheetVisible;
    //                                oSheet1.Unprotect(oMissing);

    //                                //filling excel according to verification type 
    //                                switch (Convert.ToInt16(strTypeID))
    //                                {
    //                                    case 1:
    //                                        //GAP
    //                                        oSheet = (Excel._Worksheet)oBook.Worksheets["Deg_Veri"];
    //                                        oSheet.Visible = Excel.XlSheetVisibility.xlSheetVisible;
    //                                        oSheet.Unprotect(oMissing);

    //                                        oexcelRange = ((Excel.Range)oSheet.Cells[5, 5]);
    //                                        oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
    //                                        oexcelRange.Value2 = ds.Tables[0].Rows[i]["APPLICANT_NAME"].ToString();

    //                                        oexcelRange = ((Excel.Range)oSheet.Cells[6, 4]);
    //                                        oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
    //                                        oexcelRange.Value2 = ds.Tables[0].Rows[i]["REF_NO"].ToString();

    //                                        oexcelRange = ((Excel.Range)oSheet.Cells[6, 8]);
    //                                        oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
    //                                        oexcelRange.Value2 = Convert.ToDateTime(ds.Tables[0].Rows[i]["CASE_REC_DATETIME"].ToString()).ToString("dd/MM/yyyy");

    //                                        oexcelRange = ((Excel.Range)oSheet.Cells[6, 13]);
    //                                        oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
    //                                        oexcelRange.Value2 = ds.Tables[0].Rows[i]["AGENCY_NAME"].ToString();

    //                                        oexcelRange = ((Excel.Range)oSheet.Cells[7, 4]);
    //                                        oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
    //                                        oexcelRange.Value2 = ds.Tables[0].Rows[i]["RES_ADD_LINE"].ToString();

    //                                        oexcelRange = ((Excel.Range)oSheet.Cells[8, 7]);
    //                                        oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
    //                                        oexcelRange.Value2 = ds.Tables[0].Rows[i]["RES_PIN_CODE"].ToString();

    //                                        oexcelRange = ((Excel.Range)oSheet.Cells[8, 10]);
    //                                        oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
    //                                        oexcelRange.Value2 = ds.Tables[0].Rows[i]["RES_LAND_MARK"].ToString();

    //                                        oexcelRange = ((Excel.Range)oSheet.Cells[9, 4]);
    //                                        oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
    //                                        oexcelRange.Value2 = ds.Tables[0].Rows[i]["RES_PHONE"].ToString();

    //                                        oexcelRange = ((Excel.Range)oSheet.Cells[9, 8]);
    //                                        oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
    //                                        oexcelRange.Value2 = ds.Tables[0].Rows[i]["PP_NORMAL"].ToString();

    //                                        oexcelRange = ((Excel.Range)oSheet.Cells[9, 12]);
    //                                        oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
    //                                        oexcelRange.Value2 = ds.Tables[0].Rows[i]["MOBILE"].ToString();

    //                                        oexcelRange = ((Excel.Range)oSheet.Cells[11, 4]);
    //                                        oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
    //                                        oexcelRange.Value2 = ds.Tables[0].Rows[i]["PERMANENT_ADDRESS"].ToString();

    //                                        oexcelRange = ((Excel.Range)oSheet.Cells[12, 7]);
    //                                        oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
    //                                        oexcelRange.Value2 = ds.Tables[0].Rows[i]["PINCODE"].ToString();

    //                                        oexcelRange = ((Excel.Range)oSheet.Cells[12, 10]);
    //                                        oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
    //                                        oexcelRange.Value2 = ds.Tables[0].Rows[i]["LAND_MARK_OBSERVED"].ToString();

    //                                        oexcelRange = ((Excel.Range)oSheet.Cells[12, 12]);
    //                                        oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
    //                                        oexcelRange.Value2 = "N/A";// ds.Tables[0].Rows[i]["CASE_ID"].ToString();

    //                                        oexcelRange = ((Excel.Range)oSheet.Cells[13, 4]);
    //                                        oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
    //                                        oexcelRange.Value2 = ds.Tables[0].Rows[i]["DOB"].ToString();

    //                                        oexcelRange = ((Excel.Range)oSheet.Cells[13, 9]);
    //                                        oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
    //                                        oexcelRange.Value2 = ds.Tables[0].Rows[i]["QUALIFICATION"].ToString();

    //                                        oexcelRange = ((Excel.Range)oSheet.Cells[13, 13]);
    //                                        oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
    //                                        oexcelRange.Value2 = ds.Tables[0].Rows[i]["TIME_AT_CURR_Y_M"].ToString();

    //                                        oexcelRange = ((Excel.Range)oSheet.Cells[14, 4]);
    //                                        oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
    //                                        oexcelRange.Value2 = ds.Tables[0].Rows[i]["MARITAL_STATUS"].ToString();

    //                                        oexcelRange = ((Excel.Range)oSheet.Cells[14, 9]);
    //                                        oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
    //                                        oexcelRange.Value2 = ds.Tables[0].Rows[i]["NO_OF_DEPENDENT"].ToString();

    //                                        oexcelRange = ((Excel.Range)oSheet.Cells[14, 11]);
    //                                        oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
    //                                        oexcelRange.Value2 = ds.Tables[0].Rows[i]["DESIGNATION"].ToString();

    //                                        oexcelRange = ((Excel.Range)oSheet.Cells[15, 4]);
    //                                        oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
    //                                        oexcelRange.Value2 = ds.Tables[0].Rows[i]["COMPANY_NAME"].ToString();

    //                                        oexcelRange = ((Excel.Range)oSheet.Cells[15, 11]);
    //                                        oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
    //                                        oexcelRange.Value2 = ds.Tables[0].Rows[i]["OFFICE_TELEPHONE"].ToString() + " " + ds.Tables[0].Rows[i]["OFFICE_EXT"].ToString();

    //                                        oexcelRange = ((Excel.Range)oSheet.Cells[16, 4]);
    //                                        oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
    //                                        oexcelRange.Value2 = ds.Tables[0].Rows[i]["OFFICE_ADDRESS"].ToString();

    //                                        oexcelRange = ((Excel.Range)oSheet.Cells[17, 4]);
    //                                        oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
    //                                        oexcelRange.Value2 = ds.Tables[0].Rows[i]["VEHICLE_TYPE"].ToString();

    //                                        oexcelRange = ((Excel.Range)oSheet.Cells[17, 9]);
    //                                        oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
    //                                        oexcelRange.Value2 = ds.Tables[0].Rows[i]["VEHICLE_MAKE"].ToString();

    //                                        oexcelRange = ((Excel.Range)oSheet.Cells[17, 11]);
    //                                        oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
    //                                        oexcelRange.Value2 = ds.Tables[0].Rows[i]["VEHICLE_IS"].ToString();

    //                                        oexcelRange = ((Excel.Range)oSheet.Cells[18, 4]);
    //                                        oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
    //                                        oexcelRange.Value2 = ds.Tables[0].Rows[i]["INCOME_DOC_SUBMITTED_WITH_APLICATION"].ToString();

    //                                        oexcelRange = ((Excel.Range)oSheet.Cells[18, 9]);
    //                                        oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
    //                                        oexcelRange.Value2 = ds.Tables[0].Rows[i]["IS_CREDIT_CARD"].ToString();

    //                                        oexcelRange = ((Excel.Range)oSheet.Cells[18, 11]);
    //                                        oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
    //                                        oexcelRange.Value2 = ds.Tables[0].Rows[i]["CARD_TYPE"].ToString();

    //                                        oexcelRange = ((Excel.Range)oSheet.Cells[19, 4]);
    //                                        oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
    //                                        oexcelRange.Value2 = ds.Tables[0].Rows[i]["CARD_NO"].ToString();

    //                                        oexcelRange = ((Excel.Range)oSheet.Cells[19, 9]);
    //                                        oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
    //                                        oexcelRange.Value2 = ds.Tables[0].Rows[i]["CARD_LIMIT"].ToString();

    //                                        oexcelRange = ((Excel.Range)oSheet.Cells[19, 11]);
    //                                        oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
    //                                        oexcelRange.Value2 = ds.Tables[0].Rows[i]["CARD_EXPIRY"].ToString();

    //                                        oexcelRange = ((Excel.Range)oSheet.Cells[21, 5]);
    //                                        oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
    //                                        oexcelRange.Value2 = ds.Tables[0].Rows[i]["APPLICANT_AVAILABILITY"].ToString();

    //                                        oexcelRange = ((Excel.Range)oSheet.Cells[21, 7]);
    //                                        oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
    //                                        oexcelRange.Value2 = ds.Tables[0].Rows[i]["TIME_AT_CURR_RESIDANCE"].ToString();

    //                                        oexcelRange = ((Excel.Range)oSheet.Cells[21, 11]);
    //                                        oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
    //                                        oexcelRange.Value2 = "N/A";//ds.Tables[0].Rows[i]["RESIDANCE_IS"].ToString();

    //                                        oexcelRange = ((Excel.Range)oSheet.Cells[22, 5]);
    //                                        oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
    //                                        oexcelRange.Value2 = "N/A";//ds.Tables[0].Rows[i]["IS_SPOUSE_WORKING"].ToString();

    //                                        oexcelRange = ((Excel.Range)oSheet.Cells[22, 9]);
    //                                        oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
    //                                        oexcelRange.Value2 = ds.Tables[0].Rows[i]["APPLICANT_WORKS_AT"].ToString();

    //                                        oexcelRange = ((Excel.Range)oSheet.Cells[22, 11]);
    //                                        oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
    //                                        oexcelRange.Value2 = ds.Tables[0].Rows[i]["VERIFIED_NEIGHBOUR"].ToString();

    //                                        oexcelRange = ((Excel.Range)oSheet.Cells[24, 4]);
    //                                        oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
    //                                        oexcelRange.Value2 = ds.Tables[0].Rows[i]["RES_TYPE"].ToString();

    //                                        oexcelRange = ((Excel.Range)oSheet.Cells[24, 10]);
    //                                        oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
    //                                        oexcelRange.Value2 = ds.Tables[0].Rows[i]["APPROXIMATE_AREA"].ToString();

    //                                        oexcelRange = ((Excel.Range)oSheet.Cells[25, 4]);
    //                                        oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
    //                                        oexcelRange.Value2 = ds.Tables[0].Rows[i]["GENRAL_APPEARANCE"].ToString();

    //                                        oexcelRange = ((Excel.Range)oSheet.Cells[24, 10]);
    //                                        oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
    //                                        oexcelRange.Value2 = ds.Tables[0].Rows[i]["LOCALITY"].ToString();

    //                                        oexcelRange = ((Excel.Range)oSheet.Cells[26, 4]);
    //                                        oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
    //                                        oexcelRange.Value2 = ds.Tables[0].Rows[i]["LOCATING_ADDRESS"].ToString();

    //                                        oexcelRange = ((Excel.Range)oSheet.Cells[26, 10]);
    //                                        oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
    //                                        oexcelRange.Value2 = ds.Tables[0].Rows[i]["ASSETS_VISIBLE"].ToString();

    //                                        oexcelRange = ((Excel.Range)oSheet.Cells[27, 6]);
    //                                        oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
    //                                        oexcelRange.Value2 = ds.Tables[0].Rows[i]["PORTRAIT"].ToString();

    //                                        oexcelRange = ((Excel.Range)oSheet.Cells[27, 10]);
    //                                        oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
    //                                        oexcelRange.Value2 = ds.Tables[0].Rows[i]["PROOF_OF_VISIT_COLLECTED"].ToString();

    //                                        oexcelRange = ((Excel.Range)oSheet.Cells[28, 6]);
    //                                        oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
    //                                        oexcelRange.Value2 = ds.Tables[0].Rows[i]["ROUTE_MAP_DRAWN"].ToString();

    //                                        oexcelRange = ((Excel.Range)oSheet.Cells[28, 9]);
    //                                        oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
    //                                        oexcelRange.Value2 = ds.Tables[0].Rows[i]["IS_NEGATIVE_AREA"].ToString();

    //                                        oexcelRange = ((Excel.Range)oSheet.Cells[28, 12]);
    //                                        oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
    //                                        oexcelRange.Value2 = ds.Tables[0].Rows[i]["IS_OCL"].ToString();

    //                                        oexcelRange = ((Excel.Range)oSheet.Cells[29, 4]);
    //                                        oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
    //                                        oexcelRange.Value2 = ds.Tables[0].Rows[i]["TPC_DONE"].ToString();

    //                                        oexcelRange = ((Excel.Range)oSheet.Cells[29, 10]);
    //                                        oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
    //                                        oexcelRange.Value2 = ds.Tables[0].Rows[i]["TPC_DETAILS"].ToString();

    //                                        oexcelRange = ((Excel.Range)oSheet.Cells[30, 5]);
    //                                        oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
    //                                        oexcelRange.Value2 = ds.Tables[0].Rows[i]["ANY_OTHER_INFO_OBT"].ToString();

    //                                        oexcelRange = ((Excel.Range)oSheet.Cells[31, 5]);
    //                                        oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
    //                                        oexcelRange.Value2 = ds.Tables[0].Rows[i]["FE_REMARK"].ToString();

    //                                        oexcelRange = ((Excel.Range)oSheet.Cells[34, 4]);
    //                                        oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
    //                                        oexcelRange.Value2 = ds.Tables[0].Rows[i]["ADRESS_CONFIRMATION"].ToString();

    //                                        oexcelRange = ((Excel.Range)oSheet.Cells[34, 7]);
    //                                        oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
    //                                        oexcelRange.Value2 = ds.Tables[0].Rows[i]["CONTACTABILITY"].ToString();

    //                                        oexcelRange = ((Excel.Range)oSheet.Cells[34, 11]);
    //                                        oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
    //                                        oexcelRange.Value2 = ds.Tables[0].Rows[i]["CONFIRMATION_IF_APPLICANT_MET"].ToString();

    //                                        oexcelRange = ((Excel.Range)oSheet.Cells[35, 4]);
    //                                        oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
    //                                        oexcelRange.Value2 = ds.Tables[0].Rows[i]["PROFILE"].ToString();

    //                                        oexcelRange = ((Excel.Range)oSheet.Cells[35, 7]);
    //                                        oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
    //                                        oexcelRange.Value2 = ds.Tables[0].Rows[i]["REPUTATION"].ToString();

    //                                        oexcelRange = ((Excel.Range)oSheet.Cells[35, 11]);
    //                                        oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
    //                                        oexcelRange.Value2 = ds.Tables[0].Rows[i]["DECLINED_CODE"].ToString();

    //                                        oexcelRange = ((Excel.Range)oSheet.Cells[36, 4]);
    //                                        oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
    //                                        oexcelRange.Value2 = ds.Tables[0].Rows[i]["DECLINED_REASON"].ToString();

    //                                        oexcelRange = ((Excel.Range)oSheet.Cells[37, 4]);
    //                                        oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
    //                                        oexcelRange.Value2 = ds.Tables[0].Rows[i]["OVERALL_ASSESMENT"].ToString();

    //                                        oexcelRange = ((Excel.Range)oSheet.Cells[38, 5]);
    //                                        oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
    //                                        oexcelRange.Value2 = ds.Tables[0].Rows[i]["OVERALL_ASSESMENT_REASON"].ToString();
    //                                        oexcelRange = ((Excel.Range)oSheet.Cells[39, 11]);
    //                                        oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
    //                                        oexcelRange.Value2 = ds.Tables[0].Rows[i]["FULLNAME"].ToString();

    //                                        oexcelRange = ((Excel.Range)oSheet.Cells[40, 11]);
    //                                        oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
    //                                        oexcelRange.Value2 = "";
    //                                        //SUMMARY
    //                                        switch (ds.Tables[0].Rows[i]["CASE_STATUS_ID"].ToString())
    //                                        {
    //                                            case "1":
    //                                                oexcelRange = ((Excel.Range)oSheet1.Cells[27, 6]);
    //                                                oexcelRange.HorizontalAlignment = HorizontalAlign.Center;
    //                                                oexcelRange.BorderAround(LineStyle.SingleLine, XlBorderWeight.xlMedium, XlColorIndex.xlColorIndexAutomatic, oMissing);
    //                                                oexcelRange.Hyperlinks.Add(oexcelRange, oBook.FullName, "'" + oSheet.Name + "'" + "!A1", oMissing, "");
    //                                                oexcelRange.Font.Bold = true;
    //                                                oexcelRange.Font.Size = 11;
    //                                                oexcelRange.Value2 = "X";
    //                                                break;
    //                                            case "2":
    //                                                oexcelRange = ((Excel.Range)oSheet1.Cells[29, 6]);
    //                                                oexcelRange.HorizontalAlignment = HorizontalAlign.Center;
    //                                                oexcelRange.BorderAround(LineStyle.SingleLine, XlBorderWeight.xlMedium, XlColorIndex.xlColorIndexAutomatic, oMissing);
    //                                                //hyperlink = (Hyperlink)oexcelRange.Hyperlinks.Add(oexcelRange, ((Excel._Worksheet)oBook.Worksheets["RV"]).Cells[1,1].ToString(), oMissing, oMissing, oMissing);
    //                                                oexcelRange.Hyperlinks.Add(oexcelRange, oBook.FullName, "'" + oSheet.Name + "'" + "!A1", oMissing, "");
    //                                                oexcelRange.Font.Bold = true;
    //                                                oexcelRange.Font.Size = 11;
    //                                                oexcelRange.Value2 = "X";

    //                                                break;
    //                                            case "3":
    //                                                oexcelRange = ((Excel.Range)oSheet1.Cells[31, 6]);
    //                                                oexcelRange.HorizontalAlignment = HorizontalAlign.Center;
    //                                                oexcelRange.BorderAround(LineStyle.SingleLine, XlBorderWeight.xlMedium, XlColorIndex.xlColorIndexAutomatic, oMissing);
    //                                                oexcelRange.Hyperlinks.Add(oexcelRange, oBook.FullName, "'" + oSheet.Name + "'" + "!A1", oMissing, "");
    //                                                oexcelRange.Font.Bold = true;
    //                                                oexcelRange.Font.Size = 11;
    //                                                oexcelRange.Value2 = "X";
    //                                                break;
    //                                            default:
    //                                                break;

    //                                        }
    //                                        break;
                                       
    //                                }
    //                            }
    //                        }
    //                    }
    //                    ds.Clear();
    //                    oBook.Save();
    //                    oSheet = null;
    //                    oBook.Close(false, oMissing, false);
    //                    oBook = null;
    //                    oBooks.Close();
    //                    oBooks = null;

    //                    oExcelApp.Quit();
    //                    oExcelApp = null;
    //                }

    //                catch (Exception exp)
    //                {
    //                    conn.Close();
    //                    throw new Exception(exp.Message);
    //                    // lblMsg.Text = exp.Message;
    //                }

    //            }
    //            conn.Close();
    //        }
    //    }
    //    catch (Exception exp)
    //    {
    //        throw new Exception(exp.Message);

    //    }
    //}


    protected void btnGenrate_Report_Click(object sender, EventArgs e)
    {
        int iCount = 0;
        try
        {
            CCommon con = new CCommon();
            EBC_StandardOutPut objStandardOutput = new EBC_StandardOutPut();
            string strId = "";
            string FinalwhereId = "";
            foreach (GridViewRow gvror in gvOutput.Rows)
            {
                System.Web.UI.WebControls.CheckBox chk = gvror.FindControl("chkCaseId") as System.Web.UI.WebControls.CheckBox;
                if (chk.Checked == true)
                {
                    System.Web.UI.WebControls.Label CaseId = gvror.FindControl("Label1") as System.Web.UI.WebControls.Label;
                    strId = CaseId.Text;
                    if (FinalwhereId != "")
                    {
                        FinalwhereId = FinalwhereId + "," + strId;
                    }
                    else
                    {
                        FinalwhereId = strId;
                    }
                }
            }


            if (FinalwhereId.Trim() != "")
            {
                DataSet dsStdOutput = new DataSet();
                EBC_StandardOutPut objReport = new EBC_StandardOutPut();               
                System.Data.DataTable dtCaseId = new System.Data.DataTable();
                System.Data.DataTable GetGAP_Verificationdt = new System.Data.DataTable();                
                System.Data.DataTable GetResidenceVerificationdt = new System.Data.DataTable();                
                System.Data.DataTable GetDegree_Verificationdt = new System.Data.DataTable();
                System.Data.DataTable GetEmployment_Verificationdt = new System.Data.DataTable();                 
                //System.Data.DataTable dtResiTeleAttempt = new System.Data.DataTable();
                //System.Data.DataTable dtOfficeTeleAttempt = new System.Data.DataTable();
                string[] arrCaseId = FinalwhereId.Split(',');
                if (arrCaseId.Length > 0)
                {
                    for (int i = 0; i < arrCaseId.Length; i++)
                    {
                        dsStdOutput.Tables.Clear();
                        dsStdOutput.Clear();
                        string sRefNo = "";
                        OleDbDataReader oledbRead;
                        oledbRead = objReport.GetRefNoByCaseId(arrCaseId[i].ToString());
                        if (oledbRead.Read())
                            sRefNo = oledbRead["Ref_No"].ToString();

                        oledbRead.Close();
                        //dtCaseId = objReport.GetCaseIdforReport(arrCaseId[i].ToString());
                        GetGAP_Verificationdt = objReport.GetGAP_Verification(arrCaseId[i].ToString());
                        GetResidenceVerificationdt = objReport.GetResidenceVerification(arrCaseId[i].ToString());
                        GetDegree_Verificationdt = objReport.GetDegree_Verification(arrCaseId[i].ToString());
                        GetEmployment_Verificationdt = objReport.GetEmployment_Verification(arrCaseId[i].ToString());

                        dsStdOutput.Tables.Add(dtCaseId);

                        dsStdOutput.Tables[0].TableName = "Main";

                        dsStdOutput.Tables.Add(GetGAP_Verificationdt);
                        dsStdOutput.Tables[1].TableName = "GAP";

                        dsStdOutput.Tables.Add(GetResidenceVerificationdt);
                        dsStdOutput.Tables[2].TableName = "RESIDENCERECORD";

                        dsStdOutput.Tables.Add(GetDegree_Verificationdt);
                        dsStdOutput.Tables[3].TableName = "DEGREE";

                        dsStdOutput.Tables.Add(GetEmployment_Verificationdt);
                        dsStdOutput.Tables[4].TableName = "EmploymentVerification";
                        //ECB_rpt_Rv_Office.rpt
                        //ECB_rpt_EMP_DEG_Office.rpt
                        //ECB_rpt_EmpVery_Office.rpt
                        //ECB_rpt_EMP_DEG_Office.rpt
                        CrystalReportDocument myReportDocument;
                        myReportDocument = new CrystalReportDocument();

                        if (dsStdOutput.Tables["GAP"].Rows.Count > 0)
                        {
                            myReportDocument.Load(Server.MapPath("ECB_rpt_Gap_Office.rpt"));
                            myReportDocument.SetDataSource(dsStdOutput);
                        }

                        if (dsStdOutput.Tables["RESIDENCERECORD"].Rows.Count > 0)
                        {
                            myReportDocument.Load(Server.MapPath("ECB_rpt_Rv_Office.rpt"));
                            myReportDocument.SetDataSource(dsStdOutput);
                        }


                        if (dsStdOutput.Tables["DEGREE"].Rows.Count > 0)
                        {
                            myReportDocument.Load(Server.MapPath("ECB_rpt_EMP_DEG_Office.rpt"));
                            myReportDocument.SetDataSource(dsStdOutput);
                        }


                        if (dsStdOutput.Tables["EmploymentVerification"].Rows.Count > 0)
                        {
                            myReportDocument.Load(Server.MapPath("ECB_rpt_EmpVery_Office.rpt"));
                            myReportDocument.SetDataSource(dsStdOutput);
                        }


                        if (!Directory.Exists(Server.MapPath("../../ExportToUTI/EBC/" + Session["UserName"].ToString())))
                            Directory.CreateDirectory(Server.MapPath("../../ExportToUTI/EBC/" + Session["UserName"].ToString()));
                        myReportDocument.ExportToDisk(ExportFormatType.PortableDocFormat, Server.MapPath("../../ExportToUTI/EBC/" + Session["UserName"].ToString()) + "/" + sRefNo + ".pdf");
                        myReportDocument.Dispose();
                        GC.Collect();
                    }
                    lblMsg.Visible = true;
                    lblMsg.ForeColor = System.Drawing.Color.Red;
                    lblMsg.Text = "Report generated successfully.";
                    hplDownload.Visible = true;
                    hplDownload.NavigateUrl = ConfigurationManager.AppSettings["FtpPath"] + "//EBC//" + Session["UserName"].ToString() + "//";

                }
            }
            else
            {
                lblMsg.Visible = true;
                lblMsg.Text = "Please select case.";
                hplDownload.Visible = false;
                hplDownload.NavigateUrl = "";
                //gvOutput.DataBind();
            }

        }
        catch (Exception ex)
        {
            lblMsg.Visible = true;
            lblMsg.Text = ex.Message.ToString();
            hplDownload.Visible = false;
            hplDownload.NavigateUrl = "";

        }

    }

    protected void gvOutput_DataBound(object sender, System.EventArgs e)
    {
        // Each time the data is bound to the grid we need to build up the CheckBoxIDs array
        // Get the header CheckBox
        if (gvOutput.Rows.Count <= 0)
        {
            //lblMsg.Text = "No record found";
        }
        else
        {
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
}
