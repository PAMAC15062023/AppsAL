// Decompiled with JetBrains decompiler
// Type: InvalidRequest
// Assembly: App_Web_invalidrequest.aspx.cdcab7d2, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: A079EB07-22CC-4A47-ABCE-C6DDC94EF8CF
// Assembly location: D:\RK\RAMKI CONSULTANCY\PAMAC\Technology support\Projects\HDFC Bank\Decompiled source\App_Web_invalidrequest.aspx.cdcab7d2.dll

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
  }

  protected void lnkLogin_Click(object sender, EventArgs e) => this.Response.Redirect("Client.aspx", false);
}
