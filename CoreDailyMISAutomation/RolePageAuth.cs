using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace YesBank
{
    public class RolePageAuth
    {
        bool result = false;

        List<string> RolePageMapping = new List<string>();
        public RolePageAuth()
        {
            //Pre Login Stage
            RolePageMapping.Add("MFEDL_Pre_LoginStage;1");
            RolePageMapping.Add("MFEDL_UploadFile;1");
            RolePageMapping.Add("MFEDL_Pre_TVR;1");
            RolePageMapping.Add("MFEDL_MenuPage;1");

            //Post Login Stage
            RolePageMapping.Add("MFEDL_Post_UploadFile;2");
            RolePageMapping.Add("MFEDL_Post_LoginAndMaker;2");
            RolePageMapping.Add("MFEDL_Post_MenuPage;2");
            RolePageMapping.Add("MFEDL_Post_UserHoldCases;2");

            //Supervisor
            RolePageMapping.Add("MFEDL_UserMaster;3");
            RolePageMapping.Add("MFEDL_BranchMaster;3");
            RolePageMapping.Add("MFEDL_CPCMaster;3");
            RolePageMapping.Add("MFEDL_UploadFile;3");
            RolePageMapping.Add("MFEDL_Post_UploadFile;3");
            RolePageMapping.Add("MFEDL_PreSupervisorPage;3");
            RolePageMapping.Add("MFEDL_PostSupervisorPage;3");
            RolePageMapping.Add("MFEDL_MIS;3");
            RolePageMapping.Add("MFEDL_DownLoadPDF;3");
            RolePageMapping.Add("MFEDL_GetCaseHistory;3");
            RolePageMapping.Add("MFEDL_SuperMenuPage;3");


            // Common 
            RolePageMapping.Add("ChangePassword;1");
            RolePageMapping.Add("ChangePassword;2");
            RolePageMapping.Add("ChangePassword;3");

            RolePageMapping.Add("MFEDL_InvalidRequest;1");
            RolePageMapping.Add("MFEDL_InvalidRequest;2");
            RolePageMapping.Add("MFEDL_InvalidRequest;3");
        }

        public bool CheckRolePageAuth(string RoleID, string PageName)
        {
            if (RolePageMapping.Contains(PageName + ";" + RoleID))
            {
                result = true;
            }

            return result;
        }

    }
}