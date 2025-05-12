using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class Pages_JFS_Quality_control : System.Web.UI.Page
{
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
            sqlcmd.CommandText = "sp_getbranch_name_Qc";

            SqlDataAdapter sda = new SqlDataAdapter();
            sda.SelectCommand = sqlcmd;

            DataSet MyDs = new DataSet();
            sda.Fill(MyDs);

            ddlbranch_qc.DataTextField = "branch_name";
            ddlbranch_qc.DataValueField = "branch_name";
            ddlbranch_qc.DataSource = MyDs;
            ddlbranch_qc.DataBind();
            ddlbranch_qc.Items.Insert(0, new ListItem("--All--", "0"));
        }
        catch
        {
        }

    }
    protected void btnsearch_Click(object sender, EventArgs e)
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
            sqlcmd.CommandText = "sp_btnSearch_JFS_Qc";

            SqlDataAdapter sda = new SqlDataAdapter();
            sda.SelectCommand = sqlcmd;


            SqlParameter branch_name = new SqlParameter();
            branch_name.SqlDbType = SqlDbType.NVarChar;
            branch_name.Value = ddlbranch_qc.SelectedValue.ToString();
            branch_name.ParameterName = "@branch_name";
            sqlcmd.Parameters.Add(branch_name);

            SqlParameter App_no = new SqlParameter();
            App_no.SqlDbType = SqlDbType.NVarChar;
            App_no.Value = txtAppNo.Text.ToString();
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
    protected void ddlbranch_qc_SelectedIndexChanged1(object sender, EventArgs e)
    {
        Searchdata();
    }
    protected void ddlerror_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            for (int i = 0; i < GridView1.Rows.Count; i++)
            {
                TextBox txremark = (TextBox)GridView1.Rows[i].FindControl("txtremark");
                DropDownList dl = (DropDownList)GridView1.Rows[i].FindControl("ddlerror");
                CheckBox chk = (CheckBox)GridView1.Rows[i].FindControl("chkid");
                if (chk.Checked == true)
                {
                    if (dl.SelectedValue.ToString() == "Yes")
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
                    txremark.Visible = false;
                }
            }
        }
        catch
        {
        }
    }

    protected void btnsave_Click(object sender, EventArgs e)
    {
        SaveQc_Status();
        Searchdata();
    }


    public void SaveQc_Status()
    {
        try
        {
            Object SaveUSERInfo = (Object)Session["UserInfo"];

            SqlConnection sqlCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);

            for (int i = 0; i < GridView1.Rows.Count; i++)
            {
                TextBox txremark = (TextBox)GridView1.Rows[i].FindControl("txtremark");
                DropDownList dl = (DropDownList)GridView1.Rows[i].FindControl("ddlstatus");
                DropDownList de = (DropDownList)GridView1.Rows[i].FindControl("ddlerror");
                CheckBox chk = (CheckBox)GridView1.Rows[i].FindControl("chkid");

                if (chk.Checked == true)
                {
                    SqlCommand sqlcmd = new SqlCommand();
                    sqlcmd.Connection = sqlCon;
                    sqlcmd.CommandType = CommandType.StoredProcedure;
                    sqlcmd.CommandText = "sp_SaveQCstatus";
                    sqlcmd.CommandTimeout = 0;

                    SqlParameter Auto_Application_No = new SqlParameter();
                    Auto_Application_No.SqlDbType = SqlDbType.VarChar;
                    Auto_Application_No.Value = GridView1.Rows[i].Cells[1].Text.Trim();
                    Auto_Application_No.ParameterName = "@Auto_Application_No";
                    sqlcmd.Parameters.Add(Auto_Application_No);

                    SqlParameter qc_status = new SqlParameter();
                    qc_status.SqlDbType = SqlDbType.VarChar;
                    qc_status.Value = dl.SelectedValue.ToString();
                    qc_status.ParameterName = "@Qc_status";
                    sqlcmd.Parameters.Add(qc_status);

                    SqlParameter error = new SqlParameter();
                    error.SqlDbType = SqlDbType.VarChar;
                    error.Value = de.SelectedValue.ToString();
                    error.ParameterName = "@errors";
                    sqlcmd.Parameters.Add(error);


                    SqlParameter remark = new SqlParameter();
                    remark.SqlDbType = SqlDbType.VarChar;
                    remark.Value = txremark.Text.Trim();
                    remark.ParameterName = "@Qc_remark";
                    sqlcmd.Parameters.Add(remark);

                    SqlParameter QC_done_by = new SqlParameter();
                    QC_done_by.SqlDbType = SqlDbType.VarChar;
                    QC_done_by.Value = Convert.ToString(((UserInfo.structUSERInfo)(SaveUSERInfo)).UserId);
                    QC_done_by.ParameterName = "@QC_done_by";
                    sqlcmd.Parameters.Add(QC_done_by);




                    if (de.SelectedValue.ToString() == "Yes" && txremark.Text == "")
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


        }
        catch
        {
        }
    }


    protected void ddlstatus_SelectedIndexChanged(object sender, EventArgs e)
    {
        for (int i = 0; i < GridView1.Rows.Count; i++)
        {

            DropDownList dl = (DropDownList)GridView1.Rows[i].FindControl("ddlstatus");
            CheckBox chk = (CheckBox)GridView1.Rows[i].FindControl("chkid");

            if (chk.Checked == true)
            {
                if (dl.SelectedValue.ToString() == "")
                {
                }

            }
            else
            {
                dl.SelectedIndex = 0;

            }
        }
    }
}
