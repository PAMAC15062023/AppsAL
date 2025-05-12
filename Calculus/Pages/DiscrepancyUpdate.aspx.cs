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
using System.Web.SessionState;

public partial class Pages_DiscrepancyUpdate : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserInfo"] == null)
        {
            Response.Redirect("InvalidRequest.aspx", false);
        }

        
        if (!IsPostBack)
        {
            Get_DiscrepancyList();
            ddlDiscrepancy.Attributes.Add("onchange", "javascript:return Check_Discrepancy();");
          
              if ((Request.QueryString["ApplicationNo"] != null) && (Request.QueryString["PUID"] != null))
            {
                txtNanoApplicationNo.Text = Convert.ToString(Request.QueryString["ApplicationNo"]);
               // txtPUId.Text = Convert.ToString(Request.QueryString["PUID"]);
                if (txtNanoApplicationNo.Text != "")
                {
                    hdnNanoApplicationNO.Value = txtNanoApplicationNo.Text.Trim();
                    Get_Application_DiscrepancyInfo();
                }

             }
        }   
     
    }
     
    private void Get_DiscrepancyList()
    {
        try
        {

            SqlConnection sqlCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);

            sqlCon.Open();
            SqlCommand sqlCom = new SqlCommand();
            sqlCom.Connection = sqlCon;
            sqlCom.CommandType = CommandType.StoredProcedure;
            sqlCom.CommandText = "Get_AllDiscrepancyList";
            SqlDataAdapter sqlDA = new SqlDataAdapter();
            sqlDA.SelectCommand = sqlCom;
            DataTable dt = new DataTable();
            sqlDA.Fill(dt);
            sqlCon.Close();

            ddlDiscrepancy.DataTextField = "DiscrepancyName";
            ddlDiscrepancy.DataValueField = "DiscrepancyId";
            ddlDiscrepancy.DataSource = dt;
            ddlDiscrepancy.DataBind();

            ddlDiscrepancy.Items.Insert(0, "--Select--");
            ddlDiscrepancy.SelectedIndex = 0;



        }
        catch (Exception ex)
        {
            lblMessage.CssClass = "ErrorMessage";
            lblMessage.Visible = true;
            lblMessage.Text = ex.Message;
        }
    }
    protected void btnRetreive_Click(object sender, EventArgs e)
    {
        hdnNanoApplicationNO.Value = txtNanoApplicationNo.Text.Trim();
        Get_Application_DiscrepancyInfo();


    }

    private void Get_Application_DiscrepancyInfo()
    {
        try
        {

            Object SaveUSERInfo = (Object)Session["UserInfo"];
            SqlConnection sqlCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);

            sqlCon.Open();
            SqlCommand sqlCom = new SqlCommand();
            sqlCom.Connection = sqlCon;
            sqlCom.CommandType = CommandType.StoredProcedure;
            sqlCom.CommandText = "Get_NanoApplicationDetails_for_Discrepancy";



            SqlParameter BranchId = new SqlParameter();
            BranchId.SqlDbType = SqlDbType.Int;
            BranchId.Value = Convert.ToInt32(((UserInfo.structUSERInfo)(SaveUSERInfo)).BranchId);
            BranchId.ParameterName = "@BranchId";
            sqlCom.Parameters.Add(BranchId);


            SqlParameter NanoApplicationNo = new SqlParameter();
            NanoApplicationNo.SqlDbType = SqlDbType.VarChar;
            NanoApplicationNo.Value = txtNanoApplicationNo.Text.Trim();
            NanoApplicationNo.ParameterName = "@NanoApplicationNo";
            sqlCom.Parameters.Add(NanoApplicationNo);

            SqlDataAdapter sqlDA = new SqlDataAdapter();
            sqlDA.SelectCommand = sqlCom;
            DataSet ds = new DataSet();
            sqlDA.Fill(ds);
            sqlCon.Close();
            if (ds.Tables[0].Rows.Count >= 1)
            {
                lblMessage.Visible = false ;
                lblMessage.Text = "";
                pnlAddDiscrepancy.Visible = true;
                grv_ApplicationInfo.DataSource = ds.Tables[0];
                grv_ApplicationInfo.DataBind();

                if (ds.Tables[1].Rows.Count > 0)
                {
                    gridDiscrepancyList.DataSource = ds.Tables[1];
                    gridDiscrepancyList.DataBind();

                }
            }
            else
            {
                pnlAddDiscrepancy.Visible = false; 
                lblMessage.CssClass = "ErrorMessage";
                lblMessage.Visible = true;
                lblMessage.Text = "Record not Found!";

                grv_ApplicationInfo.DataSource = null;
                grv_ApplicationInfo.DataBind();
                gridDiscrepancyList.DataSource = null;
                gridDiscrepancyList.DataBind();

            
            }
        }
        catch (Exception ex)
        {
            lblMessage.CssClass = "ErrorMessage";
            lblMessage.Visible = true;
            lblMessage.Text = ex.Message;
        }
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        try
        {
            Response.Redirect("Menu.aspx", false);
        }
        catch (Exception ex)
        {
            lblMessage.Visible = true;
            lblMessage.Text = ex.Message;
        }
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        try
        {
            Add_Application_DiscrepancyInfo();
        }
        catch (Exception ex)
        {
            lblMessage.CssClass = "ErrorMessage";
            lblMessage.Visible = true;
            lblMessage.Text = ex.Message;
        }
    }

    private void Add_Application_DiscrepancyInfo()
    {
        try
        {
            Object SaveUSERInfo = (Object)Session["UserInfo"];
            SqlConnection sqlCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);

            sqlCon.Open();
            SqlCommand sqlCom = new SqlCommand();
            sqlCom.Connection = sqlCon;
            sqlCom.CommandType = CommandType.StoredProcedure;
            sqlCom.CommandText = "Insert_DiscrepancyTo_Application";

            SqlParameter BranchId = new SqlParameter();
            BranchId.SqlDbType = SqlDbType.Int;
            BranchId.Value = Convert.ToInt32(((UserInfo.structUSERInfo)(SaveUSERInfo)).BranchId);
            BranchId.ParameterName = "@BranchId";
            sqlCom.Parameters.Add(BranchId);

            SqlParameter CreateBy = new SqlParameter();
            CreateBy.SqlDbType = SqlDbType.VarChar;
            CreateBy.Value = Convert.ToString(((UserInfo.structUSERInfo)(SaveUSERInfo)).UserId);
            CreateBy.ParameterName = "@CreateBy";
            sqlCom.Parameters.Add(CreateBy);


            SqlParameter NanoApplicationNo = new SqlParameter();
            NanoApplicationNo.SqlDbType = SqlDbType.VarChar;
            NanoApplicationNo.Value = hdnNanoApplicationNO.Value.Trim();
            NanoApplicationNo.ParameterName = "@NanoApplicationNo";
            sqlCom.Parameters.Add(NanoApplicationNo);

            SqlParameter DiscrepancyId = new SqlParameter();
            DiscrepancyId.SqlDbType = SqlDbType.Int;
            DiscrepancyId.Value = ddlDiscrepancy.SelectedValue;
            DiscrepancyId.ParameterName = "@DiscrepancyId";
            sqlCom.Parameters.Add(DiscrepancyId);

            SqlParameter Remark = new SqlParameter();
            Remark.SqlDbType = SqlDbType.VarChar;
            Remark.Value = txtDiscrepancyRemark.Text.Trim();
            Remark.ParameterName = "@Remark";
            sqlCom.Parameters.Add(Remark);
            int Rows = sqlCom.ExecuteNonQuery();

            if (Rows > 0)
            {
                lblMessage.CssClass = "UpdateMessage";
                lblMessage.Visible = true;
                lblMessage.Text = "Updated Successfully!";
            }
            else
            {
                lblMessage.CssClass = "ErrorMessage";
                lblMessage.Visible = true;
                lblMessage.Text = "Record Aleady Exists/Wrong ApplicationNo Entered!";
            }
            Get_Application_DiscrepancyInfo();


        }
        catch (Exception ex)
        {
            lblMessage.CssClass = "ErrorMessage";
            lblMessage.Visible = true;
            lblMessage.Text = ex.Message;
        }
    }
    protected void lnk_ChangeStatus_Click(object sender, EventArgs e)
    {
       int senderAutoID =Convert.ToInt32(((System.Web.UI.WebControls.LinkButton)(sender)).CommandArgument);
        //Object senderId = (Object)senderId.CommandArgument;
       Update_ApplicationDiscrepancyStatus(senderAutoID);
    }
    private void Update_ApplicationDiscrepancyStatus(int pAutoId)
    {
        try
        {
            Object SaveUSERInfo = (Object)Session["UserInfo"];
            SqlConnection sqlCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);

            sqlCon.Open();
            SqlCommand sqlCom = new SqlCommand();
            sqlCom.Connection = sqlCon;
            sqlCom.CommandType = CommandType.StoredProcedure;
            sqlCom.CommandText = "Update_Discrepancy_Status";

            SqlParameter BranchId = new SqlParameter();
            BranchId.SqlDbType = SqlDbType.Int;
            BranchId.Value = Convert.ToInt32(((UserInfo.structUSERInfo)(SaveUSERInfo)).BranchId);
            BranchId.ParameterName = "@BranchId";
            sqlCom.Parameters.Add(BranchId);

            SqlParameter UpdatedBy = new SqlParameter();
            UpdatedBy.SqlDbType = SqlDbType.VarChar;
            UpdatedBy.Value = Convert.ToString(((UserInfo.structUSERInfo)(SaveUSERInfo)).UserId);
            UpdatedBy.ParameterName = "@UpdatedBy";
            sqlCom.Parameters.Add(UpdatedBy);


            SqlParameter NanoApplicationNo = new SqlParameter();
            NanoApplicationNo.SqlDbType = SqlDbType.VarChar;
            NanoApplicationNo.Value = hdnNanoApplicationNO.Value.Trim();
            NanoApplicationNo.ParameterName = "@NanoApplicationNo";
            sqlCom.Parameters.Add(NanoApplicationNo);

            SqlParameter AutoId = new SqlParameter();
            AutoId.SqlDbType = SqlDbType.Int;
            AutoId.Value = pAutoId;
            AutoId.ParameterName = "@AutoId";
            sqlCom.Parameters.Add(AutoId);

            int Rows = sqlCom.ExecuteNonQuery();

            if (Rows > 0)
            {
                lblMessage.CssClass = "UpdateMessage";
                lblMessage.Visible = true;
                lblMessage.Text = "Updated Successfully!";
            }
            else
            {
                lblMessage.CssClass = "ErrorMessage";
                lblMessage.Visible = true;
                lblMessage.Text = "Record not updated!!!";
            }
            Get_Application_DiscrepancyInfo();


        }
        catch (Exception ex)
        {
            lblMessage.CssClass = "ErrorMessage";
            lblMessage.Visible = true;
            lblMessage.Text = ex.Message;
        }
    }
    
}
