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
//--for CrystalReports's ReportDocument.
using CrystalDecisions.Shared;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Web;
using CrystalDecisions.ReportSource;
using System.IO;


//crystaldecisions.crystalreports.engine.dll. 
//crystaldecisions.reportsource.dll 
//crystaldecisions.shared.dll 
//crystaldecisions.web.dll

public partial class CrystalReportviewer : System.Web.UI.Page
{
    CCommon objCmm = new CCommon();
    CrystalReportDocument myReportDocument = new CrystalReportDocument();
    protected void Page_Load(object sender, EventArgs e)
    {
        //try
        //{
            if (crViewer != null)
            {
                crViewer.Dispose();
            }
            ////--Initializing CrystalReport
            CrystalReportDocument myReportDocument;

            myReportDocument = new CrystalReportDocument();
            if ((Context.Session["ParameterCollection"] != null) && (Context.Session["ParameterCollection"].ToString() != ""))
                crViewer.ParameterFieldInfo = (ParameterFields)Session["ParameterCollection"];
            else
                crViewer.ParameterFieldInfo.Clear();

            ////Response.Write(Session["Path"].ToString());
            myReportDocument.Load(Session["Path"].ToString());
            myReportDocument.SetDataSource(Session["dataset"]);
            //--Binding report with CrystalReportViewer            
            crViewer.ReportSource = myReportDocument;
            crViewer.DataBind();
            
        //}
        //catch (Exception ex)
        //{
            //lblMsg.Visible = true;
            //lblMsg.Text = ex.Message.ToString();            
        //}
    }

protected void Page_Dispose(object sender, EventArgs e)
{
    myReportDocument.Dispose();
    crViewer.Dispose();
}

 protected void crViewer_Unload(object sender, EventArgs e)
    {
        myReportDocument.Clone();
        myReportDocument.Dispose();

    }
    protected void btnBack_Click(object sender, EventArgs e)
    {
        if ((Request.QueryString["bckPgURL"] != null) && (Request.QueryString["bckPgURL"].ToString()!=""))
        {
            Response.Redirect(Request.QueryString["bckPgURL"].ToString());
        }
    }
}
