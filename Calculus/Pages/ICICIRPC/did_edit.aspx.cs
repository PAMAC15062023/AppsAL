using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

public partial class Pages_RPC_OP_did_edit : System.Web.UI.Page
{
    //SingleUserLogin Login = new SingleUserLogin();
    protected void Page_Load(object sender, EventArgs e)
    {
        //Login.ValidateTokenLoginDetails();
        if (!IsPostBack)
        {

            Get_DataForedit();
        }

    }
    private void Get_DataForedit()
    {
        Object SaveUSERInfo = (Object)Session["UserInfo"];
        SqlConnection sqlCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);

        try
        {
            SqlCommand sqlCom = new SqlCommand();
            sqlCom.Connection = sqlCon;
            sqlCom.CommandType = CommandType.StoredProcedure;
            sqlCom.CommandText = "IRPC_Get_Hold_Status_ICICI_SP";
            sqlCom.CommandTimeout = 0;

            //SqlParameter USERID = new SqlParameter();
            //USERID.SqlDbType = SqlDbType.VarChar;
            //USERID.Value = Convert.ToString(((UserInfo.structUSERInfo)(SaveUSERInfo)).UserId);
            //USERID.ParameterName = "@UserID";
            //sqlCom.Parameters.Add(USERID);

            //SqlParameter GroupID = new SqlParameter();
            //GroupID.SqlDbType = SqlDbType.Int;
            //GroupID.Value = Convert.ToInt32(((UserInfo.structUSERInfo)(SaveUSERInfo)).GroupId);
            //GroupID.ParameterName = "@GroupID";
            //sqlCom.Parameters.Add(GroupID);

            sqlCon.Open();

            SqlDataAdapter sqlDA = new SqlDataAdapter();
            sqlDA.SelectCommand = sqlCom;

            DataTable dt = new DataTable();
            sqlDA.Fill(dt);

            sqlCon.Close();

            if (dt.Rows.Count > 0)
            {
                grdlos.DataSource = dt;
                grdlos.DataBind();

            }
            else
            {
                grdlos.DataSource = null;
                grdlos.DataBind();
            }
        }
        catch (Exception ex)
        {
            lblMessage.Visible = true;
            lblMessage.Text = "Error :" + ex.Message;
        }
        finally
        {
            sqlCon.Close();
            sqlCon.Dispose();
        }

    }

    private void Get_DataForsearch()
    {
        Object SaveUSERInfo = (Object)Session["UserInfo"];
        SqlConnection sqlCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);
        try
        {
            SqlCommand sqlCom = new SqlCommand();
            sqlCom.Connection = sqlCon;
            sqlCom.CommandType = CommandType.StoredProcedure;
            sqlCom.CommandText = "IRPC_Get_Hold_Case_Search_SP";
            sqlCom.CommandTimeout = 0;

            SqlParameter losno = new SqlParameter();
            losno.SqlDbType = SqlDbType.VarChar;
            losno.Value = txtlosno.Text.ToString();
            losno.ParameterName = "@losno";
            sqlCom.Parameters.Add(losno);



            sqlCon.Open();

            SqlDataAdapter sqlDA = new SqlDataAdapter();
            sqlDA.SelectCommand = sqlCom;

            DataTable dt = new DataTable();
            sqlDA.Fill(dt);

            sqlCon.Close();

            if (dt.Rows.Count > 0)
            {
                grdlos.DataSource = dt;
                grdlos.DataBind();

            }
            else
            {
                grdlos.DataSource = null;
                grdlos.DataBind();
            }
        }
        catch (Exception ex)
        {
            lblMessage.Visible = true;
            lblMessage.Text = "Error :" + ex.Message;
        }
        finally
        {
            sqlCon.Close();
            sqlCon.Dispose();
        }

    }

    protected void btncancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Pages/Menu.aspx", true);
    }

    public void save_status()
    {

        Object SaveUSERInfo = (Object)Session["UserInfo"];

        SqlConnection sqlCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);

        try
        {
            for (int i = 0; i <= grdlos.Rows.Count - 1; i++)
            {
                CheckBox chkSelect = (CheckBox)grdlos.Rows[i].FindControl("chkSelect");
                DropDownList ddlstatus = (DropDownList)grdlos.Rows[i].FindControl("ddlstatus");

                HdnUID.Value = grdlos.Rows[i].Cells[1].Text.Trim();


                if (chkSelect.Checked == true)
                {

                    SqlCommand sqlCom = new SqlCommand();
                    sqlCom.Connection = sqlCon;
                    sqlCom.CommandType = CommandType.StoredProcedure;
                    sqlCom.CommandText = "IRPC_Completed_Process_CAM_Edit_SP";
                    sqlCom.CommandTimeout = 0;

                    SqlDataAdapter sqlDA = new SqlDataAdapter();
                    sqlDA.SelectCommand = sqlCom;

                    SqlParameter LOSNo = new SqlParameter();
                    LOSNo.SqlDbType = SqlDbType.VarChar;
                    LOSNo.Value = HdnUID.Value;
                    LOSNo.ParameterName = "@LOSNo";
                    sqlCom.Parameters.Add(LOSNo);

                    SqlParameter did_status = new SqlParameter();
                    did_status.SqlDbType = SqlDbType.VarChar;
                    did_status.Value = ddlstatus.SelectedValue.ToString();
                    did_status.ParameterName = "@did_completedstatus";
                    sqlCom.Parameters.Add(did_status);

                    SqlParameter user = new SqlParameter();
                    user.SqlDbType = SqlDbType.VarChar;
                    user.Value = Convert.ToString(((UserInfo.structUSERInfo)(SaveUSERInfo)).UserId);
                    user.ParameterName = "@didstatus_updateby";
                    sqlCom.Parameters.Add(user);


                    //SqlParameter DIDUpdate_Date = new SqlParameter();
                    //DIDUpdate_Date.SqlDbType = SqlDbType.VarChar;
                    //DIDUpdate_Date.Value = System.DateTime.Now.ToString().Trim();
                    //DIDUpdate_Date.ParameterName = "@DIDUpdate_Date";
                    //sqlCom.Parameters.Add(DIDUpdate_Date);

                    sqlCon.Open();

                    int SqlRow = 0;
                    SqlRow = sqlCom.ExecuteNonQuery();

                    sqlCon.Close();

                    if (SqlRow > 0)
                    {



                    }
                }

            }
        }
        catch (Exception ex)
        {
            lblMessage.Visible = true;
            lblMessage.Text = "Error :" + ex.Message;
        }
        finally
        {
            sqlCon.Close();
            sqlCon.Dispose();
        }

    }

    protected void lnkedit_Click(object sender, EventArgs e)
    {
        save_status();
        Get_DataForedit();
    }


    protected void btnsearch_Click(object sender, EventArgs e)
    {

        if (txtlosno.Text != "")
        {

            Get_DataForsearch();
        }
        else
        {
            //lblMessage.Text = "Please Enter The Los Number!!!!!!!!!!!!";
            Get_DataForedit();
        }

    }
    protected void grdlos_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        SqlConnection sqlCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);

        if (e.Row.RowType == DataControlRowType.DataRow)
        {


            DropDownList ddlstatus = (e.Row.FindControl("ddlstatus") as DropDownList);
          
            SqlCommand cmd = new SqlCommand("IRPC_MasterSearchCode_SP", sqlCon);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Types", "CAMStatusType");
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
            }           
        }
    }
}