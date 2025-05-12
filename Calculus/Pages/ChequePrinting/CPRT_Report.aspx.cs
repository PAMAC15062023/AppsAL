using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Pages_ChequePrinting_CPRT_Report : System.Web.UI.Page
{
    string ExportExcelFileName = string.Empty;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindBankName();
            BindBranchName();
            btnExport.Visible = false;
        }
    }
    protected void BindBankName()
    {
        try
        {
            SqlConnection sqlCon = new SqlConnection(ConfigurationManager.AppSettings["CPRT_ConnectionString"]);

            SqlCommand sqlCom = new SqlCommand();
            sqlCom.Connection = sqlCon;
            sqlCom.CommandType = CommandType.StoredProcedure;
            sqlCom.CommandText = "CPRT_BankName_SP";
            sqlCom.CommandTimeout = 0;


            SqlDataAdapter da = new SqlDataAdapter(sqlCom);
            DataSet ds = new DataSet();
            da.Fill(ds);

            if (ds != null && ds.Tables.Count > 0)
            {
                ddlBankName.DataTextField = "Bank_Name";
                ddlBankName.DataValueField = "Bank_Name";
                ddlBankName.DataSource = ds.Tables[0];
                ddlBankName.DataBind();

                ddlBankName.Items.Insert(0, "--Select--");
                ddlBankName.SelectedIndex = 0;
            }
        }
        catch (Exception ex)
        {

        }
    }
    protected void BindBranchName()
    {
        try
        {
            SqlConnection sqlCon = new SqlConnection(ConfigurationManager.AppSettings["CPRT_ConnectionString"]);

            SqlCommand sqlCom = new SqlCommand();
            sqlCom.Connection = sqlCon;
            sqlCom.CommandType = CommandType.StoredProcedure;
            sqlCom.CommandText = "CPRT_BranchName_SP";
            sqlCom.CommandTimeout = 0;


            SqlDataAdapter da = new SqlDataAdapter(sqlCom);
            DataSet ds = new DataSet();
            da.Fill(ds);

            if (ds != null && ds.Tables.Count > 0)
            {
                ddlBranchName.DataTextField = "Bank_BranchName";
                ddlBranchName.DataValueField = "Bank_BranchName";
                ddlBranchName.DataSource = ds.Tables[0];
                ddlBranchName.DataBind();

                ddlBranchName.Items.Insert(0, "--Select--");
                ddlBranchName.SelectedIndex = 0;
            }
        }
        catch (Exception ex)
        {

        }
    }
    protected void BindReports()
    {
        lblMessage.Text = "";

        SqlConnection sqlCon = new SqlConnection(ConfigurationManager.AppSettings["CPRT_ConnectionString"]);

        string proc;

        try
        {
            string msg = string.Empty;

            if (txtFromDate.Text == "" || txtFromDate.Text == null)
            {
                msg = msg + "Please Select From Date";
            }
            if (txtToDate.Text == "" || txtToDate.Text == null)
            {
                msg = msg + "Please Select To Date";
            }
            if (ddlBankName.SelectedValue == "--Select--")
            {
                msg = msg + "Please Select Bank Name";
            }
            if (ddlBranchName.SelectedValue == "--Select--")
            {
                msg = msg + "Please Select Branch Name";
            }
            if (msg != "")
            {
                ClientScript.RegisterStartupScript(Page.GetType(), "mykey", "alert('" + msg + "');", true);
                return;
            }

            SqlCommand sqlCom = new SqlCommand();
            sqlCom.Connection = sqlCon;
            sqlCom.CommandType = CommandType.StoredProcedure;
            sqlCom.CommandText = "CPRT_Report_SP";
            sqlCom.CommandTimeout = 0;

            SqlParameter FromDate = new SqlParameter();
            FromDate.SqlDbType = SqlDbType.VarChar;
            FromDate.Value = strDate(txtFromDate.Text.Trim());
            FromDate.ParameterName = "@FromDate";
            sqlCom.Parameters.Add(FromDate);

            SqlParameter ToDate = new SqlParameter();
            ToDate.SqlDbType = SqlDbType.VarChar;
            ToDate.Value = strDate(txtToDate.Text.Trim());
            ToDate.ParameterName = "@ToDate";
            sqlCom.Parameters.Add(ToDate);


            SqlParameter BankName = new SqlParameter();
            BankName.SqlDbType = SqlDbType.VarChar;
            BankName.Value = ddlBankName.SelectedValue;
            BankName.ParameterName = "@BankName";
            sqlCom.Parameters.Add(BankName);

            SqlParameter BranchName = new SqlParameter();
            BranchName.SqlDbType = SqlDbType.VarChar;
            BranchName.Value = ddlBranchName.SelectedValue;
            BranchName.ParameterName = "@BranchName";
            sqlCom.Parameters.Add(BranchName);

            SqlDataAdapter adp = new SqlDataAdapter(sqlCom);
            DataSet ds = new DataSet();

            adp.Fill(ds);

            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {

                grdlos.DataSource = ds;
                grdlos.DataBind();

                gvExportReport.DataSource = ds;
                gvExportReport.DataBind();

                btnExport.Visible = true;
            }
            else
            {
                grdlos.DataSource = null;
                grdlos.DataBind();

                gvExportReport.DataSource = null;
                gvExportReport.DataBind();

                btnExport.Visible = false;

                lblMessage.Text = "No Record Found ....!!!";
            }

        }
        catch (Exception ex)
        {
            lblMessage.Visible = true;
            lblMessage.Text = "Error :" + ex.Message;
        }
        finally
        {
            sqlCon.Close();
            sqlCon.Dispose();
        }
    }
    public string strDate(string strInDate)
    {
        string strDD = strInDate.Substring(0, 2);

        string strMM = strInDate.Substring(3, 2);

        string strYYYY = strInDate.Substring(6, 4);

        string strYYYYMMDD = strYYYY + "-" + strMM + "-" + strDD;

        DateTime dtConvertDate = Convert.ToDateTime(strYYYYMMDD);

        string strOutDate = dtConvertDate.ToString("yyyy-MM-dd");

        return strOutDate;
    }
    private void Genrate_Exel1()
    {
        String attachment = "attachment; filename=" + DateTime.Now.ToString("dd/MM/yyyy") + "CPRT_Report.xls";
        Response.AddHeader("content-disposition", attachment);
        Response.ContentType = "application/ms-excel";
        StringWriter sw = new System.IO.StringWriter();
        HtmlTextWriter htw = new HtmlTextWriter(sw);
        Table tblSpace = new Table();
        TableRow tblRow = new TableRow();
        TableCell tblCell = new TableCell();
        tblCell.Text = " ";
        tblCell.ColumnSpan = 10;// 10;
        tblCell.Text = "<b> <font size='2' color='blue'>PAMAC FINSERVE PVT. LTD.</font></span></b> <br/>";
        tblCell.CssClass = "SuccessMessage";
        TableRow tblRow1 = new TableRow();
        TableCell tblCell1 = new TableCell();
        tblCell1.ColumnSpan = 20;// 10;
        tblCell1.CssClass = "SuccessMessage";
        tblRow.Cells.Add(tblCell);
        tblRow1.Cells.Add(tblCell1);
        tblRow.Height = 20;
        tblSpace.Rows.Add(tblRow);
        tblSpace.Rows.Add(tblRow1);
        tblSpace.RenderControl(htw);

        Table tbl1 = new Table();
        grdlos.EnableViewState = false;
        grdlos.GridLines = GridLines.Both;
        tbExport.RenderControl(htw);
        Response.Write(sw.ToString());

        Response.End();
        Response.Write(sw.ToString());
    }
    public override void VerifyRenderingInServerForm(Control control)
    {
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        BindReports();
    }

    protected void btnExport_Click(object sender, EventArgs e)
    {
        Genrate_Exel1();
    }

    protected void btncancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/pages/menu.aspx", true);
    }
}