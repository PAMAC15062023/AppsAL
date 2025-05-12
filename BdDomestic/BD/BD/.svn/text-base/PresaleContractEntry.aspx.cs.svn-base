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

public partial class PresaleContractEntry : System.Web.UI.Page
{
    CBDContract oBD = new CBDContract();
    CCommon oCmn = new CCommon();
    protected void Page_Load(object sender, EventArgs e)
    {
        string UserId = Session["UserId"].ToString();
        if (UserId == "101103548")
        {
            btnSubmit.Visible = false;

        }
        if (!IsPostBack)
        {
            ddlBDManager.DataBind();
            ddlLeadBy.DataBind();
            ddlClient.DataBind();           
            if (Request.QueryString.Count > 0)
            {
                if (Request.QueryString["Mode"].ToString() != "" || Request.QueryString["Mode"].ToString() != null)
                    hdnMode.Value = Request.QueryString["Mode"].ToString();
                if (hdnMode.Value == "E")
                {
                    if (Request.QueryString["NID"].ToString() != "" || Request.QueryString["NID"].ToString() != null)
                    {
                        hdnContID.Value = Request.QueryString["NID"].ToString();
                        oBD.ContID = Request.QueryString["NID"].ToString();
                        DataSet dsContractDetail = oBD.GetPresaleContractDetail();
                        if (dsContractDetail != null)
                        {
                            if (dsContractDetail.Tables[0].Rows.Count > 0)
                            {
                                for (int i = 0; i < dsContractDetail.Tables[0].Rows.Count; i++)
                                {
                                    txtRefNo.Text = dsContractDetail.Tables[0].Rows[i]["CONT_PRESALE_REF_NO"].ToString();
                                    if (dsContractDetail.Tables[0].Rows[i]["CLIENT_ID"].ToString() != "")
                                        ddlClient.SelectedValue = dsContractDetail.Tables[0].Rows[i]["CLIENT_ID"].ToString();
                                    txtDomain.Text = dsContractDetail.Tables[0].Rows[i]["CLIENT_DOMAIN"].ToString();
                                    txtAddress.Text = dsContractDetail.Tables[0].Rows[i]["CLIENT_ADDRESS"].ToString();
                                    txtConPerson.Text = dsContractDetail.Tables[0].Rows[i]["CONTACT_PERSON"].ToString();
                                    txtDesignation.Text = dsContractDetail.Tables[0].Rows[i]["CONTACT_DESIGNATION"].ToString();
                                    txtConEmail.Text = dsContractDetail.Tables[0].Rows[i]["CONTACT_EMAIL"].ToString();
                                    txtConTel.Text = dsContractDetail.Tables[0].Rows[i]["CONTACT_TELEPHONE"].ToString();
                                    txtRemark.Text = dsContractDetail.Tables[0].Rows[i]["REMARK"].ToString();
                                    if (dsContractDetail.Tables[0].Rows[i]["LEAD_BY"].ToString() != "")
                                        ddlLeadBy.SelectedValue = dsContractDetail.Tables[0].Rows[i]["LEAD_BY"].ToString();
                                    if (dsContractDetail.Tables[0].Rows[i]["LEAD_DATE"].ToString() != "")
                                    txtLeadDate.Text = Convert.ToDateTime(dsContractDetail.Tables[0].Rows[i]["LEAD_DATE"]).ToString("dd/MM/yyyy");
                                    if (dsContractDetail.Tables[0].Rows[i]["BD_MANAGER_ID"].ToString() != "")
                                        ddlBDManager.SelectedValue = dsContractDetail.Tables[0].Rows[i]["BD_MANAGER_ID"].ToString();

                                }
                            }
                        }
                        DataSet dsActProd = oBD.GetActProd();
                        CheckBox chkActProd;
                        HiddenField hdnActID;
                        HiddenField hdnProdID;
                        gvActProd.DataBind();
                        if (dsActProd.Tables[0].Rows.Count > 0)
                        {
                            for (int i = 0; i < dsActProd.Tables[0].Rows.Count; i++)
                            {
                                foreach (GridViewRow row in gvActProd.Rows)
                                {
                                    chkActProd = (CheckBox)row.FindControl("chkNo");
                                    hdnActID = (HiddenField)row.FindControl("hdnActivityID");
                                    hdnProdID = (HiddenField)row.FindControl("hdnProductID");

                                    if (hdnActID.Value.ToString() == dsActProd.Tables[0].Rows[i]["ACTIVITY_ID"].ToString() && hdnProdID.Value.ToString() == dsActProd.Tables[0].Rows[i]["PRODUCT_ID"].ToString())
                                    {
                                        chkActProd.Checked = true;
                                    }
                                }    
                            }
                        }
                        Boolean blnIsEdit = oBD.getMDet();
                        if (!blnIsEdit)
                        {
                            btnSubmit.Enabled = false;
                            lblMsg.Text = "Meeting Details are entered. Contract can not be edited.";
                        }
                    }                    
                }
            }
            else
            {
                //imgGet.Visible = true;
               // oBD.getSerial();
               // txtRefNo.Text = "Pre" + oBD.Serial;
                hdnMode.Value = "A";               
                txtDomain.Text = "";
                txtAddress.Text = "";
                txtConPerson.Text = "";
                txtDesignation.Text = "";
                txtConEmail.Text = "";
                txtConTel.Text = "";
                txtLeadDate.Text = "";
                txtRemark.Text = "";
            }
        }
    }
    protected void ddlClient_SelectedIndexChanged(object sender, EventArgs e)
    {
        String strClientID = ddlClient.SelectedValue.ToString();
        txtDomain.Text = oBD.getDomain(strClientID);
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        CheckBox chkActProd;
        HiddenField hdnActID;
        HiddenField hdnProdID;        
        String strActProdID = "";
        int strcheck = 0;
        foreach(GridViewRow row in gvActProd.Rows)
        {
            chkActProd = (CheckBox)row.FindControl("chkNo");            
            hdnActID = (HiddenField)row.FindControl("hdnActivityID");
            hdnProdID = (HiddenField)row.FindControl("hdnProductID");
            //if (chkActProd.Checked)
            //{
            //    strActProdID += hdnActID.Value.ToString() +":"+hdnProdID.Value.ToString() + " ";                 
            //}
            if (chkActProd.Checked)
            {
                strcheck = strcheck + 1;
                if (strcheck > 1)
                {
                    lblMsg.Text = "U can't select more than one Activity with product";
                    return;

                }
                else
                {

                    strActProdID += hdnActID.Value.ToString() + ":" + hdnProdID.Value.ToString() + " ";
                }
            }
        }
        if (strActProdID!="")
        oBD.arrActProdID = (strActProdID.Trim()).Split(' ');
        oBD.ContRefNo = txtRefNo.Text.Trim();
        oBD.ClientID = ddlClient.SelectedValue.ToString();
        oBD.ClientDomain = txtDomain.Text.Trim();
        oBD.ClientAddress = txtAddress.Text.Trim();
        oBD.ContactPerson = txtConPerson.Text.Trim();
        oBD.ContactDesignation = txtDesignation.Text.Trim();
        oBD.ContactEmail = txtConEmail.Text.Trim();
        oBD.ContactPhone = txtConTel.Text.Trim();
        oBD.Remark = txtRemark.Text.Trim();
        oBD.LeadBy = ddlLeadBy.SelectedValue.ToString();
        if (txtLeadDate.Text.Trim() != "")
            oBD.LeadDate = Convert.ToDateTime(oCmn.strDate(txtLeadDate.Text.Trim())).ToString();
        oBD.BDManager = ddlBDManager.SelectedValue.ToString();
        oBD.PresaleStatus = "New";
        oBD.IsConfirmed = "N";
        if (hdnMode.Value == "A")
        {
            oBD.Prefix = Session["Prefix"].ToString();
            oBD.InsertPresaleContractDetail();
            Response.Redirect("ViewPresaleCase.aspx?Msg=Record added successfully!");
        }
        if (hdnMode.Value == "E")
        {
            oBD.ContID = hdnContID.Value.ToString();
            oBD.UpdatePresaleContractDetail();
            Response.Redirect("ViewPresaleCase.aspx?Msg=Record updated successfully!");
        }
    }   
    protected void ddlLeadBy_DataBound(object sender, EventArgs e)
    {
        ddlLeadBy.Items.Insert(0, new ListItem("--Select--", ""));
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("ViewPresaleCase.aspx?Msg=");
    }
    protected void ddlBDManager_DataBound(object sender, EventArgs e)
    {
        ddlBDManager.Items.Insert(0, new ListItem("--Select--", ""));
    }
    protected void ddlClient_DataBound(object sender, EventArgs e)
    {
        ddlClient.Items.Insert(0, new ListItem("--Select--", ""));
    }
    protected void imgGet_Click(object sender, ImageClickEventArgs e)
    {
        //TO GENERATE UNIQUE CODE
        String strPre = oCmn.GetUniqueID1("PRESALE_CONTRACT_DETAIL_SERIAL", "");
       //txtRefNo.Text = "Pre" + strPre;
        //add by kamal matekar
        txtRefNo.Text = strPre + "/";
    }
}
