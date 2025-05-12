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
using System.Data.OleDb;

public partial class QueryBuilder_Default : System.Web.UI.Page
{
    protected void Page_Init(object sender, EventArgs e)
    {
        if (Session.Count == 0)
            Response.Redirect("../../Default.aspx?Message='Session expires. Please login again.'");
    }
    protected void Page_Load(object sender, EventArgs e)
    {

    }
}
