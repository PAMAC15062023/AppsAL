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


public partial class Pages_ICICIRPC_ICICI_MIS : System.Web.UI.Page
{
    //SingleUserLogin Login = new SingleUserLogin();
    protected void Page_Load(object sender, EventArgs e)
    {
       
        if (!IsPostBack)
        {
            BindProduct();
        }
        Object SaveUSERInfo = (Object)Session["UserInfo"];
        
    }
    protected void BindProduct()
    {
        SqlConnection sqlCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);

        SqlCommand cmd = new SqlCommand("IRPC_MasterSearchCode_SP", sqlCon);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@Types", "RPCProduct");
        cmd.Parameters.AddWithValue("@Level", 1);
        SqlDataAdapter adp = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        adp.Fill(ds);

        if (ds != null && ds.Tables[0].Rows.Count > 0)
        {
            ddlproduct.DataSource = ds;
            ddlproduct.DataValueField = "Code_Id";
            ddlproduct.DataTextField = "Description";
            ddlproduct.DataBind();
            ddlproduct.Items.Insert(0, new ListItem("ALL", "ALL"));
        }
    }
    protected void btncancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Pages/Menu.aspx", true);
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
                FromDate.Value = strDate(txtFromDate.Text.Trim());
                FromDate.ParameterName = "@FromDate";
                cmd.Parameters.Add(FromDate);

                SqlParameter ToDate = new SqlParameter();
                ToDate.SqlDbType = SqlDbType.VarChar;
                ToDate.Value = strDate(txtToDate.Text.Trim());
                ToDate.ParameterName = "@ToDate";
                cmd.Parameters.Add(ToDate);

                SqlParameter product = new SqlParameter();
                product.SqlDbType = SqlDbType.VarChar;
                product.Value = ddlproduct.SelectedValue.ToString();
                product.ParameterName = "@productid";
                cmd.Parameters.Add(product);


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

    public string strDate(string strInDate)
    {
        string strDD = strInDate.Substring(0, 2);

        string strMM = strInDate.Substring(3, 2);

        string strYYYY = strInDate.Substring(6, 4);

        string strMMDDYYYY = strMM + "/" + strDD + "/" + strYYYY;

       // string strMMDDYYYY = strDD + "/" + strMM + "/" + strYYYY;

        DateTime dtConvertDate = Convert.ToDateTime(strMMDDYYYY);

        string strOutDate = dtConvertDate.ToString("dd-MMM-yyyy");

        return strOutDate;
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
        "<b><font size='2' color='blue'>From Date " + txtFromDate.Text + " To " + txtToDate.Text + " </font></b> <br/>";
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