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

public partial class Assets_Header : System.Web.UI.Page
{
    protected void Page_Init(object sender, EventArgs e)
    {
        if (Session.Count == 0)
            Response.Redirect("../../Default.aspx?Message='Session expires.Please login again.'");
    }
    OleDbConnection connection;
    string constring;

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
                        constring = ConfigurationManager.ConnectionStrings["CMConnectionString"].ToString();
                        connection = new OleDbConnection(constring);
                        string hierarchy = "SELECT DISTINCT CENTRE_NAME,ACTIVITY_NAME,PRODUCT_NAME,CLIENT_NAME FROM CE_AC_PR_CT_VW WHERE " +
                                         " CENTRE_ID=? AND ACTIVITY_ID=? AND PRODUCT_ID=? AND CLIENT_ID=?";
                        OleDbParameter[] param = new OleDbParameter[4];
                        param[0] = new OleDbParameter("Centre_id", OleDbType.VarChar);
                        param[0].Value = Session["CenreId"].ToString();
                        param[1] = new OleDbParameter("Activity_id", OleDbType.VarChar);
                        param[1].Value = Session["ActivityId"].ToString();
                        param[2] = new OleDbParameter("product_id", OleDbType.VarChar);
                        param[2].Value = Session["ProductId"].ToString();
                        param[3] = new OleDbParameter("client_id", OleDbType.VarChar);
                        param[3].Value = Session["ClientId"].ToString();
                        OleDbDataReader DDR = OleDbHelper.ExecuteReader(connection, CommandType.Text, hierarchy, param);
                        if (DDR.Read())
                        {
                            lblHierarchy.Text = DDR["Activity_Name"].ToString() + " - " +
                                                DDR["Product_Name"].ToString() + " -" +
                                                DDR["Centre_Name"].ToString() + " - " +
                                                DDR["Client_Name"].ToString();
                        }
                        DDR.Close();
                        lblDate.Text = System.DateTime.Now.ToString("MMMM dd, yyyy hh:mm:tt");
                        if (Session["FLName"] != null)
                        {
                            if (Session["FLNAME"].ToString() != "")
                            {
                                lblName.Text = Session["FLName"].ToString();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
            }
        }
    }
}
