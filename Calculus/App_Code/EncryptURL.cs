using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Text;
 

/// <summary>
/// Summary description for EncryptURL
/// </summary>
public class EncryptURL
{
	public EncryptURL()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public string EncryptURL_In(string URL)
    {
        int CharValue;
        string strURL="";
        for (int i = 0; i <= URL.Length-1; i++)
        {

            CharValue = Convert.ToInt32(URL[i]);
            strURL = strURL + CharValue.ToString();
        }

        return strURL;
    }
    public string DecryptURL_In(string URL)
    {
        Char CharValue;
        string strURL = "";
        for (int i = 0; i <= URL.Length - 1; i++)
        {

            int value =Convert.ToInt32(URL[i].ToString()  + URL[i+1].ToString());
            CharValue = Convert.ToChar(value);
            strURL = strURL + CharValue.ToString();
            i = i + 1;
        }
         
        return strURL;
    }

}
