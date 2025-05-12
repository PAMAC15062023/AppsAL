using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class Pages_ChequeProcessingNEW_ValidateChequeEntrySBI : System.Web.UI.Page
{
    public string GetTID;
    public int intTID;
    protected void Page_Load(object sender, EventArgs e)
    {

        if (Session["UserInfo"] == null)
        {
            Response.Redirect("~/Pages/InvalidRequest.aspx");

        }
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

                txtBatchNo.Text = Request.QueryString["BN"].ToString();
                Register_ControlsWith_JavaScript();
                Get_BatchDetailsHeaders();
                Get_DropBoxDetailsHeaders();
                Get_MICRDetails();
                Get_Bin_Logo_Details();


                if (Cache["ReasonListNew"] == null)
                {
                    Get_ReasonList();
                }
                else
                {
                    ddlReasonList.DataTextField = "Reason";
                    ddlReasonList.DataValueField = "ReasonID";

                    ddlReasonList.DataSource = (DataTable)Cache["ReasonListNew"];
                    ddlReasonList.DataBind();

                    ddlReasonList.Items.Insert(0, "-Select-");
                    ddlReasonList.SelectedIndex = 0;
                }

                               
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
                if (txtMICRCode.Text == "")
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
                    btnModify.Enabled = false;
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

            if (Cache["BinLogoDetails"] == null)
            {

                Object SaveUSERInfo = (Object)Session["UserInfo"];

                SqlConnection sqlcon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);

                sqlcon.Open();
                SqlCommand sqlcmd = new SqlCommand();
                sqlcmd.Connection = sqlcon;
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.CommandText = "Get_BinLogoDetails";
                SqlDataAdapter sqlda = new SqlDataAdapter();
                sqlda.SelectCommand = sqlcmd;

                DataTable dt = new DataTable();
                sqlda.Fill(dt);
                sqlcon.Close();

                Cache["BinLogoDetails"] = dt;

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
            else
            {
                DataTable dt = (DataTable)Cache["BinLogoDetails"];

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
        }
        catch (Exception ex)
        {
            lblMessage.Visible = true;
            lblMessage.Text = ex.Message;
            lblMessage.CssClass = "ErrorMessage";
        }

        finally
        {

        }
    }  
    
    
//string StrScript = "<script language='javascript'> javascript:Page_load_validation(); </script>";
    //Page.RegisterStartupScript("OnLoad_21", StrScript);



    private void Get_NewCount()
    {
        Object SaveUSERInfo = (Object)Session["UserInfo"];

        try
        {
            SqlConnection sqlCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);



            SqlCommand sqlCom = new SqlCommand();
            sqlCom.Connection = sqlCon;
            sqlCom.CommandType = CommandType.StoredProcedure;
            sqlCom.CommandText = "Get_ChequeCountNew_Validate";



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

        finally
        { 
        
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

        finally
        { 
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
            sqlCom.CommandText = "Get_BatchDetailsHeaders_Validation";



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

        finally
        { 
        
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        Insert_C_ChequeCapureInfo_Validation();
        Reset_Controls();
        if (Cache["ReasonListNew"] == null)
        {
            Get_ReasonList();
        }
        else
        {
            ddlReasonList.DataTextField = "Reason";
            ddlReasonList.DataValueField = "ReasonID";

            ddlReasonList.DataSource = (DataTable)Cache["ReasonListNew"];
            ddlReasonList.DataBind();

            ddlReasonList.Items.Insert(0, "-Select-");
            ddlReasonList.SelectedIndex = 0;
        }
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
                btnModify.Enabled = false;
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
        Get_ChequeDatFor_Validatation();
        //GET_Header_Values(txtBatchNo.Text.Trim());
    }
    //private void GET_Header_Values(string pBatchNo)
    //{

    //    txtBatchNo.Text = pBatchNo.Trim();
    //    Get_DropBoxDetails_Dropwise_for_ChequeEntryValidation(txtBatchNo.Text.Trim());
    //    Get_ReasonList();
    //    Get_BatchDetails_For_Validate_ChequeEntry();
    //    Get_ChequeDatFor_Validatation();
    //    //if (hdnMICRDetails.Value == "")
    //    //{
    //    //    Get_MICRDetails();

    //    //}

    //}
    private void Register_ControlsWith_JavaScript()
    {
        //ddlDropBoxList.Attributes.Add("onKeyDown", "javascript:if(event.keyCode==13) {event.keyCode=9;Get_DropBoxDetails()};");

        ddlInstrumentType.Attributes.Add("onKeyDown", "javascript:if(event.keyCode==13 || event.keyCode==9){event.keyCode=9;};");

        ddlReasonList.Attributes.Add("onKeyDown", "javascript:if(event.keyCode==13 || event.keyCode==9){ event.keyCode=9;Validate_ReasonList(1)};");
        ddlSignature.Attributes.Add("onKeyDown", "javascript:if(event.keyCode==13){ event.keyCode=9};Validate_Signature();");


        txtChequeNo.Attributes.Add("onKeyDown", "javascript:if(event.keyCode==13 || event.keyCode==9){ event.keyCode=9;Validate_ChequeNo()};");
        txtChequeAmt.Attributes.Add("onKeyDown", "javascript:if(event.keyCode==13 || event.keyCode==9) {event.keyCode=9;Validate_ChequeAmt()};");
        txtChequeDate.Attributes.Add("onKeyDown", "javascript:if(event.keyCode==13 || event.keyCode==9) { event.keyCode=9;ChequeDate_Validate()};");
        txtCardNo.Attributes.Add("onKeyDown", "javascript:if(event.keyCode==13 || event.keyCode==9) {event.keyCode=9;Validate_CardNo();};");

        txtAcountNo.Attributes.Add("onKeyDown", "javascript:if(event.keyCode==13) {event.keyCode=9;Validate_AccountNo()};");

    }
    private void Insert_C_ChequeCapureInfo_Validation()
    {
        Object SaveUSERInfo = (Object)Session["UserInfo"];

        SqlConnection sqlCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);

     
        SqlCommand sqlCom = new SqlCommand();
        sqlCom.Connection = sqlCon;
        sqlCom.CommandType = CommandType.StoredProcedure;
        sqlCom.CommandText = "Insert_C_ChequeCapureInfo_Validation";

      

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

        //if (hdnDropboxID.Value != "0")
        //{
        //    ddlDropBoxList.SelectedIndex =Convert.ToInt32(hdnDropboxID.Value);
        //    string strDropBoxDetails = "";
        //    strDropBoxDetails = ddlDropBoxList.SelectedItem.Value.Trim();
        //    string[] RowDetails = strDropBoxDetails.Split('|');
        //    intDropBoxID = Convert.ToInt32(RowDetails[0]);
        //}

        SqlParameter DropBoxID = new SqlParameter();
        DropBoxID.SqlDbType = SqlDbType.Int;
        DropBoxID.Value = intDropBoxID; //Convert.ToInt32(ddlDropBoxList.SelectedItem.Value);
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
        MICRCode.Value = txtMICRCode.Text.Trim();
        MICRCode.ParameterName = "@MICRCode";
        sqlCom.Parameters.Add(MICRCode);


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
        ReceiptNo.Value = txtReceiptNo.Text.Trim();
        ReceiptNo.ParameterName = "@ReceiptNo";
        sqlCom.Parameters.Add(ReceiptNo);

        int intReasonID = 0;
        if (ddlReasonList.SelectedIndex != 0)
        {
            intReasonID = Convert.ToInt32(ddlReasonList.SelectedItem.Value);
        }

        SqlParameter ReasonID = new SqlParameter();
        ReasonID.SqlDbType = SqlDbType.Int;
        ReasonID.Value = intReasonID;
        ReasonID.ParameterName = "@ReasonID";
        sqlCom.Parameters.Add(ReasonID);

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

        SqlParameter ChequeValidateStart = new SqlParameter();
        ChequeValidateStart.SqlDbType = SqlDbType.VarChar;
        ChequeValidateStart.Value = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
        ChequeValidateStart.ParameterName = "@ChequeValidateStart";
        sqlCom.Parameters.Add(ChequeValidateStart);

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

        sqlCon.Close();

        if (RowEffected != "")
        {
            lblMessage.Text = "Cheque Details Successfully Saved, Batch No: " + RowEffected;
            lblMessage.CssClass = "SuccessMessage";

        }

    }
    private void Get_DropBoxDetails_Dropwise_for_ChequeEntryValidation(string strBatchNo)
    {
        try
        {
            Object SaveUSERInfo = (Object)Session["UserInfo"];

            SqlConnection sqlcon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);


            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlcon;
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.CommandText = "Get_DropBoxDetails_Dropwise_for_ChequeEntryValidation";


            SqlParameter BranchID = new SqlParameter();
            BranchID.SqlDbType = SqlDbType.Int;
            BranchID.Value = Convert.ToInt32(((UserInfo.structUSERInfo)(SaveUSERInfo)).BranchId);
            BranchID.ParameterName = "@BranchID";
            sqlcmd.Parameters.Add(BranchID);

            SqlParameter BatchNo = new SqlParameter();
            BatchNo.SqlDbType = SqlDbType.VarChar;
            BatchNo.Value = strBatchNo;
            BatchNo.ParameterName = "@BatchNo";
            sqlcmd.Parameters.Add(BatchNo);


            sqlcon.Open();
            SqlDataAdapter sqlda = new SqlDataAdapter();
            sqlda.SelectCommand = sqlcmd;
            DataTable dt = new DataTable();
            sqlda.Fill(dt);
            sqlcon.Close();

            ddlDropBoxList.DataTextField = "DropBox_Code";
            ddlDropBoxList.DataValueField = "DropBoxDetails";
            ddlDropBoxList.DataSource = dt;
            ddlDropBoxList.DataBind();

            ddlDropBoxList.Items.Insert(0, "-Select-");
            ddlDropBoxList.SelectedIndex = 0;

        }
        catch (Exception ex)
        {
            lblMessage.Visible = true;
            lblMessage.Text = ex.Message;
            lblMessage.CssClass = "ErrorMessage";

        }

        finally
        { 
        
        }

    }
    private void Get_BatchDetails_For_Validate_ChequeEntry()
    {
        try
        {
            Object SaveUSERInfo = (Object)Session["UserInfo"];

            SqlConnection sqlcon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);

            sqlcon.Open();
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlcon;
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.CommandText = "Get_BatchDetails_For_Validate_ChequeEntry";
            SqlDataAdapter sqlda = new SqlDataAdapter();
            sqlda.SelectCommand = sqlcmd;

            SqlParameter BranchID = new SqlParameter();
            BranchID.SqlDbType = SqlDbType.Int;
            BranchID.Value = Convert.ToInt32(((UserInfo.structUSERInfo)(SaveUSERInfo)).BranchId);
            BranchID.ParameterName = "@BranchID";
            sqlcmd.Parameters.Add(BranchID);

            SqlParameter BatchNo = new SqlParameter();
            BatchNo.SqlDbType = SqlDbType.VarChar;
            BatchNo.Value = txtBatchNo.Text.Trim();
            BatchNo.ParameterName = "@BatchNo";
            sqlcmd.Parameters.Add(BatchNo);

            SqlParameter TransactioNDetailID = new SqlParameter();
            TransactioNDetailID.SqlDbType = SqlDbType.VarChar;
            TransactioNDetailID.Value = hdnTransactionDetailID.Value;
            TransactioNDetailID.ParameterName = "@TransactioNDetailID";
            sqlcmd.Parameters.Add(TransactioNDetailID);

            SqlParameter UserID = new SqlParameter();
            UserID.SqlDbType = SqlDbType.VarChar;
            UserID.Value = Convert.ToString(((UserInfo.structUSERInfo)(SaveUSERInfo)).UserId);
            UserID.ParameterName = "@UserID";
            sqlcmd.Parameters.Add(UserID);

            DataSet ds = new DataSet();
            sqlda.Fill(ds);
            sqlcon.Close();

            if (ds.Tables.Count > 0)
            {

                lblBatchDate.Text = ds.Tables[0].Rows[0]["BatchDate"].ToString();
                lblNoOfCheque.Text = ds.Tables[0].Rows[0]["TotalCheques"].ToString();
                lblTotalChqueCapture.Text = ds.Tables[0].Rows[0]["TotalChequesCaptured"].ToString();
                hdnEntryStart.Value = ds.Tables[0].Rows[0]["EntryDate"].ToString();
                hdnDate.Value = ds.Tables[0].Rows[0]["ChequeDepositDate"].ToString();
                lblChequeCapturedByUser.Text = ds.Tables[0].Rows[0]["TotalChequesCapturedByUser"].ToString();
                ddlDropBoxList.Focus();

                if (ds.Tables.Count == 2)
                {

                    txtAcountNo.Text = ds.Tables[1].Rows[0]["AccountNo"].ToString();
                    txtCardNo.Text = ds.Tables[1].Rows[0]["CardNo"].ToString();
                    txtChequeAmt.Text = ds.Tables[1].Rows[0]["ChequeAmt"].ToString();
                    txtChequeDate.Text = ds.Tables[1].Rows[0]["ChequeDate"].ToString();
                    txtChequeNo.Text = ds.Tables[1].Rows[0]["ChequeNo"].ToString();
                    txtContactNo.Text = ds.Tables[1].Rows[0]["ContactNo"].ToString();
                    txtMICRCode.Text = ds.Tables[1].Rows[0]["MICRCode"].ToString();
                    txtReceiptNo.Text = ds.Tables[1].Rows[0]["ReceiptNo"].ToString();
                    txtRemark.Text = ds.Tables[1].Rows[0]["Remark"].ToString();
                    txtTransactionCode.Text = ds.Tables[1].Rows[0]["TransactionCode"].ToString();

                    ddlInstrumentType.SelectedValue = ds.Tables[1].Rows[0]["IntrumentType"].ToString();
                    ddlReasonList.SelectedValue = ds.Tables[1].Rows[0]["ReasonID"].ToString();
                    ddlSignature.SelectedValue = ds.Tables[1].Rows[0]["SignOnCheque"].ToString();

                    hdnChequeStaus.Value = ds.Tables[1].Rows[0]["ChequeType"].ToString();

                    string DropboxValue = ds.Tables[1].Rows[0]["DropBoxID"].ToString();
                    for (int i = 0; i <= ddlDropBoxList.Items.Count - 1; i++)
                    {
                        if (ddlDropBoxList.Items[i].Value.Contains(DropboxValue))
                        {
                            ddlDropBoxList.SelectedIndex = i;
                        }

                    }



                }
            }


        }
        catch (Exception ex)
        {
            lblMessage.Visible = true;
            lblMessage.Text = ex.Message;
            lblMessage.CssClass = "ErrorMessage";

        }


        finally
        { 
        
        }

    }
    private void AssignValues_ToDetails(DataTable dt)
    {



    }
    private void AssignValues_ToHeader()
    {

    }
    private void Get_MICRDetails()
    {
        try
        {
            Object SaveUSERInfo = (Object)Session["UserInfo"];

            SqlConnection sqlcon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);

            sqlcon.Open();
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlcon;
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.CommandText = "Get_MICRDetails_mod";
            SqlDataAdapter sqlda = new SqlDataAdapter();
            sqlda.SelectCommand = sqlcmd;

            SqlParameter BranchID = new SqlParameter();
            BranchID.SqlDbType = SqlDbType.Int;
            BranchID.Value = Convert.ToInt32(((UserInfo.structUSERInfo)(SaveUSERInfo)).BranchId);
            BranchID.ParameterName = "@BranchID";
            sqlcmd.Parameters.Add(BranchID);

            SqlParameter BatchNo = new SqlParameter();
            BatchNo.SqlDbType = SqlDbType.VarChar;
            BatchNo.Value = txtBatchNo.Text;
            BatchNo.ParameterName = "@BatchNo";
            sqlcmd.Parameters.Add(BatchNo);

            DataTable dt = new DataTable();
            sqlda.Fill(dt);
            sqlcon.Close();

            if (dt.Rows.Count > 0)
            {
                string strMICRDetails = "";

                for (int i = 0; i <= dt.Rows.Count - 1; i++)
                {
                    strMICRDetails = strMICRDetails + dt.Rows[i]["MICR_Details"].ToString().Trim();
                }
                hdnMICRDetails.Value = strMICRDetails;

                //if (Convert.ToInt32(((UserInfo.structUSERInfo)(SaveUSERInfo)).BranchId) == 1)
                //{
                string sub = hdnMICRDetails.Value.Substring(3, 3);
                if (sub == "002")
                {
                    txtAcountNo.Enabled = true;
                }
                else
                {
                    txtAcountNo.Enabled = false;
                }
                //}

            }
        }

        catch (Exception ex)
        {
            lblMessage.Visible = true;
            lblMessage.Text = ex.Message;
            lblMessage.CssClass = "ErrorMessage";
        }


        finally
        { }



    }
    private void Reset_Controls()
    {

        txtAcountNo.Text = "";
        txtCardNo.Text = "";
        txtChequeAmt.Text = "";
        txtChequeDate.Text = "";
        txtChequeNo.Text = "";
        txtContactNo.Text = "";
        txtMICRCode.Text = "";
        txtReceiptNo.Text = "";
        txtRemark.Text = "";
        txtTransactionCode.Text = "";

        hdnChequeStaus.Value = "0";
        hdnEntryStart.Value = "";
        hdnDate.Value = "";
        hdnIsSuspenseCheque.Value = "0";
        //hdnMICRDetails.Value = "";
        hdnTransactionDetailID.Value = "0";
        hdnValidateChequeEntry.Value = "";
        ddlInstrumentType.SelectedIndex = 0;


    }
    //protected void btnAddNew_Click(object sender, EventArgs e)
    //{
    //    Reset_Controls();
    //    GET_Header_Values(txtBatchNo.Text.Trim());
    //}

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Pages/Menu.aspx", true);
    }

    protected void btnBackToSearch_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Pages/ChequeProcessingNEW/ValidateCheque_Search.aspx", true);
    }

    private void Get_ReasonList()
    {
        try
        {
            Object SaveUSERInfo = (Object)Session["UserInfo"];

            SqlConnection sqlcon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);

            sqlcon.Open();
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlcon;
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.CommandText = "Get_ReasonListNew";
            SqlDataAdapter sqlda = new SqlDataAdapter();
            sqlda.SelectCommand = sqlcmd;

            SqlParameter Is_Active = new SqlParameter();
            Is_Active.SqlDbType = SqlDbType.Int;
            Is_Active.Value = 1;
            Is_Active.ParameterName = "@Is_Active";
            sqlcmd.Parameters.Add(Is_Active);

            DataTable dt = new DataTable();
            sqlda.Fill(dt);
            sqlcon.Close();

            Cache["ReasonListNew"] = dt;

            ddlReasonList.DataTextField = "Reason";
            ddlReasonList.DataValueField = "ReasonID";
            ddlReasonList.DataSource = dt;
            ddlReasonList.DataBind();

            ddlReasonList.Items.Insert(0, "-Select-");
            ddlReasonList.SelectedIndex = 0;

        }
        catch (Exception ex)
        {
            lblMessage.Visible = true;
            lblMessage.Text = ex.Message;
            lblMessage.CssClass = "ErrorMessage";

        }

        finally
        { 
        
        }

    }
    private void Get_ChequeDatFor_Validatation()
    {
        try
        {
            Object SaveUSERInfo = (Object)Session["UserInfo"];

            SqlConnection sqlcon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);

            sqlcon.Open();
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlcon;
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.CommandText = "Get_ChequeDatFor_Validatation";
            SqlDataAdapter sqlda = new SqlDataAdapter();
            sqlda.SelectCommand = sqlcmd;

            SqlParameter BranchID = new SqlParameter();
            BranchID.SqlDbType = SqlDbType.Int;
            BranchID.Value = Convert.ToInt32(((UserInfo.structUSERInfo)(SaveUSERInfo)).BranchId);
            BranchID.ParameterName = "@BranchID";
            sqlcmd.Parameters.Add(BranchID);

            SqlParameter BatchNo = new SqlParameter();
            BatchNo.SqlDbType = SqlDbType.VarChar;
            BatchNo.Value = txtBatchNo.Text.Trim();
            BatchNo.ParameterName = "@BatchNo";
            sqlcmd.Parameters.Add(BatchNo);

            //int intDropBoxID = 0;

            //if (ddlDropBoxList.SelectedIndex != 0)
            //{
            //    string strDropBoxDetails = "";
            //    strDropBoxDetails = ddlDropBoxList.SelectedItem.Value.Trim();
            //    string[] RowDetails = strDropBoxDetails.Split('|');
            //    intDropBoxID = Convert.ToInt32(RowDetails[0]);
            //}

            SqlParameter DropBoxID = new SqlParameter();
            DropBoxID.SqlDbType = SqlDbType.Int;
            DropBoxID.Value = Convert.ToInt32(ddlDropBoxList.SelectedValue);// intDropBoxID;
            DropBoxID.ParameterName = "@DropBoxID";
            sqlcmd.Parameters.Add(DropBoxID);

            DataTable dt = new DataTable();
            sqlda.Fill(dt);
            sqlcon.Close();

            if (dt.Rows.Count > 0)
            {
                string strChequeValidate = "";
                hdnValidateChequeEntry.Value = "";

                for (int i = 0; i <= dt.Rows.Count - 1; i++)
                {
                    strChequeValidate = strChequeValidate + dt.Rows[i]["ChequeDetails"].ToString().Trim();
                }
                hdnValidateChequeEntry.Value = strChequeValidate;

                GetTID = strChequeValidate.Trim();
                string[] RowDetails2 = strChequeValidate.Split('|');
                intTID = Convert.ToInt32(RowDetails2[0]);
                hdnTID.Value = intTID.ToString();
            }
            //else 
            //{
            //    lblMessage.Text = "All Cheques Validation Complete for this Batch.";
            //    lblMessage.CssClass = "SuccessMessage";
            //}
        }

        catch (Exception ex)
        {
            lblMessage.Visible = true;
            lblMessage.Text = ex.Message;
            lblMessage.CssClass = "ErrorMessage";
        }

        finally
        { 
        
        }
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
            btnModify.Enabled = false;
        }
        Get_ChequeDatFor_Validatation();

    }

    private void Get_DropBoxInfoHeaders()
    {
        Object SaveUSERInfo = (Object)Session["UserInfo"];

        lblMessage.Text = "";
        Enable_Controls();
        try
        {
            SqlConnection sqlCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);

            sqlCon.Open();
            SqlCommand sqlCom = new SqlCommand();
            sqlCom.Connection = sqlCon;
            sqlCom.CommandType = CommandType.StoredProcedure;
            sqlCom.CommandText = "Get_DropBoxInfoHeaders_Validate";
            SqlDataAdapter sqlDA = new SqlDataAdapter();
            sqlDA.SelectCommand = sqlCom;

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

        finally
        { }


    }

    private void Disable_Controls()
    {
        ddlInstrumentType.Enabled = false;
        txtChequeNo.Enabled = false;
        txtChequeAmt.Enabled = false;
        txtChequeDate.Enabled = false;
        txtCardNo.Enabled = false;
        txtMICRCode.Enabled = false;
        txtAcountNo.Enabled = false;
        ddlSignature.Enabled = false;
        ddlReasonList.Enabled = false;
        txtRemark.Enabled = false;
        txtContactNo.Enabled = false;
        txtReceiptNo.Enabled = false;
        txtTransactionCode.Enabled = false;
    }

    private void Enable_Controls()
    {
        ddlInstrumentType.Enabled = true;
        txtChequeNo.Enabled = true;
        txtChequeAmt.Enabled = true;
        txtChequeDate.Enabled = true;
        txtCardNo.Enabled = true;
        //txtMICRCode.Enabled = true;
        //txtAcountNo.Enabled = true;
        //ddlSignature.Enabled = true;
        //ddlReasonList.Enabled = true;
        //txtRemark.Enabled = true;
        //txtContactNo.Enabled = true;
        //txtReceiptNo.Enabled = true;
        //txtTransactionCode.Enabled = true;
    }
    protected void txtChequeAmt_TextChanged(object sender, EventArgs e)
    {

    }

    protected void btnModify_Click(object sender, EventArgs e)
    {
        //Response.Redirect("ModifieldCheck.aspx?TID=" + hdnTID.Value + "&CT=1", true);
        Response.Redirect("ModifyChequeEntry.aspx?TID=" + hdnTID.Value + "&CT=1", true);
    }
}