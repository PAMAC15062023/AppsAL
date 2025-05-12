using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

public partial class Pages_ChequeProcessingNEW_ChequeEntryNew : System.Web.UI.Page
{
    int CID;
    string Client;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserInfo"] == null)
        {
            Response.Redirect("~/Pages/InvalidRequest.aspx");

        }

        ddlReasonList.Enabled = true;
        if (hdncheqdate.Value != "" && hdncheqdate.Value != "0")
        {
            Label1.Text = hdncheqdate.Value;
            if (Label1.Text == "Valid Cheque")
                ddlReasonList.Enabled = false;
            else
                ddlReasonList.Enabled = true;
        }
        if (hdnchkstat.Value != "" && hdnchkstat.Value != "0")
        {
            lblChequeStatus.Text = hdnchkstat.Value;
        }
        if (hdnArray.Value != "" && hdnArray.Value != "0")
        {
            string abc = hdnArray.Value;
            string[] arr = abc.Split(',');

            HiddenField1.Value = abc;

        }

        //if (hdnsuspCardNo.Value != "" && hdnsuspCardNo.Value != "0")
        //{
        //    Label2.Text = hdnsuspCardNo.Value;
        //}
        //else
        //{
        //    Label2.Text = "";
        //}
        //if (hdnChequeStaus.Value == "0")
        //{
        //    lblChequeStatus.Text = "Valid";
        //    // ddlReasonList.disabled = true;
        //}

        //else
        //{

        //    lblChequeStatus.Text = "Invalid";


        //}
        if (!IsPostBack)
        {
            if (Request.QueryString["BN"] != null)
            {
                if (Request.QueryString["Vw"] != null)
                {
                    btnSave.Visible = false;
                }
                if (Request.QueryString["TID"] != null)
                {
                    hdnTransactionDetailID.Value = Request.QueryString["TID"].ToString();
                }
                if (Request.QueryString["CT"] != null)
                {
                    hdnchequeCategory.Value = Request.QueryString["CT"].ToString();

                }
                txtBatchNo.Text = Request.QueryString["BN"].ToString();



                Register_ControlsWith_JavaScript();

                Get_BatchDetailsHeaders();
                Get_DropBoxDetailsHeaders();
                Get_ReasonList();
                Get_MICRDetails();
                Get_Bin_Logo_Details();

            }

        }
        else
        {

            Get_BatchDetailsHeaders();

            Get_NewCount();

            int CapCount = Convert.ToInt32(Session["CapturedChequeCount"]);
            int TotCount = Convert.ToInt32(Session["TotalChequeCount"]);
            if (CapCount == TotCount)
            {
                ddlDropBoxList.Enabled = true;
            }
            if (CapCount != TotCount)
            {
                if (TextBox1.Text == "")
                {
                    ddlInstrumentType.Focus();
                }
            }
            else
            {
                if (Convert.ToInt32(hdnC.Value) == Convert.ToInt32(hdnT.Value))
                {
                    lblMessage.Text = "";
                    lblMessage.Text = "All Cheques Captured for this Batch.";
                    btnSave.Enabled = false;
                    btnCancel.Focus();
                }
                else
                {
                    ddlDropBoxList.Enabled = true;
                    ddlDropBoxList.Focus();
                }
            }


        }
    }

    private void Get_Bin_Logo_Details()
    {
        try
        {
            Object SaveUSERInfo = (Object)Session["UserInfo"];

            SqlConnection sqlcon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);


            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlcon;
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.CommandText = "Get_BinLogoDetails";
            sqlcmd.CommandTimeout = 0;

            sqlcon.Open();
            SqlDataAdapter sqlda = new SqlDataAdapter();
            sqlda.SelectCommand = sqlcmd;

            DataTable dt = new DataTable();
            sqlda.Fill(dt);
            sqlcon.Close();

            if (dt.Rows.Count > 0)
            {
                string strBinLogos = "";
                hdnBinLogoDetails.Value = "";

                for (int i = 0; i <= dt.Rows.Count - 1; i++)
                {
                    strBinLogos = strBinLogos + dt.Rows[i]["BinLogoDetails"].ToString().Trim();
                }
                hdnBinLogoDetails.Value = strBinLogos;

            }
        }
        catch (Exception ex)
        {
            lblMessage.Visible = true;
            lblMessage.Text = ex.Message;
            lblMessage.CssClass = "ErrorMessage";
        }
    }

    private void Get_MICRDetails()
    {
        try
        {
            Object SaveUSERInfo = (Object)Session["UserInfo"];

            SqlConnection sqlcon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);


            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlcon;
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.CommandText = "Get_MICRDataFor_Validation";
            sqlcmd.CommandTimeout = 0;

            SqlParameter BranchID = new SqlParameter();
            BranchID.SqlDbType = SqlDbType.Int;
            BranchID.Value = Convert.ToInt32(((UserInfo.structUSERInfo)(SaveUSERInfo)).BranchId);
            BranchID.ParameterName = "@BranchID";
            sqlcmd.Parameters.Add(BranchID);

            sqlcon.Open();
            SqlDataAdapter sqlda = new SqlDataAdapter();
            sqlda.SelectCommand = sqlcmd;

            DataTable dt = new DataTable();
            sqlda.Fill(dt);
            sqlcon.Close();

            if (dt.Rows.Count > 0)
            {
                string strChequeValidate = "";
                hdnMicrCheck.Value = "";

                for (int i = 0; i <= dt.Rows.Count - 1; i++)
                {
                    strChequeValidate = strChequeValidate + dt.Rows[i]["MicrDetails"].ToString().Trim();
                }
                hdnMicrCheck.Value = strChequeValidate;



            }

        }

        catch (Exception ex)
        {
            lblMessage.Visible = true;
            lblMessage.Text = ex.Message;
            lblMessage.CssClass = "ErrorMessage";
        }
    }

    private void Get_ReasonList()
    {
        try
        {
            Object SaveUSERInfo = (Object)Session["UserInfo"];

            SqlConnection sqlcon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);


            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlcon;
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.CommandText = "Get_ReasonList_ForInvalid";
            sqlcmd.CommandTimeout = 0;




            SqlParameter Is_Active = new SqlParameter();
            Is_Active.SqlDbType = SqlDbType.Int;
            Is_Active.Value = 1;
            Is_Active.ParameterName = "@Is_Active";
            sqlcmd.Parameters.Add(Is_Active);

            sqlcon.Open();

            SqlDataAdapter sqlda = new SqlDataAdapter();
            sqlda.SelectCommand = sqlcmd;

            DataTable dt = new DataTable();
            sqlda.Fill(dt);

            sqlcon.Close();

            ddlReasonList.DataTextField = "Reason";
            ddlReasonList.DataValueField = "ReasonID";
            ddlReasonList.DataSource = dt;
            ddlReasonList.DataBind();

            ddlReasonList.Items.Insert(0, "-Select-");
            // ddlReasonList.Items.Insert(78, new ListItem("I25-VALID CHEQUE", "I25"));
            ddlReasonList.SelectedIndex = 0;

        }
        catch (Exception ex)
        {
            lblMessage.Visible = true;
            lblMessage.Text = ex.Message;
            lblMessage.CssClass = "ErrorMessage";

        }

    }

    private void Get_NewCount()
    {
        Object SaveUSERInfo = (Object)Session["UserInfo"];

        try
        {
            SqlConnection sqlCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);


            SqlCommand sqlCom = new SqlCommand();
            sqlCom.Connection = sqlCon;
            sqlCom.CommandType = CommandType.StoredProcedure;
            sqlCom.CommandText = "Get_ChequeCountNew";
            sqlCom.CommandTimeout = 0;

            SqlParameter BatchNo = new SqlParameter();
            BatchNo.SqlDbType = SqlDbType.VarChar;
            BatchNo.Value = txtBatchNo.Text.Trim();
            BatchNo.ParameterName = "@BatchNo";
            sqlCom.Parameters.Add(BatchNo);

            SqlParameter DropBoxId = new SqlParameter();
            DropBoxId.SqlDbType = SqlDbType.VarChar;
            DropBoxId.Value = Convert.ToInt32(ddlDropBoxList.SelectedValue);
            DropBoxId.ParameterName = "@DropBoxId";
            sqlCom.Parameters.Add(DropBoxId);


            sqlCon.Open();
            SqlDataAdapter sqlDA = new SqlDataAdapter();
            sqlDA.SelectCommand = sqlCom;

            DataSet ds = new DataSet();
            sqlDA.Fill(ds);
            sqlCon.Close();

            if (ds.Tables[0].Rows.Count > 0)
            {

                lblTotalChqueCapture.Text = ds.Tables[0].Rows[0]["DropBoxChequeCaptureCount"].ToString() + " of " + ds.Tables[0].Rows[0]["DropBoxChequeTotalCount"].ToString();
                hdnChqCount.Value = ds.Tables[0].Rows[0]["DropBoxChequeCaptureCount"].ToString();
                hdnTotalChqs.Value = ds.Tables[0].Rows[0]["DropBoxChequeTotalCount"].ToString();

            }
        }
        catch (Exception ex)
        {
            lblMessage.Visible = true;
            lblMessage.Text = ex.Message;
            lblMessage.CssClass = "ErrorMessage";
        }
    }

    private void Get_BatchDetailsHeaders()
    {
        Object SaveUSERInfo = (Object)Session["UserInfo"];

        try
        {
            SqlConnection sqlCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);


            SqlCommand sqlCom = new SqlCommand();
            sqlCom.Connection = sqlCon;
            sqlCom.CommandType = CommandType.StoredProcedure;
            sqlCom.CommandText = "Get_BatchDetailsHeaders";
            sqlCom.CommandTimeout = 0;



            SqlParameter BatchNo = new SqlParameter();
            BatchNo.SqlDbType = SqlDbType.VarChar;
            BatchNo.Value = txtBatchNo.Text.Trim();
            BatchNo.ParameterName = "@BatchNo";
            sqlCom.Parameters.Add(BatchNo);

            sqlCon.Open();
            SqlDataAdapter sqlDA = new SqlDataAdapter();
            sqlDA.SelectCommand = sqlCom;
            DataSet ds = new DataSet();
            sqlDA.Fill(ds);
            sqlCon.Close();

            if (ds.Tables[0].Rows.Count > 0)
            {
                lblBatchDate.Text = ds.Tables[0].Rows[0]["batchdate"].ToString();
                hdnDate.Value = ds.Tables[0].Rows[0]["ChequeDepositDate"].ToString();
                lblNoOfCheque.Text = ds.Tables[0].Rows[0]["ChequeCaptureCount"].ToString() + " of " + ds.Tables[0].Rows[0]["TotalChequesCaptured"].ToString();
                hdnC.Value = ds.Tables[0].Rows[0]["ChequeCaptureCount"].ToString();
                hdnT.Value = ds.Tables[0].Rows[0]["TotalChequesCaptured"].ToString();
            }
        }
        catch (Exception ex)
        {
            lblMessage.Visible = true;
            lblMessage.Text = ex.Message;
            lblMessage.CssClass = "ErrorMessage";
        }
    }

    private void Get_DropBoxDetailsHeaders()
    {
        Object SaveUSERInfo = (Object)Session["UserInfo"];

        try
        {
            SqlConnection sqlcon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);


            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlcon;
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.CommandText = "Get_DropBoxDetailsHeader";
            sqlcmd.CommandTimeout = 0;



            SqlParameter BatchNo = new SqlParameter();
            BatchNo.SqlDbType = SqlDbType.VarChar;
            BatchNo.Value = txtBatchNo.Text;
            BatchNo.ParameterName = "@BatchNo";
            sqlcmd.Parameters.Add(BatchNo);

            SqlParameter BranchID = new SqlParameter();
            BranchID.SqlDbType = SqlDbType.Int;
            BranchID.Value = Convert.ToInt32(((UserInfo.structUSERInfo)(SaveUSERInfo)).BranchId);
            BranchID.ParameterName = "@BranchID";
            sqlcmd.Parameters.Add(BranchID);

            sqlcon.Open();
            SqlDataAdapter sqlda = new SqlDataAdapter();
            sqlda.SelectCommand = sqlcmd;
            DataTable dt = new DataTable();
            sqlda.Fill(dt);
            sqlcon.Close();

            ddlDropBoxList.DataTextField = "DropBox_Code";
            ddlDropBoxList.DataValueField = "DropBoxId";
            ddlDropBoxList.DataSource = dt;
            ddlDropBoxList.DataBind();

            ddlDropBoxList.Items.Insert(0, "-Select-");
            ddlDropBoxList.SelectedIndex = 0;

            ddlDropBoxList.Focus();

        }
        catch (Exception ex)
        {
            lblMessage.Visible = true;
            lblMessage.Text = ex.Message;
            lblMessage.CssClass = "ErrorMessage";
        }
    }



    private void Register_ControlsWith_JavaScript()
    {
        ddlReasonList.Attributes.Add("onKeyDown", "javascript:if(event.keyCode==13 || event.keyCode==9){ event.keyCode=9};");
        ddlSignature.Attributes.Add("onKeyDown", "javascript:if(event.keyCode==13 || event.keyCode==9){ event.keyCode=9};Validate_Signature();");
        ddlInstrumentType.Attributes.Add("onKeyDown", "javascript:if(event.keyCode==13 ||event.keyCode==9){event.keyCode=9};");
        txtChequeNo.Attributes.Add("onKeyDown", "javascript:if(event.keyCode==13 || event.keyCode == 9){ event.keyCode=9;Validate_ChequeNo()};");
        txtChequeAmt.Attributes.Add("onKeyDown", "javascript:if(event.keyCode==13 || event.keyCode==9) {event.keyCode=9;Validate_ChequeAmt()};");
        txtChequeDate.Attributes.Add("onKeyDown", "javascript:if(event.keyCode==13 || event.keyCode==9) { event.keyCode=9;ChequeDate_Validate()};");
        txtCardNo.Attributes.Add("onKeyDown", "javascript:if(event.keyCode==13 || event.keyCode==9) {event.keyCode=9;Validate_CardNo()};");
        //txtMICRCode.Attributes.Add("onKeyDown", "javascript:if(event.keyCode==13 || event.keyCode==9) {event.keyCode=9;Validate_MICRCode()};");
        TextBox1.Attributes.Add("onKeyDown", "javascript:if(event.keyCode==13 || event.keyCode==9) {event.keyCode=9;Validate_MICRCode()};");
        txtAcountNo.Attributes.Add("onKeyDown", "javascript:if(event.keyCode==13) {event.keyCode=9;Validate_AccountNo()};");

        txtTransactionCode.Attributes.Add("onKeyDown", "javascript:if(event.keyCode==13 || event.keyCode==9) event.keyCode=9;Validate_TransactionCode();");
        txtContactNo.Attributes.Add("onKeyDown", "javascript:if(event.keyCode==13 || event.keyCode==9) event.keyCode=9;");
        // txtReceiptNo.Attributes.Add("onKeyDown", "javascript:if(event.keyCode==13 || event.keyCode==9) event.keyCode=9;");
        txtRemark.Attributes.Add("onKeyDown", "javascript:if(event.keyCode==13 || event.keyCode==9) event.keyCode=9;");
        btnSave.Attributes.Add("onclick", "javascript:return Validate_Save();");

    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        if ((lblBankName.Text != "" || lblBankName.Text != null) && (lblBranchName.Text != "" || lblBranchName.Text != null) && (lblCity.Text != "" || lblCity.Text != null))
        {

            Insert_C_ChequeCaptureInfo();
            Reset_Controls();
            Get_ReasonList();
            Session["CapturedChequeCount"] = Convert.ToInt32(Session["CapturedChequeCount"]) + 1;
            int CapturedChequeCount = Convert.ToInt32(Session["CapturedChequeCount"]);
            Get_BatchDetailsHeaders();
            Get_NewCount();

            if (hdnChqCount.Value == hdnTotalChqs.Value)
            {
                if (Convert.ToInt32(hdnC.Value) == Convert.ToInt32(hdnT.Value))
                {
                    lblMessage.Text = "All Cheques Captured For this Batch.";
                    Disable_Controls();
                    btnSave.Enabled = false;
                    btnCancel.Focus();
                }
                else
                {
                    ddlDropBoxList.Enabled = true;
                    ddlDropBoxList.Focus();
                }
            }
            else
            {
                ddlInstrumentType.Focus();
            }
        }
        else
        {
            lblMessage.Text = "Data not saved : Entre MICR code as Bank Branch and City Not reflecting";

            TextBox1.Text = "";
            //TextBox1.Focus();
            ddlInstrumentType.Focus();

        }
    }

    private void Insert_C_ChequeCaptureInfo()
    {
        Object SaveUSERInfo = (Object)Session["UserInfo"];

        try
        {
            SqlConnection sqlCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);


            SqlCommand sqlCom = new SqlCommand();
            sqlCom.Connection = sqlCon;
            sqlCom.CommandType = CommandType.StoredProcedure;
            sqlCom.CommandText = "Insert_C_ChequeCapureInfo_nikl";
            sqlCom.CommandTimeout = 0;


            SqlParameter BranchID = new SqlParameter();
            BranchID.SqlDbType = SqlDbType.Int;
            BranchID.Value = Convert.ToInt32(((UserInfo.structUSERInfo)(SaveUSERInfo)).BranchId);
            BranchID.ParameterName = "@BranchID";
            sqlCom.Parameters.Add(BranchID);

            SqlParameter TransactionDetailID = new SqlParameter();
            TransactionDetailID.SqlDbType = SqlDbType.Int;
            TransactionDetailID.Value = Convert.ToInt32(hdnTransactionDetailID.Value);
            TransactionDetailID.ParameterName = "@TransactionDetailID";
            sqlCom.Parameters.Add(TransactionDetailID);

            SqlParameter BatchNo = new SqlParameter();
            BatchNo.SqlDbType = SqlDbType.VarChar;
            BatchNo.Value = txtBatchNo.Text.Trim();
            BatchNo.ParameterName = "@BatchNo";
            sqlCom.Parameters.Add(BatchNo);

            int intDropBoxID = 0;
            if (ddlDropBoxList.SelectedIndex != 0)
            {
                string strDropBoxDetails = "";
                strDropBoxDetails = ddlDropBoxList.SelectedItem.Value.Trim();
                string[] RowDetails = strDropBoxDetails.Split('|');
                intDropBoxID = Convert.ToInt32(RowDetails[0]);
            }



            SqlParameter DropBoxID = new SqlParameter();
            DropBoxID.SqlDbType = SqlDbType.Int;
            DropBoxID.Value = Convert.ToInt32(ddlDropBoxList.SelectedValue);//intDropBoxID; //
            DropBoxID.ParameterName = "@DropBoxID";
            sqlCom.Parameters.Add(DropBoxID);

            SqlParameter IntrumentType = new SqlParameter();
            IntrumentType.SqlDbType = SqlDbType.VarChar;
            IntrumentType.Value = ddlInstrumentType.SelectedItem.Value.ToString();
            IntrumentType.ParameterName = "@IntrumentType";
            sqlCom.Parameters.Add(IntrumentType);

            SqlParameter ChequeNo = new SqlParameter();
            ChequeNo.SqlDbType = SqlDbType.VarChar;
            ChequeNo.Value = txtChequeNo.Text.Trim();
            ChequeNo.ParameterName = "@ChequeNo";
            sqlCom.Parameters.Add(ChequeNo);

            SqlParameter ChequeAmt = new SqlParameter();
            ChequeAmt.SqlDbType = SqlDbType.Decimal;
            ChequeAmt.Value = Convert.ToDecimal(txtChequeAmt.Text.Trim());
            ChequeAmt.ParameterName = "@ChequeAmt";
            sqlCom.Parameters.Add(ChequeAmt);

            SqlParameter ChequeDate = new SqlParameter();
            ChequeDate.SqlDbType = SqlDbType.VarChar;
            ChequeDate.Value = txtChequeDate.Text.Trim();
            ChequeDate.ParameterName = "@ChequeDate";
            sqlCom.Parameters.Add(ChequeDate);

            SqlParameter CardNo = new SqlParameter();
            CardNo.SqlDbType = SqlDbType.VarChar;
            CardNo.Value = txtCardNo.Text.Trim();
            CardNo.ParameterName = "@CardNo";
            sqlCom.Parameters.Add(CardNo);

            SqlParameter CardAmount = new SqlParameter();
            CardAmount.SqlDbType = SqlDbType.Decimal;
            CardAmount.Value = Convert.ToDecimal(txtChequeAmt.Text.Trim());//Convert.ToDecimal(lblCardAmount.Text.Trim()); 
            CardAmount.ParameterName = "@CardAmount";
            sqlCom.Parameters.Add(CardAmount);

            SqlParameter MICRCode = new SqlParameter();
            MICRCode.SqlDbType = SqlDbType.VarChar;
            MICRCode.Value = TextBox1.Text;//txtMICRCode.Text.Trim();
            MICRCode.ParameterName = "@MICRCode";
            sqlCom.Parameters.Add(MICRCode);

            SqlParameter BankName = new SqlParameter();
            BankName.SqlDbType = SqlDbType.VarChar;
            BankName.Value = lblBankName.Text;
            BankName.ParameterName = "@BankName";
            sqlCom.Parameters.Add(BankName);

            SqlParameter BranchName = new SqlParameter();
            BranchName.SqlDbType = SqlDbType.VarChar;
            BranchName.Value = lblBranchName.Text;
            BranchName.ParameterName = "@BranchName";
            sqlCom.Parameters.Add(BranchName);

            SqlParameter BranchCity = new SqlParameter();
            BranchCity.SqlDbType = SqlDbType.VarChar;
            BranchCity.Value = lblCity.Text;
            BranchCity.ParameterName = "@BranchCity";
            sqlCom.Parameters.Add(BranchCity);

            SqlParameter AccountNo = new SqlParameter();
            AccountNo.SqlDbType = SqlDbType.VarChar;
            AccountNo.Value = txtAcountNo.Text.Trim();
            AccountNo.ParameterName = "@AccountNo";
            sqlCom.Parameters.Add(AccountNo);

            SqlParameter Remark = new SqlParameter();
            Remark.SqlDbType = SqlDbType.VarChar;
            Remark.Value = txtRemark.Text.Trim();
            Remark.ParameterName = "@Remark";
            sqlCom.Parameters.Add(Remark);

            SqlParameter ContactNo = new SqlParameter();
            ContactNo.SqlDbType = SqlDbType.VarChar;
            ContactNo.Value = txtContactNo.Text.Trim();
            ContactNo.ParameterName = "@ContactNo";
            sqlCom.Parameters.Add(ContactNo);


            SqlParameter TransactionCode = new SqlParameter();
            TransactionCode.SqlDbType = SqlDbType.VarChar;
            TransactionCode.Value = txtTransactionCode.Text.Trim();
            TransactionCode.ParameterName = "@TransactionCode";
            sqlCom.Parameters.Add(TransactionCode);

            SqlParameter ReceiptNo = new SqlParameter();
            ReceiptNo.SqlDbType = SqlDbType.VarChar;
            ReceiptNo.Value = "";// txtReceiptNo.Text.Trim();
            ReceiptNo.ParameterName = "@ReceiptNo";
            sqlCom.Parameters.Add(ReceiptNo);

            int intReasonID = 0;
            if (ddlReasonList.SelectedIndex != 0)
            {
                intReasonID = Convert.ToInt32(ddlReasonList.SelectedItem.Value);
            }
            if (intReasonID == 79)
            {
                SqlParameter ReasonID = new SqlParameter();
                ReasonID.SqlDbType = SqlDbType.Int;
                ReasonID.Value = DBNull.Value;
                ReasonID.ParameterName = "@ReasonID";
                sqlCom.Parameters.Add(ReasonID);
            }
            else
            {
                SqlParameter ReasonID = new SqlParameter();
                ReasonID.SqlDbType = SqlDbType.Int;
                ReasonID.Value = intReasonID;
                ReasonID.ParameterName = "@ReasonID";
                sqlCom.Parameters.Add(ReasonID);

            }
            int IntChequeCategory = 0;

            if (hdnChequeStaus.Value == "0")
            {
                //Valid Entry
                IntChequeCategory = 1;
            }
            else if (hdnChequeStaus.Value == "1")
            {
                //Invalid Entry
                IntChequeCategory = 2;
            }

            //if (hdnChequeStaus.Value == "0")
            //{
            //    //Valid Entry
            //    IntChequeCategory = 1;
            //}
            //else if (hdnChequeStaus.Value == "1")
            //{
            //    //Invalid Entry
            //    IntChequeCategory = 2;
            //}

            SqlParameter ChequeType = new SqlParameter();
            ChequeType.SqlDbType = SqlDbType.VarChar;
            ChequeType.Value = IntChequeCategory; //hdnchequeCategory.Value; 
            ChequeType.ParameterName = "@ChequeType";
            sqlCom.Parameters.Add(ChequeType);

            SqlParameter IsSignOn = new SqlParameter();
            IsSignOn.SqlDbType = SqlDbType.VarChar;
            IsSignOn.Value = ddlSignature.SelectedItem.Value.Trim();
            IsSignOn.ParameterName = "@IsSignOn";
            sqlCom.Parameters.Add(IsSignOn);

            SqlParameter ChequeCaptureStart = new SqlParameter();
            ChequeCaptureStart.SqlDbType = SqlDbType.VarChar;
            ChequeCaptureStart.Value = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
            //ChequeCaptureStart.Value = DateTime.Now;
            ChequeCaptureStart.ParameterName = "@ChequeCaptureStart";
            sqlCom.Parameters.Add(ChequeCaptureStart);

            SqlParameter UserID = new SqlParameter();
            UserID.SqlDbType = SqlDbType.VarChar;
            UserID.Value = Convert.ToString(((UserInfo.structUSERInfo)(SaveUSERInfo)).UserId);
            UserID.ParameterName = "@UserID";
            sqlCom.Parameters.Add(UserID);

            SqlParameter IsSuspense = new SqlParameter();
            IsSuspense.SqlDbType = SqlDbType.Int;
            IsSuspense.Value = Convert.ToInt32(hdnIsSuspenseCheque.Value);
            IsSuspense.ParameterName = "@IsSuspense";
            sqlCom.Parameters.Add(IsSuspense);

            SqlParameter VarResult = new SqlParameter();
            VarResult.SqlDbType = SqlDbType.VarChar;
            VarResult.Value = txtBatchNo.Text.Trim();
            VarResult.ParameterName = "@VarResult";
            VarResult.Size = 200;
            VarResult.Direction = ParameterDirection.Output;
            sqlCom.Parameters.Add(VarResult);


            sqlCon.Open();

            sqlCom.ExecuteNonQuery();
            string RowEffected = Convert.ToString(sqlCom.Parameters["@VarResult"].Value);
            hdnTransactionDetailID.Value = RowEffected;

            sqlCon.Close();

            if (RowEffected != "")
            {
                lblMessage.Visible = true;
                lblMessage.Text = RowEffected;
                lblMessage.CssClass = "SuccessMessage";

            }
        }
        catch (Exception ex)
        {
            lblMessage.Visible = true;
            lblMessage.Text = ex.Message;
            lblMessage.CssClass = "ErrorMessage";
        }

    }

    private void Reset_Controls()
    {
        //lblMessage.Visible = false;
        ddlInstrumentType.SelectedIndex = 0;
        txtAcountNo.Text = "";
        txtCardNo.Text = "";
        txtChequeAmt.Text = "";
        txtChequeDate.Text = "";
        txtChequeNo.Text = "";
        txtContactNo.Text = "";
        //txtMICRCode.Text = "";
        TextBox1.Text = "";
        // txtReceiptNo.Text = "";
        txtRemark.Text = "";
        txtTransactionCode.Text = "";
        lblBankName.Text = "";
        lblBranchName.Text = "";
        lblCity.Text = "";
        hdncheqdate.Value = "0";
        hdnChequeStaus.Value = "0";
        hdnEntryStart.Value = "";
        hdnDate.Value = "";
        hdnIsSuspenseCheque.Value = "0";
        //hdnMICRDetails.Value = "";
        hdnTransactionDetailID.Value = "0";
        ViewState.Clear();
        Label1.Text = "";
        ddlReasonList.Enabled = true;
        ddlSignature.SelectedIndex = 1;
        lblChequeStatus.Text = "";
        hdnchkstat.Value = "";
        HiddenField1.Value = "";

    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Pages/Menu.aspx", true);
    }
    protected void btnBackToSearch_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Pages/ChequeProcessingNEW/ValidateCheque_Search.aspx", true);
    }
    protected void TextBox1_TextChanged(object sender, EventArgs e)
    {
        Object SaveUSERInfo = (Object)Session["UserInfo"];

        SqlConnection sqlCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);

        try
        {

            SqlCommand sqlCom = new SqlCommand();
            sqlCom.Connection = sqlCon;
            sqlCom.CommandType = CommandType.StoredProcedure;
            sqlCom.CommandText = "Get_MICR_mod";
            sqlCom.CommandTimeout = 0;


            SqlParameter MICRCode = new SqlParameter();
            MICRCode.SqlDbType = SqlDbType.VarChar;
            MICRCode.Value = TextBox1.Text.Trim();
            MICRCode.ParameterName = "@MICRCode";
            sqlCom.Parameters.Add(MICRCode);

            SqlParameter BranchID = new SqlParameter();
            BranchID.SqlDbType = SqlDbType.Int;
            BranchID.Value = Convert.ToInt32(((UserInfo.structUSERInfo)(SaveUSERInfo)).BranchId);
            BranchID.ParameterName = "@BranchId";
            sqlCom.Parameters.Add(BranchID);

            sqlCon.Open();
            SqlDataAdapter sqlda = new SqlDataAdapter();
            sqlda.SelectCommand = sqlCom;
            DataSet ds = new DataSet();
            sqlda.Fill(ds);
            sqlCon.Close();



            if (ds.Tables[0].Rows.Count > 0)
            {
                hdnMicrCheck.Value = "Present";

                lblBankName.Text = ds.Tables[0].Rows[0]["Bank_Name"].ToString();
                lblBranchName.Text = ds.Tables[0].Rows[0]["Branch_Name"].ToString();
                lblCity.Text = ds.Tables[0].Rows[0]["City"].ToString();
                txtAcountNo.Focus();
                
            }
            else
            {
                lblMessage.Text = "Invalid MICR Entered.";
                lblMessage.CssClass = "ErrorMessage";
                TextBox1.Focus();
                TextBox1.Text = "";
                lblBankName.Text = "";
                lblBranchName.Text = "";
                lblCity.Text = "";
               
            }


        }
        catch (Exception ex)
        {
            lblMessage.Visible = true;
            lblMessage.Text = ex.Message;
            lblMessage.CssClass = "ErrorMessage";
        }
        txtAcountNo.Focus();
    }
    protected void ddlDropBoxList_SelectedIndexChanged(object sender, EventArgs e)
    {
        Get_DropBoxInfoHeaders();
        Get_BatchDetailsHeaders();
        if (Convert.ToInt32(hdnC.Value) == Convert.ToInt32(hdnT.Value))
        {
            lblMessage.Text = "";
            lblMessage.Text = "All Cheques Captured for this Batch.";
            btnSave.Enabled = false;
        }
       
    }

    private void Get_DropBoxInfoHeaders()
    {
        Object SaveUSERInfo = (Object)Session["UserInfo"];

        lblMessage.Text = "";
        Enable_Controls();
        try
        {
            SqlConnection sqlCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);


            SqlCommand sqlCom = new SqlCommand();
            sqlCom.Connection = sqlCon;
            sqlCom.CommandType = CommandType.StoredProcedure;
            sqlCom.CommandText = "Get_DropBoxInfoHeaders";
            sqlCom.CommandTimeout = 0;


            SqlParameter BatchNo = new SqlParameter();
            BatchNo.SqlDbType = SqlDbType.VarChar;
            BatchNo.Value = txtBatchNo.Text.Trim();
            BatchNo.ParameterName = "@BatchNo";
            sqlCom.Parameters.Add(BatchNo);

            SqlParameter DropBoxId = new SqlParameter();
            DropBoxId.SqlDbType = SqlDbType.VarChar;
            DropBoxId.Value = Convert.ToInt32(ddlDropBoxList.SelectedValue);
            DropBoxId.ParameterName = "@DropBoxId";
            sqlCom.Parameters.Add(DropBoxId);


            sqlCon.Open();
            SqlDataAdapter sqlDA = new SqlDataAdapter();
            sqlDA.SelectCommand = sqlCom;
            DataSet ds = new DataSet();
            sqlDA.Fill(ds);
            sqlCon.Close();

            if (ds.Tables[0].Rows.Count > 0)
            {
                lblDropBoxName.Text = ds.Tables[0].Rows[0]["DropBox_name"].ToString();
                lblTotalChqueCapture.Text = ds.Tables[0].Rows[0]["DropBoxChequeCaptureCount"].ToString() + " of " + ds.Tables[0].Rows[0]["DropBoxChequeTotalCount"].ToString();
                Session["CapturedChequeCount"] = ds.Tables[0].Rows[0]["DropBoxChequeCaptureCount"];
                Session["TotalChequeCount"] = ds.Tables[0].Rows[0]["DropBoxChequeTotalCount"];
                ddlDropBoxList.Enabled = false;
                if (Convert.ToInt32(Session["CapturedChequeCount"]) == Convert.ToInt32(Session["TotalChequeCount"]))
                {
                    lblMessage.Text = "All Cheques Captured for this dropbox...!!";
                    ddlDropBoxList.Enabled = true;
                    ddlDropBoxList.Focus();
                    Disable_Controls();
                }
                else
                {
                    ddlInstrumentType.Focus();
                }
            }
        }
        catch (Exception ex)
        {
            lblMessage.Visible = true;
            lblMessage.Text = ex.Message;
            lblMessage.CssClass = "ErrorMessage";
        }
    }

    private void Enable_Controls()
    {
        ddlInstrumentType.Enabled = true;
        txtChequeNo.Enabled = true;
        txtChequeAmt.Enabled = true;
        txtChequeDate.Enabled = true;
        txtCardNo.Enabled = true;
        TextBox1.Enabled = true;
        txtAcountNo.Enabled = true;
        ddlSignature.Enabled = true;
        ddlReasonList.Enabled = true;
        txtRemark.Enabled = true;
        txtContactNo.Enabled = true;
        // txtReceiptNo.Enabled = true;
        txtTransactionCode.Enabled = true;
    }

    private void Disable_Controls()
    {
        ddlInstrumentType.Enabled = false;
        txtChequeNo.Enabled = false;
        txtChequeAmt.Enabled = false;
        txtChequeDate.Enabled = false;
        txtCardNo.Enabled = false;
        TextBox1.Enabled = false;
        txtAcountNo.Enabled = false;
        ddlSignature.Enabled = false;
        ddlReasonList.Enabled = false;
        txtRemark.Enabled = false;
        txtContactNo.Enabled = false;
        // txtReceiptNo.Enabled = false;
        txtTransactionCode.Enabled = false;
    }


    public string GetTID { get; set; }

    public int intTID { get; set; }

    protected void txtChequeDate_TextChanged(object sender, EventArgs e)
    {
        lblMessage.Text = "";
        ChangeReasonRemark();
    }

    public void ChangeReasonRemark()
    {
        if (txtChequeDate.Text != "" && txtChequeDate.Text != null)
        {
            if (IsDate(txtChequeDate.Text))
            {
                DateTime date = DateTime.ParseExact(txtChequeDate.Text, "dd/MM/yyyy", null);//Convert.ToDateTime(txtChequeDate.Text.ToString());

                DateTime currentDate = System.DateTime.Now.AddDays(2);

                ddlReasonList.Enabled = true;
                // string chequePickUpdt = "";
                if (txtBatchNo.Text != "" && txtBatchNo.Text != null)
                {
                    //chequePickUpdt = PickupDateCheque();
                }

                //int strStartdate = date.CompareTo(Convert.ToDateTime("01/01/2016"));
                //int strEnddate = date.CompareTo(Convert.ToDateTime("01/12/2016"));

                TimeSpan t = date - DateTime.ParseExact(hdnDate.Value, "dd/MM/yyyy", null);
                double NrOfDays = t.TotalDays;
                int NoOfDays = Convert.ToInt32(NrOfDays);

                if (NoOfDays > 0 && NoOfDays <= 30)
                {
                    ddlReasonList.SelectedValue = "15";
                }
                else if (NoOfDays > 30 && NoOfDays <= 90)
                {
                    ddlReasonList.SelectedValue = "6";
                }
                else if (NoOfDays >= (-90) && NoOfDays <= 0)//DateTime.ParseExact(chequePickUpdt, "dd/MM/yyyy", null) >= date &&
                {
                    ddlReasonList.SelectedValue = "79";
                    ddlReasonList.Enabled = false;
                }
                else if (NoOfDays > 90 || NoOfDays < (-90))
                {
                    ddlReasonList.SelectedValue = "4";
                }
                else
                {
                    // ddlReasonList.SelectedValue = "0";
                    ddlReasonList.ClearSelection();
                }


            }
            else
            {
                ddlReasonList.SelectedValue = "12";
                Label1.Text = "Invalid date";
            }
        }
        txtCardNo.Focus();

    }
    //public void ChangeReasonRemark()
    //{
    //    if (txtChequeDate.Text != "" && txtChequeDate.Text != null)

    //        if (IsDate(txtChequeDate.Text))
    //        {
    //            DateTime date = DateTime.ParseExact(txtChequeDate.Text, "dd/MM/yyyy", null);//Convert.ToDateTime(txtChequeDate.Text.ToString());

    //            DateTime currentDate = System.DateTime.Now.AddDays(2);

    //            ddlReasonList.Enabled = true;
    //            string chequePickUpdt ="";
    //            if (txtBatchNo.Text != "" && txtBatchNo.Text != null)
    //            {
    //                 chequePickUpdt = PickupDateCheque();
    //            }

    //            //int strStartdate = date.CompareTo(Convert.ToDateTime("01/01/2016"));
    //            //int strEnddate = date.CompareTo(Convert.ToDateTime("01/12/2016"));

    //            if ((date.CompareTo(System.DateTime.Now.AddDays(0).Date) == 1 || date.CompareTo(System.DateTime.Now.AddDays(0).Date) == 0)
    //               && (date.CompareTo(System.DateTime.Now.AddDays(30).Date) == -1 ))//|| date.CompareTo(System.DateTime.Now.AddDays(30).Date) == 0))
    //            {
    //                ddlReasonList.SelectedValue = "15";
    //            }
    //            else if ((date.CompareTo(System.DateTime.Now.AddDays(30).Date) == 1 || date.CompareTo(System.DateTime.Now.AddDays(30).Date) == 0)
    //               && (date.CompareTo(System.DateTime.Now.AddDays(90).Date) == -1 || date.CompareTo(System.DateTime.Now.AddDays(90).Date) == 0))
    //            {
    //                ddlReasonList.SelectedValue = "6";
    //            }
    //            else if (DateTime.ParseExact(chequePickUpdt, "dd/MM/yyyy", null) >= date && date.CompareTo(System.DateTime.Now.AddDays(-91).Date) == 1)
    //            {
    //                ddlReasonList.SelectedValue = "78";
    //                ddlReasonList.Enabled = false;
    //            }
    //            else if ((date.CompareTo(System.DateTime.Now.AddDays(91).Date) == 1 || date.CompareTo(System.DateTime.Now.AddDays(91).Date) == 0)
    //               || (date.CompareTo(System.DateTime.Now.AddDays(-90).Date) == -1 || date.CompareTo(System.DateTime.Now.AddDays(-90).Date) == 0))
    //            {
    //                ddlReasonList.SelectedValue = "4";
    //            }


    //            else
    //            {
    //                // ddlReasonList.SelectedValue = "0";
    //                ddlReasonList.ClearSelection();
    //            }
    //        }
    //        else
    //        {
    //            ddlReasonList.SelectedValue = "12";
    //            Label1.Text = "Invalid date";
    //            ddlReasonList.Enabled = true;
    //        }
    //}

    public bool IsDate(string sdate)
    {


        DateTime dt;

        bool isDate = true;

        try
        {
            dt = DateTime.ParseExact(sdate, "dd/MM/yyyy", null);
        }


        catch
        {

            isDate = false;

        }

        return isDate;

    }
    //public string PickupDateCheque()
    //{

    //    string PickUpdate = "";


    //    Object SaveUSERInfo = (Object)Session["UserInfo"];

    //    SqlConnection sqlcon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);


    //    SqlCommand sqlcmd = new SqlCommand();
    //    sqlcmd.Connection = sqlcon;
    //    sqlcmd.CommandType = CommandType.StoredProcedure;
    //    sqlcmd.CommandText = "Get_ChequePickUpDate";
    //    sqlcmd.CommandTimeout = 0;




    //    SqlParameter BatchNo = new SqlParameter();
    //    BatchNo.SqlDbType = SqlDbType.VarChar;
    //    BatchNo.Value = txtBatchNo.Text.Trim();
    //    BatchNo.ParameterName = "@BatchNo";
    //    sqlcmd.Parameters.Add(BatchNo);


    //    SqlParameter CreateBy = new SqlParameter();
    //    CreateBy.SqlDbType = SqlDbType.VarChar;
    //    CreateBy.Value = Convert.ToString(((UserInfo.structUSERInfo)(SaveUSERInfo)).UserId);
    //    CreateBy.ParameterName = "@CreateBy";
    //    sqlcmd.Parameters.Add(CreateBy);


    //    sqlcon.Open();

    //    SqlDataAdapter sqlda = new SqlDataAdapter();
    //    sqlda.SelectCommand = sqlcmd;

    //    DataTable dt = new DataTable();
    //    sqlda.Fill(dt);

    //    sqlcon.Close();

    //    if (dt.Rows.Count > 0)
    //    {
    //        PickUpdate = dt.Rows[0]["ChequePickeupDate"].ToString();
    //    }


    //    return PickUpdate;


    //}
    protected void ddlSignature_SelectedIndexChanged1(object sender, EventArgs e)
    {
        lblMessage.Text = "";
        if (ddlSignature.SelectedItem.Text == "No")
        {
            ddlReasonList.Enabled = true;
            ddlSignature.Focus();
        }
        else
        {
            ddlSignature.Focus();
        }
       
      
    }
}