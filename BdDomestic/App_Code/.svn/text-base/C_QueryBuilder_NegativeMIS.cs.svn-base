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
/// Summary description for C_QueryBuilder_NegativeMIS
/// </summary>
public class C_QueryBuilder_NegativeMIS
{
    CCommon connobj = new CCommon();
	public C_QueryBuilder_NegativeMIS()
	{
		//
		// TODO: Add constructor logic here
		//
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

    public DataTable NegativeMISReport(string CentreId)
    {
        OleDbConnection con ;
        //Description   :  This Code is used To distingusish Repository PMS Database and PMS.
        //Created By    :  Gargi Srivastava
        //Created On    :  23-Nov-2007
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
        //End OF Code
        con.Open();
        OleDbTransaction trans = con.BeginTransaction();
        //OleDbDataReader Odr;
        try
        {
            OleDbParameter[] param = new OleDbParameter[3];
            param[0] = new OleDbParameter("@FROMDATE", OleDbType.VarChar, 50);
            param[0].Value = FromDate;
            param[0].Direction = ParameterDirection.Input;

            param[1] = new OleDbParameter("TODATE", OleDbType.VarChar, 50);
            param[1].Value = ToDate;
            param[1].Direction = ParameterDirection.Input;

            param[2] = new OleDbParameter("@CentreId", OleDbType.VarChar, 50);
            param[2].Value = CentreId;
            param[2].Direction = ParameterDirection.Input;
            DataTable dt = new DataTable();
            dt = OleDbHelper.ExecuteDataset(trans, CommandType.StoredProcedure, "Negative_MIS", param).Tables[0];
             //Odr = OleDbHelper.ExecuteReader(trans,CommandType.StoredProcedure,"Negative_MIS", param);
            trans.Commit();
            con.Close();
            return dt;
        }
        catch (Exception ex)
        {
            trans.Rollback();
            con.Close();
            throw new Exception("Error While Selecting Records",ex);
        }
    }
}
