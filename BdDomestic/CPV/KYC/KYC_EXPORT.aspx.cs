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

public partial class CPV_KYC_KYC_EXPORT : System.Web.UI.Page
{
    CKYC_Export objExport = new CKYC_Export();
    CCommon objCmn = new CCommon();
  
    protected void Page_Load(object sender, EventArgs e)
    {
        objExport.ClusterID = Session["ClusterId"].ToString();
        objExport.CentreID = Session["CentreId"].ToString();
        objExport.ClientID = Session["ClientID"].ToString();
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
       
        bool isValidDates = true;
        if (txtFromDate.Text.Trim() != "" && txtToDate.Text.Trim() != "")
        {
            DateTime dtFrom;
            DateTime dtTo;
            dtFrom = Convert.ToDateTime(objCmn.strDate(txtFromDate.Text.Trim()));
            dtTo = Convert.ToDateTime(objCmn.strDate(txtToDate.Text.Trim()));

            if (dtFrom > dtTo)
            {
                isValidDates = false;
                lblMsg.Visible = true;
                lblMsg.Text = "From date must be less than to date.";
            }
        }
        if (isValidDates)
        {
            OleDbDataReader oledbRead;
            oledbRead = objExport.GetExportTemplate(Session["ClientID"].ToString());

            if (oledbRead.Read() == true)
            {
                DataSet dsExportGrid = new DataSet();
                dsExportGrid = GetExportData(Session["ClientID"].ToString());
                if (dsExportGrid.Tables.Count > 0)
                {
                    if (dsExportGrid.Tables[0].Rows.Count > 0)
                    {
                        pnlExport.Visible = true;
                        gvExport.DataSource = dsExportGrid;
                        gvExport.DataBind();
                        lblMsg.Visible = false;
                        lblMsg.Text = "";
                    }
                    else
                    {
                        lblMsg.Visible = true;
                        lblMsg.Text = "No record found.";
                        lblMsg.ForeColor = System.Drawing.Color.Red;
                        pnlExport.Visible = false;
                    }
                }
                else
                {
                    lblMsg.Visible = true;
                    lblMsg.Text = "No record found for this Client, please import cases for this case type first.";
                    lblMsg.ForeColor = System.Drawing.Color.Red;
                }

            }
            else
            {
                lblMsg.Visible = true;
                lblMsg.Text = "Template does not exists for this client.";
                lblMsg.ForeColor = System.Drawing.Color.Red;
            }
            oledbRead.Close();
        }
    }
    public DataSet GetExportData(string sClientID)
    {
        OleDbDataReader oledbRead;
        oledbRead = objExport.GetkycExportFields(sClientID);
        ArrayList arrFields = new ArrayList();
        DataSet dsExportData = new DataSet();

        while (oledbRead.Read())
        {
            arrFields.Add(oledbRead["FIELD_NAME"].ToString());
        }

        string ToDate = Convert.ToDateTime(objCmn.strDate(txtToDate.Text.Trim())).AddDays(1.0).ToString("dd-MMM-yyyy");
        dsExportData = objExport.GetKycExport(arrFields, objCmn.strDate(txtFromDate.Text.Trim()), ToDate);
        oledbRead.Close();
        return dsExportData;
    }
    protected void btnExcelReport_Click(object sender, EventArgs e)
    {
        bool isValidDates = true;
        if (txtFromDate.Text.Trim() != "" && txtToDate.Text.Trim() != "")
        {
            DateTime dtFrom;
            DateTime dtTo;
            dtFrom = Convert.ToDateTime(objCmn.strDate(txtFromDate.Text.Trim()));
            dtTo = Convert.ToDateTime(objCmn.strDate(txtToDate.Text.Trim()));

            if (dtFrom > dtTo)
            {
                isValidDates = false;
                lblMsg.Visible = true;
                lblMsg.Text = "From date must be less than to date.";
            }
        }
        if (isValidDates)
        {
            bool IsRecord = true;
            OleDbDataReader oledbRead;
            oledbRead = objExport.GetExportTemplate(Session["ClientID"].ToString());

            if (oledbRead.Read() == true)
            {
                DataSet dsExportExcel = new DataSet();
                dsExportExcel = GetExportData(Session["ClientID"].ToString());
                if (dsExportExcel.Tables.Count > 0)
                {
                    if (dsExportExcel.Tables[0].Rows.Count > 0)
                    {
                        pnlExport.Visible = true;
                        gvExport.DataSource = dsExportExcel;
                        gvExport.DataBind();
                        lblMsg.Visible = false;
                        lblMsg.Text = "";
                    }
                    else
                    {
                        lblMsg.Visible = true;
                        lblMsg.Text = "No record found.";
                        lblMsg.ForeColor = System.Drawing.Color.Red;
                        pnlExport.Visible = false;
                        IsRecord = false;
                    }
                }
                else
                {
                    lblMsg.Visible = true;
                    lblMsg.Text = "No record found for this Client, please import cases for this Client first.";
                    lblMsg.ForeColor = System.Drawing.Color.Red;
                    IsRecord = false;
                }

                if (IsRecord == true)
                {
                    Response.ClearContent();
                    gvExport.BackColor = System.Drawing.Color.White;
                    gvExport.GridLines = GridLines.Both;
                    gvExport.AutoGenerateDeleteButton = false;
                    gvExport.AutoGenerateEditButton = false;
                    gvExport.AllowSorting = false;
                    gvExport.AllowPaging = false;
                    gvExport.DataBind();

                    string attachment = "attachment; filename=HandsSoftSheet.xls";

                    Table tblSpace = new Table();
                    TableRow tblRow = new TableRow();
                    TableCell tblCell = new TableCell();
                    tblCell.Text = " ";

                    TableRow tblRow1 = new TableRow();
                    TableCell tblCell1 = new TableCell();
                    tblCell1.Text = "<br/><b><font size='4'>PAMAC Finserve Private Limited</font></b> <br/>" +
                                    "<b><font size='2'>From Date :</font></b> " + txtFromDate.Text.Trim() + "<br/>" +
                                    "<b><font size='2'>To Date :</font></b> " + txtToDate.Text.Trim() + "<br/>";

                    tblCell1.CssClass = "label";

                    tblRow.Cells.Add(tblCell);
                    tblRow1.Cells.Add(tblCell1);

                    tblRow.Height = 20;

                    tblSpace.Rows.Add(tblRow);
                    tblSpace.Rows.Add(tblRow1);


                    Response.AddHeader("content-disposition", attachment);

                    Response.ContentType = "application/ms-excel";

                    StringWriter sw = new System.IO.StringWriter();

                    HtmlTextWriter htw = new HtmlTextWriter(sw);
                    gvExport.EnableViewState = false;
                    tblRow1.RenderControl(htw);
                    gvExport.RenderControl(htw);

                    Table tblBottom = new Table();
                    TableRow tblRowBottom = new TableRow();
                    TableCell tblCellBottom = new TableCell();


                    tblCellBottom.Text = "<br/><b><font size='2'>For&nbsp;</font><font size='4'> PAMAC Finserve Private Limited</font></b><br/><br/><br/>" +
                                         "<b><font size='2'>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Authorised Signatory</font></b><br/><br/><br/>" +
                                         "<b><font size='3'>Received By</font></b>";


                    tblRowBottom.Cells.Add(tblCellBottom);

                    tblRowBottom.Height = 20;

                    tblBottom.Rows.Add(tblRowBottom);

                    tblRowBottom.RenderControl(htw);

                    Response.Write(sw.ToString());

                    Response.End();
                }
            }
            else
            {
                lblMsg.Visible = true;
                lblMsg.Text = "Template does not exists for this client.";
                lblMsg.ForeColor = System.Drawing.Color.Red;
            }
            oledbRead.Close();
        }
    }
    public override void VerifyRenderingInServerForm(Control control)
    {

    }
    protected void gvExport_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        OleDbDataReader oledbRead;
        oledbRead = objExport.GetExportTemplate(Session["ClientID"].ToString());

        if (oledbRead.Read() == true)
        {
            DataSet dsExportGrid = new DataSet();
            dsExportGrid = GetExportData(Session["ClientID"].ToString());
            if (dsExportGrid.Tables[0].Rows.Count > 0)
            {
                pnlExport.Visible = true;
                gvExport.DataSource = dsExportGrid;
                gvExport.DataBind();
                lblMsg.Visible = false;
                lblMsg.Text = "";
            }
            else
            {
                lblMsg.Visible = true;
                lblMsg.Text = "No record found.";
                lblMsg.ForeColor = System.Drawing.Color.Red;
                pnlExport.Visible = false;
            }
        }
        oledbRead.Close();
    }
    protected void gvExport_Sorting(object sender, GridViewSortEventArgs e)
    {
        OleDbDataReader oledbRead;
        oledbRead = objExport.GetExportTemplate(Session["ClientID"].ToString());
        if (oledbRead.Read() == true)
        {
            DataSet dsExportGrid = new DataSet();
            dsExportGrid = GetExportData(Session["ClientID"].ToString());
            if (dsExportGrid.Tables[0].Rows.Count > 0)
            {
                pnlExport.Visible = true;
                gvExport.DataSource = dsExportGrid;
                gvExport.DataBind();
                lblMsg.Visible = false;
                lblMsg.Text = "";
            }
            else
            {
                lblMsg.Visible = true;
                lblMsg.Text = "No record found.";
                lblMsg.ForeColor = System.Drawing.Color.Red;
                pnlExport.Visible = false;
            }
        }
        oledbRead.Close();
    }
}
