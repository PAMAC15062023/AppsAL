using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;

public partial class Pages_Calculus_HDFC_HDFCTM_SuperAdminMIS_outfile : System.Web.UI.Page
{
    bool result = false;
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Pages/Menu.aspx", true);
    }
    protected void btnExport_Click(object sender, EventArgs e)
    {
        btnSearch_Click();

        if (result == true)
        {
            Genrate_Excel();
        }
    }

    protected bool btnSearch_Click()
    {
        try
        {
            if (txtFromDate.Text.Trim() == "")
            {
                lblMsg.Text = "Please Enter From Date";
                return false;
            }

            if (txtToDate.Text.Trim() == "")
            {
                lblMsg.Text = "Please Enter To Date";
                return false;
            }

           lblMsg.Text = "";

            SqlConnection sqlCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);
            SqlCommand sqlCom = new SqlCommand();
            sqlCom.Connection = sqlCon;
            sqlCom.CommandType = CommandType.StoredProcedure;
            sqlCom.CommandText = "HDFC_AdminMIS";
            sqlCom.CommandTimeout = 0;

            SqlParameter FromDate = new SqlParameter();
            FromDate.SqlDbType = SqlDbType.VarChar;
            FromDate.Value = strDate(txtFromDate.Text.Trim());
            FromDate.ParameterName = "@FromDate";
            sqlCom.Parameters.Add(FromDate);

            SqlParameter ToDate = new SqlParameter();
            ToDate.SqlDbType = SqlDbType.VarChar;
            ToDate.Value = strDate(txtToDate.Text.Trim());
            ToDate.ParameterName = "@ToDate";
            sqlCom.Parameters.Add(ToDate);


            SqlDataAdapter adp = new SqlDataAdapter(sqlCom);
            DataSet ds = new DataSet();

            adp.Fill(ds);

            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {

                GridAdminMIS.DataSource = ds;
                GridAdminMIS.DataBind();

                btnExport.Visible = true;
                result = true;
            }
            else
            {
                GridAdminMIS.DataSource = null;
                GridAdminMIS.DataBind();

                btnExport.Visible = false;


                lblMsg.Text = "No Record Found ....!!!";
                result = false;
            }
        }
        catch (Exception ex)
        {
            ex.ToString();
            lblMsg.Text = "Error :" + ex.Message;
        }

        return result;
    }

    public string strDate(string strInDate)
    {
        string strDD = strInDate.Substring(0, 2);

        string strMM = strInDate.Substring(3, 2);

        string strYYYY = strInDate.Substring(6, 4);

        string strYYYYMMDD = strYYYY + "-" + strMM + "-" + strDD;

        //string strMMDDYYYY = strDD + "/" + strMM + "/" + strYYYY;

        DateTime dtConvertDate = Convert.ToDateTime(strYYYYMMDD);

        string strOutDate = dtConvertDate.ToString("yyyy-MM-dd");

        return strOutDate;
    }

    private void Genrate_Excel()
    {
        String attachment = "attachment; filename=HDFCTM_AdminMIS_Report" + ".xls";
        Response.AddHeader("content-disposition", attachment);
        Response.ContentType = "application/ms-excel";
        StringWriter sw = new System.IO.StringWriter();
        HtmlTextWriter htw = new HtmlTextWriter(sw);
        Table tblSpace = new Table();
        TableRow tblRow = new TableRow();
        TableCell tblCell = new TableCell();
        tblCell.Text = " ";
        tblCell.ColumnSpan = 10;// 10;
        tblCell.Text = "<b> <font size='2' color='blue'>PAMAC FINSERVE PVT. LTD.</font></span></b> <br/>";
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

        Table tbl1 = new Table();
        GridAdminMIS.EnableViewState = false;
        GridAdminMIS.GridLines = GridLines.Both;
        GridAdminMIS.RenderControl(htw);
        Response.Write(sw.ToString());

        Response.End();
        Response.Write(sw.ToString());
    }

    public override void VerifyRenderingInServerForm(Control control)
    {
        //base.VerifyRenderingInServerForm(control);
    }

}