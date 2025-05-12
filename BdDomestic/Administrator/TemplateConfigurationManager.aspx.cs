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
using System.Drawing;
using System.Drawing.Printing;

public partial class TemplateConfigurationManager : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["massage"] != null)
        {
            lblMsg.Text = (string)Session["massage"];
            Session["massage"] = null;
        }
        else
        {
            lblMsg.Text = "";
        }
        
    }
  
    protected void gvImport_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        CCommon con = new CCommon();
        String strTemplateID = "";
        string stractivity_id="";
        string strproduct_id="";
        string strclient_id="";
        string strtemplate_name="";
       
        string strColumnName = "";
        string strmultiplecolumn = "";
        string strmultiplevalue = "";
        string strCompareValue = "";
        string strtemplateName = "";
       
        if (e.CommandName == "Edit")
        {
            strTemplateID = e.CommandArgument.ToString();
            string strsql1 = "select template_name from import_data_master where template_id=" + e.CommandArgument.ToString();
            object o ;
            o = OleDbHelper.ExecuteScalar(con.ConnectionString, CommandType.Text, strsql1);
            strtemplate_name = (string)(o);
          


             string strsql4 = "select activity_id from import_data_master where template_id=" + e.CommandArgument.ToString();
           
            o = OleDbHelper.ExecuteScalar(con.ConnectionString, CommandType.Text, strsql4);
            stractivity_id = (string)(o);

            string strsql2 = "select product_id from import_data_master where template_id=" + e.CommandArgument.ToString();
            o = OleDbHelper.ExecuteScalar(con.ConnectionString, CommandType.Text, strsql2);
            strproduct_id = (string)(o);

            string strsql3 = "select client_id from import_data_master where template_id=" + e.CommandArgument.ToString();
            o = OleDbHelper.ExecuteScalar(con.ConnectionString, CommandType.Text, strsql3);
            strclient_id = (string)(o);

            //if (Session["isEdit"].ToString() == "1")
            //{
            if (strTemplateID != "")
            {
                Response.Redirect("TemplateConfiguration.aspx?Template_Id=" + strTemplateID + " &activity_id=" + stractivity_id + " &product_id=" + strproduct_id + " &client_id=" + strclient_id + " &template_name=" + strtemplate_name);
            }
            //}
            else
            {
                lblMsg.Text = "Access denied!";
            }

        }
        if (e.CommandName == "EditVerification")
        {
            strTemplateID = e.CommandArgument.ToString();
            string strsql1 = " select column_name from import_verification_master where template_id=" + e.CommandArgument.ToString();
            object o;
            o = OleDbHelper.ExecuteScalar(con.ConnectionString, CommandType.Text, strsql1);
            strColumnName = (string)(o);

            string strsql2 = " select multiple_column from import_verification_master where template_id=" + e.CommandArgument.ToString();

            o = OleDbHelper.ExecuteScalar(con.ConnectionString, CommandType.Text, strsql2);
            strmultiplecolumn = (string)(o);


            string strsql5 = " select distinct template_name from import_data_master where template_id=" + e.CommandArgument.ToString();

            o = OleDbHelper.ExecuteScalar(con.ConnectionString, CommandType.Text, strsql5);
            strtemplateName = (string)(o);


            string strsql3 = " select multiple_value from import_verification_master where template_id=" + e.CommandArgument.ToString() + " and multiple_value is not null ";

            o = OleDbHelper.ExecuteScalar(con.ConnectionString, CommandType.Text, strsql3);
            if (o != null)
            {
                strmultiplevalue = (string)(o);
            }

            string strsql4 = " select comparing_value from import_verification_master where template_id=" + e.CommandArgument.ToString() + " and comparing_value is not null";

            o = OleDbHelper.ExecuteScalar(con.ConnectionString, CommandType.Text, strsql4);

            if (o != null)
            {
                strCompareValue = (string)(o);
            }
            Response.Redirect("ConfigurationVerification.aspx?Template_Id=" + strTemplateID + " &column_name=" + strColumnName + " &multiple_column=" + strmultiplecolumn + " &multiple_values=" + strmultiplevalue + " &comparing_value=" + strCompareValue + " &template_name=" + strtemplateName);
        }
        if (e.CommandName == "Delete1")
        {
             
      
            if (e.CommandArgument.ToString() != "")
            {
                try
                {
                    CImportTemplate ojCit = new CImportTemplate();
                    ojCit.TemplateID= e.CommandArgument.ToString();
                    ojCit.DeleteTemplateAndVerificatio();
                    lblMsg.Text = "Template Deleted Successfully!";
                    gvImport.DataBind();
                }
                catch (Exception exp)
                {
                    lblMsg.Text = exp.Message;
                }
            }
        
        }
     
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        Response.Redirect("TemplateConfiguration.aspx");
    }
    protected void gvImport_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
          LinkButton  link1  = (LinkButton)e.Row.FindControl("lnkTemplateDelete");

            link1.Attributes.Add("onclick", "javascript:return " +
                          "confirm('Are you sure you want to delete this record')");
        }
    }
}
