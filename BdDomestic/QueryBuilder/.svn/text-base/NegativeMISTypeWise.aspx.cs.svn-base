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
using CrystalDecisions.Shared;
using CrystalDecisions.CrystalReports.Engine;
using System.IO;

public partial class QueryBuilder_NegativeMISTypeWise : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //Description   :  This Code is used To distingusish Repository PMS Database and PMS.
        //Created By    :  Gargi Srivastava
        //Created On    :  23-Nov-2007
        Session["DataBase"] = ddlDataBase.SelectedValue.ToString();
        //End Of Code
        if (!IsPostBack)
        {
            try
            {
                DataTable dt = new DataTable();
                C_QueryBuilderTAT obj = new C_QueryBuilderTAT();
                string UserId = Session["UserId"].ToString();
                string CenterId = obj.GetCenter(UserId);
                dt = obj.Centers(CenterId);
                ddlCentre.DataSource = dt;
                ddlCentre.DataTextField = "CENTRE_NAME";
                ddlCentre.DataValueField = "CENTRE_ID";
                ddlCentre.DataBind();
            }
            catch (Exception ex)
            {
                LblMsg.Visible = true;
                LblMsg.Text = ex.Message.ToString();
            }
        }

    }
    protected void btnReport_Click(object sender, EventArgs e)
    {
        try
        {
            C_QueryBuilder_NegativeMIS obj = new C_QueryBuilder_NegativeMIS();
            CCommon ObjCmn = new CCommon();
            obj.FromDate = ObjCmn.string_mm_dd_yy(txtFromDate.Text);
            string TDate = ObjCmn.string_mm_dd_yy(txtToDate.Text);
            string ToDate = Convert.ToDateTime(TDate).AddDays(1.0).ToString("dd/MM/yyyy");
            obj.ToDate = ObjCmn.string_mm_dd_yy(ToDate);

            DataTable dt = new DataTable();
            dt= obj.NegativeMISReport(ddlCentre.SelectedItem.Value);            

            if (dt.Rows.Count > 0)
            {
                tbl.Visible = true;
                gvNegativeMIS.DataSource = dt;
                gvNegativeMIS.DataBind();
                LblMsg.Text = "";
                gvExport.DataSource = dt;
                gvExport.DataBind();
                lblFromDate.Text = txtFromDate.Text;
                lblToDate.Text = txtToDate.Text;
                lblCentre.Text = ddlCentre.SelectedItem.Text;
            }
            else
            {
                LblMsg.Visible = true;
                LblMsg.Text = "There is no record to display";
                tbl.Visible = false;
                gvNegativeMIS.DataSource = "";
                gvNegativeMIS.DataBind();
            }
            //gvNegativeMIS.DataBind();

            //ParameterField pf1 = new ParameterField();
            //ParameterField pf2 = new ParameterField();
            //ParameterField pf3 = new ParameterField();
            //ParameterField pf4 = new ParameterField();
            //ParameterField pf5 = new ParameterField();


            //ParameterDiscreteValue pd1 = new ParameterDiscreteValue();
            //ParameterDiscreteValue pd2 = new ParameterDiscreteValue();
            //ParameterDiscreteValue pd3 = new ParameterDiscreteValue();
            //ParameterDiscreteValue pd4 = new ParameterDiscreteValue();
            //ParameterDiscreteValue pd5 = new ParameterDiscreteValue();

            //ParameterFields pfs = new ParameterFields();

            //pf1.Name = "@FROMDATE";
            //pd1.Value = obj.FromDate;
            //pf1.CurrentValues.Add(pd1);
            //pfs.Add(pf1);

            //pf2.Name = "@TODATE";
            //pd2.Value = obj.ToDate ;
            //pf2.CurrentValues.Add(pd2);
            //pfs.Add(pf2);


            //pf3.Name = "@CentreId";
            //pd3.Value = ddlCentre.SelectedItem.Value;
            //pf3.CurrentValues.Add(pd3);
            //pfs.Add(pf3);

            //pf4.Name = "Fdate_display";
            //pd4.Value = txtToDate.Text;
            //pf4.CurrentValues.Add(pd4);
            //pfs.Add(pf4);

            //pf5.Name = "ToDate_display";
            //pd5.Value = txtToDate.Text;
            //pf5.CurrentValues.Add(pd5);
            //pfs.Add(pf5);

            //Session["Parameterfields"] = pfs;
            //Session["rptName"] = "rptNegativeMIS.rpt";
            //Response.Redirect("QueryBuilderReports.aspx");
        }
        catch (Exception ex)
        {
            LblMsg.Visible = true;
            LblMsg.Text = ex.Message.ToString();
        }

    }
    protected void btnExptExcel_Click(object sender, EventArgs e)
    {
        tblExport.Visible = true;
        string attachment = "attachment; filename=NegativeMIS.xls";
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
        Response.Redirect("NegativeMISTypeWise.aspx");
    }
}
