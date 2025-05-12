using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class Pages_ICICIRPC_Bank_Cal : System.Web.UI.Page
{
    //SingleUserLogin Login = new SingleUserLogin();
    protected void Page_Load(object sender, EventArgs e)
    {
        //Login.ValidateTokenLoginDetails();
        if (!IsPostBack)
        {
            Sp_Assign_bnk_cal();
            Sp_Assign_LOSToIndexcer123();

        }

    }
    protected void lnkWIP_Click(object sender, EventArgs e)
    {
        Object SaveUSERInfo = (Object)Session["UserInfo"];

        SqlConnection sqlCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);


        try
        {

            for (int i = 0; i <= grdlos.Rows.Count - 1; i++)
            {
                CheckBox chkSelect = (CheckBox)grdlos.Rows[i].FindControl("chkSelect");

                LinkButton WIP = (LinkButton)grdlos.Rows[i].FindControl("lnkWIP");

                HdnUID.Value = grdlos.Rows[i].Cells[3].Text.Trim();

                string Remark = null;
                if (chkSelect.Checked == true)
                {




                    SqlCommand sqlCom = new SqlCommand();
                    sqlCom.Connection = sqlCon;
                    sqlCom.CommandType = CommandType.StoredProcedure;
                    sqlCom.CommandText = "IRPC_ICICIBank_Cal_SP";
                    sqlCom.CommandTimeout = 0;


                    SqlParameter UserID = new SqlParameter();
                    UserID.SqlDbType = SqlDbType.VarChar;

                    UserID.Value = Convert.ToString(((UserInfo.structUSERInfo)(SaveUSERInfo)).UserId);
                    UserID.ParameterName = "@User_ID";
                    sqlCom.Parameters.Add(UserID);

                    SqlParameter LOSNo = new SqlParameter();
                    LOSNo.SqlDbType = SqlDbType.VarChar;
                    LOSNo.Value = HdnUID.Value;
                    LOSNo.ParameterName = "@LOSNo";
                    sqlCom.Parameters.Add(LOSNo);

                    sqlCon.Open();

                    int SqlRow = 0;
                    SqlRow = sqlCom.ExecuteNonQuery();

                    sqlCon.Close();

                    if (SqlRow > 0)
                    {

                    }

                }
                else
                {
                    //lblMsg.Text = "Please Select Atleast One Record...!!!";
                }



            }
            Sp_Assign_LOSToIndexcer123();
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


    private void Sp_Assign_bnk_cal()
    {
        Object SaveUSERInfo = (Object)Session["UserInfo"];
        SqlConnection sqlCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);

        try
        {
            SqlCommand sqlCom2 = new SqlCommand();
            sqlCom2.Connection = sqlCon;
            sqlCom2.CommandType = CommandType.StoredProcedure;
            sqlCom2.CommandText = "IRPC_Assign_ICICITOBank_Calcu_Product_SP";

            SqlDataAdapter sqlDA2 = new SqlDataAdapter();
            sqlDA2.SelectCommand = sqlCom2;

            SqlParameter PMSlocation = new SqlParameter();
            PMSlocation.SqlDbType = SqlDbType.VarChar;
            PMSlocation.Value = Convert.ToString(((UserInfo.structUSERInfo)(SaveUSERInfo)).BranchId);
            PMSlocation.ParameterName = "@icicilocation";
            sqlCom2.Parameters.Add(PMSlocation);



            SqlParameter product = new SqlParameter();
            product.SqlDbType = SqlDbType.VarChar;
            product.Value = "AL";
            product.ParameterName = "@Product";
            sqlCom2.Parameters.Add(product);


            sqlCon.Open();

            int SqlRow = 0;
            SqlRow = sqlCom2.ExecuteNonQuery();

            sqlCon.Close();

            if (SqlRow > 0)
            {

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

    private void Sp_Assign_LOSToIndexcer123()
    {
        Object SaveUSERInfo = (Object)Session["UserInfo"];
        SqlConnection sqlCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);

        try
        {
            SqlCommand sqlCom2 = new SqlCommand();
            sqlCom2.Connection = sqlCon;
            sqlCom2.CommandType = CommandType.StoredProcedure;
            sqlCom2.CommandText = "IRPC_ICICI_BnkCal_Product_SP";

            SqlDataAdapter sqlDA2 = new SqlDataAdapter();
            sqlDA2.SelectCommand = sqlCom2;

            SqlParameter PMSlocation = new SqlParameter();
            PMSlocation.SqlDbType = SqlDbType.VarChar;
            PMSlocation.Value = Convert.ToString(((UserInfo.structUSERInfo)(SaveUSERInfo)).BranchId);
            PMSlocation.ParameterName = "@location";
            sqlCom2.Parameters.Add(PMSlocation);

            SqlParameter userid = new SqlParameter();
            userid.SqlDbType = SqlDbType.VarChar;
            userid.Value = Convert.ToString(((UserInfo.structUSERInfo)(SaveUSERInfo)).UserId);
            userid.ParameterName = "@userid";
            sqlCom2.Parameters.Add(userid);


            //SqlParameter product = new SqlParameter();
            //product.SqlDbType = SqlDbType.VarChar;
            //product.Value = Convert.ToString(((UserInfo.structUSERInfo)(SaveUSERInfo)).ActivityName);
            //product.ParameterName = "@Product";
            //sqlCom2.Parameters.Add(product);

            sqlCon.Open();

            SqlDataAdapter sqlDA = new SqlDataAdapter();
            sqlDA.SelectCommand = sqlCom2;

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

    protected void lnkcompandnew_Click(object sender, EventArgs e)
    {
        Object SaveUSERInfo = (Object)Session["UserInfo"];

        SqlConnection sqlCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);
        try
        {
            for (int i = 0; i <= grdlos.Rows.Count - 1; i++)
            {
                CheckBox chkSelect = (CheckBox)grdlos.Rows[i].FindControl("chkSelect");

                DropDownList ddlstatus = (DropDownList)grdlos.Rows[i].FindControl("ddlstatus");
                TextBox txtremark = (TextBox)grdlos.Rows[i].FindControl("txtremark");

                HdnUID.Value = grdlos.Rows[i].Cells[3].Text.Trim();

                if (chkSelect.Checked == true)
                {
                    if (txtremark.Text != "")
                    {

                        if (ddlstatus.SelectedIndex != 0)
                        {

                          

                            SqlCommand sqlCom = new SqlCommand();
                            sqlCom.Connection = sqlCon;
                            sqlCom.CommandType = CommandType.StoredProcedure;
                            sqlCom.CommandText = "IRPC_Save_ComStatus_BnkCal_SP";
                            sqlCom.CommandTimeout = 0;

                            SqlDataAdapter sqlDA = new SqlDataAdapter();
                            sqlDA.SelectCommand = sqlCom;

                            //SqlParameter UserID = new SqlParameter();
                            //UserID.SqlDbType = SqlDbType.VarChar;
                            //UserID.Value = Convert.ToString(((UserInfo.structUSERInfo)(SaveUSERInfo)).UserId);
                            //UserID.ParameterName = "@User_ID";
                            //sqlCom.Parameters.Add(UserID);

                            SqlParameter LOSNo = new SqlParameter();
                            LOSNo.SqlDbType = SqlDbType.VarChar;
                            LOSNo.Value = HdnUID.Value;
                            LOSNo.ParameterName = "@LOSNo";
                            sqlCom.Parameters.Add(LOSNo);

                            SqlParameter Status = new SqlParameter();
                            Status.SqlDbType = SqlDbType.VarChar;
                            Status.Value = ddlstatus.SelectedValue.ToString();
                            Status.ParameterName = "@bnkcalCompletedStatus";
                            sqlCom.Parameters.Add(Status);

                            SqlParameter Remark = new SqlParameter();
                            Remark.SqlDbType = SqlDbType.VarChar;
                            Remark.Value = txtremark.Text.Trim();
                            Remark.ParameterName = "@LosRemark";
                            sqlCom.Parameters.Add(Remark);

                            sqlCon.Open();

                            int SqlRow = 0;
                            SqlRow = sqlCom.ExecuteNonQuery();

                            sqlCon.Close();

                            if (SqlRow > 0)
                            {
                                Sp_Assign_bnk_cal();
                                lblMessage.Text = "";
                            }
                        }
                        else
                        {
                            lblMessage.Text = "Please Select Status...!!!";
                            ddlstatus.Focus();
                        }
                    }
                    else
                    {
                        lblMessage.Text = "Please Enter Remark........!!";
                        txtremark.Focus();
                    }
                }
                else
                {
                    //lblMsg.Text = "Please Select Atleast One Record...!!!";
                }

            }

            Sp_Assign_LOSToIndexcer123();
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
    protected void lnkcompletedExit_Click(object sender, EventArgs e)
    {

        Object SaveUSERInfo = (Object)Session["UserInfo"];

        SqlConnection sqlCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);

        try
        {
            for (int i = 0; i <= grdlos.Rows.Count - 1; i++)
            {
                CheckBox chkSelect = (CheckBox)grdlos.Rows[i].FindControl("chkSelect");

                DropDownList ddlstatus = (DropDownList)grdlos.Rows[i].FindControl("ddlstatus");
                TextBox txtremark = (TextBox)grdlos.Rows[i].FindControl("txtremark");

                HdnUID.Value = grdlos.Rows[i].Cells[3].Text.Trim();

                if (chkSelect.Checked == true)
                {
                    if (txtremark.Text != "")
                    {

                        if (ddlstatus.SelectedIndex != 0)
                        {

                            SqlCommand sqlCom = new SqlCommand();
                            sqlCom.Connection = sqlCon;
                            sqlCom.CommandType = CommandType.StoredProcedure;
                            sqlCom.CommandText = "IRPC_Save_ComStatus_BnkCal_SP";
                            sqlCom.CommandTimeout = 0;

                            SqlDataAdapter sqlDA = new SqlDataAdapter();
                            sqlDA.SelectCommand = sqlCom;

                            //SqlParameter UserID = new SqlParameter();
                            //UserID.SqlDbType = SqlDbType.VarChar;
                            //UserID.Value = Convert.ToString(((UserInfo.structUSERInfo)(SaveUSERInfo)).UserId);
                            //UserID.ParameterName = "@User_ID";
                            //sqlCom.Parameters.Add(UserID);

                            SqlParameter LOSNo = new SqlParameter();
                            LOSNo.SqlDbType = SqlDbType.VarChar;
                            LOSNo.Value = HdnUID.Value;
                            LOSNo.ParameterName = "@LOSNo";
                            sqlCom.Parameters.Add(LOSNo);

                            SqlParameter Status = new SqlParameter();
                            Status.SqlDbType = SqlDbType.VarChar;
                            Status.Value = ddlstatus.SelectedValue.ToString();
                            Status.ParameterName = "@bnkcalCompletedStatus";
                            sqlCom.Parameters.Add(Status);

                            SqlParameter Remark = new SqlParameter();
                            Remark.SqlDbType = SqlDbType.VarChar;
                            Remark.Value = txtremark.Text.Trim();
                            Remark.ParameterName = "@LosRemark";
                            sqlCom.Parameters.Add(Remark);

                            sqlCon.Open();

                            int SqlRow = 0;
                            SqlRow = sqlCom.ExecuteNonQuery();

                            sqlCon.Close();

                            if (SqlRow > 0)
                            {
                                Response.Redirect("~/pages/Logout.aspx", false);
                                //Sp_Assign_bnk_cal();
                                //lblMessage.Text = "";
                            }
                        }
                        else
                        {
                            lblMessage.Text = "Please Select Status...!!!";
                            ddlstatus.Focus();
                        }
                    }
                    else
                    {
                        lblMessage.Text = "Please Enter Remark........!!";
                        txtremark.Focus();
                    }
                }
                else
                {
                    //lblMsg.Text = "Please Select Atleast One Record...!!!";
                }

            }
            //Sp_Assign_LOSToIndexcer123();
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

    protected void grdlos_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        SqlConnection sqlCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);

        if (e.Row.RowType == DataControlRowType.DataRow)
        {


            DropDownList ddlstatus = (e.Row.FindControl("ddlstatus") as DropDownList);

            SqlCommand cmd = new SqlCommand("IRPC_MasterSearchCode_SP", sqlCon);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Types", "BKCStatusType");
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
                ddlstatus.Items.Insert(0, new ListItem("--Select--", "0"));
            }
        }
    }
}