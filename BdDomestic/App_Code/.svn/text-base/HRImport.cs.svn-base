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
public class HRimport
{
    private CCommon objCommon;

    #region Constructor
    public HRimport()
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


    private String sCentreID;           //6
    private String sClusterID;          //7
    private String dtAdd;               //10
    private String sAddedBy;            //11
    private String sXslSheet;           //12
    private string strBatchId;          //14
    private string strTemplateId;       //15
    private string strClientId;         //18
    private DataTable dtImportLog;       //19
    private string strActivityId;        //20
    private string sPrefix;              //21
    private string strProductId;         //22
    private DataSet dsExcel;
    private int iTotalCases;

   
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

   
    public string BatchId   //14
    {
        get { return strBatchId; }
    }

    public string TemplateId    //15
    {
        get { return strTemplateId; }
        set { strTemplateId = value; }
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
    #region immporttable
    private DataTable immporttable(string centre, string year, string paidon,string centre1)
    {
        string qry = "";
        qry = "select * from employee_salary_detail1 where location = '"+ centre1 +"' and payout_month = '"+ year +"' and paidon = '"+ paidon +"'";
        Hashtable himport = new Hashtable();
        OleDbDataAdapter odr = new OleDbDataAdapter(qry, objCommon.ConnectionString);
        DataTable dt = new DataTable();
        DataSet ds = new DataSet();
        odr.Fill(ds, "Search");
        dt = ds.Tables["Search"];
        return dt;
    }
    #endregion






    #region To Get Values From Excel And Insert Into the Table

    public bool ImportExcel(string centre, string year, string paidon,string centre1)
    {
        try
        {
            DataTable dt1 = new DataTable();
            dt1 = immporttable(centre, year, paidon,centre1);
            
            if (dt1.Rows.Count == 0)
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
                ////if (himport.Count==0)
                ////{
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
                    int iIterator = 0, iIterator1 = 0;
                    string strVals = "";
                    string strInsert = "";
                    if (htImportSteps.Count > 0)
                    {
                        //int iIterator = 0;
                        objCon = new OleDbConnection(objCommon.ConnectionString);
                        objCon.Open();

                        TotalCases = dsExcel.Tables[0].Rows.Count;
                        //string qry = "";
                        //object mon1 = "";
                        //string mon = "";
                        //qry = "select substring(convert(varchar(11),getdate(),113),4,8)";
                        //mon1 = OleDbHelper.ExecuteScalar(objCommon.ConnectionString, CommandType.Text, qry);
                        ////OleDbDataAdapter DR = new OleDbDataAdapter(qry, objCommon.ConnectionString);
                        ////OleDbDataAdapter DR = new OleDbDataAdapter(qry, objCommon.ConnectionString);
                        ////mon1 = DR;
                        //mon = mon1.ToString();
                        while (iIterator < htImportSteps.Count) //Iterate through ref_no...
                        {




                            while (iIterator < dsExcel.Tables[0].Rows.Count)
                            {
                                strVals = GetValues(iIterator, iIterator1, htImportSteps[iIterator1.ToString()].ToString());
                                strInsert = "";

                                strInsert = "Insert into " + htTable[iIterator1.ToString()].ToString() + " (" + htFields[iIterator1.ToString()].ToString() + ",payout_month, paidon" + " ) values (" + strVals.TrimStart(',') + ",'" + year + "','" + paidon + "')";
                                if (strInsert != "")

                                    OleDbHelper.ExecuteNonQuery(objCommon.ConnectionString, CommandType.Text, strInsert);

                                iIterator++;
                                isImport = true;

                            }
                            iIterator1++;
                        }
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
            
            else
            {
                LogImport("NA", "The dump for Selected payout month year and location has already been generated");
                return false;
            }
        }
        catch (Exception ex)
        {
            LogImport("NA", "Please Check Month and Year.Error:" + ex.Message);
            return false;
        }
        finally
        {

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
            strReturn = oDr["Fields_name"].ToString();
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

    private string GetValues(int iRecordCount, int iStep, string strHeaders)
    {
        string strValue = "";
        string[] strHeader = strHeaders.Split(',');
        foreach (string str in strHeader)
        {
            strValue = strValue + ",'" + dsExcel.Tables[iStep].Rows[iRecordCount][str.TrimEnd(']').TrimStart('[')].ToString().Trim().Replace("'", "''") + "'";
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
           
            throw new Exception("An error occurred :", exp);
        }
        finally
        {
            //Some action
        }
    }
    #endregion

}
