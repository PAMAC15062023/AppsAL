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
using System.IO;
using System.Data.OleDb;


public partial class TemplateConfiguration : System.Web.UI.Page
{
    int count = 0;
    
    protected void Page_Load(object sender, EventArgs e)
    {
        
        CImportTemplate oImport = new CImportTemplate();
        try
        {

            String strtemplateID = "";
            lblMassage.Text = "";



            if (Request.QueryString["template_Id"] != null && Request.QueryString["template_Id"] != "")
            {
                lblMassage.Text = "Edit";
                if (!IsPostBack)
                {
                    CCommon con = new CCommon();
                    ddlActivity.Visible = false;
                    ddlProduct.Visible = false;
                    ddlClient.Visible = false;
                    object o = new object();
                   
                    string strsql = "select activity_name from activity_master where activity_id=" + Request.QueryString["activity_Id"];
                    o = OleDbHelper.ExecuteScalar(con.ConnectionString, CommandType.Text, strsql);
                    lblActivity.Visible = true;
                    lblActivity.Text = (string)(o);

                    string strsql1 = "select product_name from product_master where activity_id=" + Request.QueryString["product_Id"];
                    o = OleDbHelper.ExecuteScalar(con.ConnectionString, CommandType.Text, strsql1);
                    lblProduct.Visible = true;
                    lblProduct.Text = (string)(o);

                    string strsq2 = "select client_name from client_master where client_id=" + Request.QueryString["client_Id"];
                    o = OleDbHelper.ExecuteScalar(con.ConnectionString, CommandType.Text, strsq2);
                    lblClient.Visible = true;
                    lblClient.Text = (string)(o);
                    
                    txtTemplate.Text = Request.QueryString["template_name"];
                    sdsgvTemplateMatchEdit.SelectCommand = "SELECT distinct [TEMPLATE_ID], [TEMPLATE_head],data_table,data_field FROM [IMPORT_DATA_MASTER]  where activity_id='" + Request.QueryString["activity_Id"] + "' and product_id='" + Request.QueryString["product_Id"] + "'and template_id='" + Request.QueryString["template_Id"] + "' order by TEMPLATE_head";
                    gvTemplateMatchEdit.DataBind();
                    btnCancel.Visible = true;
                   
                }
            }
        }
        catch (Exception exp)
        {
            lblMassage.Text = "Error";
        }
        
    }


    protected void ddlActivity_SelectedIndexChanged(object sender, EventArgs e)
    {
       
        CImportTemplate oImport = new CImportTemplate();
       
        sdsProduct.SelectCommand = oImport.ProductSelect(ddlActivity.SelectedValue);
        
        ddlProduct.DataBind();
        if (ddlActivity.SelectedIndex != 0)
        {
            sdsClient.SelectCommand = "select distinct client_id,client_name from ce_ac_pr_ct_vw where product_id='" + ddlProduct.SelectedValue + "'  ";
            ddlClient.DataBind();
            ddlClient.SelectedIndex = 0;
        }
       
        if (ddlActivity.SelectedIndex == 0)
        {

            sdsClient.SelectCommand = "select distinct client_id,client_name from ce_ac_pr_ct_vw where product_id='" + ddlProduct.SelectedValue + "' ";
          
           ddlClient.DataBind();
        }
    }
    protected void btnUpload_Click(object sender, EventArgs e)
     {
        if (xslFileupload.HasFile)
        {
           
            CImportTemplate oImport = new CImportTemplate();
            String strSql = "";
            String strPath = "";
            String MyFile = "";
            string str = "";
            //to get the file extention
            String strFileName = xslFileupload.FileName.ToString();

            FileInfo fi = new FileInfo(strFileName);
            String strExt = fi.Extension;

            if (strExt == ".xls")
            {
                //Uploading file start.
                StreamWriter SW;
                strPath = Server.MapPath("~/ImportFiles/");
                MyFile = oImport.BatchId.ToString().Trim() + ".xls";
                strPath = strPath + MyFile;
                xslFileupload.PostedFile.SaveAs(strPath);
                lblMassage.Visible = true;
                lblMassage.Text = "File uploaded successfully";
                //Uploading end.
              

                //Binding data in Grid view from Excel Sheet
                bool Excel = true;
                try
                {
                    string strConn;
                    string strFile = HttpContext.Current.Server.MapPath("~\\ImportFiles\\" + oImport.BatchId + ".xls");
                    strConn = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" +
                               strFile + @";Extended Properties=""Excel 8.0;IMEX=1""";

                    string sql = "SELECT " + "[MapFields]" + " FROM " + " [Sheet1$]";
                    OleDbDataAdapter DbDa = new OleDbDataAdapter(sql, strConn);
                    DataSet dsMap = new DataSet();
                    DbDa.Fill(dsMap);
                    gvTemplate.DataSource = dsMap;
                    gvTemplate.AllowSorting = false;
                    gvTemplate.DataBind();
                }

                catch (Exception ex)
                {
                    lblMassage.Visible = true;
                    lblMassage.Text = "Excel sheet is not in correct formate";
                    Excel = false;
                }
                if (IsPostBack)
                {
                    if (Excel == true)
                    {
                        if (Request.QueryString["template_Id"] != null && Request.QueryString["template_Id"] != "")
                        {
                            sdsgvTemplateMatch.SelectCommand = "select name,id,mt.Table_name from syscolumns, map_table_master mt where id = (select id from sysobjects where name= mt.table_name) and mt.activity_id='" + Request.QueryString["activity_Id"] + "' and mt.product_id='" + Request.QueryString["product_Id"] + "'and mt.type=0 order by name";
                            gvTemplateMatch.DataBind();
                            gvTemplateMatchEdit.Visible = false;

                        }
                        else
                        {
                            sdsgvTemplateMatch.SelectCommand = "select name,id,mt.Table_name from syscolumns, map_table_master mt where id = (select id from sysobjects where name= mt.table_name) and mt.activity_id='" + ddlActivity.SelectedValue + "' and mt.product_id='" + ddlProduct.SelectedValue + "'and mt.type=0 order by name";
                            gvTemplateMatch.DataBind();
                        }
                        btnSubmit.Visible = true;
                        btnCancel.Visible = true;
                    }
                }
             
            }
            else
            {
                lblMassage.Visible = true;
                lblMassage.Text = "File can not be uploaded ";
            }
            String strFile1 = Server.MapPath("~\\ImportFiles\\" ) + MyFile;
            if (File.Exists(strFile1))
            {
                File.Delete(strFile1);
            }
        }

       
     
    }
   
   
    protected void ddlProduct_DataBound(object sender, EventArgs e)
    {
        ddlProduct.Items.Insert(0, new ListItem("--Select Product--", "0"));
       
    }
    protected void gvTemplate_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        
        string str = "";

      
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            count++;
            str = count.ToString();
            ((Label)e.Row.FindControl("lblSrNo")).Text = str;
            hidSrNo.Value = count.ToString();
        }
    }
    protected void gvTemplateMatch_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        DropDownList ddlSrNo;
        int ctr=0;
        if (hidSrNo.Value != "")
        {
             ctr = Convert.ToInt32(hidSrNo.Value.ToString());
        }
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            ddlSrNo = ((DropDownList)e.Row.FindControl("ddlSrNo"));
            //lblTemplateField = ((Label)e.Row.FindControl("lblTemplateField"));
           
            ddlSrNo.Items.Insert(0, new ListItem("Select One", "0"));
            ddlSrNo.DataBind();
            for (int i = 1; i <= ctr; i++)
            {

                ddlSrNo.Items.Add(i.ToString());
                //ddlSrNo.SelectedValue = i.ToString();
                //ddlSrNo.DataBind();
            }


           
        }
    }

    protected void gvTemplateMatch_RowCommand(object sender, GridViewCommandEventArgs e)
    {
      
            
    }


    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        bool boolselect=false;
        foreach (GridViewRow gvRow in gvTemplateMatch.Rows)
        {
            DropDownList ddlSrNo;
            ddlSrNo = ((DropDownList)gvRow.FindControl("ddlSrNo"));

            if (ddlSrNo.SelectedIndex != 0)
            {
                boolselect = true;
            }

        }
        if (boolselect)
        {

            if (Request.QueryString["template_Id"] != null && Request.QueryString["template_Id"] != "")
            {
                string templateID;
                string strPrefix = "101";
                CImportTemplate cit = new CImportTemplate();
                CCommon con = new CCommon();
                //templateID = con.GetUniqueID("IMPORT_DATA_MASTER", strPrefix).ToString();
                cit.TemplateID = Request.QueryString["template_Id"].Trim();
                cit.TemplateName = txtTemplate.Text.Trim();
                cit.ActivityID = Request.QueryString["activity_Id"].Trim();
                cit.ProductID = Request.QueryString["product_Id"].Trim();

                cit.ClientID = Request.QueryString["client_Id"].Trim();
                cit.DeleteTemplate();
                DataTable dt = new DataTable();

                dt.Columns.Add("data_table");
                dt.Columns.Add("data_field");
                dt.Columns.Add("template_head");
                dt.Columns.Add("SEQENCE");
                DataRow row;
                DropDownList ddlSrNo;
                Label lblTable;
                Label lblField;
                int SrNo = 0;
                string strSN = "";
                int count = 0;
                int i;
                string sql = "";
                foreach (GridViewRow gvRow in gvTemplateMatch.Rows)
                {

                    ddlSrNo = ((DropDownList)gvRow.FindControl("ddlSrNo"));

                    lblTable = (Label)gvRow.FindControl("lblDataTable");
                    lblField = (Label)gvRow.FindControl("lblDataField");
                    if (ddlSrNo.SelectedIndex.ToString() != "0")
                    {

                        SrNo = Convert.ToInt32(ddlSrNo.SelectedValue) - 1;
                        row = dt.NewRow();
                        dt.Rows.Add();
                        dt.Rows[count]["data_table"] = lblTable.Text;
                        dt.Rows[count]["data_field"] = lblField.Text;
                        dt.Rows[count]["SEQENCE"] = ddlSrNo.SelectedValue;
                        dt.Rows[count]["template_head"] = gvTemplate.Rows[SrNo].Cells[1].Text;
                        count++;



                    }

                }
                count--;
                OleDbParameter TemplateName = new OleDbParameter("@TemplateName", OleDbType.VarChar, 10);
                TemplateName.Value = txtTemplate.Text.Trim();
                sql = "select count(*) from import_data_master where template_name=?";
                Object o = new object();

                o = OleDbHelper.ExecuteScalar(con.ConnectionString, CommandType.Text, sql, TemplateName);
                if (Convert.ToInt32(o) == 0)
                {
                    for (count = 0; count < dt.Rows.Count; count++)
                    {
                        cit.DataTable = dt.Rows[count]["data_table"].ToString().Trim();
                        cit.DataField = dt.Rows[count]["data_field"].ToString().Trim();
                        cit.Sequence = dt.Rows[count]["SEQENCE"].ToString().Trim();
                        cit.TemplateHead = dt.Rows[count]["template_head"].ToString().Trim();


                        cit.updateTemplate();

                        lblMassage.Visible = true;
                        lblMassage.Text = "Template update Successfully";
                        Session["massage"] = lblMassage.Text;
                    }


                }
                else
                {
                    lblMassage.Visible = true;
                    lblMassage.Text = "Duplicate Template can not be updated";
                    Session["massage"] = lblMassage.Text;
                }
                Response.Redirect("TemplateConfigurationManager.aspx");
            }
            else
            {
                string templateID;
                string strPrefix = "101";
                CImportTemplate cit = new CImportTemplate();
                CCommon con = new CCommon();
                templateID = con.GetUniqueID("IMPORT_DATA_MASTER", strPrefix).ToString();
                cit.TemplateID = templateID.Trim();
                cit.TemplateName = txtTemplate.Text.Trim();
                cit.ActivityID = ddlActivity.SelectedValue.Trim();
                cit.ProductID = ddlProduct.SelectedValue.Trim();

                cit.ClientID = ddlClient.SelectedValue.Trim();
                DataTable dt = new DataTable();

                dt.Columns.Add("data_table");
                dt.Columns.Add("data_field");
                dt.Columns.Add("template_head");
                dt.Columns.Add("SEQENCE");
                DataRow row;
                DropDownList ddlSrNo;
                Label lblTable;
                Label lblField;
                int SrNo = 0;
                string strSN = "";
                int count = 0;
                int i;
                string sql = "";
                foreach (GridViewRow gvRow in gvTemplateMatch.Rows)
                {

                    ddlSrNo = ((DropDownList)gvRow.FindControl("ddlSrNo"));

                    lblTable = (Label)gvRow.FindControl("lblDataTable");
                    lblField = (Label)gvRow.FindControl("lblDataField");
                    if (ddlSrNo.SelectedIndex.ToString() != "0")
                    {

                        SrNo = Convert.ToInt32(ddlSrNo.SelectedValue) - 1;
                        row = dt.NewRow();
                        dt.Rows.Add();
                        dt.Rows[count]["data_table"] = lblTable.Text;
                        dt.Rows[count]["data_field"] = lblField.Text;
                        dt.Rows[count]["SEQENCE"] = ddlSrNo.SelectedValue;
                        dt.Rows[count]["template_head"] = gvTemplate.Rows[SrNo].Cells[1].Text;
                        count++;



                    }

                }
                count--;
                OleDbParameter TemplateName = new OleDbParameter("@TemplateName", OleDbType.VarChar, 10);
                TemplateName.Value = txtTemplate.Text.Trim();
                sql = "select count(*) from import_data_master where template_name=?";
                Object o = new object();

                o = OleDbHelper.ExecuteScalar(con.ConnectionString, CommandType.Text, sql, TemplateName);
                if (Convert.ToInt32(o) == 0)
                {
                    for (count = 0; count < dt.Rows.Count; count++)
                    {
                        cit.DataTable = dt.Rows[count]["data_table"].ToString().Trim();
                        cit.DataField = dt.Rows[count]["data_field"].ToString().Trim();
                        cit.Sequence = dt.Rows[count]["SEQENCE"].ToString().Trim();
                        cit.TemplateHead = dt.Rows[count]["template_head"].ToString().Trim();


                        cit.CreateInsert();

                        lblMassage.Visible = true;
                        lblMassage.Text = "Template Insert Successfully";
                        Session["massage"] = lblMassage.Text;
                    }


                }
                else
                {
                    lblMassage.Visible = true;
                    lblMassage.Text = "Duplicate Template can not be Inserted";
                    Session["massage"] = lblMassage.Text;
                }
                ddlActivity.SelectedIndex = 0;
                ddlProduct.SelectedIndex = 0;
              
                txtTemplate.Text = "";
                Response.Redirect("ConfigurationVerification.aspx");
            }
        }
        else
        {
            lblMassage.Text = "Please Map Fields";
        }
      

    }

    
    protected void ddlActivity_DataBound(object sender, EventArgs e)
    {
        ddlActivity.Items.Insert(0, new ListItem("--Select Activity--", "0"));
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        DropDownList ddlSrNo;
        foreach (GridViewRow gvRow in gvTemplateMatch.Rows)
        {
            ddlSrNo = ((DropDownList)gvRow.FindControl("ddlSrNo"));
            ddlSrNo.SelectedIndex = 0;

        }
        if (Request.QueryString["template_Id"] == null && Request.QueryString["template_Id"] == "")
        {
            ddlActivity.SelectedIndex = 0;
            ddlProduct.SelectedIndex = 0;
        }
       
        txtTemplate.Text = "";
        lblMassage.Visible = false;
        if (Request.QueryString["template_Id"] != null && Request.QueryString["template_Id"] != "")
        {
            Response.Redirect("TemplateConfigurationManager.aspx");
        }
        Response.Redirect("TemplateConfigurationManager.aspx");
    }
    protected void ddlProduct_SelectedIndexChanged(object sender, EventArgs e)
     {
        sdsClient.SelectCommand = "select distinct client_id,client_name from ce_ac_pr_ct_vw where product_id='" + ddlProduct.SelectedValue + "' ";
        ddlClient.DataBind();
       
    }
    protected void ddlClient_DataBound(object sender, EventArgs e)
    {
        ddlClient.Items.Insert(0, new ListItem("--Select Client--", "0"));
       
    }
}
