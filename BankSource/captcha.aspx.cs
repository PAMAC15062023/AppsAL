// Decompiled with JetBrains decompiler
// Type: captcha
// Assembly: App_Web_captcha.aspx.cdcab7d2, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 277FA4CC-D80A-486E-8AFB-279B3EB7D0C9
// Assembly location: C:\Users\hp\Desktop\App_Web_captcha.aspx.cdcab7d2.dll

using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;

public class captcha : Page, IRequiresSessionState
{
  protected HtmlForm form1;

  protected DefaultProfile Profile => (DefaultProfile) this.Context.Profile;

  protected HttpApplication ApplicationInstance => this.Context.ApplicationInstance;

  protected void Page_Load(object sender, EventArgs e)
  {
    Bitmap bitmap = new Bitmap(180, 50);
    Graphics graphics = Graphics.FromImage((Image) bitmap);
    graphics.Clear(Color.LightGray);
    Font font = new Font("Trebuchet MS", 25f, FontStyle.Regular);
    string s = this.getcapt();
    this.Session["Captcha"] = (object) s;
    graphics.DrawString(s, font, Brushes.Navy, 2f, 2f);
    this.Response.ContentType = "image/GIF";
    bitmap.Save(this.Response.OutputStream, ImageFormat.Gif);
    bitmap.Dispose();
    graphics.Dispose();
    font.Dispose();
  }

  public string getcapt()
  {
    string[] strArray = ("a,b,c,d,e,f,g,h,j,k,m,n,p,q,r,s,t,u,v,w,x,y,z," + "A,B,C,D,E,F,G,H,J,K,L,M,N,P,Q,R,S,T,U,V,W,X,Y,Z," + "2,3,14,5,6,43,4,5,67,8,9").Split(',');
    string str1 = "";
    Random random = new Random();
    for (int index = 0; index <= 6; ++index)
    {
      string str2 = strArray[random.Next(0, strArray.Length)];
      str1 += str2;
    }
    this.Session["Captcha"] = (object) str1;
    return str1;
  }
}