using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.IO;

/// <summary>
/// Summary description for RenderImage
/// </summary>
public class RenderImage
{
	public RenderImage()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    private byte[] byteVerifierImage;

    public byte[] VerifierImage
    {
        get { return byteVerifierImage; }
        set { byteVerifierImage = value; }
    }

    private string strFileName;
    public string FileName
    {
        get { return strFileName; }
        set { strFileName = value; }
    }
  
    public string Render_FromByte_To_ImageFile()
    { 
        string filePath = strFileName;

        FileInfo FFileName_Valid = new FileInfo(filePath);
        if (FFileName_Valid.Exists)
        {
            File.Delete(filePath);
        }
        
        FileStream f = new FileStream(filePath, FileMode.OpenOrCreate, FileAccess.Write);

        f.Write(byteVerifierImage, 0, Convert.ToInt32(byteVerifierImage.Length));
        f.Close();

        return filePath;
    }
     
}
