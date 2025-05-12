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

public partial class MeetingDetails : System.Web.UI.Page
{
    CBDContract oBD = new CBDContract();
    CCommon oCmn = new CCommon();
    protected void Page_Load(object sender, EventArgs e)
    {
        string UserId = Session["UserId"].ToString();
        if (UserId == "101103548")
        {
            btnSubmit.Visible = false;
            btnReset.Enabled = false;
        }
        lblMsg.Text = "";
        if (!IsPostBack)
        {            
            if (Request.QueryString.Count > 0)
            {
                if (Request.QueryString["Mode"].ToString() != "" || Request.QueryString["Mode"].ToString() != null)
                    hdnMode.Value = Request.QueryString["Mode"].ToString();
                if (Request.QueryString["NID"].ToString() != "" || Request.QueryString["NID"].ToString() != null)
                {
                    hdnContID.Value = Request.QueryString["NID"].ToString();
                    oBD.ContID = Request.QueryString["NID"].ToString();
                    String strOfficerName = oBD.getOfficerName();
                    txtOfficer.Text = strOfficerName;
                }
            }
            gvMeetingDetails.DataBind();

            Boolean blnIsEdit = oBD.getIsConfirm();
            if (!blnIsEdit)
            {
                btnSubmit.Enabled = true; 
                lblMsg.Text = "Contract Confirmed. Meeting Details can not be edited.";
            }
        }
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        oBD.ContID = hdnContID.Value.ToString();
        oBD.ContEmpID = ddlContactBy.SelectedValue.ToString();
        oBD.MeetingFor = ddlMeetingFor.SelectedValue.ToString();
        oBD.MeetingLead = ddlMeetinglead.SelectedValue.ToString();
        if (txtMeetingDate.Text.Trim() != "")
        oBD.MeetingDate = Convert.ToDateTime(oCmn.strDate(txtMeetingDate.Text.Trim())).ToString();
        oBD.MeetingPlace = txtPlace.Text.Trim();
        oBD.OfficerName = txtOfficer.Text.Trim();
        oBD.MinutsofMeeting = txtMoM.Text.Trim();
        oBD.MeetingRemark = txtRemark.Text.Trim();
        if (chkConfirm.Checked)
            oBD.IsConfirmed = "Y";
        else
            oBD.IsConfirmed = "N";
        oBD.SourceConfirm = txtConfirmSource.Text.Trim();
        if (txtConfirmDate.Text.Trim()!="")
            oBD.ConfirmDate = Convert.ToDateTime(oCmn.strDate(txtConfirmDate.Text.Trim())).ToString();
        oBD.OrderNo = txtOrderNo.Text.Trim();
        if (txtOrderDate.Text.Trim() != "")
            oBD.OrderDate = Convert.ToDateTime(oCmn.strDate(txtOrderDate.Text.Trim())).ToString();
        oBD.CurrentUser = "RKUMAR";
        if (hdnMode.Value.ToString() == "A")
        {
            oBD.Prefix = Session["Prefix"].ToString();
            oBD.InsertPresaleMeetingDetail();
            lblMsg.Text = "Record added successfully!";
        }
        if (hdnMode.Value.ToString() == "E")
        {
            oBD.MeetingID = hdnMeetingID.Value.ToString();
            oBD.UpdatePresaleMeetingDetail();
            lblMsg.Text = "Record updated successfully!";
        }
        if (chkConfirm.Checked)
        {
            Response.Redirect("ViewPresaleCase.aspx?Msg= Contract Confirmed!");
        }
        gvMeetingDetails.DataBind();
        ddlContactBy.DataBind();
        ddlMeetingFor.DataBind();
        hdnMode.Value = "A";
        txtConfirmDate.Text = "";
        txtConfirmSource.Text = "";
        txtMeetingDate.Text = "";
        txtMoM.Text = "";
        txtOfficer.Text = "";
        txtOrderDate.Text = "";
        txtOrderNo.Text = "";
        txtPlace.Text = "";
        txtRemark.Text = "";
    }
    //protected void ddlContactBy_DataBound(object sender, EventArgs e)
    //{
    //   // ddlContactBy.Items.Insert(0, new ListItem("--Select--", ""));
    //}
    protected void ddlMeetingFor_DataBound(object sender, EventArgs e)
    {
        ddlMeetingFor.Items.Insert(0, new ListItem("--Select--", ""));
    }

    protected void ddlMeetinglead_DataBound(object sender, EventArgs e)
    {
        ddlMeetinglead.Items.Insert(0, new ListItem("--Select--", ""));
    }
    protected void gvMeetingDetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label lblNo = new Label();
            lblNo = (Label)e.Row.FindControl("lblNo");
            lblNo.Text = Convert.ToString(e.Row.DataItemIndex + 1);
        }
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("ViewPresaleCase.aspx?Msg=");
    }
    protected void gvMeetingDetails_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        String strMeetingID = "";
        if (e.CommandName == "EditMeeting")
        {
            strMeetingID = e.CommandArgument.ToString();
            if (strMeetingID != "")
            {
               // Response.Redirect("MeetingDetails.aspx?Mode=A&NID=" + strMeetingID);
                oBD.MeetingID = strMeetingID;
                oBD.ContID = hdnContID.Value.ToString();                
                DataSet dsMeetingDetail = oBD.GetMeetingDetail();
                if (dsMeetingDetail != null)
                {
                    if(dsMeetingDetail.Tables[0].Rows.Count>0)
                    {
                        for (int i = 0; i < dsMeetingDetail.Tables[0].Rows.Count; i++)
                        {                           
                            if (dsMeetingDetail.Tables[0].Rows[i]["CONTACT_EMP_ID"].ToString() != "" || dsMeetingDetail.Tables[0].Rows[i]["CONTACT_EMP_ID"].ToString() != null)
                                ddlContactBy.SelectedValue = dsMeetingDetail.Tables[0].Rows[i]["CONTACT_EMP_ID"].ToString();
                            if (dsMeetingDetail.Tables[0].Rows[i]["MEETING_FOR"].ToString() != "" || dsMeetingDetail.Tables[0].Rows[i]["MEETING_FOR"].ToString() != null)
                                ddlMeetingFor.SelectedValue = dsMeetingDetail.Tables[0].Rows[i]["MEETING_FOR"].ToString();
                            if (dsMeetingDetail.Tables[0].Rows[i]["MEETING_DATE"].ToString() != "" || dsMeetingDetail.Tables[0].Rows[i]["MEETING_DATE"].ToString() != null)
                                txtMeetingDate.Text = Convert.ToDateTime(dsMeetingDetail.Tables[0].Rows[i]["MEETING_DATE"]).ToString("dd/MM/yyyy");
                            txtPlace.Text = dsMeetingDetail.Tables[0].Rows[i]["MEETING_PLACE"].ToString();
                            txtOfficer.Text = dsMeetingDetail.Tables[0].Rows[i]["OFFICER_NAME"].ToString();
                            txtMoM.Text = dsMeetingDetail.Tables[0].Rows[i]["MINUTES_MEETING"].ToString();
                            txtRemark.Text = dsMeetingDetail.Tables[0].Rows[i]["REMARK"].ToString();
                            if (dsMeetingDetail.Tables[0].Rows[i]["IS_CONFIRMED"].ToString() == "Y")
                                chkConfirm.Checked = true;
                            txtConfirmSource.Text = dsMeetingDetail.Tables[0].Rows[i]["SOURCE_CONFIRM"].ToString();                            
                            if (dsMeetingDetail.Tables[0].Rows[i]["CONFIRM_DATE"].ToString() != "")
                                txtConfirmDate.Text = Convert.ToDateTime(dsMeetingDetail.Tables[0].Rows[i]["CONFIRM_DATE"].ToString()).ToString("dd/MM/yyyy");                            
                            txtOrderNo.Text = dsMeetingDetail.Tables[0].Rows[i]["ORDER_NO"].ToString();
                            if (dsMeetingDetail.Tables[0].Rows[i]["ORDER_DATE"].ToString() != "")
                                txtOrderDate.Text = Convert.ToDateTime(dsMeetingDetail.Tables[0].Rows[i]["ORDER_DATE"]).ToString("dd/MM/yyyy");                            
                        }
                    }
                }
                hdnMeetingID.Value = strMeetingID;
                hdnMode.Value = "E";
            }
        }
    }
    protected void btnReset_Click(object sender, EventArgs e)
    {
        gvMeetingDetails.DataBind();
        ddlContactBy.DataBind();
        ddlMeetingFor.DataBind();
        hdnMode.Value = "A";
        txtConfirmDate.Text = "";
        txtConfirmSource.Text = "";
        txtMeetingDate.Text = "";
        txtMoM.Text = "";
        //txtOfficer.Text = "";
        txtOrderDate.Text = "";
        txtOrderNo.Text = "";
        txtPlace.Text = "";
        txtRemark.Text = "";
    }
}
