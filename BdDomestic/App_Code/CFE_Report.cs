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
/// Summary description for CFE_Report
/// </summary>
public class CFE_Report
{
    CCommon objCmn = new CCommon();
	public CFE_Report()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public string GetVeri_id(string strVeri_Type_Code)
    {

        string strVeri_id = "";
        string sSql = "";
        
        sSql = "SELECT Verification_type_id  from verification_type_master  where verification_type_code ='"+strVeri_Type_Code+"'" ;

          DataSet ds=new DataSet();
              ds=   OleDbHelper.ExecuteDataset(objCmn.ConnectionString, CommandType.Text, sSql);
              strVeri_id = ds.Tables[0].Rows[0][0].ToString();


              return strVeri_id;

    }
    public DataSet GetNotIssuedCases(string strVeri_id, string strProduct, string sDate)
    {

        string strCriteria = "";
        string sSql = "";
        string scriteria = "";
        if (sDate != "")
        {
            strCriteria += " and CD.CASE_REC_DATETIME >='" + Convert.ToDateTime(sDate).ToString("dd-MMM-yyyy") + "' and CD.CASE_REC_DATETIME <'" + Convert.ToDateTime(sDate).AddDays(1.0).ToString("dd-MMM-yyyy") + "' ";



        }
        if (sDate != "")
        {
            scriteria += " and CheckOut_Date>='" + Convert.ToDateTime(sDate).ToString("dd-MMM-yyyy") + "'";
        }
        if(strProduct =="CC")
        {

            sSql = " SELECT FW.FULLNAME as [FE-Name],CD.CASE_ID as [Case ID],CD.REF_NO as [Ref No.],CM.CLIENT_NAME as [Client Name],(ISNULL(RES_ADD_LINE_1+' ','') + ISNULL(RES_ADD_LINE_2+' ','') + ISNULL(RES_ADD_LINE_3+' ','') ) AS [Residence Address]," +
                   " (ISNULL(OFF_ADD_LINE_1+' ','') + ISNULL(OFF_ADD_LINE_2+' ','') + ISNULL(OFF_ADD_LINE_3+' ',''))AS [Office Address],RES_PIN_CODE as[Resi pinCode],OFF_PIN_CODE as[Off PinCode] " +
                   " FROM CPV_CC_CASE_DETAILS CD INNER JOIN CPV_CC_CASE_VERIFICATIONTYPE CCV ON(CD.CASE_ID=CCV.CASE_ID AND VERIFICATION_TYPE_ID='" + strVeri_id + "')" +
                   " LEFT OUTER JOIN CPV_CC_FE_CASE_MAPPING CFM ON(CD.CASE_ID=CFM.CASE_ID and CCV.verification_type_id=CFM.verification_type_id) LEFT OUTER JOIN  FE_VW FW ON(FW.EMP_ID=CFM.FE_ID)LEFT OUTER Join CLIENT_MASTER cm on CD.Client_id=cm.Client_id" +
                   " WHERE CD.CASE_ID NOT IN(SELECT CASE_ID FROM FE_Tracking WHERE product_id='1011' and  VERIFICATION_TYPE_ID='" + strVeri_id + "' " + scriteria + ") AND CCV.VERIFICATION_TYPE_ID='" + strVeri_id + "' " + strCriteria + "";

        //sSql = "SELECT CD.CASE_ID FROM CPV_CC_CASE_DETAILS CD INNER JOIN CPV_CC_CASE_VERIFICATIONTYPE CCV ON(CD.CASE_ID=CCV.CASE_ID AND VERIFICATION_TYPE_ID='"+strVeri_id+"')"+
        //       "WHERE CD.CASE_ID NOT IN(SELECT CASE_ID FROM FE_Tracking WHERE VERIFICATION_TYPE_ID='"+strVeri_id+"') AND CCV.VERIFICATION_TYPE_ID='"+strVeri_id+"'";
        }
        if (strProduct == "CELLULAR")
        {

            sSql = " SELECT FW.FULLNAME as [FE-Name],CD.CASE_ID as [Case ID],CD.REF_NO as [Ref No.],CM.CLIENT_NAME as [Client Name]," +
                   " (ISNULL(APP_ADDR1+' ','') + ISNULL(APP_ADDR2+' ','') + ISNULL(APP_ADDR3+' ','') ) AS [Residence Address], " +
                   " (ISNULL(COMP_ADDR1+' ','') + ISNULL(COMP_ADDR2+' ','') + ISNULL(COMP_ADDR3+' ',''))AS [Office Address],APP_PINCODE as[Resi pinCode],COMP_PINCODE as[Off PinCode]"+
                   " FROM CPV_CELLULAR_CASES CD INNER JOIN CPV_CELLULAR_CASE_VERIFICATIONTYPE CCV ON(CD.CASE_ID=CCV.CASE_ID AND VERIFICATION_TYPE_ID='" + strVeri_id + "')" +
                   " LEFT OUTER JOIN CPV_CELLULAR_FE_CASE_MAPPING CFM ON(CD.CASE_ID=CFM.CASE_ID and CCV.verification_type_id=CFM.verification_type_id) LEFT OUTER JOIN  FE_VW FW ON(FW.EMP_ID=CFM.FE_ID) LEFT OUTER Join CLIENT_MASTER cm on CD.Client_id=cm.Client_id" +
                   " WHERE CD.CASE_ID NOT IN(SELECT CASE_ID FROM FE_Tracking WHERE product_id='1014' and VERIFICATION_TYPE_ID='" + strVeri_id + "' " + scriteria + ") AND CCV.VERIFICATION_TYPE_ID='" + strVeri_id + "' " + strCriteria + "";

            //sSql = "SELECT CD.CASE_ID FROM CPV_CELLULAR_CASES CD INNER JOIN CPV_CELLULAR_CASE_VERIFICATIONTYPE CCV ON(CD.CASE_ID=CCV.CASE_ID AND VERIFICATION_TYPE_ID='" + strVeri_id + "')" +
            //       "WHERE CD.CASE_ID NOT IN(SELECT CASE_ID FROM FE_Tracking WHERE VERIFICATION_TYPE_ID='" + strVeri_id + "') AND CCV.VERIFICATION_TYPE_ID='" + strVeri_id + "'";
        }
        if (strProduct == "EBC")
        {

            sSql = " SELECT FW.FULLNAME as [FE-Name],CD.CASE_ID as [Case ID],CD.REF_NO as [Ref No.],CM.CLIENT_NAME as [Client Name],'' AS [Residence Address]," +
                   " (ISNULL(ADD_LINE_1+' ','') + ISNULL(ADD_LINE_2+' ','') + ISNULL(ADD_LINE_3+' ',''))AS [Office Address],PIN_CODE as[Resi pinCode],'' as[Off PinCode] " +
                   " FROM CPV_EBC_CASE_DETAILS CD INNER JOIN CPV_EBC_VAERIFICATION_TYPE CCV ON(CD.CASE_ID=CCV.CASE_ID AND VERIFICATION_TYPE_ID='" + strVeri_id + "')" +
                   " LEFT OUTER JOIN CPV_EBC_FE_MAPPING CFM ON(CD.CASE_ID=CFM.CASE_ID and CCV.verification_type_id=CFM.verification_type_id) LEFT OUTER JOIN  FE_VW FW ON(FW.EMP_ID=CFM.FE_ID) LEFT OUTER Join CLIENT_MASTER cm on CD.Client_id=cm.Client_id" +
                   " WHERE CD.CASE_ID NOT IN(SELECT CASE_ID FROM FE_Tracking WHERE product_id='1016' and  VERIFICATION_TYPE_ID='" + strVeri_id + "' " + scriteria + ") AND CCV.VERIFICATION_TYPE_ID='" + strVeri_id + "' " + strCriteria + "";

            //sSql = "SELECT CD.CASE_ID FROM CPV_EBC_CASE_DETAILS CD INNER JOIN CPV_EBC_VAERIFICATION_TYPE CCV ON(CD.CASE_ID=CCV.CASE_ID AND VERIFICATION_TYPE_ID='" + strVeri_id + "')" +
            //       "WHERE CD.CASE_ID NOT IN(SELECT CASE_ID FROM FE_Tracking WHERE VERIFICATION_TYPE_ID='" + strVeri_id + "') AND CCV.VERIFICATION_TYPE_ID='" + strVeri_id + "'";
        }
        if (strProduct == "KYC")
        {
            sSql = " SELECT FW.FULLNAME as [FE-Name],CD.CASE_ID as [Case ID], CD.REF_NO as [Ref No.],CM.CLIENT_NAME as [Client Name],(ISNULL(RES_ADD_LINE_1+' ','') + ISNULL(RES_ADD_LINE_2+' ','') + ISNULL(RES_ADD_LINE_3+' ','') ) AS [Residence Address]," +
                   " (ISNULL(OFF_ADD_LINE_1+' ','') + ISNULL(OFF_ADD_LINE_2+' ','') + ISNULL(OFF_ADD_LINE_3+' ',''))AS [Office Address],RES_PIN_CODE as[Resi pinCode],OFF_PIN_CODE as[Off PinCode] " +
                   " FROM CPV_KYC_CASE_DETAILS CD INNER JOIN CPV_KYC_VERIFICATION_TYPE CCV ON(CD.CASE_ID=CCV.CASE_ID AND CCV.VERIFICATION_TYPE_ID='" + strVeri_id + "')" +
                   " LEFT OUTER JOIN CPV_KYC_FE_MAPPING CFM ON(CD.CASE_ID=CFM.CASE_ID and CCV.verification_type_id=CFM.verification_type_id) LEFT OUTER JOIN  FE_VW FW ON(FW.EMP_ID=CFM.FE_ID) LEFT OUTER Join CLIENT_MASTER cm on CD.Client_id=cm.Client_id" +
                   " WHERE CD.CASE_ID NOT IN(SELECT CASE_ID FROM FE_Tracking WHERE product_id='1015' and  VERIFICATION_TYPE_ID='" + strVeri_id + "' " + scriteria + ") AND CCV.VERIFICATION_TYPE_ID='" + strVeri_id + "' " + strCriteria + "";


            //sSql = "SELECT CD.CASE_ID FROM CPV_KYC_CASE_DETAILS CD INNER JOIN CPV_KYC_VERIFICATION_TYPE CCV ON(CD.CASE_ID=CCV.CASE_ID AND VERIFICATION_TYPE_ID='" + strVeri_id + "')" +
            //       "WHERE CD.CASE_ID NOT IN(SELECT CASE_ID FROM FE_Tracking WHERE VERIFICATION_TYPE_ID='" + strVeri_id + "') AND CCV.VERIFICATION_TYPE_ID='" + strVeri_id + "'";
        }
        if (strProduct == "IDOC")
        {

            sSql = " SELECT FW.FULLNAME as [FE-Name],CD.CASE_ID as [Case ID],CD.REF_NO as [Ref No.],CM.CLIENT_NAME as [Client Name],(ISNULL(RES_ADD_LINE_1+' ','') + ISNULL(RES_ADD_LINE_2+' ','') + ISNULL(RES_ADD_LINE_3+' ','') ) AS [Residence Address]," +
                   " (ISNULL(OFF_ADD_LINE_1+' ','') + ISNULL(OFF_ADD_LINE_2+' ','') + ISNULL(OFF_ADD_LINE_3+' ',''))AS [Office Address],RES_PIN_CODE as[Resi pinCode],OFF_PIN_CODE as[Off PinCode] " +
                   " FROM CPV_IDOC_CASE_DETAILS CD INNER JOIN CPV_IDOC_VERIFICATION_TYPE CCV ON(CD.CASE_ID=CCV.CASE_ID AND CCV.VERIFICATION_TYPE_ID='" + strVeri_id + "')" +
                   " LEFT OUTER JOIN CPV_IDOC_FE_CASE_MAPPING CFM ON(CD.CASE_ID=CFM.CASE_ID and CCV.verification_type_id=CFM.verification_type_id) LEFT OUTER JOIN  FE_VW FW ON(FW.EMP_ID=CFM.FE_ID) LEFT OUTER Join CLIENT_MASTER cm on CD.Client_id=cm.Client_id" +
                   " WHERE CD.CASE_ID NOT IN(SELECT CASE_ID FROM FE_Tracking WHERE product_id='1017' and  VERIFICATION_TYPE_ID='" + strVeri_id + "' " + scriteria + ") AND CCV.VERIFICATION_TYPE_ID='" + strVeri_id + "' " + strCriteria + "";

            //sSql = "SELECT CD.CASE_ID FROM CPV_IDOC_CASE_DETAILS CD INNER JOIN CPV_IDOC_VERIFICATION_TYPE CCV ON(CD.CASE_ID=CCV.CASE_ID AND VERIFICATION_TYPE_ID='" + strVeri_id + "')" +
            //       "WHERE CD.CASE_ID NOT IN(SELECT CASE_ID FROM FE_Tracking WHERE VERIFICATION_TYPE_ID='" + strVeri_id + "') AND CCV.VERIFICATION_TYPE_ID='" + strVeri_id + "'";
        }
        if (strProduct == "RL")
        {

            sSql = " SELECT FW.FULLNAME as [FE-Name],CD.CASE_ID as [Case ID],CD.REF_NO as [Ref No.],CM.CLIENT_NAME as [Client Name],(ISNULL(RES_ADD_LINE_1+' ','') + ISNULL(RES_ADD_LINE_2+' ','') + ISNULL(RES_ADD_LINE_3+' ','') ) AS [Residence Address]," +
                   " (ISNULL(OFF_ADD_LINE_1+' ','') + ISNULL(OFF_ADD_LINE_2+' ','') + ISNULL(OFF_ADD_LINE_3+' ',''))AS [Office Address],RES_PIN_CODE as[Resi pinCode],OFF_PIN_CODE as[Off PinCode] " +
                   " FROM CPV_RL_CASE_DETAILS CD INNER JOIN CPV_RL_CASE_VERIFICATIONTYPE CCV ON(CD.CASE_ID=CCV.CASE_ID AND VERIFICATION_TYPE_ID='" + strVeri_id + "')" +
                   " LEFT OUTER JOIN CPV_RL_CASE_FE_MAPPING CFM ON(CD.CASE_ID=CFM.CASE_ID and CCV.verification_type_id=CFM.verification_type_id) LEFT OUTER JOIN  FE_VW FW ON(FW.EMP_ID=CFM.FE_ID) LEFT OUTER Join CLIENT_MASTER cm on CD.Client_id=cm.Client_id" +
                   " WHERE CD.CASE_ID NOT IN(SELECT CASE_ID FROM FE_Tracking WHERE product_id='1012' and VERIFICATION_TYPE_ID='" + strVeri_id + "' " + scriteria + ") AND CCV.VERIFICATION_TYPE_ID='" + strVeri_id + "' " + strCriteria + "";

            //sSql = "SELECT CD.CASE_ID FROM CPV_RL_CASE_DETAILS CD INNER JOIN CPV_RL_CASE_VERIFICATIONTYPE CCV ON(CD.CASE_ID=CCV.CASE_ID AND VERIFICATION_TYPE_ID='" + strVeri_id + "')" +
            //       "WHERE CD.CASE_ID NOT IN(SELECT CASE_ID FROM FE_Tracking WHERE VERIFICATION_TYPE_ID='" + strVeri_id + "') AND CCV.VERIFICATION_TYPE_ID='" + strVeri_id + "'";
        }
        DataSet ds = new DataSet();
        ds = OleDbHelper.ExecuteDataset(objCmn.ConnectionString, CommandType.Text, sSql);
        //strVeri_id = ds.Tables[0].Rows[0][0].ToString();


        return ds;

    }

    public DataSet FEReport(string sFromDate,string sToDate,string sFECode)
    {
        
        string sSql = "";
        string strCriteria = "";
        string strCriteria1 = "";
        
        if (sFromDate != "" && sToDate != "")
        {
            strCriteria += " and CheckOut_Date >='" + Convert.ToDateTime(sFromDate).ToString("dd-MMM-yyyy") + "' and CheckOut_Date <'" + Convert.ToDateTime(sToDate).AddDays(1.0).ToString("dd-MMM-yyyy") + "'";
        }
        if (sFECode != "")
        {
            strCriteria += " and FE_Code='" + sFECode + "' ";
        }
        sSql = "SELECT FE_Tracking.FE_Name as [FE Name], " +

               " (SELECT COUNT(STATUS) FROM FE_Tracking AS IN_FE_Tracking WHERE IN_FE_Tracking.FE_Code=FE_Tracking.FE_Code "+strCriteria+") AS [Case Issued To Field], " +
               " ((SELECT COUNT(STATUS) FROM FE_Tracking AS IN_FE_Tracking WHERE IN_FE_Tracking.FE_Code=FE_Tracking.FE_Code " + strCriteria + ")-(SELECT COUNT(STATUS) FROM FE_Tracking AS IN_FE_Tracking  WHERE STATUS='Closed' AND IN_FE_Tracking.FE_Code=FE_Tracking.FE_Code " + strCriteria + ")) as [Case on Field], " +
               " (SELECT COUNT(STATUS) FROM FE_Tracking AS IN_FE_Tracking  WHERE STATUS='Closed' AND IN_FE_Tracking.FE_Code=FE_Tracking.FE_Code " + strCriteria + ") as [Case Returned From Field], " +
               " (SELECT COUNT(CaseStatus) FROM FE_Tracking AS IN_FE_Tracking WHERE CaseStatus='completed' AND IN_FE_Tracking.FE_Code=FE_Tracking.FE_Code " + strCriteria + ") AS [Case Completed], " +
               " (SELECT COUNT(CaseStatus) FROM FE_Tracking AS IN_FE_Tracking WHERE CaseStatus='Revisit' AND IN_FE_Tracking.FE_Code=FE_Tracking.FE_Code " + strCriteria + ") AS [Case Revisit], " +
               " (SELECT COUNT(CaseStatus) FROM FE_Tracking AS IN_FE_Tracking WHERE CaseStatus='Pending' AND IN_FE_Tracking.FE_Code=FE_Tracking.FE_Code " + strCriteria + ") AS [Case Pending] " +
               " FROM FE_Tracking where 1=1 " + strCriteria + " GROUP BY FE_Tracking.FE_Name,FE_Code  order by fe_name ";
        return OleDbHelper.ExecuteDataset(objCmn.ConnectionString, CommandType.Text, sSql);
 
    }
    public DataSet FE_Case_DetailReport(string sProduct,string sDate,string sFECode)
    { 
        string sSql = "";
        string strCriteria = "";
        if (sDate != "")
        {
            strCriteria += " and CheckOut_Date >='" + sDate + "' and  CheckOut_Date < '" + Convert.ToDateTime(sDate).AddDays(1.0).ToString("dd-MMM-yyyy") + "' ";
        }
        if (sFECode != "")
        {
            strCriteria += " and FE_Code='" + sFECode + "' ";
        }
       
        if (sProduct == "1011")
        {
            sSql = " select fet.fe_name as [FE Name],cd.case_id as CaseID ,ref_no  as [RefNo.],vtm.verification_type as [Verification Type]," +
                   " pm.Product_Name as[Product Name],cm.Client_Name as [Client Name]," +
                   " (ISNULL(FIRST_NAME + ' ', '') +ISNULL(MIDDLE_NAME + ' ', '') + ISNULL(LAST_NAME + ' ', '')) AS Name , " +
                   " (ISNULL(RES_ADD_LINE_1+' ','') + ISNULL(RES_ADD_LINE_2+' ','') + ISNULL(RES_ADD_LINE_3+' ','') ) AS [Residence Address], " +
                   " (ISNULL(OFF_ADD_LINE_1+' ','') + ISNULL(OFF_ADD_LINE_2+' ','') + ISNULL(OFF_ADD_LINE_3+' ',''))AS [Office Address],RES_PIN_CODE as[Resi pinCode],OFF_PIN_CODE as[Off PinCode],FET.CaseStatus " +
                   " from cpv_cc_case_details cd inner join FE_Tracking FET on(FET.Case_id=cd.Case_id) left outer join verification_type_master vtm on(fet.verification_type_id=vtm.verification_type_id)"+
                   " inner Join CLIENT_MASTER cm on fet.Client_id=cm.Client_id inner join PRODUCT_MASTER pm on pm.Product_id=fet.Product_id " +
                   " where 1=1 " + strCriteria + " order by fe_name ";

        }
        if (sProduct == "1014")
        {
            sSql = " select fet.fe_name as [FE Name],cd.case_id as CaseID ,ref_no as [Ref No.],vtm.verification_type as [Verification Type]," +
                   " pm.Product_Name as[Product Name],cm.Client_Name as [Client Name]," +
                   " (ISNULL(APP_FNAME + ' ', '') +ISNULL(APP_MNAME + ' ', '') + ISNULL(APP_LNAME + ' ', '')) AS Name , " +
                   " (ISNULL(APP_ADDR1+' ','') + ISNULL(APP_ADDR2+' ','') + ISNULL(APP_ADDR3+' ','') ) AS [Residence Address], " +
                   " (ISNULL(COMP_ADDR1+' ','') + ISNULL(COMP_ADDR2+' ','') + ISNULL(COMP_ADDR3+' ',''))AS [Office Address],APP_PINCODE as[Resi pinCode],COMP_PINCODE as[Off PinCode],FET.CaseStatus " +
                   " from CPV_CELLULAR_CASES cd inner join FE_Tracking FET on(FET.Case_id=cd.Case_id) left outer join verification_type_master vtm on(fet.verification_type_id=vtm.verification_type_id)"+
                   " inner Join CLIENT_MASTER cm on fet.Client_id=cm.Client_id inner join PRODUCT_MASTER pm on pm.Product_id=fet.Product_id " +
                   " where 1=1 " + strCriteria + " order by fe_name ";

        }
        if (sProduct == "1016")
        {
            sSql = " select fet.fe_name as [FE Name],cd.case_id as CaseID ,ref_no as [Ref No.],vtm.verification_type as [Verification Type]," +
                   " pm.Product_Name as[Product Name],cm.Client_Name as [Client Name]," +
                   " (ISNULL(FIRST_NAME + ' ', '') +ISNULL(MIDDLE_NAME + ' ', '') + ISNULL(LAST_NAME + ' ', '')) AS Name , " +
                   " (ISNULL(ADD_LINE_1+' ','') + ISNULL(ADD_LINE_2+' ','') + ISNULL(ADD_LINE_3+' ','') ) AS [Address],PIN_CODE as[PinCode],FET.CaseStatus " +
                  
                   " from CPV_EBC_CASE_DETAILS cd inner join FE_Tracking FET on(FET.Case_id=cd.Case_id) left outer join verification_type_master vtm on(fet.verification_type_id=vtm.verification_type_id)"+
                   " inner Join CLIENT_MASTER cm on fet.Client_id=cm.Client_id inner join PRODUCT_MASTER pm on pm.Product_id=fet.Product_id " +
                   " where 1=1 " + strCriteria + " order by fe_name ";

        }
        if (sProduct == "1015")
        {
            sSql = " select fet.fe_name as [FE Name],cd.case_id as CaseID ,ref_no as [Ref No.],vtm.verification_type as [Verification Type]," +
                   " pm.Product_Name as[Product Name],cm.Client_Name as [Client Name]," +
                   " (ISNULL(FIRST_NAME + ' ', '') +ISNULL(MIDDLE_NAME + ' ', '') + ISNULL(LAST_NAME + ' ', '')) AS Name , " +
                   " (ISNULL(RES_ADD_LINE_1+' ','') + ISNULL(RES_ADD_LINE_2+' ','') + ISNULL(RES_ADD_LINE_3+' ','') ) AS [Residence Address], " +
                   " (ISNULL(OFF_ADD_LINE_1+' ','') + ISNULL(OFF_ADD_LINE_2+' ','') + ISNULL(OFF_ADD_LINE_3+' ',''))AS [Office Address],RES_PIN_CODE as[Resi pinCode],OFF_PIN_CODE as[Off PinCode],FET.CaseStatus " +
                   " from CPV_KYC_CASE_DETAILS cd inner join FE_Tracking FET on(FET.Case_id=cd.Case_id) left outer join verification_type_master vtm on(fet.verification_type_id=vtm.verification_type_id)"+
                   " inner Join CLIENT_MASTER cm on fet.Client_id=cm.Client_id inner join PRODUCT_MASTER pm on pm.Product_id=fet.Product_id " +
                   " where 1=1 " + strCriteria + " order by fe_name ";

        }
        if (sProduct == "1012")
        {
            sSql = " select fet.fe_name as [FE Name],cd.case_id as CaseID ,ref_no as [Ref No.],vtm.verification_type as [Verification Type]," +
                   " pm.Product_Name as[Product Name],cm.Client_Name as [Client Name]," +
                   " (ISNULL(FIRST_NAME + ' ', '') +ISNULL(MIDDLE_NAME + ' ', '') + ISNULL(LAST_NAME + ' ', '')) AS Name , " +
                   " (ISNULL(RES_ADD_LINE_1+' ','') + ISNULL(RES_ADD_LINE_2+' ','') + ISNULL(RES_ADD_LINE_3+' ','') ) AS [Residence Address], " +
                   " (ISNULL(OFF_ADD_LINE_1+' ','') + ISNULL(OFF_ADD_LINE_2+' ','') + ISNULL(OFF_ADD_LINE_3+' ',''))AS [Office Address],RES_PIN_CODE as[Resi pinCode],OFF_PIN_CODE as[Off PinCode],FET.CaseStatus " +
                   " from CPV_RL_CASE_DETAILS cd inner join FE_Tracking FET on(FET.Case_id=cd.Case_id) left outer join verification_type_master vtm on(fet.verification_type_id=vtm.verification_type_id)"+
                   " inner Join CLIENT_MASTER cm on fet.Client_id=cm.Client_id inner join PRODUCT_MASTER pm on pm.Product_id=fet.Product_id " +
                   " where 1=1 " + strCriteria + " order by fe_name ";
        }
        if (sProduct == "1017")
        {
            sSql = " select fet.fe_name as [FE Name],cd.case_id as CaseID ,ref_no as [Ref No.],vtm.verification_type as [Verification Type]," +
                   " pm.Product_Name as[Product Name],cm.Client_Name as [Client Name]," +
                   " (ISNULL(FIRST_NAME + ' ', '') +ISNULL(MIDDLE_NAME + ' ', '') + ISNULL(LAST_NAME + ' ', '')) AS Name , " +
                   " (ISNULL(RES_ADD_LINE_1+' ','') + ISNULL(RES_ADD_LINE_2+' ','') + ISNULL(RES_ADD_LINE_3+' ','') ) AS [Residence Address], " +
                   " (ISNULL(OFF_ADD_LINE_1+' ','') + ISNULL(OFF_ADD_LINE_2+' ','') + ISNULL(OFF_ADD_LINE_3+' ',''))AS [Office Address],RES_PIN_CODE as[Resi pinCode],OFF_PIN_CODE as[Off PinCode],FET.CaseStatus " +
                   " from CPV_IDOC_CASE_DETAILS cd inner join FE_Tracking FET on(FET.Case_id=cd.Case_id) left outer join verification_type_master vtm on(fet.verification_type_id=vtm.verification_type_id)"+
                   " inner Join CLIENT_MASTER cm on fet.Client_id=cm.Client_id inner join PRODUCT_MASTER pm on pm.Product_id=fet.Product_id " +
                   " where 1=1 " + strCriteria + " order by fe_name ";

        }
        if (sProduct == "0")
        {
            sSql = " select fet.fe_name as [FE Name],cd.case_id as CaseID ,ref_no  as [RefNo.],vtm.verification_type as [Verification Type]," +
                /*-1-- */    " pm.Product_Name as[Product Name],cm.Client_Name as [Client Name]," +
                   " (ISNULL(FIRST_NAME + ' ', '') +ISNULL(MIDDLE_NAME + ' ', '') + ISNULL(LAST_NAME + ' ', '')) AS Name ,  (ISNULL(RES_ADD_LINE_1+' ','')" +
                   "+ ISNULL(RES_ADD_LINE_2+' ','') + ISNULL(RES_ADD_LINE_3+' ','') ) AS [Residence Address],  (ISNULL(OFF_ADD_LINE_1+' ','') + ISNULL(OFF_ADD_LINE_2+' ','') + ISNULL(OFF_ADD_LINE_3+' ',''))AS [Office Address],RES_PIN_CODE as[Resi pinCode],OFF_PIN_CODE as[Off PinCode]," +
                    "FET.CaseStatus  from cpv_cc_case_details cd inner join FE_Tracking FET on(FET.Case_id=cd.Case_id) left outer join verification_type_master vtm  on(fet.verification_type_id=vtm.verification_type_id)"+
                     " inner Join CLIENT_MASTER cm on fet.Client_id=cm.Client_id inner join PRODUCT_MASTER pm on pm.Product_id=fet.Product_id " +
                    " where 1=1  union select fet.fe_name as [FE Name],cd.case_id as CaseID ,ref_no as [Ref No.],vtm.verification_type as [Verification Type], " +
                /*-2-- */  " pm.Product_Name as[Product Name],cm.Client_Name as [Client Name]," +
                   " (ISNULL(APP_FNAME + ' ', '') +ISNULL(APP_MNAME + ' ', '') + ISNULL(APP_LNAME + ' ', '')) AS Name ,  (ISNULL(APP_ADDR1+' ','') + ISNULL(APP_ADDR2+' ','') + ISNULL(APP_ADDR3+' ','') )" +
                    "AS [Residence Address],  (ISNULL(COMP_ADDR1+' ','') + ISNULL(COMP_ADDR2+' ','') + ISNULL(COMP_ADDR3+' ',''))AS [Office Address],APP_PINCODE as[Resi pinCode],COMP_PINCODE as[Off PinCode],FET.CaseStatus  from CPV_CELLULAR_CASES cd inner join FE_Tracking FET on(FET.Case_id=cd.Case_id)" +
                    "left outer join verification_type_master vtm on(fet.verification_type_id=vtm.verification_type_id)"+
                     " inner Join CLIENT_MASTER cm on fet.Client_id=cm.Client_id inner join PRODUCT_MASTER pm on pm.Product_id=fet.Product_id " +
                    " where 1=1 union select fet.fe_name as [FE Name],cd.case_id as CaseID ,ref_no as [Ref No.],vtm.verification_type as [Verification Type]," +
                /*-3-- */         " pm.Product_Name as[Product Name],cm.Client_Name as [Client Name]," +
                    " (ISNULL(FIRST_NAME + ' ', '') +ISNULL(MIDDLE_NAME + ' ', '')" +
                    "+ ISNULL(LAST_NAME + ' ', '')) AS Name ,  (ISNULL(ADD_LINE_1+' ','')+ ISNULL(ADD_LINE_2+' ','') + ISNULL(ADD_LINE_3+' ','') ) AS [Office Address],'' AS [Residence Address],PIN_CODE as[Resi PinCode],'' as[Off PinCode],FET.CaseStatus  from CPV_EBC_CASE_DETAILS cd " +
                    "inner join FE_Tracking FET on(FET.Case_id=cd.Case_id) left outer join verification_type_master vtm on(fet.verification_type_id=vtm.verification_type_id)"+
                     " inner Join CLIENT_MASTER cm on fet.Client_id=cm.Client_id inner join PRODUCT_MASTER pm on pm.Product_id=fet.Product_id " +
                    " where 1=1  union select fet.fe_name as [FE Name],cd.case_id as CaseID,ref_no as [Ref No.],vtm.verification_type as [Verification Type]," +
                /*-4-- */    " pm.Product_Name as[Product Name],cm.Client_Name as [Client Name]," +
                    
                    "(ISNULL(FIRST_NAME + ' ', '') +ISNULL(MIDDLE_NAME + ' ', '') + ISNULL(LAST_NAME + ' ', '')) AS Name ,  (ISNULL(RES_ADD_LINE_1+' ','') + ISNULL(RES_ADD_LINE_2+' ','') + ISNULL(RES_ADD_LINE_3+' ','') ) AS [Residence Address],  (ISNULL(OFF_ADD_LINE_1+' ','') + ISNULL(OFF_ADD_LINE_2+' ','') +" +
                    "ISNULL(OFF_ADD_LINE_3+' ',''))AS [Office Address],RES_PIN_CODE as[Resi pinCode],OFF_PIN_CODE as[Off PinCode],FET.CaseStatus  from CPV_IDOC_CASE_DETAILS cd inner join FE_Tracking FET on(FET.Case_id=cd.Case_id) left outer join verification_type_master vtm on(fet.verification_type_id=vtm.verification_type_id)" +
                     " inner Join CLIENT_MASTER cm on fet.Client_id=cm.Client_id inner join PRODUCT_MASTER pm on pm.Product_id=fet.Product_id " +
                    "where 1=1 union select fet.fe_name as [FE Name],cd.case_id as CaseID ,ref_no as [Ref No.],vtm.verification_type as [Verification Type]," +
                /*-5-- */   " pm.Product_Name as[Product Name],cm.Client_Name as [Client Name]," +
                    " (ISNULL(FIRST_NAME + ' ', '') +ISNULL(MIDDLE_NAME + ' ', '') + ISNULL(LAST_NAME + ' ', '')) AS Name ,  (ISNULL(RES_ADD_LINE_1+' ','') +" +
                    "ISNULL(RES_ADD_LINE_2+' ','') + ISNULL(RES_ADD_LINE_3+' ','') ) AS [Residence Address], (ISNULL(OFF_ADD_LINE_1+' ','') + ISNULL(OFF_ADD_LINE_2+' ','') + ISNULL(OFF_ADD_LINE_3+' ',''))AS [Office Address],RES_PIN_CODE as[Resi pinCode],OFF_PIN_CODE as[Off PinCode],FET.CaseStatus " +
                   " from CPV_KYC_CASE_DETAILS cd inner join FE_Tracking FET on(FET.Case_id=cd.Case_id) left outer join verification_type_master vtm on(fet.verification_type_id=vtm.verification_type_id)"+
                    " inner Join CLIENT_MASTER cm on fet.Client_id=cm.Client_id inner join PRODUCT_MASTER pm on pm.Product_id=fet.Product_id " +
                   " where 1=1 union  select fet.fe_name as [FE Name],cd.case_id as CaseID ,ref_no as [Ref No.],vtm.verification_type as [Verification Type], " +
                /*-6-- */  " pm.Product_Name as[Product Name],cm.Client_Name as [Client Name]," +
                  
                    "(ISNULL(FIRST_NAME + ' ', '') +ISNULL(MIDDLE_NAME + ' ', '') + ISNULL(LAST_NAME + ' ', '')) AS Name ,  (ISNULL(RES_ADD_LINE_1+' ','') + ISNULL(RES_ADD_LINE_2+' ','') + ISNULL(RES_ADD_LINE_3+' ','') )" +
                    "AS [Residence Address],  (ISNULL(OFF_ADD_LINE_1+' ','') + ISNULL(OFF_ADD_LINE_2+' ','') + ISNULL(OFF_ADD_LINE_3+' ',''))AS [Office Address],RES_PIN_CODE as[Resi pinCode],OFF_PIN_CODE as[Off PinCode],FET.CaseStatus  from CPV_RL_CASE_DETAILS cd inner join" +
                    " FE_Tracking FET on(FET.Case_id=cd.Case_id) left outer join verification_type_master vtm on(fet.verification_type_id=vtm.verification_type_id)"+
                     " inner Join CLIENT_MASTER cm on fet.Client_id=cm.Client_id inner join PRODUCT_MASTER pm on pm.Product_id=fet.Product_id " +
                    " where 1=1  order by fe_name  ";
        }


        return OleDbHelper.ExecuteDataset(objCmn.ConnectionString, CommandType.Text, sSql);
    }
    public DataSet TotalReport(string sDate, string sProduct, string sVerificationType)
    {
        string sSql = "";
        string strCriteria = "";
        string strCriteria1 = "";
        if (sDate != "")
        {
            strCriteria += " and CD.CASE_REC_DATETIME >='" + Convert.ToDateTime(sDate).ToString("dd-MMM-yyyy") + "' and CD.CASE_REC_DATETIME <'" + Convert.ToDateTime(sDate).AddDays(1.0).ToString("dd-MMM-yyyy") + "' ";   

            
 
        }
        if (sVerificationType != "All")
        {
            strCriteria += " and vtm.verification_type_id ='" + sVerificationType + "'";
        }
        
        if (sDate != "")
        {
            strCriteria1 = " and CheckOut_Date>'" + sDate + "' ";
        }
       
       
        if (sProduct == "1011")
        {
            sSql = " SELECT COUNT(CV.CASE_ID) AS [Total No of Cases], VTM.VERIFICATION_TYPE_CODE AS [VERIFICATION TYPE], COUNT(FET.Case_ID) AS [CASE ISSUED ON FIELD], " +
                   " (COUNT(CV.CASE_ID)-COUNT(FET.Case_ID)) AS [NOT ISSUED] FROM CPV_CC_CASE_DETAILS CD INNER JOIN CPV_CC_CASE_VERIFICATIONTYPE CV ON CD.CASE_ID = CV.CASE_ID INNER JOIN " +
                   "  VERIFICATION_TYPE_MASTER VTM ON CV.VERIFICATION_TYPE_ID = VTM.VERIFICATION_TYPE_ID LEFT OUTER JOIN FE_Tracking FET ON CV.CASE_ID = FET.Case_ID AND CV.VERIFICATION_TYPE_ID = FET.Verification_Type_ID " +
                   "  AND FET.PRODUCT_ID='1011' " + strCriteria1 + " WHERE 1=1 " + strCriteria + " AND (VTM.VERIFICATION_TYPE_ID IN (1,2,10)) " +
                   "  GROUP BY CV.VERIFICATION_TYPE_ID, VTM.VERIFICATION_TYPE_CODE ";


        }

        if (sProduct == "1014")
        
        {
            sSql = " SELECT COUNT(CV.CASE_ID) AS [Total No of Cases], VTM.VERIFICATION_TYPE_CODE AS [VERIFICATION TYPE], COUNT(FET.Case_ID) AS [CASE ISSUED ON FIELD], " +
                  " (COUNT(CV.CASE_ID)-COUNT(FET.Case_ID)) AS [NOT ISSUED] FROM CPV_CELLULAR_CASES CD INNER JOIN CPV_CELLULAR_CASE_VERIFICATIONTYPE CV ON CD.CASE_ID = CV.CASE_ID INNER JOIN " +
                  "  VERIFICATION_TYPE_MASTER VTM ON CV.VERIFICATION_TYPE_ID = VTM.VERIFICATION_TYPE_ID LEFT OUTER JOIN FE_Tracking FET ON CV.CASE_ID = FET.Case_ID AND CV.VERIFICATION_TYPE_ID = FET.Verification_Type_ID " +
                  "  AND FET.PRODUCT_ID='1014' " + strCriteria1 + " WHERE 1=1 " + strCriteria + "  " +
                  "  GROUP BY CV.VERIFICATION_TYPE_ID, VTM.VERIFICATION_TYPE_CODE ";

           }
           if (sProduct == "1016")
           {

               sSql = " SELECT COUNT(CV.CASE_ID) AS [Total No of Cases], VTM.VERIFICATION_TYPE_CODE AS [VERIFICATION TYPE], COUNT(FET.Case_ID) AS [CASE ISSUED ON FIELD], " +
                     " (COUNT(CV.CASE_ID)-COUNT(FET.Case_ID)) AS [NOT ISSUED] FROM CPV_EBC_CASE_DETAILS CD INNER JOIN CPV_EBC_VAERIFICATION_TYPE CV ON CD.CASE_ID = CV.CASE_ID INNER JOIN " +
                    "  VERIFICATION_TYPE_MASTER VTM ON CV.VERIFICATION_TYPE_ID = VTM.VERIFICATION_TYPE_ID LEFT OUTER JOIN FE_Tracking FET ON CV.CASE_ID = FET.Case_ID AND CV.VERIFICATION_TYPE_ID = FET.Verification_Type_ID " +
                    "  AND FET.PRODUCT_ID='1016' " + strCriteria1 + " WHERE 1=1 " + strCriteria + " AND VTM.VERIFICATION_TYPE_ID IN(1,15,16,17,18)  " +
                    "  GROUP BY CV.VERIFICATION_TYPE_ID, VTM.VERIFICATION_TYPE_CODE ";
            }

           if (sProduct == "1015")
           {
               sSql = " SELECT COUNT(CV.CASE_ID) AS [Total No of Cases], VTM.VERIFICATION_TYPE_CODE AS [VERIFICATION TYPE], COUNT(FET.Case_ID) AS [CASE ISSUED ON FIELD], " +
                 " (COUNT(CV.CASE_ID)-COUNT(FET.Case_ID)) AS [NOT ISSUED] FROM CPV_kyc_CASE_DETAILS CD INNER JOIN CPV_KYC_VERIFICATION_TYPE CV ON CD.CASE_ID = CV.CASE_ID INNER JOIN " +
                 "  VERIFICATION_TYPE_MASTER VTM ON CV.VERIFICATION_TYPE_ID = VTM.VERIFICATION_TYPE_ID LEFT OUTER JOIN FE_Tracking FET ON CV.CASE_ID = FET.Case_ID AND CV.VERIFICATION_TYPE_ID = FET.Verification_Type_ID " +
                 "  AND FET.PRODUCT_ID='1015' " + strCriteria1 + " WHERE 1=1 " + strCriteria + " AND (VTM.VERIFICATION_TYPE_ID IN (1,2,19)) " +
                 "  GROUP BY CV.VERIFICATION_TYPE_ID, VTM.VERIFICATION_TYPE_CODE ";

             
           }
           if (sProduct == "1012")
           {

               sSql = " SELECT COUNT(CV.CASE_ID) AS [Total No of Cases], VTM.VERIFICATION_TYPE_CODE AS [VERIFICATION TYPE], COUNT(FET.Case_ID) AS [CASE ISSUED ON FIELD], " +
                   " (COUNT(CV.CASE_ID)-COUNT(FET.Case_ID)) AS [NOT ISSUED] FROM CPV_Rl_CASE_DETAILS CD INNER JOIN CPV_Rl_CASE_VERIFICATIONTYPE CV ON CD.CASE_ID = CV.CASE_ID INNER JOIN " +
                   "  VERIFICATION_TYPE_MASTER VTM ON CV.VERIFICATION_TYPE_ID = VTM.VERIFICATION_TYPE_ID LEFT OUTER JOIN FE_Tracking FET ON CV.CASE_ID = FET.Case_ID AND CV.VERIFICATION_TYPE_ID = FET.Verification_Type_ID " +
                   "  AND FET.PRODUCT_ID='1012' " + strCriteria1 + " WHERE 1=1 " + strCriteria + " AND VTM.VERIFICATION_TYPE_ID IN(1,2,10,14) " +
                   "  GROUP BY CV.VERIFICATION_TYPE_ID, VTM.VERIFICATION_TYPE_CODE ";
              
           }
           if (sProduct == "1017")
           {
              

               sSql = " SELECT COUNT(CV.CASE_ID) AS [Total No of Cases], VTM.VERIFICATION_TYPE_CODE AS [VERIFICATION TYPE], COUNT(FET.Case_ID) AS [CASE ISSUED ON FIELD], " +
                      " (COUNT(CV.CASE_ID)-COUNT(FET.Case_ID)) AS [NOT ISSUED] FROM CPV_IDOC_CASE_DETAILS CD INNER JOIN CPV_IDOC_VERIFICATION_TYPE CV ON CD.CASE_ID = CV.CASE_ID INNER JOIN " +
                      " VERIFICATION_TYPE_MASTER VTM ON CV.VERIFICATION_TYPE_ID = VTM.VERIFICATION_TYPE_ID LEFT OUTER JOIN FE_Tracking FET ON CV.CASE_ID = FET.Case_ID AND CV.VERIFICATION_TYPE_ID = FET.Verification_Type_ID " +
                      " AND FET.PRODUCT_ID='1017' " + strCriteria1 + " WHERE 1=1 " + strCriteria + " AND VTM.VERIFICATION_TYPE_ID IN(5,6,7,8,9) " +
                      " GROUP BY CV.VERIFICATION_TYPE_ID, VTM.VERIFICATION_TYPE_CODE ";

           }
           return OleDbHelper.ExecuteDataset(objCmn.ConnectionString, CommandType.Text, sSql);
    }
}
