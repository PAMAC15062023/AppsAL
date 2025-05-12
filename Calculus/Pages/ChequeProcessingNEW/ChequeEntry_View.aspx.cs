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

public partial class Pages_ChequeProcessingNEW_ChequeEntry_View : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserInfo"] == null)
        {
            Response.Redirect("~/Pages/InvalidRequest.aspx");
        }
        if (!IsPostBack)
        { 
            
        }
        RegisterControls_WithJavascript();
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        Get_ChequeDetails_For_View();
    }
    private void Get_ChequeDetails_For_View()
    {
        SqlConnection sqlcon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);
        try
        {
            Object SaveUSERInfo = (Object)Session["UserInfo"];

         
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlcon;
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.CommandText = "Get_ChequeDetails_For_View";
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

            SqlParameter BatchDate = new SqlParameter();
            BatchDate.SqlDbType = SqlDbType.VarChar;
            BatchDate.Value = txtBatchDate.Text.Trim();
            BatchDate.ParameterName = "@BatchDate";
            sqlcmd.Parameters.Add(BatchDate);

            SqlParameter PickupDate = new SqlParameter();
            PickupDate.SqlDbType = SqlDbType.VarChar;
            PickupDate.Value = txtPickupdate.Text.Trim();
            PickupDate.ParameterName = "@PickupDate";
            sqlcmd.Parameters.Add(PickupDate);

            SqlParameter ChequeNo = new SqlParameter();
            ChequeNo.SqlDbType = SqlDbType.VarChar;
            ChequeNo.Value = txtChequeNo.Text.Trim();
            ChequeNo.ParameterName = "@ChequeNo";
            sqlcmd.Parameters.Add(ChequeNo);

            SqlParameter ChequeDate = new SqlParameter();
            ChequeDate.SqlDbType = SqlDbType.VarChar;
            ChequeDate.Value = txtChequeDate.Text.Trim();
            ChequeDate.ParameterName = "@ChequeDate";
            sqlcmd.Parameters.Add(ChequeDate);

            decimal deciChequeAmount=0;
            if (txtChequeAmount.Text != "")
            {
                deciChequeAmount = Convert.ToDecimal(txtChequeAmount.Text.Trim());
            }

            SqlParameter ChequeAmount = new SqlParameter();
            ChequeAmount.SqlDbType = SqlDbType.Decimal;
            ChequeAmount.Value = deciChequeAmount;
            ChequeAmount.ParameterName = "@ChequeAmount";
            sqlcmd.Parameters.Add(ChequeAmount);

            SqlParameter CardNo = new SqlParameter();
            CardNo.SqlDbType = SqlDbType.VarChar;
            CardNo.Value = txtCardNo.Text.Trim();
            CardNo.ParameterName = "@CardNo";
            sqlcmd.Parameters.Add(CardNo);

            SqlParameter MICRCode = new SqlParameter();
            MICRCode.SqlDbType = SqlDbType.VarChar;
            MICRCode.Value = txtMICRCode.Text.Trim();
            MICRCode.ParameterName = "@MICRCode";
            sqlcmd.Parameters.Add(MICRCode);

            SqlParameter AccountNo = new SqlParameter();
            AccountNo.SqlDbType = SqlDbType.VarChar;
            AccountNo.Value = txtAccountNo.Text.Trim();
            AccountNo.ParameterName = "@AccountNo";
            sqlcmd.Parameters.Add(AccountNo);

            SqlParameter BankName = new SqlParameter();
            BankName.SqlDbType = SqlDbType.VarChar;
            BankName.Value = txtBankName.Text.Trim();
            BankName.ParameterName = "@BankName";
            sqlcmd.Parameters.Add(BankName);

            SqlParameter BranchName = new SqlParameter();
            BranchName.SqlDbType = SqlDbType.VarChar;
            BranchName.Value = txtBranchName.Text.Trim();
            BranchName.ParameterName = "@BranchName";
            sqlcmd.Parameters.Add(BranchName);

            SqlParameter BranchCity = new SqlParameter();
            BranchCity.SqlDbType = SqlDbType.VarChar;
            BranchCity.Value = txtBranchCity.Text.Trim();
            BranchCity.ParameterName = "@BranchCity";
            sqlcmd.Parameters.Add(BranchCity);

            SqlParameter ContactNo = new SqlParameter();
            ContactNo.SqlDbType = SqlDbType.VarChar;
            ContactNo.Value = txtContactNo.Text.Trim();
            ContactNo.ParameterName = "@ContactNo";
            sqlcmd.Parameters.Add(ContactNo);

            SqlParameter TransactionCode = new SqlParameter();
            TransactionCode.SqlDbType = SqlDbType.VarChar;
            TransactionCode.Value = txtTransactionCode.Text.Trim();
            TransactionCode.ParameterName = "@TransactionCode";
            sqlcmd.Parameters.Add(TransactionCode);

            SqlParameter ReceiptNo = new SqlParameter();
            ReceiptNo.SqlDbType = SqlDbType.VarChar;
            ReceiptNo.Value = txtReceiptNo.Text.Trim();
            ReceiptNo.ParameterName = "@ReceiptNo";
            sqlcmd.Parameters.Add(ReceiptNo);

            sqlcon.Open();

            SqlDataAdapter sqlda = new SqlDataAdapter();
            sqlda.SelectCommand = sqlcmd;

            DataTable dt = new DataTable();
            sqlda.Fill(dt);

            sqlcon.Close();

            if (dt.Rows.Count > 0)
            {
                grv_ChequeEntryList.DataSource = dt;
                grv_ChequeEntryList.DataBind();

                lblMessage.Text = "Total Records found " +dt.Rows.Count;
                lblMessage.CssClass = "SuccessMessage";
            }
            else
            {
                grv_ChequeEntryList.DataSource = null ;
                grv_ChequeEntryList.DataBind();

                lblMessage.Text = "Records not found!";
                lblMessage.CssClass = "ErrorMessage";
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
            if (sqlcon.State == ConnectionState.Open)
            {
                sqlcon.Close();
            }
        }
    }
        
    private void RegisterControls_WithJavascript()
    {
        //btnModify.Attributes.Add("onclick", "javascript:return Get_SelectedTransactionID(1);");
        btnView.Attributes.Add("onclick", "javascript:return Get_SelectedTransactionID(2);");
    }

    protected void grv_ChequeEntryList_RowDataBound(object sender, GridViewRowEventArgs e)
    { 
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            CheckBox chkSelect = (CheckBox)e.Row.FindControl("chkSelect");
            chkSelect.Attributes.Add("onclick", "javascript:checkSelected('" + chkSelect.ClientID + "');");
        }
    }

    protected void btnModify_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Pages/ChequeProcessingNEW/ChequeDataEntry.aspx?BN=" + hdnBatchNo.Value.Trim() + "&TID=" + hdnTransactionID.Value, true);
    }
    protected void btnView_Click(object sender, EventArgs e)
    {

        Response.Redirect("~/Pages/ChequeProcessingNEW/ModifyChequeEntry.aspx?TID=" + hdnTransactionID.Value + "&Vw=1", true);

        //    Response.Redirect("~/Pages/ChequeProcessingNEW/ChequeDataEntry.aspx?BN="+hdnBatchNo.Value.Trim()+"&TID="+hdnTransactionID.Value +"&Vw=1", true);
        //
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Pages/Menu.aspx", true);     
    }
}
