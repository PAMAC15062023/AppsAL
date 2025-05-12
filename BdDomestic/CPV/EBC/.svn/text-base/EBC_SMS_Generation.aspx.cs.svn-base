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

public partial class CPV_EBC_EBC_SMS_Generation : System.Web.UI.Page
{
    C_Sms_Generation obj_GenerateSms = new C_Sms_Generation();
    CCommon connobj = new CCommon();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DataSet ds = new DataSet();
            string activityid = Session["ActivityId"].ToString();
            ds = obj_GenerateSms.GetVerificationType_EBC(activityid);
            ddlVerificationId.DataTextField = "VERIFICATION_TYPE_CODE";
            ddlVerificationId.DataValueField = "VERIFICATION_TYPE_ID";
            ddlVerificationId.DataSource = ds;
            ddlVerificationId.DataBind();
        }

    }
    protected void ddlVerificationId_DataBound(object sender, EventArgs e)
    {
        ddlVerificationId.Items.Insert(0, new ListItem("--Select verification type--", "0"));
    }
    protected void brnSearch_Click(object sender, EventArgs e)
    {
        try
        {

            DataTable dtable = new DataTable();
            lblMessage.Text = "";
            obj_GenerateSms.VerificationId = ddlVerificationId.SelectedValue.ToString();
            dtable = obj_GenerateSms.finalrecordNew(Session["RoleId"].ToString(), Convert.ToDateTime(connobj.strDate(txtFromDate.Text.Trim().ToString())), Convert.ToDateTime(connobj.strDate(txtToDate.Text.Trim())).AddDays(1.0), Session["CentreId"].ToString(), Session["ClientId"].ToString());
            Session["RecCount"] = dtable.Rows.Count;
            if (dtable.Rows.Count > 0)
            {

                btnSend.Visible = true;
                Gview.Visible = true;
                Gview.DataSource = dtable;
                Gview.DataBind();
                ShowRecords();
            }
            else
            {
                btnSend.Visible = false;
                Gview.Visible = false;
                lblMessage.Visible = true;
                lblMessage.Text = " No Records are Found !!";

            }

        }

        catch (Exception ex)
        {
            lblMessage.Visible = true;
            lblMessage.Text = "Error while searching records: " + ex.Message;
        }
    }
    private void ShowRecords()
    {

        for (int i = 0; i < Gview.Rows.Count; i++)
        {

            TextBox txtComments;
            txtComments = (TextBox)Gview.Rows[i].FindControl("txtSms");
            //this javascript function allowed 255  charcter only into textbox.
            string strGridCustomCommentsId = "";

            if (i > 9)
            {
                strGridCustomCommentsId = "ctl00_C1_Gview_ctl";
            }
            else
            {
                strGridCustomCommentsId = "ctl00_C1_Gview_ctl0";
            }
            txtComments.Attributes.Add("onkeypress", "return CheckChar('" + strGridCustomCommentsId + Convert.ToInt16(i + 2) + "_txtSms" + "');");
            txtComments.Attributes.Add("onkeyup", "return CheckChar('" + strGridCustomCommentsId + Convert.ToInt16(i + 2) + "_txtSms" + "');");

        }
    }
    public struct GridPosition
    {
        public const int sms = 7;
        public const int mobile = 6;
        public const int CaseId = 0;

    }
    protected void Gview_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            TextBox context = (TextBox)e.Row.FindControl("txtSms");
            //this java script function clear content data.
            context.Attributes.Add("onkeydown", "javascript:window.clipboardData.clearData()");
        }

    }
    protected void btnSend_Click(object sender, EventArgs e)
    {
        string msgInfo = "";
        try
        {
            obj_GenerateSms.Sms_Date_Time = DateTime.Now;
            for (Int32 j = 0; j < Gview.Rows.Count; j++)
            {
                GridViewRow dgRow = Gview.Rows[j];
                TextBox txtCell = (TextBox)dgRow.Cells[GridPosition.sms].FindControl("txtMobile");
                TextBox txtSms = (TextBox)dgRow.Cells[GridPosition.mobile].FindControl("txtSms");
                CheckBox chk = (CheckBox)dgRow.FindControl("ChkSelect");
                if (chk.Checked == true)
                {
                    obj_GenerateSms.Mobile = txtCell.Text;
                    obj_GenerateSms.Sms = txtSms.Text;
                    obj_GenerateSms.CaseId = dgRow.Cells[GridPosition.CaseId].Text;
                    obj_GenerateSms.VerificationId = ddlVerificationId.SelectedValue.ToString();
                    if (obj_GenerateSms.Sms != "" && obj_GenerateSms.Mobile != "")
                    {
                        msgInfo = obj_GenerateSms.insertGridFieldsRL(Session["RoleId"].ToString(), "CPV_EBC_CASE_DETAILS", "CPV_EBC_VAERIFICATION_TYPE");
                    }
                }
            }
            lblMessage.Visible = true;
            lblMessage.Text = msgInfo;
            Gview.Visible = false;
            btnSend.Visible = false;

        }

        catch (Exception ex)
        {
            lblMessage.Visible = true;
            lblMessage.Text = "Error while sending SMS: " + msgInfo + " : " + ex.Message;
        }
    }
}
