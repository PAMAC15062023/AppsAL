// Decompiled with JetBrains decompiler
// Type: CPV_KYC_KYC_EXPORT_ALL
// Assembly: App_Web_kyc_export_all.aspx.513d3bc3, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 52039DE3-48E6-4742-BAE8-CC1A32DEE7BF
// Assembly location: D:\RK\RAMKI CONSULTANCY\PAMAC\Technology support\Projects\HDFC Bank\Decompiled source\App_Web_kyc_export_all.aspx.513d3bc3.dll

using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using myinfo;
using System;
using System.Collections;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.IO;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public class CPV_KYC_KYC_EXPORT_ALL : Page, IRequiresSessionState
{
  protected DropDownList ddlclientname;
  protected TextBox txtFromDate;
  protected TextBox txtToDate;
  protected Button btnSearch;
  protected Label lblreport;
  protected DropDownList ddlReports;
  protected Button btnCPVintdetl;
  protected Button Button1;
  protected RadioButton rdoDateTime;
  protected TextBox TextBox1;
  protected TextBox TextBox2;
  protected DropDownList DropDownList1;
  protected RequiredFieldValidator Rfvddlclient;
  protected ValidationSummary vsValidate;
  protected RequiredFieldValidator rfvFromDate;
  protected RequiredFieldValidator rfvToDate;
  protected Label lblCaseCount;
  protected Label lblMsg;
  protected HyperLink hplDownload;
  protected TextBox txtDate;
  protected TextBox txtTime;
  protected DropDownList ddlTimeType;
  protected DropDownList ddlSelectFormat1;
  protected Button btnExport1;
  protected GridView gvOutput;
  protected GridView grdvwFGB;
  protected GridView grv_annexure;
  protected DropDownList ddlSelectFormat;
  protected Button btnExport;
  protected HiddenField hdFromDate;
  protected HiddenField hdnDestPath;
  protected HiddenField hdToDate;
  protected SqlDataSource sdsSelectFormat;
  protected SqlDataSource sdsSelectFormat1;
  protected SqlDataSource SqlDataSourceDate;
  protected HiddenField hdnAnnexure;
  protected HiddenField HdnBranchCode;
  protected HtmlTable tblCaseCount;
  protected CustomValidator CustomValidator_Export;
  protected ValidationSummary ValidationSummary2;
  protected HtmlTable tblViewDetail;
  private Info obj = new Info();
  private CCommon objConn = new CCommon();
  private SqlConnection sqlcon;
  private CCommon objCmn = new CCommon();
  public ArrayList list = new ArrayList();
  public int listcount;
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
      CCommon ccommon = new CCommon();
      this.sqlcon = new SqlConnection(ccommon.AppConnectionString);
      this.sdsSelectFormat.ConnectionString = ccommon.ConnectionString;
      this.sdsSelectFormat1.ConnectionString = ccommon.ConnectionString;
      this.SqlDataSourceDate.ConnectionString = ccommon.ConnectionString;
      if (this.Session["isView"].ToString() != "1")
        this.Response.Redirect("Error20.aspx");
      this.txtFromDate.Focus();
      this.lblMsg.Text = "";
      this.Session["CentreId"].ToString();
      string str = this.Session["UserID"].ToString();
      if (str == "101103982" || str == "101103522" || (str == "101103586" || str == "101547") || (str == "101103454" || str == "101103982" || (str == "101103872" || str == "101103912")) || str == "101103907")
      {
        this.lblreport.Visible = true;
        this.ddlReports.Visible = true;
        this.btnCPVintdetl.Visible = true;
      }
      else
      {
        this.lblreport.Visible = false;
        this.ddlReports.Visible = false;
        this.btnCPVintdetl.Visible = false;
      }
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
      this.ddlclientname.Items.Insert(0, "--select--");
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

  protected void grv_annexure_RowCommand1(object sender, GridViewCommandEventArgs e)
  {
    for (int index = 0; index <= this.grv_annexure.Rows.Count - 1; ++index)
    {
      string str1 = e.CommandArgument.ToString();
      this.hdnAnnexure.Value = this.grv_annexure.Rows[index].Cells[1].Text.Trim();
      if (e.CommandName == "download" && str1 == this.hdnAnnexure.Value)
      {
        string filename = this.Server.MapPath("../../ExportToUTI/HDFC Bank/") + this.grv_annexure.Rows[index].Cells[7].Text.Trim();
        string str2 = "attachment; filename=" + this.grv_annexure.Rows[index].Cells[7].Text.Trim();
        this.Response.ClearContent();
        this.Response.ClearHeaders();
        this.Response.Clear();
        this.Context.Response.AddHeader("content-disposition", str2);
        this.Context.Response.ContentType = "application/PDF";
        this.Response.WriteFile(filename);
        this.Response.End();
      }
    }
  }

  protected void btnSearch_Click(object sender, EventArgs e)
  {
    try
    {
      string str1 = this.Session["CentreId"].ToString();
      string str2 = this.ddlclientname.SelectedValue.ToString();
      this.HdnBranchCode.Value = (string) null;
      this.Get_EmployeeDetails();
      string str3 = "";
      string str4 = "";
      if (this.txtToDate.Text.Trim() != "")
        str3 = Convert.ToDateTime(this.objCmn.strDate(this.txtToDate.Text.Trim())).AddDays(1.0).ToString("dd-MMM-yyyy");
      if (this.txtFromDate.Text.Trim() != "")
        str4 = this.objCmn.strDate(this.txtFromDate.Text.Trim());
      this.hdFromDate.Value = str4;
      this.hdToDate.Value = str3;
      if (!(str1 != "") || !(str2 != ""))
        return;
      OleDbParameter[] oleDbParameterArray = new OleDbParameter[4]
      {
        new OleDbParameter("@CENTRE_ID", OleDbType.VarChar),
        null,
        null,
        null
      };
      oleDbParameterArray[0].Value = (object) str1;
      oleDbParameterArray[1] = new OleDbParameter("@CLIENT_ID", OleDbType.VarChar, 10);
      oleDbParameterArray[1].Value = (object) str2;
      oleDbParameterArray[2] = new OleDbParameter("@SEND_DATETIME_FROMDATE", OleDbType.VarChar);
      oleDbParameterArray[2].Value = (object) this.objCmn.strDate(this.txtFromDate.Text.Trim());
      oleDbParameterArray[3] = new OleDbParameter("@SEND_DATETIME_TODATE", OleDbType.VarChar);
      oleDbParameterArray[3].Value = (object) this.objCmn.strDate(this.txtToDate.Text.Trim());
      OleDbHelper.ExecuteReader(this.objCmn.ConnectionString, CommandType.StoredProcedure, "sp_btnSearch", oleDbParameterArray).Close();
      if (str2 == "10160")
      {
        this.gvOutput.DataBind();
        if (this.gvOutput.Rows.Count > 0)
        {
          this.tblCaseCount.Visible = true;
          this.lblMsg.Visible = false;
        }
        else
        {
          this.tblCaseCount.Visible = false;
          this.lblCaseCount.Text = "";
          this.lblMsg.Visible = true;
          this.lblMsg.Text = "Record not found.";
        }
      }
      else if (str2 == "101121" || str2 == "101127" || (str2 == "101137" || str2 == "101160"))
      {
        this.gvOutput.DataBind();
        if (this.gvOutput.Rows.Count > 0)
        {
          this.tblCaseCount.Visible = true;
          this.lblMsg.Visible = false;
        }
        else
        {
          this.tblCaseCount.Visible = false;
          this.lblCaseCount.Text = "";
          this.lblMsg.Visible = true;
          this.lblMsg.Text = "Record not found.";
        }
      }
      else if (str2 == "101143")
      {
        this.gvOutput.DataBind();
        if (this.gvOutput.Rows.Count > 0)
        {
          this.tblCaseCount.Visible = true;
          this.lblMsg.Visible = false;
        }
        else
        {
          this.tblCaseCount.Visible = false;
          this.lblCaseCount.Text = "";
          this.lblMsg.Visible = true;
          this.lblMsg.Text = "Record not found.";
        }
      }
      else
      {
        this.gvOutput.Visible = false;
        this.tblCaseCount.Visible = false;
        this.lblCaseCount.Text = "";
        this.lblMsg.Visible = true;
        this.lblMsg.Text = "Record not found.";
      }
    }
    catch (Exception ex)
    {
      this.lblMsg.Visible = true;
      this.lblMsg.Text = "Error while retreiving data: " + ex.Message;
    }
  }

  public void GenerateHdfcLiabCurrFormat(string[] arrCaseId)
  {
    try
    {
      if (arrCaseId.Length <= 0)
        return;
      DataSet dataSet = new DataSet();
      CReport creport = new CReport();
      DataTable table1 = new DataTable();
      DataTable table2 = new DataTable();
      DataTable table3 = new DataTable();
      string str1 = this.Server.MapPath("../../ExportToUTI/HDFC Bank/");
      DateTime.Now.ToString("ddMMyyyyhhmmss");
      string str2 = DateTime.Now.ToString("dd-MMM-yyyy");
      for (int index = 0; index < arrCaseId.Length; ++index)
      {
        dataSet.Tables.Clear();
        dataSet.Clear();
        string str3 = "";
        string str4 = "";
        OleDbDataReader refNoByCaseIdKyc = creport.GetRefNoByCaseIdKyc(arrCaseId[index].ToString());
        if (refNoByCaseIdKyc.Read())
          str3 = refNoByCaseIdKyc["Ref_No"].ToString();
        string str5 = refNoByCaseIdKyc["Case_id"].ToString();
        OleDbDataReader appnameBycaseIdkyc = creport.GetAppnameBycaseIDKYC(arrCaseId[index].ToString());
        if (appnameBycaseIdkyc.Read())
          str4 = appnameBycaseIdkyc["App_Name"].ToString();
        string str6 = appnameBycaseIdkyc["off_name"].ToString();
        refNoByCaseIdKyc.Close();
        table1 = creport.GetCaseIdforReportKyc(arrCaseId[index].ToString());
        table2 = creport.GetBusinessVerificationDtlKyc_Curr(arrCaseId[index].ToString());
        dataSet.Tables.Add(table1);
        dataSet.Tables[0].TableName = "Main";
        dataSet.Tables.Add(table2);
        dataSet.Tables[1].TableName = "Kyc_Hdfc_Buss";
        dataSet.Tables.Add(table3);
        dataSet.Tables[2].TableName = "Kyc_Hdfc_Resi";
        CrystalReportDocument crystalReportDocument = new CrystalReportDocument();
        ((ReportDocument) crystalReportDocument).Load(this.Server.MapPath("KYC_HdfcCurr_Export.rpt"));
        ((ReportDocument) crystalReportDocument).SetDataSource(dataSet);
        this.Session["Path"] = (object) this.Server.MapPath("KYC_HdfcCurr_Export.rpt");
        ((ReportDocument) crystalReportDocument).ExportToDisk((ExportFormatType) 5, str1 + str3 + "_" + str4 + "_" + str6 + "_" + str2 + ".pdf");
        this.list.Add((object) (str1 + str3 + "_" + str4 + "_" + str6 + "_" + str2 + ".pdf"));
        string str7 = str3 + "_" + str4 + "_" + str6 + "_" + str2 + ".pdf";
        SqlCommand sqlCommand = new SqlCommand();
        sqlCommand.Connection = this.sqlcon;
        sqlCommand.CommandType = CommandType.StoredProcedure;
        sqlCommand.CommandText = "Sp_Update_Pdf_name";
        sqlCommand.CommandTimeout = 0;
        SqlParameter sqlParameter1 = new SqlParameter();
        sqlParameter1.SqlDbType = SqlDbType.VarChar;
        sqlParameter1.Value = (object) str7;
        sqlParameter1.ParameterName = "@PDF";
        sqlCommand.Parameters.Add(sqlParameter1);
        SqlParameter sqlParameter2 = new SqlParameter();
        sqlParameter2.SqlDbType = SqlDbType.VarChar;
        sqlParameter2.Value = (object) str5;
        sqlParameter2.ParameterName = "@Case_id";
        sqlCommand.Parameters.Add(sqlParameter2);
        this.sqlcon.Open();
        sqlCommand.ExecuteNonQuery();
        this.sqlcon.Close();
        crystalReportDocument.Dispose();
        GC.Collect();
      }
      this.listcount = this.list.Count;
      table1.Clear();
      table2.Clear();
      table3.Clear();
      table1.Dispose();
      table2.Dispose();
      table3.Dispose();
      dataSet.Clear();
      dataSet.Dispose();
    }
    catch (Exception ex)
    {
      this.lblMsg.Visible = true;
      this.lblMsg.Text = ex.Message;
      this.hplDownload.Visible = false;
      this.hplDownload.NavigateUrl = "";
    }
  }

  public void GenerateHdfcLiabFormat(string[] arrCaseId)
  {
    try
    {
      if (arrCaseId.Length <= 0)
        return;
      DataSet dataSet = new DataSet();
      CReport creport = new CReport();
      DataTable table1 = new DataTable();
      DataTable table2 = new DataTable();
      DataTable table3 = new DataTable();
      string str1 = this.Server.MapPath("../../ExportToUTI/HDFC Bank/") + "/";
      DateTime.Now.ToString("ddMMyyyyhhmmss");
      string str2 = DateTime.Now.ToString("dd-MMM-yyyy");
      for (int index = 0; index < arrCaseId.Length; ++index)
      {
        dataSet.Tables.Clear();
        dataSet.Clear();
        string str3 = "";
        string str4 = "";
        OleDbDataReader refNoByCaseIdKyc = creport.GetRefNoByCaseIdKyc(arrCaseId[index].ToString());
        if (refNoByCaseIdKyc.Read())
          str3 = refNoByCaseIdKyc["Ref_No"].ToString();
        string str5 = refNoByCaseIdKyc["Case_id"].ToString();
        OleDbDataReader appnameBycaseIdkyc = creport.GetAppnameBycaseIDKYC(arrCaseId[index].ToString());
        if (appnameBycaseIdkyc.Read())
          str4 = appnameBycaseIdkyc["App_Name"].ToString();
        refNoByCaseIdKyc.Close();
        table1 = creport.GetCaseIdforReportKyc(arrCaseId[index].ToString());
        table2 = creport.GetBusinessVerificationDtlKyc(arrCaseId[index].ToString());
        table3 = creport.GetResidenceVerificationDtlKyc(arrCaseId[index].ToString());
        dataSet.Tables.Add(table1);
        dataSet.Tables[0].TableName = "Main";
        dataSet.Tables.Add(table2);
        dataSet.Tables[1].TableName = "Kyc_Hdfc_Buss";
        dataSet.Tables.Add(table3);
        dataSet.Tables[2].TableName = "Kyc_Hdfc_Resi";
        if (dataSet.Tables[2].Rows.Count > 0)
        {
          CrystalReportDocument crystalReportDocument = new CrystalReportDocument();
          ((ReportDocument) crystalReportDocument).Load(this.Server.MapPath("KYC_Hdfc_Export.rpt"));
          ((ReportDocument) crystalReportDocument).SetDataSource(dataSet);
          this.Session["Path"] = (object) this.Server.MapPath("KYC_Hdfc_Export.rpt");
          ((ReportDocument) crystalReportDocument).ExportToDisk((ExportFormatType) 5, str1 + str3 + "_" + str4 + "_" + str2 + ".pdf");
          crystalReportDocument.Dispose();
        }
        else
        {
          CrystalReportDocument crystalReportDocument = new CrystalReportDocument();
          ((ReportDocument) crystalReportDocument).Load(this.Server.MapPath("KYC_Hdfc_Export_BV.rpt"));
          ((ReportDocument) crystalReportDocument).SetDataSource(dataSet);
          this.Session["Path"] = (object) this.Server.MapPath("KYC_Hdfc_Export_BV.rpt");
          ((ReportDocument) crystalReportDocument).ExportToDisk((ExportFormatType) 5, str1 + str3 + "_" + str4 + "_" + str2 + ".pdf");
          crystalReportDocument.Dispose();
        }
        this.list.Add((object) (str1 + str3 + "_" + str4 + "_" + str2 + ".pdf"));
        string str6 = str3 + "_" + str4 + "_" + str2 + ".pdf";
        SqlCommand sqlCommand = new SqlCommand();
        sqlCommand.Connection = this.sqlcon;
        sqlCommand.CommandType = CommandType.StoredProcedure;
        sqlCommand.CommandText = "Sp_Update_Pdf_name";
        sqlCommand.CommandTimeout = 0;
        SqlParameter sqlParameter1 = new SqlParameter();
        sqlParameter1.SqlDbType = SqlDbType.VarChar;
        sqlParameter1.Value = (object) str6;
        sqlParameter1.ParameterName = "@PDF";
        sqlCommand.Parameters.Add(sqlParameter1);
        SqlParameter sqlParameter2 = new SqlParameter();
        sqlParameter2.SqlDbType = SqlDbType.VarChar;
        sqlParameter2.Value = (object) str5;
        sqlParameter2.ParameterName = "@Case_id";
        sqlCommand.Parameters.Add(sqlParameter2);
        this.sqlcon.Open();
        sqlCommand.ExecuteNonQuery();
        this.sqlcon.Close();
        GC.Collect();
      }
      this.listcount = this.list.Count;
      table1.Clear();
      table2.Clear();
      table3.Clear();
      table1.Dispose();
      table2.Dispose();
      table3.Dispose();
      dataSet.Clear();
      dataSet.Dispose();
    }
    catch (Exception ex)
    {
      this.lblMsg.Visible = true;
      this.lblMsg.Text = ex.Message;
      this.hplDownload.Visible = false;
      this.hplDownload.NavigateUrl = "";
    }
  }

  private void Get_EmployeeDetails()
  {
    SqlConnection sqlConnection = new SqlConnection(new CCommon().AppConnectionString);
    sqlConnection.Open();
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
    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
    sqlDataAdapter.SelectCommand = sqlCommand;
    DataSet dataSet = new DataSet();
    sqlDataAdapter.Fill(dataSet);
    sqlConnection.Close();
    if (dataSet.Tables[0].Rows.Count <= 0)
      return;
    this.HdnBranchCode.Value = dataSet.Tables[0].Rows[0]["Branch_code"].ToString();
  }

  protected void btnExport1_Click(object sender, EventArgs e)
  {
    try
    {
      string str = "";
      foreach (GridViewRow row in this.gvOutput.Rows)
      {
        HiddenField control = (HiddenField) row.FindControl("hidCaseId");
        if (((CheckBox) row.FindControl("chkCaseId")).Checked)
          str = str + control.Value + ",";
      }
      if (str != "")
      {
        string[] arrCaseID = str.TrimEnd(',').Split(',');
        this.GetExport(this.ddlSelectFormat1.SelectedValue.ToString(), arrCaseID);
        this.Download_record();
      }
      else
      {
        this.lblMsg.Visible = true;
        this.lblMsg.Text = "Please select case to Export.";
        this.hplDownload.Visible = false;
        this.hplDownload.NavigateUrl = "";
        this.gvOutput.DataBind();
      }
    }
    catch (Exception ex)
    {
      this.lblMsg.Visible = true;
      this.lblMsg.Text = ex.Message;
      this.hplDownload.Visible = false;
      this.hplDownload.NavigateUrl = "";
    }
  }

  protected void btnExport_Click(object sender, EventArgs e)
  {
    try
    {
      string str = "";
      foreach (GridViewRow row in this.gvOutput.Rows)
      {
        HiddenField control = (HiddenField) row.FindControl("hidCaseId");
        if (((CheckBox) row.FindControl("chkCaseId")).Checked)
          str = str + control.Value + ",";
      }
      if (str != "")
      {
        string[] arrCaseID = str.TrimEnd(',').Split(',');
        this.GetExport(this.ddlSelectFormat.SelectedValue.ToString(), arrCaseID);
        this.Download_record();
      }
      else
      {
        this.lblMsg.Visible = true;
        this.lblMsg.Text = "Please select case to Export.";
        this.gvOutput.DataBind();
      }
    }
    catch (Exception ex)
    {
      this.lblMsg.Visible = true;
      this.lblMsg.Text = ex.Message;
    }
  }

  private void Download_record()
  {
    try
    {
      string str1 = this.Session["CentreId"].ToString();
      string str2 = this.ddlclientname.SelectedValue.ToString();
      this.HdnBranchCode.Value = (string) null;
      this.Get_EmployeeDetails();
      string str3 = "";
      this.hdFromDate.Value = "";
      this.hdToDate.Value = str3;
      if (!(str1 != "") || !(str2 != ""))
        return;
      using (SqlConnection connection = new SqlConnection(this.objConn.AppConnectionString))
      {
        SqlCommand sqlCommand = new SqlCommand("sp_Download_record", connection);
        sqlCommand.CommandType = CommandType.StoredProcedure;
        sqlCommand.Parameters.AddWithValue("@ref_no", (object) this.HdnBranchCode.Value);
        sqlCommand.Parameters.AddWithValue("@CENTRE_ID", (object) str1);
        sqlCommand.Parameters.AddWithValue("@CLIENT_ID", (object) str2);
        sqlCommand.Parameters.AddWithValue("@FromDate", (object) this.objCmn.strDate(this.txtFromDate.Text.Trim()));
        sqlCommand.Parameters.AddWithValue("@ToDate", (object) this.objCmn.strDate(this.txtToDate.Text.Trim()));
        connection.Open();
        SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
        sqlDataAdapter.SelectCommand = sqlCommand;
        DataSet dataSet = new DataSet();
        sqlDataAdapter.Fill(dataSet);
        connection.Close();
        this.gvOutput.Visible = false;
        this.grv_annexure.DataSource = (object) dataSet;
        this.grv_annexure.DataBind();
        if (this.grv_annexure.Rows.Count <= 0)
          this.lblMsg.Text = "No record found";
        else
          this.lblMsg.Text = "Total Cases Found Is " + (object) this.grv_annexure.Rows.Count;
      }
    }
    catch (Exception ex)
    {
      this.lblMsg.Text = ex.Message;
    }
  }

  private void GetMergedPDF()
  {
    PDFMerger pdfMerger = new PDFMerger();
    for (int index = 0; index < this.listcount; ++index)
      pdfMerger.AddFile(this.list[index].ToString());
    pdfMerger.DestinationFile = this.hdnDestPath.Value;
    pdfMerger.Execute();
  }

  public void GetExport(string strFormat, string[] arrCaseID)
  {
    if (this.ddlSelectFormat.SelectedValue.ToString() == "5" || this.ddlSelectFormat1.SelectedValue.ToString() == "5")
      this.GenerateHdfcLiabFormat(arrCaseID);
    else if (this.ddlSelectFormat.SelectedValue.ToString() == "26" || this.ddlSelectFormat1.SelectedValue.ToString() == "26")
      this.GenerateHdfcLiabFormat(arrCaseID);
    else if (this.ddlSelectFormat.SelectedValue.ToString() == "15" || this.ddlSelectFormat1.SelectedValue.ToString() == "15")
      this.GenerateHdfcLiabCurrFormat(arrCaseID);
    else if (this.ddlSelectFormat.SelectedValue.ToString() == "0" && this.ddlSelectFormat1.SelectedValue.ToString() == "0")
    {
      this.lblMsg.Visible = true;
      this.lblMsg.Text = "Please select format.";
      this.hplDownload.Visible = false;
      this.hplDownload.NavigateUrl = "";
    }
    this.gvOutput.DataBind();
  }

  protected void cvSelectFormat_ServerValidate(object source, ServerValidateEventArgs args)
  {
    if (!(source.ToString() == "0"))
      return;
    this.lblMsg.Visible = true;
    this.lblMsg.Text = "Please select format.";
  }

  protected void gvOutput_PageIndexChanged(object sender, EventArgs e) => this.gvOutput.DataBind();

  protected void gvOutput_PageIndexChanging(object sender, GridViewPageEventArgs e) => this.gvOutput.DataBind();

  protected void gvOutput_DataBound(object sender, EventArgs e)
  {
    if (this.gvOutput.Rows.Count <= 0)
      return;
    this.tblCaseCount.Visible = true;
    ((WebControl) this.gvOutput.HeaderRow.FindControl("HeaderLevelCheckBox")).Attributes["onclick"] = "ChangeAllCheckBoxStates(this.checked);";
    foreach (Control row in this.gvOutput.Rows)
      this.ClientScript.RegisterArrayDeclaration("CheckBoxIDs", "'" + row.FindControl("chkCaseId").ClientID + "'");
  }

  private void GenerateHDFCReport()
  {
    this.ddlclientname.SelectedValue.ToString();
    try
    {
      this.sqlcon = new SqlConnection(this.objConn.AppConnectionString);
      SqlCommand sqlCommand = new SqlCommand();
      sqlCommand.Connection = this.sqlcon;
      sqlCommand.CommandType = CommandType.StoredProcedure;
      sqlCommand.CommandText = "Sp_Hdfc_liab_Dump";
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
      sqlParameter3.Value = (object) this.Session["CentreId"].ToString();
      sqlParameter3.ParameterName = "@Centreid";
      sqlCommand.Parameters.Add(sqlParameter3);
      SqlParameter sqlParameter4 = new SqlParameter();
      sqlParameter4.SqlDbType = SqlDbType.VarChar;
      sqlParameter4.Value = (object) this.ddlclientname.SelectedValue.ToString();
      sqlParameter4.ParameterName = "@ClientId";
      sqlCommand.Parameters.Add(sqlParameter4);
      this.sqlcon.Open();
      SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
      sqlDataAdapter.SelectCommand = sqlCommand;
      DataSet dataSet = new DataSet();
      sqlDataAdapter.Fill(dataSet);
      this.sqlcon.Close();
      if (dataSet.Tables[0].Rows.Count > 0)
      {
        this.lblMsg.Text = "";
        this.lblMsg.Text = "Total Count Is :" + (object) dataSet.Tables[0].Rows.Count;
        this.grdvwFGB.DataSource = (object) dataSet;
        this.grdvwFGB.DataBind();
      }
    }
    catch (Exception ex)
    {
      this.lblMsg.Text = ex.Message;
    }
    this.GenerateEXPORTFormat();
  }

  public void GenerateEXPORTFormat()
  {
    string str = "attachment; filename= Report.xls";
    this.Response.Clear();
    this.Response.ClearHeaders();
    this.Response.ClearContent();
    this.Response.AddHeader("content-disposition", str);
    this.Response.ContentType = "application/ms-excel";
    StringWriter stringWriter = new StringWriter();
    this.grdvwFGB.RenderControl(new HtmlTextWriter((TextWriter) stringWriter));
    this.grdvwFGB.GridLines = GridLines.Both;
    this.Response.Write(stringWriter.ToString());
    this.Response.End();
  }

  public string strDate(string strInDate)
  {
    string str1 = strInDate.Substring(0, 2);
    string str2 = strInDate.Substring(3, 2);
    string str3 = strInDate.Substring(6, 4);
    return Convert.ToDateTime(str2 + "/" + str1 + "/" + str3).ToString("dd-MMM-yyyy");
  }

  public override void VerifyRenderingInServerForm(Control control)
  {
  }

  protected void Button1_Click(object sender, EventArgs e) => this.GenerateHDFCReport();

  protected void btnCPVintdetl_Click(object sender, EventArgs e)
  {
    if (this.ddlReports.SelectedIndex == 2)
      this.Sp_HDFC_Count();
    if (this.txtFromDate.Text.Trim() != "")
    {
      if (this.txtToDate.Text.Trim() != "")
      {
        if (this.ddlReports.SelectedIndex == 0)
          this.GenerateHDFCCPVInitiationReport();
        else if (this.ddlReports.SelectedIndex == 1)
          this.HDFC_CPV_Initiator_Details();
        else if (this.ddlReports.SelectedIndex == 3)
        {
          this.GenerateHDFCCPVInitiationPanindiaReport();
        }
        else
        {
          if (this.ddlReports.SelectedIndex != 4)
            return;
          this.HDFC_CPV_Initiation_Details_PanIndia_Current();
        }
      }
      else
        this.lblMsg.Text = "Please Enter To Date";
    }
    else
      this.lblMsg.Text = "Please Enter From Date";
  }

  private void GenerateHDFCCPVInitiationReport()
  {
    this.ddlclientname.SelectedValue.ToString();
    try
    {
      this.sqlcon = new SqlConnection(this.objConn.AppConnectionString);
      SqlCommand sqlCommand = new SqlCommand();
      sqlCommand.Connection = this.sqlcon;
      sqlCommand.CommandType = CommandType.StoredProcedure;
      sqlCommand.CommandText = "HDFC_CPV_Initiation_Details";
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
      sqlParameter3.Value = (object) this.Session["userid"].ToString();
      sqlParameter3.ParameterName = "@Emp_id";
      sqlCommand.Parameters.Add(sqlParameter3);
      SqlParameter sqlParameter4 = new SqlParameter();
      sqlParameter4.SqlDbType = SqlDbType.VarChar;
      sqlParameter4.Value = (object) this.Session["CentreId"].ToString();
      sqlParameter4.ParameterName = "@Centreid";
      sqlCommand.Parameters.Add(sqlParameter4);
      SqlParameter sqlParameter5 = new SqlParameter();
      sqlParameter5.SqlDbType = SqlDbType.VarChar;
      sqlParameter5.Value = (object) this.ddlclientname.SelectedValue.ToString();
      sqlParameter5.ParameterName = "@ClientId";
      sqlCommand.Parameters.Add(sqlParameter5);
      this.sqlcon.Open();
      SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
      sqlDataAdapter.SelectCommand = sqlCommand;
      DataSet dataSet = new DataSet();
      sqlDataAdapter.Fill(dataSet);
      this.sqlcon.Close();
      if (dataSet.Tables[0].Rows.Count > 0)
      {
        this.lblMsg.Text = "";
        this.lblMsg.Text = "Total Count Is :" + (object) dataSet.Tables[0].Rows.Count;
        this.grdvwFGB.Visible = true;
        this.grdvwFGB.DataSource = (object) dataSet;
        this.grdvwFGB.DataBind();
      }
    }
    catch (Exception ex)
    {
      this.lblMsg.Text = ex.Message;
    }
    this.GenerateEXPORTFormat();
  }

  private void GenerateHDFCCPVInitiationPanindiaReport()
  {
    this.ddlclientname.SelectedValue.ToString();
    try
    {
      this.sqlcon = new SqlConnection(this.objConn.AppConnectionString);
      SqlCommand sqlCommand = new SqlCommand();
      sqlCommand.Connection = this.sqlcon;
      sqlCommand.CommandType = CommandType.StoredProcedure;
      sqlCommand.CommandText = "HDFC_CPV_Initiation_Details_PanIndia";
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
      sqlParameter3.Value = (object) this.Session["userid"].ToString();
      sqlParameter3.ParameterName = "@Emp_id";
      sqlCommand.Parameters.Add(sqlParameter3);
      SqlParameter sqlParameter4 = new SqlParameter();
      sqlParameter4.SqlDbType = SqlDbType.VarChar;
      sqlParameter4.Value = (object) this.Session["CentreId"].ToString();
      sqlParameter4.ParameterName = "@Centreid";
      sqlCommand.Parameters.Add(sqlParameter4);
      SqlParameter sqlParameter5 = new SqlParameter();
      sqlParameter5.SqlDbType = SqlDbType.VarChar;
      sqlParameter5.Value = (object) this.ddlclientname.SelectedValue.ToString();
      sqlParameter5.ParameterName = "@ClientId";
      sqlCommand.Parameters.Add(sqlParameter5);
      this.sqlcon.Open();
      SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
      sqlDataAdapter.SelectCommand = sqlCommand;
      DataSet dataSet = new DataSet();
      sqlDataAdapter.Fill(dataSet);
      this.sqlcon.Close();
      if (dataSet.Tables[0].Rows.Count > 0)
      {
        this.lblMsg.Text = "";
        this.lblMsg.Text = "Total Count Is :" + (object) dataSet.Tables[0].Rows.Count;
        this.grdvwFGB.Visible = true;
        this.grdvwFGB.DataSource = (object) dataSet;
        this.grdvwFGB.DataBind();
      }
    }
    catch (Exception ex)
    {
      this.lblMsg.Text = ex.Message;
    }
    this.GenerateEXPORTFormat();
  }

  private void HDFC_CPV_Initiation_Details_PanIndia_Current()
  {
    this.ddlclientname.SelectedValue.ToString();
    try
    {
      this.sqlcon = new SqlConnection(this.objConn.AppConnectionString);
      SqlCommand sqlCommand = new SqlCommand();
      sqlCommand.Connection = this.sqlcon;
      sqlCommand.CommandType = CommandType.StoredProcedure;
      sqlCommand.CommandText = nameof (HDFC_CPV_Initiation_Details_PanIndia_Current);
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
      sqlParameter3.Value = (object) this.Session["userid"].ToString();
      sqlParameter3.ParameterName = "@Emp_id";
      sqlCommand.Parameters.Add(sqlParameter3);
      SqlParameter sqlParameter4 = new SqlParameter();
      sqlParameter4.SqlDbType = SqlDbType.VarChar;
      sqlParameter4.Value = (object) this.Session["CentreId"].ToString();
      sqlParameter4.ParameterName = "@Centreid";
      sqlCommand.Parameters.Add(sqlParameter4);
      SqlParameter sqlParameter5 = new SqlParameter();
      sqlParameter5.SqlDbType = SqlDbType.VarChar;
      sqlParameter5.Value = (object) this.ddlclientname.SelectedValue.ToString();
      sqlParameter5.ParameterName = "@ClientId";
      sqlCommand.Parameters.Add(sqlParameter5);
      this.sqlcon.Open();
      SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
      sqlDataAdapter.SelectCommand = sqlCommand;
      DataSet dataSet = new DataSet();
      sqlDataAdapter.Fill(dataSet);
      this.sqlcon.Close();
      if (dataSet.Tables[0].Rows.Count > 0)
      {
        this.lblMsg.Text = "";
        this.lblMsg.Text = "Total Count Is :" + (object) dataSet.Tables[0].Rows.Count;
        this.grdvwFGB.Visible = true;
        this.grdvwFGB.DataSource = (object) dataSet;
        this.grdvwFGB.DataBind();
      }
    }
    catch (Exception ex)
    {
      this.lblMsg.Text = ex.Message;
    }
    this.GenerateEXPORTFormat();
  }

  private void HDFC_CPV_Initiator_Details()
  {
    this.ddlclientname.SelectedValue.ToString();
    try
    {
      this.sqlcon = new SqlConnection(this.objConn.AppConnectionString);
      SqlCommand sqlCommand = new SqlCommand();
      sqlCommand.Connection = this.sqlcon;
      sqlCommand.CommandType = CommandType.StoredProcedure;
      sqlCommand.CommandText = nameof (HDFC_CPV_Initiator_Details);
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
      sqlParameter3.Value = (object) this.Session["CentreId"].ToString();
      sqlParameter3.ParameterName = "@Centreid";
      sqlCommand.Parameters.Add(sqlParameter3);
      SqlParameter sqlParameter4 = new SqlParameter();
      sqlParameter4.SqlDbType = SqlDbType.VarChar;
      sqlParameter4.Value = (object) this.ddlclientname.SelectedValue.ToString();
      sqlParameter4.ParameterName = "@ClientId";
      sqlCommand.Parameters.Add(sqlParameter4);
      this.sqlcon.Open();
      SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
      sqlDataAdapter.SelectCommand = sqlCommand;
      DataSet dataSet = new DataSet();
      sqlDataAdapter.Fill(dataSet);
      this.sqlcon.Close();
      if (dataSet.Tables[0].Rows.Count > 0)
      {
        this.lblMsg.Text = "";
        this.lblMsg.Text = "Total Count Is :" + (object) dataSet.Tables[0].Rows.Count;
        this.grdvwFGB.Visible = true;
        this.grdvwFGB.DataSource = (object) dataSet;
        this.grdvwFGB.DataBind();
      }
    }
    catch (Exception ex)
    {
      this.lblMsg.Text = ex.Message;
    }
    this.GenerateEXPORTFormat();
  }

  private void Sp_HDFC_Count()
  {
    this.ddlclientname.SelectedValue.ToString();
    try
    {
      this.sqlcon = new SqlConnection(this.objConn.AppConnectionString);
      SqlCommand sqlCommand = new SqlCommand();
      sqlCommand.Connection = this.sqlcon;
      sqlCommand.CommandType = CommandType.StoredProcedure;
      sqlCommand.CommandText = nameof (Sp_HDFC_Count);
      sqlCommand.CommandTimeout = 0;
      SqlParameter sqlParameter = new SqlParameter();
      sqlParameter.SqlDbType = SqlDbType.VarChar;
      sqlParameter.Value = (object) this.ddlclientname.SelectedValue.ToString();
      sqlParameter.ParameterName = "@ClientId";
      sqlCommand.Parameters.Add(sqlParameter);
      this.sqlcon.Open();
      SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
      sqlDataAdapter.SelectCommand = sqlCommand;
      DataSet dataSet = new DataSet();
      sqlDataAdapter.Fill(dataSet);
      this.sqlcon.Close();
      if (dataSet.Tables[0].Rows.Count > 0)
      {
        this.lblMsg.Text = "";
        this.lblMsg.Text = "Total Count Is :" + (object) dataSet.Tables[0].Rows.Count;
        this.grdvwFGB.Visible = true;
        this.grdvwFGB.DataSource = (object) dataSet;
        this.grdvwFGB.DataBind();
      }
    }
    catch (Exception ex)
    {
      this.lblMsg.Text = ex.Message;
    }
    this.GenerateEXPORTFormat();
  }

  protected void btninit_Click(object sender, EventArgs e) => this.HDFC_CPV_Initiator_Details();

  protected void gvOutput_SelectedIndexChanged(object sender, EventArgs e)
  {
  }
}
