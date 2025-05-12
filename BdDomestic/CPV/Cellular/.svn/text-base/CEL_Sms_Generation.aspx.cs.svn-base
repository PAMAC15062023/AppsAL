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
using System.IO;
using System.Text;
using System.Configuration.Assemblies;
using System.Data.OleDb;
public partial class CPV_Cellular_CC_Sms_Generation : System.Web.UI.Page
{
   
    C_Sms_Generation obj_GenerateSms = new C_Sms_Generation();
    CCommon connobj = new CCommon();
    protected void Page_Load(object sender, EventArgs e)
    {
       
    }
    protected void brnSearch_Click(object sender, EventArgs e)
    {      
        try
        {
                 
            DataTable dtable = new DataTable();                  
            lblMessage.Text = "";
            
            obj_GenerateSms.VerificationId = ddlVerificationId.SelectedValue.ToString();
           

            dtable = obj_GenerateSms.finalrecordCellular(Session["RoleId"].ToString(),Convert.ToDateTime(connobj.strDate(txtFromDate.Text.Trim().ToString())), Convert.ToDateTime(connobj.strDate(txtToDate.Text.Trim())).AddDays(1.0), Session["CentreId"].ToString(), Session["ClientId"].ToString());
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

            //if (Gview.Rows.Count > 9)
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
        public const int sms =7;
        public const int mobile = 6;
        public const int CaseId = 0;
      
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
                    obj_GenerateSms.Sms = txtSms.Text.Trim();
                    obj_GenerateSms.CaseId = dgRow.Cells[GridPosition.CaseId].Text;
                    obj_GenerateSms.VerificationId = ddlVerificationId.SelectedValue.ToString();
                    if (obj_GenerateSms.Sms != "" && obj_GenerateSms.Mobile != "")
                    {
                        msgInfo = obj_GenerateSms.insertGridFields(Session["RoleId"].ToString());
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
    protected void Gview_RowDataBound1(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {


            TextBox context = (TextBox)e.Row.FindControl("txtSms");
            //this java script function clear content data.
            context.Attributes.Add("onkeydown", "javascript:window.clipboardData.clearData()");
        }
    } 
    public SortDirection GridViewSortDirection
    {

        get
        {

            if (ViewState["sortDirection"] == null)

                ViewState["sortDirection"] = SortDirection.Ascending;

            return (SortDirection)ViewState["sortDirection"];

        }

        set { ViewState["sortDirection"] = value; }

    }
    protected void Gview_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        //btnSend.Visible = true;
        //Gview.Visible = true;
        //DataTable dtable = new DataTable();
        //Gview.PageIndex = e.NewPageIndex;
        //dtable = dtable = obj_GenerateSms.finalrecordNew(Convert.ToDateTime(connobj.strDate(txtFromDate.Text.Trim().ToString())), Convert.ToDateTime(connobj.strDate(txtToDate.Text.Trim())).AddDays(1.0), Session["CentreId"].ToString(), Session["ClientId"].ToString());
        //Gview.DataSource = dtable;
        //Gview.DataBind();


    }
    protected void Gview_Sorting(object sender, GridViewSortEventArgs e)
    {
        //DataTable dtable = new DataTable();
        //dtable = dtable = obj_GenerateSms.finalrecordNew(Convert.ToDateTime(connobj.strDate(txtFromDate.Text.Trim().ToString())), Convert.ToDateTime(connobj.strDate(txtToDate.Text.Trim())).AddDays(1.0), Session["CentreId"].ToString(), Session["ClientId"].ToString());
        //btnSend.Visible = true;
        //Gview.Visible = true;
        //DataView dv = new DataView(dtable);
        //string sortExpression = e.SortExpression;
        //if (GridViewSortDirection == SortDirection.Ascending)
        //{
        //    GridViewSortDirection = SortDirection.Descending;
        //    dv.Sort = sortExpression + " " + "ASC";
        //}
        //else
        //{
        //    GridViewSortDirection = SortDirection.Ascending;
        //    dv.Sort = sortExpression + " " + "DESC";
        //}

        //Gview.DataSource = dv;
        //Gview.DataBind();
    }

    protected void ddlVerificationId_DataBound(object sender, EventArgs e)
    {
        ddlVerificationId.Items.Insert(0, new ListItem("--Select verification type--", "0"));
    }
   
}        
                                          
              

