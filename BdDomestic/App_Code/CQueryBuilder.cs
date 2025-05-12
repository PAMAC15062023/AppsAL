using System;
using System.Data;
using System.Collections;
using System.Data.OleDb;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

/// <summary>
/// Summary description for CQueryBuilder
/// </summary>
public class CQueryBuilder
{
	public CQueryBuilder()
	{
       oCmn = new CCommon();
	}
    private CCommon oCmn;
    private string strProductId;
    public string ViewName;
    public string strView;
    public string strTemplateName;
    public string WhereVerificationID;
    public string WVerificationId;
    public string strQueryToRun;
    public string strSelectClause;
    public string strClientId;
    public string strVerificationTypeID;
    public string strREC_FromDate;
    public string strREC_ToDate;
    public string strStatus;
    public string strWithinTAT;



    ArrayList list = new ArrayList();
    public string ProductId
    {
        get { return strProductId; }
        set { strProductId = value; }
    }

    public string View
    {
        get { return strView; }
        set { strView = value; }
    }
    public string TemplateName
    {
        get { return strTemplateName; }
        set { strTemplateName = value; }
    }

    public string QueryToRun
    {
        get { return strQueryToRun; }
        set { strQueryToRun = value; }

    }

    public string SelectClause
    {
        get { return strSelectClause; }
        set { strSelectClause = value; }
    }

    public string ClientID
    {
        get { return strClientId; }
        set { strClientId = value; }
    }

    public string VerificationTypeID
    {
        get { return strVerificationTypeID; }
        set { strVerificationTypeID = value; }
    }

    public string REC_FromDate
    {
        get { return strREC_FromDate; }
        set
        {
            if (value != "")
                strREC_FromDate = value;
            else
                strREC_FromDate = null;
        }
    }
    public string REC_ToDate
    {
        get { return strREC_ToDate; }
        set
        {
            if (value != "")
                strREC_ToDate = value;
            else
                strREC_ToDate = null;
        }
    }
    public string Status
    {
        get { return strStatus; }
        set { strStatus = value; }
    }

    public string WithinTAT
    {
        get { return strWithinTAT; }
        set { strWithinTAT = value; }
    }
        
        public DataSet GetValues()
    {
        OleDbConnection sqlcon = new OleDbConnection(oCmn.ConnectionString);
        sqlcon.Close();
        string strView = "SELECT Output_view, PRODUCT_iD FROM MAP_TABLE_MASTER WHERE(PRODUCT_iD = " + strProductId + ")";
        ViewName = Convert.ToString(OleDbHelper.ExecuteScalar(sqlcon, CommandType.Text, strView));
        View = ViewName;

        string strSelect = "select name from syscolumns WHERE id =(select id from sysobjects where name='" + ViewName + "') order by name";
        DataSet Ods = new DataSet();
        Ods = OleDbHelper.ExecuteDataset(sqlcon, CommandType.Text, strSelect);
        return Ods;
    }

    public DataTable Result(string strQueryToRun)
    {
        DataTable Odt = new DataTable();       
        Odt = OleDbHelper.ExecuteDataset(oCmn.ConnectionString, CommandType.Text, strQueryToRun).Tables[0];
        return Odt;
    }
    public DataTable GetVerificationType()
    {
        int i = 0;
        OleDbDataReader dr;
        DataTable dt = new DataTable();
        DataTable Adt = new DataTable();
        OleDbConnection sqlcon = new OleDbConnection(oCmn.ConnectionString);
        sqlcon.Open();
        string str = " SELECT DISTINCT activity_id FROM ce_ac_pr_ct_vw WHERE (product_id ='" + strProductId + "') ";
        dr = OleDbHelper.ExecuteReader(sqlcon, CommandType.Text, str);
        dr.Read();
        WVerificationId = dr["activity_id"].ToString();
        while (dr.Read())
        {
            list.Add(dr[i]);
            i++;
        }
        if (i > 1)
        {
            for (int j = 0; j < i - 1; j++)
            {
                WhereVerificationID = WhereVerificationID + "'" + list[j];
            }
        }
        else
        {
            WhereVerificationID = WVerificationId;
        }
        string strVerification = "SELECT '0' AS VERIFICATION_TYPE_ID, 'Select Verification Type' AS VERIFICATION_TYPE_CODE UNION SELECT VERIFICATION_TYPE_ID,VERIFICATION_TYPE_CODE FROM VERIFICATION_TYPE_MASTER WHERE ACTIVITY_ID IN("+WhereVerificationID+")";
        dt= OleDbHelper.ExecuteDataset(oCmn.ConnectionString, CommandType.Text, strVerification).Tables[0];
        sqlcon.Close();
        return dt;
    }

    public string SaveResult()   
    {
        string Result = "";
        string strTemplateId;
        OleDbConnection sqlcon = new OleDbConnection(oCmn.ConnectionString);
        sqlcon.Open();
        //Checking For TemplateId
        OleDbDataReader Odr;
        string strCheckTemplateName = "SELECT TEMPLATE_NAME FROM QUERY_BUILDER WHERE TEMPLATE_NAME='"+strTemplateName+"'";
        Odr = OleDbHelper.ExecuteReader(sqlcon, CommandType.Text, strCheckTemplateName);
        Odr.Read();
        if (Odr.HasRows)
        {
            Result = "Duplicate";
            return Result;
        }
        else
        {
           string strPrefix = "101";
            OleDbTransaction sqlTrans = sqlcon.BeginTransaction();
            try
            {
                strTemplateId=oCmn.GetUniqueID("QUERY_BUILDER",strPrefix).ToString();
                string strSaveResult = "INSERT INTO QUERY_BUILDER VALUES(?,?,?,?,?,?,?,?,?,?,?,?)";
                OleDbParameter[] ParamSave = new OleDbParameter[12];
                
                ParamSave[0] = new OleDbParameter("@Template_ID", OleDbType.VarChar, 15);
                ParamSave[0].Value = strTemplateId;

                ParamSave[1] = new OleDbParameter("@Template_Name", OleDbType.VarChar,30);
                ParamSave[1].Value = strTemplateName;

                ParamSave[2] = new OleDbParameter("@Template_query", OleDbType.VarChar, 500);
                ParamSave[2].Value = strQueryToRun;

                ParamSave[3] = new OleDbParameter("@ViewName", OleDbType.VarChar, 30);
                ParamSave[3].Value = strView;

                ParamSave[4] = new OleDbParameter("@Select_Clause", OleDbType.VarChar, 300);
                ParamSave[4].Value = strSelectClause;

                ParamSave[5] = new OleDbParameter("@ProductID", OleDbType.VarChar, 10);
                ParamSave[5].Value = strProductId;

                ParamSave[6] = new OleDbParameter("@ClientId", OleDbType.VarChar, 10);
                ParamSave[6].Value = strClientId;

                ParamSave[7] = new OleDbParameter("@Verification_TypeID", OleDbType.VarChar, 10);
                ParamSave[7].Value = strVerificationTypeID;

                if (strREC_FromDate != null)
                {
                    ParamSave[8] = new OleDbParameter("@RecFromDt", OleDbType.Date, 8);
                    ParamSave[8].Value = strREC_FromDate;
                }
                else
                {
                    ParamSave[8] = new OleDbParameter("@RecFromDt", OleDbType.Date, 8);
                    ParamSave[8].Value = REC_FromDate;
                }

                if(strREC_ToDate!=null)
                {
                ParamSave[9]=new OleDbParameter("@RecToDt",OleDbType.Date,8);
                ParamSave[9].Value=strREC_ToDate;
                }
                else
                { 
                 ParamSave[9]=new OleDbParameter("@RecToDt",OleDbType.Date,8);
                 ParamSave[9].Value=REC_ToDate;
                }

                ParamSave[10]=new OleDbParameter("@Status",OleDbType.VarChar,1);
                ParamSave[10].Value=strStatus;

                ParamSave[11]=new OleDbParameter("@WithinTAT",OleDbType.VarChar,1);
                ParamSave[11].Value=strWithinTAT;
                
                
                OleDbHelper.ExecuteNonQuery(sqlTrans, CommandType.Text, strSaveResult, ParamSave);
                
                
                sqlTrans.Commit();
                sqlcon.Close();
                
            }
            catch(Exception ex)
            {
                sqlTrans.Rollback();
                sqlcon.Close();
                Result = "Error";
                return Result;
            }
             Result = "Save" ; 
            return  Result;
        }     
    }

    public DataTable GetTemplateValue(string TemplateName)
    {
        DataTable dt = new DataTable();
        OleDbConnection sqlcon = new OleDbConnection(oCmn.ConnectionString);
        sqlcon.Open();
        string strTEMPLATEQUERY = "SELECT TEMPLATE_QUERY FROM QUERY_BUILDER WHERE TEMPLATE_NAME='" + TemplateName + "' ";
        string Querry =Convert.ToString(OleDbHelper.ExecuteScalar(sqlcon, CommandType.Text, strTEMPLATEQUERY));
        dt = OleDbHelper.ExecuteDataset(oCmn.ConnectionString, CommandType.Text, Querry).Tables[0];
        sqlcon.Close();
        return dt;   
    }
    public string GetTemplateSelectClause()
    {
        string s = "";
        OleDbDataReader Odr;
        OleDbConnection sqlcon = new OleDbConnection(oCmn.ConnectionString);
        sqlcon.Open();
        string strSelectClause = "SELECT SELECT_CLAUSE FROM QUERY_BUILDER WHERE TEMPLATE_NAME='" + TemplateName + "' ";
        Odr = OleDbHelper.ExecuteReader(sqlcon, CommandType.Text, strSelectClause);
        if (Odr.HasRows)
        {
            Odr.Read();
             s = Odr[0].ToString();
        }
        return s;
        //int iIndex = Querry.IndexOf("WHERE");
        //int l1 = Querry.Length;
        //int actual = l1 - iIndex;
        //string stesting = Querry.Substring(0, iIndex - 1);
        //string sTest = Querry.Replace("", "");       
    }
    public int GetProductID()
    {
        OleDbConnection sqlcon = new OleDbConnection(oCmn.ConnectionString);
        sqlcon.Open();
        string selectProductId = "SELECT PRODUCT_ID FROM QUERY_BUILDER WHERE TEMPLATE_NAME='"+strTemplateName+"'";
        int PID= Convert.ToInt32(OleDbHelper.ExecuteScalar(sqlcon, CommandType.Text, selectProductId));
        sqlcon.Close();
        return PID;
    }
    
    public bool DeleteTemplate(string TemplateName)
    { 
        OleDbConnection sqlcon = new OleDbConnection(oCmn.ConnectionString);
        sqlcon.Open();
        try
        {
            string strDelTemplate = "DELETE FROM QUERY_BUILDER WHERE TEMPLATE_NAME='" + TemplateName + "' ";
            OleDbHelper.ExecuteNonQuery(sqlcon, CommandType.Text, strDelTemplate);
            sqlcon.Close();
            return true;
        }
        catch(Exception ex)
        {
            sqlcon.Close();
            return false;
        }
    }
    public void GetExtraEditValues(string TemplateName)
    {
        OleDbDataReader Odr;
        OleDbConnection sqlcon = new OleDbConnection(oCmn.ConnectionString);
        sqlcon.Open();
        string strExtraEditValues = "SELECT PRODUCT_ID, CLIENT_ID, VERIFICATION_TYPE_ID, REC_FROM_DATE, REC_TO_DATE, STATUS, WITH_IN_TAT FROM QUERY_BUILDER WHERE TEMPLATE_NAME='"+TemplateName+"'";
        Odr=OleDbHelper.ExecuteReader(sqlcon, CommandType.Text, strExtraEditValues);
        if (Odr.HasRows)
        {
            Odr.Read();
            ProductId = Odr["PRODUCT_ID"].ToString();
            ClientID = Odr["CLIENT_ID"].ToString();
            VerificationTypeID = Odr["VERIFICATION_TYPE_ID"].ToString();
            REC_FromDate = Odr["REC_FROM_DATE"].ToString();
            REC_ToDate = Odr["REC_TO_DATE"].ToString();
            Status = Odr["STATUS"].ToString();
            WithinTAT = Odr["WITH_IN_TAT"].ToString();          
        }
    }

    public string GetPreviousViewName(string TemplateName)
    {
        //try
       // {
            string view = "";
            OleDbConnection sqlcon = new OleDbConnection(oCmn.ConnectionString);
            sqlcon.Open();
            string strGetPreviousName = "SELECT VIEW_NAME FROM QUERY_BUILDER WHERE TEMPLATE_NAME='" + TemplateName + "'";
            view = Convert.ToString(OleDbHelper.ExecuteScalar(sqlcon, CommandType.Text, strGetPreviousName));
            return view;
       // }
        //catch (Exception ex)
        //{
        //}
    }
    public bool UpdateResult(string TemplateName)
    {
        OleDbConnection sqlcon = new OleDbConnection(oCmn.ConnectionString);
        sqlcon.Open();
        OleDbTransaction trans = sqlcon.BeginTransaction();
        try
        {                             
            //string strUpdateTemplate = "UPDATE QUERY_BUILDER SET TEMPLATE_QUERY =? SELECT_CLAUSE =?, CLIENT_ID =?, VERIFICATION_TYPE_ID =?, REC_FROM_DATE =?, REC_TO_DATE =?, STATUS =?, WITH_IN_TAT =? WHERE TEMPLATE_NAME=? ";

            //OleDbParameter[] paramUpdate=new OleDbParameter[9];
 
            //paramUpdate[0]=new OleDbParameter("@Template_Query",OleDbType.VarChar,500);
            //paramUpdate[0].Value=strQueryToRun;

            //paramUpdate[1]=new OleDbParameter("@SELECT_CLAUSE",OleDbType.VarChar,300);
            //paramUpdate[1].Value=strSelectClause;

            //paramUpdate[2] = new OleDbParameter("@CLIENT_ID", OleDbType.VarChar, 10);
            //paramUpdate[2].Value = strClientId;

            //paramUpdate[3] = new OleDbParameter("@VERIFICATION_TYPE_ID", OleDbType.VarChar, 10);
            //paramUpdate[3].Value = strVerificationTypeID;

            //if(strREC_FromDate!=null)
            //{
            //paramUpdate[4]=new OleDbParameter("@REC_FROM_DATE",OleDbType.Date,8);
            //paramUpdate[4].Value=strREC_FromDate;
            //}
            //else
            //{
            // paramUpdate[4]=new OleDbParameter("@REC_FROM_DATE",OleDbType.Date,8);
            // paramUpdate[4].Value=REC_FromDate;
            //}
            //if(strREC_ToDate!=null)
            //{
            //paramUpdate[5]=new OleDbParameter("@REC_TO_DATE",OleDbType.Date,8);
            //paramUpdate[5].Value=strREC_ToDate;
            //}
            //else
            //{
            //    paramUpdate[5] = new OleDbParameter("@REC_TO_DATE", OleDbType.Date, 8);
            //    paramUpdate[5].Value=REC_ToDate;  
            //}

            //paramUpdate[6]=new OleDbParameter("@STATUS",OleDbType.VarChar,1);
            //paramUpdate[6].Value=strStatus;

            //paramUpdate[7]=new OleDbParameter("@WITH_IN_TAT",OleDbType.VarChar,1);
            //paramUpdate[7].Value=strWithinTAT;

            //paramUpdate[8]=new OleDbParameter("@TEMPLATE_NAME",OleDbType.VarChar,30);
            //paramUpdate[8].Value=TemplateName;


            //OleDbHelper.ExecuteNonQuery(trans, CommandType.Text, strUpdateTemplate,paramUpdate);
            if (strREC_FromDate == null && strREC_ToDate == null)
            {
                string strUpdateTemplate = "UPDATE QUERY_BUILDER SET TEMPLATE_QUERY ='" + strQueryToRun + "', SELECT_CLAUSE ='" + strSelectClause + "', CLIENT_ID ='" + strClientId + "', VERIFICATION_TYPE_ID ='" + strVerificationTypeID + "', REC_FROM_DATE =null, REC_TO_DATE =null, STATUS ='" + strStatus + "', WITH_IN_TAT ='" + strWithinTAT + "' WHERE TEMPLATE_NAME='" + TemplateName + "' ";
                OleDbHelper.ExecuteNonQuery(trans, CommandType.Text, strUpdateTemplate);
            }
            else
            {
                string strUpdateTemplate = "UPDATE QUERY_BUILDER SET TEMPLATE_QUERY ='" + strQueryToRun + "', SELECT_CLAUSE ='" + strSelectClause + "', CLIENT_ID ='" + strClientId + "', VERIFICATION_TYPE_ID ='" + strVerificationTypeID + "', REC_FROM_DATE ='" + strREC_FromDate + "', REC_TO_DATE ='" + strREC_ToDate + "', STATUS ='" + strStatus + "', WITH_IN_TAT ='" + strWithinTAT + "' WHERE TEMPLATE_NAME='" + TemplateName + "' ";
                OleDbHelper.ExecuteNonQuery(trans, CommandType.Text, strUpdateTemplate);
            }
            

            trans.Commit();
            sqlcon.Close();
            return true;
        }
        catch (Exception ex)
        {
            trans.Rollback();
            return false;
        }
    }
}
