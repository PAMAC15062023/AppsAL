using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using YesBank;

namespace InternalAuditApplication
{
    public partial class InternalAudit_StatusUpdate : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindQuarter();
                BindBranch();
                BindVertical();
                BindScopeNonScope();

                pnlSearchForAuditeeCapDetails.Visible = true;
                pnlGridForAssessmentDetails.Visible = false;
                pnlStatusUpdate.Visible = false;
                PnlButtons.Visible = false;
            }
        }

        protected void BindQuarter()
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
                string msg = ex.ToString();
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
                string msg = ex.ToString();
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
                string msg = ex.ToString();
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
                string msg = ex.ToString();
            }
        }
        protected void GetAssessmentDetailsForAuditee()
        {
            try
            {

                string Scope_NonScope = "";

                if (ddlScopeNonScope.SelectedItem.Text != "--Select--")
                {
                    Scope_NonScope =  ddlScopeNonScope.SelectedItem.Text;
                }

                SqlConnection sqlCon = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);

                SqlCommand sqlCom = new SqlCommand();
                sqlCom.Connection = sqlCon;
                sqlCom.CommandType = CommandType.StoredProcedure;
                sqlCom.CommandText = "InternalAudit_GetDataForStatusUpdateSearchWise_SP";
                sqlCom.CommandTimeout = 0;

                SqlParameter Quarter = new SqlParameter();
                Quarter.SqlDbType = SqlDbType.VarChar;
                Quarter.Value = ddlQuarter.SelectedItem.Text;
                Quarter.ParameterName = "@Quarter";
                sqlCom.Parameters.Add(Quarter);

                SqlParameter Branch = new SqlParameter();
                Branch.SqlDbType = SqlDbType.VarChar;
                Branch.Value = ddlBranch.SelectedItem.Text;
                Branch.ParameterName = "@Branch";
                sqlCom.Parameters.Add(Branch);

                SqlParameter Vertical = new SqlParameter();
                Vertical.SqlDbType = SqlDbType.VarChar;
                Vertical.Value = ddlVertical.SelectedItem.Text;
                Vertical.ParameterName = "@Vertical";
                sqlCom.Parameters.Add(Vertical);

                SqlParameter ScopeNonScope = new SqlParameter();
                ScopeNonScope.SqlDbType = SqlDbType.VarChar;
                ScopeNonScope.Value = Scope_NonScope;
                ScopeNonScope.ParameterName = "@ScopeNonScope";
                sqlCom.Parameters.Add(ScopeNonScope);

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

                    hdnGridviewRowCount.Value = Convert.ToString(GVDetailsFromAssessment.Rows.Count);



                    GVDetailsFromAssessment.Rows[0].Cells[0].Enabled = false;
                    GVDetailsFromAssessment.Rows[0].Cells[1].Enabled = false;

                }
                else
                {
                    GVDetailsFromAssessment.DataSource = null;
                    GVDetailsFromAssessment.DataBind();

                    hdnGridviewRowCount.Value = "0";

                    lblMsgXls.Visible = true;
                    lblMsgXls.Text = "No Case Found";
                }
            }
            catch (Exception ex)
            {
                lblMsgXls.Visible = true;
                lblMsgXls.Text = ex.ToString();
            }


        }
        protected void BtnSearch_Click(object sender, EventArgs e)
        {
            pnlGridForAssessmentDetails.Visible = true;
            pnlSearchForAuditeeCapDetails.Visible = false;
            pnlStatusUpdate.Visible = false;
            PnlButtons.Visible = false;
            GetAssessmentDetailsForAuditee();
        }

        protected void GetDetailsForStatusUpdate()
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
                //GVDetailsFromAssessment.DataSource = dt;
                //GVDetailsFromAssessment.DataBind();

                //GVDetailsFromAssessment.Rows[0].Cells[0].Enabled = false;
                //GVDetailsFromAssessment.Rows[0].Cells[1].Enabled = false;
                txtEvidencedetailsforweakness.Text = dt.Rows[0]["EvidenceDetailsForWeekness"].ToString(); //add on 31/08/2024
                //txtEvidencedetailsforweakness.Enabled = false;//add on 31/08/2024
                txtCorrectionWithReferenceToEvidence.Text = dt.Rows[0]["CorrectionWithReferenceToEvidence"].ToString();
                //txtCorrectionWithReferenceToEvidence.Enabled = false;
                txtRootCauseAnalysis.Text = dt.Rows[0]["RootCauseAnalysis"].ToString();
                //txtRootCauseAnalysis.Enabled = false;
                txtAction.Text = dt.Rows[0]["Action"].ToString();
                //txtAction.Enabled = false;
                txtResponse.Text = dt.Rows[0]["Response"].ToString();
                //txtResponse.Enabled = false;
                txtTargateDate.Text = dt.Rows[0]["TargetDate"].ToString();
                txtTargateDate.Enabled = false;
                txtViewAndDownload.Text = dt.Rows[0]["EvidenceAttached"].ToString();
                txtViewAndDownload.Enabled = false;
                hdnFileName.Value = dt.Rows[0]["EvidenceAttached"].ToString();
                hdnAuditorEmailId.Value = dt.Rows[0]["AuditorEmailId"].ToString();
                hdnNameOfAuditor.Value = dt.Rows[0]["NameOfAuditor"].ToString();
                hdnAuditeeEmailId.Value = dt.Rows[0]["AuditeeEmailId"].ToString();
                hdnNameOfAuditee.Value = dt.Rows[0]["NameOfAuditee"].ToString();
            }
            else
            {
                GVDetailsFromAssessment.DataSource = null;
                GVDetailsFromAssessment.DataBind();

                lblMsgXls.Visible = true;
                lblMsgXls.Text = "No Case Found";
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
        protected void lkbtnEdit_Click(object sender, EventArgs e)
        {
            pnlGridForAssessmentDetails.Visible = false;
            pnlSearchForAuditeeCapDetails.Visible = false;
            BindFinalStatus();
            try
            {
                for (int i = 0; i <= GVDetailsFromAssessment.Rows.Count - 1; i++)
                {
                    CheckBox chkSelect = (CheckBox)GVDetailsFromAssessment.Rows[i].FindControl("chkbox");

                    LinkButton WIP = (LinkButton)GVDetailsFromAssessment.Rows[i].FindControl("lkbtnRemove");

                    if (chkSelect.Checked == true)
                    {
                        pnlStatusUpdate.Visible = true;
                        PnlButtons.Visible = true;
                        hdnIDForStatusUpdate.Value = GVDetailsFromAssessment.DataKeys[i].Value.ToString();
                        HdnGAPID.Value = GVDetailsFromAssessment.Rows[i].Cells[5].Text.Trim();
                        GetDetailsForStatusUpdate();
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

        private void DownloadFile(string fname, bool forceDownload)
        {
            try
            {
                string path = fname;
                string name = Path.GetFileName(path);
                string ext = Path.GetExtension(path);
                string type = "";
                // set known types based on file extension  
                if (ext != null)
                {
                    switch (ext.ToLower())
                    {
                        case ".txt":
                            type = "text/plain";
                            break;
                        case ".doc":
                        case ".rtf":
                            type = "Application/msword";
                            break;
                        case ".zip":
                            type = "application/zip";
                            break;
                        case ".xls":
                            type = "application/vnd.ms-excel";
                            break;
                    }
                }

                if (forceDownload)

                    Response.ClearHeaders();
                Response.ClearContent();
                Response.Clear();

                {
                    Response.AppendHeader("content-disposition", "attachment; filename=" + hdnFileName.Value);
                    path = "~/InternalAuditApplication/UploadedFiles/" + hdnFileName.Value + "";
                }
                if (type != "")

                    Response.ContentType = type;
                Response.WriteFile(path);
                Response.End();
                // HttpContext.Current.ApplicationInstance.CompleteRequest();
            }
            catch (Exception ex)
            {
                lblMsgXls.Text = "Error:" + ex.Message;

            }
        }
        protected void btnViewAndDownLoad_Click(object sender, EventArgs e)
        {

            try
            {
                if (hdnFileName.Value != "" && hdnFileName.Value != null)
                {
                    string strURL = "UploadedFiles/" + hdnFileName.Value;
                    WebClient req = new WebClient();
                    HttpResponse response = HttpContext.Current.Response;
                    response.Clear();
                    response.ClearContent();
                    response.ClearHeaders();
                    response.Buffer = true;
                    response.AddHeader("Content-Disposition", "attachment;filename=\"" + Server.MapPath(strURL) + "\"");
                    byte[] data = req.DownloadData(Server.MapPath(strURL));
                    response.BinaryWrite(data);
                    response.End();
                }
            }
            catch (Exception ex)
            {
                string msg = ex.ToString();
            }



        }

        protected bool SaveData()
        {
            string msg = string.Empty;
            bool validation = false;

            if (ddlFinalStatus.SelectedValue == "--Select--")
            {
                msg = msg + "Please Select Final Status ";
            }
            if (txtVerificationOfCAPByAuditor.Text.Trim() == "" || txtVerificationOfCAPByAuditor.Text.Trim() == null)
            {
                msg = msg + "Please Enter Verification Remark By Auditor ";
            }
            if (txtCAPVerticiationDate.Text.Trim() == "" || txtCAPVerticiationDate.Text.Trim() == null)
            {
                msg = msg + "Please Enter CAP Verticiation Date";
            }

            if (msg != "")
            {
                validation = false;
                ClientScript.RegisterStartupScript(Page.GetType(), "mykey", "alert('" + msg + "');", true);
                return validation;
            }

            SqlConnection sqlCon = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);

            SqlCommand cmd = new SqlCommand("InternalAudit_SaveDataForStatusUpdate_SP", sqlCon);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@GAP_ID", HdnGAPID.Value);
            cmd.Parameters.AddWithValue("@EvidenceDetails", txtEvidencedetailsforweakness.Text); //add on 29/11/2024
            cmd.Parameters.AddWithValue("@CorrectionWithReferenceToEvidence", txtCorrectionWithReferenceToEvidence.Text); //add on 29/11/2024
            cmd.Parameters.AddWithValue("@RootCauseAnalysis", txtRootCauseAnalysis.Text); //add on 29/11/2024
            cmd.Parameters.AddWithValue("@CorrectiveActionTaken", txtAction.Text); //add on 29/11/2024
            cmd.Parameters.AddWithValue("@Response", txtResponse.Text); //add on 29/11/2024
            cmd.Parameters.AddWithValue("@VerificationOfGAPByAuditor", txtVerificationOfCAPByAuditor.Text);
            cmd.Parameters.AddWithValue("@CAPVerticiationDate", strDate(txtCAPVerticiationDate.Text));
            cmd.Parameters.AddWithValue("@FinalStatus", ddlFinalStatus.SelectedItem.Text);
            cmd.Parameters.AddWithValue("@UserID", Convert.ToString(Session["UserID"]));

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
            txtEvidencedetailsforweakness.Text = "";
            txtCorrectionWithReferenceToEvidence.Text = "";
            txtRootCauseAnalysis.Text = "";
            txtAction.Text = "";
            txtResponse.Text = "";
            txtTargateDate.Text = "";
            txtVerificationOfCAPByAuditor.Text = "";
            txtRootCauseAnalysis.Text = "";
            txtCAPVerticiationDate.Text = "";
            ddlFinalStatus.SelectedIndex = 0;
        }
        protected void BtnClose_Click(object sender, EventArgs e)
        {
            if (Session["UserID"] != null)
            {
                bool result = SaveData();
                if (result)
                {
                    ClearData();
                    pnlStatusUpdate.Visible = false;
                    PnlButtons.Visible = false;

                    GetAssessmentDetailsForAuditee();

                    int GVRowCount = Convert.ToInt32(hdnGridviewRowCount.Value);
                    if (GVRowCount > 0)
                    {
                        pnlGridForAssessmentDetails.Visible = true;
                        pnlSearchForAuditeeCapDetails.Visible = false;
                    }
                    else
                    {
                        pnlSearchForAuditeeCapDetails.Visible = true;
                        pnlGridForAssessmentDetails.Visible = false;
                    }
                }
            }
            else
            {
                Session.Clear();
                Response.Redirect("Login.aspx", false);
            }
        }

        protected bool ReturnDataToAuditee()
        {
            string msg = string.Empty;
            bool validation = false;

            if (ddlFinalStatus.SelectedValue == "--Select--")
            {
                msg = msg + "Please Select Final Status ";
            }
            if (txtVerificationOfCAPByAuditor.Text.Trim() == "" || txtVerificationOfCAPByAuditor.Text.Trim() == null)
            {
                msg = msg + "Please Enter Verification Of CAP By Auditor ";
            }
            if (txtCAPVerticiationDate.Text.Trim() == "" || txtCAPVerticiationDate.Text.Trim() == null)
            {
                msg = msg + "Please Enter CAP Verticiation Date";
            }

            if (msg != "")
            {
                validation = false;
                ClientScript.RegisterStartupScript(Page.GetType(), "mykey", "alert('" + msg + "');", true);
                return validation;
            }
            SqlConnection sqlCon = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);

            SqlCommand sqlCom = new SqlCommand();
            sqlCom.Connection = sqlCon;
            sqlCom.CommandType = CommandType.StoredProcedure;
            sqlCom.CommandText = "InternalAudit_SaveDataForStatusUpdate_SP";
            sqlCom.CommandTimeout = 0;

            sqlCom.Parameters.AddWithValue("@GAP_ID", HdnGAPID.Value);
            sqlCom.Parameters.AddWithValue("@EvidenceDetails", txtEvidencedetailsforweakness.Text); //add on 29/11/2024
            sqlCom.Parameters.AddWithValue("@CorrectionWithReferenceToEvidence", txtCorrectionWithReferenceToEvidence.Text); //add on 29/11/2024
            sqlCom.Parameters.AddWithValue("@RootCauseAnalysis", txtRootCauseAnalysis.Text); //add on 29/11/2024
            sqlCom.Parameters.AddWithValue("@CorrectiveActionTaken", txtAction.Text); //add on 29/11/2024
            sqlCom.Parameters.AddWithValue("@Response", txtResponse.Text); //add on 29/11/2024
            sqlCom.Parameters.AddWithValue("@VerificationOfGAPByAuditor", txtVerificationOfCAPByAuditor.Text);
            sqlCom.Parameters.AddWithValue("@CAPVerticiationDate", strDate(txtCAPVerticiationDate.Text));
            sqlCom.Parameters.AddWithValue("@FinalStatus", ddlFinalStatus.SelectedItem.Text);
            sqlCom.Parameters.AddWithValue("@UserID", Convert.ToString(Session["UserID"]));

            sqlCon.Open();

            int result = sqlCom.ExecuteNonQuery();

            sqlCon.Close();

            if (result > 0)
            {
                validation = true;
                lblMsgXls.Visible = true;
                lblMsgXls.Text = "Return to Auditee";

            }
            else
            {
                validation = false;

                lblMsgXls.Visible = true;
                lblMsgXls.Text = "Error";
            }

            return validation;
        }
        protected void BtnReturn_Click(object sender, EventArgs e)
        {

            if (Session["UserID"] != null)
            {
                bool result = ReturnDataToAuditee();
                if (result)
                {
                    SendMail();
                    pnlStatusUpdate.Visible = false;
                    PnlButtons.Visible = false;
                    ClearData();

                    GetAssessmentDetailsForAuditee();

                    int GVRowCount = Convert.ToInt32(hdnGridviewRowCount.Value);
                    if (GVRowCount > 0)
                    {
                        pnlGridForAssessmentDetails.Visible = true;
                        pnlSearchForAuditeeCapDetails.Visible = false;
                    }
                    else
                    {
                        pnlSearchForAuditeeCapDetails.Visible = true;
                        pnlGridForAssessmentDetails.Visible = false;
                    }

                }
            }
            else
            {
                Session.Clear();
                Response.Redirect("Login.aspx", false);
            }
        }
        protected void BtnBack1_Click(object sender, EventArgs e)
        {
            Response.Redirect("InternalAudit_Menu.aspx", false);
        }

        protected void ddlFinalStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlFinalStatus.SelectedItem.Text == "Open")
            {
                BtnClose.Visible = false;
                BtnReturn.Visible = true;
            }
            else if (ddlFinalStatus.SelectedItem.Text == "Close")
            {
                BtnReturn.Visible = false;
                BtnClose.Visible = true;
            }
        }
        protected void SendMail()
        {
            try
            {

                System.Net.Mail.MailMessage mail = new System.Net.Mail.MailMessage();
                mail.Subject = "Internal Audit Response From Auditor";
                mail.From = new MailAddress("software.support@pamac.com");

                string MailTo = hdnAuditeeEmailId.Value;
                string MailCC = hdnAuditorEmailId.Value;

                mail.To.Add(MailTo);
                mail.CC.Add(MailCC.TrimEnd(','));

                string strBody =
                           "<html><body><font color=\"Navy\" style=\"font-style=Italic;font-weight=bold\">" +
                           "<P></P>" +
                           "<P>Dear " + hdnNameOfAuditee.Value + ",</P>" +
                           "<P>Action updated by You against {" + HdnGAPID.Value + "} has been rejected by the auditor,</P>" +
                           "<P>Kindly login to the portal {" + " https://internalaudit.pamac-online.com  " + "} and update the correct action and upload the evidence,</P>" +
                           "<P>Please ensure action on the same at the earliest to avoid the escalation.</P>" +
                           "<P>*This Is An Automatically Generated Email, Please Do Not Reply*</P>" +
                           "<P></P>" +
                           "<P>Regards,</P>" +
                           "<P>" + hdnNameOfAuditor.Value + "</P> " +
                           "</font></html></body>";

                mail.Body = strBody;
                mail.IsBodyHtml = true;
                SmtpClient smtp = new SmtpClient("mail.pamac.com", 587);
                smtp.Credentials = new System.Net.NetworkCredential("software.support@pamac.com", "_ug7rogzH");
                smtp.EnableSsl = false;
                smtp.Send(mail);
            }
            catch (Exception ex)
            {
                string msg = ex.ToString();
            }
        }
        protected void BindScopeNonScope()
        {
            try
            {
                SqlConnection sqlCon = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);

                SqlCommand sqlCom = new SqlCommand();
                sqlCom.Connection = sqlCon;
                sqlCom.CommandType = CommandType.StoredProcedure;
                sqlCom.CommandText = "InternalAudit_BindScopeNonScope_SP";
                sqlCom.CommandTimeout = 0;

                SqlDataAdapter da = new SqlDataAdapter(sqlCom);
                DataSet ds = new DataSet();
                da.Fill(ds);

                if (ds != null && ds.Tables.Count > 0)
                {
                    ddlScopeNonScope.DataTextField = "ScopeORNonscope";
                    ddlScopeNonScope.DataValueField = "ScopeORNonscope";
                    ddlScopeNonScope.DataSource = ds.Tables[0];
                    ddlScopeNonScope.DataBind();

                    ddlScopeNonScope.Items.Insert(0, "--Select--");
                    ddlScopeNonScope.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                lblMsgXls.Visible = true;
                lblMsgXls.Text = ex.ToString();
            }
        }

    }
}