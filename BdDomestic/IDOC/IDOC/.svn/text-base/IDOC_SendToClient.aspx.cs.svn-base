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

public partial class IDOC_IDOC_IDOC_SendToClient : System.Web.UI.Page
{
    CCommon connobj = new CCommon();
    protected void Page_Load(object sender, EventArgs e)
    {
        txtfromdate.Focus();
        tblImg.Visible = false;
        if (Session["isAdd"].ToString() != "1")
            Response.Redirect("NoAccess.aspx");

       if (Session["isEdit"].ToString() != "1")
         Response.Redirect("NoAccess.aspx");

    }
    protected void btnCalcTat_Click(object sender, EventArgs e)
    {
        try
        {
            DateTime strSendDate;
            DateTime strToDate;
            CIDOC_SendToClient objclient = new CIDOC_SendToClient();
            strToDate = Convert.ToDateTime(connobj.strDate(Txttodate1.Text.Trim()));          
            String s1 = Convert.ToDateTime(connobj.strDate(txtSendDt.Text.Trim())).ToString("MM/dd/yyyy") + " " + txtSendTm.Text.ToString() + " " + ddlSendTimeType.SelectedItem.Text.Trim().ToString();
            strSendDate = Convert.ToDateTime(s1.ToString());          
            if (strSendDate > strToDate)
            {
              string TatHour = objclient.GerStandardTatHour();
              if (TatHour != "")
              {
                  double standardTatHour;
                  lbldatavalidation.Visible = false;
                  btnSentToClient.Enabled = true;
                  tblImg.Visible = true;
                  gvSearch.Visible = false;
                  gvSendTat.Visible = true;
                  btnSentToClient.Enabled = true;
                  DataTable dtable = new DataTable();
                  objclient.SendDate = txtSendDt.Text.Trim().ToString();
                  objclient.SendTime = txtSendTm.Text.ToString();
                  string Tdate = Txttodate1.Text.Trim();
                  DateTime sFromdate = Convert.ToDateTime(connobj.strDate(txtfromdate.Text.ToString().Trim()));
                  DateTime sToDate = Convert.ToDateTime(connobj.strDate(Tdate)).AddDays(1.0);
                  Double StandardHour = System.Convert.ToDouble(TatHour);
                  objclient.SendTimeType = ddlSendTimeType.SelectedItem.Text.Trim();
                  dtable = objclient.GetTAT(sFromdate, sToDate);
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
                  lbldatavalidation.Text = "Please First Set Standard Tat Hour !! ";
              
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

                CIDOC_SendToClient objclient = new CIDOC_SendToClient();
                DataTable d_table = new DataTable();
                DataSet ds = new DataSet();
                lblmessage.Visible = false;
                string Tdate = Txttodate1.Text.Trim();

                
               
                

                DateTime sFromDate;
                DateTime sToDate;

                sFromDate = Convert.ToDateTime(connobj.strDate(txtfromdate.Text.ToString().Trim()));;


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

                CIDOC_SendToClient objclient = new CIDOC_SendToClient();

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
    }
    protected void gvSendTat_RowDataBound(object sender, GridViewRowEventArgs e)
    {

    }
    protected void gvSendTat_Sorting(object sender, GridViewSortEventArgs e)
    {

    }
    public bool FunctioncompareDate()
    {
        CCommon objCom = new CCommon();
        DateTime sFromDate;
        DateTime sToDate;
        sFromDate = Convert.ToDateTime(objCom.strDate(txtfromdate.Text.ToString().Trim()));
        sToDate = Convert.ToDateTime(objCom.strDate(Txttodate1.Text.ToString().Trim()));

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
