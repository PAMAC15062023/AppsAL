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
using System.Data.OleDb;
using System.IO;


public partial class Pages_JFS_ImportFile : System.Web.UI.Page
{
    string strlos = string.Empty;  
    string strlos1 = string.Empty;
    string smsg = string.Empty;
    int count = 0;
    int c = 0;
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/pages/menu.aspx", true);
    }
    protected void btnupload_Click(object sender, EventArgs e)
    {
        
        try
        {
            if (xslFileUpload.HasFile)
            {
                String strPath = "";
                String MyFile = "";
                string strDateTime = DateTime.Now.ToString("ddMMyyyyhhmmss");

                strPath = Server.MapPath("~/Pages/JFS/ImportFiles/");
                MyFile = strDateTime + ".xls";
                strPath = (strPath + MyFile);
                xslFileUpload.PostedFile.SaveAs(strPath);

                string strFileName = xslFileUpload.FileName.ToString();

                FileInfo fi = new FileInfo(strFileName);
                string strExt = fi.Extension;

                if (strExt.ToLower() == ".xls")
                {
                    string strConn = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + strPath + @";Extended Properties=""Excel 8.0;IMEX=1""";

                    OleDbConnection oleCon = new OleDbConnection(strConn);
                    oleCon.Open();

                    OleDbCommand oleCom = new OleDbCommand("SELECT * FROM [sheet1$]");
                    oleCom.Connection = oleCon;

                    OleDbDataAdapter oleDA = new OleDbDataAdapter();
                    oleDA.SelectCommand = oleCom;

                    DataTable dt = new DataTable();
                    oleDA.Fill(dt);
                    oleCon.Close();

                    if (dt.Rows.Count > 0)
                    {
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            if (ddlcasetype.SelectedValue.ToString() == "1")
                            {
                                                             
                                Update_Into_upload(dt.Rows[i]);
                            }
                            else
                            {
                                Update_Into_JFS_upload(dt.Rows[i]);   
                            }
                        }
                        if (strlos != "")
                        {
                            lblMsgXls.Text += "Following LOS have not been IMPORTED :-" + " " + strlos;
                        }
                        lblMsgXls1.Text = "";
                        lblMsgXls1.Text += "IMPORTED Count" + " " + smsg;
                        //lblMsgXls.Text = "Data Import Successfully!!";

                    }
                

                string strFile = Server.MapPath("~/Pages/JFS/ImportFiles/") + MyFile;
                if (File.Exists(strFile))
                   
                {
                    File.Delete(strFile);
                }
           }
                else
                {
                    lblMsgXls.Visible = true;
                    lblMsgXls.Text = "It's Not An Excel File...!!!";
                }
            }
            else
            {
                lblMsgXls.Visible = true;
                lblMsgXls.Text = "Please Select Excel File To Import...!!!";
            }
        }
        catch (Exception ex)
        {
            lblMsgXls.Visible = true;
            lblMsgXls.Text = "Data Not Importing please check import file and Case Type";
            string error= "Error :" + ex.Message;
        }




    }

  
    protected void Update_Into_JFS_upload(DataRow dr)
    {

        Object SaveUSERInfo = (Object)Session["UserInfo"];

        SqlConnection sqlCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);

        SqlCommand sqlcmd = new SqlCommand();
        sqlcmd.Connection = sqlCon;
        sqlcmd.CommandType = CommandType.StoredProcedure;
        sqlcmd.CommandText = "sp_importQRdata_JFS12";
        sqlcmd.CommandTimeout = 0;

        SqlParameter Auto_Application_No = new SqlParameter();
        Auto_Application_No.SqlDbType = SqlDbType.VarChar;
        Auto_Application_No.Value = dr["Auto Application No"].ToString().Trim();
        Auto_Application_No.ParameterName = "@Auto_Application_No";
        sqlcmd.Parameters.Add(Auto_Application_No);

        if (dr["File Received at Agency date"].ToString().Trim() != "")
        {
            SqlParameter File_Received_at_Agency_date = new SqlParameter();
            File_Received_at_Agency_date.SqlDbType = SqlDbType.VarChar;
            File_Received_at_Agency_date.Value = dr["File Received at Agency date"].ToString().Trim();
            File_Received_at_Agency_date.ParameterName = "@File_Received_at_Agency_date";
            sqlcmd.Parameters.Add(File_Received_at_Agency_date);
        }
        else
        {
            SqlParameter File_Received_at_Agency_date = new SqlParameter();
            File_Received_at_Agency_date.SqlDbType = SqlDbType.VarChar;
            File_Received_at_Agency_date.Value = DBNull.Value;
            File_Received_at_Agency_date.ParameterName = "@File_Received_at_Agency_date";
            sqlcmd.Parameters.Add(File_Received_at_Agency_date);
        }


        SqlParameter Branch_Name = new SqlParameter();
        Branch_Name.SqlDbType = SqlDbType.VarChar;
        Branch_Name.Value = dr["Branch: Branch Name"].ToString().Trim();
        Branch_Name.ParameterName = "@Branch_Name";
        sqlcmd.Parameters.Add(Branch_Name);

        SqlParameter No_of_Customer = new SqlParameter();
        No_of_Customer.SqlDbType = SqlDbType.VarChar;
        No_of_Customer.Value = dr["No# of Customer / EFL Version"].ToString().Trim();
        No_of_Customer.ParameterName = "@No_of_Customer";
        sqlcmd.Parameters.Add(No_of_Customer);


        SqlParameter Total_Loan_Amount = new SqlParameter();
        Total_Loan_Amount.SqlDbType = SqlDbType.VarChar;
        Total_Loan_Amount.Value = dr["Total Loan Amount"].ToString().Trim();
        Total_Loan_Amount.ParameterName = "@Total_Loan_Amount";
        sqlcmd.Parameters.Add(Total_Loan_Amount);

        SqlParameter Product_Code = new SqlParameter();
        Product_Code.SqlDbType = SqlDbType.VarChar;
        Product_Code.Value = dr["Product Code"].ToString().Trim();
        Product_Code.ParameterName = "@Product_Code";
        sqlcmd.Parameters.Add(Product_Code);

        SqlParameter Modified_Date = new SqlParameter();
        Modified_Date.SqlDbType = SqlDbType.VarChar;
        Modified_Date.Value = dr["Last Modified Date Time"].ToString().Trim();
        Modified_Date.ParameterName = "@Modified_Date";
        sqlcmd.Parameters.Add(Modified_Date);

        SqlParameter Place_of_Meeting = new SqlParameter();
        Place_of_Meeting.SqlDbType = SqlDbType.VarChar;
        Place_of_Meeting.Value = dr["Place of Meeting"].ToString().Trim();
        Place_of_Meeting.ParameterName = "@Place_of_Meeting";
        sqlcmd.Parameters.Add(Place_of_Meeting);

        SqlParameter Branch_Zone_Name = new SqlParameter();
        Branch_Zone_Name.SqlDbType = SqlDbType.VarChar;
        Branch_Zone_Name.Value = dr["Branch: Region: Zone Code: Zone Name"].ToString().Trim();
        Branch_Zone_Name.ParameterName = "@Branch_Zone_Name";
        sqlcmd.Parameters.Add(Branch_Zone_Name);

        SqlParameter Branch_Region_Region_Name = new SqlParameter();
        Branch_Region_Region_Name.SqlDbType = SqlDbType.VarChar;
        Branch_Region_Region_Name.Value = dr["Branch: Region: Region Name"].ToString().Trim();
        Branch_Region_Region_Name.ParameterName = "@Branch_Region_Region_Name";
        sqlcmd.Parameters.Add(Branch_Region_Region_Name);

        SqlParameter File_Status = new SqlParameter();
        File_Status.SqlDbType = SqlDbType.VarChar;
        File_Status.Value = dr["Sub Draft Status"].ToString().Trim();
        File_Status.ParameterName = "@File_Status";
        sqlcmd.Parameters.Add(File_Status);

        SqlParameter Data_Entry_Reason = new SqlParameter();
        Data_Entry_Reason.SqlDbType = SqlDbType.VarChar;
        Data_Entry_Reason.Value = dr["On Hold Data Entry Reason"].ToString().Trim();
        Data_Entry_Reason.ParameterName = "@Data_Entry_Reason";
        sqlcmd.Parameters.Add(Data_Entry_Reason);

        SqlParameter Application_Status = new SqlParameter();
        Application_Status.SqlDbType = SqlDbType.VarChar;
        Application_Status.Value = dr["Application Status"].ToString().Trim();
        Application_Status.ParameterName = "@Application_Status";
        sqlcmd.Parameters.Add(Application_Status);

        //////////////////
        SqlParameter OnHold_Reason = new SqlParameter();
        OnHold_Reason.SqlDbType = SqlDbType.VarChar;
        OnHold_Reason.Value = dr["On - Hold Reason"].ToString().Trim();
        OnHold_Reason.ParameterName = "@OnHold_Reason";
        sqlcmd.Parameters.Add(OnHold_Reason);

        SqlParameter Grp_Credit_Bureau_Status = new SqlParameter();
        Grp_Credit_Bureau_Status.SqlDbType = SqlDbType.VarChar;
        Grp_Credit_Bureau_Status.Value = dr["Group Credit Bureau Status"].ToString().Trim();
        Grp_Credit_Bureau_Status.ParameterName = "@Grp_Credit_Bureau_Status";
        sqlcmd.Parameters.Add(Grp_Credit_Bureau_Status);

        SqlParameter Created_Date = new SqlParameter();
        Created_Date.SqlDbType = SqlDbType.VarChar;
        Created_Date.Value = dr["Created Date"].ToString().Trim();
        Created_Date.ParameterName = "@Created_Date";
        sqlcmd.Parameters.Add(Created_Date);

        SqlParameter Loan_Amount = new SqlParameter();
        Loan_Amount.SqlDbType = SqlDbType.VarChar;
        Loan_Amount.Value = dr["Loan Amount"].ToString().Trim();
        Loan_Amount.ParameterName = "@Loan_Amount";
        sqlcmd.Parameters.Add(Loan_Amount);

        SqlParameter Branch_Respo = new SqlParameter();
        Branch_Respo.SqlDbType = SqlDbType.VarChar;
        Branch_Respo.Value = dr["Branch Response"].ToString().Trim();
        Branch_Respo.ParameterName = "@Branch_Respo";
        sqlcmd.Parameters.Add(Branch_Respo);

        SqlParameter modifiyed_by = new SqlParameter();
        modifiyed_by.SqlDbType = SqlDbType.VarChar;
        modifiyed_by.Value = dr["Last Modified By: Full Name"].ToString().Trim();
        modifiyed_by.ParameterName = "@Modified_by";
        sqlcmd.Parameters.Add(modifiyed_by);

        SqlParameter branch_code = new SqlParameter();
        branch_code.SqlDbType = SqlDbType.VarChar;
        branch_code.Value = dr["Branch: Branch Code"].ToString().Trim();
        branch_code.ParameterName = "@branch_code";
        sqlcmd.Parameters.Add(branch_code);

        //////////////////////////////////////////////

        SqlParameter user = new SqlParameter();
        user.SqlDbType = SqlDbType.VarChar;
        user.Value = Convert.ToString(((UserInfo.structUSERInfo)(SaveUSERInfo)).UserId);
        user.ParameterName = "@upload_by";
        sqlcmd.Parameters.Add(user);

        sqlCon.Open();
        int RowEffected = 0;

        RowEffected = sqlcmd.ExecuteNonQuery();

        sqlCon.Close();
        if (RowEffected > 0)
        {
            lblMsgXls.Visible = true;
            count++;

            smsg = Convert.ToString(count);
        }
        else
        {
            SqlCommand sqlCom = new SqlCommand();
            sqlCom.Connection = sqlCon;
            sqlCom.CommandType = CommandType.StoredProcedure;
            sqlCom.CommandText = "check_appno_jfs";
            sqlCom.CommandTimeout = 0;

            SqlParameter BranchId = new SqlParameter();
            BranchId.SqlDbType = SqlDbType.VarChar;
            BranchId.Value = dr["Auto Application No"].ToString().Trim();
            BranchId.ParameterName = "@Auto_Application_No";
            sqlCom.Parameters.Add(BranchId);

            sqlCon.Open();

            SqlDataAdapter sqlDA = new SqlDataAdapter();
            sqlDA.SelectCommand = sqlCom;

            DataTable dt = new DataTable();
            sqlDA.Fill(dt);
            sqlCon.Close();


            if (dt.Rows.Count > 0)
            {
                c++;
                strlos1 = Convert.ToString(c);

                lblMsgXls.Visible = true;
                lblMsgXls.Text = "Please Check Import File!!!!!!!!!!!!";
            }
            else
            {
                strlos += dr["Auto Application No"].ToString().Trim() + " --  ";
            }

        }

    }


    public string strDate(string strInDate)
    {
        string strDD = strInDate.Substring(0, 2);

        string strMM = strInDate.Substring(3, 2);

        string strYYYY = strInDate.Substring(6, 4);

        string strhh = strInDate.Substring(11, 2);

        string strmmm = strInDate.Substring(14, 2);

        string strss = strInDate.Substring(17, 2);

        string strMMDDYYYY = strMM + "/" + strDD + "/" + strYYYY + " " + strhh + ":" + strmmm + ":" + strss;

        DateTime dtConvertDate = Convert.ToDateTime(strMMDDYYYY);

        string strOutDate = dtConvertDate.ToString("dd-MMM-yyyy HH:mm:ss");

        return strOutDate;
    }

   
    protected void Update_Into_upload(DataRow dr)
    {

        Object SaveUSERInfo = (Object)Session["UserInfo"];

        SqlConnection sqlCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);

        SqlCommand sqlcmd = new SqlCommand();
        sqlcmd.Connection = sqlCon;
        sqlcmd.CommandType = CommandType.StoredProcedure;
        sqlcmd.CommandText = "sp_importdata_JFS";
        sqlcmd.CommandTimeout = 0;

        SqlParameter Auto_Application_No = new SqlParameter();
        Auto_Application_No.SqlDbType = SqlDbType.VarChar;
        Auto_Application_No.Value = dr["Auto Application No"].ToString().Trim();
        Auto_Application_No.ParameterName = "@Auto_Application_No";
        sqlcmd.Parameters.Add(Auto_Application_No);


        if (dr["Receive Date From Sales / EFL Date"].ToString() != "")
        {

            SqlParameter Receive_Date_From_Sales_date = new SqlParameter();
            Receive_Date_From_Sales_date.SqlDbType = SqlDbType.VarChar;
            Receive_Date_From_Sales_date.Value =dr["Receive Date From Sales / EFL Date"].ToString().Trim();
            Receive_Date_From_Sales_date.ParameterName = "@Receive_Date_From_Sales_date";
            sqlcmd.Parameters.Add(Receive_Date_From_Sales_date);
        }
        else{

            SqlParameter Receive_Date_From_Sales_date = new SqlParameter();
            Receive_Date_From_Sales_date.SqlDbType = SqlDbType.VarChar;
            Receive_Date_From_Sales_date.Value = DBNull.Value;
            Receive_Date_From_Sales_date.ParameterName = "@Receive_Date_From_Sales_date";
            sqlcmd.Parameters.Add(Receive_Date_From_Sales_date);



        }

        if (dr["Verified Date"].ToString() != "")
        {
            SqlParameter Verified_Date = new SqlParameter();
            Verified_Date.SqlDbType = SqlDbType.VarChar;
            Verified_Date.Value =  dr["Verified Date"].ToString().Trim();
            Verified_Date.ParameterName = "@Verified_Date";
            sqlcmd.Parameters.Add(Verified_Date);
        }
        else
        {

            SqlParameter Verified_Date = new SqlParameter();
            Verified_Date.SqlDbType = SqlDbType.VarChar;
            Verified_Date.Value = DBNull.Value;
            Verified_Date.ParameterName = "@Verified_Date";
            sqlcmd.Parameters.Add(Verified_Date);

        }


        if (dr["Dispatch To agency Date"].ToString() != "")
        {
            SqlParameter Dispatch_To_agency_Date = new SqlParameter();
            Dispatch_To_agency_Date.SqlDbType = SqlDbType.VarChar;
            Dispatch_To_agency_Date.Value = dr["Dispatch To agency Date"].ToString().Trim();
            Dispatch_To_agency_Date.ParameterName = "@Dispatch_To_agency_Date";
            sqlcmd.Parameters.Add(Dispatch_To_agency_Date);
        }
        else
        {

            SqlParameter Dispatch_To_agency_Date = new SqlParameter();
            Dispatch_To_agency_Date.SqlDbType = SqlDbType.VarChar;
            Dispatch_To_agency_Date.Value = DBNull.Value;
            Dispatch_To_agency_Date.ParameterName = "@Dispatch_To_agency_Date";
            sqlcmd.Parameters.Add(Dispatch_To_agency_Date);
        
        }



        if (dr["File Received at Agency date"].ToString() != "")
        {
            SqlParameter File_Received_at_Agency_date = new SqlParameter();
            File_Received_at_Agency_date.SqlDbType = SqlDbType.VarChar;
            File_Received_at_Agency_date.Value = dr["File Received at Agency date"].ToString().Trim();
            File_Received_at_Agency_date.ParameterName = "@File_Received_at_Agency_date";
            sqlcmd.Parameters.Add(File_Received_at_Agency_date);
        }
        else
        {


            SqlParameter File_Received_at_Agency_date = new SqlParameter();
            File_Received_at_Agency_date.SqlDbType = SqlDbType.VarChar;
            File_Received_at_Agency_date.Value = DBNull.Value;
            File_Received_at_Agency_date.ParameterName = "@File_Received_at_Agency_date";
            sqlcmd.Parameters.Add(File_Received_at_Agency_date);
    }

        SqlParameter Branch_Name = new SqlParameter();
        Branch_Name.SqlDbType = SqlDbType.VarChar;
        Branch_Name.Value = dr["Branch: Branch Name"].ToString().Trim();
        Branch_Name.ParameterName = "@Branch_Name";
        sqlcmd.Parameters.Add(Branch_Name);

        SqlParameter Area_Name = new SqlParameter();
        Area_Name.SqlDbType = SqlDbType.VarChar;
        Area_Name.Value = dr["Area: Area Name"].ToString().Trim();
        Area_Name.ParameterName = "@Area_Name";
        sqlcmd.Parameters.Add(Area_Name);

        SqlParameter Place_of_Meeting = new SqlParameter();
        Place_of_Meeting.SqlDbType = SqlDbType.VarChar;
        Place_of_Meeting.Value = dr["Place of Meeting"].ToString().Trim();
        Place_of_Meeting.ParameterName = "@Place_of_Meeting";
        sqlcmd.Parameters.Add(Place_of_Meeting);

        SqlParameter Meeting_Center_Code = new SqlParameter();
        Meeting_Center_Code.SqlDbType = SqlDbType.NVarChar;
        Meeting_Center_Code.Value = dr["Meeting Center Code"].ToString().Trim();
        Meeting_Center_Code.ParameterName = "@Meeting_Center_Code";
        sqlcmd.Parameters.Add(Meeting_Center_Code);

        SqlParameter No_of_Customer = new SqlParameter();
        No_of_Customer.SqlDbType = SqlDbType.Int;
        No_of_Customer.Value = dr["No# of Customer / EFL Version"].ToString().Trim();
        No_of_Customer.ParameterName = "@No_of_Customer";
        sqlcmd.Parameters.Add(No_of_Customer);


        SqlParameter Total_Loan_Amount = new SqlParameter();
        Total_Loan_Amount.SqlDbType = SqlDbType.Int;
        Total_Loan_Amount.Value = dr["Total Loan Amount"].ToString().Trim();
        Total_Loan_Amount.ParameterName = "@Total_Loan_Amount";
        sqlcmd.Parameters.Add(Total_Loan_Amount);

        SqlParameter Product_Code = new SqlParameter();
        Product_Code.SqlDbType = SqlDbType.Int;
        Product_Code.Value = dr["Product Code"].ToString().Trim();
        Product_Code.ParameterName = "@Product_Code";
        sqlcmd.Parameters.Add(Product_Code);


        if (dr["Last Modified Date"].ToString() != "")
        {
            SqlParameter Modified_Date = new SqlParameter();
            Modified_Date.SqlDbType = SqlDbType.VarChar;
            Modified_Date.Value = dr["Last Modified Date"].ToString().Trim();
            Modified_Date.ParameterName = "@Modified_Date";
            sqlcmd.Parameters.Add(Modified_Date);
        }
        else
        {
            SqlParameter Modified_Date = new SqlParameter();
            Modified_Date.SqlDbType = SqlDbType.VarChar;
            Modified_Date.Value = DBNull.Value;
            Modified_Date.ParameterName = "@Modified_Date";
            sqlcmd.Parameters.Add(Modified_Date);
        }

        SqlParameter Modified_by = new SqlParameter();
        Modified_by.SqlDbType = SqlDbType.VarChar;
        Modified_by.Value = dr["Last Modified By: Full Name"].ToString().Trim();
        Modified_by.ParameterName = "@Modified_by";
        sqlcmd.Parameters.Add(Modified_by);

        SqlParameter Branch_Zone_Name = new SqlParameter();
        Branch_Zone_Name.SqlDbType = SqlDbType.VarChar;
        Branch_Zone_Name.Value = dr["Branch: Region: Zone Code: Zone Name"].ToString().Trim();
        Branch_Zone_Name.ParameterName = "@Branch_Zone_Name";
        sqlcmd.Parameters.Add(Branch_Zone_Name);

        SqlParameter Branch_Region_Region_Name = new SqlParameter();
        Branch_Region_Region_Name.SqlDbType = SqlDbType.VarChar;
        Branch_Region_Region_Name.Value = dr["Branch: Region: Region Name"].ToString().Trim();
        Branch_Region_Region_Name.ParameterName = "@Branch_Region_Region_Name";
        sqlcmd.Parameters.Add(Branch_Region_Region_Name);

        SqlParameter File_Status = new SqlParameter();
        File_Status.SqlDbType = SqlDbType.VarChar;
        File_Status.Value = dr["File Status?"].ToString().Trim();
        File_Status.ParameterName = "@File_Status";
        sqlcmd.Parameters.Add(File_Status);

        SqlParameter Data_Entry_Reason = new SqlParameter();
        Data_Entry_Reason.SqlDbType = SqlDbType.VarChar;
        Data_Entry_Reason.Value = dr["On Hold Data Entry Reason"].ToString().Trim();
        Data_Entry_Reason.ParameterName = "@Data_Entry_Reason";
        sqlcmd.Parameters.Add(Data_Entry_Reason);

        SqlParameter Application_Status = new SqlParameter();
        Application_Status.SqlDbType = SqlDbType.VarChar;
        Application_Status.Value = dr["Application Status"].ToString().Trim();
        Application_Status.ParameterName = "@Application_Status";
        sqlcmd.Parameters.Add(Application_Status);

        SqlParameter branch_code = new SqlParameter();
        branch_code.SqlDbType = SqlDbType.VarChar;
        branch_code.Value = dr["Branch Code"].ToString().Trim();
        branch_code.ParameterName = "@branch_code";
        sqlcmd.Parameters.Add(branch_code);

        SqlParameter user = new SqlParameter();
        user.SqlDbType = SqlDbType.VarChar;
        user.Value = Convert.ToString(((UserInfo.structUSERInfo)(SaveUSERInfo)).UserId);
        user.ParameterName = "@upload_by";
        sqlcmd.Parameters.Add(user);


        sqlCon.Open();
        int RowEffected = 0;

        RowEffected = sqlcmd.ExecuteNonQuery();

        sqlCon.Close();
        if (RowEffected > 0)
        {
            lblMsgXls.Visible = true;
            count++;

            smsg = Convert.ToString(count);
        }
        else
        {
            SqlCommand sqlCom = new SqlCommand();
            sqlCom.Connection = sqlCon;
            sqlCom.CommandType = CommandType.StoredProcedure;
            sqlCom.CommandText = "check_appno_jfs";
            sqlCom.CommandTimeout = 0;

            SqlParameter BranchId = new SqlParameter();
            BranchId.SqlDbType = SqlDbType.VarChar;
            BranchId.Value = dr["Auto Application No"].ToString().Trim();
            BranchId.ParameterName = "@Auto_Application_No";
            sqlCom.Parameters.Add(BranchId);

            sqlCon.Open();

            SqlDataAdapter sqlDA = new SqlDataAdapter();
            sqlDA.SelectCommand = sqlCom;

            DataTable dt = new DataTable();
            sqlDA.Fill(dt);
            sqlCon.Close();


            if (dt.Rows.Count > 0)
            {
                c++;
                strlos1 = Convert.ToString(c);

                lblMsgXls.Visible = true;
                lblMsgXls.Text = "Please Check Import File!!!!!!!!!!!!";
            }
            else
            {
                strlos += dr["Auto Application No"].ToString().Trim() + " --  ";
            }

        }

    }
   

}


