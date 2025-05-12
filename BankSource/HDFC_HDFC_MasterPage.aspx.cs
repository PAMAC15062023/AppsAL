// Decompiled with JetBrains decompiler
// Type: HDFC_HDFC_MasterPage
// Assembly: App_Web_masterpage.master.513d3bc3, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 7A7555D5-FD12-49C3-AEC2-68D060DFE299
// Assembly location: D:\RK\RAMKI CONSULTANCY\PAMAC\Technology support\Projects\HDFC Bank\Decompiled source\App_Web_masterpage.master.513d3bc3.dll

using myinfo;
using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Web.Profile;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public class HDFC_HDFC_MasterPage : MasterPage
{
  protected HtmlHead Head1;
  protected Menu Menu1;
  protected LinkButton LinkButton2;
  protected LinkButton lnkChangePassword;
  protected Label lblName;
  protected Label lbldate;
  protected ContentPlaceHolder C1;
  protected HtmlForm form1;
  private Info obj = new Info();

  protected DefaultProfile Profile => (DefaultProfile) this.Context.Profile;

  protected HttpApplication ApplicationInstance => this.Context.ApplicationInstance;

  protected void Page_Init(object sender, EventArgs e)
  {
    if (this.Session.Count == 0)
    {
      this.Session.Abandon();
      this.Response.Redirect("~/InvalidRequest.aspx");
    }
    else if (!string.IsNullOrEmpty(Convert.ToString(this.Session["userid"])) && this.Session["AuthToken"] != null && (this.Request.Cookies["AuthToken"] != null && !this.Session["AuthToken"].ToString().Equals(this.Request.Cookies["AuthToken"].Value)))
      this.Response.Redirect("~/InvalidRequest.aspx");
    CMaster cmaster = new CMaster();
    if (this.Request.QueryString.Count != 0)
    {
      if (this.Request.QueryString["OperationId"] == null)
        return;
      this.Session["OperationId"] = (object) this.Request.QueryString["OperationId"];
      ArrayList operationPermission = cmaster.GetOperationPermission(this.Session["OperationId"].ToString(), this.Session["RoleId"].ToString());
      this.Session["isAdd"] = (object) operationPermission[0].ToString();
      this.Session["isEdit"] = (object) operationPermission[1].ToString();
      this.Session["isDelete"] = (object) operationPermission[2].ToString();
      this.Session["isView"] = (object) operationPermission[3].ToString();
      operationPermission.Clear();
    }
    else
    {
      if (this.Session["OperationId"] == null || this.Session["RoleId"] == null)
        return;
      ArrayList operationPermission = cmaster.GetOperationPermission(this.Session["OperationId"].ToString(), this.Session["RoleId"].ToString());
      this.Session["isAdd"] = (object) operationPermission[0].ToString();
      this.Session["isEdit"] = (object) operationPermission[1].ToString();
      this.Session["isDelete"] = (object) operationPermission[2].ToString();
      this.Session["isView"] = (object) operationPermission[3].ToString();
    }
  }

  protected void Page_Load(object sender, EventArgs e)
  {
    this.token();
    this.Response.AddHeader("Pragma", "no-cache");
    this.logedindetails();
    if (this.Session["LogId"].ToString() != this.Session["Old"].ToString())
    {
      this.Response.Redirect("~/OldSession.aspx");
    }
    else
    {
      CMaster cmaster = new CMaster();
      cmaster.RoleId = this.Session["RoleId"].ToString();
      cmaster.UserId = this.Session["UserId"].ToString();
      cmaster.GetMenu(this.Session["ProductId"].ToString());
      if (this.Menu1.Items.Count == 0)
      {
        cmaster.GetMenu(this.Session["ProductId"].ToString());
        ArrayList operations = cmaster.Operations;
        int num = 0;
        foreach (ArrayList arrayList in operations)
        {
          arrayList[0].ToString();
          string text = arrayList[1].ToString();
          arrayList[2].ToString();
          string navigateUrl = arrayList[3].ToString();
          if (navigateUrl == "")
            navigateUrl = "javascript:alert('Under Construction')";
          string str1 = arrayList[4].ToString();
          string str2 = arrayList[5].ToString();
          if (arrayList[6].ToString() == "0")
          {
            this.Menu1.Items.Add(new MenuItem(text, text));
            ++num;
          }
          else if (str1 == "y")
            this.Menu1.Items[num - 1].ChildItems.Add(new MenuItem(text, text, "", navigateUrl)
            {
              Enabled = str2 == "1"
            });
          else if (str2 == "1")
          {
            MenuItem child = new MenuItem(text, text, "", navigateUrl);
            this.Menu1.Items[num - 1].ChildItems.Add(child);
          }
        }
      }
      if (this.Session["FLName"] == null || !(this.Session["FLName"].ToString() != ""))
        return;
      this.lblName.Text = this.Session["FLName"].ToString();
    }
  }

  protected void logedindetails()
  {
    try
    {
      SqlConnection sqlConnection = new SqlConnection(new CCommon().AppConnectionString);
      sqlConnection.Open();
      SqlCommand sqlCommand = new SqlCommand();
      sqlCommand.Connection = sqlConnection;
      sqlCommand.CommandType = CommandType.StoredProcedure;
      sqlCommand.CommandText = "Sp_Login_Details_2";
      sqlCommand.CommandTimeout = 0;
      SqlParameter sqlParameter = new SqlParameter();
      sqlParameter.SqlDbType = SqlDbType.VarChar;
      sqlParameter.Value = (object) this.Session["userid"].ToString().Trim();
      sqlParameter.ParameterName = "@LoginName";
      sqlCommand.Parameters.Add(sqlParameter);
      SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
      sqlDataAdapter.SelectCommand = sqlCommand;
      DataTable dataTable = new DataTable();
      sqlDataAdapter.Fill(dataTable);
      sqlConnection.Close();
      if (dataTable.Rows.Count <= 0)
        return;
      this.Session["Old"] = (object) dataTable.Rows[0]["log_det_id"].ToString();
      this.lbldate.Text = "Last logged on: " + dataTable.Rows[1]["login_date"].ToString() + " at :" + dataTable.Rows[1]["login_time"].ToString();
    }
    catch (Exception ex)
    {
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

  protected void LinkButton2_Click(object sender, EventArgs e)
  {
    try
    {
      this.Response.Redirect("~/HDFCBANK/HDFCBANK/Download.aspx", false);
    }
    catch (Exception ex)
    {
      this.Response.Redirect("~/Error20.aspx");
    }
  }
}
