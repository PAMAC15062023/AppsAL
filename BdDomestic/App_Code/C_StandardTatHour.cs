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
/// Summary description for C_StandardTatHour
/// </summary>
public class C_StandardTatHour
{
    CCommon objconn = new CCommon();
	public C_StandardTatHour()
	{
		//
		// TODO: Add constructor logic here
		//
    }
#region Property Decalaration
private string client;
private string product;
private string hathrs1;
private string hathrs2;
private string hathrs3;
private string activityId;
private string templateId;
private string standardTatHour;

    public string StandardTatHour
    {
        get { return standardTatHour; }
        set { standardTatHour = value; }
    }


  public string ActivityId
    {
        get{return activityId;}
        set { activityId = value; }
    }

    
    
    public string TemplateId
    {
        get { return templateId; }
        set { templateId = value; }
    }

    
    
    public string Client
{
  get { return client; }
  set { client = value; }
}


    
    public string Product
{
    get { return product; }
    set { product = value; }
}



    public string Hathrs1
{
    get { return hathrs1; }
    set { hathrs1 = value; }
}
    public string Hathrs2
{
    get { return hathrs2; }
    set { hathrs2 = value; }
}

    public string Hathrs3
{
    get { return hathrs3; }
    set { hathrs3 = value; }
}
#endregion Property Decalaration
public void InsertTatHours()
    {
       
        string strPrefix = "101";
        string TAT_ID = "";
      
        OleDbConnection conn = new OleDbConnection(objconn.ConnectionString);
        conn.Open();
        OleDbTransaction oledbTrans = conn.BeginTransaction();
        string sql = "";
        try
        {
            OleDbParameter[] param = new OleDbParameter[7];               
                
                        TAT_ID = objconn.GetUniqueID("STANDARD_TAT_HOURS", strPrefix).ToString();                      
                        sql = "INSERT INTO STANDARD_TAT_HOURS (STANDARD_TAT_ID,ACTIVITY_ID,CLIENT_ID,PRODUCT_ID,"
                        + "STD_HRS1,STD_HRS2,STD_HRS3)"
                        + " values (?,?,?,?,?,?,?)";
                        param[0] = new OleDbParameter("@STANDARD_TAT_ID", OleDbType.VarChar, 15);
                        param[0].Value = TAT_ID;
                        param[1] = new OleDbParameter("@ACTIVITY_ID", OleDbType.VarChar, 15);
                        param[1].Value = ActivityId;
                        param[2] = new OleDbParameter("@CLIENT_ID", OleDbType.VarChar, 15);
                        param[2].Value = Client;
                        param[3] = new OleDbParameter("@PRODUCT_ID", OleDbType.VarChar, 15);
                        param[3].Value = Product;
                        param[4] = new OleDbParameter("@STD_HRS1", OleDbType.VarChar, 9);
                        param[4].Value = Hathrs1;
                        param[5] = new OleDbParameter("@STD_HRS2", OleDbType.VarChar, 9);
                        param[5].Value = Hathrs2;
                        param[6] = new OleDbParameter("@STD_HRS3", OleDbType.VarChar, 9);
                        param[6].Value = Hathrs3;
                        OleDbHelper.ExecuteNonQuery(oledbTrans, CommandType.Text, sql, param);
                        oledbTrans.Commit();
                        conn.Close();      
                
       }
       catch (Exception ex)
       {
           oledbTrans.Rollback();
           conn.Close();
           throw new Exception("Error while Submiting " + ex.Message);
       }
    }
public DataSet fill_product()
    {
        string Query1 = "";
        Query1 = "select distinct Product_Name,Product_ID from ce_ac_pr_ct_vw where Activity_ID='" + ActivityId + "'";
        return OleDbHelper.ExecuteDataset(objconn.ConnectionString, CommandType.Text, Query1);
          
    }
public DataSet fill_client()
    {
        string Query1 = "";
        Query1 = "select distinct client_Name,client_ID from ce_ac_pr_ct_vw where Product_ID='" + Product + "'";
        return OleDbHelper.ExecuteDataset(objconn.ConnectionString, CommandType.Text, Query1);
       
    }
public DataTable Show_TatHour()
    {
        DataTable d_table = new DataTable();
        DataSet ds = new DataSet();
        DataRow dr;
        OleDbDataAdapter da = new OleDbDataAdapter();
        OleDbConnection conn = new OleDbConnection(objconn.ConnectionString);
        d_table.Columns.Add("STANDARD_TAT_ID");       
        d_table.Columns.Add("activity_name");       
        d_table.Columns.Add("product_name");
        d_table.Columns.Add("client_name");
        d_table.Columns.Add("STD_HRS1");
        d_table.Columns.Add("STD_HRS2");
        d_table.Columns.Add("STD_HRS3");
        try
        {
            string strSql = "";
            //Code commented by Manoj to avoid the display of duplicate entry
            // strSql = "select sth.STANDARD_TAT_ID,capc.activity_id, capc.activity_name, capc.product_id, capc.product_name, capc.client_id, capc.client_name,sth.STD_HRS1,sth.STD_HRS2,sth.STD_HRS3 from ce_ac_pr_ct_vw as capc inner join STANDARD_TAT_HOURS as sth on capc.activity_id=sth.activity_id and capc.product_id=sth.product_id and capc.client_id=sth.client_id ";

            strSql = "select distinct sth.STANDARD_TAT_ID,capc.activity_id, capc.activity_name, capc.product_id, capc.product_name, capc.client_id, capc.client_name,sth.STD_HRS1,sth.STD_HRS2,sth.STD_HRS3 from ce_ac_pr_ct_vw as capc inner join STANDARD_TAT_HOURS as sth on capc.activity_id=sth.activity_id and capc.product_id=sth.product_id and capc.client_id=sth.client_id ";
           

            da = new OleDbDataAdapter(strSql, conn);
            da.Fill(ds, "TAT");
            if (ds.Tables["TAT"].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables["TAT"].Rows.Count; i++)
                {
                    dr = d_table.NewRow();

                    dr[0] = ds.Tables["TAT"].Rows[i]["STANDARD_TAT_ID"];
                    dr[1] = ds.Tables["TAT"].Rows[i]["activity_name"];
                    dr[2] = ds.Tables["TAT"].Rows[i]["product_name"];
                    dr[3] = ds.Tables["TAT"].Rows[i]["client_name"];
                    dr[4] = ds.Tables["TAT"].Rows[i]["STD_HRS1"].ToString().Replace(".", ":");
                    dr[5] = ds.Tables["TAT"].Rows[i]["STD_HRS2"].ToString().Replace(".", ":");
                    dr[6] = ds.Tables["TAT"].Rows[i]["STD_HRS3"].ToString().Replace(".", ":");
                    d_table.Rows.Add(dr);
                }

            }

            return d_table;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
     }
public void UpdateTatHour(string strTat_ID)
 
    {
        OleDbConnection conn = new OleDbConnection(objconn.ConnectionString);
        conn.Open();
        OleDbTransaction oledbTrans = conn.BeginTransaction();
        string sql = "";
        OleDbParameter[] param = new OleDbParameter[7];
        try
        {
            sql = "Update STANDARD_TAT_HOURS set STD_HRS1=? , STD_HRS2=? , STD_HRS3=?, CLIENT_ID=? , PRODUCT_ID=? , ACTIVITY_ID=? Where STANDARD_TAT_ID=? ";
            //sql = "Update STANDARD_TAT_HOURS set STD_HRS1=? , STD_HRS2=? , STD_HRS3=? Where STANDARD_TAT_ID=? ";
            param[0] = new OleDbParameter("@STD_HRS1", OleDbType.VarChar, 9);
            param[0].Value = Hathrs1;
            param[1] = new OleDbParameter("@STD_HRS2", OleDbType.VarChar, 9);
            param[1].Value = Hathrs2;
            param[2] = new OleDbParameter("@STD_HRS3", OleDbType.VarChar, 9);
            param[2].Value = Hathrs3;
            param[3] = new OleDbParameter("@CLIENT_ID", OleDbType.VarChar, 15);
            param[3].Value = Client;
            param[4] = new OleDbParameter("@PRODUCT_ID", OleDbType.VarChar, 15);
            param[4].Value = Product;
            param[5] = new OleDbParameter("@ACTIVITY_ID", OleDbType.VarChar, 15);
            param[5].Value = ActivityId;
            param[6] = new OleDbParameter("@STANDARD_TAT_ID", OleDbType.VarChar, 15);
            param[6].Value = strTat_ID;
            OleDbHelper.ExecuteNonQuery(oledbTrans, CommandType.Text, sql, param);
            oledbTrans.Commit();
            conn.Close();
        }
        catch (Exception ex)
        {
            oledbTrans.Rollback();
            conn.Close();
            throw new Exception("Error while Submiting " + ex.Message);
        }
          
    }
public OleDbDataReader GetRecords(string standardTatId)
    {
        string sSql = "";
        sSql = "select * from STANDARD_TAT_HOURS where STANDARD_TAT_ID='" + standardTatId + "'";
        return OleDbHelper.ExecuteReader(objconn.ConnectionString, CommandType.Text, sSql);
    }
public Boolean getDuplicateValue(String strTat_ID)
    {
        OleDbConnection sqlConn = new OleDbConnection(objconn.ConnectionString);
        sqlConn.Open();
        Boolean blnResult = false;        
        string strSQL = "";
        strSQL = "Select * from STANDARD_TAT_HOURS " +
                            "where ACTIVITY_ID='" + ActivityId + "'" +
                             " AND PRODUCT_ID='" + Product + "'" +
                            " AND CLIENT_ID='" + Client + "'";

        if (strTat_ID != "")
        {
            strSQL = strSQL + " AND [STANDARD_TAT_ID]<> '" + strTat_ID + "'";
        }
        OleDbDataReader objOLEDBHelper = OleDbHelper.ExecuteReader(sqlConn, CommandType.Text, strSQL);
        if (objOLEDBHelper.Read())
        {
            blnResult = true;
        }
        objOLEDBHelper.Close();
        sqlConn.Close();
        return blnResult;
    }
}
