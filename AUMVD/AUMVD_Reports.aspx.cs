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
using YesBank;

namespace AUMVD
{
    public partial class AUMVD_Reports : System.Web.UI.Page
    {
        bool result = false;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lblMISName.Visible = false;
                ddlMISName.Visible = false;
                BtnExport.Visible = false;
                txtFromDate.Enabled = true;
                txtToDate.Enabled = true;
                gvData.Visible = false;
            }
        }

        protected void ddlMISType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlMISType.SelectedItem.Text == "Active User List")
            {
                lblMISName.Visible = true;
                ddlMISName.Visible = true;
                txtFromDate.Visible = false;
                txtToDate.Visible = false;
                gvData.Visible = false;

            }
            else
            {
                lblMISName.Visible = false;
                ddlMISName.Visible = false;
                txtFromDate.Visible = true;
                txtToDate.Visible = true;
                gvData.Visible = false;
            }
            txtFromDate.Text = "";
            txtToDate.Text = "";
            ddlMISName.SelectedIndex = 0;
            BtnExport.Visible = false;
        }

        public string strDate(string strInDate)
        {

            string strMM = strInDate.Substring(3, 2);

            string strDD = strInDate.Substring(0, 2);

            string strYYYY = strInDate.Substring(6, 4);

            string strMMDDYYYY = strYYYY + "-" + strMM + "-" + strDD;

            //string strMMDDYYYY = strDD + "/" + strMM + "/" + strYYYY;

            DateTime dtConvertDate = Convert.ToDateTime(strMMDDYYYY);

            string strOutDate = dtConvertDate.ToString("yyyy-MM-dd");

            return strOutDate;
        }
        protected bool BindReports()
        {
            lblMsgXls.Text = "";
            SqlConnection sqlCon = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            string proc = string.Empty;

            try
            {
                if (ddlMISType.SelectedIndex != 0)
                {
                    if (ddlMISType.SelectedItem.Text == "Active User List")
                    {
                        if (ddlMISName.SelectedItem.Text != "--Select--")
                        {
                            SqlCommand sqlCom = new SqlCommand();
                            sqlCom.Connection = sqlCon;
                            sqlCom.CommandType = CommandType.StoredProcedure;
                            sqlCom.CommandText = ddlMISName.SelectedValue;
                            sqlCom.CommandTimeout = 0;

                            SqlDataAdapter adp = new SqlDataAdapter(sqlCom);
                            DataSet ds = new DataSet();

                            adp.Fill(ds);

                            if (ds != null && ds.Tables[0].Rows.Count > 0)
                            {

                                gvData.DataSource = ds;
                                gvData.DataBind();
                                result = true;
                                ViewState["Result"] = result;
                                BtnExport.Visible = true;
                            }
                            else
                            {
                                gvData.DataSource = null;
                                gvData.DataBind();
                                BtnExport.Visible = false;

                                lblMsgXls.Text = "No Record Found ....!!!";
                                result = false;
                            }
                        }
                        else
                        {
                            lblMsgXls.Text = "Please select MIS Name for Active User List";
                            BtnExport.Visible = false;
                            return false;
                        }

                    }
                    
                    else if (ddlMISType.SelectedItem.Text == "Volume Data")
                    {
                        if (txtFromDate.Text != "")
                        {
                            if (txtToDate.Text != "")
                            {
                                SqlCommand sqlComm = new SqlCommand();
                                sqlComm.Connection = sqlCon;
                                sqlComm.CommandType = CommandType.StoredProcedure;
                                sqlComm.CommandText = "ActiveUserMIS_VolumeDataMIS";
                                sqlComm.CommandTimeout = 0;

                                SqlParameter FromDate = new SqlParameter();
                                FromDate.SqlDbType = SqlDbType.VarChar;
                                FromDate.Value = strDate(txtFromDate.Text.Trim());
                                FromDate.ParameterName = "@FromDate";
                                sqlComm.Parameters.Add(FromDate);

                                SqlParameter ToDate = new SqlParameter();
                                ToDate.SqlDbType = SqlDbType.VarChar;
                                ToDate.Value = strDate(txtToDate.Text.Trim());
                                ToDate.ParameterName = "@ToDate";
                                sqlComm.Parameters.Add(ToDate);

                                SqlDataAdapter adpp = new SqlDataAdapter(sqlComm);
                                DataSet dss = new DataSet();

                                adpp.Fill(dss);

                                if (dss != null && dss.Tables[0].Rows.Count > 0)
                                {

                                    gvData.DataSource = dss;
                                    gvData.DataBind();
                                    result = true;
                                    ViewState["Result"] = result;
                                    BtnExport.Visible = true;
                                }
                                else
                                {
                                    gvData.DataSource = null;
                                    gvData.DataBind();
                                    BtnExport.Visible = false;

                                    lblMsgXls.Text = "No Record Found ....!!!";
                                    result = false;
                                }
                            }
                                else
                                {
                                    gvData.DataSource = null;
                                    gvData.DataBind();

                                    lblMsgXls.Text = "Please Select To Date ....!!!";
                                    BtnExport.Visible = false;
                                }
                            }
                            else
                            {
                                gvData.DataSource = null;
                                gvData.DataBind();

                                lblMsgXls.Text = "Please Select From Date  ...!!!";
                                BtnExport.Visible = false;
                            }                       
                    }

                }

                else
                {
                    lblMsgXls.Text = "Please Select MIS ...!!!";
                    BtnExport.Visible = false;
                    return false;
                }

                return true;
            }
            catch (Exception ex)
            {
                lblMsgXls.Visible = true;
                lblMsgXls.Text = "Error: " + ex.Message;
                BtnExport.Visible = false;
                gvData.DataSource = null;
                gvData.DataBind();
                return false;
            }
            finally
            {
                sqlCon.Close();
                sqlCon.Dispose();
            }
        }

       
        protected void BtnSearch_Click(object sender, EventArgs e)
        {
            gvData.Visible = true;
            BindReports();
        }

        protected void BtnExport_Click(object sender, EventArgs e)
        {
            Genrate_Excel();
        }

        private void Genrate_Excel()
        {
            String attachment = "attachment; filename=" + ddlMISType.SelectedItem.ToString() + " " + ddlMISName.SelectedItem.ToString() + ".xls";
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
            // base.VerifyRenderingInServerForm(control);
        }

        public void Clear()
        {
            txtFromDate.Text = "";
            txtToDate.Text = "";
            ddlMISName.SelectedIndex = 0;
            ddlMISType.SelectedIndex = 0;
            gvData.Visible = false;
            lblMsgXls.Text = "";
        }

        protected void BtnBack_Click(object sender, EventArgs e)
        {
            Clear();
        }
    }
}