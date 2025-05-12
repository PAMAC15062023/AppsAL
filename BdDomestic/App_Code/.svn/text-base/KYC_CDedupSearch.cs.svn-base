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
using System.IO;
using System.Collections;
/// <summary>
/// Summary description for KYC_CDedupSearch
/// </summary>
public class KYC_CDedupSearch
{
    private string strFirstName;
    private string strMiddileName;
    private string strLastName;
    private string strResiAdd1;
    private string strResiAdd2;
    private string strResiAdd3;
    private string strOffAdd1;
    private string strOffAdd2;
    private string strOffAdd3;
    private string strDOB;
    private string strResiPinCode;
    private string strResiCity;
    private string strResiTel;
    private string strOffTelNo;
    private string strOffCity;
    private string strResiLanMark;

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
    public string ResiAdd1
    {
        get { return strResiAdd1; }
        set { strResiAdd1 = value; }
    }
    public string ResiAdd2
    {
        get { return strResiAdd2; }
        set { strResiAdd2 = value; }
    }
    public string ResiAdd3
    {
        get { return strResiAdd3; }
        set { strResiAdd3 = value; }
    }
    public string OffAdd1
    {
        get { return strOffAdd1; }
        set { strOffAdd1 = value; }
    }
    public string OffAdd2
    {
        get { return strOffAdd2; }
        set { strOffAdd2 = value; }
    }
    public string OffAdd3
    {
        get { return strOffAdd3; }
        set { strOffAdd3 = value; }
    }
    public string DOB
    {
        get { return strDOB; }
        set { strDOB = value; }
    }
    public string ResiPinCode
    {
        get { return strResiPinCode; }
        set { strResiPinCode = value; }
    }
    private string strOffPinCode;
    public string OffPinCode
    {
        get { return strOffPinCode; }
        set { strOffPinCode = value; }
    }
    public string ResiCity
    {
        get { return strResiCity; }
        set { strResiCity = value; }
    }
    public string OffCity
    {
        get { return strOffCity; }
        set { strOffCity = value; }
    }
    public string ResiTel
    {
        get { return strResiTel; }
        set { strResiTel = value; }
    }
    public string OffTel
    {
        get { return strOffTelNo; }
        set { strOffTelNo = value; }
    }
    public string ResiLandMark
    {
        get { return strResiLanMark; }
        set { strResiLanMark = value; }
    }

    CCommon con = new CCommon();
	public KYC_CDedupSearch()
	{
		//
		// TODO: Add constructor logic here
		//
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
        strSql = "Select case_id,ref_no,CASE_REC_DATETIME,FIRST_NAME,MIDDLE_NAME,LAST_NAME,RES_ADD_LINE_1,RES_ADD_LINE_2,RES_ADD_LINE_3,RES_CITY,RES_PIN_CODE," +
                 "RES_LAND_MARK,RES_PHONE,OFF_NAME,OFF_ADD_LINE_1,OFF_ADD_LINE_2,OFF_ADD_LINE_3, " +
                 "OFF_CITY,OFF_PIN_CODE,OFF_PHONE,DOB from CPV_KYC_CASE_DETAILS where " + strDateCriteria + "  " +
                 "and Cluster_id='" + strClusterID + "' and Centre_id='" + strCentreID + "' and Client_id='" + strClientID + "' ";
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


        if (ResiAdd1 != "")
        {
            strResiCriteria += " or RES_ADD_LINE_1 like'%" + ResiAdd1 + "%'  ";
            strResiCriteria += " or RES_ADD_LINE_1 like'%" + ResiAdd2 + "%' or RES_ADD_LINE_1 like'%" + ResiAdd3 + "%' ";
        }

        if (ResiAdd3 != "")
        {
            strResiCriteria += " or RES_ADD_LINE_3 like'%" + ResiAdd3 + "%'  ";
            strResiCriteria += " or RES_ADD_LINE_3 like'%" + ResiAdd2 + "%' or RES_ADD_LINE_3 like'%" + ResiAdd3 + "%' ";
        }
        if (ResiAdd2 != "")
        {
            strResiCriteria += " or RES_ADD_LINE_2 like'%" + ResiAdd2 + "%'  ";
            strResiCriteria += " or RES_ADD_LINE_2 like'%" + ResiAdd2 + "%' or RES_ADD_LINE_2 like'%" + ResiAdd3 + "%' ";
        }
        if (ResiLandMark != "")
        {
            strResiCriteria += " or  RES_LAND_MARK like'%" + ResiLandMark + " %'";
        }
        //Code for Office Address

        string strOfiiceCriteria = "";

        if (OffAdd1 != "")
        {
            strOfiiceCriteria += " or OFF_ADD_LINE_1 like'%" + OffAdd1 + "%'  ";
            strOfiiceCriteria += " or OFF_ADD_LINE_1 like'%" + OffAdd2 + "%' or OFF_ADD_LINE_1 like'%" + OffAdd3 + "%' ";
        }

        if (OffAdd3 != "")
        {
            strOfiiceCriteria += " or OFF_ADD_LINE_3 like'%" + OffAdd3 + "%' ";
            strOfiiceCriteria += " or OFF_ADD_LINE_3 like'%" + OffAdd2 + "%' or OFF_ADD_LINE_3 like'%" + OffAdd3 + "%' ";
        }
        if (OffAdd2 != "")
        {
            strOfiiceCriteria += " or OFF_ADD_LINE_2 like'%" + OffAdd2 + "%' ";
            strOfiiceCriteria += " or OFF_ADD_LINE_2 like'%" + OffAdd2 + "%' or OFF_ADD_LINE_2 like'%" + OffAdd3 + "%' ";
        }


        string strCriteria = "";
        if (ResiCity != "")
        {
            strCriteria += " and RES_CITY='" + ResiCity + "'";
        }
        if (ResiPinCode != "")
        {
            strCriteria += " and RES_PIN_CODE='" + ResiPinCode + "' ";
        }
        if (ResiTel != "")
        {
            strCriteria += " and RES_PHONE='" + ResiTel + "' ";
        }

        if (OffCity != "")
        {
            strCriteria = " and OFF_CITY='" + OffCity + "' ";
        }
        if (OffPinCode != "")
        {
            strCriteria += " and OFF_PIN_CODE='" + OffPinCode + "' ";
        }
        if (OffTel != "")
        {
            strCriteria = " and OFF_PHONE='" + OffTel + "' ";
        }

        if (DOB != "")
        {
            strCriteria += " and DOB='" + DOB + "' ";
        }
        strSql =  "  select cd.case_id as CaseID,REF_NO as [Ref No],CASE_REC_DATETIME as [Rec Date],(ISNULL(FIRST_NAME + ' ', '') +ISNULL(MIDDLE_NAME + ' ', '') + ISNULL(LAST_NAME + ' ', '')) as Name , " +
                  " (ISNULL(RES_ADD_LINE_1+' ','') + ISNULL(RES_ADD_LINE_2+' ','') + ISNULL(RES_ADD_LINE_3+' ','')) AS [Resident Address],RES_CITY as [Resi City],RES_PIN_CODE as [Resi Pin Code], " +
                
                  " RES_LAND_MARK as [Resi Land Mark],RES_PHONE as [Resi Tel],OFF_NAME as [Off Name], " +
                  " (ISNULL(OFF_ADD_LINE_1+' ','') + ISNULL(OFF_ADD_LINE_2+' ','') + ISNULL(OFF_ADD_LINE_3+' ','')) AS [Office Address],OFF_CITY as [Off City], " +
                  " OFF_PIN_CODE as [Off Pin Code],OFF_PHONE as [Off Tel],DOB, " +
                  "  dbo.GetStatus_Name(BV.VERIFICATION_TYPE_ID)  AS [BV STATUS],   " +
                  "  dbo.GetStatus_Name(RV.VERIFICATION_TYPE_ID)  AS [RV STATUS],   " +
                  "  dbo.GetStatus_Name(CA.VERIFICATION_TYPE_ID)  AS [CA STATUS] " +
                  " from CPV_KYC_CASE_DETAILS CD " +
                  " LEFT OUTER JOIN CPV_KYC_CASE_VERIFICATION BV  ON BV.CASE_ID=CD.CASE_ID AND BV.VERIFICATION_TYPE_ID = '2' " +
                  " LEFT OUTER JOIN CPV_KYC_CASE_VERIFICATION RV  ON BV.CASE_ID=CD.CASE_ID AND RV.VERIFICATION_TYPE_ID = '1' " +
                  " LEFT OUTER JOIN CPV_KYC_CASE_VERIFICATION CA ON CA.CASE_ID=CD.CASE_ID AND CA.VERIFICATION_TYPE_ID = '10' " +
                  " where  ( 1=1 " + strNameCrieteria + "  ) and   " +
                  " 1=1 and( 1=1 " + strResiCriteria + "  )  and   " +
                  " 1=1 and( 1=1 " + strOfiiceCriteria + " ) and 1=1 " +
                  " " + strCriteria + " and Cluster_id=" + strClusterID + " " +
                  " and Centre_id=" + strCentreID + " and Client_id=" + strClientID + " and " + strDateCriteria + " ";
        return OleDbHelper.ExecuteDataset(con.ConnectionString, CommandType.Text, strSql);


    }
}
