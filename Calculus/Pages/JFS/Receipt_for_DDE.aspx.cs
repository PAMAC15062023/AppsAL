using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

public partial class Pages_JFS_Receipt_for_DDE : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            getbranch_name();
            Searchdata();
            

        }

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
            sqlcmd.CommandText = "sp_getbranch_name_rdd";

            SqlDataAdapter sda = new SqlDataAdapter();
            sda.SelectCommand = sqlcmd;

            DataSet MyDs = new DataSet();
            sda.Fill(MyDs);

            ddlbranchrd.DataTextField = "branch_name";
            ddlbranchrd.DataValueField = "branch_name";
            ddlbranchrd.DataSource = MyDs;
            ddlbranchrd.DataBind();
            ddlbranchrd.Items.Insert(0, new ListItem("--All--", "0"));
        }
        catch
        {
        }

    }
    protected void ddlbranch_SelectedIndexChanged(object sender, EventArgs e)
    {
        Searchdata();
    }
    protected void btnCancelRD_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/pages/menu.aspx", true);
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
            sqlcmd.CommandText = "sp_btnSearch_JFS_RDDE";

            SqlDataAdapter sda = new SqlDataAdapter();
            sda.SelectCommand = sqlcmd;


            SqlParameter branch_name = new SqlParameter();
            branch_name.SqlDbType = SqlDbType.NVarChar;
            branch_name.Value = ddlbranchrd.SelectedValue.ToString();
            branch_name.ParameterName = "@branch_name";
            sqlcmd.Parameters.Add(branch_name);

            SqlParameter App_no = new SqlParameter();
            App_no.SqlDbType = SqlDbType.NVarChar;
            App_no.Value = txtAppNord.Text.ToString();
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

    protected void btnsave_Click(object sender, EventArgs e)
    {

        saveDDE_status();
        Searchdata();
    }


    public void saveDDE_status()
    {
        try
        {
            Object SaveUSERInfo = (Object)Session["UserInfo"];

            SqlConnection sqlCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);

            for (int i = 0; i < GridView1.Rows.Count; i++)
            {

                DropDownList dl = (DropDownList)GridView1.Rows[i].FindControl("ddlstatus");
                CheckBox chk = (CheckBox)GridView1.Rows[i].FindControl("chkid");

                if (chk.Checked == true)
                {
                    SqlCommand sqlcmd = new SqlCommand();
                    sqlcmd.Connection = sqlCon;
                    sqlcmd.CommandType = CommandType.StoredProcedure;
                    sqlcmd.CommandText = "sp_Save_RDE_STATUS";
                    sqlcmd.CommandTimeout = 0;

                    SqlParameter Auto_Application_No = new SqlParameter();
                    Auto_Application_No.SqlDbType = SqlDbType.VarChar;
                    Auto_Application_No.Value = GridView1.Rows[i].Cells[1].Text.Trim();
                    Auto_Application_No.ParameterName = "@Auto_Application_No";
                    sqlcmd.Parameters.Add(Auto_Application_No);

                    SqlParameter scan_status = new SqlParameter();
                    scan_status.SqlDbType = SqlDbType.VarChar;
                    scan_status.Value = dl.SelectedValue.ToString();
                    scan_status.ParameterName = "@receipt_dde";
                    sqlcmd.Parameters.Add(scan_status);

                    //SqlParameter file_date = new SqlParameter();
                    //file_date.SqlDbType = SqlDbType.DateTime;
                    //file_date.Value =Convert.ToDateTime(GridView1.Rows[i].Cells[8].Text);
                    //file_date.ParameterName = "@file_at_agency";
                    //sqlcmd.Parameters.Add(file_date);

                    SqlParameter RDE_done_by = new SqlParameter();
                    RDE_done_by.SqlDbType = SqlDbType.VarChar;
                    RDE_done_by.Value = Convert.ToString(((UserInfo.structUSERInfo)(SaveUSERInfo)).UserId);
                    RDE_done_by.ParameterName = "@RDE_done_by";
                    sqlcmd.Parameters.Add(RDE_done_by);



                    sqlCon.Open();
                    int RowEffected = 0;

                    RowEffected = sqlcmd.ExecuteNonQuery();
                    lblMsgXls.Text = "Data Updated Successfuly!!!!!";

                    sqlCon.Close();
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

    public string strDate(string strInDate)
    {
        string strDD = strInDate.Substring(0, 2);

        string strMM = strInDate.Substring(3, 2);

        string strYYYY = strInDate.Substring(6, 4);

        string strhh = strInDate.Substring(11, 2);

        string strmmm = strInDate.Substring(14, 2);

        string strss = strInDate.Substring(17, 2);

        string strMMDDYYYY = strMM + "/" + strDD + "/" + strYYYY + " " + strhh + ":" + strmmm + ":" + strss;

        DateTime dtConvertDate = Convert.ToDateTime(strMMDDYYYY);

        string strOutDate = dtConvertDate.ToString("dd-MMM-yyyy HH:mm:ss");

        return strOutDate;
    }
}

    


     

