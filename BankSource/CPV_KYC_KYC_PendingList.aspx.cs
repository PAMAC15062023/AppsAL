// Decompiled with JetBrains decompiler
// Type: CPV_KYC_KYC_PendingList
// Assembly: App_Web_kyc_pendinglist.aspx.513d3bc3, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 44ACA1D6-A786-4F28-9661-9A2A94F510E3
// Assembly location: D:\RK\RAMKI CONSULTANCY\PAMAC\Technology support\Projects\HDFC Bank\Decompiled source\App_Web_kyc_pendinglist.aspx.513d3bc3.dll

using myinfo;
using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;

public class CPV_KYC_KYC_PendingList : Page, IRequiresSessionState
{
  protected Label lblMsg;
  protected DropDownList ddlclientname;
  protected TextBox txtFromDate;
  protected TextBox txtToDate;
  protected Button Button1;
  protected GridView grdvpdrp;
  protected RequiredFieldValidator Rfvddlclient;
  protected ValidationSummary vsValidate;
  protected RequiredFieldValidator rfvFromDate;
  protected RequiredFieldValidator rfvToDate;
  private Info obj = new Info();
  private CCommon con = new CCommon();
  private string OpID;

  protected DefaultProfile Profile => (DefaultProfile) this.Context.Profile;

  protected HttpApplication ApplicationInstance => this.Context.ApplicationInstance;

  private void Page_Init(object sender, EventArgs e)
  {
    this.ViewStateUserKey = this.Session.SessionID;
    this.Session.Timeout = 240;
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
      if (this.Session["isView"].ToString() != "1")
        this.Response.Redirect("Error20.aspx");
      this.lblMsg.Text = "";
      this.txtFromDate.Focus();
      this.Get_EmployeeDetails();
    }
    catch (Exception ex)
    {
      this.Response.Redirect("~/InvalidRequest.aspx");
    }
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

  public override void VerifyRenderingInServerForm(Control control)
  {
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

  public string strDate(string strInDate)
  {
    string str1 = strInDate.Substring(0, 2);
    string str2 = strInDate.Substring(3, 2);
    string str3 = strInDate.Substring(6, 4);
    return Convert.ToDateTime(str2 + "/" + str1 + "/" + str3).ToString("dd-MMM-yyyy");
  }

  private void PendingExcelReport()
  {
    try
    {
      using (SqlConnection sqlConnection = new SqlConnection(new CCommon().AppConnectionString))
      {
        SqlCommand sqlCommand = new SqlCommand();
        sqlCommand.Connection = sqlConnection;
        sqlCommand.CommandType = CommandType.StoredProcedure;
        sqlCommand.CommandText = "Sp_Pendinglist_Verification_KYC_12_hdfc";
        sqlCommand.CommandTimeout = 0;
        sqlCommand.CommandTimeout = 0;
        SqlParameter sqlParameter1 = new SqlParameter();
        sqlParameter1.SqlDbType = SqlDbType.DateTime;
        sqlParameter1.Value = (object) this.strDate(this.txtFromDate.Text.Trim());
        sqlParameter1.ParameterName = "@FromDate";
        sqlCommand.Parameters.Add(sqlParameter1);
        SqlParameter sqlParameter2 = new SqlParameter();
        sqlParameter2.SqlDbType = SqlDbType.DateTime;
        sqlParameter2.Value = (object) this.strDate(this.txtToDate.Text.Trim());
        sqlParameter2.ParameterName = "@Todate";
        sqlCommand.Parameters.Add(sqlParameter2);
        SqlParameter sqlParameter3 = new SqlParameter();
        sqlParameter3.SqlDbType = SqlDbType.VarChar;
        sqlParameter3.Value = (object) this.ddlclientname.SelectedValue.ToString();
        sqlParameter3.ParameterName = "@Client_ID";
        sqlCommand.Parameters.Add(sqlParameter3);
        SqlParameter sqlParameter4 = new SqlParameter();
        sqlParameter4.SqlDbType = SqlDbType.VarChar;
        sqlParameter4.Value = (object) this.Session["CentreId"].ToString();
        sqlParameter4.ParameterName = "@Centre_id";
        sqlCommand.Parameters.Add(sqlParameter4);
        SqlParameter sqlParameter5 = new SqlParameter();
        sqlParameter5.SqlDbType = SqlDbType.VarChar;
        sqlParameter5.ParameterName = "@Branch_code";
        sqlParameter5.Value = (object) this.Session["Branch_code"].ToString();
        sqlCommand.Parameters.Add(sqlParameter5);
        sqlConnection.Open();
        SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
        sqlDataAdapter.SelectCommand = sqlCommand;
        DataTable dataTable = new DataTable();
        sqlDataAdapter.Fill(dataTable);
        sqlConnection.Close();
        this.grdvpdrp.DataSource = (object) dataTable;
        this.grdvpdrp.DataBind();
        string str = "attachment; filename=Pending Report.xls";
        this.Response.ClearContent();
        this.Response.ClearHeaders();
        this.Response.Clear();
        this.Response.AddHeader("content-disposition", str);
        this.Response.ContentType = "application/ms-excel";
        StringWriter stringWriter = new StringWriter();
        this.grdvpdrp.RenderControl(new HtmlTextWriter((TextWriter) stringWriter));
        this.grdvpdrp.GridLines = GridLines.Both;
        this.Response.Write(stringWriter.ToString());
        this.Response.End();
      }
    }
    catch (Exception ex)
    {
      this.lblMsg.Text = ex.Message;
    }
  }

  protected void Button1_Click(object sender, EventArgs e) => this.PendingExcelReport();
}
