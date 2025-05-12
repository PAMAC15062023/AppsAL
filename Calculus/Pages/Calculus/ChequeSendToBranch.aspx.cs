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

public partial class Pages_Calculus_ChequeSendToBranch : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserInfo"] == null)
        {
            Response.Redirect("~/Pages/InvalidRequest.aspx");
        }
        if (!IsPostBack)
        {
            Get_BranchId();
            Object SaveUSERInfo = (Object)Session["UserInfo"];
            if (((UserInfo.structUSERInfo)(SaveUSERInfo)).GroupName.Contains("Admin"))
            {
                ddlBranchList.Enabled = true;
            }
            else
            {
                ddlBranchList.SelectedValue = Convert.ToString(((UserInfo.structUSERInfo)(SaveUSERInfo)).BranchId);
                ddlBranchList.Enabled = false;
            }

            Register_Controls_WithJavascript();
            BindPaymentStatus();
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
            sqlcmd.CommandText = "CalOnlineTrans_Get_All_Branch_List_SP";
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
    protected void grv_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
           // CheckBox chkSelect = (CheckBox)e.Row.FindControl("chkSelect");
            //chkSelect.Attributes.Add("onclick", "javascript:checkSelected('" + chkSelect.ClientID + "');");

            GridView grvDetails = (GridView)e.Row.FindControl("grvDetails");
            grvDetails.DataSource = Get_TransactionDetails(e.Row.Cells[2].Text);
            grvDetails.DataBind();
        }
    }
    private DataTable Get_TransactionDetails(string strPaymentID)
    {

        SqlConnection sqlCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);

        sqlCon.Open();
        SqlCommand sqlCom = new SqlCommand();
        sqlCom.Connection = sqlCon;
        sqlCom.CommandType = CommandType.StoredProcedure;
        sqlCom.CommandText = "CalOnlineTrans_GetPaymentDetailsForSendtoBranch_SP";

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
    protected void btnGeneRate_Click(object sender, EventArgs e)
    {
        Get_PaymentID_For_SendToBranch();
    }
    private void Get_PaymentID_For_SendToBranch()
    { 
        SqlConnection sqlCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);
        Object SaveUSERInfo = (Object)Session["UserInfo"];
        sqlCon.Open();
        SqlCommand sqlCom = new SqlCommand();
        sqlCom.Connection = sqlCon;
        sqlCom.CommandType = CommandType.StoredProcedure;
        sqlCom.CommandText = "CalOnlineTrans_GetPaymentsForSentToBranch_SP";

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

        SqlParameter FromDate = new SqlParameter();
        FromDate.SqlDbType = SqlDbType.VarChar;
        FromDate.Value = txtFromDate.Text.Trim();
        FromDate.ParameterName = "@FromDate";
        sqlCom.Parameters.Add(FromDate);

        SqlParameter ToDate = new SqlParameter();
        ToDate.SqlDbType = SqlDbType.VarChar;
        ToDate.Value = txtToDate.Text.Trim();
        ToDate.ParameterName = "@ToDate";
        sqlCom.Parameters.Add(ToDate);

        SqlParameter PaymentStatus = new SqlParameter();
        PaymentStatus.SqlDbType = SqlDbType.VarChar;
        PaymentStatus.Value = ddlPaymentStatus.SelectedItem.Value;
        PaymentStatus.ParameterName = "@PaymentStatus";
        sqlCom.Parameters.Add(PaymentStatus);

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

            GridView1.DataSource = dt;
            GridView1.DataBind();
        }
        else
        {
            grvTransactionInfo.DataSource = null;
            grvTransactionInfo.DataBind();
            lblMessage.Text = "No Records found!";
            lblMessage.CssClass = "ErrorMessage";

            GridView1.DataSource = null;
            GridView1.DataBind();
        }


    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        Update_PaymentStatus();
    }
    private void Update_PaymentStatus()
    {
        try
        {
            Object SaveUSERInfo = (Object)Session["UserInfo"];

            SqlConnection sqlCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);

            sqlCon.Open();
            SqlCommand sqlCom = new SqlCommand();
            sqlCom.Connection = sqlCon;
            sqlCom.CommandType = CommandType.StoredProcedure;
            sqlCom.CommandText = "CalOnlineTrans_UpdatePaymentRequestStatus_SP";

            SqlParameter TransactionDetails = new SqlParameter();
            TransactionDetails.SqlDbType = SqlDbType.VarChar;
            TransactionDetails.Value = Get_PaymentTransactionIDDetails();
            TransactionDetails.ParameterName = "@TransactionDetails";
            sqlCom.Parameters.Add(TransactionDetails);

            SqlParameter UserID = new SqlParameter();
            UserID.SqlDbType = SqlDbType.VarChar;
            UserID.Value = Convert.ToString(((UserInfo.structUSERInfo)(SaveUSERInfo)).UserId);
            UserID.ParameterName = "@UserID";
            sqlCom.Parameters.Add(UserID);
             
            int RowUpdated = 0;
            RowUpdated = sqlCom.ExecuteNonQuery();
            sqlCon.Close();

            if (RowUpdated != 0)
            {
                lblMessage.Text = "Records updated successfully";
                lblMessage.CssClass = "SucessMessage";
            }
        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
            lblMessage.CssClass = "ErrorMessage";
        }
    }
    private string Get_PaymentTransactionIDDetails()
    {
        string strTransactionDetails = "";

        for (int i = 0; i <= grvTransactionInfo.Rows.Count - 1; i++)
        {
            CheckBox chkSelect = (CheckBox)grvTransactionInfo.Rows[i].FindControl("chkSelect");
            if (chkSelect.Checked)
            {
                strTransactionDetails = strTransactionDetails + grvTransactionInfo.Rows[i].Cells[2].Text.ToString() + "|" + grvTransactionInfo.Rows[i].Cells[3].Text.ToString()+"^";
            }        
        }
        
        return strTransactionDetails;       
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/pages/Menu.aspx", false);
    }
    private void Generate_ExcelFile()
    {
        String attachment = "attachment; filename=Cheque Send to Client Report.xls";
        Response.AddHeader("content-disposition", attachment);
        Response.ContentType = "application/ms-excel";
        StringWriter sw = new System.IO.StringWriter();
        HtmlTextWriter htw = new HtmlTextWriter(sw);
        Table tblSpace = new Table();
        TableRow tblRow = new TableRow();
        TableCell tblCell = new TableCell();
        tblCell.Text = " ";

        TableRow tblRow1 = new TableRow();
        TableCell tblCell1 = new TableCell();
        tblCell1.ColumnSpan = 20;// 10;
        tblCell1.Text = "<b><font size='3'>PAMAC FINSERVE PVT. LTD., MUMBAI</font></b> <br/>" +
                        "<b><font size='2' color='blue'>Cheque Send to Client Report ,For Date : " + txtFromDate.Text + " To : " + txtFromDate.Text + " </font></b> <br/>";
        tblCell1.CssClass = "SuccessMessage";
        tblRow.Cells.Add(tblCell);
        tblRow1.Cells.Add(tblCell1);
        tblRow.Height = 20;
        tblSpace.Rows.Add(tblRow);
        tblSpace.Rows.Add(tblRow1);
        tblSpace.RenderControl(htw);

        Table tbl = new Table();
        GridView1.EnableViewState = false;
        GridView1.GridLines = GridLines.Both;
        tbExport.RenderControl(htw);
        Response.Write(sw.ToString());

        Response.End();
    }
    protected void btnExport_Click(object sender, EventArgs e)
    {
        Generate_ExcelFile();
    }
    public override void VerifyRenderingInServerForm(Control control)
    {

    }
    private void Register_Controls_WithJavascript()
    {
        btnGeneRate.Attributes.Add("onclick", "javascript:return ValidateGenerate();");
        btnSave.Attributes.Add("onclick", "javascript:return ValidateSave();");
    }
    protected void BindPaymentStatus()
    {
        Common common = new Common();
        DataSet ds = new DataSet();

        ds = common.GetCalOnlineTransMasterSearchCode("PaymentStatus", 1);
        if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            ddlPaymentStatus.DataSource = ds;
            ddlPaymentStatus.DataValueField = "Code_Id";
            ddlPaymentStatus.DataTextField = "Description";
            ddlPaymentStatus.DataBind();
            ddlPaymentStatus.Items.Insert(0, new ListItem("--Select--", "0"));
        }
    }
 }
