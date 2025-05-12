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

public partial class Pages_ChequeProcessingNEW_MDBDetails_master : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                if (Session["UserInfo"] == null)
                {
                    Response.Redirect("~/Pages/InvalidRequest.aspx");

                }
                //Get_RegionID();
                BindIsActive();
                Clear_textfield();
                Get_BranchData();
                Get_GridBranchInfo();
                Register_Validation();
               
            }
        }
        catch (Exception ex)
        {
            lblMessage.Visible = true;
            lblMessage.Text = ex.Message;
            lblMessage.CssClass = "ErrorMessage";


        }
    }
    protected void BindIsActive()
    {
        SqlConnection sqlCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);

        SqlCommand cmd = new SqlCommand("KMPL_SearchCodeMaster_SP", sqlCon);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@Types", "CMIsActiveType");
        cmd.Parameters.AddWithValue("@Level", 1);
        SqlDataAdapter adp = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        adp.Fill(ds);

        if (ds != null && ds.Tables[0].Rows.Count > 0)
        {
            ddlIsActive.DataSource = ds;
            ddlIsActive.DataValueField = "Code_Id";
            ddlIsActive.DataTextField = "Description";
            ddlIsActive.DataBind();
            ddlIsActive.Items.Insert(0, new ListItem("--Select--", "0"));
        }
    }
    private void Get_BranchData()
    {
        try
        {
            SqlConnection sqlcon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);


            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlcon;
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.CommandText = "CommonMaster_Get_C_BranchData_SP";
            sqlcmd.CommandTimeout = 0;

            sqlcon.Open();
            SqlDataAdapter sqlda = new SqlDataAdapter();
            sqlda.SelectCommand = sqlcmd;
            DataTable dt = new DataTable();
            sqlda.Fill(dt);
            sqlcon.Close();

            ddlBranchName.DataTextField = "BranchName";
            ddlBranchName.DataValueField = "BranchId";
            ddlBranchName.DataSource = dt;
            ddlBranchName.DataBind();

            ddlBranchName.Items.Insert(0, "-Select-");
            ddlBranchName.SelectedIndex = 0;

        }
        catch (Exception ex)
        {
            lblMessage.Visible = true;
            lblMessage.Text = ex.Message;
            lblMessage.CssClass = "ErrorMessage";

        }

        finally
        { 
        }

    }
    private void Register_Validation()
    {
        btnSave.Attributes.Add("onclick", "javascript:return ValidationAllField();");

    }

    private void Get_GridBranchInfo()
    {
        try
        {
            Object SaveUSERInfo = (Object)Session["UserInfo"];

            SqlConnection SqlCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);


            SqlCommand SqlCmd = new SqlCommand();
            SqlCmd.Connection = SqlCon;
            SqlCmd.CommandType = CommandType.StoredProcedure;
            SqlCmd.CommandText = "CommonMaster_Get_BranchData_ForMDBDetails_SP";
            SqlCmd.CommandTimeout = 0;


            SqlParameter BranchId = new SqlParameter();
            BranchId.SqlDbType = SqlDbType.Int;
            BranchId.Value = Convert.ToInt32(((UserInfo.structUSERInfo)(SaveUSERInfo)).BranchId);
            BranchId.ParameterName = "@BranchId";
            SqlCmd.Parameters.Add(BranchId);


            SqlCon.Open();

            SqlDataAdapter sqlDA = new SqlDataAdapter();
            sqlDA.SelectCommand = SqlCmd;

            DataTable dt = new DataTable();
            sqlDA.Fill(dt);
            SqlCon.Close();

            Gv_Search.DataSource = dt;
            Gv_Search.DataBind();
        }
        catch (Exception ex)
        {
            lblMessage.Visible = true;
            lblMessage.Text = ex.Message;
            lblMessage.CssClass = "Error Message";
        }
        finally
        { 
        
        }

    }

    protected void Gv_Search_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Attributes.Add("onclick", "javascript:GV_RowSelection('" + e.Row.RowIndex + "','" + e.Row.Cells[0].Text + "');");
        }

    }
    
    //private void Get_RegionID()
    //{
    //    try
    //    {
    //        SqlConnection sqlcon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);

    //        sqlcon.Open();
    //        SqlCommand sqlcmd = new SqlCommand();
    //        sqlcmd.Connection = sqlcon;
    //        sqlcmd.CommandType = CommandType.StoredProcedure;
    //        sqlcmd.CommandText = "Get_Region";
    //        SqlDataAdapter sqlda = new SqlDataAdapter();
    //        sqlda.SelectCommand = sqlcmd;
    //        DataTable dt = new DataTable();
    //        sqlda.Fill(dt);
    //        sqlcon.Close();

    //        ddlRegion.DataTextField = "Region_Name";
    //        ddlRegion.DataValueField = "Region_id";
    //        ddlRegion.DataSource = dt;
    //        ddlRegion.DataBind();

    //        ddlRegion.Items.Insert(0, "-Select-");
    //        ddlRegion.SelectedIndex = 0;

    //    }
    //    catch (Exception ex)
    //    {
    //        lblMessage.Visible = true;
    //        lblMessage.Text = ex.Message;
    //        lblMessage.CssClass = "ErrorMessage";

    //    }

    //}

    protected void btnSave_Click(object sender, EventArgs e)
    {
        Insert_BranchInfo();
        Get_GridBranchInfo();
        Clear_textfield();

    }

    protected void Insert_BranchInfo()
    {
        Object SaveUSERInfo = (Object)Session["UserInfo"];

        using (SqlConnection sqlCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]))
        {

            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.Connection = sqlCon;
            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCmd.CommandText = "CommonMaster_Insert_LocationInfo_SP";
            sqlCmd.CommandTimeout = 0;

            SqlParameter BranchID = new SqlParameter();
            BranchID.SqlDbType = SqlDbType.Int;
            BranchID.Value = ddlBranchName.SelectedItem.Value;
            //BranchID.Value = hdnBranchId.Value;
            BranchID.ParameterName = "@BranchId";
            sqlCmd.Parameters.Add(BranchID);

            SqlParameter BranchName = new SqlParameter();
            BranchName.SqlDbType = SqlDbType.VarChar;
            BranchName.Value = ddlBranchName.SelectedItem.Text;
            BranchName.ParameterName = "@BranchName";
            sqlCmd.Parameters.Add(BranchName);

            SqlParameter BranchCode = new SqlParameter();
            BranchCode.SqlDbType = SqlDbType.VarChar;
            BranchCode.Value = txtBranchCode.Text.Trim();
            BranchCode.ParameterName = "@BranchCode";
            sqlCmd.Parameters.Add(BranchCode);

            SqlParameter CityCode = new SqlParameter();
            CityCode.SqlDbType = SqlDbType.VarChar;
            CityCode.Value = txtCityCode.Text;
            CityCode.ParameterName = "@CityCode";
            sqlCmd.Parameters.Add(CityCode);

            if (txtDSLimit.Text == "")
            {
                txtDSLimit.Text = Convert.ToString(0);
            }
            SqlParameter Ds_Limit = new SqlParameter();
            Ds_Limit.SqlDbType = SqlDbType.Int;
            Ds_Limit.Value = Convert.ToInt32(txtDSLimit.Text);
            Ds_Limit.ParameterName = "@Ds_Limit";
            sqlCmd.Parameters.Add(Ds_Limit);

            SqlParameter Is_Active = new SqlParameter();
            Is_Active.SqlDbType = SqlDbType.Bit;
            Is_Active.Value = Convert.ToBoolean(ddlIsActive.SelectedItem.Value);
            Is_Active.ParameterName = "@Is_Active";
            sqlCmd.Parameters.Add(Is_Active);

            SqlParameter UserID = new SqlParameter();
            UserID.SqlDbType = SqlDbType.VarChar;
            UserID.Value = Convert.ToString(((UserInfo.structUSERInfo)(SaveUSERInfo)).UserId);
            UserID.ParameterName = "@UserID";
            sqlCmd.Parameters.Add(UserID);

            SqlParameter LocCodeSBI = new SqlParameter();
            LocCodeSBI.SqlDbType = SqlDbType.VarChar;
            LocCodeSBI.Value = txtSBICode.Text.Trim();
            LocCodeSBI.ParameterName = "@LocCodeSBI";
            sqlCmd.Parameters.Add(LocCodeSBI);

            SqlParameter LocCodeNonSBI = new SqlParameter();
            LocCodeNonSBI.SqlDbType = SqlDbType.VarChar;
            LocCodeNonSBI.Value = txtNonSBICode.Text.Trim();
            LocCodeNonSBI.ParameterName = "@LocCodeNonSBI";
            sqlCmd.Parameters.Add(LocCodeNonSBI);

            sqlCon.Open();

            int SqlRow = 0;
            SqlRow = sqlCmd.ExecuteNonQuery();

            sqlCon.Close();

            if (SqlRow > 0)
            {
                lblMessage.Text = "Update Successfully!";
                lblMessage.CssClass = "UpdateMessage";
                lblMessage.Visible = true;
            }
        }
    }

    protected void Clear_textfield()
    {
        hdnBranchId.Value = "0";
        //txtBranchName.Text = "";
        ddlBranchName.SelectedIndex = 0;
        txtBranchCode.Text = "";
        ddlIsActive.SelectedIndex = 0;
        txtCityCode.Text = "";
        txtDSLimit.Text = "";
        txtSBICode.Text = "";
        txtNonSBICode.Text = "";
        //ddlRegion.SelectedIndex = 0;
    }


    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Pages/Menu.aspx", true);
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        Clear_textfield();
    }
    protected void Gv_Search_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}