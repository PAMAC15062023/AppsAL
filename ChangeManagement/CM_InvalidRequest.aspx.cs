using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Configuration;
using System.Data;

namespace ChangeManagement
{
    public partial class CM_InvalidRequest : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void lnkLogin_Click(object sender, EventArgs e)
        {
            Response.Redirect("CM_Login.aspx", false);
        }
    }
}