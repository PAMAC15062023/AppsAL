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

public partial class ValidateCheque_Search : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserInfo"] == null)
        {
            Response.Redirect("~/Pages/InvalidRequest.aspx");
        }
        if (!IsPostBack)
        {
            if (Cache["SBIClientList"] == null)
            {
                Get_AllClientList();
            }
            else
            {
                ddlClientList.DataTextField = "ClientName";
                ddlClientList.DataValueField = "ClientID";

                ddlClientList.DataSource = (DataTable)Cache["SBIClientList"];
                ddlClientList.DataBind();

                ddlClientList.Items.Insert(0, "-Select-");
                ddlClientList.SelectedIndex = 0;
            }

            RegisterControls_WithJavascript();
        }

        //string StrScript = "<script language='javascript'> javascript:Page_load_validation(); </script>";
       // Page.RegisterStartupScript("OnLoad_21", StrScript);
    }
    private void Get_AllClientList()
    {
        try
        {
            SqlConnection sqlcon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);

            sqlcon.Open();
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlcon;
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.CommandText = "Get_AllClientList";
            SqlDataAdapter sqlda = new SqlDataAdapter();
            sqlda.SelectCommand = sqlcmd;

            SqlParameter Is_Active = new SqlParameter();
            Is_Active.SqlDbType = SqlDbType.Int;
            Is_Active.Value = 1;
            Is_Active.ParameterName = "@Is_Active";
            sqlcmd.Parameters.Add(Is_Active);

            DataTable dt = new DataTable();
            sqlda.Fill(dt);
            sqlcon.Close();

            Cache["SBIClientList"] = dt;

            ddlClientList.DataTextField = "ClientName";
            ddlClientList.DataValueField = "ClientID";
            ddlClientList.DataSource = dt;
            ddlClientList.DataBind();

            ddlClientList.Items.Insert(0, "-Select-");
            ddlClientList.SelectedIndex = 0;

        }
        catch (Exception ex)
        {
            lblMessage.Visible = true;
            lblMessage.Text = ex.Message;
            lblMessage.CssClass = "ErrorMessage";

        }

        finally
        { 
        
        }

    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        Get_BatchFileDetails_Search();
    }
    private void Get_BatchFileDetails_Search()
    {
        try
        {
            Object SaveUSERInfo = (Object)Session["UserInfo"];

            SqlConnection sqlcon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);

            sqlcon.Open();
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlcon;
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.CommandText = "Get_BatchFileDetails_Search_Validate";//////nnnnn
            SqlDataAdapter sqlda = new SqlDataAdapter();
            sqlda.SelectCommand = sqlcmd;

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

            int pClientId = 0;
            if (ddlClientList.SelectedIndex != 0)
            {
                pClientId = Convert.ToInt32(ddlClientList.SelectedItem.Value);
            }

            SqlParameter ClientID = new SqlParameter();
            ClientID.SqlDbType = SqlDbType.Int;
            ClientID.Value = pClientId;
            ClientID.ParameterName = "@ClientID";
            sqlcmd.Parameters.Add(ClientID);

            SqlParameter ChequePickeupDate = new SqlParameter();
            ChequePickeupDate.SqlDbType = SqlDbType.VarChar;
            ChequePickeupDate.Value = txtPickupDate.Text.Trim();
            ChequePickeupDate.ParameterName = "@ChequePickeupDate";
            sqlcmd.Parameters.Add(ChequePickeupDate);

            SqlParameter ChequeDepositDate = new SqlParameter();
            ChequeDepositDate.SqlDbType = SqlDbType.VarChar;
            ChequeDepositDate.Value = txtDepositdate.Text.Trim();
            ChequeDepositDate.ParameterName = "@ChequeDepositDate";
            sqlcmd.Parameters.Add(ChequeDepositDate);

            SqlParameter DepositSlipNo = new SqlParameter();
            DepositSlipNo.SqlDbType = SqlDbType.VarChar;
            DepositSlipNo.Value = txtDepositSlipNo.Text.Trim();
            DepositSlipNo.ParameterName = "@DepositSlipNo";
            sqlcmd.Parameters.Add(DepositSlipNo);

            SqlParameter SendDate = new SqlParameter();
            SendDate.SqlDbType = SqlDbType.VarChar;
            SendDate.Value = txtSendDate.Text.Trim();
            SendDate.ParameterName = "@SendDate";
            sqlcmd.Parameters.Add(SendDate);

            SqlParameter Status = new SqlParameter();
            Status.SqlDbType = SqlDbType.VarChar;
            Status.Value = txtSendDate.Text.Trim();
            Status.ParameterName = "@Status";
            sqlcmd.Parameters.Add(Status);

            DataTable dt = new DataTable();
            sqlda.Fill(dt);
            sqlcon.Close();


            if (dt.Rows.Count > 0)
            {
                lblMessage.Text = "Total No of Rows found :" + dt.Rows.Count;
                lblMessage.CssClass = "SuccessMessage";
                grvTransactionInfo.DataSource = dt;
                grvTransactionInfo.DataBind();
            }
            else
            {

                lblMessage.Text = "Total No of Rows found :" + dt.Rows.Count;
                lblMessage.CssClass = "ErrorMessage";
                grvTransactionInfo.DataSource = null;
                grvTransactionInfo.DataBind();
            }



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
            CheckBox chkSelect = (CheckBox)e.Row.FindControl("chkSelect");
            chkSelect.Attributes.Add("onclick", "javascript:checkSelected('" + chkSelect.ClientID + "');");

            GridView grvDetails = (GridView)e.Row.FindControl("grvDetails");
            grvDetails.DataSource = Get_DropBoxCountDetails(e.Row.Cells[2].Text);
            grvDetails.DataBind();
        }
    }
    private DataTable Get_DropBoxCountDetails(string strBatchNo)
    {

        SqlConnection sqlCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);

        sqlCon.Open();
        SqlCommand sqlCom = new SqlCommand();
        sqlCom.Connection = sqlCon;
        sqlCom.CommandType = CommandType.StoredProcedure;
        sqlCom.CommandText = "Get_BatchFileDetails_Search_Detail";

        SqlParameter BatchNo = new SqlParameter();
        BatchNo.SqlDbType = SqlDbType.VarChar;
        BatchNo.Value = strBatchNo;
        BatchNo.ParameterName = "@BatchNo";
        sqlCom.Parameters.Add(BatchNo);

        SqlDataAdapter sqlDA = new SqlDataAdapter();
        sqlDA.SelectCommand = sqlCom;
        DataTable dt = new DataTable();
        sqlDA.Fill(dt);
        sqlCon.Close();

        return dt;

    }
    private void RegisterControls_WithJavascript()
    {
        //btnModify.Attributes.Add("onclick", "javascript:return Get_SelectedTransactionID(1);");
        //btnView.Attributes.Add("onclick", "javascript:return Get_SelectedTransactionID(1);");
        btnView.Attributes.Add("onclick", "javascript:return Get_SelectedTransactionID(3);");
        
    }
    protected void btnView_Click(object sender, EventArgs e)
    {
        Response.Redirect("ValidateChequeDataEntry.aspx?BN=" + hdnTransID.Value.Trim() + "&TID=0&CT=1", true);
        //string sub = hdnTransID.Value.Substring(15, 3);
        //if (sub == "SBI")
        //{
        //    Response.Redirect("ValidateChequeEntrySBI.aspx?BN=" + hdnTransID.Value.Trim() + "&TID=0&CT=1&BK=1", true);
        //}
        //else
        //{
        //    Response.Redirect("ValidateChequeDataEntry.aspx?BN=" + hdnTransID.Value.Trim() + "&TID=0&CT=1&BK=0", true);
        //}
    }
    
    protected void btnClose_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Pages/Menu.aspx", true);     
    }
    
    protected void btnClear_Click(object sender, EventArgs e)
    {
        Reset_Controls();
    }
    private void Reset_Controls()
    {
        txtBatchNo.Text = "";
        txtDepositdate.Text = "";
        txtDepositSlipNo.Text = "";
        txtPickupDate.Text = "";
        txtSendDate.Text = "";
        ddlClientList.SelectedIndex = 0;
       
    }
    
}
