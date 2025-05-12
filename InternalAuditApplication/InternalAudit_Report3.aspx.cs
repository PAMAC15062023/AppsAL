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

namespace InternalAuditApplication
{
    public partial class InternalAudit_Report3 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindQuarter();
                BindBranch();
                BindVertical();
                pnlGridForReport3.Visible = false;
                BtnExport.Visible = false;

                BindScopeNonScope();
            }
        }

        protected void BindQuarter()
        {
            try
            {
                SqlConnection sqlCon = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);

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

            }
        }

        protected void BindBranch()
        {
            try
            {
                SqlConnection sqlCon = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);

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

            }
        }

        protected void BindVertical()
        {
            try
            {
                SqlConnection sqlCon = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);

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

            }
        }

        protected void BindUnit(int BranchID)
        {
            try
            {
                SqlConnection sqlCon = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);

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

            }
        }

        /* protected void BindFinalStatus()
         {
             try
             {
                 SqlConnection sqlCon = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);

                 SqlCommand sqlCom = new SqlCommand();
                 sqlCom.Connection = sqlCon;
                 sqlCom.CommandType = CommandType.StoredProcedure;
                 sqlCom.CommandText = "InternalAudit_BindFinalStatus_SP";
                 sqlCom.CommandTimeout = 0;

                 SqlDataAdapter da = new SqlDataAdapter(sqlCom);
                 DataSet ds = new DataSet();
                 da.Fill(ds);

                 if (ds != null && ds.Tables.Count > 0)
                 {
                     ddlFinalStatus.DataTextField = "FinalStatus";
                     ddlFinalStatus.DataValueField = "ID";
                     ddlFinalStatus.DataSource = ds.Tables[0];
                     ddlFinalStatus.DataBind();

                     ddlFinalStatus.Items.Insert(0, "--Select--");
                     ddlFinalStatus.SelectedIndex = 0;
                 }
             }
             catch (Exception ex)
             {

             }
         }*/

        protected void GetReportDataSearchWise()
        {
            try
            {
                //add on 28/08/2024 start>>
                string msg = string.Empty;
                string Branch_2 = string.Empty;
                string Vertical_2 = string.Empty;
                string Unit_2 = string.Empty;
                string ScopeNonScope_2 = string.Empty;


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

                //<<add on 28/08/2024 end

                SqlConnection sqlCon = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);

                SqlCommand sqlCom = new SqlCommand();
                sqlCom.Connection = sqlCon;
                sqlCom.CommandType = CommandType.StoredProcedure;
                sqlCom.CommandText = "InternalAudit_GetDataForReport3_SP";
                sqlCom.CommandTimeout = 0;

                SqlParameter Quarter = new SqlParameter();
                Quarter.SqlDbType = SqlDbType.VarChar;
                Quarter.Value = ddlQuarter.SelectedItem.Text;
                Quarter.ParameterName = "@Quarter_HalfYear";
                sqlCom.Parameters.Add(Quarter);

                SqlParameter Branch = new SqlParameter();
                Branch.SqlDbType = SqlDbType.VarChar;
                Branch.Value = Branch_2;//ddlBranch.SelectedItem.Text;
                Branch.ParameterName = "@Branch";
                sqlCom.Parameters.Add(Branch);

                SqlParameter Vertical = new SqlParameter();
                Vertical.SqlDbType = SqlDbType.VarChar;
                Vertical.Value = Vertical_2;//ddlVertical.SelectedItem.Text;
                Vertical.ParameterName = "@Vertical";
                sqlCom.Parameters.Add(Vertical);

                SqlParameter Unit = new SqlParameter();
                Unit.SqlDbType = SqlDbType.VarChar;
                Unit.Value = Unit_2;//ddlUnit.SelectedItem.Text;
                Unit.ParameterName = "@Unit";
                sqlCom.Parameters.Add(Unit);

                SqlParameter UserID = new SqlParameter();
                UserID.SqlDbType = SqlDbType.VarChar;
                UserID.Value = Convert.ToString(Session["UserID"]);
                UserID.ParameterName = "@UserID";
                sqlCom.Parameters.Add(UserID);

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
                    GVDetailsFromReport3.DataSource = dt;
                    GVDetailsFromReport3.DataBind();
                    pnlGridForReport3.Visible = true;
                    BtnExport.Visible = true;

                    GVDetailsFromReport3.Rows[0].Cells[0].Enabled = false;
                    GVDetailsFromReport3.Rows[0].Cells[1].Enabled = false;
                }
                else
                {
                    GVDetailsFromReport3.DataSource = null;
                    GVDetailsFromReport3.DataBind();
                    pnlGridForReport3.Visible = false;
                    BtnExport.Visible = false;

                    lblMsgXls.Visible = true;
                    lblMsgXls.Text = "No Case Found";
                }
            }
            catch (Exception ex)
            {
                lblMsgXls.Text = ex.ToString();
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
            GetReportDataSearchWise();

        }

        protected void BtnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("InternalAudit_Menu.aspx", false);
        }

        private void Genrate_Excel()
        {
            String attachment = "attachment; filename=" + "Report3" + ".xls";
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
            GVDetailsFromReport3.EnableViewState = false;
            GVDetailsFromReport3.GridLines = GridLines.Both;
            GVDetailsFromReport3.RenderControl(htw);
            Response.Write(sw.ToString());

            Response.End();
            Response.Write(sw.ToString());
        }

        public override void VerifyRenderingInServerForm(Control control)
        {
            // base.VerifyRenderingInServerForm(control);
        }
        protected void BtnExport_Click(object sender, EventArgs e)
        {
            GetReportDataSearchWise();
            Genrate_Excel();
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