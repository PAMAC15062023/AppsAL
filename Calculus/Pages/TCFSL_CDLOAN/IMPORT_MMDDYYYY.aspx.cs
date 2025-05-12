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

public partial class Pages_TCFSL_CDLOAN_IMPORT_MMDDYYYY : System.Web.UI.Page
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

    }
    public string strDateFunc(string strInDate)
    {
        try
        {
            string[] timeFormats = { 
                    "MM/dd/yyyy hh:mm:ss tt",
                    "MM/dd/yyyy HH:mm:ss tt",
                    "MM/d/yyyy HH:mm:ss tt",
                    "MM/d/yyyy hh:mm:ss tt",
                    "MM/d/yyyy HH:mm:ss tt",
                    "MM/d/yyyy hh:mm:ss tt",
                    "M/d/yyyy hh:mm:ss tt",
                    "M/d/yyyy HH:mm:ss tt",
                    "MM/dd/yyyy",
                    "MM/d/yyyy",
                    "MM/d/yyyy",
                    "M/d/yyyy",

                    //function for not Am:PM-- data table issue



                    //function for " - "

                    "MM-dd-yyyy hh:mm:ss tt",
                    "MM-dd-yyyy HH:mm:ss tt",
                    "M-dd-yyyy HH:mm:ss tt",
                    "M-dd-yyyy hh:mm:ss tt",
                    "MM-d-yyyy HH:mm:ss tt",
                    "MM-d-yyyy hh:mm:ss tt",
                    "M-d-yyyy hh:mm:ss tt",
                    "M-d-yyyy HH:mm:ss tt",
                    "MM-dd-yyyy",
                    "M-dd-yyyy",
                    "MM-d-yyyy",
                    "M-d-yyyy",

                    "dd-MMM-yy",
                    "d-MMM-yy",
                    "d-MMM-yyyy",
                    "d-MMM-yyyy",

                    //hh::mm
                    "MM/dd/yyyy hh:mm tt",
                    "MM/dd/yyyy HH:mm tt",
                    "MM/d/yyyy HH:mm tt",
                    "MM/d/yyyy hh:mm tt",
                    "MM/d/yyyy HH:mm tt",
                    "MM/d/yyyy hh:mm tt",
                    "M/d/yyyy hh:mm tt",
                    "M/d/yyyy HH:mm tt",

                    //function for not Am:PM-- data table issue
                    "MM/dd/yyyy hh:mm",
                    "MM/dd/yyyy HH:mm",
                    "MM/d/yyyy HH:mm",
                    "MM/d/yyyy hh:mm",
                    "MM/d/yyyy HH:mm",
                    "MM/d/yyyy hh:mm",
                    "M/d/yyyy hh:mm",
                    "M/d/yyyy HH:mm",



                    //function for " - "

                    "MM-dd-yyyy hh:mm tt",
                    "MM-dd-yyyy HH:mm tt",
                    "M-dd-yyyy HH:mm tt",
                    "M-dd-yyyy hh:mm tt",
                    "MM-d-yyyy HH:mm tt",
                    "MM-d-yyyy hh:mm tt",
                    "M-d-yyyy hh:mm tt",
                    "M-d-yyyy HH:mm tt",

                    "MM-dd-yyyy hh:mm",
                    "MM-dd-yyyy HH:mm",
                    "M-dd-yyyy HH:mm",
                    "M-dd-yyyy hh:mm",
                    "MM-d-yyyy HH:mm",
                    "MM-d-yyyy hh:mm",
                    "M-d-yyyy hh:mm",
                    "M-d-yyyy HH:mm",



                    //Time Slot
                    "MM/dd/yyyy h:mm:ss tt",
                    "MM/dd/yyyy H:mm:ss tt",
                    "MM/d/yyyy h:mm:ss tt",
                    "MM/d/yyyy H:mm:ss tt",
                    "MM/d/yyyy h:mm:ss tt",
                    "MM/d/yyyy H:mm:ss tt",
                    "M/d/yyyy h:mm:ss tt",
                    "M/d/yyyy H:mm:ss tt",
                    "MM/dd/yyyy",
                    "MM/d/yyyy",
                    "MM/d/yyyy",
                    "M/d/yyyy",


                       //function for " - "
                    "MM-dd-yyyy h:mm:ss tt",
                    "MM-dd-yyyy H:mm:ss tt",
                    "M-dd-yyyy h:mm:ss tt",
                    "M-dd-yyyy H:mm:ss tt",
                    "MM-d-yyyy h:mm:ss tt",
                    "MM-d-yyyy H:mm:ss tt",
                    "M-d-yyyy h:mm:ss tt",
                    "M-d-yyyy H:mm:ss tt",
                    "MM-dd-yyyy",
                    "M-dd-yyyy",
                    "MM-d-yyyy",
                    "M-d-yyyy",

                     //hh::mm
                    "MM/dd/yyyy h:mm tt",
                    "MM/dd/yyyy H:mm tt",
                    "MM/d/yyyy h:mm tt",
                    "MM/d/yyyy H:mm tt",
                    "MM/d/yyyy h:mm tt",
                    "MM/d/yyyy H:mm tt",
                    "M/d/yyyy h:mm tt",
                    "M/d/yyyy H:mm tt",


                    "MM/dd/yyyy h:mm",
                    "MM/dd/yyyy H:mm",
                    "MM/d/yyyy h:mm",
                    "MM/d/yyyy H:mm",
                    "MM/d/yyyy h:mm",
                    "MM/d/yyyy H:mm",
                    "M/d/yyyy h:mm",
                    "M/d/yyyy H:mm",


                    //function for " - "

                    "MM-dd-yyyy h:mm tt",
                    "MM-dd-yyyy H:mm tt",
                    "M-dd-yyyy h:mm tt",
                    "M-dd-yyyy H:mm tt",
                    "MM-d-yyyy h:mm tt",
                    "MM-d-yyyy H:mm tt",
                    "M-d-yyyy h:mm tt",
                    "M-d-yyyy H:mm tt",
                    "MM-dd-yyyy",
                    "M-dd-yyyy",
                    "MM-d-yyyy",
                    "M-d-yyyy",

                    "MM-dd-yyyy h:mm",
                    "MM-dd-yyyy H:mm",
                    "M-dd-yyyy h:mm",
                    "M-dd-yyyy H:mm",
                    "MM-d-yyyy h:mm",
                    "MM-d-yyyy H:mm",
                    "M-d-yyyy h:mm",
                    "M-d-yyyy H:mm"

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
    protected void btnImport_Click(object sender, EventArgs e)
    {
        try
        {
            if (xslFileUpload.HasFile)
            {
                String strPath = "";
                String MyFile = "";
                string strDateTime = DateTime.Now.ToString("ddMMyyyyhhmmss");

                strPath = Server.MapPath("~/Pages/TCFSL_CDLOAN/files/");
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
                            if (ddlType.SelectedItem.Value != "0")
                            {
                                    Update_Into_TCFSL_CD_upload(dt.Rows[i]);
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
                            AllMessage += "Following Case Number Already Exists or Check Status :-" + "" + strlos1 + "</br>" + "</br>";
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
    protected void Update_Into_TCFSL_CD_upload(DataRow dr)
    {

        Object SaveUSERInfo = (Object)Session["UserInfo"];

        SqlConnection sqlCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);
        try
        {

            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlCon;
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.CommandText = "TCFSL_IMPORT";
            sqlcmd.CommandTimeout = 0;

            if (dr["Case Number"].ToString() != "" && dr["Loan Application: Webtop Id"].ToString() != "" && dr["Status"].ToString() != "" && dr["Last Modified Date Time"].ToString() != "")
            {
                //    if (dr["SortCASE NUMBER"].ToString() != "" && dr["SortWEBTOP #"].ToString() != "" && dr["SortSTATUS"].ToString() != "")
                //{
                //sqlcmd.Parameters.AddWithValue("@Store_Customer_Name", dr["SortLOAN APPLICATION"].ToString().Trim());
                sqlcmd.Parameters.AddWithValue("@Case_Number", dr["Case Number"].ToString().Trim());
                sqlcmd.Parameters.AddWithValue("@Webtop_Id", dr["Loan Application: Webtop Id"].ToString().Trim());
                sqlcmd.Parameters.AddWithValue("@Stage", dr["Application Stage"].ToString().Trim());
                sqlcmd.Parameters.AddWithValue("@Customer_Name", dr["Customer Name"].ToString().Trim());
                sqlcmd.Parameters.AddWithValue("@Status", dr["Status"].ToString().Trim());
                sqlcmd.Parameters.AddWithValue("@CDSubvention_Product_Category", dr["Owner Profile Name"].ToString().Trim());
                sqlcmd.Parameters.AddWithValue("@Finnone_Branch", dr["Loan Application: Finnone Branch: Branch Name"].ToString().Trim());
                sqlcmd.Parameters.AddWithValue("@Requested_Loan_Amount", dr["Loan Application: Requested Loan Amount"].ToString().Trim());
                sqlcmd.Parameters.AddWithValue("@Last_Modified_Date", strDateFunc(dr["Last Modified Date Time"].ToString().Trim()));
                sqlcmd.Parameters.AddWithValue("@Owner_FulLName", dr["Owner Name"].ToString().Trim());


                sqlcmd.Parameters.AddWithValue("@TCFCreated_Sate", dr["Created Date Time"].ToString().Trim());
                sqlcmd.Parameters.AddWithValue("@Last_Modified_By", dr["Last Modified By"].ToString().Trim());
                sqlcmd.Parameters.AddWithValue("@Store_Name", dr["Store Name"].ToString().Trim());
                sqlcmd.Parameters.AddWithValue("@cStore", dr["cStore"].ToString().Trim());
                sqlcmd.Parameters.AddWithValue("@FileRecDte", dr["Loan Application: File Received Date"].ToString().Trim());

                sqlcmd.Parameters.AddWithValue("@CaseType", ddlType.SelectedItem.Value);
                sqlcmd.Parameters.AddWithValue("@BRANCH", Convert.ToString(((UserInfo.structUSERInfo)(SaveUSERInfo)).BranchId));
                sqlcmd.Parameters.AddWithValue("@UPLOAD_BY", Convert.ToString(((UserInfo.structUSERInfo)(SaveUSERInfo)).UserId));


                sqlCon.Open();
                int RowEffected = 0;
                RowEffected = sqlcmd.ExecuteNonQuery();
                sqlCon.Close();

                if (RowEffected > 0)
                {
                    isvaliddata = true;
                    count++;
                    smsg = Convert.ToString(count);

                }
                else
                {
                    SqlCommand sqlCom = new SqlCommand();
                    sqlCom.Connection = sqlCon;
                    sqlCom.CommandType = CommandType.StoredProcedure;
                    sqlCom.CommandText = "check_tcfslcreen";
                    sqlCom.CommandTimeout = 0;

                    sqlCom.Parameters.AddWithValue("@Case_Number", dr["Case Number"].ToString().Trim());
                    sqlCom.Parameters.AddWithValue("@Webtop_Id", dr["Loan Application: Webtop Id"].ToString().Trim());

                    sqlCon.Open();

                    SqlDataAdapter sqlDA = new SqlDataAdapter();
                    sqlDA.SelectCommand = sqlCom;

                    DataTable dt = new DataTable();
                    sqlDA.Fill(dt);
                    sqlCon.Close();

                    if (dt.Rows.Count > 0)
                    {
                        isError = true;
                        strlos1 += dr["Case Number"].ToString().Trim() + "--";
                        //+ dr["Webtop Id"].ToString().Trim() + "--"
                    }
                    else
                    {
                        strlos1 += dr["Case Number"].ToString().Trim() + "--";
                    }

                }
            }

            sqlCon.Close();
        }
        catch (Exception ex)
        {
            hiddenResult.Value = "Error :" + ex.Message;
            return;
        }
        finally
        {
            sqlCon.Close();
            sqlCon.Dispose();
        }
    }
    //protected void Update_Into_TCFSL_CD_upload(DataRow dr)
    //{

    //    Object SaveUSERInfo = (Object)Session["UserInfo"];

    //    SqlConnection sqlCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);
    //    try
    //    {

    //        SqlCommand sqlcmd = new SqlCommand();
    //        sqlcmd.Connection = sqlCon;
    //        sqlcmd.CommandType = CommandType.StoredProcedure;
    //        sqlcmd.CommandText = "TCFSL_IMPORT";
    //        sqlcmd.CommandTimeout = 0;


    //        //sqlcmd.Parameters.AddWithValue("@Store_Customer_Name", dr["SortLOAN APPLICATION"].ToString().Trim());
    //        sqlcmd.Parameters.AddWithValue("@Case_Number", dr["Case Number"].ToString().Trim());
    //        sqlcmd.Parameters.AddWithValue("@Webtop_Id", dr["Loan Application: Webtop Id"].ToString().Trim());
    //        sqlcmd.Parameters.AddWithValue("@Stage", dr["Application Stage"].ToString().Trim());
    //        sqlcmd.Parameters.AddWithValue("@Customer_Name", dr["Customer Name"].ToString().Trim());
    //        sqlcmd.Parameters.AddWithValue("@Status", dr["Status"].ToString().Trim());
    //        sqlcmd.Parameters.AddWithValue("@CDSubvention_Product_Category", dr["Owner Profile Name"].ToString().Trim());
    //        sqlcmd.Parameters.AddWithValue("@Finnone_Branch", dr["Loan Application: Finnone Branch: Branch Name"].ToString().Trim());
    //        sqlcmd.Parameters.AddWithValue("@Requested_Loan_Amount", dr["Loan Application: Requested Loan Amount"].ToString().Trim());
    //        sqlcmd.Parameters.AddWithValue("@Last_Modified_Date", strDateFunc(dr["Last Modified Date Time"].ToString().Trim()));
    //        sqlcmd.Parameters.AddWithValue("@Owner_FulLName", dr["Owner Name"].ToString().Trim());


    //        sqlcmd.Parameters.AddWithValue("@TCFCreated_Sate",strDateFunc(dr["Created Date Time"].ToString().Trim()));
    //        sqlcmd.Parameters.AddWithValue("@Last_Modified_By", dr["Last Modified By"].ToString().Trim());
    //        sqlcmd.Parameters.AddWithValue("@Store_Name", dr["Store Name"].ToString().Trim());
    //        sqlcmd.Parameters.AddWithValue("@cStore", dr["cStore"].ToString().Trim());

    //        sqlcmd.Parameters.AddWithValue("@CaseType", ddlType.SelectedItem.Value);
    //        sqlcmd.Parameters.AddWithValue("@BRANCH", Convert.ToString(((UserInfo.structUSERInfo)(SaveUSERInfo)).BranchId));
    //        sqlcmd.Parameters.AddWithValue("@UPLOAD_BY", Convert.ToString(((UserInfo.structUSERInfo)(SaveUSERInfo)).UserId));


    //        sqlCon.Open();
    //        int RowEffected = 0;
    //        RowEffected = sqlcmd.ExecuteNonQuery();
    //        sqlCon.Close();

    //        if (RowEffected > 0)
    //        {
    //            isvaliddata = true;
    //            count++;
    //            smsg = Convert.ToString(count);

    //        }
    //        else
    //        {
    //            SqlCommand sqlCom = new SqlCommand();
    //            sqlCom.Connection = sqlCon;
    //            sqlCom.CommandType = CommandType.StoredProcedure;
    //            sqlCom.CommandText = "check_tcfslcreen";
    //            sqlCom.CommandTimeout = 0;

    //            sqlCom.Parameters.AddWithValue("@Case_Number", dr["SortCASE NUMBER"].ToString().Trim());
    //            sqlCom.Parameters.AddWithValue("@Webtop_Id", dr["SortWEBTOP #"].ToString().Trim());

    //            sqlCon.Open();

    //            SqlDataAdapter sqlDA = new SqlDataAdapter();
    //            sqlDA.SelectCommand = sqlCom;

    //            DataTable dt = new DataTable();
    //            sqlDA.Fill(dt);
    //            sqlCon.Close();

    //            if (dt.Rows.Count > 0)
    //            {
    //                isError = true;
    //                strlos1 += dr["SortCASE NUMBER"].ToString().Trim() + "--";
    //                //+ dr["Webtop Id"].ToString().Trim() + "--"
    //            }
    //            else
    //            {
    //                strlos1 += dr["SortCASE NUMBER"].ToString().Trim() + "--";
    //            }

    //        }

    //        sqlCon.Close();
    //    }
    //    catch (Exception ex)
    //    {
    //        hiddenResult.Value = "Error :" + ex.Message;
    //        return;
    //    }
    //    finally
    //    {
    //        sqlCon.Close();
    //        sqlCon.Dispose();
    //    }
    //}
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Pages/Menu.aspx", true);
    }
    protected void btnsmaple_Click(object sender, EventArgs e)
    {
        string filename = "IMPORT.xls";
        Response.ContentType = "application/octect-stream";
        Response.AppendHeader("Content-Disposition", "attachment;filename=" + filename);
        Response.TransmitFile(Server.MapPath("~/Pages/TCFSL_CDLOAN/Download/" + filename));
        Response.End();
    }
}