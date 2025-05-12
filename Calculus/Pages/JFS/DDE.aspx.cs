using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class Pages_JFS_DDE : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            getbranch_name();
            AutoassignDE();          
            Searchdata();          
        }
    }
    protected void ddlbranch_SelectedIndexChanged(object sender, EventArgs e)
    {
        Searchdata();
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
            sqlcmd.CommandText = "sp_btnSearch_JFS_DDE_demo";

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

            SqlParameter username = new SqlParameter();
            username.SqlDbType = SqlDbType.NVarChar;
            username.Value = Convert.ToString(((UserInfo.structUSERInfo)(SaveUSERInfo)).UserId);
            username.ParameterName = "@da_user";
            sqlcmd.Parameters.Add(username);
            

            DataSet MyDs = new DataSet();
            sda.Fill(MyDs);
            if (MyDs.Tables[0].Rows.Count == 0)
            {
                lblMsgXls.Text = "Records not found";
            }

            GridView1.DataSource = MyDs;
            GridView1.DataBind();

            //string s = MyDs.Tables[0].Rows[0][9].ToString();
            //// Split string on spaces.
            //// ... This will separate all the words.
            //string[] words = s.Split(',');

            //int abc = words.Length;

            //for (int k = 0; k < abc; k++)
            //{
            //    TextBox TxtBoxU = new TextBox();

            //    TxtBoxU.ID = "TextBoxU" + k.ToString();
            //    TxtBoxU.Text = words[k];
            //    TxtBoxU.Attributes.Add("runat", "server");
            //    GridView1.Rows[k].Cells[1].Controls.Add((TxtBoxU));

            //    //CheckBox chkU = new CheckBox();
            //    //chkU.ID = "chkU" + k.ToString();
            //    //chkU.Attributes.Add("runat", "server");
            //    //GridView1.Rows[k].Cells[1].Controls.Add((chkU));
            //}

        
            
        }
        catch
        {
        }
    }

    public void AutoassignDE()
    {
        try
        {

            Object SaveUSERInfo = (Object)Session["UserInfo"];
            SqlConnection sqlCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);

            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlCon;
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.CommandText = "sp_auto_assign_user";

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

    public void getbranch_name()
    {
        try
        {

            Object SaveUSERInfo = (Object)Session["UserInfo"];
            SqlConnection sqlCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);

            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlCon;
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.CommandText = "sp_getbranch_name_dde";


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


    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/pages/menu.aspx", true);
    }
    protected void btnsearch_Click(object sender, EventArgs e)
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
                    if (dl.SelectedIndex.ToString() == "Completed")
                    {
                        
                        txremark.Visible = false;
                    }
                    else if (dl.SelectedIndex.ToString() == "Incompleted")
                    {
                        
                        txremark.Visible = false;
                    }

                    else if (dl.SelectedValue.ToString() == "Scan Issue")
                    {
                        txremark.Visible = true;
                    }
                    else
                    {
                        txremark.Visible = false;
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

    protected void btnsave_Click(object sender, EventArgs e)
    {
        save_DDE_STATUS();
        AutoassignDE();
        Searchdata();
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
                    sqlcmd.CommandText = "sp_Save_DDE_STATUS";
                    sqlcmd.CommandTimeout = 0;

                    SqlParameter Auto_Application_No = new SqlParameter();
                    Auto_Application_No.SqlDbType = SqlDbType.VarChar;
                    Auto_Application_No.Value = GridView1.Rows[i].Cells[1].Text.Trim();
                    Auto_Application_No.ParameterName = "@Auto_Application_No";
                    sqlcmd.Parameters.Add(Auto_Application_No);

                    SqlParameter scan_status = new SqlParameter();
                    scan_status.SqlDbType = SqlDbType.VarChar;
                    scan_status.Value = dl.SelectedValue.ToString();
                    scan_status.ParameterName = "@DataEntry_status";
                    sqlcmd.Parameters.Add(scan_status);


                    SqlParameter remark = new SqlParameter();
                    remark.SqlDbType = SqlDbType.VarChar;
                    remark.Value = txremark.Text.ToString();
                    remark.ParameterName = "@dataEntry_remark";
                    sqlcmd.Parameters.Add(remark);


                    SqlParameter DE_done_by = new SqlParameter();
                    DE_done_by.SqlDbType = SqlDbType.VarChar;
                    DE_done_by.Value = Convert.ToString(((UserInfo.structUSERInfo)(SaveUSERInfo)).UserId);
                    DE_done_by.ParameterName = "@DE_done_by";
                    sqlcmd.Parameters.Add(DE_done_by);

                    SqlParameter da_status = new SqlParameter();
                    da_status.SqlDbType = SqlDbType.VarChar;
                    da_status.Value = dl.SelectedValue.ToString();
                    da_status.ParameterName = "@da_status";
                    sqlcmd.Parameters.Add(da_status);


                    SqlParameter da_remark = new SqlParameter();
                    da_remark.SqlDbType = SqlDbType.VarChar;
                    da_remark.Value = txremark.Text.ToString();
                    da_remark.ParameterName = "@da_remark";
                    sqlcmd.Parameters.Add(da_remark);



                    if (dl.SelectedValue.ToString() == "Scan Issue" && txremark.Text == "")
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



            }

        }
        catch
        {
        }
    }

   
}