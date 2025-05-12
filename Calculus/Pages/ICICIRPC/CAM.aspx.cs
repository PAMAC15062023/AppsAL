using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

public partial class Pages_ICICIRPC_CAM : System.Web.UI.Page
{
    //SingleUserLogin Login = new SingleUserLogin();
    protected void Page_Load(object sender, EventArgs e)
    {
        //Login.ValidateTokenLoginDetails();
        if (!IsPostBack)
        {
            if (Context.Request.QueryString["losno"] != null)
            {

                CAM();
                getdataforCAP_CAM();

            }
            else
            {
                Sp_Assign_LOSToCAM();
                Sp_Assign_LOSToIndexcer12();

            }
        }

    }

    public void getdataforCAP_CAM()
    {

        Object SaveUSERInfo = (Object)Session["UserInfo"];
        SqlConnection sqlCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);
        try
        {
            SqlCommand sqlCom = new SqlCommand();
            sqlCom.Connection = sqlCon;
            sqlCom.CommandType = CommandType.StoredProcedure;
            sqlCom.CommandText = "IRPC_ICICI_CAM_SP";//icici_CAM
            sqlCom.CommandTimeout = 0;

            SqlParameter USERID = new SqlParameter();
            USERID.SqlDbType = SqlDbType.VarChar;
            USERID.Value = Convert.ToString(((UserInfo.structUSERInfo)(SaveUSERInfo)).UserId);
            USERID.ParameterName = "@uid";
            sqlCom.Parameters.Add(USERID);

            SqlParameter LOSNo = new SqlParameter();
            LOSNo.SqlDbType = SqlDbType.VarChar;
            LOSNo.Value = Context.Request.QueryString["losno"].ToString();
            LOSNo.ParameterName = "@LOSNo";
            sqlCom.Parameters.Add(LOSNo);

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

                // grdlos.Columns[7].Visible = false;
                // grdlos.Columns[9].Visible = false;
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
    public void CAM()
    {

        Object SaveUSERInfo = (Object)Session["UserInfo"];
        SqlConnection sqlCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);

        try
        {
            SqlCommand sqlCom2 = new SqlCommand();
            sqlCom2.Connection = sqlCon;
            sqlCom2.CommandType = CommandType.StoredProcedure;
            sqlCom2.CommandText = "IRPC_CPV_TO_CAM_Assign_SP";  //CPVTOCAMAssign
            sqlCom2.CommandTimeout = 0;

            SqlDataAdapter sqlDA2 = new SqlDataAdapter();
            sqlDA2.SelectCommand = sqlCom2;

            SqlParameter Assign_to = new SqlParameter();
            Assign_to.SqlDbType = SqlDbType.VarChar;
            Assign_to.Value = Convert.ToString(((UserInfo.structUSERInfo)(SaveUSERInfo)).UserId);
            Assign_to.ParameterName = "@UserId";
            sqlCom2.Parameters.Add(Assign_to);

            SqlParameter LOSNo = new SqlParameter();
            LOSNo.SqlDbType = SqlDbType.VarChar;
            LOSNo.Value = Context.Request.QueryString["losno"].ToString();
            LOSNo.ParameterName = "@LOSNo";
            sqlCom2.Parameters.Add(LOSNo);

            sqlCon.Open();

            int SqlRow = 0;
            SqlRow = sqlCom2.ExecuteNonQuery();

            sqlCon.Close();


            if (SqlRow > 0)
            {
            }
            else
            {
                Response.Redirect("BDE.aspx");
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

    private void Sp_Assign_LOSToCAM()
    {
        Object SaveUSERInfo = (Object)Session["UserInfo"];
        SqlConnection sqlCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);

        try
        {
            SqlCommand sqlCom2 = new SqlCommand();
            sqlCom2.Connection = sqlCon;
            sqlCom2.CommandType = CommandType.StoredProcedure;
            sqlCom2.CommandText = "IRPC_Assign_BDE_TO_CAM_AUTO_Product_SP";//Assign_BDETOCAM_AUTO_product

            SqlDataAdapter sqlDA2 = new SqlDataAdapter();
            sqlDA2.SelectCommand = sqlCom2;

            SqlParameter PMSlocation = new SqlParameter();
            PMSlocation.SqlDbType = SqlDbType.VarChar;
            PMSlocation.Value = Convert.ToString(((UserInfo.structUSERInfo)(SaveUSERInfo)).BranchId);
            PMSlocation.ParameterName = "@icicilocation";
            sqlCom2.Parameters.Add(PMSlocation);

            SqlParameter product = new SqlParameter();
            product.SqlDbType = SqlDbType.VarChar;
            product.Value = Convert.ToString(((UserInfo.structUSERInfo)(SaveUSERInfo)).ActivityName);
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



    //private void Get_DataForIndesing()
    //{
    //    Object SaveUSERInfo = (Object)Session["UserInfo"];
    //    SqlConnection sqlCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);

    //    SqlCommand sqlCom = new SqlCommand();
    //    sqlCom.Connection = sqlCon;
    //    sqlCom.CommandType = CommandType.StoredProcedure;
    //    //sqlCom.CommandText = "Get_DataForIndesing12";     original
    //    sqlCom.CommandText = "Get_DataForIndesing123";
    //    sqlCom.CommandTimeout = 0;

    //    SqlParameter USERID = new SqlParameter();
    //    USERID.SqlDbType = SqlDbType.VarChar;
    //    USERID.Value = Convert.ToString(((UserInfo.structUSERInfo)(SaveUSERInfo)).UserId);
    //    USERID.ParameterName = "@UserID";
    //    sqlCom.Parameters.Add(USERID);

    //    SqlParameter GroupID = new SqlParameter();
    //    GroupID.SqlDbType = SqlDbType.Int;
    //    GroupID.Value = Convert.ToInt32(((UserInfo.structUSERInfo)(SaveUSERInfo)).GroupId);
    //    GroupID.ParameterName = "@GroupID";
    //    sqlCom.Parameters.Add(GroupID);

    //    sqlCon.Open();

    //    SqlDataAdapter sqlDA = new SqlDataAdapter();
    //    sqlDA.SelectCommand = sqlCom;

    //    DataTable dt = new DataTable();
    //    sqlDA.Fill(dt);

    //    sqlCon.Close();

    //    if (dt.Rows.Count > 0)
    //    {
    //        grdlos.DataSource = dt;
    //        grdlos.DataBind();

    //    }
    //    else
    //    {
    //        grdlos.DataSource = null;
    //        grdlos.DataBind();
    //    }

    //}

    protected void lnkClose_Click(object sender, EventArgs e)
    {

    }

    protected void btncancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Pages/Menu.aspx", true);
    }

    protected void lnkWIP_Click1(object sender, EventArgs e)
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
                    sqlCom.CommandText = "IRPC_ICICI_Indexer_CAM_SP";
                    sqlCom.CommandTimeout = 0;


                    SqlParameter UserID = new SqlParameter();
                    UserID.SqlDbType = SqlDbType.VarChar;
                    //UserID.Value = "P49506";
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

                        ////////////chkSelect.Checked = false;
                        ////////////chkSelect.Enabled = false;

                    }

                }
                else
                {
                    //lblMsg.Text = "Please Select Atleast One Record...!!!";
                }

            }

            Sp_Assign_LOSToIndexcer12();

            // Get_DataForIndesing();
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

    protected void lnkCompleted_Click(object sender, EventArgs e)
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

                //TextBox txtloanamount = (TextBox)grdlos.Rows[i].FindControl("txtloanamount");

                //TextBox txtloantenure = (TextBox)grdlos.Rows[i].FindControl("txtloantenure");



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
                            sqlCom.CommandText = "IRPC_BDE_ICICI_CAM_SP";
                            sqlCom.CommandTimeout = 0;

                            SqlDataAdapter sqlDA = new SqlDataAdapter();
                            sqlDA.SelectCommand = sqlCom;

                            //SqlParameter UserID = new SqlParameter();
                            //UserID.SqlDbType = SqlDbType.VarChar;
                            //UserID.Value = "P49506";
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
                            Status.ParameterName = "@LosStatus";
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

                                Sp_Assign_LOSToCAM();

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

            Sp_Assign_LOSToIndexcer12();


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

    protected void lnkdiscripant_Click(object sender, EventArgs e)
    {


        Object SaveUSERInfo = (Object)Session["UserInfo"];

        SqlConnection sqlCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);

        try
        {

            for (int i = 0; i <= grdlos.Rows.Count - 1; i++)
            {
                CheckBox chkSelect = (CheckBox)grdlos.Rows[i].FindControl("chkSelect");


                HdnUID.Value = grdlos.Rows[i].Cells[3].Text.Trim();


                if (chkSelect.Checked == true)
                {

                    SqlCommand sqlCom2 = new SqlCommand();
                    sqlCom2.Connection = sqlCon;
                    sqlCom2.CommandType = CommandType.StoredProcedure;
                    sqlCom2.CommandText = "IRPC_LOS_Discripant_SP";
                    sqlCom2.CommandTimeout = 0;

                    SqlDataAdapter sqlDA2 = new SqlDataAdapter();
                    sqlDA2.SelectCommand = sqlCom2;

                    SqlParameter LOSNo = new SqlParameter();
                    LOSNo.SqlDbType = SqlDbType.VarChar;
                    LOSNo.Value = HdnUID.Value;
                    LOSNo.ParameterName = "@LOSNo";
                    sqlCom2.Parameters.Add(LOSNo);

                    sqlCon.Open();

                    int SqlRow = 0;
                    SqlRow = sqlCom2.ExecuteNonQuery();

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
        // Get_DataForIndesing();

    }

    private void Sp_Assign_LOSToIndexcer12()
    {
        Object SaveUSERInfo = (Object)Session["UserInfo"];
        SqlConnection sqlCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);

        try
        {
            SqlCommand sqlCom2 = new SqlCommand();
            sqlCom2.Connection = sqlCon;
            sqlCom2.CommandType = CommandType.StoredProcedure;
            sqlCom2.CommandText = "IRPC_ICICI_CAM2_SP"; // sp_icici_CAM

            SqlDataAdapter sqlDA2 = new SqlDataAdapter();
            sqlDA2.SelectCommand = sqlCom2;

            SqlParameter PMSlocation = new SqlParameter();
            PMSlocation.SqlDbType = SqlDbType.VarChar;
            PMSlocation.Value = Convert.ToInt32(((UserInfo.structUSERInfo)(SaveUSERInfo)).BranchId);
            PMSlocation.ParameterName = "@location";
            sqlCom2.Parameters.Add(PMSlocation);

            SqlParameter userid = new SqlParameter();
            userid.SqlDbType = SqlDbType.VarChar;
            userid.Value = Convert.ToString(((UserInfo.structUSERInfo)(SaveUSERInfo)).UserId);
            userid.ParameterName = "@userid";
            sqlCom2.Parameters.Add(userid);

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




    private void Sp_Assign_LOSToIndexcer123()
    {
        Object SaveUSERInfo = (Object)Session["UserInfo"];
        SqlConnection sqlCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);
        try
        {

            SqlCommand sqlCom2 = new SqlCommand();
            sqlCom2.Connection = sqlCon;
            sqlCom2.CommandType = CommandType.StoredProcedure;
            sqlCom2.CommandText = "IRPC_ICICI_CAM_Inprocess_SP";

            SqlDataAdapter sqlDA2 = new SqlDataAdapter();
            sqlDA2.SelectCommand = sqlCom2;

            SqlParameter PMSlocation = new SqlParameter();
            PMSlocation.SqlDbType = SqlDbType.VarChar;
            PMSlocation.Value = Convert.ToInt32(((UserInfo.structUSERInfo)(SaveUSERInfo)).BranchId);
            PMSlocation.ParameterName = "@location";
            sqlCom2.Parameters.Add(PMSlocation);

            SqlParameter losno = new SqlParameter();
            losno.SqlDbType = SqlDbType.VarChar;
            losno.Value = HdnUID.Value;
            losno.ParameterName = "@losno";
            sqlCom2.Parameters.Add(losno);

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

    //protected void lnkCompleteExit_Click(object sender, EventArgs e)
    //{
    //    try
    //    {
    //        for (int i = 0; i <= grdlos.Rows.Count - 1; i++)
    //        {
    //            CheckBox chkSelect = (CheckBox)grdlos.Rows[i].FindControl("chkSelect");

    //            DropDownList ddlstatus = (DropDownList)grdlos.Rows[i].FindControl("ddlstatus");

    //            TextBox txtremark = (TextBox)grdlos.Rows[i].FindControl("txtremark");

    //            //TextBox txtloanamount = (TextBox)grdlos.Rows[i].FindControl("txtloanamount");

    //            //TextBox txtloantenure = (TextBox)grdlos.Rows[i].FindControl("txtloantenure");



    //            HdnUID.Value = grdlos.Rows[i].Cells[3].Text.Trim();


    //            if (chkSelect.Checked == true)
    //            {
    //                if (txtremark.Text != "")
    //                {

    //                    if (ddlstatus.SelectedIndex != 0)
    //                    {

    //                        Object SaveUSERInfo = (Object)Session["UserInfo"];

    //                        SqlConnection sqlCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);

    //                        SqlCommand sqlCom = new SqlCommand();
    //                        sqlCom.Connection = sqlCon;
    //                        sqlCom.CommandType = CommandType.StoredProcedure;
    //                        sqlCom.CommandText = "sp_BDEICICI_cam";
    //                        sqlCom.CommandTimeout = 0;

    //                        SqlDataAdapter sqlDA = new SqlDataAdapter();
    //                        sqlDA.SelectCommand = sqlCom;

    //                        //SqlParameter UserID = new SqlParameter();
    //                        //UserID.SqlDbType = SqlDbType.VarChar;
    //                        //UserID.Value = "P49506";
    //                        //UserID.ParameterName = "@User_ID";
    //                        //sqlCom.Parameters.Add(UserID);

    //                        SqlParameter LOSNo = new SqlParameter();
    //                        LOSNo.SqlDbType = SqlDbType.VarChar;
    //                        LOSNo.Value = HdnUID.Value;
    //                        LOSNo.ParameterName = "@LOSNo";
    //                        sqlCom.Parameters.Add(LOSNo);

    //                        SqlParameter Status = new SqlParameter();
    //                        Status.SqlDbType = SqlDbType.VarChar;
    //                        Status.Value = ddlstatus.SelectedValue.ToString();
    //                        Status.ParameterName = "@LosStatus";
    //                        sqlCom.Parameters.Add(Status);

    //                        SqlParameter Remark = new SqlParameter();
    //                        Remark.SqlDbType = SqlDbType.VarChar;
    //                        Remark.Value = txtremark.Text.Trim();
    //                        Remark.ParameterName = "@LosRemark";
    //                        sqlCom.Parameters.Add(Remark);


    //                        sqlCon.Open();

    //                        int SqlRow = 0;
    //                        SqlRow = sqlCom.ExecuteNonQuery();

    //                        sqlCon.Close();

    //                        if (SqlRow > 0)
    //                        {
    //                            if (Session["UserInfo"] != null)
    //                            {
    //                                //Session.Clear();
    //                                Response.Redirect("~/pages/Logout.aspx", false);
    //                            }

    //                            lblMessage.Text = "";

    //                        }
    //                    }
    //                    else
    //                    {
    //                        lblMessage.Text = "Please Select Status...!!!";
    //                        ddlstatus.Focus();

    //                    }
    //                }

    //                else
    //                {

    //                    lblMessage.Text = "Please Enter Remark........!!";
    //                    txtremark.Focus();
    //                }
    //            }
    //            else
    //            {
    //                //lblMsg.Text = "Please Select Atleast One Record...!!!";
    //            }

    //        }




    //    }
    //    catch (Exception ex)
    //    {
    //        lblMessage.Visible = true;
    //        lblMessage.Text = "Error :" + ex.Message;
    //    }
    //}

    protected void lnkCompleteExit_Click1(object sender, EventArgs e)
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

                //TextBox txtloanamount = (TextBox)grdlos.Rows[i].FindControl("txtloanamount");

                //TextBox txtloantenure = (TextBox)grdlos.Rows[i].FindControl("txtloantenure");



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
                            sqlCom.CommandText = "IRPC_BDE_ICICI_CAM_SP";
                            sqlCom.CommandTimeout = 0;

                            SqlDataAdapter sqlDA = new SqlDataAdapter();
                            sqlDA.SelectCommand = sqlCom;

                            //SqlParameter UserID = new SqlParameter();
                            //UserID.SqlDbType = SqlDbType.VarChar;
                            //UserID.Value = "P49506";
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
                            Status.ParameterName = "@LosStatus";
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
                                if (Session["UserInfo"] != null)
                                {
                                    //Session.Clear();
                                    Response.Redirect("~/pages/Logout.aspx", false);
                                }

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

    protected void grdlos_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        SqlConnection sqlCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);

        if (e.Row.RowType == DataControlRowType.DataRow)
        {


            DropDownList ddlstatus = (e.Row.FindControl("ddlstatus") as DropDownList);

            SqlCommand cmd = new SqlCommand("IRPC_MasterSearchCode_SP", sqlCon);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Types", "CAMStatus");
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