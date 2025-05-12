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

public partial class Pages_Helpdesk_NewTicket : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserInfo"] == null)
        {
            Response.Redirect("~/Pages/InvalidRequest.aspx");
        }        

        if (!IsPostBack)
        {
            usenamepage_load();
          
            Get_vender_name();//vender name drodownlist
            Get_vender_provider(0);//vender provier dropdownlist
            Get_vender_sevices(0);//vender sevices dropdownlist
            Register_ControlsWith_JavaScript();
        }
        
    }

   //added by suraksha automatic

    private void usenamepage_load() // automatic show username on page 
    {

        try
        {
            Object SaveUSERInfo = (Object)Session["UserInfo"];
            SqlConnection sqlCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);

            sqlCon.Open();
            SqlCommand sqlCom = new SqlCommand();
            sqlCom.Connection = sqlCon;
            sqlCom.CommandType = CommandType.StoredProcedure;
           sqlCom.CommandText = "Get_usernamefromid";
           
            sqlCom.CommandTimeout = 0;

            SqlParameter ProblemTypeID = new SqlParameter();
            ProblemTypeID.SqlDbType = SqlDbType.VarChar;
            ProblemTypeID.Value = Convert.ToString(((UserInfo.structUSERInfo)(SaveUSERInfo)).UserId);
            ProblemTypeID.ParameterName = "@userid";
            sqlCom.Parameters.Add(ProblemTypeID);

          
            SqlDataReader dr = sqlCom.ExecuteReader();
            if (dr.Read())
            {
                txtUserName.Text = dr["UserName"].ToString();
            }
            sqlCon.Close();
            
            
        }
        catch (Exception ex)
        {
            lblMessage.Visible = true;
            lblMessage.Text = ex.Message;
            lblMessage.CssClass = "ErrorMessage";
        }

    }
    private void fillUserGrid()//fill gridview procedure change by suraksha call in insert method
    {
        Object SaveUSERInfo = (Object)Session["UserInfo"];
        SqlConnection sqlCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);

        sqlCon.Open();
        SqlCommand sqlCom = new SqlCommand();
        sqlCom.Connection = sqlCon;
        sqlCom.CommandType = CommandType.StoredProcedure;
        sqlCom.CommandText = "Get_ReqeustedTicket_For_Assignment_User_new";//inner join
        sqlCom.CommandTimeout = 0;

        SqlDataAdapter sqlDA = new SqlDataAdapter();
        sqlDA.SelectCommand = sqlCom;

        SqlParameter USERID = new SqlParameter();
        USERID.SqlDbType = SqlDbType.VarChar;
        USERID.Value = Convert.ToString(((UserInfo.structUSERInfo)(SaveUSERInfo)).UserId);
        USERID.ParameterName = "@RequestBy";// parameter pass userID into sp
        sqlCom.Parameters.Add(USERID);
        
        SqlParameter BranchID = new SqlParameter();
        BranchID.SqlDbType = SqlDbType.Int;
        BranchID.Value = Convert.ToInt32(((UserInfo.structUSERInfo)(SaveUSERInfo)).BranchId);
        BranchID.ParameterName = "@BranchID";//parameter pass branchID inti sp
        sqlCom.Parameters.Add(BranchID);

        int intProblemType = Convert.ToInt32(ddlProblemType.SelectedItem.Value);

        SqlParameter intProblemType1  = new SqlParameter();
        intProblemType1.SqlDbType = SqlDbType.Int;
        intProblemType1.Value = intProblemType;
        intProblemType1.ParameterName = "@venderName";
        sqlCom.Parameters.Add(intProblemType1);

     


        DataTable dt = new DataTable();
        sqlDA.Fill(dt);
        sqlCon.Close();

        if (dt.Rows.Count > 0)
        {
            grvUserFill.DataSource = dt;
            grvUserFill.DataBind();
        }
        //lblMessage.Text = "Total Records founds:" + dt.Rows.Count;
        //lblMessage.CssClass = "SuccessMessage";
    }
    //changes done by suraksha


    protected void ddlProblemType_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlProblemType.SelectedIndex != 0)
        {
            int intProblemType = Convert.ToInt32(ddlProblemType.SelectedItem.Value);
            Get_vender_provider(intProblemType);
            ddlProblemDetails.Focus();
        }
         
    }
    protected void ddlProblemDetails_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlProblemDetails.SelectedIndex != 0)
        {
            int intvenderpro = Convert.ToInt32(ddlProblemDetails.SelectedItem.Value);
            Get_vender_sevices(intvenderpro);
            ddlvender_provider.Focus();
        }
    }
    private void Get_vender_name()
    {
        try
        {
            SqlConnection sqlCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);

            sqlCon.Open();
            SqlCommand sqlCom = new SqlCommand();
            sqlCom.Connection = sqlCon;
            sqlCom.CommandType = CommandType.StoredProcedure;
            sqlCom.CommandText = "Get_vender_type";
            SqlDataAdapter sqlDA = new SqlDataAdapter();
            sqlDA.SelectCommand = sqlCom;
            
            DataTable dt = new DataTable();
            sqlDA.Fill(dt);
            sqlCon.Close();

            ddlProblemType.DataTextField = "vender_name";
            ddlProblemType.DataValueField = "vender_id";
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
    // change done by suraksha
    private void Get_vender_provider(int intProblemType)
    {
        try
        {
            SqlConnection sqlCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);

            sqlCon.Open();
            SqlCommand sqlCom = new SqlCommand();
            sqlCom.Connection = sqlCon;
            sqlCom.CommandType = CommandType.StoredProcedure;
            sqlCom.CommandText = "Get_vender_provider";
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

            ddlProblemDetails.DataTextField = "vender_prob_provider";
            ddlProblemDetails.DataValueField = "vender_id";
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
    //one method added by suraksha
    private void Get_vender_sevices(int intvenderpro)
    {

        try
        {
            SqlConnection sqlCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);

            sqlCon.Open();
            SqlCommand sqlCom = new SqlCommand();
            sqlCom.Connection = sqlCon;
            sqlCom.CommandType = CommandType.StoredProcedure;
            sqlCom.CommandText = "Get_vender_sevices";
            SqlDataAdapter sqlDA = new SqlDataAdapter();
            sqlDA.SelectCommand = sqlCom;

            SqlParameter ProblemTypeID = new SqlParameter();
            ProblemTypeID.SqlDbType = SqlDbType.Int;
            ProblemTypeID.Value = intvenderpro;
            ProblemTypeID.ParameterName = "@intvenderpro";
            sqlCom.Parameters.Add(ProblemTypeID);

            DataTable dt = new DataTable();
            sqlDA.Fill(dt);
            sqlCon.Close();

            ddlvender_provider.DataTextField = "vender_services";
            ddlvender_provider.DataValueField = "vender_id";
            ddlvender_provider.DataSource = dt;
            ddlvender_provider.DataBind();

            ddlvender_provider.Items.Insert(0, "--Select--");
            ddlvender_provider.SelectedIndex = 0;
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
    protected void btnSave_Click(object sender, EventArgs e)//done  Insert_H_TicketInfo method call here
    {
        Insert_H_TicketInfo();
    }
    private void Insert_H_TicketInfo()// procedure change by suraksha
    {
            Object SaveUSERInfo = (Object)Session["UserInfo"];

            SqlConnection sqlCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);

            sqlCon.Open();
            SqlCommand sqlCom = new SqlCommand();
            sqlCom.Connection = sqlCon;
            sqlCom.CommandType = CommandType.StoredProcedure;
           // sqlCom.CommandText = "Insert_H_TicketInfoMRB";
            sqlCom.CommandText = "Insert_H_TicketInfoMRB_new";
            SqlDataAdapter sqlDA = new SqlDataAdapter();
            sqlDA.SelectCommand = sqlCom;

            SqlParameter BranchID = new SqlParameter();
            BranchID.SqlDbType = SqlDbType.Int;
            BranchID.Value = Convert.ToInt32(((UserInfo.structUSERInfo)(SaveUSERInfo)).BranchId);
            BranchID.ParameterName = "@BranchID";
            sqlCom.Parameters.Add(BranchID);

            SqlParameter TicketNo = new SqlParameter();
            TicketNo.SqlDbType = SqlDbType.VarChar;
            TicketNo.Value =lblTicketNo.Text.Trim();
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
            ProblemTypeID.ParameterName = "@venderName";
            sqlCom.Parameters.Add(ProblemTypeID);

            int intProblemDetail=Convert.ToInt32(ddlProblemDetails.SelectedItem.Value);

            SqlParameter ProblemDetailId = new SqlParameter();
            ProblemDetailId.SqlDbType = SqlDbType.Int;
            ProblemDetailId.Value = intProblemDetail;
            ProblemDetailId.ParameterName = "@venderProvider";
            sqlCom.Parameters.Add(ProblemDetailId);

           // newly added by suraksha
            int intvenderservice = Convert.ToInt32(ddlvender_provider.SelectedItem.Value);

            SqlParameter Problemservice = new SqlParameter();
            Problemservice.SqlDbType = SqlDbType.Int;
            Problemservice.Value = intvenderservice;
            Problemservice.ParameterName = "@venderService";
            sqlCom.Parameters.Add(Problemservice);


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
    private void Clear_Controls()
    { 
    
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

   
}
