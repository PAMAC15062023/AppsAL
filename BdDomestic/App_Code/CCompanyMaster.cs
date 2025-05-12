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
/// Summary description for CCompanyMaster
/// </summary>
public class CCompanyMaster
{
    private CCommon oCmn;

    private string strCoCode;
    private string strCoName;
    private string strCorAdd1;
    private string strCorAdd2;
    private string strCorAdd3;
    private string strCorCity;
    private string strCorPin;
    private string strRegAdd1;
    private string strRegAdd2;
    private string strRegAdd3;
    private string strRegCity;
    private string strRegPin;
   

    private string strCompanyId;
    private string strCompany_Id;


    private string strPrefix;


    public string CompanyCode
    {
        get { return strCoCode; }
        set { strCoCode = value; }
    }

    public string CompanyName
    {
        get { return strCoName; }
        set { strCoName = value; }
    }

    public string CorAdd1
    {
        get { return strCorAdd1; }
        set { strCorAdd1 = value; }
    }
    public string CorAdd2
    {
        get { return strCorAdd2; }
        set { strCorAdd2 = value; }
    }
    public string CorAdd3
    {
        get { return strCorAdd3; }
        set { strCorAdd3 = value; }
    }
    public string CorCity
    {
        get { return strCorCity; }
        set { strCorCity = value; }
    }
    public string Corpin
    {
        get { return strCorPin; }
        set { strCorPin = value; }
    }
    public string RegAdd1
    {
        get { return strRegAdd1; }
        set { strRegAdd1 = value; }
    }

    public string RegAdd2
    {
        get { return strRegAdd2; }
        set { strRegAdd2 = value; }
    }
    public string RegAdd3
    {
        get { return strRegAdd3; }
        set { strRegAdd3 = value; }
    }
    public string RegCity
    {
        get { return strRegCity; }
        set { strRegCity = value; }
    }
    public string Regpin
    {
        get { return strRegPin; }
        set { strRegPin = value; }
    }
    public string CompanyId
    {
        get { return strCompanyId; }
    }
    public String Company_Id    //1
    {
        get { return strCompany_Id; }
        set { strCompany_Id = value; }
    }
   

	public CCompanyMaster()
	{
        oCmn = new CCommon();
		
	}

    public void InsertCompanyMaster()
    {

        OleDbConnection sqlConn = new OleDbConnection(oCmn.ConnectionString);
        sqlConn.Open();
        strPrefix = "101";
        
        OleDbTransaction sqlTrans = sqlConn.BeginTransaction();
        try
        {
            strCompanyId = oCmn.GetUniqueID("COMPANY_MASTER", strPrefix).ToString();
            string CompanyMast = "insert into company_master (COMPANY_ID,COMPANY_CODE,COMPANY_NAME,REG_ADD1,REG_ADD2,REG_ADD3,REG_CITY,REG_PIN,CORS_ADD1,CORS_ADD2,CORS_ADD3,CORS_CITY,CORS_PIN) VALUES(?,?,?,?,?,?,?,?,?,?,?,?,?)";
            OleDbParameter[] paramCompany = new OleDbParameter[13];
            paramCompany[0] = new OleDbParameter("@CompanyId", OleDbType.VarChar, 50);
            paramCompany[0].Value = strCompanyId;
            paramCompany[1] = new OleDbParameter("@CompanyCode", OleDbType.VarChar, 10);
            paramCompany[1].Value = strCoCode;
            paramCompany[2] = new OleDbParameter("@CompanyName", OleDbType.VarChar, 100);
            paramCompany[2].Value = strCoName;

            paramCompany[3] = new OleDbParameter("@RegAdd1", OleDbType.VarChar, 100);
            paramCompany[3].Value = strRegAdd1;
            paramCompany[4] = new OleDbParameter("@RegAdd2", OleDbType.VarChar, 100);
            paramCompany[4].Value = strRegAdd2;
            paramCompany[5] = new OleDbParameter("@RegAdd3", OleDbType.VarChar, 100);
            paramCompany[5].Value = strRegAdd3;

            paramCompany[6] = new OleDbParameter("@RegCity", OleDbType.VarChar, 50);
            paramCompany[6].Value = strRegCity;
            paramCompany[7] = new OleDbParameter("@RegPin", OleDbType.VarChar, 50);
            paramCompany[7].Value = strRegPin;
            paramCompany[8] = new OleDbParameter("@CorAdd1", OleDbType.VarChar, 100);
            paramCompany[8].Value = strCorAdd1;
            paramCompany[9] = new OleDbParameter("@CorAdd2", OleDbType.VarChar, 100);
            paramCompany[9].Value = strCorAdd2;
            paramCompany[10] = new OleDbParameter("@CorAdd3", OleDbType.VarChar, 100);
            paramCompany[10].Value = strCorAdd3;
            paramCompany[11] = new OleDbParameter("@CorCity", OleDbType.VarChar, 50);
            paramCompany[11].Value = strCorCity;
            paramCompany[12] = new OleDbParameter("@CorPin", OleDbType.VarChar, 10);
            paramCompany[12].Value = strCorPin;file:///D:\Sandeep\PMS\Application\App_Data\

            OleDbHelper.ExecuteNonQuery(sqlTrans, CommandType.Text, CompanyMast, paramCompany);
           // string sql="select hier_id from company_hierarchy_master where type='co'";
           //OleDbDataReader oSDR = OleDbHelper.ExecuteReader(sqlTrans, CommandType.Text, sql) ;
           // string[] strHierId = oSDR["hier_id"].ToString().Split(',');

           
            //foreach (string str in strHierId)
            //{

                string strUniqueHierId = oCmn.GetUniqueID("COMPANY_HIERARCHY_MASTER", strPrefix).ToString();
                string strHierarchy = "Insert into COMPANY_HIERARCHY_MASTER values (?, ?, ?, ?, ?)";
                OleDbParameter[] paramHierarchy = new OleDbParameter[5];
                paramHierarchy[0] = new OleDbParameter("@HIER_ID", OleDbType.VarChar, 50);
                paramHierarchy[0].Value = strUniqueHierId;

                paramHierarchy[1] = new OleDbParameter("@REF_ID", OleDbType.VarChar, 50);
                paramHierarchy[1].Value = strCompanyId;

                paramHierarchy[2] = new OleDbParameter("@HIER_LEVEL", OleDbType.Numeric);
                paramHierarchy[2].Value = 1;

                paramHierarchy[3] = new OleDbParameter("@PARENT_ID", OleDbType.VarChar, 50);
                paramHierarchy[3].Value = 1;

                paramHierarchy[4] = new OleDbParameter("@TYPE", OleDbType.VarChar, 5);
                paramHierarchy[4].Value = "CO";

                OleDbHelper.ExecuteNonQuery(sqlTrans, CommandType.Text, strHierarchy, paramHierarchy);

                
            //}
                sqlTrans.Commit();
                sqlConn.Close();
        }

        catch (System.Exception ex)
        {
            sqlTrans.Rollback();
            sqlConn.Close();
            throw new Exception("An error occurred while executing the insert Company", ex);
        }
 
    }
    public void getCompany()
    {
        OleDbConnection sqlConn = new OleDbConnection(oCmn.ConnectionString);
        String sql = "";
        OleDbDataReader ord;
        sql = "select * from company_master where company_id=?";
        OleDbParameter[] paramCompany = new OleDbParameter[1];
        paramCompany[0] = new OleDbParameter("@company_id", OleDbType.VarChar, 50);
        paramCompany[0].Value = strCompany_Id;
        ord = OleDbHelper.ExecuteReader(sqlConn, CommandType.Text, sql, paramCompany);
        if (ord.HasRows)
        {
            while (ord.Read())
            {
                CompanyCode = ord["company_code"].ToString();
                CompanyName = ord["company_name"].ToString();
                CorAdd1 = ord["cors_add1"].ToString();
                CorAdd2 = ord["cors_add2"].ToString();
                CorAdd3 = ord["cors_add3"].ToString();
                CorCity = ord["cors_city"].ToString();
                Corpin = ord["cors_Pin"].ToString();
                RegAdd1 = ord["reg_add1"].ToString();
                RegAdd2 = ord["reg_add2"].ToString();
                RegAdd3 = ord["reg_add3"].ToString();
                RegCity = ord["reg_city"].ToString();
                Regpin=ord["reg_pin"].ToString();
            }
        }
        ord.Close(); 
    }
    public void UpdateCompany()
    {
        OleDbConnection sqlConn = new OleDbConnection(oCmn.ConnectionString);
        sqlConn.Open();
        OleDbTransaction sqlTrans = sqlConn.BeginTransaction();
        try
        {
            
            String sql = "";
            sql = "update company_master set company_name=?, reg_add1=?,reg_add2=?,reg_add3=?,reg_city=?,reg_pin=?,cors_add1=?,cors_add2=?,cors_add3=?,cors_city=?,cors_pin=? where company_id=?";
            OleDbParameter[] paramCompany = new OleDbParameter[12];
            paramCompany[0] = new OleDbParameter("@CompanyName", OleDbType.VarChar, 100);
            paramCompany[0].Value = strCoName;

            paramCompany[1] = new OleDbParameter("@RegAdd1", OleDbType.VarChar, 100);
            paramCompany[1].Value = strRegAdd1;
            paramCompany[2] = new OleDbParameter("@RegAdd2", OleDbType.VarChar, 100);
            paramCompany[2].Value = strRegAdd2;
            paramCompany[3] = new OleDbParameter("@RegAdd3", OleDbType.VarChar, 100);
            paramCompany[3].Value = strRegAdd3;

            paramCompany[4] = new OleDbParameter("@RegCity", OleDbType.VarChar, 50);
            paramCompany[4].Value = strRegCity;
            paramCompany[5] = new OleDbParameter("@RegPin", OleDbType.VarChar, 50);
            paramCompany[5].Value = strRegPin;
            paramCompany[6] = new OleDbParameter("@CorAdd1", OleDbType.VarChar, 100);
            paramCompany[6].Value = strCorAdd1;
            paramCompany[7] = new OleDbParameter("@CorAdd2", OleDbType.VarChar, 100);
            paramCompany[7].Value = strCorAdd2;
            paramCompany[8] = new OleDbParameter("@CorAdd3", OleDbType.VarChar, 100);
            paramCompany[8].Value = strCorAdd3;
            paramCompany[9] = new OleDbParameter("@CorCity", OleDbType.VarChar, 50);
            paramCompany[9].Value = strCorCity;
            paramCompany[10] = new OleDbParameter("@CorPin", OleDbType.VarChar, 10);
            paramCompany[10].Value = strCorPin;
            paramCompany[11] = new OleDbParameter("@company_id", OleDbType.VarChar, 50);
            paramCompany[11].Value = strCompany_Id;

            OleDbHelper.ExecuteNonQuery(sqlTrans, CommandType.Text, sql, paramCompany);

            sqlTrans.Commit();
            sqlConn.Close();
        }
        catch (System.Exception ex)
        {
            sqlTrans.Rollback();
            sqlConn.Close();
            throw new Exception("An error occurred while executing the Update Company", ex);
        }
    }

    public DataSet companyName()
    {
        OleDbConnection sqlConn = new OleDbConnection(oCmn.ConnectionString);
        sqlConn.Open();
        String sql = "";
        sql = "select Company_Name from company_master where company_id='1011'";
        return OleDbHelper.ExecuteDataset(sqlConn, CommandType.Text, sql);
    }

}
