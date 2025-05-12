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

public partial class CPV_Cellular_CELL_BifercationCases : System.Web.UI.Page
{
    CCommon con = new CCommon();
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        bool isValidDates = true;
        if (txtDateFrom.Text.Trim() != "" && txtDateTo.Text.Trim() != "")
        {
            DateTime dtFrom;
            DateTime dtTo;
            dtFrom = Convert.ToDateTime(con.strDate(txtDateFrom.Text.Trim()));
            dtTo = Convert.ToDateTime(con.strDate(txtDateTo.Text.Trim()));

            if (dtFrom > dtTo)
            {
                isValidDates = false;
                lblMsg.Visible = true;
                lblMsg.Text = "From date must be less than to date.";
            }
        }
        if (isValidDates == true)
        {

            CReport objReport = new CReport();
            DataSet dsBifurcation = new DataSet();
            //DataSet dsPendingListHead = new DataSet();
            string Tdate;
            objReport.CaseType = ddlCaseType.SelectedValue.ToString();
            Tdate = Convert.ToDateTime(con.strDate(txtDateTo.Text.Trim())).AddDays(1.0).ToString("dd-MMM-yyyy");

            dsBifurcation = objReport.Cell_GetBifercationReport(con.strDate(txtDateFrom.Text.Trim()), Tdate, Session["ClientId"].ToString(), Session["CentreId"].ToString());
            //dsPendingListHead = objReport.GetPendingReportListHead(sFromDate, sToDate, "Pamac Online");

            if (dsBifurcation.Tables[0].Rows.Count > 0)
            {
                //--this statement is very important, here the table name should 
                //--match with the XML Schema table name 
                dsBifurcation.Tables[0].TableName = "BIFURCATIONOFCASES";
                Session["dataset"] = dsBifurcation;
                Session["Path"] = Server.MapPath("CELL_Bifercation.rpt");
                Session.Remove("ParameterCollection");
                Response.Redirect("../../CrystalReportviewer.aspx?bckPgURL=CPV\\Cellular\\CELL_BifercationCases.aspx");
            }
            else
            {
                lblMessage.Visible = true;
                lblMessage.ForeColor = System.Drawing.Color.Red;
                lblMessage.Text = "No Record found.";
            }
        }
    }

    protected void ddlCaseType_DataBound(object sender, EventArgs e)
    {
        ddlCaseType.Items.Insert(0, new ListItem("All", "0"));
    }
}
