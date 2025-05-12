using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

public partial class Pages_Hero_Housing_CAM : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        label1.Text = "Page Refreshed at: " + DateTime.Today.ToLongDateString() + " Time : " + DateTime.Now.ToLongTimeString();
        if (!IsPostBack)
        {
            Autoassign();
        }
    }
    protected void btncancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Pages/Menu.aspx", true);
    }


    protected void lnkCompleted_Click(object sender, EventArgs e)
    {
        Object SaveUSERInfo = (Object)Session["UserInfo"];

        SqlConnection sqlCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);
        try
        {

            for (int i = 0; i <= grdlos.Rows.Count - 1; i++)
            {
                DropDownList ddlstatus = (DropDownList)grdlos.Rows[i].FindControl("ddlstatus");

                TextBox txtremark = (TextBox)grdlos.Rows[i].FindControl("txtremark");

                HdnUID.Value = grdlos.Rows[i].Cells[0].Text.Trim();


                if (ddlstatus.SelectedValue.ToString() != null)
                {

                    SqlCommand sqlCom = new SqlCommand();
                    sqlCom.Connection = sqlCon;
                    sqlCom.CommandType = CommandType.StoredProcedure;
                    sqlCom.CommandText = "Hero_Housing_InsertRecordCam_SP";
                    sqlCom.CommandTimeout = 0;


                    SqlParameter Status = new SqlParameter();
                    Status.SqlDbType = SqlDbType.VarChar;
                    Status.Value = ddlstatus.SelectedValue.ToString();
                    Status.ParameterName = "@CamStatus";
                    sqlCom.Parameters.Add(Status);

                    SqlParameter Remark = new SqlParameter();
                    Remark.SqlDbType = SqlDbType.VarChar;
                    Remark.Value = txtremark.Text.ToString();
                    Remark.ParameterName = "@CamRemark";
                    sqlCom.Parameters.Add(Remark);


                    SqlParameter LOSNo = new SqlParameter();
                    LOSNo.SqlDbType = SqlDbType.VarChar;
                    LOSNo.Value = HdnUID.Value;
                    LOSNo.ParameterName = "@Loan_App_No";
                    sqlCom.Parameters.Add(LOSNo);

                    SqlParameter userid = new SqlParameter();
                    userid.SqlDbType = SqlDbType.VarChar;
                    userid.Value = Convert.ToString(((UserInfo.structUSERInfo)(SaveUSERInfo)).UserId);
                    userid.ParameterName = "@userid";
                    sqlCom.Parameters.Add(LOSNo);

                    sqlCon.Open();

                    int SqlRow = 0;
                    SqlRow = sqlCom.ExecuteNonQuery();
                    if (SqlRow > 0)
                    {
                        Autoassign();
                    }
                    else
                    {

                    }
                }

            }
        }
        catch (Exception)
        {

            throw;
        }
       
    }


    protected void lnkCompleteExit_Click1(object sender, EventArgs e)
    {
        Object SaveUSERInfo = (Object)Session["UserInfo"];

        SqlConnection sqlCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);
        try
        {

            for (int i = 0; i <= grdlos.Rows.Count - 1; i++)
            {
                DropDownList ddlstatus = (DropDownList)grdlos.Rows[i].FindControl("ddlstatus");

                TextBox txtremark = (TextBox)grdlos.Rows[i].FindControl("txtremark");

                HdnUID.Value = grdlos.Rows[i].Cells[0].Text.Trim();


                if (ddlstatus.SelectedValue.ToString() != null)
                {

                    SqlCommand sqlCom = new SqlCommand();
                    sqlCom.Connection = sqlCon;
                    sqlCom.CommandType = CommandType.StoredProcedure;
                    sqlCom.CommandText = "Hero_Housing_InsertRecordCam_SP";
                    sqlCom.CommandTimeout = 0;


                    SqlParameter Status = new SqlParameter();
                    Status.SqlDbType = SqlDbType.VarChar;
                    Status.Value = ddlstatus.SelectedValue.ToString();
                    Status.ParameterName = "@CamStatus";
                    sqlCom.Parameters.Add(Status);

                    SqlParameter Remark = new SqlParameter();
                    Remark.SqlDbType = SqlDbType.VarChar;
                    Remark.Value = txtremark.Text.ToString();
                    Remark.ParameterName = "@CamRemark";
                    sqlCom.Parameters.Add(Remark);


                    SqlParameter LOSNo = new SqlParameter();
                    LOSNo.SqlDbType = SqlDbType.VarChar;
                    LOSNo.Value = HdnUID.Value;
                    LOSNo.ParameterName = "@Loan_App_No";
                    sqlCom.Parameters.Add(LOSNo);

                    SqlParameter userid = new SqlParameter();
                    userid.SqlDbType = SqlDbType.VarChar;
                    userid.Value = Convert.ToString(((UserInfo.structUSERInfo)(SaveUSERInfo)).UserId);
                    userid.ParameterName = "@userid";
                    sqlCom.Parameters.Add(userid);

                    sqlCon.Open();

                    int SqlRow = 0;
                    SqlRow = sqlCom.ExecuteNonQuery();
                    if (SqlRow > 0)
                    {
                        if (Session["UserInfo"] != null)
                        {
                            //Session.Clear();
                            Response.Redirect("~/pages/Logout.aspx", false);
                        }

                    }

                }

            }
        }
        catch (Exception)
        {

            throw;
        }
    }


    public void Autoassign()
    {

        Object SaveUSERInfo = (Object)Session["UserInfo"];
        SqlConnection sqlCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);

        try
        {
            sqlCon.Open();
            SqlCommand sqlCom2 = new SqlCommand();
            sqlCom2.Connection = sqlCon;
            sqlCom2.CommandType = CommandType.StoredProcedure;
            sqlCom2.CommandText = "Hero_Housing_AutoAssign_Cam_SP";

            SqlParameter USERID = new SqlParameter();
            USERID.SqlDbType = SqlDbType.VarChar;
            USERID.Value = Convert.ToString(((UserInfo.structUSERInfo)(SaveUSERInfo)).UserId);
            USERID.ParameterName = "@userid";
            sqlCom2.Parameters.Add(USERID);

            SqlDataAdapter adp = new SqlDataAdapter();
            adp.SelectCommand = sqlCom2;
            DataTable dt = new DataTable();
            adp.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Updatedate(dt.Rows[i]);
                }

            }


            grdlos.DataSource = dt;
            grdlos.DataBind();



            int SqlRow = 0;
            SqlRow = sqlCom2.ExecuteNonQuery();

        }
        catch (Exception ex)
        {
            //lblMessage.Visible = true;
            //lblMessage.Text = "Error :" + ex.Message;
        }
        sqlCon.Close();
    }



    public void Updatedate(DataRow dr)
    {
        Object SaveUSERInfo = (Object)Session["UserInfo"];

        SqlConnection sqlCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);
        try
        {
            sqlCon.Open();
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlCon;
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.CommandText = "Hero_Housing_DateUpdate_Cam_SP";
            sqlcmd.CommandTimeout = 0;

            SqlParameter loanAppNo = new SqlParameter();
            loanAppNo.SqlDbType = SqlDbType.VarChar;
            loanAppNo.Value = dr["Loan_App_No"].ToString().Trim();
            loanAppNo.ParameterName = "@Loan_App_No";
            sqlcmd.Parameters.Add(loanAppNo);




            SqlParameter DataEntryStartTime = new SqlParameter();
            DataEntryStartTime.SqlDbType = SqlDbType.DateTime;
            DataEntryStartTime.Value = DateTime.Now;
            DataEntryStartTime.ParameterName = "@CamStartTime";
            sqlcmd.Parameters.Add(DataEntryStartTime);

            sqlcmd.ExecuteNonQuery();

            sqlCon.Close();

        }
        catch (Exception)
        {

            throw;
        }

    }
}