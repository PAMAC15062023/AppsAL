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

public partial class Pages_Calculus_OtherThanPettyCash_AmountTransfer : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
               
        if (Session["UserInfo"] == null)
        {
            Response.Redirect("~/Pages/InvalidRequest.aspx"); 
        }

         string paramlist = Session["Param"].ToString();
         string[] arrPARAM = paramlist.Split('|');   
  

        if (!IsPostBack)
        {
            if (Request.QueryString["Vw"] != null)
            {
                btnSave.Visible = false;
            }
            if (Request.QueryString["TID"] != null)
            {
                hdnTransactionID.Value = arrPARAM[0].ToString(); //Request.QueryString["TID"].ToString();
                lblTransactionID.Text = hdnTransactionID.Value;
            }

            GET_Header_Values();
            Register_ControlsWith_JavaScript(); 
        }

        string StrScript = "<script language='javascript'> javascript:Page_load_validation(); </script>";
         
        Page.RegisterStartupScript("OnLoad_21", StrScript); 
    }
    private void GET_Header_Values()
    {
        Get_BankInfo();
        Get_BankBranchInfo(0);
        if (hdnTransactionID.Value!="")
        {
            Get_OTP_TransactionDetails(hdnTransactionID.Value.ToString());
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
            sqlCom.CommandText = "Get_OTP_TransactionDetails";

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
                hdnPaymentID.Value=dt.Rows[0]["PaymentID"].ToString();
                lblPaymentID.Text = dt.Rows[0]["PaymentID"].ToString();

                lblActivity.Text = dt.Rows[0]["Activity"].ToString();
                RequestedAmount.Text = dt.Rows[0]["TotalRequestAmount"].ToString();
                lblAuthorizeBy.Text = dt.Rows[0]["AuthorizeBy"].ToString();
                lblCentreName.Text = dt.Rows[0]["Branch"].ToString();
                lblClusterName.Text = dt.Rows[0]["Region"].ToString();
                lblProduct.Text = dt.Rows[0]["Product"].ToString();
                lblRequestBy.Text = dt.Rows[0]["RequestBy"].ToString();
                lblTransactionID.Text = dt.Rows[0]["TransactionID"].ToString();
                lblVertical.Text = dt.Rows[0]["Vertical"].ToString();
                //ddlOTPRequest.Items.Add(dt.Rows[0]["TransactionID"].ToString());
                lblAccountHead.Text = dt.Rows[0]["AccountLedgerName"].ToString();
                lblRemark.Text = dt.Rows[0]["Remark"].ToString();


                lblAmount.Text = dt.Rows[0]["TotalRequestAmount"].ToString();
                hdnBranchID.Value = dt.Rows[0]["BranchID"].ToString();

                
                ListItem ListTransactionID=new ListItem(dt.Rows[0]["TransactionID"].ToString(),dt.Rows[0]["TransactionDetailID"].ToString());
                ddlOTPRequest.Items.Add(ListTransactionID);
            }
            if (hdnPaymentID.Value != "")
            { 
                Get_PaymentDetails();
            }


        }
        catch (Exception ex)
        {
            lblErrorMessage.Visible = true;
            lblErrorMessage.Text = ex.Message;
            lblErrorMessage.CssClass = "ErrorMessage";
        }
    }
    private void Register_ControlsWith_JavaScript()
    {
        ddlPaymentType.Attributes.Add("onchange", "javascript:Validate_PaymentType();");        
        btnSave.Attributes.Add("onclick", "javascript:return Validate_Save();");
        ddlIsChequePrint.Attributes.Add("onchange", "javascript:Validate_ChequePrint();");       
        ddlBankBranchList.Attributes.Add("onchange", "javascript:Validate_BankBranchList();");
     
    }
    private void Get_PaymentDetails()
    {

        Object SaveUSERInfo = (Object)Session["UserInfo"];

        SqlConnection sqlCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);

        sqlCon.Open();
        SqlCommand sqlCom = new SqlCommand();
        sqlCom.Connection = sqlCon;
        sqlCom.CommandType = CommandType.StoredProcedure;
        sqlCom.CommandText = "Get_OTP_PaymentDetailsFor_Modify";

        SqlParameter PaymentID = new SqlParameter();
        PaymentID.SqlDbType = SqlDbType.VarChar;
        PaymentID.Value = hdnPaymentID.Value;
        PaymentID.ParameterName = "@PaymentID";
        sqlCom.Parameters.Add(PaymentID);

        SqlParameter BranchID = new SqlParameter();
        BranchID.SqlDbType = SqlDbType.Int;
        BranchID.Value = Convert.ToInt32(((UserInfo.structUSERInfo)(SaveUSERInfo)).BranchId);//pBranchId;
        BranchID.ParameterName = "@BranchID";
        sqlCom.Parameters.Add(BranchID);

        SqlDataAdapter sqlDA = new SqlDataAdapter();
        sqlDA.SelectCommand = sqlCom;
        DataTable dt = new DataTable();
        sqlDA.Fill(dt);
        sqlCon.Close();

        if (dt.Rows.Count > 0)
        {
            ddlPaymentType.SelectedValue = dt.Rows[0]["PaymentType"].ToString();
            txtAccountHolderName.Text = dt.Rows[0]["AccountHolderName"].ToString(); 

            txtChequeIssue.Text = dt.Rows[0]["ChequeIssueTo"].ToString();
            txtChequeNo.Text = dt.Rows[0]["ChequeNo"].ToString();

            txtCheuqeDate.Text = dt.Rows[0]["ChequeDate"].ToString();
            txtTransferAccountNo.Text = dt.Rows[0]["AccountNo"].ToString();

            hdnAccountHolderName.Value = dt.Rows[0]["AccountHolderName"].ToString();
            hdnAccountNo.Value=dt.Rows[0]["AccountNo"].ToString();

          
            ddlBankList.SelectedValue = dt.Rows[0]["BankID"].ToString(); 


            ddlBankBranchList.SelectedValue = dt.Rows[0]["BankBranchID"].ToString();

            bool IsBearer =Convert.ToBoolean(dt.Rows[0]["IsBearer"].ToString());
            if (IsBearer==true)
            {
                 ddlIsBearer.SelectedValue = "1";
            }

            else
            {
                ddlIsBearer.SelectedValue = "2";
            }

            bool IsCheque =Convert.ToBoolean( dt.Rows[0]["IsChequePrint"].ToString());
            if (IsCheque == true)
            {
                ddlIsChequePrint.SelectedValue = "1";
            }

            else
            {
                ddlIsChequePrint.SelectedValue = "2";
            }
             
        }

    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Pages/Menu.aspx");
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        Insert_PaymentInfo(hdnPaymentID.Value.Trim());
    }
    private void Insert_PaymentInfo(string pPaymentID)
    {
        try
        {
            Object SaveUSERInfo = (Object)Session["UserInfo"];

            SqlConnection sqlCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);

            sqlCon.Open();
            SqlCommand sqlCom = new SqlCommand();
            sqlCom.Connection = sqlCon;
            sqlCom.CommandType = CommandType.StoredProcedure;
            sqlCom.CommandText = "Insert_OTH_PaymentInfo";


            SqlParameter PaymentID = new SqlParameter();
            PaymentID.SqlDbType = SqlDbType.VarChar;
            PaymentID.Value = pPaymentID.Trim();
            PaymentID.ParameterName = "@PaymentID";
            sqlCom.Parameters.Add(PaymentID);

            SqlParameter BranchID = new SqlParameter();
            BranchID.SqlDbType = SqlDbType.VarChar;
            BranchID.Value = hdnBranchID.Value.Trim();
            BranchID.ParameterName = "@BranchID";
            sqlCom.Parameters.Add(BranchID);

            SqlParameter TransactionID = new SqlParameter();
            TransactionID.SqlDbType = SqlDbType.VarChar;
            TransactionID.Value = lblTransactionID.Text.Trim();
            TransactionID.ParameterName = "@TransactionID";
            sqlCom.Parameters.Add(TransactionID);

            SqlParameter TotalPaymentAmount = new SqlParameter();
            TotalPaymentAmount.SqlDbType = SqlDbType.Decimal;
            TotalPaymentAmount.Value = Convert.ToDecimal(lblAmount.Text.Trim());
            TotalPaymentAmount.ParameterName = "@TotalPaymentAmount";
            sqlCom.Parameters.Add(TotalPaymentAmount);

            SqlParameter UserID = new SqlParameter();
            UserID.SqlDbType = SqlDbType.VarChar;
            UserID.Value = Convert.ToString(((UserInfo.structUSERInfo)(SaveUSERInfo)).UserId);//pBranchId;
            UserID.ParameterName = "@UserID";
            sqlCom.Parameters.Add(UserID);


            string valueBankBranchID = ddlBankBranchList.SelectedItem.Value;
            string[] strRowBankBranchID;
            
            strRowBankBranchID = valueBankBranchID.Split('|');  
                                    

            string strPaymentDetails = "";

            strPaymentDetails = ddlPaymentType.SelectedItem.Value + "|" + lblAmount.Text + "|" + txtChequeIssue.Text + "|" + txtChequeNo.Text.Trim() + "|" + txtCheuqeDate.Text.Trim() + "|" + hdnAccountHolderName.Value + "|" + hdnAccountNo.Value + "|" + ddlBankList.SelectedItem.Text + "|" + ddlBankBranchList.SelectedItem.Text + "|" + ddlOTPRequest.SelectedItem.Value + "|" + ddlBankList.SelectedItem.Value + "|" + strRowBankBranchID[0].ToString() + "|" + ddlIsBearer.SelectedItem.Value + "|" + ddlIsChequePrint.SelectedItem.Value + "|1^";

            SqlParameter PaymentDetails = new SqlParameter();
            PaymentDetails.SqlDbType = SqlDbType.VarChar;
            PaymentDetails.Value = strPaymentDetails;
            PaymentDetails.ParameterName = "@PaymentDetails";
            sqlCom.Parameters.Add(PaymentDetails);

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
                hdnPaymentID.Value = RowEffected;
                lblPaymentID.Text = "Payment ID: " + RowEffected;
                lblErrorMessage.Text = "Record Successfully Updated! PaymentID - " + RowEffected;
                lblErrorMessage.CssClass = "UpdateMessage";
                lblErrorMessage.Visible = true;
            }
        }
        catch (Exception ex)
        {
            lblErrorMessage.Text = ex.Message;
            lblErrorMessage.CssClass = "ErrorMessage";
        }

    }
    private void Get_BankInfo()
    {
        SqlConnection sqlCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);

        sqlCon.Open();
        SqlCommand sqlCom = new SqlCommand();
        sqlCom.Connection = sqlCon;
        sqlCom.CommandType = CommandType.StoredProcedure;
        sqlCom.CommandText = "Get_BankInfo";

        SqlParameter BankName = new SqlParameter();
        BankName.SqlDbType = SqlDbType.VarChar;
        BankName.Value = "";
        BankName.ParameterName = "@BankName";
        sqlCom.Parameters.Add(BankName);

        SqlParameter IsActive = new SqlParameter();
        IsActive.SqlDbType = SqlDbType.Int;
        IsActive.Value = 1;
        IsActive.ParameterName = "@IsActive";
        sqlCom.Parameters.Add(IsActive);

        SqlDataAdapter sqlDA = new SqlDataAdapter();
        sqlDA.SelectCommand = sqlCom;
        DataTable dt = new DataTable();
        sqlDA.Fill(dt);
        sqlCon.Close();

        if (dt.Rows.Count > 0)
        {


            ddlBankList.DataSource = dt;
            ddlBankList.DataTextField = "Bank_Name";
            ddlBankList.DataValueField = "Bank_ID";
            ddlBankList.DataBind();

            ddlBankList.Items.Insert(0, "--Select--");
            ddlBankList.SelectedIndex = 0;
        }

    }
    private void Get_BankBranchInfo(int intBankID)
    {
        SqlConnection sqlCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);

        sqlCon.Open();
        SqlCommand sqlCom = new SqlCommand();
        sqlCom.Connection = sqlCon;
        sqlCom.CommandType = CommandType.StoredProcedure;
        sqlCom.CommandText = "Get_BranchBankDetails";

        SqlParameter BankhID = new SqlParameter();
        BankhID.SqlDbType = SqlDbType.Int;
        BankhID.Value = intBankID;
        BankhID.ParameterName = "@BankhID";
        sqlCom.Parameters.Add(BankhID);

        SqlDataAdapter sqlDA = new SqlDataAdapter();
        sqlDA.SelectCommand = sqlCom;
        DataTable dt = new DataTable();
        sqlDA.Fill(dt);
        sqlCon.Close();

        ddlBankBranchList.DataSource = dt;
        ddlBankBranchList.DataTextField = "BranchDetail";
        ddlBankBranchList.DataValueField = "Bank_BranchID";
        ddlBankBranchList.DataBind();


        ddlBankBranchList.Items.Insert(0, "--Select--");
        ddlBankBranchList.SelectedIndex = 0;
    }
    protected void ddlBankList_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlBankList.SelectedIndex != 0)
        {
            Get_BankBranchInfo(Convert.ToInt32(ddlBankList.SelectedItem.Value));
            ddlBankBranchList.Focus();
        }
    }
    private void Reset_Controls()
    {
        txtAccountHolderName.Text = "";
        
        txtChequeIssue.Text = "";
        txtChequeNo.Text = ""; 
        txtCheuqeDate.Text = "";
        txtTransferAccountNo.Text = "";
        
        hdnBranchID.Value = "0";        
        hdnPaymentID.Value = "";
        hdnAccountHolderName.Value = "";
        hdnAccountNo.Value = "";
        hdnTransactionID.Value = ""; 
        
        lblTransactionID.Text = "";
        lblPaymentID.Text = "";

        ddlBankBranchList.SelectedIndex = 0;
        ddlBankList.SelectedIndex = 0;
        ddlIsBearer.SelectedIndex = 0;
        ddlIsChequePrint.SelectedIndex = 0;
        ddlPaymentType.SelectedIndex = 0;  
        ddlIsChequePrint.SelectedIndex = 0;
        ddlOTPRequest.Items.Clear();
        ddlOTPRequest.Items.Insert(0, "--Select--");

    }
    protected void btnSaveNext_Click(object sender, EventArgs e)
    {
        try
        {
            string buildPaymentString = "";
            Insert_PaymentInfo(hdnPaymentID.Value);

            if (hdnPaymentID.Value != "")
            {
                string paramlist = Session["Param"].ToString();
                string[] arrPARAM = paramlist.Split('|');

                for (int i = 0; i <= arrPARAM.Length - 1; i++)
                {

                    if (lblTransactionID.Text.Trim() != arrPARAM[i].Trim())
                    {
                        buildPaymentString = buildPaymentString + arrPARAM[i].Trim() + "|";
                    }
                     
                }

                Session["Param"] = buildPaymentString;

                string paramlistNew = Session["Param"].ToString();
                string[] arrPARAMNew = paramlistNew.Split('|');


                Reset_Controls();
                 hdnTransactionID.Value= arrPARAMNew[0].ToString();
                lblTransactionID.Text=hdnTransactionID.Value;
                if (lblTransactionID.Text != "")
                {
                    Get_BankInfo();
                    Get_OTP_TransactionDetails(lblTransactionID.Text);
                    ddlOTPRequest.Focus();
                }
            }


        }
        catch (Exception ex)
        {
            lblErrorMessage.Text = ex.Message;
            lblErrorMessage.CssClass = "ErrorMessage";
        }

    }
}
