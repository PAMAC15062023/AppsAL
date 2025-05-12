using System;
using System.Data;
using System.Data.OleDb;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

/// <summary>
/// Summary description for C_QueryBuilder_TATMIS
/// </summary>
public class C_QueryBuilder_TATMIS
{
    CCommon connobj = new CCommon();
	public C_QueryBuilder_TATMIS()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    private decimal decStdTAT_1;
    public decimal StdTAT_1
    {
        get { return decStdTAT_1; }
        set { decStdTAT_1 = value; }
    }

    private decimal decStdTAT_2;
    public decimal StdTAT_2
    {
        get { return decStdTAT_2; }
        set { decStdTAT_2 = value; }
    }

    private decimal decStdTAT_3;
    public decimal StdTAT_3
    {
        get { return decStdTAT_3; }
        set { decStdTAT_3 = value; }
    }
    private string strFromDate;
    public string FromDate
    {
        get { return strFromDate; }
        set { strFromDate = value; }
    }
    private string strToDate;
    public string ToDate
    {
        get { return strToDate; }
        set { strToDate = value; }
    }
    public DataTable GET_ALL_Product_Client(string CentreId)
    {
        DataTable dt = new DataTable();
        //Description   :  This Code is used To distingusish Repository PMS Database and PMS.
        //Created By    :  Gargi Srivastava
        //Created On    :  23-Nov-2007
        OleDbConnection con;
        if (HttpContext.Current.Session["DataBase"] != null)
        {

            if (HttpContext.Current.Session["DataBase"].ToString() == "RepositoryPMS")
            {
                con = new OleDbConnection(connobj.RepositoryConnectionString);
            }
            else
            {
                con = new OleDbConnection(connobj.ConnectionString);
            }
        }
        else
        {
            con = new OleDbConnection(connobj.ConnectionString);
        }
        //End Of Code
        con.Open();
        OleDbParameter[] param = new OleDbParameter[1];
        param[0] = new OleDbParameter("@CentreId", OleDbType.VarChar, 8000);
        param[0].Value = CentreId;
        param[0].Direction = ParameterDirection.Input;
        dt = OleDbHelper.ExecuteDataset(con, CommandType.StoredProcedure, "GET_All_Product_Client",param).Tables[0];
        con.Close();
        return dt;
    }

    public string GetTableName(string ProductName)
    {
        string TableName="";
        //Description   :  This Code is used To distingusish Repository PMS Database and PMS.
        //Created By    :  Gargi Srivastava
        //Created On    :  23-Nov-2007
        OleDbConnection con;
        if (HttpContext.Current.Session["DataBase"] != null)
        {

            if (HttpContext.Current.Session["DataBase"].ToString() == "RepositoryPMS")
            {
                con = new OleDbConnection(connobj.RepositoryConnectionString);
            }
            else
            {
                con = new OleDbConnection(connobj.ConnectionString);
            }
        }
        else
        {
            con = new OleDbConnection(connobj.ConnectionString);
        }
        //End Of Code
        con.Open();

        con.Close();
        switch (ProductName)
        {
            case "CC" :
                TableName = "CPV_CC_CASE_DETAILS";
                break;
            case "RL":
                TableName = "CPV_RL_CASE_DETAILS";
                break;
            case "CELLULAR":
                TableName = "CPV_CELLULAR_CASES";
                break;
            case "KYC":
                TableName = "CPV_KYC_CASE_DETAILS";
                break;
            case "EBC":
                TableName = "CPV_EBC_CASE_DETAILS";
                break;
            case "IDOC":
                TableName = "CPV_IDOC_CASE_DETAILS";
                break;
            case "DocCollection":
                TableName = "CPV_CC_CASE_DETAILS";
                break;
           

        }
        return TableName;
    }

    public DataTable GetTatHrs(string TableName, string ClientId)
    {
        DataTable dt = new DataTable();
        //Description   :  This Code is used To distingusish Repository PMS Database and PMS.
        //Created By    :  Gargi Srivastava
        //Created On    :  23-Nov-2007
        OleDbConnection con;
        if (HttpContext.Current.Session["DataBase"] != null)
        {

            if (HttpContext.Current.Session["DataBase"].ToString() == "RepositoryPMS")
            {
                con = new OleDbConnection(connobj.RepositoryConnectionString);
            }
            else
            {
                con = new OleDbConnection(connobj.ConnectionString);
            }
        }
        else
        {
            con = new OleDbConnection(connobj.ConnectionString);
        }
        //End Of Code
        con.Open();
        OleDbParameter[] param = new OleDbParameter[4];
        param[0] = new OleDbParameter("@TableName", OleDbType.VarChar, 50);
        param[0].Value = TableName;
        param[0].Direction = ParameterDirection.Input;
       
        param[1] = new OleDbParameter("@ClienId", OleDbType.VarChar, 8000);
        param[1].Value =ClientId;
        param[1].Direction = ParameterDirection.Input;

        param[2] = new OleDbParameter("@FromDate", OleDbType.VarChar, 50);
        param[2].Value = "'"+FromDate+"'";
        param[2].Direction = ParameterDirection.Input;

        param[3] = new OleDbParameter("@ToDate", OleDbType.VarChar, 50);
        param[3].Value ="'"+ ToDate+"'";
        param[3].Direction = ParameterDirection.Input;
       
        dt = OleDbHelper.ExecuteDataset(con, CommandType.StoredProcedure, "Get_Tat_Hrs", param).Tables[0];
        con.Close();
        return dt;
    }

    public DataTable GetTatHrs1(string TableName, string ClientId, string CentreId)
    {
        DataTable dt = new DataTable();
        //Description   :  This Code is used To distingusish Repository PMS Database and PMS.
        //Created By    :  Gargi Srivastava
        //Created On    :  23-Nov-2007
        OleDbConnection con;
        if (HttpContext.Current.Session["DataBase"] != null)
        {

            if (HttpContext.Current.Session["DataBase"].ToString() == "RepositoryPMS")
            {
                con = new OleDbConnection(connobj.RepositoryConnectionString);
            }
            else
            {
                con = new OleDbConnection(connobj.ConnectionString);
            }
        }
        else
        {
            con = new OleDbConnection(connobj.ConnectionString);
        }
        //End Of Code
        con.Open();
        OleDbParameter[] param = new OleDbParameter[5];
        param[0] = new OleDbParameter("@TableName", OleDbType.VarChar, 50);
        param[0].Value = TableName;
        param[0].Direction = ParameterDirection.Input;

        param[1] = new OleDbParameter("@ClienId", OleDbType.VarChar, 8000);
        param[1].Value = ClientId;
        param[1].Direction = ParameterDirection.Input;

        param[2] = new OleDbParameter("@CentreId", OleDbType.VarChar, 8000);
        param[2].Value = CentreId;
        param[2].Direction = ParameterDirection.Input;


        param[3] = new OleDbParameter("@FromDate", OleDbType.VarChar, 50);
        param[3].Value = "'" + FromDate + "'";
        param[3].Direction = ParameterDirection.Input;

        param[4] = new OleDbParameter("@ToDate", OleDbType.VarChar, 50);
        param[4].Value = "'" + ToDate + "'";
        param[4].Direction = ParameterDirection.Input;

        dt = OleDbHelper.ExecuteDataset(con, CommandType.StoredProcedure, "Get_Tat_Hrs_new", param).Tables[0];
        con.Close();
        return dt;
    }




    public void StdTatHrs(string ProductId,string ClientId )
    {
        //Description   :  This Code is used To distingusish Repository PMS Database and PMS.
        //Created By    :  Gargi Srivastava
        //Created On    :  23-Nov-2007
        OleDbConnection con;
        if (HttpContext.Current.Session["DataBase"] != null)
        {

            if (HttpContext.Current.Session["DataBase"].ToString() == "RepositoryPMS")
            {
                con = new OleDbConnection(connobj.RepositoryConnectionString);
            }
            else
            {
                con = new OleDbConnection(connobj.ConnectionString);
            }
        }
        else
        {
            con = new OleDbConnection(connobj.ConnectionString);
        }
        //End Of Code
        con.Open();
        OleDbDataReader Odr;
        OleDbParameter[] param = new OleDbParameter[2];
        param[0] = new OleDbParameter("@PRODUCT_ID", OleDbType.VarChar, 20);
        param[0].Value = ProductId;
        param[0].Direction = ParameterDirection.Input;

        param[1] = new OleDbParameter("@CLIENT_ID", OleDbType.VarChar, 8000);
        param[1].Value = ClientId;
        param[1].Direction = ParameterDirection.Input;
        Odr = OleDbHelper.ExecuteReader(con, CommandType.StoredProcedure, "GetStdTatHrs", param);
        Odr.Read();
        StdTAT_1 =Convert.ToDecimal(Odr["STD_HRS1"]);
        StdTAT_2 =Convert.ToDecimal(Odr["STD_HRS2"]);
        StdTAT_3 =Convert.ToDecimal(Odr["STD_HRS3"]);
        Odr.Close();
        con.Close();

    }
    public DataTable Centers(string CentreId)
    {
        DataTable dt = new DataTable();
        //Description   :  This Code is used To distingusish Repository PMS Database and PMS.
        //Created By    :  Gargi Srivastava
        //Created On    :  23-Nov-2007
        OleDbConnection con;
        if (HttpContext.Current.Session["DataBase"] != null)
        {

            if (HttpContext.Current.Session["DataBase"].ToString() == "RepositoryPMS")
            {
                con = new OleDbConnection(connobj.RepositoryConnectionString);
            }
            else
            {
                con = new OleDbConnection(connobj.ConnectionString);
            }
        }
        else
        {
            con = new OleDbConnection(connobj.ConnectionString);
        }
       //End Of Code
        con.Open();
        string str = "SELECT CENTRE_ID,CENTRE_NAME FROM CENTRE_MASTER WHERE CENTRE_ID in (" + CentreId + ")";
        dt = OleDbHelper.ExecuteDataset(con,CommandType.Text, str).Tables[0];
        con.Close();
        return dt;
     }

    public decimal Total_Tat_1(string TableName, string ClientID, string CentreId)
    {    
        OleDbConnection con;
        if (HttpContext.Current.Session["DataBase"] != null)
        {
            if (HttpContext.Current.Session["DataBase"].ToString() == "RepositoryPMS")
            {
                con = new OleDbConnection(connobj.RepositoryConnectionString);
            }
            else
            {
                con = new OleDbConnection(connobj.ConnectionString);
            }
        }
        else
        {
            con = new OleDbConnection(connobj.ConnectionString);
        }
        //End Of Code
        con.Open();
        string str = " SELECT  COUNT("+TableName+".CASE_ID) AS TAT1_total " +
                    " FROM " + TableName + " INNER JOIN " +
                    " CLIENT_MASTER ON " + TableName + ".CLIENT_ID = CLIENT_MASTER.CLIENT_ID " +
                    " WHERE (" + TableName + ".CASE_REC_DATETIME >='"+@FromDate+"') AND (" + TableName + ".CASE_REC_DATETIME < '"+@ToDate+"') AND  " +
                    " (" + TableName + ".TAT_HRS IS NOT NULL) AND (" + TableName + ".TAT_HRS <> '') AND  " +
                    " (CAST(REPLACE(" + TableName + ".TAT_HRS, ':', '.') AS float) <= " + StdTAT_1 + ") AND (CLIENT_MASTER.CLIENT_ID = " + @ClientID + ")AND (" + TableName + ".CENTRE_ID = " + @CentreId + ")"; 
        decimal TAT1_Total =Convert.ToDecimal(OleDbHelper.ExecuteScalar(con, CommandType.Text, str));
        con.Close();
        return TAT1_Total;
    }

    public decimal Total_Tat_2(string TableName, string ClientID, string CentreId)
    {
        OleDbConnection con;
        if (HttpContext.Current.Session["DataBase"] != null)
        {
            if (HttpContext.Current.Session["DataBase"].ToString() == "RepositoryPMS")
            {
                con = new OleDbConnection(connobj.RepositoryConnectionString);
            }
            else
            {
                con = new OleDbConnection(connobj.ConnectionString);
            }
        }
        else
        {
            con = new OleDbConnection(connobj.ConnectionString);
        }
        //End Of Code
        con.Open();
        string str = " SELECT  COUNT(" + TableName + ".CASE_ID) AS TAT2_total " +
                    " FROM " + TableName + " INNER JOIN " +
                    " CLIENT_MASTER ON " + TableName + ".CLIENT_ID = CLIENT_MASTER.CLIENT_ID " +
                    " WHERE (" + TableName + ".CASE_REC_DATETIME >='" + @FromDate + "') AND (" + TableName + ".CASE_REC_DATETIME < '" + @ToDate + "') AND  " +
                    " (" + TableName + ".TAT_HRS IS NOT NULL) AND (" + TableName + ".TAT_HRS <> '') AND  " +
                    " (CAST(REPLACE(" + TableName + ".TAT_HRS, ':', '.') AS float) > " + StdTAT_1 + ")AND (CAST(REPLACE(" + TableName + ".TAT_HRS, ':', '.') AS float) <= " + StdTAT_2 + ") AND (CLIENT_MASTER.CLIENT_ID = " + @ClientID + ")AND (" + TableName + ".CENTRE_ID = " + @CentreId + ")";
        decimal TAT2_Total = Convert.ToDecimal(OleDbHelper.ExecuteScalar(con, CommandType.Text, str));
        con.Close();
        return TAT2_Total;
    }

    public decimal Total_Tat_3(string TableName, string ClientID, string CentreId)
    {
        OleDbConnection con;
        if (HttpContext.Current.Session["DataBase"] != null)
        {
            if (HttpContext.Current.Session["DataBase"].ToString() == "RepositoryPMS")
            {
                con = new OleDbConnection(connobj.RepositoryConnectionString);
            }
            else
            {
                con = new OleDbConnection(connobj.ConnectionString);
            }
        }
        else
        {
            con = new OleDbConnection(connobj.ConnectionString);
        }
        //End Of Code
        con.Open();
        string str = " SELECT  COUNT(" + TableName + ".CASE_ID) AS TAT3_total " +
                    " FROM " + TableName + " INNER JOIN " +
                    " CLIENT_MASTER ON " + TableName + ".CLIENT_ID = CLIENT_MASTER.CLIENT_ID " +
                    " WHERE (" + TableName + ".CASE_REC_DATETIME >='" + @FromDate + "') AND (" + TableName + ".CASE_REC_DATETIME < '" + @ToDate + "') AND  " +
                    " (" + TableName + ".TAT_HRS IS NOT NULL) AND (" + TableName + ".TAT_HRS <> '') AND  " +
                    " (CAST(REPLACE(" + TableName + ".TAT_HRS, ':', '.') AS float) > " + StdTAT_1 + ")and (CAST(REPLACE(" + TableName + ".TAT_HRS, ':', '.') AS float) > " + StdTAT_2 + ") and (CAST(REPLACE(" + TableName + ".TAT_HRS, ':', '.') AS float) <= " + StdTAT_3 + ") AND (CLIENT_MASTER.CLIENT_ID = " + @ClientID + ")AND (" + TableName + ".CENTRE_ID = " + @CentreId + ")";
        decimal TAT3_Total = Convert.ToDecimal(OleDbHelper.ExecuteScalar(con, CommandType.Text, str));
        con.Close();
        return TAT3_Total;
    }

    public decimal Beynod(string TableName, string ClientID, string CentreId)
    {
        OleDbConnection con;
        if (HttpContext.Current.Session["DataBase"] != null)
        {
            if (HttpContext.Current.Session["DataBase"].ToString() == "RepositoryPMS")
            {
                con = new OleDbConnection(connobj.RepositoryConnectionString);
            }
            else
            {
                con = new OleDbConnection(connobj.ConnectionString);
            }
        }
        else
        {
            con = new OleDbConnection(connobj.ConnectionString);
        }
        //End Of Code
        con.Open();
        string str = " SELECT  COUNT(" + TableName + ".CASE_ID) AS Beyond " +
                    " FROM " + TableName + " INNER JOIN " +
                    " CLIENT_MASTER ON " + TableName + ".CLIENT_ID = CLIENT_MASTER.CLIENT_ID " +
                    " WHERE (" + TableName + ".CASE_REC_DATETIME >='" + @FromDate + "') AND (" + TableName + ".CASE_REC_DATETIME < '" + @ToDate + "') AND  " +
                    " (" + TableName + ".TAT_HRS IS NOT NULL) AND (" + TableName + ".TAT_HRS <> '') AND  " +
                    " (CAST(REPLACE(" + TableName + ".TAT_HRS, ':', '.') AS float) > " + StdTAT_1 + ")and (CAST(REPLACE(" + TableName + ".TAT_HRS, ':', '.') AS float) > " + StdTAT_2 + ")and (CAST(REPLACE(" + TableName + ".TAT_HRS, ':', '.') AS float) > " + StdTAT_3 + ") AND (CLIENT_MASTER.CLIENT_ID = " + @ClientID + ")AND (" + TableName + ".CENTRE_ID = " + @CentreId + ")";
        decimal Beyond = Convert.ToDecimal(OleDbHelper.ExecuteScalar(con, CommandType.Text, str));
        con.Close();
        return Beyond;
    }

    public decimal Pending(string TableName, string ClientID, string CentreId)
    {
        OleDbConnection con;
        if (HttpContext.Current.Session["DataBase"] != null)
        {
            if (HttpContext.Current.Session["DataBase"].ToString() == "RepositoryPMS")
            {
                con = new OleDbConnection(connobj.RepositoryConnectionString);
            }
            else
            {
                con = new OleDbConnection(connobj.ConnectionString);
            }
        }
        else
        {
            con = new OleDbConnection(connobj.ConnectionString);
        }
        //End Of Code
        con.Open();
        string str = " SELECT  COUNT(" + TableName + ".CASE_ID) AS Pending " +
                    " FROM " + TableName + " INNER JOIN " +
                    " CLIENT_MASTER ON " + TableName + ".CLIENT_ID = CLIENT_MASTER.CLIENT_ID " +
                    " WHERE (" + TableName + ".CASE_REC_DATETIME >='" + @FromDate + "') AND (" + TableName + ".CASE_REC_DATETIME < '" + @ToDate + "') AND  " +
                    " (" + TableName + ".SEND_DATETIME IS NULL OR " + TableName + ".SEND_DATETIME = '') AND  " +
                    " (CLIENT_MASTER.CLIENT_ID = " + @ClientID + ")AND (" + TableName + ".CENTRE_ID = " + @CentreId + ")";
        decimal Pending = Convert.ToDecimal(OleDbHelper.ExecuteScalar(con, CommandType.Text, str));
        con.Close();
        return Pending;
    }


    public decimal TotalCaseClientWise(string TableName, string ClientID, string CentreId)
    {
        OleDbConnection con;
        if (HttpContext.Current.Session["DataBase"] != null)
        {
            if (HttpContext.Current.Session["DataBase"].ToString() == "RepositoryPMS")
            {
                con = new OleDbConnection(connobj.RepositoryConnectionString);
            }
            else
            {
                con = new OleDbConnection(connobj.ConnectionString);
            }
        }
        else
        {
            con = new OleDbConnection(connobj.ConnectionString);
        }
        //End Of Code
        con.Open();
        string str = " SELECT  COUNT(" + TableName + ".CASE_ID) AS total " +
                    " FROM " + TableName + " INNER JOIN " +
                    " CLIENT_MASTER ON " + TableName + ".CLIENT_ID = CLIENT_MASTER.CLIENT_ID " +
                    " WHERE (" + TableName + ".CASE_REC_DATETIME >='" + @FromDate + "') AND (" + TableName + ".CASE_REC_DATETIME < '" + @ToDate + "') AND  " +
                    " (CLIENT_MASTER.CLIENT_ID = " + @ClientID + ") AND (" + TableName + ".CENTRE_ID = " + @CentreId + ")";
        decimal TotalCaseClientWise = Convert.ToDecimal(OleDbHelper.ExecuteScalar(con, CommandType.Text, str));
        con.Close();
        return TotalCaseClientWise;
    }
}
