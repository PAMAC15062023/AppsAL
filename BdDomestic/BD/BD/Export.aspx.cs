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
using System.Data.SqlClient;
using System.Text;
using System.IO;

public partial class BD_Export : System.Web.UI.Page
{
    CBDContract oBD = new CBDContract();
    CCommon objCom = new CCommon();
    DataSet ds = new DataSet();
   

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //string UserId = Session["UserId"].ToString();

            string UserId ="101335";

            if ("101103545" == UserId || "101190" == UserId || "101566" == UserId || "10133" == UserId || "101335" == UserId || "101103547" == UserId)
            {
                lblleadby.Visible = true;
                ddlLeadBy.Visible = true;
                lblbd.Visible = true;
                ddlBDManager.Visible = true;
            }

            Register_Javascript();

        }

    }
    private void Register_Javascript()
    {
        btnSearch.Attributes.Add("onclick", "javascript:return Validate_Search();");
        
    }

    //private void RegisterValidation_OnClickEvent()
    //{

    //    btnSearch.Attributes.Add("onclick", "javascript:return Validate_Search();");
  
    //}
   
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        try
        {
            
          getsearch();
           
        }
        catch (Exception ex)
        {
            lblMessage.Visible = true;
            lblMessage.Text = ex.Message;
        }

    }

    public void getsearch()
    {
        try
        {
        bool dateIsValid = false;
        dateIsValid = FunctioncompareDate();

        if (dateIsValid == true)
        {
//            string sFromDate;
  //          string sToDate;


            //string sFromDate = objCom.strDate(txtFromDate.Text.Trim());
            //string sToDate = objCom.strDate(txtToDate.Text.Trim());

            string UserId = Session["UserId"].ToString();
            if (ddlMeetinglead.Visible == true)
            {
                oBD.MeetingLead = ddlMeetinglead.SelectedValue;
            }
            if (ddlLeadBy.Visible == true)
            {
                oBD.LeadBy = ddlLeadBy.SelectedValue;
            }
            if (ddlBDManager.Visible == true)
            {
                oBD.BDManager = ddlBDManager.SelectedValue;
            }

            //ds = oBD.fillgridview(UserId,sFromDate,sToDate);

            ds = oBD.fillgridview(UserId, (objCom.strDate(txtFromDate.Text.Trim())), (objCom.strDate(txtToDate.Text.Trim())));



            gvImportedData.DataSource = ds;
            gvImportedData.DataBind();

            if (gvImportedData.Rows.Count > 0)
            {
                lblMessage.Text = "Record Found-" + gvImportedData.Rows.Count;
                tblExport.Visible = true;
                gvImportedData.Visible = true;
                btnExport.Visible = true;
            }
            else
            {
                lblMessage.Text = "No Record Found";
            }
        
        }
         }
        catch (Exception ex)
        {
            lblMessage.Visible = true;
            lblMessage.Text = ex.Message;
        }
    
    }

    protected void ddlMeetinglead_DataBound(object sender, EventArgs e)
    {
        ddlMeetinglead.Items.Insert(0, new ListItem("--Select--", ""));
    }

    protected void ddlBDManager_DataBound(object sender, EventArgs e)
    {
        ddlBDManager.Items.Insert(0, new ListItem("--Select--", ""));
    }
    protected void ddlLeadBy_DataBound(object sender, EventArgs e)
    {
        ddlLeadBy.Items.Insert(0, new ListItem("--Select--", ""));
    }

    protected void btnExport_Click(object sender, EventArgs e)
    {
       
        String attachment = "attachment; filename=BDTracker.xls";
        Response.AddHeader("content-disposition", attachment);
        Response.ContentType = "application/ms-excel";
        StringWriter sw = new System.IO.StringWriter();
        HtmlTextWriter htw = new HtmlTextWriter(sw);
        Table tblSpace = new Table();
        TableRow tblRow = new TableRow();
        TableCell tblCell = new TableCell();
        tblCell.Text = " ";

        TableRow tblRow1 = new TableRow();
        TableCell tblCell1 = new TableCell();
        tblCell1.ColumnSpan = 20;// 10;
        tblCell1.Text = "<b><font size='3'>BD Tracker Report </font></b> <br/>";
        tblCell1.CssClass = "FormHeading";
        tblRow.Cells.Add(tblCell);
        tblRow1.Cells.Add(tblCell1);
        tblRow.Height = 20;
        tblSpace.Rows.Add(tblRow);
        tblSpace.Rows.Add(tblRow1);
        tblSpace.RenderControl(htw);

        Table tbl = new Table();
        gvImportedData.EnableViewState = false;
        gvImportedData.GridLines = GridLines.Both;
        tblExport.RenderControl(htw);
        Response.Write(sw.ToString());

        Response.End();


    }

    public override void VerifyRenderingInServerForm(Control control)
    {

    }

    public bool FunctioncompareDate()
    {

        DateTime sFromDate;
        DateTime sToDate;
        sFromDate = Convert.ToDateTime(objCom.strDate(txtFromDate.Text.Trim()));
        sToDate = Convert.ToDateTime(objCom.strDate(txtToDate.Text.Trim()));

        bool bReturn = true;
        if (sFromDate > sToDate)
        {
            bReturn = false;
        }
        else
        {
            bReturn = true;


        }
        return bReturn;
    } 

  
}
