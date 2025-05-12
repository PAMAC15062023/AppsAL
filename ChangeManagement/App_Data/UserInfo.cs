using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

/// <summary>
/// Summary description for UserInfo
/// </summary>
public class UserInfo
{
	public UserInfo()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public struct structUSERInfo
    {
        public string ID;
        public string UserName;
        public string UserID;
        public int RoleID;
        public string RoleName;
        public string Email;
        public string Branch_Hub_Id;
        public string Location_Id;
        public string Location_Name;
        public bool IsActive;
        public string CreatedDate;
        public string CreatedBy;
        public string ModifyDate;
        public string ModifyBy;
        public string Login_Date;
        public string Logout_Date;
        public string State;
        public string Branch;
        public string Location;
        public string PamacBranch;

        public string Program;


        public string Password;
        public string BranchName;
        public int BranchId;
        public string GroupName;
        public int GroupId;
        public string MasterFileCreatedDate;
        public string MasterLastUpdatedDate;
        public string PageAccessString;
        public string AuthorizeUSERID;
        public string AuthorizePassword;
        public int ActivityID;
        public string ActivityName;
        public string ClientName;
        public int ClientId;
    } 
}
