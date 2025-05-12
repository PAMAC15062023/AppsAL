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


public partial class QueryBuilder_RejectCaseMIS : System.Web.UI.Page
{
    CCommon objcon = new CCommon();
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    
    protected void fillgrid()
    {
        string qry = "";
        DataTable dt = new DataTable();
        DataSet ds = new DataSet();
        string fromdate = "";
        string todate = "";
        //DateTime fromdate;
        //DateTime todate;
        if (txtFromDate.Text == "" || txtFromDate.Text == null && txtToDate.Text == "" || txtToDate.Text == null)
        {
            lblMsg.Text = "Please Select Valid Date Range";
            lblMsg.Visible = true;
            txtFromDate.Focus();
        }
        else
        {
            if (txtFromDate.Text.Trim() != "")
                fromdate = Convert.ToDateTime(objcon.strDate(txtFromDate.Text.Trim())).ToString("dd/MM/yyyy");
            /////////////////////fromdate = Convert.ToDateTime(objcon.strDate1(txtFromDate.Text.Trim())).ToString("yyyy-MM-dd");
            if (txtToDate.Text.Trim() != "")
                todate = Convert.ToDateTime(objcon.strDate(txtToDate.Text.Trim())).ToString("dd/MM/yyyy");
            //////////////////////////todate = Convert.ToDateTime(objcon.strDate1(txtToDate.Text.Trim())).ToString("yyyy-MM-dd");
            string product = "";
            if (ddlProduct.SelectedValue != "")
            {
                product = ddlProduct.SelectedItem.ToString();
                if (product == "CC")
                {
                    qry = "select ref_no as RefNo,a.CASE_ID as CaseID,VERIFICATION_TYPE_Code,Client_name, Fe_Response, Why_Rejected, Reason, max(date_time)as 'Date_Time', product_name,isnull(firstname,'')+' '+isnull(middlename,'')+' '+isnull(lastname,'') as Fe_name from case_reject a, employee_master b, cpv_CC_case_details c, verification_type_master d, client_master e where a.case_id = c.case_id and a.verification_type_id = d.verification_type_id and a.fe_id = b.emp_id and c.client_id = e.client_id and convert(varchar(10),case_rec_datetime,103) >= '" + fromdate + "' AND convert(varchar(10),case_rec_datetime,103) <= '" + todate + "' and product_name='" + ddlProduct.SelectedItem + "' group by ref_no, a.case_id, VERIFICATION_TYPE_Code,Client_name, Fe_Response, Why_Rejected, Reason, product_name,isnull(firstname,'')+' '+isnull(middlename,'')+' '+isnull(lastname,''),c.case_rec_datetime order by date_time desc ";
                }
                if (product == "KYC")
                {
                    qry = "select distinct ref_no as RefNo,a.CASE_ID as CaseID,VERIFICATION_TYPE_Code,Client_name, Fe_Response, Why_Rejected, Reason, max(date_time)as 'Date_Time', product_name,isnull(firstname,'')+' '+isnull(middlename,'')+' '+isnull(lastname,'') as Fe_name from case_reject a, employee_master b, cpv_KYC_case_details c, verification_type_master d, client_master e where a.case_id = c.case_id and a.verification_type_id = d.verification_type_id and a.fe_id = b.emp_id and c.client_id = e.client_id and convert(varchar(10),case_rec_datetime,103) >= '" + fromdate + "' AND convert(varchar(10),case_rec_datetime,103) <= '" + todate + "' and product_name='" + ddlProduct.SelectedItem + "' group by ref_no, a.case_id, VERIFICATION_TYPE_Code,Client_name, Fe_Response, Why_Rejected, Reason, product_name,isnull(firstname,'')+' '+isnull(middlename,'')+' '+isnull(lastname,''),c.case_rec_datetime order by date_time desc ";
                }
                if (product == "RL")
                {
                    qry = "select distinct ref_no as RefNo,a.CASE_ID as CaseID,VERIFICATION_TYPE_Code,Client_name, Fe_Response, Why_Rejected, Reason, max(date_time)as 'Date_Time', a.product_name,isnull(firstname,'')+' '+isnull(middlename,'')+' '+isnull(lastname,'') as Fe_name from case_reject a, employee_master b, CPV_RL_CASE_DETAILS c, verification_type_master d, client_master e where a.case_id = c.case_id and a.verification_type_id = d.verification_type_id and a.fe_id = b.emp_id and c.client_id = e.client_id and convert(varchar(10),case_rec_datetime,103) >= '" + fromdate + "' AND convert(varchar(10),case_rec_datetime,103) <= '" + todate + "' and a.product_name='" + ddlProduct.SelectedItem + "' group by ref_no, a.case_id, VERIFICATION_TYPE_Code,Client_name, Fe_Response, Why_Rejected, Reason, a.product_name,isnull(firstname,'')+' '+isnull(middlename,'')+' '+isnull(lastname,''),c.case_rec_datetime order by date_time desc ";
                }
                OleDbDataAdapter ol = new OleDbDataAdapter(qry, objcon.ConnectionString);
                ol.Fill(ds, "Search");
                dt = ds.Tables["Search"];
                if (dt.Rows.Count > 0)
                {
                    GridView1.DataSource = dt;
                    GridView1.DataBind();
                    GridView1.Visible = true;
                }
                else
                {
                    GridView1.Visible = false;
                    lblMsg.Visible = true;
                    lblMsg.Text = "No Record Found!!!";

                }
            }
         }
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        fillgrid();
    }
    protected void Btnexport_Click(object sender, EventArgs e)
    {
        {
            fillgrid();
            if (GridView1.Rows.Count > 0)
            {
                String attachment = "attachment; filename=PAMAC FEMU REJECT MIS.xls";
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
                                "<b><font size='2'>PAMAC FEMU REJECT CASE MIS For Date : " + txtFromDate.Text + " </font></b> <br/>";
                tblCell1.CssClass = "FormHeading";
                tblRow.Cells.Add(tblCell);
                tblRow1.Cells.Add(tblCell1);
                tblRow.Height = 20;
                tblSpace.Rows.Add(tblRow);
                tblSpace.Rows.Add(tblRow1);
                tblSpace.RenderControl(htw);

                Table tbl = new Table();
                GridView1.EnableViewState = false;
                GridView1.GridLines = GridLines.Both;
                GridView1.RenderControl(htw);
                Response.Write(sw.ToString());
                Response.End();
            }
        }
    }
}
