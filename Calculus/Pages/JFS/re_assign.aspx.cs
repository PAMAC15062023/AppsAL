using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

public partial class Pages_JFS_re_assign : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ddltype.Items.Insert(0, new ListItem("--Select", "0"));
            Searchdata_da();
 
                
        }
    }

    public void getbranch_name_de()
    {
        try
        {

            Object SaveUSERInfo = (Object)Session["UserInfo"];
            SqlConnection sqlCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);

            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlCon;
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.CommandText = "sp_getbranch_name_reassign";

            SqlParameter branch_id = new SqlParameter();
            branch_id.SqlDbType = SqlDbType.NVarChar;
            branch_id.Value = Convert.ToString(((UserInfo.structUSERInfo)(SaveUSERInfo)).BranchId);
            branch_id.ParameterName = "@branchid";
            sqlcmd.Parameters.Add(branch_id);

            SqlDataAdapter sda = new SqlDataAdapter();
            sda.SelectCommand = sqlcmd;

            DataSet MyDs = new DataSet();
            sda.Fill(MyDs);


            ddlbranch_DE.DataTextField = "branch_name";
            ddlbranch_DE.DataValueField = "branch_name";

            ddlbranch_DE.DataSource = MyDs;
            ddlbranch_DE.DataBind();

            ddlbranch_DE.Items.Insert(0, new ListItem("--All--", "0"));
        }
        catch
        {
        }

    }
    public void Searchdata_de()
    {
        try
        {
            Object SaveUSERInfo = (Object)Session["UserInfo"];
            SqlConnection sqlCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);

            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlCon;
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.CommandText = "sp_btnSearch_JFS_reassign";

            SqlDataAdapter sda = new SqlDataAdapter();
            sda.SelectCommand = sqlcmd;

            SqlParameter branch_name = new SqlParameter();
            branch_name.SqlDbType = SqlDbType.NVarChar;
            branch_name.Value = ddlbranch_DE.SelectedValue.ToString();
            branch_name.ParameterName = "@branch_name";
            sqlcmd.Parameters.Add(branch_name);


            SqlParameter branch_id = new SqlParameter();
            branch_id.SqlDbType = SqlDbType.NVarChar;
            branch_id.Value = Convert.ToString(((UserInfo.structUSERInfo)(SaveUSERInfo)).BranchId);
            branch_id.ParameterName = "@branch_id";
            sqlcmd.Parameters.Add(branch_id);

            SqlParameter App_no = new SqlParameter();
            App_no.SqlDbType = SqlDbType.NVarChar;
            App_no.Value = txtappno_de.Text.Trim();            
            App_no.ParameterName = "@App_no";
            sqlcmd.Parameters.Add(App_no);

            DataSet MyDs = new DataSet();
            sda.Fill(MyDs);
            if (MyDs.Tables[0].Rows.Count == 0)
            {
                lblMsgXls.Text = "Records not found";
            }

            grd_dedata.DataSource = MyDs;
            grd_dedata.DataBind();
        }
        catch
        {
        }
    }

    public void getuser_name_de()
    {
        try
        {

            Object SaveUSERInfo = (Object)Session["UserInfo"];
            SqlConnection sqlCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);

            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlCon;
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.CommandText = "sp_getUser_name";

            SqlParameter branch_id = new SqlParameter();
            branch_id.SqlDbType = SqlDbType.NVarChar;
            branch_id.Value = Convert.ToString(((UserInfo.structUSERInfo)(SaveUSERInfo)).BranchId);
            branch_id.ParameterName = "@branchid";
            sqlcmd.Parameters.Add(branch_id);

            SqlDataAdapter sda = new SqlDataAdapter();
            sda.SelectCommand = sqlcmd;

            DataSet MyDs = new DataSet();
            sda.Fill(MyDs);


            ddluser_DE.DataTextField = "username";
            ddluser_DE.DataValueField = "username";
            ddluser_DE.DataSource = MyDs;
            ddluser_DE.DataBind();

        }
        catch
        {
        }



    }
    
    protected void ddltype_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddltype.SelectedValue == "DE")
            {
                pnlDE.Visible = true;
                pnlDA.Visible = false;

                getbranch_name_de();
                Searchdata_de();
                getuser_name_de();
                
            }
            else
            {
                pnlDA.Visible = true;
                pnlDE.Visible = false;
                getbranch_name_da();
                Searchdata_da();
                getuser_name_da();
            }

        }

    public void getbranch_name_da()
    {
        try
        {

            Object SaveUSERInfo = (Object)Session["UserInfo"];
            SqlConnection sqlCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);

            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlCon;
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.CommandText = "sp_getbranch_reassign";

            SqlParameter branch_id = new SqlParameter();
            branch_id.SqlDbType = SqlDbType.NVarChar;
            branch_id.Value = Session["BranchId"].ToString();
            branch_id.ParameterName = "@branchid";
            sqlcmd.Parameters.Add(branch_id);

            SqlDataAdapter sda = new SqlDataAdapter();
            sda.SelectCommand = sqlcmd;

            DataSet MyDs = new DataSet();
            sda.Fill(MyDs);


            ddlbranch_da.DataTextField = "branch_name";
            ddlbranch_da.DataValueField = "branch_name";

            ddlbranch_da.DataSource = MyDs;
            ddlbranch_da.DataBind();

            ddlbranch_da.Items.Insert(0, new ListItem("--All--", "0"));
        }
        catch
        {
        }

    }

    public void getuser_name_da()
    {
        try
        {

            Object SaveUSERInfo = (Object)Session["UserInfo"];
            SqlConnection sqlCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);

            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlCon;
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.CommandText = "sp_getUser_nameDA";

            SqlParameter branch_id = new SqlParameter();
            branch_id.SqlDbType = SqlDbType.NVarChar;
            branch_id.Value = Convert.ToString(((UserInfo.structUSERInfo)(SaveUSERInfo)).BranchId);
            branch_id.ParameterName = "@branchid";
            sqlcmd.Parameters.Add(branch_id);

            SqlDataAdapter sda = new SqlDataAdapter();
            sda.SelectCommand = sqlcmd;

            DataSet MyDs = new DataSet();
            sda.Fill(MyDs);



            ddluser_da.DataTextField = "username";
            ddluser_da.DataValueField = "username";
            ddluser_da.DataSource = MyDs;
            ddluser_da.DataBind();

        }
        catch
        {
        }



    }

    public void Searchdata_da()
    {
        try
        {
            Object SaveUSERInfo = (Object)Session["UserInfo"];
            SqlConnection sqlCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);

            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlCon;
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.CommandText = "sp_btnSearch_JFS_DA_reassing";

            SqlDataAdapter sda = new SqlDataAdapter();
            sda.SelectCommand = sqlcmd;

            //SqlParameter branch_name = new SqlParameter();
            //branch_name.SqlDbType = SqlDbType.NVarChar;
            //branch_name.Value = ddlbranch_DE.SelectedValue.ToString();
            //branch_name.ParameterName = "@branch_name";
            //sqlcmd.Parameters.Add(branch_name);


            SqlParameter branch_id = new SqlParameter();
            branch_id.SqlDbType = SqlDbType.NVarChar;
            branch_id.Value = Convert.ToString(((UserInfo.structUSERInfo)(SaveUSERInfo)).BranchId);
            branch_id.ParameterName = "@branch_id";
            sqlcmd.Parameters.Add(branch_id);

            SqlParameter App_no = new SqlParameter();
            App_no.SqlDbType = SqlDbType.NVarChar;
            App_no.Value = txtappno_de.Text.Trim();
            App_no.ParameterName = "@App_no";
            sqlcmd.Parameters.Add(App_no);

            DataSet MyDs = new DataSet();
            sda.Fill(MyDs);
            if (MyDs.Tables[0].Rows.Count == 0)
            {
                lblMsgXls.Text = "Records not found";
            }

            GridView3.DataSource = MyDs;
            GridView3.DataBind();
        }
        catch
        {
        }
    }
    protected void btncancel_da_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/pages/menu.aspx", true);
    }
    protected void btncancel_de_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/pages/menu.aspx", true);
    }

    protected void btnsearch_de_Click(object sender, EventArgs e)
    {
        Searchdata_de();
    }


    protected void btnreassign_de_Click(object sender, EventArgs e)
    {
        save_assign();
        Searchdata_de();
    }




    public void save_assign()
    {
        try
        {
            Object SaveUSERInfo = (Object)Session["UserInfo"];

            SqlConnection sqlCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);

            for (int i = 0; i < grd_dedata.Rows.Count; i++)
            {

                CheckBox chk = (CheckBox)grd_dedata.Rows[i].FindControl("chkid");

                if (chk.Checked == true)
                {
                    SqlCommand sqlcmd = new SqlCommand();
                    sqlcmd.Connection = sqlCon;
                    sqlcmd.CommandType = CommandType.StoredProcedure;
                    sqlcmd.CommandText = "sp_Save_reassignment_de";
                    sqlcmd.CommandTimeout = 0;

                    SqlParameter Auto_Application_No = new SqlParameter();
                    Auto_Application_No.SqlDbType = SqlDbType.VarChar;
                    Auto_Application_No.Value = grd_dedata.Rows[i].Cells[1].Text.Trim();
                    Auto_Application_No.ParameterName = "@Auto_Application_No";
                    sqlcmd.Parameters.Add(Auto_Application_No);

                    SqlParameter br_assign = new SqlParameter();
                    br_assign.SqlDbType = SqlDbType.VarChar;
                    br_assign.Value = ddluser_DE.SelectedValue.ToString();
                    br_assign.ParameterName = "@br_assign";
                    sqlcmd.Parameters.Add(br_assign);

                    SqlParameter userass_done_by = new SqlParameter();
                    userass_done_by.SqlDbType = SqlDbType.VarChar;
                    userass_done_by.Value = Convert.ToString(((UserInfo.structUSERInfo)(SaveUSERInfo)).UserId);
                    userass_done_by.ParameterName = "@userass_done_by";
                    sqlcmd.Parameters.Add(userass_done_by);

                    if (ddluser_DE.SelectedValue.ToString() == "")
                    {
                        lblMsgXls.Text = "Please enter user";
                    }
                    else
                    {
                        sqlCon.Open();
                        int RowEffected = 0;

                        RowEffected = sqlcmd.ExecuteNonQuery();
                        lblMsgXls.Text = "Data Updated Successfuly !!!!!!!";

                        sqlCon.Close();
                    }
                }

            }
        }
        catch
        {
        }


    }


    public void save_assign_da()
    {
        try
        {
            Object SaveUSERInfo = (Object)Session["UserInfo"];

            SqlConnection sqlCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);

            for (int i = 0; i < GridView3.Rows.Count; i++)
            {

                CheckBox chk = (CheckBox)GridView3.Rows[i].FindControl("chkid");

                if (chk.Checked == true)
                {
                    SqlCommand sqlcmd = new SqlCommand();
                    sqlcmd.Connection = sqlCon;
                    sqlcmd.CommandType = CommandType.StoredProcedure;
                    sqlcmd.CommandText = "sp_Save_reassignment_da";
                    sqlcmd.CommandTimeout = 0;

                    SqlParameter Auto_Application_No = new SqlParameter();
                    Auto_Application_No.SqlDbType = SqlDbType.VarChar;
                    Auto_Application_No.Value = GridView3.Rows[i].Cells[1].Text.Trim();
                    Auto_Application_No.ParameterName = "@Auto_Application_No";
                    sqlcmd.Parameters.Add(Auto_Application_No);

                    SqlParameter br_assign = new SqlParameter();
                    br_assign.SqlDbType = SqlDbType.VarChar;
                    br_assign.Value = ddluser_DE.SelectedValue.ToString();
                    br_assign.ParameterName = "@da_user";
                    sqlcmd.Parameters.Add(br_assign);

                    SqlParameter userass_done_by = new SqlParameter();
                    userass_done_by.SqlDbType = SqlDbType.VarChar;
                    userass_done_by.Value = Convert.ToString(((UserInfo.structUSERInfo)(SaveUSERInfo)).UserId);
                    userass_done_by.ParameterName = "@daa_done_by";
                    sqlcmd.Parameters.Add(userass_done_by);

                    if (ddluser_da.SelectedValue.ToString() == "")
                    {
                        lblMsgXls.Text = "Please enter user";
                    }
                    else
                    {
                        sqlCon.Open();
                        int RowEffected = 0;

                        RowEffected = sqlcmd.ExecuteNonQuery();
                        lblMsgXls.Text = "Data Updated Successfuly !!!!!!!";

                        sqlCon.Close();
                    }
                }

            }
        }
        catch
        {
        }


    }

    protected void _Click(object sender, EventArgs e)
    {
        Searchdata_de();
    }


    public void Save_DA_status()
    {
        try
        {
            Object SaveUSERInfo = (Object)Session["UserInfo"];

            SqlConnection sqlCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);

            for (int i = 0; i < GridView3.Rows.Count; i++)
            {
                DropDownList dl = (DropDownList)GridView3.Rows[i].FindControl("ddlDAstatus");
                CheckBox chk = (CheckBox)GridView3.Rows[i].FindControl("chkid");

                if (chk.Checked == true)
                {
                    SqlCommand sqlcmd = new SqlCommand();
                    sqlcmd.Connection = sqlCon;
                    sqlcmd.CommandType = CommandType.StoredProcedure;
                    sqlcmd.CommandText = "sp_Save_da_reassign";
                    sqlcmd.CommandTimeout = 0;

                    SqlParameter Auto_Application_No = new SqlParameter();
                    Auto_Application_No.SqlDbType = SqlDbType.VarChar;
                    Auto_Application_No.Value = GridView3.Rows[i].Cells[1].Text.Trim();
                    Auto_Application_No.ParameterName = "@Auto_Application_No";
                    sqlcmd.Parameters.Add(Auto_Application_No);


                    SqlParameter br_assign = new SqlParameter();
                    br_assign.SqlDbType = SqlDbType.VarChar;
                    br_assign.Value = ddluser_da.SelectedValue.ToString();
                    br_assign.ParameterName = "@da_user";
                    sqlcmd.Parameters.Add(br_assign);

                    SqlParameter DAA_done_by = new SqlParameter();
                    DAA_done_by.SqlDbType = SqlDbType.VarChar;
                    DAA_done_by.Value = Convert.ToString(((UserInfo.structUSERInfo)(SaveUSERInfo)).UserId);
                    DAA_done_by.ParameterName = "@DAA_done_by";
                    sqlcmd.Parameters.Add(DAA_done_by);

                    if (ddluser_da.SelectedValue.ToString() == "")
                    {
                        lblMsgXls.Text = "Please enter user";
                    }
                    else
                    {

                        sqlCon.Open();
                        int RowEffected = 0;

                        RowEffected = sqlcmd.ExecuteNonQuery();
                        lblMsgXls.Text = "Data Updated Successfuly !!!!!!!";

                        sqlCon.Close();
                    }
                }

            }
        }
        catch
        {
        }


    }



    protected void btnreassign_da_Click(object sender, EventArgs e)
    {
        save_assign_da();
        Searchdata_da();
    }
}