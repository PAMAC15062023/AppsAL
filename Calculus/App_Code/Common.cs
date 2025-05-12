using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Common
/// </summary>
public class Common
{
    public Common()
    {
        //
        // TODO: Add constructor logic here
        //
    }
            
    public DataSet GetCalOnlineTransMasterSearchCode(string type,int level) 
    {
        SqlConnection sqlCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);

        SqlCommand cmd = new SqlCommand("CalOnlineTrans_MasterSearchCode_SP", sqlCon);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@Types",type);
        cmd.Parameters.AddWithValue("@Level", level);
        SqlDataAdapter adp = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        adp.Fill(ds);
        return ds;
    }
}