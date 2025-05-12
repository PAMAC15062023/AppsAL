using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.IO;

namespace ChangeManagement
{
    public partial class CM_Development_MIS_Report : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnExport_Click(object sender, EventArgs e)
        {
            bool result = false;

            result = BindReports();


            if (result == true)
            {
                Generate_Excel();
                //ClearData();
            }
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("FEDBank_SupervisorMenu.aspx", false);
        }

        protected bool BindReports()
        {
            lblMsgXls.Text = "";

            bool result = false;

            SqlConnection sqlCon = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);

            //string proc;

            try
            {
                //if (ddlReports.SelectedIndex.ToString() != "0")
                //{
                //    if (txtFromDate.Text != "")
                //    {
                //        if (txtToDate.Text != "")
                //        {
                //            if (ddlReports.SelectedValue.ToString() == "Client_MIS")
                //            {
                //                proc = "FEDBank_Client_MIS_Report_SP";
                //            }
                //            else if (ddlReports.SelectedValue.ToString() == "EndToEndTAT")
                //            {
                //                proc = "FEDBank_END_TO_END_TAT_SP";
                //            }
                //            else if (ddlReports.SelectedValue.ToString() == "Initiate-FEDFINA")
                //            {
                //                proc = "FEDBank_Initiate-FEDFINA_SP";
                //            }
                //            else if (ddlReports.SelectedValue.ToString() == "LoginTAT")
                //            {
                //                proc = "FEDBank_Login_TAT_SP";
                //            }
                //            else
                //            {
                //                proc = "FEDBank_QC_MIS_SP";
                //            }

                SqlCommand sqlCom = new SqlCommand();
                sqlCom.Connection = sqlCon;
                sqlCom.CommandType = CommandType.StoredProcedure;
                sqlCom.CommandText = "";
                sqlCom.CommandTimeout = 0;





                SqlDataAdapter adp = new SqlDataAdapter(sqlCom);
                DataSet ds = new DataSet();
                adp.Fill(ds);

                if (ds != null && ds.Tables[0].Rows.Count > 0)
                {

                    gvData.DataSource = ds;
                    gvData.DataBind();

                    btnExport.Visible = true;
                    result = true;
                }
                else
                {
                    gvData.DataSource = null;
                    gvData.DataBind();

                    btnExport.Visible = false;


                    lblMsgXls.Text = "No Record Found ....!!!";
                    result = false;
                }
                //}
                //else
                //{
                //    lblMsgXls.Text = "Please Select To Date ....!!!";
                //}
                //}
                //else
                //{
                //    lblMsgXls.Text = "Please Select From Date ....!!!";
                //}
                //}
                //else
                //{
                //    lblMsgXls.Text = "Please Select  Report  ...!!!";
                //}

            }
            catch (Exception ex)
            {
                string msg = ex.Message;
            }
            finally
            {
                sqlCon.Close();
                sqlCon.Dispose();
            }
            return result;
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
        private void Generate_Excel()
        {
            String attachment = "attachment; filename=" + ".xls";
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
    }
}