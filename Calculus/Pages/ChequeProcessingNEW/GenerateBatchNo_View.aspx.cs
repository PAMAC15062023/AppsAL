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

public partial class Pages_ChequeProcessingNEW_GenerateBatchNo_View : System.Web.UI.Page
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

    }
    private void Get_AllClientList()
    {
        try
        {
            SqlConnection sqlcon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);


            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlcon;
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.CommandText = "Get_AllClientList";
            sqlcmd.CommandTimeout = 0;

            SqlParameter Is_Active = new SqlParameter();
            Is_Active.SqlDbType = SqlDbType.Int;
            Is_Active.Value = 1;
            Is_Active.ParameterName = "@Is_Active";
            sqlcmd.Parameters.Add(Is_Active);

            sqlcon.Open();
            SqlDataAdapter sqlda = new SqlDataAdapter();
            sqlda.SelectCommand = sqlcmd;
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


            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlcon;
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.CommandText = "Get_BatchFileDetails_Search";
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


            sqlcon.Open();
            SqlDataAdapter sqlda = new SqlDataAdapter();
            sqlda.SelectCommand = sqlcmd;

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

        finally
        {
        
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

     
        SqlCommand sqlCom = new SqlCommand();
        sqlCom.Connection = sqlCon;
        sqlCom.CommandType = CommandType.StoredProcedure;
        sqlCom.CommandText = "Get_BatchFileDetails_Search_Detail";
        sqlCom.CommandTimeout = 0;


        SqlParameter BatchNo = new SqlParameter();
        BatchNo.SqlDbType = SqlDbType.VarChar;
        BatchNo.Value = strBatchNo;
        BatchNo.ParameterName = "@BatchNo";
        sqlCom.Parameters.Add(BatchNo);

        sqlCon.Open();
        SqlDataAdapter sqlDA = new SqlDataAdapter();
        sqlDA.SelectCommand = sqlCom;
        DataTable dt = new DataTable();
        sqlDA.Fill(dt);
        sqlCon.Close();

        return dt;

    }
    private void RegisterControls_WithJavascript()
    {
        btnModify.Attributes.Add("onclick", "javascript:return Get_SelectedTransactionID(1);");
        btnView.Attributes.Add("onclick", "javascript:return Get_SelectedTransactionID(2);");
        
        btnChequeEntry.Attributes.Add("onclick", "javascript:return Get_SelectedTransactionID(3);");
        btnOtherBank.Attributes.Add("onclick", "javascript:return Get_SelectedTransactionID(3);");
        btnUpCountry.Attributes.Add("onclick", "javascript:return Get_SelectedTransactionID(3);");
       
    }
    protected void btnView_Click(object sender, EventArgs e)
    {
        //Response.Redirect("GenerateBatchFile.aspx?Vw=1&TID=" + hdnTransID.Value.Trim(), true);
        Response.Redirect("GenerateBatchFileNew.aspx?Vw=1&TID=" + hdnTransID.Value.Trim(), true); 
    }
    protected void btnModify_Click(object sender, EventArgs e)
    {
        Response.Redirect("GenerateBatchFileNew.aspx?TID=" + hdnTransID.Value.Trim(), true); 
        //Response.Redirect("GenerateBatchFile.aspx?TID=" + hdnTransID.Value.Trim(), true);  
    }
    protected void btnChequeEntry_Click(object sender, EventArgs e)
    {
        //Response.Redirect("ChequeDataEntry.aspx?BN=" + hdnTransID.Value.Trim()+"&TID=0&CT=1", true);
        Response.Redirect("ChequeEntryNew.aspx?BN=" + hdnTransID.Value.Trim() + "&TID=0&CT=1", true); 
    }
    protected void btnGenerateDepositSlip_Click(object sender, EventArgs e)
    {
        Response.Redirect("GenerateDepositSlip.aspx?BN=" + hdnTransID.Value.Trim() , true);    
    }
    protected void btnClose_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Pages/Menu.aspx", true);     
    }
   
    protected void btnOtherBank_Click(object sender, EventArgs e)
    {
        Response.Redirect("OtherChequeDataEntry.aspx?BN=" + hdnTransID.Value.Trim() + "&TID=0&CT=3", true);       
    }
    protected void btnUpCountry_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/pages/chequeprocessingnew/OtherChequeDataEntry.aspx?BN=" + hdnTransID.Value.Trim() + "&TID=0&CT=4", true);     
  
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
    protected void btnValidateChequeEntry_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Pages/ChequeProcessingNEW/ValidateChequeDataEntry.aspx",true);
    }
}
