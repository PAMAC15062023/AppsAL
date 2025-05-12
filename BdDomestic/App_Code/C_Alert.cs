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

public class C_Alert
{
	public C_Alert()
	{
	}
    public void Show(string message)
    {
        // Cleans the message to allow single quotation marks 
        string cleanMessage = message.Replace("'", "\'");
        string script = "<script type=text/javascript language=javascript>alert('" + message + "');</script>";

        // Gets the executing web page 
        Page page = HttpContext.Current.CurrentHandler as Page;
       
        // Checks if the handler is a Page and that the script isn't allready on the Page 
        if (page != null && !page.ClientScript.IsClientScriptBlockRegistered("alert"))
        {
            page.ClientScript.RegisterStartupScript(typeof(C_Alert), "alert", script);            
        }
    }
    public void Showconfirm(string message)
    {
        // Cleans the message to allow single quotation marks 
        string cleanMessage = message.Replace("'", "\'");
        string script = "<script type=text/javascript language=javascript>confirm('" + message + "');</script>";

        // Gets the executing web page 
        Page page = HttpContext.Current.CurrentHandler as Page;

        // Checks if the handler is a Page and that the script isn't allready on the Page 
        if (page != null && !page.ClientScript.IsClientScriptBlockRegistered("confirm"))
        {
            page.ClientScript.RegisterStartupScript(typeof(C_Alert), "confirm", script);
        }
    } 
}
