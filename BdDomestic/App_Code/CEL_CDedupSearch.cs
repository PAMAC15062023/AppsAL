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
/// Summary description for CEL_CDedupSearch
/// </summary>
public class CEL_CDedupSearch
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
    private string strOffStreet;
    private string strResiStreet;
    private string strOffTel1;
    private string strResiTel1;

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
    public string ResiStreet
    {
        get { return strResiStreet; }
        set { strResiStreet = value; }
    }
    public string OffStreet
    {
        get { return strOffStreet; }
        set { strOffStreet = value; }
    }
    public string ResiTel1
    {
        get { return strResiTel1; }
        set { strResiTel1 = value; }
    }
    public string OffTel1
    {
        get { return strOffTel1; }
        set { strOffTel1 = value; }
    }
    CCommon con = new CCommon();
	public CEL_CDedupSearch()
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
        strSql = "Select case_id,ref_no,CASE_REC_DATETIME,APP_FNAME,APP_MNAME,APP_LNAME,APP_ADDR1,APP_ADDR2,APP_ADDR3,APP_CITY,APP_STREET,APP_PINCODE," +
                 "APP_PHONE1,APP_PHONE2,COMP_NAME,COMP_ADDR1,COMP_ADDR2,COMP_ADDR3,dbo.GetCellular_CaseType(Case_type_id) as[Case Type], " +
                 "COMP_CITY,COMP_STREET,COMP_PINCODE,COMP_PHONE1,COMP_PHONE2,APP_DOB from CPV_CELLULAR_CASES where " + strDateCriteria + "  " +
                 "and Cluster_id='" + strClusterID + "' and Centre_id='" + strCentreID + "' and Client_id='" + strClientID + "'  ";
        return OleDbHelper.ExecuteDataset(con.ConnectionString, CommandType.Text, strSql);

    }
    public DataSet GetRecordsPerCase(string strDate, string strTime, string strTimeType, string strClusterID, string strCentreID, string strClientID)
    {
        string strSql = "";

        // Code for Criteria Name
        string strDateCriteria = "";
        if (strDate != "" && strTime != "")
        {
            strDateCriteria = " cd.CASE_REC_DATETIME= '" + Convert.ToDateTime(strDate + ' ' + strTime + ' ' + strTimeType) + "' ";
        }
        else
        {
            //strDateCriteria = " CASE_REC_DATETIME <= '" + Convert.ToDateTime(strDate) + "' and CASE_REC_DATETIME > '" + Convert.ToDateTime(strDate).AddDays(1.0) + "' ";

            strDateCriteria = "cd.CASE_REC_DATETIME  not between '" + Convert.ToDateTime(strDate) + "' and '" + Convert.ToDateTime(strDate).AddDays(1.0) + "'  ";

        }
        string strNameCrieteria = "";

        if (FirstName != "")
        {
            strNameCrieteria += " or soundex(cd.APP_FNAME)= soundex('" + FirstName + "') or cd.APP_FNAME like'%" + FirstName + "%'  ";
            strNameCrieteria += " or soundex(cd.APP_MNAME)= soundex('" + FirstName + "') or cd.APP_MNAME like'%" + FirstName + "%'  ";
            strNameCrieteria += " or soundex(cd.APP_LNAME)= soundex('" + FirstName + "') or cd.APP_LNAME like'%" + FirstName + "%'  ";
        }


        if (LastName != "")
        {
            strNameCrieteria += " or soundex(cd.APP_FNAME)= soundex('" + LastName + "') or cd.APP_FNAME like'%" + LastName + "%'  ";
            strNameCrieteria += " or soundex(cd.APP_MNAME)= soundex('" + LastName + "') or cd.APP_MNAME like'%" + LastName + "%'  ";
            strNameCrieteria += " or soundex(cd.APP_LNAME)= soundex('" + LastName + "') or cd.APP_LNAME like'%" + LastName + "%'  ";
        }
        if (MiddleName != "")
        {
            strNameCrieteria += " or soundex(cd.APP_FNAME)= soundex('" + MiddleName + "') or cd.APP_FNAME like'%" + MiddleName + "%'  ";
            strNameCrieteria += " or soundex(cd.APP_MNAME)= soundex('" + MiddleName + "') or cd.APP_MNAME like'%" + MiddleName + "%'  ";
            strNameCrieteria += " or soundex(cd.APP_LNAME)= soundex('" + MiddleName + "') or cd.APP_LNAME like'%" + MiddleName + "%'  ";
        }

        // Code for Criteria ResiAddress
        string strResiCriteria = "";


        if (ResiAdd1 != "")
        {
            strResiCriteria += " or cd.APP_ADDR1 like'%" + ResiAdd1 + "%'  ";
            strResiCriteria += " or cd.APP_ADDR1 like'%" + ResiAdd2 + "%' or cd.APP_ADDR1 like'%" + ResiAdd3 + "%' ";
        }

        if (ResiAdd3 != "")
        {
            strResiCriteria += " or cd.APP_ADDR3 like'%" + ResiAdd3 + "%'  ";
            strResiCriteria += " or cd.APP_ADDR3 like'%" + ResiAdd2 + "%' or cd.APP_ADDR3 like'%" + ResiAdd3 + "%' ";
        }
        if (ResiAdd2 != "")
        {
            strResiCriteria += " or cd.APP_ADDR2 like'%" + ResiAdd2 + "%'  ";
            strResiCriteria += " or cd.APP_ADDR2 like'%" + ResiAdd2 + "%' or cd.APP_ADDR2 like'%" + ResiAdd3 + "%' ";
        }
        if (ResiLandMark != "")
        {
            strResiCriteria += " or  cd.APP_STREET like'%" + ResiStreet + " %'";
        }
        //Code for Office Address

        string strOfiiceCriteria = "";

        if (OffAdd1 != "")
        {
            strOfiiceCriteria += " or cd.COMP_ADDR1 like'%" + OffAdd1 + "%'  ";
            strOfiiceCriteria += " or cd.COMP_ADDR1 like'%" + OffAdd2 + "%' or cd.COMP_ADDR1 like'%" + OffAdd3 + "%' ";
        }

        if (OffAdd3 != "")
        {
            strOfiiceCriteria += " or cd.COMP_ADDR3 like'%" + OffAdd3 + "%' ";
            strOfiiceCriteria += " or cd.COMP_ADDR3 like'%" + OffAdd2 + "%' or cd.COMP_ADDR3 like'%" + OffAdd3 + "%' ";
        }
        if (OffAdd2 != "")
        {
            strOfiiceCriteria += " or cd.COMP_ADDR2 like'%" + OffAdd2 + "%' ";
            strOfiiceCriteria += " or cd.COMP_ADDR2 like'%" + OffAdd2 + "%' or cd.COMP_ADDR2 like'%" + OffAdd3 + "%' ";
        }
        if (OffStreet != "")
        {
            strOfiiceCriteria += "or cd.COMP_STREET like '%"+OffStreet+"%'";
        }

        string strCriteria = "";
        if (ResiCity != "")
        {
            strCriteria += " and cd.APP_CITY='" + ResiCity + "'";
        }
        if (ResiPinCode != "")
        {
            strCriteria += " and cd.APP_PINCODE='" + ResiPinCode + "' ";
        }
        if (ResiTel != "" && ResiTel1!="")
        {
            strCriteria += " and (cd.APP_PHONE1='" + ResiTel + "'  or cd.APP_PHONE1='" + ResiTel1 + "' or cd.APP_PHONE2='" + ResiTel + "' or cd.APP_PHONE2='" + ResiTel + "' ) ";
        }
        if (ResiTel != "" && ResiTel1 == "")
        {
            strCriteria += " and cd.APP_PHONE1='" + ResiTel + "'";
        }
        if (ResiTel1 != "" && ResiTel == "")
        {
            strCriteria += " and cd.APP_PHONE2='" + ResiTel1 + "'";
 
        }

        if (OffCity != "")
        {
            strCriteria = " and cd.COMP_CITY='" + OffCity + "' ";
        }
        if (OffPinCode != "")
        {
            strCriteria += " and cd.COMP_PINCODE='" + OffPinCode + "' ";
        }
        if (OffTel != "" && OffTel1!="")
        {
            strCriteria += " and (cd.COMP_PHONE1='" + OffTel + "'  or cd.COMP_PHONE1='" + OffTel1 + "' or cd.COMP_PHONE2='" + OffTel + "' or cd.COMP_PHONE2='" + OffTel1 + "' ) ";
        }
        if (OffTel != "" && OffTel1 == "")
        {
            strCriteria += "and cd.COMP_PHONE1='" + OffTel + "'";

        }
        if (OffTel1 != "" && OffTel == "")
        {
            strCriteria += "and cd.COMP_PHONE2='" + OffTel1 + "'";
        }
        if (DOB != "")
        {
            strCriteria += " and cd.APP_DOB='" +DOB +"' ";
        }
        strSql = "  select cd.case_id as CaseID,cd.REF_NO as [Ref No],cd.CASE_REC_DATETIME as [Rec Date],(ISNULL(cd.APP_FNAME + ' ', '') +ISNULL(cd.APP_MNAME + ' ', '') + ISNULL(cd.APP_LNAME + ' ', '')) as Name , " +
                  " (ISNULL(cd.APP_ADDR1+' ','') + ISNULL(cd.APP_ADDR2+' ','') + ISNULL(cd.APP_ADDR3+' ','')) AS [Resident Address], " +
                  " cd.APP_STREET as [Resi Street], cd.APP_CITY as [Resi City],cd.APP_PINCODE as [Resi Pin Code], " +
                  " cd.APP_PHONE1 as [Resi Tel1],cd.APP_PHONE2 as [Resi Tel2],cd.COMP_NAME as [Off Name], " +
                  " (ISNULL(cd.COMP_ADDR1+' ','') + ISNULL(cd.COMP_ADDR2+' ','') + ISNULL(cd.COMP_ADDR3+' ','')) AS [Office Address],cd.COMP_STREET as [Off Street],cd.COMP_CITY as [Off City], " +
                  " cd.COMP_PINCODE as [Off Pin Code],cd.COMP_PHONE1 as [Off Tel1],cd.COMP_PHONE2 as[Off Tel2],cd.APP_DOB, dbo.getStatus_Name(cd.CASE_STATUS_ID) as Case_Status,dbo.GetCellular_CaseType(cd.Case_type_id) as[Case Type]" +
                  " from CPV_CELLULAR_CASES CD " +
                 
                  " where  ( 1=1 " + strNameCrieteria + "  ) and   " +
                  " 1=1 and( 1=1 " + strResiCriteria +  "  )  and   " +
                  " 1=1 and( 1=1 " + strOfiiceCriteria + " ) and 1=1 " +
                  " " + strCriteria + " and cd.Cluster_id=" + strClusterID + " " +
                  " and cd.Centre_id=" + strCentreID + " and cd.Client_id=" + strClientID + " and " + strDateCriteria + " ";
        return OleDbHelper.ExecuteDataset(con.ConnectionString, CommandType.Text, strSql);


    }
}
