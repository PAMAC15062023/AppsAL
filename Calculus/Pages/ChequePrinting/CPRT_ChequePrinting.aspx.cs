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

public partial class CPRT_ChequePrinting : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        { 
            if(!IsPostBack)
            {

                string CompanyName = Request.QueryString["comp"];
                string Bank = Request.QueryString["Bank"];
                string Branch = Request.QueryString["Branch"];

                if (string.IsNullOrEmpty(CompanyName))
                { 
                    Get_CodirList();
                    Get_bankName();
                    //Register_ControlswithJavascript();
                }
                else
                {
                    Get_CodirList();
                    Get_bankName();
                    get_ChqDetails_1(CompanyName, Bank, Branch);
                    lblMessage.Text = CompanyName +" called from another program";
                }
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
            ddlBranchName.DataValueField = "Bank_BranchName";
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
       get_ChqDetails();
        //Get_GroupInfo();
        //Reset_Control();
    }
    private void get_ChqDetails()
    {
       // Object SaveUSERInfo = (Object)Session["UserInfo"];

      
        SqlConnection sqlcon = new SqlConnection(ConfigurationSettings.AppSettings["CPRT_ConnectionString"]);

        sqlcon.Open();
        SqlCommand sqlcmd = new SqlCommand();
        sqlcmd.Connection = sqlcon;
        sqlcmd.CommandType = CommandType.StoredProcedure;
        sqlcmd.CommandText = "CPRT_get_ChqDetails_sp";
        SqlDataAdapter sqlda = new SqlDataAdapter();
        sqlda.SelectCommand = sqlcmd;

        
        SqlParameter CodirList = new SqlParameter();
        CodirList.SqlDbType = SqlDbType.VarChar;
        CodirList.Value = ddlCodirList.SelectedItem.Value;
        CodirList.ParameterName = "@Codir";
        sqlcmd.Parameters.Add(CodirList);

        SqlParameter BankId = new SqlParameter();
        BankId.SqlDbType = SqlDbType.VarChar;
        BankId.Value = ddlBankName.SelectedItem.Text;
        BankId.ParameterName = "@BankID";
        sqlcmd.Parameters.Add(BankId);

        SqlParameter BranchID = new SqlParameter();
        BranchID.SqlDbType = SqlDbType.VarChar;
        BranchID.Value = ddlBranchName.SelectedItem.Value;
        BranchID.ParameterName = "@BranchID";
        sqlcmd.Parameters.Add(BranchID);

        DataTable dt = new DataTable();
        sqlda.Fill(dt);
        sqlcon.Close();

        if (dt.Rows.Count > 0)
        {
            lblMessage.Text = "Total No of Rows found :" + dt.Rows.Count;
            lblMessage.CssClass = "SuccessMessage";
            grvTransactionInfo.DataSource = dt;
            grvTransactionInfo.DataBind();
        }
        else
        {

            lblMessage.Text = "Total No of Rows found :" + dt.Rows.Count;
            lblMessage.CssClass = "ErrorMessage";
            grvTransactionInfo.DataSource = null;
            grvTransactionInfo.DataBind();
        }



    }
    private void get_ChqDetails_1(string codir, string bnk , string brch )
    {
        // Object SaveUSERInfo = (Object)Session["UserInfo"];


        SqlConnection sqlcon = new SqlConnection(ConfigurationSettings.AppSettings["CPRT_ConnectionString"]);

        sqlcon.Open();
        SqlCommand sqlcmd = new SqlCommand();
        sqlcmd.Connection = sqlcon;
        sqlcmd.CommandType = CommandType.StoredProcedure;
        sqlcmd.CommandText = "CPRT_get_ChqDetails_sp";
        SqlDataAdapter sqlda = new SqlDataAdapter();
        sqlda.SelectCommand = sqlcmd;


        SqlParameter CodirList = new SqlParameter();
        CodirList.SqlDbType = SqlDbType.VarChar;
        CodirList.Value = codir;
        CodirList.ParameterName = "@Codir";
        sqlcmd.Parameters.Add(CodirList);

        SqlParameter BankId = new SqlParameter();
        BankId.SqlDbType = SqlDbType.VarChar;
        BankId.Value = bnk;
        BankId.ParameterName = "@BankID";
        sqlcmd.Parameters.Add(BankId);

        SqlParameter BranchID = new SqlParameter();
        BranchID.SqlDbType = SqlDbType.VarChar;
        BranchID.Value = brch;
        BranchID.ParameterName = "@BranchID";
        sqlcmd.Parameters.Add(BranchID);

        DataTable dt = new DataTable();
        sqlda.Fill(dt);
        sqlcon.Close();

        if (dt.Rows.Count > 0)
        {
            lblMessage.Text = "Total No of Rows found :" + dt.Rows.Count;
            lblMessage.CssClass = "SuccessMessage";
            grvTransactionInfo.DataSource = dt;
            grvTransactionInfo.DataBind();
        }
        else
        {

            lblMessage.Text = "Total No of Rows found :" + dt.Rows.Count;
            lblMessage.CssClass = "ErrorMessage";
            grvTransactionInfo.DataSource = null;
            grvTransactionInfo.DataBind();
        }



    }
    protected void chkApprove_CheckedChanged(object source, EventArgs e)
    {  
        
        var checkbox = (CheckBox)source;
      //  CheckBox chk = (CheckBox)sender;
        if (checkbox.Checked)
        {
            GridViewRow grvRow = (GridViewRow)checkbox.NamingContainer;//This will give you row
            string @selectedrowid= grvRow.Cells[1].Text; //Updated the cell text in that row.
            Response.Redirect("CPRT_GereratorPrintFile.aspx?cname=" + @selectedrowid, true);

        }
    }
  
    //protected void btnView_Click(object sender, EventArgs e)
    //{
    //    //  Response.Redirect("ValidateChequeDataEntry.aspx?BN=" + hdnTransID.Value.Trim() + "&TID=0&CT=1", true);
    //    Response.Redirect("CPRT_GereratorPrintFile.aspx?cname=" + "PAMAC" + "&invno=" + 1234, true);
    //}
    
    //private void Reset_Control()
    //{
    //    //hdnGroupID.Value = "0";
    //    //txtGroupDescription.Text = "";
    //    //txtGroupName.Text = "";
    //    //ddlBranchList.SelectedIndex = 0;
    //    //ddlIsActivate.SelectedIndex = 0;

    //}
    protected void grvTransactionInfo_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Attributes.Add("onclick", "javascript:Pro_SelectRow('" + e.Row.RowIndex + "','" + e.Row.Cells[0].Text + "')");
            e.Row.Attributes.Add("onmouseover", "javascript:hover('in','" + e.Row.RowIndex + "');");
            e.Row.Attributes.Add("onmouseout", "javascript:hover('out','" + e.Row.RowIndex + "');");

        }
    }
    ////private void Register_ControlswithJavascript()
    //{
    //    //btnSave.Attributes.Add("onclick", "javascript:return ValidateSave();");
    //  /*  btnAddNew.Attributes.Add("onclick", "javascript:return ValidateAddNew();")*/;
   
    
    //}
    //protected void btnAddNew_Click(object sender, EventArgs e)
    //{

    //}
}
