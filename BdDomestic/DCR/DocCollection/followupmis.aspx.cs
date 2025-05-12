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
using System.Text;
using System.IO;
using System.Drawing;

public partial class followupmis : System.Web.UI.Page
{
    CCommon objcon = new CCommon();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (ddlProduct.Items.Count == 0)
        {
            products();
        }
        if (ddlclients.Items.Count == 1)
        {
            clients();
            
        }
        ////////if (ddlclients.Items.Count ==1)
        ////////{
        ////////    client();
        ////////}
    }
    protected void btnsearch_Click(object sender, EventArgs e)
    {
        fillgrid();
        grdlabel.Visible = true;
        grdlabel.Text = "Femu Detailed MIS";
    }
    protected void fillgrid()
    {
        string b="A";
        string c="B";
        string a = "D";
        string qry = "";
        DataTable dt = new DataTable();
        DataSet ds = new DataSet();
        //string fromdate = "";
        //string todate = "";
        //DateTime fromdate;
        //DateTime todate;
        if (txtFromDate.Text == "" || txtFromDate.Text == null)
        {
            lbl.Text = "Please Select Valid Date Range";
            lbl.Visible = true;
            txtFromDate.Focus();

        }
        //////////else
        //////////{
        //////////    fromdate = Convert.ToDateTime(objcon.strDate(txtFromDate.Text.Trim()));
        //////////}
        if (ddlclients.SelectedIndex == 0)
        {
            qry = "EXEC FOLLOWUPMIS2 '" + Convert.ToDateTime(objcon.strDate(txtFromDate.Text.Trim())) + "','" + b + " ','" + a + "' ,'','" + Session["CentreID"].ToString() + "','" + ddlProduct.SelectedItem.ToString() + "'";
            OleDbDataAdapter ol = new OleDbDataAdapter(qry, objcon.ConnectionString);
            ol.Fill(ds, "Search");
            dt = ds.Tables["Search"];
            if (dt.Rows.Count > 0)
            {
                grdvw.DataSource = dt;
                grdvw.DataBind();
                grdvw.Visible = true;
                lbl.Visible = false;
            }
            else
            {
                grdvw.Visible = false;
                lbl.Visible = true;
                lbl.Text = "No Record Found!!!";
            }
         }
        else
        {
            qry = "EXEC FOLLOWUPMIS2 '" + Convert.ToDateTime(objcon.strDate(txtFromDate.Text.Trim())) + "','" + c + " ','" + a + "' ,'" + ddlclients.SelectedValue.ToString() + "','" + Session["CentreID"].ToString() + "','" + ddlProduct.SelectedItem.ToString() + "'";
            OleDbDataAdapter ol = new OleDbDataAdapter(qry, objcon.ConnectionString);
            ol.Fill(ds, "Search");
            dt = ds.Tables["Search"];
            if (dt.Rows.Count > 0)
            {
                grdvw.DataSource = dt;
                grdvw.DataBind();
                grdvw.Visible = true;
                lbl.Visible = false;
            }
            else
            {
                grdvw.Visible = false;
                lbl.Visible = true;
                lbl.Text = "No Record Found!!!";      
            }
        }
    }

    protected void export_Click(object sender, EventArgs e)
    {
        fillgrid();
        if (grdvw.Rows.Count > 0)
        {
            String attachment = "attachment; filename=PAMAC FEMU FOLLOWUP MIS.xls";
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
                            "<b><font size='2'>PAMAC FEMU FOLLOWUP DETAILED MIS For Date : " + txtFromDate.Text + " </font></b> <br/>";
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
    public override void VerifyRenderingInServerForm(Control control)
    {

    }
    protected void fillgrid1()
    {
        string a = "S";
        string b = "A";
        string c = "B";
        string qry = "";
        DataTable dt = new DataTable();
        DataSet ds = new DataSet();
                
        if (ddlclients.SelectedIndex == 0)
            {
                qry = "EXEC FOLLOWUPMIS2 '" + Convert.ToDateTime(objcon.strDate(txtFromDate.Text.Trim())) + "','" + b + "','" + a + "','','" + Session["CentreID"].ToString() + "','"+ ddlProduct.SelectedItem.ToString() +"'";
                OleDbDataAdapter ol = new OleDbDataAdapter(qry, objcon.ConnectionString);
                ol.Fill(ds, "Search");
                dt = ds.Tables["Search"];
                if (dt.Rows.Count > 0)
                {
                    grdvw.DataSource = dt;
                    grdvw.DataBind();
                    grdvw.Visible = true;
                    lbl.Visible = false;
                }
                else
                {
                    grdvw.Visible = false;
                    lbl.Visible = true;
                    lbl.Text = "No Record Found!!!";
                }
            }
         else
            {
                qry = "EXEC FOLLOWUPMIS2 '" + Convert.ToDateTime(objcon.strDate(txtFromDate.Text.Trim())) + "','" + c + "','" + a + "','" + ddlclients.SelectedValue.ToString() + "','" + Session["CentreID"].ToString() + "','" + ddlProduct.SelectedItem.ToString() + "'";
                OleDbDataAdapter ol = new OleDbDataAdapter(qry, objcon.ConnectionString);
                ol.Fill(ds, "Search");
                dt = ds.Tables["Search"];
                if (dt.Rows.Count > 0)
                {
                    grdvw.DataSource = dt;
                    grdvw.DataBind();
                    grdvw.Visible = true;
                    lbl.Visible = false;
                }
                else
                {
                    grdvw.Visible = false;
                    lbl.Visible = true;
                    lbl.Text = "No Record Found!!!";
                }
            }
        }

    protected void btnSearchall_Click(object sender, EventArgs e)
    {
        fillgrid1();
        grdlabel.Visible = true;
        grdlabel.Text = "Femu Summary MIS";
    }

    protected void btnexportall_Click(object sender, EventArgs e)
    {
        fillgrid1();
        if (grdvw.Rows.Count > 0)
        {
            String attachment = "attachment; filename=PAMAC FEMU FOLLOWUP MIS.xls";
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
                            "<b><font size='2'>PAMAC FEMU FOLLOWUP SUMMARY MIS For Date : " + txtFromDate.Text + " </font></b> <br/>";
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

    protected void clients()
    {
        ddlclients.Items.Clear();
        ddlclients.Items.Add("----All Clients----");
        DataTable dt=new DataTable();
        DataSet ds=new DataSet();
        string qry="";
        qry = "Select client_id,client_name from CE_AC_PR_CT_VW where centre_id = '"+ Session["CentreId"].ToString() +"' and product_name = '"+ ddlProduct.SelectedItem.ToString() +"' order by client_name";
        OleDbDataAdapter ol=new OleDbDataAdapter(qry,objcon.ConnectionString);
        ol.Fill(ds,"Search");
        dt=ds.Tables["Search"];
        if (dt.Rows.Count > 0)
        {
            ddlclients.DataSource = dt;
            ddlclients.DataTextField = "Client_name";
            ddlclients.DataValueField = "Client_id";
            ddlclients.DataBind();
        }
        else
        {
        }
    }

    protected void products()
    {
        DataTable dt = new DataTable();
        DataSet ds = new DataSet();
        string qry = "";
        qry = "Select product_id,product_code from product_master where product_code not in ('BD','Asset','DIP Check','HR') order by product_code";
        OleDbDataAdapter ol = new OleDbDataAdapter(qry, objcon.ConnectionString);
        ol.Fill(ds, "Search");
        dt = ds.Tables["Search"];
        if (dt.Rows.Count > 0)
        {
            ddlProduct.DataSource = dt;
            ddlProduct.DataTextField = "Product_code";
            ddlProduct.DataValueField = "Product_id";
            ddlProduct.DataBind();
        }
        else
        {
        }
    }

    //////////protected void client()
    //////////{
    //////////    DataTable dt = new DataTable();
    //////////    DataSet ds = new DataSet();
    //////////    string qry = "";
    //////////    qry = "Select client_id,client_name from client_master order by client_name";
    //////////    OleDbDataAdapter ol = new OleDbDataAdapter(qry, objcon.ConnectionString);
    //////////    ol.Fill(ds, "Search");
    //////////    dt = ds.Tables["Search"];
    //////////    if (dt.Rows.Count > 0)
    //////////    {
    //////////        ddlclients.DataSource = dt;
    //////////        ddlclients.DataTextField = "Client_name";
    //////////        ddlclients.DataValueField = "Client_id";
    //////////        ddlclients.DataBind();

    //////////    }
    //////////    else
    //////////    {
    //////////    }
    //////////}

    protected void ddlProduct_SelectedIndexChanged(object sender, EventArgs e)
    {
        clients();
    }
}
