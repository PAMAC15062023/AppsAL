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

public partial class TestMis : System.Web.UI.Page
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
            String attachment = "attachment; filename=PAMAC FEMU MIS.xls";
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
                            "<b><font size='2'>PAMAC FEMU MIS For Date : " + txtFromDate.Text + " </font></b> <br/>";
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
        string date = "";
        date = Convert.ToDateTime(objcon.strDate(txtFromDate.Text.Trim())).ToString("dd/MM/yyyy");
        string qry = "";
        qry = " select uname as [User Name],emp_code as [Employee Code],isnull(firstname,'')+' '+isnull(middlename,'')+' '+isnull(lastname,'') as [Employee Name],login_date as [Login Date/Time] from test a,user_master b,employee_master c where a.uname=b.loginname and a.uname=(left(emp_code,1)+substring(emp_code,3,7)) and b.userid=c.emp_id and CONVERT(VARCHAR(10),login_date,103) = '" + date + "' order by isnull(firstname,'')+' '+isnull(middlename,'')+' '+isnull(lastname,''),login_date  ";
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
