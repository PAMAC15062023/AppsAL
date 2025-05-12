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

public partial class CPV_CC_CC_Standard_Output : System.Web.UI.Page
{
    CCommon objCmn = new CCommon();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["isView"].ToString() != "1")
            Response.Redirect("NoAccess.aspx");
        gvOutput.DataBind();
        txtFromDate.Focus();
        lblMsg.Text = "";
    }
    //search to fill database between from to SEND_DATETIME
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        String strCentreID = Session["CentreId"].ToString(); //"1011";
        String strClientID = Session["ClientId"].ToString(); //"1013";
        //String strDateCriteria = "";
        string ToDate = "";
        string FromDate = "";
        //modified by hemangi kambli on 21-Aug-2007 --------------------------
        //By Ashish...
        //if (txtToDate.Text.Trim() != "")
        //    ToDate = Convert.ToDateTime(objCmn.strDate(txtToDate.Text.Trim())).AddDays(1.0).ToString("dd-MMM-yyyy");

        //if (txtFromDate.Text.Trim() != "")
        //    FromDate = objCmn.strDate(txtFromDate.Text.Trim());
        
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
        //----------------------------------------------------------------------------
        //if (txtFromDate.Text != "")
        //{
        //    strDateCriteria = " AND convert(varchar,SEND_DATETIME,106)>='" + txtFromDate.Text.ToString().Trim() + "'";
        //}
        //if (txtToDate.Text != "")
        //{
        //    strDateCriteria = " AND convert(varchar,SEND_DATETIME,106)<'" + ToDate + "'";
        //}

        if (strCentreID != "" && strClientID != "")
        {
            
            //sdsOutput.SelectCommand = "SELECT [CASE_ID], ISNULL(FIRST_NAME + ' ', '') +ISNULL(MIDDLE_NAME + ' ', '') + ISNULL(LAST_NAME + ' ', '') + ISNULL(FULL_NAME + ' ', '') AS [APPLICANT_NAME], [VERIFICATION_CODE] FROM [CPV_CC_CASE_DETAILS] " +
            //    "WHERE (([SEND_DATETIME] IS NOT NULL) AND ([CENTRE_ID] = '" + strCentreID + "') AND ([CLIENT_ID] = '" + strClientID + "')" + strDateCriteria + ")";
            //modified by hemangi kambli on 18-May-2007-----------
            //sdsOutput.SelectCommand = "SELECT [CASE_ID], ISNULL(FIRST_NAME + ' ', '') +ISNULL(MIDDLE_NAME + ' ', '') + ISNULL(LAST_NAME + ' ', '') + ISNULL(FULL_NAME + ' ', '') AS [APPLICANT_NAME], [VERIFICATION_CODE] FROM [CPV_CC_CASE_DETAILS] " +
            //   "WHERE (([SEND_DATETIME] IS NOT NULL) AND ([CENTRE_ID] = '" + strCentreID + "') AND ([CLIENT_ID] = '" + strClientID + "')" + strDateCriteria + ")";
            
            //modified by Asavari Sonawane on 19 May 2007 to add send and recive date columns
            
            //Commented By Ashish on 31-05-07..
            //sdsOutput.SelectCommand = "SELECT [CASE_ID], ISNULL(FIRST_NAME + ' ', '') +ISNULL(MIDDLE_NAME + ' ', '') + ISNULL(LAST_NAME + ' ', '') AS [APPLICANT_NAME], [VERIFICATION_CODE], " +
            //                          "[CASE_REC_DATETIME], [SEND_DATETIME] FROM [CPV_CC_CASE_DETAILS] " +
            //                          "WHERE (([SEND_DATETIME] IS NOT NULL) AND ([CENTRE_ID] = '" + strCentreID + "') AND ([CLIENT_ID] = '" + strClientID + "')" + strDateCriteria + ")";


            //to get total no of records......
            string sSql = "SELECT Count(*) as TotalCount FROM [CPV_CC_CASE_DETAILS] " +
                          "WHERE (([SEND_DATETIME] IS NOT NULL) AND ([CENTRE_ID] = '" + strCentreID + "') AND ([CLIENT_ID] = '" + strClientID + "')and (SEND_DATETIME >='" + FromDate + "' and SEND_DATETIME<'" + ToDate + "' ))";

            OleDbDataReader oledbRead;
            oledbRead = OleDbHelper.ExecuteReader(objCmn.ConnectionString, CommandType.Text, sSql);
            if(oledbRead.Read()==true)
                lblCaseCount.Text = "Number of cases " + oledbRead["TotalCount"].ToString();

            oledbRead.Close();
            ///-----------------
            
            //By Ashish...            
            sdsOutput.SelectCommand = "SELECT [CASE_ID], [REF_NO],ISNULL(FIRST_NAME + ' ', '') +ISNULL(MIDDLE_NAME + ' ', '') + ISNULL(LAST_NAME + ' ', '') AS [APPLICANT_NAME], [VERIFICATION_CODE], " +
                                          " Convert(varchar(24),CASE_REC_DATETIME,103)+ ' ' + LTRIM(SUBSTRING(CONVERT( VARCHAR(20),CASE_REC_DATETIME, 22), 10, 5) " +
                                          " + RIGHT(CONVERT(VARCHAR(20), CASE_REC_DATETIME, 22), 3))as [CASE_REC_DATETIME], " +
                                          " Convert(varchar(24),SEND_DATETIME,103)+ ' ' + LTRIM(SUBSTRING(CONVERT( VARCHAR(20),SEND_DATETIME, 22), 10, 5) " +
                                          " + RIGHT(CONVERT(VARCHAR(20), SEND_DATETIME, 22), 3))as [SEND_DATETIME] " +
                                          " FROM [CPV_CC_CASE_DETAILS] " +
                                          "WHERE (([SEND_DATETIME] IS NOT NULL) AND ([CENTRE_ID] = '" + strCentreID + "') AND ([CLIENT_ID] = '" + strClientID + "')and (SEND_DATETIME >='" + FromDate + "' and SEND_DATETIME<'" + ToDate + "' ))";
            

            gvOutput.DataBind();
            if (gvOutput.Rows.Count > 0)
            {
                //lblCaseCount.Text = "Number of cases " + gvOutput.Rows.Count;
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
                hplDownload.Visible = false;
                hplDownload.NavigateUrl = "";
            }
            
        }
    }
    protected void btnReport_Click(object sender, EventArgs e)
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
            //strSelectedCaseID ="101112938";// "101114613";
            if (strSelectedCaseID != "")
            {
                String[] arrCaseID = (strSelectedCaseID.TrimEnd(',')).Split(',');
                //passed caseid's in array to generate excel
                //GenerateExcel(arrCaseID);
                GenerateExcelStandardFormat(arrCaseID);
                lblMsg.Visible = true;
                lblMsg.Text = "Export completed successfully";
                hplDownload.Visible = true;
                //hplDownload.NavigateUrl = ConfigurationManager.AppSettings["FtpPath"] + "//CC//" + Session["UserName"].ToString() + "//";
                //hplDownload.NavigateUrl = ConfigurationManager.AppSettings["FtpPath"] + "//CC//" + Session["UserName"].ToString() + "//" + DateTime.Now.ToString("ddMMyyyyhhmm") + "//";                
            }
            else
            {
                lblMsg.Text = "Please select case to assign";
                hplDownload.Visible = false;
                hplDownload.NavigateUrl = "";
            }
        }
        catch (Exception exp)
        {
            lblMsg.Text = exp.Message;
            hplDownload.Visible = false;
            hplDownload.NavigateUrl = "";
        }
    }
    /*
    public void GenerateExcel(String[] arrCaseID)
    {
       //declaring excel variables
        Excel.Application oExcelApp;
        Excel.Workbooks oBooks;
        Excel._Workbook oBook;
        Excel._Worksheet oSheet;
        Excel._Worksheet oSheet1;
        Excel.Range oexcelRange;
        object oMissing;
        //for getting connection string
        CCommon oCmn;
        try
        {
            String strCentreID =  Session["CentreId"].ToString(); //"1011";"1011";
            String strClientID =  Session["ClientId"].ToString(); //"1013";"10111";
            if (strCentreID != "" && strClientID != "")
            {               
                oCmn = new CCommon();
                //dataset for main data
                DataSet ds;
                //dataset for attempt details
                DataSet ds1;
                OleDbConnection conn = new OleDbConnection(oCmn.ConnectionString);
                String strRefID = "";
                foreach (String strCaseID in arrCaseID)
                {
                    String strTypeID = "";
                        try
                        {
                            //getting main data
                            conn.Open();
                            String strSQL = "SELECT * FROM CPV_CC_CASE_OUTPUT_VW " +
                                     "WHERE (CENTRE_ID = '" + strCentreID + "') AND (CLIENT_ID = '" + strClientID + "') AND (CASE_ID = '" + strCaseID + "')";
                            ds = OleDbHelper.ExecuteDataset(conn, CommandType.Text, strSQL);
                            conn.Close();
                            //excel setting
                            oMissing = System.Reflection.Missing.Value;
                            oExcelApp = new Excel.Application();
                            oExcelApp.Visible = false;
                            oBooks = oExcelApp.Workbooks;
                            oMissing = System.Reflection.Missing.Value;
                            oExcelApp.Visible = false;
                            String strExcel = Server.MapPath("excelstanderoutput.xls");
                            oBook = oBooks._Open(strExcel, oMissing, oMissing, oMissing, oMissing, oMissing, oMissing, oMissing, oMissing, oMissing, oMissing, oMissing, oMissing);
                            oExcelApp.Visible = false;
                            oExcelApp.UserControl = false;

                            //getting data from dataset to insert it in excel cells
                            if (ds != null)
                            {
                                if (ds.Tables[0].Rows.Count > 0)
                                {
                                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                                    {
                                        strTypeID = ds.Tables[0].Rows[i]["VERIFICATION_TYPE_ID"].ToString();
                                        //assign ref id
                                        strRefID = ds.Tables[0].Rows[i]["REF_NO"].ToString();

                                        //getting attempt details 
                                        conn.Open();
                                        String strSQL1 = "";
                                        if (strTypeID == "1" || strTypeID == "2")
                                        {
                                            strSQL1 = "SELECT VERIFIER_ID, ATTEMPT_DATE_TIME, FULLNAME FROM VERIFIER_LAST_ATTEMPT_VW INNER JOIN FE_VW ON VERIFIER_ID=EMP_ID " +
                                                      "WHERE CASE_ID='" + strCaseID + "' AND VERIFICATION_TYPE_ID='" + strTypeID + "'";
                                        }

                                        if (strTypeID == "3" || strTypeID == "4")
                                        {
                                            strSQL1 = "SELECT VERIFIER_ID, ATTEMPT_DATE_TIME, TELEPHONE_NO, REMARK, FULLNAME FROM CPV_CC_VERI_ATTEMPTS INNER JOIN TC_VW ON VERIFIER_ID=EMP_ID " +
                                                      "WHERE CASE_ID='" + strCaseID + "' AND VERIFICATION_TYPE_ID='" + strTypeID + "'";
                                        }
                                        ds1 = OleDbHelper.ExecuteDataset(conn, CommandType.Text, strSQL1);
                                        conn.Close();
                                       // SUMMARY
                                        oSheet1 = (Excel._Worksheet)oBook.Worksheets["Summary"];
                                        oSheet1.Visible = Excel.XlSheetVisibility.xlSheetVisible;
                                        oSheet1.Unprotect(oMissing);
                                        
                                        //filling excel according to verification type 
                                        switch (Convert.ToInt16(strTypeID))
                                        {
                                            case 1:                                                
                                                //RV
                                                oSheet = (Excel._Worksheet)oBook.Worksheets["RV"];
                                                oSheet.Visible = Excel.XlSheetVisibility.xlSheetVisible;
                                                oSheet.Unprotect(oMissing);

                                                oexcelRange = ((Excel.Range)oSheet.Cells[5, 5]);
                                                oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                oexcelRange.Value2 = ds.Tables[0].Rows[i]["APPLICANT_NAME"].ToString();

                                                oexcelRange = ((Excel.Range)oSheet.Cells[6, 4]);
                                                oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                oexcelRange.Value2 = ds.Tables[0].Rows[i]["REF_NO"].ToString();
                                               
                                                oexcelRange = ((Excel.Range)oSheet.Cells[6, 8]);
                                                oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                oexcelRange.Value2 = ds.Tables[0].Rows[i]["CASE_REC_DATETIME"].ToString();

                                                oexcelRange = ((Excel.Range)oSheet.Cells[6, 13]);
                                                oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                oexcelRange.Value2 = ds.Tables[0].Rows[i]["AGENCY_NAME"].ToString();

                                                oexcelRange = ((Excel.Range)oSheet.Cells[7, 4]);
                                                oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                oexcelRange.Value2 = ds.Tables[0].Rows[i]["RES_ADD_LINE"].ToString();

                                                oexcelRange = ((Excel.Range)oSheet.Cells[8, 7]);
                                                oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                oexcelRange.Value2 = ds.Tables[0].Rows[i]["RES_PIN_CODE"].ToString();

                                                oexcelRange = ((Excel.Range)oSheet.Cells[8, 10]);
                                                oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                oexcelRange.Value2 = ds.Tables[0].Rows[i]["RES_LAND_MARK"].ToString();

                                                oexcelRange = ((Excel.Range)oSheet.Cells[9, 4]);
                                                oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                oexcelRange.Value2 = ds.Tables[0].Rows[i]["RES_PHONE"].ToString();

                                                oexcelRange = ((Excel.Range)oSheet.Cells[9, 8]);
                                                oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                oexcelRange.Value2 = ds.Tables[0].Rows[i]["PP_NORMAL"].ToString();

                                                oexcelRange = ((Excel.Range)oSheet.Cells[9, 12]);
                                                oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                oexcelRange.Value2 = ds.Tables[0].Rows[i]["MOBILE"].ToString();

                                                oexcelRange = ((Excel.Range)oSheet.Cells[11, 4]);
                                                oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                oexcelRange.Value2 = ds.Tables[0].Rows[i]["PERMANENT_ADDRESS"].ToString();

                                                oexcelRange = ((Excel.Range)oSheet.Cells[12, 7]);
                                                oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                oexcelRange.Value2 = ds.Tables[0].Rows[i]["PINCODE"].ToString();

                                                oexcelRange = ((Excel.Range)oSheet.Cells[12, 10]);
                                                oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                oexcelRange.Value2 = ds.Tables[0].Rows[i]["LAND_MARK_OBSERVED"].ToString();

                                                oexcelRange = ((Excel.Range)oSheet.Cells[12, 12]);
                                                oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                oexcelRange.Value2 = "N/A";// ds.Tables[0].Rows[i]["CASE_ID"].ToString();

                                                oexcelRange = ((Excel.Range)oSheet.Cells[13, 4]);
                                                oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                oexcelRange.Value2 = ds.Tables[0].Rows[i]["DOB"].ToString();

                                                oexcelRange = ((Excel.Range)oSheet.Cells[13, 9]);
                                                oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                oexcelRange.Value2 = ds.Tables[0].Rows[i]["QUALIFICATION"].ToString();

                                                oexcelRange = ((Excel.Range)oSheet.Cells[13, 13]);
                                                oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                oexcelRange.Value2 = ds.Tables[0].Rows[i]["TIME_AT_CURR_Y_M"].ToString();

                                                oexcelRange = ((Excel.Range)oSheet.Cells[14, 4]);
                                                oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                oexcelRange.Value2 = ds.Tables[0].Rows[i]["MARITAL_STATUS"].ToString();

                                                oexcelRange = ((Excel.Range)oSheet.Cells[14, 9]);
                                                oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                oexcelRange.Value2 = ds.Tables[0].Rows[i]["NO_OF_DEPENDENT"].ToString();

                                                oexcelRange = ((Excel.Range)oSheet.Cells[14, 11]);
                                                oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                oexcelRange.Value2 = ds.Tables[0].Rows[i]["DESIGNATION"].ToString();

                                                oexcelRange = ((Excel.Range)oSheet.Cells[15, 4]);
                                                oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                oexcelRange.Value2 = ds.Tables[0].Rows[i]["COMPANY_NAME"].ToString();

                                                oexcelRange = ((Excel.Range)oSheet.Cells[15, 11]);
                                                oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                oexcelRange.Value2 = ds.Tables[0].Rows[i]["OFFICE_TELEPHONE"].ToString() + " " + ds.Tables[0].Rows[i]["OFFICE_EXT"].ToString(); 

                                                oexcelRange = ((Excel.Range)oSheet.Cells[16, 4]);
                                                oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                oexcelRange.Value2 = ds.Tables[0].Rows[i]["OFFICE_ADDRESS"].ToString();

                                                oexcelRange = ((Excel.Range)oSheet.Cells[17, 4]);
                                                oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                oexcelRange.Value2 = ds.Tables[0].Rows[i]["VEHICLE_TYPE"].ToString();

                                                oexcelRange = ((Excel.Range)oSheet.Cells[17, 9]);
                                                oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                oexcelRange.Value2 = ds.Tables[0].Rows[i]["VEHICLE_MAKE"].ToString();

                                                oexcelRange = ((Excel.Range)oSheet.Cells[17, 11]);
                                                oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                oexcelRange.Value2 = ds.Tables[0].Rows[i]["VEHICLE_IS"].ToString();

                                                oexcelRange = ((Excel.Range)oSheet.Cells[18, 4]);
                                                oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                oexcelRange.Value2 = ds.Tables[0].Rows[i]["INCOME_DOC_SUBMITTED_WITH_APLICATION"].ToString();

                                                oexcelRange = ((Excel.Range)oSheet.Cells[18, 9]);
                                                oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                oexcelRange.Value2 = ds.Tables[0].Rows[i]["IS_CREDIT_CARD"].ToString();

                                                oexcelRange = ((Excel.Range)oSheet.Cells[18, 11]);
                                                oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                oexcelRange.Value2 = ds.Tables[0].Rows[i]["CARD_TYPE"].ToString();

                                                oexcelRange = ((Excel.Range)oSheet.Cells[19, 4]);
                                                oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                oexcelRange.Value2 = ds.Tables[0].Rows[i]["CARD_NO"].ToString();

                                                oexcelRange = ((Excel.Range)oSheet.Cells[19, 9]);
                                                oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                oexcelRange.Value2 = ds.Tables[0].Rows[i]["CARD_LIMIT"].ToString();

                                                oexcelRange = ((Excel.Range)oSheet.Cells[19, 11]);
                                                oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                oexcelRange.Value2 = ds.Tables[0].Rows[i]["CARD_EXPIRY"].ToString();

                                                oexcelRange = ((Excel.Range)oSheet.Cells[21, 5]);
                                                oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                oexcelRange.Value2 = ds.Tables[0].Rows[i]["APPLICANT_AVAILABILITY"].ToString();

                                                oexcelRange = ((Excel.Range)oSheet.Cells[21, 7]);
                                                oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                oexcelRange.Value2 = ds.Tables[0].Rows[i]["TIME_AT_CURR_RESIDANCE"].ToString();

                                                oexcelRange = ((Excel.Range)oSheet.Cells[21, 11]);
                                                oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                oexcelRange.Value2 = "N/A";//ds.Tables[0].Rows[i]["RESIDANCE_IS"].ToString();

                                                oexcelRange = ((Excel.Range)oSheet.Cells[22, 5]);
                                                oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                oexcelRange.Value2 = "N/A";//ds.Tables[0].Rows[i]["IS_SPOUSE_WORKING"].ToString();

                                                oexcelRange = ((Excel.Range)oSheet.Cells[22, 9]);
                                                oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                oexcelRange.Value2 = ds.Tables[0].Rows[i]["APPLICANT_WORKS_AT"].ToString();

                                                oexcelRange = ((Excel.Range)oSheet.Cells[22, 11]);
                                                oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                oexcelRange.Value2 = ds.Tables[0].Rows[i]["VERIFIED_NEIGHBOUR"].ToString();

                                                oexcelRange = ((Excel.Range)oSheet.Cells[24, 4]);
                                                oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                oexcelRange.Value2 = ds.Tables[0].Rows[i]["RES_TYPE"].ToString();

                                                oexcelRange = ((Excel.Range)oSheet.Cells[24, 10]);
                                                oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                oexcelRange.Value2 = ds.Tables[0].Rows[i]["APPROXIMATE_AREA"].ToString();

                                                oexcelRange = ((Excel.Range)oSheet.Cells[25, 4]);
                                                oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                oexcelRange.Value2 = ds.Tables[0].Rows[i]["GENRAL_APPEARANCE"].ToString();

                                                oexcelRange = ((Excel.Range)oSheet.Cells[24, 10]);
                                                oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                oexcelRange.Value2 = ds.Tables[0].Rows[i]["LOCALITY"].ToString();

                                                oexcelRange = ((Excel.Range)oSheet.Cells[26, 4]);
                                                oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                oexcelRange.Value2 = ds.Tables[0].Rows[i]["LOCATING_ADDRESS"].ToString();

                                                oexcelRange = ((Excel.Range)oSheet.Cells[26, 10]);
                                                oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                oexcelRange.Value2 = ds.Tables[0].Rows[i]["ASSETS_VISIBLE"].ToString();

                                                oexcelRange = ((Excel.Range)oSheet.Cells[27, 6]);
                                                oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                oexcelRange.Value2 = ds.Tables[0].Rows[i]["PORTRAIT"].ToString();

                                                oexcelRange = ((Excel.Range)oSheet.Cells[27, 10]);
                                                oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                oexcelRange.Value2 = ds.Tables[0].Rows[i]["PROOF_OF_VISIT_COLLECTED"].ToString();

                                                oexcelRange = ((Excel.Range)oSheet.Cells[28, 6]);
                                                oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                oexcelRange.Value2 = ds.Tables[0].Rows[i]["ROUTE_MAP_DRAWN"].ToString();

                                                oexcelRange = ((Excel.Range)oSheet.Cells[28, 9]);
                                                oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                oexcelRange.Value2 = ds.Tables[0].Rows[i]["IS_NEGATIVE_AREA"].ToString();

                                                oexcelRange = ((Excel.Range)oSheet.Cells[28, 12]);
                                                oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                oexcelRange.Value2 = ds.Tables[0].Rows[i]["IS_OCL"].ToString();

                                                oexcelRange = ((Excel.Range)oSheet.Cells[29, 4]);
                                                oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                oexcelRange.Value2 = ds.Tables[0].Rows[i]["TPC_DONE"].ToString();

                                                oexcelRange = ((Excel.Range)oSheet.Cells[29, 10]);
                                                oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                oexcelRange.Value2 = ds.Tables[0].Rows[i]["TPC_DETAILS"].ToString();

                                                oexcelRange = ((Excel.Range)oSheet.Cells[30, 5]);
                                                oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                oexcelRange.Value2 = ds.Tables[0].Rows[i]["ANY_OTHER_INFO_OBT"].ToString();

                                                oexcelRange = ((Excel.Range)oSheet.Cells[31, 5]);
                                                oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                oexcelRange.Value2 = ds.Tables[0].Rows[i]["FE_REMARK"].ToString();

                                                oexcelRange = ((Excel.Range)oSheet.Cells[34, 4]);
                                                oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                oexcelRange.Value2 = ds.Tables[0].Rows[i]["ADRESS_CONFIRMATION"].ToString();

                                                oexcelRange = ((Excel.Range)oSheet.Cells[34, 7]);
                                                oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                oexcelRange.Value2 = ds.Tables[0].Rows[i]["CONTACTABILITY"].ToString();

                                                oexcelRange = ((Excel.Range)oSheet.Cells[34, 11]);
                                                oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                oexcelRange.Value2 = ds.Tables[0].Rows[i]["CONFIRMATION_IF_APPLICANT_MET"].ToString();

                                                oexcelRange = ((Excel.Range)oSheet.Cells[35, 4]);
                                                oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                oexcelRange.Value2 = ds.Tables[0].Rows[i]["PROFILE"].ToString();

                                                oexcelRange = ((Excel.Range)oSheet.Cells[35, 7]);
                                                oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                oexcelRange.Value2 = ds.Tables[0].Rows[i]["REPUTATION"].ToString();

                                                oexcelRange = ((Excel.Range)oSheet.Cells[35, 11]);
                                                oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                oexcelRange.Value2 = ds.Tables[0].Rows[i]["DECLINED_CODE"].ToString();

                                                oexcelRange = ((Excel.Range)oSheet.Cells[36, 4]);
                                                oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                oexcelRange.Value2 = ds.Tables[0].Rows[i]["DECLINED_REASON"].ToString();

                                                oexcelRange = ((Excel.Range)oSheet.Cells[37, 4]);
                                                oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                oexcelRange.Value2 = ds.Tables[0].Rows[i]["OVERALL_ASSESMENT"].ToString();

                                                oexcelRange = ((Excel.Range)oSheet.Cells[38, 5]);
                                                oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                oexcelRange.Value2 = ds.Tables[0].Rows[i]["OVERALL_ASSESMENT_REASON"].ToString();
                                                
                                                if (ds1 != null)
                                                {
                                                    if (ds1.Tables[0].Rows.Count > 0)
                                                    {                                                        
                                                        oexcelRange = ((Excel.Range)oSheet.Cells[39, 4]);
                                                        oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                        oexcelRange.Value2 = ds1.Tables[0].Rows[0]["VERIFIER_ID"].ToString();

                                                        oexcelRange = ((Excel.Range)oSheet.Cells[39, 8]);
                                                        oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                        oexcelRange.Value2 = ds1.Tables[0].Rows[0]["FULLNAME"].ToString();

                                                        oexcelRange = ((Excel.Range)oSheet.Cells[40, 4]);
                                                        oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                        oexcelRange.Value2 = ds1.Tables[0].Rows[0]["ATTEMPT_DATE_TIME"].ToString();
                                                    }
                                                }

                                                oexcelRange = ((Excel.Range)oSheet.Cells[39, 11]);
                                                oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                oexcelRange.Value2 = ds.Tables[0].Rows[i]["FULLNAME"].ToString();

                                                //oexcelRange = ((Excel.Range)oSheet.Cells[40, 4]);
                                                //oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                //oexcelRange.Value2 = ds.Tables[0].Rows[i]["ATTEMPT_DATE_TIME"].ToString();

                                                oexcelRange = ((Excel.Range)oSheet.Cells[40, 11]);
                                                oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                oexcelRange.Value2 = "";
                                                //SUMMARY
                                                switch (ds.Tables[0].Rows[i]["CASE_STATUS_ID"].ToString())
                                                {
                                                    case "1":
                                                        oexcelRange = ((Excel.Range)oSheet1.Cells[27, 6]);
                                                        oexcelRange.HorizontalAlignment = HorizontalAlign.Center;
                                                        oexcelRange.BorderAround(LineStyle.SingleLine, XlBorderWeight.xlMedium, XlColorIndex.xlColorIndexAutomatic, oMissing);
                                                        oexcelRange.Hyperlinks.Add(oexcelRange, oBook.FullName, "'" + oSheet.Name + "'" + "!A1", oMissing, "");
                                                        oexcelRange.Font.Bold = true;
                                                        oexcelRange.Font.Size = 11;
                                                        oexcelRange.Value2 = "X";
                                                        break;
                                                    case "2":
                                                        oexcelRange = ((Excel.Range)oSheet1.Cells[29, 6]);
                                                        oexcelRange.HorizontalAlignment = HorizontalAlign.Center;
                                                        oexcelRange.BorderAround(LineStyle.SingleLine, XlBorderWeight.xlMedium, XlColorIndex.xlColorIndexAutomatic, oMissing);
                                                        //hyperlink = (Hyperlink)oexcelRange.Hyperlinks.Add(oexcelRange, ((Excel._Worksheet)oBook.Worksheets["RV"]).Cells[1,1].ToString(), oMissing, oMissing, oMissing);
                                                        oexcelRange.Hyperlinks.Add(oexcelRange, oBook.FullName, "'" + oSheet.Name + "'" + "!A1", oMissing, "");
                                                        oexcelRange.Font.Bold = true;
                                                        oexcelRange.Font.Size = 11;
                                                        oexcelRange.Value2 = "X";

                                                        break;
                                                    case "3":
                                                        oexcelRange = ((Excel.Range)oSheet1.Cells[31, 6]);
                                                        oexcelRange.HorizontalAlignment = HorizontalAlign.Center;
                                                        oexcelRange.BorderAround(LineStyle.SingleLine, XlBorderWeight.xlMedium, XlColorIndex.xlColorIndexAutomatic, oMissing);
                                                        oexcelRange.Hyperlinks.Add(oexcelRange, oBook.FullName, "'" + oSheet.Name + "'" + "!A1", oMissing, "");
                                                        oexcelRange.Font.Bold = true;
                                                        oexcelRange.Font.Size = 11;
                                                        oexcelRange.Value2 = "X";
                                                        break;
                                                    default:
                                                        break;

                                                }
                                                break;
                                            case 2:                                                
                                                //BV
                                                oSheet = (Excel._Worksheet)oBook.Worksheets["BV"];
                                                oSheet.Visible = Excel.XlSheetVisibility.xlSheetVisible;
                                                oSheet.Unprotect(oMissing);

                                                oexcelRange = ((Excel.Range)oSheet.Cells[5, 5]);
                                                oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                oexcelRange.Value2 = ds.Tables[0].Rows[i]["APPLICANT_NAME"].ToString();

                                                oexcelRange = ((Excel.Range)oSheet.Cells[6, 4]);
                                                oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                oexcelRange.Value2 = ds.Tables[0].Rows[i]["REF_NO"].ToString();

                                                oexcelRange = ((Excel.Range)oSheet.Cells[6, 8]);
                                                oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                oexcelRange.Value2 = ds.Tables[0].Rows[i]["CASE_REC_DATETIME"].ToString();

                                                oexcelRange = ((Excel.Range)oSheet.Cells[6, 13]);
                                                oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                oexcelRange.Value2 = ds.Tables[0].Rows[i]["AGENCY_NAME"].ToString();

                                                oexcelRange = ((Excel.Range)oSheet.Cells[7, 4]);
                                                oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                oexcelRange.Value2 = ds.Tables[0].Rows[i]["OFF_ADD_LINE"].ToString();

                                                oexcelRange = ((Excel.Range)oSheet.Cells[8, 7]);
                                                oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                oexcelRange.Value2 = ds.Tables[0].Rows[i]["OFF_PIN_CODE"].ToString();

                                                oexcelRange = ((Excel.Range)oSheet.Cells[8, 10]);
                                                oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                oexcelRange.Value2 = ds.Tables[0].Rows[i]["LAND_MARK_OBSERVED"].ToString();

                                                oexcelRange = ((Excel.Range)oSheet.Cells[9, 4]);
                                                oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                oexcelRange.Value2 = ds.Tables[0].Rows[i]["OFFICE_TELEPHONE"].ToString();

                                                oexcelRange = ((Excel.Range)oSheet.Cells[9, 10]);
                                                oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                oexcelRange.Value2 = ds.Tables[0].Rows[i]["OFFICE_EXT"].ToString();

                                                oexcelRange = ((Excel.Range)oSheet.Cells[9, 12]);
                                                oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                oexcelRange.Value2 = ds.Tables[0].Rows[i]["MOBILE"].ToString();

                                                oexcelRange = ((Excel.Range)oSheet.Cells[11, 5]);
                                                oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                oexcelRange.Value2 = ds.Tables[0].Rows[i]["CONTACTED_PERSON_NAME"].ToString();

                                                oexcelRange = ((Excel.Range)oSheet.Cells[11, 12]);
                                                oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                oexcelRange.Value2 = ds.Tables[0].Rows[i]["CONTACTED_PERSON_DESIGN"].ToString();

                                                oexcelRange = ((Excel.Range)oSheet.Cells[12, 5]);
                                                oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                oexcelRange.Value2 = ds.Tables[0].Rows[i]["PERSON_CONTACTED_MET"].ToString();

                                                oexcelRange = ((Excel.Range)oSheet.Cells[12, 11]);
                                                oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                oexcelRange.Value2 = ds.Tables[0].Rows[i]["COMPANY_NAME"].ToString();

                                                oexcelRange = ((Excel.Range)oSheet.Cells[13, 5]);
                                                oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                oexcelRange.Value2 = "N/A";//ds.Tables[0].Rows[i]["CASE_ID"].ToString();

                                                oexcelRange = ((Excel.Range)oSheet.Cells[13, 12]);
                                                oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                oexcelRange.Value2 = ds.Tables[0].Rows[i]["COMPANY_EXISTENCE_YEAR"].ToString();

                                                oexcelRange = ((Excel.Range)oSheet.Cells[14, 5]);
                                                oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                oexcelRange.Value2 = ds.Tables[0].Rows[i]["DESIGNATION"].ToString();

                                                oexcelRange = ((Excel.Range)oSheet.Cells[14, 12]);
                                                oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                oexcelRange.Value2 = ds.Tables[0].Rows[i]["TIME_AT_CURRENT_EMPLOYMENT"].ToString();

                                                oexcelRange = ((Excel.Range)oSheet.Cells[15, 5]);
                                                oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                oexcelRange.Value2 = ds.Tables[0].Rows[i]["EMP_JOB_TYPE"].ToString();

                                                oexcelRange = ((Excel.Range)oSheet.Cells[15, 12]);
                                                oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                oexcelRange.Value2 = ds.Tables[0].Rows[i]["BUSINESS_PERMISES"].ToString();

                                                oexcelRange = ((Excel.Range)oSheet.Cells[17, 5]);
                                                oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                oexcelRange.Value2 = ds.Tables[0].Rows[i]["DOB"].ToString();

                                                oexcelRange = ((Excel.Range)oSheet.Cells[17, 13]);
                                                oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                oexcelRange.Value2 = ds.Tables[0].Rows[i]["INCOME_DOC_SUBMITTED_WITH_APLICATION"].ToString();

                                                oexcelRange = ((Excel.Range)oSheet.Cells[18, 5]);
                                                oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                oexcelRange.Value2 = ds.Tables[0].Rows[i]["PERMANENT_ADDRESS"].ToString();

                                                oexcelRange = ((Excel.Range)oSheet.Cells[19, 10]);
                                                oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                oexcelRange.Value2 = ds.Tables[0].Rows[i]["ANY_OTHER_RESIDANCE_PHONE_NO"].ToString();

                                                oexcelRange = ((Excel.Range)oSheet.Cells[20, 5]);
                                                oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                oexcelRange.Value2 = ds.Tables[0].Rows[i]["ADD_ON_APPLIED"].ToString();

                                                oexcelRange = ((Excel.Range)oSheet.Cells[21, 10]);
                                                oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                oexcelRange.Value2 = ds.Tables[0].Rows[i]["CHANGE_IN_PHONE_NO"].ToString();

                                                oexcelRange = ((Excel.Range)oSheet.Cells[23, 5]);
                                                oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                oexcelRange.Value2 = ds.Tables[0].Rows[i]["OFF_NAME_ON_BOARD"].ToString();

                                                oexcelRange = ((Excel.Range)oSheet.Cells[23, 12]);
                                                oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                oexcelRange.Value2 = ds.Tables[0].Rows[i]["REASON_NONVISIBLE_NAMEPLATE"].ToString();

                                                oexcelRange = ((Excel.Range)oSheet.Cells[24, 5]);
                                                oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                oexcelRange.Value2 = ds.Tables[0].Rows[i]["OFFICE_SIZE"].ToString();

                                                oexcelRange = ((Excel.Range)oSheet.Cells[24, 10]);
                                                oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                oexcelRange.Value2 = ds.Tables[0].Rows[i]["APPROXIMATE_AREA"].ToString();

                                                oexcelRange = ((Excel.Range)oSheet.Cells[24, 13]);
                                                oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                oexcelRange.Value2 = ds.Tables[0].Rows[i]["NO_OF_EMP"].ToString();

                                                oexcelRange = ((Excel.Range)oSheet.Cells[25, 5]);
                                                oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                oexcelRange.Value2 = ds.Tables[0].Rows[i]["GENRAL_APPEARANCE"].ToString();

                                                oexcelRange = ((Excel.Range)oSheet.Cells[25, 12]);
                                                oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                oexcelRange.Value2 = ds.Tables[0].Rows[i]["OFFICE_LOCALITY"].ToString();

                                                oexcelRange = ((Excel.Range)oSheet.Cells[26, 5]);
                                                oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                oexcelRange.Value2 = ds.Tables[0].Rows[i]["OFFICE_REPUTATION"].ToString();

                                                oexcelRange = ((Excel.Range)oSheet.Cells[26, 12]);
                                                oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                oexcelRange.Value2 = ds.Tables[0].Rows[i]["LOCATING_ADDRESS"].ToString();

                                                oexcelRange = ((Excel.Range)oSheet.Cells[27, 5]);
                                                oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                oexcelRange.Value2 = ds.Tables[0].Rows[i]["OFFICE_IS_IN"].ToString();

                                                oexcelRange = ((Excel.Range)oSheet.Cells[27, 12]);
                                                oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                oexcelRange.Value2 = ds.Tables[0].Rows[i]["BUSINESS_TYPE"].ToString();

                                                oexcelRange = ((Excel.Range)oSheet.Cells[28, 5]);
                                                oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                oexcelRange.Value2 = ds.Tables[0].Rows[i]["AFFILATION_POLITICAL_PARTY_SEEN"].ToString();

                                                oexcelRange = ((Excel.Range)oSheet.Cells[28, 11]);
                                                oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                oexcelRange.Value2 = ds.Tables[0].Rows[i]["EQUIPMENT_SIGHTED_IN_OFFICE"].ToString();

                                                oexcelRange = ((Excel.Range)oSheet.Cells[29, 5]);
                                                oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                oexcelRange.Value2 = ds.Tables[0].Rows[i]["BUSINESS_STOCK_SEEN"].ToString();

                                                oexcelRange = ((Excel.Range)oSheet.Cells[29, 12]);
                                                oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                oexcelRange.Value2 = ds.Tables[0].Rows[i]["STOCK_TYPE"].ToString();

                                                oexcelRange = ((Excel.Range)oSheet.Cells[30, 5]);
                                                oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                oexcelRange.Value2 = ds.Tables[0].Rows[i]["BUSINESS_ACTIVITY_SEEN"].ToString();

                                                oexcelRange = ((Excel.Range)oSheet.Cells[30, 12]);
                                                oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                oexcelRange.Value2 = ds.Tables[0].Rows[i]["PROOF_OF_VISIT_COLLECTED"].ToString();

                                                oexcelRange = ((Excel.Range)oSheet.Cells[31, 4]);
                                                oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                oexcelRange.Value2 = ds.Tables[0].Rows[i]["ROUTE_MAP_DRAWN"].ToString();

                                                oexcelRange = ((Excel.Range)oSheet.Cells[31, 9]);
                                                oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                oexcelRange.Value2 = ds.Tables[0].Rows[i]["IS_NEGATIVE_AREA"].ToString();

                                                oexcelRange = ((Excel.Range)oSheet.Cells[31, 12]);
                                                oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                oexcelRange.Value2 = ds.Tables[0].Rows[i]["IS_OCL"].ToString();

                                                oexcelRange = ((Excel.Range)oSheet.Cells[34, 3]);
                                                oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                oexcelRange.Value2 = ds.Tables[0].Rows[i]["TPC_DONE"].ToString();

                                                oexcelRange = ((Excel.Range)oSheet.Cells[34, 6]);
                                                oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                oexcelRange.Value2 = ds.Tables[0].Rows[i]["TPC_DETAILS"].ToString();

                                                oexcelRange = ((Excel.Range)oSheet.Cells[34, 13]);
                                                oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                oexcelRange.Value2 = ds.Tables[0].Rows[i]["ENTRY_PERMITTED"].ToString();

                                                oexcelRange = ((Excel.Range)oSheet.Cells[35, 6]);
                                                oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                oexcelRange.Value2 = ds.Tables[0].Rows[i]["ANY_OTHER_INFO_OBT"].ToString();

                                                oexcelRange = ((Excel.Range)oSheet.Cells[37, 6]);
                                                oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                oexcelRange.Value2 = ds.Tables[0].Rows[i]["TPC_NAME"].ToString();

                                                oexcelRange = ((Excel.Range)oSheet.Cells[38, 6]);
                                                oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                oexcelRange.Value2 = ds.Tables[0].Rows[i]["OFF_ADDRESS_YEARS"].ToString();

                                                oexcelRange = ((Excel.Range)oSheet.Cells[39, 6]);
                                                oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                oexcelRange.Value2 = ds.Tables[0].Rows[i]["BUSINESS_NATURE"].ToString();

                                                oexcelRange = ((Excel.Range)oSheet.Cells[39, 13]);
                                                oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                oexcelRange.Value2 = ds.Tables[0].Rows[i]["NO_OF_EMP_SIGHTED_IN_PERMISES"].ToString();

                                                oexcelRange = ((Excel.Range)oSheet.Cells[40, 4]);
                                                oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                oexcelRange.Value2 = ds.Tables[0].Rows[i]["FE_REMARK"].ToString();

                                                oexcelRange = ((Excel.Range)oSheet.Cells[43, 4]);
                                                oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                oexcelRange.Value2 = ds.Tables[0].Rows[i]["ADRESS_CONFIRMATION"].ToString();

                                                oexcelRange = ((Excel.Range)oSheet.Cells[43, 7]);
                                                oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                oexcelRange.Value2 = ds.Tables[0].Rows[i]["CONTACTABILITY"].ToString();

                                                oexcelRange = ((Excel.Range)oSheet.Cells[43, 11]);
                                                oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                oexcelRange.Value2 = ds.Tables[0].Rows[i]["CONFIRMATION_IF_APPLICANT_MET"].ToString();

                                                oexcelRange = ((Excel.Range)oSheet.Cells[44, 4]);
                                                oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                oexcelRange.Value2 = ds.Tables[0].Rows[i]["PROFILE"].ToString();

                                                oexcelRange = ((Excel.Range)oSheet.Cells[44, 7]);
                                                oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                oexcelRange.Value2 = ds.Tables[0].Rows[i]["REPUTATION"].ToString();
                                                
                                                oexcelRange = ((Excel.Range)oSheet.Cells[44, 11]);
                                                oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                oexcelRange.Value2 = ds.Tables[0].Rows[i]["DECLINED_CODE"].ToString();

                                                oexcelRange = ((Excel.Range)oSheet.Cells[45, 4]);
                                                oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                oexcelRange.Value2 = ds.Tables[0].Rows[i]["DECLINED_REASON"].ToString();

                                                oexcelRange = ((Excel.Range)oSheet.Cells[46, 4]);
                                                oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                oexcelRange.Value2 = ds.Tables[0].Rows[i]["OVERALL_ASSESMENT"].ToString();

                                                oexcelRange = ((Excel.Range)oSheet.Cells[47, 6]);
                                                oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                oexcelRange.Value2 = ds.Tables[0].Rows[i]["OVERALL_ASSESMENT_REASON"].ToString();
                                                //**
                                                if (ds1 != null)
                                                {
                                                    if (ds1.Tables[0].Rows.Count > 0)
                                                    {
                                                        oexcelRange = ((Excel.Range)oSheet.Cells[48, 4]);
                                                        oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                        oexcelRange.Value2 = ds1.Tables[0].Rows[0]["VERIFIER_ID"].ToString();

                                                        oexcelRange = ((Excel.Range)oSheet.Cells[48, 8]);
                                                        oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                        oexcelRange.Value2 = ds1.Tables[0].Rows[0]["FULLNAME"].ToString();

                                                        oexcelRange = ((Excel.Range)oSheet.Cells[49, 4]);
                                                        oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                        oexcelRange.Value2 = ds1.Tables[0].Rows[0]["ATTEMPT_DATE_TIME"].ToString();
                                                    }
                                                }
                                                oexcelRange = ((Excel.Range)oSheet.Cells[48, 12]);
                                                oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                oexcelRange.Value2 = ds.Tables[0].Rows[i]["FULLNAME"].ToString();

                                                //oexcelRange = ((Excel.Range)oSheet.Cells[49, 4]);
                                                //oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                //oexcelRange.Value2 = ds.Tables[0].Rows[i]["CASE_ID"].ToString();

                                                oexcelRange = ((Excel.Range)oSheet.Cells[49, 12]);
                                                oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                oexcelRange.Value2 = "";//ds.Tables[0].Rows[i]["CASE_ID"].ToString();
                                                //SUMMARY
                                                switch (ds.Tables[0].Rows[i]["CASE_STATUS_ID"].ToString())
                                                {
                                                    case "1":
                                                        oexcelRange = ((Excel.Range)oSheet1.Cells[35, 6]);
                                                        oexcelRange.HorizontalAlignment = HorizontalAlign.Center;
                                                        oexcelRange.BorderAround(LineStyle.SingleLine, XlBorderWeight.xlMedium, XlColorIndex.xlColorIndexAutomatic, oMissing);
                                                        oexcelRange.Hyperlinks.Add(oexcelRange, oBook.FullName, "'" + oSheet.Name + "'" + "!A1", oMissing, "");
                                                        oexcelRange.Font.Bold = true;
                                                        oexcelRange.Font.Size = 11;
                                                        oexcelRange.Value2 = "X";
                                                        break;
                                                    case "2":
                                                        oexcelRange = ((Excel.Range)oSheet1.Cells[37, 6]);
                                                        oexcelRange.HorizontalAlignment = HorizontalAlign.Center;
                                                        oexcelRange.BorderAround(LineStyle.SingleLine, XlBorderWeight.xlMedium, XlColorIndex.xlColorIndexAutomatic, oMissing);
                                                        oexcelRange.Hyperlinks.Add(oexcelRange, oBook.FullName, "'" + oSheet.Name + "'" + "!A1", oMissing, "");
                                                        oexcelRange.Font.Bold = true;
                                                        oexcelRange.Font.Size = 11;
                                                        oexcelRange.Value2 = "X";

                                                        break;
                                                    case "3":
                                                        oexcelRange = ((Excel.Range)oSheet1.Cells[39, 6]);
                                                        oexcelRange.HorizontalAlignment = HorizontalAlign.Center;
                                                        oexcelRange.BorderAround(LineStyle.SingleLine, XlBorderWeight.xlMedium, XlColorIndex.xlColorIndexAutomatic, oMissing);
                                                        oexcelRange.Hyperlinks.Add(oexcelRange, oBook.FullName, "'" + oSheet.Name + "'" + "!A1", oMissing, "");
                                                        oexcelRange.Font.Bold = true;
                                                        oexcelRange.Font.Size = 11;
                                                        oexcelRange.Value2 = "X";
                                                        break;
                                                    default:
                                                        break;

                                                }
                                                break;
                                            case 3:                                                
                                                //RVT
                                                oSheet = (Excel._Worksheet)oBook.Worksheets["RTV"];
                                                oSheet.Visible = Excel.XlSheetVisibility.xlSheetVisible;
                                                oSheet.Unprotect(oMissing);

                                                oexcelRange = ((Excel.Range)oSheet.Cells[5, 5]);
                                                oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                oexcelRange.Value2 = ds.Tables[0].Rows[i]["APPLICANT_NAME"].ToString();

                                                oexcelRange = ((Excel.Range)oSheet.Cells[6, 4]);
                                                oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                oexcelRange.Value2 = ds.Tables[0].Rows[i]["REF_NO"].ToString();

                                                oexcelRange = ((Excel.Range)oSheet.Cells[6, 8]);
                                                oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                oexcelRange.Value2 = ds.Tables[0].Rows[i]["CASE_REC_DATETIME"].ToString();

                                                oexcelRange = ((Excel.Range)oSheet.Cells[6, 13]);
                                                oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                oexcelRange.Value2 = ds.Tables[0].Rows[i]["AGENCY_NAME"].ToString();

                                                oexcelRange = ((Excel.Range)oSheet.Cells[8, 4]);
                                                oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                oexcelRange.Value2 = ds.Tables[0].Rows[i]["CONTACTED_PERSON_NAME"].ToString();

                                                oexcelRange = ((Excel.Range)oSheet.Cells[8, 8]);
                                                oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                oexcelRange.Value2 = ds.Tables[0].Rows[i]["BUSINESS_CONTACT_NO"].ToString();

                                                oexcelRange = ((Excel.Range)oSheet.Cells[8, 11]);
                                                oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                oexcelRange.Value2 = "N/A";//ds.Tables[0].Rows[i]["PP_NORMAL"].ToString();

                                                oexcelRange = ((Excel.Range)oSheet.Cells[8, 13]);
                                                oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                oexcelRange.Value2 = ds.Tables[0].Rows[i]["TPC_DETAILS"].ToString();

                                                oexcelRange = ((Excel.Range)oSheet.Cells[9, 4]);
                                                oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                oexcelRange.Value2 = ds.Tables[0].Rows[i]["RES_ADD_LINE"].ToString();

                                                oexcelRange = ((Excel.Range)oSheet.Cells[10, 7]);
                                                oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                oexcelRange.Value2 = ds.Tables[0].Rows[i]["RES_PIN_CODE"].ToString();

                                                oexcelRange = ((Excel.Range)oSheet.Cells[10, 10]);
                                                oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                oexcelRange.Value2 = ds.Tables[0].Rows[i]["RES_LAND_MARK"].ToString();

                                                oexcelRange = ((Excel.Range)oSheet.Cells[11, 4]);
                                                oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                oexcelRange.Value2 = ds.Tables[0].Rows[i]["PERMANENT_ADDRESS"].ToString();

                                                oexcelRange = ((Excel.Range)oSheet.Cells[13, 4]);
                                                oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                oexcelRange.Value2 = ds.Tables[0].Rows[i]["PP_ADD_LOCATION"].ToString();

                                                oexcelRange = ((Excel.Range)oSheet.Cells[16, 4]);
                                                oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                oexcelRange.Value2 = ds.Tables[0].Rows[i]["TIME_AT_CURR_Y_M"].ToString(); //ds.Tables[0].Rows[i]["TIME_AT_CURR_RESIDANCE"].ToString();

                                                oexcelRange = ((Excel.Range)oSheet.Cells[16, 8]);
                                                oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                oexcelRange.Value2 = ds.Tables[0].Rows[i]["MAILING_ADDRESS"].ToString();

                                                oexcelRange = ((Excel.Range)oSheet.Cells[16, 12]);
                                                oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                oexcelRange.Value2 = ds.Tables[0].Rows[i]["RESIDANCE_IS"].ToString();

                                                oexcelRange = ((Excel.Range)oSheet.Cells[17, 4]);
                                                oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                oexcelRange.Value2 = ds.Tables[0].Rows[i]["RESI_COMOFF_OWNED"].ToString();

                                                oexcelRange = ((Excel.Range)oSheet.Cells[17, 11]);
                                                oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                oexcelRange.Value2 = ds.Tables[0].Rows[i]["BUSINESS_CONTACT_EXTN"].ToString();

                                                oexcelRange = ((Excel.Range)oSheet.Cells[18, 4]);
                                                oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                oexcelRange.Value2 = ds.Tables[0].Rows[i]["COMPANY_NAME"].ToString();

                                                oexcelRange = ((Excel.Range)oSheet.Cells[18, 11]);
                                                oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                oexcelRange.Value2 = ds.Tables[0].Rows[i]["DESIGNATION"].ToString();

                                                oexcelRange = ((Excel.Range)oSheet.Cells[19, 4]);
                                                oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                oexcelRange.Value2 = ds.Tables[0].Rows[i]["TIME_AT_CURRENT_EMPLOYMENT"].ToString();

                                                oexcelRange = ((Excel.Range)oSheet.Cells[19, 11]);
                                                oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                oexcelRange.Value2 = ds.Tables[0].Rows[i]["NOB"].ToString();

                                                oexcelRange = ((Excel.Range)oSheet.Cells[21, 4]);
                                                oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                oexcelRange.Value2 = ds.Tables[0].Rows[i]["NAME_OF_PERSON_CONTACTED"].ToString();// ds.Tables[0].Rows[i]["CONTACTED_PERSON_NAME"].ToString(); //or PERSON_CONTACTED

                                                oexcelRange = ((Excel.Range)oSheet.Cells[21, 10]);
                                                oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                oexcelRange.Value2 = ds.Tables[0].Rows[i]["REL_WITH_APPLICANT"].ToString();

                                                oexcelRange = ((Excel.Range)oSheet.Cells[22, 4]);
                                                oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                oexcelRange.Value2 = ds.Tables[0].Rows[i]["DOB_APPLICANT"].ToString();

                                                oexcelRange = ((Excel.Range)oSheet.Cells[22, 10]);
                                                oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                oexcelRange.Value2 = ds.Tables[0].Rows[i]["TIME_AT_CURR_RESIDANCE"].ToString();

                                                oexcelRange = ((Excel.Range)oSheet.Cells[23, 5]);
                                                oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                oexcelRange.Value2 = ds.Tables[0].Rows[i]["APPLICANT_IS_AVAILABLE_AT"].ToString();

                                                oexcelRange = ((Excel.Range)oSheet.Cells[23, 12]);
                                                oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                oexcelRange.Value2 = ds.Tables[0].Rows[i]["APPLICANT_AGE"].ToString();

                                                oexcelRange = ((Excel.Range)oSheet.Cells[24, 4]);
                                                oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                oexcelRange.Value2 = "N/A";//ds.Tables[0].Rows[i]["VERIFIER_COMMENTS"].ToString();

                                                oexcelRange = ((Excel.Range)oSheet.Cells[25, 4]);
                                                oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                oexcelRange.Value2 = ds.Tables[0].Rows[i]["NEW_DETAILS_OBTAINED"].ToString();
                                                if (ds1 != null)
                                                {
                                                    if (ds1.Tables[0].Rows.Count > 0)
                                                    {
                                                        for (int j = 0; j < ds1.Tables[0].Rows.Count; j++)
                                                        {
                                                            switch (j)
                                                            {
                                                                case 1:
                                                                    if (ds1.Tables[0].Rows[j]["ATTEMPT_DATE_TIME"].ToString() != "")
                                                                    {
                                                                        oexcelRange = ((Excel.Range)oSheet.Cells[28, 4]);
                                                                        oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                                        oexcelRange.Value2 = Convert.ToDateTime(ds1.Tables[0].Rows[j]["ATTEMPT_DATE_TIME"]).ToString("dd-MMM-yyyy");

                                                                        oexcelRange = ((Excel.Range)oSheet.Cells[28, 6]);
                                                                        oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                                        oexcelRange.Value2 = Convert.ToDateTime(ds1.Tables[0].Rows[j]["ATTEMPT_DATE_TIME"]).ToString("hh:mm:ss");
                                                                    }
                                                                    oexcelRange = ((Excel.Range)oSheet.Cells[28, 8]);
                                                                    oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                                    oexcelRange.Value2 = ds1.Tables[0].Rows[j]["TELEPHONE_NO"].ToString();

                                                                    oexcelRange = ((Excel.Range)oSheet.Cells[28, 10]);
                                                                    oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                                    oexcelRange.Value2 = ds1.Tables[0].Rows[j]["REMARK"].ToString();
                                                                    break;
                                                                case 2:
                                                                    if (ds1.Tables[0].Rows[j]["ATTEMPT_DATE_TIME"].ToString() != "")
                                                                    {
                                                                        oexcelRange = ((Excel.Range)oSheet.Cells[29, 4]);
                                                                        oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                                        oexcelRange.Value2 = Convert.ToDateTime(ds1.Tables[0].Rows[j]["ATTEMPT_DATE_TIME"]).ToString("dd-MMM-yyyy");

                                                                        oexcelRange = ((Excel.Range)oSheet.Cells[29, 6]);
                                                                        oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                                        oexcelRange.Value2 = Convert.ToDateTime(ds1.Tables[0].Rows[j]["ATTEMPT_DATE_TIME"]).ToString("hh:mm:ss");
                                                                    }
                                                                    oexcelRange = ((Excel.Range)oSheet.Cells[29, 8]);
                                                                    oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                                    oexcelRange.Value2 = ds1.Tables[0].Rows[j]["TELEPHONE_NO"].ToString();

                                                                    oexcelRange = ((Excel.Range)oSheet.Cells[29, 10]);
                                                                    oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                                    oexcelRange.Value2 = ds1.Tables[0].Rows[j]["REMARK"].ToString();
                                                                    break;
                                                                case 3:
                                                                    if (ds1.Tables[0].Rows[j]["ATTEMPT_DATE_TIME"].ToString() != "")
                                                                    {
                                                                        oexcelRange = ((Excel.Range)oSheet.Cells[30, 4]);
                                                                        oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                                        oexcelRange.Value2 = Convert.ToDateTime(ds1.Tables[0].Rows[j]["ATTEMPT_DATE_TIME"]).ToString("dd-MMM-yyyy");

                                                                        oexcelRange = ((Excel.Range)oSheet.Cells[30, 6]);
                                                                        oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                                        oexcelRange.Value2 = Convert.ToDateTime(ds1.Tables[0].Rows[j]["ATTEMPT_DATE_TIME"]).ToString("hh:mm:ss");
                                                                    }
                                                                    oexcelRange = ((Excel.Range)oSheet.Cells[30, 8]);
                                                                    oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                                    oexcelRange.Value2 = ds1.Tables[0].Rows[j]["TELEPHONE_NO"].ToString();

                                                                    oexcelRange = ((Excel.Range)oSheet.Cells[30, 10]);
                                                                    oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                                    oexcelRange.Value2 = ds1.Tables[0].Rows[j]["REMARK"].ToString();
                                                                    break;
                                                                case 4:
                                                                    if (ds1.Tables[0].Rows[j]["ATTEMPT_DATE_TIME"].ToString() != "")
                                                                    {
                                                                        oexcelRange = ((Excel.Range)oSheet.Cells[31, 4]);
                                                                        oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                                        oexcelRange.Value2 = Convert.ToDateTime(ds1.Tables[0].Rows[j]["ATTEMPT_DATE_TIME"]).ToString("dd-MMM-yyyy");

                                                                        oexcelRange = ((Excel.Range)oSheet.Cells[31, 6]);
                                                                        oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                                        oexcelRange.Value2 = Convert.ToDateTime(ds1.Tables[0].Rows[j]["ATTEMPT_DATE_TIME"]).ToString("hh:mm:ss");
                                                                    }
                                                                    oexcelRange = ((Excel.Range)oSheet.Cells[31, 8]);
                                                                    oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                                    oexcelRange.Value2 = ds1.Tables[0].Rows[j]["TELEPHONE_NO"].ToString();

                                                                    oexcelRange = ((Excel.Range)oSheet.Cells[31, 10]);
                                                                    oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                                    oexcelRange.Value2 = ds1.Tables[0].Rows[j]["REMARK"].ToString();
                                                                    break;
                                                                case 5:
                                                                    if (ds1.Tables[0].Rows[j]["ATTEMPT_DATE_TIME"].ToString() != "")
                                                                    {
                                                                        oexcelRange = ((Excel.Range)oSheet.Cells[32, 4]);
                                                                        oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                                        oexcelRange.Value2 = Convert.ToDateTime(ds1.Tables[0].Rows[j]["ATTEMPT_DATE_TIME"]).ToString("dd-MMM-yyyy");

                                                                        oexcelRange = ((Excel.Range)oSheet.Cells[32, 6]);
                                                                        oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                                        oexcelRange.Value2 = Convert.ToDateTime(ds1.Tables[0].Rows[j]["ATTEMPT_DATE_TIME"]).ToString("hh:mm:ss");
                                                                    }
                                                                    oexcelRange = ((Excel.Range)oSheet.Cells[32, 8]);
                                                                    oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                                    oexcelRange.Value2 = ds1.Tables[0].Rows[j]["TELEPHONE_NO"].ToString();

                                                                    oexcelRange = ((Excel.Range)oSheet.Cells[32, 10]);
                                                                    oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                                    oexcelRange.Value2 = ds1.Tables[0].Rows[j]["REMARK"].ToString();
                                                                    break;
                                                            }
                                                        }
                                                        oexcelRange = ((Excel.Range)oSheet.Cells[41, 4]);
                                                        oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                        oexcelRange.Value2 = ds1.Tables[0].Rows[0]["VERIFIER_ID"].ToString();

                                                        oexcelRange = ((Excel.Range)oSheet.Cells[41, 8]);
                                                        oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                        oexcelRange.Value2 = ds1.Tables[0].Rows[0]["FULLNAME"].ToString();

                                                        oexcelRange = ((Excel.Range)oSheet.Cells[42, 4]);
                                                        oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                        oexcelRange.Value2 = ds1.Tables[0].Rows[0]["ATTEMPT_DATE_TIME"].ToString();
                                                    }
                                                }
                                                ds1.Clear();
                                                oexcelRange = ((Excel.Range)oSheet.Cells[33, 5]);
                                                oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                oexcelRange.Value2 = ds.Tables[0].Rows[i]["ANY_INFO"].ToString();

                                                oexcelRange = ((Excel.Range)oSheet.Cells[36, 4]);
                                                oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                oexcelRange.Value2 = ds.Tables[0].Rows[i]["ADRESS_CONFIRMATION"].ToString();

                                                oexcelRange = ((Excel.Range)oSheet.Cells[36, 7]);
                                                oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                oexcelRange.Value2 = ds.Tables[0].Rows[i]["CONTACTABILITY"].ToString();

                                                oexcelRange = ((Excel.Range)oSheet.Cells[36, 11]);
                                                oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                oexcelRange.Value2 = ds.Tables[0].Rows[i]["CONFIRMATION_IF_APPLICANT_MET"].ToString();

                                                oexcelRange = ((Excel.Range)oSheet.Cells[37, 4]);
                                                oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                oexcelRange.Value2 = ds.Tables[0].Rows[i]["PROFILE"].ToString();

                                                oexcelRange = ((Excel.Range)oSheet.Cells[37, 7]);
                                                oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                oexcelRange.Value2 = ds.Tables[0].Rows[i]["REPUTATION"].ToString();
                                                
                                                oexcelRange = ((Excel.Range)oSheet.Cells[37, 11]);
                                                oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                oexcelRange.Value2 = ds.Tables[0].Rows[i]["DECLINED_CODE"].ToString();

                                                oexcelRange = ((Excel.Range)oSheet.Cells[38, 4]);
                                                oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                oexcelRange.Value2 = ds.Tables[0].Rows[i]["OVERALL_ASSESMENT"].ToString();

                                                oexcelRange = ((Excel.Range)oSheet.Cells[39, 4]);
                                                oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                oexcelRange.Value2 = ds.Tables[0].Rows[i]["OVERALL_ASSESMENT"].ToString();

                                                oexcelRange = ((Excel.Range)oSheet.Cells[40, 5]);
                                                oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                oexcelRange.Value2 = ds.Tables[0].Rows[i]["OVERALL_ASSESMENT_REASON"].ToString();

                                                //oexcelRange = ((Excel.Range)oSheet.Cells[41, 4]);
                                                //oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                //oexcelRange.Value2 = ds.Tables[0].Rows[i]["CASE_ID"].ToString();

                                                //oexcelRange = ((Excel.Range)oSheet.Cells[41, 8]);
                                                //oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                //oexcelRange.Value2 = ds.Tables[0].Rows[i]["CASE_ID"].ToString();
                                               
                                                oexcelRange = ((Excel.Range)oSheet.Cells[41, 11]);
                                                oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                oexcelRange.Value2 = ds.Tables[0].Rows[i]["FULLNAME"].ToString();

                                                //oexcelRange = ((Excel.Range)oSheet.Cells[42, 4]);
                                                //oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                //oexcelRange.Value2 = ds.Tables[0].Rows[i]["CASE_ID"].ToString();

                                                oexcelRange = ((Excel.Range)oSheet.Cells[42, 11]);
                                                oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                oexcelRange.Value2 = "";// ds.Tables[0].Rows[i]["CASE_ID"].ToString();
                                                //SUMMARY
                                                switch (ds.Tables[0].Rows[i]["CASE_STATUS_ID"].ToString())
                                                {
                                                    case "1":
                                                        oexcelRange = ((Excel.Range)oSheet1.Cells[42, 6]);
                                                        oexcelRange.HorizontalAlignment = HorizontalAlign.Center;
                                                        oexcelRange.BorderAround(LineStyle.SingleLine, XlBorderWeight.xlMedium, XlColorIndex.xlColorIndexAutomatic, oMissing);
                                                        oexcelRange.Hyperlinks.Add(oexcelRange, oBook.FullName, "'" + oSheet.Name + "'" + "!A1", oMissing, "");
                                                        oexcelRange.Font.Bold = true;
                                                        oexcelRange.Font.Size = 11;
                                                        oexcelRange.Value2 = "X";
                                                        break;
                                                    case "2":
                                                        oexcelRange = ((Excel.Range)oSheet1.Cells[44, 6]);
                                                        oexcelRange.HorizontalAlignment = HorizontalAlign.Center;
                                                        oexcelRange.BorderAround(LineStyle.SingleLine, XlBorderWeight.xlMedium, XlColorIndex.xlColorIndexAutomatic, oMissing);
                                                        oexcelRange.Hyperlinks.Add(oexcelRange, oBook.FullName, "'" + oSheet.Name + "'" + "!A1", oMissing, "");
                                                        oexcelRange.Font.Bold = true;
                                                        oexcelRange.Font.Size = 11;
                                                        oexcelRange.Value2 = "X";

                                                        break;
                                                    case "3":
                                                        oexcelRange = ((Excel.Range)oSheet1.Cells[46, 6]);                                                        
                                                        oexcelRange.HorizontalAlignment = HorizontalAlign.Center;
                                                        oexcelRange.BorderAround(LineStyle.SingleLine, XlBorderWeight.xlMedium, XlColorIndex.xlColorIndexAutomatic, oMissing);
                                                        oexcelRange.Hyperlinks.Add(oexcelRange, oBook.FullName, "'" + oSheet.Name + "'" + "!A1", oMissing, "");
                                                        oexcelRange.Font.Bold = true;
                                                        oexcelRange.Font.Size = 11;
                                                        oexcelRange.Value2 = "X";
                                                        break;
                                                    default:
                                                        break;

                                                }
                                                break;
                                            case 4:                                               
                                                //BVT
                                                oSheet = (Excel._Worksheet)oBook.Worksheets["BTV"];
                                                oSheet.Visible = Excel.XlSheetVisibility.xlSheetVisible;
                                                oSheet.Unprotect(oMissing);

                                                oexcelRange = ((Excel.Range)oSheet.Cells[5, 5]);
                                                oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                oexcelRange.Value2 = ds.Tables[0].Rows[i]["APPLICANT_NAME"].ToString();

                                                oexcelRange = ((Excel.Range)oSheet.Cells[6, 4]);
                                                oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                oexcelRange.Value2 = ds.Tables[0].Rows[i]["REF_NO"].ToString();

                                                oexcelRange = ((Excel.Range)oSheet.Cells[6, 8]);
                                                oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                oexcelRange.Value2 = ds.Tables[0].Rows[i]["CASE_REC_DATETIME"].ToString();

                                                oexcelRange = ((Excel.Range)oSheet.Cells[6, 13]);
                                                oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                oexcelRange.Value2 = ds.Tables[0].Rows[i]["AGENCY_NAME"].ToString();

                                                oexcelRange = ((Excel.Range)oSheet.Cells[8, 4]);
                                                oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                oexcelRange.Value2 = ds.Tables[0].Rows[i]["BUSINESS_CONTACT_NO"].ToString();

                                                oexcelRange = ((Excel.Range)oSheet.Cells[8, 10]);
                                                oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                oexcelRange.Value2 = ds.Tables[0].Rows[i]["BUSINESS_CONTACT_EXTN"].ToString();// ds.Tables[0].Rows[i]["OFFICE_EXT"].ToString(); //BUSINESS_CONTACT_EXTN

                                                oexcelRange = ((Excel.Range)oSheet.Cells[9, 4]);
                                                oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                oexcelRange.Value2 = ds.Tables[0].Rows[i]["OFF_ADD_LINE"].ToString();

                                                oexcelRange = ((Excel.Range)oSheet.Cells[12, 4]);
                                                oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                oexcelRange.Value2 = ds.Tables[0].Rows[i]["DOB_APPLICANT"].ToString();

                                                oexcelRange = ((Excel.Range)oSheet.Cells[12, 8]);
                                                oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                oexcelRange.Value2 = ds.Tables[0].Rows[i]["QUALIFICATION"].ToString();

                                                oexcelRange = ((Excel.Range)oSheet.Cells[12, 12]);
                                                oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                oexcelRange.Value2 = ds.Tables[0].Rows[i]["DESIGNATION"].ToString();

                                                oexcelRange = ((Excel.Range)oSheet.Cells[13, 4]);
                                                oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                oexcelRange.Value2 = ds.Tables[0].Rows[i]["TIME_AT_CURRENT_EMPL_Y_M"].ToString();//ds.Tables[0].Rows[i]["TIME_AT_CURRENT_EMPLOYMENT"].ToString();

                                                oexcelRange = ((Excel.Range)oSheet.Cells[13, 10]);
                                                oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                oexcelRange.Value2 = ds.Tables[0].Rows[i]["INCOME_DOC_SUBMITTED_WITH_APLICATION"].ToString();

                                                oexcelRange = ((Excel.Range)oSheet.Cells[14, 4]);
                                                oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                oexcelRange.Value2 = ds.Tables[0].Rows[i]["RESI_COMOFF_OWNED"].ToString();

                                                oexcelRange = ((Excel.Range)oSheet.Cells[14, 10]);
                                                oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                oexcelRange.Value2 = ds.Tables[0].Rows[i]["TIME_AT_CURR_Y_M"].ToString();//*

                                                oexcelRange = ((Excel.Range)oSheet.Cells[15, 4]);
                                                oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                oexcelRange.Value2 = ds.Tables[0].Rows[i]["RES_PHONE"].ToString();

                                                oexcelRange = ((Excel.Range)oSheet.Cells[15, 10]);
                                                oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                oexcelRange.Value2 = ds.Tables[0].Rows[i]["RESIDANCE_IS"].ToString();

                                                oexcelRange = ((Excel.Range)oSheet.Cells[16, 4]);
                                                oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                oexcelRange.Value2 = ds.Tables[0].Rows[i]["MAILING_ADDRESS"].ToString();

                                                oexcelRange = ((Excel.Range)oSheet.Cells[18, 5]);
                                                oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                oexcelRange.Value2 = ds.Tables[0].Rows[i]["CONTACTED_PERSON_NAME"].ToString();

                                                oexcelRange = ((Excel.Range)oSheet.Cells[18, 8]);
                                                oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                oexcelRange.Value2 = ds.Tables[0].Rows[i]["OTHERS_DESIGNATION"].ToString();

                                                oexcelRange = ((Excel.Range)oSheet.Cells[18, 12]);
                                                oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                oexcelRange.Value2 = ds.Tables[0].Rows[i]["NATURE_BUSINESS_RESI_CUM_OFF"].ToString();// ds.Tables[0].Rows[i]["BUSINESS_NATURE"].ToString(); ds.Tables[0].Rows[i]["NATURE_BUSINESS_RESI_CUM_OFF"].ToString();

                                                oexcelRange = ((Excel.Range)oSheet.Cells[19, 5]);
                                                oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                oexcelRange.Value2 = ds.Tables[0].Rows[i]["DESIGNATION"].ToString();

                                                oexcelRange = ((Excel.Range)oSheet.Cells[19, 10]);
                                                oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                oexcelRange.Value2 = ds.Tables[0].Rows[i]["TIME_AT_CURRENT_EMPLOYMENT"].ToString();

                                                oexcelRange = ((Excel.Range)oSheet.Cells[20, 5]);
                                                oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                oexcelRange.Value2 = ds.Tables[0].Rows[i]["APPLICANT_IS_AVAILABLE_AT"].ToString();

                                                oexcelRange = ((Excel.Range)oSheet.Cells[20, 10]);
                                                oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                oexcelRange.Value2 = ds.Tables[0].Rows[i]["APPLICANT_AGE"].ToString();

                                                oexcelRange = ((Excel.Range)oSheet.Cells[21, 5]);
                                                oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                oexcelRange.Value2 = ds.Tables[0].Rows[i]["TELE_COMMENTS"].ToString();

                                                oexcelRange = ((Excel.Range)oSheet.Cells[22, 5]);
                                                oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                oexcelRange.Value2 = ds.Tables[0].Rows[i]["NEW_DETAILS_OBTAINED"].ToString();

                                                if (ds1 != null)
                                                {
                                                    if (ds1.Tables[0].Rows.Count > 0)
                                                    {
                                                        for (int j = 0; j < ds1.Tables[0].Rows.Count; j++)
                                                        {
                                                            switch (j)
                                                            {
                                                                case 1:
                                                                    if (ds1.Tables[0].Rows[j]["ATTEMPT_DATE_TIME"].ToString() != "")
                                                                    {
                                                                        oexcelRange = ((Excel.Range)oSheet.Cells[25, 4]);
                                                                        oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                                        oexcelRange.Value2 = Convert.ToDateTime(ds1.Tables[0].Rows[j]["ATTEMPT_DATE_TIME"]).ToString("dd-MMM-yyyy");

                                                                        oexcelRange = ((Excel.Range)oSheet.Cells[25, 6]);
                                                                        oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                                        oexcelRange.Value2 = Convert.ToDateTime(ds1.Tables[0].Rows[j]["ATTEMPT_DATE_TIME"]).ToString("hh:mm:ss");
                                                                    }
                                                                    oexcelRange = ((Excel.Range)oSheet.Cells[25, 8]);
                                                                    oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                                    oexcelRange.Value2 = ds1.Tables[0].Rows[j]["TELEPHONE_NO"].ToString();

                                                                    oexcelRange = ((Excel.Range)oSheet.Cells[25, 10]);
                                                                    oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                                    oexcelRange.Value2 = ds1.Tables[0].Rows[j]["REMARK"].ToString();
                                                                    break;
                                                                case 2:
                                                                    if (ds1.Tables[0].Rows[j]["ATTEMPT_DATE_TIME"].ToString() != "")
                                                                    {
                                                                        oexcelRange = ((Excel.Range)oSheet.Cells[26, 4]);
                                                                        oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                                        oexcelRange.Value2 = Convert.ToDateTime(ds1.Tables[0].Rows[j]["ATTEMPT_DATE_TIME"]).ToString("dd-MMM-yyyy");

                                                                        oexcelRange = ((Excel.Range)oSheet.Cells[26, 6]);
                                                                        oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                                        oexcelRange.Value2 = Convert.ToDateTime(ds1.Tables[0].Rows[j]["ATTEMPT_DATE_TIME"]).ToString("hh:mm:ss");
                                                                    }
                                                                    oexcelRange = ((Excel.Range)oSheet.Cells[26, 8]);
                                                                    oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                                    oexcelRange.Value2 = ds1.Tables[0].Rows[j]["TELEPHONE_NO"].ToString();

                                                                    oexcelRange = ((Excel.Range)oSheet.Cells[26, 10]);
                                                                    oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                                    oexcelRange.Value2 = ds1.Tables[0].Rows[j]["REMARK"].ToString();
                                                                    break;
                                                                case 3:
                                                                    if (ds1.Tables[0].Rows[j]["ATTEMPT_DATE_TIME"].ToString() != "")
                                                                    {
                                                                        oexcelRange = ((Excel.Range)oSheet.Cells[27, 4]);
                                                                        oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                                        oexcelRange.Value2 = Convert.ToDateTime(ds1.Tables[0].Rows[j]["ATTEMPT_DATE_TIME"]).ToString("dd-MMM-yyyy");

                                                                        oexcelRange = ((Excel.Range)oSheet.Cells[27, 6]);
                                                                        oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                                        oexcelRange.Value2 = Convert.ToDateTime(ds1.Tables[0].Rows[j]["ATTEMPT_DATE_TIME"]).ToString("hh:mm:ss");
                                                                    }
                                                                    oexcelRange = ((Excel.Range)oSheet.Cells[27, 8]);
                                                                    oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                                    oexcelRange.Value2 = ds1.Tables[0].Rows[j]["TELEPHONE_NO"].ToString();

                                                                    oexcelRange = ((Excel.Range)oSheet.Cells[27, 10]);
                                                                    oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                                    oexcelRange.Value2 = ds1.Tables[0].Rows[j]["REMARK"].ToString();
                                                                    break;
                                                                case 4:
                                                                    if (ds1.Tables[0].Rows[j]["ATTEMPT_DATE_TIME"].ToString() != "")
                                                                    {
                                                                        oexcelRange = ((Excel.Range)oSheet.Cells[28, 4]);
                                                                        oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                                        oexcelRange.Value2 = Convert.ToDateTime(ds1.Tables[0].Rows[j]["ATTEMPT_DATE_TIME"]).ToString("dd-MMM-yyyy");

                                                                        oexcelRange = ((Excel.Range)oSheet.Cells[28, 6]);
                                                                        oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                                        oexcelRange.Value2 = Convert.ToDateTime(ds1.Tables[0].Rows[j]["ATTEMPT_DATE_TIME"]).ToString("hh:mm:ss");
                                                                    }
                                                                    oexcelRange = ((Excel.Range)oSheet.Cells[28, 8]);
                                                                    oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                                    oexcelRange.Value2 = ds1.Tables[0].Rows[j]["TELEPHONE_NO"].ToString();

                                                                    oexcelRange = ((Excel.Range)oSheet.Cells[28, 10]);
                                                                    oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                                    oexcelRange.Value2 = ds1.Tables[0].Rows[j]["REMARK"].ToString();
                                                                    break;
                                                                case 5:
                                                                    if (ds1.Tables[0].Rows[j]["ATTEMPT_DATE_TIME"].ToString() != "")
                                                                    {
                                                                        oexcelRange = ((Excel.Range)oSheet.Cells[29, 4]);
                                                                        oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                                        oexcelRange.Value2 = Convert.ToDateTime(ds1.Tables[0].Rows[j]["ATTEMPT_DATE_TIME"]).ToString("dd-MMM-yyyy");

                                                                        oexcelRange = ((Excel.Range)oSheet.Cells[29, 6]);
                                                                        oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                                        oexcelRange.Value2 = Convert.ToDateTime(ds1.Tables[0].Rows[j]["ATTEMPT_DATE_TIME"]).ToString("hh:mm:ss");
                                                                    }
                                                                    oexcelRange = ((Excel.Range)oSheet.Cells[29, 8]);
                                                                    oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                                    oexcelRange.Value2 = ds1.Tables[0].Rows[j]["TELEPHONE_NO"].ToString();

                                                                    oexcelRange = ((Excel.Range)oSheet.Cells[29, 10]);
                                                                    oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                                    oexcelRange.Value2 = ds1.Tables[0].Rows[j]["REMARK"].ToString();
                                                                    break;
                                                            }
                                                        }
                                                        //**
                                                        oexcelRange = ((Excel.Range)oSheet.Cells[38, 4]);
                                                        oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                        oexcelRange.Value2 = ds1.Tables[0].Rows[0]["VERIFIER_ID"].ToString();

                                                        oexcelRange = ((Excel.Range)oSheet.Cells[38, 8]);
                                                        oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                        oexcelRange.Value2 = ds1.Tables[0].Rows[0]["FULLNAME"].ToString();

                                                        oexcelRange = ((Excel.Range)oSheet.Cells[39, 4]);
                                                        oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                        oexcelRange.Value2 = ds1.Tables[0].Rows[0]["ATTEMPT_DATE_TIME"].ToString();
                                                    }
                                                }
                                                ds1.Clear();

                                                oexcelRange = ((Excel.Range)oSheet.Cells[33, 4]);
                                                oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                oexcelRange.Value2 = ds.Tables[0].Rows[i]["ADRESS_CONFIRMATION"].ToString();//*

                                                oexcelRange = ((Excel.Range)oSheet.Cells[33, 8]);
                                                oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                oexcelRange.Value2 = ds.Tables[0].Rows[i]["CONTACTABILITY"].ToString();

                                                oexcelRange = ((Excel.Range)oSheet.Cells[33, 13]);
                                                oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                oexcelRange.Value2 = ds.Tables[0].Rows[i]["CONFIRMATION_IF_APPLICANT_MET"].ToString();

                                                oexcelRange = ((Excel.Range)oSheet.Cells[34, 4]);
                                                oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                oexcelRange.Value2 = ds.Tables[0].Rows[i]["PROFILE"].ToString();

                                                oexcelRange = ((Excel.Range)oSheet.Cells[34, 7]);
                                                oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                oexcelRange.Value2 = ds.Tables[0].Rows[i]["REPUTATION"].ToString();
                                                
                                                oexcelRange = ((Excel.Range)oSheet.Cells[34, 11]);
                                                oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                oexcelRange.Value2 = ds.Tables[0].Rows[i]["DECLINED_CODE"].ToString();

                                                oexcelRange = ((Excel.Range)oSheet.Cells[35, 4]);
                                                oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                oexcelRange.Value2 = ds.Tables[0].Rows[i]["DECLINED_REASON"].ToString();

                                                oexcelRange = ((Excel.Range)oSheet.Cells[36, 4]);
                                                oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                oexcelRange.Value2 = ds.Tables[0].Rows[i]["OVERALL_ASSESMENT"].ToString();

                                                oexcelRange = ((Excel.Range)oSheet.Cells[37, 5]);
                                                oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                oexcelRange.Value2 = ds.Tables[0].Rows[i]["OVERALL_ASSESMENT_REASON"].ToString();

                                                //oexcelRange = ((Excel.Range)oSheet.Cells[38, 4]);
                                                //oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                //oexcelRange.Value2 = ds.Tables[0].Rows[i]["CASE_ID"].ToString();

                                                //oexcelRange = ((Excel.Range)oSheet.Cells[38, 8]);
                                                //oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                //oexcelRange.Value2 = ds.Tables[0].Rows[i]["CASE_ID"].ToString();
                                                

                                                oexcelRange = ((Excel.Range)oSheet.Cells[38, 11]);
                                                oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                oexcelRange.Value2 = ds.Tables[0].Rows[i]["FULLNAME"].ToString();

                                                //oexcelRange = ((Excel.Range)oSheet.Cells[39, 4]);
                                                //oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                //oexcelRange.Value2 = ds.Tables[0].Rows[i]["CASE_ID"].ToString();

                                                oexcelRange = ((Excel.Range)oSheet.Cells[39, 11]);
                                                oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                oexcelRange.Value2 = "";// ds.Tables[0].Rows[i]["CASE_ID"].ToString();
                                                //SUMMARY
                                                switch (ds.Tables[0].Rows[i]["CASE_STATUS_ID"].ToString())
                                                {
                                                    case "1":
                                                        oexcelRange = ((Excel.Range)oSheet1.Cells[49, 6]);
                                                        oexcelRange.HorizontalAlignment = HorizontalAlign.Center;
                                                        oexcelRange.BorderAround(LineStyle.SingleLine, XlBorderWeight.xlMedium, XlColorIndex.xlColorIndexAutomatic, oMissing);
                                                        oexcelRange.Hyperlinks.Add(oexcelRange, oBook.FullName, "'" + oSheet.Name + "'" + "!A1", oMissing, "");
                                                        oexcelRange.Font.Bold = true;
                                                        oexcelRange.Font.Size = 11;
                                                        oexcelRange.Value2 = "X";
                                                        break;
                                                    case "2":
                                                        oexcelRange = ((Excel.Range)oSheet1.Cells[51, 6]);
                                                        oexcelRange.HorizontalAlignment = HorizontalAlign.Center;
                                                        oexcelRange.BorderAround(LineStyle.SingleLine, XlBorderWeight.xlMedium, XlColorIndex.xlColorIndexAutomatic, oMissing);
                                                        oexcelRange.Hyperlinks.Add(oexcelRange, oBook.FullName, "'" + oSheet.Name + "'" + "!A1", oMissing, "");
                                                        oexcelRange.Font.Bold = true;
                                                        oexcelRange.Font.Size = 11;
                                                        oexcelRange.Value2 = "X";

                                                        break;
                                                    case "3":
                                                        oexcelRange = ((Excel.Range)oSheet1.Cells[53, 6]);
                                                        oexcelRange.HorizontalAlignment = HorizontalAlign.Center;
                                                        oexcelRange.BorderAround(LineStyle.SingleLine, XlBorderWeight.xlMedium, XlColorIndex.xlColorIndexAutomatic, oMissing);
                                                        oexcelRange.Hyperlinks.Add(oexcelRange, oBook.FullName, "'" + oSheet.Name + "'" + "!A1", oMissing, "");
                                                        oexcelRange.Font.Bold = true;
                                                        oexcelRange.Font.Size = 11;
                                                        oexcelRange.Value2 = "X";
                                                        break;
                                                    default:
                                                        break;

                                                }
                                                break;
                                            default:
                                                //SUMMARY
                                                //oSheet = (Excel._Worksheet)oBook.Worksheets["Summary"];
                                                //oSheet.Visible = Excel.XlSheetVisibility.xlSheetVisible;
                                                //oSheet.Unprotect(oMissing);
                                                //switch (Convert.ToInt16(strTypeID))
                                                //{
                                                //    case 1:
                                                //        break;
                                                //    case 2:
                                                //        break;
                                                //    case 3:
                                                //        break;
                                                //    case 4:
                                                //        break;
                                                //}
                                                break;
                                        }
                                    }
                                }
                            }
                            ds.Clear();
                            // saving excel sheet
                            if (strRefID != "")
                            {

                                if (!Directory.Exists(Server.MapPath("../../ExportToUTI/" + Session["UserName"].ToString())))
                                    Directory.CreateDirectory(Server.MapPath("../../ExportToUTI/" + Session["UserName"].ToString()));
                                String strFileName = Server.MapPath("../../ExportToUTI/" + Session["UserName"].ToString()) + "/" + strRefID + ".xls";
                                oBook.SaveAs(strFileName, oMissing, oMissing, oMissing, oMissing, oMissing, XlSaveAsAccessMode.xlNoChange, oMissing, oMissing, oMissing, oMissing, oMissing);
                            }
                                //clear all excel veriables
                            oSheet = null;                            
                            oBooks.Close();
                            oBooks = null;                           
                            oBook = null;
                            oExcelApp.Quit();
                            oExcelApp = null;
                        }

                        catch (Exception exp)
                        {
                            conn.Close();
                            throw new Exception(exp.Message);
                            // lblMsg.Text = exp.Message;
                        }
                   
                    }
                conn.Close();
            }
        }
        catch (Exception exp)
        {
            throw new Exception(exp.Message);
            //lblMsg.Text = exp.Message;
        }
    }

    */
    // by Ashish....

    //Added by hemangi kambli on 1-Aug-2007 for convering no of year, month(i.e.2.5) to -year-month(i.e. 2 Years 5 months)
    public string retYearMonth(string sField)
    {
        string sTmp = sField;
        string sYear = "";
        string sMonth = "";
        string sYrMth="";

        if (sTmp.Trim() != "")
        {
            string[] arrYearMth = sTmp.Split('.');
            if (arrYearMth.Length > 0)
            {
                sYear = arrYearMth[0].ToString();
                if (sYear == "1")
                    sYrMth = sYear + " Year ";
                else if (sYear == "")
                    sYrMth += "";  
                else
                    sYrMth = sYear + " Years ";
                
                if (arrYearMth.Length > 1)
                {
                    sMonth = arrYearMth[1].ToString();
                    if (sMonth == "1")
                        sYrMth += sMonth + " Month";
                    else if(sMonth=="")
                        sYrMth += "";  
                    else
                        sYrMth += sMonth + " Months";                    
                   
                }
                else
                    sYrMth +=  "";  

            }
            else
            {
                sYrMth = "";
            }
        }
        else
            sYrMth = "";

        return sYrMth;
    }

    public void GenerateExcelStandardFormat(String[] arrCaseID)
    {
               //declaring excel variables
                Excel.Application oExcelApp;
                Excel.Workbooks oBooks;
                Excel._Workbook oBook;
                Excel._Worksheet oSheet;
                Excel._Worksheet oSheet1;
                Excel.Range oexcelRange;
                object oMissing;
                //for getting connection string
                CCommon oCmn;
                try
                {
                    String strCentreID =  Session["CentreId"].ToString(); //"1011";"1011";
                    String strClientID =  Session["ClientId"].ToString(); //"1013";"10111";
                    if (strCentreID != "" && strClientID != "")
                    {               
                        oCmn = new CCommon();
                        //dataset for main data
                        DataSet ds;
                        //dataset for attempt details
                        DataSet ds1;
                        OleDbConnection conn = new OleDbConnection(oCmn.ConnectionString);
                        String strRefID = "";
                        String strExcel = Server.MapPath("excelstanderoutput.xls");

                        string strMapPath = Server.MapPath("../../ExportToUTI/CC/") + Session["UserName"].ToString() + "/";
                        string strDateTime = DateTime.Now.ToString("ddMMyyyyhhmm");

                        if (!Directory.Exists(strMapPath + strDateTime))
                            Directory.CreateDirectory(strMapPath + strDateTime);

                        foreach (String strCaseID in arrCaseID)
                        {
                            ArrayList arrVerType = new ArrayList();
                            String strTypeID = "";
                                try
                                {
                                    //getting main data
                                    conn.Open();
                                    String strSQL = "SELECT * FROM CPV_CC_CASE_OUTPUT_VW " +
                                             "WHERE (CENTRE_ID = '" + strCentreID + "') AND (CLIENT_ID = '" + strClientID + "') AND (CASE_ID = '" + strCaseID + "')";
                                    ds = OleDbHelper.ExecuteDataset(conn, CommandType.Text, strSQL);
                                    conn.Close();
                                    //excel setting

                                    if(ds.Tables[0].Rows.Count>0)
                                        strRefID = ds.Tables[0].Rows[0]["REF_NO"].ToString();

                                    //if (!Directory.Exists(Server.MapPath("../../ExportToUTI/CC/" + Session["UserName"].ToString()) + "/" + DateTime.Now.ToString("ddMMyyyyhhmm")))
                                    //    Directory.CreateDirectory(Server.MapPath("../../ExportToUTI/CC/" + Session["UserName"].ToString()) + "/" + DateTime.Now.ToString("ddMMyyyyhhmm"));
                                    String strFileName = strMapPath + strDateTime + "/" + strRefID + ".xls";
                                                            
                                    if (File.Exists(strFileName))
                                        File.Delete(strFileName);

                                    File.Copy(strExcel, strFileName);

                                    oMissing = System.Reflection.Missing.Value;
                                    oExcelApp = new Excel.Application();
                                    oExcelApp.Visible = false;
                                    oBooks = oExcelApp.Workbooks;
                                    oMissing = System.Reflection.Missing.Value;
                                    oExcelApp.Visible = false;
                                    oBook = oBooks._Open(strFileName, oMissing, oMissing, oMissing, oMissing, oMissing, oMissing, oMissing, oMissing, oMissing, oMissing, oMissing, oMissing);
                                    oExcelApp.Visible = false;
                                    oExcelApp.UserControl = false;

                                    //getting data from dataset to insert it in excel cells
                                    if (ds != null)
                                    {
                                        if (ds.Tables[0].Rows.Count > 0)
                                        {
                                            // SUMMARY
                                            oSheet1 = (Excel._Worksheet)oBook.Worksheets["Summary"];
                                            oSheet1.Visible = Excel.XlSheetVisibility.xlSheetVisible;
                                            oSheet1.Unprotect(oMissing);

                                            oexcelRange = ((Excel.Range)oSheet1.Cells[6, 5]);
                                            oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                            oexcelRange.Value2 = ds.Tables[0].Rows[0]["APPLICANT_NAME"].ToString();

                                            oexcelRange = ((Excel.Range)oSheet1.Cells[6, 12]);
                                            oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                            oexcelRange.Value2 = ds.Tables[0].Rows[0]["CASE_REC_DATETIME"].ToString();

                                            oexcelRange = ((Excel.Range)oSheet1.Cells[7, 5]);
                                            oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                            oexcelRange.Value2 = ds.Tables[0].Rows[0]["REF_NO"].ToString();

                                            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                                            {
                                                strTypeID = ds.Tables[0].Rows[i]["VERIFICATION_TYPE_ID"].ToString();
                                                //assign ref id

                                                //getting attempt details 
                                                conn.Open();
                                                String strSQL1 = "";
                                                if (strTypeID == "1" || strTypeID == "2")
                                                {
                                                    strSQL1 = "SELECT VERIFIER_ID, ATTEMPT_DATE_TIME, FULLNAME FROM VERIFIER_LAST_ATTEMPT_VW INNER JOIN FE_VW ON VERIFIER_ID=EMP_ID " +
                                                              "WHERE CASE_ID='" + strCaseID + "' AND VERIFICATION_TYPE_ID='" + strTypeID + "'";
                                                }

                                                if (strTypeID == "3" || strTypeID == "4")
                                                {
                                                    //strSQL1 = "SELECT VERIFIER_ID, ATTEMPT_DATE_TIME, TELEPHONE_NO, REMARK, FULLNAME FROM CPV_CC_VERI_ATTEMPTS INNER JOIN TC_VW ON VERIFIER_ID=EMP_ID " +
                                                    //          "WHERE CASE_ID='" + strCaseID + "' AND VERIFICATION_TYPE_ID='" + strTypeID + "'";
                                                    strSQL1 = "SELECT VERIFIER_ID, ATTEMPT_DATE_TIME, TELEPHONE_NO, REMARK, FULLNAME FROM CPV_CC_VERI_ATTEMPTS LEFT OUTER JOIN TC_VW ON VERIFIER_ID=EMP_ID " +
                                                              "WHERE CASE_ID='" + strCaseID + "' AND VERIFICATION_TYPE_ID='" + strTypeID + "'";
                                                }
                                                if (strSQL1 != "")
                                                {
                                                    ds1 = OleDbHelper.ExecuteDataset(conn, CommandType.Text, strSQL1);
                                                    conn.Close();
                                                    
                                                    //filling excel according to verification type 
                                                    switch (Convert.ToInt16(strTypeID))
                                                    {
                                                        case 1:
                                                            //RV
                                                            arrVerType.Add("RV");
                                                            oSheet = (Excel._Worksheet)oBook.Worksheets["RV"];
                                                            oSheet.Visible = Excel.XlSheetVisibility.xlSheetVisible;
                                                            oSheet.Unprotect(oMissing);

                                                            oexcelRange = ((Excel.Range)oSheet.Cells[5, 5]);
                                                            oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                            oexcelRange.Value2 = ds.Tables[0].Rows[i]["APPLICANT_NAME"].ToString();

                                                            oexcelRange = ((Excel.Range)oSheet.Cells[6, 4]);
                                                            oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                            oexcelRange.Value2 = ds.Tables[0].Rows[i]["REF_NO"].ToString();

                                                            oexcelRange = ((Excel.Range)oSheet.Cells[6, 8]);
                                                            oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                            oexcelRange.Value2 = Convert.ToDateTime(ds.Tables[0].Rows[i]["CASE_REC_DATETIME"].ToString()).ToString("dd/MM/yyyy");

                                                            oexcelRange = ((Excel.Range)oSheet.Cells[6, 13]);
                                                            oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                            oexcelRange.Value2 = ds.Tables[0].Rows[i]["AGENCY_NAME"].ToString();

                                                            oexcelRange = ((Excel.Range)oSheet.Cells[7, 4]);
                                                            oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                            oexcelRange.Value2 = ds.Tables[0].Rows[i]["RES_ADD_LINE"].ToString();

                                                            oexcelRange = ((Excel.Range)oSheet.Cells[8, 7]);
                                                            oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                            oexcelRange.Value2 = ds.Tables[0].Rows[i]["RES_PIN_CODE"].ToString();

                                                            oexcelRange = ((Excel.Range)oSheet.Cells[8, 10]);
                                                            oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                            oexcelRange.Value2 = ds.Tables[0].Rows[i]["RES_LAND_MARK"].ToString();

                                                            oexcelRange = ((Excel.Range)oSheet.Cells[9, 4]);
                                                            oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                            oexcelRange.Value2 = ds.Tables[0].Rows[i]["RES_PHONE"].ToString();

                                                            oexcelRange = ((Excel.Range)oSheet.Cells[9, 8]);
                                                            oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                            oexcelRange.Value2 = ds.Tables[0].Rows[i]["PP_NORMAL"].ToString();

                                                            oexcelRange = ((Excel.Range)oSheet.Cells[9, 12]);
                                                            oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                            oexcelRange.Value2 = ds.Tables[0].Rows[i]["MOBILE"].ToString();

                                                            oexcelRange = ((Excel.Range)oSheet.Cells[11, 4]);
                                                            oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                            oexcelRange.Value2 = ds.Tables[0].Rows[i]["PERMANENT_ADDRESS"].ToString();

                                                            oexcelRange = ((Excel.Range)oSheet.Cells[12, 7]);
                                                            oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                            oexcelRange.Value2 = ds.Tables[0].Rows[i]["PINCODE"].ToString();

                                                            oexcelRange = ((Excel.Range)oSheet.Cells[12, 10]);
                                                            oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                            oexcelRange.Value2 = ds.Tables[0].Rows[i]["LAND_MARK_OBSERVED"].ToString();

                                                            oexcelRange = ((Excel.Range)oSheet.Cells[12, 12]);
                                                            oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                            //oexcelRange.Value2 = "N/A";// ds.Tables[0].Rows[i]["CASE_ID"].ToString();
                                                            //oexcelRange.Value2 = ds.Tables[0].Rows[i]["RES_PHONE"].ToString();
                                                            oexcelRange.Value2 = ds.Tables[0].Rows[i]["PMT_PHONE"].ToString();

                                                            oexcelRange = ((Excel.Range)oSheet.Cells[13, 4]);
                                                            oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                            oexcelRange.Value2 = ds.Tables[0].Rows[i]["DOB"].ToString();

                                                            oexcelRange = ((Excel.Range)oSheet.Cells[13, 9]);
                                                            oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                            oexcelRange.Value2 = ds.Tables[0].Rows[i]["QUALIFICATION"].ToString();

                                                            oexcelRange = ((Excel.Range)oSheet.Cells[13, 13]);
                                                            oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                            //oexcelRange.Value2 = ds.Tables[0].Rows[i]["TIME_AT_CURR_Y_M"].ToString();
                                                            oexcelRange.Value2 = retYearMonth(ds.Tables[0].Rows[i]["TIME_AT_CURR_Y_M"].ToString());

                                                            oexcelRange = ((Excel.Range)oSheet.Cells[14, 4]);
                                                            oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                            oexcelRange.Value2 = ds.Tables[0].Rows[i]["MARITAL_STATUS"].ToString();

                                                            oexcelRange = ((Excel.Range)oSheet.Cells[14, 9]);
                                                            oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                            oexcelRange.Value2 = ds.Tables[0].Rows[i]["NO_OF_DEPENDENT"].ToString();

                                                            oexcelRange = ((Excel.Range)oSheet.Cells[14, 12]);
                                                            oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                            oexcelRange.Value2 = ds.Tables[0].Rows[i]["DESIGNATION"].ToString();

                                                            oexcelRange = ((Excel.Range)oSheet.Cells[15, 4]);
                                                            oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                            oexcelRange.Value2 = ds.Tables[0].Rows[i]["COMPANY_NAME"].ToString();

                                                            oexcelRange = ((Excel.Range)oSheet.Cells[15, 11]);
                                                            oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                            oexcelRange.Value2 = ds.Tables[0].Rows[i]["OFFICE_TELEPHONE"].ToString() + " " + ds.Tables[0].Rows[i]["OFFICE_EXT"].ToString();

                                                            oexcelRange = ((Excel.Range)oSheet.Cells[16, 4]);
                                                            oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                            oexcelRange.Value2 = ds.Tables[0].Rows[i]["OFFICE_ADDRESS"].ToString();

                                                            oexcelRange = ((Excel.Range)oSheet.Cells[17, 4]);
                                                            oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                            oexcelRange.Value2 = ds.Tables[0].Rows[i]["VEHICLE_TYPE"].ToString();

                                                            oexcelRange = ((Excel.Range)oSheet.Cells[17, 9]);
                                                            oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                            oexcelRange.Value2 = ds.Tables[0].Rows[i]["VEHICLE_MAKE"].ToString();

                                                            oexcelRange = ((Excel.Range)oSheet.Cells[17, 11]);
                                                            oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                            oexcelRange.Value2 = ds.Tables[0].Rows[i]["VEHICLE_IS"].ToString();

                                                            oexcelRange = ((Excel.Range)oSheet.Cells[18, 4]);
                                                            oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                            oexcelRange.Value2 = ds.Tables[0].Rows[i]["INCOME_DOC_SUBMITTED_WITH_APLICATION"].ToString();

                                                            oexcelRange = ((Excel.Range)oSheet.Cells[18, 9]);
                                                            oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                            oexcelRange.Value2 = ds.Tables[0].Rows[i]["IS_CREDIT_CARD"].ToString();

                                                            oexcelRange = ((Excel.Range)oSheet.Cells[18, 11]);
                                                            oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                            oexcelRange.Value2 = ds.Tables[0].Rows[i]["CARD_TYPE"].ToString();

                                                            oexcelRange = ((Excel.Range)oSheet.Cells[19, 4]);
                                                            oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                            oexcelRange.Value2 = ds.Tables[0].Rows[i]["CARD_NO"].ToString();

                                                            oexcelRange = ((Excel.Range)oSheet.Cells[19, 9]);
                                                            oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                            oexcelRange.Value2 = ds.Tables[0].Rows[i]["CARD_LIMIT"].ToString();

                                                            oexcelRange = ((Excel.Range)oSheet.Cells[19, 11]);
                                                            oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                            oexcelRange.Value2 = ds.Tables[0].Rows[i]["CARD_EXPIRY"].ToString();

                                                            oexcelRange = ((Excel.Range)oSheet.Cells[21, 5]);
                                                            oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                            oexcelRange.Value2 = ds.Tables[0].Rows[i]["APPLICANT_AVAILABILITY"].ToString();

                                                            oexcelRange = ((Excel.Range)oSheet.Cells[21, 9]);
                                                            oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                            //oexcelRange.Value2 = ds.Tables[0].Rows[i]["TIME_AT_CURR_RESIDANCE"].ToString();
                                                            oexcelRange.Value2 = retYearMonth(ds.Tables[0].Rows[i]["TIME_AT_CURR_RESIDANCE"].ToString());

                                                            oexcelRange = ((Excel.Range)oSheet.Cells[21, 11]);
                                                            oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                            //oexcelRange.Value2 = "N/A";//ds.Tables[0].Rows[i]["RESIDANCE_IS"].ToString();
                                                            oexcelRange.Value2 = ds.Tables[0].Rows[i]["RESIDANCE_IS"].ToString();

                                                            oexcelRange = ((Excel.Range)oSheet.Cells[22, 5]);
                                                            oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                            //oexcelRange.Value2 = "N/A";//ds.Tables[0].Rows[i]["IS_SPOUSE_WORKING"].ToString();
                                                            oexcelRange.Value2 = ds.Tables[0].Rows[i]["IS_SPOUSE_WORKING"].ToString();

                                                            oexcelRange = ((Excel.Range)oSheet.Cells[22, 9]);
                                                            oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                            oexcelRange.Value2 = ds.Tables[0].Rows[i]["APPLICANT_WORKS_AT"].ToString();

                                                            oexcelRange = ((Excel.Range)oSheet.Cells[22, 11]);
                                                            oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                            oexcelRange.Value2 = ds.Tables[0].Rows[i]["VERIFIED_NEIGHBOUR"].ToString();

                                                            oexcelRange = ((Excel.Range)oSheet.Cells[24, 4]);
                                                            oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                            oexcelRange.Value2 = ds.Tables[0].Rows[i]["RES_TYPE"].ToString();

                                                            oexcelRange = ((Excel.Range)oSheet.Cells[24, 10]);
                                                            oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                            oexcelRange.Value2 = ds.Tables[0].Rows[i]["APPROXIMATE_AREA"].ToString();

                                                            oexcelRange = ((Excel.Range)oSheet.Cells[25, 4]);
                                                            oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                            oexcelRange.Value2 = ds.Tables[0].Rows[i]["GENRAL_APPEARANCE"].ToString();

                                                            oexcelRange = ((Excel.Range)oSheet.Cells[25, 10]);
                                                            oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                            oexcelRange.Value2 = ds.Tables[0].Rows[i]["LOCALITY"].ToString();

                                                            oexcelRange = ((Excel.Range)oSheet.Cells[26, 4]);
                                                            oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                            oexcelRange.Value2 = ds.Tables[0].Rows[i]["LOCATING_ADDRESS"].ToString();

                                                            oexcelRange = ((Excel.Range)oSheet.Cells[26, 10]);
                                                            oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                            oexcelRange.Value2 = ds.Tables[0].Rows[i]["ASSETS_VISIBLE"].ToString();

                                                            oexcelRange = ((Excel.Range)oSheet.Cells[27, 6]);
                                                            oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                            oexcelRange.Value2 = ds.Tables[0].Rows[i]["PORTRAIT"].ToString();

                                                            oexcelRange = ((Excel.Range)oSheet.Cells[27, 10]);
                                                            oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                            oexcelRange.Value2 = ds.Tables[0].Rows[i]["PROOF_OF_VISIT_COLLECTED"].ToString();

                                                            oexcelRange = ((Excel.Range)oSheet.Cells[28, 6]);
                                                            oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                            oexcelRange.Value2 = ds.Tables[0].Rows[i]["ROUTE_MAP_DRAWN"].ToString();

                                                            oexcelRange = ((Excel.Range)oSheet.Cells[28, 9]);
                                                            oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                            oexcelRange.Value2 = ds.Tables[0].Rows[i]["IS_NEGATIVE_AREA"].ToString();

                                                            oexcelRange = ((Excel.Range)oSheet.Cells[28, 12]);
                                                            oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                            oexcelRange.Value2 = ds.Tables[0].Rows[i]["IS_OCL"].ToString();

                                                            oexcelRange = ((Excel.Range)oSheet.Cells[29, 4]);
                                                            oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                            oexcelRange.Value2 = ds.Tables[0].Rows[i]["TPC_DONE"].ToString();

                                                            oexcelRange = ((Excel.Range)oSheet.Cells[29, 10]);
                                                            oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                            oexcelRange.Value2 = ds.Tables[0].Rows[i]["TPC_DETAILS"].ToString();

                                                            oexcelRange = ((Excel.Range)oSheet.Cells[30, 5]);
                                                            oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                            oexcelRange.Value2 = ds.Tables[0].Rows[i]["ANY_OTHER_INFO_OBT"].ToString();

                                                            oexcelRange = ((Excel.Range)oSheet.Cells[31, 5]);
                                                            oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                            oexcelRange.Value2 = ds.Tables[0].Rows[i]["FE_REMARK"].ToString();

                                                            oexcelRange = ((Excel.Range)oSheet.Cells[34, 4]);
                                                            oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                            oexcelRange.Value2 = ds.Tables[0].Rows[i]["ADRESS_CONFIRMATION"].ToString();

                                                            oexcelRange = ((Excel.Range)oSheet.Cells[34, 7]);
                                                            oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                            oexcelRange.Value2 = ds.Tables[0].Rows[i]["CONTACTABILITY"].ToString();

                                                            oexcelRange = ((Excel.Range)oSheet.Cells[34, 11]);
                                                            oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                            oexcelRange.Value2 = ds.Tables[0].Rows[i]["CONFIRMATION_IF_APPLICANT_MET"].ToString();

                                                            oexcelRange = ((Excel.Range)oSheet.Cells[35, 4]);
                                                            oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                            oexcelRange.Value2 = ds.Tables[0].Rows[i]["PROFILE"].ToString();

                                                            oexcelRange = ((Excel.Range)oSheet.Cells[35, 7]);
                                                            oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                            oexcelRange.Value2 = ds.Tables[0].Rows[i]["REPUTATION"].ToString();

                                                            //oexcelRange = ((Excel.Range)oSheet.Cells[35, 11]);
                                                            //oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                            //oexcelRange.Value2 = ds.Tables[0].Rows[i]["DECLINED_CODE"].ToString();

                                                            //oexcelRange = ((Excel.Range)oSheet.Cells[36, 4]);
                                                            //oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                            //oexcelRange.Value2 = ds.Tables[0].Rows[i]["DECLINED_REASON"].ToString();

                                                            oexcelRange = ((Excel.Range)oSheet.Cells[37, 4]);
                                                            oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                            //oexcelRange.Value2 = ds.Tables[0].Rows[i]["OVERALL_ASSESMENT"].ToString();
                                                            oexcelRange.Value2 = ds.Tables[0].Rows[i]["STATUS_NAME"].ToString();

                                                            oexcelRange = ((Excel.Range)oSheet.Cells[38, 5]);
                                                            oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                            //oexcelRange.Value2 = ds.Tables[0].Rows[i]["OVERALL_ASSESMENT_REASON"].ToString();
                                                            oexcelRange.Value2 = ds.Tables[0].Rows[i]["DECLINED_REASON"].ToString();

                                                            if (ds1 != null)
                                                            {
                                                                if (ds1.Tables[0].Rows.Count > 0)
                                                                {
                                                                    oexcelRange = ((Excel.Range)oSheet.Cells[39, 4]);
                                                                    oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                                    oexcelRange.Value2 = ds1.Tables[0].Rows[0]["VERIFIER_ID"].ToString();

                                                                    oexcelRange = ((Excel.Range)oSheet.Cells[39, 8]);
                                                                    oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                                    oexcelRange.Value2 = ds1.Tables[0].Rows[0]["FULLNAME"].ToString();

                                                                    oexcelRange = ((Excel.Range)oSheet.Cells[40, 4]);
                                                                    oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                                    oexcelRange.Value2 = Convert.ToDateTime(ds1.Tables[0].Rows[0]["ATTEMPT_DATE_TIME"].ToString()).ToString("dd/MM/yyyy");
                                                                }
                                                            }

                                                            oexcelRange = ((Excel.Range)oSheet.Cells[39, 11]);
                                                            oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                            oexcelRange.Value2 = ds.Tables[0].Rows[i]["FULLNAME"].ToString();

                                                            //oexcelRange = ((Excel.Range)oSheet.Cells[40, 4]);
                                                            //oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                            //oexcelRange.Value2 = ds.Tables[0].Rows[i]["ATTEMPT_DATE_TIME"].ToString();

                                                            oexcelRange = ((Excel.Range)oSheet.Cells[40, 11]);
                                                            oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                            oexcelRange.Value2 = "";
                                                            //SUMMARY
                                                            switch (ds.Tables[0].Rows[i]["CASE_STATUS_ID"].ToString())
                                                            {
                                                                case "1":   //Positive
                                                                case "8":   //Accept                                                                    

                                                                    oexcelRange = ((Excel.Range)oSheet1.Cells[27, 10]);
                                                                    oexcelRange.HorizontalAlignment = HorizontalAlign.Center;
                                                                    oexcelRange.BorderAround(LineStyle.SingleLine, XlBorderWeight.xlMedium, XlColorIndex.xlColorIndexAutomatic, oMissing);
                                                                    oexcelRange.Hyperlinks.Add(oexcelRange, oBook.FullName, "'" + oSheet.Name + "'" + "!A1", oMissing, "");
                                                                    oexcelRange.Font.Bold = true;
                                                                    oexcelRange.Font.Size = 11;
                                                                    oexcelRange.Value2 = "X";
                                                                    break;
                                                                case "2":   //Negative
                                                                case "9":   //Decline                                                                    

                                                                    oexcelRange = ((Excel.Range)oSheet1.Cells[29, 10]);
                                                                    oexcelRange.HorizontalAlignment = HorizontalAlign.Center;
                                                                    oexcelRange.BorderAround(LineStyle.SingleLine, XlBorderWeight.xlMedium, XlColorIndex.xlColorIndexAutomatic, oMissing);
                                                                    oexcelRange.Hyperlinks.Add(oexcelRange, oBook.FullName, "'" + oSheet.Name + "'" + "!A1", oMissing, "");
                                                                    oexcelRange.Font.Bold = true;
                                                                    oexcelRange.Font.Size = 11;
                                                                    oexcelRange.Value2 = "X";

                                                                    break;
                                                                case "3":   //Neutral
                                                                case "10":  //Refer to bank                                                                    

                                                                    oexcelRange = ((Excel.Range)oSheet1.Cells[31, 10]);
                                                                    oexcelRange.HorizontalAlignment = HorizontalAlign.Center;
                                                                    oexcelRange.BorderAround(LineStyle.SingleLine, XlBorderWeight.xlMedium, XlColorIndex.xlColorIndexAutomatic, oMissing);
                                                                    oexcelRange.Hyperlinks.Add(oexcelRange, oBook.FullName, "'" + oSheet.Name + "'" + "!A1", oMissing, "");
                                                                    oexcelRange.Font.Bold = true;
                                                                    oexcelRange.Font.Size = 11;
                                                                    oexcelRange.Value2 = "X";
                                                                    break;
                                                                default:
                                                                    break;

                                                            }
                                                            break;
                                                        case 2:
                                                            //BV
                                                            arrVerType.Add("BV");
                                                            oSheet = (Excel._Worksheet)oBook.Worksheets["BV"];
                                                            oSheet.Visible = Excel.XlSheetVisibility.xlSheetVisible;
                                                            oSheet.Unprotect(oMissing);

                                                            oexcelRange = ((Excel.Range)oSheet.Cells[5, 5]);
                                                            oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                            oexcelRange.Value2 = ds.Tables[0].Rows[i]["APPLICANT_NAME"].ToString();

                                                            oexcelRange = ((Excel.Range)oSheet.Cells[6, 4]);
                                                            oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                            oexcelRange.Value2 = ds.Tables[0].Rows[i]["REF_NO"].ToString();

                                                            oexcelRange = ((Excel.Range)oSheet.Cells[6, 8]);
                                                            oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                            oexcelRange.Value2 = Convert.ToDateTime(ds.Tables[0].Rows[i]["CASE_REC_DATETIME"].ToString()).ToString("dd/MM/yyyy");

                                                            oexcelRange = ((Excel.Range)oSheet.Cells[6, 13]);
                                                            oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                            oexcelRange.Value2 = ds.Tables[0].Rows[i]["AGENCY_NAME"].ToString();

                                                            oexcelRange = ((Excel.Range)oSheet.Cells[7, 4]);
                                                            oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                            oexcelRange.Value2 = ds.Tables[0].Rows[i]["OFF_ADD_LINE"].ToString();

                                                            oexcelRange = ((Excel.Range)oSheet.Cells[8, 7]);
                                                            oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                            oexcelRange.Value2 = ds.Tables[0].Rows[i]["OFF_PIN_CODE"].ToString();

                                                            oexcelRange = ((Excel.Range)oSheet.Cells[8, 10]);
                                                            oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                            oexcelRange.Value2 = ds.Tables[0].Rows[i]["LAND_MARK_OBSERVED"].ToString();

                                                            oexcelRange = ((Excel.Range)oSheet.Cells[9, 4]);
                                                            oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                            oexcelRange.Value2 = ds.Tables[0].Rows[i]["OFFICE_TELEPHONE"].ToString();

                                                            oexcelRange = ((Excel.Range)oSheet.Cells[9, 7]);
                                                            oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                            oexcelRange.Value2 = ds.Tables[0].Rows[i]["PP_NORMAL"].ToString();

                                                            oexcelRange = ((Excel.Range)oSheet.Cells[9, 10]);
                                                            oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                            oexcelRange.Value2 = ds.Tables[0].Rows[i]["OFFICE_EXT"].ToString();

                                                            oexcelRange = ((Excel.Range)oSheet.Cells[9, 12]);
                                                            oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                            oexcelRange.Value2 = ds.Tables[0].Rows[i]["MOBILE"].ToString();

                                                            oexcelRange = ((Excel.Range)oSheet.Cells[11, 5]);
                                                            oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                            oexcelRange.Value2 = ds.Tables[0].Rows[i]["CONTACTED_PERSON_NAME"].ToString();

                                                            oexcelRange = ((Excel.Range)oSheet.Cells[11, 12]);
                                                            oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                            oexcelRange.Value2 = ds.Tables[0].Rows[i]["CONTACTED_PERSON_DESIGN"].ToString();

                                                            oexcelRange = ((Excel.Range)oSheet.Cells[12, 5]);
                                                            oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                            oexcelRange.Value2 = ds.Tables[0].Rows[i]["PERSON_CONTACTED_MET"].ToString();

                                                            oexcelRange = ((Excel.Range)oSheet.Cells[12, 11]);
                                                            oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                            oexcelRange.Value2 = ds.Tables[0].Rows[i]["COMPANY_NAME"].ToString();

                                                            oexcelRange = ((Excel.Range)oSheet.Cells[13, 5]);
                                                            oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                            //oexcelRange.Value2 = "N/A";//ds.Tables[0].Rows[i]["CASE_ID"].ToString();
                                                            oexcelRange.Value2 = ds.Tables[0].Rows[i]["BUSINESS_NATURE"].ToString();

                                                            oexcelRange = ((Excel.Range)oSheet.Cells[13, 12]);
                                                            oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                            oexcelRange.Value2 = ds.Tables[0].Rows[i]["COMPANY_EXISTENCE_YEAR"].ToString();

                                                            oexcelRange = ((Excel.Range)oSheet.Cells[14, 5]);
                                                            oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                            oexcelRange.Value2 = ds.Tables[0].Rows[i]["DESIGNATION"].ToString();

                                                            oexcelRange = ((Excel.Range)oSheet.Cells[14, 12]);
                                                            oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                            oexcelRange.Value2 = retYearMonth(ds.Tables[0].Rows[i]["TIME_AT_CURRENT_EMPLOYMENT"].ToString());

                                                            oexcelRange = ((Excel.Range)oSheet.Cells[15, 5]);
                                                            oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                            oexcelRange.Value2 = ds.Tables[0].Rows[i]["EMP_JOB_TYPE"].ToString();

                                                            oexcelRange = ((Excel.Range)oSheet.Cells[15, 12]);
                                                            oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                            oexcelRange.Value2 = ds.Tables[0].Rows[i]["BUSINESS_PERMISES"].ToString();

                                                            oexcelRange = ((Excel.Range)oSheet.Cells[17, 5]);
                                                            oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                            oexcelRange.Value2 = ds.Tables[0].Rows[i]["DOB"].ToString();

                                                            oexcelRange = ((Excel.Range)oSheet.Cells[17, 13]);
                                                            oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                            oexcelRange.Value2 = ds.Tables[0].Rows[i]["INCOME_DOC_SUBMITTED_WITH_APLICATION"].ToString();

                                                            oexcelRange = ((Excel.Range)oSheet.Cells[18, 5]);
                                                            oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                            oexcelRange.Value2 = ds.Tables[0].Rows[i]["PERMANENT_ADDRESS"].ToString();

                                                            oexcelRange = ((Excel.Range)oSheet.Cells[19, 10]);
                                                            oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                            oexcelRange.Value2 = ds.Tables[0].Rows[i]["ANY_OTHER_RESIDANCE_PHONE_NO"].ToString();

                                                            oexcelRange = ((Excel.Range)oSheet.Cells[20, 5]);
                                                            oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                            oexcelRange.Value2 = ds.Tables[0].Rows[i]["ADD_ON_APPLIED"].ToString();

                                                            oexcelRange = ((Excel.Range)oSheet.Cells[21, 10]);
                                                            oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                            oexcelRange.Value2 = ds.Tables[0].Rows[i]["CHANGE_IN_PHONE_NO"].ToString();

                                                            oexcelRange = ((Excel.Range)oSheet.Cells[23, 5]);
                                                            oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                            oexcelRange.Value2 = ds.Tables[0].Rows[i]["OFF_NAME_ON_BOARD"].ToString();

                                                            oexcelRange = ((Excel.Range)oSheet.Cells[23, 12]);
                                                            oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                            oexcelRange.Value2 = ds.Tables[0].Rows[i]["REASON_NONVISIBLE_NAMEPLATE"].ToString();

                                                            oexcelRange = ((Excel.Range)oSheet.Cells[24, 5]);
                                                            oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                            oexcelRange.Value2 = ds.Tables[0].Rows[i]["OFFICE_SIZE"].ToString();

                                                            oexcelRange = ((Excel.Range)oSheet.Cells[24, 10]);
                                                            oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                            oexcelRange.Value2 = ds.Tables[0].Rows[i]["APPROXIMATE_AREA"].ToString();

                                                            oexcelRange = ((Excel.Range)oSheet.Cells[24, 13]);
                                                            oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                            oexcelRange.Value2 = ds.Tables[0].Rows[i]["NO_OF_EMP"].ToString();

                                                            oexcelRange = ((Excel.Range)oSheet.Cells[25, 5]);
                                                            oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                            oexcelRange.Value2 = ds.Tables[0].Rows[i]["GENRAL_APPEARANCE"].ToString();

                                                            oexcelRange = ((Excel.Range)oSheet.Cells[25, 12]);
                                                            oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                            oexcelRange.Value2 = ds.Tables[0].Rows[i]["OFFICE_LOCALITY"].ToString();

                                                            oexcelRange = ((Excel.Range)oSheet.Cells[26, 5]);
                                                            oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                            oexcelRange.Value2 = ds.Tables[0].Rows[i]["OFFICE_REPUTATION"].ToString();

                                                            oexcelRange = ((Excel.Range)oSheet.Cells[26, 12]);
                                                            oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                            oexcelRange.Value2 = ds.Tables[0].Rows[i]["LOCATING_ADDRESS"].ToString();

                                                            oexcelRange = ((Excel.Range)oSheet.Cells[27, 5]);
                                                            oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                            oexcelRange.Value2 = ds.Tables[0].Rows[i]["OFFICE_IS_IN"].ToString();

                                                            oexcelRange = ((Excel.Range)oSheet.Cells[27, 12]);
                                                            oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                            oexcelRange.Value2 = ds.Tables[0].Rows[i]["BUSINESS_TYPE"].ToString();

                                                            oexcelRange = ((Excel.Range)oSheet.Cells[28, 5]);
                                                            oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                            oexcelRange.Value2 = ds.Tables[0].Rows[i]["AFFILATION_POLITICAL_PARTY_SEEN"].ToString();

                                                            oexcelRange = ((Excel.Range)oSheet.Cells[28, 11]);
                                                            oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                            oexcelRange.Value2 = ds.Tables[0].Rows[i]["EQUIPMENT_SIGHTED_IN_OFFICE"].ToString();

                                                            oexcelRange = ((Excel.Range)oSheet.Cells[29, 5]);
                                                            oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                            oexcelRange.Value2 = ds.Tables[0].Rows[i]["BUSINESS_STOCK_SEEN"].ToString();

                                                            oexcelRange = ((Excel.Range)oSheet.Cells[29, 12]);
                                                            oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                            oexcelRange.Value2 = ds.Tables[0].Rows[i]["STOCK_TYPE"].ToString();

                                                            oexcelRange = ((Excel.Range)oSheet.Cells[30, 5]);
                                                            oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                            oexcelRange.Value2 = ds.Tables[0].Rows[i]["BUSINESS_ACTIVITY_SEEN"].ToString();

                                                            oexcelRange = ((Excel.Range)oSheet.Cells[30, 12]);
                                                            oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                            oexcelRange.Value2 = ds.Tables[0].Rows[i]["PROOF_OF_VISIT_COLLECTED"].ToString();

                                                            oexcelRange = ((Excel.Range)oSheet.Cells[31, 4]);
                                                            oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                            oexcelRange.Value2 = ds.Tables[0].Rows[i]["ROUTE_MAP_DRAWN"].ToString();

                                                            oexcelRange = ((Excel.Range)oSheet.Cells[31, 9]);
                                                            oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                            oexcelRange.Value2 = ds.Tables[0].Rows[i]["IS_NEGATIVE_AREA"].ToString();

                                                            oexcelRange = ((Excel.Range)oSheet.Cells[31, 12]);
                                                            oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                            oexcelRange.Value2 = ds.Tables[0].Rows[i]["IS_OCL"].ToString();

                                                            oexcelRange = ((Excel.Range)oSheet.Cells[34, 3]);
                                                            oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                            oexcelRange.Value2 = ds.Tables[0].Rows[i]["TPC_DONE"].ToString();

                                                            oexcelRange = ((Excel.Range)oSheet.Cells[34, 6]);
                                                            oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                            oexcelRange.Value2 = ds.Tables[0].Rows[i]["TPC_DETAILS"].ToString();

                                                            oexcelRange = ((Excel.Range)oSheet.Cells[34, 13]);
                                                            oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                            oexcelRange.Value2 = ds.Tables[0].Rows[i]["ENTRY_PERMITTED"].ToString();

                                                            oexcelRange = ((Excel.Range)oSheet.Cells[35, 6]);
                                                            oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                            oexcelRange.Value2 = ds.Tables[0].Rows[i]["ANY_OTHER_INFO_OBT"].ToString();

                                                            oexcelRange = ((Excel.Range)oSheet.Cells[37, 6]);
                                                            oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                            oexcelRange.Value2 = ds.Tables[0].Rows[i]["TPC_NAME"].ToString();

                                                            oexcelRange = ((Excel.Range)oSheet.Cells[38, 6]);
                                                            oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                            oexcelRange.Value2 = ds.Tables[0].Rows[i]["OFF_ADDRESS_YEARS"].ToString();

                                                            oexcelRange = ((Excel.Range)oSheet.Cells[39, 6]);
                                                            oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                            oexcelRange.Value2 = ds.Tables[0].Rows[i]["BUSINESS_NATURE"].ToString();

                                                            oexcelRange = ((Excel.Range)oSheet.Cells[39, 13]);
                                                            oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                            oexcelRange.Value2 = ds.Tables[0].Rows[i]["NO_OF_EMP_SIGHTED_IN_PERMISES"].ToString();

                                                            oexcelRange = ((Excel.Range)oSheet.Cells[40, 4]);
                                                            oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                            oexcelRange.Value2 = ds.Tables[0].Rows[i]["FE_REMARK"].ToString();

                                                            oexcelRange = ((Excel.Range)oSheet.Cells[43, 4]);
                                                            oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                            oexcelRange.Value2 = ds.Tables[0].Rows[i]["ADRESS_CONFIRMATION"].ToString();

                                                            oexcelRange = ((Excel.Range)oSheet.Cells[43, 7]);
                                                            oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                            oexcelRange.Value2 = ds.Tables[0].Rows[i]["CONTACTABILITY"].ToString();

                                                            oexcelRange = ((Excel.Range)oSheet.Cells[43, 11]);
                                                            oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                            oexcelRange.Value2 = ds.Tables[0].Rows[i]["CONFIRMATION_IF_APPLICANT_MET"].ToString();

                                                            oexcelRange = ((Excel.Range)oSheet.Cells[44, 4]);
                                                            oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                            oexcelRange.Value2 = ds.Tables[0].Rows[i]["PROFILE"].ToString();

                                                            oexcelRange = ((Excel.Range)oSheet.Cells[44, 7]);
                                                            oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                            oexcelRange.Value2 = ds.Tables[0].Rows[i]["REPUTATION"].ToString();

                                                            //oexcelRange = ((Excel.Range)oSheet.Cells[44, 11]);
                                                            //oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                            //oexcelRange.Value2 = ds.Tables[0].Rows[i]["DECLINED_CODE"].ToString();

                                                            //oexcelRange = ((Excel.Range)oSheet.Cells[45, 4]);
                                                            //oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                            //oexcelRange.Value2 = ds.Tables[0].Rows[i]["DECLINED_REASON"].ToString();

                                                            oexcelRange = ((Excel.Range)oSheet.Cells[46, 4]);
                                                            oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                            //oexcelRange.Value2 = ds.Tables[0].Rows[i]["OVERALL_ASSESMENT"].ToString();
                                                            oexcelRange.Value2 = ds.Tables[0].Rows[i]["STATUS_NAME"].ToString();

                                                            oexcelRange = ((Excel.Range)oSheet.Cells[47, 6]);
                                                            oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                            //oexcelRange.Value2 = ds.Tables[0].Rows[i]["OVERALL_ASSESMENT_REASON"].ToString();
                                                            oexcelRange.Value2 = ds.Tables[0].Rows[i]["DECLINED_REASON"].ToString();
                                                            //**
                                                            if (ds1 != null)
                                                            {
                                                                if (ds1.Tables[0].Rows.Count > 0)
                                                                {
                                                                    oexcelRange = ((Excel.Range)oSheet.Cells[48, 4]);
                                                                    oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                                    oexcelRange.Value2 = ds1.Tables[0].Rows[0]["VERIFIER_ID"].ToString();

                                                                    oexcelRange = ((Excel.Range)oSheet.Cells[48, 8]);
                                                                    oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                                    oexcelRange.Value2 = ds1.Tables[0].Rows[0]["FULLNAME"].ToString();

                                                                    oexcelRange = ((Excel.Range)oSheet.Cells[49, 4]);
                                                                    oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                                    oexcelRange.Value2 = Convert.ToDateTime(ds1.Tables[0].Rows[0]["ATTEMPT_DATE_TIME"].ToString()).ToString("dd/MM/yyyy");
                                                                }
                                                            }
                                                            oexcelRange = ((Excel.Range)oSheet.Cells[48, 12]);
                                                            oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                            oexcelRange.Value2 = ds.Tables[0].Rows[i]["FULLNAME"].ToString();

                                                            //oexcelRange = ((Excel.Range)oSheet.Cells[49, 4]);
                                                            //oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                            //oexcelRange.Value2 = ds.Tables[0].Rows[i]["CASE_ID"].ToString();

                                                            oexcelRange = ((Excel.Range)oSheet.Cells[49, 12]);
                                                            oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                            oexcelRange.Value2 = "";//ds.Tables[0].Rows[i]["CASE_ID"].ToString();
                                                            //SUMMARY
                                                            switch (ds.Tables[0].Rows[i]["CASE_STATUS_ID"].ToString())
                                                            {
                                                                case "1":   //Positive
                                                                case "8":   //Accept
                                                                    
                                                                    oexcelRange = ((Excel.Range)oSheet1.Cells[35, 10]);
                                                                    oexcelRange.HorizontalAlignment = HorizontalAlign.Center;
                                                                    oexcelRange.BorderAround(LineStyle.SingleLine, XlBorderWeight.xlMedium, XlColorIndex.xlColorIndexAutomatic, oMissing);
                                                                    oexcelRange.Hyperlinks.Add(oexcelRange, oBook.FullName, "'" + oSheet.Name + "'" + "!A1", oMissing, "");
                                                                    oexcelRange.Font.Bold = true;
                                                                    oexcelRange.Font.Size = 11;
                                                                    oexcelRange.Value2 = "X";
                                                                    break;
                                                                case "2":   //Negative
                                                                case "9":   //Decline
                                                                    
                                                                    oexcelRange = ((Excel.Range)oSheet1.Cells[37, 10]);
                                                                    oexcelRange.HorizontalAlignment = HorizontalAlign.Center;
                                                                    oexcelRange.BorderAround(LineStyle.SingleLine, XlBorderWeight.xlMedium, XlColorIndex.xlColorIndexAutomatic, oMissing);
                                                                    oexcelRange.Hyperlinks.Add(oexcelRange, oBook.FullName, "'" + oSheet.Name + "'" + "!A1", oMissing, "");
                                                                    oexcelRange.Font.Bold = true;
                                                                    oexcelRange.Font.Size = 11;
                                                                    oexcelRange.Value2 = "X";

                                                                    break;
                                                                case "3":   //Neutral
                                                                case "10":  //Refer To Bank
                                                                    
                                                                    oexcelRange = ((Excel.Range)oSheet1.Cells[39, 10]);
                                                                    oexcelRange.HorizontalAlignment = HorizontalAlign.Center;
                                                                    oexcelRange.BorderAround(LineStyle.SingleLine, XlBorderWeight.xlMedium, XlColorIndex.xlColorIndexAutomatic, oMissing);
                                                                    oexcelRange.Hyperlinks.Add(oexcelRange, oBook.FullName, "'" + oSheet.Name + "'" + "!A1", oMissing, "");
                                                                    oexcelRange.Font.Bold = true;
                                                                    oexcelRange.Font.Size = 11;
                                                                    oexcelRange.Value2 = "X";
                                                                    break;
                                                                default:
                                                                    break;

                                                            }
                                                            break;
                                                        //case 3:                                                
                                                        case 4:
                                                            //RVT
                                                            arrVerType.Add("RT");
                                                            oSheet = (Excel._Worksheet)oBook.Worksheets["RTV"];
                                                            oSheet.Visible = Excel.XlSheetVisibility.xlSheetVisible;
                                                            oSheet.Unprotect(oMissing);

                                                            oexcelRange = ((Excel.Range)oSheet.Cells[5, 5]);
                                                            oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                            oexcelRange.Value2 = ds.Tables[0].Rows[i]["APPLICANT_NAME"].ToString();

                                                            oexcelRange = ((Excel.Range)oSheet.Cells[6, 4]);
                                                            oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                            oexcelRange.Value2 = ds.Tables[0].Rows[i]["REF_NO"].ToString();

                                                            oexcelRange = ((Excel.Range)oSheet.Cells[6, 8]);
                                                            oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                            oexcelRange.Value2 = Convert.ToDateTime(ds.Tables[0].Rows[i]["CASE_REC_DATETIME"].ToString()).ToString("dd/MM/yyyy");

                                                            oexcelRange = ((Excel.Range)oSheet.Cells[6, 13]);
                                                            oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                            oexcelRange.Value2 = ds.Tables[0].Rows[i]["AGENCY_NAME"].ToString();

                                                            oexcelRange = ((Excel.Range)oSheet.Cells[8, 4]);
                                                            oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                            oexcelRange.Value2 = ds.Tables[0].Rows[i]["CONTACTED_PERSON_NAME"].ToString();

                                                            oexcelRange = ((Excel.Range)oSheet.Cells[8, 8]);
                                                            oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                            oexcelRange.Value2 = ds.Tables[0].Rows[i]["BUSINESS_CONTACT_NO"].ToString();

                                                            oexcelRange = ((Excel.Range)oSheet.Cells[8, 11]);
                                                            oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                            //oexcelRange.Value2 = "N/A";//ds.Tables[0].Rows[i]["PP_NORMAL"].ToString();


                                                            oexcelRange = ((Excel.Range)oSheet.Cells[8, 13]);
                                                            oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                            oexcelRange.Value2 = ds.Tables[0].Rows[i]["TPC_DETAILS"].ToString();

                                                            oexcelRange = ((Excel.Range)oSheet.Cells[9, 4]);
                                                            oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                            oexcelRange.Value2 = ds.Tables[0].Rows[i]["RES_ADD_LINE"].ToString();

                                                            oexcelRange = ((Excel.Range)oSheet.Cells[10, 7]);
                                                            oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                            oexcelRange.Value2 = ds.Tables[0].Rows[i]["RES_PIN_CODE"].ToString();

                                                            oexcelRange = ((Excel.Range)oSheet.Cells[10, 10]);
                                                            oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                            oexcelRange.Value2 = ds.Tables[0].Rows[i]["RES_LAND_MARK"].ToString();

                                                            oexcelRange = ((Excel.Range)oSheet.Cells[11, 4]);
                                                            oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                            oexcelRange.Value2 = ds.Tables[0].Rows[i]["Expr1"].ToString();

                                                            oexcelRange = ((Excel.Range)oSheet.Cells[13, 4]);
                                                            oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                            oexcelRange.Value2 = ds.Tables[0].Rows[i]["PP_ADD_LOCATION"].ToString();

                                                            oexcelRange = ((Excel.Range)oSheet.Cells[16, 4]);
                                                            oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                            //oexcelRange.Value2 = ds.Tables[0].Rows[i]["TIME_AT_CURR_Y_M"].ToString(); //ds.Tables[0].Rows[i]["TIME_AT_CURR_RESIDANCE"].ToString();
                                                            oexcelRange.Value2 = retYearMonth(ds.Tables[0].Rows[i]["TIME_AT_CURR_Y_M"].ToString());

                                                            oexcelRange = ((Excel.Range)oSheet.Cells[16, 8]);
                                                            oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                            oexcelRange.Value2 = ds.Tables[0].Rows[i]["MAILING_ADDRESS"].ToString();

                                                            oexcelRange = ((Excel.Range)oSheet.Cells[16, 12]);
                                                            oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                            oexcelRange.Value2 = ds.Tables[0].Rows[i]["RESIDANCE_IS"].ToString();

                                                            oexcelRange = ((Excel.Range)oSheet.Cells[17, 4]);
                                                            oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                            oexcelRange.Value2 = ds.Tables[0].Rows[i]["RESI_COMOFF_OWNED"].ToString();

                                                            oexcelRange = ((Excel.Range)oSheet.Cells[17, 11]);
                                                            oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                            oexcelRange.Value2 = ds.Tables[0].Rows[i]["BUSINESS_CONTACT_EXTN"].ToString();

                                                            oexcelRange = ((Excel.Range)oSheet.Cells[18, 4]);
                                                            oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                            oexcelRange.Value2 = ds.Tables[0].Rows[i]["COMPANY_NAME"].ToString();

                                                            oexcelRange = ((Excel.Range)oSheet.Cells[18, 11]);
                                                            oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                            oexcelRange.Value2 = ds.Tables[0].Rows[i]["DESIGNATION"].ToString();

                                                            oexcelRange = ((Excel.Range)oSheet.Cells[19, 4]);
                                                            oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                            oexcelRange.Value2 = retYearMonth(ds.Tables[0].Rows[i]["TIME_AT_CURRENT_EMPLOYMENT"].ToString());

                                                            oexcelRange = ((Excel.Range)oSheet.Cells[19, 11]);
                                                            oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                            oexcelRange.Value2 = ds.Tables[0].Rows[i]["NOB"].ToString();

                                                            oexcelRange = ((Excel.Range)oSheet.Cells[21, 4]);
                                                            oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                            oexcelRange.Value2 = ds.Tables[0].Rows[i]["NAME_OF_PERSON_CONTACTED"].ToString();// ds.Tables[0].Rows[i]["CONTACTED_PERSON_NAME"].ToString(); //or PERSON_CONTACTED

                                                            oexcelRange = ((Excel.Range)oSheet.Cells[21, 10]);
                                                            oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                            oexcelRange.Value2 = ds.Tables[0].Rows[i]["REL_WITH_APPLICANT"].ToString();

                                                            oexcelRange = ((Excel.Range)oSheet.Cells[22, 4]);
                                                            oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                            oexcelRange.Value2 = ds.Tables[0].Rows[i]["DOB_APPLICANT"].ToString();

                                                            oexcelRange = ((Excel.Range)oSheet.Cells[22, 10]);
                                                            oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                            oexcelRange.Value2 = retYearMonth(ds.Tables[0].Rows[i]["TIME_AT_CURR_RESIDANCE"].ToString());

                                                            oexcelRange = ((Excel.Range)oSheet.Cells[23, 5]);
                                                            oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                            oexcelRange.Value2 = ds.Tables[0].Rows[i]["APPLICANT_IS_AVAILABLE_AT"].ToString();

                                                            oexcelRange = ((Excel.Range)oSheet.Cells[23, 12]);
                                                            oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                            oexcelRange.Value2 = ds.Tables[0].Rows[i]["APPLICANT_AGE"].ToString();

                                                            oexcelRange = ((Excel.Range)oSheet.Cells[24, 4]);
                                                            oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                            oexcelRange.Value2 = "";//ds.Tables[0].Rows[i]["VERIFIER_COMMENTS"].ToString();

                                                            oexcelRange = ((Excel.Range)oSheet.Cells[25, 4]);
                                                            oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                            oexcelRange.Value2 = ds.Tables[0].Rows[i]["NEW_DETAILS_OBTAINED"].ToString();
                                                            if (ds1 != null)
                                                            {
                                                                if (ds1.Tables[0].Rows.Count > 0)
                                                                {
                                                                    for (int j = 0; j < ds1.Tables[0].Rows.Count; j++)
                                                                    {
                                                                        switch (j + 1)
                                                                        {
                                                                            case 1:
                                                                                if (ds1.Tables[0].Rows[j]["ATTEMPT_DATE_TIME"].ToString() != "")
                                                                                {
                                                                                    oexcelRange = ((Excel.Range)oSheet.Cells[28, 4]);
                                                                                    oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                                                    oexcelRange.Value2 = Convert.ToDateTime(ds1.Tables[0].Rows[j]["ATTEMPT_DATE_TIME"]).ToString("dd/MM/yyyy");

                                                                                    oexcelRange = ((Excel.Range)oSheet.Cells[28, 6]);
                                                                                    oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                                                    oexcelRange.Value2 = Convert.ToDateTime(ds1.Tables[0].Rows[j]["ATTEMPT_DATE_TIME"]).ToString("hh:mm tt");
                                                                                }
                                                                                oexcelRange = ((Excel.Range)oSheet.Cells[28, 8]);
                                                                                oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                                                oexcelRange.Value2 = ds1.Tables[0].Rows[j]["TELEPHONE_NO"].ToString();

                                                                                oexcelRange = ((Excel.Range)oSheet.Cells[28, 10]);
                                                                                oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                                                oexcelRange.Value2 = ds1.Tables[0].Rows[j]["REMARK"].ToString();
                                                                                break;
                                                                            case 2:
                                                                                if (ds1.Tables[0].Rows[j]["ATTEMPT_DATE_TIME"].ToString() != "")
                                                                                {
                                                                                    oexcelRange = ((Excel.Range)oSheet.Cells[29, 4]);
                                                                                    oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                                                    oexcelRange.Value2 = Convert.ToDateTime(ds1.Tables[0].Rows[j]["ATTEMPT_DATE_TIME"]).ToString("dd/MM/yyyy");

                                                                                    oexcelRange = ((Excel.Range)oSheet.Cells[29, 6]);
                                                                                    oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                                                    oexcelRange.Value2 = Convert.ToDateTime(ds1.Tables[0].Rows[j]["ATTEMPT_DATE_TIME"]).ToString("hh:mm tt");
                                                                                }
                                                                                oexcelRange = ((Excel.Range)oSheet.Cells[29, 8]);
                                                                                oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                                                oexcelRange.Value2 = ds1.Tables[0].Rows[j]["TELEPHONE_NO"].ToString();

                                                                                oexcelRange = ((Excel.Range)oSheet.Cells[29, 10]);
                                                                                oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                                                oexcelRange.Value2 = ds1.Tables[0].Rows[j]["REMARK"].ToString();
                                                                                break;
                                                                            case 3:
                                                                                if (ds1.Tables[0].Rows[j]["ATTEMPT_DATE_TIME"].ToString() != "")
                                                                                {
                                                                                    oexcelRange = ((Excel.Range)oSheet.Cells[30, 4]);
                                                                                    oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                                                    oexcelRange.Value2 = Convert.ToDateTime(ds1.Tables[0].Rows[j]["ATTEMPT_DATE_TIME"]).ToString("dd/MM/yyyy");

                                                                                    oexcelRange = ((Excel.Range)oSheet.Cells[30, 6]);
                                                                                    oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                                                    oexcelRange.Value2 = Convert.ToDateTime(ds1.Tables[0].Rows[j]["ATTEMPT_DATE_TIME"]).ToString("hh:mm tt");
                                                                                }
                                                                                oexcelRange = ((Excel.Range)oSheet.Cells[30, 8]);
                                                                                oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                                                oexcelRange.Value2 = ds1.Tables[0].Rows[j]["TELEPHONE_NO"].ToString();

                                                                                oexcelRange = ((Excel.Range)oSheet.Cells[30, 10]);
                                                                                oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                                                oexcelRange.Value2 = ds1.Tables[0].Rows[j]["REMARK"].ToString();
                                                                                break;
                                                                            case 4:
                                                                                if (ds1.Tables[0].Rows[j]["ATTEMPT_DATE_TIME"].ToString() != "")
                                                                                {
                                                                                    oexcelRange = ((Excel.Range)oSheet.Cells[31, 4]);
                                                                                    oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                                                    oexcelRange.Value2 = Convert.ToDateTime(ds1.Tables[0].Rows[j]["ATTEMPT_DATE_TIME"]).ToString("dd/MM/yyyy");

                                                                                    oexcelRange = ((Excel.Range)oSheet.Cells[31, 6]);
                                                                                    oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                                                    oexcelRange.Value2 = Convert.ToDateTime(ds1.Tables[0].Rows[j]["ATTEMPT_DATE_TIME"]).ToString("hh:mm tt");
                                                                                }
                                                                                oexcelRange = ((Excel.Range)oSheet.Cells[31, 8]);
                                                                                oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                                                oexcelRange.Value2 = ds1.Tables[0].Rows[j]["TELEPHONE_NO"].ToString();

                                                                                oexcelRange = ((Excel.Range)oSheet.Cells[31, 10]);
                                                                                oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                                                oexcelRange.Value2 = ds1.Tables[0].Rows[j]["REMARK"].ToString();
                                                                                break;
                                                                            case 5:
                                                                                if (ds1.Tables[0].Rows[j]["ATTEMPT_DATE_TIME"].ToString() != "")
                                                                                {
                                                                                    oexcelRange = ((Excel.Range)oSheet.Cells[32, 4]);
                                                                                    oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                                                    oexcelRange.Value2 = Convert.ToDateTime(ds1.Tables[0].Rows[j]["ATTEMPT_DATE_TIME"]).ToString("dd/MM/yyyy");

                                                                                    oexcelRange = ((Excel.Range)oSheet.Cells[32, 6]);
                                                                                    oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                                                    oexcelRange.Value2 = Convert.ToDateTime(ds1.Tables[0].Rows[j]["ATTEMPT_DATE_TIME"]).ToString("hh:mm tt");
                                                                                }
                                                                                oexcelRange = ((Excel.Range)oSheet.Cells[32, 8]);
                                                                                oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                                                oexcelRange.Value2 = ds1.Tables[0].Rows[j]["TELEPHONE_NO"].ToString();

                                                                                oexcelRange = ((Excel.Range)oSheet.Cells[32, 10]);
                                                                                oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                                                oexcelRange.Value2 = ds1.Tables[0].Rows[j]["REMARK"].ToString();
                                                                                break;
                                                                        }
                                                                    }
                                                                    oexcelRange = ((Excel.Range)oSheet.Cells[41, 4]);
                                                                    oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                                    oexcelRange.Value2 = ds1.Tables[0].Rows[0]["VERIFIER_ID"].ToString();

                                                                    //oexcelRange = ((Excel.Range)oSheet.Cells[41, 8]);
                                                                    //oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                                    //oexcelRange.Value2 = ds1.Tables[0].Rows[0]["FULLNAME"].ToString();

                                                                    oexcelRange = ((Excel.Range)oSheet.Cells[42, 4]);
                                                                    oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                                    oexcelRange.Value2 = Convert.ToDateTime(ds1.Tables[0].Rows[0]["ATTEMPT_DATE_TIME"].ToString()).ToString("dd/MM/yyyy");
                                                                }
                                                            }
                                                            ds1.Clear();
                                                            oexcelRange = ((Excel.Range)oSheet.Cells[33, 5]);
                                                            oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                            oexcelRange.Value2 = ds.Tables[0].Rows[i]["ANY_INFO"].ToString();

                                                            oexcelRange = ((Excel.Range)oSheet.Cells[36, 4]);
                                                            oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                            oexcelRange.Value2 = ds.Tables[0].Rows[i]["ADRESS_CONFIRMATION"].ToString();

                                                            oexcelRange = ((Excel.Range)oSheet.Cells[36, 7]);
                                                            oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                            oexcelRange.Value2 = ds.Tables[0].Rows[i]["CONTACTABILITY"].ToString();

                                                            oexcelRange = ((Excel.Range)oSheet.Cells[36, 11]);
                                                            oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                            oexcelRange.Value2 = ds.Tables[0].Rows[i]["CONFIRMATION_IF_APPLICANT_MET"].ToString();

                                                            oexcelRange = ((Excel.Range)oSheet.Cells[37, 4]);
                                                            oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                            oexcelRange.Value2 = ds.Tables[0].Rows[i]["PROFILE"].ToString();

                                                            oexcelRange = ((Excel.Range)oSheet.Cells[37, 7]);
                                                            oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                            oexcelRange.Value2 = ds.Tables[0].Rows[i]["REPUTATION"].ToString();

                                                            //oexcelRange = ((Excel.Range)oSheet.Cells[37, 11]);
                                                            //oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                            //oexcelRange.Value2 = ds.Tables[0].Rows[i]["DECLINED_CODE"].ToString();

                                                            //oexcelRange = ((Excel.Range)oSheet.Cells[38, 4]);
                                                            //oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                            //oexcelRange.Value2 = ds.Tables[0].Rows[i]["OVERALL_ASSESMENT"].ToString();

                                                            oexcelRange = ((Excel.Range)oSheet.Cells[39, 4]);
                                                            oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                            oexcelRange.Value2 = ds.Tables[0].Rows[i]["OVERALL_ASSESMENT"].ToString();

                                                            oexcelRange = ((Excel.Range)oSheet.Cells[40, 5]);
                                                            oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                            oexcelRange.Value2 = ds.Tables[0].Rows[i]["OVERALL_ASSESMENT_REASON"].ToString();

                                                            //oexcelRange = ((Excel.Range)oSheet.Cells[41, 4]);
                                                            //oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                            //oexcelRange.Value2 = ds.Tables[0].Rows[i]["CASE_ID"].ToString();

                                                            //oexcelRange = ((Excel.Range)oSheet.Cells[41, 8]);
                                                            //oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                            //oexcelRange.Value2 = ds.Tables[0].Rows[i]["CASE_ID"].ToString();

                                                            //oexcelRange = ((Excel.Range)oSheet.Cells[41, 7]);
                                                            //oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                            //oexcelRange.Value2 = ds.Tables[0].Rows[i]["FULLNAME"].ToString();

                                                            //oexcelRange = ((Excel.Range)oSheet.Cells[42, 4]);
                                                            //oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                            //oexcelRange.Value2 = ds.Tables[0].Rows[i]["CASE_ID"].ToString();

                                                            //oexcelRange = ((Excel.Range)oSheet.Cells[42, 11]);
                                                            //oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                            //oexcelRange.Value2 = "";// ds.Tables[0].Rows[i]["CASE_ID"].ToString();
                                                            //SUMMARY
                                                            switch (ds.Tables[0].Rows[i]["CASE_STATUS_ID"].ToString())
                                                            {
                                                                case "1":   //Positive
                                                                case "8":   //Accept
                                                                    
                                                                    oexcelRange = ((Excel.Range)oSheet1.Cells[42, 10]);
                                                                    oexcelRange.HorizontalAlignment = HorizontalAlign.Center;
                                                                    oexcelRange.BorderAround(LineStyle.SingleLine, XlBorderWeight.xlMedium, XlColorIndex.xlColorIndexAutomatic, oMissing);
                                                                    oexcelRange.Hyperlinks.Add(oexcelRange, oBook.FullName, "'" + oSheet.Name + "'" + "!A1", oMissing, "");
                                                                    oexcelRange.Font.Bold = true;
                                                                    oexcelRange.Font.Size = 11;
                                                                    oexcelRange.Value2 = "X";
                                                                    break;
                                                                case "2":   //Negative
                                                                case "9":   //Decline
                                                                    
                                                                    oexcelRange = ((Excel.Range)oSheet1.Cells[44, 10]);
                                                                    oexcelRange.HorizontalAlignment = HorizontalAlign.Center;
                                                                    oexcelRange.BorderAround(LineStyle.SingleLine, XlBorderWeight.xlMedium, XlColorIndex.xlColorIndexAutomatic, oMissing);
                                                                    oexcelRange.Hyperlinks.Add(oexcelRange, oBook.FullName, "'" + oSheet.Name + "'" + "!A1", oMissing, "");
                                                                    oexcelRange.Font.Bold = true;
                                                                    oexcelRange.Font.Size = 11;
                                                                    oexcelRange.Value2 = "X";
                                                                    break;
                                                                case "3":   //Neutral
                                                                case "10":  //Refer To Bank
                                                                   
                                                                    oexcelRange = ((Excel.Range)oSheet1.Cells[46, 10]);
                                                                    oexcelRange.HorizontalAlignment = HorizontalAlign.Center;
                                                                    oexcelRange.BorderAround(LineStyle.SingleLine, XlBorderWeight.xlMedium, XlColorIndex.xlColorIndexAutomatic, oMissing);
                                                                    oexcelRange.Hyperlinks.Add(oexcelRange, oBook.FullName, "'" + oSheet.Name + "'" + "!A1", oMissing, "");
                                                                    oexcelRange.Font.Bold = true;
                                                                    oexcelRange.Font.Size = 11;
                                                                    oexcelRange.Value2 = "X";
                                                                    break;
                                                                default:
                                                                    break;

                                                            }
                                                            break;
                                                        //case 4:                                               
                                                        case 3:
                                                            //BVT
                                                            arrVerType.Add("BT");
                                                            oSheet = (Excel._Worksheet)oBook.Worksheets["BTV"];
                                                            oSheet.Visible = Excel.XlSheetVisibility.xlSheetVisible;
                                                            oSheet.Unprotect(oMissing);

                                                            oexcelRange = ((Excel.Range)oSheet.Cells[5, 5]);
                                                            oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                            oexcelRange.Value2 = ds.Tables[0].Rows[i]["APPLICANT_NAME"].ToString();

                                                            oexcelRange = ((Excel.Range)oSheet.Cells[6, 4]);
                                                            oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                            oexcelRange.Value2 = ds.Tables[0].Rows[i]["REF_NO"].ToString();

                                                            oexcelRange = ((Excel.Range)oSheet.Cells[6, 8]);
                                                            oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                            oexcelRange.Value2 = Convert.ToDateTime(ds.Tables[0].Rows[i]["CASE_REC_DATETIME"].ToString()).ToString("dd/MM/yyyy");

                                                            oexcelRange = ((Excel.Range)oSheet.Cells[6, 13]);
                                                            oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                            oexcelRange.Value2 = ds.Tables[0].Rows[i]["AGENCY_NAME"].ToString();

                                                            oexcelRange = ((Excel.Range)oSheet.Cells[8, 4]);
                                                            oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                            oexcelRange.Value2 = ds.Tables[0].Rows[i]["BUSINESS_CONTACT_NO"].ToString();

                                                            oexcelRange = ((Excel.Range)oSheet.Cells[8, 10]);
                                                            oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                            oexcelRange.Value2 = ds.Tables[0].Rows[i]["BUSINESS_CONTACT_EXTN"].ToString();// ds.Tables[0].Rows[i]["OFFICE_EXT"].ToString(); //BUSINESS_CONTACT_EXTN

                                                            oexcelRange = ((Excel.Range)oSheet.Cells[9, 4]);
                                                            oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                            oexcelRange.Value2 = ds.Tables[0].Rows[i]["OFF_ADD_LINE"].ToString();

                                                            oexcelRange = ((Excel.Range)oSheet.Cells[12, 4]);
                                                            oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                            oexcelRange.Value2 = ds.Tables[0].Rows[i]["DOB_APPLICANT"].ToString();

                                                            oexcelRange = ((Excel.Range)oSheet.Cells[12, 8]);
                                                            oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                            oexcelRange.Value2 = ds.Tables[0].Rows[i]["QUALIFICATION"].ToString();

                                                            oexcelRange = ((Excel.Range)oSheet.Cells[12, 12]);
                                                            oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                            oexcelRange.Value2 = ds.Tables[0].Rows[i]["DESIGNATION"].ToString();

                                                            oexcelRange = ((Excel.Range)oSheet.Cells[13, 4]);
                                                            oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                            oexcelRange.Value2 = retYearMonth(ds.Tables[0].Rows[i]["TIME_AT_CURRENT_EMPL_Y_M"].ToString());

                                                            oexcelRange = ((Excel.Range)oSheet.Cells[13, 10]);
                                                            oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                            oexcelRange.Value2 = ds.Tables[0].Rows[i]["INCOME_DOC_SUBMITTED_WITH_APLICATION"].ToString();

                                                            oexcelRange = ((Excel.Range)oSheet.Cells[14, 4]);
                                                            oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                            oexcelRange.Value2 = ds.Tables[0].Rows[i]["RESI_COMOFF_OWNED"].ToString();

                                                            oexcelRange = ((Excel.Range)oSheet.Cells[14, 10]);
                                                            oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                            oexcelRange.Value2 = retYearMonth(ds.Tables[0].Rows[i]["TIME_AT_CURR_Y_M"].ToString());//*

                                                            oexcelRange = ((Excel.Range)oSheet.Cells[15, 4]);
                                                            oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                            oexcelRange.Value2 = ds.Tables[0].Rows[i]["RES_PHONE"].ToString();

                                                            oexcelRange = ((Excel.Range)oSheet.Cells[15, 10]);
                                                            oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                            oexcelRange.Value2 = ds.Tables[0].Rows[i]["RESIDANCE_IS"].ToString();

                                                            oexcelRange = ((Excel.Range)oSheet.Cells[16, 4]);
                                                            oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                            oexcelRange.Value2 = ds.Tables[0].Rows[i]["MAILING_ADDRESS"].ToString();

                                                            oexcelRange = ((Excel.Range)oSheet.Cells[18, 5]);
                                                            oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                            oexcelRange.Value2 = ds.Tables[0].Rows[i]["CONTACTED_PERSON_NAME"].ToString();

                                                            oexcelRange = ((Excel.Range)oSheet.Cells[18, 8]);
                                                            oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                            oexcelRange.Value2 = ds.Tables[0].Rows[i]["OTHERS_DESIGNATION"].ToString();

                                                            oexcelRange = ((Excel.Range)oSheet.Cells[18, 12]);
                                                            oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                            oexcelRange.Value2 = ds.Tables[0].Rows[i]["NATURE_BUSINESS_RESI_CUM_OFF"].ToString();// ds.Tables[0].Rows[i]["BUSINESS_NATURE"].ToString(); ds.Tables[0].Rows[i]["NATURE_BUSINESS_RESI_CUM_OFF"].ToString();

                                                            oexcelRange = ((Excel.Range)oSheet.Cells[19, 5]);
                                                            oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                            oexcelRange.Value2 = ds.Tables[0].Rows[i]["DESIGNATION"].ToString();

                                                            oexcelRange = ((Excel.Range)oSheet.Cells[19, 10]);
                                                            oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                            oexcelRange.Value2 = retYearMonth(ds.Tables[0].Rows[i]["TIME_AT_CURRENT_EMPLOYMENT"].ToString());

                                                            oexcelRange = ((Excel.Range)oSheet.Cells[20, 5]);
                                                            oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                            oexcelRange.Value2 = ds.Tables[0].Rows[i]["APPLICANT_IS_AVAILABLE_AT"].ToString();

                                                            oexcelRange = ((Excel.Range)oSheet.Cells[20, 10]);
                                                            oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                            oexcelRange.Value2 = ds.Tables[0].Rows[i]["APPLICANT_AGE"].ToString();

                                                            oexcelRange = ((Excel.Range)oSheet.Cells[21, 5]);
                                                            oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                            oexcelRange.Value2 = ds.Tables[0].Rows[i]["TELE_COMMENTS"].ToString();

                                                            oexcelRange = ((Excel.Range)oSheet.Cells[22, 5]);
                                                            oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                            oexcelRange.Value2 = ds.Tables[0].Rows[i]["NEW_DETAILS_OBTAINED"].ToString();

                                                            if (ds1 != null)
                                                            {
                                                                if (ds1.Tables[0].Rows.Count > 0)
                                                                {
                                                                    for (int j = 0; j < ds1.Tables[0].Rows.Count; j++)
                                                                    {
                                                                        switch (j + 1)
                                                                        {
                                                                            case 1:
                                                                                if (ds1.Tables[0].Rows[j]["ATTEMPT_DATE_TIME"].ToString() != "")
                                                                                {
                                                                                    oexcelRange = ((Excel.Range)oSheet.Cells[25, 4]);
                                                                                    oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                                                    oexcelRange.Value2 = Convert.ToDateTime(ds1.Tables[0].Rows[j]["ATTEMPT_DATE_TIME"]).ToString("dd/MM/yyyy");

                                                                                    oexcelRange = ((Excel.Range)oSheet.Cells[25, 6]);
                                                                                    oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                                                    oexcelRange.Value2 = Convert.ToDateTime(ds1.Tables[0].Rows[j]["ATTEMPT_DATE_TIME"]).ToString("hh:mm tt");
                                                                                }
                                                                                oexcelRange = ((Excel.Range)oSheet.Cells[25, 8]);
                                                                                oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                                                oexcelRange.Value2 = ds1.Tables[0].Rows[j]["TELEPHONE_NO"].ToString();

                                                                                oexcelRange = ((Excel.Range)oSheet.Cells[25, 10]);
                                                                                oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                                                oexcelRange.Value2 = ds1.Tables[0].Rows[j]["REMARK"].ToString();
                                                                                break;
                                                                            case 2:
                                                                                if (ds1.Tables[0].Rows[j]["ATTEMPT_DATE_TIME"].ToString() != "")
                                                                                {
                                                                                    oexcelRange = ((Excel.Range)oSheet.Cells[26, 4]);
                                                                                    oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                                                    oexcelRange.Value2 = Convert.ToDateTime(ds1.Tables[0].Rows[j]["ATTEMPT_DATE_TIME"]).ToString("dd/MM/yyyy");

                                                                                    oexcelRange = ((Excel.Range)oSheet.Cells[26, 6]);
                                                                                    oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                                                    oexcelRange.Value2 = Convert.ToDateTime(ds1.Tables[0].Rows[j]["ATTEMPT_DATE_TIME"]).ToString("hh:mm tt");
                                                                                }
                                                                                oexcelRange = ((Excel.Range)oSheet.Cells[26, 8]);
                                                                                oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                                                oexcelRange.Value2 = ds1.Tables[0].Rows[j]["TELEPHONE_NO"].ToString();

                                                                                oexcelRange = ((Excel.Range)oSheet.Cells[26, 10]);
                                                                                oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                                                oexcelRange.Value2 = ds1.Tables[0].Rows[j]["REMARK"].ToString();
                                                                                break;
                                                                            case 3:
                                                                                if (ds1.Tables[0].Rows[j]["ATTEMPT_DATE_TIME"].ToString() != "")
                                                                                {
                                                                                    oexcelRange = ((Excel.Range)oSheet.Cells[27, 4]);
                                                                                    oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                                                    oexcelRange.Value2 = Convert.ToDateTime(ds1.Tables[0].Rows[j]["ATTEMPT_DATE_TIME"]).ToString("dd/MM/yyyy");

                                                                                    oexcelRange = ((Excel.Range)oSheet.Cells[27, 6]);
                                                                                    oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                                                    oexcelRange.Value2 = Convert.ToDateTime(ds1.Tables[0].Rows[j]["ATTEMPT_DATE_TIME"]).ToString("hh:mm tt");
                                                                                }
                                                                                oexcelRange = ((Excel.Range)oSheet.Cells[27, 8]);
                                                                                oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                                                oexcelRange.Value2 = ds1.Tables[0].Rows[j]["TELEPHONE_NO"].ToString();

                                                                                oexcelRange = ((Excel.Range)oSheet.Cells[27, 10]);
                                                                                oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                                                oexcelRange.Value2 = ds1.Tables[0].Rows[j]["REMARK"].ToString();
                                                                                break;
                                                                            case 4:
                                                                                if (ds1.Tables[0].Rows[j]["ATTEMPT_DATE_TIME"].ToString() != "")
                                                                                {
                                                                                    oexcelRange = ((Excel.Range)oSheet.Cells[28, 4]);
                                                                                    oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                                                    oexcelRange.Value2 = Convert.ToDateTime(ds1.Tables[0].Rows[j]["ATTEMPT_DATE_TIME"]).ToString("dd/MM/yyyy");

                                                                                    oexcelRange = ((Excel.Range)oSheet.Cells[28, 6]);
                                                                                    oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                                                    oexcelRange.Value2 = Convert.ToDateTime(ds1.Tables[0].Rows[j]["ATTEMPT_DATE_TIME"]).ToString("hh:mm tt");
                                                                                }
                                                                                oexcelRange = ((Excel.Range)oSheet.Cells[28, 8]);
                                                                                oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                                                oexcelRange.Value2 = ds1.Tables[0].Rows[j]["TELEPHONE_NO"].ToString();

                                                                                oexcelRange = ((Excel.Range)oSheet.Cells[28, 10]);
                                                                                oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                                                oexcelRange.Value2 = ds1.Tables[0].Rows[j]["REMARK"].ToString();
                                                                                break;
                                                                            case 5:
                                                                                if (ds1.Tables[0].Rows[j]["ATTEMPT_DATE_TIME"].ToString() != "")
                                                                                {
                                                                                    oexcelRange = ((Excel.Range)oSheet.Cells[29, 4]);
                                                                                    oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                                                    oexcelRange.Value2 = Convert.ToDateTime(ds1.Tables[0].Rows[j]["ATTEMPT_DATE_TIME"]).ToString("dd/MM/yyyy");

                                                                                    oexcelRange = ((Excel.Range)oSheet.Cells[29, 6]);
                                                                                    oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                                                    oexcelRange.Value2 = Convert.ToDateTime(ds1.Tables[0].Rows[j]["ATTEMPT_DATE_TIME"]).ToString("hh:mm tt");
                                                                                }
                                                                                oexcelRange = ((Excel.Range)oSheet.Cells[29, 8]);
                                                                                oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                                                oexcelRange.Value2 = ds1.Tables[0].Rows[j]["TELEPHONE_NO"].ToString();

                                                                                oexcelRange = ((Excel.Range)oSheet.Cells[29, 10]);
                                                                                oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                                                oexcelRange.Value2 = ds1.Tables[0].Rows[j]["REMARK"].ToString();
                                                                                break;
                                                                        }
                                                                    }
                                                                    //**
                                                                    //oexcelRange = ((Excel.Range)oSheet.Cells[38, 4]);
                                                                    //oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                                    //oexcelRange.Value2 = ds1.Tables[0].Rows[0]["VERIFIER_ID"].ToString();

                                                                    //oexcelRange = ((Excel.Range)oSheet.Cells[38, 7]);
                                                                    //oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                                    //oexcelRange.Value2 = ds1.Tables[0].Rows[0]["FULLNAME"].ToString();

                                                                    oexcelRange = ((Excel.Range)oSheet.Cells[39, 4]);
                                                                    oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                                    oexcelRange.Value2 = Convert.ToDateTime(ds1.Tables[0].Rows[0]["ATTEMPT_DATE_TIME"].ToString()).ToString("dd/MM/yyyy");
                                                                }
                                                            }
                                                            ds1.Clear();

                                                            oexcelRange = ((Excel.Range)oSheet.Cells[30, 5]);
                                                            oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                            oexcelRange.Value2 = ds.Tables[0].Rows[i]["Any_Info"].ToString();//*

                                                            oexcelRange = ((Excel.Range)oSheet.Cells[33, 4]);
                                                            oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                            oexcelRange.Value2 = ds.Tables[0].Rows[i]["ADRESS_CONFIRMATION"].ToString();

                                                            oexcelRange = ((Excel.Range)oSheet.Cells[33, 8]);
                                                            oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                            oexcelRange.Value2 = ds.Tables[0].Rows[i]["CONTACTABILITY"].ToString();

                                                            oexcelRange = ((Excel.Range)oSheet.Cells[33, 13]);
                                                            oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                            oexcelRange.Value2 = ds.Tables[0].Rows[i]["CONFIRMATION_IF_APPLICANT_MET"].ToString();

                                                            oexcelRange = ((Excel.Range)oSheet.Cells[34, 4]);
                                                            oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                            oexcelRange.Value2 = ds.Tables[0].Rows[i]["PROFILE"].ToString();

                                                            oexcelRange = ((Excel.Range)oSheet.Cells[34, 7]);
                                                            oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                            oexcelRange.Value2 = ds.Tables[0].Rows[i]["REPUTATION"].ToString();

                                                            //oexcelRange = ((Excel.Range)oSheet.Cells[34, 11]);
                                                            //oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                            //oexcelRange.Value2 = ds.Tables[0].Rows[i]["DECLINED_CODE"].ToString();

                                                            //oexcelRange = ((Excel.Range)oSheet.Cells[35, 4]);
                                                            //oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                            //oexcelRange.Value2 = ds.Tables[0].Rows[i]["DECLINED_REASON"].ToString();

                                                            oexcelRange = ((Excel.Range)oSheet.Cells[36, 4]);
                                                            oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                            oexcelRange.Value2 = ds.Tables[0].Rows[i]["OVERALL_ASSESMENT"].ToString();

                                                            oexcelRange = ((Excel.Range)oSheet.Cells[37, 5]);
                                                            oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                            oexcelRange.Value2 = ds.Tables[0].Rows[i]["OVERALL_ASSESMENT_REASON"].ToString();

                                                            //oexcelRange = ((Excel.Range)oSheet.Cells[38, 4]);
                                                            //oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                            //oexcelRange.Value2 = ds.Tables[0].Rows[i]["CASE_ID"].ToString();

                                                            //oexcelRange = ((Excel.Range)oSheet.Cells[38, 8]);
                                                            //oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                            //oexcelRange.Value2 = ds.Tables[0].Rows[i]["CASE_ID"].ToString();


                                                            //oexcelRange = ((Excel.Range)oSheet.Cells[38, 11]);
                                                            //oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                            //oexcelRange.Value2 = ds.Tables[0].Rows[i]["FULLNAME"].ToString();

                                                            //oexcelRange = ((Excel.Range)oSheet.Cells[39, 4]);
                                                            //oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                            //oexcelRange.Value2 = ds.Tables[0].Rows[i]["CASE_ID"].ToString();

                                                            oexcelRange = ((Excel.Range)oSheet.Cells[39, 11]);
                                                            oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                            oexcelRange.Value2 = "";// ds.Tables[0].Rows[i]["CASE_ID"].ToString();
                                                            //SUMMARY
                                                            switch (ds.Tables[0].Rows[i]["CASE_STATUS_ID"].ToString())
                                                            {
                                                                case "1":   //Positive
                                                                case "8":   //Accept
                                                                    
                                                                    oexcelRange = ((Excel.Range)oSheet1.Cells[49, 10]);
                                                                    oexcelRange.HorizontalAlignment = HorizontalAlign.Center;
                                                                    oexcelRange.BorderAround(LineStyle.SingleLine, XlBorderWeight.xlMedium, XlColorIndex.xlColorIndexAutomatic, oMissing);
                                                                    oexcelRange.Hyperlinks.Add(oexcelRange, oBook.FullName, "'" + oSheet.Name + "'" + "!A1", oMissing, "");
                                                                    oexcelRange.Font.Bold = true;
                                                                    oexcelRange.Font.Size = 11;
                                                                    oexcelRange.Value2 = "X";
                                                                    break;
                                                                case "2":   //Negative
                                                                case "9":   //Decline
                                                                    
                                                                    oexcelRange = ((Excel.Range)oSheet1.Cells[51, 10]);
                                                                    oexcelRange.HorizontalAlignment = HorizontalAlign.Center;
                                                                    oexcelRange.BorderAround(LineStyle.SingleLine, XlBorderWeight.xlMedium, XlColorIndex.xlColorIndexAutomatic, oMissing);
                                                                    oexcelRange.Hyperlinks.Add(oexcelRange, oBook.FullName, "'" + oSheet.Name + "'" + "!A1", oMissing, "");
                                                                    oexcelRange.Font.Bold = true;
                                                                    oexcelRange.Font.Size = 11;
                                                                    oexcelRange.Value2 = "X";

                                                                    break;
                                                                case "3":   //Neutral
                                                                case "10":  //ReferTo Bank
                                                                    
                                                                    oexcelRange = ((Excel.Range)oSheet1.Cells[53, 10]);
                                                                    oexcelRange.HorizontalAlignment = HorizontalAlign.Center;
                                                                    oexcelRange.BorderAround(LineStyle.SingleLine, XlBorderWeight.xlMedium, XlColorIndex.xlColorIndexAutomatic, oMissing);
                                                                    oexcelRange.Hyperlinks.Add(oexcelRange, oBook.FullName, "'" + oSheet.Name + "'" + "!A1", oMissing, "");
                                                                    oexcelRange.Font.Bold = true;
                                                                    oexcelRange.Font.Size = 11;
                                                                    oexcelRange.Value2 = "X";
                                                                    break;
                                                                default:
                                                                    break;

                                                            }
                                                            break;
                                                        default:

                                                            break;
                                                    }
                                                }   //if(strSQL1!="")
                                                else
                                                    conn.Close();
                                            }   //for (int i = 0; i < ds.Tables[0].Rows.Count; i++)

                                            ArrayList arrTotVer = new ArrayList();
                                            arrTotVer.Add("RV");
                                            arrTotVer.Add("BV");
                                            arrTotVer.Add("RT");
                                            arrTotVer.Add("BT");
                                            arrTotVer.Add("PRV"); 
                                            // int iIdx = 26;
                                            string strRV = "N";
                                            string strBV = "N";
                                            string strRT = "N";
                                            string strBT = "N";
                                            string strPRV = "N";

                                            for (int i = 0; i < arrTotVer.Count; i++)
                                            {
                                                for (int j = 0; j < arrVerType.Count; j++)
                                                {
                                                    switch (arrTotVer[i].ToString())
                                                    {

                                                        case "RV":
                                                            if (arrVerType[j].ToString() == "RV")
                                                            {
                                                                strRV = "Y";
                                                            }
                                                            break;
                                                        case "BV":
                                                            if (arrVerType[j].ToString() == "BV")
                                                            {
                                                                strBV = "Y";
                                                            }
                                                            break;
                                                        case "RT":
                                                            if (arrVerType[j].ToString() == "RT")
                                                            {
                                                                strRT = "Y";
                                                            }
                                                            break;
                                                        case "BT":
                                                            if (arrVerType[j].ToString() == "BT")
                                                            {
                                                                strBT = "Y";
                                                            }
                                                            break;
                                                        case "PRV":
                                                            if (arrVerType[j].ToString() == "PRV")
                                                            {
                                                                strPRV = "Y";
                                                            }
                                                            break;   

                                                    }
                                                }
                                            }

                                            if (strRV == "Y")
                                            {
                                                oexcelRange = ((Excel.Range)oSheet1.Cells[26, 6]);
                                                oexcelRange.HorizontalAlignment = HorizontalAlign.Center;
                                                oexcelRange.BorderAround(LineStyle.SingleLine, XlBorderWeight.xlMedium, XlColorIndex.xlColorIndexAutomatic, oMissing);
                                                oexcelRange.Font.Bold = true;
                                                oexcelRange.Font.Size = 11;
                                                oexcelRange.Value2 = "X";
                                            }
                                            else
                                            {
                                                oexcelRange = ((Excel.Range)oSheet1.Cells[26, 8]);
                                                oexcelRange.HorizontalAlignment = HorizontalAlign.Center;
                                                oexcelRange.BorderAround(LineStyle.SingleLine, XlBorderWeight.xlMedium, XlColorIndex.xlColorIndexAutomatic, oMissing);
                                                oexcelRange.Font.Bold = true;
                                                oexcelRange.Font.Size = 11;
                                                oexcelRange.Value2 = "X";
                                            }

                                            if (strBV == "Y")
                                            {
                                                oexcelRange = ((Excel.Range)oSheet1.Cells[34, 6]);
                                                oexcelRange.HorizontalAlignment = HorizontalAlign.Center;
                                                oexcelRange.BorderAround(LineStyle.SingleLine, XlBorderWeight.xlMedium, XlColorIndex.xlColorIndexAutomatic, oMissing);
                                                oexcelRange.Font.Bold = true;
                                                oexcelRange.Font.Size = 11;
                                                oexcelRange.Value2 = "X";
                                            }
                                            else
                                            {
                                                oexcelRange = ((Excel.Range)oSheet1.Cells[34, 8]);
                                                oexcelRange.HorizontalAlignment = HorizontalAlign.Center;
                                                oexcelRange.BorderAround(LineStyle.SingleLine, XlBorderWeight.xlMedium, XlColorIndex.xlColorIndexAutomatic, oMissing);
                                                oexcelRange.Font.Bold = true;
                                                oexcelRange.Font.Size = 11;
                                                oexcelRange.Value2 = "X";
                                            }

                                            if (strRT == "Y")
                                            {
                                                oexcelRange = ((Excel.Range)oSheet1.Cells[41, 6]);
                                                oexcelRange.HorizontalAlignment = HorizontalAlign.Center;
                                                oexcelRange.BorderAround(LineStyle.SingleLine, XlBorderWeight.xlMedium, XlColorIndex.xlColorIndexAutomatic, oMissing);
                                                oexcelRange.Font.Bold = true;
                                                oexcelRange.Font.Size = 11;
                                                oexcelRange.Value2 = "X";
                                            }
                                            else
                                            {
                                                oexcelRange = ((Excel.Range)oSheet1.Cells[41, 8]);
                                                oexcelRange.HorizontalAlignment = HorizontalAlign.Center;
                                                oexcelRange.BorderAround(LineStyle.SingleLine, XlBorderWeight.xlMedium, XlColorIndex.xlColorIndexAutomatic, oMissing);
                                                oexcelRange.Font.Bold = true;
                                                oexcelRange.Font.Size = 11;
                                                oexcelRange.Value2 = "X";
                                            }

                                            if (strBT == "Y")
                                            {
                                                oexcelRange = ((Excel.Range)oSheet1.Cells[48, 6]);
                                                oexcelRange.HorizontalAlignment = HorizontalAlign.Center;
                                                oexcelRange.BorderAround(LineStyle.SingleLine, XlBorderWeight.xlMedium, XlColorIndex.xlColorIndexAutomatic, oMissing);
                                                oexcelRange.Font.Bold = true;
                                                oexcelRange.Font.Size = 11;
                                                oexcelRange.Value2 = "X";
                                            }
                                            else
                                            {
                                                oexcelRange = ((Excel.Range)oSheet1.Cells[48, 8]);
                                                oexcelRange.HorizontalAlignment = HorizontalAlign.Center;
                                                oexcelRange.BorderAround(LineStyle.SingleLine, XlBorderWeight.xlMedium, XlColorIndex.xlColorIndexAutomatic, oMissing);
                                                oexcelRange.Font.Bold = true;
                                                oexcelRange.Font.Size = 11;
                                                oexcelRange.Value2 = "X";
                                            }

                                            if (strPRV == "Y")
                                            {
                                                oexcelRange = ((Excel.Range)oSheet1.Cells[55, 6]);
                                                oexcelRange.HorizontalAlignment = HorizontalAlign.Center;
                                                oexcelRange.BorderAround(LineStyle.SingleLine, XlBorderWeight.xlMedium, XlColorIndex.xlColorIndexAutomatic, oMissing);
                                                oexcelRange.Font.Bold = true;
                                                oexcelRange.Font.Size = 11;
                                                oexcelRange.Value2 = "X";
                                            }
                                            else
                                            {
                                                oexcelRange = ((Excel.Range)oSheet1.Cells[55, 8]);
                                                oexcelRange.HorizontalAlignment = HorizontalAlign.Center;
                                                oexcelRange.BorderAround(LineStyle.SingleLine, XlBorderWeight.xlMedium, XlColorIndex.xlColorIndexAutomatic, oMissing);
                                                oexcelRange.Font.Bold = true;
                                                oexcelRange.Font.Size = 11;
                                                oexcelRange.Value2 = "X";
                                            }
                                        }       //if (ds.Tables[0].Rows.Count > 0)
                                    }           //if(ds!=null)
                                    ds.Clear();
                                    oBook.Save();
                                    //saving excel sheet
                                    oSheet = null;
                                    oBook.Close(false, oMissing ,false);
                                    oBook = null;  
                                    oBooks.Close();
                                    oBooks = null;                           
                                    
                                    oExcelApp.Quit();
                                    oExcelApp = null;

                                    hplDownload.NavigateUrl = ConfigurationManager.AppSettings["FtpPath"] + "//CC//" + Session["UserName"].ToString() + "//" + strDateTime + "//";                
                                }

                                catch (Exception exp)
                                {
                                    conn.Close();                        
                                    throw new Exception(exp.Message);
                                }
                               
                            }
                        conn.Close();
                    }
                }
                catch (Exception exp)
                {
                    throw new Exception(exp.Message);
                    //lblMsg.Text = exp.Message;
                }
}

    protected void btnGenrate_Report_Click(object sender, EventArgs e)
    {        
        try
        {
            CCommon con = new CCommon();
            CStandard_Output objStandardOutput = new CStandard_Output();
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
            ///commented by hemangi kambli on 19-May-2007---------------
            //Added by hemangi kambli on 18-May-2007-----Below code is for showing report in crystal report.
            //DataSet dsStdOutput = new DataSet();
            //System.Data.DataTable dtCaseId = new System.Data.DataTable();
            //dtCaseId = objStandardOutput.Select_CaseId(FinalwhereId);
            //dsStdOutput.Tables.Add(dtCaseId);
            //dsStdOutput.Tables[0].TableName = "Main";

            //System.Data.DataTable dtOfficeVerify = new System.Data.DataTable();
            //dtOfficeVerify = objStandardOutput.Select_Record_Office(FinalwhereId);
            //dsStdOutput.Tables.Add(dtOfficeVerify);
            //dsStdOutput.Tables[1].TableName = "OFFICERECORD";

            //System.Data.DataTable dtResiVerify = new System.Data.DataTable();
            //dtResiVerify = objStandardOutput.Select_Record_Residence(FinalwhereId);
            //dsStdOutput.Tables.Add(dtResiVerify);
            //dsStdOutput.Tables[2].TableName = "RESIDENCERECORD";

            //System.Data.DataTable dtOfficeTelVerify = new System.Data.DataTable();
            //dtOfficeTelVerify = objStandardOutput.Select_Record_Office_Telephone(FinalwhereId);
            //dsStdOutput.Tables.Add(dtOfficeTelVerify);
            //dsStdOutput.Tables[3].TableName = "OFFICETELEPHONICERECORD";

            //System.Data.DataTable dtResiTelVerify = new System.Data.DataTable();
            //dtResiTelVerify = objStandardOutput.Select_Record_Office(FinalwhereId);
            //dsStdOutput.Tables.Add(dtResiTelVerify);
            //dsStdOutput.Tables[4].TableName = "RESIDENCETELEPHONICREOCRD";

            //Session["dataset"] = dsStdOutput;
            //Session["Path"] = Server.MapPath("CC_rpt_CRV_Office.rpt");
            //Response.Redirect("../../CrystalReportviewer.aspx?bckPgURL=CPV\\CC\\CC_Standard_Output.aspx");
            /////--------------------------------------------------------------------------
            ////Added by hemangi kambli on 18-May-2007----------------------------------- 
            
            if (FinalwhereId.Trim() != "")
            {
                DataSet dsStdOutput = new DataSet();
                CReport objReport = new CReport();
                System.Data.DataTable dtCaseId = new System.Data.DataTable();
                System.Data.DataTable dtOfficeVerify = new System.Data.DataTable();
                System.Data.DataTable dtResiVerify = new System.Data.DataTable();
                System.Data.DataTable dtOfficeTelVerify = new System.Data.DataTable();
                System.Data.DataTable dtResiTelVerify = new System.Data.DataTable();
                System.Data.DataTable dtResiTeleAttempt = new System.Data.DataTable();
                System.Data.DataTable dtOfficeTeleAttempt = new System.Data.DataTable();
                string[] arrCaseId = FinalwhereId.Split(',');
                if (arrCaseId.Length > 0)
                {                    
                    string strMapPath = Server.MapPath("../../ExportToUTI/CC/") + Session["UserName"].ToString() + "/";
                    string strDateTime = DateTime.Now.ToString("ddMMyyyyhhmm");

                    if (!Directory.Exists(strMapPath + strDateTime))
                        Directory.CreateDirectory(strMapPath + strDateTime);

                    for (int i = 0; i < arrCaseId.Length; i++)
                    {
                        dsStdOutput.Tables.Clear();
                        dsStdOutput.Clear();
                        string sRefNo="";
                        OleDbDataReader oledbRead;
                        oledbRead = objReport.GetRefNoByCaseId(arrCaseId[i].ToString());
                        if (oledbRead.Read())
                            sRefNo = oledbRead["Ref_No"].ToString();

                        oledbRead.Close();
                        dtCaseId = objReport.GetCaseIdforReport(arrCaseId[i].ToString());
                        dtOfficeVerify = objReport.GetBusinessVerificationDtl(arrCaseId[i].ToString());
                        dtResiVerify = objReport.GetResidenceVerificationDtl(arrCaseId[i].ToString());
                        dtOfficeTelVerify = objReport.GetOfficeTeleDtl(arrCaseId[i].ToString());
                        dtResiTelVerify = objReport.GetResidenceTeleDtl(arrCaseId[i].ToString());
                       
                        dsStdOutput.Tables.Add(dtCaseId);
                        dsStdOutput.Tables[0].TableName = "Main";

                        dsStdOutput.Tables.Add(dtOfficeVerify);
                        dsStdOutput.Tables[1].TableName = "OFFICERECORD";

                        dsStdOutput.Tables.Add(dtResiVerify);
                        dsStdOutput.Tables[2].TableName = "RESIDENCERECORD";

                        dsStdOutput.Tables.Add(dtOfficeTelVerify);
                        dsStdOutput.Tables[3].TableName = "OFFICETELEPHONICERECORD";

                        dsStdOutput.Tables.Add(dtResiTelVerify);
                        dsStdOutput.Tables[4].TableName = "RESIDENCETELEPHONICREOCRD";

                        CrystalReportDocument myReportDocument;
                        myReportDocument = new CrystalReportDocument();
                        myReportDocument.Load(Server.MapPath("CC_rpt_CRV_Office.rpt"));
                        myReportDocument.SetDataSource(dsStdOutput);
                       
                        //if (!Directory.Exists(Server.MapPath("../../ExportToUTI/CC/" + Session["UserName"].ToString()) +  "/" + DateTime.Now.ToString("ddMMyyyyhhmm")))
                        //    Directory.CreateDirectory(Server.MapPath("../../ExportToUTI/CC/" + Session["UserName"].ToString()) + "/" + DateTime.Now.ToString("ddMMyyyyhhmm"));
                        myReportDocument.ExportToDisk(ExportFormatType.PortableDocFormat, strMapPath + strDateTime  + "/" + sRefNo + ".pdf");

                        myReportDocument.Dispose();
                        GC.Collect();
                    }
                    
                    
                    lblMsg.Visible = true;
                    lblMsg.ForeColor = System.Drawing.Color.Red;
                    lblMsg.Text = "Report generated successfully.";
                    hplDownload.Visible = true;

                    //hplDownload.NavigateUrl = ConfigurationManager.AppSettings["FtpPath"] + "//CC//" + Session["UserName"].ToString() + "//" + DateTime.Now.ToString("ddMMyyyyhhmm") + "//";
                    hplDownload.NavigateUrl = ConfigurationManager.AppSettings["FtpPath"] + "//CC//" + Session["UserName"].ToString() + "//" + strDateTime + "//";


                    //START for Downloading files from server to local folder

                    //END for Downloading files from server to local folder
                }
            }
            else
            {
                lblMsg.Visible = true;
                lblMsg.Text = "Please select case.";
                hplDownload.Visible = false;
                hplDownload.NavigateUrl = "";

            }

            
            /////--------------------------------------------------------------------------
            //Commented by hemangi kambli on 18-May-2007----------------------------------
            //DataSet dsCaseId = new DataSet();

            //dsCaseId = objStandardOutput.Select_CaseId(FinalwhereId);
            //string mXmlCaseId = Server.MapPath("XMLCASE_ID.xml");
            //dsCaseId.WriteXml(mXmlCaseId, XmlWriteMode.WriteSchema);    

            //    DataSet Ods = new DataSet();

            //    Ods = objStandardOutput.Select_Record_Office(FinalwhereId);
            //    string mXmlFileOffice = Server.MapPath("XML_CC_CRV_Office.xml");
            //    Ods.WriteXml(mXmlFileOffice, XmlWriteMode.WriteSchema);

            //    DataSet ds_DateTime = new DataSet();
            //    DataSet RT = new DataSet();
            //    RT = objStandardOutput.Select_Record_Residence_Telephone(FinalwhereId);
            //    ds_DateTime = objStandardOutput.Select_Date_Time_Calling(FinalwhereId);
            //    string mXmlFileResidence_Tele = Server.MapPath("XML_CC_CRV_Residence_Telephone.xml");
            //    string mXmlFile_DateTimeCalling = Server.MapPath("XML_DateTimeCalling.xml");
            //    RT.WriteXml(mXmlFileResidence_Tele, XmlWriteMode.WriteSchema);
            //    ds_DateTime.WriteXml(mXmlFile_DateTimeCalling, XmlWriteMode.WriteSchema);

            //    DataSet RV = new DataSet();
            //    RV = objStandardOutput.Select_Record_Residence(FinalwhereId);
            //    string mXmlFile = Server.MapPath("XML_CC_CRV_Residence.xml");
            //    RV.WriteXml(mXmlFile, XmlWriteMode.WriteSchema);

            //    DataSet BT = new DataSet();
            //    BT = objStandardOutput.Select_Record_Office_Telephone(FinalwhereId);
            //    string xmlFileOffice_Tele = Server.MapPath("XMLCRV_CC_OFFICE_TELEPHONIC.xml");
            //    BT.WriteXml(xmlFileOffice_Tele, XmlWriteMode.WriteSchema);

            //    Session["ReportName"] = "CC_rpt_CRV_Office.rpt";
            //    Response.Redirect("CC_CONTAINER_UTI.aspx");

            ////-----------------------------------------------------------------------------------
            //Ods = objStandardOutput.Select_Record_Residence(FinalwhereId);
            //string mXmlFile = Server.MapPath("XML_CC_CRV_Residence.xml");
            //Ods.WriteXml(mXmlFile, XmlWriteMode.WriteSchema);
            //Session["ReportName"] = "CC_rpt_CRV_Residence.rpt";
            //Response.Redirect("CC_Container.aspx");

            //DataSet ds_DateTime = new DataSet();
            //Ods = objStandardOutput.Select_Record_Residence_Telephone(FinalwhereId);
            //ds_DateTime = objStandardOutput.Select_Date_Time_Calling(FinalwhereId, VerificationTypeId);
            //string mXmlFile = Server.MapPath("XML_CC_CRV_Residence_Telephone.xml");
            //string mXmlFile_DateTimeCalling = Server.MapPath("XML_DateTimeCalling.xml");
            //Ods.WriteXml(mXmlFile, XmlWriteMode.WriteSchema);
            //ds_DateTime.WriteXml(mXmlFile_DateTimeCalling, XmlWriteMode.WriteSchema);
            //Session["ReportName"] = "CC_rpt_CRV_Residence_Telephone_Verification.rpt";
            //Response.Redirect("CC_Container.aspx");
        }
        catch (Exception ex)
        {
            lblMsg.Visible = true;
            lblMsg.Text = ex.Message.ToString();
            hplDownload.Visible = false;
            hplDownload.NavigateUrl = "";

        }
        //if(iCount==1)
        //    Response.Redirect("../../CrystalReportviewer.aspx?bckPgURL=CPV\\CC\\CC_Standard_Output.aspx");
    }

    protected void gvOutput_DataBound(object sender, System.EventArgs e)
    {
        // Each time the data is bound to the grid we need to build up the CheckBoxIDs array
        // Get the header CheckBox
        if (gvOutput.Rows.Count <= 0)
        {
            //lblMsg.Text = "No record found";
            pnlView.Visible = true;
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

    public void GeneratePDF(string[] arrCaseId)
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
                System.Data.DataTable dtOfficeTelVerify = new System.Data.DataTable();
                System.Data.DataTable dtResiTelVerify = new System.Data.DataTable();
                System.Data.DataTable dtResiTeleAttempt = new System.Data.DataTable();
                System.Data.DataTable dtOfficeTeleAttempt = new System.Data.DataTable();

                string strMapPath = Server.MapPath("../../ExportToUTI/CC/") + Session["UserName"].ToString() + "/";
                string strDateTime = DateTime.Now.ToString("ddMMyyyyhhmm");

                if (!Directory.Exists(strMapPath + strDateTime))
                    Directory.CreateDirectory(strMapPath + strDateTime);

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
                    dtCaseId = objReport.GetCaseIdforReport(arrCaseId[i].ToString());
                    dtOfficeVerify = objReport.GetBusinessVerificationDtl(arrCaseId[i].ToString());
                    dtResiVerify = objReport.GetResidenceVerificationDtl(arrCaseId[i].ToString());
                    dtOfficeTelVerify = objReport.GetOfficeTeleDtl(arrCaseId[i].ToString());
                    dtResiTelVerify = objReport.GetResidenceTeleDtl(arrCaseId[i].ToString());

                    dsStdOutput.Tables.Add(dtCaseId);
                    dsStdOutput.Tables[0].TableName = "Main";

                    dsStdOutput.Tables.Add(dtOfficeVerify);
                    dsStdOutput.Tables[1].TableName = "OFFICERECORD";

                    dsStdOutput.Tables.Add(dtResiVerify);
                    dsStdOutput.Tables[2].TableName = "RESIDENCERECORD";

                    dsStdOutput.Tables.Add(dtOfficeTelVerify);
                    dsStdOutput.Tables[3].TableName = "OFFICETELEPHONICERECORD";

                    dsStdOutput.Tables.Add(dtResiTelVerify);
                    dsStdOutput.Tables[4].TableName = "RESIDENCETELEPHONICREOCRD";

                    CrystalReportDocument myReportDocument;
                    myReportDocument = new CrystalReportDocument();
                    myReportDocument.Load(Server.MapPath("CC_rpt_CRV_Office.rpt"));
                    myReportDocument.SetDataSource(dsStdOutput);

                    myReportDocument.ExportToDisk(ExportFormatType.PortableDocFormat, strMapPath + strDateTime + "/" + sRefNo + ".pdf");
                    myReportDocument.Dispose();
                    GC.Collect();
                }

                lblMsg.Visible = true;
                lblMsg.ForeColor = System.Drawing.Color.Red;
                lblMsg.Text = "Report generated successfully.";
                hplDownload.Visible = true;
               
                hplDownload.NavigateUrl = ConfigurationManager.AppSettings["FtpPath"] + "//CC//" + Session["UserName"].ToString() + "//" + strDateTime + "//";            }
        }
        catch (Exception ex)
        {

        }            
    }

    public void GenerateExcelBarclaysFormat(string[] arrCaseID)
    {
        //declaring excel variables
        Excel.Application oExcelApp;
        Excel.Workbooks oBooks;
        Excel._Workbook oBook;
        Excel._Worksheet oSheet;
        Excel._Worksheet oSheet1;
        Excel.Range oexcelRange;
        object oMissing;
        //for getting connection string
        CCommon oCmn;
        try
        {
            String strCentreID = Session["CentreId"].ToString(); 
            String strClientID = Session["ClientId"].ToString(); 
            if (strCentreID != "" && strClientID != "")
            {
                oCmn = new CCommon();
                //dataset for main data
                DataSet ds;
                //dataset for attempt details
                DataSet ds1;
                OleDbConnection conn = new OleDbConnection(oCmn.ConnectionString);
                String strRefID = "";
                String strExcel = Server.MapPath("excelBARCLAYoutput.xls");

                string strMapPath = Server.MapPath("../../ExportToUTI/CC/") + Session["UserName"].ToString() + "/";
                string strDateTime = DateTime.Now.ToString("ddMMyyyyhhmm");

                if (!Directory.Exists(strMapPath + strDateTime))
                    Directory.CreateDirectory(strMapPath + strDateTime);

                foreach (String strCaseID in arrCaseID)
                {
                    String strTypeID = "";
                    
                    //////////////-------------------------------                  
                   
                    ArrayList arrVerType = new ArrayList();
                    //---------------------------------------------
                    try
                    {
                        //getting main data
                        conn.Open();
                        String strSQL = "SELECT * FROM CPV_CC_CASE_OUTPUT_VW " +
                                 "WHERE (CENTRE_ID = '" + strCentreID + "') AND (CLIENT_ID = '" + strClientID + "') AND (CASE_ID = '" + strCaseID + "')";
                        ds = OleDbHelper.ExecuteDataset(conn, CommandType.Text, strSQL);
                        conn.Close();
                        //excel setting

                        if (ds.Tables[0].Rows.Count > 0)
                            strRefID = ds.Tables[0].Rows[0]["REF_NO"].ToString();

                        //if (!Directory.Exists(Server.MapPath("../../ExportToUTI/CC/" + Session["UserName"].ToString()) + "/" + DateTime.Now.ToString("ddMMyyyyhhmm")))
                        //    Directory.CreateDirectory(Server.MapPath("../../ExportToUTI/CC/" + Session["UserName"].ToString()) + "/" + DateTime.Now.ToString("ddMMyyyyhhmm"));
                        String strFileName = strMapPath + strDateTime + "/" + strRefID + ".xls";

                        if (File.Exists(strFileName))
                            File.Delete(strFileName);

                        File.Copy(strExcel, strFileName);

                        oMissing = System.Reflection.Missing.Value;
                        oExcelApp = new Excel.Application();
                        oExcelApp.Visible = false;
                        oBooks = oExcelApp.Workbooks;
                        oMissing = System.Reflection.Missing.Value;
                        oExcelApp.Visible = false;
                        oBook = oBooks._Open(strFileName, oMissing, oMissing, oMissing, oMissing, oMissing, oMissing, oMissing, oMissing, oMissing, oMissing, oMissing, oMissing);
                        oExcelApp.Visible = false;
                        oExcelApp.UserControl = false;

                        //getting data from dataset to insert it in excel cells
                        if (ds != null)
                        {
                            if (ds.Tables[0].Rows.Count > 0)
                            {
                                oSheet1 = (Excel._Worksheet)oBook.Worksheets["Summary"];
                                oSheet1.Visible = Excel.XlSheetVisibility.xlSheetVisible;
                                oSheet1.Unprotect(oMissing);                               
                                
                                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                                {
                                    strTypeID = ds.Tables[0].Rows[i]["VERIFICATION_TYPE_ID"].ToString();
                                    //assign ref id

                                    //getting attempt details 
                                    conn.Open();
                                    String strSQL1 = "";
                                    if (strTypeID == "1" || strTypeID == "2")
                                    {
                                        strSQL1 = "SELECT VERIFIER_ID, ATTEMPT_DATE_TIME, FULLNAME FROM VERIFIER_LAST_ATTEMPT_VW INNER JOIN FE_VW ON VERIFIER_ID=EMP_ID " +
                                                  "WHERE CASE_ID='" + strCaseID + "' AND VERIFICATION_TYPE_ID='" + strTypeID + "'";
                                    }

                                    if (strTypeID == "3" || strTypeID == "4")
                                    {
                                        //strSQL1 = "SELECT VERIFIER_ID, ATTEMPT_DATE_TIME, TELEPHONE_NO, REMARK, FULLNAME FROM CPV_CC_VERI_ATTEMPTS INNER JOIN TC_VW ON VERIFIER_ID=EMP_ID " +
                                        //          "WHERE CASE_ID='" + strCaseID + "' AND VERIFICATION_TYPE_ID='" + strTypeID + "'";
                                        strSQL1 = "SELECT VERIFIER_ID, ATTEMPT_DATE_TIME, TELEPHONE_NO, REMARK, FULLNAME FROM CPV_CC_VERI_ATTEMPTS LEFT OUTER JOIN TC_VW ON VERIFIER_ID=EMP_ID " +
                                                  "WHERE CASE_ID='" + strCaseID + "' AND VERIFICATION_TYPE_ID='" + strTypeID + "'";
                                    }
                                    if (strSQL1 != "")
                                    {
                                        ds1 = OleDbHelper.ExecuteDataset(conn, CommandType.Text, strSQL1);
                                        conn.Close();
                                        // SUMMARY
                                        

                                        //filling excel according to verification type 
                                        switch (Convert.ToInt16(strTypeID))
                                        {
                                            case 1:
                                                //RV
                                                oSheet = (Excel._Worksheet)oBook.Worksheets["RV"];
                                                arrVerType.Add("RV");
                                                oSheet.Visible = Excel.XlSheetVisibility.xlSheetVisible;
                                                oSheet.Unprotect(oMissing);

                                                oexcelRange = ((Excel.Range)oSheet.Cells[5, 3]);
                                                //oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                oexcelRange.Value2 = ds.Tables[0].Rows[i]["REF_NO"].ToString();

                                                oexcelRange = ((Excel.Range)oSheet.Cells[5, 7]);
                                                //oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                //oexcelRange.Value2 = ds.Tables[0].Rows[i]["AGENCY_NAME"].ToString();
                                                oexcelRange.Value2 = "PAMAC";

                                                oexcelRange = ((Excel.Range)oSheet.Cells[6, 3]);
                                                //oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                oexcelRange.Value2 = ds.Tables[0].Rows[i]["APPLICANT_NAME"].ToString();

                                                oexcelRange = ((Excel.Range)oSheet.Cells[7, 3]);
                                                //oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                oexcelRange.Value2 = ds.Tables[0].Rows[i]["RES_ADD_LINE"].ToString() + " " + ds.Tables[0].Rows[i]["RES_PIN_CODE"].ToString();

                                                oexcelRange = ((Excel.Range)oSheet.Cells[8, 3]);
                                                //oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                oexcelRange.Value2 = ds.Tables[0].Rows[i]["ADRESS_CONFIRMATION"].ToString();

                                                oexcelRange = ((Excel.Range)oSheet.Cells[8, 7]);
                                                //oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                oexcelRange.Value2 = ds.Tables[0].Rows[i]["RES_LAND_MARK"].ToString();

                                                oexcelRange = ((Excel.Range)oSheet.Cells[8, 9]);
                                                //oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                oexcelRange.Value2 = ds.Tables[0].Rows[i]["RES_PHONE"].ToString();

                                                string sVerDateTimeRV = ds.Tables[0].Rows[i]["CASE_REC_DATETIME"].ToString();
                                                if (sVerDateTimeRV != "")
                                                {
                                                    string[] arrVerDateTime = sVerDateTimeRV.Split(' ');
                                                    if (arrVerDateTime[0].ToString() != "")
                                                    {
                                                        oexcelRange = ((Excel.Range)oSheet.Cells[9, 3]);
                                                        oexcelRange.Value2 = arrVerDateTime[0].ToString();
                                                    }
                                                    if (arrVerDateTime[1].ToString() != "" && arrVerDateTime[2].ToString() != "")
                                                    {
                                                        oexcelRange = ((Excel.Range)oSheet.Cells[9, 7]);
                                                        oexcelRange.Value2 = arrVerDateTime[1].ToString() + " " + arrVerDateTime[2].ToString();
                                                    }
                                                }
                                                oexcelRange = ((Excel.Range)oSheet.Cells[11, 3]);
                                                //oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                oexcelRange.Value2 = ds.Tables[0].Rows[i]["PERSON_CONTACTED"].ToString();

                                                oexcelRange = ((Excel.Range)oSheet.Cells[11, 7]);
                                                //oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                oexcelRange.Value2 = ds.Tables[0].Rows[i]["REL_WITH_APPLICANT"].ToString();

                                                oexcelRange = ((Excel.Range)oSheet.Cells[12, 3]);
                                                //oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                oexcelRange.Value2 = ds.Tables[0].Rows[i]["DOB"].ToString();
                                                
                                                oexcelRange = ((Excel.Range)oSheet.Cells[12, 7]);
                                                //oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                
                                                if (ds.Tables[0].Rows[i]["TITLE"].ToString().Trim() != "")
                                                    oexcelRange.Value2 = retYearMonth(ds.Tables[0].Rows[i]["TIME_AT_CURR_RESIDANCE"].ToString()) + " - (" + ds.Tables[0].Rows[i]["TITLE"].ToString().Trim() + ")";
                                                else
                                                    oexcelRange.Value2 = retYearMonth(ds.Tables[0].Rows[i]["TIME_AT_CURR_RESIDANCE"].ToString());

                                                oexcelRange = ((Excel.Range)oSheet.Cells[13, 3]);
                                                //oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                oexcelRange.Value2 = ds.Tables[0].Rows[i]["RESIDANCE_IS"].ToString();

                                                oexcelRange = ((Excel.Range)oSheet.Cells[13, 7]);
                                                //oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                oexcelRange.Value2 = ds.Tables[0].Rows[i]["QUALIFICATION"].ToString();

                                                oexcelRange = ((Excel.Range)oSheet.Cells[14, 3]);
                                                //oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                oexcelRange.Value2 = ds.Tables[0].Rows[i]["MARITAL_STATUS"].ToString();

                                                oexcelRange = ((Excel.Range)oSheet.Cells[14, 7]);
                                                //oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                oexcelRange.Value2 = ds.Tables[0].Rows[i]["FAMILY_MEMBERS"].ToString();

                                                oexcelRange = ((Excel.Range)oSheet.Cells[14, 9]);
                                                //oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                oexcelRange.Value2 = retYearMonth(ds.Tables[0].Rows[i]["WORKING"].ToString());

                                                oexcelRange = ((Excel.Range)oSheet.Cells[15, 3]);
                                                //oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                oexcelRange.Value2 = ds.Tables[0].Rows[i]["CHILDREN"].ToString();

                                                oexcelRange = ((Excel.Range)oSheet.Cells[15, 7]);
                                                //oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                oexcelRange.Value2 = ds.Tables[0].Rows[i]["NO_OF_DEPENDENT"].ToString();

                                                oexcelRange = ((Excel.Range)oSheet.Cells[15, 9]);
                                                //oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                oexcelRange.Value2 = ds.Tables[0].Rows[i]["IS_SPOUSE_WORKING"].ToString();

                                                oexcelRange = ((Excel.Range)oSheet.Cells[17, 3]);
                                                //oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                oexcelRange.Value2 = ds.Tables[0].Rows[i]["IS_CREDIT_CARD"].ToString();

                                                oexcelRange = ((Excel.Range)oSheet.Cells[17, 7]);
                                                //oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                oexcelRange.Value2 = ds.Tables[0].Rows[i]["CARD_NO"].ToString();

                                                oexcelRange = ((Excel.Range)oSheet.Cells[18, 3]);
                                                //oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                oexcelRange.Value2 = ds.Tables[0].Rows[i]["CARD_LIMIT"].ToString();

                                                oexcelRange = ((Excel.Range)oSheet.Cells[18, 7]);
                                                //oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                oexcelRange.Value2 = ds.Tables[0].Rows[i]["ISSUING_BANK"].ToString();
                                                
                                                oexcelRange = ((Excel.Range)oSheet.Cells[18, 9]);
                                                //oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                oexcelRange.Value2 = ds.Tables[0].Rows[i]["CARD_EXPIRY"].ToString();

                                                oexcelRange = ((Excel.Range)oSheet.Cells[20, 3]);
                                                //oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                oexcelRange.Value2 = ds.Tables[0].Rows[i]["CUSTOMER_COOPERATION"].ToString();

                                                oexcelRange = ((Excel.Range)oSheet.Cells[20, 7]);
                                                //oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                oexcelRange.Value2 = ds.Tables[0].Rows[i]["NEIGHBOUR_REFERENCE"].ToString();

                                                oexcelRange = ((Excel.Range)oSheet.Cells[21, 3]);
                                                //oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                oexcelRange.Value2 = ds.Tables[0].Rows[i]["VERIFIED_NEIGHBOUR"].ToString();

                                                oexcelRange = ((Excel.Range)oSheet.Cells[22, 3]);
                                                //oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                oexcelRange.Value2 = ds.Tables[0].Rows[i]["RES_TYPE"].ToString();

                                                oexcelRange = ((Excel.Range)oSheet.Cells[22, 7]);
                                                //oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                oexcelRange.Value2 = ds.Tables[0].Rows[i]["LOCALITY"].ToString();

                                                oexcelRange = ((Excel.Range)oSheet.Cells[23, 3]);
                                                //oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                oexcelRange.Value2 = ds.Tables[0].Rows[i]["LOCATING_ADDRESS"].ToString();

                                                oexcelRange = ((Excel.Range)oSheet.Cells[23, 7]);
                                                //oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                oexcelRange.Value2 = ds.Tables[0].Rows[i]["CONSTRUCTION_OF_RESIDANCE"].ToString();

                                                oexcelRange = ((Excel.Range)oSheet.Cells[24, 3]);
                                                //oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                //oexcelRange.Value2 = ds.Tables[0].Rows[i]["COMMENTS_EXTERIORS"].ToString();
                                                if (ds.Tables[0].Rows[i]["COMMENTS_EXTERIORS"].ToString() != "")
                                                {
                                                    string strExterior = ds.Tables[0].Rows[i]["COMMENTS_EXTERIORS"].ToString().Trim();
                                                    int iIndex= strExterior.IndexOf("Others");
                                                    if (iIndex > 0)
                                                    {
                                                        int iIndex1 = iIndex + 20;
                                                        string sTmp1 = strExterior.Substring(0, iIndex - 1);
                                                        string sTmp2 = strExterior.Replace("Others(P1. Specify),", "");
                                                        oexcelRange.Value2 = sTmp2;
                                                    }
                                                    else
                                                        oexcelRange.Value2 = ds.Tables[0].Rows[i]["COMMENTS_EXTERIORS"].ToString().Trim();
                                                    
                                                }

                                                oexcelRange = ((Excel.Range)oSheet.Cells[24, 7]);
                                                //oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                oexcelRange.Value2 = ds.Tables[0].Rows[i]["APPROXIMATE_AREA"].ToString();

                                                oexcelRange = ((Excel.Range)oSheet.Cells[25, 3]);
                                                //oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                oexcelRange.Value2 = ds.Tables[0].Rows[i]["INTERIOR"].ToString();

                                                oexcelRange = ((Excel.Range)oSheet.Cells[26, 3]);
                                                //oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                oexcelRange.Value2 = ds.Tables[0].Rows[i]["ASSETS_VISIBLE"].ToString();

                                                oexcelRange = ((Excel.Range)oSheet.Cells[25, 7]);
                                                //oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                oexcelRange.Value2 = ds.Tables[0].Rows[i]["PORTRAIT"].ToString();

                                                oexcelRange = ((Excel.Range)oSheet.Cells[27, 3]);
                                                //oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                oexcelRange.Value2 = ds.Tables[0].Rows[i]["ANY_OTHER_INFO_OBT"].ToString();

                                                oexcelRange = ((Excel.Range)oSheet.Cells[28, 3]);
                                                //oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                oexcelRange.Value2 = ds.Tables[0].Rows[i]["FE_REMARK"].ToString();

                                                oexcelRange = ((Excel.Range)oSheet.Cells[30, 4]);
                                                //oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                oexcelRange.Value2 = ds.Tables[0].Rows[i]["APPLICANT_STAYED_RESIDANCE"].ToString();

                                                oexcelRange = ((Excel.Range)oSheet.Cells[30, 8]);
                                                //oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                oexcelRange.Value2 = ds.Tables[0].Rows[i]["APPLICANT_AGE2"].ToString();

                                                oexcelRange = ((Excel.Range)oSheet.Cells[31, 4]);
                                                //oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                oexcelRange.Value2 = ds.Tables[0].Rows[i]["APPLICANT_AVAILABILITY"].ToString();

                                                oexcelRange = ((Excel.Range)oSheet.Cells[31, 8]);
                                                //oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                oexcelRange.Value2 = ds.Tables[0].Rows[i]["FAMILY_MEMBERS"].ToString();

                                                oexcelRange = ((Excel.Range)oSheet.Cells[32, 3]);
                                                //oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                oexcelRange.Value2 = ds.Tables[0].Rows[i]["STATUS_NAME"].ToString();

                                                oexcelRange = ((Excel.Range)oSheet.Cells[33, 3]);
                                                //oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                oexcelRange.Value2 = ds.Tables[0].Rows[i]["DECLINED_CODE"].ToString();

                                                oexcelRange = ((Excel.Range)oSheet.Cells[34, 3]);
                                                //oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                oexcelRange.Value2 = ds.Tables[0].Rows[i]["SUPERVISOR_REMARKS"].ToString();

                                                //SUMMARY
                                                

                                                switch (ds.Tables[0].Rows[i]["CASE_STATUS_ID"].ToString())
                                                {
                                                    case "1":   //Positive
                                                    case "8":   //Accept
                                                        
                                                        oexcelRange = ((Excel.Range)oSheet1.Cells[27, 10]);
                                                        oexcelRange.HorizontalAlignment = HorizontalAlign.Center;
                                                        oexcelRange.BorderAround(LineStyle.SingleLine, XlBorderWeight.xlMedium, XlColorIndex.xlColorIndexAutomatic, oMissing);
                                                        oexcelRange.Hyperlinks.Add(oexcelRange, oBook.FullName, "'" + oSheet.Name + "'" + "!A1", oMissing, "");
                                                        oexcelRange.Font.Bold = true;
                                                        oexcelRange.Font.Size = 11;
                                                        oexcelRange.Value2 = "X";
                                                        break;
                                                    case "2":   //Negative
                                                    case "9":   //Decline
                                                        
                                                        oexcelRange = ((Excel.Range)oSheet1.Cells[29, 10]);
                                                        oexcelRange.HorizontalAlignment = HorizontalAlign.Center;
                                                        oexcelRange.BorderAround(LineStyle.SingleLine, XlBorderWeight.xlMedium, XlColorIndex.xlColorIndexAutomatic, oMissing);
                                                        oexcelRange.Hyperlinks.Add(oexcelRange, oBook.FullName, "'" + oSheet.Name + "'" + "!A1", oMissing, "");
                                                        oexcelRange.Font.Bold = true;
                                                        oexcelRange.Font.Size = 11;
                                                        oexcelRange.Value2 = "X";

                                                        break;
                                                    case "3":   //Neutral
                                                    case "10":  //Refer to bank
                                                        
                                                        oexcelRange = ((Excel.Range)oSheet1.Cells[31, 10]);
                                                        oexcelRange.HorizontalAlignment = HorizontalAlign.Center;
                                                        oexcelRange.BorderAround(LineStyle.SingleLine, XlBorderWeight.xlMedium, XlColorIndex.xlColorIndexAutomatic, oMissing);
                                                        oexcelRange.Hyperlinks.Add(oexcelRange, oBook.FullName, "'" + oSheet.Name + "'" + "!A1", oMissing, "");
                                                        oexcelRange.Font.Bold = true;
                                                        oexcelRange.Font.Size = 11;
                                                        oexcelRange.Value2 = "X";
                                                        break;
                                                    default:
                                                        break;

                                                }
                                                break;
                                            case 2:
                                                //BV
                                                oSheet = (Excel._Worksheet)oBook.Worksheets["BV"];
                                                arrVerType.Add("BV");
                                                oSheet.Visible = Excel.XlSheetVisibility.xlSheetVisible;
                                                oSheet.Unprotect(oMissing);

                                                oexcelRange = ((Excel.Range)oSheet.Cells[5, 3]);
                                                //oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                oexcelRange.Value2 = ds.Tables[0].Rows[i]["REF_NO"].ToString();

                                                oexcelRange = ((Excel.Range)oSheet.Cells[5, 7]);
                                                //oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                //oexcelRange.Value2 = ds.Tables[0].Rows[i]["AGENCY_NAME"].ToString();
                                                oexcelRange.Value2 = "PAMAC";

                                                oexcelRange = ((Excel.Range)oSheet.Cells[6, 3]);
                                                //oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                oexcelRange.Value2 = ds.Tables[0].Rows[i]["APPLICANT_NAME"].ToString();

                                                oexcelRange = ((Excel.Range)oSheet.Cells[6, 7]);
                                                //oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                oexcelRange.Value2 = ds.Tables[0].Rows[i]["CO_APP_NAME"].ToString();

                                                oexcelRange = ((Excel.Range)oSheet.Cells[7, 3]);
                                                //oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                oexcelRange.Value2 = ds.Tables[0].Rows[i]["OFF_ADD_LINE"].ToString() + " " + ds.Tables[0].Rows[i]["OFF_PIN_CODE"].ToString();

                                                oexcelRange = ((Excel.Range)oSheet.Cells[8, 3]);
                                                //oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                oexcelRange.Value2 = ds.Tables[0].Rows[i]["ADRESS_CONFIRMATION"].ToString();

                                                oexcelRange = ((Excel.Range)oSheet.Cells[8, 7]);
                                                //oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                if (ds.Tables[0].Rows[i]["InputDesignation"].ToString().Trim() != "")
                                                    oexcelRange.Value2 = ds.Tables[0].Rows[i]["DESIGNATION"].ToString() + " - (" + ds.Tables[0].Rows[i]["InputDesignation"].ToString() + ")";
                                                else
                                                    oexcelRange.Value2 = ds.Tables[0].Rows[i]["DESIGNATION"].ToString();

                                                string sVerDateTimeBV = ds.Tables[0].Rows[i]["CASE_REC_DATETIME"].ToString();
                                                if (sVerDateTimeBV != "")
                                                {
                                                    string[] arrVerDateTime = sVerDateTimeBV.Split(' ');
                                                    if (arrVerDateTime[0].ToString() != "")
                                                    {
                                                        oexcelRange = ((Excel.Range)oSheet.Cells[9, 3]);
                                                        oexcelRange.Value2 = arrVerDateTime[0].ToString();
                                                    }
                                                    if (arrVerDateTime[1].ToString() != "" && arrVerDateTime[2].ToString() != "")
                                                    {
                                                        oexcelRange = ((Excel.Range)oSheet.Cells[9, 7]);
                                                        oexcelRange.Value2 = arrVerDateTime[1].ToString() + " " + arrVerDateTime[2].ToString();
                                                    }
                                                }

                                                oexcelRange = ((Excel.Range)oSheet.Cells[11, 3]);
                                                //oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                oexcelRange.Value2 = ds.Tables[0].Rows[i]["CONTACTED_PERSON_NAME"].ToString();

                                                oexcelRange = ((Excel.Range)oSheet.Cells[11, 7]);
                                                //oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                oexcelRange.Value2 = ds.Tables[0].Rows[i]["CONTACTED_PERSON_DESIGN"].ToString();

                                                oexcelRange = ((Excel.Range)oSheet.Cells[12, 3]);
                                                //oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                oexcelRange.Value2 = ds.Tables[0].Rows[i]["OFF_PHONE"].ToString();

                                                oexcelRange = ((Excel.Range)oSheet.Cells[12, 7]);
                                                //oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                oexcelRange.Value2 = ds.Tables[0].Rows[i]["OFFICE_EXT"].ToString();

                                                oexcelRange = ((Excel.Range)oSheet.Cells[12, 9]);
                                                //oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                oexcelRange.Value2 = ds.Tables[0].Rows[i]["MOBILE"].ToString();

                                                oexcelRange = ((Excel.Range)oSheet.Cells[13, 4]);
                                                //oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                oexcelRange.Value2 = retYearMonth(ds.Tables[0].Rows[i]["COMPANY_EXISTENCE_YEAR"].ToString());

                                                oexcelRange = ((Excel.Range)oSheet.Cells[13, 9]);
                                                //oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                oexcelRange.Value2 = ds.Tables[0].Rows[i]["PROOF_OF_VISIT_COLLECTED"].ToString();

                                                oexcelRange = ((Excel.Range)oSheet.Cells[14, 4]);
                                                //oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                oexcelRange.Value2 = ds.Tables[0].Rows[i]["COMPANY_NAME"].ToString();

                                                oexcelRange = ((Excel.Range)oSheet.Cells[15, 3]);
                                                //oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                oexcelRange.Value2 = ds.Tables[0].Rows[i]["BUSINESS_TYPE"].ToString();
                                                                                                
                                                oexcelRange = ((Excel.Range)oSheet.Cells[17, 3]);
                                                if (ds.Tables[0].Rows[i]["BUSINESS_TYPE"].ToString().Trim() == "Others")
                                                    oexcelRange.Value2 = ds.Tables[0].Rows[i]["BUSINESS_TYPE"].ToString();
                                                                                                
                                                oexcelRange = ((Excel.Range)oSheet.Cells[16, 3]);
                                                //oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                oexcelRange.Value2 = ds.Tables[0].Rows[i]["BUSINESS_NATURE"].ToString();
                                                ///------------------------------------------------
                                                ///
                                                oexcelRange = ((Excel.Range)oSheet.Cells[17, 7]);
                                                //oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                oexcelRange.Value2 = ds.Tables[0].Rows[i]["BUSINESS_PERMISES"].ToString();

                                                oexcelRange = ((Excel.Range)oSheet.Cells[18, 4]);
                                                //oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                oexcelRange.Value2 = ds.Tables[0].Rows[i]["NO_OF_EMP"].ToString();

                                                oexcelRange = ((Excel.Range)oSheet.Cells[18, 7]);
                                                //oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                oexcelRange.Value2 = ds.Tables[0].Rows[i]["BRANCH"].ToString();

                                                oexcelRange = ((Excel.Range)oSheet.Cells[19, 4]);
                                                //oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                oexcelRange.Value2 = ds.Tables[0].Rows[i]["AVG_MONTH_TURNOVER"].ToString();

                                                oexcelRange = ((Excel.Range)oSheet.Cells[19, 7]);
                                                //oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                oexcelRange.Value2 = ds.Tables[0].Rows[i]["NO_CUSTOMER_PERDAY"].ToString();

                                                oexcelRange = ((Excel.Range)oSheet.Cells[21, 3]);
                                                //oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                oexcelRange.Value2 = ds.Tables[0].Rows[i]["EMP_JOB_TYPE"].ToString();

                                                oexcelRange = ((Excel.Range)oSheet.Cells[21, 7]);
                                                //oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                oexcelRange.Value2 = ds.Tables[0].Rows[i]["APPLICANT_JOB_TRANSFERABLE"].ToString();

                                                oexcelRange = ((Excel.Range)oSheet.Cells[22, 3]);
                                                //oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                oexcelRange.Value2 = ds.Tables[0].Rows[i]["APP_WORKING_AS"].ToString();

                                                oexcelRange = ((Excel.Range)oSheet.Cells[23, 6]);
                                                //oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                oexcelRange.Value2 = ds.Tables[0].Rows[i]["NAMEOFCOMPANY1"].ToString();

                                                oexcelRange = ((Excel.Range)oSheet.Cells[24, 3]);
                                                //oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                oexcelRange.Value2 = retYearMonth(ds.Tables[0].Rows[i]["YEARS_WORKED"].ToString());

                                                oexcelRange = ((Excel.Range)oSheet.Cells[24, 7]);
                                                //oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                oexcelRange.Value2 = ds.Tables[0].Rows[i]["SALARY_DRAWN"].ToString();

                                                oexcelRange = ((Excel.Range)oSheet.Cells[26, 4]);
                                                //oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                oexcelRange.Value2 = ds.Tables[0].Rows[i]["OFF_NAME_ON_BOARD"].ToString();

                                                oexcelRange = ((Excel.Range)oSheet.Cells[26, 7]);
                                                //oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                oexcelRange.Value2 = ds.Tables[0].Rows[i]["VERIFIED_NEIGHBOUR"].ToString();

                                                oexcelRange = ((Excel.Range)oSheet.Cells[27, 3]);
                                                //oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                oexcelRange.Value2 = ds.Tables[0].Rows[i]["TYPE_OF_OFFICE"].ToString();

                                                oexcelRange = ((Excel.Range)oSheet.Cells[27, 7]);
                                                //oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                oexcelRange.Value2 = ds.Tables[0].Rows[i]["APPROXIMATE_AREA"].ToString();

                                                oexcelRange = ((Excel.Range)oSheet.Cells[28, 3]);
                                                //oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                oexcelRange.Value2 = ds.Tables[0].Rows[i]["OFFICE_LOCALITY"].ToString();

                                                oexcelRange = ((Excel.Range)oSheet.Cells[28, 7]);
                                                //oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                oexcelRange.Value2 = ds.Tables[0].Rows[i]["EXTERIOR"].ToString();

                                                oexcelRange = ((Excel.Range)oSheet.Cells[29, 3]);
                                                //oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                oexcelRange.Value2 = ds.Tables[0].Rows[i]["CONSTRUCTION_OFFICE"].ToString();

                                                oexcelRange = ((Excel.Range)oSheet.Cells[29, 7]);
                                                //oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                oexcelRange.Value2 = ds.Tables[0].Rows[i]["LOCATING_ADDRESS"].ToString();

                                                oexcelRange = ((Excel.Range)oSheet.Cells[30, 3]);
                                                //oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                oexcelRange.Value2 = ds.Tables[0].Rows[i]["INTERIOR"].ToString();

                                                oexcelRange = ((Excel.Range)oSheet.Cells[30, 7]);
                                                //oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                oexcelRange.Value2 = ds.Tables[0].Rows[i]["NO_OF_EMP"].ToString();

                                                oexcelRange = ((Excel.Range)oSheet.Cells[31, 3]);
                                                //oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                oexcelRange.Value2 = ds.Tables[0].Rows[i]["BUSINESS_ACTIVITY_SEEN"].ToString();

                                                oexcelRange = ((Excel.Range)oSheet.Cells[31, 7]);
                                                //oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                oexcelRange.Value2 = ds.Tables[0].Rows[i]["NO_CUSTOMER_SEEN"].ToString();

                                                oexcelRange = ((Excel.Range)oSheet.Cells[32, 4]);
                                                //oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                oexcelRange.Value2 = ds.Tables[0].Rows[i]["AFFILATION_POLITICAL_PARTY_SEEN"].ToString();

                                                oexcelRange = ((Excel.Range)oSheet.Cells[33, 4]);
                                                //oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                oexcelRange.Value2 = ds.Tables[0].Rows[i]["ITEM_SEEN_IN_PERMISES"].ToString();

                                                oexcelRange = ((Excel.Range)oSheet.Cells[34, 3]);
                                                //oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                oexcelRange.Value2 = ds.Tables[0].Rows[i]["ANY_OTHER_INFO_OBT"].ToString();

                                                oexcelRange = ((Excel.Range)oSheet.Cells[35, 3]);
                                                //oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                oexcelRange.Value2 = ds.Tables[0].Rows[i]["FE_REMARK"].ToString();

                                                oexcelRange = ((Excel.Range)oSheet.Cells[36, 3]);
                                                //oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                oexcelRange.Value2 = ds.Tables[0].Rows[i]["STATUS_NAME"].ToString();

                                                oexcelRange = ((Excel.Range)oSheet.Cells[37, 3]);
                                                //oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                oexcelRange.Value2 = ds.Tables[0].Rows[i]["DECLINED_CODE"].ToString();

                                                oexcelRange = ((Excel.Range)oSheet.Cells[38, 3]);
                                                //oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                oexcelRange.Value2 = ds.Tables[0].Rows[i]["SUPERVISOR_REMARKS"].ToString();

                                                //oexcelRange = ((Excel.Range)oSheet.Cells[47, 6]);
                                                //oexcelRange.HorizontalAlignment = HorizontalAlign.Left;                                            
                                                //oexcelRange.Value2 = ds.Tables[0].Rows[i]["DECLINED_REASON"].ToString();

                                                //SUMMARY
                                                switch (ds.Tables[0].Rows[i]["CASE_STATUS_ID"].ToString())
                                                {
                                                    case "1":   //Positive
                                                    case "8":   //Accept     
                                                   
                                                        oexcelRange = ((Excel.Range)oSheet1.Cells[34, 10]);
                                                        oexcelRange.HorizontalAlignment = HorizontalAlign.Center;
                                                        oexcelRange.BorderAround(LineStyle.SingleLine, XlBorderWeight.xlMedium, XlColorIndex.xlColorIndexAutomatic, oMissing);
                                                        oexcelRange.Hyperlinks.Add(oexcelRange, oBook.FullName, "'" + oSheet.Name + "'" + "!A1", oMissing, "");
                                                        oexcelRange.Font.Bold = true;
                                                        oexcelRange.Font.Size = 11;
                                                        oexcelRange.Value2 = "X";
                                                        break;
                                                    case "2":   //Negative
                                                    case "9":   //Decline
                                                        
                                                        oexcelRange = ((Excel.Range)oSheet1.Cells[36, 10]);
                                                        oexcelRange.HorizontalAlignment = HorizontalAlign.Center;
                                                        oexcelRange.BorderAround(LineStyle.SingleLine, XlBorderWeight.xlMedium, XlColorIndex.xlColorIndexAutomatic, oMissing);
                                                        oexcelRange.Hyperlinks.Add(oexcelRange, oBook.FullName, "'" + oSheet.Name + "'" + "!A1", oMissing, "");
                                                        oexcelRange.Font.Bold = true;
                                                        oexcelRange.Font.Size = 11;
                                                        oexcelRange.Value2 = "X";
                                                        break;
                                                    case "3":   //Neutral
                                                    case "10":  //Refer To Bank
                                                        
                                                        oexcelRange = ((Excel.Range)oSheet1.Cells[38, 10]);
                                                        oexcelRange.HorizontalAlignment = HorizontalAlign.Center;
                                                        oexcelRange.BorderAround(LineStyle.SingleLine, XlBorderWeight.xlMedium, XlColorIndex.xlColorIndexAutomatic, oMissing);
                                                        oexcelRange.Hyperlinks.Add(oexcelRange, oBook.FullName, "'" + oSheet.Name + "'" + "!A1", oMissing, "");
                                                        oexcelRange.Font.Bold = true;
                                                        oexcelRange.Font.Size = 11;
                                                        oexcelRange.Value2 = "X";
                                                        break;
                                                    default:
                                                        break;

                                                }
                                                break;
                                            //case 3:                                           
                                            case 4:
                                                //RVT
                                                oSheet = (Excel._Worksheet)oBook.Worksheets["RTBT"];
                                                arrVerType.Add("RT");
                                                oSheet.Visible = Excel.XlSheetVisibility.xlSheetVisible;
                                                oSheet.Unprotect(oMissing);

                                                oexcelRange = ((Excel.Range)oSheet.Cells[5, 7]);
                                                //oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                oexcelRange.Value2 = Convert.ToDateTime(ds.Tables[0].Rows[i]["CASE_REC_DATETIME"].ToString()).ToString("dd/MM/yyyy");

                                                oexcelRange = ((Excel.Range)oSheet.Cells[6, 3]);
                                                //oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                oexcelRange.Value2 = Convert.ToDateTime(ds.Tables[0].Rows[i]["CASE_REC_DATETIME"].ToString()).ToString("dd/MM/yyyy");

                                                oexcelRange = ((Excel.Range)oSheet.Cells[7, 3]);
                                                //oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                oexcelRange.Value2 = ds.Tables[0].Rows[i]["REF_NO"].ToString();

                                                oexcelRange = ((Excel.Range)oSheet.Cells[8, 3]);
                                                //oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                oexcelRange.Value2 = ds.Tables[0].Rows[i]["AGENCY_NAME"].ToString();

                                                oexcelRange = ((Excel.Range)oSheet.Cells[10, 3]);
                                                //oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                oexcelRange.Value2 = Convert.ToDateTime(ds.Tables[0].Rows[i]["CASE_REC_DATETIME"].ToString()).ToString("dd/MM/yyyy");

                                                oexcelRange = ((Excel.Range)oSheet.Cells[12, 3]);
                                                //oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                oexcelRange.Value2 = ds.Tables[0].Rows[i]["APPLICANT_NAME"].ToString();

                                                oexcelRange = ((Excel.Range)oSheet.Cells[13, 3]);
                                                //oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                oexcelRange.Value2 = ds.Tables[0].Rows[i]["RES_ADD_LINE"].ToString() + " " + ds.Tables[0].Rows[i]["RES_PIN_CODE"].ToString();

                                                oexcelRange = ((Excel.Range)oSheet.Cells[14, 3]);
                                                //oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                oexcelRange.Value2 = ds.Tables[0].Rows[i]["RES_LAND_MARK"].ToString();

                                                oexcelRange = ((Excel.Range)oSheet.Cells[14, 7]);
                                                //oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                oexcelRange.Value2 = ds.Tables[0].Rows[i]["IS_RESI_ADD_IS_IN_NEGATIVE_AREA"].ToString();

                                                oexcelRange = ((Excel.Range)oSheet.Cells[15, 3]);
                                                //oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                oexcelRange.Value2 = ds.Tables[0].Rows[i]["RES_PHONE"].ToString();

                                                oexcelRange = ((Excel.Range)oSheet.Cells[15, 7]);
                                                //oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                oexcelRange.Value2 = ds.Tables[0].Rows[i]["MOBILE"].ToString();

                                                oexcelRange = ((Excel.Range)oSheet.Cells[17, 3]);
                                                //oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                oexcelRange.Value2 = ds.Tables[0].Rows[i]["APPLICANT_NAME"].ToString();

                                                oexcelRange = ((Excel.Range)oSheet.Cells[18, 3]);
                                                //oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                oexcelRange.Value2 = ds.Tables[0].Rows[i]["RES_ADD_LINE"].ToString() + " " + ds.Tables[0].Rows[i]["RES_PIN_CODE"].ToString();

                                                oexcelRange = ((Excel.Range)oSheet.Cells[19, 3]);
                                                //oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                oexcelRange.Value2 = ds.Tables[0].Rows[i]["PERMANENT_ADDRESS"].ToString();

                                                oexcelRange = ((Excel.Range)oSheet.Cells[20, 3]);
                                                //oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                oexcelRange.Value2 = ds.Tables[0].Rows[i]["BUSINESS_CONTACT_NO"].ToString();

                                                oexcelRange = ((Excel.Range)oSheet.Cells[20, 8]);
                                                //oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                oexcelRange.Value2 = ds.Tables[0].Rows[i]["RESIDANCE_IS"].ToString();

                                                oexcelRange = ((Excel.Range)oSheet.Cells[21, 3]);
                                                //oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                oexcelRange.Value2 = ds.Tables[0].Rows[i]["SPECIAL_INSTRUCTIONS"].ToString();

                                                oexcelRange = ((Excel.Range)oSheet.Cells[22, 3]);
                                                //oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                oexcelRange.Value2 = ds.Tables[0].Rows[i]["SPK_TO"].ToString();

                                                oexcelRange = ((Excel.Range)oSheet.Cells[22, 8]);
                                                //oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                oexcelRange.Value2 = ds.Tables[0].Rows[i]["REL_WITH_APPLICANT"].ToString();

                                                if (ds1 != null)
                                                {
                                                    if (ds1.Tables[0].Rows.Count > 0)
                                                    {
                                                        for (int j = 0; j < ds1.Tables[0].Rows.Count; j++)
                                                        {
                                                            switch (j + 1)
                                                            {
                                                                case 1:
                                                                    if (ds1.Tables[0].Rows[j]["ATTEMPT_DATE_TIME"].ToString() != "")
                                                                    {
                                                                        oexcelRange = ((Excel.Range)oSheet.Cells[26, 3]);
                                                                        oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                                        oexcelRange.Value2 = Convert.ToDateTime(ds1.Tables[0].Rows[j]["ATTEMPT_DATE_TIME"]).ToString("dd/MM/yyyy");

                                                                        oexcelRange = ((Excel.Range)oSheet.Cells[27, 3]);
                                                                        oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                                        oexcelRange.Value2 = Convert.ToDateTime(ds1.Tables[0].Rows[j]["ATTEMPT_DATE_TIME"]).ToString("hh:mm tt");
                                                                    }
                                                                    oexcelRange = ((Excel.Range)oSheet.Cells[24, 3]);
                                                                    oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                                    oexcelRange.Value2 = ds1.Tables[0].Rows[j]["TELEPHONE_NO"].ToString();

                                                                    oexcelRange = ((Excel.Range)oSheet.Cells[28, 3]);
                                                                    oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                                    oexcelRange.Value2 = ds1.Tables[0].Rows[j]["REMARK"].ToString();
                                                                    break;
                                                                case 2:
                                                                    if (ds1.Tables[0].Rows[j]["ATTEMPT_DATE_TIME"].ToString() != "")
                                                                    {
                                                                        oexcelRange = ((Excel.Range)oSheet.Cells[26, 5]);
                                                                        oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                                        oexcelRange.Value2 = Convert.ToDateTime(ds1.Tables[0].Rows[j]["ATTEMPT_DATE_TIME"]).ToString("dd/MM/yyyy");

                                                                        oexcelRange = ((Excel.Range)oSheet.Cells[27, 5]);
                                                                        oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                                        oexcelRange.Value2 = Convert.ToDateTime(ds1.Tables[0].Rows[j]["ATTEMPT_DATE_TIME"]).ToString("hh:mm tt");
                                                                    }
                                                                    oexcelRange = ((Excel.Range)oSheet.Cells[24, 5]);
                                                                    oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                                    oexcelRange.Value2 = ds1.Tables[0].Rows[j]["TELEPHONE_NO"].ToString();

                                                                    oexcelRange = ((Excel.Range)oSheet.Cells[28, 5]);
                                                                    oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                                    oexcelRange.Value2 = ds1.Tables[0].Rows[j]["REMARK"].ToString();
                                                                    break;
                                                                case 3:
                                                                    if (ds1.Tables[0].Rows[j]["ATTEMPT_DATE_TIME"].ToString() != "")
                                                                    {
                                                                        oexcelRange = ((Excel.Range)oSheet.Cells[26, 7]);
                                                                        oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                                        oexcelRange.Value2 = Convert.ToDateTime(ds1.Tables[0].Rows[j]["ATTEMPT_DATE_TIME"]).ToString("dd/MM/yyyy");

                                                                        oexcelRange = ((Excel.Range)oSheet.Cells[27, 7]);
                                                                        oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                                        oexcelRange.Value2 = Convert.ToDateTime(ds1.Tables[0].Rows[j]["ATTEMPT_DATE_TIME"]).ToString("hh:mm tt");
                                                                    }
                                                                    oexcelRange = ((Excel.Range)oSheet.Cells[24, 7]);
                                                                    oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                                    oexcelRange.Value2 = ds1.Tables[0].Rows[j]["TELEPHONE_NO"].ToString();

                                                                    oexcelRange = ((Excel.Range)oSheet.Cells[28, 7]);
                                                                    oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                                    oexcelRange.Value2 = ds1.Tables[0].Rows[j]["REMARK"].ToString();
                                                                    break;
                                                                case 4:
                                                                    if (ds1.Tables[0].Rows[j]["ATTEMPT_DATE_TIME"].ToString() != "")
                                                                    {
                                                                        oexcelRange = ((Excel.Range)oSheet.Cells[26, 8]);
                                                                        oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                                        oexcelRange.Value2 = Convert.ToDateTime(ds1.Tables[0].Rows[j]["ATTEMPT_DATE_TIME"]).ToString("dd/MM/yyyy");

                                                                        oexcelRange = ((Excel.Range)oSheet.Cells[27, 8]);
                                                                        oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                                        oexcelRange.Value2 = Convert.ToDateTime(ds1.Tables[0].Rows[j]["ATTEMPT_DATE_TIME"]).ToString("hh:mm tt");
                                                                    }
                                                                    oexcelRange = ((Excel.Range)oSheet.Cells[24, 8]);
                                                                    oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                                    oexcelRange.Value2 = ds1.Tables[0].Rows[j]["TELEPHONE_NO"].ToString();

                                                                    oexcelRange = ((Excel.Range)oSheet.Cells[28, 8]);
                                                                    oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                                    oexcelRange.Value2 = ds1.Tables[0].Rows[j]["REMARK"].ToString();
                                                                    break;
                                                                case 5:
                                                                    if (ds1.Tables[0].Rows[j]["ATTEMPT_DATE_TIME"].ToString() != "")
                                                                    {
                                                                        oexcelRange = ((Excel.Range)oSheet.Cells[26, 9]);
                                                                        oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                                        oexcelRange.Value2 = Convert.ToDateTime(ds1.Tables[0].Rows[j]["ATTEMPT_DATE_TIME"]).ToString("dd/MM/yyyy");

                                                                        oexcelRange = ((Excel.Range)oSheet.Cells[27, 9]);
                                                                        oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                                        oexcelRange.Value2 = Convert.ToDateTime(ds1.Tables[0].Rows[j]["ATTEMPT_DATE_TIME"]).ToString("hh:mm tt");
                                                                    }
                                                                    oexcelRange = ((Excel.Range)oSheet.Cells[24, 9]);
                                                                    oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                                    oexcelRange.Value2 = ds1.Tables[0].Rows[j]["TELEPHONE_NO"].ToString();

                                                                    oexcelRange = ((Excel.Range)oSheet.Cells[28, 9]);
                                                                    oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                                    oexcelRange.Value2 = ds1.Tables[0].Rows[j]["REMARK"].ToString();
                                                                    break;
                                                            }
                                                        }
                                                    }
                                                }
                                                ds1.Clear();
                                                oexcelRange = ((Excel.Range)oSheet.Cells[30, 3]);
                                                //oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                oexcelRange.Value2 = ds.Tables[0].Rows[i]["status_name"].ToString();

                                                oexcelRange = ((Excel.Range)oSheet.Cells[31, 3]);
                                                //oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                oexcelRange.Value2 = ds.Tables[0].Rows[i]["Any_Info"].ToString();

                                                oexcelRange = ((Excel.Range)oSheet.Cells[32, 3]);
                                                //oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                oexcelRange.Value2 = ds.Tables[0].Rows[i]["SUPERVISOR_REMARKS"].ToString();

                                                //SUMMARY                                           
                                                switch (ds.Tables[0].Rows[i]["CASE_STATUS_ID"].ToString())
                                                {
                                                    case "1":   //Positive
                                                    case "8":   //Accept                                                        

                                                        oexcelRange = ((Excel.Range)oSheet1.Cells[41, 10]);
                                                        oexcelRange.HorizontalAlignment = HorizontalAlign.Center;
                                                        oexcelRange.BorderAround(LineStyle.SingleLine, XlBorderWeight.xlMedium, XlColorIndex.xlColorIndexAutomatic, oMissing);
                                                        oexcelRange.Hyperlinks.Add(oexcelRange, oBook.FullName, "'" + oSheet.Name + "'" + "!A1", oMissing, "");
                                                        oexcelRange.Font.Bold = true;
                                                        oexcelRange.Font.Size = 11;
                                                        oexcelRange.Value2 = "X";
                                                        break;
                                                    case "2":   //Negative
                                                    case "9":   //Decline                                                        

                                                        oexcelRange = ((Excel.Range)oSheet1.Cells[43, 10]);
                                                        oexcelRange.HorizontalAlignment = HorizontalAlign.Center;
                                                        oexcelRange.BorderAround(LineStyle.SingleLine, XlBorderWeight.xlMedium, XlColorIndex.xlColorIndexAutomatic, oMissing);
                                                        oexcelRange.Hyperlinks.Add(oexcelRange, oBook.FullName, "'" + oSheet.Name + "'" + "!A1", oMissing, "");
                                                        oexcelRange.Font.Bold = true;
                                                        oexcelRange.Font.Size = 11;
                                                        oexcelRange.Value2 = "X";
                                                        break;
                                                    case "3":   //Neutral
                                                    case "10":  //Refer To Bank
                                                        
                                                        oexcelRange = ((Excel.Range)oSheet1.Cells[45, 10]);
                                                        oexcelRange.HorizontalAlignment = HorizontalAlign.Center;
                                                        oexcelRange.BorderAround(LineStyle.SingleLine, XlBorderWeight.xlMedium, XlColorIndex.xlColorIndexAutomatic, oMissing);
                                                        oexcelRange.Hyperlinks.Add(oexcelRange, oBook.FullName, "'" + oSheet.Name + "'" + "!A1", oMissing, "");
                                                        oexcelRange.Font.Bold = true;
                                                        oexcelRange.Font.Size = 11;
                                                        oexcelRange.Value2 = "X";
                                                        break;
                                                    default:
                                                        break;
                                                }
                                                break;
                                            //case 4:    //completed till here                                                
                                            case 3:
                                                //BVT
                                                oSheet = (Excel._Worksheet)oBook.Worksheets["RTBT"];
                                                arrVerType.Add("BT");
                                                oSheet.Visible = Excel.XlSheetVisibility.xlSheetVisible;
                                                oSheet.Unprotect(oMissing);

                                                oexcelRange = ((Excel.Range)oSheet.Cells[34, 3]);
                                                //oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                oexcelRange.Value2 = ds.Tables[0].Rows[i]["APPLICANT_NAME"].ToString();

                                                oexcelRange = ((Excel.Range)oSheet.Cells[35, 3]);
                                                //oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                oexcelRange.Value2 = ds.Tables[0].Rows[i]["COMPANY_NAME"].ToString();

                                                oexcelRange = ((Excel.Range)oSheet.Cells[36, 3]);
                                                //oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                oexcelRange.Value2 = ds.Tables[0].Rows[i]["OFF_ADD_LINE"].ToString();

                                                oexcelRange = ((Excel.Range)oSheet.Cells[37, 3]);
                                                //oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                oexcelRange.Value2 = ds.Tables[0].Rows[i]["LAND_MARK_OBSERVED"].ToString();

                                                oexcelRange = ((Excel.Range)oSheet.Cells[37, 7]);
                                                //oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                oexcelRange.Value2 = ds.Tables[0].Rows[i]["IF_OFFICE_ADD_IS_IN_NEGATIVE_AREA"].ToString();

                                                oexcelRange = ((Excel.Range)oSheet.Cells[38, 3]);
                                                //oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                oexcelRange.Value2 = ds.Tables[0].Rows[i]["OFF_PHONE"].ToString();

                                                oexcelRange = ((Excel.Range)oSheet.Cells[38, 7]);
                                                //oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                oexcelRange.Value2 = ds.Tables[0].Rows[i]["OFFICE_EXT"].ToString();

                                                oexcelRange = ((Excel.Range)oSheet.Cells[38, 9]);
                                                //oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                oexcelRange.Value2 = "";

                                                oexcelRange = ((Excel.Range)oSheet.Cells[40, 3]);
                                                //oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                oexcelRange.Value2 = ds.Tables[0].Rows[i]["BUSINESS_CONTACT_NO"].ToString();

                                                oexcelRange = ((Excel.Range)oSheet.Cells[40, 8]);
                                                //oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                oexcelRange.Value2 = ds.Tables[0].Rows[i]["BUSINESS_CONTACT_EXTN"].ToString();

                                                oexcelRange = ((Excel.Range)oSheet.Cells[41, 3]);
                                                //oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                oexcelRange.Value2 = ds.Tables[0].Rows[i]["APPLICANT_NAME"].ToString();

                                                oexcelRange = ((Excel.Range)oSheet.Cells[41, 8]);
                                                //oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                oexcelRange.Value2 = ds.Tables[0].Rows[i]["OTHER_CONTACTED_DESIGNATION"].ToString();

                                                oexcelRange = ((Excel.Range)oSheet.Cells[42, 3]);
                                                //oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                oexcelRange.Value2 = retYearMonth(ds.Tables[0].Rows[i]["NO_OF_YEARS_AT_CURRENT_EMPLOYMENT"].ToString());

                                                oexcelRange = ((Excel.Range)oSheet.Cells[42, 8]);
                                                //oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                oexcelRange.Value2 = ds.Tables[0].Rows[i]["DEPARTMENT"].ToString();

                                                oexcelRange = ((Excel.Range)oSheet.Cells[43, 3]);
                                                //oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                oexcelRange.Value2 = ds.Tables[0].Rows[i]["FOR_SELF_EMPLOYED_TYPE_OF_ORGANIZATION"].ToString();

                                                oexcelRange = ((Excel.Range)oSheet.Cells[43, 8]);
                                                //oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                oexcelRange.Value2 = ds.Tables[0].Rows[i]["OTHER_NATURE_OF_BUSINESS"].ToString();

                                                oexcelRange = ((Excel.Range)oSheet.Cells[44, 3]);
                                                //oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                oexcelRange.Value2 = ds.Tables[0].Rows[i]["COMPANY_NAME"].ToString();

                                                oexcelRange = ((Excel.Range)oSheet.Cells[45, 3]);
                                                //oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                oexcelRange.Value2 = ds.Tables[0].Rows[i]["OFF_ADD_LINE"].ToString();

                                                oexcelRange = ((Excel.Range)oSheet.Cells[46, 3]);
                                                //oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                oexcelRange.Value2 = ds.Tables[0].Rows[i]["LAND_MARK_OBSERVED"].ToString();

                                                oexcelRange = ((Excel.Range)oSheet.Cells[47, 3]);
                                                //oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                oexcelRange.Value2 = ds.Tables[0].Rows[i]["SPECIAL_INSTRUCTIONS"].ToString();

                                                oexcelRange = ((Excel.Range)oSheet.Cells[48, 3]);
                                                //oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                oexcelRange.Value2 = ds.Tables[0].Rows[i]["SPK_TO"].ToString();

                                                oexcelRange = ((Excel.Range)oSheet.Cells[48, 8]);
                                                //oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                oexcelRange.Value2 = ds.Tables[0].Rows[i]["OTHERS_DESIGNATION"].ToString();

                                                oexcelRange = ((Excel.Range)oSheet.Cells[49, 3]);
                                                //oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                oexcelRange.Value2 = ds.Tables[0].Rows[i]["REL_WITH_APPLICANT"].ToString();

                                                if (ds1 != null)
                                                {
                                                    if (ds1.Tables[0].Rows.Count > 0)
                                                    {
                                                        for (int j = 0; j < ds1.Tables[0].Rows.Count; j++)
                                                        {
                                                            switch (j + 1)
                                                            {
                                                                case 1:
                                                                    if (ds1.Tables[0].Rows[j]["ATTEMPT_DATE_TIME"].ToString() != "")
                                                                    {
                                                                        oexcelRange = ((Excel.Range)oSheet.Cells[53, 3]);
                                                                        oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                                        oexcelRange.Value2 = Convert.ToDateTime(ds1.Tables[0].Rows[j]["ATTEMPT_DATE_TIME"]).ToString("dd/MM/yyyy");

                                                                        oexcelRange = ((Excel.Range)oSheet.Cells[54, 3]);
                                                                        oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                                        oexcelRange.Value2 = Convert.ToDateTime(ds1.Tables[0].Rows[j]["ATTEMPT_DATE_TIME"]).ToString("hh:mm tt");
                                                                    }
                                                                    oexcelRange = ((Excel.Range)oSheet.Cells[51, 3]);
                                                                    oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                                    oexcelRange.Value2 = ds1.Tables[0].Rows[j]["TELEPHONE_NO"].ToString();

                                                                    oexcelRange = ((Excel.Range)oSheet.Cells[55, 3]);
                                                                    oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                                    oexcelRange.Value2 = ds1.Tables[0].Rows[j]["REMARK"].ToString();
                                                                    break;
                                                                case 2:
                                                                    if (ds1.Tables[0].Rows[j]["ATTEMPT_DATE_TIME"].ToString() != "")
                                                                    {
                                                                        oexcelRange = ((Excel.Range)oSheet.Cells[53, 5]);
                                                                        oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                                        oexcelRange.Value2 = Convert.ToDateTime(ds1.Tables[0].Rows[j]["ATTEMPT_DATE_TIME"]).ToString("dd/MM/yyyy");

                                                                        oexcelRange = ((Excel.Range)oSheet.Cells[54, 5]);
                                                                        oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                                        oexcelRange.Value2 = Convert.ToDateTime(ds1.Tables[0].Rows[j]["ATTEMPT_DATE_TIME"]).ToString("hh:mm tt");
                                                                    }
                                                                    oexcelRange = ((Excel.Range)oSheet.Cells[51, 5]);
                                                                    oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                                    oexcelRange.Value2 = ds1.Tables[0].Rows[j]["TELEPHONE_NO"].ToString();

                                                                    oexcelRange = ((Excel.Range)oSheet.Cells[55, 5]);
                                                                    oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                                    oexcelRange.Value2 = ds1.Tables[0].Rows[j]["REMARK"].ToString();
                                                                    break;
                                                                case 3:
                                                                    if (ds1.Tables[0].Rows[j]["ATTEMPT_DATE_TIME"].ToString() != "")
                                                                    {
                                                                        oexcelRange = ((Excel.Range)oSheet.Cells[53, 7]);
                                                                        oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                                        oexcelRange.Value2 = Convert.ToDateTime(ds1.Tables[0].Rows[j]["ATTEMPT_DATE_TIME"]).ToString("dd/MM/yyyy");

                                                                        oexcelRange = ((Excel.Range)oSheet.Cells[54, 7]);
                                                                        oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                                        oexcelRange.Value2 = Convert.ToDateTime(ds1.Tables[0].Rows[j]["ATTEMPT_DATE_TIME"]).ToString("hh:mm tt");
                                                                    }
                                                                    oexcelRange = ((Excel.Range)oSheet.Cells[51, 7]);
                                                                    oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                                    oexcelRange.Value2 = ds1.Tables[0].Rows[j]["TELEPHONE_NO"].ToString();

                                                                    oexcelRange = ((Excel.Range)oSheet.Cells[55, 7]);
                                                                    oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                                    oexcelRange.Value2 = ds1.Tables[0].Rows[j]["REMARK"].ToString();
                                                                    break;
                                                                case 4:
                                                                    if (ds1.Tables[0].Rows[j]["ATTEMPT_DATE_TIME"].ToString() != "")
                                                                    {
                                                                        oexcelRange = ((Excel.Range)oSheet.Cells[53, 8]);
                                                                        oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                                        oexcelRange.Value2 = Convert.ToDateTime(ds1.Tables[0].Rows[j]["ATTEMPT_DATE_TIME"]).ToString("dd/MM/yyyy");

                                                                        oexcelRange = ((Excel.Range)oSheet.Cells[54, 8]);
                                                                        oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                                        oexcelRange.Value2 = Convert.ToDateTime(ds1.Tables[0].Rows[j]["ATTEMPT_DATE_TIME"]).ToString("hh:mm tt");
                                                                    }
                                                                    oexcelRange = ((Excel.Range)oSheet.Cells[51, 8]);
                                                                    oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                                    oexcelRange.Value2 = ds1.Tables[0].Rows[j]["TELEPHONE_NO"].ToString();

                                                                    oexcelRange = ((Excel.Range)oSheet.Cells[55, 8]);
                                                                    oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                                    oexcelRange.Value2 = ds1.Tables[0].Rows[j]["REMARK"].ToString();
                                                                    break;
                                                                case 5:
                                                                    if (ds1.Tables[0].Rows[j]["ATTEMPT_DATE_TIME"].ToString() != "")
                                                                    {
                                                                        oexcelRange = ((Excel.Range)oSheet.Cells[53, 9]);
                                                                        oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                                        oexcelRange.Value2 = Convert.ToDateTime(ds1.Tables[0].Rows[j]["ATTEMPT_DATE_TIME"]).ToString("dd/MM/yyyy");

                                                                        oexcelRange = ((Excel.Range)oSheet.Cells[54, 9]);
                                                                        oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                                        oexcelRange.Value2 = Convert.ToDateTime(ds1.Tables[0].Rows[j]["ATTEMPT_DATE_TIME"]).ToString("hh:mm tt");
                                                                    }
                                                                    oexcelRange = ((Excel.Range)oSheet.Cells[51, 9]);
                                                                    oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                                    oexcelRange.Value2 = ds1.Tables[0].Rows[j]["TELEPHONE_NO"].ToString();

                                                                    oexcelRange = ((Excel.Range)oSheet.Cells[55, 9]);
                                                                    oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                                    oexcelRange.Value2 = ds1.Tables[0].Rows[j]["REMARK"].ToString();
                                                                    break;
                                                            }
                                                        }
                                                    }
                                                }
                                                ds1.Clear();

                                                oexcelRange = ((Excel.Range)oSheet.Cells[57, 3]);
                                                //oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                oexcelRange.Value2 = ds.Tables[0].Rows[i]["status_name"].ToString();

                                                oexcelRange = ((Excel.Range)oSheet.Cells[58, 3]);
                                                //oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                oexcelRange.Value2 = ds.Tables[0].Rows[i]["Any_Info"].ToString();//*

                                                //SUMMARY                                           
                                                switch (ds.Tables[0].Rows[i]["CASE_STATUS_ID"].ToString())
                                                {
                                                    case "1":   //Positive
                                                    case "8":   //Accept
                                                       
                                                        oexcelRange = ((Excel.Range)oSheet1.Cells[48, 10]);
                                                        oexcelRange.HorizontalAlignment = HorizontalAlign.Center;
                                                        oexcelRange.BorderAround(LineStyle.SingleLine, XlBorderWeight.xlMedium, XlColorIndex.xlColorIndexAutomatic, oMissing);
                                                        oexcelRange.Hyperlinks.Add(oexcelRange, oBook.FullName, "'" + oSheet.Name + "'" + "!A1", oMissing, "");
                                                        oexcelRange.Font.Bold = true;
                                                        oexcelRange.Font.Size = 11;
                                                        oexcelRange.Value2 = "X";
                                                        break;
                                                    case "2":   //Negative
                                                    case "9":   //Decline
                                                        
                                                        oexcelRange = ((Excel.Range)oSheet1.Cells[50, 10]);
                                                        oexcelRange.HorizontalAlignment = HorizontalAlign.Center;
                                                        oexcelRange.BorderAround(LineStyle.SingleLine, XlBorderWeight.xlMedium, XlColorIndex.xlColorIndexAutomatic, oMissing);
                                                        oexcelRange.Hyperlinks.Add(oexcelRange, oBook.FullName, "'" + oSheet.Name + "'" + "!A1", oMissing, "");
                                                        oexcelRange.Font.Bold = true;
                                                        oexcelRange.Font.Size = 11;
                                                        oexcelRange.Value2 = "X";
                                                        break;
                                                    case "3":   //Neutral
                                                    case "10":  //ReferTo Bank                                                        

                                                        oexcelRange = ((Excel.Range)oSheet1.Cells[52, 10]);
                                                        oexcelRange.HorizontalAlignment = HorizontalAlign.Center;
                                                        oexcelRange.BorderAround(LineStyle.SingleLine, XlBorderWeight.xlMedium, XlColorIndex.xlColorIndexAutomatic, oMissing);
                                                        oexcelRange.Hyperlinks.Add(oexcelRange, oBook.FullName, "'" + oSheet.Name + "'" + "!A1", oMissing, "");
                                                        oexcelRange.Font.Bold = true;
                                                        oexcelRange.Font.Size = 11;
                                                        oexcelRange.Value2 = "X";
                                                        break;
                                                    default:
                                                        break;

                                                }
                                                break;
                                            default:

                                                break;
                                        }
                                    }
                                    else
                                        conn.Close();
                                }
                                oSheet1 = (Excel._Worksheet)oBook.Worksheets["Summary"];
                                oSheet1.Visible = Excel.XlSheetVisibility.xlSheetVisible;
                                oSheet1.Unprotect(oMissing);

                                oexcelRange = ((Excel.Range)oSheet1.Cells[6, 5]);
                                oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                oexcelRange.Value2 = ds.Tables[0].Rows[0]["APPLICANT_NAME"].ToString();

                                oexcelRange = ((Excel.Range)oSheet1.Cells[6, 12]);
                                oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                oexcelRange.Value2 = ds.Tables[0].Rows[0]["CASE_REC_DATETIME"].ToString();

                                oexcelRange = ((Excel.Range)oSheet1.Cells[7, 5]);
                                oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                oexcelRange.Value2 = ds.Tables[0].Rows[0]["REF_NO"].ToString();

                                oexcelRange = ((Excel.Range)oSheet1.Cells[8, 5]);
                                oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                oexcelRange.Value2 = ds.Tables[0].Rows[0]["TITLE"].ToString();

                                ArrayList arrTotVer = new ArrayList();
                                arrTotVer.Add("RV");
                                arrTotVer.Add("BV");
                                arrTotVer.Add("RT");
                                arrTotVer.Add("BT");
                                arrTotVer.Add("PRV");
                                arrTotVer.Add("PRTV");
                               // int iIdx = 26;
                                string strRV = "N";
                                string strBV = "N";
                                string strRT = "N";
                                string strBT = "N";
                                string strPRV = "N";
                                string strPRTV = "N";
                                for (int i = 0; i < arrTotVer.Count; i++)
                                {
                                    for (int j = 0; j < arrVerType.Count; j++)
                                    {
                                        switch (arrTotVer[i].ToString())
                                        {

                                            case "RV":
                                                if (arrVerType[j].ToString() == "RV")
                                                {
                                                    strRV = "Y";
                                                }
                                                break;
                                            case "BV":
                                                if (arrVerType[j].ToString() == "BV")
                                                {
                                                    strBV = "Y";
                                                }
                                                break;
                                            case "RT":
                                                if (arrVerType[j].ToString() == "RT")
                                                {
                                                    strRT = "Y";
                                                }
                                                break;
                                            case "BT":
                                                if (arrVerType[j].ToString() == "BT")
                                                {
                                                    strBT = "Y";
                                                }
                                                break;
                                            case "PRV":
                                                if (arrVerType[j].ToString() == "PRV")
                                                {
                                                    strPRV = "Y";
                                                }
                                                break;
                                            case "PRTV":
                                                if (arrVerType[j].ToString() == "PRTV")
                                                {
                                                    strPRTV = "Y";
                                                }
                                                break;

                                        }
                                    }
                                }

                                    if (strRV == "Y")
                                    {
                                        oexcelRange = ((Excel.Range)oSheet1.Cells[26, 6]);
                                        oexcelRange.HorizontalAlignment = HorizontalAlign.Center;
                                        oexcelRange.BorderAround(LineStyle.SingleLine, XlBorderWeight.xlMedium, XlColorIndex.xlColorIndexAutomatic, oMissing);
                                        oexcelRange.Font.Bold = true;
                                        oexcelRange.Font.Size = 11;
                                        oexcelRange.Value2 = "X";
                                    }
                                    else
                                    {
                                        oexcelRange = ((Excel.Range)oSheet1.Cells[26, 8]);
                                        oexcelRange.HorizontalAlignment = HorizontalAlign.Center;
                                        oexcelRange.BorderAround(LineStyle.SingleLine, XlBorderWeight.xlMedium, XlColorIndex.xlColorIndexAutomatic, oMissing);
                                        oexcelRange.Font.Bold = true;
                                        oexcelRange.Font.Size = 11;
                                        oexcelRange.Value2 = "X";
                                    }

                                    if (strBV == "Y")
                                    {
                                        oexcelRange = ((Excel.Range)oSheet1.Cells[33, 6]);
                                        oexcelRange.HorizontalAlignment = HorizontalAlign.Center;
                                        oexcelRange.BorderAround(LineStyle.SingleLine, XlBorderWeight.xlMedium, XlColorIndex.xlColorIndexAutomatic, oMissing);
                                        oexcelRange.Font.Bold = true;
                                        oexcelRange.Font.Size = 11;
                                        oexcelRange.Value2 = "X";
                                    }
                                    else
                                    {
                                        oexcelRange = ((Excel.Range)oSheet1.Cells[33, 8]);
                                        oexcelRange.HorizontalAlignment = HorizontalAlign.Center;
                                        oexcelRange.BorderAround(LineStyle.SingleLine, XlBorderWeight.xlMedium, XlColorIndex.xlColorIndexAutomatic, oMissing);
                                        oexcelRange.Font.Bold = true;
                                        oexcelRange.Font.Size = 11;
                                        oexcelRange.Value2 = "X";
                                    }

                                    if (strRT == "Y")
                                    {
                                        oexcelRange = ((Excel.Range)oSheet1.Cells[40, 6]);
                                        oexcelRange.HorizontalAlignment = HorizontalAlign.Center;
                                        oexcelRange.BorderAround(LineStyle.SingleLine, XlBorderWeight.xlMedium, XlColorIndex.xlColorIndexAutomatic, oMissing);
                                        oexcelRange.Font.Bold = true;
                                        oexcelRange.Font.Size = 11;
                                        oexcelRange.Value2 = "X";
                                    }
                                    else
                                    {
                                        oexcelRange = ((Excel.Range)oSheet1.Cells[40, 8]);
                                        oexcelRange.HorizontalAlignment = HorizontalAlign.Center;
                                        oexcelRange.BorderAround(LineStyle.SingleLine, XlBorderWeight.xlMedium, XlColorIndex.xlColorIndexAutomatic, oMissing);
                                        oexcelRange.Font.Bold = true;
                                        oexcelRange.Font.Size = 11;
                                        oexcelRange.Value2 = "X";
                                    }

                                    if (strBT == "Y")
                                    {
                                        oexcelRange = ((Excel.Range)oSheet1.Cells[47, 6]);
                                        oexcelRange.HorizontalAlignment = HorizontalAlign.Center;
                                        oexcelRange.BorderAround(LineStyle.SingleLine, XlBorderWeight.xlMedium, XlColorIndex.xlColorIndexAutomatic, oMissing);
                                        oexcelRange.Font.Bold = true;
                                        oexcelRange.Font.Size = 11;
                                        oexcelRange.Value2 = "X";
                                    }
                                    else
                                    {
                                        oexcelRange = ((Excel.Range)oSheet1.Cells[47, 8]);
                                        oexcelRange.HorizontalAlignment = HorizontalAlign.Center;
                                        oexcelRange.BorderAround(LineStyle.SingleLine, XlBorderWeight.xlMedium, XlColorIndex.xlColorIndexAutomatic, oMissing);
                                        oexcelRange.Font.Bold = true;
                                        oexcelRange.Font.Size = 11;
                                        oexcelRange.Value2 = "X";
                                    }

                                    if (strPRV == "Y")
                                    {
                                        oexcelRange = ((Excel.Range)oSheet1.Cells[54, 6]);
                                        oexcelRange.HorizontalAlignment = HorizontalAlign.Center;
                                        oexcelRange.BorderAround(LineStyle.SingleLine, XlBorderWeight.xlMedium, XlColorIndex.xlColorIndexAutomatic, oMissing);
                                        oexcelRange.Font.Bold = true;
                                        oexcelRange.Font.Size = 11;
                                        oexcelRange.Value2 = "X";
                                    }
                                    else
                                    {
                                        oexcelRange = ((Excel.Range)oSheet1.Cells[54, 8]);
                                        oexcelRange.HorizontalAlignment = HorizontalAlign.Center;
                                        oexcelRange.BorderAround(LineStyle.SingleLine, XlBorderWeight.xlMedium, XlColorIndex.xlColorIndexAutomatic, oMissing);
                                        oexcelRange.Font.Bold = true;
                                        oexcelRange.Font.Size = 11;
                                        oexcelRange.Value2 = "X";
                                    }

                                    //if (strPRTV == "Y")
                                    //{
                                    //    oexcelRange = ((Excel.Range)oSheet1.Cells[54, 6]);
                                    //    oexcelRange.HorizontalAlignment = HorizontalAlign.Center;
                                    //    oexcelRange.BorderAround(LineStyle.SingleLine, XlBorderWeight.xlMedium, XlColorIndex.xlColorIndexAutomatic, oMissing);
                                    //    oexcelRange.Font.Bold = true;
                                    //    oexcelRange.Font.Size = 11;
                                    //    oexcelRange.Value2 = "X";
                                    //}
                                    //else
                                    //{
                                    //    oexcelRange = ((Excel.Range)oSheet1.Cells[54, 8]);
                                    //    oexcelRange.HorizontalAlignment = HorizontalAlign.Center;
                                    //    oexcelRange.BorderAround(LineStyle.SingleLine, XlBorderWeight.xlMedium, XlColorIndex.xlColorIndexAutomatic, oMissing);
                                    //    oexcelRange.Font.Bold = true;
                                    //    oexcelRange.Font.Size = 11;
                                    //    oexcelRange.Value2 = "X";
                                    //}
                            }   //if (ds.Tables[0].Rows.Count > 0)
                        }       //(ds != null)
                        ds.Clear();
                        ///---------------------
                        oBook.Save();                       
                        
                        //saving excel sheet
                        oSheet = null;
                        oBook.Close(false, oMissing, false);
                        oBook = null;
                        oBooks.Close();
                        oBooks = null;

                        oExcelApp.Quit();
                        oExcelApp = null;

                        hplDownload.Visible = true;   
                        hplDownload.NavigateUrl = ConfigurationManager.AppSettings["FtpPath"] + "//CC//" + Session["UserName"].ToString() + "//" + strDateTime + "//";
                    }

                    catch (Exception exp)
                    {
                        conn.Close();
                        throw new Exception(exp.Message);
                    }

                }
                conn.Close();
            }
        }
        catch (Exception exp)
        {
            throw new Exception(exp.Message);
            //lblMsg.Text = exp.Message;
        }
    }

    public void GetExport(string strFormat, String[] arrCaseID)
    {
        if (ddlSelectFormat.SelectedValue.ToString() == "1" || ddlSelectFormat1.SelectedValue.ToString() == "1")
            GenerateExcelStandardFormat(arrCaseID);
        else if (ddlSelectFormat.SelectedValue.ToString() == "3" || ddlSelectFormat1.SelectedValue.ToString() == "3")
            GenerateExcelBarclaysFormat(arrCaseID);
        else if (ddlSelectFormat.SelectedValue.ToString() == "2" || ddlSelectFormat1.SelectedValue.ToString() == "2")
            GeneratePDF(arrCaseID);
        else if (ddlSelectFormat.SelectedValue.ToString() == "0" && ddlSelectFormat1.SelectedValue.ToString() == "0")
        {
            lblMsg.Visible = true;
            lblMsg.Text = "Please select format.";
            hplDownload.Visible = false;
            hplDownload.NavigateUrl = "";
        }
    }

    public void btnExport_Click(object sender, EventArgs e)
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
                if(ddlSelectFormat.SelectedIndex!=0)
                    GetExport(ddlSelectFormat.SelectedValue.ToString(), arrCaseID);
                else if (ddlSelectFormat1.SelectedIndex != 0)
                    GetExport(ddlSelectFormat1.SelectedValue.ToString(), arrCaseID);
                lblMsg.Visible = true;
                lblMsg.Text = "Export completed successfully.";
                hplDownload.Visible = true;                
            }
            else
            {
                lblMsg.Visible = true;
                lblMsg.Text = "Please select case to Export.";
                hplDownload.Visible = false;
                hplDownload.NavigateUrl = "";
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
    protected void cvSelectFormat_ServerValidate(object source, ServerValidateEventArgs args)
    {
        if (source.ToString() == "0")
        {
            lblMsg.Visible = true;
            lblMsg.Text = "Please select format.";
        }                
    }

    //protected void ddlSelectFormat_DataBound(object sender, EventArgs e)
    //{
    //    ddlSelectFormat.Items.Insert(0, new ListItem("Select", "0"));
    //}
}
