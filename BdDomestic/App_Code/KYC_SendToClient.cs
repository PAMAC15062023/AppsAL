using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.OleDb;
/// <summary>
/// Summary description for KYC_SendToClient
/// </summary>
public class KYC_SendToClient
{
    CCommon connobj = new CCommon();
	public KYC_SendToClient()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    private string strSendDate;
    private string strSendTime;
    private string strSendTimeType;
    private string strcaseid;
    private string strtathrs;
    private string strsearchfromDate;
    private string strsearchtoDate;
    public string SearchFromDate
    {
        get { return strsearchfromDate; }
        set { strsearchfromDate = value; }
    }
    public string SearchToDate
    {
        get { return strsearchtoDate; }
        set { strsearchtoDate = value; }
    }
    public string TATHRS
    {
        get { return strtathrs; }
        set { strtathrs = value; }
    }
    public string CaseId
    {
        get { return strcaseid; }
        set { strcaseid = value; }
    }
    public string SendDate
    {
        get { return strSendDate; }
        set { strSendDate = value; }
    }
    public string SendTime
    {
        get { return strSendTime; }
        set { strSendTime = value; }
    }
    public string SendTimeType
    {
        get { return strSendTimeType; }
        set { strSendTimeType = value; }
    }
    public DataTable GetTAT(DateTime sFromDate, DateTime sToDate)
    {

        DataTable d_table = new DataTable();
        DataSet ds = new DataSet();
        DateTime strSendDate;
        DateTime strSendDate1;
        TimeSpan ts1;
        double Hrs, mins;
        string Hours = "";
        string Minutes = "";
        string Total_Hours = "";
        DataRow drow;
        d_table.Columns.Add("REF_NO");
        d_table.Columns.Add("APPLICANT_NAME");
        d_table.Columns.Add("REC_DATE");
        d_table.Columns.Add("TAT_HRS");
        d_table.Columns.Add("CaseId");
        try
        {

            ds = GerRecords(sFromDate, sToDate);
            if (ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    drow = d_table.NewRow();
                    drow[0] = ds.Tables[0].Rows[i]["REF_NO"];
                    drow[1] = ds.Tables[0].Rows[i]["APPLICANT_NAME"];
                    drow[2] = Convert.ToDateTime(ds.Tables[0].Rows[i]["REC_DATE"].ToString()).ToString("dd/MM/yyyy hh:mm tt");
                    String s = ds.Tables[0].Rows[i]["REC_DATE"].ToString();
                    strSendDate1 = Convert.ToDateTime(s.ToString());
                    String s1 = Convert.ToDateTime(connobj.strDate(SendDate)).ToString("MM/dd/yyyy") + " " + SendTime.ToString() + " " + SendTimeType.ToString();
                    strSendDate = Convert.ToDateTime(s1.ToString());
                    ts1 = strSendDate.Subtract(strSendDate1);
                    Hrs = Convert.ToDouble(ts1.Days * 24 + ts1.Hours);
                    mins = Convert.ToDouble(ts1.Minutes);
                    Hours = Hrs.ToString();
                    Minutes = mins.ToString();
                    Total_Hours = Hours + ":" + Minutes;
                    drow[3] = Total_Hours.ToString();
                    drow[4] = ds.Tables[0].Rows[i]["CASE_ID"];
                    d_table.Rows.Add(drow);
                }

            }

            return d_table;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }


    }
    public DataTable GetClient(DateTime sFromDate, DateTime sToDate)
    {

        DataTable d_table = new DataTable();
        DataColumn REF_NO = new DataColumn("REF_NO");
        DataColumn APPLICANT_NAME = new DataColumn("APPLICANT_NAME");
        DataColumn REC_DATE = new DataColumn("REC_DATE");


        DataSet ds = new DataSet();
        DataRow drow;
        d_table.Columns.Add(REF_NO);
        d_table.Columns.Add(APPLICANT_NAME);
        d_table.Columns.Add(REC_DATE);
        try
        {
            ds = GerRecords(sFromDate, sToDate);
            if (ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    drow = d_table.NewRow();
                    drow[0] = ds.Tables[0].Rows[i]["REF_NO"];
                    drow[1] = ds.Tables[0].Rows[i]["APPLICANT_NAME"];
                    drow[2] = Convert.ToDateTime(ds.Tables[0].Rows[i]["REC_DATE"].ToString()).ToString("dd/MM/yyyy hh:mm tt");
                    d_table.Rows.Add(drow);
                }

            }

            return d_table;
        }

        catch (Exception ex)
        {
            throw new Exception("Error While Searching " + ex.Message);
        }

    }
    public void insertGridFields(DateTime strSendDate, string chkb)
    {
        OleDbConnection conn = new OleDbConnection(connobj.ConnectionString);
        conn.Open();
        OleDbTransaction oledbTrans = conn.BeginTransaction();
        string sql = "";
        try
        {

            sql = "";
            sql = "UPDATE  CPV_KYC_CASE_DETAILS SET SEND_DATETIME=?,TAT_HRS=?, " +
                  "WITHIN_TAT=?  WHERE CASE_ID=?";
                    OleDbParameter[] paramGrid = new OleDbParameter[4];
                    paramGrid[0] = new OleDbParameter("@SEND_DATETIME", OleDbType.VarChar);
                    paramGrid[0].Value = strSendDate;
                    paramGrid[1] = new OleDbParameter("@TAT_HRS", OleDbType.VarChar);
                    paramGrid[1].Value = TATHRS;
                    paramGrid[2] = new OleDbParameter("@WITHIN_TAT", OleDbType.VarChar);
                    paramGrid[2].Value = chkb;
                    paramGrid[3] = new OleDbParameter("@CASE_ID", OleDbType.VarChar);
                    paramGrid[3].Value = CaseId;
                    OleDbHelper.ExecuteNonQuery(oledbTrans, CommandType.Text, sql, paramGrid);
                    oledbTrans.Commit();
                    conn.Close();
        }
        catch (Exception ex)
        {
            oledbTrans.Rollback();
            conn.Close();
            throw new Exception("Error While Sending " + ex.Message);
        }

    }
    public string GerStandardTatHour()
    {
        OleDbConnection conn = new OleDbConnection(connobj.ConnectionString);
        conn.Open();
        OleDbTransaction oledbTrans = conn.BeginTransaction();
        string sSql = "";
        string STD_HRS = "";
        try
        {


            sSql = "SELECT STD_HRS1,STD_HRS2,STD_HRS3 from STANDARD_TAT_HOURS  WHERE ACTIVITY_ID='" + HttpContext.Current.Session["ActivityId"].ToString() + "' AND CLIENT_ID='" + HttpContext.Current.Session["ClientId"].ToString() + "' AND PRODUCT_ID='" + HttpContext.Current.Session["ProductId"].ToString() + "'";
            DataSet ds = OleDbHelper.ExecuteDataset(oledbTrans, CommandType.Text, sSql);
            if (ds.Tables[0].Rows.Count > 0)
            {
                STD_HRS = ds.Tables[0].Rows[0]["STD_HRS1"].ToString();
            }
            oledbTrans.Commit();

        }
        catch (Exception ex)
        {

            oledbTrans.Rollback();
            throw new Exception("Error While Geting StandardTatHour " + ex.Message);
        }
        return STD_HRS;





    }
    public DataSet GerRecords(DateTime FromDate, DateTime ToDate)
    {
        OleDbConnection conn = new OleDbConnection(connobj.ConnectionString);
        conn.Open();
        DataSet dsGetRecords;
        OleDbTransaction oledbTrans = conn.BeginTransaction();
        string strSql = "";


        try
        {

            strSql = " SELECT CD.CASE_ID, CD.REF_NO, (ISNULL(CD.FIRST_NAME,'')+''+ISNULL(CD.MIDDLE_NAME,'')+''+ISNULL(CD.LAST_NAME,''))AS APPLICANT_NAME," +
                     " CD.CASE_REC_DATETIME AS REC_DATE FROM CPV_KYC_CASE_DETAILS CD WHERE CD.SEND_DATETIME IS NULL AND CD.CENTRE_ID='" + HttpContext.Current.Session["CentreId"].ToString() + "' AND " +
                     " CD.CLIENT_ID='" + HttpContext.Current.Session["ClientId"].ToString() + "' AND CD.CASE_REC_DATETIME>= '" + FromDate + "' AND " +
                     " CD.CASE_REC_DATETIME <'" + ToDate + "' AND CD.CASE_ID NOT IN (SELECT CASE_ID FROM " +
                     " CPV_KYC_CASE_STATUS_NULL WHERE CENTRE_ID='" + HttpContext.Current.Session["CentreId"].ToString() + "' AND  " +
                     "CLIENT_ID='" + HttpContext.Current.Session["ClientId"].ToString() + "' AND CASE_REC_DATETIME>='" + FromDate + "' AND CASE_REC_DATETIME<'" + ToDate + "')";



            dsGetRecords = OleDbHelper.ExecuteDataset(oledbTrans, CommandType.Text, strSql);
            oledbTrans.Commit();
            conn.Close();

        }
        catch (Exception ex)
        {
            oledbTrans.Rollback();
            conn.Close();
            throw new Exception("Error While Geting Records " + ex.Message);
        }
        return dsGetRecords;
    }
}
