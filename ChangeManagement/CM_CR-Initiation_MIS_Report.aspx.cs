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
    public partial class CM_CR_Initiation_MIS_Report : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindVertical();
                BindBranch();
                lblMsgXls.Visible = false;
                btnExport.Visible = true;
            }
            
        }

        protected void btnExport_Click(object sender, EventArgs e)
        {
            bool result = false;

            if(ddlVertical.SelectedItem.Text!=""  && ddlVertical.SelectedItem.Text != "--Select Vertical--")
            {
                if(ddlBranch.SelectedItem.Text != "")
                {
                    result = BindReports();
                }
                else
                {
                    lblMsgXls.Visible = true;
                    lblMsgXls.Text = "Please select Branch";
                    return;
                }
            }
            else
            {
                lblMsgXls.Visible = true;
                lblMsgXls.Text = "Please select Vertical and Branch";
                return;
            }

            if (result == true)
            {
                Generate_Excel();
                ClearData();
            }
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("CM_MenuPage.aspx", false);
        }

        public override void VerifyRenderingInServerForm(Control control)
        {
            //base.VerifyRenderingInServerForm(control);
        }

        protected bool BindReports()
        {
            lblMsgXls.Text = "";

            bool result = false;

            SqlConnection sqlCon = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());

            try
            {
                SqlCommand sqlCom = new SqlCommand();
                sqlCom.Connection = sqlCon;
                sqlCom.CommandType = CommandType.StoredProcedure;
                sqlCom.CommandText = "CR_MIS_Report";
                sqlCom.CommandTimeout = 0;

                //SqlParameter userid = new SqlParameter();
                //userid.SqlDbType = SqlDbType.VarChar;
                //userid.Value = Session["UserID"].ToString();
                //userid.ParameterName = "@UserID";
                //sqlCom.Parameters.Add(userid);

                //SqlParameter roleid = new SqlParameter();
                //roleid.SqlDbType = SqlDbType.Int;
                //roleid.Value = Convert.ToInt32(Session["Roleid"].ToString());
                //roleid.ParameterName = "@RoleID";
                //sqlCom.Parameters.Add(roleid);

                SqlParameter vertical = new SqlParameter();
                vertical.SqlDbType = SqlDbType.VarChar;
                vertical.Value = ddlVertical.SelectedItem.Text;
                vertical.ParameterName = "@CR_Vertical";
                sqlCom.Parameters.Add(vertical);

                SqlParameter branch = new SqlParameter();
                branch.SqlDbType = SqlDbType.Int;
                branch.Value = ddlBranch.SelectedValue;
                branch.ParameterName = "@CR_Branch";
                sqlCom.Parameters.Add(branch);

                SqlParameter fromdate = new SqlParameter();
                fromdate.SqlDbType = SqlDbType.DateTime;
                if (!string.IsNullOrEmpty(txtFromDate.Text)) //(txtFromDate.Text!="")
                {
                    fromdate.Value = Convert.ToDateTime(txtFromDate.Text);
                }
                else
                {
                    fromdate.Value = DBNull.Value;
                }

                fromdate.ParameterName = "@FromDate";
                sqlCom.Parameters.Add(fromdate);

                SqlParameter todate = new SqlParameter();
                todate.SqlDbType = SqlDbType.DateTime;
                if (!string.IsNullOrEmpty(txtToDate.Text)) //(txtToDate.Text!="")
                {
                    todate.Value = Convert.ToDateTime(txtToDate.Text);
                }
                else
                {
                    todate.Value = DBNull.Value;
                }
                todate.ParameterName = "@ToDate";
                sqlCom.Parameters.Add(todate);

                sqlCon.Open();

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

        private void ClearData()
        {
            ddlVertical.SelectedIndex = 0;
            ddlBranch.SelectedIndex = 0;
            txtFromDate.Text = "";
            txtToDate.Text = "";
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

        protected void BindBranch()
        {
            try
            {
                SqlConnection sqlCon = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());

                SqlCommand sqlCom = new SqlCommand();
                sqlCom.Connection = sqlCon;
                sqlCom.CommandType = CommandType.StoredProcedure;
                sqlCom.CommandText = "CM_Branch_Master_SP";
                sqlCom.CommandTimeout = 0;

                SqlDataAdapter da = new SqlDataAdapter(sqlCom);
                DataSet ds = new DataSet();
                da.Fill(ds);

                if (ds != null && ds.Tables.Count > 0)
                {
                    ddlBranch.DataTextField = "BranchName";
                    ddlBranch.DataValueField = "BranchId";
                    ddlBranch.DataSource = ds.Tables[0];
                    ddlBranch.DataBind();

                    ddlBranch.Items.Insert(0, "--Select Branch--");
                    ddlBranch.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
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
                sqlCom.CommandText = "CM_Vertical_Master_SP";
                sqlCom.CommandTimeout = 0;

                SqlDataAdapter da = new SqlDataAdapter(sqlCom);
                DataSet ds = new DataSet();
                da.Fill(ds);

                if (ds != null && ds.Tables.Count > 0)
                {
                    ddlVertical.DataTextField = "vertical_name";
                    ddlVertical.DataValueField = "vertical_id";
                    ddlVertical.DataSource = ds.Tables[0];
                    ddlVertical.DataBind();

                    ddlVertical.Items.Insert(0, "--Select Vertical--");
                    ddlVertical.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
            }
        }
        protected void ddlVertical_SelectedIndexChanged(object sender, EventArgs e)
        {
            //btnExport.Visible = true;
        }
    }
}