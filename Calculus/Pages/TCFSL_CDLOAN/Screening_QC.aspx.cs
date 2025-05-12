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

public partial class Pages_TCFSL_CDLOAN_Screening_QC : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {


            Sp_Assign_SCREENING();
            get_importdata();


            get_gridpendingFinone();
            ProductGridBind();

        }
    }
    // added by omkar start
    private bool IsMatchApplicationPattern(String inputString)
    {
        Regex ApplicationPattern = new Regex(@"^[A-Z]{4}[0-9]{8}$");

        return !ApplicationPattern.IsMatch(inputString);
    }
    // added by omkar end
    private void Sp_Assign_SCREENING()
    {
        Object SaveUSERInfo = (Object)Session["UserInfo"];
        SqlConnection sqlCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);
        try
        {

            SqlCommand sqlCom2 = new SqlCommand();
            sqlCom2.Connection = sqlCon;
            sqlCom2.CommandType = CommandType.StoredProcedure;
            sqlCom2.CommandText = "TCFSL_Assign_SCREENING_QC_18052019_SP";//Sp_Assign_SCREENING_QC_15052019 //Sp_Assign_SCREENING_QC

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

    private void Sp_Assign_SCREENING12()
    {
        Object SaveUSERInfo = (Object)Session["UserInfo"];
        SqlConnection sqlCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);
        try
        {

            SqlCommand sqlCom2 = new SqlCommand();
            sqlCom2.Connection = sqlCon;
            sqlCom2.CommandType = CommandType.StoredProcedure;
            sqlCom2.CommandText = "TCFSL_Assign_SCREENING_ReassignQC_SP";

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

    /// <summary>
    /// /FOR AUTOASSIGN CASE get
    /// </summary>
    /// 
    ///for pending for finone cases
    ///
    private void get_gridpendingFinone()
    {
        Object SaveUSERInfo = (Object)Session["UserInfo"];
        SqlConnection sqlCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);

        try
        {
            SqlCommand sqlCom2 = new SqlCommand();
            sqlCom2.Connection = sqlCon;
            sqlCom2.CommandType = CommandType.StoredProcedure;
            sqlCom2.CommandText = "TCFSLSCREEN_Showgridpending_QC";

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
                grdPending.Visible = true;
                grdPending.DataSource = dt;
                grdPending.DataBind();
                btnsumbit.Visible = true;
                lblassign.Visible = true;

            }
            else
            {
                grdPending.DataSource = null;
                grdPending.DataBind();
                btnsumbit.Visible = false;
                lblassign.Visible = false;
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
            sqlCom2.CommandText = "TCFSLCREEN_importdataQC_18052019";//TCFSLCREEN_importdataQC_15052019 //TCFSLCREEN_importdataQC

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
                grdlos.DataSource = dt;
                grdlos.DataBind();


                grddata.DataSource = dt;
                grddata.DataBind();
                DiscripancyGridBind();

                HdnProdct.Value = dt.Rows[0]["QCSCREEN_PRODUCT"].ToString().Trim();
                hdnStageType.Value = dt.Rows[0]["Stage_Status"].ToString().Trim();

                TextBox txtproductNo = (TextBox)grdlos.Rows[0].FindControl("txtproductNo");
                if ((hdnStageType.Value != "NEW") && (hdnStageType.Value != "") && (hdnStageType.Value != "ReInitiate"))
                {
                    txtproductNo.Text = HdnProdct.Value;
                    //txtproductNo.Enabled = false; //commented by omkar
                    //ddlCaseStatus.SelectedValue = Hdncasestatus.Value;
                    //ddlCaseStatus.Enabled = false;
                }
                else
                {
                    txtproductNo.Enabled = true;
                }

            }
            else
            {
                grdlos.DataSource = null;
                grdlos.DataBind();

                grddata.DataSource = null;
                grddata.DataBind();

                GridDiscripancy.Visible = false;
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

    private void get_importdata12()
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
            sqlCom2.CommandText = "TCFSLCREEN_importdataNew_reassignQC";//TCFSLCREEN_importdata1

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
                grdlos.DataSource = dt;
                grdlos.DataBind();


                grddata.DataSource = dt;
                grddata.DataBind();
                DiscripancyGridBind();

                HdnProdct.Value = dt.Rows[0]["QCSCREEN_PRODUCT"].ToString().Trim();
                hdnStageType.Value = dt.Rows[0]["Stage_Status"].ToString().Trim();

                TextBox txtproductNo = (TextBox)grdlos.Rows[0].FindControl("txtproductNo");
                if ((hdnStageType.Value != "NEW") && (hdnStageType.Value != "") && (hdnStageType.Value != "ReInitiate"))
                {
                    txtproductNo.Text = HdnProdct.Value;
                    //txtproductNo.Enabled = false; //commented by omkar
                    //ddlCaseStatus.SelectedValue = Hdncasestatus.Value;
                    //ddlCaseStatus.Enabled = false;
                }
                else
                {
                    txtproductNo.Enabled = true;
                }

            }
            else
            {
                grdlos.DataSource = null;
                grdlos.DataBind();

                grddata.DataSource = null;
                grddata.DataBind();

                GridDiscripancy.Visible = false;
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
                //CheckBox chkSelect = (CheckBox)grdlos.Rows[i].FindControl("chkSelect");

                TextBox txtproductNo = (TextBox)grdlos.Rows[i].FindControl("txtproductNo");
                LinkButton WIP = (LinkButton)grdlos.Rows[i].FindControl("lnkWIP");

                hdncaseno.Value = grdlos.Rows[i].Cells[3].Text.Trim();
                Hdnwebtop.Value = grdlos.Rows[i].Cells[4].Text.Trim();

                string Remark = null;

                //if (chkSelect.Checked == true)
                //{

                SqlCommand sqlCom = new SqlCommand();
                sqlCom.Connection = sqlCon;
                sqlCom.CommandType = CommandType.StoredProcedure;
                sqlCom.CommandText = "TCFSLScreen_assignQC";
                sqlCom.CommandTimeout = 0;


                SqlParameter UserID = new SqlParameter();
                UserID.SqlDbType = SqlDbType.VarChar;
                //UserID.Value = "P49506";
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


                //if (HdnProdct.Value != "")
                //{
                //    txtproductNo.Text = HdnProdct.Value;
                //    txtproductNo.Enabled = false;
                //}
                //else
                //{
                //    txtproductNo.Enabled = true;
                //}

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

                //}
                //else
                //{
                //    hiddenResult.Value = "Please Select Atleast One Record...!!!";
                //}

            }


            if (hdnStageType.Value == "Pending")
            {
                Sp_Assign_SCREENING12();
                get_importdata12();
            }
            else
            {
                Sp_Assign_SCREENING();
                get_importdata();
            }


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
                    //CheckBox chkSelect = (CheckBox)grdlos.Rows[i].FindControl("chkSelect");

                    DropDownList Status = (DropDownList)grdlos.Rows[i].FindControl("ddlstatus");

                    Button Discripancy = (Button)grdlos.Rows[i].FindControl("btnAddDiscripancy");

                    TextBox txtdiscripancy = (TextBox)grdlos.Rows[i].FindControl("txtdiscripancy");

                    Button btnAddproduct = (Button)grdlos.Rows[i].FindControl("btnAddproduct");

                    TextBox txtproduct = (TextBox)grdlos.Rows[i].FindControl("txtproduct");

                    LinkButton Complete = (LinkButton)grdlos.Rows[i].FindControl("lnkCompleteExit");

                    LinkButton lnkCompleteNext = (LinkButton)grdlos.Rows[i].FindControl("lnkCompleteNext");

                    LinkButton lnkCompleteMakr = (LinkButton)grdlos.Rows[i].FindControl("lnkCompleteMakr");

                    TextBox txtproductno = (TextBox)grdlos.Rows[i].FindControl("txtproductno");


                    HdnWIPStatus.Value = grdlos.Rows[i].Cells[2].Text.Trim();
                    if (HdnWIPStatus.Value == "InProcess")
                    {

                        if (Status.SelectedItem.Text != "--Select--")
                        {
                            if ((Status.SelectedItem.Text == "Approved"))
                            {
                                txtdiscripancy.Visible = false;
                                Discripancy.Visible = false;
                                Complete.Enabled = true;
                                txtproductno.Visible = true;
                                btnAddproduct.Visible = true;
                                txtproduct.Visible = true;
                                lnkCompleteNext.Visible = false;
                                Complete.Visible = false;
                                lnkCompleteMakr.Visible = false;

                            }
                            else if ((Status.SelectedItem.Value == "Pending"))
                            {
                                txtdiscripancy.Visible = false;
                                Discripancy.Visible = false;
                                Complete.Enabled = true;
                                txtproductno.Visible = false;
                                txtproductno.Text = "";
                                btnAddproduct.Visible = false;
                                txtproduct.Visible = false;
                                lnkCompleteNext.Visible = true;
                                Complete.Visible = true;
                                lnkCompleteMakr.Visible = false;
                            }
                            else
                            {
                                txtdiscripancy.Visible = true;
                                Discripancy.Visible = true;
                                Complete.Enabled = true;
                                txtproductno.Visible = false;
                                txtproductno.Text = "";
                                btnAddproduct.Visible = false;
                                txtproduct.Visible = false;
                                lnkCompleteNext.Visible = false;
                                Complete.Visible = false;
                                lnkCompleteMakr.Visible = false;
                            }

                        }

                        else
                        {
                            hiddenResult.Value = "Select Status....!!!!!";
                            Status.SelectedIndex = 0;
                        }
                    }

                    else
                    {
                        hiddenResult.Value = "Click on Start button.........!!";
                        Status.SelectedIndex = 0;
                        return;


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

                    LinkButton lnkCompleteMakr = (LinkButton)grdlos.Rows[i].FindControl("lnkCompleteMakr");

                    hdncaseno.Value = grdlos.Rows[i].Cells[3].Text.Trim();
                    Hdnwebtop.Value = grdlos.Rows[i].Cells[4].Text.Trim();
                    HdnWIPStatus.Value = grdlos.Rows[i].Cells[2].Text.Trim();

                    if (HdnWIPStatus.Value == "InProcess")
                    {


                        SqlCommand sqlCom = new SqlCommand();
                        sqlCom.Connection = sqlCon;
                        sqlCom.CommandType = CommandType.StoredProcedure;
                        sqlCom.CommandText = "TCFSL_Screen_AddDiscripancy";
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

                        if (txtdiscripancy.Text.ToUpper().Trim() != "")
                        {
                            SqlParameter Discripancy = new SqlParameter();
                            Discripancy.SqlDbType = SqlDbType.VarChar;
                            Discripancy.Value = txtdiscripancy.Text.ToUpper().Trim();
                            Discripancy.ParameterName = "@Discripancy";
                            sqlCom.Parameters.Add(Discripancy);
                        }
                        else
                        {
                            hiddenResult.Value = "Kindly Enter Discripancy.........!!";
                        }

                        SqlParameter Status1 = new SqlParameter();
                        Status1.SqlDbType = SqlDbType.VarChar;
                        Status1.Value = "Pending";
                        Status1.ParameterName = "@Status";
                        sqlCom.Parameters.Add(Status1);

                        SqlParameter stage = new SqlParameter();
                        stage.SqlDbType = SqlDbType.VarChar;
                        stage.Value = "QCSCREEN";
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
                            lnkCompleteMakr.Visible = false;

                        }
                    }
                    else
                    {
                        hiddenResult.Value = "Click on Start button.........!!";
                        return;
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
    protected void btnAddproduct_Click(object sender, EventArgs e)
    {
        Save_Product();
    }
    protected void get_CountProduct()
    {
        Object SaveUSERInfo = (Object)Session["UserInfo"];

        SqlConnection sqlCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);
        try
        {
            if (sqlCon.State == ConnectionState.Closed)
            {
                for (int i = 0; i <= grdlos.Rows.Count - 1; i++)
                {
                    //CheckBox chkSelect = (CheckBox)grdlos.Rows[i].FindControl("chkSelect");

                    LinkButton WIP = (LinkButton)grdlos.Rows[i].FindControl("lnkWIP");

                    //if (chkSelect.Checked == true)
                    //{
                    hdncaseno.Value = grdlos.Rows[i].Cells[3].Text.Trim();
                    Hdnwebtop.Value = grdlos.Rows[i].Cells[4].Text.Trim();

                    SqlCommand sqlcmd = new SqlCommand();
                    sqlcmd.Connection = sqlCon;
                    sqlcmd.CommandType = CommandType.StoredProcedure;
                    sqlcmd.CommandText = "TCFSL_SCREEN_ProductInfoQC";
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
                        HdnProdct.Value = dt.Rows[0]["NoProduct"].ToString().Trim();
                        //hdnProdCount.Value = dt.Rows[0]["NoProduct"].ToString().Trim();

                    }
                    else
                    {
                        //hiddenResult.Value = "Needs to add Product match with Product Count.....!!!!";
                    }

                    //}
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
    protected void Save_Product()
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
                    //CheckBox chkSelect = (CheckBox)grdlos.Rows[i].FindControl("chkSelect");

                    Button btnAddproduct = (Button)grdlos.Rows[i].FindControl("btnAddproduct");

                    TextBox txtproduct = (TextBox)grdlos.Rows[i].FindControl("txtproduct");

                    TextBox txtproductno = (TextBox)grdlos.Rows[i].FindControl("txtproductno");

                    LinkButton Complete = (LinkButton)grdlos.Rows[i].FindControl("lnkCompleteExit");

                    LinkButton lnkCompleteNext = (LinkButton)grdlos.Rows[i].FindControl("lnkCompleteNext");

                    LinkButton lnkCompleteMakr = (LinkButton)grdlos.Rows[i].FindControl("lnkCompleteMakr");

                    hdncaseno.Value = grdlos.Rows[i].Cells[3].Text.Trim();
                    Hdnwebtop.Value = grdlos.Rows[i].Cells[4].Text.Trim();

                    SqlCommand sqlCom1 = new SqlCommand();
                    sqlCom1.Connection = sqlCon;
                    sqlCom1.CommandType = CommandType.StoredProcedure;
                    sqlCom1.CommandText = "TCFSL_Screen_AddProductQC_SP";
                    sqlCom1.CommandTimeout = 0;

                    SqlParameter caseno1 = new SqlParameter();
                    caseno1.SqlDbType = SqlDbType.VarChar;
                    caseno1.Value = hdncaseno.Value;
                    caseno1.ParameterName = "@Case_Number";
                    sqlCom1.Parameters.Add(caseno1);

                    SqlParameter WebtopNo1 = new SqlParameter();
                    WebtopNo1.SqlDbType = SqlDbType.VarChar;
                    WebtopNo1.Value = Hdnwebtop.Value;
                    WebtopNo1.ParameterName = "@Webtop_Id";
                    sqlCom1.Parameters.Add(WebtopNo1);

                    if (txtproductno.Text != "")
                    {
                        SqlParameter productno = new SqlParameter();
                        productno.SqlDbType = SqlDbType.VarChar;
                        productno.Value = txtproductno.Text.Trim();
                        productno.ParameterName = "@product";
                        sqlCom1.Parameters.Add(productno);
                    }
                    else
                    {
                        hiddenResult.Value = "Enter Product No";
                        return;
                    }


                    int SqlRow1 = 0;
                    SqlRow1 = sqlCom1.ExecuteNonQuery();

                    if (SqlRow1 > 0)
                    {

                    }

                    SqlCommand sqlCom = new SqlCommand();
                    sqlCom.Connection = sqlCon;
                    sqlCom.CommandType = CommandType.StoredProcedure;
                    sqlCom.CommandText = "TCFSL_ScreenQC_AddMakerProduct";
                    sqlCom.CommandTimeout = 0;

                    SqlParameter caseno = new SqlParameter();
                    caseno.SqlDbType = SqlDbType.VarChar;
                    caseno.Value = hdncaseno.Value;
                    caseno.ParameterName = "@Case_Number";
                    sqlCom.Parameters.Add(caseno);

                    SqlParameter WebtopNo = new SqlParameter();
                    WebtopNo.SqlDbType = SqlDbType.VarChar;
                    WebtopNo.Value = Hdnwebtop.Value;
                    WebtopNo.ParameterName = "@Webtop_Id";
                    sqlCom.Parameters.Add(WebtopNo);

                    string Application = string.Empty;
                    Application = txtproduct.Text.Substring(0, 4);

                    if (txtproduct.Text != "")
                    {
                        if (Application == "APPL")
                        {
                            if (!IsMatchApplicationPattern(txtproduct.Text))
                            {
                                SqlParameter product = new SqlParameter();
                                product.SqlDbType = SqlDbType.VarChar;
                                product.Value = txtproduct.Text.Trim();
                                product.ParameterName = "@product";
                                sqlCom.Parameters.Add(product);
                            }
                            else
                            {
                                hiddenResult.Value = "Please Enter Valid Product Application Number.........!!<br>It must contain 12 characters without space inbetween......!!<br>Starting 4 characters are alphabets & rest all 8 characters are numeric......!!";
                                return;
                            }
                        }
                        else
                        {

                            hiddenResult.Value = "Application Number should start from APPL..!!";
                            return;
                        }
                    }
                    else
                    {
                        hiddenResult.Value = "Enter Product APPNo";
                        return;
                    }


                    int SqlRow = 0;
                    SqlRow = sqlCom.ExecuteNonQuery();

                    if (SqlRow > 0)
                    {
                        ProductGridBind();
                        txtproduct.Text = null;
                        Complete.Visible = true;
                        lnkCompleteNext.Visible = true;
                        lnkCompleteMakr.Visible = true;

                    }
                    else
                    {
                        hiddenResult.Value = "Product FinnOneApplication Number is already exists or check Count Of Product...!!!!";
                        ProductGridBind();
                        txtproduct.Text = null;
                        Complete.Visible = false;
                        lnkCompleteNext.Visible = false;
                        lnkCompleteMakr.Visible = false;
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
    public void ProductGridBind()
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
                    //CheckBox chkSelect = (CheckBox)grdlos.Rows[i].FindControl("chkSelect");

                    DropDownList Status = (DropDownList)grdlos.Rows[i].FindControl("ddlstatus");

                    Button AddDiscripancy = (Button)grdlos.Rows[i].FindControl("btnAddDiscripancy");

                    TextBox txtdiscripancy = (TextBox)grdlos.Rows[i].FindControl("txtdiscripancy");

                    hdncaseno.Value = grdlos.Rows[i].Cells[3].Text.Trim();
                    Hdnwebtop.Value = grdlos.Rows[i].Cells[4].Text.Trim();

                    SqlCommand sqlcmd = new SqlCommand();
                    sqlcmd.Connection = sqlCon;
                    sqlcmd.CommandType = CommandType.StoredProcedure;
                    sqlcmd.CommandText = "TCFSL_Screen_Selectproduct";
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

                    SqlDataAdapter sqlDA = new SqlDataAdapter();
                    sqlDA.SelectCommand = sqlcmd;

                    DataTable dt = new DataTable();
                    sqlDA.Fill(dt);

                    sqlCon.Close();
                    if (dt.Rows.Count > 0)
                    {
                        grdProduct.Visible = true;
                        grdProduct.DataSource = dt;
                        grdProduct.DataBind();
                    }
                    else
                    {
                        grdProduct.Visible = false;
                        grdProduct.DataSource = null;
                        grdProduct.DataBind();
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
            if (sqlCon.State == ConnectionState.Closed)
            {
                sqlCon.Open();
                for (int i = 0; i <= grdlos.Rows.Count - 1; i++)
                {
                    //CheckBox chkSelect = (CheckBox)grdlos.Rows[i].FindControl("chkSelect");

                    DropDownList Status = (DropDownList)grdlos.Rows[i].FindControl("ddlstatus");

                    Button AddDiscripancy = (Button)grdlos.Rows[i].FindControl("btnAddDiscripancy");

                    TextBox txtdiscripancy = (TextBox)grdlos.Rows[i].FindControl("txtdiscripancy");

                    hdncaseno.Value = grdlos.Rows[i].Cells[3].Text.Trim();
                    Hdnwebtop.Value = grdlos.Rows[i].Cells[4].Text.Trim();

                    SqlCommand sqlcmd = new SqlCommand();
                    sqlcmd.Connection = sqlCon;
                    sqlcmd.CommandType = CommandType.StoredProcedure;
                    sqlcmd.CommandText = "TCFSL_Screen_SelectDiscripancyQC";
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
                    }
                    else
                    {
                        GridDiscripancy.DataSource = null;
                        GridDiscripancy.DataBind();
                        GridDiscripancy.Visible = false;
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
                        Hdnwebtop.Value = GridDiscripancy.Rows[i].Cells[4].Text.Trim();
                        HdnWIPStatus.Value = GridDiscripancy.Rows[i].Cells[6].Text.Trim();

                        SqlCommand sqlcmd = new SqlCommand();
                        sqlcmd.Connection = sqlCon;
                        sqlcmd.CommandType = CommandType.StoredProcedure;
                        sqlcmd.CommandText = "TCFSL_SCREEN_UpdateDiscripancy";
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

                        SqlParameter WebtopNo = new SqlParameter();
                        WebtopNo.SqlDbType = SqlDbType.VarChar;
                        WebtopNo.Value = Hdnwebtop.Value;
                        WebtopNo.ParameterName = "@WebtopNo";
                        sqlcmd.Parameters.Add(WebtopNo);

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
    protected void lnkCompleteNext_Click(object sender, EventArgs e)
    {
        Object SaveUSERInfo = (Object)Session["UserInfo"];

        SqlConnection sqlCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);
        try
        {
            for (int i = 0; i <= grdlos.Rows.Count - 1; i++)
            {
                //CheckBox chkSelect = (CheckBox)grdlos.Rows[i].FindControl("chkSelect");
                DropDownList ddlstatus = (DropDownList)grdlos.Rows[i].FindControl("ddlstatus");
                //TextBox txtremark = (TextBox)grdlos.Rows[i].FindControl("txtremark");
                TextBox txtproduct = (TextBox)grdlos.Rows[i].FindControl("txtproduct");
                TextBox txtproductNo = (TextBox)grdlos.Rows[i].FindControl("txtproductNo");
                bool IsProductCountmatch = false;
                hdncaseno.Value = grdlos.Rows[i].Cells[3].Text.Trim();
                Hdnwebtop.Value = grdlos.Rows[i].Cells[4].Text.Trim();
                HdnWIPStatus.Value = grdlos.Rows[i].Cells[2].Text.Trim();
                HdnProdct.Value = grdlos.Rows[i].Cells[5].Text.Trim();

                //if (chkSelect.Checked == true)
                //{
                if (ddlstatus.SelectedIndex != 0)
                {
                    if (HdnWIPStatus.Value == "InProcess")
                    {
                        if (ddlstatus.SelectedItem.Text == "Approved")
                        {
                            if (grdProduct.Rows.Count.ToString() == getEnteredProductCount(hdncaseno.Value, Hdnwebtop.Value))
                            {
                                IsProductCountmatch = true;
                            }
                            else
                            {
                                IsProductCountmatch = false;
                            }
                        }
                        else 
                        {
                            IsProductCountmatch = true;
                        }
                        if (IsProductCountmatch)
                        {
                            SqlCommand sqlCom = new SqlCommand();
                            sqlCom.Connection = sqlCon;
                            sqlCom.CommandType = CommandType.StoredProcedure;
                            sqlCom.CommandText = "SCREENCOMPLETEQC_TCFSL";
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

                            if (ddlstatus.SelectedItem.Text == "Approved")
                            {
                                if (txtproductNo.Text != "")
                                {
                                    SqlParameter product = new SqlParameter();
                                    product.SqlDbType = SqlDbType.VarChar;
                                    product.Value = txtproductNo.Text.Trim();
                                    product.ParameterName = "@product";
                                    sqlCom.Parameters.Add(product);
                                }
                                else
                                {
                                    hiddenResult.Value = "Enter Product";
                                    return;
                                }
                            }
                            else
                            {
                                SqlParameter product = new SqlParameter();
                                product.SqlDbType = SqlDbType.VarChar;
                                product.Value = "";
                                product.ParameterName = "@product";
                                sqlCom.Parameters.Add(product);
                            }
                            //if ((ddlstatus.SelectedValue.ToString().Trim() != "Reject")&&(ddlstatus.SelectedValue.ToString().Trim() != "Hold"))
                            //{
                            //    if (txtremark.Text != "")
                            //    {
                            //        SqlParameter Remark = new SqlParameter();
                            //        Remark.SqlDbType = SqlDbType.VarChar;
                            //        Remark.Value = txtremark.Text.Trim();
                            //        Remark.ParameterName = "@LosRemark";
                            //        sqlCom.Parameters.Add(Remark);
                            //    }
                            //    else
                            //    {
                            //        hiddenResult.Value = "Enter Remark";
                            //        return;
                            //    }
                            //}
                            //else
                            //{
                            //    SqlParameter Remark = new SqlParameter();
                            //    Remark.SqlDbType = SqlDbType.VarChar;
                            //    Remark.Value = txtremark.Text.Trim();
                            //    Remark.ParameterName = "@LosRemark";
                            //    sqlCom.Parameters.Add(Remark);
                            //}
                            sqlCon.Open();
                            int SqlRow = 0;
                            SqlRow = sqlCom.ExecuteNonQuery();
                            sqlCon.Close();
                            if (SqlRow > 0)
                            {
                                hiddenResult.Value = "Data Successfully Updated........!!";
                                //Sp_Assign_SCREENING();
                                //get_importdata();
                                get_gridpendingFinone();
                                //ProductGridBind();
                            }
                            else
                            {
                                hiddenResult.Value = "Check Count Of Product and ADD........!!";
                                txtproductNo.Text.Trim();
                                txtproductNo.Enabled = false;
                                return;
                            }
                        }
                        else
                        {
                            hiddenResult.Value = "Check product count and enter respective FinnOneApplication numbers.........!!";
                            return;

                        }
                    }


                    else
                    {
                        hiddenResult.Value = "Click on Start button.........!!";
                        return;


                    }

                }
                else
                {
                    hiddenResult.Value = "Please Select Status........!!";
                    return;
                }

                //}
                //else
                //{
                //    hiddenResult.Value = "Click on Check Box.........!!";
                //    return;
                //}
            }

            Sp_Assign_SCREENING();
            get_importdata();
            ProductGridBind();
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
    public string getEnteredProductCount(string caseNumber, string webtopId)
    {
        string productCount = "0";

        Object SaveUSERInfo = (Object)Session["UserInfo"];

        SqlConnection sqlCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);
        try
        {
            if (sqlCon.State == ConnectionState.Closed)
            {
                for (int i = 0; i <= grdlos.Rows.Count - 1; i++)
                {
                    SqlCommand sqlcmd = new SqlCommand();
                    sqlcmd.Connection = sqlCon;
                    sqlcmd.CommandType = CommandType.StoredProcedure;
                    sqlcmd.CommandText = "TCFSL_USP_Get_Entered_Product_Count_SP";
                    sqlcmd.CommandTimeout = 0;

                    SqlParameter caseno = new SqlParameter();
                    caseno.SqlDbType = SqlDbType.VarChar;
                    caseno.Value = caseNumber;
                    caseno.ParameterName = "@caseno";
                    sqlcmd.Parameters.Add(caseno);

                    SqlParameter WebtopNo = new SqlParameter();
                    WebtopNo.SqlDbType = SqlDbType.VarChar;
                    WebtopNo.Value = webtopId;
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
                        productCount = dt.Rows[0]["EnteredProductCount"].ToString().Trim();
                        if (productCount == "")
                        {
                            productCount = "0";
                        }
                    }
                    else
                    {
                        productCount = "0";
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


        return productCount;
    }
    protected void lnkCompleteExit_Click(object sender, EventArgs e)
    {

        Object SaveUSERInfo = (Object)Session["UserInfo"];

        SqlConnection sqlCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);
        try
        {
            for (int i = 0; i <= grdlos.Rows.Count - 1; i++)
            {
                //CheckBox chkSelect = (CheckBox)grdlos.Rows[i].FindControl("chkSelect");
                DropDownList ddlstatus = (DropDownList)grdlos.Rows[i].FindControl("ddlstatus");
                //TextBox txtremark = (TextBox)grdlos.Rows[i].FindControl("txtremark");
                TextBox txtproduct = (TextBox)grdlos.Rows[i].FindControl("txtproduct");
                TextBox txtproductNo = (TextBox)grdlos.Rows[i].FindControl("txtproductNo");

                bool IsProductCountmatch = false;

                hdncaseno.Value = grdlos.Rows[i].Cells[3].Text.Trim();
                Hdnwebtop.Value = grdlos.Rows[i].Cells[4].Text.Trim();
                HdnWIPStatus.Value = grdlos.Rows[i].Cells[2].Text.Trim();

                //if (chkSelect.Checked == true)
                //{
                if (ddlstatus.SelectedIndex != 0)
                {
                    if (HdnWIPStatus.Value == "InProcess")
                    {
                        if (ddlstatus.SelectedItem.Text == "Approved")
                        {
                            if (grdProduct.Rows.Count.ToString() == getEnteredProductCount(hdncaseno.Value, Hdnwebtop.Value))
                            {
                                IsProductCountmatch = true;
                            }
                            else
                            {
                                IsProductCountmatch = false;
                            }
                        }
                        else
                        {
                            IsProductCountmatch = true;
                        }
                        if (IsProductCountmatch)
                        {
                            SqlCommand sqlCom = new SqlCommand();
                            sqlCom.Connection = sqlCon;
                            sqlCom.CommandType = CommandType.StoredProcedure;
                            sqlCom.CommandText = "SCREENCOMPLETEQC_TCFSL";
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
                            if (ddlstatus.SelectedItem.Text == "Approved")
                            {
                                if (txtproductNo.Text != "")
                                {
                                    SqlParameter product = new SqlParameter();
                                    product.SqlDbType = SqlDbType.VarChar;
                                    product.Value = txtproductNo.Text.Trim();
                                    product.ParameterName = "@product";
                                    sqlCom.Parameters.Add(product);
                                }
                                else
                                {
                                    hiddenResult.Value = "Enter Product";
                                    return;
                                }
                            }
                            else {
                                SqlParameter product = new SqlParameter();
                                product.SqlDbType = SqlDbType.VarChar;
                                product.Value = "";
                                product.ParameterName = "@product";
                                sqlCom.Parameters.Add(product);
                            }
                            

                            //SqlParameter Remark = new SqlParameter();
                            //Remark.SqlDbType = SqlDbType.VarChar;
                            //Remark.Value = txtremark.Text.Trim();
                            //Remark.ParameterName = "@LosRemark";
                            //sqlCom.Parameters.Add(Remark);

                            sqlCon.Open();
                            int SqlRow = 0;
                            SqlRow = sqlCom.ExecuteNonQuery();
                            sqlCon.Close();
                            if (SqlRow > 0)
                            {
                                Response.Redirect("~/Pages/Menu.aspx", true);
                                hiddenResult.Value = "";
                            }



                            else
                            {

                                hiddenResult.Value = "Check Count Of Product and ADD........!!";
                                txtproductNo.Text.Trim();
                                txtproductNo.Enabled = false;
                                return;
                            }
                        }
                        else
                        {
                            hiddenResult.Value = "Check product count and enter respective FinnOneApplication numbers.........!!";
                            return;

                        }
                    }
                    else
                    {
                        hiddenResult.Value = "Click on Start button.........!!";
                        return;

                    }


                }
                else
                {
                    hiddenResult.Value = "Please Select Status........!!";
                    //txtremark.Focus();
                }

                //}
                //else
                //{

                //}
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
    protected void lnkCompleteMakr_Click(object sender, EventArgs e)
    {
        Object SaveUSERInfo = (Object)Session["UserInfo"];

        SqlConnection sqlCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);
        try
        {
            for (int i = 0; i <= grdlos.Rows.Count - 1; i++)
            {
                //CheckBox chkSelect = (CheckBox)grdlos.Rows[i].FindControl("chkSelect");
                DropDownList ddlstatus = (DropDownList)grdlos.Rows[i].FindControl("ddlstatus");
                //TextBox txtremark = (TextBox)grdlos.Rows[i].FindControl("txtremark");
                TextBox txtproduct = (TextBox)grdlos.Rows[i].FindControl("txtproduct");
                TextBox txtproductNo = (TextBox)grdlos.Rows[i].FindControl("txtproductNo");

                bool IsProductCountmatch = false;
                hdncaseno.Value = grdlos.Rows[i].Cells[3].Text.Trim();
                Hdnwebtop.Value = grdlos.Rows[i].Cells[4].Text.Trim();
                HdnWIPStatus.Value = grdlos.Rows[i].Cells[2].Text.Trim();
                HdnProdct.Value = grdlos.Rows[i].Cells[5].Text.Trim();

                //if (chkSelect.Checked == true)
                //{
                if (ddlstatus.SelectedIndex != 0)
                {
                    if (HdnWIPStatus.Value == "InProcess")
                    {
                        if (ddlstatus.SelectedItem.Text == "Approved")
                        {
                            if (grdProduct.Rows.Count.ToString() == getEnteredProductCount(hdncaseno.Value, Hdnwebtop.Value))
                            {
                                IsProductCountmatch = true;
                            }
                            else
                            {
                                IsProductCountmatch = false;
                            }
                        }
                        else
                        {
                            IsProductCountmatch = true;
                        }
                        if (IsProductCountmatch)
                        {
                            SqlCommand sqlCom = new SqlCommand();
                            sqlCom.Connection = sqlCon;
                            sqlCom.CommandType = CommandType.StoredProcedure;
                            sqlCom.CommandText = "SCREENCOMPLETEQC_TCFSL";
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

                            if (ddlstatus.SelectedItem.Text == "Approved")
                            {
                                if (txtproductNo.Text != "")
                                {
                                    SqlParameter product = new SqlParameter();
                                    product.SqlDbType = SqlDbType.VarChar;
                                    product.Value = txtproductNo.Text.Trim();
                                    product.ParameterName = "@product";
                                    sqlCom.Parameters.Add(product);
                                }
                                else
                                {
                                    hiddenResult.Value = "Enter Product";
                                    return;
                                }
                            }
                            else
                            {
                                SqlParameter product = new SqlParameter();
                                product.SqlDbType = SqlDbType.VarChar;
                                product.Value = "";
                                product.ParameterName = "@product";
                                sqlCom.Parameters.Add(product);
                            }
                            sqlCon.Open();
                            int SqlRow = 0;
                            SqlRow = sqlCom.ExecuteNonQuery();
                            sqlCon.Close();
                            if (SqlRow > 0)
                            {
                                Response.Redirect("Maker.aspx?caseno=" + hdncaseno.Value);
                            }
                        }
                        else
                        {
                            hiddenResult.Value = "Check product count and enter respective FinnOneApplication numbers.........!!";
                            return;

                        }
                    }


                    else
                    {
                        hiddenResult.Value = "Click on Start button.........!!";
                        return;


                    }

                }
                else
                {
                    hiddenResult.Value = "Please Select Status........!!";
                    return;
                }

                //}
                //else
                //{
                //    hiddenResult.Value = "Click on Check Box.........!!";
                //    return;
                //}
            }

            Sp_Assign_SCREENING();
            get_importdata();
            ProductGridBind();
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
    protected void btnsumbit_Click(object sender, EventArgs e)
    {
        Object SaveUSERInfo = (Object)Session["UserInfo"];
        SqlConnection sqlCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);

        try
        {
            for (int i = 0; i <= grdPending.Rows.Count - 1; i++)
            {


                CheckBox chkSelect = (CheckBox)grdPending.Rows[i].FindControl("chkSelect");
                LinkButton WIP = (LinkButton)grdPending.Rows[i].FindControl("lnkWIP");
                HdnWeb.Value = grdPending.Rows[i].Cells[2].Text.Trim();
                HdnCase.Value = grdPending.Rows[i].Cells[1].Text.Trim();
                if (chkSelect.Checked == true)
                {
                    SqlCommand sqlCom = new SqlCommand();
                    sqlCom.Connection = sqlCon;
                    sqlCom.CommandType = CommandType.StoredProcedure;
                    sqlCom.CommandText = "TCFSL_Assign_Screen_PendingQC_SP";
                    sqlCom.CommandTimeout = 0;

                    SqlParameter UserID = new SqlParameter();
                    UserID.SqlDbType = SqlDbType.VarChar;
                    UserID.Value = Convert.ToString(((UserInfo.structUSERInfo)(SaveUSERInfo)).UserId);
                    UserID.ParameterName = "@UserID";
                    sqlCom.Parameters.Add(UserID);

                    SqlParameter CaseNo = new SqlParameter();
                    CaseNo.SqlDbType = SqlDbType.VarChar;
                    CaseNo.Value = HdnCase.Value;
                    CaseNo.ParameterName = "@CaseNo";
                    sqlCom.Parameters.Add(CaseNo);

                    SqlParameter WebNo = new SqlParameter();
                    WebNo.SqlDbType = SqlDbType.VarChar;
                    WebNo.Value = HdnWeb.Value;
                    WebNo.ParameterName = "@WebNo";
                    sqlCom.Parameters.Add(WebNo);

                    SqlParameter flag = new SqlParameter();
                    flag.SqlDbType = SqlDbType.VarChar;
                    flag.Value = "QCSCREEN";
                    flag.ParameterName = "@flag";
                    sqlCom.Parameters.Add(flag);

                    sqlCon.Open();
                    int K = 0;
                    K = sqlCom.ExecuteNonQuery();

                    sqlCon.Close();
                    if (K > 0)
                    {
                        hiddenResult.Value = "Request has been Assign";

                        //get_importdataPending();
                        get_gridpendingFinone();
                    }
                }
                else
                {
                    hiddenResult.Value = "Click on Check button.........!!";
                }
            }
        }
        catch (Exception ex)
        {
            hiddenResult.Value = ex.Message;

        }

        Sp_Assign_SCREENING12();
        get_importdata12();
    }
    protected void grdlos_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        SqlConnection sqlCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);

        if (e.Row.RowType == DataControlRowType.DataRow)
        {

            DropDownList ddlstatus = (e.Row.FindControl("ddlstatus") as DropDownList);

            SqlCommand cmd = new SqlCommand("TCFSL_MasterSearchCode_SP", sqlCon);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Types", "SQCStatusType");
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