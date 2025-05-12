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



public partial class Pages_GeneratePDFReport : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnGenerate_Click(object sender, EventArgs e)
    {
        GeneratePDF();
    }
    public void GeneratePDF(object sender, System.EventArgs args)
    {
        // do manual validation of Name/BusinessName
        if (txtName.Text == "" && txtBusinessName.Text == "")
        {
            lblResult.Text = "<font color=red>Either Name or Business name must be specified.</font>";
            return;
        }

        // create instance of the PDF manager
        PdfManager objPDF = new PdfManager();

        // Create new document
        PdfDocument objDoc = objPDF.OpenDocument(Server.MapPath("images/w9.pdf"));

        // Obtain page 1 of the document
        PdfPage objPage = objDoc.Pages[1];

        // Create empty param object to be used throughout the app
        PdfParam objParam = objPDF.CreateParam();

        PdfFont objFont = objDoc.Fonts["Helvetica-Bold"]; // a standard font

        // Name
        objParam.Add("x=70, y=698");
        objPage.Canvas.DrawText(txtName.Text, objParam, objFont);

        // Business Name
        objParam.Add("y=674");
        objPage.Canvas.DrawText(txtBusinessName.Text, objParam, objFont);

        // Draw a check mark in a business type box using standard ZapfDingbat font
        float x = 150F, y = 653F;

        if (Type1.Checked)
            x = 229F;

        if (Type2.Checked)
            x = 294F;

        if (Type3.Checked)
            x = 351.5F;

        objParam["x"] = x;
        objParam["y"] = y;
        objPage.Canvas.DrawText("4", objParam, objDoc.Fonts["ZapfDingbats"]);


        // Other
        if (Type3.Checked && txtOther.Text != "")
        {
            objParam.Add("x=397, y=653");
            objPage.Canvas.DrawText(txtOther.Text, objParam, objFont);
        }

        // Exempt checkbox
        if (chkExempt.Checked)
        {
            objPage.Canvas.DrawText("4", "x=480.5; y=653", objDoc.Fonts["ZapfDingbats"]);
        }

        // Address
        objParam.Add("x=70, y=626");
        objPage.Canvas.DrawText(txtAddress.Text, objParam, objFont);

        // City, State, Zip
        objParam.Add("y=602");
        objPage.Canvas.DrawText(txtCity.Text + ", " + txtState.Text + " " + txtZip.Text, objParam, objFont);

        // SSN or EIN
        String strTIN;
        if (TIN0.Checked)
        {
            y = 533;
            strTIN = txtSSN.Text;
        }
        else
        {
            y = 493;
            strTIN = txtEIN.Text;
        }

        x = 433;
        float dX = 14.4F; // box size
        for (int i = 0; i < strTIN.Length; i++)
        {
            if ((char)strTIN[i] >= '0' && (char)strTIN[i] <= '9')
            {
                objParam["x"] = x;
                objParam["y"] = y;
                objPage.Canvas.DrawText(strTIN[i].ToString(), objParam, objFont);
                x = x + dX;
            }
        }

        // Date
        objParam.Add("x=432, y=337");
        objPage.Canvas.DrawText(DateTime.Today.ToString("MMM dd, yyyy"), objParam, objFont);

        // Signature - taken from a .gif file (image itself) and .bmp (mask)
        PdfImage objSignatureImg = objDoc.OpenImage(Server.MapPath("images/sig.gif"));
        PdfImage objMaskImg = objDoc.OpenImage(Server.MapPath("images/sig.bmp"));
        objMaskImg.IsMask = true;
        objSignatureImg.SetImageMask(objMaskImg);  // For transparency purposes

        objPage.Canvas.DrawImage(objSignatureImg, "x=144; y=316; scalex=.2, scaley=.2");

        // We use Session ID for file names.
        // false means "do not overwrite"
        // The method returns generated file name.
        String strPath = Server.MapPath("files") + "\\" + Session.SessionID + ".pdf";
        String strFileName = objDoc.Save(strPath, false);

        lblResult.Text = "Success. Your PDF file <font color=gray>" + strFileName + "</font> can be downloaded <A TARGET=_new HREF=\"files/" + strFileName + "\"><B>here</B></A>.";
    }
}
