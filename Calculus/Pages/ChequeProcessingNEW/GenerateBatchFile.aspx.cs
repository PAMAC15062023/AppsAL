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

public partial class Pages_ChequProcessingNEW_GenerateBatchFile : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserInfo"] == null)
        {
            Response.Redirect("~/Pages/InvalidRequest.aspx");
        }
        if (!IsPostBack)
        {
            if (Request.QueryString["Vw"] != null)
            {
                btnSave.Visible = false;
            }
            if (Request.QueryString["TID"] != null)
            {
                lblBatchNo.Visible = true;
                txtBatchNo.Visible = true;
                txtBatchNo.Text = Request.QueryString["TID"].ToString();
            }
           
            Object SaveUSERInfo = (Object)Session["UserInfo"];
            GET_Header_Values();
            Register_Controls_For_Javascript();
           
            lblLocation.Text = Convert.ToString(((UserInfo.structUSERInfo)(SaveUSERInfo)).BranchName);
            
            txtPickupDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
            ddlClientList.Focus();
        }
         

        string StrScript = "<script language='javascript'> javascript:Page_load_validation(); </script>";
        Page.RegisterStartupScript("OnLoad_21", StrScript);
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        Insert_BatchInfo();
        btnSave.Visible = false;
        btnCancel.Focus();

    }

    private void Insert_BatchInfo()
    {
        Object SaveUSERInfo = (Object)Session["UserInfo"];

        SqlConnection sqlCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);

   
        SqlCommand sqlCom = new SqlCommand();
        sqlCom.Connection = sqlCon;
        sqlCom.CommandType = CommandType.StoredProcedure;
        sqlCom.CommandText = "Insert_C_BatchInfo";
        sqlCom.CommandTimeout = 0;



        SqlParameter BranchID = new SqlParameter();
        BranchID.SqlDbType = SqlDbType.Int;
        BranchID.Value = Convert.ToInt32(((UserInfo.structUSERInfo)(SaveUSERInfo)).BranchId);
        BranchID.ParameterName = "@BranchID";
        sqlCom.Parameters.Add(BranchID);

        SqlParameter BatchNo = new SqlParameter();
        BatchNo.SqlDbType = SqlDbType.VarChar;
        BatchNo.Value = txtBatchNo.Text.Trim();
        BatchNo.ParameterName = "@BatchNo";
        sqlCom.Parameters.Add(BatchNo);

        SqlParameter ClientID = new SqlParameter();
        ClientID.SqlDbType = SqlDbType.VarChar;
        ClientID.Value = Convert.ToInt32(ddlClientList.SelectedItem.Value);
        ClientID.ParameterName = "@ClientID";
        sqlCom.Parameters.Add(ClientID);

        SqlParameter ChequePickeupDate = new SqlParameter();
        ChequePickeupDate.SqlDbType = SqlDbType.VarChar;
        ChequePickeupDate.Value = txtPickupDate.Text.Trim();
        ChequePickeupDate.ParameterName = "@ChequePickeupDate";
        sqlCom.Parameters.Add(ChequePickeupDate);

        SqlParameter ChequeDepositDate = new SqlParameter();
        ChequeDepositDate.SqlDbType = SqlDbType.VarChar;
        ChequeDepositDate.Value = txtDepositdate.Text.Trim();
        ChequeDepositDate.ParameterName = "@ChequeDepositDate";
        sqlCom.Parameters.Add(ChequeDepositDate);

        SqlParameter UserID = new SqlParameter();
        UserID.SqlDbType = SqlDbType.VarChar;
        UserID.Value = Convert.ToString(((UserInfo.structUSERInfo)(SaveUSERInfo)).UserId);
        UserID.ParameterName = "@UserID";
        sqlCom.Parameters.Add(UserID);

        SqlParameter DropBoxChequeDetails = new SqlParameter();
        DropBoxChequeDetails.SqlDbType = SqlDbType.VarChar;
        DropBoxChequeDetails.Value = hdnDropBoxDetails.Value.Trim();
        DropBoxChequeDetails.ParameterName = "@DropBoxChequeDetails";
        sqlCom.Parameters.Add(DropBoxChequeDetails);
        
        SqlParameter VarResult = new SqlParameter();
        VarResult.SqlDbType = SqlDbType.VarChar;
        VarResult.Value = "";//txtBatchNo.Text.Trim();
        VarResult.ParameterName = "@VarResult";
        VarResult.Size = 200;
        VarResult.Direction = ParameterDirection.Output;
        sqlCom.Parameters.Add(VarResult);


        sqlCon.Open();


        sqlCom.ExecuteNonQuery();
        string RowEffected = Convert.ToString(sqlCom.Parameters["@VarResult"].Value);

        sqlCon.Close();

        if (RowEffected != "")
        {
            lblMessage.Text = "Batch No Successfully Generated, Batch No: " + RowEffected;
            lblMessage.CssClass = "SuccessMessage";
            //txtBatchNo.Text = RowEffected;

            //btnCancel.Focus();
        }

    }

    private void Get_AllClientList()
    {
        SqlConnection sqlcon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);

        try
        { 
            
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlcon;
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.CommandText = "Get_AllClientList";
            sqlcmd.CommandTimeout = 0;

            SqlParameter Is_Active = new SqlParameter();
            Is_Active.SqlDbType = SqlDbType.Int;
            Is_Active.Value = 1;
            Is_Active.ParameterName = "@Is_Active";
            sqlcmd.Parameters.Add(Is_Active);

            sqlcon.Open();
            SqlDataAdapter sqlda = new SqlDataAdapter();
            sqlda.SelectCommand = sqlcmd;
            DataTable dt = new DataTable();
            sqlda.Fill(dt);

            Cache["SBIClientList"]=dt;

            ddlClientList.DataTextField = "ClientName";
            ddlClientList.DataValueField = "ClientID";
            ddlClientList.DataSource = dt;
            ddlClientList.DataBind();

            ddlClientList.Items.Insert(0, "-Select-");
            ddlClientList.SelectedIndex = 0;


        }
        catch (Exception ex)
        {
            lblMessage.Visible = true;
            lblMessage.Text = ex.Message;
            lblMessage.CssClass = "ErrorMessage";

        }
        finally
        {
            sqlcon.Close();
        }

    }

    private void Get_AllDropBoxInfo(int _clientNo)
    {
        try
        {
            Object SaveUSERInfo = (Object)Session["UserInfo"];

            SqlConnection sqlcon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);


            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlcon;
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.CommandText = "Get_AllDropBoxInfo";
            sqlcmd.CommandTimeout = 0;




            SqlParameter BranchID = new SqlParameter();
            BranchID.SqlDbType = SqlDbType.Int;
            BranchID.Value = Convert.ToInt32(((UserInfo.structUSERInfo)(SaveUSERInfo)).BranchId);
            BranchID.ParameterName = "@BranchID";
            sqlcmd.Parameters.Add(BranchID);

            if (_clientNo == 1)
            {
                SqlParameter Remark = new SqlParameter();
                Remark.SqlDbType = SqlDbType.VarChar;
                Remark.Value = "Normal";
                Remark.ParameterName = "@Remark";
                sqlcmd.Parameters.Add(Remark);
            }
            else
                if (_clientNo == 2)
                {
                    SqlParameter Remark = new SqlParameter();
                    Remark.SqlDbType = SqlDbType.VarChar;
                    Remark.Value = "SOC";
                    Remark.ParameterName = "@Remark";
                    sqlcmd.Parameters.Add(Remark);
                }

            sqlcon.Open();
            SqlDataAdapter sqlda = new SqlDataAdapter();
            sqlda.SelectCommand = sqlcmd;
            DataTable dt = new DataTable();
            sqlda.Fill(dt);
            sqlcon.Close();

            ddlDropBoxList.DataTextField = "DropBox_Code";
            ddlDropBoxList.DataValueField = "DropBoxID";
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

    public string RowEffected;
   
    private void Register_Controls_For_Javascript()
    {
        ddlDropBoxList.Attributes.Add("onchange", "javascript:ShowDropBoxName();");         
        btnAdd.Attributes.Add("onclick", "javascript:return AddColumnToGrid();");
        btnRemove.Attributes.Add("onclick", "javascript:return Remove_DropBoxCount();");
        btnSave.Attributes.Add("onclick", "javascript:return Validate_Save();"); 
         
    }
        
    private void Clear_Controls()
    { 
    
    }

    private void GET_Header_Values()
    {
        if (Cache["SBIClientList"]==null)
        {
        Get_AllClientList();
        }
        else
        {
            ddlClientList.DataTextField = "ClientName";
            ddlClientList.DataValueField = "ClientID";

            ddlClientList.DataSource = (DataTable)Cache["SBIClientList"];
            ddlClientList.DataBind();

            ddlClientList.Items.Insert(0, "-Select-");
            ddlClientList.SelectedIndex = 0;
        }
        
 
        Register_Controls_For_Javascript();
   

    }

    private void Get_BatchInfoDetails_Modify()
    {
        try
        {
            Object SaveUSERInfo = (Object)Session["UserInfo"];

            SqlConnection sqlcon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);


            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlcon;
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.CommandText = "Get_BatchInfoDetails_Modify";
            sqlcmd.CommandTimeout = 0;




            SqlParameter BatchNo = new SqlParameter();
            BatchNo.SqlDbType = SqlDbType.VarChar;
            BatchNo.Value = "";
            BatchNo.ParameterName = "@BatchNo";
            sqlcmd.Parameters.Add(BatchNo);

            SqlParameter BranchID = new SqlParameter();
            BranchID.SqlDbType = SqlDbType.Int;
            BranchID.Value = Convert.ToInt32(((UserInfo.structUSERInfo)(SaveUSERInfo)).BranchId);
            BranchID.ParameterName = "@BranchID";
            sqlcmd.Parameters.Add(BranchID);


            sqlcon.Open();
            SqlDataAdapter sqlda = new SqlDataAdapter();
            sqlda.SelectCommand = sqlcmd;
            DataSet ds = new DataSet();
            sqlda.Fill(ds);
            sqlcon.Close();

            if (ds.Tables.Count == 2)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    txtDepositdate.Text = ds.Tables[0].Rows[0]["ChequeDepositDate"].ToString();
                    txtPickupDate.Text = ds.Tables[0].Rows[0]["ChequePickupDate"].ToString();
                    ddlClientList.SelectedValue = ds.Tables[0].Rows[0]["ClientID"].ToString();

                }
                if (ds.Tables[1].Rows.Count > 0)
                {
                    string strChequeDetails = "";

                    for (int i = 0; i <= ds.Tables[1].Rows.Count - 1; i++)
                    {
                        strChequeDetails = strChequeDetails + ds.Tables[1].Rows[i]["ChequeDetails"].ToString().Trim();
                    }
                    hdnDropBoxDetails.Value = strChequeDetails;
                }

            }
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

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Pages/Menu.aspx", true);     
    }

    public int intDropBoxList;
    public int intDropBoxID;

    protected void ddlClientList_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlClientList.SelectedIndex == 1)
        {
            Get_AllDropBoxInfo(ddlClientList.SelectedIndex);
        }
        else if(ddlClientList.SelectedIndex == 2)
        {
            Get_AllDropBoxInfo(ddlClientList.SelectedIndex);
        }
    }

    protected void ddlDropBoxList_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}
