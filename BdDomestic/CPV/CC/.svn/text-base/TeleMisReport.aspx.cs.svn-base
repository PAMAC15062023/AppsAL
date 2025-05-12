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
using Microsoft.Office.Core;
using CrystalDecisions.Shared;
using System.Configuration.Assemblies;

public partial class CPV_CC_TeleMisReport : System.Web.UI.Page
{
    CCommon objcon = new CCommon();
    DateTime dtfrom;
    DateTime dtto;
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {

        }
    }




       
        
       
       
    private DataTable getsearch()
    {
        DataTable dt = new DataTable();
        DataSet ds = new DataSet();
        string qry = "";
         DateTime frdate;
        DateTime todate;
        //OleDbDataReader oleDR;
        
        frdate = Convert.ToDateTime(objcon.strDate(txtFDate.Text.Trim()));
        todate = Convert.ToDateTime(objcon.strDate(txtTDate.Text.Trim()));

         qry = "exec telereport '" + frdate + "','" + todate + "'";
       // qry = "SELECT TELECALLER,COMPLETE,POSITIVE,NEGATIVE,OTHER FROM DK5 where date_time >='" + dtfrom + "' and date_time <'" + dtto + "'";
             //oleDR = OleDbHelper.ExecuteReader(objcon.ConnectionString, CommandType.StoredProcedure, qry);
         OleDbDataAdapter ola = new OleDbDataAdapter(qry, objcon.ConnectionString);
         ola.Fill(ds, "telereport");
         dt = ds.Tables["telereport"];
         return dt;
        //return oleDR;
    }
    //private void binddata()
    //{
    //    try
    //    {
    //        //dtfrom = objcon.strDate(txtFDate.Text.ToString());
    //        //dtto = objcon.strDate(txtTDate.Text.ToString());
    //    }
    //    catch
    //    {
    //        lblMessage.Text = "Please Enter The Valid Date Range";
    //        return;
    //    }
    //    btnExport.Enabled = true;
    //    OleDbDataReader bindreader;
    //    bindreader = getsearch();
    //    DataTable dt = new DataTable();
    //    DataColumn dc = new DataColumn();
    //    dc = new DataColumn("Sr No.", typeof(System.String));
    //    dt.Columns.Add(dc);
    //    dc = new DataColumn("Telecaller Name", typeof(System.String));
    //    dt.Columns.Add(dc);
    //    dc = new DataColumn("Case Completed", typeof(System.String));
    //    dt.Columns.Add(dc);
    //    dc = new DataColumn("Positive", typeof(System.String));
    //    dt.Columns.Add(dc);
    //    dc = new DataColumn("Negative", typeof(System.String));
    //    dt.Columns.Add(dc);
    //    dc = new DataColumn("Other", typeof(System.String));
    //    dt.Columns.Add(dc);
    //    int i = 0;
    //    int j = 0;
    //    int sno = 1;
    //    string tcid = "";
    //    DataRow dr;
    //    dr = dt.NewRow();
    //    string colval;
    //    while (bindreader.Read())
    //    {
    //        dr["Sr No."] = sno;
    //        dr["Telecaller Name"] = bindreader["Telecaller"];
    //        dr["Case Completed"] = bindreader["complete"];
    //        dr["Positive"] = bindreader["Positive"];
    //        dr["Negative"] = bindreader["Negative"];
    //        dr["Other"] = bindreader["other"];
    //        dt.Rows.Add(dr);
    //        dt.Rows.Add();
    //        dr = dt.NewRow();
    //        sno++;

    //    }
    //    GvTele.DataSource = dt;
    //    GvTele.DataBind();

   // }
    protected void getdata()
    {
        DataTable dt1 = new DataTable();
        dt1 = getsearch();
        if (dt1.Rows.Count > 0)
        {
            GvTele.DataSource = dt1;
            GvTele.DataBind();
            GvTele.Visible = true;
        }
        else
        {
            lblMessage.Visible = true;
            lblMessage.Text = "Record Not Found!!!!!!!!";
            GvTele.Visible = false;

        }
    }
    protected void btnsearch_Click(object sender, EventArgs e)
    {
        bool isvalid = true;
        if (txtFDate.Text == "" && txtTDate.Text == "")
        {
            isvalid = false;
            lblMessage.Visible = true;
            lblMessage.Text = "Please Enter The valid Date Range!!!!!";
            lblMessage.ForeColor = System.Drawing.Color.Red;
            lblMessage.Font.Bold=true;
        }
        if (txtFDate.Text != "" && txtTDate.Text != "")
        {
            dtfrom = Convert.ToDateTime(objcon.strDate(txtFDate.Text.Trim().ToString()));
            dtto = Convert.ToDateTime(objcon.strDate(txtTDate.Text.Trim().ToString()));
            if(dtfrom > dtto)
            {
                isvalid=false;
                lblMessage.Visible=true;
                lblMessage.Text="From Date Must be less Than To Date";

            }
        }
        if (isvalid == true)
        {
            lblMessage.Text = "";
            getdata();
        }
    }
    protected void btnExport_Click(object sender, EventArgs e)
    {

        getdata();
        string strCentre;

        if (GvTele.Rows.Count > 0)
        {
            String attachment = "attachment; filename=Tele Decline Report.xls";
            Response.ClearHeaders();
            Response.ClearContent();
            Response.Clear();
            Context.Response.AddHeader("content-disposition", attachment);
            //Response.AddHeader("content-disposition", attachment);
            Context.Response.ContentType="application/vnd.ms-excel";
           // context.Response.ContentType = "application/ms-excel";
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
                //                            "<b><font size='3'>Daily Attendance Tracking</font></b> <br/>" +
                            "<b><font size='2'>Tele Decline MIS FROM : " + dtfrom + "  TO : " + dtto + "  </font></b> <br/><br/><br/>";
            //                            "<b><font size='2'>Period From : " + dr.FromDt + " To: " + dr.ToDt + " </font></b> <br/>";
            //                            "<b><font size='2'>PERIOD FROM : " + dr.FromDt + "  TO : " + dr.ToDt + "  " + lblMessage + "  </font></b> <br/>";
            //tblCell1.CssClass = "FormHeading";
            tblRow.Cells.Add(tblCell);
            tblRow1.Cells.Add(tblCell1);
            tblRow.Height = 20;
            tblSpace.Rows.Add(tblRow);
            tblSpace.Rows.Add(tblRow1);
            tblSpace.RenderControl(htw);
            Table tbl = new Table();
            GvTele.GridLines = GridLines.Both;
            GvTele.EnableViewState = false;
            GvTele.RenderControl(htw);
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
}
