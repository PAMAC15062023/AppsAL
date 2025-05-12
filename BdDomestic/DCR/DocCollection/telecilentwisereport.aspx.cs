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

public partial class CPV_CC_telecilentwisereport : System.Web.UI.Page
{
    CCommon objcon = new CCommon();
    DateTime dtfrom;
    DateTime dtto;
    protected void Page_Load(object sender, EventArgs e)
    {
        txtFromDate.Focus();
    }
 public DataTable getsearch()
    {
        DataTable dt = new DataTable();
        DataSet ds = new DataSet();
        string qry = "";
        DateTime frdate;
        DateTime todate;
        frdate = Convert.ToDateTime(objcon.strDate(txtFromDate.Text.Trim()));
        todate = Convert.ToDateTime(objcon.strDate(txtToDate.Text.Trim()));

        qry = "exec CLIENT_WISE_TC_CASES '" + frdate + "','" + todate + "'";
        OleDbDataAdapter ol = new OleDbDataAdapter(qry, objcon.ConnectionString);
        ol.Fill(ds, "Search");
        dt = ds.Tables["Search"];
        return dt;
          }
    protected void btnsearch_Click(object sender, EventArgs e)
    {
        bool isvalid = true;
        if (txtFromDate.Text.Trim() == "" || txtToDate.Text.Trim() == "")
        {
            lblmsg.Visible = true;
            lblmsg.Text = "Please Select the valid Date Range";
            lblmsg.ForeColor = System.Drawing.Color.Red;
            lblmsg.Font.Bold = true;
        }
        if (txtFromDate.Text.Trim() != "" && txtToDate.Text.Trim() != "")
        {

            dtfrom = Convert.ToDateTime(objcon.strDate(txtFromDate.Text.Trim().ToString()));
            dtto=Convert.ToDateTime(objcon.strDate(txtToDate.Text.Trim().ToString()));

            if (dtfrom > dtto)
            {
                lblmsg.Visible = true;
                lblmsg.Text = "From Date cannot be less than To Date";
                lblmsg.ForeColor = System.Drawing.Color.Red;
                lblmsg.Font.Bold = true;
            }
        }
        if (isvalid == true)
        {
           
            string todate;
            //CReport crt = new CReport();
            DataTable  dset = new DataTable();
            dset=getsearch();
            
            if (dset.Rows.Count > 0)
            {
                GridView.DataSource=dset;
                GridView.DataBind();
                GridView.Visible = true;
                    
             }
                
                //dset.Tables[0].TableName = "TeleReport";
                //Session["dataset"] = dset;
                //Session["Path"] = Server.MapPath("telereport.rpt");
                //Session.Remove("ParameterCollection");
                //Response.Redirect("../../CrystalReportviewer.aspx?bckPgURL=CPV\\CC\\telecilentwisereport.aspx");

            }
            else
            {
                lblmsg.Visible = true;
                lblmsg.Text = "No Record Found...";
                lblmsg.ForeColor = System.Drawing.Color.Red;
                lblmsg.Font.Bold = true;
            }
        }
    protected void cmdExcel_Click(object sender, EventArgs e)
    {
        DataTable dset = new DataTable();
        dset = getsearch();

        if (dset.Rows.Count > 0)
        {
            GridView.DataSource = dset;
            GridView.DataBind();
            GridView.Visible = true;
           if (GridView.Rows.Count > 0)
           {
               String attachment = "attachment; filename=PAMAC Client Wise Tele MIS.xls";
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
                               "<b><font size='2'>PAMAC Client Wise Tele MIS From " + txtFromDate.Text + " To " + txtToDate.Text+ " :  </font></b> <br/>";
               tblCell1.CssClass = "FormHeading";
               tblRow.Cells.Add(tblCell);
               tblRow1.Cells.Add(tblCell1);
               tblRow.Height = 20;
               tblSpace.Rows.Add(tblRow);
               tblSpace.Rows.Add(tblRow1);
               tblSpace.RenderControl(htw);

               Table tbl = new Table();
               GridView.EnableViewState = false;
               GridView.GridLines = GridLines.Both;
               GridView.RenderControl(htw);
               Response.Write(sw.ToString());
               Response.End();
           }
           else
           {

           }
        }
    }
    public override void VerifyRenderingInServerForm(Control control)
    {

    }
}
