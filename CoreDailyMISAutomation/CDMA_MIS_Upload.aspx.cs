using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using YesBank;

namespace CoreDailyMISAutomation
{
    public partial class CDMA_MIS_Upload : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindSubVertical();
                BindClientName();
                BindActivity();
                BindProduct();
                BindSubProduct();
                pnlRadioButton.Visible = true;
                pnlFieldSelection.Visible = true;
                pnlUploadMonthlyMIS.Visible = false;
                pnlUploadBillingMIS.Visible = false;
            }
        }

        protected void BindSubVertical()
        {
            try
            {
                SqlConnection sqlCon = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);

                SqlCommand sqlCom = new SqlCommand();
                sqlCom.Connection = sqlCon;
                sqlCom.CommandType = CommandType.StoredProcedure;
                sqlCom.CommandText = "CDMA_BindSubVertical";
                sqlCom.CommandTimeout = 0;

                SqlDataAdapter da = new SqlDataAdapter(sqlCom);
                DataSet ds = new DataSet();
                da.Fill(ds);

                if (ds != null && ds.Tables.Count > 0)
                {
                    ddlSubVertical.DataTextField = "SubVertical";
                    ddlSubVertical.DataValueField = "ID";
                    ddlSubVertical.DataSource = ds.Tables[0];
                    ddlSubVertical.DataBind();

                    ddlSubVertical.Items.Insert(0, "--Select--");
                    ddlSubVertical.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {

            }
        }

        protected void ddlSubVertical_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection sqlCon = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);

            SqlCommand sqlCom = new SqlCommand();
            sqlCom.Connection = sqlCon;
            sqlCom.CommandType = CommandType.StoredProcedure;
            sqlCom.CommandText = "CDMA_OnIndexChangeOfSubVertical_SP";
            sqlCom.CommandTimeout = 0;

            SqlParameter SubVertical = new SqlParameter();
            SubVertical.SqlDbType = SqlDbType.VarChar;
            SubVertical.Value = ddlSubVertical.SelectedValue;
            SubVertical.ParameterName = "@SubVerticalID";
            sqlCom.Parameters.Add(SubVertical);

            sqlCon.Open();

            SqlDataAdapter da = new SqlDataAdapter(sqlCom);
            DataSet ds = new DataSet();
            da.Fill(ds);

            sqlCon.Close();

            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                ddlClientName.DataTextField = "ClientName";
                ddlClientName.DataValueField = "ID";
                ddlClientName.DataSource = ds.Tables[0];
                ddlClientName.DataBind();

                ddlClientName.Items.Insert(0, "--Select--");
                ddlClientName.SelectedIndex = 0;
            }
            else
            {
                ddlClientName.Items.Clear();
            }
        }


        protected void BindClientName()
        {
            try
            {
                SqlConnection sqlCon = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);

                SqlCommand sqlCom = new SqlCommand();
                sqlCom.Connection = sqlCon;
                sqlCom.CommandType = CommandType.StoredProcedure;
                sqlCom.CommandText = "CDMA_BindClientName";
                sqlCom.CommandTimeout = 0;

                SqlDataAdapter da = new SqlDataAdapter(sqlCom);
                DataSet ds = new DataSet();
                da.Fill(ds);

                if (ds != null && ds.Tables.Count > 0)
                {
                    ddlClientName.DataTextField = "ClientName";
                    ddlClientName.DataValueField = "ID";
                    ddlClientName.DataSource = ds.Tables[0];
                    ddlClientName.DataBind();

                    ddlClientName.Items.Insert(0, "--Select--");
                    ddlClientName.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {

            }
        }

        protected void ddlClientName_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection sqlCon = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);

            SqlCommand sqlCom = new SqlCommand();
            sqlCom.Connection = sqlCon;
            sqlCom.CommandType = CommandType.StoredProcedure;
            sqlCom.CommandText = "CDMA_OnIndexChangeOfClient_SP";
            sqlCom.CommandTimeout = 0;

            SqlParameter Client = new SqlParameter();
            Client.SqlDbType = SqlDbType.VarChar;
            Client.Value = ddlClientName.SelectedValue;
            Client.ParameterName = "@ClientID";
            sqlCom.Parameters.Add(Client);

            sqlCon.Open();

            SqlDataAdapter da = new SqlDataAdapter(sqlCom);
            DataSet ds = new DataSet();
            da.Fill(ds);

            sqlCon.Close();
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                ddlActivity.DataTextField = "Activity";
                ddlActivity.DataValueField = "ID";
                ddlActivity.DataSource = ds.Tables[0];
                ddlActivity.DataBind();

                ddlActivity.Items.Insert(0, "--Select--");
                ddlActivity.SelectedIndex = 0;

                ddlProduct.DataTextField = "Product";
                ddlProduct.DataValueField = "ID";
                ddlProduct.DataSource = ds.Tables[1];
                ddlProduct.DataBind();

                ddlProduct.Items.Insert(0, "--Select--");
                ddlProduct.SelectedIndex = 0;
            }
            else
            {
                ddlActivity.Items.Clear();
                ddlProduct.Items.Clear();
            }
        }

        protected void BindActivity()
        {
            try
            {
                SqlConnection sqlCon = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);

                SqlCommand sqlCom = new SqlCommand();
                sqlCom.Connection = sqlCon;
                sqlCom.CommandType = CommandType.StoredProcedure;
                sqlCom.CommandText = "CDMA_BindActivity";
                sqlCom.CommandTimeout = 0;

                SqlDataAdapter da = new SqlDataAdapter(sqlCom);
                DataSet ds = new DataSet();
                da.Fill(ds);

                if (ds != null && ds.Tables.Count > 0)
                {
                    ddlActivity.DataTextField = "Activity";
                    ddlActivity.DataValueField = "ID";
                    ddlActivity.DataSource = ds.Tables[0];
                    ddlActivity.DataBind();

                    ddlActivity.Items.Insert(0, "--Select--");
                    ddlActivity.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {

            }
        }

        //protected void ddlActivity_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    SqlConnection sqlCon = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);

        //    SqlCommand sqlCom = new SqlCommand();
        //    sqlCom.Connection = sqlCon;
        //    sqlCom.CommandType = CommandType.StoredProcedure;
        //    sqlCom.CommandText = "CDMA_OnIndexChangeOfActivity_SP";
        //    sqlCom.CommandTimeout = 0;

        //    SqlParameter Client = new SqlParameter();
        //    Client.SqlDbType = SqlDbType.VarChar;
        //    Client.Value = ddlClientName.SelectedValue;
        //    Client.ParameterName = "@ClientID";
        //    sqlCom.Parameters.Add(Client);

        //    SqlParameter SubVertical = new SqlParameter();
        //    SubVertical.SqlDbType = SqlDbType.VarChar;
        //    SubVertical.Value = ddlSubVertical.SelectedValue;
        //    SubVertical.ParameterName = "@SubVerticalID";
        //    sqlCom.Parameters.Add(SubVertical);

        //    sqlCon.Open();

        //    SqlDataAdapter da = new SqlDataAdapter(sqlCom);
        //    DataSet ds = new DataSet();
        //    da.Fill(ds);

        //    sqlCon.Close();

        //    if (ds != null && ds.Tables.Count > 0)
        //    {
        //        ddlProduct.DataTextField = "Product";
        //        ddlProduct.DataValueField = "ID";
        //        ddlProduct.DataSource = ds.Tables[0];
        //        ddlProduct.DataBind();

        //        ddlProduct.Items.Insert(0, "--Select--");
        //        ddlProduct.SelectedIndex = 0;
        //    }
        //    else
        //    {

        //        ddlProduct.Items.Clear();
        //    }
        //}

        protected void BindProduct()
        {
            try
            {
                SqlConnection sqlCon = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);

                SqlCommand sqlCom = new SqlCommand();
                sqlCom.Connection = sqlCon;
                sqlCom.CommandType = CommandType.StoredProcedure;
                sqlCom.CommandText = "CDMA_BindProduct";
                sqlCom.CommandTimeout = 0;

                SqlDataAdapter da = new SqlDataAdapter(sqlCom);
                DataSet ds = new DataSet();
                da.Fill(ds);

                if (ds != null && ds.Tables.Count > 0)
                {
                    ddlProduct.DataTextField = "Product";
                    ddlProduct.DataValueField = "ID";
                    ddlProduct.DataSource = ds.Tables[0];
                    ddlProduct.DataBind();

                    ddlProduct.Items.Insert(0, "--Select--");
                    ddlProduct.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {

            }
        }

        protected void ddlProduct_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection sqlCon = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);

            SqlCommand sqlCom = new SqlCommand();
            sqlCom.Connection = sqlCon;
            sqlCom.CommandType = CommandType.StoredProcedure;
            sqlCom.CommandText = "CDMA_OnIndexChangeOfProduct_SP";
            sqlCom.CommandTimeout = 0;

            SqlParameter Product = new SqlParameter();
            Product.SqlDbType = SqlDbType.VarChar;
            Product.Value = ddlProduct.SelectedValue;
            Product.ParameterName = "@ProductID";
            sqlCom.Parameters.Add(Product);

            sqlCon.Open();

            SqlDataAdapter da = new SqlDataAdapter(sqlCom);
            DataSet ds = new DataSet();
            da.Fill(ds);

            sqlCon.Close();

            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                ddlSubProduct.Enabled = true;
                ddlSubProduct.DataTextField = "SubProduct";
                ddlSubProduct.DataValueField = "ID";
                ddlSubProduct.DataSource = ds.Tables[0];
                ddlSubProduct.DataBind();

                ddlSubProduct.Items.Insert(0, "--Select--");
                ddlSubProduct.SelectedIndex = 0;
            }
            else
            {
                ddlSubProduct.Enabled = false;
            }
        }

        protected void BindSubProduct()
        {
            try
            {
                SqlConnection sqlCon = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);

                SqlCommand sqlCom = new SqlCommand();
                sqlCom.Connection = sqlCon;
                sqlCom.CommandType = CommandType.StoredProcedure;
                sqlCom.CommandText = "CDMA_BindSubProduct";
                sqlCom.CommandTimeout = 0;

                SqlDataAdapter da = new SqlDataAdapter(sqlCom);
                DataSet ds = new DataSet();
                da.Fill(ds);

                if (ds != null && ds.Tables.Count > 0)
                {
                    ddlSubProduct.DataTextField = "SubProduct";
                    ddlSubProduct.DataValueField = "ID";
                    ddlSubProduct.DataSource = ds.Tables[0];
                    ddlSubProduct.DataBind();

                    ddlSubProduct.Items.Insert(0, "--Select--");
                    ddlSubProduct.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {

            }
        }

        protected void rdMIS_SelectedIndexChanged(object sender, EventArgs e)
        {
            string msg = string.Empty;
            if (ddlSubVertical.SelectedItem.Text == "--Select--")
            {
                msg = msg + "Please Select Sub Vertical.";
            }
            if (ddlClientName.SelectedItem.Text == "--Select--")
            {
                msg = msg + "Please Select Client Name.";
            }
            if (ddlActivity.SelectedItem.Text == "--Select--")
            {
                msg = msg + "Please Select Activity.";
            }
            if (ddlProduct.SelectedItem.Text == "--Select--")
            {
                msg = msg + "Please Select Product.";
            }
            //if (ddlSubProduct.SelectedItem.Text == "--Select--")
            //{
            //    msg = msg + "Please Select Sub Product.";
            //}
            if (txtMonthYear.Text.Trim() == "")
            {
                msg = msg + "Please Select Month Year.";
            }
            if (msg != "")
            {
                rdMIS.Items[0].Selected = false;
                rdMIS.Items[1].Selected = false;

                ClientScript.RegisterStartupScript(Page.GetType(), "mykey", "alert('" + msg + "');", true);
                return;
            }

            if (rdMIS.SelectedValue == "Monthly MIS")
            {
                pnlRadioButton.Visible = false;
                pnlFieldSelection.Visible = false;
                pnlUploadBillingMIS.Visible = false;
                pnlUploadMonthlyMIS.Visible = true;
            }
            if (rdMIS.SelectedValue == "Billing MIS")
            {
                pnlRadioButton.Visible = false;
                pnlFieldSelection.Visible = false;
                pnlUploadMonthlyMIS.Visible = false;
                pnlUploadBillingMIS.Visible = true;
            }
        }

        protected void btnImport_Click(object sender, EventArgs e)
        {

            SqlConnection sqlCon = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            try
            {
                lblMsgXls.Text = "";
                //Upload and save the file
                string excelPath = Server.MapPath("~/UploadedFiles/") + Path.GetFileName(xslFileUpload.PostedFile.FileName);
                string fileName = Path.GetFileNameWithoutExtension(excelPath);
                string fileExtension = Path.GetExtension(excelPath);

                string datetime = DateTime.Now.ToString("yyyy-MM-dd HH mm ss");

                string newxlsfilename = "CDMA_" + datetime + fileExtension;

                newxlsfilename = excelPath.Replace(Path.GetFileName(xslFileUpload.PostedFile.FileName), newxlsfilename);
                //if (fileName.ToUpper().StartsWith("INVOICE MANAGEMENT"))
                //{
                if (fileExtension.ToUpper() == ".XLS" || fileExtension.ToUpper() == ".XLSX")
                {
                    xslFileUpload.SaveAs(newxlsfilename);

                    ImportExcel ie = new ImportExcel();
                    DataTable dt = new DataTable();
                    DataSet ds = ie.ExcelDataReader(newxlsfilename);
                    if (ds.Tables.Count > 0)
                    {
                        dt = ds.Tables[0];
                    }
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        // Validating if all columns exists in format
                        int colCount = dt.Columns.Count;  // 8
                        if (colCount != 15)    //Modified on 30/08/2023 
                        {
                            lblmsg.Text = "Uploaded Excel Not As Per Standard Format Column Mismatch";

                            return;
                        }

                        List<string> Columns = returnColumns();  // 14

                        int i = 0;
                        foreach (var col in Columns)
                        {
                            if (Columns[i] != Convert.ToString(dt.Columns[i].ColumnName))
                            {
                                lblmsg.Text = Columns[i] + "!=" + Convert.ToString(dt.Columns[i].ColumnName)
                                  + "File not uploaded !!  Uploaded Excel Not As Per Standard Format Columns Name Mismatch";

                                return;
                            }
                            i++;
                        }

                        //dt.Columns.Add("UserName").DefaultValue = Session["UserName"];
                        DataColumn newColumn = new DataColumn("CreatedBy", typeof(System.String));
                        newColumn.DefaultValue = Convert.ToString(Session["UserID"]);
                        dt.Columns.Add(newColumn);


                        i = 0;
                        List<string> renameColumns = ReNameColumns();
                        foreach (var col in renameColumns)
                        {
                            dt.Columns[i].ColumnName = renameColumns[i];

                            i++;
                        }

                        dt.AcceptChanges();

                        int Result = 0;


                        foreach (DataRow row in dt.Rows)
                        {
                            if (Convert.ToString(row["MISForTheMonth"]).Normalize() != txtMonthYear.Text)
                            {
                                lblmsg.Text = "Please check month and year of uploaded file not match with select month and year !!!";
                                return;
                            }
                        }

                        string Sub_Product = string.Empty;

                        if (ddlSubProduct.SelectedItem.Text != "--Select--")
                        {
                            Sub_Product = ddlSubProduct.SelectedItem.Text;
                        }


                        DataTable dtCloned = dt.Clone();
                        dtCloned.Columns[0].DataType = typeof(string);
                        dtCloned.Columns[1].DataType = typeof(string);
                        dtCloned.Columns[2].DataType = typeof(string);
                        dtCloned.Columns[3].DataType = typeof(string);
                        dtCloned.Columns[4].DataType = typeof(string);
                        dtCloned.Columns[5].DataType = typeof(string);
                        dtCloned.Columns[6].DataType = typeof(string);
                        dtCloned.Columns[7].DataType = typeof(string);
                        dtCloned.Columns[8].DataType = typeof(string);
                        dtCloned.Columns[9].DataType = typeof(string);
                        dtCloned.Columns[10].DataType = typeof(string);
                        dtCloned.Columns[11].DataType = typeof(string);
                        dtCloned.Columns[12].DataType = typeof(string);
                        dtCloned.Columns[13].DataType = typeof(string);
                        dtCloned.Columns[14].DataType = typeof(string);
                        foreach (DataRow row in dt.Rows)
                        {
                            dtCloned.ImportRow(row);
                        }
                        dt = dtCloned;

                        dt.AcceptChanges();

                        // structure changed replacing old structure
                        SqlCommand cmd = new SqlCommand("CDMA_InsertDataIntoTrackingTable_SP", sqlCon);

                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Vertical", txtVertical.Text.Trim());
                        cmd.Parameters.AddWithValue("@SubVertical", ddlSubVertical.SelectedItem.Text);
                        cmd.Parameters.AddWithValue("@ClientName", ddlClientName.SelectedItem.Text);
                        cmd.Parameters.AddWithValue("@Activity", ddlActivity.SelectedItem.Text);
                        cmd.Parameters.AddWithValue("@Product", ddlProduct.SelectedItem.Text);
                        cmd.Parameters.AddWithValue("@SubProduct", Sub_Product);
                        cmd.Parameters.AddWithValue("@MonthYear", txtMonthYear.Text.Trim());
                        cmd.Parameters.AddWithValue("@UserID", Convert.ToString(Session["UserID"]));
                        cmd.Parameters.AddWithValue("@Branch", Convert.ToString(Session["Branch_Name"]));
                        cmd.Parameters.AddWithValue("@ExcelData", dt);


                        sqlCon.Open();
                        Result = cmd.ExecuteNonQuery();
                        sqlCon.Close();

                        if (Result > 0)
                        {
                            lblmsg.Text = "Imported Successfully";
                        }
                        else
                        {
                            lblmsg.Text = "Error Error Error";
                        }

                        //if (Result > 0)
                        //{
                        //    SqlCommand cmd1 = new SqlCommand("CDMA_InsertDataIntoTrackingTable_SP", sqlCon);
                        //    cmd1.CommandType = CommandType.StoredProcedure;
                        //    cmd1.CommandTimeout = 340;
                        //    SqlDataAdapter dp2 = new SqlDataAdapter(cmd1);
                        //    DataSet ds2 = new DataSet();
                        //    dp2.Fill(ds2);

                        //    //ExportToExcel(ds2.Tables[0]);

                        //    //ExportToExcel(ds2.Tables[0]);

                        //    if (Result > 0)
                        //    {
                        //        lblmsg.Text = "Data Inserted Successfully !!!";
                        //        lblmsg.ForeColor = System.Drawing.Color.Green;
                        //    }
                        //    else
                        //    {
                        //        lblmsg.Text = "No Record Found To Insert";
                        //    }
                        //}
                        //else
                        //{
                        //    lblmsg.Text = "No Records Found to Import, Kindly check the Excel !";
                        //    lblmsg.ForeColor = System.Drawing.Color.Red;
                        //    return;
                        //}

                        if (File.Exists(newxlsfilename))
                        {
                            File.Delete(newxlsfilename);
                        }
                    }
                }
                else
                {
                    lblmsg.Text = "Invalid File Extension, Only .xls and .xlsx file are allowed !";
                    lblmsg.ForeColor = System.Drawing.Color.Red;
                    return;
                }

            }
            catch (Exception ex)
            {
                lblmsg.Text = "Error:" + ex.Message;
                lblmsg.ForeColor = System.Drawing.Color.Red;
            }
        }

        private List<string> returnColumns()
        {
            List<string> column = new List<string>();
            //  New fields added as per changed format
            column.Add("Sr No");
            column.Add("Case processing Date");
            column.Add("Case Received Date");
            column.Add("Unique Case ID");
            column.Add("Customer Name");
            column.Add("Case Type  (FTR/Rework/FTNR Resolved/FTNR)");
            column.Add("Loan Amount");
            column.Add("Case completed date");
            column.Add("Case status");
            column.Add("Remark");
            column.Add("Maker Name");
            column.Add("Maker ID");
            column.Add("Checker Name");
            column.Add("Checker ID");
            column.Add("MIS for the month");
            return column;
        }
        private List<string> ReNameColumns()
        {
            List<string> column = new List<string>();
            // mdifed column names in view of changed format
            column.Add("ID");
            column.Add("CaseProcessingDate");
            column.Add("CaseReceivedDate");
            column.Add("UniqueCaseID");
            column.Add("CustomerName");
            column.Add("CaseType");
            column.Add("LoanAmount");
            column.Add("CaseCompletedDate");
            column.Add("CaseStatus");
            column.Add("Remark");
            column.Add("MakerName");
            column.Add("MakerID");
            column.Add("CheckerName");
            column.Add("CheckerID");
            column.Add("MISForTheMonth");
            return column;
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("CDMA_MIS_Upload.aspx", false);
        }

        protected void btnDownloadUploadFormat_Click(object sender, EventArgs e)
        {
            Response.ContentType = "application/XLSX";
            Response.AppendHeader("Content-Disposition", "attachment; filename=UploadFormat.xls");
            Response.TransmitFile(Server.MapPath("~/UploadFormat/CDMA_MonthlyMISUploadFormat.xls"));
            Response.End();
        }

        //public void ExportToExcel(DataTable dt)
        //{
        //    if (dt.Rows.Count > 0)
        //    {
        //        string currentDateTime = DateTime.Now.Ticks.ToString();
        //        string filename = "CDMA_MonthlyMIS_" + currentDateTime + ".xls";
        //        System.IO.StringWriter tw = new System.IO.StringWriter();
        //        System.Web.UI.HtmlTextWriter hw = new System.Web.UI.HtmlTextWriter(tw);
        //        DataGrid dgGrid = new DataGrid();
        //        dgGrid.DataSource = dt;
        //        dgGrid.DataBind();

        //        //Get the HTML for the control.
        //        dgGrid.RenderControl(hw);
        //        //Write the HTML back to the browser.
        //        //Response.ContentType = application/vnd.ms-excel;
        //        Response.ContentType = "application/vnd.ms-excel";
        //        Response.AppendHeader("Content-Disposition", "attachment; filename=" + filename + "");
        //        this.EnableViewState = false;
        //        Response.Write(tw.ToString());
        //        Response.End();
        //    }
        //}

        protected void btnImportBilling_Click(object sender, EventArgs e)
        {
            string msg = string.Empty;
            if (ddlSubVertical.SelectedItem.Text == "--Select--")
            {
                msg = msg + "Please Select Sub Vertical.";
            }
            if (ddlClientName.SelectedItem.Text == "--Select--")
            {
                msg = msg + "Please Select Client Name.";
            }
            if (ddlActivity.SelectedItem.Text == "--Select--")
            {
                msg = msg + "Please Select Activity.";
            }
            if (ddlProduct.SelectedItem.Text == "--Select--")
            {
                msg = msg + "Please Select Product.";
            }
            //if (ddlSubProduct.SelectedItem.Text == "--Select--")
            //{
            //    msg = msg + "Please Select Sub Product.";
            //}
            if (msg != "")
            {
                ClientScript.RegisterStartupScript(Page.GetType(), "mykey", "alert('" + msg + "');", true);
            }
            SqlConnection sqlCon = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            try
            {
                lblMessage.Text = "";
                //Upload and save the file


                string excelPath = Server.MapPath("~/UploadedFiles/") + Path.GetFileName(FileUploadBilling.PostedFile.FileName);

                string fileName = Path.GetFileNameWithoutExtension(excelPath);
                string fileExtension = Path.GetExtension(excelPath);

                string datetime = DateTime.Now.ToString("yyyy-MM-dd HH mm ss");

                string newxlsfilename = "CDMA_Billing_" + datetime + fileExtension;

                newxlsfilename = excelPath.Replace(Path.GetFileName(FileUploadBilling.PostedFile.FileName), newxlsfilename);
                //if (fileName.ToUpper().StartsWith("INVOICE MANAGEMENT"))
                //{
                if (fileExtension.ToUpper() == ".XLS" || fileExtension.ToUpper() == ".XLSX")
                {
                    FileUploadBilling.SaveAs(newxlsfilename);

                    ImportExcel ie = new ImportExcel();
                    DataTable dt = new DataTable();
                    DataSet ds = ie.ExcelDataReader(newxlsfilename);
                    if (ds.Tables.Count > 0)
                    {
                        dt = ds.Tables[0];
                    }
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        // Validating if all columns exists in format
                        int colCount = dt.Columns.Count;  // 8
                        if (colCount != 12)    //Modified on 30/08/2023 
                        {
                            lblMessage.Text = "Uploaded Excel Not As Per Standard Format Column Mismatch";

                            return;
                        }

                        List<string> Columns = ReturnColumns();  // 14

                        int i = 0;
                        foreach (var col in Columns)
                        {
                            if (Columns[i].ToUpper() != Convert.ToString(dt.Columns[i].ColumnName).ToUpper())
                            {
                                lblMessage.Text = Columns[i] + "!=" + Convert.ToString(dt.Columns[i].ColumnName)
                                  + "File not uploaded !!  Uploaded Excel Not As Per Standard Format Columns Name Mismatch";

                                return;
                            }
                            i++;
                        }

                        //dt.Columns.Add("UserName").DefaultValue = Session["UserName"];
                        DataColumn newColumn = new DataColumn("CreatedBy", typeof(System.String));
                        newColumn.DefaultValue = Convert.ToString(Session["UserID"]);
                        dt.Columns.Add(newColumn);


                        i = 0;
                        List<string> renameColumns = RenameColumns();
                        foreach (var col in renameColumns)
                        {
                            dt.Columns[i].ColumnName = renameColumns[i];

                            i++;
                        }

                        dt.AcceptChanges();

                        foreach (DataRow row in dt.Rows)
                        {
                            if (Convert.ToString(row["MISForTheMonth"]).Normalize() != txtMonthYear.Text)
                            {
                                lblMessage.Text = "Please check Month and Year of the uploaded file Not Match With Selected Month and Year !!!";
                                return;
                            }
                        }


                        DataTable dtCloned = dt.Clone();
                        dtCloned.Columns[0].DataType = typeof(string);
                        dtCloned.Columns[1].DataType = typeof(string);
                        dtCloned.Columns[2].DataType = typeof(string);
                        dtCloned.Columns[3].DataType = typeof(string);
                        dtCloned.Columns[4].DataType = typeof(string);
                        dtCloned.Columns[5].DataType = typeof(string);
                        dtCloned.Columns[6].DataType = typeof(string);
                        dtCloned.Columns[7].DataType = typeof(string);
                        dtCloned.Columns[8].DataType = typeof(string);
                        dtCloned.Columns[9].DataType = typeof(string);
                        dtCloned.Columns[10].DataType = typeof(string);
                        dtCloned.Columns[11].DataType = typeof(string);
                        foreach (DataRow row in dt.Rows)
                        {
                            dtCloned.ImportRow(row);
                        }
                        dt = dtCloned;

                        dt.AcceptChanges();


                        string Sub_Product = string.Empty;

                        if (ddlSubProduct.SelectedItem.Text != "--Select--")
                        {
                            Sub_Product = ddlSubProduct.SelectedItem.Text;
                        }

                        // structure changed replacing old structure
                        SqlCommand cmd = new SqlCommand("CDMA_InsertBillingMISIntoTrackingTable_SP", sqlCon);

                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Vertical", txtVertical.Text.Trim());
                        cmd.Parameters.AddWithValue("@SubVertical", ddlSubVertical.SelectedItem.Text);
                        cmd.Parameters.AddWithValue("@ClientName", ddlClientName.SelectedItem.Text);
                        cmd.Parameters.AddWithValue("@Activity", ddlActivity.SelectedItem.Text);
                        cmd.Parameters.AddWithValue("@Product", ddlProduct.SelectedItem.Text);
                        cmd.Parameters.AddWithValue("@SubProduct", Sub_Product);
                        cmd.Parameters.AddWithValue("@MonthYear", txtMonthYear.Text.Trim());
                        cmd.Parameters.AddWithValue("@Branch", Convert.ToString(Session["BranchName"]));
                        cmd.Parameters.AddWithValue("@UserID", Convert.ToString(Session["UserID"]));
                        cmd.Parameters.AddWithValue("@ExcelData", dt);

                        SqlDataAdapter adp1 = new SqlDataAdapter(cmd);
                        DataSet ds1 = new DataSet();
                        adp1.Fill(ds1);

                        if (ds1 != null && ds1.Tables.Count > 0)
                        {
                            lblMessage.Text = ds1.Tables[0].Rows[0]["MSG"].ToString();
                        }
                        else
                        {
                            lblMessage.Text = "Error Error Error";
                        }


                        //if (Result > 0)
                        //{


                        //    SqlCommand cmd1 = new SqlCommand("CDMA_InsertBillingMISIntoTrackingTable_SP", sqlCon);
                        //    cmd1.CommandType = CommandType.StoredProcedure;
                        //    cmd1.Parameters.AddWithValue("@Vertical_FV", txtVertical.Text.Trim());
                        //    cmd1.Parameters.AddWithValue("@SubVertical_FV", ddlSubVertical.SelectedItem.Text);
                        //    cmd1.Parameters.AddWithValue("@ClientName_FV", ddlClientName.SelectedItem.Text);
                        //    cmd1.Parameters.AddWithValue("@Activity_FV", ddlActivity.SelectedItem.Text);
                        //    cmd1.Parameters.AddWithValue("@Product_FV", ddlProduct.SelectedItem.Text);
                        //    cmd1.Parameters.AddWithValue("@SubProduct_FV", ddlSubProduct.SelectedItem.Text);
                        //    cmd1.Parameters.AddWithValue("@MonthYear_FV", txtMonthYear.Text.Trim());
                        //    cmd1.Parameters.AddWithValue("@Branch_FV", Convert.ToString(Session["BranchName"]));
                        //    SqlDataAdapter dp2 = new SqlDataAdapter(cmd1);
                        //    DataSet ds2 = new DataSet();
                        //    dp2.Fill(ds2);

                        //    //ExportToExcelBillingMIS(ds2.Tables[0]);

                        //    if (Result > 0)
                        //    {
                        //        lblMessage.Text = "Data Inserted Successfully !!!";
                        //        lblMessage.ForeColor = System.Drawing.Color.Green;
                        //    }
                        //    else
                        //    {
                        //        lblMessage.Text = "No Record Found To Insert";
                        //    }
                        //}
                        //else
                        //{
                        //    lblMessage.Text = "No Records Found to Import, Kindly check the Excel !";
                        //    lblMessage.ForeColor = System.Drawing.Color.Red;
                        //    return;
                        //}


                        if (File.Exists(newxlsfilename))
                        {
                            File.Delete(newxlsfilename);
                        }
                    }
                }
                else
                {
                    lblMessage.Text = "Invalid File Extension, Only .xls and .xlsx file are allowed !";
                    lblMessage.ForeColor = System.Drawing.Color.Red;
                    return;
                }

            }
            catch (Exception ex)
            {
                lblMessage.Text = "Error:" + ex.Message;
                lblMessage.ForeColor = System.Drawing.Color.Red;
            }
        }

        private List<string> ReturnColumns()
        {
            List<string> column = new List<string>();
            //  New fields added as per changed format
            column.Add("Sr No");
            column.Add("Case Processing Date");
            column.Add("Case Received Date");
            column.Add("Unique Case ID");
            column.Add("Customer Name");
            column.Add("Case Type  (FTR/Rework/FTNR Resolved/FTNR)");
            column.Add("Loan Amount");
            column.Add("Case completed date");
            column.Add("Final - Case status");
            column.Add("Rate Per Case");
            column.Add("Remark");
            column.Add("MIS for the month");
            return column;
        }
        private List<string> RenameColumns()
        {
            List<string> column = new List<string>();
            // mdifed column names in view of changed format
            column.Add("ID");
            column.Add("CaseProcessingDate");
            column.Add("CaseReceivedDate");
            column.Add("UniqueCaseID");
            column.Add("CustomerName");
            column.Add("CaseType");
            column.Add("LoanAmount");
            column.Add("CaseCompletedDate");
            column.Add("FinalCaseStatus");
            column.Add("RatePerCase");
            column.Add("Remark");
            column.Add("MISForTheMonth");
            return column;
        }

        protected void btnBackBilling_Click(object sender, EventArgs e)
        {
            Response.Redirect("CDMA_MIS_Upload.aspx", false);
        }

        protected void btnDownloadBilling_Click(object sender, EventArgs e)
        {
            Response.ContentType = "application/XLSX";
            Response.AppendHeader("Content-Disposition", "attachment; filename=UploadFormat.xls");
            Response.TransmitFile(Server.MapPath("~/UploadFormat/CDMA_BillingMISUploadFormat.xls"));
            Response.End();
        }

        //public void ExportToExcelBillingMIS(DataTable dt)
        //{
        //    if (dt.Rows.Count > 0)
        //    {
        //        string currentDateTime = DateTime.Now.Ticks.ToString();
        //        string filename = "CDMA_BillingMIS_" + currentDateTime + ".xls";
        //        System.IO.StringWriter tw = new System.IO.StringWriter();
        //        System.Web.UI.HtmlTextWriter hw = new System.Web.UI.HtmlTextWriter(tw);
        //        DataGrid dgGrid = new DataGrid();
        //        dgGrid.DataSource = dt;
        //        dgGrid.DataBind();

        //        //Get the HTML for the control.
        //        dgGrid.RenderControl(hw);
        //        //Write the HTML back to the browser.
        //        //Response.ContentType = application/vnd.ms-excel;
        //        Response.ContentType = "application/vnd.ms-excel";
        //        Response.AppendHeader("Content-Disposition", "attachment; filename=" + filename + "");
        //        this.EnableViewState = false;
        //        Response.Write(tw.ToString());
        //        Response.End();
        //    }
        //}
    }
}