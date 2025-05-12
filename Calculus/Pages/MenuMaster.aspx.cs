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
using System.Data.SqlClient;
using System.IO;

public partial class Pages_MenuMaster : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (Session["UserInfo"] == null)
            {
                Response.Redirect("InvalidRequest.aspx", false);
            }
            else if (!IsPostBack)
            {
                Create_MenuStructure();
                Get_BranchList();
                Register_Control_Javascript();
                string StrScript = "<script language='javascript'> javascript:Page_Load_Validation(); </script>";
                Page.RegisterStartupScript("OnLoad_Validate", StrScript);

            }
        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
            lblMessage.Visible = true;
            lblMessage.CssClass = "ErrorMessage"; 
        }
    }
    private void Create_MenuStructure()
    {

        Object SaveUSERInfo = (Object)Session["UserInfo"];

        SqlConnection sqlCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);

        sqlCon.Open();
        SqlCommand sqlCom = new SqlCommand();
        sqlCom.Connection = sqlCon;
        sqlCom.CommandType = CommandType.StoredProcedure;
        sqlCom.CommandText = "AdminMaster_GetMenuMaster_SP";

        SqlParameter BranchId = new SqlParameter();
        BranchId.SqlDbType = SqlDbType.Int;
        BranchId.Value = Convert.ToInt32(((UserInfo.structUSERInfo)(SaveUSERInfo)).BranchId);
        BranchId.ParameterName = "@BranchId";
        sqlCom.Parameters.Add(BranchId);

        SqlParameter IsActivate = new SqlParameter();
        IsActivate.SqlDbType = SqlDbType.Bit;
        IsActivate.Value = true;
        IsActivate.ParameterName = "@IsActivate";
        sqlCom.Parameters.Add(IsActivate);

        SqlDataAdapter sqlDA = new SqlDataAdapter();
        sqlDA.SelectCommand = sqlCom;

        DataSet ds = new DataSet();
        DataTable dt = new DataTable(); 

        sqlDA.Fill(ds);
        sqlCon.Close();
        sqlDA.Dispose();

        dt=ds.Tables[0].Copy();

        ds.DataSetName = "Menus";
        ds.Tables[0].TableName = "Menu";
        DataRelation relation = new DataRelation("ParentChild", ds.Tables["Menu"].Columns["MenuID"], ds.Tables["Menu"].Columns["ParentID"], true);

        //Download Hotfix from Microsoft for Resolving Issue on ISS server for Data Relation Error.
        //http://support.microsoft.com/hotfix/KBHotfix.aspx?kbnum=955594&kbln=en-us
        relation.Nested = true;
        ds.Relations.Add(relation);

        string FileSavePath = this.Request.PhysicalApplicationPath + ConfigurationSettings.AppSettings["MasterMenu_Master"].ToString();
         
        FileInfo FFileName = new FileInfo(FileSavePath);
        if (FFileName.Exists)
        {
            File.Delete(FileSavePath);
        }
        ds.WriteXml(FileSavePath);
    
        XmlDataSource1.DataFile = FileSavePath;
        XmlDataSource1.DataBind();
        Get_ParentList(dt);

    }
    private void Get_BranchList()
    {
        try
        {

            SqlConnection sqlCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);

            sqlCon.Open();
            SqlCommand sqlCom = new SqlCommand();
            sqlCom.Connection = sqlCon;
            sqlCom.CommandType = CommandType.StoredProcedure;
            sqlCom.CommandText = "Get_AllBranchList";
            SqlDataAdapter sqlDA = new SqlDataAdapter();
            sqlDA.SelectCommand = sqlCom;
            DataTable dt = new DataTable();
            sqlDA.Fill(dt);
            sqlCon.Close();

            ddlBranchList.DataTextField = "BranchName";
            ddlBranchList.DataValueField = "BranchId";
            ddlBranchList.DataSource = dt;
            ddlBranchList.DataBind();

            ddlBranchList.Items.Insert(0, "--Select--");
            ddlBranchList.SelectedIndex = 0;



        }
        catch (Exception ex)
        {
            lblMessage.Visible = true;
            lblMessage.Text = ex.Message;
            lblMessage.CssClass = "ErrorMessage";
        }
    }
    private void Get_ParentList(DataTable dt)
    {


        ddlParentList.DataTextField = "Text";
        ddlParentList.DataValueField = "MenuId";
        ddlParentList.DataSource = dt;
        ddlParentList.DataBind();

        ddlParentList.Items.Insert(0, "--Select--");
        ddlParentList.SelectedIndex = 0;

    }
    private void Register_Control_Javascript()
    {
        ddlIsHeader.Attributes.Add("onchange", "javascript:EnableDisableParentListControl();");
        btnAddNew.Attributes.Add("onclick", "javascript:return ValidateAddNew();");
        btnDelete.Attributes.Add("onclick", "javascript:return ValidateDeleteMenuFromList();");
    }
    protected void MenuTreeView_SelectedNodeChanged(object sender, EventArgs e)
    {
        int MenuId = Convert.ToInt32(((System.Web.UI.WebControls.TreeView)(sender)).SelectedNode.Value);
        string MenuPath=Convert.ToString(((System.Web.UI.WebControls.TreeView)(sender)).SelectedNode.ValuePath);
        Get_MenuInfo(MenuId,MenuPath);
    }
    private void Get_MenuInfo(int pMenuID,string pMenuPath)
    {
        Object SaveUSERInfo = (Object)Session["UserInfo"];

        SqlConnection sqlCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);

        sqlCon.Open();
        SqlCommand sqlCom = new SqlCommand();
        sqlCom.Connection = sqlCon;
        sqlCom.CommandType = CommandType.StoredProcedure;
        sqlCom.CommandText = "AdminMaster_Get_MenuInfo_SP";
 
        SqlParameter BranchId = new SqlParameter();
        BranchId.SqlDbType = SqlDbType.Int;
        BranchId.Value =Convert.ToInt32(((UserInfo.structUSERInfo)(SaveUSERInfo)).BranchId);
        BranchId.ParameterName = "@BranchId";
        sqlCom.Parameters.Add(BranchId);

        SqlParameter MenuID = new SqlParameter();
        MenuID.SqlDbType = SqlDbType.Int;
        MenuID.Value = pMenuID;
        MenuID.ParameterName = "@MenuID";
        sqlCom.Parameters.Add(MenuID);
 

        SqlDataAdapter sqlDA = new SqlDataAdapter();
        sqlDA.SelectCommand = sqlCom;
        DataTable dt = new DataTable();
        sqlDA.Fill(dt);
        sqlDA.Dispose();
        sqlCon.Close();

        txtDisplayName.Text = dt.Rows[0]["DisplayName"].ToString();
        txtPosition.Text = dt.Rows[0]["Position"].ToString();
        txtPagePath.Text = dt.Rows[0]["PagePath"].ToString();
        hdnMenuID.Value = dt.Rows[0]["MenuID"].ToString();

        if (dt.Rows[0]["MenuPath"].ToString() != "0")
        {
            hdnMenuPath.Value = dt.Rows[0]["MenuPath"].ToString();
        }
        else
        { 
            hdnMenuPath.Value=pMenuPath;
        }

        if (dt.Rows[0]["IsHeader"].ToString() == "False")
        {
            ddlIsHeader.SelectedValue = "False";
            //ddlParentList.SelectedValue = dt.Rows[0]["ParentId"].ToString();
        }
        else
        {
            ddlIsHeader.SelectedValue = "True";
            //ddlParentList.SelectedIndex = 0;
        }
        string ParentID = "";
        ParentID= dt.Rows[0]["ParentId"].ToString();

        if (ParentID != "")
        {
            ddlParentList.SelectedValue = ParentID;
        }
        else
        {
            ddlParentList.SelectedIndex=0;
        }
            ddlIsActivate.SelectedValue = dt.Rows[0]["IsActive"].ToString();
            ddlBranchList.SelectedValue = dt.Rows[0]["BranchID"].ToString();
         
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        Insert_MenuMaster();
    }
    public void Insert_MenuMaster()
    {
        try
        {
            Object SaveUSERInfo = (Object)Session["UserInfo"];

            SqlConnection sqlCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);
            sqlCon.Open();
            SqlCommand sqlCom = new SqlCommand();
            sqlCom.Connection = sqlCon;
            sqlCom.CommandType = CommandType.StoredProcedure;
            sqlCom.CommandText = "AdminMaster_Insert_MenuMaster_SP";
 
            SqlParameter MenuID = new SqlParameter();
            MenuID.SqlDbType = SqlDbType.Int;
            MenuID.Value = hdnMenuID.Value;
            MenuID.ParameterName = "@MenuID";
            sqlCom.Parameters.Add(MenuID);

            SqlParameter IsHeader = new SqlParameter();
            IsHeader.SqlDbType = SqlDbType.Bit;
            IsHeader.Value =Convert.ToBoolean(ddlIsHeader.SelectedItem.Value);
            IsHeader.ParameterName = "@IsHeader";
            sqlCom.Parameters.Add(IsHeader);

            SqlParameter IsActive = new SqlParameter();
            IsActive.SqlDbType = SqlDbType.Bit;
            IsActive.Value = Convert.ToBoolean(ddlIsActivate.SelectedItem.Value);
            IsActive.ParameterName = "@IsActive";
            sqlCom.Parameters.Add(IsActive);

            SqlParameter PagePath = new SqlParameter();
            PagePath.SqlDbType = SqlDbType.VarChar;
            PagePath.Value = txtPagePath.Text.Trim();
            PagePath.ParameterName = "@PagePath";
            sqlCom.Parameters.Add(PagePath);

            SqlParameter DisplayName = new SqlParameter();
            DisplayName.SqlDbType = SqlDbType.VarChar;
            DisplayName.Value = txtDisplayName.Text.Trim();
            DisplayName.ParameterName = "@DisplayName";
            sqlCom.Parameters.Add(DisplayName);

            SqlParameter ValuePath = new SqlParameter();
            ValuePath.SqlDbType = SqlDbType.VarChar;
            ValuePath.Value =hdnMenuPath.Value.Trim();
            ValuePath.ParameterName = "@ValuePath";
            sqlCom.Parameters.Add(ValuePath);
  

            SqlParameter ParentId = new SqlParameter();
            ParentId.SqlDbType = SqlDbType.Int;
        
            if (ddlParentList.SelectedIndex == 0)
            {
                ParentId.Value = 0;
              }
            else
            {
               
                ParentId.Value = Convert.ToInt32(ddlParentList.SelectedItem.Value);
          
            }
            ParentId.ParameterName = "@ParentId";
            sqlCom.Parameters.Add(ParentId);


            SqlParameter Position = new SqlParameter();
            Position.SqlDbType = SqlDbType.Int;
            Position.Value =Convert.ToInt32(txtPosition.Text) ;
            Position.ParameterName = "@Position";
            sqlCom.Parameters.Add(Position);

            int RecordUpdated = 0;

            RecordUpdated = sqlCom.ExecuteNonQuery();           
            sqlCon.Close();

            if (RecordUpdated > 0)
            {
                lblMessage.Text = "Record Updated Sucessfully!!!!";
                lblMessage.Visible = true;
                lblMessage.CssClass = "UpdateMessage";
                
            }
            Clear_Controls();
            Create_MenuStructure();

        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
            lblMessage.Visible = true;
            lblMessage.CssClass = "ErrorMessage";
        }    
    }
    private void Clear_Controls()
    {
        txtDisplayName.Text = "";
        txtPagePath.Text = "";
        txtPosition.Text = "";
        hdnMenuID.Value = "0";
        hdnMenuPath.Value = "";
        ddlParentList.SelectedIndex = 0;
        ddlIsActivate.SelectedIndex = 0;
        ddlIsHeader.SelectedIndex = 1;
        ddlBranchList.SelectedIndex = 0;
         
 
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("Menu.aspx", false);
    }
}

