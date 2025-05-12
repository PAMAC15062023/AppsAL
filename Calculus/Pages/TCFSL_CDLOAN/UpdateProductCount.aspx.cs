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

public partial class Pages_TCFSL_CDLOAN_UpdateProductCount : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Object SaveUSERInfo = (Object)Session["UserInfo"];
        SqlConnection sqlCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);

        if (Session["UserInfo"] == null)
        {
            Response.Redirect("~/Pages/Logout.aspx");

            Response.AppendHeader("Refresh", "2");
        }
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        txtCaseNumber.Text = "";
        txtProductCount.Text = "";

        Response.Redirect("~/Pages/Menu.aspx", true);
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        if (txtCaseNumber.Text == "" || txtProductCount.Text == "")
        {
            lblMessage.Text = "";
            lblMessage.Text = "Please enter Case Number and CORRECT Product Count";
            lblMessage.Visible = true;
        }
        else
        {
            Update_Product();
        }
    }
    private void Update_Product()
    {
        Object SaveUSERInfo = (Object)Session["UserInfo"];

        SqlConnection sqlCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);
        try
        {
            SqlCommand sqlCom = new SqlCommand();
            sqlCom.Connection = sqlCon;
            sqlCom.CommandType = CommandType.StoredProcedure;
            sqlCom.CommandText = "TCFSL_USP_Update_Product_Count_SP";

            SqlDataAdapter sqlDA = new SqlDataAdapter();
            sqlDA.SelectCommand = sqlCom;

            SqlParameter intType = new SqlParameter();
            intType.SqlDbType = SqlDbType.VarChar;
            intType.Value = 1;
            intType.ParameterName = "@intType";
            sqlCom.Parameters.Add(intType);

            SqlParameter CaseNumber = new SqlParameter();
            CaseNumber.SqlDbType = SqlDbType.VarChar;
            CaseNumber.Value = txtCaseNumber.Text.Trim();
            CaseNumber.ParameterName = "@CaseNumber";
            sqlCom.Parameters.Add(CaseNumber);

            SqlParameter ProductCount = new SqlParameter();
            ProductCount.SqlDbType = SqlDbType.VarChar;
            ProductCount.Value = txtProductCount.Text.Trim();
            ProductCount.ParameterName = "@ProductCount";
            sqlCom.Parameters.Add(ProductCount);

            SqlParameter UserID = new SqlParameter();
            UserID.SqlDbType = SqlDbType.VarChar;
            UserID.Value = Convert.ToString(((UserInfo.structUSERInfo)(SaveUSERInfo)).UserId);
            UserID.ParameterName = "@UserID";
            sqlCom.Parameters.Add(UserID);

            sqlCon.Open();
            int SqlRow = 0;
            SqlRow = sqlCom.ExecuteNonQuery();
            sqlCon.Close();
            if (SqlRow > 0)
            {
                lblMessage.Text = "";
                lblMessage.Text = "Data Successfully Updated........!!";
                lblMessage.Visible = true;
                txtCaseNumber.Text = "";
                txtProductCount.Text = "";
            }
            else
            {
                lblMessage.Text = "";
                lblMessage.Text = "Something went wrong........!!";
                lblMessage.Visible = true;
                return;
            }
        }

        catch (Exception ex)
        {
            lblMessage.Text = "Error :" + ex.Message;
        }
        finally
        {
            sqlCon.Close();
            sqlCon.Dispose();
        }
    }

    protected void txtSearch_Click(object sender, EventArgs e)
    {
        getExistingProductCount();
    }

    protected void getExistingProductCount()
    {
        SqlConnection sqlcon = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);
        try
        {
            if (sqlcon.State == ConnectionState.Closed)
            {
                sqlcon.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = sqlcon;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "TCFSL_USP_Update_Product_Count_SP";
                cmd.CommandTimeout = 0;

                SqlParameter intType = new SqlParameter();
                intType.SqlDbType = SqlDbType.VarChar;
                intType.Value = 2;
                intType.ParameterName = "@intType";
                cmd.Parameters.Add(intType);

                SqlParameter CaseNumber = new SqlParameter();
                CaseNumber.SqlDbType = SqlDbType.VarChar;
                CaseNumber.Value = txtCaseNumber.Text.Trim();
                CaseNumber.ParameterName = "@CaseNumber";
                cmd.Parameters.Add(CaseNumber);

                SqlDataAdapter sda = new SqlDataAdapter();
                sda.SelectCommand = cmd;

                DataTable dt = new DataTable();
                sda.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    lbl1st.Text = dt.Rows[0]["QCSCREEN_PRODUCT"].ToString();
                    lbl2nd.Text = dt.Rows[0]["QCRESCREEN_PRODUCT"].ToString();
                    lbl3rd.Text = dt.Rows[0]["QCRESCREEN_PRODUCT1"].ToString();
                    lbl4th.Text = dt.Rows[0]["QCRESCREEN_PRODUCT11"].ToString();
                    lbl5th.Text = dt.Rows[0]["QCRESCREEN_PRODUCT12"].ToString();
                    lbl6th.Text = dt.Rows[0]["QCRESCREEN_PRODUCT13"].ToString();
                }
                else
                {
                    lbl1st.Text = "NA";
                    lbl2nd.Text = "NA";
                    lbl3rd.Text = "NA";
                    lbl4th.Text = "NA";
                    lbl5th.Text = "NA";
                    lbl6th.Text = "NA";
                }
            }
        }
        catch (SqlException sqlex)
        {
            lblMessage.Text = sqlex.Message.ToString();
        }
        catch (SystemException ex)
        {
            lblMessage.Text = ex.Message.ToString();
        }
        finally
        {
            if (sqlcon.State == ConnectionState.Open)
            {
                sqlcon.Close();
            }
        }
    }
}