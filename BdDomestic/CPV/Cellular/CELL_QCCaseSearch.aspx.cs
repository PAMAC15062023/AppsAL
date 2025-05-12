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


public partial class CPV_Cellular_CELL_QCCaseSearch : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["isView"].ToString() != "1")
            Response.Redirect("NoAccess.aspx");
        //if (Session["isDelete"].ToString() != "1")
        //    Response.Redirect("NoAccess.aspx");
    }
    protected void btnsearch_Click(object sender, EventArgs e)
    {
        string strSelectCriteria = "";
        string strsql = "";
        if (txtMobNo.Text != "")
        {
            strSelectCriteria += " AND Cell.CELLNO='" + txtMobNo.Text.Trim() + "'";
        }
        if (txtCanNo.Text != "")
        {
            strSelectCriteria += " AND Qc.ref_no= '" + txtCanNo.Text.Trim() + "'  ";
        }
        if (txtApplName.Text != "")
        {
            if (chkName.Checked)
                strSelectCriteria += "  AND (ISNULL(Cell.APP_FNAME+ ' ', '') +ISNULL(Cell.APP_MNAME + ' ', '') + ISNULL(Cell.APP_LNAME + ' ', '')='" + txtApplName.Text.Trim().ToString().Replace("'", "") + "')";
            else
                strSelectCriteria += " AND (ISNULL(Cell.APP_FNAME + ' ', '') +ISNULL(Cell.APP_MNAME + ' ', '') + ISNULL(Cell.APP_LNAME + ' ', '') Like'%" + txtApplName.Text.Trim().ToString().Replace("'", "") + "%')";
        }
        strsql = "select Qc.case_id, Cell.CELLNO, ISNULL(Cell.APP_FNAME,'') + ' ' + ISNULL(Cell.APP_MNAME,'') + ' ' + ISNULL(Cell.APP_LNAME,'') AS  [Applicant Name]," +
                "Qc.Ref_No as [Can No] from CPV_CELLULAR_CASES Cell left outer join cpv_qc_case_details Qc On Cell.case_id=Qc.case_id WHERE 1=1  " + strSelectCriteria + " " +
                " AND CLUSTER_ID='" + HttpContext.Current.Session["ClusterId"] + "'" +
                " AND Qc.CENTRE_ID='" + HttpContext.Current.Session["CentreId"] + "'" + " AND Qc.CLIENT_ID='" + HttpContext.Current.Session["ClientId"] + "'";
        sdsgv.SelectCommand = strsql;
        GridView1.DataBind();
        if (GridView1.Rows.Count <= 0)
        {
            lblmsg.Text = "No record found";
        }
    }
    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName.Equals("Select"))
        {
            string caseID = e.CommandArgument.ToString();

            if (caseID != null && caseID != "")
            {
                Response.Redirect("CEL_QCCellular_Verification_Entry.aspx?CaseID=" + caseID + "&Mode=View");
            }
        }

    }
}
