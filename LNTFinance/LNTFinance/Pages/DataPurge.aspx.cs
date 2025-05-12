using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LNTFinance.Pages
{
    public partial class DataPurge : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnTruncate_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtTillDate.Text != "")
                {
                    Object SaveUSERInfo = (Object)Session["UserInfo"];

                    SqlConnection sqlcon = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);

                    SqlCommand sqlcmd = new SqlCommand();
                    sqlcmd.Connection = sqlcon;
                    sqlcmd.CommandType = CommandType.StoredProcedure;
                    sqlcmd.CommandText = "LNT_LTFS_IP_DataPurge_SP";
                    sqlcmd.CommandTimeout = 0;

                    SqlParameter TillDate = new SqlParameter();
                    TillDate.SqlDbType = SqlDbType.VarChar;
                    TillDate.Value = strDate(txtTillDate.Text.Trim());
                    TillDate.ParameterName = "@TillDate";
                    sqlcmd.Parameters.Add(TillDate);

                    SqlParameter UserID = new SqlParameter();
                    UserID.SqlDbType = SqlDbType.VarChar;
                    UserID.Value = Session["LoginName"];
                    UserID.ParameterName = "@PurgedBy";
                    sqlcmd.Parameters.Add(UserID);


                    SqlParameter ClientID = new SqlParameter();
                    ClientID.SqlDbType = SqlDbType.VarChar;
                    ClientID.Value = Session["ClientID"];
                    ClientID.ParameterName = "@ClientID";
                    sqlcmd.Parameters.Add(ClientID);

                    sqlcon.Open();

                    int i = sqlcmd.ExecuteNonQuery();

                    if (i > 0)
                    {
                        lblMessage.Text = "Data Purged Sucessfully...!";
                        lblMessage.ForeColor = System.Drawing.Color.Green;
                        txtTillDate.Text = "";
                    }
                    else
                    {
                        lblMessage.Text = "Data already Purged Till Date " + txtTillDate.Text.Trim() + " ...!";
                        lblMessage.ForeColor = System.Drawing.Color.Red;
                    }
                    sqlcon.Close();
                }
                else
                {
                    lblMessage.Text = "Please select till date...!";
                    lblMessage.ForeColor = System.Drawing.Color.Red;
                }
            }
            catch (Exception ex)
            {
                lblMessage.Text = ex.ToString();
                lblMessage.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            txtTillDate.Text = "";
            Response.Redirect("MenuPage.aspx", false);
        }
        public string strDate(string strInDate)
        {
            string strDD = strInDate.Substring(0, 2);

            string strMM = strInDate.Substring(3, 2);

            string strYYYY = strInDate.Substring(6, 4);

            string strYYYYMMDD = strYYYY + "-" + strMM + "-" + strDD;

            //string strMMDDYYYY = strDD + "/" + strMM + "/" + strYYYY;

            DateTime dtConvertDate = Convert.ToDateTime(strYYYYMMDD);

            string strOutDate = dtConvertDate.ToString("yyyy-MM-dd");

            return strOutDate;
        }
    }
}