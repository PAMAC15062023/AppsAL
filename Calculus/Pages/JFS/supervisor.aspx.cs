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

public partial class Pages_JFS_supervisor : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Get_DataForIndexing();
        }

    }

    private void Get_DataForIndexing()
    {
        Object SaveUSERInfo = (Object)Session["UserInfo"];
        SqlConnection sqlCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);

        string proc;
        if (ddltype.SelectedItem.ToString() == "DA")
        {
            proc = "JFSCompleteMISDA";
        }
        else if (ddltype.SelectedItem.ToString() == "Query Resolved")
        {
            proc = "getdate_forQR";
        }

        else
        {
            proc = "getdate_forDE";
        }



        SqlCommand sqlCom = new SqlCommand();
        sqlCom.Connection = sqlCon;
        sqlCom.CommandType = CommandType.StoredProcedure;
        sqlCom.CommandText = proc;
        sqlCom.CommandTimeout = 0;

        if (ddlrpclocation.SelectedIndex == 0)
        {
            SqlParameter BranchID = new SqlParameter();
            BranchID.SqlDbType = SqlDbType.VarChar;
            BranchID.Value = Convert.ToString(((UserInfo.structUSERInfo)(SaveUSERInfo)).BranchId);
            BranchID.ParameterName = "@BranchID";
            sqlCom.Parameters.Add(BranchID);
        }
        else
        {
            SqlParameter BranchID = new SqlParameter();
            BranchID.SqlDbType = SqlDbType.VarChar;
            BranchID.Value = ddlrpclocation.SelectedValue.ToString();
            BranchID.ParameterName = "@BranchID";
            sqlCom.Parameters.Add(BranchID);
        }
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

    protected void ddltype_SelectedIndexChanged(object sender, EventArgs e)
    {
        Get_DataForIndexing();
    }
    protected void ddlrpclocation_SelectedIndexChanged(object sender, EventArgs e)
    {
        Get_DataForIndexing();
    }
    protected void Btnchangerpc_Click(object sender, EventArgs e)
    {
        if (ddlrpclocation.SelectedIndex.ToString() != "0")
        {
            for (int i = 0; i <= grdlos.Rows.Count - 1; i++)
            {
                Object SaveUSERInfo = (Object)Session["UserInfo"];
                SqlConnection sqlCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);
                CheckBox chkSelect = (CheckBox)grdlos.Rows[i].FindControl("chkSelect");
                LinkButton WIP = (LinkButton)grdlos.Rows[i].FindControl("lnkWIP");
                HdnUID.Value = grdlos.Rows[i].Cells[1].Text.Trim();

                if (chkSelect.Checked == true)
                {
                    SqlCommand sqlCom1 = new SqlCommand();
                    sqlCom1.Connection = sqlCon;
                    sqlCom1.CommandType = CommandType.StoredProcedure;
                    sqlCom1.CommandText = "update_location";
                    sqlCom1.CommandTimeout = 0;

                    SqlParameter Rpclocation = new SqlParameter();
                    Rpclocation.SqlDbType = SqlDbType.VarChar;
                    Rpclocation.Value = ddlchngrpc.SelectedValue.ToString();
                    Rpclocation.ParameterName = "@branch_id";
                    sqlCom1.Parameters.Add(Rpclocation);

                    SqlParameter LOSNo1 = new SqlParameter();
                    LOSNo1.SqlDbType = SqlDbType.VarChar;
                    LOSNo1.Value = HdnUID.Value;
                    LOSNo1.ParameterName = "@auto_application_no";
                    sqlCom1.Parameters.Add(LOSNo1);

                    sqlCon.Open();

                    int SqlRow = 0;
                    SqlRow = sqlCom1.ExecuteNonQuery();

                    sqlCon.Close();
                }
            }
            Get_DataForIndexing();
        }
        else
        {
            lblMessage.Text = "Please Select RPC Location !!!";
        }
    }

    private void Get_UserList()
    {
        try
        {
            string proc;
            Object SaveUSERInfo = (Object)Session["UserInfo"];
            SqlConnection sqlCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);

            if (DropDownList1.SelectedValue.ToString() == "DA")
            {
                proc = "Get_UserDAList";
            }
            else if (DropDownList1.SelectedValue.ToString() == "Query Resolved")
            {
                proc = "Get_UserQRList";
            }
            else
            {
                proc = "Get_UserDEList";
            }

            SqlCommand sqlCom = new SqlCommand();
            sqlCom.Connection = sqlCon;
            sqlCom.CommandType = CommandType.StoredProcedure;
            sqlCom.CommandText = proc;
            sqlCom.CommandTimeout = 0;

            if (ddlrpclocation.SelectedIndex == 0)
            {
                SqlParameter PMSlocation = new SqlParameter();
                PMSlocation.SqlDbType = SqlDbType.VarChar;
                PMSlocation.Value = Convert.ToString(((UserInfo.structUSERInfo)(SaveUSERInfo)).BranchId);
                PMSlocation.ParameterName = "@PMSlocation";
                sqlCom.Parameters.Add(PMSlocation);
            }
            else
            {
                SqlParameter PMSlocation = new SqlParameter();
                PMSlocation.SqlDbType = SqlDbType.VarChar;
                PMSlocation.Value = ddlrpclocation.SelectedValue.ToString();
                PMSlocation.ParameterName = "@PMSlocation";
                sqlCom.Parameters.Add(PMSlocation);
            }

            sqlCon.Open();
            SqlDataAdapter sqlDA = new SqlDataAdapter();
            sqlDA.SelectCommand = sqlCom;
            DataTable dt = new DataTable();
            sqlDA.Fill(dt);

            sqlCon.Close();

            DropDownList2.DataTextField = "username";
            DropDownList2.DataValueField = "createdby";

            DropDownList2.DataSource = dt;
            DropDownList2.DataBind();

            DropDownList2.Items.Insert(0, new ListItem("--Select--", "0"));
            DropDownList2.SelectedIndex = 0;


        }
        catch (Exception ex)
        {
            lblMessage.Visible = true;
            lblMessage.Text = ex.Message;
            lblMessage.CssClass = "ErrorMessage";
        }
    }
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        Get_UserList();
        DropDownList1.BackColor = System.Drawing.Color.FromName("White");
        DropDownList2.BackColor = System.Drawing.Color.FromName("Yellow");
        lblMessage.Text = "Please Select Atleast One Record & User...!!!";
    }
    protected void BtnAssign_Click(object sender, EventArgs e)
    {
        string proc;
        if (DropDownList1.SelectedIndex.ToString() != "0")
        {
            if (DropDownList2.SelectedIndex.ToString() != "0")
            {
                for (int i = 0; i <= grdlos.Rows.Count - 1; i++)
                {
                    Object SaveUSERInfo = (Object)Session["UserInfo"];
                    SqlConnection sqlCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);
                    CheckBox chkSelect = (CheckBox)grdlos.Rows[i].FindControl("chkSelect");
                    LinkButton WIP = (LinkButton)grdlos.Rows[i].FindControl("lnkWIP");
                    HdnUID.Value = grdlos.Rows[i].Cells[1].Text.Trim();

                    if (chkSelect.Checked == true)
                    {
                        if (DropDownList1.SelectedValue.ToString() == "DA")
                        {
                            proc = "assignManual_da";
                        }
                        else if (DropDownList1.SelectedValue.ToString() == "Query Resolved")
                        {
                            proc = "assignManual_QR";
                        }
                        else
                        {
                            proc = "assignManual_de";
                        }

                        SqlCommand sqlCom = new SqlCommand();
                        sqlCom.Connection = sqlCon;
                        sqlCom.CommandType = CommandType.StoredProcedure;
                        sqlCom.CommandText = proc;
                        sqlCom.CommandTimeout = 0;

                        SqlParameter UserID = new SqlParameter();
                        UserID.SqlDbType = SqlDbType.VarChar;
                        UserID.Value = DropDownList2.SelectedValue.ToString();
                        UserID.ParameterName = "@user_id";
                        sqlCom.Parameters.Add(UserID);

                        SqlParameter LOSNo = new SqlParameter();
                        LOSNo.SqlDbType = SqlDbType.VarChar;
                        LOSNo.Value = HdnUID.Value;
                        LOSNo.ParameterName = "@auto_application_no";
                        sqlCom.Parameters.Add(LOSNo);

                        sqlCon.Open();

                        int K = 0;
                        K = sqlCom.ExecuteNonQuery();

                        sqlCon.Close();

                        if (K > 0)
                        {
                            lblMessage.Text = "Application Assign To :" + DropDownList1.SelectedValue.ToString() + " : " + DropDownList2.SelectedItem.ToString();
                            DropDownList1.BackColor = System.Drawing.Color.FromName("White");
                            DropDownList2.BackColor = System.Drawing.Color.FromName("White");
                        }
                        else
                        {
                            lblMessage.Text = "Application Already In Process";

                            DropDownList1.BackColor = System.Drawing.Color.FromName("White");
                            DropDownList2.BackColor = System.Drawing.Color.FromName("White");
                        }
                    }
                    else
                    {
                        DropDownList1.BackColor = System.Drawing.Color.FromName("White");
                    }
                }
            }
            else
            {
                lblMessage.Text = "Please Select Atleast One Record & User...!!!";
                DropDownList1.BackColor = System.Drawing.Color.FromName("yellow");
            }
        }
        else
        {
            lblMessage.Text = "Please Select Atleast One Record & Type...!!!";
            DropDownList1.BackColor = System.Drawing.Color.FromName("yellow");
        }
        Get_DataForIndexing();
    }
    protected void btncancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Pages/Menu.aspx", true);
    }
    protected void grdlos_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            string input = e.Row.Cells[7].Text.Replace("&nbsp;", "");

            if (input != "")
            {

                DateTime dtinput = Convert.ToDateTime(input);


                string subTime = input.Substring(10, 8);

                string subDate = input.Substring(0, 9);


                DateTime hrs = Convert.ToDateTime(System.DateTime.Now.ToString("t"));
                string todaydate = Convert.ToString(hrs).Substring(0, 9);
                string subtimenow = Convert.ToString(hrs).Substring(10, 8);


                string strNOW = hrs.ToString("HH:mm:ss tt");
                string strINPUT = dtinput.ToString("HH:mm:ss tt");




                if (subDate == todaydate)
                {
                    double seconds = 3600 * 6;


                    TimeSpan TAT = DateTime.Parse(strNOW) - DateTime.Parse(strINPUT);

                    double secondstat = (3600 * TAT.Hours) + (TAT.Minutes * 60) + TAT.Seconds;


                    if (secondstat < seconds)
                    {
                        e.Row.BackColor = Color.FromName("white");
                    }
                    else
                    {
                        e.Row.ForeColor = Color.FromName("red");
                    }
                }
                else
                {
                    e.Row.ForeColor = Color.FromName("red");
                }
            }

        }
    }
}