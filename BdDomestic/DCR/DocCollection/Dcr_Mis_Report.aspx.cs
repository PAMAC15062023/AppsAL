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
using System.Drawing;
using System.IO;
using System.Text;
using System.Data.SqlClient;

public partial class DcrMIS : System.Web.UI.Page
{
    CCommon objcon = new CCommon();
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnsearch_Click(object sender, EventArgs e)
    {
        fillgrid();
    }
    //protected void grdvw_PageIndexChanging(object sender, GridViewPageEventArgs e)
    //{
    //    grdvw.PageIndex = e.NewPageIndex;
    //    fillgrid();
    //}
    protected void export_Click(object sender, EventArgs e)
    {
        fillgrid();
        if (grdvw.Rows.Count > 0)
        {
            String attachment = "attachment; filename=PAMAC DCR MIS.xls";
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
            tblCell1.Text = "<b><font size='3'>PAMAC FINSERVE PVT. LTD., MUMBAI</font></b> <br/>" +
                            "<b><font size='2'>PAMAC DCR MIS FromDate : " + txtFromDate.Text + " ToDate " + txtFromDate.Text + " And VerificationType = " + ddlVeriType.SelectedItem + "</font></b> <br/>";
            tblCell1.CssClass = "FormHeading";
            tblRow.Cells.Add(tblCell);
            tblRow1.Cells.Add(tblCell1);
            tblRow.Height = 20;
            tblSpace.Rows.Add(tblRow);
            tblSpace.Rows.Add(tblRow1);
            tblSpace.RenderControl(htw);

            Table tbl = new Table();
            grdvw.EnableViewState = false;
            grdvw.GridLines = GridLines.Both;
            grdvw.RenderControl(htw);
            Response.Write(sw.ToString());

            Response.End();
        }
    }
    protected void fillgrid()
    {
        DataTable dt = new DataTable();
        DataSet ds = new DataSet();
        string qry = "";
        int VeriType = 0;

        if (ddlVeriType.SelectedValue != "(All)")
        {
            VeriType = Convert.ToInt32(ddlVeriType.SelectedValue);
        }

        qry = "EXEC DcrMis_Report " + Session["ClientID"].ToString()  + ",'" + txtFromDate.Text.Trim()  + "', '" + txtToDate.Text.Trim()  + "', " + VeriType + "";    
        OleDbDataAdapter ol = new OleDbDataAdapter(qry, objcon.ConnectionString);
        ol.Fill(ds, "Search");
        dt = ds.Tables["Search"];
        if (dt.Rows.Count > 0)
        {
            grdvw.DataSource = dt;
            grdvw.DataBind();
            grdvw.Visible = true;
            lblmsg.Text = "";
        }

        else
        {
            lblmsg.Text = "No Record Found";
            grdvw.Visible = false;
            lblmsg.Visible = true;
        }
    }
    public override void VerifyRenderingInServerForm(Control control)
    {

    }
}
