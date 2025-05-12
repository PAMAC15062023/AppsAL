// Decompiled with JetBrains decompiler
// Type: Index
// Assembly: App_Web_client.aspx.cdcab7d2, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 43A87F01-EC34-4A6B-990A-4CBA2AB4CBB9
// Assembly location: D:\RK\RAMKI CONSULTANCY\PAMAC\Technology support\Projects\HDFC Bank\Decompiled source\App_Web_client.aspx.cdcab7d2.dll

using System;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public class Index : Page, IRequiresSessionState
{
  protected Label lblMsg;
  protected HyperLink HyperLink1;
  protected HyperLink HyperLink8;
  protected HyperLink HyperLink2;
  protected HyperLink HyperLink4;
  protected HyperLink HyperLink5;
  protected HyperLink HyperLink6;
  protected HyperLink HyperLink7;
  protected Label Label1;
  protected HtmlForm form1;

  protected DefaultProfile Profile => (DefaultProfile) this.Context.Profile;

  protected HttpApplication ApplicationInstance => this.Context.ApplicationInstance;

  private void Page_Init(object sender, EventArgs e) => this.ViewStateUserKey = this.Session.SessionID;

  protected void Page_Load(object sender, EventArgs e)
  {
    this.Label1.Text = this.Request.UserHostName.ToString();
    if (this.Request.ServerVariables["HTTP_X_FORWARDED_FOR"] == null)
      this.Label1.Text = this.Request.ServerVariables["REMOTE_ADDR"];
    if (this.Request.QueryString["Message"] == null)
      return;
    this.lblMsg.Text = this.Request.QueryString["Message"].ToString();
  }
}
