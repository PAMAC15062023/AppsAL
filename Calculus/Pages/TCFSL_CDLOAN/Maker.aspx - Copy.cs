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

public partial class Pages_TCFSL_CDLOAN_Maker : System.Web.UI.Page
{
    bool strselect = false;
    bool strstatus = false;
    bool strWIPstatus = false;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //added
            if (Context.Request.QueryString["caseno"] != null)
            {
                Sp_Assign_QCToMKR();
                get_griddate();
                get_importdata();
            }
            else
            {
                Sp_Assign_Maker();
                get_griddate();
                get_importdata();
            }
        }

    }
    private void Sp_Assign_Maker()
    {
        Object SaveUSERInfo = (Object)Session["UserInfo"];
        SqlConnection sqlCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);
        try
        {

            SqlCommand sqlCom2 = new SqlCommand();
            sqlCom2.Connection = sqlCon;
            sqlCom2.CommandType = CommandType.StoredProcedure;
            sqlCom2.CommandText = "Sp_Assign_makernew1";//Sp_Assign_maker,Sp_Assign_makernew

            SqlDataAdapter sqlDA2 = new SqlDataAdapter();
            sqlDA2.SelectCommand = sqlCom2;

            SqlParameter UserId = new SqlParameter();
            UserId.SqlDbType = SqlDbType.VarChar;
            UserId.Value = Convert.ToString(((UserInfo.structUSERInfo)(SaveUSERInfo)).UserId);
            UserId.ParameterName = "@UserId";
            sqlCom2.Parameters.Add(UserId);

            SqlParameter PMSlocation = new SqlParameter();
            PMSlocation.SqlDbType = SqlDbType.VarChar;
            PMSlocation.Value = Convert.ToString(((UserInfo.structUSERInfo)(SaveUSERInfo)).BranchId);
            PMSlocation.ParameterName = "@PMSlocation";
            sqlCom2.Parameters.Add(PMSlocation);


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
            hiddenResult.Value = "Error :" + ex.Message;
        }
        finally
        {
            sqlCon.Close();
            sqlCon.Dispose();
        }
    }
    ////added
    private void Sp_Assign_QCToMKR()
    {
        Object SaveUSERInfo = (Object)Session["UserInfo"];
        SqlConnection sqlCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);
        try
        {

            SqlCommand sqlCom2 = new SqlCommand();
            sqlCom2.Connection = sqlCon;
            sqlCom2.CommandType = CommandType.StoredProcedure;
            sqlCom2.CommandText = "Sp_Assign_QCTOLSR";

            SqlDataAdapter sqlDA2 = new SqlDataAdapter();
            sqlDA2.SelectCommand = sqlCom2;

            SqlParameter UserId = new SqlParameter();
            UserId.SqlDbType = SqlDbType.VarChar;
            UserId.Value = Convert.ToString(((UserInfo.structUSERInfo)(SaveUSERInfo)).UserId);
            UserId.ParameterName = "@UserId";
            sqlCom2.Parameters.Add(UserId);

            SqlParameter caseno = new SqlParameter();
            caseno.SqlDbType = SqlDbType.VarChar;
            caseno.Value = Context.Request.QueryString["caseno"].ToString();
            caseno.ParameterName = "@caseno";
            sqlCom2.Parameters.Add(caseno);


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
            hiddenResult.Value = "Error :" + ex.Message;
        }
        finally
        {
            sqlCon.Close();
            sqlCon.Dispose();
        }
    }
    //for grid bind
    private void get_griddate()
    {
        Object SaveUSERInfo = (Object)Session["UserInfo"];
        SqlConnection sqlCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);

        try
        {
            SqlCommand sqlCom2 = new SqlCommand();
            sqlCom2.Connection = sqlCon;
            sqlCom2.CommandType = CommandType.StoredProcedure;
            sqlCom2.CommandText = "TCFSLMaker_ShowgridNEW";

            SqlDataAdapter sqlDA2 = new SqlDataAdapter();
            sqlDA2.SelectCommand = sqlCom2;

            SqlParameter PMSlocation = new SqlParameter();
            PMSlocation.SqlDbType = SqlDbType.VarChar;
            PMSlocation.Value = Convert.ToString(((UserInfo.structUSERInfo)(SaveUSERInfo)).UserId);
            PMSlocation.ParameterName = "@user_Id";
            sqlCom2.Parameters.Add(PMSlocation);

            sqlCon.Open();

            SqlDataAdapter sqlDA = new SqlDataAdapter();
            sqlDA.SelectCommand = sqlCom2;

            DataTable dt = new DataTable();
            sqlDA.Fill(dt);

            sqlCon.Close();

            if (dt.Rows.Count > 0)
            {
                grddata.Visible = true;
                grddata.DataSource = dt;

                hdncaseno.Value = dt.Rows[0]["Case Number"].ToString();
                grddata.DataBind();

            }
            else
            {
                grddata.DataSource = null;
                grddata.DataBind();
                hdnfnno.Value = "";
            }

        }
        catch (Exception ex)
        {
            hiddenResult.Value = "Error :" + ex.Message;
        }
        finally
        {
            sqlCon.Close();
            sqlCon.Dispose();
        }

    }
    private void get_importdata()
    {
        Object SaveUSERInfo = (Object)Session["UserInfo"];
        SqlConnection sqlCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);

        try
        {

            //HiddenField hdndata = new HiddenField();
            //hdndata.Value = grdlos.Rows[i].Cells[3].Text.Trim();

            SqlCommand sqlCom2 = new SqlCommand();
            sqlCom2.Connection = sqlCon;
            sqlCom2.CommandType = CommandType.StoredProcedure;
            sqlCom2.CommandText = "TCFSLmaker_importdataNew";//TCFSLmaker_importdata

            SqlDataAdapter sqlDA2 = new SqlDataAdapter();
            sqlDA2.SelectCommand = sqlCom2;

            SqlParameter PMSlocation = new SqlParameter();
            PMSlocation.SqlDbType = SqlDbType.VarChar;
            PMSlocation.Value = Convert.ToString(((UserInfo.structUSERInfo)(SaveUSERInfo)).UserId);
            PMSlocation.ParameterName = "@user_Id";
            sqlCom2.Parameters.Add(PMSlocation);

            SqlParameter CASENO = new SqlParameter();
            CASENO.SqlDbType = SqlDbType.VarChar;
            CASENO.Value = hdncaseno.Value;
            CASENO.ParameterName = "@CASENO";
            sqlCom2.Parameters.Add(CASENO);



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
                DiscripancyGridBind();
                //get_importdata();
                get_griddate();
                lnkCompleteNext.Visible = false;
                lnkCompleteExit.Visible = false;
                lnkCompleteQC.Visible = false;//added

            }
            else
            {
                grdlos.DataSource = null;
                grdlos.DataBind();
                lnkCompleteNext.Visible = true;
                lnkCompleteExit.Visible = true;
                lnkCompleteQC.Visible = true;//added
            }

        }
        catch (Exception ex)
        {
            hiddenResult.Value = "Error :" + ex.Message;
        }
        finally
        {
            sqlCon.Close();
            sqlCon.Dispose();
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

                hdncaseno.Value = grdlos.Rows[i].Cells[4].Text.Trim();
                Hdnwebtop.Value = grdlos.Rows[i].Cells[6].Text.Trim();
                hdnfnno.Value = grdlos.Rows[i].Cells[5].Text.Trim();

                string Remark = null;

                if (chkSelect.Checked == true)
                {

                    strselect = true;

                    SqlCommand sqlCom = new SqlCommand();
                    sqlCom.Connection = sqlCon;
                    sqlCom.CommandType = CommandType.StoredProcedure;
                    sqlCom.CommandText = "TCFSLMaker_assign";
                    sqlCom.CommandTimeout = 0;


                    SqlParameter UserID = new SqlParameter();
                    UserID.SqlDbType = SqlDbType.VarChar;
                    UserID.Value = Convert.ToString(((UserInfo.structUSERInfo)(SaveUSERInfo)).UserId);
                    UserID.ParameterName = "@User_ID";
                    sqlCom.Parameters.Add(UserID);

                    SqlParameter caseno = new SqlParameter();
                    caseno.SqlDbType = SqlDbType.VarChar;
                    caseno.Value = hdncaseno.Value;
                    caseno.ParameterName = "@caseno";
                    sqlCom.Parameters.Add(caseno);

                    SqlParameter WebtopNo = new SqlParameter();
                    WebtopNo.SqlDbType = SqlDbType.VarChar;
                    WebtopNo.Value = Hdnwebtop.Value;
                    WebtopNo.ParameterName = "@WebtopNo";
                    sqlCom.Parameters.Add(WebtopNo);

                    SqlParameter Finno = new SqlParameter();
                    Finno.SqlDbType = SqlDbType.VarChar;
                    Finno.Value = hdnfnno.Value;
                    Finno.ParameterName = "@Finno";
                    sqlCom.Parameters.Add(Finno);

                    sqlCon.Open();

                    int SqlRow = 0;
                    SqlRow = sqlCom.ExecuteNonQuery();

                    sqlCon.Close();

                    if (SqlRow > 0)
                    {
                        hiddenResult.Value = "Inprocess...!!!";
                        //chkSelect.Checked = false;
                        //chkSelect.Enabled = false;
                        //Sp_Assign_LOSToBDE();

                    }

                }
                else
                {
                    if (!strselect)
                    {

                        hiddenResult.Value = "Please check on checkbox first...";
                    }
                }

            }
            Sp_Assign_Maker();
            get_importdata();


            // Get_DataForIndesing();
        }
        catch (Exception ex)
        {
            hiddenResult.Value = "Error :" + ex.Message;
        }
        finally
        {
            sqlCon.Close();
            sqlCon.Dispose();
        }
    }
    protected void ddlstatus_SelectedIndexChanged(object sender, EventArgs e)
    {
        Object SaveUSERInfo = (Object)Session["UserInfo"];

        SqlConnection sqlCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);
        try
        {
            if (sqlCon.State == ConnectionState.Closed)
            {
                sqlCon.Open();
                for (int i = 0; i <= grdlos.Rows.Count - 1; i++)
                {
                    CheckBox chkSelect = (CheckBox)grdlos.Rows[i].FindControl("chkSelect");

                    DropDownList Status = (DropDownList)grdlos.Rows[i].FindControl("ddlstatus");

                    Button Discripancy = (Button)grdlos.Rows[i].FindControl("btnAddDiscripancy");

                    TextBox txtdiscripancy = (TextBox)grdlos.Rows[i].FindControl("txtdiscripancy");

                    LinkButton Complete = (LinkButton)grdlos.Rows[i].FindControl("lnkComplete");

                    //LinkButton lnkCompleteNext = (LinkButton)grdlos.Rows[i].FindControl("lnkCompleteNext");

                    //TextBox txtremark = (TextBox)grdlos.Rows[i].FindControl("txtremark");
                    if (chkSelect.Checked == true)
                    {

                        strselect = true;

                        if (Status.SelectedItem.Text != "--Select--")
                        {
                            strstatus = true;
                            if ((Status.SelectedItem.Text == "Approved"))
                            {
                                txtdiscripancy.Visible = false;
                                Discripancy.Visible = false;
                                Complete.Enabled = true;
                                //txtremark.Visible = true;
                                lnkCompleteNext.Visible = true;
                                Complete.Visible = true;

                            }
                            else
                            {
                                txtdiscripancy.Visible = true;
                                Discripancy.Visible = true;
                                Complete.Enabled = true;
                                //txtremark.Visible = false;
                                lnkCompleteNext.Visible = false;
                                //Complete.Visible = false;
                            }

                        }

                        else
                        {
                            if (!strstatus)
                            {
                                hiddenResult.Value = "Select Status....!!!!!";
                                Status.SelectedIndex = 0;
                            }

                        }

                    }

                    else
                    {
                        if (!strselect)
                        {

                            hiddenResult.Value = "Please check on checkbox first...";
                            Status.SelectedIndex = 0;
                        }
                    }



                }

            }

        }

        catch (SqlException sqlex)
        {
            //lblMessage.Text = sqlex.Message.ToString();

        }
        catch (SystemException ex)
        {
            //lblMessage.Text = ex.Message.ToString();
        }
        finally
        {
            if (sqlCon.State == ConnectionState.Open)
            {
                sqlCon.Close();
            }

        }
    }
    //
    protected void btnAddDiscripancy_Click(object sender, EventArgs e)
    {
        Object SaveUSERInfo = (Object)Session["UserInfo"];

        SqlConnection sqlCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);
        try
        {
            if (sqlCon.State == ConnectionState.Closed)
            {
                sqlCon.Open();
                for (int i = 0; i <= grdlos.Rows.Count - 1; i++)
                {
                    CheckBox chkSelect = (CheckBox)grdlos.Rows[i].FindControl("chkSelect");

                    DropDownList Status = (DropDownList)grdlos.Rows[i].FindControl("ddlstatus");

                    Button AddDiscripancy = (Button)grdlos.Rows[i].FindControl("btnAddDiscripancy");

                    TextBox txtdiscripancy = (TextBox)grdlos.Rows[i].FindControl("txtdiscripancy");

                    LinkButton Complete = (LinkButton)grdlos.Rows[i].FindControl("lnkCompleteExit");

                    LinkButton lnkCompleteNext = (LinkButton)grdlos.Rows[i].FindControl("lnkCompleteNext");

                    hdncaseno.Value = grdlos.Rows[i].Cells[4].Text.Trim();
                    Hdnwebtop.Value = grdlos.Rows[i].Cells[6].Text.Trim();
                    hdnfnno.Value = grdlos.Rows[i].Cells[5].Text.Trim();

                    if (chkSelect.Checked == true)
                    {
                        strselect = true;

                        SqlCommand sqlCom = new SqlCommand();
                        sqlCom.Connection = sqlCon;
                        sqlCom.CommandType = CommandType.StoredProcedure;
                        sqlCom.CommandText = "TCFSL_Maker_AddDiscripancy";
                        sqlCom.CommandTimeout = 0;

                        SqlParameter caseno = new SqlParameter();
                        caseno.SqlDbType = SqlDbType.VarChar;
                        caseno.Value = hdncaseno.Value;
                        caseno.ParameterName = "@caseno";
                        sqlCom.Parameters.Add(caseno);

                        SqlParameter WebtopNo = new SqlParameter();
                        WebtopNo.SqlDbType = SqlDbType.VarChar;
                        WebtopNo.Value = Hdnwebtop.Value;
                        WebtopNo.ParameterName = "@WebtopNo";
                        sqlCom.Parameters.Add(WebtopNo);


                        SqlParameter Finno = new SqlParameter();
                        Finno.SqlDbType = SqlDbType.VarChar;
                        Finno.Value = hdnfnno.Value;
                        Finno.ParameterName = "@Finno";
                        sqlCom.Parameters.Add(Finno);


                        SqlParameter Discripancy = new SqlParameter();
                        Discripancy.SqlDbType = SqlDbType.VarChar;
                        Discripancy.Value = txtdiscripancy.Text.ToUpper().Trim();
                        Discripancy.ParameterName = "@Discripancy";
                        sqlCom.Parameters.Add(Discripancy);

                        SqlParameter Status1 = new SqlParameter();
                        Status1.SqlDbType = SqlDbType.VarChar;
                        Status1.Value = "Pending";
                        Status1.ParameterName = "@Status";
                        sqlCom.Parameters.Add(Status1);

                        SqlParameter stage = new SqlParameter();
                        stage.SqlDbType = SqlDbType.VarChar;
                        stage.Value = "Maker";
                        stage.ParameterName = "@stage";
                        sqlCom.Parameters.Add(stage);


                        SqlParameter StatusSelect = new SqlParameter();
                        StatusSelect.SqlDbType = SqlDbType.VarChar;
                        StatusSelect.Value = Status.SelectedItem.Value;
                        StatusSelect.ParameterName = "@StatusSelect";
                        sqlCom.Parameters.Add(StatusSelect);


                        int SqlRow = 0;
                        SqlRow = sqlCom.ExecuteNonQuery();

                        if (SqlRow > 0)
                        {
                            DiscripancyGridBind();
                            txtdiscripancy.Text = null;
                            Complete.Visible = true;
                            lnkCompleteNext.Visible = true;

                        }
                    }

                    else
                    {
                        if (!strselect)
                        {

                            hiddenResult.Value = "Please check on checkbox first...";
                            Status.SelectedIndex = 0;
                        }
                    }
                }
            }
        }

        catch (SqlException sqlex)
        {
            //lblMessage.Text = sqlex.Message.ToString();

        }
        catch (SystemException ex)
        {
            //lblMessage.Text = ex.Message.ToString();
        }
        finally
        {
            if (sqlCon.State == ConnectionState.Open)
            {
                sqlCon.Close();
            }
        }


    }
    public void DiscripancyGridBind()
    {
        Object SaveUSERInfo = (Object)Session["UserInfo"];

        SqlConnection sqlCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);
        try
        {
            for (int i = 0; i <= grdlos.Rows.Count - 1; i++)
            {
                CheckBox chkSelect = (CheckBox)grdlos.Rows[i].FindControl("chkSelect");

                DropDownList Status = (DropDownList)grdlos.Rows[i].FindControl("ddlstatus");

                Button AddDiscripancy = (Button)grdlos.Rows[i].FindControl("btnAddDiscripancy");

                TextBox txtdiscripancy = (TextBox)grdlos.Rows[i].FindControl("txtdiscripancy");

                hdncaseno.Value = grdlos.Rows[i].Cells[4].Text.Trim();
                Hdnwebtop.Value = grdlos.Rows[i].Cells[6].Text.Trim();
                hdnfnno.Value = grdlos.Rows[i].Cells[5].Text.Trim();

                SqlCommand sqlcmd = new SqlCommand();
                sqlcmd.Connection = sqlCon;
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.CommandText = "TCFSL_Maker_SelectDiscripancyNEW";
                sqlcmd.CommandTimeout = 0;

                SqlParameter caseno = new SqlParameter();
                caseno.SqlDbType = SqlDbType.VarChar;
                caseno.Value = hdncaseno.Value;
                caseno.ParameterName = "@caseno";
                sqlcmd.Parameters.Add(caseno);

                SqlParameter WebtopNo = new SqlParameter();
                WebtopNo.SqlDbType = SqlDbType.VarChar;
                WebtopNo.Value = Hdnwebtop.Value;
                WebtopNo.ParameterName = "@WebtopNo";
                sqlcmd.Parameters.Add(WebtopNo);

                sqlCon.Open();
                SqlDataAdapter sqlDA = new SqlDataAdapter();
                sqlDA.SelectCommand = sqlcmd;

                DataTable dt = new DataTable();
                sqlDA.Fill(dt);

                sqlCon.Close();
                if (dt.Rows.Count > 0)
                {
                    GridDiscripancy.Visible = true;
                    GridDiscripancy.DataSource = dt;
                    GridDiscripancy.DataBind();
                    hdnDisStatus.Value = dt.Rows[0]["StatusSelect"].ToString();
                    GridDiscripancy.Caption = hdnDisStatus.Value + ' ' + "Discripancy";
                    GridDiscripancy.Font.Bold = true;
                    //GridDiscripancy.Caption.ForeColor = System.Drawing.Color.Beige;

                }
                else
                {
                    GridDiscripancy.DataSource = null;
                    GridDiscripancy.DataBind();
                    GridDiscripancy.Visible = false;
                }

            }
        }
        catch (SqlException sqlex)
        {
            //lblMessage.Text = sqlex.Message.ToString();

        }
        catch (SystemException ex)
        {
            //lblMessage.Text = ex.Message.ToString();
        }
        finally
        {
            if (sqlCon.State == ConnectionState.Open)
            {
                sqlCon.Close();
            }
        }

    }
    protected void lnkresolve_click1(object sender, EventArgs e)
    {
        Object SaveUSERInfo = (Object)Session["UserInfo"];

        SqlConnection sqlCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);
        try
        {
            if (sqlCon.State == ConnectionState.Closed)
            {
                sqlCon.Open();
                for (int i = 0; i <= GridDiscripancy.Rows.Count - 1; i++)
                {
                    CheckBox chkSelect = (CheckBox)GridDiscripancy.Rows[i].FindControl("chkSelect");

                    LinkButton Start = (LinkButton)GridDiscripancy.Rows[i].FindControl("lnkresolve");

                    if (chkSelect.Checked == true)
                    {
                        hdncaseno.Value = GridDiscripancy.Rows[i].Cells[3].Text.Trim();
                        hdnfnno.Value = GridDiscripancy.Rows[i].Cells[4].Text.Trim();
                        HdnWIPStatus.Value = GridDiscripancy.Rows[i].Cells[6].Text.Trim();


                        SqlCommand sqlcmd = new SqlCommand();
                        sqlcmd.Connection = sqlCon;
                        sqlcmd.CommandType = CommandType.StoredProcedure;
                        sqlcmd.CommandText = "TCFSL_Maker_UpdateDiscripancy";
                        sqlcmd.CommandTimeout = 0;

                        SqlParameter Status = new SqlParameter();
                        Status.SqlDbType = SqlDbType.VarChar;
                        Status.Value = "Resolved";
                        Status.ParameterName = "@Status";
                        sqlcmd.Parameters.Add(Status);

                        SqlParameter caseno = new SqlParameter();
                        caseno.SqlDbType = SqlDbType.VarChar;
                        caseno.Value = hdncaseno.Value;
                        caseno.ParameterName = "@caseno";
                        sqlcmd.Parameters.Add(caseno);

                        SqlParameter Finno = new SqlParameter();
                        Finno.SqlDbType = SqlDbType.VarChar;
                        Finno.Value = hdnfnno.Value;
                        Finno.ParameterName = "@Finno";
                        sqlcmd.Parameters.Add(Finno);

                        SqlParameter Dis_ID = new SqlParameter();
                        Dis_ID.SqlDbType = SqlDbType.VarChar;
                        Dis_ID.Value = HdnWIPStatus.Value;
                        Dis_ID.ParameterName = "@Dis_ID";
                        sqlcmd.Parameters.Add(Dis_ID);


                        int SqlRow = 0;
                        SqlRow = sqlcmd.ExecuteNonQuery();

                        DiscripancyGridBind();
                        //GridDiscripancy.Visible = false;
                    }
                }
            }
        }
        catch (SqlException sqlex)
        {
            //lblMessage.Text = sqlex.Message.ToString();

        }
        catch (SystemException ex)
        {
            //lblMessage.Text = ex.Message.ToString();
        }
        finally
        {
            if (sqlCon.State == ConnectionState.Open)
            {
                sqlCon.Close();
            }
        }
    }
    protected void btncancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Pages/Menu.aspx", true);
    }
    //complete grid case method
    protected void lnkComplete_Click(object sender, EventArgs e)
    {
        Object SaveUSERInfo = (Object)Session["UserInfo"];
        SqlConnection sqlCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);
        try
        {
            for (int i = 0; i <= grdlos.Rows.Count - 1; i++)
            {
                CheckBox chkSelect = (CheckBox)grdlos.Rows[i].FindControl("chkSelect");
                DropDownList ddlstatus = (DropDownList)grdlos.Rows[i].FindControl("ddlstatus");
                //TextBox txtremark = (TextBox)grdlos.Rows[i].FindControl("txtremark");
                //   TextBox txtproduct = (TextBox)grdlos.Rows[i].FindControl("txtproduct");

                hdncaseno.Value = grdlos.Rows[i].Cells[4].Text.Trim();
                Hdnwebtop.Value = grdlos.Rows[i].Cells[6].Text.Trim();
                hdnfnno.Value = grdlos.Rows[i].Cells[5].Text.Trim();
                HdnWIPStatus.Value = grdlos.Rows[i].Cells[3].Text.Trim();

                if (chkSelect.Checked == true)
                {
                    strselect = true;
                    if (ddlstatus.SelectedIndex != 0)
                    {
                        strstatus = true;
                        if (HdnWIPStatus.Value == "InProcess")
                        {
                            strWIPstatus = true;
                            SqlCommand sqlCom = new SqlCommand();
                            sqlCom.Connection = sqlCon;
                            sqlCom.CommandType = CommandType.StoredProcedure;
                            sqlCom.CommandText = "MAKERCOMPLETE_TCFSL";
                            sqlCom.CommandTimeout = 0;

                            SqlDataAdapter sqlDA = new SqlDataAdapter();
                            sqlDA.SelectCommand = sqlCom;

                            SqlParameter UserID = new SqlParameter();
                            UserID.SqlDbType = SqlDbType.VarChar;
                            UserID.Value = Convert.ToString(((UserInfo.structUSERInfo)(SaveUSERInfo)).UserId);
                            UserID.ParameterName = "@User_ID";
                            sqlCom.Parameters.Add(UserID);

                            SqlParameter caseno = new SqlParameter();
                            caseno.SqlDbType = SqlDbType.VarChar;
                            caseno.Value = hdncaseno.Value;
                            caseno.ParameterName = "@caseno";
                            sqlCom.Parameters.Add(caseno);

                            SqlParameter WebtopNo = new SqlParameter();
                            WebtopNo.SqlDbType = SqlDbType.VarChar;
                            WebtopNo.Value = Hdnwebtop.Value;
                            WebtopNo.ParameterName = "@WebtopNo";
                            sqlCom.Parameters.Add(WebtopNo);

                            SqlParameter Finno = new SqlParameter();
                            Finno.SqlDbType = SqlDbType.VarChar;
                            Finno.Value = hdnfnno.Value;
                            Finno.ParameterName = "@Finno";
                            sqlCom.Parameters.Add(Finno);

                            if (ddlstatus.SelectedValue != "" && ddlstatus.SelectedValue != "--Select--")
                            {
                                SqlParameter Status = new SqlParameter();
                                Status.SqlDbType = SqlDbType.VarChar;
                                Status.Value = ddlstatus.SelectedValue.ToString();
                                Status.ParameterName = "@LosStatus";
                                sqlCom.Parameters.Add(Status);
                            }
                            else
                            {
                                hiddenResult.Value = "Select Status";
                                return;
                            }

                            sqlCon.Open();
                            int SqlRow = 0;
                            SqlRow = sqlCom.ExecuteNonQuery();
                            sqlCon.Close();
                            if (SqlRow > 0)
                            {
                                hiddenResult.Value = "Data Successfully Updated........!!";
                                GridDiscripancy.Visible = false;
                                //get_griddate();
                                get_importdata();
                            }
                        }


                        else
                        {
                            if (!strWIPstatus)
                            {
                                hiddenResult.Value = "Click on Start button.........!!";
                                return;
                            }


                        }

                    }
                    else
                    {
                        if (!strstatus)
                        {
                            hiddenResult.Value = "Please Select Status........!!";
                            return;
                        }
                    }

                }
                else
                {
                    if (!strselect)
                    {

                        hiddenResult.Value = "Please check on checkbox first...";
                        return;
                    }
                }
            }

            //get_griddate();
            //get_importdata();
        }
        catch (Exception ex)
        {
            hiddenResult.Value = "Error :" + ex.Message;
        }
        finally
        {
            sqlCon.Close();
            sqlCon.Dispose();
        }
    }
    //complete button outside grid method
    protected void lnkCompleteNext_Click(object sender, EventArgs e)
    {
        Sp_Assign_Maker();
        get_griddate();
        get_importdata();
    }
    protected void lnkCompleteExit_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Pages/Menu.aspx", true);
        hiddenResult.Value = "";
    }
    //added
    protected void lnkCompleteQC_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Pages/TCFSL_CDLOAN/Screening_QC.aspx", true);
        hiddenResult.Value = "";
    }

}