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
public partial class Pages_Helpdesk_TicketAssignment : System.Web.UI.Page
{
    string UserRemarkValue = "";  //add on 19/01/2024
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Get_BranchId();
            Get_ProblemTypeInfo();
            Get_SupportEngineerList();
            Get_ProblemDetailInfo(0);
            BindTicketStatus();
        }
    }
    protected void BindTicketStatus()
    {
        SqlConnection sqlCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);

        SqlCommand cmd = new SqlCommand("HelpDesk_SearchCodeMaster_SP", sqlCon);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@Types", "HDTicketStatusType");
        cmd.Parameters.AddWithValue("@Level", 1);
        SqlDataAdapter adp = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        adp.Fill(ds);

        if (ds != null && ds.Tables[0].Rows.Count > 0)
        {
            ddlTicketStatus.DataSource = ds;
            ddlTicketStatus.DataValueField = "Code_Id";
            ddlTicketStatus.DataTextField = "Description";
            ddlTicketStatus.DataBind();
            ddlTicketStatus.Items.Insert(0, new ListItem("--Select--", "0"));
        }

    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Pages/Menu.aspx", true);
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        Get_ReqeustedTicket_For_Assignment(false);
    }

    public void GetUserRemark() //add on 19/01/2024
    {
        for (int i = 0; i <= grv_TicketList.Rows.Count - 1; i++)
        {
            TextBox txtUserRemark = (TextBox)grv_TicketList.Rows[i].FindControl("UserRemark"); //add on 19/01/24
            UserRemarkValue = txtUserRemark.Text.Trim();
        }
    }
    private void Get_ReqeustedTicket_For_Assignment(Boolean isExport)
    {
        Object SaveUSERInfo = (Object)Session["UserInfo"];
        SqlConnection sqlCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);

        sqlCon.Open();


        string ab = Convert.ToString(((UserInfo.structUSERInfo)(SaveUSERInfo)).UserId);

        if (ab == "server.support")
        {

            SqlCommand sqlCom = new SqlCommand();
            sqlCom.Connection = sqlCon;
            sqlCom.CommandType = CommandType.StoredProcedure;
            sqlCom.CommandText = "HelpDesk_GetReqeustedTicketForAssignment123_SP";
            SqlDataAdapter sqlDA = new SqlDataAdapter();
            sqlDA.SelectCommand = sqlCom;

            int intBranchID = 0;

            if (ddlBranchList.SelectedIndex != 0)
            {
                intBranchID = Convert.ToInt32(ddlBranchList.SelectedItem.Value);
            }

            SqlParameter BranchID = new SqlParameter();
            BranchID.SqlDbType = SqlDbType.Int;
            BranchID.Value = intBranchID; //Convert.ToInt32(((UserInfo.structUSERInfo)(SaveUSERInfo)).BranchId);
            BranchID.ParameterName = "@BranchID";
            sqlCom.Parameters.Add(BranchID);

            SqlParameter TicketNo = new SqlParameter();
            TicketNo.SqlDbType = SqlDbType.VarChar;
            TicketNo.Value = txtTicketNo.Text.Trim();
            TicketNo.ParameterName = "@TicketNo";
            sqlCom.Parameters.Add(TicketNo);

            SqlParameter Department = new SqlParameter();
            Department.SqlDbType = SqlDbType.VarChar;
            Department.Value = txtDepartment.Text.Trim();
            Department.ParameterName = "@Department";
            sqlCom.Parameters.Add(Department);




            int intPromblemTypeID = 0;
            if (ddlProblemTypeList.SelectedIndex != 0)
            {
                intPromblemTypeID = Convert.ToInt32(ddlProblemTypeList.SelectedItem.Value);
            }

            SqlParameter PromblemTypeID = new SqlParameter();
            PromblemTypeID.SqlDbType = SqlDbType.Int;
            PromblemTypeID.Value = intPromblemTypeID;
            PromblemTypeID.ParameterName = "@PromblemTypeID";
            sqlCom.Parameters.Add(PromblemTypeID);

            int intProblemDetailID = 0;
            if (ddlProblemDetailList.SelectedIndex != 0)
            {
                intProblemDetailID = Convert.ToInt32(ddlProblemDetailList.SelectedItem.Value);
            }
            SqlParameter ProblemDetailID = new SqlParameter();
            ProblemDetailID.SqlDbType = SqlDbType.Int;
            ProblemDetailID.Value = intProblemDetailID;
            ProblemDetailID.ParameterName = "@ProblemDetailID";
            sqlCom.Parameters.Add(ProblemDetailID);

            SqlParameter FromDate = new SqlParameter();
            FromDate.SqlDbType = SqlDbType.VarChar;
            FromDate.Value = txtRequestFromDate.Text.Trim();
            FromDate.ParameterName = "@FromDate";
            sqlCom.Parameters.Add(FromDate);

            SqlParameter ToDate = new SqlParameter();
            ToDate.SqlDbType = SqlDbType.VarChar;
            ToDate.Value = txtRequestToDate.Text.Trim();
            ToDate.ParameterName = "@ToDate";
            sqlCom.Parameters.Add(ToDate);

            string strTicketStatus = "";

            if (ddlTicketStatus.SelectedItem.Value.ToString() != "0")
            {
                strTicketStatus = ddlTicketStatus.SelectedItem.Value.ToString();
            }

            SqlParameter TicketStatus = new SqlParameter();
            TicketStatus.SqlDbType = SqlDbType.VarChar;
            TicketStatus.Value = strTicketStatus;
            TicketStatus.ParameterName = "@TicketStatus";
            sqlCom.Parameters.Add(TicketStatus);

            SqlParameter RequestBy = new SqlParameter();
            RequestBy.SqlDbType = SqlDbType.VarChar;
            RequestBy.Value = txtRequestBy.Text.Trim();
            RequestBy.ParameterName = "@RequestBy";
            sqlCom.Parameters.Add(RequestBy);

            string strAssignedBy = "";
            if (ddlAssignedBy.SelectedIndex != 0)
            {
                strAssignedBy = ddlAssignedBy.SelectedItem.Value.Trim();
            }

            SqlParameter AssignedBY = new SqlParameter();
            AssignedBY.SqlDbType = SqlDbType.VarChar;
            AssignedBY.Value = strAssignedBy;
            AssignedBY.ParameterName = "@AssignedBY";
            sqlCom.Parameters.Add(AssignedBY);

            string strAssignedTo = "";
            if (ddlAssignedTo.SelectedIndex != 0)
            {
                strAssignedTo = ddlAssignedTo.SelectedItem.Value.Trim();
            }


            SqlParameter AssignedTo = new SqlParameter();
            AssignedTo.SqlDbType = SqlDbType.VarChar;
            AssignedTo.Value = strAssignedTo;
            AssignedTo.ParameterName = "@AssignedTo";
            sqlCom.Parameters.Add(AssignedTo);


            //TextBox txtUserRemark = (TextBox)grv_TicketList.Rows[0].FindControl("UserRemark"); //add on 19/01/24
            //UserRemarkValue = txtUserRemark.Text.Trim();

            SqlParameter UserRemark = new SqlParameter(); //add on 19/01/24
            UserRemark.SqlDbType = SqlDbType.VarChar;
            UserRemark.Value = UserRemarkValue.Trim();
            UserRemark.ParameterName = "@UserRemark";
            sqlCom.Parameters.Add(UserRemark);

            DataTable dt = new DataTable();
            sqlDA.Fill(dt);
            sqlCon.Close();

            if (dt.Rows.Count > 0)
            {
                if (isExport == true)
                {
                    GridView1.DataSource = dt;
                    GridView1.DataBind();
                }
                else
                {
                    grv_TicketList.DataSource = dt;
                    grv_TicketList.DataBind();
                }
                lblMessage.Text = "Total Records founds:" + dt.Rows.Count;
                lblMessage.CssClass = "SuccessMessage";

            }
            else
            {
                if (isExport == true)
                {
                    GridView1.DataSource = dt;
                    GridView1.DataBind();
                }
                else
                {
                    grv_TicketList.DataSource = null;
                    grv_TicketList.DataBind();
                }
                lblMessage.Text = "No Records found!";
                lblMessage.CssClass = "ErrorMessage";
            }
        }
        else
        {
            SqlCommand sqlCom = new SqlCommand();
            sqlCom.Connection = sqlCon;
            sqlCom.CommandType = CommandType.StoredProcedure;
            sqlCom.CommandText = "HelpDesk_GetReqeustedTicketForAssignment_SP";
            SqlDataAdapter sqlDA = new SqlDataAdapter();
            sqlDA.SelectCommand = sqlCom;

            int intBranchID = 0;

            if (ddlBranchList.SelectedIndex != 0)
            {
                intBranchID = Convert.ToInt32(ddlBranchList.SelectedItem.Value);
            }

            SqlParameter BranchID = new SqlParameter();
            BranchID.SqlDbType = SqlDbType.Int;
            BranchID.Value = intBranchID; //Convert.ToInt32(((UserInfo.structUSERInfo)(SaveUSERInfo)).BranchId);
            BranchID.ParameterName = "@BranchID";
            sqlCom.Parameters.Add(BranchID);

            SqlParameter TicketNo = new SqlParameter();
            TicketNo.SqlDbType = SqlDbType.VarChar;
            TicketNo.Value = txtTicketNo.Text.Trim();
            TicketNo.ParameterName = "@TicketNo";
            sqlCom.Parameters.Add(TicketNo);

            SqlParameter Department = new SqlParameter();
            Department.SqlDbType = SqlDbType.VarChar;
            Department.Value = txtDepartment.Text.Trim();
            Department.ParameterName = "@Department";
            sqlCom.Parameters.Add(Department);




            int intPromblemTypeID = 0;
            if (ddlProblemTypeList.SelectedIndex != 0)
            {
                intPromblemTypeID = Convert.ToInt32(ddlProblemTypeList.SelectedItem.Value);
            }

            SqlParameter PromblemTypeID = new SqlParameter();
            PromblemTypeID.SqlDbType = SqlDbType.Int;
            PromblemTypeID.Value = intPromblemTypeID;
            PromblemTypeID.ParameterName = "@PromblemTypeID";
            sqlCom.Parameters.Add(PromblemTypeID);

            int intProblemDetailID = 0;
            if (ddlProblemDetailList.SelectedIndex != 0)
            {
                intProblemDetailID = Convert.ToInt32(ddlProblemDetailList.SelectedItem.Value);
            }
            SqlParameter ProblemDetailID = new SqlParameter();
            ProblemDetailID.SqlDbType = SqlDbType.Int;
            ProblemDetailID.Value = intProblemDetailID;
            ProblemDetailID.ParameterName = "@ProblemDetailID";
            sqlCom.Parameters.Add(ProblemDetailID);

            SqlParameter FromDate = new SqlParameter();
            FromDate.SqlDbType = SqlDbType.VarChar;
            FromDate.Value = txtRequestFromDate.Text.Trim();
            FromDate.ParameterName = "@FromDate";
            sqlCom.Parameters.Add(FromDate);

            SqlParameter ToDate = new SqlParameter();
            ToDate.SqlDbType = SqlDbType.VarChar;
            ToDate.Value = txtRequestToDate.Text.Trim();
            ToDate.ParameterName = "@ToDate";
            sqlCom.Parameters.Add(ToDate);

            string strTicketStatus = "";

            if (ddlTicketStatus.SelectedItem.Value.ToString() != "0")
            {
                strTicketStatus = ddlTicketStatus.SelectedItem.Value.ToString();
            }

            SqlParameter TicketStatus = new SqlParameter();
            TicketStatus.SqlDbType = SqlDbType.VarChar;
            TicketStatus.Value = strTicketStatus;
            TicketStatus.ParameterName = "@TicketStatus";
            sqlCom.Parameters.Add(TicketStatus);

            SqlParameter RequestBy = new SqlParameter();
            RequestBy.SqlDbType = SqlDbType.VarChar;
            RequestBy.Value = txtRequestBy.Text.Trim();
            RequestBy.ParameterName = "@RequestBy";
            sqlCom.Parameters.Add(RequestBy);

            string strAssignedBy = "";
            if (ddlAssignedBy.SelectedIndex != 0)
            {
                strAssignedBy = ddlAssignedBy.SelectedItem.Value.Trim();
            }

            SqlParameter AssignedBY = new SqlParameter();
            AssignedBY.SqlDbType = SqlDbType.VarChar;
            AssignedBY.Value = strAssignedBy;
            AssignedBY.ParameterName = "@AssignedBY";
            sqlCom.Parameters.Add(AssignedBY);

            string strAssignedTo = "";
            if (ddlAssignedTo.SelectedIndex != 0)
            {
                strAssignedTo = ddlAssignedTo.SelectedItem.Value.Trim();
            }


            SqlParameter AssignedTo = new SqlParameter();
            AssignedTo.SqlDbType = SqlDbType.VarChar;
            AssignedTo.Value = strAssignedTo;
            AssignedTo.ParameterName = "@AssignedTo";
            sqlCom.Parameters.Add(AssignedTo);

            //TextBox txtUserRemark = (TextBox)grv_TicketList.Rows[0].FindControl("UserRemark"); //add on 19/01/24
            //UserRemarkValue = txtUserRemark.Text.Trim();
            //GetUserRemark(); //add on 19/01/24

            SqlParameter UserRemark = new SqlParameter(); //add on 19/01/24
            UserRemark.SqlDbType = SqlDbType.VarChar;
            UserRemark.Value = UserRemarkValue.Trim();
            UserRemark.ParameterName = "@UserRemark";
            sqlCom.Parameters.Add(UserRemark);

            DataTable dt = new DataTable();
            sqlDA.Fill(dt);
            sqlCon.Close();

            if (dt.Rows.Count > 0)
            {
                if (isExport == true)
                {
                    GridView1.DataSource = dt;
                    GridView1.DataBind();
                }
                else
                {
                    grv_TicketList.DataSource = dt;
                    grv_TicketList.DataBind();
                }
                lblMessage.Text = "Total Records founds:" + dt.Rows.Count;
                lblMessage.CssClass = "SuccessMessage";

            }
            else
            {
                if (isExport == true)
                {
                    GridView1.DataSource = dt;
                    GridView1.DataBind();
                }
                else
                {
                    grv_TicketList.DataSource = null;
                    grv_TicketList.DataBind();
                }
                lblMessage.Text = "No Records found!";
                lblMessage.CssClass = "ErrorMessage";
            }




        }

    }
    private void Get_ProblemTypeInfo()
    {
        try
        {

            SqlConnection sqlCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);

            sqlCon.Open();
            SqlCommand sqlCom = new SqlCommand();
            sqlCom.Connection = sqlCon;
            sqlCom.CommandType = CommandType.StoredProcedure;
            sqlCom.CommandText = "HelpDesk_GetProblemTypeInfo_SP";
            SqlDataAdapter sqlDA = new SqlDataAdapter();
            sqlDA.SelectCommand = sqlCom;


            SqlParameter IsActive = new SqlParameter();
            IsActive.SqlDbType = SqlDbType.Bit;
            IsActive.Value = true;
            IsActive.ParameterName = "@IsActive";
            sqlCom.Parameters.Add(IsActive);

            DataTable dt = new DataTable();
            sqlDA.Fill(dt);
            sqlCon.Close();

            ddlProblemTypeList.DataTextField = "ProblemTypeName";
            ddlProblemTypeList.DataValueField = "ProblemTypeID";
            ddlProblemTypeList.DataSource = dt;
            ddlProblemTypeList.DataBind();

            ddlProblemTypeList.Items.Insert(0, "--Select--");
            ddlProblemTypeList.SelectedIndex = 0;



        }
        catch (Exception ex)
        {
            lblMessage.Visible = true;
            lblMessage.Text = ex.Message;
            lblMessage.CssClass = "ErrorMessage";
        }
    }
    private void Get_ProblemDetailInfo(int intProblemType)
    {
        try
        {

            SqlConnection sqlCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);

            sqlCon.Open();
            SqlCommand sqlCom = new SqlCommand();
            sqlCom.Connection = sqlCon;
            sqlCom.CommandType = CommandType.StoredProcedure;
            sqlCom.CommandText = "HelpDesk_GetProblemDetailInfo_SP";
            SqlDataAdapter sqlDA = new SqlDataAdapter();
            sqlDA.SelectCommand = sqlCom;

            SqlParameter ProblemTypeID = new SqlParameter();
            ProblemTypeID.SqlDbType = SqlDbType.Int;
            ProblemTypeID.Value = intProblemType;
            ProblemTypeID.ParameterName = "@ProblemTypeID";
            sqlCom.Parameters.Add(ProblemTypeID);

            DataTable dt = new DataTable();
            sqlDA.Fill(dt);
            sqlCon.Close();

            ddlProblemDetailList.DataTextField = "ProblemDetailsName";
            ddlProblemDetailList.DataValueField = "ProblemDetailID";
            ddlProblemDetailList.DataSource = dt;
            ddlProblemDetailList.DataBind();

            ddlProblemDetailList.Items.Insert(0, "--Select--");
            ddlProblemDetailList.SelectedIndex = 0;



        }
        catch (Exception ex)
        {
            lblMessage.Visible = true;
            lblMessage.Text = ex.Message;
            lblMessage.CssClass = "ErrorMessage";
        }
    }
    protected void ddlProblemTypeList_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlProblemTypeList.SelectedIndex != 0)
        {
            Get_ProblemDetailInfo(Convert.ToInt32(ddlProblemTypeList.SelectedItem.Value));
        }
    }
    private void Get_BranchId()
    {
        try
        {
            SqlConnection sqlcon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);

            sqlcon.Open();
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlcon;
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.CommandText = "Get_AllBranchList";
            SqlDataAdapter sqlda = new SqlDataAdapter();
            sqlda.SelectCommand = sqlcmd;
            DataTable dt = new DataTable();
            sqlda.Fill(dt);
            sqlcon.Close();

            ddlBranchList.DataTextField = "BranchName";
            ddlBranchList.DataValueField = "BranchId";
            ddlBranchList.DataSource = dt;
            ddlBranchList.DataBind();

            ddlBranchList.Items.Insert(0, "-Select-");
            ddlBranchList.SelectedIndex = 0;

        }
        catch (Exception ex)
        {
            lblMessage.Visible = true;
            lblMessage.Text = ex.Message;
            lblMessage.CssClass = "ErrorMessage";

        }

    }
    protected void lnkTicketNo_Click(object sender, EventArgs e)
    {
        string TicketNo = ((System.Web.UI.WebControls.LinkButton)(sender)).Text.ToString();
        if (TicketNo != "")
        {
            Response.Redirect("~/Pages/Helpdesk/TicketStatus.aspx?Tk=" + TicketNo.Trim(), true);
            //    function openwindow()
            //{        
            //    window.open('ViewOpeningBalanceByBranch.aspx', '_blank', 'height=350,width=700,status=yes,resizable=yes');
            //} 
        }

    }
    private void DownloadFile(string fname, bool forceDownload)
    {
        try
        {
            string path = fname;
            string name = Path.GetFileName(path);
            string ext = Path.GetExtension(path);
            string type = "";
            // set known types based on file extension  
            if (ext != null)
            {
                switch (ext.ToLower())
                {

                    case ".txt":
                        type = "text/plain";
                        break;

                    case ".doc":
                    case ".rtf":
                        type = "Application/msword";
                        break;
                    case ".zip":
                        type = "application/zip";
                        break;
                    case ".xls":
                        type = "application/vnd.ms-excel";
                        break;
                }
            }
            if (forceDownload)
            {
                Response.AppendHeader("content-disposition",
                    "attachment; filename=" + name);
            }
            if (type != "")
                Response.ContentType = type;
            Response.WriteFile(path);
            Response.End();
        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
            lblMessage.CssClass = "ErrorMessage";
        }
    }
    protected void lnkDownloadFile_Click(object sender, EventArgs e)
    {
        string DownloadPath = ((System.Web.UI.WebControls.LinkButton)(sender)).CommandArgument.ToString();
        if (DownloadPath != "")
        {
            DownloadFile(DownloadPath, true);
        }
        else
        {
            lblMessage.Text = "No Attach document found!";
        }
    }
    protected void grv_TicketList_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {

            LinkButton lnkDownloadFile = (LinkButton)e.Row.FindControl("lnkDownloadFile");
            if (lnkDownloadFile.CommandArgument == "")
            {
                lnkDownloadFile.Enabled = false;
                lnkDownloadFile.ToolTip = "No Attachment found!";
            }

        }
    }
    private void Get_SupportEngineerList()
    {
        try
        {

            SqlConnection sqlCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);

            sqlCon.Open();
            SqlCommand sqlCom = new SqlCommand();
            sqlCom.Connection = sqlCon;
            sqlCom.CommandType = CommandType.StoredProcedure;
            sqlCom.CommandText = "HelpDesk_GetSupportEngineerList_SP";
            SqlDataAdapter sqlDA = new SqlDataAdapter();
            sqlDA.SelectCommand = sqlCom;


            DataTable dt = new DataTable();
            sqlDA.Fill(dt);
            sqlCon.Close();

            ddlAssignedTo.DataTextField = "UserName";
            ddlAssignedTo.DataValueField = "UserID";
            ddlAssignedTo.DataSource = dt;
            ddlAssignedTo.DataBind();

            ddlAssignedTo.Items.Insert(0, "--Select--");
            ddlAssignedTo.SelectedIndex = 0;

            ddlAssignedBy.DataTextField = "UserName";
            ddlAssignedBy.DataValueField = "UserID";
            ddlAssignedBy.DataSource = dt;
            ddlAssignedBy.DataBind();

            ddlAssignedBy.Items.Insert(0, "--Select--");
            ddlAssignedBy.SelectedIndex = 0;


        }
        catch (Exception ex)
        {
            lblMessage.Visible = true;
            lblMessage.Text = ex.Message;
            lblMessage.CssClass = "ErrorMessage";
        }
    }

    private void Generate_ExcelFile()
    {
        String attachment = "attachment; filename=TicketAssignmentReport.xls";
        Response.AddHeader("content-disposition", attachment);
        Response.ContentType = "application/ms-excel";
        StringWriter sw = new System.IO.StringWriter();
        HtmlTextWriter htw = new HtmlTextWriter(sw);
        Table tblSpace = new Table();
        TableRow tblRow = new TableRow();
        TableCell tblCell = new TableCell();
        tblCell.Text = " ";

        TableRow tblRow1 = new TableRow();
        TableCell tblCell1 = new TableCell();
        tblCell1.ColumnSpan = 20;// 10;
        tblCell1.Text = "<b> <span style='background-color:Gray'> <font size='4'>PAMAC FINSERVE PVT. LTD., Branch-" + ddlBranchList.SelectedItem.Text + " </font></span></b> <br/>" +
                        "<b><font size='2' color='blue'>Ticket Assignment Report   </font></b> <br/>";
        tblCell1.CssClass = "SuccessMessage";
        tblRow.Cells.Add(tblCell);
        tblRow1.Cells.Add(tblCell1);
        tblRow.Height = 20;
        tblSpace.Rows.Add(tblRow);
        tblSpace.Rows.Add(tblRow1);
        tblSpace.RenderControl(htw);

        Table tbl = new Table();
        grv_TicketList.EnableViewState = false;
        grv_TicketList.GridLines = GridLines.Both;
        tbExport.RenderControl(htw);
        Response.Write(sw.ToString());

        Response.End();
    }
    protected void btnExport_Click(object sender, EventArgs e)
    {
        Get_ReqeustedTicket_For_Assignment(true);
        Generate_ExcelFile();
    }

    public override void VerifyRenderingInServerForm(Control control)
    {

    }



}
