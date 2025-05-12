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

public partial class CPV_RL_RL_ConsolidatedTAT : System.Web.UI.Page
{
    CReport objReport = new CReport();
    CCommon con = new CCommon();
    protected void Page_Load(object sender, EventArgs e)
    {
        //if (Session["isView"].ToString() != "1")
        //    Response.Redirect("NoAccess.aspx");
        txtFromDate.Focus();
    }
    protected void btnGenrateReport_Click(object sender, EventArgs e)
    {

        DataSet ds = new DataSet();
        string Tdate;
        Tdate = Convert.ToDateTime(con.strDate(txtToDate.Text.Trim())).AddDays(1.0).ToString("dd-MMM-yyyy");

        ds = objReport.GetConsolidatedTATMIS_RL(con.strDate(txtFromDate.Text.Trim()), Tdate, Session["ClientId"].ToString(), Session["CentreId"].ToString());
   
         if (ds.Tables[0].Rows.Count > 0)
        {
        ds.Tables[0].TableName = "TATMIS_Report";
        Session["dataset"] = ds;
        Session["Path"] = Server.MapPath("rptTAT_Report.rpt");
        Response.Redirect("../../CrystalReportViewer.aspx?bckPgURL=CPV\\RL\\RL_ConsolidatedTAT.aspx");
        }
    else
    {
        lblMessage.Visible = true;
        lblMessage.ForeColor = System.Drawing.Color.Red;
        lblMessage.Text = "No Record found.";
    }



    }
}
