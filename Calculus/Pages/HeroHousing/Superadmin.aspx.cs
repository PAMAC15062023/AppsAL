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

public partial class Pages_HeroHousing_Superadmin : System.Web.UI.Page
{
    string proc;
    string flagstage;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindLocation();
            BindRoll();
            BindProcessQueue();

            if (ddlRoll.SelectedValue == "1" && ddlQueueDE.SelectedItem.Value == "1")
            {
                ddlQueueDE.Visible = true;
                ddlQueueDE.SelectedValue = "1";
                ddlQueueDE.Items.FindByValue("CAM").Enabled = false;
                ddlQueueDE.Items.FindByValue("CAM_Hold").Enabled = false;
                ddlQueueDE.Items.FindByValue("Data_Entry").Enabled = true;
                ddlQueueDE.Items.FindByValue("Data_EntryHold").Enabled = true;
                Get_DEUserList();
                Get_DataForIndexing3();
            }
        }
        //Response.AppendHeader("Refresh", "30");
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
           

            ddlChangelocation.DataSource = ds;
            ddlChangelocation.DataValueField = "Code_Id";
            ddlChangelocation.DataTextField = "Description";
            ddlChangelocation.DataBind();
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
    protected void BindProcessQueue()
    {
        SqlConnection sqlCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);

        SqlCommand cmd = new SqlCommand("HeroHousing_MasterSearchCode_SP", sqlCon);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@Types", "ProcessQueueType");
        cmd.Parameters.AddWithValue("@Level", 1);
        SqlDataAdapter adp = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        adp.Fill(ds);

        if (ds != null && ds.Tables[0].Rows.Count > 0)
        {
            ddlQueueDE.DataSource = ds;
            ddlQueueDE.DataValueField = "Code_Id";
            ddlQueueDE.DataTextField = "Description";
            ddlQueueDE.DataBind();
            ddlQueueDE.Items.Insert(0, new ListItem("--Select--", "1"));
        }
    }


    protected void btnlocation_Click(object sender, EventArgs e)
    {

        Object SaveUSERInfo = (Object)Session["UserInfo"];

        SqlConnection sqlCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);

        try
        {
            if (ddllocation.SelectedIndex.ToString() != "0")
            {
                for (int i = 0; i <= grdlos.Rows.Count - 1; i++)
                {


                    CheckBox chkSelect = (CheckBox)grdlos.Rows[i].FindControl("chkSelect");

                    LinkButton WIP = (LinkButton)grdlos.Rows[i].FindControl("lnkWIP");

                    HdnAppno.Value = grdlos.Rows[i].Cells[1].Text.Trim();

                    if (chkSelect.Checked == true)
                    {


                        SqlCommand sqlCom1 = new SqlCommand();
                        sqlCom1.Connection = sqlCon;
                        sqlCom1.CommandType = CommandType.StoredProcedure;
                        sqlCom1.CommandText = "HeroHousing_Update_Hero_Location_SP";
                        sqlCom1.CommandTimeout = 0;

                        SqlParameter Rpclocation = new SqlParameter();
                        Rpclocation.SqlDbType = SqlDbType.VarChar;
                        Rpclocation.Value = ddlChangelocation.SelectedValue.ToString();
                        Rpclocation.ParameterName = "@branchid";
                        sqlCom1.Parameters.Add(Rpclocation);

                        SqlParameter LOSNo1 = new SqlParameter();
                        LOSNo1.SqlDbType = SqlDbType.VarChar;
                        LOSNo1.Value = HdnAppno.Value;
                        LOSNo1.ParameterName = "@AppNo";
                        sqlCom1.Parameters.Add(LOSNo1);

                        sqlCon.Open();

                        int SqlRow = 0;
                        SqlRow = sqlCom1.ExecuteNonQuery();

                        sqlCon.Close();
                    }

                }

            }
            else
            {
                hiddenResult.Value = "Please Select RPC Location !!!";
            }


            //Get_DataForIndexing();
        }
        catch (Exception ex)
        {
            hiddenResult.Value = "Error :" + ex.Message;
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
            ddlQueueDE.Visible = true;
            ddlQueueDE.SelectedValue = "1";
            ddlQueueDE.Items.FindByValue("CAM").Enabled = false;
            ddlQueueDE.Items.FindByValue("CAM_Hold").Enabled = false;
            ddlQueueDE.Items.FindByValue("Data_Entry").Enabled = true;
            ddlQueueDE.Items.FindByValue("Data_EntryHold").Enabled = true;
            Get_DEUserList();
            grdlos.Visible = false;
        }

        else
        {
            ddlQueueDE.Visible = true;
            Get_UserListCAM();
            ddlQueueDE.SelectedValue = "1";
            ddlQueueDE.Items.FindByValue("Data_Entry").Enabled = false;
            ddlQueueDE.Items.FindByValue("Data_EntryHold").Enabled = false;
            ddlQueueDE.Items.FindByValue("CAM").Enabled = true;
            ddlQueueDE.Items.FindByValue("CAM_Hold").Enabled = true;
            grdlos.Visible = false;
        }
    }
    protected void ddlQueueDE_SelectedIndexChanged(object sender, EventArgs e)
    {
        Get_DataForIndexing3();
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
    private void Get_DataForIndexing3()
    {

        Object SaveUSERInfo = (Object)Session["UserInfo"];
        SqlConnection sqlCon = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);

        try
        {
            sqlCon.Open();
            if (ddlQueueDE.SelectedValue == "Data_Entry")
            {
                proc = "HeroHousing_DataGrid_DataEntry_SP";
                Get_DEUserList();
            }

            else if (ddlQueueDE.SelectedValue == "Data_EntryHold")
            {

                proc = "HeroHousing_DataGrid_DataEntry_Hold_SP";
                Get_DEUserList();
            }
            else if (ddlQueueDE.SelectedValue == "CAM")
            {
                proc = "HeroHousing_Data_Grid_CAM_SP";
                Get_UserListCAM();
            }

            else if (ddlQueueDE.SelectedValue == "CAM_Hold")
            {

                proc = "HeroHousing_Data_Grid_CAM_Hold_SP";
                Get_UserListCAM();
            }
            else
            {
                //hiddenResult.Value = "Kindly select Process Queue..!!!";
                return;
            }

            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlCon;
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.CommandText = proc;
            sqlcmd.CommandTimeout = 0;


            SqlParameter BranchID = new SqlParameter();
            BranchID.SqlDbType = SqlDbType.VarChar;
            BranchID.Value = ddllocation.SelectedValue.ToString();
            BranchID.ParameterName = "@BranchID";
            sqlcmd.Parameters.Add(BranchID);


            SqlParameter Roll = new SqlParameter();
            Roll.SqlDbType = SqlDbType.VarChar;
            Roll.Value = ddlQueueDE.SelectedValue.ToString();
            Roll.ParameterName = "@Roll";
            sqlcmd.Parameters.Add(Roll);

            SqlDataAdapter sda = new SqlDataAdapter();
            sda.SelectCommand = sqlcmd;

            DataTable dt = new DataTable();
            sda.Fill(dt);

            sqlCon.Close();

            if (dt.Rows.Count > 0)
            {
                grdlos.Visible = true;
                grdlos.DataSource = dt;
                grdlos.DataBind();

                ViewState["dirState"] = dt;
                ViewState["sortdr"] = "Asc";

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
    protected void grdlos_Sorting(object sender, GridViewSortEventArgs e)
    {
        DataTable dtrslt = (DataTable)ViewState["dirState"];
        if (dtrslt.Rows.Count > 0)
        {
            if (Convert.ToString(ViewState["sortdr"]) == "Asc")
            {
                dtrslt.DefaultView.Sort = e.SortExpression + " Desc";
                ViewState["sortdr"] = "Desc";
            }
            else
            {
                dtrslt.DefaultView.Sort = e.SortExpression + " Asc";
                ViewState["sortdr"] = "Asc";
            }
            grdlos.DataSource = dtrslt;
            grdlos.DataBind();


        }

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
                        sqlCom.CommandText = "HeroHousing_Assign_ALL_HERO_USER_SP";
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
    protected void btncancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Pages/Menu.aspx", true);
    }
    protected void ddllocation_SelectedIndexChanged(object sender, EventArgs e)
    {
        Get_DataForIndexing3();
    }
}