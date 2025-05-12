using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LNTFinance.Pages
{
    public partial class LNT_UserMaster : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindRoleId();
                Register_ControlsWithJavaScript();
                BindReportingManager();
            }
        }
        protected void txtLoginName_TextChanged(object sender, EventArgs e)
        {
            lblMessage.Text = "";
            try
            {
                SqlConnection sqlCon = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

                SqlCommand cmd = new SqlCommand("LNT_IsEmployeeExists", sqlCon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@UserId", txtLoginName.Text.Trim());
                cmd.Parameters.AddWithValue("@ClientId", Session["ClientID"]); /*Added on 19/07/2022*/
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adp.Fill(ds);


                if (ds != null && ds.Tables[0].Rows.Count > 0)
                {

                }
                else
                {
                    txtLoginName.Text = "";
                    lblMessage.Text = "Employee Code Not Exists In PMS";
                }



            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }
        private void Register_ControlsWithJavaScript()
        {
            btnAddNew.Attributes.Add("onclick", "javascript:return Validate_AddNEW();");
            btnSave.Attributes.Add("onclick", "javascript:return Validate_Save();");

        }
        protected void BindRoleId()
        {
            int roleID = Convert.ToInt32(Session["RoleID"]);

            try
            {
                SqlConnection sqlCon = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

                SqlCommand cmd = new SqlCommand("LNT_BindRoleId_SP", sqlCon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ClientId", Session["ClientID"]);  //Added on 27/07/2022
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adp.Fill(ds);

                if (ds != null && ds.Tables[0].Rows.Count > 0)
                {
                    if (roleID == 1)
                    {
                        ddlRoleId.DataValueField = "RoleID";
                        ddlRoleId.DataTextField = "RoleName";
                        ddlRoleId.DataSource = ds.Tables[0];
                        ddlRoleId.DataBind();
                        ddlRoleId.Items.Insert(0, "--Select--");
                        ddlRoleId.SelectedIndex = 0;
                    }
                    else
                    {
                        ds.Tables[0].Rows[0].Delete();
                        ds.Tables[0].Rows[1].Delete();
                        ds.AcceptChanges();

                        ddlRoleId.DataValueField = "RoleID";
                        ddlRoleId.DataTextField = "RoleName";
                        ddlRoleId.DataSource = ds.Tables[0];
                        ddlRoleId.DataBind();
                        ddlRoleId.Items.Insert(0, "--Select--");
                        ddlRoleId.SelectedIndex = 0;
                    }
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }
        public string GenerateAutoPassword()
        {
            try
            {
                int i;
                int CharLength = Convert.ToInt16(ConfigurationSettings.AppSettings["CharLength"]);
                int SpecialCharLength = Convert.ToInt16(ConfigurationSettings.AppSettings["SpecialCharLength"]); ;
                int NumericLength = Convert.ToInt16(ConfigurationSettings.AppSettings["NumLength"]); ;

                string strPassword = "";
                Random Rn = new Random();

                for (i = 0; i < CharLength; i++)
                {
                    if (i == 0)
                    {
                        strPassword = strPassword + Convert.ToChar(Rn.Next(65, 90));
                    }
                    else
                    {
                        strPassword = strPassword + Convert.ToChar(Rn.Next(97, 122));
                    }
                }
                for (i = 0; i < SpecialCharLength; i++)
                {
                    strPassword = strPassword + Convert.ToChar(Rn.Next(64, 64));
                }
                for (i = 0; i < NumericLength; i++)
                {
                    strPassword = strPassword + Convert.ToChar(Rn.Next(48, 57));
                }

                return strPassword;
            }
            catch (Exception ex)
            {
                string st = ex.Message;
                return "";
            }
        }
        protected void GetUserDetails(string UserId)
        {
            lblMessage.Text = "";
            try
            {

                SqlConnection sqlCon = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
                SqlCommand cmd = new SqlCommand("LNT_GetUserDetails", sqlCon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@UserId", UserId);
                cmd.Parameters.AddWithValue("@ClientId", Session["ClientID"]);  
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adp.Fill(ds);
                //Changed on 22/07/2022
                //if (ds != null && ds.Tables.Count > 0)
                //{                   
                //        grv_GroupInfo.DataSource = ds;
                //        grv_GroupInfo.DataBind();                   

                //}
                //Added on 22/07/2022
                if (ds != null && ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows[0][0].ToString() == "TRUE")
                    {
                        grv_GroupInfo.DataSource = ds;
                        grv_GroupInfo.DataBind();
                        grv_GroupInfo.Visible = true;


                    }
                    else
                    {
                        grv_GroupInfo.Visible = false;
                        lblMessage.Text = ds.Tables[0].Rows[0]["MESSAGE"].ToString();

                    }

                }
            }
            catch (Exception ex)
            {

                ex.ToString();
                lblMessage.Visible = true;
                lblMessage.Text = ex.Message;
                lblMessage.CssClass = "ErrorMessage";
            }

        }

        protected void btnGo_Click(object sender, EventArgs e)
        {
            GetUserDetails(txtSearchUserID.Text);
        }

        protected void lnkAutoGenetae_Click(object sender, EventArgs e)
        {
            txtPassword.Text = GenerateAutoPassword();
        }

        protected void grv_GroupInfo_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes.Add("onclick", "javascript:Pro_SelectRow('" + e.Row.RowIndex + "','" + e.Row.Cells[0].Text + "')");
                e.Row.Attributes.Add("onmouseover", "javascript:hover('in','" + e.Row.RowIndex + "');");
                e.Row.Attributes.Add("onmouseout", "javascript:hover('out','" + e.Row.RowIndex + "');");
            }
        }
        private void Insert_UserInfo()
        {
            try
            {

                SqlConnection sqlCon = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);




                string msg = string.Empty;

                if (txtUserName.Text.Trim() == "" || txtUserName.Text.Trim() == null)
                {
                    msg = msg + "Employee Name Cannot be left Blank!,";
                }
                if (txtLoginName.Text.Trim() == "" || txtLoginName.Text.Trim() == null)
                {
                    msg = msg + "Employee Code Cannot be left Blank! ";
                }
                if (txtPassword.Text.Trim() == "" || txtPassword.Text.Trim() == null)
                {
                    msg = msg + "Password Cannot be left Blank!";
                }
                if (ddlRoleId.SelectedValue == "--Select--" || ddlRoleId.SelectedIndex == 0)
                {
                    msg = msg + "Please select RoleId  to Contine...!";
                }
                if (ddlRoleId.SelectedValue == "--Select--" || ddlRoleId.SelectedIndex == 0)
                {
                    msg = msg + "Please select Activate Status to Contine...!";
                }
                if (ddlReportingManager.SelectedValue == "--Select--" || ddlReportingManager.SelectedIndex == 0)
                {
                    msg = msg + "Please select Reporting Manager to Contine...!";
                }

                if (msg != "")
                {

                    //ClientScript.RegisterStartupScript(Page.GetType(), "mykey", "alert('" + msg + "');", true);
                    lblMessage.Text = msg;
                    return;
                }

                SqlCommand cmd = new SqlCommand("LNT_InsertUserMaster", sqlCon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID", Convert.ToInt32(hdnUserId.Value));
                cmd.Parameters.AddWithValue("@UserName", txtUserName.Text.Trim());
                cmd.Parameters.AddWithValue("@LoginName", txtLoginName.Text.Trim());
                cmd.Parameters.AddWithValue("@Password", CEncDec.Encrypt(txtPassword.Text.Trim(), txtPassword.Text.Trim()));
                cmd.Parameters.AddWithValue("@RoleID", ddlRoleId.SelectedValue);
                cmd.Parameters.AddWithValue("@IsActive", Convert.ToBoolean(ddlIsActivate.SelectedItem.Value));
                cmd.Parameters.AddWithValue("@CreateBy", Convert.ToString(Session["LoginName"]));
                cmd.Parameters.AddWithValue("@ClientID", Convert.ToString(Session["ClientID"]));
                cmd.Parameters.AddWithValue("@ReportingManager", ddlReportingManager.SelectedValue.ToString());

                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adp.Fill(ds);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    if (ds.Tables[0].Rows[0][0].ToString() == "TRUE")
                    {
                        lblMessage.Text = ds.Tables[0].Rows[0]["MESSAGE"].ToString();
                        GetUserDetails(txtLoginName.Text);
                        ClearAllText();
                    }
                    else
                    {
                        lblMessage.Text = ds.Tables[0].Rows[0]["MESSAGE"].ToString();
                    }

                }
                else
                {
                    lblMessage.Visible = true;
                    lblMessage.Text = "Error While Saving Record";
                }
            }
            catch (Exception ex)
            {
                lblMessage.Visible = true;
                lblMessage.Text = ex.Message;
                lblMessage.CssClass = "ErrorMessage";
            }
        }
        protected void ClearAllText()
        {
            txtUserName.Text = "";
            txtLoginName.Text = "";
            txtPassword.Text = "";
            ddlRoleId.SelectedIndex = 0;
            ddlIsActivate.SelectedIndex = 0;
            ddlReportingManager.SelectedIndex = 0;
            hdnUserId.Value = "0";
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            lblMessage.Text = "";
            Insert_UserInfo();
            
        }
        protected void btnAddNew_Click(object sender, EventArgs e)
        {
            lblMessage.Text = "";
            Insert_UserInfo(); 
        }
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            lblMessage.Text = "";
            ClearAllText();
            Response.Redirect("MenuPage.aspx", false);
        }

        protected void BindReportingManager()
        {
            try
            {
                SqlConnection sqlCon = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());

                SqlCommand sqlCom = new SqlCommand();
                sqlCom.Connection = sqlCon;
                sqlCom.CommandType = CommandType.StoredProcedure;
                sqlCom.CommandText = "LNT_BindReportingManagerList_SP";
                sqlCom.CommandTimeout = 0;

                SqlDataAdapter da = new SqlDataAdapter(sqlCom);
                DataSet ds = new DataSet();
                da.Fill(ds);

                if (ds != null && ds.Tables.Count > 0)
                {

                    ddlReportingManager.DataValueField = "UserId";
                    ddlReportingManager.DataTextField = "UserName";
                    ddlReportingManager.DataSource = ds.Tables[0];
                    ddlReportingManager.DataBind();

                    ddlReportingManager.Items.Insert(0, "--Select--");
                    ddlReportingManager.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
            }
        }
    }
}