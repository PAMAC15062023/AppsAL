// Decompiled with JetBrains decompiler
// Type: OldSession
// Assembly: App_Web_oldsession.aspx.cdcab7d2, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AA428822-9DA6-437F-8206-F0757564906D
// Assembly location: D:\RK\RAMKI CONSULTANCY\PAMAC\Technology support\Projects\HDFC Bank\Decompiled source\App_Web_oldsession.aspx.cdcab7d2.dll

using System;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;

public class OldSession : Page, IRequiresSessionState
{
  protected HtmlForm form1;

  protected DefaultProfile Profile => (DefaultProfile) this.Context.Profile;

  protected HttpApplication ApplicationInstance => this.Context.ApplicationInstance;

  protected void Page_Load(object sender, EventArgs e)
  {
    this.Session.Abandon();
    this.Response.Cookies.Add(new HttpCookie("ASP.NET_SessionId", ""));
  }
}
