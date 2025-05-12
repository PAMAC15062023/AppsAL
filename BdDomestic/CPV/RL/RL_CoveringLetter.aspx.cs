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

public partial class CPV_RL_RL_CoveringLetter : System.Web.UI.Page
{
    CCommon oCom = new CCommon();
    CCompanyMaster oComp = new CCompanyMaster();
    public string CompanyName;
    protected void Page_Load(object sender, EventArgs e)
    {
        txtDateFrom.Focus();
        //if (Session["isView"].ToString() != "1")
        //    Response.Redirect("NoAccess.aspx");
        if (IsPostBack)
        {
            lblMessage.Text = "";
        }
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        bool isValidDates = true;
        if (txtDateFrom.Text.Trim() != "" && txtDateTo.Text.Trim() != "")
        {
            DateTime dtFrom;
            DateTime dtTo;
            dtFrom = Convert.ToDateTime(oCom.strDate(txtDateFrom.Text.Trim()));
            dtTo = Convert.ToDateTime(oCom.strDate(txtDateTo.Text.Trim()));

            if (dtFrom > dtTo)
            {
                isValidDates = false;
                lblMessage.Visible = true;
                lblMessage.Text = "From date must be less than to date.";
            }
        }
        if (isValidDates == true)
        {
            string sFromDate;
            string sToDate;
            CReport objReport = new CReport();
            DataSet dsCoverLetter = new DataSet();
            //DataSet dsPendingListHead = new DataSet();

            string Tdate;
            Tdate = Convert.ToDateTime(oCom.strDate(txtDateTo.Text.Trim())).AddDays(1.0).ToString("dd-MMM-yyyy");

            dsCoverLetter = objReport.RLCoverLetter(oCom.strDate(txtDateFrom.Text.Trim()), Tdate, Session["ClientId"].ToString(), Session["CentreId"].ToString());
            //dsPendingListHead = objReport.GetPendingReportListHead(sFromDate, sToDate, "Pamac Online");

            if (dsCoverLetter.Tables[0].Rows.Count > 0)
            {
                //--this statement is very important, here the table name should 
                //--match with the XML Schema table name 
                dsCoverLetter.Tables[0].TableName = "COVERLETTER";


                //--For Heading of Report------------------

                //dsPendingListHead.Tables[0].TableName = "PENDINGLISTHEADING";
                //DataRow drPendingListHead = dsPendingListHead.Tables[0].NewRow();
                //drPendingListHead["COMPANYNAME"] = "PAMAC Online";
                //drPendingListHead["FROMDATE"] = txtFromDate.Text.Trim();
                //drPendingListHead["TODATE"] = txtToDate.Text.Trim();
                //dsPendingListHead.Tables[0].Rows.Add(drPendingListHead);
                ///-----------------------------------------------------
                Session["dataset"] = dsCoverLetter;

                //Session["datasetHead"] = dsPendingListHead;
                Session["Path"] = Server.MapPath("RLCoverLetter.rpt");
                Session.Remove("ParameterCollection");
                Response.Redirect("../../CrystalReportviewer.aspx?bckPgURL=CPV\\RL\\RL_CoveringLetter.aspx");
            }
            else
            {
                lblMessage.Visible = true;
                lblMessage.ForeColor = System.Drawing.Color.Red;
                lblMessage.Text = "No Record found.";
            }
        }
    }
    //private void GRIDVIEW()
    //{
    //    CCover_Letter oCL = new CCover_Letter();
    //    oCL.Date_From1 = txtDateFrom.Text;
    //    oCL.Date_To1 = txtDateTo.Text;
    //    oCL.Client_id1 = Session["ClientId"].ToString();
    //    oCL.Center_id1 = Session["CentreId"].ToString();
    //    CompanyName = oComp.companyName().ToString();

    //    try
    //    {
    //        gvCoverLetter.DataSource = oCL.getRecords();
    //        gvCoverLetter.DataBind();
    //        if (gvCoverLetter.Rows.Count == 0)
    //        {
    //            lblMessage.Text = "No Records Found !";
    //        }
    //        else
    //        {
    //            int Sr_no = 1;
    //            for (int i = 0; i < gvCoverLetter.Rows.Count; i++)
    //            {

    //                gvCoverLetter.Rows[i].Cells[0].Text = Sr_no.ToString();

    //                Sr_no++;
    //            }
    //        }
    //    }
    //    catch (Exception)
    //    {

    //    }

    //}
    //private void CRYSTALVIEW()
    //{
    //    CCover_Letter oCL = new CCover_Letter();
    //    string Fdate = txtDateFrom.Text;
    //    oCL.Date_From1 = Fdate;

    //    string Tdate = txtDateTo.Text;
    //    string TTdate = Tdate;

    //    oCL.Date_To1 = Convert.ToDateTime(Tdate).AddDays(1.0).ToString("dd-MMM-yyyy");
    //    oCL.Client_id1 = Session["ClientId"].ToString();
    //    oCL.Center_id1 = Session["CentreId"].ToString();
    //    CompanyName = oComp.companyName().Tables[0].Rows[0][0].ToString();
    //    DataSet ds = new DataSet();
    //    ds = oCL.getRecords();

    //    //CODED BY ASHISH
    //    CCrystalReport obj = new CCrystalReport();
    //    ArrayList Name = new ArrayList();
    //    Name.Add("Fdate");
    //    Name.Add("Tdate");
    //    Name.Add("ClIENTID");
    //    Name.Add("CENTERID");
    //    Name.Add("COMPANYNAME");
    //    Name.Add("TTdate");

    //    //Change1

    //    string[] PName;
    //    PName = (string[])Name.ToArray(typeof(string));
    //    ArrayList Value = new ArrayList();
    //    Value.Add(oCL.Date_From1);
    //    Value.Add(oCL.Date_To1);
    //    Value.Add(oCL.Client_id1);
    //    Value.Add(oCL.Center_id1);
    //    Value.Add(CompanyName);
    //    Value.Add(TTdate);
    //    //Value.Add("COVER LETTER");
    //    //Chande2

    //    string[] PValue;
    //    PValue = (string[])Value.ToArray(typeof(string));
    //    ParameterFields parcol = new ParameterFields();
    //    //Change3....
    //    parcol = obj.ParameterOnly(6, PName, PValue);
    //    Session["ParameterCollection"] = parcol;
    //    Session["ReportName"] = "CrystalCoverLetter.rpt";
    //    Session["Link"] = "CC_Cover_Letter.aspx";
    //    //Change 4.....(Name of  Your Crystal Report)
    //    Response.Redirect("CC_Container.aspx");
    //}

}
