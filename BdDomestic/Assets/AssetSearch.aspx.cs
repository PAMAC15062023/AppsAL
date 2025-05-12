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
using System.Text;
using System.Drawing;
using System.IO;
using System.Data.OleDb;

public partial class Assets_AssetSearch : System.Web.UI.Page
{
    CCommon objcon = new CCommon();
        protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnsearch_Click(object sender, EventArgs e)
    {
        if (txtname.Text == "" && txtbar.Text=="")
        {
            lblmsg.Visible = true;
            lblmsg.Text = "Please Enter Either Name or Barcode in Respective Textbox";
        }
         else if(txtname.Text!="" && txtbar.Text=="")
        {
            lblmsg.Visible = false;
            btnexport.Visible = true;
            string qry = "";
            DataTable dt = new DataTable();
            DataSet ds = new DataSet();
            qry = "Select * from asset_summary where name like '%" + txtname.Text + "%'";
            OleDbDataAdapter ol = new OleDbDataAdapter(qry, objcon.ConnectionString);
            ol.Fill(ds, "Search");
            dt = ds.Tables["Search"];
            if (dt.Rows.Count > 0)
            {
                grdvw.DataSource = dt;
                grdvw.DataBind();
                grdvw.Visible = true;
            }
            else
            {
                lblmsg.Text = "No Record Found";
                lblmsg.Visible = true;
            }
         }
        else if(txtname.Text=="" && txtbar.Text!="")
        {
            btnexport.Visible = true;
            string qry = "";
            DataTable dt = new DataTable();
            DataSet ds = new DataSet();
            qry = "Select * from asset_summary where barcode='" + txtbar.Text + "'";
            OleDbDataAdapter ol = new OleDbDataAdapter(qry, objcon.ConnectionString);
            ol.Fill(ds, "Search");
            dt = ds.Tables["Search"];
            if (dt.Rows.Count > 0)
            {
                grdvw.DataSource = dt;
                grdvw.DataBind();
                grdvw.Visible = true;
            }
            else
            {
                lblmsg.Text = "No Record Found";
                lblmsg.Visible = true;
            }
        }
            else if(txtname.Text!="" && txtbar.Text!="")
            {
                btnexport.Visible=true;
                string qry="";
                DataTable dt=new DataTable();
                DataSet ds=new DataSet();
                qry="Select * from asset_summary where name='" + txtname.Text + "' and barcode='" + txtbar.Text + "'";
                OleDbDataAdapter ol=new OleDbDataAdapter(qry,objcon.ConnectionString);
                ol.Fill(ds,"Search");
                dt=ds.Tables["Search"];
                if (dt.Rows.Count > 0)
                {
                    grdvw.DataSource = dt;
                    grdvw.DataBind();
                    grdvw.Visible = true;
                }
                else
                {
                    lblmsg.Visible = true;
                    lblmsg.Text = "No Record Found";
                }
            }
        }
    protected void btnClear_Click(object sender, EventArgs e)
    {
        txtname.Text = "";
        txtbar.Text = "";
        grdvw.Visible = false;
    }
    protected void btnexport_Click(object sender, EventArgs e)
    {
        if(txtname.Text=="" && txtbar.Text=="")
        {
            lblmsg.Visible = true;
            lblmsg.Text = "Please Enter Either Name or Barcode in Respective Textbox";
        }
        else if(txtname.Text!="" && txtbar.Text=="")
        {
            lblmsg.Visible = false;
            btnexport.Visible = true;
            string qry = "";
            DataTable dt = new DataTable();
            DataSet ds = new DataSet();
            qry = "Select * from asset_summary where name like '%" + txtname.Text + "%'";
            OleDbDataAdapter ol = new OleDbDataAdapter(qry, objcon.ConnectionString);
            ol.Fill(ds, "Search");
            dt = ds.Tables["Search"];
            if (dt.Rows.Count > 0)
            {
                grdvw.DataSource = dt;
                grdvw.DataBind();
                grdvw.Visible = true;
            }
            else
            {
                lblmsg.Text = "No Record Found";
                lblmsg.Visible = true;
            }
            if (grdvw.Rows.Count > 0)
            {
                String attachment = "attachment; filename=Asset Search MIS.xls";
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
                                "<b><font size='2'>PAMAC Asset Search MIS For Name:" + txtname.Text + " </font></b> <br/>";
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
            else
            {
                // lblMsg.Text = "No data to Export";
            }
        }
        else if(txtname.Text=="" && txtbar.Text!="")
        {
            
            btnexport.Visible = true;
            string qry = "";
            DataTable dt = new DataTable();
            DataSet ds = new DataSet();
            qry = "Select * from asset_summary where barcode='" + txtbar.Text + "'";
            OleDbDataAdapter ol = new OleDbDataAdapter(qry, objcon.ConnectionString);
            ol.Fill(ds, "Search");
            dt = ds.Tables["Search"];
            if (dt.Rows.Count > 0)
            {
                grdvw.DataSource = dt;
                grdvw.DataBind();
                grdvw.Visible = true;
            }
            else
            {
                lblmsg.Text = "No Record Found";
                lblmsg.Visible = true;
            }
            if (grdvw.Rows.Count > 0)
            {
                String attachment = "attachment; filename=Asset Search MIS.xls";
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
                                "<b><font size='2'>PAMAC Asset Search MIS For Barcode No:" + txtbar.Text + " </font></b> <br/>";
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
            else
            {
                // lblMsg.Text = "No data to Export";
            }
        }
        
            else if(txtname.Text!="" && txtbar.Text!="")
            {
                btnexport.Visible=true;
                string qry="";
                DataTable dt=new DataTable();
                DataSet ds=new DataSet();
                qry="Select * from asset_summary where name='" + txtname.Text + "' and barcode='" + txtbar.Text + "'";
                OleDbDataAdapter ol=new OleDbDataAdapter(qry,objcon.ConnectionString);
                ol.Fill(ds,"Search");
                dt=ds.Tables["Search"];
                if (dt.Rows.Count > 0)
                {
                    grdvw.DataSource = dt;
                    grdvw.DataBind();
                    grdvw.Visible = true;
                }
                else
                {
                    lblmsg.Visible = true;
                    lblmsg.Text = "No Record Found";
                }
                if (grdvw.Rows.Count > 0)
            {
                String attachment = "attachment; filename=Asset Search MIS.xls";
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
                                "<b><font size='2'>PAMAC Asset Search MIS For Name=" + txtname.Text + " and Barcode No:" + txtbar.Text + "</font></b> <br/>";
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
