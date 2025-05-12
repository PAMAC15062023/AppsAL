using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LNTFinance.Pages 
{
    public partial class LNT_RoleMaster : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    Get_RoleMasterDetails();
                    Register_ControlswithJavascript();
                }
            }
            catch (Exception ex)
            {
                lblMessage.Text = ex.Message;
                lblMessage.CssClass = "ErrorMessage";
                lblMessage.Visible = true;
            }
        }
        private void Get_RoleMasterDetails()
        {
            try
            {
                SqlConnection sqlCon = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

                SqlCommand cmd = new SqlCommand("LNT_GetRoleMasterDetails_SP", sqlCon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ClientId", Session["ClientID"]); /*Added on 19/07/2022*/
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adp.Fill(ds);

                grv_Data.DataSource = ds;
                grv_Data.DataBind();

            }
            catch (Exception ex)
            {
                lblMessage.Visible = true;
                lblMessage.Text = ex.Message;
                lblMessage.CssClass = "ErrorMessage";
            }
        }
        private void Register_ControlswithJavascript()
        {
            btnSave.Attributes.Add("onclick", "javascript:return ValidateSave();");
            btnAddNew.Attributes.Add("onclick", "javascript:return ValidateAddNew();");
        }
        private void Reset_Control()
        {
            hdnID.Value = "0";
            txtRoleName.Text = "";
            ddlIsActivate.SelectedIndex = 0;
        }
        private void SaveData()
        {
            Object SaveUSERInfo = (Object)Session["UserInfo"];

            SqlConnection sqlCon = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

            SqlCommand cmd = new SqlCommand("AdminMaster_Insert_GroupInfo_SP", sqlCon);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ID", hdnID.Value);
            //cmd.Parameters.AddWithValue("@UserId", Convert.ToString(((UserInfo.structUSERInfo)(SaveUSERInfo)).UserId));
            cmd.Parameters.AddWithValue("@RoleName", txtRoleName.Text.Trim());
            cmd.Parameters.AddWithValue("@IsActivate", Convert.ToBoolean(ddlIsActivate.SelectedItem.Value));
            sqlCon.Open(); //Added on 30/09/2022
            int Rows = cmd.ExecuteNonQuery();
            sqlCon.Close(); //Added on 30/09/2022
            if (Rows > 0)
            {
                lblMessage.Text = "Update Successfully!";
                lblMessage.CssClass = "UpdateMessage";
                lblMessage.Visible = true;
            }
           
        }
        protected void grv_Data_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes.Add("onclick", "javascript:Pro_SelectRow('" + e.Row.RowIndex + "','" + e.Row.Cells[0].Text + "')");
                e.Row.Attributes.Add("onmouseover", "javascript:hover('in','" + e.Row.RowIndex + "');");
                e.Row.Attributes.Add("onmouseout", "javascript:hover('out','" + e.Row.RowIndex + "');");

            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            SaveData();
            Get_RoleMasterDetails();
            Reset_Control();
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Reset_Control();
            Response.Redirect("MenuPage.aspx", false);
        }
    }
}