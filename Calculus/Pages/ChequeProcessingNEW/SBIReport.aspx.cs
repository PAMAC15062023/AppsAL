using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.IO;
using System.Globalization;
using System.Collections;
using System.Text;

public partial class Pages_ChequeProcessingNEW_SBIReport : System.Web.UI.Page
{
    public ArrayList Arrlist = new ArrayList();

      protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserInfo"] == null)
        {
            Response.Redirect("~/Pages/InvalidRequest.aspx");
        }

        if (!IsPostBack) 
        {
            if (Cache["SBIClientList"] == null)
            {
                Get_AllClientList();
            }
            else
            {
                ddlClientList.DataTextField = "ClientName";
                ddlClientList.DataValueField = "ClientID";

                ddlClientList.DataSource = (DataTable)Cache["SBIClientList"];
                ddlClientList.DataBind();

                ddlClientList.Items.Insert(0, "-Select-");
                ddlClientList.SelectedIndex = 0;
            }
            //Get_AllBranchList();
        }
        Object SaveUSERInfo = (Object)Session["UserInfo"];
        lblLocation.Text = Convert.ToString(((UserInfo.structUSERInfo)(SaveUSERInfo)).BranchName);
        
    }

    private void Get_AllClientList()
    {
        try
        {
            SqlConnection sqlcon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);

            sqlcon.Open();
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlcon;
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.CommandText = "Get_AllClientList";
            SqlDataAdapter sqlda = new SqlDataAdapter();
            sqlda.SelectCommand = sqlcmd;

            SqlParameter Is_Active = new SqlParameter();
            Is_Active.SqlDbType = SqlDbType.Int;
            Is_Active.Value = 1;
            Is_Active.ParameterName = "@Is_Active";
            sqlcmd.Parameters.Add(Is_Active);

            DataTable dt = new DataTable();
            sqlda.Fill(dt);

            sqlcon.Close();

            Cache["SBIClientList"] = dt;

            ddlClientList.DataTextField = "ClientName";
            ddlClientList.DataValueField = "ClientID";
            ddlClientList.DataSource = dt;
            ddlClientList.DataBind();

            ddlClientList.Items.Insert(0, "-Select-");
            ddlClientList.SelectedIndex = 0;

        }
        catch (Exception ex)
        {
            lblMessage.Visible = true;
            lblMessage.Text = ex.Message;
            lblMessage.CssClass = "ErrorMessage";

        }

        finally
        { 
        
        }
    }
    //private void Get_AllBranchList()
    //{
    //    try
    //    {
    //        Object SaveUSERInfo = (Object)Session["UserInfo"];

    //        SqlConnection sqlcon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);

    //        sqlcon.Open();
    //        SqlCommand sqlcmd = new SqlCommand();
    //        sqlcmd.Connection = sqlcon;
    //        sqlcmd.CommandType = CommandType.StoredProcedure;
    //        sqlcmd.CommandText = "Get_AllBranchList";
    //        SqlDataAdapter sqlda = new SqlDataAdapter();
    //        sqlda.SelectCommand = sqlcmd;

    //        DataTable dt = new DataTable();

    //        sqlda.Fill(dt);
    //        sqlcon.Close();

    //        ddlBranch.DataTextField = "BranchName";
    //        ddlBranch.DataValueField = "BranchId";
    //        ddlBranch.DataSource = dt;
    //        ddlBranch.DataBind();

    //        ddlBranch.Items.Insert(0, "--ALL--");
    //        ddlBranch.SelectedIndex = 0;

    //    }
    //    catch (Exception ex)
    //    {
    //        lblMessage.Visible = true;
    //        lblMessage.Text = ex.Message;
    //        lblMessage.CssClass = "ErrorMessage";
    //    }

    //}
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Pages/Menu.aspx", true);
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        if (ddlClientList.SelectedIndex != 0)
        {
            if (txtFromDate.Text != "")
            {
                if (txtToDate.Text != "")
                {
                    if (ddlMIStype.SelectedIndex <= 0)
                    {
                        lblMessage.Visible = true;
                        lblMessage.Text = "Select MIS Type.";
                    }
                    else
                        if (ddlMIStype.SelectedValue == "GetDataForTextReportSBI")
                        {
                            btnExport.Text = "Export Text Report";
                            lblMessage.Visible = false;

                            //pnlExport.Visible = true;
                            grvMISdata.Visible = true;
                            btmPanel.Visible = true;
                            GetDataForMIS();
                            //Generate_TextFile();
                        }
                        else
                            {
                                btnExport.Text = "Export to Excel";
                        lblMessage.Visible = false;
                        //pnlExport.Visible = true;
                        grvMISdata.Visible = true;
                        btmPanel.Visible = true;
                        GetDataForMIS();
                    }
                }
                else
                {
                    lblMessage.Text = "Enter Deposit Date.";
                    lblMessage.CssClass = "ErrorMessage";
                }
            }
            else
            {
                lblMessage.Text = "Enter from Date.";
                lblMessage.CssClass = "ErrorMessage";
            }

        }
        else
        {
            lblMessage.Text = "Select One Client.";
            lblMessage.CssClass = "ErrorMessage";
        }
        
       
    }

    private void GetDataForMIS()
    {
        string ReportHeaderName = "";

        if (ddlMIStype.SelectedIndex != 0)
        {

            ReportHeaderName = ddlMIStype.SelectedItem.Text;

        }
        lblReportHeader.Text = ReportHeaderName;

        if (ddlMIStype.SelectedValue == "Get_DropBoxMIS")
        {
            try
            {
                ReportHeaderName = "";
                grvMISdata.ShowHeader = true;
                grvMISdata.DataSource = null;
                grvMISdata.DataBind();
                BindDateWise_Gridview();

                if (grvMISdata.Rows.Count == 0)
                {
                    lblMessage.Visible = true;
                    lblMessage.Text = "No Records Found";
                    ReportHeaderName = "";
                }
                if (grvMISdata.Rows.Count == 0 && DateDiff>31)
                {
                    lblMessage.Visible = true;
                    lblMessage.Text = "Difference between dates should be 31 days or less.";
                    ReportHeaderName = "";
                }

              
            }
            catch (Exception ex)
            {
                lblMessage.Visible = true;
                lblMessage.Text = ex.Message;
            }
        }
        else
            if (ddlMIStype.SelectedValue == "GetDataForTextReportSBI")
        {
            try
            {
                Object SaveUSERInfo = (Object)Session["UserInfo"];

                SqlConnection sqlcon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);

                sqlcon.Open();
                SqlCommand sqlcmd = new SqlCommand();
                sqlcmd.Connection = sqlcon;
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.CommandText = ddlMIStype.SelectedItem.Value.ToString().Trim();
                SqlDataAdapter sqlda = new SqlDataAdapter();
                sqlda.SelectCommand = sqlcmd;

                SqlParameter BranchID = new SqlParameter();
                BranchID.SqlDbType = SqlDbType.Int;
                BranchID.Value = Convert.ToInt32(((UserInfo.structUSERInfo)(SaveUSERInfo)).BranchId);
                BranchID.ParameterName = "@BranchID";
                sqlcmd.Parameters.Add(BranchID);

                int pClientId = 0;
                if (ddlClientList.SelectedIndex != 0)
                {
                    pClientId = Convert.ToInt32(ddlClientList.SelectedItem.Value);
                }

                SqlParameter ClientID = new SqlParameter();
                ClientID.SqlDbType = SqlDbType.Int;
                ClientID.Value = pClientId;
                ClientID.ParameterName = "@ClientID";
                sqlcmd.Parameters.Add(ClientID);

                SqlParameter FromDate = new SqlParameter();
                FromDate.SqlDbType = SqlDbType.VarChar;
                FromDate.Value = txtFromDate.Text.Trim();
                FromDate.ParameterName = "@FromDate";
                sqlcmd.Parameters.Add(FromDate);

                SqlParameter ToDate = new SqlParameter();
                ToDate.SqlDbType = SqlDbType.VarChar;
                ToDate.Value = txtToDate.Text.Trim();
                ToDate.ParameterName = "@ToDate";
                sqlcmd.Parameters.Add(ToDate);

                DataTable dt = new DataTable();
                sqlda.Fill(dt);
                sqlcon.Close();

                if (dt.Rows.Count > 0)
                {
                    lblMessage.Text = "Record(s) Founds :" + dt.Rows.Count;
                    lblMessage.CssClass = "SuccessMessage";


                    grvMISdata.Visible = true;
                    grvMISdata.ShowHeader = false;
                    //grvMISdata.AllowPaging = false;
                    grvMISdata.DataSource = dt;
                    grvMISdata.DataBind();

                }
                else
                {
                    lblMessage.CssClass = "ErrorMessage";
                    lblMessage.Text = "Record(s) Founds :" + 0;
                    grvMISdata.DataSource = null;
                    grvMISdata.DataBind();

                }
            }
            catch (Exception ex)
            {
                lblMessage.Visible = true;
                lblMessage.Text = ex.Message;
                lblMessage.CssClass = "ErrorMessage";

            }

            }
            else
        {

        Object SaveUSERInfo = (Object)Session["UserInfo"];
        
        SqlConnection sqlcon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);

        sqlcon.Open();
        SqlCommand sqlcmd = new SqlCommand();
        sqlcmd.Connection = sqlcon;
        sqlcmd.CommandType = CommandType.StoredProcedure;
        sqlcmd.CommandText = ddlMIStype.SelectedItem.Value.ToString().Trim();
        SqlDataAdapter sqlda = new SqlDataAdapter();
        sqlda.SelectCommand = sqlcmd;

        //int pBranchID = 0;
        //if (ddlBranch.SelectedIndex != 0)
        //{
        //    pBranchID = Convert.ToInt32(ddlBranch.SelectedItem.Value);
        //}

        SqlParameter BranchID = new SqlParameter();
        BranchID.SqlDbType = SqlDbType.Int;
        BranchID.Value = Convert.ToInt32(((UserInfo.structUSERInfo)(SaveUSERInfo)).BranchId);
        BranchID.ParameterName = "@BranchID";
        sqlcmd.Parameters.Add(BranchID);

        int pClientId = 0;
        if (ddlClientList.SelectedIndex != 0)
        {
            pClientId = Convert.ToInt32(ddlClientList.SelectedItem.Value);
        }

        SqlParameter ClientID = new SqlParameter();
        ClientID.SqlDbType = SqlDbType.Int;
        ClientID.Value = pClientId;
        ClientID.ParameterName = "@ClientID";
        sqlcmd.Parameters.Add(ClientID);

        SqlParameter FromDate = new SqlParameter();
        FromDate.SqlDbType = SqlDbType.VarChar;
        FromDate.Value = txtFromDate.Text.Trim();
        FromDate.ParameterName = "@FromDate_dmy";
        sqlcmd.Parameters.Add(FromDate);

        SqlParameter ToDate = new SqlParameter();
        ToDate.SqlDbType = SqlDbType.VarChar;
        ToDate.Value = txtToDate.Text.Trim();
        ToDate.ParameterName = "@ToDate_mdy";
        sqlcmd.Parameters.Add(ToDate);

        DataTable dt = new DataTable();
        sqlda.Fill(dt);
        sqlcon.Close();

        if (dt.Rows.Count > 0)
        {
            lblMessage.Text = "Record(s) Founds :" + dt.Rows.Count;
            lblMessage.CssClass = "SuccessMessage";

            grvMISdata.Visible = true;
            grvMISdata.DataSource = dt;
            grvMISdata.DataBind();
        }
        else
        {
            lblMessage.CssClass = "ErrorMessage";
            lblMessage.Text = "Record(s) Founds :" + 0;
            grvMISdata.DataSource = null;
            grvMISdata.DataBind();

        }
        }

    }
    public int DateDiff;
    public int DropBoxID;
    public string BatchDate;
    public int Count;
    public string datename;
    public string ColumnValue;
    public int TotalCount;
    public int NonZeroCount;
    public int DaysCount;

    private string Get_DateFormat(string cDate, string cDateFormat)
    {
        try
        {
            string strDate = cDate;
            string[] strArrDate = strDate.Split('/');

            if (strArrDate.Length > 0)
            {
                if (cDateFormat == "yyyy/MM/dd")
                {
                    strDate = strArrDate[2] + "/" + strArrDate[1] + "/" + strArrDate[0];

                }
                else if (cDateFormat == "MM/dd/yyyy")
                {
                    strDate = strArrDate[1] + "/" + strArrDate[0] + "/" + strArrDate[2];

                }
            }

            return strDate;
        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
            lblMessage.CssClass = "ErrorMessage";
            lblMessage.Visible = true;
            return "";
        }

    }
    public DataSet DropboxData = new DataSet();
    public void BindDateWise_Gridview()
    {
        SqlConnection sqlcon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);
        Object SaveUSERInfo = (Object)Session["UserInfo"];

        Get_DateFiff();

        if (DateDiff <= 31)
        {
            SqlCommand cmd = new SqlCommand("GetDataFor_DropBoxMIS_1", sqlcon);
            cmd.CommandType = CommandType.StoredProcedure;

            //cmd.Parameters.AddWithValue("@FromDate", txtFromDate.Text.Trim());
            //cmd.Parameters.AddWithValue("@ToDate", txtToDate.Text.Trim());
            cmd.Parameters.AddWithValue("@BranchID", Convert.ToInt32(((UserInfo.structUSERInfo)(SaveUSERInfo)).BranchId));
            // Display the selected users information
            sqlcon.Open();
            GetDropBoxCountForDate2();
            GetTotalCountForDate();
            using (SqlDataReader dr = cmd.ExecuteReader())
            {
                if (dr.HasRows)
                {
                    DataTable DT = new DataTable();
                    DataColumn DC = new DataColumn();

                    DC = new DataColumn("Sr.No", typeof(System.String));
                    DT.Columns.Add(DC);
                    DC = new DataColumn("Location", typeof(System.String));
                    DT.Columns.Add(DC);
                    DC = new DataColumn("DropBox ID", typeof(System.String));
                    DT.Columns.Add(DC);
                    DC = new DataColumn("DropBox Name", typeof(System.String));
                    DT.Columns.Add(DC);

                    int i = 0;

                    for (i = 0; i <= DateDiff; i++)
                    {
                        DC = new DataColumn(" " + Convert.ToDateTime(Get_DateFormat(txtFromDate.Text.Trim(), "MM/dd/yyyy")).AddDays(i).ToString("ddd") + ":" + Convert.ToInt32(Convert.ToDateTime(Get_DateFormat(txtFromDate.Text.Trim(), "MM/dd/yyyy")).AddDays(i).ToString("dd")) + "-" + Convert.ToInt32(Convert.ToDateTime(Get_DateFormat(txtFromDate.Text.Trim(), "MM/dd/yyyy")).AddDays(i).ToString("yy")), typeof(System.Int32));
                        DT.Columns.Add(DC);

                        Arrlist.Add(Convert.ToDateTime(Get_DateFormat(txtFromDate.Text.Trim(), "MM/dd/yyyy")).AddDays(i).ToString("MM/dd/yyyy"));
                    }

                    DC = new DataColumn("Volume/Month", typeof(System.Int32));
                    DT.Columns.Add(DC);
                    DC = new DataColumn("Average", typeof(System.Int32));
                    DT.Columns.Add(DC);

                    i = 0;
                    int j = 0;
                    int k = 0;
                    int sno = 1;

                    DataRow DR;
                    DR = DT.NewRow();
                    ColumnValue = "";

                    //GetDropBoxCountForDate2();


                    while (dr.Read())
                    {
                        DropBoxID = Convert.ToInt32(dr[3].ToString());

                        if (DropBoxID == 99999)
                        {
                            DR["Sr.No"] = "";
                            DR["Location"] = dr[0].ToString();
                            DR["DropBox ID"] = dr[1].ToString();
                            DR["DropBox Name"] = dr[2].ToString();

                            TotalCount = 0;
                            NonZeroCount = 0;

                            for (j = 0; j <= DateDiff; j++)
                            {
                                ColumnValue = " " + Convert.ToDateTime(Get_DateFormat(txtFromDate.Text.Trim(), "MM/dd/yyyy")).AddDays(j).ToString("ddd") + ":" + Convert.ToInt32(Convert.ToDateTime(Get_DateFormat(txtFromDate.Text.Trim(), "MM/dd/yyyy")).AddDays(j).ToString("dd")) + "-" + Convert.ToInt32(Convert.ToDateTime(Get_DateFormat(txtFromDate.Text.Trim(), "MM/dd/yyyy")).AddDays(j).ToString("yy"));
                                datename = Get_DateFormat(Arrlist[j].ToString(), "MM/dd/yyyy");
                                if (ds.Tables.Count > 0)
                                {
                                    for (k = 0; k < ds2.Tables[0].Rows.Count; k++)
                                    {
                                        if (Convert.ToInt32(ds2.Tables[0].Rows[k]["dropboxid"].ToString()) == DropBoxID && ds2.Tables[0].Rows[k]["date"].ToString() == datename.ToString())
                                        {
                                            DaysCount = Convert.ToInt32(ds2.Tables[0].Rows[k]["cnt"].ToString());
                                            NonZeroCount++;
                                            break;
                                        }
                                        else
                                        {
                                            DaysCount = 0;
                                        }
                                    }
                                }
                                DR[ColumnValue] = DaysCount;
                                //datename = "";
                                TotalCount = TotalCount + DaysCount;
                            }

                           
                            DR["Volume/Month"] = TotalCount;
                            if (NonZeroCount == 0)
                            {
                                DR["Average"] = 0;
                            }
                            else
                            {
                                DR["Average"] = Convert.ToInt32(TotalCount / NonZeroCount);
                            }
                            DT.Rows.Add(DR);
                        }
                        else
                        {
                            DR["Sr.No"] = sno;
                            DR["Location"] = dr[0].ToString();
                            DR["DropBox ID"] = dr[1].ToString();
                            DR["DropBox Name"] = dr[2].ToString();

                            TotalCount = 0;
                            NonZeroCount = 0;

                            for (j = 0; j <= DateDiff; j++)
                            {
                                ColumnValue = " " + Convert.ToDateTime(Get_DateFormat(txtFromDate.Text.Trim(), "MM/dd/yyyy")).AddDays(j).ToString("ddd") + ":" + Convert.ToInt32(Convert.ToDateTime(Get_DateFormat(txtFromDate.Text.Trim(), "MM/dd/yyyy")).AddDays(j).ToString("dd")) + "-" + Convert.ToInt32(Convert.ToDateTime(Get_DateFormat(txtFromDate.Text.Trim(), "MM/dd/yyyy")).AddDays(j).ToString("yy"));
                                datename = Get_DateFormat(Arrlist[j].ToString(), "MM/dd/yyyy");


                                if (ds.Tables.Count > 0)
                                {
                                    for (k = 0; k < ds.Tables[0].Rows.Count; k++)
                                    {
                                        if (Convert.ToInt32(ds.Tables[0].Rows[k]["dropboxid"].ToString()) == DropBoxID && ds.Tables[0].Rows[k]["date"].ToString() == datename.ToString())
                                        {
                                            Count = Convert.ToInt32(ds.Tables[0].Rows[k]["cnt"].ToString());
                                            NonZeroCount++;
                                            break;
                                        }
                                        else
                                        {
                                            Count = 0;
                                        }
                                    }


                                }

                                DR[ColumnValue] = Count;
                                TotalCount = TotalCount + Count;

                            }


                            DR["Volume/Month"] = TotalCount;
                            if (NonZeroCount == 0)
                            {
                                DR["Average"] = 0;
                            }
                            else
                            {
                                DR["Average"] = Convert.ToInt32(TotalCount / NonZeroCount);
                            }
                            DT.Rows.Add(DR);
                            //DT.Rows.Add();
                            DR = DT.NewRow();
                            sno++;
                        }
                    }
                    grvMISdata.DataSource = DT;
                    grvMISdata.DataBind();
                }
            }
        }
        else 
        {
            lblMessage.Visible = true;
            lblMessage.Text = "Difference between dates should be less than 31 days.";
            lblMessage.CssClass = "ErrorMessage";
        }

    }


    public SqlDataReader dr2;
    public DataSet ds = new DataSet();
    private void GetDropBoxCountForDate2()
    {
        try
        {
            Object SaveUSERInfo = (Object)Session["UserInfo"];
            SqlConnection sqlcon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);

            sqlcon.Open();
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlcon;
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.CommandText = "GetDropBoxCountForDate";
            SqlDataAdapter sqlda = new SqlDataAdapter();
            sqlda.SelectCommand = sqlcmd;

            SqlParameter BranchID = new SqlParameter();
            BranchID.SqlDbType = SqlDbType.Int;
            BranchID.Value = Convert.ToInt32(((UserInfo.structUSERInfo)(SaveUSERInfo)).BranchId);
            BranchID.ParameterName = "@BranchID";
            sqlcmd.Parameters.Add(BranchID);

            SqlParameter FromDate = new SqlParameter();
            FromDate.SqlDbType = SqlDbType.VarChar;
            FromDate.Value = txtFromDate.Text;
            FromDate.ParameterName = "@FromDate";
            sqlcmd.Parameters.Add(FromDate);

            SqlParameter ToDate = new SqlParameter();
            ToDate.SqlDbType = SqlDbType.VarChar;
            ToDate.Value = txtToDate.Text;
            ToDate.ParameterName = "@ToDate";
            sqlcmd.Parameters.Add(ToDate);

            sqlda.Fill(ds);



            sqlcon.Close();


        }
        catch (Exception ex)
        {
            lblMessage.Visible = true;
            lblMessage.Text = ex.Message;
            lblMessage.CssClass = "ErrorMessage";

        }

        finally
        { 
        
        }
    }

    public DataSet ds2 = new DataSet();
    private void GetTotalCountForDate()
    {
        try
        {
            Object SaveUSERInfo = (Object)Session["UserInfo"];

            SqlConnection sqlcon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);

            sqlcon.Open();
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlcon;
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.CommandText = "GetTotalCountForDateNew";
            SqlDataAdapter sqlda = new SqlDataAdapter();
            sqlda.SelectCommand = sqlcmd;

            SqlParameter BranchID = new SqlParameter();
            BranchID.SqlDbType = SqlDbType.Int;
            BranchID.Value = Convert.ToInt32(((UserInfo.structUSERInfo)(SaveUSERInfo)).BranchId);
            BranchID.ParameterName = "@BranchID";
            sqlcmd.Parameters.Add(BranchID);

            SqlParameter FromDate = new SqlParameter();
            FromDate.SqlDbType = SqlDbType.VarChar;
            FromDate.Value = txtFromDate.Text;
            FromDate.ParameterName = "@FromDate";
            sqlcmd.Parameters.Add(FromDate);

            SqlParameter ToDate = new SqlParameter();
            ToDate.SqlDbType = SqlDbType.VarChar;
            ToDate.Value = txtToDate.Text;
            ToDate.ParameterName = "@ToDate";
            sqlcmd.Parameters.Add(ToDate);

            sqlda.Fill(ds2);
            //sqlcmd.ExecuteNonQuery();
            sqlcon.Close();

            //DaysCount = Convert.ToInt32(sqlcmd.Parameters["@VarResult"].Value);

            //if (DaysCount != 0)
            //{
            //    NonZeroCount++;
            //}

        }
        catch (Exception ex)
        {
            lblMessage.Visible = true;
            lblMessage.Text = ex.Message;
            lblMessage.CssClass = "ErrorMessage";

        }
        finally
        { 
        
        }
    }

    //private void GetDropBoxCountForDate()
    //{
    //    try
    //    {
    //        SqlConnection sqlcon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);

    //        sqlcon.Open();
    //        SqlCommand sqlcmd = new SqlCommand();
    //        sqlcmd.Connection = sqlcon;
    //        sqlcmd.CommandType = CommandType.StoredProcedure;
    //        sqlcmd.CommandText = "GetDropBoxCountForDate";
    //        //sqlcmd.CommandText = "GetDropBoxCountForDateNew";
    //        SqlDataAdapter sqlda = new SqlDataAdapter();
    //        sqlda.SelectCommand = sqlcmd;

    //        //OLD OLD OLD
    //        SqlParameter DropBoxID1 = new SqlParameter();
    //        DropBoxID1.SqlDbType = SqlDbType.Int;
    //        DropBoxID1.Value = DropBoxID;
    //        DropBoxID1.ParameterName = "@DropBoxID";
    //        sqlcmd.Parameters.Add(DropBoxID1);

    //        SqlParameter CurrDate = new SqlParameter();
    //        CurrDate.SqlDbType = SqlDbType.VarChar;
    //        CurrDate.Value = Get_DateFormat(datename, "MM/dd/yyyy");
    //        CurrDate.ParameterName = "@CurrDate";
    //        sqlcmd.Parameters.Add(CurrDate);

    //        SqlParameter VarResult = new SqlParameter();
    //        VarResult.SqlDbType = SqlDbType.VarChar;
    //        VarResult.Value = "";//
    //        VarResult.ParameterName = "@VarResult";
    //        VarResult.Size = 200;
    //        VarResult.Direction = ParameterDirection.Output;
    //        sqlcmd.Parameters.Add(VarResult);

    //        //NEW NEW NEW

    //        sqlcmd.ExecuteNonQuery();
    //        sqlcon.Close();

    //        Count = Convert.ToInt32(sqlcmd.Parameters["@VarResult"].Value);
    //        if (Count != 0)
    //        {
    //            NonZeroCount++;
    //        }

    //    }
    //    catch (Exception ex)
    //    {
    //        lblMessage.Visible = true;
    //        lblMessage.Text = ex.Message;
    //        lblMessage.CssClass = "ErrorMessage";

    //    }
    //}

private void Get_DateFiff()
{
 	try
        {
            SqlConnection sqlcon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);

            sqlcon.Open();
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlcon;
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.CommandText = "Get_DateDiff";
            SqlDataAdapter sqlda = new SqlDataAdapter();
            sqlda.SelectCommand = sqlcmd;

            SqlParameter FromDate = new SqlParameter();
            FromDate.SqlDbType = SqlDbType.VarChar;
            FromDate.Value =txtFromDate.Text;
            FromDate.ParameterName = "@FromDate";
            sqlcmd.Parameters.Add(FromDate);

            SqlParameter ToDate = new SqlParameter();
            ToDate.SqlDbType = SqlDbType.VarChar;
            ToDate.Value =txtToDate.Text;
            ToDate.ParameterName = "@ToDate";
            sqlcmd.Parameters.Add(ToDate);

            SqlParameter VarResult = new SqlParameter();
            VarResult.SqlDbType = SqlDbType.VarChar;
            VarResult.Value = "";//
            VarResult.ParameterName = "@VarResult";
            VarResult.Size = 200;
            VarResult.Direction = ParameterDirection.Output;
            sqlcmd.Parameters.Add(VarResult);

            sqlcmd.ExecuteNonQuery();
            sqlcon.Close();

            DateDiff = Convert.ToInt32(sqlcmd.Parameters["@VarResult"].Value);
        }
        catch (Exception ex)
        {
            lblMessage.Visible = true;
            lblMessage.Text = ex.Message;
            lblMessage.CssClass = "ErrorMessage";

        }
}

        protected void btnExport_Click(object sender, EventArgs e)
    {

        if (ddlClientList.SelectedIndex != 0)
        {
            if (txtFromDate.Text != "")
            {
                if (txtToDate.Text != "")
                {
                    if (btnExport.Text == "Export Text Report") 
                    {
                        Generate_TextFile();
                    }
                    else{
                    Generate_ExcelFile();
                    }
                }
                else
                {
                    lblMessage.Text = "Enter Deposit Date.";
                    lblMessage.CssClass = "ErrorMessage";
                }
            }
            else
            {
                lblMessage.Text = "Enter from Date.";
                lblMessage.CssClass = "ErrorMessage";
            }

        }
        else
        {
            lblMessage.Text = "Select One Client.";
            lblMessage.CssClass = "ErrorMessage";
        }
        
        //attachment = ddlBranch.SelectedItem.Text + "-" + "Invalid Cheques from " + txtFromDate.Text + " to " + txtToDate.Text+".xls";
        //lblMessage2.Text = attachment;
        
    }

    private void Generate_TextFile()
    {
        StringBuilder str = new StringBuilder();
        for (int i = 0; i < grvMISdata.Rows.Count; i++)
        {

            for (int j = 0; j < 1; j++)
            {

                str.Append(grvMISdata.Rows[i].Cells[0].Text + Environment.NewLine);

            }

          
        }
        Response.Clear();

        Response.AddHeader("content-disposition", "attachment;filename=TextReport.txt");

        Response.Charset = "";

        Response.Cache.SetCacheability(HttpCacheability.NoCache);

        Response.ContentType = "application/vnd.text";

        System.IO.StringWriter stringWrite = new System.IO.StringWriter();

        System.Web.UI.HtmlTextWriter htmlWrite = new HtmlTextWriter(stringWrite);

        Response.Write(str.ToString());

        Response.End();

       
    }

   

        private void Generate_ExcelFile()
    {

           
        string attachment="";
        if (ddlMIStype.SelectedIndex == 1)
        {
            attachment = "attachment; filename=DropBoxMIS.xls";
        }
        if (ddlMIStype.SelectedIndex == 2)
        {
            attachment = "attachment; filename=InvalidChqsMIS.xls";
        }
        else if (ddlMIStype.SelectedIndex == 3)
        {
            attachment = "attachment; filename=SuspenseChqsMIS.xls";
        }
        else if (ddlMIStype.SelectedIndex == 4)
        {
            attachment = "attachment; filename=ForeclosurChqsMIS.xls";
        }
        else if (ddlMIStype.SelectedIndex == 5)
        {
            attachment = "attachment; filename=OtherBankChqsMIS.xls";
        }
        else if (ddlMIStype.SelectedIndex == 6)
        {
             attachment = "attachment; filename=InwardBTChqsMIS.xls";
        }
        else if (ddlMIStype.SelectedIndex == 7)
        {
             attachment = "attachment; filename=ReturnChqsMIS.xls";
        }
        else if (ddlMIStype.SelectedIndex == 8)
        {
             attachment = "attachment; filename=UpcountryChqsMIS.xls";
        }
        else if (ddlMIStype.SelectedIndex == 9)
        {
            attachment = "attachment; filename=DailyChequeSummary.xls";
        }
        //String attachment = "attachment; filename=strFileName";

        //string style = @"<style> .text { mso-number-format:\@; } </style> "; 
        Response.ClearContent();

            //Response.AddHeader("content-disposition", "attachment; filename=strFileName");

        Response.AddHeader("content-disposition", attachment);
        Response.ContentType = "application/ms-excel";
        StringWriter sw = new System.IO.StringWriter();
        HtmlTextWriter htw = new HtmlTextWriter(sw);
        //Table tblSpace = new Table();
        //TableRow tblRow = new TableRow();
        //TableCell tblCell = new TableCell();
        //tblCell.Text = " ";

        //TableRow tblRow1 = new TableRow();
        //TableCell tblCell1 = new TableCell();
        //tblCell1.ColumnSpan = 20;// 10;
        //tblCell1.Text = "<b> <span style='background-color:Gray'> <font size='4'>PAMAC FINSERVE PVT. LTD., Branch-"+ddlBranch.SelectedItem.Text+" </font></span></b> <br/>" +
        //                "<b><font size='2' color='blue'>"+ lblReportHeader.Text + "  for Date " + txtFromDate.Text + " To " + txtToDate.Text + " </font></b> <br/>";
        //tblCell1.CssClass = "SuccessMessage";
        //tblRow.Cells.Add(tblCell);
        //tblRow1.Cells.Add(tblCell1);
        //tblRow.Height = 20;
        //tblSpace.Rows.Add(tblRow);
        //tblSpace.Rows.Add(tblRow1);

        string style = @"<style> TD { mso-number-format:\@; } </style> ";

        //Response.Write(style);

        //tblSpace.RenderControl(htw);

        //Table tbl = new Table();
        grvMISdata.EnableViewState = false;
        //grvMISdata.GridLines = GridLines.Both;
        //tbExport.RenderControl(htw);

        //foreach (GridViewRow r in grvMISdata.Rows)
        //{
        //    if (r.RowType == DataControlRowType.DataRow)
        //    {
        //        for (int columnIndex = 0; columnIndex < r.Cells.Count; columnIndex++)
        //        {
        //            r.Cells[columnIndex].Attributes.Add("class", "textmode");
        //        }
        //    }
        //} 


        grvMISdata.RenderControl(htw);
        Response.Write(style);
        Response.Write(sw.ToString());

        Response.End();
    }

        //private void GetFileName()
        //{
        //    attachment = ddlBranch.SelectedItem.Text + "-" + "Invalid Cheques from " + txtFromDate.Text + " to " + txtToDate.Text;
        //}

        public override void VerifyRenderingInServerForm(Control control)
        {

        }

        protected void grvMISdata_RowDataBound(object sender, GridViewRowEventArgs e)
        {

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Cells[1].Attributes.Add("class", "text");
            }
        }


    protected void ddlMISList_SelectedIndexChanged(object sender, EventArgs e)
    {
        grvMISdata.DataSource = null;
        grvMISdata.DataBind();
        
    }


    protected void ddlClientList_SelectedIndexChanged(object sender, EventArgs e)
    {
        lblMessage.Text = "";
        //lblMessage2.Text = "";
        grvMISdata.DataSource = null;
        grvMISdata.DataBind();
    }
}