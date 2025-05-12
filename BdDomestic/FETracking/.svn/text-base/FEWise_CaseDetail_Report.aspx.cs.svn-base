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
using System.IO;

public partial class FETracking_FEWise_CaseDetail_Report : System.Web.UI.Page
{
    CFE_Report objFE = new CFE_Report();
    CCommon con = new CCommon();
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnShow_Click(object sender, EventArgs e)
    {
        try
        {
            string strDate = "";

            string strFECode = "";
            string strProduct = ddlProdct.SelectedValue.Trim();
            if (txtDate.Text != "")
            {
                strDate = Convert.ToDateTime(con.strDate(txtDate.Text)).ToString("dd-MMM-yyyy");

            }
            if (txtFECode.Text != "")
            {
                strFECode = txtFECode.Text.Trim();
            }
            DataSet ds;

            ds = objFE.FE_Case_DetailReport(strProduct, strDate, strFECode);
            ViewState["v1"]=ds;
            if (ds.Tables[0].Rows.Count > 0)
            {
                btnExport1.Visible = true;
                btnExport2.Visible = true;
                gvShow.DataSource = ds;
                gvShow.DataBind();
                lblmsg.Text = "";
            }
            else
            {
                btnExport1.Visible = false;
                btnExport2.Visible = false;
                lblmsg.Text = "No record found.";
            }
        }
        catch (Exception ex)
        {
            btnExport1.Visible = false;
            btnExport2.Visible = false;
            lblmsg.Text = ex.Message;
        }

    }
    protected void ddlProdct_DataBound(object sender, EventArgs e)
    {
       
        ddlProdct.Items.Insert(0, new ListItem("All", "0"));
       
    }
    protected void btnExport1_Click(object sender, EventArgs e)
    {
        try
        {
            DataSet ds = new DataSet();
            ds = (DataSet)ViewState["v1"];
            GridView gv = new GridView();
            if (ds.Tables[0].Rows.Count > 0)
            {

                gv.DataSource = ds;
                gv.DataBind();
                string attachment = "attachment; filename=FE-Wise Report.xls";
                Table tblSpace = new Table();
                TableRow tblRow = new TableRow();
                TableCell tblCell = new TableCell();
                Label lblProduct = new Label();
                lblProduct.Text = ddlProdct.SelectedItem.Text;
                
                tblCell.Text = " ";

                TableRow tblRow1 = new TableRow();

                tblSpace.HorizontalAlign = HorizontalAlign.Center;
                TableCell tblCell1 = new TableCell();
                tblCell1.HorizontalAlign = HorizontalAlign.Center;
                tblCell1.Text += "<br/><b><font size='4'>FE-Wise Case Detail Report</font></b> <br/>";
                if (ddlProdct.SelectedIndex != 0)
                {
                    tblCell1.Text += "<b><font size='2'>Product Name :</font></b> " + lblProduct.Text + "<br/>";
                }
                if (txtDate.Text != "" && txtFECode.Text != "")
                {
                    tblCell1.Text += "<b><font size='2'> Date :</font></b> " + txtDate.Text.Trim() + "<br/>";

                    tblCell1.Text += "<b><font size='2'>FE-Code :</font></b> " + txtFECode.Text.Trim() + "<br/>";
                }
                if (txtDate.Text != "")
                {
                    tblCell1.Text += "<b><font size='2'> Date :</font></b> " + txtDate.Text.Trim() + "<br/>";
                }
                if (txtFECode.Text != "")
                {
                    tblCell1.Text += "<b><font size='2'>FE-Code :</font></b> " + txtFECode.Text.Trim() + "<br/>";


                }
                tblCell1.CssClass = "label";

                tblRow.Cells.Add(tblCell);
                tblRow1.Cells.Add(tblCell1);

                tblRow.Height = 20;

                tblSpace.Rows.Add(tblRow);
                tblSpace.Rows.Add(tblRow1);


                Response.AddHeader("content-disposition", attachment);

                Response.ContentType = "application/ms-excel";

                StringWriter sw1 = new System.IO.StringWriter();

                HtmlTextWriter htw1 = new HtmlTextWriter(sw1);

                tblCell1.RenderControl(htw1);
                gv.RenderControl(htw1);
                Response.Write(sw1.ToString());
                Response.End();

            }
            else
            {
                lblmsg.Text = "No record found.";
            }
            ds.Dispose();
            ds.Clear();
        }
        catch (Exception ex)
        {
            lblmsg.Text = ex.Message;
        }
    }
    public override void VerifyRenderingInServerForm(Control control)
    {

    }
}
