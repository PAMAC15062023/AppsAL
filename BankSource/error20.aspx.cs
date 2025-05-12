// Decompiled with JetBrains decompiler
// Type: InvalidRequest
// Assembly: App_Web_error20.aspx.cdcab7d2, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DB06586B-A080-4C4A-9B52-35342A7D1A13
// Assembly location: D:\RK\RAMKI CONSULTANCY\PAMAC\Technology support\Projects\HDFC Bank\Decompiled source\App_Web_error20.aspx.cdcab7d2.dll

using System;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public class InvalidRequest : Page, IRequiresSessionState
{
  protected Label lblMessage;
  protected LinkButton lnkLogin;
  protected HtmlForm form1;

  protected DefaultProfile Profile => (DefaultProfile) this.Context.Profile;

  protected HttpApplication ApplicationInstance => this.Context.ApplicationInstance;

  protected void Page_Load(object sender, EventArgs e)
  {
    this.Session.Abandon();
    this.Response.Cookies.Add(new HttpCookie("ASP.NET_SessionId", ""));
  }

  protected void lnkLogin_Click(object sender, EventArgs e) => this.Response.Redirect("Client.aspx", false);
}
