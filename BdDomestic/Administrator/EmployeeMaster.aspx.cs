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

public partial class EmployeeMaster : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session.Count<=0)
        {
            Response.Redirect("../Logout.aspx");
        }
        lblMsg.Text = "";  
        if (!IsPostBack)
        {
          txtEmpName.Text = "";            
        }
    }
    protected void btnNew_Click(object sender, EventArgs e)
    {
        Response.Redirect("EmployeeMasterManage.aspx?OperationId=" + Request.QueryString["OperationId"]);
    }
    protected void gvEmployeeView_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        String strEMP_ID = "";
        if (e.CommandName == "Edit")
        {
            //if (Session["isEdit"].ToString() == "1")
            //{
                strEMP_ID = e.CommandArgument.ToString();
                if (strEMP_ID != "")
                {
                    Response.Redirect("EmployeeMasterManage.aspx?OperationId=" + Request.QueryString["OperationId"] + "&EMP_ID=" + strEMP_ID);
                }
            //}
            //else
            //{
            //    lblMsg.Text = "Access denied!";
            //}
        }
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        String sSql = "SELECT A.EMP_ID AS EMP_ID, A.EMP_CODE AS EMP_CODE, A.FULLNAME AS FULLNAME, " +
                      "B.DEPARTMENT AS DEPARTMENT FROM [EMPLOYEE_MASTER] AS A INNER JOIN [DEPARTMENT_MASTER] " +
                      " AS B ON A.DEPARTMENT_ID = B.DEPT_ID WHERE 1=1 " +
                      " AND CENTRE_ID='" + Session["CentreId"].ToString() + "'";
        if (txtEmpName.Text != "")
        {
            sSql = sSql + " AND FULLNAME LIKE '%" + txtEmpName.Text.ToString().Trim().Replace("'","") + "%'";
        }
        if (ddlDept.SelectedValue != "")
        {
            sSql = sSql + " AND DEPARTMENT_ID = '" + ddlDept.SelectedValue.ToString().Trim().Replace("'", "") + "'";
        }
        //
        sSql += " ORDER BY FULLNAME ";

        SDSEmployee.SelectCommand = sSql;
        gvEmployeeView.DataBind();
        if (gvEmployeeView.Rows.Count == 0)
            lblMsg.Text = "No record found.";
    }
    protected void gvEmployeeView_PageIndexChanged(object sender, EventArgs e)
    {
        String sSql = "SELECT A.EMP_ID AS EMP_ID, A.EMP_CODE AS EMP_CODE, A.FULLNAME AS FULLNAME, B.DEPARTMENT AS DEPARTMENT FROM [EMPLOYEE_MASTER] AS A INNER JOIN [DEPARTMENT_MASTER] AS B ON A.DEPARTMENT_ID = B.DEPT_ID WHERE 1=1 ";
        sSql = sSql + " AND CENTRE_ID='" + Session["CentreId"].ToString() + "'";
        if (txtEmpName.Text != "")
        {
            sSql = sSql + " AND FULLNAME LIKE '%" + txtEmpName.Text.Trim().Replace("'", "") + "%'";
        }
        if (ddlDept.SelectedValue != "")
        {
            sSql = sSql + " AND DEPARTMENT_ID = '" + ddlDept.SelectedValue.ToString().Trim().Replace("'", "") + "'";
        }
        sSql += " ORDER BY FULLNAME ";

        SDSEmployee.SelectCommand = sSql;
        gvEmployeeView.DataBind();
        if (gvEmployeeView.Rows.Count == 0)
            lblMsg.Text = "No record found.";
    }
    protected void ddlDept_DataBound(object sender, EventArgs e)
    {
        ddlDept.Items.Insert(0, new ListItem("--Select--", ""));
    }
    protected void gvEmployeeView_Sorting(object sender, GridViewSortEventArgs e)
    {
        String sSql = "SELECT A.EMP_ID AS EMP_ID, A.EMP_CODE AS EMP_CODE, A.FULLNAME AS FULLNAME, B.DEPARTMENT AS DEPARTMENT FROM [EMPLOYEE_MASTER] AS A INNER JOIN [DEPARTMENT_MASTER] AS B ON A.DEPARTMENT_ID = B.DEPT_ID WHERE 1=1 ";
        sSql = sSql + " AND CENTRE_ID='" + Session["CentreId"].ToString() + "'";
        if (txtEmpName.Text != "")
        {
            sSql = sSql + " AND FULLNAME LIKE '%" + txtEmpName.Text.Trim().Replace("'", "") + "%'";
        }
        if (ddlDept.SelectedValue != "")
        {
            sSql = sSql + " AND DEPARTMENT_ID = '" + ddlDept.SelectedValue.ToString().Trim().Replace("'", "") + "'";
        }


        SDSEmployee.SelectCommand = sSql;
        gvEmployeeView.DataBind();
        if (gvEmployeeView.Rows.Count == 0)
            lblMsg.Text = "No record found.";
    }
    protected void gvEmployeeView_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            LinkButton l = (LinkButton)e.Row.FindControl("lnkEditEmp");
            
            //if (Session["isEdit"].ToString() != "1")
            //{
            //    l.Attributes.Add("onclick", "javascript:return " +
            //         "Access()");
            //}
        }
    }
}
