using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.IO;
using System.Configuration;
/// <summary>
/// Summary description for BulkImpot
/// </summary>
public class BulkImpot
{
	public BulkImpot()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public void InsertRecord(string TableName, DataTable PriceTable)
    {

        SqlCommand My_SQLCommand = new SqlCommand();
        DataSet MyDataSet = new DataSet();
        SqlDataAdapter My_SQLDataAdapter = new SqlDataAdapter();

        My_SQLDataAdapter.SelectCommand = new SqlCommand();
        try
        {
            using (SqlConnection dbConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString()))
            {
                dbConnection.Open();
                using (SqlBulkCopy s = new SqlBulkCopy(dbConnection))
                {
                    s.DestinationTableName = TableName;
                    foreach (var column in PriceTable.Columns)
                        s.ColumnMappings.Add(column.ToString(), column.ToString());
                    s.WriteToServer(PriceTable);
                }
                dbConnection.Close();
            }
        }
        catch (Exception ex)
        {

            //throw ex;
        }

        finally
        {

        }

    }



}