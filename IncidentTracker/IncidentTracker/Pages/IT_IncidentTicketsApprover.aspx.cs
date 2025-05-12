using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IncidentTracker.Pages
{
    public partial class IT_IncidentTicketsApprover : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                pnlDataEntry.Visible = false;
                pnlGridView.Visible = true;
                btnSave.Visible = false;

                Enabledcontrols();
                BindIncidentTrackerDetails();
            }
        }
        protected void lnkWIP_Click(object sender, EventArgs e)
        {
            lblMsgXls.Text = "";
            try
            {
                for (int i = 0; i <= gvData.Rows.Count - 1; i++)
                {
                    CheckBox chkSelect = (CheckBox)gvData.Rows[i].FindControl("chkSelect");

                    LinkButton WIP = (LinkButton)gvData.Rows[i].FindControl("lnkWIP");

                    if (chkSelect.Checked == true)
                    {
                        ViewState["IncidentNumber"] = gvData.Rows[i].Cells[3].Text.Trim();

                        string IncidentNumber = gvData.Rows[i].Cells[3].Text.Trim();

                        BindIncidentTrackerDetailsByID(IncidentNumber);

                        lblMsgXls.Text = "";
                        break;
                    }
                    else
                    {
                        lblMsgXls.Visible = true;
                        lblMsgXls.Text = "Error :";
                    }
                }
            }
            catch (Exception ex)
            {
                lblMsgXls.Visible = true;
                lblMsgXls.Text = "Error :" + ex.Message;
            }
        }
        protected void BindVerticalInfo()
        {
            try
            {
                SqlConnection sqlCon = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);
                SqlCommand sqlCom = new SqlCommand();
                sqlCom.Connection = sqlCon;
                sqlCom.CommandType = CommandType.StoredProcedure;
                sqlCom.CommandText = "IT_BindVerticalInfo_SP";
                SqlDataAdapter da = new SqlDataAdapter(sqlCom);
                DataSet ds = new DataSet();
                da.Fill(ds);
                if (ds != null && ds.Tables.Count > 0)
                {
                    ddlIncidentReportingUnit.DataTextField = "Vertical_Name";
                    ddlIncidentReportingUnit.DataValueField = "Vertical_ID";
                    ddlIncidentReportingUnit.DataSource = ds.Tables[0];
                    ddlIncidentReportingUnit.DataBind();
                    ddlIncidentReportingUnit.Items.Insert(0, "--Select--");
                    ddlIncidentReportingUnit.SelectedIndex = 0;


                    ddlIncidentReportedToUnit.DataTextField = "Vertical_Name";
                    ddlIncidentReportedToUnit.DataValueField = "Vertical_ID";
                    ddlIncidentReportedToUnit.DataSource = ds.Tables[0];
                    ddlIncidentReportedToUnit.DataBind();
                    ddlIncidentReportedToUnit.Items.Insert(0, "--Select--");
                    ddlIncidentReportedToUnit.SelectedIndex = 0;

                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }
        protected void BindIncidentTrackerDetails()
        {
            try
            {
                SqlConnection sqlCon = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);

                SqlCommand sqlCom = new SqlCommand();
                sqlCom.Connection = sqlCon;
                sqlCom.CommandType = CommandType.StoredProcedure;
                sqlCom.CommandText = "IT_BindIncidentTrackerDetails_SP";
                sqlCom.CommandTimeout = 0;

                sqlCon.Open();
                SqlDataAdapter sqlDA = new SqlDataAdapter();
                sqlDA.SelectCommand = sqlCom;
                DataTable dt = new DataTable();
                sqlDA.Fill(dt);

                sqlCon.Close();

                if (dt.Rows.Count > 0)
                {
                    gvData.DataSource = dt;
                    gvData.DataBind();
                }
                else
                {
                    gvData.DataSource = null;
                    gvData.DataBind();

                    lblMsgXls.Visible = true;
                    lblMsgXls.Text = "No Case Found";
                }
            }
            catch (Exception ex)
            {

                lblMsgXls.Text = ex.ToString();
            }
        }
        protected void BindIncidentTrackerDetailsByID(string IncidentNumber)
        {
            try
            {
                Object SaveUSERInfo = (Object)Session["UserInfo"];

                SqlConnection sqlCon = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);

                SqlCommand sqlCom = new SqlCommand();
                sqlCom.Connection = sqlCon;
                sqlCom.CommandType = CommandType.StoredProcedure;
                sqlCom.CommandText = "IT_BindIncidentTrackerDetails_ByID_SP";
                sqlCom.CommandTimeout = 0;

                SqlParameter Incident_Number = new SqlParameter();
                Incident_Number.SqlDbType = SqlDbType.VarChar;
                Incident_Number.Value = IncidentNumber;
                Incident_Number.ParameterName = "@IncidentNumber";
                sqlCom.Parameters.Add(Incident_Number);

                SqlDataAdapter da = new SqlDataAdapter(sqlCom);
                DataSet ds = new DataSet();
                da.Fill(ds);

                if (ds != null && ds.Tables.Count > 0)
                {

                    BindVerticalInfo();
                    txtIncidentDateAndTime.Text = Convert.ToDateTime(ds.Tables[0].Rows[0]["IncidentDateTime"]).ToString("yyyy-MM-ddTHH:mm:ss.ss");
                    txtIncidentReportedBy.Text = ds.Tables[0].Rows[0]["IncidentReportedBy"].ToString();
                    txtIncidentDateAndTimeOfReporting.Text = Convert.ToDateTime(ds.Tables[0].Rows[0]["IncidentDateTimeOfReporting"]).ToString("yyyy-MM-ddTHH:mm:ss.ss");
                    txtIncidentReportedTo.Text = ds.Tables[0].Rows[0]["IncidentReportedTo"].ToString();
                    txtIncidentDescription.Text = ds.Tables[0].Rows[0]["IncidentDescription"].ToString();
                    txtUsersBUimpacted.Text = ds.Tables[0].Rows[0]["UsersBUImpacted"].ToString();
                    //txtRootCauseAnalysisDate.Text = ds.Tables[0].Rows[0]["RootCauseAnalysisDate"].ToString();
                    txtRootCauseAnalysisStartDateTime.Text = Convert.ToDateTime(ds.Tables[0].Rows[0]["RootCauseAnalysisStartTime"]).ToString("yyyy-MM-ddTHH:mm:ss.ss");
                    txtRootCauseAnalysisEndDateTime.Text = Convert.ToDateTime(ds.Tables[0].Rows[0]["RootCauseAnalysisEndTime"]).ToString("yyyy-MM-ddTHH:mm:ss.ss");
                    txtRootReasonForIncident.Text = ds.Tables[0].Rows[0]["RootReasonForIncident"].ToString();
                    txtRemidialAction.Text = ds.Tables[0].Rows[0]["RemidialAction"].ToString();
                    txtResultOfRemedialAction.Text = ds.Tables[0].Rows[0]["ResultOfRemedialAction"].ToString();
                    txtLongTermSolution.Text = ds.Tables[0].Rows[0]["LongTermSolution"].ToString();

                    ddlIncidentReportingUnit.SelectedValue = ds.Tables[0].Rows[0]["IncidentReportingUnit"].ToString();
                    ddlIncidentReportedVia.SelectedValue = ds.Tables[0].Rows[0]["IncidentReportedVia"].ToString();
                    ddlIncidentReportedToUnit.SelectedValue = ds.Tables[0].Rows[0]["IncidentReportedToUnit"].ToString();
                    ddlSeverity.SelectedValue = ds.Tables[0].Rows[0]["Severity"].ToString();
                    ddlImpactCost.SelectedValue = ds.Tables[0].Rows[0]["ImpactCost"].ToString();

                    string UserId = Convert.ToString(((UserInfo.structUSERInfo)(SaveUSERInfo)).UserId);
                    string UserName = Convert.ToString(((UserInfo.structUSERInfo)(SaveUSERInfo)).UserName);

                    txtReviewer.Text = UserName + " " + UserId;

                    if (ds.Tables[0].Rows[0]["ApproverStatus"].ToString() != "")
                    {
                        txtReviewerDate.Text = ds.Tables[0].Rows[0]["ReviewAndClosureDate"].ToString();
                        txtReviewer.Text = ds.Tables[0].Rows[0]["Reviewer"].ToString();
                        ddlReviewerStatus.SelectedValue = ds.Tables[0].Rows[0]["ApproverStatus"].ToString();
                        txtReviewerRemarks.Text = ds.Tables[0].Rows[0]["ApproverRemarks"].ToString();
                    }

                    pnlDataEntry.Visible = true;
                    pnlGridView.Visible = false;
                    btnSave.Visible = true;
                }
            }
            catch (Exception ex)
            {

                lblMsgXls.Text = ex.ToString();
            }
        }
        protected void Enabledcontrols()
        {
            txtIncidentDateAndTime.Enabled = false;
            txtIncidentReportedBy.Enabled = false;
            txtIncidentDateAndTimeOfReporting.Enabled = false;
            txtIncidentReportedTo.Enabled = false;
            txtIncidentDescription.Enabled = false;
            txtUsersBUimpacted.Enabled = false;
            //txtRootCauseAnalysisDate.Enabled = false;
            txtRootCauseAnalysisStartDateTime.Enabled = false;
            txtRootCauseAnalysisEndDateTime.Enabled = false;
            txtRootReasonForIncident.Enabled = false;
            txtRemidialAction.Enabled = false;
            txtResultOfRemedialAction.Enabled = false;
            txtLongTermSolution.Enabled = false;
            ddlIncidentReportingUnit.Enabled = false;
            ddlIncidentReportedVia.Enabled = false;
            ddlIncidentReportedToUnit.Enabled = false;
            ddlSeverity.Enabled = false;
            ddlImpactCost.Enabled = false;
            txtReviewer.Enabled = false;
        }
        protected void SaveData()
        {
            try
            {

                lblMsgXls.Text = "";

                Object SaveUSERInfo = (Object)Session["UserInfo"];

                string msg = string.Empty;

                string IncidentNumber = Convert.ToString(ViewState["IncidentNumber"]);


                if (ddlReviewerStatus.SelectedItem.Text == "--Select--")
                {
                    msg = msg + "Please Select Reviewer Status ";
                }

                if (msg != "")
                {
                    ClientScript.RegisterStartupScript(Page.GetType(), "mykey", "alert('" + msg + "');", true);
                    return;
                }


                SqlConnection sqlCon = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());



                SqlCommand cmd = new SqlCommand("IT_Update_ReviewAndClosureDetails_SP", sqlCon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@UserId", Convert.ToString(((UserInfo.structUSERInfo)(SaveUSERInfo)).UserId));
                cmd.Parameters.AddWithValue("@IncidentNumber", IncidentNumber);
                cmd.Parameters.AddWithValue("@RevieweDate", strDate(txtReviewerDate.Text.Trim()));
                cmd.Parameters.AddWithValue("@Reviewer", txtReviewer.Text.Trim());
                cmd.Parameters.AddWithValue("@ReviewerStatus", ddlReviewerStatus.SelectedItem.Text);
                cmd.Parameters.AddWithValue("@ReviewerRemarks", txtReviewerRemarks.Text.Trim());

                sqlCon.Open();
                int result = cmd.ExecuteNonQuery();
                sqlCon.Close();

                if (result > 0)
                {
                    lblMsgXls.Visible = true;
                    lblMsgXls.Text = "Data Save Successfully";
                    BindIncidentTrackerDetails();
                    ClearData();
                }
                else
                {
                    lblMsgXls.Text = "Error";
                }
            }
            catch (Exception ex)
            {

                lblMsgXls.Text = ex.ToString();
            }

        }
        protected void ClearData()
        {
            txtReviewerDate.Text = "";
            txtReviewer.Text = "";
            ddlReviewerStatus.Text = "";
            txtReviewerRemarks.Text = "";

            pnlDataEntry.Visible = false;
            pnlGridView.Visible = true;
            btnSave.Visible = false;
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            SaveData();
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("IT_MenuPage.aspx", true);
        }
        public string strDate(string strInDate)
        {
            string strDD = strInDate.Substring(0, 2);

            string strMM = strInDate.Substring(3, 2);

            string strYYYY = strInDate.Substring(6, 4);

            string strYYYYMMDD = strYYYY + "-" + strMM + "-" + strDD;

            //string strMMDDYYYY = strDD + "/" + strMM + "/" + strYYYY;

            DateTime dtConvertDate = Convert.ToDateTime(strYYYYMMDD);

            string strOutDate = dtConvertDate.ToString("yyyy-MM-dd");

            return strOutDate;
        }
    }
}