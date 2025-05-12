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
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserInfo"] == null)
        {
            Response.Redirect("~/Pages/InvalidRequest.aspx");
        }

        if (!IsPostBack)
        {

            Get_vender_name();//vender name drodownlist
            pnlcat.Visible = true;
            pnlSearchMaster.Visible = false;
            pnlData.Visible = false;
           
        }
    }
    //protected void btnCancel_Click(object sender, EventArgs e)
    //{
    //    Response.Redirect("~/Pages/Menu.aspx", true);
    //}

    //public void getlocation()
    //{
    //    try
    //    {

    //        Object SaveUSERInfo = (Object)Session["UserInfo"];
    //        SqlConnection sqlCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);

    //        SqlCommand sqlcmd = new SqlCommand();
    //        sqlcmd.Connection = sqlCon;
    //        sqlcmd.CommandType = CommandType.StoredProcedure;
    //        sqlcmd.CommandText = "sp_getbranch";



    //        SqlDataAdapter sda = new SqlDataAdapter();
    //        sda.SelectCommand = sqlcmd;

    //        sqlCon.Open();

    //        DataSet MyDs = new DataSet();
    //        sda.Fill(MyDs);

    //        sqlCon.Close();



    //        ddlbranch.DataTextField = "branchname";
    //        ddlbranch.DataValueField = "branchid";

    //        ddlbranch.DataSource = MyDs;
    //        ddlbranch.DataBind();
    //        ddlbranch.Items.Insert(0, new ListItem("--All--", "0"));

    //    }
    //    catch
    //    {
    //    }
    //}

    //protected void btnsearch_Click(object sender, EventArgs e)
    //{
    //    Searchdata();
    //}

    //public void Searchdata()
    //{
    //    try
    //    {
    //        Object SaveUSERInfo = (Object)Session["UserInfo"];
    //        SqlConnection sqlCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);

    //        SqlCommand sqlcmd = new SqlCommand();
    //        sqlcmd.Connection = sqlCon;
    //        sqlcmd.CommandType = CommandType.StoredProcedure;
    //        sqlcmd.CommandText = "sp_getRecord_helpdesk12";

    //        SqlDataAdapter sda = new SqlDataAdapter();
    //        sda.SelectCommand = sqlcmd;


    //        SqlParameter status = new SqlParameter();
    //        status.SqlDbType = SqlDbType.NVarChar;
    //        status.Value = ddlstatus.SelectedValue.ToString();
    //        status.ParameterName = "@ticketstatus";
    //        sqlcmd.Parameters.Add(status);

    //        SqlParameter Branch_name = new SqlParameter();
    //        Branch_name.SqlDbType = SqlDbType.NVarChar;
    //        Branch_name.Value = ddlbranch.SelectedValue.ToString();
    //        Branch_name.ParameterName = "@branchid";
    //        sqlcmd.Parameters.Add(Branch_name);



    //        DataSet MyDs = new DataSet();
    //        sda.Fill(MyDs);


    //        GridView1.DataSource = MyDs;
    //        GridView1.DataBind();




    //    }
    //    catch
    //    {

    //    }
    //}

    //private void Generate_ExcelFile()
    //{
    //    String attachment = "attachment; filename=Report.xls";
    //    Response.AddHeader("content-disposition", attachment);
    //    Response.ContentType = "application/ms-excel";
    //    StringWriter sw = new System.IO.StringWriter();
    //    HtmlTextWriter htw = new HtmlTextWriter(sw);
    //    Table tblSpace = new Table();
    //    TableRow tblRow = new TableRow();
    //    TableCell tblCell = new TableCell();
    //    tblCell.Text = " ";

    //    TableRow tblRow1 = new TableRow();
    //    TableCell tblCell1 = new TableCell();
    //    tblCell1.ColumnSpan = 20;// 10;
    //    //tblCell1.Text = "<b><font size='3' color='blue'>PAMAC FINSERVE PVT. LTD., Branch-" + ddlBranchList.SelectedItem.Text + " </font></span></b> <br/>" +
    //    //                "<b><font size='2' color='blue'>" + lblReportHeader.Text + "  From" + txtFromDate.Text + " To " + txtToDate.Text + " </font></b> <br/>";
    //    tblCell1.CssClass = "SuccessMessage";
    //    tblRow.Cells.Add(tblCell);
    //    tblRow1.Cells.Add(tblCell1);
    //    tblRow.Height = 20;
    //    tblSpace.Rows.Add(tblRow);
    //    tblSpace.Rows.Add(tblRow1);
    //    tblSpace.RenderControl(htw);

    //    Table tbl = new Table();
    //    GridView1.EnableViewState = false;
    //    GridView1.GridLines = GridLines.Both;
    //    GridView1.RenderControl(htw);

    //    string style = @"<style> TD { mso-number-format:\@; } </style> ";
    //    Response.Write(style);

    //    Response.Write(sw.ToString());

    //    Response.End();
    //}


    //public override void VerifyRenderingInServerForm(Control control)
    //{

    //}

    //protected void btnExporttoExcel_Click(object sender, EventArgs e)
    //{
    //    Generate_ExcelFile();
    //}




    private void Get_vender_name()
    {
        try
        {
            SqlConnection sqlCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);

            sqlCon.Open();
            SqlCommand sqlCom = new SqlCommand();
            sqlCom.Connection = sqlCon;
            sqlCom.CommandType = CommandType.StoredProcedure;
            sqlCom.CommandText = "Get_vender_type";
            SqlDataAdapter sqlDA = new SqlDataAdapter();
            sqlDA.SelectCommand = sqlCom;

            DataTable dt = new DataTable();
            sqlDA.Fill(dt);
            sqlCon.Close();

            ddlvendersearch.DataTextField = "vender_name";
            ddlvendersearch.DataValueField = "vender_id";
            ddlvendersearch.DataSource = dt;
            ddlvendersearch.DataBind();

            ddlvendersearch.Items.Insert(0, "--Select--");
            ddlvendersearch.SelectedIndex = 0;
        }
        catch (Exception ex)
        {
            Label1.Visible = true;
            Label1.Text = ex.Message;
            Label1.CssClass = "ErrorMessage";
        }
    }
    //protected void search_Click(object sender, EventArgs e)
    //{
    //    try
    //    {
    //        SqlConnection sqlCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);

    //        sqlCon.Open();
    //        SqlCommand sqlCom = new SqlCommand();
    //        sqlCom.Connection = sqlCon;
    //        sqlCom.CommandType = CommandType.StoredProcedure;
    //        sqlCom.CommandText = "show_particular_txt";
    //        SqlDataAdapter sqlDA = new SqlDataAdapter();
    //        sqlDA.SelectCommand = sqlCom;

    //        int intProblemType = Convert.ToInt32(ddlvendersearch.SelectedItem.Value);

    //        SqlParameter ProblemTypeID = new SqlParameter();
    //        ProblemTypeID.SqlDbType = SqlDbType.Int;
    //        ProblemTypeID.Value = intProblemType;
    //        ProblemTypeID.ParameterName = "@venderID";
    //        sqlCom.Parameters.Add(ProblemTypeID);

    //        SqlDataAdapter da = new SqlDataAdapter();
    //        da.SelectCommand = sqlCom;

    //        DataTable dt = new DataTable();
    //        da.Fill(dt);

    //        //string Emailid = "software.support@pamac.com";
    //        //string CCEmailid = "edp@pamac.com";
    //        txtvender.Text = dt.Rows[0]["vender_name"].ToString();
    //        txtprovider.Text = dt.Rows[0]["vender_prob_provider"].ToString();
    //        txtservices.Text = dt.Rows[0]["vender_services"].ToString();

    //        sqlCon.Close();
    //    }
    //    catch (Exception ex)
    //    {
    //        Label1.Visible = true;
    //        Label1.Text = ex.Message;
    //        Label1.CssClass = "ErrorMessage";
    //    }
    //}



    //protected void btnupdate_Click(object sender, EventArgs e)
    //{
    //    try
    //    {
    //        SqlConnection sqlCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);

    //        sqlCon.Open();
    //        SqlCommand sqlCom = new SqlCommand();
    //        sqlCom.Connection = sqlCon;
    //        sqlCom.CommandType = CommandType.StoredProcedure;
    //        sqlCom.CommandText = "update_H_TicketInfo_new";
    //        SqlDataAdapter sqlDA = new SqlDataAdapter();
    //        sqlDA.SelectCommand = sqlCom;

    //        int venderID = Convert.ToInt32(ddlvendersearch.SelectedItem.Value);

    //        SqlParameter vender_id = new SqlParameter();
    //        vender_id.SqlDbType = SqlDbType.Int;
    //        vender_id.Value = venderID;
    //        vender_id.ParameterName = "@vender_id";
    //        sqlCom.Parameters.Add(vender_id);


    //         SqlParameter vender_name = new SqlParameter();
    //         vender_name.SqlDbType = SqlDbType.VarChar;
    //         vender_name.Value = txtvender.Text;
    //         vender_name.ParameterName = "@vender_name";
    //         sqlCom.Parameters.Add(vender_name);

    //        SqlParameter vender_provider = new SqlParameter();
    //        vender_provider.SqlDbType = SqlDbType.VarChar;
    //        vender_provider.Value = txtprovider.Text;
    //        vender_provider.ParameterName = "@vender_prob_provider";
    //        sqlCom.Parameters.Add(vender_provider);

    //        SqlParameter vender_service = new SqlParameter();
    //        vender_service.SqlDbType = SqlDbType.VarChar;
    //        vender_service.Value = txtservices.Text;
    //        vender_service.ParameterName = "@vender_services";
    //        sqlCom.Parameters.Add(vender_service);

    //        sqlCom.ExecuteNonQuery();

    //        Label1.Text = "data update successfully";
    //        sqlCon.Close();
    //        clearcon();

    //    }
    //    catch (Exception ex)
    //    {
    //        Label1.Visible = true;
    //        Label1.Text = ex.Message;
    //        Label1.CssClass = "ErrorMessage";
    //    }
    //}
    //protected void btncle_Click(object sender, EventArgs e)
    //{
    //    Response.Redirect("~/Pages/Menu.aspx", true);
    //}
    //protected void btnadd_Click(object sender, EventArgs e)
    //{
    //    try
    //    {
    //        SqlConnection sqlCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);

    //        sqlCon.Open();
    //        SqlCommand sqlCom = new SqlCommand();
    //        sqlCom.Connection = sqlCon;
    //        sqlCom.CommandType = CommandType.StoredProcedure;
    //        sqlCom.CommandText = "insert_vender_master";
    //        SqlDataAdapter sqlDA = new SqlDataAdapter();
    //        sqlDA.SelectCommand = sqlCom;




    //        SqlParameter vender_name = new SqlParameter();
    //        vender_name.SqlDbType = SqlDbType.VarChar;
    //        vender_name.Value = txtvender.Text;
    //        vender_name.ParameterName = "@vender_name";
    //        sqlCom.Parameters.Add(vender_name);

    //        SqlParameter vender_provider = new SqlParameter();
    //        vender_provider.SqlDbType = SqlDbType.VarChar;
    //        vender_provider.Value = txtprovider.Text;
    //        vender_provider.ParameterName = "@vender_prob_provider";
    //        sqlCom.Parameters.Add(vender_provider);

    //        SqlParameter vender_service = new SqlParameter();
    //        vender_service.SqlDbType = SqlDbType.VarChar;
    //        vender_service.Value = txtservices.Text;
    //        vender_service.ParameterName = "@vender_services";
    //        sqlCom.Parameters.Add(vender_service);

    //        sqlCom.ExecuteNonQuery();

    //        Label1.Text = "data insert successfully";
    //        sqlCon.Close();
    //        clearcon();

    //    }
    //    catch (Exception ex)
    //    {
    //        Label1.Visible = true;
    //        Label1.Text = ex.Message;
    //        Label1.CssClass = "ErrorMessage";
    //    }
    //}

    protected void ddlvendersearch_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlvendersearch.SelectedIndex != 0)
        {
            int intProblemType = Convert.ToInt32(ddlvendersearch.SelectedItem.Value);
        }
    }
    protected void search_Click1(object sender, EventArgs e)
    {
        try
        {
            SqlConnection sqlCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);

            sqlCon.Open();
            SqlCommand sqlCom = new SqlCommand();
            sqlCom.Connection = sqlCon;
            sqlCom.CommandType = CommandType.StoredProcedure;
            sqlCom.CommandText = "show_particular_txt";
            SqlDataAdapter sqlDA = new SqlDataAdapter();
            sqlDA.SelectCommand = sqlCom;

            int intProblemType = Convert.ToInt32(ddlvendersearch.SelectedItem.Value);

            SqlParameter ProblemTypeID = new SqlParameter();
            ProblemTypeID.SqlDbType = SqlDbType.Int;
            ProblemTypeID.Value = intProblemType;
            ProblemTypeID.ParameterName = "@venderID";
            sqlCom.Parameters.Add(ProblemTypeID);


            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = sqlCom;


            DataTable dt = new DataTable();
            da.Fill(dt);


            if (dt.Rows.Count > 0)
            {
                GridSearchMaster.DataSource = dt;
                GridSearchMaster.DataBind();

                pnlSearchMaster.Visible = true;
            }
            else if (ddlvendersearch.SelectedIndex == 0)
            {
             

                GridSearchMaster.DataSource = null;
                GridSearchMaster.DataBind();
                pnlData.Visible = true;
                BtnUpdate.Visible = false;
            }
            else
            {
                Label1.Text = "Records Not Found in BIS...!!!";
                GridSearchMaster.DataSource = null;
                GridSearchMaster.DataBind();
            }
            sqlCon.Close();
        }


        catch (Exception ex)
        {
            Label1.Visible = true;
            Label1.Text = ex.Message;
            Label1.CssClass = "ErrorMessage";
        }
    }

    protected void BtnReset_Click(object sender, EventArgs e)
    {
        resettxt();
    }

    public void resettxt()
    {
       
        txtName.Text = "";
        txtPro.Text = "";
        txtServices.Text = "";
        ddlvendersearch.SelectedIndex = 0;
        GridSearchMaster.Visible = false;
    }
    protected void BtnCancle_Click1(object sender, EventArgs e)
    {
        Response.Redirect("~/Pages/Menu.aspx", true);
    }
    protected void BtnAdd_Click(object sender, EventArgs e)
    {
        try
        {
            SqlConnection sqlCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);

            sqlCon.Open();
            SqlCommand sqlCom = new SqlCommand();
            sqlCom.Connection = sqlCon;
            sqlCom.CommandType = CommandType.StoredProcedure;
            sqlCom.CommandText = "insert_vender_master";
            SqlDataAdapter sqlDA = new SqlDataAdapter();
            sqlDA.SelectCommand = sqlCom;




            SqlParameter vender_name = new SqlParameter();
            vender_name.SqlDbType = SqlDbType.VarChar;
            vender_name.Value = txtName.Text;
            vender_name.ParameterName = "@vender_name";
            sqlCom.Parameters.Add(vender_name);

            SqlParameter vender_provider = new SqlParameter();
            vender_provider.SqlDbType = SqlDbType.VarChar;
            vender_provider.Value = txtPro.Text;
            vender_provider.ParameterName = "@vender_prob_provider";
            sqlCom.Parameters.Add(vender_provider);

            SqlParameter vender_service = new SqlParameter();
            vender_service.SqlDbType = SqlDbType.VarChar;
            vender_service.Value = txtServices.Text;
            vender_service.ParameterName = "@vender_services";
            sqlCom.Parameters.Add(vender_service);

            sqlCom.ExecuteNonQuery();

            Label1.Text = "data insert successfully";
            sqlCon.Close();
            txtName.Text = "";
            txtPro.Text = "";
            txtServices.Text = "";
            ddlvendersearch.SelectedIndex = 0;
        }
        catch (Exception ex)
        {
            Label1.Visible = true;
            Label1.Text = ex.Message;
            Label1.CssClass = "ErrorMessage";
        }
    }
    protected void GridSearchMaster_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {

            for (int i = 0; i < GridSearchMaster.Rows.Count; i++)
            {
                String strUID = "";
                strUID = e.CommandArgument.ToString();
                HiddenField1.Value = GridSearchMaster.Rows[i].Cells[0].Text.Trim();



                if (HiddenField1.Value == strUID)
                {

                    txtName.Text = GridSearchMaster.Rows[i].Cells[1].Text.Trim();
                    txtPro.Text = GridSearchMaster.Rows[i].Cells[2].Text.Trim();
                    txtServices.Text = GridSearchMaster.Rows[i].Cells[3].Text.Trim();
                    HiddenField2.Value = HiddenField1.Value;
                }
            }

            pnlData.Visible = true;
           
            Label1.Visible = true;

        }
        catch (SqlException sqlex)
        {

            Label1.Text = sqlex.Message.ToString();
        }
        catch (SystemException ex)
        {
            Label1.Text = ex.Message.ToString();
        }
    }
    protected void BtnUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            SqlConnection sqlCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);

            sqlCon.Open();
            SqlCommand sqlCom = new SqlCommand();
            sqlCom.Connection = sqlCon;
            sqlCom.CommandType = CommandType.StoredProcedure;
            sqlCom.CommandText = "update_H_TicketInfo_new";
            SqlDataAdapter sqlDA = new SqlDataAdapter();
            sqlDA.SelectCommand = sqlCom;

            int venderID = Convert.ToInt32(ddlvendersearch.SelectedItem.Value);

            SqlParameter vender_id = new SqlParameter();
            vender_id.SqlDbType = SqlDbType.Int;
            vender_id.Value = venderID;
            vender_id.ParameterName = "@vender_id";
            sqlCom.Parameters.Add(vender_id);


            SqlParameter vender_name = new SqlParameter();
            vender_name.SqlDbType = SqlDbType.VarChar;
            vender_name.Value = txtName.Text;
            vender_name.ParameterName = "@vender_name";
            sqlCom.Parameters.Add(vender_name);

            SqlParameter vender_provider = new SqlParameter();
            vender_provider.SqlDbType = SqlDbType.VarChar;
            vender_provider.Value = txtPro.Text;
            vender_provider.ParameterName = "@vender_prob_provider";
            sqlCom.Parameters.Add(vender_provider);

            SqlParameter vender_service = new SqlParameter();
            vender_service.SqlDbType = SqlDbType.VarChar;
            vender_service.Value = txtServices.Text;
            vender_service.ParameterName = "@vender_services";
            sqlCom.Parameters.Add(vender_service);

            sqlCom.ExecuteNonQuery();

            Label1.Text = "data update successfully";
            sqlCon.Close();
            txtName.Text = "";
            txtPro.Text = "";
            txtServices.Text = "";
           


        }
        catch (Exception ex)
        {
            Label1.Visible = true;
            Label1.Text = ex.Message;
            Label1.CssClass = "ErrorMessage";
        }
    }
    protected void ddlselectedcat_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlselectedcat.SelectedIndex == 0)
        {
            Label1.Visible = false;
            pnlcat.Visible = true;
            pnlSearchMaster.Visible = false;
            pnlData.Visible = false;
        }

        if (ddlselectedcat.SelectedIndex == 1)
        {
            pnlcat.Visible = false;
            pnlSearchMaster.Visible = true;
            pnlData.Visible = true;
            BtnUpdate.Visible = false;
        }
        if (ddlselectedcat.SelectedIndex == 2)
        {
            pnlcat.Visible = false;
            pnlSearchMaster.Visible = true;
            pnlData.Visible = false;
            BtnAdd.Visible = false;
        }

    }
    protected void GridSearchMaster_RowEditing(object sender, GridViewEditEventArgs e)
    {
        GridSearchMaster.PageIndex = e.NewEditIndex;
    }
}
