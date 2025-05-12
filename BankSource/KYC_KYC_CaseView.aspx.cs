// Decompiled with JetBrains decompiler
// Type: KYC_KYC_CaseView
// Assembly: App_Web_kyc_caseview.aspx.513d3bc3, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: BBE9FA8F-4CDE-481B-A445-77A76F9FB3B9
// Assembly location: D:\RK\RAMKI CONSULTANCY\PAMAC\Technology support\Projects\HDFC Bank\Decompiled source\App_Web_kyc_caseview.aspx.513d3bc3.dll

using myinfo;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;

public class KYC_KYC_CaseView : Page, IRequiresSessionState
{
  protected DropDownList ddlclientname;
  protected TextBox txtFromDate;
  protected TextBox txtToDate;
  protected Button Button1;
  protected Label lblMsg;
  protected GridView gvKYC;
  protected SqlDataSource sdsKYC;
  protected HiddenField hdnclientname;
  protected RequiredFieldValidator Rfvddlclient;
  protected ValidationSummary ValidationSummary1;
  protected ValidationSummary vsValidate;
  private Info obj = new Info();
  private CKYC objKYC = new CKYC();
  private CCommon objConn = new CCommon();
  private SqlConnection sqlcon;
  private string OpID;

  protected DefaultProfile Profile => (DefaultProfile) this.Context.Profile;

  protected HttpApplication ApplicationInstance => this.Context.ApplicationInstance;

  private void Page_Init(object sender, EventArgs e)
  {
    if (this.Session.Count != 0)
      return;
    this.Session.Abandon();
    this.Response.Redirect("~/InvalidRequest.aspx");
  }

  protected void Page_Load(object sender, EventArgs e)
  {
    this.Session["userid"].ToString();
    this.Call();
    this.Sp_Login_Details_Check();
    this.token();
    try
    {
      this.Get_EmployeeDetails();
      CCommon ccommon = new CCommon();
      this.sqlcon = new SqlConnection(ccommon.AppConnectionString);
      this.sdsKYC.ConnectionString = ccommon.ConnectionString;
      if (this.Session["isView"].ToString() != "1")
        this.Response.Redirect("Error20.aspx");
      this.lblMsg.Visible = false;
      if (this.Context.Request.QueryString["Msg"] != null && this.Context.Request.QueryString["Msg"] != "")
      {
        this.lblMsg.Visible = true;
        this.lblMsg.Text = this.Request.QueryString["Msg"].ToString();
      }
      else
        this.lblMsg.Text = "";
    }
    catch (Exception ex)
    {
      this.Response.Redirect("~/InvalidRequest.aspx");
    }
  }

  public void Call()
  {
    string str = this.Session["userid"].ToString();
    DataSet dataSet1 = new DataSet();
    DataSet dataSet2 = this.obj.NewMethod(str);
    if (!this.IsPostBack && dataSet2.Tables[1].Rows.Count > 0)
    {
      this.ddlclientname.DataTextField = "client_name";
      this.ddlclientname.DataValueField = "client_id";
      this.ddlclientname.DataSource = (object) dataSet2.Tables[1];
      this.ddlclientname.DataBind();
      this.ddlclientname.Items.Insert(0, new ListItem("--select--", "0"));
      this.ddlclientname.SelectedIndex = 0;
    }
    if (dataSet2.Tables[0].Rows.Count > 0)
      this.Session["Old"] = (object) dataSet2.Tables[0].Rows[0]["log_det_id"].ToString();
    if (!(this.Session["LogId"].ToString() != this.Session["Old"].ToString()))
      return;
    this.Response.Redirect("~/OldSession.aspx");
  }

  public void Sp_Login_Details_Check()
  {
    string str1 = this.Session["ProductId"].ToString();
    string str2 = this.Session["RoleId"].ToString();
    this.OpID = this.Context.Request.QueryString["OperationId"];
    if (this.Context.Request.QueryString["OperationId"] == null)
      this.OpID = "0";
    DataSet dataSet = new DataSet();
    if (this.obj.Sp_Login_Details_Check(str1, str2, this.OpID).Tables[0].Rows.Count > 0)
      return;
    this.Response.Redirect("~/Error20.aspx");
  }

  public void token()
  {
    DataSet dataSet = new DataSet();
    DataSet tokenUpdate = this.obj.Get_TokenUpdate();
    if (this.Session["Token"].ToString() == tokenUpdate.Tables[0].Rows[0]["Token"].ToString())
    {
      this.Session.Remove("Token");
      int num = new Random().Next();
      this.obj.UpdateTokenDetail(num);
      this.Session["Token"] = (object) num;
    }
    else
      this.Response.Redirect("~/Error20.aspx");
  }

  protected void gvKYC_RowCommand(object sender, GridViewCommandEventArgs e)
  {
    DataSet dataSet = new DataSet();
    string str = e.CommandArgument.ToString();
    if (e.CommandName == "Edit" && str != "")
      this.Response.Redirect("~/HDFCBANK/HDFCBANK/KYC_CaseEntry.aspx?CaseID=" + str);
    if (!(e.CommandName == "DeleteKYC") || this.objKYC.DeleteKYCCaseEntry(str) != 1)
      return;
    this.lblMsg.Visible = true;
    this.lblMsg.Text = "Record deleted successfully.";
  }

  protected void gvKYC_RowDataBound(object sender, GridViewRowEventArgs e)
  {
    if (e.Row.RowType != DataControlRowType.DataRow)
      return;
    ((WebControl) e.Row.FindControl("lnkDeleteKYC")).Attributes.Add("onclick", "javascript:return confirm('Are you sure you want to delete this record')");
  }

  public string strDate(string strInDate)
  {
    string str1 = strInDate.Substring(0, 2);
    string str2 = strInDate.Substring(3, 2);
    string str3 = strInDate.Substring(6, 4);
    return Convert.ToDateTime(str2 + "/" + str1 + "/" + str3).ToString("dd-MMM-yyyy");
  }

  protected void Button1_Click(object sender, EventArgs e)
  {
    if (this.txtFromDate.Text != "")
    {
      if (this.txtToDate.Text != "")
      {
        this.lblMsg.Text = "";
        this.lblMsg.Visible = false;
        SqlCommand sqlCommand = new SqlCommand();
        sqlCommand.Connection = this.sqlcon;
        sqlCommand.CommandType = CommandType.StoredProcedure;
        sqlCommand.CommandText = "Sp_HDFC_KYC";
        sqlCommand.CommandTimeout = 0;
        SqlParameter sqlParameter1 = new SqlParameter();
        sqlParameter1.SqlDbType = SqlDbType.VarChar;
        sqlParameter1.Value = (object) this.Session["CentreID"].ToString();
        sqlParameter1.ParameterName = "@CentreID";
        sqlCommand.Parameters.Add(sqlParameter1);
        SqlParameter sqlParameter2 = new SqlParameter();
        sqlParameter2.SqlDbType = SqlDbType.VarChar;
        sqlParameter2.Value = (object) this.ddlclientname.SelectedValue.ToString();
        sqlParameter2.ParameterName = "@Client_id";
        sqlCommand.Parameters.Add(sqlParameter2);
        SqlParameter sqlParameter3 = new SqlParameter();
        sqlParameter3.SqlDbType = SqlDbType.VarChar;
        sqlParameter3.Value = this.Session["Branch_Code"];
        sqlParameter3.ParameterName = "@RefNo";
        sqlCommand.Parameters.Add(sqlParameter3);
        SqlParameter sqlParameter4 = new SqlParameter();
        sqlParameter4.SqlDbType = SqlDbType.VarChar;
        sqlParameter4.Value = (object) this.Session["UserID"].ToString();
        sqlParameter4.ParameterName = "@Add_By";
        sqlCommand.Parameters.Add(sqlParameter4);
        SqlParameter sqlParameter5 = new SqlParameter();
        sqlParameter5.SqlDbType = SqlDbType.DateTime;
        sqlParameter5.Value = (object) this.strDate(this.txtFromDate.Text.Trim());
        sqlParameter5.ParameterName = "@FromDate";
        sqlCommand.Parameters.Add(sqlParameter5);
        SqlParameter sqlParameter6 = new SqlParameter();
        sqlParameter6.SqlDbType = SqlDbType.DateTime;
        sqlParameter6.Value = (object) this.strDate(this.txtToDate.Text.Trim());
        sqlParameter6.ParameterName = "@Todate";
        sqlCommand.Parameters.Add(sqlParameter6);
        this.sqlcon.Open();
        SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
        sqlDataAdapter.SelectCommand = sqlCommand;
        DataTable dataTable = new DataTable();
        sqlDataAdapter.Fill(dataTable);
        this.sqlcon.Close();
        if (dataTable.Rows.Count > 0)
        {
          this.lblMsg.Text = "";
          this.lblMsg.Text = "Total Count Is :" + (object) dataTable.Rows.Count;
          this.gvKYC.DataSourceID = (string) null;
          this.gvKYC.DataBind();
          this.gvKYC.DataSource = (object) dataTable;
          this.gvKYC.DataBind();
        }
        else
        {
          this.gvKYC.DataSourceID = (string) null;
          this.gvKYC.DataBind();
        }
      }
      else
        this.lblMsg.Text = "Please Entre From Date";
    }
    this.lblMsg.Text = "Please Entre To Date";
  }

  private void Get_EmployeeDetails()
  {
    SqlConnection sqlConnection = new SqlConnection(new CCommon().AppConnectionString);
    SqlCommand sqlCommand = new SqlCommand();
    sqlCommand.Connection = sqlConnection;
    sqlCommand.CommandType = CommandType.StoredProcedure;
    sqlCommand.CommandText = "Get_EmployeeDetails_HDFC";
    sqlCommand.CommandTimeout = 0;
    SqlParameter sqlParameter = new SqlParameter();
    sqlParameter.SqlDbType = SqlDbType.VarChar;
    sqlParameter.Value = (object) this.Session["userid"].ToString();
    sqlParameter.ParameterName = "@Emp_id";
    sqlCommand.Parameters.Add(sqlParameter);
    sqlConnection.Open();
    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
    sqlDataAdapter.SelectCommand = sqlCommand;
    DataSet dataSet = new DataSet();
    sqlDataAdapter.Fill(dataSet);
    sqlConnection.Close();
    if (dataSet.Tables[0].Rows.Count <= 0)
      return;
    this.Session["Branch_Code"] = (object) dataSet.Tables[0].Rows[0]["Branch_code"].ToString();
  }

  protected void ddlclientname_SelectedIndexChanged(object sender, EventArgs e)
  {
    ((CCPVDetail) this.objKYC).CentreId = this.Session["CentreID"].ToString();
    ((CCPVDetail) this.objKYC).ClientId = this.ddlclientname.SelectedValue.ToString();
    this.hdnclientname.Value = this.ddlclientname.SelectedValue.ToString();
    this.sdsKYC.ConnectionString = this.objConn.ConnectionString;
  }
}
