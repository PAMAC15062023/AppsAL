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
    public partial class InternalAudit_Scheduler : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["SaveMSG"] != null && Request.QueryString["SaveMSG"] != string.Empty)
                {
                    lblMsgXls.Text = Request.QueryString["SaveMSG"];
                }
                gvschedulerdata.Visible = false;
                PnlScheduler2.Visible = false;
                PnlButtons.Visible = false;
                PnlSchedulerGrid2.Visible = false;
                BindAuditor();
                BindAuditStatus();
            }
        }

        protected void BindAuditor()
        {
            try
            {
                SqlConnection sqlCon = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);

                SqlCommand sqlCom = new SqlCommand();
                sqlCom.Connection = sqlCon;
                sqlCom.CommandType = CommandType.StoredProcedure;
                sqlCom.CommandText = "InternalAudit_BindAuditor_SP";
                sqlCom.CommandTimeout = 0;

                SqlParameter UserID = new SqlParameter();
                UserID.SqlDbType = SqlDbType.VarChar;
                UserID.Value = Convert.ToString(Session["UserID"]);
                UserID.ParameterName = "@UserID";
                sqlCom.Parameters.Add(UserID);

                SqlParameter UserName = new SqlParameter();
                UserName.SqlDbType = SqlDbType.VarChar;
                UserName.Value = (Session["UserName"].ToString()); 
                UserName.ParameterName = "@UserName";
                sqlCom.Parameters.Add(UserName);

                SqlParameter Role = new SqlParameter();
                Role.SqlDbType = SqlDbType.VarChar;
                Role.Value = Convert.ToString(Session["RoleID"]);
                Role.ParameterName = "@RoleID";
                sqlCom.Parameters.Add(Role);

                SqlDataAdapter da = new SqlDataAdapter(sqlCom);
                DataSet ds = new DataSet();
                da.Fill(ds);

                if (ds != null && ds.Tables.Count > 0)
                {
                    ddlAuditor.DataTextField = "UserName";
                    ddlAuditor.DataValueField = "UserID";
                    ddlAuditor.DataSource = ds.Tables[0];
                    ddlAuditor.DataBind();

                    int Roleid = Convert.ToInt32(Session["RoleID"]);
                    if (Roleid != 1002)
                    {
                        ddlAuditor.SelectedIndex = 1;
                    }
                    else 
                    {
                        ddlAuditor.Items.Insert(0, "--Select--");
                        ddlAuditor.SelectedIndex = 0;
                    }
                }
            }
            catch (Exception ex)
            {
                string msg = ex.ToString();
            }
        }

        protected void BindAuditStatus()
        {
            try
            {
                SqlConnection sqlCon = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);

                SqlCommand sqlCom = new SqlCommand();
                sqlCom.Connection = sqlCon;
                sqlCom.CommandType = CommandType.StoredProcedure;
                sqlCom.CommandText = "InternalAudit_BindAuditStatus_SP";
                sqlCom.CommandTimeout = 0;

                SqlDataAdapter da = new SqlDataAdapter(sqlCom);
                DataSet ds = new DataSet();
                da.Fill(ds);

                if (ds != null && ds.Tables.Count > 0)
                {
                    ddlAduditStatus.DataTextField = "FinalStatus";
                    ddlAduditStatus.DataValueField = "ID";
                    ddlAduditStatus.DataSource = ds.Tables[0];
                    ddlAduditStatus.DataBind();

                    ddlAduditStatus.Items.Insert(0, "--Select--");
                    ddlAduditStatus.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                string msg = ex.ToString();
            }

        }
        protected void btnSearch_Click(object sender, EventArgs e)
        {

            getschedulerdata();
        }

        protected void getschedulerdata()
        {

            gvschedulerdata.Visible = true;
            PnlSchedulerGrid2.Visible = true;
            SqlConnection sqlCon = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);

            SqlCommand sqlCom = new SqlCommand();
            sqlCom.Connection = sqlCon;
            sqlCom.CommandType = CommandType.StoredProcedure;
            sqlCom.CommandText = "InternalAudit_SearchAuditorDetails_SP";
            sqlCom.CommandTimeout = 0;

            SqlParameter Auditor = new SqlParameter();
            Auditor.SqlDbType = SqlDbType.VarChar;
            Auditor.Value = ddlAuditor.SelectedItem.Text;
            Auditor.ParameterName = "@Auditor";
            sqlCom.Parameters.Add(Auditor);

            //SqlParameter USERID = new SqlParameter();
            //USERID.SqlDbType = SqlDbType.VarChar;
            //USERID.Value = Convert.ToString(Session["UserID"]);
            //USERID.ParameterName = "@userID";
            //sqlCom.Parameters.Add(USERID);


            sqlCon.Open();

            SqlDataAdapter sqlDA = new SqlDataAdapter();
            sqlDA.SelectCommand = sqlCom;

            DataTable dt = new DataTable();
            sqlDA.Fill(dt);

            sqlCon.Close();

            if (dt.Rows.Count > 0)
            {
                gvschedulerdata.DataSource = dt;
                gvschedulerdata.DataBind();

                gvschedulerdata.Rows[0].Cells[0].Enabled = false;
                gvschedulerdata.Rows[0].Cells[1].Enabled = false;
               
                int Roleid = Convert.ToInt32(Session["RoleID"]); //add on 24/07/2024

                if (Roleid != 1002) //add on 25/07/2024
                {
                    foreach (GridViewRow row in gvschedulerdata.Rows)
                    {
                        row.Cells[13].Visible = false;
                        gvschedulerdata.Columns[13].Visible = false;
                    }

                }
                else
                {
                    foreach (GridViewRow row in gvschedulerdata.Rows)
                    {
                        row.Cells[13].Visible = true;
                        row.Cells[13].Enabled = true;
                        gvschedulerdata.Columns[13].Visible = true;
                    }
                }
            }
            else
            {
                gvschedulerdata.DataSource = null;
                gvschedulerdata.DataBind();

                lblMsgXls.Visible = true;
                lblMsgXls.Text = "No Case Found";
            }
        }

        protected void BtnBack_Click(object sender, EventArgs e)
        {

            for (int i = 0; i < gvschedulerdata.Rows.Count; i++)
            {
                Int32 key = Convert.ToInt32(gvschedulerdata.DataKeys[i].Value.ToString());
            }


            Response.Redirect("InternalAudit_Menu.aspx", false);
        }

        protected void GetAuditScheduler (int ID)
        {
            try
            {
                SqlConnection sqlCon = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);

                SqlCommand sqlCom = new SqlCommand();
                sqlCom.Connection = sqlCon;
                sqlCom.CommandType = CommandType.StoredProcedure;
                sqlCom.CommandText = "InternalAudit_GetAuditScheduler_SP";
                sqlCom.CommandTimeout = 0;

                SqlParameter ID1 = new SqlParameter();
                ID1.SqlDbType = SqlDbType.Int;
                ID1.Value = Convert.ToString(ID);
                ID1.ParameterName = "@ID";
                sqlCom.Parameters.Add(ID1);

                SqlDataAdapter da = new SqlDataAdapter(sqlCom);
                DataSet ds = new DataSet();
                da.Fill(ds);

                if (ds != null && ds.Tables.Count > 0)
                {
                    int status = 0;
                    string status2 = Convert.ToString(ds.Tables[0].Rows[0]["Status"]);

                    if(status2 != null && status2 != "")
                    {
                        status = Convert.ToInt32(ds.Tables[0].Rows[0]["Status"]);
                    }
                    if (status == 0)
                    {
                        txtAuditScheduleDate.Enabled = true;
                        txtDateOfAuditConducted.Enabled = false;
                        txtCapSharedWithAuditee.Enabled = false;
                        txtFollowUpEmails.Enabled = false;
                        txtCapRevertStatus.Enabled = false;
                        txtRemarks.Enabled = false;
                        ddlAduditStatus.Enabled = true;
                    }
                    else if (status == 1)
                    {
                        txtAuditScheduleDate.Enabled = false;
                        txtDateOfAuditConducted.Enabled = true;
                        txtCapSharedWithAuditee.Enabled = false;
                        txtFollowUpEmails.Enabled = false;
                        txtCapRevertStatus.Enabled = false;
                        txtRemarks.Enabled = false;
                        ddlAduditStatus.Enabled = true;
                    }
                    else if (status == 2)
                    {
                        txtAuditScheduleDate.Enabled = false;
                        txtDateOfAuditConducted.Enabled = false;
                        txtCapSharedWithAuditee.Enabled = true;
                        txtFollowUpEmails.Enabled = false;
                        txtCapRevertStatus.Enabled = false;
                        txtRemarks.Enabled = false;
                        ddlAduditStatus.Enabled = true;
                    }
                    else if (status == 3)
                    {
                        txtAuditScheduleDate.Enabled = false;
                        txtDateOfAuditConducted.Enabled = false;
                        txtCapSharedWithAuditee.Enabled = false;
                        txtFollowUpEmails.Enabled = true;
                        txtCapRevertStatus.Enabled = false;
                        txtRemarks.Enabled = false;
                        ddlAduditStatus.Enabled = true;
                    }
                    else if (status == 4)
                    {
                        txtAuditScheduleDate.Enabled = false;
                        txtDateOfAuditConducted.Enabled = false;
                        txtCapSharedWithAuditee.Enabled = false;
                        txtFollowUpEmails.Enabled = false;
                        txtCapRevertStatus.Enabled = true;
                        txtRemarks.Enabled = true;
                        ddlAduditStatus.Enabled = true;
                    }

                    txtAuditScheduleDate.Text = ds.Tables[0].Rows[0]["AuditScheduleDate"].ToString();

                    string DateOfAuditConducted = ds.Tables[0].Rows[0]["DateOfAuditConducted"].ToString();
                    if (DateOfAuditConducted != "02/01/1900")
                    {
                        txtDateOfAuditConducted.Text = ds.Tables[0].Rows[0]["DateOfAuditConducted"].ToString();
                        txtDateOfAuditConducted.Enabled = false;
                    }
                    else 
                    {
                        txtDateOfAuditConducted.Text = "";
                    }

                    string CapSharedWithAuditee = ds.Tables[0].Rows[0]["CapSharedWithAuditee"].ToString();
                    if(CapSharedWithAuditee != "02/01/1900")
                    {
                        txtCapSharedWithAuditee.Text = ds.Tables[0].Rows[0]["CapSharedWithAuditee"].ToString();
                    }
                    else
                    {
                        txtCapSharedWithAuditee.Text = "";
                    }
                        
                    string FollowUpEmails = ds.Tables[0].Rows[0]["FollowUpEmails"].ToString();
                    if (FollowUpEmails != "02/01/1900")
                    {
                        txtFollowUpEmails.Text = ds.Tables[0].Rows[0]["FollowUpEmails"].ToString();
                    }
                    else
                    {
                        txtFollowUpEmails.Text = "";
                    }
                    txtCapRevertStatus.Text = ds.Tables[0].Rows[0]["CapRevertStatus"].ToString();
                    txtRemarks.Text = ds.Tables[0].Rows[0]["Remarks"].ToString();

                }
            }
            catch (Exception ex)
            {
                string msg = ex.ToString();
            }

        }

        protected void DeleteAuditSchedular(int ID)
        {
            try
            {
                SqlConnection sqlCon = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);

                SqlCommand sqlCom = new SqlCommand();
                sqlCom.Connection = sqlCon;
                sqlCom.CommandType = CommandType.StoredProcedure;
                sqlCom.CommandText = "InternalAudit_DeleteAuditScheduler_SP";
                sqlCom.CommandTimeout = 0;

                SqlParameter id = new SqlParameter();
                id.SqlDbType = SqlDbType.Int;
                id.Value = Convert.ToString(ID);
                id.ParameterName = "@ID";
                sqlCom.Parameters.Add(id);

                sqlCon.Open();
                sqlCom.ExecuteNonQuery();
                sqlCon.Close();
                lblMsgXls.Text = "Record deleted Successfully";
            }
            catch (Exception ex)
            {
                string msg = ex.ToString();
            }
        }
        protected void GetDetailsFromScheduler()
        {
            SqlConnection sqlCon = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);

            SqlCommand sqlCom = new SqlCommand();
            sqlCom.Connection = sqlCon;
            sqlCom.CommandType = CommandType.StoredProcedure;
            sqlCom.CommandText = "InternalAudit_GetDataForScheduler_Sp";
            sqlCom.CommandTimeout = 0;

            SqlParameter AuditID = new SqlParameter();
            AuditID.SqlDbType = SqlDbType.VarChar;
            AuditID.Value = HdnID.Value;
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

                txtQuarter.Text = dt.Rows[0]["Quarter_HalfYear"].ToString();
                txtQuarter.Enabled = false;
                txtBranch.Text = dt.Rows[0]["Branch"].ToString();
                txtBranch.Enabled = false;
                txtVertical.Text = dt.Rows[0]["Vertical"].ToString();
                txtVertical.Enabled = false;
                txtUnit.Text = dt.Rows[0]["Unit"].ToString();
                txtUnit.Enabled = false;
                txtScheduleDate.Text = dt.Rows[0]["ScheduleDate"].ToString();
                txtScheduleDate.Enabled = false;
                txtAuditor.Text = dt.Rows[0]["Auditor"].ToString();
                txtAuditor.Enabled = false;
                txtAuditee.Text = dt.Rows[0]["Auditor"].ToString();
                txtAuditee.Enabled = false;
            }
            else
            {
                lblMsgXls.Visible = true;
                //lblMsgXls.Text = "No Case Found";
            }
        }
        protected void lkbtnEdit_Click(object sender, EventArgs e)
        {
            PnlButtons.Visible = true;
            PnlScheduler1.Visible = false;
            PnlScheduler2.Visible = false;
            PnlSchedulerGrid2.Visible = false;
            txtDateOfAuditConducted.Enabled = false;
            lblMsgXls.Text = "";
           try
             {
                 for (int i = 0; i <= gvschedulerdata.Rows.Count - 1; i++)
                 {
                     CheckBox chkSelect = (CheckBox)gvschedulerdata.Rows[i].FindControl("chkbox");

                     LinkButton WIP = (LinkButton)gvschedulerdata.Rows[i].FindControl("lkbtnEdit");                    

                    if (chkSelect.Checked == true)
                     {

                        HdnID.Value = gvschedulerdata.DataKeys[i].Value.ToString();

                         PnlScheduler2.Visible = true;

                        GetAuditScheduler(Convert.ToInt32(HdnID.Value));
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

        public void ClearData()
        {
            txtAuditScheduleDate.Text = "";
            txtDateOfAuditConducted.Text = "";
            txtCapSharedWithAuditee.Text = "";
            txtFollowUpEmails.Text = "";
            txtCapRevertStatus.Text = "";
            ddlAduditStatus.SelectedIndex = 0;
            txtRemarks.Text = "";
            PnlScheduler2.Visible = false;
        }
        protected bool SaveData()
        {
            bool validationResult = false;
            string msg = string.Empty;
            DateTime? NullDate = null;
            if (ddlAduditStatus.SelectedValue == "--Select--")
            {
                msg = msg + "Please Select Final Status ";
            }
            if (msg != "")
            {
                validationResult = false;
                ClientScript.RegisterStartupScript(Page.GetType(), "mykey", "alert('" + msg + "');", true);
                return validationResult;
            }
            SqlConnection sqlCon = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);

            SqlCommand cmd = new SqlCommand("InternalAudit_SaveSchedulerData_SP", sqlCon);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ID", Convert.ToInt32(HdnID.Value));

            if (txtAuditScheduleDate.Text.Trim() != "" && txtAuditScheduleDate.Text.Trim() != null)
            {
                cmd.Parameters.AddWithValue("@AuditScheduleDate", strDate(txtAuditScheduleDate.Text));
            }
            else
            {
                cmd.Parameters.AddWithValue("@AuditScheduleDate", NullDate);
            }

            if (txtDateOfAuditConducted.Text.Trim() != "" && txtDateOfAuditConducted.Text.Trim() != null)
            {
                cmd.Parameters.AddWithValue("@DateOfAuditConducted", strDate(txtDateOfAuditConducted.Text));
            }
            else
            {
                cmd.Parameters.AddWithValue("@DateOfAuditConducted", string.IsNullOrEmpty(txtDateOfAuditConducted.Text));
            }

            if (txtCapSharedWithAuditee.Text.Trim() != "" && txtCapSharedWithAuditee.Text.Trim() != null)
            {
                cmd.Parameters.AddWithValue("@CapSharedWithAuditee", strDate(txtCapSharedWithAuditee.Text));
            }
            else
            {
                cmd.Parameters.AddWithValue("@CapSharedWithAuditee", string.IsNullOrEmpty(txtCapSharedWithAuditee.Text));
            }

            if (txtFollowUpEmails.Text.Trim() != "" && txtFollowUpEmails.Text.Trim() != null && txtFollowUpEmails.Text.Trim() != "01-01-1900 12.00.00 AM" && txtFollowUpEmails.Text.Trim() != "1900-01-02 00:00:00.000")
            {
                cmd.Parameters.AddWithValue("@FollowUpEmails", strDate(txtFollowUpEmails.Text));
            }
            else
            {
                //cmd.Parameters.AddWithValue("@FollowUpEmails", string.IsNullOrEmpty(txtFollowUpEmails.Text));
                cmd.Parameters.AddWithValue("@FollowUpEmails", DBNull.Value); //add on 29/11/2024
            }

            cmd.Parameters.AddWithValue("@CapRevertStatus", txtCapRevertStatus.Text);
            cmd.Parameters.AddWithValue("@AuditStatus", ddlAduditStatus.SelectedItem.Text);
            cmd.Parameters.AddWithValue("@Remarks", txtRemarks.Text);
            cmd.Parameters.AddWithValue("@UserID", Convert.ToString(Session["UserID"]));


            sqlCon.Open();
            int result = cmd.ExecuteNonQuery();
            sqlCon.Close();

            if (result > 0)
            {
                lblMsgXls.Visible = true;
                lblMsgXls.Text = "Data Successfully added ";
                validationResult = true;
            }
            return validationResult;
        }
        protected void BtnSave_Click(object sender, EventArgs e)
        {
            bool result = SaveData();
           
            if (result)
            {
                PnlScheduler1.Visible = true;
                PnlScheduler2.Visible = false;
                PnlButtons.Visible = false;
                PnlSchedulerGrid2.Visible = false;
                getschedulerdata();
                ClearData();

                //Response.Redirect("InternalAudit_Scheduler.aspx?SaveMSG=Record Save Successfully", false);
            }
            else
            {
                Session.Clear();
                Response.Redirect("Login.aspx", false);
            }
        }

        protected void BtnBackFromSearch_Click(object sender, EventArgs e)
        {
            Response.Redirect("InternalAudit_Menu.aspx", false);
        }

        protected void lkbtnDelete_Click(object sender, EventArgs e)
        {

           try
            {
                for (int i = 0; i <= gvschedulerdata.Rows.Count - 1; i++)
                {
                    CheckBox chkSelect = (CheckBox)gvschedulerdata.Rows[i].FindControl("chkbox");

                    LinkButton Del = (LinkButton)gvschedulerdata.Rows[i].FindControl("lkbtnDelete");

                    if (chkSelect.Checked == true)
                    {
                        HdnID.Value = gvschedulerdata.DataKeys[i].Value.ToString();

                        PnlScheduler2.Visible = true;

                        DeleteAuditSchedular(Convert.ToInt32(HdnID.Value));
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
    }
}