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

public partial class HR_HR_PAMACHEADCOUNT : System.Web.UI.Page
{
    CCommon objcon = new CCommon();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

        }
        if (ddlyear.Items.Count == 0)
        {
            getyear();
        }
    }

    protected DataTable fillyear()
    {
        DataTable dt = new DataTable();
        DataSet ds = new DataSet();
        string qry = "";
        qry = " Exec SELECT_YEAR";
        OleDbDataAdapter ole = new OleDbDataAdapter(qry, objcon.ConnectionString);
        ole.Fill(ds, "Search");
        dt = ds.Tables["Search"];
        return dt;
    }
    protected void getyear()
    {
        DataTable dt = new DataTable();
        dt = fillyear();
        if (dt.Rows.Count > 0)
        {
            ddlyear.DataSource = dt;
            ddlyear.DataTextField = "year";
            ddlyear.DataValueField = "year";
            ddlyear.DataBind();
        }
    }
    protected DataTable getreport()
    {
        OleDbDataReader dr;
        DataTable dt = new DataTable();
        DataSet ds = new DataSet();
        object c,d;
        string a,b;
        string qry = "";
        qry = "select left('" + ddlyear.SelectedValue + "',4)";
        c = OleDbHelper.ExecuteScalar(objcon.ConnectionString, CommandType.Text, qry);
        a = c.ToString();
        qry = "select right('" + ddlyear.SelectedValue + "',4)";
        d = OleDbHelper.ExecuteScalar(objcon.ConnectionString, CommandType.Text, qry);
        b= d.ToString();
        qry = "exec PAMACHRHEADCOUNT '" + a + "','" + b + "'";
        OleDbDataAdapter ol = new OleDbDataAdapter(qry, objcon.ConnectionString);
        ol.Fill(ds, "Search");
        dt = ds.Tables["Search"];
        return dt;
    }
    protected void getreport1()
    {
        DataTable dt = new DataTable();
        dt = getreport();
        if (dt.Rows.Count > 0)
        {
            gvmis.DataSource = dt;
            gvmis.DataBind();
            gvmis.Visible = true;
        }
        else
        {
            gvmis.Visible = false;
        }

    }

    protected void Export_Click(object sender, EventArgs e)
    {
        getreport1();
            if (gvmis.Rows.Count > 0)
            {
                String attachment = "attachment; filename=PAMAC HR Head Count.xls";
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
                                "<b><font size='2'>PAMAC HR Head Count FOR Financial Year : " + ddlyear.SelectedValue + " </font></b> <br/>";
                tblCell1.CssClass = "FormHeading";
                tblRow.Cells.Add(tblCell);
                tblRow1.Cells.Add(tblCell1);
                tblRow.Height = 20;
                tblSpace.Rows.Add(tblRow);
                tblSpace.Rows.Add(tblRow1);
                tblSpace.RenderControl(htw);

                Table tbl = new Table();
                gvmis.EnableViewState = false;
                gvmis.GridLines = GridLines.Both;
                gvmis.RenderControl(htw);
                Response.Write(sw.ToString());

                Response.End();

            }
        
       
            else
            {
                // lblMsg.Text = "No data to Export";
            }
       
}
    public override void VerifyRenderingInServerForm(Control control)
    {

    }
      
    
    protected void btnreport_Click(object sender, EventArgs e)
    {
        getreport1();
    }
}
