using System;
using System.Data;
using System.Data.OleDb;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

/// <summary>
/// Summary description for CConsolidateTAT
/// </summary>
public class CConsolidateTAT
{
	public CConsolidateTAT()
	{
        oCmn = new CCommon();
	}
    private string strFromDate;
    private string strToDate;
    
    public string FromDate
    {
        get { return strFromDate; }
        set { strFromDate = value; }

    }
    public string ToDate
    {
        get { return strToDate; }
        set { strToDate = value; }
    }
    private CCommon oCmn;
   
    public DataSet GetReport()
    {
        string strClientID = HttpContext.Current.Session["ClientId"].ToString();
        DataSet ds = new DataSet();
        OleDbConnection con = new OleDbConnection(oCmn.ConnectionString);
        con.Open();
        //CHECK ABOUT CLIENT..(THIS IS FOR CLIENT =1013)...........
        string str = "SELECT Convert(varchar(24),CASE_REC_DATETIME,103) as CASE_REC_DATETIME,SEND_DATETIME, COUNT(CASE_REC_DATETIME) AS NO, SUM(GRATER) AS WITHIN_TAT, SUM(STANDARD) AS GRATER_THAN_TAT, SUM(PENDING)AS PENDING, "+
                     "CAST((CAST(SUM(GRATER)AS DECIMAL(18,2))/CAST(COUNT(CASE_REC_DATETIME)AS DECIMAL(18,2)))* 100 AS DECIMAL(18,2)) AS PER_WITHIN, "+
                     "CAST(CAST(SUM(STANDARD)AS DECIMAL(18,2))/CAST(COUNT(CASE_REC_DATETIME)AS DECIMAL(18,2))* 100 AS DECIMAL(18,2)) AS PER_GRATER_TAT, "+
                     "CAST(CAST(SUM(PENDING)AS DECIMAL(18,2))/CAST(COUNT(CASE_REC_DATETIME)AS DECIMAL(18,2))* 100 AS DECIMAL(18,2)) AS PER_PENDING  FROM  "+
                     "(SELECT CASE_REC_DATETIME, CASE WITHIN_TAT WHEN 0 THEN 1 ELSE 0 END AS 'GRATER',  "+
                     "CASE WITHIN_TAT WHEN 1 THEN 1 ELSE 0 END AS 'STANDARD', SEND_DATETIME, CASE SEND_DATETIME WHEN ISNULL(SEND_DATETIME, '') THEN 0 ELSE 1 END AS 'PENDING' FROM CPV_CC_CASE_DETAILS  " +
                     "WHERE CASE_REC_DATETIME >= '" + strFromDate + "' AND  CASE_REC_DATETIME <'" + strToDate + "' and Client_Id=" + strClientID + ")AS DERIVETABLE_1  " +
                     "GROUP BY CASE_REC_DATETIME, SEND_DATETIME "+
                     "order by CASE_REC_DATETIME";
        ds= OleDbHelper.ExecuteDataset(con, CommandType.Text, str);
        return ds;
    }
}
