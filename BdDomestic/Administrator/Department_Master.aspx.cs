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

public partial class Administrator_Department_Master : System.Web.UI.Page
{
    CDepartmentMaster obj = new CDepartmentMaster();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            
            gvDept.DataBind();
        }
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        if (btnAdd.Text == "Add New")
        {
            bool flag = false;
            obj.DeptName = txtDeptName.Text;
            flag = obj.Add_DeptMaster();
            if (flag == true)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "win", "<script>alert('Record Inserted Sucessfully !!')</script>");
                //lblMsg.Text = "Record Inserted Sucessfully !!";
                gvDept.DataBind();
                txtDeptName.Text = "";

            }
            else
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "win", "<script>alert('Error Occured While Inserting!! !!')</script>");
                //lblMsg.Text = "Error Occured While Inserting!!";
            }
        }
        else if (btnAdd.Text == "Update")
        {
            bool flag=false;
            flag = obj.UpdateDepartment(ViewState["DeptId"].ToString(), txtDeptName.Text);
            if (flag == true)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "win", "<script>alert('Record Updated Sucessfully!! !!')</script>");
                //lblMsg.Text = "Record Updated Sucessfully !!";
                gvDept.DataBind();
                txtDeptName.Text = "";
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "win", "<script>alert('Error Occured While Updating Record!!')</script>");
                //lblMsg.Text = "Error Occured While Updating Record!!";
            }

        }
    }
    protected void gvDept_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "ed")
        {
            lblMsg.Text = "";
            btnAdd.Text = "Update";
            string strDeptId = e.CommandArgument.ToString();
            ViewState["DeptId"] = e.CommandArgument.ToString();
            obj.SelectRecord(strDeptId);
            txtDeptName.Text = obj.DeptName;
        }
        if (e.CommandName == "del")
        {
            bool flag = false;
            string strDeptId = e.CommandArgument.ToString();
            flag = obj.DeleteDepartment(strDeptId);
           if (flag == true)
           {
               Page.ClientScript.RegisterStartupScript(this.GetType(), "win", "<script>alert('Record Deleted Sucessfully !!')</script>");
               //lblMsg.Text = "Record Deleted Sucessfully !!";
               gvDept.DataBind();
           }
           else
           {
               Page.ClientScript.RegisterStartupScript(this.GetType(), "win", "<script>alert('Error Occured While Deleting Record!!')</script>");
               //lblMsg.Text = "Error Occured While Deleting Record!!";
           }
  
        }
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("Department_Master.aspx");
    }
    protected void gvDept_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            ImageButton link1 = (ImageButton)e.Row.FindControl("ImgBtnDel");

            link1.Attributes.Add("onclick", "javascript:return " +
                          "confirm('Are you sure you want to delete this record')");
        }
    }
}
