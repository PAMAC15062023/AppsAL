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
using System.Data.OleDb;

public partial class QueryBuilder_Header : System.Web.UI.Page
{
    protected void Page_Init(object sender, EventArgs e)
    {
        if (Session.Count == 0)
            Response.Redirect("../../Default.aspx?Message='Session expires. Please login again.'");
    }

    OleDbConnection connection;
    string connString;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            try
            {
                if (Session["CentreId"] != null && Session["ActivityId"] != null && Session["ProductId"] != null && Session["ClientId"] != null)
                {
                    if (Session["CentreId"].ToString() != "" && Session["ActivityId"].ToString() != "" && Session["ProductId"].ToString() != "" && Session["ClientId"].ToString() != "")
                    {
                        connString = ConfigurationManager.ConnectionStrings["CMConnectionString"].ToString();
                        connection = new OleDbConnection(connString);
                        string strHeirarchy = "SELECT DISTINCT CENTRE_NAME, ACTIVITY_NAME, PRODUCT_NAME, CLIENT_NAME FROM CE_AC_PR_CT_VW WHERE " +
                                                    "CENTRE_ID = ? AND ACTIVITY_ID=? AND PRODUCT_ID=? AND CLIENT_ID=?";

                        OleDbParameter[] paramHeirarchy = new OleDbParameter[4];
                        paramHeirarchy[0] = new OleDbParameter("CENTRE_ID", OleDbType.VarChar);
                        paramHeirarchy[0].Value = Session["CentreId"].ToString();
                        paramHeirarchy[1] = new OleDbParameter("ACTIVITY_ID", OleDbType.VarChar);
                        paramHeirarchy[1].Value = Session["ActivityId"].ToString();
                        paramHeirarchy[2] = new OleDbParameter("PRODUCT_ID", OleDbType.VarChar);
                        paramHeirarchy[2].Value = Session["ProductId"].ToString();
                        paramHeirarchy[3] = new OleDbParameter("CLIENT_ID", OleDbType.VarChar);
                        paramHeirarchy[3].Value = Session["ClientId"].ToString();

                        OleDbDataReader drHeirarchy = OleDbHelper.ExecuteReader(connection, CommandType.Text, strHeirarchy, paramHeirarchy);
                        if (drHeirarchy.Read())
                        {
                            lblHierarchy.Text = drHeirarchy["ACTIVITY_NAME"].ToString() + " - " +
                                                drHeirarchy["PRODUCT_NAME"].ToString() + " - " +
                                                drHeirarchy["CLIENT_NAME"].ToString() + " - " +
                                                drHeirarchy["CENTRE_NAME"].ToString();
                        }
                        drHeirarchy.Close();
                        lblDate.Text = System.DateTime.Now.ToString("MMMM dd, yyyy hh:mm:tt");
                        if (Session["FLName"] != null)
                        {
                            if (Session["FLName"].ToString() != "")
                            {
                                lblName.Text = Session["FLName"].ToString();
                            }
                        }
                    }
                }
            }
            catch (Exception exp)
            {
            }
        }

    }
}
