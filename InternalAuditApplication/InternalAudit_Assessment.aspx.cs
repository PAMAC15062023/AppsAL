using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using YesBank;

namespace InternalAuditApplication
{
    public partial class InternalAudit_Assessment : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                getschedulerdata();
                BindCauseOrControl();
                BindAuditDecision();
                BindFinalStatus();

                PnlAssessment2.Visible = false;
                PnlAssessment2.Enabled = false;

                BtnSaveAndContinue.Visible = false;
                PnlAssessmentData1.Visible = false;

            }


        }

        protected void BindCauseOrControl()
        {
            try
            {
                SqlConnection sqlCon = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);

                SqlCommand sqlCom = new SqlCommand();
                sqlCom.Connection = sqlCon;
                sqlCom.CommandType = CommandType.StoredProcedure;
                sqlCom.CommandText = "InternalAudit_BindClauseOrControl_SP";
                sqlCom.CommandTimeout = 0;

                SqlDataAdapter da = new SqlDataAdapter(sqlCom);
                DataSet ds = new DataSet();
                da.Fill(ds);

                if (ds != null && ds.Tables.Count > 0)
                {
                    ddlClauseOrControl.DataTextField = "ClausesAndRequirement";
                    ddlClauseOrControl.DataValueField = "ID";
                    ddlClauseOrControl.DataSource = ds.Tables[0];
                    ddlClauseOrControl.DataBind();

                    ddlClauseOrControl.Items.Insert(0, "--Select--");
                    ddlClauseOrControl.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {

            }
        }
        protected void BindAuditDecision()
        {
            try
            {
                SqlConnection sqlCon = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);

                SqlCommand sqlCom = new SqlCommand();
                sqlCom.Connection = sqlCon;
                sqlCom.CommandType = CommandType.StoredProcedure;
                sqlCom.CommandText = "InternalAudit_BindAuditDecision_SP";
                sqlCom.CommandTimeout = 0;

                SqlDataAdapter da = new SqlDataAdapter(sqlCom);
                DataSet ds = new DataSet();
                da.Fill(ds);

                if (ds != null && ds.Tables.Count > 0)
                {
                    ddlAuditDecision.DataTextField = "AuditDecision";
                    ddlAuditDecision.DataValueField = "ID";
                    ddlAuditDecision.DataSource = ds.Tables[0];
                    ddlAuditDecision.DataBind();

                    ddlAuditDecision.Items.Insert(0, "--Select--");
                    ddlAuditDecision.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {

            }
        }

        protected void BindFinalStatus()
        {
            try
            {
                SqlConnection sqlCon = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);

                SqlCommand sqlCom = new SqlCommand();
                sqlCom.Connection = sqlCon;
                sqlCom.CommandType = CommandType.StoredProcedure;
                sqlCom.CommandText = "InternalAudit_BindFinalStatus_SP";
                sqlCom.CommandTimeout = 0;

                SqlDataAdapter da = new SqlDataAdapter(sqlCom);
                DataSet ds = new DataSet();
                da.Fill(ds);

                if (ds != null && ds.Tables.Count > 0)
                {
                    ddlFinalStatus.DataTextField = "FinalStatus";
                    ddlFinalStatus.DataValueField = "ID";
                    ddlFinalStatus.DataSource = ds.Tables[0];
                    ddlFinalStatus.DataBind();

                    ddlFinalStatus.Items.Insert(0, "--Select--");
                    ddlFinalStatus.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {

            }
        }

        protected void GetDetailsFromScheduler()
        {
            SqlConnection sqlCon = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);

            SqlCommand sqlCom = new SqlCommand();
            sqlCom.Connection = sqlCon;
            sqlCom.CommandType = CommandType.StoredProcedure;
            sqlCom.CommandText = "InternalAudit_GetDataForAssessment_Sp";
            sqlCom.CommandTimeout = 0;

            SqlParameter AuditID = new SqlParameter();
            AuditID.SqlDbType = SqlDbType.VarChar;
            AuditID.Value = hdnAuditID.Value;
            AuditID.ParameterName = "@AuditID";
            sqlCom.Parameters.Add(AuditID);

            sqlCon.Open();

            SqlDataAdapter sqlDA = new SqlDataAdapter();
            sqlDA.SelectCommand = sqlCom;

            DataTable dt = new DataTable();
            sqlDA.Fill(dt);

            sqlCon.Close();

            if (dt.Rows.Count > 0)
            {

                txtYear.Text = dt.Rows[0]["FinancialYear"].ToString();
                txtYear.Enabled = false;
                txtQuarter.Text = dt.Rows[0]["Quarter_HalfYear"].ToString();
                txtQuarter.Enabled = false;
                txtLocation.Text = dt.Rows[0]["Branch"].ToString();
                txtLocation.Enabled = false;
                txtNameOfAuditor.Text = dt.Rows[0]["Auditor"].ToString();
                txtNameOfAuditor.Enabled = false;

                txtUnit.Text = dt.Rows[0]["Unit"].ToString();
                txtUnit.Enabled = false;
                txtNameOfAuditee.Text = dt.Rows[0]["Auditee"].ToString();
                txtNameOfAuditee.Enabled = false;
                txtVertical.Text = dt.Rows[0]["Vertical"].ToString();
                txtVertical.Enabled = false;


                string fullValue = dt.Rows[0]["Auditee"].ToString().Replace(",","/");
                string[] values = fullValue.Split('/');


                DataTable newDataTable = new DataTable();
                newDataTable.Columns.Add("Auditee", typeof(string));
                foreach (string value in values)
                {
                    DataRow row = newDataTable.NewRow();
                    row["Auditee"] = value.Trim();
                    newDataTable.Rows.Add(row);
                }

                if (newDataTable.Rows.Count > 0)
                {
                    DDLPointAddresstoAuditee.DataTextField = "Auditee";
                    DDLPointAddresstoAuditee.DataValueField = "Auditee";
                    DDLPointAddresstoAuditee.DataSource = newDataTable;
                    DDLPointAddresstoAuditee.DataBind();

                    DDLPointAddresstoAuditee.Items.Insert(0, "--Select--");
                    DDLPointAddresstoAuditee.SelectedIndex = 0;
                }


            }
            else
            {
                lblMsgXls.Visible = true;
                //lblMsgXls.Text = "No Case Found";
            }
        }
        protected void getschedulerdata()
        {

            SqlConnection sqlCon = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);

            SqlCommand sqlCom = new SqlCommand();
            sqlCom.Connection = sqlCon;
            sqlCom.CommandType = CommandType.StoredProcedure;
            sqlCom.CommandText = "InternalAudit_SchedulerDataForAssessment_SP";
            sqlCom.CommandTimeout = 120;

            SqlParameter UserID = new SqlParameter();
            UserID.SqlDbType = SqlDbType.VarChar;
            UserID.Value = Convert.ToString(Session["UserID"]);
            UserID.ParameterName = "@UserID";
            sqlCom.Parameters.Add(UserID);

            sqlCon.Open();

            SqlDataAdapter sqlDA = new SqlDataAdapter();
            sqlDA.SelectCommand = sqlCom;

            DataTable dt = new DataTable();
            sqlDA.Fill(dt);

            sqlCon.Close();

            if (dt.Rows.Count > 0)
            {
                gvAssessmentdata.DataSource = dt;
                gvAssessmentdata.DataBind();

                gvAssessmentdata.Rows[0].Cells[0].Enabled = false;
                gvAssessmentdata.Rows[0].Cells[1].Enabled = false;
            }
            else
            {
                gvAssessmentdata.DataSource = null;
                gvAssessmentdata.DataBind();

                lblMsgXls.Visible = true;
                lblMsgXls.Text = "No Case Found";
            }
        }

        protected void ClearData()
        {
            ddlClauseOrControl.SelectedIndex = 0;
            txtEvidenceDetails.Text = "";
            ddlAuditDecision.SelectedIndex = 0;
            ddlFinalStatus.SelectedIndex = 0;
            //txtGapID.Text = "";
        }
        protected void lkbtnAssessment_Click(object sender, EventArgs e)
        {
            PnlAssessmentData1.Visible = true;
            PnlAssessment1.Visible = false;
            PnlAssessment2.Enabled = false;
            try
            {
                for (int i = 0; i <= gvAssessmentdata.Rows.Count - 1; i++)
                {
                    CheckBox chkSelect = (CheckBox)gvAssessmentdata.Rows[i].FindControl("chkbox");

                    LinkButton WIP = (LinkButton)gvAssessmentdata.Rows[i].FindControl("lkbtnAssessment");

                    if (chkSelect.Checked == true)
                    {

                        hdnAuditID.Value = gvAssessmentdata.DataKeys[i].Value.ToString();

                        PnlAssessment2.Visible = true;
                        BtnSaveAndContinue.Visible = true;
                        BindAddAssessmentDetails();
                        GetDetailsFromScheduler();

                        break;
                    }
                    else
                    {
                        lblMsgXls.Visible = true;

                    }
                }
            }
            catch (Exception ex)
            {
                lblMsgXls.Visible = true;
                lblMsgXls.Text = "Error :" + ex.Message;
            }

        }

        protected void BindAddAssessmentDetails()
        {
            SqlConnection sqlCon = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);

            SqlCommand sqlCom = new SqlCommand();
            sqlCom.Connection = sqlCon;
            sqlCom.CommandType = CommandType.StoredProcedure;
            sqlCom.CommandText = "InternalAudit_BindAddAssessmentGridByID_SP";
            sqlCom.CommandTimeout = 0;

            SqlParameter ID = new SqlParameter();
            ID.SqlDbType = SqlDbType.VarChar;
            ID.Value = hdnAuditID.Value;
            ID.ParameterName = "@ID";
            sqlCom.Parameters.Add(ID);

            sqlCon.Open();

            SqlDataAdapter sqlDA = new SqlDataAdapter();
            sqlDA.SelectCommand = sqlCom;

            DataTable dt = new DataTable();
            sqlDA.Fill(dt);

            sqlCon.Close();

            if (dt.Rows.Count > 0)
            {
                GVAddAssessment.DataSource = dt;
                GVAddAssessment.DataBind();

                GVAddAssessment.Rows[0].Cells[0].Enabled = false;
                GVAddAssessment.Rows[0].Cells[1].Enabled = false;

                PNLAddAssessment.Visible = true;
            }
            else
            {
                GVAddAssessment.DataSource = null;
                GVAddAssessment.DataBind();

                lblMsgXls.Visible = true;
                lblMsgXls.Text = "No Case Found";
            }
        }

        protected bool AddObservation()
        {
            string msg = string.Empty;
            //DateTime? NullDate = null;
            bool validation = false;

            if (ddlFinalStatus.SelectedValue == "--Select--")
            {
                msg = msg + "Please Select Final Status ";
            }
            if (ddlClauseOrControl.SelectedValue == "--Select--")
            {
                msg = msg + "Please Select Clause Or Control ";
            }
            if (ddlAuditDecision.SelectedValue == "--Select--")
            {
                msg = msg + "Please Select Audit Decision ";
            }
            if (DDLPointAddresstoAuditee.SelectedValue == "--Select--")
            {
                msg = msg + "Please Select Point Address to Auditee ";
            }
            if (msg != "")
            {
                validation = false;
                ClientScript.RegisterStartupScript(Page.GetType(), "mykey", "alert('" + msg + "');", true);
                return validation;
            }

            SqlConnection sqlCon = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);

            SqlCommand cmd = new SqlCommand("InternalAudit_SaveAssessmentData_SP", sqlCon);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ID", Convert.ToInt32(hdnAuditID.Value));
            cmd.Parameters.AddWithValue("@Vertical", txtVertical.Text);
            cmd.Parameters.AddWithValue("@Unit", txtUnit.Text);
            cmd.Parameters.AddWithValue("@ClauseOrControlName", ddlClauseOrControl.SelectedItem.Text);
            cmd.Parameters.AddWithValue("@EvidenceDetailsForWeekness", txtEvidenceDetails.Text);
            cmd.Parameters.AddWithValue("@AuditDecision", ddlAuditDecision.SelectedItem.Text);
            cmd.Parameters.AddWithValue("@FinalStatus", ddlFinalStatus.SelectedItem.Text);
            cmd.Parameters.AddWithValue("@Year", txtYear.Text);
            cmd.Parameters.AddWithValue("@Location", txtLocation.Text);
            cmd.Parameters.AddWithValue("@Quarter", txtQuarter.Text);
            cmd.Parameters.AddWithValue("@DateOfAudit", strDate(txtDateOfAudit.Text));
            cmd.Parameters.AddWithValue("@Auditor", txtNameOfAuditor.Text);
            cmd.Parameters.AddWithValue("@Auditee", txtNameOfAuditee.Text);
            cmd.Parameters.AddWithValue("@UserID", Convert.ToString(Session["UserID"]));
            cmd.Parameters.AddWithValue("@ToAuditee", DDLPointAddresstoAuditee.SelectedItem.Text);
            cmd.Parameters.AddWithValue("@GAP_ID", Convert.ToString(hdnGAPID.Value));
            

            sqlCon.Open();
            int result = cmd.ExecuteNonQuery();
            sqlCon.Close();

            if (result > 0)
            {
                lblMsgXls.Visible = true;
                BindAddAssessmentDetails();
                ClearData();
                validation = true;
            }
            return validation;
        }
        protected void BtnAdd_Click(object sender, EventArgs e)
        {
            if (Session["UserID"] != null)
            {
                bool result = AddObservation();
                if (result)
                {
                    PnlAssessment2.Visible = true;
                }
            }
            else
            {
                Session.Clear();
                Response.Redirect("Login.aspx", false);
            }

        }

        protected void BtnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("InternalAudit_Menu.aspx", false);
        }

        protected void RemoveDataFromAssessment(int AssessmentID)
        {
            SqlConnection sqlCon = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);

            SqlCommand sqlCom = new SqlCommand();
            sqlCom.Connection = sqlCon;
            sqlCom.CommandType = CommandType.StoredProcedure;
            sqlCom.CommandText = "InternalAudit_deleteAddAssessmentGridByID_SP";
            sqlCom.CommandTimeout = 0;

            SqlParameter ID = new SqlParameter();
            ID.SqlDbType = SqlDbType.VarChar;
            ID.Value = AssessmentID;
            ID.ParameterName = "@ID";
            sqlCom.Parameters.Add(ID);

            sqlCon.Open();
            sqlCom.ExecuteNonQuery();
            sqlCon.Close();
        }
        protected void lkbtnRemove_Click(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i <= GVAddAssessment.Rows.Count - 1; i++)
                {
                    CheckBox chkSelect = (CheckBox)GVAddAssessment.Rows[i].FindControl("chkbox");

                    LinkButton WIP = (LinkButton)GVAddAssessment.Rows[i].FindControl("lkbtnRemove");

                    if (chkSelect.Checked == true)
                    {

                        hdnAssessmentID.Value = GVAddAssessment.DataKeys[i].Value.ToString();

                        RemoveDataFromAssessment(Convert.ToInt32(hdnAssessmentID.Value));
                        BindAddAssessmentDetails();
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
        protected bool SaveAuditDate()
        {
            string msg = string.Empty;
            bool validationResult = false;
            if (txtDateOfAudit.Text.Trim() == "" || txtDateOfAudit.Text.Trim() == null)
            {
                msg = msg + "Please Enter Date Of Audit";
            }

            if (msg != "")
            {
                validationResult = false;
                ClientScript.RegisterStartupScript(Page.GetType(), "mykey", "alert('" + msg + "');", true);
                return validationResult;
            }
            SqlConnection sqlCon = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);

            SqlCommand cmd = new SqlCommand("InternalAudit_SaveAuditDateFromAssessment_SP", sqlCon);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@AuditID", hdnAuditID.Value);
            cmd.Parameters.AddWithValue("@DateOfAudit", strDate(txtDateOfAudit.Text));

            sqlCon.Open();
            int result = cmd.ExecuteNonQuery();
            sqlCon.Close();

            if (result > 0)
            {
                lblMsgXls.Visible = true;
                lblMsgXls.Text = "Audit Date Saved Successfully!!";
                validationResult = true;
            }
            return validationResult;
        }
        protected void BtnSave1_Click(object sender, EventArgs e)
        {
            if (Session["UserID"] != null)
            {
                bool result = SaveAuditDate();
                if (result)
                {
                    SaveAuditDate();
                    PnlAssessment2.Enabled = true;
                }
                else
                {
                    PnlAssessment2.Enabled = false;
                }
            }
            else
            {
                Session.Clear();
                Response.Redirect("Login.aspx", false);
            }
        }

        protected void BtnSaveAndContinue_Click1(object sender, EventArgs e)
        {
            ClearData();
            PnlAssessment2.Visible = false;
            PNLAddAssessment.Visible = false;
            PnlAssessment1.Visible = true;
            PnlAssessmentData1.Visible = false;
            BtnSaveAndContinue.Visible = false;
            lblMsgXls.Text = "Your Assessment has been Save and Submited Successfully";
        }

        protected void lkbtnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i <= GVAddAssessment.Rows.Count - 1; i++)
                {
                    CheckBox chkSelect = (CheckBox)GVAddAssessment.Rows[i].FindControl("chkbox");

                    LinkButton WIP = (LinkButton)GVAddAssessment.Rows[i].FindControl("lkbtnRemove");

                    if (chkSelect.Checked == true)
                    {

                        hdnGAPID.Value = GVAddAssessment.Rows[i].Cells[7].Text.Trim();


                        //ddlClauseOrControl.SelectedItem.Text = GVAddAssessment.Rows[i].Cells[3].Text.Trim();
                        txtEvidenceDetails.Text = GVAddAssessment.Rows[i].Cells[4].Text.Trim();
                        //ddlAuditDecision.SelectedItem.Text = GVAddAssessment.Rows[i].Cells[5].Text.Trim();
                        //ddlFinalStatus.SelectedItem.Text = GVAddAssessment.Rows[i].Cells[6].Text.Trim();
                        //DDLPointAddresstoAuditee.SelectedItem.Text = GVAddAssessment.Rows[i].Cells[8].Text.Trim();
                        txtDateOfAudit.Text = GVAddAssessment.Rows[i].Cells[9].Text.Trim();
                        PnlAssessment2.Enabled = true;
                        break;
                    }
                    else
                    {
                        PnlAssessment2.Enabled = false;
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
    }
}