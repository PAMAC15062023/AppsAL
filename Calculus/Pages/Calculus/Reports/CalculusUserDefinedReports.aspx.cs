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
using System.IO;

public partial class Pages_Calculus_Reports_CalculusUserDefinedReports : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserInfo"] == null)
        {
            Response.Redirect("~/Pages/InvalidRequest.aspx");
        }
        if (!IsPostBack)
        {
            Get_AllBranchList_For_Auth();
            Object SaveUSERInfo = (Object)Session["UserInfo"];
            if (((UserInfo.structUSERInfo)(SaveUSERInfo)).GroupName.Contains("Admin") || ((UserInfo.structUSERInfo)(SaveUSERInfo)).GroupName.Contains("FTS_Supervisor") || ((UserInfo.structUSERInfo)(SaveUSERInfo)).GroupName.Contains("Cal_Online_Trans") || ((UserInfo.structUSERInfo)(SaveUSERInfo)).GroupName.Contains("Vendor") || ((UserInfo.structUSERInfo)(SaveUSERInfo)).GroupName.Contains("CPA_manager"))
            {
                ddlBranchList.Enabled = true;
            }
            else
            {
                ddlBranchList.SelectedValue = Convert.ToString(((UserInfo.structUSERInfo)(SaveUSERInfo)).BranchId);
                ddlBranchList.Enabled = false;
            }        

        }

        RegisterControls_WithJavascript();
    }

    private void RegisterControls_WithJavascript() 
    {
        btnSearch.Attributes.Add("onclick", "javascript:return validate_Search();");
        ddlReportList.Attributes.Add("onchange", "javascript:ReportList();");
        btnExporttoExcel.Attributes.Add("onclick", "javascript:return validate_Export();");
        btnReset.Attributes.Add("onclick", "javascript:return Reset_values();"); 
       
    }
    private void Get_AllBranchList_For_Auth()
    {
        try
        {
            Object SaveUSERInfo = (Object)Session["UserInfo"];
         
            SqlConnection sqlcon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);

            sqlcon.Open();

            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlcon;
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.CommandText = "Get_AllBranchList_For_Auth";
            SqlDataAdapter sqlda = new SqlDataAdapter();
            sqlda.SelectCommand = sqlcmd;



            SqlParameter UserID = new SqlParameter();
            UserID.SqlDbType = SqlDbType.VarChar;
            UserID.Value = ((UserInfo.structUSERInfo)(SaveUSERInfo)).UserId.Trim(); 
            UserID.ParameterName = "@UserID";
            sqlcmd.Parameters.Add(UserID);
                       
            DataTable dt = new DataTable();

            sqlda.Fill(dt);
            sqlcon.Close();

            ddlBranchList.DataTextField = "BranchName";
            ddlBranchList.DataValueField = "BranchId";
            ddlBranchList.DataSource = dt;
            ddlBranchList.DataBind();

            ddlBranchList.Items.Insert(0, "-Select-");
            ddlBranchList.SelectedIndex = 0;

        }
        catch (Exception ex)
        {
            lblMessage.Visible = true;
            lblMessage.Text = ex.Message;
            lblMessage.CssClass = "ErrorMessage";
        }

    }
    private void Generate_ExcelFile()
    {
        String attachment = "attachment; filename=UserDefinedReport.xls";
        Response.AddHeader("content-disposition", attachment);
        Response.ContentType = "application/ms-excel";
        StringWriter sw = new System.IO.StringWriter();
        HtmlTextWriter htw = new HtmlTextWriter(sw);
        Table tblSpace = new Table();
        TableRow tblRow = new TableRow();
        TableCell tblCell = new TableCell();
        tblCell.Text = " ";

        TableRow tblRow1 = new TableRow();
        TableCell tblCell1 = new TableCell();
        tblCell1.ColumnSpan = 20;// 10;
        tblCell1.Text = "<b> <span style='background-color:Gray'> <font size='4'>PAMAC FINSERVE PVT. LTD., Branch-"+ddlBranchList.SelectedItem.Text+" </font></span></b> <br/>" +
                        "<b><font size='2' color='blue'>"+ lblReportHeader.Text + "  for Date " + txtFromDate.Text + " To " + txtToDate.Text + " </font></b> <br/>";
        tblCell1.CssClass = "SuccessMessage";
        tblRow.Cells.Add(tblCell);
        tblRow1.Cells.Add(tblCell1);
        tblRow.Height = 20;
        tblSpace.Rows.Add(tblRow);
        tblSpace.Rows.Add(tblRow1);
        tblSpace.RenderControl(htw);

        Table tbl = new Table();
        gvExportReport.EnableViewState = false;
        gvExportReport.GridLines = GridLines.Both;
        tbExport.RenderControl(htw);

        string style = @"<style> TD { mso-number-format:\@; } </style> ";
        Response.Write(style);

        Response.Write(sw.ToString());

        Response.End();
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        if (ddlReportList.SelectedIndex == 1)
        {
            Get_OtherThanPettyCashReport_VendorPayment();
        }
        else if (ddlReportList.SelectedItem.Value == "CalOnlineTrans_Get_Cheque_Payout_Report__SP")
        {
            Get_OtherThanPettyCashReport();
        }
        else
        {
            Get_OtherThanPettyCashReport();
        }
    }

    private void Get_OtherThanPettyCashReport_VendorPayment()
    {
        Object SaveUSERInfo = (Object)Session["UserInfo"];

        string ReportHeaderName = "";

        if (ddlReportList.SelectedIndex != 0)
        {

            ReportHeaderName = ddlReportList.SelectedItem.Text;

        }
        lblReportHeader.Text = ReportHeaderName;

        SqlConnection sqlcon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);

        sqlcon.Open();
        SqlCommand sqlcmd = new SqlCommand();
        sqlcmd.Connection = sqlcon;
        sqlcmd.CommandType = CommandType.StoredProcedure;
        sqlcmd.CommandText = "CalOnlineTrans_GetVendorPaymentReportBranchWiseAllCentre__SP";
		sqlcmd.CommandTimeout = 3600;
        SqlDataAdapter sqlda = new SqlDataAdapter();
        sqlda.SelectCommand = sqlcmd;

        int pBranchID = 0;
        if (ddlBranchList.SelectedIndex != 0)
        {
            pBranchID = Convert.ToInt32(ddlBranchList.SelectedItem.Value);
        }

        SqlParameter BranchID = new SqlParameter();
        BranchID.SqlDbType = SqlDbType.Int;
        BranchID.Value = pBranchID;
        BranchID.ParameterName = "@BranchID";
        sqlcmd.Parameters.Add(BranchID);

        SqlParameter FromDate = new SqlParameter();
        FromDate.SqlDbType = SqlDbType.VarChar;
        FromDate.Value = txtFromDate.Text.Trim();
        FromDate.ParameterName = "@FromDate";
        sqlcmd.Parameters.Add(FromDate);

        SqlParameter ToDate = new SqlParameter();
        ToDate.SqlDbType = SqlDbType.VarChar;
        ToDate.Value = txtToDate.Text.Trim();
        ToDate.ParameterName = "@ToDate";
        sqlcmd.Parameters.Add(ToDate);

        #region Code By Amrita on 22-Apr-2014 As per Client Requirement
        SqlParameter ClientId = new SqlParameter();
        ClientId.SqlDbType = SqlDbType.Int;
        ClientId.Value = Convert.ToInt32(((UserInfo.structUSERInfo)(SaveUSERInfo)).ClientId);
        ClientId.ParameterName = "@ClientId";
        sqlcmd.Parameters.Add(ClientId);
        #endregion


        SqlParameter status = new SqlParameter();
        status.SqlDbType = SqlDbType.VarChar;
        status.Value = ddlstatus.SelectedValue.ToString().Trim();
        status.ParameterName = "@status";
        sqlcmd.Parameters.Add(status);




        SqlParameter UserID = new SqlParameter();
        UserID.SqlDbType = SqlDbType.VarChar;
        UserID.Value = Convert.ToString(((UserInfo.structUSERInfo)(SaveUSERInfo)).UserId);
        UserID.ParameterName = "@UserID";
        sqlcmd.Parameters.Add(UserID);

        DataTable dt = new DataTable();
        sqlda.Fill(dt);
        sqlcon.Close();

        if (dt.Rows.Count > 0)
        {
            lblMessage.Text = "Record(s) Founds :" + dt.Rows.Count;
            lblMessage.CssClass = "SuccessMessage";

            gvExportReport.DataSource = dt;
            gvExportReport.DataBind();
        }
        else
        {
            lblMessage.CssClass = "ErrorMessage";
            lblMessage.Text = "Record(s) Founds :" + 0;
            gvExportReport.DataSource = null;
            gvExportReport.DataBind();
        }

    }

    private void Get_OtherThanPettyCashReport()
    {
        Object SaveUSERInfo = (Object)Session["UserInfo"];

        string ReportHeaderName = "";

        if (ddlReportList.SelectedIndex != 0)
        {

            ReportHeaderName = ddlReportList.SelectedItem.Text;
        
        }
        lblReportHeader.Text = ReportHeaderName;

        SqlConnection sqlcon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);
        
        sqlcon.Open();
        SqlCommand sqlcmd = new SqlCommand();
        sqlcmd.Connection = sqlcon;
        sqlcmd.CommandType = CommandType.StoredProcedure;
        sqlcmd.CommandText = ddlReportList.SelectedItem.Value.ToString().Trim(); 
		sqlcmd.CommandTimeout = 3600;
        SqlDataAdapter sqlda = new SqlDataAdapter();
        sqlda.SelectCommand = sqlcmd;

        int pBranchID = 0;
        if (ddlBranchList.SelectedIndex != 0)
        {
            pBranchID = Convert.ToInt32(ddlBranchList.SelectedItem.Value);
        }

        SqlParameter BranchID = new SqlParameter();
        BranchID.SqlDbType = SqlDbType.Int;
        BranchID.Value = pBranchID;
        BranchID.ParameterName = "@BranchID";
        sqlcmd.Parameters.Add(BranchID);

        SqlParameter FromDate = new SqlParameter();
        FromDate.SqlDbType = SqlDbType.VarChar;
        FromDate.Value = txtFromDate.Text.Trim();
        FromDate.ParameterName = "@FromDate";
        sqlcmd.Parameters.Add(FromDate);

        SqlParameter ToDate = new SqlParameter();
        ToDate.SqlDbType = SqlDbType.VarChar;
        ToDate.Value = txtToDate.Text.Trim();
        ToDate.ParameterName = "@ToDate";
        sqlcmd.Parameters.Add(ToDate);

        #region Code By Amrita on 22-Apr-2014 As per Client Requirement
        SqlParameter ClientId = new SqlParameter();
        ClientId.SqlDbType = SqlDbType.Int;
        ClientId.Value = Convert.ToInt32(((UserInfo.structUSERInfo)(SaveUSERInfo)).ClientId);
        ClientId.ParameterName = "@ClientId";
        sqlcmd.Parameters.Add(ClientId);
        #endregion

        //if (ddlReportList.SelectedItem.Value.ToString() == "Get_VendorPaymentReport_BranchWiseAllCentre")
        //{
            SqlParameter UserID = new SqlParameter();
            UserID.SqlDbType = SqlDbType.VarChar;
            UserID.Value = Convert.ToString(((UserInfo.structUSERInfo)(SaveUSERInfo)).UserId);
            UserID.ParameterName = "@UserID";
            sqlcmd.Parameters.Add(UserID);
        //}
            SqlParameter status = new SqlParameter();
            status.SqlDbType = SqlDbType.VarChar;
            status.Value = ddlstatus.SelectedValue.ToString().Trim();
            status.ParameterName = "@status";
            sqlcmd.Parameters.Add(status);


        DataTable dt = new DataTable();
        sqlda.Fill(dt);
        sqlcon.Close();

        if (dt.Rows.Count > 0)
        {
            lblMessage.Text = "Record(s) Founds :" + dt.Rows.Count;
            lblMessage.CssClass = "SuccessMessage";

            gvExportReport.DataSource = dt;
            gvExportReport.DataBind();
        }
        else
        {
            lblMessage.CssClass = "ErrorMessage";
            lblMessage.Text = "Record(s) Founds :" + 0;
            gvExportReport.DataSource = null;
            gvExportReport.DataBind();
        }

    }

    public override void VerifyRenderingInServerForm(Control control)
    {

    } 

    protected void btnExporttoExcel_Click(object sender, EventArgs e)
    {
        Generate_ExcelFile();
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Pages/menu.aspx", true);
    }
  
}
