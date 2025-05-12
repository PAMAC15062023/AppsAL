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

public partial class Pages_ICICIRPC_importfile : System.Web.UI.Page
{
    SingleUserLogin Login = new SingleUserLogin();

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
            if (xlsFileUpload.HasFile)
            {
                String strPath = "";
                String MyFile = "";
                string strDateTime = DateTime.Now.ToString("ddMMyyyyhhmmss");

                strPath = Server.MapPath("~/Pages/ChequePrinting/UploadFiles/");
                MyFile = strDateTime + ".xls";
                strPath = (strPath + MyFile);
                xlsFileUpload.PostedFile.SaveAs(strPath);

                string strFileName = xlsFileUpload.FileName.ToString();

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

                    if (dt != null && dt.Rows.Count > 0)
                    {
                        int colCount = dt.Columns.Count;  // 9
                        if (colCount != 9)
                        {
                            lblMsgXls.Text = "Uploaded Excel Not As Per Standard Format";

                            return;
                        }

                        List<string> Columns = returnColumns();  // 9

                        int i = 0;
                        foreach (var col in Columns)
                        {
                            if (Columns[i] != Convert.ToString(dt.Columns[i].ColumnName))
                            {
                                lblMsgXls.Text = "Uploaded Excel Not As Per Standard Format Column Name Mismatch";

                                return;
                            }
                            i++;
                        }

                        if (dt.Rows.Count > 0)
                        {
                            for (int j = 0; j < dt.Rows.Count; j++)
                            {
                                CPRT_Insert_upload(dt.Rows[j]);

                            }
                        }
                        string smsg = Convert.ToString(dt.Rows.Count);
                        lblMsgXls.Text = "Data Import Successfully!! Total Count :" + smsg;
                    }
                }
                else
                {
                    lblMsgXls.Visible = true;
                    lblMsgXls.Text = "Please Select XLS File only To Import...!!!";
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
            lblMsgXls.Text = "Error :" + ex.Message;
        }
    }
    private List<string> returnColumns()
    {
        List<string> column = new List<string>();

        column.Add("Company_DirectorName");
        column.Add("BankName");
        column.Add("BranchName");
        column.Add("PayeeName");
        column.Add("Amount");
        column.Add("PaymentDetails");
        column.Add("Narration");
        column.Add("AccountHead");
        column.Add("CalculusTransactionID");

        return column;
    }
    protected void CPRT_Insert_upload(DataRow dr)
    {

        Object SaveUSERInfo = (Object)Session["UserInfo"];

        SqlConnection sqlCon = new SqlConnection(ConfigurationSettings.AppSettings["CPRT_ConnectionString"]);
        try
        {

            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlCon;
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.CommandText = "CPRT_importdata_sp";
            sqlcmd.CommandTimeout = 0;


            sqlcmd.Parameters.AddWithValue("@Co_Di_Name", dr["Company_DirectorName"].ToString().Trim());
            sqlcmd.Parameters.AddWithValue("@BankName", dr["BankName"].ToString().Trim());
            sqlcmd.Parameters.AddWithValue("@BranchName", dr["BranchName"].ToString().Trim());
            sqlcmd.Parameters.AddWithValue("@PayeeName", dr["PayeeName"].ToString().Trim());
            sqlcmd.Parameters.AddWithValue("@AccountHead", dr["AccountHead"].ToString().Trim());
            sqlcmd.Parameters.AddWithValue("@CalculusTransactionID", dr["CalculusTransactionID"].ToString().Trim());
            sqlcmd.Parameters.AddWithValue("@Amount", dr["Amount"].ToString().Trim());
            sqlcmd.Parameters.AddWithValue("@PaymentDetails", dr["PaymentDetails"].ToString().Trim());
            sqlcmd.Parameters.AddWithValue("@Narration", dr["Narration"].ToString().Trim());

            int cnint = Convert.ToInt32(dr["Amount"]);
            string cnw = ConvertNumbertoWords(cnint);
          //  sqlcmd.Parameters.AddWithValue("@amtinwords", cnw);
            sqlcmd.Parameters.AddWithValue("@amtinwords", cnw + " Only");


            //sqlcmd.Parameters.AddWithValue("@LoanTenor", dr["Loan Tenor"].ToString().Trim());
            //sqlcmd.Parameters.AddWithValue("@SFAID", dr["SFA ID"].ToString().Trim());
            //sqlcmd.Parameters.AddWithValue("@imp_product", dr["Product"].ToString().Trim());
            //sqlcmd.Parameters.AddWithValue("@RM_EMPID", dr["Relationship Manager- EMP ID"].ToString().Trim());
            //sqlcmd.Parameters.AddWithValue("@BCMName", dr["BCM Name"].ToString().Trim());
            //sqlcmd.Parameters.AddWithValue("@DMAName", dr["DMA/DST/Sol ID Name"].ToString().Trim());
            //sqlcmd.Parameters.AddWithValue("@SOLID", dr["SOL ID"].ToString().Trim());
            //sqlcmd.Parameters.AddWithValue("@FI_Req", dr["FI Req"].ToString().Trim());
            //sqlcmd.Parameters.AddWithValue("@location", dr["LOCATION"].ToString().Trim());
            //sqlcmd.Parameters.AddWithValue("@Add_by", Convert.ToString(((UserInfo.structUSERInfo)(SaveUSERInfo)).UserId));
            //sqlcmd.Parameters.AddWithValue("@Product", "HL");


            sqlCon.Open();
            int RowEffected = 0;

            RowEffected = sqlcmd.ExecuteNonQuery();
            if (RowEffected > 0)
            {


            }

            sqlCon.Close();
        }
        catch (Exception ex)
        {
            lblMsgXls.Visible = true;
            lblMsgXls.Text = "Error :" + ex.Message;
        }
        finally
        {
            sqlCon.Close();
            sqlCon.Dispose();
        }
    }
    public static string ConvertNumbertoWords(int number)
    {
        if (number == 0)
            return "Zero";
        if (number < 0)
            return "minus " + ConvertNumbertoWords(Math.Abs(number));
        string words = "";
        if ((number / 10000000) > 0)
        {
            words += ConvertNumbertoWords(number / 10000000) + " Crore ";
            number %= 10000000;
        }
        if ((number / 100000) > 0)
        {
            words += ConvertNumbertoWords(number / 100000) + " Lakh ";
            number %= 100000;
        }
        if ((number / 1000) > 0)
        {
            words += ConvertNumbertoWords(number / 1000) + " Thousand ";
            number %= 1000;
        }
        if ((number / 100) > 0)
        {
            words += ConvertNumbertoWords(number / 100) + " Hundred ";
            number %= 100;
        }
        if (number > 0)
        {
            if (words != "")
                words += "And ";
            var unitsMap = new[] { "Zero", "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine", "Ten", "Eleven", "Twelve", "Thirteen", "Fourteen", "Fifteen", "Sixteen", "Seventeen", "Eighteen", "Nineteen" };
            var tensMap = new[] { "Zero", "Ten", "Twenty", "Thirty", "Forty", "Fifty", "Sixty", "Seventy", "Eighty", "Ninety" };

            if (number < 20)
                words += unitsMap[number];
            else
            {
                words += tensMap[number / 10];
                if ((number % 10) > 0)
                    words += " " + unitsMap[number % 10];
            }
        }
        return words;
    }
}


//public string strDate(string strInDate)
//{
//    string strDD = strInDate.Substring(0, 2);

//    string strMM = strInDate.Substring(3, 2);

//    string strYYYY = strInDate.Substring(6, 4);

//    string strhh = strInDate.Substring(11, 2);

//    string strmmm = strInDate.Substring(14, 2);

//    string strss = strInDate.Substring(17, 2);

//    string strMMDDYYYY = strMM + "/" + strDD + "/" + strYYYY + " " + strhh + ":" + strmmm + ":" + strss;

//    DateTime dtConvertDate = Convert.ToDateTime(strMMDDYYYY);

//    string strOutDate = dtConvertDate.ToString("dd-MMM-yyyy HH:mm:ss");

//    return strOutDate;
//}

//}


