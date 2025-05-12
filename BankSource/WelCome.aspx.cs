// Decompiled with JetBrains decompiler
// Type: WelCome
// Assembly: App_Web_welcome.aspx.cdcab7d2, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 314DAAC6-0ECC-4CFB-B891-5209FA9029B2
// Assembly location: D:\RK\RAMKI CONSULTANCY\PAMAC\Technology support\Projects\HDFC Bank\Decompiled source\App_Web_welcome.aspx.cdcab7d2.dll

using System;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;

public class WelCome : Page, IRequiresSessionState
{
  protected Image Image1;
  protected Label Label1;

  protected DefaultProfile Profile => (DefaultProfile) this.Context.Profile;

  protected HttpApplication ApplicationInstance => this.Context.ApplicationInstance;

  protected void Page_Load(object sender, EventArgs e)
  {
  }
}
