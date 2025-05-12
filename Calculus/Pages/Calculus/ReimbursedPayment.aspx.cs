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
using System.Globalization;

public partial class Pages_Calculus_ReimbursedPayment : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Get_GridOpeningBalanceData();
        }
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Pages/Menu.aspx", true);
    }
    private void Get_GridOpeningBalanceData()
    {
        try
        {
            Object SaveUSERInfo = (Object)Session["UserInfo"];

            SqlConnection SqlCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);

            SqlCon.Open();
            SqlCommand SqlCmd = new SqlCommand();
            SqlCmd.Connection = SqlCon;
            SqlCmd.CommandType = CommandType.StoredProcedure;
            SqlCmd.CommandText = "uspGetReimbursablePayments";

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
    protected void Gr_Ope_Bal_RowEditing(object sender, GridViewEditEventArgs e)
    {
        //NewEditIndex property used to determine the index of the row being edited.  
        Gr_Ope_Bal.EditIndex = e.NewEditIndex;
        Get_GridOpeningBalanceData();

    }
    protected void Gr_Ope_Bal_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        //Finding the controls from Gridview for the row which is going to update  
        Label lblTransactionDetailID = Gr_Ope_Bal.Rows[e.RowIndex].FindControl("lblTransactionDetailID") as Label;
        TextBox txtReimburstedAmount = Gr_Ope_Bal.Rows[e.RowIndex].FindControl("txtReimburstedAmount") as TextBox;
        TextBox txtReimburstedRemark = Gr_Ope_Bal.Rows[e.RowIndex].FindControl("txtReimburstedRemark") as TextBox;
        TextBox txtReimburstedOn = Gr_Ope_Bal.Rows[e.RowIndex].FindControl("txtReimburstedOn") as TextBox;
        DateTime date = DateTime.ParseExact(txtReimburstedOn.Text, "dd/MM/yyyy", null);

        SqlConnection sqlCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);
        sqlCon.Open();
        SqlCommand sqlCmd = new SqlCommand();
        sqlCmd.Connection = sqlCon;
        sqlCmd.CommandType = CommandType.StoredProcedure;
        sqlCmd.CommandText = "uspUpdateReimburstedPayment";

        SqlParameter TransactionDetailID = new SqlParameter();
        TransactionDetailID.SqlDbType = SqlDbType.VarChar;
        TransactionDetailID.Value = lblTransactionDetailID.Text;
        TransactionDetailID.ParameterName = "@TransactionDetailID";
        sqlCmd.Parameters.Add(TransactionDetailID);

        SqlParameter ReimburstedAmount = new SqlParameter();
        ReimburstedAmount.SqlDbType = SqlDbType.VarChar;
        ReimburstedAmount.Value = txtReimburstedAmount.Text;
        ReimburstedAmount.ParameterName = "@ReimburstedAmount";
        sqlCmd.Parameters.Add(ReimburstedAmount);

        SqlParameter ReimburstedRemark = new SqlParameter();
        ReimburstedRemark.SqlDbType = SqlDbType.VarChar;
        ReimburstedRemark.Value = txtReimburstedRemark.Text;
        ReimburstedRemark.ParameterName = "@ReimburstedRemark";
        sqlCmd.Parameters.Add(ReimburstedRemark);

        SqlParameter ReimburstedOn = new SqlParameter();
        ReimburstedOn.SqlDbType = SqlDbType.DateTime;
        ReimburstedOn.Value = date;
        ReimburstedOn.ParameterName = "@ReimburstedOn";
        sqlCmd.Parameters.Add(ReimburstedOn);

        int SqlRow = 0;
        SqlRow = sqlCmd.ExecuteNonQuery();

        if (SqlRow > 0)
        {

            lblMessage.Text = "Update Successfully!";
            lblMessage.CssClass = "UpdateMessage";
            lblMessage.Visible = true;
        }
        else
        {

            lblMessage.Text = "Something went wronge!";
            lblMessage.CssClass = "ErrorMessage";
            lblMessage.Visible = true;
        }
        sqlCon.Close();
        //Setting the EditIndex property to -1 to cancel the Edit mode in Gridview  
        Gr_Ope_Bal.EditIndex = -1;
        //Call ShowData method for displaying updated data  
        Get_GridOpeningBalanceData();
    }
    protected void Gr_Ope_Bal_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        //Setting the EditIndex property to -1 to cancel the Edit mode in Gridview  
        Gr_Ope_Bal.EditIndex = -1;
        Get_GridOpeningBalanceData();
    }
}