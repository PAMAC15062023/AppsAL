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
    public partial class InternalAudit_AuditeeCAP : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                /*BindQuarter();
                BindBranch();
                BindVertical();*/

                GetAssessmentDetailsForAuditee();
                pnlAuditeeCAPDetails.Visible = false;
                BtnSave.Visible = false;
            }
        }

        /* protected void BindQuarter()
         {
             try
             {
                 SqlConnection sqlCon = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);

                 SqlCommand sqlCom = new SqlCommand();
                 sqlCom.Connection = sqlCon;
                 sqlCom.CommandType = CommandType.StoredProcedure;
                 sqlCom.CommandText = "InternalAudit_BindQuarter_SP";
                 sqlCom.CommandTimeout = 0;

                 SqlDataAdapter da = new SqlDataAdapter(sqlCom);
                 DataSet ds = new DataSet();
                 da.Fill(ds);

                 if (ds != null && ds.Tables.Count > 0)
                 {
                     ddlQuarter.DataTextField = "Quarter";
                     ddlQuarter.DataValueField = "ID";
                     ddlQuarter.DataSource = ds.Tables[0];
                     ddlQuarter.DataBind();

                     ddlQuarter.Items.Insert(0, "--Select--");
                     ddlQuarter.SelectedIndex = 0;
                 }
             }
             catch (Exception ex)
             {

             }
         }

         protected void BindBranch()
         {
             try
             {
                 SqlConnection sqlCon = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);

                 SqlCommand sqlCom = new SqlCommand();
                 sqlCom.Connection = sqlCon;
                 sqlCom.CommandType = CommandType.StoredProcedure;
                 sqlCom.CommandText = "InternalAudit_BindBranch_SP";
                 sqlCom.CommandTimeout = 0;

                 SqlDataAdapter da = new SqlDataAdapter(sqlCom);
                 DataSet ds = new DataSet();
                 da.Fill(ds);

                 if (ds != null && ds.Tables.Count > 0)
                 {
                     ddlBranch.DataTextField = "Location";
                     ddlBranch.DataValueField = "ID";
                     ddlBranch.DataSource = ds.Tables[0];
                     ddlBranch.DataBind();

                     ddlBranch.Items.Insert(0, "--Select--");
                     ddlBranch.SelectedIndex = 0;
                 }
             }
             catch (Exception ex)
             {

             }
         }

         protected void BindVertical()
         {
             try
             {
                 SqlConnection sqlCon = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);

                 SqlCommand sqlCom = new SqlCommand();
                 sqlCom.Connection = sqlCon;
                 sqlCom.CommandType = CommandType.StoredProcedure;
                 sqlCom.CommandText = "InternalAudit_BindVertical_SP";
                 sqlCom.CommandTimeout = 0;

                 SqlDataAdapter da = new SqlDataAdapter(sqlCom);
                 DataSet ds = new DataSet();
                 da.Fill(ds);

                 if (ds != null && ds.Tables.Count > 0)
                 {
                     ddlVertical.DataTextField = "Vertical";
                     ddlVertical.DataValueField = "ID";
                     ddlVertical.DataSource = ds.Tables[0];
                     ddlVertical.DataBind();

                     ddlVertical.Items.Insert(0, "--Select--");
                     ddlVertical.SelectedIndex = 0;
                 }
             }
             catch (Exception ex)
             {

             }
         }*/

        protected void GetAssessmentDetailsForAuditee()
        {

            SqlConnection sqlCon = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);

            SqlCommand sqlCom = new SqlCommand();
            sqlCom.Connection = sqlCon;
            sqlCom.CommandType = CommandType.StoredProcedure;
            sqlCom.CommandText = "InternalAudit_GetDataForAuditeeCAPSearchWise_SP";
            sqlCom.CommandTimeout = 0;

            SqlParameter UserName = new SqlParameter();
            UserName.SqlDbType = SqlDbType.VarChar;
            UserName.Value = Convert.ToString(Session["UserID"]);
            UserName.ParameterName = "@UserID";
            sqlCom.Parameters.Add(UserName);

            sqlCon.Open();

            SqlDataAdapter sqlDA = new SqlDataAdapter();
            sqlDA.SelectCommand = sqlCom;

            DataTable dt = new DataTable();
            sqlDA.Fill(dt);

            sqlCon.Close();

            if (dt.Rows.Count > 0)
            {
                GVDetailsFromAssessment.DataSource = dt;
                GVDetailsFromAssessment.DataBind();

                GVDetailsFromAssessment.Rows[0].Cells[0].Enabled = false;
                GVDetailsFromAssessment.Rows[0].Cells[1].Enabled = false;
            }
            else
            {
                GVDetailsFromAssessment.DataSource = null;
                GVDetailsFromAssessment.DataBind();

                lblMsgXls.Visible = true;
                lblMsgXls.Text = "No Case Found";
            }
        }
        /* protected void BtnSearch_Click(object sender, EventArgs e)
         {
             GetAssessmentDetailsForAuditee();
         }*/

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

        private string UploadAttachment_OnServer()
        {
            try
            {
                string FileSavePath = "";
                string filename_Attachment = "";
                if (FUEvidenceAttached.FileName != "")
                {
                    //string fullSitePath = Convert.ToString(ConfigurationSettings.AppSettings["HelpdeskAttachmentPath"]);
                    //fullSitePath = fullSitePath.Trim();

                    string strRndonMo = System.Guid.NewGuid().ToString().Substring(1, 5) + System.Guid.NewGuid().ToString().Substring(1, 5);//HdnUNQID.Value.ToString().Substring(0,10);//System.Guid.NewGuid().ToString().Substring(1, 7);
                    string strPath = Server.MapPath("UploadedFiles/");

                    strPath = strPath.Trim();
                    filename_Attachment = Convert.ToString(FUEvidenceAttached.FileName.Trim());
                    filename_Attachment = filename_Attachment.Replace(" ", "_");

                    FileSavePath = strPath + strRndonMo + filename_Attachment;

                    filename_Attachment = strRndonMo + filename_Attachment; //Added on 04-02-2023 By Yasir

                    FUEvidenceAttached.SaveAs(FileSavePath);

                    FileSavePath = filename_Attachment;  //Added on 04-02-2023 By Yasir
                }
                return FileSavePath;
            }
            catch (Exception ex)
            {
                lblMsgXls.Text = ex.Message;
                lblMsgXls.CssClass = "ErrorMessage";
                return "";
            }
        }

        protected void GetDetailsReturnedFromStatusUpdate()
        {
            SqlConnection sqlCon = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);

            SqlCommand sqlCom = new SqlCommand();
            sqlCom.Connection = sqlCon;
            sqlCom.CommandType = CommandType.StoredProcedure;
            sqlCom.CommandText = "InternalAudit_GetDataForStatusUpdate_SP";
            sqlCom.CommandTimeout = 0;

            SqlParameter GAPID = new SqlParameter();
            GAPID.SqlDbType = SqlDbType.VarChar;
            GAPID.Value = Convert.ToString(HdnGAPID.Value);
            GAPID.ParameterName = "@GAP_ID";
            sqlCom.Parameters.Add(GAPID);

            sqlCon.Open();

            SqlDataAdapter sqlDA = new SqlDataAdapter();
            sqlDA.SelectCommand = sqlCom;

            DataTable dt = new DataTable();
            sqlDA.Fill(dt);

            sqlCon.Close();

            if (dt.Rows.Count > 0)
            {

                txtCorrectionWithReferenceToEvidence.Text = dt.Rows[0]["CorrectionWithReferenceToEvidence"].ToString();
                txtRootCauseAnalysis.Text = dt.Rows[0]["RootCauseAnalysis"].ToString();
                txtAction.Text = dt.Rows[0]["Action"].ToString();
                txtResponse.Text = dt.Rows[0]["Response"].ToString();
                txtTargateDate.Text = dt.Rows[0]["TargetDate"].ToString();
                lblEvidenceAttached.Text = dt.Rows[0]["EvidenceAttached"].ToString();
            }
            else
            {
                GVDetailsFromAssessment.DataSource = null;
                GVDetailsFromAssessment.DataBind();

                lblMsgXls.Visible = true;
                lblMsgXls.Text = "No Case Found";
            }
        }
        protected void lkbtnEdit_Click(object sender, EventArgs e)
        {
            lblMsgXls.Text = "";
            try
            {
                for (int i = 0; i <= GVDetailsFromAssessment.Rows.Count - 1; i++)
                {
                    CheckBox chkSelect = (CheckBox)GVDetailsFromAssessment.Rows[i].FindControl("chkbox");

                    LinkButton WIP = (LinkButton)GVDetailsFromAssessment.Rows[i].FindControl("lkbtnRemove");

                    if (chkSelect.Checked == true)
                    {

                        hdnAssessmentID.Value = GVDetailsFromAssessment.DataKeys[i].Value.ToString();
                        txtGAPID.Text = GVDetailsFromAssessment.Rows[i].Cells[5].Text.Trim();
                        txtGAPID.Enabled = false;
                        txtClauseOrControl.Text = GVDetailsFromAssessment.Rows[i].Cells[6].Text.Trim();
                        txtClauseOrControl.Enabled = false;
                        txtEvidenceDetails.Text = GVDetailsFromAssessment.Rows[i].Cells[7].Text.Trim();
                        txtEvidenceDetails.Enabled = false;
                        txtAuditDecision.Text = GVDetailsFromAssessment.Rows[i].Cells[8].Text.Trim();
                        txtAuditDecision.Enabled = false;

                        if (GVDetailsFromAssessment.Rows[i].Cells[11].Text.Trim() != "&nbsp;")
                        {
                            txtToAuditee.Text = GVDetailsFromAssessment.Rows[i].Cells[11].Text.Trim();
                        }
                        txtToAuditee.Enabled = false;

                        HdnGAPID.Value = GVDetailsFromAssessment.Rows[i].Cells[5].Text.Trim();
                        GetDetailsReturnedFromStatusUpdate();
                        pnlAuditeeCAPDetails.Visible = true;
                        pnlSearchForAssessmentDetails.Visible = false;

                        if (txtToAuditee.Text.Trim().ToUpper() == Convert.ToString(Session["UserName"]).ToUpper())
                        {
                            BtnSave.Visible = true;
                        }
                        else
                        {
                            BtnSave.Visible = false;
                        }
                        break;
                    }
                    else
                    {
                        lblMsgXls.Visible = true;
                        lblMsgXls.Text = "Please Select atleast One Record"; //"Error :";
                    }
                }
            }
            catch (Exception ex)
            {
                lblMsgXls.Visible = true;
                lblMsgXls.Text = "Error :" + ex.Message;
            }
        }


        protected bool SaveData()
        {
            string msg = string.Empty;
            string EvidenceAttached = UploadAttachment_OnServer();
            bool validation = false;

            if (txtCorrectionWithReferenceToEvidence.Text.Trim() == "" || txtCorrectionWithReferenceToEvidence.Text.Trim() == null)
            {
                msg = msg + "PleaseEnter Correction With Respect to Evidence";
            }
            if (txtRootCauseAnalysis.Text.Trim() == "" || txtRootCauseAnalysis.Text.Trim() == null)
            {
                msg = msg + "Please Enter Root Cause Analysis ";
            }
            if (txtAction.Text.Trim() == "" || txtAction.Text.Trim() == null)
            {
                msg = msg + "Please Enter Action";
            }
            if (txtResponse.Text.Trim() == "" || txtResponse.Text.Trim() == null)
            {
                msg = msg + "Please Enter Response";
            }
            if (txtTargateDate.Text.Trim() == "" || txtTargateDate.Text.Trim() == null)
            {
                msg = msg + "Please Enter Targate Date";
            }

            if (msg != "")
            {
                validation = false;
                ClientScript.RegisterStartupScript(Page.GetType(), "mykey", "alert('" + msg + "');", true);
                return validation;
            }
            SqlConnection sqlCon = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);

            SqlCommand cmd = new SqlCommand("InternalAudit_SaveAuditeeCAPData_SP", sqlCon);
            cmd.CommandType = CommandType.StoredProcedure;
            //cmd.Parameters.AddWithValue("@ID", Convert.ToInt32(hdnAuditID.Value));
            cmd.Parameters.AddWithValue("@GAP_ID", txtGAPID.Text);
            cmd.Parameters.AddWithValue("@ClauseOrControl", txtClauseOrControl.Text);
            cmd.Parameters.AddWithValue("@EvidenceDetails", txtEvidenceDetails.Text);
            cmd.Parameters.AddWithValue("@AuditDecision", txtAuditDecision.Text);
            cmd.Parameters.AddWithValue("@CorrectionWithRespectToEvidence", txtCorrectionWithReferenceToEvidence.Text);
            cmd.Parameters.AddWithValue("@RootCauseAnalysis", txtRootCauseAnalysis.Text);
            cmd.Parameters.AddWithValue("@Action", txtAction.Text);
            cmd.Parameters.AddWithValue("@Response", txtResponse.Text);
            cmd.Parameters.AddWithValue("@TargateDate", strDate(txtTargateDate.Text));
            cmd.Parameters.AddWithValue("@EvidenceAttached", EvidenceAttached);
            cmd.Parameters.AddWithValue("@UserID", Convert.ToString(Session["UserID"]));
            cmd.Parameters.AddWithValue("@ToAuditee", txtToAuditee.Text.Trim());

            sqlCon.Open();
            int result = cmd.ExecuteNonQuery();
            sqlCon.Close();

            if (result > 0)
            {
                lblMsgXls.Visible = true;
                lblMsgXls.Text = "Data Saved Successfully!!";
                validation = true;
            }

            return validation;
        }

        protected void ClearData()
        {
            //ddlQuarter.SelectedIndex = 0;
            //ddlBranch.SelectedIndex = 0;
            // ddlVertical.SelectedIndex = 0;
            txtGAPID.Text = "";
            txtClauseOrControl.Text = "";
            txtEvidenceDetails.Text = "";
            txtAuditDecision.Text = "";
            txtCorrectionWithReferenceToEvidence.Text = "";
            txtRootCauseAnalysis.Text = "";
            txtAction.Text = "";
            txtResponse.Text = "";
            txtTargateDate.Text = "";
            FUEvidenceAttached.Dispose();

        }
        protected void BtnSave_Click(object sender, EventArgs e)
        {
            if (Session["UserID"] != null)
            {
                bool result = SaveData();
                if (result)
                {
                    ClearData();
                    GetAssessmentDetailsForAuditee();
                    pnlSearchForAssessmentDetails.Visible = true;
                    pnlAuditeeCAPDetails.Visible = false;
                    BtnSave.Visible = false;
                }
            }
            else
            {

                Response.Redirect("Login.aspx", false);
            }
        }
        //protected void btnBack_Click2(object sender, EventArgs e)
        //{
        //    Response.Redirect("InternalAudit_Menu.aspx", false);
        //}

        protected void BtnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("InternalAudit_Menu.aspx", false);
        }
    }
}