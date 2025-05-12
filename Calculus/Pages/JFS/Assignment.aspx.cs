using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;


public partial class Pages_JFS_Assignment : System.Web.UI.Page
{
   
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            getbranch_name();
            Searchdata();
            getuser_name();
        }
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/pages/menu.aspx", true);
    }

    protected void btnsearch_Click(object sender, EventArgs e)
    {
        Searchdata();
    }  

    public void getbranch_name()
    {
        try
        {

            Object SaveUSERInfo = (Object)Session["UserInfo"];
            SqlConnection sqlCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);

            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlCon;
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.CommandText = "sp_getbranch_name_assign";

            SqlParameter branch_id = new SqlParameter();
            branch_id.SqlDbType = SqlDbType.NVarChar;
            branch_id.Value = Session["BranchId"].ToString();
            branch_id.ParameterName = "@branchid";
            sqlcmd.Parameters.Add(branch_id);

            SqlDataAdapter sda = new SqlDataAdapter();
            sda.SelectCommand = sqlcmd;

            DataSet MyDs = new DataSet();
            sda.Fill(MyDs);

            ddlbranch.DataTextField = "branch_name";
            ddlbranch.DataValueField = "branch_name";
            ddlbranch.DataSource = MyDs;
            ddlbranch.DataBind();
            ddlbranch.Items.Insert(0, new ListItem("--All--", "0"));
        }
        catch
        {
        }

    }


    public void getuser_name()
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
            branch_id.Value = Session["BranchId"].ToString();
            branch_id.ParameterName = "@branchid";
            sqlcmd.Parameters.Add(branch_id);

            SqlDataAdapter sda = new SqlDataAdapter();
            sda.SelectCommand = sqlcmd;

            DataSet MyDs = new DataSet();
            sda.Fill(MyDs);


            ddlusername.DataTextField = "username";
            ddlusername.DataValueField = "username";
            ddlusername.DataSource = MyDs;
            ddlusername.DataBind();
         
        }
        catch
        {
        }

        

    }
    protected void ddlbranch_SelectedIndexChanged(object sender, EventArgs e)
    {
        getuser_name();
       
    }
protected void Button1_Click(object sender, EventArgs e)
{
    save_assign();
    Searchdata();
}

public void save_assign()
{
    try
    {
        Object SaveUSERInfo = (Object)Session["UserInfo"];

        SqlConnection sqlCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);

        for (int i = 0; i < GridView1.Rows.Count; i++)
        {

            CheckBox chk = (CheckBox)GridView1.Rows[i].FindControl("chkid");

            if (chk.Checked == true)
            {
                SqlCommand sqlcmd = new SqlCommand();
                sqlcmd.Connection = sqlCon;
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.CommandText = "sp_Save_assign";
                sqlcmd.CommandTimeout = 0;

                SqlParameter Auto_Application_No = new SqlParameter();
                Auto_Application_No.SqlDbType = SqlDbType.VarChar;
                Auto_Application_No.Value = GridView1.Rows[i].Cells[1].Text.Trim();
                Auto_Application_No.ParameterName = "@Auto_Application_No";
                sqlcmd.Parameters.Add(Auto_Application_No);

                SqlParameter br_assign = new SqlParameter();
                br_assign.SqlDbType = SqlDbType.VarChar;
                br_assign.Value = ddlusername.SelectedValue.ToString();
                br_assign.ParameterName = "@br_assig";
                sqlcmd.Parameters.Add(br_assign);

                SqlParameter userass_done_by = new SqlParameter();
                userass_done_by.SqlDbType = SqlDbType.VarChar;
                userass_done_by.Value = Convert.ToString(((UserInfo.structUSERInfo)(SaveUSERInfo)).UserId);
                userass_done_by.ParameterName = "@userass_done_by";
                sqlcmd.Parameters.Add(userass_done_by);

                if (ddlusername.SelectedValue.ToString() == "")
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



public void Searchdata()
{
    try
    {
        Object SaveUSERInfo = (Object)Session["UserInfo"];
        SqlConnection sqlCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);

        SqlCommand sqlcmd = new SqlCommand();
        sqlcmd.Connection = sqlCon;
        sqlcmd.CommandType = CommandType.StoredProcedure;
        sqlcmd.CommandText = "sp_btnSearch_JFS_assig_id";

        SqlDataAdapter sda = new SqlDataAdapter();
        sda.SelectCommand = sqlcmd;

        SqlParameter branch_name = new SqlParameter();
        branch_name.SqlDbType = SqlDbType.NVarChar;
        branch_name.Value = ddlbranch.SelectedValue.ToString();
        branch_name.ParameterName = "@branch_name";
        sqlcmd.Parameters.Add(branch_name);


        SqlParameter branch_id = new SqlParameter();
        branch_id.SqlDbType = SqlDbType.NVarChar;
        branch_id.Value = Convert.ToString(((UserInfo.structUSERInfo)(SaveUSERInfo)).BranchId);
        branch_id.ParameterName = "@branch_id";
        sqlcmd.Parameters.Add(branch_id);

        SqlParameter App_no = new SqlParameter();
        App_no.SqlDbType = SqlDbType.NVarChar;
        App_no.Value = txtAppNo.Text.Trim();
        App_no.ParameterName = "@App_no";
        sqlcmd.Parameters.Add(App_no);

        DataSet MyDs = new DataSet();
        sda.Fill(MyDs);
        if (MyDs.Tables[0].Rows.Count == 0)
        {
            lblMsgXls.Text = "Records not found";
        }

        GridView1.DataSource = MyDs;
        GridView1.DataBind();
    }
    catch
    {
    }
}





}
