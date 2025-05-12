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
using System.Data.OleDb;

public partial class CPV_CC_CC_FE_Login_View : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        FillView();
    }
    public void FillView()
    {
        sdsGV.SelectCommand = "select cd.case_id as CaseID,VTM.VERIFICATION_TYPE_CODE AS [Verification Type], cd.ref_no as [Ref No.],(ISNULL(CD.FIRST_NAME + ' ', '') +ISNULL" +
                               "(CD.MIDDLE_NAME + ' ', '') + ISNULL(CD.LAST_NAME + ' ', '')) as [Applicant Name]" +
                               "from CPV_CC_CASE_DETAILS CD left outer join CPV_CC_FE_CASE_MAPPING FM right outer join VERIFICATION_TYPE_MASTER VTM on(VTM.VERIFICATION_TYPE_ID=FM.VERIFICATION_TYPE_ID)" +
                               "on(fm.case_id=cd.case_id) where fm.FE_ID=" + Session["UserId"].ToString() + " and cd.CENTRE_ID=" + Session["CentreId"].ToString() + " and cd.CLIENT_ID=" + Session["ClientId"].ToString() + "";
        FEgv.DataBind();
        if (FEgv.Rows.Count <= 0)
        {
            lblmsg.Visible = true;
            lblmsg.Text = "No record found.";
        }
    }
}
