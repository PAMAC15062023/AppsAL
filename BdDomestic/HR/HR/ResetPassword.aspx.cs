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

public partial class HR_HR_ResetPassword : System.Web.UI.Page
{
    CResetPassword objReset = new CResetPassword();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindGrid();
        }
    }
    public void BindGrid()
    {
        DataSet ds = new DataSet();
        ds = objReset.GetRecords();
        GvResetPassword.DataSource = ds;
        GvResetPassword.DataBind();
    }
    protected void BtnSave_Click(object sender, EventArgs e)
    {
        if (GvResetPassword.Rows.Count > 0)
        {
            string strPassword;
            int Uid;
            int Chkcount = 0;
            foreach (GridViewRow row in GvResetPassword.Rows)
            {
                CheckBox Chk = (CheckBox)(row.FindControl("chkSelect"));
                HiddenField EmpID = (HiddenField)(row.FindControl("HdnEmpId"));
                HiddenField EmpCode = (HiddenField)(row.FindControl("HdnEmpcode"));
                HiddenField DOL = (HiddenField)(row.FindControl("HdnDOL"));
                if (Chk.Checked == true)
                {
                    
                    strPassword = Convert.ToString(EmpCode.Value.ToString() + Convert.ToString(Convert.ToDateTime(DOL.Value.ToString()).ToString("dd/MM/yyyy")));
                    DataSet ds = new DataSet();
                    int Count = objReset.UpdatePassword(strPassword, EmpID.Value.ToString().Trim());
                    if (Count > 0)
                    {
                        lblMsg.Text = "Password Reset Successfully";
                    }
                    Chkcount = Chkcount + 1;
                }
            }
            if (Chkcount == 0)
            {
                lblMsg.Text = "Please select atleast one Employee to Reset the Password";
            }
            else
            {
                BindGrid();
            }
        }
        else
        {
            lblMsg.Text = "No Record Exist!";
        }
    }
    
    public SortDirection GridViewSortDirection //This will return Asc or Desc
    {
        get
        {
            if (ViewState["sortDirection"] == null)
                ViewState["sortDirection"] = SortDirection.Ascending;
            return (SortDirection)ViewState["sortDirection"];
        }
        set { ViewState["sortDirection"] = value; }
    }
    protected void GvResetPassword_Sorting(object sender, GridViewSortEventArgs e)
    {
        DataSet ds = new DataSet();
        ds = objReset.GetRecords();

        DataView dv = new DataView(ds.Tables[0]);
        //This will return the column Name on which you want to sort records
        string sortExpression = e.SortExpression;

        if (GridViewSortDirection == SortDirection.Ascending)
        {
            GridViewSortDirection = SortDirection.Descending;
            dv.Sort = sortExpression + " " + "ASC";
        }

        else
        {
            GridViewSortDirection = SortDirection.Ascending;
            dv.Sort = sortExpression + " " + "DESC";
        }

        GvResetPassword.DataSource = dv;
        GvResetPassword.DataBind();
    }
    protected void GvResetPassword_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GvResetPassword.PageIndex = e.NewPageIndex;
        BindGrid();
    }
    protected void GvResetPassword_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        Cache["RecCount"] = GvResetPassword.Rows.Count;
    }
}
