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

public partial class BD_ViewConfirmContract : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string UserId = Session["UserId"].ToString();
        if ("101103557" == UserId || "101103553" == UserId || "101103550" == UserId || "101103549" == UserId || "101103551" == UserId || "101103552" == UserId || "101103556" == UserId || "101103555" == UserId || "101103554" == UserId)
        {
            gvConfirmContract.Visible = false;
            lblMsg.Text = "U are not authorised ";
        }
    }
    protected void gvConfirmContract_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        String strCont_ID = "";
        if (e.CommandName == "EnterCotractDetail")
        {
            strCont_ID = e.CommandArgument.ToString();
            if (strCont_ID != "")
            {
                Response.Redirect("ContractDetail.aspx?Mode=A&NID=" + strCont_ID);
            }
        }
    }
}
