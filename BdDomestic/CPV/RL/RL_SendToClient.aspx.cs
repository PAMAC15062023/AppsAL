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
using System.Data.OleDb;

public partial class CPV_RL_RL_SendToClient : System.Web.UI.Page
{
    CCommon connobj = new CCommon();
    RL_SendToClient objclient = new RL_SendToClient();
    DataTable dtable = new DataTable();
    protected void Page_Load(object sender, EventArgs e)
    {
        tblImg.Visible = false;
        if (Session["isAdd"].ToString() != "1")
            Response.Redirect("NoAccess.aspx");
    }

    protected void btnCalcTat_Click(object sender, EventArgs e)
    {

        try
        {
            DateTime strSendDate;
            DateTime strToDate;
            DateTime sFromDate;
            DateTime sToDate;
            DataTable dtable = new DataTable();
            
            strToDate = Convert.ToDateTime(connobj.strDate(Txttodate1.Text.Trim()));
            String s1 = Convert.ToDateTime(connobj.strDate(txtSendDt.Text.Trim())).ToString("MM/dd/yyyy") + " " + txtSendTm.Text + " " + ddlSendTimeType.SelectedItem.Text.Trim();
            strSendDate = Convert.ToDateTime(s1.ToString());
            if (strSendDate >= strToDate)
            {
                double standardTatHour;
                string TatHour = objclient.GerStandardTatHour();
                if (TatHour != "")
                {
                    lbldatavalidation.Visible = false;
                    btnSentToClient.Enabled = true;
                    tblImg.Visible = true;
                    gvSearch.Visible = false;
                    
                    gvSendTat.Visible = true;
                    btnSentToClient.Enabled = true;
                    objclient.SendDate = txtSendDt.Text.Trim().ToString();
                    objclient.SendTime = txtSendTm.Text.ToString();
                    string Tdate = Txttodate1.Text.Trim();
                    Double StandardHour = System.Convert.ToDouble(TatHour);
                    sFromDate = Convert.ToDateTime(connobj.strDate(txtfromdate.Text.ToString().Trim()));
                    sToDate = Convert.ToDateTime(connobj.strDate(Tdate)).AddDays(1.0);
                    objclient.SendTimeType = ddlSendTimeType.SelectedItem.Text.Trim();
                    dtable = objclient.GetTAT(sFromDate, sToDate);
                    DataView dv = new DataView(dtable);
                    gvSendTat.DataSource = dv;
                    gvSendTat.DataBind();
                    foreach (GridViewRow gvRow in gvSendTat.Rows)
                    {
                        CheckBox chk = (CheckBox)gvRow.FindControl("ChkTAT");
                        objclient.TATHRS = gvRow.Cells[GridPosition.TATHAR].Text;

                        string hour = objclient.TATHRS.ToString().Replace(":", ".");
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
                else
                {
                    lbldatavalidation.Visible = true;
                    lbldatavalidation.Text = "Please First Set Standard Tat Hour ";
                }

            }
            else
            {
                gvSearch.Visible = true;

                lbldatavalidation.Visible = true;
                lbldatavalidation.Text = "Send Date Must Be Greater Then To Date ";
                tblImg.Visible = true;
            }
        }
        catch (Exception ex)
        {

            lbldatavalidation.Visible = true;
            btnSentToClient.Enabled = false;
            lbldatavalidation.Text = "Send Date Must Be Greater Then Rec. Date ";

        }
    }
    protected void BtnSearch_Click(object sender, EventArgs e)
    {
        try
        {
            bool dateIsValid = false;
            dateIsValid = FunctioncompareDate();
            if (dateIsValid == true)
            {

               
                DataTable d_table = new DataTable();
                DataSet ds = new DataSet();
                lblmessage.Visible = false;
                string Tdate = Txttodate1.Text.Trim();
                DateTime sFromDate;
                DateTime sToDate;
                sFromDate = Convert.ToDateTime(connobj.strDate(txtfromdate.Text.ToString().Trim()));
                sToDate = Convert.ToDateTime(connobj.strDate(Tdate)).AddDays(1.0);
                gvSendTat.Visible = false;
                d_table = objclient.GetClient(sFromDate, sToDate);
                if (d_table.Rows.Count > 0)
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
                else
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
                    lblmessage.Text = "Records Does Not Exist!!";

                }
            }
            else
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
                lblmessage.Text = "From Date Must Be Less Then ToDate!!";
            }
        }
        catch (Exception ex)
        {

            Response.Write(ex.Message.ToString());

        }
    }
    protected void btnSentToClient_Click(object sender, EventArgs e)
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
                //strSendDate = (objclient.SendDate + " " + objclient.SendTime + " " + objclient.SendTimeType);

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
                    //lblsendtimeformate = false;
                    lblhourandminformate.Visible = false;
                    lblmessage.Text = "Record Saved SuccessfullY!!";
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

                    Response.Write(ex.Message.ToString());

                }

            }
        }

    }

    public struct GridPosition
    {
        public const int TATHAR = 4;
        public const int Caseid = 0;
        public const int RecDate = 3;

    }


    protected void gvSendTat_RowDataBound(object sender, GridViewRowEventArgs e)
    {


    }
   

    public bool FunctioncompareDate()
    {

        DateTime sFromDate;
        DateTime sToDate;
        sFromDate = Convert.ToDateTime(connobj.strDate(txtfromdate.Text.ToString().Trim()));
        sToDate = Convert.ToDateTime(connobj.strDate(Txttodate1.Text.ToString().Trim()));
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
    //protected void gvSearch_PageIndexChanging(object sender, GridViewPageEventArgs e)
    //{
    //    gvSearch.PageIndex = e.NewPageIndex;
    //    DateTime sFromDate;
    //    DateTime sToDate;
    //    tblImg.Visible = true;
    //    sFromDate = Convert.ToDateTime(connobj.strDate(txtfromdate.Text.ToString().Trim()));
    //    sToDate = Convert.ToDateTime(connobj.strDate(Txttodate1.Text.Trim())).AddDays(1.0);
    //    dtable = objclient.GetClient(sFromDate, sToDate);
    //    gvSearch.DataSource = dtable;
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
