using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;

public partial class Pages_Calculus_HDFC_HDFCTM_Loginstage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            if (Request.QueryString["msg"] != null)
            {
                lblMsg.Text = "Record Inserted";
            }

            Get_Login_Stage();
            BindUserDashbord();
        }
    }
    protected void BindUserDashbord()
    {
        try
        {
            SqlConnection sqlCon = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);
            Object SaveUSERInfo = (Object)Session["UserInfo"];

            SqlCommand cmd = new SqlCommand("HDFCTM_UserDashboard_SP", sqlCon);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@UserId", Convert.ToString(((UserInfo.structUSERInfo)(SaveUSERInfo)).UserId));

            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            adp.Fill(ds);

            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                lblFTNR.Text = "[FTNR:-" + ds.Tables[0].Rows[0]["FTNR"].ToString() + "]";
                lblFTR.Text = "[FTR:-" + ds.Tables[0].Rows[0]["FTR"].ToString() + "]";
                lblAlreadyDisbursed.Text = "[Already Disbursed:-" + ds.Tables[0].Rows[0]["AlreadyDisbursed"].ToString() + "]";
                lblLock.Text = "[Lock:-" + ds.Tables[0].Rows[0]["Lock"].ToString() + "]";
                lblHold.Text = "[Hold:-" + ds.Tables[0].Rows[0]["Hold"].ToString() + "]";
                lblALREADYFTNR.Text = "[Already FTNR:-" + ds.Tables[0].Rows[0]["ALREADYFTNR"].ToString() + "]";
                lblTotalCount.Text = "[Total Count:-" + ds.Tables[0].Rows[0]["TotalCount"].ToString() + "]";
            }
        }
        catch (Exception ex)
        {
            ex.ToString();
        }
    }
    protected void Status()
    {
        try
        {
            SqlConnection sqlCon = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);

            SqlCommand sqlCom = new SqlCommand();
            sqlCom.Connection = sqlCon;
            sqlCom.CommandType = CommandType.StoredProcedure;
            sqlCom.CommandText = "Sp_BindStatus";
            sqlCom.CommandTimeout = 0;


            SqlDataAdapter da = new SqlDataAdapter(sqlCom);
            DataSet ds = new DataSet();
            da.Fill(ds);

            if (ds != null && ds.Tables.Count > 0)
            {
                ddlStatus.DataTextField = "Status_atClose";
                ddlStatus.DataValueField = "ID";
                ddlStatus.DataSource = ds.Tables[0];
                ddlStatus.DataBind();

                ddlStatus.Items.Insert(0, "--Select--");
                ddlStatus.SelectedIndex = 0;
            }
        }
        catch (Exception ex)
        {
            ex.ToString();
        }
    }
    protected void Reason()
    {
        try
        {
            SqlConnection sqlCon = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);

            SqlCommand sqlCom = new SqlCommand();
            sqlCom.Connection = sqlCon;
            sqlCom.CommandType = CommandType.StoredProcedure;
            sqlCom.CommandText = "Sp_BindReason";
            sqlCom.CommandTimeout = 0;


            SqlDataAdapter da = new SqlDataAdapter(sqlCom);
            DataSet ds = new DataSet();
            da.Fill(ds);

            if (ds != null && ds.Tables.Count > 0)
            {
                ddlReason.DataTextField = "Reason";
                ddlReason.DataValueField = "ID";
                ddlReason.DataSource = ds.Tables[0];
                ddlReason.DataBind();

                ddlReason.Items.Insert(0, "--Select--");
                ddlReason.SelectedIndex = 0;
            }
        }
        catch (Exception ex)
        {
            ex.ToString();
        }
    }

    private void Get_Login_Stage()
    {
        try
        {
            Object SaveUSERInfo = (Object)Session["UserInfo"];

            SqlConnection sqlCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);

            sqlCon.Open();
            SqlCommand sqlCom = new SqlCommand();
            sqlCom.Connection = sqlCon;
            sqlCom.CommandType = CommandType.StoredProcedure;
            sqlCom.CommandText = "HDFC_LoginStage";

            SqlParameter Userid = new SqlParameter();
            Userid.SqlDbType = SqlDbType.VarChar;
            Userid.Value = Convert.ToString(((UserInfo.structUSERInfo)(SaveUSERInfo)).UserId);
            Userid.ParameterName = "@UserId";
            sqlCom.Parameters.Add(Userid);

            SqlDataAdapter sqlDA = new SqlDataAdapter();
            sqlDA.SelectCommand = sqlCom;


            DataTable dt = new DataTable();
            sqlDA.Fill(dt);
            sqlCon.Close();

            if (dt.Rows.Count > 0)
            {
                GridLoginStage.DataSource = dt;
                GridLoginStage.DataBind();

                hdnReferenceID.Value = Convert.ToString(dt.Rows[0]["ReferenceID"]);

            }

        }
        catch (Exception ex)
        {
            ex.ToString();
        }
    }
    protected void lnkEdit_Click(object sender, EventArgs e)
    {

        Object SaveUSERInfo = (Object)Session["UserInfo"];
        try
        {

            for (int i = 0; i <= GridLoginStage.Rows.Count - 1; i++)
            {
                LinkButton LinkBtn = (LinkButton)GridLoginStage.Rows[i].FindControl("lnkEdit");
                CheckBox chkSelect = (CheckBox)GridLoginStage.Rows[i].FindControl("chkSelect");

                string Application_ID = GridLoginStage.Rows[i].Cells[2].Text.Trim();


                if (chkSelect.Checked == true)
                {
                    SqlConnection sqlCon = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);

                    SqlCommand sqlCom = new SqlCommand();
                    sqlCom.Connection = sqlCon;
                    sqlCom.CommandType = CommandType.StoredProcedure;
                    sqlCom.CommandText = "BindDataLoginStage";
                    sqlCom.CommandTimeout = 0;

                    SqlParameter ReferenceID = new SqlParameter();
                    ReferenceID.SqlDbType = SqlDbType.Int;
                    ReferenceID.Value = Convert.ToInt32(hdnReferenceID.Value);
                    ReferenceID.ParameterName = "@ReferenceID";
                    sqlCom.Parameters.Add(ReferenceID);

                    SqlDataAdapter adp = new SqlDataAdapter(sqlCom);
                    DataSet ds = new DataSet();
                    adp.Fill(ds);

                    if (ds != null)
                    {
                        Panel1.Visible = true;
                        txtApplicationID.Text = Convert.ToString(ds.Tables[0].Rows[0]["ApplicationID"]);
                        txtAssignedDatetime.Text = Convert.ToString(ds.Tables[0].Rows[0]["AssignedDate"]);
                        txtCustomerName.Text = Convert.ToString(ds.Tables[0].Rows[0]["CustomerName"]);
                        hdnUploadDate.Value = Convert.ToString(ds.Tables[0].Rows[0]["UploadDate"]);
                        hdnEmployeeCode.Value = Convert.ToString(((UserInfo.structUSERInfo)(SaveUSERInfo)).UserId);
                        hdnEmployeeName.Value = Convert.ToString(((UserInfo.structUSERInfo)(SaveUSERInfo)).UserName);
                        hdnFileStatus.Value = Convert.ToString(ds.Tables[0].Rows[0]["FileStatus"]);
                        hdnAssignedto.Value = Convert.ToString(ds.Tables[0].Rows[0]["AssignedTo"]);
                        Status();
                        Reason();

                        chkSelect.Checked = false;
                        chkSelect.Enabled = false;
                    }
                }
                else
                {

                }
            }
        }
        catch (Exception ex)
        {
            ex.ToString();

        }
    }
    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Pages/Menu.aspx", true);
    }
    protected void btnSaveAndContinue_Click(object sender, EventArgs e)
    {
        Object SaveUSERInfo = (Object)Session["UserInfo"];

        if (SaveUSERInfo != null)
        {
            bool result = SaveData();
            if (result)
            {
                BindUserDashbord();
                Response.Redirect("HDFCTM_Loginstage.aspx?msg=true");
            }

        }
        else
        {
            Session.Clear();
            Response.Redirect("~/Pages/Login.aspx", true);
        }

    }

    protected bool SaveData()
    {
        bool validationResult = false;

        if (ddlStatus.SelectedIndex == 0)
        {
            lblMsg.Text = "Please Select the Status";
            return false;
        }

        if (ddlStatus.SelectedItem.Text.Trim() == "FTNR" && ddlReason.SelectedIndex == 0)
        {
            lblMsg.Text = "Please Select the Reason";
            return false;
        }

        if (ddlStatus.SelectedItem.Text.Trim() == "FTNR" && ddlReason.SelectedItem.Text.Trim() == "Others" && txtRemarks.Text.Trim() == "")
        {
            lblMsg.Text = "Please Enter the Remarks";
            return false;
        }

        if (ddlStatus.SelectedItem.Text.Trim() == "Hold" && txtRemarks.Text.Trim() == "")
        {
            lblMsg.Text = "Please Enter the Remarks";
            return false;
        }

        try
        {
            lblMsg.Text = "";

            string Reason = "";

            SqlConnection sqlCon = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);
            Object SaveUSERInfo = (Object)Session["UserInfo"];

            SqlCommand cmd = new SqlCommand("HDFCTM_LoginStage_SP", sqlCon);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Updatedate", Convert.ToDateTime(hdnUploadDate.Value));
            cmd.Parameters.AddWithValue("@ApplicationID", txtApplicationID.Text.Trim());
            cmd.Parameters.AddWithValue("@CustomerName", txtCustomerName.Text.Trim());
            cmd.Parameters.AddWithValue("@FileStatus", hdnFileStatus.Value);
            cmd.Parameters.AddWithValue("@AssignedTo", hdnAssignedto.Value);
            cmd.Parameters.AddWithValue("@assigndatetime", txtAssignedDatetime.Text.Trim());
            cmd.Parameters.AddWithValue("@StatusatClose", ddlStatus.SelectedValue);

            if (ddlReason.SelectedItem.Text == "Others" || ddlStatus.SelectedItem.Text.Trim().ToUpper() == "HOLD")
            {
                Reason = txtRemarks.Text.Trim();
            }
            else
            {
                Reason = ddlReason.SelectedItem.Text.Trim();
            }

            if (ddlStatus.SelectedItem.Text.Trim().ToUpper() != "HOLD" && ddlStatus.SelectedItem.Text.Trim().ToUpper() != "FTNR")
            {
                Reason = "";
            }

            cmd.Parameters.AddWithValue("@Reason", Reason);
            cmd.Parameters.AddWithValue("@userid", hdnEmployeeCode.Value);
            cmd.Parameters.AddWithValue("@ReferenceID", Convert.ToInt32(hdnReferenceID.Value));


            sqlCon.Open();
            int result = cmd.ExecuteNonQuery();
            sqlCon.Close();

            if (result > 0)
            {
                lblMsg.Visible = true;

                lblMsg.Text = "Data Successfully added ";

                validationResult = true;
            }
        }
        catch (Exception ex)
        {
            ex.ToString();
            validationResult = false;
        }

        return validationResult;
    }

    protected void ddlStatus_SelectedIndexChanged(object sender, EventArgs e)
    {
        //ddlStatus.SelectedItem.Text = null;

        txtRemarks.Enabled = false;

        if (ddlStatus.SelectedItem.Text == "FTNR")
        {
            ddlReason.Enabled = true;
        }

        else if (ddlStatus.SelectedItem.Text == "Hold")
        {
            ddlReason.SelectedIndex = 0;
            txtRemarks.Enabled = true;
            ddlReason.Enabled = false;
        }
        else
        // if (ddlStatus.SelectedItem.Text == "FTR" || ddlStatus.SelectedItem.Text == "Already_DisbursedR" || ddlStatus.SelectedItem.Text == "Lock" || ddlStatus.SelectedItem.Text == "Ops_H")
        {
            ddlReason.SelectedIndex = 0;
            ddlReason.Enabled = false;
            txtRemarks.Enabled = false;
            txtRemarks.Text = "";
        }

    }
    protected void btnSaveAndExit_Click(object sender, EventArgs e)
    {
        Object SaveUSERInfo = (Object)Session["UserInfo"];

        if (SaveUSERInfo != null)
        {

            bool result = SaveData();
            if (result)
            {
                Response.Redirect("~/Pages/Menu.aspx", true);
            }

        }
        else
        {
            Session.Clear();
            Response.Redirect("~/Pages/Login.aspx", true);
        }
    }
    protected void ddlReason_SelectedIndexChanged(object sender, EventArgs e)
    {

        if (ddlReason.SelectedItem.Text == "Others")
        {
            txtRemarks.Enabled = true;
        }
        else
        {
            txtRemarks.Enabled = false;
        }
    }
}