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

public partial class Administrator_Summary_Panel_Mapping : System.Web.UI.Page
{
    CGet objGet = new CGet();
    CAdmin_Summary_Panel_Mapping objCASPanel_Mapping = new CAdmin_Summary_Panel_Mapping();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            funFillActivity("");
            if (Request.QueryString["template_Id"] != null && Request.QueryString["template_Id"] != "")
            {
                hidTemplateID.Value = Request.QueryString["template_id"];
                objCASPanel_Mapping.pptTemplateID = Request.QueryString["template_Id"];
                objCASPanel_Mapping.getTemplates();
                ddlActivity.SelectedValue = objCASPanel_Mapping.pptActivityID;
                funFillVerificationType(objCASPanel_Mapping.pptActivityID, objCASPanel_Mapping.pptVerificationType);
                funFillProduct(objCASPanel_Mapping.pptActivityID, objCASPanel_Mapping.pptProductID);
                funFillClients(objCASPanel_Mapping.pptProductID, objCASPanel_Mapping.pptClientID);
                txtTemplateName.Text = objCASPanel_Mapping.pptTemplateName;
                int nCount = 0;
                nCount = objCASPanel_Mapping.getCountofPanelNo();
                hidSrNo.Value = nCount.ToString();
            }
        }

    }

    protected void ddlActivity_SelectedIndexChanged(object sender, EventArgs e)
    {
        string strActivityID = ddlActivity.SelectedValue.ToString();
        //funFillActivity(strActivityID);
        funFillVerificationType(strActivityID, "");
        funFillProduct(strActivityID, "");
        ddlClient.Items.Clear();
    }


    protected void ddlVerificationType_SelectedIndexChanged(object sender, EventArgs e)
    {
        int nVerificationType_ID=Convert.ToInt32(ddlVerificationType.SelectedValue.ToString());
        int nCount = 0;
        if(nVerificationType_ID!=0)
        {
            CAdmin_Summary_Panel_Mapping objCASPanel_Mapping = new CAdmin_Summary_Panel_Mapping();
            objCASPanel_Mapping.pptVerificationType = nVerificationType_ID.ToString();
            nCount = objCASPanel_Mapping.getCountofPanelNo();
            
        }
        hidSrNo.Value = nCount.ToString();
    }
    protected void gvTemplateMatch_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        //DropDownList ddlSrNo;
        TextBox txtSrNo;
        Label lblPanel_ID;
        string strPanel_ID="";
        int ctr = Convert.ToInt32(hidSrNo.Value.ToString());
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            txtSrNo = ((TextBox)e.Row.FindControl("txtSrNo"));
            //ddlSrNo = ((DropDownList)e.Row.FindControl("ddlSrNo"));
            lblPanel_ID=((Label)e.Row.FindControl("lblPanelID"));

            //ddlSrNo.Items.Insert(0, new ListItem("Select One", "0"));
            //ddlSrNo.DataBind();
            //for (int i = 1; i <= ctr; i++)
            //{

            //    ddlSrNo.Items.Add(i.ToString());

            //}
            
            strPanel_ID = lblPanel_ID.Text.ToString();
            DataSet dsTemplate = new DataSet();
            dsTemplate = objCASPanel_Mapping.dsPanelList;
            if (dsTemplate != null)
            {
                if (dsTemplate.Tables[0].Rows.Count != 0)
                {
                    for (int j = 0; j < dsTemplate.Tables[0].Rows.Count; j++)
                    {
                        if (dsTemplate.Tables[0].Rows[j]["PANEL_ID"].ToString() == strPanel_ID)
                        {
                            //ddlSrNo.SelectedValue = dsTemplate.Tables[0].Rows[j]["SR_NO"].ToString();
                            txtSrNo.Text = dsTemplate.Tables[0].Rows[j]["SR_NO"].ToString();
                            
                        }
                    }
                }
            }

        }
    }
    protected void ddlProduct_SelectedIndexChanged(object sender, EventArgs e)
    {
        string strProductID = ddlProduct.SelectedValue.ToString();
        funFillClients(strProductID, "");
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            CAdmin_Summary_Panel_Mapping objCASPanel_Mapping = new CAdmin_Summary_Panel_Mapping();
            
            Boolean blnIsDuplicate = true;

            //objCASPanel_Mapping.pptCentreID = ddlCentre.SelectedValue.ToString();
            objCASPanel_Mapping.pptActivityID = ddlActivity.SelectedValue.ToString();
            objCASPanel_Mapping.pptProductID = ddlProduct.SelectedValue.ToString();
            objCASPanel_Mapping.pptTemplateName = txtTemplateName.Text.ToString();
            objCASPanel_Mapping.pptVerificationType = ddlVerificationType.SelectedValue.ToString();
            objCASPanel_Mapping.pptClientID = ddlClient.SelectedValue.ToString();
            string strTemplate_ID = "";

            if (hidTemplateID.Value.ToString() != "")
            {
                strTemplate_ID = hidTemplateID.Value.ToString();
            }
            DataTable dtPanel = new DataTable();
            dtPanel.Columns.Add("Panel_ID");
            dtPanel.Columns.Add("Sr_No");

            DataRow dr;
            Label lblPanelID;
            //Label lblPanelDescription;
            //DropDownList ddlSrNo;
            TextBox txtSrNo;
            int nSrNo;
            int nCount = 0;

            foreach (GridViewRow gvRow in gvTemplateMatch.Rows)
            {

                txtSrNo = ((TextBox)gvRow.FindControl("txtSrNo"));

                lblPanelID = (Label)gvRow.FindControl("lblPanelID");

                if (txtSrNo.Text.Trim().ToString() != "")
                {

                    nSrNo = Convert.ToInt32(txtSrNo.Text.Trim().ToString());
                    dr = dtPanel.NewRow();
                    dtPanel.Rows.Add();
                    dtPanel.Rows[nCount]["PANEL_ID"] = lblPanelID.Text;
                    dtPanel.Rows[nCount]["SR_NO"] = txtSrNo.Text.Trim().ToString();
                    nCount++;
                }

            }
            objCASPanel_Mapping.dsPanelList = new DataSet();
            objCASPanel_Mapping.dsPanelList.Tables.Add(dtPanel);
            if (strTemplate_ID == "")
            {
                blnIsDuplicate = objCASPanel_Mapping.getDuplicateValue("");
                if (blnIsDuplicate != true)
                {
                    objCASPanel_Mapping.insertPanel();
                    lblError.Text = "Template Created Successfully!!";
                }
                else
                {
                    lblError.Text = "Template Already exist!!";
                }
            }
            else
            {
                blnIsDuplicate = objCASPanel_Mapping.getDuplicateValue(strTemplate_ID);
                if (blnIsDuplicate != true)
                {
                    objCASPanel_Mapping.pptTemplateID = strTemplate_ID;
                    objCASPanel_Mapping.updatePanel();
                    lblError.Text = "Template Updated Successfully!!";
                }
                else
                {
                    lblError.Text = "Template Already exist!!";
                }
            }
        }
        catch (Exception exp)
        {
            lblError.Text = exp.Message;
        }
    }
    protected void ddlClient_DataBound(object sender, EventArgs e)
    {
        ddlClient.Items.Insert(0, new ListItem("--Select Client--", "0"));
    }
    protected void ddlProduct_DataBound(object sender, EventArgs e)
    {
        ddlProduct.Items.Insert(0, new ListItem("--Select Product--", "0"));
    }
    protected void ddlVerificationType_DataBound(object sender, EventArgs e)
    {
        ddlVerificationType.Items.Insert(0, new ListItem("--Select Verification Type--", "0"));
    }

    public void funFillVerificationType(string strActivityID,string strVeriTypeID)
    {
        DataSet ds = new DataSet();
        if (strActivityID != "")
        {
            ds = objGet.getVerificationType(strActivityID);
            ddlVerificationType.Items.Clear();
            ListItem liVeriType = new ListItem("--Select Verification Type--", "");
            ddlVerificationType.Items.Add(liVeriType);

            if (ds != null)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    for (int k = 0; k < ds.Tables[0].Rows.Count; k++)
                    {
                        liVeriType = new ListItem((string)ds.Tables[0].Rows[k]["VERIFICATION_TYPE_CODE"], (string)ds.Tables[0].Rows[k]["VERIFICATION_TYPE_ID"]);
                        ddlVerificationType.Items.Add(liVeriType);
                    }
                    if (strVeriTypeID != "")
                    {
                        ddlVerificationType.SelectedValue = strVeriTypeID;
                    }
                }
            }
            ds.Clear();
        }
    }

    public void funFillProduct(string strActivityID, string strProductID)
    {
        DataSet ds = new DataSet();
        if (strActivityID != "")
        {
            ddlActivity.SelectedValue = strActivityID;
            ds = objGet.getProducts(strActivityID);

            ddlProduct.Items.Clear();
            ListItem liProduct = new ListItem("--Select Product--", "");
            ddlProduct.Items.Add(liProduct);

            if (ds != null)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    for (int k = 0; k < ds.Tables[0].Rows.Count; k++)
                    {
                        liProduct = new ListItem((string)ds.Tables[0].Rows[k]["PRODUCT_NAME"], (string)ds.Tables[0].Rows[k]["PRODUCT_ID"]);
                        ddlProduct.Items.Add(liProduct);
                    }
                    if(strProductID!="")
                    {
                        ddlProduct.SelectedValue = strProductID;
                    }
                     
                }
            }
            ds.Clear();
        }
    }
    public void funFillClients(string strProductID, string strClientID)
    {
        DataSet ds = new DataSet();
        if (strProductID != "")
        {
            ddlProduct.SelectedValue = strProductID;
            ds = objGet.getClients(strProductID);
            ddlClient.Items.Clear();
            ListItem liClient = new ListItem("--Select Client--", "");
            ddlClient.Items.Add(liClient);

            if (ds != null)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    for (int k = 0; k < ds.Tables[0].Rows.Count; k++)
                    {
                        liClient = new ListItem((string)ds.Tables[0].Rows[k]["CLIENT_NAME"], (string)ds.Tables[0].Rows[k]["CLIENT_ID"]);
                        ddlClient.Items.Add(liClient);
                    }
                    if (strClientID != "")
                    {
                        ddlClient.SelectedValue = strClientID;
                    }
                }
            }
        }
    }

    public void funFillActivity(string strActivityID)
    {
        DataSet ds = new DataSet();

        if (strActivityID == "")
        {
            ds = objGet.getActivities();
            ddlActivity.Items.Clear();
            ListItem liActivities = new ListItem("--Select Activity--", "");
            ddlActivity.Items.Add(liActivities);

            if (ds != null)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    for (int k = 0; k < ds.Tables[0].Rows.Count; k++)
                    {
                        liActivities = new ListItem((string)ds.Tables[0].Rows[k]["ACTIVITY_NAME"], (string)ds.Tables[0].Rows[k]["ACTIVITY_ID"]);
                        ddlActivity.Items.Add(liActivities);
                    }
                }
            }
            ds.Clear();
        }

        if (strActivityID != "")
        {
            ddlActivity.SelectedValue = strActivityID;
        }
   }
    protected void ddlClient_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("Summary_Panel_Mapping_View.aspx");
    }
}
