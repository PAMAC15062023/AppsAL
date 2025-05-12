using System;
using System.Data;
using System.Data.OleDb;  
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class CPV_CC_CC_TC_Assign : System.Web.UI.Page
{
    DateTime dtfrom;
    DateTime dtto;
    CCommon objCommon = new CCommon();
    string strCreteria = "";
    protected void Page_Load(object sender, EventArgs e)
    {

        if (Session["isAdd"].ToString() != "1")
            Response.Redirect("NoAccess.aspx");

        lblMsg.Text = "";
        Label2.Visible = false;  
        if (!IsPostBack)
        {
            try
            {
                //ddlType.DataBind();
                //FillView();
            }
            catch (Exception exp)
            {
                lblMsg.Text = "Error occured operation faild. Error:" + exp.Message;
            }
        }
    }
    //////////public void FillView()
    //////////{
    //////////    try
    //////////    {
    //////////        String strCentreID = "";
    //////////        String strClientID = "";
    //////////        String strSql = "";
    //////////        strCentreID = Session["CentreId"].ToString();
    //////////        strClientID = Session["ClientId"].ToString();

    //////////        CCommon objCommon = new CCommon();

    //////////        if (strClientID != "" && strCentreID != "")
    //////////        {
    //////////            String strCreteria = "";
    //////////            if (txtDate.Text != "" && txtToDate.Text != "")
    //////////            {
    //////////                //strCreteria += " AND (CONVERT(VARCHAR, CD.CASE_REC_DATETIME,103)>='" + Convert.ToDateTime(objCommon.strDate(txtDate.Text.Trim())).ToString("MM/dd/yyyy") + "'AND (CONVERT(VARCHAR, CD.CASE_REC_DATETIME,103)<='" + Convert.ToDateTime(objCommon.strDate(txtToDate.Text.Trim())).ToString("MM/dd/yyyy") + "')";
    //////////                strCreteria += " AND (CONVERT(VARCHAR, CD.CASE_REC_DATETIME,103)>='" + Convert.ToDateTime(objCommon.strDate(txtDate.Text.Trim())).ToString("dd/MM/yyyy") + "' AND (CONVERT(VARCHAR, CD.CASE_REC_DATETIME,103)<='" + Convert.ToDateTime(objCommon.strDate(txtToDate.Text.Trim())).ToString("dd/MM/yyyy") + "') AND CV.VERIFICATION_TYPE_ID in ('4','3'))";
    //////////            }

    //////////            else
    //////////                lblMsg.Visible = true;
    //////////            //lblMsg.Text = "Please select date...........";

    //////////            //strCreteria += " AND CV.VERIFICATION_TYPE_ID in ('4','3')))";

    //////////            String strSelADDRes = "";
    //////////            String strseladdOff = "";
    //////////            {
    //////////                strSelADDRes = "(ISNULL(CD.RES_ADD_LINE_1+' ','') + ISNULL(CD.RES_ADD_LINE_2+' ','') + ISNULL(CD.RES_ADD_LINE_3+' ','')) AS [Resident Address], CD.RES_CITY AS [City], CD.RES_STATE AS [State], CD.RES_PIN_CODE AS [Pincode] ";
    //////////                strseladdOff = "(ISNULL(CD.OFF_ADD_LINE_1+' ','') + ISNULL(CD.OFF_ADD_LINE_2+' ','') + ISNULL(CD.OFF_ADD_LINE_3+' ','')) AS [Office Address], CD.OFF_CITY AS [City], CD.OFF_STATE AS [State], CD.OFF_PIN_CODE AS [Pincode] ";

    //////////            }

    //////////            strSql = "SELECT CD.CASE_ID AS [Case ID], CD.REF_NO AS [Refrence No], ISNULL(CD.TITLE + ' ', '') + ISNULL(CD.FIRST_NAME + ' ', '') +ISNULL(CD.MIDDLE_NAME + ' ', '') + ISNULL(CD.LAST_NAME + ' ', '') AS [Applicant Name], " +
    //////////                    "" + strSelADDRes + ", " + strseladdOff + ", CONVERT(VARCHAR, CD.CASE_REC_DATETIME, 103) AS [Recieved Date], cv.VERIFICATION_TYPE_ID as VerificationType FROM CPV_CC_CASE_DETAILS CD, CPV_CC_CASE_VERIFICATIONTYPE CV " +
    //////////                    "WHERE CD.CASE_ID = CV.CASE_ID AND (CD.SEND_DATETIME IS NULL OR CD.SEND_DATETIME = '') AND (IS_CASE_COMPLETE IS NULL OR IS_CASE_COMPLETE = '')AND CD.CLIENT_ID in ('10111','10140') " + strCreteria + " And not exists " +
    //////////                    "(select case_id from cpv_cc_tc_case_mapping where status in('A','R','M'))order by cd.case_id ";

    //////////            //hdnVerificatioTypeID.Value = ddlType.SelectedValue.ToString();
    //////////            //strSql = "SELECT CD.CASE_ID AS [Case ID], CD.REF_NO AS [Refrence No], ISNULL(CD.TITLE + ' ', '') + ISNULL(CD.FIRST_NAME + ' ', '') +ISNULL(CD.MIDDLE_NAME + ' ', '') + ISNULL(CD.LAST_NAME + ' ', '') AS [Applicant Name], " + strSelADDRes + "," + strseladdOff +
    //////////            //                "CONVERT(VARCHAR, CD.CASE_REC_DATETIME, 103) AS [Recieved Date], FV.FULLNAME AS [Assigned To],cv.VERIFICATION_TYPE_ID as VerificationType " +
    //////////            //                "FROM CPV_CC_CASE_DETAILS CD LEFT OUTER JOIN " +
    //////////            //                "CPV_CC_CASE_VERIFICATIONTYPE CV LEFT OUTER JOIN " +
    //////////            //                "TC_VW FV INNER JOIN CPV_CC_TC_CASE_MAPPING FE ON FV.EMP_ID = FE.TC_ID ON CV.CASE_ID = FE.CASE_ID AND " +
    //////////            //                "CV.VERIFICATION_TYPE_ID = FE.VERIFICATION_TYPE_ID ON CD.CASE_ID = CV.CASE_ID " +
    //////////            //    //"LEFT OUTER JOIN CPV_CC_VERI_DETAILS VD ON CD.CASE_ID = VD.CASE_ID " +
    //////////            //                "WHERE(CD.SEND_DATETIME IS NULL) AND CD.CLIENT_ID='" + strClientID + "' AND CD.CENTRE_ID='" + strCentreID + "'" + strCreteria;
    //////////        }
            
    //////////        sdsGV.SelectCommand = strSql;
    //////////        GVTCTOT.Visible = true;

    //////////        //if (gvFEAssignmentCases.Rows.Count <= 0)
    //////////        //{
    //////////        //    lblMsg.Text = "No record found";
    //////////        //}
    //////////    }
    //////////    catch (Exception ex)
    //////////    {
    //////////        lblMsg.Visible = true;
    //////////        lblMsg.Text = "Error while retreiving data: " + ex.Message;
    //////////    }
    //////////}
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        try

        {
            //FillView();
            bool isvaliddate = true;
            if (txtDate.Text.Trim() == "" || txtToDate.Text.Trim() == "")
            {
                isvaliddate = false;
                lblMsg.Visible = true;
                lblMsg.Text = "Please Enter From Date And To Date";
                lblMsg.ForeColor = System.Drawing.Color.Red;
                lblMsg.Font.Bold = true;
            }
            if (txtDate.Text.Trim() != "" && txtToDate.Text.Trim() != "")
            {
                dtfrom = Convert.ToDateTime(objCommon.strDate(txtDate.Text.Trim()));
                dtto = Convert.ToDateTime(objCommon.strDate(txtToDate.Text.Trim()));

                if (dtfrom > dtto)
                {
                    isvaliddate = false;
                    lblMsg.Visible = true;
                    lblMsg.Text = "From Date must be less than To Date";
                }
            }
            if (isvaliddate == true)
            {

                lblMsg.Text = "";
                string c;
                String strCentreID = "";
                String strClientID = "";
                String strSql = "";

                strCentreID = Session["CentreId"].ToString();
                strClientID = Session["ClientId"].ToString();
                String strCreteria = "";
                Label2.Visible = true;
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();

                strCreteria += " AND CONVERT(VARCHAR(10), CD.CASE_REC_DATETIME,103)>='" + Convert.ToDateTime(objCommon.strDate(txtDate.Text.Trim())).ToString("dd/MM/yyyy") + "' AND CONVERT(VARCHAR(10), CD.CASE_REC_DATETIME,103) <= '" + Convert.ToDateTime(objCommon.strDate(txtToDate.Text.Trim())).ToString("dd/MM/yyyy") + "' AND CV.VERIFICATION_TYPE_ID in ('4','3')";
                //strCreteria += " AND (CONVERT(VARCHAR, CD.CASE_REC_DATETIME,101)>='" + dtfrom + "' AND (CONVERT(VARCHAR, CD.CASE_REC_DATETIME,101)<='" + dtto + "') AND CV.VERIFICATION_TYPE_ID in ('4','3'))";

                strSql = "SELECT Count(*) FROM CPV_CC_CASE_DETAILS CD, CPV_CC_CASE_VERIFICATIONTYPE CV " +
                            "WHERE CD.CASE_ID = CV.CASE_ID AND (CD.SEND_DATETIME IS NULL OR CD.SEND_DATETIME = '') AND (IS_CASE_COMPLETE IS NULL OR IS_CASE_COMPLETE = '') AND CD.CLIENT_ID in ('10111','10140') " + strCreteria + " And CD.CASE_ID NOT IN " +
                            "(select case_id from cpv_cc_tc_case_mapping where status in('A','R','M') and datediff(day,convert(varchar(10),date_time,25),'" + Convert.ToDateTime(objCommon.strDate(txtDate.Text.Trim())).ToString("yyyy-MM-dd") + "') < 5)";
                //and datediff(dd,convert(varchar(10),date_time,103),'" + Convert.ToDateTime(txtToDate.Text.Trim()).ToString("DD/MM/YYYY") + "') < 10)";

                //strSql = "SELECT Count(*) FROM CPV_CC_CASE_DETAILS CD LEFT OUTER JOIN " +
                //                            "CPV_CC_CASE_VERIFICATIONTYPE CV LEFT OUTER JOIN " +
                //                            "TC_VW FV INNER JOIN CPV_CC_TC_CASE_MAPPING FE ON FV.EMP_ID = FE.TC_ID ON CV.CASE_ID = FE.CASE_ID AND " +
                //                            "CV.VERIFICATION_TYPE_ID = FE.VERIFICATION_TYPE_ID ON CD.CASE_ID = CV.CASE_ID " +
                //                            "WHERE(CD.SEND_DATETIME IS NULL) AND CD.CLIENT_ID='" + strClientID + "' AND CD.CENTRE_ID='" + strCentreID + "'" + strCreteria1;
                object obj = OleDbHelper.ExecuteScalar(objCommon.ConnectionString, CommandType.Text, strSql);
                c = obj.ToString();
                lbltot.Text = c;
                if (lbltot.Text == "" || lbltot.Text == "0")
                {
                    lblMsg.Visible = true;
                    lblMsg.Text = "There is no records....";
                }
                sdsClient.SelectCommand = "SELECT '---ALL CLIENTS---' AS CLIENT_ID, '---ALL CLIENTS---' AS CLIENT_NAME UNION SELECT DISTINCT CM.CLIENT_ID, CLIENT_NAME FROM CPV_CC_CASE_DETAILS CD, CPV_CC_CASE_VERIFICATIONTYPE CV, CLIENT_MASTER CM " +
                            "WHERE CD.CASE_ID = CV.CASE_ID AND CD.CLIENT_ID = CM.CLIENT_ID AND (CD.SEND_DATETIME IS NULL OR CD.SEND_DATETIME = '') AND (IS_CASE_COMPLETE IS NULL OR IS_CASE_COMPLETE = '') AND CD.CLIENT_ID in ('10111','10140') " + strCreteria + " And CD.CASE_ID NOT IN " +
                            "(select case_id from cpv_cc_tc_case_mapping where status in('A','R','M') and datediff(day,convert(varchar(10),date_time,25),'" + Convert.ToDateTime(objCommon.strDate(txtDate.Text.Trim())).ToString("yyyy-MM-dd") + "') < 5)";
                ddlClient.DataValueField = "client_id";
                ddlClient.DataTextField = "client_name";
                ddlClient.DataBind(); 
            }

            GVTCTOT_DataBound(sender, e);
            //lbltot.Text.ToString = obj; 
            //obj = lbltot.Text.ToString();   
            //OleDbDataAdapter oledb = new OleDbDataAdapter(strSql);
            //lbltot.Text = ole.Fill(ds);
            //dt = ds.Tables["search"];
            
        }
            
        catch (Exception exp)
        {
            lblMsg.Text = exp.Message + ' ' + "Error occured operation faild";
        }
    }

private struct gridposition
{
    public const int tc_id=0;
    public const int tcname=1;
    public const int check = 2;
}
protected void btnAssign1_Click1(object sender, EventArgs e)
    {
        //check selected telecaller///
        HiddenField hdnCaseID;
       // String selecttele;
        if (lbltot.Text == "0" || lbltot.Text == "")
        {
            Label2.Visible = true;
            lblMsg.Visible = true;
            lblMsg.Text = "No Cases Pending to be Assigned.";
        }
        else
        {
            CheckBox chkTcId;
            int strSelectedtele = 0;
            //int i = 0;
            Object container = new Object();
            foreach (GridViewRow row in GVTCTOT.Rows)
            {
                hdnCaseID = (HiddenField)row.FindControl("hidCaseId");
                chkTcId = (System.Web.UI.WebControls.CheckBox)row.FindControl("chkname");

                if (chkTcId.Checked)
                    strSelectedtele = strSelectedtele + 1;
                //return (i); 
            }
            if (strSelectedtele <=0)
            {
                lblMsg.Visible = true;
                lblMsg.Text = "No Tele Caller Selected. Please Select Tele Caller to assign Cases.";
            }
            else
            {
                String strCentreID = "";
                String strClientID = "";
                String strSql, strSql1, strSql2, sQuery, sQuery1 = "";
                CCommon objCommon = new CCommon();
                strCentreID = Session["CentreId"].ToString();
                strClientID = Session["ClientId"].ToString();
                String strSelADD = "";

                string qry = "";
                qry = "select [Datetime] = convert(varchar, getdate(), 25)";
                object aa = OleDbHelper.ExecuteScalar(objCommon.ConnectionString, CommandType.Text, qry);

                String strSelADDRes = "";
                String strseladdOff = "";
                {
                    strSelADDRes = "(ISNULL(CD.RES_ADD_LINE_1+' ','') + ISNULL(CD.RES_ADD_LINE_2+' ','') + ISNULL(CD.RES_ADD_LINE_3+' ','')) AS [ResidentAddress], CD.RES_CITY AS [ResCity] ";
                    strseladdOff = "(ISNULL(CD.OFF_ADD_LINE_1+' ','') + ISNULL(CD.OFF_ADD_LINE_2+' ','') + ISNULL(CD.OFF_ADD_LINE_3+' ','')) AS [OfficeAddress], CD.OFF_CITY AS [OffCity] ";

                }

                
                if (txtDate.Text != "" && txtToDate.Text != "")
                {
                    //strCreteria += " AND (CONVERT(VARCHAR, CD.CASE_REC_DATETIME,103)>='" + txtDate.Text + "'AND (CONVERT(VARCHAR, CD.CASE_REC_DATETIME,103)<='" + txtToDate.Text + "'AND CV.VERIFICATION_TYPE_ID IN('4','3'))";
                    strCreteria += " AND (CONVERT(VARCHAR, CD.CASE_REC_DATETIME,103)>='" + Convert.ToDateTime(objCommon.strDate(txtDate.Text.Trim())).ToString("dd/MM/yyyy") + "' AND (CONVERT(VARCHAR, CD.CASE_REC_DATETIME,103)<='" + Convert.ToDateTime(objCommon.strDate(txtToDate.Text.Trim())).ToString("dd/MM/yyyy") + "') AND CV.VERIFICATION_TYPE_ID in ('4','3'))";
                }
                //select proper count for griddata
                strSql = "SELECT Count(*) FROM CPV_CC_CASE_DETAILS CD, CPV_CC_CASE_VERIFICATIONTYPE CV WHERE CD.CASE_ID = CV.CASE_ID AND (CD.SEND_DATETIME IS NULL OR CD.SEND_DATETIME = '') AND " +
                         "(IS_CASE_COMPLETE IS NULL OR IS_CASE_COMPLETE = '')AND CD.CLIENT_ID in ('10111','10140') " + strCreteria + "";

                //strSql = "SELECT Count(*) FROM CPV_CC_CASE_DETAILS CD LEFT OUTER JOIN " +
                //                                "CPV_CC_CASE_VERIFICATIONTYPE CV LEFT OUTER JOIN " +
                //                                "TC_VW FV INNER JOIN CPV_CC_TC_CASE_MAPPING FE ON FV.EMP_ID = FE.TC_ID ON CV.CASE_ID = FE.CASE_ID AND " +
                //                                "CV.VERIFICATION_TYPE_ID = FE.VERIFICATION_TYPE_ID ON CD.CASE_ID = CV.CASE_ID " +
                //                                "WHERE(CD.SEND_DATETIME IS NULL AND FE.STATUS='') AND CD.CLIENT_ID='" + strClientID + "' AND CD.CENTRE_ID='" + strCentreID + "'" + strCreteria;
                object obj = OleDbHelper.ExecuteScalar(objCommon.ConnectionString, CommandType.Text, strSql);

                //divided grid data(count) to selected telecaller count 
                strSql1 = "select " + obj + "/" + strSelectedtele + "";
                object obj1 = OleDbHelper.ExecuteScalar(objCommon.ConnectionString, CommandType.Text, strSql1);

                //insert grid data to another dummy data
                strSql2 = "INSERT INTO TCDUMP SELECT CD.CASE_ID AS [CaseID], CD.REF_NO AS [RefrenceNo], ISNULL(CD.TITLE + ' ', '') + ISNULL(CD.FIRST_NAME + ' ', '') +ISNULL(CD.MIDDLE_NAME + ' ', '') + ISNULL(CD.LAST_NAME + ' ', '') AS [ApplicantName], " +
                            "" + strSelADDRes + ", " + strseladdOff + ", CONVERT(VARCHAR, CD.CASE_REC_DATETIME, 103) AS [RecievedDate], cv.VERIFICATION_TYPE_ID as VerificationType FROM CPV_CC_CASE_DETAILS CD, CPV_CC_CASE_VERIFICATIONTYPE CV " +
                            "WHERE CD.CASE_ID = CV.CASE_ID AND (CD.SEND_DATETIME IS NULL OR CD.SEND_DATETIME = '') AND (IS_CASE_COMPLETE IS NULL OR IS_CASE_COMPLETE = '')AND CD.CLIENT_ID in ('10111','10140') " + strCreteria + " order by cd.case_id ";
                //strSql2 = "INSERT INTO TcDump SELECT CD.CASE_ID, CD.REF_NO AS [Refrence_No], ISNULL(CD.TITLE + ' ', '') + ISNULL(CD.FIRST_NAME + ' ', '') +ISNULL(CD.MIDDLE_NAME + ' ', '') + ISNULL(CD.LAST_NAME + ' ', '') AS [Applicant_Name], " + strSelADDRes + "," + strseladdOff +
                //                        "CD.CASE_REC_DATETIME, FV.FULLNAME AS [Assigned_To] " +
                //                        "FROM CPV_CC_CASE_DETAILS CD LEFT OUTER JOIN " +
                //                        "CPV_CC_CASE_VERIFICATIONTYPE CV LEFT OUTER JOIN " +
                //                        "TC_VW FV INNER JOIN CPV_CC_TC_CASE_MAPPING FE ON FV.EMP_ID = FE.TC_ID ON CV.CASE_ID = FE.CASE_ID AND " +
                //                        "CV.VERIFICATION_TYPE_ID = FE.VERIFICATION_TYPE_ID ON CD.CASE_ID = CV.CASE_ID " +
                //                        "WHERE(CD.SEND_DATETIME IS NULL) AND CD.CLIENT_ID='" + strClientID + "' AND CD.CENTRE_ID='" + strCentreID + "'" + strCreteria;
                object obj2 = OleDbHelper.ExecuteNonQuery(objCommon.ConnectionString, CommandType.Text, strSql2);

                //select top recored in TcDump table to insert another table ABC
                //strSql = "Insert into Abc Select top " + obj1 + " * From TcDump";
                //object obj3 = OleDbHelper.ExecuteNonQuery(objCommon.ConnectionString, CommandType.Text, strSql); 


                foreach (GridViewRow row in GVTCTOT.Rows)
                {
                    string tcid = row.Cells[gridposition.tc_id].Text;

                    chkTcId = (CheckBox)row.FindControl("chkname");
                    if (chkTcId.Checked)
                    {
                        string tc1 = tcid;
                        //strSelectedtele = strSelectedtele + 1;
                        sQuery = "EXEC TC_AUTO_ASSIGNMENT '" + aa + "'," + obj1 + ",'" + tc1 + "'";
                        OleDbHelper.ExecuteNonQuery(objCommon.ConnectionString, CommandType.Text, sQuery);
                        //sQuery1 = "DELETE from TcDump where caseId in(select Top " + obj1 + "(a.CaseId) from TcDump a, cpv_cc_tc_case_mapping b where a.caseid = b.case_id and a.verificationtype = b.verification_type_id and status = 'A' and date_time = '" + aa + "')";
                        //OleDbHelper.ExecuteNonQuery(objCommon.ConnectionString, CommandType.Text, sQuery1);
                    }
                }

                string str = "";
                //DateTime frdate;
                //DateTime todate;
                //frdate = aa;
                //todate = aa;
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();

                qry = "exec TcWiseReport'" + aa + "','" + aa + "'";
                OleDbDataAdapter ole = new OleDbDataAdapter(qry, objCommon.ConnectionString);

                ole.Fill(ds, "TcWiseReport");
                dt = ds.Tables["TcWiseReport"];
                GVTCCou.DataSource = dt;
                GVTCCou.DataBind();

                if (GVTCCou.Rows.Count <= 0)
                {
                    lblMsg.Text = "No record found";
                }

                int dd;
                sQuery1 = "select count(*) from TcDump";
                object obj3 = OleDbHelper.ExecuteScalar(objCommon.ConnectionString, CommandType.Text, sQuery1);
                dd = Convert.ToInt32(obj3.ToString());
                if (dd > 0)
                {
                    lblMsg.Text = "'" + dd + "' No. of Cases Pending";
                    lblMsg.Visible = true;
                }
                else 

                lblMsg.Text = "Telecaller Assigned Successfully";
                Label2.Visible = true;
                lbltot.Text = "0";
                //foreach (string sCaseID in arrCaseID)
                //{
                //    String sQuery = "INSERT INTO CPV_CC_TC_CASE_MAPPING (CASE_ID, TC_ID, VERIFICATION_TYPE_ID, DATE_TIME) VALUES(" + sCaseID + ", '" + AssignedTo + "', '" + VerificationType + "', '" + strDate + "')";
                //    OleDbHelper.ExecuteNonQuery(objCommon.ConnectionString, CommandType.Text, sQuery);
                //}
            }
        }
    }
    protected void GVTCTOT_DataBound(object sender, EventArgs e)
    {
        if (GVTCTOT.Rows.Count <= 0)
        {
            //lblMsg.Text = "No record found";
        }
        else
        {
            //tblCaseCount.Visible = true;
            System.Web.UI.WebControls.CheckBox cbHeader = ((System.Web.UI.WebControls.CheckBox)(GVTCTOT.HeaderRow.FindControl("HeaderLevelCheckBox")));
            cbHeader.Attributes["onclick"] = "ChangeAllCheckBoxStates(this.checked);";
            foreach (GridViewRow gvr in GVTCTOT.Rows)
            {
                // Get a programmatic reference to the CheckBox control
                System.Web.UI.WebControls.CheckBox cb = ((System.Web.UI.WebControls.CheckBox)(gvr.FindControl("chkname")));
                ClientScript.RegisterArrayDeclaration("CheckBoxIDs", string.Concat("\'", cb.ClientID, "\'"));
            }
        }
    }
   
   
        
protected void  ddlClient_SelectedIndexChanged(object sender, EventArgs e)
{
    string strSql1 = "";
    string S;
    strCreteria += " AND CONVERT(VARCHAR(10), CD.CASE_REC_DATETIME,103)>='" + Convert.ToDateTime(objCommon.strDate(txtDate.Text.Trim())).ToString("dd/MM/yyyy") + "' AND CONVERT(VARCHAR(10), CD.CASE_REC_DATETIME,103) <= '" + Convert.ToDateTime(objCommon.strDate(txtToDate.Text.Trim())).ToString("dd/MM/yyyy") + "' AND CV.VERIFICATION_TYPE_ID in ('4','3')";
    strSql1 = "SELECT Count(*) FROM CPV_CC_CASE_DETAILS CD, CPV_CC_CASE_VERIFICATIONTYPE CV " +
                        "WHERE CD.CASE_ID = CV.CASE_ID AND (CD.SEND_DATETIME IS NULL OR CD.SEND_DATETIME = '') AND CLIENT_ID = '" + ddlClient.SelectedValue + "'AND (IS_CASE_COMPLETE IS NULL OR IS_CASE_COMPLETE = '') AND CD.CLIENT_ID in ('10111','10140') " + strCreteria + " And CD.CASE_ID NOT IN " +
                        "(select case_id from cpv_cc_tc_case_mapping where status in('A','R','M') and datediff(day,convert(varchar(10),date_time,25),'" + Convert.ToDateTime(objCommon.strDate(txtDate.Text.Trim())).ToString("yyyy-MM-dd") + "') < 5)";
    object obj = OleDbHelper.ExecuteScalar(objCommon.ConnectionString, CommandType.Text, strSql1);
    S = obj.ToString();
    lbltot.Text = S;
    if (lbltot.Text == "" || lbltot.Text == "0")
    {
        lblMsg.Visible = true;
        lblMsg.Text = "There is no Record....";

    }
}        
    
}


