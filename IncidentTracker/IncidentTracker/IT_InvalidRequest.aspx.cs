using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IncidentTracker
{
    public partial class IT_InvalidRequest : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void lnkLogin_Click(object sender, EventArgs e)
        {
            Response.Redirect("IT_LoginPage.aspx", false);
        }
    }
}