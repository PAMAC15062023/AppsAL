using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using YesBankAmended;

namespace AxisBank.Pages
{
    public partial class grid_authentication : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GenerateRandomText();

            }
        }
        private void GenerateRandomText()
        {
            string randomText = GenerateRandomString();
            Session["Grid"] = randomText;
            txtGridA.Text = randomText.Substring(0, 1);
            txtGridB.Text = randomText.Substring(1, 1);
            txtGridC.Text = randomText.Substring(2, 1);
            //   DrawImage(randomText);
        }
        private string GenerateRandomString()
        {
            var rand = new Random();
            string chars = "ABCDEFGHIJKLMNOPQRSTUVWX";
            var s = new string(chars.OrderBy(x => rand.Next()).Take(3).ToArray());
            return s;// new String(stringChars);
        }
        protected void btnVerify_Click(object sender, EventArgs e)
        {
            if ((txtGrid1.Text == "") || (txtGrid2.Text == "") || (txtGrid3.Text == ""))
            {
                lblMessage.Text = "Please fill all grid values";
            }
            else
            {
                string userid = Convert.ToString(Session["UserID"]);
                String cha1 = txtGridA.Text;
                String cha2 = txtGridB.Text;
                String cha3 = txtGridC.Text;
                string val1 = txtGrid1.Text;
                string val2 = txtGrid2.Text;
                string val3 = txtGrid3.Text;

                SqlConnection sqlCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);

                sqlCon.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = sqlCon;
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.CommandText = "SP_getUserGridValues";
                cmd.CommandTimeout = 0;
                cmd.Parameters.AddWithValue("@cha1", cha1);
                cmd.Parameters.AddWithValue("@cha2", cha2);
                cmd.Parameters.AddWithValue("@cha3", cha3);
                cmd.Parameters.AddWithValue("@val1", RAS_EncDec.GetMD5(val1));
                cmd.Parameters.AddWithValue("@val2", RAS_EncDec.GetMD5(val2));
                cmd.Parameters.AddWithValue("@val3", RAS_EncDec.GetMD5(val3));
                cmd.Parameters.AddWithValue("@userid", userid);

                SqlDataAdapter dp = new SqlDataAdapter(cmd);
                DataTable dt2 = new DataTable();
                dp.Fill(dt2);

                DataRow dr = dt2.Rows[0];

                string cnt = dr["cnt"].ToString();
                if (cnt == "1")
                {
                    int RoleID = Convert.ToInt32(Session["RoleID"]);
                    if (RoleID == 1)
                    {
                        Response.Redirect("CDMA_Menu.aspx", true);
                    }
                    else if (RoleID == 2)
                    {
                        Response.Redirect("CDMA_Menu.aspx", true);
                    }
                }
                else
                {
                    lblMessage.Text = "Sorry wrong credentials";
                }


            }
        }
    }
}