using System;
using System.Data;
using System.Data.OleDb;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.IO;
using System.Text;
using System.Configuration.Assemblies;



public partial class CPV_CC_QueryBuilder : System.Web.UI.Page
{
    CQueryBuilder obj = new CQueryBuilder();
    public int icount = 0;
    public bool flag = false;
    public string strSelect = "";
    public string strWhere = "";
    public static DataTable dt = new DataTable();
    public string strMsg = "";
    string QueryToRun = "";
    
   
    protected void Page_Load(object sender, EventArgs e)
    {   
        ViewState["Type"] = "";
        lblMsg.Visible = false;
       //string g=  Session["CentreId"].ToString();
    }
    protected void btnGetReport_Click(object sender, EventArgs e)
    {
       //Select Critaria.....
        try
        {
            obj.ProductId = ddlProduct.SelectedValue;
            obj.GetValues();
            ViewState["View"] = obj.View;  
                ArrayList list = new ArrayList();
                for (int i = 0; i < CheckBoxListSelect.Items.Count; i++)
                {
                    if (CheckBoxListSelect.Items[i].Selected)
                    {
                        if (strSelect != "")
                        {
                            strSelect = strSelect + "," + CheckBoxListSelect.Items[i].Text;
                        }
                        else
                        {
                            strSelect = CheckBoxListSelect.Items[i].Text;
                        }
                    }
                }
                if (strSelect == "")
                {
                    strSelect = "*";
                }
                ViewState["SelectClause"] = strSelect;
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message.ToString()); 
        }
        
//End Of Select Critaria.

    //Where Critaria....
        try
        {         
          if(ddlClient.SelectedValue!="0")
            {               
                if (flag == false)
                {
                    strWhere = strWhere + " WHERE CLIENT_ID=" + ddlClient.SelectedValue;
                    flag = true;
                }
                else
                {
                    strWhere = strWhere + " AND CLIENT_ID=" + ddlClient.SelectedValue;
                    flag = true;
                }

            }
            if (ddlVerification.SelectedValue != "0")
            {
                if (flag == false)
                {
                    strWhere = strWhere + "WHERE VERIFICATION_TYPE_ID=" + ddlVerification.SelectedValue;
                    flag=true;
                }
                else
                {
                    strWhere = strWhere + " and VERIFICATION_TYPE_ID=" + ddlVerification.SelectedValue;
                    flag = true;
                }
            }
            if (txtFromDate.Text != "" && txtToDate.Text != "")
            {
                CCreditCardGenerateLabel objChkdate = new CCreditCardGenerateLabel();
                bool CompareDate = objChkdate.FunctioncompareDate(txtFromDate.Text, txtToDate.Text);
                if (CompareDate == true)
                {
                    if (flag == false)
                    {
                        strWhere = strWhere + "WHERE CASE_REC_DATETIME>='" + txtFromDate.Text + "' AND CASE_REC_DATETIME <='" + txtToDate.Text + "' ";
                        flag = true;
                    }
                    else
                    {
                        strWhere = strWhere + " AND CASE_REC_DATETIME>='" + txtFromDate.Text + "' AND CASE_REC_DATETIME <=" + txtToDate.Text + "'";
                        flag = true;
                    }
                }
                else
                {
                    icount = 1;
                    lblMsg.Visible = true;
                    lblMsg.Text = "FromDate Should be Less Than ToDate";
                }
            }
            if((txtFromDate.Text!="" && txtToDate.Text=="") ||(txtFromDate.Text=="" && txtToDate.Text!=""))
            {
                lblMsg.Visible = true;
                lblMsg.Text = "Select Both From Date and To Date  !!";             
                 gvdet.DataSource = "";
                 gvdet.AllowPaging = false;
                 gvdet.DataBind();
            }
            if (RbTAT.SelectedIndex != -1)
            {
                if (flag == false)
                {
                    if (RbTAT.SelectedValue == "0")
                    {
                        strWhere = strWhere + " WHERE WITHIN_TAT=0";
                        flag = false;
                    }
                    if (RbTAT.SelectedValue == "1")
                    {
                        strWhere = strWhere + "WHERE WITHIN_TAT=1";
                        flag = false;
                     }
                }
                else
                {
                    if (RbTAT.SelectedValue == "0")
                    {
                        strWhere = strWhere + " AND WITHIN_TAT=0";
                        flag = false;
                    }
                    if (RbTAT.SelectedValue == "1")
                    {
                        strWhere = strWhere + "AND WITHIN_TAT=1";
                        flag = false;
                    }
                }
            }           
            if(ViewState["View"].ToString()!="")
            {
             QueryToRun="SELECT "+strSelect +" from "+ ViewState["View"]+' '+ strWhere+" ";
             ViewState["QueryToRun"] = QueryToRun;
             dt = obj.Result(QueryToRun);
             gvdet.DataSource = dt;
             gvdet.DataBind();
             int i = dt.Rows.Count;
             if (i == 0)
             {
                 icount = 3;
             }
             if (i > 0)
             {
                 icount = 4;
             }
            }
            else
            {
                lblMsg.Visible = true;
                lblMsg.Text = "  View Does Not Exist In DataBase !! ";
                gvdet.DataSource = "";
                gvdet.AllowPaging = false;
                gvdet.DataBind();
            }
        }  
        catch (Exception ex)
        {
            Response.Write(ex.Message.ToString());
        }
        if (icount == 4)
        {            
            Panel1.Visible = true;
        }
        if (icount == 1)
        {
            lblMsg.Visible = true;
            lblMsg.Text = "FromDate Should be Less Than ToDate";
           
        }
        if (icount == 3)
        {
            lblMsg.Visible = true;
            lblMsg.Text = "No Record Found !!";
        }
        else
        {
        }
        
    }
    protected void btnExport_Excel_Click(object sender, EventArgs e)
    {
        string attachment = "attachment; filename=Contacts.xls";
        Response.ClearContent();
        Response.AddHeader("content-disposition", attachment);
        Response.ContentType = "application/ms-excel";
        StringWriter sw = new StringWriter();
    
        HtmlTextWriter htw = new HtmlTextWriter(sw);
       
        gvdet.RenderControl(htw);
        Response.Write(sw.ToString());
        Response.End(); 
    }
    public override void VerifyRenderingInServerForm(Control control)
    {

    }

    protected void btnShow_Click(object sender, EventArgs e)
    {
        try
        {
            lblMsg.Text = "";
            DataSet ds = new DataSet();
            obj.ProductId = ddlProduct.SelectedValue;
            ds = obj.GetValues();
            ViewState["View"] = obj.View;
            if (ViewState["View"].ToString() != "")
            {
                int i = ds.Tables[0].Rows.Count;
                CheckBoxListSelect.DataSource = ds.Tables[0];
                CheckBoxListSelect.DataTextField = "name";
                CheckBoxListSelect.DataBind();
                pnlSelect.Visible = true;
            }
            else
            {
                lblMsg.Visible = true;
                lblMsg.Text = "View Does Not Exist In DataBase !!";
                gvdet.DataSource = "";
                gvdet.AllowPaging = false;
                gvdet.DataBind();
                CheckBoxListSelect.DataSource = "";
                CheckBoxListSelect.DataBind();
            }
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message.ToString());
        }
    }

    protected void gvdet_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvdet.PageIndex = e.NewPageIndex;
        gvdet.DataSource = dt;
        gvdet.DataBind();
    }
    protected void gvdet_Sorting(object sender, GridViewSortEventArgs e)
    {
        string stype = "";
        string SortType = "";
        DataView dv = new DataView(dt);
        SortType = e.SortExpression;
       
        //ViewState["Type"] = "Ascending";

        if (stype == "D")
        {
            ViewState["Type"] = "Descending";
        }
        else if (stype == "A")
        {
            ViewState["Type"] = "Ascending";
        }

        if (ViewState["Type"].ToString() == "Ascending" || ViewState["Type"].ToString()=="")
        {   
            dv.Sort = SortType + " " + "ASC";
            stype = "D";
        }
        if (ViewState["Type"].ToString() == "Descending")
        {
            dv.Sort = SortType + " " + "Desc";
            stype = "A";
        }


        //string st =(SortDirection) gvdet.SortDirection;
        //dv.Sort = SortType + " " + "DESC";
        //e.SortExpression = SortDirection.Descending;
        gvdet.DataSource = dv;
        gvdet.DataBind();
     
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("QueryBuilder.aspx");
    }
    protected void ddlProduct_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            DataTable Vdt = new DataTable();
            obj.ProductId = ddlProduct.SelectedValue;
            Vdt = obj.GetVerificationType();

            ddlVerification.DataSource = Vdt;
            ddlVerification.Items.Insert(0, new ListItem("Select", "0"));
            ddlVerification.DataValueField = "VERIFICATION_TYPE_ID";
            ddlVerification.DataTextField = "VERIFICATION_TYPE_CODE";
            ddlVerification.DataBind();
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message.ToString());
        }
    }
    protected void ddlClient_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void btnSaveResult_Click(object sender, EventArgs e)
    {
        if (Panel1.Visible == false)
        {
            lblMsg.Visible = true;
            lblMsg.Text = "First Genrate The Report !!";
        }
        else
        {
            TD1.Visible = true;
            TD2.Visible = true;
            TD3.Visible = true;
            TD4.Visible = true;
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            if (btnSave.Text == "OK")
            {
                obj.TemplateName = txtTemplate.Text;
                obj.QueryToRun = ViewState["QueryToRun"].ToString();
                obj.View = ViewState["View"].ToString();
                obj.SelectClause = ViewState["SelectClause"].ToString();
                obj.ProductId = ddlProduct.SelectedValue;
                obj.ClientID = ddlClient.SelectedValue;
                obj.VerificationTypeID = ddlVerification.SelectedValue;
                obj.REC_FromDate = txtFromDate.Text;
                obj.REC_ToDate = txtToDate.Text;
                if (RbStatus.SelectedValue == "")
                {
                    obj.Status = null;
                }
                else
                {
                    obj.Status = RbStatus.SelectedValue;
                }
                if (RbTAT.SelectedValue == "")
                {
                    obj.WithinTAT = null;
                }
                else
                {
                    obj.WithinTAT = RbStatus.SelectedValue;
                }

                bool flag = false;
                string Result = obj.SaveResult();
                if (Result == "Save")
                {
                    lblMsg.Visible = true;
                    lblMsg.Text = "Template Saved Sucessfully !!";
                    gvTemplate.DataBind();

                }
                else if (Result == "Duplicate")
                {
                    lblMsg.Visible = true;
                    lblMsg.Text = "Same Name Template Can Not Be Created Again !!";
                    gvTemplate.DataBind();

                }
                else if (Result == "Error")
                {
                    lblMsg.Visible = true;
                    lblMsg.Text = "Error Occured While Inserting Record!!";
                }
            }
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message.ToString());
        }

        //Updating Records.....
        try
        {
            if (btnSave.Text == "Update")
            {
                if (Panel1.Visible == true)
                {
                    ArrayList list = new ArrayList();
                    for (int i = 0; i < CheckBoxListSelect.Items.Count; i++)
                    {
                        if (CheckBoxListSelect.Items[i].Selected)
                        {
                            if (strSelect != "")
                            {
                                strSelect = strSelect + "," + CheckBoxListSelect.Items[i].Text;
                            }
                            else
                            {
                                strSelect = CheckBoxListSelect.Items[i].Text;
                            }
                        }
                    }
                    if (strSelect == "")
                    {
                        strSelect = "*";
                    }

                    try
                    {
                        if (ddlClient.SelectedValue != "0")
                        {
                            if (flag == false)
                            {
                                strWhere = strWhere + " WHERE CLIENT_ID=" + ddlClient.SelectedValue;
                                flag = true;
                            }
                            else
                            {
                                strWhere = strWhere + " AND CLIENT_ID=" + ddlClient.SelectedValue;
                                flag = true;
                            }

                        }
                        if (ddlVerification.SelectedValue != "0")
                        {
                            if (flag == false)
                            {
                                strWhere = strWhere + "WHERE VERIFICATION_TYPE_ID=" + ddlVerification.SelectedValue;
                                flag = true;
                            }
                            else
                            {
                                strWhere = strWhere + " and VERIFICATION_TYPE_ID=" + ddlVerification.SelectedValue;
                                flag = true;
                            }
                        }
                        if (txtFromDate.Text != "" && txtToDate.Text != "")
                        {
                            CCreditCardGenerateLabel objChkdate = new CCreditCardGenerateLabel();
                            bool CompareDate = objChkdate.FunctioncompareDate(txtFromDate.Text, txtToDate.Text);
                            if (CompareDate == true)
                            {
                                if (flag == false)
                                {
                                    strWhere = strWhere + "WHERE CASE_REC_DATETIME>='" + txtFromDate.Text + "' AND CASE_REC_DATETIME <='" + txtToDate.Text + "' ";
                                    flag = true;
                                }
                                else
                                {
                                    strWhere = strWhere + " AND CASE_REC_DATETIME>='" + txtFromDate.Text + "' AND CASE_REC_DATETIME <=" + txtToDate.Text + "'";
                                    flag = true;
                                }
                            }
                            else
                            {
                                icount = 1;
                                lblMsg.Visible = true;
                                lblMsg.Text = "FromDate Should be Less Than ToDate";
                            }
                        }
                        if ((txtFromDate.Text != "" && txtToDate.Text == "") || (txtFromDate.Text == "" && txtToDate.Text != ""))
                        {
                            lblMsg.Visible = true;
                            lblMsg.Text = "Select Both From Date and To Date  !!";
                            gvdet.DataSource = "";
                            gvdet.AllowPaging = false;
                            gvdet.DataBind();
                        }
                        if (RbTAT.SelectedIndex != -1)
                        {
                            if (flag == false)
                            {
                                if (RbTAT.SelectedValue == "0")
                                {
                                    strWhere = strWhere + " WHERE WITHIN_TAT=0";
                                    flag = false;
                                }
                                if (RbTAT.SelectedValue == "1")
                                {
                                    strWhere = strWhere + "WHERE WITHIN_TAT=1";
                                    flag = false;
                                }
                            }
                            else
                            {
                                if (RbTAT.SelectedValue == "0")
                                {
                                    strWhere = strWhere + " AND WITHIN_TAT=0";
                                    flag = false;
                                }
                                if (RbTAT.SelectedValue == "1")
                                {
                                    strWhere = strWhere + "AND WITHIN_TAT=1";
                                    flag = false;
                                }
                            }
                        }

                        string P_view = obj.GetPreviousViewName(ViewState["TemplateName"].ToString());
                        ViewState["PreviousView"] = P_view;

                        if (ViewState["PreviousView"].ToString() != "")
                        {
                            QueryToRun = "SELECT " + strSelect + " from " + ViewState["PreviousView"] + ' ' + strWhere + " ";
                            obj.QueryToRun = QueryToRun;
                            obj.SelectClause = strSelect;
                            obj.ClientID = ddlClient.SelectedValue;
                            obj.VerificationTypeID = ddlVerification.SelectedValue;
                            if (txtFromDate.Text == "")
                            {
                                obj.REC_FromDate = null;
                            }
                            else
                            {
                                obj.REC_FromDate = txtFromDate.Text;
                            }
                            if (txtToDate.Text == "")
                            {
                                obj.REC_ToDate = null;
                            }
                            else
                            {
                                obj.REC_ToDate = txtToDate.Text;
                            }
                            if (RbStatus.SelectedValue == "")
                            {
                                obj.Status = null;
                            }
                            else
                            {
                                obj.Status = RbStatus.SelectedValue;
                            }
                            if (RbTAT.SelectedValue == "")
                            {
                                obj.WithinTAT = null;
                            }
                            else
                            {
                                obj.WithinTAT = RbStatus.SelectedValue;
                            }
                            bool flag = false;
                            flag = obj.UpdateResult(ViewState["TemplateName"].ToString());
                            if (flag == true)
                            {
                                lblMsg.Visible = true;
                                lblMsg.Text = "Records Updated Sucessfully !!";

                            }
                            if (flag == false)
                            {
                                lblMsg.Visible = true;
                                lblMsg.Text = "Error in Updating Records!!";
                            }

                        }
                    }
                    catch (Exception ex)
                    {
                    }
                }
                else
                {
                    lblMsg.Visible = true;
                    lblMsg.Text = "First Genrate The Report!!";
                }
            }
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message.ToString());
        }
    }

    protected void gvTemplate_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "btnSelect")
        {
            string TemplateName = e.CommandArgument.ToString();
            DataTable dt = new DataTable();
            dt = obj.GetTemplateValue(TemplateName);
            Panel1.Visible = true;
            
            gvdet.DataSource = dt;
            gvdet.DataBind();
        }
        if (e.CommandName == "btnEdit")
        {
            DataSet ds = new DataSet();
            Hashtable Ht = new Hashtable();
            string TemplateName = e.CommandArgument.ToString();
            ViewState["TemplateName"] = e.CommandArgument.ToString();
            obj.TemplateName = TemplateName;
            string intProductId = Convert.ToString(obj.GetProductID());
            obj.ProductId = intProductId;
            ds = obj.GetValues();
            CheckBoxListSelect.DataSource = ds.Tables[0];
            CheckBoxListSelect.DataTextField = "name";
            CheckBoxListSelect.DataBind();
            string selectedvalues = obj.GetTemplateSelectClause();

            string[] getSelected = selectedvalues.Split(',');
            
            for(int x=0;x<getSelected.Length;x++)
            {
                Ht.Add(getSelected[x], "1");
            }
            int count = CheckBoxListSelect.Items.Count;
            for (int i = 0; i < count; i++)
            {
                if (Ht[CheckBoxListSelect.Items[i].Value] != null)
                    CheckBoxListSelect.Items[i].Selected = true;
           }
           obj.GetExtraEditValues(TemplateName);
           ddlProduct.SelectedValue = obj.ProductId;
           ddlClient.SelectedValue = obj.ClientID;
           ddlVerification.SelectedValue = obj.VerificationTypeID;
           txtFromDate.Text = obj.REC_FromDate;
           txtToDate.Text = obj.REC_ToDate;
           RbStatus.SelectedValue = obj.Status;
           RbTAT.SelectedValue = obj.Status;

           DataTable Vdt = new DataTable();
           obj.ProductId = ddlProduct.SelectedValue;
           Vdt = obj.GetVerificationType();

           ddlVerification.DataSource = Vdt;
           ddlVerification.Items.Insert(0, new ListItem("Select", "0"));
           ddlVerification.DataValueField = "VERIFICATION_TYPE_ID";
           ddlVerification.DataTextField = "VERIFICATION_TYPE_CODE";
           ddlVerification.DataBind();
           
            btnSave.Visible = true;
            TD4.Visible = true;
            btnSave.Text = "Update";
       

        }
        if (e.CommandName == "btnDel")
        {
            string TemplateName = e.CommandArgument.ToString();
            bool flag = false;
            flag = obj.DeleteTemplate(TemplateName);
            if (flag == true)
            {
                lblMsg.Visible = true;
                lblMsg.Text = "Template Deleted Sucessfully !!";
                gvTemplate.DataBind();
            }
            else
            {
                lblMsg.Visible = true;
                lblMsg.Text = "Template Not Deleted !!";
            }
        }
    }   
}
