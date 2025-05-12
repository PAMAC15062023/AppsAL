using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace InternalAuditApplication
{
    public partial class InternalAudit_UnitMaster : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindBranch();
                BindUnitGrid();
            }
        }

        public void BindBranch()
        {
                try
                {
                    SqlConnection sqlCon = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());

                    SqlCommand sqlCom = new SqlCommand();
                    sqlCom.Connection = sqlCon;
                    sqlCom.CommandType = CommandType.StoredProcedure;
                    sqlCom.CommandText = "InternalAudit_BindBranch_Master";
                    sqlCom.CommandTimeout = 0;

                    SqlDataAdapter da = new SqlDataAdapter(sqlCom);
                    DataSet ds = new DataSet();
                    da.Fill(ds);

                    if (ds != null && ds.Tables.Count > 0)
                    {
                    DDLBranch.DataTextField = "Location";
                    DDLBranch.DataValueField = "ID";
                    DDLBranch.DataSource = ds.Tables[0];
                    DDLBranch.DataBind();

                    DDLBranch.Items.Insert(0, "--Select--");
                    DDLBranch.SelectedIndex = 0;
                    }
                }
                catch (Exception ex)
                {

                }
            
        }

        public void BindUnitGrid()
        {
            SqlConnection sqlcon = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "InternalAudit_UnitMaster_Grid";
                cmd.Connection = sqlcon;

                DataTable dt = new DataTable();
                SqlDataAdapter sda = new SqlDataAdapter(cmd);

                sda.Fill(dt);
                gvUnit.DataSource = dt;
                gvUnit.DataBind();
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }

        public void Clear()
        {
            DDLBranch.SelectedIndex = 0;
            txtUnit.Text = "";
            chkActive.Checked = false;
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            object SaveUSERInfo = (Object)Session["UserInfo"];

            string Userid = Convert.ToString(((UserInfo.structUSERInfo)(SaveUSERInfo)).UserID);

            if (txtUnit.Text == "")
            {
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "SomestartupScript", " alert('Please Enter Unit');", true);
                return;
            }

            SqlConnection Con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "InternalAudit_UnitMasterSaveData_SP";
                cmd.Connection = Con;

                cmd.Parameters.AddWithValue("@ID", hdnID.Value);
                cmd.Parameters.AddWithValue("@Branch", DDLBranch.SelectedValue);
                cmd.Parameters.AddWithValue("@Unit", txtUnit.Text);
                cmd.Parameters.AddWithValue("@isactive", chkActive.Checked);
                cmd.Parameters.AddWithValue("@USerId", Userid);
                Con.Open();
                int result = cmd.ExecuteNonQuery();

                if (result > 0)
                {

                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }

           
            BindUnitGrid();
            Clear();
        }

        protected void btn_Edit_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            GridViewRow gr = (GridViewRow)btn.NamingContainer;

            int rowIndex = ((sender as Button).NamingContainer as GridViewRow).RowIndex;

            hdnID.Value = Convert.ToString(gvUnit.DataKeys[rowIndex].Values[0]);
            int BranchID = Convert.ToInt32(gvUnit.DataKeys[rowIndex].Values[1]);

            Label lblBranchGrid = (Label)gr.FindControl("lblBranchGrid");
            DDLBranch.SelectedValue = Convert.ToString(BranchID);

            Label lblUnit = (Label)gr.FindControl("lblUnit");
            txtUnit.Text = lblUnit.Text.Trim();

            Label lblisActive = (Label)gr.FindControl("lblisActive");
            string data = lblisActive.Text.Trim();
            if (data == "True" || data == "Active")
            {
                chkActive.Checked = true;

            }
            else
            {
                chkActive.Checked = false;

            }
        }
       
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("InternalAudit_Menu.aspx", false);
        }

        protected void gvUnit_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvUnit.PageIndex = e.NewPageIndex;
            BindUnitGrid();
        }
    }
}