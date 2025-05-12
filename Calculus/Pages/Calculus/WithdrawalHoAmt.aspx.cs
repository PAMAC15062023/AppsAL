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
using System.Data.OleDb;

public partial class Pages_Calculus_WithdrawalHoAmt : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                //Get_BranchIDInfo();//16Jan19
                Get_GridOpeningBalanceData();
                Register_Validation_On_Field();
                //Get_BranchList();//16Jan19
                ShwRemain_OpeningBalanceData();
            }
        }
        catch (Exception ex)
        {
            lblMessage.Visible = true;
            lblMessage.Text = ex.Message;
            lblMessage.CssClass = "ErrorMessage";
        }
    }
    private void Get_BranchIDInfo()
    {
        Object SaveUSERInfo = (Object)Session["UserInfo"];

        // lblBranchName.Text = Convert.ToString(((UserInfo.structUSERInfo)(SaveUSERInfo)).BranchName);

    }
    //private void Get_BranchList()
    //{
    //    try
    //    {

    //        SqlConnection sqlCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);

    //        sqlCon.Open();
    //        SqlCommand sqlCom = new SqlCommand();
    //        sqlCom.Connection = sqlCon;
    //        sqlCom.CommandType = CommandType.StoredProcedure;
    //        sqlCom.CommandText = "Get_AllBranchList";
    //        SqlDataAdapter sqlDA = new SqlDataAdapter();
    //        sqlDA.SelectCommand = sqlCom;
    //        DataTable dt = new DataTable();
    //        sqlDA.Fill(dt);
    //        sqlCon.Close();

    //        ddlBranchList.DataTextField = "BranchName";
    //        ddlBranchList.DataValueField = "BranchId";
    //        ddlBranchList.DataSource = dt;
    //        ddlBranchList.DataBind();

    //        ddlBranchList.Items.Insert(0, "--Select--");
    //        ddlBranchList.SelectedIndex = 0;

    //    }
    //    catch (Exception ex)
    //    {
    //        lblMessage.Visible = true;
    //        lblMessage.Text = ex.Message;
    //    }
    //}
    private void Register_Validation_On_Field()
    {
        btnSave.Attributes.Add("onclick", "javascript:return Validation_AllField();");
        //btnSave.Attributes.Add("onclick", "javascript:return CheckStatus();");
        //ddlYear.Attributes.Add("onblur", "javascript:return dropdown_validator();");
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (Convert.ToInt32(txtAmount.Text.Trim(), 10) % 100 == 0)
        {
            Insert_OpeningBalanceData();
        }
        else 
        {
            lblMessage.Text = "Plz Enter Withdrawal Amount Which Is Multiple of 100";
            return;
        }

        //Get_GridOpeningBalanceData();
        //ClearAllTextField();

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
    protected void ShwRemain_OpeningBalanceData()
    {
        try
        {
            Object SaveUSERInfo = (Object)Session["UserInfo"];

            SqlConnection sqlCon = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);

            sqlCon.Open();
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.Connection = sqlCon;
            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCmd.CommandText = "CalOnlineTrans_Show_Withdrawal_HO_Amount1_SP";//Show_WithdrawalHOAmount

            SqlParameter openingBalanceID = new SqlParameter();
            openingBalanceID.SqlDbType = SqlDbType.Int;
            openingBalanceID.Value = hndOpeningBalId.Value;
            openingBalanceID.ParameterName = "@openingBalanceID";
            sqlCmd.Parameters.Add(openingBalanceID);

            SqlParameter BranchID = new SqlParameter();
            BranchID.SqlDbType = SqlDbType.Int;
            BranchID.Value = Convert.ToInt32(((UserInfo.structUSERInfo)(SaveUSERInfo)).BranchId);
            BranchID.ParameterName = "@BranchID";
            sqlCmd.Parameters.Add(BranchID);


            //string strYrMonth = DateTime.Now.ToString("yyyyMMdd"); //Get_DateFormat(txtWithdrawDate.Text, "yyyyMMdd");
            string Month = ddlMonth.SelectedItem.Value.ToString().Trim();
            string Year = ddlYear.SelectedItem.Value.ToString().Trim();
            string strYrMonth = Year + Month; //Get_DateFormat(txtWithdrawDate.Text, "yyyyMMdd");

            SqlParameter OpeningBalanceYrMonth = new SqlParameter();
            OpeningBalanceYrMonth.SqlDbType = SqlDbType.VarChar;
            OpeningBalanceYrMonth.Value = strYrMonth.Substring(0, 6);
            OpeningBalanceYrMonth.ParameterName = "@OpeningBalanceYrMonth";
            sqlCmd.Parameters.Add(OpeningBalanceYrMonth);

            SqlParameter RequestType = new SqlParameter();
            RequestType.SqlDbType = SqlDbType.VarChar;
            RequestType.Value = "1";
            RequestType.ParameterName = "@RequestType";
            sqlCmd.Parameters.Add(RequestType);


            SqlParameter ClientId = new SqlParameter();
            ClientId.SqlDbType = SqlDbType.Int;
            ClientId.Value = Convert.ToInt32(((UserInfo.structUSERInfo)(SaveUSERInfo)).ClientId);
            ClientId.ParameterName = "@ClientId";
            sqlCmd.Parameters.Add(ClientId);

            SqlParameter VarResult = new SqlParameter();
            VarResult.SqlDbType = SqlDbType.VarChar;
            VarResult.Value = lblHOAmount.Text;
            VarResult.ParameterName = "@RemainWithHOAmt";
            VarResult.Size = 200;
            VarResult.Direction = ParameterDirection.Output;
            sqlCmd.Parameters.Add(VarResult);

            sqlCmd.ExecuteNonQuery();
            string RowEffected = Convert.ToString(sqlCmd.Parameters["@RemainWithHOAmt"].Value + ".00");

            sqlCon.Close();

            if (RowEffected != "")
            {
                lblHOAmount.Text = RowEffected;
                lblHOAmount.Visible = true;
            }
        }
        catch (Exception ex)
        {
            lblMessage.Visible = true;
            lblMessage.Text = ex.Message;
            lblMessage.CssClass = "Error Message";
        }
    }
    protected void Insert_OpeningBalanceData()
    {
        try
        {
            Object SaveUSERInfo = (Object)Session["UserInfo"];

            SqlConnection sqlCon = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);

            sqlCon.Open();
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.Connection = sqlCon;
            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCmd.CommandText = "CalOnlineTrans_InsertWithdrawalHOAmount1_SP";//Insert_WithdrawalHOAmount

            SqlParameter openingBalanceID = new SqlParameter();
            openingBalanceID.SqlDbType = SqlDbType.Int;
            openingBalanceID.Value = hndOpeningBalId.Value;
            openingBalanceID.ParameterName = "@openingBalanceID";
            sqlCmd.Parameters.Add(openingBalanceID);

            SqlParameter BranchID = new SqlParameter();
            BranchID.SqlDbType = SqlDbType.Int;
            BranchID.Value = ((UserInfo.structUSERInfo)(SaveUSERInfo)).BranchId;//ddlBranchList.SelectedValue.ToString();
            BranchID.ParameterName = "@BranchID";
            sqlCmd.Parameters.Add(BranchID);

            SqlParameter WithdrawDate = new SqlParameter();
            WithdrawDate.SqlDbType = SqlDbType.VarChar;
            WithdrawDate.Value = txtWithdrawDate.Text.Trim();
            WithdrawDate.ParameterName = "@WithdrawDate";
            sqlCmd.Parameters.Add(WithdrawDate);

            if (ddlMonth.SelectedItem.Value.ToString().Trim() != "-Select-")
            {
            }
            else
            {
                lblMessage.Text = "Kindly Select Actual Month Of Withdrawal..!!";
                return;
            }


            if (ddlYear.SelectedItem.Value.ToString().Trim() != "--Select--")
            {
            }
            else
            {
                lblMessage.Text = "Kindly Select Actual Year Of Withdrawal..!!";
                return;
            }

            string Month = ddlMonth.SelectedItem.Value.ToString().Trim();
            string Year = ddlYear.SelectedItem.Value.ToString().Trim();
            string strYrMonth = Year + Month; //Get_DateFormat(txtWithdrawDate.Text, "yyyyMMdd");

            SqlParameter OpeningBalanceYrMonth = new SqlParameter();
            OpeningBalanceYrMonth.SqlDbType = SqlDbType.VarChar;
            OpeningBalanceYrMonth.Value = strYrMonth.Substring(0, 6);
            OpeningBalanceYrMonth.ParameterName = "@OpeningBalanceYrMonth";
            sqlCmd.Parameters.Add(OpeningBalanceYrMonth);

            //string strYrMonth = Get_DateFormat(txtWithdrawDate.Text, "yyyyMMdd");

            //SqlParameter OpeningBalanceYrMonth = new SqlParameter();
            //OpeningBalanceYrMonth.SqlDbType = SqlDbType.VarChar;
            //OpeningBalanceYrMonth.Value = strYrMonth.Substring(0, 6);
            //OpeningBalanceYrMonth.ParameterName = "@OpeningBalanceYrMonth";
            //sqlCmd.Parameters.Add(OpeningBalanceYrMonth);

            //SqlParameter OpeningBalanceYrMonth = new SqlParameter();
            //OpeningBalanceYrMonth.SqlDbType = SqlDbType.VarChar;
            //OpeningBalanceYrMonth.Value = ddlYear.Text.Trim() + ddlMonth.Text.Trim();
            //OpeningBalanceYrMonth.ParameterName = "@OpeningBalanceYrMonth";
            //sqlCmd.Parameters.Add(OpeningBalanceYrMonth);

            SqlParameter OpeningBalanceAmount = new SqlParameter();
            OpeningBalanceAmount.SqlDbType = SqlDbType.Decimal;
            OpeningBalanceAmount.Value = txtAmount.Text.Trim();
            OpeningBalanceAmount.ParameterName = "@OpeningBalanceAmount";
            sqlCmd.Parameters.Add(OpeningBalanceAmount);

            SqlParameter RequestType = new SqlParameter();
            RequestType.SqlDbType = SqlDbType.VarChar;
            RequestType.Value = ddlRequestType.SelectedItem.Value;
            RequestType.ParameterName = "@RequestType";
            sqlCmd.Parameters.Add(RequestType);

            SqlParameter Remark = new SqlParameter();
            Remark.SqlDbType = SqlDbType.VarChar;
            Remark.Value = txtRemark.Text.Trim();
            Remark.ParameterName = "@Remark";
            sqlCmd.Parameters.Add(Remark);


            SqlParameter ClientId = new SqlParameter();
            ClientId.SqlDbType = SqlDbType.Int;
            ClientId.Value = Convert.ToInt32(((UserInfo.structUSERInfo)(SaveUSERInfo)).ClientId);
            ClientId.ParameterName = "@ClientId";
            sqlCmd.Parameters.Add(ClientId);


            SqlParameter UserID = new SqlParameter();
            UserID.SqlDbType = SqlDbType.VarChar;
            UserID.Value = Convert.ToString(((UserInfo.structUSERInfo)(SaveUSERInfo)).UserId);
            UserID.ParameterName = "@User_ID";
            sqlCmd.Parameters.Add(UserID);

            //SqlParameter RemainWithHOAmt = new SqlParameter();
            //RemainWithHOAmt.SqlDbType = SqlDbType.Decimal;
            //RemainWithHOAmt.Value = lblHOAmount.Text.Trim();
            //RemainWithHOAmt.ParameterName = "@RemainWithHOAmt";
            //sqlCmd.Parameters.Add(RemainWithHOAmt);

            //SqlParameter VarResult = new SqlParameter();
            //VarResult.SqlDbType = SqlDbType.VarChar;
            //VarResult.Value = lblHOAmount.Text;
            //VarResult.ParameterName = "@VarResult";
            //VarResult.Size = 200;
            //VarResult.Direction = ParameterDirection.Output;
            //sqlCmd.Parameters.Add(VarResult);

            int SqlRow = 0;
            SqlRow = sqlCmd.ExecuteNonQuery();

            //string RowEffected = Convert.ToString(sqlCmd.Parameters["@VarResult"].Value);
            //lblHOAmount.Text = RowEffected;

            if (SqlRow > 0)
            {
                lblMessage.Text = "Update Successfully!";
                lblMessage.CssClass = "UpdateMessage";
                lblMessage.Visible = true;
                ShwRemain_OpeningBalanceData();
                Get_GridOpeningBalanceData();
                ClearAllTextField();
            }
            else
            {
                lblMessage.Text = "HO Withdrawal Amount exceeds limit!";
                lblMessage.CssClass = "UpdateMessage";
                lblMessage.Visible = true;
            }
        }
        catch (Exception ex)
        {
            lblMessage.Visible = true;
            lblMessage.Text = ex.Message;
            lblMessage.CssClass = "Error Message";
        }
    }
    private void Get_GridOpeningBalanceData()
    {

        try
        {

            string YEAR = "";
            string MONTH = "";

            if (ddlYear.SelectedValue != "--Select--")
            {
                YEAR = ddlYear.SelectedValue;
            }

            if (ddlMonth.SelectedValue != "-Select-")
            {
                MONTH = ddlMonth.SelectedValue;
            }


            Object SaveUSERInfo = (Object)Session["UserInfo"];

            SqlConnection SqlCon = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);

            SqlCon.Open();
            SqlCommand SqlCmd = new SqlCommand();
            SqlCmd.Connection = SqlCon;
            SqlCmd.CommandType = CommandType.StoredProcedure;
            SqlCmd.CommandText = "CalOnlineTrans_GetRequestHOWithdrBalanceData_SP";

            SqlParameter BranchID = new SqlParameter();
            BranchID.SqlDbType = SqlDbType.Int;
            BranchID.Value = ((UserInfo.structUSERInfo)(SaveUSERInfo)).BranchId;
            BranchID.ParameterName = "@BranchID";
            SqlCmd.Parameters.Add(BranchID);


            SqlParameter ClientId = new SqlParameter();
            ClientId.SqlDbType = SqlDbType.Int;
            ClientId.Value = Convert.ToInt32(((UserInfo.structUSERInfo)(SaveUSERInfo)).ClientId);
            ClientId.ParameterName = "@ClientId";
            SqlCmd.Parameters.Add(ClientId);

            SqlParameter Year = new SqlParameter();
            Year.SqlDbType = SqlDbType.VarChar;
            Year.Value = YEAR;
            Year.ParameterName = "@Year";
            SqlCmd.Parameters.Add(Year);

            SqlParameter Month = new SqlParameter();
            Month.SqlDbType = SqlDbType.VarChar;
            Month.Value = MONTH;
            Month.ParameterName = "@Month";
            SqlCmd.Parameters.Add(Month);

            SqlDataAdapter sqlDA = new SqlDataAdapter();
            sqlDA.SelectCommand = SqlCmd;

            DataTable dt = new DataTable();
            sqlDA.Fill(dt);
            SqlCon.Close();

            Gr_Ope_Bal.DataSource = dt;
            Gr_Ope_Bal.DataBind();
        }
        catch (Exception ex)
        {
            lblMessage.Visible = true;
            lblMessage.Text = ex.Message;
            lblMessage.CssClass = "Error Message";
        }
    }
    protected void ClearAllTextField()
    {
        //ddlYear.SelectedIndex = 0;
        //ddlMonth.SelectedIndex = 0;
        txtAmount.Text = "";
        txtRemark.Text = "";
        //lblMessage.Text = "";
        ddlRequestType.SelectedIndex = 0;
        hndOpeningBalId.Value = "0";
        //ddlBranchList.SelectedIndex = 0;//16Jan19
        txtWithdrawDate.Text = "";
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Pages/Menu.aspx", true);
    }
    protected void textActualDate_TextChanged(object sender, EventArgs e)
    {
        //Get_BranchIDInfo();//16Jan19
        Get_GridOpeningBalanceData();
        Register_Validation_On_Field();
        //Get_BranchList();//16Jan19
        ShwRemain_OpeningBalanceDataActual();
    }
    protected void ShwRemain_OpeningBalanceDataActual()
    {
        try
        {
            Object SaveUSERInfo = (Object)Session["UserInfo"];

            SqlConnection sqlCon = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);

            sqlCon.Open();
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.Connection = sqlCon;
            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCmd.CommandText = "CalOnlineTrans_Show_Withdrawal_HO_Amount1_SP";//Show_WithdrawalHOAmount

            SqlParameter openingBalanceID = new SqlParameter();
            openingBalanceID.SqlDbType = SqlDbType.Int;
            openingBalanceID.Value = hndOpeningBalId.Value;
            openingBalanceID.ParameterName = "@openingBalanceID";
            sqlCmd.Parameters.Add(openingBalanceID);

            SqlParameter BranchID = new SqlParameter();
            BranchID.SqlDbType = SqlDbType.Int;
            BranchID.Value = Convert.ToInt32(((UserInfo.structUSERInfo)(SaveUSERInfo)).BranchId);
            BranchID.ParameterName = "@BranchID";
            sqlCmd.Parameters.Add(BranchID);

            string Month = ddlMonth.SelectedItem.Value.ToString().Trim();
            string Year = ddlYear.SelectedItem.Value.ToString().Trim();
            string strYrMonth = Year + Month; //Get_DateFormat(txtWithdrawDate.Text, "yyyyMMdd");

            SqlParameter OpeningBalanceYrMonth = new SqlParameter();
            OpeningBalanceYrMonth.SqlDbType = SqlDbType.VarChar;
            OpeningBalanceYrMonth.Value = strYrMonth.Substring(0, 6);
            OpeningBalanceYrMonth.ParameterName = "@OpeningBalanceYrMonth";
            sqlCmd.Parameters.Add(OpeningBalanceYrMonth);

            SqlParameter RequestType = new SqlParameter();
            RequestType.SqlDbType = SqlDbType.VarChar;
            RequestType.Value = "1";
            RequestType.ParameterName = "@RequestType";
            sqlCmd.Parameters.Add(RequestType);


            SqlParameter ClientId = new SqlParameter();
            ClientId.SqlDbType = SqlDbType.Int;
            ClientId.Value = Convert.ToInt32(((UserInfo.structUSERInfo)(SaveUSERInfo)).ClientId);
            ClientId.ParameterName = "@ClientId";
            sqlCmd.Parameters.Add(ClientId);

            SqlParameter VarResult = new SqlParameter();
            VarResult.SqlDbType = SqlDbType.VarChar;
            VarResult.Value = lblHOAmount.Text;
            VarResult.ParameterName = "@RemainWithHOAmt";
            VarResult.Size = 200;
            VarResult.Direction = ParameterDirection.Output;
            sqlCmd.Parameters.Add(VarResult);

            sqlCmd.ExecuteNonQuery();
            string RowEffected = Convert.ToString(sqlCmd.Parameters["@RemainWithHOAmt"].Value + ".00");

            sqlCon.Close();

            if (RowEffected != "")
            {
                lblHOAmount.Text = RowEffected;
                lblHOAmount.Visible = true;
            }
        }
        catch (Exception ex)
        {
            lblMessage.Visible = true;
            lblMessage.Text = ex.Message;
            lblMessage.CssClass = "Error Message";
        }
    }
    protected void txtPaymentDate_TextChanged(object sender, EventArgs e)
    {
        //Get_BranchIDInfo();//16Jan19
        Get_GridOpeningBalanceData();
        Register_Validation_On_Field();
        //Get_BranchList();//16Jan19
        ShwRemain_OpeningBalanceDataActual();
    }
    protected void ddlMonth_SelectedIndexChanged(object sender, EventArgs e)
    {

        if (ddlYear.SelectedItem.Value.ToString().Trim() != "--Select--")
        {
        }
        else
        {
            lblMessage.Text = "Kindly Select Actual Year Of Withdrawal..!!";
            return;
        }
        //Get_BranchIDInfo();//16Jan19
        Get_GridOpeningBalanceData();
        Register_Validation_On_Field();
        //Get_BranchList();//16Jan19
        ShwRemain_OpeningBalanceDataActual();
    }
    protected void ddlYear_SelectedIndexChanged(object sender, EventArgs e)
    {
        lblMessage.Text = "";

        //Get_BranchIDInfo();//16Jan19
        Get_GridOpeningBalanceData();
        Register_Validation_On_Field();
        // Get_BranchList();//16Jan19
        ShwRemain_OpeningBalanceDataActual();
    }
    protected void btnHOTrnsfr_Click(object sender, EventArgs e)
    {
        Generate_ExcelFile();
    }
    private void Generate_ExcelFile()
    {

        string attachment = "";

        attachment = "attachment; filename=HoWithdrawReport.xls";
        Response.ClearContent();


        Response.AddHeader("content-disposition", attachment);
        Response.ContentType = "application/ms-excel";
        StringWriter sw = new System.IO.StringWriter();
        HtmlTextWriter htw = new HtmlTextWriter(sw);

        string style = @"<style><br/> <b><span style='background-color:Gray'> <font size='4'>PAMAC FINSERVE PVT. LTD.,HO Withdraw Details </font></span></b> <br/> </style> ";

        Gr_Ope_Bal.EnableViewState = false;

        Gr_Ope_Bal.RenderControl(htw);
        Response.Write(style);
        Response.Write(sw.ToString());

        Response.End();
    }
    public override void VerifyRenderingInServerForm(Control control)
    {

    }
}