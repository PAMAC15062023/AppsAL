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
/// Summary description for CGet
/// </summary>
public class CGet
{
    private CCommon objCommon;
    
#region Constructor
    public CGet()
	{
        objCommon = new CCommon();
    }
#endregion

    #region Get activities by passing the centreid
    public DataSet getActivities(string strCentreID)
    {
        OleDbConnection sqlConn = new OleDbConnection(objCommon.ConnectionString);
        DataSet dsgetActivities = new DataSet();
        string strSQL = "";
        strSQL = "SELECT DISTINCT [ACTIVITY_ID],[ACTIVITY_NAME] FROM [CE_AC_PR_CT_VW] WHERE [CENTRE_ID]='" + HttpContext.Current.Session["CentreId"] + "' AND ACTIVITY_ID IS NOT NULL and ACTIVITY_NAME IS NOT NULL";
        dsgetActivities = OleDbHelper.ExecuteDataset(sqlConn, CommandType.Text, strSQL);
        return dsgetActivities;
    }
    #endregion

    #region Get all activities 
    public DataSet getActivities()
    {
        OleDbConnection sqlConn = new OleDbConnection(objCommon.ConnectionString);
        DataSet dsgetActivities = new DataSet();
        string strSQL = "";

        strSQL = "SELECT DISTINCT [ACTIVITY_ID],[ACTIVITY_NAME] FROM [CE_AC_PR_CT_VW] WHERE [CENTRE_ID]='" + HttpContext.Current.Session["CentreId"] + "' AND ACTIVITY_ID IS NOT NULL and ACTIVITY_NAME IS NOT NULL";
        dsgetActivities = OleDbHelper.ExecuteDataset(sqlConn, CommandType.Text, strSQL);
        return dsgetActivities;
    }
    #endregion

    #region Get Products by passing Activity_id
    public DataSet getProducts(string strActivity)
    {
        OleDbConnection sqlConn = new OleDbConnection(objCommon.ConnectionString);
        DataSet dsGetProduct = new DataSet();
        string strSQL = "";
        strSQL = "SELECT DISTINCT [PRODUCT_ID],[PRODUCT_NAME] FROM [CE_AC_PR_CT_VW] WHERE [ACTIVITY_ID]='" + strActivity + "' AND PRODUCT_ID IS NOT NULL AND PRODUCT_NAME IS NOT NULL";
        dsGetProduct = OleDbHelper.ExecuteDataset(sqlConn, CommandType.Text, strSQL);
        return dsGetProduct;
    }
    #endregion

    #region Get Clients by passing the productid
    public DataSet getClients(string strProductID)
    {
        OleDbConnection sqlConn = new OleDbConnection(objCommon.ConnectionString);
        DataSet dsgetClient = new DataSet();
        string strSQL = "";
        strSQL = "SELECT DISTINCT [CLIENT_ID],[CLIENT_NAME] FROM [CE_AC_PR_CT_VW] WHERE [PRODUCT_ID]='" + strProductID + "' AND CLIENT_ID IS NOT NULL and client_name is not null";
        dsgetClient = OleDbHelper.ExecuteDataset(sqlConn, CommandType.Text, strSQL);
        return dsgetClient;
    }
     #endregion

    #region Get Verification Type by passing the ACtivityID
    public DataSet getVerificationType(string ACtivityID)
    {
        OleDbConnection sqlConn = new OleDbConnection(objCommon.ConnectionString);
        DataSet dsgetClient = new DataSet();
        string strSQL = "";
        
        strSQL = "SELECT DISTINCT [VERIFICATION_TYPE_ID],[VERIFICATION_TYPE_CODE] FROM [VERIFICATION_TYPE_MASTER] WHERE [ACTIVITY_ID]='" + ACtivityID + "'";
        dsgetClient = OleDbHelper.ExecuteDataset(sqlConn, CommandType.Text, strSQL);
        return dsgetClient;
    }

    public DataSet getVerificationTypeForSms(string VerificatinoId)
    {
        OleDbConnection sqlConn = new OleDbConnection(objCommon.ConnectionString);
        DataSet dsgetClient = new DataSet();
        string strSQL = "";

        strSQL = "SELECT DISTINCT [VERIFICATION_TYPE_ID],[VERIFICATION_TYPE_CODE] FROM [VERIFICATION_TYPE_MASTER] WHERE [VERIFICATION_TYPE_ID]='" + VerificatinoId + "'";
        dsgetClient = OleDbHelper.ExecuteDataset(sqlConn, CommandType.Text, strSQL);
        return dsgetClient;
    }
    #endregion

    #region Get Panels
    public DataSet getPanels(string strActivity, string strProduct, string strClientID, string strVerificationType_ID)
    {
        
        OleDbConnection sqlConn = new OleDbConnection(objCommon.ConnectionString);
        DataSet dsgetPanels = new DataSet();
        string strSQL = "";
        strSQL = " SELECT SDPM.PANEL_NAME, SPM.SR_NO FROM SUMMARY_PANEL_MAPPING SPM ";
        strSQL = strSQL + " INNER JOIN SUMMARY_DETAIL_PANEL_MASTER  SDPM ON SPM.PANEL_ID = SDPM.PANEL_ID ";
        strSQL = strSQL + " INNER JOIN SUMMARY_DETAIL_TEMPLATE_MASTER  SDTM ON SPM.TEMPLATE_ID = SDTM.TEMPLATE_ID";
        strSQL = strSQL + " WHERE SDTM.ACTIVITY_ID='"+ strActivity +"' AND SDTM.PRODUCT_ID='"+ strProduct +"'";
        strSQL = strSQL + " AND SDTM.CLIENT_ID='" + strClientID + "'AND SDTM.VERIFICATION_TYPE_ID='" + strVerificationType_ID + "' ORDER BY SR_NO" ;
        dsgetPanels = OleDbHelper.ExecuteDataset(sqlConn, CommandType.Text, strSQL);
        return dsgetPanels;

    }
    public DataSet getPanels_Dcr(string strActivity, string strProduct, string strClientID, string strVerificationType_ID)
    {

        OleDbConnection sqlConn = new OleDbConnection(objCommon.ConnectionString);
        DataSet dsgetPanels = new DataSet();
        string strSQL = "";
        strSQL = " SELECT SDPM.PANEL_NAME, SPM.SR_NO FROM SUMMARY_PANEL_MAPPING SPM ";
        strSQL = strSQL + " INNER JOIN SUMMARY_DETAIL_PANEL_MASTER  SDPM ON SPM.PANEL_ID = SDPM.PANEL_ID ";
        strSQL = strSQL + " AND SDPM.PRODUCT_ID='" + strProduct + "' AND SDPM.VERIFICATION_TYPE_ID='" + strVerificationType_ID + "' ORDER BY SR_NO";
        dsgetPanels = OleDbHelper.ExecuteDataset(sqlConn, CommandType.Text, strSQL);
        return dsgetPanels;

    }
    #endregion
}
