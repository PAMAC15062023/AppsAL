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
public partial class QueryBuilder_TatAnalysisClient_MonthWise : System.Web.UI.Page
{
    C_QueryBuilderTAT obj = new C_QueryBuilderTAT();
    public string CenterId = "";
    public string ClientId = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            string UserId = Session["UserId"].ToString();
            CenterId = obj.GetCenter(UserId);
            ClientId = obj.GetClientId(CenterId);
            ViewState["ClientId"] = ClientId;
        }
    }
    protected void btnReport_Click(object sender, EventArgs e)
    {
        CCommon ObjCommon = new CCommon();
        obj.rptClient_Centre_MonthWise(txtFromDate.Text, txtToDate.Text, ViewState["ClientId"].ToString());
        string Fdate = ObjCommon.string_mm_dd_yy(txtFromDate.Text);
        string Tdate = ObjCommon.string_mm_dd_yy(txtToDate.Text);

        ParameterField pf1 = new ParameterField();
        ParameterField pf2 = new ParameterField();
        ParameterField pf3 = new ParameterField();

        ParameterDiscreteValue pd1 = new ParameterDiscreteValue();
        ParameterDiscreteValue pd2 = new ParameterDiscreteValue();
        ParameterDiscreteValue pd3 = new ParameterDiscreteValue();
        ParameterFields pfs = new ParameterFields();

        pf1.Name = "@FromDate";
        pd1.Value = "'" + Fdate + "'";
        pf1.CurrentValues.Add(pd1);
        pfs.Add(pf1);

        pf2.Name = "@ToDate";
        pd2.Value = "'" + Tdate + "'";
        pf2.CurrentValues.Add(pd2);
        pfs.Add(pf2);

        pf3.Name = "@ClientId";
        pd3.Value = ViewState["ClientId"].ToString();
        pf3.CurrentValues.Add(pd3);
        pfs.Add(pf3);

        Session["Parameterfields"] = pfs;
        Session["rptName"] = "rptTatAnalysisClient_MonthWise.rpt";
        Response.Redirect("QueryBuilderReports.aspx");
    }
}
