using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.IO;
using System.Data.OleDb;

/// <summary>
/// Summary description for CImportTemplate
/// </summary>
public class CImportTemplate
{
  
    private CCommon objCommon;
    private StreamWriter SW;

    private String strCentreID;
    private String strClusterID;
    private String strActivityID;
    private String strClintID;
    private String strProductID;
    private String strBatchId;
    private String strXslSheet;
    private string strTemplateName;
    private string strDataTable;
    private string strTemplateHead;
    private string strDataField;
    private string strSequence;
    private string strTemplateID;
    public string CentreID   
    {
        get { return strCentreID; }
        set
        {
            if (value == "")
            {
                strCentreID = null;
            }
            else
            {
                strCentreID = value;
            }
        }
    }
    public String ClusterID   
    {
        get { return strClusterID; }
        set
        {
            if (value == "")
            {
                strClusterID = null;
            }
            else
            {
                strClusterID = value;
            }
        }
    }

    public String ActivityID   
    {
        get { return strActivityID; }
        set
        {
            if (value == "")
            {
                strActivityID = null;
            }
            else
            {
                strActivityID = value;
            }
        }
    }
    public String ClientID
    {
        get { return strClintID; }
        set
        {
            if (value == "")
            {
                strClintID = null;
            }
            else
            {
                strClintID = value;
            }
        }
    }

    public String ProductID
    {
        get { return strProductID; }
        set
        {
            if (value == "")
            {
                strProductID = null;
            }
            else
            {
                strProductID = value;
            }
        }
    }
    public String XslSheet   //12
    {
        get { return strXslSheet; }
        set
        {
            if (value == "")
            {
                strXslSheet = null;
            }
            else
            {
                strXslSheet = value;
            }
        }
    }

    public string TemplateName
    {
        get { return strTemplateName; }
        set { strTemplateName = value; }
    }
    public string DataTable
    {
        get { return strDataTable; }
        set { strDataTable = value; }
    }

    public string DataField
    {
        get { return strDataField; }
        set { strDataField = value; }
    }
    public string TemplateHead
    {
        get { return strTemplateHead; }
        set { strTemplateHead = value; }
    }

    public string Sequence
    {
        get { return strSequence; }
        set { strSequence = value; }
    }
    public string TemplateID
    {
        get { return strTemplateID; }
        set { strTemplateID = value; }
    }
    public string BatchId   
    {
        get { return strBatchId; }
    }
	public CImportTemplate()
	{
        objCommon = new CCommon();
        strBatchId = this.GetBatchID();
	}

    public string ProductSelect(string strActivity)
    {
        return "Select Distinct Product_Id, Product_Name from CE_AC_PR_CT_VW where Activity_Id= '" + strActivity + "' and product_id is not null AND PRODUCT_NAME IS NOT NULL order by product_name ";
    }
   
    //public string ActivitySelect(string strCentre)
    //{
    //    return "Select Distinct activity_Id, activity_Name from CE_AC_PR_CT_VW where centre_Id= '" + strCentre + "' order by activity_name";
    //}
    public void CreateInsert()
    {
        OleDbConnection sqlConn = new OleDbConnection(objCommon.ConnectionString);
        sqlConn.Open();
      
        string sql = "";
       
        OleDbTransaction sqlTrans = sqlConn.BeginTransaction();
      

  try
 {
           
               
              sql = "insert into import_data_master (template_id,template_name,activity_id,product_id,client_id,data_table,data_field,template_head,data_type,seqence,is_master)values(?,?,?,?,?,?,?,?,?,?,?)";
               OleDbParameter[] paramImport = new OleDbParameter[11];
            paramImport[0] = new OleDbParameter("@templateId", OleDbType.VarChar, 15);
            paramImport[0].Value = strTemplateID;

            paramImport[1] = new OleDbParameter("@templateName", OleDbType.VarChar, 20);
            paramImport[1].Value = strTemplateName;

          
            paramImport[2] = new OleDbParameter("@ActivityId", OleDbType.VarChar, 15);
            paramImport[2].Value = strActivityID;

            paramImport[3] = new OleDbParameter("@product_id", OleDbType.VarChar, 15);
            paramImport[3].Value = strProductID;

            paramImport[4] = new OleDbParameter("@clientID", OleDbType.VarChar, 15);
            paramImport[4].Value = strClintID;

            paramImport[5] = new OleDbParameter("@datatable", OleDbType.VarChar, 50);
            paramImport[5].Value = strDataTable;

            paramImport[6] = new OleDbParameter("@datafield", OleDbType.VarChar, 50);
            paramImport[6].Value = strDataField;

            paramImport[7] = new OleDbParameter("@template", OleDbType.VarChar, 255);
            paramImport[7].Value = strTemplateHead;

            paramImport[8] = new OleDbParameter("@datatype", OleDbType.VarChar, 50);
            paramImport[8].Value = "varchar";

            paramImport[9] = new OleDbParameter("@sequence", OleDbType.VarChar, 8);
            paramImport[9].Value = strSequence;

            paramImport[10] = new OleDbParameter("@ismaster", OleDbType.VarChar, 1);
            paramImport[10].Value = "0";

             OleDbHelper.ExecuteNonQuery(sqlTrans, CommandType.Text, sql, paramImport);
             sqlTrans.Commit();
             sqlConn.Close();

 }
        catch (System.Exception ex)
        {


            sqlTrans.Rollback();
            sqlConn.Close();
            throw new Exception("An error occurred while executing the insert Template", ex);


        }
    }
    public String GetBatchID()
    {

        try
        {
            Int32 iBatchId = 0;
            String sSql = "";
            sSql = "SELECT [LAST_BATCH_ID] FROM [LAST_IMPORT_BATCH]";

            OleDbDataReader sqlRead = OleDbHelper.ExecuteReader(objCommon.ConnectionString, CommandType.Text, sSql);
            if (sqlRead.Read())
                iBatchId = Convert.ToInt32(sqlRead[0].ToString());
            else
                iBatchId = 1;
            sqlRead.Close();

            sSql = "UPDATE [LAST_IMPORT_BATCH] SET [LAST_BATCH_ID] = " + (iBatchId + 1);
            OleDbHelper.ExecuteNonQuery(objCommon.ConnectionString, CommandType.Text, sSql);
            return iBatchId.ToString();
        }
        catch (System.Exception exp)
        {
            SW = File.AppendText(HttpContext.Current.Server.MapPath("HutchRoTN_ImportFiles\\ErrorLog.txt"));
            SW.WriteLine("Time : " + System.DateTime.Now);
            SW.WriteLine("Error Occured :" + exp.Message);
            SW.Close();
            throw new Exception("An error occurred :", exp);
        }
        finally
        {
            //Some action
        }
     }
        public void ImportExcel()
        {
            String strConn;
            String strFile = HttpContext.Current.Server.MapPath("~\\ImportFiles\\" + BatchId + ".xls");
            strConn = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + strFile + @";Extended Properties=""Excel 8.0;IMEX=1""";
            OleDbConnection conn = new OleDbConnection(strConn);
            conn.Open();
            string sql = "select * from [186$]";
            OleDbDataReader sqlRead = OleDbHelper.ExecuteReader(conn, CommandType.Text, sql);
            conn.Close();

        }
    public void DeleteTemplate()
    {
         OleDbConnection sqlConn = new OleDbConnection(objCommon.ConnectionString);
        sqlConn.Open();
      
        string strsql = "";
        string sql = "";
        OleDbTransaction sqlTrans = sqlConn.BeginTransaction();

        try
        {
            strsql = "delete from import_data_master where template_id=? and activity_id=? and product_id=?";
            OleDbParameter[] paramImport1 = new OleDbParameter[3];
            paramImport1[0] = new OleDbParameter("@templateId", OleDbType.VarChar, 15);
            paramImport1[0].Value = strTemplateID;

            paramImport1[1] = new OleDbParameter("@ActivityId", OleDbType.VarChar, 15);
            paramImport1[1].Value = strActivityID;

            paramImport1[2] = new OleDbParameter("@product_id", OleDbType.VarChar, 15);
            paramImport1[2].Value = strProductID;
            OleDbHelper.ExecuteNonQuery(sqlTrans, CommandType.Text, strsql, paramImport1);
            sqlTrans.Commit();
            sqlConn.Close();
        }
        catch (Exception ex)
        {
            sqlTrans.Rollback();
            sqlConn.Close();
            throw new Exception("An error occurred while executing the update Template", ex);
        }
    }
    public void DeleteTemplateAndVerificatio()
    {
        OleDbConnection sqlConn = new OleDbConnection(objCommon.ConnectionString);
        sqlConn.Open();

        string strsql = "";
        string sSql = "";
        string sql = "";
        OleDbTransaction sqlTrans = sqlConn.BeginTransaction();

        try
        {
            strsql = "delete from import_data_master where template_id=?";
            OleDbParameter[] paramImport1 = new OleDbParameter[1];
            paramImport1[0] = new OleDbParameter("@templateId", OleDbType.VarChar, 15);
            paramImport1[0].Value = strTemplateID;

            OleDbHelper.ExecuteNonQuery(sqlTrans, CommandType.Text, strsql, paramImport1);
            sSql = "delete from IMPORT_VERIFICATION_MASTER where template_id=?";
            OleDbParameter[] paramImport2 = new OleDbParameter[1];
            paramImport2[0] = new OleDbParameter("@templateId", OleDbType.VarChar, 15);
            paramImport2[0].Value = strTemplateID;
            OleDbHelper.ExecuteNonQuery(sqlTrans, CommandType.Text, strsql, paramImport2);
            sql = "delete from IMPORT_VERIFICATION_STRING where template_id=?";
            OleDbParameter[] paramImport3 = new OleDbParameter[1];
            paramImport3[0] = new OleDbParameter("@templateId", OleDbType.VarChar, 15);
            paramImport3[0].Value = strTemplateID;
            OleDbHelper.ExecuteNonQuery(sqlTrans, CommandType.Text, strsql, paramImport3);
            sqlTrans.Commit();
            sqlConn.Close();
        }
        catch (Exception ex)
        {
            sqlTrans.Rollback();
            sqlConn.Close();
            throw new Exception("An error occurred while executing the Delete Template", ex);
        }
 
    }
    public void updateTemplate()
    {
       OleDbConnection sqlConn = new OleDbConnection(objCommon.ConnectionString);
        sqlConn.Open();
      
    
        string sql = "";
        OleDbTransaction sqlTrans = sqlConn.BeginTransaction();

        try
        {
          

            sql = "insert into import_data_master (template_id,template_name,activity_id,product_id,client_id,data_table,data_field,template_head,data_type,seqence,is_master)values(?,?,?,?,?,?,?,?,?,?,?)";
            OleDbParameter[] paramImport = new OleDbParameter[11];
            paramImport[0] = new OleDbParameter("@templateId", OleDbType.VarChar, 15);
            paramImport[0].Value = strTemplateID;

            paramImport[1] = new OleDbParameter("@templateName", OleDbType.VarChar, 10);
            paramImport[1].Value = strTemplateName;


            paramImport[2] = new OleDbParameter("@ActivityId", OleDbType.VarChar, 15);
            paramImport[2].Value = strActivityID;

            paramImport[3] = new OleDbParameter("@product_id", OleDbType.VarChar, 15);
            paramImport[3].Value = strProductID;

            paramImport[4] = new OleDbParameter("@clientID", OleDbType.VarChar, 15);
            paramImport[4].Value = strClintID;

            paramImport[5] = new OleDbParameter("@datatable", OleDbType.VarChar, 50);
            paramImport[5].Value = strDataTable;

            paramImport[6] = new OleDbParameter("@datafield", OleDbType.VarChar, 50);
            paramImport[6].Value = strDataField;

            paramImport[7] = new OleDbParameter("@template", OleDbType.VarChar, 255);
            paramImport[7].Value = strTemplateHead;

            paramImport[8] = new OleDbParameter("@datatype", OleDbType.VarChar, 50);
            paramImport[8].Value = "varchar";

            paramImport[9] = new OleDbParameter("@sequence", OleDbType.VarChar, 8);
            paramImport[9].Value = strSequence;

            paramImport[10] = new OleDbParameter("@ismaster", OleDbType.VarChar, 1);
            paramImport[10].Value = "0";

            OleDbHelper.ExecuteNonQuery(sqlTrans, CommandType.Text, sql, paramImport);
            sqlTrans.Commit();
            sqlConn.Close();

        }
        catch (Exception ex)
        {
            sqlTrans.Rollback();
            sqlConn.Close();
            throw new Exception("An error occurred while executing the update Template", ex);
        }
    }
}
