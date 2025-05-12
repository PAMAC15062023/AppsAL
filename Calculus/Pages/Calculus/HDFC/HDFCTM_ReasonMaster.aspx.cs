using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class Pages_Calculus_HDFC_HDFCTM_ReasonMaster : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Object SaveUSERInfo = (Object)Session["UserInfo"];
            int GroupId = Convert.ToInt32(((UserInfo.structUSERInfo)(SaveUSERInfo)).GroupId);

            if (GroupId == 236)
            {
                HDFCTM_Reason();
            }
            else
            {
                Response.Redirect("~/Pages/Menu.aspx", true);
            }
        }
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Pages/Menu.aspx", true);
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (txtReason.Text.Trim() == "")
        {
            lblMessage.Text = "Reason cannot be left blank !";
            return;
        }

        HDFCTM_InsertReason();
        HDFCTM_Reason();
        ClearDate();
    }

    private void HDFCTM_InsertReason()
    {
        Object SaveUSERInfo = (Object)Session["UserInfo"];
        SqlConnection sqlCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);

        sqlCon.Open();
        SqlCommand sqlCmd = new SqlCommand();
        sqlCmd.Connection = sqlCon;
        sqlCmd.CommandType = CommandType.StoredProcedure;
        sqlCmd.CommandText = "HDFCTM_Insert_SP";

        SqlParameter ReasonID = new SqlParameter();
        ReasonID.SqlDbType = SqlDbType.Int;
        ReasonID.Value = hdnReasonId.Value;
        ReasonID.ParameterName = "@ID";
        sqlCmd.Parameters.Add(ReasonID);

        SqlParameter Reason = new SqlParameter();
        Reason.SqlDbType = SqlDbType.NVarChar;
        Reason.Value = txtReason.Text.Trim();
        Reason.ParameterName = "@Reason";
        sqlCmd.Parameters.Add(Reason);

        SqlParameter Is_Active = new SqlParameter();
        Is_Active.SqlDbType = SqlDbType.Int;
        Is_Active.Value = chkactive.Checked;
        Is_Active.ParameterName = "@Is_Active";
        sqlCmd.Parameters.Add(Is_Active);

        SqlParameter Userid = new SqlParameter();
        Userid.SqlDbType = SqlDbType.VarChar;
        Userid.Value = Convert.ToString(((UserInfo.structUSERInfo)(SaveUSERInfo)).UserId);
        Userid.ParameterName = "@UserId";
        sqlCmd.Parameters.Add(Userid);

        int SqlRow = 0;
        SqlRow = sqlCmd.ExecuteNonQuery();

        if (SqlRow > 0)
        {
            HDFCTM_Reason();
            if (hdnReasonId.Value == "0")
            {
                lblMessage.Text = "Inserted Successfully!";

            }
            else
            {
                lblMessage.Text = "Updated Successfully!";

            }
            lblMessage.CssClass = "UpdateMessage";
            lblMessage.Visible = true;

        }
    }
    protected void ClearDate()
    {
        txtReason.Text = "";
        chkactive.Checked = false;
        hdnReasonId.Value = "0";
    }

    protected void HDFCTM_Reason()
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

            Gridview_HDFCTM.DataSource = ds;
            Gridview_HDFCTM.DataBind();
        }
        catch (Exception ex)
        {
            ex.ToString();
        }
    }
    protected void btn_Edit_Click(object sender, EventArgs e)
    {
        Button btn = (Button)sender;
        GridViewRow gr = (GridViewRow)btn.NamingContainer;
        int index = gr.RowIndex;

        Button LinkBtn = (Button)Gridview_HDFCTM.Rows[index].FindControl("btn_Edit");
        CheckBox chkSelect = (CheckBox)Gridview_HDFCTM.Rows[index].FindControl("chkactive");
        hdnReasonId.Value = Gridview_HDFCTM.Rows[index].Cells[0].Text.Trim();

        txtReason.Text = Gridview_HDFCTM.Rows[index].Cells[1].Text.Trim();

        string data = Gridview_HDFCTM.Rows[index].Cells[2].Text.Trim();

        chkactive.Checked = false;

        if (data == "Yes")
        {
            chkactive.Checked = true;
        }
    }
}