using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class Pages_JFS_query_resol : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            getbranch_name();
            AutoassignQR();
            Searchdata();
        }

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
            sqlcmd.CommandText = "sp_getbranch_name_qr";

            SqlParameter branch_name = new SqlParameter();
            branch_name.SqlDbType = SqlDbType.NVarChar;
            branch_name.Value = Convert.ToString(((UserInfo.structUSERInfo)(SaveUSERInfo)).BranchId);
            branch_name.ParameterName = "@branch_id";
            sqlcmd.Parameters.Add(branch_name);

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

    public void Searchdata()
    {
        try
        {
            Object SaveUSERInfo = (Object)Session["UserInfo"];
            SqlConnection sqlCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);

            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlCon;
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.CommandText = "btnSearch_JFS_QR";

            SqlDataAdapter sda = new SqlDataAdapter();
            sda.SelectCommand = sqlcmd;


            SqlParameter branch_name = new SqlParameter();
            branch_name.SqlDbType = SqlDbType.NVarChar;
            branch_name.Value = ddlbranch.SelectedValue.ToString();
            branch_name.ParameterName = "@branch_name";
            sqlcmd.Parameters.Add(branch_name);

            SqlParameter Branch_Id = new SqlParameter();
            Branch_Id.SqlDbType = SqlDbType.NVarChar;
            Branch_Id.Value = Convert.ToString(((UserInfo.structUSERInfo)(SaveUSERInfo)).BranchId);
            Branch_Id.ParameterName = "@Branch_Id";
            sqlcmd.Parameters.Add(Branch_Id);


            SqlParameter App_no = new SqlParameter();
            App_no.SqlDbType = SqlDbType.NVarChar;
            App_no.Value = txtAppNo.Text.Trim();
            App_no.ParameterName = "@App_no";
            sqlcmd.Parameters.Add(App_no);

            SqlParameter user_id = new SqlParameter();
            user_id.SqlDbType = SqlDbType.NVarChar;
            user_id.Value = Convert.ToString(((UserInfo.structUSERInfo)(SaveUSERInfo)).UserId); 
            user_id.ParameterName = "@br_assig";
            sqlcmd.Parameters.Add(user_id);




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
    public void AutoassignQR()
    {
        try
        {

            Object SaveUSERInfo = (Object)Session["UserInfo"];
            SqlConnection sqlCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);

            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlCon;
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.CommandText = "autoassign_QRuser";

            SqlParameter BranchID = new SqlParameter();
            BranchID.SqlDbType = SqlDbType.VarChar;
            BranchID.Value = Convert.ToString(((UserInfo.structUSERInfo)(SaveUSERInfo)).BranchId);
            BranchID.ParameterName = "@BranchID";
            sqlcmd.Parameters.Add(BranchID);

            sqlCon.Open();

            int i = sqlcmd.ExecuteNonQuery();

            sqlCon.Close();
        }
        catch
        {
        }

    }

    public void save_DDE_STATUS()
    {
        try
        {
            Object SaveUSERInfo = (Object)Session["UserInfo"];

            SqlConnection sqlCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);

            for (int i = 0; i < GridView1.Rows.Count; i++)
            {
                TextBox txremark = (TextBox)GridView1.Rows[i].FindControl("txtremark");
                DropDownList dl = (DropDownList)GridView1.Rows[i].FindControl("ddlstatus");
                CheckBox chk = (CheckBox)GridView1.Rows[i].FindControl("chkid");

                if (chk.Checked == true)
                {
                    SqlCommand sqlcmd = new SqlCommand();
                    sqlcmd.Connection = sqlCon;
                    sqlcmd.CommandType = CommandType.StoredProcedure;
                    sqlcmd.CommandText = "Save_QR_STATUS";
                    sqlcmd.CommandTimeout = 0;

                    SqlParameter Auto_Application_No = new SqlParameter();
                    Auto_Application_No.SqlDbType = SqlDbType.VarChar;
                    Auto_Application_No.Value = GridView1.Rows[i].Cells[1].Text.Trim();
                    Auto_Application_No.ParameterName = "@Auto_Application_No";
                    sqlcmd.Parameters.Add(Auto_Application_No);

                    SqlParameter scan_status = new SqlParameter();
                    scan_status.SqlDbType = SqlDbType.VarChar;
                    scan_status.Value = dl.SelectedValue.ToString();
                    scan_status.ParameterName = "@qr_status";
                    sqlcmd.Parameters.Add(scan_status);


                    SqlParameter remark = new SqlParameter();
                    remark.SqlDbType = SqlDbType.VarChar;
                    remark.Value = txremark.Text.ToString();
                    remark.ParameterName = "@qr_remark";
                    sqlcmd.Parameters.Add(remark);

                    if (dl.SelectedValue == "Incompleted" && txremark.Text == "")
                    {
                        lblMsgXls.Text = "Please enter remark";
                    }
                    else
                    {

                        sqlCon.Open();
                        int RowEffected = sqlcmd.ExecuteNonQuery();
                        lblMsgXls.Text = "Data Updated Successfuly !!!!!!!";
                        sqlCon.Close();
                    }
                }

                AutoassignQR();
                Searchdata();
            }

        }
        catch
        {
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        save_DDE_STATUS();
       // AutoassignQR();
        //Searchdata();
    }
    protected void ddlbranch_SelectedIndexChanged(object sender, EventArgs e)
    {
        Searchdata();
    }
    protected void ddlstatus_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            for (int i = 0; i < GridView1.Rows.Count; i++)
            {
                TextBox txremark = (TextBox)GridView1.Rows[i].FindControl("txtremark");
                DropDownList dl = (DropDownList)GridView1.Rows[i].FindControl("ddlstatus");
                CheckBox chk = (CheckBox)GridView1.Rows[i].FindControl("chkid");
                if (chk.Checked == true)
                {
                     if (dl.SelectedIndex.ToString() == "Incompleted")
                    {
                        txremark.Visible = false;
                       
                    }

                    else 
                    {
                        txremark.Visible = true;
                    }
                   
                }
                else
                {
                    dl.SelectedIndex = 0;
                }


            }
        }
        catch
        {
        }
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/pages/menu.aspx", true);
    }
}