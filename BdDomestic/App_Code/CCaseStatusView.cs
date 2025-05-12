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
/// Summary description for CCaseStatusView
/// </summary>
public class CCaseStatusView
{
    CCommon objconn = new CCommon();
	public CCaseStatusView()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    private string refNO;
    public string RefNO
    {
        get
        {
            return refNO;
        }
        set
        {
            refNO = value;
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
    public DataTable GetSearchDcr()
    {
        string sSql = "";

        DataTable dtSearch = new DataTable();
       
            //sSql = "Select CASE_ID,REF_NO,(isnull(FIRST_NAME,'') + ' ' + isnull(MIDDLE_NAME,'') + ' ' + isnull(LAST_NAME,'')) " +
            //       " as Applicant_Name ,VERIFICATION_CODE from CPV_CC_CASE_DETAILS where CENTRE_ID='" + CentreID + "'" +
            //       " and CLIENT_ID='" + ClientID + "'";
        sSql = "Select CASE_ID,REF_NO,(isnull(FIRST_NAME,'') + ' ' + isnull(MIDDLE_NAME,'') + ' ' + isnull(LAST_NAME,'')) " +
                   " as Applicant_Name ,VERIFICATION_CODE from CPV_CC_CASE_DETAILS where " +
                   " CLIENT_ID='" + ClientID + "'";
            if (RefNO != "")
            {
                sSql += " and REF_NO like '%" + objconn.FixQuotes(RefNO) + "%'";
            }
            if (ApplicantName != "")
            {
                sSql += " and (isnull(FIRST_NAME,'') + ' ' + isnull(MIDDLE_NAME,'') + '' + isnull(LAST_NAME,'')) " +
                       " like '%" + objconn.FixQuotes(ApplicantName) + "%'";
            }
            if (CaseID != "")
            {
                sSql += " and CASE_ID='" + CaseID + "'";
            }

            sSql += " ORDER BY CASE_ID DESC";

            OleDbDataAdapter oledbDA = new OleDbDataAdapter(sSql, objconn.ConnectionString);
            DataSet ds = new DataSet();
            oledbDA.Fill(ds,"Search");
            dtSearch = ds.Tables["Search"];
            return dtSearch;
        
    }

    public DataTable GetSearch()
    {
        string sSql = "";

        DataTable dtSearch = new DataTable();

        //sSql = "Select CASE_ID,REF_NO,(isnull(FIRST_NAME,'') + ' ' + isnull(MIDDLE_NAME,'') + ' ' + isnull(LAST_NAME,'')) " +
        //       " as Applicant_Name ,VERIFICATION_CODE from CPV_CC_CASE_DETAILS where CENTRE_ID='" + CentreID + "'" +
        //       " and CLIENT_ID='" + ClientID + "'";
        sSql = "Select CASE_ID,REF_NO,(isnull(FIRST_NAME,'') + ' ' + isnull(MIDDLE_NAME,'') + ' ' + isnull(LAST_NAME,'')) " +
               " as Applicant_Name ,VERIFICATION_CODE from CPV_CC_CASE_DETAILS where CENTRE_ID='" + CentreID + "'" +
               " and CLIENT_ID='" + ClientID + "'";
        if (RefNO != "")
        {
            sSql += " and REF_NO like '%" + objconn.FixQuotes(RefNO) + "%'";
        }
        if (ApplicantName != "")
        {
            sSql += " and (isnull(FIRST_NAME,'') + ' ' + isnull(MIDDLE_NAME,'') + '' + isnull(LAST_NAME,'')) " +
                   " like '%" + objconn.FixQuotes(ApplicantName) + "%'";
        }
        if (CaseID != "")
        {
            sSql += " and CASE_ID='" + CaseID + "'";
        }

        sSql += " ORDER BY CASE_ID DESC";

        OleDbDataAdapter oledbDA = new OleDbDataAdapter(sSql, objconn.ConnectionString);
        DataSet ds = new DataSet();
        oledbDA.Fill(ds, "Search");
        dtSearch = ds.Tables["Search"];
        return dtSearch;

    }

    public DataTable GetSearch_QC()
    {
        string sSql = "";

        DataTable dtSearch = new DataTable();

        //sSql = "Select CASE_ID,REF_NO,(isnull(FIRST_NAME,'') + ' ' + isnull(MIDDLE_NAME,'') + ' ' + isnull(LAST_NAME,'')) " +
        //       " as Applicant_Name ,VERIFICATION_CODE from CPV_CC_CASE_DETAILS where CENTRE_ID='" + CentreID + "'" +
        //       " and CLIENT_ID='" + ClientID + "'";
        sSql = "Select qc_case.CASE_ID,qc_case.REF_NO,(isnull(FIRST_NAME,'') + ' ' + isnull(MIDDLE_NAME,'') + ' ' + isnull(LAST_NAME,'')) as Applicant_Name, " +
               "qc_verification_code as VERIFICATION_CODE from CPV_qc_CASE_DETAILS qc_case left outer join cpv_cc_case_details case_details on qc_case.case_id=case_details.case_id " +
               " where qc_case.CENTRE_ID='" + CentreID + "'and qc_case.CLIENT_ID='" + ClientID + "'";
        if (RefNO != "")
        {
            sSql += " and qc_case.REF_NO like '%" + objconn.FixQuotes(RefNO) + "%'";
        }
        if (ApplicantName != "")
        {
            sSql += " and (isnull(FIRST_NAME,'') + ' ' + isnull(MIDDLE_NAME,'') + '' + isnull(LAST_NAME,'')) " +
                   " like '%" + objconn.FixQuotes(ApplicantName) + "%'";
        }
        if (CaseID != "")
        {
            sSql += " and qc_case.CASE_ID='" + CaseID + "'";
        }

        sSql += " ORDER BY qc_case.CASE_ID DESC";

        OleDbDataAdapter oledbDA = new OleDbDataAdapter(sSql, objconn.ConnectionString);
        DataSet ds = new DataSet();
        oledbDA.Fill(ds, "Search");
        dtSearch = ds.Tables["Search"];
        return dtSearch;

    }
    public DataTable RLGetSearch()
    {
        string sSql = "";

        DataTable dtSearch = new DataTable();

        sSql = "Select CASE_ID,REF_NO,(isnull(FIRST_NAME,'') + ' ' + isnull(MIDDLE_NAME,'') + ' ' + isnull(LAST_NAME,'')) " +
               " as Applicant_Name ,VERIFICATION_CODE from CPV_RL_CASE_DETAILS where CENTRE_ID='" + CentreID + "'" +
               " and CLIENT_ID='" + ClientID + "'";
        if (RefNO != "")
        {
            sSql += " and REF_NO like '%" + objconn.FixQuotes(RefNO) + "%'";
        }
        if (ApplicantName != "")
        {
            sSql += " and (isnull(FIRST_NAME,'') + ' ' + isnull(MIDDLE_NAME,'') + '' + isnull(LAST_NAME,'')) " +
                   " like '%" + objconn.FixQuotes(ApplicantName) + "%'";
        }
        if (CaseID != "")
        {
            sSql += " and CASE_ID='" + CaseID + "'";
        }

        sSql += " ORDER BY CASE_ID DESC";

        OleDbDataAdapter oledbDA = new OleDbDataAdapter(sSql, objconn.ConnectionString);
        DataSet ds = new DataSet();
        oledbDA.Fill(ds, "Search");
        dtSearch = ds.Tables["Search"];
        return dtSearch;

    }

    public DataTable RLGetSearch_Qc()
    {
        string sSql = "";

        DataTable dtSearch = new DataTable();

        //sSql = "Select CASE_ID,REF_NO,(isnull(FIRST_NAME,'') + ' ' + isnull(MIDDLE_NAME,'') + ' ' + isnull(LAST_NAME,'')) " +
        //       " as Applicant_Name ,VERIFICATION_CODE from CPV_RL_CASE_DETAILS where CENTRE_ID='" + CentreID + "'" +
        //       " and CLIENT_ID='" + ClientID + "'";
        sSql = "Select qc_case.CASE_ID,qc_case.REF_NO,(isnull(FIRST_NAME,'') + ' ' + isnull(MIDDLE_NAME,'') + ' ' + isnull(LAST_NAME,'')) " +
               " as Applicant_Name, qc_verification_code as VERIFICATION_CODE from CPV_qc_CASE_DETAILS qc_case left outer join cpv_rl_case_details case_details on qc_case.case_id=case_details.case_id " +
               " where qc_case.CENTRE_ID='" + CentreID + "' and qc_case.CLIENT_ID='" + ClientID + "'";
        if (RefNO != "")
        {
            sSql += " and qc_case.REF_NO like '%" + objconn.FixQuotes(RefNO) + "%'";
        }
        if (ApplicantName != "")
        {
            sSql += " and (isnull(FIRST_NAME,'') + ' ' + isnull(MIDDLE_NAME,'') + '' + isnull(LAST_NAME,'')) " +
                   " like '%" + objconn.FixQuotes(ApplicantName) + "%'";
        }
        if (CaseID != "")
        {
            sSql += " and qc_case.CASE_ID='" + CaseID + "'";
        }

        sSql += " ORDER BY qc_case.CASE_ID DESC";

        OleDbDataAdapter oledbDA = new OleDbDataAdapter(sSql, objconn.ConnectionString);
        DataSet ds = new DataSet();
        oledbDA.Fill(ds, "Search");
        dtSearch = ds.Tables["Search"];
        return dtSearch;

    }
    public DataTable KYCGetSearch()
    {
        string sSql = "";

        DataTable dtSearch = new DataTable();

        sSql = "Select cd.CASE_ID,REF_NO,(isnull(FIRST_NAME,'') + ' ' + isnull(MIDDLE_NAME,'') + ' ' + isnull(LAST_NAME,'')) " +
               " as Applicant_Name,tm.VERIFICATION_TYPE_CODE as VERIFICATION_CODE  from CPV_KYC_CASE_DETAILS cd inner join CPV_KYC_VERIFICATION_TYPE vt " +
               " on cd.CASE_ID=vt.CASE_ID inner join VERIFICATION_TYPE_MASTER as tm " +
               " on vt.VERIFICATION_TYPE_ID=tm.VERIFICATION_TYPE_ID " +
               " where CENTRE_ID='" + CentreID + "'" +
               " and CLIENT_ID='" + ClientID + "'";
        if (RefNO != "")
        {
            sSql += " and REF_NO like '%" + objconn.FixQuotes(RefNO) + "%'";
        }
        if (ApplicantName != "")
        {
            sSql += " and (isnull(FIRST_NAME,'') + ' ' + isnull(MIDDLE_NAME,'') + '' + isnull(LAST_NAME,'')) " +
                   " like '%" + objconn.FixQuotes(ApplicantName) + "%'";
        }
        if (CaseID != "")
        {
            sSql += " and cd.CASE_ID='" + CaseID + "'";
        }

        sSql += " ORDER BY cd.CASE_ID DESC";

        OleDbDataAdapter oledbDA = new OleDbDataAdapter(sSql, objconn.ConnectionString);
        DataSet ds = new DataSet();
        oledbDA.Fill(ds, "Search");
        dtSearch = ds.Tables["Search"];
        return dtSearch;

    }

    public DataTable KYCGetSearch_Qc()
    {
        string sSql = "";

        DataTable dtSearch = new DataTable();

        //sSql = "Select cd.CASE_ID,REF_NO,(isnull(FIRST_NAME,'') + ' ' + isnull(MIDDLE_NAME,'') + ' ' + isnull(LAST_NAME,'')) " +
        //       " as Applicant_Name,tm.VERIFICATION_TYPE_CODE as VERIFICATION_CODE  from CPV_KYC_CASE_DETAILS cd inner join CPV_KYC_VERIFICATION_TYPE vt " +
        //       " on cd.CASE_ID=vt.CASE_ID inner join VERIFICATION_TYPE_MASTER as tm " +
        //       " on vt.VERIFICATION_TYPE_ID=tm.VERIFICATION_TYPE_ID " +
        //       " where CENTRE_ID='" + CentreID + "'" +
        //       " and CLIENT_ID='" + ClientID + "'";
        sSql = "Select qc_case.CASE_ID,qc_case.REF_NO,(isnull(FIRST_NAME,'') + ' ' + isnull(MIDDLE_NAME,'') + ' ' + isnull(LAST_NAME,'')) as Applicant_Name,qc_verification_code as VERIFICATION_CODE from CPV_qc_CASE_DETAILS qc_case " +
               "left outer join cpv_kyc_case_details case_details on qc_case.case_id=case_details.case_id " +
               " where qc_case.CENTRE_ID='" + CentreID + "' and qc_case.CLIENT_ID='" + ClientID + "'";
        if (RefNO != "")
        {
            sSql += " and qc_case.REF_NO like '%" + objconn.FixQuotes(RefNO) + "%'";
        }
        if (ApplicantName != "")
        {
            sSql += " and (isnull(FIRST_NAME,'') + ' ' + isnull(MIDDLE_NAME,'') + '' + isnull(LAST_NAME,'')) " +
                   " like '%" + objconn.FixQuotes(ApplicantName) + "%'";
        }
        if (CaseID != "")
        {
            sSql += " and qc_case.CASE_ID='" + CaseID + "'";
        }

        sSql += " ORDER BY qc_case.CASE_ID DESC";

        OleDbDataAdapter oledbDA = new OleDbDataAdapter(sSql, objconn.ConnectionString);
        DataSet ds = new DataSet();
        oledbDA.Fill(ds, "Search");
        dtSearch = ds.Tables["Search"];
        return dtSearch;

    }
    public DataTable EBCGetSearch()
    {
        string sSql = "";
        DataTable dtSearch = new DataTable();

        sSql = " Select cd.CASE_ID,REF_NO,(isnull(FIRST_NAME,'') + ' ' + isnull(MIDDLE_NAME,'') + ' ' + isnull(LAST_NAME,'')) " +
               " as Applicant_Name,vm.VERIFICATION_TYPE_CODE as VERIFICATION_CODE from CPV_EBC_CASE_DETAILS as cd inner join CPV_EBC_VAERIFICATION_TYPE as vt on cd.CASE_ID=vt.Case_ID " +
               " inner join VERIFICATION_TYPE_MASTER as vm on vt.verification_type_id=vm.VERIFICATION_TYPE_ID " +
               " where CENTRE_ID='" + CentreID + "'" +
               " and CLIENT_ID='" + ClientID + "'" ;
        if (RefNO != "")
        {
            sSql += " and REF_NO like '%" + objconn.FixQuotes(RefNO) + "%'";
        }
        if (ApplicantName != "")
        {
            sSql += " and (isnull(FIRST_NAME,'') + ' ' + isnull(MIDDLE_NAME,'') + '' + isnull(LAST_NAME,'')) " +
                   " like '%" + objconn.FixQuotes(ApplicantName) + "%'";
        }
        if (CaseID != "")
        {
            sSql += " and cd.CASE_ID='" + CaseID + "'";
        }

        sSql += " ORDER BY cd.CASE_ID DESC";

        OleDbDataAdapter oledbDA = new OleDbDataAdapter(sSql, objconn.ConnectionString);
        DataSet ds = new DataSet();
        oledbDA.Fill(ds, "Search");
        dtSearch = ds.Tables["Search"];
        return dtSearch;
    }
}
