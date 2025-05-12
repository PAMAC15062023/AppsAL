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
/// Summary description for CC_CFEWiseSearch
/// </summary>
public class CC_CFEWiseSearch
{
    CCommon oCom = new CCommon();
    private string dateFrom;

    public string DateFrom
    {
        get { return dateFrom; }
        set { dateFrom = value; }
    }
    private string dateTo;

    public string DateTo
    {
        get { return dateTo; }
        set { dateTo = value; }
    }

	public CC_CFEWiseSearch()
	{
		
	}
    public DataSet getdata()
    {
        string str = "SELECT  dISTINCT(dbo.FE_VW.FULLNAME),  count(*) as Total, " +

 " Case WHEN dbo.VERIFICATION_TYPE_MASTER.VERIFICATION_TYPE_CODE='BV' THEN count(*)" +

 " End as BV,Case WHEN dbo.VERIFICATION_TYPE_MASTER.VERIFICATION_TYPE_CODE='RV' THEN count(*) end as RV, case WHEN dbo.VERIFICATION_TYPE_MASTER.VERIFICATION_TYPE_CODE='PRV' THEN count(*)" +

 " End as PRV FROM   dbo.CPV_CC_FE_CASE_MAPPING INNER JOIN dbo.VERIFICATION_TYPE_MASTER ON dbo.CPV_CC_FE_CASE_MAPPING.VERIFICATION_TYPE_ID = dbo.VERIFICATION_TYPE_MASTER.VERIFICATION_TYPE_ID INNER JOIN " +

 "dbo.FE_VW ON dbo.CPV_CC_FE_CASE_MAPPING.FE_ID = dbo.FE_VW.EMP_ID  where dbo.CPV_CC_FE_CASE_MAPPING.date_time between '" + dateFrom + "' and '" + dateTo + "'  group by dbo.FE_VW.FULLNAME,dbo.VERIFICATION_TYPE_MASTER.VERIFICATION_TYPE_CODE";
        
        return OleDbHelper.ExecuteDataset(oCom.ConnectionString, CommandType.Text, str);
    }
}
