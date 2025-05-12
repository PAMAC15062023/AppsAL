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
    public partial class FarmDigitalUserTATReport : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["RoleID"] != null && Convert.ToString(Session["RoleID"]) != "")
                {
                    int RoleId = Convert.ToInt32(Session["RoleID"]);

                    if (RoleId != 3)
                    {
                        BindBindUsers();
                    }
                    else
                    {
                        ddlUserID.Enabled = false;
                    }
                }
                else
                {
                    Response.Redirect("LNT_Error20.aspx", false);
                }
            }
        }
        protected void BindBindUsers()
        {
            try
            {
                SqlConnection sqlCon = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

                SqlCommand cmd = new SqlCommand("LNT_BindUsers_SP", sqlCon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ClientId", Session["ClientID"]);  //Added on 27/07/2022
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adp.Fill(ds);

                if (ds != null && ds.Tables[0].Rows.Count > 0)
                {
                    ddlUserID.DataValueField = "LoginName";
                    ddlUserID.DataTextField = "UserName";
                    ddlUserID.DataSource = ds.Tables[0];
                    ddlUserID.DataBind();
                    ddlUserID.Items.Insert(0, "--Select--");
                    ddlUserID.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }
        protected void BindReports()
        {
            lblMsgXls.Text = "";

            SqlConnection sqlCon = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            int RoleId = Convert.ToInt32(Session["RoleID"]);

            try
            {
                if (Session["LoginName"] != null && Convert.ToString(Session["LoginName"]) != "")
                {
                    if (ddlReportType.SelectedValue != "-Select-")
                    {
                        if (txtFromDate.Text.Trim() != "")
                        {
                            if (txtToDate.Text.Trim() != "")
                            {

                                //SqlCommand cmd = new SqlCommand("LNT_GetFarmDigitalUserTATReport_SP", sqlCon);

                                SqlCommand cmd = new SqlCommand();
                                cmd.Connection = sqlCon;
                                cmd.CommandType = CommandType.StoredProcedure;
                                cmd.CommandText = ddlReportType.SelectedValue.ToString();

                                cmd.CommandType = CommandType.StoredProcedure;
                                cmd.Parameters.AddWithValue("@ClientId", Session["ClientID"]);  //Added on 27/07/2022

                                if (RoleId == 1 || RoleId == 2)
                                {
                                    cmd.Parameters.AddWithValue("@UserId", (ddlUserID.SelectedValue == "--Select--" ? "" : ddlUserID.SelectedValue));
                                }
                                if (RoleId == 3)
                                {
                                    cmd.Parameters.AddWithValue("@UserId", Convert.ToString(Session["LoginName"]));
                                }


                                cmd.Parameters.AddWithValue("@FromDate", strDate(txtFromDate.Text.Trim()));
                                cmd.Parameters.AddWithValue("@ToDate", strDate(txtToDate.Text.Trim()));
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

                                    btnExport.Visible = false;

                                    lblMsgXls.Text = "No Record Found ....!!!";
                                }
                            }
                            else
                            {
                                lblMsgXls.Text = "Please Select To Date ....!!!";
                            }
                        }
                        else
                        {
                            lblMsgXls.Text = "Please Select From Date ....!!!";
                        }
                    }
                    else
                    {
                        lblMsgXls.Text = "Please Select Report Type ....!!!";
                    }
                }
                else
                {
                    Response.Redirect("LNT_Error20.aspx", false);
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
            string ReportName = string.Empty;

            if (ddlReportType.SelectedValue == "LNT_DailyProductivityMIS_SP")
            {
                ReportName = "ProductivityReport";
            }
            else if (ddlReportType.SelectedValue == "LNT_GetFarmDigitalUserTATReport_SP")
            {
                ReportName = "UserTATReport";
            }

            String attachment = "attachment; filename=" + ReportName + ".xls";
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
        protected void ClearAllData()
        {
            if (ddlUserID.SelectedIndex != -1)
            {
                ddlUserID.SelectedIndex = 0;
            }

            txtFromDate.Text = "";
            txtToDate.Text = "";
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            BindReports();
        }

        protected void btnExport_Click(object sender, EventArgs e)
        {
            Genrate_Excel();
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            ClearAllData();
            Response.Redirect("MenuPage.aspx", false);
        }
    }
}