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

public partial class CPV_CC_Sup_remarks : System.Web.UI.Page
{
    sup_remarks supremark = new sup_remarks();
    sup_remarks objcasestatus = new sup_remarks();
   
    CCommon objconn = new CCommon();
    string sCaseId;

    string Todate;
    string Fromdate;

    protected void page_load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            
            if (Context.Request.QueryString["CaseID"] != null && Context.Request.QueryString["CaseID"] != "" && Context.Request.QueryString["FromDate"] != null && Context.Request.QueryString["FromDate"] !="" && Context.Request.QueryString["ToDate"]!=null && Context.Request.QueryString["ToDate"]!="")
            {
                sCaseId = Request.QueryString["CaseID"].ToString();
                Fromdate = Request.QueryString["FromDate"].ToString();
                Todate = Request.QueryString["ToDate"].ToString();
                 Txtcase.Text = sCaseId;
                 txtfdate.Text = Fromdate;
                 txttdate.Text = Todate;
                OleDbDataReader oledbDR;
                string qry = "select send_datetime from cpv_cc_case_details where case_id='" + sCaseId + "'";

                oledbDR = OleDbHelper.ExecuteReader(objconn.ConnectionString, CommandType.Text, qry);
                //OleDbParameter[] oledbparam = new OleDbParameter[3];
                if (oledbDR.Read())
                {
                    if (!(oledbDR["send_datetime"].ToString().Trim().Length.Equals(0)))
                    {
                        lblMessage.Text = "This Case Is already Marked as Sent To Client..... ";
                    }
                    else
                    {
                        lblMessage.Text = "";
                        //gvsupervisor.EditIndex = -1;
                        getsearchcases();
                        property_set();
                        fillstatus();
                        btnapply.Visible = true;
                        OverallCommennt.Visible = true;
                        Overallstatus.Visible = true;
                        txtoverall.Visible = true;
                        ddlstatus.Visible = true;
                    }
                }
            }
           
        }

        //////txtoverall.Visible = false;
        //////DDLstatus.Visible = false;
        //////Overallstatus.Visible = false;
        //////OverallCommennt.Visible = false;
        //////btnapply.Visible = false;
    }
    protected void getsearchcases()
    {

        DataTable dt = new DataTable();
        dt = getsearch();
     
        if (dt.Rows.Count > 0)
        {
            gvsupervisor.DataSource = dt;
            gvsupervisor.DataBind();
            gvsupervisor.Visible = true;
            dt = fillstatus();
            if (dt.Rows.Count > 0)
            {
                ddlstatus.DataSource = dt;
                ddlstatus.DataTextField = "status_code";
                ddlstatus.DataValueField = "case_status_id";
                ddlstatus.DataBind();
                Overallstatus.Visible = true;
                ddlstatus.Visible = true;
                btnapply.Visible = true;
                OverallCommennt.Visible = true;
                txtoverall.Visible = true;
            }
            else
            {
                ddlstatus.Visible = false;
            }
        }
        else
        {
            gvsupervisor.Visible = false;
            lblMessage.Text = "Record Not Found....";
           
        }
        
      
    }
    private void property_set()
    {
        supremark.caseid = Txtcase.Text.Trim().ToString();
        //supremark.refno = Txtref.Text.Trim().ToString();
        //supremark.applicantname = TxtappName.Text.Trim().ToString();
        supremark.centreid = Session["centreid"].ToString();
        supremark.clientid = Session["clientid"].ToString();

    }
    protected DataTable fillstatus()
    {
        string qry = "";
        DataTable dtsearch = new DataTable();
        qry = "select case_status_id,status_code from case_status_master where product_id='" + Session["ProductID"] + "' and case_status_id not in('37','38') order by status_code ";
        OleDbDataAdapter oledbDA = new OleDbDataAdapter(qry,objconn.ConnectionString);
        DataSet da = new DataSet();
        oledbDA.Fill(da, "case_status_master");
        dtsearch = da.Tables["case_status_master"];
        return dtsearch;

    }

   

    protected DataTable getsearch()
    {
        //////////string qry = "";
        //////////OleDbDataReader oledbDR;
        //////////if (Txtcase.Text != "")
        //////////{
        //////////    qry = "select ref_no from cpv_cc_case_details where case_id = '" + Txtcase.Text + "'";
        //////////    oledbDR = OleDbHelper.ExecuteReader(objconn.ConnectionString, CommandType.Text, qry);
        //////////    //OleDbParameter[] oledbparam = new OleDbParameter[3];
        //////////    if (oledbDR.Read())
        //////////    {
        //////////        Txtref.Text = oledbDR["ref_no"].ToString();
        //////////    }
        //////////}
        //////////else
        //////////{
        //////////    qry = "select case_id from cpv_cc_case_details where ref_no = '" + Txtref.Text + "'";
        //////////    oledbDR = OleDbHelper.ExecuteReader(objconn.ConnectionString, CommandType.Text, qry);
        //////////    //OleDbParameter[] oledbparam = new OleDbParameter[3];
        //////////    if (oledbDR.Read())
        //////////    {
        //////////        Txtcase.Text = oledbDR["case_id"].ToString();
        //////////    }
        //////////}

        string qry1 = "";
        string qry2 = "";
        string qry3 = "";
        string qry4 = "";
        string qry5 = "";

        DataTable dtSearch = new DataTable();
        ////////change by santosh shelar 13-09-08//////////////////////////// 

        qry1 = "select distinct 'RV' as veri_code,(isnull(res_add_line_1,'')+' '+isnull(res_add_line_2,'')+' '+isnull(res_add_line_3,'')) as residence_address,c.time_at_curr_residance,a.residance_is,b.res_phone,b.dob,'' as company_name,'' as Designation,''as Office_address,''as Office_phone,''as Working_since,e.status_name,d.SUPERVISOR_REMARKS"+
               " from cpv_cc_veri_description1 a(nolock),cpv_cc_case_details b(nolock),cpv_cc_veri_description c(nolock),cpv_cc_veri_details d(nolock),case_status_master e(nolock)" +
                " where a.case_id=b.case_id and a.case_id=c.case_id and a.case_id=d.case_id and d.case_status_id=e.case_status_id and a.verification_type_id=c.verification_type_id and a.verification_type_id=d.verification_type_id and a.VERIFICATION_TYPE_ID='1'and b.Centre_id='" + Session["centreid"] + "' and b.client_id='" + Session["clientid"] + "'";

        //qry2 = "select distinct 'BV' as veri_code,''as company_name,''as Designation,''as Office_address,'' as Working_Since,''as Office_phone,a.company_name,a.designation,(isnull(off_add_line_1,'')+' '+isnull(off_add_line_2,'')+' '+isnull(off_add_line_3,'')),b.off_phone,'',e.status_name,d.SUPERVISOR_REMARKS" +
        //        " from cpv_cc_veri_description1 a(nolock),cpv_cc_case_details b(nolock),cpv_cc_veri_description c(nolock),cpv_cc_veri_details d(nolock),case_status_master e(nolock)" +
        //         " where a.case_id=b.case_id and a.case_id=c.case_id and a.case_id=d.case_id and d.case_status_id=e.case_status_id and a.verification_type_id=c.verification_type_id and a.verification_type_id=d.verification_type_id and a.VERIFICATION_TYPE_ID='2'and b.centre_id='" + Session["centreid"] + "'and b.client_id='" + Session["clientid"] + "'";

        qry2 = "select distinct 'BV' as veri_code,''as company_name,''as Designation,''as Office_address,'' as Working_Since,''as Office_phone,a.company_name,a.designation,(isnull(off_add_line_1,'')+' '+isnull(off_add_line_2,'')+' '+isnull(off_add_line_3,'')),b.off_phone,a.years_worked,e.status_name,d.SUPERVISOR_REMARKS" +
                " from cpv_cc_veri_description1 a(nolock),cpv_cc_case_details b(nolock),cpv_cc_veri_description c(nolock),cpv_cc_veri_details d(nolock),case_status_master e(nolock)" +
                 " where a.case_id=b.case_id and a.case_id=c.case_id and a.case_id=d.case_id and d.case_status_id=e.case_status_id and a.verification_type_id=c.verification_type_id and a.verification_type_id=d.verification_type_id and a.VERIFICATION_TYPE_ID='2'and b.centre_id='" + Session["centreid"] + "'and b.client_id='" + Session["clientid"] + "'";
        
        //qry3 = "select distinct 'RT' as veri_code,(isnull(res_add_line_1,'')+' '+isnull(res_add_line_2,'')+' '+isnull(res_add_line_3,'')) as residence_address,c.time_at_curr_residance,a.residance_is,b.res_phone,'' as company_name,''as Designation,''as Office_address,'' as office_phone,'',''as Working_since,e.status_name,d.SUPERVISOR_REMARKS" +
        //     " from cpv_cc_veri_description1 a(nolock),cpv_cc_case_details b(nolock),cpv_cc_veri_description c(nolock),cpv_cc_veri_details d(nolock),case_status_master e(nolock)" +
        //     " where a.case_id=b.case_id and a.case_id=c.case_id and a.case_id=d.case_id and d.case_status_id=e.case_status_id and a.verification_type_id=c.verification_type_id and a.verification_type_id=d.verification_type_id and a.VERIFICATION_TYPE_ID='4'and b.centre_id='" + Session["centreid"] + "' and b.client_id='" + Session["clientid"] + "'";

        qry3 = "select distinct 'RT' as veri_code,(isnull(res_add_line_1,'')+' '+isnull(res_add_line_2,'')+' '+isnull(res_add_line_3,'')) as residence_address,c.time_at_curr_y_m,a.residance_is,b.res_phone,'' as company_name,''as Designation,''as Office_address,'' as office_phone,'',''as Working_since,e.status_name,d.SUPERVISOR_REMARKS" +
             " from cpv_cc_veri_description1 a(nolock),cpv_cc_case_details b(nolock),cpv_cc_veri_description c(nolock),cpv_cc_veri_details d(nolock),case_status_master e(nolock)" +
             " where a.case_id=b.case_id and a.case_id=c.case_id and a.case_id=d.case_id and d.case_status_id=e.case_status_id and a.verification_type_id=c.verification_type_id and a.verification_type_id=d.verification_type_id and a.VERIFICATION_TYPE_ID='4'and b.centre_id='" + Session["centreid"] + "' and b.client_id='" + Session["clientid"] + "'";

        //qry4 = "select distinct 'BT' as veri_code,'' as company_name,''as Designation,''as Office_address,'' As Working_since,'',a.company_name,a.designation,(isnull(off_add_line_1,'')+' '+isnull(off_add_line_2,'')+' '+isnull(off_add_line_3,'')),'',a.time_at_current_empl_y_m,e.status_name,d.SUPERVISOR_REMARKS" +
        //        " from cpv_cc_veri_description1 a(nolock),cpv_cc_case_details b(nolock),cpv_cc_veri_description c(nolock),cpv_cc_veri_details d(nolock),case_status_master e(nolock)" +
        //       " where a.case_id=b.case_id and a.case_id=c.case_id and a.case_id=d.case_id and d.case_status_id=e.case_status_id and a.verification_type_id=c.verification_type_id and a.verification_type_id=d.verification_type_id and a.VERIFICATION_TYPE_ID='3' and b.centre_id='" + Session["centreid"] + "' and b.client_id='" + Session["clientid"] + "'";

        qry4 = "select distinct 'BT' as veri_code,'' as company_name,''as Designation,''as Office_address,'' As Working_since,'',a.company_name,a.designation,(isnull(off_add_line_1,'')+' '+isnull(off_add_line_2,'')+' '+isnull(off_add_line_3,'')),b.off_phone,a.time_at_current_empl_y_m,e.status_name,d.SUPERVISOR_REMARKS" +
                " from cpv_cc_veri_description1 a(nolock),cpv_cc_case_details b(nolock),cpv_cc_veri_description c(nolock),cpv_cc_veri_details d(nolock),case_status_master e(nolock)" +
               " where a.case_id=b.case_id and a.case_id=c.case_id and a.case_id=d.case_id and d.case_status_id=e.case_status_id and a.verification_type_id=c.verification_type_id and a.verification_type_id=d.verification_type_id and a.VERIFICATION_TYPE_ID='3' and b.centre_id='" + Session["centreid"] + "' and b.client_id='" + Session["clientid"] + "'";

        //////////if (Txtref.Text != "")
        //////////{
        //////////    qry1 += "and Ref_No like '%" + Txtref.Text + " %'";
        //////////    qry2 += "and ref_no like '%" + Txtref.Text + " %'";
        //////////    qry3 += "and ref_no like '%" + Txtref.Text + "%'";
        //////////    qry4 += "and ref_no like '%" + Txtref.Text + "%'";
        //////////}
        ////if (TxtappName.Text != "")
        ////{
        ////    qry1 += "and (isnull(first_name,'')+' '+isnull(middle_name,'')+' 'isnull(last_name))" +
        ////            "like '%" + TxtappName.Text + "%'";
        ////    qry2 += "and (isnull(first_name,'')+' '+isnull(middle_name,'')+' '+isnull(last_name,''))" +
        ////            "like '%" + TxtappName.Text + "%'";
        ////    qry3 += "and (isnull(first_name,'')+' '+isnull(middle_name,'')+' '+isnull(last_name,''))" +
        ////            "like '%" + TxtappName.Text + "%'";
        ////    qry4 += "and (isnull(first_name,'')+' '+isnull(middle_name,'')+' '+isnull(last_name,''))" +
        ////            "like '%" + TxtappName.Text + "%'";
        ////}
        if (Txtcase.Text != "")
        {
            qry1 += "and a.Case_id='" + Txtcase.Text + "'";
            qry2 += "and a.case_id='" + Txtcase.Text + "'";
            qry3 += "and a.case_id='" + Txtcase.Text + "'";
            qry4 += "and a.case_id='" + Txtcase.Text + "'";
            
        }
        
        qry5 = qry1 + " " + "Union" + " " + qry2 + " " + "Union" + " " + qry3 + " " + "Union" + " " + qry4;

        OleDbDataAdapter oledbDA = new OleDbDataAdapter(qry5, objconn.ConnectionString);
        DataSet da = new DataSet();
        oledbDA.Fill(da, "Search");
        dtSearch = da.Tables["Search"];
        return dtSearch;

    }  
   

    private struct GridPosition
    {
        public const int VerificationType = 1;
        //public const int verification_code= 1;
        public const int ResidanceAddress = 2;
        public const int Stayingsince = 3;
        public const int resi_status = 4;
        public const int resi_phone = 5;
        public const int dob = 6;
        public const int Company_Name = 7;
        public const int Designation = 8;
        public const int OfficeAddress = 9;
        public const int office_phone = 10;
        public const int WorkingSince = 11;
        public const int status = 12;
        public const int remarks = 13;
        //public const int overall_status = 14;
        //public const int comments = 15;
        //public const int edit = 16;
    }
    //protected void gvsupervisor_RowEditing(object sender, GridViewEditEventArgs e)
    //{
    //    gvsupervisor.EditIndex = e.NewEditIndex;
    //    getsearchcases();
    //    property_set();
    //    Initializefunction();

    //}
    protected void gvsupervisor_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        foreach (GridViewRow row in gvsupervisor.Rows)
        {
            string veriCode = row.Cells[GridPosition.VerificationType].Text;
            string strCaseID = Txtcase.Text;
            string datefrom = txtfdate.Text;
            string dateto = txttdate.Text;
            
            
            for (Int32 rowTypeCount = 0; rowTypeCount < gvsupervisor.Rows.Count; rowTypeCount++)
            {
                GridViewRow gvRow = gvsupervisor.Rows[rowTypeCount];

                string[] arrVerificationTypeCode = veriCode.Split('+');
                for (int i = 0; i < arrVerificationTypeCode.Length; i++)
                {
                    if (arrVerificationTypeCode[i].Length > 0)
                    {

                        MatchVerificationType(arrVerificationTypeCode[i].ToString(), row, veriCode, strCaseID);
                       
                        matchdate(datefrom, dateto);
                    }

                }
            }

        }
        //if (e.Row.RowType == DataControlRowType.DataRow)
        //{
        //    DropDownList ddlstatus = (DropDownList)e.Row.FindControl("ddlstatus");
        //    if (ddlstatus != null)
        //    {
        //        ddlstatus.DataSource = fillstatus();
        //        ddlstatus.DataBind();
        //        ddlstatus.SelectedValue = gvsupervisor.DataKeys[e.Row.RowIndex].Values[1].ToString();
        //    }
        //}


    }
    //protected void gvsupervisor_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    //{
    //    gvsupervisor.EditIndex = -1;
    //    getsearchcases();
    //    property_set();
    //}
    //protected void gvsupervisor_RowUpdatind(object sender, GridViewUpdateEventArgs e)
    //{
    //    GridViewRow row = gvsupervisor.Rows[e.RowIndex];
    //    if (row != null)
    //    {
    //        DropDownList ddlstatus = ((DropDownList)row.FindControl("ddlstatus"));
    //        TextBox txtoverall = ((TextBox)row.FindControl("txtoverall"));
    //        objcasestatus.OverallStatus = ddlstatus.SelectedValue.ToString();
    //        objcasestatus.OverallComments = ddlstatus.SelectedValue.ToString();
    //        strmsg = updateremarks();
    //        gvsupervisor.EditIndex = -1;
    //        property_set();
    //        getsearchcases();
    //    }
    //}

    private void MatchVerificationType(string code, GridViewRow gvRow, string verificationTypeCode, string caseID)
    {

        Label lblRV = (Label)gvRow.Cells[GridPosition.VerificationType].FindControl("lblRV");
        Label lblBV = (Label)gvRow.Cells[GridPosition.VerificationType].FindControl("lblBV");
        Label lblRT = (Label)gvRow.Cells[GridPosition.VerificationType].FindControl("lblRT");
        Label lblBT = (Label)gvRow.Cells[GridPosition.VerificationType].FindControl("lblBT");
        
        //Label lblSlashRV = (Label)gvRow.Cells[GridPosition.VerificationType].FindControl("lblSlashRV");
        //Label lblSlashBV = (Label)gvRow.Cells[GridPosition.VerificationType].FindControl("lblSlashBV");
        //Label lblSlashRT = (Label)gvRow.Cells[GridPosition.VerificationType].FindControl("lblSlashRT");
        //Label lblSlashBT = (Label)gvRow.Cells[GridPosition.VerificationType].FindControl("lblSlashBT");
        //Label lblSlashPRV = (Label)gvRow.Cells[GridPosition.SELECTVERIFICATIONTYPE].FindControl("lblSlashPRV");
        
        string verificationType = code;
        string path = Server.MapPath("../../CPV/CC/");
        switch (code)
        {
              
            case "RV":
                
                //string str = path + "CC_ResidenceVerification.aspx?CaseID=" + caseID + "&VerTypeId=1&VerificationTypeCode=" + verificationTypeCode + "&Mode=View";
                lblRV.Text = "<A href=CC_ResidenceVerification.aspx?CaseID=" + caseID + "&VerTypeId=1&VerificationTypeCode=" + verificationTypeCode + "&Mode=Update >RV</A>";
                lblRV.Visible = true;
                //lblSlashRV.Visible = true;
                break;
            case "BV":
                //string str1 = path + "CC_BusinessVerification.aspx?CaseID=" + caseID + "&VerTypeId=2&VerificationTypeCode=" + verificationTypeCode + "&Mode=View";
                lblBV.Text = "<A href= CC_BusinessVerification.aspx?CaseID=" + caseID + "&VerTypeId=1&VerificationTypeCode=" + verificationTypeCode + "&Mode=Update>BV</A>";
                lblBV.Visible = true;
                //lblSlashBV.Visible = true;

                break;

            case "RT":
                //string str2 = path + "CC_ResidenceVerificationTelephonic.aspx?CaseID=" + caseID + "&VerTypeId=4&VerificationTypeCode=" + verificationTypeCode + "&Mode=View";
                lblRT.Text = "<A href=CC_ResidenceVerificationTelephonic.aspx?CaseID=" + caseID + "&VerTypeId=4&VerificationTypeCode=" + verificationTypeCode + "&Mode=Update>RT</A>";
                lblRT.Visible = true;
                //lblSlashRT.Visible = true;
                break;
            case "BT":
                //string str3 =path +  "CC_BusinessVerificationTelephonic.aspx?CaseID=" + caseID + "&VerTypeId=3&VerificationTypeCode=" + verificationTypeCode + "&Mode=View";
                lblBT.Text = "<A href=CC_BusinessVerificationTelephonic.aspx?CaseID=" + caseID + "&VerTypeId=3&VerificationTypeCode=" + verificationTypeCode + "&Mode=Update>BT</>";
                lblBT.Visible = true;
                //lblSlashBT.Visible = true;
                break;

            //case "PRV":
            //    string str4 = "CC_ResidenceVerification.aspx?CaseID=" + caseID + "&VerTypeId=10&VerificationTypeCode=" + verificationTypeCode + "&Mode=View";
            //    lblPRV.Text = "<A href='#' onClick=winOpen('" + str4 + "')>PRV</A>";
            //    lblPRV.Visible = true;
            //    lblSlashPRV.Visible = true;
            //    break;

            //case "PRTV":
            //    lblPRTV.Visible = true;
            //    break;

        }
    }
     
    
    protected void gvsupervisor_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvsupervisor.PageIndex = e.NewPageIndex;
        property_set();
        getsearchcases();
    }
        
    public void updateremarks()
    {
        OleDbDataReader oledbDataReader;
        OleDbConnection con = new OleDbConnection(objconn.ConnectionString);
        con.Open();
        OleDbTransaction oletran = con.BeginTransaction();
        string qry = "";
        //string msg = "";
        string qry1 = "";
        try
        {
            if (txtoverall.Text != "")
            {
                qry = "select case_id from cpv_cc_case_details where case_id='" + Txtcase.Text + "'";
                oledbDataReader = OleDbHelper.ExecuteReader(objconn.ConnectionString, CommandType.Text, qry);
                //OleDbParameter[] oledbparam = new OleDbParameter[3];

                if (oledbDataReader.Read())
                {
                    qry1 = "update cpv_cc_case_details set overall_comments='" + txtoverall.Text + "',overall_status_id='" + ddlstatus.SelectedValue + "'" +
                            " where case_id='" + Txtcase.Text + "'";
                    //oledbparam[0]=new OleDbParameter
                                      
                }
               
                OleDbHelper.ExecuteNonQuery(objconn.ConnectionString, CommandType.Text, qry1);
                oletran.Commit();
                con.Close();
                //return strmsg;
              
            }
                  
            if(txtoverall.Text=="")
            {
               msg.Visible = false;
                msg.Text = "Overall Remarks Cannot Be Blank.";
                msg.Visible = true;
            }
        }
        catch (Exception ex)
        {
            throw new Exception("Error While Updating" + ex.Message);
        }


    }
    //public string UpdateItems()
    //{
    //    OleDbDataReader oledbDataReader;
    //    OleDbConnection conn = new OleDbConnection(objconn.ConnectionString);
    //    conn.Open();
    //    OleDbTransaction oledbTrans = conn.BeginTransaction();
    //    string strMSg = "";
    //    string strSql = "";
    //    string sSql = "";
    //    try
    //    {

    //        strSql = " Select CASE_ID from CPV_CC_CASE_DETAILS " +
    //                 " Where CASE_ID='" + Txtcase.Text + "'";
    //        oledbDataReader = OleDbHelper.ExecuteReader(objconn.ConnectionString,CommandType.Text, strSql);

    //        OleDbParameter[] oledbParam = new OleDbParameter[3];

    //        if (oledbDataReader.Read())
    //        {
    //            sSql = "Update CPV_CC_CASE_DETAILS set Overall_comments=?,Overall_Status_ID=? " +
    //                    " Where CASE_ID=?";


    //            oledbParam[0] = new OleDbParameter("OverallComments", OleDbType.VarChar, 200);
    //            oledbParam[0].Value = txtoverall.Text;

    //            oledbParam[1] = new OleDbParameter("OverallStatusID", OleDbType.VarChar, 15);
    //            oledbParam[1].Value = Overallstatus;

    //            oledbParam[2] = new OleDbParameter("CaseID", OleDbType.VarChar, 15);
    //            oledbParam[2].Value = Txtcase.Text;

    //            strMSg = "Records Updated Successfully..";


    //        }
    //        OleDbHelper.ExecuteNonQuery(oledbTrans, CommandType.Text, sSql, oledbParam);
    //        oledbTrans.Commit();
    //        conn.Close();
    //        return strMSg;
    //    }
    //    catch (Exception ex)
    //    {
    //        throw new Exception("Error while Updating " + ex.Message);
    //    }

    //}
    private void matchdate(string frodate,string todat)
    {
        //Button btnapply = (Button)btnapply.FindControl["btnapply"];
        
        string str="oveall_remarks.aspx?FromDate="+ frodate +"&ToDate="+ todat +"&Mode=View";
        msg.Text="<a href='" + str + "'>Show</A>";
        //msg.Visible = true;
        ////updateremarks();
        //string str ="<A href=oveall_remarks.aspx?FromDate=" + frodate + "&ToDate=" + todat + "&Mode=View"></A>";
        //lblStatus.Text = "<A href='" + str + "'>view status</A>";
    }

    ////protected void ddlstatus_SelectedIndexChanged(object sender, EventArgs e)
    ////{
    ////    getsearchcases();
    ////}

    //protected void btnapply_Click1(object sender, EventArgs e)
    //{
    //    
    //    //matchdate(Fromdate, Todate);
    //    //string str = "Sup_remarks.aspx?CaseID=" + caseID + "&Mode=View";
    //    //lblStatus.Text = "<A href='" + str + "'>view status</A>";
    //   // lblStatus.Visible = true;
    //}
    //private void Initializefunction()
    //{
    //    for (int i = 0; i < gvsupervisor.Rows.Count; i++)
    //    {
    //        TextBox txtoverall;
    //        txtoverall = (TextBox)gvsupervisor.Rows[i].FindControl("txtoverall");
    //        if (txtoverall != null)
    //        {
    //            txtoverall.Attributes.Add("onkeypress", "return PreventCharacterToAdd('" + txtoverall.ClientID + "');");
    //            txtoverall.Attributes.Add("onkeyup", "return PreventCharacterToAdd('" + txtoverall.ClientID + "');");
    //        }

    //    }

    //}

    protected void btnapply_Click(object sender, EventArgs e)
    {
        btnapply.Visible = true;
        //updateremarks();
        btnapply.Visible = false;
        msg.Visible = true;
        //ddlstatus.SelectedIndex = 0;
       
    }
    protected void ddlstatus_SelectedIndexChanged(object sender, EventArgs e)
    {
        updateremarks();
        getsearchcases();
    }
}

