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

public partial class CPV_Cellular_CEL_VerifierMISReport : System.Web.UI.Page
{
    CCommon con = new CCommon();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["isView"].ToString() != "1")
            Response.Redirect("NoAccess.aspx");
        lblMsg.Text = "";
    }
    
    protected void ddlCaseType_DataBound(object sender, EventArgs e)
    {
        ddlCaseType.Items.Insert(0, new ListItem("All", "0"));
    }
    protected void ddlFE_DataBound(object sender, EventArgs e)
    {
        ddlFE.Items.Insert(0, new ListItem("All", "0"));
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
                string caseType;
                string feID;
                CReport objReport = new CReport();
                DataSet dsVerifierMIS = new DataSet();
                string Tdate;
                Tdate = Convert.ToDateTime(con.strDate(txtToDate.Text)).AddDays(1.0).ToString("dd-MMM-yyyy");
                caseType = ddlCaseType.SelectedValue.Trim().ToString();
                feID = ddlFE.SelectedValue.Trim().ToString();
                dsVerifierMIS = objReport.Cell_GetVerifierMIS(Session["CentreId"].ToString(), con.strDate(txtFromDate.Text.Trim()), Tdate, caseType, feID);

                if (dsVerifierMIS.Tables[0].Rows.Count > 0)
                {
                    //--this statement is very important, here the table name should 
                    //--match with the XML Schema table name 
                    dsVerifierMIS.Tables[0].TableName = "VERIFIERMIS";



                    Session["dataset"] = dsVerifierMIS;


                    Session["Path"] = Server.MapPath("rptVerifierMISReport.rpt");
                    Session.Remove("ParameterCollection");
                    iCount = 1;


                }
                else
                {
                    lblMsg.Visible = true;
                    lblMsg.ForeColor = System.Drawing.Color.Red;
                    lblMsg.Text = "No Record found.";
                }
            }

        }
        catch (Exception ex)
        {
            lblMsg.Visible = true;
            lblMsg.Text = "Error : " + ex.Message;
        }
        if (iCount == 1)
        {
            Response.Redirect("../../CrystalReportviewer.aspx?bckPgURL=CPV\\Cellular\\CEL_VerifierMISReport.aspx");
        }
    }
}
