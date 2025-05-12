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

public partial class Pages_Calculus_DropBox_Master : System.Web.UI.Page
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
                Get_BranchData();
                Get_GridDropBoxInfo();
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
    private void Register_Validation()
    {
        btnSave.Attributes.Add("onclick", "javascript:return ValidationAllField();");

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

    private void Get_GridDropBoxInfo()
    {
        try
        {
            Object SaveUSERInfo = (Object)Session["UserInfo"];

            SqlConnection SqlCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);


            SqlCommand SqlCmd = new SqlCommand();
            SqlCmd.Connection = SqlCon;
            SqlCmd.CommandType = CommandType.StoredProcedure;
            SqlCmd.CommandText = "CommonMaster_Get_DropBoxData_SP";
            SqlCmd.CommandTimeout = 0;


            SqlParameter BranchId = new SqlParameter();
            BranchId.SqlDbType = SqlDbType.Int;
            BranchId.Value = Convert.ToInt32(((UserInfo.structUSERInfo)(SaveUSERInfo)).BranchId);
            BranchId.ParameterName = "@BranchID";
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

    protected void Gv_Search_RowDataBound(object sender,GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Attributes.Add("onclick", "javascript:GV_RowSelection('" + e.Row.RowIndex + "','" + e.Row.Cells[0].Text + "');");
           
            
        }

    }


 
    protected void btnSave_Click(object sender, EventArgs e)
    {
        Insert_DropBoxData();
        Get_GridDropBoxInfo();
        Clear_textfield();
        
    }

    protected void Insert_DropBoxData()
    {
        Object SaveUSERInfo = (Object)Session["UserInfo"];

        using (SqlConnection sqlCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]))
        {
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.Connection = sqlCon;
            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCmd.CommandText = "CommonMaster_Insert_DropBoxInfo_SP";
            sqlCmd.CommandTimeout = 0;

            SqlParameter DropBoxId = new SqlParameter();
            DropBoxId.SqlDbType = SqlDbType.Int;
            DropBoxId.Value = hdnDropBoxId.Value;
            DropBoxId.ParameterName = "@DropBoxId";
            sqlCmd.Parameters.Add(DropBoxId);

            SqlParameter BranchID = new SqlParameter();
            BranchID.SqlDbType = SqlDbType.VarChar;
            BranchID.Value = ddlBranchName.SelectedItem.Value;
            BranchID.ParameterName = "@BranchID";
            sqlCmd.Parameters.Add(BranchID);

            SqlParameter Location = new SqlParameter();
            Location.SqlDbType = SqlDbType.VarChar;
            Location.Value = txtLocation.Text.Trim();
            Location.ParameterName = "@Location";
            sqlCmd.Parameters.Add(Location);

            SqlParameter DropBox_Code = new SqlParameter();
            DropBox_Code.SqlDbType = SqlDbType.VarChar;
            DropBox_Code.Value = txtDropCode.Text.Trim();
            DropBox_Code.ParameterName = "@DropBox_Code";
            sqlCmd.Parameters.Add(DropBox_Code);

            SqlParameter DropBox_Name = new SqlParameter();
            DropBox_Name.SqlDbType = SqlDbType.VarChar;
            DropBox_Name.Value = txtDropBoxName.Text.Trim();
            DropBox_Name.ParameterName = "@DropBox_Name";
            sqlCmd.Parameters.Add(DropBox_Name);

            SqlParameter Contact_Person = new SqlParameter();
            Contact_Person.SqlDbType = SqlDbType.VarChar;
            Contact_Person.Value = txtContactPerson.Text.Trim();
            Contact_Person.ParameterName = "@Contact_Person";
            sqlCmd.Parameters.Add(Contact_Person);

            SqlParameter Address_Line1 = new SqlParameter();
            Address_Line1.SqlDbType = SqlDbType.VarChar;
            Address_Line1.Value = txtAddress1.Text.Trim();
            Address_Line1.ParameterName = "@Address_Line1";
            sqlCmd.Parameters.Add(Address_Line1);

            SqlParameter Address_line2 = new SqlParameter();
            Address_line2.SqlDbType = SqlDbType.VarChar;
            Address_line2.Value = txtAddress2.Text.Trim();
            Address_line2.ParameterName = "@Address_line2";
            sqlCmd.Parameters.Add(Address_line2);

            SqlParameter City = new SqlParameter();
            City.SqlDbType = SqlDbType.VarChar;
            City.Value = txtcity.Text.Trim();
            City.ParameterName = "@City";
            sqlCmd.Parameters.Add(City);

            SqlParameter Pincode = new SqlParameter();
            Pincode.SqlDbType = SqlDbType.VarChar;
            Pincode.Value = txtPincode.Text.Trim();
            Pincode.ParameterName = "@Pincode";
            sqlCmd.Parameters.Add(Pincode);

            SqlParameter PhoneNo = new SqlParameter();
            PhoneNo.SqlDbType = SqlDbType.VarChar;
            PhoneNo.Value = txtPhoneNo.Text.Trim();
            PhoneNo.ParameterName = "@PhoneNo";
            sqlCmd.Parameters.Add(PhoneNo);

            SqlParameter Remark = new SqlParameter();
            Remark.SqlDbType = SqlDbType.VarChar;
            Remark.Value = txtRemark.Text.Trim();
            Remark.ParameterName = "@Remark";
            sqlCmd.Parameters.Add(Remark);

            SqlParameter Is_Active = new SqlParameter();
            Is_Active.SqlDbType = SqlDbType.Bit;
            Is_Active.Value = Convert.ToBoolean(ddlIsActive.SelectedItem.Value);
            Is_Active.ParameterName = "@Is_Active";
            sqlCmd.Parameters.Add(Is_Active);

            SqlParameter RightsBy = new SqlParameter();
            RightsBy.SqlDbType = SqlDbType.VarChar;
            RightsBy.Value = Convert.ToString(((UserInfo.structUSERInfo)(SaveUSERInfo)).UserId);
            RightsBy.ParameterName = "@RightsBy";
            sqlCmd.Parameters.Add(RightsBy);

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
            hdnDropBoxId.Value = "0";
            ddlBranchName.SelectedIndex = 0;
            txtLocation.Text = "";
            txtDropBoxName.Text = "";
            txtDropCode.Text = "";
            txtContactPerson.Text = "";
            txtAddress1.Text = "";
            txtAddress2.Text = "";
            txtcity.Text = "";
            txtPincode.Text = "";
            txtPhoneNo.Text = "";
            txtRemark.Text = "";
            ddlIsActive.SelectedIndex = 0;
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
