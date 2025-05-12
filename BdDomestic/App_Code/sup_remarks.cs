using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.OleDb;

/// <summary>
/// Summary description for sup_remarks
/// </summary>
public class sup_remarks
{
        CCommon objconn = new CCommon();
        public sup_remarks()
	    {
		//
		// TODO: Add constructor logic here
		//
	    }
         private string RefNo;
         public string refno
          {
                get
                {
                     return RefNo;
                }
                 set
                 {
                    RefNo = value;

                  }
         }
         private string CaseId;
         public string caseid
            {
                 get
                 {
                     return CaseId;
                 }
                 set
                 {
                     CaseId = value;
                 }
            }
            private string overallStatus;
            public string OverallStatus
            {
                get
                {
                    return overallStatus;
                }
                set
                {
                    overallStatus = value;
                }
            }
            private string overallComments;
            public string OverallComments
            {
                get
                {
                    return overallComments;
                }
                set
                {
                    overallComments = value;
                }
            }
            private string productID;
            public string ProductID
            {
                get
                {
                    return productID;
                }
                set
                {
                    productID = value;
                }
            }
                //private string ApplicantName;
                //public string applicantname
                //{
                //     get
                //     {
                //         return ApplicantName;
                //     }
                //    set
                //     {
                //        ApplicantName = value;
                //     }
                //}
            private string CentreID;
            public string centreid
            {
                get
                 {
                     return CentreID;
                 }
                set
                {
                     CentreID = value;
                }
            }
                 private string ClientID;
                 public string clientid
                    {
                         get
                         {
                             return ClientID;
                         }
                        set
                         {
                                 ClientID = value;
                         }
                    }
                    private string todate;
                    public string Todate
                    {
                        get
                        {
                            return todate;
                        }
                        set
                        {
                            todate = value;
                        }
                    }
                    private string fromdate;
                    public string Fromdate
                    {
                        get
                        {
                            return fromdate;
                        }
                        set
                        {
                            fromdate = value;
                        }
                    }

  


    }

