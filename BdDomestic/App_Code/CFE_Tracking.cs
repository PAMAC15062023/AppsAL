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
/// Summary description for CFE_Tracking
/// </summary>
public class CFE_Tracking
{
    CCommon objCon = new CCommon();
    //Declared by supriya  on 19/11/2007

    #region Propery Declarion 
    private String strFE_Code;     //1
    private String strFE_Name;   //2
    private String strCase_ID;  //3
    private String strVerification_type_Code;   //4
    private String strProduct_Code;  //5
    private String strClient_Code;
    private DateTime dtCheckOut;
    private DateTime dtCheckIn;
    private String strStatus;
    private String strCaseStatus;

    public String strFE_Code1   //1
    {
        get {
            return strFE_Code;
        }
        set
        {
           strFE_Code = value;           
        }
    }
    public String strFE_Name1    //2
    {
        get { 
            return strFE_Name;
        }
        set
        {                  
           strFE_Name = value;           
        }
    }
    public String strCase_ID1    //3
    {
        get { return strCase_ID; }
        set
        {
            
                strCase_ID = value;
           
        }
    }
    public String strVerification_type_Code1    //4
    {
        get { return strVerification_type_Code; }
        set
        {
           
                strVerification_type_Code = value;
            
        }
    }
    public String strProduct_Code1    //4
    {
        get { return strProduct_Code; }
        set
        {          
            strProduct_Code = value;            
        }
    }
    public String strClient_Code1    //4
    {
        get { return strClient_Code; }
        set
        {           
           strClient_Code = value;            
        }
    }
    public DateTime   dtCheckOut1    //4
    {
        get { return dtCheckOut; }
        set
        {
           
                dtCheckOut = value;
           
        }
    }
    public DateTime dtCheckIn1    //4
    {
        get { return dtCheckIn; }
        set
        {
           
                dtCheckIn = value;
            
        }
    }
    public String strStatus1    //4
    {
        get { return strStatus; }
        set
        {
           
                strStatus = value;
            
        }
    }
    public String strCaseStatus1    //4
    {
        get { return strCaseStatus; }
        set
        {

            strCaseStatus = value;

        }
    }


    #endregion Propery Declarion


    public CFE_Tracking()
	{
		//
		// TODO: Add constructor logic here
		//
	}


    public string InsertTrack()
    {
        OleDbConnection oledbCon = new OleDbConnection(objCon.ConnectionString);
        oledbCon.Open();
        string stravbl;
        OleDbTransaction oledbTrans = oledbCon.BeginTransaction();


        try
        {

            DataSet ds1 = new DataSet();
         // ds1 = GetFERepeat(strFE_Code, strCase_ID, strVerification_type_Code, strProduct_Code);
            ds1 = GetFERepeat1(strCase_ID, strVerification_type_Code, strProduct_Code);
            if (strCaseStatus == "Fresh")
            {
                if (ds1.Tables[0].Rows.Count == 0)
                {
                    string sqlQuery;
                    sqlQuery = "insert into FE_Tracking (FE_Code,FE_Name,Case_ID,Verification_Type_ID,Product_ID,Client_ID,CheckOut_Date,CheckIn_Date,Status,CaseStatus) values(?,?,?,?,?,?,?,?,?,?)";
                    OleDbParameter[] param_FETracking = new OleDbParameter[10];
                    param_FETracking[0] = new OleDbParameter("FE_Code", OleDbType.VarChar, 15);
                    param_FETracking[0].Value = strFE_Code1;
                    param_FETracking[1] = new OleDbParameter("FE_Name", OleDbType.VarChar, 15);
                    param_FETracking[1].Value = strFE_Name1;
                    param_FETracking[2] = new OleDbParameter("Case_ID", OleDbType.VarChar, 15);
                    param_FETracking[2].Value = strCase_ID1;
                    param_FETracking[3] = new OleDbParameter("Verification_Type_ID", OleDbType.VarChar, 15);
                    param_FETracking[3].Value = strVerification_type_Code1;
                    param_FETracking[4] = new OleDbParameter("Product_ID", OleDbType.VarChar, 15);
                    param_FETracking[4].Value = strProduct_Code1;
                    param_FETracking[5] = new OleDbParameter("Client_ID", OleDbType.VarChar, 15);
                    param_FETracking[5].Value = strClient_Code1;
                    param_FETracking[6] = new OleDbParameter("CheckOut_Date", OleDbType.Date, 8);
                    param_FETracking[6].Value = dtCheckOut1;
                    param_FETracking[7] = new OleDbParameter("CheckIn_Date", OleDbType.Date, 8);
                    param_FETracking[7].Value = dtCheckIn1;
                    param_FETracking[8] = new OleDbParameter("Status", OleDbType.VarChar, 20);
                    param_FETracking[8].Value = strStatus1;
                    param_FETracking[9] = new OleDbParameter("CaseStatus", OleDbType.VarChar, 20);
                    param_FETracking[9].Value = strCaseStatus1;
                    OleDbHelper.ExecuteNonQuery(oledbTrans, CommandType.Text, sqlQuery, param_FETracking);
                    oledbTrans.Commit();
                    oledbCon.Close();
                    stravbl = "Done";

                }
                else
                {
                    stravbl = "Available";
                }
            }
            else
            {
                UpdateRevisit(strCase_ID1, strVerification_type_Code1, strProduct_Code1);
               
                string sqlQuery;
                sqlQuery = "insert into FE_Tracking (FE_Code,FE_Name,Case_ID,Verification_Type_ID,Product_ID,Client_ID,CheckOut_Date,CheckIn_Date,Status,CaseStatus) values(?,?,?,?,?,?,?,?,?,?)";
                OleDbParameter[] param_FETracking = new OleDbParameter[10];
                param_FETracking[0] = new OleDbParameter("FE_Code", OleDbType.VarChar, 15);
                param_FETracking[0].Value = strFE_Code1;
                param_FETracking[1] = new OleDbParameter("FE_Name", OleDbType.VarChar, 15);
                param_FETracking[1].Value = strFE_Name1;
                param_FETracking[2] = new OleDbParameter("Case_ID", OleDbType.VarChar, 15);
                param_FETracking[2].Value = strCase_ID1;
                param_FETracking[3] = new OleDbParameter("Verification_Type_ID", OleDbType.VarChar, 15);
                param_FETracking[3].Value = strVerification_type_Code1;
                param_FETracking[4] = new OleDbParameter("Product_ID", OleDbType.VarChar, 15);
                param_FETracking[4].Value = strProduct_Code1;
                param_FETracking[5] = new OleDbParameter("Client_ID", OleDbType.VarChar, 15);
                param_FETracking[5].Value = strClient_Code1;
                param_FETracking[6] = new OleDbParameter("CheckOut_Date", OleDbType.Date, 8);
                param_FETracking[6].Value = dtCheckOut1;
                param_FETracking[7] = new OleDbParameter("CheckIn_Date", OleDbType.Date, 8);
                param_FETracking[7].Value = dtCheckIn1;
                param_FETracking[8] = new OleDbParameter("Status", OleDbType.VarChar, 20);
                param_FETracking[8].Value = strStatus1;
                param_FETracking[9] = new OleDbParameter("CaseStatus", OleDbType.VarChar, 20);
                if (strCaseStatus1 == "ReVisit")
                {
                    param_FETracking[9].Value = "Fresh";
                }
                else
                {
                    param_FETracking[9].Value = strCaseStatus1;
                }

                OleDbHelper.ExecuteNonQuery(oledbTrans, CommandType.Text, sqlQuery, param_FETracking);
                oledbTrans.Commit();
                oledbCon.Close();
                stravbl = "Done";


            }


        }
        catch (Exception ex)
        {
            oledbTrans.Rollback();
            oledbCon.Close();
            throw new Exception("Error Found During Inserting " + ex.Message);
        }
        return stravbl;
    }

    public DataSet CheckBarcode(string strFECode)
    {
        OleDbConnection sqlcon = new OleDbConnection(objCon.ConnectionString);
        sqlcon.Open();
        DataSet ds;
        try
        {
            String strSql = "SELECT Case_ID,Verification_Type_ID,Product_ID,Client_ID FROM [FE_Tracking] WHERE FE_Code='"+strFECode+"' ";
            ds = OleDbHelper.ExecuteDataset(sqlcon, CommandType.Text, strSql);
            sqlcon.Close();
        }
        catch (Exception exp)
        {
            sqlcon.Close();
            throw new Exception("Error while executing ", exp);
        }
        return ds;

    }
    

 public void UpdateFE_MappingReAssignFE(string strTableName,string strFEID,string strcid,string strvid)
    {
        OleDbConnection sqlcon = new OleDbConnection(objCon.ConnectionString);
        sqlcon.Open();


        OleDbTransaction TransUpdate = sqlcon.BeginTransaction();
        try
        {
            string strSql;
            if (strTableName != "CPV_RL_CASE_FE_MAPPING")
            {
                 strSql = "Update  " + strTableName + " set FE_ID='" + strFEID + "' where CASE_ID='" + strcid + "'AND VERIFICATION_TYPE_ID='" + strvid + "'";
            }
            else
            {
                 strSql = "Update  " + strTableName + " set FE_ID='" + strFEID + "'  where CASE_ID='" + strcid + "'AND VERIFICATION_TYPE_ID='" + strvid + "'";
         
            }

            OleDbHelper.ExecuteNonQuery(TransUpdate, CommandType.Text, strSql);
            TransUpdate.Commit();
            sqlcon.Close();
        }
        catch (Exception exp)
        {
            TransUpdate.Rollback();
            sqlcon.Close();
            throw new Exception("Error while executing ", exp);
        }



    }

    public void UpdateFE_Mapping(string strTableName,string strFEID,DateTime dtCheckout,string strcid,string strvid)
    {
        OleDbConnection sqlcon = new OleDbConnection(objCon.ConnectionString);
        sqlcon.Open();


        OleDbTransaction TransUpdate = sqlcon.BeginTransaction();
        try
        {
            string strSql;
            if (strTableName != "CPV_RL_CASE_FE_MAPPING")
            {
                 strSql = "Update  " + strTableName + " set FE_ID='" + strFEID + "',DATE_TIME='" + dtCheckOut + " ' where CASE_ID='" + strcid + "'AND VERIFICATION_TYPE_ID='" + strvid + "'";
            }
            else
            {
                 strSql = "Update  " + strTableName + " set FE_ID='" + strFEID + "',ASSIGN_DATETIME='" + dtCheckOut + "'  where CASE_ID='" + strcid + "'AND VERIFICATION_TYPE_ID='" + strvid + "'";
         
            }

            OleDbHelper.ExecuteNonQuery(TransUpdate, CommandType.Text, strSql);
            TransUpdate.Commit();
            sqlcon.Close();
        }
        catch (Exception exp)
        {
            TransUpdate.Rollback();
            sqlcon.Close();
            throw new Exception("Error while executing ", exp);
        }



    }
    public void  UpdateRevisit(string strCaseid, string strvId, string strPid)
    {
        OleDbConnection sqlcon = new OleDbConnection(objCon.ConnectionString);
        sqlcon.Open();

     
        OleDbTransaction TransUpdate = sqlcon.BeginTransaction();
        try
        {
           
                string strSql = "Update  FE_Tracking set CaseStatus='Revisit' where  Case_Id='" + strCaseid + "' AND Verification_Type_Id='" + strvId + "' AND Product_Id='" + strPid + "'  ";
                OleDbHelper.ExecuteNonQuery(TransUpdate, CommandType.Text, strSql);
                TransUpdate.Commit();
                sqlcon.Close();
               
           

        }
        catch (Exception exp)
        {
            TransUpdate.Rollback();
            sqlcon.Close();
            throw new Exception("Error while executing ", exp);
        }

        

    }

    public string  UpdateStatus(string strfecode,string strCaseid,string strvId,string strPid,DateTime date,string strCStatus)
    {
        OleDbConnection sqlcon = new OleDbConnection(objCon.ConnectionString);
        sqlcon.Open();

        string precheck;
        string st;
        OleDbTransaction TransUpdate = sqlcon.BeginTransaction();
        try
        {
              DataSet ds1 = new DataSet();
            ds1 = GetPreStatus(strfecode, strCaseid, strvId , strPid);
             st= ds1.Tables[0].Rows[0][0].ToString();
            if ( st == "Issued")
            {
                string strSql = "Update  FE_Tracking set Status='Closed',CheckIn_Date='" + date + "',CaseStatus='"+strCStatus+"' where FE_Code='" + strfecode + "'AND Case_Id='" + strCaseid + "' AND Verification_Type_Id='" + strvId + "' AND Product_Id='" + strPid + "'  ";
                OleDbHelper.ExecuteNonQuery(TransUpdate, CommandType.Text, strSql);
                TransUpdate.Commit();
                sqlcon.Close();
                precheck ="changed";
            }
            else
            {
                precheck = "Not changed";

            }

        }
        catch (Exception exp)
        {
            TransUpdate.Rollback();
            sqlcon.Close();
            throw new Exception("Error while executing ", exp);
        }

        return precheck;

    }



    public string  ReassignFE(string strfecode,string strFeName, string strCaseid, string strvId, string strPid)
    {
        OleDbConnection sqlcon = new OleDbConnection(objCon.ConnectionString);
        sqlcon.Open();

        string precheck;
        string st;
        OleDbTransaction TransUpdate = sqlcon.BeginTransaction();
        try
        {


            string strSql = "Update  FE_Tracking set FE_Code='" + strfecode + "',FE_Name='" + strFeName + "' where Case_Id='" + strCaseid + "' AND Verification_Type_Id='" + strvId + "' AND Product_Id='" + strPid + "'  ";
                OleDbHelper.ExecuteNonQuery(TransUpdate, CommandType.Text, strSql);
                TransUpdate.Commit();
                sqlcon.Close();
                precheck = "Changed";
           

        }
        catch (Exception exp)
        {
            TransUpdate.Rollback();
            sqlcon.Close();
            throw new Exception("Error while executing ", exp);
        }

        return precheck;

    }
    public DataSet GetPreStatus(string strfecode, string strCaseid, string strvId, string strPid)
    {
        OleDbConnection sqlcon = new OleDbConnection(objCon.ConnectionString);
        sqlcon.Open();

        DataSet ds = new DataSet();

        try
        {
            string strSql = "select Status from FE_Tracking where FE_Code='" + strfecode + "'AND Case_Id='" + strCaseid + "' AND Verification_Type_Id='" + strvId + "' AND Product_Id='" + strPid + "'  ";


            ds = OleDbHelper.ExecuteDataset(sqlcon, CommandType.Text, strSql);

            sqlcon.Close();
        }
        catch (Exception exp)
        {

            sqlcon.Close();
            throw new Exception("Error while executing ", exp);
        }

        return ds;

    }

    public DataSet GetFERepeat1( string strCaseid, string strvId, string strPid)
    {
        OleDbConnection sqlcon = new OleDbConnection(objCon.ConnectionString);
        sqlcon.Open();

        DataSet ds = new DataSet();

        try
        {
            string strSql = "select FE_Code from FE_Tracking where  Case_Id='" + strCaseid + "' AND Verification_Type_Id='" + strvId + "' AND Product_Id='" + strPid + "'  ";


            ds = OleDbHelper.ExecuteDataset(sqlcon, CommandType.Text, strSql);

            sqlcon.Close();
        }
        catch (Exception exp)
        {

            sqlcon.Close();
            throw new Exception("Error while executing ", exp);
        }

        return ds;

    }

    public DataSet  GetFERepeat( string strFECode,string strCaseid, string strvId, string strPid)
    {
        OleDbConnection sqlcon = new OleDbConnection(objCon.ConnectionString);
        sqlcon.Open();

        DataSet ds = new DataSet();
        
        try
        {
            string strSql = "select FE_Code from FE_Tracking where FE_Code='"+ strFECode+"'AND Case_Id='" + strCaseid + "' AND Verification_Type_Id='" + strvId + "' AND Product_Id='" + strPid + "'  ";


            ds = OleDbHelper.ExecuteDataset(sqlcon, CommandType.Text, strSql);
         
            sqlcon.Close();
        }
        catch (Exception exp)
        {
          
            sqlcon.Close();
            throw new Exception("Error while executing ", exp);
        }

        return ds;

    }


    public int  GetFEcasesPending(string strFECode)
    {
        OleDbConnection sqlcon = new OleDbConnection(objCon.ConnectionString);
        sqlcon.Open();
        int Count;
        DateTime dT = System.DateTime.Today.Date;
        DataSet ds = new DataSet();

        try
        {
            string strSql = "select count(*)as count from FE_Tracking where  FE_Code='" + strFECode + "' AND Status='Issued'"; //AND CheckOut_Date <='" + dT + "'";//AND  CheckIn_Date = '" + dT.AddDays(1.0) + "' ";


            ds = OleDbHelper.ExecuteDataset(sqlcon, CommandType.Text, strSql);
            Count = Convert.ToInt32( ds.Tables[0].Rows[0][0].ToString());
            sqlcon.Close();
        }
        catch (Exception exp)
        {

            sqlcon.Close();
            throw new Exception("Error while executing ", exp);
        }

        return Count;

    }

    public DataSet  getFE_Name(string strFECode)
    {
      
        OleDbConnection sqlcon = new OleDbConnection(objCon.ConnectionString);
        sqlcon.Open();
        DataSet ds;
        
        try
        {
            String strSql = "SELECT FULLNAME,EMP_ID FROM [EMPLOYEE_MASTER] WHERE EMP_Code='" + strFECode + "' ";
            ds = OleDbHelper.ExecuteDataset(sqlcon, CommandType.Text, strSql);
          

            sqlcon.Close();
        }
        catch (Exception exp)
        {
            sqlcon.Close();
            throw new Exception("Error while executing ", exp);
        }
        return ds;

    }

    public string getProductCode(string strPid)
    {
        string strPcode = "";
        OleDbConnection sqlcon = new OleDbConnection(objCon.ConnectionString);
        sqlcon.Open();
        DataSet ds;
        try
        {
            String strSql = "SELECT PRODUCT_CODE  FROM [PRODUCT_MASTER] WHERE PRODUCT_ID='" + strPid + "' ";
            ds = OleDbHelper.ExecuteDataset(sqlcon, CommandType.Text, strSql);
            if (ds.Tables[0].Rows.Count != 0)
            {
                strPcode = ds.Tables[0].Rows[0][0].ToString();
            }

            sqlcon.Close();
        }
        catch (Exception exp)
        {
            sqlcon.Close();
            throw new Exception("Error while executing ", exp);
        }
        return strPcode;

    }


    public string getClientId(string strTB,string strTB1,string strcaseid,string strvid,string strcenterid)
    {
        string strclientid = "";
        OleDbConnection sqlcon = new OleDbConnection(objCon.ConnectionString);
        sqlcon.Open();
        DataSet ds;
        try
        {
            String strSql = "select client_id from "+strTB +" cd inner join "+strTB1+" ccv on(cd.case_id=ccv.case_id)"+
                              "where cd.case_id="+strcaseid +" and ccv.verification_type_id="+strvid +" and centre_id="+strcenterid+" ";
            ds = OleDbHelper.ExecuteDataset(sqlcon, CommandType.Text, strSql);
            if (ds.Tables[0].Rows.Count != 0)
            {
                strclientid = ds.Tables[0].Rows[0][0].ToString();
            }

            sqlcon.Close();
        }
        catch (Exception exp)
        {
            sqlcon.Close();
            throw new Exception("Error while executing ", exp);
        }
        return strclientid;

    }

    public string getProductId(string strPbarcode)
    {
        string strPid = "";
        OleDbConnection sqlcon = new OleDbConnection(objCon.ConnectionString);
        sqlcon.Open();
        DataSet ds;
        try
        {
            String strSql = "SELECT product_id  FROM [Barcode] WHERE product_barcode='" + strPbarcode + "' ";
            ds = OleDbHelper.ExecuteDataset(sqlcon, CommandType.Text, strSql);
            if (ds.Tables[0].Rows.Count != 0)
            {
                strPid = ds.Tables[0].Rows[0][0].ToString();
            }

            sqlcon.Close();
        }
        catch (Exception exp)
        {
            sqlcon.Close();
            throw new Exception("Error while executing ", exp);
        }
        return strPid;

    }

    public string getVerificationId(string strVbarcode)
    {
        string strVid = "";
        OleDbConnection sqlcon = new OleDbConnection(objCon.ConnectionString);
        sqlcon.Open();
        DataSet ds;
        try
        {
            String strSql = "SELECT verification_type_id  FROM [Barcode] WHERE verification_type_barcode='" + strVbarcode + "' ";
            ds = OleDbHelper.ExecuteDataset(sqlcon, CommandType.Text, strSql);
            if (ds.Tables[0].Rows.Count != 0)
            {
                strVid = ds.Tables[0].Rows[0][0].ToString();
            }

            sqlcon.Close();
        }
        catch (Exception exp)
        {
            sqlcon.Close();
            throw new Exception("Error while executing ", exp);
        }
        return strVid;

    }


}
