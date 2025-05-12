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

public partial class HR_HR_DedupSearch : System.Web.UI.Page
{
    CBISENTRY CBE = new CBISENTRY();
    protected void Page_Load(object sender, EventArgs e)
    {
        DataSet ds = new DataSet();
        lblName.Text ="Dedup search for"+ Request.QueryString["FirstName"].ToString() + " " + Request.QueryString["LastName"].ToString();
        if (Request.QueryString["CentreID"] != "" && Request.QueryString["CentreID"] != null)
        {
            CBE.CentreID = Request.QueryString["CentreID"].ToString();
        }
        else
        {
            CBE.CentreID = Session["CentreID"].ToString();
            
        }
        CBE.ClusterID = Session["ClusterID"].ToString();
        string strRloeID = Session["RoleID"].ToString();
        string[] strRole1 = strRloeID.Split(',');
        foreach (string str in strRole1)
        {
            if (str == "24")
            {
                CBE.UserRole1 = "HO-HR";
            }
            if (str == "25")
            {
                if (CBE.UserRole1 != "HO-HR")
                {
                    CBE.UserRole1 = "Cluster-HR";
                }
            }
        }
        ds = CBE.DedupSearch(Request.QueryString["FirstName"], Request.QueryString["LastName"]);
        if (ds.Tables[0].Rows.Count <= 0)
        {
            lblmsg.Text = "No record found";
        }
        else
        {
            gvDedup.DataSource = ds;
            gvDedup.DataBind();
        }
       
    }
}
