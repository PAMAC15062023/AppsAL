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

public partial class FETracking_Total_Veri_Report : System.Web.UI.Page
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

          string  strVerification = ddlVeri.SelectedValue;
            string strProduct = ddlProduct.SelectedValue.Trim();
            if (txtDate.Text != "")
            {
                strDate = Convert.ToDateTime(con.strDate(txtDate.Text)).ToString("dd-MMM-yyyy");

            }
            
            DataSet ds;

            ds = objFE.TotalReport(strDate, strProduct, strVerification);
            ViewState["v1"] = ds;
            if (ds.Tables[0].Rows.Count > 0)
            {
                btnExport1.Visible = true;
                btnExport2.Visible = true;
                gvSow.DataSource = ds;
                gvSow.DataBind();
                lblmsg.Text = "";
            }
            else
            {
                btnExport1.Visible = false;
                btnExport2.Visible = false;
                gvSow.DataSource = ds;
                gvSow.DataBind();
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

    protected void gvSow_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "NotIsuued")
        {
           
            string strDate = "";
            if (txtDate.Text != "")
            {
                strDate = Convert.ToDateTime(con.strDate(txtDate.Text)).ToString("dd-MMM-yyyy");

            }
            string strVeri_Type = e.CommandArgument.ToString ();
            string veri_id = objFE.GetVeri_id(strVeri_Type);
            DataSet ds22 = new DataSet();
            ds22 = objFE.GetNotIssuedCases(veri_id, ddlProduct.SelectedItem.Text, strDate);
            gvNotIssued.DataSource = ds22;
            gvNotIssued.DataBind();
            ViewState["v2"] = ds22;
           
        }



    }




    protected void ddlProduct_DataBound(object sender, EventArgs e)
    {
        ddlProduct.Items.Insert(0, new ListItem("--Select Product--", "0"));
    }
    protected void ddlVeri_DataBound(object sender, EventArgs e)
    {
        ddlVeri.Items.Insert(0, new ListItem("--All--", "All"));
    }
    protected void btnExport1_Click(object sender, EventArgs e)
    {

        try
        {
            DataSet ds = new DataSet();
            DataSet dsShow = new DataSet();
            dsShow = (DataSet)ViewState["v2"];
            ds = (DataSet)ViewState["v1"];
            GridView gv = new GridView();
            GridView gvShow = new GridView();
            if (ds.Tables[0].Rows.Count > 0)
            {

                gv.DataSource = ds;
                gv.DataBind();
                gvShow.DataSource = dsShow;
                gvShow.DataBind();
                string attachment = "attachment; filename=FE-Wise Report.xls";
                Table tblSpace = new Table();
                TableRow tblRow = new TableRow();
                TableCell tblCell = new TableCell();
                Label lblProduct = new Label();
                Label lblbName = new Label();
                lblbName.Text = "DETAIL OF NOT ISSUED CASES.";
                
                lblProduct.Text = ddlProduct.SelectedItem.Text;
                tblCell.Text = " ";

                TableRow tblRow1 = new TableRow();

                tblSpace.HorizontalAlign = HorizontalAlign.Center;
                TableCell tblCell1 = new TableCell();
                tblCell1.HorizontalAlign = HorizontalAlign.Center;
                tblCell1.Text += "<br/><b><font size='4'>Verfication Type-Wise Report</font></b> <br/>";
                tblCell1.Text += "<b><font size='2'>Product Name :</font></b> " + lblProduct.Text + "<br/>";
               
                if (txtDate.Text != "")
                {
                    tblCell1.Text += "<b><font size='2'> Date :</font></b> " + txtDate.Text.Trim() + "<br/>";
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
                lblbName.RenderControl(htw1);
                gvShow.RenderControl(htw1);
                gvNotIssued.RenderControl(htw1);
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
    protected void gvSow_SelectedIndexChanged(object sender, EventArgs e)
    {

        string strDate = "";
        if (txtDate.Text != "")
        {
            strDate = Convert.ToDateTime(con.strDate(txtDate.Text)).ToString("dd-MMM-yyyy");

        }
        DataSet ds11;
        ds11 = objFE.TotalReport(strDate, ddlProduct.SelectedValue, ddlVeri.SelectedValue);
        gvSow.DataSource = ds11;
        gvSow.DataBind();
    }
}
