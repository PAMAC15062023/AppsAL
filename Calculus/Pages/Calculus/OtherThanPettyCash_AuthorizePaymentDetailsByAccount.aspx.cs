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

public partial class Pages_Calculus_OtherThanPettyCash_AuthorizePaymentDetailsByAccount : System.Web.UI.Page
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
                Get_VerticalList();
                Get_ProductList();
                //  Get_ActivityList(100);
                RegisterControls_WithJavascript();
            }
       
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
            sqlcmd.CommandText = "CalOnlineTrans_Get_AllBranchList_For_Auth_SP";

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
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        Get_RecordsForOtherThanRequestDepositAcceptance_View();
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
    private void Get_RecordsForOtherThanRequestDepositAcceptance_View()
    {

        Object SaveUSERInfo = (Object)Session["UserInfo"];

        SqlConnection sqlCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);

        sqlCon.Open();
        SqlCommand sqlCom = new SqlCommand();
        sqlCom.Connection = sqlCon;
        sqlCom.CommandType = CommandType.StoredProcedure;
        sqlCom.CommandText = "CalOnlineTrans_Get_RecordsForOtherThanRequestDepositAcceptanceViewNew_SP";

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

        int pVerticalID = 0;
        if (ddlVertical.SelectedIndex != 0)
        {
            pVerticalID = Convert.ToInt32(ddlVertical.SelectedItem.Value);
        }

        SqlParameter VerticalID = new SqlParameter();
        VerticalID.SqlDbType = SqlDbType.Int;
        VerticalID.Value = pVerticalID;
        VerticalID.ParameterName = "@VerticalID";
        sqlCom.Parameters.Add(VerticalID);

        int pActivityID = 0;
        if (ddlActivity.SelectedIndex != 0)
        {
            pActivityID = Convert.ToInt32(ddlActivity.SelectedItem.Value);
        }

        SqlParameter ActivityID = new SqlParameter();
        ActivityID.SqlDbType = SqlDbType.Int;
        ActivityID.Value = pActivityID;
        ActivityID.ParameterName = "@ActivityID";
        sqlCom.Parameters.Add(ActivityID);

        int pProductID = 0;
        if (ddlProduct.SelectedIndex != 0)
        {
            pProductID = Convert.ToInt32(ddlProduct.SelectedItem.Value);
        }


        SqlParameter ProductID = new SqlParameter();
        ProductID.SqlDbType = SqlDbType.Int;
        ProductID.Value = pProductID;
        ProductID.ParameterName = "@ProductID";
        sqlCom.Parameters.Add(ProductID);

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
        sqlCom.CommandText = "CalOnlineTrans_GetOtherThanePettyCashTransactionDetails_SP";

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

        if (dt.Rows.Count>0)
        {

            if (dt.Rows[0]["RefCheck"].ToString() == "OTP01")
            {
                return null;
            }
            
        
        }

        return dt;

    }
    protected void btnReset_Click(object sender, EventArgs e)
    {
        txtTransactionID.Text = "";
        txtTotalAmount.Text = "";
        ddlBranchList.SelectedIndex = 0;
        txtRequestDate.Text = "";
        txtTotalAmount.Text = "";
        ddlProduct.SelectedIndex = 0;
        ddlVertical.SelectedIndex = 0;
        ddlActivity.SelectedIndex = 0;
    }
    protected void btnView_Click(object sender, EventArgs e)
    {
        Response.Redirect("OtherThanPettyCash.aspx?Vw=1&TID=" + hdnTransID.Value.Trim(), true);
    }
    private void RegisterControls_WithJavascript()
    {
        btnAccept.Attributes.Add("onclick", "javascript:return Get_SelectedTransactionID(1);");
        btnUpdate.Attributes.Add("onclick", "javascript:return Get_SelectedTransactionID(1);");
        //btnSubmitDetails.Attributes.Add("onclick", "javascript:return Get_SelectedTransactionID(3);");
    }
    protected void btnModify_Click(object sender, EventArgs e)
    {
        Response.Redirect("OtherThanPettyCash.aspx?TID=" + hdnTransID.Value.Trim(), true);

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
    private void Get_VerticalList()
    {
        try
        {
            Object SaveUSERInfo = (Object)Session["UserInfo"];

            SqlConnection sqlCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);

            sqlCon.Open();
            SqlCommand sqlCom = new SqlCommand();
            sqlCom.Connection = sqlCon;
            sqlCom.CommandType = CommandType.StoredProcedure;
            sqlCom.CommandText = "CalOnlineTrans_GetVerticalList_SP";

            SqlParameter IsActivate = new SqlParameter();
            IsActivate.SqlDbType = SqlDbType.Bit;
            IsActivate.Value = true;
            IsActivate.ParameterName = "@IsActivate";
            sqlCom.Parameters.Add(IsActivate);

            SqlDataAdapter sqlDA = new SqlDataAdapter();
            sqlDA.SelectCommand = sqlCom;
            DataTable dt = new DataTable();
            sqlDA.Fill(dt);
            sqlCon.Close();

            ddlVertical.DataTextField = "Vertical_Name";
            ddlVertical.DataValueField = "Vertical_ID";

            ddlVertical.DataSource = dt;
            ddlVertical.DataBind();

            ddlVertical.Items.Insert(0, "--Select--");
            ddlVertical.SelectedIndex = 0;
            if (ddlVertical.SelectedIndex == 0)
            {
                Get_ActivityList(0);
            }
            else
            {
                Get_ActivityList(Convert.ToInt32(ddlVertical.SelectedIndex));
            }

            

        }
        catch (Exception ex)
        {
            lblMessage.Visible = true;
            lblMessage.Text = ex.Message;
            lblMessage.CssClass = "ErrorMessage";
        }
    }
    private void Get_ProductList()
    {
        try
        {
            Object SaveUSERInfo = (Object)Session["UserInfo"];

            SqlConnection sqlCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);

            sqlCon.Open();
            SqlCommand sqlCom = new SqlCommand();
            sqlCom.Connection = sqlCon;
            sqlCom.CommandType = CommandType.StoredProcedure;
            sqlCom.CommandText = "CalOnlineTrans_GetProductList_SP";

            SqlParameter IsActivate = new SqlParameter();
            IsActivate.SqlDbType = SqlDbType.Bit;
            IsActivate.Value = true;
            IsActivate.ParameterName = "@IsActivate";
            sqlCom.Parameters.Add(IsActivate);

            SqlDataAdapter sqlDA = new SqlDataAdapter();
            sqlDA.SelectCommand = sqlCom;
            DataTable dt = new DataTable();
            sqlDA.Fill(dt);
            sqlCon.Close();

            ddlProduct.DataTextField = "Product_Code";
            ddlProduct.DataValueField = "Product_ID";

            ddlProduct.DataSource = dt;
            ddlProduct.DataBind();

            ddlProduct.Items.Insert(0, "--Select--");
            ddlProduct.SelectedIndex = 0;



        }
        catch (Exception ex)
        {
            lblMessage.Visible = true;
            lblMessage.Text = ex.Message;
            lblMessage.CssClass = "ErrorMessage";
        }
    }
    private void Get_ActivityList(int pVerticalID)
    {
        try
        {

            SqlConnection sqlCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);

            sqlCon.Open();
            SqlCommand sqlCom = new SqlCommand();
            sqlCom.Connection = sqlCon;
            sqlCom.CommandType = CommandType.StoredProcedure;
            sqlCom.CommandText = "CalOnlineTrans_Get_ActivityList_SP";

            SqlParameter Vertical_ID = new SqlParameter();
            Vertical_ID.SqlDbType = SqlDbType.Int;
            Vertical_ID.Value = pVerticalID;
            Vertical_ID.ParameterName = "@Vertical_ID";
            sqlCom.Parameters.Add(Vertical_ID);

            SqlDataAdapter sqlDA = new SqlDataAdapter();
            sqlDA.SelectCommand = sqlCom;
            DataTable dt = new DataTable();
            sqlDA.Fill(dt);
            sqlCon.Close();

            ddlActivity.DataTextField = "Activity_Name";
            ddlActivity.DataValueField = "Activity_ID";

            ddlActivity.DataSource = dt;
            ddlActivity.DataBind();

            ddlActivity.Items.Insert(0, "--Select--");
            ddlActivity.SelectedIndex = 0;

        }
        catch (Exception ex)
        {
            lblMessage.Visible = true;
            lblMessage.Text = ex.Message;
            lblMessage.CssClass = "ErrorMessage";
        }
    }
    protected void ddlVertical_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlVertical.SelectedIndex != 0)
        {
            Get_ActivityList(Convert.ToInt32(ddlVertical.SelectedItem.Value));
            ddlActivity.Focus();

        }
        else
        {
            Get_ActivityList(0);

        }
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Pages/Menu.aspx", true);
    }
    protected void btnAccept_Click(object sender, EventArgs e)
    {
        for (int i = 0; i <= grvTransactionInfo.Rows.Count - 1; i++)
        {

            string sTrans = "";

            CheckBox chkSelect = (CheckBox)grvTransactionInfo.Rows[i].FindControl("chkSelect");
            TextBox txtRemark = (TextBox)grvTransactionInfo.Rows[i].FindControl("txtRemark");

            if (chkSelect.Checked == true)
            {
                if (txtRemark.Text != "")
                {
                    sTrans = grvTransactionInfo.Rows[i].Cells[2].Text.Trim();
                    Update_PaymentRequest_By_Account(sTrans, txtRemark.Text.Trim(), 1);
                }
                else
                {
                    lblMessage.Text = "Please enter Remark!";
                    lblMessage.CssClass = "ErrorMessage";
                    txtRemark.Focus();
                }
            }

        }
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        for (int i = 0; i <= grvTransactionInfo.Rows.Count - 1; i++)
        {

            string sTrans = "";

            CheckBox chkSelect = (CheckBox)grvTransactionInfo.Rows[i].FindControl("chkSelect");
            TextBox txtRemark = (TextBox)grvTransactionInfo.Rows[i].FindControl("txtRemark");

            if (chkSelect.Checked == true)
            {
                if (txtRemark.Text != "")
                {
                    sTrans = grvTransactionInfo.Rows[i].Cells[2].Text.Trim();

                    Update_PaymentRequest_By_Account(sTrans, txtRemark.Text.Trim(),0);
                }
                else
                {
                    lblMessage.Text = "Please enter Remark!";
                    lblMessage.CssClass = "ErrorMessage";
                    txtRemark.Focus();
                }
            }

        }
    }
    private void Update_PaymentRequest_By_Account(string strTransID,string strRemark,int pUpdate)
    {
        try
        {
            Object SaveUSERInfo = (Object)Session["UserInfo"];

            SqlConnection sqlCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);

            sqlCon.Open();
            SqlCommand sqlCom = new SqlCommand();
            sqlCom.Connection = sqlCon;
            sqlCom.CommandType = CommandType.StoredProcedure;
            sqlCom.CommandText = "CalOnlineTrans_UpdateOtherThanPettyCashVoucherDetails_ToCLoseNew_SP";

            SqlParameter TranasctionID = new SqlParameter();
            TranasctionID.SqlDbType = SqlDbType.VarChar;
            TranasctionID.Value = strTransID;
            TranasctionID.ParameterName = "@TransactionID";
            sqlCom.Parameters.Add(TranasctionID);

            SqlParameter Remark = new SqlParameter();
            Remark.SqlDbType = SqlDbType.VarChar;
            Remark.Value = strRemark;
            Remark.ParameterName = "@Remark";
            sqlCom.Parameters.Add(Remark);

            SqlParameter UserID = new SqlParameter();
            UserID.SqlDbType = SqlDbType.VarChar;
            UserID.Value = Convert.ToString(((UserInfo.structUSERInfo)(SaveUSERInfo)).UserId);
            UserID.ParameterName = "@UserID";
            sqlCom.Parameters.Add(UserID);

            SqlParameter Update = new SqlParameter();
            Update.SqlDbType = SqlDbType.Int;
            Update.Value = pUpdate;
            Update.ParameterName = "@Update";
            sqlCom.Parameters.Add(Update);

            
            int RowEffected =Convert.ToInt32(sqlCom.ExecuteNonQuery());
            sqlCon.Close();

            if (RowEffected >0)
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

    protected void ddlActivity_SelectedIndexChanged(object sender, EventArgs e)
    {
    }
}
