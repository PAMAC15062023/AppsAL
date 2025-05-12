using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LNTFinance.Pages
{
    public partial class LNT_UserReport : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void BindReports()
        {
            lblMsgXls.Text = "";

            SqlConnection sqlCon = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

            try
            {
                if (txtFromDate.Text != "")
                {
                    if (txtToDate.Text != "")
                    {

                        SqlCommand cmd = new SqlCommand("LNT_LTFS_UserReport_SP", sqlCon);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@UserId", Session["LoginName"]);
                        cmd.Parameters.AddWithValue("@FromDate", strDate(txtFromDate.Text.Trim()));
                        cmd.Parameters.AddWithValue("@ToDate", strDate(txtToDate.Text.Trim()));
                        cmd.Parameters.AddWithValue("@ClientID", Session["ClientID"]); /*Added on 22/07/2022*/
                        SqlDataAdapter adp = new SqlDataAdapter(cmd);
                        DataSet ds = new DataSet();
                        adp.Fill(ds);

                        if (ds != null && ds.Tables[0].Rows.Count > 0)
                        {

                            gvData.DataSource = ds;
                            gvData.DataBind();

                            btnExport.Visible = true;
                        }
                        else
                        {
                            gvData.DataSource = null;
                            gvData.DataBind();

                            lblMsgXls.Text = "No Record Found ....!!!";
                            btnExport.Visible = false;
                        }
                    }
                    else
                    {
                        lblMsgXls.Text = "Please Select To Date ....!!!";
                        btnExport.Visible = false;
                    }
                }
                else
                {
                    lblMsgXls.Text = "Please Select From Date ....!!!";
                    btnExport.Visible = false;
                }


            }
            catch (Exception ex)
            {
                lblMsgXls.Visible = true;
                lblMsgXls.Text = "Error :" + ex.Message;
            }
        }
        public string strDate(string strInDate)
        {
            string strDD = strInDate.Substring(0, 2);

            string strMM = strInDate.Substring(3, 2);

            string strYYYY = strInDate.Substring(6, 4);

            string strYYYYMMDD = strYYYY + "-" + strMM + "-" + strDD;

            //string strMMDDYYYY = strDD + "/" + strMM + "/" + strYYYY;

            DateTime dtConvertDate = Convert.ToDateTime(strYYYYMMDD);

            string strOutDate = dtConvertDate.ToString("yyyy-MM-dd");

            return strOutDate;
        }

        protected void ClearAllData()
        {
            txtFromDate.Text = "";
            txtToDate.Text = "";
        }
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            BindReports();
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            ClearAllData();
            Response.Redirect("MenuPage.aspx", false);
        }

        protected void btnExport_Click(object sender, EventArgs e)
        {
            Genrate_Excel();
        }
        private void Genrate_Excel()
        {
            String attachment = "attachment; filename= User Report.xls";
            Response.AddHeader("content-disposition", attachment);
            Response.ContentType = "application/ms-excel";
            StringWriter sw = new System.IO.StringWriter();
            HtmlTextWriter htw = new HtmlTextWriter(sw);
            Table tblSpace = new Table();
            TableRow tblRow = new TableRow();
            TableCell tblCell = new TableCell();
            tblCell.Text = " ";
            tblCell.ColumnSpan = 10;// 10;
            tblCell.Text = "<b> <font size='2' color='blue'>PAMAC FINSERVE PVT. LTD.</font></span></b> <br/>";
            tblCell.CssClass = "SuccessMessage";
            TableRow tblRow1 = new TableRow();
            TableCell tblCell1 = new TableCell();
            tblCell1.ColumnSpan = 20;// 10;
            tblCell1.CssClass = "SuccessMessage";
            tblRow.Cells.Add(tblCell);
            tblRow1.Cells.Add(tblCell1);
            tblRow.Height = 20;
            tblSpace.Rows.Add(tblRow);
            tblSpace.Rows.Add(tblRow1);
            tblSpace.RenderControl(htw);

            Table tbl1 = new Table();
            gvData.EnableViewState = false;
            gvData.GridLines = GridLines.Both;
            gvData.RenderControl(htw);
            Response.Write(sw.ToString());

            Response.End();
            Response.Write(sw.ToString());
        }
        public override void VerifyRenderingInServerForm(Control control)
        {
            //base.VerifyRenderingInServerForm(control);
        }
    }
}