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
using System.Text;
using System.IO;
using Microsoft.Office.Core;
using System.Configuration.Assemblies;
using CrystalDecisions.Shared;

public partial class CPV_CC_TcAssignedCasesQueue : System.Web.UI.Page
{
    //DateTime Date1;
    sup_remarks sremark = new sup_remarks();
    CCommon objcon = new CCommon();
    CLogin userid = new CLogin();
    Object a = new Object();
    DateTime dtfrom;
    DateTime dtto;
    string Fdate;
    string Tdate;
    string scaseid;
    string username = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {                        
            if (Context.Request.QueryString["FromDate"] != null && Context.Request.QueryString["FromDate"] != " " || Context.Request.QueryString["ToDate"] != null && Context.Request.QueryString["ToDate"] !="")
            {
                //scaseid = Request.QueryString["CaseID"].ToString();
                Fdate = Request.QueryString["FromDate"].ToString();
                Tdate = Request.QueryString["ToDate"].ToString();
                txtDate.Text = Fdate;
                txttodate.Text = Tdate;
            }
        }
        
        username= Session["userid"].ToString();
        if (txtDate.Text.Trim() != "" && txttodate.Text.Trim() != "")
        {
            getsearch();
        }
    }
    protected DataTable getcases()
    {
        string qry = "";
        DataTable dtsearch = new DataTable();
       
        dtfrom= Convert.ToDateTime(objcon.strDate(txtDate.Text.Trim()));
        dtto= Convert.ToDateTime(objcon.strDate(txttodate.Text.Trim()));
        
        //////////qry = "select distinct a.case_id,c.client_name,b.centre_name,d.ref_no,(isnull(d.first_name,'')+' '+isnull(d.middle_name,'')+' '+isnull(d.last_name,'')) as applicant_name,g.status_code,verification_type_code" +
        //////////    " from cpv_cc_tc_case_mapping a(nolock),centre_master b,client_master c,cpv_cc_case_details d(nolock),verification_type_master e,cpv_cc_veri_details f(nolock),case_status_master g" +
        //////////    " where a.case_id=d.case_id and a.case_id=f.case_id and a.verification_type_id=e.verification_type_id and a.verification_type_id=f.verification_type_id and b.centre_id=d.centre_id and c.client_id=d.client_id and " +
        //////////    " b.centre_id='" + Session["CentreID"] + "' and a.tc_id='" + username + "' and c.client_id='" + Session["ClientID"] + "' and f.case_status_id = '38' and g.case_status_id=f.case_status_id and a.status in('A','R','M') and a.date_time >='" + dtfrom + "' and a.date_time <'" + dtto + "' " +
        //////////    " Union " +
        //////////    " select distinct a.case_id,c.client_name,b.centre_name,d.ref_no,(isnull(d.first_name,'')+' '+isnull(d.middle_name,'')+' '+isnull(d.last_name,'')) as applicant_name,'' as status_code,verification_type_code" +
        //////////    " from cpv_cc_tc_case_mapping a(nolock),centre_master b,client_master c,cpv_cc_case_details d(nolock),verification_type_master e " +
        //////////    " where a.case_id=d.case_id and a.verification_type_id=e.verification_type_id and b.centre_id=d.centre_id and c.client_id=d.client_id " +
        //////////    " and a.tc_id='" + username + "' and c.client_id='" + Session["ClientID"] + "' and a.status in('A','R','M') and b.centre_id='" + Session["CentreID"] + "' and date_time >='" + dtfrom + "' and a.date_time <'" + dtto + "'" +
        //////////    " AND A.CASE_ID + VERIFICATION_TYPE_CODE NOT IN (SELECT DISTINCT F.CASE_ID + VERIFICATION_TYPE_CODE FROM CPV_CC_VERI_DETAILS F(NOLOCK), VERIFICATION_TYPE_MASTER G(NOLOCK) WHERE F.CASE_ID = D.CASE_ID AND F.VERIFICATION_TYPE_ID = G.VERIFICATION_TYPE_ID AND (SEND_DATETIME IS NULL OR SEND_DATETIME = '') AND DATEDIFF(DD,D.CASE_REC_DATETIME,'" + dtfrom +"') < 5 )";
        qry = "EXEC TC_ASSIGN_QUEUE '" + dtfrom + "', '" + dtto + "', '" + Session["ClientID"] + "', '" + Session["CentreID"] + "', '" + username + "'";    
        OleDbDataAdapter oleda = new OleDbDataAdapter(qry, objcon.ConnectionString);
        DataSet da = new DataSet();
        oleda.Fill(da, "Search");
        dtsearch = da.Tables["Search"];
        return dtsearch;
    }
    protected void getsearch()
    {
        DataTable dt = new DataTable();
        dt = getcases();
        if (dt.Rows.Count > 0)
        {
            gvtc.DataSource = dt;
            gvtc.DataBind();
            gvtc.Visible = true;
        }
        else
        {
            gvtc.Visible = false;
            lblMessage.Text = "Records Not Found!!!!!";
            lblMessage.Visible = true;

        }
    }
    private void property_set()
    {
        //sremark.caseid = gvtc.FindControl("caseid");
    sremark.Fromdate = txtDate.Text.Trim().ToString();
        sremark.Todate = txttodate.Text.Trim().ToString();
                sremark.centreid = Session["centreid"].ToString();
        sremark.clientid = Session["clientid"].ToString();
    }
    private struct gridposition
    {
        public const int caseid = 0;
        public const int refno = 1;
        public const int clientname = 2;
        public const int centrename = 3;
        public const int appli = 4;
        public const int casesta = 5;
        public const int verification = 6;
        public const int ver = 7;

    }
    protected void gvtc_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        foreach (GridViewRow row in gvtc.Rows)
        {
            string veriCode = row.Cells[gridposition.verification].Text;
            //string veric = row.Cells[gridposition.ver].Text;
            string strCaseID = row.Cells[gridposition.caseid].Text;
            string frodate = txtDate.Text;
            string toda = txttodate.Text;
           
            for (Int32 rowTypeCount = 0; rowTypeCount < gvtc.Rows.Count; rowTypeCount++)
            {
                GridViewRow gvRow = gvtc.Rows[rowTypeCount];

                string[] arrVerificationTypeCode = veriCode.Split('+');
                for (int i = 0; i < arrVerificationTypeCode.Length; i++)
                {
                    if (arrVerificationTypeCode[i].Length > 0)
                    {

                        MatchVerificationType(arrVerificationTypeCode[i].ToString(), row,veriCode, strCaseID,frodate,toda);

                        
                    }

                }
            }

        }
       
   
    }
    private void MatchVerificationType(string code, GridViewRow gvrow, string verificationTypeCode, string caseID,string fromdate1,string todate1)
    {
       
        Label lblRT = (Label)gvrow.Cells[gridposition.ver].FindControl("lblRT");
        Label lblBT = (Label)gvrow.Cells[gridposition.ver].FindControl("lblBT");
        
        string verificationType = code;
        string path = Server.MapPath("../../CPV/CC/");
        switch (code)
        {
            case "RT":
                //string str2 = path + "CC_ResidenceVerificationTelephonic.aspx?CaseID=" + caseID + "&VerTypeId=4&VerificationTypeCode=" + verificationTypeCode + "&Mode=View";
                lblRT.Text = "<A href=CC_ResidenceVerificationTelephonic.aspx?CaseID=" + caseID + "&VerTypeId=4&VerificationTypeCode=" + verificationTypeCode + "&FromDate="+ fromdate1 +"&ToDate=" + todate1 + "&Mode=Update>RT</A>";
                lblRT.Visible = true;
                //lblSlashRT.Visible = true;
                break;
            case "BT":
                //string str3 =path +  "CC_BusinessVerificationTelephonic.aspx?CaseID=" + caseID + "&VerTypeId=3&VerificationTypeCode=" + verificationTypeCode + "&Mode=View";
                lblBT.Text = "<A href=CC_BusinessVerificationTelephonic.aspx?CaseID=" + caseID + "&VerTypeId=3&VerificationTypeCode=" + verificationTypeCode + "&FromDate="+ fromdate1 +"&ToDate=" + todate1 +"&Mode=Update>BT</>";
                lblBT.Visible = true;
                //lblSlashBT.Visible = true;
                break;       
        }

    }

    protected void btnsearch_Click(object sender, EventArgs e)
    {
        bool isvalid = true;
        if (txtDate.Text == "")
        {
            isvalid = false;
            lblMessage.Visible = true;
            lblMessage.Text = "Please Enter The Valid Date.";
            lblMessage.ForeColor = System.Drawing.Color.Red;
            lblMessage.Font.Bold = true;
        }
        if (txtDate.Text != "")
        {
            dtfrom = Convert.ToDateTime(objcon.strDate(txtDate.Text.Trim()));
        }
        if (isvalid == true)
        {
            lblMessage.Text = "";
            getsearch();
        }
    }
   

    private void ExportGridView()
    {
       
    }
    protected void btnExport_Click(object sender, EventArgs e)
    {
                       Response.ClearContent();
                       gvtc.BackColor = System.Drawing.Color.White;
                       gvtc.GridLines = GridLines.Both;
                       gvtc.AutoGenerateDeleteButton = false;
                       gvtc.AutoGenerateEditButton = false;
                       gvtc.AllowSorting = false;
                       gvtc.AllowPaging = false;
                       //gvExport.DataBind();

                       string attachment = "attachment; filename=TcAssignedCasesQueue.xls";

                       Table tblSpace = new Table();
                       TableRow tblRow = new TableRow();
                       TableCell tblCell = new TableCell();
                       tblCell.Text = " ";

                       TableRow tblRow1 = new TableRow();
                       TableCell tblCell1 = new TableCell();
                       tblCell1.Text = "<br/><b><font size='4'>PAMAC Finserve Private Limited</font></b> <br/>" +
                                        "<b><font size='2'>From Date :</font></b> " + txtDate.Text.Trim() + "<br/>"+
                                       "<b><font size='2'>To Date :</font></b> " + txttodate.Text.Trim() + "<br/>";

                       tblCell1.CssClass = "label";

                       tblRow.Cells.Add(tblCell);
                       tblRow1.Cells.Add(tblCell1);

                       tblRow.Height = 20;

                       tblSpace.Rows.Add(tblRow);
                       tblSpace.Rows.Add(tblRow1);
        
                       Response.AddHeader("content-disposition", attachment);

                       Response.ContentType = "application/ms-excel";

                       StringWriter sw = new System.IO.StringWriter();

                        HtmlTextWriter htw = new HtmlTextWriter(sw);
                        gvtc.EnableViewState = false;
                        tblRow1.RenderControl(htw);
                        gvtc.RenderControl(htw);

                        Table tblBottom = new Table();
                        TableRow tblRowBottom = new TableRow();
                        TableCell tblCellBottom = new TableCell();


                        //tblCellBottom.Text = "<br/><b><font size='2'>For&nbsp;</font><font size='4'> PAMAC Finserve Private Limited</font></b><br/><br/><br/>" +
                                          ////"<b><font size='2'>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Authorised Signatory</font></b><br/><br/><br/>" +
                                           //  "<b><font size='3'>Received By</font></b>";


                        tblRowBottom.Cells.Add(tblCellBottom);
                        tblRowBottom.Height = 20;

                        tblBottom.Rows.Add(tblRowBottom);

                        tblRowBottom.RenderControl(htw);

                        Response.Write(sw.ToString());

                        Response.End();
                 

    }
    public override void VerifyRenderingInServerForm(Control control)
    {

    }

    
}
