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

namespace CoreDailyMISAutomation
{
    public partial class CDMA_ReportExtract : System.Web.UI.Page
    {
        bool result = false;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindSubVertical();
                BindClientName();
                BindActivity();
                BindProduct();
                BindSubProduct();
                BtnExport.Visible = false;
            }
        }

        protected void BindSubVertical()
        {
            try
            {
                SqlConnection sqlCon = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);

                SqlCommand sqlCom = new SqlCommand();
                sqlCom.Connection = sqlCon;
                sqlCom.CommandType = CommandType.StoredProcedure;
                sqlCom.CommandText = "CDMA_BindSubVertical";
                sqlCom.CommandTimeout = 0;

                SqlDataAdapter da = new SqlDataAdapter(sqlCom);
                DataSet ds = new DataSet();
                da.Fill(ds);

                if (ds != null && ds.Tables.Count > 0)
                {
                    ddlSubVertical.DataTextField = "SubVertical";
                    ddlSubVertical.DataValueField = "ID";
                    ddlSubVertical.DataSource = ds.Tables[0];
                    ddlSubVertical.DataBind();

                    ddlSubVertical.Items.Insert(0, "--Select--");
                    ddlSubVertical.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {

            }
        }
        protected void ddlSubVertical_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlSubVertical.SelectedValue != "--Select--")
            {
                SqlConnection sqlCon = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);

                SqlCommand sqlCom = new SqlCommand();
                sqlCom.Connection = sqlCon;
                sqlCom.CommandType = CommandType.StoredProcedure;
                sqlCom.CommandText = "CDMA_OnIndexChangeOfSubVertical_SP";
                sqlCom.CommandTimeout = 0;

                SqlParameter SubVertical = new SqlParameter();
                SubVertical.SqlDbType = SqlDbType.VarChar;
                SubVertical.Value = ddlSubVertical.SelectedValue;
                SubVertical.ParameterName = "@SubVerticalID";
                sqlCom.Parameters.Add(SubVertical);

                sqlCon.Open();

                SqlDataAdapter da = new SqlDataAdapter(sqlCom);
                DataSet ds = new DataSet();
                da.Fill(ds);

                sqlCon.Close();

                if (ds != null && ds.Tables[0].Rows.Count > 0)
                {
                    ddlClientName.DataTextField = "ClientName";
                    ddlClientName.DataValueField = "ID";
                    ddlClientName.DataSource = ds.Tables[0];
                    ddlClientName.DataBind();

                    ddlClientName.Items.Insert(0, "--Select--");
                    ddlClientName.SelectedIndex = 0;
                    ddlClientName.Enabled = true;
                }
                else
                {
                    ddlClientName.Items.Insert(0, "--Select--");
                    ddlClientName.SelectedIndex = 0;
                    ddlClientName.Enabled = false;
                }
            }
            else
            {
                BindClientName();
            }
        }
        protected void BindClientName()
        {
            try
            {
                SqlConnection sqlCon = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);

                SqlCommand sqlCom = new SqlCommand();
                sqlCom.Connection = sqlCon;
                sqlCom.CommandType = CommandType.StoredProcedure;
                sqlCom.CommandText = "CDMA_BindClientName";
                sqlCom.CommandTimeout = 0;

                SqlDataAdapter da = new SqlDataAdapter(sqlCom);
                DataSet ds = new DataSet();
                da.Fill(ds);

                if (ds != null && ds.Tables.Count > 0)
                {
                    ddlClientName.DataTextField = "ClientName";
                    ddlClientName.DataValueField = "ID";
                    ddlClientName.DataSource = ds.Tables[0];
                    ddlClientName.DataBind();

                    ddlClientName.Items.Insert(0, "--Select--");
                    ddlClientName.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {

            }
        }
        protected void ddlClientName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlClientName.SelectedValue != "--Select--")
            {
                SqlConnection sqlCon = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);

                SqlCommand sqlCom = new SqlCommand();
                sqlCom.Connection = sqlCon;
                sqlCom.CommandType = CommandType.StoredProcedure;
                sqlCom.CommandText = "CDMA_OnIndexChangeOfClient_SP";
                sqlCom.CommandTimeout = 0;

                SqlParameter Client = new SqlParameter();
                Client.SqlDbType = SqlDbType.VarChar;
                Client.Value = ddlClientName.SelectedValue;
                Client.ParameterName = "@ClientID";
                sqlCom.Parameters.Add(Client);

                sqlCon.Open();

                SqlDataAdapter da = new SqlDataAdapter(sqlCom);
                DataSet ds = new DataSet();
                da.Fill(ds);

                sqlCon.Close();
                if (ds != null && ds.Tables[0].Rows.Count > 0)
                {

                    ddlActivity.Enabled = true;
                    ddlProduct.Enabled = true;
                    ddlSubProduct.Enabled = true;

                    ddlActivity.DataTextField = "Activity";
                    ddlActivity.DataValueField = "ID";
                    ddlActivity.DataSource = ds.Tables[0];
                    ddlActivity.DataBind();

                    ddlActivity.Items.Insert(0, "--Select--");
                    ddlActivity.SelectedIndex = 0;

                    ddlProduct.DataTextField = "Product";
                    ddlProduct.DataValueField = "ID";
                    ddlProduct.DataSource = ds.Tables[1];
                    ddlProduct.DataBind();

                    ddlProduct.Items.Insert(0, "--Select--");
                    ddlProduct.SelectedIndex = 0;
                }
                else
                {
                    //ddlActivity.Items.Clear();
                    //ddlProduct.Items.Clear();
                    ddlActivity.Items.Insert(0, "--Select--");
                    ddlActivity.SelectedIndex = 0;

                    ddlProduct.Items.Insert(0, "--Select--");
                    ddlProduct.SelectedIndex = 0;

                    ddlSubProduct.Items.Insert(0, "--Select--");
                    ddlSubProduct.SelectedIndex = 0;

                    ddlActivity.Enabled = false;
                    ddlProduct.Enabled = false;
                    ddlSubProduct.Enabled = false;
                }
            }
            else
            {
                BindActivity();
                BindSubProduct();
            }
        }
        protected void BindActivity()
        {
            try
            {
                SqlConnection sqlCon = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);

                SqlCommand sqlCom = new SqlCommand();
                sqlCom.Connection = sqlCon;
                sqlCom.CommandType = CommandType.StoredProcedure;
                sqlCom.CommandText = "CDMA_BindActivity";
                sqlCom.CommandTimeout = 0;

                SqlDataAdapter da = new SqlDataAdapter(sqlCom);
                DataSet ds = new DataSet();
                da.Fill(ds);

                if (ds != null && ds.Tables.Count > 0)
                {
                    ddlActivity.DataTextField = "Activity";
                    ddlActivity.DataValueField = "ID";
                    ddlActivity.DataSource = ds.Tables[0];
                    ddlActivity.DataBind();

                    ddlActivity.Items.Insert(0, "--Select--");
                    ddlActivity.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {

            }
        }

        //protected void ddlActivity_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    SqlConnection sqlCon = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);

        //    SqlCommand sqlCom = new SqlCommand();
        //    sqlCom.Connection = sqlCon;
        //    sqlCom.CommandType = CommandType.StoredProcedure;
        //    sqlCom.CommandText = "CDMA_OnIndexChangeOfActivity_SP";
        //    sqlCom.CommandTimeout = 0;

        //    SqlParameter Client = new SqlParameter();
        //    Client.SqlDbType = SqlDbType.VarChar;
        //    Client.Value = ddlClientName.SelectedValue;
        //    Client.ParameterName = "@ClientID";
        //    sqlCom.Parameters.Add(Client);

        //    SqlParameter SubVertical = new SqlParameter();
        //    SubVertical.SqlDbType = SqlDbType.VarChar;
        //    SubVertical.Value = ddlSubVertical.SelectedValue;
        //    SubVertical.ParameterName = "@SubVerticalID";
        //    sqlCom.Parameters.Add(SubVertical);

        //    sqlCon.Open();

        //    SqlDataAdapter da = new SqlDataAdapter(sqlCom);
        //    DataSet ds = new DataSet();
        //    da.Fill(ds);

        //    sqlCon.Close();

        //    if (ds != null && ds.Tables.Count > 0)
        //    {
        //        ddlProduct.DataTextField = "Product";
        //        ddlProduct.DataValueField = "ID";
        //        ddlProduct.DataSource = ds.Tables[0];
        //        ddlProduct.DataBind();

        //        ddlProduct.Items.Insert(0, "--Select--");
        //        ddlProduct.SelectedIndex = 0;
        //    }
        //    else
        //    {

        //        ddlProduct.Items.Clear();
        //    }
        //}
        protected void BindProduct()
        {
            try
            {
                SqlConnection sqlCon = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);

                SqlCommand sqlCom = new SqlCommand();
                sqlCom.Connection = sqlCon;
                sqlCom.CommandType = CommandType.StoredProcedure;
                sqlCom.CommandText = "CDMA_BindProduct";
                sqlCom.CommandTimeout = 0;

                SqlDataAdapter da = new SqlDataAdapter(sqlCom);
                DataSet ds = new DataSet();
                da.Fill(ds);

                if (ds != null && ds.Tables.Count > 0)
                {
                    ddlProduct.DataTextField = "Product";
                    ddlProduct.DataValueField = "ID";
                    ddlProduct.DataSource = ds.Tables[0];
                    ddlProduct.DataBind();

                    ddlProduct.Items.Insert(0, "--Select--");
                    ddlProduct.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {

            }
        }
        protected void ddlProduct_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlProduct.SelectedValue != "--Select--")
            {
                SqlConnection sqlCon = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);

                SqlCommand sqlCom = new SqlCommand();
                sqlCom.Connection = sqlCon;
                sqlCom.CommandType = CommandType.StoredProcedure;
                sqlCom.CommandText = "CDMA_OnIndexChangeOfProduct_SP";
                sqlCom.CommandTimeout = 0;

                SqlParameter Product = new SqlParameter();
                Product.SqlDbType = SqlDbType.VarChar;
                Product.Value = ddlProduct.SelectedValue;
                Product.ParameterName = "@ProductID";
                sqlCom.Parameters.Add(Product);

                sqlCon.Open();

                SqlDataAdapter da = new SqlDataAdapter(sqlCom);
                DataSet ds = new DataSet();
                da.Fill(ds);

                sqlCon.Close();

                if (ds != null && ds.Tables[0].Rows.Count > 0)
                {
                    ddlSubProduct.DataTextField = "SubProduct";
                    ddlSubProduct.DataValueField = "ID";
                    ddlSubProduct.DataSource = ds.Tables[0];
                    ddlSubProduct.DataBind();

                    ddlSubProduct.Items.Insert(0, "--Select--");
                    ddlSubProduct.SelectedIndex = 0;
                    ddlSubProduct.Enabled = true;
                }
                else
                {
                    ddlSubProduct.Items.Insert(0, "--Select--");
                    ddlSubProduct.SelectedIndex = 0;
                    ddlSubProduct.Enabled = false;
                }
            }
            else
            {
                BindSubProduct();
            }
        }
        protected void BindSubProduct()
        {
            try
            {
                SqlConnection sqlCon = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);

                SqlCommand sqlCom = new SqlCommand();
                sqlCom.Connection = sqlCon;
                sqlCom.CommandType = CommandType.StoredProcedure;
                sqlCom.CommandText = "CDMA_BindSubProduct";
                sqlCom.CommandTimeout = 0;

                SqlDataAdapter da = new SqlDataAdapter(sqlCom);
                DataSet ds = new DataSet();
                da.Fill(ds);

                if (ds != null && ds.Tables.Count > 0)
                {
                    ddlSubProduct.DataTextField = "SubProduct";
                    ddlSubProduct.DataValueField = "ID";
                    ddlSubProduct.DataSource = ds.Tables[0];
                    ddlSubProduct.DataBind();

                    ddlSubProduct.Items.Insert(0, "--Select--");
                    ddlSubProduct.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {

            }
        }
        protected bool BindReports()
        {
            lblMsgXls.Text = "";

            SqlConnection sqlCon = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);

            string proc = string.Empty;
            string flag = string.Empty;

            try
            {

                if (ddlMIS.SelectedIndex.ToString() != "0")
                {
                    if (txtMonthYear.Text != "")
                    {
                        if (ddlMIS.SelectedValue.ToString() == "Monthly Volume MIS")
                        {
                            proc = "CDMA_GetReportForMonthlyMIS_SP";
                            flag = "Monthly Volume MIS";
                        }
                        else if (ddlMIS.SelectedValue.ToString() == "Billing MIS")
                        {
                            proc = "CDMA_GetReportForBillingMIS_SP";
                            flag = "Billing MIS";
                        }
                        else if (ddlMIS.SelectedValue.ToString() == "Manual Update MIS")
                        {
                            proc = "CDMA_GetReportForManualUpdate_SP";
                            flag = "Manual Update MIS";
                        }

                        SqlCommand sqlCom = new SqlCommand();
                        sqlCom.Connection = sqlCon;
                        sqlCom.CommandType = CommandType.StoredProcedure;
                        sqlCom.CommandText = proc;
                        sqlCom.CommandTimeout = 0;

                        SqlParameter MonthYear = new SqlParameter();
                        MonthYear.SqlDbType = SqlDbType.VarChar;
                        MonthYear.Value = txtMonthYear.Text.Trim();
                        MonthYear.ParameterName = "@MonthYear";
                        sqlCom.Parameters.Add(MonthYear);

                        SqlParameter SubVertical = new SqlParameter();
                        SubVertical.SqlDbType = SqlDbType.VarChar;
                        if (ddlSubVertical.SelectedItem.Text == "--Select--")
                        {
                            SubVertical.Value = "";
                        }
                        else
                        {
                            SubVertical.Value = ddlSubVertical.SelectedItem.Text;
                        }

                        SubVertical.ParameterName = "@SubVertical";
                        sqlCom.Parameters.Add(SubVertical);

                        SqlParameter ClientName = new SqlParameter();
                        ClientName.SqlDbType = SqlDbType.VarChar;
                        if (ddlClientName.SelectedItem.Text == "--Select--")
                        {
                            ClientName.Value = "";
                        }
                        else
                        {
                            ClientName.Value = ddlClientName.SelectedItem.Text;
                        }
                        ClientName.ParameterName = "@ClientName";
                        sqlCom.Parameters.Add(ClientName);

                        SqlParameter Activity = new SqlParameter();
                        Activity.SqlDbType = SqlDbType.VarChar;

                        if (ddlActivity.SelectedItem.Text == "--Select--")
                        {
                            Activity.Value = "";
                        }
                        else
                        {
                            Activity.Value = ddlActivity.SelectedItem.Text;
                        }
                        Activity.ParameterName = "@Activity";
                        sqlCom.Parameters.Add(Activity);

                        SqlParameter Product = new SqlParameter();
                        Product.SqlDbType = SqlDbType.VarChar;
                        if (ddlProduct.SelectedItem.Text == "--Select--")
                        {
                            Product.Value = "";
                        }
                        else
                        {
                            Product.Value = ddlProduct.SelectedItem.Text;
                        }
                        Product.ParameterName = "@Product";
                        sqlCom.Parameters.Add(Product);

                        SqlParameter SubProduct = new SqlParameter();
                        SubProduct.SqlDbType = SqlDbType.VarChar;
                        if (ddlSubProduct.SelectedItem.Text == "--Select--")
                        {
                            SubProduct.Value = "";
                        }
                        else
                        {
                            SubProduct.Value = ddlSubProduct.SelectedItem.Text;
                        }
                        SubProduct.ParameterName = "@SubProduct";
                        sqlCom.Parameters.Add(SubProduct);

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
                        gvData.DataSource = null;
                        gvData.DataBind();

                        lblMsgXls.Text = "Please Select Month and Year ....!!!";
                        BtnExport.Visible = false;
                    }
                }
                else
                {
                    gvData.DataSource = null;
                    gvData.DataBind();

                    lblMsgXls.Text = "Please Select  MIS  ...!!!";
                    BtnExport.Visible = false;
                }

            }
            catch (Exception ex)
            {

                lblMsgXls.Visible = true;
                lblMsgXls.Text = "Error :" + ex.Message;
                BtnExport.Visible = false;

                gvData.DataSource = null;
                gvData.DataBind();
            }
            finally
            {
                sqlCon.Close();
                sqlCon.Dispose();
            }
            return result;
        }
        protected void BtnSearch_Click(object sender, EventArgs e)
        {

            BindReports();
        }

        protected void BtnBack_Click(object sender, EventArgs e)
        {
            bool Result = Convert.ToBoolean(ViewState["Result"]);

            if (Result == true)
            {
                Response.Redirect("CDMA_ReportExtract.aspx", false);
            }
            else
            {
                Response.Redirect("CDMA_Menu.aspx", false);
            }

        }

        protected void BtnExport_Click(object sender, EventArgs e)
        {

            Genrate_Excel();

        }

        private void Genrate_Excel()
        {
            String attachment = "attachment; filename=" + ddlMIS.SelectedItem.ToString() + ".xls";
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



    }
}