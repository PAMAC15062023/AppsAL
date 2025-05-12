using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace InternalAuditApplication
{
    public partial class InternalAudit_AuthorizeFailed : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblMessage.Text = "You are not authorized to view this Page !!";
        }
    }
}