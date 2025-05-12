using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.OleDb;
/// <summary>
/// Summary description for CRoleOperation
/// </summary>
public class CRoleOperation
{
    private string strRoleName;
    private string strRoleId;
    private ArrayList alistRolePermissions;
    private string strProductId;

    private CCommon objConn;

    public string RoleName
    {
        get { return strRoleName; }
        set { strRoleName = value; }
    }

    public string RoleId
    {
        get { return strRoleId; }
        set { strRoleId = value; }
    }


    public ArrayList RolePermissions
    {
        get { return alistRolePermissions; }
        set { alistRolePermissions = value; }
    }

    public string ProductId
    {
        get { return strProductId; }
        set { strProductId = value; }
    }

    public string GerRoleName()
    {
        string strSqlRoleName = "select Role_Name from Role_Master where Role_Id=?";
        OleDbParameter paramRoleName = new OleDbParameter("RoleId",OleDbType.VarChar);
        paramRoleName.Value = strRoleId;
        strRoleName = OleDbHelper.ExecuteScalar(objConn.ConnectionString, CommandType.Text, strSqlRoleName, paramRoleName).ToString();
        return strRoleName;
    }

    public string SetPermission()
    {
        OleDbConnection sqlConn = new OleDbConnection(objConn.ConnectionString);
        sqlConn.Open();
        OleDbTransaction sqlTrans = sqlConn.BeginTransaction();
        string sqlDelete = "delete from Role_Operation where Role_id = ? and Operation_Id " +
                           "in ( Select Operation_Id from Operation_Master where Product_Id= ?)";
        //OleDbParameter paramDelete = new OleDbParameter("RoleId", OleDbType.VarChar);
        //paramDelete.Value = strRoleId;

        OleDbParameter[] paramDelete = new OleDbParameter[2];
        paramDelete[0] = new OleDbParameter("RoleId", OleDbType.VarChar);
        paramDelete[0].Value = strRoleId;
        paramDelete[1] = new OleDbParameter("ProductId", OleDbType.VarChar);
        paramDelete[1].Value = strProductId;


        object obj = OleDbHelper.ExecuteScalar(sqlTrans, CommandType.Text, sqlDelete, paramDelete);
        OleDbParameter[] paramRoleOpr;// = new OleDbParameter[6];
       
        //paramLoginLog[0].Value = LogId;
        try
        {
            int Counter = 0;
            string strOpreationId, strIsAdd, strIsEdit, strIsDelete, strIsView;
            while (Counter < alistRolePermissions.Count)
            {
                paramRoleOpr = new OleDbParameter[6];
                paramRoleOpr[0] = new OleDbParameter("RoleId", OleDbType.VarChar);
                paramRoleOpr[0].Value = strRoleId;
                paramRoleOpr[1] = new OleDbParameter("OperationId", OleDbType.VarChar);
                paramRoleOpr[2] = new OleDbParameter("IsAdd", OleDbType.VarChar);
                paramRoleOpr[3] = new OleDbParameter("IsEdit", OleDbType.VarChar);
                paramRoleOpr[4] = new OleDbParameter("IsDelete", OleDbType.VarChar);
                paramRoleOpr[5] = new OleDbParameter("IsView", OleDbType.VarChar);

                ArrayList slistOP = (ArrayList)alistRolePermissions[Counter];
                strOpreationId = slistOP[0].ToString();
                strIsAdd = slistOP[1].ToString();
                strIsEdit = slistOP[2].ToString();
                strIsDelete = slistOP[3].ToString();
                strIsView = slistOP[4].ToString();
                string sqlInsert = "Insert into Role_Operation values(?, ?, ?, ?, ?, ?)";
                paramRoleOpr[1].Value = strOpreationId;
                paramRoleOpr[2].Value = strIsAdd;
                paramRoleOpr[3].Value = strIsEdit;
                paramRoleOpr[4].Value = strIsDelete;
                paramRoleOpr[5].Value = strIsView;
                obj = OleDbHelper.ExecuteScalar(sqlTrans, CommandType.Text, sqlInsert, paramRoleOpr); 
                Counter++;
            }
            sqlTrans.Commit();
            sqlConn.Close();
            return "Successfully updated role permissions";
        }
        catch (Exception ex)
        {
            sqlTrans.Rollback();
            sqlConn.Close();
            throw new Exception("An error occurred while executing the confirmCases()", ex);
        }   
        /*
        string sSql = "";
        try
        {
            sSql = "Update Case_Master SET CASE_Entry_Status='S' where CASE_Entry_Status='T'";

            retVal = OleDbHelper.ExecuteNonQuery(sqlTrans, CommandType.Text, sSql);

            sqlTrans.Commit();
            sqlConn.Close();

            return retVal;
        }
        catch (Exception ex)
        {
            sqlTrans.Rollback();
            sqlConn.Close();
            throw new Exception("An error occurred while executing the confirmCases()", ex);
        }
        */

    }

	public CRoleOperation()
	{
        objConn = new CCommon();
	}
    public CRoleOperation(string fpRoleId)
    {
        objConn = new CCommon();
        strRoleId = fpRoleId;
    }
}
