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
using System.Web.Services.Protocols;
using Microsoft.Reporting.WebForms;
using System.IO;


public partial class Pages_Calculus_ReportRender : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserInfo"] == null)
        {
            Response.Redirect("~/Pages/InvalidRequest.aspx");

        }
        if (Request.QueryString.Count == 6)
        {

            string[] arr = new string[5];
            arr[0] = Request.QueryString["1"];
            arr[1] = Request.QueryString["2"].Replace("&", " and "); ;
            arr[2] = Request.QueryString["3"];
            arr[3] = Request.QueryString["4"];
            arr[4] = Request.QueryString["5"];

            string pReportName = Request.QueryString["6"];
            Render_Local_Report(arr, pReportName.Trim());
            Page.Header.Title = pReportName;

        }
    }


    private void Render_Report_Server(string[] Param, string ReportPath)
    {
        Microsoft.Reporting.WebForms.ReportViewer rview = new Microsoft.Reporting.WebForms.ReportViewer();
        rview.ServerReport.ReportServerUrl = new Uri(ConfigurationSettings.AppSettings["ReportServer"]);
        System.Collections.Generic.List<Microsoft.Reporting.WebForms.ReportParameter> paramList = new System.Collections.Generic.List<Microsoft.Reporting.WebForms.ReportParameter>();

        ReportParameter[] RptParameters = new ReportParameter[5];
        RptParameters[0] = new ReportParameter("CrossChequeValue", Param[0]);
        RptParameters[1] = new ReportParameter("ChequeIssueTo", Param[1]);
        RptParameters[2] = new ReportParameter("ChequeDate", Param[2]);
        RptParameters[3] = new ReportParameter("AmountInWord", Param[3]);
        RptParameters[4] = new ReportParameter("ChequeAmount", Param[4]);

       //rview.ServerReport.ReportServerCredentials = new ReportCredentials(@"Administrator", "$Pms$Admin$", "PAMAC");
        
        rview.ServerReport.ReportPath = ReportPath;
        rview.ServerReport.SetParameters(RptParameters); 

        string mimeType, encoding, extension, deviceInfo;

        string[] streamids;
        Microsoft.Reporting.WebForms.Warning[] warnings;

        string format = "PDF"; //Desired format goes here (PDF, Excel, or Image)
        deviceInfo = "<DeviceInfo>" + "<SimplePageHeaders>True</SimplePageHeaders>" + "</DeviceInfo>";
        byte[] bytes = rview.ServerReport.Render(format, deviceInfo, out mimeType, out encoding, out extension, out streamids, out warnings);
        Response.Clear();

        if (format == "PDF")
        {

            Response.ContentType = "application/pdf";
            Response.AddHeader("Content-disposition", "filename=output.pdf");
        }
        else if (format == "Excel")
        {

            Response.ContentType = "application/excel";
            Response.AddHeader("Content-disposition", "filename=output.xls");

        }

        Response.OutputStream.Write(bytes, 0, bytes.Length);
        Response.OutputStream.Flush();
        Response.OutputStream.Close();
        Response.Flush();
        Response.Close();
    }

    private void Render_Local_Report(string[] Param, string ReportPath)
    {
        Microsoft.Reporting.WebForms.ReportViewer rview = new Microsoft.Reporting.WebForms.ReportViewer();
       
       
        string fullSitePath = this.Request.PhysicalApplicationPath;
        fullSitePath = fullSitePath + "Pages\\Calculus\\Reports\\";

        string URL = fullSitePath + ReportPath;
        rview.LocalReport.ReportPath = URL.ToString();
       
        System.Collections.Generic.List<Microsoft.Reporting.WebForms.ReportParameter> paramList = new System.Collections.Generic.List<Microsoft.Reporting.WebForms.ReportParameter>();

        ReportParameter[] RptParameters = new ReportParameter[5];
        RptParameters[0] = new ReportParameter("CrossChequeValue", Param[0]);
        RptParameters[1] = new ReportParameter("ChequeIssueTo", Param[1]);
        RptParameters[2] = new ReportParameter("ChequeDate", Param[2]);
        RptParameters[3] = new ReportParameter("AmountInWord", Param[3]);
        RptParameters[4] = new ReportParameter("ChequeAmount", Param[4]);

        rview.LocalReport.SetParameters(RptParameters);

        string mimeType, encoding, extension, deviceInfo;

        string[] streamids;
        Microsoft.Reporting.WebForms.Warning[] warnings;

        string format = "PDF"; //Desired format goes here (PDF, Excel, or Image)
        deviceInfo = "<DeviceInfo>" + "<SimplePageHeaders>True</SimplePageHeaders>" + "</DeviceInfo>";
        byte[] bytes = rview.LocalReport.Render(format, deviceInfo, out mimeType, out encoding, out extension, out streamids, out warnings);
        Response.Clear();

        if (format == "PDF")
        {

            Response.ContentType = "application/pdf";
            Response.AddHeader("Content-disposition", "filename=output.pdf");
            
        }
        else if (format == "Excel")
        {

            Response.ContentType = "application/excel";
            Response.AddHeader("Content-disposition", "filename=output.xls");
            

        }

        Response.OutputStream.Write(bytes, 0, bytes.Length);
        Response.OutputStream.Flush();
        Response.OutputStream.Close();
        Response.Flush();
        Response.Close();
    }

}
