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
    public partial class InternalAudit_BranchMaster : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                BindBranchGrid();
            }
        }

        public void BindBranchGrid()
        {
            SqlConnection sqlcon = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "InternalAudit_BranchMaster_Grid";
                cmd.Connection = sqlcon;

                DataTable dt = new DataTable();
                SqlDataAdapter sda = new SqlDataAdapter(cmd);

                sda.Fill(dt);
                gvBranch.DataSource = dt;
                gvBranch.DataBind();
            }
            catch(Exception ex)
            {
                ex.ToString();
            }
        }

        public void Clear()
        {
            txtBranch.Text = "";
            chkActive.Checked = false;
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            object SaveUSERInfo = (Object)Session["UserInfo"];

            string Userid = Convert.ToString(((UserInfo.structUSERInfo)(SaveUSERInfo)).UserID);

            if (txtBranch.Text == "")
            {
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "SomestartupScript", " alert('Please Enter Branch');", true);
                return;
            }

            SqlConnection Con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "InternalAudit_BranchMasterSaveData_SP";
                cmd.Connection = Con;

                cmd.Parameters.AddWithValue("@ID", hdnID.Value);
                cmd.Parameters.AddWithValue("@Branch", txtBranch.Text);
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

            BindBranchGrid();
            Clear();
        }

        protected void btn_Edit_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            GridViewRow gr = (GridViewRow)btn.NamingContainer;
            hdnID.Value = gvBranch.DataKeys[gr.RowIndex]["ID"].ToString();

            Label lblBranch = (Label)gr.FindControl("lblBranch");
            txtBranch.Text = lblBranch.Text.Trim();

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
        protected void gvBranch_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvBranch.PageIndex = e.NewPageIndex;
            BindBranchGrid();
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("InternalAudit_Menu.aspx", false);
        }
    }
}