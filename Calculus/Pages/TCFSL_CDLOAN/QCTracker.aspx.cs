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

public partial class Pages_TCFSL_CDLOAN_QCTracker : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            updateAutoAssignment();
            bindCasesGrid();
        }
    }
    public void bindCasesGrid()
    {
        Object SaveUSERInfo = (Object)Session["UserInfo"];
        SqlConnection sqlCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);

        try
        {
            SqlCommand sqlCom = new SqlCommand();
            sqlCom.Connection = sqlCon;
            sqlCom.CommandType = CommandType.StoredProcedure;
            sqlCom.CommandText = "TCFSL__Auto_Assign_To_QC_SP";

            SqlParameter intType = new SqlParameter();
            intType.SqlDbType = SqlDbType.VarChar;
            intType.Value = 4;
            intType.ParameterName = "@intType";
            sqlCom.Parameters.Add(intType);

            SqlParameter UserID = new SqlParameter();
            UserID.SqlDbType = SqlDbType.VarChar;
            UserID.Value = Convert.ToString(((UserInfo.structUSERInfo)(SaveUSERInfo)).UserId);
            UserID.ParameterName = "@UserID";
            sqlCom.Parameters.Add(UserID);

            SqlDataAdapter sqlDA2 = new SqlDataAdapter();
            sqlDA2.SelectCommand = sqlCom;


            sqlCon.Open();

            SqlDataAdapter sqlDA = new SqlDataAdapter();
            sqlDA.SelectCommand = sqlCom;

            DataTable dt = new DataTable();
            sqlDA.Fill(dt);

            sqlCon.Close();

            if (dt.Rows.Count > 0)
            {
                grdCases.DataSource = dt;
                grdCases.DataBind();
                hdnCaseNo.Value = dt.Rows[0]["Case_Number"].ToString();
                hdnWebTop.Value = dt.Rows[0]["Webtop_Id"].ToString();
            }
            else
            {
                grdCases.DataSource = null;
                grdCases.DataBind();
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
    public void updateAutoAssignment()
    {
        Object SaveUSERInfo = (Object)Session["UserInfo"];
        SqlConnection sqlCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);

        try
        {
            SqlCommand sqlCom = new SqlCommand();
            sqlCom.Connection = sqlCon;
            sqlCom.CommandType = CommandType.StoredProcedure;
            sqlCom.CommandText = "TCFSL__Auto_Assign_To_QC_SP";

            SqlParameter intType = new SqlParameter();
            intType.SqlDbType = SqlDbType.VarChar;
            intType.Value = 1;
            intType.ParameterName = "@intType";
            sqlCom.Parameters.Add(intType);

            SqlDataAdapter sqlDA2 = new SqlDataAdapter();
            sqlDA2.SelectCommand = sqlCom;


            sqlCon.Open();

            SqlDataAdapter sqlDA = new SqlDataAdapter();
            sqlDA.SelectCommand = sqlCom;

            DataTable dt = new DataTable();
            sqlDA.Fill(dt);

            sqlCon.Close();

            //if (dt.Rows.Count > 0)
            //{
            //    grdCases.DataSource = dt;
            //    grdCases.DataBind();
            //    hdnCaseNo.Value = dt.Rows[0]["Case_Number"].ToString();
            //    hdnWebTop.Value = dt.Rows[0]["Webtop_Id"].ToString();
            //}
            //else
            //{
            //    grdCases.DataSource = null;
            //    grdCases.DataBind();
            //}

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
    protected void ddlError_SelectedIndexChanged(object sender, EventArgs e)
    {
        Object SaveUSERInfo = (Object)Session["UserInfo"];

        SqlConnection sqlCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);
        try
        {
            if (sqlCon.State == ConnectionState.Closed)
            {
                sqlCon.Open();
                for (int i = 0; i <= grdCases.Rows.Count - 1; i++)
                {
                    DropDownList ddlError = (DropDownList)grdCases.Rows[i].FindControl("ddlError");

                    ListBox lstDocumentStage = (ListBox)grdCases.Rows[i].FindControl("lstDocumentStage");

                    TextBox txtRemarks = (TextBox)grdCases.Rows[i].FindControl("txtRemarks");



                    if (hdnStartStatus.Value == "InProcess")
                    {
                        if (ddlError.SelectedItem.Text != "--Select--")
                        {
                            if ((ddlError.SelectedItem.Text == "No Error"))
                            {
                                lstDocumentStage.Visible = false;
                                txtRemarks.Visible = false;

                            }
                            else
                            {
                                lstDocumentStage.Visible = true;
                                txtRemarks.Visible = true;
                            }
                        }
                        else
                        {
                            hiddenResult.Value = "Select Error....!!!!!";
                            ddlError.SelectedIndex = 0;
                        }
                    }
                    else
                    {
                        hiddenResult.Value = "Click on Start button.........!!";
                        ddlError.SelectedIndex = 0;
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
    protected void lnkWIP_Click(object sender, EventArgs e)
    {
        hdnStartStatus.Value = "InProcess";
        Object SaveUSERInfo = (Object)Session["UserInfo"];
        SqlConnection sqlCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);

        try
        {
            SqlCommand sqlCom = new SqlCommand();
            sqlCom.Connection = sqlCon;
            sqlCom.CommandType = CommandType.StoredProcedure;
            sqlCom.CommandText = "TCFSL__Auto_Assign_To_QC_SP";

            SqlParameter intType = new SqlParameter();
            intType.SqlDbType = SqlDbType.VarChar;
            intType.Value = 2;
            intType.ParameterName = "@intType";
            sqlCom.Parameters.Add(intType);

            SqlParameter UserId = new SqlParameter();
            UserId.SqlDbType = SqlDbType.VarChar;
            UserId.Value = Convert.ToString(((UserInfo.structUSERInfo)(SaveUSERInfo)).UserId);
            UserId.ParameterName = "@UserId";
            sqlCom.Parameters.Add(UserId);

            SqlParameter CaseNo = new SqlParameter();
            CaseNo.SqlDbType = SqlDbType.VarChar;
            CaseNo.Value = hdnCaseNo.Value.ToString(); ;
            CaseNo.ParameterName = "@CaseNo";
            sqlCom.Parameters.Add(CaseNo);

            SqlParameter WebtopNo = new SqlParameter();
            WebtopNo.SqlDbType = SqlDbType.VarChar;
            WebtopNo.Value = hdnWebTop.Value.ToString(); ;
            WebtopNo.ParameterName = "@WebtopNo";
            sqlCom.Parameters.Add(WebtopNo);

            SqlDataAdapter sqlDA2 = new SqlDataAdapter();
            sqlDA2.SelectCommand = sqlCom;


            sqlCon.Open();

            SqlDataAdapter sqlDA = new SqlDataAdapter();
            sqlDA.SelectCommand = sqlCom;

            DataTable dt = new DataTable();
            sqlDA.Fill(dt);

            sqlCon.Close();

            //if (dt.Rows.Count > 0)
            //{
            //    grdCases.DataSource = dt;
            //    grdCases.DataBind();

            //}
            //else
            //{
            //    grdCases.DataSource = null;
            //    grdCases.DataBind();
            //}

        }
        catch (Exception ex)
        {
            //hiddenResult.Value = "Error :" + ex.Message;
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
    protected void lnkCompleteNext_Click(object sender, EventArgs e)
    {
        Object SaveUSERInfo = (Object)Session["UserInfo"];

        SqlConnection sqlCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);
        try
        {
            for (int i = 0; i <= grdCases.Rows.Count - 1; i++)
            {
                DropDownList ddlError = (DropDownList)grdCases.Rows[i].FindControl("ddlError");

                ListBox lstDocumentStage = (ListBox)grdCases.Rows[i].FindControl("lstDocumentStage");

                TextBox txtRemarks = (TextBox)grdCases.Rows[i].FindControl("txtRemarks");

                string isErrorExist = ddlError.SelectedItem.Value.ToString();

                string errorList = "";

                if (isErrorExist == "Error")
                {
                    foreach (ListItem item in lstDocumentStage.Items)
                    {
                        if (item.Selected)
                        {
                            errorList += item.Text + " ,";
                        }
                    }
                    if (errorList.Substring(errorList.Length - 1) == ",")
                        errorList = errorList.Remove(errorList.Length - 1);
                }
                if (hdnStartStatus.Value == "InProcess")
                {
                    SqlCommand sqlCom = new SqlCommand();
                    sqlCom.Connection = sqlCon;
                    sqlCom.CommandType = CommandType.StoredProcedure;
                    sqlCom.CommandText = "TCFSL__Auto_Assign_To_QC_SP";

                    SqlDataAdapter sqlDA = new SqlDataAdapter();
                    sqlDA.SelectCommand = sqlCom;

                    SqlParameter intType = new SqlParameter();
                    intType.SqlDbType = SqlDbType.VarChar;
                    intType.Value = 3;
                    intType.ParameterName = "@intType";
                    sqlCom.Parameters.Add(intType);

                    SqlParameter IsErrorExist = new SqlParameter();
                    IsErrorExist.SqlDbType = SqlDbType.VarChar;
                    IsErrorExist.Value = isErrorExist;
                    IsErrorExist.ParameterName = "@IsErrorExist";
                    sqlCom.Parameters.Add(IsErrorExist);

                    SqlParameter ErrorParameter = new SqlParameter();
                    ErrorParameter.SqlDbType = SqlDbType.VarChar;
                    ErrorParameter.Value = errorList;
                    ErrorParameter.ParameterName = "@ErrorParameter";
                    sqlCom.Parameters.Add(ErrorParameter);

                    SqlParameter ErrorRemark = new SqlParameter();
                    ErrorRemark.SqlDbType = SqlDbType.VarChar;
                    ErrorRemark.Value = txtRemarks.Text;
                    ErrorRemark.ParameterName = "@ErrorRemark";
                    sqlCom.Parameters.Add(ErrorRemark);

                    SqlParameter UserID = new SqlParameter();
                    UserID.SqlDbType = SqlDbType.VarChar;
                    UserID.Value = Convert.ToString(((UserInfo.structUSERInfo)(SaveUSERInfo)).UserId);
                    UserID.ParameterName = "@UserID";
                    sqlCom.Parameters.Add(UserID);

                    SqlParameter caseno = new SqlParameter();
                    caseno.SqlDbType = SqlDbType.VarChar;
                    caseno.Value = hdnCaseNo.Value;
                    caseno.ParameterName = "@caseno";
                    sqlCom.Parameters.Add(caseno);

                    SqlParameter WebtopNo = new SqlParameter();
                    WebtopNo.SqlDbType = SqlDbType.VarChar;
                    WebtopNo.Value = hdnWebTop.Value;
                    WebtopNo.ParameterName = "@WebtopNo";
                    sqlCom.Parameters.Add(WebtopNo);


                    sqlCon.Open();
                    int SqlRow = 0;
                    SqlRow = sqlCom.ExecuteNonQuery();
                    sqlCon.Close();
                    if (SqlRow > 0)
                    {
                        hiddenResult.Value = "Data Successfully Updated........!!";
                        updateAutoAssignment();
                        bindCasesGrid();

                    }
                    else
                    {
                        hiddenResult.Value = "Something went wrong........!!";
                        return;
                    }
                }
                else
                {
                    hiddenResult.Value = "Click on Start button.........!!";
                    return;


                }
            }

            updateAutoAssignment();
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
    protected void lnkCompleteExit_Click(object sender, EventArgs e)
    {
        Object SaveUSERInfo = (Object)Session["UserInfo"];

        SqlConnection sqlCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);
        try
        {
            for (int i = 0; i <= grdCases.Rows.Count - 1; i++)
            {
                DropDownList ddlError = (DropDownList)grdCases.Rows[i].FindControl("ddlError");

                ListBox lstDocumentStage = (ListBox)grdCases.Rows[i].FindControl("lstDocumentStage");

                TextBox txtRemarks = (TextBox)grdCases.Rows[i].FindControl("txtRemarks");

                string isErrorExist = ddlError.SelectedItem.Value.ToString();

                string errorList = "";

                if (isErrorExist == "Error")
                {
                    foreach (ListItem item in lstDocumentStage.Items)
                    {
                        if (item.Selected)
                        {
                            errorList += item.Text + " ,";
                        }
                    }
                    if (errorList.Substring(errorList.Length - 1) == ",")
                        errorList = errorList.Remove(errorList.Length - 1);
                }
                if (hdnStartStatus.Value == "InProcess")
                {
                    SqlCommand sqlCom = new SqlCommand();
                    sqlCom.Connection = sqlCon;
                    sqlCom.CommandType = CommandType.StoredProcedure;
                    sqlCom.CommandText = "TCFSL__Auto_Assign_To_QC_SP";

                    SqlDataAdapter sqlDA = new SqlDataAdapter();
                    sqlDA.SelectCommand = sqlCom;

                    SqlParameter intType = new SqlParameter();
                    intType.SqlDbType = SqlDbType.VarChar;
                    intType.Value = 3;
                    intType.ParameterName = "@intType";
                    sqlCom.Parameters.Add(intType);

                    SqlParameter IsErrorExist = new SqlParameter();
                    IsErrorExist.SqlDbType = SqlDbType.VarChar;
                    IsErrorExist.Value = isErrorExist;
                    IsErrorExist.ParameterName = "@IsErrorExist";
                    sqlCom.Parameters.Add(IsErrorExist);

                    SqlParameter ErrorParameter = new SqlParameter();
                    ErrorParameter.SqlDbType = SqlDbType.VarChar;
                    ErrorParameter.Value = errorList;
                    ErrorParameter.ParameterName = "@ErrorParameter";
                    sqlCom.Parameters.Add(ErrorParameter);

                    SqlParameter ErrorRemark = new SqlParameter();
                    ErrorRemark.SqlDbType = SqlDbType.VarChar;
                    ErrorRemark.Value = txtRemarks.Text;
                    ErrorRemark.ParameterName = "@ErrorRemark";
                    sqlCom.Parameters.Add(ErrorRemark);

                    SqlParameter UserID = new SqlParameter();
                    UserID.SqlDbType = SqlDbType.VarChar;
                    UserID.Value = Convert.ToString(((UserInfo.structUSERInfo)(SaveUSERInfo)).UserId);
                    UserID.ParameterName = "@UserID";
                    sqlCom.Parameters.Add(UserID);

                    SqlParameter caseno = new SqlParameter();
                    caseno.SqlDbType = SqlDbType.VarChar;
                    caseno.Value = hdnCaseNo.Value;
                    caseno.ParameterName = "@CaseNo";
                    sqlCom.Parameters.Add(caseno);

                    SqlParameter WebtopNo = new SqlParameter();
                    WebtopNo.SqlDbType = SqlDbType.VarChar;
                    WebtopNo.Value = hdnWebTop.Value;
                    WebtopNo.ParameterName = "@WebtopNo";
                    sqlCom.Parameters.Add(WebtopNo);


                    sqlCon.Open();
                    int SqlRow = 0;
                    SqlRow = sqlCom.ExecuteNonQuery();
                    sqlCon.Close();
                    if (SqlRow > 0)
                    {
                        Response.Redirect("~/Pages/Menu.aspx", true);
                    }
                    else
                    {
                        hiddenResult.Value = "Something went wrong........!!";
                        return;
                    }
                }
                else
                {
                    hiddenResult.Value = "Click on Start button.........!!";
                    return;
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
    protected void grdCases_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        SqlConnection sqlCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);

        if (e.Row.RowType == DataControlRowType.DataRow)
        {

            DropDownList ddlError = (e.Row.FindControl("ddlError") as DropDownList);

            SqlCommand cmd = new SqlCommand("TCFSL_MasterSearchCode_SP", sqlCon);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Types", "ErrorType");
            cmd.Parameters.AddWithValue("@Level", 1);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            adp.Fill(ds);

            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                ddlError.DataSource = ds;
                ddlError.DataValueField = "Code_Id";
                ddlError.DataTextField = "Description";
                ddlError.DataBind();
                ddlError.Items.Insert(0, new ListItem("--Select--", "0"));
            }
        }
    }
}