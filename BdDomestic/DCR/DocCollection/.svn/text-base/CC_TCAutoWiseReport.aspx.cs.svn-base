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
using CrystalDecisions.Shared;
using CrystalDecisions.CrystalReports.Engine;

public partial class CPV_CC_CC_TCAutoWiseReport : System.Web.UI.Page
{
    //DateTime fromdate;
    //DateTime todate;

    CCommon con = new CCommon();
    protected void Page_Load(object sender, EventArgs e)
    {
        txtFromDate.Focus();
    }
    public DataSet TcMis()
    {
        DataSet ds = new DataSet();
        string aa,bb, qry = "";

        aa = Convert.ToDateTime(txtFromDate.Text.Trim()).ToString("dd-MM-yyyy");
        bb = Convert.ToDateTime(txtToDate.Text.Trim()).ToString("dd-MM-yyyy");   
        //fromdate = Convert.ToDateTime(con.strDate(txtFromDate.Text.Trim()));
        //todate = Convert.ToDateTime(con.strDate(txtToDate.Text.Trim()));
        
        //todate = Convert.ToDateTime(con.strDate(txtToDate.Text.Trim().ToString()));

        qry = "Exec TeleDailyMis_DCR '" + aa + "','" + bb + "','" + Session["CentreId"].ToString() + "'";
        return OleDbHelper.ExecuteDataset(con.ConnectionString, CommandType.Text, qry);   
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        CCommon objCommon = new CCommon();
        bool isValidDates = true;
        
        if (isValidDates)
        {
            
            DataSet dsTcRepo = new DataSet();
            CReport crt = new CReport();
            dsTcRepo = TcMis(); 
            
            //TDate = Convert.ToDateTime(con.strDate(txtToDate.Text.Trim())).AddDays(1.0).ToString("dd-MMM-YYYY");
            //dsTcRepo = objReport.GetTcReport(con.strDate(txtFromDate.Text.Trim()), TDate, Session["ClientId"].ToString(), Session["CentreId"].ToString());

            if (dsTcRepo.Tables[0].Rows.Count > 0)
            {
                dsTcRepo.Tables[0].TableName = "TcWiseReport";
                Session["dataset"] = dsTcRepo;
                Session["Path"] = Server.MapPath("crTcAutoReport.rpt");
                Session.Remove("ParameterCollection");
                Response.Redirect("../../CrystalReportviewer.aspx?bckPgURL=CPV\\CC\\CC_CC_TCAutoWiseReport.aspx");
            }
            else
            {
                lblMsg.Visible = true;
                lblMsg.ForeColor = System.Drawing.Color.Red;
                lblMsg.Font.Bold = true;   
                lblMsg.Text = "No Record found.";
            }
            }
        }
    }
