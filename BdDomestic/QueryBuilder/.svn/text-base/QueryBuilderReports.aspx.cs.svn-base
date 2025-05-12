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
using CrystalDecisions.Shared;
using CrystalDecisions.CrystalReports.Engine;

public partial class QueryBuilder_QueryBuilderReports : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        using (OleDbConnection conn = new OleDbConnection(ConfigurationManager.ConnectionStrings["CMConnectionString"].ConnectionString))
        {
            conn.Open();
           

            ReportDocument rd = new ReportDocument();
            ConnectionInfo crConnectionInfo = new ConnectionInfo();
            crConnectionInfo.ServerName = ConfigurationManager.AppSettings.Get("ServerName");
            crConnectionInfo.UserID = ConfigurationManager.AppSettings.Get("UserID");
            crConnectionInfo.Password = ConfigurationManager.AppSettings.Get("Password");
            crConnectionInfo.DatabaseName = ConfigurationManager.AppSettings.Get("DatabaseName");
            rd.Load(Server.MapPath(Session["rptName"].ToString()));
            CrystalDecisions.CrystalReports.Engine.Tables crTables = rd.Database.Tables;
            for (int j = 0; j < crTables.Count; j++)
            {
                CrystalDecisions.CrystalReports.Engine.Table crTable = crTables[j];
                TableLogOnInfo crTableLogOnInfo = crTable.LogOnInfo;
                crTableLogOnInfo.ConnectionInfo = crConnectionInfo;
                crTable.ApplyLogOnInfo(crTableLogOnInfo);
                crTable.Location = crConnectionInfo.DatabaseName + ".dbo." + crTable.Name;

            }
            CrystalReportViewer1.ParameterFieldInfo = (ParameterFields)Session["Parameterfields"];
            CrystalReportViewer1.ReportSource = rd;


        }
    }
}
