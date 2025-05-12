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
    public partial class LNT_FarmDigital : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Object SaveUSERInfo = (Object)Session["UserInfo"];

            if (!IsPostBack)
            {
                Panel1.Visible = false;

                BindTypeOfAgency(); //add on 06/07/2024
                BindTypeOfCase();
                BindAssetType1();
                BindPaymentMade();
                BindStatusMaster();
                BindClientCaseStatus();
                BindUserDashbord();

                txtReceivedDate.Text = Convert.ToString(DateTime.Now);
                txtUserID.Text = Convert.ToString(((UserInfo.structUSERInfo)(SaveUSERInfo)).LoginName);
            }
        }
        protected void BindTypeOfAgency() //add on 06/07/2024
        {
            try
            {
                SqlConnection sqlCon = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

                SqlCommand cmd = new SqlCommand("LNT_BindAgencyMaster_SP", sqlCon);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adp.Fill(ds);

                if (ds != null && ds.Tables[0].Rows.Count > 0)
                {
                    rdbAgency.DataValueField = "ID";
                    rdbAgency.DataTextField = "Agency";
                    rdbAgency.DataSource = ds.Tables[0];
                    rdbAgency.DataBind();
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }
        protected void BindTypeOfCase()
        {
            try
            {
                SqlConnection sqlCon = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

                SqlCommand cmd = new SqlCommand("LNT_BindTypeOfCase_SP", sqlCon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ClientId", Session["ClientID"]);  //Added on 22/07/2022
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adp.Fill(ds);

                if (ds != null && ds.Tables[0].Rows.Count > 0)
                {
                    rdbTypeOfCase.DataValueField = "TypeofCaseID";
                    rdbTypeOfCase.DataTextField = "TypeofCase_Name";
                    rdbTypeOfCase.DataSource = ds.Tables[0];
                    rdbTypeOfCase.DataBind();
                    //ddlTypeOfCase.Items.Insert(0, "--Select--");
                    //ddlTypeOfCase.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }
        protected void BindAssetType1()
        {
            try
            {
                SqlConnection sqlCon = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

                SqlCommand cmd = new SqlCommand("LNT_BindAssetType_SP", sqlCon);
                cmd.CommandType = CommandType.StoredProcedure;


                cmd.Parameters.AddWithValue("@ClientId", Session["ClientID"]);  //Added on 27/07/2022



                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adp.Fill(ds);

                if (ds != null && ds.Tables[0].Rows.Count > 0)
                {
                    ddlAssetType1.DataValueField = "AssetTypeID";
                    ddlAssetType1.DataTextField = "AssetType_Name";
                    ddlAssetType1.DataSource = ds.Tables[0];
                    ddlAssetType1.DataBind();
                    ddlAssetType1.Items.Insert(0, "--Select--");
                    ddlAssetType1.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }
        protected void BindPaymentMade()
        {
            try
            {
                SqlConnection sqlCon = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

                SqlCommand cmd = new SqlCommand("LNT_BindPaymentMade_SP", sqlCon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ClientId", Session["ClientID"]);  //Added on 27/07/2022
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adp.Fill(ds);

                if (ds != null && ds.Tables[0].Rows.Count > 0)
                {
                    ddlPaymentMade.DataValueField = "PaymentMadeID";
                    ddlPaymentMade.DataTextField = "PaymentMade_Name";
                    ddlPaymentMade.DataSource = ds.Tables[0];
                    ddlPaymentMade.DataBind();
                    ddlPaymentMade.Items.Insert(0, "--Select--");
                    ddlPaymentMade.SelectedIndex = 0;
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
                    rdbOpsStatus.DataValueField = "StatusID";
                    rdbOpsStatus.DataTextField = "StatusName";
                    rdbOpsStatus.DataSource = ds.Tables[0];
                    rdbOpsStatus.DataBind();
                    //rdbAppStatus.Items.Insert(0, "--Select--");
                    //rdbAppStatus.SelectedIndex = 0;
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
                    rdbAppStatus.DataValueField = "Descriptions";
                    rdbAppStatus.DataTextField = "Descriptions";
                    rdbAppStatus.DataSource = ds.Tables[0];
                    rdbAppStatus.DataBind();
                    //rdbAppStatus.Items.Insert(0, "--Select--");
                    //rdbAppStatus.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }
        protected void ClearAllData()
        {
            Object SaveUSERInfo = (Object)Session["UserInfo"];

            txtAPPLICATIONID.Text = "";
            rdbTypeOfCase.SelectedIndex = -1;
            ddlAssetType1.SelectedIndex = 0;
            ddlPaymentMade.SelectedIndex = 0;
            rdbOpsStatus.SelectedIndex = -1;
            rdbAppStatus.SelectedIndex = -1;
            rdbAgency.SelectedIndex = -1;

            txtBranchName.Text = "";
            txtSupplierName.Text = "";
            txtRemark.Text = "";
            txtReceivedDate.Text = Convert.ToString(DateTime.Now);
            txtUserID.Text = Convert.ToString(((UserInfo.structUSERInfo)(SaveUSERInfo)).LoginName);
            ViewState.Clear();
        }
        protected bool SaveData()
        {
            bool validationResult = true;

            string msg = string.Empty;

            if (txtAPPLICATIONID.Text.Trim() == "" || txtAPPLICATIONID.Text.Trim() == null)
            {
                msg = msg + "Please Enter APPLICATION ID ";
            }

            if (txtAPPLICATIONID.Text.Trim() != "" || txtAPPLICATIONID.Text.Trim() != null)
            {
                int length = txtAPPLICATIONID.Text.Length;

                if (length != 18)
                {
                    msg = msg + "APPLICATION ID should be 18 digits only";
                }
            }

            if (rdbAppStatus.Items[0].Selected == false && rdbAppStatus.Items[1].Selected == false)
            {
                msg = msg + "Please Select App Status, ";
            }
            if (rdbTypeOfCase.Items[0].Selected == false && rdbTypeOfCase.Items[1].Selected == false)
            {
                msg = msg + "Please Select Type Of Case, ";
            }
            if (txtAPPLICATIONID.Text.Trim() == "" && txtAPPLICATIONID.Text.Trim() == null)
            {
                msg = msg + "Please Enter Application Number,";
            }
            if (rdbOpsStatus.Items[0].Selected == false && rdbOpsStatus.Items[1].Selected == false)
            {
                msg = msg + "Please Select Ops Status, ";
            }

            if (rdbAgency.Items[0].Selected == false && rdbAgency.Items[1].Selected == false)
            {
                msg = msg + "Please Select Agency, ";
            }
            if (ddlAssetType1.SelectedValue == "0" || ddlAssetType1.SelectedValue == "--Select--")
            {
                msg = msg + "Please Select Asset Type ";
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

                SqlCommand cmd = new SqlCommand("LNT_InsertFarmDigitalDATA_SP", sqlCon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@APPLICATIONID", txtAPPLICATIONID.Text.Trim());
                cmd.Parameters.AddWithValue("@ClientCaseStatus", rdbAppStatus.SelectedValue);
                cmd.Parameters.AddWithValue("@STATUS", rdbOpsStatus.SelectedValue);
                cmd.Parameters.AddWithValue("@TypeOfCase", rdbTypeOfCase.SelectedValue);
                cmd.Parameters.AddWithValue("@Agency", rdbAgency.SelectedItem.Text);
                cmd.Parameters.AddWithValue("@AssetType", ddlAssetType1.SelectedValue);
                cmd.Parameters.AddWithValue("@ReceivedDate", Convert.ToDateTime(txtReceivedDate.Text));
                cmd.Parameters.AddWithValue("@CreatedByUser", txtUserID.Text);
                cmd.Parameters.AddWithValue("@StartTime", Convert.ToDateTime(ViewState["StartTime"]));
                cmd.Parameters.AddWithValue("@ClientId", Session["ClientID"]);
                cmd.Parameters.AddWithValue("@BranchName", "");
                cmd.Parameters.AddWithValue("@SupplierName", "");
                cmd.Parameters.AddWithValue("@PaymentMade", "");
                cmd.Parameters.AddWithValue("@REMARK", "");

                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();

                adp.Fill(dt);

                if (dt != null && dt.Rows.Count > 0)
                {
                    string massage = Convert.ToString(dt.Rows[0]["MSG"]);

                    if (massage == "TRUE")
                    {
                        int NumberOfAttemt = Convert.ToInt32(dt.Rows[0]["Number Of Attempts"]);

                        lblMsgXls.ForeColor = System.Drawing.Color.Green;

                        if (NumberOfAttemt == 1)
                        {
                            lblMsgXls.Text = Convert.ToString(dt.Rows[0]["SaveMSG"]) + " and Number Of Attempts Is " + Convert.ToString(dt.Rows[0]["Number Of Attempts"]);
                        }
                        else
                        {
                            lblMsgXls.Text = Convert.ToString(dt.Rows[0]["SaveMSG"]) + " and Number Of Attempts are " + Convert.ToString(dt.Rows[0]["Number Of Attempts"]);
                        }
                        validationResult = true;
                        BindUserDashbord();
                    }
                    else
                    {
                        lblMsgXls.ForeColor = System.Drawing.Color.Red;
                        lblMsgXls.Text = Convert.ToString(dt.Rows[0]["SaveMSG"]);
                        validationResult = false;
                    }
                }
                else
                {
                    lblMsgXls.ForeColor = System.Drawing.Color.Red;
                    lblMsgXls.Text = "The case is already exists, Try after 4 minutes";
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
        protected void btnBack_Click(object sender, EventArgs e)
        {
            ClearAllData();
            Response.Redirect("MenuPage.aspx", false);
        }

        protected void txtAPPLICATIONID_TextChanged(object sender, EventArgs e)
        {
            ViewState["StartTime"] = Convert.ToDateTime(DateTime.Now);
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
        protected void BindUserDashbord()
        {
            try
            {
                SqlConnection sqlCon = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

                SqlCommand cmd = new SqlCommand("LNT_Get_FarmDigital_DEO_Dashboard_SP", sqlCon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@UserId", Session["LoginName"]);
                //cmd.Parameters.AddWithValue("@ClientId", Session["ClientID"]);

                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adp.Fill(ds);

                if (ds != null && ds.Tables[0].Rows.Count > 0)
                {

                    lblPreFresh.Text = ds.Tables[0].Rows[0]["PreFresh"].ToString();
                    lblPostFresh.Text = ds.Tables[0].Rows[0]["PostFresh"].ToString();
                    lblTotalCount.Text = ds.Tables[0].Rows[0]["TotalCasesCount"].ToString();
                    lblPreResend.Text = ds.Tables[0].Rows[0]["PreResend"].ToString();
                    lblPostResend.Text = ds.Tables[0].Rows[0]["PostResend"].ToString();
                    lblTotalTime.Text = ds.Tables[0].Rows[0]["TotalDuration"].ToString();
                    lblPreApproved.Text = ds.Tables[0].Rows[0]["PreApproved"].ToString();
                    lblPostApproved.Text = ds.Tables[0].Rows[0]["PostApproved"].ToString();
                    lblPreFreshResend.Text = ds.Tables[0].Rows[0]["PreTotal"].ToString();
                    lblPostFreshResend.Text = ds.Tables[0].Rows[0]["PostTotal"].ToString();
                    lblPreSalesQ.Text = ds.Tables[0].Rows[0]["PreSalesQ"].ToString();
                    lblPostSalesQ.Text = ds.Tables[0].Rows[0]["PostSalesQ"].ToString();
                    //lblTotalDuration.Text = ds.Tables[0].Rows[0]["TotalDuration"].ToString();     --On 20/06/2024
                    //lblTotalCaseCount.Text = ds.Tables[0].Rows[0]["TotalCasesCount"].ToString();
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }
    }
}