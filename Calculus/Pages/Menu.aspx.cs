using System;
using System.Data;
using System.Xml;
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

public partial class Pages_Menu : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            Object SaveUSERInfo = (Object)Session["UserInfo"];

            if (Session["UserInfo"] == null)
            {
                Response.Redirect("InvalidRequest.aspx", true);
            }
            else if (((UserInfo.structUSERInfo)(SaveUSERInfo)).AuthorizePassword == "0")
            {
                Response.Redirect("Change_Password.aspx?Err=Please Change your password!", true);
            }
            else
            {

                if (!IsPostBack)
                {
                    if (Convert.ToString(Session["isMFA_Valid"]) == "Yes")
                    {
                        Load_UserStatus();
                        string FileSavePath = this.Request.PhysicalApplicationPath + ConfigurationManager.AppSettings["MasterMenu"].ToString() + Convert.ToString(((UserInfo.structUSERInfo)(SaveUSERInfo)).GroupName) + ".xml";
                        FileInfo FFileName = new FileInfo(FileSavePath);
                        if (FFileName.Exists)
                        {
                            XmlDataSource1.DataFile = FileSavePath;
                            XmlDataSource1.DataBind();
                        }
                        else
                        {
                            Create_MenuStructure();
                        }
                    }
                    else
                    { 
                        Session.Clear();
                        Response.Redirect("~/pages/Logout.aspx", false);
                    }
                }
            }
        }
        catch
        {

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
        sqlCom.CommandText = "Get_MenuMaster_Userwise";


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
        GroupID.Value = Convert.ToInt32(((UserInfo.structUSERInfo)(SaveUSERInfo)).GroupId);
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

        //Download Hotfix from Microsoft for Resolving Issue on ISS server.
        //http://support.microsoft.com/hotfix/KBHotfix.aspx?kbnum=955594&kbln=en-us
        relation.Nested = true;
        ds.Relations.Add(relation);

        string FileSavePath = this.Request.PhysicalApplicationPath + ConfigurationSettings.AppSettings["MasterMenu"].ToString() + Convert.ToString(((UserInfo.structUSERInfo)(SaveUSERInfo)).GroupName + ".xml");

        FileInfo FFileName = new FileInfo(FileSavePath);
        if (FFileName.Exists)
        {
            File.Delete(FileSavePath);
        }

        ds.WriteXml(FileSavePath);

        XmlDataSource1.DataFile = FileSavePath;
        XmlDataSource1.DataBind();
        ds.Dispose();

    }
    private void Load_UserStatus()
    {
        try
        {
            if (Session["UserInfo"] == null)
            {
                Response.Redirect("InvalidRequest.aspx", false);
            }
            else
            {
                Object SaveUSERInfo = (Object)Session["UserInfo"];
                lblUserName.Text = Convert.ToString(((UserInfo.structUSERInfo)(SaveUSERInfo)).UserId);
                lblBranch.Text = Convert.ToString(((UserInfo.structUSERInfo)(SaveUSERInfo)).BranchName);
                lblRole.Text = Convert.ToString(((UserInfo.structUSERInfo)(SaveUSERInfo)).GroupName);
                lblMasterFileInfo.Text = Convert.ToString(((UserInfo.structUSERInfo)(SaveUSERInfo)).MasterLastUpdatedDate);
                lblClient.Text = Convert.ToString(((UserInfo.structUSERInfo)(SaveUSERInfo)).ClientName);
                DateTime DateLastAccessTime = Convert.ToDateTime(lblMasterFileInfo.Text.Trim());

                int intMonth = Convert.ToInt32(DateTime.Now.Month);




                lblMonth.Text = Get_MonthName(intMonth);
                lblDate.Text = DateTime.Now.Day.ToString();

                TimeSpan ts = DateTime.Now - DateLastAccessTime;
                if (Math.Round(ts.TotalHours) > 24)
                {
                    lblInfo.Visible = true;
                    lblMasterFileInfo.ForeColor = System.Drawing.Color.Red;
                    lblInfo.ToolTip = "DBF Files are 24Hours Old!";
                }

            }
        }
        catch (Exception ex)
        {

        }
    }
    private string Get_MonthName(int intMonth)
    {
        string Month = "";
        if (intMonth == 1)
        {
            Month = "Jan";
        }
        else if (intMonth == 2)
        {
            Month = "Feb";
        }
        else if (intMonth == 3)
        {
            Month = "Mar";
        }
        else if (intMonth == 4)
        {
            Month = "Apr";
        }
        else if (intMonth == 5)
        {
            Month = "May";
        }
        else if (intMonth == 6)
        {
            Month = "Jun";
        }
        else if (intMonth == 7)
        {
            Month = "Jul";
        }
        else if (intMonth == 8)
        {
            Month = "Aug";
        }
        else if (intMonth == 9)
        {
            Month = "Sep";
        }
        else if (intMonth == 10)
        {
            Month = "Oct";
        }
        else if (intMonth == 11)
        {
            Month = "Nov";
        }
        else if (intMonth == 12)
        {
            Month = "Dec";
        }


        return Month;
    }
}
