using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;


public partial class Pages_ChequeProcessingNEW_ModifyChequeEntry : System.Web.UI.Page
{
    public string DropboxValue;
    protected void Page_Load(object sender, EventArgs e)
    
    {
        
        if (Session["UserInfo"] == null)
        {
            Response.Redirect("~/Pages/InvalidRequest.aspx");
        }

        if (!IsPostBack)
        {
                if (Request.QueryString["TID"] != null)
                {
                    hdnTransactionDetailID.Value = Request.QueryString["TID"].ToString();
                }
                Get_DropBoxDataForMod();




                if (Cache["ReasonListNew"] == null)
                {
                    Get_ReasonList();
                }
                else
                {
                    ddlReasonList.DataTextField = "Reason";
                    ddlReasonList.DataValueField = "ReasonID";

                    ddlReasonList.DataSource = (DataTable)Cache["ReasonListNew"];
                    ddlReasonList.DataBind();

                    ddlReasonList.Items.Insert(0, "-Select-");
                    ddlReasonList.SelectedIndex = 0;
                }

                Get_DataForMod();
                ddlDropBoxList.Focus();
                Get_Bin_Logo_Details();
                Register_ControlsWith_JavaScript();
            }
    }

private void Register_ControlsWith_JavaScript()
{
    ddlDropBoxList.Attributes.Add("onKeyDown", "javascript:if(event.keyCode==13){ event.keyCode=9};");
    ddlReasonList.Attributes.Add("onKeyDown", "javascript:if(event.keyCode==13){ event.keyCode=9};");
    ddlInstrumentType.Attributes.Add("onKeyDown", "javascript:if(event.keyCode==13){event.keyCode=9};");
    ddlSignature.Attributes.Add("onKeyDown", "javascript:if(event.keyCode==13){ event.keyCode=9};");

    txtChequeNo.Attributes.Add("onKeyDown", "javascript:if(event.keyCode==13){ event.keyCode=9;Validate_ChequeNo()};");
    txtChequeAmt.Attributes.Add("onKeyDown", "javascript:if(event.keyCode==13) {event.keyCode=9;Validate_ChequeAmt()};");
    txtChequeDate.Attributes.Add("onKeyDown", "javascript:if(event.keyCode==13) { event.keyCode=9;ChequeDate_Validate()};");
    txtCardNo.Attributes.Add("onKeyDown", "javascript:if(event.keyCode==13) {event.keyCode=9;Validate_CardNo()};");
    //txtMICRCode.Attributes.Add("onKeyDown", "javascript:if(event.keyCode==13) {event.keyCode=9;Validate_MICRCode()};");
    TextBox1.Attributes.Add("onKeyDown", "javascript:if(event.keyCode==13) {event.keyCode=9;Validate_MICRCode()};");
    txtAcountNo.Attributes.Add("onKeyDown", "javascript:if(event.keyCode==13) {event.keyCode=9;Validate_AccountNo()};");

    txtTransactionCode.Attributes.Add("onKeyDown", "javascript:if(event.keyCode==13) event.keyCode=9;Validate_TransactionCode();");
    txtContactNo.Attributes.Add("onKeyDown", "javascript:if(event.keyCode==13) event.keyCode=9;");
    txtReceiptNo.Attributes.Add("onKeyDown", "javascript:if(event.keyCode==13) event.keyCode=9;");
    txtRemark.Attributes.Add("onKeyDown", "javascript:if(event.keyCode==13) event.keyCode=9;");
    btnUpdate.Attributes.Add("onclick", "javascript:return Validate_Save();");

}

private void Get_Bin_Logo_Details()
{
    try
    {
        if (Cache["BinLogoDetails"] == null)
        {

            Object SaveUSERInfo = (Object)Session["UserInfo"];

            SqlConnection sqlcon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);


            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlcon;
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.CommandText = "Get_BinLogoDetails";
            sqlcmd.CommandTimeout = 0;

            sqlcon.Open();
            SqlDataAdapter sqlda = new SqlDataAdapter();
            sqlda.SelectCommand = sqlcmd;

            DataTable dt = new DataTable();
            sqlda.Fill(dt);

            Cache["BinLogoDetails"] = dt;

            sqlcon.Close();

            if (dt.Rows.Count > 0)
            {
                string strBinLogos = "";
                hdnBinLogoDetails.Value = "";

                for (int i = 0; i <= dt.Rows.Count - 1; i++)
                {
                    strBinLogos = strBinLogos + dt.Rows[i]["BinLogoDetails"].ToString().Trim();
                }
                hdnBinLogoDetails.Value = strBinLogos;

            }
        }
        else
        {
            DataTable dt = (DataTable)Cache["BinLogoDetails"];

            if (dt.Rows.Count > 0)
            {
                string strBinLogos = "";
                hdnBinLogoDetails.Value = "";

                for (int i = 0; i <= dt.Rows.Count - 1; i++)
                {
                    strBinLogos = strBinLogos + dt.Rows[i]["BinLogoDetails"].ToString().Trim();
                }
                hdnBinLogoDetails.Value = strBinLogos;

            }
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
     private void Get_DropBoxDataForMod()
    {
        try
        {
            Object SaveUSERInfo = (Object)Session["UserInfo"];

            SqlConnection sqlcon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);


            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlcon;
            sqlcmd.CommandType = CommandType.StoredProcedure;
            //sqlcmd.CommandText = "Get_ReasonList";
            sqlcmd.CommandText = "Get_DropboxDataForMod";
            sqlcmd.CommandTimeout = 0;



            SqlParameter BranchID = new SqlParameter();
            BranchID.SqlDbType = SqlDbType.Int;
            BranchID.Value = Convert.ToInt32(((UserInfo.structUSERInfo)(SaveUSERInfo)).BranchId);
            BranchID.ParameterName = "@BranchID";
            sqlcmd.Parameters.Add(BranchID);

            SqlParameter TransactionDetailID = new SqlParameter();
            TransactionDetailID.SqlDbType = SqlDbType.Int;
            TransactionDetailID.Value = hdnTransactionDetailID.Value;
            TransactionDetailID.ParameterName = "@TransactionDetailID";
            sqlcmd.Parameters.Add(TransactionDetailID);


            sqlcon.Open();
            SqlDataAdapter sqlda = new SqlDataAdapter();
            sqlda.SelectCommand = sqlcmd;
            DataTable dt = new DataTable();
            sqlda.Fill(dt);
            sqlcon.Close();

            ddlDropBoxList.DataTextField = "DropBox_code";
            ddlDropBoxList.DataValueField = "Dropbox_name";
            ddlDropBoxList.DataSource = dt;
            ddlDropBoxList.DataBind();

            ddlDropBoxList.Items.Insert(0, "-Select-");
            ddlDropBoxList.SelectedIndex = 0;

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

     private void Get_ReasonList()
    {
        SqlConnection sqlcon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);

        try
        {
            Object SaveUSERInfo = (Object)Session["UserInfo"];       

            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlcon;
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.CommandText = "Get_ReasonListNew";
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
           

            Cache["ReasonListNew"] = dt;

            ddlReasonList.DataTextField = "Reason";
            ddlReasonList.DataValueField = "ReasonID";
            ddlReasonList.DataSource = dt;
            ddlReasonList.DataBind();

            ddlReasonList.Items.Insert(0, "-Select-");
            ddlReasonList.SelectedIndex = 0;

        }
        catch (Exception ex)
        {
            lblMessage.Visible = true;
            lblMessage.Text = ex.Message;
            lblMessage.CssClass = "ErrorMessage";

        }
        finally
        {
            sqlcon.Close();
        }

    }
      private void Get_DataForMod()
    {
        try
        {
            Object SaveUSERInfo = (Object)Session["UserInfo"];

            SqlConnection sqlcon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);


            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlcon;
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.CommandText = "Get_ChequeDetailForModification";
            sqlcmd.CommandTimeout = 0;


            SqlParameter BranchID = new SqlParameter();
            BranchID.SqlDbType = SqlDbType.Int;
            BranchID.Value = Convert.ToInt32(((UserInfo.structUSERInfo)(SaveUSERInfo)).BranchId);
            BranchID.ParameterName = "@BranchID";
            sqlcmd.Parameters.Add(BranchID);

            SqlParameter TransactionDetailID = new SqlParameter();
            TransactionDetailID.SqlDbType = SqlDbType.Int;
            TransactionDetailID.Value = hdnTransactionDetailID.Value;
            TransactionDetailID.ParameterName = "@TransactionDetailID";
            sqlcmd.Parameters.Add(TransactionDetailID);



            sqlcon.Open();
            SqlDataAdapter sqlda = new SqlDataAdapter();
            sqlda.SelectCommand = sqlcmd;
            DataSet ds = new DataSet();
            sqlda.Fill(ds);
            sqlcon.Close();


            if (ds.Tables.Count > 0)
            {
                txtBatchNo.Text = ds.Tables[0].Rows[0]["BatchNo"].ToString();
                lblBatchDate.Text = ds.Tables[0].Rows[0]["BatchDate"].ToString();
                //lblNoOfCheque.Text = ds.Tables[0].Rows[0]["TotalCheques"].ToString();
                //lblTotalChqueCapture.Text = ds.Tables[0].Rows[0]["TotalChequesCaptured"].ToString();
                hdnEntryStart.Value = ds.Tables[0].Rows[0]["EntryDate"].ToString();
                hdnDate.Value = ds.Tables[0].Rows[0]["ChequeDepositDate"].ToString();
                //lblChequeCapturedByUser.Text = ds.Tables[0].Rows[0]["TotalChequesCapturedByUser"].ToString();
                txtAcountNo.Text = ds.Tables[0].Rows[0]["AccountNo"].ToString();
                txtCardNo.Text = ds.Tables[0].Rows[0]["CardNo"].ToString();
                txtChequeAmt.Text = ds.Tables[0].Rows[0]["ChequeAmt"].ToString();
                hdnChqDate.Value = ds.Tables[0].Rows[0]["ChequeDate"].ToString();
                txtChequeDate.Text = hdnChqDate.Value;


                txtChequeNo.Text = ds.Tables[0].Rows[0]["ChequeNo"].ToString();
                txtContactNo.Text = ds.Tables[0].Rows[0]["ContactNo"].ToString();
                TextBox1.Text = ds.Tables[0].Rows[0]["MICRCode"].ToString();
                lblBankName.Text = ds.Tables[0].Rows[0]["Bank_Name"].ToString();
                lblBranchName.Text = ds.Tables[0].Rows[0]["Branch_Name"].ToString();
                lblCity.Text = ds.Tables[0].Rows[0]["City"].ToString();
                txtReceiptNo.Text = ds.Tables[0].Rows[0]["ReceiptNo"].ToString();
                txtRemark.Text = ds.Tables[0].Rows[0]["Remark"].ToString();
                txtTransactionCode.Text = ds.Tables[0].Rows[0]["TransactionCode"].ToString();

                ddlInstrumentType.SelectedValue = ds.Tables[0].Rows[0]["IntrumentType"].ToString();
                ddlReasonList.SelectedValue = ds.Tables[0].Rows[0]["ReasonID"].ToString();
                ddlSignature.SelectedValue = ds.Tables[0].Rows[0]["SignOnCheque"].ToString();

                hdnChequeStaus.Value = ds.Tables[0].Rows[0]["ChequeType"].ToString();
                lblChequeStatus.Text = ds.Tables[0].Rows[0]["ChequeType"].ToString();

                hdnIsSuspenseCheque.Value = ds.Tables[0].Rows[0]["ChequeType"].ToString();
                //ddlDropBoxList.SelectedValue = ds.Tables[0].Rows[0]["DropBoxID"].ToString();

                DropboxValue = ds.Tables[0].Rows[0]["DropBoxID"].ToString();
                for (int i = 0; i <= ddlDropBoxList.Items.Count - 1; i++)
                {
                    if (ddlDropBoxList.Items[i].Value.Contains(DropboxValue))
                    {
                        ddlDropBoxList.SelectedIndex = i;
                    }

                }



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
   
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Pages/Menu.aspx", true); 
    }
    protected void btnBackToSearch_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Pages/ChequeProcessingNEW/ValidateCheque_Search.aspx", true); 
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        Object SaveUSERInfo = (Object)Session["UserInfo"];

        try
        {
            SqlConnection sqlCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);


            SqlCommand sqlCom = new SqlCommand();
            sqlCom.Connection = sqlCon;
            sqlCom.CommandType = CommandType.StoredProcedure;
            sqlCom.CommandText = "Update_C_ChequeCapureInfo";
            sqlCom.CommandTimeout = 0;


            SqlParameter BranchID = new SqlParameter();
            BranchID.SqlDbType = SqlDbType.Int;
            BranchID.Value = Convert.ToInt32(((UserInfo.structUSERInfo)(SaveUSERInfo)).BranchId);
            BranchID.ParameterName = "@BranchID";
            sqlCom.Parameters.Add(BranchID);

            SqlParameter TransactionDetailID = new SqlParameter();
            TransactionDetailID.SqlDbType = SqlDbType.Int;
            TransactionDetailID.Value = Convert.ToInt32(hdnTransactionDetailID.Value);
            TransactionDetailID.ParameterName = "@TransactionDetailID";
            sqlCom.Parameters.Add(TransactionDetailID);

            SqlParameter BatchNo = new SqlParameter();
            BatchNo.SqlDbType = SqlDbType.VarChar;
            BatchNo.Value = txtBatchNo.Text.Trim();
            BatchNo.ParameterName = "@BatchNo";
            sqlCom.Parameters.Add(BatchNo);

            int intDropBoxID = 0;
            if (ddlDropBoxList.SelectedIndex != 0)
            {
                string strDropBoxDetails = "";
                strDropBoxDetails = ddlDropBoxList.SelectedItem.Value.Trim();
                string[] RowDetails = strDropBoxDetails.Split('|');
                intDropBoxID = Convert.ToInt32(RowDetails[0]);
            }

            //if (hdnDropboxID.Value != "0")
            //{
            //    ddlDropBoxList.SelectedIndex =Convert.ToInt32(hdnDropboxID.Value);
            //    string strDropBoxDetails = "";
            //    strDropBoxDetails = ddlDropBoxList.SelectedItem.Value.Trim();
            //    string[] RowDetails = strDropBoxDetails.Split('|');
            //    intDropBoxID = Convert.ToInt32(RowDetails[0]);
            //}

            SqlParameter DropBoxID = new SqlParameter();
            DropBoxID.SqlDbType = SqlDbType.Int;
            DropBoxID.Value = intDropBoxID;//Convert.ToInt32(DropboxValue);//intDropBoxID; //Convert.ToInt32(ddlDropBoxList.SelectedItem.Value);
            DropBoxID.ParameterName = "@DropBoxID";
            sqlCom.Parameters.Add(DropBoxID);

            SqlParameter IntrumentType = new SqlParameter();
            IntrumentType.SqlDbType = SqlDbType.VarChar;
            IntrumentType.Value = ddlInstrumentType.SelectedItem.Value.ToString();
            IntrumentType.ParameterName = "@IntrumentType";
            sqlCom.Parameters.Add(IntrumentType);

            SqlParameter ChequeNo = new SqlParameter();
            ChequeNo.SqlDbType = SqlDbType.VarChar;
            ChequeNo.Value = txtChequeNo.Text.Trim();
            ChequeNo.ParameterName = "@ChequeNo";
            sqlCom.Parameters.Add(ChequeNo);

            SqlParameter ChequeAmt = new SqlParameter();
            ChequeAmt.SqlDbType = SqlDbType.Decimal;
            ChequeAmt.Value = Convert.ToDecimal(txtChequeAmt.Text.Trim());
            ChequeAmt.ParameterName = "@ChequeAmt";
            sqlCom.Parameters.Add(ChequeAmt);

            SqlParameter ChequeDate = new SqlParameter();
            ChequeDate.SqlDbType = SqlDbType.VarChar;
            ChequeDate.Value = txtChequeDate.Text;//Get_DateFormat(txtChequeDate.Text.Trim(), "MM/dd/yyyy"); ;
            ChequeDate.ParameterName = "@ChequeDate";
            sqlCom.Parameters.Add(ChequeDate);

            SqlParameter CardNo = new SqlParameter();
            CardNo.SqlDbType = SqlDbType.VarChar;
            CardNo.Value = txtCardNo.Text.Trim();
            CardNo.ParameterName = "@CardNo";
            sqlCom.Parameters.Add(CardNo);

            SqlParameter CardAmount = new SqlParameter();
            CardAmount.SqlDbType = SqlDbType.Decimal;
            CardAmount.Value = Convert.ToDecimal(txtChequeAmt.Text.Trim());//Convert.ToDecimal(lblCardAmount.Text.Trim()); 
            CardAmount.ParameterName = "@CardAmount";
            sqlCom.Parameters.Add(CardAmount);

            SqlParameter MICRCode = new SqlParameter();
            MICRCode.SqlDbType = SqlDbType.VarChar;
            MICRCode.Value = TextBox1.Text;//txtMICRCode.Text.Trim();
            MICRCode.ParameterName = "@MICRCode";
            sqlCom.Parameters.Add(MICRCode);

            SqlParameter BankName = new SqlParameter();
            BankName.SqlDbType = SqlDbType.VarChar;
            BankName.Value = lblBankName.Text;
            BankName.ParameterName = "@BankName";
            sqlCom.Parameters.Add(BankName);

            SqlParameter BranchName = new SqlParameter();
            BranchName.SqlDbType = SqlDbType.VarChar;
            BranchName.Value = lblBranchName.Text;
            BranchName.ParameterName = "@BranchName";
            sqlCom.Parameters.Add(BranchName);

            SqlParameter BranchCity = new SqlParameter();
            BranchCity.SqlDbType = SqlDbType.VarChar;
            BranchCity.Value = lblCity.Text;
            BranchCity.ParameterName = "@BranchCity";
            sqlCom.Parameters.Add(BranchCity);


            SqlParameter AccountNo = new SqlParameter();
            AccountNo.SqlDbType = SqlDbType.VarChar;
            AccountNo.Value = txtAcountNo.Text.Trim();
            AccountNo.ParameterName = "@AccountNo";
            sqlCom.Parameters.Add(AccountNo);

            SqlParameter Remark = new SqlParameter();
            Remark.SqlDbType = SqlDbType.VarChar;
            Remark.Value = txtRemark.Text.Trim();
            Remark.ParameterName = "@Remark";
            sqlCom.Parameters.Add(Remark);

            SqlParameter ContactNo = new SqlParameter();
            ContactNo.SqlDbType = SqlDbType.VarChar;
            ContactNo.Value = txtContactNo.Text.Trim();
            ContactNo.ParameterName = "@ContactNo";
            sqlCom.Parameters.Add(ContactNo);


            SqlParameter TransactionCode = new SqlParameter();
            TransactionCode.SqlDbType = SqlDbType.VarChar;
            TransactionCode.Value = txtTransactionCode.Text.Trim();
            TransactionCode.ParameterName = "@TransactionCode";
            sqlCom.Parameters.Add(TransactionCode);

            SqlParameter ReceiptNo = new SqlParameter();
            ReceiptNo.SqlDbType = SqlDbType.VarChar;
            ReceiptNo.Value = txtReceiptNo.Text.Trim();
            ReceiptNo.ParameterName = "@ReceiptNo";
            sqlCom.Parameters.Add(ReceiptNo);

            int intReasonID = 0;
            if (ddlReasonList.SelectedIndex != 0)
            {
                intReasonID = Convert.ToInt32(ddlReasonList.SelectedItem.Value);
            }

            SqlParameter ReasonID = new SqlParameter();
            ReasonID.SqlDbType = SqlDbType.Int;
            ReasonID.Value = intReasonID;
            ReasonID.ParameterName = "@ReasonID";
            sqlCom.Parameters.Add(ReasonID);

            int IntChequeCategory = 0;

            if (hdnChequeStaus.Value == "0")
            {
                //Valid Entry
                IntChequeCategory = 1;
            }
            else if (hdnChequeStaus.Value == "1")
            {
                //Invalid Entry
                IntChequeCategory = 2;
            }

            SqlParameter ChequeType = new SqlParameter();
            ChequeType.SqlDbType = SqlDbType.VarChar;
            ChequeType.Value = IntChequeCategory; //hdnchequeCategory.Value; 
            ChequeType.ParameterName = "@ChequeType";
            sqlCom.Parameters.Add(ChequeType);

            SqlParameter IsSignOn = new SqlParameter();
            IsSignOn.SqlDbType = SqlDbType.VarChar;
            IsSignOn.Value = ddlSignature.SelectedItem.Value.Trim();
            IsSignOn.ParameterName = "@IsSignOn";
            sqlCom.Parameters.Add(IsSignOn);

            SqlParameter ChequeCaptureStart = new SqlParameter();
            ChequeCaptureStart.SqlDbType = SqlDbType.VarChar;
            ChequeCaptureStart.Value = hdnEntryStart.Value;
            ChequeCaptureStart.ParameterName = "@ChequeCaptureStart";
            sqlCom.Parameters.Add(ChequeCaptureStart);

            SqlParameter UserID = new SqlParameter();
            UserID.SqlDbType = SqlDbType.VarChar;
            UserID.Value = Convert.ToString(((UserInfo.structUSERInfo)(SaveUSERInfo)).UserId);
            UserID.ParameterName = "@UserID";
            sqlCom.Parameters.Add(UserID);

            SqlParameter IsSuspense = new SqlParameter();
            IsSuspense.SqlDbType = SqlDbType.Int;
            IsSuspense.Value = Convert.ToInt32(hdnIsSuspenseCheque.Value);
            IsSuspense.ParameterName = "@IsSuspense";
            sqlCom.Parameters.Add(IsSuspense);

            SqlParameter VarResult = new SqlParameter();
            VarResult.SqlDbType = SqlDbType.VarChar;
            VarResult.Value = txtBatchNo.Text.Trim();
            VarResult.ParameterName = "@VarResult";
            VarResult.Size = 200;
            VarResult.Direction = ParameterDirection.Output;
            sqlCom.Parameters.Add(VarResult);


            sqlCon.Open();


            sqlCom.ExecuteNonQuery();
            string RowEffected = Convert.ToString(sqlCom.Parameters["@VarResult"].Value);
            hdnTransactionDetailID.Value = RowEffected;

            sqlCon.Close();

            if (RowEffected != "")
            {
                lblMessage.Visible = true;
                lblMessage.Text = "Cheque Details Successfully Updated, Batch No: " + RowEffected;
                lblMessage.CssClass = "SuccessMessage";
                txtBatchNo.Enabled = false;
                ddlDropBoxList.Enabled = false;
                ddlInstrumentType.Enabled = false;
                txtChequeNo.Enabled = false;
                txtChequeAmt.Enabled = false;
                txtChequeDate.Enabled = false;
                txtCardNo.Enabled = false;
                TextBox1.Enabled = false;
                txtAcountNo.Enabled = false;
                ddlSignature.Enabled = false;
                ddlReasonList.Enabled = false;
                txtTransactionCode.Enabled = false;
                txtReceiptNo.Enabled = false;
                txtRemark.Enabled = false;
                btnUpdate.Enabled = false;
                btnCancel.Focus();
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
    private string Get_DateFormat(string cDate, string cDateFormat)
    {
        try
        {
            string strDate = cDate;
            string[] strArrDate = strDate.Split('/');

            if (strArrDate.Length > 0)
            {
                if (cDateFormat == "yyyy/MM/dd")
                {
                    strDate = strArrDate[2] + "/" + strArrDate[1] + "/" + strArrDate[0];

                }
                else if (cDateFormat == "MM/dd/yyyy")
                {
                    strDate = strArrDate[1] + "/" + strArrDate[0] + "/" + strArrDate[2];

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

    protected void TextBox1_TextChanged(object sender, EventArgs e)
    {
        Object SaveUSERInfo = (Object)Session["UserInfo"];

        SqlConnection sqlCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);

        try
        {

            SqlCommand sqlCom = new SqlCommand();
            sqlCom.Connection = sqlCon;
            sqlCom.CommandType = CommandType.StoredProcedure;
            sqlCom.CommandText = "Get_MICR_mod";
            sqlCom.CommandTimeout = 0;



            SqlParameter MICRCode = new SqlParameter();
            MICRCode.SqlDbType = SqlDbType.VarChar;
            MICRCode.Value = TextBox1.Text;
            MICRCode.ParameterName = "@MICRCode";
            sqlCom.Parameters.Add(MICRCode);

            SqlParameter BranchID = new SqlParameter();
            BranchID.SqlDbType = SqlDbType.Int;
            BranchID.Value = Convert.ToInt32(((UserInfo.structUSERInfo)(SaveUSERInfo)).BranchId);
            BranchID.ParameterName = "@BranchId";
            sqlCom.Parameters.Add(BranchID);


            sqlCon.Open();
            SqlDataAdapter sqlda = new SqlDataAdapter();
            sqlda.SelectCommand = sqlCom;
            DataSet ds = new DataSet();
            sqlda.Fill(ds);
            sqlCon.Close();



            if (ds.Tables[0].Rows.Count > 0)
            {
                hdnMicrCheck.Value = ds.Tables[0].Rows[0]["msg"].ToString();
                if (ds.Tables[0].Rows[0]["msg"].ToString() == "Present")
                {
                    lblBankName.Text = ds.Tables[0].Rows[0]["Bank_Name"].ToString();
                    lblBranchName.Text = ds.Tables[0].Rows[0]["Branch_Name"].ToString();
                    lblCity.Text = ds.Tables[0].Rows[0]["City"].ToString();

                }
                else
                {
                    lblMessage.Text = "Invalid MICR Entered.";
                    lblMessage.CssClass = "ErrorMessage";
                    TextBox1.Focus();
                    TextBox1.Text = "";
                    lblBankName.Text = "";
                    lblBranchName.Text = "";
                    lblCity.Text = "";
                }
            }
            else
            {
                lblMessage.Text = "Enter Correct MICR Code.";
                lblMessage.CssClass = "ErrorMessage";
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

    //protected void TextBox1_TextChanged(object sender, EventArgs e)
    //{
    //    Object SaveUSERInfo = (Object)Session["UserInfo"];

    //    SqlConnection sqlCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);

    //    sqlCon.Open();
    //    SqlCommand sqlCom = new SqlCommand();
    //    sqlCom.Connection = sqlCon;
    //    sqlCom.CommandType = CommandType.StoredProcedure;
    //    sqlCom.CommandText = "Get_MICR";
    //    SqlDataAdapter sqlda = new SqlDataAdapter();
    //    sqlda.SelectCommand = sqlCom;

    //    SqlParameter MICRCode = new SqlParameter();
    //    MICRCode.SqlDbType = SqlDbType.VarChar;
    //    MICRCode.Value = TextBox1.Text;
    //    MICRCode.ParameterName = "@MICRCode";
    //    sqlCom.Parameters.Add(MICRCode);

    //    SqlParameter BranchID = new SqlParameter();
    //    BranchID.SqlDbType = SqlDbType.Int;
    //    BranchID.Value = Convert.ToInt32(((UserInfo.structUSERInfo)(SaveUSERInfo)).BranchId);
    //    BranchID.ParameterName = "@BranchID";
    //    sqlCom.Parameters.Add(BranchID);


    //    DataSet ds = new DataSet();
    //    sqlda.Fill(ds);
    //    sqlCon.Close();

    //    if (ds.Tables.Count > 0)
    //    {

    //        lblBankName.Text = ds.Tables[0].Rows[0]["Bank_Name"].ToString();
    //        lblBranchName.Text = ds.Tables[0].Rows[0]["Branch_Name"].ToString();
    //        lblCity.Text = ds.Tables[0].Rows[0]["City"].ToString();
    //    }

    //}
}