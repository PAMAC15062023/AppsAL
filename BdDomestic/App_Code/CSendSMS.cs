using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Net;
using System.IO;

/// <summary>
/// Summary description for CSendSMS
/// </summary>
public class CSendSMS
{
	public CSendSMS()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public string funSendSMS(string strMessage, string strMobileNo)
    {
        string strURL = "http://sms.its4solutions.com/sendsms.php";
        //string strEncoding = "?uname=PAMAC&passwd=55555&PhoneNumber=" + strMobileNo + "&sender=pamac&text=" + HttpUtility.UrlEncode(strMessage).ToString();
        string strEncoding = "?uname=" + ConfigurationManager.AppSettings["SMSUserId"].ToString() +
                             "&passwd=" + ConfigurationManager.AppSettings["SMSPassword"].ToString() + 
                             "&PhoneNumber=" + strMobileNo + "&sender=pamac&text=" + HttpUtility.UrlEncode(strMessage).ToString();

        string strResponse = string.Empty;
        
        strURL = strURL + strEncoding;
        
        WebClient wc = new WebClient();
        Stream responseStream = wc.OpenRead(strURL);
       
        StreamReader sr = new StreamReader(responseStream);
        
        string strResponseString = sr.ReadToEnd();
        

        if (strResponseString != string.Empty)
        {
            strResponse = strResponseString.ToString();
        }
        else
        {
            strResponse = "No Repsonse from SMS server";
        }

        sr.Close();
        responseStream.Close();
        return strResponse.ToString();
    }

}
