//using System;
//using System.Data;
//using System.Configuration;
//using System.Web;
//using System.Web.Security;
//using System.Web.UI;
//using System.Web.UI.WebControls;
//using System.Web.UI.WebControls.WebParts;
//using System.Web.UI.HtmlControls;

///// <summary>
///// Summary description for UserInfo
///// </summary>
//public class UserInfo
//{
//	public UserInfo()
//	{
//		//
//		// TODO: Add constructor logic here
//		//
//	}
//    public struct structUSERInfo
//    {
//        public string UserId;
//        public string UserName;
//        public string LoginName;
//        public int RoleId;
//        public string RoleName;
//        public string LoanType;
//        public string Branch_Hub_Id;
//        public string Location_Id;
//        public string Location_Name;

//        public string Password;
//        public string BranchName;
//        public int BranchId;
//        public string GroupName;
//        public int GroupId;
//        public string MasterFileCreatedDate;
//        public string MasterLastUpdatedDate;
//        public string PageAccessString;
//        public string AuthorizeUSERID;
//        public string AuthorizePassword;
//        public int ActivityID;
//        public string ActivityName;
//        public string ClientName;
//        public int ClientId;
//    }
//}


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
        public string ClientID;
        public string UserName;
        public string LoginName;
        public int RoleId;
        public string RoleName;
        public string LoanType;
        public string Branch_Hub_Id;
        public string Location_Id;
        public string Location_Name;

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
