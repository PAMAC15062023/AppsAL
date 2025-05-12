/*----------------------------------------------------------------------------------------
Scope of Program	:	
File Name			:	CEBC.cs
Create By			:	Hemangi Kambli
Create Date		    :	10th April 2007
Remarks 		    :	This class inherits CCPVDetail.cs.
                        This is class used for entrying/modifiying EBC Case Entry.
						
----------------------------------------------------------------------------------------*/

using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Globalization;
using System.Data.OleDb;
using System.Collections;
using System.IO;

public sealed class CEBC : CCPVDetail
{
    private CCommon objCon;

	public CEBC()
	{
        objCon = new CCommon();
    }

    #region Property Declaration
    private string sEmpCode;
    private string sVerifierID;
    private string sVerificationTypeId;
    private string sAttemptDateTime;
    private string sAttemptRemark;
    private char sAddConfirm;
    private string sAddConfirmFrom;
    private string sThirdPartyCon;
    private string sCaseStatusID;
    private DateTime dtDateOfBirth;
    
    public string EmpCode
    {
        get { return sEmpCode; }
        set { sEmpCode = value; }
    }
    public string VerifierID
    {
        get { return sVerifierID; }
        set { sVerifierID = value; }
    }
    public string VerificationTypeID
    {
        get { return sVerificationTypeId; }
        set { sVerificationTypeId = value; }
    }
    public string AttemptDateTime
    {
        get { return sAttemptDateTime; }
        set { sAttemptDateTime = value; }
    }
    public string AttemptRemark
    {
        get { return sAttemptRemark; }
        set { sAttemptRemark = value; }
    }
    public char AddressConfirm
    {
        get { return sAddConfirm; }
        set { sAddConfirm = value; }
    }
    public string AddressConfirmFrom
    {
        get { return sAddConfirmFrom; }
        set { sAddConfirmFrom = value; }
    }
    public string ThirdPartyConfirmation
    {
        get { return sThirdPartyCon; }
        set { sThirdPartyCon = value; }
    }
    public string CaseStatusID
    {
        get { return sCaseStatusID; }
        set { sCaseStatusID = value; }
    }
    #endregion Property Declaration

    //Name              :   GetCaseIdByRefNo
    //Create By			:	Hemangi Kambli
    //Create Date		:	10th April 2007
    //Remarks 		    :	This method returns CaseId.

    public string GetCaseIdByRefNo(string sRefNo, OleDbTransaction oledbTrans)
    {
        string sSql = "";

        sSql = "Select Case_Id from CPV_EBC_CASE_DETAILS where Ref_No='" + sRefNo + "'";
        DataSet ds = OleDbHelper.ExecuteDataset(oledbTrans, CommandType.Text, sSql);
        if (ds.Tables[0].Rows.Count > 0)
        {
            CaseId = ds.Tables[0].Rows[0]["Case_Id"].ToString();
        }

        return CaseId;
    }

    //Name              :   GetCaseIdByRefNo
    //Create By			:	Hemangi Kambli
    //Create Date		:	10th April 2007
    //Remarks 		    :	This method returns CaseId.

    public string GetCaseIdByRefNo(string sRefNo)
    {
        string sSql = "";

        sSql = "Select Case_Id from CPV_EBC_CASE_DETAILS where Ref_No='" + sRefNo + "'";

        DataSet ds = OleDbHelper.ExecuteDataset(objCon.ConnectionString, CommandType.Text, sSql);
        if (ds.Tables[0].Rows.Count > 0)
        {
            CaseId = ds.Tables[0].Rows[0]["Case_Id"].ToString();
        }
        return CaseId;
    }
    
    //Name             :   GetRefNo
    //Create By		   :   Hemangi Kambli
    //Create Date	   :   10th April 2007
    //Remarks 		   :   This method check whether RefNo is already exist or not.

    public OleDbDataReader GetEBCCase(string sCaseID)
    {
        string sSql = "";
        sSql = "Select Case_Id from CPV_EBC_CASE_DETAILS where Case_ID='" + sCaseID + "'";

        return OleDbHelper.ExecuteReader(objCon.ConnectionString, CommandType.Text, sSql);
    }



    //Name             :   UpdateEBCCaseEntry
    //Create By		   :   Hemangi Kambli
    //Create Date	   :   10th April 2007
    //Remarks 		   :   This method is used to get all details of EBCCaseEntry by Case_ID.

    public DataSet GetEBCCaseEntry(string sCaseID)
    {
        string sSql = "";

        sSql = "Select Ref_No,Case_Rec_dateTime,Title,First_Name,Middle_Name,Last_Name,Full_Name as Name,DOB,ADD_LINE_1," +
               " ADD_LINE_2,ADD_LINE_3,City,Pin_code,(ADD_LINE_1+' '+ADD_LINE_2+' '+ADD_LINE_3+' '+City+' '+Pin_Code) as Address, Phone1,Phone2,Emp_Code,Location,Emp_Code " +
               "DATE_OF_JOINING,LOCATION,DESIGNATION,FATHER_NAME,STAFF_NAME, " +
               "Previous_Employer_Name,Previous_Employer_Address,Previous_Designation,Reference_Name_Number,Project " +
               " from CPV_EBC_CASE_DETAILS Where Case_ID='" + sCaseID + "' AND SEND_DATETIME IS NULL";
        return OleDbHelper.ExecuteDataset(objCon.ConnectionString, CommandType.Text, sSql);
    }

    //Name             :   GetCreditCaseEntry
    //Create By		   :   Hemangi Kambli
    //Create Date	   :   10th April 2007
    //Remarks 		   :   This method is used to assign select query to the SqlDatasource.
    //                 :   Without Parameter

    public string GetEBCCaseEntry()
    {
        string sSql = "";

        sSql = "Select Case_ID,Ref_No,Case_Rec_dateTime,Title,First_Name,Middle_Name,Last_Name, Full_Name as Name,DOB,ADD_LINE_1," +
           " ADD_LINE_2,ADD_LINE_3,City,Pin_code,Phone1,Phone2,Emp_Code,Location,Emp_Code,DATE_OF_JOINING,LOCATION,DESIGNATION,FATHER_NAME,STAFF_NAME, " +
           "Previous_Employer_Name,Previous_Employer_Address,Previous_Designation,Reference_Name_Number,Project " +
           " from CPV_EBC_CASE_DETAILS where Centre_id='" + CentreId + "' AND Client_id='" + ClientId + "' AND SEND_DATETIME IS NULL";
        return sSql;
    }

    //Name             :   GetCreditCaseEntry
    //Create By		   :   Hemangi Kambli
    //Create Date	   :   9th April 2007
    //Remarks 		   :   This method is used to assign select query to the SqlDatasource.
    //                 :   With Parameter for seaching criteria in EBCCases

    public string GetEBCCaseEntry(string sRefNo, string sName, bool bChecked, string sFrom, string sTo)
    {
        string sSql = "";
        string FromDate = "";
        string ToDate = "";
        sSql = "Select Case_ID,Ref_No,Case_Rec_dateTime,Title,(First_Name+ ' '+Middle_Name+ ' '+Last_Name) as Name,DOB,ADD_LINE_1," +
               " ADD_LINE_2,ADD_LINE_3,City,Pin_code,Phone1,Phone2,Emp_Code,Location,Emp_code " +
               "DATE_OF_JOINING,LOCATION,DESIGNATION,FATHER_NAME,STAFF_NAME, " +
               "Previous_Employer_Name,Previous_Employer_Address,Previous_Designation,Reference_Name_Number,Project " +
               " from CPV_EBC_CASE_DETAILS WHERE  Centre_id='" + CentreId + "' AND Client_id='" + ClientId + "' AND SEND_DATETIME IS NULL";

        if (sRefNo != "")
        {
            sSql += " AND Ref_No LIKE '%" + objCon.FixQuotes(sRefNo) + "%'";
        }

        if (sName != "")
        {
            if (bChecked == true)
            {
                sSql += " and ((ISNULL(First_Name,'')+ ' '+ ISNULL(Middle_Name,'')+ ' '+ISNULL(Last_Name,'')) ='" + objCon.FixQuotes(sName) + "')";
            }
            else
            {
                sSql += " and ((ISNULL(First_Name,'')+ ' '+ ISNULL(Middle_Name,'')+ ' '+ISNULL(Last_Name,'')) LIKE '%" + objCon.FixQuotes(sName) + "%')";
            }
        }

        ////for Case_Rec_date
        //if (sFrom != "" && sTo == "")
        //{
        //    FromDate = objCon.strDate(sFrom);
        //    ToDate = Convert.ToDateTime(objCon.strDate(sFrom)).AddDays(1.0).ToString("dd-MMM-yyyy");
        //}
        //else if (sFrom == "" && sTo != "")
        //{
        //    FromDate = objCon.strDate(sTo);
        //    ToDate = Convert.ToDateTime(objCon.strDate(sTo)).AddDays(1.0).ToString("dd-MMM-yyyy");
        //}
        if (sFrom != "" && sTo != "")
        {
            FromDate = Convert.ToDateTime(objCon.strDate(sFrom)).ToString("dd-MMM-yyyy");
            //ToDate = Convert.ToDateTime(objCon.strDate(sFrom)).AddDays(1.0).ToString("dd-MMM-yyyy");
            //FromDate = objCon.strDate(sTo);
            ToDate = Convert.ToDateTime(objCon.strDate(sTo)).AddDays(1.0).ToString("dd-MMM-yyyy");
        }
        if (FromDate != "" && ToDate != "")
            sSql += " AND (Case_Rec_dateTime >='" + objCon.FixQuotes(FromDate) + "'" + "and Case_Rec_dateTime<'" + objCon.FixQuotes(ToDate) + "')";

        sSql += " ORDER BY CASE_ID DESC";
        return sSql;
        ///////////////////////////////////////

        return sSql;
    }

    //Name             :   DeleteEBCCaseEntry
    //Create By		   :   Hemangi Kambli
    //Create Date	   :   10th April 2007
    //Remarks 		   :   This method is used to delete EBCCaseEntry by RefNo.

    public Int32 DeleteEBCaseEntry(string sCaseID)
    {
        OleDbConnection oledbConn = new OleDbConnection(objCon.ConnectionString);
        oledbConn.Open();
        OleDbTransaction oledbTrans = oledbConn.BeginTransaction();
        Int32 nretVal = 0;
        string sSql = "";
        try
        {
            sSql = "Delete from CPV_EBC_CASE_DETAILS WHERE Case_ID='" + sCaseID + "'";
            nretVal = OleDbHelper.ExecuteNonQuery(oledbTrans, CommandType.Text, sSql);

            oledbTrans.Commit();
            oledbConn.Close();

            return nretVal;
        }
        catch (Exception ex)
        {
            oledbTrans.Rollback();
            oledbConn.Close();
            throw new Exception("Error while deleting CaseEBCEntry " + ex.Message);
        }

    }


    //Name             :   UpdateEBCCaseEntry
    //Create By		   :   Hemangi Kambli
    //Create Date	   :   10th April 2007
    //Remarks 		   :   This method is used to update EBCCaseEntry by RefNo.

    public Int32 UpdateEBCCaseEntry(string sCaseID)
    {
        OleDbConnection oledbConn = new OleDbConnection(objCon.ConnectionString);
        oledbConn.Open();
        OleDbTransaction oledbTrans = oledbConn.BeginTransaction();
        Int32 nretVal = 0;
        string sSql = "";
        try
        {
            CaseId = sCaseID;
            sSql = "Update CPV_EBC_CASE_DETAILS SET Case_Rec_dateTime=?, " +
                  "Title=?,First_Name=?,Middle_Name=?,Last_Name=?,Full_Name=?,DOB=?,ADD_LINE_1=?,ADD_LINE_2=?," +
                  "ADD_LINE_3=?,City=?,Pin_code=?,Phone1=?,Phone2=?,Emp_Code=?," +
                  "Modify_By=?,Modify_Date=?,DATE_OF_JOINING=?,LOCATION=?,DESIGNATION=?,STAFF_NAME=?,FATHER_NAME=?, " +
                  "Previous_Employer_Name=?,Previous_Employer_Address=?,Previous_Designation=?,Reference_Name_Number=?,Project=? " +
                  " WHERE Case_Id=?";

            OleDbParameter[] paramEBC = new OleDbParameter[28];

            paramEBC[0] = new OleDbParameter("@Case_Recv_dateTime", OleDbType.DBTimeStamp,8);
            paramEBC[0].Value = ReceivedDateTime;
            paramEBC[1] = new OleDbParameter("@Title", OleDbType.VarChar,15);
            paramEBC[1].Value = Title;
            paramEBC[2] = new OleDbParameter("@First_Name", OleDbType.VarChar,100);
            paramEBC[2].Value = FirstName;
            paramEBC[3] = new OleDbParameter("@Middle_Name", OleDbType.VarChar,100);
            paramEBC[3].Value = MiddleName;
            paramEBC[4] = new OleDbParameter("@Last_Name", OleDbType.VarChar,100);
            paramEBC[4].Value = LastName;
            paramEBC[5] = new OleDbParameter("@Full_Name", OleDbType.VarChar,200);
            paramEBC[5].Value = FullName;
            paramEBC[6] = new OleDbParameter("@DateOfBirth", OleDbType.VarChar,50);
            paramEBC[6].Value = DOB ;
            paramEBC[7] = new OleDbParameter("@ADD1", OleDbType.VarChar,100);
            paramEBC[7].Value = ResAdd1;
            paramEBC[8] = new OleDbParameter("@ADD2", OleDbType.VarChar,100);
            paramEBC[8].Value = ResAdd2;
            paramEBC[9] = new OleDbParameter("@ADD3", OleDbType.VarChar,100);
            paramEBC[9].Value = ResAdd3;
            paramEBC[10] = new OleDbParameter("@City", OleDbType.VarChar,50);
            paramEBC[10].Value = ResCity;
            paramEBC[11] = new OleDbParameter("@Pin_code", OleDbType.VarChar,10);
            paramEBC[11].Value = ResPin;
            paramEBC[12] = new OleDbParameter("@Phone1", OleDbType.VarChar,50);
            paramEBC[12].Value = ResPhone;
            paramEBC[13] = new OleDbParameter("@Phone2", OleDbType.VarChar,50);
            paramEBC[13].Value = OfficePhone;
            paramEBC[14] = new OleDbParameter("@Emp_Code", OleDbType.VarChar,10);
            paramEBC[14].Value = EmpCode;
            paramEBC[15] = new OleDbParameter("@Modify_By", OleDbType.VarChar,15);
            paramEBC[15].Value = ModifyBy;
            paramEBC[16] = new OleDbParameter("@Modify_Date", OleDbType.DBTimeStamp);
            paramEBC[16].Value = ModifyOn;
            paramEBC[17] = new OleDbParameter("@DOJ", OleDbType.VarChar,50);
            paramEBC[17].Value = DOJ;
            paramEBC[18] = new OleDbParameter("@Location", OleDbType.VarChar,50);
            paramEBC[18].Value = Location;
            paramEBC[19] = new OleDbParameter("@Designamtion", OleDbType.VarChar,100);
            paramEBC[19].Value = Designation1;
            paramEBC[20] = new OleDbParameter("@StaffName", OleDbType.VarChar,100);
            paramEBC[20].Value = StaffName;
            paramEBC[21] = new OleDbParameter("@FatherName", OleDbType.VarChar,100);
            paramEBC[21].Value =FathersName;
            paramEBC[22] = new OleDbParameter("@PreEmpName", OleDbType.VarChar,100);
            paramEBC[22].Value = PreEmpName;
            paramEBC[23] = new OleDbParameter("@PreEmpAdd", OleDbType.VarChar,255);
            paramEBC[23].Value = PreEmpAdd;
            paramEBC[24] = new OleDbParameter("@PreEmpDesignation", OleDbType.VarChar,100);
            paramEBC[24].Value = PreviousDesignation;
            paramEBC[25] = new OleDbParameter("@RefNameNo", OleDbType.VarChar,100);
            paramEBC[25].Value =RefNameNum ;
            paramEBC[26] = new OleDbParameter("@Project", OleDbType.VarChar,100);
            paramEBC[26].Value = Project;
            paramEBC[27] = new OleDbParameter("@Case_Id", OleDbType.VarChar,15);
            paramEBC[27].Value = CaseId;

            nretVal= OleDbHelper.ExecuteNonQuery(oledbTrans, CommandType.Text, sSql, paramEBC);
            sSql = "Delete from CPV_EBC_VAERIFICATION_TYPE WHERE Case_Id='" + CaseId + "'";
            OleDbHelper.ExecuteNonQuery(oledbTrans, CommandType.Text, sSql);

            sSql = "insert into CPV_EBC_VAERIFICATION_TYPE (case_id,verification_type_id) values(?,?)";
            OleDbParameter[] paramVeri = new OleDbParameter[2];

            paramVeri[0] = new OleDbParameter("@CaseID", OleDbType.VarChar, 15);
            paramVeri[0].Value = CaseId;
            paramVeri[1] = new OleDbParameter("@Cluster_Id", OleDbType.VarChar, 15);
            paramVeri[1].Value = VerificationTypeID;
            nretVal = OleDbHelper.ExecuteNonQuery(oledbTrans, CommandType.Text, sSql, paramVeri);
            oledbTrans.Commit();
            oledbConn.Close();

            return nretVal;
        }
        catch (Exception ex)
        {
            oledbTrans.Rollback();
            oledbConn.Close();
            throw new Exception("Error while updating CaseEBCEntry " + ex.Message);
        }
    }

    //Function Name    :   InsertEBCCaseEntry
    //Create By		   :   Hemangi Kambli
    //Create Date	   :   6th April 2007
    //Remarks 		   :   This method is used to insert new EBCCaseEntry.

    public Int32 InsertEBCCaseEntry(string strPrefix)
    {
        OleDbConnection oledbConn = new OleDbConnection(objCon.ConnectionString);
        oledbConn.Open();
        OleDbTransaction oledbTrans = oledbConn.BeginTransaction();
        Int32 nretVal = 0;


        try
        {
            CaseId = objCon.GetUniqueID("CPV_EBC_CASE_DETAILS", strPrefix).ToString();

            string sSql = "";

            sSql = "Insert into CPV_EBC_CASE_DETAILS(Case_Id,Cluster_Id,Centre_Id,Ref_No,Case_Rec_dateTime, " +
                  "Title,First_Name,Middle_Name,Last_Name,Full_Name,DOB,ADD_LINE_1,ADD_LINE_2," +
                  "ADD_LINE_3,City,Pin_code,Phone1,Phone2,Emp_Code,Add_By,Add_Date,Client_ID,"+
                  " DATE_OF_JOINING,LOCATION,DESIGNATION,FATHER_NAME,STAFF_NAME," +
                  "Previous_Employer_Name,Previous_Employer_Address,Previous_Designation,Reference_Name_Number,Project)" +
                  "Values(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)";


            OleDbParameter[] paramEBC = new OleDbParameter[32];

            paramEBC[0] = new OleDbParameter("@CaseID", OleDbType.VarChar,15);
            paramEBC[0].Value = CaseId;
            paramEBC[1] = new OleDbParameter("@Cluster_Id", OleDbType.VarChar,15);
            paramEBC[1].Value = ClusterId;
            paramEBC[2] = new OleDbParameter("@Centre_Id", OleDbType.VarChar,15);
            paramEBC[2].Value = CentreId;            
            paramEBC[3] = new OleDbParameter("@Ref_No", OleDbType.VarChar,15);
            paramEBC[3].Value = RefNo;
            paramEBC[4] = new OleDbParameter("@Case_Recv_dateTime", OleDbType.DBTimeStamp,8);
            paramEBC[4].Value = ReceivedDateTime;
            paramEBC[5] = new OleDbParameter("@Title", OleDbType.VarChar,50);
            paramEBC[5].Value = Title;
            paramEBC[6] = new OleDbParameter("@First_Name", OleDbType.VarChar,100);
            paramEBC[6].Value = FirstName;
            paramEBC[7] = new OleDbParameter("@Middle_Name", OleDbType.VarChar,100);
            paramEBC[7].Value = MiddleName;
            paramEBC[8] = new OleDbParameter("@Last_Name", OleDbType.VarChar);
            paramEBC[8].Value = LastName;
            paramEBC[9] = new OleDbParameter("@Full_Name", OleDbType.VarChar,200);
            paramEBC[9].Value = FullName;
            paramEBC[10] = new OleDbParameter("@DateOfBirth", OleDbType.VarChar,50);
            paramEBC[10].Value = DOB;
            paramEBC[11] = new OleDbParameter("@ADD1", OleDbType.VarChar,100);
            paramEBC[11].Value = ResAdd1;
            paramEBC[12] = new OleDbParameter("@ADD2", OleDbType.VarChar,100);
            paramEBC[12].Value = ResAdd2;
            paramEBC[13] = new OleDbParameter("@ADD3", OleDbType.VarChar,100);
            paramEBC[13].Value = ResAdd3;
            paramEBC[14] = new OleDbParameter("@City", OleDbType.VarChar,50);
            paramEBC[14].Value = ResCity;
            paramEBC[15] = new OleDbParameter("@Pin_code", OleDbType.VarChar,10);
            paramEBC[15].Value = ResPin;
            paramEBC[16] = new OleDbParameter("@Phone1", OleDbType.VarChar,50);
            paramEBC[16].Value = ResPhone;
            paramEBC[17] = new OleDbParameter("@Phone2", OleDbType.VarChar,50);
            paramEBC[17].Value = OfficePhone;
            paramEBC[18] = new OleDbParameter("@Emp_Code", OleDbType.VarChar,10);
            paramEBC[18].Value = EmpCode;
            paramEBC[19] = new OleDbParameter("@AddedBy", OleDbType.VarChar,15);
            paramEBC[19].Value = AddedBy;
            paramEBC[20] = new OleDbParameter("@AddedOn", OleDbType.DBTimeStamp,8);
            paramEBC[20].Value = AddedOn;
            paramEBC[21] = new OleDbParameter("@Client_Id", OleDbType.VarChar,15);
            paramEBC[21].Value = ClientId;
            paramEBC[22] = new OleDbParameter("@DOJ", OleDbType.VarChar,50);
            paramEBC[22].Value = DOJ;
            paramEBC[23] = new OleDbParameter("@Location", OleDbType.VarChar,50);
            paramEBC[23].Value = Location;
            paramEBC[24] = new OleDbParameter("@Designation1", OleDbType.VarChar,100);
            paramEBC[24].Value = Designation1;
            paramEBC[25] = new OleDbParameter("@FatherName", OleDbType.VarChar,100);
            paramEBC[25].Value = FathersName;
            paramEBC[26] = new OleDbParameter("@StaffName", OleDbType.VarChar,100);
            paramEBC[26].Value = StaffName;
            paramEBC[27] = new OleDbParameter("@PreviousEmployerName", OleDbType.VarChar,100);
            paramEBC[27].Value = PreEmpName;
            paramEBC[28] = new OleDbParameter("@PreviousEmployerAdd", OleDbType.VarChar,255);
            paramEBC[28].Value = PreEmpAdd;
            paramEBC[29] = new OleDbParameter("@PreviousDesignation", OleDbType.VarChar,100);
            paramEBC[29].Value = PreviousDesignation;
            paramEBC[30] = new OleDbParameter("@RefNameNo", OleDbType.VarChar,100);
            paramEBC[30].Value = RefNameNum;
            paramEBC[31] = new OleDbParameter("@Project", OleDbType.VarChar,100);
            paramEBC[31].Value = Project;

            nretVal= OleDbHelper.ExecuteNonQuery(oledbTrans, CommandType.Text, sSql, paramEBC);
            sSql = "insert into CPV_EBC_VAERIFICATION_TYPE (case_id,verification_type_id) values(?,?)";
            OleDbParameter[] paramVeri = new OleDbParameter[2];

            paramVeri[0] = new OleDbParameter("@CaseID", OleDbType.VarChar, 15);
            paramVeri[0].Value = CaseId;
            paramVeri[1] = new OleDbParameter("@Cluster_Id", OleDbType.VarChar, 15);
            paramVeri[1].Value = VerificationTypeID;
            nretVal = OleDbHelper.ExecuteNonQuery(oledbTrans, CommandType.Text, sSql, paramVeri);
            oledbTrans.Commit();
            oledbConn.Close();

            return nretVal;
        }
        catch (Exception ex)
        {
            oledbTrans.Rollback();
            oledbConn.Close();
            throw new Exception("Error while Inserting CaseEBCEntry " + ex.Message);
        }
    }

    //Name             :   GetRefNo
    //Create By		   :   Hemangi Kambli
    //Create Date	   :   14th April 2007
    //Remarks 		   :   This method check whether EBC case verify detail exist or not.

    public OleDbDataReader GetEBCCaseVerify(string sCaseID)
    {
        string sSql = "";
        sSql = "Select Case_Id from CPV_EBC_VERI_ATTEMPTS where Case_ID='" + sCaseID + "'";

        return OleDbHelper.ExecuteReader(objCon.ConnectionString, CommandType.Text, sSql);
    }

    public string GetVerifier(string sRoleID)
    {
        string sSql = "";

        sSql = "SELECT E.EMP_ID, E.FirstName + ' ' + E.LastName AS Name " +
              " FROM EMPLOYEE_MASTER E INNER JOIN USER_MASTER U ON E.EMP_ID = U.userid Inner JOIN " +
              " USER_ROLE UR ON E.EMP_ID = UR.USER_ID where UR.Role_ID='" + sRoleID + "' " +
              " ORDER BY E.FirstName";

        return sSql;
    }

    public DataSet GetAttemptDtl(string sCaseID)
    {
        string sSql = "";
        //sSql = "SELECT E.EMP_ID, E.FULLNAME,CSM.CASE_STATUS_ID,CSM.STATUS_CODE,CSM.STATUS_NAME, VM.VERIFICATION_TYPE_ID," +
        //      " VM.VERIFICATION_TYPE_CODE,VM.VERIFICATION_TYPE,VAT.ATTEMPT_DATE_TIME,VAT.REMARK, VAT.ADDRESS_CONFIRM, " +
        //      " VAT.ADDRESS_CONFIRM_FROM, VAT.THIRD_PARTY_CONFIRMATION " +
        //      " FROM CPV_EBC_VERI_ATTEMPTS VAT INNER JOIN CPV_EBC_CASE_DETAILS CD ON VAT.CASE_ID = CD.CASE_ID " +
        //      " INNER JOIN CASE_STATUS_MASTER CSM ON CSM.CASE_STATUS_ID=CD.CASE_STATUS_ID " +
        //      " INNER JOIN VERIFICATION_TYPE_MASTER VM ON VAT.VERIFICATION_TYPE_ID=VM.VERIFICATION_TYPE_ID " +
        //      " INNER JOIN EMPLOYEE_MASTER E ON  E.EMP_ID=VAT.VERIFIER_ID WHERE CD.Case_ID='" + sCaseID + "'";

        sSql = "SELECT E.EMP_ID , E.FULLNAME, CSM.Case_Status_ID,CSM.STATUS_CODE,CSM.STATUS_NAME, " +
              " VAT.ATTEMPT_DATE_TIME,VAT.REMARK, VAT.ADDRESS_CONFIRM,  VAT.ADDRESS_CONFIRM_FROM, " +
              " VAT.THIRD_PARTY_CONFIRMATION  FROM CPV_EBC_VERI_ATTEMPTS VAT INNER JOIN CPV_EBC_CASE_DETAILS CD " +
              " ON VAT.CASE_ID = CD.CASE_ID INNER JOIN CASE_STATUS_MASTER CSM ON CSM.CASE_STATUS_ID=CD.CASE_STATUS_ID  " +
              " INNER JOIN EMPLOYEE_MASTER E ON  E.EMP_ID=VAT.VERIFIER_ID WHERE CD.Case_ID='" + sCaseID + "'";

        return OleDbHelper.ExecuteDataset(objCon.ConnectionString, CommandType.Text, sSql);
    }

    public Int32 InsertEBCCaseVerification(ArrayList arrAttempt)
    {
        OleDbConnection oledbConn = new OleDbConnection(objCon.ConnectionString);
        oledbConn.Open();
        OleDbTransaction oledbTrans = oledbConn.BeginTransaction();
        Int32 retVal = 0;
        //OleDbDataReader oledbRead = GetCaseStatusDtl(CaseID);
        try
        {
            string sSql = "";
            string sSql1 = "";

            foreach (ArrayList item in arrAttempt)
            {   
                AttemptDateTime = item[0].ToString();
                AttemptRemark = item[1].ToString();
                AddressConfirm = Convert.ToChar(item[2]);
                AddressConfirmFrom = item[3].ToString();
                ThirdPartyConfirmation = item[4].ToString();

                sSql = "Insert into CPV_EBC_VERI_ATTEMPTS(Case_ID,VERIFIER_ID,ATTEMPT_DATE_TIME,REMARK,ADDRESS_CONFIRM,ADDRESS_CONFIRM_FROM,THIRD_PARTY_CONFIRMATION)" +
                        "Values(?,?,?,?,?,?,?)";

                OleDbParameter[] paramAttempt = new OleDbParameter[7];
                paramAttempt[0] = new OleDbParameter("@CaseID", OleDbType.VarChar);
                paramAttempt[0].Value = CaseId;
                paramAttempt[1] = new OleDbParameter("@VerifierID", OleDbType.VarChar);
                paramAttempt[1].Value = VerifierID;
                paramAttempt[2] = new OleDbParameter("@AttemptDateTime", OleDbType.DBTimeStamp);
                paramAttempt[2].Value = AttemptDateTime;
                paramAttempt[3] = new OleDbParameter("@AttemptRemark", OleDbType.VarChar);
                paramAttempt[3].Value = AttemptRemark;
                paramAttempt[4] = new OleDbParameter("@ADDRESS_CONFIRM", OleDbType.Char);
                paramAttempt[4].Value = AddressConfirm;
                paramAttempt[5] = new OleDbParameter("@ADDRESS_CONFIRM_FROM", OleDbType.VarChar);
                paramAttempt[5].Value = AddressConfirmFrom;
                paramAttempt[6] = new OleDbParameter("@THIRD_PARTY_CONFIRMATION", OleDbType.VarChar);
                paramAttempt[6].Value = ThirdPartyConfirmation;
               
                OleDbHelper.ExecuteNonQuery(oledbTrans, CommandType.Text, sSql, paramAttempt);

            }
            
            sSql = "";
            sSql1 = "Update CPV_EBC_CASE_DETAILS SET CASE_STATUS_ID=? where Case_ID='" + CaseId + "'";

            OleDbParameter[] paramStatus = new OleDbParameter[1];
            paramStatus[0] = new OleDbParameter("@CaseStatusID", SqlDbType.NVarChar);
            paramStatus[0].Value = CaseStatusID;

            retVal = OleDbHelper.ExecuteNonQuery(oledbTrans, CommandType.Text, sSql1, paramStatus);
            
            oledbTrans.Commit();
            oledbConn.Close();

            return retVal;
        }
        catch (Exception ex)
        {
           
            oledbTrans.Rollback();
            oledbConn.Close();
            throw new Exception("An error occurred while executing the InsertEBCCaseVerification()", ex);
        }
    }

    public Int32 UpdateEBCCaseVerification(ArrayList arrAttempt)
    {
        OleDbConnection oledbConn = new OleDbConnection(objCon.ConnectionString);
        oledbConn.Open();
        OleDbTransaction oledbTrans = oledbConn.BeginTransaction();
        Int32 retVal = 0;
        //OleDbDataReader oledbRead = GetCaseStatusDtl(CaseID);
        try
        {
            string sSql = "";
            string sSql1 = "";

            sSql = "Delete from CPV_EBC_VERI_ATTEMPTS where Case_Id='" + CaseId + "'";
            OleDbHelper.ExecuteNonQuery(oledbTrans, CommandType.Text, sSql);

            foreach (ArrayList item in arrAttempt)
            {
                AttemptDateTime = item[0].ToString();
                AttemptRemark = item[1].ToString();
                AddressConfirm = Convert.ToChar(item[2]);
                AddressConfirmFrom = item[3].ToString();
                ThirdPartyConfirmation = item[4].ToString();
             
                sSql = "Insert into CPV_EBC_VERI_ATTEMPTS(Case_ID,VERIFIER_ID,ATTEMPT_DATE_TIME,REMARK,ADDRESS_CONFIRM,ADDRESS_CONFIRM_FROM,THIRD_PARTY_CONFIRMATION)" +
                        "Values(?,?,?,?,?,?,?)";

                OleDbParameter[] paramAttempt = new OleDbParameter[7];
                paramAttempt[0] = new OleDbParameter("@CaseID", OleDbType.VarChar);
                paramAttempt[0].Value = CaseId;
                paramAttempt[1] = new OleDbParameter("@VerifierID", OleDbType.VarChar);
                paramAttempt[1].Value = VerifierID;
                paramAttempt[2] = new OleDbParameter("@AttemptDateTime", OleDbType.DBTimeStamp);
                paramAttempt[2].Value = AttemptDateTime;
                paramAttempt[3] = new OleDbParameter("@AttemptRemark", OleDbType.VarChar);
                paramAttempt[3].Value = AttemptRemark;
                paramAttempt[4] = new OleDbParameter("@ADDRESS_CONFIRM", OleDbType.Char);
                paramAttempt[4].Value = AddressConfirm;
                paramAttempt[5] = new OleDbParameter("@ADDRESS_CONFIRM_FROM", OleDbType.VarChar);
                paramAttempt[5].Value = AddressConfirmFrom;
                paramAttempt[6] = new OleDbParameter("@THIRD_PARTY_CONFIRMATION", OleDbType.VarChar);
                paramAttempt[6].Value = ThirdPartyConfirmation;

                OleDbHelper.ExecuteNonQuery(oledbTrans, CommandType.Text, sSql, paramAttempt);

            }

            sSql = "";
            sSql1 = "Update CPV_EBC_CASE_DETAILS SET CASE_STATUS_ID=? where Case_ID='" + CaseId + "'";

            OleDbParameter[] paramStatus = new OleDbParameter[1];
            paramStatus[0] = new OleDbParameter("@CaseStatusID", SqlDbType.NVarChar);
            paramStatus[0].Value = CaseStatusID;

            retVal = OleDbHelper.ExecuteNonQuery(oledbTrans, CommandType.Text, sSql1, paramStatus);

            oledbTrans.Commit();
            oledbConn.Close();

            return retVal;
        }
        catch (Exception ex)
        {

            oledbTrans.Rollback();
            oledbConn.Close();
            throw new Exception("An error occurred while executing the InsertEBCCaseVerification()", ex);
        }
    }
    public void InsertQualification()
    {
        OleDbConnection oledbConn = new OleDbConnection(objCon.ConnectionString);
        oledbConn.Open();
        OleDbTransaction oledbTrans = oledbConn.BeginTransaction();
       
        string sSql = "";
      
        try
        {     
            
            sSql = "insert into CPV_EBC_CASE_QUALIFICATION (case_id,Qualification,Specialization,University,Roll_No,Year_Passing) values(?,?,?,?,?,?)";
            OleDbParameter[] paramQualification = new OleDbParameter[6];
            paramQualification[0] = new OleDbParameter("@CaseID", OleDbType.VarChar,15);
            paramQualification[0].Value = CaseId;
            paramQualification[1] = new OleDbParameter("@Qualification", OleDbType.VarChar,50);
            paramQualification[1].Value = Qualification;
            paramQualification[2] = new OleDbParameter("@Specilization", OleDbType.VarChar,100);
            paramQualification[2].Value = Specilization;
            paramQualification[3] = new OleDbParameter("@University", OleDbType.VarChar,100);
            paramQualification[3].Value = University;
            paramQualification[4] = new OleDbParameter("@Roll_No", OleDbType.VarChar,50);
            paramQualification[4].Value = RollNo;
            paramQualification[5] = new OleDbParameter("@Year_Passing", OleDbType.VarChar,50);
            paramQualification[5].Value = YearOfPassing;
            OleDbHelper.ExecuteNonQuery(oledbTrans, CommandType.Text, sSql, paramQualification);
            oledbTrans.Commit();
            oledbConn.Close();
        }
        catch (Exception ex)
        {
            oledbTrans.Rollback();
            oledbConn.Close();
            throw new Exception("An error occurred while inserting the value of Qualification", ex);
        }
    }
    public void DeleteQualiRecord()
    {
        OleDbConnection oledbConn = new OleDbConnection(objCon.ConnectionString);
        oledbConn.Open();
        OleDbTransaction oledbTrans = oledbConn.BeginTransaction();
        string sSql1 = "";
        try
        {
            sSql1 = "delete from CPV_EBC_CASE_QUALIFICATION where case_id='" + CaseId + "' ";
            OleDbHelper.ExecuteNonQuery(oledbTrans, CommandType.Text, sSql1);
            oledbTrans.Commit();
            oledbConn.Close();
        }
        catch (Exception ex)
        {
            oledbTrans.Rollback();
            oledbConn.Close();
            throw new Exception("An error occurred while Deleting the value of Qualification", ex);
        }
    }
    public OleDbDataReader GetQualification(string sCaseID)
    {
        OleDbConnection oledbConn = new OleDbConnection(objCon.ConnectionString);
        oledbConn.Open();
        OleDbTransaction oledbTrans = oledbConn.BeginTransaction();
        string sSql = "";

        sSql = "select Qualification,Specialization,University,Roll_No,Year_Passing from CPV_EBC_CASE_QUALIFICATION where case_id='" + sCaseID + "' ";
        return OleDbHelper.ExecuteReader(objCon.ConnectionString, CommandType.Text, sSql);
    }
    public string  GetVerificationType(string scaseID)
    {
        OleDbConnection oledbConn = new OleDbConnection(objCon.ConnectionString);
        oledbConn.Open();
        string sSql = "";
        sSql="select verification_type_id from CPV_EBC_VAERIFICATION_TYPE where case_id= " + scaseID + " ";
        string rtval =(string) OleDbHelper.ExecuteScalar(objCon.ConnectionString, CommandType.Text, sSql);
        return rtval;
    }
}

