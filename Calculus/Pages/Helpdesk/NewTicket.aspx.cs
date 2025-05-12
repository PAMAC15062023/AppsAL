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


public partial class Pages_Helpdesk_NewTicket : System.Web.UI.Page
{
    string UserRemarkValue = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserInfo"] == null)
        {
            Response.Redirect("~/Pages/InvalidRequest.aspx");
        }

        if (!IsPostBack)
        {
            // fillUserGrid();
            BindDepartment();
            Get_ProblemTypeInfo();
            Get_ProblemDetailInfo(0);
            Register_ControlsWith_JavaScript();

            fillUserGrid(); //add on 16/01/24
            //for (int m = 0; m <= grvUserFill.Rows.Count - 1; m++)  //add on 18/01/24
            //{
            //    if (grvUserFill.Rows[m].Cells[11].Text.ToString().Trim() != "") //(hdnID.Value == grvUserFill.Rows[m].Cells[0].Text)
            //    {
            //        grvUserFill.Rows[m].Cells[11].Text.ToString();
            //    }
            //}

            Object SaveUSERInfo = (Object)Session["UserInfo"];
            txtUserName.Text = Convert.ToString(((UserInfo.structUSERInfo)(SaveUSERInfo)).UserName);

        }

    }

    // edit by sanket

    protected void BindDepartment()
    {
        SqlConnection sqlCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);

        SqlCommand cmd = new SqlCommand("KMPL_SearchCodeMaster_SP", sqlCon);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@Types", "HDDepartmentType");
        cmd.Parameters.AddWithValue("@Level", 1);
        SqlDataAdapter adp = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        adp.Fill(ds);

        if (ds != null && ds.Tables[0].Rows.Count > 0)
        {
            ddlDepartment.DataSource = ds;
            ddlDepartment.DataValueField = "Code_Id";
            ddlDepartment.DataTextField = "Description";
            ddlDepartment.DataBind();
            ddlDepartment.Items.Insert(0, new ListItem("--Select--", "0"));
        }

    }

    private void fillUserGrid()
    {
        Object SaveUSERInfo = (Object)Session["UserInfo"];
        SqlConnection sqlCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);

        sqlCon.Open();
        SqlCommand sqlCom = new SqlCommand();
        sqlCom.Connection = sqlCon;
        sqlCom.CommandType = CommandType.StoredProcedure;
        sqlCom.CommandText = "HelpDesk_GetReqeustedTicketForAssignmentUser_SP";
        sqlCom.CommandTimeout = 0;

        SqlDataAdapter sqlDA = new SqlDataAdapter();
        sqlDA.SelectCommand = sqlCom;

        SqlParameter USERID = new SqlParameter();
        USERID.SqlDbType = SqlDbType.VarChar;
        USERID.Value = Convert.ToString(((UserInfo.structUSERInfo)(SaveUSERInfo)).UserId);
        USERID.ParameterName = "@RequestBy";
        sqlCom.Parameters.Add(USERID);

        SqlParameter BranchID = new SqlParameter();
        BranchID.SqlDbType = SqlDbType.Int;
        BranchID.Value = Convert.ToInt32(((UserInfo.structUSERInfo)(SaveUSERInfo)).BranchId);
        BranchID.ParameterName = "@BranchID";
        sqlCom.Parameters.Add(BranchID);

        //SqlParameter UserRemark = new SqlParameter();
        //UserRemark.SqlDbType = SqlDbType.VarChar;
        //UserRemark.Value = UserRemarkValue.Trim();
        //UserRemark.ParameterName = "@UserRemark";
        //sqlCom.Parameters.Add(UserRemark);

        DataTable dt = new DataTable();
        sqlDA.Fill(dt);
        sqlCon.Close();

        if (dt.Rows.Count > 0)
        {

            //for (int i = 0; i <= dt.Rows.Count - 1; i++)  //add on 18/01/24
            //{
            //    if (dt.Columns[11].ToString().Trim() != "") //(hdnID.Value == grvUserFill.Rows[m].Cells[0].Text)
            //    {
            //        //dt.Columns.Add("UserRemark"); 
            //    }
            //}

            grvUserFill.DataSource = dt;
            grvUserFill.DataBind();

            //for (int i = 0; i <= grvUserFill.Rows.Count - 1; i++)
            //{

            //    for (int a = 0; a < dt.Rows.Count; a++)
            //    {
            //        TextBox UserRemark = (TextBox)grvUserFill.Rows[i].FindControl("UserRemark");
            //        var Mark = dt.Rows[a]["UserRemark"];
            //        UserRemark.Text = Mark.ToString();

            //    }
            //}

            //grvUserFill.DataBind();

            for (int i = 0; i < dt.Rows.Count; i++) // add on 20/01/24
            {
                //if (grvUserFill.Rows[i].Cells[11].Text == "Approve")
                {


                    LinkButton Approve = (LinkButton)grvUserFill.Rows[i].FindControl("Approve");
                    LinkButton Reject = (LinkButton)grvUserFill.Rows[i].FindControl("Reject");
                    CheckBox chkbox = (CheckBox)grvUserFill.Rows[i].FindControl("chkbox"); //add on 13/02/2024
                    TextBox txtUserRemark = (TextBox)grvUserFill.Rows[i].FindControl("UserRemark"); //add on 13/02/2024

                    

                    var TicketStatus = dt.Rows[i]["TicketStatus"];  //add on 13/02/2024 start>>

                    string TS = TicketStatus.ToString();
                    if (TS.Trim() == "Close")
                    {
                        chkbox.Enabled = true;
                        txtUserRemark.Enabled = true;
                        Approve.Enabled = true;
                        Reject.Enabled = true;

                    }
                    else 
                    {
                        chkbox.Enabled = false;
                        txtUserRemark.Enabled = false;
                        Approve.Enabled = false;
                        Reject.Enabled = false;
                    }//<<add on 13/02/2024 end

                    var remark = dt.Rows[i]["UserRemark"];
                    string REMARK = remark.ToString();

                    if (REMARK.Trim() == "Approve" || REMARK.StartsWith("Approve") && TS.Trim()=="Close")  // add on 20/01/24
                    {
                        chkbox.Enabled = false;
                        txtUserRemark.Enabled = false;
                        Approve.Enabled = false;
                        Reject.Enabled = false;
                    }

                }
            }

            //GetVisible();
        }
        //lblMessage.Text = "Total Records founds:" + dt.Rows.Count;
        //lblMessage.CssClass = "SuccessMessage";
    }
    //changes done by sanket

    //public void GetVisible(object value)  //add on 20/01/24
    //{
    //    for (int i = 0; i < grvUserFill.Rows.Count; i++) // add on 20/01/24
    //    {
    //        if (grvUserFill.Rows[i].Cells[12].Text == "Approved")
    //        {
    //            LinkButton Approve = (LinkButton)grvUserFill.Rows[i].FindControl("Approve");
    //            Approve = dt.Rows[i]["Approve"];
    //            UserRemark.Text = Mark.ToString();

    //            //return true;
    //            Approve.Enabled = false;
    //        }
    //        return false;
    //    }
    //}
    protected void ddlProblemType_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlProblemType.SelectedIndex != 0)
        {
            int intProblemType = Convert.ToInt32(ddlProblemType.SelectedItem.Value);
            Get_ProblemDetailInfo(intProblemType);
            ddlProblemDetails.Focus();
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

            ddlProblemType.DataTextField = "ProblemTypeName";
            ddlProblemType.DataValueField = "ProblemTypeID";
            ddlProblemType.DataSource = dt;
            ddlProblemType.DataBind();

            ddlProblemType.Items.Insert(0, "--Select--");
            ddlProblemType.SelectedIndex = 0;
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

            ddlProblemDetails.DataTextField = "ProblemDetailsName";
            ddlProblemDetails.DataValueField = "ProblemDetailID";
            ddlProblemDetails.DataSource = dt;
            ddlProblemDetails.DataBind();

            ddlProblemDetails.Items.Insert(0, "--Select--");
            ddlProblemDetails.SelectedIndex = 0;
        }
        catch (Exception ex)
        {
            lblMessage.Visible = true;
            lblMessage.Text = ex.Message;
            lblMessage.CssClass = "ErrorMessage";
        }
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Pages/Menu.aspx", true);
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (IsValidEmail(txtUsermailId.Text)) //add on 07/05/2024
        {
            Insert_H_TicketInfo();
        }
        else //add on 07/05/2024
        {
            lblMessage.Text = "Email format is not valid.";
            txtUsermailId.Focus();
        }
       
    }
    private void Insert_H_TicketInfo()
    {
        Object SaveUSERInfo = (Object)Session["UserInfo"];

        SqlConnection sqlCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);

        sqlCon.Open();
        SqlCommand sqlCom = new SqlCommand();
        sqlCom.Connection = sqlCon;
        sqlCom.CommandType = CommandType.StoredProcedure;
        sqlCom.CommandText = "HelpDesk_InsertTicketInfoMRB_SP";
        SqlDataAdapter sqlDA = new SqlDataAdapter();
        sqlDA.SelectCommand = sqlCom;

        SqlParameter BranchID = new SqlParameter();
        BranchID.SqlDbType = SqlDbType.Int;
        BranchID.Value = Convert.ToInt32(((UserInfo.structUSERInfo)(SaveUSERInfo)).BranchId);
        BranchID.ParameterName = "@BranchID";
        sqlCom.Parameters.Add(BranchID);

        SqlParameter TicketNo = new SqlParameter();
        TicketNo.SqlDbType = SqlDbType.VarChar;
        TicketNo.Value = lblTicketNo.Text.Trim();
        TicketNo.ParameterName = "@TicketNo";
        sqlCom.Parameters.Add(TicketNo);

        SqlParameter UserName = new SqlParameter();
        UserName.SqlDbType = SqlDbType.VarChar;
        UserName.Value = txtUserName.Text.Trim();
        UserName.ParameterName = "@UserName";
        sqlCom.Parameters.Add(UserName);

        SqlParameter Department = new SqlParameter();
        Department.SqlDbType = SqlDbType.VarChar;
        //    Department.Value = txtDepartment.Text.Trim();
        Department.Value = ddlDepartment.SelectedItem.ToString();

        Department.ParameterName = "@Department";
        sqlCom.Parameters.Add(Department);

        int intProblemType = Convert.ToInt32(ddlProblemType.SelectedItem.Value);

        SqlParameter ProblemTypeID = new SqlParameter();
        ProblemTypeID.SqlDbType = SqlDbType.Int;
        ProblemTypeID.Value = intProblemType;
        ProblemTypeID.ParameterName = "@ProblemTypeID";
        sqlCom.Parameters.Add(ProblemTypeID);

        int intProblemDetail = Convert.ToInt32(ddlProblemDetails.SelectedItem.Value);

        SqlParameter ProblemDetailId = new SqlParameter();
        ProblemDetailId.SqlDbType = SqlDbType.Int;
        ProblemDetailId.Value = intProblemDetail;
        ProblemDetailId.ParameterName = "@ProblemDetailId";
        sqlCom.Parameters.Add(ProblemDetailId);


        // changes done by sanket

        //SqlParameter Priority = new SqlParameter();
        //Priority.SqlDbType = SqlDbType.VarChar;
        //Priority.Value = ddlPriority.SelectedItem.Value.ToString().Trim(); 
        //Priority.ParameterName = "@Priority";
        //sqlCom.Parameters.Add(Priority);

        SqlParameter Remark = new SqlParameter();
        Remark.SqlDbType = SqlDbType.VarChar;
        Remark.Value = txtRemark.Text.Trim();
        Remark.ParameterName = "@Remark";
        sqlCom.Parameters.Add(Remark);

        SqlParameter AttachmentPath = new SqlParameter();
        AttachmentPath.SqlDbType = SqlDbType.VarChar;
        AttachmentPath.Value = UploadAttachment_OnServer();
        AttachmentPath.ParameterName = "@AttachmentPath";
        sqlCom.Parameters.Add(AttachmentPath);

        SqlParameter UserID = new SqlParameter();
        UserID.SqlDbType = SqlDbType.VarChar;
        UserID.Value = Convert.ToString(((UserInfo.structUSERInfo)(SaveUSERInfo)).UserId);
        UserID.ParameterName = "@UserID";
        sqlCom.Parameters.Add(UserID);



        SqlParameter Usermailid = new SqlParameter();
        Usermailid.SqlDbType = SqlDbType.VarChar;
        Usermailid.Value = txtUsermailId.Text;
        Usermailid.ParameterName = "@Usermailid";
        sqlCom.Parameters.Add(Usermailid);

        SqlParameter UserRemark = new SqlParameter(); //add on 19/01/24
        UserRemark.SqlDbType = SqlDbType.VarChar;
        UserRemark.Value = UserRemarkValue.Trim();
        UserRemark.ParameterName = "@UserRemark";
        sqlCom.Parameters.Add(UserRemark);

        SqlParameter VarResult = new SqlParameter();
        VarResult.SqlDbType = SqlDbType.VarChar;
        VarResult.Value = lblTicketNo.Text.Trim();
        VarResult.ParameterName = "@VarResult";
        VarResult.Size = 200;
        VarResult.Direction = ParameterDirection.Output;
        sqlCom.Parameters.Add(VarResult);

        sqlCom.ExecuteNonQuery();
        string RowEffected = Convert.ToString(sqlCom.Parameters["@VarResult"].Value);

        sqlCon.Close();

        if (RowEffected != "")
        {
            lblMessage.Text = "Ticket Successfully Generated, Ticket No: " + RowEffected;
            lblMessage.CssClass = "SuccessMessage";
            lblTicketNo.Text = RowEffected;
            Clear_Controls();
        }

        fillUserGrid();

    }
    private string UploadAttachment_OnServer()
    {
        try
        {
            string FileSavePath = "";
            if (FileUpload1.FileName != "")
            {
                string fullSitePath = Convert.ToString(ConfigurationSettings.AppSettings["HelpdeskAttachmentPath"]);
                fullSitePath = fullSitePath.Trim();

                string FileName_Attachment = Convert.ToString(DateTime.Now.ToString("yyyyMMddHHmmss")) + "-" + Convert.ToString(FileUpload1.FileName.Trim());
                FileName_Attachment = FileName_Attachment.Replace(" ", "_");
                FileSavePath = fullSitePath + FileName_Attachment;

                FileInfo FFileName_ValidDBF = new FileInfo(FileSavePath);
                if (FFileName_ValidDBF.Exists)
                {
                    File.Delete(FileSavePath);
                }

                FileUpload1.SaveAs(FileSavePath);
            }
            return FileSavePath;
        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
            lblMessage.CssClass = "ErrorMessage";
            return "";
        }
    }
    private void Clear_Controls() //add by Rutu 04/11/23
    {
        lblTicketNo.Text = "";
        txtUsermailId.Text = "";
        //txtUserName.Text = "";
        txtRemark.Text = "";
        FileUpload1 = null;
        ddlDepartment.SelectedIndex = 0;
        ddlProblemType.SelectedIndex = 0;
        ddlProblemDetails.SelectedIndex = 0;
        lblMessage.Text = "";
        lblMessage2.Text = "";
        UserRemarkValue = "";
    }
    private void Register_ControlsWith_JavaScript()
    {
        btnSave.Attributes.Add("onclick", "javascript:return validate_finalsave();");
    }



    protected void btnexport_Click(object sender, EventArgs e)
    {
        String attachment = "attachment; filename=Ticket_Details.xls";
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
        tblCell1.Text = "<b> <span style='background-color:Gray'> <font size='4'>PAMAC FINSERVE PVT. LTD. </font></span></b> <br/>" +
                        "<b><font size='2' color='blue'>Ticket_Details Report   </font></b> <br/>";
        tblCell1.CssClass = "SuccessMessage";
        tblRow.Cells.Add(tblCell);
        tblRow1.Cells.Add(tblCell1);
        tblRow.Height = 20;
        tblSpace.Rows.Add(tblRow);
        tblSpace.Rows.Add(tblRow1);
        tblSpace.RenderControl(htw);

        Table tbl = new Table();
        grvUserFill.EnableViewState = false;
        grvUserFill.GridLines = GridLines.Both;
        grvUserFill.RenderControl(htw);
        Response.Write(sw.ToString());

        Response.End();
    }

    public override void VerifyRenderingInServerForm(Control control)
    {

    }



    protected void Approve_Click(object sender, EventArgs e)  //add on 17/01/24
    {
        int ischecked = 0; //add on 13/02/2024

        for (int i = 0; i <= grvUserFill.Rows.Count - 1; i++)
        {
            CheckBox chkbox = (CheckBox)grvUserFill.Rows[i].FindControl("chkbox");
            TextBox txtUserRemark = (TextBox)grvUserFill.Rows[i].FindControl("UserRemark");
            UserRemarkValue = txtUserRemark.Text.Trim();

            if (UserRemarkValue.Trim() == "Reject" || UserRemarkValue.StartsWith("Reject"))  //add on 14/02/2024
            {
                UserRemarkValue = "";
            }

            if (chkbox.Checked == true)
            {
                Remark();
                ApproveSPCall();
                fillUserGrid();

                ischecked = 1;

               
            }
            //else   //comment on 13/02/2024
            //{
            //    if (lblMessage2.Text == "")
            //    {
            //        lblMessage.Text = "Please checked the CheckBox";
            //    }


            //}

            if (ischecked == 0) //add on 13/02/2024
            {
                lblMessage.Text = "Please checked the CheckBox";
            }

        }
        //Clear_Controls();
    }

    protected void Reject_Click(object sender, EventArgs e)
    {

        int ischecked = 0; //add on 12/02/2024

        for (int i = 0; i <= grvUserFill.Rows.Count - 1; i++)
        {
            CheckBox chkbox = (CheckBox)grvUserFill.Rows[i].FindControl("chkbox");
            TextBox txtUserRemark = (TextBox)grvUserFill.Rows[i].FindControl("UserRemark");
            UserRemarkValue = txtUserRemark.Text.Trim();
            if (chkbox.Checked == true)
            {
                lblMessage.Text = "";
                if (txtUserRemark.Text != "")
                {
                    Remark();
                    RejectSPCall();
                    //Insert_H_TicketInfo(); //add on 23/01/24
                    fillUserGrid();

                    ischecked = 1;
                }
                else
                {
                    lblMessage.Text = ""; //add on 23/01/24
                    lblMessage2.Text = "Please Enter Remark for Reject"; //add on 23/01/24
                }
            }

            if (ischecked == 0)  //add on 12/02/2024
            {
                lblMessage.Text = "Please checked the CheckBox";
            }


        }

        //Clear_Controls();
    }

    protected void ApproveSPCall()  //add on 17/01/24
    {
        Object SaveUSERInfo = (Object)Session["UserInfo"];  //add on 13/02/2024

        SqlConnection sqlCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);
        sqlCon.Open();
        SqlCommand sqlCom = new SqlCommand();
        sqlCom.Connection = sqlCon;
        sqlCom.CommandType = CommandType.StoredProcedure;
        sqlCom.CommandText = "H_ApproveBtn_SP";
        SqlDataAdapter sqlDA = new SqlDataAdapter();
        sqlDA.SelectCommand = sqlCom;

        SqlParameter TicketNo = new SqlParameter();
        TicketNo.SqlDbType = SqlDbType.VarChar;
        TicketNo.Value = hdnID.Value;
        TicketNo.ParameterName = "@TicketNo";
        sqlCom.Parameters.Add(TicketNo);

        SqlParameter UserRemark = new SqlParameter();
        UserRemark.SqlDbType = SqlDbType.VarChar;
        UserRemark.Value = UserRemarkValue.Trim();//UserRemark.text.ToString().Trim();
        UserRemark.ParameterName = "@UserRemark";
        sqlCom.Parameters.Add(UserRemark);

        SqlParameter USERID = new SqlParameter();  //add on 13/02/2024
        USERID.SqlDbType = SqlDbType.VarChar;
        USERID.Value = Convert.ToString(((UserInfo.structUSERInfo)(SaveUSERInfo)).UserId);
        USERID.ParameterName = "@UserId";
        sqlCom.Parameters.Add(USERID);


        SqlParameter BranchId = new SqlParameter();  //add on 13/02/2024
        BranchId.SqlDbType = SqlDbType.VarChar;
        BranchId.Value = Convert.ToString(((UserInfo.structUSERInfo)(SaveUSERInfo)).BranchId);
        BranchId.ParameterName = "@BranchId";
        sqlCom.Parameters.Add(BranchId);

        sqlCom.ExecuteNonQuery();
        sqlCon.Close();
    }

    public void RejectSPCall()
    { 
        Object SaveUSERInfo = (Object)Session["UserInfo"];  //add on 13/02/2024

        SqlConnection sqlCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);
        sqlCon.Open();
        SqlCommand sqlCom = new SqlCommand();
        sqlCom.Connection = sqlCon;
        sqlCom.CommandType = CommandType.StoredProcedure;
        sqlCom.CommandText = "H_RejectBtn_SP";
        SqlDataAdapter sqlDA = new SqlDataAdapter();
        sqlDA.SelectCommand = sqlCom;

        SqlParameter TicketNo = new SqlParameter();
        TicketNo.SqlDbType = SqlDbType.VarChar;
        TicketNo.Value = hdnID.Value;
        TicketNo.ParameterName = "@TicketNo";
        sqlCom.Parameters.Add(TicketNo);

        SqlParameter UserRemark = new SqlParameter();
        UserRemark.SqlDbType = SqlDbType.VarChar;
        UserRemark.Value = UserRemarkValue.Trim();
        UserRemark.ParameterName = "@UserRemark";
        sqlCom.Parameters.Add(UserRemark);


        SqlParameter USERID = new SqlParameter();   
        USERID.SqlDbType = SqlDbType.VarChar;
        USERID.Value = Convert.ToString(((UserInfo.structUSERInfo)(SaveUSERInfo)).UserId);
        USERID.ParameterName = "@UserId";
        sqlCom.Parameters.Add(USERID);

        SqlParameter BranchId = new SqlParameter();
        BranchId.SqlDbType = SqlDbType.VarChar;
        BranchId.Value = Convert.ToString(((UserInfo.structUSERInfo)(SaveUSERInfo)).BranchId);
        BranchId.ParameterName = "@BranchId";
        sqlCom.Parameters.Add(BranchId);


        sqlCom.ExecuteNonQuery();
        sqlCon.Close();
    }
    public void Remark()  //add on 17/01/24
    {
        try
        {
            for (int i = 0; i <= grvUserFill.Rows.Count - 1; i++)
            {
                CheckBox chkbox = (CheckBox)grvUserFill.Rows[i].FindControl("chkbox");
                LinkButton WIP = (LinkButton)grvUserFill.Rows[i].FindControl("Approve");
                LinkButton WIP2 = (LinkButton)grvUserFill.Rows[i].FindControl("Reject");
                TextBox txtUserRemark = (TextBox)grvUserFill.Rows[i].FindControl("UserRemark");

                if (chkbox.Checked == true)
                {

                    GridViewRow GR = (GridViewRow)WIP.NamingContainer;
                    int index = GR.RowIndex;
                    hdnID.Value = grvUserFill.DataKeys[i].Value.ToString();
                    //txtUserRemark.Text= grvUserFill.DataKeys[i]["UserRemark"].ToString();

                }

            }

        }
        catch (Exception ex)
        {
            lblMessage.Visible = true;
            lblMessage.Text = "Error :" + ex.Message;

        }
    }

    //public static bool IsEmail(string strEmail) //add on 07/05/2024
    //{
    //    Regex rgxEmail = new Regex(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" +
    //                               @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" +
    //                               @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$");
    //    return rgxEmail.IsMatch(strEmail);
    //}

    public bool IsValidEmail(string txtUsermailId) //add on 07/05/2024
    {
        // Regular expression pattern for email validation
        string pattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";

        // Check if the email matches the pattern
        return Regex.IsMatch(txtUsermailId, pattern);
    }

    protected void TicketCloseSP() //add on 07/05/2024
    {
        Object SaveUSERInfo = (Object)Session["UserInfo"];

        SqlConnection con = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);
        con.Open();
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "HelpDesk_TicketClosedByIT_SP";

        SqlParameter ticketno = new SqlParameter();
        ticketno.SqlDbType = SqlDbType.VarChar;
        ticketno.Value = lblTicketNo.Text;
        ticketno.ParameterName = "@TicketNo";
        cmd.Parameters.Add(ticketno);

        SqlDataAdapter sda = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        sda.Fill(ds);
    }
}
