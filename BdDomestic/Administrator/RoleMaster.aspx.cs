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

public partial class Admin_RoleMaster : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //if (Session["isView"].ToString() != "1")
        //    Response.Redirect("NoAccess.aspx");
    }
    protected void imgNew_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("RoleMasterManage.aspx?Mode=A&NID=0");
    }
    protected void gvRoleMaster_SelectedIndexChanged(object sender, EventArgs e)
    {
        Response.Redirect("RoleMasterManage.aspx?Mode=E&NID=" + gvRoleMaster.SelectedRow.Cells[0].Text.ToString());
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        sdsRoleMaster.SelectCommand = "SELECT [Role_Id], [Role_Name] FROM [Role_Master] where Role_Name like ('%" + txtEmpName.Text.Trim().Replace("'", "''") + "%') order by Role_Name ";
        gvRoleMaster.DataBind();
        if (gvRoleMaster.Rows.Count == 0)
            lblMsg.Text = "No record found!!!";
        else
            lblMsg.Text = "";
    }

    protected void gvRoleMaster_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        String strRole_ID = "";
        if (e.CommandName == "Edit")
        {
            strRole_ID = e.CommandArgument.ToString();
            if (strRole_ID != "")
            {
                Response.Redirect("RoleMasterManage.aspx?OperationId=" + Request.QueryString["OperationId"] + "&Mode=E&NID=" + strRole_ID );
            }
        }
    }
    protected void gvRoleMaster_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        /*
        LinkButton lb = (LinkButton)e.Row.FindControl("lnkEditEmp");
        if (Session["isEdit"].ToString() != "1")
        {
            lb.Attributes.Add("onclick", "javascript:return" +
                      " Access()");
        }
        */
    }
}
