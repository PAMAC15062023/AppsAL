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
using System.Data.OleDb;
using System.IO;



public partial class Pages_JFS_LocationMaster : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            validate();
            bind();

        }
        Object SaveUSERInfo = (Object)Session["UserInfo"];
    }


    public void bind()
    {
        Object SaveUSERInfo = (Object)Session["UserInfo"];

        using (SqlConnection sqlCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]))
        {

            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlCon;
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.CommandText = "getdataFromJFS";
            sqlcmd.CommandTimeout = 0;



            SqlDataAdapter ad = new SqlDataAdapter();
            ad.SelectCommand = sqlcmd;
            DataTable dt = new DataTable();

            ad.Fill(dt);



            if (dt.Rows.Count > 0)
            {
                GridView1.DataSource = dt;
                GridView1.DataBind();
            }
            else
            {
                GridView1.DataSource = "null";
                GridView1.DataBind();
            }

        }
    }

    protected void validate()
    {
        btnSubmit.Attributes.Add("onclick", "javascript:return validate();");
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        lblMsgXls.Text = "";
        Object SaveUSERInfo = (Object)Session["UserInfo"];
        SqlConnection sqlCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);

        SqlCommand sqlcmd = new SqlCommand();
        sqlcmd.Connection = sqlCon;
        sqlcmd.CommandType = CommandType.StoredProcedure;
        sqlcmd.CommandText = "stp_JfsSpokeMasterData";
        sqlcmd.CommandTimeout = 0;

        SqlParameter location = new SqlParameter();
        location.SqlDbType = SqlDbType.VarChar;
        location.Value = txtlocation.Text.Trim();
        location.ParameterName = "@spokeLocation";
        sqlcmd.Parameters.Add(location);

        SqlParameter branchid = new SqlParameter();
        branchid.SqlDbType = SqlDbType.VarChar;
        branchid.Value = DropDownList1.SelectedValue.ToString();
        branchid.ParameterName = "@branchid";
        sqlcmd.Parameters.Add(branchid);

        sqlCon.Open();
        int RowEffected = 0;
        RowEffected = sqlcmd.ExecuteNonQuery();
        sqlCon.Close();

        validate();
        lblMsgXls.Text = "Submit Successfully!";
        lblMsgXls.Visible = true;



        bind();

        txtlocation.Text = "";

    }

    protected void Btncancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Pages/Menu.aspx", true);
    }


    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        lblMsgXls.Text = "";
        for (int i = 0; i < GridView1.Rows.Count; i++)
        {
            String strUID = "";
            strUID = e.CommandArgument.ToString();

            HiddenField1.Value = GridView1.Rows[i].Cells[2].Text.Trim();


            if (e.CommandName == "Edit1")
            {
                if (HiddenField1.Value == strUID)
                {
                    HiddenField2.Value = GridView1.Rows[i].Cells[2].Text.Trim();
                    txtlocation.Text = GridView1.Rows[i].Cells[4].Text.Trim();
                    DropDownList1.SelectedValue = GridView1.Rows[i].Cells[5].Text.Trim();


                    lblMsgXls.Visible = true;
                    btnSubmit.Visible = false;
                    btnUpdate.Visible = true;
                    Btncancel.Visible = true;

                }
            }

            else if (e.CommandName == "Delete")
            {
                strUID = e.CommandArgument.ToString();
                HiddenField1.Value = GridView1.Rows[i].Cells[2].Text.Trim();

                if (HiddenField1.Value == strUID)
                {
                    // delete 
                    HiddenField2.Value = GridView1.Rows[i].Cells[2].Text.Trim();

                }
            }



        }

    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {

        Object SaveUSERInfo = (Object)Session["UserInfo"];
        SqlConnection sqlCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);


        SqlCommand cmd = new SqlCommand("stp_updateGridJFS", sqlCon);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@id", HiddenField2.Value);
        cmd.Parameters.AddWithValue("@spokelocations", txtlocation.Text);
        cmd.Parameters.AddWithValue("@Branchid", DropDownList1.SelectedValue.ToString());

        sqlCon.Open();
        cmd.ExecuteNonQuery();
        sqlCon.Close();


        lblMsgXls.Text = "Edited Successfully!";
        lblMsgXls.Visible = true;

        bind();

        txtlocation.Text = "";
        btnSubmit.Visible = true;
        btnUpdate.Visible = false;




    }

    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

        using (SqlConnection sqlCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]))
        {

            SqlCommand cmd = new SqlCommand("stp_DeleteQueryJFS", sqlCon);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", HiddenField2.Value);

            sqlCon.Open();
            int i = cmd.ExecuteNonQuery();
            sqlCon.Close();


            lblMsgXls.Text = "Deleted Successfully!";
            lblMsgXls.Visible = true;
            btnSubmit.Visible = true;
            btnUpdate.Visible = false;
            Btncancel.Visible = true;
            bind();
        }
    }
}


