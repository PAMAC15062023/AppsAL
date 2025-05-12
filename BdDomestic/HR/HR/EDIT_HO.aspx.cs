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


public partial class HR_HR_EDIT_HO : System.Web.UI.Page
{
    DAT_ENTRY DE = new DAT_ENTRY();
    CCommon con = new CCommon();
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            btnSave.Visible = false;
            sdsSubCentre.SelectCommand = "Select SubCentreName,SubCentreId from SubCentreMaster ";
            ddlSubCentre.DataBind();

        }
        
        //DE.SubCentreID = ddlSubCentre.SelectedValue;
        //DE.CentreID = ddlCentre.SelectedValue;
        //DataSet dsHier = new DataSet();
        //dsHier = DE.GetHier();
        //string strHier = "";
        
        //    if (dsHier.Tables[0].Columns.Count == 3)
        //    {
        //        strHier = dsHier.Tables[0].Rows[0]["cluster_name"].ToString() + "-" + dsHier.Tables[0].Rows[0]["CENTRE_NAME"].ToString() + "-" + dsHier.Tables[0].Rows[0]["SubCentreName"].ToString();
        //    }
        //    else
        //        strHier = dsHier.Tables[0].Rows[0]["cluster_name"].ToString() + "-" + dsHier.Tables[0].Rows[0]["CENTRE_NAME"].ToString();
        //    lblHierChichy.Text = strHier;
        

    }
    public void FillGrid()
    {
        DataSet ds = new DataSet();
        DE.SubCentreID = ddlSubCentre.SelectedValue;
        DE.CentreID = ddlCentre.SelectedValue;
        if (txtEmpCode.Text.Trim() != "")
        {
            DE.EMPCODE = txtEmpCode.Text.Trim();
        }
        if (txtEmpName.Text.Trim() != "")
        {
            DE.EMPNAME = txtEmpName.Text.Trim().Replace(' ', '%');
        }
        ds = DE.EditGrid(con.strDate(txtDate.Text.Trim()));
        GVDE.DataSource = ds;

        ViewState["v1"] = ds;
        GVDE.DataBind();
        if (GVDE.Rows.Count <= 0)
        {
            lblMsg.Text = "No record found.";
            lblMsg.Visible = true;
            btnSave.Visible = false;
        }
        if (GVDE.Rows.Count > 0)
        {
            lblDate.Text = "Attendance Updation  For  Date - " + txtDate.Text + "";
            lblMsg.Visible = false;
            btnSave.Visible = true;
        }
    }
   
    protected void ddlSubCentre_DataBound(object sender, EventArgs e)
    {
        ddlSubCentre.Items.Insert(0, new ListItem("--Select--", "0"));
    }
    protected void GVDE_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowIndex != -1)
            {
                DataSet ds1 = new DataSet();
                ds1 = (DataSet)ViewState["v1"];
                DropDownList ddlID = ((DropDownList)(e.Row.FindControl("ddl")));
                HiddenField hidID = ((HiddenField)(e.Row.FindControl("hidEmpID")));
                DataRow[] dr1 = ds1.Tables[0].Select("emp_id='" + hidID.Value + "'");
                if ((ds1.Tables[0].Rows.Count) > 0)
                {
                    ddlID.SelectedValue = dr1[0]["ATTENDANCE"].ToString();
                }
                if (e.Row.RowIndex == GVDE.Rows.Count)
                {
                    ds1.Dispose();

                }
            }
        }
        catch (Exception ex)
        {
            lblMsg.Visible = true;
            lblMsg.Text = ex.Message;
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        ArrayList AlistEmp = new ArrayList();
        ArrayList AlistAtten = new ArrayList();


        string AlistCreBy = "";
        DateTime AlistCreDate;
        string AlistModBy = "";
        DateTime AlistModDate;
        AlistCreBy = Session["UserId"].ToString();
        AlistCreDate = DateTime.Now;
        AlistModBy = Session["UserId"].ToString();
        AlistModDate = DateTime.Now;

        DE.SubCentreID = ddlSubCentre.SelectedValue;
        
        foreach (GridViewRow row in GVDE.Rows)
        {
            HiddenField hidID = (HiddenField)row.FindControl("hidEmpID");
            DropDownList ddlID = (DropDownList)row.FindControl("ddl");

            
            AlistEmp.Add(hidID.Value);
            AlistAtten.Add(ddlID.SelectedValue);
            
        }
       //////DE.UpdateAttendaceByHO(AlistEmp, AlistAtten,con.strDate(txtDate.Text.Trim()));

        DE.UpdateAttendaceByHO(AlistEmp, AlistAtten, con.strDate(txtDate.Text.Trim()), AlistCreBy, AlistCreDate, AlistModBy, AlistModDate);
        FillGrid();
        lblMsg.Visible = true;
        lblMsg.Text = DE.Message;
    }
    protected void btnShow_Click(object sender, EventArgs e)
    {
        try
        {
            FillGrid();

        }
        catch (Exception ex)
        {
            lblMsg.Visible = true;
            lblMsg.Text = ex.Message;
        }
    }
    protected void ddlCentre_DataBound(object sender, EventArgs e)
    {
        ddlCentre.Items.Insert(0, new ListItem("--All--", "0"));
    }
    protected void ddlCentre_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlCentre.SelectedIndex == 0)
        {
            sdsSubCentre.SelectCommand = "Select SubCentreName,SubCentreId from SubCentreMaster ";
            ddlSubCentre.DataBind();
        }
        else
        {
            sdsSubCentre.SelectCommand = "Select SubCentreName,SubCentreId from SubCentreMaster where CentreId="+ddlCentre.SelectedValue+" ";
            ddlSubCentre.DataBind();
        }
    }

    protected void GVDE_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GVDE.PageIndex = e.NewPageIndex;
        FillGrid();
    }
}
