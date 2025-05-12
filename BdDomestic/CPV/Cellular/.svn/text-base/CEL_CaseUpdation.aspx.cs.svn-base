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

public partial class CPV_Cellular_CEL_CaseUpdation : System.Web.UI.Page
{
    C_CELLULAR_ENTRY celobject = new C_CELLULAR_ENTRY();
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        celobject.CaseID = txtCaseId.Text.Trim();
        lblMsg.Text = celobject.CaseRecieved();
        txtCaseId.Text = "";
    }
}
