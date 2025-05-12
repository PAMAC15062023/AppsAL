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
using System.Collections;

/// <summary>
/// Summary description for CCEL_Export
/// </summary>
public class CCEL_Export
{
	public CCEL_Export()
	{
		 oCmn = new CCommon();
	}
    private CCommon oCmn;
	
    private string strTemplateId;
    private string strTemplateName;
    private string strCaseTypeId;
    private string strTemplateFields;
    private string strFromDate;
    private string strToDate;
    private string strTemplateDtlId;
    private string strClientID;

    #region Property Declaration
    public string TemplateDetailId
    {
        get { return strTemplateDtlId; }
        set { strTemplateDtlId = value; }
    }
    public string TemplateFields
    {
        get { return strTemplateFields; }
        set { strTemplateFields = value; }
    }
   
    public string TemplateId
    {
        get { return strTemplateId; }
        set { strTemplateId = value; }
    }

    public string TemplateName
    {
        get { return strTemplateName; }
        set { strTemplateName = value; }
    }
    public string ClientID
    {
        get { return strClientID; }
        set { strClientID = value; }
    }

    public string CaseTypeId
    {
        get { return strCaseTypeId; }
        set { strCaseTypeId = value; }
    }

    public string FromDate
    {
        get { return strFromDate; }
        set
        {
            if (value != "")
                strFromDate = value;
            else
                strFromDate = null;
        }
    }
    public string ToDate
    {
        get { return strToDate; }
        set
        {
            if (value != "")
                strToDate = value;
            else
                strToDate = null;
        }
    }
    #endregion Property Declaration

    public OleDbDataReader GetTemplateMasterDtl(string sTempId)
    {
        string sSql = "";
        sSql = "Select * from CPV_CELLULAR_EXPORT_TEMPLATE where Template_Id='" + sTempId + "'";
        return OleDbHelper.ExecuteReader(oCmn.ConnectionString, CommandType.Text, sSql);
    }

    public OleDbDataReader GetTemplateDtl(string sTempId)
    {
        string sSql = "";
        sSql = "Select * from CPV_CELLULAR_EXPORT_DETAILS where Template_Id='" + sTempId + "' Order by SR_NO";
        return OleDbHelper.ExecuteReader(oCmn.ConnectionString, CommandType.Text, sSql);
    }

    public OleDbDataReader GetExportTemplate(string sCaseTypeId)
    {
        string sSql = "";
        sSql = "Select template_id from CPV_CELLULAR_EXPORT_TEMPLATE where CASE_TYPE_ID='" + sCaseTypeId + "'";
        return OleDbHelper.ExecuteReader(oCmn.ConnectionString, CommandType.Text, sSql);
    }

    private void GetImportDetails(string sCentreId,string sClientId,string sProductId)
    {
        string sSql = "";
        sSql = "SELECT DATA_FIELD,TEMPLATE_HEAD FROM IMPORT_DATA_MASTER " +
               " WHERE CLIENT_ID='" + sClientId + "' AND PRODUCT_ID='" + sProductId + "' " +
               " AND CENTRE_ID='" + sCentreId + "' order by Sr_NO";
        
    }

    public  DataSet GetExportFields()
    {
        string sSql = "";
        sSql = "select name from syscolumns WHERE id =(select id from sysobjects where name='CPV_CEL_CASE_EXPORT_VW') order by name";
        return OleDbHelper.ExecuteDataset(oCmn.ConnectionString, CommandType.Text, sSql);
    }

    public Int32 InsertExportTemplate(ArrayList arrTemplateField, ArrayList arrsrno)
    {
        OleDbConnection oledbConn = new OleDbConnection(oCmn.ConnectionString);
        oledbConn.Open();
        OleDbTransaction oledbTrans = oledbConn.BeginTransaction();
        Int32 retVal = 0;
        //OleDbDataReader oledbRead = GetCaseStatusDtl(CaseID);
        try
        {
            string strPrefix = "101";
            TemplateId = oCmn.GetUniqueID("CPV_CELLULAR_EXPORT_TEMPLATE", strPrefix).ToString(); 
            string sSql = "";
            sSql = "Insert into CPV_CELLULAR_EXPORT_TEMPLATE(TEMPLATE_ID,TEMPLATE_NAME,CASE_TYPE_ID)" +
                         "Values(?,?,?)";

            OleDbParameter[] paramTemplate = new OleDbParameter[3];
            paramTemplate[0] = new OleDbParameter("@TemplateId", OleDbType.VarChar,15);
            paramTemplate[0].Value = TemplateId;
            paramTemplate[1] = new OleDbParameter("@TemplateName", OleDbType.VarChar,30);
            paramTemplate[1].Value = TemplateName;
            paramTemplate[2] = new OleDbParameter("@CaseTypeId", OleDbType.VarChar, 15);
            paramTemplate[2].Value = CaseTypeId;

            if (arrTemplateField.Count > 0)
                OleDbHelper.ExecuteNonQuery(oledbTrans, CommandType.Text, sSql, paramTemplate);
            else
                retVal = OleDbHelper.ExecuteNonQuery(oledbTrans, CommandType.Text, sSql, paramTemplate);
            if (arrTemplateField.Count > 0)
            {

                for (int i = 0; i < arrTemplateField.Count; i++)
                {

                    TemplateDetailId = oCmn.GetUniqueID("CPV_CELLULAR_EXPORT_DETAILS", strPrefix).ToString();
                   
                    sSql = "Insert into CPV_CELLULAR_EXPORT_DETAILS(TEMPLATE_DETAIL_ID,TEMPLATE_ID,FIELD_NAME,SR_NO)" +
                             "Values(?,?,?,?)";

                    OleDbParameter[] paramTemplateDtl = new OleDbParameter[4];
                    paramTemplateDtl[0] = new OleDbParameter("@TemplateDetailId", OleDbType.VarChar, 15);
                    paramTemplateDtl[0].Value = TemplateDetailId;
                    paramTemplateDtl[1] = new OleDbParameter("@TemplateId", OleDbType.VarChar, 15);
                    paramTemplateDtl[1].Value = TemplateId;
                  
                    paramTemplateDtl[2] = new OleDbParameter("@TemplateFields", OleDbType.VarChar, 50);
                    paramTemplateDtl[2].Value = arrTemplateField[i].ToString(); ;
                    paramTemplateDtl[3] = new OleDbParameter("@SRNO", OleDbType.Integer, 4);
                    paramTemplateDtl[3].Value = arrsrno[i].ToString();

                    retVal = OleDbHelper.ExecuteNonQuery(oledbTrans, CommandType.Text, sSql, paramTemplateDtl);
                }
            }
            oledbTrans.Commit();
            oledbConn.Close();

            return retVal;
        }
        catch (Exception ex)
        {

            oledbTrans.Rollback();
            oledbConn.Close();
            throw new Exception("An error occurred while executing the InsertExportTemplate()"+ ex.Message);
        }
    }

    public Int32 UpdateExportTemplate(ArrayList arrTemplateField, ArrayList arrsrno)
    {
        OleDbConnection oledbConn = new OleDbConnection(oCmn.ConnectionString);
        oledbConn.Open();
        OleDbTransaction oledbTrans = oledbConn.BeginTransaction();
        Int32 retVal = 0;
        //OleDbDataReader oledbRead = GetCaseStatusDtl(CaseID);
        try
        {            
            string sSql = "";
            sSql = "UPDATE CPV_CELLULAR_EXPORT_TEMPLATE SET TEMPLATE_NAME = ?, " +
                    "CASE_TYPE_ID=? WHERE TEMPLATE_ID=?";
                         

            OleDbParameter[] paramTemplate = new OleDbParameter[3];

            paramTemplate[0] = new OleDbParameter("@TemplateName", OleDbType.VarChar, 30);
            paramTemplate[0].Value = TemplateName;
            paramTemplate[1] = new OleDbParameter("@CaseTypeId", OleDbType.VarChar, 15);
            paramTemplate[1].Value =  CaseTypeId;
            paramTemplate[2] = new OleDbParameter("@TemplateId", OleDbType.VarChar, 15);
            paramTemplate[2].Value = TemplateId;

            if (arrTemplateField.Count > 0)
                OleDbHelper.ExecuteNonQuery(oledbTrans, CommandType.Text, sSql, paramTemplate);
            else
                retVal = OleDbHelper.ExecuteNonQuery(oledbTrans, CommandType.Text, sSql, paramTemplate);

            sSql = "DELETE FROM CPV_CELLULAR_EXPORT_DETAILS WHERE TEMPLATE_ID='" + TemplateId + "'";
            OleDbHelper.ExecuteNonQuery(oledbTrans, CommandType.Text, sSql);
            string strPrefix = "101";
            if (arrTemplateField.Count > 0)
            {
                TemplateDetailId = oCmn.GetUniqueID("CPV_CELLULAR_EXPORT_DETAILS", strPrefix).ToString();
                for (int i = 0; i < arrTemplateField.Count; i++)
                {
                    
                    sSql = "Insert into CPV_CELLULAR_EXPORT_DETAILS(TEMPLATE_DETAIL_ID,TEMPLATE_ID,FIELD_NAME,SR_NO)" +
                             "Values(?,?,?,?)";

                    OleDbParameter[] paramTemplateDtl = new OleDbParameter[4];
                    paramTemplateDtl[0] = new OleDbParameter("@TemplateDetailId", OleDbType.VarChar, 15);
                    paramTemplateDtl[0].Value = TemplateDetailId;
                    paramTemplateDtl[1] = new OleDbParameter("@TemplateId", OleDbType.VarChar, 15);
                    paramTemplateDtl[1].Value = TemplateId;
                    paramTemplateDtl[2] = new OleDbParameter("@TemplateFields", OleDbType.VarChar, 50);
                    paramTemplateDtl[2].Value = arrTemplateField[i].ToString();
                    paramTemplateDtl[3] = new OleDbParameter("@SRNO", OleDbType.Integer, 4);
                    paramTemplateDtl[3].Value = arrsrno[i].ToString();

                    retVal = OleDbHelper.ExecuteNonQuery(oledbTrans, CommandType.Text, sSql, paramTemplateDtl);
                }
            }
            oledbTrans.Commit();
            oledbConn.Close();

            return retVal;
        }
        catch (Exception ex)
        {

            oledbTrans.Rollback();
            oledbConn.Close();
            throw new Exception("An error occurred while executing the InsertExportTemplate()"+ ex.Message);
        }
    }

    public Int32 DeleteExportTemplate()
    {
        OleDbConnection oledbConn = new OleDbConnection(oCmn.ConnectionString);
        oledbConn.Open();
        OleDbTransaction oledbTrans = oledbConn.BeginTransaction();
        Int32 retVal = 0;
        //OleDbDataReader oledbRead = GetCaseStatusDtl(CaseID);
        try
        {
            string sSql = "";
            sSql = "DELETE FROM CPV_CELLULAR_EXPORT_TEMPLATE WHERE TEMPLATE_ID=" + TemplateId;
            OleDbHelper.ExecuteNonQuery(oledbTrans, CommandType.Text, sSql);

            sSql = "DELETE FROM CPV_CELLULAR_EXPORT_DETAILS WHERE TEMPLATE_ID=" + TemplateId;
            retVal = OleDbHelper.ExecuteNonQuery(oledbTrans, CommandType.Text, sSql);
            
            oledbTrans.Commit();
            oledbConn.Close();

            return retVal;
        }
        catch (Exception ex)
        {

            oledbTrans.Rollback();
            oledbConn.Close();
            throw new Exception("An error occurred while executing the InsertExportTemplate()" + ex.Message);
        }
    }

    public OleDbDataReader GetCellularExportFields(string sCaseType)
    {
        string sSql = "";
        sSql = "SELECT CELTD.FIELD_NAME FROM CPV_CELLULAR_CASES CELC " +
             " INNER JOIN CPV_CELLULAR_EXPORT_TEMPLATE CELT ON CELT.CASE_TYPE_ID=CELC.CASE_TYPE_ID " +
             " INNER JOIN CPV_CELLULAR_EXPORT_DETAILS CELTD ON CELT.TEMPLATE_ID=CELTD.TEMPLATE_ID " +
             " WHERE CELC.CASE_TYPE_ID='" + sCaseType + "' Order By CELTD.Sr_No ";

        return OleDbHelper.ExecuteReader(oCmn.ConnectionString, CommandType.Text, sSql);
    }

    public DataSet GetCellularExport(ArrayList arrFields, string sFromDate, string sToDate,string basedOn)
    {
        string sSql = "";
        string sFields = "";
        string sTempFields = "";
        DataSet ds = new DataSet();

        if (arrFields.Count > 0)
        {
            sSql = "SELECT ";
            foreach (string item in arrFields)
            {
                if (item == "SEND_DATETIME")
                {
                    sTempFields += "CONVERT(VARCHAR(24), " + item + " , 103) AS SEND_DATETIME" + ",";
                }
                else if (item == "CASE_REC_DATETIME")
                {
                    sTempFields += "CONVERT(VARCHAR(24), " + item + " , 103) AS CASE_REC_DATETIME" + ",";
                }
                else
                {
                    sTempFields += "[" + item + "]" + ",";
                }
            }
            if (basedOn == "Received Date")
            {
                sFields = sTempFields.TrimEnd(',');
                sSql += sFields;
                sSql += " FROM CPV_CEL_CASE_EXPORT_VW " +
                         " WHERE " +
                         " CASE_REC_DATETIME >='" + sFromDate + "'" +
                         " AND CASE_REC_DATETIME <'" + sToDate + "'";

            }
            else
            {

                sFields = sTempFields.TrimEnd(',');
                sSql += sFields;
                sSql += " FROM CPV_CEL_CASE_EXPORT_VW " +
                         " WHERE SEND_DATETIME IS NOT NULL " +
                         " AND SEND_DATETIME >='" + sFromDate + "'" +
                         " AND SEND_DATETIME <'" + sToDate + "'";
            }

            ds =OleDbHelper.ExecuteDataset(oCmn.ConnectionString, CommandType.Text, sSql);
        }
        return ds;
    }
    public DataSet GetExportFields(string strTemplateID)
    {
        string sSql = "";
        sSql = "Select FIELD_NAME from CPV_CELLULAR_EXPORT_DETAILS where Template_Id='" + strTemplateID + "' Order by SR_NO";
        return OleDbHelper.ExecuteDataset(oCmn.ConnectionString, CommandType.Text, sSql);
    }

    public DataSet GetCellularExportData(string strFields, string strCaseTypeID, string strDateField, string strFromDate, string strToDate)
    {
        string sSql = "";
        sSql = "Select " + strFields + " from CPV_CEL_CASE_EXPORT_VW where Case_Type_ID='" + strCaseTypeID + "' AND convert(varchar(24)," + strDateField + ", 103)  >='" + strFromDate + "'" +
                         " AND convert(varchar(24), " + strDateField + " , 103)<='" + strToDate + "'" + " AND CLUSTER_ID='" + HttpContext.Current.Session["ClusterId"]  + "'" +
                         " AND CENTRE_ID='" + HttpContext.Current.Session["CentreId"] + "'" + " AND CLIENT_ID='" + HttpContext.Current.Session["ClientId"] + "'" + " Order by SR_NO";
        return OleDbHelper.ExecuteDataset(oCmn.ConnectionString, CommandType.Text, sSql);
    }
}
