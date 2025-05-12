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

public partial class Pages_ChequeProcessing_ChequeEntryModule : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (Session["UserInfo"] == null)
            {
                Response.Redirect("~/Pages/InvalidRequest.aspx", false);
            }
            else
            {
                if (!IsPostBack)
                {
                   
                    string AssignDate = DateTime.Today.ToShortDateString();
                    txtAssignDate.Text = Get_DateFormat(AssignDate, "dd/MM/yyyy");

                    Image1.ImageUrl = "~/Pages/ChequeProcessing/RenderImage.aspx?Date=" + txtAssignDate.Text.Trim() + "&Sr_no=0";
                }
            }
        }
        catch 
        { 
        
        }
    }
    protected void btnGenerate_Click(object sender, EventArgs e)
    {
        try
        {
            string AssignDate = txtAssignDate.Text.Trim();// Get_DateFormat(txtAssignDate.Text.Trim(), ConfigurationSettings.AppSettings["SQLServerDateFormat"]);
            Image1.ImageUrl = "../../Pages/ChequeProcessing/RenderImage.aspx?Date='" + AssignDate + "'&Sr_no=" + txtIndex.Text.Trim();
        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
            lblMessage.CssClass = "ErrorMessage";
            lblMessage.Visible = true;
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
      Response.Redirect("../Menu.aspx", false);
     
    }
    private string Get_DateFormat(string cDate, string cDateFormat)
    {
        try
        {
            string strDate = cDate;
            string[] strArrDate = strDate.Split('/');

            if (strArrDate.Length > 0)
            {
                if (cDateFormat == "yyyy/MM/dd")
                {
                    strDate = strArrDate[2] + "/" + strArrDate[1] + "/" + strArrDate[0];

                }
            

            
                if (cDateFormat == "MM/dd/yyyy")
                {
                    strDate = strArrDate[1] + "/" + strArrDate[0] + "/" + strArrDate[2];

                }
             
             
                if (cDateFormat == "dd/MM/yyyy")//MM/dd/yyyy
                {
                    strDate = strArrDate[1] + "/" + strArrDate[0] + "/" + strArrDate[2];
                }

            }
            return strDate;
        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
            lblMessage.CssClass = "ErrorMessage";
            lblMessage.Visible = true;
            return "";
        }

    }
}
