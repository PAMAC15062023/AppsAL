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
using System.IO;

public partial class Pages_ChequeProcessing_ChequeUploadFILES : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserInfo"] == null)
        {
            Response.Redirect("~/Pages/InvalidRequest.aspx", false);
        }
    }
    protected void btnUpload_Click(object sender, EventArgs e)
    {
        try
        {
            UploadFiles_OnServer();
        }
        catch (Exception ex)
        {
            Display_Message(ex.Message, "Error");
        }

    }
    private void UploadFiles_OnServer()
    {
        try
        {
            
            UserInfo.structUSERInfo UserInfo = new UserInfo.structUSERInfo();
            Object SaveUSERInfo = (Object)Session["UserInfo"];
            String strBranchName =((UserInfo.structUSERInfo)(SaveUSERInfo)).BranchName.Trim()+"_" ;
 
            string fullSitePath = Convert.ToString(ConfigurationSettings.AppSettings["MasterDBFFiles"]);  
            fullSitePath = fullSitePath.Trim();
            string FileSavePath = "";

            string[] UploadFilesPath = new string[5];

            string FileName_ExcelUpload = Convert.ToString(FileUpload_ValidDBF.FileName.Trim());
            FileSavePath = fullSitePath + strBranchName + FileName_ExcelUpload;

            FileInfo FFileName_ValidDBF = new FileInfo(FileSavePath);
            if (FFileName_ValidDBF.Exists)
            {
                File.Delete(FileSavePath);
            }
            UploadFilesPath[0] = FileSavePath;
            FileUpload_ValidDBF.SaveAs(FileSavePath);
            //-------------------------------------------------------------------------------

            string FileName_InvalidDBF = Convert.ToString(FileUpload_InvalidDBF.FileName.Trim());
            FileSavePath = fullSitePath + strBranchName + FileName_InvalidDBF;

            FileInfo FFileName_InvalidDBF = new FileInfo(FileSavePath);
            if (FFileName_InvalidDBF.Exists)
            {
                File.Delete(FileSavePath);
            }
            UploadFilesPath[2] = FileSavePath;
            FileUpload_InvalidDBF.SaveAs(FileSavePath);

            //-------------------------------------------------------------------------------
            string FileName_OTH = Convert.ToString(FileUpload_OtherBankDBF.FileName.Trim());
            FileSavePath = fullSitePath + strBranchName + FileName_OTH;

            FileInfo FFileName_OTH = new FileInfo(FileSavePath);
            if (FFileName_OTH.Exists)
            {
                File.Delete(FileSavePath);
            }
            UploadFilesPath[1] = FileSavePath;
            FileUpload_OtherBankDBF.SaveAs(FileSavePath);

            //-------------------------------------------------------------------------------
           
            string FileName_Upcoutry = Convert.ToString(FileUpload_Upcoutry.FileName.Trim());
            FileSavePath = fullSitePath + strBranchName + FileName_Upcoutry;

            FileInfo FFileName_Upcoutry = new FileInfo(FileSavePath);
            if (FFileName_Upcoutry.Exists)
            {
                File.Delete(FileSavePath);
                 
            }
            UploadFilesPath[3] = FileSavePath;
            FileUpload_Upcoutry.SaveAs(FileSavePath);

            Session["UploadFilesPath"] = UploadFilesPath;

            
            //------------------------------------------------------------------------------
            string FileName_ReturnDBF = Convert.ToString(FileUpload_ReturnDBF.FileName.Trim());
            FileSavePath = fullSitePath + strBranchName + FileName_ReturnDBF;


            FileInfo FFileName_ReturnDBF = new FileInfo(FileSavePath);
            if (FFileName_ReturnDBF.Exists)
            {
                File.Delete(FileSavePath);

            }
            UploadFilesPath[4] = FileSavePath;
            FileUpload_ReturnDBF.SaveAs(FileSavePath);

            Session["UploadFilesPath"] = UploadFilesPath;

            //------------------------------------------------------------------------------

            UserInfo.BranchId = Convert.ToInt32(((UserInfo.structUSERInfo)(SaveUSERInfo)).BranchId);
            UserInfo.BranchName =Convert.ToString( ((UserInfo.structUSERInfo)(SaveUSERInfo)).BranchName);
            UserInfo.Password =Convert.ToString( ((UserInfo.structUSERInfo)(SaveUSERInfo)).Password);
            UserInfo.GroupId = Convert.ToInt32(((UserInfo.structUSERInfo)(SaveUSERInfo)).GroupId);
            UserInfo.GroupName = Convert.ToString(((UserInfo.structUSERInfo)(SaveUSERInfo)).GroupName);
            UserInfo.UserId =Convert.ToString(((UserInfo.structUSERInfo)(SaveUSERInfo)).UserId);
            UserInfo.MasterFileCreatedDate = Directory.GetCreationTime(FileSavePath).ToString(); ;
            UserInfo.MasterLastUpdatedDate = Directory.GetLastAccessTime(FileSavePath).ToString();
            UserInfo.PageAccessString = Convert.ToString(((UserInfo.structUSERInfo)(SaveUSERInfo)).PageAccessString);
            UserInfo.ActivityID = Convert.ToInt32(((UserInfo.structUSERInfo)(SaveUSERInfo)).ActivityID);
            UserInfo.ActivityName = Convert.ToString (((UserInfo.structUSERInfo)(SaveUSERInfo)).ActivityName);
            UserInfo.AuthorizePassword = Convert.ToString(((UserInfo.structUSERInfo)(SaveUSERInfo)).AuthorizePassword);
            UserInfo.AuthorizeUSERID = Convert.ToString(((UserInfo.structUSERInfo)(SaveUSERInfo)).AuthorizeUSERID);
            UserInfo.UserName = Convert.ToString(((UserInfo.structUSERInfo)(SaveUSERInfo)).UserName);
            Session["UserInfo"] = UserInfo;

            Display_Message("Masters Files Successfully Uploaded!", "Success");

        }
        catch (Exception ex)
        {
            Display_Message(ex.Message, "Error");
        }
    }
    private void Display_Message(string ErrorMessage, string MessageType)
    {
        try
        {
            if (MessageType == "Error")
            {
                lblMessage.Visible = true;
                lblMessage.Text = ErrorMessage.Trim();
                lblMessage.CssClass = "ErrorMessage";
            }
            else
            {
                lblMessage.Visible = true;
                lblMessage.Text = ErrorMessage.Trim();
                lblMessage.CssClass = "SuccessMessage";
            }


        }
        catch (Exception ex)
        {
            Display_Message(ex.Message, "Error");
        }

    }
    protected void btnClose_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Pages/Menu.aspx", false);
    
    }
}
