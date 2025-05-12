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

public partial class RoleMasterManage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //lblMsg.Text = "";
        //if (Session["isEdit"].ToString() != "1")
        //    Response.Redirect("NoAccess.aspx");

        if (!IsPostBack)
        {
            try
            {
                String strRoleId = Request.QueryString["NID"].ToString();
                sdsRoleOperation.SelectParameters.Add("RoleId", strRoleId);
                CRoleOperation objRole = new CRoleOperation(strRoleId);
                txtRoleName.Text = objRole.GerRoleName();
                btnSave.Visible = false;
                btnSave1.Visible = false;
            }
            catch (Exception exp)
            {
                lblMsg.Text = exp.Message;
            }
        }
    }
    protected void gvRoleOperation_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            CheckBox chkAdd = (CheckBox)e.Row.FindControl("chkIsAdd");
            CheckBox chkEdit = (CheckBox)e.Row.FindControl("chkIsEdit");
            CheckBox chkDelete = (CheckBox)e.Row.FindControl("chkIsDelete");
            CheckBox chkView = (CheckBox)e.Row.FindControl("chkIsView");
            HiddenField hidAdd = (HiddenField)e.Row.FindControl("hidAdd");
            HiddenField hidEdit = (HiddenField)e.Row.FindControl("hidEdit");
            HiddenField hidDelete = (HiddenField)e.Row.FindControl("hidDelete");
            HiddenField hidView = (HiddenField)e.Row.FindControl("hidView");
            if (hidAdd.Value == "1")
                chkAdd.Checked = true;
            else if (hidAdd.Value == "0")
                chkAdd.Checked = false;

            if (hidEdit.Value == "1")
                chkEdit.Checked = true;
            else if (hidEdit.Value == "0")
                chkEdit.Checked = false;

            if (hidDelete.Value == "1")
                chkDelete.Checked = true;
            else if (hidDelete.Value == "0")
                chkDelete.Checked = false;

            if (hidView.Value == "1")
                chkView.Checked = true;
            else if (hidView.Value == "0")
                chkView.Checked = false;
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            ArrayList Role = new ArrayList();
            foreach (GridViewRow row in gvRoleOperation.Rows)
            {
                ArrayList Operations = new ArrayList();
                HiddenField hidOperationId = (HiddenField)row.FindControl("hidOperationId");
                CheckBox chkAdd = (CheckBox)row.FindControl("chkIsAdd");
                CheckBox chkEdit = (CheckBox)row.FindControl("chkIsEdit");
                CheckBox chkDelete = (CheckBox)row.FindControl("chkIsDelete");
                CheckBox chkView = (CheckBox)row.FindControl("chkIsView");

                if (chkAdd.Checked || chkEdit.Checked || chkDelete.Checked || chkView.Checked)
                {
                    Operations.Add(hidOperationId.Value);

                    if (chkAdd.Checked)
                        Operations.Add("1");
                    else
                        Operations.Add("0");

                    if (chkEdit.Checked)
                        Operations.Add("1");
                    else
                        Operations.Add("0");

                    if (chkDelete.Checked)
                        Operations.Add("1");
                    else
                        Operations.Add("0");

                    if (chkView.Checked)
                        Operations.Add("1");
                    else
                        Operations.Add("0");

                    Role.Add(Operations);
                }

            }
            String strRoleId = Request.QueryString["NID"].ToString();
            CRoleOperation objOperation = new CRoleOperation(strRoleId);
            objOperation.RolePermissions = Role;
            objOperation.ProductId = ddlProduct.SelectedValue;
            lblMsg.Text=objOperation.SetPermission();
        }
        catch (Exception exp)
        {
            lblMsg.Text = exp.Message;
        }
    }
    protected void ddlProduct_DataBound(object sender, EventArgs e)
    {
        ddlProduct.Items.Insert(0, new ListItem("--Select--", ""));
    }
    protected void ddlProduct_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            String strMode = Request.QueryString["Mode"].ToString();
            String strRoleId = Request.QueryString["NID"].ToString();
            String strProductID = ddlProduct.SelectedValue.ToString();

            if (strMode == "A")
            {
                lblMode.Text = "[Add]";
                sdsRoleOperation.SelectCommand = "select [Operation_id],[operation_name], [operation_name] as isAdd, [operation_name] as isEdit, [operation_name] as isDelete, [operation_name] as isView from Operation_master WHERE PRODUCT_ID='" + strProductID + "' and Display_Order<>0";
                btnSave.Visible = true;
                btnSave1.Visible = true;
            }
            else
            {
                lblMode.Text = "[Edit]";
                sdsRoleOperation.SelectCommand = "SELECT OM.OPERATION_NAME, OM.OPERATION_ID, RO.ISADD, RO.ISEDIT, RO.ISDELETE, RO.ISVIEW FROM OPERATION_MASTER as OM LEFT OUTER JOIN ROLE_OPERATION as RO ON OM.OPERATION_ID = RO.OPERATION_ID and Role_Id=? WHERE OM.PRODUCT_ID='" + strProductID + "' and Display_Order<>0 order by OM.OPERATION_NAME";
                btnSave.Visible = true;
                btnSave1.Visible = true;
                //sdsRoleOperation.SelectParameters.Add("RoleId", strRoleId);
                //CRoleOperation objRole = new CRoleOperation(strRoleId);
                //txtRoleName.Text = objRole.GerRoleName();
                //if (strRoleId != "0")
                //{
                //    //txtRoleName.Text = sdsRoleOperation.SelectParameters[1].DefaultValue;
                //}
            }
        }
        catch (Exception exp)
        {
            lblMsg.Text = exp.Message;
        }
    }
}
