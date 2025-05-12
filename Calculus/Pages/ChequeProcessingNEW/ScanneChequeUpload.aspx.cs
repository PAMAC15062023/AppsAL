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

public partial class Pages_ChequeProcessingNEW_ScanneChequeUpload : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserInfo"] == null)
        {
            Response.Redirect("~/Pages/InvalidRequest.aspx");

        }
        if (!IsPostBack)
        {
            GET_Header_Values();
            Register_ControlsWith_JavaScript();
        }


        string StrScript = "<script language='javascript'> javascript:addFileUploadBox(); </script>";
        Page.RegisterStartupScript("OnLoad_21", StrScript);
    }
    private void Register_ControlsWith_JavaScript()
    {
       //btnUploadControls.Attributes.Add("onclick","javascript:return addFileUploadBox();");
        //ddlDropBoxList.Attributes.Add("onchange", "javascript:Get_DropBoxDetails();");
    }
    private void GET_Header_Values()
    { 
    
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        Upload_onServer();
    }
    private void Upload_onServer()
    {
        String ImageUploadPath;
        ImageUploadPath = Convert.ToString(ConfigurationSettings.AppSettings[@"ChequeImageUploadPath"]);

        string strBatchNo = hdnBatchNo.Value;
        strBatchNo = strBatchNo.Replace(@"\", "_");
        ImageUploadPath = ImageUploadPath + @"\" + strBatchNo;

        if (!Directory.Exists(ImageUploadPath))
        {
            Directory.CreateDirectory(ImageUploadPath + @"\");
        }

        HttpFileCollection uploads = HttpContext.Current.Request.Files;
        for (int i = 0; i < uploads.Count; i++)
        {
            HttpPostedFile upload = (HttpPostedFile)uploads[i];

            if (upload.ContentLength == 0)
                continue;

            string Ext = System.IO.Path.GetExtension(upload.FileName); // We don't need the path, just the name.
            int intDropBoxID = 0;
            try
            {
                if (ddlDropBoxList.SelectedIndex != 0)
                {
                    string strDropBoxDetails = "";
                    strDropBoxDetails = ddlDropBoxList.SelectedItem.Value.Trim();
                    string[] RowDetails = strDropBoxDetails.Split('|');
                    intDropBoxID = Convert.ToInt32(RowDetails[0]);
                }

                string uploadFilePath=ImageUploadPath+@"\";
                string FileName = intDropBoxID.ToString()+'_'+ i.ToString() + Ext;
                upload.SaveAs(uploadFilePath + FileName);

                Insert_ImageUploadDetails(upload, uploadFilePath, FileName, Ext, intDropBoxID);

                //lblMessage.Text = "Upload(s) Successful.";

            }
            catch (Exception Exp)
            {
                lblMessage.Text = "Upload(s) FAILED."+ Exp.Message.ToString();
            }
        }
    }
      
    private void Get_BatchInfo_Details(string pBatchNo)
    {
        try
        {
            Object SaveUSERInfo = (Object)Session["UserInfo"];

            SqlConnection sqlcon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);

            sqlcon.Open();
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlcon;
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.CommandText = "Get_BatchInfo_Details";
            SqlDataAdapter sqlda = new SqlDataAdapter();
            sqlda.SelectCommand = sqlcmd;

            SqlParameter BranchID = new SqlParameter();
            BranchID.SqlDbType = SqlDbType.Int;
            BranchID.Value = Convert.ToInt32(((UserInfo.structUSERInfo)(SaveUSERInfo)).BranchId);
            BranchID.ParameterName = "@BranchID";
            sqlcmd.Parameters.Add(BranchID);

            SqlParameter BatchNo = new SqlParameter();
            BatchNo.SqlDbType = SqlDbType.VarChar;
            BatchNo.Value = pBatchNo.Trim();
            BatchNo.ParameterName = "@BatchNo";
            sqlcmd.Parameters.Add(BatchNo);

            DataTable dt = new DataTable();
            sqlda.Fill(dt);
            sqlcon.Close();

            ddlBatchNoList.DataTextField = "BatchNo";
            ddlBatchNoList.DataValueField = "BatchDetails";
            ddlBatchNoList.DataSource = dt;
            ddlBatchNoList.DataBind();

            ddlBatchNoList.Items.Insert(0, "-Select-");
            ddlBatchNoList.SelectedIndex = 0;

        }
        catch (Exception ex)
        {
            lblMessage.Visible = true;
            lblMessage.Text = ex.Message;
            lblMessage.CssClass = "ErrorMessage";

        }

        finally
        {
        }

    }
    private void Get_DropBoxDetails_Dropwise()
    {
        try
        {
            Object SaveUSERInfo = (Object)Session["UserInfo"];

            SqlConnection sqlcon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);

            sqlcon.Open();
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlcon;
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.CommandText = "Get_DropBoxDetails_Dropwise";
            SqlDataAdapter sqlda = new SqlDataAdapter();
            sqlda.SelectCommand = sqlcmd;

            SqlParameter BranchID = new SqlParameter();
            BranchID.SqlDbType = SqlDbType.Int;
            BranchID.Value = Convert.ToInt32(((UserInfo.structUSERInfo)(SaveUSERInfo)).BranchId);
            BranchID.ParameterName = "@BranchID";
            sqlcmd.Parameters.Add(BranchID);

            string strBatchNo = "";

            if (ddlDropBoxList.SelectedIndex != 0)
            {
                strBatchNo = ddlBatchNoList.SelectedItem.Text.Trim();
            }

            SqlParameter BatchNo = new SqlParameter();
            BatchNo.SqlDbType = SqlDbType.VarChar;
            BatchNo.Value = strBatchNo;
            BatchNo.ParameterName = "@BatchNo";
            sqlcmd.Parameters.Add(BatchNo);

            DataTable dt = new DataTable();
            sqlda.Fill(dt);
            sqlcon.Close();

            ddlDropBoxList.DataTextField = "DropBox_Code";
            ddlDropBoxList.DataValueField = "DropBoxDetails";
            ddlDropBoxList.DataSource = dt;
            ddlDropBoxList.DataBind();

            ddlDropBoxList.Items.Insert(0, "-Select-");
            ddlDropBoxList.SelectedIndex = 0;

        }
        catch (Exception ex)
        {
            lblMessage.Visible = true;
            lblMessage.Text = ex.Message;
            lblMessage.CssClass = "ErrorMessage";

        }

        finally
        { 
        
        }

    }
    protected void btnGo_Click(object sender, EventArgs e)
    {
        Get_BatchInfo_Details(txtBatchNo.Text.Trim());
    }
    protected void ddlBatchNoList_SelectedIndexChanged(object sender, EventArgs e)
    {
        string strBatchDetails = "";
        
        if (ddlBatchNoList.SelectedIndex != 0)
        {
            strBatchDetails = ddlBatchNoList.SelectedItem.Value.Trim();

            string[] RowDetails = strBatchDetails.Split('|');

            lblBranchName.Text = RowDetails[0];
            lblClientName.Text = RowDetails[1];
        
            Get_DropBoxDetails_Dropwise();

            hdnBatchNo.Value = ddlBatchNoList.SelectedItem.Text;
        }
    }
    protected void btnUploadControls_Click(object sender, EventArgs e)
    {

    }
    protected void ddlDropBoxList_SelectedIndexChanged(object sender, EventArgs e)
    {
        string strBatchDetails = ddlDropBoxList.SelectedItem.Value.Trim();

        string[] RowDetails = strBatchDetails.Split('|');

        lblDropBoxName.Text = RowDetails[1];
        lblTotalChequesCount.Text = RowDetails[2];
        lblUploadedOnServer.Text = RowDetails[3];

  
    }
    private void Insert_ImageUploadDetails(HttpPostedFile objUploadFile, string pImagePath, string FileName, string Extension, int intDropBoxID)
    {               
        try
        {
            Object SaveUSERInfo = (Object)Session["UserInfo"];

            SqlConnection sqlcon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);

            sqlcon.Open();
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlcon;
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.CommandText = "Insert_C_UploadImageInfo";
            SqlDataAdapter sqlda = new SqlDataAdapter();
            sqlda.SelectCommand = sqlcmd;

            SqlParameter BranchID = new SqlParameter();
            BranchID.SqlDbType = SqlDbType.Int;
            BranchID.Value = Convert.ToInt32(((UserInfo.structUSERInfo)(SaveUSERInfo)).BranchId);
            BranchID.ParameterName = "@BranchID";
            sqlcmd.Parameters.Add(BranchID);

            SqlParameter BatchNo = new SqlParameter();
            BatchNo.SqlDbType = SqlDbType.VarChar;
            BatchNo.Value = hdnBatchNo.Value.Trim();
            BatchNo.ParameterName = "@BatchNo";
            sqlcmd.Parameters.Add(BatchNo);

            SqlParameter ImageID = new SqlParameter();
            ImageID.SqlDbType = SqlDbType.VarChar;
            ImageID.Value = 0;
            ImageID.ParameterName = "@ImageID";
            sqlcmd.Parameters.Add(ImageID);

           
            
           

            SqlParameter DropBoxID = new SqlParameter();
            DropBoxID.SqlDbType = SqlDbType.Int ;
            DropBoxID.Value =intDropBoxID;
            DropBoxID.ParameterName = "@DropBoxID";
            sqlcmd.Parameters.Add(DropBoxID);

            SqlParameter ImagePath = new SqlParameter();
            ImagePath.SqlDbType = SqlDbType.VarChar;
            ImagePath.Value = pImagePath.Trim() + FileName;
            ImagePath.ParameterName = "@ImagePath";
            sqlcmd.Parameters.Add(ImagePath);

            SqlParameter ImageName = new SqlParameter();
            ImageName.SqlDbType = SqlDbType.VarChar;
            ImageName.Value = FileName;
            ImageName.ParameterName = "@ImageName";
            sqlcmd.Parameters.Add(ImageName);

            SqlParameter ImageType = new SqlParameter();
            ImageType.SqlDbType = SqlDbType.VarChar;
            ImageType.Value = Extension;
            ImageType.ParameterName = "@ImageType";
            sqlcmd.Parameters.Add(ImageType);

            SqlParameter ImageSize = new SqlParameter();
            ImageSize.SqlDbType = SqlDbType.VarChar;
            ImageSize.Value = objUploadFile.ContentLength;
            ImageSize.ParameterName = "@ImageSize";
            sqlcmd.Parameters.Add(ImageSize);

            SqlParameter IsActive = new SqlParameter();
            IsActive.SqlDbType = SqlDbType.Bit;
            IsActive.Value = 1;
            IsActive.ParameterName = "@IsActive";
            sqlcmd.Parameters.Add(IsActive);

            SqlParameter UserID = new SqlParameter();
            UserID.SqlDbType = SqlDbType.VarChar;
            UserID.Value = Convert.ToString(((UserInfo.structUSERInfo)(SaveUSERInfo)).UserId);
            UserID.ParameterName = "@UserID";
            sqlcmd.Parameters.Add(UserID);

            SqlParameter VarResult = new SqlParameter();
            VarResult.SqlDbType = SqlDbType.VarChar;
            VarResult.Value = txtBatchNo.Text.Trim();
            VarResult.ParameterName = "@VarResult";
            VarResult.Size = 200;
            VarResult.Direction = ParameterDirection.Output;
            sqlcmd.Parameters.Add(VarResult);

            sqlcmd.ExecuteNonQuery();
            string RowEffected = Convert.ToString(sqlcmd.Parameters["@VarResult"].Value);

            sqlcon.Close();

            if (RowEffected != "")
            {
                lblMessage.Text = "Images Successfully Uploaded!, Batch No: " + RowEffected;
                lblMessage.CssClass = "SuccessMessage";                
            }
        }
        catch (Exception ex)
        {
            lblMessage.Visible = true;
            lblMessage.Text = ex.Message;
            lblMessage.CssClass = "ErrorMessage";
        }    
    }
    protected void btnClose_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Pages/Menu.aspx", true);     
    }
}
