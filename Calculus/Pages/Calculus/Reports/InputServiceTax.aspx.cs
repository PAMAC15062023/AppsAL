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

public partial class InputServiceTax : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserInfo"] == null)
        {
            Response.Redirect("~/Pages/InvalidRequest.aspx");
        }
        if (!IsPostBack)
        {
            Get_BranchId();
            Object SaveUSERInfo = (Object)Session["UserInfo"];
            if (((UserInfo.structUSERInfo)(SaveUSERInfo)).GroupName.Contains("Admin"))
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
    private void Get_BranchId()
    {
        try
        {
            SqlConnection sqlcon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);

            sqlcon.Open();
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlcon;
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.CommandText = "Get_AllBranchList";
            SqlDataAdapter sqlda = new SqlDataAdapter();
            sqlda.SelectCommand = sqlcmd;
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
    private void RegisterControls_WithJavascript()
    { 
    }
    protected void BtnGenerate_Click(object sender, EventArgs e)
    {
        Get_ChequeTrackerData();
    }
    private void Get_ChequeTrackerData()
    {
        SqlConnection sqlcon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);
        Object SaveUSERInfo = (Object)Session["UserInfo"];
        sqlcon.Open();
        SqlCommand sqlcmd = new SqlCommand();
        sqlcmd.Connection = sqlcon;
        sqlcmd.CommandType = CommandType.StoredProcedure;
        sqlcmd.CommandText = "CalOnlineTrans_GetServiceTaxInputReportNew_SP";
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
    protected void btnExport_Click(object sender, EventArgs e)
    {
        Generate_ExcelFile();
    }
    private void Generate_ExcelFile()
    {
        String attachment = "attachment; filename=Input_Service_Tax_Report.xls";
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
        tblCell1.Text = "<b><font size='4'>PAMAC FINSERVE PVT. LTD., MUMBAI</font></b> <br/>" +
                        "<b><font size='2' color='blue'>Input Service Tax Report ,Payment for Date : " + txtFromDate.Text + " To : " + txtFromDate.Text + " </font></b> <br/>";
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
        Response.Write(sw.ToString());

        Response.End();
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/pages/Menu.aspx", false);
   
    }
}
