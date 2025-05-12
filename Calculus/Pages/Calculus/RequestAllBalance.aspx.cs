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
using System.Data.SqlClient;
using System.IO;
using System.Data.OleDb;

public partial class Pages_Calculus_RequestAllBalance : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {

                Object SaveUSERInfo = (Object)Session["UserInfo"];

                string userid = Convert.ToString(((UserInfo.structUSERInfo)(SaveUSERInfo)).UserId);// Session["UserId"].ToString();
                if ((userid == "P59195") || (userid == "P00030") || (userid == "P-00030"))
                {
                    btnHOTrnsfr.Visible = true;
                }
                //string userid = Session["UserId"].ToString();
                //if (userid == "P59195")
                //{
                //    if (!ddlBalanceTyp.Items.Contains(new ListItem("---Select---")))
                //    {
                //        ddlBalanceTyp.Items.Add(new ListItem("---Select---", "0"));
                //    }
                //    if (!ddlBalanceTyp.Items.Contains(new ListItem("PettyCash Balance")))
                //    {
                //        ddlBalanceTyp.Items.Add(new ListItem("PettyCash Balance", "Petty"));
                //    }
                //    if (!ddlBalanceTyp.Items.Contains(new ListItem("HO Balance")))
                //    {
                //        ddlBalanceTyp.Items.Add(new ListItem("HO Balance", "HO"));
                //    }
                //    ddlBalanceTyp.SelectedIndex = 0;
                //    ddlBalanceTyp.DataBind();
                //}
                //else
                //{
                //    if (!ddlBalanceTyp.Items.Contains(new ListItem("---Select---")))
                //    {
                //        ddlBalanceTyp.Items.Add(new ListItem("---Select---", "0"));
                //    }
                //    if (!ddlBalanceTyp.Items.Contains(new ListItem("HO Balance")))
                //    {
                //        ddlBalanceTyp.Items.Add(new ListItem("HO Balance", "HO"));
                //    }
                //    ddlBalanceTyp.SelectedIndex = 0;
                //    ddlBalanceTyp.DataBind();
                //}

                BindBalanceType();
            }
        }
        catch (Exception ex)
        {
            lblMessage.Visible = true;
            lblMessage.Text = ex.Message;
            lblMessage.CssClass = "ErrorMessage";
        }


    }
    private void Get_GridOpeningBalanceData()
    {

        try
        {

            Object SaveUSERInfo = (Object)Session["UserInfo"];

            SqlConnection SqlCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);

            SqlCon.Open();
            SqlCommand SqlCmd = new SqlCommand();
            SqlCmd.Connection = SqlCon;
            SqlCmd.CommandType = CommandType.StoredProcedure;
            SqlCmd.CommandText = "CalOnlineTrans_GetRequestOpeningBalanceData_Petty_SP";//Get_RequestOpeningBalanceData_new Get_RequestOpeningBalanceData_new08Aug

            SqlParameter BranchID = new SqlParameter();
            BranchID.SqlDbType = SqlDbType.Int;
            BranchID.Value = ((UserInfo.structUSERInfo)(SaveUSERInfo)).BranchId;
            BranchID.ParameterName = "@BranchID";
            SqlCmd.Parameters.Add(BranchID);

            #region Code By Amrita on 22-Apr-2014 As per Client Requirement
            SqlParameter ClientId = new SqlParameter();
            ClientId.SqlDbType = SqlDbType.Int;
            ClientId.Value = Convert.ToInt32(((UserInfo.structUSERInfo)(SaveUSERInfo)).ClientId);
            ClientId.ParameterName = "@ClientId";
            SqlCmd.Parameters.Add(ClientId);
            #endregion


            SqlDataAdapter sqlDA = new SqlDataAdapter();
            sqlDA.SelectCommand = SqlCmd;

            DataTable dt = new DataTable();
            sqlDA.Fill(dt);
            SqlCon.Close();

            PnlGrid.Visible = true;
            Gr_Ope_Bal.DataSource = dt;
            Gr_Ope_Bal.DataBind();
        }
        catch (Exception ex)
        {
            lblMessage.Visible = true;
            lblMessage.Text = ex.Message;
            lblMessage.CssClass = "Error Message";
        }
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Pages/Menu.aspx", true);
    }
    protected void btnBulkSave_Click(object sender, EventArgs e)
    {
        try
        {
            if (xslFileUpload.HasFile)
            {
                String strPath = "";
                String MyFile = "";
                string strDateTime = DateTime.Now.ToString("ddMMyyyyhhmmss");

                strPath = Server.MapPath("~/Pages/Calculus/IMPORT/");
                MyFile = strDateTime + ".xls";
                strPath = (strPath + MyFile);
                xslFileUpload.PostedFile.SaveAs(strPath);

                string strFileName = xslFileUpload.FileName.ToString();

                FileInfo fi = new FileInfo(strFileName);
                string strExt = fi.Extension;

                if (strExt.ToLower() == ".xls")
                {
                    string strConn = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + strPath + @";Extended Properties=""Excel 8.0;IMEX=1""";

                    OleDbConnection oleCon = new OleDbConnection(strConn);
                    oleCon.Open();

                    OleDbCommand oleCom = new OleDbCommand("SELECT * FROM [sheet1$]");
                    oleCom.Connection = oleCon;

                    OleDbDataAdapter oleDA = new OleDbDataAdapter();
                    oleDA.SelectCommand = oleCom;

                    DataTable dt = new DataTable();
                    oleDA.Fill(dt);
                    oleCon.Close();

                    if (dt.Rows.Count > 0)
                    {
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            if (ddlBalanceTyp.SelectedValue == "HO" && ddlBalanceTyp.SelectedValue != "0")
                            {
                                Bulk_Import(dt.Rows[i]);
                            }
                            else if (ddlBalanceTyp.SelectedValue == "Petty" && ddlBalanceTyp.SelectedValue != "0")
                            {
                                OpeningBalance_Import(dt.Rows[i]);
                            }

                        }
                        lblMessage.Text = "Data Import Successfully!!";

                    }

                    string strFile = Server.MapPath("~/Pages/Calculus/IMPORT/") + MyFile;
                    if (File.Exists(strFile))
                    {
                        File.Delete(strFile);
                    }
                }
                else
                {
                    lblMessage.Visible = true;
                    lblMessage.Text = "It's Not An Excel File...!!!";
                }
            }
            else
            {
                lblMessage.Visible = true;
                lblMessage.Text = "Please Select Excel File To Import...!!!";
            }
        }
        catch (Exception ex)
        {
            lblMessage.Visible = true;
            lblMessage.Text = "Error :" + ex.Message;
        }

    }
    //protected void Bulk_Import(DataRow dr)
    //{
    //    Object SaveUSERInfo = (Object)Session["UserInfo"];

    //    SqlConnection sqlCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);


    //    SqlCommand sqlcmd = new SqlCommand();
    //    sqlcmd.Connection = sqlCon;
    //    sqlcmd.CommandType = CommandType.StoredProcedure;
    //    sqlcmd.CommandText = "update_OpeningBalanceRequestHO";
    //    sqlcmd.CommandTimeout = 0;

    //    SqlParameter Branch = new SqlParameter();
    //    Branch.SqlDbType = SqlDbType.VarChar;
    //    Branch.Value = dr["Branch"].ToString().Trim();
    //    Branch.ParameterName = "@Branch";
    //    sqlcmd.Parameters.Add(Branch);

    //    SqlParameter RequestType = new SqlParameter();
    //    RequestType.SqlDbType = SqlDbType.VarChar;
    //    RequestType.Value = "1";
    //    RequestType.ParameterName = "@RequestType";
    //    sqlcmd.Parameters.Add(RequestType);

    //    SqlParameter Year = new SqlParameter();
    //    Year.SqlDbType = SqlDbType.VarChar;
    //    Year.Value = dr["Year"].ToString().Trim();
    //    Year.ParameterName = "@Yr";
    //    sqlcmd.Parameters.Add(Year);

    //    SqlParameter Month = new SqlParameter();
    //    Month.SqlDbType = SqlDbType.VarChar;
    //    Month.Value = dr["Month"].ToString().Trim();
    //    Month.ParameterName = "@Month";
    //    sqlcmd.Parameters.Add(Month);

    //    SqlParameter amount = new SqlParameter();
    //    amount.SqlDbType = SqlDbType.Decimal;
    //    amount.Value = dr["HO transfer amount"].ToString().Trim()+".00";
    //    amount.ParameterName = "@HOamount";
    //    sqlcmd.Parameters.Add(amount);

    //    SqlParameter DateTrnsfr = new SqlParameter();
    //    DateTrnsfr.SqlDbType = SqlDbType.VarChar;
    //    DateTrnsfr.Value = dr["Date Of Transfer"].ToString().Trim();
    //    DateTrnsfr.ParameterName = "@DateTrnsfr";
    //    sqlcmd.Parameters.Add(DateTrnsfr);

    //    SqlParameter UserID = new SqlParameter();
    //    UserID.SqlDbType = SqlDbType.VarChar;
    //    UserID.Value = Convert.ToString(((UserInfo.structUSERInfo)(SaveUSERInfo)).UserId);
    //    UserID.ParameterName = "@User_ID";
    //    sqlcmd.Parameters.Add(UserID);

    //    sqlCon.Open();
    //    int RowEffected = 0;

    //    RowEffected = sqlcmd.ExecuteNonQuery();

    //    if (RowEffected > 0)
    //    {
    //        Get_GridOpeningBalanceData();
    //    }

    //    sqlCon.Close();
    //}
    protected void Bulk_Import(DataRow dr)
    {
        Object SaveUSERInfo = (Object)Session["UserInfo"];

        SqlConnection sqlCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);

        sqlCon.Open();

        string TType = dr["Transfer Type"].ToString().Trim();
        if (TType == "Petty")
        {
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlCon;
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.CommandText = "CalOnlineTrans_UpdateOpeningBalanceRequestHOPetty_SP";
            sqlcmd.CommandTimeout = 0;

            SqlParameter Branch = new SqlParameter();
            Branch.SqlDbType = SqlDbType.VarChar;
            Branch.Value = dr["Branch"].ToString().Trim();
            Branch.ParameterName = "@Branch";
            sqlcmd.Parameters.Add(Branch);

            SqlParameter RequestType = new SqlParameter();
            RequestType.SqlDbType = SqlDbType.VarChar;
            RequestType.Value = "1";
            RequestType.ParameterName = "@RequestType";
            sqlcmd.Parameters.Add(RequestType);

            SqlParameter Year = new SqlParameter();
            Year.SqlDbType = SqlDbType.VarChar;
            Year.Value = dr["Year"].ToString().Trim();
            Year.ParameterName = "@Yr";
            sqlcmd.Parameters.Add(Year);

            SqlParameter Month = new SqlParameter();
            Month.SqlDbType = SqlDbType.VarChar;
            Month.Value = dr["Month"].ToString().Trim();
            Month.ParameterName = "@Month";
            sqlcmd.Parameters.Add(Month);

            if (dr["HO transfer amount"].ToString().Trim() != "")
            {
                SqlParameter amount = new SqlParameter();
                amount.SqlDbType = SqlDbType.Decimal;
                amount.Value = dr["HO transfer amount"].ToString().Trim();
                amount.ParameterName = "@HOamount";
                sqlcmd.Parameters.Add(amount);
            }
            else
            {
                SqlParameter amount = new SqlParameter();
                amount.SqlDbType = SqlDbType.Decimal;
                amount.Value = "0.00";
                amount.ParameterName = "@HOamount";
                sqlcmd.Parameters.Add(amount);
            }

            SqlParameter DateTrnsfr = new SqlParameter();
            DateTrnsfr.SqlDbType = SqlDbType.VarChar;
            DateTrnsfr.Value = dr["Date Of Transfer"].ToString().Trim();
            DateTrnsfr.ParameterName = "@DateTrnsfr";
            sqlcmd.Parameters.Add(DateTrnsfr);

            SqlParameter UserID = new SqlParameter();
            UserID.SqlDbType = SqlDbType.VarChar;
            UserID.Value = Convert.ToString(((UserInfo.structUSERInfo)(SaveUSERInfo)).UserId);
            UserID.ParameterName = "@User_ID";
            sqlcmd.Parameters.Add(UserID);


            int RowEffected = 0;

            RowEffected = sqlcmd.ExecuteNonQuery();

            if (RowEffected > 0)
            {
                Get_GridOpeningBalanceData();
            }
        }
        else if (TType == "OTP")
        {
            SqlCommand sqlcom = new SqlCommand();
            sqlcom.Connection = sqlCon;
            sqlcom.CommandType = CommandType.StoredProcedure;
            sqlcom.CommandText = "CalOnlineTrans_UpdateOpeningBalanceRequestHOOTP_SP";
            sqlcom.CommandTimeout = 0;

            SqlParameter Branch = new SqlParameter();
            Branch.SqlDbType = SqlDbType.VarChar;
            Branch.Value = dr["Branch"].ToString().Trim();
            Branch.ParameterName = "@Branch";
            sqlcom.Parameters.Add(Branch);

            SqlParameter RequestType = new SqlParameter();
            RequestType.SqlDbType = SqlDbType.VarChar;
            RequestType.Value = "1";
            RequestType.ParameterName = "@RequestType";
            sqlcom.Parameters.Add(RequestType);

            SqlParameter Year = new SqlParameter();
            Year.SqlDbType = SqlDbType.VarChar;
            Year.Value = dr["Year"].ToString().Trim();
            Year.ParameterName = "@Yr";
            sqlcom.Parameters.Add(Year);

            SqlParameter Month = new SqlParameter();
            Month.SqlDbType = SqlDbType.VarChar;
            Month.Value = dr["Month"].ToString().Trim();
            Month.ParameterName = "@Month";
            sqlcom.Parameters.Add(Month);

            if (dr["HO transfer amount"].ToString().Trim() != "")
            {
                SqlParameter amount = new SqlParameter();
                amount.SqlDbType = SqlDbType.Decimal;
                amount.Value = dr["HO transfer amount"].ToString().Trim();
                amount.ParameterName = "@HOamount";
                sqlcom.Parameters.Add(amount);
            }
            else
            {
                SqlParameter amount = new SqlParameter();
                amount.SqlDbType = SqlDbType.Decimal;
                amount.Value = "0.00";
                amount.ParameterName = "@HOamount";
                sqlcom.Parameters.Add(amount);
            }

            SqlParameter DateTrnsfr = new SqlParameter();
            DateTrnsfr.SqlDbType = SqlDbType.VarChar;
            DateTrnsfr.Value = dr["Date Of Transfer"].ToString().Trim();
            DateTrnsfr.ParameterName = "@DateTrnsfr";
            sqlcom.Parameters.Add(DateTrnsfr);

            SqlParameter UserID = new SqlParameter();
            UserID.SqlDbType = SqlDbType.VarChar;
            UserID.Value = Convert.ToString(((UserInfo.structUSERInfo)(SaveUSERInfo)).UserId);
            UserID.ParameterName = "@User_ID";
            sqlcom.Parameters.Add(UserID);


            int RowEffected1 = 0;

            RowEffected1 = sqlcom.ExecuteNonQuery();

            if (RowEffected1 > 0)
            {
                Get_GridOpeningBalanceData();
            }
        }
        sqlCon.Close();
    }

    protected void Button3_Click(object sender, EventArgs e)
    {

        string filename = "Bulk_Import.xls";
        Response.ContentType = "application/octect-stream";
        Response.AppendHeader("Content-Disposition", "attachment;filename=" + filename);
        Response.TransmitFile(Server.MapPath("~/Pages/Calculus/files/" + filename));
        Response.End();
    }
    protected void ddlBalanceTyp_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlBalanceTyp.SelectedValue == "HO" && ddlBalanceTyp.SelectedValue != "0")
        {
            PnlHO.Visible = true;
            //PnlPetty.Visible = false;
            PnlGrid.Visible = false;
            Get_GridOpeningBalanceData();
        }
        else if (ddlBalanceTyp.SelectedValue == "Petty" && ddlBalanceTyp.SelectedValue != "0")
        {
            PnlHO.Visible = true;
            //PnlPetty.Visible = true;
            PnlGrid.Visible = false;
            Get_GridOpeningBalanceData();
        }
        else
        {
            PnlHO.Visible = false;
            //PnlPetty.Visible = false;
            PnlGrid.Visible = false;
        }
    }
    protected void OpeningBalance_Import(DataRow dr)
    {
        Object SaveUSERInfo = (Object)Session["UserInfo"];

        SqlConnection sqlCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);


        SqlCommand sqlcmd = new SqlCommand();
        sqlcmd.Connection = sqlCon;
        sqlcmd.CommandType = CommandType.StoredProcedure;
        sqlcmd.CommandText = "CalOnlineTrans_InsertOpeningBalanceRequestNew12_SP";//Insert_OpeningBalanceRequestNew1
        sqlcmd.CommandTimeout = 0;

        SqlParameter Branch = new SqlParameter();
        Branch.SqlDbType = SqlDbType.VarChar;
        Branch.Value = dr["Branch"].ToString().Trim();
        Branch.ParameterName = "@Branch";
        sqlcmd.Parameters.Add(Branch);

        SqlParameter RequestType = new SqlParameter();
        RequestType.SqlDbType = SqlDbType.VarChar;
        RequestType.Value = "1";
        RequestType.ParameterName = "@RequestType";
        sqlcmd.Parameters.Add(RequestType);

        SqlParameter Year = new SqlParameter();
        Year.SqlDbType = SqlDbType.VarChar;
        Year.Value = dr["Year"].ToString().Trim();
        Year.ParameterName = "@Yr";
        sqlcmd.Parameters.Add(Year);

        SqlParameter Month = new SqlParameter();
        Month.SqlDbType = SqlDbType.VarChar;
        Month.Value = dr["Month"].ToString().Trim();
        Month.ParameterName = "@Month";
        sqlcmd.Parameters.Add(Month);

        SqlParameter amount = new SqlParameter();
        amount.SqlDbType = SqlDbType.Decimal;
        amount.Value = dr["Opening Balance Amount"].ToString().Trim() + ".00";
        amount.ParameterName = "@Balanceamount";
        sqlcmd.Parameters.Add(amount);

        SqlParameter Status = new SqlParameter();
        Status.SqlDbType = SqlDbType.Int;
        Status.Value = 2;
        Status.ParameterName = "@Status";
        sqlcmd.Parameters.Add(Status);

        SqlParameter UserID = new SqlParameter();
        UserID.SqlDbType = SqlDbType.VarChar;
        UserID.Value = Convert.ToString(((UserInfo.structUSERInfo)(SaveUSERInfo)).UserId);
        UserID.ParameterName = "@User_ID";
        sqlcmd.Parameters.Add(UserID);

        SqlParameter ClientId = new SqlParameter();
        ClientId.SqlDbType = SqlDbType.VarChar;
        ClientId.Value = Convert.ToString(((UserInfo.structUSERInfo)(SaveUSERInfo)).ClientId);
        ClientId.ParameterName = "@ClientId";
        sqlcmd.Parameters.Add(ClientId);

        sqlCon.Open();
        int RowEffected = 0;

        RowEffected = sqlcmd.ExecuteNonQuery();

        if (RowEffected > 0)
        {
            //AcceptPendingCases();
            Get_GridOpeningBalanceData();
        }

        sqlCon.Close();
    }
    private void AcceptPendingCases()
    {
        Object SaveUSERInfo = (Object)Session["UserInfo"];

        SqlConnection sqlCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);

        sqlCon.Open();
        SqlCommand sqlCmd = new SqlCommand();
        sqlCmd.Connection = sqlCon;
        sqlCmd.CommandType = CommandType.StoredProcedure;
        sqlCmd.CommandText = "CalOnlineTrans_UpdateOpeningBalanceAcceptedNew1_SP";
        sqlCmd.CommandTimeout = 0;


        SqlParameter Status = new SqlParameter();
        Status.SqlDbType = SqlDbType.Int;
        Status.Value = "2";
        Status.ParameterName = "@Status";
        sqlCmd.Parameters.Add(Status);

        SqlParameter ClientId = new SqlParameter();
        ClientId.SqlDbType = SqlDbType.Int;
        ClientId.Value = Convert.ToInt32(((UserInfo.structUSERInfo)(SaveUSERInfo)).ClientId);
        ClientId.ParameterName = "@ClientId";
        sqlCmd.Parameters.Add(ClientId);


        SqlParameter UserID = new SqlParameter();
        UserID.SqlDbType = SqlDbType.VarChar;
        UserID.Value = Convert.ToString(((UserInfo.structUSERInfo)(SaveUSERInfo)).UserId);
        UserID.ParameterName = "@UserID";
        sqlCmd.Parameters.Add(UserID);

        int SqlRow = 0;
        SqlRow = sqlCmd.ExecuteNonQuery();

        if (SqlRow > 0)
        {
            lblMessage.Text = "Update Successfully!";
            lblMessage.CssClass = "UpdateMessage";
            lblMessage.Visible = true;
        }
    }
    protected void btnHO_Click(object sender, EventArgs e)
    {
        string filename = "Bulk_Import.xls";
        Response.ContentType = "application/octect-stream";
        Response.AppendHeader("Content-Disposition", "attachment;filename=" + filename);
        Response.TransmitFile(Server.MapPath("~/Pages/Calculus/files/" + filename));
        Response.End();
    }
    protected void btnPetty_Click(object sender, EventArgs e)
    {
        string filename = "OpeningBalance.xls";
        Response.ContentType = "application/octect-stream";
        Response.AppendHeader("Content-Disposition", "attachment;filename=" + filename);
        Response.TransmitFile(Server.MapPath("~/Pages/Calculus/files/" + filename));
        Response.End();
    }

    protected void btnHOTrnsfr_Click(object sender, EventArgs e)
    {
        Get_HOTransferDetails();
        Generate_ExcelFile();

    }
    private void Get_HOTransferDetails()
    {
        try
        {
            Object SaveUSERInfo = (Object)Session["UserInfo"];

            SqlConnection sqlcon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);

            sqlcon.Open();
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlcon;
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.CommandText = "CalOnlineTrans_GetHOTransferData_SP";
            SqlDataAdapter sqlda = new SqlDataAdapter();
            sqlda.SelectCommand = sqlcmd;

            SqlParameter ReqType = new SqlParameter();
            ReqType.SqlDbType = SqlDbType.VarChar;
            ReqType.Value = "1";
            ReqType.ParameterName = "@ReqType";
            sqlcmd.Parameters.Add(ReqType);


            DataTable dt = new DataTable();
            sqlda.Fill(dt);
            sqlcon.Close();


            gvExportReport.DataSource = dt;
            gvExportReport.DataBind();
        }
        catch (Exception ex)
        {

            lblMessage.Visible = true;
            lblMessage.Text = ex.Message;
            lblMessage.CssClass = "Error Message";
        }

    }
    private void Generate_ExcelFile()
    {
        String attachment = "attachment; filename=HoTransferReport.xls";
        Response.AddHeader("content-disposition", attachment);
        Response.ContentType = "application/ms-excel";
        StringWriter sw = new System.IO.StringWriter();
        HtmlTextWriter htw = new HtmlTextWriter(sw);
        Table tblSpace = new Table();
        TableRow tblRow = new TableRow();
        TableCell tblCell = new TableCell();
        tblCell.Text = " ";

        TableRow tblRow1 = new TableRow();
        TableCell tblCell1 = new TableCell();
        tblCell1.ColumnSpan = 20;// 10;
        tblCell1.Text = "<b> <span style='background-color:Gray'> <font size='4'>PAMAC FINSERVE PVT. LTD.,HO Transfer Details </font></span></b> <br/>";
        tblCell1.CssClass = "SuccessMessage";
        tblRow.Cells.Add(tblCell);
        tblRow1.Cells.Add(tblCell1);
        tblRow.Height = 20;
        tblSpace.Rows.Add(tblRow);
        tblSpace.Rows.Add(tblRow1);
        tblSpace.RenderControl(htw);

        Table tbl = new Table();
        gvExportReport.EnableViewState = false;
        gvExportReport.GridLines = GridLines.Both;
        tbExport.RenderControl(htw);

        string style = @"<style> TD { mso-number-format:\@; } </style> ";
        Response.Write(style);

        Response.Write(sw.ToString());

        Response.End();
    }

    public override void VerifyRenderingInServerForm(Control control)
    {

    }
    protected void BindBalanceType()
    {
        Common common = new Common();
        DataSet ds = new DataSet();

        ds = common.GetCalOnlineTransMasterSearchCode("BalanceType", 1);
        if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            ddlBalanceTyp.DataSource = ds;
            ddlBalanceTyp.DataValueField = "Code_Id";
            ddlBalanceTyp.DataTextField = "Description";
            ddlBalanceTyp.DataBind();
            ddlBalanceTyp.Items.Insert(0, new ListItem("--Select--", "0"));
        }
    }
}