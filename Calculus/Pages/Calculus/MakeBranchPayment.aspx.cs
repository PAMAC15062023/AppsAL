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
using System.Text;

public partial class Pages_Calculus_MakeBranchPayment : System.Web.UI.Page
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
                btnSaveNext.Visible = false;
            }

            if (Session["Param"].ToString() != "")
            {

                lblTransctionID.Text = arrPARAM[0].ToString();
                Get_BankInfo();
                Get_BankBranchInfo(0);
                Get_TransactionDetails(lblTransctionID.Text);
                ddlPaymentRequestList.Focus();
                Bulid_Table_for_TransactionDetails();

            }

            RegisterControls_WithJavascript();
        }
        string StrScript = "<script language='javascript'> javascript:Page_load_validation(); </script>";
        ClientScript.RegisterStartupScript(typeof(Page), "OnLoad_1", StrScript);
    }

    private void Get_TransactionDetails(string pTransactionID)
    {
        try
        {
            Object SaveUSERInfo = (Object)Session["UserInfo"];

            SqlConnection sqlCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);

            sqlCon.Open();
            SqlCommand sqlCom = new SqlCommand();
            sqlCom.Connection = sqlCon;
            sqlCom.CommandType = CommandType.StoredProcedure;
            sqlCom.CommandText = "Get_PaymentRequestDetails_For_MakePayment_new";


            SqlParameter TransactionID = new SqlParameter();
            TransactionID.SqlDbType = SqlDbType.VarChar;
            TransactionID.Value = pTransactionID.ToString().Trim();
            TransactionID.ParameterName = "@TransactionID";
            sqlCom.Parameters.Add(TransactionID);

            SqlDataAdapter sqlDA = new SqlDataAdapter();
            sqlDA.SelectCommand = sqlCom;
            DataTable dt = new DataTable();
            sqlDA.Fill(dt);
            sqlCon.Close();

            if (dt.Rows.Count > 0)
            {
                AssignValueToControls(dt);
            }



        }
        catch (Exception ex)
        {
            lblMessage.Visible = true;
            lblMessage.Text = ex.Message;
            lblMessage.CssClass = "ErrorMessage";
        }

    }

    private void AssignValueToControls(DataTable dt)
    {
        lblTotalAmount.Text = dt.Rows[0]["TotalRequestAmount"].ToString();
        lblBranchName.Text = dt.Rows[0]["BranchName"].ToString();
        lblPayoutDate.Text = dt.Rows[0]["PayoutDate"].ToString();
        hdnBranchID.Value = dt.Rows[0]["BranchID"].ToString();
        hdnPaymentID.Value = dt.Rows[0]["PaymentID"].ToString();
        lblPaymentID.Text = "Payment ID: " + dt.Rows[0]["PaymentID"].ToString();

        ddlPaymentRequestList.DataTextField = "TransId";
        ddlPaymentRequestList.DataValueField = "Details";

        ddlPaymentRequestList.DataSource = dt;
        ddlPaymentRequestList.DataBind();

        ddlPaymentRequestList.Items.Insert(0, "--Select--");

        if (hdnPaymentID.Value != "")
        {
            Get_PaymentDetails();
        }
    }

    private void RegisterControls_WithJavascript()
    {
        ddlPaymentRequestList.Attributes.Add("onchange", "javascript:AssignValues();");
        btnAddtoGrid.Attributes.Add("onclick", "javascript:return AddColumnToGrid();");
        btnRemove.Attributes.Add("onclick", "javascript:return RemoveColumnFromGrid();");
        btnSave.Attributes.Add("onclick", "javascript:return ValidateSave();");
        btnBack.Attributes.Add("onclick", "javascript:return Backin_History();");

        ddlIsChequePrint.Attributes.Add("onchange", "javascript:Validate_ChequePrint();");

        ddlPaymentType.Attributes.Add("onchange", "javascript:Validate_PaymentMode();");

        ddlBankList.Attributes.Add("onchange", "javascript:Validate_BankDetails();");
        //ddlBankBranchList.Attributes.Add("onchange", "javascript:Validate_BankBranchList();");        
        txtTDSPercentage.Attributes.Add("onblur", "javascript:Validate_TDSPercentage();");
        ddlRecipientType.Attributes.Add("onchange", "javascript:Validate_RecipientType();");
        ddlNatureofPayment.Attributes.Add("onchange", "javascript:Validate_NatureofPayment();");
        //ddlTDSPercentage.Attributes.Add("onchange", "javascript:Validate_ddlTDSPercentage();"); 
        ///ClientScriptManager.RegisterForEventValidation.

    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            Insert_PaymentInfo(hdnPaymentID.Value);
            Bulid_Table_for_TransactionDetails();

        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
            lblMessage.CssClass = "ErrorMessage";
        }

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
            sqlCom.CommandText = "Insert_PaymentInfo_new";

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
            TransactionID.Value = lblTransctionID.Text.Trim();
            TransactionID.ParameterName = "@TransactionID";
            sqlCom.Parameters.Add(TransactionID);

            SqlParameter TotalPaymentAmount = new SqlParameter();
            TotalPaymentAmount.SqlDbType = SqlDbType.Decimal;
            TotalPaymentAmount.Value = Convert.ToDecimal(hdnSavingPaymentDetails.Value);
            TotalPaymentAmount.ParameterName = "@TotalPaymentAmount";
            sqlCom.Parameters.Add(TotalPaymentAmount);

            SqlParameter UserID = new SqlParameter();
            UserID.SqlDbType = SqlDbType.VarChar;
            UserID.Value = Convert.ToString(((UserInfo.structUSERInfo)(SaveUSERInfo)).UserId);//pBranchId;
            UserID.ParameterName = "@UserID";
            sqlCom.Parameters.Add(UserID);


            SqlParameter PaymentDetails = new SqlParameter();
            PaymentDetails.SqlDbType = SqlDbType.VarChar;
            PaymentDetails.Value = hdnIssuePaymentDetails.Value;
            PaymentDetails.ParameterName = "@PaymentDetails";
            sqlCom.Parameters.Add(PaymentDetails);

            #region Code By Amrita on 22-Apr-2014 As per Client Requirement
            SqlParameter ClientId = new SqlParameter();
            ClientId.SqlDbType = SqlDbType.Int;
            ClientId.Value = Convert.ToInt32(((UserInfo.structUSERInfo)(SaveUSERInfo)).ClientId);
            ClientId.ParameterName = "@ClientId";
            sqlCom.Parameters.Add(ClientId);
            #endregion


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
                lblMessage.Text = "Record Successfully Updated! PaymentID - " + RowEffected;
                lblMessage.CssClass = "UpdateMessage";
            }
else
{
lblMessage.Text = "Error not save " ;
                lblMessage.CssClass = "UpdateMessage";
}
        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
            lblMessage.CssClass = "ErrorMessage";
        }

    }

    private void Get_PaymentDetails()
    {
        SqlConnection sqlCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);

        sqlCon.Open();
        SqlCommand sqlCom = new SqlCommand();
        sqlCom.Connection = sqlCon;
        sqlCom.CommandType = CommandType.StoredProcedure;
        sqlCom.CommandText = "Get_PaymentDetailsFor_Modify";

        SqlParameter PaymentID = new SqlParameter();
        PaymentID.SqlDbType = SqlDbType.VarChar;
        PaymentID.Value = hdnPaymentID.Value;
        PaymentID.ParameterName = "@PaymentID";
        sqlCom.Parameters.Add(PaymentID);

        SqlParameter BranchID = new SqlParameter();
        BranchID.SqlDbType = SqlDbType.Int;
        BranchID.Value = Convert.ToInt32(hdnBranchID.Value);
        BranchID.ParameterName = "@BranchID";
        sqlCom.Parameters.Add(BranchID);

        SqlDataAdapter sqlDA = new SqlDataAdapter();
        sqlDA.SelectCommand = sqlCom;
        DataTable dt = new DataTable();
        sqlDA.Fill(dt);
        sqlCon.Close();

        if (dt.Rows.Count > 0)
        {
            string strPaymentIssueDetails = "";
            for (int i = 0; i <= dt.Rows.Count - 1; i++)
            {
                strPaymentIssueDetails = strPaymentIssueDetails + dt.Rows[i]["TranDetails"].ToString();
            }

            hdnIssuePaymentDetails.Value = strPaymentIssueDetails;

        }

    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/pages/menu.aspx", true);
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
        sqlCom.CommandText = "Get_All_BranchBankDetails";

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

        string strBranchDetails = "";
        for (int i = 0; i <= dt.Rows.Count - 1; i++)
        {
            strBranchDetails = strBranchDetails + dt.Rows[i]["Details"].ToString();

        }
        hdnBankBranchDetails.Value = strBranchDetails;

    }

    protected void ddlBankList_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlBankList.SelectedIndex != 0)
        {
            Get_BankBranchInfo(Convert.ToInt32(ddlBankList.SelectedItem.Value));

        }
        else
        {
            Get_BankBranchInfo(0);
        }
        //ddlBankBranchList.Focus();
    }

    protected void btnBack_Click(object sender, EventArgs e)
    {

        Response.Redirect("~/Pages/Calculus/PaymentIssueProcess.aspx", true);
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

                    if (lblTransctionID.Text.Trim() != arrPARAM[i].Trim())
                    {
                        buildPaymentString = buildPaymentString + arrPARAM[i].Trim() + "|";
                    }


                }

                Session["Param"] = buildPaymentString;

                string paramlistNew = Session["Param"].ToString();
                string[] arrPARAMNew = paramlistNew.Split('|');


                Reset_Controls();
                lblTransctionID.Text = arrPARAMNew[0].ToString();
                if (lblTransctionID.Text != "")
                {
                    Get_BankInfo();
                    Get_TransactionDetails(lblTransctionID.Text);
                    ddlPaymentRequestList.Focus();
                    Bulid_Table_for_TransactionDetails();
                }
            }
        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
            lblMessage.CssClass = "ErrorMessage";
        }

    }

    private void Reset_Controls()
    {
        txtAccountHolderName.Text = "";
        txtAccountNo.Text = "";
        txtChequeDate.Text = "";
        txtChequeIssueTo.Text = "";
        txtPaymentAmount.Text = "";
        hdnBranchID.Value = "0";
        hdnIssuePaymentDetails.Value = "";
        hdnPaymentID.Value = "";
        hdnSavingPaymentDetails.Value = "";
        lblTransctionID.Text = "";
        lblPaymentID.Text = "";
        txtTDSAmount.Text = "";
        txtTDSPercentage.Text = "";
        txtFinalPaymentAmount.Text = "";
        ddlPaymentRequestList.Items.Clear();
        ddlPaymentRequestList.Items.Insert(0, "--Select--");

        ddlNatureofPayment.SelectedIndex = 0;
        ddlRecipientType.SelectedIndex = 0;
        txtTDSAmount.Text = "";
        txtTDSPercentage.Text = "";


    }

    private void Bulid_Table_for_TransactionDetails()
    {
        string paramlist = Session["Param"].ToString();
        string[] arrPARAM = paramlist.Split('|');

        string strTable = " <table style='backcolor:yellow'> ";

        for (int i = 0; i <= arrPARAM.Length - 1; i++)
        {

            strTable = strTable + "<tr> <td>";
            strTable = strTable + "<b>" + arrPARAM[i].ToString() + "</b>";
            strTable = strTable + "</td></tr>";
        }

        strTable = strTable + "</table>";

        Label1.Text = strTable;


    }



}
