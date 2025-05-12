/*----------------------------------------------------------------------------------------
Scope of Program	:	
File Name			:	CSendToClientFinal.cs
Create By			:	Hemangi Kambli
Create Date		    :	08 Oct 2007
Remarks 		    :	This class is used to Send the case to Client.                       
						
----------------------------------------------------------------------------------------*/
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
/// Summary description for CSendToClientFinal
/// </summary>
public class CSendToClientFinal
{
    CCommon connobj = new CCommon();
	public CSendToClientFinal()
	{
		
	}

    #region PropertyDeclaration
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
    #endregion PropertyDeclaration

    #region Calculate TAT Hours
    public string CalulateTATHrs(DateTime sFromDate, DateTime sToDate,string strClientId, string strCentreId,string strTableName)
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
        OleDbDataAdapter da = new OleDbDataAdapter();
        OleDbConnection conn = new OleDbConnection(connobj.ConnectionString);
        d_table.Columns.Add("REF_NO");
        d_table.Columns.Add("APPLICANT_NAME");
        d_table.Columns.Add("REC_DATE");
        d_table.Columns.Add("TAT_HRS");
        d_table.Columns.Add("CaseId");
        try
        {            
           
            string sSql = " SELECT CD.CASE_ID as CaseId,CD.REF_NO, (ISNULL(CD.FIRST_NAME,'')+''+ISNULL(CD.LAST_NAME,'')+''+ " +
                           " ISNULL(CD.MIDDLE_NAME,''))AS APPLICANT_NAME,CD.CASE_REC_DATETIME AS REC_DATE,Null as TAT_HRS " +
                           " FROM " + strTableName + " CD " +
                           " WHERE CD.CASE_ID='" + CaseId + "'";

            da = new OleDbDataAdapter(sSql, conn);
            da.Fill(ds, "TAT");
            if (ds.Tables["TAT"].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables["TAT"].Rows.Count; i++)
                {
                    drow = d_table.NewRow();
                    drow[0] = ds.Tables["TAT"].Rows[i]["REF_NO"];
                    drow[1] = ds.Tables["TAT"].Rows[i]["APPLICANT_NAME"];

                    drow[2] = Convert.ToDateTime(ds.Tables["TAT"].Rows[i]["REC_DATE"].ToString()).ToString("dd/MM/yyyy hh:mm tt");
                    String s = ds.Tables["TAT"].Rows[i]["REC_DATE"].ToString();
                    strSendDate1 = Convert.ToDateTime(s.ToString());
                    String s1 = Convert.ToDateTime(connobj.strDate(SendDate)).ToString("MM/dd/yyyy") + " " + SendTime.ToString() + " " + SendTimeType.ToString();
                    strSendDate = Convert.ToDateTime(s1.ToString());
                    ts1 = strSendDate.Subtract(strSendDate1);
                    Hrs = Convert.ToDouble(ts1.Days * 24 + ts1.Hours);
                    mins = Convert.ToDouble(ts1.Minutes);
                    Hours = Hrs.ToString();
                    Minutes = mins.ToString();
                    Total_Hours = Hours + ":" + Minutes;

                }

            }
            return Total_Hours;

        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
    #endregion Calculate TAT Hours

    //added by kamal matekar dated ---15 oct 2009----
    #region Calculate TAT Hours

    public string CalulateQCTATHrs(DateTime sFromDate, DateTime sToDate,string strClientId, string strCentreId,string strTableName)
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
        OleDbDataAdapter da = new OleDbDataAdapter();
        OleDbConnection conn = new OleDbConnection(connobj.ConnectionString);
        d_table.Columns.Add("REF_NO");
        ///d_table.Columns.Add("APPLICANT_NAME");
        d_table.Columns.Add("REC_DATE");
        d_table.Columns.Add("TAT_HRS");
        d_table.Columns.Add("CaseId");
        try
        {            
           
            string sSql = " SELECT CD.CASE_ID as CaseId,CD.REF_NO,"+
                         ////(ISNULL(CD.FIRST_NAME,'')+''+ISNULL(CD.LAST_NAME,'')+''+ " +
                         ////" ISNULL(CD.MIDDLE_NAME,''))AS APPLICANT_NAME,
                           "CD.Case_Received_Date AS REC_DATE,Null as TAT_HRS " +
                           " FROM " + strTableName + " CD " +
                           " WHERE CD.CASE_ID='" + CaseId + "'";

            da = new OleDbDataAdapter(sSql, conn);
            da.Fill(ds, "TAT");
            if (ds.Tables["TAT"].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables["TAT"].Rows.Count; i++)
                {
                    drow = d_table.NewRow();
                    drow[0] = ds.Tables["TAT"].Rows[i]["REF_NO"];
                    ///drow[1] = ds.Tables["TAT"].Rows[i]["APPLICANT_NAME"];

                    drow[1] = Convert.ToDateTime(ds.Tables["TAT"].Rows[i]["REC_DATE"].ToString()).ToString("dd/MM/yyyy hh:mm tt");
                    String s = ds.Tables["TAT"].Rows[i]["REC_DATE"].ToString();
                    strSendDate1 = Convert.ToDateTime(s.ToString());
                    String s1 = Convert.ToDateTime(connobj.strDate(SendDate)).ToString("MM/dd/yyyy") + " " + SendTime.ToString() + " " + SendTimeType.ToString();
                    strSendDate = Convert.ToDateTime(s1.ToString());
                    ts1 = strSendDate.Subtract(strSendDate1);
                    Hrs = Convert.ToDouble(ts1.Days * 24 + ts1.Hours);
                    mins = Convert.ToDouble(ts1.Minutes);
                    Hours = Hrs.ToString();
                    Minutes = mins.ToString();
                    Total_Hours = Hours + ":" + Minutes;

                }

            }
            return Total_Hours;

        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
    #endregion Calculate TAT Hours

    //ended------

    #region SendToClient Case
    public void insertGridFields(DateTime strSendDate, string chkb, string strTableName)
    {
        OleDbConnection conn = new OleDbConnection(connobj.ConnectionString);
        conn.Open();
        OleDbTransaction oledbTrans = conn.BeginTransaction();
        string sql = "";
        try
        {

            sql = "";
            sql = "UPDATE  " + strTableName +  
                  " SET SEND_DATETIME=?,TAT_HRS=?, WITHIN_TAT=? WHERE CASE_ID=?";

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
    #endregion SendToClient Case

    //added by kamal matekar......
    #region SendToClient Case
    public void insertQCGridFields(DateTime strSendDate, string chkb, string strTableName)
    {
        OleDbConnection conn = new OleDbConnection(connobj.ConnectionString);
        conn.Open();
        OleDbTransaction oledbTrans = conn.BeginTransaction();
        string sql = "";
        try
        {

            sql = "";
            sql = "UPDATE  " + strTableName +
                  " SET Case_Send_Date=?,TAT_HRS=? " + 
                 ///WITHIN_TAT=? 
                   " WHERE CASE_ID=?";

            OleDbParameter[] paramGrid = new OleDbParameter[3];
            paramGrid[0] = new OleDbParameter("@Case_Send_Date", OleDbType.VarChar);
            paramGrid[0].Value = strSendDate;
            paramGrid[1] = new OleDbParameter("@TAT_HRS", OleDbType.VarChar);
            paramGrid[1].Value = TATHRS;
            //paramGrid[2] = new OleDbParameter("@WITHIN_TAT", OleDbType.VarChar);
            //paramGrid[2].Value = chkb;
            paramGrid[2] = new OleDbParameter("@CASE_ID", OleDbType.VarChar);
            paramGrid[2].Value = CaseId;
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
    #endregion SendToClient Case
    //ended......


    #region Calulate StandardTat Hours
    public string GerStandardTatHour(string strClientId,string strActivityId,string strProductId)
    {


        OleDbConnection conn = new OleDbConnection(connobj.ConnectionString);
        conn.Open();
        OleDbTransaction oledbTrans = conn.BeginTransaction();

        string sSql = "";
        string STD_HRS = "";
        sSql = "SELECT STD_HRS1,STD_HRS2,STD_HRS3 from STANDARD_TAT_HOURS " +
               " WHERE ACTIVITY_ID='" + strActivityId + "' " +
               " AND CLIENT_ID='" + strClientId + "' " +
               " AND PRODUCT_ID='" + strProductId + "'";

        DataSet ds = OleDbHelper.ExecuteDataset(oledbTrans, CommandType.Text, sSql);
        if (ds.Tables[0].Rows.Count > 0)
        {
            STD_HRS = ds.Tables[0].Rows[0]["STD_HRS1"].ToString();
        }
        oledbTrans.Commit();
        conn.Close();
        return STD_HRS;
    }
    #endregion Calulate StandardTat Hours

    #region Get Records Not Send To Client
    public DataSet GetRecords(string strClientId, string strCentreId, DateTime strFromDate, DateTime strToDate,string strTableName)
    {        
        string sSql = "SELECT CD.CASE_ID as CaseId,CD.REF_NO, (ISNULL(CD.FIRST_NAME,'')+''+ISNULL(CD.LAST_NAME,'')+''+ " +
                   " ISNULL(CD.MIDDLE_NAME,''))AS APPLICANT_NAME,CD.CASE_REC_DATETIME AS REC_DATE,Null as TAT_HRS " +
                   " FROM " + strTableName  + " CD" +
                   " WHERE CD.SEND_DATETIME IS NULL AND (CD.CLIENT_ID='" + strClientId + "') AND " +
                   " (CD.CENTRE_ID='" + strCentreId + "') " +
                   " AND (CD.CASE_REC_DATETIME>='" + strFromDate + "') AND (CD.CASE_REC_DATETIME<='" + strToDate + "')" +
                   " AND IS_CASE_COMPLETE='Y'";

        return OleDbHelper.ExecuteDataset(connobj.ConnectionString, CommandType.Text, sSql);
    }
    #endregion Get Records Not Send To Client

    #region Get QCRecords Not Send To Client
    public DataSet GetQCRecords(string strClientId, string strCentreId, DateTime strFromDate, DateTime strToDate, string strTableName)
    {
        string sSql = "SELECT CD.CASE_ID as CaseId,CD.REF_NO," +
                  "(ISNULL(CCD.FIRST_NAME,'')+''+ISNULL(CCD.LAST_NAME,'')+''+ISNULL(CCD.MIDDLE_NAME,''))AS APPLICANT_NAME," +
                   "CD.Case_Received_Date AS REC_DATE,Null as TAT_HRS " +
                   " FROM " + strTableName + " CD " +
                   "left outer join CPV_CC_CASE_DETAILS CCD on cd.case_id=ccd.case_id " +
                   " WHERE CD.Case_Send_Date IS NULL AND (CD.CLIENT_ID='" + strClientId + "') AND " +
                   " (CD.CENTRE_ID='" + strCentreId + "') " +
                   " AND (CD.Case_Received_Date>='" + strFromDate + "') AND (CD.Case_Received_Date<='" + strToDate + "')" +
                   " AND CD.IS_CASE_COMPLETE='Y'";

        return OleDbHelper.ExecuteDataset(connobj.ConnectionString, CommandType.Text, sSql);
    }
    #endregion Get QCRecords Not Send To Client

    #region Get QCRecords Not Send To Client
    public DataSet GetKYCQCRecords(string strClientId, string strCentreId, DateTime strFromDate, DateTime strToDate, string strTableName)
    {
        string sSql = "SELECT CD.CASE_ID as CaseId,CD.REF_NO," +
                  "(ISNULL(CCD.FIRST_NAME,'')+''+ISNULL(CCD.LAST_NAME,'')+''+ISNULL(CCD.MIDDLE_NAME,''))AS APPLICANT_NAME," +
                   "CD.Case_Received_Date AS REC_DATE,Null as TAT_HRS " +
                   " FROM " + strTableName + " CD " +
                   "left outer join CPV_KYC_CASE_DETAILS CCD on cd.case_id=ccd.case_id " +
                   " WHERE CD.Case_Send_Date IS NULL AND (CD.CLIENT_ID='" + strClientId + "') AND " +
                   " (CD.CENTRE_ID='" + strCentreId + "') " +
                   " AND (CD.Case_Received_Date>='" + strFromDate + "') AND (CD.Case_Received_Date<='" + strToDate + "')" +
                   " AND CD.IS_CASE_COMPLETE='Y'";

        return OleDbHelper.ExecuteDataset(connobj.ConnectionString, CommandType.Text, sSql);
    }
    #endregion Get QCRecords Not Send To Client

    #region Get QCRecords Not Send To Client
    public DataSet GetRLQCRecords(string strClientId, string strCentreId, DateTime strFromDate, DateTime strToDate, string strTableName)
    {
        string sSql = "SELECT CD.CASE_ID as CaseId,CD.REF_NO," +
                  "(ISNULL(CCD.FIRST_NAME,'')+''+ISNULL(CCD.LAST_NAME,'')+''+ISNULL(CCD.MIDDLE_NAME,''))AS APPLICANT_NAME," +
                   "CD.Case_Received_Date AS REC_DATE,Null as TAT_HRS " +
                   " FROM " + strTableName + " CD " +
                   "left outer join CPV_RL_CASE_DETAILS CCD on cd.case_id=ccd.case_id " +
                   " WHERE CD.Case_Send_Date IS NULL AND (CD.CLIENT_ID='" + strClientId + "') AND " +
                   " (CD.CENTRE_ID='" + strCentreId + "') " +
                   " AND (CD.Case_Received_Date>='" + strFromDate + "') AND (CD.Case_Received_Date<='" + strToDate + "')" +
                   " AND CD.IS_CASE_COMPLETE='Y'";

        return OleDbHelper.ExecuteDataset(connobj.ConnectionString, CommandType.Text, sSql);
    }
    #endregion Get QCRecords Not Send To Client



    #region Get Records Not Send To Client for CELLULAR
    public DataSet GetRecordsCellular(string strClientId, string strCentreId, DateTime strFromDate, DateTime strToDate)
    {
        string sSql = "SELECT CD.CASE_ID as CaseId,CD.REF_NO, (ISNULL(CD.APP_FNAME,'')+''+ISNULL(CD.APP_LNAME,'')+''+ " +
                   " ISNULL(CD.APP_MNAME,''))AS APPLICANT_NAME,CD.CASE_REC_DATETIME AS REC_DATE,Null as TAT_HRS " +
                   " FROM CPV_CELLULAR_CASES CD" +
                   " WHERE CD.SEND_DATETIME IS NULL AND (CD.CLIENT_ID='" + strClientId + "') AND " +
                   " (CD.CENTRE_ID='" + strCentreId + "') " +
                   " AND (CD.CASE_REC_DATETIME>='" + strFromDate + "') AND (CD.CASE_REC_DATETIME<='" + strToDate + "')" +
                   " AND IS_CASE_COMPLETE='Y'";

        return OleDbHelper.ExecuteDataset(connobj.ConnectionString, CommandType.Text, sSql);
    }
    #endregion Get Records Not Send To Client for CELLULAR

    //--for cellular QC---
    public DataSet GetQCRecordsCellular(string strClientId, string strCentreId, DateTime strFromDate, DateTime strToDate)
    {
        string sSql = " SELECT CQD.CASE_ID as CaseId,CQD.REF_NO,(ISNULL(CD.APP_FNAME,'')+''+ISNULL(CD.APP_LNAME,'')+''+  ISNULL(CD.APP_MNAME,''))AS APPLICANT_NAME, " +
                      " CQD.CASE_Received_Date AS REC_DATE,Null as TAT_HRS  FROM CPV_CELLULAR_CASES CD " +
                      " left outer join cpv_qc_case_details CQD on CD.case_id=CQD.case_id " +
                      " WHERE CQD.case_send_date IS NULL  AND (CD.CLIENT_ID='" + strClientId + "') AND " +
                      " (CQD.CENTRE_ID='" + strCentreId + "') " +
                      " AND (CQD.case_received_date>='" + strFromDate + "') AND (CQD.case_received_date<='" + strToDate + "')" +
                      " AND CQD.IS_CASE_COMPLETE='Y'";

        return OleDbHelper.ExecuteDataset(connobj.ConnectionString, CommandType.Text, sSql);
    }


    #region Calculate TAT Hours for CELLULAR
    public string CalulateTATHrsCellular(DateTime sFromDate, DateTime sToDate, string strClientId, string strCentreId)
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
        OleDbDataAdapter da = new OleDbDataAdapter();
        OleDbConnection conn = new OleDbConnection(connobj.ConnectionString);
        d_table.Columns.Add("REF_NO");
        d_table.Columns.Add("APPLICANT_NAME");
        d_table.Columns.Add("REC_DATE");
        d_table.Columns.Add("TAT_HRS");
        d_table.Columns.Add("CaseId");
        try
        {
            string sSql = " SELECT CD.CASE_ID as CaseId,CD.REF_NO, (ISNULL(CD.APP_FNAME,'')+''+ISNULL(CD.APP_LNAME,'')+''+ " +
                           " ISNULL(CD.APP_MNAME,''))AS APPLICANT_NAME,CD.CASE_REC_DATETIME AS REC_DATE,Null as TAT_HRS " +
                           " FROM CPV_CELLULAR_CASES CD " +
                           " WHERE CD.SEND_DATETIME IS NULL AND (CD.CLIENT_ID='" + strClientId + "') AND " +
                           " (CD.CENTRE_ID='" + strCentreId + "') " +
                           " AND (CD.CASE_REC_DATETIME>='" + sFromDate + "') AND (CD.CASE_REC_DATETIME<='" + sToDate + "')" +
                           " AND IS_CASE_COMPLETE='Y' and CD.CASE_ID='" + CaseId + "'";

            da = new OleDbDataAdapter(sSql, conn);
            da.Fill(ds, "TAT");
            if (ds.Tables["TAT"].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables["TAT"].Rows.Count; i++)
                {
                    drow = d_table.NewRow();
                    drow[0] = ds.Tables["TAT"].Rows[i]["REF_NO"];
                    drow[1] = ds.Tables["TAT"].Rows[i]["APPLICANT_NAME"];

                    drow[2] = Convert.ToDateTime(ds.Tables["TAT"].Rows[i]["REC_DATE"].ToString()).ToString("dd/MM/yyyy hh:mm tt");
                    String s = ds.Tables["TAT"].Rows[i]["REC_DATE"].ToString();
                    strSendDate1 = Convert.ToDateTime(s.ToString());
                    String s1 = Convert.ToDateTime(connobj.strDate(SendDate)).ToString("MM/dd/yyyy") + " " + SendTime.ToString() + " " + SendTimeType.ToString();
                    strSendDate = Convert.ToDateTime(s1.ToString());
                    ts1 = strSendDate.Subtract(strSendDate1);
                    Hrs = Convert.ToDouble(ts1.Days * 24 + ts1.Hours);
                    mins = Convert.ToDouble(ts1.Minutes);
                    Hours = Hrs.ToString();
                    Minutes = mins.ToString();
                    Total_Hours = Hours + ":" + Minutes;

                }

            }
            return Total_Hours;

        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
    #endregion Calculate TAT Hours


    #region Calculate TAT Hours for QC CELLULAR
    public string CalulateQCTATHrsCellular(DateTime sFromDate, DateTime sToDate, string strClientId, string strCentreId)
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
        OleDbDataAdapter da = new OleDbDataAdapter();
        OleDbConnection conn = new OleDbConnection(connobj.ConnectionString);
        d_table.Columns.Add("REF_NO");
        d_table.Columns.Add("APPLICANT_NAME");
        d_table.Columns.Add("REC_DATE");
        d_table.Columns.Add("TAT_HRS");
        d_table.Columns.Add("CaseId");
        try
        {
            string sSql = " SELECT CQD.CASE_ID as CaseId,CQD.REF_NO,(ISNULL(CD.APP_FNAME,'')+''+ISNULL(CD.APP_LNAME,'')+''+  ISNULL(CD.APP_MNAME,''))AS APPLICANT_NAME, " +
                      " CQD.CASE_Received_Date AS REC_DATE,Null as TAT_HRS  FROM CPV_CELLULAR_CASES CD " +
                      " left outer join cpv_qc_case_details CQD on CD.case_id=CQD.case_id " +
                      " WHERE CQD.case_send_date IS NULL  AND (CD.CLIENT_ID='" + strClientId + "') AND " +
                      " (CQD.CENTRE_ID='" + strCentreId + "') " +
                      " AND (CQD.case_received_date>='" + sFromDate + "') AND (CQD.case_received_date<='" + sToDate + "')" +
                      " AND CQD.IS_CASE_COMPLETE='Y' and CQD.CASE_ID='" + CaseId + "'";

            da = new OleDbDataAdapter(sSql, conn);
            da.Fill(ds, "TAT");
            if (ds.Tables["TAT"].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables["TAT"].Rows.Count; i++)
                {
                    drow = d_table.NewRow();
                    drow[0] = ds.Tables["TAT"].Rows[i]["REF_NO"];
                    drow[1] = ds.Tables["TAT"].Rows[i]["APPLICANT_NAME"];

                    drow[2] = Convert.ToDateTime(ds.Tables["TAT"].Rows[i]["REC_DATE"].ToString()).ToString("dd/MM/yyyy hh:mm tt");
                    String s = ds.Tables["TAT"].Rows[i]["REC_DATE"].ToString();
                    strSendDate1 = Convert.ToDateTime(s.ToString());
                    String s1 = Convert.ToDateTime(connobj.strDate(SendDate)).ToString("MM/dd/yyyy") + " " + SendTime.ToString() + " " + SendTimeType.ToString();
                    strSendDate = Convert.ToDateTime(s1.ToString());
                    ts1 = strSendDate.Subtract(strSendDate1);
                    Hrs = Convert.ToDouble(ts1.Days * 24 + ts1.Hours);
                    mins = Convert.ToDouble(ts1.Minutes);
                    Hours = Hrs.ToString();
                    Minutes = mins.ToString();
                    Total_Hours = Hours + ":" + Minutes;

                }

            }
            return Total_Hours;

        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
    #endregion Calculate QC TAT Hours

}