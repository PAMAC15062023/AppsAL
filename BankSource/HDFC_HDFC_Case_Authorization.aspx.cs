// Decompiled with JetBrains decompiler
// Type: HDFC_HDFC_Case_Authorization
// Assembly: App_Web_case_authorization.aspx.513d3bc3, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 6AEFE125-E7A8-44B7-A9BC-CCF41F35706A
// Assembly location: C:\Users\hp\Desktop\App_Web_case_authorization.aspx.513d3bc3.dll

using myinfo;
using System;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;

public class HDFC_HDFC_Case_Authorization : Page, IRequiresSessionState
{
  protected Label lblMsg;
  protected DropDownList ddlclientname;
  protected TextBox txtDate;
  protected DropDownList ddlType;
  protected TextBox txtCustName;
  protected Button btnSearch;
  protected Label lblerror;
  protected Button btnAssign;
  protected Button BtnReject;
  protected GridView gvFEAssignmentCases;
  protected Button btnAssign1;
  protected HiddenField hdnVerificatioTypeID;
  protected RequiredFieldValidator Rfvddlclient;
  protected ValidationSummary ValidationSummary1;
  private Info obj = new Info();
  private CCommon oCmn;
  public string[] arrCaseID;
  private CCommon objConn = new CCommon();
  private SqlConnection sqlcon;
  private string strCentreID;
  private string strClientID;
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
      if (this.Session["isView"].ToString() != "1")
        this.Response.Redirect("~/Error20.aspx");
      this.strCentreID = this.Session["CentreId"].ToString();
      this.strClientID = this.ddlclientname.SelectedValue.ToString();
      this.Get_EmployeeDetails();
      this.sqlcon = new SqlConnection(this.objConn.AppConnectionString);
      this.lblMsg.Text = "";
      if (this.IsPostBack)
        return;
      this.ddlType.Items.FindByText("Residence Address").Enabled = false;
      this.ddlType.Items.FindByText("Office address").Enabled = false;
      this.ddlType.Items.FindByText("Current account CPV").Enabled = false;
      this.ddlType.Items.FindByText("--Select--").Enabled = true;
    }
    catch (Exception ex)
    {
      this.Response.Redirect("~/InvalidRequest.aspx");
    }
  }

  public void FillView()
  {
    using (OleDbConnection oleDbConnection = new OleDbConnection(this.objConn.ConnectionString))
    {
      oleDbConnection.Open();
      string str1 = this.Session["Branch_code"].ToString();
      OleDbTransaction oleDbTransaction = oleDbConnection.BeginTransaction();
      string str2 = this.Session["CentreId"].ToString();
      string str3 = this.ddlclientname.SelectedValue.ToString();
      CCommon ccommon = new CCommon();
      if (!(str3 != "") || !(str2 != ""))
        return;
      if (this.txtDate.Text != "")
      {
        OleDbParameter[] oleDbParameterArray = new OleDbParameter[4]
        {
          new OleDbParameter("@Ref_No", OleDbType.VarChar),
          null,
          null,
          null
        };
        oleDbParameterArray[0].Value = (object) str1;
        oleDbParameterArray[1] = new OleDbParameter("@CLIENT_ID", OleDbType.VarChar);
        oleDbParameterArray[1].Value = (object) str3;
        oleDbParameterArray[2] = new OleDbParameter("@CENTRE_ID", OleDbType.VarChar);
        oleDbParameterArray[2].Value = (object) str2;
        oleDbParameterArray[3] = new OleDbParameter("@CASE_REC_DATETIME", OleDbType.VarChar);
        oleDbParameterArray[3].Value = (object) ccommon.strDate(this.txtDate.Text.Trim());
        this.gvFEAssignmentCases.DataSource = (object) OleDbHelper.ExecuteDataset(oleDbTransaction, CommandType.StoredProcedure, "sp_FillView1", oleDbParameterArray);
        this.gvFEAssignmentCases.DataBind();
      }
      if (this.ddlType.SelectedValue != "")
      {
        OleDbParameter[] oleDbParameterArray = new OleDbParameter[4]
        {
          new OleDbParameter("@Ref_No", OleDbType.VarChar),
          null,
          null,
          null
        };
        oleDbParameterArray[0].Value = (object) str1;
        oleDbParameterArray[1] = new OleDbParameter("@CLIENT_ID", OleDbType.VarChar);
        oleDbParameterArray[1].Value = (object) str3;
        oleDbParameterArray[2] = new OleDbParameter("@CENTRE_ID", OleDbType.VarChar);
        oleDbParameterArray[2].Value = (object) str2;
        oleDbParameterArray[3] = new OleDbParameter("@VERIFICATION_TYPE_ID", OleDbType.VarChar);
        oleDbParameterArray[3].Value = (object) this.ddlType.SelectedValue.ToString();
        this.gvFEAssignmentCases.DataSource = (object) OleDbHelper.ExecuteDataset(oleDbTransaction, CommandType.StoredProcedure, "sp_FillView", oleDbParameterArray);
        this.gvFEAssignmentCases.DataBind();
      }
      this.hdnVerificatioTypeID.Value = this.ddlType.SelectedValue.ToString();
      oleDbConnection.Close();
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

  protected void ddlType_DataBound(object sender, EventArgs e) => this.ddlType.SelectedIndex = 0;

  protected void btnSearch_Click(object sender, EventArgs e)
  {
    try
    {
      this.FillView();
    }
    catch (Exception ex)
    {
      this.lblMsg.Text = "Error occured operation faild";
    }
  }

  protected void btnSearchFE_Click(object sender, EventArgs e) => this.SelectAll(this.gvFEAssignmentCases);

  protected void btnAssign_Click(object sender, EventArgs e)
  {
    try
    {
      foreach (GridViewRow row in this.gvFEAssignmentCases.Rows)
      {
        HiddenField control = (HiddenField) row.FindControl("hidCaseId");
        string str;
        if (((CheckBox) row.FindControl("chkCaseId")).Checked)
          str = control.Value;
        else
          str = "";
        if (str != "")
        {
          using (this.sqlcon = new SqlConnection(this.objConn.AppConnectionString))
          {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = this.sqlcon;
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.CommandText = "Sp_Authorized_KYC_cases";
            sqlCommand.CommandTimeout = 0;
            SqlParameter sqlParameter1 = new SqlParameter();
            sqlParameter1.SqlDbType = SqlDbType.VarChar;
            sqlParameter1.Value = (object) Convert.ToInt32(this.Session["UserId"]);
            sqlParameter1.ParameterName = "@Created_By";
            sqlCommand.Parameters.Add(sqlParameter1);
            SqlParameter sqlParameter2 = new SqlParameter();
            sqlParameter2.SqlDbType = SqlDbType.VarChar;
            sqlParameter2.Value = (object) str;
            sqlParameter2.ParameterName = "@Case_id";
            sqlCommand.Parameters.Add(sqlParameter2);
            this.sqlcon.Open();
            sqlCommand.ExecuteNonQuery();
            this.lblerror.Text = "Records sent for the Verification";
            this.sqlcon.Close();
          }
        }
      }
      this.FillView();
    }
    catch (Exception ex)
    {
      this.lblMsg.Text = "Error occured, FE assignment faild";
    }
  }

  private void Case_Authorization(string strCaseIds)
  {
    this.oCmn = new CCommon();
    using (OleDbConnection oleDbConnection = new OleDbConnection(this.oCmn.ConnectionString))
    {
      oleDbConnection.Open();
      OleDbTransaction oleDbTransaction = oleDbConnection.BeginTransaction();
      DataTable dataTable = new DataTable();
      try
      {
        foreach (string str in this.arrCaseID)
          str.Replace("'", "").Replace('"', ' ').ToString();
      }
      catch (Exception ex)
      {
        oleDbTransaction.Rollback();
        oleDbConnection.Close();
        throw new Exception("An error occurred ", ex);
      }
      oleDbConnection.Close();
    }
  }

  protected void gvFEAssignmentCases_DataBound(object sender, EventArgs e)
  {
    if (this.gvFEAssignmentCases.Rows.Count <= 0)
    {
      if (this.lblMsg.Text == "FE assigned successfully")
        this.lblMsg.Text = "FE assigned successfully";
      else if (this.lblMsg.Text == "Please select case to assign")
        this.lblMsg.Text = "Please select case to assign";
      else
        this.lblMsg.Text = "No record found";
    }
    else
      this.SelectAll(this.gvFEAssignmentCases);
  }

  protected void gvFEAssignmentCases_PageIndexChanging(object sender, GridViewPageEventArgs e) => this.FillView();

  protected void gvFEAssignmentCases_Sorting(object sender, GridViewSortEventArgs e) => this.FillView();

  public void SelectAll(GridView gv)
  {
    ((WebControl) this.gvFEAssignmentCases.HeaderRow.FindControl("HeaderLevelCheckBox")).Attributes["onclick"] = "ChangeAllCheckBoxStates(this.checked);";
    foreach (Control row in gv.Rows)
      this.ClientScript.RegisterArrayDeclaration("CheckBoxIDs", "'" + row.FindControl("chkCaseId").ClientID + "'");
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

  protected void BtnReject_Click(object sender, EventArgs e)
  {
    try
    {
      foreach (GridViewRow row in this.gvFEAssignmentCases.Rows)
      {
        HiddenField control = (HiddenField) row.FindControl("hidCaseId");
        string str;
        if (((CheckBox) row.FindControl("chkCaseId")).Checked)
          str = control.Value;
        else
          str = "";
        if (str != "")
        {
          this.sqlcon = new SqlConnection(this.objConn.AppConnectionString);
          SqlCommand sqlCommand = new SqlCommand();
          sqlCommand.Connection = this.sqlcon;
          sqlCommand.CommandType = CommandType.StoredProcedure;
          sqlCommand.CommandText = "Sp_Rejected_KYC_cases";
          sqlCommand.CommandTimeout = 0;
          SqlParameter sqlParameter1 = new SqlParameter();
          sqlParameter1.SqlDbType = SqlDbType.VarChar;
          sqlParameter1.Value = (object) Convert.ToInt32(this.Session["UserId"]);
          sqlParameter1.ParameterName = "@Created_By";
          sqlCommand.Parameters.Add(sqlParameter1);
          SqlParameter sqlParameter2 = new SqlParameter();
          sqlParameter2.SqlDbType = SqlDbType.VarChar;
          sqlParameter2.Value = (object) str;
          sqlParameter2.ParameterName = "@Case_id";
          sqlCommand.Parameters.Add(sqlParameter2);
          this.sqlcon.Open();
          sqlCommand.ExecuteNonQuery();
          this.lblerror.Text = "Records Rejected Successfully";
          this.sqlcon.Close();
        }
      }
      this.FillView();
    }
    catch (Exception ex)
    {
      this.lblMsg.Text = "Error : Please Inform Software Team";
    }
  }

  protected void ddlclientname_SelectedIndexChanged(object sender, EventArgs e)
  {
    if (this.strClientID == "10160")
    {
      this.ddlType.Items.FindByText("Residence Address").Enabled = true;
      this.ddlType.Items.FindByText("Office address").Enabled = true;
      this.ddlType.Items.FindByText("Current account CPV").Enabled = false;
      this.ddlType.Items.FindByText("--Select--").Enabled = false;
    }
    else if (this.strClientID == "101121" || this.strClientID == "101127" || (this.strClientID == "101137" || this.strClientID == "101160"))
    {
      this.ddlType.Items.FindByText("Residence Address").Enabled = false;
      this.ddlType.Items.FindByText("Office address").Enabled = false;
      this.ddlType.Items.FindByText("Current account CPV").Enabled = true;
      this.ddlType.Items.FindByText("--Select--").Enabled = false;
    }
    else if (this.strClientID == "101143")
    {
      this.ddlType.Items.FindByText("Residence Address").Enabled = false;
      this.ddlType.Items.FindByText("Office address").Enabled = false;
      this.ddlType.Items.FindByText("Current account CPV").Enabled = true;
      this.ddlType.Items.FindByText("--Select--").Enabled = false;
    }
    else
    {
      this.ddlType.Items.FindByText("Residence Address").Enabled = false;
      this.ddlType.Items.FindByText("Office address").Enabled = false;
      this.ddlType.Items.FindByText("Current account CPV").Enabled = false;
      this.ddlType.Items.FindByText("--Select--").Enabled = true;
    }
  }
}
