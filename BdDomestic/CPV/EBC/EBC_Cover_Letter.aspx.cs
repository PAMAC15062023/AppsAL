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

public partial class CPV_EBC_EBC_Cover_Letter : System.Web.UI.Page
{
    CCommon Con = new CCommon();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["isView"].ToString() != "1")
            Response.Redirect("NoAccess.aspx");
        lblMessage.Text = "";
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        bool isValidDates = true;
        if (txtDateFrom.Text.Trim() != "" && txtDateTo.Text.Trim() != "")
        {
            DateTime dtFrom;
            DateTime dtTo;
            dtFrom = Convert.ToDateTime(Con.strDate(txtDateFrom.Text.Trim()));
            dtTo = Convert.ToDateTime(Con.strDate(txtDateTo.Text.Trim()));

            if (dtFrom > dtTo)
            {
                isValidDates = false;
                lblMessage.Visible = true;
                lblMessage.Text = "From date must be less than to date.";
            }
        }
        if (isValidDates == true)
        {
            CReport objReport = new CReport();
            DataSet dsCoverLetter = new DataSet();
            //DataSet dsPendingListHead = new DataSet();
            string Tdate;
            Tdate = Convert.ToDateTime(Con.strDate(txtDateTo.Text.Trim())).AddDays(1.0).ToString("dd-MMM-yyyy");

            dsCoverLetter = objReport.GetEBCCoveringLetterDtl(Con.strDate(txtDateFrom.Text.Trim()), Tdate, Session["ClientId"].ToString(), Session["CentreId"].ToString(), ddlVeriTypeID.SelectedValue.Trim());
            //dsPendingListHead = objReport.GetPendingReportListHead(sFromDate, sToDate, "Pamac Online");

            if (dsCoverLetter.Tables[0].Rows.Count > 0)
            {
                //--this statement is very important, here the table name should 
                //--match with the XML Schema table name 
                dsCoverLetter.Tables[0].TableName = "COVERING LETTER";
                Session["dataset"] = dsCoverLetter;
                Session["Path"] = Server.MapPath("EBC_Cover_Letter.rpt");
                Session.Remove("ParameterCollection");
                Response.Redirect("../../CrystalReportviewer.aspx?bckPgURL=CPV\\EBC\\EBC_Cover_Letter.aspx");
            }
            else
            {
                lblMessage.Visible = true;
                lblMessage.ForeColor = System.Drawing.Color.Red;
                lblMessage.Text = "Record not found.";
            }
        }
    }
    protected void ddlVeriTypeID_DataBound(object sender, EventArgs e)
    {
        //ddlVeriTypeID.Items.Insert(0, "All");
    }
}
