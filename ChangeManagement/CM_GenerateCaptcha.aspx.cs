using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Drawing.Text;
using System.IO;

namespace ChangeManagement
{
    public partial class CM_GenerateCaptcha : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            GenerateRandomText();
        }
        private void GenerateRandomText()
        {
            string randomText = GenerateRandomString();
            Session["Captcha"] = randomText;
            DrawImage(randomText);
        }

        private string GenerateRandomString()
        {
            Random rand = new Random();
            string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            char[] stringChars = new char[6];
            for (int i = 0; i < stringChars.Length; i++)
            {
                //if (i % 2 == 0)
                //{
                //    stringChars[i] = ' ';
                //}
                //else
                //{
                stringChars[i] = chars[rand.Next(chars.Length)];
                //}
            }
            return new String(stringChars);
        }

        private void DrawImage(string randomText)
        {

            Bitmap bitmap = new Bitmap(150, 50);
            Graphics graphics = Graphics.FromImage(bitmap);
            graphics.SmoothingMode = SmoothingMode.AntiAlias;
            graphics.Clear(Color.White);
            Font font = new Font("Arial", 20, FontStyle.Bold);
            graphics.DrawString(randomText, font, Brushes.Black, new PointF(10, 10));
            bitmap.Save(Response.OutputStream, ImageFormat.Jpeg);
            graphics.Dispose();
            bitmap.Dispose();
        }
    }
}