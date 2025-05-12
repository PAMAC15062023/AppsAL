using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Pages_CFS_Reports : System.Web.UI.Page
{
    public override void VerifyRenderingInServerForm(Control control)
    {
        /* Verifies that the control is rendered */
    }
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void BindReports()
    {
        lblMsg.Visible = false;
        lblMsg.Text = "";

        string msg = string.Empty;

        hfReportTypes.Value = ddlcustomerType.SelectedItem.Text;


        if (txtFromDate.Text == "")
        {
            msg = msg + "Please Select From Date ....!!!";
        }
        if (txtToDate.Text == "")
        {
            msg = msg + "Please Select To Date ....!!!";
        }
        if (ddlcustomerType.SelectedValue == "0")
        {
            msg = msg + "Please Select  Report  ...!!!";
        }

        if (msg != "")
        {
            ClientScript.RegisterStartupScript(Page.GetType(), "mykey", "alert('" + msg + "');", true);
            return;
        }




        SqlConnection sqlCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);

         
        SqlCommand sqlCom = new SqlCommand();
        sqlCom.Connection = sqlCon;
        sqlCom.CommandType = CommandType.StoredProcedure;
        sqlCom.CommandText = "CFS_VERTICAL_RPT_SP";
        SqlDataAdapter sqlDA = new SqlDataAdapter();
        sqlDA.SelectCommand = sqlCom;

        SqlParameter ReportType = new SqlParameter();
        ReportType.SqlDbType = SqlDbType.VarChar;
        ReportType.Value = ddlcustomerType.SelectedValue;
        ReportType.ParameterName = "@repttype";
        sqlCom.Parameters.Add(ReportType);

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


        SqlDataAdapter adp = new SqlDataAdapter(sqlCom);
        DataSet ds = new DataSet();
        adp.Fill(ds);

        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            gvcustomerDetails.DataSource = ds;
            gvcustomerDetails.DataBind();

            btnExport.Visible = true;
        }
        else
        {
            gvcustomerDetails.DataSource = null;
            gvcustomerDetails.DataBind();

            lblMsg.Visible = true;
            lblMsg.Text = "No Record Found";
            btnExport.Visible = false;
        }
    }
    private void ExportGridToExcel()
    {
        Response.Clear();
        Response.Buffer = true;
        Response.ClearContent();
        Response.ClearHeaders();
        Response.Charset = "";
        string FileName = "Reports" + DateTime.Now + ".xls";
        StringWriter strwritter = new StringWriter();
        HtmlTextWriter htmltextwrtter = new HtmlTextWriter(strwritter);
        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        Response.ContentType = "application/vnd.ms-excel";
        Response.AddHeader("Content-Disposition", "attachment;filename=" + hfReportTypes.Value + " - " + FileName);
        Table tblSpace = new Table();
        TableRow tblRow = new TableRow();
        TableCell tblCell = new TableCell();
        tblCell.Text = " ";
        tblCell.ColumnSpan = 10;

        tblCell.Text = "<b> <span style='background-color:Gray'> <font size='4'>PAMAC FINSERVE PVT. LTD.</font></span></b> <br/>" +
                        "<b><font size='2' color='blue'>CFS Reports - " + hfReportTypes.Value + ".</font></b> <br/>";


        TableRow tblRow1 = new TableRow();
        TableCell tblCell1 = new TableCell();
        tblCell1.ColumnSpan = 20;
        tblRow.Cells.Add(tblCell);
        tblRow1.Cells.Add(tblCell1);
        tblRow.Height = 10;
        tblSpace.Rows.Add(tblRow);
        tblSpace.Rows.Add(tblRow1);
        tblSpace.RenderControl(new HtmlTextWriter(Response.Output));
        gvcustomerDetails.GridLines = GridLines.Both;
        gvcustomerDetails.HeaderStyle.Font.Bold = true;
        gvcustomerDetails.RenderControl(htmltextwrtter);
        Response.Write(strwritter.ToString());
        Response.End();

    }

    protected void btnExport_Click(object sender, EventArgs e)
    {
        ExportGridToExcel();
    }


    protected void btnCalcel_Click(object sender, EventArgs e)
    {
        Response.Redirect("CFS.aspx", true);
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        BindReports();
    }
    public string strDate(string strInDate)
    {
        string strDD = strInDate.Substring(0, 2);

        string strMM = strInDate.Substring(3, 2);

        string strYYYY = strInDate.Substring(6, 4);

        string strYYYYMMDD = strYYYY + "-" + strMM + "-" + strDD;

        //string strMMDDYYYY = strDD + "/" + strMM + "/" + strYYYY;

        DateTime dtConvertDate = Convert.ToDateTime(strYYYYMMDD);

        string strOutDate = dtConvertDate.ToString("yyyy-MM-dd");

        return strOutDate;
    }
}