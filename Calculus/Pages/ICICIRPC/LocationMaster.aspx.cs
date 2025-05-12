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
public partial class Pages_LOSTracker_LocationMaster : System.Web.UI.Page
{
    //SingleUserLogin Login = new SingleUserLogin();
    protected void Page_Load(object sender, EventArgs e)
    {
        //Login.ValidateTokenLoginDetails();
        if (!IsPostBack)
        {
            BindLocation();
            BindIsActive();
            validate();
            bind();
        }
        Object SaveUSERInfo = (Object)Session["UserInfo"];
    }
    protected void BindLocation()
    {
        SqlConnection sqlCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);

        SqlCommand cmd = new SqlCommand("IRPC_MasterSearchCode_SP", sqlCon);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@Types", "RPCLocationType");
        cmd.Parameters.AddWithValue("@Level", 1);
        SqlDataAdapter adp = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        adp.Fill(ds);

        if (ds != null && ds.Tables[0].Rows.Count > 0)
        {
            DropDownList1.DataSource = ds;
            DropDownList1.DataValueField = "Code_Id";
            DropDownList1.DataTextField = "Description";
            DropDownList1.DataBind();
            DropDownList1.Items.Insert(0, new ListItem("--Select--", "0"));
        }  
    }
    protected void BindIsActive()
    { 
        SqlConnection sqlCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);

        SqlCommand cmd = new SqlCommand("IRPC_MasterSearchCode_SP", sqlCon);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@Types", "IsActiveType");
        cmd.Parameters.AddWithValue("@Level", 1);
        SqlDataAdapter adp = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        adp.Fill(ds);

        if (ds != null && ds.Tables[0].Rows.Count > 0)
        {
            ddlactive.DataSource = ds;
            ddlactive.DataValueField = "Code_Id";
            ddlactive.DataTextField = "Description";
            ddlactive.DataBind();
            ddlactive.Items.Insert(0, new ListItem("--Select--", "0"));
        }
    }

    public void bind()
    {
        Object SaveUSERInfo = (Object)Session["UserInfo"];

        using (SqlConnection sqlCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]))
        {
            try
            {

                SqlCommand sqlcmd = new SqlCommand();
                sqlcmd.Connection = sqlCon;
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.CommandText = "IRPC_Get_Data_SP";
                sqlcmd.CommandTimeout = 0;

                SqlDataAdapter ad = new SqlDataAdapter("IRPC_Get_Data_SP", sqlCon);
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

            catch (Exception ex)
            {
                lblMsgXls.Visible = true;
                lblMsgXls.Text = "Error :" + ex.Message;
            }
            finally
            {
                sqlCon.Close();
                sqlCon.Dispose();
            }
        }
    }

    protected void validate()
    {
        btnSubmit.Attributes.Add("onclick", "javascript:return validate();");
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {

        Object SaveUSERInfo = (Object)Session["UserInfo"];
        SqlConnection sqlCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);
        try
        {
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlCon;
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.CommandText = "IRPC_Add_LM_Data_SP";
            sqlcmd.CommandTimeout = 0;

            SqlParameter HUB = new SqlParameter();
            HUB.SqlDbType = SqlDbType.VarChar;
            HUB.Value = txthub.Text.Trim();
            HUB.ParameterName = "@HUb";
            sqlcmd.Parameters.Add(HUB);

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

            SqlParameter pamaclocation = new SqlParameter();
            pamaclocation.SqlDbType = SqlDbType.VarChar;
            pamaclocation.Value = DropDownList1.SelectedItem.ToString();
            pamaclocation.ParameterName = "@pamacLocaton";
            sqlcmd.Parameters.Add(pamaclocation);


            SqlParameter active = new SqlParameter();
            active.SqlDbType = SqlDbType.VarChar;
            active.Value = ddlactive.SelectedValue.ToString();
            active.ParameterName = "@is_active";
            sqlcmd.Parameters.Add(active);



            SqlParameter USERID = new SqlParameter();
            USERID.SqlDbType = SqlDbType.VarChar;
            USERID.Value = Convert.ToString(((UserInfo.structUSERInfo)(SaveUSERInfo)).UserId);
            USERID.ParameterName = "@RequestBy";
            sqlcmd.Parameters.Add(USERID);

            sqlCon.Open();
            int RowEffected = 0;
            RowEffected = sqlcmd.ExecuteNonQuery();
            sqlCon.Close();

            //if (RowEffected > 0)
            //{
            validate();
            lblMsgXls.Text = "Submit Successfully!";
            lblMsgXls.Visible = true;

            bind();
        }
        catch (Exception ex)
        {
            lblMsgXls.Visible = true;
            lblMsgXls.Text = "Error :" + ex.Message;
        }
        finally
        {
            sqlCon.Close();
            sqlCon.Dispose();
        }

        //}
    }

    protected void Btncancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Pages/Menu.aspx", true);
    }
    protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        GridView1.EditIndex = -1;
        bind();
    }
    protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {

        Object SaveUSERInfo = (Object)Session["UserInfo"];
        using (SqlConnection sqlCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]))
        {
            try
            {
                GridViewRow row = (GridViewRow)GridView1.Rows[e.RowIndex];
                Label lbl = (Label)row.FindControl("Label1");
                TextBox hub = (TextBox)row.FindControl("textbox1");
                TextBox spokelocation = (TextBox)row.FindControl("textbox2");
                TextBox pmslocation = (TextBox)row.FindControl("textbox3");
                GridView1.EditIndex = -1;


                SqlCommand cmd = new SqlCommand("IRPC_Update_Grid_SP", sqlCon);
                cmd.Parameters.AddWithValue("@id ", lbl.Text);
                cmd.Parameters.AddWithValue("@hub", hub.Text);
                cmd.Parameters.AddWithValue("@spokelocations", spokelocation.Text);
                cmd.Parameters.AddWithValue("@pmslocation", pmslocation.Text);
                cmd.Parameters.AddWithValue("@Branchid", DropDownList1.SelectedValue.ToString());

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.ExecuteNonQuery();

                bind();
            }
            catch (Exception ex)
            {
                lblMsgXls.Visible = true;
                lblMsgXls.Text = "Error :" + ex.Message;
            }
            finally
            {
                sqlCon.Close();
                sqlCon.Dispose();
            }


        }

    }



    protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
    {
        GridView1.EditIndex = e.NewEditIndex;
        bind();

    }
    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
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
                    DropDownList1.SelectedValue = GridView1.Rows[i].Cells[6].Text.Trim();
                    txthub.Text = GridView1.Rows[i].Cells[4].Text.Trim();
                    txtlocation.Text = GridView1.Rows[i].Cells[5].Text.Trim();
                    ddlactive.SelectedValue = GridView1.Rows[i].Cells[7].Text.Trim();




                    lblMsgXls.Visible = true;
                    btnSubmit.Visible = false;
                    btnUpdate.Visible = true;
                    Btncancel.Visible = true;

                }
            }
            //Add by : Akanksha
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
        try
        {

            SqlCommand cmd = new SqlCommand("IRPC_Update_Grid_ICICI_RPC_SP", sqlCon);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", HiddenField2.Value);
            cmd.Parameters.AddWithValue("@pmslocation", DropDownList1.SelectedItem.ToString());
            cmd.Parameters.AddWithValue("@hub", txthub.Text);
            cmd.Parameters.AddWithValue("@spokelocations", txtlocation.Text);
            cmd.Parameters.AddWithValue("@is_active", ddlactive.SelectedValue.ToString());

            cmd.Parameters.AddWithValue("@Branchid", DropDownList1.SelectedValue.ToString());
            cmd.Parameters.AddWithValue("@RequestBy", Convert.ToString(((UserInfo.structUSERInfo)(SaveUSERInfo)).UserId));


            sqlCon.Open();
            cmd.ExecuteNonQuery();
            sqlCon.Close();


            lblMsgXls.Text = "Edited Successfully!";
            lblMsgXls.Visible = true;

            bind();

            txthub.Text = "";
            txtlocation.Text = "";
        }
        catch (Exception ex)
        {
            lblMsgXls.Visible = true;
            lblMsgXls.Text = "Error :" + ex.Message;
        }
        finally
        {
            sqlCon.Close();
            sqlCon.Dispose();
        }



    }

    //ADD By :Akanksha
    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

        using (SqlConnection sqlCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]))
        {
            try
            {
                SqlCommand cmd = new SqlCommand("IRPC_Delete_Query_SP", sqlCon);
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
            catch (Exception ex)
            {
                lblMsgXls.Visible = true;
                lblMsgXls.Text = "Error :" + ex.Message;
            }
            finally
            {
                sqlCon.Close();
                sqlCon.Dispose();
            }
        }
    }
}

