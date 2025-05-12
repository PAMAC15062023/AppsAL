using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data.OleDb;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Drawing;
using System.Text.RegularExpressions;

public partial class Pages_ICICIRPC_importfile : System.Web.UI.Page
{
    //SingleUserLogin Login = new SingleUserLogin();
    String strPath = "";
    String MyFile = "";
    public List<Row> listRows = new List<Row>();
    DataTable dtExcelData = new DataTable();
    DataTable dtUploadableData = new DataTable();
    DataTable dtRejectedData = new DataTable();
    int totalRecordInserted = 0;
    int totalRecordNotInserted = 0;
    int totalRecords = 0;
    bool isErrorFound = false;
    string ResponseMessage = "";
    string FinalCaseType = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        pnlproduct.Visible = true;

    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/pages/menu.aspx", true);
    }
    protected void Bulk_Import()
    {
        Object SaveUSERInfo = (Object)Session["UserInfo"];

        SqlConnection sqlCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);

        sqlCon.Open();
        for (int i = 0; i < dtUploadableData.Rows.Count; i++)
        {
            if (ddlprodut.SelectedValue.ToString() == "1")
            {
                //GenTicket();
                Update_Into_JFS_upload(dtUploadableData.Rows[i]);
            }
            else if (ddlprodut.SelectedValue.ToString() == "2")
            {
                //GenTicket();
                Update_Into_JFS_upload12(dtUploadableData.Rows[i]);
            }
            else
            {
                //GenTicket();
                Update_Into_JFS_upload123(dtUploadableData.Rows[i]);
            }
            string smsg = Convert.ToString(dtUploadableData.Rows.Count);
            lblMsgXls.Text = "Data Import Successfully!! Total Count :" + smsg;
            sqlCon.Close();
        }
        string strFile = Server.MapPath("~/Pages/JFS/ImportFiles/") + MyFile;
        if (File.Exists(strFile))
        {
            File.Delete(strFile);
        }
    }
    protected void btnupload_Click(object sender, EventArgs e)
    {
        try
        {
            if (xslFileUpload.HasFile)
            {
                string strDateTime = DateTime.Now.ToString("ddMMyyyyhhmmss");

                strPath = Server.MapPath("~/Pages/JFS/ImportFiles/");
                MyFile = strDateTime + ".xls";
                strPath = (strPath + MyFile);
                xslFileUpload.PostedFile.SaveAs(strPath);

                string strFileName = xslFileUpload.FileName.ToString();
                FileInfo fi = new FileInfo(strFileName);
                string strExt = fi.Extension;

                if (strExt.ToLower() == ".xls")
                {
                    readExcelData();
                    filterExcelData();
                    Bulk_Import();

                    if (isErrorFound)
                    {
                        if (listRows.Count > 0)
                        {
                            exportExcel(listRows);
                        }
                    }

                }
                else
                {
                    lblMsgXls.Visible = true;
                    lblMsgXls.Text = "It's Not An Excel File...!!!";
                }
            }
            else
            {
                lblMsgXls.Visible = true;
                lblMsgXls.Text = "Please Select Excel File To Import...!!!";
            }
        }
        catch (Exception ex)
        {
            lblMsgXls.Visible = true;
            lblMsgXls.Text = "Error :" + ex.Message;
        }

        pnlproduct.Visible = true;
        PnlAL.Visible = true;
    }

    public void readExcelData()
    {

        //string strConn = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + strPath + @";Extended Properties=""Excel 8.0;IMEX=1;HDR=YES;""";
        string strConn = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + strPath + @";Extended Properties=""Excel 12.0;IMEX=1;HDR=YES;""";

        // Create the connection object
        OleDbConnection oledbConn = new OleDbConnection(strConn);
        try
        {
            // Open connection
            oledbConn.Open();

            // Create OleDbCommand object and select data from worksheet Sheet1
            OleDbCommand cmd = new OleDbCommand("SELECT * FROM [Sheet1$]", oledbConn);

            // Create new OleDbDataAdapter
            OleDbDataAdapter oleda = new OleDbDataAdapter();

            oleda.SelectCommand = cmd;

            // Create a DataSet which will hold the data extracted from the worksheet.
            DataSet dsExcel = new DataSet();

            // Fill the DataSet from the data extracted from the worksheet.
            oleda.Fill(dsExcel, "ExcelData");

            // Bind the data to the GridView
            dtExcelData = dsExcel.Tables["ExcelData"];

            //To get the count total records from the excel
            totalRecords = dtExcelData.Rows.Count;
        }
        catch (Exception ex)
        {
        }
        finally
        {
            // Close connection
            oledbConn.Close();
        }
    }

    public void filterExcelData()
    {
        dtUploadableData.Columns.Add("Sr No");
        dtUploadableData.Columns.Add("Scan Date");
        dtUploadableData.Columns.Add("Application Form No");
        dtUploadableData.Columns.Add("Customer Name");
        dtUploadableData.Columns.Add("Location/Branch");
        dtUploadableData.Columns.Add("Remark");
        dtUploadableData.Columns.Add("CaseType");
        dtUploadableData.Columns.Add("LoanAmount");
        dtUploadableData.Columns.Add("New Car Or Used Car"); //add on 12/01/24
        DataRow _dataRowAccepted = dtUploadableData.NewRow();

        dtRejectedData.Columns.Add("Sr No");
        dtRejectedData.Columns.Add("Scan Date");
        dtRejectedData.Columns.Add("Application Form No");
        dtRejectedData.Columns.Add("Customer Name");
        dtRejectedData.Columns.Add("Location/Branch");
        dtRejectedData.Columns.Add("Remark");
        dtRejectedData.Columns.Add("CaseType");
        dtRejectedData.Columns.Add("LoanAmount");
        dtRejectedData.Columns.Add("New Car Or Used Car"); //add on 12/01/24
        DataRow _dataRowRejected = dtRejectedData.NewRow();

        foreach (DataRow dr in dtExcelData.Rows)
        {
            validateImportedData(dr);
        }
    }
    //Actucal Filtration START
    #region Actucal Filtration
    protected void validateImportedData(DataRow dr)
    {
        String updatedMessage = null;
        // SqlConnection sqlCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);
        try
        {
            String[] arrayOfKeyForBlankCheck = { "Sr No", "Scan Date", "Application Form No", "Customer Name", "Location/Branch", "Remark", "LoanAmount" };

            List<Field> fieldList = new List<Field>();
            foreach (String key in arrayOfKeyForBlankCheck)
            {
                bool isError = false;
                Field field = new Field();
                field.key = key;
                field.value = dr[key].ToString();

                #region validate if BridgeCode exists in Master DB
                if (key.Equals("Application Form No"))
                {
                    FinalCaseType = validateCaseType(dr[key].ToString());
                    if (FinalCaseType == "Other")
                    {
                        isErrorFound = true;
                        isError = true;
                        if (updatedMessage != null)
                        {
                            updatedMessage += key + " is not in correct formate.<br style=\"mso-data-placement:same-cell;\">";
                        }
                        else
                        {
                            updatedMessage = key + " is not in correct formate.<br style=\"mso-data-placement:same-cell;\">";
                        }

                    }
                }
                #endregion

                if (isError)
                {
                    field.isEroor = true;
                }
                else
                {
                    field.isEroor = false;
                }
                fieldList.Add(field);
            }
            List<Field> updatedFieldList = new List<Field>();
            if (updatedMessage != null)
            {
                foreach (String key in arrayOfKeyForBlankCheck)
                {
                    foreach (Field field in fieldList)
                    {
                        if (key.Equals(field.key))
                        {
                            updatedFieldList.Add(field);
                            break;
                        }
                    }
                }
                Field updatedFieldMessage = new Field();
                updatedFieldMessage.key = "updatedMessage";
                updatedFieldMessage.value = updatedMessage;
                updatedFieldMessage.isEroor = false;
                updatedFieldList.Add(updatedFieldMessage);
                Row row = new Row();
                row.fields = updatedFieldList;
                listRows.Add(row);
            }

            if (updatedMessage == null)
            {
                DataRow Dw = dtUploadableData.NewRow();
                Object SaveUSERInfo = (Object)Session["UserInfo"];


                Dw["Sr No"] = string.IsNullOrWhiteSpace(dr["Sr No"].ToString()) ? null : dr["Sr No"].ToString();
                Dw["Scan Date"] = string.IsNullOrWhiteSpace(dr["Scan Date"].ToString()) ? null : dr["Scan Date"].ToString();
                Dw["Application Form No"] = string.IsNullOrWhiteSpace(dr["Application Form No"].ToString()) ? null : dr["Application Form No"].ToString();
                Dw["Customer Name"] = string.IsNullOrWhiteSpace(dr["Customer Name"].ToString()) ? null : dr["Customer Name"].ToString();
                Dw["Location/Branch"] = string.IsNullOrWhiteSpace(dr["Location/Branch"].ToString()) ? null : dr["Location/Branch"].ToString();
                Dw["Remark"] = string.IsNullOrWhiteSpace(dr["Remark"].ToString()) ? null : dr["Remark"].ToString();
                Dw["CaseType"] = FinalCaseType;
                Dw["LoanAmount"] = string.IsNullOrWhiteSpace(dr["LoanAmount"].ToString()) ? null : dr["LoanAmount"].ToString();
                Dw["New Car Or Used Car"] = string.IsNullOrWhiteSpace(dr["New Car Or Used Car"].ToString()) ? null : dr["New Car Or Used Car"].ToString();  //add on 12/01/24
                dtUploadableData.Rows.Add(Dw);


                totalRecordInserted += 1;
            }
            else
            {
                totalRecordNotInserted += 1;
            }

        }
        catch (Exception ex)
        {
            // isErrorFound = true;
            String message = ex.Message.ToString();
            //updatedMessage= "Error found while uploading \n"+ex.Message.ToString();

        }
        finally
        {

        }

    }

    private void exportExcel(List<Row> listRows)
    {
        Response.Clear();
        Response.ClearContent();
        Response.Buffer = true;

        Response.AddHeader("content-disposition", "attachment;filename=Error.xls");
        Response.ContentType = "application/vnd.ms-excel;charset=utf-8;";


        //Add the style sheet class here

        Response.Write(@"<style> .sborder { color : Red;border : 1px Solid Balck; } </style> ");
        //style to format numbers to string 
        string style = "<style>.textmode{mso-number-format:\\@;}</style>";
        //   HttpContext.Current.Response.ContentEncoding = System.Text.Encoding.Default

        WriteHtmlTable(listRows, Response.Output);

        Response.End();

    }

    public void WriteHtmlTable(List<Row> data, TextWriter output)
    {
        //Writes markup characters and text to an ASP.NET server control output stream. This class provides formatting capabilities that ASP.NET server controls use when rendering markup to clients.
        using (StringWriter sw = new StringWriter())
        {
            using (HtmlTextWriter htw = new HtmlTextWriter(sw))
            {

                //  Create a form to contain the List
                Table table = new Table();
                TableRow row = new TableRow();

                String[] arrayOfKeyForBlankCheck = { "Sr No", "Scan Date", "Application Form No", "Customer Name", "Location/Branch", "Remark" };


                foreach (String key in arrayOfKeyForBlankCheck)
                {
                    TableHeaderCell headerCell = new TableHeaderCell();
                    headerCell.BorderStyle = BorderStyle.Inset;
                    headerCell.BorderColor = Color.Black;
                    headerCell.Text = key;
                    row.Cells.Add(headerCell);
                }
                TableCell errorCell = new TableCell();
                errorCell.BorderStyle = BorderStyle.Inset;
                errorCell.BorderColor = Color.Black;
                errorCell.Text = "Error List";
                row.Cells.Add(errorCell);
                table.Rows.Add(row);
                //  add each of the data item to the table
                foreach (Row item in data)
                {
                    row = new TableRow();

                    foreach (Field prop in item.fields)
                    {
                        TableCell cell = new TableCell();

                        cell.BorderStyle = BorderStyle.Inset;
                        cell.BorderColor = Color.Black;
                        if (prop.isEroor)
                        {
                            cell.BackColor = Color.Yellow;
                            cell.Attributes.Add("class", "sborder");
                        }
                        cell.Text = prop.value;
                        row.Cells.Add(cell);
                    }
                    table.Rows.Add(row);
                }

                //  render the table into the htmlwriter
                table.RenderControl(htw);

                //  render the htmlwriter into the response
                output.Write(sw.ToString());
            }
        }

    }
    #endregion
    //Actucal Filtration END
    public string validateCaseType(String strNumber)
    {
        string CaseType = "";
        //Regex RCASPattern = new Regex(@"^(R-0)"); // check if application number starts with R-0
        Regex RCASPattern = new Regex(@"^(R-0).{1,9}$"); // check if application number starts with R-0 and contains maximum 12 characters
        Regex APSPattern = new Regex(@"^(A|B|C|K|U)");
        if (RCASPattern.IsMatch(strNumber))
        {
            CaseType = "RCAS";
        }
        else if (APSPattern.IsMatch(strNumber))
        {
            CaseType = "APS";
        }
        else
        {
            CaseType = "Other";
        }
        return CaseType;
    }
    public void GenTicket()
    {
        Object SaveUSERInfo = (Object)Session["UserInfo"];
        SqlConnection sqlcon = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);

        try
        {
            if (sqlcon.State == ConnectionState.Closed)
            {
                sqlcon.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = sqlcon;
                cmd.CommandType = CommandType.StoredProcedure;
                //cmd.CommandText = "Get_Series_Gen_Aspire_1";
                cmd.CommandText = "Get_Series_Gen_icic_2";  //need to upload
                cmd.CommandTimeout = 0;

                SqlParameter BranchID = new SqlParameter();
                BranchID.SqlDbType = SqlDbType.Int;
                BranchID.Value = "1"; //Convert.ToInt32(((UserInfo.structUSERInfo)(SaveUSERInfo)).BranchId);
                BranchID.ParameterName = "@intBranchId";
                cmd.Parameters.Add(BranchID);

                SqlParameter PamacLocation = new SqlParameter();
                PamacLocation.SqlDbType = SqlDbType.VarChar;
                PamacLocation.Value = "AL";
                PamacLocation.ParameterName = "@PamacBranch";
                cmd.Parameters.Add(PamacLocation);

                SqlParameter AspireBranch = new SqlParameter();
                AspireBranch.SqlDbType = SqlDbType.VarChar;
                AspireBranch.Value = "Delhi";
                AspireBranch.ParameterName = "@AspireBranch";
                cmd.Parameters.Add(AspireBranch);

                SqlParameter AspireSubBranch = new SqlParameter();
                AspireSubBranch.SqlDbType = SqlDbType.VarChar;
                AspireSubBranch.Value = "VT-21";
                AspireSubBranch.ParameterName = "@AspireSubBranch";
                cmd.Parameters.Add(AspireSubBranch);

                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    //txtRefNo.Text = dr.GetValue(0).ToString().Trim();
                }
                //txtRefNo.Text = dr[1].ToString().Trim();
            }
        }
        catch (SqlException sqlex)
        {
            lblMsgXls.Text = sqlex.Message.ToString();
        }
        catch (SystemException ex)
        {
            lblMsgXls.Text = ex.Message.ToString();
        }
        finally
        {
            if (sqlcon.State == ConnectionState.Open)
            {
                sqlcon.Close();
            }
        }
    }

    protected void Update_Into_JFS_upload(DataRow dr)
    {

        Object SaveUSERInfo = (Object)Session["UserInfo"];

        SqlConnection sqlCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);
        try
        {
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlCon;
            sqlcmd.CommandType = CommandType.StoredProcedure;
            //sqlcmd.CommandText = "sp_importdata_icic_AL_locationbase";
            sqlcmd.CommandText = "IRPC_Import_Data_AL_SP";//sp_importdata_icic_AL04
            sqlcmd.CommandTimeout = 0;

            SqlParameter sr_no = new SqlParameter();
            sr_no.SqlDbType = SqlDbType.VarChar;
            sr_no.Value = dr["Sr No"].ToString().Trim();
            sr_no.ParameterName = "@sr_no";
            sqlcmd.Parameters.Add(sr_no);

            SqlParameter scan_date = new SqlParameter();
            scan_date.SqlDbType = SqlDbType.DateTime;
            scan_date.Value = dr["Scan Date"].ToString().Trim();
            scan_date.ParameterName = "@scan_date";
            sqlcmd.Parameters.Add(scan_date);

            SqlParameter application_no = new SqlParameter();
            application_no.SqlDbType = SqlDbType.VarChar;
            application_no.Value = dr["Application Form No"].ToString().Trim();
            application_no.ParameterName = "@LOS_no";
            sqlcmd.Parameters.Add(application_no);

            SqlParameter aps_id = new SqlParameter();
            aps_id.SqlDbType = SqlDbType.VarChar;
            aps_id.Value = "";
            aps_id.ParameterName = "@aps_id";
            sqlcmd.Parameters.Add(aps_id);

            SqlParameter RT_NO = new SqlParameter();
            RT_NO.SqlDbType = SqlDbType.VarChar;
            RT_NO.Value = "";
            RT_NO.ParameterName = "@RT_NO";
            sqlcmd.Parameters.Add(RT_NO);

            SqlParameter cus_name = new SqlParameter();
            cus_name.SqlDbType = SqlDbType.VarChar;
            cus_name.Value = dr["Customer Name"].ToString().Trim();
            cus_name.ParameterName = "@cus_name";
            sqlcmd.Parameters.Add(cus_name);

            SqlParameter DSA_name = new SqlParameter();
            DSA_name.SqlDbType = SqlDbType.VarChar;
            DSA_name.Value = "";
            DSA_name.ParameterName = "@DSA_Name";
            sqlcmd.Parameters.Add(DSA_name);

            SqlParameter location = new SqlParameter();
            location.SqlDbType = SqlDbType.VarChar;
            location.Value = dr["Location/Branch"].ToString().Trim();
            location.ParameterName = "@location";
            sqlcmd.Parameters.Add(location);

            SqlParameter Remark = new SqlParameter();
            Remark.SqlDbType = SqlDbType.VarChar;
            Remark.Value = dr["Remark"].ToString().Trim();
            Remark.ParameterName = "@Remark";
            sqlcmd.Parameters.Add(Remark);

            SqlParameter CaseType = new SqlParameter();
            CaseType.SqlDbType = SqlDbType.VarChar;
            CaseType.Value = dr["CaseType"].ToString().Trim();
            CaseType.ParameterName = "@CaseType";
            sqlcmd.Parameters.Add(CaseType);

            SqlParameter add_by = new SqlParameter();
            add_by.SqlDbType = SqlDbType.VarChar;
            add_by.Value = Convert.ToString(((UserInfo.structUSERInfo)(SaveUSERInfo)).UserId);
            add_by.ParameterName = "@add_by";
            sqlcmd.Parameters.Add(add_by);


            SqlParameter product = new SqlParameter();
            product.SqlDbType = SqlDbType.VarChar;
            product.Value = "AL";
            product.ParameterName = "@Product";
            sqlcmd.Parameters.Add(product);

            SqlParameter LoanAmount = new SqlParameter();
            LoanAmount.SqlDbType = SqlDbType.VarChar;
            LoanAmount.Value = dr["LoanAmount"].ToString().Trim();
            LoanAmount.ParameterName = "@LoanAmount";
            sqlcmd.Parameters.Add(LoanAmount);

            SqlParameter NewCarOrUsedCar = new SqlParameter();   //add on 12/01/24
            NewCarOrUsedCar.SqlDbType = SqlDbType.VarChar;
            NewCarOrUsedCar.Value = dr["New Car Or Used Car"].ToString().Trim();
            NewCarOrUsedCar.ParameterName = "@NewCarOrUsedCar";
            sqlcmd.Parameters.Add(NewCarOrUsedCar);

            sqlCon.Open();
            int RowEffected = 0;

            RowEffected = sqlcmd.ExecuteNonQuery();

            sqlCon.Close();
        }
        catch (Exception ex)
        {
            lblMsgXls.Visible = true;
            lblMsgXls.Text = "Error :" + ex.Message;
        }
        finally
        {
            sqlCon.Close();
            sqlCon.Dispose();
        }

    }

    protected void Update_Into_JFS_upload12(DataRow dr)
    {

        Object SaveUSERInfo = (Object)Session["UserInfo"];

        SqlConnection sqlCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);
        try
        {

            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlCon;
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.CommandText = "IRPC_ImportDataICICHL12_SP";
            sqlcmd.CommandTimeout = 0;

            sqlcmd.Parameters.AddWithValue("@sr_no", dr["S NO#"].ToString().Trim());
            sqlcmd.Parameters.AddWithValue("@LOS_no", dr["Application no"].ToString().Trim());
            sqlcmd.Parameters.AddWithValue("@scan_date", dr["Case Recd Dt"].ToString().Trim());
            sqlcmd.Parameters.AddWithValue("@aps_id", dr["Aps ID"].ToString().Trim());
            sqlcmd.Parameters.AddWithValue("@cus_name", dr["Customer Name"].ToString().Trim());
            sqlcmd.Parameters.AddWithValue("@Pro_Shop", dr["Process Shop"].ToString().Trim());
            sqlcmd.Parameters.AddWithValue("@Loan_Amt", dr["Loan Amount"].ToString().Trim());
            sqlcmd.Parameters.AddWithValue("@LoanTenor", dr["Loan Tenor"].ToString().Trim());
            sqlcmd.Parameters.AddWithValue("@SFAID", dr["SFA ID"].ToString().Trim());
            sqlcmd.Parameters.AddWithValue("@imp_product", dr["Product"].ToString().Trim());
            sqlcmd.Parameters.AddWithValue("@RM_EMPID", dr["Relationship Manager- EMP ID"].ToString().Trim());
            sqlcmd.Parameters.AddWithValue("@BCMName", dr["BCM Name"].ToString().Trim());
            sqlcmd.Parameters.AddWithValue("@DMAName", dr["DMA/DST/Sol ID Name"].ToString().Trim());
            sqlcmd.Parameters.AddWithValue("@SOLID", dr["SOL ID"].ToString().Trim());
            sqlcmd.Parameters.AddWithValue("@FI_Req", dr["FI Req"].ToString().Trim());
            sqlcmd.Parameters.AddWithValue("@location", dr["LOCATION"].ToString().Trim());
            sqlcmd.Parameters.AddWithValue("@Add_by", Convert.ToString(((UserInfo.structUSERInfo)(SaveUSERInfo)).UserId));
            sqlcmd.Parameters.AddWithValue("@Product", "HL");


            sqlCon.Open();
            int RowEffected = 0;

            RowEffected = sqlcmd.ExecuteNonQuery();
            if (RowEffected > 0)
            {


            }

            sqlCon.Close();
        }
        catch (Exception ex)
        {
            lblMsgXls.Visible = true;
            lblMsgXls.Text = "Error :" + ex.Message;
        }
        finally
        {
            sqlCon.Close();
            sqlCon.Dispose();
        }
    }


    protected void Update_Into_JFS_upload123(DataRow dr)
    {

        Object SaveUSERInfo = (Object)Session["UserInfo"];

        SqlConnection sqlCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);
        try
        {

            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlCon;
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.CommandText = "IRPC_ImportDataICICPL04_SP";
            sqlcmd.CommandTimeout = 0;

            SqlParameter sr_no = new SqlParameter();
            sr_no.SqlDbType = SqlDbType.VarChar;
            sr_no.Value = dr["Sr No"].ToString().Trim();
            sr_no.ParameterName = "@sr_no";
            sqlcmd.Parameters.Add(sr_no);




            SqlParameter scan_date = new SqlParameter();
            scan_date.SqlDbType = SqlDbType.DateTime;
            scan_date.Value = Convert.ToDateTime(dr["Scan Date"].ToString().Trim());
            scan_date.ParameterName = "@scan_date";
            sqlcmd.Parameters.Add(scan_date);



            SqlParameter application_no = new SqlParameter();
            application_no.SqlDbType = SqlDbType.VarChar;
            application_no.Value = dr["Application Form No"].ToString().Trim();
            application_no.ParameterName = "@LOS_no";
            sqlcmd.Parameters.Add(application_no);




            SqlParameter aps_id = new SqlParameter();
            aps_id.SqlDbType = SqlDbType.VarChar;
            aps_id.Value = dr["APS ID"].ToString().Trim();
            aps_id.ParameterName = "@aps_id";
            sqlcmd.Parameters.Add(aps_id);



            SqlParameter RT_NO = new SqlParameter();
            RT_NO.SqlDbType = SqlDbType.VarChar;
            RT_NO.Value = dr["RT Number"].ToString().Trim();
            RT_NO.ParameterName = "@RT_NO";
            sqlcmd.Parameters.Add(RT_NO);




            SqlParameter cus_name = new SqlParameter();
            cus_name.SqlDbType = SqlDbType.VarChar;
            cus_name.Value = dr["Customer Name"].ToString().Trim();
            cus_name.ParameterName = "@cus_name";
            sqlcmd.Parameters.Add(cus_name);


            SqlParameter DSA_name = new SqlParameter();
            DSA_name.SqlDbType = SqlDbType.VarChar;
            DSA_name.Value = dr["Channel/DSA Name"].ToString().Trim();
            DSA_name.ParameterName = "@DSA_Name";
            sqlcmd.Parameters.Add(DSA_name);

            SqlParameter location = new SqlParameter();
            location.SqlDbType = SqlDbType.VarChar;
            location.Value = dr["Location/Branch"].ToString().Trim();
            location.ParameterName = "@location";
            sqlcmd.Parameters.Add(location);

            SqlParameter add_by = new SqlParameter();
            add_by.SqlDbType = SqlDbType.VarChar;
            add_by.Value = Convert.ToString(((UserInfo.structUSERInfo)(SaveUSERInfo)).UserId);
            //add_by.Value = "P49506";
            add_by.ParameterName = "@add_by";
            sqlcmd.Parameters.Add(add_by);


            SqlParameter product = new SqlParameter();
            product.SqlDbType = SqlDbType.VarChar;
            product.Value = "PL";
            product.ParameterName = "@Product";
            sqlcmd.Parameters.Add(product);



            SqlParameter branch_id = new SqlParameter();
            branch_id.SqlDbType = SqlDbType.VarChar;
            branch_id.Value = Convert.ToInt32(((UserInfo.structUSERInfo)(SaveUSERInfo)).BranchId);
            //branch_id.Value = "1";
            branch_id.ParameterName = "@branch_id";
            sqlcmd.Parameters.Add(branch_id);


            sqlCon.Open();
            int RowEffected = 0;

            RowEffected = sqlcmd.ExecuteNonQuery();

            sqlCon.Close();
        }
        catch (Exception ex)
        {
            lblMsgXls.Visible = true;
            lblMsgXls.Text = "Error :" + ex.Message;
        }
        finally
        {
            sqlCon.Close();
            sqlCon.Dispose();
        }
    }
    public string strDate(string strInDate)
    {
        string strDD = strInDate.Substring(0, 2);

        string strMM = strInDate.Substring(3, 2);

        string strYYYY = strInDate.Substring(6, 4);

        string strhh = strInDate.Substring(11, 2);

        string strmmm = strInDate.Substring(14, 2);

        string strss = strInDate.Substring(17, 2);

        string strMMDDYYYY = strMM + "/" + strDD + "/" + strYYYY + " " + strhh + ":" + strmmm + ":" + strss;

        DateTime dtConvertDate = Convert.ToDateTime(strMMDDYYYY);

        string strOutDate = dtConvertDate.ToString("dd-MMM-yyyy HH:mm:ss");

        return strOutDate;
    }
    protected void ddlprodut_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlprodut.SelectedValue.ToString() == "1")
        {
            PnlAL.Visible = true;
            pnlproduct.Visible = true;

        }
        else if (ddlprodut.SelectedValue.ToString() == "2")
        {
            PnlAL.Visible = true;
            pnlproduct.Visible = true;

        }
        else
        {
            PnlAL.Visible = true;
            pnlproduct.Visible = true;
        }

    }
}