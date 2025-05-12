using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;
using System.Net.Mail;
using System.Text;
using System.Web.Configuration;

public partial class Pages_Calculus_BillStatusApproval : System.Web.UI.Page
{
    string tranID;

    string strTransactionDetail;
    Double RejectAmount = 0;
    string[] ids;
    private string yrMonth;
    int Bid = 0;
    double BalanceAmount;
    private double TransactionAmount;
    private int ReqType;
    private string grdRequestType;
    private int cid;

    protected void Page_Load(object sender, EventArgs e)
    {


        if (Session["UserInfo"] == null)
        {
            Response.Redirect("~/Pages/InvalidRequest.aspx");

        }
        if (!IsPostBack)
        {
            Get_BranchList();
            RegisterControls_WithJavascript();
        }
        Label1.Text = "";
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        Get_TransactionList_For_Process();
    }
    private void Get_TransactionList_For_Process()
    {

        Object SaveUSERInfo = (Object)Session["UserInfo"];

        SqlConnection sqlCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);

        sqlCon.Open();
        SqlCommand sqlCom = new SqlCommand();
        sqlCom.Connection = sqlCon;
        sqlCom.CommandType = CommandType.StoredProcedure;

        if (ddlPaymentType.SelectedValue == "4")
        {
            sqlCom.CommandText = "CalOnlineTrans_GetApprovedPaymentRequest_ViewNew__SP";//Get_ApprovedPaymentRequest_ViewNew_new
            ddlstatus.Visible = true;
        }
        else
        {
            sqlCom.CommandText = "CalOnlineTrans_Get_ApprovedPaymentRequest_View_SP";
            ddlstatus.Visible = false;
        }


        int intBranchID = 0;
        if (ddlBranchList.SelectedIndex != 0)
        {
            intBranchID = Convert.ToInt32(ddlBranchList.SelectedItem.Value);
        }
        SqlParameter BranchId = new SqlParameter();
        BranchId.SqlDbType = SqlDbType.Int;
        BranchId.Value = intBranchID;
        BranchId.ParameterName = "@BranchId";
        sqlCom.Parameters.Add(BranchId);

        SqlParameter TransactionID = new SqlParameter();
        TransactionID.SqlDbType = SqlDbType.VarChar;
        TransactionID.Value = txtTransactionID.Text.Trim();
        TransactionID.ParameterName = "@TransactionID";
        sqlCom.Parameters.Add(TransactionID);

        SqlParameter RequestDate = new SqlParameter();
        RequestDate.SqlDbType = SqlDbType.VarChar;
        RequestDate.Value = txtPayoutDate.Text.Trim();
        RequestDate.ParameterName = "@RequestDate";
        sqlCom.Parameters.Add(RequestDate);

        decimal pAmount = 0;
        if (txtTotalAmount.Text.Trim() != "")
        {
            pAmount = Convert.ToDecimal(txtTotalAmount.Text.Trim());
        }

        SqlParameter TotalAmount = new SqlParameter();
        TotalAmount.SqlDbType = SqlDbType.Decimal;
        TotalAmount.Value = pAmount;
        TotalAmount.ParameterName = "@TotalAmount";
        sqlCom.Parameters.Add(TotalAmount);

        SqlParameter PayoutDate = new SqlParameter();
        PayoutDate.SqlDbType = SqlDbType.VarChar;
        PayoutDate.Value = txtPayoutDate.Text.Trim();
        PayoutDate.ParameterName = "@PayoutDate";
        sqlCom.Parameters.Add(PayoutDate);

        SqlParameter PayeeName = new SqlParameter();
        PayeeName.SqlDbType = SqlDbType.VarChar;
        PayeeName.Value = txtPayeeName.Text.Trim();
        PayeeName.ParameterName = "@PayeeName";
        sqlCom.Parameters.Add(PayeeName);

        SqlParameter BillNo = new SqlParameter();
        BillNo.SqlDbType = SqlDbType.VarChar;
        BillNo.Value = txtBillNo.Text.Trim();
        BillNo.ParameterName = "@BillNo";
        sqlCom.Parameters.Add(BillNo);

        SqlParameter BillDate = new SqlParameter();
        BillDate.SqlDbType = SqlDbType.VarChar;
        BillDate.Value = txtBillDate.Text.Trim();
        BillDate.ParameterName = "@BillDate";
        sqlCom.Parameters.Add(BillDate);

        decimal pBillAmount = 0;
        if (txtBillAmount.Text.Trim() != "")
        {
            pBillAmount = Convert.ToDecimal(txtBillAmount.Text.Trim());
        }

        SqlParameter BillAmount = new SqlParameter();
        BillAmount.SqlDbType = SqlDbType.Decimal;
        BillAmount.Value = pBillAmount;
        BillAmount.ParameterName = "@BillAmount";
        sqlCom.Parameters.Add(BillAmount);

        SqlParameter intStatus = new SqlParameter();
        intStatus.SqlDbType = SqlDbType.Int;
        intStatus.Value = 2;
        intStatus.ParameterName = "@intStatus";
        sqlCom.Parameters.Add(intStatus);

        SqlParameter PaymentType = new SqlParameter();
        PaymentType.SqlDbType = SqlDbType.Int;
        PaymentType.Value = Convert.ToInt32(ddlPaymentType.SelectedItem.Value);
        PaymentType.ParameterName = "@PaymentType";
        sqlCom.Parameters.Add(PaymentType);

        if (ddlPaymentType.SelectedValue == "4")
        {
            SqlParameter status = new SqlParameter();
            status.SqlDbType = SqlDbType.VarChar;
            status.Value = ddlstatus.SelectedValue.ToString().Trim();
            status.ParameterName = "@status";
            sqlCom.Parameters.Add(status);

        }
        else
        {
        }

        if ((ddlstatus.Visible == true && ddlstatus.SelectedValue.ToString().Trim() != "0"))
        {
        }
        else if (ddlstatus.Visible == false)
        {
        }
        else
        {
            lblMessage.Text = "Select Status:";
            return;
        }

        if ((ddlPaymentType.SelectedValue == "4") && (ddlstatus.SelectedValue.ToString().Trim() == "Pending" || ddlstatus.SelectedValue.ToString().Trim() == "Reject"))
        {
            btnAddPayment.Visible = false;
        }
        else
        {

            btnAddPayment.Visible = true;
        }

        #region Code By Amrita on 22-Apr-2014 As per Client Requirement
        SqlParameter c_id = new SqlParameter();
        c_id.SqlDbType = SqlDbType.Int;
        c_id.Value = Convert.ToInt32(((UserInfo.structUSERInfo)(SaveUSERInfo)).ClientId);
        c_id.ParameterName = "@ClientId";
        sqlCom.Parameters.Add(c_id);
        #endregion

        SqlDataAdapter sqlDA = new SqlDataAdapter();
        sqlDA.SelectCommand = sqlCom;
        DataTable dt = new DataTable();
        sqlDA.Fill(dt);
        sqlCon.Close();
        if (dt.Rows.Count > 0)
        {
            grvTransactionInfo.DataSource = dt;
            grvTransactionInfo.DataBind();
            lblMessage.Text = "Total Records Found " + dt.Rows.Count;
            lblMessage.CssClass = "UpdateMessage";
        }
        else
        {
            grvTransactionInfo.DataSource = null;
            grvTransactionInfo.DataBind();
            lblMessage.Text = "No Records found!";
            lblMessage.CssClass = "ErrorMessage";
        }


    }

    protected void grv_RowDataBound(object sender, GridViewRowEventArgs e)
    {

        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            LinkButton lnkDownloadFile = (LinkButton)e.Row.FindControl("lnkDownloadFile");
            if (lnkDownloadFile.CommandArgument == "")
            {
                lnkDownloadFile.Enabled = false;
                lnkDownloadFile.ToolTip = "No Attachment found!";
            }

            //CheckBox chkSelect = (CheckBox)e.Row.FindControl("chkSelect"); 
            //chkSelect.Attributes.Add("onclick","javascript:checkSelected('"+ chkSelect.ClientID+ "');");

            GridView grvDetails = (GridView)e.Row.FindControl("grvDetails");
            grvDetails.DataSource = Get_TransactionDetails(e.Row.Cells[2].Text);
            grvDetails.DataBind();

            SqlConnection sqlCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);

            DropDownList ddlAccountHeadList = (DropDownList)e.Row.FindControl("ddlAccountHeadList");



            sqlCon.Open();
            SqlCommand sqlCom = new SqlCommand();
            sqlCom.Connection = sqlCon;
            sqlCom.CommandType = CommandType.StoredProcedure;
            sqlCom.CommandText = "CalOnlineTrans_Get_AccountHeadList_New2___SP";//Get_AccountHeadList_New1

            SqlParameter Is_Active = new SqlParameter();
            Is_Active.SqlDbType = SqlDbType.Bit;
            Is_Active.Value = true;
            Is_Active.ParameterName = "@Is_Active";
            sqlCom.Parameters.Add(Is_Active);

            SqlParameter PaymentType = new SqlParameter();
            PaymentType.SqlDbType = SqlDbType.Int;
            PaymentType.Value = ddlPaymentType.SelectedValue.ToString();
            PaymentType.ParameterName = "@PaymentType";
            sqlCom.Parameters.Add(PaymentType);

            SqlDataAdapter sqlDA = new SqlDataAdapter();
            sqlDA.SelectCommand = sqlCom;
            DataTable dt = new DataTable();
            sqlDA.Fill(dt);
            sqlCon.Close();

            ddlAccountHeadList.DataTextField = "AccountLedgerName";
            ddlAccountHeadList.DataValueField = "AccountLedgerID";

            ddlAccountHeadList.DataSource = dt;
            ddlAccountHeadList.DataBind();

            ddlAccountHeadList.Items.Insert(0, "--Select--");
            ddlAccountHeadList.SelectedIndex = 0;




        }
    }

    private DataTable Get_TransactionDetails(string strTransactionID)
    {

        SqlConnection sqlCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);

        sqlCon.Open();
        SqlCommand sqlCom = new SqlCommand();
        sqlCom.Connection = sqlCon;
        sqlCom.CommandType = CommandType.StoredProcedure;
        sqlCom.CommandText = "CalOnlineTrans_GetTransactionDetailsForApprove_SP";

        SqlParameter TransactionID = new SqlParameter();
        TransactionID.SqlDbType = SqlDbType.VarChar;
        TransactionID.Value = strTransactionID;
        TransactionID.ParameterName = "@TransactionID";
        sqlCom.Parameters.Add(TransactionID);

        SqlDataAdapter sqlDA = new SqlDataAdapter();
        sqlDA.SelectCommand = sqlCom;
        DataTable dt = new DataTable();
        sqlDA.Fill(dt);
        sqlCon.Close();

        return dt;

    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/pages/menu.aspx", true);
    }

    private void Get_BranchList()
    {
        try
        {
            Object SaveUSERInfo = (Object)Session["UserInfo"];

            SqlConnection sqlCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);

            sqlCon.Open();
            SqlCommand sqlCom = new SqlCommand();
            sqlCom.Connection = sqlCon;
            sqlCom.CommandType = CommandType.StoredProcedure;
            sqlCom.CommandText = "Get_AllBranchList";

            SqlDataAdapter sqlDA = new SqlDataAdapter();
            sqlDA.SelectCommand = sqlCom;
            DataTable dt = new DataTable();
            sqlDA.Fill(dt);
            sqlCon.Close();

            ddlBranchList.DataTextField = "BranchName";
            ddlBranchList.DataValueField = "BranchID";

            ddlBranchList.DataSource = dt;
            ddlBranchList.DataBind();

            ddlBranchList.Items.Insert(0, "--Select--");
            ddlBranchList.SelectedIndex = 0;



        }
        catch (Exception ex)
        {
            lblMessage.Visible = true;
            lblMessage.Text = ex.Message;
            lblMessage.CssClass = "ErrorMessage";
        }
    }

    private void RegisterControls_WithJavascript()
    {
        btnAddPayment.Attributes.Add("onclick", "javascript:return Get_SelectedTransactionID();");
        btnSearch.Attributes.Add("onclick", "javascript:return Validate_Search();");
    }

    private void Update_TransactionRequest(int pStatus)
    {
        try
        {
            Object SaveUSERInfo = (Object)Session["UserInfo"];

            SqlConnection sqlCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);

            sqlCon.Open();
            SqlCommand sqlCom = new SqlCommand();
            sqlCom.Connection = sqlCon;
            sqlCom.CommandType = CommandType.StoredProcedure;
            sqlCom.CommandText = "CalOnlineTrans_Update_BillStatusAndApprove__SP";//Update_BillStatusAndApprove1

            SqlParameter TransactionIDList = new SqlParameter();
            TransactionIDList.SqlDbType = SqlDbType.VarChar;
            TransactionIDList.Value = Get_BillStatus();
            TransactionIDList.ParameterName = "@TransactionIDList";
            sqlCom.Parameters.Add(TransactionIDList);

            SqlParameter Status = new SqlParameter();
            Status.SqlDbType = SqlDbType.Int;
            Status.Value = pStatus;
            Status.ParameterName = "@Status";
            sqlCom.Parameters.Add(Status);

            if (hdnTaxPer.Value != "--Select--")
            {

                SqlParameter AcountHead = new SqlParameter();
                AcountHead.SqlDbType = SqlDbType.VarChar;
                AcountHead.Value = hdnTaxPer.Value;
                AcountHead.ParameterName = "@AcountHead";
                sqlCom.Parameters.Add(AcountHead);
            }
            else
            {
                Label1.Visible = true;
                Label1.Text = "Select Account Ledger..!!";
                return;

            }

            if (hdnRemark.Value != "" || pStatus != 2)
            {
            }
            else
            {
                Label1.Visible = true;
                Label1.Text = "Kindly Enter Remark..!!";
                return;
            }

            SqlParameter UserID = new SqlParameter();
            UserID.SqlDbType = SqlDbType.VarChar;
            UserID.Value = Convert.ToString(((UserInfo.structUSERInfo)(SaveUSERInfo)).UserId);
            UserID.ParameterName = "@UserID";
            sqlCom.Parameters.Add(UserID);

            int RowsEffeted = sqlCom.ExecuteNonQuery();

            if (RowsEffeted > 0)
            {
                lblMessage.Text = "Record Successfully Updated!";
                lblMessage.CssClass = "UpdateMessage";

            }

        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
            lblMessage.CssClass = "ErrorMessage";

        }

    }

    protected void btnAddPayment_Click(object sender, EventArgs e)
    {
        Update_TransactionRequestApproved();
        //Update_TransactionRequest(1);
        Clear_Controls();
    }
    private void Update_TransactionRequestApproved()
    {
        try
        {
            Object SaveUSERInfo = (Object)Session["UserInfo"];

            SqlConnection sqlCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);

            sqlCon.Open();
            SqlCommand sqlCom = new SqlCommand();
            sqlCom.Connection = sqlCon;
            sqlCom.CommandType = CommandType.StoredProcedure;
            sqlCom.CommandText = "CalOnlineTrans_UpdateBillStatusAndApprove_Approved_SP";

            SqlParameter TransactionIDList = new SqlParameter();
            TransactionIDList.SqlDbType = SqlDbType.VarChar;
            TransactionIDList.Value = Get_BillStatus();
            TransactionIDList.ParameterName = "@TransactionIDList";
            sqlCom.Parameters.Add(TransactionIDList);

            SqlParameter Status = new SqlParameter();
            Status.SqlDbType = SqlDbType.Int;
            Status.Value = "1";
            Status.ParameterName = "@Status";
            sqlCom.Parameters.Add(Status);

            if (hdnTaxPer.Value != "--Select--")
            {

                SqlParameter AcountHead = new SqlParameter();
                AcountHead.SqlDbType = SqlDbType.VarChar;
                AcountHead.Value = hdnTaxPer.Value;
                AcountHead.ParameterName = "@AcountHead";
                sqlCom.Parameters.Add(AcountHead);
            }
            else
            {
                Label1.Visible = true;
                Label1.Text = "Select Account Ledger..!!";
                return;

            }

            SqlParameter UserID = new SqlParameter();
            UserID.SqlDbType = SqlDbType.VarChar;
            UserID.Value = Convert.ToString(((UserInfo.structUSERInfo)(SaveUSERInfo)).UserId);
            UserID.ParameterName = "@UserID";
            sqlCom.Parameters.Add(UserID);

            int RowsEffeted = sqlCom.ExecuteNonQuery();

            if (RowsEffeted > 0)
            {
                lblMessage.Text = "Record Successfully Updated!";
                lblMessage.CssClass = "UpdateMessage";

            }

        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
            lblMessage.CssClass = "ErrorMessage";

        }

    }

    protected void Button1_Click(object sender, EventArgs e)
    {

    }

    private void Clear_Controls()
    {
        Get_TransactionList_For_Process();
        //   ddlBranchList.SelectedIndex = 0;
        txtBillAmount.Text = "";
        txtBillDate.Text = "";
        txtBillNo.Text = "";
        txtPayeeName.Text = "";
        txtPayoutDate.Text = "";
        txtTotalAmount.Text = "";
        //txtTransactionID.Text = "";
        ddlPaymentType.Text = "";

    }

    private string Get_TransactionID()
    {
        string strTransaction = "";
        for (int i = 0; i <= grvTransactionInfo.Rows.Count - 1; i++)
        {
            CheckBox chkSelect = (CheckBox)grvTransactionInfo.Rows[i].FindControl("chkSelect");
            TextBox txtRemark = (TextBox)grvTransactionInfo.Rows[i].FindControl("txtRemark");

            if (chkSelect.Checked == true)
            {
                strTransaction = strTransaction + "" + grvTransactionInfo.Rows[i].Cells[2].Text.Trim() + "|" + txtRemark.Text + "|";
                // tranID = grvTransactionInfo.Rows[i].Cells[2].Text.Trim();

            }

        }
        if (strTransaction.Length > 0)
        {
            strTransaction = strTransaction.Substring(0, strTransaction.Length - 1);
            strTransaction = strTransaction + "^";
        }
        return strTransaction;
    }

    private string Get_BillStatus()
    {
        string strBillStatus = "";
        for (int i = 0; i <= grvTransactionInfo.Rows.Count - 1; i++)
        {
            CheckBox chkSelect = (CheckBox)grvTransactionInfo.Rows[i].FindControl("chkSelect");
            TextBox txtRemark = (TextBox)grvTransactionInfo.Rows[i].FindControl("txtRemark");
            DropDownList ddlBillStatus = (DropDownList)grvTransactionInfo.Rows[i].FindControl("ddlBillStatus");

            DropDownList ddlAccountHeadList = (DropDownList)grvTransactionInfo.Rows[i].FindControl("ddlAccountHeadList");

            if (chkSelect.Checked == true)
            {
                strBillStatus = strBillStatus + "" + grvTransactionInfo.Rows[i].Cells[2].Text.Trim() + "|" + ddlBillStatus.SelectedValue + "|" + txtRemark.Text + "|";
                hdnTaxPer.Value = ddlAccountHeadList.SelectedValue;
                hdnRemark.Value = txtRemark.Text;
            }

        }
        if (strBillStatus.Length > 0)
        {
            strBillStatus = strBillStatus.Substring(0, strBillStatus.Length - 1);
            strBillStatus = strBillStatus + "^";
        }
        return strBillStatus;
    }

    protected void lnkDownloadFile_Click(object sender, EventArgs e)
    {

        string DownloadPath = ((System.Web.UI.WebControls.LinkButton)(sender)).CommandArgument.ToString();
        if (DownloadPath != "")
        {
            DownloadFile(DownloadPath, true);
        }
        else
        {
            lblMessage.Text = "No Attach document found!";
        }
    }

    private void DownloadFile(string fname, bool forceDownload)
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
                case ".pdf":
                    type = "application/pdf";
                    break;


            }
        }
        if (forceDownload)
        {
            Response.AppendHeader("content-disposition",
                "attachment; filename=" + name);
        }
        if (type != "")
            Response.ContentType = type;
        Response.WriteFile(path);
        Response.End();
    }

    protected void btnRejectPayment_Click(object sender, EventArgs e)
    {
        Update_TransactionRequestReject();
        //Update_TransactionRequest(2);
        updateTransactionBalance();

        GetTransectionId();

        Clear_Controls();
    }
    private void Update_TransactionRequestReject()
    {
        try
        {
            Object SaveUSERInfo = (Object)Session["UserInfo"];

            SqlConnection sqlCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);

            sqlCon.Open();
            SqlCommand sqlCom = new SqlCommand();
            sqlCom.Connection = sqlCon;
            sqlCom.CommandType = CommandType.StoredProcedure;
            sqlCom.CommandText = "CalOnlineTrans_UpdateBillStatusAndApprove_Reject_SP";

            SqlParameter TransactionIDList = new SqlParameter();
            TransactionIDList.SqlDbType = SqlDbType.VarChar;
            TransactionIDList.Value = Get_BillStatus();
            TransactionIDList.ParameterName = "@TransactionIDList";
            sqlCom.Parameters.Add(TransactionIDList);


            SqlParameter Status = new SqlParameter();
            Status.SqlDbType = SqlDbType.Int;
            Status.Value = "2";
            Status.ParameterName = "@Status";
            sqlCom.Parameters.Add(Status);

            if (hdnTaxPer.Value != "--Select--")
            {

                SqlParameter AcountHead = new SqlParameter();
                AcountHead.SqlDbType = SqlDbType.VarChar;
                AcountHead.Value = hdnTaxPer.Value;
                AcountHead.ParameterName = "@AcountHead";
                sqlCom.Parameters.Add(AcountHead);
            }
            else
            {
                Label1.Visible = true;
                Label1.Text = "Select Account Ledger..!!";
                return;

            }

            if (hdnRemark.Value != "")
            {
            }
            else
            {
                Label1.Visible = true;
                Label1.Text = "Kindly Enter Remark..!!";
                return;
            }

            SqlParameter UserID = new SqlParameter();
            UserID.SqlDbType = SqlDbType.VarChar;
            UserID.Value = Convert.ToString(((UserInfo.structUSERInfo)(SaveUSERInfo)).UserId);
            UserID.ParameterName = "@UserID";
            sqlCom.Parameters.Add(UserID);

            int RowsEffeted = sqlCom.ExecuteNonQuery();

            if (RowsEffeted > 0)
            {
                lblMessage.Text = "Record Successfully Updated!";
                lblMessage.CssClass = "UpdateMessage";

            }

        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
            lblMessage.CssClass = "ErrorMessage";

        }

    }
    private void Reject_PaymentRequest_By_Account(string strTransactionID, string strAccount_Remark)
    {
        Object SaveUSERInfo = (Object)Session["UserInfo"];

        SqlConnection sqlCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);

        sqlCon.Open();
        SqlCommand sqlCom = new SqlCommand();
        sqlCom.Connection = sqlCon;
        sqlCom.CommandType = CommandType.StoredProcedure;
        sqlCom.CommandText = "CalOnlineTrans_RejectPaymentRequest_By_Account_SP";

        SqlParameter TransactionID = new SqlParameter();
        TransactionID.SqlDbType = SqlDbType.VarChar;
        TransactionID.Value = strTransactionID;
        TransactionID.ParameterName = "@TransactionID";
        sqlCom.Parameters.Add(TransactionID);

        SqlParameter Account_Remark = new SqlParameter();
        Account_Remark.SqlDbType = SqlDbType.VarChar;
        Account_Remark.Value = strAccount_Remark;
        Account_Remark.ParameterName = "@Account_Remark";
        sqlCom.Parameters.Add(Account_Remark);

        SqlParameter UserID = new SqlParameter();
        UserID.SqlDbType = SqlDbType.VarChar;
        UserID.Value = Convert.ToString(((UserInfo.structUSERInfo)(SaveUSERInfo)).UserId);
        UserID.ParameterName = "@UserID";
        sqlCom.Parameters.Add(UserID);

        int RowEffected = 0;
        RowEffected = sqlCom.ExecuteNonQuery();

        if (RowEffected > 0)
        {
            lblMessage.Text = "Select Record Sucessfully Rejected!";
            lblMessage.CssClass = "SuccessMessage";

            grvTransactionInfo.DataSource = null;
            grvTransactionInfo.DataBind();
        }



    }

    private string Get_Selected_PaymentList()
    {
        string strPaymentID = "";

        for (int i = 0; i <= grvTransactionInfo.Rows.Count - 1; i++)
        {
            CheckBox chkSelect = (CheckBox)grvTransactionInfo.Rows[i].FindControl("chkSelect");
            //chkSelect.Attributes.Add("onclick","javascript:checkSelected('"+ chkSelect.ClientID+ "');");

            if (chkSelect.Checked == true)
            {

                strPaymentID = strPaymentID + grvTransactionInfo.Rows[i].Cells[2].Text.ToString().Trim() + "|";
            }

        }
        return strPaymentID;
    }

    public object pStatus { get; set; }

    public void updateTransactionBalance()
    {
        string strTransaction = "";

        for (int i = 0; i <= grvTransactionInfo.Rows.Count - 1; i++)
        {
            GridView grvDetails = (GridView)grvTransactionInfo.Rows[i].FindControl("grvDetails");

            CheckBox chkSelect = (CheckBox)grvTransactionInfo.Rows[i].FindControl("chkSelect");
            TextBox txtRemark = (TextBox)grvTransactionInfo.Rows[i].FindControl("txtRemark");

            if (chkSelect.Checked == true)
            {
                strTransaction = strTransaction + "" + grvTransactionInfo.Rows[i].Cells[2].Text.Trim();
                tranID = grvTransactionInfo.Rows[i].Cells[2].Text.Trim();
                grdRequestType = grvTransactionInfo.Rows[i].Cells[8].Text;
                if (strTransaction.Length > 0)
                {
                    strTransaction = strTransaction.Substring(0, strTransaction.Length - 1);
                    strTransaction = strTransaction + "^";
                }

                Object SaveUSERInfo = (Object)Session["UserInfo"];

                SqlConnection sqlCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);

                sqlCon.Open();
                SqlCommand sqlCom = new SqlCommand();
                sqlCom.Connection = sqlCon;
                sqlCom.CommandType = CommandType.StoredProcedure;
                sqlCom.CommandText = "CalOnlineTrans__AccountRejectTransaction_New_SP";
                sqlCom.CommandTimeout = 0;


                SqlParameter TransactionID = new SqlParameter();
                TransactionID.SqlDbType = SqlDbType.VarChar;
                TransactionID.Value = tranID;
                TransactionID.ParameterName = "@TransId";
                sqlCom.Parameters.Add(TransactionID);

                int intBranchID = 0;
                if (ddlBranchList.SelectedIndex != 0)
                {
                    intBranchID = Convert.ToInt32(ddlBranchList.SelectedItem.Value);
                }
                SqlParameter BranchId = new SqlParameter();
                BranchId.SqlDbType = SqlDbType.Int;
                BranchId.Value = intBranchID;
                BranchId.ParameterName = "@Branchid";
                sqlCom.Parameters.Add(BranchId);

                SqlDataAdapter sqlDA = new SqlDataAdapter();
                sqlDA.SelectCommand = sqlCom;
                DataTable dt = new DataTable();
                sqlDA.Fill(dt);
                sqlCon.Close();


                if (dt.Rows.Count > 0)
                {
                    RejectAmount = Convert.ToDouble(dt.Rows[0]["TotalRequestAmount"]);
                    Bid = Convert.ToInt32(dt.Rows[0]["BranchId"]);
                    cid = Convert.ToInt32(((UserInfo.structUSERInfo)(SaveUSERInfo)).ClientId);
                    ids = tranID.Split('\\');
                    yrMonth = ids[1].ToString();
                    sqlCon.Open();

                    if (getAmount() == 1)
                    {
                        string sql = "UPDATE [CalOnlineTrans_BranchOpeningBalanceInfo_TBL] SET [ClosingBalanceAmount]=@AvlAmt ,[TransactionAmount]=@TransAmt WHERE BranchId=@BranchId and OpeningBalanceYrMonth=@BalYrMonth and RequestType=@RequestType and ClientID=@ClientId";

                        SqlCommand cmd = new SqlCommand(sql, sqlCon);
                        cmd.Parameters.AddWithValue("@AvlAmt", BalanceAmount);
                        cmd.Parameters.AddWithValue("@TransAmt", TransactionAmount);
                        cmd.Parameters.AddWithValue("@BranchId", Bid);
                        cmd.Parameters.AddWithValue("@BalYrMonth", yrMonth);
                        cmd.Parameters.AddWithValue("@RequestType", ReqType);
                        cmd.Parameters.AddWithValue("@ClientId", cid);
                        cmd.ExecuteNonQuery();
                        sqlCon.Close();
                    }
                }
            }
        }
    }

    public int getAmount()
    {
        Object SaveUSERInfo = (Object)Session["UserInfo"];

        SqlConnection sqlCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);

        sqlCon.Open();
        SqlCommand sqlCom = new SqlCommand();
        sqlCom.Connection = sqlCon;
        sqlCom.CommandType = CommandType.StoredProcedure;
        sqlCom.CommandText = "CalOnlineTrans_Get_OpeningBalanceMonthWise_New_SP";

        SqlParameter BranchID = new SqlParameter();
        BranchID.SqlDbType = SqlDbType.Int;
        BranchID.Value = Convert.ToInt32(((UserInfo.structUSERInfo)(SaveUSERInfo)).BranchId);//pBranchId;
        BranchID.ParameterName = "@BranchID";
        sqlCom.Parameters.Add(BranchID);

        SqlParameter YrMonth = new SqlParameter();
        YrMonth.SqlDbType = SqlDbType.VarChar;
        YrMonth.Value = yrMonth;
        YrMonth.ParameterName = "@YrMonth";
        sqlCom.Parameters.Add(YrMonth);

        #region Code By Amrita on 22-Apr-2014 As per Client Requirement
        SqlParameter c_id = new SqlParameter();
        c_id.SqlDbType = SqlDbType.Int;
        c_id.Value = Convert.ToInt32(((UserInfo.structUSERInfo)(SaveUSERInfo)).ClientId);
        c_id.ParameterName = "@ClientId";
        sqlCom.Parameters.Add(c_id);
        #endregion

        if (grdRequestType == "Petty Cash")
        {
            SqlParameter RequestType = new SqlParameter();
            RequestType.SqlDbType = SqlDbType.Int;
            RequestType.Value = 1;
            RequestType.ParameterName = "@ReqType";
            sqlCom.Parameters.Add(RequestType);
            ReqType = 1;
        }
        else
        {
            SqlParameter RequestType = new SqlParameter();
            RequestType.SqlDbType = SqlDbType.Int;
            RequestType.Value = 2;
            RequestType.ParameterName = "@ReqType";
            sqlCom.Parameters.Add(RequestType);
            ReqType = 2;
        }



        SqlDataAdapter sqlDA = new SqlDataAdapter();
        sqlDA.SelectCommand = sqlCom;
        DataTable dt = new DataTable();
        sqlDA.Fill(dt);
        sqlCon.Close();
        if (dt.Rows.Count > 0)
        {
            TransactionAmount = Convert.ToDouble(dt.Rows[0]["TransactionAmount"]) - RejectAmount;
            BalanceAmount = Convert.ToDouble(dt.Rows[0]["ClosingBalanceAmount"]) + RejectAmount;
            return 1;
        }
        else
        {
            return 0;
        }
    }

    public void SendMail(string TransId)
    {
        try
        {
            System.Net.Mail.MailMessage mail = new System.Net.Mail.MailMessage();
            mail.Subject = ddlPaymentType.SelectedItem.Text.Trim() + " Bill Rejected";
            string mailto = "server.support@pamac.com";
            mail.From = new MailAddress("software.support@pamac.com");
            mail.To.Add(mailto);
            string mailbody = ConfigurationManager.AppSettings["BillStatusMailBody"];
            mail.Body = mailbody.Replace("$Transaction_ID$", TransId).Replace("$Payment_Type$", ddlPaymentType.SelectedItem.Text.Trim());


            SmtpClient smtp = new SmtpClient("mail.pamac.com", 587);
            smtp.Credentials = new System.Net.NetworkCredential("software.support@pamac.com", "_ug7rogzH");
            smtp.EnableSsl = false;
            // smtp.UseDefaultCredentials = false;/// Main line :SSL should be false

            smtp.Send(mail);

            // result.Value = "E-mail sent!";
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message);
        }


    }




    public void GetTransectionId()
    {
        if (Label1.Text.Trim() == "")
        {
            foreach (GridViewRow row in grvTransactionInfo.Rows) //Running all lines of grid
            {
                if (row.RowType == DataControlRowType.DataRow)
                {
                    CheckBox chkRow = (row.Cells[0].FindControl("chkSelect") as CheckBox);

                    if (chkRow.Checked)
                    {

                        string transectionId = grvTransactionInfo.Rows[row.RowIndex].Cells[2].Text.Trim();
                        SendMail(transectionId);
                    }
                }
            }
        }

    }

}
