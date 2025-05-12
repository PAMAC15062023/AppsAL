using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

namespace InternalAuditApplication
{
    public partial class InternalAudit_AssessmentDetailsReport : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindQuarter();
                BindFinancialYear();
                BindBranch();
                BindVertical();
                pnlGridForReport1.Visible = false;
                BtnExport.Visible = false;

                BindScopeNonScope();

                int RoleID = Convert.ToInt32(Session["RoleID"]);
                if (RoleID == 1002)
                {
                    pnlSearchForReport1Details.Visible = true;
                    pnlreportDetails2.Visible = true;
                    pnlButtons.Visible = true;
                }
                if (RoleID == 2)
                {
                    pnlSearchForReport1Details.Visible = true;
                    pnlreportDetails2.Visible = false;
                    pnlButtons.Visible = true;
                }

                
            }
        }
        protected void BindFinancialYear()
        {
            try
            {
                SqlConnection sqlCon = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());

                SqlCommand sqlCom = new SqlCommand();
                sqlCom.Connection = sqlCon;
                sqlCom.CommandType = CommandType.StoredProcedure;
                sqlCom.CommandText = "InternalAudit_BindFinancialYear_SP";
                sqlCom.CommandTimeout = 0;

                SqlDataAdapter da = new SqlDataAdapter(sqlCom);
                DataSet ds = new DataSet();
                da.Fill(ds);

                if (ds != null && ds.Tables.Count > 0)
                {
                    ddlFinancialYear.DataTextField = "FinancialYear";
                    ddlFinancialYear.DataValueField = "ID";
                    ddlFinancialYear.DataSource = ds.Tables[0];
                    ddlFinancialYear.DataBind();

                    ddlFinancialYear.Items.Insert(0, "--Select--");
                    ddlFinancialYear.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                string msg = ex.ToString();
            }
        }
        protected void BindQuarter()
        {
            try
            {
                SqlConnection sqlCon = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());

                SqlCommand sqlCom = new SqlCommand();
                sqlCom.Connection = sqlCon;
                sqlCom.CommandType = CommandType.StoredProcedure;
                sqlCom.CommandText = "InternalAudit_BindQuarter_SP";
                sqlCom.CommandTimeout = 0;

                SqlDataAdapter da = new SqlDataAdapter(sqlCom);
                DataSet ds = new DataSet();
                da.Fill(ds);

                if (ds != null && ds.Tables.Count > 0)
                {
                    ddlQuarter.DataTextField = "Quarter";
                    ddlQuarter.DataValueField = "ID";
                    ddlQuarter.DataSource = ds.Tables[0];
                    ddlQuarter.DataBind();

                    ddlQuarter.Items.Insert(0, "--Select--");
                    ddlQuarter.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                string msg = ex.ToString();
            }
        }

        protected void BindBranch()
        {
            try
            {
                SqlConnection sqlCon = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());

                SqlCommand sqlCom = new SqlCommand();
                sqlCom.Connection = sqlCon;
                sqlCom.CommandType = CommandType.StoredProcedure;
                sqlCom.CommandText = "InternalAudit_BindBranch_SP";
                sqlCom.CommandTimeout = 0;

                SqlDataAdapter da = new SqlDataAdapter(sqlCom);
                DataSet ds = new DataSet();
                da.Fill(ds);

                if (ds != null && ds.Tables.Count > 0)
                {
                    ddlBranch.DataTextField = "Location";
                    ddlBranch.DataValueField = "ID";
                    ddlBranch.DataSource = ds.Tables[0];
                    ddlBranch.DataBind();

                    ddlBranch.Items.Insert(0, "--Select--");
                    ddlBranch.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                string msg = ex.ToString();
            }
        }

        protected void BindVertical()
        {
            try
            {
                SqlConnection sqlCon = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());

                SqlCommand sqlCom = new SqlCommand();
                sqlCom.Connection = sqlCon;
                sqlCom.CommandType = CommandType.StoredProcedure;
                sqlCom.CommandText = "InternalAudit_BindVertical_SP";
                sqlCom.CommandTimeout = 0;

                SqlDataAdapter da = new SqlDataAdapter(sqlCom);
                DataSet ds = new DataSet();
                da.Fill(ds);

                if (ds != null && ds.Tables.Count > 0)
                {
                    ddlVertical.DataTextField = "Vertical";
                    ddlVertical.DataValueField = "ID";
                    ddlVertical.DataSource = ds.Tables[0];
                    ddlVertical.DataBind();

                    ddlVertical.Items.Insert(0, "--Select--");
                    ddlVertical.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                string msg = ex.ToString();
            }
        }

        protected void BindUnit(int BranchID)
        {
            try
            {
                SqlConnection sqlCon = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());

                SqlCommand sqlCom = new SqlCommand();
                sqlCom.Connection = sqlCon;
                sqlCom.CommandType = CommandType.StoredProcedure;
                sqlCom.CommandText = "InternalAudit_BindUnit_ByBranch_SP";
                sqlCom.CommandTimeout = 0;

                SqlParameter Branch = new SqlParameter();
                Branch.SqlDbType = SqlDbType.VarChar;
                Branch.Value = BranchID;
                Branch.ParameterName = "@BranchID";
                sqlCom.Parameters.Add(Branch);


                SqlDataAdapter da = new SqlDataAdapter(sqlCom);
                DataSet ds = new DataSet();
                da.Fill(ds);

                if (ds != null && ds.Tables.Count > 0)
                {
                    ddlUnit.DataTextField = "Unit";
                    ddlUnit.DataValueField = "ID";
                    ddlUnit.DataSource = ds.Tables[0];
                    ddlUnit.DataBind();

                    ddlUnit.Items.Insert(0, "--Select--");
                    ddlUnit.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                string msg = ex.ToString();
            }
        }

        protected void ddlBranch_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlBranch.SelectedValue != "--Select--")
            {
                BindUnit(Convert.ToInt32(ddlBranch.SelectedValue));
                ddlUnit.Enabled = true;
            }
            else
            {
                ddlUnit.SelectedValue = "--Select--";
                ddlUnit.Enabled = false;
            }
        }
        protected void ClearData()
        {
            ddlQuarter.SelectedIndex = 0;
            ddlBranch.SelectedIndex = 0;
            ddlVertical.SelectedIndex = 0;
            ddlUnit.SelectedIndex = 0;
        }
        protected void BtnSearch_Click(object sender, EventArgs e)
        {
            int RoleID = Convert.ToInt32(Session["RoleID"]);
            if (RoleID == 1002)
            {
                GetReportDataSearchWiseAdmin();
            }
            if (RoleID == 2)
            {
                GetReportDataSearchWiseAuditee();
            }

        }

        protected void BtnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("InternalAudit_Menu.aspx", false);
        }

        protected void BtnExport_Click(object sender, EventArgs e)
        {
            GetReportDataSearchWiseAdmin();
            GetReportDataSearchWiseAuditee();
            Genrate_Excel();
        }
        public override void VerifyRenderingInServerForm(Control control)
        {
            // base.VerifyRenderingInServerForm(control);
        }
        protected void GetReportDataSearchWiseAdmin()
        {
            try
            {
                string msg = string.Empty;
                string Branch_2 = string.Empty;
                string Vertical_2 = string.Empty;
                string Unit_2 = string.Empty;
                string ScopeNonScope_2 = string.Empty;

                if (ddlFinancialYear.SelectedItem.Text == "--Select--")
                {
                    msg = msg + "Please Select Financial Year ";
                }
                if (ddlQuarter.SelectedItem.Text == "--Select--")
                {
                    msg = msg + "Please Select Quarter ";
                }
                if (msg != "")
                {

                    ClientScript.RegisterStartupScript(Page.GetType(), "mykey", "alert('" + msg + "');", true);
                    return;
                }


                if (ddlBranch.SelectedItem.Text != "--Select--")
                {
                    Branch_2 = ddlBranch.SelectedItem.Text;
                }
                if (ddlVertical.SelectedItem.Text != "--Select--")
                {
                    Vertical_2 = ddlVertical.SelectedItem.Text;
                }

                if (ddlUnit.SelectedIndex != -1)
                {
                    if (ddlUnit.SelectedItem.Text != "--Select--")
                    {
                        Unit_2 = ddlUnit.SelectedItem.Text;
                    }
                }

                if (ddlScopeNonScope.SelectedItem.Text != "--Select--")
                {
                    ScopeNonScope_2 = ddlScopeNonScope.SelectedItem.Text;
                }

                SqlConnection sqlCon = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());

                SqlCommand sqlCom = new SqlCommand();
                sqlCom.Connection = sqlCon;
                sqlCom.CommandType = CommandType.StoredProcedure;
                sqlCom.CommandText = "InternalAudit_AssessmentDetailsReport_SP";
                sqlCom.CommandTimeout = 0;

                SqlParameter FinancialYear = new SqlParameter();
                FinancialYear.SqlDbType = SqlDbType.VarChar;
                FinancialYear.Value = ddlFinancialYear.SelectedItem.Text;
                FinancialYear.ParameterName = "@FinancialYear";
                sqlCom.Parameters.Add(FinancialYear);

                SqlParameter Quarter = new SqlParameter();
                Quarter.SqlDbType = SqlDbType.VarChar;
                Quarter.Value = ddlQuarter.SelectedItem.Text;
                Quarter.ParameterName = "@Quarter";
                sqlCom.Parameters.Add(Quarter);

                SqlParameter Branch = new SqlParameter();
                Branch.SqlDbType = SqlDbType.VarChar;
                Branch.Value = Branch_2;
                Branch.ParameterName = "@Branch";
                sqlCom.Parameters.Add(Branch);

                SqlParameter Vertical = new SqlParameter();
                Vertical.SqlDbType = SqlDbType.VarChar;
                Vertical.Value = Vertical_2;
                Vertical.ParameterName = "@Vertical";
                sqlCom.Parameters.Add(Vertical);

                SqlParameter Unit = new SqlParameter();
                Unit.SqlDbType = SqlDbType.VarChar;
                Unit.Value = Unit_2;
                Unit.ParameterName = "@Unit";
                sqlCom.Parameters.Add(Unit);

                SqlParameter ScopeNonScope = new SqlParameter();
                ScopeNonScope.SqlDbType = SqlDbType.VarChar;
                ScopeNonScope.Value = ScopeNonScope_2;
                ScopeNonScope.ParameterName = "@ScopeNonScope";
                sqlCom.Parameters.Add(ScopeNonScope);

                sqlCon.Open();

                SqlDataAdapter sqlDA = new SqlDataAdapter();
                sqlDA.SelectCommand = sqlCom;

                DataTable dt = new DataTable();
                sqlDA.Fill(dt);

                sqlCon.Close();

                if (dt.Rows.Count > 0)
                {
                    GVDetailsReport.DataSource = dt;
                    GVDetailsReport.DataBind();

                    BtnExport.Visible = true;
                    pnlGridForReport1.Visible = true;
                    GVDetailsReport.Rows[0].Cells[0].Enabled = false;
                    GVDetailsReport.Rows[0].Cells[1].Enabled = false;

                    lblMsgXls.Text = ""; //add on 28/08/2024 by rutuja
                }
                else
                {
                    GVDetailsReport.DataSource = null;
                    GVDetailsReport.DataBind();
                    BtnExport.Visible = false;
                    pnlGridForReport1.Visible = false;

                    lblMsgXls.Visible = true;
                    lblMsgXls.Text = "No Case Found";
                }
            }
            catch (Exception ex)
            {
                lblMsgXls.Text = ex.ToString();
            }
        }

        protected void GetReportDataSearchWiseAuditee()
        {
            try
            {
                string msg = string.Empty;

                if (ddlFinancialYear.SelectedItem.Text == "--Select--")
                {
                    msg = msg + "Please Select Financial Year ";
                }
                if (ddlQuarter.SelectedItem.Text == "--Select--")
                {
                    msg = msg + "Please Select Quarter ";
                }

                if (msg != "")
                {

                    ClientScript.RegisterStartupScript(Page.GetType(), "mykey", "alert('" + msg + "');", true);
                    return;
                }

                string ScopeNonScope = "";

                if (ddlScopeNonScope.SelectedItem.Text != "--Select--")
                {
                    ScopeNonScope = ddlScopeNonScope.SelectedItem.Text;
                }

                SqlConnection sqlCon = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());

                SqlCommand sqlCom = new SqlCommand();
                sqlCom.Connection = sqlCon;
                sqlCom.CommandType = CommandType.StoredProcedure;
                sqlCom.CommandText = "InternalAudit_AssessmentDetailsReportForAuditee_SP";
                sqlCom.CommandTimeout = 0;

                SqlParameter FinancialYear = new SqlParameter();
                FinancialYear.SqlDbType = SqlDbType.VarChar;
                FinancialYear.Value = ddlFinancialYear.SelectedItem.Text;
                FinancialYear.ParameterName = "@FinancialYear";
                sqlCom.Parameters.Add(FinancialYear);

                SqlParameter Quarter = new SqlParameter();
                Quarter.SqlDbType = SqlDbType.VarChar;
                Quarter.Value = ddlQuarter.SelectedItem.Text;
                Quarter.ParameterName = "@Quarter";
                sqlCom.Parameters.Add(Quarter);

                SqlParameter Branch = new SqlParameter();
                Branch.SqlDbType = SqlDbType.VarChar;
                Branch.Value = Convert.ToString(Session["CPC"]);
                Branch.ParameterName = "@Branch";
                sqlCom.Parameters.Add(Branch);

                SqlParameter Vertical = new SqlParameter();
                Vertical.SqlDbType = SqlDbType.VarChar;
                Vertical.Value = Convert.ToString(Session["Vertical"]);
                Vertical.ParameterName = "@Vertical";
                sqlCom.Parameters.Add(Vertical);

                SqlParameter Scope_NonScope = new SqlParameter();
                Scope_NonScope.SqlDbType = SqlDbType.VarChar;
                Scope_NonScope.Value = ScopeNonScope;
                Scope_NonScope.ParameterName = "@ScopeNonScope";
                sqlCom.Parameters.Add(Scope_NonScope);

                sqlCon.Open();

                SqlDataAdapter sqlDA = new SqlDataAdapter();
                sqlDA.SelectCommand = sqlCom;

                DataTable dt = new DataTable();
                sqlDA.Fill(dt);

                sqlCon.Close();

                if (dt.Rows.Count > 0)
                {
                    GVDetailsReport.DataSource = dt;
                    GVDetailsReport.DataBind();

                    BtnExport.Visible = true;
                    pnlGridForReport1.Visible = true;
                    GVDetailsReport.Rows[0].Cells[0].Enabled = false;
                    GVDetailsReport.Rows[0].Cells[1].Enabled = false;

                    lblMsgXls.Text = ""; //add on 28/08/2024 by rutuja
                }
                else
                {
                    GVDetailsReport.DataSource = null;
                    GVDetailsReport.DataBind();
                    BtnExport.Visible = false;
                    pnlGridForReport1.Visible = false;

                    lblMsgXls.Visible = true;
                    lblMsgXls.Text = "No Case Found";
                }
            }
            catch (Exception ex)
            {
                lblMsgXls.Text = ex.ToString();
            }
        }
        private void Genrate_Excel()
        {
            String attachment = "attachment; filename=" + "Assessment Details Report" + ".xls";
            Response.AddHeader("content-disposition", attachment);
            Response.ContentType = "application/ms-excel";
            StringWriter sw = new System.IO.StringWriter();
            HtmlTextWriter htw = new HtmlTextWriter(sw);
            GVDetailsReport.AllowPaging = false;
            GetReportDataSearchWiseAdmin();
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
            GVDetailsReport.EnableViewState = false;
            GVDetailsReport.GridLines = GridLines.Both;
            GVDetailsReport.RenderControl(htw);
            Response.Write(sw.ToString());

            Response.End();
            Response.Write(sw.ToString());
        }

        protected void GVDetailsReport_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GVDetailsReport.PageIndex = e.NewPageIndex;

            int RoleID = Convert.ToInt32(Session["RoleID"]);
            if (RoleID == 1002)
            {
                GetReportDataSearchWiseAdmin();
            }
            if (RoleID == 2)
            {
                GetReportDataSearchWiseAuditee();
            }
        }
        protected void BindScopeNonScope()
        {
            try
            {
                SqlConnection sqlCon = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);

                SqlCommand sqlCom = new SqlCommand();
                sqlCom.Connection = sqlCon;
                sqlCom.CommandType = CommandType.StoredProcedure;
                sqlCom.CommandText = "InternalAudit_BindScopeNonScope_SP";
                sqlCom.CommandTimeout = 0;

                SqlDataAdapter da = new SqlDataAdapter(sqlCom);
                DataSet ds = new DataSet();
                da.Fill(ds);

                if (ds != null && ds.Tables.Count > 0)
                {
                    ddlScopeNonScope.DataTextField = "ScopeORNonscope";
                    ddlScopeNonScope.DataValueField = "ScopeORNonscope";
                    ddlScopeNonScope.DataSource = ds.Tables[0];
                    ddlScopeNonScope.DataBind();

                    ddlScopeNonScope.Items.Insert(0, "--Select--");
                    ddlScopeNonScope.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                lblMsgXls.Visible = true;
                lblMsgXls.Text = ex.ToString();
            }
        }
    }
}