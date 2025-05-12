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

public partial class Pages_Calculus_ALL_BranchPaymentRequest : System.Web.UI.Page
{
    Double closingBalance = 0;
    Double transactionAmount = 0;
    int lastClosingCount = 0;
    int currentOpeningCount = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserInfo"] == null)
        {
            Response.Redirect("~/Pages/InvalidRequest.aspx");

        }

        if (!IsPostBack)
        {
            if (Request.QueryString["Vw"] != null)
            {
                btnSave.Visible = false;
            }
            if (Request.QueryString["TID"] != null)
            {
                hdnTransactionID.Value = Request.QueryString["TID"].ToString();
                lblTransactionID.Text = Request.QueryString["TID"].ToString();
            }
            BindTaxType();
            BindAdjustType();
            Get_BranchList();
            GET_Header_Values();
            Register_ControlsWith_JavaScript();


        }

        string StrScript = "<script language='javascript'> javascript:Page_load_validation(); </script>";
        Page.RegisterStartupScript("OnLoad_21", StrScript);

    }
    private void Get_BranchList()
    {
        try
        {

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
            ddlBranchList.DataValueField = "BranchId";
            ddlBranchList.DataSource = dt;
            ddlBranchList.DataBind();

            //ddlBranchList.Items.Insert(0, "--Select--");
            //ddlBranchList.SelectedIndex = 0;

        }
        catch (Exception ex)
        {
            lblError.Visible = true;
            lblError.Text = ex.Message;
        }
    }
    private void Register_ControlsWith_JavaScript()
    {
        btnAddtoGrid.Attributes.Add("onclick", "javascript:return AddColumnToGrid();");
        btnRemove.Attributes.Add("onclick", "javascript:return RemoveColumnFromGrid();");
        txtServiceTaxAmt.Attributes.Add("onfocus", "javascript:CalulateTax();");
        txtServiceTaxAmt1.Attributes.Add("onfocus", "javascript:CalulateTax();");
        ddlServiceTax.Attributes.Add("onchange", "javascript:CalulateTax();");
        txtBillAmt.Attributes.Add("onblur", "javascript:CalulateTax();");
        btnSave.Attributes.Add("onclick", "javascript:return Validate_Headers();");
        ddlVenderList.Attributes.Add("onchange", "javascript:Get_PanNo();");
        txtRemark.Attributes.Add("onfocus", "javascript:Auto_Remark();");
        ddlAccountHeadList.Attributes.Add("onchange", "javascript:Auto_Remark();");
        ddladjusttype.Attributes.Add("onchange", "javascript:AdjustmntAmt();");

    }

    private void GET_Header_Values()
    {
        Object SaveUSERInfo = (Object)Session["UserInfo"];

        lblbranch.Text = Convert.ToString(((UserInfo.structUSERInfo)(SaveUSERInfo)).BranchName);

        Get_RegionDetails(Convert.ToInt32(ddlBranchList.SelectedItem.Value));
        Get_VerticalList();
        Get_ProductList();
        //Get_ActivityList(100);
        Get_ActivityList();
        Get_AccountHeadList();
        Get_PayeeMasterList_BranchWise("00");
        Get_ServiceTaxList();

        if (hdnTransactionID.Value != "")
        {
            Get_TransactionDetails(Convert.ToInt32(ddlBranchList.SelectedItem.Value));
        }
        if (txtPaymentDate.Text != "")
        {
            Get_OpeningBalanceMonth_BranchWise();
        }
        getTotalAmount();

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
            sqlCom.CommandText = "CalOnlineTrans_GetVerticalListUserWise_SP";

            SqlParameter UserID = new SqlParameter();
            UserID.SqlDbType = SqlDbType.VarChar;
            UserID.Value = ((UserInfo.structUSERInfo)(SaveUSERInfo)).UserId;
            UserID.ParameterName = "@UserID";
            sqlCom.Parameters.Add(UserID);

            SqlParameter BranchID = new SqlParameter();
            BranchID.SqlDbType = SqlDbType.Int;
            BranchID.Value = Convert.ToInt32(ddlBranchList.SelectedItem.Value);
            BranchID.ParameterName = "@BranchID";
            sqlCom.Parameters.Add(BranchID);

            SqlDataAdapter sqlDA = new SqlDataAdapter();
            sqlDA.SelectCommand = sqlCom;
            DataTable dt = new DataTable();
            sqlDA.Fill(dt);
            sqlCon.Close();

            ddlVerticalList.DataTextField = "Vertical_Name";
            ddlVerticalList.DataValueField = "Vertical_ID";

            ddlVerticalList.DataSource = dt;
            ddlVerticalList.DataBind();

            ddlVerticalList.Items.Insert(0, "--Select--");
            ddlVerticalList.SelectedIndex = 0;



        }
        catch (Exception ex)
        {
            lblError.Visible = true;
            lblError.Text = ex.Message;
            lblError.CssClass = "ErrorMessage";
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

            ddlProductList.DataTextField = "Product_Code";
            ddlProductList.DataValueField = "Product_ID";

            ddlProductList.DataSource = dt;
            ddlProductList.DataBind();

            ddlProductList.Items.Insert(0, "--Select--");
            ddlProductList.SelectedIndex = 0;



        }
        catch (Exception ex)
        {
            lblError.Visible = true;
            lblError.Text = ex.Message;
            lblError.CssClass = "ErrorMessage";
        }
    }

    //private void Get_ActivityList(int pVerticalID)
    //{
    //    try
    //    {

    //        SqlConnection sqlCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);

    //        sqlCon.Open();
    //        SqlCommand sqlCom = new SqlCommand();
    //        sqlCom.Connection = sqlCon;
    //        sqlCom.CommandType = CommandType.StoredProcedure;
    //        sqlCom.CommandText = "Get_ActivityList";

    //        SqlParameter Vertical_ID = new SqlParameter();
    //        Vertical_ID.SqlDbType = SqlDbType.Int;
    //        Vertical_ID.Value = pVerticalID;
    //        Vertical_ID.ParameterName = "@Vertical_ID";
    //        sqlCom.Parameters.Add(Vertical_ID);

    //        SqlDataAdapter sqlDA = new SqlDataAdapter();
    //        sqlDA.SelectCommand = sqlCom;
    //        DataTable dt = new DataTable();
    //        sqlDA.Fill(dt);
    //        sqlCon.Close();

    //        ddlActivityList.DataTextField = "Activity_Name";
    //        ddlActivityList.DataValueField = "Activity_ID";

    //        ddlActivityList.DataSource = dt;
    //        ddlActivityList.DataBind();

    //        ddlActivityList.Items.Insert(0, "--Select--");
    //        ddlActivityList.SelectedIndex = 0;

    //    }
    //    catch (Exception ex)
    //    {
    //        lblError.Visible = true;
    //        lblError.Text = ex.Message;
    //        lblError.CssClass = "ErrorMessage";
    //    }
    //}
    private void Get_ActivityList()
    {
        try
        {

            SqlConnection sqlCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);

            sqlCon.Open();
            SqlCommand sqlCom = new SqlCommand();
            sqlCom.Connection = sqlCon;
            sqlCom.CommandType = CommandType.StoredProcedure;
            sqlCom.CommandText = "CalOnlineTrans_GetActivityListNew_SP";

            SqlDataAdapter sqlDA = new SqlDataAdapter();
            sqlDA.SelectCommand = sqlCom;
            DataTable dt = new DataTable();
            sqlDA.Fill(dt);
            sqlCon.Close();

            ddlActivityList.DataTextField = "Activity_Name";
            ddlActivityList.DataValueField = "Activity_ID";

            ddlActivityList.DataSource = dt;
            ddlActivityList.DataBind();

            ddlActivityList.Items.Insert(0, "--Select--");
            ddlActivityList.SelectedIndex = 0;

        }
        catch (Exception ex)
        {
            lblError.Visible = true;
            lblError.Text = ex.Message;
            lblError.CssClass = "ErrorMessage";
        }
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
                lblRegionCluster.Text = dt.Rows[0]["Region_Name"].ToString();
                txtPaymentDate.Text = dt.Rows[0]["PaymentRequestDate"].ToString();
            }




        }
        catch (Exception ex)
        {
            lblError.Visible = true;
            lblError.Text = ex.Message;
            lblError.CssClass = "ErrorMessage";
        }
    }

    //Added by abhijeet//


    private void Get_RegionDetails12()
    {
        try
        {
            if ((ddlVenderList.SelectedValue.ToString() != "") && (ddlVenderList.SelectedValue.ToString() != "--Select--"))
            {
                string payeeid = ddlVenderList.SelectedValue.Split(':')[0];

                Object SaveUSERInfo = (Object)Session["UserInfo"];

                SqlConnection sqlCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);

                sqlCon.Open();
                SqlCommand sqlCom = new SqlCommand();
                sqlCom.Connection = sqlCon;
                sqlCom.CommandType = CommandType.StoredProcedure;
                sqlCom.CommandText = "CalOnlineTrans_GetGSTDetails_SP";



                SqlParameter GSTNo = new SqlParameter();
                GSTNo.SqlDbType = SqlDbType.VarChar;
                GSTNo.Value = payeeid;
                GSTNo.ParameterName = "@payee_id";
                sqlCom.Parameters.Add(GSTNo);

                SqlDataAdapter sqlDA = new SqlDataAdapter();
                sqlDA.SelectCommand = sqlCom;
                DataTable dt = new DataTable();
                sqlDA.Fill(dt);
                sqlCon.Close();
                if (dt.Rows.Count > 0)
                {
                    if (dt.Rows[0]["Is_GSTActive"].ToString() == "1" || dt.Rows[0]["Is_GSTActive"].ToString() == "")
                    {
                        txtServiceTaxRegNo.Text = dt.Rows[0]["GST_no"].ToString();

                         //txtPanCard.Text = dt.Rows[0]["Pan_No"].ToString(); Changes done on 9-02-2024 because Pan car not bind
                         //lblError.Text = "";  Changes done on 9-02-2024 because Pan car not bind                   
                    }
					
					  txtPanCard.Text = dt.Rows[0]["Pan_No"].ToString();
                        lblError.Text = "";
                }



            }
            else
            {
            }
        }
        catch (Exception ex)
        {
            lblError.Visible = true;
            lblError.Text = ex.Message;
            lblError.CssClass = "ErrorMessage";
        }

    }


    //ended by abhijeet//

    //protected void ddlVerticalList_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    if (ddlVerticalList.SelectedIndex != 0)
    //    {
    //        Get_ActivityList(Convert.ToInt32(ddlVerticalList.SelectedItem.Value));
    //        ddlActivityList.Focus();

    //    }
    //    else
    //    {
    //        Get_ActivityList(100);

    //    }
    //}

    protected void ddlVerticalList_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlVerticalList.SelectedIndex != 0)
        {
            Get_ActivityList();
            ddlActivityList.Focus();

        }
        else
        {
            Get_ActivityList();

        }
    }

    private void Get_PayeeMasterList_BranchWise(string pPayeeName)
    {
        try
        {
            Object SaveUSERInfo = (Object)Session["UserInfo"];

            SqlConnection sqlCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);

            sqlCon.Open();
            SqlCommand sqlCom = new SqlCommand();
            sqlCom.Connection = sqlCon;
            sqlCom.CommandType = CommandType.StoredProcedure;
            sqlCom.CommandText = "CalOnlineTrans_GetPayeeMasterList_SP";

            SqlParameter BranchId = new SqlParameter();
            BranchId.SqlDbType = SqlDbType.Int;
            BranchId.Value = Convert.ToInt32(ddlBranchList.SelectedItem.Value);//pBranchId;
            BranchId.ParameterName = "@BranchId";
            sqlCom.Parameters.Add(BranchId);

            SqlParameter IsActive = new SqlParameter();
            IsActive.SqlDbType = SqlDbType.Bit;
            IsActive.Value = false;
            IsActive.ParameterName = "@IsActive";
            sqlCom.Parameters.Add(IsActive);

            SqlParameter PayeeName = new SqlParameter();
            PayeeName.SqlDbType = SqlDbType.VarChar;
            PayeeName.Value = pPayeeName;
            PayeeName.ParameterName = "@PayeeName";
            sqlCom.Parameters.Add(PayeeName);

            SqlDataAdapter sqlDA = new SqlDataAdapter();
            sqlDA.SelectCommand = sqlCom;

            DataTable dt = new DataTable();
            sqlDA.Fill(dt);
            sqlCon.Close();

            ddlVenderList.DataTextField = "Payee_Name";
            ddlVenderList.DataValueField = "Payee_ID_PanNo";

            ddlVenderList.DataSource = dt;
            ddlVenderList.DataBind();

            ddlVenderList.Items.Insert(0, "--Select--");
            ddlVenderList.SelectedIndex = 0;



        }
        catch (Exception ex)
        {
            lblError.Visible = true;
            lblError.Text = ex.Message;
            lblError.CssClass = "ErrorMessage";
        }


    }

    private void Get_ServiceTaxList()
    {
        try
        {

            SqlConnection sqlCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);

            sqlCon.Open();
            SqlCommand sqlCom = new SqlCommand();
            sqlCom.Connection = sqlCon;
            sqlCom.CommandType = CommandType.StoredProcedure;
            sqlCom.CommandText = "CalOnlineTrans_GetServiceTaxList_SP";

            SqlParameter IsActive = new SqlParameter();
            IsActive.SqlDbType = SqlDbType.Bit;
            IsActive.Value = true;
            IsActive.ParameterName = "@IsActive";
            sqlCom.Parameters.Add(IsActive);

            SqlDataAdapter sqlDA = new SqlDataAdapter();
            sqlDA.SelectCommand = sqlCom;

            DataTable dt = new DataTable();
            sqlDA.Fill(dt);
            sqlCon.Close();

            ddlServiceTax.DataTextField = "ServiceTaxPercentage";
            ddlServiceTax.DataValueField = "ServiceTaxID";

            ddlServiceTax.DataSource = dt;
            ddlServiceTax.DataBind();

            ddlServiceTax.Items.Insert(0, "--Select--");
            ddlServiceTax.SelectedIndex = 0;

        }
        catch (Exception ex)
        {
            lblError.Visible = true;
            lblError.Text = ex.Message;
            lblError.CssClass = "ErrorMessage";
        }


    }



    private void Get_ServiceTaxList12()
    {
        try
        {

            SqlConnection sqlCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);

            sqlCon.Open();
            SqlCommand sqlCom = new SqlCommand();
            sqlCom.Connection = sqlCon;
            sqlCom.CommandType = CommandType.StoredProcedure;
            sqlCom.CommandText = "CalOnlineTrans_GetServiceTaxList_17102020_SP";

            SqlParameter IsActive = new SqlParameter();
            IsActive.SqlDbType = SqlDbType.Bit;
            IsActive.Value = true;
            IsActive.ParameterName = "@IsActive";
            sqlCom.Parameters.Add(IsActive);

            SqlDataAdapter sqlDA = new SqlDataAdapter();
            sqlDA.SelectCommand = sqlCom;

            DataTable dt = new DataTable();
            sqlDA.Fill(dt);
            sqlCon.Close();

            ddlServiceTax.DataTextField = "ServiceTaxPercentage";
            ddlServiceTax.DataValueField = "ServiceTaxID";

            ddlServiceTax.DataSource = dt;
            ddlServiceTax.DataBind();

            ddlServiceTax.Items.Insert(0, "--Select--");
            ddlServiceTax.SelectedIndex = 0;

        }
        catch (Exception ex)
        {
            lblError.Visible = true;
            lblError.Text = ex.Message;
            lblError.CssClass = "ErrorMessage";
        }


    }


    private void Get_ServiceTaxList21()
    {
        try
        {

            SqlConnection sqlCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);

            sqlCon.Open();
            SqlCommand sqlCom = new SqlCommand();
            sqlCom.Connection = sqlCon;
            sqlCom.CommandType = CommandType.StoredProcedure;
            sqlCom.CommandText = "CalOnlineTrans_GetServiceTaxList24jul2017_SP";

            SqlParameter IsActive = new SqlParameter();
            IsActive.SqlDbType = SqlDbType.Bit;
            IsActive.Value = true;
            IsActive.ParameterName = "@IsActive";
            sqlCom.Parameters.Add(IsActive);

            SqlDataAdapter sqlDA = new SqlDataAdapter();
            sqlDA.SelectCommand = sqlCom;

            DataTable dt = new DataTable();
            sqlDA.Fill(dt);
            sqlCon.Close();

            ddlServiceTax.DataTextField = "ServiceTaxPercentage";
            ddlServiceTax.DataValueField = "ServiceTaxID";

            ddlServiceTax.DataSource = dt;
            ddlServiceTax.DataBind();

            ddlServiceTax.Items.Insert(0, "--Select--");
            ddlServiceTax.SelectedIndex = 0;

        }
        catch (Exception ex)
        {
            lblError.Visible = true;
            lblError.Text = ex.Message;
            lblError.CssClass = "ErrorMessage";
        }


    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        Get_PayeeMasterList_BranchWise(txtPayeeNameSearch.Text.Trim());
        ddlVenderList.Focus();
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            Insert_PaymentRequest();
            GET_Header_Values();
            UpdateAmount();
            Clears_Controls();
        }
        catch (Exception ex)
        {
        }
    }
    private void Insert_PaymentRequest()
    {
        try
        {
            Object SaveUSERInfo = (Object)Session["UserInfo"];

            SqlConnection sqlCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);

            sqlCon.Open();
            SqlCommand sqlCom = new SqlCommand();
            sqlCom.Connection = sqlCon;
            sqlCom.CommandType = CommandType.StoredProcedure;
            sqlCom.CommandText = "CalOnlineTrans_InsertTransactionInfo_New__SP";//Insert_TransactionInfo_new_23Apr12

            SqlParameter TransactionID = new SqlParameter();
            TransactionID.SqlDbType = SqlDbType.VarChar;
            TransactionID.Value = hdnTransactionID.Value;
            TransactionID.ParameterName = "@TransactionID";
            TransactionID.Size = 200;
            sqlCom.Parameters.Add(TransactionID);


            //if ((ddlBranchList.SelectedItem.Value != "--Select--") && (ddlBranchList.SelectedIndex.ToString().Trim() != "0"))
            //{
                SqlParameter BranchID = new SqlParameter();
                BranchID.SqlDbType = SqlDbType.Int;
                BranchID.Value = Convert.ToInt32(ddlBranchList.SelectedItem.Value);
                BranchID.ParameterName = "@BranchID";
                sqlCom.Parameters.Add(BranchID);
            //}
            //else
            //{
            //    lblError.Text = "Select Branch....!!!!";
            //    return;
            //}

            SqlParameter RequestDate = new SqlParameter();
            RequestDate.SqlDbType = SqlDbType.VarChar;
            RequestDate.Value = txtPaymentDate.Text.Trim();
            RequestDate.ParameterName = "@RequestDate";
            sqlCom.Parameters.Add(RequestDate);

            SqlParameter TotalRequestAmount = new SqlParameter();
            TotalRequestAmount.SqlDbType = SqlDbType.Decimal;
            TotalRequestAmount.Value = Convert.ToDecimal(hdnSavingPaymentDetails.Value);
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
            TransactionDetails.Value = hdnPaymentDetails.Value;
            TransactionDetails.ParameterName = "@TransactionDetails";
            sqlCom.Parameters.Add(TransactionDetails);

            SqlParameter AttachmentPath = new SqlParameter();
            AttachmentPath.SqlDbType = SqlDbType.VarChar;
            AttachmentPath.Value = UploadAttachment_OnServer();
            AttachmentPath.ParameterName = "@AttachmentPath";
            sqlCom.Parameters.Add(AttachmentPath);

            SqlParameter PaymentType = new SqlParameter();
            PaymentType.SqlDbType = SqlDbType.Int;
            PaymentType.Value = 2;
            PaymentType.ParameterName = "@PaymentType";
            sqlCom.Parameters.Add(PaymentType);

            SqlParameter VarResult = new SqlParameter();
            VarResult.SqlDbType = SqlDbType.VarChar;
            VarResult.Value = hdnTransactionID.Value;
            VarResult.ParameterName = "@VarResult";
            VarResult.Size = 200;
            VarResult.Direction = ParameterDirection.Output;
            sqlCom.Parameters.Add(VarResult);

            #region Code By Amrita on 22-Apr-2014 As per Client Requirement
            SqlParameter ClientId = new SqlParameter();
            ClientId.SqlDbType = SqlDbType.Int;
            ClientId.Value = Convert.ToInt32(((UserInfo.structUSERInfo)(SaveUSERInfo)).ClientId);
            ClientId.ParameterName = "@ClientId";
            sqlCom.Parameters.Add(ClientId);
            #endregion

            sqlCom.ExecuteNonQuery();
            string RowEffected = Convert.ToString(sqlCom.Parameters["@VarResult"].Value);

            sqlCon.Close();

            if (RowEffected != "")
            {
                lblError.Text = "Transaction Successfully Saved! Transaction ID : " + RowEffected;
                lblError.CssClass = "SuccessMessage";
                lblTransactionID.Text = RowEffected;
                lblTransactionID.Visible = true;
                hdnTransactionID.Value = RowEffected;
            }
        }
        catch (Exception ex)
        {
            lblError.Text = ex.Message;
            return;

        }


    }
    private void Get_OpeningBalanceMonth_BranchWise()
    {
        try
        {
            Object SaveUSERInfo = (Object)Session["UserInfo"];

            SqlConnection sqlCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);

            sqlCon.Open();
            SqlCommand sqlCom = new SqlCommand();
            sqlCom.Connection = sqlCon;
            sqlCom.CommandType = CommandType.StoredProcedure;
            sqlCom.CommandText = "CalOnlineTrans_GetOpeningBalanceMonthBranchWiseNew__SP";

            SqlParameter BranchID = new SqlParameter();
            BranchID.SqlDbType = SqlDbType.Int;
            BranchID.Value = Convert.ToInt32(ddlBranchList.SelectedItem.Value);//pBranchId;
            BranchID.ParameterName = "@BranchID";
            sqlCom.Parameters.Add(BranchID);

            string strYrMonth = Get_DateFormat(txtPaymentDate.Text, "yyyyMMdd");

            SqlParameter YrMonth = new SqlParameter();
            YrMonth.SqlDbType = SqlDbType.VarChar;
            YrMonth.Value = strYrMonth.Substring(0, 6);
            YrMonth.ParameterName = "@YrMonth";
            sqlCom.Parameters.Add(YrMonth);

            SqlParameter RequestType = new SqlParameter();
            RequestType.SqlDbType = SqlDbType.Int;
            RequestType.Value = Convert.ToInt32(2);//pBranchId;
            RequestType.ParameterName = "@RequestType";
            sqlCom.Parameters.Add(RequestType);


            #region Code By Amrita on 22-Apr-2014 As per Client Requirement
            SqlParameter ClientId = new SqlParameter();
            ClientId.SqlDbType = SqlDbType.Int;
            ClientId.Value = Convert.ToInt32(((UserInfo.structUSERInfo)(SaveUSERInfo)).ClientId);
            ClientId.ParameterName = "@ClientId";
            sqlCom.Parameters.Add(ClientId);
            #endregion

            SqlDataAdapter sqlDA = new SqlDataAdapter();
            sqlDA.SelectCommand = sqlCom;

            #region Code by Amrita
            //Procedure created to get closing  balance of last month
            SqlCommand Sqlcmd = new SqlCommand();
            Sqlcmd.Connection = sqlCon;
            Sqlcmd.CommandType = CommandType.StoredProcedure;
            Sqlcmd.CommandText = "CalOnlineTrans_GetLastMonthClosingBalance_SP";


            SqlParameter BranchId = new SqlParameter();
            BranchId.SqlDbType = SqlDbType.Int;
            BranchId.Value = Convert.ToInt32(ddlBranchList.SelectedItem.Value);//pBranchId;
            BranchId.ParameterName = "@BranchId";
            Sqlcmd.Parameters.Add(BranchId);



            SqlParameter Yrmonth = new SqlParameter();
            Yrmonth.SqlDbType = SqlDbType.VarChar;
            Yrmonth.Value = strYrMonth.Substring(0, 6);
            Yrmonth.ParameterName = "@Yrmonth";
            Sqlcmd.Parameters.Add(Yrmonth);

            SqlParameter ReqType = new SqlParameter();
            ReqType.SqlDbType = SqlDbType.Int;
            ReqType.Value = Convert.ToInt32(2);//pBranchId;
            ReqType.ParameterName = "@ReqType";
            Sqlcmd.Parameters.Add(ReqType);



            #region Code By Amrita on 22-Apr-2014 As per Client Requirement
            SqlParameter c_id = new SqlParameter();
            c_id.SqlDbType = SqlDbType.Int;
            c_id.Value = Convert.ToInt32(((UserInfo.structUSERInfo)(SaveUSERInfo)).ClientId);
            c_id.ParameterName = "@ClientId";
            Sqlcmd.Parameters.Add(c_id);
            #endregion


            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = Sqlcmd;

            DataTable dataTable = new DataTable();
            da.Fill(dataTable);
            lastClosingCount = dataTable.Rows.Count;

            DataTable dt = new DataTable();
            sqlDA.Fill(dt);
            currentOpeningCount = dt.Rows.Count;
            sqlCon.Close();


            if (dataTable.Rows.Count > 0)
            {
                if (dt.Rows.Count > 0)
                {

                    transactionAmount = Convert.ToDouble(dt.Rows[0]["TotalTransactionAmount"]);
                    if (dataTable.Rows.Count > 0)
                    {
                        closingBalance = Convert.ToDouble(dataTable.Rows[0]["ClosingBalanceAmount"]);
                    }
                    Double openingAmount = (((Convert.ToDouble(dt.Rows[0]["OpeningAmount"].ToString())) * 50) / 100);
                    if ((closingBalance < openingAmount) || (closingBalance == openingAmount))
                    {
                        //lblOpeningBalance.Text = (Convert.ToDouble(dt.Rows[0]["OpeningAmount"].ToString()) + closingBalance).ToString();
                        lblOpeningBalance.Text = (Convert.ToDouble(dt.Rows[0]["OpeningAmount"].ToString())).ToString();
                        updateOpeningBalance();
                    }
                    //lblAvailableAmt.Text = dt.Rows[0]["TotalAvailableAmount"].ToString();
                    //lblTransactionAmout.Text = dt.Rows[0]["TotalTransactionAmount"].ToString();

                    else
                        if (closingBalance > openingAmount)
                        {
                            lblOpeningBalance.Text = dt.Rows[0]["OpeningAmount"].ToString();
                        }
                    lblYearMonth.Text = dt.Rows[0]["YearMonth"].ToString();
                    if (lblOpeningBalance.Text == "0.00")
                    {
                        lblError.Text = "No opening Balance,Please contact your Account Head!";
                    }
                }
                else
                {
                    lblOpeningBalance.Text = Convert.ToString(dataTable.Rows[0]["OpeningBalanceAmount"]);
                    lblAvailableAmt.Text = "0.00";
                    lblTransactionAmout.Text = "0.00";
                    lblYearMonth.Text = strYrMonth.Substring(0, 6);
                }

            }
            else
            {
                if (dt.Rows.Count > 0)
                {
                    lblOpeningBalance.Text = Convert.ToString(dt.Rows[0]["OpeningAmount"]);

                }
                else
                {
                    lblOpeningBalance.Text = "0.00";
                }
                lblAvailableAmt.Text = "0.00";
                lblTransactionAmout.Text = "0.00";
                lblYearMonth.Text = strYrMonth.Substring(0, 6);
                // lblError.Text = "No opening Balance Found ,Please contact your Account Head!";
            }

            #endregion
        }
        catch (Exception ex)
        {
            lblError.Visible = true;
            lblError.Text = ex.Message;
            lblError.CssClass = "ErrorMessage";
            lblTransactionAmout.Text = "0.00";
        }


    }
    private string Get_DateFormat(string cDate, string cDateFormat)
    {
        try
        {
            string strDate = cDate;
            string[] strArrDate = strDate.Split('/');

            if (strArrDate.Length > 0)
            {
                if (cDateFormat == "yyyyMMdd")
                {
                    strDate = strArrDate[2] + "" + strArrDate[1] + "" + strArrDate[0];

                }
            }

            return strDate;
        }
        catch (Exception ex)
        {
            lblError.Text = ex.Message;
            lblError.CssClass = "ErrorMessage";
            lblError.Visible = true;
            return "";
        }

    }
    protected void txtPaymentDate_TextChanged(object sender, EventArgs e)
    {
        Get_OpeningBalanceMonth_BranchWise();
    }
    protected void lnkViewDetails_Click(object sender, EventArgs e)
    {
        string Value = "window.open('~/Pages/Calculus/ViewOpeningBalanceByBranch.aspx', '_blank', 'height=200,width=400,status=yes,resizable=yes')";
        Page.RegisterClientScriptBlock("OpenPage", Value);
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/pages/menu.aspx", true);
    }
    private void Get_AccountHeadList()
    {

        Object SaveUSERInfo = (Object)Session["UserInfo"];

        SqlConnection sqlCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);

        sqlCon.Open();
        SqlCommand sqlCom = new SqlCommand();
        sqlCom.Connection = sqlCon;
        sqlCom.CommandType = CommandType.StoredProcedure;
        sqlCom.CommandText = "CalOnlineTrans_GetAccountHeadList_New__SP";//Get_AccountHeadList_New

        SqlParameter Is_Active = new SqlParameter();
        Is_Active.SqlDbType = SqlDbType.Bit;
        Is_Active.Value = true;
        Is_Active.ParameterName = "@Is_Active";
        sqlCom.Parameters.Add(Is_Active);

        SqlParameter PaymentType = new SqlParameter();
        PaymentType.SqlDbType = SqlDbType.Int;
        PaymentType.Value = 2;
        PaymentType.ParameterName = "@PaymentType";
        sqlCom.Parameters.Add(PaymentType);

        SqlDataAdapter sqlDA = new SqlDataAdapter();
        sqlDA.SelectCommand = sqlCom;
        DataTable dt = new DataTable();
        sqlDA.Fill(dt);
        sqlCon.Close();

        ddlAccountHeadList.DataTextField = "AccountLedgerName";
        ddlAccountHeadList.DataValueField = "AccountLedgerID";

        ddlAccountHeadList.DataSource = dt;
        ddlAccountHeadList.DataBind();

        ddlAccountHeadList.Items.Insert(0, "--Select--");
        ddlAccountHeadList.SelectedIndex = 0;

    }
    private void Clears_Controls()
    {
        txtBillAmt.Text = "0.00";
        txtBillDate.Text = "";
        txtBillNo.Text = "";
        txtDueAmount.Text = "";
        txtDuedate.Text = "";
        txtMobile_TelNo.Text = "";
        txtPanCard.Text = "";
        txtPayeeNameSearch.Text = "";
        txtRemark.Text = "";
        txtServiceTaxAmt.Text = "";
        txtServiceTaxAmt1.Text = "";
        txtServiceTaxRegNo.Text = "";
        hdnPaymentDetails.Value = "";
        hdnSavingPaymentDetails.Value = "0.00";
        hdnTransactionID.Value = "";
        lblTransactionID.Text = "";

    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        lblError.Text = "";
        Clears_Controls();
        GET_Header_Values();
    }

    private void Get_TransactionDetails(int pBranchID)
    {
        try
        {
            SqlConnection sqlCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);

            sqlCon.Open();
            SqlCommand sqlCom = new SqlCommand();
            sqlCom.Connection = sqlCon;
            sqlCom.CommandType = CommandType.StoredProcedure;
            sqlCom.CommandText = "CalOnlineTrans_GetTransactionDetailsForModify_SP";

            SqlParameter TrasactionID = new SqlParameter();
            TrasactionID.SqlDbType = SqlDbType.VarChar;
            TrasactionID.Value = hdnTransactionID.Value.Trim();
            TrasactionID.ParameterName = "@TrasactionID";
            sqlCom.Parameters.Add(TrasactionID);

            SqlParameter BranchID = new SqlParameter();
            BranchID.SqlDbType = SqlDbType.Int;
            BranchID.Value = pBranchID;
            BranchID.ParameterName = "@BranchID";
            sqlCom.Parameters.Add(BranchID);

            SqlDataAdapter sqlDA = new SqlDataAdapter();
            sqlDA.SelectCommand = sqlCom;
            DataTable dt = new DataTable();
            sqlDA.Fill(dt);
            sqlCon.Close();

            if (dt.Rows.Count > 0)
            {
                txtPaymentDate.Text = dt.Rows[0]["RequestDate"].ToString();
                lblAttachDocumentName.Text = dt.Rows[0]["AttachDocumentPath"].ToString();
                string strTranasctionDetails = "";
                for (int i = 0; i <= dt.Rows.Count - 1; i++)
                {
                    strTranasctionDetails = strTranasctionDetails + dt.Rows[i]["Details"].ToString();
                }

                hdnPaymentDetails.Value = strTranasctionDetails;
            }
        }
        catch (Exception ex)
        {
            lblError.Visible = true;
            lblError.Text = ex.Message;
            lblError.CssClass = "ErrorMessage";
        }
    }
    protected void btnAddtoGrid_Click(object sender, EventArgs e)
    {

    }
    private string UploadAttachment_OnServer()
    {
        try
        {
            string FileSavePath = "";
            if (FileUpload1.FileName != "")
            {
                string fullSitePath = Convert.ToString(ConfigurationSettings.AppSettings["CalculusAttachmentPath"]);
                fullSitePath = fullSitePath.Trim();

                string FileName_Attachment = Convert.ToString(DateTime.Now.ToString("yyyyMMddHHmmss")) + "-" + Convert.ToString(FileUpload1.FileName.Trim());
                FileName_Attachment = FileName_Attachment.Replace(" ", "_");
                FileSavePath = fullSitePath + FileName_Attachment;

                FileInfo FFileName_ValidDBF = new FileInfo(FileSavePath);
                if (FFileName_ValidDBF.Exists)
                {
                    File.Delete(FileSavePath);
                }

                FileUpload1.SaveAs(FileSavePath);
            }
            return FileSavePath;
        }
        catch (Exception ex)
        {
            lblError.Text = ex.Message;
            lblError.CssClass = "ErrorMessage";
            return "";
        }
    }
    #region Code by Amrita to update Amount and Opening Balance
    public void UpdateAmount()
    {
        try
        {
            Object SaveUSERInfo = (Object)Session["UserInfo"];
            string strYrMonth = Get_DateFormat(txtPaymentDate.Text, "yyyyMMdd");
            int bid = Convert.ToInt32(ddlBranchList.SelectedItem.Value);
            int cid = Convert.ToInt32(((UserInfo.structUSERInfo)(SaveUSERInfo)).ClientId);
            SqlConnection sqlCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);

            sqlCon.Open();
            string sql = "UPDATE [CalOnlineTrans_BranchOpeningBalanceInfo_TBL] SET [ClosingBalanceAmount]=@AvlAmt ,[TransactionAmount]=@TransAmt WHERE BranchId=@BranchId and OpeningBalanceYrMonth=@BalYrMonth and RequestType=@RequestType and ClientID=@ClientID";
            SqlCommand sqlCom = new SqlCommand(sql, sqlCon);
            sqlCom.Parameters.AddWithValue("@AvlAmt", Convert.ToDecimal(lblAvailableAmt.Text));
            sqlCom.Parameters.AddWithValue("@TransAmt", Convert.ToDecimal(lblTransactionAmout.Text));
            sqlCom.Parameters.AddWithValue("@BranchId", bid);
            sqlCom.Parameters.AddWithValue("@BalYrMonth", strYrMonth.Substring(0, 6));
            sqlCom.Parameters.AddWithValue("@RequestType", Convert.ToInt32(2));
            sqlCom.Parameters.AddWithValue("@ClientID", cid);
            sqlCom.ExecuteNonQuery();
            sqlCon.Close();




        }
        catch (Exception ex)
        {
            lblError.Text = ex.Message;
            lblError.CssClass = "ErrorMessage";
            return;
        }
    }

    public void getTotalAmount()
    {
        try
        {
            Object SaveUSERInfo = (Object)Session["UserInfo"];

            SqlConnection sqlCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);

            sqlCon.Open();
            SqlCommand sqlCom = new SqlCommand();
            sqlCom.Connection = sqlCon;
            sqlCom.CommandType = CommandType.StoredProcedure;
            sqlCom.CommandText = "CalOnlineTrans_GetTransactionalAmountNew_SP";


            SqlParameter BranchID = new SqlParameter();
            BranchID.SqlDbType = SqlDbType.Int;
            BranchID.Value = Convert.ToInt32(ddlBranchList.SelectedItem.Value);//pBranchId;
            BranchID.ParameterName = "@BranchID";
            sqlCom.Parameters.Add(BranchID);

            string strYrMonth = Get_DateFormat(txtPaymentDate.Text, "yyyyMMdd");


            SqlParameter YrMonth = new SqlParameter();
            YrMonth.SqlDbType = SqlDbType.VarChar;
            YrMonth.Value = strYrMonth.Substring(0, 6);
            YrMonth.ParameterName = "@YrMonth";
            sqlCom.Parameters.Add(YrMonth);

            SqlParameter RequestType = new SqlParameter();
            RequestType.SqlDbType = SqlDbType.Int;
            RequestType.Value = Convert.ToInt32(2);//pBranchId;
            RequestType.ParameterName = "@RequestType";
            sqlCom.Parameters.Add(RequestType);

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
                lblTransactionAmout.Text = dt.Rows[0]["AmountRemaining"].ToString();
                if (Convert.ToDouble(lblTransactionAmout.Text) < Convert.ToDouble(lblOpeningBalance.Text))
                {
                    lblAvailableAmt.Text = Convert.ToString(Convert.ToDecimal(lblOpeningBalance.Text) - Convert.ToDecimal(lblTransactionAmout.Text));
                }
                else
                {
                    lblError.Text = "No Balance Remaining";
                    //  lblTransactionAmout.Text = (0).ToString();
                    lblAvailableAmt.Text = (0).ToString();

                }


            }
            else
            {
                lblAvailableAmt.Text = Convert.ToString(Convert.ToDecimal(lblOpeningBalance.Text));
                lblTransactionAmout.Text = "0.00";

            }
        }
        catch (Exception ex)
        {
            lblError.Visible = true;
            lblError.Text = ex.Message;
            lblError.CssClass = "ErrorMessage";
        }
    }

    public void updateOpeningBalance()
    {
        try
        {
            Object SaveUSERInfo = (Object)Session["UserInfo"];
            string strYrMonth = Get_DateFormat(txtPaymentDate.Text, "yyyyMMdd");
            int bid = Convert.ToInt32(((UserInfo.structUSERInfo)(SaveUSERInfo)).BranchId);
            SqlConnection sqlCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);
            int cid = Convert.ToInt32(((UserInfo.structUSERInfo)(SaveUSERInfo)).ClientId);
            sqlCon.Open();

            string sql = "UPDATE [CalOnlineTrans_BranchOpeningBalanceInfo_TBL] SET [ExtendedOpeningBalance]=@OpeningAmt WHERE BranchId=@BranchId and OpeningBalanceYrMonth=@BalYrMonth and RequestType=@RequestType and ClientID=@ClientID";
            SqlCommand sqlCom = new SqlCommand(sql, sqlCon);
            sqlCom.Parameters.AddWithValue("@OpeningAmt", lblOpeningBalance.Text);
            sqlCom.Parameters.AddWithValue("@BranchId", bid);
            sqlCom.Parameters.AddWithValue("@BalYrMonth", strYrMonth.Substring(0, 6));
            sqlCom.Parameters.AddWithValue("@RequestType", Convert.ToInt32(2));
            sqlCom.Parameters.AddWithValue("@ClientID", cid);

            sqlCom.ExecuteNonQuery();
            sqlCon.Close();



        }
        catch (Exception ex)
        {
            lblError.Text = ex.Message;
            lblError.CssClass = "ErrorMessage";
            return;
        }
    }

    #endregion
    protected void btnRemove_Click(object sender, EventArgs e)
    {

    }
    protected void ddlTaxtype_SelectedIndexChanged(object sender, EventArgs e)
    {

        if (ddlTaxtype.SelectedValue.ToString() == "1")
        {
            Get_ServiceTaxList();
        }
        else if (ddlTaxtype.SelectedValue.ToString() == "2")
        {

            Get_ServiceTaxList12();
        }
        else if (ddlTaxtype.SelectedValue.ToString() == "4")
        {

            Get_ServiceTaxList31();
        }
        else
        {

            Get_ServiceTaxList21();

        }


    }
    private void Get_ServiceTaxList31()
    {
        try
        {

            SqlConnection sqlCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);

            sqlCon.Open();

            SqlCommand sqlCom = new SqlCommand();
            sqlCom.Connection = sqlCon;
            sqlCom.CommandType = CommandType.StoredProcedure;
            sqlCom.CommandText = "CalOnlineTrans_GetServiceTaxList__SP";

            SqlParameter IsActive = new SqlParameter();
            IsActive.SqlDbType = SqlDbType.Bit;
            IsActive.Value = true;
            IsActive.ParameterName = "@IsActive";
            sqlCom.Parameters.Add(IsActive);

            SqlDataAdapter sqlDA = new SqlDataAdapter();
            sqlDA.SelectCommand = sqlCom;

            DataTable dt = new DataTable();
            sqlDA.Fill(dt);


            sqlCon.Close();

            ddlServiceTax.DataTextField = "ServiceTaxPercentage";
            ddlServiceTax.DataValueField = "ServiceTaxID";

            ddlServiceTax.DataSource = dt;
            ddlServiceTax.DataBind();

            ddlServiceTax.Items.Insert(0, "--Select--");
            ddlServiceTax.SelectedIndex = 0;

        }
        catch (Exception ex)
        {
            lblError.Visible = true;
            lblError.Text = ex.Message;
            lblError.CssClass = "ErrorMessage";
        }


    }
    protected void ddlVenderList_SelectedIndexChanged(object sender, EventArgs e)
    {
        Get_ServiceTaxList21();
    }
    protected void ddlVenderList_SelectedIndexChanged1(object sender, EventArgs e)
    {
        Get_RegionDetails12();
    }
    protected void ddladjusttype_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddladjusttype.SelectedItem.Value == "4")
        {
            txtDueAmount.Text = "0.00";
            txtDueAmount.Enabled = false;
        }
        else
        {
            txtDueAmount.Text = "";
            txtDueAmount.Enabled = true;
        }
    }
    protected void ddlBranchList_SelectedIndexChanged(object sender, EventArgs e)
    {

        GET_Header_Values();
        Register_ControlsWith_JavaScript();
    }
    protected void BindTaxType()
    {
        Common common = new Common();
        DataSet ds = new DataSet();

        ds = common.GetCalOnlineTransMasterSearchCode("TaxType", 1);
        if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            ddlTaxtype.DataSource = ds;
            ddlTaxtype.DataValueField = "Code_Id";
            ddlTaxtype.DataTextField = "Description";
            ddlTaxtype.DataBind();
            ddlTaxtype.Items.Insert(0, new ListItem("--Select--", "0"));
        }
    }
    protected void BindAdjustType()
    {
        Common common = new Common();
        DataSet ds = new DataSet();

        ds = common.GetCalOnlineTransMasterSearchCode("AdjustType", 1);
        if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            ddladjusttype.DataSource = ds;
            ddladjusttype.DataValueField = "Code_Id";
            ddladjusttype.DataTextField = "Description";
            ddladjusttype.DataBind();
            ddladjusttype.Items.Insert(0, new ListItem("--Select--", "0"));
        }
    }
}

