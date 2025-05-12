/*----------------------------------------------------------------------------------------
Scope of Program	:	
File Name			:	CCreditCard.cs
Create By			:	Hemangi Kambli
Create Date		    :	11th April 2007
Remarks 		    :	This class inherits CCPVDetail.cs.
                        This is class used for entrying/modifiying KYC case entry.
						
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
using System.Data.OleDb;
using System.Collections;
using System.IO;

public sealed class CKYC : CCPVDetail
{
    private CCommon objCon;
	public CKYC()
	{
        objCon = new CCommon();
    }

    #region PropertyDeclaration
    private string sVerifierID;
    private string sVerificationTypeId;
    private string sAttemptDateTime;
    private string sAttemptRemark;
    private string sCaseStatusID;

    public string CaseStatusID
    {
        get { return sCaseStatusID; }
        set { sCaseStatusID = value; }
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
    #endregion PropertyDeclaration

    //Name              :   GetCaseIdByRefNo
    //Create By			:	Hemangi Kambli
    //Create Date		:	11th April 2007
    //Remarks 		    :	This method returns CaseId.

    public string GetCaseIdByRefNo(string sRefNo, OleDbTransaction oledbTrans)
    {
        string sSql = "";

        sSql = "Select Case_Id from CPV_KYC_CASE_DETAILS where Ref_No='" + sRefNo + "'";
        DataSet ds = OleDbHelper.ExecuteDataset(oledbTrans, CommandType.Text, sSql);
        if (ds.Tables[0].Rows.Count > 0)
        {
            CaseId = ds.Tables[0].Rows[0]["Case_Id"].ToString();
        }

        return CaseId;
    }

    //Name              :   GetCaseIdByRefNo
    //Create By			:	Hemangi Kambli
    //Create Date		:	11th April 2007
    //Remarks 		    :	This method returns CaseId.

    public string GetCaseIdByRefNo(string sRefNo)
    {
        string sSql = "";

        sSql = "Select Case_Id from CPV_KYC_CASE_DETAILS where Ref_No='" + sRefNo + "'";

        DataSet ds = OleDbHelper.ExecuteDataset(objCon.ConnectionString, CommandType.Text, sSql);
        if (ds.Tables[0].Rows.Count > 0)
        {
            CaseId = ds.Tables[0].Rows[0]["Case_Id"].ToString();
        }
        return CaseId;
    }


    //Name             :   GetKYCCase
    //Create By		   :   Hemangi Kambli
    //Create Date	   :   11th April 2007
    //Remarks 		   :   This method check whether RefNo is already exist or not.

    public OleDbDataReader GetKYCCase(string sCaseID)
    {
        string sSql = "";
        sSql = "Select Case_Id from CPV_KYC_CASE_DETAILS where Case_ID='" + sCaseID + "'";

        return OleDbHelper.ExecuteReader(objCon.ConnectionString, CommandType.Text, sSql);
    }

    //Name             :   GetKYCCaseEntry
    //Create By		   :   Hemangi Kambli
    //Create Date	   :   11th April 2007
    //Remarks 		   :   This method is used to get all details of CreditCardCaseEntry by Case_ID.

    public DataSet GetKYCCaseEntry(string sCaseID)
    {
        string sSql = "";

        sSql = "Select Ref_No,Case_Rec_dateTime,Title,First_Name,Middle_Name,Last_Name,full_Name as Name,DOB,RES_ADD_LINE_1," +
               " RES_ADD_LINE_2,RES_ADD_LINE_3,RES_City,Res_Pin_code,Res_Land_Mark,Res_Phone,OFF_ADD_LINE_1, " +
               " (isnull(RES_ADD_LINE_1,'')+ ' ' + isnull(RES_ADD_LINE_2,'') + ' ' +isnull(RES_ADD_LINE_3,'')+ ' '+isnull(Res_Land_Mark,'')+ ' ' +isnull(RES_City,'')+ ' ' +isnull(Res_Pin_code,'')) as Address, " +
               " OFF_ADD_LINE_2,OFF_ADD_LINE_3,Off_city,Off_Pin_Code,Off_Phone,Off_Extn,Designation," +
               " Department,Occupation from CPV_KYC_CASE_DETAILS Where Case_ID='" + sCaseID + "' and send_datetime is null";
        return OleDbHelper.ExecuteDataset(objCon.ConnectionString, CommandType.Text, sSql);
    }

    //Name             :   GetKYCCaseEntry
    //Create By		   :   Hemangi Kambli
    //Create Date	   :   11th April 2007
    //Remarks 		   :   This method is used to assign select query to the SqlDatasource.
    //                 :   Without Parameter

    public string GetKYCCaseEntry(string sCentreId, string sClientId)
    {
        string sSql = "";

        sSql = "Select Case_ID,Ref_No,Case_Rec_dateTime,Title,(isnull(First_Name,'')+ ' '+isnull(Middle_Name,'')+ ' '+isnull(Last_Name,'')) as Name,DOB,RES_ADD_LINE_1," +
               " RES_ADD_LINE_2,RES_ADD_LINE_3,RES_City,Res_Pin_code,Res_Land_Mark,Res_Phone,OFF_ADD_LINE_1, " +
               " OFF_ADD_LINE_2,OFF_ADD_LINE_3,Off_city,Off_Pin_Code,Off_Phone,Off_Extn,Designation," +
               " Department,Occupation from CPV_KYC_CASE_DETAILS  Where CENTRE_ID='" + sCentreId + "' and Client_ID='" + sClientId + "' and send_datetime is null";
        return sSql;
    }

    //Name             :   GetKYCCaseEntry
    //Create By		   :   Hemangi Kambli
    //Create Date	   :   9th April 2007
    //Remarks 		   :   This method is used to assign select query to the SqlDatasource.
    //                 :   With Parameter for seaching criteria in CreditCardCases

    public string GetKYCCaseEntry(string sRefNo, string sName, bool bChecked, string sFrom, string sTo)
    {
        string sSql = "";
        string FromDate = "";
        string ToDate = "";
        sSql = "Select Case_ID,Ref_No,Case_Rec_dateTime,Title,(isnull(First_Name,'')+ ' '+isnull(Middle_Name,'')+ ' '+isnull(Last_Name,'')) as Name,DOB,RES_ADD_LINE_1," +
               " RES_ADD_LINE_2,RES_ADD_LINE_3,RES_City,Res_Pin_code,Res_Land_Mark,Res_Phone,OFF_ADD_LINE_1, " +
               " OFF_ADD_LINE_2,OFF_ADD_LINE_3,Off_city,Off_Pin_Code,Off_Phone,Off_Extn,Designation," +
               " Department,Occupation from CPV_KYC_CASE_DETAILS WHERE Centre_id='"+CentreId+"' AND Client_id='"+ClientId+"' and send_datetime is null ";

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
        if (sFrom != "" && sTo != "")
        {
            FromDate = objCon.strDate(sFrom);
            ToDate = Convert.ToDateTime(objCon.strDate(sFrom)).AddDays(1.0).ToString("dd-MMM-yyyy");
            FromDate = objCon.strDate(sTo);
            ToDate = Convert.ToDateTime(objCon.strDate(sTo)).AddDays(1.0).ToString("dd-MMM-yyyy");
        }
        ////for Case_Rec_date
        //if (sFrom != "" && sTo != "")
        //{
        //    sSql += " AND (Case_Rec_dateTime BETWEEN '" + Convert.ToDateTime(objCon.FixQuotes(sFrom)).ToString("dd/MM/yyyy") + "'" + "and '" + Convert.ToDateTime(objCon.FixQuotes(sTo)).ToString("dd/MM/yyyy") + "')";
        //}
        //else if (sFrom != "" && sTo == "")
        //{
        //    sSql += " AND (Case_Rec_dateTime BETWEEN '" + Convert.ToDateTime(objCon.FixQuotes(sFrom)).ToString("dd/MM/yyyy") + "'" + "and '" + Convert.ToDateTime(objCon.FixQuotes(sFrom)).ToString("dd/MM/yyyy") + "')";
        //}
        //else if (sFrom == "" && sTo != "")
        //{
        //    sSql += " AND (Case_Rec_dateTime BETWEEN '" + Convert.ToDateTime(objCon.FixQuotes(sTo)).ToString("dd/MM/yyyy") + "'" + "and '" + Convert.ToDateTime(objCon.FixQuotes(sTo)).ToString("dd/MM/yyyy") + "')";
        //}
        ///////////////////////////////////////
        if (FromDate != "" && ToDate != "")
            sSql += " AND (Case_Rec_dateTime >='" + objCon.FixQuotes(FromDate) + "'" + "and Case_Rec_dateTime<'" + objCon.FixQuotes(ToDate) + "')";

        sSql += " ORDER BY CASE_ID DESC";

        return sSql;
      
    }


    public string GetKYCCaseEntry(string sRefNo, string sName, bool bChecked, string sFrom, string sTo, string sCentreId, string sClientId)
    {
        string sSql = "";
        string FromDate = "";
        string ToDate = "";


        sSql = "Select Case_ID,Ref_No,Case_Rec_dateTime,Title,(isnull(First_Name,'')+ ' '+ isnull(Middle_Name,'')+ ' '+isnull(Last_Name,'')) as Name,DOB,RES_ADD_LINE_1," +
               " RES_ADD_LINE_2,RES_ADD_LINE_3,RES_City,Res_Pin_code,Res_Land_Mark,Res_Phone,OFF_ADD_LINE_1, " +
               " OFF_ADD_LINE_2,OFF_ADD_LINE_3,Off_city,Off_Pin_Code,Off_Phone,Off_Extn,Designation," +
               " Department,Occupation from CPV_KYC_CASE_DETAILS WHERE (SEND_DATETIME IS NULL)" +
               " AND CENTRE_ID='" + sCentreId + "'" +
               " AND CLIENT_ID='" + sClientId + "' AND SEND_DATETIME IS NULL";

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

        //for Case_Rec_date

        if (sFrom != "" && sTo == "")
        {
            FromDate = objCon.strDate(sFrom);
            ToDate = Convert.ToDateTime(objCon.strDate(sFrom)).AddDays(1.0).ToString("dd-MMM-yyyy");
        }
         if (sFrom == "" && sTo != "")
        {
            FromDate = objCon.strDate(sTo);
            ToDate = Convert.ToDateTime(objCon.strDate(sTo)).AddDays(1.0).ToString("dd-MMM-yyyy");
        }
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
    }

    //Name             :   DeleteKYCCaseEntry
    //Create By		   :   Hemangi Kambli
    //Create Date	   :   11th April 2007
    //Remarks 		   :   This method is used to delete KYCCaseEntry by RefNo.

    public Int32 DeleteKYCCaseEntry(string sCaseID)
    {
        OleDbConnection oledbConn = new OleDbConnection(objCon.ConnectionString);
        oledbConn.Open();
        OleDbTransaction oledbTrans = oledbConn.BeginTransaction();
        Int32 nretVal = 0;
        string sSql = "";
        try
        {
            sSql = "Delete from CPV_KYC_VERIFICATION_TYPE WHERE Case_Id='" + sCaseID + "'";
            OleDbHelper.ExecuteNonQuery(oledbTrans, CommandType.Text, sSql);

            sSql = "Delete from CPV_KYC_CASE_DETAILS WHERE Case_ID='" + sCaseID + "'";
            nretVal = OleDbHelper.ExecuteNonQuery(oledbTrans, CommandType.Text, sSql);

            oledbTrans.Commit();
            oledbConn.Close();

            return nretVal;
        }
        catch (Exception ex)
        {
            oledbTrans.Rollback();
            oledbConn.Close();
            throw new Exception("Error while deleting CaseKYCEntry " + ex.Message);
        }

    }


    //Name             :   UpdateKYCCaseEntry
    //Create By		   :   Hemangi Kambli
    //Create Date	   :   11th April 2007
    //Remarks 		   :   This method is used to update KYCCaseEntry by RefNo.

    public Int32 UpdateKYCCaseEntry(ArrayList arrCaseVerType, string sCaseID)
    {
        OleDbConnection oledbConn = new OleDbConnection(objCon.ConnectionString);
        oledbConn.Open();
        OleDbTransaction oledbTrans = oledbConn.BeginTransaction();
        Int32 nretVal = 0;
        string sSql = "";
        try
        {
            CaseId = sCaseID;
            sSql = "Update CPV_KYC_CASE_DETAILS SET Case_Rec_dateTime=?, " +
                  "Title=?,First_Name=?,Middle_Name=?,Last_Name=?,Full_Name=?,DOB=?,RES_ADD_LINE_1=?,RES_ADD_LINE_2=?," +
                  "RES_ADD_LINE_3=?,RES_City=?,Res_Pin_code=?,Res_Land_Mark=?,Res_Phone=?,OFF_ADD_LINE_1=?,OFF_ADD_LINE_2=?," +
                  "OFF_ADD_LINE_3=?,Off_city=?,Off_Pin_Code=?,Off_Phone=?,Off_Extn=?,Designation=?," +
                  "Department=?,Occupation=?,Modify_By=?,Modify_Date=?,VERIFICATION_TYPE_ID=? " +
                  " WHERE Case_Id=?";

            OleDbParameter[] paramCreditCard = new OleDbParameter[28];

            paramCreditCard[0] = new OleDbParameter("@Case_Recv_dateTime", OleDbType.DBTimeStamp);
            paramCreditCard[0].Value = ReceivedDateTime;
            paramCreditCard[1] = new OleDbParameter("@Title", OleDbType.VarChar,10);
            paramCreditCard[1].Value = Title;
            paramCreditCard[2] = new OleDbParameter("@First_Name", OleDbType.VarChar,50);
            paramCreditCard[2].Value = FirstName;
            paramCreditCard[3] = new OleDbParameter("@Middle_Name", OleDbType.VarChar,50);
            paramCreditCard[3].Value = MiddleName;
            paramCreditCard[4] = new OleDbParameter("@Last_Name", OleDbType.VarChar,50);
            paramCreditCard[4].Value = LastName;
            paramCreditCard[5] = new OleDbParameter("@Full_Name", OleDbType.VarChar,200);
            paramCreditCard[5].Value = FullName;
            paramCreditCard[6] = new OleDbParameter("@DOB", OleDbType.VarChar,50);
            paramCreditCard[6].Value = DOB;
            paramCreditCard[7] = new OleDbParameter("@RES_ADD_LINE_1", OleDbType.VarChar,100);
            paramCreditCard[7].Value = ResAdd1;
            paramCreditCard[8] = new OleDbParameter("@RES_ADD_LINE_2", OleDbType.VarChar,100);
            paramCreditCard[8].Value = ResAdd2;
            paramCreditCard[9] = new OleDbParameter("@RES_ADD_LINE_3", OleDbType.VarChar,100);
            paramCreditCard[9].Value = ResAdd3;
            paramCreditCard[10] = new OleDbParameter("@RES_City", OleDbType.VarChar,50);
            paramCreditCard[10].Value = ResCity;
            paramCreditCard[11] = new OleDbParameter("@Res_Pin_code", OleDbType.VarChar,10);
            paramCreditCard[11].Value = ResPin;
            paramCreditCard[12] = new OleDbParameter("@Res_Land_Mark", OleDbType.VarChar,50);
            paramCreditCard[12].Value = ResLandMark;
            paramCreditCard[13] = new OleDbParameter("@Res_Phone", OleDbType.VarChar,50);
            paramCreditCard[13].Value = ResPhone;
            paramCreditCard[14] = new OleDbParameter("@OFF_ADD_LINE_1", OleDbType.VarChar,100);
            paramCreditCard[14].Value = OfficeAdd1;
            paramCreditCard[15] = new OleDbParameter("@OFF_ADD_LINE_2", OleDbType.VarChar,100);
            paramCreditCard[15].Value = OfficeAdd2;
            paramCreditCard[16] = new OleDbParameter("@OFF_ADD_LINE_3", OleDbType.VarChar,100);
            paramCreditCard[16].Value = OfficeAdd3;
            paramCreditCard[17] = new OleDbParameter("@Off_city", OleDbType.VarChar,50);
            paramCreditCard[17].Value = OfficeCity;
            paramCreditCard[18] = new OleDbParameter("@Off_Pin_Code", OleDbType.VarChar,10);
            paramCreditCard[18].Value = OfficePin;
            paramCreditCard[19] = new OleDbParameter("@Off_Phone", OleDbType.VarChar,50);
            paramCreditCard[19].Value = OfficePhone;
            paramCreditCard[20] = new OleDbParameter("@Off_Extn", OleDbType.VarChar,10);
            paramCreditCard[20].Value = OfficeExtn;
            paramCreditCard[21] = new OleDbParameter("@Designation", OleDbType.VarChar,50);
            paramCreditCard[21].Value = Designation;
            paramCreditCard[22] = new OleDbParameter("@Department", OleDbType.VarChar,50);
            paramCreditCard[22].Value = Department;
            paramCreditCard[23] = new OleDbParameter("@Occupation", OleDbType.VarChar,50);
            paramCreditCard[23].Value = Occupation;
            paramCreditCard[24] = new OleDbParameter("@Modify_By", OleDbType.VarChar,15);
            paramCreditCard[24].Value = ModifyBy;
            paramCreditCard[25] = new OleDbParameter("@Modify_Date", OleDbType.DBTimeStamp);
            paramCreditCard[25].Value = ModifyOn;
            paramCreditCard[26] = new OleDbParameter("@VerificationTypeID", OleDbType.VarChar, 10);
            paramCreditCard[26].Value = VerificationTypeID;
            paramCreditCard[27] = new OleDbParameter("@Case_Id", OleDbType.VarChar,15);
            paramCreditCard[27].Value = CaseId;

            if (arrCaseVerType.Count > 0)
                OleDbHelper.ExecuteNonQuery(oledbTrans, CommandType.Text, sSql, paramCreditCard);
            else

            nretVal= OleDbHelper.ExecuteNonQuery(oledbTrans, CommandType.Text, sSql, paramCreditCard);

       

            oledbTrans.Commit();
            oledbConn.Close();

            return nretVal;
        }
        catch (Exception ex)
        {
            oledbTrans.Rollback();
            oledbConn.Close();
            throw new Exception("Error while updating CaseKYCEntry " + ex.Message);
        }
    }

    //Function Name    :   InsertKYCCaseEntry
    //Create By		   :   Hemangi Kambli
    //Create Date	   :   11th April 2007
    //Remarks 		   :   This method is used to insert new CreditCardCaseEntry.

    public Int32 InsertKYCCaseEntry(ArrayList arrCaseVerType, string strPrefix)
    {
        OleDbConnection oledbConn = new OleDbConnection(objCon.ConnectionString);
        oledbConn.Open();
        OleDbTransaction oledbTrans = oledbConn.BeginTransaction();
        Int32 nretVal = 0;


        try
        {
            CaseId = objCon.GetUniqueID("CPV_KYC_CASE_DETAILS", strPrefix).ToString();
           

            string sSql = "";
           
            sSql = "Insert into CPV_KYC_CASE_DETAILS(Case_Id,Cluster_Id,Centre_Id,Ref_No,Case_Rec_dateTime, " +
                  "Title,First_Name,Middle_Name,Last_Name,Full_Name,DOB,RES_ADD_LINE_1,RES_ADD_LINE_2," +
                  "RES_ADD_LINE_3,RES_City,Res_Pin_code,Res_Land_Mark,Res_Phone,OFF_ADD_LINE_1,OFF_ADD_LINE_2," +
                  "OFF_ADD_LINE_3,Off_city,Off_Pin_Code,Off_Phone,Off_Extn,Designation,Department,Occupation,Add_By,Add_Date,Client_Id,VERIFICATION_TYPE_ID) " +
                  "Values(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)";


            OleDbParameter[] paramCreditCard = new OleDbParameter[32];

            paramCreditCard[0] = new OleDbParameter("@CaseID", OleDbType.VarChar,15);
            paramCreditCard[0].Value = CaseId;
            paramCreditCard[1] = new OleDbParameter("@Cluster_Id", OleDbType.VarChar,15);
            paramCreditCard[1].Value = ClusterId;
            paramCreditCard[2] = new OleDbParameter("@Centre_Id", OleDbType.VarChar,15);
            paramCreditCard[2].Value = CentreId;
            paramCreditCard[3] = new OleDbParameter("@Ref_No", OleDbType.VarChar,50);
            paramCreditCard[3].Value = RefNo;
            paramCreditCard[4] = new OleDbParameter("@Case_Recv_dateTime", OleDbType.DBTimeStamp);
            paramCreditCard[4].Value = ReceivedDateTime;
            paramCreditCard[5] = new OleDbParameter("@Title", OleDbType.VarChar,10);
            paramCreditCard[5].Value = Title;
            paramCreditCard[6] = new OleDbParameter("@First_Name", OleDbType.VarChar,50);
            paramCreditCard[6].Value = FirstName;
            paramCreditCard[7] = new OleDbParameter("@Middle_Name", OleDbType.VarChar,50);
            paramCreditCard[7].Value = MiddleName;
            paramCreditCard[8] = new OleDbParameter("@Last_Name", OleDbType.VarChar,50);
            paramCreditCard[8].Value = LastName;
            paramCreditCard[9] = new OleDbParameter("@Full_Name", OleDbType.VarChar,200);
            paramCreditCard[9].Value = FullName;
            paramCreditCard[10] = new OleDbParameter("@DOB", OleDbType.VarChar,50);
            paramCreditCard[10].Value = DOB;
            paramCreditCard[11] = new OleDbParameter("@RES_ADD_LINE_1", OleDbType.VarChar,100);
            paramCreditCard[11].Value = ResAdd1;
            paramCreditCard[12] = new OleDbParameter("@RES_ADD_LINE_2", OleDbType.VarChar,100);
            paramCreditCard[12].Value = ResAdd2;
            paramCreditCard[13] = new OleDbParameter("@RES_ADD_LINE_3", OleDbType.VarChar,100);
            paramCreditCard[13].Value = ResAdd3;
            paramCreditCard[14] = new OleDbParameter("@RES_City", OleDbType.VarChar,50);
            paramCreditCard[14].Value = ResCity;
            paramCreditCard[15] = new OleDbParameter("@Res_Pin_code", OleDbType.VarChar,10);
            paramCreditCard[15].Value = ResPin;
            paramCreditCard[16] = new OleDbParameter("@Res_Land_Mark", OleDbType.VarChar,50);
            paramCreditCard[16].Value = ResLandMark;
            paramCreditCard[17] = new OleDbParameter("@Res_Phone", OleDbType.VarChar,50);
            paramCreditCard[17].Value = ResPhone;
            paramCreditCard[18] = new OleDbParameter("@OFF_ADD_LINE_1", OleDbType.VarChar,100);
            paramCreditCard[18].Value = OfficeAdd1;
            paramCreditCard[19] = new OleDbParameter("@OFF_ADD_LINE_2", OleDbType.VarChar,100);
            paramCreditCard[19].Value = OfficeAdd2;
            paramCreditCard[20] = new OleDbParameter("@OFF_ADD_LINE_3", OleDbType.VarChar,100);
            paramCreditCard[20].Value = OfficeAdd3;
            paramCreditCard[21] = new OleDbParameter("@Off_city", OleDbType.VarChar,50);
            paramCreditCard[21].Value = OfficeCity;
            paramCreditCard[22] = new OleDbParameter("@Off_Pin_Code", OleDbType.VarChar,10);
            paramCreditCard[22].Value = OfficePin;
            paramCreditCard[23] = new OleDbParameter("@Off_Phone", OleDbType.VarChar,50);
            paramCreditCard[23].Value = OfficePhone;
            paramCreditCard[24] = new OleDbParameter("@Off_Extn", OleDbType.VarChar,10);
            paramCreditCard[24].Value = OfficeExtn;
            paramCreditCard[25] = new OleDbParameter("@Designation", OleDbType.VarChar,50);
            paramCreditCard[25].Value = Designation;
            paramCreditCard[26] = new OleDbParameter("@Department", OleDbType.VarChar,50);
            paramCreditCard[26].Value = Department;
            paramCreditCard[27] = new OleDbParameter("@Occupation", OleDbType.VarChar,50);
            paramCreditCard[27].Value = Occupation;
            paramCreditCard[28] = new OleDbParameter("@AddedBy", OleDbType.VarChar,15);
            paramCreditCard[28].Value = AddedBy;
            paramCreditCard[29] = new OleDbParameter("@AddedOn", OleDbType.DBTimeStamp);
            paramCreditCard[29].Value = AddedOn;
            paramCreditCard[30] = new OleDbParameter("@Client_Id", OleDbType.VarChar,15);
            paramCreditCard[30].Value = ClientId;
            paramCreditCard[31] = new OleDbParameter("@VerificationTypeID", OleDbType.VarChar, 10);
            paramCreditCard[31].Value = VerificationTypeID;

            nretVal=OleDbHelper.ExecuteNonQuery(oledbTrans, CommandType.Text, sSql, paramCreditCard);

             sSql = "";
           
            sSql = "Insert into CPV_KYC_VERIFICATION_TYPE(Case_Id,VERIFICATION_TYPE_ID) " +
                   " Values(?,?)";

            OleDbParameter[] paramType = new OleDbParameter[2];

            paramType[0] = new OleDbParameter("@CaseID", OleDbType.VarChar,15);
            paramType[0].Value = CaseId;
            paramType[1] = new OleDbParameter("@Cluster_Id", OleDbType.VarChar,10);
            paramType[1].Value = VerificationTypeID;

            nretVal = OleDbHelper.ExecuteNonQuery(oledbTrans, CommandType.Text, sSql, paramType);
            
            
            oledbTrans.Commit();
            oledbConn.Close();

            return nretVal;
        }
        catch (Exception ex)
        {
            oledbTrans.Rollback();
            oledbConn.Close();
            throw new Exception("Error while Inserting CaseKYCEntry " + ex.Message);
        }
    }

    //Name             :   GetRefNo
    //Create By		   :   Hemangi Kambli
    //Create Date	   :   16th April 2007
    //Remarks 		   :   This method check whether KYC case verify detail exist or not.

    public OleDbDataReader GetKYCCaseVerify(string sCaseID)
    {
        string sSql = "";
        sSql = "Select Case_Id from CPV_KYC_VERI_ATTEMPTS where Case_ID='" + sCaseID + "'";

        return OleDbHelper.ExecuteReader(objCon.ConnectionString, CommandType.Text, sSql);
    }


    public DataSet GetAttemptDtl(string sCaseID)
    {
        string sSql = "";
       
        sSql = "SELECT E.EMP_ID , E.FULLNAME, CSM.Case_Status_ID,CSM.STATUS_CODE,CSM.STATUS_NAME, " +
              " VAT.ATTEMPT_DATE_TIME,VAT.REMARK " +
              " FROM CPV_KYC_VERI_ATTEMPTS VAT INNER JOIN CPV_KYC_CASE_DETAILS CD " +
              " ON VAT.CASE_ID = CD.CASE_ID INNER JOIN CASE_STATUS_MASTER CSM ON CSM.CASE_STATUS_ID=CD.CASE_STATUS_ID  " +
              " INNER JOIN EMPLOYEE_MASTER E ON  E.EMP_ID=VAT.VERIFIER_ID WHERE CD.Case_ID='" + sCaseID + "'";

        return OleDbHelper.ExecuteDataset(objCon.ConnectionString, CommandType.Text, sSql);
    }

    public Int32 InsertKYCCaseVerification(ArrayList arrAttempt)
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

                sSql = "Insert into CPV_KYC_VERI_ATTEMPTS(Case_ID,VERIFIER_ID,ATTEMPT_DATE_TIME,REMARK)" +
                        "Values(?,?,?,?)";

                OleDbParameter[] paramAttempt = new OleDbParameter[4];
                paramAttempt[0] = new OleDbParameter("@CaseID", OleDbType.VarChar);
                paramAttempt[0].Value = CaseId;
                paramAttempt[1] = new OleDbParameter("@VerifierID", OleDbType.VarChar);
                paramAttempt[1].Value = VerifierID;
                paramAttempt[2] = new OleDbParameter("@AttemptDateTime", OleDbType.DBTimeStamp);
                paramAttempt[2].Value = AttemptDateTime;
                paramAttempt[3] = new OleDbParameter("@AttemptRemark", OleDbType.VarChar);
                paramAttempt[3].Value = AttemptRemark;

                OleDbHelper.ExecuteNonQuery(oledbTrans, CommandType.Text, sSql, paramAttempt);

            }

            sSql = "";
            sSql1 = "Update CPV_KYC_CASE_DETAILS SET CASE_STATUS_ID=? where Case_ID='" + CaseId + "'";

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
            throw new Exception("An error occurred while executing the InsertKYCCaseVerification()", ex);
        }
    }

    public Int32 UpdateKYCCaseVerification(ArrayList arrAttempt)
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

            sSql = "Delete from CPV_KYC_VERI_ATTEMPTS where Case_Id='" + CaseId + "'";
            OleDbHelper.ExecuteNonQuery(oledbTrans, CommandType.Text, sSql);

            foreach (ArrayList item in arrAttempt)
            {
                AttemptDateTime = item[0].ToString();
                AttemptRemark = item[1].ToString();
               
               sSql = "Insert into CPV_KYC_VERI_ATTEMPTS(Case_ID,VERIFIER_ID,ATTEMPT_DATE_TIME,REMARK)" +
                        "Values(?,?,?,?)";

                OleDbParameter[] paramAttempt = new OleDbParameter[4];
                paramAttempt[0] = new OleDbParameter("@CaseID", OleDbType.VarChar);
                paramAttempt[0].Value = CaseId;
                paramAttempt[1] = new OleDbParameter("@VerifierID", OleDbType.VarChar);
                paramAttempt[1].Value = VerifierID;
                paramAttempt[2] = new OleDbParameter("@AttemptDateTime", OleDbType.DBTimeStamp);
                paramAttempt[2].Value = AttemptDateTime;
                paramAttempt[3] = new OleDbParameter("@AttemptRemark", OleDbType.VarChar);
                paramAttempt[3].Value = AttemptRemark;

                OleDbHelper.ExecuteNonQuery(oledbTrans, CommandType.Text, sSql, paramAttempt);

            }

            sSql = "";
            sSql1 = "Update CPV_KYC_CASE_DETAILS SET CASE_STATUS_ID=? where Case_ID='" + CaseId + "'";

            OleDbParameter[] paramStatus = new OleDbParameter[1];
            paramStatus[0] = new OleDbParameter("@CaseStatusID", OleDbType.VarChar);
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
            throw new Exception("An error occurred while executing the InsertKYCCaseVerification()", ex);
        }
    }

    public string GetVerificationType(string scaseID)
    {
        OleDbConnection oledbConn = new OleDbConnection(objCon.ConnectionString);
        oledbConn.Open();
        string sSql = "";
        sSql = "select verification_type_id from CPV_KYC_VERIFICATION_TYPE where case_id= " + scaseID + " ";
        string rtval = (string)OleDbHelper.ExecuteScalar(objCon.ConnectionString, CommandType.Text, sSql);
        return rtval;
    }
}



