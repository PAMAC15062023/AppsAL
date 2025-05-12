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
using ADOX;
using System.Data.OleDb;
using System.IO;


public partial class Pages_ChequeProcessingNEW_GenerateMDBFile : System.Web.UI.Page
{
    public string MDBName;
    protected void Page_Load(object sender, EventArgs e)
    {
     //if (Session["UserInfo"] == null)
     //       {
     //           Response.Redirect("~/Pages/InvalidRequest.aspx");
     //       }

        if (!IsPostBack)
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
            RegisterControls_WithJavascript();
        }
        Object SaveUSERInfo = (Object)Session["UserInfo"];
        lblLocation.Text = Convert.ToString(((UserInfo.structUSERInfo)(SaveUSERInfo)).BranchName);
    }
    private void RegisterControls_WithJavascript()
    {
        
    }

  

    private void Get_PendingCount()
    {
        try
        {
            Object SaveUSERInfo = (Object)Session["UserInfo"];

            SqlConnection sqlcon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);


            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlcon;
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.CommandText = "Get_PendingCountForDSnMDB";
            sqlcmd.CommandTimeout = 0;



            SqlParameter BranchID = new SqlParameter();
            BranchID.SqlDbType = SqlDbType.Int;
            BranchID.Value = Convert.ToInt32(((UserInfo.structUSERInfo)(SaveUSERInfo)).BranchId);
            BranchID.ParameterName = "@BranchID";
            sqlcmd.Parameters.Add(BranchID);

            int pClientId = 0;
            if (ddlClientList.SelectedIndex != 0)
            {
                pClientId = Convert.ToInt32(ddlClientList.SelectedItem.Value);
            }

            SqlParameter ClientID = new SqlParameter();
            ClientID.SqlDbType = SqlDbType.Int;
            ClientID.Value = pClientId;
            ClientID.ParameterName = "@ClientID";
            sqlcmd.Parameters.Add(ClientID);

            SqlParameter ChequePickeupDate = new SqlParameter();
            ChequePickeupDate.SqlDbType = SqlDbType.VarChar;
            ChequePickeupDate.Value = txtPickupDate.Text.Trim();
            ChequePickeupDate.ParameterName = "@ChequePickeupDate";
            sqlcmd.Parameters.Add(ChequePickeupDate);

            sqlcon.Open();
            SqlDataAdapter sqlda = new SqlDataAdapter();
            sqlda.SelectCommand = sqlcmd;
            DataTable dt = new DataTable();
            sqlda.Fill(dt);
            sqlcon.Close();

            if (dt.Rows.Count > 0)
            {
                hdnPendingCount.Value = dt.Rows[0]["PendingCount"].ToString();
            }
        }
        catch (Exception ex)
        {
            lblMessage.Visible = true;
            lblMessage.Text = ex.Message;
            lblMessage.CssClass = "ErrorMessage";
        }
        finally
        { }

    }

    private DataTable Get_DropBoxCountDetails(string strBatchNo)
    {

        SqlConnection sqlCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);

    
        SqlCommand sqlCom = new SqlCommand();
        sqlCom.Connection = sqlCon;
        sqlCom.CommandType = CommandType.StoredProcedure;
        sqlCom.CommandText = "Get_BatchFileDetails_Search_Detail";

        SqlParameter BatchNo = new SqlParameter();
        BatchNo.SqlDbType = SqlDbType.VarChar;
        BatchNo.Value = strBatchNo;
        BatchNo.ParameterName = "@BatchNo";
        sqlCom.Parameters.Add(BatchNo);

        sqlCon.Open();
        SqlDataAdapter sqlDA = new SqlDataAdapter();
        sqlDA.SelectCommand = sqlCom;
        DataTable dt = new DataTable();
        sqlDA.Fill(dt);
        sqlCon.Close();

        return dt;

    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {

        if (ddlClientList.SelectedIndex != 0)
        {
            if (txtPickupDate.Text != "")
            {
                if (txtDepositdate.Text != "")
                {
                    Get_BatchFileDetails_Search2();
                    Get_PendingCount();
                    btnGenerateMDB.Visible = true;
                }
                else
                {
                    lblMessage.Text = "Deposit Date Mandatory.";
                    lblMessage.CssClass = "ErrorMessage";
                }
            }
            else
            {
                lblMessage.Text = "Pickup Date Mandatory.";
                lblMessage.CssClass = "ErrorMessage";
            }

        }
        else
        {
            lblMessage.Text = "Select One Client.";
            lblMessage.CssClass = "ErrorMessage";
        }
        ////Get_BatchFileDetails_Search(); //before datewise search
        //if (ddlClientList.SelectedIndex < 1)
        //{
        //    lblMessage.Text = "Select One Client";
        //}
        //else
        //{
        //    Get_BatchFileDetails_Search2();
        //}
    }

    
    private void Get_BatchFileDetails_Search2()
    {
        try
        {
            Object SaveUSERInfo = (Object)Session["UserInfo"];

            SqlConnection sqlcon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);


            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlcon;
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.CommandText = "Get_BatchFileDetails_SearchNew";
            sqlcmd.CommandTimeout = 0;




            SqlParameter BranchID = new SqlParameter();
            BranchID.SqlDbType = SqlDbType.Int;
            BranchID.Value = Convert.ToInt32(((UserInfo.structUSERInfo)(SaveUSERInfo)).BranchId);
            BranchID.ParameterName = "@BranchID";
            sqlcmd.Parameters.Add(BranchID);

            int pClientId = 0;
            if (ddlClientList.SelectedIndex != 0)
            {
                pClientId = Convert.ToInt32(ddlClientList.SelectedItem.Value);
            }

            SqlParameter ClientID = new SqlParameter();
            ClientID.SqlDbType = SqlDbType.Int;
            ClientID.Value = pClientId;
            ClientID.ParameterName = "@ClientID";
            sqlcmd.Parameters.Add(ClientID);

            SqlParameter ChequePickeupDate = new SqlParameter();
            ChequePickeupDate.SqlDbType = SqlDbType.VarChar;
            ChequePickeupDate.Value = txtPickupDate.Text.Trim();
            ChequePickeupDate.ParameterName = "@ChequePickeupDate";
            sqlcmd.Parameters.Add(ChequePickeupDate);

            SqlParameter ChequeDepositDate = new SqlParameter();
            ChequeDepositDate.SqlDbType = SqlDbType.VarChar;
            ChequeDepositDate.Value = txtDepositdate.Text.Trim();
            ChequeDepositDate.ParameterName = "@ChequeDepositDate";
            sqlcmd.Parameters.Add(ChequeDepositDate);


            sqlcon.Open();
            SqlDataAdapter sqlda = new SqlDataAdapter();
            sqlda.SelectCommand = sqlcmd;
            DataTable dt = new DataTable();
            sqlda.Fill(dt);
            sqlcon.Close();


            if (dt.Rows.Count > 0)
            {
                lblMessage.Text = "Total No of Rows found :" + dt.Rows.Count;
                lblMessage.CssClass = "SuccessMessage";
                grvTransactionInfo.DataSource = dt;
                grvTransactionInfo.DataBind();
            }
            else
            {

                lblMessage.Text = "Total No of Rows found :" + dt.Rows.Count;
                lblMessage.CssClass = "ErrorMessage";
                grvTransactionInfo.DataSource = null;
                grvTransactionInfo.DataBind();
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
   
    protected void btnClose_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Pages/Menu.aspx", true);
        
    }
    protected void btnGenerateMDB_Click(object sender, EventArgs e)
    {
        try
        {
            if (ddlClientList.SelectedIndex != 0)
            {
                if (txtPickupDate.Text != "")
                {
                    if (txtDepositdate.Text != "")
                    {
                        //Generate_MDBFile();

                        //if (hdnPendingCount.Value != null && Convert.ToInt32(hdnPendingCount.Value) == 0)
                        //{
                        Generate_MDBFile();
                        //}
                        //else
                        //{
                        //    lblMessage.Text = "MDB cannot be generated.Complete Pending batch(s) first.";
                        //    lblMessage.CssClass = "ErrorMessage";
                        //}
                    }
                    else
                    {
                        lblMessage.Text = "Deposit Date Mandatory.";
                        lblMessage.CssClass = "ErrorMessage";
                    }
                }
                else
                {
                    lblMessage.Text = "Pickup Date Mandatory.";
                    lblMessage.CssClass = "ErrorMessage";
                }

            }
            else
            {
                lblMessage.Text = "Select One Client.";
                lblMessage.CssClass = "ErrorMessage";
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
    protected void btnClear_Click(object sender, EventArgs e)
    {
        //txtBatchNo.Text = "";
        txtDepositdate.Text = "";
        //txtDepositSlipNo.Text = "";
        txtPickupDate.Text = "";
        //txtSendDate.Text = "";
        ddlClientList.SelectedIndex = 0;    
    }
    private void GetMDBFileName()
    {
        Object SaveUSERInfo = (Object)Session["UserInfo"];
        
            SqlConnection sqlcon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);

   
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlcon;
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.CommandText = "Get_MDBName";
            sqlcmd.CommandTimeout = 0;

        

            SqlParameter BranchID = new SqlParameter();
            BranchID.SqlDbType = SqlDbType.Int;
            BranchID.Value = Convert.ToInt32(((UserInfo.structUSERInfo)(SaveUSERInfo)).BranchId);
            BranchID.ParameterName = "@BranchID";
            sqlcmd.Parameters.Add(BranchID);

            SqlParameter chqdate = new SqlParameter();
            chqdate.SqlDbType = SqlDbType.VarChar;
            chqdate.Value =txtPickupDate.Text;//Convert.ToInt32(ddlClientList.SelectedItem.Value);
            chqdate.ParameterName = "@chqdate";
            sqlcmd.Parameters.Add(chqdate);

            SqlParameter ClientId = new SqlParameter();
            ClientId.SqlDbType = SqlDbType.Int;
            ClientId.Value =Convert.ToInt32(ddlClientList.SelectedIndex.ToString());
            ClientId.ParameterName = "@clientId";
            sqlcmd.Parameters.Add(ClientId);

            SqlParameter VarResult = new SqlParameter();
            VarResult.SqlDbType = SqlDbType.VarChar;
            VarResult.Value = "";//txtBatchNo.Text.Trim();
            VarResult.ParameterName = "@varSeries";
            VarResult.Size = 20;
            VarResult.Direction = ParameterDirection.Output;
            sqlcmd.Parameters.Add(VarResult);

            sqlcon.Open();
   

            sqlcmd.ExecuteNonQuery();

            MDBName = Convert.ToString(sqlcmd.Parameters["@varSeries"].Value);
            sqlcon.Close();
        
    }
    private void Generate_MDBFile()
    {
        string MDBFileTemplate = Convert.ToString(ConfigurationSettings.AppSettings["MDBFileTemplate"]); //this.Request.PhysicalApplicationPath;
        
        string FileName = "";
        string FileSAVEPath = "";
        string FinalFileDownload = "";

        GetMDBFileName();
        
        //FileName = Convert.ToString(DateTime.Now.ToString("yyyyMMddHHmmss"));

      
        FileName = MDBName.ToString();


        FileSAVEPath = Convert.ToString(ConfigurationSettings.AppSettings["FileDownloadPath"]); //Convert.ToString(System.Configuration.ConfigurationManager.AppSettings["GESBI_ExportFilePath"]);
        FinalFileDownload = FileSAVEPath + FileName + ".mdb";

         MDB_NameToInsert=FileName+".mdb";

        File.Copy(MDBFileTemplate, FinalFileDownload, true); 

        string strCon = "Provider=Microsoft.Jet.OLEDB.4.0;data source=" + FinalFileDownload;
        OleDbConnection oleCon = new OleDbConnection(strCon);
        oleCon.Open();
    
        DataTable dt = Get_Datafor_MDB_Generation();

        //if (dt != null)
        //{
            for (int i = 0; i <= dt.Rows.Count - 1; i++)
            {
                OleDbCommand oleCom1 = new OleDbCommand("Insert Into trxndetail (SerialNo,cardno,amount) values('" + Convert.ToInt32(dt.Rows[i]["serialno"].ToString()) + "','" + Convert.ToString(dt.Rows[i]["CardNo"].ToString()) + "','" + Convert.ToDecimal(dt.Rows[i]["CardAmount"].ToString()) + "')");
               
                oleCom1.Connection = oleCon;
                oleCom1.ExecuteReader();

                OleDbCommand oleCom2 = new OleDbCommand("Insert Into trxnHeader (serialno,trantype,paymode,trxnamount,derogmastcode,remarks,invalidtrxnyn,insttype,instno,instdate,microfilmno,micrcode,cityname,bankname,branchname,dsnumber,dropboxid,accountno,phoneno,receiptno,TcCode,PType,PDate) values('" + Convert.ToInt32(dt.Rows[i]["serialno"].ToString()) + "','" + Convert.ToString(dt.Rows[i]["trantype"].ToString()) + "','" + Convert.ToString(dt.Rows[i]["paymode"].ToString()) + "','" + Convert.ToDecimal(dt.Rows[i]["trxnamount"].ToString()) + "','" + Convert.ToString(dt.Rows[i]["derogmastcode"].ToString()) + "','" + Convert.ToString(dt.Rows[i]["remarks"].ToString()) + "','" + Convert.ToString(dt.Rows[i]["invalidtrxnyn"].ToString()) + "','" + Convert.ToString(dt.Rows[i]["insttype"].ToString()) + "','" + Convert.ToString(dt.Rows[i]["instno"].ToString()) + "','" + Convert.ToString(dt.Rows[i]["instdate"].ToString()) + "','" + Convert.ToString(dt.Rows[i]["microfilmno"].ToString()) + "','" + Convert.ToString(dt.Rows[i]["micrcode"].ToString()) + "','" + Convert.ToString(dt.Rows[i]["cityname"].ToString()) + "','" + Convert.ToString(dt.Rows[i]["bankname"].ToString()) + "','" + Convert.ToString(dt.Rows[i]["branchname"].ToString()) + "','" + Convert.ToString(dt.Rows[i]["dsnumber"].ToString()) + "','" + Convert.ToString(dt.Rows[i]["dropboxid"].ToString()) + "','" + Convert.ToString(dt.Rows[i]["accountno"].ToString()) + "','" + Convert.ToString(dt.Rows[i]["phoneno"].ToString()) + "','" + Convert.ToString(dt.Rows[i]["receiptno"].ToString()) + "','" + Convert.ToString(dt.Rows[i]["TcCode"].ToString()) + "','" + Convert.ToString(dt.Rows[i]["PType"].ToString()) + "','" + Convert.ToString(dt.Rows[i]["PDate"].ToString()) + "')");
                oleCom2.Connection = oleCon;
                oleCom2.ExecuteReader();
            }
        //}
        DataTable dt2 = Get_BatchDataForMDB();
        for (int j = 0; j <= dt2.Rows.Count - 1; j++)
        {
            OleDbCommand oleCom = new OleDbCommand("Insert Into Batch (Center,batchid,citycode) values('" + Convert.ToString(dt2.Rows[j]["Centre"]) + "','" + Convert.ToString(dt2.Rows[j]["BatchId"]) + "','" + Convert.ToString(dt2.Rows[j]["CityCode"]) + "')");
            oleCom.Connection = oleCon;
            oleCom.ExecuteReader(); ;
        }

        //OleDbCommand oleCom = new OleDbCommand("Insert Into Batch (Center,batchid,citycode) values('MUM320','MUM320093','400')");
        //oleCom.Connection = oleCon;
        //oleCom.ExecuteReader(); ;


        oleCon.Close();
        Download_MdbFile(FinalFileDownload);
       


    }

    private DataTable Get_BatchDataForMDB()
    {
        try
        {
            Object SaveUSERInfo = (Object)Session["UserInfo"];

            SqlConnection sqlcon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);


            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlcon;
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.CommandText = "Get_BatchDataforMDB";
            sqlcmd.CommandTimeout = 0;



            SqlParameter BranchID = new SqlParameter();
            BranchID.SqlDbType = SqlDbType.Int;
            BranchID.Value = Convert.ToInt32(((UserInfo.structUSERInfo)(SaveUSERInfo)).BranchId);
            BranchID.ParameterName = "@BranchID";
            sqlcmd.Parameters.Add(BranchID);

            SqlParameter chqdate = new SqlParameter();
            chqdate.SqlDbType = SqlDbType.VarChar;
            chqdate.Value = txtPickupDate.Text;//Convert.ToInt32(ddlClientList.SelectedItem.Value);
            chqdate.ParameterName = "@chqdate";
            sqlcmd.Parameters.Add(chqdate);

            SqlParameter ClientId = new SqlParameter();
            ClientId.SqlDbType = SqlDbType.Int;
            ClientId.Value = Convert.ToInt32(ddlClientList.SelectedIndex.ToString());
            ClientId.ParameterName = "@clientId";
            sqlcmd.Parameters.Add(ClientId);

            SqlParameter VarResult = new SqlParameter();
            VarResult.SqlDbType = SqlDbType.VarChar;
            VarResult.Value = "";//txtBatchNo.Text.Trim();
            VarResult.ParameterName = "@varSeries";
            VarResult.Size = 20;
            VarResult.Direction = ParameterDirection.Output;
            sqlcmd.Parameters.Add(VarResult);

            sqlcon.Open();
            SqlDataAdapter sqlda = new SqlDataAdapter();
            sqlda.SelectCommand = sqlcmd;

            sqlcmd.ExecuteNonQuery();

            DataTable dt2 = new DataTable();
            sqlda.Fill(dt2);
            sqlcon.Close();

            return dt2;

        }
        catch (Exception ex)
        {
            lblMessage.Visible = true;
            lblMessage.Text = ex.Message;
            lblMessage.CssClass = "ErrorMessage";
            return null;

        }
        finally
        { 
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
        { }

    }
    private DataTable Get_Datafor_MDB_Generation()
    {
        try
        {
            Object SaveUSERInfo = (Object)Session["UserInfo"];

            SqlConnection sqlcon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);

            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlcon;
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.CommandText = "Get_Datafor_MDB_Generation_datewise_clientwise4_new123";//nikhil new change 29 Nov.2013
            sqlcmd.CommandTimeout = 0;




            SqlParameter BranchID = new SqlParameter();
            BranchID.SqlDbType = SqlDbType.Int;
            BranchID.Value = Convert.ToInt32(((UserInfo.structUSERInfo)(SaveUSERInfo)).BranchId);
            BranchID.ParameterName = "@BranchID";
            sqlcmd.Parameters.Add(BranchID);

            int pClientId = 0;
            if (ddlClientList.SelectedIndex != 0)
            {
                pClientId = Convert.ToInt32(ddlClientList.SelectedItem.Value);
            }

            SqlParameter ClientID = new SqlParameter();
            ClientID.SqlDbType = SqlDbType.Int;
            ClientID.Value = pClientId;
            ClientID.ParameterName = "@ClientID";
            sqlcmd.Parameters.Add(ClientID);

            SqlParameter ChequePickeupDate_mdy = new SqlParameter();
            ChequePickeupDate_mdy.SqlDbType = SqlDbType.VarChar;
            ChequePickeupDate_mdy.Value = txtPickupDate.Text;
            ChequePickeupDate_mdy.ParameterName = "@ChequePickeupDate_mdy";
            sqlcmd.Parameters.Add(ChequePickeupDate_mdy);

            SqlParameter MDB_NameToInsert2 = new SqlParameter();
            MDB_NameToInsert2.SqlDbType = SqlDbType.VarChar;
            MDB_NameToInsert2.Value = MDB_NameToInsert;
            MDB_NameToInsert2.ParameterName = "@MDB_NameToInsert";
            sqlcmd.Parameters.Add(MDB_NameToInsert2);

            SqlParameter VarResult = new SqlParameter();
            VarResult.SqlDbType = SqlDbType.VarChar;
            VarResult.Value = "";
            VarResult.ParameterName = "@VarResult";
            sqlcmd.Parameters.Add(VarResult);

            sqlcon.Open();
            SqlDataAdapter sqlda = new SqlDataAdapter();
            sqlda.SelectCommand = sqlcmd;
            DataTable dt = new DataTable();
            sqlda.Fill(dt);
            sqlcon.Close();

            return dt;

        }
        catch (Exception ex)
        {
            lblMessage.Visible = true;
            lblMessage.Text = ex.Message;
            lblMessage.CssClass = "ErrorMessage";
            return null;

        }

        finally
        { 
        
        }
        
    }
    private void Download_MdbFile(string strFileName)
    {

            string FileNamePath = strFileName;            
            FileInfo f = new FileInfo(FileNamePath);  
            Response.AppendHeader("Content-Disposition", "attachment; filename=" + f.Name);
            
            Response.ContentType = "application/Msaccess";//"application/x-msexcel";
            Response.Flush();

            Response.WriteFile(FileNamePath.Trim(), true);

            HttpContext.Current.Response.End();
         
    }
    public string MDB_NameToInsert { get; set; }
    protected void ddlClientList_SelectedIndexChanged(object sender, EventArgs e)
    {
        lblMessage.Text = "";
        grvTransactionInfo.DataSource = null;
        grvTransactionInfo.DataBind();
       
    }
}
