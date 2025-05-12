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
/// Summary description for CAdmin_Summary_Panel_Mapping
/// Created By Manoj
/// To Maintaing the panel
/// </summary>
public class CAdmin_Summary_Panel_Mapping
{
    CCommon objComm;
    private string strVerificationType;
    private string strActivityID;
    private string strProductID;
    private string strTemplateName;
    private string strClinetID;
    private string strTemplateID;
    public DataSet dsPanelList;



    //private string str

	public CAdmin_Summary_Panel_Mapping()
	{
		//
		// TODO: Add constructor logic here
		//
        objComm = new CCommon();
        
	}
    public string pptVerificationType
    {
        get { return strVerificationType; }
        set { strVerificationType = value; }
    }

    public string pptActivityID
    {
        get { return strActivityID; }
        set { strActivityID = value; }
    }

    public string pptProductID
    {
        get { return strProductID; }
        set { strProductID = value; }
    }

    public string pptTemplateName
    {
        get { return strTemplateName; }
        set { strTemplateName = value; }
    }

    public string pptClientID
    {
        get { return strClinetID; }
        set { strClinetID = value; }
    }

    public string pptTemplateID
    {
        get { return strTemplateID; }
        set { strTemplateID = value; }
    }

    public Boolean getDuplicateValue(String strTemplate_ID)
    {
        OleDbConnection sqlConn = new OleDbConnection(objComm.ConnectionString);
        sqlConn.Open();
        Boolean blnResult = false;

        string strSQL = "";
        strSQL = " SELECT [ACTIVITY_ID],[PRODUCT_ID],[CLIENT_ID],[VERIFICATION_TYPE_ID] FROM SUMMARY_DETAIL_TEMPLATE_MASTER ";
        strSQL = strSQL + " WHERE [ACTIVITY_ID]='" + pptActivityID + "' AND ";
        strSQL = strSQL + "  [PRODUCT_ID]='" + pptProductID + "' AND ";
        strSQL = strSQL + "  [CLIENT_ID]='" + pptClientID + "' AND ";
        strSQL = strSQL + "  [VERIFICATION_TYPE_ID]='" + pptVerificationType + "'";

        if (strTemplate_ID != "")
        {
            strSQL = strSQL + " AND [TEMPLATE_ID]<>'" + strTemplate_ID + "'";
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

    public int getCountofPanelNo()
    {
        OleDbConnection sqlConn = new OleDbConnection(objComm.ConnectionString);
        sqlConn.Open();

        string strSQL = "";
        strSQL = " SELECT COUNT(*) AS GetCount FROM [SUMMARY_DETAIL_PANEL_MASTER] WHERE [VERIFICATION_TYPE_ID]=?";
       
        OleDbParameter[] paramVerificationType = new OleDbParameter[1];
        paramVerificationType[0] = new OleDbParameter("@pptVerificationType", OleDbType.VarChar);
        paramVerificationType[0].Value = strVerificationType;

        OleDbDataReader objOLEDBHelper = OleDbHelper.ExecuteReader(sqlConn, CommandType.Text, strSQL, paramVerificationType);

        int nCount = 0;

        if (objOLEDBHelper.Read())
        {

            nCount = Convert.ToInt32(objOLEDBHelper["GetCount"].ToString());
        }
       
        objOLEDBHelper.Close();
        sqlConn.Close();

        return nCount;
    }

    public void insertPanel()
    {
        OleDbConnection sqlConn = new OleDbConnection(objComm.ConnectionString);
        sqlConn.Open();

        string strPrefix = "101";
        string strSQL = "";
        string strSQL1 = "";
        //string strTemplateID;

        OleDbTransaction sqlTrans = sqlConn.BeginTransaction();
        try
        {
            pptTemplateID = objComm.GetUniqueID("SUMMARY_DETAIL_TEMPLATE_MASTER", strPrefix).ToString();
            
            strSQL = " INSERT INTO [SUMMARY_DETAIL_TEMPLATE_MASTER]([TEMPLATE_ID], [TEMPLATE_NAME]";
            strSQL = strSQL + ", [CLIENT_ID], [ACTIVITY_ID], [PRODUCT_ID]";
            strSQL = strSQL + ", [VERIFICATION_TYPE_ID]) ";
            strSQL = strSQL + " VALUES(?,?,?,?,?,?)";

            OleDbParameter[] paramPreCont = new OleDbParameter[6];
            paramPreCont[0] = new OleDbParameter("@pptTemplateID", OleDbType.VarChar);
            paramPreCont[0].Value = pptTemplateID;

            paramPreCont[1] = new OleDbParameter("@pptTemplateName", OleDbType.VarChar);
            paramPreCont[1].Value = pptTemplateName;
      
            paramPreCont[2] = new OleDbParameter("@pptClientID", OleDbType.VarChar);
            paramPreCont[2].Value = pptClientID;

            paramPreCont[3] = new OleDbParameter("@pptActivityID", OleDbType.VarChar);
            paramPreCont[3].Value = pptActivityID;

            paramPreCont[4] = new OleDbParameter("@pptProductID", OleDbType.VarChar);
            paramPreCont[4].Value = pptProductID;

            paramPreCont[5] = new OleDbParameter("@pptVerificationType", OleDbType.VarChar);
            paramPreCont[5].Value = pptVerificationType;


            if (dsPanelList != null)
            {
                if (dsPanelList.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < dsPanelList.Tables[0].Rows.Count; i++)
                    {
                        strSQL1 = " INSERT INTO [SUMMARY_PANEL_MAPPING] ([TEMPLATE_ID],[PANEL_ID],[SR_NO])";
                        strSQL1 = strSQL1 + " VALUES(?,?,?)";

                        OleDbParameter[] paramPanelList = new OleDbParameter[3];
                        paramPanelList[0] = new OleDbParameter("@pptTemplateID", OleDbType.VarChar);
                        paramPanelList[0].Value = pptTemplateID;

                        paramPanelList[1] = new OleDbParameter("@pptPANEL_ID", OleDbType.VarChar);
                        paramPanelList[1].Value = dsPanelList.Tables[0].Rows[i].ItemArray[0].ToString();

                        paramPanelList[2] = new OleDbParameter("@pptSR_NO", OleDbType.VarChar);
                        paramPanelList[2].Value = dsPanelList.Tables[0].Rows[i].ItemArray[1].ToString();

                        OleDbHelper.ExecuteNonQuery(sqlTrans, CommandType.Text, strSQL1, paramPanelList);
                    }
                }
               
            }

            OleDbHelper.ExecuteNonQuery(sqlTrans, CommandType.Text, strSQL, paramPreCont);
            sqlTrans.Commit();
            sqlConn.Close();
        }
        catch(Exception exp)
        {
            sqlTrans.Rollback();
            sqlConn.Close();
            throw new Exception("An error occurred ", exp);
        }

    }
    public void getTemplates()
    {
        OleDbConnection sqlConn = new OleDbConnection(objComm.ConnectionString);
        //sqlConn.Open();
        
        string strSQL = "";
        strSQL = " SELECT [ACTIVITY_ID],[PRODUCT_ID],[CLIENT_ID],[TEMPLATE_NAME],[VERIFICATION_TYPE_ID] FROM SUMMARY_DETAIL_TEMPLATE_MASTER WHERE TEMPLATE_ID='" + strTemplateID + "'";

        OleDbDataReader dr;
        dr = OleDbHelper.ExecuteReader(sqlConn, CommandType.Text, strSQL);
        while (dr.Read())
        {
            pptActivityID = dr[0].ToString();
            pptProductID = dr[1].ToString();
            pptClientID = dr[2].ToString();
            pptTemplateName = dr[3].ToString();
            pptVerificationType = dr[4].ToString();
        }
        dr.Close();

        DataSet objDataSet = new DataSet();
        strSQL = "";
        strSQL = strSQL + " SELECT [Panel_ID],[SR_No] FROM SUMMARY_PANEL_MAPPING WHERE [TEMPLATE_ID]='" + strTemplateID + "'";
        objDataSet = OleDbHelper.ExecuteDataset(sqlConn, CommandType.Text, strSQL);
        dsPanelList = objDataSet;
    }

    public void updatePanel()
    {
        OleDbConnection sqlConn = new OleDbConnection(objComm.ConnectionString);
        sqlConn.Open();

        string strSQL2 = "";
        string strSQL = "";
        string strSQL1 = "";
        //string strTemplateID;

        OleDbTransaction sqlTrans = sqlConn.BeginTransaction();
        try
        {
            //pptTemplateID = objComm.GetUniqueID("SUMMARY_DETAIL_TEMPLATE_MASTER", strPrefix).ToString();

            strSQL = " UPDATE [SUMMARY_DETAIL_TEMPLATE_MASTER] SET [TEMPLATE_NAME]='" + pptTemplateName + "'";
            strSQL = strSQL + ", [CLIENT_ID]='" + pptClientID + "'";
            strSQL = strSQL + ", [ACTIVITY_ID]='" + pptActivityID + "'";
            strSQL = strSQL + ", [PRODUCT_ID]='" + pptProductID + "'";
            strSQL = strSQL + ", [VERIFICATION_TYPE_ID]='" + pptVerificationType + "'";
            strSQL = strSQL + " WHERE [TEMPLATE_ID]='" + pptTemplateID + "'";


            strSQL2 = "DELETE FROM [SUMMARY_PANEL_MAPPING] WHERE [TEMPLATE_ID]='" + pptTemplateID + "'";
            OleDbHelper.ExecuteNonQuery(sqlTrans, CommandType.Text, strSQL2);

            if (dsPanelList != null)
            {
                if (dsPanelList.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < dsPanelList.Tables[0].Rows.Count; i++)
                    {
                        strSQL1 = " INSERT INTO [SUMMARY_PANEL_MAPPING] ([TEMPLATE_ID],[PANEL_ID],[SR_NO])";
                        strSQL1 = strSQL1 + " VALUES(?,?,?)";

                        OleDbParameter[] paramPanelList = new OleDbParameter[3];
                        paramPanelList[0] = new OleDbParameter("@pptTemplateID", OleDbType.VarChar);
                        paramPanelList[0].Value = pptTemplateID;

                        paramPanelList[1] = new OleDbParameter("@pptPANEL_ID", OleDbType.VarChar);
                        paramPanelList[1].Value = dsPanelList.Tables[0].Rows[i].ItemArray[0].ToString();

                        paramPanelList[2] = new OleDbParameter("@pptSR_NO", OleDbType.VarChar);
                        paramPanelList[2].Value = dsPanelList.Tables[0].Rows[i].ItemArray[1].ToString();

                        OleDbHelper.ExecuteNonQuery(sqlTrans, CommandType.Text, strSQL1, paramPanelList);
                    }
                }

            }

            OleDbHelper.ExecuteNonQuery(sqlTrans, CommandType.Text, strSQL);
            sqlTrans.Commit();
            sqlConn.Close();
        }
        catch (Exception exp)
        {
            sqlTrans.Rollback();
            sqlConn.Close();
            throw new Exception("An error occurred ", exp);
        }

    }
    public void deleteTemplate()
    {
        OleDbConnection sqlConn = new OleDbConnection(objComm.ConnectionString);
        sqlConn.Open();

        string strSQL = "";
        string strSQL1 = "";

        OleDbTransaction sqlTrans = sqlConn.BeginTransaction();

        try
        {
            strSQL = " DELETE FROM SUMMARY_DETAIL_TEMPLATE_MASTER WHERE [TEMPLATE_ID]='" + pptTemplateID + "'";
            strSQL1 = " DELETE FROM SUMMARY_PANEL_MAPPING WHERE [TEMPLATE_ID]='" + pptTemplateID + "'";
            
            OleDbHelper.ExecuteNonQuery(sqlTrans, CommandType.Text, strSQL);
            OleDbHelper.ExecuteNonQuery(sqlTrans, CommandType.Text, strSQL1);

            sqlTrans.Commit();
            sqlConn.Close();
        }
        catch (Exception exp)
        {
            sqlTrans.Rollback();
            sqlConn.Close();
            throw new Exception("An error occurred ", exp);
        }
    }
}
