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
using System.Text;

public partial class Pages_ChequeProcessingNEW_ADI_FileGeneration : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserInfo"] == null)
        {
            Response.Redirect("~/Pages/InvalidRequest.aspx");
        }
        if (!IsPostBack)
        {
            Get_AllBranchList_For_Auth();
            //Get_AllClientList();
            txtPickupDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
            btnExport.Visible = false;
            Object SaveUSERInfo = (Object)Session["UserInfo"];
            if (((UserInfo.structUSERInfo)(SaveUSERInfo)).GroupName.Contains("Admin"))
            {
                ddlBranchList.Enabled = true;
            }
            else
            {
                ddlBranchList.SelectedValue = Convert.ToString(((UserInfo.structUSERInfo)(SaveUSERInfo)).BranchId);
                ddlBranchList.Enabled = false;
            }
            
        }
    }

    //private void Get_AllClientList()
    //{

    //    try
    //    {
    //        SqlConnection sqlcon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);

    //        sqlcon.Open();
    //        SqlCommand sqlcmd = new SqlCommand();
    //        sqlcmd.Connection = sqlcon;
    //        sqlcmd.CommandType = CommandType.StoredProcedure;
    //        sqlcmd.CommandText = "Get_AllClientList";
    //        SqlDataAdapter sqlda = new SqlDataAdapter();
    //        sqlda.SelectCommand = sqlcmd;

    //        SqlParameter Is_Active = new SqlParameter();
    //        Is_Active.SqlDbType = SqlDbType.Int;
    //        Is_Active.Value = 1;
    //        Is_Active.ParameterName = "@Is_Active";
    //        sqlcmd.Parameters.Add(Is_Active);

    //        DataTable dt = new DataTable();
    //        sqlda.Fill(dt);
    //        sqlcon.Close();

    //        ddlClientList.DataTextField = "ClientName";
    //        ddlClientList.DataValueField = "ClientID";
    //        ddlClientList.DataSource = dt;
    //        ddlClientList.DataBind();

    //        ddlClientList.Items.Insert(0, "-Select-");
    //        ddlClientList.SelectedIndex = 0;

    //    }
    //    catch (Exception ex)
    //    {
    //        lblMessage.Visible = true;
    //        lblMessage.Text = ex.Message;
    //        lblMessage.CssClass = "ErrorMessage";

    //    }

    //}

    private void Get_AllBranchList_For_Auth()
    {
        try
        {
            Object SaveUSERInfo = (Object)Session["UserInfo"];

            SqlConnection sqlcon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);

            sqlcon.Open();
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlcon;
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.CommandText = "Get_AllBranchList_For_Auth";
            SqlDataAdapter sqlda = new SqlDataAdapter();
            sqlda.SelectCommand = sqlcmd;

            SqlParameter UserID = new SqlParameter();
            UserID.SqlDbType = SqlDbType.VarChar;
            UserID.Value = ((UserInfo.structUSERInfo)(SaveUSERInfo)).UserId.Trim();
            UserID.ParameterName = "@UserID";
            sqlcmd.Parameters.Add(UserID);

            DataTable dt = new DataTable();

            sqlda.Fill(dt);
            sqlcon.Close();

            ddlBranchList.DataTextField = "BranchName";
            ddlBranchList.DataValueField = "BranchId";
            ddlBranchList.DataSource = dt;
            ddlBranchList.DataBind();

            ddlBranchList.Items.Insert(0, "-Select-");
            ddlBranchList.SelectedIndex = 0;

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
    public override void VerifyRenderingInServerForm(Control control)
    {

    }
    protected void BtnGenerate_Click(object sender, EventArgs e)
    {
        if (ddlFormatType.SelectedIndex != 0)
        {
            if (ddlClientList.SelectedIndex != 0)
            {
                if (txtPickupDate.Text != "")
                {
                    btnExport.Visible = true;
                    GenerateADIFile();
                }
                else
                {
                    lblMessage.Visible = true;
                    lblMessage.Text = "Select appropriate PickupDate.";
                }
            }
            else
            {
                lblMessage.Visible = true;
                lblMessage.Text = "Select appropriate Client Type";
            }
        }
        else
        {
            lblMessage.Visible = true;
            lblMessage.Text = "Select appropriate Format.";
        }

    }

    private void GenerateADIFile()
    {
        try
        {
            Object SaveUSERInfo = (Object)Session["UserInfo"];
            SqlConnection sqlcon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);
            sqlcon.Open();

            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.CommandText = "GenerateADIFile";
            sqlcmd.Connection = sqlcon;

            SqlDataAdapter sqlda = new SqlDataAdapter();
            //sqlda.SelectCommand = sqlcmd;

            int pBranchID = 0;
            if (ddlBranchList.SelectedIndex != 0)
            {
                pBranchID = Convert.ToInt32(ddlBranchList.SelectedItem.Value);
            }

            SqlParameter BranchID = new SqlParameter();
            BranchID.SqlDbType = SqlDbType.Int;
            BranchID.Value = pBranchID;
            BranchID.ParameterName = "@BranchID";
            sqlcmd.Parameters.Add(BranchID);

            SqlParameter ClientID = new SqlParameter();
            ClientID.SqlDbType = SqlDbType.Int;
            ClientID.Value = Convert.ToInt32(ddlClientList.SelectedItem.Value);
            ClientID.ParameterName = "@ClientID";
            sqlcmd.Parameters.Add(ClientID);

            SqlParameter FormatType = new SqlParameter();
            FormatType.SqlDbType = SqlDbType.Int;
            FormatType.Value = Convert.ToInt32(ddlFormatType.SelectedItem.Value);
            FormatType.ParameterName = "@FormatType";
            sqlcmd.Parameters.Add(FormatType);

            SqlParameter PickupDate = new SqlParameter();
            PickupDate.SqlDbType = SqlDbType.VarChar;
            PickupDate.Value = txtPickupDate.Text;
            PickupDate.ParameterName = "@PickupDate";
            sqlcmd.Parameters.Add(PickupDate);

            SqlParameter VarResult = new SqlParameter();
            VarResult.SqlDbType = SqlDbType.VarChar;
            VarResult.Value = "";
            VarResult.ParameterName = "@VarResult";
            sqlcmd.Parameters.Add(VarResult);

            sqlda.SelectCommand = sqlcmd;
            DataTable dt = new DataTable();
            sqlda.Fill(dt);
            sqlcon.Close();

            if (dt.Rows.Count > 0)
            {
                gvExportReport.DataSource = dt;
                gvExportReport.DataBind();
                if (Convert.ToInt32(ddlFormatType.SelectedItem.Value) == 1)
                {

                    //GenerateExcelReport();
                    //string attachment = "";
                    //if (ddlClientList.SelectedIndex == 1)
                    //{
                    //    attachment = "attachment; filename=ADI_FileGenerationSBI.xls";
                    //}
                    //if (ddlClientList.SelectedIndex == 2)
                    //{
                    //    attachment = "attachment; filename=ADI_FileGenerationNonSBI.xls";
                    //}
                    //Response.ClearContent();
                    //Response.AddHeader("content-disposition", attachment);
                    //Response.ContentType = "application/ms-excel";
                    //StringWriter sw = new System.IO.StringWriter();
                    //HtmlTextWriter htw = new HtmlTextWriter(sw);

                    //string style = @"<style> TD { mso-number-format:\@; } </style> ";
                    //gvExportReport.EnableViewState = false;
                    //gvExportReport.RenderControl(htw);
                    //Response.Write(style);
                    //Response.Write(sw.ToString());
                    //Response.End();
                }
                else
                    if (Convert.ToInt32(ddlFormatType.SelectedItem.Value) == 2)
                    {
                        //StringBuilder str = new StringBuilder();
                        //for (int i = 0; i < gvExportReport.Rows.Count; i++)
                        //{
                        //    for (int j = 0; j < 1; j++)
                        //    {
                        //        str.Append(gvExportReport.Rows[i].Cells[0].Text + Environment.NewLine);
                        //    }
                        //}

                        //string attachment = "";
                        //if (ddlClientList.SelectedIndex == 1)
                        //{
                        //    attachment = "attachment; filename=ADI_FileGenerationSBI.xls";
                        //}
                        //if (ddlClientList.SelectedIndex == 2)
                        //{
                        //    attachment = "attachment; filename=ADI_FileGenerationNonSBI.xls";
                        //}
                        //Response.ClearContent();
                        //Response.AddHeader("content-disposition", attachment);
                        //Response.Charset = "";
                        //Response.Cache.SetCacheability(HttpCacheability.NoCache);
                        //Response.ContentType = "application/vnd.text";
                        //System.IO.StringWriter stringWrite = new System.IO.StringWriter();
                        //System.Web.UI.HtmlTextWriter htmlWrite = new HtmlTextWriter(stringWrite);
                        //Response.Write(str.ToString());
                        //Response.End();
                    }
            }
            else
            {
                lblMessage.Visible = true;
                lblMessage.Text = "No Records Found.";
                lblMessage.CssClass = "ErrorMessage";
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

    private void GenerateTextReport()
    {
        StringBuilder str = new StringBuilder();
        for (int i = 0; i < gvExportReport.Rows.Count; i++)
        {
            for (int j = 0; j < 1; j++)
            {
                str.Append(gvExportReport.Rows[i].Cells[0].Text + Environment.NewLine);
            }
        }

        string attachment = "";
        if (ddlClientList.SelectedIndex == 1)
        {
            attachment = "attachment; filename=ADI_FileGenerationSBI.txt";
        }
        if (ddlClientList.SelectedIndex == 2)
        {
            attachment = "attachment; filename=ADI_FileGenerationNonSBI.txt";
        }
        Response.ClearContent();
        Response.AddHeader("content-disposition", attachment);
        Response.Charset = "";
        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        Response.ContentType = "application/vnd.text";
        System.IO.StringWriter stringWrite = new System.IO.StringWriter();
        System.Web.UI.HtmlTextWriter htmlWrite = new HtmlTextWriter(stringWrite);
        Response.Write(str.ToString());
        Response.End();
    }

    private void GenerateExcelReport()
    {
       
        string attachment = "";
        if (ddlClientList.SelectedIndex == 1)
        {
            attachment = "attachment; filename=ADI_FileGenerationSBI.xls";
        }
        if (ddlClientList.SelectedIndex == 2)
        {
            attachment = "attachment; filename=ADI_FileGenerationNonSBI.xls";
        }
        Response.ClearContent();
        Response.AddHeader("content-disposition", attachment);
        Response.ContentType = "application/ms-excel";
        StringWriter sw = new System.IO.StringWriter();
        HtmlTextWriter htw = new HtmlTextWriter(sw);

        string style = @"<style> TD { mso-number-format:\@; } </style> ";
        gvExportReport.GridLines = GridLines.Both;
        gvExportReport.EnableViewState = false;
        gvExportReport.RenderControl(htw);
        Response.Write(style);
        Response.Write(sw.ToString());

        Response.End();
    }
    protected void btnReset_Click(object sender, EventArgs e)
    {
        ddlBranchList.SelectedIndex = 0;
        ddlClientList.SelectedIndex = 0;
        ddlFormatType.SelectedIndex = 0;
        txtPickupDate.Text = "";
    }
    protected void btnExport_Click(object sender, EventArgs e)
    {
        if (ddlFormatType.SelectedIndex == 1)
        {
            GenerateExcelReport();
        }
        else
            if (ddlFormatType.SelectedIndex == 2)
            {
                GenerateTextReport();
            }
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("");
    }
}