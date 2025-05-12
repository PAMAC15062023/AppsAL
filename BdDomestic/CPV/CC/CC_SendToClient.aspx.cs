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

public partial class CPV_CC_CC_SendToClient : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //if (IsPostBack)
        //{
        //    /*Calling again whole search functionality...*/
        //    if((txtfromdate.Text!="" || txtfromdate.Text!=null) && (txtToDate.Text!="" || txtToDate.Text!=null))
        //    {
        //        bool dateIsValid = false;
        //        dateIsValid = FunctioncompareDate();
        //        lblMsg.Text = "";
        //        lblMsg.Visible = false;
        //        if (dateIsValid == true)
        //        {
        //            CsendToClient objSendClient = new CsendToClient();
        //            CCommon connobj = new CCommon();
        //            DateTime sFromDate;
        //            DateTime sToDate;
        //            sFromDate = Convert.ToDateTime(connobj.strDate(txtfromdate.Text.ToString().Trim()));
        //            sToDate = Convert.ToDateTime(connobj.strDate(txtToDate.Text.Trim())).AddDays(1.0);
        //            DataSet dsSendClient = new DataSet();
        //            dsSendClient = objSendClient.GetRecords(Session["ClientId"].ToString(), Session["CentreId"].ToString(), sFromDate, sToDate);
        //            if (dsSendClient.Tables[0].Rows.Count > 0)
        //            {
        //                gvSendTat.DataSource = dsSendClient;
        //                gvSendTat.DataBind();
        //                pnlSendClient.Visible = true;
        //                lblCount.Visible = true;
        //                //gvSendTat.Columns[4].Visible = false;
        //                //gvSendTat.Columns[5].Visible = false;
        //                lblCount.Text = "Number of records:" + dsSendClient.Tables[0].Rows.Count;
        //                hdnStandardTAT.Value = objSendClient.GerStandardTatHour();
        //            }
        //        }

        //    }
        //}
        
        
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        bool dateIsValid = false;
        dateIsValid = FunctioncompareDate();
        lblMsg.Text = "";
        lblMsg.Visible = false;
        if (dateIsValid == true)
        {
            CsendToClient objSendClient = new CsendToClient();
            CCommon connobj = new CCommon();
            DateTime sFromDate;
            DateTime sToDate;
            sFromDate = Convert.ToDateTime(connobj.strDate(txtfromdate.Text.ToString().Trim()));
            sToDate = Convert.ToDateTime(connobj.strDate(txtToDate.Text.Trim())).AddDays(1.0);
            DataSet dsSendClient = new DataSet();
            dsSendClient = objSendClient.GetRecords(Session["ClientId"].ToString(), Session["CentreId"].ToString(), sFromDate, sToDate);
            if (dsSendClient.Tables[0].Rows.Count > 0)
            {
                gvSendTat.DataSource = dsSendClient;
                gvSendTat.DataBind();
                pnlSendClient.Visible = true;
                lblCount.Visible = true;
                //gvSendTat.Columns[4].Visible = false;
                //gvSendTat.Columns[5].Visible = false;
                lblCount.Text = "Number of records:" + dsSendClient.Tables[0].Rows.Count;
                hdnStandardTAT.Value = objSendClient.GerStandardTatHour();
            }
            else
            {
                lblMsg.Visible = true;
                lblMsg.ForeColor = System.Drawing.Color.Red;
                lblMsg.Text = "Record not found.";
                pnlSendClient.Visible = false;
                //tblSendClient.Visible = false;
            }
        }
    }

    public bool FunctioncompareDate()
    {
        CCommon connobj = new CCommon();
        DateTime sFromDate;
        DateTime sToDate;
        sFromDate = Convert.ToDateTime(connobj.strDate(txtfromdate.Text.ToString().Trim()));
        sToDate = Convert.ToDateTime(connobj.strDate(txtToDate.Text.ToString().Trim()));
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

    public struct GridPosition
    {
        public const int TATHAR = 4;
        public const int Caseid = 0;
        public const int RecDate = 3;

    }

    protected void btnCalcTat_Click(object sender, EventArgs e)
    {
        try
        {
            CCommon connobj = new CCommon();
            DateTime strSendDate;
            DateTime strToDate;
            DateTime sFromDate;
            DateTime sToDate;
            DataTable dtable = new DataTable();
            CsendToClient objclient = new CsendToClient();
            strToDate = Convert.ToDateTime(connobj.strDate(txtToDate.Text.Trim()));
            String s1 = Convert.ToDateTime(connobj.strDate(txtSendDt.Text.Trim())).ToString("MM/dd/yyyy") + " " + txtSendTm.Text + " " + ddlSendTimeType.SelectedItem.Text.Trim();
            strSendDate = Convert.ToDateTime(s1.ToString());
            if (strSendDate >= strToDate)
            {
                double standardTatHour;
                string TatHour = objclient.GerStandardTatHour();
                if (TatHour != "")
                {
                    //lbldatavalidation.Visible = false;
                    btnSentToClient.Enabled = true;
                    //tblImg.Visible = true;
                    //gvSearch.Visible = false;
                    gvSendTat.Visible = true;
                    btnSentToClient.Enabled = true;
                    objclient.SendDate = txtSendDt.Text.Trim().ToString();
                    objclient.SendTime = txtSendTm.Text.ToString();
                    string Tdate = txtToDate.Text.Trim();
                    Double StandardHour = System.Convert.ToDouble(TatHour);
                    sFromDate = Convert.ToDateTime(connobj.strDate(txtfromdate.Text.ToString().Trim()));
                    sToDate = Convert.ToDateTime(connobj.strDate(Tdate)).AddDays(1.0);
                    objclient.SendTimeType = ddlSendTimeType.SelectedItem.Text.Trim();

                    gvSendTat.Columns[4].Visible = true;
                    gvSendTat.Columns[5].Visible = true;

                    foreach (GridViewRow gvRow in gvSendTat.Rows)
                    {
                        String s = gvRow.Cells[3].Text.ToString();
                        DateTime strSendDate1;
                        TimeSpan ts1;
                        double Hrs, mins;
                        string Hours = "";
                        string Minutes = "";
                        string Total_Hours = "";

                        //-----to calculate TAT hours for each case......

                        strSendDate1 = Convert.ToDateTime(connobj.strDate(s.ToString()));
                        String sSend = Convert.ToDateTime(connobj.strDate(txtSendDt.Text.Trim())).ToString("MM/dd/yyyy") + " " + txtSendTm.Text.Trim() + " " + ddlSendTimeType.SelectedValue.ToString();
                        strSendDate = Convert.ToDateTime(sSend.ToString());
                        ts1 = strSendDate.Subtract(strSendDate1);
                        Hrs = Convert.ToDouble(ts1.Days * 24 + ts1.Hours);
                        mins = Convert.ToDouble(ts1.Minutes);
                        Hours = Hrs.ToString();
                        Minutes = mins.ToString();
                        Total_Hours = Hours + ":" + Minutes;
                        gvRow.Cells[4].Text = Total_Hours;

                        ///....Check whether TAT is within or not......
                        CheckBox chk = (CheckBox)gvRow.FindControl("ChkTAT");
                        objclient.TATHRS = gvRow.Cells[4].Text;
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
                        //............................................................
                    }
                }
                else
                {
                    lblMsg.Visible = true;
                    lblMsg.Text = "Please First Set Standard Tat Hour ";
                }

            }
            else
            {
                lblMsg.Visible = true;
                lblMsg.Text = "Send Date Must Be Greater Then To Date ";
            }
        }
        catch (Exception ex)
        {
            //throw new Exception(ex.Message);
            lblMsg.Visible = true;
            lblMsg.Text = "Send Date Must Be Greater Then Rec. Date ";

        }
    }



    //public string CalculateTAT(GridViewRow dgRow)
    //{
    //    String s = dgRow.Cells[4].Text.ToString();
    //    DateTime strSendDate1;
    //    TimeSpan ts1;
    //    double Hrs, mins;
    //    string Hours = "";
    //    string Minutes = "";
    //    string Total_Hours = "";
    //    CCommon connobj = new CCommon();
    //    //-----to calculate TAT hours for each case......
    //    strSendDate1 = Convert.ToDateTime(connobj.strDate(s.ToString()));
    //    String sSend = Convert.ToDateTime(connobj.strDate(txtSendDt.Text.Trim())).ToString("MM/dd/yyyy") + " " + txtSendTm.Text.Trim() + " " + ddlSendTimeType.SelectedValue.ToString();
    //    DateTime strSendDate;
        
    //    strSendDate = Convert.ToDateTime(sSend.ToString());
    //    ts1 = strSendDate.Subtract(strSendDate1);
    //    Hrs = Convert.ToDouble(ts1.Days * 24 + ts1.Hours);
    //    mins = Convert.ToDouble(ts1.Minutes);
    //    Hours = Hrs.ToString();
    //    Minutes = mins.ToString();
    //    Total_Hours = Hours + ":" + Minutes;
    //    return Total_Hours;
    //}
    protected void btnSentToClient_Click(object sender, EventArgs e)
    {
        bool IsRecordSaved = false;
        CCommon connobj = new CCommon();

        if (gvSendTat.Rows.Count > 0)
        {
            for (Int32 j = 0; j < gvSendTat.Rows.Count; j++)
            {
                string chkb = "";
                DateTime strSendDate;
                CsendToClient objclient = new CsendToClient();
                objclient.SendDate = txtSendDt.Text.Trim().ToString();
                objclient.SendTime = txtSendTm.Text.ToString();
                objclient.SendTimeType = ddlSendTimeType.Text.ToString();
                //strSendDate = (objclient.SendDate + " " + objclient.SendTime + " " + objclient.SendTimeType);

                String s1 = Convert.ToDateTime(connobj.strDate(txtSendDt.Text.Trim().ToString())).ToString("MM/dd/yyyy") + " " + txtSendTm.Text.ToString() + " " + ddlSendTimeType.Text.ToString();
                strSendDate = Convert.ToDateTime(s1.ToString());
                GridViewRow dgRow = gvSendTat.Rows[j];
                string fromDate =(dgRow.Cells[4].Text);
                DateTime fdate = Convert.ToDateTime(connobj.strDate(fromDate.Trim()));
                CheckBox Ch = (CheckBox)dgRow.FindControl("Chk");
                if (Ch.Checked)
                {
                    objclient.CaseId = dgRow.Cells[1].Text;
                    HiddenField hdTat = (HiddenField)dgRow.FindControl("hdTat");
                    //Calling Tat Calculation Function...
                    objclient.TATHRS = objclient.GetTAT_New( fdate, strSendDate);                  
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
                        //lblMsg.Visible = true;
                        lblhourandminformate.Visible = false;
                        //lblMsg.Text = "Record Saved SuccessfullY!!";
                        IsRecordSaved = true;
                        pnlSendClient.Visible = false;
                    }

                    catch (Exception ex)
                    {
                        Response.Write(ex.Message.ToString());
                    }
                }
            }
        }
        /*Again Calling the functionality of Search button.....*/
            /*Calling again whole search functionality...*/
            if ((txtfromdate.Text != "" || txtfromdate.Text != null) && (txtToDate.Text != "" || txtToDate.Text != null))
            {
                bool dateIsValid = false;
                dateIsValid = FunctioncompareDate();
                lblMsg.Text = "";
                lblMsg.Visible = false;
                if (dateIsValid == true)
                {
                    CsendToClient objSendClient = new CsendToClient();
                    //CCommon connobj = new CCommon();
                    DateTime sFromDate;
                    DateTime sToDate;
                    sFromDate = Convert.ToDateTime(connobj.strDate(txtfromdate.Text.ToString().Trim()));
                    sToDate = Convert.ToDateTime(connobj.strDate(txtToDate.Text.Trim())).AddDays(1.0);
                    DataSet dsSendClient = new DataSet();
                    dsSendClient = objSendClient.GetRecords(Session["ClientId"].ToString(), Session["CentreId"].ToString(), sFromDate, sToDate);
                    if (dsSendClient.Tables[0].Rows.Count > 0)
                    {
                        gvSendTat.DataSource = dsSendClient;
                        gvSendTat.DataBind();
                        pnlSendClient.Visible = true;
                        lblCount.Visible = true;
                        //gvSendTat.Columns[4].Visible = false;
                        //gvSendTat.Columns[5].Visible = false;
                        lblCount.Text = "Number of records:" + dsSendClient.Tables[0].Rows.Count;
                        hdnStandardTAT.Value = objSendClient.GerStandardTatHour();
                    }
                }
                if (IsRecordSaved = true)
                {
                    lblMsg.Visible = true;
                    lblMsg.Text = "Record saved sucessfully.";               
                }

            }
    }
    protected void gvSendTat_DataBound(object sender, EventArgs e)
    {
        System.Web.UI.WebControls.CheckBox cbHeader = ((System.Web.UI.WebControls.CheckBox)(gvSendTat.HeaderRow.FindControl("ChkAll")));
        cbHeader.Attributes["onclick"] = "ChangeAllCheckBoxStates(this.checked);";
        foreach (GridViewRow gvr in gvSendTat.Rows)
        {
            // Get a programmatic reference to the CheckBox control
            System.Web.UI.WebControls.CheckBox cb = ((System.Web.UI.WebControls.CheckBox)(gvr.FindControl("Chk")));
            ClientScript.RegisterArrayDeclaration("CheckBoxIDs", string.Concat("\'", cb.ClientID, "\'"));
        }
    }
}
