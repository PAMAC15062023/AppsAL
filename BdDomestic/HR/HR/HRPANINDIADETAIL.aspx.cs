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
using System.IO;
using System.Drawing;

public partial class HR_HR_HRPANINDIADETAIL : System.Web.UI.Page
{
    CCommon objcon = new CCommon();
    DataTable dtcentre = new DataTable();
    string a, b;
    string flag;
    string mon;
    string paidon;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            dtcentre = centre();
            ddlcentre.DataSource = dtcentre;
            ddlcentre.DataTextField = "Centre_name";
            ddlcentre.DataValueField = "centre_id";
           
            ddlcentre.DataBind();
                    

            if (ddlyear.Items.Count == 0)
            {
                getyear();
            }
        }    
    }
    protected DataTable fillyear()
    {
        DataTable dt = new DataTable();
        DataSet ds = new DataSet();
        string qry = "";
        qry = " select substring(convert(varchar(11),getdate(),113),7,8) -1  as year union select substring(convert(varchar(11),getdate(),113),7,8) as year " +
            " Union select substring(convert(varchar(11),getdate(),113),7,8) + 1 as year";
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
    protected DataTable centre()
    {

        DataTable dt = new DataTable();
        DataSet ds = new DataSet();
        string qry = "";
        qry = "Select centre_id,centre_name from centre_master order by centre_name";
        OleDbDataAdapter ol = new OleDbDataAdapter(qry, objcon.ConnectionString);
        ol.Fill(ds, "Search");
        dt = ds.Tables["Search"];
        return dt;


    }
    protected DataTable allcentre()
    {
        DataTable dt = new DataTable();
        DataSet ds = new DataSet();
        flag = a;
        string qry = "";
        qry = "Exec HRCPAPANINDIADETAIL '','" + ddlmonth.SelectedValue + ' ' + ddlyear.SelectedValue + "','a'";
        OleDbDataAdapter ol = new OleDbDataAdapter(qry, objcon.ConnectionString);
        ol.Fill(ds, "Search");
        dt = ds.Tables["Search"];
        return dt;
    }
    protected void allcentre1()
    {
        DataTable dt = new DataTable();
        dt = allcentre();
        if (dt.Rows.Count > 0)
        {
            gvmis.DataSource = dt;
            gvmis.DataBind();
            gvmis.Visible = true;

        }
        else
        {
            lblmsg.Visible = true;
            lblmsg.Text = "No Record Found for This Yearmonth";
        }

    }
    protected DataTable centre2()
    {
        flag = b;
        string x = ddlcentre.SelectedItem.ToString();
        DataTable dt = new DataTable();
        DataSet ds = new DataSet();
        string qry = "";
        qry = "Exec HRCPAPANINDIADETAIL '" + x + "','" + ddlmonth.SelectedValue + ' ' + ddlyear.SelectedValue + "','b'  ";
        OleDbDataAdapter ol = new OleDbDataAdapter(qry, objcon.ConnectionString);
        ol.Fill(ds, "Search");
        dt = ds.Tables["Search"];
        return dt;
    }
    protected void centre1()
    {
        DataTable dt = new DataTable();
        dt = centre2();
        if (dt.Rows.Count > 0)
        {
            gvmis.Visible = true;
            gvmis.DataSource = dt;
            gvmis.DataBind();
        }
        else
        {
            lblmsg.Visible = true;
            lblmsg.Text = "No Record Found for This Yearmonth and Centre";
        }
    }
    protected void btnreport_Click(object sender, EventArgs e)
    {
        if (ddlmonth.SelectedIndex == 0)
        {
            lblmsg.Visible = true;
            lblmsg.Text = "Please Select The Month";
        }
        else
        {
            if (ddlcentre.SelectedIndex == 0)
            {
                allcentre1();
            }
            else
            {
                centre1();
            }
        }
    }
    protected void Export_Click(object sender, EventArgs e)
    {
        if (ddlcentre.SelectedIndex == 0)
        {
            allcentre1();
            if (gvmis.Rows.Count > 0)
            {
                String attachment = "attachment; filename=PAMAC CPA PAN INDIA STAFF DETAILS.xls";
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
                                "<b><font size='2'>PAMAC CPAN PAN INDIA STAFF DETAILS FOR : " + ddlmonth.SelectedValue + ' ' + ddlyear.SelectedValue + " And " + ddlcentre.SelectedItem + " </font></b> <br/>";
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
        }
        else
        {
            centre1();

            if (gvmis.Rows.Count > 0)
            {
                String attachment = "attachment; filename=PAMAC CPA PAN INDIA STAFF DETAILS.xls";
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
                                "<b><font size='2'>PAMAC CPA PAN INDIA DETAILS FOR : " + ddlmonth.SelectedValue + ' ' + ddlyear.SelectedValue + " And " + ddlcentre.SelectedItem + " </font></b> <br/>";
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
    }
    public override void VerifyRenderingInServerForm(Control control)
    {

    }
}
