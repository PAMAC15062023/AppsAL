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

public partial class Pages_Calculus_ViewOpeningBalanceByBranch : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    { 
        if (!IsPostBack)
        {
            if (Session["UserInfo"] == null)
            {
                Response.Redirect("~/Pages/InvalidRequest.aspx");
            }
            BindRequestType();
            Object SaveUSERInfo = (Object)Session["UserInfo"];
            lblbranch.Text = Convert.ToString(((UserInfo.structUSERInfo)(SaveUSERInfo)).BranchName); 
           
            Get_OpeningBalanceMonth_BranchWise();
            
        }
    }
    protected void BindRequestType()
    {
        Common common = new Common();
        DataSet ds = new DataSet();

        ds = common.GetCalOnlineTransMasterSearchCode("BRequestType", 1);
        if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            ddlRequestType.DataSource = ds;
            ddlRequestType.DataValueField = "Code_Id";
            ddlRequestType.DataTextField = "Description";
            ddlRequestType.DataBind();
            //ddlRequestType.Items.Insert(0, new ListItem("--Select--", "0"));
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
            sqlCom.CommandText = "CalOnlineTrans_GetOpeningBalanceMonthBranchWiseNew_SP";


            SqlParameter BranchID = new SqlParameter();
            BranchID.SqlDbType = SqlDbType.Int;
            BranchID.Value = Convert.ToInt32(((UserInfo.structUSERInfo)(SaveUSERInfo)).BranchId);//pBranchId;
            BranchID.ParameterName = "@BranchID";
            sqlCom.Parameters.Add(BranchID);
             
            SqlParameter YrMonth = new SqlParameter();
            YrMonth.SqlDbType = SqlDbType.VarChar;
            YrMonth.Value = "";
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

                grvTransactionInfo.DataSource = dt;
                grvTransactionInfo.DataBind(); 
            }
            else
            {
                grvTransactionInfo.DataSource = null;
                grvTransactionInfo.DataBind(); 
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
    private DataTable Get_OpeningBalacnceRequestDetails(string strYearMonth,int pBranchID)
    {

        SqlConnection sqlCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);

        sqlCon.Open();
        SqlCommand sqlCom = new SqlCommand();
        sqlCom.Connection = sqlCon;
        sqlCom.CommandType = CommandType.StoredProcedure;
        sqlCom.CommandText = "CalOnlineTrans_GetOpeningBalanceRequestDetails_SP";

        SqlParameter YearMonth = new SqlParameter();
        YearMonth.SqlDbType = SqlDbType.VarChar;
        YearMonth.Value = strYearMonth;
        YearMonth.ParameterName = "@YearMonth";
        sqlCom.Parameters.Add(YearMonth);

        SqlParameter BranchID = new SqlParameter();
        BranchID.SqlDbType = SqlDbType.Int ;
        BranchID.Value = pBranchID;
        BranchID.ParameterName = "@BranchID";
        sqlCom.Parameters.Add(BranchID);

        SqlParameter RequestType = new SqlParameter();
        RequestType.SqlDbType = SqlDbType.Int;
        RequestType.Value = ddlRequestType.SelectedItem.Value;
        RequestType.ParameterName = "@RequestType";
        sqlCom.Parameters.Add(RequestType);



        SqlDataAdapter sqlDA = new SqlDataAdapter();
        sqlDA.SelectCommand = sqlCom;
        DataTable dt = new DataTable();
        sqlDA.Fill(dt);
        sqlCon.Close();

        return dt;

    }

    protected void ddlRequestType_SelectedIndexChanged(object sender, EventArgs e)
    {
        Get_OpeningBalanceMonth_BranchWise();
    }
    protected void grv_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        Object SaveUSERInfo = (Object)Session["UserInfo"];
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
           
            GridView grvDetails = (GridView)e.Row.FindControl("grvDetails");
            grvDetails.DataSource = Get_OpeningBalacnceRequestDetails(e.Row.Cells[6].Text, Convert.ToInt32(((UserInfo.structUSERInfo)(SaveUSERInfo)).BranchId));
            grvDetails.DataBind();
        }
    }
}
