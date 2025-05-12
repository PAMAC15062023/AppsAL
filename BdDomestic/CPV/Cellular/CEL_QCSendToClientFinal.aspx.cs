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

public partial class CPV_Cellular_CEL_QCSendToClientFinal : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            txtSendDt.Text = "";
            txtSendTm.Text = "";
            ddlSendTimeType.SelectedIndex = 0;
        }
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        try
        {
            bool dateIsValid = false;
            dateIsValid = FunctioncompareDate();
            lblMsg.Text = "";
            lblMsg.Visible = false;
            if (dateIsValid == true)
            {
                CSendToClientFinal objSendClient = new CSendToClientFinal();
                CCommon connobj = new CCommon();
                DateTime sFromDate;
                DateTime sToDate;
                sFromDate = Convert.ToDateTime(connobj.strDate(txtfromdate.Text.ToString().Trim()));
                sToDate = Convert.ToDateTime(connobj.strDate(txtToDate.Text.Trim())).AddDays(1.0);
                DataSet dsSendClient = new DataSet();
                dsSendClient = objSendClient.GetQCRecordsCellular(Session["ClientId"].ToString(), Session["CentreId"].ToString(), sFromDate, sToDate);
                if (dsSendClient.Tables[0].Rows.Count > 0)
                {
                    gvSendTat.DataSource = dsSendClient;
                    gvSendTat.DataBind();
                    pnlSendClient.Visible = true;
                    lblCount.Visible = true;
                    lblCount.Text = "Number of records: " + dsSendClient.Tables[0].Rows.Count;
                    hdnStandardTAT.Value = objSendClient.GerStandardTatHour(Session["ClientId"].ToString(), Session["ActivityId"].ToString(), Session["ProductId"].ToString());
                    if (hdnStandardTAT.Value.ToString() == "")
                    {
                        lblMsg.Visible = true;
                        lblMsg.Text = "Please First Set Standard Tat Hour!";
                        btnSentToClient.Enabled = false;
                        TRTAT.Visible = false;
                    }
                    else
                    {
                        lblMsg.Visible = false;
                        lblMsg.Text = "";
                        btnSentToClient.Enabled = true;
                        TRTAT.Visible = true;
                    }
                    txtSendDt.Text = DateTime.Now.ToString("dd/MM/yyyy");
                    txtSendTm.Text = DateTime.Now.ToString("hh:mm");
                    ddlSendTimeType.SelectedValue = DateTime.Now.ToString("tt");
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
        catch (Exception ex)
        {
            lblMsg.Visible = true;
            lblMsg.Text = "Error : " + ex.Message;
            lblMsg.ForeColor = System.Drawing.Color.Red;
        }
        //try catch is added by supriya on 16th Nov2007 
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

    protected void btnSentToClient_Click(object sender, EventArgs e)
    {
        CCommon connobj = new CCommon();
        bool IsRecordSaved = false;
        if (gvSendTat.Rows.Count > 0)
        {
            for (Int32 j = 0; j < gvSendTat.Rows.Count; j++)
            {
                string chkb = "";
                DateTime strSendDate;
                CSendToClientFinal objclient = new CSendToClientFinal();
                objclient.SendDate = txtSendDt.Text.Trim().ToString();
                objclient.SendTime = txtSendTm.Text.ToString();
                objclient.SendTimeType = ddlSendTimeType.Text.ToString();

                String s1 = Convert.ToDateTime(connobj.strDate(txtSendDt.Text.Trim().ToString())).ToString("MM/dd/yyyy") + " " + txtSendTm.Text.ToString() + " " + ddlSendTimeType.Text.ToString();
                strSendDate = Convert.ToDateTime(s1.ToString());
                GridViewRow dgRow = gvSendTat.Rows[j];
                string fromDate = (dgRow.Cells[4].Text);
                DateTime fdate = Convert.ToDateTime(connobj.strDate(fromDate.Trim()));
                CheckBox Ch = (CheckBox)dgRow.FindControl("Chk");
                if (Ch.Checked)
                {
                    objclient.CaseId = dgRow.Cells[1].Text;       
                    ////added by kamal matekar
                    //Calling Tat Calculation Function...
                    objclient.TATHRS = objclient.CalulateQCTATHrsCellular(fdate, strSendDate, Session["ClientId"].ToString(), Session["CentreId"].ToString());
                    //CheckBox chk = (CheckBox)dgRow.FindControl("ChkTAT");
                    //if (chk.Checked == true)
                    //{
                    //    chkb = "1";
                    //}
                    //else
                    //{
                    //    chkb = "0";
                    //}
                    HiddenField hdnTat = (HiddenField)dgRow.FindControl("hdTat");
                    HiddenField hdnWithinTat = (HiddenField)dgRow.FindControl("hdnWithinTat");
                    ///objclient.TATHRS = hdnTat.Value.ToString();

                    string strValue = objclient.TATHRS;
                    strValue = strValue.Replace(":", ".");

                    string strSTD = hdnStandardTAT.Value;
                    strSTD = strSTD.Replace(":", ".");

                    if (Convert.ToDouble(strValue) > Convert.ToDouble(strSTD))
                    //if (hdnTat.Value >= "24:00")
                    {
                        hdnWithinTat.Value = "0";

                    }
                    else
                    {
                        hdnWithinTat.Value = "1";
                    }

                    try
                    {
                        objclient.insertQCGridFields(strSendDate, hdnWithinTat.Value, "cpv_qc_case_details");
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
                CSendToClientFinal objSendClient = new CSendToClientFinal();
                //CCommon connobj = new CCommon();
                DateTime sFromDate;
                DateTime sToDate;
                sFromDate = Convert.ToDateTime(connobj.strDate(txtfromdate.Text.ToString().Trim()));
                sToDate = Convert.ToDateTime(connobj.strDate(txtToDate.Text.Trim())).AddDays(1.0);
                DataSet dsSendClient = new DataSet();
                dsSendClient = objSendClient.GetRecordsCellular(Session["ClientId"].ToString(), Session["CentreId"].ToString(), sFromDate, sToDate);
                if (dsSendClient.Tables[0].Rows.Count > 0)
                {
                    gvSendTat.DataSource = dsSendClient;
                    gvSendTat.DataBind();
                    pnlSendClient.Visible = true;
                    lblCount.Visible = true;
                    lblCount.Text = "Number of records:" + dsSendClient.Tables[0].Rows.Count;
                    hdnStandardTAT.Value = objSendClient.GerStandardTatHour(Session["ClientId"].ToString(), Session["ActivityId"].ToString(), Session["ProductId"].ToString());
                }
            }
            if (IsRecordSaved == true)
            {
                lblMsg.Visible = true;
                lblMsg.Text = "Record saved sucessfully.";
                txtSendDt.Text = DateTime.Now.ToString("dd/MM/yyyy");
                txtSendTm.Text = DateTime.Now.ToString("hh:mm");
                ddlSendTimeType.SelectedValue = DateTime.Now.ToString("tt");
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
