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

public partial class Administrator_FEPincodeMapping : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        lblMsg.Text = "";
        //Pin=" + strPincode + "&FE=" + strFEID + "&Client
        if (!IsPostBack)
        {
            if (Context.Request.QueryString["Pin"] != null && Context.Request.QueryString["Pin"] != "" &&
                Context.Request.QueryString["FE"] != null && Context.Request.QueryString["FE"] != "" &&
                Context.Request.QueryString["Client"] != null && Context.Request.QueryString["Client"] != "")
            {
                txtPincode.Text = Request.QueryString["Pin"].ToString();
                ddlFEName.SelectedValue = Request.QueryString["FE"].ToString();
                lstClients.SelectedValue = Request.QueryString["Client"].ToString();               
            }
        }
    }
    protected void ddlFEName_DataBound(object sender, EventArgs e)
    {
        ddlFEName.Items.Insert(0, new ListItem("--Select--", ""));
    }
    //protected void gvFEPincode_RowCommand(object sender, GridViewCommandEventArgs e)
    //{
    //    String strPincode = "";
    //    String strFEID = "";
    //    string strClientId="";
    //    if (e.CommandName == "DeleteMapping")
    //    {
    //        try
    //        {
    //            int idx = Convert.ToInt32(e.CommandArgument);
    //            HiddenField hdn = ((HiddenField)(gvFEPincode.Rows[idx].FindControl("hdnFE_ID")));
    //            Label lbl = ((Label)(gvFEPincode.Rows[idx].FindControl("lblPincode")));
    //            strPincode = ((Label)(gvFEPincode.Rows[idx].FindControl("lblPincode"))).Text.ToString();//lbl.Text.ToString();
    //            strFEID = ((HiddenField)(gvFEPincode.Rows[idx].FindControl("hdnFE_ID"))).Value.ToString();//hdn.Value.ToString();
    //            strClientId=((HiddenField)(gvFEPincode.Rows[idx].FindControl("hdnClient_Id"))).Value.ToString();//hdn.Value.ToString();
                    
    //            if (strPincode != "" && strFEID != "")
    //            {
    //                CFEAssignment oPin = new CFEAssignment();
    //                oPin.FEID = strFEID;
    //                oPin.Pincode = strPincode;
    //                oPin.ClinetId = strClientId;
    //                oPin.DeleteFePinMapping();
    //                lblMsg.Text = "FE Pincode mapping deleted successfully!";
    //                gvFEPincode.DataBind();
    //                ddlFEName.SelectedIndex = 0;
    //                txtPincode.Text = "";
    //            }
    //        }
    //        catch (Exception exp)
    //        {
    //            lblMsg.Text = "Error in delete, record can not be deleted.";
    //        }
    //    }
    //}
    //protected void btnAdd_Click(object sender, EventArgs e)
    //{
    //    try
    //    {
    //        CFEAssignment oPin = new CFEAssignment();
    //        //oPin.FEID = ddlFEName.SelectedValue.ToString();
    //        //oPin.Pincode = txtPincode.Text.Trim().ToString();
    //        //oPin.ClinetId = ddlClient.SelectedItem.Value;
    //        //added by hemangi kambli on 19-Nov-2007 ---------------------
    //        oPin.FEID = ddlFEName.SelectedValue.ToString();            
    //        ArrayList arrClients = new ArrayList();
    //        foreach (ListItem li in lstClients.Items)
    //        {
    //            if(li.Selected==true)
    //                arrClients.Add(li.Value);
    //        }
    //        string[] arrPin = txtPincode.Text.ToString().Split(',');            
    //        ///-----------------------------------------------------------
    //        oPin.InsertFePinMapping(arrClients,arrPin);
    //        lblMsg.Text = "FE Pincode mapping added successfully!";
    //        gvFEPincode.DataBind();
    //        ddlFEName.SelectedIndex = 0;
    //        txtPincode.Text = "";
    //    }
    //    catch (Exception exp)
    //    {
    //        lblMsg.Text = "Error in adding, record can not be added.";
    //    }
    //}

    //protected void gvFEPincode_RowDataBound(object sender, GridViewRowEventArgs e)
    //{
    //    if (e.Row.RowType == DataControlRowType.DataRow)
    //    {
    //        LinkButton l = (LinkButton)e.Row.FindControl("lnkFEPinDelete");
    //        l.Attributes.Add("onclick", "javascript:return " +
    //                      "confirm('Are you sure you want to delete this record')");
    //    }
    //}

    protected void ddlClient_DataBound(object sender, EventArgs e)
    {
        //ddlClient.Items.Insert(0, new ListItem("--Select--", ""));
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        int iCount = 0;
        try
        {
            CFEAssignment oPin = new CFEAssignment();
            //oPin.FEID = ddlFEName.SelectedValue.ToString();
            //oPin.Pincode = txtPincode.Text.Trim().ToString();
            //oPin.ClinetId = ddlClient.SelectedItem.Value;
            //added by hemangi kambli on 19-Nov-2007 ---------------------
            oPin.FEID = ddlFEName.SelectedValue.ToString();
            ArrayList arrClients = new ArrayList();
            if (lstClients.SelectedValue != "0")
            {
                foreach (ListItem li in lstClients.Items)
                {
                    if (li.Selected == true)
                        arrClients.Add(li.Value);
                }
            }
            else if (lstClients.SelectedValue == "0")
            {
                foreach (ListItem li in lstClients.Items)
                {
                     if(li.Value!="0")
                         arrClients.Add(li.Value);
                }
            }
            string[] arrPin = txtPincode.Text.ToString().Split(',');
            ///-----------------------------------------------------------  
            ///for editing records....            
            oPin.InsertUpdatePinMapping(arrClients, arrPin);         
            //gvFEPincode.DataBind();
            ddlFEName.SelectedIndex = 0;
            txtPincode.Text = "";
            iCount = 1;
        }
        catch (Exception exp)
        {
            lblMsg.Visible = true;
            lblMsg.Text = "Error in adding, record can not be added. " + exp.Message;
        }
        if(iCount==1)
            Response.Redirect("FEPincodeMapping_View.aspx?MSg=" + lblMsg.Text.ToString());
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("FEPincodeMapping_View.aspx");
    }
}
