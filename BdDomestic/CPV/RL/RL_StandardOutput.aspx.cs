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
using System.Text;
using System.IO;
using CrystalDecisions.Shared;
using CrystalDecisions.CrystalReports.Engine;

public partial class RL_RL_StandardOutput : System.Web.UI.Page
{
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
            CCommon objCmn = new CCommon();
            String strCentreID = Session["CentreId"].ToString();
            String strClientID = Session["ClientId"].ToString();
            bool isValidDates = true;
            hplDownload.Visible = false;
            if (txtFromDate.Text.Trim() != "" && txtToDate.Text.Trim() != "")
            {
                DateTime dtFrom = Convert.ToDateTime(objCmn.strDate(txtFromDate.Text.Trim()));
                DateTime dtTo = Convert.ToDateTime(objCmn.strDate(txtToDate.Text.Trim()));
                if (dtFrom > dtTo)
                {
                    isValidDates = false;
                    lblMsg.Visible = true;
                    lblMsg.Text = "From date must be less than to date.";
                }
            }
            if (isValidDates == true)
            {
                if (strCentreID != "" && strClientID != "")
                {
                    string ToDate = "";
                    string FromDate = "";
                    FromDate = objCmn.strDate(txtFromDate.Text.Trim());
                    ToDate = Convert.ToDateTime(objCmn.strDate(txtToDate.Text.Trim())).AddDays(1.0).ToString("dd-MMM-yyyy");

                    hdFromDate.Value = FromDate;
                    hdToDate.Value = ToDate;

                    //to get total no of records......
                    string sSql = "SELECT Count(*) as TotalCount FROM [CPV_RL_CASE_DETAILS] " +
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
                    //                          " FROM [CPV_RL_CASE_DETAILS] " +
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
        catch (Exception ex)
        {
            lblMsg.Visible = true;
            lblMsg.Text = "Error :" + ex.Message;
        }

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
                //GenerateExcel(arrCaseID);
                GeneratePDF(arrCaseID);
                gvOutput.DataBind();
                //lblMsg.Visible = true;
                //lblMsg.Text = "Export completed successfully";
                //hplDownload.Visible = true;
                //hplDownload.NavigateUrl = ConfigurationManager.AppSettings["FtpPath"] + "//RL//" + Session["UserName"].ToString() + "//";
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
    public void GeneratePDF(string[] arrCaseId)
    {
        int iCount = 0;
        try
        {
            if (arrCaseId.Length > 0)
            {
                DataSet dsRl_Main = new DataSet();
                CReport objReport = new CReport();
                System.Data.DataTable dtCaseId = new System.Data.DataTable();
                System.Data.DataTable dtResi_Tele = new System.Data.DataTable();
                System.Data.DataTable dtResi_Crv = new System.Data.DataTable();
                System.Data.DataTable dtOff_Tele = new System.Data.DataTable();
                System.Data.DataTable dtOff_Crv = new System.Data.DataTable();
                //System.Data.DataTable dtOfficeTeleAttempt = new System.Data.DataTable();

                string strMapPath = Server.MapPath("../../ExportToUTI/RL/") + Session["UserName"].ToString() + "/";
                string strDateTime = DateTime.Now.ToString("ddMMyyyyhhmmss");

                if (!Directory.Exists(strMapPath + strDateTime))
                    Directory.CreateDirectory(strMapPath + strDateTime);

                for (int i = 0; i < arrCaseId.Length; i++)
                {
                   
                    dsRl_Main.Tables.Clear();
                    dsRl_Main.Clear();
                    string sRefNo = "";
                    OleDbDataReader oledbRead;
                    oledbRead = objReport.GetRefNoByCaseIdRL(arrCaseId[i].ToString());
                    if (oledbRead.Read())
                        sRefNo = oledbRead["Case_id"].ToString();

                    oledbRead.Close();
                    dtCaseId = objReport.GetCaseIdforReportRL(arrCaseId[i].ToString());
                    dtOff_Crv = objReport.GetBusinessVerificationDtlRL(arrCaseId[i].ToString());
                    dtResi_Crv = objReport.GetResidenceVerificationDtlRL(arrCaseId[i].ToString());
                    dtOff_Tele = objReport.GetOfficeTeleDtlRL(arrCaseId[i].ToString());
                    dtResi_Tele = objReport.GetResidenceTeleDtlRL(arrCaseId[i].ToString());                    
                  
                    dsRl_Main.Tables.Add(dtCaseId);
                    dsRl_Main.Tables[0].TableName = "Rl_Main";

                    dsRl_Main.Tables.Add(dtOff_Crv);
                    dsRl_Main.Tables[1].TableName = "Off_Crv";

                    dsRl_Main.Tables.Add(dtResi_Crv);
                    dsRl_Main.Tables[2].TableName = "Resi_Crv";

                    dsRl_Main.Tables.Add(dtOff_Tele);
                    dsRl_Main.Tables[3].TableName = "Off_Tele";

                    dsRl_Main.Tables.Add(dtResi_Tele);
                    dsRl_Main.Tables[4].TableName = "Resi_Tele";

                    CrystalReportDocument myReportDocument;
                    myReportDocument = new CrystalReportDocument();
                    myReportDocument.Load(Server.MapPath("Rl_Ge_Main.rpt"));
                    
                    //myReportDocument.ParameterFields.Add(arrCaseId[i].ToString());
                    myReportDocument.SetDataSource(dsRl_Main);
                    //myReportDocument.ExportToStream(ExportFormatType.PortableDocFormat),System.IO.MemoryStream);
               
                   myReportDocument.ExportToDisk(ExportFormatType.PortableDocFormat, strMapPath + strDateTime + "/" + sRefNo + ".pdf");
                        myReportDocument.Close();
                    //myReportDocument.Dispose();
                    GC.Collect();
                }
                
                lblMsg.Visible = true;
                lblMsg.Text = "Export Completed successfully.";
                hplDownload.Visible = true;
                hplDownload.NavigateUrl = ConfigurationManager.AppSettings["FtpPath"] + "//RL//" + Session["UserName"].ToString() + "//" + strDateTime + "//";
                dtCaseId.Clear();
                dtOff_Tele.Clear();
                dtResi_Tele.Clear();
                dtResi_Crv.Clear();
                dtOff_Crv.Clear();

                dtCaseId.Dispose();
                dtOff_Tele.Dispose();
                dtResi_Tele.Dispose();
                dtResi_Crv.Dispose();
                dtOff_Crv.Dispose();
                dsRl_Main.Clear();
                dsRl_Main.Clear();
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
        Excel.Range oexcelRange;
        object oMissing;
        //for getting connection string
        
        try
        {
            String strCentreID = Session["CentreId"].ToString();
            String strClientID = Session["ClientId"].ToString(); 
            if (strCentreID != "" && strClientID != "")
            {
                CCommon oCmn = new CCommon();
                //dataset for main data
                DataSet ds;
                //dataset for attempt details
                DataSet ds1;
                OleDbConnection conn = new OleDbConnection(oCmn.ConnectionString);
                String strRefID = "";
                string strCaseId = "";
                String strExcel = Server.MapPath("ExcelStdOutputRL.xls");

                string strMapPath = Server.MapPath("../../ExportToUTI/RL/") + Session["UserName"].ToString() + "/";
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
                        String strSQL = "SELECT distinct(verification_type_id), cd.CASE_ID,REF_NO,channel_name " +
                                        " FROM CPV_RL_CASE_DETAILS cd inner join CPV_RL_CASE_VERIFICATIONTYPE cv " +
                                        " on cd.case_id=cv.case_id " +
                                        " WHERE (CENTRE_ID = '" + strCentreID + "') AND (CLIENT_ID = '" + strClientID + "') " +
                                        " AND (cd.CASE_ID = '" + strCaseID + "') " +
                                        " ORDER BY VERIFICATION_TYPE_ID";

                        ds = OleDbHelper.ExecuteDataset(conn, CommandType.Text, strSQL);
                        conn.Close();
                        //excel setting
                        string strChannelName = "";
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            strCaseId = ds.Tables[0].Rows[0]["CASE_ID"].ToString();
                            strChannelName = ds.Tables[0].Rows[0]["channel_name"].ToString();
                        }
                        if (strCaseId != "")
                        {
                            //if (!Directory.Exists(Server.MapPath("../../ExportToUTI/RL/" + Session["UserName"].ToString())))
                            //    Directory.CreateDirectory(Server.MapPath("../../ExportToUTI/RL/" + Session["UserName"].ToString()));
                            //String strFileName = Server.MapPath("../../ExportToUTI/RL/" + Session["UserName"].ToString()) + "/" + strCaseID + ".xls";
                            String strFileName = "";
                            if (strChannelName.Trim() != "")
                            {
                                strFileName = strMapPath + strDateTime + "/" + strCaseId + strChannelName.Trim() + ".xls";
                            }
                            else
                            {
                                strFileName = strMapPath + strDateTime + "/" + strCaseId + "000" + ".xls";
                            }
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
                                        if ((strTypeID == "1") || (strTypeID == "4"))  //For RV/RT
                                        {
                                            strSQL1 = "SELECT * FROM CPV_RL_verification_RVRT_view " +
                                                      " WHERE CASE_ID='" + strCaseID + "' AND VERIFICATION_TYPE_ID='" + strTypeID + "'";
                                        }
                                        else if ((strTypeID == "2") || (strTypeID == "3")) //For BV/BT
                                        {
                                            strSQL1 = "SELECT * FROM CPV_RL_verification_BVBT_view " +
                                                    " WHERE CASE_ID='" + strCaseID + "' AND VERIFICATION_TYPE_ID='" + strTypeID + "'";
                                        }
                                        else if (strTypeID == "14")  //For RCO
                                        {
                                            strSQL1 = "SELECT * FROM CPV_RL_verification_RCB_view " +
                                                    " WHERE CASE_ID='" + strCaseID + "' AND VERIFICATION_TYPE_ID='" + strTypeID + "'";
                                        }
                                        else if ((strTypeID == "12") || (strTypeID == "13"))//For REF1/REF2
                                        {
                                            strSQL1 = "Select * FROM CPV_RL_verification_ref_view " +
                                                     " WHERE CASE_ID='" + strCaseID + "' AND VERIFICATION_TYPE_ID='" + strTypeID + "'";
                                        }

                                        ds1 = OleDbHelper.ExecuteDataset(conn, CommandType.Text, strSQL1);
                                        conn.Close();
                                        if (ds1.Tables[0].Rows.Count > 0)
                                        {                                           
                                            for (int j = 0; j < ds1.Tables[0].Rows.Count; j++)
                                            {                                                

                                                //filling excel according to verification type 
                                                switch (Convert.ToInt16(strTypeID))
                                                {                                                    
                                                    case 1: 
                                                        //RV                                                        
                                                        oSheet = (Excel._Worksheet)oBook.Worksheets["RV"];
                                                        oSheet.Visible = Excel.XlSheetVisibility.xlSheetVisible;
                                                        oSheet.Unprotect(oMissing);

                                                        string sVerDateTimeRV = ds1.Tables[0].Rows[j]["VERIFICATION_DATETIME"].ToString();
                                                        if (sVerDateTimeRV != "")
                                                        {
                                                            string[] arrVerDateTime = sVerDateTimeRV.Split(' ');
                                                            if (arrVerDateTime[0].ToString().Trim() != "")
                                                            {
                                                                if (arrVerDateTime[0].ToString() != "")
                                                                {
                                                                    oexcelRange = ((Excel.Range)oSheet.Cells[6, 4]);
                                                                    oexcelRange.Value2 = arrVerDateTime[0].ToString();
                                                                }
                                                                if (arrVerDateTime[1].ToString() != "" && arrVerDateTime[2].ToString() != "")
                                                                {
                                                                    oexcelRange = ((Excel.Range)oSheet.Cells[6, 10]);
                                                                    oexcelRange.Value2 = arrVerDateTime[1].ToString() + " " + arrVerDateTime[2].ToString();
                                                                }
                                                            }
                                                        }

                                                        oexcelRange = ((Excel.Range)oSheet.Cells[5, 10]);
                                                        oexcelRange.Value2 = ds1.Tables[0].Rows[j]["REF_NO"].ToString();

                                                        oexcelRange = ((Excel.Range)oSheet.Cells[7, 4]);                                                        
                                                        oexcelRange.Value2 = "PAMAC";

                                                        oexcelRange = ((Excel.Range)oSheet.Cells[7, 10]);                                                        
                                                        oexcelRange.Value2 = ds1.Tables[0].Rows[j]["FE"].ToString();

                                                        oexcelRange = ((Excel.Range)oSheet.Cells[9, 5]);                                                        
                                                        oexcelRange.Value2 = ds1.Tables[0].Rows[j]["APPNAME"].ToString();

                                                        oexcelRange = ((Excel.Range)oSheet.Cells[10, 5]);
                                                        oexcelRange.Value2 = ds1.Tables[0].Rows[j]["ADDRESS"].ToString();

                                                        oexcelRange = ((Excel.Range)oSheet.Cells[12, 5]);                                                        
                                                        oexcelRange.Value2 = ds1.Tables[0].Rows[j]["Name_Neighbour1"].ToString();

                                                        oexcelRange = ((Excel.Range)oSheet.Cells[13, 5]);
                                                        oexcelRange.Value2 = ds1.Tables[0].Rows[j]["ADD_Neighbour1"].ToString();

                                                        oexcelRange = ((Excel.Range)oSheet.Cells[14, 5]);
                                                        oexcelRange.Value2 = ds1.Tables[0].Rows[j]["CONFIRM_Neighbour1"].ToString(); 

                                                        oexcelRange = ((Excel.Range)oSheet.Cells[14, 10]);
                                                        oexcelRange.Value2 = ds1.Tables[0].Rows[j]["Stay_Res_Neighbour1"].ToString();

                                                        oexcelRange = ((Excel.Range)oSheet.Cells[15, 5]);
                                                        oexcelRange.Value2 = ds1.Tables[0].Rows[j]["RESSTATUS_Neighbour1"].ToString(); 

                                                        oexcelRange = ((Excel.Range)oSheet.Cells[16, 5]);
                                                        oexcelRange.Value2 = ds1.Tables[0].Rows[j]["Comments_Neighbour1"].ToString();

                                                        oexcelRange = ((Excel.Range)oSheet.Cells[18, 5]);
                                                        oexcelRange.Value2 = ds1.Tables[0].Rows[j]["Name_Neighbour2"].ToString();

                                                        oexcelRange = ((Excel.Range)oSheet.Cells[19, 5]);
                                                        oexcelRange.Value2 = ds1.Tables[0].Rows[j]["ADD_Neighbour2"].ToString();

                                                        oexcelRange = ((Excel.Range)oSheet.Cells[20, 5]);
                                                        oexcelRange.Value2 = ds1.Tables[0].Rows[j]["CONFIRM_Neighbour2"].ToString();

                                                        oexcelRange = ((Excel.Range)oSheet.Cells[20, 10]);
                                                        oexcelRange.Value2 = ds1.Tables[0].Rows[j]["Stay_Res_Neighbour2"].ToString();

                                                        oexcelRange = ((Excel.Range)oSheet.Cells[21, 5]);
                                                        oexcelRange.Value2 = ds1.Tables[0].Rows[j]["RESSTATUS_Neighbour2"].ToString();

                                                        oexcelRange = ((Excel.Range)oSheet.Cells[22, 5]);
                                                        oexcelRange.Value2 = ds1.Tables[0].Rows[j]["Comments_Neighbour2"].ToString();

                                                        oexcelRange = ((Excel.Range)oSheet.Cells[25, 5]);                                                        
                                                        oexcelRange.Value2 = ds1.Tables[0].Rows[j]["LOCALITY"].ToString();

                                                        oexcelRange = ((Excel.Range)oSheet.Cells[25, 10]);
                                                        oexcelRange.Value2 = ds1.Tables[0].Rows[j]["Landmark"].ToString();

                                                        oexcelRange = ((Excel.Range)oSheet.Cells[26, 5]);
                                                        oexcelRange.Value2 = ds1.Tables[0].Rows[j]["Accessibility"].ToString();

                                                        oexcelRange = ((Excel.Range)oSheet.Cells[26, 10]);
                                                        oexcelRange.Value2 = ds1.Tables[0].Rows[j]["Bachelor_Accomodation"].ToString();

                                                        oexcelRange = ((Excel.Range)oSheet.Cells[27, 5]);
                                                        oexcelRange.Value2 = ds1.Tables[0].Rows[j]["Exterior_Premises"].ToString();

                                                        oexcelRange = ((Excel.Range)oSheet.Cells[27, 10]);
                                                        oexcelRange.Value2 = ds1.Tables[0].Rows[j]["Entrance_Motorable"].ToString();

                                                        oexcelRange = ((Excel.Range)oSheet.Cells[28, 5]);
                                                        oexcelRange.Value2 = ds1.Tables[0].Rows[j]["Nameplate_on_door"].ToString();

                                                        oexcelRange = ((Excel.Range)oSheet.Cells[28, 10]);
                                                        oexcelRange.Value2 = ds1.Tables[0].Rows[j]["Society_Board_Sighted"].ToString();

                                                        oexcelRange = ((Excel.Range)oSheet.Cells[29, 5]);
                                                        oexcelRange.Value2 = ds1.Tables[0].Rows[j]["interior_Premises"].ToString();

                                                        oexcelRange = ((Excel.Range)oSheet.Cells[29, 10]);
                                                        oexcelRange.Value2 = ds1.Tables[0].Rows[j]["Entry_Permitted"].ToString();

                                                        oexcelRange = ((Excel.Range)oSheet.Cells[30, 5]);
                                                        oexcelRange.Value2 = ds1.Tables[0].Rows[j]["Area_of_House"].ToString();

                                                        oexcelRange = ((Excel.Range)oSheet.Cells[30, 10]);
                                                        oexcelRange.Value2 = ds1.Tables[0].Rows[j]["ASSETS"].ToString().Replace("Others,","");

                                                        oexcelRange = ((Excel.Range)oSheet.Cells[31, 5]);
                                                        oexcelRange.Value2 = ds1.Tables[0].Rows[j]["SEP_BATHROOM_SEEN"].ToString();

                                                        oexcelRange = ((Excel.Range)oSheet.Cells[31, 10]);
                                                        oexcelRange.Value2 = ds1.Tables[0].Rows[j]["FAMILY_SEEN"].ToString();

                                                        oexcelRange = ((Excel.Range)oSheet.Cells[32, 5]);
                                                        oexcelRange.Value2 = ds1.Tables[0].Rows[j]["ROOF_TYPE"].ToString();

                                                        oexcelRange = ((Excel.Range)oSheet.Cells[35, 5]);
                                                        oexcelRange.Value2 = ds1.Tables[0].Rows[j]["PERSON_CONTACTED"].ToString();

                                                        oexcelRange = ((Excel.Range)oSheet.Cells[35, 11]);
                                                        oexcelRange.Value2 = ds1.Tables[0].Rows[j]["Relationship"].ToString();

                                                        oexcelRange = ((Excel.Range)oSheet.Cells[36, 5]);
                                                        oexcelRange.Value2 = ds1.Tables[0].Rows[j]["Identity_Proof_Seen"].ToString();

                                                        oexcelRange = ((Excel.Range)oSheet.Cells[36, 11]);
                                                        oexcelRange.Value2 = ds1.Tables[0].Rows[j]["Type"].ToString();

                                                        oexcelRange = ((Excel.Range)oSheet.Cells[37, 5]);
                                                        oexcelRange.Value2 = ds1.Tables[0].Rows[j]["Months"].ToString();

                                                        oexcelRange = ((Excel.Range)oSheet.Cells[37, 11]);
                                                        oexcelRange.Value2 = ds1.Tables[0].Rows[j]["STAYING_WHOM"].ToString();

                                                        oexcelRange = ((Excel.Range)oSheet.Cells[38, 5]);
                                                        oexcelRange.Value2 = ds1.Tables[0].Rows[j]["Address_Proof_Sighted"].ToString();

                                                        oexcelRange = ((Excel.Range)oSheet.Cells[38, 11]);
                                                        oexcelRange.Value2 = ds1.Tables[0].Rows[j]["age_applicant"].ToString();

                                                        oexcelRange = ((Excel.Range)oSheet.Cells[39, 5]);
                                                        oexcelRange.Value2 = ds1.Tables[0].Rows[j]["No_of_dependent"].ToString();

                                                        oexcelRange = ((Excel.Range)oSheet.Cells[39, 11]);
                                                        oexcelRange.Value2 = ds1.Tables[0].Rows[j]["MARITAL_STATUS"].ToString();

                                                        oexcelRange = ((Excel.Range)oSheet.Cells[40, 5]);
                                                        oexcelRange.Value2 = ds1.Tables[0].Rows[j]["Applicant_income"].ToString();

                                                        oexcelRange = ((Excel.Range)oSheet.Cells[40, 11]);
                                                        oexcelRange.Value2 = ds1.Tables[0].Rows[j]["Father_Spouse_Name"].ToString();

                                                        oexcelRange = ((Excel.Range)oSheet.Cells[41, 5]);
                                                        oexcelRange.Value2 = ds1.Tables[0].Rows[j]["Company_name"].ToString();

                                                        oexcelRange = ((Excel.Range)oSheet.Cells[41, 11]);
                                                        oexcelRange.Value2 = ds1.Tables[0].Rows[j]["Mother_Name"].ToString();

                                                        oexcelRange = ((Excel.Range)oSheet.Cells[42, 5]);
                                                        oexcelRange.Value2 = ds1.Tables[0].Rows[j]["Address_Company"].ToString();

                                                        oexcelRange = ((Excel.Range)oSheet.Cells[42, 11]);
                                                        oexcelRange.Value2 = ds1.Tables[0].Rows[j]["other_source_income"].ToString();

                                                        oexcelRange = ((Excel.Range)oSheet.Cells[43, 5]);
                                                        oexcelRange.Value2 = ds1.Tables[0].Rows[j]["Other_Investment"].ToString();

                                                        oexcelRange = ((Excel.Range)oSheet.Cells[43, 11]);
                                                        oexcelRange.Value2 = ds1.Tables[0].Rows[j]["Purpose_loan"].ToString();

                                                        oexcelRange = ((Excel.Range)oSheet.Cells[44, 5]);
                                                        oexcelRange.Value2 = ds1.Tables[0].Rows[j]["loan_applicant_name"].ToString();

                                                        oexcelRange = ((Excel.Range)oSheet.Cells[44, 11]);
                                                        oexcelRange.Value2 = ds1.Tables[0].Rows[j]["Behavior_Person_Contacted"].ToString();

                                                        oexcelRange = ((Excel.Range)oSheet.Cells[45, 5]);
                                                        oexcelRange.Value2 = ds1.Tables[0].Rows[j]["EDUCATION_BACKGROUND"].ToString();

                                                        oexcelRange = ((Excel.Range)oSheet.Cells[46, 5]);
                                                        oexcelRange.Value2 = ds1.Tables[0].Rows[j]["Verifier_Comments1"].ToString();

                                                        oexcelRange = ((Excel.Range)oSheet.Cells[47, 2]);
                                                        oexcelRange.Value2 = ds1.Tables[0].Rows[j]["Verifier_Comments2"].ToString();
                                                        
                                                        oexcelRange = ((Excel.Range)oSheet.Cells[48, 2]);
                                                        oexcelRange.Value2 = ds1.Tables[0].Rows[j]["Verifier_Comments3"].ToString();

                                                        oexcelRange = ((Excel.Range)oSheet.Cells[49, 5]);
                                                        oexcelRange.Value2 = ds1.Tables[0].Rows[j]["SUPERVISOR_COMMENTS1"].ToString();

                                                        oexcelRange = ((Excel.Range)oSheet.Cells[50, 2]);
                                                        oexcelRange.Value2 = ds1.Tables[0].Rows[j]["SUPERVISOR_COMMENTS2"].ToString();

                                                        oexcelRange = ((Excel.Range)oSheet.Cells[51, 2]);
                                                        oexcelRange.Value2 = ds1.Tables[0].Rows[j]["SUPERVISOR_COMMENTS3"].ToString();
                                                        
                                                        oexcelRange = ((Excel.Range)oSheet.Cells[52, 5]);
                                                        oexcelRange.Value2 = ds1.Tables[0].Rows[j]["Colour_of_Door"].ToString();

                                                        oexcelRange = ((Excel.Range)oSheet.Cells[53, 5]);
                                                        oexcelRange.Value2 = ds1.Tables[0].Rows[j]["STATUS_NAME"].ToString();
                                                                                                                                                                       
                                                        break;

                                                    case 4:

                                                        //for RTV
                                                        oSheet = (Excel._Worksheet)oBook.Worksheets["RTV"];
                                                        oSheet.Visible = Excel.XlSheetVisibility.xlSheetVisible;
                                                        oSheet.Unprotect(oMissing);

                                                        oexcelRange = ((Excel.Range)oSheet.Cells[3, 3]);
                                                        oexcelRange.Value2 = ds1.Tables[0].Rows[j]["Area"].ToString();

                                                        oexcelRange = ((Excel.Range)oSheet.Cells[3, 10]);
                                                        oexcelRange.Value2 = ds1.Tables[0].Rows[j]["REF_NO"].ToString();

                                                        string sVerDateTimeRTV = ds1.Tables[0].Rows[j]["VERIFICATION_DATETIME"].ToString();
                                                        string sVerDateRTV = "";
                                                        if (sVerDateTimeRTV != "")
                                                        {                                                           
                                                            string[] arrVerDateTime = sVerDateTimeRTV.Split(' ');
                                                            if (arrVerDateTime[0].ToString().Trim() != "")
                                                            {
                                                                if (arrVerDateTime[0].ToString() != "")
                                                                {
                                                                    sVerDateRTV += Convert.ToDateTime(arrVerDateTime[0].ToString()).ToString("dd/MM/yyyy");
                                                                }
                                                                if (arrVerDateTime[1].ToString() != "" && arrVerDateTime[2].ToString() != "")
                                                                {

                                                                    sVerDateRTV += " " + arrVerDateTime[1].ToString() + " " + arrVerDateTime[2].ToString();
                                                                }
                                                            }
                                                        }
                                                        oexcelRange = ((Excel.Range)oSheet.Cells[3, 12]);
                                                        oexcelRange.Value2 = sVerDateRTV;

                                                        oexcelRange = ((Excel.Range)oSheet.Cells[4, 4]);
                                                        oexcelRange.Value2 = ds1.Tables[0].Rows[j]["APPNAME"].ToString();

                                                        oexcelRange = ((Excel.Range)oSheet.Cells[4, 11]);                                                        
                                                        oexcelRange.Value2 = ds1.Tables[0].Rows[j]["TEL_NO_TYPE_PHONE"].ToString();

                                                        oexcelRange = ((Excel.Range)oSheet.Cells[6, 4]);
                                                        oexcelRange.Value2 = ds1.Tables[0].Rows[j]["Address_Confirmed"].ToString();

                                                        oexcelRange = ((Excel.Range)oSheet.Cells[6, 8]);
                                                        oexcelRange.Value2 = ds1.Tables[0].Rows[j]["RESI_ADDRESS"].ToString();

                                                        oexcelRange = ((Excel.Range)oSheet.Cells[7, 4]);                                                        
                                                        oexcelRange.Value2 = ds1.Tables[0].Rows[j]["PERSON_CONTACTED"].ToString();

                                                        oexcelRange = ((Excel.Range)oSheet.Cells[7, 11]);                                                        
                                                        oexcelRange.Value2 = ds1.Tables[0].Rows[j]["Relationship"].ToString();

                                                        oexcelRange = ((Excel.Range)oSheet.Cells[8, 4]);                                                        
                                                        oexcelRange.Value2 = ds1.Tables[0].Rows[j]["Address"].ToString();

                                                        //oexcelRange = ((Excel.Range)oSheet.Cells[8, 11]);                                                        
                                                        //oexcelRange.Value2 = ds1.Tables[0].Rows[j]["Company_name"].ToString();

                                                        oexcelRange = ((Excel.Range)oSheet.Cells[8, 11]);
                                                        oexcelRange.Value2 = ds1.Tables[0].Rows[j]["OFF_NAME"].ToString();

                                                        oexcelRange = ((Excel.Range)oSheet.Cells[9, 4]);
                                                        oexcelRange.Value2 = ds1.Tables[0].Rows[j]["YEARS_AT_RESIDENCE"].ToString();

                                                        oexcelRange = ((Excel.Range)oSheet.Cells[9, 11]);                                                        
                                                        oexcelRange.Value2 = ds1.Tables[0].Rows[j]["Verifier_Comments"].ToString();

                                                        oexcelRange = ((Excel.Range)oSheet.Cells[10, 4]);
                                                        oexcelRange.Value2 = ds1.Tables[0].Rows[j]["Permanent_address"].ToString();

                                                        oexcelRange = ((Excel.Range)oSheet.Cells[11, 4]);
                                                        oexcelRange.Value2 = ds1.Tables[0].Rows[j]["STATUS_NAME"].ToString();

                                                        oexcelRange = ((Excel.Range)oSheet.Cells[11, 11]);
                                                        oexcelRange.Value2 = ds1.Tables[0].Rows[j]["Unsatisfactory_Reason"].ToString();

                                                        ///FOR ATTEMPTS

                                                        OleDbDataReader oledbRTVAttemptRead;
                                                        string sSql = "";
                                                        sSql = " SELECT * FROM CPV_RL_VERIFICATION_ATTEMPT " +
                                                               " WHERE CASE_ID='" + strCaseID + "' AND VERIFICATION_TYPE_ID='" + strTypeID + "'";
                                                        oledbRTVAttemptRead = OleDbHelper.ExecuteReader(oCmn.ConnectionString, CommandType.Text, sSql);
                                                        int iColRTAttempt = 4;
                                                        while(oledbRTVAttemptRead.Read() == true)
                                                        {
                                                            string[] sArrAttempt = oledbRTVAttemptRead["ATTEMPT_DATETIME"].ToString().Split(' ');
                                                            string strAttemptDate = "";
                                                            string strAttemptTime = "";
                                                            if (sArrAttempt.Length > 0)
                                                            {
                                                                strAttemptDate = Convert.ToDateTime(sArrAttempt[0].ToString().Trim()).ToString("dd/MM/yyyy");
                                                                if (sArrAttempt.Length > 1)
                                                                {
                                                                    strAttemptTime = sArrAttempt[1].ToString().Trim() +
                                                                                     sArrAttempt[2].ToString().Trim();
                                                                }
                                                            }

                                                            oexcelRange = ((Excel.Range)oSheet.Cells[13, iColRTAttempt]);                                                            
                                                            oexcelRange.Value2 = strAttemptDate;

                                                            oexcelRange = ((Excel.Range)oSheet.Cells[14, iColRTAttempt]);                                                            
                                                            oexcelRange.Value2 = Convert.ToDateTime(strAttemptTime).ToString("hh:mm tt");

                                                            oexcelRange = ((Excel.Range)oSheet.Cells[15, iColRTAttempt]);
                                                            oexcelRange.Value2 = oledbRTVAttemptRead["Attempt_Remark"].ToString(); 

                                                            iColRTAttempt+=1;
                                                        }                                                        
                                                        
                                                        break;
                                                    case 3: //For BTV
                                                        
                                                        oSheet = (Excel._Worksheet)oBook.Worksheets["BTV"];
                                                        oSheet.Visible = Excel.XlSheetVisibility.xlSheetVisible;
                                                        oSheet.Unprotect(oMissing);

                                                        oexcelRange = ((Excel.Range)oSheet.Cells[3, 3]);
                                                        oexcelRange.Value2 = ds1.Tables[0].Rows[j]["Area"].ToString();

                                                        oexcelRange = ((Excel.Range)oSheet.Cells[3, 10]);
                                                        oexcelRange.Value2 = ds1.Tables[0].Rows[j]["REF_NO"].ToString();

                                                        string sVerDateTimeBTV = ds1.Tables[0].Rows[j]["VERIFICATION_DATETIME"].ToString();
                                                        string sVerDateBTV = "";
                                                        if (sVerDateTimeBTV != "")
                                                        {
                                                            string[] arrVerDateTime = sVerDateTimeBTV.Split(' ');
                                                            if (arrVerDateTime[0].ToString().Trim() != "")
                                                            {
                                                                if (arrVerDateTime[0].ToString() != "")
                                                                {
                                                                    sVerDateBTV += Convert.ToDateTime(arrVerDateTime[0].ToString()).ToString("dd/MM/yyyy");
                                                                }
                                                                if (arrVerDateTime[1].ToString() != "" && arrVerDateTime[2].ToString() != "")
                                                                {

                                                                    sVerDateBTV += " " + arrVerDateTime[1].ToString() + " " + arrVerDateTime[2].ToString();
                                                                }
                                                            }
                                                        }
                                                        oexcelRange = ((Excel.Range)oSheet.Cells[3, 12]);
                                                        oexcelRange.Value2 = sVerDateBTV;

                                                        oexcelRange = ((Excel.Range)oSheet.Cells[4, 4]);
                                                        oexcelRange.Value2 = ds1.Tables[0].Rows[j]["APPNAME"].ToString();

                                                        oexcelRange = ((Excel.Range)oSheet.Cells[4, 11]);
                                                        oexcelRange.Value2 = ds1.Tables[0].Rows[j]["Type_oF_Phone"].ToString();

                                                        oexcelRange = ((Excel.Range)oSheet.Cells[6, 4]);
                                                        oexcelRange.Value2 = ds1.Tables[0].Rows[j]["PERSON_CONFIRM_ADDRESS"].ToString();

                                                        oexcelRange = ((Excel.Range)oSheet.Cells[6, 8]);
                                                        oexcelRange.Value2 = ds1.Tables[0].Rows[j]["OFF_ADDRESS"].ToString();

                                                        oexcelRange = ((Excel.Range)oSheet.Cells[7, 4]);
                                                        oexcelRange.Value2 = ds1.Tables[0].Rows[j]["Person_Contacted"].ToString();

                                                        oexcelRange = ((Excel.Range)oSheet.Cells[7, 11]);
                                                        oexcelRange.Value2 = ds1.Tables[0].Rows[j]["Nature_Business"].ToString();

                                                        oexcelRange = ((Excel.Range)oSheet.Cells[8, 4]);
                                                        oexcelRange.Value2 = ds1.Tables[0].Rows[j]["OFF_NAME"].ToString();

                                                        oexcelRange = ((Excel.Range)oSheet.Cells[8, 11]);
                                                        oexcelRange.Value2 = ds1.Tables[0].Rows[j]["Designation_contacted_person"].ToString();

                                                        oexcelRange = ((Excel.Range)oSheet.Cells[9, 4]);
                                                        oexcelRange.Value2 = ds1.Tables[0].Rows[j]["Office_Address"].ToString();

                                                        oexcelRange = ((Excel.Range)oSheet.Cells[9, 11]);
                                                        oexcelRange.Value2 = ds1.Tables[0].Rows[j]["Office_Name"].ToString();

                                                        oexcelRange = ((Excel.Range)oSheet.Cells[10, 4]);
                                                        oexcelRange.Value2 = ds1.Tables[0].Rows[j]["No_year_service"].ToString();

                                                        oexcelRange = ((Excel.Range)oSheet.Cells[10, 11]);
                                                        oexcelRange.Value2 = ds1.Tables[0].Rows[j]["Type_Industry"].ToString();

                                                        oexcelRange = ((Excel.Range)oSheet.Cells[11, 4]);
                                                        oexcelRange.Value2 = ds1.Tables[0].Rows[j]["Type_Office"].ToString();

                                                        oexcelRange = ((Excel.Range)oSheet.Cells[11, 11]);
                                                        oexcelRange.Value2 = ds1.Tables[0].Rows[j]["Remarks"].ToString();

                                                        oexcelRange = ((Excel.Range)oSheet.Cells[12, 4]);
                                                        oexcelRange.Value2 = ds1.Tables[0].Rows[j]["STATUS_NAME"].ToString();

                                                        oexcelRange = ((Excel.Range)oSheet.Cells[12, 11]);
                                                        oexcelRange.Value2 = ds1.Tables[0].Rows[j]["Unsatisfactory_Reason"].ToString();

                                                        ///FOR ATTEMPTS

                                                        OleDbDataReader oledbBTVAttemptRead;
                                                        string sSqlBT = "";
                                                        sSqlBT = " SELECT * FROM CPV_RL_VERIFICATION_ATTEMPT " +
                                                               " WHERE CASE_ID='" + strCaseID + "' AND VERIFICATION_TYPE_ID='" + strTypeID + "'";
                                                        oledbBTVAttemptRead = OleDbHelper.ExecuteReader(oCmn.ConnectionString, CommandType.Text, sSqlBT);
                                                        int iColBTAttempt = 4;
                                                        while (oledbBTVAttemptRead.Read() == true)
                                                        {
                                                            string[] sArrAttempt = oledbBTVAttemptRead["ATTEMPT_DATETIME"].ToString().Split(' ');
                                                            string strAttemptDate = "";
                                                            string strAttemptTime = "";
                                                            if (sArrAttempt.Length > 0)
                                                            {
                                                                strAttemptDate = Convert.ToDateTime(sArrAttempt[0].ToString().Trim()).ToString("dd/MM/yyyy");
                                                                if (sArrAttempt.Length > 1)
                                                                {
                                                                    strAttemptTime = sArrAttempt[1].ToString().Trim() +
                                                                                     sArrAttempt[2].ToString().Trim();
                                                                }
                                                            }

                                                            oexcelRange = ((Excel.Range)oSheet.Cells[14, iColBTAttempt]);
                                                            oexcelRange.Value2 = strAttemptDate;

                                                            oexcelRange = ((Excel.Range)oSheet.Cells[15, iColBTAttempt]);
                                                            oexcelRange.Value2 = Convert.ToDateTime(strAttemptTime).ToString("hh:mm tt");

                                                            oexcelRange = ((Excel.Range)oSheet.Cells[16, iColBTAttempt]);
                                                            oexcelRange.Value2 = oledbBTVAttemptRead["Attempt_Remark"].ToString(); 

                                                            iColBTAttempt += 1;
                                                        }       

                                                        break;
                                                    case 14:    //For RCO

                                                        oSheet = (Excel._Worksheet)oBook.Worksheets["Resi Cum Office"];
                                                        oSheet.Visible = Excel.XlSheetVisibility.xlSheetVisible;
                                                        oSheet.Unprotect(oMissing);

                                                        string sVerDateTimeRCO = ds1.Tables[0].Rows[j]["VERIFICATION_DATETIME"].ToString();
                                                        if (sVerDateTimeRCO != "")
                                                        {
                                                            string[] arrVerDateTime = sVerDateTimeRCO.Split(' ');
                                                            if (arrVerDateTime[0].ToString().Trim() != "")
                                                            {
                                                                if (arrVerDateTime[0].ToString() != "")
                                                                {
                                                                    oexcelRange = ((Excel.Range)oSheet.Cells[6, 4]);
                                                                    oexcelRange.Value2 = Convert.ToDateTime(arrVerDateTime[0].ToString()).ToString("dd/MM/yyyy");
                                                                }
                                                                if (arrVerDateTime[1].ToString() != "" && arrVerDateTime[2].ToString() != "")
                                                                {
                                                                    oexcelRange = ((Excel.Range)oSheet.Cells[6, 10]);
                                                                    oexcelRange.Value2 = arrVerDateTime[1].ToString() + " " + arrVerDateTime[2].ToString();
                                                                }
                                                            }
                                                        }
                                                        
                                                        oexcelRange = ((Excel.Range)oSheet.Cells[7, 4]);
                                                        oexcelRange.Value2 = "PAMAC";

                                                        oexcelRange = ((Excel.Range)oSheet.Cells[5, 10]);
                                                        oexcelRange.Value2 = ds1.Tables[0].Rows[j]["REF_NO"].ToString();

                                                        oexcelRange = ((Excel.Range)oSheet.Cells[7, 10]);
                                                        oexcelRange.Value2 = ds1.Tables[0].Rows[j]["FE"].ToString();

                                                        oexcelRange = ((Excel.Range)oSheet.Cells[9, 5]);
                                                        oexcelRange.Value2 = ds1.Tables[0].Rows[j]["APPNAME"].ToString();

                                                        oexcelRange = ((Excel.Range)oSheet.Cells[10, 5]);                                                        
                                                        oexcelRange.Value2 = ds1.Tables[0].Rows[j]["RESI_ADDRESS"].ToString();

                                                        oexcelRange = ((Excel.Range)oSheet.Cells[12, 5]);
                                                        oexcelRange.Value2 = ds1.Tables[0].Rows[j]["Name_Neighbour1"].ToString();

                                                        oexcelRange = ((Excel.Range)oSheet.Cells[13, 5]);
                                                        oexcelRange.Value2 = ds1.Tables[0].Rows[j]["Address_Neighbour1"].ToString();

                                                        oexcelRange = ((Excel.Range)oSheet.Cells[14, 5]);
                                                        oexcelRange.Value2 = ds1.Tables[0].Rows[j]["Neighbour1_confirmation"].ToString();

                                                        oexcelRange = ((Excel.Range)oSheet.Cells[14, 10]);
                                                        oexcelRange.Value2 = ds1.Tables[0].Rows[j]["Month_at_office"].ToString();

                                                        oexcelRange = ((Excel.Range)oSheet.Cells[15, 5]);
                                                        oexcelRange.Value2 = ds1.Tables[0].Rows[j]["Market_Reputation_Neighbour1"].ToString();

                                                        oexcelRange = ((Excel.Range)oSheet.Cells[15, 10]);
                                                        oexcelRange.Value2 = ds1.Tables[0].Rows[j]["Month_Stay_Resi_Neigh1"].ToString();

                                                        //oexcelRange = ((Excel.Range)oSheet.Cells[15, 10]);
                                                        //oexcelRange.Value2 = ds1.Tables[0].Rows[j]["Months_stay_residencE"].ToString();

                                                        oexcelRange = ((Excel.Range)oSheet.Cells[16, 5]);
                                                        oexcelRange.Value2 = ds1.Tables[0].Rows[j]["Office_self_owned1"].ToString();

                                                        oexcelRange = ((Excel.Range)oSheet.Cells[17, 5]);
                                                        oexcelRange.Value2 = ds1.Tables[0].Rows[j]["neighbour1_comment1"].ToString();

                                                        oexcelRange = ((Excel.Range)oSheet.Cells[19, 5]);
                                                        oexcelRange.Value2 = ds1.Tables[0].Rows[j]["Name_Neighbour2"].ToString();

                                                        oexcelRange = ((Excel.Range)oSheet.Cells[20, 5]);
                                                        oexcelRange.Value2 = ds1.Tables[0].Rows[j]["Address_Neighbour2"].ToString();

                                                        oexcelRange = ((Excel.Range)oSheet.Cells[21, 5]);
                                                        oexcelRange.Value2 = ds1.Tables[0].Rows[j]["Neighbour1_confirmation2"].ToString();

                                                        oexcelRange = ((Excel.Range)oSheet.Cells[21, 10]);
                                                        oexcelRange.Value2 = ds1.Tables[0].Rows[j]["Month_at_office1"].ToString();

                                                        oexcelRange = ((Excel.Range)oSheet.Cells[22, 5]);
                                                        oexcelRange.Value2 = ds1.Tables[0].Rows[j]["Market_Reputation_Neighbour2"].ToString();

                                                        oexcelRange = ((Excel.Range)oSheet.Cells[22, 10]);
                                                        oexcelRange.Value2 = ds1.Tables[0].Rows[j]["Month_Stay_Resi_Neigh2"].ToString();

                                                        oexcelRange = ((Excel.Range)oSheet.Cells[23, 5]);
                                                        oexcelRange.Value2 = ds1.Tables[0].Rows[j]["Office_self_owned2"].ToString();
                                                     
                                                        oexcelRange = ((Excel.Range)oSheet.Cells[24, 5]);
                                                        oexcelRange.Value2 = ds1.Tables[0].Rows[j]["Comments_Neighbour2"].ToString();

                                                        oexcelRange = ((Excel.Range)oSheet.Cells[27, 5]);
                                                        oexcelRange.Value2 = ds1.Tables[0].Rows[j]["Locality"].ToString();

                                                        oexcelRange = ((Excel.Range)oSheet.Cells[27, 10]);
                                                        oexcelRange.Value2 = ds1.Tables[0].Rows[j]["Landmark"].ToString();

                                                        oexcelRange = ((Excel.Range)oSheet.Cells[28, 5]);
                                                        oexcelRange.Value2 = ds1.Tables[0].Rows[j]["Type_Business_Activity"].ToString();

                                                        oexcelRange = ((Excel.Range)oSheet.Cells[28, 10]);
                                                        oexcelRange.Value2 = ds1.Tables[0].Rows[j]["Level_Business_Activity"].ToString();

                                                        oexcelRange = ((Excel.Range)oSheet.Cells[29, 5]);
                                                        oexcelRange.Value2 = ds1.Tables[0].Rows[j]["Stock_Seen"].ToString();

                                                        oexcelRange = ((Excel.Range)oSheet.Cells[29, 10]);
                                                        oexcelRange.Value2 = ds1.Tables[0].Rows[j]["NO_EMP_SEEN"].ToString();

                                                        oexcelRange = ((Excel.Range)oSheet.Cells[30, 5]);
                                                        oexcelRange.Value2 = ds1.Tables[0].Rows[j]["Accessibility"].ToString();

                                                        oexcelRange = ((Excel.Range)oSheet.Cells[30, 10]);
                                                        oexcelRange.Value2 = ds1.Tables[0].Rows[j]["Entrance_Motorable"].ToString();

                                                        oexcelRange = ((Excel.Range)oSheet.Cells[31, 6]);
                                                        oexcelRange.Value2 = ds1.Tables[0].Rows[j]["Clear_demarcation_RES_OFFICE"].ToString();

                                                        oexcelRange = ((Excel.Range)oSheet.Cells[31, 10]);
                                                        oexcelRange.Value2 = ds1.Tables[0].Rows[j]["External_Condition"].ToString();

                                                        oexcelRange = ((Excel.Range)oSheet.Cells[32, 5]);
                                                        oexcelRange.Value2 = ds1.Tables[0].Rows[j]["Internal_condition"].ToString();

                                                        oexcelRange = ((Excel.Range)oSheet.Cells[34, 5]);
                                                        oexcelRange.Value2 = ds1.Tables[0].Rows[j]["Name_Plate_Sighted_Resi"].ToString();

                                                        oexcelRange = ((Excel.Range)oSheet.Cells[35, 5]);
                                                        oexcelRange.Value2 = ds1.Tables[0].Rows[j]["Entry_permitted_Resi"].ToString();

                                                        oexcelRange = ((Excel.Range)oSheet.Cells[36, 5]);
                                                        oexcelRange.Value2 = ds1.Tables[0].Rows[j]["Approx_Area_Resi"].ToString();

                                                        oexcelRange = ((Excel.Range)oSheet.Cells[34, 10]);
                                                        oexcelRange.Value2 = ds1.Tables[0].Rows[j]["Name_Plate_Sighted_Office"].ToString();

                                                        oexcelRange = ((Excel.Range)oSheet.Cells[35, 10]);
                                                        oexcelRange.Value2 = ds1.Tables[0].Rows[j]["Entry_permitted_Office"].ToString();

                                                        oexcelRange = ((Excel.Range)oSheet.Cells[36, 10]);
                                                        oexcelRange.Value2 = ds1.Tables[0].Rows[j]["Approx_Area_Office"].ToString();

                                                        oexcelRange = ((Excel.Range)oSheet.Cells[37, 5]);
                                                        oexcelRange.Value2 = ds1.Tables[0].Rows[j]["Asset_Seen"].ToString().Replace("Other,","");

                                                        oexcelRange = ((Excel.Range)oSheet.Cells[37, 10]);
                                                        oexcelRange.Value2 = ds1.Tables[0].Rows[j]["ROOF_Type"].ToString();

                                                        oexcelRange = ((Excel.Range)oSheet.Cells[38, 5]);
                                                        oexcelRange.Value2 = ds1.Tables[0].Rows[j]["SEP_BATHROOM_SEEN"].ToString();

                                                        oexcelRange = ((Excel.Range)oSheet.Cells[38, 10]);
                                                        oexcelRange.Value2 = ds1.Tables[0].Rows[j]["FAMILY_SEEN"].ToString();

                                                        oexcelRange = ((Excel.Range)oSheet.Cells[41, 5]);
                                                        oexcelRange.Value2 = ds1.Tables[0].Rows[j]["Person_contacted"].ToString();

                                                        oexcelRange = ((Excel.Range)oSheet.Cells[41, 11]);
                                                        oexcelRange.Value2 = ds1.Tables[0].Rows[j]["Relationship"].ToString();

                                                        oexcelRange = ((Excel.Range)oSheet.Cells[42, 5]);
                                                        oexcelRange.Value2 = ds1.Tables[0].Rows[j]["Identity_proof_seen"].ToString();

                                                        oexcelRange = ((Excel.Range)oSheet.Cells[42, 11]);
                                                        oexcelRange.Value2 = ds1.Tables[0].Rows[j]["Business_proof_seen"].ToString();

                                                        oexcelRange = ((Excel.Range)oSheet.Cells[43, 5]);
                                                        oexcelRange.Value2 = ds1.Tables[0].Rows[j]["Nature_Business"].ToString();

                                                        oexcelRange = ((Excel.Range)oSheet.Cells[43, 11]);
                                                        oexcelRange.Value2 = ds1.Tables[0].Rows[j]["Type_Organization"].ToString();

                                                        oexcelRange = ((Excel.Range)oSheet.Cells[44, 5]);
                                                        oexcelRange.Value2 = ds1.Tables[0].Rows[j]["Status_Residence"].ToString();

                                                        oexcelRange = ((Excel.Range)oSheet.Cells[44, 11]);
                                                        oexcelRange.Value2 = ds1.Tables[0].Rows[j]["Months_work_current_office"].ToString();

                                                        oexcelRange = ((Excel.Range)oSheet.Cells[45, 5]);
                                                        oexcelRange.Value2 = ds1.Tables[0].Rows[j]["Months_stay_residencE"].ToString();

                                                        oexcelRange = ((Excel.Range)oSheet.Cells[45, 11]);
                                                        oexcelRange.Value2 = ds1.Tables[0].Rows[j]["Applicant_Income"].ToString();

                                                        oexcelRange = ((Excel.Range)oSheet.Cells[46, 5]);
                                                        oexcelRange.Value2 = ds1.Tables[0].Rows[j]["Other_sources_income"].ToString();

                                                        oexcelRange = ((Excel.Range)oSheet.Cells[46, 11]);
                                                        oexcelRange.Value2 = ds1.Tables[0].Rows[j]["previous_occupation"].ToString();

                                                        oexcelRange = ((Excel.Range)oSheet.Cells[47, 5]);
                                                        oexcelRange.Value2 = ds1.Tables[0].Rows[j]["FATHER_Spouse_Name"].ToString();

                                                        oexcelRange = ((Excel.Range)oSheet.Cells[47, 11]);
                                                        oexcelRange.Value2 = ds1.Tables[0].Rows[j]["MOTHER_NAME"].ToString();

                                                        oexcelRange = ((Excel.Range)oSheet.Cells[48, 5]);
                                                        oexcelRange.Value2 = ds1.Tables[0].Rows[j]["Marital_Status"].ToString();

                                                        oexcelRange = ((Excel.Range)oSheet.Cells[48, 11]);
                                                        oexcelRange.Value2 = ds1.Tables[0].Rows[j]["Other_Investments"].ToString();

                                                        oexcelRange = ((Excel.Range)oSheet.Cells[49, 5]);
                                                        oexcelRange.Value2 = ds1.Tables[0].Rows[j]["No_of_dependents"].ToString();

                                                        oexcelRange = ((Excel.Range)oSheet.Cells[49, 11]);
                                                        oexcelRange.Value2 = ds1.Tables[0].Rows[j]["DOB"].ToString();

                                                        oexcelRange = ((Excel.Range)oSheet.Cells[50, 5]);
                                                        oexcelRange.Value2 = ds1.Tables[0].Rows[j]["Purpose_Loan"].ToString();

                                                        oexcelRange = ((Excel.Range)oSheet.Cells[50, 11]);
                                                        oexcelRange.Value2 = ds1.Tables[0].Rows[j]["other_loans_TAKEN"].ToString();

                                                        oexcelRange = ((Excel.Range)oSheet.Cells[51, 5]);
                                                        oexcelRange.Value2 = ds1.Tables[0].Rows[j]["Education_Background"].ToString();

                                                        oexcelRange = ((Excel.Range)oSheet.Cells[51, 11]);
                                                        oexcelRange.Value2 = ds1.Tables[0].Rows[j]["behaviour_person_contacted"].ToString();

                                                        oexcelRange = ((Excel.Range)oSheet.Cells[52, 5]);
                                                        oexcelRange.Value2 = ds1.Tables[0].Rows[j]["Verifier_Comments1"].ToString();

                                                        oexcelRange = ((Excel.Range)oSheet.Cells[53, 2]);
                                                        oexcelRange.Value2 = ds1.Tables[0].Rows[j]["Verifier_Comments2"].ToString();

                                                        oexcelRange = ((Excel.Range)oSheet.Cells[54, 2]);
                                                        oexcelRange.Value2 = ds1.Tables[0].Rows[j]["Verifier_Comments3"].ToString();
                                                        
                                                        oexcelRange = ((Excel.Range)oSheet.Cells[55, 5]);
                                                        oexcelRange.Value2 = ds1.Tables[0].Rows[j]["SUPERVISOR_COMMENTS1"].ToString();

                                                        oexcelRange = ((Excel.Range)oSheet.Cells[56, 2]);
                                                        oexcelRange.Value2 = ds1.Tables[0].Rows[j]["SUPERVISOR_COMMENTS2"].ToString();

                                                        oexcelRange = ((Excel.Range)oSheet.Cells[57, 2]);
                                                        oexcelRange.Value2 = ds1.Tables[0].Rows[j]["SUPERVISOR_COMMENTS3"].ToString();

                                                        oexcelRange = ((Excel.Range)oSheet.Cells[58, 5]);
                                                        oexcelRange.Value2 = ds1.Tables[0].Rows[j]["Colour_Door"].ToString();

                                                        oexcelRange = ((Excel.Range)oSheet.Cells[58, 11]);
                                                        oexcelRange.Value2 = ds1.Tables[0].Rows[j]["Proof_Business_Acitivity"].ToString();

                                                        oexcelRange = ((Excel.Range)oSheet.Cells[59, 5]);
                                                        oexcelRange.Value2 = ds1.Tables[0].Rows[j]["Overall_Verification"].ToString();

                                                        break;
                                                    case 2:     //BV

                                                        //CHECK WHETHER SALARIED/SELF-EMPLOYED
                                                        string sSqlBV = "";
                                                        DataSet dsBV = new DataSet();
                                                        sSqlBV = "SELECT * FROM CPV_RL_verification_BVBT_view " +
                                                                  " WHERE CASE_ID='" + strCaseID + "' AND VERIFICATION_TYPE_ID='" + strTypeID + "'" +
                                                                  " and EMPLOYEE_TYPE LIKE '%SALARIED%' ";

                                                        dsBV = OleDbHelper.ExecuteDataset(oCmn.ConnectionString, CommandType.Text, sSqlBV);
                                                        //////SALARIED ----------------
                                                        if (dsBV.Tables[0].Rows.Count > 0)
                                                        {
                                                            oSheet = (Excel._Worksheet)oBook.Worksheets["BV- sal"];
                                                            oSheet.Visible = Excel.XlSheetVisibility.xlSheetVisible;
                                                            oSheet.Unprotect(oMissing);

                                                            string sVerDateTimeBVSAL = "";
                                                            sVerDateTimeBVSAL = ds1.Tables[0].Rows[j]["VERIFICATION_DATETIME"].ToString();
                                                            if (sVerDateTimeBVSAL != "")
                                                            {
                                                                string[] arrVerDateTime = sVerDateTimeBVSAL.Split(' ');
                                                                if (arrVerDateTime[0].ToString().Trim()!="")
                                                                {
                                                                    if (arrVerDateTime[0].ToString() != "")
                                                                    {
                                                                        oexcelRange = ((Excel.Range)oSheet.Cells[6, 4]);
                                                                        oexcelRange.Value2 = arrVerDateTime[0].ToString();
                                                                    }
                                                                    if (arrVerDateTime[1].ToString() != "" && arrVerDateTime[2].ToString() != "")
                                                                    {
                                                                        oexcelRange = ((Excel.Range)oSheet.Cells[6, 10]);
                                                                        oexcelRange.Value2 = arrVerDateTime[1].ToString() + " " + arrVerDateTime[2].ToString();
                                                                    }
                                                                }
                                                            }
                                                            oexcelRange = ((Excel.Range)oSheet.Cells[7, 4]);
                                                            oexcelRange.Value2 = "PAMAC";

                                                            oexcelRange = ((Excel.Range)oSheet.Cells[5, 10]);
                                                            oexcelRange.Value2 = ds1.Tables[0].Rows[j]["REF_NO"].ToString();

                                                            oexcelRange = ((Excel.Range)oSheet.Cells[7, 10]);
                                                            oexcelRange.Value2 = ds1.Tables[0].Rows[j]["FE"].ToString();

                                                            oexcelRange = ((Excel.Range)oSheet.Cells[9, 5]);
                                                            oexcelRange.Value2 = ds1.Tables[0].Rows[j]["APPNAME"].ToString();

                                                            oexcelRange = ((Excel.Range)oSheet.Cells[10, 5]);
                                                            oexcelRange.Value2 = ds1.Tables[0].Rows[j]["Office_Name"].ToString();

                                                            oexcelRange = ((Excel.Range)oSheet.Cells[11, 5]);
                                                            oexcelRange.Value2 = ds1.Tables[0].Rows[j]["Office_Address"].ToString();

                                                            oexcelRange = ((Excel.Range)oSheet.Cells[13, 5]);
                                                            oexcelRange.Value2 = ds1.Tables[0].Rows[j]["NAME_COLLEGUE"].ToString();

                                                            oexcelRange = ((Excel.Range)oSheet.Cells[14, 5]);
                                                            oexcelRange.Value2 = ds1.Tables[0].Rows[j]["DESGN_DEPT_COLLEGUE"].ToString();
                                                            
                                                            oexcelRange = ((Excel.Range)oSheet.Cells[15, 5]);
                                                            oexcelRange.Value2 = ds1.Tables[0].Rows[j]["MONTH_COMP_EXIST_ADDRESS"].ToString();

                                                            oexcelRange = ((Excel.Range)oSheet.Cells[16, 5]);
                                                            oexcelRange.Value2 = ds1.Tables[0].Rows[j]["Name_Neighbour1"].ToString();

                                                            oexcelRange = ((Excel.Range)oSheet.Cells[17, 5]);
                                                            oexcelRange.Value2 = ds1.Tables[0].Rows[j]["Address_Neighbour1"].ToString();

                                                            oexcelRange = ((Excel.Range)oSheet.Cells[18, 5]);
                                                            oexcelRange.Value2 = ds1.Tables[0].Rows[j]["Confirmation_Neighbour1"].ToString();

                                                            oexcelRange = ((Excel.Range)oSheet.Cells[18, 10]);
                                                            oexcelRange.Value2 = ds1.Tables[0].Rows[j]["Month_at_office1"].ToString();

                                                            oexcelRange = ((Excel.Range)oSheet.Cells[19, 5]);
                                                            oexcelRange.Value2 = ds1.Tables[0].Rows[j]["Market_Reputaion_Neighbour1"].ToString();

                                                            oexcelRange = ((Excel.Range)oSheet.Cells[20, 5]);
                                                            oexcelRange.Value2 = ds1.Tables[0].Rows[j]["Comments_Neighbour1"].ToString();

                                                            oexcelRange = ((Excel.Range)oSheet.Cells[21, 5]);
                                                            oexcelRange.Value2 = ds1.Tables[0].Rows[j]["PROFILE_CO_NEIGHBOUR"].ToString();

                                                            oexcelRange = ((Excel.Range)oSheet.Cells[22, 5]);
                                                            oexcelRange.Value2 = ds1.Tables[0].Rows[j]["Name_Neighbour2"].ToString();

                                                            oexcelRange = ((Excel.Range)oSheet.Cells[23, 5]);
                                                            oexcelRange.Value2 = ds1.Tables[0].Rows[j]["Address_Neighbour2"].ToString();

                                                            oexcelRange = ((Excel.Range)oSheet.Cells[24, 5]);
                                                            oexcelRange.Value2 = ds1.Tables[0].Rows[j]["Confirmation_Neighbour2"].ToString();

                                                            oexcelRange = ((Excel.Range)oSheet.Cells[24, 10]);
                                                            oexcelRange.Value2 = ds1.Tables[0].Rows[j]["Month_at_office2"].ToString();

                                                            oexcelRange = ((Excel.Range)oSheet.Cells[25, 5]);
                                                            oexcelRange.Value2 = ds1.Tables[0].Rows[j]["Market_Reputaion_Neighbour2"].ToString();

                                                            oexcelRange = ((Excel.Range)oSheet.Cells[26, 5]);
                                                            oexcelRange.Value2 = ds1.Tables[0].Rows[j]["Comments_Neighbour2"].ToString();

                                                            oexcelRange = ((Excel.Range)oSheet.Cells[28, 5]);
                                                            oexcelRange.Value2 = ds1.Tables[0].Rows[j]["Locality"].ToString();

                                                            oexcelRange = ((Excel.Range)oSheet.Cells[28, 10]);
                                                            oexcelRange.Value2 = ds1.Tables[0].Rows[j]["Landmark"].ToString();

                                                            oexcelRange = ((Excel.Range)oSheet.Cells[29, 5]);
                                                            oexcelRange.Value2 = ds1.Tables[0].Rows[j]["Business_activity"].ToString();

                                                            oexcelRange = ((Excel.Range)oSheet.Cells[29, 10]);
                                                            oexcelRange.Value2 = ds1.Tables[0].Rows[j]["Business_Activity_seen"].ToString();

                                                            oexcelRange = ((Excel.Range)oSheet.Cells[30, 5]);
                                                            oexcelRange.Value2 = ds1.Tables[0].Rows[j]["Equipment_Stock_sighted"].ToString();

                                                            oexcelRange = ((Excel.Range)oSheet.Cells[30, 10]);
                                                            oexcelRange.Value2 = ds1.Tables[0].Rows[j]["No_of_emp_seen"].ToString();

                                                            oexcelRange = ((Excel.Range)oSheet.Cells[31, 5]);
                                                            oexcelRange.Value2 = ds1.Tables[0].Rows[j]["Accessibility"].ToString();

                                                            oexcelRange = ((Excel.Range)oSheet.Cells[31, 10]);
                                                            oexcelRange.Value2 = ds1.Tables[0].Rows[j]["Enterance_Motorable"].ToString();

                                                            oexcelRange = ((Excel.Range)oSheet.Cells[32, 5]);
                                                            oexcelRange.Value2 = ds1.Tables[0].Rows[j]["Exterior_conditions"].ToString();

                                                            oexcelRange = ((Excel.Range)oSheet.Cells[32, 10]);
                                                            oexcelRange.Value2 = ds1.Tables[0].Rows[j]["Business_board_sighted"].ToString();

                                                            oexcelRange = ((Excel.Range)oSheet.Cells[33, 5]);
                                                            oexcelRange.Value2 = ds1.Tables[0].Rows[j]["Nam_Plate_sighted"].ToString();

                                                            oexcelRange = ((Excel.Range)oSheet.Cells[33, 10]);
                                                            oexcelRange.Value2 = ds1.Tables[0].Rows[j]["entry_permited"].ToString();

                                                            oexcelRange = ((Excel.Range)oSheet.Cells[34, 5]);
                                                            oexcelRange.Value2 = ds1.Tables[0].Rows[j]["APPLICANT_NAME_VERIFIED_FROM"].ToString();

                                                            oexcelRange = ((Excel.Range)oSheet.Cells[35, 5]);
                                                            oexcelRange.Value2 = ds1.Tables[0].Rows[j]["Interior_conditions"].ToString();

                                                            oexcelRange = ((Excel.Range)oSheet.Cells[35, 10]);
                                                            oexcelRange.Value2 = ds1.Tables[0].Rows[j]["Assets_Seen"].ToString().Replace("Others,","");

                                                            oexcelRange = ((Excel.Range)oSheet.Cells[36, 5]);
                                                            oexcelRange.Value2 = ds1.Tables[0].Rows[j]["Aprox_area"].ToString();

                                                            oexcelRange = ((Excel.Range)oSheet.Cells[39, 5]);
                                                            oexcelRange.Value2 = ds1.Tables[0].Rows[j]["Person_Contacted"].ToString();

                                                            oexcelRange = ((Excel.Range)oSheet.Cells[39, 11]);
                                                            oexcelRange.Value2 = ds1.Tables[0].Rows[j]["Relationship_applicant"].ToString();

                                                            oexcelRange = ((Excel.Range)oSheet.Cells[40, 5]);
                                                            oexcelRange.Value2 = ds1.Tables[0].Rows[j]["Identity_Proof_Seen"].ToString();

                                                            oexcelRange = ((Excel.Range)oSheet.Cells[40, 11]);
                                                            oexcelRange.Value2 = ds1.Tables[0].Rows[j]["Designation_contacted_person"].ToString();

                                                            oexcelRange = ((Excel.Range)oSheet.Cells[41, 5]);
                                                            oexcelRange.Value2 = ds1.Tables[0].Rows[j]["Designation"].ToString();

                                                            oexcelRange = ((Excel.Range)oSheet.Cells[41, 11]);
                                                            oexcelRange.Value2 = ds1.Tables[0].Rows[j]["Brief_Job_Responsibilities"].ToString();

                                                            oexcelRange = ((Excel.Range)oSheet.Cells[42, 5]);
                                                            oexcelRange.Value2 = ds1.Tables[0].Rows[j]["Type_Organization"].ToString();

                                                            oexcelRange = ((Excel.Range)oSheet.Cells[42, 11]);
                                                            oexcelRange.Value2 = ds1.Tables[0].Rows[j]["Status_Office"].ToString();

                                                            oexcelRange = ((Excel.Range)oSheet.Cells[43, 5]);
                                                            oexcelRange.Value2 = ds1.Tables[0].Rows[j]["No_of_current_office"].ToString();

                                                            oexcelRange = ((Excel.Range)oSheet.Cells[43, 11]);
                                                            oexcelRange.Value2 = ds1.Tables[0].Rows[j]["WORK_SHIFT"].ToString();

                                                            oexcelRange = ((Excel.Range)oSheet.Cells[44, 5]);
                                                            oexcelRange.Value2 = ds1.Tables[0].Rows[j]["Business_Proof_Seen"].ToString();

                                                            oexcelRange = ((Excel.Range)oSheet.Cells[44, 11]);
                                                            oexcelRange.Value2 = ds1.Tables[0].Rows[j]["Marital_Status"].ToString();

                                                            oexcelRange = ((Excel.Range)oSheet.Cells[45, 5]);
                                                            oexcelRange.Value2 = ds1.Tables[0].Rows[j]["Applicant_Income"].ToString();

                                                            oexcelRange = ((Excel.Range)oSheet.Cells[45, 11]);
                                                            oexcelRange.Value2 = ds1.Tables[0].Rows[j]["Residential_Address"].ToString();

                                                            oexcelRange = ((Excel.Range)oSheet.Cells[46, 5]);
                                                            oexcelRange.Value2 = ds1.Tables[0].Rows[j]["Other_Investment"].ToString();

                                                            oexcelRange = ((Excel.Range)oSheet.Cells[46, 11]);
                                                            oexcelRange.Value2 = ds1.Tables[0].Rows[j]["Any_other_Loan"].ToString();

                                                            oexcelRange = ((Excel.Range)oSheet.Cells[47, 5]);
                                                            oexcelRange.Value2 = ds1.Tables[0].Rows[j]["USE_OF_LOAN"].ToString();

                                                            oexcelRange = ((Excel.Range)oSheet.Cells[47, 11]);
                                                            oexcelRange.Value2 = ds1.Tables[0].Rows[j]["Behavour_person_contacted"].ToString();

                                                            oexcelRange = ((Excel.Range)oSheet.Cells[48, 5]);
                                                            oexcelRange.Value2 = ds1.Tables[0].Rows[j]["Education"].ToString();

                                                            oexcelRange = ((Excel.Range)oSheet.Cells[49, 5]);
                                                            oexcelRange.Value2 = ds1.Tables[0].Rows[j]["Verifier_Comments1"].ToString();

                                                            oexcelRange = ((Excel.Range)oSheet.Cells[50, 2]);
                                                            oexcelRange.Value2 = ds1.Tables[0].Rows[j]["Verifier_Comments2"].ToString();

                                                            oexcelRange = ((Excel.Range)oSheet.Cells[51, 2]);
                                                            oexcelRange.Value2 = ds1.Tables[0].Rows[j]["Verifier_Comments3"].ToString();

                                                            oexcelRange = ((Excel.Range)oSheet.Cells[52, 5]);
                                                            oexcelRange.Value2 = ds1.Tables[0].Rows[j]["SUPERVISOR_COMMENTS1"].ToString();

                                                            oexcelRange = ((Excel.Range)oSheet.Cells[53, 2]);
                                                            oexcelRange.Value2 = ds1.Tables[0].Rows[j]["SUPERVISOR_COMMENTS2"].ToString();

                                                            oexcelRange = ((Excel.Range)oSheet.Cells[54, 2]);
                                                            oexcelRange.Value2 = ds1.Tables[0].Rows[j]["SUPERVISOR_COMMENTS3"].ToString();

                                                            oexcelRange = ((Excel.Range)oSheet.Cells[55, 5]);
                                                            oexcelRange.Value2 = ds1.Tables[0].Rows[j]["Colour_Door"].ToString();

                                                            oexcelRange = ((Excel.Range)oSheet.Cells[55, 11]);
                                                            oexcelRange.Value2 = ds1.Tables[0].Rows[j]["Proof_Buss_Activity"].ToString();

                                                            oexcelRange = ((Excel.Range)oSheet.Cells[56, 5]);
                                                            oexcelRange.Value2 = ds1.Tables[0].Rows[j]["Overall_Verification"].ToString();

                                                        }                                                     

                                                        sSqlBV = "SELECT * FROM CPV_RL_verification_BVBT_view " +
                                                                  " WHERE CASE_ID='" + strCaseID + "' AND VERIFICATION_TYPE_ID='" + strTypeID + "'" +
                                                                  " and EMPLOYEE_TYPE LIKE '%SELF EMPLOYED%' ";

                                                        dsBV = OleDbHelper.ExecuteDataset(oCmn.ConnectionString, CommandType.Text, sSqlBV);
                                                        if (dsBV.Tables[0].Rows.Count > 0)
                                                        {
                                                            oSheet = (Excel._Worksheet)oBook.Worksheets["BV- Self"];
                                                            oSheet.Visible = Excel.XlSheetVisibility.xlSheetVisible;
                                                            oSheet.Unprotect(oMissing);

                                                            string sVerDateTimeBVSelf = ds1.Tables[0].Rows[j]["VERIFICATION_DATETIME"].ToString();
                                                            if (sVerDateTimeBVSelf != "")
                                                            {
                                                                string[] arrVerDateTime = sVerDateTimeBVSelf.Split(' ');
                                                                if (arrVerDateTime[0].ToString().Trim() != "")
                                                                {
                                                                    if (arrVerDateTime[0].ToString() != "")
                                                                    {
                                                                        oexcelRange = ((Excel.Range)oSheet.Cells[6, 4]);
                                                                        oexcelRange.Value2 = arrVerDateTime[0].ToString();
                                                                    }
                                                                    if (arrVerDateTime[1].ToString() != "" && arrVerDateTime[2].ToString() != "")
                                                                    {
                                                                        oexcelRange = ((Excel.Range)oSheet.Cells[6, 10]);
                                                                        oexcelRange.Value2 = arrVerDateTime[1].ToString() + " " + arrVerDateTime[2].ToString();
                                                                    }
                                                                }
                                                            }
                                                            oexcelRange = ((Excel.Range)oSheet.Cells[5, 10]);
                                                            oexcelRange.Value2 = ds1.Tables[0].Rows[j]["REF_NO"].ToString();
                                                      
                                                            oexcelRange = ((Excel.Range)oSheet.Cells[7, 4]);
                                                            oexcelRange.Value2 = "PAMAC";

                                                            oexcelRange = ((Excel.Range)oSheet.Cells[7, 10]);
                                                            oexcelRange.Value2 = ds1.Tables[0].Rows[j]["FE"].ToString();

                                                            oexcelRange = ((Excel.Range)oSheet.Cells[9, 5]);
                                                            oexcelRange.Value2 = ds1.Tables[0].Rows[j]["APPNAME"].ToString();

                                                            oexcelRange = ((Excel.Range)oSheet.Cells[10, 5]);
                                                            oexcelRange.Value2 = ds1.Tables[0].Rows[j]["Office_Name"].ToString();

                                                            oexcelRange = ((Excel.Range)oSheet.Cells[11, 5]);
                                                            oexcelRange.Value2 = ds1.Tables[0].Rows[j]["Office_Address"].ToString();

                                                            oexcelRange = ((Excel.Range)oSheet.Cells[13, 5]);
                                                            oexcelRange.Value2 = ds1.Tables[0].Rows[j]["Name_Neighbour1"].ToString();

                                                            oexcelRange = ((Excel.Range)oSheet.Cells[14, 5]);
                                                            oexcelRange.Value2 = ds1.Tables[0].Rows[j]["Address_Neighbour1"].ToString();

                                                            oexcelRange = ((Excel.Range)oSheet.Cells[15, 5]);
                                                            oexcelRange.Value2 = ds1.Tables[0].Rows[j]["Confirmation_Neighbour1"].ToString();

                                                            oexcelRange = ((Excel.Range)oSheet.Cells[15, 10]);
                                                            oexcelRange.Value2 = ds1.Tables[0].Rows[j]["Month_at_office1"].ToString();

                                                            oexcelRange = ((Excel.Range)oSheet.Cells[16, 5]);
                                                            oexcelRange.Value2 = ds1.Tables[0].Rows[j]["Market_Reputaion_Neighbour1"].ToString();

                                                            oexcelRange = ((Excel.Range)oSheet.Cells[17, 5]);
                                                            oexcelRange.Value2 = ds1.Tables[0].Rows[j]["IS_office_self_Neighbour1"].ToString();

                                                            oexcelRange = ((Excel.Range)oSheet.Cells[18, 5]);
                                                            oexcelRange.Value2 = ds1.Tables[0].Rows[j]["Comments_Neighbour1"].ToString();
                                                            

                                                            oexcelRange = ((Excel.Range)oSheet.Cells[20, 5]);
                                                            oexcelRange.Value2 = ds1.Tables[0].Rows[j]["Name_Neighbour2"].ToString();

                                                            oexcelRange = ((Excel.Range)oSheet.Cells[21, 5]);
                                                            oexcelRange.Value2 = ds1.Tables[0].Rows[j]["Address_Neighbour2"].ToString();

                                                            oexcelRange = ((Excel.Range)oSheet.Cells[22, 5]);
                                                            oexcelRange.Value2 = ds1.Tables[0].Rows[j]["Confirmation_Neighbour2"].ToString();

                                                            oexcelRange = ((Excel.Range)oSheet.Cells[22, 10]);
                                                            oexcelRange.Value2 = ds1.Tables[0].Rows[j]["Month_at_office2"].ToString();

                                                            oexcelRange = ((Excel.Range)oSheet.Cells[23, 5]);
                                                            oexcelRange.Value2 = ds1.Tables[0].Rows[j]["Market_Reputaion_Neighbour2"].ToString();

                                                            oexcelRange = ((Excel.Range)oSheet.Cells[24, 5]);
                                                            oexcelRange.Value2 = ds1.Tables[0].Rows[j]["IS_office_self_Neighbour2"].ToString();
                                                            
                                                            oexcelRange = ((Excel.Range)oSheet.Cells[25, 5]);
                                                            oexcelRange.Value2 = ds1.Tables[0].Rows[j]["Comments_Neighbour2"].ToString();

                                                            oexcelRange = ((Excel.Range)oSheet.Cells[27, 5]);
                                                            oexcelRange.Value2 = ds1.Tables[0].Rows[j]["Locality"].ToString();

                                                            oexcelRange = ((Excel.Range)oSheet.Cells[27, 10]);
                                                            oexcelRange.Value2 = ds1.Tables[0].Rows[j]["Landmark"].ToString();

                                                            oexcelRange = ((Excel.Range)oSheet.Cells[28, 5]);
                                                            oexcelRange.Value2 = ds1.Tables[0].Rows[j]["Business_activity"].ToString();

                                                            oexcelRange = ((Excel.Range)oSheet.Cells[28, 10]);
                                                            oexcelRange.Value2 = ds1.Tables[0].Rows[j]["Business_Activity_seen"].ToString();

                                                            oexcelRange = ((Excel.Range)oSheet.Cells[29, 5]);
                                                            oexcelRange.Value2 = ds1.Tables[0].Rows[j]["Equipment_Stock_sighted"].ToString();

                                                            oexcelRange = ((Excel.Range)oSheet.Cells[29, 10]);
                                                            oexcelRange.Value2 = ds1.Tables[0].Rows[j]["No_of_emp_seen"].ToString();

                                                            oexcelRange = ((Excel.Range)oSheet.Cells[30, 5]);
                                                            oexcelRange.Value2 = ds1.Tables[0].Rows[j]["Accessibility"].ToString();

                                                            oexcelRange = ((Excel.Range)oSheet.Cells[30, 10]);
                                                            oexcelRange.Value2 = ds1.Tables[0].Rows[j]["Enterance_Motorable"].ToString();

                                                            oexcelRange = ((Excel.Range)oSheet.Cells[31, 5]);
                                                            oexcelRange.Value2 = ds1.Tables[0].Rows[j]["Exterior_conditions"].ToString();

                                                            oexcelRange = ((Excel.Range)oSheet.Cells[31, 10]);
                                                            oexcelRange.Value2 = ds1.Tables[0].Rows[j]["Business_board_sighted"].ToString();

                                                            oexcelRange = ((Excel.Range)oSheet.Cells[32, 5]);
                                                            oexcelRange.Value2 = ds1.Tables[0].Rows[j]["ROOF_TYPE"].ToString();

                                                            oexcelRange = ((Excel.Range)oSheet.Cells[33, 5]);
                                                            oexcelRange.Value2 = ds1.Tables[0].Rows[j]["Nam_Plate_sighted"].ToString();

                                                            oexcelRange = ((Excel.Range)oSheet.Cells[33, 11]);
                                                            oexcelRange.Value2 = ds1.Tables[0].Rows[j]["entry_permited"].ToString();

                                                            oexcelRange = ((Excel.Range)oSheet.Cells[34, 5]);
                                                            oexcelRange.Value2 = ds1.Tables[0].Rows[j]["Interior_conditions"].ToString();

                                                            oexcelRange = ((Excel.Range)oSheet.Cells[34, 10]);
                                                            oexcelRange.Value2 = ds1.Tables[0].Rows[j]["Assets_Seen"].ToString().Replace("Others,","");

                                                            oexcelRange = ((Excel.Range)oSheet.Cells[35, 5]);
                                                            oexcelRange.Value2 = ds1.Tables[0].Rows[j]["Aprox_area"].ToString();

                                                            oexcelRange = ((Excel.Range)oSheet.Cells[38, 5]);
                                                            oexcelRange.Value2 = ds1.Tables[0].Rows[j]["Person_Contacted"].ToString();

                                                            oexcelRange = ((Excel.Range)oSheet.Cells[38, 11]);
                                                            oexcelRange.Value2 = ds1.Tables[0].Rows[j]["Relationship_applicant"].ToString();

                                                            oexcelRange = ((Excel.Range)oSheet.Cells[39, 5]);
                                                            oexcelRange.Value2 = ds1.Tables[0].Rows[j]["Identity_Proof_Seen"].ToString();

                                                            oexcelRange = ((Excel.Range)oSheet.Cells[39, 11]);
                                                            oexcelRange.Value2 = ds1.Tables[0].Rows[j]["Designation_contacted_person"].ToString();

                                                            oexcelRange = ((Excel.Range)oSheet.Cells[40, 5]);
                                                            oexcelRange.Value2 = ds1.Tables[0].Rows[j]["Designation"].ToString();

                                                            oexcelRange = ((Excel.Range)oSheet.Cells[40, 11]);
                                                            oexcelRange.Value2 = ds1.Tables[0].Rows[j]["Brief_Job_Responsibilities"].ToString();

                                                            oexcelRange = ((Excel.Range)oSheet.Cells[41, 5]);
                                                            oexcelRange.Value2 = ds1.Tables[0].Rows[j]["Type_Organization"].ToString();

                                                            oexcelRange = ((Excel.Range)oSheet.Cells[41, 11]);
                                                            oexcelRange.Value2 = ds1.Tables[0].Rows[j]["Status_Office"].ToString();

                                                            oexcelRange = ((Excel.Range)oSheet.Cells[42, 5]);
                                                            oexcelRange.Value2 = ds1.Tables[0].Rows[j]["No_of_current_office"].ToString();

                                                            oexcelRange = ((Excel.Range)oSheet.Cells[42, 11]);
                                                            oexcelRange.Value2 = ds1.Tables[0].Rows[j]["WORK_SHIFT"].ToString();

                                                            oexcelRange = ((Excel.Range)oSheet.Cells[43, 5]);
                                                            oexcelRange.Value2 = ds1.Tables[0].Rows[j]["Business_Proof_Seen"].ToString();

                                                            oexcelRange = ((Excel.Range)oSheet.Cells[43, 11]);
                                                            oexcelRange.Value2 = ds1.Tables[0].Rows[j]["Marital_Status"].ToString();

                                                            oexcelRange = ((Excel.Range)oSheet.Cells[44, 5]);
                                                            oexcelRange.Value2 = ds1.Tables[0].Rows[j]["Applicant_Income"].ToString();

                                                            oexcelRange = ((Excel.Range)oSheet.Cells[44, 11]);
                                                            oexcelRange.Value2 = ds1.Tables[0].Rows[j]["Residential_Address"].ToString();

                                                            oexcelRange = ((Excel.Range)oSheet.Cells[45, 5]);
                                                            oexcelRange.Value2 = ds1.Tables[0].Rows[j]["Other_Investment"].ToString();

                                                            oexcelRange = ((Excel.Range)oSheet.Cells[45, 11]);
                                                            oexcelRange.Value2 = ds1.Tables[0].Rows[j]["Any_other_Loan"].ToString();

                                                            oexcelRange = ((Excel.Range)oSheet.Cells[46, 5]);
                                                            oexcelRange.Value2 = ds1.Tables[0].Rows[j]["USE_OF_LOAN"].ToString();

                                                            oexcelRange = ((Excel.Range)oSheet.Cells[46, 11]);
                                                            oexcelRange.Value2 = ds1.Tables[0].Rows[j]["Behavour_person_contacted"].ToString();

                                                            oexcelRange = ((Excel.Range)oSheet.Cells[47, 5]);
                                                            oexcelRange.Value2 = ds1.Tables[0].Rows[j]["Education"].ToString();

                                                            oexcelRange = ((Excel.Range)oSheet.Cells[48, 5]);
                                                            oexcelRange.Value2 = ds1.Tables[0].Rows[j]["Verifier_Comment1"].ToString();

                                                            oexcelRange = ((Excel.Range)oSheet.Cells[49, 2]);
                                                            oexcelRange.Value2 = ds1.Tables[0].Rows[j]["Verifier_Comments2"].ToString();

                                                            oexcelRange = ((Excel.Range)oSheet.Cells[50, 2]);
                                                            oexcelRange.Value2 = ds1.Tables[0].Rows[j]["Verifier_Comments3"].ToString();

                                                            oexcelRange = ((Excel.Range)oSheet.Cells[51, 5]);
                                                            oexcelRange.Value2 = ds1.Tables[0].Rows[j]["SUPERVISOR_COMMENTS1"].ToString();

                                                            oexcelRange = ((Excel.Range)oSheet.Cells[52, 2]);
                                                            oexcelRange.Value2 = ds1.Tables[0].Rows[j]["SUPERVISOR_COMMENTS2"].ToString();

                                                            oexcelRange = ((Excel.Range)oSheet.Cells[53, 2]);
                                                            oexcelRange.Value2 = ds1.Tables[0].Rows[j]["SUPERVISOR_COMMENTS3"].ToString();

                                                            oexcelRange = ((Excel.Range)oSheet.Cells[54, 5]);
                                                            oexcelRange.Value2 = ds1.Tables[0].Rows[j]["Colour_Door"].ToString();

                                                            oexcelRange = ((Excel.Range)oSheet.Cells[54, 11]);
                                                            oexcelRange.Value2 = ds1.Tables[0].Rows[j]["Proof_Buss_Activity"].ToString();

                                                            oexcelRange = ((Excel.Range)oSheet.Cells[55, 5]);
                                                            oexcelRange.Value2 = ds1.Tables[0].Rows[j]["Overall_Verification"].ToString();

                                                        }
                                                        break;

                                                    case 12:     //REF1

                                                        oSheet = (Excel._Worksheet)oBook.Worksheets["REF 1"];
                                                        oSheet.Visible = Excel.XlSheetVisibility.xlSheetVisible;
                                                        oSheet.Unprotect(oMissing);

                                                        oexcelRange = ((Excel.Range)oSheet.Cells[4, 3]);
                                                        oexcelRange.Value2 = ds1.Tables[0].Rows[j]["Area"].ToString();

                                                        oexcelRange = ((Excel.Range)oSheet.Cells[4, 10]);
                                                        oexcelRange.Value2 = ds1.Tables[0].Rows[j]["REF_NO"].ToString();

                                                        string sVerDateTimeRef1 = ds1.Tables[0].Rows[j]["VERIFICATION_DATETIME"].ToString();
                                                        string sVerDateRef1 = "";
                                                        if (sVerDateTimeRef1 != "")
                                                        {
                                                            string[] arrVerDateTime = sVerDateTimeRef1.Split(' ');
                                                            if (arrVerDateTime[0].ToString().Trim() != "")
                                                            {
                                                                if (arrVerDateTime[0].ToString() != "")
                                                                {
                                                                    sVerDateRef1 += Convert.ToDateTime(arrVerDateTime[0].ToString()).ToString("dd/MM/yyyy");
                                                                }
                                                                if (arrVerDateTime[1].ToString() != "" && arrVerDateTime[2].ToString() != "")
                                                                {

                                                                    sVerDateRef1 += " " + arrVerDateTime[1].ToString() + " " + arrVerDateTime[2].ToString();
                                                                }
                                                            }
                                                        }
                                                        oexcelRange = ((Excel.Range)oSheet.Cells[4, 11]);
                                                        oexcelRange.Value2 = sVerDateRef1;

                                                        oexcelRange = ((Excel.Range)oSheet.Cells[5, 3]);
                                                        oexcelRange.Value2 = ds1.Tables[0].Rows[j]["APPNAME"].ToString();

                                                        oexcelRange = ((Excel.Range)oSheet.Cells[6, 3]);
                                                        oexcelRange.Value2 = ds1.Tables[0].Rows[j]["RESI_ADDRESS"].ToString();

                                                        oexcelRange = ((Excel.Range)oSheet.Cells[7, 8]);
                                                        oexcelRange.Value2 = ds1.Tables[0].Rows[j]["RESI_ADDRESS"].ToString();
                                                        
                                                        oexcelRange = ((Excel.Range)oSheet.Cells[8, 8]);
                                                        oexcelRange.Value2 = ds1.Tables[0].Rows[j]["Person_Contacted"].ToString();

                                                        oexcelRange = ((Excel.Range)oSheet.Cells[9, 3]);
                                                        oexcelRange.Value2 = ds1.Tables[0].Rows[j]["Relationship"].ToString();

                                                        oexcelRange = ((Excel.Range)oSheet.Cells[9, 8]);
                                                        oexcelRange.Value2 = ds1.Tables[0].Rows[j]["Number_Years_Residence"].ToString();

                                                        oexcelRange = ((Excel.Range)oSheet.Cells[10, 3]);
                                                        oexcelRange.Value2 = ds1.Tables[0].Rows[j]["Applicant_Know_Since"].ToString();

                                                        oexcelRange = ((Excel.Range)oSheet.Cells[10, 8]);
                                                        oexcelRange.Value2 = ds1.Tables[0].Rows[j]["Occupation"].ToString();

                                                        oexcelRange = ((Excel.Range)oSheet.Cells[11, 3]);
                                                        oexcelRange.Value2 = ds1.Tables[0].Rows[j]["Phone_number"].ToString();

                                                        oexcelRange = ((Excel.Range)oSheet.Cells[11, 8]);
                                                        oexcelRange.Value2 = ds1.Tables[0].Rows[j]["Emp_and_Business"].ToString();

                                                        oexcelRange = ((Excel.Range)oSheet.Cells[12, 8]);
                                                        oexcelRange.Value2 = ds1.Tables[0].Rows[j]["Designation_applicant"].ToString();

                                                        oexcelRange = ((Excel.Range)oSheet.Cells[13, 3]);
                                                        oexcelRange.Value2 = ds1.Tables[0].Rows[j]["Ref_Contacted_Confirms_App_Stay"].ToString();

                                                        oexcelRange = ((Excel.Range)oSheet.Cells[14, 3]);
                                                        oexcelRange.Value2 = ds1.Tables[0].Rows[j]["Residence_Address"].ToString();

                                                        oexcelRange = ((Excel.Range)oSheet.Cells[14, 8]);
                                                        oexcelRange.Value2 = ds1.Tables[0].Rows[j]["Address_Different"].ToString();

                                                        oexcelRange = ((Excel.Range)oSheet.Cells[16, 3]);
                                                        oexcelRange.Value2 = ds1.Tables[0].Rows[j]["Purpose"].ToString();

                                                        oexcelRange = ((Excel.Range)oSheet.Cells[17, 3]);
                                                        oexcelRange.Value2 = ds1.Tables[0].Rows[j]["MTNL_Check"].ToString();

                                                        oexcelRange = ((Excel.Range)oSheet.Cells[19, 3]);
                                                        oexcelRange.Value2 = ds1.Tables[0].Rows[j]["STATUS_NAME"].ToString();

                                                        break;
                                                      
                                                    case 13:     //REF2

                                                        oSheet = (Excel._Worksheet)oBook.Worksheets["REF 2"];
                                                        oSheet.Visible = Excel.XlSheetVisibility.xlSheetVisible;
                                                        oSheet.Unprotect(oMissing);

                                                        oexcelRange = ((Excel.Range)oSheet.Cells[4, 3]);
                                                        oexcelRange.Value2 = ds1.Tables[0].Rows[j]["Area"].ToString();

                                                        oexcelRange = ((Excel.Range)oSheet.Cells[4, 10]);
                                                        oexcelRange.Value2 = ds1.Tables[0].Rows[j]["REF_NO"].ToString();

                                                        string sVerDateTimeRef2 = ds1.Tables[0].Rows[j]["VERIFICATION_DATETIME"].ToString();
                                                        string sVerDateRef2 = "";
                                                        if (sVerDateTimeRef2 != "")
                                                        {
                                                            string[] arrVerDateTime = sVerDateTimeRef2.Split(' ');
                                                            if (arrVerDateTime[0].ToString().Trim() != "")
                                                            {
                                                                if (arrVerDateTime[0].ToString() != "")
                                                                {
                                                                    sVerDateRef2 += Convert.ToDateTime(arrVerDateTime[0].ToString()).ToString("dd/MM/yyyy");
                                                                }
                                                                if (arrVerDateTime[1].ToString() != "" && arrVerDateTime[2].ToString() != "")
                                                                {

                                                                    sVerDateRef2 += " " + arrVerDateTime[1].ToString() + " " + arrVerDateTime[2].ToString();
                                                                }
                                                            }
                                                        }
                                                        oexcelRange = ((Excel.Range)oSheet.Cells[4, 11]);
                                                        oexcelRange.Value2 = sVerDateRef2;

                                                        oexcelRange = ((Excel.Range)oSheet.Cells[5, 3]);
                                                        oexcelRange.Value2 = ds1.Tables[0].Rows[j]["APPNAME"].ToString();

                                                        oexcelRange = ((Excel.Range)oSheet.Cells[6, 3]);
                                                        oexcelRange.Value2 = ds1.Tables[0].Rows[j]["RESI_ADDRESS"].ToString();

                                                        oexcelRange = ((Excel.Range)oSheet.Cells[7, 8]);
                                                        oexcelRange.Value2 = ds1.Tables[0].Rows[j]["RESI_ADDRESS"].ToString();
                                                                                                               
                                                        oexcelRange = ((Excel.Range)oSheet.Cells[8, 8]);
                                                        oexcelRange.Value2 = ds1.Tables[0].Rows[j]["Person_Contacted"].ToString();

                                                        oexcelRange = ((Excel.Range)oSheet.Cells[9, 3]);
                                                        oexcelRange.Value2 = ds1.Tables[0].Rows[j]["Relationship"].ToString();

                                                        oexcelRange = ((Excel.Range)oSheet.Cells[9, 8]);
                                                        oexcelRange.Value2 = ds1.Tables[0].Rows[j]["Number_Years_Residence"].ToString();

                                                        oexcelRange = ((Excel.Range)oSheet.Cells[10, 3]);
                                                        oexcelRange.Value2 = ds1.Tables[0].Rows[j]["Applicant_Know_Since"].ToString();

                                                        oexcelRange = ((Excel.Range)oSheet.Cells[10, 8]);
                                                        oexcelRange.Value2 = ds1.Tables[0].Rows[j]["Occupation"].ToString();

                                                        oexcelRange = ((Excel.Range)oSheet.Cells[11, 3]);
                                                        oexcelRange.Value2 = ds1.Tables[0].Rows[j]["Phone_number"].ToString();

                                                        oexcelRange = ((Excel.Range)oSheet.Cells[11, 8]);
                                                        oexcelRange.Value2 = ds1.Tables[0].Rows[j]["Emp_and_Business"].ToString();

                                                        oexcelRange = ((Excel.Range)oSheet.Cells[12, 8]);
                                                        oexcelRange.Value2 = ds1.Tables[0].Rows[j]["Designation_applicant"].ToString();

                                                        oexcelRange = ((Excel.Range)oSheet.Cells[13, 3]);
                                                        oexcelRange.Value2 = ds1.Tables[0].Rows[j]["Ref_Contacted_Confirms_App_Stay"].ToString();

                                                        oexcelRange = ((Excel.Range)oSheet.Cells[14, 3]);
                                                        oexcelRange.Value2 = ds1.Tables[0].Rows[j]["Residence_Address"].ToString();

                                                        oexcelRange = ((Excel.Range)oSheet.Cells[14, 8]);
                                                        oexcelRange.Value2 = ds1.Tables[0].Rows[j]["Address_Different"].ToString();

                                                        oexcelRange = ((Excel.Range)oSheet.Cells[16, 3]);
                                                        oexcelRange.Value2 = ds1.Tables[0].Rows[j]["Purpose"].ToString();

                                                        oexcelRange = ((Excel.Range)oSheet.Cells[17, 3]);
                                                        oexcelRange.Value2 = ds1.Tables[0].Rows[j]["MTNL_Check"].ToString();

                                                        oexcelRange = ((Excel.Range)oSheet.Cells[19, 3]);
                                                        oexcelRange.Value2 = ds1.Tables[0].Rows[j]["STATUS_NAME"].ToString();                                                     

                                                        break;
                                                }
                                            }
                                        }
                                    }
                                }
                            }

                            ds.Clear();
                            oBook.Save();
                           
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
                hplDownload.NavigateUrl = ConfigurationManager.AppSettings["FtpPath"] + "//RL//" + Session["UserName"].ToString() + "//" + strDateTime + "//";                
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