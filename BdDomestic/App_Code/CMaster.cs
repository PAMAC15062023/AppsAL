using System;
using System.Data;
using System.Data.OleDb;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

/// <summary>
/// Summary description for CMaster
/// </summary>
public class CMaster
{
    private string strRoleId;
    private string strUserId;
    private string strUserName;
    private string strLocation;

    private ArrayList alistNoAccess;

    private CCommon objConn;

    public string RoleId
    {
        get { return strRoleId; }
        set { strRoleId = value; }
    }
    public string UserId
    {
        get { return strUserId; }
        set { strUserId = value; }
    }
    public string UserName
    {
        get { return strUserName; }
        set { strUserName = value; }
    }
    public string Location
    {
        get { return strLocation; }
        set { strLocation = value; }
    }
    public ArrayList Operations
    {
        get { return alistNoAccess; }
        set { alistNoAccess = value; }
    }

	public CMaster()
	{
        objConn = new CCommon();
	}

    public void UserNameLocation()
    {
        string sqlRoleOperation = "select FirstName + ' ' + LastName as UserName, City from Employee_Master where Emp_id = ?";
        OleDbParameter paramRoleOperation = new OleDbParameter("EmployeeId", OleDbType.VarChar);
        paramRoleOperation.Value = UserId;
        OleDbDataReader drRoleOperation = (OleDbDataReader) OleDbHelper.ExecuteReader(objConn.ConnectionString, CommandType.Text, sqlRoleOperation, paramRoleOperation);
        if (drRoleOperation.Read())
        {
            UserName = drRoleOperation["UserName"].ToString();
            Location = drRoleOperation["City"].ToString();
        }
    }

    public void GetMenu(string ProductId)
    {
        ArrayList alistItem = new ArrayList();
        string sqlRoleOperation = "select Operation_Id, Operation_name, menu_header, Page_URL + '?OperationId=' + Operation_Id as URL , VISIBLILITY, DISPLAY_ORDER from OPERATION_MASTER where Product_Id='" + ProductId + "' ORDER BY MENU_HEADER, DISPLAY_ORDER";
        //OleDbParameter paramRoleOperation = new OleDbParameter("roleId", OleDbType.VarChar);
        //paramRoleOperation.Value = RoleId;
        OleDbDataReader drRoleOperation = (OleDbDataReader) OleDbHelper.ExecuteReader(objConn.ConnectionString, CommandType.Text, sqlRoleOperation);
        alistNoAccess = new ArrayList();
        while (drRoleOperation.Read())
        {
            alistItem = new ArrayList();
            alistItem.Add(drRoleOperation["operation_id"]);
            alistItem.Add(drRoleOperation["Operation_name"]);
            alistItem.Add(drRoleOperation["menu_header"]);
            alistItem.Add(drRoleOperation["URL"]);
            alistItem.Add(drRoleOperation["VISIBLILITY"]);
            
            //string strChk = "select Operation_Id from OPERATION_MASTER where Operation_Id = " + drRoleOperation["operation_id"].ToString() + " and Operation_Id in (select operation_id from role_operation where role_id in (" + RoleId + ") and (isAdd=1 or isEdit=1 or isDelete=1 or isView=1))";
            string strChk = "select Operation_Id from OPERATION_MASTER where Operation_Id = " + drRoleOperation["operation_id"].ToString() + " and Operation_Id in " +
                            " (select operation_Id from role_operation where role_id in (" + RoleId + ") and (isAdd=1 or isEdit=1 or isDelete=1 or isView=1))";
            OleDbDataReader drChkOperation = (OleDbDataReader)OleDbHelper.ExecuteReader(objConn.ConnectionString, CommandType.Text, strChk);
            if (drChkOperation.Read())
            {
                alistItem.Add("1");
            }
            else
            {
                alistItem.Add("0");
            }
            drChkOperation.Close();
            alistNoAccess.Add(alistItem);
            alistItem.Add(drRoleOperation["DISPLAY_ORDER"]);
            //alistIterm.Clear();
        }
        drRoleOperation.Close();
    }

    public ArrayList GetOperationPermission(string strOperationId, string strRoleId)
    {
        //string strPermission = "select isAdd, isEdit, isDelete, isView from Role_Operation where Role_Id in ( " + strRoleId + " ) and Operation_Id = ?";
        //OleDbParameter paramPermission = new OleDbParameter();
        ////paramPermission[0] = new OleDbParameter("RoleId", OleDbType.VarChar);
        ////paramPermission[0].Value = strRoleId;
        //paramPermission = new OleDbParameter("OperationId", OleDbType.VarChar);
        //paramPermission.Value = strOperationId;
        //OleDbDataReader drPermission = (OleDbDataReader)OleDbHelper.ExecuteReader(objConn.ConnectionString, CommandType.Text, strPermission, paramPermission);
        //By Asavari for multirole application on 07 Sep 2007
        string strPermission = "SELECT ISADD, ISEDIT, ISDELETE, ISVIEW FROM " +
                                "(SELECT DISTINCT ISVIEW=1, OPERATION_ID  FROM ROLE_OPERATION WHERE OPERATION_ID=" + strOperationId + " AND ROLE_ID IN(" + strRoleId + " )AND " +
                                "(ISVIEW=1)) A  FULL OUTER JOIN " +
                                "(SELECT DISTINCT ISADD,OPERATION_ID  FROM ROLE_OPERATION WHERE OPERATION_ID=" + strOperationId + " AND ROLE_ID IN(" + strRoleId + " )  AND " +
                                "(ISADD=1))B ON A.OPERATION_ID=B.OPERATION_ID FULL OUTER JOIN " +
                                "(SELECT DISTINCT ISEDIT,OPERATION_ID  FROM ROLE_OPERATION WHERE OPERATION_ID=" + strOperationId + " AND ROLE_ID IN(" + strRoleId + " )AND " +
                                "(ISEDIT=1)) C ON B.OPERATION_ID=C.OPERATION_ID FULL OUTER JOIN " +
                                "(SELECT DISTINCT ISDELETE,OPERATION_ID  FROM ROLE_OPERATION WHERE OPERATION_ID=" + strOperationId + " AND ROLE_ID IN(" + strRoleId + " )AND " +
                                "(ISDELETE=1)) D ON C.OPERATION_ID=D.OPERATION_ID";

        OleDbDataReader drPermission = (OleDbDataReader)OleDbHelper.ExecuteReader(objConn.ConnectionString, CommandType.Text, strPermission);
  
        ArrayList alistPermisson = new ArrayList();
        if (drPermission.Read())
        {
            alistPermisson.Add(drPermission["isAdd"]);
            alistPermisson.Add(drPermission["isEdit"]);
            alistPermisson.Add(drPermission["isDelete"]);
            alistPermisson.Add(drPermission["isView"]);
        }
        else
        {
            alistPermisson.Add("0");
            alistPermisson.Add("0");
            alistPermisson.Add("0");
            alistPermisson.Add("0");
        }
        drPermission.Close();
        return alistPermisson;
    }

    public void LogoutLog(string LogId)
    {
        string sqlLoginLog = "Update FE_Login_Detail set LOGOUT_DATE = ? where LOG_DET_ID = ?";
        OleDbParameter[] paramLoginLog = new OleDbParameter[3];
        paramLoginLog[0] = new OleDbParameter("LOGOUT_DATE", OleDbType.Date);
        paramLoginLog[0].Value = DateTime.Now;
        paramLoginLog[1] = new OleDbParameter("LOG_DET_ID", OleDbType.VarChar);
        paramLoginLog[1].Value = LogId;

        int intQueryResult = OleDbHelper.ExecuteNonQuery(objConn.ConnectionString, CommandType.Text, sqlLoginLog, paramLoginLog);

    }
}
