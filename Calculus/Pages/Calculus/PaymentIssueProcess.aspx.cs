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


public partial class Pages_Calculus_PaymentIssueProcess : System.Web.UI.Page
{
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

        if (ddlPaymentType.SelectedValue == "1")
        {
            sqlCom.CommandText = "CalOnlineTrans_Get_AcceptedPaymentRequest_ViewNew_New_SP";
        }
        else 
        {
            sqlCom.CommandText = "CalOnlineTrans_GetAcceptedPaymentRequestView_New_SP";
       
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
        PayoutDate.SqlDbType = SqlDbType.VarChar ;
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

        #region Code By Amrita on 22-Apr-2014 As per Client Requirement
        SqlParameter ClientId = new SqlParameter();
        ClientId.SqlDbType = SqlDbType.Int;
        ClientId.Value = Convert.ToInt32(((UserInfo.structUSERInfo)(SaveUSERInfo)).ClientId);
        ClientId.ParameterName = "@ClientId";
        sqlCom.Parameters.Add(ClientId);
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
            
            GridView grvDetails = (GridView)e.Row.FindControl("grvDetails");
            grvDetails.DataSource = Get_TransactionDetails(e.Row.Cells[2].Text);
            grvDetails.DataBind();



        }
    }

    private DataTable Get_TransactionDetails(string strTransactionID)
    {

        SqlConnection sqlCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);

        sqlCon.Open();
        SqlCommand sqlCom = new SqlCommand();
        sqlCom.Connection = sqlCon;
        sqlCom.CommandType = CommandType.StoredProcedure;
        sqlCom.CommandText = "CalOnlineTrans_GetTransactionDetailsForApprove__SP";

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

    protected void btnAddPayment_Click(object sender, EventArgs e)
    {
        hdnTransID.Value = Get_Selected_PaymentList();

        if (hdnTransID.Value != "")
        {
            Session["Param"] = hdnTransID.Value;

            if (hdnTransID.Value.Contains("VPM"))
            {
                
                Response.Redirect("MakeBranchPayment.aspx?TID=?", true);
            }
            else if (hdnTransID.Value.Contains("UPM"))
            {

                Response.Redirect("MakeBranchPayment.aspx?TID=?", true);
            }
            else if (hdnTransID.Value.Contains("PCV"))
            {
               
                Response.Redirect("BranchPettyCashPaymentAdd.aspx?TID=?" + hdnTransID.Value, true);
            }
            else if (hdnTransID.Value.Contains("OTP"))
            {
                Response.Redirect("OtherThanPettyCash_AmountTransfer.aspx?TID=" + hdnTransID.Value, true);

            }
            else if (hdnTransID.Value.Contains("EPM"))
            {
                Response.Redirect("MakeBranchPayment.aspx?TID=?", true);

                //Response.Redirect("OtherThanPettyCash_AmountTransfer.aspx?TID=" + hdnTransID.Value, true);

            }
        }
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
        for (int i=0;i<=grvTransactionInfo.Rows.Count-1;i++)
        {
            
            string sTrans = "";

            CheckBox chkSelect = (CheckBox)grvTransactionInfo.Rows[i].FindControl("chkSelect");
            TextBox txtRemark = (TextBox)grvTransactionInfo.Rows[i].FindControl("txtRemark");
            
            if (chkSelect.Checked == true)
            {
                if (txtRemark.Text != "")
                {
                    sTrans = grvTransactionInfo.Rows[i].Cells[2].Text.Trim();

                    Reject_PaymentRequest_By_Account(sTrans, txtRemark.Text.Trim());
                }
                else 
                {
                    lblMessage.Text = "Please enter Remark!";
                    lblMessage.CssClass = "ErrorMessage";
                    txtRemark.Focus();
                }
            }

        }

        Get_TransactionList_For_Process();
    }

    private void Reject_PaymentRequest_By_Account(string strTransactionID, string strAccount_Remark)
    {
        Object SaveUSERInfo = (Object)Session["UserInfo"];
           
        SqlConnection sqlCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);

        sqlCon.Open();
        SqlCommand sqlCom = new SqlCommand();
        sqlCom.Connection = sqlCon;
        sqlCom.CommandType = CommandType.StoredProcedure;
        sqlCom.CommandText = "CalOnlineTrans_RejectPaymentRequestByAccount_New_SP";  

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
        RowEffected=sqlCom.ExecuteNonQuery();

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
            CheckBox chkSelect = (CheckBox) grvTransactionInfo.Rows[i].FindControl("chkSelect"); 
            //chkSelect.Attributes.Add("onclick","javascript:checkSelected('"+ chkSelect.ClientID+ "');");

            if (chkSelect.Checked == true)
            {

                strPaymentID = strPaymentID+ grvTransactionInfo.Rows[i].Cells[2].Text.ToString().Trim() + "|"; 
            }
            
        }
            return strPaymentID;
    }
}
