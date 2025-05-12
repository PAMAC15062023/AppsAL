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
/// Summary description for COverallCaseStatus
/// Made At 13-OCt-2007
/// Made BY Gargi Srivastava
/// </summary>
public class COverallCaseStatus
{
    CCommon objConn = new CCommon();
	public COverallCaseStatus()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    //Properties for Overall Case Status View
    private string todate;
    public string Todate
    {
        get
        {
            return todate;
        }
        set
        {
            todate = value;
        }
    }
    private string fromdate;
    public string Fromdate
    {
        get
        {
            return fromdate;
        }
        set
        {
            fromdate = value;
        }
    }
    private string clientID;
    public string ClientID
    {
        get
        {
            return clientID;
        }
        set
        {
            clientID = value;
        }
    }
    private string centreID;
    public string CentreID
    {
        get
        {
            return centreID;
        }
        set
        {
            centreID = value;
        }
    }
    private string caseID;
    public string CaseID
    {
        get
        {
            return caseID;
        }
        set
        {
            caseID = value;
        }
    }
    private string refNo;
    public string RefNo
    {
        get
        {
            return refNo;
        }
        set
        {
            refNo = value;
        }
    }
    private string applicantName;
    public string ApplicantName
    {
        get
        {
            return applicantName;
        }
        set
        {
            applicantName = value;
        }
    }
    private string overallStatus;
    public string OverallStatus
    {
        get
        {
            return overallStatus;
        }
        set
        {
            overallStatus = value; 
        }
    }
    private string overallComments;
    public string OverallComments
    {
        get
        {
            return overallComments;
        }
        set
        {
            overallComments = value;
        }
    }
    private string productID;
    public string ProductID
    {
        get
        {
            return productID;
        }
        set
        {
            productID = value ;
        }
    }
    
    public DataTable CCGetSearch()
    {
        string sSql = "";
        DataTable dtSearch = new DataTable();
        sSql = "Select CASE_ID,isnull(FIRST_NAME,'')+ ' ' + isnull(MIDDLE_NAME,'')+ ' ' + isnull(LAST_NAME,'') as Applicant_Name," +
               "REF_NO,Overall_Status_ID,STATUS_CODE,Overall_comments  " +
               "from CPV_CC_CASE_DETAILS cd left join CASE_STATUS_MASTER cm "+
               "on cm.CASE_STATUS_ID = cd.Overall_Status_ID "+
               " where IS_CASE_COMPLETE = 'Y' and SEND_DATETIME is null " +
               "And CLIENT_ID='" + ClientID + "'" + " And CENTRE_ID='" + CentreID + "'";

        if (Fromdate != "")
        {
            sSql += " And convert(varchar(24),CASE_REC_DATETIME,103)>='" + Fromdate + "'";
        }
        if (Todate != "")
        {
            sSql += " And convert(varchar(24),CASE_REC_DATETIME,103)<='" + Todate + "'";
        }

        sSql += " ORDER BY CASE_ID DESC";

        OleDbDataAdapter oledbDA = new OleDbDataAdapter(sSql, objConn.ConnectionString);
        DataSet dsSearch = new DataSet();
        oledbDA.Fill(dsSearch, "Search");
        dtSearch=dsSearch.Tables["Search"];
        return dtSearch;
    }
    
    public DataTable FillOverallStatus()
    {
        DataTable dt = new DataTable();
        string sSql = "";
        sSql = "SELECT [CASE_STATUS_ID], [STATUS_CODE] FROM [CASE_STATUS_MASTER] WHERE PRODUCT_ID='"+ ProductID +"'" + " ORDER BY STATUS_CODE ";
        OleDbDataAdapter oledbDA = new OleDbDataAdapter(sSql, objConn.ConnectionString);
        DataSet ds = new DataSet();
        oledbDA.Fill(ds, "OverallStatus");
        dt = ds.Tables["OverallStatus"];
        return dt;
    }

    public string UpdateGridItems()
    {
        OleDbDataReader oledbDataReader;
        OleDbConnection conn = new OleDbConnection(objConn.ConnectionString);
        conn.Open();
        OleDbTransaction oledbTrans = conn.BeginTransaction();
        string strMSg = "";
        string strSql = "";
        string sSql = "";
        try
        {

            strSql = " Select CASE_ID from CPV_CC_CASE_DETAILS " +
                     " Where CASE_ID='" + CaseID + "'";
            oledbDataReader = OleDbHelper.ExecuteReader(objConn.ConnectionString, CommandType.Text, strSql);

            OleDbParameter[] oledbParam = new OleDbParameter[3];

            if (oledbDataReader.Read())
            {
                sSql = "Update CPV_CC_CASE_DETAILS set Overall_comments=?,Overall_Status_ID=? " +
                        " Where CASE_ID=?";


                oledbParam[0] = new OleDbParameter("OverallComments", OleDbType.VarChar, 200);
                oledbParam[0].Value = OverallComments;

                oledbParam[1] = new OleDbParameter("OverallStatusID", OleDbType.VarChar, 15);
                oledbParam[1].Value = OverallStatus;

                oledbParam[2] = new OleDbParameter("CaseID", OleDbType.VarChar, 15);
                oledbParam[2].Value = CaseID;

                strMSg = "Records Updated Successfully..";


            }
            OleDbHelper.ExecuteNonQuery(oledbTrans, CommandType.Text, sSql, oledbParam);
            oledbTrans.Commit();
            conn.Close();
            return strMSg;
        }
        catch (Exception ex)
        {
            throw new Exception("Error while Updating " + ex.Message);
        }

    }
    
}
