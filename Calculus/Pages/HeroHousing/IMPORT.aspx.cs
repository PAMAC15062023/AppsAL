using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data.OleDb;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class Pages_HeroHousing_IMPORT : System.Web.UI.Page
{
    bool isvaliddata = false;
    bool isError = false;
    string DateFormat = string.Empty;
    string strlos = string.Empty;
    string strlos1 = string.Empty;
    string strlos2 = string.Empty;
    string smsg = string.Empty;
    string AllMessage = "";
    int count = 0;
    int c = 0;
    string app;
    int k;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            GetBranch();
        }

    }
    //public string strDateFunc(string strInDate)
    //{
    //    try
    //    {
    //        string[] timeFormats = { 
    //                "MM/dd/yyyy hh:mm:ss tt",
    //                "MM/dd/yyyy HH:mm:ss tt",
    //                "MM/d/yyyy HH:mm:ss tt",
    //                "MM/d/yyyy hh:mm:ss tt",
    //                "MM/d/yyyy HH:mm:ss tt",
    //                "MM/d/yyyy hh:mm:ss tt",
    //                "M/d/yyyy hh:mm:ss tt",
    //                "M/d/yyyy HH:mm:ss tt",
    //                "MM/dd/yyyy",
    //                "MM/d/yyyy",
    //                "MM/d/yyyy",
    //                "M/d/yyyy",

    //                //function for not Am:PM-- data table issue



    //                //function for " - "

    //                "MM-dd-yyyy hh:mm:ss tt",
    //                "MM-dd-yyyy HH:mm:ss tt",
    //                "M-dd-yyyy HH:mm:ss tt",
    //                "M-dd-yyyy hh:mm:ss tt",
    //                "MM-d-yyyy HH:mm:ss tt",
    //                "MM-d-yyyy hh:mm:ss tt",
    //                "M-d-yyyy hh:mm:ss tt",
    //                "M-d-yyyy HH:mm:ss tt",
    //                "MM-dd-yyyy",
    //                "M-dd-yyyy",
    //                "MM-d-yyyy",
    //                "M-d-yyyy",

    //                "dd-MMM-yy",
    //                "d-MMM-yy",
    //                "d-MMM-yyyy",
    //                "d-MMM-yyyy",

    //                //hh::mm
    //                "MM/dd/yyyy hh:mm tt",
    //                "MM/dd/yyyy HH:mm tt",
    //                "MM/d/yyyy HH:mm tt",
    //                "MM/d/yyyy hh:mm tt",
    //                "MM/d/yyyy HH:mm tt",
    //                "MM/d/yyyy hh:mm tt",
    //                "M/d/yyyy hh:mm tt",
    //                "M/d/yyyy HH:mm tt",

    //                //function for not Am:PM-- data table issue
    //                "MM/dd/yyyy hh:mm",
    //                "MM/dd/yyyy HH:mm",
    //                "MM/d/yyyy HH:mm",
    //                "MM/d/yyyy hh:mm",
    //                "MM/d/yyyy HH:mm",
    //                "MM/d/yyyy hh:mm",
    //                "M/d/yyyy hh:mm",
    //                "M/d/yyyy HH:mm",



    //                //function for " - "

    //                "MM-dd-yyyy hh:mm tt",
    //                "MM-dd-yyyy HH:mm tt",
    //                "M-dd-yyyy HH:mm tt",
    //                "M-dd-yyyy hh:mm tt",
    //                "MM-d-yyyy HH:mm tt",
    //                "MM-d-yyyy hh:mm tt",
    //                "M-d-yyyy hh:mm tt",
    //                "M-d-yyyy HH:mm tt",

    //                "MM-dd-yyyy hh:mm",
    //                "MM-dd-yyyy HH:mm",
    //                "M-dd-yyyy HH:mm",
    //                "M-dd-yyyy hh:mm",
    //                "MM-d-yyyy HH:mm",
    //                "MM-d-yyyy hh:mm",
    //                "M-d-yyyy hh:mm",
    //                "M-d-yyyy HH:mm",



    //                //Time Slot
    //                "MM/dd/yyyy h:mm:ss tt",
    //                "MM/dd/yyyy H:mm:ss tt",
    //                "MM/d/yyyy h:mm:ss tt",
    //                "MM/d/yyyy H:mm:ss tt",
    //                "MM/d/yyyy h:mm:ss tt",
    //                "MM/d/yyyy H:mm:ss tt",
    //                "M/d/yyyy h:mm:ss tt",
    //                "M/d/yyyy H:mm:ss tt",
    //                "MM/dd/yyyy",
    //                "MM/d/yyyy",
    //                "MM/d/yyyy",
    //                "M/d/yyyy",


    //                   //function for " - "
    //                "MM-dd-yyyy h:mm:ss tt",
    //                "MM-dd-yyyy H:mm:ss tt",
    //                "M-dd-yyyy h:mm:ss tt",
    //                "M-dd-yyyy H:mm:ss tt",
    //                "MM-d-yyyy h:mm:ss tt",
    //                "MM-d-yyyy H:mm:ss tt",
    //                "M-d-yyyy h:mm:ss tt",
    //                "M-d-yyyy H:mm:ss tt",
    //                "MM-dd-yyyy",
    //                "M-dd-yyyy",
    //                "MM-d-yyyy",
    //                "M-d-yyyy",

    //                 //hh::mm
    //                "MM/dd/yyyy h:mm tt",
    //                "MM/dd/yyyy H:mm tt",
    //                "MM/d/yyyy h:mm tt",
    //                "MM/d/yyyy H:mm tt",
    //                "MM/d/yyyy h:mm tt",
    //                "MM/d/yyyy H:mm tt",
    //                "M/d/yyyy h:mm tt",
    //                "M/d/yyyy H:mm tt",


    //                "MM/dd/yyyy h:mm",
    //                "MM/dd/yyyy H:mm",
    //                "MM/d/yyyy h:mm",
    //                "MM/d/yyyy H:mm",
    //                "MM/d/yyyy h:mm",
    //                "MM/d/yyyy H:mm",
    //                "M/d/yyyy h:mm",
    //                "M/d/yyyy H:mm",


    //                //function for " - "

    //                "MM-dd-yyyy h:mm tt",
    //                "MM-dd-yyyy H:mm tt",
    //                "M-dd-yyyy h:mm tt",
    //                "M-dd-yyyy H:mm tt",
    //                "MM-d-yyyy h:mm tt",
    //                "MM-d-yyyy H:mm tt",
    //                "M-d-yyyy h:mm tt",
    //                "M-d-yyyy H:mm tt",
    //                "MM-dd-yyyy",
    //                "M-dd-yyyy",
    //                "MM-d-yyyy",
    //                "M-d-yyyy",

    //                "MM-dd-yyyy h:mm",
    //                "MM-dd-yyyy H:mm",
    //                "M-dd-yyyy h:mm",
    //                "M-dd-yyyy H:mm",
    //                "MM-d-yyyy h:mm",
    //                "MM-d-yyyy H:mm",
    //                "M-d-yyyy h:mm",
    //                "M-d-yyyy H:mm"

    //        };

    //        String date = strInDate.Trim();
    //        // DateTime datenew = DateTime.ParseExact(date, "M/d/yyyy", System.Globalization.CultureInfo.InvariantCulture);
    //        DateTime datenew1 = DateTime.ParseExact(date, timeFormats, null, System.Globalization.DateTimeStyles.None);

    //        string Datenewone = Convert.ToString(datenew1.ToShortDateString());
    //        string Datenewone1 = Convert.ToString(datenew1.ToLongTimeString());
    //        return Datenewone + " " + Datenewone1;
    //    }
    //    catch (Exception ex)
    //    {
    //        return DateFormat = "DatetimeFormate";
    //    }
    //}
    public string strDateFunc(string strInDate)
    {
        try
        {
            string[] timeFormats = { 
                    "dd/MM/yyyy hh:mm:ss tt",
                    "dd/MM/yyyy HH:mm:ss tt",
                    "d/MM/yyyy HH:mm:ss tt",
                    "d/MM/yyyy hh:mm:ss tt",
                    "d/MM/yyyy HH:mm:ss tt",
                    "d/MM/yyyy hh:mm:ss tt",
                    "d/M/yyyy hh:mm:ss tt",
                    "d/M/yyyy HH:mm:ss tt",
                    "dd/MM/yyyy",
                    "d/MM/yyyy",
                    "d/MM/yyyy",
                    "d/M/yyyy",

                    //function for not Am:PM-- data table issue

                    

                    //function for " - "

                    "dd-MM-yyyy hh:mm:ss tt",
                    "dd-MM-yyyy HH:mm:ss tt",
                    "dd-M-yyyy HH:mm:ss tt",
                    "dd-M-yyyy hh:mm:ss tt",
                    "d-MM-yyyy HH:mm:ss tt",
                    "d-MM-yyyy hh:mm:ss tt",
                    "d-M-yyyy hh:mm:ss tt",
                    "d-M-yyyy HH:mm:ss tt",
                    "dd-MM-yyyy",
                    "dd-M-yyyy",
                    "d-MM-yyyy",
                    "d-M-yyyy",
                    
                    "MMM-dd-yy",
                    "MMM-d-yy",
                    "MMM-d-yyyy",
                    "MMM-d-yyyy",

                    //hh::mm
                    "dd/MM/yyyy hh:mm tt",
                    "dd/MM/yyyy HH:mm tt",
                    "d/MM/yyyy HH:mm tt",
                    "d/MM/yyyy hh:mm tt",
                    "d/MM/yyyy HH:mm tt",
                    "d/MM/yyyy hh:mm tt",
                    "d/M/yyyy hh:mm tt",
                    "d/M/yyyy HH:mm tt",

                    //function for not Am:PM-- data table issue
                    "dd/MM/yyyy hh:mm",
                    "dd/MM/yyyy HH:mm",
                    "d/M/yyyy HH:mm",
                    "d/MM/yyyy hh:mm",
                    "d/MM/yyyy HH:mm",
                    "d/MM/yyyy hh:mm",
                    "d/M/yyyy hh:mm",
                    "d/M/yyyy HH:mm",



                    //function for " - "

                    "dd-MM-yyyy hh:mm tt",
                    "dd-MM-yyyy HH:mm tt",
                    "dd-M-yyyy HH:mm tt",
                    "dd-M-yyyy hh:mm tt",
                    "d-MM-yyyy HH:mm tt",
                    "d-MM-yyyy hh:mm tt",
                    "d-M-yyyy hh:mm tt",
                    "d-M-yyyy HH:mm tt",

                    "dd-MM-yyyy hh:mm",
                    "dd-MM-yyyy HH:mm",
                    "dd-M-yyyy HH:mm",
                    "dd-M-yyyy hh:mm",
                    "d-MM-yyyy HH:mm",
                    "d-MM-yyyy hh:mm",
                    "d-M-yyyy hh:mm",
                    "d-M-yyyy HH:mm",



                    //Time Slot
                    "dd/MM/yyyy h:mm:ss tt",
                    "dd/MM/yyyy H:mm:ss tt",
                    "d/MM/yyyy h:mm:ss tt",
                    "d/MM/yyyy H:mm:ss tt",
                    "d/MM/yyyy h:mm:ss tt",
                    "d/MM/yyyy H:mm:ss tt",
                    "d/M/yyyy h:mm:ss tt",
                    "d/M/yyyy H:mm:ss tt",
                    "dd/MM/yyyy",
                    "d/MM/yyyy",
                    "d/MM/yyyy",
                    "d/M/yyyy",


                       //function for " - "
                    "dd-MM-yyyy h:mm:ss tt",
                    "dd-MM-yyyy H:mm:ss tt",
                    "dd-M-yyyy h:mm:ss tt",
                    "dd-M-yyyy H:mm:ss tt",
                    "d-MM-yyyy h:mm:ss tt",
                    "d-MM-yyyy H:mm:ss tt",
                    "d-M-yyyy h:mm:ss tt",
                    "d-M-yyyy H:mm:ss tt",
                    "dd-MM-yyyy",
                    "dd-M-yyyy",
                    "d-MM-yyyy",
                    "d-M-yyyy",

                     //hh::mm
                    "dd/MM/yyyy h:mm tt",
                    "dd/MM/yyyy H:mm tt",
                    "d/MM/yyyy h:mm tt",
                    "d/MM/yyyy H:mm tt",
                    "dd/MM/yyyy h:mm tt",
                    "d/MM/yyyy H:mm tt",
                    "d/M/yyyy h:mm tt",
                    "d/M/yyyy H:mm tt",
                  

                    "dd/MM/yyyy h:mm",
                    "dd/MM/yyyy H:mm",
                    "d/MM/yyyy h:mm",
                    "d/MM/yyyy H:mm",
                    "d/MM/yyyy h:mm",
                    "d/MM/yyyy H:mm",
                    "d/M/yyyy h:mm",
                    "d/M/yyyy H:mm",


                    //function for " - "
                   
                    "dd-MM-yyyy h:mm tt",
                    "dd-MM-yyyy H:mm tt",
                    "dd-M-yyyy h:mm tt",
                    "dd-M-yyyy H:mm tt",
                    "d-MM-yyyy h:mm tt",
                    "d-MM-yyyy H:mm tt",
                    "d-M-yyyy h:mm tt",
                    "d-M-yyyy H:mm tt",
                    "dd-MM-yyyy",
                    "dd-M-yyyy",
                    "d-MM-yyyy",
                    "d-M-yyyy",

                    "dd-MM-yyyy h:mm",
                    "dd-MM-yyyy H:mm",
                    "dd-M-yyyy h:mm",
                    "dd-M-yyyy H:mm",
                    "d-MM-yyyy h:mm",
                    "d-MM-yyyy H:mm",
                    "d-M-yyyy h:mm",
                    "d-M-yyyy H:mm"

            };

            String date = strInDate.Trim();
            // DateTime datenew = DateTime.ParseExact(date, "M/d/yyyy", System.Globalization.CultureInfo.InvariantCulture);
            DateTime datenew1 = DateTime.ParseExact(date, timeFormats, null, System.Globalization.DateTimeStyles.None);

            string Datenewone = Convert.ToString(datenew1.ToShortDateString());
            string Datenewone1 = Convert.ToString(datenew1.ToLongTimeString());
            return Datenewone + " " + Datenewone1;
        }
        catch (Exception ex)
        {
            return DateFormat = "DatetimeFormate";
        }
    }
    public void GetBranch()
    {
        Object SaveUSERInfo = (Object)Session["UserInfo"];

        SqlConnection sqlCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);
        try
        {

            sqlCon.Open();
            SqlCommand command = new SqlCommand("Get_AllBranchList", sqlCon);
            command.CommandType = CommandType.StoredProcedure;

            SqlDataAdapter da = new SqlDataAdapter(command);
            DataTable dt = new DataTable();
            da.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                ddlBranch.DataSource = dt;
                ddlBranch.DataTextField = "BranchName";
                ddlBranch.DataValueField = "BranchId";

                ddlBranch.DataBind();

                ddlBranch.Items.Insert(0, new ListItem("Select"));
                ddlBranch.SelectedIndex = 0;
            }


        }
        catch (Exception)
        {

            throw;
        }
    }
    protected void btnImport_Click(object sender, EventArgs e)
    {
        try
        {
            if (xslFileUpload.HasFile)
            {
                String strPath = "";
                String MyFile = "";
                string strDateTime = DateTime.Now.ToString("ddMMyyyyhhmmss");

                strPath = Server.MapPath("~/Pages/HeroHousing/files/");
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
                            if (ddlBranch.SelectedItem.Value != "0")
                            {
                                insertRecord(dt.Rows[i]);
                            }
                            else
                            {
                                hiddenResult.Value = "Kindly Select Import Type.....!!!!";
                                return;
                            }

                        }

                        //hiddenResult.Value += "Following ID have not been IMPORTED :-" + " " + strlos1 + " <br/>  " + "Data Import Successfully!! Total Count : " + smsg;

                        if (isvaliddata)
                        {
                            AllMessage += "Data Import Successfully!! Total Count : " + smsg + "</br>" + "</br>";
                        }
                        if (isError)
                        {
                            AllMessage += "Following App Number Already Exists or check stage start time :-" + "" + strlos1 + "</br>" + "</br>";
                        }
                        if (isvaliddata || isError)
                        {
                            hiddenResult.Value = AllMessage;
                        }

                        //lblMsgXls1.Text += "IMPORTED Count" + " " + smsg;
                        //string smsg = Convert.ToString(dt.Rows.Count);
                        //hiddenResult.Value = "Data Import Successfully!! Total Count :" + smsg;
                    }
                    string strFile = Server.MapPath("~/Pages/JFS/ImportFiles/") + MyFile;
                    if (File.Exists(strFile))
                    {
                        File.Delete(strFile);
                    }
                }
                else
                {
                    hiddenResult.Value = "It's Not An Excel File...!!!";
                    return;
                }

            }
            else
            {
                hiddenResult.Value = "Please Select Excel File To Import...!!!";
                return;
            }
        }
        catch (Exception ex)
        {
            hiddenResult.Value = "Error :" + ex.Message;
            return;
        }

    }
    //public void insertRecord(DataRow dr)
    //{

    //    Object SaveUSERInfo = (Object)Session["UserInfo"];

    //    SqlConnection sqlconn = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);

    //    try
    //    {
    //        SqlCommand sqlcmd = new SqlCommand("SpInsertDataHeroHusing", sqlconn);
    //        sqlcmd.CommandType = CommandType.StoredProcedure;
    //        sqlcmd.CommandTimeout = 0;

    //        if (dr["Loan_App_No"].ToString().Trim() != "" && dr["Sub_Stage_Start_Time"].ToString().Trim() != "" && dr["FTNR_Check"].ToString().Trim()!="")
    //        {
    //            sqlcmd.Parameters.AddWithValue("@Loan_App_No", dr["Loan_App_No"].ToString().Trim());
    //            sqlcmd.Parameters.AddWithValue("@LMS_Application_ID", dr["LMS_Application_ID"].ToString().Trim());
    //            sqlcmd.Parameters.AddWithValue("@Application_Form_Number", dr["Application_Form_Number"].ToString().Trim());
    //            sqlcmd.Parameters.AddWithValue("@LOB", dr["LOB"].ToString().Trim());
    //            sqlcmd.Parameters.AddWithValue("@Branch", dr["Branch"].ToString().Trim());
    //            sqlcmd.Parameters.AddWithValue("@Product_Scheme", dr["Product_Scheme"].ToString().Trim());
    //            sqlcmd.Parameters.AddWithValue("@Transaction_Type",dr["Transaction_Type"].ToString().Trim());
    //            sqlcmd.Parameters.AddWithValue("@Approved_ROI",dr["Approved_ROI"].ToString().Trim());
    //            sqlcmd.Parameters.AddWithValue("@Approved_Loan_Amount",dr["Approved_Loan_Amount"].ToString().Trim());
    //            sqlcmd.Parameters.AddWithValue("@Approved_Cross_Sell_Amount",dr["Approved_Cross_Sell_Amount"].ToString().Trim());
    //            sqlcmd.Parameters.AddWithValue("@Approved_Processing_Fees",dr["Approved_Processing_Fees"].ToString().Trim());
    //            sqlcmd.Parameters.AddWithValue("@Disbursement_Date",dr["Disbursement_Date"].ToString().Trim());
    //            sqlcmd.Parameters.AddWithValue("@Disbursal_Amount",dr["Disbursal_Amount"].ToString().Trim());
    //            sqlcmd.Parameters.AddWithValue("@Credit_Manager",dr["Credit_Manager"].ToString().Trim());
    //            sqlcmd.Parameters.AddWithValue("@Applicant_Customer_segment",dr["Applicant_Customer_segment"].ToString().Trim());
    //            sqlcmd.Parameters.AddWithValue("@Segment",dr["Segment"].ToString().Trim());
    //            sqlcmd.Parameters.AddWithValue("@Requested_Loan_Amount",dr["Requested_Loan_Amount"].ToString().Trim());
    //            sqlcmd.Parameters.AddWithValue("@Loan_Application_Number",dr["Loan_Application_Number"].ToString().Trim());
    //            sqlcmd.Parameters.AddWithValue("@Customer_Customer_Name",dr["Customer_Customer_Name"].ToString().Trim());
    //            sqlcmd.Parameters.AddWithValue("@Stage",dr["Stage"].ToString().Trim());
    //            sqlcmd.Parameters.AddWithValue("@Sub_Stage",dr["Sub_Stage"].ToString().Trim());
    //            sqlcmd.Parameters.AddWithValue("@Previous_Sub_Stage",dr["Previous_Sub_Stage"].ToString().Trim());
    //            sqlcmd.Parameters.AddWithValue("@SM_CBM",dr["SM_CBM"].ToString().Trim());
    //            sqlcmd.Parameters.AddWithValue("@Loan_Application_Created_By",dr["Loan_Application_Created_By"].ToString().Trim());
    //            sqlcmd.Parameters.AddWithValue("@Sum_of_IMD",dr["Sum_of_IMD"].ToString().Trim());
    //            sqlcmd.Parameters.AddWithValue("@Login_Date",dr["Login_Date"].ToString().Trim());
    //            sqlcmd.Parameters.AddWithValue("@Sub_Stage_Start_Time",strDateFunc(dr["Sub_Stage_Start_Time"].ToString().Trim()));
    //            sqlcmd.Parameters.AddWithValue("@FTNR_Check",dr["FTNR_Check"].ToString().Trim());
    //            sqlcmd.Parameters.AddWithValue("@File_Checker",dr["File_Checker"].ToString().Trim());
    //            sqlcmd.Parameters.AddWithValue("@Scan_Data_Checker",dr["Scan_Data_Checker"].ToString().Trim());
    //            sqlcmd.Parameters.AddWithValue("@Scan_Data_Maker",dr["Scan_Data_Maker"].ToString().Trim());
    //            sqlcmd.Parameters.AddWithValue("@Credit_Authority_Approver",dr["Credit_Authority_Approver"].ToString().Trim());
    //            sqlcmd.Parameters.AddWithValue("@Comments",dr["Comments"].ToString().Trim());
    //            sqlcmd.Parameters.AddWithValue("@Comments_Trail",dr["Comments_Trail"].ToString().Trim());
    //            sqlcmd.Parameters.AddWithValue("@Owner_Name",dr["Owner_Name"].ToString().Trim());
    //            sqlcmd.Parameters.AddWithValue("@Property_Identified",dr["Property_Identified"].ToString().Trim());
    //            sqlcmd.Parameters.AddWithValue("@Sanction_Date",dr["Sanction_Date"].ToString().Trim());
    //            if (ddlBranch.SelectedValue.ToString() != "" || ddlBranch.SelectedValue.ToString() != null)
    //            {
    //                sqlcmd.Parameters.AddWithValue("@BranchId", ddlBranch.SelectedItem.Value.ToString().Trim());
    //            }

    //            sqlconn.Open();
    //            int RowsEffected = 0;
    //            RowsEffected = sqlcmd.ExecuteNonQuery();
    //            sqlconn.Close();

    //            if (RowsEffected > 0)
    //            {
    //                isvaliddata = true;
    //                count++;
    //                smsg = Convert.ToString(count);
    //            }
    //            else if (dr["Sub_Stage"].ToString().Trim() == "Loan Disbursed")
    //            {
    //                SqlCommand sqlcomm = new SqlCommand("update_CompleteDis", sqlconn);
    //                sqlcomm.CommandType = CommandType.StoredProcedure;
    //                sqlcomm.CommandTimeout = 0;

    //                sqlcomm.Parameters.AddWithValue("@Loan_App_No", dr["Loan_App_No"].ToString().Trim());
    //                sqlcomm.Parameters.AddWithValue("@Sub_Stage", dr["Sub_Stage"].ToString().Trim());

    //                //if (ddlBranch.SelectedValue.ToString() != "" || ddlBranch.SelectedValue.ToString() != null)
    //                //{
    //                //    sqlcomm.Parameters.AddWithValue("@BranchId", ddlBranch.SelectedItem.Value.ToString().Trim());
    //                //}

    //                sqlconn.Open();
    //                int RowsEffected1 = 0;
    //                RowsEffected1 = sqlcomm.ExecuteNonQuery();
    //                sqlconn.Close();

    //                if (RowsEffected1 > 0)
    //                {
    //                    //isvaliddata = true;
    //                    //count++;
    //                    //smsg = Convert.ToString(count);
    //                }
    //            }
    //            else
    //            {
    //                SqlCommand sqlcom = new SqlCommand("check_housing_no", sqlconn);
    //                sqlcom.CommandType = CommandType.StoredProcedure;
    //                sqlcom.CommandTimeout = 0;

    //                sqlcom.Parameters.AddWithValue("@Loan_App_No", dr["Loan_App_No"].ToString().Trim());

    //                sqlconn.Open();
    //                SqlDataAdapter sda = new SqlDataAdapter();
    //                sda.SelectCommand = sqlcom;

    //                DataTable dt = new DataTable();
    //                sda.Fill(dt);
    //                sqlconn.Close();

    //                if (dt.Rows.Count > 0)
    //                {
    //                    isError = true;
    //                    strlos1 += dr["Loan_App_No"].ToString().Trim() + "--";
    //                    //+ dr["Webtop Id"].ToString().Trim() + "--"
    //                }
    //                else
    //                {
    //                    strlos1 += dr["Loan_App_No"].ToString().Trim() + "--";
    //                }
    //            }
    //        }
    //        sqlconn.Close();
    //    }
    //    catch (Exception ex)
    //    {
    //        hiddenResult.Value = "Error:" + ex.Message;
    //        return;
    //    }

    //}
    public void insertRecord(DataRow dr)
    {

        Object SaveUSERInfo = (Object)Session["UserInfo"];

        SqlConnection sqlconn = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);

        try
        {
            SqlCommand sqlcmd = new SqlCommand("HeroHousing_Insert_Data_SP", sqlconn);
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.CommandTimeout = 0;

            if (dr["Loan_App_No"].ToString().Trim() != "" && dr["Sub_Stage_Start_Time"].ToString().Trim() != "" && (dr["Sub_Stage"].ToString().Trim() == "COPS:Data Maker"))
            {
                sqlcmd.Parameters.AddWithValue("@Loan_App_No", dr["Loan_App_No"].ToString().Trim());
                sqlcmd.Parameters.AddWithValue("@LMS_Application_ID", dr["LMS_Application_ID"].ToString().Trim());
                sqlcmd.Parameters.AddWithValue("@Application_Form_Number", dr["Application_Form_Number"].ToString().Trim());
                sqlcmd.Parameters.AddWithValue("@LOB", dr["LOB"].ToString().Trim());
                sqlcmd.Parameters.AddWithValue("@Branch", dr["Branch"].ToString().Trim());
                sqlcmd.Parameters.AddWithValue("@Product_Scheme", dr["Product_Scheme"].ToString().Trim());
                sqlcmd.Parameters.AddWithValue("@Transaction_Type", dr["Transaction_Type"].ToString().Trim());
                sqlcmd.Parameters.AddWithValue("@Approved_ROI", dr["Approved_ROI"].ToString().Trim());
                sqlcmd.Parameters.AddWithValue("@Approved_Loan_Amount", dr["Approved_Loan_Amount"].ToString().Trim());
                sqlcmd.Parameters.AddWithValue("@Approved_Cross_Sell_Amount", dr["Approved_Cross_Sell_Amount"].ToString().Trim());
                sqlcmd.Parameters.AddWithValue("@Approved_Processing_Fees", dr["Approved_Processing_Fees"].ToString().Trim());
                sqlcmd.Parameters.AddWithValue("@Disbursement_Date", dr["Disbursement_Date"].ToString().Trim());
                sqlcmd.Parameters.AddWithValue("@Disbursal_Amount", dr["Disbursal_Amount"].ToString().Trim());
                sqlcmd.Parameters.AddWithValue("@Credit_Manager", dr["Credit_Manager"].ToString().Trim());
                sqlcmd.Parameters.AddWithValue("@Applicant_Customer_segment", dr["Applicant_Customer_segment"].ToString().Trim());
                sqlcmd.Parameters.AddWithValue("@Segment", dr["Segment"].ToString().Trim());
                sqlcmd.Parameters.AddWithValue("@Requested_Loan_Amount", dr["Requested_Loan_Amount"].ToString().Trim());
                sqlcmd.Parameters.AddWithValue("@Loan_Application_Number", dr["Loan_Application_Number"].ToString().Trim());
                sqlcmd.Parameters.AddWithValue("@Customer_Customer_Name", dr["Customer_Customer_Name"].ToString().Trim());
                sqlcmd.Parameters.AddWithValue("@Stage", dr["Stage"].ToString().Trim());
                sqlcmd.Parameters.AddWithValue("@Sub_Stage", dr["Sub_Stage"].ToString().Trim());
                sqlcmd.Parameters.AddWithValue("@Previous_Sub_Stage", dr["Previous_Sub_Stage"].ToString().Trim());
                sqlcmd.Parameters.AddWithValue("@SM_CBM", dr["SM_CBM"].ToString().Trim());
                sqlcmd.Parameters.AddWithValue("@Loan_Application_Created_By", dr["Loan_Application_Created_By"].ToString().Trim());
                sqlcmd.Parameters.AddWithValue("@Sum_of_IMD", dr["Sum_of_IMD"].ToString().Trim());
                sqlcmd.Parameters.AddWithValue("@Login_Date", dr["Login_Date"].ToString().Trim());
                sqlcmd.Parameters.AddWithValue("@Sub_Stage_Start_Time", strDateFunc(dr["Sub_Stage_Start_Time"].ToString().Trim()));
                sqlcmd.Parameters.AddWithValue("@FTNR_Check", dr["FTNR_Check"].ToString().Trim());
                sqlcmd.Parameters.AddWithValue("@File_Checker", dr["File_Checker"].ToString().Trim());
                sqlcmd.Parameters.AddWithValue("@Scan_Data_Checker", dr["Scan_Data_Checker"].ToString().Trim());
                sqlcmd.Parameters.AddWithValue("@Scan_Data_Maker", dr["Scan_Data_Maker"].ToString().Trim());
                sqlcmd.Parameters.AddWithValue("@Credit_Authority_Approver", dr["Credit_Authority_Approver"].ToString().Trim());
                sqlcmd.Parameters.AddWithValue("@Comments", dr["Comments"].ToString().Trim());
                sqlcmd.Parameters.AddWithValue("@Comments_Trail", dr["Comments_Trail"].ToString().Trim());
                sqlcmd.Parameters.AddWithValue("@Owner_Name", dr["Owner_Name"].ToString().Trim());
                sqlcmd.Parameters.AddWithValue("@Property_Identified", dr["Property_Identified"].ToString().Trim());
                sqlcmd.Parameters.AddWithValue("@Sanction_Date", dr["Sanction_Date"].ToString().Trim());
                if (ddlBranch.SelectedValue.ToString() != "" || ddlBranch.SelectedValue.ToString() != null)
                {
                    sqlcmd.Parameters.AddWithValue("@BranchId", ddlBranch.SelectedItem.Value.ToString().Trim());
                }

                sqlconn.Open();
                int RowsEffected = 0;
                RowsEffected = sqlcmd.ExecuteNonQuery();
                sqlconn.Close();

                if (RowsEffected > 0)
                {
                    isvaliddata = true;
                    count++;
                    smsg = Convert.ToString(count);
                }

                else
                {
                    SqlCommand sqlcom = new SqlCommand("HeroHousing_Check_Housing_No_SP", sqlconn);
                    sqlcom.CommandType = CommandType.StoredProcedure;
                    sqlcom.CommandTimeout = 0;

                    sqlcom.Parameters.AddWithValue("@Loan_App_No", dr["Loan_App_No"].ToString().Trim());

                    sqlconn.Open();
                    SqlDataAdapter sda = new SqlDataAdapter();
                    sda.SelectCommand = sqlcom;

                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    sqlconn.Close();

                    if (dt.Rows.Count > 0)
                    {
                        isError = true;
                        strlos1 += dr["Loan_App_No"].ToString().Trim() + "--";
                        //+ dr["Webtop Id"].ToString().Trim() + "--"
                    }
                    else
                    {
                        strlos1 += dr["Loan_App_No"].ToString().Trim() + "--";
                    }
                }
            }
            else if (dr["Sub_Stage"].ToString().Trim() == "Loan Disbursed")
            {
                SqlCommand sqlcomm = new SqlCommand("HeroHousing_Update_Complete_Dis_SP", sqlconn);
                sqlcomm.CommandType = CommandType.StoredProcedure;
                sqlcomm.CommandTimeout = 0;

                sqlcomm.Parameters.AddWithValue("@Loan_App_No", dr["Loan_App_No"].ToString().Trim());
                sqlcomm.Parameters.AddWithValue("@Sub_Stage", dr["Sub_Stage"].ToString().Trim());

                //if (ddlBranch.SelectedValue.ToString() != "" || ddlBranch.SelectedValue.ToString() != null)
                //{
                //    sqlcomm.Parameters.AddWithValue("@BranchId", ddlBranch.SelectedItem.Value.ToString().Trim());
                //}

                sqlconn.Open();
                int RowsEffected1 = 0;
                RowsEffected1 = sqlcomm.ExecuteNonQuery();
                sqlconn.Close();

                if (RowsEffected1 > 0)
                {
                    //isvaliddata = true;
                    //count++;
                    //smsg = Convert.ToString(count);
                }
            }
            sqlconn.Close();
        }
        catch (Exception ex)
        {
            hiddenResult.Value = "Error:" + ex.Message;
            return;
        }

    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Pages/Menu.aspx", true);
    }
    protected void btnsmaple_Click(object sender, EventArgs e)
    {
        string filename = "HeroHousing.xls";
        Response.ContentType = "application/octect-stream";
        Response.AppendHeader("Content-Disposition", "attachment;filename=" + filename);
        Response.TransmitFile(Server.MapPath("~/Pages/HeroHousing/Download/" + filename));
        Response.End();
    }
}