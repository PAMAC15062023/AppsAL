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
/// Summary description for CExportDataDump
/// </summary>
public class CExportDataDump
{
	public CExportDataDump()
	{
		
	}

    public DataSet GetRecods(string strFromDate,string strToDate,string strClientId,string strCentreId)
    {
        CCommon objCmn=new CCommon();
        string sSql = "";
        sSql = "SELECT CaseOutPut.CASE_ID,REF_NO as [Application ID],TYPE_OF_APPLICANT as [Type of Applicant],Type_Of_Loan as [Type of Loan]," +
              " CONVERT(CHAR(9), case_rec_datetime, 3) + LTRIM(SUBSTRING(CONVERT(VARCHAR(20),case_rec_datetime, 22), 10, 5) + RIGHT(CONVERT(VARCHAR(20), case_rec_datetime, 22), 3)) as [Received Date]," +
              " CONVERT(CHAR(9), SEND_DATETIME, 3) + LTRIM(SUBSTRING(CONVERT(VARCHAR(20),SEND_DATETIME, 22), 10, 5) + RIGHT(CONVERT(VARCHAR(20), SEND_DATETIME, 22), 3)) as [Send Date]," +
              " APPLICANT_NAME as [Customer Name],OFF_NAME as [Company Name],OFF_CITY as [Location]," +
              " OFF_ADD_LINE_1 as [Bldg Name],'' as Area,PINCODE as [Po.Box],OFFICE_TELEPHONE as [Telephone No],FaxNumber as [Fax No],MOBILE as [Mobile No]," +
              " CASE OFFICE_IS_IN WHEN 'NA' THEN '' ELSE OFFICE_IS_IN End as [Office Location]," +
              " CASE OFF_NAME_ON_BOARD WHEN 'NA' THEN '' ELSE OFF_NAME_ON_BOARD END as [Name Board of Company]," +
              " Is_Security_guard_building as [Security Guard],Is_Reception_Desk as [Reception Desk],EQUIPMENT_SIGHTED_IN_OFFICE as [Equipment Seen],No_Desks_Workstations_Tables as [How Many Desk/Workstation/Tables]," +
              " NO_OF_EMP_SIGHTED_IN_PERMISES as [No of Employee], No_Of_Employees as [No of Employee Seen],Is_TradeLicense_Displayed as [Trade License Displayed],Details_Of_Trade_License as [Details of Trade License],No_Of_Employees as [No of Employee Working]," +
              " Branch1_Location as [Branch 1 Location],Branch1_TelephoneNo as [Branch 1 Telephone No],Branch1_Rental_Amt as [Branch 1 Rental Amt],Isnull(Branch1_FaxNo,'')+' ' +Isnull(Branch1_ManagerName,'') as [Branch 1 Faxno/Manager name]," +
              " Branch2_Location as [Branch 2 Location],Branch2_TelephoneNo as [Branch 2 Telephone No],Branch2_Rental_Amt as [Branch 2 Rental Amt],Isnull(Branch2_FaxNo,'')+' ' +Isnull(Branch2_ManagerName,'') as [Branch 2 Faxno/Manager name]," +
              " Branch3_Location as [Branch 3 Location],Branch3_TelephoneNo as [Branch 3 Telephone No],Branch3_Rental_Amt as [Branch 3 Rental Amt],Isnull(Branch3_FaxNo,'')+' ' +Isnull(Branch3_ManagerName,'') as [Branch 3 Faxno/Manager name],"+
              " Branch4_Location as [Branch 4 Location],Branch4_TelephoneNo as [Branch 4 Telephone No],Branch4_Rental_Amt as [Branch 4 Rental Amt],Isnull(Branch4_FaxNo,'')+' ' +Isnull(Branch4_ManagerName,'') as [Branch 4 Faxno/Manager name]," +
              " Sponsor1_Name as [Sponsor 1 Name],Type1 as [Type 1],Sponsor1_TelephoneNo as [Sponsor 1 Telephone No],Sponsor1_Address as [Sponsor 1 Address]," +
              " Sponsor2_Name as [Sponsor 2 Name],Type2 as [Type 2],Sponsor2_TelephoneNo as [Sponsor 2 Telephone No],Sponsor2_Address as [Sponsor 2 Address]," +
              " Sponsor3_Name as [Sponsor 3 Name],Type3 as [Type 3],Sponsor3_TelephoneNo as [Sponsor 3 Telephone No],Sponsor3_Address as [Sponsor 3 Address]," +
              " No_Emps_SeniorPosition as [No of Emps in Senior Position]," +
              " Business_NatureCITI as [Nature of Business],Product_Dealt_With as [Product Dealt With],BankName1 as [BankName 1],Type_Of_Account1 as [Type of Account 1],Facilities1 as [Facilities 1],BankName2 as [BankName 2]," +
              " Type_Of_Account2 as [Type of Account 2],Facilities2 as [Facilities 2],BankName3 as [BankName 3],Type_Of_Account3 as [Type of Account 3],Facilities3 as [Facilities 3],Sales_In as [Sales in],Avg_Monthly_Turnover as [Avg Monthly Turnover]," +
              " COMPANY_EXISTENCE_YEAR as [Company Existence Seen],Client_List as [Client List],Impression_Of_Office as [Impression of Office],Application_No as [Application No.],Telephone_Bill as [Telephone Bill],Employment_Status as [Employment Status],Years_In_Employment_Business as [Years in Employment]," +
              " Cm_Design as [Applicant Deisgnation],Basic_Salary as [Basic Salary],Transport_Allowance as [Transport Allowance],House_Rent_Allowance as [House Rent Allowance],Fixed_Allowance as [Fixed allowance],Total_Fixed_Salary as [Total Fixed Salary]," +
              " Type_Of_Salary as [Type of Salary],FE_REMARK as [Comments],Employment_Confirmed_With as [Employment Confirmed with],Employment_Confirmed_With_Designation as [Employment Confirmed with Designation],Additional_Comments as [Additional Comments]," +
              " FE.Fullname as [FE Name]," +
              " CONVERT(CHAR(9), Verifier.ATTEMPT_DATE_TIME, 3) + LTRIM(SUBSTRING(CONVERT(VARCHAR(20),Verifier.ATTEMPT_DATE_TIME, 22), 10, 5) + RIGHT(CONVERT(VARCHAR(20), Verifier.ATTEMPT_DATE_TIME, 22), 3)) as [Date of Visit]," +              
              " status_name as [FV Deicision],Credit_Analyst_Decision as [Credit Analyst Decision],Credit_Analyst_Name as [Credit Analyst Name],Credit_Analyst_Date as [Credit Analyst Date]," +
              " SUPERVISOR_ID as [Supervisor Name],SUPERVISOR_REMARKS as [Supervisor Remarks]" +
              " FROM CPV_CC_CASE_OUTPUT_VW CaseOutPut " +
              " left outer join VERIFIER_LAST_ATTEMPT_VW Verifier on CaseOutPut.Case_id=Verifier.Case_id "+
              " and CaseOutPut.Verification_type_id=Verifier.Verification_type_id " +
              " left outer join FE_Vw FE on Verifier.Verifier_id=FE.Emp_ID " +
              " WHERE SEND_DATETIME IS NOT NULL " +
              " AND SEND_DATETIME>='" + strFromDate + "' AND SEND_DATETIME<'" + strToDate + "'" +
              " AND CLIENT_ID='" + strClientId + "' AND CaseOutPut.CENTRE_ID='" + strCentreId + "'";

        return OleDbHelper.ExecuteDataset(objCmn.ConnectionString, CommandType.Text, sSql);
    }

}
