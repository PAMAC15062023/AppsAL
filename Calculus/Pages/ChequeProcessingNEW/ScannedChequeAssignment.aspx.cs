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
using System.IO.Compression; 

public partial class Pages_ChequeProcessingNEW_ScannedChequeAssignment : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserInfo"] == null)
        {
            Response.Redirect("~/Pages/InvalidRequest.aspx");
            

        }
        if (!IsPostBack)
        {
            //if (Request.QueryString["Vw"] != null)
            //{
            //    btnSave.Visible = false;
            //}
            //if (Request.QueryString["TID"] != null)
            //{
            //    txtBatchNo.Text = Request.QueryString["TID"].ToString();
            //}

           GET_Header_Values();
          
            
        }
         
        Register_ControlsWith_JavaScript();
    }
    private void GET_Header_Values()
    {
        Get_UserListInfo();
        //Get_BatchInfo_Details();
        //Get_DropBoxDetails_Dropwise();

    }
    private void Get_UserListInfo()
    {
        try
        {
            Object SaveUSERInfo = (Object)Session["UserInfo"];

            SqlConnection sqlcon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);

            sqlcon.Open();
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlcon;
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.CommandText = "Get_UserList_For_ChequeProcessing";
            SqlDataAdapter sqlda = new SqlDataAdapter();
            sqlda.SelectCommand = sqlcmd;

            SqlParameter BranchID = new SqlParameter();
            BranchID.SqlDbType = SqlDbType.Int;
            BranchID.Value = Convert.ToInt32(((UserInfo.structUSERInfo)(SaveUSERInfo)).BranchId);
            BranchID.ParameterName = "@BranchID";
            sqlcmd.Parameters.Add(BranchID);

            SqlParameter ProcessName = new SqlParameter();
            ProcessName.SqlDbType = SqlDbType.VarChar;
            ProcessName.Value = "Cheque Process";
            ProcessName.ParameterName = "@ProcessName";
            sqlcmd.Parameters.Add(ProcessName);


            DataTable dt = new DataTable();
            sqlda.Fill(dt);
            sqlcon.Close();

            chkUserList.DataTextField = "UserName";
            chkUserList.DataValueField = "UserID";
            chkUserList.DataSource = dt;
            chkUserList.DataBind();



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
            sqlcmd.CommandText = "Get_DropBoxDetails_Dropwise_Assignement";
            SqlDataAdapter sqlda = new SqlDataAdapter();
            sqlda.SelectCommand = sqlcmd;

            SqlParameter BranchID = new SqlParameter();
            BranchID.SqlDbType = SqlDbType.Int;
            BranchID.Value = Convert.ToInt32(((UserInfo.structUSERInfo)(SaveUSERInfo)).BranchId);
            BranchID.ParameterName = "@BranchID";
            sqlcmd.Parameters.Add(BranchID);

            string strBatchNo = "";

            if (ddlBatchNoList.SelectedIndex != 0)
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

            ddlDropboxList.DataTextField = "DropBox_Code";
            ddlDropboxList.DataValueField = "DropBoxDetails";
            ddlDropboxList.DataSource = dt;
            ddlDropboxList.DataBind();
            ddlDropboxList.SelectedIndex = 0;


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
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        Get_BatchInfo_Details(txtBatchNoSearch.Text.Trim());
    }
    protected void ddlBatchNoList_SelectedIndexChanged(object sender, EventArgs e)
    {
        
        Get_DropBoxDetails_Dropwise();

    }    
    private void Register_ControlsWith_JavaScript()
    {
         
        ddlDropboxList.Attributes.Add("onchange", "javascript:Get_DropBoxDetails();");
        btnSave.Attributes.Add("onclick", "javascript:return Validate_ChequeCount();");
        

    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        Insert_ImageAssignment();
    }
    private void Insert_ImageAssignment()
    {
        try
        {
            Object SaveUSERInfo = (Object)Session["UserInfo"];

            SqlConnection sqlcon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);

            sqlcon.Open();
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlcon;
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.CommandText = "Insert_C_ChequeImageAssignment";
            SqlDataAdapter sqlda = new SqlDataAdapter();
            sqlda.SelectCommand = sqlcmd;

            SqlParameter BranchID = new SqlParameter();
            BranchID.SqlDbType = SqlDbType.Int;
            BranchID.Value = Convert.ToInt32(((UserInfo.structUSERInfo)(SaveUSERInfo)).BranchId);
            BranchID.ParameterName = "@BranchID";
            sqlcmd.Parameters.Add(BranchID);

            string strBatchNo = "";

            if (ddlBatchNoList.SelectedIndex != 0)
            {
                strBatchNo = ddlBatchNoList.SelectedItem.Text.Trim();
            }

            SqlParameter BatchNo = new SqlParameter();
            BatchNo.SqlDbType = SqlDbType.VarChar;
            BatchNo.Value = strBatchNo;
            BatchNo.ParameterName = "@BatchNo";
            sqlcmd.Parameters.Add(BatchNo);

            int intDropBoxID = 0;
            if (ddlDropboxList.SelectedIndex != 0)
            {
                string strDropBoxDetails = "";
                strDropBoxDetails = ddlDropboxList.SelectedItem.Value.Trim();
                string[] RowDetails = strDropBoxDetails.Split('|');
                intDropBoxID = Convert.ToInt32(RowDetails[0]);
            }

            SqlParameter DropBoxID = new SqlParameter();
            DropBoxID.SqlDbType = SqlDbType.Int;
            DropBoxID.Value = intDropBoxID;
            DropBoxID.ParameterName = "@DropBoxID";
            sqlcmd.Parameters.Add(DropBoxID);

            SqlParameter UserID = new SqlParameter();
            UserID.SqlDbType = SqlDbType.VarChar;
            UserID.Value = Convert.ToString(((UserInfo.structUSERInfo)(SaveUSERInfo)).UserId);
            UserID.ParameterName = "@UserID";
            sqlcmd.Parameters.Add(UserID);

            SqlParameter AssignmentDetails = new SqlParameter();
            AssignmentDetails.SqlDbType = SqlDbType.NVarChar;
            AssignmentDetails.Value = Get_AssignmentDetails();
            AssignmentDetails.ParameterName = "@AssignmentDetails";
            sqlcmd.Parameters.Add(AssignmentDetails);

            SqlParameter NoOfUser = new SqlParameter();
            NoOfUser.SqlDbType = SqlDbType.Int ;
            NoOfUser.Value =Convert.ToInt32(hdnUserCount.Value);
            NoOfUser.ParameterName = "@NoOfUser";
            sqlcmd.Parameters.Add(NoOfUser);

            SqlParameter NoOfCheque = new SqlParameter();
            NoOfCheque.SqlDbType = SqlDbType.Int;
            NoOfCheque.Value = Convert.ToInt32(hdnUserCount.Value);
            NoOfCheque.ParameterName = "@NoOfCheque";
            sqlcmd.Parameters.Add(NoOfCheque); 

            sqlcmd.ExecuteNonQuery();
            
            sqlcon.Close();


        }
        catch (Exception ex)
        {
            lblMessage.Visible = true;
            lblMessage.Text = ex.Message;
            lblMessage.CssClass = "ErrorMessage";

        }
    }
    private string Get_AssignmentDetails()
    { 
        string ReturnValue="";

        for(int i=0;i<=chkUserList.Items.Count-1;i++)
        {
            if (chkUserList.Items[i].Selected == true)
            {
                ReturnValue = ReturnValue + chkUserList.Items[i].Value.ToString() + "|" + hdnCount.Value+"^"; 
            }
        }
        return ReturnValue;

    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Pages/Menu.aspx", true);     
    }
}
