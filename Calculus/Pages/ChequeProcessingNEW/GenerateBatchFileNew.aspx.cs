using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

public partial class Pages_ChequeProcessingNEW_GenerateBatchFileNew : System.Web.UI.Page
{
    int clientid = 0;
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
                txtBatchNo.Enabled = false;
                txtChequeCount.Enabled = false;
                txtDepositdate.Enabled = false;
                txtDropBoxName.Enabled = false;
                txtPickupDate.Enabled = false;
                // I Make Change Please  Do enable Fale
                ddlClientList.Enabled = true;
                ddlDropBoxList.Enabled = true;
                //888888888888888888888888888888//
                btnAdd.Visible = false;

            }

            if (Request.QueryString["TID"] != null)
            {
                lblBatchNo.Visible = true;
                txtBatchNo.Visible = true;
                txtBatchNo.Text = Request.QueryString["TID"].ToString();
            }
            else
            {
                txtPickupDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
            }
            
            Object SaveUSERInfo = (Object)Session["UserInfo"];
            GET_Header_Values();
            Register_Controls_For_Javascript();
            
            lblLocation.Text = Convert.ToString(((UserInfo.structUSERInfo)(SaveUSERInfo)).BranchName);
          

            ddlClientList.Focus();
            if (ddlClientList.SelectedIndex == 1)
            {
                clientid = 1;
                Get_AllDropBoxInfo(clientid);
            }
            else if(ddlClientList.SelectedIndex==2)
            {
                clientid = 2;
                Get_AllDropBoxInfo(clientid);
            }

            // I Make Change Please  Do enable Fale And Remove Clientid And Get _Alldropboxinfo 
            ddlClientList.Enabled = true;
            clientid = 1;
            Get_AllDropBoxInfo(clientid);
            //*************************************//
        }

    }

    protected void Gv_Search_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Attributes.Add("onclick", "javascript:GV_RowSelection('" + e.Row.RowIndex + "','" + e.Row.Cells[4].Text + "');");
        }

    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        lblMessage.Text = "";
        Insert_BatchInfo();
        GET_Header_Values();
        Clear_Controls();

    }

    private void Insert_BatchInfo()
    {
        Object SaveUSERInfo = (Object)Session["UserInfo"];

        SqlConnection sqlCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);

  
        SqlCommand sqlCom = new SqlCommand();
        sqlCom.Connection = sqlCon;
        sqlCom.CommandType = CommandType.StoredProcedure;
        sqlCom.CommandText = "Insert_C_BatchInfo_mod2";
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

        List<string> myList = new List<string>(ddlDropBoxList.SelectedItem.Value.Split(':'));

        SqlParameter DropBoxID = new SqlParameter();
        DropBoxID.SqlDbType = SqlDbType.Int;
        DropBoxID.Value =Convert.ToInt32(myList[0]);
        DropBoxID.ParameterName = "@DropBoxID";
        sqlCom.Parameters.Add(DropBoxID);

        SqlParameter ChqCount = new SqlParameter();
        ChqCount.SqlDbType = SqlDbType.Int;
        ChqCount.Value = Convert.ToInt32(txtChequeCount.Text);
        ChqCount.ParameterName = "@ChqCount";
        sqlCom.Parameters.Add(ChqCount);

        SqlParameter DropCountID = new SqlParameter();
        DropCountID.SqlDbType = SqlDbType.Int;
        DropCountID.Value = Convert.ToInt32(hdnDropCountID.Value);
        DropCountID.ParameterName = "@DropCountID";
        sqlCom.Parameters.Add(DropCountID);

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
            lblMessage.Text = "Batch  Successfully Updated, Batch No: " + RowEffected;
            lblMessage.CssClass = "SuccessMessage";
            //txtBatchNo.Text = RowEffected;

            //btnCancel.Focus();
        }

    }

    private void Get_AllClientList()
    {
        try
        {
            SqlConnection sqlcon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);

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
            sqlcon.Close();

            Cache["SBIClientList"] = dt;

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
        
        
        }
    }

    private void Get_AllDropBoxInfo(int clientid)
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

            if (clientid == 1)
            {
                SqlParameter Remark = new SqlParameter();
                Remark.SqlDbType = SqlDbType.VarChar;
                Remark.Value = "Normal";
                Remark.ParameterName = "@Remark";
                sqlcmd.Parameters.Add(Remark);
            }
            else
                if (clientid == 2)
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
        //ddlDropBoxList.Attributes.Add("onchange", "javascript:ShowDropBoxName();");
        //btnAdd.Attributes.Add("onclick", "javascript:return AddColumnToGrid();");
        //btnRemove.Attributes.Add("onclick", "javascript:return Remove_DropBoxCount();");
        btnSave.Attributes.Add("onclick", "javascript:return Validate_Save();");

    }



    private void Clear_Controls()
    {
        lblMessage.Text = "";
        ddlDropBoxList.SelectedIndex = 0;
        txtChequeCount.Text = "";
        txtDropBoxName.Text = "";
    }

    private void GET_Header_Values()
    {
        if (Cache["SBIClientList"] == null)
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
        //Get_AllDropBoxInfo();
        Register_Controls_For_Javascript();
        if (txtBatchNo.Text != "")
        {
            Get_BatchInfoDetails_Modify();
            Get_TotalCount();
        }

    }

    private void Get_TotalCount()
    {
        try
        {
            Object SaveUSERInfo = (Object)Session["UserInfo"];

            SqlConnection sqlcon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);


            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlcon;
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.CommandText = "Get_TotalCountForBatch";
            sqlcmd.CommandTimeout = 0;



            SqlParameter BatchNo = new SqlParameter();
            BatchNo.SqlDbType = SqlDbType.VarChar;
            BatchNo.Value = txtBatchNo.Text.Trim();
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

            lblCount.Text = ds.Tables[0].Rows[0]["TotalCount"].ToString();



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

    private void Get_BatchInfoDetails_Modify()
    {
        try
        {
            Object SaveUSERInfo = (Object)Session["UserInfo"];

            SqlConnection sqlcon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);


            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlcon;
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.CommandText = "Get_BatchInfoDetails_Modify_mod";
            sqlcmd.CommandTimeout = 0;



            SqlParameter BatchNo = new SqlParameter();
            BatchNo.SqlDbType = SqlDbType.VarChar;
            BatchNo.Value = txtBatchNo.Text.Trim();
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
                    Gv_Search.DataSource = ds.Tables[1];
                    Gv_Search.DataBind();

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

      protected void ddlDropBoxList_SelectedIndexChanged(object sender, EventArgs e)
    {
        lblMessage.Text = "";
        try
        {
            Object SaveUSERInfo = (Object)Session["UserInfo"];

            SqlConnection sqlcon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);


            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlcon;
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.CommandText = "Get_DropBoxNameNew";
            sqlcmd.CommandTimeout = 0;



            List<string> myList2 = new List<string>(ddlDropBoxList.SelectedItem.Value.Split(':'));

            SqlParameter DropBoxI = new SqlParameter();
            DropBoxI.SqlDbType = SqlDbType.Int;
            DropBoxI.Value = Convert.ToInt32(myList2[0]);
            DropBoxI.ParameterName = "@DropBoxID";
            sqlcmd.Parameters.Add(DropBoxI);


            sqlcon.Open();
            SqlDataAdapter sqlda = new SqlDataAdapter();
            sqlda.SelectCommand = sqlcmd;
            DataSet ds = new DataSet();
            sqlda.Fill(ds);
            sqlcon.Close();

            txtDropBoxName.Text = ds.Tables[0].Rows[0]["DropBox_Name"].ToString();

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
        txtChequeCount.Focus();


    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        lblMessage.Text = "";
        Clear_Controls();
    }

    protected void ddlClientList_SelectedIndexChanged(object sender, EventArgs e)
    {
        //if (Convert.ToInt32(ddlClientList.SelectedItem) == 1)
        //{
            
        //}
        //else
        //{
        //}
    }
    protected void ddlClientList_Load(object sender, EventArgs e)
    {
       
    }
}