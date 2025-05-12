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
        Get_PaymentListFor_View();
    }
    private void Get_PaymentListFor_View()
    {

        Object SaveUSERInfo = (Object)Session["UserInfo"];

        SqlConnection sqlCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);

        sqlCon.Open();
        SqlCommand sqlCom = new SqlCommand();
        sqlCom.Connection = sqlCon;
        sqlCom.CommandType = CommandType.StoredProcedure;
        sqlCom.CommandText = "CalOnlineTrans_GetPaymentListFor_View_New_SP";


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

        SqlParameter PaymentID = new SqlParameter();
        PaymentID.SqlDbType = SqlDbType.VarChar;
        PaymentID.Value = txtPaymentID.Text.Trim();
        PaymentID.ParameterName = "@PaymentID";
        sqlCom.Parameters.Add(PaymentID);

        decimal pAmount = 0;
        if (txtPaymentAmt.Text.Trim() != "")
        {
            pAmount = Convert.ToDecimal(txtPaymentAmt.Text.Trim());
        }

        SqlParameter PaymentAmount = new SqlParameter();
        PaymentAmount.SqlDbType = SqlDbType.Decimal;
        PaymentAmount.Value = pAmount;
        PaymentAmount.ParameterName = "@PaymentAmount";
        sqlCom.Parameters.Add(PaymentAmount);

        SqlParameter PaymentDate = new SqlParameter();
        PaymentDate.SqlDbType = SqlDbType.VarChar;
        PaymentDate.Value = txtPaymentDate.Text.Trim();
        PaymentDate.ParameterName = "@PaymentDate";
        sqlCom.Parameters.Add(PaymentDate);

        SqlParameter ChequeDate = new SqlParameter();
        ChequeDate.SqlDbType = SqlDbType.VarChar;
        ChequeDate.Value = txtChequeDate.Text.Trim();
        ChequeDate.ParameterName = "@ChequeDate";
        sqlCom.Parameters.Add(ChequeDate);

        decimal pCheuqeAmount = 0;
        if (txtChequeAmount.Text.Trim() != "")
        {
            pCheuqeAmount = Convert.ToDecimal(txtChequeAmount.Text.Trim());
        }

        SqlParameter ChequeAmount = new SqlParameter();
        ChequeAmount.SqlDbType = SqlDbType.Decimal;
        ChequeAmount.Value = pCheuqeAmount;
        ChequeAmount.ParameterName = "@ChequeAmount";
        sqlCom.Parameters.Add(ChequeAmount);


        SqlParameter CheuqeNo = new SqlParameter();
        CheuqeNo.SqlDbType = SqlDbType.VarChar;
        CheuqeNo.Value = txtCheuqeNo.Text.Trim();
        CheuqeNo.ParameterName = "@CheuqeNo";
        sqlCom.Parameters.Add(CheuqeNo);

        SqlParameter TransactionID = new SqlParameter();
        TransactionID.SqlDbType = SqlDbType.VarChar;
        TransactionID.Value = txtTransactionID.Text.Trim();
        TransactionID.ParameterName = "@TransactionID";
        sqlCom.Parameters.Add(TransactionID);
           
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

            CheckBox chkSelect = (CheckBox)e.Row.FindControl("chkSelect");
            chkSelect.Attributes.Add("onclick", "javascript:checkSelected('" + chkSelect.ClientID + "');");

            GridView grvDetails = (GridView)e.Row.FindControl("grvDetails");
            grvDetails.DataSource = Get_PaymentDetails(e.Row.Cells[2].Text);
            grvDetails.DataBind();


        }
    }
    private DataTable Get_PaymentDetails(string strPaymentID)
    {

        SqlConnection sqlCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);

        sqlCon.Open();
        SqlCommand sqlCom = new SqlCommand();
        sqlCom.Connection = sqlCon;
        sqlCom.CommandType = CommandType.StoredProcedure;
        sqlCom.CommandText = "CalOnlineTrans_GetPaymentDetails_SP";

        SqlParameter PaymentID = new SqlParameter();
        PaymentID.SqlDbType = SqlDbType.VarChar;
        PaymentID.Value = strPaymentID;
        PaymentID.ParameterName = "@PaymentID";
        sqlCom.Parameters.Add(PaymentID);

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
            sqlCom.CommandText = "CalOnlineTrans_Get_All_Branch_List_SP";

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
        btnAddPayment.Attributes.Add("onclick", "javascript:return Get_SelectedTransactionID(1);");
        btnView.Attributes.Add("onclick", "javascript:return Get_SelectedTransactionID(2);");
    }
    protected void btnAddPayment_Click(object sender, EventArgs e)
    {
        Session["Param"] = hdnTransID.Value;

        if (hdnTransID.Value.Contains("VPM"))
        {
            Response.Redirect("MakeBranchPayment.aspx?TID=" + hdnTransID.Value, true);
        }
        else if (hdnTransID.Value.Contains("PCV"))
        {
            Response.Redirect("BranchPettyCashPaymentAdd.aspx?TID=" + hdnTransID.Value, true);
        }         
        else if (hdnTransID.Value.Contains("OTP"))
        {
               Response.Redirect("OtherThanPettyCash_AmountTransfer.aspx?TID=" + hdnTransID.Value, true);
        
        }

        //Response.Redirect("MakeBranchPayment.aspx?TID="+ hdnTransID.Value , true);
    }
    protected void btnView_Click(object sender, EventArgs e)
    {
        Session["Param"] = hdnTransID.Value;
         if (hdnTransID.Value.Contains("VPM"))
        {
            Response.Redirect("MakeBranchPayment.aspx?Vw=1&TID=" + hdnTransID.Value, true);
        }
        else if (hdnTransID.Value.Contains("PCV"))
        {
            Response.Redirect("BranchPettyCashPaymentAdd.aspx?Vw=1&TID=" + hdnTransID.Value, true);
        }
        else if (hdnTransID.Value.Contains("OTP"))
        {
            Response.Redirect("OtherThanPettyCash_AmountTransfer.aspx?Vw=1&TID=" + hdnTransID.Value, true);

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
}


