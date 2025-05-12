/*----------------------------------------------------------------------------------------
Scope of Program	:	
File Name			:	CIDOC.cs
Create By			:	Hemangi Kambli
Create Date		    :	12th April 2007
Remarks 		    :	This class inherits CCPVDetail.cs.
                        This is class used for entrying/modifiying IDOC case entry.
						
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

public sealed class CIDOC  : CCPVDetail
{
    private CCommon objCon;
    public CIDOC()
    {
        objCon = new CCommon();
    }

    #region Property Declaration

    private string sVerTypeId;
    private string sBankRefNo;
    private string sWard;
    private string sVerifierID;
    private string sVerificationTypeId;
    private string sAttemptDateTime;
    private string sAttemptRemark;
    private string sCaseStatusID;
    private string sTaxAmt;
    private string sTotAmt;

    public string TaxAmount
    {
        get { return sTaxAmt; }
        set { sTaxAmt = value; }
    }

    public string TotalAmount
    {
        get { return sTotAmt; }
        set { sTotAmt = value; }
    }

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
    public string VerficationTypeID
    {
        get { return sVerTypeId; }
        set { sVerTypeId = value; }
    }
    public string BankRefNo
    {
        get { return sBankRefNo; }
        set { sBankRefNo = value; }
    }
    public string Ward
    {
        get { return sWard; }
        set { sWard = value; }
    }

    #endregion Property Declaration

     
    //Name              :   GetCaseVerificationType
    //Create By			:	Hemangi Kambli
    //Create Date		:	12th April 2007
    //Remarks 		    :	This return dataset for Verification_Type_Id, Verification_Type_code

    public DataSet GetCaseVerificationType(string sActivityID)
    {
        string sSql = "";
        sSql = "Select Verification_Type_Id, Verification_Type_code from Verification_Type_Master where Activity_ID='" + sActivityID + "'";
        return OleDbHelper.ExecuteDataset(objCon.ConnectionString, CommandType.Text, sSql);   
    }

    //Name              :   GetCaseIdByRefNo
    //Create By			:	Hemangi Kambli
    //Create Date		:	12th April 2007
    //Remarks 		    :	This method returns CaseId.
						
    public string GetCaseIdByRefNo(string sRefNo,OleDbTransaction oledbTrans)
    {
        string sSql = "";
        
        sSql = "Select Case_Id from CPV_IDOC_CASE_DETAILS where Ref_No='" + sRefNo + "'";
        DataSet ds = OleDbHelper.ExecuteDataset(oledbTrans, CommandType.Text, sSql);
        if (ds.Tables[0].Rows.Count > 0)
        {
            CaseId = ds.Tables[0].Rows[0]["Case_Id"].ToString();
        }

        return CaseId;
    }

    //Name              :   GetCaseIdByRefNo
    //Create By			:	Hemangi Kambli
    //Create Date		:	12th April 2007
    //Remarks 		    :	This method returns CaseId.

    public string GetCaseIdByRefNo(string sRefNo)
    {
        string sSql = "";

        sSql = "Select Case_Id from CPV_IDOC_CASE_DETAILS where Ref_No='" + sRefNo + "'";
        
        DataSet ds=OleDbHelper.ExecuteDataset(objCon.ConnectionString, CommandType.Text, sSql);
        if (ds.Tables[0].Rows.Count > 0)
        {
            CaseId = ds.Tables[0].Rows[0]["Case_Id"].ToString();
        }
        return CaseId;
    }

    //Name             :   GetAllVerificationId
    //Create By		   :   Hemangi Kambli
    //Create Date	   :   12th April 2007
    //Remarks 		   :   This method is used to get verification id.

    public DataSet GetAllVerificationId(string sCaseID)
    {        
        string sSql = "";
        sSql = "Select Verification_Type_ID from CPV_IDOC_VERIFICATION_TYPE where Case_Id='" + sCaseID + "'";

        return OleDbHelper.ExecuteDataset(objCon.ConnectionString, CommandType.Text, sSql);
    }

    //Name             :   GetRefNo
    //Create By		   :   Hemangi Kambli
    //Create Date	   :   12th April 2007
    //Remarks 		   :   This method check whether RefNo is already exist or not.

    public OleDbDataReader GetIDOCCase(string sCaseID)
    {
        string sSql = "";
        sSql = "Select Case_Id from CPV_IDOC_CASE_DETAILS where Case_ID='" + sCaseID + "'";

        return OleDbHelper.ExecuteReader(objCon.ConnectionString, CommandType.Text, sSql);
    }
    
    //Name             :   GetIDOCCaseEntry
    //Create By		   :   Hemangi Kambli
    //Create Date	   :   12th April 2007
    //Remarks 		   :   This method is used to get all details of IDOCCaseEntry by Case_ID.
    
    public DataSet GetIDOCCaseEntry(string sCaseID, string sCentreId,string sClientId)
    {
        string sSql = "";

        sSql = "Select CASE_ID,VERIFICATION_CODE,REF_NO,ASST_YEAR,RECEIPT_NO,ITO,CASE_REC_DATETIME,TITLE,FIRST_NAME,MIDDLE_NAME,LAST_NAME," +
                "(ISNULL(TITLE,'') + ' ' +ISNULL(First_Name,'')+ ' '+ISNULL(Middle_Name,'')+ ' '+ISNULL(Last_Name,'')) as FULL_NAME," +
                "(ISNULL(TITLE,'') + ' ' +ISNULL(First_Name,'')+ ' '+ISNULL(Middle_Name,'')+ ' '+ISNULL(Last_Name,'')) as NAME," +
                " DOB,RES_ADD_LINE_1,OFF_NAME," +
                " RES_ADD_LINE_2,RES_ADD_LINE_3,RES_CITY,RES_PIN_CODE,RES_LAND_MARK,RES_PHONE,OFF_ADD_LINE_1, " +
                " OFF_ADD_LINE_2,OFF_ADD_LINE_3,OFF_CITY,OFF_PIN_CODE,OFF_PHONE,OFF_EXTN,DESIGNATION," +
                " DEPARTMENT,OCCUPATION,REF_PRODUCT_ID,WARD,TOTAL_AMOUNT,TAX_AMOUNT,ADD_BY,MODIFY_BY,ADD_DATE,MODIFY_DATE, " +
                " BANK_NAME,BANK_ADDRESS,BANK_PIN,BANK_CITY,VERIFICATION_CHARGES,Vehicle_Registration_Number,RTO_Office,Pan_No " +
                " FROM CPV_IDOC_CASE_DETAILS WHERE CASE_ID='" + sCaseID + "'" +
                " AND SEND_DATETIME IS NULL " +
                " AND CENTRE_ID='" + sCentreId + "'" +
                " AND CLIENT_ID='" + sClientId + "'" +
                " ORDER BY CASE_ID DESC";

        return OleDbHelper.ExecuteDataset(objCon.ConnectionString, CommandType.Text, sSql);
    }

    //Name             :   GetIDOCCaseEntry
    //Create By		   :   Hemangi Kambli
    //Create Date	   :   12th April 2007
    //Remarks 		   :   This method is used to assign select query to the SqlDatasource.
    //                 :   Without Parameter

    public string GetIDOCCaseEntry(string sCentreId,string sClientId)
    {
        string sSql = "";


        sSql = "Select CASE_ID,VERIFICATION_CODE,REF_NO,OFF_NAME,ASST_YEAR,RECEIPT_NO,REF_NO,ITO,CASE_REC_DATETIME,TITLE,FIRST_NAME,MIDDLE_NAME,LAST_NAME," +
               "(ISNULL(TITLE,'') + ' ' +ISNULL(First_Name,'')+ ' '+ISNULL(Middle_Name,'')+ ' '+ISNULL(Last_Name,'')) as FULL_NAME,DOB,RES_ADD_LINE_1," +
               "(ISNULL(TITLE,'') + ' ' +ISNULL(First_Name,'')+ ' '+ISNULL(Middle_Name,'')+ ' '+ISNULL(Last_Name,'')) as NAME, " +
               " RES_ADD_LINE_2,RES_ADD_LINE_3,RES_CITY,RES_PIN_CODE,RES_LAND_MARK,RES_PHONE,OFF_ADD_LINE_1, " +
               " OFF_ADD_LINE_2,OFF_ADD_LINE_3,OFF_CITY,OFF_PIN_CODE,OFF_PHONE,OFF_EXTN,DESIGNATION," +
               " DEPARTMENT,OCCUPATION,REF_PRODUCT_ID,WARD,TOTAL_AMOUNT,TAX_AMOUNT,ADD_BY,MODIFY_BY,ADD_DATE,MODIFY_DATE, " +
               " BANK_NAME,BANK_ADDRESS,BANK_PIN,BANK_CITY,VERIFICATION_CHARGES,Vehicle_Registration_Number,RTO_Office " +
               " FROM CPV_IDOC_CASE_DETAILS WHERE SEND_DATETIME IS NULL" +
               " AND CENTRE_ID='" + sCentreId + "'" +
               " AND CLIENT_ID='" + sClientId + "'" +
               " ORDER BY CASE_ID DESC ";
              
        return sSql;
    }

    //Name             :   GetIDOCCaseEntry
    //Create By		   :   Hemangi Kambli
    //Create Date	   :   9th April 2007
    //Remarks 		   :   This method is used to assign select query to the SqlDatasource.
    //                 :   With Parameter for seaching criteria in IDOCCases

    public string GetIDOCCaseEntry(string sRefNo,string sName,bool bChecked, string sFrom, string sTo, string sCentreId,string sClientId,string sCaseID)
    {
        string sSql = "";
        string FromDate = "";
        string ToDate = "";

        sSql = "Select CASE_ID,VERIFICATION_CODE,REF_NO,OFF_NAME,ASST_YEAR,RECEIPT_NO,ITO,CASE_REC_DATETIME,TITLE,FIRST_NAME,MIDDLE_NAME," +
               "(ISNULL(TITLE,'')+' '+ISNULL(First_Name,' ')+ ' '+ISNULL(Middle_Name,'')+ ' '+ISNULL(Last_Name,'')) as Name,LAST_NAME,DOB,RES_ADD_LINE_1," +
               " RES_ADD_LINE_2,RES_ADD_LINE_3,RES_CITY,RES_PIN_CODE,RES_LAND_MARK,RES_PHONE,OFF_ADD_LINE_1, " +
               " OFF_ADD_LINE_2,OFF_ADD_LINE_3,OFF_CITY,OFF_PIN_CODE,OFF_PHONE,OFF_EXTN,DESIGNATION," +
               " DEPARTMENT,OCCUPATION,REF_PRODUCT_ID,WARD,TOTAL_AMOUNT,TAX_AMOUNT,ADD_BY,MODIFY_BY,ADD_DATE,MODIFY_DATE, " +
               " BANK_NAME,BANK_ADDRESS,BANK_PIN,BANK_CITY,VERIFICATION_CHARGES,Vehicle_Registration_Number,RTO_Office " +
               " FROM CPV_IDOC_CASE_DETAILS WHERE 1=1 AND SEND_DATETIME IS NULL" +
               " AND CENTRE_ID='" + sCentreId + "'" +
               " AND CLIENT_ID='" + sClientId + "'" +
               " AND CLUSTER_ID='" + HttpContext.Current.Session["ClusterId"] + "'";
               

        if (sRefNo != "")
        {            
            sSql += " AND Ref_No LIKE '%" + objCon.FixQuotes(sRefNo) + "%'";
        }
        if (sCaseID != "")
        {
            sSql +="AND case_id = '"+sCaseID+"'";
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
    }

    //Name             :   DeleteIDOCCaseEntry
    //Create By		   :   Hemangi Kambli
    //Create Date	   :   12th April 2007
    //Remarks 		   :   This method is used to delete IDOCCaseEntry by RefNo.

    public Int32 DeleteIDOCCaseEntry(string sCaseID)
    {
        OleDbConnection oledbConn = new OleDbConnection(objCon.ConnectionString);
        oledbConn.Open();
        OleDbTransaction oledbTrans = oledbConn.BeginTransaction();
        Int32 nretVal = 0;
        string sSql = "";
        try
        {
            sSql = "Delete from CPV_IDOC_VERIFICATION_TYPE WHERE Case_Id='" + sCaseID + "'";
            OleDbHelper.ExecuteNonQuery(oledbTrans, CommandType.Text, sSql);

            sSql = "Delete from CPV_IDOC_CASE_DETAILS WHERE Case_ID='" + sCaseID + "'";
            nretVal= OleDbHelper.ExecuteNonQuery(oledbTrans, CommandType.Text, sSql);

            oledbTrans.Commit();
            oledbConn.Close();

            return nretVal;
        }
        catch (Exception ex)
        {
            oledbTrans.Rollback();
            oledbConn.Close();
            throw new Exception("Error while deleting CaseIDOCEntry " + ex.Message);
        }

    }


    //Name             :   UpdateIDOCCaseEntry
    //Create By		   :   Hemangi Kambli
    //Create Date	   :   12th April 2007
    //Remarks 		   :   This method is used to update IDOCCaseEntry by RefNo.
    
    public Int32 UpdateIDOCCaseEntry(ArrayList arrCaseVerType, string sCaseID)
    {
        OleDbConnection oledbConn = new OleDbConnection(objCon.ConnectionString);
        oledbConn.Open();
        OleDbTransaction oledbTrans = oledbConn.BeginTransaction();
        Int32 nretVal = 0;        
        string sSql = "";
        try
        {
            string strDOB = DOB;
            /*----------------------------------------------------------------------------------------
           
                Modified By			:	Gargi Srivastava
                Modified Date		:	22 May 2007
                
            ----------------------------------------------------------------------------------------*/
            CaseId = sCaseID;
            sSql = "Update CPV_IDOC_CASE_DETAILS SET REF_NO=?, " +
                  "ITO=?,CASE_REC_DATETIME=?,TITLE=?,FIRST_NAME=?,MIDDLE_NAME=?,FULL_NAME=?, " +
                  "LAST_NAME=?,DOB=?,RES_ADD_LINE_1=?,RES_ADD_LINE_2=?,RES_ADD_LINE_3=?,RES_CITY=?,RES_PIN_CODE=?,RES_LAND_MARK=?, " +
                  "RES_PHONE=?,OFF_ADD_LINE_1=?,OFF_ADD_LINE_2=?,OFF_ADD_LINE_3=?,OFF_CITY=?," +
                  "OFF_PIN_CODE=?,OFF_PHONE=?,OFF_EXTN=?,DESIGNATION=?,DEPARTMENT=?,OCCUPATION=?,REF_PRODUCT_ID=?,WARD=?,TOTAL_AMOUNT=?, " +
                  "TAX_AMOUNT=?,ADD_BY=?,MODIFY_BY=?,ADD_DATE=?,MODIFY_DATE=?,BANK_NAME=?,BANK_ADDRESS=?,BANK_PIN=?,BANK_CITY=?,VERIFICATION_CHARGES=?,  "+
                  "Vehicle_Registration_Number=?,RTO_Office=?,ASST_YEAR=?,RECEIPT_NO=?,OFF_NAME=?,VERIFICATION_CODE=?,Pan_No=? WHERE CASE_ID=?";           

            OleDbParameter[] paramIDOC = new OleDbParameter[47];

            paramIDOC[0] = new OleDbParameter("@Ref_No", OleDbType.VarChar,50);
            paramIDOC[0].Value = RefNo;


            paramIDOC[1] = new OleDbParameter("@ITO", OleDbType.VarChar,100);
            paramIDOC[1].Value = ITO;

            paramIDOC[2] = new OleDbParameter("@Case_Recv_dateTime", OleDbType.DBTimeStamp);
            paramIDOC[2].Value = ReceivedDateTime;

            paramIDOC[3] = new OleDbParameter("@Title", OleDbType.VarChar,10);
            paramIDOC[3].Value = Title;

            paramIDOC[4] = new OleDbParameter("@First_Name", OleDbType.VarChar,50);
            paramIDOC[4].Value = FirstName;

            paramIDOC[5] = new OleDbParameter("@Middle_Name", OleDbType.VarChar,50);
            paramIDOC[5].Value = MiddleName;

            paramIDOC[6] = new OleDbParameter("@Full_Name", OleDbType.VarChar,200);
            paramIDOC[6].Value = FullName;

            paramIDOC[7] = new OleDbParameter("@Last_Name", OleDbType.VarChar,50);
            paramIDOC[7].Value = LastName;

            //if (strDOB != null)
            //{
            //    paramIDOC[9] = new OleDbParameter("@DateOfBirth", OleDbType.Date, 8);
            //    paramIDOC[9].Value = CCommon.date_mm_dd_yy(strDOB);

            //}
            //else
            //{

                paramIDOC[8] = new OleDbParameter("@DateOfBirth", OleDbType.VarChar, 50);
                paramIDOC[8].Value = DOB;
            //}

            
            paramIDOC[9] = new OleDbParameter("@RES_ADD_LINE_1", OleDbType.VarChar,100);
            paramIDOC[9].Value = ResAdd1;

            paramIDOC[10] = new OleDbParameter("@RES_ADD_LINE_2", OleDbType.VarChar,100);
            paramIDOC[10].Value = ResAdd2;

            paramIDOC[11] = new OleDbParameter("@RES_ADD_LINE_3", OleDbType.VarChar,100);
            paramIDOC[11].Value = ResAdd3;

            paramIDOC[12] = new OleDbParameter("@RES_City", OleDbType.VarChar,50);
            paramIDOC[12].Value = ResCity;

            paramIDOC[13] = new OleDbParameter("@Res_Pin_code", OleDbType.VarChar,10);
            paramIDOC[13].Value = ResPin;

            paramIDOC[14] = new OleDbParameter("@Res_Land_Mark", OleDbType.VarChar,50);
            paramIDOC[14].Value = ResLandMark;

            paramIDOC[15] = new OleDbParameter("@Res_Phone", OleDbType.VarChar,50);
            paramIDOC[15].Value = ResPhone;

 
            paramIDOC[16] = new OleDbParameter("@OFF_ADD_LINE_1", OleDbType.VarChar,100);
            paramIDOC[16].Value = OfficeAdd1;

            paramIDOC[17] = new OleDbParameter("@OFF_ADD_LINE_2", OleDbType.VarChar,100);
            paramIDOC[17].Value = OfficeAdd2;

            paramIDOC[18] = new OleDbParameter("@OFF_ADD_LINE_3", OleDbType.VarChar,100);
            paramIDOC[18].Value = OfficeAdd3;

            paramIDOC[19] = new OleDbParameter("@Off_city", OleDbType.VarChar,50);
            paramIDOC[19].Value = OfficeCity;

            paramIDOC[20] = new OleDbParameter("@Off_Pin_Code", OleDbType.VarChar,10);
            paramIDOC[20].Value = OfficePin;

            paramIDOC[21] = new OleDbParameter("@Off_Phone", OleDbType.VarChar,50);
            paramIDOC[21].Value = OfficePhone;

            paramIDOC[22] = new OleDbParameter("@Off_Extn", OleDbType.VarChar,50);
            paramIDOC[22].Value = OfficeExtn;

            paramIDOC[23] = new OleDbParameter("@Designation", OleDbType.VarChar,50);
            paramIDOC[23].Value = Designation;


            paramIDOC[24] = new OleDbParameter("@Department", OleDbType.VarChar,50);
            paramIDOC[24].Value = Department;

            paramIDOC[25] = new OleDbParameter("@Occupation", OleDbType.VarChar,50);
            paramIDOC[25].Value = Occupation;

            paramIDOC[26] = new OleDbParameter("@RefProductID", OleDbType.VarChar,15);
            paramIDOC[26].Value = RefProductID;

           
            paramIDOC[27] = new OleDbParameter("@Ward", OleDbType.VarChar,100);
            paramIDOC[27].Value = Ward;

            paramIDOC[28] = new OleDbParameter("@TotalAmount", OleDbType.VarChar,15);
            paramIDOC[28].Value = TotalAmount;

            paramIDOC[29] = new OleDbParameter("@TaxAmount", OleDbType.VarChar,15);
            paramIDOC[29].Value = TaxAmount;


            paramIDOC[30] = new OleDbParameter("@AddedBy", OleDbType.VarChar,15);
            paramIDOC[30].Value = AddedBy;

            paramIDOC[31] = new OleDbParameter("@ModifyBy", OleDbType.VarChar,15);
            paramIDOC[31].Value = ModifyBy;

            paramIDOC[32] = new OleDbParameter("@AddedOn", OleDbType.DBTimeStamp);
            paramIDOC[32].Value = AddedOn;

            paramIDOC[33] = new OleDbParameter("@ModifyOn", OleDbType.DBTimeStamp);
            paramIDOC[33].Value = ModifyOn;

            paramIDOC[34] = new OleDbParameter("@BankName", OleDbType.VarChar,100);
            paramIDOC[34].Value = BankName;

            paramIDOC[35] = new OleDbParameter("@BankAddress", OleDbType.VarChar,255);
            paramIDOC[35].Value = BankAddress;

            paramIDOC[36] = new OleDbParameter("@BankPin", OleDbType.VarChar,10);
            paramIDOC[36].Value = BankPin;

            paramIDOC[37] = new OleDbParameter("@BankCity", OleDbType.VarChar,100);
            paramIDOC[37].Value = BankCity;

            paramIDOC[38] = new OleDbParameter("@VerificationCharges", OleDbType.VarChar, 10);
            paramIDOC[38].Value = VerificationCharges;

            paramIDOC[39] = new OleDbParameter("@RegistrationNumberOfVechicle", OleDbType.VarChar, 50);
            paramIDOC[39].Value = RegistrationNumberOfVechicle;

            paramIDOC[40] = new OleDbParameter("@RTOOffice", OleDbType.VarChar, 50);
            paramIDOC[40].Value = RTOOffice;

            paramIDOC[41] = new OleDbParameter("@AsstYear", OleDbType.VarChar, 10);
            paramIDOC[41].Value = AsstYear;

            paramIDOC[42] = new OleDbParameter("@ReceiptNo", OleDbType.VarChar, 20);
            paramIDOC[42].Value = ReceiptNo;

            paramIDOC[43] = new OleDbParameter("@OfficeName", OleDbType.VarChar, 100);
            paramIDOC[43].Value = OfficeName;

            paramIDOC[44] = new OleDbParameter("@VerificationTypeCode", OleDbType.VarChar, 100);
            paramIDOC[44].Value = VerificationTypeCode;

            paramIDOC[45] = new OleDbParameter("@PanNo", OleDbType.VarChar, 50);
            paramIDOC[45].Value = PanNo; 

            paramIDOC[46] = new OleDbParameter("@Case_Id", OleDbType.VarChar,15);
            paramIDOC[46].Value = CaseId;


            if (arrCaseVerType.Count > 0)
                OleDbHelper.ExecuteNonQuery(oledbTrans, CommandType.Text, sSql, paramIDOC);
            else
                nretVal = OleDbHelper.ExecuteNonQuery(oledbTrans, CommandType.Text, sSql, paramIDOC);                    

            sSql = "Delete from CPV_IDOC_VERIFICATION_TYPE WHERE Case_Id='" + CaseId + "'";
            OleDbHelper.ExecuteNonQuery(oledbTrans, CommandType.Text, sSql);

            foreach (string item in arrCaseVerType)
            {
                //sVerTypeId = item[0].ToString();
                sVerTypeId = item;
                sSql = "";
               
                sSql = "";
                sSql = "Insert into CPV_IDOC_VERIFICATION_TYPE(Case_Id,Verification_Type_ID)" +
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
            throw new Exception("Error while updating CaseIDOCEntry " + ex.Message);
        }
    }

    //Function Name    :   InsertIDOCCaseEntry
    //Create By		   :   Hemangi Kambli
    //Create Date	   :   6th April 2007
    //Remarks 		   :   This method is used to insert new IDOCCaseEntry.
  
    public Int32 InsertIDOCCaseEntry(ArrayList arrCaseVerType, string strPrefix)
    {
        OleDbConnection oledbConn = new OleDbConnection(objCon.ConnectionString);
        oledbConn.Open();
        OleDbTransaction oledbTrans = oledbConn.BeginTransaction();
        Int32 nretVal = 0;
                
        
        try
        {
            CaseId = objCon.GetUniqueID("CPV_IDOC_CASE_DETAILS", strPrefix).ToString(); 

            string sSql = "";
            string strDOB = DOB; 

            /*----------------------------------------------------------------------------------------
           
                 Modified By			:	Gargi Srivastava
                 Modified Date		:	22 May 2007
                
             ----------------------------------------------------------------------------------------*/
           

            sSql = "Insert into CPV_IDOC_CASE_DETAILS(CASE_ID,CLUSTER_ID,CENTRE_ID,CLIENT_ID,REF_NO, " +
                    "ITO,CASE_REC_DATETIME,TITLE,FIRST_NAME,MIDDLE_NAME,FULL_NAME,LAST_NAME,DOB,RES_ADD_LINE_1,RES_ADD_LINE_2, " +
                    "RES_ADD_LINE_3,RES_CITY,RES_PIN_CODE,RES_LAND_MARK, " +
                    "RES_PHONE,OFF_ADD_LINE_1,OFF_ADD_LINE_2,OFF_ADD_LINE_3,OFF_CITY," +
                    "OFF_PIN_CODE,OFF_PHONE,OFF_EXTN,DESIGNATION,DEPARTMENT,OCCUPATION,REF_PRODUCT_ID,WARD,TOTAL_AMOUNT, " +
                    "TAX_AMOUNT,ADD_BY,MODIFY_BY,ADD_DATE,MODIFY_DATE,BANK_NAME,BANK_ADDRESS,BANK_PIN,BANK_CITY,VERIFICATION_CHARGES, " +
                    " Vehicle_Registration_Number,RTO_Office,ASST_YEAR,RECEIPT_NO,OFF_NAME,VERIFICATION_CODE,Pan_No)" +
                    "Values(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)";


            OleDbParameter[] paramIDOC=new OleDbParameter[50];

            paramIDOC[0] = new OleDbParameter("@Case_Id", OleDbType.VarChar,15);
            paramIDOC[0].Value = CaseId;

            paramIDOC[1] = new OleDbParameter("@ClusterId", OleDbType.VarChar,15);
            paramIDOC[1].Value = ClusterId;

            paramIDOC[2] = new OleDbParameter("@CentreId", OleDbType.VarChar,15);
            paramIDOC[2].Value = CentreId;

            paramIDOC[3] = new OleDbParameter("@ClientId", OleDbType.VarChar,15);
            paramIDOC[3].Value = ClientId;


            paramIDOC[4] = new OleDbParameter("@Ref_No", OleDbType.VarChar,50);
            paramIDOC[4].Value = RefNo;

            //paramIDOC[5] = new OleDbParameter("@Bank_Ref_No", OleDbType.VarChar,50);
            //paramIDOC[5].Value = BankRefNo;

            paramIDOC[5] = new OleDbParameter("@ITO", OleDbType.VarChar,100);
            paramIDOC[5].Value = ITO;

            paramIDOC[6] = new OleDbParameter("@Case_Recv_dateTime", OleDbType.DBTimeStamp);
            paramIDOC[6].Value = ReceivedDateTime;

            paramIDOC[7] = new OleDbParameter("@Title", OleDbType.VarChar,10);
            paramIDOC[7].Value = Title;


            paramIDOC[8] = new OleDbParameter("@First_Name", OleDbType.VarChar,50);
            paramIDOC[8].Value = FirstName;

            paramIDOC[9] = new OleDbParameter("@Middle_Name", OleDbType.VarChar,50);
            paramIDOC[9].Value = MiddleName;

            paramIDOC[10] = new OleDbParameter("@Full_Name", OleDbType.VarChar,200);
            paramIDOC[10].Value = FullName;

            paramIDOC[11] = new OleDbParameter("@Last_Name", OleDbType.VarChar,50);
            paramIDOC[11].Value = LastName;

            paramIDOC[12] = new OleDbParameter("@DateOfBirth", OleDbType.VarChar,50);
            paramIDOC[12].Value = DOB;

            //if (strDOB != null)
            //{
            //    paramIDOC[13] = new OleDbParameter("@DateOfBirth", OleDbType.Date, 8);
            //    paramIDOC[13].Value = CCommon.date_mm_dd_yy(strDOB);

            //}
            //else
            //{

            //    paramIDOC[13] = new OleDbParameter("@DateOfBirth", OleDbType.Date, 8);
            //    paramIDOC[13].Value = DOB;
            //}


            paramIDOC[13] = new OleDbParameter("@RES_ADD_LINE_1", OleDbType.VarChar,100);
            paramIDOC[13].Value = ResAdd1;

            paramIDOC[14] = new OleDbParameter("@RES_ADD_LINE_2", OleDbType.VarChar,100);
            paramIDOC[14].Value = ResAdd2;

            paramIDOC[15] = new OleDbParameter("@RES_ADD_LINE_3", OleDbType.VarChar,100);
            paramIDOC[15].Value = ResAdd3;

            paramIDOC[16] = new OleDbParameter("@RES_City", OleDbType.VarChar,50);
            paramIDOC[16].Value = ResCity;

            paramIDOC[17] = new OleDbParameter("@Res_Pin_code", OleDbType.VarChar,10);
            paramIDOC[17].Value = ResPin;

            paramIDOC[18] = new OleDbParameter("@Res_Land_Mark", OleDbType.VarChar,50);
            paramIDOC[18].Value = ResLandMark;

            paramIDOC[19] = new OleDbParameter("@Res_Phone", OleDbType.VarChar,50);
            paramIDOC[19].Value = ResPhone;

    
            paramIDOC[20] = new OleDbParameter("@OFF_ADD_LINE_1", OleDbType.VarChar,100);
            paramIDOC[20].Value = OfficeAdd1;

            paramIDOC[21] = new OleDbParameter("@OFF_ADD_LINE_2", OleDbType.VarChar,100);
            paramIDOC[21].Value = OfficeAdd2;

            paramIDOC[22] = new OleDbParameter("@OFF_ADD_LINE_3", OleDbType.VarChar,100);
            paramIDOC[22].Value = OfficeAdd3;

            paramIDOC[23] = new OleDbParameter("@Off_city", OleDbType.VarChar,50);
            paramIDOC[23].Value = OfficeCity;

            paramIDOC[24] = new OleDbParameter("@Off_Pin_Code", OleDbType.VarChar,10);
            paramIDOC[24].Value = OfficePin;

            paramIDOC[25] = new OleDbParameter("@Off_Phone", OleDbType.VarChar,50);
            paramIDOC[25].Value = OfficePhone;

            paramIDOC[26] = new OleDbParameter("@Off_Extn", OleDbType.VarChar,50);
            paramIDOC[26].Value = OfficeExtn;

            paramIDOC[27] = new OleDbParameter("@Designation", OleDbType.VarChar,50);
            paramIDOC[27].Value = Designation;

            paramIDOC[28] = new OleDbParameter("@Department", OleDbType.VarChar,50);
            paramIDOC[28].Value = Department;

            paramIDOC[29] = new OleDbParameter("@Occupation", OleDbType.VarChar,50);
            paramIDOC[29].Value = Occupation;

            paramIDOC[30] = new OleDbParameter("@RefProductID", OleDbType.VarChar,50);
            paramIDOC[30].Value = RefProductID;

            paramIDOC[31] = new OleDbParameter("@Ward", OleDbType.VarChar,100);
            paramIDOC[31].Value = Ward;

            paramIDOC[32] = new OleDbParameter("@TotalAmount", OleDbType.VarChar,15);
            paramIDOC[32].Value = TotalAmount;

            paramIDOC[33] = new OleDbParameter("@TaxAmount", OleDbType.VarChar,15);
            paramIDOC[33].Value = TaxAmount;


            paramIDOC[34] = new OleDbParameter("@AddedBy", OleDbType.VarChar,15);
            paramIDOC[34].Value = AddedBy;

            paramIDOC[35] = new OleDbParameter("@ModifyBy", OleDbType.VarChar,15);
            paramIDOC[35].Value = ModifyBy;

            paramIDOC[36] = new OleDbParameter("@AddedOn", OleDbType.DBTimeStamp);
            paramIDOC[36].Value = AddedOn;

            paramIDOC[37] = new OleDbParameter("@ModifyOn", OleDbType.DBTimeStamp);
            paramIDOC[37].Value = ModifyOn;


            paramIDOC[38] = new OleDbParameter("@BankName", OleDbType.VarChar, 100);
            paramIDOC[38].Value = BankName;

            paramIDOC[39] = new OleDbParameter("@BankAddress", OleDbType.VarChar, 255);
            paramIDOC[39].Value = BankAddress;

            paramIDOC[40] = new OleDbParameter("@BankPin", OleDbType.VarChar, 10);
            paramIDOC[40].Value = BankPin;

            paramIDOC[41] = new OleDbParameter("@BankCity", OleDbType.VarChar, 100);
            paramIDOC[41].Value = BankCity;

            paramIDOC[42] = new OleDbParameter("@VerificationCharges", OleDbType.VarChar, 10);
            paramIDOC[42].Value = VerificationCharges;

            paramIDOC[43] = new OleDbParameter("@RegistrationNumberOfVechicle", OleDbType.VarChar, 50);
            paramIDOC[43].Value = RegistrationNumberOfVechicle;

            paramIDOC[44] = new OleDbParameter("@RTOOffice", OleDbType.VarChar, 50);
            paramIDOC[44].Value = RTOOffice;

            paramIDOC[45] = new OleDbParameter("@AsstYear", OleDbType.VarChar, 10);
            paramIDOC[45].Value = AsstYear;

            paramIDOC[46] = new OleDbParameter("@ReceiptNo", OleDbType.VarChar, 20);
            paramIDOC[46].Value = ReceiptNo;

            paramIDOC[47] = new OleDbParameter("@OfficeName", OleDbType.VarChar, 100);
            paramIDOC[47].Value = OfficeName;

            paramIDOC[48] = new OleDbParameter("@VerificationTypeCode", OleDbType.VarChar, 100);
            paramIDOC[48].Value = VerificationTypeCode;

            paramIDOC[49] = new OleDbParameter("@PanNo", OleDbType.VarChar, 50);
            paramIDOC[49].Value = PanNo; 
            
            if (arrCaseVerType.Count > 0)
                OleDbHelper.ExecuteNonQuery(oledbTrans, CommandType.Text, sSql, paramIDOC);
            else
                nretVal=OleDbHelper.ExecuteNonQuery(oledbTrans, CommandType.Text, sSql, paramIDOC);
                        
            foreach(string item in arrCaseVerType)
            {
                sVerTypeId = item;
                sSql = "";
                sSql = "Insert into CPV_IDOC_VERIFICATION_TYPE(Case_Id,Verification_Type_ID)" +
                       "Values(?,?)";
                                
                OleDbParameter[] paramCaseVerType = new OleDbParameter[2];
                paramCaseVerType[0] = new OleDbParameter("@CaseId", OleDbType.VarChar);
                paramCaseVerType[0].Value = CaseId;
                paramCaseVerType[1] = new OleDbParameter("@VerficationTypeID", OleDbType.VarChar);
                paramCaseVerType[1].Value = VerficationTypeID;

                nretVal=OleDbHelper.ExecuteNonQuery(oledbTrans, CommandType.Text, sSql, paramCaseVerType);
            }
            oledbTrans.Commit();
            oledbConn.Close();

            return nretVal;        
        }
        catch (Exception ex)
        {
            oledbTrans.Rollback();
            oledbConn.Close();
            throw new Exception("Error while Inserting CaseIDOCEntry " + ex.Message);
        }
    }

    //Name             :   GetRefNo
    //Create By		   :   Hemangi Kambli
    //Create Date	   :   17th April 2007
    //Remarks 		   :   This method check whether IDOC case verify detail exist or not.

    public OleDbDataReader GetIDOCCaseVerify(string sCaseID)
    {
        string sSql = "";
        sSql = "Select Case_Id from CPV_IDOC_VERI_ATTEMPTS where Case_ID='" + sCaseID + "'";

        return OleDbHelper.ExecuteReader(objCon.ConnectionString, CommandType.Text, sSql);
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
              " VAT.ATTEMPT_DATE_TIME,VAT.REMARK " +
              " FROM CPV_IDOC_VERI_ATTEMPTS VAT INNER JOIN CPV_IDOC_CASE_DETAILS CD " +
              " ON VAT.CASE_ID = CD.CASE_ID INNER JOIN CASE_STATUS_MASTER CSM ON CSM.CASE_STATUS_ID=CD.CASE_STATUS_ID  " +
              " INNER JOIN EMPLOYEE_MASTER E ON  E.EMP_ID=VAT.VERIFIER_ID WHERE CD.Case_ID='" + sCaseID + "'";

        return OleDbHelper.ExecuteDataset(objCon.ConnectionString, CommandType.Text, sSql);
    }

    public Int32 InsertIDOCCaseVerification(ArrayList arrAttempt)
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

                sSql = "Insert into CPV_IDOC_VERI_ATTEMPTS(Case_ID,VERIFIER_ID,ATTEMPT_DATE_TIME,REMARK)" +
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
            sSql1 = "Update CPV_IDOC_CASE_DETAILS SET CASE_STATUS_ID=?,Tax_Amount=?,Total_Amount=? where Case_ID='" + CaseId + "'";

            OleDbParameter[] paramStatus = new OleDbParameter[3];

            paramStatus[0] = new OleDbParameter("@CaseStatusID", OleDbType.VarChar);
            paramStatus[0].Value = CaseStatusID;
            paramStatus[1] = new OleDbParameter("@Tax_Amount", OleDbType.VarChar,15);
            paramStatus[1].Value = TaxAmount;
            paramStatus[2] = new OleDbParameter("@Total_Amount", OleDbType.VarChar,15);
            paramStatus[2].Value = TotalAmount;

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

    public Int32 UpdateIDOCCaseVerification(ArrayList arrAttempt)
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

            sSql = "Delete from CPV_IDOC_VERI_ATTEMPTS where Case_Id='" + CaseId + "'";
            OleDbHelper.ExecuteNonQuery(oledbTrans, CommandType.Text, sSql);

            foreach (ArrayList item in arrAttempt)
            {
                AttemptDateTime = item[0].ToString();
                AttemptRemark = item[1].ToString();

                sSql = "Insert into CPV_IDOC_VERI_ATTEMPTS(Case_ID,VERIFIER_ID,ATTEMPT_DATE_TIME,REMARK)" +
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
            sSql1 = "Update CPV_IDOC_CASE_DETAILS SET CASE_STATUS_ID=?,Tax_Amount=?,Total_Amount=? where Case_ID='" + CaseId + "'";

            OleDbParameter[] paramStatus = new OleDbParameter[3];

            paramStatus[0] = new OleDbParameter("@CaseStatusID", OleDbType.VarChar);
            paramStatus[0].Value = CaseStatusID;
            paramStatus[1] = new OleDbParameter("@Tax_Amount", OleDbType.VarChar,15);
            paramStatus[1].Value = TaxAmount;
            paramStatus[2] = new OleDbParameter("@Total_Amount", OleDbType.VarChar,15);
            paramStatus[2].Value = TotalAmount;

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

    public DataTable GetReferenceProduct()
    {
        string sSql = "";
        DataTable dtReferenceProduct = new DataTable();
        sSql = "Select PRODUCT_ID,Product_Name from Product_Master ";
        OleDbDataAdapter oledbDa = new OleDbDataAdapter(sSql, objCon.ConnectionString);
        DataSet ds = new DataSet();
        oledbDa.Fill(ds, "CPV_IDOC_CASE_DETAILS");
        dtReferenceProduct = ds.Tables["CPV_IDOC_CASE_DETAILS"];
        return dtReferenceProduct;

    }
}






