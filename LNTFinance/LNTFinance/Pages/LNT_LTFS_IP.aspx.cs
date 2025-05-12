using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace LNTFinance.Pages
{
    public partial class LNT_LTFS_IP : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Object SaveUSERInfo = (Object)Session["UserInfo"];

            if (!IsPostBack)
            {
                string Client = Convert.ToString(Session["ClientID"]);

                if (Client == "IP")
                {
                    lblheader.Text = "LTFS_IP";
                }

                BindStatusMaster();
                BindClientCaseStatus();
                BindUserDashbord();

                txtDate.Text = Convert.ToString(DateTime.Now);
                txtUserID.Text = Convert.ToString(((UserInfo.structUSERInfo)(SaveUSERInfo)).LoginName);
            }
        }

        protected void BindStatusMaster()
        {
            try
            {
                SqlConnection sqlCon = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

                SqlCommand cmd = new SqlCommand("LNT_LTFS_BindStatusMaster_SP", sqlCon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ClientId", Session["ClientID"]);  //Added on 27/07/2022

                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adp.Fill(ds);

                if (ds != null && ds.Tables[0].Rows.Count > 0)
                {
                    ddlSTATUS.DataValueField = "StatusID";
                    ddlSTATUS.DataTextField = "StatusName";
                    ddlSTATUS.DataSource = ds.Tables[0];
                    ddlSTATUS.DataBind();
                    ddlSTATUS.Items.Insert(0, "--Select--");
                    ddlSTATUS.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }

        protected void BindClientCaseStatus()
        {
            try
            {
                SqlConnection sqlCon = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

                SqlCommand cmd = new SqlCommand("LNT_LTFS_BindClientCaseStatusMaster_SP", sqlCon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ClientId", Session["ClientID"]);  //Added on 27/07/2022

                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adp.Fill(ds);

                if (ds != null && ds.Tables[0].Rows.Count > 0)
                {
                    ddlClientCaseStatus.DataValueField = "ID";
                    ddlClientCaseStatus.DataTextField = "Descriptions";
                    ddlClientCaseStatus.DataSource = ds.Tables[0];
                    ddlClientCaseStatus.DataBind();
                    ddlClientCaseStatus.Items.Insert(0, "--Select--");
                    ddlClientCaseStatus.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }

        protected void BindUserDashbord()
        {
            try
            {
                SqlConnection sqlCon = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

                SqlCommand cmd = new SqlCommand("LNT_UserDashbord_SP", sqlCon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@UserId", Session["LoginName"]);
                cmd.Parameters.AddWithValue("@ClientId", Session["ClientID"]);

                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adp.Fill(ds);

                if (ds != null && ds.Tables[0].Rows.Count > 0)
                {
                    lblFreshCount.Text = "[Fresh:-" + ds.Tables[0].Rows[0]["FRESH"].ToString() + "]";
                    lblResendCount.Text = "[Resend:-" + ds.Tables[0].Rows[0]["RESEND"].ToString() + "]";
                    lblSaleQueCount.Text = "[SaleQue:-" + ds.Tables[0].Rows[0]["SalesQue"].ToString() + "]";
                    lblApproveCount.Text = "[Approve:-" + ds.Tables[0].Rows[0]["Approve"].ToString() + "]";
                    lblTotalCount.Text = "[Total:-" + ds.Tables[0].Rows[0]["Total"].ToString() + "]";
                    lblTotalDuration.Text = "[Total Duration:-" + ds.Tables[0].Rows[0]["TotalDutation"].ToString() + "]";
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }
        protected void txtAPPLICATIONID_TextChanged1(object sender, EventArgs e)
        {
            ViewState["StartTime"] = Convert.ToDateTime(DateTime.Now);
        }

        protected void ClearAllData()
        {
            Object SaveUSERInfo = (Object)Session["UserInfo"];

            txtAPPLICATIONID.Text = "";
            BindStatusMaster();
            BindClientCaseStatus();
            txtAppDate.Text = "";
            txtRemark.Text = "";
            txtDate.Text = Convert.ToString(DateTime.Now);
            txtUserID.Text = Convert.ToString(((UserInfo.structUSERInfo)(SaveUSERInfo)).LoginName);
            ViewState.Clear();
        }
        protected bool SaveData()
        {
            bool validationResult = true;

            string msg = string.Empty;

            if (txtAppDate.Text.Trim() == "" || txtAppDate.Text.Trim() == null)
            {
                msg = msg + "Please Enter APP DATE,";
            }


            //if (txtAppDate.Text.Trim() != "")
            //{
            //    Regex regex = new Regex(@"^(((((0[1-9])|(1\d)|(2[0-8]))-((0[1-9])|(1[0-2])))|((31-((0[13578])|(1[02])))|((29|30)-((0[1,3-9])|(1[0-2])))))-((20[0-9][0-9]))|(29-02-20(([02468][048])|([13579][26]))))$");

            //    //Verify whether date entered in dd-MM-yyyy format.
            //    bool isValid = regex.IsMatch(txtAppDate.Text.Trim());
            //    //Verify whether entered date is Valid date.
            //    DateTime dt;
            //    isValid = DateTime.TryParseExact(txtAppDate.Text, "dd-mm-yyyy", new CultureInfo("en-GB"), DateTimeStyles.None, out dt);
            //    if (!isValid)
            //    {
            //        msg = msg + "Invalid Date. date format Like [dd-mm-yyyy]";

            //    }

            //}


            if (txtAPPLICATIONID.Text.Trim() == "" || txtAPPLICATIONID.Text.Trim() == null)
            {
                msg = msg + "Please Enter APP ID,";
            }
            if (ddlClientCaseStatus.SelectedValue == "--Select--" || ddlClientCaseStatus.SelectedIndex == 0)
            {
                msg = msg + "Please Select APP Status,";
            }

            if (ddlSTATUS.SelectedValue == "--Select--" || ddlSTATUS.SelectedIndex == 0)
            {
                msg = msg + "Please Select OPS Status, ";
            }

            if (msg != "")
            {
                validationResult = false;
                ClientScript.RegisterStartupScript(Page.GetType(), "mykey", "alert('" + msg + "');", true);
                return validationResult;
            }

            try
            {
                SqlConnection sqlCon = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

                SqlCommand cmd = new SqlCommand("LNT_LTFS_InsertData_SP", sqlCon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@APPLICATIONID", txtAPPLICATIONID.Text.Trim());
                cmd.Parameters.AddWithValue("@STATUS", ddlSTATUS.SelectedValue);
                cmd.Parameters.AddWithValue("@AppDate", txtAppDate.Text.Trim());
                cmd.Parameters.AddWithValue("@ReceivedDate", Convert.ToDateTime(txtDate.Text.Trim()));
                cmd.Parameters.AddWithValue("@Remark", txtRemark.Text.Trim());
                cmd.Parameters.AddWithValue("@StartTime", Convert.ToDateTime(ViewState["StartTime"]));
                cmd.Parameters.AddWithValue("@CreatedByUser", txtUserID.Text.Trim());
                cmd.Parameters.AddWithValue("@ClientCaseStatus", ddlClientCaseStatus.SelectedItem.Text);
                cmd.Parameters.AddWithValue("@ClientId", Session["ClientID"]); /*Added on 19/07/2022*/

                sqlCon.Open();
                int Result = cmd.ExecuteNonQuery();
                sqlCon.Close();

                if (Result > 0)
                {
                    lblMsgXls.Text = "Data Save Successfully";
                    validationResult = true;
                    BindUserDashbord();
                }
                else
                {
                    lblMsgXls.Text = "Error";
                    validationResult = false;
                }
            }
            catch (Exception ex)
            {
                lblMsgXls.Text = ex.ToString();
                validationResult = false;
            }

            return validationResult;
        }

        protected void btnSaveAndContinue_Click(object sender, EventArgs e)
        {
            lblMsgXls.Text = "";
            bool result = SaveData();
            if (result)
            {
                ClearAllData();
            }
        }

        protected void btnSaveAndExit_Click(object sender, EventArgs e)
        {
            lblMsgXls.Text = "";

            bool result = SaveData();
            if (result)
            {

                ClearAllData();
                Session.Clear();
                Response.Redirect("MenuPage.aspx", false);
            }
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            ClearAllData();
            Response.Redirect("MenuPage.aspx", false);
        }
    }
}