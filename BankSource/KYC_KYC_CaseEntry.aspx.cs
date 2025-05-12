// Decompiled with JetBrains decompiler
// Type: KYC_KYC_CaseEntry
// Assembly: App_Web_kyc_caseentry.aspx.513d3bc3, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 36678623-0E42-4244-9AED-3D8DB47E30D1
// Assembly location: D:\RK\RAMKI CONSULTANCY\PAMAC\Technology support\Projects\HDFC Bank\Decompiled source\App_Web_kyc_caseentry.aspx.513d3bc3.dll

using myinfo;
using System;
using System.Collections;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Drawing;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;

public class KYC_KYC_CaseEntry : Page, IRequiresSessionState
{
  protected Label lblMsg;
  protected DropDownList ddlclientname;
  protected TextBox txtRefNo;
  protected TextBox txtTitle;
  protected TextBox txtRecDate;
  protected TextBox txtRecTime;
  protected DropDownList ddlTimeType;
  protected TextBox txtFirstNm;
  protected TextBox txtMiddleNm;
  protected TextBox txtLastNm;
  protected DropDownList ddlVeriType;
  protected TextBox txtResAdd1;
  protected TextBox txtResAdd2;
  protected TextBox txtResAdd3;
  protected TextBox txtResCity;
  protected TextBox txtResPin;
  protected TextBox txtResPhone;
  protected Panel PnlRes;
  protected TextBox txtOffName;
  protected TextBox txtOffAdd1;
  protected TextBox txtOffAdd2;
  protected TextBox txtOffAdd3;
  protected TextBox txtOffCity;
  protected TextBox txtOffPin;
  protected TextBox txtOffPhone;
  protected TextBox txtOffExtn;
  protected TextBox txtDesgn;
  protected TextBox txtDept;
  protected TextBox txtOccupation;
  protected Panel Panel1;
  protected Label lbllandmark;
  protected TextBox txtLandMark;
  protected Label lblreason;
  protected TextBox txtReasonForCpv;
  protected Label lblstate;
  protected TextBox txtstate;
  protected Label lblcountry;
  protected TextBox txtcountry;
  protected ASPNET_Captcha.ASPNET_Captcha ucCaptcha;
  protected TextBox txtCaptcha;
  protected Label lblMessage;
  protected Button btnSubmit;
  protected Button btnCancel;
  protected RequiredFieldValidator Rfvddlclient;
  protected RequiredFieldValidator reqfrstname;
  protected RequiredFieldValidator rqfmdlname;
  protected RequiredFieldValidator RequiredFieldValidator3;
  protected CustomValidator valVeriType;
  protected RegularExpressionValidator revReceived;
  protected RegularExpressionValidator revRecTime;
  protected RequiredFieldValidator rfvRecDate;
  protected RequiredFieldValidator rfvRecTime;
  protected RequiredFieldValidator RequiredFieldValidator2;
  protected ValidationSummary vsValidate;
  protected RequiredFieldValidator Add1;
  protected RequiredFieldValidator Add2;
  protected RequiredFieldValidator Add3;
  protected RequiredFieldValidator Resipin;
  protected RequiredFieldValidator landmark;
  protected RequiredFieldValidator Offadd1;
  protected RequiredFieldValidator Offadd2;
  protected RequiredFieldValidator OffPin;
  protected RequiredFieldValidator OffAdd3;
  protected RequiredFieldValidator RequiredFieldValidator1;
  private Info obj = new Info();
  private CKYC objKYC = new CKYC();
  private DataSet dsKYC = new DataSet();
  private DataSet dsVerification = new DataSet();
  private CCommon objcon = new CCommon();
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
    this.strClientID = this.ddlclientname.SelectedValue.ToString();
    this.Session["CentreId"].ToString();
    this.Call();
    string str1 = this.Context.Request.QueryString["CaseID"];
    this.OpID = this.Context.Request.QueryString["OperationId"];
    this.Sp_Login_Details_Check2();
    this.token();
    if (str1 == null)
      this.Sp_Login_Details_Check();
    try
    {
      if (this.txtRecDate.Text == "" || this.txtRecDate.Text == null)
      {
        this.txtRecDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
        this.txtRecTime.Text = DateTime.Now.ToString("hh:mm");
        this.ddlTimeType.SelectedValue = DateTime.Now.ToString("tt");
      }
      CCommon ccommon = new CCommon();
      if (this.Session["isView"].ToString() != "1")
        this.Response.Redirect("~/Error20.aspx");
      if (!this.IsPostBack)
      {
        this.ddlVeriType.Items.FindByText("Residence Address").Enabled = false;
        this.ddlVeriType.Items.FindByText("Office address").Enabled = false;
        this.ddlVeriType.Items.FindByText("Current account CPV").Enabled = false;
        this.ddlVeriType.Items.FindByText("--Select--").Enabled = true;
        this.PnlRes.Visible = false;
        this.Panel1.Visible = false;
        if (this.Context.Request.QueryString["CaseID"] != null && this.Context.Request.QueryString["CaseID"] != "")
        {
          string str2 = this.Request.QueryString["CaseID"].ToString();
          if (str2 != "")
          {
            if (str2 == "Add")
            {
              this.txtRecDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
              this.txtRecTime.Text = DateTime.Now.ToString("hh:mm");
              this.ddlTimeType.SelectedValue = DateTime.Now.ToString("tt");
            }
            this.dsKYC = this.objKYC.GetKYCCaseEntry(str2);
            if (this.dsKYC.Tables[0].Rows.Count > 0)
            {
              string str3 = this.dsKYC.Tables[0].Rows[0]["CASE_REC_DATETime"].ToString();
              if (str3 != "")
              {
                string[] strArray = str3.Split(' ');
                if (strArray[0].ToString() != "")
                  this.txtRecDate.Text = Convert.ToDateTime(strArray[0].ToString()).ToString("dd/MM/yyyy");
                if (strArray[1].ToString() != "")
                  this.txtRecTime.Text = Convert.ToDateTime(strArray[1].ToString()).ToString("hh:mm");
                this.ddlTimeType.SelectedValue = strArray[2].ToString();
              }
              this.txtRefNo.Text = this.dsKYC.Tables[0].Rows[0]["Ref_No"].ToString();
              this.ddlclientname.SelectedValue = this.dsKYC.Tables[0].Rows[0]["Client_id"].ToString();
              this.ddlclientname.Enabled = false;
              this.txtTitle.Text = this.dsKYC.Tables[0].Rows[0]["Title"].ToString();
              this.txtFirstNm.Text = this.dsKYC.Tables[0].Rows[0]["First_Name"].ToString();
              this.txtMiddleNm.Text = this.dsKYC.Tables[0].Rows[0]["Middle_Name"].ToString();
              this.txtLastNm.Text = this.dsKYC.Tables[0].Rows[0]["Last_Name"].ToString();
              this.txtResAdd1.Text = this.dsKYC.Tables[0].Rows[0]["RES_ADD_LINE_1"].ToString();
              this.txtResAdd2.Text = this.dsKYC.Tables[0].Rows[0]["RES_ADD_LINE_2"].ToString();
              this.txtResAdd3.Text = this.dsKYC.Tables[0].Rows[0]["RES_ADD_LINE_3"].ToString();
              this.txtResCity.Text = this.dsKYC.Tables[0].Rows[0]["RES_CITY"].ToString();
              this.txtResPhone.Text = this.dsKYC.Tables[0].Rows[0]["RES_PHONE"].ToString();
              this.txtResPin.Text = this.dsKYC.Tables[0].Rows[0]["RES_PIN_CODE"].ToString();
              this.txtLandMark.Text = this.dsKYC.Tables[0].Rows[0]["RES_LAND_MARK"].ToString();
              this.txtstate.Text = this.dsKYC.Tables[0].Rows[0]["State"].ToString();
              this.txtcountry.Text = this.dsKYC.Tables[0].Rows[0]["Country"].ToString();
              this.txtReasonForCpv.Text = this.dsKYC.Tables[0].Rows[0]["ReasonFrCPV"].ToString();
              this.txtOffName.Text = this.dsKYC.Tables[0].Rows[0]["Off_Name"].ToString();
              this.txtOffAdd1.Text = this.dsKYC.Tables[0].Rows[0]["OFF_ADD_LINE_1"].ToString();
              this.txtOffAdd2.Text = this.dsKYC.Tables[0].Rows[0]["OFF_ADD_LINE_2"].ToString();
              this.txtOffAdd3.Text = this.dsKYC.Tables[0].Rows[0]["OFF_ADD_LINE_3"].ToString();
              this.txtOffCity.Text = this.dsKYC.Tables[0].Rows[0]["OFF_CITY"].ToString();
              this.txtOffPhone.Text = this.dsKYC.Tables[0].Rows[0]["OFF_PHONE"].ToString();
              this.txtOffExtn.Text = this.dsKYC.Tables[0].Rows[0]["OFF_EXTN"].ToString();
              this.txtOffPin.Text = this.dsKYC.Tables[0].Rows[0]["OFF_PIN_CODE"].ToString();
              this.txtDesgn.Text = this.dsKYC.Tables[0].Rows[0]["DESIGNATION"].ToString();
              this.txtDept.Text = this.dsKYC.Tables[0].Rows[0]["DEPARTMENT"].ToString();
              this.txtOccupation.Text = this.dsKYC.Tables[0].Rows[0]["OCCUPATION"].ToString();
              this.ddlVeriType.SelectedValue = this.objKYC.GetVerificationType(str2);
              if (this.ddlVeriType.SelectedValue.ToString() == "2" && this.ddlclientname.SelectedValue.ToString() == "10160")
              {
                this.ddlVeriType.Items.FindByText("Office address").Enabled = true;
                this.ddlVeriType.Items.FindByText("--Select--").Enabled = false;
              }
              else if (this.ddlVeriType.SelectedValue.ToString() == "1" && this.ddlclientname.SelectedValue.ToString() == "10160")
              {
                this.ddlVeriType.Items.FindByText("Residence Address").Enabled = true;
                this.ddlVeriType.Items.FindByText("--Select--").Enabled = false;
              }
              else
              {
                this.ddlVeriType.Items.FindByText("--Select--").Enabled = false;
                this.ddlVeriType.Items.FindByText("Current account CPV").Enabled = true;
              }
              this.ddlVeriType.Enabled = false;
              if (this.txtResAdd1.Text != "")
              {
                this.lbllandmark.Visible = true;
                this.txtLandMark.Visible = true;
                this.PnlRes.Visible = true;
                this.Panel1.Visible = false;
                this.lblcountry.Visible = true;
                this.txtcountry.Visible = true;
                this.lblstate.Visible = true;
                this.txtstate.Visible = true;
                this.lblreason.Visible = true;
                this.txtReasonForCpv.Visible = true;
              }
              else if (this.txtOffAdd1.Text != "")
              {
                this.lbllandmark.Visible = true;
                this.txtLandMark.Visible = true;
                this.PnlRes.Visible = false;
                this.Panel1.Visible = true;
                this.lblcountry.Visible = true;
                this.txtcountry.Visible = true;
                this.lblstate.Visible = true;
                this.txtstate.Visible = true;
                this.lblreason.Visible = true;
                this.txtReasonForCpv.Visible = true;
              }
              else
              {
                this.lbllandmark.Visible = false;
                this.txtLandMark.Visible = false;
                this.PnlRes.Visible = false;
                this.Panel1.Visible = false;
                this.lblcountry.Visible = false;
                this.txtcountry.Visible = false;
                this.lblstate.Visible = false;
                this.txtstate.Visible = false;
                this.lblreason.Visible = false;
                this.txtReasonForCpv.Visible = false;
              }
            }
          }
        }
      }
      this.Get_EmployeeDetails();
    }
    catch (Exception ex)
    {
      this.Response.Redirect("~/InvalidRequest.aspx");
    }
  }

  private void ClearControl()
  {
    this.ddlTimeType.SelectedIndex = 0;
    this.txtTitle.Text = "";
    this.txtOffCity.Text = "";
    this.txtRefNo.Text = "";
    this.txtRecDate.Text = "";
    this.txtRecTime.Text = "";
    this.txtResAdd1.Text = "";
    this.txtResAdd2.Text = "";
    this.txtResAdd3.Text = "";
    this.txtResCity.Text = "";
    this.txtResPin.Text = "";
    this.txtResPhone.Text = "";
    this.txtOffAdd1.Text = "";
    this.txtOffAdd2.Text = "";
    this.txtOffAdd3.Text = "";
    this.txtOffPhone.Text = "";
    this.txtOffPin.Text = "";
    this.txtOffExtn.Text = "";
    this.txtLandMark.Text = "";
    this.txtDept.Text = "";
    this.txtDesgn.Text = "";
    this.txtFirstNm.Text = "";
    this.txtLastNm.Text = "";
    this.txtMiddleNm.Text = "";
    this.txtOccupation.Text = "";
    this.txtOffName.Text = "";
    this.txtstate.Text = "";
    this.txtReasonForCpv.Text = "";
    this.txtcountry.Text = "";
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
      this.ddlclientname.Items.Insert(0, new ListItem("--Select--", "0"));
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

  public void Sp_Login_Details_Check2()
  {
    string str = this.Session["userid"].ToString();
    DataSet dataSet = new DataSet();
    if (this.obj.Sp_Login_Details_Check2(str).Tables[0].Rows.Count > 0)
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

  protected void btnSubmit_Click(object sender, EventArgs e)
  {
    try
    {
      if (this.ucCaptcha.Validate(this.txtCaptcha.Text.Trim()))
      {
        int num = 0;
        ArrayList arrayList = new ArrayList();
        try
        {
          if (this.txtRecDate.Text.Trim() != "" && this.txtRecTime.Text.Trim() != "")
            ((CCPVDetail) this.objKYC).ReceivedDateTime = Convert.ToDateTime(this.objcon.strDate(this.txtRecDate.Text.Trim()) + " " + this.txtRecTime.Text.Trim() + " " + this.ddlTimeType.SelectedItem.Text.Trim());
          ((CCPVDetail) this.objKYC).CentreId = this.Session["CentreId"].ToString();
          ((CCPVDetail) this.objKYC).ClusterId = this.Session["ClusterId"].ToString();
          ((CCPVDetail) this.objKYC).ClientId = this.ddlclientname.SelectedValue.ToString();
          ((CCPVDetail) this.objKYC).RefNo = this.txtRefNo.Text.Trim();
          ((CCPVDetail) this.objKYC).Title = this.txtTitle.Text.Trim();
          ((CCPVDetail) this.objKYC).FirstName = this.txtFirstNm.Text.Trim();
          ((CCPVDetail) this.objKYC).MiddleName = this.txtMiddleNm.Text.Trim();
          ((CCPVDetail) this.objKYC).LastName = this.txtLastNm.Text.Trim();
          ((CCPVDetail) this.objKYC).FullName = this.txtFirstNm.Text.Trim() + " " + this.txtMiddleNm.Text.Trim() + " " + this.txtLastNm.Text.Trim();
          ((CCPVDetail) this.objKYC).ResAdd1 = this.txtResAdd1.Text.Trim();
          ((CCPVDetail) this.objKYC).ResAdd2 = this.txtResAdd2.Text.Trim();
          ((CCPVDetail) this.objKYC).ResAdd3 = this.txtResAdd3.Text.Trim();
          ((CCPVDetail) this.objKYC).ResCity = this.txtResCity.Text.Trim();
          ((CCPVDetail) this.objKYC).ResPin = this.txtResPin.Text.Trim();
          ((CCPVDetail) this.objKYC).ResLandMark = this.txtLandMark.Text.Trim();
          ((CCPVDetail) this.objKYC).State = this.txtstate.Text.Trim();
          ((CCPVDetail) this.objKYC).Country = this.txtcountry.Text.Trim();
          ((CCPVDetail) this.objKYC).ReasonfrCPV = this.txtReasonForCpv.Text.Trim();
          ((CCPVDetail) this.objKYC).ResPhone = this.txtResPhone.Text.Trim();
          ((CCPVDetail) this.objKYC).OffName = this.txtOffName.Text.Trim();
          ((CCPVDetail) this.objKYC).OfficeAdd1 = this.txtOffAdd1.Text.Trim();
          ((CCPVDetail) this.objKYC).OfficeAdd2 = this.txtOffAdd2.Text.Trim();
          ((CCPVDetail) this.objKYC).OfficeAdd3 = this.txtOffAdd3.Text.Trim();
          ((CCPVDetail) this.objKYC).OfficeCity = this.txtOffCity.Text.Trim();
          ((CCPVDetail) this.objKYC).OfficePin = this.txtOffPin.Text.Trim();
          ((CCPVDetail) this.objKYC).OfficePhone = this.txtOffPhone.Text.Trim();
          ((CCPVDetail) this.objKYC).OfficeExtn = this.txtOffExtn.Text.Trim();
          ((CCPVDetail) this.objKYC).Designation = this.txtDesgn.Text.Trim();
          ((CCPVDetail) this.objKYC).Department = this.txtDept.Text.Trim();
          ((CCPVDetail) this.objKYC).Occupation = this.txtOccupation.Text.Trim();
          this.objKYC.VerificationTypeID = this.ddlVeriType.SelectedValue.ToString();
          ((CCPVDetail) this.objKYC).AddedBy = this.Session["UserId"].ToString();
          ((CCPVDetail) this.objKYC).AddedOn = DateTime.Now;
          ((CCPVDetail) this.objKYC).ModifyBy = this.Session["UserId"].ToString();
          ((CCPVDetail) this.objKYC).ModifyOn = DateTime.Now;
          if (this.Context.Request.QueryString["CaseID"] != null && this.Context.Request.QueryString["CaseID"] != "")
          {
            OleDbDataReader kycCase = this.objKYC.GetKYCCase(this.Request.QueryString["CaseID"].ToString());
            if (!kycCase.Read())
            {
              if (this.objKYC.InsertKYCCaseEntry(arrayList, this.Session["Prefix"].ToString()) == 1)
              {
                this.lblMsg.Visible = true;
                this.lblMsg.Text = "Record added successfully.";
                this.ClearControl();
                if (this.Request.QueryString["CaseID"].ToString() == "Add")
                  num = 1;
              }
            }
            else if (this.objKYC.UpdateKYCCaseEntry(arrayList, this.Request.QueryString["CaseID"].ToString()) != 0)
            {
              this.lblMsg.Visible = true;
              this.lblMsg.Text = "Record updated successfully.";
              this.ClearControl();
              num = 1;
            }
            kycCase.Close();
          }
          else if (this.objKYC.InsertKYCCaseEntry(arrayList, this.Session["Prefix"].ToString()) == 1)
          {
            this.lblMsg.Visible = true;
            this.lblMsg.Text = "Record added successfully.";
            this.ClearControl();
          }
        }
        catch (Exception ex)
        {
          this.lblMsg.Visible = true;
          this.lblMsg.Text = ex.Message.ToString();
        }
        if (num != 1)
          return;
        this.Response.Redirect("~/HDFCBANK/HDFCBANK/Default.aspx");
      }
      else
      {
        this.lblMessage.Text = "Invalid!";
        this.lblMessage.ForeColor = Color.Red;
      }
    }
    catch (Exception ex)
    {
      this.lblMsg.Text = ex.Message;
    }
  }

  protected void gvKYC_RowDataBound(object sender, GridViewRowEventArgs e)
  {
    if (e.Row.RowType != DataControlRowType.DataRow)
      return;
    ((WebControl) e.Row.FindControl("lnkDeleteKYC")).Attributes.Add("onclick", "javascript:return confirm('Are you sure you want to delete this record')");
  }

  protected void btnCancel_Click(object sender, EventArgs e) => this.Response.Redirect("~/HDFCBANK/HDFCBANK/Default.aspx");

  protected void ddlVeriType_DataBound(object sender, EventArgs e) => ((ListControl) sender).Items.Insert(0, new ListItem("--Select Verification Type--", "0"));

  protected void ddlVeriType_SelectedIndexChanged(object sender, EventArgs e)
  {
    if (this.ddlVeriType.SelectedValue.ToString() == "1")
    {
      this.lbllandmark.Visible = true;
      this.txtLandMark.Visible = true;
      this.PnlRes.Visible = true;
      this.Panel1.Visible = false;
      this.lblcountry.Visible = true;
      this.txtcountry.Visible = true;
      this.lblstate.Visible = true;
      this.txtstate.Visible = true;
      this.lblreason.Visible = true;
      this.txtReasonForCpv.Visible = true;
    }
    else if (this.ddlVeriType.SelectedValue.ToString() == "2")
    {
      this.lbllandmark.Visible = true;
      this.txtLandMark.Visible = true;
      this.PnlRes.Visible = false;
      this.Panel1.Visible = true;
      this.lblcountry.Visible = true;
      this.txtcountry.Visible = true;
      this.lblstate.Visible = true;
      this.txtstate.Visible = true;
      this.lblreason.Visible = true;
      this.txtReasonForCpv.Visible = true;
    }
    else
    {
      this.lblcountry.Visible = false;
      this.txtcountry.Visible = false;
      this.lblstate.Visible = false;
      this.txtstate.Visible = false;
      this.lblreason.Visible = false;
      this.txtReasonForCpv.Visible = false;
      this.lbllandmark.Visible = false;
      this.txtLandMark.Visible = false;
      this.PnlRes.Visible = false;
      this.Panel1.Visible = false;
    }
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
    DataTable dataTable = new DataTable();
    sqlDataAdapter.Fill(dataTable);
    sqlConnection.Close();
    if (dataTable.Rows.Count <= 0)
      return;
    this.txtRefNo.Text = dataTable.Rows[0]["Branch_code"].ToString();
  }

  protected void ddlclientname_SelectedIndexChanged(object sender, EventArgs e)
  {
    if (this.ddlclientname.SelectedIndex != 0)
    {
      if (this.strClientID == "10160")
      {
        this.ddlVeriType.Items.FindByText("Residence Address").Enabled = true;
        this.ddlVeriType.Items.FindByText("Office address").Enabled = true;
        this.ddlVeriType.Items.FindByText("Current account CPV").Enabled = false;
        this.ddlVeriType.Items.FindByText("--Select--").Enabled = true;
      }
      else
      {
        this.ddlVeriType.Items.FindByText("Residence Address").Enabled = false;
        this.ddlVeriType.Items.FindByText("Office address").Enabled = false;
        this.ddlVeriType.Items.FindByText("Current account CPV").Enabled = true;
        this.ddlVeriType.Items.FindByText("--Select--").Enabled = true;
      }
    }
    else
    {
      this.ddlVeriType.Items.FindByText("Residence Address").Enabled = false;
      this.ddlVeriType.Items.FindByText("Office address").Enabled = false;
      this.ddlVeriType.Items.FindByText("Current account CPV").Enabled = false;
      this.ddlVeriType.Items.FindByText("--Select--").Enabled = true;
    }
    this.lblcountry.Visible = false;
    this.txtcountry.Visible = false;
    this.lblstate.Visible = false;
    this.txtstate.Visible = false;
    this.lblreason.Visible = false;
    this.txtReasonForCpv.Visible = false;
    this.lbllandmark.Visible = false;
    this.txtLandMark.Visible = false;
    this.PnlRes.Visible = false;
    this.Panel1.Visible = false;
  }
}
