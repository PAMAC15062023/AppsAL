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
using System.Data.SqlClient;
using System.IO;
using System.Text.RegularExpressions;

public partial class Pages_HeroHousing_DataEntry : System.Web.UI.Page
{
    bool strselect = false;
    bool strstatus = false;
    bool strWIPstatus = false;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            sp_assign_DataEntry();
            get_importdata();
            //get_griddata();
        }
    }
    public void sp_assign_DataEntry()
    {
        Object SaveUSERInfo = (Object)Session["UserInfo"];
        SqlConnection sqlcon = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);

        try
        {
            SqlCommand sqlcmd = new SqlCommand("HeroHousing_Assign_Data_Entry_SP", sqlcon);
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.CommandTimeout = 0;


            SqlDataAdapter sqlDA2 = new SqlDataAdapter();
            sqlDA2.SelectCommand = sqlcmd;

            sqlcmd.Parameters.AddWithValue("@userid", Convert.ToString(((UserInfo.structUSERInfo)(SaveUSERInfo)).UserId));
            sqlcmd.Parameters.AddWithValue("@PMSLocation", Convert.ToString(((UserInfo.structUSERInfo)(SaveUSERInfo)).BranchId));

            sqlcon.Open();
            int rowseffect = 0;
            rowseffect = sqlcmd.ExecuteNonQuery();
            sqlcon.Close();

            if (rowseffect > 0)
            {

            }
        }
        catch (Exception ex)
        {
            hiddenResult.Value = "Error:" + ex.Message;
        }
    }
    public void get_importdata()
    {
        Object SaveUSERInfo = (Object)Session["UserInfo"];
        SqlConnection conn = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);

        try
        {
            SqlCommand cmd1 = new SqlCommand("HeroHousing_Get_Data_Entry_SP", conn);
            cmd1.CommandType = CommandType.StoredProcedure;
            cmd1.CommandTimeout = 0;

            cmd1.Parameters.AddWithValue("@UserId", Convert.ToString(((UserInfo.structUSERInfo)(SaveUSERInfo)).UserId));
            cmd1.Parameters.AddWithValue("@PMSlocation", Convert.ToString(((UserInfo.structUSERInfo)(SaveUSERInfo)).BranchId));

            conn.Open();
            SqlDataAdapter sda = new SqlDataAdapter();
            sda.SelectCommand = cmd1;

            DataTable dt = new DataTable();
            sda.Fill(dt);
            conn.Close();

            if (dt.Rows.Count > 0)
            {
                grdlos.DataSource = dt;
                grdlos.DataBind();
                DiscripancyGridBind();
                // get_griddata();


                grddata.DataSource = dt;
                grddata.DataBind();
            }
            else
            {
                grdlos.DataSource = null;
                grdlos.DataBind();


                grddata.DataSource = null;
                grddata.DataBind();
                DiscripancyGridBind();
            }
        }
        catch (Exception ex)
        {
            hiddenResult.Value = "Error:" + ex.Message;
        }
    }
    //public void get_griddata()
    //{
    //    Object SaveUSERInfo = (Object)Session["UserInfo"];
    //    SqlConnection sqlconn = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);

    //    try
    //    {
    //        SqlCommand cmd = new SqlCommand("", sqlconn);
    //        cmd.CommandType = CommandType.StoredProcedure;
    //        cmd.CommandTimeout = 0;

    //        cmd.Parameters.AddWithValue("@user_Id", Convert.ToString(((UserInfo.structUSERInfo)(SaveUSERInfo)).UserId));
    //        cmd.Parameters.AddWithValue("@Branch_id", Convert.ToString(((UserInfo.structUSERInfo)(SaveUSERInfo)).BranchId));

    //        sqlconn.Open();
    //        SqlDataAdapter sda = new SqlDataAdapter();
    //        sda.SelectCommand = cmd;

    //        DataTable dt = new DataTable();
    //        sda.Fill(dt);
    //        sqlconn.Close();

    //        if (dt.Rows.Count > 0)
    //        {
    //            grddata.DataSource = dt;
    //            grddata.DataBind();
    //        }
    //        else
    //        {
    //            grddata.DataSource = null;
    //            grddata.DataBind();
    //        }
    //    }
    //    catch (Exception ex)
    //    {
    //        hiddenResult.Value = "Error:" + ex.Message;
    //        return;
    //    }

    //}
    protected void btncancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Pages/Menu.aspx", true);
    }
    protected void lnkWIP_Click(object sender, EventArgs e)
    {
        Object SaveUSERInfo = (Object)Session["UserInfo"];
        SqlConnection conn = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);

        try
        {

            for (int i = 0; i <= grdlos.Rows.Count - 1; i++)
            {

                LinkButton lnkWIP = (LinkButton)grdlos.Rows[i].FindControl("lnkWIP");
                hdncaseno.Value = grdlos.Rows[i].Cells[3].Text.Trim();

                SqlCommand cmd = new SqlCommand("HeroHousing_Inproc_Data_Entry_SP", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 0;

                cmd.Parameters.AddWithValue("@Userid", Convert.ToString(((UserInfo.structUSERInfo)(SaveUSERInfo)).UserId));
                cmd.Parameters.AddWithValue("@caseno", hdncaseno.Value);

                conn.Open();
                int rows = 0;
                rows = cmd.ExecuteNonQuery();
                conn.Close();

                if (rows > 0)
                {
                    hiddenResult.Value = "Inprocess..!!!";
                }
            }

            sp_assign_DataEntry();
            get_importdata();
        }
        catch (Exception ex)
        {
            hiddenResult.Value = "Error:" + ex.Message;
            return;
        }
    }
    protected void ddlstatus_SelectedIndexChanged(object sender, EventArgs e)
    {
        Object SaveUSERInfo = (Object)Session["UserInfo"];

        SqlConnection sqlCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);
        try
        {
            if (sqlCon.State == ConnectionState.Closed)
            {
                sqlCon.Open();
                for (int i = 0; i <= grdlos.Rows.Count - 1; i++)
                {
                    DropDownList Status = (DropDownList)grdlos.Rows[i].FindControl("ddlstatus");

                    Button Discripancy = (Button)grdlos.Rows[i].FindControl("btnAddDiscripancy");

                    TextBox txtdiscripancy = (TextBox)grdlos.Rows[i].FindControl("txtdiscripancy");

                    LinkButton Complete = (LinkButton)grdlos.Rows[i].FindControl("lnkCompleteExit");

                    LinkButton lnkCompleteNext = (LinkButton)grdlos.Rows[i].FindControl("lnkCompleteNext");

                    TextBox txtremark = (TextBox)grdlos.Rows[i].FindControl("txtremark");

                    HdnWIPStatus.Value = grdlos.Rows[i].Cells[2].Text.Trim();

                    if (HdnWIPStatus.Value == "InProcess")
                    {
                        if (Status.SelectedItem.Text != "--Select--")
                        {
                            strstatus = true;
                            if ((Status.SelectedItem.Text == "Complete"))
                            {
                                txtdiscripancy.Visible = false;
                                Discripancy.Visible = false;
                                Complete.Visible = true;
                                lnkCompleteNext.Visible = true;
                                txtremark.Visible = true;
                            }
                            else
                            {
                                txtdiscripancy.Visible = true;
                                Discripancy.Visible = true;
                                Complete.Visible = false;
                                lnkCompleteNext.Visible = false;
                                txtremark.Visible = false;
                            }

                        }
                        else
                        {
                            if (!strstatus)
                            {
                                hiddenResult.Value = "Select Status....!!!!!";
                                Status.SelectedIndex = 0;
                                Complete.Visible = false;
                                lnkCompleteNext.Visible = false;
                            }

                        }
                    }

                    else
                    {
                        hiddenResult.Value = "Click On Start Button....!!!!!";
                        Complete.Visible = false;
                        lnkCompleteNext.Visible = false;
                    }




                }

            }

        }

        catch (SqlException sqlex)
        {
            //lblMessage.Text = sqlex.Message.ToString();

        }
        catch (SystemException ex)
        {
            //lblMessage.Text = ex.Message.ToString();
        }
    }
    protected void btnAddDiscripancy_Click(object sender, EventArgs e)
    {
        Object SaveUSERInfo = (Object)Session["UserInfo"];

        SqlConnection sqlCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);
        try
        {
            if (sqlCon.State == ConnectionState.Closed)
            {
                sqlCon.Open();
                for (int i = 0; i <= grdlos.Rows.Count - 1; i++)
                {
                    DropDownList Status = (DropDownList)grdlos.Rows[i].FindControl("ddlstatus");

                    Button AddDiscripancy = (Button)grdlos.Rows[i].FindControl("btnAddDiscripancy");

                    TextBox txtdiscripancy = (TextBox)grdlos.Rows[i].FindControl("txtdiscripancy");

                    LinkButton Complete = (LinkButton)grdlos.Rows[i].FindControl("lnkCompleteExit");

                    LinkButton lnkCompleteNext = (LinkButton)grdlos.Rows[i].FindControl("lnkCompleteNext");

                    hdncaseno.Value = grdlos.Rows[i].Cells[3].Text.Trim();
                    HdnWIPStatus.Value = grdlos.Rows[i].Cells[2].Text.Trim();

                    if (HdnWIPStatus.Value == "InProcess")
                    {
                        strselect = true;

                        SqlCommand sqlCom = new SqlCommand();
                        sqlCom.Connection = sqlCon;
                        sqlCom.CommandType = CommandType.StoredProcedure;
                        sqlCom.CommandText = "HeroHousing_DataEntry_AddDiscripancy_SP";
                        sqlCom.CommandTimeout = 0;

                        SqlParameter caseno = new SqlParameter();
                        caseno.SqlDbType = SqlDbType.VarChar;
                        caseno.Value = hdncaseno.Value;
                        caseno.ParameterName = "@AppNo";
                        sqlCom.Parameters.Add(caseno);

                        SqlParameter Discripancy = new SqlParameter();
                        Discripancy.SqlDbType = SqlDbType.VarChar;
                        Discripancy.Value = txtdiscripancy.Text.ToUpper().Trim();
                        Discripancy.ParameterName = "@Discripancy";
                        sqlCom.Parameters.Add(Discripancy);

                        SqlParameter Status1 = new SqlParameter();
                        Status1.SqlDbType = SqlDbType.VarChar;
                        Status1.Value = "Pending";
                        Status1.ParameterName = "@Status";
                        sqlCom.Parameters.Add(Status1);

                        SqlParameter stage = new SqlParameter();
                        stage.SqlDbType = SqlDbType.VarChar;
                        stage.Value = "DataEnry";
                        stage.ParameterName = "@stage";
                        sqlCom.Parameters.Add(stage);


                        SqlParameter ddlStatus = new SqlParameter();
                        ddlStatus.SqlDbType = SqlDbType.VarChar;
                        ddlStatus.Value = Status.SelectedItem.Value.ToString().Trim();
                        ddlStatus.ParameterName = "@ddlStatus";
                        sqlCom.Parameters.Add(ddlStatus);

                        sqlCom.Parameters.AddWithValue("@userId", Convert.ToString(((UserInfo.structUSERInfo)(SaveUSERInfo)).UserId));

                        int SqlRow = 0;
                        SqlRow = sqlCom.ExecuteNonQuery();

                        if (SqlRow > 0)
                        {
                            DiscripancyGridBind();
                            txtdiscripancy.Text = null;
                            Complete.Visible = true;
                            lnkCompleteNext.Visible = true;

                        }
                    }

                    else
                    {
                        if (!strselect)
                        {

                            hiddenResult.Value = "Please check on checkbox first...";
                            Status.SelectedIndex = 0;
                        }
                    }
                }
            }
        }

        catch (SqlException sqlex)
        {
            //lblMessage.Text = sqlex.Message.ToString();

        }
        catch (SystemException ex)
        {
            //lblMessage.Text = ex.Message.ToString();
        }


    }
    public void DiscripancyGridBind()
    {
        Object SaveUSERInfo = (Object)Session["UserInfo"];
        SqlConnection conn = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);
        try
        {
            for (int i = 0; i <= grdlos.Rows.Count - 1; i++)
            {
                DropDownList ddlstatus = (DropDownList)grdlos.Rows[i].FindControl("ddlstatus");
                Button btnAddDiscripancy = (Button)grdlos.Rows[i].FindControl("btnAddDiscripancy");
                TextBox txtdiscripancy = (TextBox)grdlos.Rows[i].FindControl("txtdiscripancy");

                hdncaseno.Value = grdlos.Rows[i].Cells[3].Text.Trim();

                SqlCommand cmd = new SqlCommand("HeroHousing_DataEntry_SelectDiscripancyNEW_SP", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 0;

                cmd.Parameters.AddWithValue("@AppNo", hdncaseno.Value);

                conn.Open();
                SqlDataAdapter sda = new SqlDataAdapter();
                sda.SelectCommand = cmd;

                DataTable dt = new DataTable();
                sda.Fill(dt);
                conn.Close();

                if (dt.Rows.Count > 0)
                {
                    GridDiscripancy.Visible = true;
                    GridDiscripancy.DataSource = dt;
                    GridDiscripancy.DataBind();
                }
                else
                {
                    GridDiscripancy.DataSource = null;
                    GridDiscripancy.DataBind();
                    GridDiscripancy.Visible = false;
                }
            }

        }
        catch (Exception ex)
        {
            hiddenResult.Value = "Error:" + ex.Message;
            return;
        }

    }
    protected void lnkresolve_click1(object sender, EventArgs e)
    {
        Object SaveUSERInfo = (Object)Session["UserInfo"];

        SqlConnection conn = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);
        try
        {
            conn.Open();
            for (int i = 0; i <= GridDiscripancy.Rows.Count - 1; i++)
            {
                CheckBox chkSelect = (CheckBox)GridDiscripancy.Rows[i].FindControl("chkSelect");
                LinkButton lnkresolve = (LinkButton)GridDiscripancy.Rows[i].FindControl("lnkresolve");

                if (chkSelect.Checked == true)
                {
                    hdncaseno.Value = GridDiscripancy.Rows[i].Cells[3].Text.Trim();
                    hdnDisStatus.Value = GridDiscripancy.Rows[i].Cells[5].Text.Trim();

                    SqlCommand cmd = new SqlCommand("HeroHousing_DataEntry_UpdateDiscripancy_SP", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 0;

                    cmd.Parameters.AddWithValue("@AppNo", hdncaseno.Value);
                    cmd.Parameters.AddWithValue("@status", "Resolved");
                    cmd.Parameters.AddWithValue("@Dis_Id", hdnDisStatus.Value);

                    int sqlrow = 0;
                    sqlrow = cmd.ExecuteNonQuery();

                    DiscripancyGridBind();

                }
            }
        }
        catch (Exception ex)
        {
            hiddenResult.Value = "Error:" + ex.Message;
            return;
        }

    }
    //complete grid case method
    protected void lnkCompleteNext_Click(object sender, EventArgs e)
    {
        Object SaveUSERInfo = (Object)Session["UserInfo"];
        SqlConnection sqlcon = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);
        try
        {
            for (int i = 0; i <= grdlos.Rows.Count - 1; i++)
            {
                TextBox txtremark = (TextBox)grdlos.Rows[i].FindControl("txtremark");
                DropDownList ddlstatus = (DropDownList)grdlos.Rows[i].FindControl("ddlstatus");

                hdncaseno.Value = grdlos.Rows[i].Cells[3].Text.Trim();

                SqlCommand cmd = new SqlCommand("HeroHousing_DATA_ENTRY_COMPLETE_SP", sqlcon);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 0;

                    cmd.Parameters.AddWithValue("@AppNo", hdncaseno.Value);
                    cmd.Parameters.AddWithValue("@DEStatus", ddlstatus.SelectedItem.Value);
                    //if ((txtremark.Visible == true) && (txtremark.Text == ""))
                    //{
                    //    hiddenResult.Value = "Kindly Enter Remark..!!!";
                    //    return;
                    //}
                    //else
                    //{
                        cmd.Parameters.AddWithValue("@Remark", txtremark.Text.ToUpper().Trim());
                    //}
                    cmd.Parameters.AddWithValue("@UserId", Convert.ToString(((UserInfo.structUSERInfo)(SaveUSERInfo)).UserId));

                    sqlcon.Open();
                    int rows = 0;
                    rows = cmd.ExecuteNonQuery();
                    sqlcon.Close();

                    if (rows > 0)
                    {
                        hiddenResult.Value = "Data Update Successfully";
                    }
            }

            sp_assign_DataEntry();
            get_importdata();
        }
        catch (Exception ex)
        {
            hiddenResult.Value = "Error:" + ex.Message;
            return;
        }
    }
    //complete grid case method
    protected void lnkCompleteExit_Click(object sender, EventArgs e)
    {
        Object SaveUSERInfo = (Object)Session["UserInfo"];
        SqlConnection sqlcon = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);
        try
        {
            for (int i = 0; i <= grdlos.Rows.Count - 1; i++)
            {
                TextBox txtremark = (TextBox)grdlos.Rows[i].FindControl("txtremark");
                DropDownList ddlstatus = (DropDownList)grdlos.Rows[i].FindControl("ddlstatus");

                hdncaseno.Value = grdlos.Rows[i].Cells[3].Text.Trim();


                SqlCommand cmd = new SqlCommand("HeroHousing_DATA_ENTRY_COMPLETE_SP", sqlcon);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 0;

                    cmd.Parameters.AddWithValue("@AppNo", hdncaseno.Value);
                    cmd.Parameters.AddWithValue("@DEStatus", ddlstatus.SelectedItem.Value);
                    //if ((txtremark.Visible == true) && (txtremark.Text == ""))
                    //{
                    //    hiddenResult.Value = "Kindly Enter Remark..!!!";
                    //    return;
                    //}
                    //else
                    //{
                        cmd.Parameters.AddWithValue("@Remark", txtremark.Text.ToUpper().Trim());
                    //}
                    cmd.Parameters.AddWithValue("@UserId", Convert.ToString(((UserInfo.structUSERInfo)(SaveUSERInfo)).UserId));

                    sqlcon.Open();
                    int rows = 0;
                    rows = cmd.ExecuteNonQuery();
                    sqlcon.Close();

                    if (rows > 0)
                    {
                        Response.Redirect("~/Pages/Menu.aspx", true);
                        hiddenResult.Value = "";
                    }
            }

        }
        catch (Exception ex)
        {
            hiddenResult.Value = "Error:" + ex.Message;
            return;
        }
    }
    protected void grdlos_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        SqlConnection sqlCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);

        if (e.Row.RowType == DataControlRowType.DataRow)
        {

            DropDownList ddlstatus = (e.Row.FindControl("ddlstatus") as DropDownList);

            SqlCommand cmd = new SqlCommand("HeroHousing_MasterSearchCode_SP", sqlCon);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Types", "DataStatusType");
            cmd.Parameters.AddWithValue("@Level", 1);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            adp.Fill(ds);

            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                ddlstatus.DataSource = ds;
                ddlstatus.DataValueField = "Code_Id";
                ddlstatus.DataTextField = "Description";
                ddlstatus.DataBind();
                ddlstatus.Items.Insert(0, new ListItem("--Select--", "0"));
            }
        }
    }
}