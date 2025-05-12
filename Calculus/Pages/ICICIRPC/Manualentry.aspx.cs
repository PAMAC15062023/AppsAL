using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;


public partial class Pages_ICICIRPC_Manualentry : System.Web.UI.Page
{
    //SingleUserLogin Login = new SingleUserLogin();
    protected void Page_Load(object sender, EventArgs e)
    {
        //Login.ValidateTokenLoginDetails();
    }


    protected void btnsubmit_Click(object sender, EventArgs e)
    {
        Insert_ptpadd();
    }

    protected void btncancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Pages/Menu.aspx", true);
    }


    private void Insert_ptpadd()
    {
        Object SaveUSERInfo = (Object)Session["UserInfo"];

        SqlConnection sqlCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);

        try
        {
           
            sqlCon.Open();
            SqlCommand sqlCom = new SqlCommand();
            sqlCom.Connection = sqlCon;
            sqlCom.CommandType = CommandType.StoredProcedure;
            sqlCom.CommandText = "sp_importdata_icic";

            SqlParameter app_no = new SqlParameter();
            app_no.SqlDbType = SqlDbType.VarChar;
            app_no.Value = txtapp_no.Text.Trim();
            app_no.ParameterName = "@los_no";
            sqlCom.Parameters.Add(app_no);

            SqlParameter scan_date = new SqlParameter();
            scan_date.SqlDbType = SqlDbType.VarChar;
            scan_date.Value = txtscan_date.Text.Trim();
            scan_date.ParameterName = "@scan_date";
            sqlCom.Parameters.Add(scan_date);

            SqlParameter cus_name = new SqlParameter();
            cus_name.SqlDbType = SqlDbType.VarChar;
            cus_name.Value = txtcus_name.Text.Trim();
            cus_name.ParameterName = "@cus_name";
            sqlCom.Parameters.Add(cus_name);


            SqlParameter aps_id = new SqlParameter();
            aps_id.SqlDbType = SqlDbType.VarChar;
            aps_id.Value = txt_apsid.Text.Trim();
            aps_id.ParameterName = "@aps_id";
            sqlCom.Parameters.Add(aps_id);

           
            SqlParameter location = new SqlParameter();
            location.SqlDbType = SqlDbType.VarChar;
            location.Value = txt_location.Text.Trim();
            location.ParameterName = "@location";
            sqlCom.Parameters.Add(location);



            SqlParameter remarkfield = new SqlParameter();
            remarkfield.SqlDbType = SqlDbType.VarChar;
            remarkfield.Value = txtremark_field.Text.Trim();
            remarkfield.ParameterName = "@remarks_field";
            sqlCom.Parameters.Add(remarkfield);





            SqlParameter submittedby = new SqlParameter();
            submittedby.SqlDbType = SqlDbType.VarChar;
            submittedby.Value = txt_submittedby.Text.Trim();
            submittedby.ParameterName = "@submitted_by";
            sqlCom.Parameters.Add(submittedby);


            SqlParameter addedby = new SqlParameter();
            addedby.SqlDbType = SqlDbType.VarChar;
            addedby.Value = "P49506";
            addedby.ParameterName = "@add_by";
            sqlCom.Parameters.Add(addedby);



           


            int RowEffected = sqlCom.ExecuteNonQuery();
            sqlCon.Close();

            if (RowEffected > 0)
            {
                lblMsgXls.Text = "Data updated Successfully!";
                lblMsgXls.CssClass = "SuccessMessage";
            }
        }
        catch (Exception ex)
        {
            lblMsgXls.Visible = true;
            lblMsgXls.Text = ex.Message;
            lblMsgXls.CssClass = "ErrorMessage";
        }
        finally
        {
            sqlCon.Close();
            sqlCon.Dispose();
        }
    }


    

    
 
   
}