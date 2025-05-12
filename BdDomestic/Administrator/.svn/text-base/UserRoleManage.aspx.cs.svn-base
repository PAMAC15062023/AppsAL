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

public partial class UserRoleManage : System.Web.UI.Page
{
    CEmployeeMaster oEmp = new CEmployeeMaster();
    OleDbConnection connection;
    string connString;

    protected void Page_Load(object sender, EventArgs e)
    {
        //if (Session["isAdd"].ToString() != "1")
        //{
        //    Response.Redirect("NoAccess.aspx");
        //}
        lblMsg.Text = "";
        connString = ConfigurationManager.ConnectionStrings["CMConnectionString"].ToString();
        connection = new OleDbConnection(connString);
    }

    protected void Page_UnLoad(object sender, EventArgs e)
    {
        if (connection.State == ConnectionState.Open)
            connection.Close();
    }

    protected void ddlEmpName_DataBound(object sender, EventArgs e)
    {
        ddlEmpName.Items.Insert(0, new ListItem("--Select--", ""));
    }
    protected void btnAssign_Click(object sender, EventArgs e)
    {
        try
        {
            oEmp.RUserID = ddlEmpName.SelectedValue.ToString();

            if (oEmp.RUserID != null)
            {
                Boolean blnTF;
                oEmp.DeleteRole();
                foreach (GridViewRow row in gvRole.Rows)
                {
                    blnTF = ((CheckBox)row.FindControl("chkRole")).Checked;
                    oEmp.RoleID = (string)gvRole.DataKeys[row.RowIndex]["ROLE_ID"];
                    if (blnTF)
                    {
                        oEmp.AssignRole();
                    }
                }
                TreeNodeCollection checkedNodes = TreeView1.CheckedNodes;
                String str = "";
                int counter = 0;
                            
                while (counter < checkedNodes.Count)
                {                  
                  str += GetHierID(checkedNodes[counter].Value.Split(','))+",";
                  counter += 1;
                }
                if (str != "")
                {
                    oEmp.AssignHierarchy(ddlEmpName.SelectedValue, str.TrimEnd(','));
                }
                if (str != "")
                    lblMsg.Text = "Roles and hierarchy assigned successfully.";
                else
                    lblMsg.Text = "Roles assigned successfully. Please select hierarchy";
            }
            else
            {
                lblMsg.Text = "Select the employee to assign the role.";
            }
        }
        catch (Exception exp)
        {
            lblMsg.Text = "Error in role assignment." + exp.Message;
        }
    }
    protected void ddlEmpName_SelectedIndexChanged(object sender, EventArgs e)
    {
        TraverseTree();
        gvRole.DataBind();
        String strEmpCode = "";
        if (ddlEmpName.SelectedValue.ToString() != "")
        {
            oEmp.RUserID = ddlEmpName.SelectedValue.ToString();
            OleDbDataReader oDr1 = oEmp.GetEmpCode();
            if (oDr1.HasRows)
            {
                if (oDr1.Read())
                {
                    strEmpCode = oDr1["EMP_CODE"].ToString();
                }
            }
            oDr1.Close();
            OleDbDataReader oDr = oEmp.GetRole();
            String strRoleID = "";
            if (oDr.HasRows)
            {
                while (oDr.Read())
                {
                    foreach (GridViewRow row in gvRole.Rows)
                    {
                        strRoleID = oDr["ROLE_ID"].ToString();
                        if (strRoleID == (string)gvRole.DataKeys[row.RowIndex]["ROLE_ID"])
                        {
                            ((CheckBox)row.FindControl("chkRole")).Checked = true;
                        }
                    }
                }
            }
            oDr.Close();
        }

        lblEmpCode.Text = strEmpCode;
    }
    public void TraverseTree()
    {
        TreeView1.Nodes[0].ChildNodes.Clear();
        TreeNodeEventArgs e1 = new TreeNodeEventArgs(TreeView1.Nodes[0]);
        this.Node_Populate(TreeView1, e1);
    }
    protected void gvRole_Sorting(object sender, GridViewSortEventArgs e)
    {
        gvRole.DataBind();
    }

    protected void Node_Populate(object sender, System.Web.UI.WebControls.TreeNodeEventArgs e)
    {
        if (e.Node.ChildNodes.Count == 0)
        {
            switch (e.Node.Depth)
            {
                case 0:
                    Level1(e.Node);
                    break;
                case 1:
                    Level2(e.Node);
                    break;
                case 2:
                    Level3(e.Node);
                    break;
                case 3:
                    Level4(e.Node);
                    break;
            }
        }
    }

    void Level1(TreeNode node)
    {
        string ParentID = node.Value;
        String strSql = "";
        String strSql1 = "";
        DataSet ds;
            strSql = "SELECT DISTINCT CENTRE_ID, CENTRE_NAME FROM CE_AC_PR_CT_VW " +
                                       "WHERE CENTRE_ID IS NOT NULL";
        DataSet lvl4 = OleDbHelper.ExecuteDataset(connection, CommandType.Text, strSql);
             
        if (lvl4.Tables.Count > 0)
        {
            foreach (DataRow row in lvl4.Tables[0].Rows)
            {
                TreeNode newNode = new TreeNode(row["CENTRE_NAME"].ToString(), row["CENTRE_ID"].ToString()+ ",3");
                newNode.PopulateOnDemand = true;
                newNode.SelectAction = TreeNodeSelectAction.None;
                if (ddlEmpName.SelectedValue != "")
                {
                    strSql1 = "SELECT DISTINCT REF_ID FROM COMPANY_HIERARCHY_MASTER WHERE HIER_LEVEL=3 " +
                               " AND HIER_ID IN (SELECT HIER_ID FROM USER_HIERARCHY WHERE USER_ID='" + ddlEmpName.SelectedValue + "')";

                     ds = OleDbHelper.ExecuteDataset(connection, CommandType.Text, strSql1);
                    if (ds.Tables.Count > 0)
                    {
                        foreach (DataRow row1 in ds.Tables[0].Rows)
                        {
                            if (row["CENTRE_ID"].ToString() == row1["REF_ID"].ToString())
                                newNode.Checked = true;
                        }
                    }
                    ds.Clear();
                }
                newNode.Expanded = true;
                node.ChildNodes.Add(newNode);
                newNode.ShowCheckBox = true;
            }
        }
    }

    void Level2(TreeNode node)
    {
        String[] arr = new String[3];
        arr= node.Value.Split(',');
        string ParentID = arr[0].ToString();
        String strParents = node.Value;
        String strSql = "";
        String strSql1 = "";
        DataSet ds;
        strSql = "SELECT DISTINCT ACTIVITY_ID, ACTIVITY_NAME FROM CE_AC_PR_CT_VW " +
                 "WHERE (ACTIVITY_ID IS NOT NULL) AND (CENTRE_ID ='" + ParentID + "')";
        DataSet lvl5 = OleDbHelper.ExecuteDataset(connection, CommandType.Text, strSql);

        if (lvl5.Tables.Count > 0)
        {
            foreach (DataRow row in lvl5.Tables[0].Rows)
            {
                TreeNode newNode = new TreeNode(row["ACTIVITY_NAME"].ToString(), row["ACTIVITY_ID"].ToString() + ",4" + "," + strParents);
                newNode.PopulateOnDemand = true;
                newNode.SelectAction = TreeNodeSelectAction.None;
                if (ddlEmpName.SelectedValue != "")
                {
                    //strSql1 = "SELECT DISTINCT REF_ID FROM COMPANY_HIERARCHY_MASTER WHERE HIER_LEVEL=4 AND (PARENT_ID ='" + ParentID + "')" +
                    //           " AND HIER_ID IN (SELECT HIER_ID FROM USER_HIERARCHY WHERE USER_ID='" + ddlEmpName.SelectedValue + "')";

                    //ds = OleDbHelper.ExecuteDataset(connection, CommandType.Text, strSql1);
                    //if (ds.Tables.Count > 0)
                    //{
                    //    foreach (DataRow row1 in ds.Tables[0].Rows)
                    //    {
                            String strRefID = "";
                            strRefID = GetRefID(newNode.Value.Split(','), ddlEmpName.SelectedValue.ToString());

                            if (row["ACTIVITY_ID"].ToString() == strRefID)// row1["REF_ID"].ToString())
                                newNode.Checked = true;
                    //    }
                    //}
                    //ds.Clear();
                }
                newNode.Expanded = true;
                node.ChildNodes.Add(newNode);
                newNode.ShowCheckBox = true;
            }
        }
    }

    void Level3(TreeNode node)
    {

        String[] arr = new String[3];
        arr = node.Value.Split(',');
        string ParentID = arr[0].ToString();
        String strParents = node.Value;
        String strSql = "";
        String strSql1 = "";
        DataSet ds;
        strSql = "SELECT DISTINCT PRODUCT_ID, PRODUCT_NAME FROM CE_AC_PR_CT_VW " +
                 "WHERE (PRODUCT_ID IS NOT NULL) AND (ACTIVITY_ID ='" + ParentID + "')";
        DataSet lvl6 = OleDbHelper.ExecuteDataset(connection, CommandType.Text, strSql);

        if (lvl6.Tables.Count > 0)
        {
            foreach (DataRow row in lvl6.Tables[0].Rows)
            {
                TreeNode newNode = new TreeNode(row["PRODUCT_NAME"].ToString(), row["PRODUCT_ID"].ToString() + ",5" + "," + strParents);
                newNode.PopulateOnDemand = true;
                newNode.SelectAction = TreeNodeSelectAction.None;
                if (ddlEmpName.SelectedValue != "")
                {
                    //strSql1 = "SELECT DISTINCT REF_ID FROM COMPANY_HIERARCHY_MASTER WHERE HIER_LEVEL=5 AND (PARENT_ID ='" + ParentID + "')" +
                    //          " AND HIER_ID IN (SELECT HIER_ID FROM USER_HIERARCHY WHERE USER_ID='" + ddlEmpName.SelectedValue + "')";

                    //ds = OleDbHelper.ExecuteDataset(connection, CommandType.Text, strSql1);
                    //if (ds.Tables.Count > 0)
                    //{
                    //    foreach (DataRow row1 in ds.Tables[0].Rows)
                        //{
                            String strRefID = "";
                            strRefID = GetRefID(newNode.Value.Split(','), ddlEmpName.SelectedValue.ToString());

                            if (row["PRODUCT_ID"].ToString() == strRefID)//row1["REF_ID"].ToString())
                                newNode.Checked = true;
                    //    }
                    //}
                    //ds.Clear();
                }
                newNode.Expanded = true;
                node.ChildNodes.Add(newNode);
                newNode.ShowCheckBox = true;
            }
        }
    }

    void Level4(TreeNode node)
    {
        String[] arr = new String[3];
        arr = node.Value.Split(',');
        string ParentID = arr[0].ToString();
        String strParents = node.Value;
        String strSql = "";
        String strSql1 = "";
        DataSet ds;
        strSql = "SELECT DISTINCT CLIENT_ID, CLIENT_NAME FROM CE_AC_PR_CT_VW " +
                 "WHERE (CLIENT_ID IS NOT NULL) AND (PRODUCT_ID ='" + ParentID + "')";
        DataSet lvl7 = OleDbHelper.ExecuteDataset(connection, CommandType.Text, strSql);
       
        if (lvl7.Tables.Count > 0)
        {
            foreach (DataRow row in lvl7.Tables[0].Rows)
            {
                TreeNode newNode = new TreeNode(row["CLIENT_NAME"].ToString(), row["CLIENT_ID"].ToString() + ",6" + "," + strParents);
                newNode.PopulateOnDemand = false;
                newNode.SelectAction = TreeNodeSelectAction.None;
                if (ddlEmpName.SelectedValue != "")
                {
                    //strSql1 = "SELECT DISTINCT REF_ID FROM COMPANY_HIERARCHY_MASTER WHERE HIER_LEVEL=6 AND (PARENT_ID ='" + ParentID + "')" +
                    //          " AND HIER_ID IN (SELECT HIER_ID FROM USER_HIERARCHY WHERE USER_ID='" + ddlEmpName.SelectedValue + "')";

                    //ds = OleDbHelper.ExecuteDataset(connection, CommandType.Text, strSql1);
                    //if (ds.Tables.Count > 0)
                    //{
                    //    foreach (DataRow row1 in ds.Tables[0].Rows)
                    //    {
                    String strRefID = "";
                    strRefID = GetRefID(newNode.Value.Split(','), ddlEmpName.SelectedValue.ToString());

                    if (row["CLIENT_ID"].ToString() == strRefID)//row1["REF_ID"].ToString())
                                newNode.Checked = true;
                    //    }
                    //}
                    //ds.Clear();
                }
                newNode.Expanded = true;
                node.ChildNodes.Add(newNode);
                newNode.ShowCheckBox = true;
            }
        }
    }
    public String GetRefID(String[] arr, String UserID)
    {
        DataSet ds;
        String strSql = "";
        String str = "";
        int i = 0;
        int j = 0;
        strSql = "SELECT REF_ID FROM COMPANY_HIERARCHY_MASTER WHERE REF_ID ='" + arr[i].ToString() + "' AND HIER_LEVEL='" + arr[++i].ToString() + "'";
        strSql += " AND HIER_ID IN (SELECT HIER_ID FROM USER_HIERARCHY WHERE USER_ID='" + UserID + "')";
        while (i <= arr.Length - 2)
        {
            if (Convert.ToInt16(arr[i]) > 3)
            {
                strSql += " AND PARENT_ID IN (SELECT HIER_ID FROM COMPANY_HIERARCHY_MASTER WHERE REF_ID='" + arr[++i].ToString() + "' AND HIER_LEVEL='" + arr[++i].ToString() + "'";
                j++;
            }
        }
        while (j > 0)
        {
            strSql += ")";
            j--;
        }
        ds = OleDbHelper.ExecuteDataset(connection, CommandType.Text, strSql);
        if (ds.Tables.Count > 0)
        {
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                str = row["REF_ID"].ToString();
            }            
        }
        ds.Clear();
        return str;
    }
    public String GetHierID(String[] arr)
    {
        DataSet ds;
        String strSql = "";
        String str = "";
        int i = 0;
        int j = 0;
            strSql = "SELECT HIER_ID FROM COMPANY_HIERARCHY_MASTER WHERE REF_ID='" + arr[i].ToString() + "' AND HIER_LEVEL='" + arr[++i].ToString() + "'";
            while (i <= arr.Length-2)
            {
                if (Convert.ToInt16(arr[i]) > 3)
                {
                    strSql += " AND PARENT_ID IN (SELECT HIER_ID FROM COMPANY_HIERARCHY_MASTER WHERE REF_ID='" + arr[++i].ToString() + "' AND HIER_LEVEL='" + arr[++i].ToString() + "'";
                    j++;
                }
            }
            while (j > 0)
            {
                strSql += ")";
                j--;
            }
        ds = OleDbHelper.ExecuteDataset(connection, CommandType.Text, strSql);
        if (ds.Tables.Count > 0)
        {
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                str +=  row["HIER_ID"].ToString() + ",";
            }
        }
        ds.Clear();
        return str;
    }
}
