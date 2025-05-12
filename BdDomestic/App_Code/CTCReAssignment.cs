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
using System.Collections;

/// <summary>
/// Summary description for CTCReAssignment
/// </summary>
public class CTCReAssignment
{
    CCommon oCmn;
    String strDate;
    private string strCaseId;
	public CTCReAssignment()
	{
        oCmn = new CCommon();
        strDate = System.DateTime.Now.ToString();
        //
		// TODO: Add constructor logic here
		//
	}
    //TC ASSIGNMENT
    private String strTCID;
    private String strClinetId;
    private String strAssignedTo;
    private String strVerificationType;
    public String[] arrCaseID;

    public string TCID
    {
        get { return strTCID; }
        set { strTCID = value; }
    }
    public string ClinetId
    {
        get { return strClinetId; }
        set { strClinetId = value; }
    }
    private String strEditTCID;
    private String strEditClinetId;
    public string EditTCID
    {
        get { return strEditTCID; }
        set { strEditTCID = value; }
    }
    public string EditClinetId
    {
        get { return strEditClinetId; }
        set { strEditClinetId = value; }
    }
    //FE ASSIGNMENT
    public string AssignedTo
    {
        get { return strAssignedTo; }
        set { strAssignedTo = value; }
    }
    public string VerificationType
    {
        get { return strVerificationType; }
        set { strVerificationType = value; }
    }
    //Check before assignment
    public bool ChkTcAssignment(string strCaseIds)
    {
        string strSql = "SELECT CD.CASE_ID FROM CPV_CC_CASE_DETAILS CD INNER JOIN " +
                        " CPV_CC_CASE_VERIFICATIONTYPE CV ON CD.CASE_ID = CV.CASE_ID " +
                        " where CD.Send_DateTime is null and CD.Case_ID='" + strCaseIds + "' and CV.VERIFICATION_TYPE_ID='" +
                        VerificationType + "'";
        object obj = OleDbHelper.ExecuteScalar(oCmn.ConnectionString, CommandType.Text, strSql);
        if (obj == null)
        {
            return false;
        }
        else
        {
            strClinetId = obj.ToString();
            strSql = "SELECT FEM.CASE_ID FROM CPV_CC_TC_CASE_MAPPING FEM " +
                     "where FEM.Case_ID='" + strCaseIds + "' and FEM.VERIFICATION_TYPE_ID='" +
                     VerificationType + "'";
            obj = OleDbHelper.ExecuteScalar(oCmn.ConnectionString, CommandType.Text, strSql);
            if (obj == null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
    //Overload Check before assignment Ref No.
    public bool ChkTcAssignment(string strCaseIds, string IsRef)
    {
        string strSql = "select Case_Id from CPV_CC_CASE_DETAILS where SEND_DATETIME is null and " +
                        " ref_No='" + strCaseIds + "'";
        object obj = OleDbHelper.ExecuteScalar(oCmn.ConnectionString, CommandType.Text, strSql);
        if (obj != null)
        {
            return ChkTcAssignment(obj.ToString());
        }
        else
        {
            return false;
        }
    }
    public void InsertTcCaseMapping1(string strCaseIds)
    {
    //    OleDbConnection conn = new OleDbConnection(oCmn.ConnectionString);
    //    conn.Open();
    //    OleDbConnection trans = conn.BeginTransaction(); 
    //    try 
    //    {
       
        
    //    }
    //    catch (Exception exp)
    //    {
    //        trans.Rollback();
    //        conn.Close();
    //        throw new Exception("An error occurred ", exp);
       
    //}
 }
        
    
    
    
    public void InsertTcCaseMapping(string strCaseIds)
    {
        OleDbConnection conn = new OleDbConnection(oCmn.ConnectionString);
        conn.Open();
        OleDbTransaction trans = conn.BeginTransaction();
        try
        {
            //String sQuery1 = "DELETE FROM CPV_CC_TC_CASE_MAPPING WHERE VERIFICATION_TYPE_ID='" + VerificationType + "' AND CASE_ID IN (" + strCaseIds + ")";
            //OleDbHelper.ExecuteNonQuery(trans, CommandType.Text, sQuery1);
            //String sQuery = "INSERT INTO CPV_CC_FE_CASE_MAPPING (CASE_ID, FE_ID, VERIFICATION_TYPE_ID, DATE_TIME) VALUES(?, ?, ?, ?)";
            foreach (string sCaseID in arrCaseID)
            {
                String sQuery = "INSERT INTO CPV_CC_TC_CASE_MAPPING (CASE_ID, TC_ID, VERIFICATION_TYPE_ID, DATE_TIME,status) VALUES(" + sCaseID + ", '" + AssignedTo + "', '" + VerificationType + "', '" + strDate + "','R')";
                OleDbHelper.ExecuteNonQuery(trans, CommandType.Text, sQuery);
            }
            trans.Commit();
            conn.Close();
        }
        catch (Exception exp)
        {
            trans.Rollback();
            conn.Close();
            throw new Exception("An error occurred ", exp);
        }
    }
    public void InsertMuTcCaseMapping(string strCaseIds)
    {
        OleDbConnection conn = new OleDbConnection(oCmn.ConnectionString);
        conn.Open();
        OleDbTransaction trans = conn.BeginTransaction();

        string qry, sql = "";
        qry = "select [Datetime] = convert(varchar, getdate(), 25)";
        object aa = OleDbHelper.ExecuteScalar(oCmn.ConnectionString, CommandType.Text, qry);
        //OleDbDataReader dr = new OleDbDataReader 
        //dr = OleDbHelper.ExecuteReader(oCmn.ConnectionString, CommandType.Text, qry);
        //int bb;
        //bb = System.DateTime.Today.Month;
        //strDate = System.DateTime.Now.ToString("yyyy-mm-dd 00:00:00.000");


        try
        {
            foreach (string sCaseID in arrCaseID)
            {
                //sql = "select verificationType from TcDump where caseId='" + + "'" ;
                //object obj1 = OleDbHelper.ExecuteScalar(oCmn.ConnectionString, CommandType.Text, sql);

                String sQuery = "INSERT INTO CPV_CC_TC_CASE_MAPPING (CASE_ID, TC_ID, VERIFICATION_TYPE_ID, DATE_TIME,Status) VALUES(" + sCaseID + ", '" + AssignedTo + "', '" + VerificationType + "', '" + aa + "','M')";
                OleDbHelper.ExecuteNonQuery(trans, CommandType.Text, sQuery);
                string sQuery1 = "delete from tcdump where caseid = " + sCaseID + " and verificationtype = '" + VerificationType + "'";
                OleDbHelper.ExecuteNonQuery(trans, CommandType.Text, sQuery1);
            }
            trans.Commit();
            conn.Close();
        }
        catch (Exception exp)
        {
            trans.Rollback();
            conn.Close();
            throw new Exception("An error occurred ", exp);
        }
    }
    public void InsertFeCaseMapping(string strCaseIds, string IsRef)
    {
        arrCaseID = strClinetId.Split(',');
        InsertTcCaseMapping("'" + strClinetId + "'");
    }
}
