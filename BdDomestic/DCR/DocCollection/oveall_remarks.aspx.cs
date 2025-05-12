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
using System.IO;

public partial class CPV_CC_oveall_remarks : System.Web.UI.Page
{
    sup_remarks objcasestatus = new sup_remarks();
    
    DateTime dtFrom;
    DateTime dtTo;

    string Tdate;
    string Fdate;
    CCommon objconn = new CCommon();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            
            if (Context.Request.QueryString["FromDate"] != null && Context.Request.QueryString["FromDate"] != " " || Context.Request.QueryString["ToDate"] != null && Context.Request.QueryString["ToDate"] !="")
            {
                        Fdate = Request.QueryString["FromDate"].ToString();
                        Tdate=Request.QueryString["ToDate"].ToString();
                        txtFromDate.Text=Fdate;
                        txtToDate.Text=Tdate;
                          // Txtcase.Text = sCaseId;
                        bool isValidDates = true;
                        if (txtFromDate.Text.Trim() == "" || txtToDate.Text.Trim() == "")
                        {
                            isValidDates = false;
                            lblMessage.Visible = true;
                            lblMessage.Text = "Please enter From and To Date.";
                            lblMessage.ForeColor = System.Drawing.Color.Red;
                            lblMessage.Font.Bold = true;
                        }

                        if (txtFromDate.Text.Trim() != "" && txtToDate.Text.Trim() != "")
                        {

                            //string dtTodate;
                            //string Fromdate;
                            dtFrom = Convert.ToDateTime(objconn.strDate(txtFromDate.Text.Trim()));
                            dtTo = Convert.ToDateTime(objconn.strDate(txtToDate.Text.Trim())).AddDays(1.0);
                            //dtTo = "select dateadd(day,1,dtto)";
                            //dtTodate = dtTo;
                            //Fromdate = dtFrom;

                            if (dtFrom > dtTo)
                            {
                                isValidDates = false;
                                lblMessage.Visible = true;
                                lblMessage.Text = "From date must be less than to date.";
                            }
                        }
                        if (isValidDates == true)
                        {
                            //CExportDataDump objExportDump=new CExportDataDump();
                            //DataSet dsExportDump = new DataSet();
                            //Fdate = Convert.ToDateTime(objconn.strDate(txtFromDate.Text.Trim())).ToString("dd-MMM-yyyy");
                            //Tdate = Convert.ToDateTime(objconn.strDate(txtToDate.Text.Trim())).AddDays(1.0).ToString("dd-MMM-yyyy");

                            lblMessage.Text = "";
                            propertyset();
                            getsearchcases();
                           
                        }
                }
            }

        }
        


  
    protected void getsearchcases()
    {
        DataTable dt = new DataTable();
        dt = getsearch();
        if (dt.Rows.Count > 0)
        {
           GvOverall.DataSource = dt;
            GvOverall.DataBind();
            GvOverall.Visible = true;
        }
        else
        {
            GvOverall.Visible = false;
            lblMessage.Text = "Record Not Found...";
        }
        
    }
    protected DataTable getsearch()
    {
       

            // string FromDate = objconn.string_mm_dd_yy(txtFromDate.Text);
        //string TDate = objconn.string_mm_dd_yy(txtToDate.Text);
        //string ToDate = Convert.ToDateTime(TDate).AddDays(1.0).ToString("dd/MM/yyyy");
            //obj.ToDate = ObjCmn.string_mm_dd_yy(ToDate);
            string qry = "";
            string qry1 = "";
            string qry3 = "";
            DataTable dtsearch = new DataTable();
            qry = "select case_id,ref_no,(isnull(first_name,'')+' '+isnull(middle_name,'')+' '+isnull(last_name,'')) as applicant_name,'' as status_code,'' as overall_comments from cpv_cc_case_details " +
                    " where centre_id='" + Session["CentreID"] + "' and client_id='" + Session["ClientID"] + "' and case_rec_datetime>='" + dtFrom + "' and case_rec_datetime<'" + dtTo +"' and send_datetime is null and is_case_complete='y' and (overall_comments is null or overall_comments = '')";
            qry1 = "Select case_id,ref_no,(isnull(first_name,'')+' '+isnull(middle_name,'')+' '+isnull(last_name,'')) as applicant_name,b.status_code,overall_comments from cpv_cc_case_details a,case_status_master b" +
                   " where centre_id='" + Session["CentreID"] + "' and client_id='" + Session["ClientID"] + "' and case_rec_datetime>='" + dtFrom + "' and case_rec_datetime<'" + dtTo + "' and a.overall_status_id=b.case_status_id";
            qry3 = qry + " " + "Union" + " " + qry1;        

            OleDbDataAdapter oleDbDa = new OleDbDataAdapter(qry3, objconn.ConnectionString);
            DataSet da = new DataSet();
            oleDbDa.Fill(da, "Search");
            dtsearch = da.Tables["Search"];
            return dtsearch;
        
    }

    protected void GvOverall_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GvOverall.PageIndex = e.NewPageIndex;
        getsearchcases();
    }
    private struct Gridposition
    {
        public const int caseid=0;
        public const int refno=1;
        public const int applicantname=2;
        public const int overallstatus = 3;
        public const int comments = 4;
        public const int status = 5;
    }
    //protected void GvOverall_RowEditing(object sender, GridViewEditEventArgs e)
    //{
    //    GvOverall.EditIndex = e.NewEditIndex;
    //    propertyset();
    //    getsearchcases();

    //}

    protected void GvOverall_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        
       
            foreach (GridViewRow row in GvOverall.Rows)
             {
            
             string   strcaseid = row.Cells[Gridposition.caseid].Text;
             string FroDate = txtFromDate.Text;
             string Todate = txtToDate.Text;
                
                //string status = row.Cells[Gridposition.status].ResolveUrl(path + "Sup_remarks.aspx?Caseid=" + strcaseid + "&Mode=View");    
                
                for (Int32 rowTypeCount = 0; rowTypeCount < GvOverall.Rows.Count; rowTypeCount++)
                {
                    GridViewRow gvRow = GvOverall.Rows[rowTypeCount];
                    MatchVerificationType(row, strcaseid,FroDate,Todate);
                }
            }
            
    }
    private void propertyset()
    {
        objcasestatus.Fromdate = txtFromDate.Text.Trim().ToString();
        objcasestatus.Todate = txtToDate.Text.Trim().ToString();
        objcasestatus.ProductID = Session["ProductId"].ToString();
        objcasestatus.centreid = Session["CentreId"].ToString();
        objcasestatus.clientid = Session["ClientId"].ToString();

    }

    private void MatchVerificationType(GridViewRow gvRow, string caseID,string fromdate,string todate)
    {
        Label status = (Label)gvRow.Cells[Gridposition.status].FindControl("status");
        //string path = Server.MapPath("../../CPV/CC/");
        //string str= path + "Sup_remarks.aspx"
        //lblStatus.Text = "<a href=()>View</a>";
        //lblStatus.Visible = true;
         string str = "Sup_remarks.aspx?CaseID=" + caseID + "&FromDate=" + fromdate +"&ToDate=" + todate +"&Mode=view ";
                status.Text = "<A href='" + str + "'>view status</A>";
               status.Visible = true;
                //lblSlashRV.Visible = true;
    }
    
    
   

    //////////string path = Server.MapPath("../../CPV/CC/");
    //////////string str = Path + "Sup_remarks.aspx?CaseID=" + caseID + "&VerTypeId=1&VerificationTypeCode=" + verificationTypeCode + "&Mode=View";
    //////////            lblRV.Text = "<A href= ('" + str + "')>RV</A>";
    //////////            lblRV.Visible = true;
    //private DataTable fillstatus()
    //{

    //}
    protected void btnsearch_Click1(object sender, EventArgs e)
    {

        bool isValidDates = true;
        if (txtFromDate.Text.Trim() == "" || txtToDate.Text.Trim() == "")
        {
            isValidDates = false;
            lblMessage.Visible = true;
            lblMessage.Text = "Please enter From and To Date.";
            lblMessage.ForeColor = System.Drawing.Color.Red;
            lblMessage.Font.Bold = true;
        }
        
        if (txtFromDate.Text.Trim() != "" && txtToDate.Text.Trim() != "")
        {
        
       //string dtTodate;
       //string Fromdate;
            dtFrom = Convert.ToDateTime(objconn.strDate(txtFromDate.Text.Trim()));
            dtTo = Convert.ToDateTime(objconn.strDate(txtToDate.Text.Trim())).AddDays(1.0);
            //dtTo = "select dateadd(day,1,dtto)";
            //dtTodate = dtTo;
            //Fromdate = dtFrom;

            if (dtFrom > dtTo)
            {
                isValidDates = false;
                lblMessage.Visible = true;
                lblMessage.Text = "From date must be less than to date.";
            }
        }
        if (isValidDates == true)
        {
            //CExportDataDump objExportDump=new CExportDataDump();
            //DataSet dsExportDump = new DataSet();
            //Fdate = Convert.ToDateTime(objconn.strDate(txtFromDate.Text.Trim())).ToString("dd-MMM-yyyy");
            //Tdate = Convert.ToDateTime(objconn.strDate(txtToDate.Text.Trim())).AddDays(1.0).ToString("dd-MMM-yyyy");

            lblMessage.Text = "";
            getsearchcases();
        }
    }

    
}
