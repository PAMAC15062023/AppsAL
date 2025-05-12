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
using System.Drawing;

namespace IncidentTracker.Pages
{
    public partial class IT_ReportPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                btnExport.Visible = false;
            }
        }
        protected void Search()
        {
            lblMsgXls.Text = "";

            SqlConnection sqlCon = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);

            string proc = string.Empty;

            try
            {

                if (txtFromDate.Text != "")
                {
                    if (txtToDate.Text != "")
                    {
                        proc = "IT_Report1_SP";

                        SqlCommand sqlCom = new SqlCommand();
                        sqlCom.Connection = sqlCon;
                        sqlCom.CommandType = CommandType.StoredProcedure;
                        sqlCom.CommandText = proc;
                        sqlCom.CommandTimeout = 0;

                        SqlParameter FromDate = new SqlParameter();
                        FromDate.SqlDbType = SqlDbType.VarChar;
                        FromDate.Value = strDate(txtFromDate.Text.Trim());
                        FromDate.ParameterName = "@FromDate";
                        sqlCom.Parameters.Add(FromDate);

                        SqlParameter ToDate = new SqlParameter();
                        ToDate.SqlDbType = SqlDbType.VarChar;
                        ToDate.Value = strDate(txtToDate.Text.Trim());
                        ToDate.ParameterName = "@ToDate";
                        sqlCom.Parameters.Add(ToDate);


                        SqlDataAdapter adp = new SqlDataAdapter(sqlCom);
                        DataSet ds = new DataSet();

                        adp.Fill(ds);

                        if (ds != null && ds.Tables[0].Rows.Count > 0)
                        {

                            gvDataShow.DataSource = ds;
                            gvDataShow.DataBind();

                            btnExport.Visible = true;
                        }
                        else
                        {
                            btnExport.Visible = false;
                            gvDataShow.DataSource = null;
                            gvDataShow.DataBind();
                            lblMsgXls.Text = "No Record Found ....!!!";
                        }
                    }
                    else
                    {
                        btnExport.Visible = false;
                        lblMsgXls.Text = "Please Select To Date ....!!!";
                    }
                }
                else
                {
                    btnExport.Visible = false;
                    lblMsgXls.Text = "Please Select From Date ....!!!";
                }


            }
            catch (Exception ex)
            {
                lblMsgXls.Visible = true;
                lblMsgXls.Text = "Error :" + ex.Message;
            }
            finally
            {
                sqlCon.Close();
                sqlCon.Dispose();
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
        private void Genrate_Excel()
        {
            String attachment = "attachment; filename=Report1.xls";
            Response.AddHeader("content-disposition", attachment);
            Response.ContentType = "application/ms-excel";
            StringWriter sw = new System.IO.StringWriter();
            HtmlTextWriter htw = new HtmlTextWriter(sw);
            Table tblSpace = new Table();
            tblSpace.RenderControl(htw);

            Table tbl1 = new Table();
            gvDataShow.EnableViewState = false;
            gvDataShow.GridLines = GridLines.Both;
            gvDataShow.RenderControl(htw);
            Response.Write(sw.ToString());

            Response.End();
            Response.Write(sw.ToString());
        }
        public override void VerifyRenderingInServerForm(Control control)
        {
            // base.VerifyRenderingInServerForm(control);
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            Search();
        }

        protected void btnExport_Click(object sender, EventArgs e)
        {
            Genrate_Excel();
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("IT_MenuPage.aspx", true);
        }
    }
}