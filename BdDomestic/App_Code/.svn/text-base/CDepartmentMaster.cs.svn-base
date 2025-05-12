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
/// Summary description for CDepartmentMaster
/// </summary>
public class CDepartmentMaster
{
	public CDepartmentMaster()
	{
         oCmn = new CCommon();
	}

    private string strDeptId;
    private string strDeptName;
    
    public string DeptId
    {
        get { return strDeptId; }
        set { strDeptId = value; }
    }

    public string DeptName
    {
        get { return strDeptName; }
        set { strDeptName = value; }
    }

    private CCommon oCmn;

    public bool Add_DeptMaster()
    {
        OleDbConnection sqlcon = new OleDbConnection(oCmn.ConnectionString);
        sqlcon.Open();
        OleDbDataReader dr;
        string strChkDeptName = "SELECT  DEPARTMENT FROM DEPARTMENT_MASTER WHERE(DEPARTMENT = '"+strDeptName+"')";
        dr = OleDbHelper.ExecuteReader(sqlcon, CommandType.Text, strChkDeptName);
        dr.Read();
        if (dr.HasRows)
        {
            return false;
        }
        else
        {
            string strPrefix = "101";
            OleDbTransaction trans = sqlcon.BeginTransaction();
            try
            {
                strDeptId = oCmn.GetUniqueID("DEPARTMENT_MASTER", strPrefix).ToString();
                string strInsertDepartment = "INSERT INTO DEPARTMENT_MASTER (DEPT_ID, DEPARTMENT) VALUES (?,?)";
                
                OleDbParameter[] paramDepartment = new OleDbParameter[2];

                paramDepartment[0] = new OleDbParameter("@DEPT_ID", OleDbType.VarChar, 15);
                paramDepartment[0].Value = strDeptId;

                paramDepartment[1] = new OleDbParameter("@DEPARTMENT", OleDbType.VarChar, 10);
                paramDepartment[1].Value = strDeptName;

                OleDbHelper.ExecuteNonQuery(trans, CommandType.Text, strInsertDepartment,paramDepartment);
                trans.Commit();
                sqlcon.Close();
                return true;
            }
            catch (Exception ex)
            {
                trans.Rollback();
                sqlcon.Close();
                return false;
                throw new Exception("An Error has occured while inserting Department ", ex);      
            }
        }
    }

    public void SelectRecord(string DeptId)
    {
        OleDbConnection sqlcon = new OleDbConnection(oCmn.ConnectionString);
        sqlcon.Open();
        try
        {
            OleDbDataReader Odr;
            string strSelectDepartment = "SELECT DEPT_ID, DEPARTMENT FROM DEPARTMENT_MASTER WHERE DEPT_ID='"+DeptId+"' ";
           Odr= OleDbHelper.ExecuteReader(sqlcon, CommandType.Text, strSelectDepartment);
            while(Odr.Read())
            {
                DeptName = Odr["DEPARTMENT"].ToString();
            }
            sqlcon.Close();
        }
        catch (Exception ex)
        {
            sqlcon.Close();
            throw new Exception("Error while Selecting the Values", ex);
        }

    }

    public bool UpdateDepartment(string DeptId, string Department)
    {
        OleDbConnection sqlcon = new OleDbConnection(oCmn.ConnectionString);
        sqlcon.Open();
        try
        {
            string strUpdateDepartment = "UPDATE DEPARTMENT_MASTER SET DEPARTMENT ='" + Department + "' where DEPT_ID='" + DeptId + "' ";
            OleDbHelper.ExecuteNonQuery(sqlcon, CommandType.Text, strUpdateDepartment);
            return true;
        }
        catch (Exception ex)
        {
            sqlcon.Close();
            throw new Exception("Error while Updating Records !!", ex);
        }
    }

    public bool DeleteDepartment(string DeptId)
    {
        OleDbConnection sqlcon = new OleDbConnection(oCmn.ConnectionString);
        sqlcon.Open();
        try
        {
            string strDeleteDepartment = "DELETE FROM DEPARTMENT_MASTER WHERE (DEPT_ID = '"+DeptId+"')";
            OleDbHelper.ExecuteNonQuery(sqlcon, CommandType.Text, strDeleteDepartment);
            return true;
            sqlcon.Close();
        }
        catch (Exception ex)
        {
            sqlcon.Close();
            throw new Exception("Error while Deleting Records !!", ex);
        }
    }

}
