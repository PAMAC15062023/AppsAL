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
/// Summary description for CHR_UploadFiles
/// </summary>
public class CHR_UploadFiles
{
    CCommon objconn = new CCommon();
	public CHR_UploadFiles()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    private string empCode;
    public string EmpCode
    {
        get { return empCode; }
        set { empCode = value; }
    }
    private string empName;
    public string EmpName
    {
        get { return empName; }
        set { empName = value; }
    }
    public DataTable GetUploadSearch()
    {

        DataSet ds = new DataSet();
        DataTable dt = new DataTable();
        OleDbConnection sqlCON = new OleDbConnection(objconn.ConnectionString);
        sqlCON.Open();

        OleDbParameter[] param_ViewRecord = new OleDbParameter[2];

        param_ViewRecord[0] = new OleDbParameter("@EMPCode", OleDbType.VarChar, 15);
        param_ViewRecord[0].Value = EmpCode;
        param_ViewRecord[0].Direction = ParameterDirection.Input;

        param_ViewRecord[1] = new OleDbParameter("@EmpName", OleDbType.VarChar, 300);
        param_ViewRecord[1].Value = EmpName;
        param_ViewRecord[1].Direction = ParameterDirection.Input;



        ds = OleDbHelper.ExecuteDataset(sqlCON, CommandType.StoredProcedure, "HRFileUploadSearch", param_ViewRecord);
        if (ds.Tables[0].Rows.Count > 0)
        {
            dt = ds.Tables[0];
        }
        return dt;



    }
    public DataTable GetUploadSelection()
    {

        DataSet ds = new DataSet();
        DataTable dt = new DataTable();
        OleDbConnection sqlCON = new OleDbConnection(objconn.ConnectionString);
        sqlCON.Open();

        OleDbParameter[] param_ViewRecord = new OleDbParameter[2];

        param_ViewRecord[0] = new OleDbParameter("@EMPCode", OleDbType.VarChar, 15);
        param_ViewRecord[0].Value = EmpCode;
        param_ViewRecord[0].Direction = ParameterDirection.Input;

        param_ViewRecord[1] = new OleDbParameter("@EmpName", OleDbType.VarChar, 300);
        param_ViewRecord[1].Value = EmpName;
        param_ViewRecord[1].Direction = ParameterDirection.Input;



        ds = OleDbHelper.ExecuteDataset(sqlCON, CommandType.StoredProcedure, "HRFileUploadSelection", param_ViewRecord);
        if (ds.Tables[0].Rows.Count > 0)
        {
            dt = ds.Tables[0];
        }
        return dt;
    }

    public void UploadEmpMaster(string strFile,int empID)
    {
    OleDbConnection sqlCON = new OleDbConnection(objconn.ConnectionString);
    string strQuery = "Update Employee_Master set PHOTO_PATH='" + strFile + "' where EMP_ID=" + empID;
    OleDbCommand sqlCmd = new OleDbCommand(strQuery, sqlCON);
    sqlCON.Open();
    int j = (int)sqlCmd.ExecuteNonQuery();
    sqlCON.Close();
    
    }
    public void UploadEmpQualification(string strFile, int empID, int qID, string copiesAttached)
    {
        OleDbConnection sqlCON = new OleDbConnection(objconn.ConnectionString);
        string strQuery = "Update EMPLOYEE_EDUCATION_QUALIFICATION set File_Path='" + strFile + "' ,Copies_Attached ='" + copiesAttached + "' where EMP_ID=" + empID + " and Education_Qualification_Id=" + qID;
        OleDbCommand sqlCmd = new OleDbCommand(strQuery, sqlCON);
        sqlCON.Open();
        int j = (int)sqlCmd.ExecuteNonQuery();
        sqlCON.Close();
    }
    public OleDbDataReader GetRecordsofLable(string empCode)
    {
        string sSql = "";
        sSql = "select EMP_CODE as [Employee Code],isnull(FIRSTNAME,'')+ ' ' + isnull(MIDDLENAME,'')+ ' ' +isnull(LASTNAME,'') as [Name], " +
                
                "CLUSTER_NAME as [Cluster Name],CENTRE_NAME as [Centre Name],SubCentreName as [Subcentre Name] "+
                "from Employee_Master em "+

                "left join CENTRE_MASTER cenm "+
                "on em.CENTRE_ID=cenm.CENTRE_ID "+ 

                "left join CLUSTER_MASTER clusm "+
                "on cenm.CLUSTER_ID=clusm.CLUSTER_ID "+

                "left join SubCentreMaster subcenm " +
                "on em.SUBCENTRE_ID=subcenm.SubCentreId  where EMP_CODE='" + empCode + "' ";


        return OleDbHelper.ExecuteReader(objconn.ConnectionString, CommandType.Text, sSql);
    }
}
