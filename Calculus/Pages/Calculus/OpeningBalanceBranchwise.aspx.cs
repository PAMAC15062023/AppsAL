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

public partial class Pages_Calculus_OpeningBalanceBranchwise : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["UserInfo"] == null)
            {
                Response.Redirect("~/Pages/InvalidRequest.aspx");
            }
            Get_BranchList();
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
            sqlCom.CommandText = "CalOnlineTrans_GetOpeningBalanceMonthBranchWise_SP";
              
            SqlParameter BranchID = new SqlParameter();
            BranchID.SqlDbType = SqlDbType.Int;
            BranchID.Value = Convert.ToInt32(ddlBranchList.SelectedItem.Value);//pBranchId;
            BranchID.ParameterName = "@BranchID";
            sqlCom.Parameters.Add(BranchID);

            string strYearMonth="";

            if ((ddlMonth.SelectedIndex != 0) && (ddlYear.SelectedIndex != 0))
            {

                strYearMonth = ddlYear.SelectedItem.Value.ToString() + "" + ddlMonth.SelectedItem.Value.Trim();
            }
            else if(ddlMonth.SelectedIndex != 0)
            {
                strYearMonth = ddlMonth.SelectedItem.Value.ToString(); 
            }
            else if (ddlYear.SelectedIndex != 0)
            {
                strYearMonth = ddlYear.SelectedItem.Value.ToString(); 
            }

            SqlParameter YrMonth = new SqlParameter();
            YrMonth.SqlDbType = SqlDbType.VarChar;
            YrMonth.Value = strYearMonth;
            YrMonth.ParameterName = "@YrMonth";
            sqlCom.Parameters.Add(YrMonth);

            SqlParameter RequestType = new SqlParameter();
            RequestType.SqlDbType = SqlDbType.Int;
            RequestType.Value = Convert.ToInt32(ddlRequestType.SelectedItem.Value);
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

            DataTable dt = new DataTable();
            sqlDA.Fill(dt);
            sqlCon.Close();

            if (dt.Rows.Count > 0)
            {

                gvOpeningBranchBalanace.DataSource = dt;
                gvOpeningBranchBalanace.DataBind();
                lblError.Text = "Total Records found : " + dt.Rows.Count;
            }
            else
            {
                gvOpeningBranchBalanace.DataSource = null;
                gvOpeningBranchBalanace.DataBind();
                lblError.Text = "No records found!";
            }


        }
        catch (Exception ex)
        {
            lblError.Visible = true;
            lblError.Text = ex.Message;
            lblError.CssClass = "ErrorMessage";
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
            lblError.Text = ex.Message;
            lblError.CssClass = "ErrorMessage";
            lblError.Visible = true;
            return "";
        }

    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        if (ddlBranchList.SelectedIndex != 0)
        {
            Get_OpeningBalanceMonth_BranchWise();
        }
        else
        {
            lblError.Text = "Please select branch to continue!";
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
            sqlCom.CommandText = "Get_AllBranchList";

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
            lblError.Visible = true;
            lblError.Text = ex.Message;
            lblError.CssClass = "ErrorMessage";
        }
    }
    protected void ddlRequestType_SelectedIndexChanged(object sender, EventArgs e)
    {
        Get_OpeningBalanceMonth_BranchWise();
    }
}
