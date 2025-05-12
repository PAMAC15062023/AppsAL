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

public partial class CPV_Cellular_CC_Cellular_PendingList_Report : System.Web.UI.Page
{
    CCommon con = new CCommon();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["isView"].ToString() != "1")
            Response.Redirect("NoAccess.aspx");
            lblMsg.Text = "";

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
            objReport.value = ddlValue.SelectedValue.ToString();
            objReport.CaseType = ddlCaseType.SelectedValue.ToString();
            dsPendingList = objReport.Cell_GetPendingList(con.strDate(txtFromDate.Text.Trim()), Tdate, Session["ClientId"].ToString(), Session["CentreId"].ToString());
           
            if (dsPendingList.Tables[0].Rows.Count > 0)
            {
                //--this statement is very important, here the table name should 
                //--match with the XML Schema table name 
                dsPendingList.Tables[0].TableName = "PENDINGLIST";


               
                Session["dataset"] = dsPendingList;


                Session["Path"] = Server.MapPath("CC_Cellular_PendingList_Report.rpt");
                Session.Remove("ParameterCollection");
                iCount = 1;
                //Response.Redirect("../../CrystalReportviewer.aspx?bckPgURL=CPV\\Cellular\\CC_Cellular_PendingList_Report.aspx");
              
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
        Response.Redirect("../../CrystalReportviewer.aspx?bckPgURL=CPV\\Cellular\\CC_Cellular_PendingList_Report.aspx");
    }
    //try catch is added by supriya on 16th Nov2007 
    }
    protected void ddlCaseType_DataBound(object sender, EventArgs e)
    {
        ddlCaseType.Items.Insert(0, new ListItem("All", "0"));
    }
}
