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
using System.IO;

public partial class Pages_TCFSL_CDLOAN_DownTimeTracker : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindSystem();
            //bind();
        }
        Object SaveUSERInfo = (Object)Session["UserInfo"];
    }
    protected void BindSystem()
    {
        SqlConnection sqlCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);

            SqlCommand cmd = new SqlCommand("TCFSL_MasterSearchCode_SP", sqlCon);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Types", "SystemType");
            cmd.Parameters.AddWithValue("@Level", 1);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            adp.Fill(ds);

            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                ddlSystem.DataSource = ds;
                ddlSystem.DataValueField = "Code_Id";
                ddlSystem.DataTextField = "Description";
                ddlSystem.DataBind();
                ddlSystem.Items.Insert(0, new ListItem("--Select--", "0"));
            }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        Save();
    }
    public void Save()
    {
        Object SaveUSERInfo = (Object)Session["UserInfo"];
        SqlConnection sqlCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);

        try
        {
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlCon;
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.CommandText = "TCFSL__DownTimeTracker_SP";
            sqlcmd.CommandTimeout = 0;

            if (ddlSystem.SelectedValue != "" && ddlSystem.SelectedValue != "--Select--" && ddlSystem.SelectedValue != "0")
            {
                SqlParameter Info_STATUS = new SqlParameter();
                Info_STATUS.SqlDbType = SqlDbType.VarChar;
                Info_STATUS.Value = ddlSystem.SelectedValue.ToString();
                Info_STATUS.ParameterName = "@Info_STATUS";
                sqlcmd.Parameters.Add(Info_STATUS);
            }
            else
            {
                hiddenResult.Value = "Kindly Select System..!!";
                ddlSystem.Focus();
                return;
            }

            if (txtStrtdate.Text.ToString().Trim() != "")
            {

                SqlParameter StrtDate = new SqlParameter();
                StrtDate.SqlDbType = SqlDbType.DateTime;
                StrtDate.Value = txtStrtdate.Text.Trim().ToString();
                StrtDate.ParameterName = "@StrtDate";
                sqlcmd.Parameters.Add(StrtDate);
            }
            else
            {
                hiddenResult.Value = "Enter StartTime Date";
                txtStrtdate.Focus();
                return;
            }


            if (txtTillDate.Text.ToString().Trim() != "")
            {

                SqlParameter TillDate = new SqlParameter();
                TillDate.SqlDbType = SqlDbType.DateTime;
                TillDate.Value = txtTillDate.Text.Trim().ToString();
                TillDate.ParameterName = "@TillDate";
                sqlcmd.Parameters.Add(TillDate);
            }
            else
            {
                hiddenResult.Value = "Enter TillTime Date";
                txtTillDate.Focus();
                return;
            }


            //if (txtTillTime.Text.ToString().Trim() != "")
            //{
            //    SqlParameter TillTime = new SqlParameter();
            //    TillTime.SqlDbType = SqlDbType.VarChar;
            //    TillTime.Value = txtTillTime.Text.Trim().ToString();
            //    TillTime.ParameterName = "@TillTime";
            //    sqlcmd.Parameters.Add(TillTime);
            //}
            //else
            //{
            //    hiddenResult.Value = "Enter TillTime :";
            //    txtTillTime.Focus();
            //    return;
            //}


            //if (txtStrttime.Text.ToString().Trim() != "")
            //{
            //    SqlParameter Strttime = new SqlParameter();
            //    Strttime.SqlDbType = SqlDbType.VarChar;
            //    Strttime.Value = txtStrttime.Text.Trim().ToString();
            //    Strttime.ParameterName = "@Strttime";
            //    sqlcmd.Parameters.Add(Strttime);
            //}
            //else
            //{
            //    hiddenResult.Value = "Enter StartTime :";
            //    txtStrttime.Focus();
            //    return;
            //}
            SqlParameter Branch_Id = new SqlParameter();
            Branch_Id.SqlDbType = SqlDbType.VarChar;
            Branch_Id.Value = Convert.ToString(((UserInfo.structUSERInfo)(SaveUSERInfo)).BranchId);
            Branch_Id.ParameterName = "@Branch_Id";
            sqlcmd.Parameters.Add(Branch_Id);

            SqlParameter AddedBy = new SqlParameter();
            AddedBy.SqlDbType = SqlDbType.VarChar;
            AddedBy.Value = Convert.ToString(((UserInfo.structUSERInfo)(SaveUSERInfo)).UserId);
            AddedBy.ParameterName = "@AddedBy";
            sqlcmd.Parameters.Add(AddedBy);

            sqlcmd.Parameters.Add("@remark", txtRemark.Text.Trim().ToString());

            sqlCon.Open();
            int RowEffected = 0;
            RowEffected = sqlcmd.ExecuteNonQuery();
            sqlCon.Close();

            if (RowEffected > 0)
            {
                //validate();
                hiddenResult.Value = "Submit Successfully!";

                txtStrtdate.Text = "";
                //txtStrttime.Text = "";
                txtTillDate.Text = "";
               // txtTillTime.Text = "";
                txtRemark.Text = "";
                ddlSystem.SelectedValue = "0";
            }
        }
        catch (Exception ex)
        {

            throw;
        }
        finally
        {

        }

    }
    //public void bind()
    //{
    //    Object SaveUSERInfo = (Object)Session["UserInfo"];

    //    using (SqlConnection sqlCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]))
    //    {

    //        SqlCommand sqlcmd = new SqlCommand();
    //        sqlcmd.Connection = sqlCon;
    //        sqlcmd.CommandType = CommandType.StoredProcedure;
    //        sqlcmd.CommandText = "RPC_GetDownTime";
    //        sqlcmd.CommandTimeout = 0;

    //        SqlParameter AddedBy = new SqlParameter();
    //        AddedBy.SqlDbType = SqlDbType.VarChar;
    //        AddedBy.Value = Convert.ToString(((UserInfo.structUSERInfo)(SaveUSERInfo)).UserId);
    //        AddedBy.ParameterName = "@AddedBy";
    //        sqlcmd.Parameters.Add(AddedBy);

    //        SqlDataAdapter ad = new SqlDataAdapter();
    //        ad.SelectCommand = sqlcmd;

    //        DataTable dt = new DataTable();
    //        ad.Fill(dt);

    //        if (dt.Rows.Count > 0)
    //        {
    //            GridView1.DataSource = dt;
    //            GridView1.DataBind();
    //            for (int i = 0; i < GridView1.Rows.Count; i++)
    //            {
    //                LinkButton lnkEdit = (LinkButton)GridView1.Rows[i].FindControl("lnkEditEmp");
    //                string GrdUpTimeDate = GridView1.Rows[i].Cells[4].Text.Trim();
    //                if (GrdUpTimeDate != "" && GrdUpTimeDate != "&nbsp;")
    //                {
    //                    lnkEdit.Enabled = false;
    //                }
    //                else
    //                {
    //                    lnkEdit.Enabled = true;
    //                }
    //            }
    //        }
    //        else
    //        {
    //            //GridView1.DataSource = "null";
    //            //GridView1.DataBind();
    //        }

    //    }
    //}
    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Pages/Menu.aspx", true);
    }
}