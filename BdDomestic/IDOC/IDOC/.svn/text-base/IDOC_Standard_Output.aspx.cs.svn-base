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
using Excel;
using Microsoft.Office.Core;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using Excel;
using Microsoft.Office.Core;
using System.Text;
using System.IO;

public partial class IDOC_IDOC_Standard_Output : System.Web.UI.Page
{
    CCommon objCmn = new CCommon();
    CIDocVerification objIDocVer = new CIDocVerification();
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
            String strCentreID = Session["CentreId"].ToString();
            String strClientID = Session["ClientId"].ToString();
            string ToDate = "";
            string FromDate = "";

            bool isValidDates = true;
            if (txtFromDate.Text.Trim() != "" && txtToDate.Text.Trim() != "")
            {
                DateTime dtFrom;
                DateTime dtTo;
                dtFrom = Convert.ToDateTime(objCmn.strDate(txtFromDate.Text.Trim()));
                dtTo = Convert.ToDateTime(objCmn.strDate(txtToDate.Text.Trim()));

                FromDate = objCmn.strDate(txtFromDate.Text.Trim());
                ToDate = Convert.ToDateTime(objCmn.strDate(txtToDate.Text.Trim())).AddDays(1.0).ToString("dd-MMM-yyyy");

                hdFromDate.Value = FromDate;
                hdToDate.Value = ToDate;
                if (dtFrom > dtTo)
                {
                    isValidDates = false;
                    lblMsg.Visible = true;
                    lblMsg.Text = "From date must be less than to date.";
                }
            }
            if (isValidDates == true)
            {
                ToDate = Convert.ToDateTime(objCmn.strDate(txtToDate.Text.Trim())).AddDays(1.0).ToString("dd-MMM-yyyy");
                if (strCentreID != "" && strClientID != "")
                {
                    //to get total no of records......
                    string sSql = "SELECT Count(*) as TotalCount FROM [CPV_IDOC_CASE_DETAILS] " +
                                  "WHERE (([SEND_DATETIME] IS NOT NULL) AND ([CENTRE_ID] = '" + strCentreID + "') AND ([CLIENT_ID] = '" + strClientID + "')and (SEND_DATETIME >='" + FromDate + "' and SEND_DATETIME<'" + ToDate + "' ))";

                    OleDbDataReader oledbRead;
                    oledbRead = OleDbHelper.ExecuteReader(objCmn.ConnectionString, CommandType.Text, sSql);
                    if (oledbRead.Read() == true)
                        lblCaseCount.Text = "Number of cases : " + oledbRead["TotalCount"].ToString();

                    oledbRead.Close();
                    ///-----------------

                    //sdsOutput.SelectCommand = "SELECT [CASE_ID], ISNULL(FIRST_NAME + ' ', '') +ISNULL(MIDDLE_NAME + ' ', '') + ISNULL(LAST_NAME + ' ', '') AS [APPLICANT_NAME], " +
                    //                          " Convert(varchar(24),CASE_REC_DATETIME,103)+ ' ' + LTRIM(SUBSTRING(CONVERT( VARCHAR(20),CASE_REC_DATETIME, 22), 10, 5) " +
                    //                          " + RIGHT(CONVERT(VARCHAR(20), CASE_REC_DATETIME, 22), 3))as [CASE_REC_DATETIME], " +
                    //                          " Convert(varchar(24),SEND_DATETIME,103)+ ' ' + LTRIM(SUBSTRING(CONVERT( VARCHAR(20),SEND_DATETIME, 22), 10, 5) " +
                    //                          " + RIGHT(CONVERT(VARCHAR(20), SEND_DATETIME, 22), 3))as [SEND_DATETIME] " +                                      
                    //                          " FROM [CPV_IDOC_CASE_DETAILS] " +
                    //                          "WHERE (([SEND_DATETIME] IS NOT NULL) AND ([CENTRE_ID] = '" + strCentreID + "') AND ([CLIENT_ID] = '" + strClientID + "')and (SEND_DATETIME >='" + objCmn.strDate(txtFromDate.Text.Trim()) + "' and SEND_DATETIME<'" + ToDate + "' ))";
                    gvOutput.DataBind();
                    if (gvOutput.Rows.Count > 0)
                        pnlView.Visible = true;
                    else
                    {
                        pnlView.Visible = false;
                        lblMsg.Visible = true;
                        lblMsg.Text = "Record not found.";
                    }

                }
            }
        }
        catch(Exception ex)
        {
            lblMsg.Visible = true;
            lblMsg.Text = "Error while generating report: " + ex.Message; 
        }
        //try catch is added by supriya on 14th Nov2007 

    }

    protected void btnExcelReport_Click(object sender, EventArgs e)
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
                GenerateExcel(arrCaseID);
                gvOutput.DataBind();
                //lblMsg.Visible = true;                
                //lblMsg.Text = "Export completed successfully";
                //hplDownload.Visible = true;
                //hplDownload.NavigateUrl = ConfigurationManager.AppSettings["FtpPath"] +  "//IDOC//" + Session["UserName"].ToString() + "//";
            }
            else
            {
                lblMsg.Visible = true;
                lblMsg.Text = "Please select case to assign";
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
            String strCentreID = Session["CentreId"].ToString(); //"1011";"1011";
            String strClientID = Session["ClientId"].ToString(); //"1013";"10111";
            if (strCentreID != "" && strClientID != "")
            {
                oCmn = new CCommon();
                //dataset for main data
                DataSet ds;
                //dataset for attempt details
                DataSet ds1;
                OleDbConnection conn = new OleDbConnection(oCmn.ConnectionString);
                String strRefID = "";
                string strCaseId = "";
                String strExcel = Server.MapPath("ExcelStdOutputIDOC.xls");
                
                string strMapPath = Server.MapPath("../../ExportToUTI/IDOC/") + Session["UserName"].ToString() + "/";
                string strDateTime = DateTime.Now.ToString("ddMMyyyyhhmmss");

                if (!Directory.Exists(strMapPath + strDateTime))
                    Directory.CreateDirectory(strMapPath + strDateTime);

                foreach (String strCaseID in arrCaseID)
                {
                    String strTypeID = "";
                    try
                    {
                        //getting main data
                        conn.Open();
                        String strSQL = "SELECT distinct(VERIFICATION_TYPE_ID),CASE_ID,REF_NO FROM IDOC_IODC_CASE_OUTPUT_VW " +
                                        " WHERE (CENTRE_ID = '" + strCentreID + "') AND (CLIENT_ID = '" + strClientID + "') " +
                                        " AND (CASE_ID = '" + strCaseID + "') ORDER BY VERIFICATION_TYPE_ID";
                        ds = OleDbHelper.ExecuteDataset(conn, CommandType.Text, strSQL);
                        conn.Close();
                        //excel setting

                        if (ds.Tables[0].Rows.Count > 0)
                            strCaseId = ds.Tables[0].Rows[0]["CASE_ID"].ToString();

                        if (strCaseId != "")
                        {
                            //if (!Directory.Exists(Server.MapPath("../../ExportToUTI/IDOC/" + Session["UserName"].ToString())))
                            //    Directory.CreateDirectory(Server.MapPath("../../ExportToUTI/IDOC/" + Session["UserName"].ToString()));
                            //String strFileName = Server.MapPath("../../ExportToUTI/IDOC/" + Session["UserName"].ToString()) + "/" + strCaseID + ".xls";
                            String strFileName = strMapPath + strDateTime + "/" + strCaseId + ".xls";

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
                                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                                    {
                                        strTypeID = ds.Tables[0].Rows[i]["VERIFICATION_TYPE_ID"].ToString();
                                        strRefID = ds.Tables[0].Rows[0]["REF_NO"].ToString();

                                        //getting attempt details 
                                        conn.Open();

                                        String strSQL1 = "";
                                        if (strTypeID == "7")   //For Bank Statement
                                        {
                                            strSQL1 = "SELECT APPLICANT_NAME,REF_NO,CASE_REC_DATETIME,BANK_NAME,BankAddress,Person_contacted, Cont_Designation_dept,ACCOUNT_CORRECT, " +
                                                      " DOCUMENT_AS_PER_STANDARD,AMOUNT_ON_DOC,FE_REMARK,FE_VISIT_DATE,FULLNAME,STATUS_CODE,CASE_STATUS_ID " +
                                                      " FROM IDOC_IODC_CASE_OUTPUT_VW " +
                                                      " WHERE CASE_ID='" + strCaseID + "' AND VERIFICATION_TYPE_ID='" + strTypeID + "'";
                                        }
                                        else if (strTypeID == "6")  //For ITR
                                        {
                                            strSQL1 = "SELECT APPLICANT_NAME,REF_NO,CASE_REC_DATETIME,TOTAL_INCOME,Pan_correct, computation_correct,Tax_cal_correct," +
                                                    " OK_field_verification,Other_observation,INCOME_CAL_CORRECT," +
                                                    " Is_Fourth_Digit,Are_Digit_Numeric,Is_It_Ten_Digit_Alpha,Alpha_Falls_Under_Ward,Address_Falls_Under_Ward," +
                                                    " Tallied_with,Computer_Record,Inward_register,Blue_register,index_register,Orally_by_clerck, " +
                                                    " Agency_Name,FE_VISIT_DATE,FULLNAME,STATUS_CODE,FE_REMARK,CASE_STATUS_ID " +
                                                    " FROM IDOC_IODC_CASE_OUTPUT_VW " +
                                                    " WHERE CASE_ID='" + strCaseID + "' AND VERIFICATION_TYPE_ID='" + strTypeID + "'";
                                        }
                                        else if (strTypeID == "8" || strTypeID == "5" || strTypeID == "11")  //For Form16 and SalarySlip and Salary Certificate
                                        {
                                            strSQL1 = "SELECT APPLICANT_NAME,REF_NO,VERIFICATION_TYPE,CASE_REC_DATETIME,OFF_NAME,TOTAL_INCOME,Overwriting,Pan_correct,Tan_correcT,computation_correct,Calculation_correct," +
                                                    " Tax_cal_correct,Tax_payble_correct,OK_field_verification,IS_spelling_mistake,Other_observation, " +
                                                    " Person_contacted,Cont_Designation_dept,APP_DESIGNATION,APP_DEPARTMENT,APP_YEAR_IN_SERVICE," +
                                                    " MONTH_INCOME,NO_of_Employee,TYPE_OF_INDUSTRY,ORGANIZATION_SEAL,AUTHORITY_SIGNATURE," +
                                                    " DOCUMENT_AS_PER_STANDARD,DATE_ON_DOC,AMOUNT_ON_DOC,APP_ADDRESS_CORRECT,BUSSINESS_ACTIVITY_SEEN," +
                                                    " STOCK_SIGHTED,NO_OF_EMP_SEEN,NAME_BOARD_SEEN,FE_REMARK,TELE_REMARK,VERIFICATION_TYPE_ID,FE_VISIT_DATE," +
                                                    " ATTEMPT_DATE_TIME,TELEPHONE_NO,REMARK,FULLNAME,STATUS_CODE,CASE_STATUS_ID " +
                                                    " FROM IDOC_IODC_CASE_OUTPUT_VW " +
                                                    " WHERE CASE_ID='" + strCaseID + "' AND VERIFICATION_TYPE_ID='" + strTypeID + "'";
                                        }
                                        else if (strTypeID == "9")  //For RC
                                        {
                                            strSQL1 = "Select APPLICANT_NAME,REF_NO,CASE_REC_DATETIME,Vehicle_Registration_Number,RTO_Office,RC_Details_Confirmed_With,Is_Correct_Registration_No_Of_Vehicle,Is_Vehicle_Personal_Commercial," +
                                                     " Is_Vehicle_Hypothecated,Fuinancer_Name,Registration_Date_As_Per_RC_Register,Transfer_Details,Address_Falls_Under_Jurisdiction_RTO, " +
                                                     " Other_observation,FULLNAME,STATUS_CODE,CASE_STATUS_ID,FE_REMARK,FE_VISIT_DATE " +
                                                     " FROM IDOC_IODC_CASE_OUTPUT_VW " +
                                                     " WHERE CASE_ID='" + strCaseID + "' AND VERIFICATION_TYPE_ID='" + strTypeID + "'";


                                        }

                                        ds1 = OleDbHelper.ExecuteDataset(conn, CommandType.Text, strSQL1);
                                        conn.Close();
                                        if (ds1.Tables[0].Rows.Count > 0)
                                        {
                                            int iRowCellNoSS = 37;
                                            int iRowCellNoSC = 37;
                                            int iRowCellNoF16 = 40;
                                            int iRowCellNoITR = 19;
                                            for (int j = 0; j < ds1.Tables[0].Rows.Count; j++)
                                            {
                                                // SUMMARY
                                                oSheet1 = (Excel._Worksheet)oBook.Worksheets["Summary"];
                                                oSheet1.Visible = Excel.XlSheetVisibility.xlSheetVisible;
                                                oSheet1.Unprotect(oMissing);

                                                //filling excel according to verification type 
                                                switch (Convert.ToInt16(strTypeID))
                                                {
                                                    case 7:
                                                        //Bank statement
                                                        string[] sArrDesgnDept = ds1.Tables[0].Rows[j]["Cont_Designation_dept"].ToString().Split('+');
                                                        string strDesgn = "";
                                                        string strDept = "";
                                                        if (sArrDesgnDept.Length > 0)
                                                        {
                                                            strDesgn = sArrDesgnDept[0].ToString().Trim();
                                                            if (sArrDesgnDept.Length > 1)
                                                            {
                                                                strDept = sArrDesgnDept[1].ToString().Trim();
                                                            }

                                                        }
                                                        oSheet = (Excel._Worksheet)oBook.Worksheets["DV-BS"];
                                                        oSheet.Visible = Excel.XlSheetVisibility.xlSheetVisible;
                                                        oSheet.Unprotect(oMissing);

                                                        oexcelRange = ((Excel.Range)oSheet.Cells[5, 5]);
                                                        //oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                        oexcelRange.Value2 = ds1.Tables[0].Rows[j]["APPLICANT_NAME"].ToString();

                                                        oexcelRange = ((Excel.Range)oSheet.Cells[6, 4]);
                                                        //oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                        oexcelRange.Value2 = ds1.Tables[0].Rows[j]["REF_NO"].ToString();

                                                        oexcelRange = ((Excel.Range)oSheet.Cells[6, 8]);
                                                        //oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                        oexcelRange.Value2 = Convert.ToDateTime(ds1.Tables[0].Rows[j]["CASE_REC_DATETIME"].ToString()).ToString("dd/MM/yyyy hh:mm tt");

                                                        oexcelRange = ((Excel.Range)oSheet.Cells[6, 13]);
                                                        //oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                        oexcelRange.Value2 = "";

                                                        oexcelRange = ((Excel.Range)oSheet.Cells[8, 5]);
                                                        //oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                        oexcelRange.Value2 = ds1.Tables[0].Rows[j]["BANK_NAME"].ToString();

                                                        oexcelRange = ((Excel.Range)oSheet.Cells[9, 5]);
                                                        //oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                        oexcelRange.Value2 = ds1.Tables[0].Rows[j]["BankAddress"].ToString();

                                                        oexcelRange = ((Excel.Range)oSheet.Cells[10, 5]);
                                                        //oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                        oexcelRange.Value2 = ds1.Tables[0].Rows[j]["Person_contacted"].ToString();

                                                        oexcelRange = ((Excel.Range)oSheet.Cells[11, 5]);
                                                        //oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                        oexcelRange.Value2 = strDesgn;

                                                        oexcelRange = ((Excel.Range)oSheet.Cells[11, 12]);
                                                        //oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                        oexcelRange.Value2 = strDept;

                                                        oexcelRange = ((Excel.Range)oSheet.Cells[12, 7]);
                                                        //oexcelRange.HorizontalAlignment = HorizontalAlign.Center;
                                                        oexcelRange.Value2 = ds1.Tables[0].Rows[j]["ACCOUNT_CORRECT"].ToString();

                                                        oexcelRange = ((Excel.Range)oSheet.Cells[12, 12]);
                                                        //oexcelRange.HorizontalAlignment = HorizontalAlign.Center;
                                                        oexcelRange.Value2 = ds1.Tables[0].Rows[j]["DOCUMENT_AS_PER_STANDARD"].ToString();

                                                        oexcelRange = ((Excel.Range)oSheet.Cells[13, 7]);
                                                        //oexcelRange.HorizontalAlignment = HorizontalAlign.Center;
                                                        oexcelRange.Value2 = ds1.Tables[0].Rows[j]["AMOUNT_ON_DOC"].ToString();

                                                        oexcelRange = ((Excel.Range)oSheet.Cells[14, 10]);
                                                        //oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                        oexcelRange.Value2 = ds1.Tables[0].Rows[j]["FE_REMARK"].ToString();

                                                        oexcelRange = ((Excel.Range)oSheet.Cells[17, 4]);
                                                        //oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                        oexcelRange.Value2 = ds1.Tables[0].Rows[j]["STATUS_CODE"].ToString();

                                                        oexcelRange = ((Excel.Range)oSheet.Cells[18, 8]);
                                                        //oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                        oexcelRange.Value2 = ds1.Tables[0].Rows[j]["FULLNAME"].ToString();

                                                        oexcelRange = ((Excel.Range)oSheet.Cells[19, 4]);
                                                        //oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                        oexcelRange.Value2 = ds1.Tables[0].Rows[j]["FE_VISIT_DATE"].ToString();

                                                        break;

                                                    case 8:
                                                    
                                                        //for Form16 
                                                        oSheet = (Excel._Worksheet)oBook.Worksheets["DV-F16"];
                                                        oSheet.Visible = Excel.XlSheetVisibility.xlSheetVisible;
                                                        oSheet.Unprotect(oMissing);
                                                        
                                                        oexcelRange = ((Excel.Range)oSheet.Cells[5, 5]);
                                                        //oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                        oexcelRange.Value2 = ds1.Tables[0].Rows[j]["APPLICANT_NAME"].ToString();

                                                        oexcelRange = ((Excel.Range)oSheet.Cells[6, 5]);
                                                        //oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                        oexcelRange.Value2 = ds1.Tables[0].Rows[j]["REF_NO"].ToString();

                                                        oexcelRange = ((Excel.Range)oSheet.Cells[6, 11]);
                                                        //oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                        oexcelRange.Value2 = Convert.ToDateTime(ds1.Tables[0].Rows[j]["CASE_REC_DATETIME"].ToString()).ToString("dd/MM/yyyy hh:mm tt");

                                                        oexcelRange = ((Excel.Range)oSheet.Cells[7, 5]);
                                                        //oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                        oexcelRange.Value2 = ds1.Tables[0].Rows[j]["OFF_NAME"].ToString();

                                                        oexcelRange = ((Excel.Range)oSheet.Cells[7, 5]);
                                                        //oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                        oexcelRange.Value2 = ds1.Tables[0].Rows[j]["OFF_NAME"].ToString();

                                                        oexcelRange = ((Excel.Range)oSheet.Cells[9, 10]);
                                                        //oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                        oexcelRange.Value2 = ds1.Tables[0].Rows[j]["TOTAL_INCOME"].ToString();

                                                        oexcelRange = ((Excel.Range)oSheet.Cells[10, 10]);
                                                        //oexcelRange.HorizontalAlignment = HorizontalAlign.Center;
                                                        oexcelRange.Value2 = ds1.Tables[0].Rows[j]["Overwriting"].ToString();

                                                        oexcelRange = ((Excel.Range)oSheet.Cells[11, 10]);
                                                        //oexcelRange.HorizontalAlignment = HorizontalAlign.Center;
                                                        oexcelRange.Value2 = ds1.Tables[0].Rows[j]["Pan_correct"].ToString();

                                                        oexcelRange = ((Excel.Range)oSheet.Cells[12, 10]);
                                                        //oexcelRange.HorizontalAlignment = HorizontalAlign.Center;
                                                        oexcelRange.Value2 = ds1.Tables[0].Rows[j]["Tan_correcT"].ToString();

                                                        oexcelRange = ((Excel.Range)oSheet.Cells[13, 10]);
                                                        //oexcelRange.HorizontalAlignment = HorizontalAlign.Center;
                                                        oexcelRange.Value2 = ds1.Tables[0].Rows[j]["computation_correct"].ToString();

                                                        oexcelRange = ((Excel.Range)oSheet.Cells[14, 10]);
                                                        //oexcelRange.HorizontalAlignment = HorizontalAlign.Center;
                                                        oexcelRange.Value2 = ds1.Tables[0].Rows[j]["Calculation_correct"].ToString();

                                                        oexcelRange = ((Excel.Range)oSheet.Cells[15, 10]);
                                                        //oexcelRange.HorizontalAlignment = HorizontalAlign.Center;
                                                        oexcelRange.Value2 = ds1.Tables[0].Rows[j]["Tax_cal_correct"].ToString();

                                                        oexcelRange = ((Excel.Range)oSheet.Cells[16, 10]);
                                                        //oexcelRange.HorizontalAlignment = HorizontalAlign.Center;
                                                        oexcelRange.Value2 = ds1.Tables[0].Rows[j]["Tax_payble_correct"].ToString();

                                                        oexcelRange = ((Excel.Range)oSheet.Cells[17, 10]);
                                                        //oexcelRange.HorizontalAlignment = HorizontalAlign.Center;
                                                        oexcelRange.Value2 = ds1.Tables[0].Rows[j]["OK_field_verification"].ToString();

                                                        oexcelRange = ((Excel.Range)oSheet.Cells[18, 10]);
                                                        //oexcelRange.HorizontalAlignment = HorizontalAlign.Center;
                                                        oexcelRange.Value2 = ds1.Tables[0].Rows[j]["IS_spelling_mistake"].ToString();

                                                        oexcelRange = ((Excel.Range)oSheet.Cells[19, 10]);
                                                        //oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                        oexcelRange.Value2 = ds1.Tables[0].Rows[j]["Other_observation"].ToString();

                                                        oexcelRange = ((Excel.Range)oSheet.Cells[21, 5]);
                                                        //oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                        oexcelRange.Value2 = ds1.Tables[0].Rows[j]["Person_contacted"].ToString();

                                                        oexcelRange = ((Excel.Range)oSheet.Cells[21, 11]);
                                                        //oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                        oexcelRange.Value2 = ds1.Tables[0].Rows[j]["Cont_Designation_dept"].ToString();

                                                        oexcelRange = ((Excel.Range)oSheet.Cells[21, 5]);
                                                        //oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                        oexcelRange.Value2 = ds1.Tables[0].Rows[j]["Person_contacted"].ToString();

                                                        oexcelRange = ((Excel.Range)oSheet.Cells[23, 5]);
                                                        //oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                        oexcelRange.Value2 = ds1.Tables[0].Rows[j]["APP_DESIGNATION"].ToString();

                                                        oexcelRange = ((Excel.Range)oSheet.Cells[23, 11]);
                                                        //oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                        oexcelRange.Value2 = ds1.Tables[0].Rows[j]["APP_DEPARTMENT"].ToString();

                                                        oexcelRange = ((Excel.Range)oSheet.Cells[24, 7]);
                                                        //oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                        oexcelRange.Value2 = ds1.Tables[0].Rows[j]["APP_YEAR_IN_SERVICE"].ToString();

                                                        oexcelRange = ((Excel.Range)oSheet.Cells[24, 12]);
                                                        //oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                        oexcelRange.Value2 = ds1.Tables[0].Rows[j]["MONTH_INCOME"].ToString();

                                                        oexcelRange = ((Excel.Range)oSheet.Cells[25, 7]);
                                                        //oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                        oexcelRange.Value2 = ds1.Tables[0].Rows[j]["NO_OF_EMP_SEEN"].ToString();

                                                        oexcelRange = ((Excel.Range)oSheet.Cells[25, 11]);
                                                        //oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                        oexcelRange.Value2 = ds1.Tables[0].Rows[j]["TYPE_OF_INDUSTRY"].ToString();

                                                        oexcelRange = ((Excel.Range)oSheet.Cells[27, 10]);
                                                        //oexcelRange.HorizontalAlignment = HorizontalAlign.Center;
                                                        oexcelRange.Value2 = ds1.Tables[0].Rows[j]["ORGANIZATION_SEAL"].ToString();

                                                        oexcelRange = ((Excel.Range)oSheet.Cells[28, 10]);
                                                        //oexcelRange.HorizontalAlignment = HorizontalAlign.Center;
                                                        oexcelRange.Value2 = ds1.Tables[0].Rows[j]["AUTHORITY_SIGNATURE"].ToString();

                                                        oexcelRange = ((Excel.Range)oSheet.Cells[29, 10]);
                                                        //oexcelRange.HorizontalAlignment = HorizontalAlign.Center;
                                                        oexcelRange.Value2 = ds1.Tables[0].Rows[j]["DOCUMENT_AS_PER_STANDARD"].ToString();

                                                        oexcelRange = ((Excel.Range)oSheet.Cells[30, 10]);
                                                        //oexcelRange.HorizontalAlignment = HorizontalAlign.Center;
                                                        oexcelRange.Value2 = ds1.Tables[0].Rows[j]["DATE_ON_DOC"].ToString();

                                                        oexcelRange = ((Excel.Range)oSheet.Cells[31, 10]);
                                                        //oexcelRange.HorizontalAlignment = HorizontalAlign.Center;
                                                        oexcelRange.Value2 = ds1.Tables[0].Rows[j]["AMOUNT_ON_DOC"].ToString();

                                                        oexcelRange = ((Excel.Range)oSheet.Cells[32, 10]);
                                                        //oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                        oexcelRange.Value2 = ds1.Tables[0].Rows[j]["APP_ADDRESS_CORRECT"].ToString();

                                                        oexcelRange = ((Excel.Range)oSheet.Cells[34, 6]);
                                                        //oexcelRange.HorizontalAlignment = HorizontalAlign.Center;
                                                        oexcelRange.Value2 = ds1.Tables[0].Rows[j]["BUSSINESS_ACTIVITY_SEEN"].ToString();

                                                        oexcelRange = ((Excel.Range)oSheet.Cells[34, 12]);
                                                        //oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                        oexcelRange.Value2 = ds1.Tables[0].Rows[j]["NO_of_Employee"].ToString();

                                                        oexcelRange = ((Excel.Range)oSheet.Cells[35, 6]);
                                                        //oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                        oexcelRange.Value2 = ds1.Tables[0].Rows[j]["STOCK_SIGHTED"].ToString();

                                                        oexcelRange = ((Excel.Range)oSheet.Cells[35, 12]);
                                                        //oexcelRange.HorizontalAlignment = HorizontalAlign.Center;
                                                        oexcelRange.Value2 = ds1.Tables[0].Rows[j]["NAME_BOARD_SEEN"].ToString();

                                                        oexcelRange = ((Excel.Range)oSheet.Cells[36, 4]);
                                                        //oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                        oexcelRange.Value2 = ds1.Tables[0].Rows[j]["FE_REMARK"].ToString();
                                                        /////////for teleLog ------------------------------------------------
                                                        string[] sArrAttempt = ds1.Tables[0].Rows[j]["ATTEMPT_DATE_TIME"].ToString().Split(' ');
                                                        string strAttemptDate = "";
                                                        string strAttemptTime = "";
                                                        if (sArrAttempt.Length > 0)
                                                        {
                                                            strAttemptDate = sArrAttempt[0].ToString().Trim();
                                                            if (sArrAttempt.Length > 1)
                                                            {
                                                                strAttemptTime = sArrAttempt[1].ToString().Trim() +
                                                                                 sArrAttempt[2].ToString().Trim();
                                                            }
                                                        }
                                                        oexcelRange = ((Excel.Range)oSheet.Cells[iRowCellNoF16, 4]);
                                                        //oexcelRange.HorizontalAlignment = HorizontalAlign.Center;
                                                        oexcelRange.Value2 = strAttemptDate;

                                                        oexcelRange = ((Excel.Range)oSheet.Cells[iRowCellNoF16, 6]);
                                                        //oexcelRange.HorizontalAlignment = HorizontalAlign.Center;
                                                        oexcelRange.Value2 = strAttemptTime;

                                                        oexcelRange = ((Excel.Range)oSheet.Cells[iRowCellNoF16, 8]);
                                                        //oexcelRange.HorizontalAlignment = HorizontalAlign.Center;
                                                        oexcelRange.Value2 = ds1.Tables[0].Rows[j]["TELEPHONE_NO"].ToString();

                                                        oexcelRange = ((Excel.Range)oSheet.Cells[iRowCellNoF16, 10]);
                                                        //oexcelRange.HorizontalAlignment = HorizontalAlign.Center;
                                                        oexcelRange.Value2 = ds1.Tables[0].Rows[j]["REMARK"].ToString();

                                                        ///////////------------------------
                                                        oexcelRange = ((Excel.Range)oSheet.Cells[45, 4]);
                                                        //oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                        oexcelRange.Value2 = ds1.Tables[0].Rows[j]["TELE_REMARK"].ToString();

                                                        oexcelRange = ((Excel.Range)oSheet.Cells[45, 4]);
                                                        //oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                        oexcelRange.Value2 = ds1.Tables[0].Rows[j]["TELE_REMARK"].ToString();

                                                        oexcelRange = ((Excel.Range)oSheet.Cells[45, 4]);
                                                        //oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                        oexcelRange.Value2 = ds1.Tables[0].Rows[j]["TELE_REMARK"].ToString();

                                                        oexcelRange = ((Excel.Range)oSheet.Cells[47, 4]);
                                                        //oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                        oexcelRange.Value2 = ds1.Tables[0].Rows[j]["STATUS_CODE"].ToString();

                                                        oexcelRange = ((Excel.Range)oSheet.Cells[48, 8]);
                                                        //oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                        oexcelRange.Value2 = ds1.Tables[0].Rows[j]["FULLNAME"].ToString();

                                                        oexcelRange = ((Excel.Range)oSheet.Cells[49, 4]);
                                                        //oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                        oexcelRange.Value2 = ds1.Tables[0].Rows[j]["FE_VISIT_DATE"].ToString();

                                                        iRowCellNoF16++;
                                                        break;
                                                    case 5: //For Salary slip
                                                        oSheet = (Excel._Worksheet)oBook.Worksheets["DV-SS"];
                                                        oSheet.Visible = Excel.XlSheetVisibility.xlSheetVisible;
                                                        oSheet.Unprotect(oMissing);

                                                        oexcelRange = ((Excel.Range)oSheet.Cells[5, 5]);
                                                        //oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                        oexcelRange.Value2 = ds1.Tables[0].Rows[j]["APPLICANT_NAME"].ToString();

                                                        oexcelRange = ((Excel.Range)oSheet.Cells[6, 5]);
                                                        //oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                        oexcelRange.Value2 = ds1.Tables[0].Rows[j]["REF_NO"].ToString();

                                                        oexcelRange = ((Excel.Range)oSheet.Cells[6, 11]);
                                                        //oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                        oexcelRange.Value2 = Convert.ToDateTime(ds1.Tables[0].Rows[j]["CASE_REC_DATETIME"].ToString()).ToString("dd/MM/yyyy hh:mm tt");

                                                        oexcelRange = ((Excel.Range)oSheet.Cells[7, 5]);
                                                        //oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                        oexcelRange.Value2 = ds1.Tables[0].Rows[j]["OFF_NAME"].ToString();
                                                        
                                                        oexcelRange = ((Excel.Range)oSheet.Cells[9, 10]);
                                                        //oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                        oexcelRange.Value2 = ds1.Tables[0].Rows[j]["TOTAL_INCOME"].ToString();

                                                        oexcelRange = ((Excel.Range)oSheet.Cells[10, 10]);
                                                        //oexcelRange.HorizontalAlignment = HorizontalAlign.Center;
                                                        oexcelRange.Value2 = ds1.Tables[0].Rows[j]["Overwriting"].ToString();
                                                                                                                
                                                        oexcelRange = ((Excel.Range)oSheet.Cells[11, 10]);
                                                        //oexcelRange.HorizontalAlignment = HorizontalAlign.Center;
                                                        oexcelRange.Value2 = ds1.Tables[0].Rows[j]["computation_correct"].ToString();

                                                        oexcelRange = ((Excel.Range)oSheet.Cells[12, 10]);
                                                        //oexcelRange.HorizontalAlignment = HorizontalAlign.Center;
                                                        oexcelRange.Value2 = ds1.Tables[0].Rows[j]["Calculation_correct"].ToString();

                                                        oexcelRange = ((Excel.Range)oSheet.Cells[13, 10]);
                                                        //oexcelRange.HorizontalAlignment = HorizontalAlign.Center;
                                                        oexcelRange.Value2 = ds1.Tables[0].Rows[j]["Tax_cal_correct"].ToString();

                                                        oexcelRange = ((Excel.Range)oSheet.Cells[14, 10]);
                                                        //oexcelRange.HorizontalAlignment = HorizontalAlign.Center;
                                                        oexcelRange.Value2 = ds1.Tables[0].Rows[j]["OK_field_verification"].ToString();

                                                        oexcelRange = ((Excel.Range)oSheet.Cells[15, 10]);
                                                        //oexcelRange.HorizontalAlignment = HorizontalAlign.Center;
                                                        oexcelRange.Value2 = ds1.Tables[0].Rows[j]["IS_spelling_mistake"].ToString();

                                                        oexcelRange = ((Excel.Range)oSheet.Cells[16, 10]);
                                                        //oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                        oexcelRange.Value2 = ds1.Tables[0].Rows[j]["Other_observation"].ToString();

                                                        oexcelRange = ((Excel.Range)oSheet.Cells[18, 5]);
                                                        //oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                        oexcelRange.Value2 = ds1.Tables[0].Rows[j]["Person_contacted"].ToString();

                                                        oexcelRange = ((Excel.Range)oSheet.Cells[18, 11]);
                                                        //oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                        oexcelRange.Value2 = ds1.Tables[0].Rows[j]["Cont_Designation_dept"].ToString();

                                                       
                                                        oexcelRange = ((Excel.Range)oSheet.Cells[20, 5]);
                                                        //oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                        oexcelRange.Value2 = ds1.Tables[0].Rows[j]["APP_DESIGNATION"].ToString();

                                                        oexcelRange = ((Excel.Range)oSheet.Cells[20, 11]);
                                                        //oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                        oexcelRange.Value2 = ds1.Tables[0].Rows[j]["APP_DEPARTMENT"].ToString();

                                                        oexcelRange = ((Excel.Range)oSheet.Cells[21, 7]);
                                                        //oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                        oexcelRange.Value2 = ds1.Tables[0].Rows[j]["APP_YEAR_IN_SERVICE"].ToString();

                                                        oexcelRange = ((Excel.Range)oSheet.Cells[21, 12]);
                                                        //oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                        oexcelRange.Value2 = ds1.Tables[0].Rows[j]["MONTH_INCOME"].ToString();

                                                        oexcelRange = ((Excel.Range)oSheet.Cells[22, 7]);
                                                        //oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                        oexcelRange.Value2 = ds1.Tables[0].Rows[j]["NO_OF_EMP_SEEN"].ToString();

                                                        oexcelRange = ((Excel.Range)oSheet.Cells[22, 11]);
                                                        //oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                        oexcelRange.Value2 = ds1.Tables[0].Rows[j]["TYPE_OF_INDUSTRY"].ToString();

                                                        oexcelRange = ((Excel.Range)oSheet.Cells[24, 10]);
                                                        //oexcelRange.HorizontalAlignment = HorizontalAlign.Center;
                                                        oexcelRange.Value2 = ds1.Tables[0].Rows[j]["ORGANIZATION_SEAL"].ToString();

                                                        oexcelRange = ((Excel.Range)oSheet.Cells[25, 10]);
                                                        //oexcelRange.HorizontalAlignment = HorizontalAlign.Center;
                                                        oexcelRange.Value2 = ds1.Tables[0].Rows[j]["AUTHORITY_SIGNATURE"].ToString();

                                                        oexcelRange = ((Excel.Range)oSheet.Cells[26, 10]);
                                                        //oexcelRange.HorizontalAlignment = HorizontalAlign.Center;
                                                        oexcelRange.Value2 = ds1.Tables[0].Rows[j]["DOCUMENT_AS_PER_STANDARD"].ToString();

                                                        oexcelRange = ((Excel.Range)oSheet.Cells[27, 10]);
                                                        //oexcelRange.HorizontalAlignment = HorizontalAlign.Center;
                                                        oexcelRange.Value2 = ds1.Tables[0].Rows[j]["DATE_ON_DOC"].ToString();

                                                        oexcelRange = ((Excel.Range)oSheet.Cells[28, 10]);
                                                        //oexcelRange.HorizontalAlignment = HorizontalAlign.Center;
                                                        oexcelRange.Value2 = ds1.Tables[0].Rows[j]["AMOUNT_ON_DOC"].ToString();

                                                        oexcelRange = ((Excel.Range)oSheet.Cells[29, 10]);
                                                        //oexcelRange.HorizontalAlignment = HorizontalAlign.Center;
                                                        oexcelRange.Value2 = ds1.Tables[0].Rows[j]["APP_ADDRESS_CORRECT"].ToString();

                                                        oexcelRange = ((Excel.Range)oSheet.Cells[31, 6]);
                                                        //oexcelRange.HorizontalAlignment = HorizontalAlign.Center;
                                                        oexcelRange.Value2 = ds1.Tables[0].Rows[j]["BUSSINESS_ACTIVITY_SEEN"].ToString();

                                                        oexcelRange = ((Excel.Range)oSheet.Cells[31, 12]);
                                                        //oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                        oexcelRange.Value2 = ds1.Tables[0].Rows[j]["NO_of_Employee"].ToString();

                                                        oexcelRange = ((Excel.Range)oSheet.Cells[32, 6]);
                                                        //oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                        oexcelRange.Value2 = ds1.Tables[0].Rows[j]["STOCK_SIGHTED"].ToString();

                                                        oexcelRange = ((Excel.Range)oSheet.Cells[32, 12]);
                                                        //oexcelRange.HorizontalAlignment = HorizontalAlign.Center;
                                                        oexcelRange.Value2 = ds1.Tables[0].Rows[j]["NAME_BOARD_SEEN"].ToString();

                                                        oexcelRange = ((Excel.Range)oSheet.Cells[33, 4]);
                                                        //oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                        oexcelRange.Value2 = ds1.Tables[0].Rows[j]["FE_REMARK"].ToString();
                                                        /////////for teleLog ------------------------------------------------
                                                        string[] sArrAttemptSS = ds1.Tables[0].Rows[j]["ATTEMPT_DATE_TIME"].ToString().Split(' ');
                                                        string strAttemptDateSS = "";
                                                        string strAttemptTimeSS = "";
                                                        if (sArrAttemptSS.Length > 0)
                                                        {
                                                            strAttemptDateSS = sArrAttemptSS[0].ToString().Trim();
                                                            if (sArrAttemptSS.Length > 1)
                                                            {
                                                                strAttemptTimeSS = sArrAttemptSS[1].ToString().Trim() +
                                                                                 sArrAttemptSS[2].ToString().Trim();
                                                            }
                                                        }
                                                        oexcelRange = ((Excel.Range)oSheet.Cells[iRowCellNoSS, 4]);
                                                        //oexcelRange.HorizontalAlignment = HorizontalAlign.Center;
                                                        oexcelRange.Value2 = strAttemptDateSS;

                                                        oexcelRange = ((Excel.Range)oSheet.Cells[iRowCellNoSS, 6]);
                                                        //oexcelRange.HorizontalAlignment = HorizontalAlign.Center;
                                                        oexcelRange.Value2 = strAttemptTimeSS;

                                                        oexcelRange = ((Excel.Range)oSheet.Cells[iRowCellNoSS, 8]);
                                                        //oexcelRange.HorizontalAlignment = HorizontalAlign.Center;
                                                        oexcelRange.Value2 = ds1.Tables[0].Rows[j]["TELEPHONE_NO"].ToString();

                                                        oexcelRange = ((Excel.Range)oSheet.Cells[iRowCellNoSS, 10]);
                                                        //oexcelRange.HorizontalAlignment = HorizontalAlign.Center;
                                                        oexcelRange.Value2 = ds1.Tables[0].Rows[j]["REMARK"].ToString();

                                                        ///////////------------------------
                                                        oexcelRange = ((Excel.Range)oSheet.Cells[42, 4]);
                                                        //oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                        oexcelRange.Value2 = ds1.Tables[0].Rows[j]["TELE_REMARK"].ToString();
                                                                                                               
                                                        oexcelRange = ((Excel.Range)oSheet.Cells[44, 4]);
                                                        //oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                        oexcelRange.Value2 = ds1.Tables[0].Rows[j]["STATUS_CODE"].ToString();

                                                        oexcelRange = ((Excel.Range)oSheet.Cells[45, 8]);
                                                        //oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                        oexcelRange.Value2 = ds1.Tables[0].Rows[j]["FULLNAME"].ToString();

                                                        oexcelRange = ((Excel.Range)oSheet.Cells[46, 4]);
                                                        //oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                        oexcelRange.Value2 = ds1.Tables[0].Rows[j]["FE_VISIT_DATE"].ToString();

                                                        iRowCellNoSS++;
                                                        break;
                                                    case 11:    //For salary certificate
                                                        oSheet = (Excel._Worksheet)oBook.Worksheets["DV-SC"];
                                                        oSheet.Visible = Excel.XlSheetVisibility.xlSheetVisible;
                                                        oSheet.Unprotect(oMissing);

                                                        oexcelRange = ((Excel.Range)oSheet.Cells[5, 5]);
                                                        //oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                        oexcelRange.Value2 = ds1.Tables[0].Rows[j]["APPLICANT_NAME"].ToString();

                                                        oexcelRange = ((Excel.Range)oSheet.Cells[6, 5]);
                                                        //oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                        oexcelRange.Value2 = ds1.Tables[0].Rows[j]["REF_NO"].ToString();

                                                        oexcelRange = ((Excel.Range)oSheet.Cells[6, 11]);
                                                        //oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                        oexcelRange.Value2 = Convert.ToDateTime(ds1.Tables[0].Rows[j]["CASE_REC_DATETIME"].ToString()).ToString("dd/MM/yyyy hh:mm tt");

                                                        oexcelRange = ((Excel.Range)oSheet.Cells[7, 5]);
                                                        //oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                        oexcelRange.Value2 = ds1.Tables[0].Rows[j]["OFF_NAME"].ToString();

                                                        oexcelRange = ((Excel.Range)oSheet.Cells[9, 10]);
                                                        //oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                        oexcelRange.Value2 = ds1.Tables[0].Rows[j]["TOTAL_INCOME"].ToString();

                                                        oexcelRange = ((Excel.Range)oSheet.Cells[10, 10]);
                                                        //oexcelRange.HorizontalAlignment = HorizontalAlign.Center;
                                                        oexcelRange.Value2 = ds1.Tables[0].Rows[j]["Overwriting"].ToString();

                                                        oexcelRange = ((Excel.Range)oSheet.Cells[11, 10]);
                                                        //oexcelRange.HorizontalAlignment = HorizontalAlign.Center;
                                                        oexcelRange.Value2 = ds1.Tables[0].Rows[j]["computation_correct"].ToString();

                                                        oexcelRange = ((Excel.Range)oSheet.Cells[12, 10]);
                                                        //oexcelRange.HorizontalAlignment = HorizontalAlign.Center;
                                                        oexcelRange.Value2 = ds1.Tables[0].Rows[j]["Calculation_correct"].ToString();

                                                        oexcelRange = ((Excel.Range)oSheet.Cells[13, 10]);
                                                        //oexcelRange.HorizontalAlignment = HorizontalAlign.Center;
                                                        oexcelRange.Value2 = ds1.Tables[0].Rows[j]["Tax_cal_correct"].ToString();

                                                        oexcelRange = ((Excel.Range)oSheet.Cells[14, 10]);
                                                        //oexcelRange.HorizontalAlignment = HorizontalAlign.Center;
                                                        oexcelRange.Value2 = ds1.Tables[0].Rows[j]["OK_field_verification"].ToString();

                                                        oexcelRange = ((Excel.Range)oSheet.Cells[15, 10]);
                                                        //oexcelRange.HorizontalAlignment = HorizontalAlign.Center;
                                                        oexcelRange.Value2 = ds1.Tables[0].Rows[j]["IS_spelling_mistake"].ToString();

                                                        oexcelRange = ((Excel.Range)oSheet.Cells[16, 10]);
                                                        //oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                        oexcelRange.Value2 = ds1.Tables[0].Rows[j]["Other_observation"].ToString();

                                                        oexcelRange = ((Excel.Range)oSheet.Cells[18, 5]);
                                                        //oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                        oexcelRange.Value2 = ds1.Tables[0].Rows[j]["Person_contacted"].ToString();

                                                        oexcelRange = ((Excel.Range)oSheet.Cells[18, 11]);
                                                        //oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                        oexcelRange.Value2 = ds1.Tables[0].Rows[j]["Cont_Designation_dept"].ToString();
                                                                                                               
                                                        oexcelRange = ((Excel.Range)oSheet.Cells[20, 5]);
                                                        //oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                        oexcelRange.Value2 = ds1.Tables[0].Rows[j]["APP_DESIGNATION"].ToString();

                                                        oexcelRange = ((Excel.Range)oSheet.Cells[20, 11]);
                                                        //oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                        oexcelRange.Value2 = ds1.Tables[0].Rows[j]["APP_DEPARTMENT"].ToString();

                                                        oexcelRange = ((Excel.Range)oSheet.Cells[21, 7]);
                                                        //oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                        oexcelRange.Value2 = ds1.Tables[0].Rows[j]["APP_YEAR_IN_SERVICE"].ToString();

                                                        oexcelRange = ((Excel.Range)oSheet.Cells[21, 12]);
                                                        //oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                        oexcelRange.Value2 = ds1.Tables[0].Rows[j]["MONTH_INCOME"].ToString();

                                                        oexcelRange = ((Excel.Range)oSheet.Cells[22, 7]);
                                                        //oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                        oexcelRange.Value2 = ds1.Tables[0].Rows[j]["NO_OF_EMP_SEEN"].ToString();

                                                        oexcelRange = ((Excel.Range)oSheet.Cells[22, 11]);
                                                        //oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                        oexcelRange.Value2 = ds1.Tables[0].Rows[j]["TYPE_OF_INDUSTRY"].ToString();

                                                        oexcelRange = ((Excel.Range)oSheet.Cells[24, 10]);
                                                        //oexcelRange.HorizontalAlignment = HorizontalAlign.Center;
                                                        oexcelRange.Value2 = ds1.Tables[0].Rows[j]["ORGANIZATION_SEAL"].ToString();

                                                        oexcelRange = ((Excel.Range)oSheet.Cells[25, 10]);
                                                        //oexcelRange.HorizontalAlignment = HorizontalAlign.Center;
                                                        oexcelRange.Value2 = ds1.Tables[0].Rows[j]["AUTHORITY_SIGNATURE"].ToString();

                                                        oexcelRange = ((Excel.Range)oSheet.Cells[26, 10]);
                                                        //oexcelRange.HorizontalAlignment = HorizontalAlign.Center;
                                                        oexcelRange.Value2 = ds1.Tables[0].Rows[j]["DOCUMENT_AS_PER_STANDARD"].ToString();

                                                        oexcelRange = ((Excel.Range)oSheet.Cells[27, 10]);
                                                        //oexcelRange.HorizontalAlignment = HorizontalAlign.Center;
                                                        oexcelRange.Value2 = ds1.Tables[0].Rows[j]["DATE_ON_DOC"].ToString();

                                                        oexcelRange = ((Excel.Range)oSheet.Cells[28, 10]);
                                                        //oexcelRange.HorizontalAlignment = HorizontalAlign.Center;
                                                        oexcelRange.Value2 = ds1.Tables[0].Rows[j]["AMOUNT_ON_DOC"].ToString();

                                                        oexcelRange = ((Excel.Range)oSheet.Cells[29, 10]);
                                                        //oexcelRange.HorizontalAlignment = HorizontalAlign.Center;
                                                        oexcelRange.Value2 = ds1.Tables[0].Rows[j]["APP_ADDRESS_CORRECT"].ToString();

                                                        oexcelRange = ((Excel.Range)oSheet.Cells[31, 6]);
                                                        //oexcelRange.HorizontalAlignment = HorizontalAlign.Center;
                                                        oexcelRange.Value2 = ds1.Tables[0].Rows[j]["BUSSINESS_ACTIVITY_SEEN"].ToString();

                                                        oexcelRange = ((Excel.Range)oSheet.Cells[31, 12]);
                                                        //oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                        oexcelRange.Value2 = ds1.Tables[0].Rows[j]["NO_of_Employee"].ToString();

                                                        oexcelRange = ((Excel.Range)oSheet.Cells[32, 6]);
                                                        //oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                        oexcelRange.Value2 = ds1.Tables[0].Rows[j]["STOCK_SIGHTED"].ToString();

                                                        oexcelRange = ((Excel.Range)oSheet.Cells[32, 12]);
                                                        //oexcelRange.HorizontalAlignment = HorizontalAlign.Center;
                                                        oexcelRange.Value2 = ds1.Tables[0].Rows[j]["NAME_BOARD_SEEN"].ToString();

                                                        oexcelRange = ((Excel.Range)oSheet.Cells[33, 4]);
                                                        //oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                        oexcelRange.Value2 = ds1.Tables[0].Rows[j]["FE_REMARK"].ToString();
                                                        /////////for teleLog ------------------------------------------------
                                                        string[] sArrAttemptSC = ds1.Tables[0].Rows[j]["ATTEMPT_DATE_TIME"].ToString().Split(' ');
                                                        string strAttemptDateSC = "";
                                                        string strAttemptTimeSC = "";
                                                        if (sArrAttemptSC.Length > 0)
                                                        {
                                                            strAttemptDateSC = sArrAttemptSC[0].ToString().Trim();
                                                            if (sArrAttemptSC.Length > 1)
                                                            {
                                                                strAttemptTimeSC = sArrAttemptSC[1].ToString().Trim() +
                                                                                 sArrAttemptSC[2].ToString().Trim();
                                                            }
                                                        }
                                                        oexcelRange = ((Excel.Range)oSheet.Cells[iRowCellNoSC, 4]);
                                                        //oexcelRange.HorizontalAlignment = HorizontalAlign.Center;
                                                        oexcelRange.Value2 = strAttemptDateSC;

                                                        oexcelRange = ((Excel.Range)oSheet.Cells[iRowCellNoSC, 6]);
                                                        //oexcelRange.HorizontalAlignment = HorizontalAlign.Center;
                                                        oexcelRange.Value2 = strAttemptTimeSC;

                                                        oexcelRange = ((Excel.Range)oSheet.Cells[iRowCellNoSC, 8]);
                                                        //oexcelRange.HorizontalAlignment = HorizontalAlign.Center;
                                                        oexcelRange.Value2 = ds1.Tables[0].Rows[j]["TELEPHONE_NO"].ToString();

                                                        oexcelRange = ((Excel.Range)oSheet.Cells[iRowCellNoSC, 10]);
                                                        //oexcelRange.HorizontalAlignment = HorizontalAlign.Center;
                                                        oexcelRange.Value2 = ds1.Tables[0].Rows[j]["REMARK"].ToString();

                                                        ///////////------------------------
                                                        oexcelRange = ((Excel.Range)oSheet.Cells[42, 4]);
                                                        //oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                        oexcelRange.Value2 = ds1.Tables[0].Rows[j]["TELE_REMARK"].ToString();

                                                        oexcelRange = ((Excel.Range)oSheet.Cells[44, 4]);
                                                        //oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                        oexcelRange.Value2 = ds1.Tables[0].Rows[j]["STATUS_CODE"].ToString();

                                                        oexcelRange = ((Excel.Range)oSheet.Cells[45, 8]);
                                                        //oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                        oexcelRange.Value2 = ds1.Tables[0].Rows[j]["FULLNAME"].ToString();

                                                        oexcelRange = ((Excel.Range)oSheet.Cells[46, 4]);
                                                        //oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                        oexcelRange.Value2 = ds1.Tables[0].Rows[j]["FE_VISIT_DATE"].ToString();

                                                        iRowCellNoSC++;
                                                        break;
                                                    case 6:     //ITR

                                                        oSheet = (Excel._Worksheet)oBook.Worksheets["DV-ITR"];
                                                        oSheet.Visible = Excel.XlSheetVisibility.xlSheetVisible;
                                                        oSheet.Unprotect(oMissing);

                                                        oexcelRange = ((Excel.Range)oSheet.Cells[5, 5]);
                                                        //oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                        oexcelRange.Value2 = ds1.Tables[0].Rows[j]["APPLICANT_NAME"].ToString();

                                                        oexcelRange = ((Excel.Range)oSheet.Cells[6, 5]);
                                                        //oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                        oexcelRange.Value2 = ds1.Tables[0].Rows[j]["REF_NO"].ToString();

                                                        oexcelRange = ((Excel.Range)oSheet.Cells[6, 8]);
                                                        //oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                        oexcelRange.Value2 = Convert.ToDateTime(ds1.Tables[0].Rows[j]["CASE_REC_DATETIME"].ToString()).ToString("dd/MM/yyyy hh:mm tt");

                                                        oexcelRange = ((Excel.Range)oSheet.Cells[8, 4]);
                                                        //oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                        oexcelRange.Value2 = ds1.Tables[0].Rows[j]["TOTAL_INCOME"].ToString();

                                                        oexcelRange = ((Excel.Range)oSheet.Cells[8, 10]);
                                                        //oexcelRange.HorizontalAlignment = HorizontalAlign.Center;
                                                        oexcelRange.Value2 = ds1.Tables[0].Rows[j]["Pan_correct"].ToString();

                                                        oexcelRange = ((Excel.Range)oSheet.Cells[8, 13]);
                                                        //oexcelRange.HorizontalAlignment = HorizontalAlign.Center;
                                                        oexcelRange.Value2 = ds1.Tables[0].Rows[j]["Is_It_Ten_Digit_Alpha"].ToString();

                                                        oexcelRange = ((Excel.Range)oSheet.Cells[9, 6]);
                                                        //oexcelRange.HorizontalAlignment = HorizontalAlign.Center;
                                                        oexcelRange.Value2 = ds1.Tables[0].Rows[j]["Are_Digit_Numeric"].ToString();

                                                        oexcelRange = ((Excel.Range)oSheet.Cells[10, 10]);
                                                        //oexcelRange.HorizontalAlignment = HorizontalAlign.Center;
                                                        oexcelRange.Value2 = ds1.Tables[0].Rows[j]["Is_Fourth_Digit"].ToString();

                                                        oexcelRange = ((Excel.Range)oSheet.Cells[10, 13]);
                                                        //oexcelRange.HorizontalAlignment = HorizontalAlign.Center;
                                                        oexcelRange.Value2 = ds1.Tables[0].Rows[j]["computation_correct"].ToString();

                                                        oexcelRange = ((Excel.Range)oSheet.Cells[11, 5]);
                                                        //oexcelRange.HorizontalAlignment = HorizontalAlign.Center;
                                                        oexcelRange.Value2 = ds1.Tables[0].Rows[j]["INCOME_CAL_CORRECT"].ToString();

                                                        oexcelRange = ((Excel.Range)oSheet.Cells[11, 8]);
                                                        //oexcelRange.HorizontalAlignment = HorizontalAlign.Center;
                                                        oexcelRange.Value2 = ds1.Tables[0].Rows[j]["Tax_cal_correct"].ToString();

                                                        oexcelRange = ((Excel.Range)oSheet.Cells[12, 7]);
                                                        //oexcelRange.HorizontalAlignment = HorizontalAlign.Center;
                                                        oexcelRange.Value2 = ds1.Tables[0].Rows[j]["Alpha_Falls_Under_Ward"].ToString();

                                                        oexcelRange = ((Excel.Range)oSheet.Cells[12, 13]);
                                                        //oexcelRange.HorizontalAlignment = HorizontalAlign.Center;
                                                        oexcelRange.Value2 = ds1.Tables[0].Rows[j]["Address_Falls_Under_Ward"].ToString();

                                                        oexcelRange = ((Excel.Range)oSheet.Cells[13, 7]);
                                                        //oexcelRange.HorizontalAlignment = HorizontalAlign.Center;
                                                        oexcelRange.Value2 = ds1.Tables[0].Rows[j]["OK_field_verification"].ToString();

                                                        oexcelRange = ((Excel.Range)oSheet.Cells[14, 7]);
                                                        //oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                        oexcelRange.Value2 = ds1.Tables[0].Rows[j]["Other_observation"].ToString();

                                                       
                                                        ///for multiple rows---------------------
                                                        oexcelRange = ((Excel.Range)oSheet.Cells[iRowCellNoITR, 4]);
                                                        //oexcelRange.HorizontalAlignment = HorizontalAlign.Center;
                                                        oexcelRange.Value2 = ds1.Tables[0].Rows[j]["Computer_Record"].ToString();

                                                        oexcelRange = ((Excel.Range)oSheet.Cells[iRowCellNoITR, 6]);
                                                        //oexcelRange.HorizontalAlignment = HorizontalAlign.Center;
                                                        oexcelRange.Value2 = ds1.Tables[0].Rows[j]["Inward_register"].ToString();

                                                        oexcelRange = ((Excel.Range)oSheet.Cells[iRowCellNoITR, 8]);
                                                        //oexcelRange.HorizontalAlignment = HorizontalAlign.Center;
                                                        oexcelRange.Value2 = ds1.Tables[0].Rows[j]["Blue_register"].ToString();

                                                        oexcelRange = ((Excel.Range)oSheet.Cells[iRowCellNoITR, 11]);
                                                        //oexcelRange.HorizontalAlignment = HorizontalAlign.Center;
                                                        oexcelRange.Value2 = ds1.Tables[0].Rows[j]["index_register"].ToString();

                                                        oexcelRange = ((Excel.Range)oSheet.Cells[iRowCellNoITR, 12]);
                                                        //oexcelRange.HorizontalAlignment = HorizontalAlign.Center;
                                                        oexcelRange.Value2 = ds1.Tables[0].Rows[j]["Orally_by_clerck"].ToString();
                                                        ///----------------------------------------------------------------
                                                        oexcelRange = ((Excel.Range)oSheet.Cells[24, 4]);
                                                        //oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                        oexcelRange.Value2 = ds1.Tables[0].Rows[j]["STATUS_CODE"].ToString();

                                                        oexcelRange = ((Excel.Range)oSheet.Cells[25, 10]);
                                                        //oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                        oexcelRange.Value2 = ds1.Tables[0].Rows[j]["FE_Remark"].ToString();

                                                        oexcelRange = ((Excel.Range)oSheet.Cells[29, 7]);
                                                        //oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                        oexcelRange.Value2 = ds1.Tables[0].Rows[j]["FULLNAME"].ToString();

                                                        oexcelRange = ((Excel.Range)oSheet.Cells[30, 4]);
                                                        //oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                        oexcelRange.Value2 = ds1.Tables[0].Rows[j]["FE_VISIT_DATE"].ToString();

                                                        iRowCellNoITR++;
                                                        break;

                                                    case 9:     //RC

                                                        oSheet = (Excel._Worksheet)oBook.Worksheets["DV-RC"];
                                                        oSheet.Visible = Excel.XlSheetVisibility.xlSheetVisible;
                                                        oSheet.Unprotect(oMissing);

                                                        oexcelRange = ((Excel.Range)oSheet.Cells[5, 5]);
                                                        //oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                        oexcelRange.Value2 = ds1.Tables[0].Rows[j]["APPLICANT_NAME"].ToString();

                                                        oexcelRange = ((Excel.Range)oSheet.Cells[6, 8]);
                                                        //oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                        oexcelRange.Value2 = Convert.ToDateTime(ds1.Tables[0].Rows[j]["CASE_REC_DATETIME"].ToString()).ToString("dd/MM/yyyy hh:mm tt");

                                                        oexcelRange = ((Excel.Range)oSheet.Cells[6, 13]);
                                                        //oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                        oexcelRange.Value2 = ds1.Tables[0].Rows[j]["REF_NO"].ToString();

                                                        oexcelRange = ((Excel.Range)oSheet.Cells[8, 5]);
                                                        //oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                        oexcelRange.Value2 = ds1.Tables[0].Rows[j]["Vehicle_Registration_Number"].ToString();

                                                        oexcelRange = ((Excel.Range)oSheet.Cells[9, 5]);
                                                        //oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                        oexcelRange.Value2 = ds1.Tables[0].Rows[j]["RTO_Office"].ToString();

                                                        oexcelRange = ((Excel.Range)oSheet.Cells[10, 5]);
                                                        //oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                        oexcelRange.Value2 = ds1.Tables[0].Rows[j]["Address_Falls_Under_Jurisdiction_RTO"].ToString();

                                                        oexcelRange = ((Excel.Range)oSheet.Cells[11, 5]);
                                                        //oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                        oexcelRange.Value2 = ds1.Tables[0].Rows[j]["Other_observation"].ToString();

                                                        oexcelRange = ((Excel.Range)oSheet.Cells[13, 7]);
                                                        //oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                        oexcelRange.Value2 = ds1.Tables[0].Rows[j]["RC_Details_Confirmed_With"].ToString();

                                                        oexcelRange = ((Excel.Range)oSheet.Cells[14, 7]);
                                                        //oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                        oexcelRange.Value2 = ds1.Tables[0].Rows[j]["Is_Correct_Registration_No_Of_Vehicle"].ToString();

                                                        oexcelRange = ((Excel.Range)oSheet.Cells[15, 7]);
                                                        //oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                        oexcelRange.Value2 = ds1.Tables[0].Rows[j]["Is_Vehicle_Personal_Commercial"].ToString();

                                                        oexcelRange = ((Excel.Range)oSheet.Cells[16, 7]);
                                                        //oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                        oexcelRange.Value2 = ds1.Tables[0].Rows[j]["Is_Vehicle_Hypothecated"].ToString();

                                                        oexcelRange = ((Excel.Range)oSheet.Cells[17, 7]);
                                                        //oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                        oexcelRange.Value2 = ds1.Tables[0].Rows[j]["Fuinancer_Name"].ToString();

                                                        oexcelRange = ((Excel.Range)oSheet.Cells[18, 7]);
                                                        //oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                        oexcelRange.Value2 = ds1.Tables[0].Rows[j]["Registration_Date_As_Per_RC_Register"].ToString();

                                                        oexcelRange = ((Excel.Range)oSheet.Cells[19, 7]);
                                                        //oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                        oexcelRange.Value2 = ds1.Tables[0].Rows[j]["Transfer_Details"].ToString();

                                                        oexcelRange = ((Excel.Range)oSheet.Cells[20, 4]);
                                                        //oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                        oexcelRange.Value2 = ds1.Tables[0].Rows[j]["STATUS_CODE"].ToString();

                                                        oexcelRange = ((Excel.Range)oSheet.Cells[21, 10]);
                                                        //oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                        oexcelRange.Value2 = ds1.Tables[0].Rows[j]["FE_REMARK"].ToString();

                                                        oexcelRange = ((Excel.Range)oSheet.Cells[24, 7]);
                                                        //oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                        oexcelRange.Value2 = ds1.Tables[0].Rows[j]["FULLNAME"].ToString();

                                                        oexcelRange = ((Excel.Range)oSheet.Cells[25, 4]);
                                                        //oexcelRange.HorizontalAlignment = HorizontalAlign.Left;
                                                        oexcelRange.Value2 = ds1.Tables[0].Rows[j]["FE_VISIT_DATE"].ToString();

                                                        break;
                                                }
                                            }
                                        }
                                    }
                                }
                            }

                            ds.Clear();
                            oBook.Save();
                            //// saving excel sheet
                            //if (strRefID != "")
                            //{

                            //    String strFileName = (Server.MapPath("~//StdOutput//IDOC//")) + strRefID + ".xls";
                            //    oBook.SaveAs(strFileName, oMissing, oMissing, oMissing, oMissing, oMissing, XlSaveAsAccessMode.xlNoChange, oMissing, oMissing, oMissing, oMissing, oMissing);
                            //}
                            //clear all excel veriables
                            oSheet = null;
                            oBook.Close(false, oMissing, false);
                            oBook = null;
                            oBooks.Close();
                            oBooks = null;

                            oExcelApp.Quit();
                            oExcelApp = null;                            
                        }
                    }
                        
                    catch (Exception exp)
                    {
                        conn.Close();
                        //throw new Exception(exp.Message);
                        lblMsg.Visible = true;
                        lblMsg.Text = exp.Message;
                    }

                }
                lblMsg.Visible = true;
                hplDownload.NavigateUrl = ConfigurationManager.AppSettings["FtpPath"] + "//IDOC//" + Session["UserName"].ToString() + "//" + strDateTime + "//";                
                lblMsg.Text = "Export completed successfully";
                hplDownload.Visible = true;
                conn.Close();
            }
        }
        catch (Exception exp)
        {
            //throw new Exception(exp.Message);
            lblMsg.Text = exp.Message;
            lblMsg.Visible = true;
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
