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

public partial class CPV_KYC_KYC_SendToClient : System.Web.UI.Page
{
    CCommon connobj = new CCommon();
    KYC_SendToClient objclient = new KYC_SendToClient();
    DataTable d_table = new DataTable();
    DataSet ds = new DataSet();
    DataTable dtable = new DataTable();
    DataView dv = new DataView();
    protected void Page_Load(object sender, EventArgs e)
    {
        
        tblImg.Visible = false;
        if (Session["isAdd"].ToString() != "1")
            Response.Redirect("NoAccess.aspx");
    }
    protected void BtnSearch_Click(object sender, EventArgs e)
    {
        SearchRecords();
    }
    protected void btnCalcTat_Click(object sender, EventArgs e)
    {

        
      
        DateTime strSendDate;
        DateTime strToDate;
        DateTime strFromDate;
        DateTime strToDateCompaire;
        string TatHour;
        strToDate = Convert.ToDateTime(connobj.strDate(Txttodate1.Text.Trim())).AddDays(1.0);
        strToDateCompaire = Convert.ToDateTime(connobj.strDate(Txttodate1.Text.Trim()));
        strFromDate = Convert.ToDateTime(connobj.strDate(txtfromdate.Text.Trim()));
        String s1 = Convert.ToDateTime(connobj.strDate(txtSendDt.Text.Trim())).ToString("MM/dd/yyyy") + " " + txtSendTm.Text.ToString() + " " + ddlSendTimeType.SelectedItem.Text.Trim().ToString();
        strSendDate = Convert.ToDateTime(s1.ToString());
        try
        {
            

            if (strSendDate >= strToDateCompaire)
            {
                TatHour = objclient.GerStandardTatHour();
                if (TatHour != "")
                {
                    calculateTatHours(TatHour, strFromDate, strToDate);

                }
                else
                {
                    lbldatavalidation.Visible = true;

                   // Page.ClientScript.RegisterStartupScript(this.GetType(), "win", "<script>alert('Please First Set Standard Tat Hour')</script>");
                    lbldatavalidation.Text = "Please First Set Standard Tat Hour ";
                }
            }

            else
            {
                gvSearch.Visible = true;
                gvSendTat.Visible = false;
                lbldatavalidation.Visible = true;
                lbldatavalidation.Text = "Send Date Must Be Greater Then To Date ";
                // Page.ClientScript.RegisterStartupScript(this.GetType(), "win", "<script>alert('Send Date Must Be Greater Then To Date')</script>");
                tblImg.Visible = true;
            }
        }
        catch (Exception ex)
        {
            lbldatavalidation.Visible = true;
            btnSentToClient.Enabled = false;
            //Page.ClientScript.RegisterStartupScript(this.GetType(), "win", "<script>alert('Send Date Must Be Greater Then Rec. Date')</script>");
          lbldatavalidation.Text = "Send Date Must Be Greater Then Rec. Date ";

        }
    }
    protected void btnSentToClient_Click(object sender, EventArgs e)
    {
        sendToClient();
    }
    public void recordsFound()
    {
        ddd.Visible = true;
        dd.Visible = true;
        lbldatavalidation.Visible = false;
        gvSearch.Visible = true;
        ddlSendTimeType.Visible = true;
        btnCalcTat.Visible = true;
        btnSentToClient.Visible = true;
        btnSentToClient.Enabled = false;
        tblImg.Visible = true;
        lblsenddate.Visible = true;
        txtSendDt.Visible = true;
        lblsendtime.Visible = true;
        lblsenddatefotmate.Visible = true;
        lblhourandminformate.Visible = true;
        lblhourandminformate.Visible = true;
        txtSendTm.Visible = true;
        txtSendTm.Text = "";
        txtSendDt.Text = "";
        gvSearch.DataSource = d_table;
        gvSearch.DataBind();
    }
    public void recordsNotFound()
    {
        ddlSendTimeType.Visible = false;
        btnCalcTat.Visible = false;
        btnSentToClient.Visible = false;
        tblImg.Visible = false;
        lblsenddate.Visible = false;
        txtSendDt.Visible = false;
        lblsendtime.Visible = false;
        txtSendTm.Visible = false;
        lblmessage.Visible = true;
        lbldatavalidation.Visible = false;
        lblsenddatefotmate.Visible = false;
        lblhourandminformate.Visible = false;
        gvSearch.Visible = false;
        gvSendTat.Visible = false;
        dd.Visible = false;
        ddd.Visible = false;
        //Page.ClientScript.RegisterStartupScript(this.GetType(), "win", "<script>alert('Records Does Not Exist!!')</script>");
       lblmessage.Text = "Records Does Not Exist!!";
    }
    public void toDateLessThenFromDate()
    {
        ddlSendTimeType.Visible = false;
        btnCalcTat.Visible = false;
        btnSentToClient.Visible = false;
        tblImg.Visible = false;
        lblsenddate.Visible = false;
        txtSendDt.Visible = false;
        lblsendtime.Visible = false;
        txtSendTm.Visible = false;
        lblmessage.Visible = true;
        lbldatavalidation.Visible = false;
        lblsenddatefotmate.Visible = false;
        lblhourandminformate.Visible = false;
        gvSearch.Visible = false;
        gvSendTat.Visible = false;
        dd.Visible = false;
        ddd.Visible = false;
        //Page.ClientScript.RegisterStartupScript(this.GetType(), "win", "<script>alert('From Date Must Be Less Then ToDate!!')</script>");
       lblmessage.Text = "From Date Must Be Less Then ToDate!!";
    }
    public void SearchRecords()
    {
        DateTime sFromDate;
        DateTime sToDate;
        sFromDate = Convert.ToDateTime(connobj.strDate(txtfromdate.Text.ToString().Trim()));
        sToDate = Convert.ToDateTime(connobj.strDate(Txttodate1.Text.Trim())).AddDays(1.0);
        try
        {

            if (Convert.ToDateTime(connobj.strDate(Txttodate1.Text.Trim())) >= Convert.ToDateTime(connobj.strDate(txtfromdate.Text.ToString().Trim())))
            {
                lblmessage.Visible = false;
                gvSendTat.Visible = false;
                d_table = objclient.GetClient(sFromDate, sToDate);
                if (d_table.Rows.Count > 0)
                {
                    recordsFound();
                }
                else
                {
                    recordsNotFound();
                }
            }
            else
            {
                toDateLessThenFromDate();
            }
        }
        catch (Exception ex)
        {
            throw new Exception("Error While Searching " + ex.Message);
        }
    }
    public void calculateTatHours(string TatHour, DateTime strFromDate, DateTime strToDate)
    {
        string hour;
        double standardTatHour;
        double StandardHour;
        lbldatavalidation.Visible = false;
        btnSentToClient.Enabled = true;
        tblImg.Visible = true;
        gvSearch.Visible = false;
        gvSendTat.Visible = true;
        btnSentToClient.Enabled = true;
        objclient.SendDate = txtSendDt.Text.Trim().ToString();
        objclient.SendTime = txtSendTm.Text.ToString();
        StandardHour = System.Convert.ToDouble(TatHour);
        objclient.SendTimeType = ddlSendTimeType.SelectedItem.Text.Trim();
        dtable = objclient.GetTAT(strFromDate, strToDate);
        dv = new DataView(dtable);
        gvSendTat.DataSource = dv;
        gvSendTat.DataBind();
        foreach (GridViewRow gvRow in gvSendTat.Rows)
        {
            CheckBox chk = (CheckBox)gvRow.FindControl("ChkTAT");
            objclient.TATHRS = gvRow.Cells[GridPosition.TATHAR].Text;
            hour = objclient.TATHRS.ToString().Replace(":", ".");
            standardTatHour = System.Convert.ToDouble(hour);
            if (standardTatHour < StandardHour)
            {
                chk.Checked = true;
            }
            else
            {
                chk.Checked = false;
            }

        }

    }
    public void sendToClient()
    {
        if (gvSendTat.Rows.Count > 0)
        {
            for (Int32 j = 0; j < gvSendTat.Rows.Count; j++)
            {
                lblmessage.Visible = false;
                string chkb = "";
                DateTime strSendDate;
                objclient.SendDate = txtSendDt.Text.Trim().ToString();
                objclient.SendTime = txtSendTm.Text.ToString();
                objclient.SendTimeType = ddlSendTimeType.Text.ToString();
                String s1 = Convert.ToDateTime(connobj.strDate(txtSendDt.Text.Trim().ToString())).ToString("MM/dd/yyyy") + " " + txtSendTm.Text.ToString() + " " + ddlSendTimeType.Text.ToString();
                strSendDate = Convert.ToDateTime(s1.ToString());
                GridViewRow dgRow = gvSendTat.Rows[j];
                objclient.TATHRS = dgRow.Cells[GridPosition.TATHAR].Text;
                objclient.CaseId = dgRow.Cells[GridPosition.Caseid].Text;
                CheckBox chk = (CheckBox)dgRow.FindControl("ChkTAT");
                if (chk.Checked == true)
                {
                    chkb = "1";
                }
                else
                {
                    chkb = "0";
                }

                try
                {
                    objclient.insertGridFields(strSendDate, chkb);
                    lblmessage.Visible = true;
                    lblhourandminformate.Visible = false;
                    //Page.ClientScript.RegisterStartupScript(this.GetType(), "win", "<script>alert('Records Saved SuccessfullY!!')</script>");
                   lblmessage.Text = "Records Saved SuccessfullY!!";
                    ddd.Visible = false;
                    dd.Visible = false;
                    ddlSendTimeType.Visible = false;
                    btnCalcTat.Visible = false;
                    btnSentToClient.Visible = false;
                    tblImg.Visible = false;
                    lblsenddate.Visible = false;
                    txtSendDt.Visible = false;
                    lblsendtime.Visible = false;
                    txtSendTm.Visible = false;
                    gvSearch.Visible = false;
                    gvSendTat.Visible = false;
                }
                catch (Exception ex)
                {

                    throw new Exception("Error While Sending " + ex.Message);

                }

            }
        }

    }
    public struct GridPosition
    {
        public const int TATHAR = 4;
        public const int Caseid = 0;
    }
    //protected void gvSearch_PageIndexChanging(object sender, GridViewPageEventArgs e)
    //{
    //    gvSearch.PageIndex = e.NewPageIndex;
    //    DateTime sFromDate;
    //    DateTime sToDate;
    //    gvSendTat.Visible = true;
    //    tblImg.Visible = true;
    //    sFromDate = Convert.ToDateTime(connobj.strDate(txtfromdate.Text.ToString().Trim()));
    //    sToDate = Convert.ToDateTime(connobj.strDate(Txttodate1.Text.Trim())).AddDays(1.0);
    //    d_table = objclient.GetClient(sFromDate, sToDate);
    //    gvSearch.DataSource = d_table;
    //    gvSearch.DataBind();
    //}
    //protected void gvSendTat_PageIndexChanging(object sender, GridViewPageEventArgs e)
    //{

    //    DateTime sFromDate;
    //    DateTime sToDate;
    //    gvSendTat.Visible = true;
    //    tblImg.Visible = true;
    //    objclient.SendDate = txtSendDt.Text.Trim().ToString();
    //    objclient.SendTime = txtSendTm.Text.ToString();
    //    objclient.SendTimeType = ddlSendTimeType.SelectedItem.Text.Trim();

    //    sFromDate = Convert.ToDateTime(connobj.strDate(txtfromdate.Text.ToString().Trim()));
    //    sToDate = Convert.ToDateTime(connobj.strDate(Txttodate1.Text.Trim())).AddDays(1.0);
    //    dtable = objclient.GetTAT(sFromDate, sToDate);
    //    gvSendTat.DataSource = dtable;
    //    gvSendTat.PageIndex = e.NewPageIndex;
    //    gvSendTat.DataBind();
    //}
    //protected void gvSearch_Sorting(object sender, GridViewSortEventArgs e)
    //{



    //    DataTable d_table = new DataTable();
    //    DateTime sFromDate;
    //    DateTime sToDate;
    //    tblImg.Visible = true;
    //    sFromDate = Convert.ToDateTime(connobj.strDate(txtfromdate.Text.ToString().Trim()));
    //    sToDate = Convert.ToDateTime(connobj.strDate(Txttodate1.Text.Trim())).AddDays(1.0);
    //    d_table = objclient.GetClient(sFromDate, sToDate);
    //    DataView dv = new DataView(d_table);
    //    string sortExpression = e.SortExpression;
    //    if (GridViewSortDirection == SortDirection.Ascending)
    //    {
    //        GridViewSortDirection = SortDirection.Descending;
    //        dv.Sort = sortExpression + " " + "ASC";
    //    }
    //    else
    //    {
    //        GridViewSortDirection = SortDirection.Ascending;
    //        dv.Sort = sortExpression + " " + "DESC";
    //    }

    //    gvSearch.DataSource = dv;
    //    gvSearch.DataBind();
    //}
    //public SortDirection GridViewSortDirection
    //{

    //    get
    //    {

    //        if (ViewState["sortDirection"] == null)

    //            ViewState["sortDirection"] = SortDirection.Ascending;

    //        return (SortDirection)ViewState["sortDirection"];

    //    }

    //    set { ViewState["sortDirection"] = value; }

    //}
    //protected void gvSendTat_Sorting(object sender, GridViewSortEventArgs e)
    //{

    //    DateTime sFromDate;
    //    DateTime sToDate;
    //    gvSendTat.Visible = true;
    //    tblImg.Visible = true;
    //    objclient.SendDate = txtSendDt.Text.Trim().ToString();
    //    objclient.SendTime = txtSendTm.Text.ToString();
    //    objclient.SendTimeType = ddlSendTimeType.SelectedItem.Text.Trim();

    //    sFromDate = Convert.ToDateTime(connobj.strDate(txtfromdate.Text.ToString().Trim()));
    //    sToDate = Convert.ToDateTime(connobj.strDate(Txttodate1.Text.Trim())).AddDays(1.0);
    //    dtable = objclient.GetTAT(sFromDate, sToDate);



    //    DataView dv = new DataView(dtable);
    //    string sortExpression = e.SortExpression;
    //    if (GridViewSortDirection == SortDirection.Ascending)
    //    {
    //        GridViewSortDirection = SortDirection.Descending;
    //        dv.Sort = sortExpression + " " + "ASC";
    //    }
    //    else
    //    {
    //        GridViewSortDirection = SortDirection.Ascending;
    //        dv.Sort = sortExpression + " " + "DESC";
    //    }

    //    gvSendTat.DataSource = dv;
    //    gvSendTat.DataBind();



    //}
}
