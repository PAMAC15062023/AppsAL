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

public partial class CPV_EBC_EBC_ClaimMISReport : System.Web.UI.Page
{
    CCommon con = new CCommon();
    CReport objReport = new CReport();
    protected void Page_Load(object sender, EventArgs e)
    {
        txtFromDate.Focus();
    }
    public bool FunctioncompareDate()
    {
        DateTime sFromDate;
        DateTime sToDate;
        sFromDate = Convert.ToDateTime(con.strDate(txtFromDate.Text.Trim()));
        sToDate = Convert.ToDateTime(con.strDate(txtToDate.Text.Trim()));

        bool bReturn = true;
        if (sFromDate > sToDate)
        {
            bReturn = false;
        }
        else
        {
            bReturn = true;


        }
        return bReturn;
    }
    protected void btnGenrateReport_Click(object sender, EventArgs e)
    {
        int iCount = 0;
        try
        {
        bool dateIsValid = false;
        dateIsValid = FunctioncompareDate();
        if (dateIsValid == true)
        {
            string sFromDate;
            string sToDate;
            
            DataSet dsClaimReport = new DataSet();
            //DataSet dsPendingListHead = new DataSet();

            string Tdate;
            Tdate = Convert.ToDateTime(con.strDate(txtToDate.Text)).AddDays(1.0).ToString("dd-MMM-yyyy");

            dsClaimReport = objReport.GetEBCClaimMISReport(con.strDate(txtFromDate.Text.Trim()), Tdate, Session["ClientId"].ToString(), Session["CentreId"].ToString());
           

            if (dsClaimReport.Tables[0].Rows.Count > 0)
            {
              
                dsClaimReport.Tables[0].TableName = "CLAIMMIS";


             
                Session["dataset"] = dsClaimReport;


                Session["Path"] = Server.MapPath("EBC_ClaimMISReport.rpt");
                Session.Remove("ParameterCollection");
                iCount = 1;
               // Response.Redirect("../../CrystalReportviewer.aspx?bckPgURL=CPV\\EBC\\EBC_ClaimMISReport.aspx");
            }
            else
            {
                lblMessage.Visible = true;
                lblMessage.ForeColor = System.Drawing.Color.Red;
                lblMessage.Text = "Record not found.";
            }
        }
        else
        {
            lblMessage.Visible = true;
            lblMessage.ForeColor = System.Drawing.Color.Red;
            lblMessage.Text = "From date must be less than to date.";
        }

        }
    catch (Exception ex)
    {
        lblMessage.Visible = true;
        lblMessage.Text = "Error while generating report: " + ex.Message;
    }



    if (iCount == 1)
    {
        Response.Redirect("../../CrystalReportviewer.aspx?bckPgURL=CPV\\EBC\\EBC_ClaimMISReport.aspx");
    }
    //try catch is added by supriya on 14th Nov2007 

    }
}
