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

public partial class ConfigurationVerification : System.Web.UI.Page
{
    CCommon con = new CCommon();
    CConfigurationVerification conObject = new CConfigurationVerification();
   
    DataTable dt = new DataTable();
    int i1 = 0;
    string str = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {

            String strtemplateID = "";
            lblMsg.Text = "";
            string strMultiColumn = "";
            string strMultivalues="";
             
            lblMulorSingValue.Visible = false;
            if (Request.QueryString["template_Id"] != null && Request.QueryString["template_Id"] != "")
            {
                lblTemplate.Visible = true;
                lblColumnslection.Visible = true;
                
                if (!IsPostBack)
                {

                    CCommon con = new CCommon();

                    string strsql = "";

                    txtSepareator.Visible = false;
                    ddlTemplateName.Visible = false;
                    rbtnColumnSelection.Visible = false;

                    //txtColumnName.Text = Request.QueryString["column_name"];
                    lblTemplate.Text = Request.QueryString["template_name"];
                    strMultiColumn = Request.QueryString["multiple_column"].Trim();
                    strMultivalues=Request.QueryString["multiple_values"].Trim();
                    if (strMultiColumn == "")
                    {
                        lblMsg.Visible = true;
                        //lblMsg.Text = "First do the verification";
                        //Session["massage"] = lblMsg.Text;
                       
                        Response.Redirect("ConfigurationVerification.aspx");
                    }
                    if (strMultiColumn == "Y")
                    {
                        lblColumnslection.Text = "Multiple Column";
                        strsql = " select IVS.String,IVS.comparing_value, IVS.Verification_Type_id ,VTM.VERIFICATION_TYPE_CODE  from IMPORT_VERIFICATION_STRING IVS INNER JOIN VERIFICATION_TYPE_MASTER VTM on(VTM.VERIFICATION_TYPE_ID=IVS.VERIFICATION_TYPE_ID) where template_id=" + Request.QueryString["template_Id"];
                        OleDbDataReader dr;
                        dr = OleDbHelper.ExecuteReader(con.ConnectionString, CommandType.Text, strsql);

                        dt.Columns.Add("String");
                        dt.Columns.Add("Comparing Value");
                        dt.Columns.Add("Verification");
                        dt.Columns.Add("VerificationID");
                        while (dr.Read())
                        {
                            dt.Rows.Add();
                            dt.Rows[dt.Rows.Count - 1]["String"] = dr[0].ToString();
                            dt.Rows[dt.Rows.Count - 1]["Comparing Value"] = dr[1].ToString();
                            dt.Rows[dt.Rows.Count - 1]["Verification"] = dr[3].ToString();
                            dt.Rows[dt.Rows.Count - 1]["VerificationID"] = dr[2].ToString();
                            hidverificationid.Value = hidverificationid.Value + dr[2].ToString() + '+';
                        }

                        gvStringVerification.DataSource = dt;
                        gvStringVerification.AllowSorting = false;
                        gvMultibound();
                        gvStringVerification.DataBind();
                        ViewState["v1"] = dt;
                        //sdsgvstringVerification.SelectCommand = " select ivs.string,vtm.verification_type_code from verification_type_master vtm inner join import_verification_string ivs on(vtm.verification_type_id=ivs.verification_type_id) where ivs.template_id=" + Request.QueryString["template_Id"];
                        //gvStringVerification.DataSourceID = sdsgvstringVerification.ID;
                        //gvStringVerification.DataBind();
                        sdsgvVerification.SelectCommand = "select verification_type_code,verification_type_id from verification_type_master where activity_id=(select distinct activity_id from import_data_master where template_id='" + Request.QueryString["template_Id"] + "')";
                        gvVerification.DataBind();
                        btnAddMultiColumn.Visible = true;
                        btnSubmitt.Visible = true;
                        lblcolonval.Visible = false;
                        lbls.Visible = false;
                        lblcomval.Text = "compare Value";
                        txtStringTemplate.Visible = true;
                        valtxtStringTemplate1.Enabled = false;
                       
                    }
                    if (strMultiColumn == "N")
                    {
                        valtxtComparingValue.Enabled = true;
                        valtxtComparingValue.ErrorMessage = "Please put the value in string in template";
                        lblColumnslection.Text = "Single Column";
                        lblcomval.Text = "string in Template";
                        btnAddMultiColumn.Visible = false;
                        btnAddSingleColumn.Visible = true;
                        lblval.Visible = true;
                        rbtnValues.Visible = false;
                        lblMulorSingValue.Visible = true;
                          lblcolonval.Visible = true;
                        lbls.Visible = true;
                        txtStringTemplate.Text = Request.QueryString["column_name"];
                        txtSepareator.Visible = false;
                       
                        object o;
                        string sql="select SEPARATOR_CHAR from import_verification_master where template_id="+Request.QueryString["template_Id"];
                         o = OleDbHelper.ExecuteScalar(con.ConnectionString, CommandType.Text, sql);

                          if (o.ToString()!="")
                             {
                                 txtSepareator.Text = (string)(o);
                             }
                        
                        if (strMultivalues == "Y")
                        {
                            lblMulorSingValue.Text = "Multiple Value";
                            Session["str"] = "Y";
                            valtxtseparator.Enabled = true;
                        }
                        else
                        {
                            lblMulorSingValue.Visible = true;
                            lblMulorSingValue.Text = "Single Value";
                            valtxtseparator.Enabled = false;
                            txtSepareator.Enabled = false;
                            Session["str"] = "N";
                        }
                         strsql = " select String, Verification_Type_id  from IMPORT_VERIFICATION_STRING where template_id=" + Request.QueryString["template_Id"];
                        OleDbDataReader dr;
                        dr = OleDbHelper.ExecuteReader(con.ConnectionString, CommandType.Text, strsql);

                        dt.Columns.Add("String");
                        
                        while (dr.Read())
                        {
                            dt.Rows.Add();
                            dt.Rows[dt.Rows.Count - 1]["String"] = dr[0].ToString();
                            hidverificationid.Value = hidverificationid.Value + dr[1].ToString()+'+';
                        }
                        ViewState["v2"] = dt;
                        gvsinglleverificationEdit.DataSource = dt;
                        gvsinglleverificationEdit.AllowSorting = false;
                        gvsinglleverificationEdit.DataBind();
                   
                   
                        sdsgvSingleVerification.SelectCommand = "select verification_type_code,verification_type_id from verification_type_master where activity_id=(select distinct activity_id from import_data_master where template_id='" + Request.QueryString["template_Id"] + "')";
                        gvSingleVerification.DataBind();
                       
                        txtSepareator.Visible = true;
                        lblSeparator.Visible = true;
                        ViewState["v4"] = dt;
                        btnAddSingleColumn.Visible = true;
                        btnSubmitt.Visible = true;
                        //code for add after Edit

                    }
                    txtComparingValue.Text = Request.QueryString["comparing_value"].Trim();

                  

                }
            }
            if (rbtnColumnSelection.SelectedValue == "N")
            {
                valtxtseparator.Enabled = true;
                valtxtComparingValue.Enabled = true;
                valtxtComparingValue.ErrorMessage = "Please put the string in string in template";
            }
        }
        catch (Exception ex)
        {
 
        }

    }
    protected void ddlTemplateName_DataBound(object sender, EventArgs e)
    {
        ddlTemplateName.Items.Insert(0, new ListItem("--Select Template Name--", "0"));
       
    }
    protected void gvVerification_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        
        foreach (GridViewRow gvRow in gvVerification.Rows)
        {
           
            ((RadioButton)gvRow.FindControl("rbtngvVerification")).Attributes.Add("onclick", "javascript: RadioChecked('" + ((RadioButton)gvRow.FindControl("rbtngvVerification")).ClientID + "');");
        }
    }
    protected void ddlTemplateName_SelectedIndexChanged(object sender, EventArgs e)
    {
       
        rbtnColumnSelection.SelectedIndex=0;
        if (rbtnColumnSelection.SelectedValue == "Y")
        {
            valtxtStringTemplate1.Enabled = false;
        }
        if (ddlTemplateName.SelectedIndex == 0)
        {
            sdsgvVerification.SelectCommand = "select verification_type_code,verification_type_id from verification_type_master where activity_id=(select distinct activity_id from import_data_master where template_id='" + ddlTemplateName.SelectedValue + "')";
            gvVerification.DataBind();
            btnAddMultiColumn.Visible = false;
            btnAddSingleColumn.Visible = false;
            sdsgvSingleVerification.SelectCommand = "select verification_type_code,verification_type_id from verification_type_master where activity_id=(select distinct activity_id from import_data_master where template_id='" + ddlTemplateName.SelectedValue + "')";
            gvSindgleColumnStringVerification.DataBind();
            lblval.Visible = false;
            rbtnValues.Visible = false;
            lblcolonval.Visible = false;
            lbls.Visible = false;
            txtSepareator.Visible = false;
            lblSeparator.Visible = false;
            
        }
        else
        {
            gvVerification.Visible = true;
            sdsgvVerification.SelectCommand = "select verification_type_code,verification_type_id from verification_type_master where activity_id=(select distinct activity_id from import_data_master where template_id='" + ddlTemplateName.SelectedValue + "')";
            gvVerification.DataBind();
            if (rbtnColumnSelection.SelectedIndex == 0)
            {
                btnAddMultiColumn.Visible = true;
                lblval.Visible = false;
            }
            if (rbtnColumnSelection.SelectedIndex == 1)
            {
                btnAddMultiColumn.Visible = true;
                lblval.Visible = true;
            }
            
        }
      
    }
    protected void btnAddMultiColumn_Click(object sender, EventArgs e)
    {
        bool Radiobutt = false;
        btnSubmitt.Visible = true;
        foreach (GridViewRow gvRow in gvVerification.Rows)
        {
            RadioButton rbtn1;

            rbtn1 = (RadioButton)gvRow.FindControl("rbtngvVerification");

            if (rbtn1.Checked)
            {
                Radiobutt = true;
            }

        }
        if (Request.QueryString["template_Id"] != null && Request.QueryString["template_Id"] != "" && Request.QueryString["column_name"] != "")
        {
            if (Radiobutt)
            {
                gvStringVerification.DataSourceID = null;
              
               
                btnSubmitt.Visible = true;
                if (rbtnColumnSelection.SelectedIndex == 0 && hidcount.Value == "")
                {
                    //dt.Rows.Clear();
                    dt=(DataTable) ViewState["v1"];
                }
                int count = 0;
               

                string[] strTemp;
              
                if (hidcount.Value != "")
                {
                    count = Convert.ToInt32(hidcount.Value);
                }
                DataRow row;
                int i = 0;

                row = dt.NewRow();
                if (ViewState["v1"] != null)
                {
                    dt = (DataTable)(ViewState["v1"]);
                    //if (rbtnColumnSelection.SelectedIndex == 0 && hidcount.Value == "")
                    //{
                    //    dt.Columns.Add("verification");
                    //    dt.Columns.Add("String in Template");
                    //    dt.Columns.Add("Comparing Value");
                    //}
                }

                string strtxtColumnName = "";
               
                string strVerfication = "";
                string strverificationID = "";



                foreach (GridViewRow gvRow in gvVerification.Rows)
                {
                    i++;
                    RadioButton rbtn1;
                    HiddenField hidval;
                    rbtn1 = (RadioButton)gvRow.FindControl("rbtngvVerification");
                     hidval = (HiddenField)gvRow.FindControl("hidValue");
                    if (rbtn1.Checked == true)
                    {
                        strVerfication = gvVerification.Rows[i - 1].Cells[1].Text.Trim();
                        strverificationID = hidval.Value;
                    }

                }
                if (ViewState["v1"] == null)
                {
                    dt.Columns.Add("verification");
                    dt.Columns.Add("String");
                    dt.Columns.Add("Comparing Value");
                    dt.Columns.Add("VerificationID");
                    hidtxtStringTemplate.Value = "";
                }

             
                bool boolIsDuplicate = false;
               
                    strTemp = hidtxtStringTemplate.Value.ToString().Split(',');

                   
                    for (i = 0; i < dt.Rows.Count; i++)
                    {
                        if (txtStringTemplate.Text == dt.Rows[i]["VerificationID"].ToString())
                        {
                            boolIsDuplicate = true;
                        }
                        
                    }
               

                    if (!boolIsDuplicate)
                    {
                        //insert record in datatable and attach string to hiddenfield here....
                        dt.Rows.Add();
                        dt.Rows[dt.Rows.Count - 1]["String"] = txtStringTemplate.Text.Trim();
                        hidtxtStringTemplate.Value = hidtxtStringTemplate.Value + txtStringTemplate.Text.Trim() + ',';
                        dt.Rows[dt.Rows.Count - 1]["verification"] = strVerfication.Trim();
                        dt.Rows[dt.Rows.Count - 1]["Comparing Value"] = txtComparingValue.Text.Trim();
                        dt.Rows[dt.Rows.Count - 1]["VerificationID"] = strverificationID.Trim();
                        ViewState["v1"] = dt;
                        count++;
                        hidcount.Value = count.ToString();
                        lblMsg.Visible = false;
                        //end 
                    }
                    else
                    {
                        lblMsg.Visible = true;
                        lblMsg.Text = "Duplicate value should not be entered";
                    }
               
                ViewState["v2"] = null;
                gvsinglleverificationEdit.Visible = false;
                gvStringVerification.DataSource = dt;
                gvStringVerification.AllowSorting = false;
                gvMultibound();
                gvStringVerification.DataBind();
                lblMsg.Visible = false;
                //foreach (GridViewRow gvRow in gvVerification.Rows)
                //{

                //   ((RadioButton)gvRow.FindControl("rbtngvVerification")).Checked=false;


                //}

            }
            else
            {
                lblMsg.Visible = true;
                lblMsg.Text = "Please select rows";
                gvsinglleverificationEdit.Visible = false;
            }
        }

        else 
        {
            if (Radiobutt)
            {
                btnSubmitt.Visible = true;
                if (rbtnColumnSelection.SelectedIndex == 0 && hidcount.Value == "")
                {
                    dt.Rows.Clear();
                    ViewState["v1"] = dt;
                }
                int count = 0;
              
                string[] strTemp;
               
                if (hidcount.Value != "")
                {
                    count = Convert.ToInt32(hidcount.Value);
                }
                DataRow row;
                int i = 0;

                row = dt.NewRow();
                if (ViewState["v1"] != null)
                {
                    dt = (DataTable)(ViewState["v1"]);
                    if (rbtnColumnSelection.SelectedIndex == 0 && hidcount.Value == "")
                    {
                        dt.Columns.Add("verification");
                        dt.Columns.Add("String");
                        dt.Columns.Add("Comparing Value");
                        dt.Columns.Add("VerificationID");
                    }
                }

                string strtxtColumnName = "";
                string strVerfication = "";
                string strVerificationID = "";
                strtxtColumnName = txtStringTemplate.Text;
             
                string[] txtColN = strtxtColumnName.Split(',');



                foreach (GridViewRow gvRow in gvVerification.Rows)
                {
                    i++;
                    RadioButton rbtn1;
                    HiddenField hidval;
                    rbtn1 = (RadioButton)gvRow.FindControl("rbtngvVerification");
                    hidval = (HiddenField)gvRow.FindControl("hidValue");
                    if (rbtn1.Checked == true)
                    {
                        strVerfication = gvVerification.Rows[i - 1].Cells[1].Text.Trim();
                        strVerificationID = hidval.Value;
                    }

                }
                if (ViewState["v1"] == null)
                {
                    dt.Columns.Add("verification");
                    dt.Columns.Add("String");
                    dt.Columns.Add("Comparing Value");
                    dt.Columns.Add("VerificationID");
                    hidtxtStringTemplate.Value = "";
                }

                bool boolExistCol = false;
                bool boolIsDuplicate = false;
                foreach (string str in txtColN)
                {
                    if (txtStringTemplate.Text.Trim() == str)
                    {
                        boolExistCol = true;
                    }
                }

                if (boolExistCol)
                {
                    strTemp = hidtxtStringTemplate.Value.ToString().Split(',');

                   
                    for (i = 0; i < dt.Rows.Count; i++)
                    {
                        if (txtStringTemplate.Text.Trim() == dt.Rows[i]["VerificationID"].ToString())
                        {
                            boolIsDuplicate = true;
                        }
                    }

                        if (!boolIsDuplicate)
                        {
                            //insert record in datatable and attach string to hiddenfield here....
                            dt.Rows.Add();
                            dt.Rows[dt.Rows.Count - 1]["String"] = txtStringTemplate.Text.Trim();
                            hidtxtStringTemplate.Value = hidtxtStringTemplate.Value + txtStringTemplate.Text.Trim() + ',';
                            dt.Rows[dt.Rows.Count - 1]["verification"] = strVerfication.Trim();
                            dt.Rows[dt.Rows.Count - 1]["Comparing Value"] = txtComparingValue.Text.Trim();
                            dt.Rows[dt.Rows.Count - 1]["VerificationID"] = strVerificationID.Trim();
                            ViewState["v1"] = dt;
                            count++;
                            hidcount.Value = count.ToString();
                            lblMsg.Visible = false;
                            //end 
                        }
                        else
                        {
                            lblMsg.Visible = true;
                            lblMsg.Text = "Duplicate value should not be entered";
                        }


                }
                ViewState["v2"] = null;
                gvStringVerification.DataSource = dt;
                gvStringVerification.AllowSorting = false;
                gvMultibound();
                gvStringVerification.DataBind();
                //lblMsg.Visible = false;
                //foreach (GridViewRow gvRow in gvVerification.Rows)
                //{

                //   ((RadioButton)gvRow.FindControl("rbtngvVerification")).Checked=false;


                //}

            }
            else
            {
                lblMsg.Visible = true;
                lblMsg.Text = "Please select rows";
            }
 
        }
      
        foreach (GridViewRow gvRow in gvVerification.Rows)
        {

            HiddenField hidval;
            RadioButton rbtn1;
            rbtn1 = (RadioButton)gvRow.FindControl("rbtngvVerification");

            if (rbtn1.Checked)
            {
                hidval = (HiddenField)gvRow.FindControl("hidValue");

             hidstr.Value   = hidstr.Value+ hidval.Value + ',';

                      
            }
        }


        txtComparingValue.Text = "";
        txtStringTemplate.Text = "";
        txtSepareator.Text = "";
       
        }
    

    
    protected void gvStringVerification_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        dt = (DataTable)(ViewState["v1"]);
       
        conObject.TemplateID = Request.QueryString["template_Id"];

        //conObject.VerificationTypeID = dt.Rows[e.RowIndex]["verificationID"].ToString();
        conObject.VerificationTypeID = dt.Rows[e.RowIndex]["VerificationID"].ToString();
        //conObject.DeleteVerificationString();
        dt.Rows[e.RowIndex].Delete();
        gvStringVerification.DataSource = dt;
        gvMultibound();
        gvStringVerification.DataBind();
        ViewState["v1"] = dt;
     
    }
   
    protected void btnSubmitt_Click(object sender, EventArgs e)
    {
        string strcolumnname = "";
        //string strverificationID = "";
     
        //int l=0;
        //foreach (GridViewRow gvRow in gvSingleVerification.Rows)
        //{
        //    l++;
        //    CheckBox chk1;

        //    chk1 = (CheckBox)gvRow.FindControl("chkngvVerification");
        //    HiddenField hidval;
        //    hidval = (HiddenField)gvRow.FindControl("hidValue");
        //    if (chk1.Checked)
        //    {
               
               
        //        strverificationID = strverificationID + hidval.Value.Trim() + ',';
        //    }

        //}
               
        
        if (btnAddMultiColumn.Visible == true)
        {
            dt = (DataTable)ViewState["v1"];

            if (dt != null)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    strcolumnname = strcolumnname + dt.Rows[i]["String"].ToString().Trim() + ',';
                }
            }
        }
        if (btnAddSingleColumn.Visible == true)
        {
            dt = (DataTable)ViewState["v2"];

            if (dt != null)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    strcolumnname = strcolumnname + dt.Rows[i]["String in Template"].ToString().Trim() + ',';
                }
            }
        }

        if (btnAddMultiColumn.Visible == true)
        {
            if (Request.QueryString["template_Id"] != null && Request.QueryString["template_Id"] != "" && Request.QueryString["column_name"] != "")
            {
                if (ViewState["v1"] != null)
                {
                    dt = (DataTable)(ViewState["v1"]);
                }

                if (btnAddMultiColumn.Visible == true)
                {
                   
                   
                    if (dt != null)
                    {
                        conObject.TemplateID = Request.QueryString["template_Id"].Trim();
                        conObject.DeleteVerificationMaster();
                        conObject.DeleteVerificationString();
                    }
                   
                        if (dt != null)
                        {
                       
                            conObject.TemplateID = Request.QueryString["template_Id"].Trim();
                            //conObject.VerificationTypeID = str.Trim();
                            string strsql = "select distinct table_name from map_table_master where type=1 and activity_id = (select distinct activity_id from import_data_master where template_id='" + Request.QueryString["template_Id"] + "') and product_id=(select distinct product_id from import_data_master where template_id='" + Request.QueryString["template_Id"] + "')";
                            conObject.TableName = OleDbHelper.ExecuteScalar(con.ConnectionString, CommandType.Text, strsql).ToString().Trim();
                            conObject.MultipleCollumn = "Y";
                            conObject.ColumnName = strcolumnname.TrimEnd(',').Trim();
                            conObject.ExpectedValue = "Y";
                            conObject.Separator = null;
                            conObject.SeparatorValue = null;
                            conObject.MultipleVakue = null;

                            conObject.ComparingValue = txtComparingValue.Text.Trim();
                            
                                string sSql1 = "select count(*) from import_verification_master where TEMPLATE_ID='" + Request.QueryString["template_Id"]+ "' ";
                                object o1;
                                 o1 = OleDbHelper.ExecuteScalar(con.ConnectionString, CommandType.Text, sSql1);
                                 if (Convert.ToInt32(o1) == 0)
                                 {
                                     conObject.InsertVerificationMaster();
                                 }
                          
                            
                               
                                    for (int i = 0; i < dt.Rows.Count; i++)
                                    {
                                        string sSql = "select count(*) from import_verification_string where  TEMPLATE_ID='" + Request.QueryString["template_Id"] + "' and  VERIFICATION_TYPE_ID='" + dt.Rows[i]["verificationID"].ToString().Trim() + "' ";
                                          object o;
                                          o = OleDbHelper.ExecuteScalar(con.ConnectionString, CommandType.Text, sSql);
                                          if (Convert.ToInt32(o) == 0)
                                          {
                                              
                                                  conObject.String1 = dt.Rows[i]["String"].ToString().Trim();
                                                  conObject.ComparingValue = dt.Rows[i]["Comparing Value"].ToString().Trim();
                                                  conObject.VerificationTypeID = dt.Rows[i]["VerificationID"].ToString().Trim();
                                                  //conObject.VerificationTypeID = dt.Rows[dt.Rows.Count - 1]["verification"].ToString();
                                                  conObject.InsertVerificationString();

                                                  
                                             
                                          }

                                    }
                                
                            
                            
                        }
                        else
                        {
                            lblMsg.Visible = true;

                            lblMsg.Text = "First Add the column Name";
                            Session["massage"] = lblMsg.Text;
                            Response.Redirect("TemplateConfigurationManager.aspx");
                        }
                    
                }
                hidstr.Value = null;
                if (dt!=null)
                {
                    
                    lblMsg.Visible = true;
                    lblMsg.Text = " verification updated successfuly";
                    Session["massage"] = lblMsg.Text;
                    Response.Redirect("TemplateConfigurationManager.aspx");
                }
            }
            else
            {
                if (ViewState["v1"] != null)
                {
                    dt = (DataTable)(ViewState["v1"]);
                }
                if (btnAddMultiColumn.Visible == true)
                {
                  

                   
                        
                            conObject.TemplateID = ddlTemplateName.SelectedValue.Trim();
                            //conObject.VerificationTypeID = str.Trim();
                            string strsql = "select distinct table_name from map_table_master where type=1 and activity_id = (select distinct activity_id from import_data_master where template_id='" + ddlTemplateName.SelectedValue + "')and product_id=(select distinct product_id from import_data_master where template_id='" + ddlTemplateName.SelectedValue + "')";
                            conObject.TableName = OleDbHelper.ExecuteScalar(con.ConnectionString, CommandType.Text, strsql).ToString().Trim();
                            conObject.MultipleCollumn ="Y";
                            conObject.ColumnName = strcolumnname.TrimEnd(',').Trim();
                            conObject.ExpectedValue = "Y";
                            conObject.Separator = null;
                            conObject.SeparatorValue = null;
                            conObject.MultipleVakue = null;

                            conObject.ComparingValue = txtComparingValue.Text.Trim();
                            string sSql1 = "select count(*) from import_verification_master where TEMPLATE_ID='" + ddlTemplateName.SelectedValue.Trim() + "'";
                                object o1;
                                 o1 = OleDbHelper.ExecuteScalar(con.ConnectionString, CommandType.Text, sSql1);
                                 if (Convert.ToInt32(o1) == 0)
                                 {
                                     conObject.InsertVerificationMaster();
                                 }
                            if (dt != null)
                            {
                                
                                    for (int i = 0; i < dt.Rows.Count; i++)
                                    {
                                        string sSql = "select count(*) from import_verification_string where  VERIFICATION_TYPE_ID='" + dt.Rows[i]["VerificationID"] + "' and TEMPLATE_ID = '" + ddlTemplateName.SelectedValue.Trim() + "'";
                                         object o;
                                          o = OleDbHelper.ExecuteScalar(con.ConnectionString, CommandType.Text, sSql);
                                          if (Convert.ToInt32(o) == 0)
                                          {

                                              conObject.String1 = dt.Rows[i]["String"].ToString().Trim();
                                              conObject.ComparingValue = dt.Rows[i]["Comparing Value"].ToString().Trim();
                                              conObject.VerificationTypeID = dt.Rows[i]["VerificationID"].ToString().Trim();
                                              //conObject.VerificationTypeID = dt.Rows[dt.Rows.Count - 1]["verification"].ToString();
                                              conObject.InsertVerificationString();
                                          }
                                            
                                       

                                    }
                                
                            }
                            else
                            {
                                lblMsg.Visible = true;
                                lblMsg.Text = "First Add the column Name";
                                Session["massage"] = lblMsg.Text;
                            }
                        
                       
                    
                }
                hidstr.Value = null;
                if (dt!=null)
                {
                   
                    lblMsg.Visible = true;
                    lblMsg.Text = "verification inserted successfully";
                    Session["massage"] = lblMsg.Text;
                }
            }
        }
        if (btnAddSingleColumn.Visible == true)
        {
            if (Request.QueryString["template_Id"] != null && Request.QueryString["template_Id"] != "" && Request.QueryString["column_name"] != "")
            {
                string str = "";
                if (ViewState["v2"] != null)
                {
                    dt = (DataTable)(ViewState["v2"]);
                }
                
                conObject.TemplateID = Request.QueryString["template_Id"].Trim();
                if (dt != null)
                {
                    conObject.DeleteVerificationMaster();
                    conObject.DeleteVerificationString();
                }
               
                conObject.VerificationTypeID = str.TrimEnd(',').Trim();
                string strsql = "select distinct table_name from map_table_master where type=1 and activity_id = (select distinct activity_id from import_data_master where template_id='" + Request.QueryString["template_Id"] + "') and product_id=(select distinct product_id from import_data_master where template_id='" + Request.QueryString["template_Id"]  +"')";
                conObject.TableName = OleDbHelper.ExecuteScalar(con.ConnectionString, CommandType.Text, strsql).ToString().Trim();
                conObject.MultipleCollumn = "N";
                conObject.ColumnName = txtStringTemplate.Text.Trim();
                conObject.MultipleVakue = (string)Session["str"];
                conObject.ComparingValue = null;
                conObject.ExpectedValue = null;
                if (rbtnValues.SelectedValue == "Y")
                {
                    conObject.Separator = "Y";
                    conObject.SeparatorValue = txtSepareator.Text.Trim();

                }
                else
                {
                    conObject.Separator = "N";
                    conObject.SeparatorValue = null;
                }
                           string sSql1 = "select count(*) from import_verification_master where TEMPLATE_ID='" + Request.QueryString["template_Id"]+ "'";
                            object o1;
                            o1 = OleDbHelper.ExecuteScalar(con.ConnectionString, CommandType.Text, sSql1);
                            if (Convert.ToInt32(o1) == 0)
                            {
                                conObject.InsertVerificationMaster();
                            }
                
                    if (dt != null)
                    {
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {


                            string sSql = "select count(*) from import_verification_string where  VERIFICATION_TYPE_ID='" + dt.Rows[i]["verificationID"].ToString().Trim() + "' and TEMPLATE_ID=" + Request.QueryString["template_Id"];
                            object o;
                            o = OleDbHelper.ExecuteScalar(con.ConnectionString, CommandType.Text, sSql);
                            if (Convert.ToInt32(o) == 0)
                            {

                                conObject.String1 = dt.Rows[i]["String"].ToString().Trim();
                                conObject.VerificationTypeID = dt.Rows[i]["verificationID"].ToString().Trim();
                                conObject.InsertVerificationString();

                            }
                        }
                    }
                    else
                    {
                        lblMsg.Visible = true;
                        lblMsg.Text = "First Add the column Name";
                        gvsinglleverificationEdit.DataBind();
                        Session["massage"] = lblMsg.Text;
                        Response.Redirect("TemplateConfigurationManager.aspx");
                    }
                
               

                
             
                    lblMsg.Visible = true;
                    lblMsg.Text = "verification updated successfully";
                    Session["massage"] = lblMsg.Text;
              
            }
            else
            {
                string str = "";
                if (ViewState["v2"] != null)
                {
                    dt = (DataTable)(ViewState["v2"]);
                }
              

                conObject.TemplateID = ddlTemplateName.SelectedValue.Trim();
                conObject.VerificationTypeID = str.TrimEnd(',').Trim();
                string strsql = "select distinct table_name from map_table_master where type=1 and activity_id = (select distinct activity_id from import_data_master where template_id='" + ddlTemplateName.SelectedValue + "') and product_id=(select distinct product_id from import_data_master where template_id='" + ddlTemplateName.SelectedValue + "')";
                conObject.TableName = OleDbHelper.ExecuteScalar(con.ConnectionString, CommandType.Text, strsql).ToString().Trim();
                conObject.MultipleCollumn = rbtnColumnSelection.SelectedValue.Trim();
                conObject.ColumnName = txtStringTemplate.Text.Trim();
                conObject.MultipleVakue = rbtnValues.SelectedValue.Trim();
                conObject.ComparingValue = null;
                conObject.ExpectedValue = null;
                if (rbtnValues.SelectedValue == "Y")
                {
                    conObject.Separator = "Y";
                    conObject.SeparatorValue = txtSepareator.Text.Trim();

                }
                else
                {
                    conObject.Separator = "N";
                    conObject.SeparatorValue = null;
                }
                         string sSql1 = "select count(*) from import_verification_master where TEMPLATE_ID='" + Request.QueryString["template_Id"]+ "'";
                            object o1;
                            o1 = OleDbHelper.ExecuteScalar(con.ConnectionString, CommandType.Text, sSql1);
                            if (Convert.ToInt32(o1) == 0)
                            {
                                conObject.InsertVerificationMaster();
                            }
                if (dt != null)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {

                        string sSql = "select count(*) from import_verification_string where  VERIFICATION_TYPE_ID='" + dt.Rows[i]["verificationID"].ToString().Trim() + "' and TEMPLATE_ID='" + ddlTemplateName.SelectedValue.Trim()+"'";
                            object o;
                            o = OleDbHelper.ExecuteScalar(con.ConnectionString, CommandType.Text, sSql);
                            if (Convert.ToInt32(o) == 0)
                            {

                                conObject.String1 = dt.Rows[i]["String in Template"].ToString().Trim();
                                conObject.VerificationTypeID = dt.Rows[i]["verificationID"].ToString().Trim();
                                conObject.InsertVerificationString();
                            }

                           
                    }


                    }
                
                else
                {
                    lblMsg.Visible = true;
                    lblMsg.Text = "First Add the column Name";
                    Session["massage"] = lblMsg.Text;
                    Response.Redirect("TemplateConfigurationManager.aspx");
                }
               
                    lblMsg.Visible = true;
                    lblMsg.Text = "verification inserted successfully";
                    Session["massage"] = lblMsg.Text;
                
            }
        }
        if (dt != null)
        {
            Response.Redirect("TemplateConfigurationManager.aspx");
        }
    }
    protected void rbtnValues_SelectedIndexChanged(object sender, EventArgs e)
    {
       
        if (rbtnValues.SelectedValue == "Y")
        {
            txtSepareator.Enabled = true;
           
            dt = (DataTable)(ViewState["v3"]);
            gvSindgleColumnStringVerification.DataSource = dt;
            gvSindgleColumnStringVerification.DataBind();
        }
        else
        {
          
            txtSepareator.Enabled = false;
            valtxtseparator.Enabled = false;
            txtSepareator.Text = "";
            dt = (DataTable)(ViewState["v3"]);
            gvSindgleColumnStringVerification.DataSource = dt;
            gvSindgleColumnStringVerification.DataBind();
        }
        dt = (DataTable)(ViewState["v2"]);
        DataTable dt1 = new DataTable();
        dt1.Columns.Add("verification");
        dt1.Columns.Add("String in Template");
        DataRow row1;
        row1 = dt1.NewRow();

        for ( int i = 0; i < dt.Rows.Count; i++)
        {
            dt1.Rows.Add();
            dt1.Rows[dt1.Rows.Count - 1]["String in Template"] = dt.Rows[i]["String in Template"].ToString();
            dt1.Rows[dt1.Rows.Count - 1]["verification"] = dt.Rows[i]["verification"].ToString();
        }

        gvSindgleColumnStringVerification.DataSource = dt1;
        gvSindgleColumnStringVerification.AllowSorting = false;
        gvSindgleColumnStringVerification.DataBind();
        //ViewState["v3"] = null;
        btnAddMultiColumn.Visible = false;
        btnAddSingleColumn.Visible = true;
        //txtColumnName.Text = "";
        txtComparingValue.Text = "";
        txtStringTemplate.Text = "";
       
        foreach (GridViewRow gvRow in gvSingleVerification.Rows)
        {
          

            ((CheckBox)gvRow.FindControl("chkngvVerification")).Checked = false;


        }
    }
    protected void rbtnColumnSelection_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (rbtnColumnSelection.SelectedValue == "Y")
        {

            lblcomval.Text = "Comparing value";
            valtxtComparingValue.ErrorMessage = "Please put the Compare Value";
            valtxtComparingValue.Enabled = true;
           
        }
        else
        {
            lblcomval.Text = "String in Template";
        }
        if (rbtnColumnSelection.SelectedValue == "N")
        {
            valtxtseparator.Enabled = true;
            valtxtComparingValue.Enabled = true;
            valtxtComparingValue.ErrorMessage = "Please put the string in string in template";
        }
        if (ddlTemplateName.SelectedIndex == 0)
        {
            lblMsg.Visible = true;

            lblMsg.Text = "Please select template name";
        }
        else
        {
            if (rbtnColumnSelection.SelectedValue == "Y")
            {
                rbtnValues.Visible = false;
                txtSepareator.Visible = false;
                gvSingleVerification.Visible = false;
                gvVerification.Visible = true;
                btnAddMultiColumn.Visible = true;
                btnAddSingleColumn.Visible = false;
                valtxtComparingValue.ErrorMessage = "Please put the Compare Value";
                valtxtComparingValue.Enabled = true;
                sdsgvVerification.SelectCommand = "select verification_type_code,verification_type_id from verification_type_master where activity_id=(select distinct activity_id from import_data_master where template_id='" + ddlTemplateName.SelectedValue + "')";
                gvVerification.DataBind();
                dt.Rows.Clear();
                gvSindgleColumnStringVerification.DataSource = null;
                gvSindgleColumnStringVerification.AllowSorting = false;
                gvSindgleColumnStringVerification.DataBind();
                ViewState["v2"] = null;
                gvSindgleColumnStringVerification.DataSource = dt;
                gvSindgleColumnStringVerification.DataBind();
                lblval.Visible = false;
              
                //txtColumnName.Text = "";
                txtComparingValue.Text = "";
                txtStringTemplate.Text = "";
                valtxtseparator.Enabled = false;
                lblSeparator.Visible = false;
                txtSepareator.Text = "";
                btnAddMultiColumn.Visible = true;
                lblcolonval.Visible = false;
                lbls.Visible = false;
                valtxtStringTemplate1.Enabled = false;
                btnSubmitt.Visible = false;
            }

            if (rbtnColumnSelection.SelectedValue == "N")
            {
                valtxtStringTemplate1.Enabled = true;
                lblcomval.Visible = true;
                txtComparingValue.Visible = true;
                btnSubmitt.Visible = true;
                valtxtseparator.Enabled = true;
                rbtnValues.Visible = true;
                txtSepareator.Visible = true;
                gvSingleVerification.Visible = true;
                gvVerification.Visible = false;
                btnAddMultiColumn.Visible = false;
                btnAddSingleColumn.Visible = true;
                lblSeparator.Visible = true;
                lblval.Visible = true;
                lblcolonval.Visible = true;
                lbls.Visible = true;
                sdsgvSingleVerification.SelectCommand = "select verification_type_code,verification_type_id from verification_type_master where activity_id=(select distinct activity_id from import_data_master where template_id='" + ddlTemplateName.SelectedValue + "')";
                gvSingleVerification.DataBind();
                if ( ViewState["v2"]==null)
                {
                    dt.Columns.Add("verification");
                    dt.Columns.Add("String in Template");
                    dt.Columns.Add("verificationID");
                    int k = 0;
                    foreach (GridViewRow gvRow in gvSingleVerification.Rows)
                    {

                        HiddenField hidVal;
                        HiddenField hidcd;
                        hidVal = (HiddenField)gvRow.FindControl("hidValue");
                        hidcd = (HiddenField)gvRow.FindControl("hidcode");
                        dt.Rows.Add();
                        dt.Rows[k]["String in Template"] = hidcd.Value;
                        dt.Rows[k]["verification"] = hidcd.Value;
                        dt.Rows[k]["verificationID"]=hidVal.Value;
                       
                       
                        ViewState["v2"] = dt;
                        ViewState["v3"] = dt;
                        ViewState["v1"] = null;
                        gvStringVerification.DataSource = null;
                        gvStringVerification.DataBind();
                        gvSindgleColumnStringVerification.AllowSorting = false;
                        
                        gvSindgleColumnStringVerification.DataBind();
                        k++;
                    }
                }
                else
                {
                  
  
                    dt = (DataTable)(ViewState["v1"]);
                    //dt.Rows.Clear();
                    gvStringVerification.DataSource = dt;
                    gvStringVerification.DataBind();
                }
                dt = (DataTable)(ViewState["v2"]);

                DataTable dt1 = new DataTable();
                dt1.Columns.Add("verification");
                dt1.Columns.Add("String in Template");
                DataRow row1;
                row1 = dt1.NewRow();
             
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        dt1.Rows.Add();
                        dt1.Rows[dt1.Rows.Count - 1]["String in Template"] = dt.Rows[i]["String in Template"].ToString();
                        dt1.Rows[dt1.Rows.Count - 1]["verification"] = dt.Rows[i]["verification"].ToString();
                    }
            
                gvSindgleColumnStringVerification.DataSource = dt1;
                gvSindgleColumnStringVerification.AllowSorting = false;
                gvSindgleColumnStringVerification.DataBind();
                //txtColumnName.Text = "";
                txtComparingValue.Text = "";
                txtStringTemplate.Text = "";
               
            }
            lblMsg.Visible = false;
        }
      
    }

    protected void btnAddSingleColumn_Click(object sender, EventArgs e)
    {
        btnAddSingleColumn.Attributes.Add("OnClick","javascript:return " + "Checkbox1(); ");
        bool cheakbox = false;
        btnSubmitt.Visible = true;
     
        foreach (GridViewRow gvRow in gvSingleVerification.Rows)
        {
            CheckBox chk1;

            chk1 = (CheckBox)gvRow.FindControl("chkngvVerification");
            if (chk1.Checked)
            {
                cheakbox = true;

            }

        }
        if (cheakbox)
        {
            if (Request.QueryString["template_Id"] != null && Request.QueryString["template_Id"] != "" && Request.QueryString["column_name"] != "")
            {



                //gvsinglleverificationEdit.Visible = false;
                int count = 0;

            
                string strcd = "";
               

                string[] strcode1 = hidtxtStringTemplate.Value.Split(',');


                string[] strTemp;
                if (hidcount.Value != "")
                {
                    count = Convert.ToInt32(hidcount.Value);
                }
                DataRow row;
                int i = 0;

                row = dt.NewRow();
                if (ViewState["v2"] != null)
                {
                   
                    dt = (DataTable)(ViewState["v2"]);
                    
                  
                }
               
                string strtxtColumnName = "";
                string strVerfication = "";

                string strverificationID = "";
                foreach (GridViewRow gvRow in gvSingleVerification.Rows)
                {
                    i++;
                    CheckBox chk1;

                    chk1 = (CheckBox)gvRow.FindControl("chkngvVerification");
                    HiddenField hidval;
                    hidval = (HiddenField)gvRow.FindControl("hidValue");
                    if (chk1.Checked)
                    {
                        strVerfication = strVerfication + gvSingleVerification.Rows[i - 1].Cells[1].Text.Trim() + ',';
                        //strverificationID = strverificationID + gvSindgleColumnStringVerification.Rows[i - 1].Cells[3].Text + ',';
                        strverificationID = strverificationID + hidval.Value.Trim() + ',';
                    }

                }
                string sSql = "select count(*) from import_verification_string where string ='" + txtComparingValue.Text.Trim() + "' and VERIFICATION_TYPE_ID='" + strverificationID.TrimEnd(',').Trim() + "' and TEMPLATE_ID=" + Request.QueryString["template_Id"];
                object o;
                o = OleDbHelper.ExecuteScalar(con.ConnectionString, CommandType.Text, sSql);
                if (Convert.ToInt32(o) == 0 && dt.Rows.Count==0)
                {
                   
                    dt.Columns.Add("String in Template");
                    dt.Columns.Add("verificationID");
                }
                foreach (GridViewRow gvRow in gvSingleVerification.Rows)
                {
                    HiddenField hidcd;
                    hidcd = (HiddenField)gvRow.FindControl("hidcode");
                    strcd = strcd + hidcd.Value + ',';
                    
                }
               

                string[] strcode = strcd.Split(',');
                bool boolIsDuplicate = false;
             

                strTemp = hidtxtStringTemplate.Value.ToString().Split(',');
                bool boolIsDuplicate1 = false;
               
                for (i = 0; i < dt.Rows.Count; i++)
                {
                    if (txtComparingValue.Text == dt.Rows[dt.Rows.Count - 1]["String in Template"].ToString())
                    {
                        boolIsDuplicate1 = true;
                    }
                }

              
                    if (!boolIsDuplicate1)
                    {

                        dt.Rows.Add();
                        dt.Rows[dt.Rows.Count - 1]["String"] = txtComparingValue.Text.Trim();
                        hidtxtStringTemplate.Value = hidtxtStringTemplate.Value + txtComparingValue.Text.Trim() + ',';
                        dt.Rows[dt.Rows.Count - 1]["String in Template"] = strVerfication.TrimEnd(',').Trim();
                        dt.Rows[dt.Rows.Count - 1]["verificationID"] = strverificationID.TrimEnd(',').Trim();
                        ViewState["v2"] = dt;
                        count++;
                        lblMsg.Visible = false;

                    }
                    else
                    {
                       
                        lblMsg.Visible = true;
                        lblMsg.Text = "Duplicate string should not be entered";
                    }
               
                    GrdBound();
                
                str = "update";
                //gvsinglleverificationEdit.Columns.RemoveAt(1);
                gvsinglleverificationEdit.Columns[1].Visible = false;
                gvsinglleverificationEdit.DataBind();
                ViewState["v1"] = null;
                lblMulorSingValue.Visible = true;
                //lblMsg.Visible = false;


            }

            else
            {
                btnSubmitt.Visible = true;
                int count = 0;
                //string[] strTemp;
                string strcd = "";
                string[] strTemp;
                //hidden field for column name

                if (hidcount.Value != "")
                {
                    count = Convert.ToInt32(hidcount.Value);
                }
                DataRow row;
                int i = 0;

                row = dt.NewRow();
                if (ViewState["v2"] != null)
                {
                    dt = (DataTable)(ViewState["v2"]);

                }
                string strtxtColumnName = "";
                string strVerfication = "";
                string strverficationID = "";
                //strtxtColumnName = txtColumnName.Text;
                foreach (GridViewRow gvRow in gvSingleVerification.Rows)
                {
                    i++;
                    CheckBox chk1;
                  
                    chk1 = (CheckBox)gvRow.FindControl("chkngvVerification");
                    HiddenField hidval;
                    hidval = (HiddenField)gvRow.FindControl("hidValue");
                    if (chk1.Checked)
                    {
                        strVerfication = strVerfication + gvSingleVerification.Rows[i - 1].Cells[1].Text.Trim() + ',';
                        //strverficationID = strverficationID + gvSindgleColumnStringVerification.Rows[i - 1].Cells[3].Text + ',';
                        strverficationID = strverficationID + hidval.Value.Trim() + ',';
                    }
                    
                  
                 
                }
              
                foreach (GridViewRow gvRow in gvSingleVerification.Rows)
                {
                    HiddenField hidcd;
                    hidcd = (HiddenField)gvRow.FindControl("hidcode");
                    strcd = strcd + hidcd.Value.Trim() + ',';
                    
                    

                }

                string[] strcode = strcd.Split(',');
                bool boolIsDuplicate = false;
               

                strTemp = hidtxtStringTemplate.Value.ToString().Split(',');
                bool boolIsDuplicate1 = false;
               
                for (i = 0; i < dt.Rows.Count; i++)
                {
                    if (txtComparingValue.Text == dt.Rows[dt.Rows.Count - 1]["String in Template"].ToString())
                    {
                        boolIsDuplicate1 = true;
                    }
                }
             
                    if (!boolIsDuplicate1)
                    {
                        dt.Rows.Add();
                        dt.Rows[dt.Rows.Count - 1]["String in Template"] = txtComparingValue.Text.Trim();
                        hidtxtStringTemplate.Value = hidtxtStringTemplate.Value + txtComparingValue.Text.Trim() + ',';
                        dt.Rows[dt.Rows.Count - 1]["verification"] = strVerfication.TrimEnd(',').Trim();
                        dt.Rows[dt.Rows.Count - 1]["verificationID"] = strverficationID.TrimEnd(',').Trim();
                        ViewState["v2"] = dt;
                        count++;
                        lblMsg.Visible = false;
                    }
                
                else
                {
                    lblMsg.Visible = true;
                    lblMsg.Text = "Duplicate string should not be entered";
                }

                DataTable dt1 = new DataTable();
                dt1.Columns.Add("verification");
                dt1.Columns.Add("String in Template");
                DataRow row1;
                row1 = dt1.NewRow();
               
                    for (i = 0; i < dt.Rows.Count; i++)
                    {
                        dt1.Rows.Add();
                        dt1.Rows[dt1.Rows.Count - 1]["String in Template"] = dt.Rows[i]["String in Template"].ToString();
                        dt1.Rows[dt1.Rows.Count - 1]["verification"] = dt.Rows[i]["verification"].ToString();
                    }
               
                gvSindgleColumnStringVerification.DataSource = dt1;
                gvSindgleColumnStringVerification.AllowSorting = false;
                gvSindgleColumnStringVerification.DataBind();
                ViewState["v1"] = null;
                //lblMsg.Visible = false;

            } 
            
        
        }
        
        else
        {
            dt = (DataTable)(ViewState["v2"]);
            DataTable dt1 = new DataTable();
            dt1.Columns.Add("String");
            dt1.Columns.Add("String in Template");
            DataRow row1;
              row1 = dt1.NewRow();
           
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    dt1.Rows.Add();
                    dt1.Rows[dt1.Rows.Count - 1]["String in Template"] = dt.Rows[i]["String in Template"].ToString();
                    dt1.Rows[dt1.Rows.Count - 1]["String"] = dt.Rows[i]["string"].ToString();
                }
          
            gvsinglleverificationEdit.DataSource = dt1;
            i1 = 1;
            gvsinglleverificationEdit.DataBind();
            gvsinglleverificationEdit.Columns[1].Visible = false;
            lblMulorSingValue.Visible = true;
            lblMsg.Visible = true;
            lblMsg.Text = "Please select rows";
        }

       
      
        txtComparingValue.Text = "";
        foreach (GridViewRow gvRow in gvSingleVerification.Rows)
        {

            CheckBox chk;
            chk = (CheckBox)gvRow.FindControl("chkngvVerification");
            chk.Checked = false;

        }
    
    }
    protected void gvSindgleColumnStringVerification_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        dt = (DataTable)(ViewState["v2"]);
        
        dt.Rows[e.RowIndex].Delete();
        DataTable dt1 = new DataTable();
        //dt1.Columns.Add("verification");
        dt1.Columns.Add("Verification");
        dt1.Columns.Add("String in Template");
       
        DataRow row1;
        row1 = dt1.NewRow();

        for (int i = 0; i < dt.Rows.Count; i++)
        {
            dt1.Rows.Add();
            dt1.Rows[dt1.Rows.Count - 1]["Verification"] = dt.Rows[i]["verification"].ToString();
            dt1.Rows[dt1.Rows.Count - 1]["String in Template"] = dt.Rows[i]["String in Template"].ToString();
            //dt1.Rows[dt1.Rows.Count - 1]["verification"] = dt.Rows[i]["verification"].ToString();
           
        }
        gvSindgleColumnStringVerification.DataSource = dt1;
        gvSindgleColumnStringVerification.DataBind();
        ViewState["v2"] = dt;
    }
    protected void gvStringVerification_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            LinkButton link1 = (LinkButton)e.Row.FindControl("lnkTemplate");

            link1.Attributes.Add("onclick", "javascript:return " +
                          "confirm('Are you sure you want to delete this record')");
        }
    }
    protected void gvSindgleColumnStringVerification_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        string strsql = "";
        string strsql1 = "";
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            
            strsql = "SELECT VERIFICATION_TYPE_CODE FROM  VERIFICATION_TYPE_MASTER WHERE (VERIFICATION_TYPE_ID IN (2,3))";
        }
    }
    protected void gvsinglleverificationEdit_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void gvsinglleverificationEdit_RowDataBound(object sender, GridViewRowEventArgs e)
    {
       
        if (str == "")
        {
            string strsql = "";
            string selected1 = "";
            if (i1 == 0)
            {
                dt.Columns.Add("String in Template");
                dt.Columns.Add("verificationID");
            }
            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                string[] hidvalue = hidverificationid.Value.Split('+');


                strsql = "SELECT VERIFICATION_TYPE_CODE FROM  VERIFICATION_TYPE_MASTER WHERE (VERIFICATION_TYPE_ID IN (" + hidvalue[i1 - 1] + "))";
                if (hidvalue[i1 - 1] != "")
                {
                    OleDbDataReader dr;
                    dr = OleDbHelper.ExecuteReader(con.ConnectionString, CommandType.Text, strsql);


                    while (dr.Read())
                    {
                        selected1 = selected1 + dr[0].ToString() + ",";
                        dt.Rows[i1 - 1]["verificationID"] = hidvalue[i1 - 1];
                    }


                    e.Row.Cells[1].Text = selected1.TrimEnd(',');
                    dt.Rows[i1 - 1]["String in Template"] = selected1.TrimEnd(',');

                }


            }
            i1++;
            ViewState["v4"] = dt;
            ViewState["v2"] = dt;
            
            
        }
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            LinkButton link1 = (LinkButton)e.Row.FindControl("lnkTemplate");

            link1.Attributes.Add("onclick", "javascript:return " +
                          "confirm('Are you sure you want to delete this record')");
        }
        
    }

    protected void gvsinglleverificationEdit_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        if (Request.QueryString["template_Id"] != null)
        {
           if (btnAddSingleColumn.Visible == true)
           {
            
                dt = (DataTable)ViewState["v2"];
                conObject.TemplateID = Request.QueryString["template_Id"];
                conObject.VerificationTypeID = dt.Rows[e.RowIndex]["verificationID"].ToString();

                dt.Rows[e.RowIndex].Delete();

                //conObject.DeleteVerificationString();
                GrdBound();

                gvsinglleverificationEdit.Columns[1].Visible = false;
                str = "delete";
                lblMulorSingValue.Visible = true;
                gvsinglleverificationEdit.DataBind();
                ViewState["v2"] = dt;
            }
            if (btnAddMultiColumn.Visible == true)
            {
 
            }
       
        }
       
    }
    protected void txtSepareator_TextChanged(object sender, EventArgs e)
    {

    }
    protected void gvStringVerification_Sorting(object sender, GridViewSortEventArgs e)
    {

    }
    protected void gvSindgleColumnStringVerification_Sorting(object sender, GridViewSortEventArgs e)
    {

    }
    public void GrdBound()
    {
        DataTable dt1 = new DataTable();
        //dt1.Columns.Add("verification");
        dt1.Columns.Add("String in Template");
        dt1.Columns.Add("String");
        DataRow row1;
        row1 = dt1.NewRow();
       
            for ( int i = 0; i < dt.Rows.Count; i++)
            {
                dt1.Rows.Add();
                dt1.Rows[dt1.Rows.Count - 1]["String in Template"] = dt.Rows[i]["String in Template"].ToString();
                //dt1.Rows[dt1.Rows.Count - 1]["verification"] = dt.Rows[i]["verification"].ToString();
                dt1.Rows[dt1.Rows.Count - 1]["String"] = dt.Rows[i]["String"].ToString();
            }
       

        //gvSindgleColumnStringVerification.DataSource = dt1;
        gvsinglleverificationEdit.DataSource = dt1;
        gvSindgleColumnStringVerification.AllowSorting = false;
    }
    public void gvMultibound()
    {
        DataTable dt1 = new DataTable();
        dt1.Columns.Add("String");
        dt1.Columns.Add("Comparing Value");
        dt1.Columns.Add("Verification");
        DataRow row1;
        row1 = dt1.NewRow();
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            dt1.Rows.Add();
            dt1.Rows[dt1.Rows.Count - 1]["String"] = dt.Rows[i]["String"].ToString();
            dt1.Rows[dt1.Rows.Count - 1]["Comparing Value"] = dt.Rows[i]["Comparing Value"].ToString();
            dt1.Rows[dt1.Rows.Count - 1]["Verification"] = dt.Rows[i]["Verification"].ToString();

        }
        gvStringVerification.DataSource = dt1;
        gvSindgleColumnStringVerification.AllowSorting = false;
    }
    
}
