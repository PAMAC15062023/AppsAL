using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
 
/// <summary>
/// Summary description for ReportCredentials
/// </summary>
 
    public class ReportCredentials : Microsoft.Reporting.WebForms.IReportServerCredentials 
    {

        string _userName, _password, _domain;

        public ReportCredentials(string userName, string password, string domain)
        {

            _userName = userName;

            _password = password;

            _domain = domain;

        }
        public System.Security.Principal.WindowsIdentity ImpersonationUser
        {

            get
            {

                return null;

            }

        } 
        public System.Net.ICredentials NetworkCredentials
        {

            get
            {

                return new System.Net.NetworkCredential(_userName, _password, _domain);

            }

        }  
        public bool GetFormsCredentials(out System.Net.Cookie authCoki, out string userName, out string password, out string authority)
        {

            userName = _userName;

            password = _password;

            authority = _domain;

            authCoki = new System.Net.Cookie(".ASPXAUTH", ".ASPXAUTH", "/", "Domain");

            return true;

        }

    }
 
