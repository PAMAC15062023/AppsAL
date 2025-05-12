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

public partial class CC_CC_SMSGeneration : System.Web.UI.Page
{
    CCreditCard objCreditCard = new CCreditCard();

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        try
        {

        lblMsg.Text = "";
        lblMsg.Visible = false;
        if (chkName.Checked == true)
            sdsCreditCard.SelectCommand = objCreditCard.GetCreditCaseEntry(txtRefNo.Text.Trim(), txtName.Text.Trim(), true, txtFromDate.Text.Trim(), txtToDate.Text.Trim(), Session["CentreId"].ToString(), Session["ClientId"].ToString());
        else
            sdsCreditCard.SelectCommand = objCreditCard.GetCreditCaseEntry(txtRefNo.Text.Trim(), txtName.Text.Trim(), false, txtFromDate.Text.Trim(), txtToDate.Text.Trim(), Session["CentreId"].ToString(), Session["ClientId"].ToString());    
    
          }
        catch (Exception ex)
        {
            lblMsg.Visible = true;
            lblMsg.Text = "Error :" + ex.Message;
        }
        //try catch is added by supriya on 16th Nov2007
    }

    protected void btnSend_Click(object sender, EventArgs e)
    {
        ArrayList arrSMSContent = new ArrayList();
        ArrayList arrMobileNo = new ArrayList();
        CheckBox chkSelect;
        TextBox txtSMSContent;


        foreach (GridViewRow row in gvCreditCard.Rows)
        {   
            chkSelect = (CheckBox)row.FindControl("chkSelect");
            txtSMSContent =(TextBox)row.FindControl("txtSMSContent");

            if (chkSelect.Checked == true)
            {
                arrMobileNo.Add(row.Cells[4].Text.Trim());
                arrSMSContent.Add(txtSMSContent.Text.Trim());
            }
        }

    }
}
