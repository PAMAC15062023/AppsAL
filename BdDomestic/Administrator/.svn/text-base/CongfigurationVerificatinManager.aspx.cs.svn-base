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

public partial class CongfigurationVerificatinManager : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
  
    protected void gvImport_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        CCommon con = new CCommon();
        String strTemplateID = "";
        string strColumnName="";
        string strmultiplecolumn="";
        string strmultiplevalue="";
        string strCompareValue = "";
        string strtemplateName = "";
        if (e.CommandName == "Edit")
        {
            strTemplateID = e.CommandArgument.ToString();
            string strsql1 = " select column_name from import_verification_master where template_id=" + e.CommandArgument.ToString();
            object o = new object();
            o = OleDbHelper.ExecuteScalar(con.ConnectionString, CommandType.Text, strsql1);
            strColumnName = (string)(o);

            string strsql2 = " select multiple_column from import_verification_master where template_id=" + e.CommandArgument.ToString();
      
            o = OleDbHelper.ExecuteScalar(con.ConnectionString, CommandType.Text, strsql2);
            strmultiplecolumn = (string)(o);


            string strsql5 = " select distinct template_name from import_data_master where template_id=" + e.CommandArgument.ToString();

            o = OleDbHelper.ExecuteScalar(con.ConnectionString, CommandType.Text, strsql5);
            strtemplateName = (string)(o);


            string strsql3 = " select multiple_value from import_verification_master where template_id=" + e.CommandArgument.ToString()+" and multiple_value is not null ";
           
            o = OleDbHelper.ExecuteScalar(con.ConnectionString, CommandType.Text, strsql3);
            if (o !=null)
            {
                strmultiplevalue = (string)(o);
            }

            string strsql4 = " select comparing_value from import_verification_master where template_id=" + e.CommandArgument.ToString() + " and comparing_value is not null";
             
            o = OleDbHelper.ExecuteScalar(con.ConnectionString, CommandType.Text, strsql4);

            if (o != null)
            {
                strCompareValue = (string)(o);
            }
            if (strTemplateID != "")
            {
                Response.Redirect("ConfigurationVerification.aspx?Template_Id=" + strTemplateID + " &column_name=" + strColumnName + " &multiple_column=" + strmultiplecolumn + " &multiple_values=" + strmultiplevalue + " &comparing_value=" + strCompareValue + " &template_name=" + strtemplateName);
            }
        }
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        Response.Redirect("ConfigurationVerification.aspx");
    }
}
