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

public partial class CPRT_ChequeBookDetails : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        { 
            if(!IsPostBack)
            {
                Get_CodirList();
                Get_bankName();
              //  Get_branchName();
                //Get_BranchList();
                //Get_GroupInfo();
                Register_ControlswithJavascript();
            }
        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
            lblMessage.CssClass = "ErrorMessage";
            lblMessage.Visible = true;
        }

    }
    private void Get_CodirList()
    {
        try
        {

            SqlConnection sqlCon = new SqlConnection(ConfigurationSettings.AppSettings["CPRT_ConnectionString"]);

            sqlCon.Open();
            SqlCommand sqlCom = new SqlCommand();
            sqlCom.Connection = sqlCon;
            sqlCom.CommandType = CommandType.StoredProcedure;
            sqlCom.CommandText = "CPRT_Get_AllCoDirList_sp";
            SqlDataAdapter sqlDA = new SqlDataAdapter();
            sqlDA.SelectCommand = sqlCom;
            DataTable dt = new DataTable();
            sqlDA.Fill(dt);
            sqlCon.Close();

            ddlCodirList.DataTextField = "Company_Director_Name";
            ddlCodirList.DataValueField = "Company_Director_Name";
            ddlCodirList.DataSource = dt;
            ddlCodirList.DataBind();

            ddlCodirList.Items.Insert(0, "--Select--");
            ddlCodirList.SelectedIndex = 0;



        }
        catch (Exception ex)
        {
            lblMessage.Visible = true;
            lblMessage.Text = ex.Message;
            lblMessage.CssClass = "ErrorMessage";
        }
    }
    private void Get_bankName()
    {
        try
        {

            SqlConnection sqlCon = new SqlConnection(ConfigurationSettings.AppSettings["CPRT_ConnectionString"]);

            sqlCon.Open();
            SqlCommand sqlCom = new SqlCommand();
            sqlCom.Connection = sqlCon;
            sqlCom.CommandType = CommandType.StoredProcedure;
            sqlCom.CommandText = "CPRT_Get_AllBankList_sp";
            SqlDataAdapter sqlDA = new SqlDataAdapter();
            sqlDA.SelectCommand = sqlCom;
            DataTable dt = new DataTable();
            sqlDA.Fill(dt);
            sqlCon.Close();

            ddlBankName.DataTextField = "Bank_Name";
            ddlBankName.DataValueField = "Bank_ID";
            ddlBankName.DataSource = dt;
            ddlBankName.DataBind();

            ddlBankName.Items.Insert(0, "--Select--");
            ddlBankName.SelectedIndex = 0;



        }
        catch (Exception ex)
        {
            lblMessage.Visible = true;
            lblMessage.Text = ex.Message;
            lblMessage.CssClass = "ErrorMessage";
        }
    }
    private void Get_branchName()
    {
        try
        {

            SqlConnection sqlCon = new SqlConnection(ConfigurationSettings.AppSettings["CPRT_ConnectionString"]);

            sqlCon.Open();
            SqlCommand sqlCom = new SqlCommand();
            sqlCom.Connection = sqlCon;
            sqlCom.CommandType = CommandType.StoredProcedure;
            sqlCom.CommandText = "CPRT_Get_AllBranchList_sp";

            SqlParameter BankID = new SqlParameter();
            BankID.SqlDbType = SqlDbType.VarChar;
            BankID.Value = ddlBankName.SelectedValue.ToString();
            BankID.ParameterName = "@BankID";
            sqlCom.Parameters.Add(BankID);


            SqlDataAdapter sqlDA = new SqlDataAdapter();
            sqlDA.SelectCommand = sqlCom;
            DataTable dt = new DataTable();
            sqlDA.Fill(dt);
            sqlCon.Close();

            ddlBranchName.DataTextField = "Bank_BranchName";
            ddlBranchName.DataValueField = "Branch_code";
            ddlBranchName.DataSource = dt;
            ddlBranchName.DataBind();

            ddlBranchName.Items.Insert(0, "--Select--");
            ddlBranchName.SelectedIndex = 0;



        }
        catch (Exception ex)
        {
            lblMessage.Visible = true;
            lblMessage.Text = ex.Message;
            lblMessage.CssClass = "ErrorMessage";
        }
    }
    protected void ddlBankName_SelectedIndexChanged(object sender, EventArgs e)
    {
        Get_branchName();
      
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Pages/Menu.aspx", true);
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        Update_ChqDetails();
        //Get_GroupInfo();
        Reset_Control();
    }
    private void Update_ChqDetails()
    {
       // Object SaveUSERInfo = (Object)Session["UserInfo"];

        SqlConnection sqlCon = new SqlConnection(ConfigurationSettings.AppSettings["CPRT_ConnectionString"]);

        sqlCon.Open();
        SqlCommand sqlCom = new SqlCommand();
        sqlCom.Connection = sqlCon;
        sqlCom.CommandType = CommandType.StoredProcedure;
        sqlCom.CommandText = "CPRT_Update_CacnelledChq_sp";
        
        SqlParameter CodirList = new SqlParameter();
        CodirList.SqlDbType = SqlDbType.VarChar;
        CodirList.Value = ddlCodirList.SelectedItem.Value;
        CodirList.ParameterName = "@Codir";
        sqlCom.Parameters.Add(CodirList);

        SqlParameter BankId = new SqlParameter();
        BankId.SqlDbType = SqlDbType.VarChar;
        BankId.Value = ddlBankName.SelectedItem.Value;
        BankId.ParameterName = "@BankID";
        sqlCom.Parameters.Add(BankId);

        SqlParameter BranchID = new SqlParameter();
        BranchID.SqlDbType = SqlDbType.VarChar;
        BranchID.Value = ddlBranchName.SelectedItem.Value;
        BranchID.ParameterName = "@BranchID";
        sqlCom.Parameters.Add(BranchID);

        SqlParameter ChqStartNo = new SqlParameter();
        ChqStartNo.SqlDbType = SqlDbType.VarChar;
        ChqStartNo.Value = txtChqStartNo.Text.Trim();
        ChqStartNo.ParameterName = "@StartNo";
        sqlCom.Parameters.Add(ChqStartNo);

        SqlParameter stat = new SqlParameter();
        stat.SqlDbType = SqlDbType.VarChar;
        stat.Value = ddlIsActivate.SelectedItem.Value;
        stat.ParameterName = "@stat";
        sqlCom.Parameters.Add(stat);

        
        //SqlParameter ChqEndNo = new SqlParameter();
        //ChqEndNo.SqlDbType = SqlDbType.VarChar;
        //ChqEndNo.Value = txtChqEndNo.Text.Trim();
        //ChqEndNo.ParameterName = "@EndNo";
        //sqlCom.Parameters.Add(ChqEndNo);


        int Rows = 0;

        Rows = sqlCom.ExecuteNonQuery();

        if (Rows > 0)
        {
            lblMessage.Text = "Update Successfull!";
            lblMessage.CssClass = "UpdateMessage";
            lblMessage.Visible = true;
        }



    }
    private void Reset_Control()
    {
        //hdnGroupID.Value = "0";
        //txtGroupDescription.Text = "";
        //txtGroupName.Text = "";
        //ddlBranchList.SelectedIndex = 0;
        //ddlIsActivate.SelectedIndex = 0;

    }
    //protected void grv_GroupInfo_RowDataBound(object sender, GridViewRowEventArgs e)
    //{
    //    if (e.Row.RowType == DataControlRowType.DataRow)
    //    {
    //        e.Row.Attributes.Add("onclick", "javascript:Pro_SelectRow('" + e.Row.RowIndex + "','" + e.Row.Cells[0].Text + "')");
    //        e.Row.Attributes.Add("onmouseover", "javascript:hover('in','" + e.Row.RowIndex + "');");
    //        e.Row.Attributes.Add("onmouseout", "javascript:hover('out','" + e.Row.RowIndex + "');");
            
    //    }
    //}
    private void Register_ControlswithJavascript()
    {
        btnSave.Attributes.Add("onclick", "javascript:return ValidateSave();");
      /*  btnAddNew.Attributes.Add("onclick", "javascript:return ValidateAddNew();")*/;
   
    
    }
    //protected void btnAddNew_Click(object sender, EventArgs e)
    //{

    //}
}
