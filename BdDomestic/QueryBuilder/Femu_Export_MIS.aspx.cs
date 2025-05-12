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
using System.Configuration.Assemblies;
using CrystalDecisions.Shared;
using CrystalDecisions.CrystalReports.ViewerObjectModel;


public partial class Femu_Export_MIS : System.Web.UI.Page
{
    DateTime dtfrom;
    DateTime dtto;
    string Fdate;
    string Tdate;
    CCommon objcon = new CCommon();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Context.Request.QueryString["FromDate"] != null && Context.Request.QueryString["FromDate"] != " " || Context.Request.QueryString["ToDate"] != null && Context.Request.QueryString["ToDate"] != "")
            {
                //scaseid = Request.QueryString["CaseID"].ToString();
                Fdate = Request.QueryString["FromDate"].ToString();
                Tdate = Request.QueryString["ToDate"].ToString();
                txtFromDate.Text = Fdate;
                txtToDate.Text = Tdate;
            }
        }

    }
    protected void btnsearch_Click(object sender, EventArgs e)
    {
        bool isvalid = true;
        if (txtFromDate.Text == "")
        {
            isvalid = false;
            lblMessage.Visible = true;
            lblMessage.Text = "Please Enter The Valid Date.";
            lblMessage.ForeColor = System.Drawing.Color.Red;
            lblMessage.Font.Bold = true;
        }
        if (txtFromDate.Text != "")
        {
            dtfrom = Convert.ToDateTime(objcon.strDate(txtFromDate.Text.Trim()));
        }
        if (isvalid == true)
        {
            lblMessage.Text = "";
            getsearch();
        }
    }
    protected void getsearch()
    {
        DataTable dt = new DataTable();
        dt = getcases();
        if (dt.Rows.Count > 0)
        {
            grdvw.DataSource = dt;
            grdvw.DataBind();
            tblExport.Visible = true;
            grdvw.Visible = true;
        }
        else
        {

            tblExport.Visible = false;
            grdvw.Visible = false;
            lblMessage.Text = "Records Not Found!!!!!";
            lblMessage.Visible = true;

        }
    }
    private string Get_DateFormat(string cDate, string cDateFormat)
    {
        try
        {
            string strDate = cDate;
            string[] strArrDate = strDate.Split('/');

            if (strArrDate.Length > 0)
            {
                if (cDateFormat == "yyyy/MM/dd")
                {
                    strDate = strArrDate[2] + "/" + strArrDate[1] + "/" + strArrDate[0];

                }
                else if (cDateFormat == "yyyyMMdd")
                {
                    strDate = strArrDate[2] + strArrDate[1] +  strArrDate[0];

                }
            }
                        return strDate;
        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
            lblMessage.CssClass = "ErrorMessage";
            lblMessage.Visible = true;
            return "";
        }

    }
    protected DataTable getcases()
    {
        string qry = "";
        DataTable dtsearch = new DataTable();
        

        //qry = "EXEC Get_QC_Case_Mis '" + Convert.ToDateTime(objcon.strDate(txtFromDate.Text.Trim())).ToString("dd-MMM-yyyy") + "', '" + Convert.ToDateTime(objcon.strDate(txtToDate.Text.Trim())).ToString("dd-MMM-yyyy") + "', '" + ddlCenter.SelectedValue.ToString() + "'";
        qry = "EXEC Get_FEMU_Record_By_Field '" + Get_DateFormat(txtFromDate.Text.Trim(), "yyyyMMdd") + "', '" + Get_DateFormat(txtToDate.Text.Trim(), "yyyyMMdd") + "','" + ddlprduct1.SelectedValue.ToString() + "','" + ddlVeriType.SelectedValue.ToString() + "'";
        OleDbDataAdapter oleda = new OleDbDataAdapter(qry, objcon.ConnectionString);
        DataSet da = new DataSet();
        oleda.Fill(da, "Search");
        dtsearch = da.Tables["Search"];
        return dtsearch;
    }
    protected void btnExport_Click(object sender, EventArgs e)
    {
        //GridView1.Visible = true;
        //string attachment = "attachment; filename=QcCentreClientWiseMIS.xls";
        //Response.ClearContent();
        //Response.AddHeader("content-disposition", attachment);
        //Response.ContentType = "application/ms-excel";
        //StringWriter sw = new StringWriter();

        //HtmlTextWriter htw = new HtmlTextWriter(sw);
        //GridView1.RenderControl(htw);
        //Response.Write(sw.ToString());
        //Response.End(); 

        String attachment = "attachment; filename=FemuReport.xls";
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
                        "<b><font size='2'>PAMAC FEMU REPORT MIS For Date : " + txtFromDate.Text + " </font></b> <br/>";
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
        tblExport.RenderControl(htw);
        Response.Write(sw.ToString());

        Response.End();

    
    }

    public override void VerifyRenderingInServerForm(Control control)
    {

    }
    
}
