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
public partial class Pages_ICICIRPC_BDE : System.Web.UI.Page
{
    //SingleUserLogin Login = new SingleUserLogin();
    protected void Page_Load(object sender, EventArgs e)
    {

        //Login.ValidateTokenLoginDetails();

        if (Session["UserInfo"] != null)
        {
            //Response.Redirect("~/Pages/Logout.aspx");
        }

        if (!IsPostBack)
        {
            Sp_Assign_LOSToBDE();
            Sp_Assign_LOSToIndexcer();
            get_importdata();
        }

    }


    protected void lnkCompleteCPV_Click(object sender, EventArgs e)
    {
        Object SaveUSERInfo = (Object)Session["UserInfo"];
        SqlConnection sqlCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);
        try
        {
            for (int i = 0; i <= grdlos.Rows.Count - 1; i++)
            {
                CheckBox chkSelect = (CheckBox)grdlos.Rows[i].FindControl("chkSelect");
                DropDownList ddlstatus = (DropDownList)grdlos.Rows[i].FindControl("ddlstatus");
                TextBox txtapsid = (TextBox)grdlos.Rows[i].FindControl("txtapsid");
                TextBox txtremark = (TextBox)grdlos.Rows[i].FindControl("txtremark");
                DropDownList ddlProductStatus = (DropDownList)grdlos.Rows[i].FindControl("ddlProductStatus");

                //Yasir
                //TextBox txtloanamount = (TextBox)grdlos.Rows[i].FindControl("txtloanamount");
                //TextBox txtloantenure = (TextBox)grdlos.Rows[i].FindControl("txtloantenure");

                HdnUID.Value = grdlos.Rows[i].Cells[4].Text.Trim();


                if (chkSelect.Checked == true)
                {
                    if (ddlProductStatus.SelectedIndex != 0)
                    {
                        if (ddlstatus.SelectedIndex != 0)
                        {
                            if ((ddlstatus.SelectedValue == "Completed" && txtapsid.Text != "") || (ddlstatus.SelectedIndex != 0 && txtapsid.Text != "") || (ddlstatus.SelectedValue != "Completed" && txtapsid.Text == ""))
                            {

                                if (txtremark.Text != "")
                                {

                                    SqlCommand sqlCom = new SqlCommand();
                                    sqlCom.Connection = sqlCon;
                                    sqlCom.CommandType = CommandType.StoredProcedure;
                                    sqlCom.CommandText = "IRPC_BDEICICI_SP"; //sp_BDEICICI
                                    sqlCom.CommandTimeout = 0;

                                    SqlDataAdapter sqlDA = new SqlDataAdapter();
                                    sqlDA.SelectCommand = sqlCom;

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

                                    SqlParameter Status = new SqlParameter();
                                    Status.SqlDbType = SqlDbType.VarChar;
                                    Status.Value = ddlstatus.SelectedValue.ToString();
                                    Status.ParameterName = "@LosStatus";
                                    sqlCom.Parameters.Add(Status);

                                    SqlParameter apsid = new SqlParameter();
                                    apsid.SqlDbType = SqlDbType.VarChar;
                                    apsid.Value = txtapsid.Text.Trim();
                                    apsid.ParameterName = "@aps_id";
                                    sqlCom.Parameters.Add(apsid);

                                    SqlParameter Remark = new SqlParameter();
                                    Remark.SqlDbType = SqlDbType.VarChar;
                                    Remark.Value = txtremark.Text.Trim();
                                    Remark.ParameterName = "@LosRemark";
                                    sqlCom.Parameters.Add(Remark);

                                    SqlParameter ProductStatus = new SqlParameter();
                                    ProductStatus.SqlDbType = SqlDbType.VarChar;
                                    ProductStatus.Value = ddlProductStatus.SelectedValue.ToString();
                                    ProductStatus.ParameterName = "@ProductStatus";
                                    sqlCom.Parameters.Add(ProductStatus);

                                    //Yasir
                                    //SqlParameter loanamount = new SqlParameter();
                                    //loanamount.SqlDbType = SqlDbType.VarChar;
                                    //loanamount.Value = txtloanamount.Text.Trim();
                                    //loanamount.ParameterName = "@BDE_Loanamount";
                                    //sqlCom.Parameters.Add(loanamount);

                                    //SqlParameter loantenure = new SqlParameter();
                                    //loantenure.SqlDbType = SqlDbType.VarChar;
                                    //loantenure.Value = txtloantenure.Text.Trim();
                                    //loantenure.ParameterName = "@BDE_Loantenure";
                                    //sqlCom.Parameters.Add(loantenure);

                                    sqlCon.Open();

                                    int SqlRow = 0;
                                    SqlRow = sqlCom.ExecuteNonQuery();

                                    sqlCon.Close();

                                    if (SqlRow > 0)
                                    {
                                        Response.Redirect("CPV.aspx?losno=" + HdnUID.Value);
                                    }
                                }

                                else
                                {
                                    lblMessage.Text = "Please Enter Remark!!";
                                    txtremark.Focus();
                                }
                            }

                            else
                            {
                                lblMessage.Text = "Please APS ID!!";
                                txtapsid.Focus();
                            }
                        }
                        else
                        {
                            lblMessage.Text = "Please Select Status........!!";
                            txtremark.Focus();
                        }
                    }
                    else
                    {
                        lblMessage.Text = "Please Select Product Status........!!";
                        txtremark.Focus();
                    }
                }
                else
                {

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
    private void Sp_Assign_LOSToBDE()
    {
        Object SaveUSERInfo = (Object)Session["UserInfo"];
        SqlConnection sqlCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);
        try
        {

            SqlCommand sqlCom2 = new SqlCommand();
            sqlCom2.Connection = sqlCon;
            sqlCom2.CommandType = CommandType.StoredProcedure;
            sqlCom2.CommandText = "IRPC_Assign_ICICI_TO_Indexcer_Product_SP";

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

                HdnUID.Value = grdlos.Rows[i].Cells[4].Text.Trim();

                string Remark = null;
                if (chkSelect.Checked == true)
                {



                    SqlCommand sqlCom = new SqlCommand();
                    sqlCom.Connection = sqlCon;
                    sqlCom.CommandType = CommandType.StoredProcedure;
                    sqlCom.CommandText = "IRPC_AssignICICI_Indexer_SP";
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

                        //Sp_Assign_LOSToBDE();

                    }

                }
                else
                {
                    //lblMsg.Text = "Please Select Atleast One Record...!!!";
                }

            }
            Sp_Assign_LOSToIndexcer();

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
                TextBox txtapsid = (TextBox)grdlos.Rows[i].FindControl("txtapsid");
                TextBox txtremark = (TextBox)grdlos.Rows[i].FindControl("txtremark");
                DropDownList ddlProductStatus = (DropDownList)grdlos.Rows[i].FindControl("ddlProductStatus");

                //Yasir
                //TextBox txtloanamount = (TextBox)grdlos.Rows[i].FindControl("txtloanamount");
                //TextBox txtloantenure = (TextBox)grdlos.Rows[i].FindControl("txtloantenure");

                HdnUID.Value = grdlos.Rows[i].Cells[4].Text.Trim();


                if (chkSelect.Checked == true)
                {
                    if (ddlProductStatus.SelectedIndex != 0)
                    {
                        if (ddlstatus.SelectedIndex != 0)
                        {
                            if ((ddlstatus.SelectedValue == "Completed" && txtapsid.Text != "") || (ddlstatus.SelectedIndex != 0 && txtapsid.Text != "") || (ddlstatus.SelectedValue != "Completed" && txtapsid.Text == ""))
                            {
                                if (txtremark.Text != "")
                                {


                                    SqlCommand sqlCom = new SqlCommand();
                                    sqlCom.Connection = sqlCon;
                                    sqlCom.CommandType = CommandType.StoredProcedure;
                                    sqlCom.CommandText = "IRPC_BDEICICI_SP"; //sp_BDEICICI
                                    sqlCom.CommandTimeout = 0;

                                    SqlDataAdapter sqlDA = new SqlDataAdapter();
                                    sqlDA.SelectCommand = sqlCom;

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

                                    SqlParameter Status = new SqlParameter();
                                    Status.SqlDbType = SqlDbType.VarChar;
                                    Status.Value = ddlstatus.SelectedValue.ToString();
                                    Status.ParameterName = "@LosStatus";
                                    sqlCom.Parameters.Add(Status);

                                    SqlParameter apsid = new SqlParameter();
                                    apsid.SqlDbType = SqlDbType.VarChar;
                                    apsid.Value = txtapsid.Text.Trim();
                                    apsid.ParameterName = "@aps_id";
                                    sqlCom.Parameters.Add(apsid);


                                    SqlParameter Remark = new SqlParameter();
                                    Remark.SqlDbType = SqlDbType.VarChar;
                                    Remark.Value = txtremark.Text.Trim();
                                    Remark.ParameterName = "@LosRemark";
                                    sqlCom.Parameters.Add(Remark);


                                    SqlParameter ProductStatus = new SqlParameter();
                                    ProductStatus.SqlDbType = SqlDbType.VarChar;
                                    ProductStatus.Value = ddlProductStatus.SelectedValue.ToString();
                                    ProductStatus.ParameterName = "@ProductStatus";
                                    sqlCom.Parameters.Add(ProductStatus);

                                    //Yasir
                                    //SqlParameter loanamount = new SqlParameter();
                                    //loanamount.SqlDbType = SqlDbType.VarChar;
                                    //loanamount.Value = txtloanamount.Text.Trim();
                                    //loanamount.ParameterName = "@BDE_Loanamount";
                                    //sqlCom.Parameters.Add(loanamount);

                                    //SqlParameter loantenure = new SqlParameter();
                                    //loantenure.SqlDbType = SqlDbType.VarChar;
                                    //loantenure.Value = txtloantenure.Text.Trim();
                                    //loantenure.ParameterName = "@BDE_Loantenure";
                                    //sqlCom.Parameters.Add(loantenure);

                                    sqlCon.Open();
                                    int SqlRow = 0;
                                    SqlRow = sqlCom.ExecuteNonQuery();
                                    sqlCon.Close();
                                    if (SqlRow > 0)
                                    {
                                        Sp_Assign_LOSToBDE();
                                        lblMessage.Text = "";
                                    }
                                }

                                else
                                {
                                    lblMessage.Text = "Please Enter Remark!!";
                                    txtremark.Focus();
                                }
                            }

                            else
                            {
                                lblMessage.Text = "Please APS ID!!";
                                txtapsid.Focus();
                            }

                        }
                        else
                        {
                            lblMessage.Text = "Please Select Status........!!";
                            txtremark.Focus();
                        }
                    }
                    else
                    {
                        lblMessage.Text = "Please Select Product Status........!!";
                        txtremark.Focus();
                    }
                }
                else
                {

                }
            }

            Sp_Assign_LOSToIndexcer();
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
                    // lblMsg.Text = "Please Select Atleast One Record...!!!";
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
    private void Sp_Assign_LOSToIndexcer()
    {
        Object SaveUSERInfo = (Object)Session["UserInfo"];
        SqlConnection sqlCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);

        try
        {
            SqlCommand sqlCom2 = new SqlCommand();
            sqlCom2.Connection = sqlCon;
            sqlCom2.CommandType = CommandType.StoredProcedure;
            sqlCom2.CommandText = "IRPC_ICICI_SP";

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
            sqlCom2.CommandText = "IRPC_ICICI_1234_SP";

            SqlDataAdapter sqlDA2 = new SqlDataAdapter();
            sqlDA2.SelectCommand = sqlCom2;

            SqlParameter PMSlocation = new SqlParameter();
            PMSlocation.SqlDbType = SqlDbType.VarChar;
            PMSlocation.Value = Convert.ToInt32(((UserInfo.structUSERInfo)(SaveUSERInfo)).BranchId);
            PMSlocation.ParameterName = "@location";
            sqlCom2.Parameters.Add(PMSlocation);

            //SqlParameter losno = new SqlParameter();
            //losno.SqlDbType = SqlDbType.VarChar;
            //losno.Value = HdnUID.Value;
            //losno.ParameterName = "@losno";
            //sqlCom2.Parameters.Add(losno);


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



    private void Sp_Assign_LOSToIndexcer12()
    {
        Object SaveUSERInfo = (Object)Session["UserInfo"];
        SqlConnection sqlCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);

        try
        {
            SqlCommand sqlCom2 = new SqlCommand();
            sqlCom2.Connection = sqlCon;
            sqlCom2.CommandType = CommandType.StoredProcedure;
            sqlCom2.CommandText = "IRPC_ICICI_123_SP";

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





    protected void lnkCompleteExit_Click(object sender, EventArgs e)
    {

        Object SaveUSERInfo = (Object)Session["UserInfo"];
        SqlConnection sqlCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);

        try
        {
            for (int i = 0; i <= grdlos.Rows.Count - 1; i++)
            {
                CheckBox chkSelect = (CheckBox)grdlos.Rows[i].FindControl("chkSelect");

                DropDownList ddlstatus = (DropDownList)grdlos.Rows[i].FindControl("ddlstatus");
                TextBox txtapsid = (TextBox)grdlos.Rows[i].FindControl("txtapsid");
                TextBox txtremark = (TextBox)grdlos.Rows[i].FindControl("txtremark");
                DropDownList ddlProductStatus = (DropDownList)grdlos.Rows[i].FindControl("ddlProductStatus");

                //Yasir
                //TextBox txtloanamount = (TextBox)grdlos.Rows[i].FindControl("txtloanamount");
                //TextBox txtloantenure = (TextBox)grdlos.Rows[i].FindControl("txtloantenure");

                HdnUID.Value = grdlos.Rows[i].Cells[4].Text.Trim();

                if (chkSelect.Checked == true)
                {
                    if (ddlProductStatus.SelectedIndex != 0)
                    {
                        if (ddlstatus.SelectedIndex != 0)
                        {
                            if ((ddlstatus.SelectedValue == "Completed" && txtapsid.Text != "") || (ddlstatus.SelectedIndex != 0 && txtapsid.Text != "") || (ddlstatus.SelectedValue != "Completed" && txtapsid.Text == ""))
                            {
                                if (txtremark.Text != "")
                                {
                                    SqlCommand sqlCom = new SqlCommand();
                                    sqlCom.Connection = sqlCon;
                                    sqlCom.CommandType = CommandType.StoredProcedure;
                                    sqlCom.CommandText = "IRPC_BDEICICI_SP";//Yasir //Old- sp_BDEICICI
                                    sqlCom.CommandTimeout = 0;

                                    SqlDataAdapter sqlDA = new SqlDataAdapter();
                                    sqlDA.SelectCommand = sqlCom;

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

                                    SqlParameter Status = new SqlParameter();
                                    Status.SqlDbType = SqlDbType.VarChar;
                                    Status.Value = ddlstatus.SelectedValue.ToString();
                                    Status.ParameterName = "@LosStatus";
                                    sqlCom.Parameters.Add(Status);



                                    SqlParameter apsid = new SqlParameter();
                                    apsid.SqlDbType = SqlDbType.VarChar;
                                    apsid.Value = txtapsid.Text.Trim();
                                    apsid.ParameterName = "@aps_id";
                                    sqlCom.Parameters.Add(apsid);


                                    SqlParameter Remark = new SqlParameter();
                                    Remark.SqlDbType = SqlDbType.VarChar;
                                    Remark.Value = txtremark.Text.Trim();
                                    Remark.ParameterName = "@LosRemark";
                                    sqlCom.Parameters.Add(Remark);


                                    SqlParameter ProductStatus = new SqlParameter();
                                    ProductStatus.SqlDbType = SqlDbType.VarChar;
                                    ProductStatus.Value = ddlProductStatus.SelectedValue.ToString();
                                    ProductStatus.ParameterName = "@ProductStatus";
                                    sqlCom.Parameters.Add(ProductStatus);


                                    //Yasir
                                    //SqlParameter loanamount = new SqlParameter();
                                    //loanamount.SqlDbType = SqlDbType.VarChar;
                                    //loanamount.Value = txtloanamount.Text.Trim();
                                    //loanamount.ParameterName = "@BDE_Loanamount";
                                    //sqlCom.Parameters.Add(loanamount);



                                    //SqlParameter loantenure = new SqlParameter();
                                    //loantenure.SqlDbType = SqlDbType.VarChar;
                                    //loantenure.Value = txtloantenure.Text.Trim();
                                    //loantenure.ParameterName = "@BDE_Loantenure";
                                    //sqlCom.Parameters.Add(loantenure);

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
                                    lblMessage.Text = "Please Enter Remark!!";
                                    txtremark.Focus();
                                }
                            }

                            else
                            {
                                lblMessage.Text = "Please APS ID!!";
                                txtapsid.Focus();
                            }

                        }
                        else
                        {
                            lblMessage.Text = "Please Select Status........!!";
                            txtremark.Focus();
                        }
                    }
                    else
                    {
                        lblMessage.Text = "Please Select Product Status........!!";
                        txtremark.Focus();
                    }
                }
                else
                {
                    lblMessage.Text = "Please Select Check Box........!!";

                    return;
                }
            }



            if (Session["UserInfo"] != null)
            {

                Response.Redirect("~/pages/Logout.aspx", false);
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

    private void get_importdata()
    {
        Object SaveUSERInfo = (Object)Session["UserInfo"];
        SqlConnection sqlCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);

        try
        {
            for (int i = 0; i <= grdlos.Rows.Count - 1; i++)
            {
                HiddenField hdndata = new HiddenField();
                hdndata.Value = grdlos.Rows[i].Cells[4].Text.Trim();

                SqlCommand sqlCom2 = new SqlCommand();
                sqlCom2.Connection = sqlCon;
                sqlCom2.CommandType = CommandType.StoredProcedure;
                sqlCom2.CommandText = "IRPC_Get_ImportData_SP";

                SqlDataAdapter sqlDA2 = new SqlDataAdapter();
                sqlDA2.SelectCommand = sqlCom2;

                SqlParameter PMSlocation = new SqlParameter();
                PMSlocation.SqlDbType = SqlDbType.VarChar;
                PMSlocation.Value = hdndata.Value;
                PMSlocation.ParameterName = "@losno";
                sqlCom2.Parameters.Add(PMSlocation);

                sqlCon.Open();

                SqlDataAdapter sqlDA = new SqlDataAdapter();
                sqlDA.SelectCommand = sqlCom2;

                DataTable dt = new DataTable();
                sqlDA.Fill(dt);

                sqlCon.Close();

                if (dt.Rows.Count > 0)
                {
                    grddata.DataSource = dt;
                    grddata.DataBind();

                }
                else
                {
                    grddata.DataSource = null;
                    grddata.DataBind();
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
}


