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
    public partial class CDMA_ManualUpdate : System.Web.UI.Page
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
            }
            else
            {
                ddlClientName.Items.Clear();
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
                ddlActivity.Items.Clear();
                ddlProduct.Items.Clear();
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

        protected void ddlProduct_SelectedIndexChanged(object sender, EventArgs e)
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
                ddlSubProduct.Enabled = true;
                ddlSubProduct.DataTextField = "SubProduct";
                ddlSubProduct.DataValueField = "ID";
                ddlSubProduct.DataSource = ds.Tables[0];
                ddlSubProduct.DataBind();

                ddlSubProduct.Items.Insert(0, "--Select--");
                ddlSubProduct.SelectedIndex = 0;
            }
            else
            {
                ddlSubProduct.Enabled = false;
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

        protected void ddlMISMonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Get the selected month from the dropdown list
            int selectedMonth = Convert.ToInt32(ddlMISMonth.SelectedValue);

            // Get the current year (you can also allow user input for year if needed)
            int currentYear = DateTime.Now.Year;
            int previousYear = DateTime.Now.Year;

            // Handle the case when the selected month is January (i.e., previous month is December of the previous year)
            if (selectedMonth == 1)
            {
                previousYear--; // Move to the previous year
                selectedMonth = 12; // Set to December

                DateTime selectedDate2 = new DateTime(previousYear, selectedMonth, 1);

                txtPreviousMonthName.Text = selectedDate2.ToString("MMMM yyyy");
                txtCurrentMonthName.Text = ddlMISMonth.SelectedItem.Text + " " + currentYear;
            }

            else
            {
                // Calculate the previous month

                DateTime selectedDate = new DateTime(currentYear, selectedMonth, 1);
                DateTime previousMonthDate = selectedDate.AddMonths(-1);

                // Display the previous month in the TextBox
                txtPreviousMonthName.Text = previousMonthDate.ToString("MMMM yyyy");
                txtCurrentMonthName.Text = ddlMISMonth.SelectedItem.Text + " " + currentYear;
            }
        }

        protected void Clear()
        {
            ddlSubVertical.SelectedIndex = 0;
            ddlClientName.SelectedIndex = 0;
            ddlActivity.SelectedIndex = 0;
            ddlProduct.SelectedIndex = 0;
            ddlSubProduct.SelectedIndex = 0;
            ddlMISMonth.SelectedIndex = 0;
            txtPreviousMonthName.Text = "";
            txtPreviousMonthVolume.Text = "";
            txtCurrentMonthName.Text = "";
            txtCurrentMonthVolume.Text = "";
            txtIncDecCount.Text = "";
            txtIncDecPer.Text = "";
            txtDuplicateandHoldCaseCount.Text = "";
            txtStaffCount.Text = "";
            txtWithinTATCaseCount.Text = "";
            txtOutOfTATCaseCount.Text = "";
            txtQCCount.Text = "";
            txtErrorCount.Text = "";
            txtComplaintsCount.Text = "";
            ddlDeviation.SelectedIndex = 0;
            txtCountOfCases.Text = "";
            ddlCalculusData.SelectedIndex = 0;
            txtRemark.Text = "";

        }
        protected void Save()
        {
            lblmsg.Text = "";
            Object SaveUSERInfo = (Object)Session["UserInfo"];
            string SubProduct = string.Empty;
            string Client_Name = string.Empty;

            string Userid = Convert.ToString(((UserInfo.structUSERInfo)(SaveUSERInfo)).UserID);

            if (ddlSubVertical.SelectedValue == "--Select--")
            {
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "SomestartupScript", " alert('Please Enter Sub Vertical');", true);
                return;
            }
            if (ddlClientName.SelectedValue == "--Select--")
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
                SubProduct = Convert.ToString(ddlSubProduct.SelectedItem.Text.Trim());
            }
            if (ddlMISMonth.SelectedValue == "0")
            {
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "SomestartupScript", " alert('Please Enter MIS Month');", true);
                return;
            }
            if (txtPreviousMonthVolume.Text == "")
            {
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "SomestartupScript", " alert('Please Enter Previous Month Volume');", true);
                return;
            }
            if (txtCurrentMonthVolume.Text == "")
            {
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "SomestartupScript", " alert('Please Enter Current Month Volume');", true);
                return;
            }
            if (txtIncDecCount.Text == "")
            {
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "SomestartupScript", " alert('Please Enter Increased/Decreased count');", true);
                return;
            }
            if (txtIncDecPer.Text == "")
            {
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "SomestartupScript", " alert('Please Enter Increased/Decreased percentage');", true);
                return;
            }
            if (txtDuplicateandHoldCaseCount.Text == "")
            {
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "SomestartupScript", " alert('Please Enter Duplicate and Hold cases (Count)');", true);
                return;
            }
            if (txtStaffCount.Text == "")
            {
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "SomestartupScript", " alert('Please Enter Staff Count');", true);
                return;
            }
            if (txtWithinTATCaseCount.Text == "")
            {
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "SomestartupScript", " alert('Please Enter Within TAT - Count of Cases (Count)');", true);
                return;
            }
            if (txtOutOfTATCaseCount.Text == "")
            {
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "SomestartupScript", " alert('Please Enter Out of TAT - Count of Cases (Count)');", true);
                return;
            }
            if (txtQCCount.Text == "")
            {
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "SomestartupScript", " alert('Please Enter QC Count)');", true);
                return;
            }
            if (txtErrorCount.Text == "")
            {
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "SomestartupScript", " alert('Please Enter Error Count)');", true);
                return;
            }
            if (txtComplaintsCount.Text == "")
            {
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "SomestartupScript", " alert('Please Enter Complaints Count (Recd. From Client))');", true);
                return;
            }
            if (ddlDeviation.SelectedValue == "--Select--")
            {
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "SomestartupScript", " alert('Please Enter Deviation');", true);
                return;
            }
            if (txtCountOfCases.Text == "")
            {
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "SomestartupScript", " alert('Please Enter Count of Cases - Billed to client (Approx Count ))');", true);
                return;
            }
            if (ddlCalculusData.SelectedValue == "--Select--")
            {
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "SomestartupScript", " alert('Please Enter Calculus Data');", true);
                return;
            }
            if (ddlDeviation.SelectedValue == "Yes" && txtRemark.Text == "")
            {
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "SomestartupScript", " alert('Please Enter Remark');", true);
                return;
            }



            SqlConnection sqlCon = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "CDMA_ManualUpdateSaveData_SP";
                cmd.Connection = sqlCon;

                //cmd.Parameters.AddWithValue("@ID", hdnClientID.Value);
                //cmd.Parameters.AddWithValue("@AllMasterID", hdnAMID.Value);
                cmd.Parameters.AddWithValue("@ClientName", ddlClientName.SelectedItem.Text.Trim());
                cmd.Parameters.AddWithValue("@SubVertical", ddlSubVertical.SelectedItem.Text.Trim());
                cmd.Parameters.AddWithValue("@Activity", ddlActivity.SelectedItem.Text.Trim());
                cmd.Parameters.AddWithValue("@Product", ddlProduct.SelectedItem.Text.Trim());
                cmd.Parameters.AddWithValue("@SubProduct", SubProduct);
                cmd.Parameters.AddWithValue("@MISMonth", ddlMISMonth.SelectedValue);
                cmd.Parameters.AddWithValue("@PreviousMonthName", txtPreviousMonthName.Text.Trim());
                cmd.Parameters.AddWithValue("@PreviousMonthVol", txtPreviousMonthVolume.Text.Trim());
                cmd.Parameters.AddWithValue("@CurrentMonthName", txtCurrentMonthName.Text.Trim());
                cmd.Parameters.AddWithValue("@CurrentMonthVol", txtCurrentMonthVolume.Text.Trim());
                cmd.Parameters.AddWithValue("@IncorDecCount", txtIncDecCount.Text.Trim());
                cmd.Parameters.AddWithValue("@IncorDecPer", txtIncDecPer.Text.Trim());
                cmd.Parameters.AddWithValue("@DuporHoldCaseCount", txtDuplicateandHoldCaseCount.Text.Trim());
                cmd.Parameters.AddWithValue("@StaffCount", txtStaffCount.Text.Trim());
                cmd.Parameters.AddWithValue("@WithinTATCountOfCases", txtWithinTATCaseCount.Text.Trim());
                cmd.Parameters.AddWithValue("@OutOfTATCountOfCases", txtOutOfTATCaseCount.Text.Trim());
                cmd.Parameters.AddWithValue("@QCCount", txtQCCount.Text.Trim());
                cmd.Parameters.AddWithValue("@ErrorCount", txtErrorCount.Text.Trim());
                cmd.Parameters.AddWithValue("@ComplaintsCount", txtComplaintsCount.Text.Trim());
                cmd.Parameters.AddWithValue("@Deviation", ddlDeviation.SelectedItem.Text.Trim());
                cmd.Parameters.AddWithValue("@CountOfCases", txtCountOfCases.Text.Trim());
                cmd.Parameters.AddWithValue("@CalculusData", ddlCalculusData.SelectedItem.Text.Trim());
                cmd.Parameters.AddWithValue("@Remark", txtRemark.Text.Trim());
                cmd.Parameters.AddWithValue("@UserId", Userid);
                cmd.Parameters.AddWithValue("@Branch", Convert.ToString(Session["Branch_Name"]));

                // TEST //  // TEST//

                sqlCon.Open();
                int result = cmd.ExecuteNonQuery();

                if (result > 0)
                {
                    lblmsg.ForeColor = System.Drawing.Color.Green;
                    lblmsg.Text = "Record Inserted Successfully!!";
                    Clear();
                }
                else
                {
                    lblmsg.ForeColor = System.Drawing.Color.Red;
                    lblmsg.Text = "Error while data saving !!!";
                }

            }
            catch (Exception ex)
            {
                lblmsg.ForeColor = System.Drawing.Color.Red;
                lblmsg.Text = ex.ToString();

            }

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            Save();
        }
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("CDMA_Menu.aspx", false);
        }
    }
}
