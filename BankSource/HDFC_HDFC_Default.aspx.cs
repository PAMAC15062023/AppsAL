// Decompiled with JetBrains decompiler
// Type: HDFC_HDFC_Default
// Assembly: App_Web_default.aspx.513d3bc3, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 7FD85B61-61BA-4B18-A102-34AD0D9D0D35
// Assembly location: D:\RK\RAMKI CONSULTANCY\PAMAC\Technology support\Projects\HDFC Bank\Decompiled source\App_Web_default.aspx.513d3bc3.dll

using myinfo;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;

public class HDFC_HDFC_Default : Page, IRequiresSessionState
{
  private SqlConnection sqlcon;
  private string connString;
  private Info obj = new Info();

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
    this.token();
  }

  public void Call()
  {
    string str = this.Session["userid"].ToString();
    DataSet dataSet1 = new DataSet();
    DataSet dataSet2 = this.obj.NewMethod(str);
    if (dataSet2.Tables[0].Rows.Count > 0)
    {
      this.Session["Old"] = (object) dataSet2.Tables[0].Rows[0]["log_det_id"].ToString();
      this.Session["LogId"].ToString();
      this.Session["Old"].ToString();
    }
    if (!(this.Session["LogId"].ToString() != this.Session["Old"].ToString()))
      return;
    this.Response.Redirect("~/OldSession.aspx");
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
}
