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
using System.Data.OleDb;
using System.Text;
using System.IO;
using Microsoft.Office.Core;
using System.Configuration.Assemblies;
using CrystalDecisions.Shared;
using CrystalDecisions.CrystalReports.ViewerObjectModel;
using System.Data.SqlClient;


public partial class QueryBuilder_Femu_Control_Report : System.Web.UI.Page
{   
    CCommon objcon = new CCommon();
    public override void VerifyRenderingInServerForm(Control control)
    {

    }   
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                Get_FE_Name(Convert.ToInt32(Session["CentreId"]));

            }

            Register_Control_With_Javascript();
        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
            lblMessage.Visible = true;
            lblMessage.CssClass = "ErrorMessage";
        }

        
    }
    protected void btnsearch_Click(object sender, EventArgs e)
    {       
        if (txtToDate.Text != "")
        {       
            getsearch();         
        }
        else 
        {
            lblMessage.Text = "Please select date to continue!";
            lblMessage.Visible = true;
            lblMessage.CssClass = "ErrorMessage";
        }
    } 
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
                else if (cDateFormat == "yyyyMMdd")
                {
                    strDate = strArrDate[2] + strArrDate[1] + strArrDate[0];

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
    protected void getsearch()
    {

        SqlConnection sqlCon = new SqlConnection(ConfigurationSettings.AppSettings["constring"]);

        sqlCon.Open();
        SqlCommand sqlCom = new SqlCommand();
        sqlCom.Connection = sqlCon;
        sqlCom.CommandType = CommandType.StoredProcedure;
        sqlCom.CommandText = "Get_FEMUControlReport";
        SqlDataAdapter sqlDA = new SqlDataAdapter();

        SqlParameter Product = new SqlParameter();
        Product.SqlDbType = SqlDbType.VarChar;
        Product.ParameterName = "@Product";
        Product.Value = ddlprduct1.Text.Trim();
        sqlCom.Parameters.Add(Product);

        SqlParameter CentreID = new SqlParameter();
        CentreID.SqlDbType = SqlDbType.Int;
        CentreID.ParameterName = "@CentreID";
        CentreID.Value = Convert.ToInt32(Session["CentreId"]);
        sqlCom.Parameters.Add(CentreID);

        SqlParameter FromDate = new SqlParameter();
        FromDate.SqlDbType = SqlDbType.VarChar;
        FromDate.ParameterName = "@FromDate";
        FromDate.Value = txtToDate.Text.Trim();
        sqlCom.Parameters.Add(FromDate);


        SqlParameter ToDate = new SqlParameter();
        ToDate.SqlDbType = SqlDbType.VarChar;
        ToDate.ParameterName = "@ToDate";
        ToDate.Value = txtToDate.Text.Trim();
        sqlCom.Parameters.Add(ToDate);

        SqlParameter CaseStatus = new SqlParameter();
        CaseStatus.SqlDbType = SqlDbType.VarChar;
        CaseStatus.ParameterName = "@CaseStatus";
        CaseStatus.Value = DDLCaseSta.Text.Trim();
        sqlCom.Parameters.Add(CaseStatus);

        sqlDA.SelectCommand = sqlCom;
        DataTable dt = new DataTable();
        sqlDA.Fill(dt);
        sqlCon.Close();

        if (dt.Rows.Count > 0)
        {
            lblMessage.Text = "";
            lblTotalCount.Text = "Total Records Found :" + dt.Rows.Count.ToString();
            grdvw.DataSource = dt;
            grdvw.DataBind();

            grvReport.DataSource = dt;
            grvReport.DataBind();


        }
        else
        {
            grdvw.DataSource = null;
            grdvw.DataBind();

            grvReport.DataSource = null;
            grvReport.DataBind();

            lblMessage.Text = "Records Not Found!!!!!";
            lblMessage.Visible = true;

        }
    }
    protected DataTable getcases()
    {
        try
        {
            string qry = "";
            DataTable dtsearch = new DataTable();


            qry = "EXEC Get_FEMUControlReport '" + ddlprduct1.SelectedValue.ToString() + "','" + Session["CentreId"].ToString() + "','" + txtToDate.Text.Trim() + "','" + txtToDate.Text.Trim() + "','" + DDLCaseSta.SelectedValue.ToString() + "'";
            OleDbDataAdapter oleda = new OleDbDataAdapter(qry, objcon.ConnectionString);
            DataSet da = new DataSet();
            oleda.Fill(da, "Search");
            dtsearch = da.Tables["Search"];
            return dtsearch;
        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
            lblMessage.Visible = true;
            lblMessage.CssClass = "ErrorMessage";
            return null;
        }
    }    
    protected void btnExport_Click(object sender, EventArgs e)
    {
        String attachment = "attachment; filename=Femu Comtrol Sheet Report.xls";
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
        tblCell1.Text = "<b><font size='3'>PAMAC FINSERVE PVT. LTD., MUMBAI</font></b> <br/>" +
                        "<b><font size='2' color='blue'>Femu Control Sheet Report - Assignement Date : " + txtToDate.Text + " To :" + txtToDate.Text + " </font></b> <br/>";
        tblCell1.CssClass = "SuccessMessage";
        tblRow.Cells.Add(tblCell);
        tblRow1.Cells.Add(tblCell1);
        tblRow.Height = 20;
        tblSpace.Rows.Add(tblRow);
        tblSpace.Rows.Add(tblRow1);
        tblSpace.RenderControl(htw);

        Table tbl = new Table();
        grvReport.Visible = true;
        grvReport.EnableViewState = false;
        grvReport.GridLines = GridLines.Both;
        tblExport.RenderControl(htw);
        Response.Write(sw.ToString());

        Response.End();
    } 
    private void Get_FE_Name(int pCentreId)
    {
        try
        {

            SqlConnection sqlCon = new SqlConnection(ConfigurationSettings.AppSettings["constring"]);

            sqlCon.Open();
            SqlCommand sqlCom = new SqlCommand();
            sqlCom.Connection = sqlCon;
            sqlCom.CommandType = CommandType.StoredProcedure;
            sqlCom.CommandText = "Get_AllFELIst";
            SqlDataAdapter sqlDA = new SqlDataAdapter();

            SqlParameter CentreId = new SqlParameter();
            CentreId.SqlDbType = SqlDbType.Int;
            CentreId.ParameterName = "@CentreId";
            CentreId.Value = pCentreId;
            sqlCom.Parameters.Add(CentreId);

            sqlDA.SelectCommand = sqlCom;
            DataTable dt = new DataTable();
            sqlDA.Fill(dt);
            sqlCon.Close();

            ddlFEList.DataTextField = "FullName";
            ddlFEList.DataValueField = "FE_ID";
            ddlFEList.DataSource = dt;
            ddlFEList.DataBind();

            ddlFEList.Items.Insert(0, "--Select--");
            ddlFEList.SelectedIndex = 0;



        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
            lblMessage.Visible = true;
            lblMessage.CssClass = "ErrorMessage";
        }
    }
    protected void grdvw_DataBound(object sender, EventArgs e)
    {
        try
        {
            for (int i = 0; i <= grdvw.Rows.Count - 1; i++)
            {
                CheckBox chkSelect = (CheckBox)grdvw.Rows[i].FindControl("chkSelect");
                HiddenField hdnSelectedValue = (HiddenField)grdvw.Rows[i].FindControl("hdnSelectedValue");
                chkSelect.Attributes.Add("onclick", "javascript:ShowFEList('" + chkSelect.ClientID + "','" + hdnSelectedValue.ClientID + "');");
  

            }
        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
            lblMessage.Visible = true;
            lblMessage.CssClass = "ErrorMessage";
        }
    }
    protected void btnSetValue_Click(object sender, EventArgs e)
    {

        try
        {
            int SelectedInt = 0;
            if (ddlFEList.SelectedIndex != 0)
            {
                for (int i = 0; i <= grdvw.Rows.Count - 1; i++)
                {
                    CheckBox chkSelect = (CheckBox)grdvw.Rows[i].FindControl("chkSelect");
                    Label lblFEName = (Label)grdvw.Rows[i].FindControl("lblFEName");
                    HiddenField hdnSelectedValue = (HiddenField)grdvw.Rows[i].FindControl("hdnSelectedValue");
                    //chkSelect.Attributes.Add("onclick", "javascript:ShowFEList('" + chkSelect.ClientID + "','" + hdnSelectedValue.ClientID + "');");
                    if ((chkSelect.Checked == true )&&(grdvw.Rows[i].Cells[12].Text.Trim().ToUpper()!="ACCEPT"))
                    {
                        hdnSelectedValue.Value = ddlFEList.SelectedValue;
                        lblFEName.Text = ddlFEList.SelectedItem.Text.Trim();
                        chkSelect.Checked = false;
                    }

                    if (lblFEName.Text != "")
                    {
                        SelectedInt = SelectedInt + 1;
                    }

                }
            }
            lblTotalCount.Text = "Total Records Found: " + grdvw.Rows.Count.ToString()+" And "+SelectedInt +" were Reassigned to FE" ;
            ddlFEList.SelectedIndex = 0;

        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
            lblMessage.Visible = true;
            lblMessage.CssClass = "ErrorMessage";
        }
    }
    protected void btnResignedCases_Click(object sender, EventArgs e)
    {
        try
        {
            Ressignment_Pending_CasesToFE();
            getsearch(); 
        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
            lblMessage.Visible = true;
            lblMessage.CssClass = "ErrorMessage";
        }
    }
    private void Ressignment_Pending_CasesToFE()
    {
        try
        {
            SqlConnection sqlCon = new SqlConnection(ConfigurationSettings.AppSettings["constring"]);

            sqlCon.Open();
            SqlCommand sqlCom = new SqlCommand();
            sqlCom.Connection = sqlCon;
            sqlCom.CommandType = CommandType.StoredProcedure;
            sqlCom.CommandText = "Insert_ReAssignmentCases";
            SqlDataAdapter sqlDA = new SqlDataAdapter();

            SqlParameter ReAssignCaseInfo = new SqlParameter();
            ReAssignCaseInfo.SqlDbType = SqlDbType.VarChar;
            ReAssignCaseInfo.ParameterName = "@ReAssignCaseInfo";
            ReAssignCaseInfo.Value = Get_PendingCaseToRessignMentInfo();
            sqlCom.Parameters.Add(ReAssignCaseInfo);


            SqlParameter ProductType = new SqlParameter();
            ProductType.SqlDbType = SqlDbType.VarChar;
            ProductType.ParameterName = "@ProductType";
            ProductType.Value = ddlprduct1.Text.Trim();
            sqlCom.Parameters.Add(ProductType);

            SqlParameter AssignedBy = new SqlParameter();
            AssignedBy.SqlDbType = SqlDbType.Int;
            AssignedBy.ParameterName = "@AssingedBy";
            AssignedBy.Value = Convert.ToInt32(Session["UserId"]);
            sqlCom.Parameters.Add(AssignedBy);

            int ReturnRows = 0;
            ReturnRows = sqlCom.ExecuteNonQuery();
            sqlCon.Close();

            if (ReturnRows > 0)
            {
                lblMessage.CssClass = "UpdateMessage";
                lblMessage.Text = " Cases Assigned Successfully!";
                lblMessage.Visible = true;
              

            }

           
        }
        catch (Exception ex)
        {

            lblMessage.CssClass = "ErrorMessage";
            lblMessage.Text = ex.Message;
            lblMessage.Visible = true;
        }

    }
    private string Get_PendingCaseToRessignMentInfo()
    {
        try
        {
            string Value = "";
            for (int i = 0; i <= grdvw.Rows.Count - 1; i++)
            {
                CheckBox chkSelect = (CheckBox)grdvw.Rows[i].FindControl("chkSelect");
                HiddenField hdnSelectedValue = (HiddenField)grdvw.Rows[i].FindControl("hdnSelectedValue");

                if ((hdnSelectedValue.Value != "") && (grdvw.Rows[i].Cells[12].Text.Trim().ToUpper()!="ACCEPT"))
                {
                    Value += grdvw.Rows[i].Cells[7].Text.Trim() + "|" + hdnSelectedValue.Value.Trim() + "|" + grdvw.Rows[i].Cells[10].Text.Trim() + "^";
                    //Value += grdvw.Rows[i].Cells["Case_Id"].Text.Trim() + "|" + hdnSelectedValue.Value.Trim() + "|" + grdvw.Rows[i].Cells["Verification_Type"].Text.Trim() + "^";
                }
                 
            }

            return Value;
        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
            lblMessage.Visible = true;
            lblMessage.CssClass = "ErrorMessage";
            return "";
        }
    }
    private void Register_Control_With_Javascript()
    {
        try
        {
            btnResignedCases.Attributes.Add("onclick", "javascript:return Validate_ReassignedCasesToFE();");
            btnSetValue.Attributes.Add("onclick", "javascript:return Validate_FEAssignment();");

        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
            lblMessage.Visible = true;
            lblMessage.CssClass = "ErrorMessage";             
        }

    
    }
}
