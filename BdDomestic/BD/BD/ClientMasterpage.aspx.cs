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
using System.Data.SqlClient;
//using System.Configuration;
//using System.Data;
//using MSCaptcha;


public partial class BD_BD_ClientMasterpage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {

        }

    }


    protected void btnInsert_Click(object sender, EventArgs e)
    {

        Insert();

    }


    protected void Insert()
    {
        try
        {
            CCommon oCmn = new CCommon();
          

             OleDbConnection conn = new OleDbConnection(oCmn.ConnectionString);
             OleDbCommand spCmd = new OleDbCommand("client_master_BDDOMESTIC", conn);
             spCmd.CommandType = CommandType.StoredProcedure;
             conn.Open();
              
                 spCmd.Parameters.AddWithValue("@CLIENT_CODE", textclientcode.Text.Trim());
                  spCmd.Parameters.AddWithValue("@CLIENT_NAME", textclientname.Text.Trim());
                  spCmd.Parameters.AddWithValue("@INT_TYPE", "1");
                int rowsAffected = spCmd.ExecuteNonQuery();
                conn.Close();
            labelerror.Visible = true;
            if(rowsAffected >0)
            {    
            labelerror.Text = "Record Inserted Successfully";
            }
            else
            {
                labelerror.Text = "Records Not Inserted";
            }

        }
        catch (Exception ex)
        {
            labelerror.Visible = true;
            labelerror.Text = ex.ToString();
        }

    }


   
}
