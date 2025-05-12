/*----------------------------------------------------------------------------------------
Scope of Program	:	
File Name			:	CCreditCard.cs
Create By			:	Hemangi Kambli
Create Date		    :	7th April 2007
Remarks 		    :	This class inherits CCPVDetail.cs.
                        This is class used for entrying/modifiying creditCard case entry.
						
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

public sealed class CCreditCard : CCPVDetail
{
    private CCommon objCon;

	public CCreditCard()
	{
        objCon = new CCommon();
    }

    #region Property Declaration

    private string sVerTypeId;
    private string sDeclineCode;
    private string sDeclineReason;
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

    public string DeclineCode
    {
        get { return sDeclineCode; }
        set { sDeclineCode = value; }
    }

    public string DeclineReason
    {
        get { return sDeclineReason; }
        set { sDeclineReason = value; }
    }

    public string VerifierID
    {
        get { return sVerifierID; }
        set { sVerifierID = value; }
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
    public string VerficationTypeID
    {
        get { return sVerTypeId; }
        set { sVerTypeId = value; }
    }

    #endregion Property Declaration

    //Name              :   GetCaseVerificationType
    //Create By			:	Hemangi Kambli
    //Create Date		:	7th April 2007
    //Remarks 		    :	This return dataset for Verification_Type_Id, Verification_Type_code

    public DataSet GetCaseVerificationType(string sActivityD)
    {
        string sSql = "";
        sSql = "Select Verification_Type_Id, Verification_Type_code from Verification_Type_Master where ACTIVITY_ID='" + sActivityD + "'" +
                " AND VERIFICATION_TYPE_ID IN(1,2,4,3,10) ";
        return OleDbHelper.ExecuteDataset(objCon.ConnectionString, CommandType.Text, sSql);
    }

    //Name              :   GetCaseIdByRefNo
    //Create By			:	Hemangi Kambli
    //Create Date		:	7th April 2007
    //Remarks 		    :	This method returns CaseId.

    public string GetCaseIdByRefNo(string sRefNo, OleDbTransaction oledbTrans)
    {
        string sSql = "";

        sSql = "Select Case_Id from CPV_CC_CASE_DETAILS where Ref_No='" + sRefNo + "'";
        DataSet ds = OleDbHelper.ExecuteDataset(oledbTrans, CommandType.Text, sSql);
        if (ds.Tables[0].Rows.Count > 0)
        {
            CaseId = ds.Tables[0].Rows[0]["Case_Id"].ToString();
        }

        return CaseId;
    }

    //Name              :   GetCaseIdByRefNo
    //Create By			:	Hemangi Kambli
    //Create Date		:	7th April 2007
    //Remarks 		    :	This method returns CaseId.

    public string GetCaseIdByRefNo(string sRefNo)
    {
        string sSql = "";

        sSql = "Select Case_Id from CPV_CC_CASE_DETAILS where Ref_No='" + sRefNo + "'";

        DataSet ds = OleDbHelper.ExecuteDataset(objCon.ConnectionString, CommandType.Text, sSql);
        if (ds.Tables[0].Rows.Count > 0)
        {
            CaseId = ds.Tables[0].Rows[0]["Case_Id"].ToString();
        }
        return CaseId;
    }

    //Name             :   GetAllVerificationId
    //Create By		   :   Hemangi Kambli
    //Create Date	   :   7th April 2007
    //Remarks 		   :   This method is used to get verification id.

    public DataSet GetAllVerificationId(string sCaseID)
    {
        string sSql = "";
        sSql = "Select Verification_Type_ID from CPV_CC_CASE_VERIFICATIONTYPE where Case_Id='" + sCaseID + "'";

        return OleDbHelper.ExecuteDataset(objCon.ConnectionString, CommandType.Text, sSql);
    }

    //Name             :   GetRefNo
    //Create By		   :   Hemangi Kambli
    //Create Date	   :   7th April 2007
    //Remarks 		   :   This method check whether RefNo is already exist or not.

    public OleDbDataReader GetCreditCase(string sCaseID)
    {
        string sSql = "";
        sSql = "Select Case_Id from CPV_CC_CASE_DETAILS where Case_ID='" + sCaseID + "'";

        return OleDbHelper.ExecuteReader(objCon.ConnectionString, CommandType.Text, sSql);
    }


    //Name             :   UpdateCreditCardCaseEntry
    //Create By		   :   Hemangi Kambli
    //Create Date	   :   7th April 2007
    //Remarks 		   :   This method is used to get all details of CreditCardCaseEntry by Case_ID.

    public DataSet GetCreditCaseEntry(string sCaseID, string sCentreId, string sClientId)
    {
        string sSql = "";

        sSql = "Select Ref_No,CASE_TYPE,Case_Rec_dateTime,Title,First_Name,Middle_Name,Last_Name,DOB," +
                "RES_ADD_LINE_1, RES_ADD_LINE_2,RES_ADD_LINE_3,RES_City,RES_STATE,Res_Pin_code,Res_Land_Mark," +
                "Res_Phone,MOBILE,OFF_NAME,OFF_ADD_LINE_1,  OFF_ADD_LINE_2,OFF_ADD_LINE_3,Off_city," +
                "OFF_STATE,Off_Pin_Code,Off_Phone,Off_Extn,Designation,(ISNULL(RES_ADD_LINE_1,'') + ' ' + " +
                "ISNULL(RES_ADD_LINE_2,'')+ ' ' + ISNULL(RES_ADD_LINE_3,'')+' ' + ISNULL(Res_Land_Mark,'')" +
                "+' '+ISNULL(RES_City,'')+''+ISNULL(RES_STATE,'')+' '+ ISNULL(Res_Pin_code,'')) AS ADDRESS," +
                "ISNULL(First_Name,'')+ ' '+ISNULL(Middle_Name,'')+ ' '+ISNULL(Last_Name,'') + ' ' " +
                "+ISNULL(RES_ADD_LINE_1,'')+' '+ISNULL(RES_ADD_LINE_2,'')+' '+ISNULL(RES_ADD_LINE_3,'')+' '" +
                "+ISNULL(RES_LAND_MARK,'')+' ' + ISNULL(RES_CITY,'')+ ' ' +ISNULL(RES_PIN_CODE,'')" +
                "as SMSContent, Department,Full_Name as Name,Occupation,PRIORITY,REGION,SPL_INSTRUCTION," +
                "PMT_ADD_LINE_1,PMT_ADD_LINE_2,PMT_ADD_LINE_3,PMT_CITY,PMT_STATE,PMT_PIN_CODE,PMT_LANDMARK," +
                "PMT_PHONE from CPV_CC_CASE_DETAILS Where Case_ID='" + sCaseID + "'" +
                " AND SEND_DATETIME IS NULL " +
                " AND CENTRE_ID='" + sCentreId + "'" +
                " AND CLIENT_ID='" + sClientId + "'" +
                " ORDER BY CASE_ID DESC";

        //sSql = "Select Ref_No,CASE_TYPE,Case_Rec_dateTime,Title,First_Name,Middle_Name,Last_Name,DOB,RES_ADD_LINE_1," +
        //       " RES_ADD_LINE_2,RES_ADD_LINE_3,RES_City,RES_STATE,Res_Pin_code,Res_Land_Mark,Res_Phone,MOBILE,OFF_NAME,OFF_ADD_LINE_1, " +
        //       " OFF_ADD_LINE_2,OFF_ADD_LINE_3,Off_city,OFF_STATE,Off_Pin_Code,Off_Phone,Off_Extn,Designation," +
        //       " (ISNULL(RES_ADD_LINE_1,'') + ' ' + ISNULL(RES_ADD_LINE_2,'')+ ' ' + ISNULL(RES_ADD_LINE_3,'')+' ' + ISNULL(Res_Land_Mark,'')+' '+ISNULL(RES_City,'')+''+ISNULL(RES_STATE,'')+' '+ISNULL(Res_Pin_code,'')) as Address, " +
        //       "((ISNULL(First_Name,'') + ' ' + ISNULL(Middle_Name,'') + ' ' + ISNULL(Last_Name, ' ')) AS FULL_NAME "+
        //       " +RES_ADD_LINE_1+' '+RES_ADD_LINE_2+' '+RES_ADD_LINE_3+' '+RES_LAND_MARK+' ' + RES_CITY+ ''+RES_STATE+' ' +RES_PIN_CODE) as SMSContent, " +
        //       " Department,Full_Name as Name,Occupation,PRIORITY,REGION,SPL_INSTRUCTION," +
        //       "PMT_ADD_LINE_1,PMT_ADD_LINE_2,PMT_ADD_LINE_3,PMT_CITY,PMT_STATE,PMT_PIN_CODE,PMT_LANDMARK,PMT_PHONE " +
        //       "from CPV_CC_CASE_DETAILS Where Case_ID='" + sCaseID + "'";
        return OleDbHelper.ExecuteDataset(objCon.ConnectionString, CommandType.Text, sSql);
    }

    //Name             :   GetCreditCaseEntry
    //Create By		   :   Hemangi Kambli
    //Create Date	   :   7th April 2007
    //Remarks 		   :   This method is used to assign select query to the SqlDatasource.
    //                 :   Without Parameter

    public string GetCreditCaseEntry(string sCentreId,string sClientId)
    {
        string sSql = "";

        sSql = "Select CASE_TYPE,Case_ID,Ref_No,Case_Rec_dateTime,Title,(ISNULL(First_Name,'')+ ' '+ISNULL(Middle_Name,'')+ ' '+ISNULL(Last_Name,'')) as Name,DOB,RES_ADD_LINE_1," +
               " RES_ADD_LINE_2,RES_ADD_LINE_3,RES_City,RES_STATE,Res_Pin_code,Res_Land_Mark,Res_Phone,Mobile,OFF_NAME,OFF_ADD_LINE_1, " +
               " OFF_ADD_LINE_2,OFF_ADD_LINE_3,Off_city,OFF_STATE,Off_Pin_Code,Off_Phone,Off_Extn,Designation," +
               " (ISNULL(First_Name,'')+ ' '+ISNULL(Middle_Name,'')+ ' '+ISNULL(Last_Name,'') + ' ' +ISNULL(RES_ADD_LINE_1,'')+' '+ISNULL(RES_ADD_LINE_2,'')+' '+ISNULL(RES_ADD_LINE_3,'')+' '+ISNULL(RES_LAND_MARK,'')+' ' + ISNULL(RES_CITY,'')+ ' ' +ISNULL(RES_PIN_CODE,'')) as SMSContent, " +
               " Department,Occupation,PRIORITY,REGION,SPL_INSTRUCTION,PMT_ADD_LINE_1,PMT_ADD_LINE_2,PMT_ADD_LINE_3," +
               " PMT_CITY,PMT_STATE,PMT_PIN_CODE,PMT_LANDMARK,PMT_PHONE from CPV_CC_CASE_DETAILS " +
               " WHERE SEND_DATETIME IS NULL" +
               " AND CENTRE_ID='" + sCentreId + "'" +
               " AND CLIENT_ID='" + sClientId + "'" +
               " ORDER BY CASE_ID DESC ";

        return sSql;
    }

    //Name             :   GetCreditCaseEntry
    //Create By		   :   Hemangi Kambli
    //Create Date	   :   9th April 2007
    //Remarks 		   :   This method is used to assign select query to the SqlDatasource.
    //                 :   With Parameter for seaching criteria in CreditCardCases

    public string GetCreditCaseEntry(string sRefNo, string sName, bool bChecked, string sFrom, string sTo, string sCentreId, string sClientId)  
    {
        string sSql = "";
        string FromDate = "";
        string ToDate = "";

        sSql = "Select CASE_TYPE,Case_ID,Ref_No,Case_Rec_dateTime,Title,(ISNULL(First_Name,'')+ ' '+ISNULL(Middle_Name,'')+ ' '+ISNULL(Last_Name,'')) as Name,DOB,RES_ADD_LINE_1," +
               " RES_ADD_LINE_2,RES_ADD_LINE_3,RES_City,RES_STATE,Res_Pin_code,Res_Land_Mark,Res_Phone,MOBILE,OFF_NAME,OFF_ADD_LINE_1, " +
               " OFF_ADD_LINE_2,OFF_ADD_LINE_3,Off_city,OFF_STATE,Off_Pin_Code,Off_Phone,Off_Extn,Designation,PRIORITY,REGION ," +
               " (ISNULL(First_Name,'')+ ' '+ISNULL(Middle_Name,'')+ ' '+ISNULL(Last_Name,'') + ' ' +ISNULL(RES_ADD_LINE_1,'')+' '+ISNULL(RES_ADD_LINE_2,'')+' '+ISNULL(RES_ADD_LINE_3,'')+' '+ISNULL(RES_LAND_MARK,'')+' ' + ISNULL(RES_CITY,'')+ ' ' +ISNULL(RES_PIN_CODE,'')) as SMSContent, " +
               " Department,Occupation,Priority,Region,SPL_INSTRUCTION from CPV_CC_CASE_DETAILS WHERE (SEND_DATETIME IS NULL)" +
               " AND CENTRE_ID='" + sCentreId + "'" +
               " AND CLIENT_ID='" + sClientId + "'";

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
        
            //if (sFrom != "" && sTo == "")
            //{
            //    FromDate = objCon.strDate(sFrom);
            //    ToDate = Convert.ToDateTime(objCon.strDate(sFrom)).AddDays(1.0).ToString("dd-MMM-yyyy");
            //}
            //else if(sFrom == "" && sTo != "")
            //{
            //    FromDate = objCon.strDate(sTo);
            //    ToDate=Convert.ToDateTime(objCon.strDate(sTo)).AddDays(1.0).ToString("dd-MMM-yyyy");
            //} 

        if (sFrom != "" && sTo != "")
        {
            FromDate = Convert.ToDateTime(objCon.strDate(sFrom)).ToString("dd-MMM-yyyy");
            //ToDate = Convert.ToDateTime(objCon.strDate(sFrom)).AddDays(1.0).ToString("dd-MMM-yyyy");
            //FromDate = objCon.strDate(sTo);
            ToDate = Convert.ToDateTime(objCon.strDate(sTo)).AddDays(1.0).ToString("dd-MMM-yyyy");
        }

        if(FromDate!="" && ToDate!="")
            sSql += " AND (Case_Rec_dateTime >='" + objCon.FixQuotes(FromDate) + "'" + "and Case_Rec_dateTime<'" + objCon.FixQuotes(ToDate) + "')";
        
        sSql += " ORDER BY CASE_ID DESC";

        return sSql;
    }

    //Name             :   DeleteCreditCardCaseEntry
    //Create By		   :   Hemangi Kambli
    //Create Date	   :   7th April 2007
    //Remarks 		   :   This method is used to delete CreditCardCaseEntry by RefNo.

    public Int32 DeleteCreditCardCaseEntry(string sCaseID)
    {
        OleDbConnection oledbConn = new OleDbConnection(objCon.ConnectionString);
        oledbConn.Open();
        OleDbTransaction oledbTrans = oledbConn.BeginTransaction();
        Int32 nretVal = 0;
        string sSql = "";
        try
        {
            sSql = "Delete from CPV_CC_CASE_VERIFICATIONTYPE WHERE Case_Id='" + sCaseID + "'";
            OleDbHelper.ExecuteNonQuery(oledbTrans, CommandType.Text, sSql);

            sSql = "Delete from CPV_CC_CASE_DETAILS WHERE Case_ID='" + sCaseID + "'";
            nretVal = OleDbHelper.ExecuteNonQuery(oledbTrans, CommandType.Text, sSql);

            oledbTrans.Commit();
            oledbConn.Close();

            return nretVal;
        }
        catch (Exception ex)
        {
            oledbTrans.Rollback();
            oledbConn.Close();
            throw new Exception("Error while deleting CaseCreditCardEntry " + ex.Message);
        }

    }


    //Name             :   UpdateCreditCardCaseEntry
    //Create By		   :   Hemangi Kambli
    //Create Date	   :   7th April 2007
    //Remarks 		   :   This method is used to update CreditCardCaseEntry by RefNo.

    public Int32 UpdateCreditCardCaseEntry(ArrayList arrCaseVerType, string sCaseID)
    {

        OleDbConnection oledbConn = new OleDbConnection(objCon.ConnectionString);
        oledbConn.Open();
        OleDbTransaction oledbTrans = oledbConn.BeginTransaction();
        Int32 nretVal = 0;
        string sSql = "";
        try
        {
            CaseId = sCaseID;
            sSql = "Update CPV_CC_CASE_DETAILS SET CASE_TYPE=?,Case_Rec_dateTime=?, " +
                  "Title=?,First_Name=?,Middle_Name=?,Last_Name=?,Full_Name=?,DOB=?,RES_ADD_LINE_1=?,RES_ADD_LINE_2=?," +
                  "RES_ADD_LINE_3=?,RES_City=?,RES_STATE=?,Res_Pin_code=?,Res_Land_Mark=?,Res_Phone=?,Mobile=?,OFF_NAME=?,OFF_ADD_LINE_1=?,OFF_ADD_LINE_2=?," +
                  "OFF_ADD_LINE_3=?,Off_city=?,OFF_STATE=?,Off_Pin_Code=?,Off_Phone=?,Off_Extn=?,Designation=?,Department=?,Occupation=?,Priority=?,Region=?,Spl_Instruction=?," +
                  "PMT_ADD_Line_1=?,PMT_ADD_Line_2=?,PMT_ADD_Line_3=?,PMT_City=?,PMT_State=?,PMT_PIN_CODE =?,PMT_Landmark=?,PMT_Phone=?,Modify_By=?,Modify_Date=?,VERIFICATION_CODE=? " +
                  " WHERE Case_Id=?";

            OleDbParameter[] paramCreditCard = new OleDbParameter[44];
            paramCreditCard[0] = new OleDbParameter("@CASE_TYPE", OleDbType.VarChar);
            paramCreditCard[0].Value = CaseType;
            paramCreditCard[1] = new OleDbParameter("@Case_Recv_dateTime", OleDbType.DBTimeStamp);
            paramCreditCard[1].Value = ReceivedDateTime;
            paramCreditCard[2] = new OleDbParameter("@Title", OleDbType.VarChar);
            paramCreditCard[2].Value = Title;
            paramCreditCard[3] = new OleDbParameter("@First_Name", OleDbType.VarChar);
            paramCreditCard[3].Value = FirstName;
            paramCreditCard[4] = new OleDbParameter("@Middle_Name", OleDbType.VarChar);
            paramCreditCard[4].Value = MiddleName;
            paramCreditCard[5] = new OleDbParameter("@Last_Name", OleDbType.VarChar);
            paramCreditCard[5].Value = LastName;
            paramCreditCard[6] = new OleDbParameter("@Full_Name", OleDbType.VarChar);
            paramCreditCard[6].Value = FullName;
            paramCreditCard[7] = new OleDbParameter("@DOB", OleDbType.VarChar);
            paramCreditCard[7].Value = DOB;
            paramCreditCard[8] = new OleDbParameter("@RES_ADD_LINE_1", OleDbType.VarChar);
            paramCreditCard[8].Value = ResAdd1;
            paramCreditCard[9] = new OleDbParameter("@RES_ADD_LINE_2", OleDbType.VarChar);
            paramCreditCard[9].Value = ResAdd2;
            paramCreditCard[10] = new OleDbParameter("@RES_ADD_LINE_3", OleDbType.VarChar);
            paramCreditCard[10].Value = ResAdd3;
            paramCreditCard[11] = new OleDbParameter("@RES_City", OleDbType.VarChar);
            paramCreditCard[11].Value = ResCity;
            paramCreditCard[12] = new OleDbParameter("@RES_State", OleDbType.VarChar);
            paramCreditCard[12].Value = ResState;
            paramCreditCard[13] = new OleDbParameter("@Res_Pin_code", OleDbType.VarChar);
            paramCreditCard[13].Value = ResPin;
            paramCreditCard[14] = new OleDbParameter("@Res_Land_Mark", OleDbType.VarChar);
            paramCreditCard[14].Value = ResLandMark;
            paramCreditCard[15] = new OleDbParameter("@Res_Phone", OleDbType.VarChar);
            paramCreditCard[15].Value = ResPhone;
            paramCreditCard[16] = new OleDbParameter("@MOBILE", OleDbType.VarChar);
            paramCreditCard[16].Value = ResMobile;
            paramCreditCard[17] = new OleDbParameter("@OFF_NAME", OleDbType.VarChar);
            paramCreditCard[17].Value = OfficeName;
            paramCreditCard[18] = new OleDbParameter("@OFF_ADD_LINE_1", OleDbType.VarChar);
            paramCreditCard[18].Value = OfficeAdd1;
            paramCreditCard[19] = new OleDbParameter("@OFF_ADD_LINE_2", OleDbType.VarChar);
            paramCreditCard[19].Value = OfficeAdd2;
            paramCreditCard[20] = new OleDbParameter("@OFF_ADD_LINE_3", OleDbType.VarChar);
            paramCreditCard[20].Value = OfficeAdd3;
            paramCreditCard[21] = new OleDbParameter("@OFF_CITY", OleDbType.VarChar);
            paramCreditCard[21].Value = OfficeCity;
            paramCreditCard[22] = new OleDbParameter("@OFF_STATE", OleDbType.VarChar);
            paramCreditCard[22].Value = OfficeState;
            paramCreditCard[23] = new OleDbParameter("@OFF_PIN_CODE", OleDbType.VarChar);
            paramCreditCard[23].Value = OfficePin;
            paramCreditCard[24] = new OleDbParameter("@OFF_PHONE", OleDbType.VarChar);
            paramCreditCard[24].Value = OfficePhone;
            paramCreditCard[25] = new OleDbParameter("@OFF_EXTN", OleDbType.VarChar);
            paramCreditCard[25].Value = OfficeExtn;
            paramCreditCard[26] = new OleDbParameter("@Designation", OleDbType.VarChar);
            paramCreditCard[26].Value = Designation;
            paramCreditCard[27] = new OleDbParameter("@DEPARTMENT", OleDbType.VarChar);
            paramCreditCard[27].Value = Department;
            paramCreditCard[28] = new OleDbParameter("@OCCUPATION", OleDbType.VarChar);
            paramCreditCard[28].Value = Occupation;
            paramCreditCard[29] = new OleDbParameter("@Priority", OleDbType.VarChar);
            paramCreditCard[29].Value = Priority;
            paramCreditCard[30] = new OleDbParameter("@REGION", OleDbType.VarChar);
            paramCreditCard[30].Value = Region;
            paramCreditCard[31] = new OleDbParameter("@SPL_INSTRUCTION", OleDbType.VarChar);
            paramCreditCard[31].Value = SplInstruction;
            /*......................Adding by chinu..............................*/
            paramCreditCard[32] = new OleDbParameter("@PMT_ADD_LINE_1", OleDbType.VarChar);
            paramCreditCard[32].Value = PmtAdd1;
            paramCreditCard[33] = new OleDbParameter("@PMT_ADD_LINE_2", OleDbType.VarChar);
            paramCreditCard[33].Value = PmtAdd2;
            paramCreditCard[34] = new OleDbParameter("@PMT_ADD_LINE_3", OleDbType.VarChar);
            paramCreditCard[34].Value = PmtAdd3;
            paramCreditCard[35] = new OleDbParameter("@PMT_CITY", OleDbType.VarChar);
            paramCreditCard[35].Value = PmtCity;
            paramCreditCard[36] = new OleDbParameter("@PMT_STATE", OleDbType.VarChar);
            paramCreditCard[36].Value = PmtState;
            paramCreditCard[37] = new OleDbParameter("@PMT_PIN_CODE", OleDbType.VarChar);
            paramCreditCard[37].Value = PmtPinCode;
            paramCreditCard[38] = new OleDbParameter("@PMT_LANDMARK", OleDbType.VarChar);
            paramCreditCard[38].Value = PmtLandMark;
            paramCreditCard[39] = new OleDbParameter("@PMT_PHONE", OleDbType.VarChar);
            paramCreditCard[39].Value = PmtPhone;
            /*--------------------------end---------------------------*/
            paramCreditCard[40] = new OleDbParameter("@Modify_By", OleDbType.VarChar);
            paramCreditCard[40].Value = ModifyBy;
            paramCreditCard[41] = new OleDbParameter("@Modify_Date", OleDbType.DBTimeStamp);
            paramCreditCard[41].Value = ModifyOn;
            paramCreditCard[42] = new OleDbParameter("@VerificationCode", OleDbType.VarChar);
            paramCreditCard[42].Value = VerificationCode;
            paramCreditCard[43] = new OleDbParameter("@Case_Id", OleDbType.VarChar);
            paramCreditCard[43].Value = CaseId;

            if (arrCaseVerType.Count > 0)
                OleDbHelper.ExecuteNonQuery(oledbTrans, CommandType.Text, sSql, paramCreditCard);
            else
                nretVal = OleDbHelper.ExecuteNonQuery(oledbTrans, CommandType.Text, sSql, paramCreditCard);


            sSql = "Delete from CPV_CC_CASE_VERIFICATIONTYPE WHERE Case_Id='" + CaseId + "'";
            OleDbHelper.ExecuteNonQuery(oledbTrans, CommandType.Text, sSql);

            foreach (string item in arrCaseVerType)
            {
                sVerTypeId = item;
                sSql = "";

                sSql = "";
                sSql = "Insert into CPV_CC_CASE_VERIFICATIONTYPE(Case_Id,Verification_Type_ID)" +
                       "Values(?,?)";

                OleDbParameter[] paramCaseVerType = new OleDbParameter[2];
                paramCaseVerType[0] = new OleDbParameter("@CaseId", OleDbType.VarChar);
                paramCaseVerType[0].Value = CaseId;
                paramCaseVerType[1] = new OleDbParameter("@VerficationTypeID", OleDbType.VarChar);
                paramCaseVerType[1].Value = VerficationTypeID;

                nretVal = OleDbHelper.ExecuteNonQuery(oledbTrans, CommandType.Text, sSql, paramCaseVerType);
            }
            oledbTrans.Commit();
            oledbConn.Close();

            return nretVal;
        }
        catch (Exception ex)
        {
            oledbTrans.Rollback();
            oledbConn.Close();
            throw new Exception("Error while updating CaseCreditCardEntry " + ex.Message);
        }
    }

    //Function Name    :   InsertCreditCardCaseEntry
    //Create By		   :   Hemangi Kambli
    //Create Date	   :   6th April 2007
    //Remarks 		   :   This method is used to insert new CreditCardCaseEntry.

    public Int32 InsertCreditCardCaseEntry(ArrayList arrCaseVerType, string strPrefix)
    {
        OleDbConnection oledbConn = new OleDbConnection(objCon.ConnectionString);
        oledbConn.Open();
        OleDbTransaction oledbTrans = oledbConn.BeginTransaction();
        Int32 nretVal = 0;
        try
        {
            CaseId = objCon.GetUniqueID("CPV_CC_CASE_DETAILS", strPrefix).ToString();

            string sSql = "";
            //sSql = "Insert into CPV_CC_CASE_DETAILS(Case_Id,Cluster_Id,Centre_Id,Ref_No,Case_Recv_date, " +
            //      "Title,First_Name,Middle_Name,Last_Name,DOB,RES_ADD_LINE_1,RES_ADD_LINE_2," +
            //      "RES_ADD_LINE_3,RES_City,Res_Pin_code,Res_Land_Mark,Res_Phone,OFF_ADD_LINE_1,OFF_ADD_LINE_2," +
            //      "OFF_ADD_LINE_3,Off_city,Off_Pin_Code,Off_Phone,Off_Extn,Designation,Department,Occupation,Add_By,Add_Date) " +
            //      "Values(?CaseID,?Cluster_Id,?Centre_Id,?Ref_No,?Case_Recv_date, " +
            //      "?Title,?First_Name,?Middle_Name,?Last_Name,?DOB,?RES_ADD_LINE_1,?RES_ADD_LINE_2," +
            //      "?RES_ADD_LINE_3,?RES_City,?Res_Pin_code,?Res_Land_Mark,?Res_Phone,?OFF_ADD_LINE_1,?OFF_ADD_LINE_2," +
            //      "?OFF_ADD_LINE_3,?Off_city,?Off_Pin_Code,?Off_Phone,?Off_Extn,?Designation,?Department,?Occupation,?AddedBy,?AddedOn)";

            sSql = "Insert into CPV_CC_CASE_DETAILS( Case_Id,Cluster_Id,Centre_Id,Ref_No,CASE_TYPE,Case_Rec_dateTime, " +
                  "Title,First_Name,Middle_Name,Last_Name,Full_Name,DOB,RES_ADD_LINE_1,RES_ADD_LINE_2," +
                  "RES_ADD_LINE_3,RES_City,RES_STATE,Res_Pin_code,Res_Land_Mark,Res_Phone,Mobile,OFF_NAME,OFF_ADD_LINE_1,OFF_ADD_LINE_2," +
                  "OFF_ADD_LINE_3,Off_city,Off_State,Off_Pin_Code,Off_Phone,Off_Extn,Designation,Department,Occupation,Priority,Region," +
                  "SPL_Instruction,PMT_ADD_LINE_1,PMT_ADD_LINE_2,PMT_ADD_LINE_3,PMT_CITY,PMT_STATE,PMT_PIN_CODE,PMT_LANDMARK,PMT_PHONE, " +
                  "Add_By,Add_Date,Client_Id,VERIFICATION_CODE) " +
                  "Values(?,?,?,?,?,?, " +
                  "?,?,?,?,?,?,?,?," +
                  "?,?,?,?,?,?,?,?,?,?," +
                  "?,?,?,?,?,?,?,?,?,?,?," +
                  "?,?,?,?,?,?,?,?,?, " +
                  "?,?,?,?)";


            OleDbParameter[] paramCreditCard = new OleDbParameter[48];

            paramCreditCard[0] = new OleDbParameter("@Case_Id", OleDbType.VarChar);
            paramCreditCard[0].Value = CaseId;
            paramCreditCard[1] = new OleDbParameter("@Cluster_Id", OleDbType.VarChar);
            paramCreditCard[1].Value = ClusterId;
            paramCreditCard[2] = new OleDbParameter("@Centre_Id", OleDbType.VarChar);
            paramCreditCard[2].Value = CentreId;
            paramCreditCard[3] = new OleDbParameter("@Ref_No", OleDbType.VarChar);
            paramCreditCard[3].Value = RefNo;
            paramCreditCard[4] = new OleDbParameter("@CASE_TYPE", OleDbType.VarChar);
            paramCreditCard[4].Value = CaseType;
            paramCreditCard[5] = new OleDbParameter("@Case_Rec_dateTime", OleDbType.DBTimeStamp);
            paramCreditCard[5].Value = ReceivedDateTime;
            paramCreditCard[6] = new OleDbParameter("@Title", OleDbType.VarChar);
            paramCreditCard[6].Value = Title;
            paramCreditCard[7] = new OleDbParameter("@First_Name", OleDbType.VarChar);
            paramCreditCard[7].Value = FirstName;
            paramCreditCard[8] = new OleDbParameter("@Middle_Name", OleDbType.VarChar);
            paramCreditCard[8].Value = MiddleName;
            paramCreditCard[9] = new OleDbParameter("@Last_Name", OleDbType.VarChar);
            paramCreditCard[9].Value = LastName;
            paramCreditCard[10] = new OleDbParameter("@Full_Name", OleDbType.VarChar);
            paramCreditCard[10].Value = FullName;
            paramCreditCard[11] = new OleDbParameter("@DOB", OleDbType.VarChar);
            paramCreditCard[11].Value = DOB;
            paramCreditCard[12] = new OleDbParameter("@RES_ADD_LINE_1", OleDbType.VarChar);
            paramCreditCard[12].Value = ResAdd1;
            paramCreditCard[13] = new OleDbParameter("@RES_ADD_LINE_2", OleDbType.VarChar);
            paramCreditCard[13].Value = ResAdd2;
            paramCreditCard[14] = new OleDbParameter("@RES_ADD_LINE_3", OleDbType.VarChar);
            paramCreditCard[14].Value = ResAdd3;
            paramCreditCard[15] = new OleDbParameter("@RES_City", OleDbType.VarChar);
            paramCreditCard[15].Value = ResCity;
            paramCreditCard[16] = new OleDbParameter("@RES_STATE", OleDbType.VarChar);
            paramCreditCard[16].Value = ResState;
            paramCreditCard[17] = new OleDbParameter("@Res_Pin_code", OleDbType.VarChar);
            paramCreditCard[17].Value = ResPin;
            paramCreditCard[18] = new OleDbParameter("@Res_Land_Mark", OleDbType.VarChar);
            paramCreditCard[18].Value = ResLandMark;
            paramCreditCard[19] = new OleDbParameter("@Res_Phone", OleDbType.VarChar);
            paramCreditCard[19].Value = ResPhone;
            /*......................adding by chinu...............................*/
            paramCreditCard[20] = new OleDbParameter("@Mobile", OleDbType.VarChar);
            paramCreditCard[20].Value = ResMobile;
            paramCreditCard[21] = new OleDbParameter("@OFF_NAME", OleDbType.VarChar);
            paramCreditCard[21].Value = OfficeName;
            /*..........................end..........................................*/
            paramCreditCard[22] = new OleDbParameter("@OFF_ADD_LINE_1", OleDbType.VarChar);
            paramCreditCard[22].Value = OfficeAdd1;
            paramCreditCard[23] = new OleDbParameter("@OFF_ADD_LINE_2", OleDbType.VarChar);
            paramCreditCard[23].Value = OfficeAdd2;
            paramCreditCard[24] = new OleDbParameter("@OFF_ADD_LINE_3", OleDbType.VarChar);
            paramCreditCard[24].Value = OfficeAdd3;
            paramCreditCard[25] = new OleDbParameter("@Off_city", OleDbType.VarChar);
            paramCreditCard[25].Value = OfficeCity;
            paramCreditCard[26] = new OleDbParameter("@OFF_STATE", OleDbType.VarChar);
            paramCreditCard[26].Value = OfficeState;
            paramCreditCard[27] = new OleDbParameter("@OfficePin", OleDbType.VarChar);
            paramCreditCard[27].Value = OfficePin;
            paramCreditCard[28] = new OleDbParameter("@OfficePhone", OleDbType.VarChar);
            paramCreditCard[28].Value = OfficePhone;
            paramCreditCard[29] = new OleDbParameter("@OfficeExtn", OleDbType.VarChar);
            paramCreditCard[29].Value = OfficeExtn;
            paramCreditCard[30] = new OleDbParameter("@Designation", OleDbType.VarChar);
            paramCreditCard[30].Value = Designation;
            paramCreditCard[31] = new OleDbParameter("@Department", OleDbType.VarChar);
            paramCreditCard[31].Value = Department;
            paramCreditCard[32] = new OleDbParameter("@Occupation", OleDbType.VarChar);
            paramCreditCard[32].Value = Occupation;
            /*..............................Adding by chinu...............................*/
            paramCreditCard[33] = new OleDbParameter("@Priority", OleDbType.VarChar);
            paramCreditCard[33].Value = Priority;
            paramCreditCard[34] = new OleDbParameter("@Region", OleDbType.VarChar);
            paramCreditCard[34].Value = Region;
            paramCreditCard[35] = new OleDbParameter("@SplInstruction", OleDbType.VarChar);
            paramCreditCard[35].Value = SplInstruction;
            /*......................Adding by chinu(permanent Address)..............................*/
            paramCreditCard[36] = new OleDbParameter("@PmtAdd1", OleDbType.VarChar);
            paramCreditCard[36].Value = PmtAdd1;
            paramCreditCard[37] = new OleDbParameter("@PmtAdd2", OleDbType.VarChar);
            paramCreditCard[37].Value = PmtAdd2;
            paramCreditCard[38] = new OleDbParameter("@PmtAdd3", OleDbType.VarChar);
            paramCreditCard[38].Value = PmtAdd3;
            paramCreditCard[39] = new OleDbParameter("@PmtCity", OleDbType.VarChar);
            paramCreditCard[39].Value = PmtCity;
            paramCreditCard[40] = new OleDbParameter("@PmtState", OleDbType.VarChar);
            paramCreditCard[40].Value = PmtState;
            paramCreditCard[41] = new OleDbParameter("@PmtPinCode", OleDbType.VarChar);
            paramCreditCard[41].Value = PmtPinCode;
            paramCreditCard[42] = new OleDbParameter("@PmtLandMark", OleDbType.VarChar);
            paramCreditCard[42].Value = PmtLandMark;
            paramCreditCard[43] = new OleDbParameter("@PmtPhone", OleDbType.VarChar);
            paramCreditCard[43].Value = PmtPhone;

            paramCreditCard[44] = new OleDbParameter("@AddedBy", OleDbType.VarChar);
            paramCreditCard[44].Value = AddedBy;
            paramCreditCard[45] = new OleDbParameter("@AddedOn", OleDbType.DBTimeStamp);
            paramCreditCard[45].Value = AddedOn;
            paramCreditCard[46] = new OleDbParameter("@ClientId", OleDbType.VarChar);
            paramCreditCard[46].Value = ClientId;

            paramCreditCard[47] = new OleDbParameter("@VerificationCode", OleDbType.VarChar);
            paramCreditCard[47].Value = VerificationCode;

            if (arrCaseVerType.Count > 0)
                OleDbHelper.ExecuteNonQuery(oledbTrans, CommandType.Text, sSql, paramCreditCard);
            else
                nretVal = OleDbHelper.ExecuteNonQuery(oledbTrans, CommandType.Text, sSql, paramCreditCard);

            foreach (string item in arrCaseVerType)
            {
                sVerTypeId = item;
                sSql = "";
                sSql = "Insert into CPV_CC_CASE_VERIFICATIONTYPE(Case_Id,Verification_Type_ID)" +
                       "Values(?,?)";

                OleDbParameter[] paramCaseVerType = new OleDbParameter[2];
                paramCaseVerType[0] = new OleDbParameter("@CaseId", OleDbType.VarChar);
                paramCaseVerType[0].Value = CaseId;
                paramCaseVerType[1] = new OleDbParameter("@VerficationTypeID", OleDbType.VarChar);
                paramCaseVerType[1].Value = VerficationTypeID;

                nretVal = OleDbHelper.ExecuteNonQuery(oledbTrans, CommandType.Text, sSql, paramCaseVerType);
            }
            oledbTrans.Commit();
            oledbConn.Close();

            return nretVal;
        }
        catch (Exception ex)
        {
            oledbTrans.Rollback();
            oledbConn.Close();
            throw new Exception("Error while Inserting CaseCreditCardEntry " + ex.Message);
        }
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

        sSql = "SELECT E.EMP_ID , E.FULLNAME,CSM.STATUS_CODE,CSM.STATUS_NAME,CD.Case_Status_ID,CD.DECLINED_CODE,CD.DECLINED_REASON, " +
              " VAT.ATTEMPT_DATE_TIME,VAT.REMARK " +
              " FROM CPV_CC_VERI_ATTEMPTS VAT INNER JOIN CPV_CC_VERI_DETAILS CD " +
              " ON VAT.CASE_ID = CD.CASE_ID INNER JOIN CASE_STATUS_MASTER CSM ON CSM.CASE_STATUS_ID=CD.CASE_STATUS_ID  " +
              " INNER JOIN EMPLOYEE_MASTER E ON  E.EMP_ID=VAT.VERIFIER_ID WHERE CD.Case_ID='" + sCaseID + "'";

        return OleDbHelper.ExecuteDataset(objCon.ConnectionString, CommandType.Text, sSql);
    }

    public Int32 InsertCCCaseVerification(ArrayList arrAttempt)
    {
        OleDbConnection oledbConn = new OleDbConnection(objCon.ConnectionString);
        oledbConn.Open();
        OleDbTransaction oledbTrans = oledbConn.BeginTransaction();
        Int32 retVal = 0;
        //OleDbDataReader oledbRead = GetCaseStatusDtl(CaseID);
        try
        {
            string sSql = "";

            foreach (ArrayList item in arrAttempt)
            {
                AttemptDateTime = item[0].ToString();
                AttemptRemark = item[1].ToString();

                sSql = "Insert into CPV_CC_VERI_ATTEMPTS(Case_ID,VERIFIER_ID,ATTEMPT_DATE_TIME,REMARK)" +
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
            OleDbDataReader oledbRead;
            oledbRead = GetIDOCCaseVerifyDtl(CaseId, oledbTrans);
            OleDbParameter[] paramVerify = new OleDbParameter[4];
            if (oledbRead.Read() == true)
            {
                sSql = "Update CPV_CC_VERI_DETAILS SET CASE_STATUS_ID=?,DECLINED_CODE=?,DECLINED_REASON=? where Case_ID=?";
            }
            else
            {
                sSql = "INSERT INTO CPV_CC_VERI_DETAILS(CASE_STATUS_ID,DECLINED_CODE,DECLINED_REASON,Case_ID) " +
                        "VALUES(?,?,?,?)";
            }

            paramVerify[0] = new OleDbParameter("@CaseStatusID", OleDbType.VarChar);
            paramVerify[0].Value = CaseStatusID;
            paramVerify[1] = new OleDbParameter("@DeclineCode", OleDbType.VarChar);
            paramVerify[1].Value = DeclineCode;
            paramVerify[2] = new OleDbParameter("@DeclineReason", OleDbType.VarChar);
            paramVerify[2].Value = DeclineReason;
            paramVerify[3] = new OleDbParameter("@CaseID", OleDbType.VarChar);
            paramVerify[3].Value = CaseId;

            retVal = OleDbHelper.ExecuteNonQuery(oledbTrans, CommandType.Text, sSql, paramVerify);

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

    public Int32 UpdateCCCaseVerification(ArrayList arrAttempt)
    {
        OleDbConnection oledbConn = new OleDbConnection(objCon.ConnectionString);
        oledbConn.Open();
        OleDbTransaction oledbTrans = oledbConn.BeginTransaction();
        Int32 retVal = 0;
        //OleDbDataReader oledbRead = GetCaseStatusDtl(CaseID);
        try
        {
            string sSql = "";

            sSql = "Delete from CPV_CC_VERI_ATTEMPTS where Case_Id='" + CaseId + "'";
            OleDbHelper.ExecuteNonQuery(oledbTrans, CommandType.Text, sSql);

            foreach (ArrayList item in arrAttempt)
            {
                AttemptDateTime = item[0].ToString();
                AttemptRemark = item[1].ToString();

                sSql = "Insert into CPV_CC_VERI_ATTEMPTS(Case_ID,VERIFIER_ID,ATTEMPT_DATE_TIME,REMARK)" +
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
            OleDbDataReader oledbRead;
            oledbRead = GetIDOCCaseVerifyDtl(CaseId, oledbTrans);
            OleDbParameter[] paramVerify = new OleDbParameter[4];
            if (oledbRead.Read() == true)
            {
                sSql = "Update CPV_CC_VERI_DETAILS SET CASE_STATUS_ID=?,DECLINED_CODE=?,DECLINED_REASON=? where Case_ID=?";
            }
            else
            {
                sSql = "INSERT INTO CPV_CC_VERI_DETAILS(CASE_STATUS_ID,DECLINED_CODE,DECLINED_REASON,Case_ID) " +
                        "VALUES(?,?,?,?)";
            }

            paramVerify[0] = new OleDbParameter("@CaseStatusID", OleDbType.VarChar);
            paramVerify[0].Value = CaseStatusID;
            paramVerify[1] = new OleDbParameter("@DeclineCode", OleDbType.VarChar);
            paramVerify[1].Value = DeclineCode;
            paramVerify[2] = new OleDbParameter("@DeclineReason", OleDbType.VarChar);
            paramVerify[2].Value = DeclineReason;
            paramVerify[3] = new OleDbParameter("@CaseID", OleDbType.VarChar);
            paramVerify[3].Value = CaseId;

            retVal = OleDbHelper.ExecuteNonQuery(oledbTrans, CommandType.Text, sSql, paramVerify);

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

    //Name             :   GetIDOCCaseVerify
    //Create By		   :   Hemangi Kambli
    //Create Date	   :   19th April 2007
    //Remarks 		   :   This method check whether Credit Card case verify detail exist or not.

    public OleDbDataReader GetIDOCCaseVerify(string sCaseID)
    {
        string sSql = "";
        sSql = "Select Case_Id from CPV_CC_VERI_ATTEMPTS where Case_ID='" + sCaseID + "'";

        return OleDbHelper.ExecuteReader(objCon.ConnectionString, CommandType.Text, sSql);
    }

    //Name             :   GetIDOCCaseVerifyDtl
    //Create By		   :   Hemangi Kambli
    //Create Date	   :   20th April 2007
    //Remarks 		   :   This method check whether Credit Card case verify detail exist or not.

    public OleDbDataReader GetIDOCCaseVerifyDtl(string sCaseID, OleDbTransaction oledbTrans)
    {
        string sSql = "";
        sSql = "Select Case_Id from CPV_CC_VERI_DETAILS where Case_ID='" + sCaseID + "'";

        return OleDbHelper.ExecuteReader(oledbTrans, CommandType.Text, sSql);
    }
}