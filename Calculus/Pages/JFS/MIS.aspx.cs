using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.IO;
using System.Globalization;
using System.Collections;
using System.Text;

public partial class Pages_JFS_MIS : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Object SaveUSERInfo = (Object)Session["UserInfo"];
        if (Session["UserInfo"] == null)
        {
            Response.Redirect("~/Pages/InvalidRequest.aspx");
        }
    }
    protected void btncancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Pages/Menu.aspx", true);
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        ReportJFS();
        Generate_ExcelFileJFS();
    }
    private void Generate_ExcelFileJFS()
    {
        String attachment = "attachment; filename=" + ddlMIS.SelectedItem.ToString() + ".xls";
        Response.AddHeader("content-disposition", attachment);
        Response.ContentType = "application/ms-excel";
        StringWriter sw = new System.IO.StringWriter();
        HtmlTextWriter htw = new HtmlTextWriter(sw);
        Table tblSpace = new Table();
        TableRow tblRow = new TableRow();
        TableCell tblCell = new TableCell();
        tblCell.Text = " ";
        tblCell.ColumnSpan = 10;// 10;
        tblCell.Text = "<b> <font size='2' color='blue'>PAMAC FINSERVE PVT. LTD.</font></span></b> <br/>" +
        "<b><font size='2' color='blue'>From Date " + txtFromDate.Text + " To " + txtToDate.Text + " </font></b> <br/>";
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

        Table tbl = new Table();
        gvExportReport.EnableViewState = false;
        gvExportReport.GridLines = GridLines.Both;
        tbExport.RenderControl(htw);
        Response.Write(sw.ToString());

        Response.End();
    }
    public override void VerifyRenderingInServerForm(Control control)
    {

    }
    protected void ReportJFS()
    {
        SqlConnection sqlcon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);



        SqlCommand sqlCom = new SqlCommand();
        sqlCom.Connection = sqlcon;
        sqlCom.CommandType = CommandType.StoredProcedure;
        sqlCom.CommandText = ddlMIS.SelectedValue.ToString();
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


        sqlcon.Open();

        SqlDataAdapter sqlDA = new SqlDataAdapter();
        sqlDA.SelectCommand = sqlCom;

        DataTable dt = new DataTable();
        sqlDA.Fill(dt);

        sqlcon.Close();

        if (dt.Rows.Count > 0)
        {
            gvExportReport.DataSource = dt;
            gvExportReport.DataBind();

        }
        else
        {
            gvExportReport.DataSource = null;
            gvExportReport.DataBind();
        }
    }
    public string strDate(string strInDate)
    {
        string strDD = strInDate.Substring(0, 2);

        string strMM = strInDate.Substring(3, 2);

        string strYYYY = strInDate.Substring(6, 4);

        string strMMDDYYYY = strMM + "/" + strDD + "/" + strYYYY;

        //string strMMDDYYYY = strDD + "/" + strMM + "/" + strYYYY;

        DateTime dtConvertDate = Convert.ToDateTime(strMMDDYYYY);

        string strOutDate = dtConvertDate.ToString("dd-MMM-yyyy");

        return strOutDate;
    }
}


