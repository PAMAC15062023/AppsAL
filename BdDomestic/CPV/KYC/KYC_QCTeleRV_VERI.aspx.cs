using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.OleDb;
using System.Data.SqlClient;

public partial class CPV_KYC_KYC_QCTeleRV_VERI : System.Web.UI.Page
{
    //string verificationType = "RV";
    CKYCVerification objKYC = new CKYCVerification();

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                if (Context.Request.QueryString["CaseID"] != null && Context.Request.QueryString["CaseID"] != "" && Context.Request.QueryString["VerTypeId"] != null && Context.Request.QueryString["VerTypeId"] != "")
                {

                    txtCaseID.Text = Context.Request.QueryString["CaseID"];
                    hdnVeriTypeId.Value = Context.Request.QueryString["VerTypeId"];
                    int VeriType = Convert.ToInt32(hdnVeriTypeId.Value);
                    Get_Details_For_QCTele(txtCaseID.Text.Trim(), VeriType, "KYC");

                    if ((hdnVeriTypeId.Value == "29"))  //for RV
                        lblhead.Text = "QC Tele Residence Verification";
                    else if ((hdnVeriTypeId.Value == "30"))
                        lblhead.Text = "QC Tele Business Verification";

                    if ((Request.QueryString["Mode"] != null) && (Request.QueryString["Mode"] != ""))
                    {
                        hidMode.Value = Request.QueryString["Mode"].ToString();
                    }

                }

                if (hidMode.Value == "View")
                {
                    ReadOnly();
                    
                }

            }

        }
        catch (Exception Ex)
        {
            lblMessage.Text = Ex.Message;
        }


    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            //if (IsValidAttempt())
            //{
            Insert_Details_For_QCTele();
            hdnVeriTypeId.Value = Context.Request.QueryString["VerTypeId"];
            int veritype1 = Convert.ToInt32(hdnVeriTypeId.Value);
            Get_Details_For_QCTele(txtCaseID.Text.Trim(), veritype1, "KYC");

            //}
        }
        catch (Exception Ex)
        {
            lblMessage.Text = Ex.Message;
        }

    }
    private void Insert_Details_For_QCTele()
    {
        try
        {


            SqlConnection sqlCon = new SqlConnection(ConfigurationManager.AppSettings["constring"]);
            sqlCon.Open();
            SqlCommand sqlCom = new SqlCommand();
            sqlCom.Connection = sqlCon;
            sqlCom.CommandType = CommandType.StoredProcedure;
            sqlCom.CommandText = "Insert_Record_QCTELE_FIELD";
            sqlCom.CommandTimeout = 0;

            SqlParameter Case_Id = new SqlParameter();
            Case_Id.SqlDbType = SqlDbType.VarChar;
            Case_Id.ParameterName = "@CASE_ID";
            Case_Id.Value = txtCaseID.Text.Trim();
            sqlCom.Parameters.Add(Case_Id);

            SqlParameter Verification_Type_Id = new SqlParameter();
            Verification_Type_Id.SqlDbType = SqlDbType.Int;
            Verification_Type_Id.ParameterName = "@Verification_Type_Id";
            Verification_Type_Id.Value = hdnVeriTypeId.Value;
            sqlCom.Parameters.Add(Verification_Type_Id);

            SqlParameter Product = new SqlParameter();
            Product.SqlDbType = SqlDbType.VarChar;
            Product.ParameterName = "@Product";
            Product.Value = "KYC";
            sqlCom.Parameters.Add(Product);

            SqlParameter Phone_No = new SqlParameter();
            Phone_No.SqlDbType = SqlDbType.VarChar;
            Phone_No.ParameterName = "@Phone_No";
            Phone_No.Value = txtPhoneNo.Text.Trim();
            sqlCom.Parameters.Add(Phone_No);

            SqlParameter Spoken_To = new SqlParameter();
            Spoken_To.SqlDbType = SqlDbType.VarChar;
            Spoken_To.ParameterName = "@Spoken_To";
            Spoken_To.Value = txtspokento.Text.Trim();
            sqlCom.Parameters.Add(Spoken_To);

            SqlParameter Relationship = new SqlParameter();
            Relationship.SqlDbType = SqlDbType.VarChar;
            Relationship.ParameterName = "@Relationship";
            Relationship.Value = txtRelationship.Text.Trim();
            sqlCom.Parameters.Add(Relationship);

            SqlParameter Greeted_the_Applicant = new SqlParameter();
            Greeted_the_Applicant.SqlDbType = SqlDbType.VarChar;
            Greeted_the_Applicant.ParameterName = "@Greeted_the_Applicant";
            Greeted_the_Applicant.Value = ddlGreetedtheApplicant.Text.Trim();
            sqlCom.Parameters.Add(Greeted_the_Applicant);

            SqlParameter Appearance = new SqlParameter();
            Appearance.SqlDbType = SqlDbType.VarChar;
            Appearance.ParameterName = "@Appearance";
            Appearance.Value = txtAppearance.Text.Trim();
            sqlCom.Parameters.Add(Appearance);

            SqlParameter ID_card_Shown = new SqlParameter();
            ID_card_Shown.SqlDbType = SqlDbType.VarChar;
            ID_card_Shown.ParameterName = "@ID_card_Shown";
            ID_card_Shown.Value = ddlAIDcardshown.Text.Trim();
            sqlCom.Parameters.Add(ID_card_Shown);

            SqlParameter Over_Questioning = new SqlParameter();
            Over_Questioning.SqlDbType = SqlDbType.VarChar;
            Over_Questioning.ParameterName = "@Over_Questioning";
            Over_Questioning.Value = txtOverQuestioning.Text.Trim();
            sqlCom.Parameters.Add(Over_Questioning);

            SqlParameter Behaviour = new SqlParameter();
            Behaviour.SqlDbType = SqlDbType.VarChar;
            Behaviour.ParameterName = "@Behaviour";
            Behaviour.Value = txtBehaviour.Text.Trim();
            sqlCom.Parameters.Add(Behaviour);

            SqlParameter Proof_of_visit_obtained = new SqlParameter();
            Proof_of_visit_obtained.SqlDbType = SqlDbType.VarChar;
            Proof_of_visit_obtained.ParameterName = "@Proof_of_visit_obtained";
            Proof_of_visit_obtained.Value = ddlProofofVisitObtained.Text.Trim();
            sqlCom.Parameters.Add(Proof_of_visit_obtained);

            SqlParameter Form_Filled_in_front = new SqlParameter();
            Form_Filled_in_front.SqlDbType = SqlDbType.VarChar;
            Form_Filled_in_front.ParameterName = "@Form_Filled_in_front";
            Form_Filled_in_front.Value = ddlFormFilledInFront.Text.Trim();
            sqlCom.Parameters.Add(Form_Filled_in_front);

            SqlParameter Feedback_if_any = new SqlParameter();
            Feedback_if_any.SqlDbType = SqlDbType.VarChar;
            Feedback_if_any.ParameterName = "@Feedback_if_any";
            Feedback_if_any.Value = txtFeedbackIfAny.Text.Trim();
            sqlCom.Parameters.Add(Feedback_if_any);


            SqlParameter Place_Of_Call = new SqlParameter();
            Place_Of_Call.SqlDbType = SqlDbType.VarChar;
            Place_Of_Call.ParameterName = "@Place_Of_Call";
            Place_Of_Call.Value = ddlPlaceOfCall.Text.Trim();
            sqlCom.Parameters.Add(Place_Of_Call);

            SqlParameter Message = new SqlParameter();
            Message.SqlDbType = SqlDbType.VarChar;
            Message.Direction = ParameterDirection.Output;
            Message.Size = 100;
            Message.ParameterName = "@Message";
            Message.Value = "";
            sqlCom.Parameters.Add(Message);


            int intRow = sqlCom.ExecuteNonQuery();
            string strMessage = sqlCom.Parameters["@Message"].Value.ToString();

            sqlCon.Close();

            lblMessage.CssClass = "UpdateMessage";
            lblMessage.Text = strMessage;
            lblMessage.Visible = true;

            if (intRow > 0)
            {
                //lblMessage.CssClass = "UpdateMessage";
                //lblMessage.Text = "Record Successfully Updated!";
                //lblMessage.Visible = true;
            }

         
        }
        catch (Exception Ex)
        {
            lblMessage.Text = Ex.Message;
        }

    }
    private void Get_Details_For_QCTele(string pCaseId, int pVerificationTypeID, string pProductId)
    {
        try
        {

            SqlConnection sqlCon = new SqlConnection(ConfigurationManager.AppSettings["constring"]);
            sqlCon.Open();
            SqlCommand sqlCom = new SqlCommand();
            sqlCom.Connection = sqlCon;
            sqlCom.CommandType = CommandType.StoredProcedure;
            sqlCom.CommandText = "Get_Record_For_QCTELE_FIELD";
            sqlCom.CommandTimeout = 0;

            SqlParameter Case_Id = new SqlParameter();
            Case_Id.SqlDbType = SqlDbType.VarChar;
            Case_Id.ParameterName = "@Case_Id";
            Case_Id.Value = pCaseId;
            sqlCom.Parameters.Add(Case_Id);

            SqlParameter Verification_Type_ID = new SqlParameter();
            Verification_Type_ID.SqlDbType = SqlDbType.Int;
            Verification_Type_ID.ParameterName = "@Verification_Type_ID";
            Verification_Type_ID.Value = pVerificationTypeID;
            sqlCom.Parameters.Add(Verification_Type_ID);

            SqlParameter Product = new SqlParameter();
            Product.SqlDbType = SqlDbType.VarChar;
            Product.ParameterName = "@Product";
            Product.Value = pProductId;
            sqlCom.Parameters.Add(Product);

            SqlDataAdapter sqlDA = new SqlDataAdapter();
            sqlDA.SelectCommand = sqlCom;
            DataSet ds = new DataSet();
            sqlDA.Fill(ds);
            sqlCon.Close();
            if (ds.Tables[0].Rows.Count > 0)
            {
                Assign_RV_Details(ds.Tables[0]);
            }
            else
            {
                lblMessage.CssClass = "ErrorMessage";
                lblMessage.Text = "No Details found!!!!";
            }
        }
        catch (Exception Ex)
        {
            lblMessage.Text = Ex.Message;
        }

    }
    private void Assign_RV_Details(DataTable dt)
    {
        try
        {
            txtReferenceNo.Text = dt.Rows[0]["Ref_No"].ToString().Trim();
            txtApplicantName.Text = dt.Rows[0]["Applicant_Name"].ToString().Trim();

            txtProductName.Text = dt.Rows[0]["Product_Name"].ToString();
            txtDateOfVerification.Text = dt.Rows[0]["Verification_DATE"].ToString().Trim();
            txtFe.Text = dt.Rows[0]["FE_NAME"].ToString().Trim();
            txtNameOfthePersonMet.Text = dt.Rows[0]["PERSON_CONTACTED_MET"].ToString().Trim();

            // txtTimeOfVerification.Text  = dt.Rows[0]["DATE_TIME_VISIT"].ToString().Trim();
            string date_time = dt.Rows[0]["DATE_TIME_VISIT"].ToString().Trim();
            string[] arrAttemptDateTime = date_time.Split(' ');
            if (date_time != "")
            {
                txtTimeOfVerification.Text = Convert.ToDateTime(arrAttemptDateTime[1].ToString()).ToString("hh:mm");
            }
            txtPhoneNo.Text = dt.Rows[0]["Phone"].ToString().Trim();
            ddlPlaceOfCall.SelectedValue = dt.Rows[0]["Place_of_Call"].ToString().Trim();
            txtspokento.Text = dt.Rows[0]["Spoken_To"].ToString().Trim();
            txtRelationship.Text = dt.Rows[0]["Relationship"].ToString().Trim();
            ddlGreetedtheApplicant.SelectedValue = dt.Rows[0]["Greeted_the_Applicant"].ToString().Trim();

            txtAppearance.Text = dt.Rows[0]["Appearance"].ToString().Trim();
            ddlAIDcardshown.SelectedValue = dt.Rows[0]["ID_card_Shown"].ToString().Trim();
            txtOverQuestioning.Text = dt.Rows[0]["Over_Questioning"].ToString().Trim();

            txtBehaviour.Text = dt.Rows[0]["Behaviour"].ToString().Trim();
            ddlProofofVisitObtained.SelectedValue = dt.Rows[0]["Proof_of_visit_obtained"].ToString().Trim();

            ddlFormFilledInFront.SelectedValue = dt.Rows[0]["Form_Filled_in_front"].ToString().Trim();
            txtFeedbackIfAny.Text = dt.Rows[0]["Feedback_if_any"].ToString().Trim();

        }
        catch (Exception Ex)
        {
            lblMessage.Text = Ex.Message;
        }
    }

    private void ReadOnly()
    {
        btnSave.Enabled = false;
        btnCancel.Enabled = false;
     }

}
