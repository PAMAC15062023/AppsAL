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
/// Summary description for CCreditCardGenerateLabel
/// </summary>
public class CCreditCardGenerateLabel
{
    CCommon oCom = new CCommon();
    private string strActivity_ID;
    private string strProduct_ID;
    private string strVerification_Type_ID;
    private string strClient_ID;
    private string strfromdate;
    private string strtodate;
    private string strverification_Type;
    private string strcentre_id;




    public string Centre_Id
    {
        get { return strcentre_id; }
        set { strcentre_id = value; }
    }
    public string Fromdate
    {
        get { return strfromdate; }
        set { strfromdate = value; }
    }

    public string Todate
    {
        get { return strtodate; }
        set { strtodate = value; }
    }

    public string Verification_Type
    {
        get { return strverification_Type; }
        set { strverification_Type = value; }
    }

    public string Activity_ID
    {
        get { return strActivity_ID; }
        set { strActivity_ID = value; }
    }

    public string Product_ID
    {
        get { return strProduct_ID; }
        set { strProduct_ID = value; }
    }

    public string Verification_Type_ID
    {
        get { return strVerification_Type_ID; }
        set { strVerification_Type_ID = value; }
    }

    public string Client_ID
    {
        get { return strClient_ID; }
        set { strClient_ID = value; }
    }

	public CCreditCardGenerateLabel()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public DataSet getTemplate()
    {
        
        string strSQL = " SELECT VTM.VERIFICATION_TYPE_CODE, LPTM.ADDITIONAL1, LPTM.ADDITIONAL2, LPTM.SR_NO,";
        strSQL = strSQL + " LPTM.LABEL_PRINTING_DATE, LPTM.ALL_VERIFICATION_TYPE,LPTD.TABLE_NAME, ";
        strSQL = strSQL + " LPTD.SELECTED_FIELD, LPTD.SERIAL_NO, LPTD.LINE_NO";
        strSQL = strSQL + " FROM LABEL_PRINTING_TEMPLATE_MASTER LPTM ";
        strSQL = strSQL + " INNER JOIN LABEL_PRINTING_TEMPLATE_DETAILS LPTD ";
        strSQL = strSQL + " ON (LPTM.LABEL_TEMPLATE_ID=LPTD.LABEL_TEMPLATE_ID)";
        strSQL = strSQL + " INNER JOIN VERIFICATION_TYPE_MASTER VTM";
        strSQL = strSQL + " ON (LPTM.VERIFICATION_TYPE_ID=VTM.VERIFICATION_TYPE_ID)";
        strSQL = strSQL + " WHERE LPTM.CLIENT_ID='"+ strClient_ID +"' AND LPTM.ACTIVITY_ID='"+strActivity_ID+"'";
        strSQL = strSQL + " AND LPTM.PRODUCT_ID='" +strProduct_ID+"'";
        strSQL = strSQL + " AND LPTM.VERIFICATION_TYPE_ID='"+strVerification_Type_ID+"'";
        strSQL = strSQL + " ORDER BY LPTD.SERIAL_NO ";
        return OleDbHelper.ExecuteDataset(oCom.ConnectionString, CommandType.Text, strSQL);

    }

    public DataSet getLabel(string strSQL)
    {
            
        return OleDbHelper.ExecuteDataset(oCom.ConnectionString, CommandType.Text, strSQL);

    }
    public DataSet getGridValue(string CentreId, string strClient_ID)
    {

        string strSQL = " select SR_NO,REF_NO,FULL_NAME FROM CPV_CC_CASE_DETAILS   WHERE case_rec_datetime >= '" + strfromdate + "' AND case_rec_datetime < = '" + strtodate + "' ";

        return OleDbHelper.ExecuteDataset(oCom.ConnectionString, CommandType.Text, strSQL);

    }
    public DataSet GetVerificationType(string activityid)
    {
       

        string strSQL = " select VERIFICATION_TYPE_CODE,VERIFICATION_TYPE_ID FROM verification_type_master   WHERE  ACTIVITY_ID= '" + activityid + "'";

        return OleDbHelper.ExecuteDataset(oCom.ConnectionString, CommandType.Text, strSQL);

    }

}
