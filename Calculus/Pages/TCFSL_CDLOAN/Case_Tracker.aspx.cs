using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.Drawing;

public partial class Pages_TCFSL_CDLOAN_Case_Tracker : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        GetDetails_Screen();
    }

    public void GetDetails_Screen()
    {
        try
        {
            Object SaveUSERInfo = (Object)Session["UserInfo"];
            SqlConnection sqlcon = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);
            sqlcon.Open();
            SqlCommand sqlcom = new SqlCommand("TCFSL__Case_Search_CD_Loan_SP", sqlcon); //("Case_search_cdloan", sqlcon)
            sqlcom.CommandType = CommandType.StoredProcedure;
            sqlcom.Parameters.AddWithValue("@Webtop_Id", txtWebtopId.Text.ToString().Trim());
            SqlDataAdapter da = new SqlDataAdapter(sqlcom);
            DataTable dt = new DataTable();
            da.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                grdScreen.DataSource = dt;
                grdScreen.DataBind();

                for (int i = 0; i < dt.Rows.Count; i++)
                {


                    Label lblCaseNo = grdScreen.Rows[i].FindControl("lblCaseNo") as Label;
                    Label lblWebtopId = grdScreen.Rows[i].FindControl("lblWebtopId") as Label;
                    Label lblApplicationNo = grdScreen.Rows[i].FindControl("lblApplicationNo") as Label;
                    Label lblSreeningUser = grdScreen.Rows[i].FindControl("lblSreeningUser") as Label;
                    Label lblSreeningInprocessDate = grdScreen.Rows[i].FindControl("lblSreeningInprocessDate") as Label;
                    Label lblSreeningStatus = grdScreen.Rows[i].FindControl("lblSreeningStatus") as Label;
                    Label lblSreeningDate = grdScreen.Rows[i].FindControl("lblSreeningDate") as Label;

                    Label lblQCscreenUser = grdScreen.Rows[i].FindControl("lblQCscreenUser") as Label;
                    Label lblQCscreenInprocessTime = grdScreen.Rows[i].FindControl("lblQCscreenInprocessTime") as Label;
                    Label lblQCscreenStatus = grdScreen.Rows[i].FindControl("lblQCscreenStatus") as Label;
                    Label lblQCscreenDateTime = grdScreen.Rows[i].FindControl("lblQCscreenDateTime") as Label;

                    Label lblMakerUser = grdScreen.Rows[i].FindControl("lblMakerUser") as Label;
                    Label lblMakerInprocessDate = grdScreen.Rows[i].FindControl("lblMakerInprocessDate") as Label;
                    Label lblMakerStatus = grdScreen.Rows[i].FindControl("lblMakerStatus") as Label;
                    Label lblMakerDateTime = grdScreen.Rows[i].FindControl("lblMakerDateTime") as Label;

                    Label lblAuthor = grdScreen.Rows[i].FindControl("lblAuthor") as Label;
                    Label lblAuthorDate = grdScreen.Rows[i].FindControl("lblAuthorDate") as Label;
                    Label llblAuthorStatus = grdScreen.Rows[i].FindControl("llblAuthorStatus") as Label;
                    Label lblAuthorDateTime = grdScreen.Rows[i].FindControl("lblAuthorDateTime") as Label;


                    lblCaseNo.Text = "Case Number : " + dt.Rows[i]["Case Number"].ToString();
                    lblCaseNo.ForeColor = System.Drawing.Color.White;
                    lblWebtopId.Text = "Webtop Id : " + dt.Rows[i]["WEBTOP #"].ToString();
                    lblWebtopId.ForeColor = System.Drawing.Color.White;
                    lblApplicationNo.Text = "Application Number : " + dt.Rows[i]["FinnOneApplication Number"].ToString();
                    lblApplicationNo.ForeColor = System.Drawing.Color.White;

                    lblSreeningUser.Text = dt.Rows[i]["Screening User Name"].ToString();
                    lblSreeningInprocessDate.Text = dt.Rows[i]["Screening Start Date & Time"].ToString();
                    lblSreeningStatus.Text = dt.Rows[i]["SFDC Status"].ToString();
                    lblSreeningDate.Text = dt.Rows[i]["Screening Completed Date & Time"].ToString();

                    lblQCscreenUser.Text = dt.Rows[i]["Screening QC User Name"].ToString();
                    lblQCscreenInprocessTime.Text = dt.Rows[i]["Screening QC Start Date & Time"].ToString();
                    lblQCscreenStatus.Text = dt.Rows[i]["QC Status"].ToString();
                    lblQCscreenDateTime.Text = dt.Rows[i]["Screening QC Completed Date & Time"].ToString();

                    lblMakerUser.Text = dt.Rows[i]["Maker User Name"].ToString();
                    lblMakerInprocessDate.Text = dt.Rows[i]["Maker Start Date & Time"].ToString();
                    lblMakerStatus.Text = dt.Rows[i]["FINONE Maker Status"].ToString();
                    lblMakerDateTime.Text = dt.Rows[i]["Maker Complete Date & Time"].ToString();

                    lblAuthor.Text = dt.Rows[i]["Author User Name"].ToString();
                    lblAuthorDate.Text = dt.Rows[i]["Author Start Date & Time"].ToString();
                    llblAuthorStatus.Text = dt.Rows[i]["FINONE Author Status"].ToString();
                    lblAuthorDateTime.Text = dt.Rows[i]["Author Complete Date & Time"].ToString();

                    
                }
            }
            else
            {

                lblMessage.Text = "No Record Found";
                lblMessage.Visible = true;
            }
            sqlcon.Close();

        }
        catch (Exception ex)
        {
            lblMessage.Visible = true;
            lblMessage.Text = ex.Message;
        }


    }

    protected void ButnCancel0_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Pages/Menu.aspx", true);
    }
}