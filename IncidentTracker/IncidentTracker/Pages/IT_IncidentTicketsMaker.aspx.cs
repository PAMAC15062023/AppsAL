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
    public partial class IT_IncidentTicketsMaker : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindVerticalInfo();


                if (Request.QueryString["IncidentNumber"] != null && Request.QueryString["IncidentNumber"] != string.Empty)
                {
                    lblIncidentNumber.Text = Request.QueryString["IncidentNumber"];

                    BindIncidentTrackerDetailsByID(lblIncidentNumber.Text);
                }
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
        private void SaveData()
        {
            try
            {
                Object SaveUSERInfo = (Object)Session["UserInfo"];

                SqlConnection sqlCon = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);

                sqlCon.Open();
                SqlCommand sqlCom = new SqlCommand();
                sqlCom.Connection = sqlCon;
                sqlCom.CommandType = CommandType.StoredProcedure;
                sqlCom.CommandText = "IT_InsertUpdateIncidentTicketInfo_SP";
                SqlDataAdapter sqlDA = new SqlDataAdapter();
                sqlDA.SelectCommand = sqlCom;


                SqlParameter IncidentNumber = new SqlParameter();
                IncidentNumber.SqlDbType = SqlDbType.VarChar;
                IncidentNumber.Value = lblIncidentNumber.Text.Trim();
                IncidentNumber.ParameterName = "@IncidentNumber";
                sqlCom.Parameters.Add(IncidentNumber);

                SqlParameter IncidentDateAndTime = new SqlParameter();
                IncidentDateAndTime.SqlDbType = SqlDbType.DateTime;
                IncidentDateAndTime.Value = txtIncidentDateAndTime.Text.Trim();
                IncidentDateAndTime.ParameterName = "@IncidentDateTime";
                sqlCom.Parameters.Add(IncidentDateAndTime);


                SqlParameter IncidentReportedBy = new SqlParameter();
                IncidentReportedBy.SqlDbType = SqlDbType.VarChar;
                IncidentReportedBy.Value = txtIncidentReportedBy.Text.Trim();
                IncidentReportedBy.ParameterName = "@IncidentReportedBy";
                sqlCom.Parameters.Add(IncidentReportedBy);


                SqlParameter IncidentReportingUnit = new SqlParameter();
                IncidentReportingUnit.SqlDbType = SqlDbType.VarChar;
                IncidentReportingUnit.Value = ddlIncidentReportingUnit.SelectedValue;
                IncidentReportingUnit.ParameterName = "@IncidentReportingUnit";
                sqlCom.Parameters.Add(IncidentReportingUnit);


                SqlParameter IncidentDateAndTimeOfReporting = new SqlParameter();
                IncidentDateAndTimeOfReporting.SqlDbType = SqlDbType.DateTime;
                IncidentDateAndTimeOfReporting.Value = txtIncidentDateAndTimeOfReporting.Text;
                IncidentDateAndTimeOfReporting.ParameterName = "@IncidentDateTimeOfReporting";
                sqlCom.Parameters.Add(IncidentDateAndTimeOfReporting);



                SqlParameter IncidentReportedVia = new SqlParameter();
                IncidentReportedVia.SqlDbType = SqlDbType.VarChar;
                IncidentReportedVia.Value = ddlIncidentReportedVia.SelectedItem.Text;
                IncidentReportedVia.ParameterName = "@IncidentReportedVia";
                sqlCom.Parameters.Add(IncidentReportedVia);

                SqlParameter IncidentReportedTo = new SqlParameter();
                IncidentReportedTo.SqlDbType = SqlDbType.VarChar;
                IncidentReportedTo.Value = txtIncidentReportedTo.Text;
                IncidentReportedTo.ParameterName = "@IncidentReportedTo";
                sqlCom.Parameters.Add(IncidentReportedTo);

                SqlParameter IncidentReportedToUnit = new SqlParameter();
                IncidentReportedToUnit.SqlDbType = SqlDbType.VarChar;
                IncidentReportedToUnit.Value = ddlIncidentReportedToUnit.SelectedValue;
                IncidentReportedToUnit.ParameterName = "@IncidentReportedToUnit";
                sqlCom.Parameters.Add(IncidentReportedToUnit);


                SqlParameter IncidentDescription = new SqlParameter();
                IncidentDescription.SqlDbType = SqlDbType.VarChar;
                IncidentDescription.Value = txtIncidentDescription.Text;
                IncidentDescription.ParameterName = "@IncidentDescription";
                sqlCom.Parameters.Add(IncidentDescription);

                SqlParameter Severity = new SqlParameter();
                Severity.SqlDbType = SqlDbType.VarChar;
                Severity.Value = ddlSeverity.SelectedItem.Text;
                Severity.ParameterName = "@Severity";
                sqlCom.Parameters.Add(Severity);

                SqlParameter UsersBUImpacted = new SqlParameter();
                UsersBUImpacted.SqlDbType = SqlDbType.VarChar;
                UsersBUImpacted.Value = txtUsersBUimpacted.Text;
                UsersBUImpacted.ParameterName = "@UsersBUImpacted";
                sqlCom.Parameters.Add(UsersBUImpacted);

                SqlParameter ImpactCost = new SqlParameter();
                ImpactCost.SqlDbType = SqlDbType.VarChar;
                ImpactCost.Value = ddlImpactCost.SelectedItem.Text;
                ImpactCost.ParameterName = "@ImpactCost";
                sqlCom.Parameters.Add(ImpactCost);

                //SqlParameter RootCauseAnalysisDate = new SqlParameter();
                //RootCauseAnalysisDate.SqlDbType = SqlDbType.DateTime;
                //RootCauseAnalysisDate.Value = txtRootCauseAnalysisDate.Text;
                //RootCauseAnalysisDate.ParameterName = "@RootCauseAnalysisDate";
                //sqlCom.Parameters.Add(RootCauseAnalysisDate);

                SqlParameter RootCauseAnalysisStartDateTime = new SqlParameter();
                RootCauseAnalysisStartDateTime.SqlDbType = SqlDbType.DateTime;
                RootCauseAnalysisStartDateTime.Value = txtRootCauseAnalysisStartDateTime.Text;
                RootCauseAnalysisStartDateTime.ParameterName = "@RootCauseAnalysisStartTime";
                sqlCom.Parameters.Add(RootCauseAnalysisStartDateTime);

                SqlParameter RootCauseAnalysisEndTime = new SqlParameter();
                RootCauseAnalysisEndTime.SqlDbType = SqlDbType.DateTime;
                RootCauseAnalysisEndTime.Value = txtRootCauseAnalysisEndDateTime.Text;
                RootCauseAnalysisEndTime.ParameterName = "@RootCauseAnalysisEndTime";
                sqlCom.Parameters.Add(RootCauseAnalysisEndTime);

                SqlParameter RootReasonForIncident = new SqlParameter();
                RootReasonForIncident.SqlDbType = SqlDbType.VarChar;
                RootReasonForIncident.Value = txtRootReasonForIncident.Text;
                RootReasonForIncident.ParameterName = "@RootReasonForIncident";
                sqlCom.Parameters.Add(RootReasonForIncident);

                SqlParameter RemidialAction = new SqlParameter();
                RemidialAction.SqlDbType = SqlDbType.VarChar;
                RemidialAction.Value = txtRemidialAction.Text;
                RemidialAction.ParameterName = "@RemidialAction";
                sqlCom.Parameters.Add(RemidialAction);

                SqlParameter ResultOfRemedialAction = new SqlParameter();
                ResultOfRemedialAction.SqlDbType = SqlDbType.VarChar;
                ResultOfRemedialAction.Value = txtResultOfRemedialAction.Text.Trim();
                ResultOfRemedialAction.ParameterName = "@ResultOfRemedialAction";
                sqlCom.Parameters.Add(ResultOfRemedialAction);

                SqlParameter LongTermSolution = new SqlParameter();
                LongTermSolution.SqlDbType = SqlDbType.VarChar;
                LongTermSolution.Value = txtLongTermSolution.Text;
                LongTermSolution.ParameterName = "@LongTermSolution";
                sqlCom.Parameters.Add(LongTermSolution);

                SqlParameter BranchID = new SqlParameter();
                BranchID.SqlDbType = SqlDbType.Int;
                BranchID.Value = Convert.ToInt32(((UserInfo.structUSERInfo)(SaveUSERInfo)).BranchId);
                BranchID.ParameterName = "@BranchID";
                sqlCom.Parameters.Add(BranchID);


                SqlParameter UserID = new SqlParameter();
                UserID.SqlDbType = SqlDbType.VarChar;
                UserID.Value = Convert.ToString(((UserInfo.structUSERInfo)(SaveUSERInfo)).UserId);
                UserID.ParameterName = "@UserID";
                sqlCom.Parameters.Add(UserID);



                SqlParameter VarResult = new SqlParameter();
                VarResult.SqlDbType = SqlDbType.VarChar;
                VarResult.Value = lblIncidentNumber.Text.Trim();
                VarResult.ParameterName = "@VarResult";
                VarResult.Size = 200;
                VarResult.Direction = ParameterDirection.Output;
                sqlCom.Parameters.Add(VarResult);

                sqlCom.ExecuteNonQuery();
                string RowEffected = Convert.ToString(sqlCom.Parameters["@VarResult"].Value);

                sqlCon.Close();

                if (RowEffected != "")
                {
                    lblMsgXls.Text = "Ticket Successfully Generated, Ticket No: " + RowEffected;
                    lblMsgXls.CssClass = "SuccessMessage";
                    lblIncidentNumber.Text = RowEffected;
                    ClearData();
                }
            }
            catch (Exception ex)
            {

                lblMsgXls.Text = ex.ToString();
            }



        }
        protected void ClearData()
        {
            lblIncidentNumber.Text = "";
            txtIncidentDateAndTime.Text = "";
            txtIncidentReportedBy.Text = "";
            ddlIncidentReportingUnit.SelectedIndex = 0;
            txtIncidentDateAndTimeOfReporting.Text = "";
            ddlIncidentReportedVia.SelectedIndex = 0;
            txtIncidentReportedTo.Text = "";
            ddlIncidentReportedToUnit.SelectedIndex = 0;
            txtIncidentDescription.Text = "";
            txtIncidentDescription.Text = "";
            ddlSeverity.SelectedIndex = 0;
            txtUsersBUimpacted.Text = "";
            ddlImpactCost.SelectedIndex = 0;
            //txtRootCauseAnalysisDate.Text = "";
            txtRootCauseAnalysisStartDateTime.Text = "";
            txtRootCauseAnalysisEndDateTime.Text = "";
            txtRootReasonForIncident.Text = "";
            txtRemidialAction.Text = "";
            txtResultOfRemedialAction.Text = "";
            txtLongTermSolution.Text = "";
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                SaveData();
            }
            catch (Exception ex)
            {
                lblMsgXls.Text = ex.ToString();
            }
        }
        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("IT_MenuPage.aspx", true);
        }
        protected void BindIncidentTrackerDetailsByID(string IncidentNumber)
        {
            try
            {
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

                    //pnlDataEntry.Visible = true;
                    //pnlGridView.Visible = false;
                    //btnSave.Visible = true;
                }
            }
            catch (Exception ex)
            {

                lblMsgXls.Text = ex.ToString();
            }
        }
    }
}