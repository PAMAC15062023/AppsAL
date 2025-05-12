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
/// Summary description for CHR_Export
/// </summary>
public class CHR_Export
{
    CCommon objconn = new CCommon();
	public CHR_Export()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    private string centreID;
    public string CentreID
    {
        get { return centreID; }
        set { centreID = value; }
    }
    private string clusterID;
    public string ClusterID
    {
        get { return clusterID; }
        set { clusterID = value; }
    }
    private string subCentreID;
    public string SubCentreID
    {
        get { return subCentreID; }
        set { subCentreID = value; }
    }
    private string tempEmpCode;
    public string TempEmpCode
    {
        get { return tempEmpCode; }
        set { tempEmpCode = value; }
    }
    private string empCode;
    public string EmpCode
    {
        get { return empCode; }
        set { empCode = value; }
    }
    private string from ;
    public string From
    {
        get { return from; }
        set { from = value; }
    }
    private string to;
    public string To
    {
        get { return to; }
        set { to = value; }
    }


    public DataTable GetClusterName()
    {
        string sSql = "";

        DataTable dt = new DataTable();

        sSql = " SELECT CLUSTER_ID,CLUSTER_NAME FROM CLUSTER_MASTER order by  CLUSTER_NAME";
                
        OleDbDataAdapter oledbDa = new OleDbDataAdapter(sSql, objconn.ConnectionString);
        DataSet ds = new DataSet();
        oledbDa.Fill(ds, "ClusterName");
        dt = ds.Tables["ClusterName"];
        return dt;

    }
    public DataTable GetCentreName(string clusterid)
    {
        string sSql = "";

        DataTable dt = new DataTable();

        sSql = "SELECT CENTRE_ID,CENTRE_NAME from CENTRE_MASTER where " +
                " CLUSTER_ID = '" + clusterid + "'" + " order by CENTRE_NAME";

        OleDbDataAdapter oledbDa = new OleDbDataAdapter(sSql, objconn.ConnectionString);
        DataSet ds = new DataSet();
        oledbDa.Fill(ds,"CentreName");
        dt = ds.Tables["CentreName"];
        return dt;

    }
    public DataTable GetSubCentreName(string centreid)
    {
        string sSql = "";

        DataTable dt = new DataTable();

         sSql = "SELECT SubCentreId,SubCentreName from SubCentreMaster where " +
                " CentreId = '" + centreid + "'" + " order by SubCentreName";
       
        OleDbDataAdapter oledbDa = new OleDbDataAdapter(sSql, objconn.ConnectionString);
        DataSet ds = new DataSet();
        oledbDa.Fill(ds, "SubCentreName");
        dt = ds.Tables["SubCentreName"];
        return dt;

    }
    

    public DataTable GetExportSearch()
    {

        DataSet ds = new DataSet();
        DataTable dt = new DataTable();
        OleDbConnection sqlCON = new OleDbConnection(objconn.ConnectionString);
        sqlCON.Open();
        
        OleDbParameter[] param_ViewRecord = new OleDbParameter[5];

        param_ViewRecord[0] = new OleDbParameter("@ClusterID", OleDbType.VarChar, 50, "CLUSTER_ID");
        param_ViewRecord[0].Value = ClusterID;
        param_ViewRecord[0].Direction = ParameterDirection.Input;

        param_ViewRecord[1] = new OleDbParameter("@CentreId", OleDbType.VarChar, 15, "CENTRE_ID");
        param_ViewRecord[1].Value = CentreID;
        param_ViewRecord[1].Direction = ParameterDirection.Input;

        param_ViewRecord[2] = new OleDbParameter("@SubCentreId", OleDbType.VarChar, 50, "SubCentreId");
        param_ViewRecord[2].Value = SubCentreID;
        param_ViewRecord[2].Direction = ParameterDirection.Input;
        //param_ViewRecord[3] = new OleDbParameter("@EmpCode", OleDbType.VarChar, 15, "EMP_CODE");
        //param_ViewRecord[3].Value = EmpCode;
        //param_ViewRecord[3].Direction = ParameterDirection.Input;
        param_ViewRecord[3] = new OleDbParameter("@FromDate", OleDbType.VarChar, 25, "DOJ");
        param_ViewRecord[3].Value = From;
        param_ViewRecord[3].Direction = ParameterDirection.Input;
        param_ViewRecord[4] = new OleDbParameter("@ToDate", OleDbType.VarChar, 25, "DOJ");
        param_ViewRecord[4].Value = To;
        param_ViewRecord[4].Direction = ParameterDirection.Input;

        ds = OleDbHelper.ExecuteDataset(sqlCON, CommandType.StoredProcedure, "HREXPORT", param_ViewRecord);
        if (ds.Tables[0].Rows.Count > 0)
        {
            dt = ds.Tables[0];
        }
        return dt;
        


    }
}
