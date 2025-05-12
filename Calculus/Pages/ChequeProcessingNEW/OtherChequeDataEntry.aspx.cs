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
using System.Data.SqlClient;

public partial class Pages_ChequeProcessingNEW_OtherBank : System.Web.UI.Page
{
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
                    if (Request.QueryString["CT"] != null)
                    {
                        hdnchequeCategory.Value = Request.QueryString["CT"].ToString();

                        if (hdnchequeCategory.Value == "1")
                        {
                            lblChequeCategory.Text = "Valid"; 
                        }
                        else if (hdnchequeCategory.Value == "2")
                        {
                            lblChequeCategory.Text = "Invalid"; 
                        }
                        else if (hdnchequeCategory.Value == "3")
                        {
                            lblChequeCategory.Text = "Other";
                        }
                        else if (hdnchequeCategory.Value == "4")
                        {
                            lblChequeCategory.Text = "UpCountry";
                        }

                    } 
                     
                    GET_Header_Values(Request.QueryString["BN"].ToString());
                    Register_ControlsWith_JavaScript();
                    //lblMessage.Text=Request.LogonUserIdentity.Name;
                
            }
          //string StrScript = "<script language='javascript'> javascript:Page_load_validation(); </script>";
           //Page.RegisterStartupScript("OnLoad_21", StrScript);
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        Insert_C_ChequeCaptureInfo();
        Reset_Controls();//nn
        GET_Header_Values(txtBatchNo.Text.Trim());//nn

    }
    private void GET_Header_Values(string pBatchNo)
    {
         
        txtBatchNo.Text = pBatchNo.Trim();
        Get_DropBoxDetails_Dropwise(txtBatchNo.Text.Trim());
        //Get_ReasonList();
        Get_BatchDetails_For_ChequeEntry();
        if (hdnMICRDetails.Value == "")
        {
            Get_MICRDetails();
             
        }

    }
    private void Register_ControlsWith_JavaScript()
    {

        //ddlDropBoxList.Attributes.Add("onKeyDown", "javascript:Get_DropBoxDetails(event);");
        //ddlReasonList.Attributes.Add("onKeyDown", "javascript:if(event.keyCode==13){ event.keyCode=9};");
        ddlInstrumentType.Attributes.Add("onKeyDown", "javascript:if(event.keyCode==13){ event.keyCode=9;};");
        ddlSignature.Attributes.Add("onKeyDown", "javascript:if(event.keyCode==13){ event.keyCode=9;};");

        txtChequeNo.Attributes.Add("onKeyDown", "javascript:if(event.keyCode==13){ event.keyCode=9;};");
        txtChequeAmt.Attributes.Add("onKeyDown", "javascript:if(event.keyCode==13) {event.keyCode=9;};");
        txtChequeDate.Attributes.Add("onKeyDown", "javascript:if(event.keyCode==13) { event.keyCode=9;};");
        txtCardNo.Attributes.Add("onKeyDown", "javascript:if(event.keyCode==13) {event.keyCode=9;};");
        //txtMICRCode.Attributes.Add("onKeyDown", "javascript:if(event.keyCode==13) {event.keyCode=9;};");
        txtMICRCode.Attributes.Add("onKeyDown", "javascript:if(event.keyCode==13) {event.keyCode=9;};");
        txtAcountNo.Attributes.Add("onKeyDown", "javascript:if(event.keyCode==13) {event.keyCode=9;};");

        txtBank.Attributes.Add("onKeyDown", "javascript:if(event.keyCode==13) event.keyCode=9;");
        txtBranch.Attributes.Add("onKeyDown", "javascript:if(event.keyCode==13) event.keyCode=9;");
        txtCity.Attributes.Add("onKeyDown", "javascript:if(event.keyCode==13) event.keyCode=9;");
        //txtRemark.Attributes.Add("onKeyDown", "javascript:if(event.keyCode==13) event.keyCode=9;");
        btnSave.Attributes.Add("onclick", "javascript:return Validate_Save();");
        ddlDropBoxList.Attributes.Add("onKeyDown", "javascript:if(event.keyCode==13){ event.keyCode=9;Get_DropBoxDetails();};");         
         //txtMICRCode.Attributes.Add("onfocusout", "javascript:Validate_MICRCode();");        
         //btnSave.Attributes.Add("onclick", "javascript:return Validate_Save();");
       
    }
    private void Insert_C_ChequeCaptureInfo()
    {
        Object SaveUSERInfo = (Object)Session["UserInfo"];
        
        SqlConnection sqlCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);

        
        SqlCommand sqlCom = new SqlCommand();
        sqlCom.Connection = sqlCon;
        sqlCom.CommandType = CommandType.StoredProcedure;
        sqlCom.CommandText = "Insert_Other_ChequeCapureInfo_mod";
        sqlCom.CommandTimeout = 0;

 

        SqlParameter BranchID = new SqlParameter();
        BranchID.SqlDbType = SqlDbType.Int;
        BranchID.Value = Convert.ToInt32(((UserInfo.structUSERInfo)(SaveUSERInfo)).BranchId);
        BranchID.ParameterName = "@BranchID";
        sqlCom.Parameters.Add(BranchID);

        SqlParameter TransactionDetailID = new SqlParameter();
        TransactionDetailID.SqlDbType = SqlDbType.Int;
        TransactionDetailID.Value =Convert.ToInt32(hdnTransactionDetailID.Value);
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
        ChequeAmt.Value =Convert.ToDecimal(txtChequeAmt.Text.Trim());
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

        SqlParameter CardAmount= new SqlParameter();
        CardAmount.SqlDbType = SqlDbType.Decimal;
        CardAmount.Value =Convert.ToDecimal( txtChequeAmt.Text.Trim());//Convert.ToDecimal(lblCardAmount.Text.Trim()); 
        CardAmount.ParameterName = "@CardAmount";
        sqlCom.Parameters.Add(CardAmount);

        SqlParameter MICRCode = new SqlParameter();
        MICRCode.SqlDbType = SqlDbType.VarChar;
        MICRCode.Value = txtMICRCode.Text.Trim();
        MICRCode.ParameterName = "@MICRCode";
        sqlCom.Parameters.Add(MICRCode);

        SqlParameter BankName = new SqlParameter();
        BankName.SqlDbType = SqlDbType.VarChar;
        BankName.Value = txtBank.Text;
        BankName.ParameterName = "@BankName";
        sqlCom.Parameters.Add(BankName);

        SqlParameter BranchName = new SqlParameter();
        BranchName.SqlDbType = SqlDbType.VarChar;
        BranchName.Value = txtBranch.Text;
        BranchName.ParameterName = "@BranchName";
        sqlCom.Parameters.Add(BranchName);

        SqlParameter BranchCity = new SqlParameter();
        BranchCity.SqlDbType = SqlDbType.VarChar;
        BranchCity.Value = txtCity.Text;
        BranchCity.ParameterName = "@BranchCity";
        sqlCom.Parameters.Add(BranchCity);

        SqlParameter AccountNo = new SqlParameter();
        AccountNo.SqlDbType = SqlDbType.VarChar;
        AccountNo.Value = txtAcountNo.Text.Trim();
        AccountNo.ParameterName = "@AccountNo";
        sqlCom.Parameters.Add(AccountNo);

        //SqlParameter Remark = new SqlParameter();
        //Remark.SqlDbType = SqlDbType.VarChar;
        //Remark.Value = txtRemark.Text.Trim();
        //Remark.ParameterName = "@Remark";
        //sqlCom.Parameters.Add(Remark);

        //SqlParameter ContactNo = new SqlParameter();
        //ContactNo.SqlDbType = SqlDbType.VarChar;
        //ContactNo.Value = txtContactNo.Text.Trim();
        //ContactNo.ParameterName = "@ContactNo";
        //sqlCom.Parameters.Add(ContactNo);


        //SqlParameter TransactionCode = new SqlParameter();
        //TransactionCode.SqlDbType = SqlDbType.VarChar;
        //TransactionCode.Value = txtTransactionCode.Text.Trim();
        //TransactionCode.ParameterName = "@TransactionCode";
        //sqlCom.Parameters.Add(TransactionCode);

        //SqlParameter ReceiptNo = new SqlParameter();
        //ReceiptNo.SqlDbType = SqlDbType.VarChar;
        //ReceiptNo.Value = txtReceiptNo.Text.Trim();
        //ReceiptNo.ParameterName = "@ReceiptNo";
        //sqlCom.Parameters.Add(ReceiptNo);

        //int intReasonID = 0;
        //if (ddlReasonList.SelectedIndex != 0)
        //{
        //    intReasonID = Convert.ToInt32(ddlReasonList.SelectedItem.Value);
        //}

        //SqlParameter ReasonID = new SqlParameter();
        //ReasonID.SqlDbType = SqlDbType.Int ;
        //ReasonID.Value = intReasonID;
        //ReasonID.ParameterName = "@ReasonID";
        //sqlCom.Parameters.Add(ReasonID);

        SqlParameter ChequeType = new SqlParameter();
        ChequeType.SqlDbType = SqlDbType.VarChar;
        ChequeType.Value = hdnchequeCategory.Value;//hdnChequeStaus.Value;
        ChequeType.ParameterName = "@ChequeType";
        sqlCom.Parameters.Add(ChequeType);

        SqlParameter IsSignOn = new SqlParameter();
        IsSignOn.SqlDbType = SqlDbType.VarChar;
        IsSignOn.Value = ddlSignature.SelectedItem.Value.Trim();
        IsSignOn.ParameterName = "@IsSignOn";
        sqlCom.Parameters.Add(IsSignOn);

        SqlParameter ChequeCaptureStart = new SqlParameter();
        ChequeCaptureStart.SqlDbType = SqlDbType.VarChar;
        ChequeCaptureStart.Value = hdnEntryStart.Value ;
        ChequeCaptureStart.ParameterName = "@ChequeCaptureStart";
        sqlCom.Parameters.Add(ChequeCaptureStart); 

        SqlParameter UserID = new SqlParameter();
        UserID.SqlDbType = SqlDbType.VarChar;
        UserID.Value = Convert.ToString(((UserInfo.structUSERInfo)(SaveUSERInfo)).UserId);
        UserID.ParameterName = "@UserID";
        sqlCom.Parameters.Add(UserID);

        //SqlParameter IsSuspense = new SqlParameter();
        //IsSuspense.SqlDbType = SqlDbType.Int ;
        //IsSuspense.Value =Convert.ToInt32(hdnIsSuspenseCheque.Value);
        //IsSuspense.ParameterName = "@IsSuspense";
        //sqlCom.Parameters.Add(IsSuspense); 

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
            Reset_Controls();
            GET_Header_Values(txtBatchNo.Text.Trim());
        }

    }
    private void Get_DropBoxDetails_Dropwise(string strBatchNo)
    {
        try
        {
            Object SaveUSERInfo = (Object)Session["UserInfo"];

            SqlConnection sqlcon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);


            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlcon;
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.CommandText = "Get_DropBoxDetails_Dropwise";
            sqlcmd.CommandTimeout = 0;



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
    private void Get_BatchDetails_For_ChequeEntry()
    {
        try
        {
            Object SaveUSERInfo = (Object)Session["UserInfo"];

            SqlConnection sqlcon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);


            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlcon;
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.CommandText = "Get_BatchDetails_For_ChequeEntry";
            sqlcmd.CommandTimeout = 0;



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

            sqlcon.Open();
            SqlDataAdapter sqlda = new SqlDataAdapter();
            sqlda.SelectCommand = sqlcmd;
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
                    //txtContactNo.Text = ds.Tables[1].Rows[0]["ContactNo"].ToString();
                    txtMICRCode.Text = ds.Tables[1].Rows[0]["MICRCode"].ToString();
                    //txtReceiptNo.Text = ds.Tables[1].Rows[0]["ReceiptNo"].ToString();
                    //txtRemark.Text = ds.Tables[1].Rows[0]["Remark"].ToString();
                    //txtTransactionCode.Text = ds.Tables[1].Rows[0]["TransactionCode"].ToString();

                    ddlInstrumentType.SelectedValue = ds.Tables[1].Rows[0]["IntrumentType"].ToString();
                    //ddlReasonList.SelectedValue = ds.Tables[1].Rows[0]["ReasonID"].ToString();
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


            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlcon;
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.CommandText = "Get_MICRDetails";
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
                string strMICRDetails = "";

                for (int i = 0; i <= dt.Rows.Count - 1; i++)
                {
                    strMICRDetails = strMICRDetails + dt.Rows[i]["MICR_Details"].ToString().Trim();
                }
                hdnMICRDetails.Value = strMICRDetails;

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
    private void Reset_Controls()
    {
        ddlInstrumentType.SelectedIndex = 0;
        txtAcountNo.Text = "";       
        txtCardNo.Text = "";
        txtChequeAmt.Text = "";
        txtChequeDate.Text = "";
        txtChequeNo.Text = "";
        //txtContactNo.Text = "";
        txtMICRCode.Text = "";
        //txtReceiptNo.Text = "";
        //txtRemark.Text = "";
        //txtTransactionCode.Text = "";

        hdnChequeStaus.Value = "0";
        hdnEntryStart.Value = "";
        hdnDate.Value = "";
        hdnIsSuspenseCheque.Value = "0";
        //hdnMICRDetails.Value = "";
        hdnTransactionDetailID.Value = "0";
                    
    }
    protected void btnAddNew_Click(object sender, EventArgs e)
    {
        Reset_Controls();
        GET_Header_Values(txtBatchNo.Text.Trim());
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    { 
        Response.Redirect("~/Pages/Menu.aspx", true);     
    }
    protected void btnBackToSearch_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Pages/ChequeProcessingNEW/ChequeEntry_View.aspx", true); 
    }
    //private void Get_ReasonList()
    //{
    //    try
    //    {
    //        Object SaveUSERInfo = (Object)Session["UserInfo"];

    //        SqlConnection sqlcon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);

    //        sqlcon.Open();
    //        SqlCommand sqlcmd = new SqlCommand();
    //        sqlcmd.Connection = sqlcon;
    //        sqlcmd.CommandType = CommandType.StoredProcedure;
    //        sqlcmd.CommandText = "Get_ReasonList";
    //        SqlDataAdapter sqlda = new SqlDataAdapter();
    //        sqlda.SelectCommand = sqlcmd;

    //        SqlParameter Is_Active = new SqlParameter();
    //        Is_Active.SqlDbType = SqlDbType.Int;
    //        Is_Active.Value = 1;
    //        Is_Active.ParameterName = "@Is_Active";
    //        sqlcmd.Parameters.Add(Is_Active);

    //        DataTable dt = new DataTable();
    //        sqlda.Fill(dt);
    //        sqlcon.Close();

    //        ddlReasonList.DataTextField = "Reason";
    //        ddlReasonList.DataValueField = "ReasonID";
    //        ddlReasonList.DataSource = dt;
    //        ddlReasonList.DataBind();

    //        ddlReasonList.Items.Insert(0, "-Select-");
    //        ddlReasonList.SelectedIndex = 0;

    //    }
    //    catch (Exception ex)
    //    {
    //        lblMessage.Visible = true;
    //        lblMessage.Text = ex.Message;
    //        lblMessage.CssClass = "ErrorMessage";

    //    }

    //}
}
