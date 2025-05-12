using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Reflection;
using CrystalDecisions.CrystalReports.Engine;

/// <summary>
/// Summary description for CrystalReportDocument
/// </summary>
public sealed class CrystalReportDocument : ReportDocument, IDisposable
{

    /// <summary>
    /// Frees resources used
    /// </summary>
    public new void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
        base.Dispose();
    }

    private void CleanGlobalEvents()
    {
        Delegate domainUnloadDelegate = (Delegate)typeof(AppDomain).GetField("_domainUnload",
           BindingFlags.Instance | BindingFlags.NonPublic).GetValue(AppDomain.CurrentDomain);

        Delegate[] invocationList = domainUnloadDelegate.GetInvocationList();
        Delegate ev;


        for (short i = 0; i < invocationList.Length; i++)
        {
            ev = invocationList[i];
            if (ev.Target != null && ev.Target.Equals(this))
            {
                AppDomain.CurrentDomain.DomainUnload -= (EventHandler)ev;
            }

        }


        Delegate processExitDelegate = (Delegate)typeof(AppDomain).GetField("_processExit",
           BindingFlags.Instance | BindingFlags.NonPublic).GetValue(AppDomain.CurrentDomain);

        invocationList = processExitDelegate.GetInvocationList();

        for (short i = 0; i < invocationList.Length; i++)
        {
            ev = invocationList[i];
            if (ev.Target != null && ev.Target.Equals(this))
            {
                AppDomain.CurrentDomain.ProcessExit -= (EventHandler)ev;

            }
        }
    }


    /// <summary>
    /// Cleans up resources
    /// </summary>
    /// <param name="disposing"></param>
    protected override void Dispose(bool disposing)
    {
        if (disposing)
        {
            this.Close();
        }
        this.CleanGlobalEvents();
        base.Dispose(disposing);
    }

    /// <summary>
    /// Destructs object
    /// </summary>
    ~CrystalReportDocument()
    {
        // Simply call Dispose(false).
        Dispose(false);
    }

}

