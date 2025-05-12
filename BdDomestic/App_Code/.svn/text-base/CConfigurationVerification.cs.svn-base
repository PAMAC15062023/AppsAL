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
/// Summary description for CConfigurationVerification
/// </summary>
public class CConfigurationVerification
{
    private CCommon objCommon;
  
    private string strTemplateID;
    private string strTableName;
    private string strMultipleColumn;
    private string strColumnName;
    private string strComparingValue;
    private string strExpectedValue;
    private string strString;
    private string strVerificationTypeID;
   
    private string strSeparator;
    private string strseparatorValue;
    private string strMultipleValue;
   public string TemplateID
    {
        get { return strTemplateID; }
        set { strTemplateID = value; }
    }

    public string TableName
    {
        get { return strTableName; }
        set { strTableName = value; }
    }

    public string MultipleCollumn
    {
        get { return strMultipleColumn; }
        set { strMultipleColumn = value; }
    }

    public string ColumnName
    {
        get { return strColumnName; }
        set { strColumnName = value; }
    }

    public string ComparingValue
    {
        get { return strComparingValue; }
        set { strComparingValue = value; }
    }

    public string ExpectedValue
    {
        get { return strExpectedValue; }
        set { strExpectedValue = value; }
    }

    public string String1  
    {
        get { return strString; }
        set { strString = value; }
    }

    public string VerificationTypeID
    {
        get { return strVerificationTypeID; }
        set { strVerificationTypeID = value; }
    }
  
    public string Separator
    {
        get { return strSeparator; }
        set { strSeparator = value; }
    }
     public string SeparatorValue
    {
        get { return strseparatorValue; }
        set { strseparatorValue = value; }
    }

    public string MultipleVakue
    {
        get { return strMultipleValue; }
        set { strMultipleValue = value; }
    }
	public CConfigurationVerification()
	{
        objCommon = new CCommon();
	}
    public void InsertVerificationMaster()
    {
       

        OleDbConnection sqlConn = new OleDbConnection(objCommon.ConnectionString);
        sqlConn.Open();

        string strsql = "";
   
        
        OleDbTransaction sqlTrans = sqlConn.BeginTransaction();
        try
        {
            
                strsql = "insert into import_verification_master (template_id,table_name,multiple_column,column_name,expected_value,separator,separator_char,multiple_value) values (?,?,?,?,?,?,?,?)";
                OleDbParameter[] paramImport = new OleDbParameter[8];

                paramImport[0] = new OleDbParameter("@templateId", OleDbType.VarChar, 15);
                paramImport[0].Value = strTemplateID;

                paramImport[1] = new OleDbParameter("@tableName", OleDbType.VarChar, 50);
                paramImport[1].Value = strTableName;

                paramImport[2] = new OleDbParameter("@MultipleColumn", OleDbType.Char, 1);
                paramImport[2].Value = strMultipleColumn;

                paramImport[3] = new OleDbParameter("@ColumnName", OleDbType.VarChar, 1000);
                paramImport[3].Value = strColumnName;

                //paramImport[4] = new OleDbParameter("@ComparingValue", OleDbType.VarChar, 1);
                //paramImport[4].Value = strComparingValue;

                paramImport[4] = new OleDbParameter("@ExpectedValue", OleDbType.VarChar, 200);
                paramImport[4].Value = strExpectedValue;

                paramImport[5] = new OleDbParameter("@Separator", OleDbType.VarChar, 1);
                paramImport[5].Value = strSeparator;

                paramImport[6] = new OleDbParameter("@Separator_char", OleDbType.VarChar, 1);
                paramImport[6].Value = strseparatorValue;

                paramImport[7] = new OleDbParameter("@MultipleValue", OleDbType.VarChar, 1);
                paramImport[7].Value = strMultipleValue;

                OleDbHelper.ExecuteNonQuery(sqlTrans, CommandType.Text, strsql, paramImport);
                sqlTrans.Commit();
                sqlConn.Close();
               
            
        }
           catch(System.Exception ex)
           {
               sqlTrans.Rollback();
               sqlConn.Close();
            throw new Exception("An error occurred while executing the insert string", ex);

           }
             }
         public void InsertVerificationString()
         {
       

        OleDbConnection sqlConn = new OleDbConnection(objCommon.ConnectionString);
        sqlConn.Open();

      
        string strssql = "";
        
        OleDbTransaction sqlTrans = sqlConn.BeginTransaction();
              try
        {
            strssql = "insert into import_verification_string (template_id,string,verification_type_id,comparing_value) values (?,?,?,?)";

            OleDbParameter[] paramImport1 = new OleDbParameter[4];
            paramImport1[0] = new OleDbParameter("@templateId", OleDbType.VarChar, 15);
            paramImport1[0].Value = strTemplateID;

            paramImport1[1] = new OleDbParameter("@string", OleDbType.VarChar, 50);
            paramImport1[1].Value = strString;

            paramImport1[2] = new OleDbParameter("@VerificationTypeID", OleDbType.VarChar, 10);
            paramImport1[2].Value = strVerificationTypeID;

            paramImport1[3] = new OleDbParameter("@ComparingValue", OleDbType.VarChar, 20);
            paramImport1[3].Value = strComparingValue;

            OleDbHelper.ExecuteNonQuery(sqlTrans, CommandType.Text, strssql, paramImport1);


            sqlTrans.Commit();
            sqlConn.Close();
        }
         
        catch (System.Exception ex)
        {
            sqlTrans.Rollback();
            sqlConn.Close();
            throw new Exception("An error occurred while executing the insert string", ex);

        }
 
    }
    public void DeleteVerificationMaster()
    {
         OleDbConnection sqlConn = new OleDbConnection(objCommon.ConnectionString);
        sqlConn.Open();

        string strsql = "";
        
        
        OleDbTransaction sqlTrans = sqlConn.BeginTransaction();
        try
        {
            strsql = "delete from import_verification_master where template_id=" + strTemplateID;
            OleDbHelper.ExecuteNonQuery(sqlTrans, CommandType.Text, strsql);

            sqlTrans.Commit();
            sqlConn.Close();
        }
        catch (Exception ex)
        {
            sqlTrans.Rollback();
            sqlConn.Close();
            throw new Exception("An error occurred while executing the update string", ex);
        }
    }
    public void  DeleteVerificationString()
    {
        OleDbConnection sqlConn = new OleDbConnection(objCommon.ConnectionString);
        sqlConn.Open();

        string strsql = "";


        OleDbTransaction sqlTrans = sqlConn.BeginTransaction();
        try
        {
            strsql = "delete from import_verification_string where template_id='" + strTemplateID + "'";
            OleDbHelper.ExecuteNonQuery(sqlTrans, CommandType.Text, strsql);

            sqlTrans.Commit();
            sqlConn.Close();
        }
        catch (Exception ex)
        {
            sqlTrans.Rollback();
            sqlConn.Close();
            throw new Exception("An error occurred while executing the update string", ex);
        }
    }
}

