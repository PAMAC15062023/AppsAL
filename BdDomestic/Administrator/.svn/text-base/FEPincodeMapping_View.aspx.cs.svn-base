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

public partial class Administrator_FEPincodeMapping_View : System.Web.UI.Page
{
    C_FE_PinCodeMapping objFEPincodeMapping = new C_FE_PinCodeMapping();
    protected void Page_Load(object sender, EventArgs e)
    {
        lblMsg.Text = "";
        if ((Session["CentreId"] != null) && (Session["CentreId"].ToString() != ""))
        {
            objFEPincodeMapping.CentreId = Session["CentreId"].ToString();
        }
        if (Context.Request.QueryString["Msg"] != null && Context.Request.QueryString["Msg"] != "")
        {
            lblMsg.Visible = true;
            lblMsg.Text = Request.QueryString["Msg"].ToString();
        }
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        Response.Redirect("FEPincodeMapping.aspx");
    }

    protected void gvFEPincode_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        String strPincode = "";
        String strFEID = "";
        string strClientId = "";
        if (e.CommandName == "DeleteMapping")
        {
            try
            {
                int idx = Convert.ToInt32(e.CommandArgument);
                HiddenField hdn = ((HiddenField)(gvFEPincode.Rows[idx].FindControl("hdnFE_ID")));
                Label lbl = ((Label)(gvFEPincode.Rows[idx].FindControl("lblPincode")));
                strPincode = ((Label)(gvFEPincode.Rows[idx].FindControl("lblPincode"))).Text.ToString();//lbl.Text.ToString();
                strFEID = ((HiddenField)(gvFEPincode.Rows[idx].FindControl("hdnFE_ID"))).Value.ToString();//hdn.Value.ToString();
                strClientId = ((HiddenField)(gvFEPincode.Rows[idx].FindControl("hdnClient_Id"))).Value.ToString();//hdn.Value.ToString();

                if (strPincode != "" && strFEID != "")
                {
                    CFEAssignment oPin = new CFEAssignment();
                    oPin.FEID = strFEID;
                    oPin.Pincode = strPincode;
                    oPin.ClinetId = strClientId;
                    oPin.DeleteFePinMapping();
                    lblMsg.Text = "FE Pincode mapping deleted successfully!";
                    gvFEPincode.DataBind();                   
                }
            }
            catch (Exception exp)
            {
                lblMsg.Text = "Error in delete, record can not be deleted.";
            }
        }
        else if (e.CommandName == "EditMapping")
        {
            int idx = Convert.ToInt32(e.CommandArgument);
            HiddenField hdn = ((HiddenField)(gvFEPincode.Rows[idx].FindControl("hdnFE_ID")));
            Label lbl = ((Label)(gvFEPincode.Rows[idx].FindControl("lblPincode")));
            strPincode = ((Label)(gvFEPincode.Rows[idx].FindControl("lblPincode"))).Text.ToString();//lbl.Text.ToString();
            strFEID = ((HiddenField)(gvFEPincode.Rows[idx].FindControl("hdnFE_ID"))).Value.ToString();//hdn.Value.ToString();
            strClientId = ((HiddenField)(gvFEPincode.Rows[idx].FindControl("hdnClient_Id"))).Value.ToString();//hdn.Value.ToString();
            if (strPincode != "" && strFEID != "")
            {
                Response.Redirect("FEPincodeMapping.aspx?Pin=" + strPincode + "&FE=" + strFEID + "&Client=" + strClientId);
            }
        }
    }

    protected void gvFEPincode_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            LinkButton l = (LinkButton)e.Row.FindControl("lnkFEPinDelete");
            l.Attributes.Add("onclick", "javascript:return " +
                          "confirm('Are you sure you want to delete this record')");
        }
    }
    //Added by: Gargi Srivastava
    //Added Date: 29-Nov-2007
    //Start
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        BindGrid();

    }
    private void BindGrid()
    {
        objFEPincodeMapping.ClientId = hidClientID.Value;
        DataTable dt = new DataTable();
        dt = objFEPincodeMapping.GetFEPinCodeMappingSearch();
        if (dt.Rows.Count > 0)
        {
            gvFEPincode.DataSource = dt;
            gvFEPincode.DataBind();
        }
        else
        {
            lblMsg.Text = "No Records Found..";
        }
    }
    
    protected void gvFEPincode_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvFEPincode.PageIndex = e.NewPageIndex;
        BindGrid();
    }
    //End
}
