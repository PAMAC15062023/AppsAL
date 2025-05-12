using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;

public partial class Pages_Helpdesk_Report : System.Web.UI.Page
{
    string proc;
    protected void Page_Load(object sender, EventArgs e)
    {
        Label1.Visible = false;
        if (!IsPostBack)
        {
            BindStatus();
            getlocation();
        }
    }
    protected void BindStatus()
    {
        SqlConnection sqlCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);

        SqlCommand cmd = new SqlCommand("HelpDesk_SearchCodeMaster_SP", sqlCon);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@Types", "HDTicketStatusType");
        cmd.Parameters.AddWithValue("@Level", 1);
        SqlDataAdapter adp = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        adp.Fill(ds);

        if (ds != null && ds.Tables[0].Rows.Count > 0)
        {
            ddlstatus.DataSource = ds;
            ddlstatus.DataValueField = "Code_Id";
            ddlstatus.DataTextField = "Description";
            ddlstatus.DataBind();
            ddlstatus.Items.Insert(0, new ListItem("--All--", "0")); //Select
        }

    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Pages/Menu.aspx", true);
    }

    public string strDate(string strInDate)
    {
         string strDD = strInDate.Substring(0, 2);

        string strMM = strInDate.Substring(3, 2);

        string strYYYY = strInDate.Substring(6, 4);

        string strMMDDYYYY = strMM + "/" + strDD + "/" + strYYYY;

        //string strDDMMYYYY = strDD + "/" + strMM + "/" + strYYYY;

        //DateTime dtConvertDate = Convert.ToDateTime(strMMDDYYYY);

        DateTime dtConvertDate = Convert.ToDateTime(strMMDDYYYY);

        string strOutDate = dtConvertDate.ToString("dd-MMM-yyyy");

        return strOutDate;
    }


    public void getlocation()
    {
        try
        {

            Object SaveUSERInfo = (Object)Session["UserInfo"];
            SqlConnection sqlCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);

            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlCon;
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.CommandText = "sp_getbranch";



            SqlDataAdapter sda = new SqlDataAdapter();
            sda.SelectCommand = sqlcmd;

            sqlCon.Open();

            DataSet MyDs = new DataSet();
            sda.Fill(MyDs);

            sqlCon.Close();



            ddlbranch.DataTextField = "branchname";
            ddlbranch.DataValueField = "branchid";

            ddlbranch.DataSource = MyDs;
            ddlbranch.DataBind();
            ddlbranch.Items.Insert(0, new ListItem("--All--", "0"));

        }
        catch
        {
        }
    }

    protected void btnsearch_Click(object sender, EventArgs e)
    {

        lblMessage.Text = "";

        if (ddlResportType.SelectedItem.Text.Trim() != "--Select--")
        {
            if ((txtFromDate.Text != "") && (txtToDate.Text != ""))
            {
                if (ddlResportType.SelectedItem.Text.Trim() == "Reports")
                {
                    searchTAT();
                }
                else if (ddlResportType.SelectedItem.Text.Trim() == "TicketHistory")
                {
                    GetTicketHistory();
                }
            }
            else
            {
                GridView2.DataSource = null;
                GridView2.DataBind();
                lblMessage.Text = "Please select date ...!";
                return;
            }
        }
        else
        {
            GridView2.DataSource = null;
            GridView2.DataBind();
            lblMessage.Text = "Please select Select Resport Type first...!";
            return;
        }
    }

    public void searchTAT()
    {

        try
        {
            // if (ddlstatus.SelectedValue.ToString().Trim() == "Hold")
            // {
            // proc = "HelpDesk_Hold_New_STP_TATM_SP";

            // }
            // else if (ddlstatus.SelectedValue.ToString().Trim() == "Close")
            // {
            // proc = "HelpDesk_Close_New_STP_TATM_SP";

            // }
            // else
            // {
            // Label1.Visible = true;
            // Label1.Text = "Please select status first";
            // GridView2.DataSource = null;
            // GridView2.DataBind();
            // return;
            // }

            //if(ddlstatus.SelectedIndex != 0) //comment by Rutu 07/11/23
            {

                Object SaveUSERInfo = (Object)Session["UserInfo"];
                SqlConnection sqlCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);

                SqlCommand sqlcmd = new SqlCommand();
                sqlcmd.Connection = sqlCon;
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.CommandText = proc;
                sqlcmd.CommandText = "stp_TATMisNewhelpdesk";

                SqlDataAdapter sda = new SqlDataAdapter();
                sda.SelectCommand = sqlcmd;

                SqlParameter frmdate = new SqlParameter();
                frmdate.SqlDbType = SqlDbType.VarChar;
                frmdate.Value = strDate(txtFromDate.Text.Trim());
                frmdate.ParameterName = "@FromDate";
                sqlcmd.Parameters.Add(frmdate);

                SqlParameter todate1 = new SqlParameter();
                todate1.SqlDbType = SqlDbType.VarChar;
                todate1.Value = strDate(txtToDate.Text.Trim());
                todate1.ParameterName = "@Todate";
                sqlcmd.Parameters.Add(todate1);

                SqlParameter branchid = new SqlParameter();
                branchid.SqlDbType = SqlDbType.VarChar;
                branchid.Value = ddlbranch.SelectedValue.ToString();
                branchid.ParameterName = "@Branchid";
                sqlcmd.Parameters.Add(branchid);

                SqlParameter status = new SqlParameter();
                status.SqlDbType = SqlDbType.VarChar;
                status.Value = ddlstatus.SelectedValue.ToString().Trim();
                status.ParameterName = "@status";
                sqlcmd.Parameters.Add(status);

                sqlCon.Open();
                DataSet mhds = new DataSet();
                sda.Fill(mhds);
                if (mhds.Tables[0].Rows.Count > 0)
                {
                    GridView2.DataSource = mhds;
                    GridView2.DataBind();
                }
                else
                {
                    GridView2.DataSource = null;
                    GridView2.DataBind();
                }
                sqlCon.Close();
            }
        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
        }
    }
    public void Searchdata()
    {
        try
        {
            Object SaveUSERInfo = (Object)Session["UserInfo"];
            SqlConnection sqlCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);

            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlCon;
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.CommandText = "HelpDesk_GetRecord_SP";

            SqlDataAdapter sda = new SqlDataAdapter();
            sda.SelectCommand = sqlcmd;


            SqlParameter status = new SqlParameter();
            status.SqlDbType = SqlDbType.NVarChar;
            status.Value = ddlstatus.SelectedValue.ToString();
            status.ParameterName = "@ticketstatus";
            sqlcmd.Parameters.Add(status);

            SqlParameter Branch_name = new SqlParameter();
            Branch_name.SqlDbType = SqlDbType.NVarChar;
            Branch_name.Value = ddlbranch.SelectedValue.ToString();
            Branch_name.ParameterName = "@branchid";
            sqlcmd.Parameters.Add(Branch_name);



            DataSet MyDs = new DataSet();
            sda.Fill(MyDs);


            GridView1.DataSource = MyDs;
            GridView1.DataBind();




        }
        catch
        {

        }
    }

    private void Generate_ExcelFile()
    {
        String attachment = "attachment; filename=Report.xls";
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
                                 //tblCell1.Text = "<b><font size='3' color='blue'>PAMAC FINSERVE PVT. LTD., Branch-" + ddlBranchList.SelectedItem.Text + " </font></span></b> <br/>" +
                                 //                "<b><font size='2' color='blue'>" + lblReportHeader.Text + "  From" + txtFromDate.Text + " To " + txtToDate.Text + " </font></b> <br/>";
        tblCell1.CssClass = "SuccessMessage";
        tblRow.Cells.Add(tblCell);
        tblRow1.Cells.Add(tblCell1);
        tblRow.Height = 20;
        tblSpace.Rows.Add(tblRow);
        tblSpace.Rows.Add(tblRow1);
        tblSpace.RenderControl(htw);

        Table tbl = new Table();
        GridView2.EnableViewState = false;
        GridView2.GridLines = GridLines.Both;
        GridView2.RenderControl(htw);

        string style = @"<style> TD { mso-number-format:\@; } </style> ";
        Response.Write(style);

        Response.Write(sw.ToString());

        Response.End();
    }


    public override void VerifyRenderingInServerForm(Control control)
    {

    }

    protected void btnExporttoExcel_Click(object sender, EventArgs e)
    {
        Generate_ExcelFile();
    }
    public void GetTicketHistory()
    {

        try
        {

            Object SaveUSERInfo = (Object)Session["UserInfo"];
            SqlConnection sqlCon = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);

            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlCon;
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.CommandText = proc;
            sqlcmd.CommandText = "SP_helpdesk_GetTicket_History";

            SqlDataAdapter sda = new SqlDataAdapter();
            sda.SelectCommand = sqlcmd;

            SqlParameter frmdate = new SqlParameter();
            frmdate.SqlDbType = SqlDbType.VarChar;
            frmdate.Value = strDate(txtFromDate.Text.Trim());
            frmdate.ParameterName = "@FromDate";
            sqlcmd.Parameters.Add(frmdate);

            SqlParameter todate1 = new SqlParameter();
            todate1.SqlDbType = SqlDbType.VarChar;
            todate1.Value = strDate(txtToDate.Text.Trim());
            todate1.ParameterName = "@Todate";
            sqlcmd.Parameters.Add(todate1);

            SqlParameter branchid = new SqlParameter();
            branchid.SqlDbType = SqlDbType.VarChar;
            branchid.Value = ddlbranch.SelectedValue.ToString();
            branchid.ParameterName = "@Branchid";
            sqlcmd.Parameters.Add(branchid);

            SqlParameter status = new SqlParameter();
            status.SqlDbType = SqlDbType.VarChar;
            status.Value = ddlstatus.SelectedValue.ToString().Trim();
            status.ParameterName = "@status";
            sqlcmd.Parameters.Add(status);

            sqlCon.Open();
            DataSet mhds = new DataSet();
            sda.Fill(mhds);
            if (mhds.Tables[0].Rows.Count > 0)
            {
                GridView2.DataSource = mhds;
                GridView2.DataBind();
            }
            else
            {
                GridView2.DataSource = null;
                GridView2.DataBind();
            }
            sqlCon.Close();
        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
        }
    }
}