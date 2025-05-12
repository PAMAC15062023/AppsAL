using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace CoreDailyMISAutomation
{
    public partial class CDMA_SubVerticalMaster : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindSubVerticalGrid();
            }
            
        }

        public void BindSubVerticalGrid()
        {
            SqlConnection sqlCon = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "CDMA_BindSubVertical_Master";
                cmd.Connection = sqlCon;
                
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);

                gvSubVertical.DataSource = dt;
                gvSubVertical.DataBind();

            }
            catch (Exception ex)
            {

                ex.ToString();
            }

        }
        private void Clear()
        {
            txtSubVerticalName.Text = "";
            chkActive.Checked = false;
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            Object SaveUSERInfo = (Object)Session["UserInfo"];

            string Userid = Convert.ToString(((UserInfo.structUSERInfo)(SaveUSERInfo)).UserID);

            if (txtSubVerticalName.Text.Trim() == "")
            {
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "SomestartupScript", " alert('Please Enter SubVertical');", true);
                return;
            }
            SqlConnection sqlCon = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "CDMA_SubVerticalMasterSaveData_SP";
                cmd.Connection = sqlCon;

                cmd.Parameters.AddWithValue("@ID", hdnID.Value);
                cmd.Parameters.AddWithValue("@SubVertical", txtSubVerticalName.Text);
                cmd.Parameters.AddWithValue("@isactive", chkActive.Checked);
                cmd.Parameters.AddWithValue("@USerId", Userid);
                sqlCon.Open();
                int result = cmd.ExecuteNonQuery();

                if (result > 0)
                {

                }

            }
            catch (Exception ex)
            {

                ex.ToString();
            }

            BindSubVerticalGrid();
            Clear();
        }

        protected void btn_Edit_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            GridViewRow gr = (GridViewRow)btn.NamingContainer;
            hdnID.Value = gvSubVertical.DataKeys[gr.RowIndex]["ID"].ToString();

            Label lblSubVerticalName = (Label)gr.FindControl("lblSubVerticalName");
            txtSubVerticalName.Text = lblSubVerticalName.Text.Trim();


            //Label lblpname = (Label)gr.FindControl("lblcode");
            //Label lblpname = (Label)gr.FindControl("lblID");

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
            Response.Redirect("CDMA_Menu.aspx", false);
        }

       
    }
}