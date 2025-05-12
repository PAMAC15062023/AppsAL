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

public partial class Pages_Calculus_Reason_Master : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserInfo"] == null)
        {
            Response.Redirect("~/Pages/InvalidRequest.aspx");
        }
        try
        {
            if (!IsPostBack)
            {
                BindIsActive();
                BindFlagType();
                BindReasonType();
                Get_ReasonInfo();
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
    protected void BindFlagType() 
    {
        SqlConnection sqlCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);

        SqlCommand cmd = new SqlCommand("KMPL_SearchCodeMaster_SP", sqlCon);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@Types", "CMFlagTypes");
        cmd.Parameters.AddWithValue("@Level", 1);
        SqlDataAdapter adp = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        adp.Fill(ds);

        if (ds != null && ds.Tables[0].Rows.Count > 0)
        {
            ddlFlag.DataSource = ds;
            ddlFlag.DataValueField = "Code_Id";
            ddlFlag.DataTextField = "Description";
            ddlFlag.DataBind();
            ddlFlag.Items.Insert(0, new ListItem("--Select--", "0"));
        }
    }
    protected void BindReasonType()
    {
        SqlConnection sqlCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);

        SqlCommand cmd = new SqlCommand("KMPL_SearchCodeMaster_SP", sqlCon);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@Types", "CMReasonTypes");
        cmd.Parameters.AddWithValue("@Level", 1);
        SqlDataAdapter adp = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        adp.Fill(ds);

        if (ds != null && ds.Tables[0].Rows.Count > 0)
        {
            ddlReasonType.DataSource = ds;
            ddlReasonType.DataValueField = "Code_Id";
            ddlReasonType.DataTextField = "Description";
            ddlReasonType.DataBind();
            ddlReasonType.Items.Insert(0, new ListItem("--Select--", "0"));
        }
    }

    private void Register_Validation()
    {
        btnSave.Attributes.Add("onclick", "javascript:return ValidationAllField();");

    }

    private void Get_ReasonInfo()
    {
        try
        {
            Object SaveUSERInfo = (Object)Session["UserInfo"];

            SqlConnection SqlCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);

            SqlCon.Open();
            SqlCommand SqlCmd = new SqlCommand();
            SqlCmd.Connection = SqlCon;
            SqlCmd.CommandType = CommandType.StoredProcedure;
            SqlCmd.CommandText = "CommonMaster_Get_ReasonInfo_SP";

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

    protected void Gv_Search_RowDataBound(object sender,GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Attributes.Add("onclick", "javascript:GV_RowSelection('" + e.Row.RowIndex + "','" + e.Row.Cells[0].Text + "');");
           
            
        }

    }


 
    protected void btnSave_Click(object sender, EventArgs e)
    {
        Insert_BranchInfo();
        Get_ReasonInfo();
        Clear_textfield();
        
    }

    protected void Insert_BranchInfo()
    {
        Object SaveUSERInfo = (Object)Session["UserInfo"];
        SqlConnection sqlCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);

        sqlCon.Open();
        SqlCommand sqlCmd = new SqlCommand();
        sqlCmd.Connection = sqlCon;
        sqlCmd.CommandType = CommandType.StoredProcedure;
        sqlCmd.CommandText = "CommonMaster_Insert_ReasonInfo_SP";

        SqlParameter ReasonID = new SqlParameter();
        ReasonID.SqlDbType = SqlDbType.Int;
        ReasonID.Value = hdnReasonId.Value;
        ReasonID.ParameterName = "@ReasonID";
        sqlCmd.Parameters.Add(ReasonID);

        SqlParameter ReasonType = new SqlParameter();
        ReasonType.SqlDbType = SqlDbType.NVarChar;
        ReasonType.Value = ddlReasonType.SelectedItem.Value;
        ReasonType.ParameterName = "@Type";
        sqlCmd.Parameters.Add(ReasonType);

        SqlParameter ReasonCode = new SqlParameter();
        ReasonCode.SqlDbType = SqlDbType.NVarChar;
        ReasonCode.Value = txtReasoncode.Text.Trim();
        ReasonCode.ParameterName = "@ReasonCode";
        sqlCmd.Parameters.Add(ReasonCode);

        SqlParameter ReasonName = new SqlParameter();
        ReasonName.SqlDbType = SqlDbType.NVarChar;
        ReasonName.Value = txtReasonName.Text.Trim();
        ReasonName.ParameterName = "@ReasonName";
        sqlCmd.Parameters.Add(ReasonName);


        SqlParameter flag = new SqlParameter();
        flag.SqlDbType = SqlDbType.NVarChar;
        flag.Value = ddlFlag.SelectedItem.Value;
        flag.ParameterName = "@flag";
        sqlCmd.Parameters.Add(flag);

        SqlParameter Is_Active = new SqlParameter();
        Is_Active.SqlDbType = SqlDbType.Bit;
        Is_Active.Value = Convert.ToBoolean(ddlIsActive.SelectedItem.Value);
        Is_Active.ParameterName = "@Is_Active";
        sqlCmd.Parameters.Add(Is_Active);


        int SqlRow = 0;
        SqlRow = sqlCmd.ExecuteNonQuery();

        if (SqlRow > 0)
        {
            lblMessage.Text = "Update Successfully!";
            lblMessage.CssClass = "UpdateMessage";
            lblMessage.Visible = true;
        }
    }

    protected void Clear_textfield()
    {
        hdnReasonId.Value = "0";
        ddlReasonType.SelectedIndex = 0;
        txtReasoncode.Text = "";
        txtReasonName.Text = "";
        ddlFlag.SelectedIndex = 0;
        ddlIsActive.SelectedIndex =0;
     } 

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Pages/Menu.aspx", true);
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        Clear_textfield();
    }
}
