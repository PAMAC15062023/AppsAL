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
//using Microsoft.Reporting.WebForms;


public partial class Pages_ChequePrinting_Report : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (Session["UserInfo"] == null)
            {
                Response.Redirect("~/Pages/InvalidRequest.aspx");

            }

            if (!IsPostBack)
            {
                Get_BankInfo();
                Get_BranchId();
                Register_Validation();
              
            }
        }
        catch (Exception ex)
        {
            lblMessage.Visible = true;
            lblMessage.Text = ex.Message;
            lblMessage.CssClass = "ErrorMessage";

        }

        string StrScript = "<script language='javascript'> javascript:Page_load_validation(); </script>";
        Page.RegisterStartupScript("OnLoad_1", StrScript);
    
    }

    private void Register_Validation()
    {
        btnSubmit.Attributes.Add("onclick", "javascript:return ValidationAllField();");
        btnPrintCheque.Attributes.Add("onclick", "javascript:return Validate_PrintCheques();");
        txtChkSeriesStart.Attributes.Add("onblur", "javascript:Validation_Count();");
        txtChkSeriesEnd.Attributes.Add("onblur", "javascript:Validation_Count();");

        btnUpdateStatus.Attributes.Add("onclick", "javascript:return Validation_UpdateStatus();");
    }

    private void Get_BankBranchInfo(int intBankID)
    {
        SqlConnection sqlCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);

        sqlCon.Open();
        SqlCommand sqlCom = new SqlCommand();
        sqlCom.Connection = sqlCon;
        sqlCom.CommandType = CommandType.StoredProcedure;
        sqlCom.CommandText = "CalOnlineTrans_GetBranchBankDetails_SP";

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
        ddlBankBranchList.DataValueField = "BrnID";
        ddlBankBranchList.DataBind();
        
        ddlBankBranchList.Items.Insert(0, "-Select-");
        ddlBankBranchList.SelectedIndex = 0;
    }

    private void Get_BranchId()
    {
        Object SaveUSERInfo = (Object)Session["UserInfo"];
        SqlConnection sqlCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);

        sqlCon.Open();
        SqlCommand sqlCom = new SqlCommand();
        sqlCom.Connection = sqlCon;
        sqlCom.CommandType = CommandType.StoredProcedure;
        sqlCom.CommandText = "CalOnlineTrans_Get_AllBranchList_For_Auth_SP";

        SqlParameter UserID = new SqlParameter();
        UserID.SqlDbType = SqlDbType.VarChar;
        UserID.Value = (((UserInfo.structUSERInfo)(SaveUSERInfo)).UserId);
        UserID.ParameterName = "@UserID";
        sqlCom.Parameters.Add(UserID);

        SqlDataAdapter sqlDA = new SqlDataAdapter();
        sqlDA.SelectCommand = sqlCom;
        DataTable dt = new DataTable();
        sqlDA.Fill(dt);
        sqlCon.Close();

        ddlBranchName.DataSource = dt;
        ddlBranchName.DataTextField = "BranchName";
        ddlBranchName.DataValueField = "BranchId";
        ddlBranchName.DataBind();
        
        ddlBranchName.Items.Insert(0, "-Select-");
        ddlBranchName.SelectedIndex = 0;
    }

    protected void ddlBankList_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlBankList.SelectedIndex != 0)
        {
           
            
            string strBankID = ddlBankList.SelectedItem.Value;
            string[] arrBankID = strBankID.Split('|');
            hdnPrintReport.Value = arrBankID[1].ToString();
            Get_BankBranchInfo(Convert.ToInt32(arrBankID[0]));
            ddlBankBranchList.Focus();
           

        }
        else
        {
            ddlBankBranchList.Items.Insert(0, "-Select-");
            ddlBankBranchList.SelectedIndex = 0;
            hdnPrintReport.Value ="";
        }

    }

    private void Get_BankInfo()
    {
        SqlConnection sqlCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);

        sqlCon.Open();
        SqlCommand sqlCom = new SqlCommand();
        sqlCom.Connection = sqlCon;
        sqlCom.CommandType = CommandType.StoredProcedure;
        sqlCom.CommandText = "CalOnlineTrans_GetBankInfoChequeDetails_SP";

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

            ddlBankList.Items.Insert(0, "-Select-");
            ddlBankList.SelectedIndex = 0;
 
            
        }

    }
       
    protected void btnPrintCheque_Click(object sender, EventArgs e)
    {
         //not calling -- Application postback event is disbled 
            for (int i = 0; i <= Grid_View_Cheque.Rows.Count - 1; i++)
            {

                string pCrossChequeValue, pChequeIssueTo, pChequeDate, pAmountInWord, pChequeAmount,pPaymentID, pChequeNo;

                CheckBox chkSelect = (CheckBox)Grid_View_Cheque.Rows[i].Cells[0].FindControl("chkSelect");

                if (chkSelect.Checked == true)
                {
                    string strJScript = "";
                    pPaymentID= Grid_View_Cheque.Rows[i].Cells[1].Text.Trim();
                    pCrossChequeValue = Grid_View_Cheque.Rows[i].Cells[13].Text.Trim();
                    pChequeIssueTo = Grid_View_Cheque.Rows[i].Cells[8].Text.Trim();
                    pChequeDate = Grid_View_Cheque.Rows[i].Cells[10].Text.Trim();
                    pAmountInWord = Grid_View_Cheque.Rows[i].Cells[7].Text.Trim();
                    pChequeAmount = Grid_View_Cheque.Rows[i].Cells[6].Text.Trim();
                    pChequeNo=Get_ChequeNo_Sequence(i);

                    strJScript = "<script language='javascript'>    "; // showModalDialog
                    strJScript = strJScript + "  window.open('ReportViewer.aspx?1=" + pCrossChequeValue + "&2=" + pChequeIssueTo + "&3=" + pChequeDate + "&4=" + pAmountInWord + "&5=" + pChequeAmount + "&6=" + hdnPrintReport.Value.Trim() + "', '_blank', 'height=350,width=700,status=yes,resizable=no');";
                    strJScript = strJScript + "</script>";
                    strJScript = strJScript + "<script language='javascript'>";
                    strJScript = strJScript + " var answer=confirm('Cheque Printed correctly'); if (answer){ Confirm_ChequePrint('" + pPaymentID + "','" + pChequeNo + "','" + pChequeAmount + "','" + pChequeIssueTo + "','True');}  ";
                    strJScript =strJScript+  "</script>";
                    Page.RegisterClientScriptBlock("JavaScriptFile_1", strJScript);

                }

        }
        
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Pages/Menu.aspx", true);
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        hdnPrintChequeStatus.Value = "";
        hdnBankID.Value = "";
        hdnBankBranchID.Value = "";


        Get_Data_For_Printing();

        string strBankID = ddlBankList.SelectedItem.Value;
        string[] arrBankID = strBankID.Split('|');
        hdnBankID.Value = arrBankID[0];
        hdnBankBranchID.Value = ddlBankBranchList.SelectedItem.Value ;
          
         
    }

    private void Get_Data_For_Printing()
    {
        Object SaveUSERInfo = (Object)Session["UserInfo"];

        SqlConnection sqlCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);

        sqlCon.Open();
        SqlCommand sqlCom = new SqlCommand();
        sqlCom.Connection = sqlCon;
        sqlCom.CommandType = CommandType.StoredProcedure;
        sqlCom.CommandText = "CalOnlineTrans_GetChequeForPrintingNew_SP";

        int intBranchID = 0;
        if (ddlBranchName.SelectedIndex != 0)
        {
            intBranchID = Convert.ToInt32(ddlBranchName.SelectedItem.Value);
        }

        SqlParameter BranchId = new SqlParameter();
        BranchId.SqlDbType = SqlDbType.Int;
        BranchId.Value = intBranchID;
        BranchId.ParameterName = "@BranchID";
        sqlCom.Parameters.Add(BranchId);

        SqlParameter PaymentDateFrom = new SqlParameter();
        PaymentDateFrom.SqlDbType = SqlDbType.VarChar;
        PaymentDateFrom.Value = txtPaymentFrom.Text.Trim();
        PaymentDateFrom.ParameterName = "@PaymentDateFrom";
        sqlCom.Parameters.Add(PaymentDateFrom);

        SqlParameter PaymentDateTo = new SqlParameter();
        PaymentDateTo.SqlDbType = SqlDbType.VarChar;
        PaymentDateTo.Value = txtPaymentTo.Text.Trim();
        PaymentDateTo.ParameterName = "@PaymentDateTo";
        sqlCom.Parameters.Add(PaymentDateTo);

        int intBankID = 0;
        if (ddlBankList.SelectedIndex != 0)
        {
            string strBankID = ddlBankList.SelectedItem.Value;
            string[] arrBankID = strBankID.Split('|');
            intBankID = Convert.ToInt32(arrBankID[0]);

        }
        SqlParameter BankID = new SqlParameter();
        BankID.SqlDbType = SqlDbType.Int;
        BankID.Value = intBankID;
        BankID.ParameterName = "@BankID";
        sqlCom.Parameters.Add(BankID);

        int intBankBranchID = 0;
        if (ddlBankBranchList.SelectedIndex != 0)
        {
            intBankBranchID = Convert.ToInt32(ddlBankBranchList.SelectedItem.Value);
        }
        SqlParameter BankBranchID = new SqlParameter();
        BankBranchID.SqlDbType = SqlDbType.Int;
        BankBranchID.Value = intBankBranchID;
        BankBranchID.ParameterName = "@BankBranchID";
        sqlCom.Parameters.Add(BankBranchID);


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
            Grid_View_Cheque.DataSource = dt;
            Grid_View_Cheque.DataBind();
            lblMessage.Text = "Total Records Found " + dt.Rows.Count;
            lblMessage.CssClass = "UpdateMessage";
             
        }
        else
        {
            Grid_View_Cheque.DataSource = null;
            Grid_View_Cheque.DataBind();
            lblMessage.Text = "No Records found!";
            lblMessage.CssClass = "ErrorMessage";
        }
    }

    protected void btnClear_Click(object sender, EventArgs e)
    {
        ClearAllFields();
    }

    protected void ClearAllFields()
    {
        ddlBankList.SelectedIndex=0;
        ddlBankBranchList.SelectedIndex =0;
        ddlBranchName.SelectedIndex=0;
        txtPaymentFrom.Text ="";
        txtPaymentTo.Text = "";
        hdnBankBranchID.Value = "";
        hdnBankID.Value = "";
        hdnPrintChequeStatus.Value = "";
        hdnPrintReport.Value = "";
        ReportServerPath.Value = "";
        Grid_View_Cheque.DataSource = null;
        Grid_View_Cheque.DataBind();
    }

    private void Generate_ChequePrinting_Report(string pCrossChequeValue, string pChequeIssueTo, string pChequeDate, string pAmountInWord, string pChequeAmount)
    {
        string strURLPath = Convert.ToString(ConfigurationSettings.AppSettings["ReportServer"]);  
        string strJScript = "";
        //string ReportFormat = "";        
        System.Net.CredentialCache.DefaultNetworkCredentials.UserName = "avinash";
        System.Net.CredentialCache.DefaultNetworkCredentials.Password = "$Pms$Admin$";  
        //ReportFormat = ddl_ReportType.SelectedItem.Value; 
        strJScript = "<script language='javascript'>window.open('" + strURLPath + "/Calculus/ScbCheque_Report&rs:Command=Render&rs:format=pdf&rc:Parameters=&CrossChequeValue=" + pCrossChequeValue + "&ChequeIssueTo=" + pChequeIssueTo + "&ChequeDate=" + pChequeDate + "&AmountInWord=" + pAmountInWord + "&ChequeAmount=" +  pChequeAmount + "','','addressbar=no;statusbar=no;toolbar=no;menubar=no;scrollbar=both;');</script>";         
        Page.RegisterClientScriptBlock("JavaScriptFile_1", strJScript);
        
          
         
    }
      
    private string Get_ChequeNo_Sequence(int currentSeries)
    {
        int count=0;
        string ChequeSeries = "";
        for (int chequeNo = Convert.ToInt32(txtChkSeriesStart.Text.Trim()); chequeNo <= Convert.ToInt32(txtChkSeriesEnd.Text.Trim()); chequeNo++)
        {
            if (count == currentSeries)
            {
                ChequeSeries = chequeNo.ToString();
            }
            break;
        }

        return ChequeSeries;
    }

    protected void btnUpdateStatus_Click(object sender, EventArgs e)
    {
        try
        {
            if (hdnPrintChequeStatus.Value != "")
            {
                Insert_Cheque_UpdateDetails();
                Get_Data_For_Printing();
                txtChkSeriesStart.Text = "";
                txtChkSeriesEnd.Text = "";
            }
        }
        catch (Exception ex)
        {

            lblMessage.Visible = true;
            lblMessage.Text = ex.Message;
            lblMessage.CssClass = "ErrorMessage";
        }
    }

    private void Insert_Cheque_UpdateDetails()
    {

        try
        {
            Object SaveUSERInfo = (Object)Session["UserInfo"];

            SqlConnection sqlCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);

            sqlCon.Open();
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.Connection = sqlCon;
            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCmd.CommandText = "CalOnlineTrans_InsertChequePrintedUpdate_New_SP";


            SqlParameter UserID = new SqlParameter();
            UserID.SqlDbType = SqlDbType.VarChar;
            UserID.Value = (((UserInfo.structUSERInfo)(SaveUSERInfo)).UserId);
            UserID.ParameterName = "@UserID";
            sqlCmd.Parameters.Add(UserID);

            SqlParameter ChequePrintDetails = new SqlParameter();
            ChequePrintDetails.SqlDbType = SqlDbType.VarChar;
            ChequePrintDetails.Value = hdnPrintChequeStatus.Value.Trim();
            ChequePrintDetails.ParameterName = "@ChequePrintDetails";
            sqlCmd.Parameters.Add(ChequePrintDetails);

            #region Code By Amrita on 22-Apr-2014 As per Client Requirement
            SqlParameter ClientId = new SqlParameter();
            ClientId.SqlDbType = SqlDbType.Int;
            ClientId.Value = Convert.ToInt32(((UserInfo.structUSERInfo)(SaveUSERInfo)).ClientId);
            ClientId.ParameterName = "@ClientId";
            sqlCmd.Parameters.Add(ClientId);
            #endregion


            int SqlRow = 0;
            SqlRow = sqlCmd.ExecuteNonQuery();

            if (SqlRow > 0)
            {
                lblMessage.Text = "Cheque Details Update Successfully!";
                lblMessage.CssClass = "UpdateMessage";
                lblMessage.Visible = true;
            }
        }
        catch (Exception ex)
        {

            lblMessage.Visible = true;
            lblMessage.Text = ex.Message;
            lblMessage.CssClass = "ErrorMessage";
        }
    }

    protected void Grid_View_Cheque_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
             

            CheckBox chkSelect = (CheckBox)e.Row.FindControl("chkSelect");
            chkSelect.Attributes.Add("onclick", "javascript:ChequeCountDisplay();");
             
             
        }
    }
}
