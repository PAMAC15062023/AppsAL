using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LNTFinance.Pages
{
    public partial class LNT_ManageEmailID : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetEmailIDs();
                BindRecipient();
                BindActive();
            }
        }

        protected void GetEmailIDs()
        {
            SqlConnection sqlCon = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);

            SqlCommand sqlCom = new SqlCommand();
            sqlCom.Connection = sqlCon;
            sqlCom.CommandType = CommandType.StoredProcedure;
            sqlCom.CommandText = "LNT_GetEmailIDs_SP";
            sqlCom.CommandTimeout = 0;

            sqlCon.Open();

            SqlDataAdapter sqlDA = new SqlDataAdapter();
            sqlDA.SelectCommand = sqlCom;

            DataTable dt = new DataTable();
            sqlDA.Fill(dt);

            sqlCon.Close();

            if (dt.Rows.Count > 0)
            {
                gvListOfEmailIDs.DataSource = dt;
                gvListOfEmailIDs.DataBind();

                gvListOfEmailIDs.Rows[0].Cells[0].Enabled = false;
                gvListOfEmailIDs.Rows[0].Cells[1].Enabled = false;
            }
            else
            {
                gvListOfEmailIDs.DataSource = null;
                gvListOfEmailIDs.DataBind();

                lblMsgXls.Visible = true;
                lblMsgXls.Text = "No Email IDs Found";
            }
        }
        protected bool SaveData()
        {
            string msg = string.Empty;
            bool validation = false;
            bool status = false;

            if (txtName.Text.Trim() == "" || txtName.Text.Trim() == null)
            {
                msg = msg + "Please Enter Employee Name";
            }
            if (txtMailID.Text.Trim() == "" || txtMailID.Text.Trim() == null)
            {
                msg = msg + "Please Enter Email ID";
            }
            if (ddlActive.SelectedValue == "--Select--")
            {
                msg = msg + "Please Select Status ";
            }
            if (ddlRecipient.SelectedValue == "--Select--")
            {
                msg = msg + "Please Select Recipient ";
            }
            if (msg != "")
            {
                validation = false;
                ClientScript.RegisterStartupScript(Page.GetType(), "mykey", "alert('" + msg + "');", true);
                return validation;
            }
            SqlConnection sqlCon = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);

            SqlCommand cmd = new SqlCommand("LNT_ManageEmailID_SP", sqlCon);
            cmd.CommandType = CommandType.StoredProcedure;
            //cmd.Parameters.AddWithValue("@ID", Convert.ToInt32(hdnAuditID.Value));
            cmd.Parameters.AddWithValue("@EmpName", txtName.Text);
            cmd.Parameters.AddWithValue("@EmailID", txtMailID.Text);
            cmd.Parameters.AddWithValue("@Recipient", ddlRecipient.SelectedItem.Text);
            if (ddlActive.SelectedItem.Text == "Active")
            {
                status = true;
            }
            cmd.Parameters.AddWithValue("@Status", status);
            cmd.Parameters.AddWithValue("@UserID", Convert.ToString(Session["LoginName"]));


            sqlCon.Open();
            int result = cmd.ExecuteNonQuery();
            sqlCon.Close();

            if (result > 0)
            {
                lblMsgXls.Visible = true;
                lblMsgXls.Text = "Data Saved Successfully!!";
                validation = true;
            }
            return validation;
        }

        protected void ClearData()
        {
            txtName.Text = "";
            txtMailID.Text = "";
            ddlActive.SelectedIndex = 0;
            ddlRecipient.SelectedIndex = 0;
            hdnID.Value = "0";
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (Session["LoginName"] != null)
            {
                bool result = SaveData();
                if (result)
                {
                    ClearData();
                    GetEmailIDs();
                }
                else
                {
                    Session.Clear();
                    //Response.Redirect("LoginPage.aspx", false);
                }
            }
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("MenuPage.aspx", false);
        }

       
        protected void lkbtnEdit_Click(object sender, EventArgs e)
        {
            lblMsgXls.Text = "";
            try
            {
                for (int i = 0; i <= gvListOfEmailIDs.Rows.Count - 1; i++)
                {
                    CheckBox chkSelect = (CheckBox)gvListOfEmailIDs.Rows[i].FindControl("chkbox");
                    LinkButton WIP = (LinkButton)gvListOfEmailIDs.Rows[i].FindControl("lkbtnEdit");
                    lblMsgXls.Text = "";

                    if (chkSelect.Checked == true)
                    {
                        hdnID.Value = gvListOfEmailIDs.DataKeys[i].Value.ToString();
                        txtName.Text = gvListOfEmailIDs.Rows[i].Cells[1].Text.Trim();
                        txtMailID.Text = gvListOfEmailIDs.Rows[i].Cells[2].Text.Trim();
                        ddlRecipient.SelectedValue = gvListOfEmailIDs.Rows[i].Cells[3].Text.Trim();
                        ddlActive.SelectedValue = gvListOfEmailIDs.Rows[i].Cells[4].Text.Trim();
                        break;
                    }
                    else
                    {
                        lblMsgXls.Visible = true;
                        lblMsgXls.Text = "Please select atleast one record";
                    }
                }
            }
            catch (Exception ex)
            {
                lblMsgXls.Visible = true;
                lblMsgXls.Text = "Error :" + ex.Message;
            }
        }
        private void BindRecipient()
        {
            DataTable Recipientdt = new DataTable();

            Recipientdt.Columns.Add("RecipientId", typeof(int));
            Recipientdt.Columns.Add("RecipientName");

            Recipientdt.Rows.Add(1, "To");
            Recipientdt.Rows.Add(2, "CC");

            ddlRecipient.DataSource = Recipientdt;

            ddlRecipient.DataTextField = "RecipientName";
            ddlRecipient.DataValueField = "RecipientName";
            ddlRecipient.DataBind();
            ddlRecipient.Items.Insert(0, "--Select--");
            ddlRecipient.SelectedIndex = 0;
        }
        private void BindActive()
        {
            DataTable Activedt = new DataTable();

            Activedt.Columns.Add("ActiveId", typeof(int));
            Activedt.Columns.Add("ActiveName");

            Activedt.Rows.Add(1, "Active");
            Activedt.Rows.Add(2, "Deactive");

            ddlActive.DataSource = Activedt;

            ddlActive.DataTextField = "ActiveName";
            ddlActive.DataValueField = "ActiveName";
            ddlActive.DataBind();
            ddlActive.Items.Insert(0, "--Select--");
            ddlActive.SelectedIndex = 0;
        }

    }
}