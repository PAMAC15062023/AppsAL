using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

/// <summary>
/// Summary description for EBC_CDedupSearch
/// </summary>
public class EBC_CDedupSearch
{
    private string strFirstName;
    private string strMiddileName;
    private string strLastName;
    private string strAdd1;
    private string strAdd2;
    private string strAdd3;
   
    private string strDOB;
    private string strPinCode;
    private string strCity;
    private string strTel1;
    private string strTel2;
   
   private string strLocation;

    public string FirstName
    {
        get { return strFirstName; }
        set { strFirstName = value; }
    }
    public string MiddleName
    {
        get { return strMiddileName; }
        set { strMiddileName = value; }
    }
    public string LastName
    {
        get { return strLastName; }
        set { strLastName = value; }
    }
    public string Add1
    {
        get { return strAdd1; }
        set { strAdd1 = value; }
    }
    public string Add2
    {
        get { return strAdd2; }
        set { strAdd2 = value; }
    }
    public string Add3
    {
        get { return strAdd3; }
        set { strAdd3 = value; }
    }
   
    public string DOB
    {
        get { return strDOB; }
        set { strDOB = value; }
    }
    public string PinCode
    {
        get { return strPinCode; }
        set { strPinCode = value; }
    }
   
    public string City
    {
        get { return strCity; }
        set { strCity = value; }
    }
   
    public string Tel1
    {
        get { return strTel1; }
        set { strTel1 = value; }
    }
    public string Tel2
    {
        get { return strTel2; }
        set { strTel2 = value; }
    }
    public string Location
    {
        get { return strLocation; }
        set { strLocation = value; }
    }

    CCommon con = new CCommon();
	public EBC_CDedupSearch()
	{
		
	}
    public DataSet GetAllRecordByBatchID(string strDate, string strTime, string strTimeType, string strClusterID, string strCentreID, string strClientID)
    {
        string strSql = "";
        string strDateCriteria = "";
        if (strDate != "" && strTime != "")
        {
            strDateCriteria = " CASE_REC_DATETIME= '" + Convert.ToDateTime(strDate + ' ' + strTime + ' ' + strTimeType) + "' ";


        }
        else
        {
            strDateCriteria = "CASE_REC_DATETIME >= '" + Convert.ToDateTime(strDate) + "' and CASE_REC_DATETIME <'" + Convert.ToDateTime(strDate).AddDays(1.0) + "' ";
        }
        strSql = " Select case_id,ref_no,CASE_REC_DATETIME,FIRST_NAME,MIDDLE_NAME,LAST_NAME,ADD_LINE_1,ADD_LINE_2,ADD_LINE_3,CITY,PIN_CODE,LOCATION,PHONE1,PHONE2," +
                 " DOB from CPV_EBC_CASE_DETAILS where " + strDateCriteria + "  " +
                 " and Cluster_id='" + strClusterID + "' and Centre_id='" + strCentreID + "' and Client_id='" + strClientID + "'  ";
        return OleDbHelper.ExecuteDataset(con.ConnectionString, CommandType.Text, strSql);

    }
    public DataSet GetRecordsPerCase(string strDate, string strTime, string strTimeType, string strClusterID, string strCentreID, string strClientID)
    {
        string strSql = "";

        // Code for Criteria Name
        string strDateCriteria = "";
        if (strDate != "" && strTime != "")
        {
            strDateCriteria = " CASE_REC_DATETIME= '" + Convert.ToDateTime(strDate + ' ' + strTime + ' ' + strTimeType) + "' ";
        }
        else
        {
            //strDateCriteria = " CASE_REC_DATETIME <= '" + Convert.ToDateTime(strDate) + "' and CASE_REC_DATETIME > '" + Convert.ToDateTime(strDate).AddDays(1.0) + "' ";

            strDateCriteria = "CASE_REC_DATETIME  not between '" + Convert.ToDateTime(strDate) + "' and '" + Convert.ToDateTime(strDate).AddDays(1.0) + "'  ";

        }
        string strNameCrieteria = "";

        if (FirstName != "")
        {
            strNameCrieteria += " or soundex(FIRST_NAME)= soundex('" + FirstName + "') or First_name like'%" + FirstName + "%'  ";
            strNameCrieteria += " or soundex(MIDDLE_NAME)= soundex('" + FirstName + "') or MIDDLE_NAME like'%" + FirstName + "%'  ";
            strNameCrieteria += " or soundex(Last_name)= soundex('" + FirstName + "') or Last_name like'%" + FirstName + "%'  ";
        }


        if (LastName != "")
        {
            strNameCrieteria += " or soundex(FIRST_NAME)= soundex('" + LastName + "') or First_name like'%" + LastName + "%'  ";
            strNameCrieteria += " or soundex(MIDDLE_NAME)= soundex('" + LastName + "') or MIDDLE_NAME like'%" + LastName + "%'  ";
            strNameCrieteria += " or soundex(Last_name)= soundex('" + LastName + "') or Last_name like'%" + LastName + "%'  ";
        }
        if (MiddleName != "")
        {
            strNameCrieteria += " or soundex(FIRST_NAME)= soundex('" + MiddleName + "') or First_name like'%" + MiddleName + "%'  ";
            strNameCrieteria += " or soundex(MIDDLE_NAME)= soundex('" + MiddleName + "') or MIDDLE_NAME like'%" + MiddleName + "%'  ";
            strNameCrieteria += " or soundex(Last_name)= soundex('" + MiddleName + "') or Last_name like'%" + MiddleName + "%'  ";
        }

        // Code for Criteria ResiAddress
        string strResiCriteria = "";


        if (Add1 != "")
        {
            strResiCriteria += " or ADD_LINE_1 like'%" + Add1 + "%'  ";
            strResiCriteria += " or ADD_LINE_1 like'%" + Add2 + "%' or ADD_LINE_1 like'%" + Add3 + "%' ";
        }

        if (Add3 != "")
        {
            strResiCriteria += " or ADD_LINE_3 like'%" + Add3 + "%'  ";
            strResiCriteria += " or ADD_LINE_3 like'%" + Add2 + "%' or ADD_LINE_3 like'%" + Add3 + "%' ";
        }
        if (Add2 != "")
        {
            strResiCriteria += " or ADD_LINE_2 like'%" + Add2 + "%'  ";
            strResiCriteria += " or ADD_LINE_2 like'%" + Add2 + "%' or ADD_LINE_2 like'%" + Add3 + "%' ";
        }
        
             

        string strCriteria = "";
        if (City != "")
        {
            strCriteria += " and CITY='" + City + "'";
        }
        if (PinCode != "")
        {
            strCriteria += " and PIN_CODE='" + PinCode + "' ";
        }
        if (Tel1 != "")
        {
            strCriteria += " and PHONE1='" + Tel1 + "' ";
        }


        if (Tel2 != "")
        {
            strCriteria = " and PHONE2='" + Tel2 + "' ";
        }

        if (DOB != "")
        {
            strCriteria += " and DOB='" + DOB + "' ";
        }
        strSql = "  select cd.case_id as CaseID,REF_NO as [Ref No],CASE_REC_DATETIME as [Rec Date],(ISNULL(FIRST_NAME + ' ', '') +ISNULL(MIDDLE_NAME + ' ', '') + ISNULL(LAST_NAME + ' ', '')) as Name , " +
                  " (ISNULL(ADD_LINE_1+' ','') + ISNULL(ADD_LINE_2+' ','') + ISNULL(ADD_LINE_3+' ','')) AS [Resident Address], " +
                  " CITY as [City],PIN_CODE as [Pin Code], " +
                  " LOCATION as [Location],PHONE1 as [Phone1], " +
                  " PHONE2 as [Phone2],DOB, "+
                  "  dbo.GetStatus_Name(PV.VERIFICATION_TYPE_ID)  AS [PV STATUS],   " +
                  "  dbo.GetStatus_Name(RV.VERIFICATION_TYPE_ID)  AS [RV STATUS],   " +
                  "  dbo.GetStatus_Name(DGV.VERIFICATION_TYPE_ID)  AS [DGV STATUS], " +
                  "  dbo.GetStatus_Name(GV.VERIFICATION_TYPE_ID)  AS [GV STATUS],   " +
                  "  dbo.GetStatus_Name(EV.VERIFICATION_TYPE_ID)  AS [EV STATUS]   " +
                  " from CPV_EBC_CASE_DETAILS CD " +
                  " LEFT OUTER JOIN CPV_EBC_VERIFICATION PV  ON PV.CASE_ID=CD.CASE_ID AND PV.VERIFICATION_TYPE_ID = '15' " +
                  " LEFT OUTER JOIN CPV_EBC_VERIFICATION RV  ON RV.CASE_ID=CD.CASE_ID AND RV.VERIFICATION_TYPE_ID = '1' " +
                  " LEFT OUTER JOIN CPV_EBC_VERIFICATION DGV  ON DGV.CASE_ID=CD.CASE_ID AND DGV.VERIFICATION_TYPE_ID = '16' " +
                  " LEFT OUTER JOIN CPV_EBC_VERIFICATION GV  ON GV.CASE_ID=CD.CASE_ID AND GV.VERIFICATION_TYPE_ID = '17' " +
                  " LEFT OUTER JOIN CPV_EBC_VERIFICATION EV ON EV.CASE_ID=CD.CASE_ID AND EV.VERIFICATION_TYPE_ID = '18' " +
                  " where  ( 1=1 " + strNameCrieteria + "  ) and   " +
                  " 1=1 and( 1=1 " + strResiCriteria + "  )  and 1=1  " +
                  " " + strCriteria + " and Cluster_id=" + strClusterID + " " +
                  " and Centre_id=" + strCentreID + " and Client_id=" + strClientID + " and " + strDateCriteria + " ";
        return OleDbHelper.ExecuteDataset(con.ConnectionString, CommandType.Text, strSql);


    }
}
