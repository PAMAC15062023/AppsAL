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

public partial class CPV_CC_TELETIMELOG : System.Web.UI.Page
{
    CCommon objcon = new CCommon();
    CLogin userid = new CLogin();
    string username="";
    DateTime dtfrom;
    protected void Page_Load(object sender, EventArgs e)
    {

       
        txtFromDate.Focus();
        username = Session["userid"].ToString();
        if (DDLTELENAME.Text == "")
        {
            getstatus();
        }
            
    }
    public DataTable fillcombo()
    {
        DataTable dt = new DataTable();
        string qry = "";
        qry = "SELECT distinct emp_id, ISNULL(FIRSTNAME,'')+' '+ISNULL(MIDDLENAME,'')+' '+ISNULL(LASTNAME,'') AS TCNAME FROM " +
            " EMPLOYEE_MASTER WHERE designation_id = '8' and (dol is null or dol = '') and centre_id = '"+ Session["CentreID"] +"' order by tcname ";
        OleDbDataAdapter ole = new OleDbDataAdapter(qry, objcon.ConnectionString);
        DataSet ds = new DataSet();
        
        ole.Fill(ds, "Search");
        dt = ds.Tables["Search"];
      
        
        return dt;
    }
    protected void getstatus()
    {
        DataTable dt = new DataTable();
        dt = fillcombo();
       
        if (dt.Rows.Count > 0)
        {
            DDLTELENAME.DataSource = dt;
            DDLTELENAME.DataTextField = "tcname";
            DDLTELENAME.DataValueField = "emp_id";
            DDLTELENAME.DataBind();
            LBLTELENAME.Visible = true;
            DDLTELENAME.Visible = true;
        }
        else
        {
            lblmsg.Visible = true;
            lblmsg.Text = "No record Found";
            DDLTELENAME.Visible = false;
            LBLTELENAME.Visible = false;

        }
    }
    public DataTable tctimelog()
    {
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();
        string qry = "";
        string dtfrom1 = "";
        //dtfrom = Convert.ToDateTime(objcon.strDate(txtFromDate.Text.Trim()));
        //dtfrom1 = txtFromDate.Text.Trim();
        //dtfrom = Convert.ToDateTime(dtfrom1);
        qry ="SELECT distinct D.CLIENT_NAME AS CLIENTNAME,A.CASE_ID,REF_NO,ISNULL(FIRST_NAME,'')+' '+ISNULL(MIDDLE_NAME,'')+' '+ISNULL(LAST_NAME,'') AS NAME," +
            " B.VERIFICATION_TYPE_CODE AS TYPE,CONVERT(VARCHAR(8),ATTEMPT_DATE_TIME,114)AS TIME_OF_CALL,REMARK,ISNULL(FIRSTNAME,'')+' '+ISNULL(MIDDLENAME,'')+' '+ISNULL(LASTNAME,'') AS TCNAME,'" + txtFromDate.Text+ "' as date" +
            " FROM CPV_CC_CASE_DETAILS A,VERIFICATION_TYPE_MASTER B,CASE_TRANSACTION_LOG C,CLIENT_MASTER D,CPV_CC_VERI_ATTEMPTS E,EMPLOYEE_MASTER F" +
            " WHERE A.CASE_ID=C.CASE_ID AND A.CASE_ID =E.CASE_ID AND A.CLIENT_ID=C.CLIENT_ID AND A.CLIENT_ID=D.CLIENT_ID  " +
            " AND B.VERIFICATION_TYPE_ID=C.VERIFICATION_TYPE_ID AND B.VERIFICATION_TYPE_ID=E.VERIFICATION_TYPE_ID AND" +
            " B.VERIFICATION_TYPE_ID IN(3,4) AND C.USER_ID=F.EMP_ID AND C.USER_ID='"+ DDLTELENAME.SelectedValue +"' and convert(varchar(10),attempt_date_time,103)= convert(varchar(10),'"+ txtFromDate.Text +"',103) and A.client_id = '"+ Session["ClientId"].ToString() +"' ORDER BY A.CASE_ID, TIME_OF_CALL";
        //OleDbHelper.ExecuteDataset(objcon.ConnectionString, CommandType.Text, qry);
        OleDbDataAdapter ol = new OleDbDataAdapter(qry, objcon.ConnectionString);
        ol.Fill(ds, "Search");
        dt = ds.Tables["Search"];
        return dt;
    }
    protected void btnsearch_Click(object sender, EventArgs e)
    {
        //getstatus();
        bool isvalid = true;
        if (txtFromDate.Text.Trim() == "")
        {
            lblmsg.Visible = true;
            lblmsg.Text = "Please Select the valid Date Range";
            lblmsg.ForeColor = System.Drawing.Color.Red;
            lblmsg.Font.Bold = true;
        }
        if (txtFromDate.Text.Trim() != "" )
        {

            dtfrom = Convert.ToDateTime(objcon.strDate(txtFromDate.Text.Trim().ToString()));
    
       }
        if (isvalid == true)
        {

            string todate;
            //CReport crt = new CReport();
            DataTable dset = new DataTable();
            dset = tctimelog();

            if (dset.Rows.Count > 0)
            {

                GridView.DataSource = dset;
                GridView.DataBind();
                GridView.Visible = true;
                lblmsg.Visible = false;
                //////////dset.Tables[0].TableName = "TELETIMELOG";
                //////////Session["dataset"] = dset;
                //////////Session["Path"] = Server.MapPath("teletimelog.rpt");
                //////////Session.Remove("ParameterCollection");
                //////////Response.Redirect("../../CrystalReportviewer.aspx?bckPgURL=CPV\\CC\\TELETIMELOG.aspx");

            }
            else
            {
                lblmsg.Visible = true;
                lblmsg.Text = "No Record Found...";
                lblmsg.ForeColor = System.Drawing.Color.Red;
                lblmsg.Font.Bold = true;
            }
        }
    }
    protected void cmdExcel_Click(object sender, EventArgs e)
    {
        DataTable dset = new DataTable();
        dset = tctimelog();

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
                                "<b><font size='2'>PAMAC Tele Time Log MIS For TeleCaller :-  " + DDLTELENAME.SelectedItem + "      For Date :- " + txtFromDate.Text + "  </font></b> <br/>";
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
