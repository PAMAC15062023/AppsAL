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

public partial class QueryBuilder_TatAnalysisClientWise : System.Web.UI.Page
{
    public DataTable dtMIS = new DataTable();
    C_QueryBuilderTAT obj = new C_QueryBuilderTAT();
    public string CenterId = "";
    public string ClientId = "";
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
                if (Session["UserId"].ToString() != "" || Session["UserId"].ToString()!=null)
                {
                    string UserId = Session["UserId"].ToString();
                    CenterId = obj.GetCenter(UserId);
                    ClientId = obj.GetClientId(CenterId);
                    ViewState["ClientId"] = ClientId;
                    ViewState["CenterId"] = CenterId;
                }
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
        CCommon ObjCmn = new CCommon();
        try
        {
            obj.FromDate = ObjCmn.string_mm_dd_yy(txtFromDate.Text);
            string TDate = ObjCmn.string_mm_dd_yy(txtToDate.Text);
            string ToDate = Convert.ToDateTime(TDate).AddDays(1.0).ToString("dd/MM/yyyy");
            obj.ToDate = ObjCmn.string_mm_dd_yy(ToDate);

            DataTable dt = new DataTable();
            dt= obj.rptClient_CentreWise(ViewState["ClientId"].ToString(), ViewState["CenterId"].ToString());
            if (dt.Rows.Count > 0)
            {
                tbl.Visible = true;
                gvClientWise.DataSource = dt;
                gvClientWise.DataBind();

                lblFromDate.Text = txtFromDate.Text;
                lblToDate.Text = txtToDate.Text;
                gvExport.DataSource = dt;
                gvExport.DataBind();
            }
            else
            {
                tbl.Visible = true;
                gvClientWise.DataSource = "";
                gvClientWise.DataBind();
            }

            //ParameterField pf1 = new ParameterField();
            //ParameterField pf2 = new ParameterField();
            //ParameterField pf3 = new ParameterField();
            //ParameterField pf4 = new ParameterField();
            //ParameterField pf5 = new ParameterField();
            //ParameterField pf6 = new ParameterField();

            //ParameterDiscreteValue pd1 = new ParameterDiscreteValue();
            //ParameterDiscreteValue pd2 = new ParameterDiscreteValue();
            //ParameterDiscreteValue pd3 = new ParameterDiscreteValue();
            //ParameterDiscreteValue pd4 = new ParameterDiscreteValue();
            //ParameterDiscreteValue pd5 = new ParameterDiscreteValue();
            //ParameterDiscreteValue pd6 = new ParameterDiscreteValue();
            //ParameterFields pfs = new ParameterFields();

            //pf1.Name = "@FromDate";
            //pd1.Value = "'" + Fdate + "'";
            //pf1.CurrentValues.Add(pd1);
            //pfs.Add(pf1);

            //pf2.Name = "@ToDate";
            //pd2.Value = "'" + Tdate + "'";
            //pf2.CurrentValues.Add(pd2);
            //pfs.Add(pf2);

            //pf3.Name = "@ClientId";
            //pd3.Value = ViewState["ClientId"].ToString();
            //pf3.CurrentValues.Add(pd3);
            //pfs.Add(pf3);

            //pf4.Name = "@CenterId";
            //pd4.Value = ViewState["CenterId"].ToString();
            //pf4.CurrentValues.Add(pd4);
            //pfs.Add(pf4);
            
            //pf5.Name = "Fdate";
            //pd5.Value = txtFromDate.Text;
            //pf5.CurrentValues.Add(pd5);
            //pfs.Add(pf5);
            
            //pf6.Name = "Todate";
            //pd6.Value = txtToDate.Text;
            //pf6.CurrentValues.Add(pd6);
            //pfs.Add(pf6);

            //Session["Parameterfields"] = pfs;
            //Session["rptName"] = "rptClient.rpt";//"rptTatCentre+Client_DateWise.rpt";
            //Response.Redirect("QueryBuilderReports.aspx");
        }
        catch (Exception ex)
        {
            LblMsg.Visible = true;
            LblMsg.Text= ex.Message.ToString();
        }
    }
    protected void btnExport_Click(object sender, EventArgs e)
    {
        tblExport.Visible = true;
        string attachment = "attachment; filename=TAT Analysis ClientWise.xls";
        Response.ClearContent();
        Response.AddHeader("content-disposition", attachment);
        Response.ContentType = "application/ms-excel";
        StringWriter sw = new StringWriter();

        HtmlTextWriter htw = new HtmlTextWriter(sw);

        //gvTATMIS.RenderControl(htw);
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
        Response.Redirect("TatAnalysisClientWise.aspx");
    }
}
