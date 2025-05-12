using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

public partial class Pages_ChequeProcessingNEW_ReturnChequeEntry : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserInfo"] == null)
        {
            Response.Redirect("~/Pages/InvalidRequest.aspx");

        }
        if (!IsPostBack)
        {
            
            Object SaveUSERInfo = (Object)Session["UserInfo"];
            lblLocation2.Text = Convert.ToString(((UserInfo.structUSERInfo)(SaveUSERInfo)).BranchName); ;
            Get_AllClientList();
          
            txtReturnDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
            
            Register_ControlsWith_JavaScript();
            Get_ReasonList();
            ddlClientList.Focus();
           
            btnSave.Visible = false;
        }
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
        { }
    }

    private void Get_ReasonList()
    {
        try
        {
            Object SaveUSERInfo = (Object)Session["UserInfo"];

            SqlConnection sqlcon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);

            sqlcon.Open();
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlcon;
            sqlcmd.CommandType = CommandType.StoredProcedure;
            //sqlcmd.CommandText = "Get_ReasonList";
            sqlcmd.CommandText = "Get_ReasonListForReturn";
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

            ddlReason.DataTextField = "Reason";
            ddlReason.DataValueField = "ReasonID";
            ddlReason.DataSource = dt;
            ddlReason.DataBind();

            ddlReason.Items.Insert(0, "-Select-");
            ddlReason.SelectedIndex = 0;

        }
        catch (Exception ex)
        {
            lblMessage.Visible = true;
            lblMessage.Text = ex.Message;
            lblMessage.CssClass = "ErrorMessage";

        }

    }
    private void Register_ControlsWith_JavaScript()
    {
        //txtMemodt.Attributes.Add("onKeyDown", "javascript:if(event.keyCode==13){Validate_MemoDate();};");
        //txtMicrNo.Attributes.Add("onKeyDown", "javascript:if(event.keyCode==13) {event.keyCode=9;);");
        //txtChqNo.Attributes.Add("onKeyDown", "javascript:if(event.keyCode==13) {event.keyCode=9;);");

        //ddlClientList.Attributes.Add("onKeyDown","javascript:if(event.keyCode==13){Validate_Client();};");
        txtChqAmt.Attributes.Add("onKeyDown", "javascript:if(event.keyCode==13){Validate_ChequeAmt();};");
        //btnSave.Attributes.Add("onClick", "javascript:if(event.keyCode==13){Validate_Save();};");

    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (txtMemodt.Text == "")
        {
            lblMessage.Visible = true;
            lblMessage.Text = "Memo date cannot be blank.";
            lblMessage.CssClass = "ErrorMessage";
            txtMemodt.Focus();
        }
        if (txtMicrNo.Text == "")
        {
            lblMessage.Visible = true;
            lblMessage.Text = "Micr no cannot be blank.";
            lblMessage.CssClass = "ErrorMessage";
            txtMicrNo.Focus();
        }
        if (txtChqAmt.Text == "")
        {
            lblMessage.Visible = true;
            lblMessage.Text = "Cheque Amount cannot be blank.";
            lblMessage.CssClass = "ErrorMessage";
            txtChqAmt.Focus();
        }
        if (txtChqNo.Text == "")
        {
            lblMessage.Visible = true;
            lblMessage.Text = "Cheque no cannot be blank.";
            lblMessage.CssClass = "ErrorMessage";
            txtChqNo.Focus();
        }

        InsertReturnEntry();
        ResetControls();
        ddlClientList.Focus();


    }

    private void ResetControls()
    {
        txtMemodt.Text = "";
        lblAccNo.Text = "";
        lblBank.Text = "";
        lblBranch.Text = "";
        lblCardNo.Text = "";
        lblChqDate.Text = "";
        lblDepDate.Text = "";
        lblDepNo.Text = "";
        lblLocation.Text = "";
        //lblMessage.Text = "";
        lblPayMode.Text = "";
        lblRetMemoNo.Text = "";
        lblTotalAmt.Text = "";
        txtChqAmt.Text = "";
        txtChqNo.Text = "";
        txtMemodt.Text = "";
        txtMicrNo.Text = "";
        ddlReason.SelectedIndex = 0;
        ddlClientList.SelectedIndex = 0;

    }

    private void InsertReturnEntry()
    {
        Object SaveUSERInfo = (Object)Session["UserInfo"];
        try
        {
            SqlConnection sqlcon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);

            sqlcon.Open();
            SqlCommand sqlCom = new SqlCommand();
            sqlCom.Connection = sqlcon;
            sqlCom.CommandType = CommandType.StoredProcedure;
            sqlCom.CommandText = "ReturnEntry_ForInvalidCheque_mod";
            SqlDataAdapter sqlda = new SqlDataAdapter();
            sqlda.SelectCommand = sqlCom;

            SqlParameter TransactionDetailID = new SqlParameter();
            TransactionDetailID.SqlDbType = SqlDbType.VarChar;
            TransactionDetailID.Value = hdnTransactionDetailID.Value;
            TransactionDetailID.ParameterName = "@TransactionDetailID";
            sqlCom.Parameters.Add(TransactionDetailID);

            //NIKHIL new
            SqlParameter BranchID = new SqlParameter();
            BranchID.SqlDbType = SqlDbType.Int;
            BranchID.Value = Convert.ToInt32(((UserInfo.structUSERInfo)(SaveUSERInfo)).BranchId);
            BranchID.ParameterName = "@BranchID";
            sqlCom.Parameters.Add(BranchID);

            int pClientId = 0;
            if (ddlClientList.SelectedIndex != 0)
            {
                pClientId = Convert.ToInt32(ddlClientList.SelectedItem.Value);
            }

            SqlParameter ClientID = new SqlParameter();
            ClientID.SqlDbType = SqlDbType.Int;
            ClientID.Value = pClientId;
            ClientID.ParameterName = "@ClientID";
            sqlCom.Parameters.Add(ClientID);
            //new end

            SqlParameter BatchNo = new SqlParameter();
            BatchNo.SqlDbType = SqlDbType.VarChar;
            BatchNo.Value = hdnBatchNo.Value;//remaining
            BatchNo.ParameterName = "@BatchNo";
            sqlCom.Parameters.Add(BatchNo);

            SqlParameter ReturnDate = new SqlParameter();
            ReturnDate.SqlDbType = SqlDbType.VarChar;
            //ReturnDate.Value = DateTime.Now.ToString("dd/MM/yyyy");
            ReturnDate.Value = txtReturnDate.Text.Trim();//nikhil 3rd july 2013-for displaying return date for updation if necessary.
            ReturnDate.ParameterName = "@ReturnDate";
            sqlCom.Parameters.Add(ReturnDate);

            SqlParameter ReturnReason = new SqlParameter();
            ReturnReason.SqlDbType = SqlDbType.VarChar;
            ReturnReason.Value = ddlReason.SelectedValue.ToString();//from js
            ReturnReason.ParameterName = "@ReturnReason";
            sqlCom.Parameters.Add(ReturnReason);

            SqlParameter MemoNo = new SqlParameter();
            MemoNo.SqlDbType = SqlDbType.VarChar;
            MemoNo.Value = lblRetMemoNo.Text;//from js
            MemoNo.ParameterName = "@MemoNo";
            sqlCom.Parameters.Add(MemoNo);

            SqlParameter MemoDate = new SqlParameter();
            MemoDate.SqlDbType = SqlDbType.VarChar;
            MemoDate.Value = txtMemodt.Text;
            MemoDate.ParameterName = "@MemoDate";
            sqlCom.Parameters.Add(MemoDate);

            SqlParameter CreatedBy = new SqlParameter();
            CreatedBy.SqlDbType = SqlDbType.VarChar;
            CreatedBy.Value = Convert.ToString(((UserInfo.structUSERInfo)(SaveUSERInfo)).UserId); ;//from js
            CreatedBy.ParameterName = "@UserID";
            sqlCom.Parameters.Add(CreatedBy);

            SqlParameter VarResult = new SqlParameter();
            VarResult.SqlDbType = SqlDbType.VarChar;
            VarResult.Value = "";//
            VarResult.ParameterName = "@VarResult";
            VarResult.Size = 200;
            VarResult.Direction = ParameterDirection.Output;
            sqlCom.Parameters.Add(VarResult);

            sqlCom.ExecuteNonQuery();
            sqlcon.Close();
            string RowEffected = Convert.ToString(sqlCom.Parameters["@VarResult"].Value);
            if (RowEffected != "")
            {
                lblMessage.Visible = true;
                lblMessage.Text = RowEffected;
                lblMessage.CssClass = "SuccessMessage";
                btnSave.Visible = false;
            }
            else
            {
                lblMessage.Visible = true;
                lblMessage.Text = "No such record found...!!!!";
                lblMessage.CssClass = "ErrorMessage";
            }
        }
        catch (Exception ex)
        {
            lblMessage.Visible = true;
            lblMessage.Text = ex.Message;
            lblMessage.CssClass = "ErrorMessage";
        }

    }

    protected void txtMemodt_TextChanged(object sender, EventArgs e)
    {
        try
        {

            SqlConnection sqlCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);

            sqlCon.Open();
            SqlCommand sqlCom = new SqlCommand();
            sqlCom.Connection = sqlCon;
            sqlCom.CommandType = CommandType.StoredProcedure;
            sqlCom.CommandText = "GetMemoNo";
            SqlDataAdapter sqlDA = new SqlDataAdapter();
            sqlDA.SelectCommand = sqlCom;

            SqlParameter @MemoDate = new SqlParameter();
            @MemoDate.SqlDbType = SqlDbType.VarChar;
            @MemoDate.Value = txtMemodt.Text;//hdnValue.Value;//from js
            @MemoDate.ParameterName = "@MemoDate";
            sqlCom.Parameters.Add(@MemoDate);

            DataSet ds = new DataSet();
            sqlDA.Fill(ds);
            sqlCon.Close();

            if (ds.Tables.Count > 0)
            {
                lblRetMemoNo.Text = ds.Tables[0].Rows[0]["MemoNo"].ToString();
                txtMicrNo.Focus();
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
    protected void txtMicrNo_TextChanged(object sender, EventArgs e)
    {
        Object SaveUSERInfo = (Object)Session["UserInfo"];

        try
        {
            SqlConnection sqlCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);

            sqlCon.Open();
            SqlCommand sqlCom = new SqlCommand();
            sqlCom.Connection = sqlCon;
            sqlCom.CommandType = CommandType.StoredProcedure;
            sqlCom.CommandText = "Get_MICR";
            SqlDataAdapter sqlda = new SqlDataAdapter();
            sqlda.SelectCommand = sqlCom;

            SqlParameter BranchID = new SqlParameter();
            BranchID.SqlDbType = SqlDbType.Int;
            BranchID.Value = Convert.ToInt32(((UserInfo.structUSERInfo)(SaveUSERInfo)).BranchId);
            BranchID.ParameterName = "@BranchID";
            sqlCom.Parameters.Add(BranchID);

            SqlParameter MICRCode = new SqlParameter();
            MICRCode.SqlDbType = SqlDbType.VarChar;
            MICRCode.Value = txtMicrNo.Text;
            MICRCode.ParameterName = "@MICRCode";
            sqlCom.Parameters.Add(MICRCode);

            DataSet ds = new DataSet();
            sqlda.Fill(ds);
            sqlCon.Close();

            if (ds.Tables.Count > 0)
            {

                lblBank.Text = ds.Tables[0].Rows[0]["Bank_Name"].ToString();
                lblBranch.Text = ds.Tables[0].Rows[0]["Branch_Name"].ToString();
                txtChqAmt.Focus();
            }
            else
            {
                lblMessage.Visible = true;
                lblMessage.Text = "Enter Valid MICR code.";
                txtMicrNo.Focus();
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
    protected void txtChqNo_TextChanged(object sender, EventArgs e)
    {
        Object SaveUSERInfo = (Object)Session["UserInfo"];

        SqlConnection sqlCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);

        sqlCon.Open();
        SqlCommand sqlCom = new SqlCommand();
        sqlCom.Connection = sqlCon;
        sqlCom.CommandType = CommandType.StoredProcedure;
        sqlCom.CommandText = "GetReturnDetails_mod";

        SqlDataAdapter sqlda = new SqlDataAdapter();
        sqlda.SelectCommand = sqlCom;


        //NIKHIL new
        SqlParameter BranchID = new SqlParameter();
        BranchID.SqlDbType = SqlDbType.Int;
        BranchID.Value = Convert.ToInt32(((UserInfo.structUSERInfo)(SaveUSERInfo)).BranchId);
        BranchID.ParameterName = "@BranchID";
        sqlCom.Parameters.Add(BranchID);

        int pClientId = 0;
        if (ddlClientList.SelectedIndex != 0)
        {
            pClientId = Convert.ToInt32(ddlClientList.SelectedItem.Value);
        }

        SqlParameter ClientID = new SqlParameter();
        ClientID.SqlDbType = SqlDbType.Int;
        ClientID.Value = pClientId;
        ClientID.ParameterName = "@ClientID";
        sqlCom.Parameters.Add(ClientID);
        //new end

        SqlParameter chequeno = new SqlParameter();
        chequeno.SqlDbType = SqlDbType.VarChar;
        chequeno.Value = txtChqNo.Text;
        chequeno.ParameterName = "@chequeno";
        sqlCom.Parameters.Add(chequeno);

        SqlParameter MICRCode = new SqlParameter();
        MICRCode.SqlDbType = SqlDbType.VarChar;
        MICRCode.Value = txtMicrNo.Text;
        MICRCode.ParameterName = "@MICRNo";
        sqlCom.Parameters.Add(MICRCode);

        SqlParameter ChqAmt = new SqlParameter();
        ChqAmt.SqlDbType = SqlDbType.VarChar;
        ChqAmt.Value = txtChqAmt.Text.Trim();
        ChqAmt.ParameterName = "@ChqAmt";
        sqlCom.Parameters.Add(ChqAmt);

        DataSet ds = new DataSet();
        sqlda.Fill(ds);
        sqlCon.Close();

        //if (ds.Tables[0].Rows.Count > 0)
        if (ds.Tables[0].Rows[0]["msg"].ToString() == "Cheque Details Found...!!")
        {
            lblLocation.Text = ds.Tables[0].Rows[0]["BranchCity"].ToString();
            //lblCollPt.Text = ds.Tables[0].Rows[0]["BranchCity"].ToString();
            lblCardNo.Text = ds.Tables[0].Rows[0]["CardNo"].ToString();
            lblChqDate.Text = ds.Tables[0].Rows[0]["ChequeDate"].ToString();
            //lblChqAmt.Text = ds.Tables[0].Rows[0]["ChequeAmt"].ToString();
            lblTotalAmt.Text = ds.Tables[0].Rows[0]["CardAmount"].ToString();
            lblPayMode.Text = ds.Tables[0].Rows[0]["IntrumentType"].ToString();
            lblDepNo.Text = ds.Tables[0].Rows[0]["DepositSlipNo"].ToString();
            lblDepDate.Text = ds.Tables[0].Rows[0]["ChequeDepositDate"].ToString();
            lblAccNo.Text = ds.Tables[0].Rows[0]["AccountNo"].ToString();
            hdnBatchNo.Value = ds.Tables[0].Rows[0]["BatchNo"].ToString();
            hdnTransactionDetailID.Value = ds.Tables[0].Rows[0]["TransactionDetailID"].ToString();
            ddlReason.Focus();
            lblMessage.Visible = true;
            lblMessage.Text = ds.Tables[0].Rows[0]["msg"].ToString();
            lblMessage.CssClass = "ErrorMessage";
            btnSave.Visible = true;

        }
        else
        {
            lblMessage.Visible = true;
            lblMessage.Text = ds.Tables[0].Rows[0]["msg"].ToString();
            lblMessage.CssClass = "ErrorMessage";
            btnReset.Focus();
        }
    }
    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Pages/Menu.aspx", true);
    }
    protected void txtChqAmt_TextChanged(object sender, EventArgs e)
    {
        txtChqAmt.Text = hdnChqAmt.Value;
        txtChqNo.Focus();
    }
    protected void ddlClientList_SelectedIndexChanged(object sender, EventArgs e)
    {
        lblMessage.Text = "";
        if (ddlClientList.SelectedIndex != 0)
        {
            txtMemodt.Focus();
        }
        else
        {
            ddlClientList.Focus();
            lblMessage.Visible = true;
            lblMessage.Text = "Select Client.";
            lblMessage.CssClass = "ErrorMessage";

        }
    }

    protected void btnReset_Click(object sender, EventArgs e)
    {
        ResetControls();
        lblMessage.Text = "";
        ddlClientList.Focus();
    }
}
//    protected void txtChqAmt_TextChanged(object sender, EventArgs e)
//    {
//        Object SaveUSERInfo = (Object)Session["UserInfo"];

//        SqlConnection sqlCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);

//        sqlCon.Open();
//        SqlCommand sqlCom = new SqlCommand();
//        sqlCom.Connection = sqlCon;
//        sqlCom.CommandType = CommandType.StoredProcedure;
//        sqlCom.CommandText = "ConvertAmtToDecimal";
//        SqlDataAdapter sqlda = new SqlDataAdapter();
//        sqlda.SelectCommand = sqlCom;

//        SqlParameter ChqAmt = new SqlParameter();
//        ChqAmt.SqlDbType = SqlDbType.VarChar;
//        ChqAmt.Value = Convert.ToDecimal(txtChqAmt.Text.Trim());
//        ChqAmt.ParameterName = "@ChqAmt";
//        sqlCom.Parameters.Add(ChqAmt);

//         DataSet ds = new DataSet();
//        sqlda.Fill(ds);
//        sqlCon.Close();

//        if (ds.Tables[0].Rows.Count > 0)
//        {
//            txtChqAmt.Text = ds.Tables[0].Rows[0]["ChqAmt"].ToString();
//            txtChqNo.Focus();
//        }


//    }
//}