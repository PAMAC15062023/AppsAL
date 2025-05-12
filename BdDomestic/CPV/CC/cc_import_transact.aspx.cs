using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.IO;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class CPV_CC_cc_import_transact : System.Web.UI.Page
{
    string strFormat = "TabDelimited";
    string strCSVFile = "";
    string strPath = "";
    string folderpath = "";
    string MyFile = "";
    System.Data.Odbc.OdbcDataAdapter obj_oledb_da;
    private bool bolColName = true;
    
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    
    protected void btnImport_Click(object sender, System.EventArgs e)
    {
        try
        {
            if (FileUpload.HasFile)
            {
                CImport oImport = new CImport();
                
                oImport.GetBatchID();
                folderpath = Server.MapPath("../../ImportFiles");
                MyFile = oImport.BatchId.ToString().Trim() + ".txt";
                strPath = folderpath + MyFile;

                //txtFileName.Text = FileUpload.FileName.ToString();
                //int intLengthOfFileName = txtFileName.Text.Trim().Length;
                //int intLastIndex = txtFileName.Text.Trim().LastIndexOf("\\");
                //if (intLastIndex <= 0)
                ///{
                //    intLastIndex = 1;
                ///}
                strCSVFile = FileUpload.FileName.ToString();
                //Format();
                writeSchema();
                ConnectCSV(strCSVFile);
                //btnUpload.Enabled = true;
            }
            else
            {
                Response.Write("The File Path TextBox cannot be empty. Warning");
                return;
            }
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message);
        }
        finally
        { 
        }
    }
    //////////private void Format()
    //////////{
    //////////    try
    //////////    {

    //////////        if (cmbFormats.SelectedIndex == 0)
    //////////        {
    //////////            strFormat = "CSVDelimited";
    //////////        }
    //////////        else if (cmbFormats.SelectedIndex == 1)
    //////////        {
    //////////            strFormat = "TabDelimited";
    //////////        }
    //////////        else
    //////////        {
    //////////            strFormat = "Delimited(" + txtDelimiter.Text.Trim() + ")";
    //////////        }

    //////////    }
    //////////    catch (Exception ex)
    //////////    {
    //////////        MessageBox.Show(ex.Message);
    //////////    }
    //////////    finally
    //////////    { }
    //////////}
    private void writeSchema()
    {
        try
        {
            FileStream fsOutput = new FileStream(folderpath , FileMode.Create, FileAccess.Write);
            StreamWriter srOutput = new StreamWriter(fsOutput);
            string s1, s2, s3, s4, s5;
            s1 = "[" + strCSVFile + "]";
            s2 = "ColNameHeader=" + bolColName.ToString();
            s3 = "Format=" + strFormat;
            s4 = "MaxScanRows=25";
            s5 = "CharacterSet=OEM";
            srOutput.WriteLine(s1.ToString() + '\n' + s2.ToString() + '\n' + s3.ToString() + '\n' + s4.ToString() + '\n' + s5.ToString());
            srOutput.Close();
            fsOutput.Close();
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message);
        }
        finally
        { }
    }
    # region Function For Importing Data From CSV File
    public DataSet ConnectCSV(string filetable)
    {
        DataSet ds = new DataSet();
        try
        {
            // You can get connected to driver either by using DSN or connection string

            // Create a connection string as below, if you want to use DSN less connection. The DBQ attribute sets the path of directory which contains CSV files
            string strConnString = "Driver={Microsoft Text Driver (*.txt; *.csv)};Dbq=Server.MapPath(../../ImportFiles/);Extensions=asc,csv,tab,txt;Persist Security Info=False";
            string sql_select;
            System.Data.Odbc.OdbcConnection conn = new System.Data.Odbc.OdbcConnection();

            //Create connection to CSV file
            conn = new System.Data.Odbc.OdbcConnection(strConnString.Trim());

            // For creating a connection using DSN, use following line
            //conn	=	new System.Data.Odbc.OdbcConnection(DSN="MyDSN");

            //Open the connection 
            conn.Open();
            //Fetch records from CSV
            sql_select = "select * from [" + filetable + "]";

            obj_oledb_da = new System.Data.Odbc.OdbcDataAdapter(sql_select, conn);
            //Fill dataset with the records from CSV file
            obj_oledb_da.Fill(ds, "Stocks");

            //Set the datagrid properties

            dGridCSVdata.DataSource = ds;
            dGridCSVdata.DataMember = "Stocks";
            //Close Connection to CSV file
            conn.Close();
        }
        catch (Exception e) //Error
        {
            Response.Write(e.Message);
        }
        return ds;
    }

    # endregion
}
