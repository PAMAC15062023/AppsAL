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

public partial class CPV_CC_CC_BifercationReport : System.Web.UI.Page
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

            ds = objReport.CCBifurcationOfCases(con.strDate(txtFromDate.Text.Trim()), Tdate, Session["ClientId"].ToString(), Session["CentreId"].ToString());

            if (ds.Tables[0].Rows.Count > 0)
            {
                ds.Tables[0].TableName = "BIFERCATION";
                Session["dataset"] = ds;
                Session["Path"] = Server.MapPath("CC_BifercationReport.rpt");
                Session.Remove("ParameterCollection");
                Response.Redirect("../../CrystalReportviewer.aspx?bckPgURL=CPV\\CC\\CC_BifercationReport.aspx");
            }
            else
            {
                lblMsg.Visible = true;
                lblMsg.ForeColor = System.Drawing.Color.Red;
                lblMsg.Text = "No Record found.";
            }
        }
    }
}
