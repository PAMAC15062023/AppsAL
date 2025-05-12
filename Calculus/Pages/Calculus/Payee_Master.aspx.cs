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

public partial class Pages_Calculus_Payee_Master : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserInfo"] == null)
        {
            Response.Redirect("~/Pages/InvalidRequest.aspx", true);
        }

        if (!IsPostBack)
        {
            BindIsActive();
            BindTransactionTypes();
            Register_ControlsWithJavascripts();
            Get_StateGST();
            BindACTypes();
        }
    }

    protected void BindIsActive()
    {
        SqlConnection sqlCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);

        SqlCommand cmd = new SqlCommand("KMPL_SearchCodeMaster_SP", sqlCon);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@Types", "CMIsActiveType");
        cmd.Parameters.AddWithValue("@Level", 1);
        SqlDataAdapter adp = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        adp.Fill(ds);

        if (ds != null && ds.Tables[0].Rows.Count > 0)
        {
            ddlIsActive.DataSource = ds;
            ddlIsActive.DataValueField = "Code_Id";
            ddlIsActive.DataTextField = "Description";
            ddlIsActive.DataBind();
            ddlIsActive.Items.Insert(0, new ListItem("--Select--", "0"));

            ddlIsActiveGST.DataSource = ds;
            ddlIsActiveGST.DataValueField = "Code_Id";
            ddlIsActiveGST.DataTextField = "Description";
            ddlIsActiveGST.DataBind();
            ddlIsActiveGST.Items.Insert(0, new ListItem("--Select--", "0"));

            ddlND.DataSource = ds;
            ddlND.DataValueField = "Code_Id";
            ddlND.DataTextField = "Description";
            ddlND.DataBind();
            ddlND.Items.Insert(0, new ListItem("--Select--", "0"));

            ddlmou.DataSource = ds;
            ddlmou.DataValueField = "Code_Id";
            ddlmou.DataTextField = "Description";
            ddlmou.DataBind();
            ddlmou.Items.Insert(0, new ListItem("--Select--", "0"));
        }

    }
    protected void BindTransactionTypes()
    {
        SqlConnection sqlCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);

        SqlCommand cmd = new SqlCommand("KMPL_SearchCodeMaster_SP", sqlCon);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@Types", "CMTransTypes");
        cmd.Parameters.AddWithValue("@Level", 1);
        SqlDataAdapter adp = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        adp.Fill(ds);

        if (ds != null && ds.Tables[0].Rows.Count > 0)
        {
            ddlTransType.DataSource = ds;
            ddlTransType.DataValueField = "Code_Id";
            ddlTransType.DataTextField = "Description";
            ddlTransType.DataBind();
            ddlTransType.Items.Insert(0, new ListItem("--Select--", "0"));


        }
    }
    protected void BindACTypes()
    {
        SqlConnection sqlCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);

        SqlCommand cmd = new SqlCommand("KMPL_SearchCodeMaster_SP", sqlCon);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@Types", "CMACTypes");
        cmd.Parameters.AddWithValue("@Level", 1);
        SqlDataAdapter adp = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        adp.Fill(ds);

        if (ds != null && ds.Tables[0].Rows.Count > 0)
        {
            ddlac_type.DataSource = ds;
            ddlac_type.DataValueField = "Code_Id";
            ddlac_type.DataTextField = "Description";
            ddlac_type.DataBind();
            ddlac_type.Items.Insert(0, new ListItem("--Select--", "0"));
        }
    }
    /// <summary>
    /// Added By Prachi on NOv17
    /// </summary>
    private void Get_StateGST()
    {
        try
        {

            SqlConnection sqlCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);

            sqlCon.Open();
            SqlCommand sqlCom = new SqlCommand();
            sqlCom.Connection = sqlCon;
            sqlCom.CommandType = CommandType.StoredProcedure;
            sqlCom.CommandText = "CommonMaster_Get_STateGSTList_SP";


            SqlDataAdapter sqlDA = new SqlDataAdapter();
            sqlDA.SelectCommand = sqlCom;

            DataTable dt = new DataTable();
            sqlDA.Fill(dt);
            sqlCon.Close();

            ddlState.DataTextField = "StateName";
            ddlState.DataValueField = "Statecode";

            ddlState.DataSource = dt;
            ddlState.DataBind();

            ddlState.Items.Insert(0, "--Select--");
            ddlState.SelectedIndex = 0;


        }
        catch (Exception ex)
        {
            lblMessage.Visible = true;
            lblMessage.Text = ex.Message;
            lblMessage.CssClass = "ErrorMessage";
        }


    }
    /// <summary>
    /// end
    /// </summary>
    protected void btnSaveChanges_Click(object sender, EventArgs e)
    {
        Insert_PayeeMaster();
        txtPayeeNameSearch.Text = txtPayeeName.Text.Trim();
        Get_PayeeMasterList_BranchWise();
        Clear_Controls();
    }
    private void Register_ControlsWithJavascripts()
    {
        btnSaveChanges.Attributes.Add("Onclick", "javascript:return Validate_Save();");
        btnAddnew.Attributes.Add("Onclick", "javascript:return Validate_AddNew();");
    }
    protected void btnAddnew_Click(object sender, EventArgs e)
    {

    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/pages/menu.aspx", true);
    }

    public string strDate(string strInDate)
    {
        string strDD = strInDate.Substring(0, 2);
        string strMM = strInDate.Substring(3, 2);
        string strYYYY = strInDate.Substring(6, 4);
        string strMMDDYYYY = strMM + "/" + strDD + "/" + strYYYY;
        DateTime dtConvertDate = Convert.ToDateTime(strMMDDYYYY);
        string strOutDate = dtConvertDate.ToString("dd-MMM-yyyy");
        return strOutDate;
    }


    private void Insert_PayeeMaster()
    {
        try
        {



            Object SaveUSERInfo = (Object)Session["UserInfo"];

            SqlConnection sqlCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);


            string abc = Convert.ToString(((UserInfo.structUSERInfo)(SaveUSERInfo)).UserId);

            if (abc == "P00114" || abc == "P67995" || abc == "P68531" || abc == "P48046" || abc == "P00030")
            {


                sqlCon.Open();
                SqlCommand sqlCom = new SqlCommand();
                sqlCom.Connection = sqlCon;
                sqlCom.CommandType = CommandType.StoredProcedure;
                sqlCom.CommandText = "CommonMaster_Insert_PayeeMaster_demo1912_SP";

                SqlParameter BranchID = new SqlParameter();
                BranchID.SqlDbType = SqlDbType.Int;
                BranchID.Value = Convert.ToInt32(((UserInfo.structUSERInfo)(SaveUSERInfo)).BranchId);//pBranchId;
                BranchID.ParameterName = "@BranchID";
                sqlCom.Parameters.Add(BranchID);

                SqlParameter Payee_ID = new SqlParameter();
                Payee_ID.SqlDbType = SqlDbType.Int;
                Payee_ID.Value = hdnPayeeID.Value;
                Payee_ID.ParameterName = "@Payee_ID";
                sqlCom.Parameters.Add(Payee_ID);

                SqlParameter Payee_Name = new SqlParameter();
                Payee_Name.SqlDbType = SqlDbType.VarChar;
                Payee_Name.Value = txtPayeeName.Text.Trim();
                Payee_Name.ParameterName = "@Payee_Name";
                sqlCom.Parameters.Add(Payee_Name);

                SqlParameter Payee_Address = new SqlParameter();
                Payee_Address.SqlDbType = SqlDbType.VarChar;
                Payee_Address.Value = txt_Address.Text.Trim();
                Payee_Address.ParameterName = "@Payee_Address";
                sqlCom.Parameters.Add(Payee_Address);

                if ((ddlState.SelectedValue != "0") && (ddlState.SelectedValue != "--Select--"))
                {
                    SqlParameter Payee_City = new SqlParameter();
                    Payee_City.SqlDbType = SqlDbType.VarChar;
                    Payee_City.Value = ddlState.SelectedItem.Value;
                    Payee_City.ParameterName = "@Payee_City";
                    sqlCom.Parameters.Add(Payee_City);
                }
                else
                {
                    lblMessage.Text = "Kindly Select State..!";
                    return;
                }


                SqlParameter Payee_ContactNo = new SqlParameter();
                Payee_ContactNo.SqlDbType = SqlDbType.VarChar;
                Payee_ContactNo.Value = txtContactNo.Text.Trim();
                Payee_ContactNo.ParameterName = "@Payee_ContactNo";
                sqlCom.Parameters.Add(Payee_ContactNo);

                SqlParameter Payee_EmailID = new SqlParameter();
                Payee_EmailID.SqlDbType = SqlDbType.VarChar;
                Payee_EmailID.Value = txtEMailId.Text.Trim();
                Payee_EmailID.ParameterName = "@Payee_EmailID";
                sqlCom.Parameters.Add(Payee_EmailID);

                SqlParameter Payee_TransactionType = new SqlParameter();
                Payee_TransactionType.SqlDbType = SqlDbType.Int;
                Payee_TransactionType.Value = Convert.ToInt32(ddlTransType.SelectedItem.Value);
                Payee_TransactionType.ParameterName = "@Payee_TransactionType";
                sqlCom.Parameters.Add(Payee_TransactionType);

                SqlParameter Payee_Issue_Name = new SqlParameter();
                Payee_Issue_Name.SqlDbType = SqlDbType.VarChar;
                Payee_Issue_Name.Value = txtChequeIssueTowhom.Text.Trim();
                Payee_Issue_Name.ParameterName = "@Payee_Issue_Name";
                sqlCom.Parameters.Add(Payee_Issue_Name);

                SqlParameter Account_Holder_Name = new SqlParameter();
                Account_Holder_Name.SqlDbType = SqlDbType.VarChar;
                Account_Holder_Name.Value = txtAccountHolderName.Text.Trim();
                Account_Holder_Name.ParameterName = "@Account_Holder_Name";
                sqlCom.Parameters.Add(Account_Holder_Name);

                SqlParameter Account_No = new SqlParameter();
                Account_No.SqlDbType = SqlDbType.VarChar;
                Account_No.Value = txtAccountNo.Text.Trim();
                Account_No.ParameterName = "@Account_No";
                sqlCom.Parameters.Add(Account_No);

                SqlParameter Bank_Name = new SqlParameter();
                Bank_Name.SqlDbType = SqlDbType.VarChar;
                Bank_Name.Value = txtBankName.Text.Trim();
                Bank_Name.ParameterName = "@Bank_Name";
                sqlCom.Parameters.Add(Bank_Name);

                SqlParameter Branch_Name = new SqlParameter();
                Branch_Name.SqlDbType = SqlDbType.VarChar;
                Branch_Name.Value = txtBranchName.Text.Trim();
                Branch_Name.ParameterName = "@Branch_Name";
                sqlCom.Parameters.Add(Branch_Name);

                SqlParameter Pan_No = new SqlParameter();
                Pan_No.SqlDbType = SqlDbType.VarChar;
                Pan_No.Value = txtPanNo.Text.Trim();
                Pan_No.ParameterName = "@Pan_No";
                sqlCom.Parameters.Add(Pan_No);

                if ((ddlIsActive.SelectedValue != "0") && (ddlIsActive.SelectedValue != "--Select--"))
                {
                    SqlParameter Is_Active = new SqlParameter();
                    Is_Active.SqlDbType = SqlDbType.Bit;
                    Is_Active.Value = Convert.ToBoolean(ddlIsActive.SelectedItem.Value);
                    Is_Active.ParameterName = "@Is_Active";
                    sqlCom.Parameters.Add(Is_Active);
                }
                else
                {
                    lblMessage.Text = "Kindly Select Is Active..!";
                    return;

                }

                if (ddlIsActiveGST.SelectedValue != "0")
                {
                    SqlParameter Is_GSTActive = new SqlParameter();
                    Is_GSTActive.SqlDbType = SqlDbType.Bit;
                    Is_GSTActive.Value = Convert.ToBoolean(ddlIsActiveGST.SelectedValue);
                    Is_GSTActive.ParameterName = "@Is_GSTActive";
                    sqlCom.Parameters.Add(Is_GSTActive);
                }
                else
                {
                    SqlParameter Is_GSTActive = new SqlParameter();
                    Is_GSTActive.SqlDbType = SqlDbType.Bit;
                    Is_GSTActive.Value = DBNull.Value;
                    Is_GSTActive.ParameterName = "@Is_GSTActive";
                    sqlCom.Parameters.Add(Is_GSTActive);

                }


                ////added

                if (ddlIsActiveGST.SelectedValue.ToString().Trim() != "true" || txtGSTNo.Text != "")
                {
                }
                else
                {
                    lblMessage.Text = "Kindly Enter GST No..!";
                    return;
                }

                ///ended
                ///

                SqlParameter GST_prefx = new SqlParameter();
                GST_prefx.SqlDbType = SqlDbType.VarChar;
                GST_prefx.Value = (txtgstprefx.Text.Trim());
                GST_prefx.ParameterName = "@GST_prefx";
                sqlCom.Parameters.Add(GST_prefx);

                SqlParameter GST_NO = new SqlParameter();
                GST_NO.SqlDbType = SqlDbType.VarChar;
                GST_NO.Value = (txtGSTNo.Text.Trim());
                GST_NO.ParameterName = "@GST_NO";
                sqlCom.Parameters.Add(GST_NO);


                SqlParameter GST_code = new SqlParameter();
                GST_code.SqlDbType = SqlDbType.VarChar;
                GST_code.Value = txtGST_code.Text.Trim();
                GST_code.ParameterName = "@GST_code";
                sqlCom.Parameters.Add(GST_code);


                SqlParameter ActualGST = new SqlParameter();
                ActualGST.SqlDbType = SqlDbType.VarChar;
                ActualGST.Value = ((txtgstprefx.Text.Trim()) + (txtGSTNo.Text.Trim()));
                ActualGST.ParameterName = "@ActualGST";
                sqlCom.Parameters.Add(ActualGST);

                SqlParameter UserID = new SqlParameter();
                UserID.SqlDbType = SqlDbType.VarChar;
                UserID.Value = Convert.ToString(((UserInfo.structUSERInfo)(SaveUSERInfo)).UserId);
                UserID.ParameterName = "@UserID";
                sqlCom.Parameters.Add(UserID);

                SqlParameter Account_type = new SqlParameter();
                Account_type.SqlDbType = SqlDbType.VarChar;
                Account_type.Value = Convert.ToInt32(ddlac_type.SelectedItem.Value);
                Account_type.ParameterName = "@Account_type";
                sqlCom.Parameters.Add(Account_type);

                SqlParameter IFSC_code = new SqlParameter();
                IFSC_code.SqlDbType = SqlDbType.VarChar;
                IFSC_code.Value = txtIFSC_code.Text.Trim();
                IFSC_code.ParameterName = "@IFSC_code";
                sqlCom.Parameters.Add(IFSC_code);

                SqlParameter ND_status = new SqlParameter();
                ND_status.SqlDbType = SqlDbType.VarChar;
                ND_status.Value = ddlND.Text.Trim();
                ND_status.ParameterName = "@ND_status";
                sqlCom.Parameters.Add(ND_status);


                SqlParameter mou_status = new SqlParameter();
                mou_status.SqlDbType = SqlDbType.VarChar;
                mou_status.Value = ddlmou.Text.Trim();
                mou_status.ParameterName = "@MOU_status";
                sqlCom.Parameters.Add(mou_status);

                if ((txtNDvalidfrom.Text.ToString() != "") && (txtNDvalidfrom.Text.ToString() != " "))
                {
                    SqlParameter ND_validfrom = new SqlParameter();
                    ND_validfrom.SqlDbType = SqlDbType.DateTime;
                    ND_validfrom.Value = strDate(txtNDvalidfrom.Text.Trim().ToString());
                    ND_validfrom.ParameterName = "@ND_validfrom";
                    sqlCom.Parameters.Add(ND_validfrom);
                }
                else
                {
                    SqlParameter ND_validfrom = new SqlParameter();
                    ND_validfrom.SqlDbType = SqlDbType.DateTime;
                    ND_validfrom.Value = DBNull.Value;
                    ND_validfrom.ParameterName = "@ND_validfrom";
                    sqlCom.Parameters.Add(ND_validfrom);

                }
                if ((txtNdvalidupto.Text.ToString() != "") && (txtNdvalidupto.Text.ToString() != " "))
                {
                    SqlParameter ND_validupto = new SqlParameter();
                    ND_validupto.SqlDbType = SqlDbType.DateTime;
                    ND_validupto.Value = strDate(txtNdvalidupto.Text.Trim().ToString());
                    ND_validupto.ParameterName = "@ND_validupto";
                    sqlCom.Parameters.Add(ND_validupto);
                }
                else
                {

                    SqlParameter ND_validupto = new SqlParameter();
                    ND_validupto.SqlDbType = SqlDbType.DateTime;
                    ND_validupto.Value = DBNull.Value;
                    ND_validupto.ParameterName = "@ND_validupto";
                    sqlCom.Parameters.Add(ND_validupto);

                }
                if ((txtMouvalidfrom.Text.ToString() != "") && (txtMouvalidfrom.Text.ToString() != " "))
                {
                    SqlParameter MOU_validfrom = new SqlParameter();
                    MOU_validfrom.SqlDbType = SqlDbType.DateTime;
                    MOU_validfrom.Value = strDate(txtMouvalidfrom.Text.Trim().ToString());
                    MOU_validfrom.ParameterName = "@MOU_validfrom";
                    sqlCom.Parameters.Add(MOU_validfrom);
                }
                else
                {

                    SqlParameter MOU_validfrom = new SqlParameter();
                    MOU_validfrom.SqlDbType = SqlDbType.DateTime;
                    MOU_validfrom.Value = DBNull.Value;
                    MOU_validfrom.ParameterName = "@MOU_validfrom";
                    sqlCom.Parameters.Add(MOU_validfrom);

                }
                if ((txtMouvalidupto.Text.ToString() != "") && (txtMouvalidupto.Text.ToString() != " "))
                {
                    SqlParameter MOU_validTo = new SqlParameter();
                    MOU_validTo.SqlDbType = SqlDbType.DateTime;
                    MOU_validTo.Value = strDate(txtMouvalidupto.Text.Trim().ToString());
                    MOU_validTo.ParameterName = "@MOU_validTo";
                    sqlCom.Parameters.Add(MOU_validTo);
                }
                else
                {
                    SqlParameter MOU_validTo = new SqlParameter();
                    MOU_validTo.SqlDbType = SqlDbType.DateTime;
                    MOU_validTo.Value = DBNull.Value;
                    MOU_validTo.ParameterName = "@MOU_validTo";
                    sqlCom.Parameters.Add(MOU_validTo);


                }

                int RowEffected = sqlCom.ExecuteNonQuery();
                sqlCon.Close();

                if (RowEffected > 0)
                {
                    lblMessage.Text = "Data updated Successfully!";
                    lblMessage.CssClass = "SuccessMessage";

                    txtPayeeNameSearch.Text = txtPayeeName.Text.Trim();
                    Get_PayeeMasterList_BranchWise();
                    Clear_Controls();
                }
            }
            else
            {
                lblMessage.Text = "To Add Payee Name please contact To Ho Admin Team";

            }


        }
        catch (Exception ex)
        {
            lblMessage.Visible = true;
            lblMessage.Text = ex.Message;
            lblMessage.CssClass = "ErrorMessage";
        }


    }

    private void Get_PayeeMasterList_BranchWise()
    {
        try
        {
            Object SaveUSERInfo = (Object)Session["UserInfo"];

            SqlConnection sqlCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);

            sqlCon.Open();
            SqlCommand sqlCom = new SqlCommand();
            sqlCom.Connection = sqlCon;
            sqlCom.CommandType = CommandType.StoredProcedure;
            sqlCom.CommandText = "CommonMaster_Get_PayeeMasterList_BranchWise_demo25612_SP";//Get_PayeeMasterList_BranchWise_demo256

            SqlParameter BranchId = new SqlParameter();
            BranchId.SqlDbType = SqlDbType.Int;
            BranchId.Value = Convert.ToInt32(((UserInfo.structUSERInfo)(SaveUSERInfo)).BranchId);//pBranchId;
            BranchId.ParameterName = "@BranchId";
            sqlCom.Parameters.Add(BranchId);


            SqlParameter IsActive = new SqlParameter();
            IsActive.SqlDbType = SqlDbType.Bit;
            IsActive.Value = false;
            IsActive.ParameterName = "@IsActive";
            sqlCom.Parameters.Add(IsActive);

            SqlParameter PayeeName = new SqlParameter();
            PayeeName.SqlDbType = SqlDbType.VarChar;
            PayeeName.Value = txtPayeeNameSearch.Text.Trim();
            PayeeName.ParameterName = "@PayeeName";
            sqlCom.Parameters.Add(PayeeName);

            SqlDataAdapter sqlDA = new SqlDataAdapter();
            sqlDA.SelectCommand = sqlCom;


            DataTable dt = new DataTable();
            sqlDA.Fill(dt);
            sqlCon.Close();
            if (dt.Rows.Count > 0)
            {
                grv_PayeeList.DataSource = dt;
                grv_PayeeList.DataBind();
            }
            else
            {
                grv_PayeeList.DataSource = null;
                grv_PayeeList.DataBind();
            }


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
        Get_PayeeMasterList_BranchWise();
    }
    private void Clear_Controls()
    {
        hdnPayeeID.Value = "0";
        txt_Address.Text = "";
        txtAccountHolderName.Text = "";
        txtAccountNo.Text = "";
        txtBankName.Text = "";
        txtBranchName.Text = "";
        txtChequeIssueTowhom.Text = "";
        ddlState.SelectedIndex = 0;
        txtContactNo.Text = "";
        txtEMailId.Text = "";
        txtPanNo.Text = "";
        txtPayeeName.Text = "";
        txtPayeeNameSearch.Text = "";
        ddlIsActive.SelectedIndex = 0;
        ddlTransType.SelectedIndex = 0;
        ddlac_type.SelectedIndex = 0;
        txtIFSC_code.Text = "";
        ddlIsActiveGST.SelectedIndex = 0;
        txtGSTNo.Text = "";
        ddlND.SelectedIndex = 0;
        txtNDvalidfrom.Text = "";
        txtNdvalidupto.Text = "";
        ddlmou.SelectedIndex = 0;
        txtMouvalidfrom.Text = "";
        txtMouvalidupto.Text = "";

    }
    protected void grv_PayeeList_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Attributes.Add("onclick", "javascript:Pro_SelectRow('" + e.Row.RowIndex + "','" + e.Row.Cells[16].Text + "')");
            // e.Row.Attributes.Add("onmouseover", "javascript:hover('in','" + e.Row.RowIndex + "');");
            // e.Row.Attributes.Add("onmouseout", "javascript:hover('out','" + e.Row.RowIndex + "');");

        }
    }

    protected void ddlIsActiveGST_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlIsActiveGST.SelectedValue.ToString() == "True")
        {
            txtGSTNo.Enabled = true;
            txtGST_code.Enabled = true;
        }
        else
        {
            txtgstprefx.Text = "";
            txtGSTNo.Enabled = false;
            txtGST_code.Enabled = false;
        }
    }

    private void Get_GSTCode()
    {
        try
        {

            SqlConnection sqlCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);

            sqlCon.Open();
            SqlCommand sqlCom = new SqlCommand();
            sqlCom.Connection = sqlCon;
            sqlCom.CommandType = CommandType.StoredProcedure;
            sqlCom.CommandText = "CommonMaster_Get_STateGST_SP";

            SqlParameter Statecode = new SqlParameter();
            Statecode.SqlDbType = SqlDbType.VarChar;
            Statecode.Value = ddlState.SelectedValue.ToString();
            Statecode.ParameterName = "@Statecode";
            sqlCom.Parameters.Add(Statecode);


            SqlDataAdapter sqlDA = new SqlDataAdapter();
            sqlDA.SelectCommand = sqlCom;

            DataTable dt = new DataTable();
            sqlDA.Fill(dt);
            sqlCon.Close();

            txtgstprefx.Text = dt.Rows[0]["GStNO"].ToString();

        }
        catch (Exception ex)
        {
            lblMessage.Visible = true;
            lblMessage.Text = ex.Message;
            lblMessage.CssClass = "ErrorMessage";
        }


    }


    protected void ddlState_SelectedIndexChanged(object sender, EventArgs e)
    {
        Get_GSTCode();
    }

}
