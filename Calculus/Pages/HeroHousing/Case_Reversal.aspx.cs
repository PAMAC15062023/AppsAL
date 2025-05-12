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

public partial class Pages_HeroHousing_Case_Reversal : System.Web.UI.Page
{
    string flagstage;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindLocation();
            BindRoll();

            if (ddlRoll.SelectedValue == "1")
            {
                Get_DEUserList();
                Get_DataForIndexing3();
            }

            else if (ddlRoll.SelectedValue == "2")
            {
                Get_UserListCAM();
                Get_DataForIndexing3();
            }
        }
    }
    protected void BindLocation()
    {
        SqlConnection sqlCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);

        SqlCommand cmd = new SqlCommand("HeroHousing_MasterSearchCode_SP", sqlCon);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@Types", "LocationType");
        cmd.Parameters.AddWithValue("@Level", 1);
        SqlDataAdapter adp = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        adp.Fill(ds);

        if (ds != null && ds.Tables[0].Rows.Count > 0)
        {
            ddllocation.DataSource = ds;
            ddllocation.DataValueField = "Code_Id";
            ddllocation.DataTextField = "Description";
            ddllocation.DataBind();            
        }
    }
    protected void BindRoll()
    {
        SqlConnection sqlCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);

        SqlCommand cmd = new SqlCommand("HeroHousing_MasterSearchCode_SP", sqlCon);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@Types", "RollType");
        cmd.Parameters.AddWithValue("@Level", 1);
        SqlDataAdapter adp = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        adp.Fill(ds);

        if (ds != null && ds.Tables[0].Rows.Count > 0)
        {
            ddlRoll.DataSource = ds;
            ddlRoll.DataValueField = "Code_Id";
            ddlRoll.DataTextField = "Description";
            ddlRoll.DataBind();
        }
    }
    protected void ddllocation_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlRoll.SelectedValue == "1")
        {
            Get_DEUserList();
            Get_DataForIndexing3();
        }

        else if (ddlRoll.SelectedValue == "2")
        {
            Get_UserListCAM();
            Get_DataForIndexing3();
        }
    }
    private void Get_DataForIndexing3()
    {

        Object SaveUSERInfo = (Object)Session["UserInfo"];
        SqlConnection sqlCon = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);

        try
        {

            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlCon;
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.CommandText = "HeroHousing_Data_Grid_Case_Complete_SP";
            sqlcmd.CommandTimeout = 0;


            SqlParameter BranchID = new SqlParameter();
            BranchID.SqlDbType = SqlDbType.VarChar;
            BranchID.Value = ddllocation.SelectedValue.ToString();
            BranchID.ParameterName = "@BranchID";
            sqlcmd.Parameters.Add(BranchID);

            HdnCase.Value = ddlRoll.SelectedValue.ToString();

            SqlParameter Roll = new SqlParameter();
            Roll.SqlDbType = SqlDbType.VarChar;
            Roll.Value = HdnCase.Value;
            Roll.ParameterName = "@Roll";
            sqlcmd.Parameters.Add(Roll);

            SqlDataAdapter sda = new SqlDataAdapter();
            sda.SelectCommand = sqlcmd;

            DataTable dt = new DataTable();
            sda.Fill(dt);

            sqlCon.Close();

            if (dt.Rows.Count > 0)
            {
                grdlos.DataSource = dt;
                grdlos.DataBind();


            }
            else
            {
                grdlos.DataSource = null;
                grdlos.DataBind();
            }
        }

        catch (SqlException sqlex)
        {
            hiddenResult.Value = sqlex.Message.ToString();
        }

        finally
        {
            sqlCon.Close();
            sqlCon.Dispose();
        }
    }
    protected void ddlRoll_SelectedIndexChanged(object sender, EventArgs e)
    {

        if (ddlRoll.SelectedValue == "1")
        {
            Get_DEUserList();
            Get_DataForIndexing3();
        }

        else if (ddlRoll.SelectedValue == "2")
        {
            Get_UserListCAM();
            Get_DataForIndexing3();
        }
    }
    private void Get_DEUserList()
    {
        Object SaveUSERInfo = (Object)Session["UserInfo"];
        SqlConnection sqlCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);


        try
        {


            SqlCommand sqlCom = new SqlCommand();
            sqlCom.Connection = sqlCon;
            sqlCom.CommandType = CommandType.StoredProcedure;
            sqlCom.CommandText = "HeroHousing_Get_UserDataEntry_SP";
            sqlCom.CommandTimeout = 0;


            SqlParameter PMSlocation = new SqlParameter();
            PMSlocation.SqlDbType = SqlDbType.VarChar;
            PMSlocation.Value = ddllocation.SelectedValue.ToString();
            PMSlocation.ParameterName = "@PMSlocation";
            sqlCom.Parameters.Add(PMSlocation);

            sqlCon.Open();

            SqlDataAdapter sqlDA = new SqlDataAdapter();
            sqlDA.SelectCommand = sqlCom;

            DataTable dt = new DataTable();
            sqlDA.Fill(dt);


            sqlCon.Close();

            ddlUserlist.DataTextField = "UserName";
            ddlUserlist.DataValueField = "UserID";

            ddlUserlist.DataSource = dt;
            ddlUserlist.DataBind();

            ddlUserlist.Items.Insert(0, new ListItem("--Select--", "0"));
            ddlUserlist.SelectedIndex = 0;


        }
        catch (Exception ex)
        {
            hiddenResult.Value = ex.Message;
        }
        finally
        {
            sqlCon.Close();
            sqlCon.Dispose();
        }
    }

    private void Get_UserListCAM()
    {
        Object SaveUSERInfo = (Object)Session["UserInfo"];
        SqlConnection sqlCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);


        try
        {


            SqlCommand sqlCom = new SqlCommand();
            sqlCom.Connection = sqlCon;
            sqlCom.CommandType = CommandType.StoredProcedure;
            sqlCom.CommandText = "HeroHousing_Get_UserCAM_SP";
            sqlCom.CommandTimeout = 0;


            SqlParameter PMSlocation = new SqlParameter();
            PMSlocation.SqlDbType = SqlDbType.VarChar;
            PMSlocation.Value = ddllocation.SelectedValue.ToString();
            PMSlocation.ParameterName = "@PMSlocation";
            sqlCom.Parameters.Add(PMSlocation);

            sqlCon.Open();

            SqlDataAdapter sqlDA = new SqlDataAdapter();
            sqlDA.SelectCommand = sqlCom;

            DataTable dt = new DataTable();
            sqlDA.Fill(dt);


            sqlCon.Close();

            ddlUserlist.DataTextField = "UserName";
            ddlUserlist.DataValueField = "UserID";

            ddlUserlist.DataSource = dt;
            ddlUserlist.DataBind();

            ddlUserlist.Items.Insert(0, new ListItem("--Select--", "0"));
            ddlUserlist.SelectedIndex = 0;


        }
        catch (Exception ex)
        {
            hiddenResult.Value = ex.Message;
        }
        finally
        {
            sqlCon.Close();
            sqlCon.Dispose();
        }
    }
    protected void btncancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Pages/Menu.aspx", true);
    }
    protected void btnsumbit_Click(object sender, EventArgs e)
    {

        Object SaveUSERInfo = (Object)Session["UserInfo"];
        SqlConnection sqlCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);

        try
        {
            if (ddlUserlist.SelectedIndex.ToString() != "0")
            {
                if ((ddlRoll.SelectedItem.Text == "Data Entry"))
                {
                    flagstage = "DATAENTRY";
                }
                else if ((ddlRoll.SelectedItem.Text == "CAM"))
                {
                    flagstage = "CAM";
                }
                else
                {
                }

                for (int i = 0; i <= grdlos.Rows.Count - 1; i++)
                {

                    CheckBox chkSelect = (CheckBox)grdlos.Rows[i].FindControl("chkSelect");
                    LinkButton WIP = (LinkButton)grdlos.Rows[i].FindControl("lnkWIP");
                    HdnAppno.Value = grdlos.Rows[i].Cells[1].Text.Trim();
                    if (chkSelect.Checked == true)
                    {
                        SqlCommand sqlCom = new SqlCommand();
                        sqlCom.Connection = sqlCon;
                        sqlCom.CommandType = CommandType.StoredProcedure;
                        sqlCom.CommandText = "HeroHousing_Assign_Rev_HERO_USER_SP";
                        sqlCom.CommandTimeout = 0;

                        if (ddlUserlist.SelectedIndex != 0)
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

                        SqlParameter AppNo = new SqlParameter();
                        AppNo.SqlDbType = SqlDbType.VarChar;
                        AppNo.Value = HdnAppno.Value;
                        AppNo.ParameterName = "@AppNo";
                        sqlCom.Parameters.Add(AppNo);

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
                            txtremark.Text = "";
                        }
                        else
                        {
                            hiddenResult.Value = "Request Already In Process :";
                            ddlUserlist.BackColor = System.Drawing.Color.FromName("White");
                            ddlUserlist.BackColor = System.Drawing.Color.FromName("White");
                        }

                    }
                    else
                    {

                    }
                }
            }
            else
            {
                hiddenResult.Value = "Please Select User Name...";
                return;
            }
            Get_DataForIndexing3();
        }
        catch (Exception ex)
        {
            hiddenResult.Value = ex.Message;

        }
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        Object SaveUSERInfo = (Object)Session["UserInfo"];
        SqlConnection sqlcon = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);

        SqlCommand cmd = new SqlCommand("HeroHousing_Data_Grid_Search_Case_Complete_SP", sqlcon);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandTimeout = 0;

        cmd.Parameters.AddWithValue("@BranchID", ddllocation.SelectedItem.Value);
        cmd.Parameters.AddWithValue("@App_No", txtremark.Text.ToString().Trim());

        sqlcon.Open();
        SqlDataAdapter sda = new SqlDataAdapter();
        sda.SelectCommand = cmd;

        DataTable dt = new DataTable();
        sda.Fill(dt);

        sqlcon.Close();

        if (dt.Rows.Count > 0)
        {
            grdlos.DataSource = dt;
            grdlos.DataBind();
        }
        else
        {
            txtremark.Text = "";
            grdlos.DataSource = null;
            grdlos.DataBind();
            hiddenResult.Value = "No Data Found..!!!";
            return;
        }
    }
}