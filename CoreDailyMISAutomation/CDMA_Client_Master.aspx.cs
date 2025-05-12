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
    public partial class CDMA_Client_Master : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindSubVertical();
                BindClientName();
                BindActivity();
                BindProduct();
                BindSubProduct();
                BindClientNameGrid();
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

        public void BindClientNameGrid()
        {
            SqlConnection sqlCon = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "CDMA_ClientNameGrid_SP";
                cmd.Connection = sqlCon;

                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);

                gvClientName.DataSource = dt;
                gvClientName.DataBind();

            }
            catch (Exception ex)
            {

                ex.ToString();
            }

        }

        protected void gvClientName_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvClientName.PageIndex = e.NewPageIndex;
            BindClientNameGrid();
        }
        private void Clear()
        {
            ddlSubVertical.SelectedIndex = 0;
            txtClientName.Text = "";
            ddlActivity.SelectedIndex = 0;
            ddlProduct.SelectedIndex = 0;
            ddlSubProduct.SelectedIndex = 0;
            chkActive.Checked = false;
        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            lblmsg.Text = "";
            Object SaveUSERInfo = (Object)Session["UserInfo"];
            int SubProductID = 0;
            string Client_Name = string.Empty;

            string Userid = Convert.ToString(((UserInfo.structUSERInfo)(SaveUSERInfo)).UserID);

            if (ddlSubVertical.SelectedValue == "--Select--")
            {
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "SomestartupScript", " alert('Please Enter Sub Vertical');", true);
                return;
            }
            if (txtClientName.Text.Trim() == "" && ddlClientName.SelectedValue == "--Select--")
            {
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "SomestartupScript", " alert('Please Enter Client Name');", true);
                return;
            }
            if (ddlActivity.SelectedValue == "--Select--")
            {
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "SomestartupScript", " alert('Please Enter Activity');", true);
                return;
            }
            if (ddlProduct.SelectedValue == "--Select--")
            {
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "SomestartupScript", " alert('Please Enter Product');", true);
                return;
            }


            if (ddlSubProduct.SelectedValue != "--Select--")
            {
                SubProductID = Convert.ToInt32(ddlSubProduct.SelectedValue);
            }

            if (ddlClientName.SelectedValue != "--Select--")
            {
                hdnClientID.Value = ddlClientName.SelectedValue;
                Client_Name = ddlClientName.SelectedItem.Text.Trim();
            }
            else if (txtClientName.Text.Trim() != "")
            {
                Client_Name = txtClientName.Text.Trim();
            }


            SqlConnection sqlCon = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "CDMA_ClientNameMasterSaveData_SP";
                cmd.Connection = sqlCon;

                cmd.Parameters.AddWithValue("@ID", hdnClientID.Value);
                cmd.Parameters.AddWithValue("@AllMasterID", hdnAMID.Value);
                cmd.Parameters.AddWithValue("@ClientName", Client_Name);
                cmd.Parameters.AddWithValue("@isactive", chkActive.Checked);
                cmd.Parameters.AddWithValue("@USerId", Userid);
                cmd.Parameters.AddWithValue("@SubVertical", ddlSubVertical.SelectedItem.Text);
                cmd.Parameters.AddWithValue("@SubVerticalID", ddlSubVertical.SelectedValue);
                cmd.Parameters.AddWithValue("@ActivityID", ddlActivity.SelectedValue);
                cmd.Parameters.AddWithValue("@ProductID", ddlProduct.SelectedValue);
                cmd.Parameters.AddWithValue("@SubProductID", SubProductID);



                sqlCon.Open();
                int result = cmd.ExecuteNonQuery();

                if (result > 0)
                {
                    lblmsg.ForeColor = System.Drawing.Color.Green;
                    lblmsg.Text = "Record Inserted Successfully!!";
                }
                else
                {
                    lblmsg.ForeColor = System.Drawing.Color.Red;
                    lblmsg.Text = "Record alredy exists !!!";
                }

            }
            catch (Exception ex)
            {

                ex.ToString();
            }

            BindClientNameGrid();
            Clear();
        }

        protected void btn_Edit_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            GridViewRow gr = (GridViewRow)btn.NamingContainer;
            txtClientName.Enabled = false;

            //hdnID.Value = gvClientName.DataKeys[gr.RowIndex]["ID"].ToString();

            int rowIndex = ((sender as Button).NamingContainer as GridViewRow).RowIndex;

            hdnClientID.Value = gvClientName.DataKeys[rowIndex].Values[0].ToString();
            hdnAMID.Value = gvClientName.DataKeys[rowIndex].Values[1].ToString();
            int SubVerticalID = Convert.ToInt32(gvClientName.DataKeys[rowIndex].Values[3]);
            int activityID = Convert.ToInt32(gvClientName.DataKeys[rowIndex].Values[2]);
            int ProductID = Convert.ToInt32(gvClientName.DataKeys[rowIndex].Values[4]);
            int SubProductID = Convert.ToInt32(gvClientName.DataKeys[rowIndex].Values[5]);



            //Label lblSubVertical = (Label)gr.FindControl("lblSubVertical");
            //ddlSubVertical.SelectedItem.Text = lblSubVertical.Text.Trim();

            ddlSubVertical.SelectedValue = SubVerticalID.ToString();

            Label lblClientName = (Label)gr.FindControl("lblClientName");
            ddlClientName.SelectedValue = gvClientName.DataKeys[rowIndex].Values[0].ToString(); ;
            //txtClientName.Text = lblClientName.Text.Trim();

            //Label lblActivity = (Label)gr.FindControl("lblActivity");
            //ddlActivity.SelectedItem.Text = lblActivity.Text.Trim();


            ddlActivity.SelectedValue = activityID.ToString();

            //Label lblProduct = (Label)gr.FindControl("lblProduct");
            //ddlProduct.SelectedItem.Text = lblProduct.Text.Trim();

            ddlProduct.SelectedValue = ProductID.ToString();

            //Label lblSubProduct = (Label)gr.FindControl("lblSubProduct");
            //ddlSubProduct.SelectedItem.Text = lblSubProduct.Text.Trim();

            if (SubProductID != 0)
            {
                ddlSubProduct.SelectedValue = SubProductID.ToString();
            }

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

        protected void ddlClientName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlClientName.SelectedValue == "--Select--")
            {
                txtClientName.Enabled = true;
            }
            else
            {
                txtClientName.Enabled = false;
            }
            
        }

        protected void txtClientName_TextChanged(object sender, EventArgs e)
        {
            if (txtClientName.Text.Trim() == "" || txtClientName.Text.Trim() == null)
            {
                ddlClientName.Enabled = true;
            }
            else
            {
                ddlClientName.Enabled = false;
            }
        }
    }
}