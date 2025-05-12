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
/// Summary description for C_Sms_Generation
/// </summary>
public class C_Sms_Generation
{
    CCommon Con = new CCommon();
	public C_Sms_Generation()
	{
		//
		// TODO: Add constructor logic here
		//
    }
    #region Property Declaration
    private string strfromDate;    
    private string strtoDate;   
    private string sms;
    private string mobile;
    private string caseId;
    private string verificationId;   
    public string VerificationId
    {
        get { return verificationId; }
        set { verificationId = value; }
    }

    

    private DateTime sms_Date_Time;
   
    public DateTime Sms_Date_Time
    {
        get { return sms_Date_Time; }
        set { sms_Date_Time = value; }
    }
    public string Sms
    {
        get { return sms; }
        set { sms = value; }
    }
    public string Mobile
    {
        get { return mobile; }
        set { mobile = value; }
    }
    public string CaseId
    {
        get { return caseId; }
        set { caseId = value; }
    }
    public string StrfromDate
    {
        get { return strfromDate; }
        set { strfromDate = value; }
    }
    public string StrtoDate
    {
        get { return strtoDate; }
        set { strtoDate = value; }
    }
    #endregion Property Declaration
    public DataTable GetRecord(String Str)
    {

        DataTable dtselectedField = new DataTable();
        OleDbConnection conn = new OleDbConnection(Con.ConnectionString);
        conn.Open();
        OleDbDataAdapter oledbDa = new OleDbDataAdapter(Str, conn);
        DataSet ds = new DataSet();
        oledbDa.Fill(ds, "Sms");
        dtselectedField = ds.Tables["Sms"];
        return dtselectedField;


    }


    public DataSet getTemplateForSms()
    {

        string strSQL = " SELECT  VTM.VERIFICATION_TYPE_CODE,CM.CLIENT_NAME,LPTM.CLIENT_ID, LPTD.SERIAL_NO,LPTD.SELECTED_FIELD,LPTD.TABLE_NAME,LPTM.ADDITIONAL1,LPTM.ADDITIONAL2";
        strSQL = strSQL + " FROM LABEL_PRINTING_TEMPLATE_MASTER LPTM ";
        strSQL = strSQL + " INNER JOIN LABEL_PRINTING_TEMPLATE_DETAILS LPTD ";
        strSQL = strSQL + " ON (LPTM.LABEL_TEMPLATE_ID=LPTD.LABEL_TEMPLATE_ID) INNER JOIN VERIFICATION_TYPE_MASTER VM ON  LPTM.VERIFICATION_TYPE_ID=VM.VERIFICATION_TYPE_ID  INNER JOIN CLIENT_MASTER CM ON CM.CLIENT_ID=LPTM.CLIENT_ID";

        strSQL = strSQL + " INNER JOIN VERIFICATION_TYPE_MASTER VTM";
        strSQL = strSQL + " ON (LPTM.VERIFICATION_TYPE_ID=VTM.VERIFICATION_TYPE_ID)";
      
        strSQL = strSQL + " WHERE LPTM.CLIENT_ID='" + HttpContext.Current.Session["ClientId"].ToString() + "' AND LPTM.ACTIVITY_ID='" + HttpContext.Current.Session["ActivityId"].ToString() + "'";
        strSQL = strSQL + " AND LPTM.PRODUCT_ID='" + HttpContext.Current.Session["ProductId"].ToString() + "'";
        strSQL = strSQL + " AND  LPTM.Template_For='S' AND LPTM.VERIFICATION_TYPE_ID='" + VerificationId + "' ORDER BY LPTD.SERIAL_NO";
        return OleDbHelper.ExecuteDataset(Con.ConnectionString, CommandType.Text, strSQL);

    }


    public DataSet getTemplateForSmsCellular()
    {

        string strSQL = " SELECT CT.CASE_TYPE_CODE,LPTM.CLIENT_ID, LPTD.SERIAL_NO,LPTD.SELECTED_FIELD,LPTD.TABLE_NAME,LPTM.ADDITIONAL1,LPTM.ADDITIONAL2";
        strSQL = strSQL + " FROM LABEL_PRINTING_TEMPLATE_MASTER LPTM ";
        strSQL = strSQL + " INNER JOIN LABEL_PRINTING_TEMPLATE_DETAILS LPTD ";
        strSQL = strSQL + " ON (LPTM.LABEL_TEMPLATE_ID=LPTD.LABEL_TEMPLATE_ID) INNER JOIN CPV_CELLULAR_CASE_TYPE_MASTER CT ON  LPTM.VERIFICATION_TYPE_ID=CT.CASE_TYPE_ID";
        strSQL = strSQL + " WHERE LPTM.CLIENT_ID='" + HttpContext.Current.Session["ClientId"].ToString() + "' AND LPTM.ACTIVITY_ID='" + HttpContext.Current.Session["ActivityId"].ToString() + "'";
        strSQL = strSQL + " AND LPTM.PRODUCT_ID='" + HttpContext.Current.Session["ProductId"].ToString() + "'";
        strSQL = strSQL + " AND  LPTM.Template_For='S' and  LPTM.IS_TYPE_SPECIFIC ='1' AND LPTM.VERIFICATION_TYPE_ID ='" + VerificationId + "' ORDER BY LPTD.SERIAL_NO";
        return OleDbHelper.ExecuteDataset(Con.ConnectionString, CommandType.Text, strSQL);

    }



    public DataSet GetVerificationType_RL(string activityid)
    {

        string strSQL = " select VERIFICATION_TYPE_CODE,VERIFICATION_TYPE_ID FROM verification_type_master   WHERE  ACTIVITY_ID= '" + activityid + "'" +
                         " AND VERIFICATION_TYPE_ID IN(1,2,3,4,10,12,13,14) ";
        return OleDbHelper.ExecuteDataset(Con.ConnectionString, CommandType.Text, strSQL);
    }
    public DataSet GetVerificationType_CC(string activityid)
    {

        string strSQL = " select VERIFICATION_TYPE_CODE,VERIFICATION_TYPE_ID FROM verification_type_master   WHERE  ACTIVITY_ID= '" + activityid + "'" +
                         " AND VERIFICATION_TYPE_ID IN(1,2,10) ";
        return OleDbHelper.ExecuteDataset(Con.ConnectionString, CommandType.Text, strSQL);
    }
    public DataSet GetVerificationType_EBC(string activityid)
    {

        string strSQL = " select VERIFICATION_TYPE_CODE,VERIFICATION_TYPE_ID FROM verification_type_master   WHERE  ACTIVITY_ID= '" + activityid + "'" +
                         " AND VERIFICATION_TYPE_ID IN(1,15,16,17,18) ";
        return OleDbHelper.ExecuteDataset(Con.ConnectionString, CommandType.Text, strSQL);
    }
    public DataSet GetVerificationType_KYC(string activityid)
    {

        string strSQL = " select VERIFICATION_TYPE_CODE,VERIFICATION_TYPE_ID FROM verification_type_master   WHERE  ACTIVITY_ID= '" + activityid + "'" +
                         " AND VERIFICATION_TYPE_ID IN(1,2,19) ";
        return OleDbHelper.ExecuteDataset(Con.ConnectionString, CommandType.Text, strSQL);
    }
    public DataSet GetVerificationType_Idoc(string activityid)
    {

        string strSQL = " select VERIFICATION_TYPE_CODE,VERIFICATION_TYPE_ID FROM verification_type_master   WHERE  ACTIVITY_ID= '" + activityid + "'" +
                         " AND VERIFICATION_TYPE_ID IN(5,6,7,8,9,11) ";
        return OleDbHelper.ExecuteDataset(Con.ConnectionString, CommandType.Text, strSQL);
    }
   public DataTable finalrecordNew(string sRoleId,DateTime FromDate ,DateTime ToDate,string strCentreId,string strClientId )
   {
       DataSet dsLabelQuery = new DataSet();
       DataTable dtselectedField = new DataTable();
       string strTableName = "";
       string strSQL = "";
       OleDbConnection conn = new OleDbConnection(Con.ConnectionString);
       conn.Open();
       dsLabelQuery = getTemplateForSms();
       try
       {
           if (dsLabelQuery.Tables[0].Rows.Count > 0)
           {

              
               for (int i = 0; i < dsLabelQuery.Tables[0].Rows.Count; i++)
               {
                   strTableName = dsLabelQuery.Tables[0].Rows[i]["TABLE_NAME"].ToString();
                   string   strVerification = dsLabelQuery.Tables[0].Rows[i]["VERIFICATION_TYPE_CODE"].ToString();
                   if (dsLabelQuery.Tables[0].Rows[i]["SELECTED_FIELD"].ToString() != "MOBILE")
                   { 
                    
                   if (strTableName == "CPV_RL_CASE_DETAILS")
                    {                        
                       if ((i == 2) )
                        {

                            strSQL = strSQL + "+' ' + vm.VERIFICATION_type_code ";
                        }
                  
                       if (Convert.ToString(dsLabelQuery.Tables[0].Rows[i]["SELECTED_FIELD"]) == "CLIENT_ID")
                       {
                           if (i == 0)
                           {
                               strSQL = strSQL + " CM.CLIENT_CODE ";
                           }
                       }
                       else
                       {
                           if (Convert.ToString(dsLabelQuery.Tables[0].Rows[i]["SELECTED_FIELD"]) == "CASE_ID")
                           {

                               strSQL = strSQL +  " CCC.CASE_ID ";

                           }
                           else
                           {

                               strSQL = strSQL + "+ ' ' +ISNULL(" + dsLabelQuery.Tables[0].Rows[i]["SELECTED_FIELD"].ToString() + ",'')";
                           }
                       }
                       
                   }
                   if (strTableName == "CPV_IDOC_CASE_DETAILS")
                   {
                       if ((i == 2))
                       {

                           strSQL = strSQL + "+' ' + vm.VERIFICATION_type_code ";
                       }

                       if (Convert.ToString(dsLabelQuery.Tables[0].Rows[i]["SELECTED_FIELD"]) == "CLIENT_ID")
                       {
                           if (i == 0)
                           {
                               strSQL = strSQL + " CM.CLIENT_CODE ";
                           }
                       }
                       else
                       {
                           if (Convert.ToString(dsLabelQuery.Tables[0].Rows[i]["SELECTED_FIELD"]) == "CASE_ID")
                           {

                               strSQL = strSQL + " CCC.CASE_ID ";

                           }
                           else
                           {

                               strSQL = strSQL + "+ ' ' +ISNULL(" + dsLabelQuery.Tables[0].Rows[i]["SELECTED_FIELD"].ToString() + ",'')";
                           }
                       }
                      
                   }
                   if (strTableName == "CPV_EBC_CASE_DETAILS")
                   {
                       if ((i == 2))
                       {

                           strSQL = strSQL + "+' ' + vm.VERIFICATION_type_code ";
                       }

                       if (Convert.ToString(dsLabelQuery.Tables[0].Rows[i]["SELECTED_FIELD"]) == "CLIENT_ID")
                       {
                           if (i == 0)
                           {
                               strSQL = strSQL + " CM.CLIENT_CODE ";
                           }
                       }
                       else
                       {
                           if (Convert.ToString(dsLabelQuery.Tables[0].Rows[i]["SELECTED_FIELD"]) == "CASE_ID")
                           {

                               strSQL = strSQL + " CCC.CASE_ID ";

                           }
                           else
                           {

                               strSQL = strSQL + "+ ' ' +ISNULL(" + dsLabelQuery.Tables[0].Rows[i]["SELECTED_FIELD"].ToString() + ",'')";
                           }
                       }
                       
                   }

                   if (strTableName == "CPV_KYC_CASE_DETAILS")
                   {
                       if ((i == 2))
                       {

                           strSQL = strSQL + "+' ' + vm.VERIFICATION_type_code ";
                       }

                       if (Convert.ToString(dsLabelQuery.Tables[0].Rows[i]["SELECTED_FIELD"]) == "CLIENT_ID")
                       {
                           if (i == 0)
                           {
                               strSQL = strSQL + " CM.CLIENT_CODE ";
                           }
                       }
                       else
                       {
                           if (Convert.ToString(dsLabelQuery.Tables[0].Rows[i]["SELECTED_FIELD"]) == "CASE_ID")
                           {

                               strSQL = strSQL + " CCC.CASE_ID ";

                           }
                           else
                           {

                               strSQL = strSQL + "+ ' ' +ISNULL(" + dsLabelQuery.Tables[0].Rows[i]["SELECTED_FIELD"].ToString() + ",'')";
                           }
                       }
                      
                   }
                   if (strTableName == "CPV_CC_CASE_DETAILS")
                   {
                       if ((i == 2))
                       {

                           strSQL = strSQL + "+' ' + vm.VERIFICATION_type_code ";
                       }

                       if (Convert.ToString(dsLabelQuery.Tables[0].Rows[i]["SELECTED_FIELD"]) == "CLIENT_ID")
                       {
                           if (i == 0)
                           {
                               strSQL = strSQL + " CM.CLIENT_CODE ";
                           }
                       }
                       else
                       {
                           if (Convert.ToString(dsLabelQuery.Tables[0].Rows[i]["SELECTED_FIELD"]) == "CASE_ID")
                           {

                               strSQL = strSQL + " CCC.CASE_ID ";

                           }
                           else
                           {

                               strSQL = strSQL + "+ ' ' +ISNULL(" + dsLabelQuery.Tables[0].Rows[i]["SELECTED_FIELD"].ToString() + ",'')";
                           }
                       }
                       
                   }
               }           
             }
               
               if (strTableName == "CPV_RL_CASE_DETAILS")
               {
                   //strSQL = "SELECT " + strSQL + " AS SmsContent ," + " ccc.CASE_ID,ccc.REF_NO, v.FullName, " +
                   //    "(ISNULL(ccc.FIRST_NAME,'')+'  '+ISNULL(ccc.MIDDLE_NAME,'')+'  '+ISNULL(ccc.LAST_NAME,'')) "+ 
                   //    " AS APPLICANT_NAME, (ISNULL(ccc.RES_ADD_LINE_1,'')+'  '+ISNULL(ccc.RES_ADD_LINE_2,'')+'  '+ISNULL(ccc.RES_ADD_LINE_3,''))"+
                   //    " AS ADDRESS, CONVERT(CHAR(9), ccc.CASE_REC_DATETIME, 3) + LTRIM(SUBSTRING(CONVERT( VARCHAR(20), ccc.CASE_REC_DATETIME, 22), 10, 5) + RIGHT(CONVERT(VARCHAR(20),"+
                   //    " ccc.CASE_REC_DATETIME, 22), 3)) as REC_DATETIME , '+91'+v.MOBILE as MOBILE FROM CPV_RL_CASE_DETAILS  as ccc " +
                   //    "inner join CPV_RL_CASE_FE_MAPPING as ccva on ccc.CASE_ID=ccva.CASE_ID inner join FE_VW1 as "+
                   //    " v on v.emp_id = ccva.FE_ID inner join client_master cm on ccc.client_id = cm.client_id inner join verification_type_master vm on ccva.verification_type_id=vm.verification_type_id   WHERE ccva.verification_type_id='" + VerificationId + "'and CCC.SEND_DATETIME IS NULL AND  " +
                   //    " ccc.CASE_REC_DATETIME >= '" + FromDate + "' AND ccc.CASE_REC_DATETIME <  '" + ToDate + "' " +
                   //    " and  ccc.Centre_id = '" + strCentreId + "'   and  ccc.Client_id ='" + strClientId + " '"+
                   //    "and  ccc.SMS_DATE_TIME IS NULL ";
                   //modified by hemangi kambli on 20-nov-2007 ------
                   if (sRoleId == "2") //if supervisor then ....
                   {
                       strSQL = "SELECT (''''+ ccc.case_id + '''' + ' ' + " + strSQL + " + ' ' +ISNULL('" + dsLabelQuery.Tables[0].Rows[1]["ADDITIONAL1"].ToString() + "','') + ' ' +ISNULL('" + dsLabelQuery.Tables[0].Rows[1]["ADDITIONAL2"].ToString() + "','')) AS SmsContent ," + " ccc.CASE_ID,ccc.REF_NO, v.FullName, " +
                           "(ISNULL(ccc.FIRST_NAME,'')+'  '+ISNULL(ccc.MIDDLE_NAME,'')+'  '+ISNULL(ccc.LAST_NAME,'')) " +
                           " AS APPLICANT_NAME, (ISNULL(ccc.RES_ADD_LINE_1,'')+'  '+ISNULL(ccc.RES_ADD_LINE_2,'')+'  '+ISNULL(ccc.RES_ADD_LINE_3,''))" +
                           " AS ADDRESS, CONVERT(CHAR(9), ccc.CASE_REC_DATETIME, 3) + LTRIM(SUBSTRING(CONVERT( VARCHAR(20), ccc.CASE_REC_DATETIME, 22), 10, 5) + RIGHT(CONVERT(VARCHAR(20)," +
                           " ccc.CASE_REC_DATETIME, 22), 3)) as REC_DATETIME , '+91'+v.MOBILE as MOBILE " +
                           " FROM CPV_RL_CASE_DETAILS  as ccc " +
                           " inner join CPV_RL_CASE_VERIFICATIONTYPE as cv on ccc.case_id=cv.case_id " +
                           " inner join CPV_RL_CASE_FE_MAPPING as ccva on cv.CASE_ID=ccva.CASE_ID and cv.verification_type_id=ccva.verification_type_id " +
                           " inner join FE_VW1 as  v on v.emp_id = ccva.FE_ID inner join client_master cm on ccc.client_id = cm.client_id " +
                           " inner join verification_type_master vm on ccva.verification_type_id=vm.verification_type_id " +
                           " WHERE ccva.verification_type_id='" + VerificationId + "'and CCC.SEND_DATETIME IS NULL " +
                           " and cv.IS_SMS_SEND='N' and ccc.CASE_REC_DATETIME >= '" + FromDate + "' AND ccc.CASE_REC_DATETIME <  '" + ToDate + "' " +
                           " and  ccc.Centre_id = '" + strCentreId + "'   and  ccc.Client_id ='" + strClientId + " '";
                           
                   }
                   else  //If other than supervisor
                   {
                       strSQL = "SELECT (''''+ ccc.case_id + '''' + ' ' + " + strSQL + " + ' ' +ISNULL('" + dsLabelQuery.Tables[0].Rows[1]["ADDITIONAL1"].ToString() + "','') + ' ' +ISNULL('" + dsLabelQuery.Tables[0].Rows[1]["ADDITIONAL2"].ToString() + "','')) AS SmsContent ," + " ccc.CASE_ID,ccc.REF_NO, v.FullName, " +
                           "(ISNULL(ccc.FIRST_NAME,'')+'  '+ISNULL(ccc.MIDDLE_NAME,'')+'  '+ISNULL(ccc.LAST_NAME,'')) " +
                           " AS APPLICANT_NAME, (ISNULL(ccc.RES_ADD_LINE_1,'')+'  '+ISNULL(ccc.RES_ADD_LINE_2,'')+'  '+ISNULL(ccc.RES_ADD_LINE_3,''))" +
                           " AS ADDRESS, CONVERT(CHAR(9), ccc.CASE_REC_DATETIME, 3) + LTRIM(SUBSTRING(CONVERT( VARCHAR(20), ccc.CASE_REC_DATETIME, 22), 10, 5) + RIGHT(CONVERT(VARCHAR(20)," +
                           " ccc.CASE_REC_DATETIME, 22), 3)) as REC_DATETIME , '+91'+v.MOBILE as MOBILE " +
                           " FROM CPV_RL_CASE_DETAILS  as ccc " +
                           " inner join CPV_RL_CASE_VERIFICATIONTYPE as cv on ccc.case_id=cv.case_id " +
                           " inner join CPV_RL_CASE_FE_MAPPING as ccva on cv.CASE_ID=ccva.CASE_ID and cv.verification_type_id=ccva.verification_type_id " +
                           " inner join FE_VW1 as  v on v.emp_id = ccva.FE_ID inner join client_master cm on ccc.client_id = cm.client_id " +
                           " inner join verification_type_master vm on ccva.verification_type_id=vm.verification_type_id " +
                           " WHERE ccva.verification_type_id='" + VerificationId + "'and CCC.SEND_DATETIME IS NULL " +
                           " and ccc.CASE_REC_DATETIME >= '" + FromDate + "' AND ccc.CASE_REC_DATETIME <  '" + ToDate + "' " +
                           " and  ccc.Centre_id = '" + strCentreId + "'   and  ccc.Client_id ='" + strClientId + " '";                           
                   }
               }
               if (strTableName == "CPV_IDOC_CASE_DETAILS")
               {
                   if (sRoleId == "2") //if supervisor then ....
                   {
                       strSQL = "SELECT (''''+ ccc.case_id + '''' + ' ' + " + strSQL + " + ' ' +ISNULL('" + dsLabelQuery.Tables[0].Rows[1]["ADDITIONAL1"].ToString() + "','') + ' ' +ISNULL('" + dsLabelQuery.Tables[0].Rows[1]["ADDITIONAL2"].ToString() + "','')) AS SmsContent ," + " ccc.CASE_ID,ccc.REF_NO, v.FullName, " +
                           "(ISNULL(ccc.FIRST_NAME,'')+'  '+ISNULL(ccc.MIDDLE_NAME,'')+'  '+ISNULL(ccc.LAST_NAME,'')) " +
                           " AS APPLICANT_NAME, (ISNULL(ccc.RES_ADD_LINE_1,'')+'  '+ISNULL(ccc.RES_ADD_LINE_2,'')+'  '+ISNULL(ccc.RES_ADD_LINE_3,''))" +
                           " AS ADDRESS, CONVERT(CHAR(9), ccc.CASE_REC_DATETIME, 3) + LTRIM(SUBSTRING(CONVERT( VARCHAR(20), ccc.CASE_REC_DATETIME, 22), 10, 5) + RIGHT(CONVERT(VARCHAR(20)," +
                           " ccc.CASE_REC_DATETIME, 22), 3)) as REC_DATETIME , '+91'+v.MOBILE as MOBILE " +
                           " FROM CPV_IDOC_CASE_DETAILS  as ccc " +
                           " inner join CPV_IDOC_VERIFICATION_TYPE as cv on ccc.case_id=cv.case_id " +
                           " left outer join CPV_IDOC_FE_CASE_MAPPING as ccva on cv.CASE_ID=ccva.CASE_ID and cv.verification_type_id=ccva.verification_type_id " +
                           " inner join FE_VW1 as  v on v.emp_id = ccva.FE_ID inner join client_master cm on ccc.client_id = cm.client_id " +
                           " inner join verification_type_master vm on ccva.verification_type_id=vm.verification_type_id " +
                           " WHERE ccva.verification_type_id='" + VerificationId + "'and CCC.SEND_DATETIME IS NULL " +
                           " and cv.IS_SMS_SEND='N' and ccc.CASE_REC_DATETIME >= '" + FromDate + "' AND ccc.CASE_REC_DATETIME <  '" + ToDate + "' " +
                           " and  ccc.Centre_id = '" + strCentreId + "'   and  ccc.Client_id ='" + strClientId + " '";

                   }
                   else  //If other than supervisor
                   {
                       strSQL = "SELECT (''''+ ccc.case_id + '''' + ' ' + " + strSQL + " + ' ' +ISNULL('" + dsLabelQuery.Tables[0].Rows[1]["ADDITIONAL1"].ToString() + "','') + ' ' +ISNULL('" + dsLabelQuery.Tables[0].Rows[1]["ADDITIONAL2"].ToString() + "','')) AS SmsContent ," + " ccc.CASE_ID,ccc.REF_NO, v.FullName, " +
                           "(ISNULL(ccc.FIRST_NAME,'')+'  '+ISNULL(ccc.MIDDLE_NAME,'')+'  '+ISNULL(ccc.LAST_NAME,'')) " +
                           " AS APPLICANT_NAME, (ISNULL(ccc.RES_ADD_LINE_1,'')+'  '+ISNULL(ccc.RES_ADD_LINE_2,'')+'  '+ISNULL(ccc.RES_ADD_LINE_3,''))" +
                           " AS ADDRESS, CONVERT(CHAR(9), ccc.CASE_REC_DATETIME, 3) + LTRIM(SUBSTRING(CONVERT( VARCHAR(20), ccc.CASE_REC_DATETIME, 22), 10, 5) + RIGHT(CONVERT(VARCHAR(20)," +
                           " ccc.CASE_REC_DATETIME, 22), 3)) as REC_DATETIME , '+91'+v.MOBILE as MOBILE " +
                           " FROM CPV_IDOC_CASE_DETAILS  as ccc " +
                           " inner join CPV_IDOC_VERIFICATION_TYPE as cv on ccc.case_id=cv.case_id " +
                           " inner join CPV_IDOC_FE_CASE_MAPPING as ccva on cv.CASE_ID=ccva.CASE_ID and cv.verification_type_id=ccva.verification_type_id " +
                           " inner join FE_VW1 as  v on v.emp_id = ccva.FE_ID inner join client_master cm on ccc.client_id = cm.client_id " +
                           " inner join verification_type_master vm on ccva.verification_type_id=vm.verification_type_id " +
                           " WHERE ccva.verification_type_id='" + VerificationId + "'and CCC.SEND_DATETIME IS NULL " +
                           " and ccc.CASE_REC_DATETIME >= '" + FromDate + "' AND ccc.CASE_REC_DATETIME <  '" + ToDate + "' " +
                           " and  ccc.Centre_id = '" + strCentreId + "'   and  ccc.Client_id ='" + strClientId + " '";
                   }
               }
               if (strTableName == "CPV_EBC_CASE_DETAILS")
               {
                   if (sRoleId == "2") //if supervisor then ....
                   {
                       strSQL = "SELECT (''''+ ccc.case_id + '''' + ' ' + " + strSQL + " + ' ' +ISNULL('" + dsLabelQuery.Tables[0].Rows[1]["ADDITIONAL1"].ToString() + "','') + ' ' +ISNULL('" + dsLabelQuery.Tables[0].Rows[1]["ADDITIONAL2"].ToString() + "','')) AS SmsContent ," + " ccc.CASE_ID,ccc.REF_NO, v.FullName, " +
                           "(ISNULL(ccc.FIRST_NAME,'')+'  '+ISNULL(ccc.MIDDLE_NAME,'')+'  '+ISNULL(ccc.LAST_NAME,'')) " +
                           " AS APPLICANT_NAME, (ISNULL(ccc.ADD_LINE_1,'')+'  '+ISNULL(ccc.ADD_LINE_2,'')+'  '+ISNULL(ccc.ADD_LINE_3,''))" +
                           " AS ADDRESS, CONVERT(CHAR(9), ccc.CASE_REC_DATETIME, 3) + LTRIM(SUBSTRING(CONVERT( VARCHAR(20), ccc.CASE_REC_DATETIME, 22), 10, 5) + RIGHT(CONVERT(VARCHAR(20)," +
                           " ccc.CASE_REC_DATETIME, 22), 3)) as REC_DATETIME , '+91'+v.MOBILE as MOBILE " +
                           " FROM CPV_EBC_CASE_DETAILS  as ccc " +
                           " inner join CPV_EBC_VAERIFICATION_TYPE as cv on ccc.case_id=cv.case_id " +
                           " inner join CPV_EBC_FE_MAPPING as ccva on cv.CASE_ID=ccva.CASE_ID and cv.verification_type_id=ccva.verification_type_id " +
                           " inner join FE_VW1 as  v on v.emp_id = ccva.FE_ID inner join client_master cm on ccc.client_id = cm.client_id " +
                           " inner join verification_type_master vm on ccva.verification_type_id=vm.verification_type_id " +
                           " WHERE ccva.verification_type_id='" + VerificationId + "'and CCC.SEND_DATETIME IS NULL " +
                           " and cv.IS_SMS_SEND='N' and ccc.CASE_REC_DATETIME >= '" + FromDate + "' AND ccc.CASE_REC_DATETIME <  '" + ToDate + "' " +
                           " and  ccc.Centre_id = '" + strCentreId + "'   and  ccc.Client_id ='" + strClientId + " '";

                   }
                   else  //If other than supervisor
                   {
                       strSQL = "SELECT (''''+ ccc.case_id + '''' + ' ' + " + strSQL + " + ' ' +ISNULL('" + dsLabelQuery.Tables[0].Rows[1]["ADDITIONAL1"].ToString() + "','') + ' ' +ISNULL('" + dsLabelQuery.Tables[0].Rows[1]["ADDITIONAL2"].ToString() + "','')) AS SmsContent ," + " ccc.CASE_ID,ccc.REF_NO, v.FullName, " +
                           "(ISNULL(ccc.FIRST_NAME,'')+'  '+ISNULL(ccc.MIDDLE_NAME,'')+'  '+ISNULL(ccc.LAST_NAME,'')) " +
                           " AS APPLICANT_NAME, (ISNULL(ccc.ADD_LINE_1,'')+'  '+ISNULL(ccc.ADD_LINE_2,'')+'  '+ISNULL(ccc.ADD_LINE_3,''))" +
                           " AS ADDRESS, CONVERT(CHAR(9), ccc.CASE_REC_DATETIME, 3) + LTRIM(SUBSTRING(CONVERT( VARCHAR(20), ccc.CASE_REC_DATETIME, 22), 10, 5) + RIGHT(CONVERT(VARCHAR(20)," +
                           " ccc.CASE_REC_DATETIME, 22), 3)) as REC_DATETIME , '+91'+v.MOBILE as MOBILE " +
                           " FROM CPV_EBC_CASE_DETAILS  as ccc " +
                           " inner join CPV_EBC_VAERIFICATION_TYPE as cv on ccc.case_id=cv.case_id " +
                           " inner join CPV_EBC_FE_MAPPING as ccva on cv.CASE_ID=ccva.CASE_ID and cv.verification_type_id=ccva.verification_type_id " +
                           " inner join FE_VW1 as  v on v.emp_id = ccva.FE_ID inner join client_master cm on ccc.client_id = cm.client_id " +
                           " inner join verification_type_master vm on ccva.verification_type_id=vm.verification_type_id " +
                           " WHERE ccva.verification_type_id='" + VerificationId + "'and CCC.SEND_DATETIME IS NULL " +
                           " and ccc.CASE_REC_DATETIME >= '" + FromDate + "' AND ccc.CASE_REC_DATETIME <  '" + ToDate + "' " +
                           " and  ccc.Centre_id = '" + strCentreId + "'   and  ccc.Client_id ='" + strClientId + " '";
                   }
               }
               if (strTableName == "CPV_KYC_CASE_DETAILS")
               {
                   if (sRoleId == "2") //if supervisor then ....
                   {
                       strSQL = "SELECT (''''+ ccc.case_id + '''' + ' ' + " + strSQL + " + ' ' +ISNULL('" + dsLabelQuery.Tables[0].Rows[1]["ADDITIONAL1"].ToString() + "','') + ' ' +ISNULL('" + dsLabelQuery.Tables[0].Rows[1]["ADDITIONAL2"].ToString() + "','')) AS SmsContent ," + " ccc.CASE_ID,ccc.REF_NO, v.FullName, " +
                           "(ISNULL(ccc.FIRST_NAME,'')+'  '+ISNULL(ccc.MIDDLE_NAME,'')+'  '+ISNULL(ccc.LAST_NAME,'')) " +
                           " AS APPLICANT_NAME, (ISNULL(ccc.RES_ADD_LINE_1,'')+'  '+ISNULL(ccc.RES_ADD_LINE_2,'')+'  '+ISNULL(ccc.RES_ADD_LINE_3,''))" +
                           " AS ADDRESS, CONVERT(CHAR(9), ccc.CASE_REC_DATETIME, 3) + LTRIM(SUBSTRING(CONVERT( VARCHAR(20), ccc.CASE_REC_DATETIME, 22), 10, 5) + RIGHT(CONVERT(VARCHAR(20)," +
                           " ccc.CASE_REC_DATETIME, 22), 3)) as REC_DATETIME , '+91'+v.MOBILE as MOBILE " +
                           " FROM CPV_KYC_CASE_DETAILS  as ccc " +
                           " inner join CPV_KYC_VERIFICATION_TYPE as cv on ccc.case_id=cv.case_id " +
                           " inner join CPV_KYC_FE_MAPPING as ccva on cv.CASE_ID=ccva.CASE_ID and cv.verification_type_id=ccva.verification_type_id " +
                           " inner join FE_VW1 as  v on v.emp_id = ccva.FE_ID inner join client_master cm on ccc.client_id = cm.client_id " +
                           " inner join verification_type_master vm on ccva.verification_type_id=vm.verification_type_id " +
                           " WHERE ccva.verification_type_id='" + VerificationId + "'and CCC.SEND_DATETIME IS NULL " +
                           " and cv.IS_SMS_SEND='N' and ccc.CASE_REC_DATETIME >= '" + FromDate + "' AND ccc.CASE_REC_DATETIME <  '" + ToDate + "' " +
                           " and  ccc.Centre_id = '" + strCentreId + "'   and  ccc.Client_id ='" + strClientId + " '";

                   }
                   else  //If other than supervisor
                   {
                       strSQL = "SELECT (''''+ ccc.case_id + '''' + ' ' + " + strSQL + " + ' ' +ISNULL('" + dsLabelQuery.Tables[0].Rows[1]["ADDITIONAL1"].ToString() + "','') + ' ' +ISNULL('" + dsLabelQuery.Tables[0].Rows[1]["ADDITIONAL2"].ToString() + "','')) AS SmsContent ," + " ccc.CASE_ID,ccc.REF_NO, v.FullName, " +
                           "(ISNULL(ccc.FIRST_NAME,'')+'  '+ISNULL(ccc.MIDDLE_NAME,'')+'  '+ISNULL(ccc.LAST_NAME,'')) " +
                           " AS APPLICANT_NAME, (ISNULL(ccc.RES_ADD_LINE_1,'')+'  '+ISNULL(ccc.RES_ADD_LINE_2,'')+'  '+ISNULL(ccc.RES_ADD_LINE_3,''))" +
                           " AS ADDRESS, CONVERT(CHAR(9), ccc.CASE_REC_DATETIME, 3) + LTRIM(SUBSTRING(CONVERT( VARCHAR(20), ccc.CASE_REC_DATETIME, 22), 10, 5) + RIGHT(CONVERT(VARCHAR(20)," +
                           " ccc.CASE_REC_DATETIME, 22), 3)) as REC_DATETIME , '+91'+v.MOBILE as MOBILE " +
                           " FROM CPV_KYC_CASE_DETAILS  as ccc " +
                           " inner join CPV_KYC_VERIFICATION_TYPE as cv on ccc.case_id=cv.case_id " +
                           " inner join CPV_KYC_FE_MAPPING as ccva on cv.CASE_ID=ccva.CASE_ID and cv.verification_type_id=ccva.verification_type_id " +
                           " inner join FE_VW1 as  v on v.emp_id = ccva.FE_ID inner join client_master cm on ccc.client_id = cm.client_id " +
                           " inner join verification_type_master vm on ccva.verification_type_id=vm.verification_type_id " +
                           " WHERE ccva.verification_type_id='" + VerificationId + "'and CCC.SEND_DATETIME IS NULL " +
                           " and ccc.CASE_REC_DATETIME >= '" + FromDate + "' AND ccc.CASE_REC_DATETIME <  '" + ToDate + "' " +
                           " and  ccc.Centre_id = '" + strCentreId + "'   and  ccc.Client_id ='" + strClientId + " '";
                   }
               }
               if (strTableName == "CPV_CC_CASE_DETAILS")
               {
                   if (sRoleId == "2") //if supervisor then ....
                   {
                       strSQL = "SELECT (''''+ ccc.case_id + '''' + ' ' + " + strSQL + " + ' ' +ISNULL('" + dsLabelQuery.Tables[0].Rows[1]["ADDITIONAL1"].ToString() + "','') + ' ' +ISNULL('" + dsLabelQuery.Tables[0].Rows[1]["ADDITIONAL2"].ToString() + "','')) AS SmsContent ," + " ccc.CASE_ID,ccc.REF_NO, v.FullName, " +
                           "(ISNULL(ccc.FIRST_NAME,'')+'  '+ISNULL(ccc.MIDDLE_NAME,'')+'  '+ISNULL(ccc.LAST_NAME,'')) " +
                           " AS APPLICANT_NAME, (ISNULL(ccc.RES_ADD_LINE_1,'')+'  '+ISNULL(ccc.RES_ADD_LINE_2,'')+'  '+ISNULL(ccc.RES_ADD_LINE_3,''))" +
                           " AS ADDRESS, CONVERT(CHAR(9), ccc.CASE_REC_DATETIME, 3) + LTRIM(SUBSTRING(CONVERT( VARCHAR(20), ccc.CASE_REC_DATETIME, 22), 10, 5) + RIGHT(CONVERT(VARCHAR(20)," +
                           " ccc.CASE_REC_DATETIME, 22), 3)) as REC_DATETIME , '+91'+v.MOBILE as MOBILE " +
                           " FROM CPV_CC_CASE_DETAILS  as ccc " +
                           " inner join CPV_CC_CASE_VERIFICATIONTYPE as cv on ccc.case_id=cv.case_id " +
                           " inner join CPV_CC_FE_CASE_MAPPING as ccva on cv.CASE_ID=ccva.CASE_ID and cv.verification_type_id=ccva.verification_type_id " +
                           " inner join FE_VW1 as  v on v.emp_id = ccva.FE_ID inner join client_master cm on ccc.client_id = cm.client_id " +
                           " inner join verification_type_master vm on ccva.verification_type_id=vm.verification_type_id " +
                           " WHERE ccva.verification_type_id='" + VerificationId + "'and CCC.SEND_DATETIME IS NULL " +
                           " and cv.IS_SMS_SEND='N' and ccc.CASE_REC_DATETIME >= '" + FromDate + "' AND ccc.CASE_REC_DATETIME <  '" + ToDate + "' " +
                           " and  ccc.Centre_id = '" + strCentreId + "'   and  ccc.Client_id ='" + strClientId + " '";

                   }
                   else  //If other than supervisor
                   {
                       strSQL = "SELECT (''''+ ccc.case_id + '''' + ' ' + " + strSQL + " + ' ' +ISNULL('" + dsLabelQuery.Tables[0].Rows[1]["ADDITIONAL1"].ToString() + "','') + ' ' +ISNULL('" + dsLabelQuery.Tables[0].Rows[1]["ADDITIONAL2"].ToString() + "','')) AS SmsContent ," + " ccc.CASE_ID,ccc.REF_NO, v.FullName, " +
                           "(ISNULL(ccc.FIRST_NAME,'')+'  '+ISNULL(ccc.MIDDLE_NAME,'')+'  '+ISNULL(ccc.LAST_NAME,'')) " +
                           " AS APPLICANT_NAME, (ISNULL(ccc.RES_ADD_LINE_1,'')+'  '+ISNULL(ccc.RES_ADD_LINE_2,'')+'  '+ISNULL(ccc.RES_ADD_LINE_3,''))" +
                           " AS ADDRESS, CONVERT(CHAR(9), ccc.CASE_REC_DATETIME, 3) + LTRIM(SUBSTRING(CONVERT( VARCHAR(20), ccc.CASE_REC_DATETIME, 22), 10, 5) + RIGHT(CONVERT(VARCHAR(20)," +
                           " ccc.CASE_REC_DATETIME, 22), 3)) as REC_DATETIME , '+91'+v.MOBILE as MOBILE " +
                           " FROM CPV_CC_CASE_DETAILS  as ccc " +
                           " inner join CPV_CC_CASE_VERIFICATIONTYPE as cv on ccc.case_id=cv.case_id " +
                           " inner join CPV_CC_FE_CASE_MAPPING as ccva on cv.CASE_ID=ccva.CASE_ID and cv.verification_type_id=ccva.verification_type_id " +
                           " inner join FE_VW1 as  v on v.emp_id = ccva.FE_ID inner join client_master cm on ccc.client_id = cm.client_id " +
                           " inner join verification_type_master vm on ccva.verification_type_id=vm.verification_type_id " +
                           " WHERE ccva.verification_type_id='" + VerificationId + "'and CCC.SEND_DATETIME IS NULL " +
                           " and ccc.CASE_REC_DATETIME >= '" + FromDate + "' AND ccc.CASE_REC_DATETIME <  '" + ToDate + "' " +
                           " and  ccc.Centre_id = '" + strCentreId + "'   and  ccc.Client_id ='" + strClientId + " '";
                   }
               }
               OleDbDataAdapter oledbDa = new OleDbDataAdapter(strSQL, conn);
               DataSet ds = new DataSet();
               oledbDa.Fill(ds, "Sms");
               dtselectedField = ds.Tables["Sms"];
              
           }
       }
       catch (Exception ex)
       {

           throw new Exception(ex.Message);
       }

       return dtselectedField;

    
   }


    public DataTable finalrecordCellular(string sRoleId,DateTime FromDate, DateTime ToDate, string strCentreId, string strClientId)
    {
        DataSet dsLabelQuery = new DataSet();
        DataTable dtselectedField = new DataTable();
        string strTableName = "";
        string strSQL = "";
        OleDbConnection conn = new OleDbConnection(Con.ConnectionString);
        conn.Open();
        dsLabelQuery = getTemplateForSmsCellular();
        try
        {
            if (dsLabelQuery.Tables[0].Rows.Count > 0)
            {


                for (int i = 0; i < dsLabelQuery.Tables[0].Rows.Count; i++)
                {
                    strTableName = dsLabelQuery.Tables[0].Rows[i]["TABLE_NAME"].ToString();




                    if (Convert.ToString(dsLabelQuery.Tables[0].Rows[i]["SELECTED_FIELD"]) == "CASE_TYPE_ID")
                    {
                        if (i == 0)
                        {
                            strSQL = strSQL + " CTM.CASE_TYPE_CODE ";
                        }
                       
                            // strSQL = strSQL + "+ ' ' +ISNULL(" +  dsLabelQuery.Tables[0].Rows[i]["SELECTED_FIELD"].ToString() + ",'') ";
                           
                      
                    }
                    else
                     {
                         if (Convert.ToString(dsLabelQuery.Tables[0].Rows[i]["SELECTED_FIELD"]) == "CASE_ID")
                         {

                             //strSQL = strSQL + " CCC.CLIENT_CODE ";

                         }
                         else
                         {

                             strSQL = strSQL + "+ ' ' +ISNULL(" + dsLabelQuery.Tables[0].Rows[i]["SELECTED_FIELD"].ToString() + ",'')";

                         }
                      }
                        //inner join client_master cm on ccc.client_id=cm.client_id}


                }
              
                    //strSQL = "SELECT " + strSQL + " AS SmsContent ," + " ccc.CASE_ID, ccc.CUSTOMER_CODE,v.FullName, (ISNULL(ccc.APP_FNAME,'')+'  '+ISNULL(ccc.APP_MNAME,'')+'  '+ISNULL(ccc.APP_LNAME,'')) AS APPLICANT_NAME," +
                    //"(ISNULL(ccc.APP_ADDR1,'')+'  '+ISNULL(ccc.APP_ADDR2,'')+'  '+ISNULL(ccc.APP_ADDR3,'')) AS ADDRESS," +
                    //"CONVERT(CHAR(9), ccc.CASE_REC_DATETIME, 3) + LTRIM(SUBSTRING(CONVERT( VARCHAR(20),ccc.CASE_REC_DATETIME, 22), 10, 5) + RIGHT(CONVERT(VARCHAR(20), ccc.CASE_REC_DATETIME, 22), 3)) as CASE_REC_DATETIME ," +
                    //"'+91'+v.MOBILE as MOBILE FROM " + strTableName + "  as ccc inner join CPV_CELLULAR_FE_CASE_MAPPING " +
                    //"as ccva on ccc.CASE_ID=ccva.CASE_ID inner join FE_VW1 as v on v.emp_id = ccva.FE_ID INNER JOIN CPV_CELLULAR_CASE_TYPE_MASTER CTM ON CCC.CASE_TYPE_ID=CTM.CASE_TYPE_ID  " +
                    //"WHERE   CCC.case_type_id='" + VerificationId + "' and CCC.SEND_DATETIME IS NULL AND   ccc.CASE_REC_DATETIME >= '" + FromDate + "' " +
                    //"AND ccc.CASE_REC_DATETIME <  '" + ToDate + "' and  ccc.Centre_id = '" + strCentreId + "' " +
                    //" and  ccc.Client_id ='" + strClientId + " ' AND ccc.SMS_DATE_TIME IS NULL ";
                //modified by hemangi kambli on 20-Nov-2007 ----
                if (sRoleId == "2") //if supervisor then ---
                {
                    strSQL = "SELECT (''''+ ccc.case_id + '''' + ' ' + " + strSQL + " + ' ' +ISNULL('" + dsLabelQuery.Tables[0].Rows[1]["ADDITIONAL1"].ToString() + "','') + ' ' +ISNULL('" + dsLabelQuery.Tables[0].Rows[1]["ADDITIONAL2"].ToString() + "','')) AS SmsContent ," + " ccc.CASE_ID, ccc.CUSTOMER_CODE,v.FullName, (ISNULL(ccc.APP_FNAME,'')+'  '+ISNULL(ccc.APP_MNAME,'')+'  '+ISNULL(ccc.APP_LNAME,'')) AS APPLICANT_NAME," +
                             " (ISNULL(ccc.APP_ADDR1,'')+'  '+ISNULL(ccc.APP_ADDR2,'')+'  '+ISNULL(ccc.APP_ADDR3,'')) AS ADDRESS," +
                             " CONVERT(CHAR(9), ccc.CASE_REC_DATETIME, 3) + LTRIM(SUBSTRING(CONVERT( VARCHAR(20),ccc.CASE_REC_DATETIME, 22), 10, 5) + RIGHT(CONVERT(VARCHAR(20), ccc.CASE_REC_DATETIME, 22), 3)) as CASE_REC_DATETIME ," +
                             " '+91'+v.MOBILE as MOBILE FROM " + strTableName + "  as ccc " +
                             " inner join CPV_CELLULAR_CASE_VERIFICATIONTYPE as cv on ccc.case_id=cv.case_id " +
                             " inner join CPV_CELLULAR_FE_CASE_MAPPING as ccva on ccc.CASE_ID=ccva.CASE_ID and cv.verification_type_id=ccva.verification_type_id" +
                             " inner join FE_VW1 as v on v.emp_id = ccva.FE_ID " +
                             " inner JOIN CPV_CELLULAR_CASE_TYPE_MASTER CTM ON CCC.CASE_TYPE_ID=CTM.CASE_TYPE_ID  " +
                             " WHERE CCC.case_type_id='" + VerificationId + "' and CCC.SEND_DATETIME IS NULL " +
                             " AND cv.IS_SMS_SEND='N' " + 
                             " AND ccc.CASE_REC_DATETIME >= '" + FromDate + "' " +
                             " AND ccc.CASE_REC_DATETIME <  '" + ToDate + "' and  ccc.Centre_id = '" + strCentreId + "' " +
                             " and ccc.Client_id ='" + strClientId + "'";
                }
                else
                {
                    strSQL = "SELECT (''''+ ccc.case_id + '''' + ' ' + " + strSQL + " + ' ' +ISNULL('" + dsLabelQuery.Tables[0].Rows[1]["ADDITIONAL1"].ToString() + "','') + ' ' +ISNULL('" + dsLabelQuery.Tables[0].Rows[1]["ADDITIONAL2"].ToString() + "','')) AS SmsContent ," + " ccc.CASE_ID, ccc.CUSTOMER_CODE,v.FullName, (ISNULL(ccc.APP_FNAME,'')+'  '+ISNULL(ccc.APP_MNAME,'')+'  '+ISNULL(ccc.APP_LNAME,'')) AS APPLICANT_NAME," +
                             " (ISNULL(ccc.APP_ADDR1,'')+'  '+ISNULL(ccc.APP_ADDR2,'')+'  '+ISNULL(ccc.APP_ADDR3,'')) AS ADDRESS," +
                             " CONVERT(CHAR(9), ccc.CASE_REC_DATETIME, 3) + LTRIM(SUBSTRING(CONVERT( VARCHAR(20),ccc.CASE_REC_DATETIME, 22), 10, 5) + RIGHT(CONVERT(VARCHAR(20), ccc.CASE_REC_DATETIME, 22), 3)) as CASE_REC_DATETIME ," +
                             " '+91'+v.MOBILE as MOBILE FROM " + strTableName + "  as ccc " +
                             " inner join CPV_CELLULAR_CASE_VERIFICATIONTYPE as cv on ccc.case_id=cv.case_id " +
                             " inner join CPV_CELLULAR_FE_CASE_MAPPING as ccva on ccc.CASE_ID=ccva.CASE_ID and cv.verification_type_id=ccva.verification_type_id" +
                             " inner join FE_VW1 as v on v.emp_id = ccva.FE_ID " +
                             " inner JOIN CPV_CELLULAR_CASE_TYPE_MASTER CTM ON CCC.CASE_TYPE_ID=CTM.CASE_TYPE_ID  " +
                             " WHERE CCC.case_type_id='" + VerificationId + "' and CCC.SEND_DATETIME IS NULL " +
                             " AND ccc.CASE_REC_DATETIME >= '" + FromDate + "' " +
                             " AND ccc.CASE_REC_DATETIME <  '" + ToDate + "' and  ccc.Centre_id = '" + strCentreId + "' " +
                             " and ccc.Client_id ='" + strClientId + "'";
                }

                OleDbDataAdapter oledbDa = new OleDbDataAdapter(strSQL, conn);
                DataSet ds = new DataSet();
                oledbDa.Fill(ds, "Sms");
                dtselectedField = ds.Tables["Sms"];

            }
        }
        catch (Exception ex)
        {

            throw new Exception(ex.Message);
        }

        return dtselectedField;


    }




    public GridView ExportToExcelCellular(DateTime FromDate, DateTime ToDate, string strCentreId, string strClientId)
    {
        GridView gvExcelQuery = new GridView();      
        string strSQL = "";
        OleDbConnection conn = new OleDbConnection(Con.ConnectionString);
        conn.Open();
      
        try
        {

            strSQL = "SELECT distinct v.FullName AS VERIFIER_NAME,v.MOBILE AS VERIFIER_CELL_NO,CCC.SMS_DATE_TIME,CCC.SMS_CONTENT   FROM CPV_CELLULAR_CASES  as ccc " +
                "inner join CPV_CELLULAR_FE_CASE_MAPPING as ccva on ccc.CASE_ID=ccva.CASE_ID inner join " +
                "FE_VW1 as v on v.emp_id = ccva.FE_ID INNER JOIN CPV_CELLULAR_CASE_TYPE_MASTER CTM ON " +
                "CCC.CASE_TYPE_ID=CTM.CASE_TYPE_ID  WHERE " +
               "  ccc.SMS_DATE_TIME >= '" + FromDate + "' AND ccc.SMS_DATE_TIME <  '" + ToDate + "'" +
               " and  ccc.Centre_id = '" + strCentreId + "'  and  ccc.Client_id ='" + strClientId + " '";
              
            OleDbDataAdapter oledbDa = new OleDbDataAdapter(strSQL, conn);
                DataSet ds = new DataSet();
                oledbDa.Fill(ds, "Sms");               
                gvExcelQuery.DataSource = ds.Tables["Sms"];
                gvExcelQuery.DataBind();

         }
       
        catch (Exception ex)
        {

            throw new Exception(ex.Message);
        }

        return gvExcelQuery;


    }



    public GridView ExportToExcelRL(DateTime FromDate, DateTime ToDate, string strCentreId, string strClientId)
    {
        GridView gvExcelQuery = new GridView();
        string strSQL = "";
        OleDbConnection conn = new OleDbConnection(Con.ConnectionString);
        conn.Open();

        try
        {

            strSQL = "SELECT distinct v.FullName AS VERIFIER_NAME,v.MOBILE AS VERIFIER_CELL_NO,CCC.Channel_Name,CCC.SMS_DATE_TIME,CCC.SMS_CONTENT   FROM CPV_RL_CASE_DETAILS  as ccc " +
                "inner join CPV_RL_CASE_FE_MAPPING as ccva on ccc.CASE_ID=ccva.CASE_ID inner join " +
                "FE_VW1 as v on v.emp_id = ccva.FE_ID INNER JOIN VERIFICATION_TYPE_MASTER CTM ON " +
                "ccva.VERIFICATION_TYPE_ID=CTM.VERIFICATION_TYPE_ID  WHERE " +
               " ccc.SMS_DATE_TIME >= '" + FromDate + "' AND ccc.SMS_DATE_TIME <  '" + ToDate + "'" +             
               
               " and  ccc.Centre_id = '" + strCentreId + "'  and  ccc.Client_id ='" + strClientId + " '";

            OleDbDataAdapter oledbDa = new OleDbDataAdapter(strSQL, conn);
            DataSet ds = new DataSet();
            oledbDa.Fill(ds, "Sms");
            gvExcelQuery.DataSource = ds.Tables["Sms"];
            gvExcelQuery.DataBind();

        }

        catch (Exception ex)
        {

            throw new Exception(ex.Message);
        }

        return gvExcelQuery;


    }


    public GridView ExportToExcelCC(DateTime FromDate, DateTime ToDate, string strCentreId, string strClientId)
    {
        GridView gvExcelQuery = new GridView();
        string strSQL = "";
        OleDbConnection conn = new OleDbConnection(Con.ConnectionString);
        conn.Open();

        try
        {

            strSQL = "SELECT distinct v.FullName AS VERIFIER_NAME,v.MOBILE AS VERIFIER_CELL_NO,CCC.SMS_DATE_TIME,CCC.SMS_CONTENT   FROM CPV_CC_CASE_DETAILS  as ccc  " +
                "inner join CPV_CC_FE_CASE_MAPPING as ccva on ccc.CASE_ID=ccva.CASE_ID inner join " +
                "FE_VW1 as v on v.emp_id = ccva.FE_ID INNER JOIN VERIFICATION_TYPE_MASTER CTM ON " +
                "ccva.VERIFICATION_TYPE_ID=CTM.VERIFICATION_TYPE_ID  WHERE " +
               " ccc.SMS_DATE_TIME >= '" + FromDate + "' AND ccc.SMS_DATE_TIME <  '" + ToDate + "'" +

               " and  ccc.Centre_id = '" + strCentreId + "'  and  ccc.Client_id ='" + strClientId + " '";

            OleDbDataAdapter oledbDa = new OleDbDataAdapter(strSQL, conn);
            DataSet ds = new DataSet();
            oledbDa.Fill(ds, "Sms");
            gvExcelQuery.DataSource = ds.Tables["Sms"];
            gvExcelQuery.DataBind();

        }

        catch (Exception ex)
        {

            throw new Exception(ex.Message);
        }

        return gvExcelQuery;


    }


    public GridView ExportToExcelKYC(DateTime FromDate, DateTime ToDate, string strCentreId, string strClientId)
    {
        GridView gvExcelQuery = new GridView();
        string strSQL = "";
        OleDbConnection conn = new OleDbConnection(Con.ConnectionString);
        conn.Open();

        try
        {

            strSQL = "SELECT distinct v.FullName AS VERIFIER_NAME,v.MOBILE AS VERIFIER_CELL_NO,CCC.SMS_DATE_TIME,CCC.SMS_CONTENT   FROM CPV_KYC_CASE_DETAILS  as ccc  " +
                "inner join CPV_KYC_FE_MAPPING as ccva on ccc.CASE_ID=ccva.CASE_ID inner join " +
                "FE_VW1 as v on v.emp_id = ccva.FE_ID INNER JOIN VERIFICATION_TYPE_MASTER CTM ON " +
                "ccva.VERIFICATION_TYPE_ID=CTM.VERIFICATION_TYPE_ID  WHERE " +
               " ccc.SMS_DATE_TIME >= '" + FromDate + "' AND ccc.SMS_DATE_TIME <  '" + ToDate + "'" +

               " and  ccc.Centre_id = '" + strCentreId + "'  and  ccc.Client_id ='" + strClientId + " '";

            OleDbDataAdapter oledbDa = new OleDbDataAdapter(strSQL, conn);
            DataSet ds = new DataSet();
            oledbDa.Fill(ds, "Sms");
            gvExcelQuery.DataSource = ds.Tables["Sms"];
            gvExcelQuery.DataBind();

        }

        catch (Exception ex)
        {

            throw new Exception(ex.Message);
        }

        return gvExcelQuery;


    }


    public GridView ExportToExcelEBC(DateTime FromDate, DateTime ToDate, string strCentreId, string strClientId)
    {
        GridView gvExcelQuery = new GridView();
        string strSQL = "";
        OleDbConnection conn = new OleDbConnection(Con.ConnectionString);
        conn.Open();

        try
        {

            strSQL = "SELECT distinct v.FullName AS VERIFIER_NAME,v.MOBILE AS VERIFIER_CELL_NO,CCC.SMS_DATE_TIME,CCC.SMS_CONTENT   FROM CPV_EBC_CASE_DETAILS  as ccc  " +
                "inner join CPV_EBC_FE_MAPPING as ccva on ccc.CASE_ID=ccva.CASE_ID inner join " +
                "FE_VW1 as v on v.emp_id = ccva.FE_ID INNER JOIN VERIFICATION_TYPE_MASTER CTM ON " +
                "ccva.VERIFICATION_TYPE_ID=CTM.VERIFICATION_TYPE_ID  WHERE " +
               " ccc.SMS_DATE_TIME >= '" + FromDate + "' AND ccc.SMS_DATE_TIME <  '" + ToDate + "'" +

               " and  ccc.Centre_id = '" + strCentreId + "'  and  ccc.Client_id ='" + strClientId + " '";

            OleDbDataAdapter oledbDa = new OleDbDataAdapter(strSQL, conn);
            DataSet ds = new DataSet();
            oledbDa.Fill(ds, "Sms");
            gvExcelQuery.DataSource = ds.Tables["Sms"];
            gvExcelQuery.DataBind();

        }

        catch (Exception ex)
        {

            throw new Exception(ex.Message);
        }

        return gvExcelQuery;


    }

    public GridView ExportToExcelIDOC(DateTime FromDate, DateTime ToDate, string strCentreId, string strClientId)
    {
        GridView gvExcelQuery = new GridView();
        string strSQL = "";
        OleDbConnection conn = new OleDbConnection(Con.ConnectionString);
        conn.Open();

        try
        {

            strSQL = "SELECT distinct v.FullName AS VERIFIER_NAME,v.MOBILE AS VERIFIER_CELL_NO,CCC.SMS_DATE_TIME,CCC.SMS_CONTENT   FROM CPV_IDOC_CASE_DETAILS  as ccc  " +
                "inner join CPV_IDOC_FE_CASE_MAPPING as ccva on ccc.CASE_ID=ccva.CASE_ID inner join " +
                "FE_VW1 as v on v.emp_id = ccva.FE_ID INNER JOIN VERIFICATION_TYPE_MASTER CTM ON " +
                "ccva.VERIFICATION_TYPE_ID=CTM.VERIFICATION_TYPE_ID  WHERE " +
               " ccc.SMS_DATE_TIME >= '" + FromDate + "' AND ccc.SMS_DATE_TIME <  '" + ToDate + "'" +

               " and  ccc.Centre_id = '" + strCentreId + "'  and  ccc.Client_id ='" + strClientId + " '";

            OleDbDataAdapter oledbDa = new OleDbDataAdapter(strSQL, conn);
            DataSet ds = new DataSet();
            oledbDa.Fill(ds, "Sms");
            gvExcelQuery.DataSource = ds.Tables["Sms"];
            gvExcelQuery.DataBind();

        }

        catch (Exception ex)
        {

            throw new Exception(ex.Message);
        }

        return gvExcelQuery;


    }

    public string insertGridFields(string sRoleId)
    {
        OleDbConnection conn = new OleDbConnection(Con.ConnectionString);
        conn.Open();
        OleDbTransaction oledbTrans = conn.BeginTransaction();
        CSendSMS objSendSMS = new CSendSMS();
        string sql = "";
        string msg = "";
        string strSMSSend = "";
        try
        {

            sql = "";
            sql = "UPDATE  CPV_CELLULAR_CASES SET SMS_DATE_TIME=?,VERIFIER_MOBILE_NO=?, " +
                  "SMS_CONTENT=?  WHERE CASE_ID=?";
            OleDbParameter[] paramGrid = new OleDbParameter[4];
            paramGrid[0] = new OleDbParameter("@SMS_DATE_TIME", OleDbType.Date);
            paramGrid[0].Value = Sms_Date_Time;
            paramGrid[1] = new OleDbParameter("@VERIFIER_MOBILE_NO", OleDbType.VarChar);
            paramGrid[1].Value = Mobile;
            paramGrid[2] = new OleDbParameter("@SMS_CONTENT", OleDbType.VarChar);
            paramGrid[2].Value = Sms;
            paramGrid[3] = new OleDbParameter("@CASE_ID", OleDbType.VarChar);
            paramGrid[3].Value = CaseId;
            OleDbHelper.ExecuteNonQuery(oledbTrans, CommandType.Text, sql, paramGrid);

            //added by hemangi kambli on 15-Nov-2007 for sending SMS ----------
            //added by hemangi kambli on 14-Nov-2007 for sending SMS ----------
            if (sRoleId == "2") //If supervisor then ...
            {
                sql = "update CPV_CELLULAR_CASE_VERIFICATIONTYPE set " +
                      "IS_SMS_SEND ='Y' where IS_SMS_SEND = 'N' " +
                      " and case_id=? and VERIFICATION_TYPE_ID=?";

                OleDbParameter[] paramIsSMSSend = new OleDbParameter[2];
                paramIsSMSSend[0] = new OleDbParameter("@CaseId", OleDbType.VarChar);
                paramIsSMSSend[0].Value = CaseId;
                paramIsSMSSend[1] = new OleDbParameter("@VerificationId", OleDbType.VarChar);
                paramIsSMSSend[1].Value = VerificationId;

                OleDbHelper.ExecuteNonQuery(oledbTrans, CommandType.Text, sql, paramIsSMSSend);
            }
            
            strSMSSend = objSendSMS.funSendSMS(Sms, Mobile);
            //-----------------------------------------------------------------
            oledbTrans.Commit();
            msg = strSMSSend + " SMS Send Successfully.";
            conn.Close();

        }
        catch (Exception ex)
        {
            oledbTrans.Rollback();
            msg = "SMS Not Send: " + strSMSSend + " : " + ex.Message;
            conn.Close();
            throw new Exception("Error While Sending " + ex.Message);
        }
        return msg;
    }
   public string insertGridFieldsRL(string sRoleId ,string sDetailTable,string sVeriTable)
    {
        OleDbConnection conn = new OleDbConnection(Con.ConnectionString);
        conn.Open();
        OleDbTransaction oledbTrans = conn.BeginTransaction();
        CSendSMS objSendSMS = new CSendSMS();
        string sql = "";
        string msgBox = "";
        try
        {

            sql = "";

            sql = "UPDATE  " + sDetailTable + " SET SMS_DATE_TIME=?,MOBILE=?, " +
                  "SMS_CONTENT=?  WHERE CASE_ID=?";
            OleDbParameter[] paramGrid = new OleDbParameter[4];
            paramGrid[0] = new OleDbParameter("@SMS_DATE_TIME", OleDbType.Date);
            paramGrid[0].Value = Sms_Date_Time;
            paramGrid[1] = new OleDbParameter("@MOBILE", OleDbType.VarChar, 100);
            paramGrid[1].Value = Mobile;
            paramGrid[2] = new OleDbParameter("@SMS_CONTENT", OleDbType.VarChar, 480);
            paramGrid[2].Value = Sms;
            paramGrid[3] = new OleDbParameter("@CASE_ID", OleDbType.VarChar);
            paramGrid[3].Value = CaseId;
            OleDbHelper.ExecuteNonQuery(oledbTrans, CommandType.Text, sql, paramGrid);

            //added by hemangi kambli on 14-Nov-2007 for sending SMS ----------
            if (sRoleId == "2") //If supervisor then ...
            {
                sql = "update " + sVeriTable + " set " +
                      "IS_SMS_SEND ='Y' where IS_SMS_SEND = 'N' " +
                      " and case_id=? and VERIFICATION_TYPE_ID=?";

                OleDbParameter[] paramIsSMSSend = new OleDbParameter[2];
                paramIsSMSSend[0] = new OleDbParameter("@CaseId", OleDbType.VarChar);
                paramIsSMSSend[0].Value = CaseId;
                paramIsSMSSend[1] = new OleDbParameter("@VerificationId", OleDbType.VarChar);
                paramIsSMSSend[1].Value = VerificationId;

                OleDbHelper.ExecuteNonQuery(oledbTrans, CommandType.Text, sql, paramIsSMSSend);
            }
            ///--------------------------
            string strSMSSend = "";
            //strSMSSend = objSendSMS.funSendSMS(Sms, Mobile);

            int iLength = Sms.Length;
            if (iLength > 160)
            {                   
                int iStartIndex=0;
                string sSms ="";
                int iEndIndex = iLength; 
                //considering 480 characters means 3 Messages......(160 characters = 1 SMS)
                while (iStartIndex < 480)   //If SMS Content having characters greater than 160.
                {
                    if (iLength >= iStartIndex)
                    {
                        if (iEndIndex >= 160)   //For 160 Characters....
                        {
                            sSms = Sms.Substring(iStartIndex, 160);
                            if (sSms != "")
                            {
                                strSMSSend = objSendSMS.funSendSMS(sSms, Mobile);
                                iStartIndex += 160;
                                iEndIndex = iEndIndex - 160;
                            }
                        }
                        else    //If SMS content is less than 320 characters....
                        {
                            sSms = Sms.Substring(iStartIndex, iEndIndex);
                            if (sSms != "")
                            {
                                strSMSSend = objSendSMS.funSendSMS(sSms, Mobile);
                                iStartIndex += 160;
                            }
                        }
                    }   //If 2 SMS then break the loop...
                    else
                    {
                        break;
                    }
                }

            }
            else
            {
                strSMSSend = objSendSMS.funSendSMS(Sms, Mobile);
            }
            //-----------------------------------------------------------------
            oledbTrans.Commit();
            msgBox = strSMSSend + " SMS Send Successfully.";
            conn.Close();
        }
        catch (Exception ex)
        {
            oledbTrans.Rollback();
            conn.Close();
            throw new Exception("Error While Sending SMS: " + ex.Message);
        }
        return msgBox;
    }


   
    



    
   
    



}
