using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Pages_CFS_Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnSendMail_Click(object sender, EventArgs e)
    {
        Response.Redirect("SendMail.aspx", true);
    }

    protected void btnCustomerMaster_Click(object sender, EventArgs e)
    {
        Response.Redirect("CustomerMasterUpload.aspx", true);
    }

    protected void btnCustomerResponseManual_Click(object sender, EventArgs e)
    {
        Response.Redirect("CFS_CustomerResponse_Manual.aspx", true);
    }

    protected void btnReports_Click(object sender, EventArgs e)
    {
        Response.Redirect("Reports.aspx", true);
    }

    protected void btnDuplicateMail_Click(object sender, EventArgs e)
    {
        Response.Redirect("CFS_DuplicateMail.aspx", true);
    }
}