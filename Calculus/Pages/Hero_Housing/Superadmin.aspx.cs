using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.IO;
using System.Drawing;

public partial class Pages_Hero_Housing_Superadmin : System.Web.UI.Page
{
    string proc;
    string flagstage = "";
    //SingleUserLogin Login = new SingleUserLogin();
    protected void Page_Load(object sender, EventArgs e)
    {
        

       

        //if (Session["UserInfo"] == null)
        //{
        //    Response.Redirect("~/Pages/Logout.aspx");

        //    Response.AppendHeader("Refresh", "2");
        //}


        if (!IsPostBack)
        {
            GetUploadList();

            Getuserlist();

        }

        Response.AppendHeader("Refresh", "30");


    }
    protected void ddlQueue_SelectedIndexChanged(object sender, EventArgs e)
    {


         if (ddlQueue.SelectedValue.ToString() == "Reinitiate Cases")
        {

            Object SaveUSERInfo = (Object)Session["UserInfo"];
            SqlConnection sqlCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);
            try
            {

                sqlCon.Open();
                SqlCommand sqlCom2 = new SqlCommand();
                sqlCom2.Connection = sqlCon;
                sqlCom2.CommandType = CommandType.StoredProcedure;
                sqlCom2.CommandText = "Hero_Housing_ReInititate_SP";


                SqlDataAdapter adp = new SqlDataAdapter();
                adp.SelectCommand = sqlCom2;
                DataTable dt = new DataTable();
                adp.Fill(dt);
                grdlos.DataSource = dt;
                grdlos.DataBind();

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
    
    protected void btnExport_Click(object sender, EventArgs e)
    {
       
    }
   


    public void Getuserlist()
    {

        Object SaveUSERInfo = (Object)Session["UserInfo"];
        SqlConnection sqlCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);
        try
        {

            sqlCon.Open();
            SqlCommand sqlCom2 = new SqlCommand();
            sqlCom2.Connection = sqlCon;
            sqlCom2.CommandType = CommandType.StoredProcedure;
            sqlCom2.CommandText = "Hero_Housing_GetUserLists_SP";

            SqlDataAdapter adp = new SqlDataAdapter();
            adp.SelectCommand = sqlCom2;
            DataTable dt = new DataTable();
            adp.Fill(dt);
            ddlUserlist.DataSource = dt;
            ddlUserlist.DataTextField="userid";
            ddlUserlist.DataBind();

        }
        catch (Exception)
        {

            throw;
        }
    }
    
    protected void btnsumbit_Click(object sender, EventArgs e)
    {
        Object SaveUSERInfo = (Object)Session["UserInfo"];
        SqlConnection sqlCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);

        try
        {
            if (ddlUserlist.SelectedValue!="")
            {
              
                if (ddlapptyp.SelectedValue.ToString()=="DATAENTRY" && ddlQueue.SelectedValue.ToString()=="COMPLETED")
                {
                    flagstage = "DataEntry";
                }
               
                else
                {
                    flagstage = "CAM";
                }

                for (int i = 0; i <= grdlos.Rows.Count - 1; i++)
                {


                    CheckBox chkSelect = grdlos.Rows[0].Cells[0].FindControl("chk") as CheckBox;
                    HdnCase.Value = grdlos.Rows[i].Cells[1].Text.Trim();



                    if (chkSelect.Checked == true)
                    {


                        SqlCommand sqlCom = new SqlCommand();
                        sqlCom.Connection = sqlCon;
                        sqlCom.CommandType = CommandType.StoredProcedure;
                        sqlCom.CommandText = "Hero_Housing_Assign_SP";
                        sqlCom.CommandTimeout = 0;

                        if (ddlUserlist.SelectedValue!="")
                        {
                            SqlParameter UserID = new SqlParameter();
                            UserID.SqlDbType = SqlDbType.VarChar;
                            UserID.Value = ddlUserlist.SelectedValue.ToString();
                            UserID.ParameterName = "@UserID";
                            sqlCom.Parameters.Add(UserID);
                        }
                        else
                        {
                            hiddenResult.Value = "Please Select User...";
                            return;
                        }

                        SqlParameter CaseNo = new SqlParameter();
                        CaseNo.SqlDbType = SqlDbType.VarChar;
                        CaseNo.Value = HdnCase.Value;
                        CaseNo.ParameterName = "@Loan_App_No";
                        sqlCom.Parameters.Add(CaseNo);

                        SqlParameter flag = new SqlParameter();
                        flag.SqlDbType = SqlDbType.VarChar;
                        flag.Value = flagstage;
                        flag.ParameterName = "@flag";
                        sqlCom.Parameters.Add(flag);

                        sqlCon.Open();
                        int K = 0;
                        K = sqlCom.ExecuteNonQuery();

                        sqlCon.Close();
                        if (K > 0)
                        {
                            hiddenResult.Value = "Request Assign To :" + ddlUserlist.SelectedValue.ToString();
                            ddlUserlist.BackColor = System.Drawing.Color.FromName("White");
                            ddlUserlist.BackColor = System.Drawing.Color.FromName("White");
                        }
                        else
                        {
                            hiddenResult.Value = "Request Already In Process or Not assign to same maker user";
                            ddlUserlist.BackColor = System.Drawing.Color.FromName("White");
                            ddlUserlist.BackColor = System.Drawing.Color.FromName("White");
                        }

                    }
                    else
                    {
                        lblCount.Text = "Please select Check box ";
                        lblCount.Visible = true;
                    }
                }
            }
            else
            {
                hiddenResult.Value = "Please Select User Name...";
                return;
            }
           
        }
        catch (Exception ex)
        {
            hiddenResult.Value = ex.Message;

        }
    }
    protected void btncancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Pages/Menu.aspx", true);
    }
    protected void ddlassignuser_SelectedIndexChanged(object sender, EventArgs e)
    {
        
    }
  
   
   

    public void GetUploadList()
    {

        Object SaveUSERInfo = (Object)Session["UserInfo"];
        SqlConnection sqlCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);
        try
        {

            sqlCon.Open();
            SqlCommand sqlCom2 = new SqlCommand();
            sqlCom2.Connection = sqlCon;
            sqlCom2.CommandType = CommandType.StoredProcedure;
            sqlCom2.CommandText = "Hero_Housing_GetUploadData_SP";

            SqlDataAdapter adp = new SqlDataAdapter();
            adp.SelectCommand = sqlCom2;
            DataTable dt = new DataTable();
            adp.Fill(dt);
            grdlos.DataSource = dt;
            grdlos.DataBind();

        }
        catch (Exception)
        {

            throw;
        }
    }
    protected void ddlapptyp_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlapptyp.SelectedValue.ToString()=="DATAENTRY")
        {


            Object SaveUSERInfo = (Object)Session["UserInfo"];
            SqlConnection sqlCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);
            try
            {

                sqlCon.Open();
                SqlCommand sqlCom2 = new SqlCommand();
                sqlCom2.Connection = sqlCon;
                sqlCom2.CommandType = CommandType.StoredProcedure;
                sqlCom2.CommandText = "Hero_Housing_GetDataEntry_SP";

                SqlDataAdapter adp = new SqlDataAdapter();
                adp.SelectCommand = sqlCom2;
                DataTable dt = new DataTable();
                adp.Fill(dt);
                grdlos.DataSource = dt;
                grdlos.DataBind();

            }
            catch (Exception)
            {

                throw;
            }
        }
        else
        {

            Object SaveUSERInfo = (Object)Session["UserInfo"];
            SqlConnection sqlCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);
            try
            {

                sqlCon.Open();
                SqlCommand sqlCom2 = new SqlCommand();
                sqlCom2.Connection = sqlCon;
                sqlCom2.CommandType = CommandType.StoredProcedure;
                sqlCom2.CommandText = "Hero_Housing_GetCamEntry_SP";    

                SqlDataAdapter adp = new SqlDataAdapter();
                adp.SelectCommand = sqlCom2;
                DataTable dt = new DataTable();
                adp.Fill(dt);
                grdlos.DataSource = dt;
                grdlos.DataBind();

            }
            catch (Exception)
            {

                throw;
            }
        
        }
    }
  
}