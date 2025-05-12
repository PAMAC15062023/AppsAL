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
/// Summary description for C_EIS_Reports
/// </summary>
public class C_EIS_Reports
{
    CCommon objcommon = new CCommon();
    DataSet ds = new DataSet();    
    public C_EIS_Reports()
	{
		//
		// TODO: Add constructor logic here
		//
    }
    # region PropertiesforPendingPan
    private int iClusterId;
    private int iCentreId;
    private int iSubCentreId;
    private string iReportfor;
    private DateTime ifromDate;
    private DateTime itoDate;
    public DateTime fromDate
    {
        get
        {
            return ifromDate;
        }
        set
        {
            ifromDate = value;
        }
    }
    public DateTime toDate
    {
        get
        {
            return itoDate;
        }
        set
        {
            itoDate = value;
        }
    }
    public int ClusterId
    {
        get
        {
            return iClusterId;
        }
        set
        {
            iClusterId = value;
        }
    }
    public int CentreId
    {
        get
        {
            return iCentreId;
        }
        set
        {
            iCentreId = value;
        }
    }
    public int SubCentreId
    {
        get
        {
            return iSubCentreId;
        }
        set
        {
            iSubCentreId = value;
        }
    }
   public string Reportfor 
    {
        get
        {
            return iReportfor;
        }
        set
        {
            iReportfor = value;
        }
    }
# endregion 
    public DataView GetPanSearchRecords(string FromDate, string ToDate)
    {
        DataView dv = new DataView();
        DataTable dt = new DataTable(); 
        OleDbConnection sqlcon = new OleDbConnection(objcommon.ConnectionString);
        sqlcon.Open();
        OleDbParameter[] oledbParam =new OleDbParameter[4];

        //oledbParam[0] = new OleDbParameter("@fromDate", OleDbType.DBTimeStamp, 15);
        //oledbParam[0].Value = ifromDate;
        //oledbParam[0].Direction = ParameterDirection.Input;

        //oledbParam[1] = new OleDbParameter("@toDate", OleDbType.DBTimeStamp, 15);
        //oledbParam[1].Value = itoDate;
        //oledbParam[1].Direction = ParameterDirection.Input;

        oledbParam[0] = new OleDbParameter("@clusterId", OleDbType.Integer, 4);
        oledbParam[0].Value = iClusterId;
        oledbParam[0].Direction = ParameterDirection.Input;

        oledbParam[1] = new OleDbParameter("@centreId", OleDbType.Integer, 4);
        oledbParam[1].Value = iCentreId;
        oledbParam[1].Direction = ParameterDirection.Input;

        oledbParam[2] = new OleDbParameter("@SubCentreId", OleDbType.Integer, 4);
        oledbParam[2].Value = iSubCentreId;
        oledbParam[2].Direction = ParameterDirection.Input;

        oledbParam[3] = new OleDbParameter("@For", OleDbType.VarChar, 50);
        oledbParam[3].Value = iReportfor;
        oledbParam[3].Direction = ParameterDirection.Input;

        ds = OleDbHelper.ExecuteDataset(sqlcon, CommandType.StoredProcedure, "SpEmployeeDetailsSearch", oledbParam);
        dt = ds.Tables[0];
        dv = dt.DefaultView;
        string Search = "DOJ >= '" + strDateConverter(FromDate.ToString()) + "' And DOJ < '" + strDateConverter(ToDate.ToString()).AddDays(1.0) + "'";
        dv.RowFilter = Search;
        return dv;
    }
    public DataSet GetPanRecords()
    {
        OleDbConnection sqlcon = new OleDbConnection(objcommon.ConnectionString);
        sqlcon.Open();
        OleDbParameter[] oledbParam = new OleDbParameter[1];

        oledbParam[0] = new OleDbParameter("@for", OleDbType.VarChar, 10);
        oledbParam[0].Value = iReportfor;
        oledbParam[0].Direction = ParameterDirection.Input;
        
        ds = OleDbHelper.ExecuteDataset(sqlcon, CommandType.StoredProcedure, "SpEmployeeDetails", oledbParam);

        return ds;

    }
    public DateTime strDateConverter(string strInDate)
    {
        int DateLength = strInDate.Length;
        string strDD = strInDate.Substring(0, 2);
        string strMM = strInDate.Substring(3, 2);
        string strYYYY = strInDate.Substring(6, 4);
        string strMMDDYYYY = strMM + "/" + strDD + "/" + strYYYY;
        DateTime dtConvertDate = Convert.ToDateTime(strMMDDYYYY);
        return dtConvertDate;

    }
    public void FillComboList(DropDownList ddl, string strvalue, string strtext,string Procedure, int paramvalue)
    {
        OleDbConnection sqlcon = new OleDbConnection(objcommon.ConnectionString);
        sqlcon.Open();
        OleDbParameter[] oledbParam = new OleDbParameter[1];

        oledbParam[0] = new OleDbParameter("@Param", OleDbType.Integer, 4);
        oledbParam[0].Value = paramvalue;
        oledbParam[0].Direction = ParameterDirection.Input;

        ds = OleDbHelper.ExecuteDataset(sqlcon, CommandType.StoredProcedure, Procedure, oledbParam);
        ddl.DataTextField = strtext.ToString();
        ddl.DataValueField = strvalue.ToString();
        if (ds.Tables.Count > 0)
        {
            ddl.DataSource = ds;
            ddl.DataBind();
        }
    }
}
