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

public partial class Pages_GroupRightsInfo : System.Web.UI.Page
{
  
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserInfo"] == null)
        {
            Response.Redirect("InvalidRequest.aspx", false);
        }
        if (!IsPostBack)
        {
            Create_MenuStructure();
             
            Get_GroupMaster();
        }
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Pages/Menu.aspx",true );
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {        
        if (ddlGroupInfo.SelectedIndex != 0)
        {
             

            Insert_MenuRights();
            Update_USER_RightsXML(Convert.ToInt32(ddlGroupInfo.SelectedItem.Value),ddlGroupInfo.SelectedItem.Text.Trim());
        }
        else
        {
            lblMessage.Text = "Please select Group to Continue..";
            lblMessage.CssClass = "ErrorMessage";
            lblMessage.Visible = true;  
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

        dt = ds.Tables[0].Copy();

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
        

    }
    private void Get_GroupMaster()
    {
        try
        {
            Object SaveUSERInfo = (Object)Session["UserInfo"];

            SqlConnection sqlCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);

            sqlCon.Open();
            SqlCommand sqlCom = new SqlCommand();
            sqlCom.Connection = sqlCon;
            sqlCom.CommandType = CommandType.StoredProcedure;
            sqlCom.CommandText = "AdminMaster_Get_GroupMaster_SP";

            SqlParameter BranchId = new SqlParameter();
            BranchId.SqlDbType = SqlDbType.Int;
            BranchId.Value = 0;//Convert.ToInt32(((UserInfo.structUSERInfo)(SaveUSERInfo)).BranchId);
            BranchId.ParameterName = "@BranchId";
            sqlCom.Parameters.Add(BranchId);

            SqlParameter IsActivate = new SqlParameter();
            IsActivate.SqlDbType = SqlDbType.Bit ;
            IsActivate.Value = true;
            IsActivate.ParameterName = "@IsActivate";
            sqlCom.Parameters.Add(IsActivate);

            SqlDataAdapter sqlDA = new SqlDataAdapter();
            sqlDA.SelectCommand = sqlCom;
            DataTable dt = new DataTable();
            sqlDA.Fill(dt);
            sqlCon.Close();

            ddlGroupInfo.DataTextField = "GroupName";
            ddlGroupInfo.DataValueField = "GroupId";
            
            ddlGroupInfo.DataSource = dt;
            ddlGroupInfo.DataBind();

            ddlGroupInfo.Items.Insert(0, "--Select--");
            ddlGroupInfo.SelectedIndex = 0;



        }
        catch (Exception ex)
        {
            lblMessage.Visible = true;
            lblMessage.Text = ex.Message;
            lblMessage.CssClass = "ErrorMessage";
        }
    }
    protected void ddlGroupInfo_SelectedIndexChanged(object sender, EventArgs e)
    {
             Unchecking_Nodes();         
            if (ddlGroupInfo.SelectedIndex != 0)
            {
                 GroupInfo_List();
            }
    }
    private void GroupInfo_List()
    {
        try
        {
           
                Object SaveUSERInfo = (Object)Session["UserInfo"];

                SqlConnection sqlCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);

                sqlCon.Open();
                SqlCommand sqlCom = new SqlCommand();
                sqlCom.Connection = sqlCon;
                sqlCom.CommandType = CommandType.StoredProcedure;
                sqlCom.CommandText = "AdminMaster_Get_GroupNameInfo_SP";


                SqlParameter GroupId = new SqlParameter();
                GroupId.SqlDbType = SqlDbType.Int;
                GroupId.Value = Convert.ToInt32(ddlGroupInfo.SelectedItem.Value);
                GroupId.ParameterName = "@GroupId";
                sqlCom.Parameters.Add(GroupId);

                SqlParameter BranchId = new SqlParameter();
                BranchId.SqlDbType = SqlDbType.Int;
                BranchId.Value = Convert.ToInt32(((UserInfo.structUSERInfo)(SaveUSERInfo)).BranchId);
                BranchId.ParameterName = "@BranchId";
                sqlCom.Parameters.Add(BranchId);

                SqlDataAdapter sqlDA = new SqlDataAdapter();
                sqlDA.SelectCommand = sqlCom;
                DataSet ds = new DataSet();
                sqlDA.Fill(ds);
                sqlDA.Dispose();
                sqlCon.Close();
                
                if (ds.Tables.Count>0)
                {
                //------------------------------Main Header----------------------------------
                ddlIsActivate.SelectedValue = ds.Tables[0].Rows[0]["IsActivate"].ToString();
                lblGroupDesc.Text = ds.Tables[0].Rows[0]["GroupDescription"].ToString();
                }

                if (ds.Tables.Count>1)
                {
                    Get_MenuRigts(ds.Tables[1]);
                }
            }

        
        catch (Exception ex)
        {
            lblMessage.Visible = true;
            lblMessage.Text = ex.Message;
            lblMessage.CssClass = "ErrorMessage";
        }
    }
    private void Get_MenuRigts(DataTable dt)
    {
        

        for (int i = 0; i <= dt.Rows.Count - 1; i++)
        {
            TreeNode Mnu = (TreeNode)MenuTreeView.FindNode(dt.Rows[i]["ValuePath"].ToString());

            if (Mnu != null)
            {
                if (Mnu.Value == dt.Rows[i]["MenuID"].ToString())
                {
                    Mnu.Checked =Convert.ToBoolean(dt.Rows[i]["IsActivate"].ToString());
                }

            }
             
            
        }    
    }
    private void Insert_MenuRights()
    {
        Object SaveUSERInfo = (Object)Session["UserInfo"];

        SqlConnection sqlCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);

        sqlCon.Open();
        SqlCommand sqlCom = new SqlCommand();
        sqlCom.Connection = sqlCon;
        sqlCom.CommandType = CommandType.StoredProcedure;
        sqlCom.CommandText = "AdminMaster_Insert_GroupRights_SP";

        SqlParameter BranchId = new SqlParameter();
        BranchId.SqlDbType = SqlDbType.Int;
        BranchId.Value = Convert.ToInt32(((UserInfo.structUSERInfo)(SaveUSERInfo)).BranchId);
        BranchId.ParameterName = "@BranchId";
        sqlCom.Parameters.Add(BranchId);


        SqlParameter GroupID = new SqlParameter();
        GroupID.SqlDbType = SqlDbType.Int;
        GroupID.Value =Convert.ToInt32(ddlGroupInfo.SelectedItem.Value);
        GroupID.ParameterName = "@GroupID";
        sqlCom.Parameters.Add(GroupID);


        SqlParameter GroupRightsDetails = new SqlParameter();
        GroupRightsDetails.SqlDbType = SqlDbType.VarChar ;
        GroupRightsDetails.Value = Get_MenuRightsDetails();
        GroupRightsDetails.ParameterName = "@GroupRightsDetails";
        sqlCom.Parameters.Add(GroupRightsDetails);

        SqlParameter RightsBy = new SqlParameter();
        RightsBy.SqlDbType = SqlDbType.VarChar ;
        RightsBy.Value = Convert.ToString (((UserInfo.structUSERInfo)(SaveUSERInfo)).UserId);
        RightsBy.ParameterName = "@RightsBy";
        sqlCom.Parameters.Add(RightsBy);

        int RowsCounts = 0;

        RowsCounts = sqlCom.ExecuteNonQuery();

        if( RowsCounts >0 )
        {
            lblMessage.Text="Update records successfully!";                
            lblMessage.CssClass="SuccessMessage";
            lblMessage.Visible=true;
        }
        else
        {
            lblMessage.Text = "";
            lblMessage.CssClass = "SuccessMessage";
            lblMessage.Visible = true;
        }
         


    }
    private string Get_MenuRightsDetails()
    {
        string ReturnValue = "";
        string ValuePath = "";

        for (int i = 0; i <= MenuTreeView.CheckedNodes.Count - 1; i++)
        {
             ValuePath = "";
            if (MenuTreeView.CheckedNodes[i].Checked == true)
            {
                 
                    ValuePath = MenuTreeView.CheckedNodes[i].ValuePath;
                    string[] valueArr = ValuePath.Split('/');
                    if (valueArr.Length  > 0)
                    {
                        for (int j = 0; j <= valueArr.Length - 1; j++)
                        {
                            ReturnValue = ReturnValue +  "1|" + valueArr[j] + "^";
                        }
                    }
                    else
                    {
                        ReturnValue = ReturnValue + "1|" + MenuTreeView.CheckedNodes[i].Value + "^";
                    }

            }        
        
        }
        return ReturnValue;
        
        

    }   
    private void Update_USER_RightsXML(int pGroupID,string pGroupName)
    {
        
    
        Object SaveUSERInfo = (Object)Session["UserInfo"];

        SqlConnection sqlCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);

        sqlCon.Open();
        SqlCommand sqlCom = new SqlCommand();
        sqlCom.Connection = sqlCon;
        sqlCom.CommandType = CommandType.StoredProcedure;
        sqlCom.CommandText = "AdminMaster_Get_MenuMaster_Userwise_SP";

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


        SqlParameter GroupID = new SqlParameter();
        GroupID.SqlDbType = SqlDbType.Int;
        GroupID.Value = pGroupID;
        GroupID.ParameterName = "@GroupID";
        sqlCom.Parameters.Add(GroupID);

        SqlDataAdapter sqlDA = new SqlDataAdapter();
        sqlDA.SelectCommand = sqlCom;

        DataSet ds = new DataSet();
        sqlDA.Fill(ds);
        sqlCon.Close();
        sqlDA.Dispose();

        ds.DataSetName = "Menus";
        ds.Tables[0].TableName = "Menu";
        DataRelation relation = new DataRelation("ParentChild", ds.Tables["Menu"].Columns["MenuID"], ds.Tables["Menu"].Columns["ParentID"], true);

        relation.Nested = true;
        ds.Relations.Add(relation);

        string FileSavePath = this.Request.PhysicalApplicationPath + ConfigurationSettings.AppSettings["MasterMenu"].ToString() + pGroupName + ".xml" ;

        FileInfo FFileName = new FileInfo(FileSavePath);
        if (FFileName.Exists)
        {
            File.Delete(FileSavePath);
        }
        ds.WriteXml(FileSavePath);
        ds.Dispose();

    }
    private void Unchecking_Nodes()

    {

        string[] MenuValuePath = new string[Convert.ToInt32(MenuTreeView.CheckedNodes.Count)];
        for (int i = 0; i <= MenuTreeView.CheckedNodes.Count - 1; i++)
        {
            MenuValuePath[i] = MenuTreeView.CheckedNodes[i].ValuePath;

        }

        for (int j = 0; j <= MenuValuePath.Length - 1; j++)
        {
            TreeNode Mnu = (TreeNode)MenuTreeView.FindNode(MenuValuePath[j].ToString());
            if (Mnu != null)
            {
                Mnu.Checked = false;
            }

        }
    
    }
}
 