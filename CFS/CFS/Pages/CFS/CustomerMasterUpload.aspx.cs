using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OleDb;
using System.Data;
using System.Configuration;
using System.IO;
using System.Drawing;
using System.Data.SqlClient;

public partial class Pages_CFS_CustomerMasterUpload : System.Web.UI.Page
{

    string ErrorFileName = "BISMaster";
    string excelFilePath = "";
    public List<Row> listRows = new List<Row>();
    DataTable dtExcelData = new DataTable();
    DataTable dtUploadableData = new DataTable();
    DataTable dtRejectedData = new DataTable();
    int totalRecordInserted = 0;
    int totalRecordNotInserted = 0;
    int totalRecords = 0;
    //ImportPV importPv = new ImportPV();
    bool isErrorFound = false;
    //StandardValidations stdValications = new StandardValidations();

    protected void Page_Load(object sender, EventArgs e)
    {
    }
    protected void btnImport_Click(object sender, EventArgs e)
    {
        try
        {
            if (fuDataFile.HasFile)
            {
                excelFilePath = Server.MapPath("~/Pages/CFS/UploadFile/" + fuDataFile.FileName);
                fuDataFile.SaveAs(excelFilePath);
                readExcelData();
                filterExcelData();
                insertDataToDatabase();
                if (isErrorFound)
                {
                    if (listRows.Count > 0)
                    {
                        //  exportExcel(listRows);
                    }
                }
            }
        }
        catch (Exception ex)
        {
            //divError.Visible = true;
            //lblError.Text = "Error:" + ex.Message;
            //ErrorLog Log = new ErrorLog(ex, ErrorFileName, Session["LoginName"].ToString());
        }
    }
    public void readExcelData()
    {
        //string strConn = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + excelFilePath + @";Extended Properties=""Excel 8.0;IMEX=1;HDR=YES;""";
        string strConn = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + excelFilePath + @";Extended Properties=Excel 12.0;";
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

            // Fill the DataSet from the data extracted from the worksheet.
            oleda.Fill(dtExcelData);

            string[] columnName = new string[29];


            for (int i = 0; i < dtExcelData.Columns.Count; i++)
            {
                columnName[i] = dtExcelData.Columns[i].ColumnName.ToString();
            }

            if (!columnName.Contains("Centre") || !columnName.Contains("Vertical") || !columnName.Contains("Client_Name") || !columnName.Contains("Short_Name_Client")
                || !columnName.Contains("Product") || !columnName.Contains("DCH_Name") || !columnName.Contains("DCH_phone") || !columnName.Contains("DCH_Email_id")
                || !columnName.Contains("DCH_Coordinator") || !columnName.Contains("DCH_cordinator_phone") || !columnName.Contains("DCH_Corodinator_email_id")
                || !columnName.Contains("CFS_to_be_initiated_centrally_or_locally") || !columnName.Contains("Customer_ID") || !columnName.Contains("Name_contact_person")
                || !columnName.Contains("LastName") || !columnName.Contains("FirstName") || !columnName.Contains("EmailAddress") || !columnName.Contains("Category")
                || !columnName.Contains("Job_Title") || !columnName.Contains("Business_Phone") || !columnName.Contains("Home_Phone") || !columnName.Contains("Mobile_Phone")
                || !columnName.Contains("Fax_Number") || !columnName.Contains("Address") || !columnName.Contains("City") || !columnName.Contains("State")
                || !columnName.Contains("PIN_Code") || !columnName.Contains("WebPage") || !columnName.Contains("Otherdetails"))
            {
                lblMsgXls.Visible = true;
                lblMsgXls.ForeColor = Color.Red;
                lblMsgXls.Text = "Invalid File formate...Wrong Headers!";
                return;
            }

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
        dtUploadableData.Columns.Add("Centre");
        dtUploadableData.Columns.Add("Vertical");
        dtUploadableData.Columns.Add("Client_Name");
        dtUploadableData.Columns.Add("Short_Name_Client");
        dtUploadableData.Columns.Add("Product");
        dtUploadableData.Columns.Add("DCH_Name");
        dtUploadableData.Columns.Add("DCH_phone");
        dtUploadableData.Columns.Add("DCH_Email_id");
        dtUploadableData.Columns.Add("DCH_Coordinator");
        dtUploadableData.Columns.Add("DCH_cordinator_phone");
        dtUploadableData.Columns.Add("DCH_Corodinator_email_id");
        dtUploadableData.Columns.Add("CFS_to_be_initiated_centrally_or_locally");
        dtUploadableData.Columns.Add("Customer_ID");
        dtUploadableData.Columns.Add("Name_contact_person");
        dtUploadableData.Columns.Add("LastName");
        dtUploadableData.Columns.Add("FirstName");
        dtUploadableData.Columns.Add("EmailAddress");
        dtUploadableData.Columns.Add("Category");
        dtUploadableData.Columns.Add("Job_Title");
        dtUploadableData.Columns.Add("Business_Phone");
        dtUploadableData.Columns.Add("Home_Phone");
        dtUploadableData.Columns.Add("Mobile_Phone");
        dtUploadableData.Columns.Add("Fax_Number");
        dtUploadableData.Columns.Add("Address");
        dtUploadableData.Columns.Add("City");
        dtUploadableData.Columns.Add("State");
        dtUploadableData.Columns.Add("PIN_Code");
        dtUploadableData.Columns.Add("WebPage");
        dtUploadableData.Columns.Add("Otherdetails");

        DataRow _dataRowAccepted = dtUploadableData.NewRow();

        //dtRejectedData.Columns.Add("BISRecdDate");
        //dtRejectedData.Columns.Add("BridgeCode");
        //dtRejectedData.Columns.Add("TypeOfOrganisation");
        //dtRejectedData.Columns.Add("PAN");
        //dtRejectedData.Columns.Add("GSTIN");
        //dtRejectedData.Columns.Add("ACNo");
        //dtRejectedData.Columns.Add("BankName");
        //dtRejectedData.Columns.Add("BankBranchName");
        //dtRejectedData.Columns.Add("IFSCCode");
        //dtRejectedData.Columns.Add("MICRCode");
        //dtRejectedData.Columns.Add("MobileNo");
        //dtRejectedData.Columns.Add("AlternatePayeeName");
        //dtRejectedData.Columns.Add("DealerName");
        //dtRejectedData.Columns.Add("NameAsPerIncomeTaxsite");
        //dtRejectedData.Columns.Add("House_ApartmentName");
        //dtRejectedData.Columns.Add("StreetName_VicinityName_LocalityName");
        //dtRejectedData.Columns.Add("Area_Village");
        //dtRejectedData.Columns.Add("City_District");
        //dtRejectedData.Columns.Add("DealerPinCode");
        //dtRejectedData.Columns.Add("State");
        //dtRejectedData.Columns.Add("BISStatus");
        //dtRejectedData.Columns.Add("Remark_Discrepancy");
        //dtRejectedData.Columns.Add("IsPanVerified");
        //dtRejectedData.Columns.Add("AccountCode");
        //dtRejectedData.Columns.Add("TDSPercent");
        //dtRejectedData.Columns.Add("CreatedBy");
        //DataRow _dataRowRejected = dtRejectedData.NewRow();

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

            String[] arrayOfKeyForBlankCheck = { "Centre","Vertical","Client_Name","Short_Name_Client","Product","DCH_Name","DCH_phone",
                                                  "DCH_Email_id","DCH_Coordinator","DCH_cordinator_phone","DCH_Corodinator_email_id",
                                                  "CFS_to_be_initiated_centrally_or_locally","Customer_ID","Name_contact_person",
                                                  "LastName","FirstName","EmailAddress","Category","Job_Title","Business_Phone",
                                                  "Home_Phone","Mobile_Phone","Fax_Number","Address","City","State",
                                                   "PIN_Code","WebPage","Otherdetails"};





            List<Field> fieldList = new List<Field>();
            foreach (String key in arrayOfKeyForBlankCheck)
            {
                bool isError = false;
                Field field = new Field();
                field.key = key;
                field.value = dr[key].ToString();

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
                Object LoginInfo = (Object)Session["userInfo"];


                Dw["Centre"] = string.IsNullOrWhiteSpace(dr["Centre"].ToString()) ? null : dr["Centre"].ToString();
                Dw["Vertical"] = string.IsNullOrWhiteSpace(dr["Vertical"].ToString()) ? null : dr["Vertical"].ToString();
                Dw["Client_Name"] = string.IsNullOrWhiteSpace(dr["Client_Name"].ToString()) ? null : dr["Client_Name"].ToString();
                Dw["Short_Name_Client"] = string.IsNullOrWhiteSpace(dr["Short_Name_Client"].ToString()) ? null : dr["Short_Name_Client"].ToString();
                Dw["Product"] = string.IsNullOrWhiteSpace(dr["Product"].ToString()) ? null : dr["Product"].ToString();
                Dw["DCH_Name"] = string.IsNullOrWhiteSpace(dr["DCH_Name"].ToString()) ? null : dr["DCH_Name"].ToString();
                Dw["DCH_phone"] = string.IsNullOrWhiteSpace(dr["DCH_phone"].ToString()) ? null : dr["DCH_phone"].ToString();
                Dw["DCH_Email_id"] = string.IsNullOrWhiteSpace(dr["DCH_Email_id"].ToString()) ? null : dr["DCH_Email_id"].ToString();
                Dw["DCH_Coordinator"] = string.IsNullOrWhiteSpace(dr["DCH_Coordinator"].ToString()) ? null : dr["DCH_Coordinator"].ToString();
                Dw["DCH_cordinator_phone"] = string.IsNullOrWhiteSpace(dr["DCH_cordinator_phone"].ToString()) ? null : dr["DCH_cordinator_phone"].ToString();


                Dw["DCH_Corodinator_email_id"] = string.IsNullOrWhiteSpace(dr["DCH_Corodinator_email_id"].ToString()) ? null : dr["DCH_Corodinator_email_id"].ToString();
                Dw["CFS_to_be_initiated_centrally_or_locally"] = string.IsNullOrWhiteSpace(dr["CFS_to_be_initiated_centrally_or_locally"].ToString()) ? null : dr["CFS_to_be_initiated_centrally_or_locally"].ToString();
                Dw["Customer_ID"] = string.IsNullOrWhiteSpace(dr["Customer_ID"].ToString()) ? null : dr["Customer_ID"].ToString();
                Dw["Name_contact_person"] = string.IsNullOrWhiteSpace(dr["Name_contact_person"].ToString()) ? null : dr["Name_contact_person"].ToString();
                Dw["LastName"] = string.IsNullOrWhiteSpace(dr["LastName"].ToString()) ? null : dr["LastName"].ToString();
                Dw["FirstName"] = string.IsNullOrWhiteSpace(dr["FirstName"].ToString()) ? null : dr["FirstName"].ToString();
                Dw["EmailAddress"] = string.IsNullOrWhiteSpace(dr["EmailAddress"].ToString()) ? null : dr["EmailAddress"].ToString();
                Dw["Category"] = string.IsNullOrWhiteSpace(dr["Category"].ToString()) ? null : dr["Category"].ToString();
                Dw["Job_Title"] = string.IsNullOrWhiteSpace(dr["Job_Title"].ToString()) ? null : dr["Job_Title"].ToString();
                Dw["Business_Phone"] = string.IsNullOrWhiteSpace(dr["Business_Phone"].ToString()) ? null : dr["Business_Phone"].ToString();

                Dw["Home_Phone"] = string.IsNullOrWhiteSpace(dr["Home_Phone"].ToString()) ? null : dr["Home_Phone"].ToString();
                Dw["Mobile_Phone"] = string.IsNullOrWhiteSpace(dr["Mobile_Phone"].ToString()) ? null : dr["Mobile_Phone"].ToString();
                Dw["Fax_Number"] = string.IsNullOrWhiteSpace(dr["Fax_Number"].ToString()) ? null : dr["Fax_Number"].ToString();
                Dw["Address"] = string.IsNullOrWhiteSpace(dr["Address"].ToString()) ? null : dr["Address"].ToString();
                Dw["City"] = string.IsNullOrWhiteSpace(dr["City"].ToString()) ? null : dr["City"].ToString();
                Dw["State"] = string.IsNullOrWhiteSpace(dr["State"].ToString()) ? null : dr["State"].ToString();
                Dw["PIN_Code"] = string.IsNullOrWhiteSpace(dr["PIN_Code"].ToString()) ? null : dr["PIN_Code"].ToString();
                Dw["WebPage"] = string.IsNullOrWhiteSpace(dr["WebPage"].ToString()) ? null : dr["WebPage"].ToString();
                Dw["Otherdetails"] = string.IsNullOrWhiteSpace(dr["Otherdetails"].ToString()) ? null : dr["Otherdetails"].ToString();

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

                String[] arrayOfKeyForBlankCheck = { "Centre","Vertical","Client_Name","Short_Name_Client","Product","DCH_Name","DCH_phone",
                                                     "DCH_Email_id","DCH_Coordinator","DCH_cordinator_phone","DCH_Corodinator_email_id",
                                                     "CFS_to_be_initiated_centrally_or_locally","Customer_ID","Name_contact_person",
                                                     "LastName","FirstName","EmailAddress","Category","Job_Title","Business_Phone",
                                                     "Home_Phone","Mobile_Phone","Fax_Number","Address","City","State",
                                                     "PIN_Code","WebPage","Otherdetails"};


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
    public void insertDataToDatabase()
    {
        SqlConnection sqlCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);


        for (int i = 0; i < dtUploadableData.Rows.Count; i++)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();

            sqlCon.Open();

            SqlCommand sqlCom = new SqlCommand();
            sqlCom.Connection = sqlCon;
            sqlCom.CommandType = CommandType.StoredProcedure;
            sqlCom.CommandText = "CFS_ImportCustomermaster_SP";
            SqlDataAdapter sqlDA = new SqlDataAdapter();
            sqlDA.SelectCommand = sqlCom;

            SqlParameter Centre = new SqlParameter();
            Centre.SqlDbType = SqlDbType.VarChar;
            Centre.Value = dtUploadableData.Rows[i]["Centre"];
            Centre.ParameterName = "@Centre";
            sqlCom.Parameters.Add(Centre);

            SqlParameter Vertical = new SqlParameter();
            Vertical.SqlDbType = SqlDbType.VarChar;
            Vertical.Value = dtUploadableData.Rows[i]["Vertical"];
            Vertical.ParameterName = "@Vertical";
            sqlCom.Parameters.Add(Vertical);

            SqlParameter Client_Name = new SqlParameter();
            Client_Name.SqlDbType = SqlDbType.VarChar;
            Client_Name.Value = dtUploadableData.Rows[i]["Client_Name"];
            Client_Name.ParameterName = "@Client_Name";
            sqlCom.Parameters.Add(Client_Name);

            SqlParameter Short_Name_Client = new SqlParameter();
            Short_Name_Client.SqlDbType = SqlDbType.VarChar;
            Short_Name_Client.Value = dtUploadableData.Rows[i]["Short_Name_Client"];
            Short_Name_Client.ParameterName = "@Short_Name_Client";
            sqlCom.Parameters.Add(Short_Name_Client);

            SqlParameter Product = new SqlParameter();
            Product.SqlDbType = SqlDbType.VarChar;
            Product.Value = dtUploadableData.Rows[i]["Product"];
            Product.ParameterName = "@Product";
            sqlCom.Parameters.Add(Product);

            SqlParameter DCH_Name = new SqlParameter();
            DCH_Name.SqlDbType = SqlDbType.VarChar;
            DCH_Name.Value = dtUploadableData.Rows[i]["DCH_Name"];
            DCH_Name.ParameterName = "@DCH_Name";
            sqlCom.Parameters.Add(DCH_Name);

            SqlParameter DCH_phone = new SqlParameter();
            DCH_phone.SqlDbType = SqlDbType.VarChar;
            DCH_phone.Value = dtUploadableData.Rows[i]["DCH_phone"];
            DCH_phone.ParameterName = "@DCH_phone";
            sqlCom.Parameters.Add(DCH_phone);

            SqlParameter DCH_Email_id = new SqlParameter();
            DCH_Email_id.SqlDbType = SqlDbType.VarChar;
            DCH_Email_id.Value = dtUploadableData.Rows[i]["DCH_Email_id"];
            DCH_Email_id.ParameterName = "@DCH_Email_id";
            sqlCom.Parameters.Add(DCH_Email_id);

            SqlParameter DCH_Coordinator = new SqlParameter();
            DCH_Coordinator.SqlDbType = SqlDbType.VarChar;
            DCH_Coordinator.Value = dtUploadableData.Rows[i]["DCH_Coordinator"];
            DCH_Coordinator.ParameterName = "@DCH_Coordinator";
            sqlCom.Parameters.Add(DCH_Coordinator);

            SqlParameter DCH_cordinator_phone = new SqlParameter();
            DCH_cordinator_phone.SqlDbType = SqlDbType.VarChar;
            DCH_cordinator_phone.Value = dtUploadableData.Rows[i]["DCH_cordinator_phone"];
            DCH_cordinator_phone.ParameterName = "@DCH_cordinator_phone";
            sqlCom.Parameters.Add(DCH_cordinator_phone);

            SqlParameter DCH_Corodinator_email_id = new SqlParameter();
            DCH_Corodinator_email_id.SqlDbType = SqlDbType.VarChar;
            DCH_Corodinator_email_id.Value = dtUploadableData.Rows[i]["DCH_Corodinator_email_id"];
            DCH_Corodinator_email_id.ParameterName = "@DCH_Corodinator_email_id";
            sqlCom.Parameters.Add(DCH_Corodinator_email_id);

            SqlParameter CFS_to_be_initiated_centrally_or_locally = new SqlParameter();
            CFS_to_be_initiated_centrally_or_locally.SqlDbType = SqlDbType.VarChar;
            CFS_to_be_initiated_centrally_or_locally.Value = dtUploadableData.Rows[i]["CFS_to_be_initiated_centrally_or_locally"];
            CFS_to_be_initiated_centrally_or_locally.ParameterName = "@CFS_to_be_initiated_centrally_or_locally";
            sqlCom.Parameters.Add(CFS_to_be_initiated_centrally_or_locally);

            SqlParameter Customer_ID = new SqlParameter();
            Customer_ID.SqlDbType = SqlDbType.VarChar;
            Customer_ID.Value = dtUploadableData.Rows[i]["Customer_ID"];
            Customer_ID.ParameterName = "@Customer_ID";
            sqlCom.Parameters.Add(Customer_ID);

            SqlParameter Name_contact_person = new SqlParameter();
            Name_contact_person.SqlDbType = SqlDbType.VarChar;
            Name_contact_person.Value = dtUploadableData.Rows[i]["Name_contact_person"];
            Name_contact_person.ParameterName = "@Name_contact_person";
            sqlCom.Parameters.Add(Name_contact_person);

            SqlParameter LastName = new SqlParameter();
            LastName.SqlDbType = SqlDbType.VarChar;
            LastName.Value = dtUploadableData.Rows[i]["LastName"];
            LastName.ParameterName = "@LastName";
            sqlCom.Parameters.Add(LastName);

            SqlParameter FirstName = new SqlParameter();
            FirstName.SqlDbType = SqlDbType.VarChar;
            FirstName.Value = dtUploadableData.Rows[i]["FirstName"];
            FirstName.ParameterName = "@FirstName";
            sqlCom.Parameters.Add(FirstName);

            SqlParameter EmailAddress = new SqlParameter();
            EmailAddress.SqlDbType = SqlDbType.VarChar;
            EmailAddress.Value = dtUploadableData.Rows[i]["EmailAddress"];
            EmailAddress.ParameterName = "@EmailAddress";
            sqlCom.Parameters.Add(EmailAddress);

            SqlParameter Category = new SqlParameter();
            Category.SqlDbType = SqlDbType.VarChar;
            Category.Value = dtUploadableData.Rows[i]["Category"];
            Category.ParameterName = "@Category";
            sqlCom.Parameters.Add(Category);

            SqlParameter Job_Title = new SqlParameter();
            Job_Title.SqlDbType = SqlDbType.VarChar;
            Job_Title.Value = dtUploadableData.Rows[i]["Job_Title"];
            Job_Title.ParameterName = "@Job_Title";
            sqlCom.Parameters.Add(Job_Title);

            SqlParameter Business_Phone = new SqlParameter();
            Business_Phone.SqlDbType = SqlDbType.VarChar;
            Business_Phone.Value = dtUploadableData.Rows[i]["Business_Phone"];
            Business_Phone.ParameterName = "@Business_Phone";
            sqlCom.Parameters.Add(Business_Phone);

            SqlParameter Home_Phone = new SqlParameter();
            Home_Phone.SqlDbType = SqlDbType.VarChar;
            Home_Phone.Value = dtUploadableData.Rows[i]["Home_Phone"];
            Home_Phone.ParameterName = "@Home_Phone";
            sqlCom.Parameters.Add(Home_Phone);

            SqlParameter Mobile_Phone = new SqlParameter();
            Mobile_Phone.SqlDbType = SqlDbType.VarChar;
            Mobile_Phone.Value = dtUploadableData.Rows[i]["Mobile_Phone"];
            Mobile_Phone.ParameterName = "@Mobile_Phone";
            sqlCom.Parameters.Add(Mobile_Phone);

            SqlParameter Fax_Number = new SqlParameter();
            Fax_Number.SqlDbType = SqlDbType.VarChar;
            Fax_Number.Value = dtUploadableData.Rows[i]["Fax_Number"];
            Fax_Number.ParameterName = "@Fax_Number";
            sqlCom.Parameters.Add(Fax_Number);

            SqlParameter Address = new SqlParameter();
            Address.SqlDbType = SqlDbType.VarChar;
            Address.Value = dtUploadableData.Rows[i]["Address"];
            Address.ParameterName = "@Address";
            sqlCom.Parameters.Add(Address);

            SqlParameter City = new SqlParameter();
            City.SqlDbType = SqlDbType.VarChar;
            City.Value = dtUploadableData.Rows[i]["City"];
            City.ParameterName = "@City";
            sqlCom.Parameters.Add(City);

            SqlParameter State = new SqlParameter();
            State.SqlDbType = SqlDbType.VarChar;
            State.Value = dtUploadableData.Rows[i]["State"];
            State.ParameterName = "@State";
            sqlCom.Parameters.Add(State);


            SqlParameter PIN_Code = new SqlParameter();
            PIN_Code.SqlDbType = SqlDbType.VarChar;
            PIN_Code.Value = dtUploadableData.Rows[i]["PIN_Code"];
            PIN_Code.ParameterName = "@PIN_Code";
            sqlCom.Parameters.Add(PIN_Code);

            SqlParameter WebPage = new SqlParameter();
            WebPage.SqlDbType = SqlDbType.VarChar;
            WebPage.Value = dtUploadableData.Rows[i]["WebPage"];
            WebPage.ParameterName = "@WebPage";
            sqlCom.Parameters.Add(WebPage);

            SqlParameter Otherdetails = new SqlParameter();
            Otherdetails.SqlDbType = SqlDbType.VarChar;
            Otherdetails.Value = dtUploadableData.Rows[i]["Otherdetails"];
            Otherdetails.ParameterName = "@Otherdetails";
            sqlCom.Parameters.Add(Otherdetails);


            int result = sqlCom.ExecuteNonQuery();


            sqlCon.Close();

            if (result > 0)
            {
                lblMsgXls.Visible = true;
                lblMsgXls.Text = "Data inserted";
            }
            else
            {
                lblMsgXls.Visible = true;
                lblMsgXls.Text = "Error";
            }


            //SqlDataAdapter adp = new SqlDataAdapter(sqlCom);
            //DataSet ds = new DataSet();
            //adp.Fill(ds);

            //getBIS();
        }
    }
    //public void getBIS()
    //{
    //    try
    //    {
    //        List<SqlParameter> parameters = new List<SqlParameter>();
    //        parameters.Add(new SqlParameter("@IntType", 5));
    //        //parameters.Add(new SqlParameter("@CompanyID",Convert.ToInt16(Session["ClientID"])));
    //        //parameters.Add(new SqlParameter("@ClientID", Convert.ToInt16(Session["CompanyID"])));
    //        DataSet ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "uspBISMaster", parameters.ToArray());



    //        if (ds.Tables[0].Rows.Count > 0)
    //        {
    //            gvBIS.DataSource = ds.Tables[0];
    //            gvBIS.DataBind();
    //        }
    //        else
    //        {
    //            //divError.Visible = true;
    //            //lblError.Text = "Something Went Wrong...";
    //        }
    //    }

    //    catch (Exception ex)
    //    {
    //        divError.Visible = true;
    //        lblError.Text = "Error:" + ex.Message;
    //        ErrorLog Log = new ErrorLog(ex, ErrorFileName, Session["LoginName"].ToString());
    //    }

    //}


    protected void btnCalcel_Click(object sender, EventArgs e)
    {
        Response.Redirect("CFS.aspx", true);
    }
}