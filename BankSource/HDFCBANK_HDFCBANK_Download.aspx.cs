// Decompiled with JetBrains decompiler
// Type: HDFCBANK_HDFCBANK_Download
// Assembly: App_Web_download.aspx.513d3bc3, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 2098F04A-46BB-4C70-822D-A67355947BFD
// Assembly location: D:\RK\RAMKI CONSULTANCY\PAMAC\Technology support\Projects\HDFC Bank\Decompiled source\App_Web_download.aspx.513d3bc3.dll

using myinfo;
using System;
using System.Data;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;

public class HDFCBANK_HDFCBANK_Download : Page, IRequiresSessionState
{
  private Info obj = new Info();

  protected DefaultProfile Profile => (DefaultProfile) this.Context.Profile;

  protected HttpApplication ApplicationInstance => this.Context.ApplicationInstance;

  protected void Page_Load(object sender, EventArgs e) => this.Download();

  private void Download()
  {
    DataSet dataSet = new DataSet();
    DataSet tokenUpdate = this.obj.Get_TokenUpdate();
    if (this.Session["Token"].ToString() == tokenUpdate.Tables[0].Rows[0]["Token"].ToString())
    {
      this.Session.Remove("Token");
      int num = new Random().Next();
      this.obj.UpdateTokenDetail(num);
      this.Session["Token"] = (object) num;
      string filename = this.Server.MapPath("~/ProcessFlow/HDFC Bank  Liab _Software Manual_Version 1.1 [Compatibility Mode].pdf");
      string str = "attachment; filename=HDFC Bank  Liab _Software Manual_Version 1.1 [Compatibility Mode].pdf";
      this.Response.ClearContent();
      this.Response.ClearHeaders();
      this.Response.Clear();
      this.Context.Response.AddHeader("content-disposition", str);
      this.Context.Response.ContentType = "application/PDF";
      this.Response.WriteFile(filename);
      this.Response.End();
    }
    else
      this.Response.Redirect("~/Error20.aspx");
  }
}
