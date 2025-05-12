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

public partial class OtherThanPettyCash : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                Object SaveUSERInfo = (Object)Session["UserInfo"];

                lblBranch.Text = Convert.ToString(((UserInfo.structUSERInfo)(SaveUSERInfo)).BranchName);
                Get_ValidationOnField();

                Get_RegionDetails(Convert.ToInt32(((UserInfo.structUSERInfo)(SaveUSERInfo)).BranchId));
                Get_VeriticalHead_Data();
                Get_ActivityList(100);
                Get_ProductList();


                //string Query = Server.UrlDecode(Request.Url.Query);
              
                if (Request.QueryString["Vw"] != null)
                {
                    btnSaveRecord.Visible = false;
                } 

                if (Request.QueryString["TID"]!=null)
                {
                    EncryptURL Encrpt = new EncryptURL();  

                    hdnTransactionID.Value =Encrpt.DecryptURL_In(Request.QueryString["TID"].ToString());
                    lblTransactionID.Text = hdnTransactionID.Value;
                    Get_DataForModification(lblTransactionID.Text);
                }
            }
        }
        catch(Exception ex)
        {
            lblMessage.Visible = true;
            lblMessage.Text = ex.Message;
            lblMessage.CssClass = "ErrorMessage";

        }
    }

    private void Get_VeriticalHead_Data()
    {
        try
        {
            Object SaveUSERInfo = (Object)Session["UserInfo"];

            SqlConnection sqlCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);

            sqlCon.Open();
            SqlCommand sqlCom = new SqlCommand();
            sqlCom.Connection = sqlCon;
            sqlCom.CommandType = CommandType.StoredProcedure;
            sqlCom.CommandText = "CalOnlineTrans_GetVerticalListUserWise_SP";

            SqlParameter UserID = new SqlParameter();
            UserID.SqlDbType = SqlDbType.VarChar;
            UserID.Value = ((UserInfo.structUSERInfo)(SaveUSERInfo)).UserId;
            UserID.ParameterName = "@UserID";
            sqlCom.Parameters.Add(UserID);

            SqlParameter BranchID = new SqlParameter();
            BranchID.SqlDbType = SqlDbType.Int;
            BranchID.Value = Convert.ToInt32(((UserInfo.structUSERInfo)(SaveUSERInfo)).BranchId);
            BranchID.ParameterName = "@BranchID";
            sqlCom.Parameters.Add(BranchID);

            SqlDataAdapter sqlDA = new SqlDataAdapter();
            sqlDA.SelectCommand = sqlCom;
            DataTable dt = new DataTable();
            sqlDA.Fill(dt);
            sqlCon.Close();

            ddlVerticalHead.DataTextField = "Vertical_Name";
            ddlVerticalHead.DataValueField = "Vertical_ID";

            ddlVerticalHead.DataSource = dt;
            ddlVerticalHead.DataBind();

            ddlVerticalHead.Items.Insert(0, "--Select--");
            ddlVerticalHead.SelectedIndex = 0;

        }
        catch (Exception ex)
        { 
            lblMessage.Visible = true;
            lblMessage.Text = ex.Message;
            lblMessage.CssClass = "ErrorMessage";
        }
    }
    //private void Get_ActivityList()
    //{
    //    try
    //    {

    //        SqlConnection sqlCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);

    //        sqlCon.Open();
    //        SqlCommand sqlCom = new SqlCommand();
    //        sqlCom.Connection = sqlCon;
    //        sqlCom.CommandType = CommandType.StoredProcedure;
    //        sqlCom.CommandText = "Get_ActivityAll";

    //        SqlDataAdapter sqlDA = new SqlDataAdapter();
    //        sqlDA.SelectCommand = sqlCom;
    //        DataTable dt = new DataTable();
    //        sqlDA.Fill(dt);
    //        sqlCon.Close();

    //        ddlActivity.DataTextField = "Activity_Name";
    //        ddlActivity.DataValueField = "Activity_ID";

    //        ddlActivity.DataSource = dt;
    //        ddlActivity.DataBind();

    //        ddlActivity.Items.Insert(0, "--Select--");
    //        ddlActivity.SelectedIndex = 0;

    //    }
    //    catch (Exception ex)
    //    {
    //        lblMessage.Visible = true;
    //        lblMessage.Text = ex.Message;
    //        lblMessage.CssClass = "ErrorMessage";
    //    }
    //}
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
            sqlCom.CommandText = "CalOnlineTrans_Get_ProductList_All_SP";

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

    private void Get_ValidationOnField()
    {
        btnSaveRecord.Attributes.Add("OnClick", "javascript:return Validation_OnField();");
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/pages/menu.aspx", true);
    }
    private void Get_RegionDetails(int pBranchID)
    {
        try
        {
            Object SaveUSERInfo = (Object)Session["UserInfo"];

            SqlConnection sqlCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);

            sqlCon.Open();
            SqlCommand sqlCom = new SqlCommand();
            sqlCom.Connection = sqlCon;
            sqlCom.CommandType = CommandType.StoredProcedure;
            sqlCom.CommandText = "CalOnlineTrans_GetRegionDetails_SP";

            SqlParameter BranchID = new SqlParameter();
            BranchID.SqlDbType = SqlDbType.Int;
            BranchID.Value = pBranchID;// ;
            BranchID.ParameterName = "@BranchID";
            sqlCom.Parameters.Add(BranchID);

            SqlDataAdapter sqlDA = new SqlDataAdapter();
            sqlDA.SelectCommand = sqlCom;
            DataTable dt = new DataTable();
            sqlDA.Fill(dt);
            sqlCon.Close();
            if (dt.Rows.Count > 0)
            {
                lblCluster.Text = dt.Rows[0]["Region_Name"].ToString();
                
            }

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
        txtAmount.Text = "";
        txtPaymentReqDate.Text = "";
        txtRemark.Text = "";
        ddlActivity.SelectedIndex = 0;
        ddlProduct.SelectedIndex = 0;
        ddlVerticalHead.SelectedIndex = 0;
        
    }
    
    private void Get_DataForModification(string pTransactionID)
    {
        try
        {
            Object SaveUSERInfo = (Object)Session["UserInfo"];

            SqlConnection sqlCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);

            sqlCon.Open();
            SqlCommand sqlCom = new SqlCommand();
            sqlCom.Connection = sqlCon;
            sqlCom.CommandType = CommandType.StoredProcedure;
            sqlCom.CommandText = "CalOnlineTrans_GetDataForModifyOTPS_SP";


            SqlParameter TransactionID = new SqlParameter();
            TransactionID.SqlDbType = SqlDbType.VarChar;
            TransactionID.Value = pTransactionID.ToString().Trim();
            TransactionID.ParameterName = "@TransactionID";
            sqlCom.Parameters.Add(TransactionID);

            SqlDataAdapter sqlDA = new SqlDataAdapter();
            sqlDA.SelectCommand = sqlCom;
            DataTable dt = new DataTable();
            sqlDA.Fill(dt);
            sqlCon.Close();

            if (dt.Rows.Count > 0)
            {
                AssignTransactionDetails(dt);
            }
        }
        catch (Exception ex)
        {
            lblMessage.Visible = true;
            lblMessage.Text = ex.Message;
            lblMessage.CssClass = "ErrorMessage";
        }

    }
    private void AssignTransactionDetails(DataTable dt)
    {
        txtPaymentReqDate.Text = dt.Rows[0]["PaymentReqDate"].ToString();
        ddlVerticalHead.SelectedValue = dt.Rows[0]["VerticalID"].ToString();
        ddlActivity.SelectedValue = dt.Rows[0]["ActivityID"].ToString();
        ddlProduct.SelectedValue = dt.Rows[0]["ProductID"].ToString();
        txtAmount.Text = dt.Rows[0]["Amount"].ToString();
        txtRemark.Text = dt.Rows[0]["Remark"].ToString();
      
    }

    protected void btnSaveRecord_Click(object sender, EventArgs e)
    {
        Insert_PaymentRequestForOTPCash();

    }
    private void Insert_PaymentRequestForOTPCash()
    {
        try
        {
            Object SaveUSERInfo = (Object)Session["UserInfo"];

            SqlConnection sqlCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);

            sqlCon.Open();
            SqlCommand sqlCom = new SqlCommand();
            sqlCom.Connection = sqlCon;
            sqlCom.CommandType = CommandType.StoredProcedure;
            sqlCom.CommandText = "CalOnlineTrans_Insert_TransactionInfo_OtherThanPettyCash_New_SP";

            SqlParameter TransactionID = new SqlParameter();
            TransactionID.SqlDbType = SqlDbType.VarChar;
            TransactionID.Value = hdnTransactionID.Value;
            TransactionID.ParameterName = "@TransactionID";
            TransactionID.Size = 200;
            sqlCom.Parameters.Add(TransactionID);


            SqlParameter BranchID = new SqlParameter();
            BranchID.SqlDbType = SqlDbType.Int;
            BranchID.Value = Convert.ToInt32(((UserInfo.structUSERInfo)(SaveUSERInfo)).BranchId);
            BranchID.ParameterName = "@BranchID";
            sqlCom.Parameters.Add(BranchID);

            SqlParameter RequestDate = new SqlParameter();
            RequestDate.SqlDbType = SqlDbType.VarChar;
            RequestDate.Value = txtPaymentReqDate.Text.Trim(); 
            RequestDate.ParameterName = "@RequestDate";
            sqlCom.Parameters.Add(RequestDate);

            SqlParameter TotalRequestAmount = new SqlParameter();
            TotalRequestAmount.SqlDbType = SqlDbType.Decimal;
            TotalRequestAmount.Value = txtAmount.Text.Trim();
            TotalRequestAmount.ParameterName = "@TotalRequestAmount";
            sqlCom.Parameters.Add(TotalRequestAmount);

            SqlParameter AccountLedgerID = new SqlParameter();
            AccountLedgerID.SqlDbType = SqlDbType.Int;
            AccountLedgerID.Value = 0;
            AccountLedgerID.ParameterName = "@AccountLedgerID";
            sqlCom.Parameters.Add(AccountLedgerID);

            SqlParameter UserID = new SqlParameter();
            UserID.SqlDbType = SqlDbType.VarChar;
            UserID.Value = Convert.ToString(((UserInfo.structUSERInfo)(SaveUSERInfo)).UserId);
            UserID.ParameterName = "@UserID";
            sqlCom.Parameters.Add(UserID);

            SqlParameter TransactionDetails = new SqlParameter();
            TransactionDetails.SqlDbType = SqlDbType.VarChar;
            TransactionDetails.Value = ddlProduct.SelectedItem.Value.ToString()+ "|" + ddlVerticalHead.SelectedItem.Value.ToString()+ "|" + ddlActivity.SelectedItem.Value.ToString() + "|0|OTP01|" + txtPaymentReqDate.Text.Trim() + "|" + txtAmount.Text.Trim() + "|6|0|0||0|||0||" + txtRemark.Text.Trim()+"|"+"^";
            TransactionDetails.ParameterName = "@TransactionDetails";
            sqlCom.Parameters.Add(TransactionDetails);

            SqlParameter AttachmentPath = new SqlParameter();
            AttachmentPath.SqlDbType = SqlDbType.VarChar;
            AttachmentPath.Value =""; 
            AttachmentPath.ParameterName = "@AttachmentPath";
            sqlCom.Parameters.Add(AttachmentPath);

            #region Code By Amrita on 22-Apr-2014 As per Client Requirement
            SqlParameter c_id = new SqlParameter();
            c_id.SqlDbType = SqlDbType.Int;
            c_id.Value = Convert.ToInt32(((UserInfo.structUSERInfo)(SaveUSERInfo)).ClientId);
            c_id.ParameterName = "@ClientId";
            sqlCom.Parameters.Add(c_id);
            #endregion


            SqlParameter VarResult = new SqlParameter();
            VarResult.SqlDbType = SqlDbType.VarChar;
            VarResult.Value = "";
            VarResult.ParameterName = "@VarResult";
            VarResult.Size = 200;
            VarResult.Direction = ParameterDirection.Output;
            sqlCom.Parameters.Add(VarResult);

          

            sqlCom.ExecuteNonQuery();
            string RowEffected = Convert.ToString(sqlCom.Parameters["@VarResult"].Value);

            sqlCon.Close();

            if (RowEffected != "")
            {
                lblMessage.Text = "Transaction Successfully Saved! Transaction ID : " + RowEffected;
                lblMessage.CssClass = "SuccessMessage";
                lblTransactionID.Text = RowEffected;
                lblTransactionID.Visible = true;
                hdnTransactionID.Value = RowEffected;

            }
        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;

        }
        
    }
    protected void btnModifyData_Click(object sender, EventArgs e)
    {

    }

    protected void ddlVerticalHead_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlVerticalHead.SelectedIndex != 0)
        {
            Get_ActivityList(Convert.ToInt32(ddlVerticalHead.SelectedItem.Value));
            ddlActivity.Focus();

        }
        else
        {
            Get_ActivityList(100);

        }
    }
}
