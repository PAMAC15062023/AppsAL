using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Text;
using System.IO;
public partial class Pages_HeroHousing_MIS : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindMIS();
        }
        Object SaveUSERInfo = (Object)Session["UserInfo"];

    }
    protected void BindMIS()
    {
        SqlConnection sqlCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);

        SqlCommand cmd = new SqlCommand("HeroHousing_MasterSearchCode_SP", sqlCon);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@Types", "MISType");
        cmd.Parameters.AddWithValue("@Level", 1);
        SqlDataAdapter adp = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        adp.Fill(ds);

        if (ds != null && ds.Tables[0].Rows.Count > 0)
        {
            ddlMIS.DataSource = ds;
            ddlMIS.DataValueField = "Code_Id";
            ddlMIS.DataTextField = "Description";
            ddlMIS.DataBind();
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        Report();
        Generate_ExcelFile();
    }
    protected void Report()
    {
        SqlConnection sqlcon = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);
        try
        {
            if (textFromDate.Text.Contains("null"))
            {
                textFromDate.Text = textFromDate.Text.Remove(11);
                textFromDate.Text = textFromDate.Text + "00:00:00";
            }
            if (textToDate.Text.Contains("null"))
            {
                textToDate.Text = textFromDate.Text.Remove(11);
                textToDate.Text = textFromDate.Text + "00:00:00";
            }
            if (sqlcon.State == ConnectionState.Closed)
            {
                sqlcon.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = sqlcon;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = ddlMIS.SelectedValue.ToString();
                cmd.CommandTimeout = 0;

                SqlParameter FromDate = new SqlParameter();
                FromDate.SqlDbType = SqlDbType.VarChar;
                FromDate.Value = strDateUpdated(textFromDate.Text.TrimEnd());
                FromDate.ParameterName = "@FromDate";
                cmd.Parameters.Add(FromDate);

                SqlParameter ToDate = new SqlParameter();
                ToDate.SqlDbType = SqlDbType.VarChar;
                ToDate.Value = strDateUpdated(textToDate.Text.TrimEnd());
                ToDate.ParameterName = "@ToDate";
                cmd.Parameters.Add(ToDate);

                SqlDataAdapter sda = new SqlDataAdapter();
                sda.SelectCommand = cmd;

                DataTable dt = new DataTable();
                sda.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    gvExportReport.DataSource = dt;
                    gvExportReport.DataBind();
                }
                else
                {
                    gvExportReport.DataSource = null;
                    gvExportReport.DataBind();
                }
            }
        }
        catch (SqlException sqlex)
        {
            lblMessage.Text = sqlex.Message.ToString();
        }
        catch (SystemException ex)
        {
            lblMessage.Text = ex.Message.ToString();
        }
        finally
        {
            if (sqlcon.State == ConnectionState.Open)
            {
                sqlcon.Close();
            }
        }
    }
    protected void btncancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Pages/Menu.aspx", true);
    }
    public string strDate(string strInDate)
    {
        string strDD = strInDate.Substring(0, 2);
        string strMM = strInDate.Substring(3, 2);
        string strYYYY = strInDate.Substring(6, 4);
        string strMMDDYYYY = strMM + "/" + strDD + "/" + strYYYY;
        //string strMMDDYYYY = strDD + "/" + strMM + "/" + strYYYY;
        DateTime dtConvertDate = Convert.ToDateTime(strMMDDYYYY);
        string strOutDate = dtConvertDate.ToString("dd-MMM-yyyy");
        return strOutDate;
    }

    public string strDateUpdated(string strInDate)
    {
        string strDD = strInDate.Substring(0, 2);
        string strMM = strInDate.Substring(3, 2);
        string strYYYY = strInDate.Substring(6, 4);
        string strTime = strInDate.Substring(10, 9);
        string strMMDDYYYY = strMM + "/" + strDD + "/" + strYYYY;
        //string strMMDDYYYY = strDD + "/" + strMM + "/" + strYYYY;
        DateTime dtConvertDate = Convert.ToDateTime(strMMDDYYYY);
        string strOutDate = dtConvertDate.ToString("yyyy-MM-dd");
        return strOutDate + strTime + ".000";
    }

    private void Generate_ExcelFile()
    {
        String attachment = "attachment; filename=" + ddlMIS.SelectedItem.ToString() + ".xls";
        Response.AddHeader("content-disposition", attachment);
        Response.ContentType = "application/ms-excel";
        StringWriter sw = new System.IO.StringWriter();
        HtmlTextWriter htw = new HtmlTextWriter(sw);
        Table tblSpace = new Table();
        TableRow tblRow = new TableRow();
        TableCell tblCell = new TableCell();
        tblCell.Text = " ";
        tblCell.ColumnSpan = 10;// 10;
        tblCell.Text = "<b> <font size='2' color='blue'>PAMAC FINSERVE PVT. LTD.</font></span></b> <br/>" +
        "<b><font size='2' color='blue'>From Date " + textFromDate.Text + " To " + textToDate.Text + " </font></b> <br/>";
        tblCell.CssClass = "SuccessMessage";
        TableRow tblRow1 = new TableRow();
        TableCell tblCell1 = new TableCell();
        tblCell1.ColumnSpan = 20;// 10;
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
        Response.Write(sw.ToString());

        Response.End();
    }

    public override void VerifyRenderingInServerForm(Control control)
    {
        /* Verifies that the control is rendered */
    }
}