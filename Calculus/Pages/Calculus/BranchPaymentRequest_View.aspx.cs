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

public partial class Pages_Calculus_BranchPaymentRequest_View : System.Web.UI.Page
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
                
                Object SaveUSERInfo = (Object)Session["UserInfo"];
                
                if (((UserInfo.structUSERInfo)(SaveUSERInfo)).GroupName.Contains("Admin"))
                {
                     Get_AllBranchList_For_Auth();
                     ddlBranchList.Enabled = true;
                }
                else
                {
                     Get_BranchId();
                     ddlBranchList.SelectedValue = Convert.ToString(((UserInfo.structUSERInfo)(SaveUSERInfo)).BranchId);                                 
                     ddlBranchList.Enabled = false;
                }              
            }
            RegisterControls_WithJavascript();
        } 
        catch (Exception ex)
        {
            lblMessage.Visible = true;
            lblMessage.Text = ex.Message;
            lblMessage.CssClass = "ErrorMessage";
        }
    }
    private void Get_AllBranchList_For_Auth()
    {
        try
        {
            Object SaveUSERInfo = (Object)Session["UserInfo"];

            SqlConnection sqlcon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);

            sqlcon.Open();
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlcon;
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.CommandText = "Get_AllBranchList_For_Auth";

            SqlParameter UserID = new SqlParameter();
            UserID.SqlDbType = SqlDbType.VarChar;
            UserID.Value = Convert.ToString(((UserInfo.structUSERInfo)(SaveUSERInfo)).UserId);
            UserID.ParameterName = "@UserID";
            sqlcmd.Parameters.Add(UserID);

            SqlDataAdapter sqlda = new SqlDataAdapter();
            sqlda.SelectCommand = sqlcmd;
            DataTable dt = new DataTable();
            sqlda.Fill(dt);
            sqlcon.Close();

            ddlBranchList.DataTextField = "BranchName";
            ddlBranchList.DataValueField = "BranchId";
            ddlBranchList.DataSource = dt;
            ddlBranchList.DataBind();

            ddlBranchList.Items.Insert(0, "-Select-");
            ddlBranchList.SelectedIndex = 0;

        }
        catch (Exception ex)
        {
            lblMessage.Visible = true;
            lblMessage.Text = ex.Message;
            lblMessage.CssClass = "ErrorMessage";

        }

    }
    private void Get_BranchId()
    {
        try
        {
            SqlConnection sqlcon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);

            sqlcon.Open();
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlcon;
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.CommandText = "Get_AllBranchList";
            SqlDataAdapter sqlda = new SqlDataAdapter();
            sqlda.SelectCommand = sqlcmd;
            DataTable dt = new DataTable();
            sqlda.Fill(dt);
            sqlcon.Close();

            ddlBranchList.DataTextField = "BranchName";
            ddlBranchList.DataValueField = "BranchId";
            ddlBranchList.DataSource = dt;
            ddlBranchList.DataBind();

            ddlBranchList.Items.Insert(0, "-Select-");
            ddlBranchList.SelectedIndex = 0;

        }
        catch (Exception ex)
        {
            lblMessage.Visible = true;
            lblMessage.Text = ex.Message;
            lblMessage.CssClass = "ErrorMessage";

        }

    }
    protected void btnAddNew_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/pages/calculus/BranchPaymentRequest.aspx", true);
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        Get_TransactionList_For_Process();
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/pages/menu.aspx", true);
  
    }
    protected void grv_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            CheckBox chkSelect = (CheckBox)e.Row.FindControl("chkSelect");
            chkSelect.Attributes.Add("onclick", "javascript:checkSelected('" + chkSelect.ClientID + "');");

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
    private void Get_TransactionList_For_Process()
    {

        Object SaveUSERInfo = (Object)Session["UserInfo"];

        SqlConnection sqlCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);

        sqlCon.Open();
        SqlCommand sqlCom = new SqlCommand();
        sqlCom.Connection = sqlCon;
        sqlCom.CommandType = CommandType.StoredProcedure;
        sqlCom.CommandText = "CalOnlineTrans_GetRecordsForPyamentProcessViewNew_SP";

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
        RequestDate.Value = txtRequestDate.Text.Trim();
        RequestDate.ParameterName = "@RequestDate";
        sqlCom.Parameters.Add(RequestDate);

        decimal pTotAmount = 0;
        if (txtTotalAmount.Text.Trim() != "")
        {
            pTotAmount = Convert.ToDecimal(txtTotalAmount.Text.Trim());
        }

        SqlParameter TotAmount = new SqlParameter();
        TotAmount.SqlDbType = SqlDbType.Decimal;
        TotAmount.Value = pTotAmount;
        TotAmount.ParameterName = "@Amount";
        sqlCom.Parameters.Add(TotAmount);

        SqlParameter Payee = new SqlParameter();
        Payee.SqlDbType = SqlDbType.VarChar;
        Payee.Value = txtPayeeName.Text.Trim();
        Payee.ParameterName = "@Payee";
        sqlCom.Parameters.Add(Payee);

        SqlParameter SerRegNo = new SqlParameter();
        SerRegNo.SqlDbType = SqlDbType.VarChar;
        SerRegNo.Value = txtServiceTaxRegNo.Text.Trim();
        SerRegNo.ParameterName = "@SerRegNo";
        sqlCom.Parameters.Add(SerRegNo);

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

        decimal pAmount = 0;
        if (txtBillAmount.Text.Trim() != "")
        {
            pAmount = Convert.ToDecimal(txtBillAmount.Text.Trim());
        }

        SqlParameter Amount = new SqlParameter();
        Amount.SqlDbType = SqlDbType.Decimal;
        Amount.Value = pAmount;
        Amount.ParameterName = "@BillAmt";
        sqlCom.Parameters.Add(Amount);
        
        SqlParameter UserID = new SqlParameter();
        UserID.SqlDbType = SqlDbType.VarChar;
        UserID.Value = Convert.ToString(((UserInfo.structUSERInfo)(SaveUSERInfo)).UserId);
        UserID.ParameterName = "@UserID";
        sqlCom.Parameters.Add(UserID);

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
    private DataTable Get_TransactionDetails(string strTransactionID)
    {

        SqlConnection sqlCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);

        sqlCon.Open();
        SqlCommand sqlCom = new SqlCommand();
        sqlCom.Connection = sqlCon;
        sqlCom.CommandType = CommandType.StoredProcedure;
        sqlCom.CommandText = "CalOnlineTrans_Get_Transaction_Details_SP";//Get_TransactionDetails12_New

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
    protected void btnReset_Click(object sender, EventArgs e)
    {
        txtTransactionID.Text="";
        txtTotalAmount.Text="";
        ddlBranchList.SelectedIndex=0;
        txtRequestDate.Text="";
        txtServiceTaxRegNo.Text="";
        txtPayeeName.Text="";
        txtTotalAmount.Text="";
        txtBillNo.Text="";
        txtBillDate.Text="";
        txtBillAmount.Text = "";

    }    
    protected void btnView_Click(object sender, EventArgs e)
    {
        Response.Redirect("BranchPaymentRequest.aspx?Vw=1&TID="+hdnTransID.Value.Trim() , true);
    }
    private void RegisterControls_WithJavascript()
    {
        btnModify.Attributes.Add("onclick", "javascript:return Get_SelectedTransactionID(1);");
        btnView.Attributes.Add("onclick", "javascript:return Get_SelectedTransactionID(2);");
        btnSearch.Attributes.Add("onclick", "javascript:return Validate_Search();"); 
    }
    protected void btnModify_Click(object sender, EventArgs e)
    {
        Response.Redirect("BranchPaymentRequest.aspx?TID=" + hdnTransID.Value.Trim(), true);
  
    }
    private void DownloadFile(string fname, bool forceDownload)
    {
        try
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
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
            lblMessage.CssClass = "ErrorMessage";
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
}
