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
using System.Text.RegularExpressions;

public partial class Pages_TCFSL_CDLOAN_Author : System.Web.UI.Page
{
    bool strselect = false;
    bool strstatus = false;
    bool strWIPstatus = false;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Sp_Assign_Author();
            get_griddate();
            IfStuckOpen();
            get_importdata();
        }

    }
    private void Sp_Assign_Author()
    {
        Object SaveUSERInfo = (Object)Session["UserInfo"];
        SqlConnection sqlCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);
        try
        {

            SqlCommand sqlCom2 = new SqlCommand();
            sqlCom2.Connection = sqlCon;
            sqlCom2.CommandType = CommandType.StoredProcedure;
            sqlCom2.CommandText = "TCFSL_Assign_Author_New_SP";

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
            sqlCom2.CommandText = "TCFSLAuthor_ShowgridNew";

            //SqlDataAdapter sqlDA2 = new SqlDataAdapter();
            //sqlDA2.SelectCommand = sqlCom2;

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
            sqlCom2.CommandText = "TCFSLAUTHOR_importdataNew";//TCFSLAUTHOR_importdata

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
                //get_importdata();
                DiscripancyGridBind();
                get_griddate();
                lnkCompleteNext.Visible = false;
                lnkCompleteExit.Visible = false;

            }
            else
            {
                grdlos.DataSource = null;
                grdlos.DataBind();
                lnkCompleteNext.Visible = true;
                lnkCompleteExit.Visible = true;
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
    public void DiscripancyGridBind()
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

                    hdncaseno.Value = grdlos.Rows[i].Cells[4].Text.Trim();
                    Hdnwebtop.Value = grdlos.Rows[i].Cells[6].Text.Trim();
                    hdnfnno.Value = grdlos.Rows[i].Cells[5].Text.Trim();

                    SqlCommand sqlcmd = new SqlCommand();
                    sqlcmd.Connection = sqlCon;
                    sqlcmd.CommandType = CommandType.StoredProcedure;
                    sqlcmd.CommandText = "TCFSL_AUTHOR_SelectDiscripancyNEW";
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


                    SqlDataAdapter da = new SqlDataAdapter(sqlcmd);
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    GridDiscripancy.Visible = true;
                    GridDiscripancy.DataSource = ds;
                    GridDiscripancy.DataBind();

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
                    sqlCom.CommandText = "TCFSLAUTHOR_assign";
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
            Sp_Assign_Author();
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

                    TextBox txtLanAgreementNo = (TextBox)grdlos.Rows[i].FindControl("txtLanAgreementNo");
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
                                txtLanAgreementNo.Visible = true;

                            }
                            else
                            {
                                txtdiscripancy.Visible = true;
                                Discripancy.Visible = true;
                                Complete.Enabled = true;
                                //txtremark.Visible = false;
                                lnkCompleteNext.Visible = false;
                                //Complete.Visible = false;
                                txtLanAgreementNo.Visible = false;
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
                        sqlCom.CommandText = "TCFSL_AUTHOR_AddDiscripancy";
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
                        stage.Value = "AUTHOR";
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
                        sqlcmd.CommandText = "TCFSL_AUTHOR_UpdateDiscripancy";
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

    private bool IsMatchLanAgreementPattern(String inputString)
    {
        Regex LanAgreementPattern = new Regex(@"^[a-zA-Z]{5}[0-9]{16}$");

        return !LanAgreementPattern.IsMatch(inputString);
    }

    private bool IsLanAgreementNumberAlreadyExist(string LanAgreementNUmber)
    {
        bool IsExist = false;
        SqlConnection sqlCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);
        DataTable dtLanAgreementNumber = new DataTable();
        try
        {
            SqlCommand sqlCom = new SqlCommand();
            sqlCom.Connection = sqlCon;
            sqlCom.CommandType = CommandType.StoredProcedure;
            sqlCom.CommandText = "TCFSL_USP_CheckLanAgreementNumberExist_SP";//AUTHORCOMPLETE_TCFSL
            sqlCom.CommandTimeout = 0;

            
            SqlParameter LanNo = new SqlParameter();
            LanNo.SqlDbType = SqlDbType.VarChar;
            LanNo.Value = LanAgreementNUmber;
            LanNo.ParameterName = "@LanAgreementNumber";
            sqlCom.Parameters.Add(LanNo);

            SqlDataAdapter sqlDA = new SqlDataAdapter();
            sqlDA.SelectCommand = sqlCom;

            sqlDA.Fill(dtLanAgreementNumber);

            if (dtLanAgreementNumber.Rows.Count > 0)
            {
                IsExist = true;
            }
            else
            {
                IsExist = false;
            }


        }
        catch (Exception ex)
        {

        }
        return IsExist;
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
                TextBox txtLanAgreementNo = (TextBox)grdlos.Rows[i].FindControl("txtLanAgreementNo");

                hdncaseno.Value = grdlos.Rows[i].Cells[4].Text.Trim();
                Hdnwebtop.Value = grdlos.Rows[i].Cells[6].Text.Trim();
                hdnfnno.Value = grdlos.Rows[i].Cells[5].Text.Trim();
                HdnWIPStatus.Value = grdlos.Rows[i].Cells[3].Text.Trim();
                bool test = IsMatchLanAgreementPattern(txtLanAgreementNo.Text);
                if (chkSelect.Checked == true)
                {
                    strselect = true;
                    if (ddlstatus.SelectedIndex != 0)
                    {
                        strstatus = true;
                        if (HdnWIPStatus.Value == "InProcess")
                        {

                            if (ddlstatus.SelectedValue == "Approved" && txtLanAgreementNo.Text == "")
                            {
                                hiddenResult.Value = "Please fill LAN Agreement No.........!!";
                                return;
                            }
                            else if (ddlstatus.SelectedValue == "Approved" && IsMatchLanAgreementPattern(txtLanAgreementNo.Text))
                            {
                                hiddenResult.Value = "Please Enter Valid Lan Agreement Number.........!!<br>It must contain 21 characters without space inbetween......!!<br>Starting 5 characters are alphabets & rest all 16 characters are numeric......!!";
                                return;
                            }
                            else if (ddlstatus.SelectedValue == "Approved" && IsLanAgreementNumberAlreadyExist(txtLanAgreementNo.Text))
                            {
                                hiddenResult.Value = "Lan Agreement Number Already Exist.........!!!";
                                return;
                            }
                            else
                            {
                                strWIPstatus = true;

                                SqlCommand sqlCom = new SqlCommand();
                                sqlCom.Connection = sqlCon;
                                sqlCom.CommandType = CommandType.StoredProcedure;
                                sqlCom.CommandText = "TCFSL_AUTHOR_COMPLETE_New_SP";//AUTHORCOMPLETE_TCFSL
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


                                SqlParameter LanNo = new SqlParameter();
                                LanNo.SqlDbType = SqlDbType.VarChar;
                                LanNo.Value = txtLanAgreementNo.Text;
                                LanNo.ParameterName = "@LanNo";
                                sqlCom.Parameters.Add(LanNo);

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
                                    get_importdata();
                                }
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
    //complete method
    protected void lnkCompleteNext_Click(object sender, EventArgs e)
    {
        Sp_Assign_Author();
        get_griddate();
        IfStuckOpen();
        get_importdata();
    }
    protected void lnkCompleteExit_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Pages/Menu.aspx", true);
    }
    private void IfStuckOpen()
    {
        Object SaveUSERInfo = (Object)Session["UserInfo"];

        SqlConnection sqlCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);
        try
        {
            SqlCommand sqlCom = new SqlCommand();
            sqlCom.Connection = sqlCon;
            sqlCom.CommandType = CommandType.StoredProcedure;
            sqlCom.CommandText = "uspOpenAuthorStuckCase";

            SqlDataAdapter sqlDA = new SqlDataAdapter();
            sqlDA.SelectCommand = sqlCom;

            SqlParameter CaseNumber = new SqlParameter();
            CaseNumber.SqlDbType = SqlDbType.VarChar;
            CaseNumber.Value = hdncaseno.Value;
            CaseNumber.ParameterName = "@CaseNumber";
            sqlCom.Parameters.Add(CaseNumber);

            sqlCon.Open();
            int SqlRow = 0;
            SqlRow = sqlCom.ExecuteNonQuery();
            sqlCon.Close();
            if (SqlRow > 0)
            {
            }
            else
            {
            }
        }

        catch (Exception ex)
        {
        }
        finally
        {
            sqlCon.Close();
            sqlCon.Dispose();
        }
    }
}