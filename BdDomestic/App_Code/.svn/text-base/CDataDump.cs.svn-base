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

/// <summary>
/// Summary description for CDataDump
/// </summary>
public class CDataDump
{
    private CCommon objCommon;

    #region Constructor
    public CDataDump()
	{
        objCommon = new CCommon();

        //Get batch id for cases being imported
        dtImportLog = new DataTable();
        DataColumn dcRowNumber = new DataColumn("RowNumber");
        DataColumn dcDetails = new DataColumn("Details");
        dtImportLog.Columns.Add(dcRowNumber);
        dtImportLog.Columns.Add(dcDetails);

        dsExcel = new DataSet();

    }
    #endregion

    #region Propery Declarion for case_Master Table


    private String sCaseID;             //1
    private String sALCDate;            //2
    private String sALCTime;            //3 
    private String sALCTimeType;        //4
    private String sCompanyID;          //5
    private String sCentreID;           //6
    private String sClusterID;          //7
    private String sCaseTypeID;         //8
    private String sCaseEntryStatus;    //9
    private String dtAdd;               //10
    private String sAddedBy;            //11
    private String sXslSheet;           //12
    private String sCaseRedo;           //13
    private string strBatchId;          //14
    private string strTemplateId;       //15

    private string strCaseType;         //16
    private string strActualDate;       //17

    private string strClientId;         //18

    private DataTable dtImportLog;       //19

    private string strActivityId;        //20
    private string sPrefix;              //21

    private string strProductId;         //22
    private DataSet dsExcel;
    private int iTotalCases;

    public String CaseID    //1
    {
        get { return sCaseID; }
        set { sCaseID = value; }
    }
    public String ALCDate  //2
    {
        get { return sALCDate; }
        set
        {
            if (value == "")
            {
                sALCDate = null;
            }
            else
            {
                sALCDate = value;
            }
        }
    }
    public String ALCTime  //3
    {
        get { return sALCTime; }
        set
        {
            if (value == "")
            {
                sALCTime = null;
            }
            else
            {
                sALCTime = value;
            }
        }
    }
    public String ALCTimeType  //4
    {
        get { return sALCTimeType; }
        set
        {
            if (value == "")
            {
                sALCTimeType = null;
            }
            else
            {
                sALCTimeType = value;
            }
        }
    }
    public String CompanyID   //5
    {
        get { return sCompanyID; }
        set
        {
            if (value == "")
            {
                sCompanyID = null;
            }
            else
            {
                sCompanyID = value;
            }
        }
    }
    public String CentreID   //6
    {
        get { return sCentreID; }
        set
        {
            if (value == "")
            {
                sCentreID = null;
            }
            else
            {
                sCentreID = value;
            }
        }
    }
    public String ClusterID   //7
    {
        get { return sClusterID; }
        set
        {
            if (value == "")
            {
                sClusterID = null;
            }
            else
            {
                sClusterID = value;
            }
        }
    }
    public String CaseTypeID   //8
    {
        get { return sCaseTypeID; }
        set
        {
            if (value == "")
            {
                sCaseTypeID = null;
            }
            else
            {
                sCaseTypeID = value;
            }
        }
    }
    public String CaseEntryStatus   //9
    {
        get { return sCaseEntryStatus; }
        set
        {
            if (value == "")
            {
                sCaseEntryStatus = null;
            }
            else
            {
                sCaseEntryStatus = value;
            }
        }
    }
    public String AddOn   //10
    {
        get { return dtAdd; }
        set
        {
            if (value == "")
            {
                dtAdd = null;
            }
            else
            {
                dtAdd = value;
            }
        }
    }
    public String AddedBy   //11
    {
        get { return sAddedBy; }
        set
        {
            if (value == "")
            {
                sAddedBy = null;
            }
            else
            {
                sAddedBy = value;
            }
        }
    }

    public String XslSheet   //12
    {
        get { return sXslSheet; }
        set
        {
            if (value == "")
            {
                sXslSheet = null;
            }
            else
            {
                sXslSheet = value;
            }
        }
    }

    public String CaseRedo   //13
    {
        get { return sCaseRedo; }
        set
        {
            if (value == "")
            {
                sCaseRedo = "0";
            }
            else
            {
                sCaseRedo = value;
            }
        }
    }

    public string BatchId   //14
    {
        get { return strBatchId; }
    }

    public string TemplateId    //15
    {
        get { return strTemplateId; }
        set { strTemplateId = value; }
    }

    public string CaseType//16
    {
        get { return strCaseType; }
        set { strCaseType = value; }
    }

    public string ActualDate//17
    {
        get { return strActualDate; }
        set { strActualDate = value; }
    }

    public string ClientId//18
    {
        get { return strClientId; }
        set { strClientId = value; }
    }

    public DataTable ImportLog//19  Readonly property which will return the log for import.
    {
        get { return dtImportLog; }
    }

    public string ActivityId//20
    {
        get { return strActivityId; }
        set { strActivityId = value; }
    }

    public string Prefix//21
    {
        get { return sPrefix; }
        set { sPrefix = value; }
    }

    public String ProductId//22
    {
        get { return strProductId; }
        set { strProductId = value; }
    }

    public int TotalCases 
    {
        get { return iTotalCases; }
        set { iTotalCases = value; }
    }

    #endregion Propery Declarion for case_Master Table

    #region Private variables
        private OleDbConnection objCon;
        private OleDbTransaction objTrans;
    private Hashtable htGetHeadProcess;
    #endregion

    #region GetAdditionalFields
    //Added by hemangi kambli on 07-Aug-2007 
    private Hashtable GetAdditionalFields()
    {
        Hashtable htReturn = new Hashtable();
        string strReturn = "";
        string strSql = "select Sequence_Id, Additional_Fields from datadump_master " +
                        " where Client_Id ='" + ClientId + "'" +
                        " AND PRODUCT_ID='" + ProductId + "'";

        OleDbDataReader oDr = OleDbHelper.ExecuteReader(objCommon.ConnectionString, CommandType.Text, strSql);
        while (oDr.Read())
        {            
            if (oDr["Additional_Fields"].ToString() != "")
                strReturn = oDr["Additional_Fields"].ToString();
            htReturn.Add(oDr["Sequence_Id"].ToString(), strReturn);
        }
        oDr.Close();
        return htReturn;
    }

    #endregion GetAdditionalFields

    #region To Get Values From Excel And Insert Into the Table
   
    //public bool ImportExcel()
    //{
    //    bool isImport = false;        
    //    Hashtable htImportSteps = new Hashtable();
    //    htImportSteps = GetExcelHeaders();

    //    Hashtable htFields = new Hashtable();
    //    htFields = GetFields();

    //    Hashtable htRefDetails = new Hashtable();
    //    htRefDetails = GetReferneceDetails();

    //    Hashtable htTable = new Hashtable();
    //    htTable = GetTable();

    //    Hashtable htGetPrimaryHeaders = new Hashtable();
    //    htGetPrimaryHeaders = GetPrimaryHeaders();

    //    Hashtable htGetAdditionalValues = new Hashtable();
    //    htGetAdditionalValues = GetAdditionalValues();

    //    Hashtable htGetIterationHeader = new Hashtable();
    //    htGetIterationHeader = GetIterationHeader();

    //    htGetHeadProcess = new Hashtable();
    //    htGetHeadProcess = GetHeadProcess();

    //    //Added by hemangi kambli on 07-Aug-2007 --------------
    //    Hashtable htGetAdditionalFields = new Hashtable();
    //    htGetAdditionalFields = GetAdditionalFields();
    //    //-----------------------------------------------------

    //    String strFile = HttpContext.Current.Server.MapPath("../../ImportFiles/" + BatchId + ".xls");
    //    string strConn = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + strFile + @";Extended Properties=""Excel 8.0;IMEX=1""";

    //    try
    //    {
    //        int iStepCounter = 0;
    //        while (iStepCounter < htImportSteps.Count)
    //        {
    //            String STR = "SELECT " + htImportSteps[iStepCounter.ToString()].ToString().TrimEnd(',') + " FROM [Sheet1$] ";
    //            //Select From Excel and Filling data in to DataSet
    //            OleDbDataAdapter myCommand = new OleDbDataAdapter(STR, strConn);
    //            DataTable dt = new DataTable();
    //            myCommand.Fill(dt);
    //            dsExcel.Tables.Add(dt);
    //            iStepCounter++;
    //        }

    //        objCon = new OleDbConnection(objCommon.ConnectionString);
    //        objCon.Open();

    //        int iIterator = 0;
    //        while (iIterator < dsExcel.Tables[0].Rows.Count) //Iterate through ref_no...
    //        {
    //            objTrans = objCon.BeginTransaction();
    //            try
    //            {
    //                string strCaseId = "";
    //                strCaseId = GetCaseId(dsExcel.Tables[0].Rows[iIterator][0].ToString());
    //                if (strCaseId == "")
    //                {
    //                    objTrans.Rollback();
    //                    LogImport((iIterator + 1).ToString(), (iIterator + 1).ToString() + " row can not be imported. Case with Reference No. '" + dsExcel.Tables[0].Rows[iIterator][0].ToString() + "' does not exists. ");
    //                    continue;
    //                }
    //                else
    //                {
    //                    try
    //                    {                            
    //                        //Added by hemangi kambli on 07-Aug-2007 ---------------
    //                        //Start Update Send_dateTime in CPV_CC_CASE_DETAILS table-----
    //                        int iIterator1 = 2;
    //                        int iIterator2 = 1;
    //                        string strVals = "";
    //                        string strInsert = "";
                            
    //                        string strTableUpdate = (htTable[iIterator2.ToString()].ToString());
    //                        string strFieldUpdate = (htFields[iIterator2.ToString()].ToString());
    //                        strVals = GetValues(iIterator, iIterator2, htGetIterationHeader[iIterator2.ToString()].ToString());

    //                        strInsert = "Update " + htTable[iIterator2.ToString()].ToString() + " SET " +
    //                                    htFields[iIterator2.ToString()].ToString() + "= " + strVals.TrimStart(',') +
    //                                    " WHERE CASE_ID='" + strCaseId + "'";

    //                        OleDbHelper.ExecuteNonQuery(objTrans, CommandType.Text, strInsert);
    //                        //End Update Send_dateTime in CPV_CC_CASE_DETAILS table-----

    //                        //Start Attempt Details Entry ------------------------------------------------
    //                        strInsert = "Delete from " + htTable[iIterator1.ToString()].ToString() + " Where Case_id='" + strCaseId + "' AND " +
    //                                    htGetAdditionalFields[iIterator1.ToString()].ToString() + "=" +
    //                                    htGetAdditionalValues[iIterator1.ToString()].ToString();
    //                        OleDbHelper.ExecuteNonQuery(objTrans, CommandType.Text, strInsert);

    //                        //while (iIterator1 < htImportSteps.Count)
    //                        while (iIterator1 < 7)
    //                        {
    //                            strInsert = "";
    //                            if (htGetPrimaryHeaders[iIterator1.ToString()] != null)
    //                            {
    //                                if (dsExcel.Tables[iIterator1].Rows[iIterator][htGetPrimaryHeaders[iIterator1.ToString()].ToString().TrimStart('[').TrimEnd(']')].ToString().Trim() != "")
    //                                {
    //                                    if (htRefDetails[iIterator1.ToString()] == null)
    //                                    {
    //                                        if (htGetAdditionalValues[iIterator1.ToString()] != null)
    //                                            strVals = GetValues(iIterator, iIterator1, htGetIterationHeader[iIterator1.ToString()].ToString()) + "," + htGetAdditionalValues[iIterator1.ToString()].ToString() + ",'" + strCaseId + "'";
    //                                        else
    //                                            strVals = GetValues(iIterator, iIterator1, htGetIterationHeader[iIterator1.ToString()].ToString()) + ",'" + strCaseId + "'";
    //                                    }
    //                                    else
    //                                    {
    //                                        if (htGetAdditionalValues[iIterator1.ToString()] != null)
    //                                            strVals = GetValues(iIterator, iIterator1, htGetIterationHeader[iIterator1.ToString()].ToString(), (Hashtable)htRefDetails[iIterator1.ToString()]) + "," + htGetAdditionalValues[iIterator1.ToString()].ToString() + ",'" + strCaseId + "'";
    //                                        else
    //                                            strVals = GetValues(iIterator, iIterator1, htGetIterationHeader[iIterator1.ToString()].ToString(), (Hashtable)htRefDetails[iIterator1.ToString()]) + ",'" + strCaseId + "'";
    //                                    }

    //                                    strInsert = "Insert into " + htTable[iIterator1.ToString()].ToString() + " (" + htFields[iIterator1.ToString()].ToString() + ",CASE_ID" + ") values (" + strVals.TrimStart(',') + ")";

    //                                }
    //                            }
    //                            else
    //                            {
    //                                if (htRefDetails[iIterator1.ToString()] == null)
    //                                {
    //                                    if (htGetAdditionalValues[iIterator1.ToString()] != null)
    //                                        strVals = GetValues(iIterator, iIterator1, htGetIterationHeader[iIterator1.ToString()].ToString()) + "," + htGetAdditionalValues[iIterator1.ToString()].ToString() + ",'" + strCaseId + "'";
    //                                    else
    //                                        strVals = GetValues(iIterator, iIterator1, htGetIterationHeader[iIterator1.ToString()].ToString()) + ",'" + strCaseId + "'";
    //                                }
    //                                else
    //                                {
    //                                    if (htGetAdditionalValues[iIterator1.ToString()] != null)
    //                                        strVals = GetValues(iIterator, iIterator1, htGetIterationHeader[iIterator1.ToString()].ToString(), (Hashtable)htRefDetails[iIterator1.ToString()]) + "," + htGetAdditionalValues[iIterator1.ToString()].ToString() + ",'" + strCaseId + "'";
    //                                    else
    //                                        strVals = GetValues(iIterator, iIterator1, htGetIterationHeader[iIterator1.ToString()].ToString(), (Hashtable)htRefDetails[iIterator1.ToString()]) + ",'" + strCaseId + "'";
    //                                }

    //                                strInsert = "Insert into " + htTable[iIterator1.ToString()].ToString() + " (" + htFields[iIterator1.ToString()].ToString() + ",CASE_ID" + ") values (" + strVals.TrimStart(',') + ")";
    //                            }
    //                            if (strInsert != "")
    //                                OleDbHelper.ExecuteNonQuery(objTrans, CommandType.Text, strInsert);
                                                                
    //                            iIterator1++;
    //                        }
    //                        //End Attempt Details Entry ------------------------------------------------                    //For Verification Entry -------------------------------------------------------

    //                        ////Start Verification Entry------------------------------------------------
    //                        ////added on 09-Aug-2007 ---------------------------------------------------
    //                        ////CPV_CC_VERI_DESCRIPTION, CPV_CC_VERI_DESCRIPTION1 ----------------------
    //                        strInsert = "";
    //                        int iIteratorDesc = 8;
    //                        OleDbDataReader oledbRead;
    //                        while (iIteratorDesc <= htImportSteps.Count-1) //14
    //                        {
    //                            if (htGetPrimaryHeaders[iIteratorDesc.ToString()] != null)
    //                            {                                    
    //                                if (dsExcel.Tables[iIteratorDesc].Rows[iIterator][htGetPrimaryHeaders[iIteratorDesc.ToString()].ToString().TrimStart('[').TrimEnd(']')].ToString().Trim() != "")
    //                                {   
    //                                    if (htGetAdditionalValues[iIteratorDesc.ToString()] != null)
    //                                        strVals = GetValues(iIterator, iIteratorDesc, htGetIterationHeader[iIteratorDesc.ToString()].ToString()) + "," + htGetAdditionalValues[iIteratorDesc.ToString()].ToString() + ",'" + strCaseId + "'";
    //                                    else
    //                                        strVals = GetValues(iIterator, iIteratorDesc, htGetIterationHeader[iIteratorDesc.ToString()].ToString()) + ",'" + strCaseId + "'";
                                                                                                                                  
    //                                    string[] arrIterDesc = htGetIterationHeader[iIteratorDesc.ToString()].ToString().Split(',');
    //                                    string strFieldsDesc = htFields[iIteratorDesc.ToString()].ToString() + ",Case_Id";
    //                                    string[] arrFieldsDesc = strFieldsDesc.Split(',');
    //                                    string[] arrValuesDesc = strVals.TrimStart(',').Replace("'","").Split(',');

    //                                    strInsert = "Select * from " + htTable[iIteratorDesc.ToString()].ToString() + " Where Case_id='" + strCaseId + "' AND " +
    //                                                htGetAdditionalFields[iIteratorDesc.ToString()].ToString() + "=" +
    //                                                htGetAdditionalValues[iIteratorDesc.ToString()].ToString();

    //                                    oledbRead = OleDbHelper.ExecuteReader(objTrans, CommandType.Text, strInsert);
    //                                    //If record already exist then update else insert ---------------------------------
    //                                    string strTmpFieldsDesc = "";
    //                                    if (oledbRead.Read() == true)
    //                                    {
    //                                        strInsert = "Update " + htTable[iIteratorDesc.ToString()].ToString() + " SET ";

    //                                        for (int i = 0; i < arrIterDesc.Length; i++)  //for rating ------
    //                                        {
    //                                            if (arrIterDesc[i] == "[RV Rating]" || (arrIterDesc[i] == "[BV Rating]"))
    //                                            {
    //                                                if (arrValuesDesc[i].Trim() != "")
    //                                                {
    //                                                    if (arrValuesDesc[i] == "88")     //For 88-Negative,99-Positive
    //                                                        arrValuesDesc[i] = "2";
    //                                                    else if (arrValuesDesc[i] == "99")
    //                                                        arrValuesDesc[i] = "1";
    //                                                }
    //                                                else
    //                                                {
    //                                                    arrValuesDesc[i] = "''";
    //                                                }
    //                                                strTmpFieldsDesc += arrFieldsDesc[i] + "= '" + arrValuesDesc[i] + "',";
    //                                            }
    //                                            else
    //                                                strTmpFieldsDesc += arrFieldsDesc[i] + "= '" + arrValuesDesc[i] + "',";
    //                                        }

    //                                        strInsert += strTmpFieldsDesc.TrimEnd(',');
    //                                        strInsert += " Where Case_id='" + strCaseId + "' AND " +
    //                                                    htGetAdditionalFields[iIteratorDesc.ToString()].ToString() + "='" +
    //                                                    htGetAdditionalValues[iIteratorDesc.ToString()].ToString() + "'";                                            
    //                                    }
    //                                    else
    //                                    {
    //                                        //if (htGetAdditionalValues[iIteratorDesc.ToString()] != null)
    //                                        //    strVals = GetValues(iIterator, iIteratorDesc, htGetIterationHeader[iIteratorDesc.ToString()].ToString()) + "," + htGetAdditionalValues[iIteratorDesc.ToString()].ToString() + ",'" + strCaseId + "'";
    //                                        //else
    //                                        //    strVals = GetValues(iIterator, iIteratorDesc, htGetIterationHeader[iIteratorDesc.ToString()].ToString()) + ",'" + strCaseId + "'";
    //                                        for (int i = 0; i < arrIterDesc.Length; i++)  //for rating ------
    //                                        {
    //                                            if (arrIterDesc[i] == "[RV Rating]" || (arrIterDesc[i] == "[BV Rating]"))
    //                                            {
    //                                                if (arrValuesDesc[i].Trim() != "")
    //                                                {
    //                                                    if (arrValuesDesc[i] == "88")     //For 88-Negative,99-Positive
    //                                                        arrValuesDesc[i] = "2";
    //                                                    else if (arrValuesDesc[i] == "99")
    //                                                        arrValuesDesc[i] = "1";
    //                                                }
    //                                                else
    //                                                {
    //                                                    arrValuesDesc[i] = "''";
    //                                                }
    //                                                strTmpFieldsDesc += "'" + arrValuesDesc[i] + "',";
    //                                            }
    //                                            else
    //                                                strTmpFieldsDesc += "'" + arrValuesDesc[i] + "',";
    //                                        }
    //                                        strTmpFieldsDesc += "'" + htGetAdditionalValues[iIteratorDesc.ToString()] +
    //                                                            "','" + strCaseId + "'";

    //                                        strInsert = "Insert into " + htTable[iIteratorDesc.ToString()].ToString() +
    //                                                    " (" + strFieldsDesc +                                                        
    //                                                    ") values (" + strTmpFieldsDesc.TrimEnd(',') + ")";

    //                                    }
    //                                    if (strInsert != "")
    //                                        OleDbHelper.ExecuteNonQuery(objTrans, CommandType.Text, strInsert);

    //                                    oledbRead.Close();                                        
    //                                }
    //                            }
    //                            iIteratorDesc++;
    //                        }
    //                        ///------------------------------------------------------------------------------
    //                        ///Start Insert Remark entry ----------------------------------------------------
    //                        //strInsert = "";
    //                        //string strFields = "";
    //                        //string strTmpFields = "";
    //                        //int iIteratorRVRemark = 13; //10[RV Verification Remarks],11[BV Verification Remarks]
    //                        //while (iIteratorRVRemark <= 14) //for [RV Verification Remarks],[BV Verification Remarks]
    //                        //{
    //                        //    if (htGetPrimaryHeaders[iIteratorRVRemark.ToString()] != null)
    //                        //    {
    //                        //        if (dsExcel.Tables[iIteratorRVRemark].Rows[iIterator][htGetPrimaryHeaders[iIteratorRVRemark.ToString()].ToString().TrimStart('[').TrimEnd(']')].ToString().Trim() != "")
    //                        //        {
    //                        //            strInsert = "";
    //                        //            if (htGetAdditionalValues[iIteratorRVRemark.ToString()] != null)
    //                        //                strVals = GetValues(iIterator, iIteratorRVRemark, htGetIterationHeader[iIteratorRVRemark.ToString()].ToString());
    //                        //            else
    //                        //                strVals = GetValues(iIterator, iIteratorRVRemark, htGetIterationHeader[iIteratorRVRemark.ToString()].ToString());

    //                        //            strFields = "";
    //                        //            strFields = htFields[iIteratorRVRemark.ToString()].ToString();
    //                        //            string[] arrRVRemark = strFields.Split(',');

    //                        //            strTmpFields = "";

    //                        //            for (int i = 0; i < arrRVRemark.Length - 1; i++)
    //                        //            {
    //                        //                strTmpFields += arrRVRemark[i];
    //                        //            }

    //                        //            strInsert = "Select * from " + htTable[iIteratorRVRemark.ToString()].ToString() + " Where Case_id='" + strCaseId + "' AND " +
    //                        //                       htGetAdditionalFields[iIteratorRVRemark.ToString()].ToString() + "=" +
    //                        //                       htGetAdditionalValues[iIteratorRVRemark.ToString()].ToString();

    //                        //            oledbRead = OleDbHelper.ExecuteReader(objTrans, CommandType.Text, strInsert);
    //                        //            //If FE_Remark entry already exists(case_id+verification_type_id) 
    //                        //            //then update entry else insert.------------------------------------
    //                        //            if (oledbRead.Read() == true)
    //                        //            {

    //                        //                strInsert = "Update " + htTable[iIteratorRVRemark.ToString()].ToString() + " SET ";
    //                        //                strInsert += strTmpFields.TrimEnd(',') + "= ";
    //                        //                strInsert += strVals.TrimStart(',') +
    //                        //                              " Where Case_id='" + strCaseId + "' AND " +
    //                        //                              htGetAdditionalFields[iIteratorRVRemark.ToString()].ToString() + "=" +
    //                        //                              htGetAdditionalValues[iIteratorRVRemark.ToString()].ToString();
    //                        //            }
    //                        //            else
    //                        //            {

    //                        //                if (htGetAdditionalValues[iIteratorRVRemark.ToString()] != null)
    //                        //                    strVals += "," + htGetAdditionalValues[iIteratorRVRemark.ToString()].ToString() + ",'" + strCaseId + "'";
    //                        //                else
    //                        //                    strVals += ",'" + strCaseId + "'";

    //                        //                strInsert = "Insert into " + htTable[iIteratorRVRemark.ToString()].ToString() +
    //                        //                            " (" + strTmpFields + "," +
    //                        //                            htGetAdditionalFields[iIteratorRVRemark.ToString()].ToString() +
    //                        //                            ",CASE_ID" + ") values (" + strVals.TrimStart(',') + ")";

    //                        //            }

    //                        //            if (strInsert != "")
    //                        //                OleDbHelper.ExecuteNonQuery(objTrans, CommandType.Text, strInsert);

    //                        //            oledbRead.Close();
                                        
    //                        //        }
    //                        //    }
    //                        //    iIteratorRVRemark++;
    //                        //}
    //                        ///End Insert Remark entry -----------------------------------------------
    //                        ////End Verification Entry------------------------------------------------                  
    //                        ///Start Insert case_status entry ----------------------------------------
    //                        //int iIteratorRVRating = 15;
    //                        //while (iIteratorRVRating <= 16)
    //                        //{
    //                        //    if (htGetPrimaryHeaders[iIteratorRVRating.ToString()] != null)
    //                        //    {
    //                        //        if (dsExcel.Tables[iIteratorRVRating].Rows[iIterator][htGetPrimaryHeaders[iIteratorRVRating.ToString()].ToString().TrimStart('[').TrimEnd(']')].ToString().Trim() != "")
    //                        //        {
    //                        //            strInsert = "";
    //                        //            if (htGetAdditionalValues[iIteratorRVRating.ToString()] != null)
    //                        //                strVals = GetValues(iIterator, iIteratorRVRating, htGetIterationHeader[iIteratorRVRating.ToString()].ToString());
    //                        //            else
    //                        //                strVals = GetValues(iIterator, iIteratorRVRating, htGetIterationHeader[iIteratorRVRating.ToString()].ToString());

    //                        //            strVals = strVals.TrimStart(',');
    //                        //            strVals = strVals.Replace("'", "");

    //                        //            if (strVals.Trim() != "")
    //                        //            {
    //                        //                if (strVals == "88")     //For 88-Negative,99-Positive
    //                        //                    strVals = "2";
    //                        //                else if (strVals == "99")
    //                        //                    strVals = "1";
    //                        //            }
    //                        //            else
    //                        //            {
    //                        //                strVals = "''";
    //                        //            }

    //                        //            if (htGetAdditionalValues[iIteratorRVRating.ToString()] != null)
    //                        //                strVals += "," + htGetAdditionalValues[iIteratorRVRating.ToString()].ToString() + ",'" + strCaseId + "'";
    //                        //            else
    //                        //                strVals += ",'" + strCaseId + "'";

    //                        //            strInsert = "Insert into " + htTable[iIteratorRVRating.ToString()].ToString() +
    //                        //                        " (" + htFields[iIteratorRVRating.ToString()].ToString() + "," +
    //                        //                        " CASE_ID" + ") values (" + strVals.TrimStart(',') + ")";

    //                        //            //}
    //                        //            if (strInsert != "")
    //                        //                OleDbHelper.ExecuteNonQuery(objTrans, CommandType.Text, strInsert);
                                                                                
    //                        //            //End Insert case_status entry ----------------------------------------
    //                        //        }
    //                        //    }
    //                        //    iIteratorRVRating++;
    //                        //}
    //                    }
    //                    catch (Exception ex)
    //                    {
    //                        objTrans.Rollback();
    //                        LogImport("NA", "Invalid data"+ ex.Message);
    //                        //log error here
    //                        continue;
    //                        //objCon.Close();
    //                    }
    //                }
    //            }
    //            catch (Exception ex)
    //            {
    //                objTrans.Rollback();
    //                LogImport((iIterator + 1).ToString(), (iIterator + 1).ToString() + " row can not be imported. Error:" + ex.Message);
    //                //log error here                
    //                continue;
    //                //objCon.Close();
    //            }
    //            finally
    //            {
    //                iIterator++;
    //                //SrCount += 1;
    //            }

    //            //if (dtImportLog.Rows.Count == 0)
    //            //    objTrans.Commit();
    //            //else
    //            //    objTrans.Rollback();
    //            objTrans.Commit();
    //            isImport = true;
    //        }
    //        //return true;
    //        return isImport;
    //    }
    //    catch (Exception exp)
    //    {
    //        LogImport("NA", "Please change name of Worksheet to 'Sheet1' or Change header names according to the template selected. Error:" + exp.Message);
    //        return false;
    //    }
    //    finally
    //    {
    //        //Some action
    //    }
    //}

    public bool ImportExcel()
    {
        bool isImport = false;
        Hashtable htImportSteps = new Hashtable();
        htImportSteps = GetExcelHeaders();

        Hashtable htFields = new Hashtable();
        htFields = GetFields();

        Hashtable htRefDetails = new Hashtable();
        htRefDetails = GetReferneceDetails();

        Hashtable htTable = new Hashtable();
        htTable = GetTable();

        Hashtable htGetPrimaryHeaders = new Hashtable();
        htGetPrimaryHeaders = GetPrimaryHeaders();

        Hashtable htGetAdditionalValues = new Hashtable();
        htGetAdditionalValues = GetAdditionalValues();

        Hashtable htGetIterationHeader = new Hashtable();
        htGetIterationHeader = GetIterationHeader();

        htGetHeadProcess = new Hashtable();
        htGetHeadProcess = GetHeadProcess();

        //Added by hemangi kambli on 07-Aug-2007 --------------
        Hashtable htGetAdditionalFields = new Hashtable();
        htGetAdditionalFields = GetAdditionalFields();
        //-----------------------------------------------------

        String strFile = HttpContext.Current.Server.MapPath("../../ImportFiles/" + BatchId + ".xls");
        string strConn = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + strFile + @";Extended Properties=""Excel 8.0;IMEX=1""";

        try
        {
            int iStepCounter = 0;
            while (iStepCounter < htImportSteps.Count)
            {
                String STR = "SELECT " + htImportSteps[iStepCounter.ToString()].ToString().TrimEnd(',') + " FROM [Sheet1$] ";
                //Select From Excel and Filling data in to DataSet
                OleDbDataAdapter myCommand = new OleDbDataAdapter(STR, strConn);
                DataTable dt = new DataTable();
                myCommand.Fill(dt);
                dsExcel.Tables.Add(dt);
                iStepCounter++;
            }
            if (htImportSteps.Count > 0)
            {
                objCon = new OleDbConnection(objCommon.ConnectionString);
                objCon.Open();

                int iIterator = 0;
                TotalCases = dsExcel.Tables[0].Rows.Count;
                while (iIterator < dsExcel.Tables[0].Rows.Count) //Iterate through ref_no...
                {
                    objTrans = objCon.BeginTransaction();
                    try
                    {
                        string strCaseId = "";
                        strCaseId = GetCaseId(dsExcel.Tables[0].Rows[iIterator][0].ToString());
                        if (strCaseId == "")
                        {
                            objTrans.Rollback();
                            TotalCases--;
                            LogImport((iIterator + 1).ToString(), (iIterator + 1).ToString() + " row can not be imported. Case with Reference No. '" + dsExcel.Tables[0].Rows[iIterator][0].ToString() + "' does not exists. ");
                            continue;
                        }
                        else
                        {
                            try
                            {
                                //Added by hemangi kambli on 07-Aug-2007 ---------------

                                int iIterator1 = 2;
                                string strVals = "";
                                string strInsert = "";
                                //Start Update Send_dateTime in CPV_CC_CASE_DETAILS table-----
                                int iIteratorUpdate = 1;
                                strVals = GetValues(iIterator, iIteratorUpdate, htGetIterationHeader[iIteratorUpdate.ToString()].ToString());

                                strInsert = "Update " + htTable[iIteratorUpdate.ToString()].ToString() + " SET " +
                                            htFields[iIteratorUpdate.ToString()].ToString() + "= " + strVals.TrimStart(',') +
                                            " WHERE CASE_ID='" + strCaseId + "'";

                                OleDbHelper.ExecuteNonQuery(objTrans, CommandType.Text, strInsert);
                                //End Update Send_dateTime in CPV_CC_CASE_DETAILS table-----

                                while (iIterator1 < htImportSteps.Count)
                                {
                                    strInsert = "";
                                    if (htGetPrimaryHeaders[iIterator1.ToString()] != null)
                                    {
                                        if (dsExcel.Tables[iIterator1].Rows[iIterator][htGetPrimaryHeaders[iIterator1.ToString()].ToString().TrimStart('[').TrimEnd(']')].ToString().Trim() != "")
                                        {
                                            if (htRefDetails[iIterator1.ToString()] == null)
                                            {
                                                if (htGetAdditionalValues[iIterator1.ToString()] != null)
                                                    strVals = GetValues(iIterator, iIterator1, htGetIterationHeader[iIterator1.ToString()].ToString()) + "," + htGetAdditionalValues[iIterator1.ToString()].ToString() + ",'" + strCaseId + "'";
                                                else
                                                    strVals = GetValues(iIterator, iIterator1, htGetIterationHeader[iIterator1.ToString()].ToString()) + ",'" + strCaseId + "'";
                                            }
                                            else
                                            {
                                                if (htGetAdditionalValues[iIterator1.ToString()] != null)
                                                    strVals = GetValues(iIterator, iIterator1, htGetIterationHeader[iIterator1.ToString()].ToString(), (Hashtable)htRefDetails[iIterator1.ToString()]) + "," + htGetAdditionalValues[iIterator1.ToString()].ToString() + ",'" + strCaseId + "'";
                                                else
                                                    strVals = GetValues(iIterator, iIterator1, htGetIterationHeader[iIterator1.ToString()].ToString(), (Hashtable)htRefDetails[iIterator1.ToString()]) + ",'" + strCaseId + "'";
                                            }

                                            strInsert = "Insert into " + htTable[iIterator1.ToString()].ToString() + " (" + htFields[iIterator1.ToString()].ToString() + ",CASE_ID" + ") values (" + strVals.TrimStart(',') + ")";

                                        }
                                    }
                                    else
                                    {
                                        if (htRefDetails[iIterator1.ToString()] == null)
                                        {
                                            if (htGetAdditionalValues[iIterator1.ToString()] != null)
                                                strVals = GetValues(iIterator, iIterator1, htGetIterationHeader[iIterator1.ToString()].ToString()) + "," + htGetAdditionalValues[iIterator1.ToString()].ToString() + ",'" + strCaseId + "'";
                                            else
                                                strVals = GetValues(iIterator, iIterator1, htGetIterationHeader[iIterator1.ToString()].ToString()) + ",'" + strCaseId + "'";
                                        }
                                        else
                                        {
                                            if (htGetAdditionalValues[iIterator1.ToString()] != null)
                                                strVals = GetValues(iIterator, iIterator1, htGetIterationHeader[iIterator1.ToString()].ToString(), (Hashtable)htRefDetails[iIterator1.ToString()]) + "," + htGetAdditionalValues[iIterator1.ToString()].ToString() + ",'" + strCaseId + "'";
                                            else
                                                strVals = GetValues(iIterator, iIterator1, htGetIterationHeader[iIterator1.ToString()].ToString(), (Hashtable)htRefDetails[iIterator1.ToString()]) + ",'" + strCaseId + "'";
                                        }

                                        strInsert = "Insert into " + htTable[iIterator1.ToString()].ToString() + " (" + htFields[iIterator1.ToString()].ToString() + ",CASE_ID" + ") values (" + strVals.TrimStart(',') + ")";
                                    }
                                    if (strInsert != "")
                                        OleDbHelper.ExecuteNonQuery(objTrans, CommandType.Text, strInsert);

                                    iIterator1++;
                                }

                            }
                            catch (Exception ex)
                            {
                                objTrans.Rollback();
                                LogImport("NA", "Invalid data" + ex.Message);
                                //log error here
                                continue;
                                //objCon.Close();
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        TotalCases--;
                        objTrans.Rollback();
                        LogImport((iIterator + 1).ToString(), (iIterator + 1).ToString() + " row can not be imported. Error:" + ex.Message);
                        //log error here                
                        continue;
                        //objCon.Close();
                    }
                    finally
                    {
                        iIterator++;
                        //SrCount += 1;
                    }

                    //if (dtImportLog.Rows.Count == 0)
                    //    objTrans.Commit();
                    //else
                    //    objTrans.Rollback();
                    objTrans.Commit();
                    isImport = true;
                }
                //return true;
                return isImport;
            }
            else
            {
                LogImport("NA", "No default settings for this client to import the data dump,Please consult your administrator.");
                return false;
            }
        }
        catch (Exception exp)
        {
            LogImport("NA", "Please change name of Worksheet to 'Sheet1' or Change header names according to the template selected. Error:" + exp.Message);
            return false;
        }
        finally
        {
            //Some action
        }
    }
    private Hashtable GetHeadProcess()
    {
        Hashtable htReturn = new Hashtable();
        string strSql = "select Sequence_Id, HEADER_FIELDS1, HEADER_FIELDS2, PROCESS, FIELD_TYPE " +
                        " from DATADUMP_PROCESS where Client_Id ='" + ClientId + "'" +
                        " AND PRODUCT_ID='" + ProductId + "'";
        OleDbDataReader oDr = OleDbHelper.ExecuteReader(objCommon.ConnectionString, CommandType.Text, strSql);
        while (oDr.Read())
        {
            htReturn.Add(oDr["HEADER_FIELDS1"].ToString(), oDr["HEADER_FIELDS1"].ToString() + "," + oDr["HEADER_FIELDS2"].ToString() + "," + oDr["PROCESS"].ToString() + "," + oDr["FIELD_TYPE"].ToString());
        }
        oDr.Close();
        return htReturn;
    }

    private Hashtable GetAdditionalValues()
    {
        Hashtable htReturn = new Hashtable();
        string strSql = "select Sequence_Id, Additional_Values from datadump_master " +
                        " where Client_Id ='" + ClientId + "'" +
                        " AND PRODUCT_ID='" + ProductId + "'";

        OleDbDataReader oDr = OleDbHelper.ExecuteReader(objCommon.ConnectionString, CommandType.Text, strSql);
        while (oDr.Read())
        {
            htReturn.Add(oDr["Sequence_Id"].ToString(), oDr["Additional_Values"].ToString());
        }
        oDr.Close();
        return htReturn;
    }

    private Hashtable GetPrimaryHeaders()
    {
        Hashtable htReturn = new Hashtable();
        string strSql = "select Sequence_Id, Primary_Header from datadump_master " +
                        " where Client_Id ='" + ClientId + "'" +
                        " AND PRODUCT_ID='" + ProductId + "'";

        OleDbDataReader oDr = OleDbHelper.ExecuteReader(objCommon.ConnectionString, CommandType.Text, strSql);
        while (oDr.Read())
        {
            htReturn.Add(oDr["Sequence_Id"].ToString(), oDr["Primary_Header"].ToString());
        }
        oDr.Close();
        return htReturn;
    }

    private Hashtable GetTable()
    {
        Hashtable htReturn = new Hashtable();
        string strSql = "select Sequence_Id, Table_Name from datadump_master " +
                        " where Client_Id ='" + ClientId + "'" +
                        " AND PRODUCT_ID='" + ProductId + "'";

        OleDbDataReader oDr = OleDbHelper.ExecuteReader(objCommon.ConnectionString, CommandType.Text, strSql);
        while (oDr.Read())
        {
            htReturn.Add(oDr["Sequence_Id"].ToString(), oDr["Table_Name"].ToString());
        }
        oDr.Close();
        return htReturn;
    }

    private Hashtable GetFields()
    {
        Hashtable htReturn = new Hashtable();
        string strReturn = "";
        string strSql = "select Sequence_Id, Fields_name, Additional_Fields from datadump_master " +
                        " where Client_Id ='" + ClientId + "'" +
                        " AND PRODUCT_ID='" + ProductId + "'";

        OleDbDataReader oDr = OleDbHelper.ExecuteReader(objCommon.ConnectionString, CommandType.Text, strSql);
        while (oDr.Read())
        {
            strReturn=oDr["Fields_name"].ToString();
            if (oDr["Additional_Fields"].ToString() != "")
                strReturn = strReturn + "," + oDr["Additional_Fields"].ToString();
            htReturn.Add(oDr["Sequence_Id"].ToString(), strReturn);
        }
        oDr.Close();
        return htReturn;
    }


    private Hashtable GetReferneceDetails()
    {

        string strSql = "select DATADUMP_ID, SEQUENCE_ID, HEADER_FIELDS, IS_REF from DATADUMP_MASTER " +
                        " where CLIENT_ID ='" + ClientId + "'" + 
                        " AND PRODUCT_ID='" + ProductId + "'" + 
                        " order by SEQUENCE_ID";

        Hashtable htHeaders = new Hashtable();
        OleDbDataReader oDr = OleDbHelper.ExecuteReader(objCommon.ConnectionString, CommandType.Text, strSql);
        Hashtable htRefDetails = new Hashtable();
        while (oDr.Read())
        {
            if (oDr["IS_REF"].ToString() == "1")
            {
                string strGetReference = "Select REFERENCE_ID,REFERENCE_HEADERS, REFERENCE_TABLES  + ',' + REFERENCE_TO_FIELDS " +
                                         " + ',' + COMPARING_FIELDS as Details from DATADUMP_REFERENCE  " +
                                         " where DATADUMP_ID ='" + oDr["DATADUMP_ID"].ToString() + "'";
                OleDbDataReader oDr1 = OleDbHelper.ExecuteReader(objCommon.ConnectionString, CommandType.Text, strGetReference);
                while (oDr1.Read())
                {
                    //htRefDetails.Add(oDr1["REFERENCE_HEADERS"].ToString(), oDr1["Details"].ToString());
                    htRefDetails.Add(oDr1["REFERENCE_ID"].ToString(), oDr1["Details"].ToString());
                    
                }
                oDr1.Close();
                htHeaders.Add(oDr["SEQUENCE_ID"].ToString(), htRefDetails);
            }
        }
        oDr.Close();
        return htHeaders;
    }

    private Hashtable GetIterationHeader()
    {
        string strSql = "select SEQUENCE_ID, Iteration_header from DATADUMP_MASTER " +
                        " where CLIENT_ID ='" + ClientId + "'" +
                        " AND PRODUCT_ID='" + ProductId + "'" +
                        " order by SEQUENCE_ID";

        Hashtable htHeaders = new Hashtable();
        OleDbDataReader oDr = OleDbHelper.ExecuteReader(objCommon.ConnectionString, CommandType.Text, strSql);
        while (oDr.Read())
        {
            htHeaders.Add(oDr["SEQUENCE_ID"].ToString(), oDr["Iteration_header"].ToString());
        }
        oDr.Close();
        return htHeaders;
    }

    private string GetValues(int iRecordCount, int iStep, string strHeaders )
    {
        string strValue = "";
        string[] strHeader = strHeaders.Split(',');
        foreach (string str in strHeader)
        {
            strValue = strValue + ",'" + dsExcel.Tables[iStep].Rows[iRecordCount][str.TrimEnd(']').TrimStart('[')].ToString().Trim().Replace("'","''") + "'";
        }
        return strValue;
    }

    private string GetValues(int iRecordCount, int iStep, string strHeaders, Hashtable htRefDetails)
    {
        string strValue = "";

        string[] strHeader = strHeaders.Split(',');

        foreach (string str in strHeader)
        {
            
            if (htGetHeadProcess[str]!=null)
            {
                string[] strFieldProcess = htGetHeadProcess[str].ToString().Split(',');
                //HEADER_FIELDS1 "," HEADER_FIELDS2 "," PROCESS "," FIELD_TYPE
                if (strFieldProcess[3] == "datetime")
                {
                    DateTime dtDate = Convert.ToDateTime(dsExcel.Tables[iStep].Rows[iRecordCount][strFieldProcess[0].TrimEnd(']').TrimStart('[')]);
                    DateTime dtTime = Convert.ToDateTime(dsExcel.Tables[iStep].Rows[iRecordCount][strFieldProcess[1].TrimEnd(']').TrimStart('[')]);
                    DateTime dtDateTime = dtDate.Add(dtTime.TimeOfDay);
                    string strDateTime = dtDateTime.ToString("dd-MMM-yyyy hh:mm tt");
                    strValue = strValue + ",'" + strDateTime + "'";
                }
                else
                {

                }
                //added by hemangi kambli on 11-August-2007 --------------------------
                if (str == "[RV Rating]" || str == "[BV Rating]")   //for HSBC client 88(-ve2),99(+ve1)
                {
                    string stTmp = dsExcel.Tables[iStep].Rows[iRecordCount][str.TrimEnd(']').TrimStart('[')].ToString().Trim().Replace("'", "''");
                    if (stTmp.Trim() != "")
                    {
                        if (stTmp == "99")
                            strValue = strValue + ",'1'";
                        else if (stTmp == "88")
                            strValue = strValue + ",'2'";
                    }
                    else
                        strValue = strValue + ",''";
                }
                //----------------------------------------------------------------------
            }
            else
            {                
                if (htRefDetails[str] == null)
                    strValue = strValue + ",'" + dsExcel.Tables[iStep].Rows[iRecordCount][str.TrimEnd(']').TrimStart('[')].ToString().Trim().Replace("'", "''") + "'";
                else
                {
                    //REFERENCE_TABLES  , REFERENCE_TO_FIELDS , COMPARING_FIELDS
                    string[] strRef = htRefDetails[str].ToString().Split(',');

                    string strSqlGetRefVal = "select " + strRef[1] + " from " + strRef[0] + " where " +
                                             strRef[2] + "= '" + dsExcel.Tables[iStep].Rows[iRecordCount][str.TrimEnd(']').TrimStart('[')].ToString().Trim().Replace("'", "''") + "'";
                    object obj = OleDbHelper.ExecuteScalar(objCommon.ConnectionString, CommandType.Text, strSqlGetRefVal);
                    if (obj != null)
                        strValue = strValue + ',' + obj.ToString();
                    else
                        strValue = strValue + ',' + "''";
                }
            }
        }
        return strValue;
    }

    private Hashtable GetExcelHeaders()
    {
        string strSql = "select SEQUENCE_ID, HEADER_FIELDS from DATADUMP_MASTER" +
                        " where CLIENT_ID = '" + ClientId + "' And PRODUCT_ID='" + ProductId + "'" +
                        " order by SEQUENCE_ID";

        Hashtable htHeaders = new Hashtable();
        OleDbDataReader oDr = OleDbHelper.ExecuteReader(objCommon.ConnectionString, CommandType.Text, strSql);
        while (oDr.Read())
        {
            htHeaders.Add(oDr["SEQUENCE_ID"].ToString(), oDr["HEADER_FIELDS"].ToString());
        }
        oDr.Close();
        return htHeaders;
    }

    private string GetCaseId(string Ref_No)
    {
        string strSql = "Select Case_Id from CPV_CC_CASE_DETAILS where ref_no ='" + Ref_No + "' and SEND_DATETIME is null";
        object obj = OleDbHelper.ExecuteScalar(objCommon.ConnectionString, CommandType.Text,strSql);
        if (obj == null)
            return "";
        else
            return obj.ToString();
    }

    #endregion To Get Values From Excel And Insert Into the Table

    #region Import Log function
    private void LogImport(string strRowNumber, string strDetails)
    {
        dtImportLog.Rows.Add(strRowNumber, strDetails);
    }
    #endregion
    
    #region This function returns unique batchId for each mported valid excle data file.
    public void GetBatchID()
    {

        try
        {
            Int32 iBatchId = 0;
            String sSql = "";
            sSql = "SELECT [LAST_BATCH_ID] FROM [LAST_IMPORT_BATCH]";

            OleDbDataReader OleDbRead = OleDbHelper.ExecuteReader(objCommon.ConnectionString, CommandType.Text, sSql);
            if (OleDbRead.Read())
                iBatchId = Convert.ToInt32(OleDbRead[0].ToString());
            else
                iBatchId = 1;
            OleDbRead.Close();

            sSql = "UPDATE [LAST_IMPORT_BATCH] SET [LAST_BATCH_ID] = " + (iBatchId + 1);
            OleDbHelper.ExecuteNonQuery(objCommon.ConnectionString, CommandType.Text, sSql);
            strBatchId = iBatchId.ToString();
        }
        catch (System.Exception exp)
        {
            //SW = File.AppendText(HttpContext.Current.Server.MapPath("HutchRoTN_ImportFiles\\ErrorLog.txt"));
            //SW.WriteLine("Time : " + System.DateTime.Now);
            //SW.WriteLine("Error Occured :" + exp.Message);
            //SW.Close();
            throw new Exception("An error occurred :", exp);
        }
        finally
        {
            //Some action
        }
    }
    #endregion

}
