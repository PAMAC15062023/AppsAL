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

public partial class Pages_ServiceTax : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            Get_GridData();
            Register_Validation();
        }
        catch(Exception ex)
        {
            lblMessage.Visible = true;
            lblMessage.Text = ex.Message;
            lblMessage.CssClass = "ErrorMessage";
        }
    }
    private void Get_GridData()
    {
        try
        {

            //Object SaveUSERInfo = (Object)Session["UserInfo"];

            SqlConnection SqlCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);

            SqlCon.Open();
            SqlCommand SqlCmd = new SqlCommand();
            SqlCmd.Connection = SqlCon;
            SqlCmd.CommandType = CommandType.StoredProcedure;
            SqlCmd.CommandText = "Get_ServiceData";

            SqlDataAdapter sqlDA = new SqlDataAdapter();
            sqlDA.SelectCommand = SqlCmd;


            DataTable dt = new DataTable();
            sqlDA.Fill(dt);
            SqlCon.Close();

            Gv_ServiceTax.DataSource = dt;
            Gv_ServiceTax.DataBind();
        }
        catch(Exception ex)
        {
            lblMessage.Visible = true;
            lblMessage.Text = ex.Message;
            lblMessage.CssClass = "Error Message";
        }
    }

    protected void Gv_ServiceTax_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Attributes.Add("onclick", "javascript:GV_RowSelection('" + e.Row.RowIndex + "','" + e.Row.Cells[0].Text + "');");


        }

    }
    private void Register_Validation()
    {
        btnSave.Attributes.Add("onclick", "javascript:return ValidationAllField();");
       // txtTax.Attributes.Add("onblur", "javascript:return numericValidate('" +txtTax.ClientID+ "');");
    }


    protected void btnSave_Click(object sender, EventArgs e)
    {
        Insert_UpdateData();
        Get_GridData();
    }

    protected void Insert_UpdateData()
    {
        SqlConnection SqlConn = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);
       Object SaveUSERInfo = (Object)Session["UserInfo"];

        SqlConn.Open();
        SqlCommand SqlCmd = new SqlCommand();
        SqlCmd.Connection = SqlConn;
        SqlCmd.CommandType = CommandType.StoredProcedure;
        SqlCmd.CommandText = "Insert_ServiceTax";

        SqlParameter ServiceTaxID = new SqlParameter();
        ServiceTaxID.SqlDbType = SqlDbType.Int;
        ServiceTaxID.Value = hdnServiceTaxID.Value;
        ServiceTaxID.ParameterName = "@ServiceTaxID";
        SqlCmd.Parameters.Add(ServiceTaxID);

        SqlParameter ServiceTaxName = new SqlParameter();
        ServiceTaxName.SqlDbType = SqlDbType.VarChar;
        ServiceTaxName.Value = txtTaxName.Text.Trim(); 
        ServiceTaxName.ParameterName = "@ServiceTaxName ";
        SqlCmd.Parameters.Add(ServiceTaxName);

        SqlParameter ServiceTaxCode = new SqlParameter();
        ServiceTaxCode.SqlDbType = SqlDbType.VarChar;
        ServiceTaxCode.Value = txtTaxCode.Text.Trim();
        ServiceTaxCode.ParameterName = "@ServiceTaxCode";
        SqlCmd.Parameters.Add(ServiceTaxCode);

        SqlParameter ServiceTaxPercentage = new SqlParameter();
        ServiceTaxPercentage.SqlDbType = SqlDbType.Decimal;
        ServiceTaxPercentage.Value = txtTax.Text.Trim();
        ServiceTaxPercentage.ParameterName = "@ServiceTaxPercentage";
        SqlCmd.Parameters.Add(ServiceTaxPercentage);

        SqlParameter ServiceTaxEffectiveStartDate = new SqlParameter();
        ServiceTaxEffectiveStartDate.SqlDbType = SqlDbType.VarChar;
        ServiceTaxEffectiveStartDate.Value =Get_DateFormat(txtStartPeriod.Text.Trim(),"MM/dd/yyyy");
        ServiceTaxEffectiveStartDate.ParameterName = "@ServiceTaxEffectiveStartDate";
        SqlCmd.Parameters.Add(ServiceTaxEffectiveStartDate);

        SqlParameter ServiceTaxEffectiveEndDate = new SqlParameter();
        ServiceTaxEffectiveEndDate.SqlDbType = SqlDbType.VarChar;
        ServiceTaxEffectiveEndDate.Value = Get_DateFormat(txtEndPeriod.Text.Trim(), "MM/dd/yyyy"); //Convert.ToDateTime(txtEndPeriod.ToString()).ToString("dd/mm/yyyy");
        ServiceTaxEffectiveEndDate.ParameterName = "@ServiceTaxEffectiveEndDate";
        SqlCmd.Parameters.Add(ServiceTaxEffectiveEndDate);

        SqlParameter AccountHeadID = new SqlParameter();
        AccountHeadID.SqlDbType = SqlDbType.Int;
        AccountHeadID.Value = 0;
        AccountHeadID.ParameterName = "@AccountHeadID";
        SqlCmd.Parameters.Add(AccountHeadID);

        SqlParameter Remark = new SqlParameter();
        Remark.SqlDbType = SqlDbType.VarChar;
        Remark.Value = txtRemark.Text.Trim();
        Remark.ParameterName = "@Remark";
        SqlCmd.Parameters.Add(Remark);

        SqlParameter IsActive = new SqlParameter();
        IsActive.SqlDbType = SqlDbType.Bit;
        IsActive.Value = Convert.ToBoolean(ddlIsActive.SelectedItem.Value);
        IsActive.ParameterName = "@IsActive";
        SqlCmd.Parameters.Add(IsActive);

        SqlParameter UserID = new SqlParameter();
        UserID.SqlDbType = SqlDbType.VarChar;
        UserID.Value = Convert.ToString(((UserInfo.structUSERInfo)(SaveUSERInfo)).UserId); 
        UserID.ParameterName = "@UserID";
        SqlCmd.Parameters.Add(UserID);

        int SqlRow = 0;
        SqlRow = SqlCmd.ExecuteNonQuery();

        if (SqlRow > 0)
        {
            lblMessage.Text = "Update Successfully!";
            lblMessage.CssClass = "UpdateMessage";
            lblMessage.Visible = true;
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
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Pages/Menu.aspx", true);
    }
    protected void btnAddNew_Click(object sender, EventArgs e)
    {
        Clear_AllField();
    }
    protected void Clear_AllField()
    {
        hdnServiceTaxID.Value = "0";
        txtTaxName.Text = "";
        txtTaxCode.Text = "";
        txtTax.Text = "";
        txtStartPeriod.Text = "";
        txtEndPeriod.Text = "";
        txtRemark.Text = "";
        ddlIsActive.SelectedIndex = 0;
    }
}

