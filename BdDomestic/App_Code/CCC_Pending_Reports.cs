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
/// Summary description for CCC_Printing_Reports
/// </summary>
public class CCC_Printing_Reports
{
    CCommon oCom;
    private string Client_ID;
    private string Center_ID;
    private string DateFrom;
    private string DateTo;
    private string Date;

    public string Date1
    {
        get { return Date; }
        set { Date = value; }
    }

    public string DateTo1
    {
        get { return DateTo; }
        set { DateTo = value; }
    }

    public string DateFrom1
    {
        get { return DateFrom; }
        set { DateFrom = value; }
    }

    public string Center_ID1
    {
        get { return Center_ID; }
        set { Center_ID = value; }
    }

    public string Client_ID1
    {
        get { return Client_ID; }
        set { Client_ID = value; }
    }
	public CCC_Printing_Reports()
	{
        oCom = new CCommon();
		//
		// TODO: Add constructor logic here
		//
	}
    public DataSet getPendingReport()
    {
        OleDbConnection sqlcon = new OleDbConnection(oCom.ConnectionString);
        sqlcon.Open();
        string strSelect = "";
        strSelect = " SELECT DISTINCT(CD.CASE_REC_DATETIME) as RECEIVED_DATE ,count(CD.CASE_REC_DATETIME) AS TOTAL , ";
        strSelect += " COUNT(CD.SEND_DATETIME) AS COMPLETE ,CD.SEND_DATETIME AS SEND_DATE , ";
        strSelect += " (COUNT(CD.CASE_REC_DATETIME)-COUNT(CD.SEND_DATETIME)) AS PENDING ";
        strSelect += " FROM CPV_CC_CASE_DETAILS CD ";
        strSelect += " WHERE CONVERT(VARCHAR,CD.CASE_REC_DATETIME,106) BETWEEN '" + DateFrom1 + "' AND '" + DateTo1 + "' ";
        strSelect += " AND CD.CLIENT_ID='" + Client_ID1 + "' AND CD.CENTRE_ID='" + Center_ID1 + "' ";
        strSelect += " GROUP  BY CD.CASE_REC_DATETIME,CD.SEND_DATETIME ";
        strSelect += " ORDER BY CD.CASE_REC_DATETIME ASC,CD.SEND_DATETIME";
        //SQL QUERY
        return OleDbHelper.ExecuteDataset(sqlcon, CommandType.Text, strSelect);
    
        //REASON: Send_dateTime field changed from table CPV_CC_CASE_VERI to table CPV_CC_CASE_DETAILS //

        //string strSelect = "";
        //strSelect  = " SELECT DISTINCT(cd.case_rec_dateTime) as RECEIVED_DATE ,count(cd.case_rec_dateTime) AS TOTAL , ";
        //strSelect += " COUNT(VD.SEND_DATETIME) AS COMPLETE ,VD.SEND_DATETIME AS SEND_DATE , ";
        //strSelect += " (count(cd.case_rec_dateTime)-COUNT(VD.SEND_DATETIME)) AS PENDING ";
        //strSelect += " from CPV_CC_CASE_DETAILS CD INNER JOIN CPV_CC_VERI_DETAILS VD ON CD.CASE_ID=VD.CASE_ID ";
        //strSelect += " WHERE (CD.CASE_REC_DATETIME BETWEEN '"+DateFrom1+"' AND '"+DateTo1+"')  ";
        //strSelect += " AND CD.CLIENT_ID='" + Client_ID1 + "' AND CD.CENTRE_ID='" + Center_ID1 + "' ";
        //strSelect += " GROUP  BY cd.case_rec_dateTime,VD.SEND_DATETIME ";//SQL QUERY
        //return OleDbHelper.ExecuteDataset(sqlcon, CommandType.Text, strSelect);
    }
    //public DataSet getPendingReportGraph()
    //{
    //    //OleDbConnection sqlcon= new OleDbConnection(oCom.ConnectionString);
    //    //sqlcon.Open();
    //    //string strGraph = "";
    //    //strGraph = " SELECT distinct(CASE_REC_DATETIME) AS RECEIVED_DATE,";
    //    //strGraph += " COUNT(CASE_REC_DATETIME) AS TOTAL_RECEIVED,";
    //    //strGraph += " SEND_DATETIME AS SEND_DATETIME ,";
    //    //strGraph += " count(SEND_DATETIME) AS TOTAL_SEND,";
    //    //strGraph += " (count(CASE_REC_DATETIME)-COUNT(SEND_DATETIME)) AS PENDING ";
    //    //strGraph += " FROM cpv_cc_case_details ";
    //    //strGraph += " WHERE CASE_REC_DATETIME BETWEEN '" + DateFrom1 + "'  AND '" + DateTo1 + "'";
    //    //strGraph += " AND CLIENT_ID='" + Client_ID1 + "' AND CENTRE_ID='" + Center_ID1 + "' ";
    //    //strGraph += " GROUP BY CASE_REC_DATETIME,SEND_DATETIME";
    //    //strGraph += " ORDER BY CASE_REC_DATETIME";
    //    ////strGraph += " COMPUTE  SUM(COUNT(CASE_REC_DATETIME)) ";

    //    //return OleDbHelper.ExecuteDataset(sqlcon,CommandType.Text,strGraph);

    //}
    //public DataSet getdate()
    //{
    //    OleDbConnection sqlcon = new OleDbConnection(oCom.ConnectionString);
    //    sqlcon.Open();
    //    string strDate = "";
    //    strDate = " SELECT distinct(CASE_REC_DATETIME),COUNT(CASE_REC_DATETIME) from cpv_cc_case_details ";
    //    strDate += " where CASE_REC_DATETIME between '01-jan-2007' AND '20-jan-2007' ";
    //    strDate += " GROUP BY CASE_REC_DATETIME ";
    //    strDate += " ORDER BY CASE_REC_DATETIME ASC ";
    //    return OleDbHelper.ExecuteDataset(sqlcon, CommandType.Text, strDate);
    //}
    //public DataSet getSendDate()
    //{
    //    OleDbConnection sqlcon = new OleDbConnection(oCom.ConnectionString);
    //    sqlcon.Open();
    //    string strDate = "";
    //    strDate += " SELECT SEND_DATETIME,COUNT(SEND_DATETIME) FROM CPV_CC_CASE_DETAILS ";
    //    strDate += " WHERE CASE_REC_DATETIME ='"+Date1+"' ";
    //    strDate += " GROUP BY SEND_DATETIME ";
    //    strDate += " ORDER BY SEND_DATETIME ASC ";
        
    //    return OleDbHelper.ExecuteDataset(sqlcon, CommandType.Text, strDate);

    //}
    //public DataSet getCrossTab()
    //{
    //    OleDbConnection sqlCon = new OleDbConnection(oCom.ConnectionString);
    //    sqlCon.Open();
    //    string datediff = "";
    //    datediff = " select datediff(dd,'"+DateFrom1+"','"+DateTo1+"') as Nos_of_Days   ";
    //    return OleDbHelper.ExecuteDataset(sqlCon, CommandType.Text, datediff);
    //}


}
