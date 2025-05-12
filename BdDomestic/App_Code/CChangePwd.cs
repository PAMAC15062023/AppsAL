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
/// Summary description for CChangePwd
/// </summary>
public class CChangePwd
{
    private string strOldPwd;
    private string strNewPwd;
    private string strUserId;
    private string strStatus;
    private CCommon objConn;

    public string Status
    {
        get { return strStatus; }
        set { strStatus = value; }
    }

    public string UserId
    {
        set { strUserId = value; }
    }

    public string NewPwd
    {
        set { strNewPwd = value; }
    }

    public string OldPwd
    {
        set { strOldPwd = value; }
    }

	public CChangePwd()
	{
        objConn = new CCommon();
    }

    public void UserAuthenticate()
    {
        string sqlUser = "Select userid from user_master where UserId=? and Password=?";
        OleDbParameter[] paramUser = new OleDbParameter[2];
        object o;
        paramUser[0] = new OleDbParameter("UserId", OleDbType.VarChar);
        paramUser[0].Value = strUserId;
        paramUser[1] = new OleDbParameter("Password", OleDbType.VarChar);
        paramUser[1].Value = CEncDec.Encrypt(strOldPwd, strOldPwd);
        o = OleDbHelper.ExecuteScalar(objConn.ConnectionString, CommandType.Text, sqlUser, paramUser);
        if (o != null)
        {
            //Below Line Commented By Avinash Wankhede [PAMAC] Dated 05 May 2009 
            //sqlUser = "Update user_master set Password=? where UserId=?";
            //END here 
            //Below Line Added By Avinash Wankhede [PAMAC] Dated 05 May 2009            
            sqlUser = "Update user_master set Password=?,IS_SYSTEM=?,LAST_RESET_DATE=? where UserId=?";
            //End Here 

            OleDbParameter[] paramUserUpdate = new OleDbParameter[4];
            paramUserUpdate[0] = new OleDbParameter("Password", SqlDbType.NVarChar);
            paramUserUpdate[0].Value = CEncDec.Encrypt(strNewPwd, strNewPwd);
            paramUserUpdate[3] = new OleDbParameter("UserId", SqlDbType.NVarChar);
            paramUserUpdate[3].Value = strUserId;

            //Below Line Added By Avinash Wankhede [PAMAC] Dated 05 May 2009                       
            paramUserUpdate[1] = new OleDbParameter("IS_SYSTEM", SqlDbType.Bit);
            paramUserUpdate[1].Value = false ;
            paramUserUpdate[2] = new OleDbParameter("LAST_RESET_DATE", SqlDbType.DateTime);
            paramUserUpdate[2].Value = Convert.ToDateTime(DateTime.Now);
           //End Here

            int QueryReturn = OleDbHelper.ExecuteNonQuery(objConn.ConnectionString, CommandType.Text, sqlUser, paramUserUpdate);
            strStatus = "1";
        }
        else
        {
            strStatus = "0";
        }
    }
}
