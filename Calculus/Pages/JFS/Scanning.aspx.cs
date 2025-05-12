using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Drawing;

public partial class Pages_JFS_Scanning : System.Web.UI.Page
{
    string ABCT;
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            getbranch_name();
            Searchdata();
        }

    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/pages/menu.aspx", true);
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
            sqlcmd.CommandText = "sp_getbranch_name";


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
            sqlcmd.CommandText = "sp_btnSearch_JFS";

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
    protected void btnsearch_Click(object sender, EventArgs e)
    {
        Searchdata();
    }
    protected void ddlstatus_SelectedIndexChanged(object sender, EventArgs e)
    {
        for (int i = 0; i < GridView1.Rows.Count; i++)
        {
            TextBox txremark = (TextBox)GridView1.Rows[i].FindControl("txtremark");
            DropDownList dl = (DropDownList)GridView1.Rows[i].FindControl("ddlstatus");
            CheckBox chk = (CheckBox)GridView1.Rows[i].FindControl("chkid");

            if (chk.Checked == true)
            {
                if (dl.SelectedValue.ToString() == "Received with Query")
                {
                    txremark.Visible = true;

                }
                else if (dl.SelectedValue.ToString() == "Received")
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
    protected void btnsave_Click(object sender, EventArgs e)
    {
        savescanningupdate();
        //Searchdata();
    }
    public void savescanningupdate()
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
                    sqlcmd.CommandText = "sp_scanningSave";
                    sqlcmd.CommandTimeout = 0;

                    SqlParameter Auto_Application_No = new SqlParameter();
                    Auto_Application_No.SqlDbType = SqlDbType.VarChar;
                    Auto_Application_No.Value = GridView1.Rows[i].Cells[3].Text.Trim();
                    Auto_Application_No.ParameterName = "@Auto_Application_No";
                    sqlcmd.Parameters.Add(Auto_Application_No);

                    SqlParameter scan_status = new SqlParameter();
                    scan_status.SqlDbType = SqlDbType.VarChar;
                    scan_status.Value = dl.SelectedValue.ToString();
                    scan_status.ParameterName = "@Scanning_status";
                    sqlcmd.Parameters.Add(scan_status);

                    SqlParameter remark = new SqlParameter();
                    remark.SqlDbType = SqlDbType.VarChar;
                    remark.Value = txremark.Text.ToString();
                    remark.ParameterName = "@Remark";
                    sqlcmd.Parameters.Add(remark);

                    SqlParameter add_by = new SqlParameter();
                    add_by.SqlDbType = SqlDbType.VarChar;
                    add_by.Value = Convert.ToString(((UserInfo.structUSERInfo)(SaveUSERInfo)).UserId);
                    add_by.ParameterName = "@scanning_done_by";
                    sqlcmd.Parameters.Add(add_by);

                    if (dl.SelectedValue.ToString() == "Received with Query" && txremark.Text == "")
                    {
                        lblMsgXls.Text = "Please enter remark";
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
            Searchdata();
        }
        catch
        {
        }

    }
    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    
    {
        try
        {
            for (int i = 0; i < GridView1.Rows.Count; i++)
            {
                String strUID = "";
                strUID = e.CommandArgument.ToString();
                HiddenField1.Value = GridView1.Rows[i].Cells[1].Text.Trim();

                if (e.CommandName == "Edit1")
                {
                    if (HiddenField1.Value == strUID)
                    {
                        HiddenField2.Value = GridView1.Rows[i].Cells[2].Text.Trim();
                        Response.Redirect("cisc_number.aspx?Auto_Application_No=" + HiddenField2.Value);
                    }
                }
            }
        }
        catch (Exception ex)
        {
        }
    }
    //protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    //{
    //    try
    //    {
    //        if (e.Row.RowType == DataControlRowType.DataRow)
    //        {

    //            Object SaveUSERInfo = (Object)Session["UserInfo"];
    //            SqlConnection sqlCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);

    //            SqlCommand sqlcmd = new SqlCommand();
    //            sqlcmd.Connection = sqlCon;
    //            sqlcmd.CommandType = CommandType.StoredProcedure;
    //            sqlcmd.CommandText = "get_color";

    //            SqlDataAdapter sda = new SqlDataAdapter();
    //            sda.SelectCommand = sqlcmd;




    //            DataSet MyDs = new DataSet();
    //            sda.Fill(MyDs);
    //            if (MyDs.Tables[0].Rows.Count == 0)
    //            {
    //                //lblMsgXls.Text = "Records not found";
    //                e.Row.ForeColor = Color.FromName("red");
    //                            }
    //                          else
    //                           {
    //                             e.Row.BackColor = Color.FromName("White");
    //                           }
                
    //            GridView1.DataSource = MyDs;
    //            GridView1.DataBind();
    //        }
    //    }

    //    catch
    //    {
    //    }
   

    //}
    
    //if (e.Row.RowType == DataControlRowType.DataRow)
        //{
        // if (Convert.ToDateTime(diff1) < Convert.ToDateTime(abc))
        // {
        // e.Row.ForeColor = Color.FromName("red");
        //  }
        // else
        //{
        //  e.Row.BackColor = Color.FromName("White");
        // }
        //}
        // else if (input12 == "LOSCompleteMISQDE")
        // {
        //   if (Convert.ToDateTime(diff2) < Convert.ToDateTime(abc))
        // {
        // e.Row.ForeColor = Color.FromName("red");
        //}
        //else
        //{
        //e.Row.BackColor = Color.FromName("White");
        //}
        //}
        //else if (input12 == "LOSCompleteMISDDE" || input12 == "LOSCompleteMISCPV" || input12 == "LOSCompleteMISMDR")
        //{
        //if (Convert.ToDateTime(diff3) < Convert.ToDateTime(abc))
        //{
        //  e.Row.ForeColor = Color.FromName("red");
        //  }
        //else
        //{
        //                e.Row.BackColor = Color.FromName("White");
        //            }

        //        }

        //        else
        //        {
        //            e.Row.BackColor = Color.FromName("White");

        //        }


        //    }
        //    else
        //    {

        //        e.Row.ForeColor = Color.FromName("red");

        //    }


        


    }

