using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IncidentTracker.Pages
{
    public partial class IT_ReturnFromApprover : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindReturnFromApprover();
            }
        }
        protected void BindReturnFromApprover()
        {
            try
            {
                SqlConnection sqlCon = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);

                SqlCommand sqlCom = new SqlCommand();
                sqlCom.Connection = sqlCon;
                sqlCom.CommandType = CommandType.StoredProcedure;
                sqlCom.CommandText = "IT_BindReturnFromApprover_SP";
                sqlCom.CommandTimeout = 0;

                sqlCon.Open();
                SqlDataAdapter sqlDA = new SqlDataAdapter();
                sqlDA.SelectCommand = sqlCom;
                DataTable dt = new DataTable();
                sqlDA.Fill(dt);

                sqlCon.Close();

                if (dt.Rows.Count > 0)
                {
                    gvData.DataSource = dt;
                    gvData.DataBind();
                }
                else
                {
                    gvData.DataSource = null;
                    gvData.DataBind();

                    lblMsgXls.Visible = true;
                    lblMsgXls.Text = "No Case Found";
                }
            }
            catch (Exception ex)
            {

                lblMsgXls.Text = ex.ToString();
            }
        }
        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("IT_MenuPage.aspx", true);
        }

        protected void lnkWIP_Click(object sender, EventArgs e)
        {
            lblMsgXls.Text = "";
            try
            {
                for (int i = 0; i <= gvData.Rows.Count - 1; i++)
                {
                    CheckBox chkSelect = (CheckBox)gvData.Rows[i].FindControl("chkSelect");

                    LinkButton WIP = (LinkButton)gvData.Rows[i].FindControl("lnkWIP");

                    if (chkSelect.Checked == true)
                    {
                        ViewState["IncidentNumber"] = gvData.Rows[i].Cells[3].Text.Trim();

                        string IncidentNumber = gvData.Rows[i].Cells[3].Text.Trim();

                        Response.Redirect("IT_IncidentTicketsMaker.aspx?IncidentNumber=" + IncidentNumber);
                    }
                    else
                    {
                        lblMsgXls.Visible = true;
                        lblMsgXls.Text = "Error :";
                    }
                }
            }
            catch (Exception ex)
            {
                lblMsgXls.Visible = true;
                lblMsgXls.Text = "Error :" + ex.Message;
            }
        }
    }
}