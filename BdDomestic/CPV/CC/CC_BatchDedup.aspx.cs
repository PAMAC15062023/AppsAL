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
using System.Data.SqlClient;
using System.Data.OleDb;
using System.IO;
using System.Drawing;

public partial class Import : System.Web.UI.Page
{
    String strXlsSheet = ""; 
   
    protected void Page_Load(object sender, EventArgs e)
    {
        //Added by hemangi kambli on 25/6/2007
        txtFromDate.Focus();
        //---------------------------------------
    }

    private void GetAutoDedup(Color clrGridBg)
    {

        string strSqlDedup = "Select Case_Id, CLIENT_ID, REF_NO, CASE_REC_DATETIME, FIRST_NAME, MIDDLE_NAME, LAST_NAME, FULL_NAME," +
                             " RES_ADD_LINE_1, RES_ADD_LINE_2, RES_ADD_LINE_3, RES_CITY, RES_STATE, RES_PIN_CODE, " +
                             " OFF_ADD_LINE_1, OFF_ADD_LINE_2, OFF_ADD_LINE_3, OFF_CITY, OFF_STATE " +
                             " from CPV_CC_CASE_DETAILS where CASE_REC_DATETIME >= '" + txtFromDate.Text + "'" +
                             " and CASE_REC_DATETIME < '" + Convert.ToDateTime(txtToDate.Text).AddDays(1.0).ToString("dd-MMM-yyyy") + "'";
        OleDbDataReader dr = OleDbHelper.ExecuteReader(ConfigurationManager.ConnectionStrings["CMConnectionString"].ToString(), CommandType.Text, strSqlDedup);
        while (dr.Read())
        {
            SqlDataSource sdsTest = new SqlDataSource();
            sdsTest.ConnectionString = ConfigurationManager.ConnectionStrings["CMConnectionString"].ToString();
            sdsTest.ProviderName = ConfigurationManager.ConnectionStrings["CMConnectionString"].ProviderName;
            sdsTest.SelectCommand = "SELECT CD.TITLE, CD.FIRST_NAME, CD.MIDDLE_NAME, CD.LAST_NAME, CD.FULL_NAME, CD.RES_ADD_LINE_1, " +
                                    " CD.RES_ADD_LINE_2, CD.RES_ADD_LINE_3, CD.RES_CITY, CD.RES_STATE, CD.RES_PIN_CODE, CD.OFF_ADD_LINE_1, " +
                                    " CD.OFF_NAME, CD.OFF_ADD_LINE_2, CD.OFF_ADD_LINE_3, CD.OFF_CITY, CD.OFF_STATE, " +
                                    " CD.CASE_REC_DATETIME, CVD.DECLINED_REASON, CSM.STATUS_NAME " +
                                    " FROM CPV_CC_CASE_DETAILS CD INNER JOIN" +
                                    " CPV_CC_VERI_DETAILS CVD ON CD.CASE_ID = CVD.CASE_ID  INNER JOIN " +
                                    " CASE_STATUS_MASTER CSM ON CVD.CASE_STATUS_ID = CSM.CASE_STATUS_ID where " +
                                    " (CD.CASE_REC_DATETIME < '" + txtFromDate.Text + "' " +
                                    " or CD.CASE_REC_DATETIME >= '" + Convert.ToDateTime(txtToDate.Text).AddDays(1.0).ToString("dd-MMM-yyyy") + "') and CD.Client_Id = '" + Session["ClientId"].ToString() + "'";

            if (ckhSoundex.Checked == true)
                sdsTest.SelectCommand = sdsTest.SelectCommand + "";
            else
            {
                if (dr["FIRST_NAME"].ToString() != "")
                    sdsTest.SelectCommand = sdsTest.SelectCommand + " and FIRST_NAME Like('" + dr["FIRST_NAME"].ToString() + "') ";
                if (dr["MIDDLE_NAME"].ToString() != "")
                    sdsTest.SelectCommand = sdsTest.SelectCommand + " and MIDDLE_NAME Like('" + dr["MIDDLE_NAME"].ToString() + "')";
                if (dr["LAST_NAME"].ToString() != "")
                    sdsTest.SelectCommand = sdsTest.SelectCommand + " and LAST_NAME Like('" + dr["LAST_NAME"].ToString() + "')";
            }
           
            if (rdbNegative.Checked)
                    sdsTest.SelectCommand = sdsTest.SelectCommand +
                                   " and CVD.CASE_STATUS_ID = 2";


            Label lblCriteria = new Label();
            //FIRST_NAME, MIDDLE_NAME, LAST_NAME
            lblCriteria.Text = dr["FIRST_NAME"].ToString() + " " + dr["MIDDLE_NAME"].ToString() + " " + dr["LAST_NAME"].ToString();
            lblCriteria.CssClass = "label";

            Label lblSpace = new Label();
            lblSpace.Text = "";
            lblSpace.CssClass = "label";

            lblSpace.Height = 50;
            lblCriteria.Height = 24;

            GridView gvTest = new GridView();
            gvTest.Width = 950;
            gvTest.SkinID = "gridviewNoSort";
            gvTest.CellSpacing = 1;
            gvTest.BackColor = clrGridBg; 
            gvTest.CellPadding = 1;
            if (clrGridBg == Color.Black)
                gvTest.GridLines = GridLines.None;
            else
                gvTest.GridLines = GridLines.Both;

            gvTest.RowStyle.HorizontalAlign = HorizontalAlign.Left;
            gvTest.RowStyle.VerticalAlign = VerticalAlign.Top;
            gvTest.AutoGenerateColumns = false;


            gvTest.RowStyle.CssClass = "GridRow";
            gvTest.PagerStyle.HorizontalAlign = HorizontalAlign.Center;
            gvTest.PagerStyle.CssClass = "Class1";
            gvTest.HeaderStyle.CssClass = "GridHeader";
            gvTest.AlternatingRowStyle.CssClass = "GridAlternate";

            gvTest.AllowPaging = false;
            gvTest.AllowSorting = false;

            BoundField bfCustomerName = new BoundField();
            BoundField bfAdd1 = new BoundField();
            BoundField bfAdd2 = new BoundField();
            BoundField bfAdd3 = new BoundField();
            BoundField bfCity = new BoundField();
            BoundField bfPin = new BoundField();
            BoundField bfRecDate = new BoundField();
            BoundField bfCaseStatus = new BoundField();
            BoundField bfDedupRemark = new BoundField();

            bfCustomerName.HeaderText = "Customer Name";
            
            bfAdd1.HeaderText = "Address1";
            bfAdd2.HeaderText = "Address3";
            bfAdd3.HeaderText = "Address2";
            bfCity.HeaderText = "City";
            bfPin.HeaderText = "Pin";
            bfRecDate.HeaderText = "Case Reeived Date";
            bfCaseStatus.HeaderText = "Case Status";
            bfDedupRemark.HeaderText = "Dedup Remark";

            bfRecDate.DataFormatString = "{0:dd-MMM-yyyy}";
            bfRecDate.HtmlEncode = false;
            

            bfCustomerName.DataField = "FIRST_NAME";
            bfAdd1.DataField = "RES_ADD_LINE_3";
            bfAdd2.DataField = "RES_ADD_LINE_2";
            bfAdd3.DataField = "RES_ADD_LINE_3";
            bfCity.DataField = "RES_City";
            bfPin.DataField = "RES_PIN_CODE";
            bfRecDate.DataField = "CASE_REC_DATETIME";
            bfCaseStatus.DataField = "STATUS_NAME";
            bfDedupRemark.DataField = "DECLINED_REASON";

            gvTest.Columns.Add(bfCustomerName);
            gvTest.Columns.Add(bfAdd1);
            gvTest.Columns.Add(bfAdd2);
            gvTest.Columns.Add(bfAdd3);
            gvTest.Columns.Add(bfCity);
            gvTest.Columns.Add(bfPin);
            gvTest.Columns.Add(bfRecDate);
            gvTest.Columns.Add(bfCaseStatus);
            gvTest.Columns.Add(bfDedupRemark);

            
            Table tblSpace = new Table();
            TableRow tblRow = new TableRow();
            TableCell tblCell= new TableCell();
            tblCell.Text = " ";

            TableRow tblRow1 = new TableRow();
            TableCell tblCell1 = new TableCell();
            tblCell1.Text = "Customer Name: " + lblCriteria.Text  +
                             "<br/>Address: " +
                             dr["RES_ADD_LINE_1"].ToString()+ " " +
                             dr["RES_ADD_LINE_2"].ToString() + " " +
                             dr["RES_ADD_LINE_3"].ToString();
            tblCell1.CssClass = "label";

            tblRow.Cells.Add(tblCell);
            tblRow1.Cells.Add(tblCell1);

            tblRow.Height = 20;

            tblSpace.Rows.Add(tblRow);
            tblSpace.Rows.Add(tblRow1);

            gvTest.DataSource = sdsTest;
            gvTest.DataBind();
            if (gvTest.Rows.Count != 0)
            {
                //plhDedupe.Controls.Add(lblSpace);
                //plhDedupe.Controls.Add(lblCriteria);
                plhDedupe.Controls.Add(tblSpace);
                plhDedupe.Controls.Add(sdsTest);
                plhDedupe.Controls.Add(gvTest);
            }
            
        }
        dr.Close();
    }

    protected void btnDedupeSearch_Click(object sender, EventArgs e)
    {
        GetAutoDedup(Color.Wheat);
        btnDedupeSearch.Focus();
    }
    protected void btnExportToExcel_Click(object sender, EventArgs e)
    {
        ExportExcel();
    }
    private void ExportExcel()
    {
        //bool IsRecord = true;
        Response.ClearContent();
        //DataSet dsDedupRpt = new DataSet();
        //GetDedup("ExportExcel");

        GetAutoDedup(Color.White);
        if (plhDedupe.Controls.Count == 0)
        {
            lblMsg.Text = "No data found for exporting to excel.";
        }
        else//if (IsRecord == true)
        {
            //gvDeDupe.BackColor = System.Drawing.Color.White;
            //gvDeDupe.GridLines = GridLines.Both;

            //gvDeDupe.AutoGenerateDeleteButton = false;
            //gvDeDupe.AutoGenerateEditButton = false;
            //gvDeDupe.AllowSorting = false;
            //gvDeDupe.AllowPaging = false;
            //gvDeDupe.DataBind();
            string attachment = "attachment; filename=DedupSearch.xls";


            Response.AddHeader("content-disposition", attachment);

            Response.ContentType = "application/ms-excel";

            StringWriter sw = new System.IO.StringWriter();

            HtmlTextWriter htw = new HtmlTextWriter(sw);
            //gvDeDupe.EnableViewState = false;
            
            plhDedupe.RenderControl(htw);
            //gvDeDupe.RenderControl(htw);

            Response.Write(sw.ToString());

            Response.End();
        }

    }

    public override void VerifyRenderingInServerForm(Control control)
    {

    }
    
}
