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

public partial class CPV_EBC_EBC_PendingList : System.Web.UI.Page
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

         int iCount = 0;
        try
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
        if (isValidDates == true)
        {
            string sFromDate;
            string sToDate;
            CReport objReport = new CReport();
            DataSet dsPendingList = new DataSet();
            //DataSet dsPendingListHead = new DataSet();

            string Tdate;
            Tdate = Convert.ToDateTime(con.strDate(txtToDate.Text)).AddDays(1.0).ToString("dd-MMM-yyyy");

            dsPendingList = objReport.GetEBCPendingReportList(con.strDate(txtFromDate.Text.Trim()), Tdate, Session["ClientId"].ToString(), Session["CentreId"].ToString());
            //dsPendingListHead = objReport.GetPendingReportListHead(sFromDate, sToDate, "Pamac Online");

            if (dsPendingList.Tables[0].Rows.Count > 0)
            {
                //--this statement is very important, here the table name should 
                //--match with the XML Schema table name 
                dsPendingList.Tables[0].TableName = "PENDINGLIST";


                //--For Heading of Report------------------

                //dsPendingListHead.Tables[0].TableName = "PENDINGLISTHEADING";
                //DataRow drPendingListHead = dsPendingListHead.Tables[0].NewRow();
                //drPendingListHead["COMPANYNAME"] = "PAMAC Online";
                //drPendingListHead["FROMDATE"] = txtFromDate.Text.Trim();
                //drPendingListHead["TODATE"] = txtToDate.Text.Trim();
                //dsPendingListHead.Tables[0].Rows.Add(drPendingListHead);
                ///-----------------------------------------------------
                Session["dataset"] = dsPendingList;

                //Session["datasetHead"] = dsPendingListHead;
                Session["Path"] = Server.MapPath("EBC_PendingList.rpt");
                Session.Remove("ParameterCollection");
                iCount = 1;
               // Response.Redirect("../../CrystalReportviewer.aspx?bckPgURL=CPV\\EBC\\EBC_PendingList.aspx");
                //Response.Redirect("CC_CrystalReportViewer.aspx?bckPgURL=CPV\\CC\\CC_PendingList.aspx");
            }
            else
            {
                lblMsg.Visible = true;
                lblMsg.ForeColor = System.Drawing.Color.Red;
                lblMsg.Text = "Record not found.";
            }
        }
    }
    catch (Exception ex)
    {
        lblMsg.Visible = true;
        lblMsg.Text = "Error while generating report: " + ex.Message;
    }



    if (iCount == 1)
    {
        Response.Redirect("../../CrystalReportviewer.aspx?bckPgURL=CPV\\EBC\\EBC_PendingList.aspx");
    }
    //try catch is added by supriya on 15th Nov2007 
    }
}
