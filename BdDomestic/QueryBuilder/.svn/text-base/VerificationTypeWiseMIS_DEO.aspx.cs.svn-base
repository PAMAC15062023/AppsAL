using System;
using System.Data;
using System.Data.OleDb;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.IO;
using System.Text;
using System.Configuration.Assemblies;

public partial class QueryBuilder_VerificationTypeWiseMIS_DEO : System.Web.UI.Page
{
    public string CenterId = "";
    public string ClientId = "";
    C_QuerryBuilder_MIS_FE obj = new C_QuerryBuilder_MIS_FE();
    protected void Page_Load(object sender, EventArgs e)
    {
        //Description   :  This Code is used To distingusish Repository PMS Database and PMS.
        //Created By    :  Gargi Srivastava
        //Created On    :  23-Nov-2007
        Session["DataBase"] = ddlDataBase.SelectedValue.ToString();
        //End Of Code
        lblMsg.Text = "";
        DataTable dtCentre = new DataTable();  
        if (!IsPostBack)
        {

            string UserId = Session["UserId"].ToString();
            dtCentre = obj.GetCenter(UserId);
            ViewState["ClientId"] = ClientId;
            ddlCentre.DataSource = dtCentre;
            ddlCentre.DataTextField = "CENTRE_NAME";
            ddlCentre.DataValueField = "CENTRE_ID";
            ddlCentre.DataBind();

            DataTable dtAllDEO = new DataTable();
            dtAllDEO = obj.AllDEO();
            ListBoxFE.DataSource = dtAllDEO;
            ListBoxFE.DataTextField = "Name";
            ListBoxFE.DataValueField = "USER_ID";
            ListBoxFE.DataBind();

            ListBoxFE.SelectedValue = "0";
            ListBoxVerificationType.SelectedValue = "0";
        }

    }
    protected void btnReport_Click1(object sender, EventArgs e)
    {
        string Fe_Id = "";
        string VerificationTypeId="";
        CCommon ObjCmn = new CCommon();

        try
        {
            obj.FromDate = ObjCmn.string_mm_dd_yy(txtFromDate.Text);
            string TDate = ObjCmn.string_mm_dd_yy(txtToDate.Text);
            string ToDate = Convert.ToDateTime(TDate).AddDays(1.0).ToString("dd/MM/yyyy");
            obj.ToDate = ObjCmn.string_mm_dd_yy(ToDate);

            string Fdate = ObjCmn.string_mm_dd_yy(txtFromDate.Text);
            string Tdate = ToDate;

           if (ListBoxFE.SelectedValue == "" || ListBoxFE.SelectedValue == null || ListBoxFE.SelectedValue == "0")
            {
                for (int i = 1; i < ListBoxFE.Items.Count; i++)
                {
                    //if (ListBoxFE.Items[i].Selected == true)
                    //{
                        Fe_Id = Fe_Id + ListBoxFE.Items[i].Value + ",";
                    //}
                }
                Fe_Id = Fe_Id.TrimEnd(',');
            }
            else
            {
                for (int i = 1; i < ListBoxFE.Items.Count; i++)
                {
                    if (ListBoxFE.Items[i].Selected == true)
                    {
                        Fe_Id = Fe_Id + ListBoxFE.Items[i].Value + ",";
                    }
                }
                Fe_Id = Fe_Id.TrimEnd(',');
            }

            if (ListBoxVerificationType.SelectedValue == "" || ListBoxVerificationType.SelectedValue == null || ListBoxVerificationType.SelectedValue == "0")
            {
                VerificationTypeId = obj.All_VerificationType_Id();
            }
            else
            {
                for (int i = 0; i < ListBoxVerificationType.Items.Count; i++)
                {
                    if (ListBoxVerificationType.Items[i].Selected == true)
                    {
                        VerificationTypeId = VerificationTypeId + ListBoxVerificationType.Items[i].Value + ",";
                    }
                }
                VerificationTypeId = VerificationTypeId.TrimEnd(',');
            }

            //string strListBox_ID = "";
            //for (int count = 1; count < ListBoxFE.Items.Count; count++)
            //{
            //    strListBox_ID = strListBox_ID + ListBoxFE.Items[count].Value+',';
            //}
            //strListBox_ID = strListBox_ID.TrimEnd(',');




            DataTable dt = new DataTable();
            if (Fe_Id != "")
            {
                dt = obj.rpt_VerificationTypeWise_MIS(Fe_Id, VerificationTypeId);
            }
            else
            {
                //lblMsg.Visible = true;
                //lblMsg.Text = "There is no FE to display record !!";
            }
            
            if (dt.Rows.Count > 0)
            {
                tbl.Visible = true;
                gvVerificationTypeWise.DataSource = dt;
                gvVerificationTypeWise.DataBind();
                lbl.Text = "";

                gvExport.DataSource = dt;
                gvExport.DataBind();
                lblFromDate.Text = txtFromDate.Text;
                lblToDate.Text = txtToDate.Text;
                
                //lblFE.Text = ListBoxFE.SelectedItem.Text.ToString();
                //lblVerificationType.Text = ListBoxVerificationType.SelectedItem.Text.ToString();
            }
            else
            {
                gvVerificationTypeWise.DataSource = "";
                gvVerificationTypeWise.DataBind();
                tbl.Visible = false;
                lbl.Visible = true;
                lbl.Text = " No Record Is Available !!";
            }
        }
        catch (Exception ex)
        {
            lblMsg.Visible = true;
            lblMsg.Text = ex.Message.ToString();
        }

    }
    protected void btnExport_Click(object sender, EventArgs e)
    {
        tblExport.Visible = true;
        string attachment = "attachment; filename=VerificationTypeWiseMIS.xls";
        Response.ClearContent();
        Response.AddHeader("content-disposition", attachment);
        Response.ContentType = "application/ms-excel";
        StringWriter sw = new StringWriter();
        HtmlTextWriter htw = new HtmlTextWriter(sw);
        gvExport.GridLines = GridLines.Both;
        tblExport.RenderControl(htw);
        Response.Write(sw.ToString());
        Response.End(); 
    }
    public override void VerifyRenderingInServerForm(Control control)
    {

    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("VerificationTypeWiseMIS_DEO.aspx");
        //ListBoxFE.SelectedValue="0";
        //ListBoxVerificationType.SelectedValue = "0";
    }
    protected void ddlCentre_SelectedIndexChanged(object sender, EventArgs e)
    {
        ListBoxFE.DataSource = SqlDataSourceDE_CentreWise;
        ListBoxFE.DataTextField = "Name";
        ListBoxFE.DataValueField = "USER_ID";
        ListBoxFE.DataBind();

        ListBoxFE.SelectedValue = "0";
        ListBoxVerificationType.SelectedValue = "0";

    }
    protected void Button1_Click(object sender, EventArgs e)
    {

    }
}
