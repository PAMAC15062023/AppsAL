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


public partial class Pages_Calculus_BranchPettyCashVoucherRequest : System.Web.UI.Page
{

    Double closingBalance = 0;
    Double transactionAmount = 0;
    private int lastClosingCount;
    private int currentOpeningCount;
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

            GET_Header_Values();
            Register_ControlsWith_JavaScript();


        }

        string StrScript = "<script language='javascript'> javascript:Page_load_validation(); </script>";
        Page.RegisterStartupScript("OnLoad_21", StrScript);

        InsertClosingAmount();
        UpdateAmount();
        UpdateBankAmount();
        Get_OpeningBalanceMonth_BranchWise();
        getTotalAmount();
    }
    private void Register_ControlsWith_JavaScript()
    {
        btnAddtoGrid.Attributes.Add("onclick", "javascript:return AddColumnToGrid();");
        btnRemove.Attributes.Add("onclick", "javascript:return RemoveColumnFromGrid();");
        btnSave.Attributes.Add("onclick", "javascript:return Validate_Headers();");

    }
    private void GET_Header_Values()
    {
        Object SaveUSERInfo = (Object)Session["UserInfo"];

        lblBranch.Text = Convert.ToString(((UserInfo.structUSERInfo)(SaveUSERInfo)).BranchName);

        Get_RegionDetails(Convert.ToInt32(((UserInfo.structUSERInfo)(SaveUSERInfo)).BranchId));
        Get_VerticalList();
        Get_ActivityList(100);
        Get_AccountHeadList();


        if (hdnTransactionID.Value != "")
        {
            Get_TransactionDetails(Convert.ToInt32(((UserInfo.structUSERInfo)(SaveUSERInfo)).BranchId));
        }
        if (txtPaymentDate.Text != "")
        {
            Get_OpeningBalanceMonth_BranchWise();
        }
        getTotalAmount();
    }
    private void Get_RegionDetails(int pBranchID)
    {
        try
        {
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
                lblRegion.Text = dt.Rows[0]["Region_Name"].ToString();
                txtPaymentDate.Text = dt.Rows[0]["PaymentRequestDate"].ToString();
                lblWeek.Text = "Week " + dt.Rows[0]["theWeekWithinMonth"].ToString();
            }

        }
        catch (Exception ex)
        {
            lblMessage.Visible = true;
            lblMessage.Text = ex.Message;
            lblMessage.CssClass = "ErrorMessage";
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

            ddlVerticalList.DataTextField = "Vertical_Name";
            ddlVerticalList.DataValueField = "Vertical_ID";

            ddlVerticalList.DataSource = dt;
            ddlVerticalList.DataBind();

            ddlVerticalList.Items.Insert(0, "--Select--");
            ddlVerticalList.SelectedIndex = 0;



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

            ddlActivityList.DataTextField = "Activity_Name";
            ddlActivityList.DataValueField = "Activity_ID";

            ddlActivityList.DataSource = dt;
            ddlActivityList.DataBind();

            ddlActivityList.Items.Insert(0, "--Select--");
            ddlActivityList.SelectedIndex = 0;

        }
        catch (Exception ex)
        {
            lblMessage.Visible = true;
            lblMessage.Text = ex.Message;
            lblMessage.CssClass = "ErrorMessage";
        }
    }
    protected void ddlVerticalList_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlVerticalList.SelectedIndex != 0)
        {
            Get_ActivityList(Convert.ToInt32(ddlVerticalList.SelectedItem.Value));
            ddlActivityList.Focus();
        }
        else
        {
            Get_ActivityList(100);

        }
    }
    private void Get_AccountHeadList()
    {

        Object SaveUSERInfo = (Object)Session["UserInfo"];

        SqlConnection sqlCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);

        sqlCon.Open();
        SqlCommand sqlCom = new SqlCommand();
        sqlCom.Connection = sqlCon;
        sqlCom.CommandType = CommandType.StoredProcedure;
        sqlCom.CommandText = "CalOnlineTrans_Get_AccountHeadList_Petty_SP";

        SqlParameter @Is_Active = new SqlParameter();
        @Is_Active.SqlDbType = SqlDbType.Bit;
        @Is_Active.Value = true;
        @Is_Active.ParameterName = "@Is_Active";
        sqlCom.Parameters.Add(@Is_Active);

        SqlParameter PaymentType = new SqlParameter();
        PaymentType.SqlDbType = SqlDbType.Int;
        PaymentType.Value = 1;
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
    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            Insert_PaymentRequest();
            GET_Header_Values();
            UpdateAmount();
            Clear_Controls();

        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
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
            sqlCom.CommandText = "CalOnlineTrans_Insert_PettyCash_VoucherRequest_SP";//Insert_PettyCashVoucherRequest_new

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

            SqlParameter AttachDocumentPath = new SqlParameter();
            AttachDocumentPath.SqlDbType = SqlDbType.VarChar;
            AttachDocumentPath.Value = UploadAttachment_OnServer();
            AttachDocumentPath.ParameterName = "@AttachDocumentPath";
            sqlCom.Parameters.Add(AttachDocumentPath);

            #region Code By Amrita on 22-Apr-2014 As per Client Requirement
            SqlParameter ClientId = new SqlParameter();
            ClientId.SqlDbType = SqlDbType.Int;
            ClientId.Value = Convert.ToInt32(((UserInfo.structUSERInfo)(SaveUSERInfo)).ClientId);
            ClientId.ParameterName = "@ClientId";
            sqlCom.Parameters.Add(ClientId);
            #endregion



            SqlParameter TransactionDetails = new SqlParameter();
            TransactionDetails.SqlDbType = SqlDbType.VarChar;
            TransactionDetails.Value = hdnPaymentDetails.Value;
            TransactionDetails.ParameterName = "@TransactionDetails";
            sqlCom.Parameters.Add(TransactionDetails);

            SqlParameter VarResult = new SqlParameter();
            VarResult.SqlDbType = SqlDbType.VarChar;
            VarResult.Value = hdnTransactionID.Value;
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
    private void Clear_Controls()
    {
        txtAmount.Text = "";
        txtClientName.Text = "";
        txtNaration.Text = "";
        hdnPaymentDetails.Value = "";
        hdnSavingPaymentDetails.Value = "0.00";
        hdnTransactionID.Value = "";
        lblTransactionID.Text = "";

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
            sqlCom.CommandText = "CalOnlineTrans_GetTransactionDetailsForCashVoucher_SP";

            SqlParameter TrasactionID = new SqlParameter();
            TrasactionID.SqlDbType = SqlDbType.VarChar;
            TrasactionID.Value = hdnTransactionID.Value.Trim();
            TrasactionID.ParameterName = "@TrasactionID";
            sqlCom.Parameters.Add(TrasactionID);

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
            lblMessage.Visible = true;
            lblMessage.Text = ex.Message;
            lblMessage.CssClass = "ErrorMessage";
        }

    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/pages/menu.aspx", true);
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
            lblMessage.Text = ex.Message;
            lblMessage.CssClass = "ErrorMessage";
            return "";
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
            sqlCom.CommandText = "CalOnlineTrans_GetOpeningBalanceMonth__BranchWise_SP";//Get_OpeningBalanceMonth_BranchWise_new23Apr,Get_OpeningBalanceMonth_BranchWise_new12

            SqlParameter BranchID = new SqlParameter();
            BranchID.SqlDbType = SqlDbType.Int;
            BranchID.Value = Convert.ToInt32(((UserInfo.structUSERInfo)(SaveUSERInfo)).BranchId);//pBranchId;
            BranchID.ParameterName = "@BranchID";
            sqlCom.Parameters.Add(BranchID);

            string strYrMonth = Get_DateFormat(txtPaymentDate.Text, "yyyyMMdd");//txtPaymentDate.Text

            SqlParameter YrMonth = new SqlParameter();
            YrMonth.SqlDbType = SqlDbType.VarChar;
            YrMonth.Value = strYrMonth.Substring(0, 6);
            YrMonth.ParameterName = "@YrMonth";
            sqlCom.Parameters.Add(YrMonth);

            SqlParameter RequestType = new SqlParameter();
            RequestType.SqlDbType = SqlDbType.Int;
            RequestType.Value = Convert.ToInt32(1);//pBranchId;
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
            Sqlcmd.CommandText = "CalOnlineTrans_GetLastMonthClosingBalancePetty___SP";//GetLastMonthClosingBalancePetty


            SqlParameter BranchId = new SqlParameter();
            BranchId.SqlDbType = SqlDbType.Int;
            BranchId.Value = Convert.ToInt32(((UserInfo.structUSERInfo)(SaveUSERInfo)).BranchId);//pBranchId;
            BranchId.ParameterName = "@BranchId";
            Sqlcmd.Parameters.Add(BranchId);



            SqlParameter Yrmonth = new SqlParameter();
            Yrmonth.SqlDbType = SqlDbType.VarChar;
            Yrmonth.Value = strYrMonth.Substring(0, 6);
            Yrmonth.ParameterName = "@Yrmonth";
            Sqlcmd.Parameters.Add(Yrmonth);

            SqlParameter ReqType = new SqlParameter();
            ReqType.SqlDbType = SqlDbType.Int;
            ReqType.Value = Convert.ToInt32(1);//pBranchId;
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
                hdnClosingAMT.Value = Convert.ToString(dataTable.Rows[0]["ClosingBalanceAmount"]);
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
                        //   lblOpeningBalance.Text = (Convert.ToDouble(dt.Rows[0]["OpeningAmount"].ToString()) + closingBalance).ToString();
                        lblOpeningBalance.Text = (Convert.ToDouble(dt.Rows[0]["OpeningAmount"].ToString())).ToString();
                        //lblHOAmout.Text = (Convert.ToDouble(dt.Rows[0]["HOAmount"].ToString())).ToString();
                        lblHOWthdrwAmt.Text = (Convert.ToDouble(dt.Rows[0]["BalHOAmount"].ToString())).ToString();

                        updateOpeningBalance();
                    }
                    //lblAvailableAmt.Text = dt.Rows[0]["TotalAvailableAmount"].ToString();
                    //lblTransactionAmout.Text = dt.Rows[0]["TotalTransactionAmount"].ToString();

                    else
                        if (closingBalance > openingAmount)
                        {
                            lblOpeningBalance.Text = dt.Rows[0]["OpeningAmount"].ToString();
                            //lblHOAmout.Text = (Convert.ToDouble(dt.Rows[0]["HOAmount"].ToString())).ToString();
                            lblHOWthdrwAmt.Text = (Convert.ToDouble(dt.Rows[0]["BalHOAmount"].ToString())).ToString();
                        }
                    lblYearMonth.Text = dt.Rows[0]["YearMonth"].ToString();
                    if (lblOpeningBalance.Text == "0.00")
                    {
                        //lblMessage.Text = "No opening Balance,Please contact your Account Head!";
                    }
                }
                else
                {
                    lblOpeningBalance.Text = "0.00"; //Convert.ToString(dataTable.Rows[0]["OpeningBalanceAmount"]);
                    //lblHOAmout.Text = (Convert.ToDouble(dt.Rows[0]["HOAmount"].ToString())).ToString();
                    lblHOWthdrwAmt.Text = "0.00"; //(Convert.ToDouble(dt.Rows[0]["BalHOAmount"].ToString())).ToString();
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
                    //lblHOAmout.Text = (Convert.ToDouble(dt.Rows[0]["HOAmount"].ToString())).ToString();
                    lblHOWthdrwAmt.Text = (Convert.ToDouble(dt.Rows[0]["BalHOAmount"].ToString())).ToString();

                }
                else
                {
                    lblOpeningBalance.Text = "0.00";
                    //lblHOAmout.Text = "0.00";
                    lblHOWthdrwAmt.Text = "0.00";
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
            lblMessage.Visible = true;
            lblMessage.Text = ex.Message;
            lblMessage.CssClass = "ErrorMessage";
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
            lblMessage.Text = ex.Message;
            lblMessage.CssClass = "ErrorMessage";
            lblMessage.Visible = true;
            return "";
        }

    }
    //  #region Code by Amrita to update Amount and Opening Balance
    public void UpdateAmount()
    {
        try
        {
            Object SaveUSERInfo = (Object)Session["UserInfo"];
            string strYrMonth = Get_DateFormat(txtPaymentDate.Text, "yyyyMMdd");
            int bid = Convert.ToInt32(((UserInfo.structUSERInfo)(SaveUSERInfo)).BranchId);
            int cid = Convert.ToInt32(((UserInfo.structUSERInfo)(SaveUSERInfo)).ClientId);
            SqlConnection sqlCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);

            sqlCon.Open();
            string sql = "UPDATE [CalOnlineTrans_BranchOpeningBalanceInfo_TBL] SET [ClosingBalanceAmount]=@AvlAmt ,[TransactionAmount]=@TransAmt WHERE BranchId=@BranchId and OpeningBalanceYrMonth=@BalYrMonth and RequestType=@RequestType and ClientID=@ClientID";
            SqlCommand sqlCom = new SqlCommand(sql, sqlCon);
            sqlCom.Parameters.AddWithValue("@AvlAmt", Convert.ToDecimal(lblAvailableAmt.Text));
            sqlCom.Parameters.AddWithValue("@TransAmt", Convert.ToDecimal(lblTransactionAmout.Text));
            sqlCom.Parameters.AddWithValue("@BranchId", bid);
            sqlCom.Parameters.AddWithValue("@BalYrMonth", strYrMonth.Substring(0, 6));
            sqlCom.Parameters.AddWithValue("@RequestType", Convert.ToInt32(1));
            sqlCom.Parameters.AddWithValue("@ClientID", cid);
            sqlCom.ExecuteNonQuery();
            sqlCon.Close();




        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
            lblMessage.CssClass = "ErrorMessage";
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
            sqlCom.CommandText = "CalOnlineTrans_Get_Transactional_Amount_New_SP";


            SqlParameter BranchID = new SqlParameter();
            BranchID.SqlDbType = SqlDbType.Int;
            BranchID.Value = Convert.ToInt32(((UserInfo.structUSERInfo)(SaveUSERInfo)).BranchId);//pBranchId;
            BranchID.ParameterName = "@BranchID";
            sqlCom.Parameters.Add(BranchID);

            string strYrMonth = Get_DateFormat(txtPaymentDate.Text, "yyyyMMdd");//txtPaymentDate.Text


            SqlParameter YrMonth = new SqlParameter();
            YrMonth.SqlDbType = SqlDbType.VarChar;
            YrMonth.Value = strYrMonth.Substring(0, 6);
            YrMonth.ParameterName = "@YrMonth";
            sqlCom.Parameters.Add(YrMonth);

            SqlParameter RequestType = new SqlParameter();
            RequestType.SqlDbType = SqlDbType.Int;
            RequestType.Value = Convert.ToInt32(1);//pBranchId;
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
                if (Convert.ToDouble(lblTransactionAmout.Text) < (Convert.ToDouble(lblOpeningBalance.Text) + Convert.ToDouble(lblHOWthdrwAmt.Text)))
                {
                    lblAvailableAmt.Text = Convert.ToString(Convert.ToDecimal(lblOpeningBalance.Text) + Convert.ToDecimal(lblHOWthdrwAmt.Text) - Convert.ToDecimal(lblTransactionAmout.Text));
                }
                else
                {
                    lblMessage.Text = "No Balance Remaining";
                    //  lblTransactionAmout.Text = (0).ToString();
                    lblAvailableAmt.Text = (0).ToString();

                }


            }
            else
            {
                lblAvailableAmt.Text = Convert.ToString(Convert.ToDecimal(lblOpeningBalance.Text) + Convert.ToDecimal(lblHOWthdrwAmt.Text));
                lblTransactionAmout.Text = "0.00";

            }
        }
        catch (Exception ex)
        {
            lblMessage.Visible = true;
            lblMessage.Text = ex.Message;
            lblMessage.CssClass = "ErrorMessage";
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
            sqlCom.Parameters.AddWithValue("@RequestType", Convert.ToInt32(1));
            sqlCom.Parameters.AddWithValue("@ClientID", cid);
            sqlCom.ExecuteNonQuery();
            sqlCon.Close();



        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
            lblMessage.CssClass = "ErrorMessage";
            return;
        }
    }
    public void InsertClosingAmount()
    {
        try
        {
            Object SaveUSERInfo = (Object)Session["UserInfo"];

            SqlConnection sqlCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);

            sqlCon.Open();
            SqlCommand sqlCom = new SqlCommand();
            sqlCom.Connection = sqlCon;
            sqlCom.CommandType = CommandType.StoredProcedure;
            sqlCom.CommandText = "CalOnlineTrans_InsertLastMonthClosingBalancePetty_SP"; //InsertLastMonthClosingBalancePetty11jan //getLastMonthClosingBalancePetty,InsertLastMonthClosingBalancePetty1


            SqlParameter BranchID = new SqlParameter();
            BranchID.SqlDbType = SqlDbType.Int;
            BranchID.Value = Convert.ToInt32(((UserInfo.structUSERInfo)(SaveUSERInfo)).BranchId);//pBranchId;
            BranchID.ParameterName = "@BranchID";
            sqlCom.Parameters.Add(BranchID);

            string strYrMonth = Get_DateFormat(txtPaymentDate.Text, "yyyyMMdd");//txtPaymentDate.Text


            SqlParameter Yrmonth = new SqlParameter();
            Yrmonth.SqlDbType = SqlDbType.VarChar;
            Yrmonth.Value = strYrMonth.Substring(0, 6);
            Yrmonth.ParameterName = "@Yrmonth";
            sqlCom.Parameters.Add(Yrmonth);

            SqlParameter ReqType = new SqlParameter();
            ReqType.SqlDbType = SqlDbType.Int;
            ReqType.Value = Convert.ToInt32(1);//pBranchId;
            ReqType.ParameterName = "@ReqType";
            sqlCom.Parameters.Add(ReqType);



            SqlParameter c_id = new SqlParameter();
            c_id.SqlDbType = SqlDbType.Int;
            c_id.Value = Convert.ToInt32(((UserInfo.structUSERInfo)(SaveUSERInfo)).ClientId);
            c_id.ParameterName = "@ClientId";
            sqlCom.Parameters.Add(c_id);


            SqlParameter UserID = new SqlParameter();
            UserID.SqlDbType = SqlDbType.VarChar;
            UserID.Value = Convert.ToString(((UserInfo.structUSERInfo)(SaveUSERInfo)).UserId);
            UserID.ParameterName = "@User_ID";
            sqlCom.Parameters.Add(UserID);

            int SqlRow = 0;
            SqlRow = sqlCom.ExecuteNonQuery();

            //string RowEffected = Convert.ToString(sqlCmd.Parameters["@VarResult"].Value);
            //lblHOAmount.Text = RowEffected;

            if (SqlRow > 0)
            {
                //lblTransactionAmout.Text = dt.Rows[0]["AmountRemaining"].ToString();
            }
            else
            {
            }
        }
        catch (Exception ex)
        {
            lblMessage.Visible = true;
            lblMessage.Text = ex.Message;
            lblMessage.CssClass = "ErrorMessage";
        }
    }

    public void UpdateBankAmount()
    {
        try
        {
            Object SaveUSERInfo = (Object)Session["UserInfo"];

            SqlConnection sqlCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);

            sqlCon.Open();
            SqlCommand sqlCom = new SqlCommand();
            sqlCom.Connection = sqlCon;
            sqlCom.CommandType = CommandType.StoredProcedure;
            sqlCom.CommandText = "CalOnlineTrans_InsertLastMonthBankClosingBalanceNew_SP";//InsertLastMonthBankClosingBalanceNew

            SqlParameter BranchID = new SqlParameter();
            BranchID.SqlDbType = SqlDbType.Int;
            BranchID.Value = Convert.ToInt32(((UserInfo.structUSERInfo)(SaveUSERInfo)).BranchId);//pBranchId;
            BranchID.ParameterName = "@BranchID";
            sqlCom.Parameters.Add(BranchID);

            string strYrMonth = Get_DateFormat(txtPaymentDate.Text, "yyyyMMdd");//txtPaymentDate.Text


            SqlParameter Yrmonth = new SqlParameter();
            Yrmonth.SqlDbType = SqlDbType.VarChar;
            Yrmonth.Value = strYrMonth.Substring(0, 6);
            Yrmonth.ParameterName = "@Yrmonth";
            sqlCom.Parameters.Add(Yrmonth);

            SqlParameter ReqType = new SqlParameter();
            ReqType.SqlDbType = SqlDbType.Int;
            ReqType.Value = Convert.ToInt32(1);//pBranchId;
            ReqType.ParameterName = "@ReqType";
            sqlCom.Parameters.Add(ReqType);



            SqlParameter c_id = new SqlParameter();
            c_id.SqlDbType = SqlDbType.Int;
            c_id.Value = Convert.ToInt32(((UserInfo.structUSERInfo)(SaveUSERInfo)).ClientId);
            c_id.ParameterName = "@ClientId";
            sqlCom.Parameters.Add(c_id);


            SqlParameter UserID = new SqlParameter();
            UserID.SqlDbType = SqlDbType.VarChar;
            UserID.Value = Convert.ToString(((UserInfo.structUSERInfo)(SaveUSERInfo)).UserId);
            UserID.ParameterName = "@User_ID";
            sqlCom.Parameters.Add(UserID);

            int SqlRow = 0;
            SqlRow = sqlCom.ExecuteNonQuery();

            //string RowEffected = Convert.ToString(sqlCmd.Parameters["@VarResult"].Value);
            //lblHOAmount.Text = RowEffected;

            if (SqlRow > 0)
            {
                //lblTransactionAmout.Text = dt.Rows[0]["AmountRemaining"].ToString();
            }
            else
            {
            }


        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
            lblMessage.CssClass = "ErrorMessage";
            return;
        }
    }
    protected void txtPaymentDate_TextChanged(object sender, EventArgs e)
    {
        InsertClosingAmount();
        UpdateAmount();
        UpdateBankAmount();
        Get_OpeningBalanceMonth_BranchWise();
        getTotalAmount();
    }
}


