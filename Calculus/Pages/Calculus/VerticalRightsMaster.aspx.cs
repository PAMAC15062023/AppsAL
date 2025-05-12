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

public partial class Pages_Calculus_VerticalRightsMaster : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserInfo"] == null)
        {
            Response.Redirect("~/Pages/InvalidRequest.aspx");

        }

        if (!IsPostBack)
        {
             
            GET_Header_Values();
            Register_ControlsWith_JavaScript();

        }

        //string StrScript = "<script language='javascript'> javascript:Page_load_validation(); </script>";
       // Page.RegisterStartupScript("OnLoad_21", StrScript);
   
    }
    protected void txtUserID_TextChanged(object sender, EventArgs e)
    {
        Get_UserList();
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        Insert_Vertical_Rights_Info();
        Get_Vertical_Rights_Info(ddlUserList.SelectedItem.Value.Trim());
        Reset_Controls();
    }
    private void GET_Header_Values()
    {
        Get_BranchId();
              
    }
    private void Register_ControlsWith_JavaScript()
    {          
        btnSave.Attributes.Add("onclick","javascript:return Validate_Save()");
        btnGo.Attributes.Add("onclick", "javascript:return Validate_SearchUserID()");       
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
    protected void btnGo_Click(object sender, EventArgs e)
    {
        Get_Vertical_Rights_Info(ddlUserList.SelectedItem.Value.Trim());
        //Get_UserList();
    }
    private void Get_UserList()
    {
        try
        {
          
            SqlConnection sqlCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);

            sqlCon.Open();
            SqlCommand sqlCom = new SqlCommand();
            sqlCom.Connection = sqlCon;
            sqlCom.CommandType = CommandType.StoredProcedure;
            sqlCom.CommandText = "Get_UserList";

            SqlParameter BranchID = new SqlParameter();
            BranchID.SqlDbType = SqlDbType.Int;
            BranchID.Value = 0;
            BranchID.ParameterName = "@BranchID";
            sqlCom.Parameters.Add(BranchID);

            SqlParameter UserName = new SqlParameter();
            UserName.SqlDbType = SqlDbType.VarChar;
            UserName.Value = txtUserID.Text.Trim();
            UserName.ParameterName = "@UserName";
            sqlCom.Parameters.Add(UserName);


            SqlDataAdapter sqlDA = new SqlDataAdapter();
            sqlDA.SelectCommand = sqlCom;
            DataTable dt = new DataTable();
            sqlDA.Fill(dt);
            sqlCon.Close();

            ddlUserList.DataTextField = "UserName";
            ddlUserList.DataValueField = "UserID";

            ddlUserList.DataSource = dt;
            ddlUserList.DataBind();

            ddlUserList.Items.Insert(0, "--Select--");
            ddlUserList.SelectedIndex = 0;

            ddlUserList.Focus();



        }
        catch (Exception ex)
        {
            lblMessage.Visible = true;
            lblMessage.Text = ex.Message;
            lblMessage.CssClass = "ErrorMessage";
        }
    }
    private void Get_Vertical_Rights_Info(string UserID_Name)
    {
        try
        {
            SqlConnection sqlCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);
            sqlCon.Open();

            SqlCommand sqlCom = new SqlCommand();
            sqlCom.Connection = sqlCon;
            sqlCom.CommandType = CommandType.StoredProcedure;
            sqlCom.CommandText = "AdminMaster_GetVerticalRightsInfo_SP";

            SqlParameter UserID = new SqlParameter();
            UserID.SqlDbType = SqlDbType.VarChar;
            UserID.Value = UserID_Name.Trim();
            UserID.ParameterName = "@UserID";
            sqlCom.Parameters.Add(UserID);

            int intBranchID = 0;
            if (ddlBranchList.SelectedIndex != 0)
            {
                intBranchID =Convert.ToInt32(ddlBranchList.SelectedItem.Value); 
            }
            
            SqlParameter BranchID = new SqlParameter();
            BranchID.SqlDbType = SqlDbType.Int;
            BranchID.Value = intBranchID;
            BranchID.ParameterName = "@BranchID";
            sqlCom.Parameters.Add(BranchID);

            SqlDataAdapter sqlDA = new SqlDataAdapter();
            sqlDA.SelectCommand = sqlCom;
            DataTable dt = new DataTable();
            sqlDA.Fill(dt);
            sqlCon.Close();

            if (dt.Rows.Count > 0)
            {
                grv_GroupInfo.DataSource = dt;
                grv_GroupInfo.DataBind();
                lblMessage.Text = "Total No of Records Found(s) " + dt.Rows.Count;
                lblMessage.CssClass = "SuccessMessage";
            }
            else
            {
                grv_GroupInfo.DataSource = null;
                grv_GroupInfo.DataBind();
                lblMessage.Text = "No Rocords found ";
                lblMessage.CssClass = "ErrorMessage"; 
            }
        }
        catch (Exception ex)
        {
            lblMessage.Visible = true;
            lblMessage.Text = ex.Message;
            lblMessage.CssClass = "ErrorMessage";
        }
    }
    protected void grv_GroupInfo_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {

            Label lblPCPA = (Label)e.Row.FindControl("lblPCPA");
            Label lblPCPV = (Label)e.Row.FindControl("lblPCPV");
            Label lblPFRC = (Label)e.Row.FindControl("lblPFRC");
            Label lblPDCR = (Label)e.Row.FindControl("lblPDCR");
            Label lblPTPU = (Label)e.Row.FindControl("lblPTPU");
            Label lblPRSP = (Label)e.Row.FindControl("lblPRSP");
            Label lblAdmin = (Label)e.Row.FindControl("lblAdmin");
            Label lblEDP = (Label)e.Row.FindControl("lblEDP");
            Label lblSSU = (Label)e.Row.FindControl("lblSSU");
            Label lblHSU = (Label)e.Row.FindControl("lblHSU");
            Label lblEBC = (Label)e.Row.FindControl("lblEBC");
            Label lblRCU = (Label)e.Row.FindControl("lblRCU");
            Label lblISO = (Label)e.Row.FindControl("lblISO");
            Label lblBD = (Label)e.Row.FindControl("lblBD");

            Label lblAcct = (Label)e.Row.FindControl("lblAcct");
            Label lblHR = (Label)e.Row.FindControl("lblHR");
            Label lblCollection = (Label)e.Row.FindControl("lblCollection");

            Label lblBranchCode = (Label)e.Row.FindControl("lblBranchCode");

            if (lblEDP.ToolTip != "0")
            {
                lblEDP.Text = "R";
            }
            else
            {
                lblEDP.Text = "T";
                lblEDP.BackColor = System.Drawing.Color.LightCoral;
            }

            if (lblAdmin.ToolTip != "0")
            {
                lblAdmin.Text = "R";
            }
            else
            {
                lblAdmin.Text = "T";
                lblAdmin.BackColor = System.Drawing.Color.LightCoral;
            }

            if (lblPCPA.ToolTip != "0")
            {
                lblPCPA.Text = "R";               
            }
            else
            {
                lblPCPA.Text = "T";
                lblPCPA.BackColor= System.Drawing.Color.LightCoral;
            }

            if (lblPCPV.ToolTip != "0")
            {
                lblPCPV.Text = "R";
            }
            else
            {
                lblPCPV.Text = "T";
                lblPCPV.BackColor = System.Drawing.Color.LightCoral;
            }

            if (lblPFRC.ToolTip != "0")
            {
                lblPFRC.Text = "R";
            }
            else
            {
                lblPFRC.Text = "T";
                lblPFRC.BackColor = System.Drawing.Color.LightCoral;
        
            }

            if (lblPDCR.ToolTip != "0")
            {
                lblPDCR.Text = "R";
            }
            else
            {
                lblPDCR.Text = "T";
                lblPDCR.BackColor = System.Drawing.Color.LightCoral;
        
            }

            if (lblPTPU.ToolTip != "0")
            {
                lblPTPU.Text = "R";
            }
            else
            {
                lblPTPU.Text = "T";
                lblPTPU.BackColor = System.Drawing.Color.LightCoral;
        
            }

            if (lblPRSP.ToolTip!= "0")
            {
                lblPRSP.Text = "R";
            }
            else
            {
                lblPRSP.Text = "T";
                lblPRSP.BackColor = System.Drawing.Color.LightCoral;
        
            }

            //--Added by kamal matekar

            if (lblAcct.ToolTip != "0")
            {
                lblAcct.Text = "R";
            }
            else
            {
                lblAcct.Text = "T";
                lblAcct.BackColor = System.Drawing.Color.LightCoral;

            }

            if (lblHR.ToolTip != "0")
            {
                lblHR.Text = "R";
            }
            else
            {
                lblHR.Text = "T";
                lblHR.BackColor = System.Drawing.Color.LightCoral;

            }

            if (lblCollection.ToolTip != "0")
            {
                lblCollection.Text = "R";
            }
            else
            {
                lblCollection.Text = "T";
                lblCollection.BackColor = System.Drawing.Color.LightCoral;

            }
            if (lblSSU.ToolTip != "0")
            {
                lblSSU.Text = "R";
            }
            else
            {
                lblSSU.Text = "T";
                lblSSU.BackColor = System.Drawing.Color.LightCoral;

            }
            if (lblHSU.ToolTip != "0")
            {
                lblHSU.Text = "R";
            }
            else
            {
                lblHSU.Text = "T";
                lblHSU.BackColor = System.Drawing.Color.LightCoral;

            }
            if (lblEBC.ToolTip != "0")
            {
                lblEBC.Text = "R";
            }
            else
            {
                lblEBC.Text = "T";
                lblEBC.BackColor = System.Drawing.Color.LightCoral;

            }
            if (lblRCU.ToolTip != "0")
            {
                lblRCU.Text = "R";
            }
            else
            {
                lblRCU.Text = "T";
                lblRCU.BackColor = System.Drawing.Color.LightCoral;

            }
            if (lblISO.ToolTip != "0")
            {
                lblISO.Text = "R";
            }
            else
            {
                lblISO.Text = "T";
                lblISO.BackColor = System.Drawing.Color.LightCoral;

            }
            if (lblBD.ToolTip != "0")
            {
                lblBD.Text = "R";
            }
            else
            {
                lblBD.Text = "T";
                lblBD.BackColor = System.Drawing.Color.LightCoral;

            }

            e.Row.Attributes.Add("onclick", "javascript:Get_UserVerticalDetailsFor_Modify('" + e.Row.Cells[4].Text.Trim() + "','" + lblBranchCode.ToolTip.Trim() + "','" + e.Row.Cells[0].Text.Trim() + "','" + lblPCPA.ToolTip.Trim() + "','" + lblPCPV.ToolTip.Trim() + "','" + lblPFRC.ToolTip.Trim() + "','" + lblPTPU.ToolTip.Trim() + "','" + lblPDCR.ToolTip.Trim() + "','" + lblPRSP.ToolTip.Trim() + "','" + lblAdmin.ToolTip.Trim() + "','" + lblEDP.ToolTip.Trim() + "','" + lblAcct.ToolTip.Trim() + "','" + lblHR.ToolTip.Trim() + "','" + lblCollection.ToolTip.Trim() + /*"','" + lblCollection.ToolTip.Trim() +*/ "','" + lblSSU.ToolTip.Trim() + "','" + lblHSU.ToolTip.Trim() + "','" + lblRCU.ToolTip.Trim() + "','" + lblEBC.ToolTip.Trim() + "','" + lblISO.ToolTip.Trim() +"','" + e.Row.RowIndex.ToString() + "');");
            e.Row.CssClass= "RowStyle";
            e.Row.Attributes.Add("onmouseover", "javascript:hover('in','" + e.Row.RowIndex + "','" + e.Row.Cells[0].Text.Trim() + "');");
            e.Row.Attributes.Add("onmouseout", "javascript:hover('out','" + e.Row.RowIndex + "','" + e.Row.Cells[0].Text.Trim() + "');");
         
        }

    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Pages/Menu.aspx", true);
    }
    protected void btnAddNew_Click(object sender, EventArgs e)
    {
        Reset_Controls();
    }
    private void Reset_Controls()
    {
        
        txtUserID.Text = "";
        ddlBranchList.SelectedIndex = 0;
        
        //ddlUserList.SelectedIndex = 0;
        
        hdnVerticalRightsID.Value = "0";
        lblMessage.Text = "";
    }
    private void Insert_Vertical_Rights_Info()
    {
        try
        {

            SqlConnection sqlCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);

            sqlCon.Open();
            SqlCommand sqlCom = new SqlCommand();
            sqlCom.Connection = sqlCon;
            sqlCom.CommandType = CommandType.StoredProcedure;
            sqlCom.CommandText = "AdminMaster_InsertVerticalRightsInfo_SP";

            SqlParameter Verical_Right_ID  = new SqlParameter();
            Verical_Right_ID.SqlDbType = SqlDbType.Int;
            Verical_Right_ID.Value = Convert.ToInt32(hdnVerticalRightsID.Value);
            Verical_Right_ID.ParameterName = "@Verical_Right_ID";
            sqlCom.Parameters.Add(Verical_Right_ID);

            SqlParameter BranchID = new SqlParameter();
            BranchID.SqlDbType = SqlDbType.Int;
            BranchID.Value =Convert.ToInt32(ddlBranchList.SelectedItem.Value);
            BranchID.ParameterName = "@BranchID";
            sqlCom.Parameters.Add(BranchID);

            SqlParameter UserID = new SqlParameter();
            UserID.SqlDbType = SqlDbType.VarChar;
            UserID.Value = ddlUserList.SelectedItem.Value;
            UserID.ParameterName = "@UserID";
            sqlCom.Parameters.Add(UserID);

            SqlParameter VerticalDetails = new SqlParameter();
            VerticalDetails.SqlDbType = SqlDbType.VarChar;
            VerticalDetails.Value = Get_Vertical_AssignedRights();
            VerticalDetails.ParameterName = "@VerticalDetails";
            sqlCom.Parameters.Add(VerticalDetails);
           
            int RowsEffected=Convert.ToInt32(sqlCom.ExecuteNonQuery());

            if (RowsEffected > 0)
            {
                lblMessage.Text = "Record Successfully Updated!";
                lblMessage.CssClass = "SuccessMessage";
            }
            else
            {
                lblMessage.Text = "No Records Updated!";
                lblMessage.CssClass = "ErrorMessage";
            }    

        }
        catch (Exception ex)
        {
            lblMessage.Visible = true;
            lblMessage.Text = ex.Message;
            lblMessage.CssClass = "ErrorMessage";
        }
    }

    private string Get_Vertical_AssignedRights()
    {
        string strVerticalDetails = "";

       

        if (chkPCPA.Checked == true)
        {
            strVerticalDetails = strVerticalDetails + "PCPA|1^";
        }
        else
        {
            strVerticalDetails = strVerticalDetails + "PCPA|0^";
        }

        if (chkPCPV.Checked == true)
        {
            strVerticalDetails = strVerticalDetails + "PCPV|1^";
        }
        else
        {
            strVerticalDetails = strVerticalDetails + "PCPV|0^";
        }

        if (chkPDCR.Checked == true)
        {
            strVerticalDetails = strVerticalDetails + "PDCR|1^";
        }
        else
        {
            strVerticalDetails = strVerticalDetails + "PDCR|0^";
        }

        if (chkPFRC.Checked == true)
        {
            strVerticalDetails = strVerticalDetails + "PFRC|1^";
        }
        else
        {
            strVerticalDetails = strVerticalDetails + "PFRC|0^";
        }

        if (chkPRSP.Checked == true)
        {
            strVerticalDetails = strVerticalDetails + "PRSP|1^";
        }
        else
        {
            strVerticalDetails = strVerticalDetails + "PRSP|0^";
        }

        if (chkPTPU.Checked == true)
        {
            strVerticalDetails = strVerticalDetails + "PTPU|1^";
        }
        else
        {
            strVerticalDetails = strVerticalDetails + "PTPU|0^";
        }
        if (chkAdmin.Checked == true)
        {
            strVerticalDetails = strVerticalDetails + "Admin|1^";
        }
        else
        {
            strVerticalDetails = strVerticalDetails + "Admin|0^";
        }

        if (chkEDP.Checked == true)
        {
            strVerticalDetails = strVerticalDetails + "EDP|1^";
        }
        else
        {
            strVerticalDetails = strVerticalDetails + "EDP|0^";
        }
        
        //-----Added by kamal matekar

        if (chkAcct.Checked == true)
        {
            strVerticalDetails = strVerticalDetails + "Account|1^";
        }
        else
        {
            strVerticalDetails = strVerticalDetails + "Account|0^";
        }
        if (chkHR.Checked == true)
        {
            strVerticalDetails = strVerticalDetails + "HR|1^";
        }
        else
        {
            strVerticalDetails = strVerticalDetails + "HR|0^";
        }
        if (CheckCollection.Checked == true)
        {
            strVerticalDetails = strVerticalDetails + "Collection|1^";
        }
        else
        {
            strVerticalDetails = strVerticalDetails + "Collection|0^";
        }
        if (ChkSSU.Checked == true)
        {
            strVerticalDetails = strVerticalDetails + "SSU|1^";
        }
        else
        {
            strVerticalDetails = strVerticalDetails + "SSU|0^";
        }
        if (ChkHSU.Checked == true)
        {
            strVerticalDetails = strVerticalDetails + "HSU|1^";
        }
        else
        {
            strVerticalDetails = strVerticalDetails + "HSU|0^";
        }
        if (ChkEBC.Checked == true)
        {
            strVerticalDetails = strVerticalDetails + "EBC|1^";
        }
        else
        {
            strVerticalDetails = strVerticalDetails + "EBC|0^";
        }

        if (ChkRCU.Checked == true)
        {
            strVerticalDetails = strVerticalDetails + "RCU|1^";
        }
        else
        {
            strVerticalDetails = strVerticalDetails + "RCU|0^";
        }
        if (ChkISO.Checked == true)
        {
            strVerticalDetails = strVerticalDetails + "ISO|1^";
        }
        else
        {
            strVerticalDetails = strVerticalDetails + "ISO|0^";
        }
        if (ChkBD.Checked == true)
        {
            strVerticalDetails = strVerticalDetails + "BD|1^";
        }
        else
        {
            strVerticalDetails = strVerticalDetails + "BD|0^";
        }


        return strVerticalDetails;

    }
}
