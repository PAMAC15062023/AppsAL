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
    public partial class InternalAudit_VerticalMaster : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                BindVerticalGrid();
            }
        }

        public void BindVerticalGrid()
        {
            SqlConnection SqlCon = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "InternalAudit_VerticalMaster_Grid";
                cmd.Connection = SqlCon;

                DataTable dt = new DataTable();
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                sda.Fill(dt);

                gvVertical.DataSource = dt;
                gvVertical.DataBind();
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }

        public void Clear()
        {
            txtVertical.Text = "";
            chkActive.Checked = false;
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            object SaveUSERInfo = (Object)Session["UserInfo"];

            string Userid = Convert.ToString(((UserInfo.structUSERInfo)(SaveUSERInfo)).UserID);

            if (txtVertical.Text == "")
            {
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "SomestartupScript", " alert('Please Enter Vertical');", true);
                return;
            }

            SqlConnection Con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            try 
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "InternalAudit_VerticalMasterSaveData_SP";
                cmd.Connection = Con;

                cmd.Parameters.AddWithValue("@ID", hdnID.Value);
                cmd.Parameters.AddWithValue("@Vertical", txtVertical.Text);
                cmd.Parameters.AddWithValue("@isactive", chkActive.Checked);
                cmd.Parameters.AddWithValue("@USerId", Userid);
                Con.Open();
                int result = cmd.ExecuteNonQuery();

                if (result > 0)
                {

                }
            }
            catch(Exception ex)
            {
                ex.ToString();
            }

            BindVerticalGrid();
            Clear();
        }

        protected void btn_Edit_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            GridViewRow gr = (GridViewRow)btn.NamingContainer;
            hdnID.Value = gvVertical.DataKeys[gr.RowIndex]["ID"].ToString();

            Label lblVertical = (Label)gr.FindControl("lblVertical");
            txtVertical.Text = lblVertical.Text.Trim();

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
        
        protected void gvVertical_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvVertical.PageIndex = e.NewPageIndex;
            BindVerticalGrid();
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("InternalAudit_Menu.aspx", false);
        }
    }
}