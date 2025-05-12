using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Design;

public partial class captcha : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Bitmap bmp = new Bitmap(180, 50);
        Graphics gp = Graphics.FromImage(bmp);
        gp.Clear(Color.LightGray);
        Font ft = new Font("Trebuchet MS", 25, FontStyle.Regular);
        string str = getcapt();
        
        Session["Captcha"] = str;

        gp.DrawString(str, ft, Brushes.Navy, 2, 2);
        Response.ContentType = "image/GIF";
        bmp.Save(Response.OutputStream, ImageFormat.Gif);
        bmp.Dispose();
        gp.Dispose();
        ft.Dispose();

    }
    public string getcapt()
    {
        string allowedchars = "a,b,c,d,e,f,g,h,j,k,m,n,p,q,r,s,t,u,v,w,x,y,z,";
        allowedchars += "A,B,C,D,E,F,G,H,J,K,L,M,N,P,Q,R,S,T,U,V,W,X,Y,Z,";
        allowedchars += "2,3,4,5,6,7,8,9";
        char[] sep ={ ',' };
        string[] arr = allowedchars.Split(sep);
        string passwordchars = "";
        string temp;
        Random rmd = new Random();
        int i;
        for (i = 0; i <= 6; i++)
        {
            temp = arr[rmd.Next(0, arr.Length)];
            passwordchars += temp;
        }

        Session["Captcha"] = passwordchars;
        return passwordchars;
    }

}
