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

public partial class Pages_ApplicationDiscrepancyReport : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {

            if (Session["UserInfo"] == null)
            {
                Response.Redirect("InvalidRequest.aspx", false);
            }

            if (!IsPostBack)
            {
                Get_SourceBranchList();
            }
        }
        catch (Exception ex)
        {
            lblMessage.CssClass = "ErrorMessage";
            lblMessage.Visible = true;
            lblMessage.Text = ex.Message;

        }
    }

    private void Get_SourceBranchList()
    {
        try
        {
            Object SaveUSERInfo = (Object)Session["UserInfo"];

            SqlConnection sqlCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);

            sqlCon.Open();
            SqlCommand sqlCom = new SqlCommand();
            sqlCom.Connection = sqlCon;
            sqlCom.CommandType = CommandType.StoredProcedure;
            sqlCom.CommandText = "Get_SourceBranhList";
            SqlDataAdapter sqlDA = new SqlDataAdapter();
            sqlDA.SelectCommand = sqlCom;

            SqlParameter BranchId = new SqlParameter();
            BranchId.SqlDbType = SqlDbType.Int;
            BranchId.Value = Convert.ToInt32(((UserInfo.structUSERInfo)(SaveUSERInfo)).BranchId);
            BranchId.ParameterName = "@BranchId";
            sqlCom.Parameters.Add(BranchId);


            DataTable dt = new DataTable();
            sqlDA.Fill(dt);
            sqlCon.Close();

            ddlSourceBranch.DataTextField = "SourceBranchName";
            ddlSourceBranch.DataValueField = "SourceBranchId";
            ddlSourceBranch.DataSource = dt;
            ddlSourceBranch.DataBind();

            ddlSourceBranch.Items.Insert(0, "(Select)");
            ddlSourceBranch.SelectedIndex = 0;



        }
        catch (Exception ex)
        {
            lblMessage.CssClass = "ErrorMessage";
            lblMessage.Visible = true;
            lblMessage.Text = ex.Message;

        }
    }
    protected void btnRetrive_Click(object sender, EventArgs e)
    {
        try
        {
            Generate_ExcelFile();

        }
        catch (Exception ex)
        {
            lblMessage.CssClass = "ErrorMessage";
            lblMessage.Visible = true;
            lblMessage.Text = ex.Message;

        }
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        try
        {
            Response.Redirect("Menu.aspx", false);
        }
        catch (Exception ex)
        {
            lblMessage.CssClass = "ErrorMessage";
            lblMessage.Visible = true;
            lblMessage.Text = ex.Message;

        }
    }

    public void GenerateCode()
    {
        //getData

        Object SaveUSERInfo = (Object)Session["UserInfo"];
        SqlConnection sqlCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);

        sqlCon.Open();
        SqlCommand sqlCom = new SqlCommand();
        sqlCom.Connection = sqlCon;
        sqlCom.CommandType = CommandType.StoredProcedure;
        sqlCom.CommandText = "Get_ApplicationDiscrepancyReport";

        SqlParameter BranchId = new SqlParameter();
        BranchId.SqlDbType = SqlDbType.Int;
        BranchId.Value = Convert.ToInt32(((UserInfo.structUSERInfo)(SaveUSERInfo)).BranchId);
        BranchId.ParameterName = "@BranchId";
        sqlCom.Parameters.Add(BranchId);


        SqlParameter FrmDate = new SqlParameter();
        FrmDate.SqlDbType = SqlDbType.VarChar;
        FrmDate.Value = txtFromDate.Text.Trim();
        FrmDate.ParameterName = "@FrmDate";
        sqlCom.Parameters.Add(FrmDate);

        SqlParameter ToDate = new SqlParameter();
        ToDate.SqlDbType = SqlDbType.VarChar;
        ToDate.Value = txtToDate.Text.Trim();
        ToDate.ParameterName = "@ToDate";
        sqlCom.Parameters.Add(ToDate);

        //
        int intSourceBranchId = 0;
        if (ddlSourceBranch.SelectedValue != "(Select)")
        {
            intSourceBranchId = Convert.ToInt32(ddlSourceBranch.SelectedValue);
        }


        SqlParameter SourceBranchId = new SqlParameter();
        SourceBranchId.SqlDbType = SqlDbType.Int;
        SourceBranchId.Value = intSourceBranchId;
        SourceBranchId.ParameterName = "@SourceBranchId";
        sqlCom.Parameters.Add(SourceBranchId);

        SqlDataAdapter sqlDA = new SqlDataAdapter();
        sqlDA.SelectCommand = sqlCom;
        DataTable dt = new DataTable();
        sqlDA.Fill(dt);
        sqlCon.Close();

        if (dt.Rows.Count > 0)
        {
            GridView1.DataSource = dt;
            GridView1.DataBind();

            lblMessage.Text = "Total Records Found " + dt.Rows.Count.ToString();
            lblMessage.CssClass = "SuccessMessage";
        }
        else
        {

            GridView1.DataSource = null;
            GridView1.DataBind();

            lblMessage.Text = "No Record Found!";
            lblMessage.CssClass = "ErrorMessage";
        }


    }
    public string GenerateTXTFile(DataTable dt)
    {

        string strHeader = "";
        string Value = "";
        // create a writer and open the file
        string FileName = "";
        string FileSAVEPAth = "";
        string ActualFileWithPath = "";
        FileName = "CVS_" + Convert.ToString(DateTime.Now.ToString("yyyyMMddHHmmss"));
        FileSAVEPAth = "C:\\TEMP\\";
        ActualFileWithPath = FileSAVEPAth + FileName + ".csv";

        TextWriter tw = new StreamWriter(ActualFileWithPath);

        int j;
        for (j = 0; j < dt.Columns.Count - 1; j++)
        {
            Value = Convert.ToString(dt.Columns[j]);
            strHeader = strHeader + Value + ",";
        }

        tw.WriteLine(strHeader);
        //tw.WriteLine("\n");
        int m;
        string strData = "";

        for (j = 0; j <= dt.Rows.Count - 1; j++)
        {

            for (m = 0; m < dt.Columns.Count - 1; m++)
            {
                Value = Convert.ToString(dt.Rows[j][m]);
                strData = strData + Value + ",";
            }

            tw.WriteLine(strData);
            //tw.WriteLine("\n");
            strData = "";
        }
        tw.Close();
        return ActualFileWithPath;
    }

    public override void VerifyRenderingInServerForm(Control control)
    {

    }
    private void Generate_ExcelFile()
    {
        String attachment = "attachment; filename=Discrepancy Report.xls";
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
                        "<b><font size='2' color='blue'>Discrepancy Report</font></b> <br/>";
        tblCell1.CssClass = "SuccessMessage";
        tblRow.Cells.Add(tblCell);
        tblRow1.Cells.Add(tblCell1);
        tblRow.Height = 20;
        tblSpace.Rows.Add(tblRow);
        tblSpace.Rows.Add(tblRow1);
        tblSpace.RenderControl(htw);

        Table tbl = new Table();
        GridView1.EnableViewState = false;
        GridView1.GridLines = GridLines.Both;

        tbExport.RenderControl(htw);
        Response.Write(sw.ToString());

        Response.End();
    }
    protected void btnGetReport_Click(object sender, EventArgs e)
    {
        if (ddlSourceBranch.SelectedIndex != 0)
        {
            GenerateCode();

        }
        else
        {

            if ((txtFromDate.Text != "") && (txtToDate.Text != ""))
            {
                GenerateCode();
            }
            else
            {
                lblMessage.Text = "Please select atleast one parameter to continue";
            }

        }
    }
}
