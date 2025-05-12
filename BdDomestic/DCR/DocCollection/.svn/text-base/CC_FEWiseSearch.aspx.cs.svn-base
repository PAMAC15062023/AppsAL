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
public partial class CC_FEWiseSearch : System.Web.UI.Page
{
    CCommon con = new CCommon();
    
    protected void Page_Load(object sender, EventArgs e)
    {        
        //if (Session["isView"].ToString() != "1")
        //    Response.Redirect("NoAccess.aspx");
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
            dtTo = Convert.ToDateTime(con.strDate( txtToDate.Text.Trim()));

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
            DataSet dsFEReport = new DataSet();

            string Tdate;
            Tdate = Convert.ToDateTime(con.strDate(txtToDate.Text.Trim())).AddDays(1.0).ToString("dd-MMM-yyyy");

            dsFEReport = objReport.GetFeReport(con.strDate(txtFromDate.Text.Trim()), Tdate, Session["ClientId"].ToString(), Session["CentreId"].ToString());

            if (dsFEReport.Tables[0].Rows.Count > 0)
            {
                dsFEReport.Tables[0].TableName = "FEWISEREPORT";


                //--For Heading of Report------------------

                //dsPendingListHead.Tables[0].TableName = "PENDINGLISTHEADING";
                //DataRow drPendingListHead = dsPendingListHead.Tables[0].NewRow();
                //drPendingListHead["COMPANYNAME"] = "PAMAC Online";
                //drPendingListHead["FROMDATE"] = txtFromDate.Text.Trim();
                //drPendingListHead["TODATE"] = txtToDate.Text.Trim();
                //dsPendingListHead.Tables[0].Rows.Add(drPendingListHead);
                ///-----------------------------------------------------
                Session["dataset"] = dsFEReport;

                //Session["datasetHead"] = dsPendingListHead;
                Session["Path"] = Server.MapPath("crFEWiseReport.rpt");
                Session.Remove("ParameterCollection");
                Response.Redirect("../../CrystalReportviewer.aspx?bckPgURL=CPV\\CC\\CC_FEWiseSearch.aspx");
            }
            else
            {
                lblMsg.Visible = true;
                lblMsg.ForeColor = System.Drawing.Color.Red;
                lblMsg.Text = "No Record found.";
            }
        }


        /////////End--------------------------------------------




        ////----------------------------------------------------------------
        //Commented by hemangi kambli on 17-May-2007-------------------------
        //CCrystalReport obj = new CCrystalReport();
        //ArrayList Name = new ArrayList();
        //Name.Add("Fdate");
        //Name.Add("Tdate");
        ////Change1

        //string[] PName;
        //PName = (string[])Name.ToArray(typeof(string));
        //ArrayList Value = new ArrayList();
        //Value.Add(txtFromDate.Text);
        //Value.Add(txtToDate.Text);
        ////Chande2

        //string[] PValue;
        //PValue = (string[])Value.ToArray(typeof(string));
        //ParameterFields parcol = new ParameterFields();
        ////Change3....
        //parcol = obj.ParameterOnly(2, PName, PValue);
        //Session["ParameterCollection"] = parcol;
        //Session["ReportName"] = "FEWiseReport.rpt";
        ////Change 4.....(Name of  Ypur Crystal Report)
        //Response.Redirect("feWiseContainer.aspx");
        //End Commented by hemangi kambli on 17-May-2007-------------------------
       
      
    }
}
