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
using Microsoft.Reporting.WebForms;



public partial class Pages_Calculus_ReportViewer : System.Web.UI.Page
{
     
     


    
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserInfo"] == null)
        {
            Response.Redirect("~/Pages/InvalidRequest.aspx");

        }
        if (Request.QueryString.Count==6)
        { 
            

            string[] arr = new string[5];
            arr[0] = Request.QueryString["1"];
            arr[1] = Request.QueryString["2"];
            arr[2] = Request.QueryString["3"];
            arr[3] = Request.QueryString["4"];
            arr[4] = Request.QueryString["5"];

            string pReportName=Request.QueryString["6"];            

            Page.Header.Title = pReportName.Replace("rdlc","");

            string ReportPath = String.Concat("ReportRender.aspx?1=", arr[0].ToString(), "&2=", arr[1].ToString(), "&3=", arr[2].ToString(), "&4=", arr[3].ToString(), "&5=", arr[4].ToString(), "&6=", pReportName);
             
            IFrame1.Attributes.Add("src", ReportPath);
                                
        }
    }

    //private void Generate_Report(string[] Param,string ReportPath)
    //{
    //    string strURLPath = Convert.ToString(ConfigurationSettings.AppSettings["ReportServer"]);
       
    //    ReportParameter[] RptParameters = new ReportParameter[5];
    //    RptParameters[0] = new ReportParameter("CrossChequeValue", Param[0]);
    //    RptParameters[1] = new ReportParameter("ChequeIssueTo", Param[1]);
    //    RptParameters[2] = new ReportParameter("ChequeDate", Param[2]);
    //    RptParameters[3] = new ReportParameter("AmountInWord", Param[3]);
    //    RptParameters[4] = new ReportParameter("ChequeAmount", Param[4]);

         
    //    rptViewer.ShowCredentialPrompts = false;
    //    //ReportViewer1.ServerReport.ReportServerCredentials= //new ReportCredentials(@"PAMACIT3\it3", "infy@123e123", "PAMACIT3");
    //    rptViewer.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Remote;
    //    rptViewer.ServerReport.ReportServerUrl = new System.Uri(strURLPath);
    //    rptViewer.ServerReport.ReportPath = ReportPath;

    //    rptViewer.ServerReport.SetParameters(RptParameters);
    //    rptViewer.ServerReport.Refresh();
         
    //    string mimeType;
    //    string encoding;
        
    //    byte[] result = rptViewer.ServerReport.RenderStream("PDF", string.Empty, string.Empty, out mimeType, out encoding);
         

    //}
}
