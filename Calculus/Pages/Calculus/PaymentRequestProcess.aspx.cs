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

public partial class Pages_Calculus_PaymentRequestProcess : System.Web.UI.Page
{
    string tranID;
    string strTransactionDetail;
    Double totalRejectAmount = 0;
    string[] ids ;
    private string yrMonth;
    int Bid=0;

   string grdRequestType=string.Empty;
   
      double BalanceAmount;
      private double TransactionAmount;
      private int ReqType;
      private string cid;
   
     
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserInfo"] == null)
        {
            Response.Redirect("~/InvalidRequest.aspx");
        }
                   
              
        if (!IsPostBack)
        {
            Get_BranchList();
            int pBranchID = 0;
            if (ddlBranchList.SelectedIndex != 0)
            {
                pBranchID = Convert.ToInt32(ddlBranchList.SelectedItem.Value);
            }
            Get_User_Vertical_RightsInfo(pBranchID);
            Object SaveUSERInfo = (Object)Session["UserInfo"];
            if ((((UserInfo.structUSERInfo)(SaveUSERInfo)).UserId.Contains("P59195")) || (((UserInfo.structUSERInfo)(SaveUSERInfo)).UserId.Contains("P00114")))
            {
                if (!ddlRequestType.Items.Contains(new ListItem("Rent Vendor Payment")))
                {
                    ddlRequestType.Items.Add(new ListItem("Rent Vendor Payment", "SPVendor"));
                }
                ddlRequestType.SelectedIndex = 0;
                ddlRequestType.DataBind();
            }
        }

        
        Register_ControlWith_javascript();
    }

    protected void btnAccept_Click(object sender, EventArgs e)
    {
        try
        {
            Update_TransactionRequest();
            if (ddlRequestType.SelectedItem.Value == "SPVendor")
            {
                Get_TransactionList_For_ProcessVendor();
            }
            else
            {
                Get_TransactionList_For_Process();
            }
            //Get_TransactionList_For_Process();
            //Clear_Controls();

        }
        catch (Exception ex)
        {
            Get_TransactionList_For_Process();
            lblMessage.Text = ex.Message;
            lblMessage.CssClass = "ErrorMessage";


        }

    }

    private void Get_BranchList()
    {
        try
        {
            Object SaveUSERInfo = (Object)Session["UserInfo"];

            SqlConnection sqlCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);

            sqlCon.Open();
            SqlCommand sqlCom = new SqlCommand();
            sqlCom.Connection = sqlCon;
            sqlCom.CommandType = CommandType.StoredProcedure;
            sqlCom.CommandText = "Get_AllBranchList_For_Auth";
           
            SqlParameter UserID = new SqlParameter();
            UserID.SqlDbType = SqlDbType.VarChar;
            UserID.Value = Convert.ToString(((UserInfo.structUSERInfo)(SaveUSERInfo)).UserId);
            UserID.ParameterName = "@UserID";
            sqlCom.Parameters.Add(UserID);

            SqlDataAdapter sqlDA = new SqlDataAdapter();
            sqlDA.SelectCommand = sqlCom;

            DataTable dt = new DataTable();
            sqlDA.Fill(dt);
            sqlCon.Close();

            ddlBranchList.DataTextField = "BranchName";
            ddlBranchList.DataValueField = "BranchID";

            ddlBranchList.DataSource = dt;
            ddlBranchList.DataBind();

            ddlBranchList.Items.Insert(0, "--Select--");
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
        if (ddlRequestType.SelectedItem.Value == "SPVendor")
        {
            Get_TransactionList_For_ProcessVendor();
        }
        else
        {
            Get_TransactionList_For_Process();
        }
    }
    private void Get_TransactionList_For_ProcessVendor()
    {

        Object SaveUSERInfo = (Object)Session["UserInfo"];

        SqlConnection sqlCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);

        sqlCon.Open();
        SqlCommand sqlCom = new SqlCommand();

        sqlCom.Connection = sqlCon;
        sqlCom.CommandType = CommandType.StoredProcedure;
        sqlCom.CommandText = "CalOnlineTrans_GetRecordsForPyamentProcessVendor_SP";


        SqlParameter intStatus = new SqlParameter();
        intStatus.SqlDbType = SqlDbType.Int;
        intStatus.Value = ddlPaymentRequestStatus.SelectedItem.Value;

        intStatus.ParameterName = "@intStatus";
        sqlCom.Parameters.Add(intStatus);


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
        TransactionID.Value = txtTransID.Text.Trim();
        TransactionID.ParameterName = "@TransactionID";
        sqlCom.Parameters.Add(TransactionID);

        SqlParameter RequestFromDate = new SqlParameter();
        RequestFromDate.SqlDbType = SqlDbType.VarChar;
        RequestFromDate.Value = txtRequestFromDate.Text.Trim();
        RequestFromDate.ParameterName = "@RequestFromDate";
        sqlCom.Parameters.Add(RequestFromDate);

        SqlParameter RequestToDate = new SqlParameter();
        RequestToDate.SqlDbType = SqlDbType.VarChar;
        RequestToDate.Value = txtRequestToDate.Text.Trim();
        RequestToDate.ParameterName = "@RequestToDate";
        sqlCom.Parameters.Add(RequestToDate);

        decimal pAmount = 0;
        if (txtAmount.Text.Trim() != "")
        {
            pAmount = Convert.ToDecimal(txtAmount.Text.Trim());
        }

        SqlParameter Amount = new SqlParameter();
        Amount.SqlDbType = SqlDbType.Decimal;
        Amount.Value = pAmount;
        Amount.ParameterName = "@Amount";
        sqlCom.Parameters.Add(Amount);

        SqlParameter RequestType = new SqlParameter();
        RequestType.SqlDbType = SqlDbType.Int;
        RequestType.Value = "2";//Convert.ToInt32(ddlRequestType.SelectedItem.Value);
        RequestType.ParameterName = "@RequestType";
        sqlCom.Parameters.Add(RequestType);

        SqlParameter UserID = new SqlParameter();
        UserID.SqlDbType = SqlDbType.VarChar;
        UserID.Value = Convert.ToString(((UserInfo.structUSERInfo)(SaveUSERInfo)).UserId);
        UserID.ParameterName = "@UserID";
        sqlCom.Parameters.Add(UserID);

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

        }
        else
        {
            grvTransactionInfo.DataSource = null;
            grvTransactionInfo.DataBind();
            lblMessage.Text = "No Records found!";
            lblMessage.CssClass = "ErrorMessage";

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
        sqlCom.CommandText = "CalOnlineTrans_GetRecords_For_PyamentProcess_SP";
        sqlCom.CommandTimeout = 120;
        //updated by abhijeet//
        //sqlCom.CommandText = "Get_RecordsForPyamentProcess_new123";


        SqlParameter intStatus = new SqlParameter();
        intStatus.SqlDbType = SqlDbType.Int;
        intStatus.Value = ddlPaymentRequestStatus.SelectedItem.Value;
        
        intStatus.ParameterName = "@intStatus";
        sqlCom.Parameters.Add(intStatus);


        int intBranchID = 0;
        if (ddlBranchList.SelectedIndex != 0)
        {
            intBranchID =Convert.ToInt32(ddlBranchList.SelectedItem.Value); 
         }
        SqlParameter BranchId = new SqlParameter();
        BranchId.SqlDbType = SqlDbType.Int;
        BranchId.Value = intBranchID;
        BranchId.ParameterName = "@BranchId";
        sqlCom.Parameters.Add(BranchId);

        SqlParameter TransactionID = new SqlParameter();
        TransactionID.SqlDbType = SqlDbType.VarChar;
        TransactionID.Value = txtTransID.Text.Trim();
        TransactionID.ParameterName = "@TransactionID";
        sqlCom.Parameters.Add(TransactionID);

        SqlParameter RequestFromDate = new SqlParameter();
        RequestFromDate.SqlDbType = SqlDbType.VarChar;
        RequestFromDate.Value = txtRequestFromDate.Text.Trim();
        RequestFromDate.ParameterName = "@RequestFromDate";
        sqlCom.Parameters.Add(RequestFromDate);

        SqlParameter RequestToDate = new SqlParameter();
        RequestToDate.SqlDbType = SqlDbType.VarChar;
        RequestToDate.Value = txtRequestToDate.Text.Trim();
        RequestToDate.ParameterName = "@RequestToDate";
        sqlCom.Parameters.Add(RequestToDate);

        decimal pAmount = 0;
        if (txtAmount.Text.Trim() != "")
        {
           pAmount=Convert.ToDecimal(txtAmount.Text.Trim());
        }

        SqlParameter Amount = new SqlParameter();
        Amount.SqlDbType = SqlDbType.Decimal;
        Amount.Value = pAmount;
        Amount.ParameterName = "@Amount";
        sqlCom.Parameters.Add(Amount);

        SqlParameter RequestType = new SqlParameter();
        RequestType.SqlDbType = SqlDbType.Int;
        RequestType.Value =Convert.ToInt32(ddlRequestType.SelectedItem.Value);
        RequestType.ParameterName = "@RequestType";
        sqlCom.Parameters.Add(RequestType);

        SqlParameter UserID = new SqlParameter();
        UserID.SqlDbType = SqlDbType.VarChar;
        UserID.Value = Convert.ToString(((UserInfo.structUSERInfo)(SaveUSERInfo)).UserId);
        UserID.ParameterName = "@UserID";
        sqlCom.Parameters.Add(UserID);

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
            
        }
        else
        {
            grvTransactionInfo.DataSource = null ;
            grvTransactionInfo.DataBind();
            lblMessage.Text = "No Records found!";
            lblMessage.CssClass = "ErrorMessage";
            
        }
      

    }

    public void grv_RowDataBound(object sender, GridViewRowEventArgs e)
    {
       
       if (e.Row.RowType == DataControlRowType.DataRow)
       {

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

    private DataTable Get_TransactionDetails(string strTransactionID)
    {
     
        SqlConnection sqlCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);

        sqlCon.Open();
        SqlCommand sqlCom = new SqlCommand();
        sqlCom.Connection = sqlCon;
        sqlCom.CommandType = CommandType.StoredProcedure;
        sqlCom.CommandText = "CalOnlineTrans_GetTransactionDetailsForApprove_SP";

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

    private void Update_TransactionRequest()
    {
        string strTransaction = "";
            for (int i=0;i<=grvTransactionInfo.Rows.Count-1;i++)
                
            {
                GridView grvDetails = (GridView)grvTransactionInfo.Rows[i].FindControl("grvDetails");

                CheckBox chkSelect = (CheckBox)grvTransactionInfo.Rows[i].FindControl("chkSelect");
                TextBox txtRemark = (TextBox)grvTransactionInfo.Rows[i].FindControl("txtRemark");

                if (chkSelect.Checked == true)
                {
                    strTransaction = strTransaction + "" + grvTransactionInfo.Rows[i].Cells[2].Text.Trim() + "|" + txtRemark.Text + "|";
                    tranID = grvTransactionInfo.Rows[i].Cells[2].Text.Trim();

                    if (strTransaction.Length > 0)
                    {
                        strTransaction = strTransaction.Substring(0, strTransaction.Length - 1);
                        strTransaction = strTransaction + "^";
                    }
                }

          
                for (int J = 0; J <= grvDetails.Rows.Count - 1; J++)
                {
                    CheckBox chkSelectDetails = (CheckBox)grvDetails.Rows[J].FindControl("chkSelectDetails");


                     string a = grvDetails.Rows[J].Cells[21].Text.Trim();

                if (chkSelectDetails.Checked == true && (a == "" || a == null || a == "&nbsp;"))

                {

                        strTransactionDetail = grvDetails.Rows[J].Cells[1].Text.Trim();

                        Object SaveUSERInfo = (Object)Session["UserInfo"];

                        SqlConnection sqlCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);

                        sqlCon.Open();
                        SqlCommand sqlCom = new SqlCommand();
                        sqlCom.Connection = sqlCon;
                        sqlCom.CommandType = CommandType.StoredProcedure;
                        sqlCom.CommandText = "CalOnlineTrans_UpdateTransactionRequestStatus_SP";//Update_TransactionRequestStatus
                        sqlCom.CommandTimeout = 0;


                        SqlParameter TransactionIDList = new SqlParameter();
                        TransactionIDList.SqlDbType = SqlDbType.VarChar;
                        TransactionIDList.Value = strTransaction;
                        TransactionIDList.ParameterName = "@TransactionIDList";
                        sqlCom.Parameters.Add(TransactionIDList);

                        SqlParameter TransactionDetailID = new SqlParameter();
                        TransactionDetailID.SqlDbType = SqlDbType.VarChar;
                        TransactionDetailID.Value = strTransactionDetail;
                        TransactionDetailID.ParameterName = "@TransactionDetailID";
                        sqlCom.Parameters.Add(TransactionDetailID);

                        SqlParameter Status = new SqlParameter();
                        Status.SqlDbType = SqlDbType.Int;
                        Status.Value = 2;
                        Status.ParameterName = "@Status";
                        sqlCom.Parameters.Add(Status);

                        SqlParameter UserID = new SqlParameter();
                        UserID.SqlDbType = SqlDbType.VarChar;
                        UserID.Value = Convert.ToString(((UserInfo.structUSERInfo)(SaveUSERInfo)).UserId);
                        UserID.ParameterName = "@UserID";
                        sqlCom.Parameters.Add(UserID);

                        int RowsEffeted = sqlCom.ExecuteNonQuery();

                        if (RowsEffeted > 0)
                        {
                            lblMessage.Text = "Record Successfully Updated!";
                            lblMessage.CssClass = "UpdateMessage";

                        }
            
                    }
                }
            }
            if (ddlRequestType.SelectedItem.Value == "SPVendor")
            {
                Get_TransactionList_For_ProcessVendor();
            }
            else
            {
                Get_TransactionList_For_Process();
            }
            //Get_TransactionList_For_Process();
    }

    private void Update_TransactionRequestReject()
    {
        string strTransaction = "";
        for (int i = 0; i <= grvTransactionInfo.Rows.Count - 1; i++)
        {
            GridView grvDetails = (GridView)grvTransactionInfo.Rows[i].FindControl("grvDetails");

            CheckBox chkSelect = (CheckBox)grvTransactionInfo.Rows[i].FindControl("chkSelect");
            TextBox txtRemark = (TextBox)grvTransactionInfo.Rows[i].FindControl("txtRemark");

            if (chkSelect.Checked == true)
            {
                strTransaction = strTransaction + "" + grvTransactionInfo.Rows[i].Cells[2].Text.Trim() + "|" + txtRemark.Text + "|";
                tranID = grvTransactionInfo.Rows[i].Cells[2].Text.Trim();

                if (strTransaction.Length > 0)
                {
                    strTransaction = strTransaction.Substring(0, strTransaction.Length - 1);
                    strTransaction = strTransaction + "^";
                    hdnRemark.Value = txtRemark.Text;
                }
            }
                        
            for (int J = 0; J <= grvDetails.Rows.Count - 1; J++)
            {
                CheckBox chkSelectDetails = (CheckBox)grvDetails.Rows[J].FindControl("chkSelectDetails");

                string a = grvDetails.Rows[J].Cells[21].Text.Trim();

                if (chkSelectDetails.Checked == true && (a == "" || a == null || a == "&nbsp;"))
                {
                    strTransactionDetail = grvDetails.Rows[J].Cells[1].Text.Trim();

                    Object SaveUSERInfo = (Object)Session["UserInfo"];

                    SqlConnection sqlCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);

                    sqlCon.Open();
                    SqlCommand sqlCom = new SqlCommand();
                    sqlCom.Connection = sqlCon;
                    sqlCom.CommandType = CommandType.StoredProcedure;
                    sqlCom.CommandText = "CalOnlineTrans_UpdateTransactionRequestStatus_SP";//Update_TransactionRequestStatus
                    sqlCom.CommandTimeout = 0;


                    SqlParameter TransactionIDList = new SqlParameter();
                    TransactionIDList.SqlDbType = SqlDbType.VarChar;
                    TransactionIDList.Value = strTransaction;
                    TransactionIDList.ParameterName = "@TransactionIDList";
                    sqlCom.Parameters.Add(TransactionIDList);

                    SqlParameter TransactionDetailID = new SqlParameter();
                    TransactionDetailID.SqlDbType = SqlDbType.VarChar;
                    TransactionDetailID.Value = strTransactionDetail;
                    TransactionDetailID.ParameterName = "@TransactionDetailID";
                    sqlCom.Parameters.Add(TransactionDetailID);

                    SqlParameter Status = new SqlParameter();
                    Status.SqlDbType = SqlDbType.Int;
                    Status.Value = 3;
                    Status.ParameterName = "@Status";
                    sqlCom.Parameters.Add(Status);

                    SqlParameter UserID = new SqlParameter();
                    UserID.SqlDbType = SqlDbType.VarChar;
                    UserID.Value = Convert.ToString(((UserInfo.structUSERInfo)(SaveUSERInfo)).UserId);
                    UserID.ParameterName = "@UserID";
                    sqlCom.Parameters.Add(UserID);

                    if (hdnRemark.Value != "")
                    {
                    }
                    else
                    {
                        lblMessage.Visible = true;
                        lblMessage.Text = "Kindly Enter Remark..!!";
                        return;
                    }

                    int RowsEffeted = sqlCom.ExecuteNonQuery();

                    if (RowsEffeted > 0)
                    {
                        lblMessage.Text = "Record Successfully Updated!";
                        lblMessage.CssClass = "UpdateMessage";


                        updateTransactionBalance();
                        Clear_Controls();

                    }

                }
            }
        }

    }
  
    protected void btnReject_Click(object sender, EventArgs e)
    {
      try
        {
            Update_TransactionRequestReject();

        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
            lblMessage.CssClass = "ErrorMessage";

        }
    }


    

    private void Register_ControlWith_javascript()
    {
        btnReset.Attributes.Add("onclick", "javascript:return resetControls();");
        btnSearch.Attributes.Add("onclick", "javascript:return Validate_Search();");   
        
    
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/pages/menu.aspx", true);
    }     

    protected void btnLogin_Click(object sender, EventArgs e)
    {

    }

    private void Clear_Controls()
    {
        txtTransID.Text = "";
        txtRequestFromDate.Text = "";
        txtAmount.Text = "";
        ddlBranchList.SelectedIndex = 0;
        ddlPaymentRequestStatus.SelectedIndex = 0;
        ddlRequestType.SelectedIndex = 0;
        grvTransactionInfo.DataSource = null;
        grvTransactionInfo.DataBind();
    
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
                    case ".pdf":
                        type = "application/pdf";
                        break;
                    case ".rar":
                        type = "application/rar";
                        break;
                    case ".jpeg":
                        type = "application/jpeg";
                        break;
                    case ".png":
                        type = "application/png";
                        break;
                    case ".html":
                        type = "application/html";
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

        string DownloadPath=((System.Web.UI.WebControls.LinkButton)(sender)).CommandArgument.ToString();
        if (DownloadPath != "")
        {
            DownloadFile(DownloadPath, true);
        }
        else
        { 
            lblMessage.Text="No Attach document found!" ;
        }
    }

    private void Get_User_Vertical_RightsInfo(int pBranchID)
    {
        Object SaveUSERInfo = (Object)Session["UserInfo"];

        SqlConnection sqlCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);

        sqlCon.Open();
        SqlCommand sqlCom = new SqlCommand();
        sqlCom.Connection = sqlCon;
        sqlCom.CommandType = CommandType.StoredProcedure;
        sqlCom.CommandText = "CalOnlineTrans_GetUserVerticalRightsInfo_SP";

        SqlParameter BranchID = new SqlParameter();
        BranchID.SqlDbType = SqlDbType.Int;
        BranchID.Value = pBranchID;
        BranchID.ParameterName = "@BranchID";
        sqlCom.Parameters.Add(BranchID);
  
        SqlParameter UserID = new SqlParameter();
        UserID.SqlDbType = SqlDbType.VarChar;
        UserID.Value = Convert.ToString(((UserInfo.structUSERInfo)(SaveUSERInfo)).UserId);
        UserID.ParameterName = "@UserID";
        sqlCom.Parameters.Add(UserID);

        SqlDataAdapter sqlDA = new SqlDataAdapter();
        sqlDA.SelectCommand = sqlCom;
        DataTable dt = new DataTable();
        sqlDA.Fill(dt);
        sqlCon.Close();
        if (dt.Rows.Count == 0)
        {
            lblMessage.Text = "You not having Payment request Authorize rights!";
            btnAccept.Visible = false;
            btnReject.Visible = false;
        }
        else
        {
            lblMessage.Text = "";
            btnAccept.Visible = true;
            btnReject.Visible = true;
        }

    }

    private void Generate_ExcelFile()
    {
        String attachment = "attachment; filename=AuthorizePaymentRequest.xls";
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
        tblCell1.Text = "<b><font size='4'>PAMAC FINSERVE PVT. LTD., MUMBAI</font></b> <br/>" +
                        "<b><font size='2' color='blue'>Authorize Payment Request Process</font></b> <br/>";
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
        Object SaveUSERInfo = (Object)Session["UserInfo"];

        SqlConnection sqlCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);

        sqlCon.Open();
        SqlCommand sqlCom = new SqlCommand();
        sqlCom.Connection = sqlCon;
        sqlCom.CommandType = CommandType.StoredProcedure;
        sqlCom.CommandText = "CalOnlineTrans_GetRecordsForPyamentProcess_SP";


        SqlParameter intStatus = new SqlParameter();
        intStatus.SqlDbType = SqlDbType.Int;
        intStatus.Value = ddlPaymentRequestStatus.SelectedItem.Value;
        intStatus.ParameterName = "@intStatus";
        sqlCom.Parameters.Add(intStatus);


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
        TransactionID.Value = txtTransID.Text.Trim();
        TransactionID.ParameterName = "@TransactionID";
        sqlCom.Parameters.Add(TransactionID);

        SqlParameter RequestFromDate = new SqlParameter();
        RequestFromDate.SqlDbType = SqlDbType.VarChar;
        RequestFromDate.Value = txtRequestFromDate.Text.Trim();
        RequestFromDate.ParameterName = "@RequestFromDate";
        sqlCom.Parameters.Add(RequestFromDate);
        
        SqlParameter RequestToDate = new SqlParameter();
        RequestToDate.SqlDbType = SqlDbType.VarChar;
        RequestToDate.Value = txtRequestToDate.Text.Trim();
        RequestToDate.ParameterName = "@RequestToDate";
        sqlCom.Parameters.Add(RequestToDate);

        decimal pAmount = 0;
        if (txtAmount.Text.Trim() != "")
        {
            pAmount = Convert.ToDecimal(txtAmount.Text.Trim());
        }

        SqlParameter Amount = new SqlParameter();
        Amount.SqlDbType = SqlDbType.Decimal;
        Amount.Value = pAmount;
        Amount.ParameterName = "@Amount";
        sqlCom.Parameters.Add(Amount);

        SqlParameter RequestType = new SqlParameter();
        RequestType.SqlDbType = SqlDbType.Int;
        RequestType.Value = Convert.ToInt32(ddlRequestType.SelectedItem.Value);
        RequestType.ParameterName = "@RequestType";
        sqlCom.Parameters.Add(RequestType);

        SqlParameter UserID = new SqlParameter();
        UserID.SqlDbType = SqlDbType.VarChar;
        UserID.Value = Convert.ToString(((UserInfo.structUSERInfo)(SaveUSERInfo)).UserId);
        UserID.ParameterName = "@UserID";
        sqlCom.Parameters.Add(UserID);


        SqlDataAdapter sqlDA = new SqlDataAdapter();
        sqlDA.SelectCommand = sqlCom;
        DataTable dt = new DataTable();
        sqlDA.Fill(dt);
        sqlCon.Close();
        if (dt.Rows.Count > 0)
        {
            GridView1.DataSource = dt;
            GridView1.DataBind();
            lblMessage.Text = "Total Records Found " + dt.Rows.Count;
            lblMessage.CssClass = "UpdateMessage";

        }
        else
        {
            GridView1.DataSource = null;
            GridView1.DataBind();
            lblMessage.Text = "No Records found!";
            lblMessage.CssClass = "ErrorMessage";

        }

        Generate_ExcelFile();
    }

    public override void VerifyRenderingInServerForm(Control control)
    {

    }

    public void updateTransactionBalance()
    {
        string strTransaction = "";

        for (int i = 0; i <= grvTransactionInfo.Rows.Count - 1; i++)
        {
            GridView grvDetails = (GridView)grvTransactionInfo.Rows[i].FindControl("grvDetails");

            CheckBox chkSelect = (CheckBox)grvTransactionInfo.Rows[i].FindControl("chkSelect");
            TextBox txtRemark = (TextBox)grvTransactionInfo.Rows[i].FindControl("txtRemark");

            if (chkSelect.Checked == true)
            {
                strTransaction = strTransaction + "" + grvTransactionInfo.Rows[i].Cells[2].Text.Trim() + "|" + txtRemark.Text + "|";
                tranID = grvTransactionInfo.Rows[i].Cells[2].Text.Trim();
                grdRequestType = grvTransactionInfo.Rows[i].Cells[8].Text;
                if (strTransaction.Length > 0)
                {
                    strTransaction = strTransaction.Substring(0, strTransaction.Length - 1);
                    strTransaction = strTransaction + "^";
                }

                Object SaveUSERInfo = (Object)Session["UserInfo"];

                SqlConnection sqlCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);

                sqlCon.Open();
                SqlCommand sqlCom = new SqlCommand();
                sqlCom.Connection = sqlCon;
                sqlCom.CommandType = CommandType.StoredProcedure;
                sqlCom.CommandText = "CalOnlineTrans_STP_GetRejectStatusDetails_SP";
                sqlCom.CommandTimeout = 0;


                SqlParameter TransactionID = new SqlParameter();
                TransactionID.SqlDbType = SqlDbType.VarChar;
                TransactionID.Value = tranID;
                TransactionID.ParameterName = "@TID";
                sqlCom.Parameters.Add(TransactionID);

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



                SqlDataAdapter sqlDA = new SqlDataAdapter();
                sqlDA.SelectCommand = sqlCom;
                DataTable dt = new DataTable();
                sqlDA.Fill(dt);
                sqlCon.Close();


                if (dt.Rows.Count > 0)
                {
                    totalRejectAmount = Convert.ToDouble(dt.Rows[0]["TotalRequestAmount"]);
                    Bid = Convert.ToInt32(dt.Rows[0]["BranchId"]);
                    ids = tranID.Split('\\');
                    yrMonth = ids[1].ToString();
                    sqlCon.Open();
                    cid= Convert.ToString(((UserInfo.structUSERInfo)(SaveUSERInfo)).ClientId);
                    if (getAmount() == 1)
                    {
                        string sql = "UPDATE [CalOnlineTrans_BranchOpeningBalanceInfo_TBL] SET [ClosingBalanceAmount]=@AvlAmt ,[TransactionAmount]=@TransAmt WHERE BranchId=@BranchId and OpeningBalanceYrMonth=@BalYrMonth and RequestType=@RequestType and ClientID=@ClientId";

                        SqlCommand cmd = new SqlCommand(sql, sqlCon);
                        cmd.Parameters.AddWithValue("@AvlAmt", BalanceAmount);
                        cmd.Parameters.AddWithValue("@TransAmt", TransactionAmount);
                        cmd.Parameters.AddWithValue("@BranchId", Bid);
                        cmd.Parameters.AddWithValue("@BalYrMonth", yrMonth);
                        cmd.Parameters.AddWithValue("@RequestType", ReqType);
                        cmd.Parameters.AddWithValue("@ClientId", cid);
                        cmd.ExecuteNonQuery();
                        sqlCon.Close();
                    }
                }
            }
        }
    }

    public int getAmount()
    {
        Object SaveUSERInfo = (Object)Session["UserInfo"];

        SqlConnection sqlCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);

        sqlCon.Open();
        SqlCommand sqlCom = new SqlCommand();
        sqlCom.Connection = sqlCon;
        sqlCom.CommandType = CommandType.StoredProcedure;
        sqlCom.CommandText = "CalOnlineTrans_Get_OpeningBalanceMonthWise_New_SP";

        SqlParameter BranchID = new SqlParameter();
        BranchID.SqlDbType = SqlDbType.Int;
        BranchID.Value = Convert.ToInt32(((UserInfo.structUSERInfo)(SaveUSERInfo)).BranchId);//pBranchId;
        BranchID.ParameterName = "@BranchID";
        sqlCom.Parameters.Add(BranchID);

        SqlParameter YrMonth = new SqlParameter();
        YrMonth.SqlDbType = SqlDbType.VarChar;
        YrMonth.Value = yrMonth;
        YrMonth.ParameterName = "@YrMonth";
        sqlCom.Parameters.Add(YrMonth);

        #region Code By Amrita on 22-Apr-2014 As per Client Requirement
        SqlParameter ClientId = new SqlParameter();
        ClientId.SqlDbType = SqlDbType.Int;
        ClientId.Value = Convert.ToInt32(((UserInfo.structUSERInfo)(SaveUSERInfo)).ClientId);
        ClientId.ParameterName = "@ClientId";
        sqlCom.Parameters.Add(ClientId);
        #endregion

        if (grdRequestType == "VenderPayment" || grdRequestType == "Utility Payment" || grdRequestType == "Employee Payment")
        {
            SqlParameter RequestType = new SqlParameter();
            RequestType.SqlDbType = SqlDbType.Int;
            RequestType.Value = Convert.ToInt32(2);//pBranchId;
            RequestType.ParameterName = "@ReqType";
            sqlCom.Parameters.Add(RequestType);
            ReqType = 2;
        }
        else if (grdRequestType == "PettyCash" || grdRequestType == "OtherThanPettyCash" )
        {
            SqlParameter RequestType = new SqlParameter();
            RequestType.SqlDbType = SqlDbType.Int;
            RequestType.Value = Convert.ToInt32(1); //pBranchId;
            RequestType.ParameterName = "@ReqType";
            sqlCom.Parameters.Add(RequestType);
            ReqType = 1;
        }

        

        SqlDataAdapter sqlDA = new SqlDataAdapter();
        sqlDA.SelectCommand = sqlCom;
        DataTable dt = new DataTable();
        sqlDA.Fill(dt);
        sqlCon.Close();
        if (dt.Rows.Count > 0)
        {
            TransactionAmount = Convert.ToDouble(dt.Rows[0]["TransactionAmount"]) - totalRejectAmount;
            BalanceAmount = Convert.ToDouble(dt.Rows[0]["ClosingBalanceAmount"]) + totalRejectAmount;
            return 1;
        }
        else
        {
            return 0;
        }
    }
}

