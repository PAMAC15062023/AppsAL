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
using System.Drawing;
using System.Data.OleDb;
using System.IO;

public partial class HR_HR_PAMACHRPANCCARDDETAIL : System.Web.UI.Page
{
    CCommon objcon = new CCommon();
    string qry = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (ddlreport.Items.Count == 0)
        {
            ddlreport.SelectedIndex=0;
        }
    }

    protected DataTable pancard()
    {
        DataTable dt = new DataTable();
        DataSet ds = new DataSet();
        qry = "EXEC HRPANCARDDETAIL";
        OleDbDataAdapter Odt = new OleDbDataAdapter(qry, objcon.ConnectionString);
        Odt.Fill(ds, "Search");
       dt= ds.Tables["Search"];
        return dt;
    }
    protected DataTable account()
    {
        DataTable dt = new DataTable();
        DataSet ds = new DataSet();
        qry = "EXEC PAMACHRACCOUNTDETAIL";
        OleDbDataAdapter odt = new OleDbDataAdapter(qry, objcon.ConnectionString);
        odt.Fill(ds, "Search");
        dt = ds.Tables["Search"];
        return dt;
    }
    protected void acc()
    {
        DataTable dt = new DataTable();
        dt = account();
        if (dt.Rows.Count > 0)
        {
            gvmis.DataSource = dt;
            gvmis.DataBind();
            gvmis.Visible = true;
        }
        else
        {
            gvmis.Visible = false;
                lblmsg.Visible = false;
                lblmsg.Text = "No Record Found";
       
        }
    }
    protected void pan()
    {
        DataTable dt = new DataTable();
        dt = pancard();
        if (dt.Rows.Count > 0)
        {
            gvmis.Visible = true;
            gvmis.DataSource = dt;
            gvmis.DataBind();

        }
        else
        {
            gvmis.Visible = false;
            lblmsg.Visible = true;
            lblmsg.Text = "NO Record Found";
        }
    }

    protected void btnreport_Click(object sender, EventArgs e)
    {
        if (ddlreport.SelectedIndex == 0)
        {
            lblmsg.Text = "Please select atleast one Report type ";
                lblmsg.Visible=true;
        }
        else
        {
            lblmsg.Visible = false;
            if (ddlreport.SelectedIndex == 1)
            {
                pan();
            }
            else
            {
                acc();
                qry = "drop table acc_det";
                OleDbDataReader odr = OleDbHelper.ExecuteReader(objcon.ConnectionString, CommandType.Text, qry);



            }
        }
    }
    protected void Export_Click(object sender, EventArgs e)
    {
        if(ddlreport.SelectedIndex==1)
        {
            pan();
        if (gvmis.Rows.Count > 0)
        {
            String attachment = "attachment; filename=PAMAC HR PAN CARD DETAIL MIS .xls";
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
                            "<b><font size='2'>PAMAC HR PAN CARD DETAIL MIS </font></b> <br/>";
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
        else
        {
            acc();
            if (gvmis.Rows.Count > 0)
            {
                String attachment = "attachment; filename=PAMAC HR ACCOUNTS DETAIL MIS .xls";
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
                                "<b><font size='2'>PAMAC HR ACCOUNTS DETAIL MIS </font></b> <br/>";
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
