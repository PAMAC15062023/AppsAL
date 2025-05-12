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
using CrystalDecisions.Shared;
using CrystalDecisions.CrystalReports.Engine;

public partial class CPV_EBC_EBC_FEWiseSearch : System.Web.UI.Page
{
    CCommon con = new CCommon();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["isView"].ToString() != "1")
            Response.Redirect("NoAccess.aspx");
        lblMsg.Text = "";
        txtFromDate.Focus();
    }
    protected void btnSearch_Click(object sender, EventArgs e)
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
        if (isValidDates)
        {
            string sFromDate;
            string sToDate;
            string sClientID;
            string sCentreID;
            CReport objReport = new CReport();
            DataSet dsFEReport = new DataSet();

            string Tdate;
            Tdate = Convert.ToDateTime(con.strDate(txtToDate.Text)).AddDays(1.0).ToString("dd-MMM-yyyy");

            dsFEReport = objReport.GetEBCFESearch(con.strDate(txtFromDate.Text.Trim()), Tdate, Session["ClientId"].ToString(), Session["CentreId"].ToString());

            if (dsFEReport.Tables[0].Rows.Count > 0)
            {
                dsFEReport.Tables[0].TableName = "FEWiseSearch";
                Session["dataset"] = dsFEReport;

                //Session["datasetHead"] = dsPendingListHead;
                Session["Path"] = Server.MapPath("EBC_FEWiseSearch.rpt");
                Session.Remove("ParameterCollection");
                Response.Redirect("../../CrystalReportviewer.aspx?bckPgURL=CPV\\EBC\\EBC_FEWiseSearch.aspx");
            }
            else
            {
                lblMsg.Visible = true;
                lblMsg.ForeColor = System.Drawing.Color.Red;
                lblMsg.Text = "Record not found.";
            }
        }

    }
}
