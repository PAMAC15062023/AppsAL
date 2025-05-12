using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class Pages_JFS_cisc_number : System.Web.UI.Page
{
    string ABCT;
    string box1;
    DataTable dt = new DataTable();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Context.Request.QueryString["Auto_Application_No"] != null)
        {
            lblapp_number.Text = Context.Request.QueryString["Auto_Application_No"];
            getdate();
            create_data();

          
            //DataRow dr = null;

            //dt.Columns.Add(new DataColumn("RowNumber", typeof(string)));

            //dt.Columns.Add(new DataColumn("Column1", typeof(string)));

            //dt.Columns.Add(new DataColumn("Column2", typeof(string)));

            //dt.Columns.Add(new DataColumn("Column3", typeof(string)));

            //dr = dt.NewRow();

            //dr["RowNumber"] = 1;

            //dr["Column1"] = string.Empty;

            //dr["Column2"] = string.Empty;

            //dr["Column3"] = string.Empty;

            //dt.Rows.Add(dr);

        }
    }
    public void getdate()
    {
        try
        {
            Object SaveUSERInfo = (Object)Session["UserInfo"];
            SqlConnection sqlCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);

            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlCon;
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.CommandText = "get_NO_of_customer";

            SqlDataAdapter sda = new SqlDataAdapter();
            sda.SelectCommand = sqlcmd;


            SqlParameter losno = new SqlParameter();
            losno.SqlDbType = SqlDbType.NVarChar;
            losno.Value = lblapp_number.Text.ToString();
            losno.ParameterName = "@auto_application_no";
            sqlcmd.Parameters.Add(losno);

            
            DataTable MyDs = new DataTable();
            sda.Fill(MyDs);
            if (MyDs.Rows.Count > 0)
            {
                txtno_cust.Text = MyDs.Rows[0]["NO_of_customer"].ToString();
            }
            else
            {
                txtno_cust.Text =null;  
            }

        }
        catch
        {

        }
    
    }
    public void create_data12()
    {
        try
        {
            
            string s = "Manswini,Abhijeet,Ajendra";
            // Split string on spaces.
            // ... This will separate all the words.
            string[] words = s.Split(',');

            int abc=  words.Length;
          //int abc= Convert.ToInt32(txtno_cust.Text);
            for (int A = 0; A < abc; A++)
            {
                dt.Columns.Add("Name" + A);
                dt.Rows.Add("Mike");               
            }
            grddata.DataSource = dt;
            grddata.DataBind();                    
       
        }
        catch (Exception ex)
        {
        }
    }

    public void create_data()
    {
        try
        {
            int abc = Convert.ToInt32(txtno_cust.Text);
            for (int k = 0; k < abc; k++)
            {
                TextBox TxtBoxU = new TextBox();
                TxtBoxU.ID = "TextBoxU" + k.ToString();
                pnldemo.Controls.Add(TxtBoxU);
            }

        }
        catch (Exception ex)
        {
        }
    }
    public void savedata()
    {
        try
        {
            foreach (TextBox textBox in pnldemo.Controls.OfType<TextBox>())
            {
                Object SaveUSERInfo = (Object)Session["UserInfo"];
                SqlConnection sqlCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);

                SqlCommand sqlcmd = new SqlCommand();
                sqlcmd.Connection = sqlCon;
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.CommandText = "insert_Csisnumber12";
                sqlcmd.CommandTimeout = 0;

                int abc = Convert.ToInt32(txtno_cust.Text);

                for (int j = 0; j < 1; j++)
                {
                    if (textBox.Text != "")
                    {
                        string box1 = textBox.Text.ToString();
                        ABCT += box1 + ',';

                        SqlParameter ci_no = new SqlParameter();
                        ci_no.SqlDbType = SqlDbType.VarChar;
                        ci_no.Value = ABCT;
                        ci_no.ParameterName = "@ci_no1";
                        sqlcmd.Parameters.Add(ci_no);

                        SqlParameter Auto_Application_No = new SqlParameter();
                        Auto_Application_No.SqlDbType = SqlDbType.VarChar;
                        Auto_Application_No.Value = lblapp_number.Text.ToString();
                        Auto_Application_No.ParameterName = "@app_no";
                        sqlcmd.Parameters.Add(Auto_Application_No);

                        sqlCon.Open();
                        int RowEffected = 0;
                        RowEffected = sqlcmd.ExecuteNonQuery();
                        sqlCon.Close();

                        if (RowEffected > 0)
                        {
                            lblmsg.Text = "Numbers added Sueccfully";
                            savescanningupdate();
                        }
                    }

                    else
                    {
                        lblmsg.Text = "Please Enter All CSIS NUMBER";
                    }
                }
            }


        }
        catch (Exception ex)
        {
        }
    }
    //public void savedata()
    //{
    //    try
    //    {
    //        foreach (TextBox textBox in pnldemo.Controls.OfType<TextBox>())
    //         {
    //        Object SaveUSERInfo = (Object)Session["UserInfo"];
    //        SqlConnection sqlCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);

    //        SqlCommand sqlcmd = new SqlCommand();
    //        sqlcmd.Connection = sqlCon;
    //        sqlcmd.CommandType = CommandType.StoredProcedure;
    //        sqlcmd.CommandText = "insert_Csisnumber12";
    //        sqlcmd.CommandTimeout = 0;

    //        int abc = Convert.ToInt32(txtno_cust.Text);
                         
    //        for (int j = 0; j < 1; j++)
    //        {
    //          string box1 = textBox.Text.ToString();
    //          ABCT += box1 + ',';
    //        }
    //        //if (ABCT.Length < 11)
    //        //{
    //            SqlParameter ci_no = new SqlParameter();
    //            ci_no.SqlDbType = SqlDbType.VarChar;
    //            ci_no.Value = ABCT;
    //            ci_no.ParameterName = "@ci_no1";
    //            sqlcmd.Parameters.Add(ci_no);

    //            SqlParameter Auto_Application_No = new SqlParameter();
    //            Auto_Application_No.SqlDbType = SqlDbType.VarChar;
    //            Auto_Application_No.Value = lblapp_number.Text.ToString();
    //            Auto_Application_No.ParameterName = "@app_no";
    //            sqlcmd.Parameters.Add(Auto_Application_No);

    //            sqlCon.Open();
    //            int RowEffected = 0;
    //            RowEffected = sqlcmd.ExecuteNonQuery();
    //            sqlCon.Close();

    //            if (RowEffected > 0)
    //            {
    //                lblmsg.Text = "Numbers added Sueccfully";
    //                savescanningupdate();
    //            }
    //        //}
    //        //else
    //        //{
    //        //    lblmsg.Text = "error";
            
    //        //}
    //      }
    //    }      
    //    catch (Exception ex)
    //    {

    //    }

    //}
    protected void txtsave_Click(object sender, EventArgs e)
    {
        savedata();      
    }
    protected void btncancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("Scanning.aspx");
    }
    protected void ddlstatus_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlstatus.SelectedValue.ToString() == "Received with Query")
        {
            txtremark.Visible = true;

        }
        else if (ddlstatus.SelectedValue.ToString() == "Received")
        {
            txtremark.Visible = false;
        }
    }
    public void savescanningupdate()
    {
        try
        {
            Object SaveUSERInfo = (Object)Session["UserInfo"];
            SqlConnection sqlCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);

                    SqlCommand sqlcmd = new SqlCommand();
                    sqlcmd.Connection = sqlCon;
                    sqlcmd.CommandType = CommandType.StoredProcedure;
                    sqlcmd.CommandText = "sp_scanningSave";
                    sqlcmd.CommandTimeout = 0;

                    SqlParameter Auto_Application_No = new SqlParameter();
                    Auto_Application_No.SqlDbType = SqlDbType.VarChar;
                    Auto_Application_No.Value=lblapp_number.Text.Trim().ToString();
                    Auto_Application_No.ParameterName = "@Auto_Application_No";
                    sqlcmd.Parameters.Add(Auto_Application_No);

                    SqlParameter scan_status = new SqlParameter();
                    scan_status.SqlDbType = SqlDbType.VarChar;
                    scan_status.Value=ddlstatus.SelectedValue.ToString();
                    scan_status.ParameterName = "@Scanning_status";
                    sqlcmd.Parameters.Add(scan_status);

                    SqlParameter remark = new SqlParameter();
                    remark.SqlDbType = SqlDbType.VarChar;
                    remark.Value = txtremark.Text.Trim().ToString();
                    remark.ParameterName = "@Remark";
                    sqlcmd.Parameters.Add(remark);

                    SqlParameter add_by = new SqlParameter();
                    add_by.SqlDbType = SqlDbType.VarChar;
                    add_by.Value = Convert.ToString(((UserInfo.structUSERInfo)(SaveUSERInfo)).UserId);
                    add_by.ParameterName = "@scanning_done_by";
                    sqlcmd.Parameters.Add(add_by);

                    if (ddlstatus.SelectedValue.ToString() == "Received with Query" && txtremark.Text.Trim().ToString() == "")
                    {
                        lblmsg.Text = "Please enter remark";
                    }
                    else
                    {
                        sqlCon.Open();
                        int RowEffected = 0;

                        RowEffected = sqlcmd.ExecuteNonQuery();
                        lblmsg.Text = "Data Updated Successfuly !!!!!!!";

                        sqlCon.Close();
                    }
                }                 
        catch
        {
        }

    }
    
}