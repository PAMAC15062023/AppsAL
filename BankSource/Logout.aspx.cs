// Decompiled with JetBrains decompiler
// Type: Logout
// Assembly: App_Web_logout.aspx.cdcab7d2, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: FCFE82D7-1DBE-4E6B-A033-BDDF9AB33F44
// Assembly location: D:\RK\RAMKI CONSULTANCY\PAMAC\Technology support\Projects\HDFC Bank\Decompiled source\App_Web_logout.aspx.cdcab7d2.dll

using System;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;

public class Logout : Page, IRequiresSessionState
{
  protected HtmlForm form1;

  protected DefaultProfile Profile => (DefaultProfile) this.Context.Profile;

  protected HttpApplication ApplicationInstance => this.Context.ApplicationInstance;

  protected void Page_Load(object sender, EventArgs e)
  {
    new CLogin().UpdateLogoutTime();
    this.Session.Clear();
    this.Session.Abandon();
    this.Session.RemoveAll();
    if (this.Request.Cookies["asp.NET_SessionId"] != null)
    {
      this.Response.Cookies["asp.NET_SessionId"].Value = string.Empty;
      this.Response.Cookies["asp.NET_SessionId"].Expires = DateTime.Now.AddMonths(-20);
    }
    if (this.Request.Cookies["AuthToken"] != null)
    {
      this.Response.Cookies["AuthToken"].Value = string.Empty;
      this.Response.Cookies["AuthToken"].Expires = DateTime.Now.AddMonths(-20);
    }
    this.Response.Redirect("Welcome.aspx");
  }
}
