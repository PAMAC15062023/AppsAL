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
using System.IO;

public partial class Pages_Calculus_OtherThanPettyCash_SubmitDetails : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserInfo"] == null)
        {
            Response.Redirect("~/Pages/InvalidRequest.aspx");

        }

        if (!IsPostBack)
        {
            if (Request.QueryString["Vw"] != null)
            {
                btnSave.Visible = false;
            }
            if (Request.QueryString["TID"] != null)
            {
                hdnTransactionID.Value = Request.QueryString["TID"].ToString();
                lblTransactionID.Text = Request.QueryString["TID"].ToString();
            }
            
          
            Register_ControlsWith_JavaScript();
            Get_Header_Details();
        }

         string StrScript = "<script language='javascript'> javascript:Page_load_validation(); </script>";
         Page.RegisterStartupScript("OnLoad_21", StrScript);
    }
    private void Get_Header_Details()
    {
        Get_ServiceTaxList();
        Get_OTP_TransactionDetails(hdnTransactionID.Value.Trim());
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Pages/Menu.aspx",true);
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        Insert_PaymentRequestForOTPCash();  
    }
    private void Insert_PaymentRequestForOTPCash()
    {
        try
        {
            Object SaveUSERInfo = (Object)Session["UserInfo"];

            SqlConnection sqlCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);

            sqlCon.Open();
            SqlCommand sqlCom = new SqlCommand();
            sqlCom.Connection = sqlCon;
            sqlCom.CommandType = CommandType.StoredProcedure;
            sqlCom.CommandText = "Update_TransactionInfo_OtherThanPettyCash";

            SqlParameter TransactionID = new SqlParameter();
            TransactionID.SqlDbType = SqlDbType.VarChar;
            TransactionID.Value = hdnTransactionID.Value;
            TransactionID.ParameterName = "@TransactionID";
            TransactionID.Size = 200;
            sqlCom.Parameters.Add(TransactionID);

            SqlParameter BranchID = new SqlParameter();
            BranchID.SqlDbType = SqlDbType.Int;
            BranchID.Value = Convert.ToInt32(((UserInfo.structUSERInfo)(SaveUSERInfo)).BranchId);
            BranchID.ParameterName = "@BranchID";
            sqlCom.Parameters.Add(BranchID);

            SqlParameter RequestDate = new SqlParameter();
            RequestDate.SqlDbType = SqlDbType.VarChar;
            RequestDate.Value = lblRequestDate.Text.Trim();
            RequestDate.ParameterName = "@RequestDate";
            sqlCom.Parameters.Add(RequestDate);

            SqlParameter TotalRequestAmount = new SqlParameter();
            TotalRequestAmount.SqlDbType = SqlDbType.Decimal;
            TotalRequestAmount.Value = lblRequestedAmount.Text.Trim();
            TotalRequestAmount.ParameterName = "@TotalRequestAmount";
            sqlCom.Parameters.Add(TotalRequestAmount);

            SqlParameter AccountLedgerID = new SqlParameter();
            AccountLedgerID.SqlDbType = SqlDbType.Int;
            AccountLedgerID.Value = 0;
            AccountLedgerID.ParameterName = "@AccountLedgerID";
            sqlCom.Parameters.Add(AccountLedgerID);

            SqlParameter UserID = new SqlParameter();
            UserID.SqlDbType = SqlDbType.VarChar;
            UserID.Value = Convert.ToString(((UserInfo.structUSERInfo)(SaveUSERInfo)).UserId);
            UserID.ParameterName = "@UserID";
            sqlCom.Parameters.Add(UserID);

            SqlParameter TransactionDetails = new SqlParameter();
            TransactionDetails.SqlDbType = SqlDbType.VarChar;
            TransactionDetails.Value = hdnProductID.Value.Trim()+ "|" + hdnVerticalID.Value.Trim() + "|" + hdnActivityID.Value.Trim() + "|"+txtClientName.Text.Trim()+"|"+txtBillNo.Text.Trim()+"|" + txtBillDate.Text.Trim() + "|" + txtBillAmt.Text.Trim() + "|"+ddlServiceTax.SelectedItem.Value+"|"+ddlServiceTax.SelectedItem.Text+"|"+hdnServiceTaxAmount.Value+"|"+txtServiceTaxRegNo.Text.Trim()+"|0|"+txtMobile_TelNo.Text.Trim()+"|"+txtDuedate.Text.Trim()+"|"+txtDueAmount.Text.Trim()+"|"+txtPanNo.Text.Trim()+"|"+hdnDepositConfirmation.Value+"|"+hdnDepositAmountDetails.Value+"^";
            TransactionDetails.ParameterName = "@TransactionDetails";
            sqlCom.Parameters.Add(TransactionDetails);

            SqlParameter AttachmentPath = new SqlParameter();
            AttachmentPath.SqlDbType = SqlDbType.VarChar;
            AttachmentPath.Value = UploadAttachment_OnServer();
            AttachmentPath.ParameterName = "@AttachmentPath";
            sqlCom.Parameters.Add(AttachmentPath);

            SqlParameter VarResult = new SqlParameter();
            VarResult.SqlDbType = SqlDbType.VarChar;
            VarResult.Value = "";
            VarResult.ParameterName = "@VarResult";
            VarResult.Size = 200;
            VarResult.Direction = ParameterDirection.Output;
            sqlCom.Parameters.Add(VarResult);

            sqlCom.ExecuteNonQuery();
            string RowEffected = Convert.ToString(sqlCom.Parameters["@VarResult"].Value);

            sqlCon.Close();

            if (RowEffected != "")
            {
                lblMessage.Text = "Transaction Successfully Saved! Transaction ID : " + RowEffected;
                lblMessage.CssClass = "SuccessMessage";
                lblTransactionID.Text = RowEffected;
                lblTransactionID.Visible = true;
                hdnTransactionID.Value = RowEffected;

            }
        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;

        }

    }      
    private void Get_OTP_TransactionDetails(string pTransactionID)
    {
        try
        {
            Object SaveUSERInfo = (Object)Session["UserInfo"];

            SqlConnection sqlCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);

            sqlCon.Open();
            SqlCommand sqlCom = new SqlCommand();
            sqlCom.Connection = sqlCon;
            sqlCom.CommandType = CommandType.StoredProcedure;
            sqlCom.CommandText = "Get_OTH_Details_For_Sumbit";

            SqlParameter BranchID = new SqlParameter();
            BranchID.SqlDbType = SqlDbType.Int;
            BranchID.Value = Convert.ToInt32(((UserInfo.structUSERInfo)(SaveUSERInfo)).BranchId);//pBranchId;
            BranchID.ParameterName = "@BranchID";
            sqlCom.Parameters.Add(BranchID);

            SqlParameter TransactionID = new SqlParameter();
            TransactionID.SqlDbType = SqlDbType.VarChar;
            TransactionID.Value = pTransactionID;
            TransactionID.ParameterName = "@TransactionID";
            sqlCom.Parameters.Add(TransactionID);

            SqlDataAdapter sqlDA = new SqlDataAdapter();
            sqlDA.SelectCommand = sqlCom;
            DataTable dt = new DataTable();
            sqlDA.Fill(dt);
            sqlCon.Close();

            if (dt.Rows.Count > 0)
            { 
                
                lblTransactionID.Text=dt.Rows[0]["TransactionID"].ToString();
                hdnTransactionID.Value=dt.Rows[0]["TransactionID"].ToString();

                lblActivity.Text  =dt.Rows[0]["Activity"].ToString();
                lblAuthorizeBy.Text=dt.Rows[0]["AuthorizeBy"].ToString();
                lblAuthorizeRemark.Text =dt.Rows[0]["Authorize_Remark"].ToString();

                lblAuthorizeDate.Text = dt.Rows[0]["AuthorizeDate"].ToString();

                lblCentreName.Text = dt.Rows[0]["Branch"].ToString();
                lblClusterName.Text = dt.Rows[0]["Region"].ToString();
                lblPaymentID.Text = dt.Rows[0]["PaymentID"].ToString();
                lblProduct.Text = dt.Rows[0]["Product"].ToString();
                lblRequestBy.Text = dt.Rows[0]["RequestBy"].ToString();
                lblRequestDate.Text = dt.Rows[0]["RequestDate"].ToString();
                lblRequestedAmount.Text = dt.Rows[0]["RequestedAmount"].ToString();
                lblTransferAmount.Text = dt.Rows[0]["TransferAmount"].ToString();
                lblTransferBy.Text = dt.Rows[0]["TransferAmount"].ToString();
                lblTransferDate.Text = dt.Rows[0]["TransferDate"].ToString();
                lblVertical.Text = dt.Rows[0]["Vertical"].ToString();

                string strBillNo = dt.Rows[0]["BillNo"].ToString().Trim();

                if (strBillNo != "OTP01")
                {

                    txtClientName.Text = dt.Rows[0]["Client"].ToString();
                    txtBillNo.Text = dt.Rows[0]["BillNo"].ToString();
                    txtBillDate.Text = dt.Rows[0]["BillDate"].ToString();
                    txtBillAmt.Text = dt.Rows[0]["BillAmount"].ToString();
                    txtDueAmount.Text = dt.Rows[0]["DueAmount"].ToString();
                    txtDuedate.Text = dt.Rows[0]["DueDate"].ToString();
                    txtMobile_TelNo.Text = dt.Rows[0]["Mobile_TelNo"].ToString();
                    txtPanNo.Text = dt.Rows[0]["PanNo"].ToString();
                    txtServiceTaxAmt.Text = dt.Rows[0]["ServiceTaxAmount"].ToString();
                    txtServiceTaxRegNo.Text = dt.Rows[0]["ServiceTaxRegNo"].ToString();
                    ddlServiceTax.SelectedValue = dt.Rows[0]["ServiceTaxID"].ToString();
                }
                else if (strBillNo == "OTP01")
                {
                    txtClientName.Text = "";
                    txtBillNo.Text = "";
                    txtBillDate.Text = "";
                    txtBillAmt.Text = "0.00";
                    txtDueAmount.Text = "0.00";
                    txtDuedate.Text = "";
                    txtMobile_TelNo.Text = "";
                    txtPanNo.Text = "";
                    txtServiceTaxAmt.Text = "0.00";
                    txtServiceTaxRegNo.Text = "";
                    ddlServiceTax.SelectedIndex = 0;            
                
                }


                hdnActivityID.Value = dt.Rows[0]["ActivityID"].ToString();
                hdnProductID.Value = dt.Rows[0]["ProductID"].ToString();
                hdnVerticalID.Value = dt.Rows[0]["verticalID"].ToString();
                              
            }
            


        }
        catch (Exception ex)
        {
            lblMessage.Visible = true;
            lblMessage.Text = ex.Message;
            lblMessage.CssClass = "ErrorMessage";
        }
    }
    private void Get_ServiceTaxList()
    {
        try
        {

            SqlConnection sqlCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);

            sqlCon.Open();
            SqlCommand sqlCom = new SqlCommand();
            sqlCom.Connection = sqlCon;
            sqlCom.CommandType = CommandType.StoredProcedure;
            sqlCom.CommandText = "Get_ServiceTaxList";

            SqlParameter IsActive = new SqlParameter();
            IsActive.SqlDbType = SqlDbType.Bit;
            IsActive.Value = true;
            IsActive.ParameterName = "@IsActive";
            sqlCom.Parameters.Add(IsActive);

            SqlDataAdapter sqlDA = new SqlDataAdapter();
            sqlDA.SelectCommand = sqlCom;

            DataTable dt = new DataTable();
            sqlDA.Fill(dt);
            sqlCon.Close();

            ddlServiceTax.DataTextField = "ServiceTaxPercentage";
            ddlServiceTax.DataValueField = "ServiceTaxID";

            ddlServiceTax.DataSource = dt;
            ddlServiceTax.DataBind();

            ddlServiceTax.Items.Insert(0, "--Select--");
            ddlServiceTax.SelectedIndex = 0;



        }
        catch (Exception ex)
        {
            lblMessage.Visible = true;
            lblMessage.Text = ex.Message;
            lblMessage.CssClass = "ErrorMessage";
        }


    }
    private string UploadAttachment_OnServer()
    {
        try
        {
            string FileSavePath = "";
            if (FileUpload1.FileName != "")
            {
                string fullSitePath = Convert.ToString(ConfigurationSettings.AppSettings["CalculusAttachmentPath"]);
                fullSitePath = fullSitePath.Trim();

                string FileName_Attachment = Convert.ToString(DateTime.Now.ToString("yyyyMMddHHmmss")) + "-" + Convert.ToString(FileUpload1.FileName.Trim());
                FileName_Attachment = FileName_Attachment.Replace(" ", "_");
                FileSavePath = fullSitePath + FileName_Attachment;

                FileInfo FFileName_ValidDBF = new FileInfo(FileSavePath);
                if (FFileName_ValidDBF.Exists)
                {
                    File.Delete(FileSavePath);
                }

                FileUpload1.SaveAs(FileSavePath);
            }
            return FileSavePath;
        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
            lblMessage.CssClass = "ErrorMessage";
            return "";
        }
    }
    private void Register_ControlsWith_JavaScript()
    {
        btnSave.Attributes.Add("onclick","javascript:return Validate_Save();");
        txtServiceTaxAmt.Attributes.Add("onfocus", "javascript:CalulateTax();");
        ddlServiceTax.Attributes.Add("onchange", "javascript:CalulateTax();");
        txtBillAmt.Attributes.Add("onfocus", "javascript:CalulateDepositAmount();");         
    } 
}  



