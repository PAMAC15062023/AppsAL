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
    public partial class LNT_TWLData : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Object SaveUSERInfo = (Object)Session["UserInfo"];

            if (!IsPostBack)
            {
                string Client = Convert.ToString(Session["ClientID"]);

                if (Client == "TWI")
                {
                    lblheader.Text = "LFTS_TL";  //"TWL - Digital";
                }
                else
                {
                    lblheader.Text = "TWL Data";
                }

                if (Client == "TWI")
                {
                    dvRemark.Visible = false;
                }
                else
                {
                    dvRemark.Visible = true;
                }

                BindStatusMaster();
                BindClientCaseStatus();
                BindUserDashbord();

                txtDate.Text = Convert.ToString(DateTime.Now);
                txtUserID.Text = Convert.ToString(((UserInfo.structUSERInfo)(SaveUSERInfo)).LoginName);
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
                    lblFreshCount.Text    =  "[Fresh:-" + ds.Tables[0].Rows[0]["FRESH"].ToString() + "]";
                    lblResendCount.Text   =  "[Resend:-" + ds.Tables[0].Rows[0]["RESEND"].ToString() + "]";
                    lblSaleQueCount.Text  =  "[SaleQue:-" + ds.Tables[0].Rows[0]["SalesQue"].ToString() + "]";
                    lblApproveCount.Text  =  "[Approve:-" +  ds.Tables[0].Rows[0]["Approve"].ToString() + "]";
                    lblTotalCount.Text    =  "[Total:-" + ds.Tables[0].Rows[0]["Total"].ToString() + "]";
                    lblTotalDuration.Text =  "[Total Duration:-" + ds.Tables[0].Rows[0]["TotalDutation"].ToString() + "]";
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }
        protected void BindStatusMaster()
        {
            try
            {
                SqlConnection sqlCon = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

                SqlCommand cmd = new SqlCommand("LNT_BindStatusMaster_SP", sqlCon);
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

                SqlCommand cmd = new SqlCommand("LNT_BindClientCaseStatus_SP", sqlCon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ClientId", Session["ClientID"]);  //Added on 27/07/2022

                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adp.Fill(ds);

                if (ds != null && ds.Tables[0].Rows.Count > 0)
                {
                    ddlClientCaseStatus.DataValueField = "Descriptions";
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
        protected void txtAPPLICATIONID_TextChanged(object sender, EventArgs e)
        {
            ViewState["StartTime"] = Convert.ToDateTime(DateTime.Now);
        }
        protected void ClearAllData()
        {
            Object SaveUSERInfo = (Object)Session["UserInfo"];

            txtAPPLICATIONID.Text = "";
            BindStatusMaster();
            BindClientCaseStatus();
            txtRemark.Text = "";
            txtDate.Text = Convert.ToString(DateTime.Now);
            txtUserID.Text = Convert.ToString(((UserInfo.structUSERInfo)(SaveUSERInfo)).LoginName);
            ViewState.Clear();
        }
        protected bool SaveData()
        {
            bool validationResult = true;

            string msg = string.Empty;

            if (ddlClientCaseStatus.SelectedValue == "--Select--" || ddlClientCaseStatus.SelectedIndex == 0)
            {
                msg = msg + "Please Select Client Case Status";
            }
            if (txtAPPLICATIONID.Text.Trim() == "" || txtAPPLICATIONID.Text.Trim() == null)
            {
                msg = msg + "Please Enter Application Number,";
            }
            if (ddlSTATUS.SelectedValue == "--Select--" || ddlSTATUS.SelectedIndex == 0)
            {
                msg = msg + "Please Select Status, ";
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

                SqlCommand cmd = new SqlCommand("LNT_InsertTWLData_SP", sqlCon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@APPLICATIONID", txtAPPLICATIONID.Text.Trim());
                cmd.Parameters.AddWithValue("@STATUS", ddlSTATUS.SelectedValue);
                cmd.Parameters.AddWithValue("@REMARK", txtRemark.Text.Trim());
                cmd.Parameters.AddWithValue("@ReceivedDate", Convert.ToDateTime(txtDate.Text.Trim()));
                //cmd.Parameters.AddWithValue("@ReceivedDate", txtDate.Text.Trim());
                cmd.Parameters.AddWithValue("@StartTime", Convert.ToDateTime(ViewState["StartTime"]));
                cmd.Parameters.AddWithValue("@CreatedByUser", txtUserID.Text.Trim());
                cmd.Parameters.AddWithValue("@ClientCaseStatus", ddlClientCaseStatus.SelectedValue);
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
                //Object SaveUSERInfo = (Object)Session["UserInfo"];
                //CommonMaster commonMaster = new CommonMaster();
                //int Result = commonMaster.UserLogOut(Convert.ToString(((UserInfo.structUSERInfo)(SaveUSERInfo)).LoginName));

                //if (Result == 1)
                //{
                ClearAllData();
                Session.Clear();
                Response.Redirect("../LoginPage.aspx", false);
                //}
            }
        }
        protected void btnBack_Click(object sender, EventArgs e)
        {
            ClearAllData();
            Response.Redirect("MenuPage.aspx", false);
        }
    }
}