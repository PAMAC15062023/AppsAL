using ChangeManagement;
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
            // Login Stage
            
            //RolePageMapping.Add("FEDBANK_Login;1");
            RolePageMapping.Add("CM_CR-Initiation;1");
            
            
            //RolePageMapping.Add("YBL_LoginStageHomePage;1");

            //RolePageMapping.Add("YBL_LoginStage;6");
            //RolePageMapping.Add("YBL_UploadFile;6");
            //RolePageMapping.Add("YBL_LoginStageHomePage;6");

            // DDE Stage
            RolePageMapping.Add("CM_VH_Approval;2");
            //RolePageMapping.Add("FEDBank_DDE_Stage;6");

            //CAM Stage
            RolePageMapping.Add("CM_Reviewer_Approval;3");

            //QC Stage
            RolePageMapping.Add("CM_Development_Activities;4");

            //OrderDetails
            RolePageMapping.Add("CM_PM_Approval;5");

            //Supervisor
            RolePageMapping.Add("CM_UserMaster;6");
            
            
            


            //RolePageMapping.Add("YBL_UploadFile;5");


            // Common 
            RolePageMapping.Add("CM_Error;1");
            RolePageMapping.Add("CM_Error;2");
            RolePageMapping.Add("CM_Error;3");
            RolePageMapping.Add("CM_Error;4");
            RolePageMapping.Add("CM_Error;5");
            RolePageMapping.Add("CM_Error;6");

            RolePageMapping.Add("CM_ChangePassword;1");
            RolePageMapping.Add("CM_ChangePassword;2");
            RolePageMapping.Add("CM_ChangePassword;3");
            RolePageMapping.Add("CM_ChangePassword;4");
            RolePageMapping.Add("CM_ChangePassword;5");
            RolePageMapping.Add("CM_ChangePassword;6");


            RolePageMapping.Add("CM_MIS_Report;1");
            RolePageMapping.Add("CM_MIS_Report;2");
            RolePageMapping.Add("CM_MIS_Report;3");
            RolePageMapping.Add("CM_MIS_Report;4");
            RolePageMapping.Add("CM_MIS_Report;5");
            RolePageMapping.Add("CM_MIS_Report;6");

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