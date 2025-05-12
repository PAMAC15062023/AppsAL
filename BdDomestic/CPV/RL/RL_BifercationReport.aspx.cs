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

public partial class CPV_RL_RL_BifercationReport : System.Web.UI.Page
{
    CReport objReport = new CReport();
    CCommon con = new CCommon();
    protected void Page_Load(object sender, EventArgs e)
    {
        txtFromDate.Focus();
    }
    protected void btnGenrateReport_Click(object sender, EventArgs e)
    {


        bool isValidDates = true;
        if (txtFromDate.Text.Trim() != "" && txtToDate.Text.Trim() != "")
        {
            DateTime dtFrom;
            DateTime dtTo;
            dtFrom = Convert.ToDateTime(con.strDate(txtFromDate.Text.Trim()));
            dtTo = Convert.ToDateTime(con.strDate(txtToDate.Text.Trim()));

            if (dtFrom > dtTo)
            {
                isValidDates = false;
                lblMsg.Visible = true;
                lblMsg.Text = "From date must be less than to date.";
            }
        }
        //Added by hemangi kambli on 17-May-2007-------------------------
        if (isValidDates)
        {
            string sFromDate;
            string sToDate;
            string sClientID;
            string sCentreID;
            CReport objReport = new CReport();
            DataSet ds = new DataSet();

            string Tdate;
            Tdate = Convert.ToDateTime(con.strDate(txtToDate.Text.Trim())).AddDays(1.0).ToString("dd-MMM-yyyy");

            ds = objReport.RLBifurcationOfCases(con.strDate(txtFromDate.Text.Trim()), Tdate, Session["ClientId"].ToString(), Session["CentreId"].ToString());

            if (ds.Tables[0].Rows.Count > 0)
            {
                ds.Tables[0].TableName = "BIFERCATION";


                //--For Heading of Report------------------

                //dsPendingListHead.Tables[0].TableName = "PENDINGLISTHEADING";
                //DataRow drPendingListHead = dsPendingListHead.Tables[0].NewRow();
                //drPendingListHead["COMPANYNAME"] = "PAMAC Online";
                //drPendingListHead["FROMDATE"] = txtFromDate.Text.Trim();
                //drPendingListHead["TODATE"] = txtToDate.Text.Trim();
                //dsPendingListHead.Tables[0].Rows.Add(drPendingListHead);
                ///-----------------------------------------------------
                Session["dataset"] = ds;

                //Session["datasetHead"] = dsPendingListHead;
                Session["Path"] = Server.MapPath("RL_BifercationReport.rpt");
                Session.Remove("ParameterCollection");
                Response.Redirect("../../CrystalReportviewer.aspx?bckPgURL=CPV\\RL\\RL_BifercationReport.aspx");
            }
            else
            {
                lblMsg.Visible = true;
                lblMsg.ForeColor = System.Drawing.Color.Red;
                lblMsg.Text = "No Record found.";
            }
        }


        //DataSet ds = new DataSet();
        //string Tdate;
        //Tdate = Convert.ToDateTime(con.strDate(txtToDate.Text.Trim())).AddDays(1.0).ToString("dd-MMM-yyyy");

        ////FromDate = Convert.ToDateTime(txtFromDate.Text);
        ////ToDate = Convert.ToDateTime(txtToDate.Text);
        //ds = objReport.GetConsolidatedTATMIS(con.strDate(txtFromDate.Text.Trim()), Tdate, Session["ClientId"].ToString(), Session["CentreId"].ToString());
        //ds.Tables[0].TableName = "TATMIS_Report";
        //Session["dataset"] = ds;
        //Session["Path"] = Server.MapPath("rptTAT_Report.rpt");
        //Response.Redirect("../../CrystalReportViewer.aspx?bckPgURL=CPV\\CC\\CC_ConsolidatedTAT.aspx");  
    }
}
