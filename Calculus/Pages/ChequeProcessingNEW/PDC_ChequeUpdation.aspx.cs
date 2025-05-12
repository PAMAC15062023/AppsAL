using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.Globalization;
using System.IO;
using System.Drawing;


public partial class Pages_ChequeProcessingNEW_PDC_ChequeUpdation : System.Web.UI.Page
{
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

            txtPickupDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
            ddlClientList.Focus();
            //TextBox1_CalendarExtender.SelectedDate = DateTime.Now;
        }
        btnExport.Visible = false;
        lblMessage.Visible = false;

        Object SaveUSERInfo = (Object)Session["UserInfo"];
        lblLocation.Text = Convert.ToString(((UserInfo.structUSERInfo)(SaveUSERInfo)).BranchName);
        //ddlLocation.Focus();

    }

    private void Get_AllClientList()
    {
        try
        {
            SqlConnection sqlcon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);


            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlcon;
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.CommandText = "Get_AllClientList";
            sqlcmd.CommandTimeout = 0;




            SqlParameter Is_Active = new SqlParameter();
            Is_Active.SqlDbType = SqlDbType.Int;
            Is_Active.Value = 1;
            Is_Active.ParameterName = "@Is_Active";
            sqlcmd.Parameters.Add(Is_Active);


            sqlcon.Open();
            SqlDataAdapter sqlda = new SqlDataAdapter();
            sqlda.SelectCommand = sqlcmd;
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

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            if (ddlClientList.SelectedIndex == 0)
            {
                lblMessage.Visible = true;
                lblMessage.Text = "Select a Client...!!!!";
            }
            else
                if (txtPickupDate.Text == "")
                {
                    lblMessage.Visible = true;
                    lblMessage.Text = "Pickup Date Mandatory.";
                }
                else
                    if (txtDepDate.Text == "")
                    {
                        lblMessage.Visible = true;
                        lblMessage.Text = "Deposit Date Mandatory.";
                    }
                    else
                    {
                        Object SaveUSERInfo = (Object)Session["UserInfo"];
                        IFormatProvider culture = new CultureInfo("en-US", true);

                        ShowPDC();

                        SqlConnection sqlcon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);


                        SqlCommand sqlcmd = new SqlCommand();
                        sqlcmd.Connection = sqlcon;
                        sqlcmd.CommandType = CommandType.StoredProcedure;
                        sqlcmd.CommandText = "UpdatePDC_mod";
                        sqlcmd.CommandTimeout = 0;




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

                        SqlParameter PickupDate = new SqlParameter();
                        PickupDate.SqlDbType = SqlDbType.VarChar;
                        PickupDate.Value = txtPickupDate.Text.Trim();//DateTime.ParseExact(txtDepDate.Text.Trim() + 2013, "ddMMyyyy", CultureInfo.InvariantCulture);//
                        PickupDate.ParameterName = "@PickupDate";
                        sqlcmd.Parameters.Add(PickupDate);

                        SqlParameter DepositDate = new SqlParameter();
                        DepositDate.SqlDbType = SqlDbType.VarChar;
                        DepositDate.Value = txtDepDate.Text.Trim();//DateTime.ParseExact(txtDepDate.Text.Trim() + 2013, "ddMMyyyy", CultureInfo.InvariantCulture);//
                        DepositDate.ParameterName = "@DepositDate";
                        sqlcmd.Parameters.Add(DepositDate);

                        sqlcon.Open();
                        SqlDataAdapter sqlda = new SqlDataAdapter();
                        sqlda.SelectCommand = sqlcmd;
                        DataSet ds = new DataSet();
                        sqlda.Fill(ds);
                        sqlcon.Close();


                        if (ds.Tables.Count > 0)
                        {
                            lblMessage.Visible = true;
                            lblMessage.Text = ds.Tables[0].Rows[0]["msg"].ToString();
                            btnUpdate.Visible = false;
                            btnExport.Visible = true;

                        }
                        else
                        {
                            lblMessage.Visible = true;
                            lblMessage.Text = "No Record Found...!!!";
                        }
                    }
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

    protected void btnExit_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Pages/Menu.aspx", true);
    }


    protected void btnExport_Click(object sender, EventArgs e)
    {
        if (ddlClientList.SelectedIndex == 0)
        {
            lblMessage.Visible = true;
            lblMessage.Text = "Select a Client...!!!!";
        }
        else
            if (txtPickupDate.Text == "")
            {
                lblMessage.Visible = true;
                lblMessage.Text = "Pickup Date Mandatory.";
            }
            else
                if (txtDepDate.Text == "")
                {
                    lblMessage.Visible = true;
                    lblMessage.Text = "Deposit Date Mandatory.";
                }
                else
        {
            Object SaveUSERInfo = (Object)Session["UserInfo"];
            IFormatProvider culture = new CultureInfo("en-US", true);

            SqlConnection sqlcon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);

   
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlcon;
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.CommandText = "ShowPDC_mod";
            sqlcmd.CommandTimeout = 0;


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

            SqlParameter PickupDate = new SqlParameter();
            PickupDate.SqlDbType = SqlDbType.VarChar;
            PickupDate.Value = txtPickupDate.Text.Trim();
            PickupDate.ParameterName = "@PickupDate";
            sqlcmd.Parameters.Add(PickupDate);

            SqlParameter DepositDate = new SqlParameter();
            DepositDate.SqlDbType = SqlDbType.VarChar;
            DepositDate.Value = txtDepDate.Text.Trim();
            DepositDate.ParameterName = "@DepositDate";
            sqlcmd.Parameters.Add(DepositDate);



            sqlcon.Open();
  
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = sqlcmd;

            DataTable dt = new DataTable();
            da.Fill(dt);

            sqlcon.Close();

            DataGrid dg = new DataGrid();
            dg.DataSource = dt;
            dg.DataBind();
            ExportToExcel("PDCinfo.xls", dg);
            dg = null;
            dg.Dispose();

            //Generate_ExcelFile2();
        }
    }

    private void ExportToExcel(string strFileName, DataGrid dg)
    {
        Response.ClearContent();
        Response.AddHeader("content-disposition", "attachment; filename=" + strFileName);
        Response.ContentType = "application/excel";
        System.IO.StringWriter sw = new System.IO.StringWriter();
        HtmlTextWriter htw = new HtmlTextWriter(sw);
        dg.RenderControl(htw);
        Response.Write(sw.ToString());
        Response.End();
    }

    private void Generate_ExcelFile2()
    {
        Response.Clear();
        Response.AddHeader("content-disposition", "attachment;filename=PDCinfo.xls");
        Response.Charset = "";
        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        Response.ContentType = "application/ms-excel";

        System.IO.StringWriter stringWrite = new System.IO.StringWriter();
        System.Web.UI.HtmlTextWriter htmlWrite = new HtmlTextWriter(stringWrite);

        grvPDCinfo.RenderControl(htmlWrite);
        Response.Write(stringWrite.ToString());
        Response.End();
    }

    private void Generate_ExcelFile()
    {
        String attachment = "attachment; filename=PDCinfo.xls";
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
        tblCell1.ColumnSpan = 10;// 20;// 10;
        tblCell1.Text = "<b> <span style='background-color:Gray'> <font size='4'>PAMAC FINSERVE PVT. LTD., Branch</b> <br/>";
        tblCell1.CssClass = "SuccessMessage";
        tblRow.Cells.Add(tblCell);
        tblRow1.Cells.Add(tblCell1);
        tblRow.Height = 20;
        tblSpace.Rows.Add(tblRow);
        tblSpace.Rows.Add(tblRow1);
        tblSpace.RenderControl(htw);

        Table tbl = new Table();
        grvPDCinfo.EnableViewState = false;
        grvPDCinfo.GridLines = GridLines.Both;
        grvPDCinfo.RenderControl(htw);
        Response.Write(sw.ToString());

        Response.End();
    }

    public override void VerifyRenderingInServerForm(Control control)
    {

    }

    protected void btnShowPDC_Click(object sender, EventArgs e)
    {
        if (ddlClientList.SelectedIndex == 0)
        {
            lblMessage.Visible = true;
            lblMessage.Text = "Select a Client...!!!!";
        }
        else
            if (txtPickupDate.Text == "")
            {
                lblMessage.Visible = true;
                lblMessage.Text = "Pickup Date Mandatory.";
            }
            else
                if (txtDepDate.Text == "")
                {
                    lblMessage.Visible = true;
                    lblMessage.Text = "Deposit Date Mandatory.";
                }
                else
              
                {
                     ShowPDC();
                }
        grvPDCinfo.Visible = true;
        //btnUpdate.Visible = true;
    }

    private void ShowPDC()
    {
        if (ddlClientList.SelectedIndex == 0)
        {
            lblMessage.Visible = true;
            lblMessage.Text = "Select a Client...!!!!";
        }
        else
        {
            Object SaveUSERInfo = (Object)Session["UserInfo"];
            //IFormatProvider culture = new CultureInfo("en-US", true);

            SqlConnection sqlcon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);

   
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlcon;
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.CommandText = "ShowPDC_mod";
            sqlcmd.CommandTimeout = 0;

         

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

            SqlParameter PickupDate = new SqlParameter();
            PickupDate.SqlDbType = SqlDbType.VarChar;
            PickupDate.Value = txtPickupDate.Text.Trim();
            PickupDate.ParameterName = "@PickupDate";
            sqlcmd.Parameters.Add(PickupDate);

            SqlParameter DepositDate = new SqlParameter();
            DepositDate.SqlDbType = SqlDbType.VarChar;
            DepositDate.Value = txtDepDate.Text.Trim();
            DepositDate.ParameterName = "@DepositDate";
            sqlcmd.Parameters.Add(DepositDate);


            sqlcon.Open();
   

            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = sqlcmd;

            DataTable dt = new DataTable();
            da.Fill(dt);

            grvPDCinfo.DataSource = dt;
            grvPDCinfo.DataBind();

            sqlcon.Close();

            if (dt.Rows.Count > 0)
            {
                btnUpdate.Visible = true;
                btnExport.Visible = true;

            }
            else
            {
                lblMessage.Visible = true;
                lblMessage.Text = "No Record Found...!!!";
            }
        }
    }
}