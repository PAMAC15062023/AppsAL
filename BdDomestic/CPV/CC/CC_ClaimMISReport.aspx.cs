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
using System.Data.SqlClient;
using System.Data.OleDb;

public partial class CPV_CC_CC_ClaimMISReport : System.Web.UI.Page
{
    CCommon objCom = new CCommon();
    protected void Page_Load(object sender, EventArgs e)
    {        
        //if (Session["isView"].ToString() != "1")
        //    Response.Redirect("NoAccess.aspx");
        lblMessage.Text = "";
        txtFromDate.Focus();
    }
    protected void btnGenrateReport_Click(object sender, EventArgs e)
    {
        int iCount=0;
        try
        {
            bool dateIsValid = false;
            dateIsValid = FunctioncompareDate();
            if (dateIsValid == true)
            {
                CReport objReport = new CReport();
                DataSet dsClaimReport = new DataSet();
                //DataSet dsPendingListHead = new DataSet();

                string Tdate;
                Tdate = Convert.ToDateTime(objCom.strDate(txtToDate.Text.Trim())).AddDays(1.0).ToString("dd-MMM-yyyy");

                dsClaimReport = objReport.GetClaimMISReport((objCom.strDate(txtFromDate.Text.Trim())), Tdate, Session["ClientId"].ToString(), Session["CentreId"].ToString());
                //dsPendingListHead = objReport.GetPendingReportListHead(sFromDate, sToDate, "Pamac Online");

                if (dsClaimReport.Tables[0].Rows.Count > 0)
                {
                    //--this statement is very important, here the table name should 
                    //--match with the XML Schema table name 
                    dsClaimReport.Tables[0].TableName = "CLAIMMIS";


                    //--For Heading of Report------------------

                    //dsPendingListHead.Tables[0].TableName = "PENDINGLISTHEADING";
                    //DataRow drPendingListHead = dsPendingListHead.Tables[0].NewRow();
                    //drPendingListHead["COMPANYNAME"] = "PAMAC Online";
                    //drPendingListHead["FROMDATE"] = txtFromDate.Text.Trim();
                    //drPendingListHead["TODATE"] = txtToDate.Text.Trim();
                    //dsPendingListHead.Tables[0].Rows.Add(drPendingListHead);
                    ///-----------------------------------------------------
                    Session["dataset"] = dsClaimReport;

                    //Session["datasetHead"] = dsPendingListHead;
                    Session["Path"] = Server.MapPath("ClaimMISReport.rpt");
                    Session.Remove("ParameterCollection");
                    iCount = 1;                    
                }
                else
                {
                    lblMessage.Visible = true;                    
                    lblMessage.Text = "No Record found.";
                }
            }
            else
            {
                lblMessage.Visible = true;                
                lblMessage.Text = "To Date Should be Greater than From Date";
            }
            
        }
        catch (Exception ex)
        {
            lblMessage.Visible = true;
            lblMessage.Text = "Error while generating report: " + ex.Message;
        }
        if (iCount == 1)
        {
            Response.Redirect("../../CrystalReportviewer.aspx?bckPgURL=CPV\\CC\\CC_ClaimMISReport.aspx");
        }
    }
   public bool FunctioncompareDate() 
    {
        
        DateTime sFromDate;
        DateTime sToDate;
        sFromDate = Convert.ToDateTime(objCom.strDate(txtFromDate.Text.Trim()));
        sToDate = Convert.ToDateTime(objCom.strDate(txtToDate.Text.Trim()));
       
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
}
