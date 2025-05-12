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
public partial class CPV_RL_RL_Sms_Generation : System.Web.UI.Page
{
    C_Sms_Generation obj_GenerateSms = new C_Sms_Generation();
    CCommon connobj = new CCommon();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DataSet ds = new DataSet();
            string activityid = Session["ActivityId"].ToString();
            ds = obj_GenerateSms.GetVerificationType_RL(activityid);
            ddlVerificationId.DataTextField = "VERIFICATION_TYPE_CODE";
            ddlVerificationId.DataValueField = "VERIFICATION_TYPE_ID";
            ddlVerificationId.DataSource = ds;
            ddlVerificationId.DataBind();
        }

    }
    protected void brnSearch_Click(object sender, EventArgs e)
    {

        try
        {
           
            DataTable dtable = new DataTable();
            lblMessage.Text = "";
            obj_GenerateSms.VerificationId = ddlVerificationId.SelectedValue.ToString();
            dtable = obj_GenerateSms.finalrecordNew(Session["RoleId"].ToString(),Convert.ToDateTime(connobj.strDate(txtFromDate.Text.Trim().ToString())), Convert.ToDateTime(connobj.strDate(txtToDate.Text.Trim())).AddDays(1.0), Session["CentreId"].ToString(), Session["ClientId"].ToString());
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
        public const int sms = 7;
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
                    obj_GenerateSms.Sms = txtSms.Text;
                    obj_GenerateSms.CaseId = dgRow.Cells[GridPosition.CaseId].Text;
                    obj_GenerateSms.VerificationId = ddlVerificationId.SelectedValue.ToString();
                    if (obj_GenerateSms.Sms != "" && obj_GenerateSms.Mobile != "")
                    {
                        msgInfo = obj_GenerateSms.insertGridFieldsRL(Session["RoleId"].ToString(), "CPV_RL_CASE_DETAILS", "CPV_RL_CASE_VERIFICATIONTYPE");
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
    protected void Gview_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {          
            TextBox context = (TextBox)e.Row.FindControl("txtSms");
            //this java script function clear content data.
            context.Attributes.Add("onkeydown", "javascript:window.clipboardData.clearData()");
        }
    }
    //protected void Page_Load(object sender, EventArgs e)
    //{

    //}
    //protected void brnSearch_Click(object sender, EventArgs e)
    //{
    //    try
    //    {

    //        String str = finalrecord();
    //        if (str != "")
    //        {
    //            C_Sms_Generation obj_GenerateSms = new C_Sms_Generation();
    //            DataTable dtable = new DataTable();
    //            bool dateIsValid = false;
    //            dateIsValid = FunctioncompareDate();
    //            lblMessage.Text = "";
    //            if (dateIsValid == true)
    //            {
    //                btnSend.Visible = true;
    //                dtable = obj_GenerateSms.GetRecord(str);
    //                if (dtable.Rows.Count > 0)
    //                {
    //                    Gview.DataSource = dtable;
    //                    foreach (GridViewRow gvRow in Gview.Rows)
    //                    {
    //                        TextBox Mobile = (TextBox)gvRow.FindControl("txtMobile");
    //                        TextBox SmsContent = (TextBox)gvRow.FindControl("txtSms");
    //                        for (int i = 0; i < dtable.Rows.Count; i++)
    //                        {
    //                            SmsContent.Text = dtable.Rows[i]["SmsContent"].ToString().Trim();
    //                            Mobile.Text = dtable.Rows[i]["MOBILE"].ToString();

    //                        }
    //                    }

    //                    Gview.DataBind();
    //                }
    //                else
    //                {
    //                    btnSend.Visible = false;
    //                    Gview.DataSource = "";
    //                    Gview.DataBind();
    //                    lblMessage.Text = " No Records are Found !!";

    //                }


    //            }
    //            else
    //            {

    //                lblMessage.Text = "FromDate Must Be Less Then ToDate !! ";

    //            }
    //        }
    //        else
    //        {
    //            lblMessage.Text = "No Records Found !! ";
    //        }
    //    }

    //    catch (Exception ex)
    //    {
    //        throw new Exception(ex.Message);
    //    }
    //}
    ////
     ////TextBox Mobile = (TextBox)gvRow.FindControl("txtMobile");
     ////                       TextBox SmsContent = (TextBox)gvRow.FindControl("txtSms");
     ////                       for (int i = 0; i < dtable.Rows.Count; i++)
     ////                       {
     ////                           SmsContent.Text = dtable.Rows[i]["SmsContent"].ToString().Trim();
     ////                           Mobile.Text = dtable.Rows[i]["MOBILE"].ToString();

     ////                       }

    //public bool FunctioncompareDate()
    //{
        
    //    DateTime sFromDate;
    //    DateTime sToDate;
    //    sFromDate = Convert.ToDateTime(connobj.strDate(txtFromDate.Text.Trim().ToString()));
    //    sToDate = Convert.ToDateTime(connobj.strDate(txtToDate.Text.Trim()));





    //    bool bReturn = true;
    //    if (sFromDate > sToDate)
    //    {
    //        bReturn = false;
    //    }
    //    else
    //    {
    //        bReturn = true;


    //    }
    //    return bReturn;
    //}

    //public struct GridPosition
    //{
    //    public const int sms = 7;
    //    public const int mobile = 6;
    //    public const int CaseId = 0;

    //}

    //public String finalrecord()
    //{
    //    //DateTime sFromDate;
    //    //DateTime sToDate;
    //    //string strTableName = "";
    //    //string strSQL = "";
    //    //DataSet dsLabelQuery = new DataSet();
    //    //string Tdate = txtToDate.Text.Trim().ToString();
    //    //sFromDate = Convert.ToDateTime(connobj.strDate(txtFromDate.Text.Trim().ToString()));
    //    //sToDate = Convert.ToDateTime(connobj.strDate(Tdate)).AddDays(1.0);
    //    //dsLabelQuery = obj_GenerateSms.getTemplateForSms();
    //    //try
    //    //{
    //    //    if (dsLabelQuery.Tables[0].Rows.Count > 0)
    //    //    {


    //    //        for (int i = 0; i < dsLabelQuery.Tables[0].Rows.Count; i++)
    //    //        {
    //    //            strTableName = dsLabelQuery.Tables[0].Rows[i]["TABLE_NAME"].ToString();
    //    //            strSQL = strSQL + "+ ' ' +ISNULL(" + dsLabelQuery.Tables[0].Rows[i]["SELECTED_FIELD"].ToString() + ",'')";

    //    //        }

    //    //        strSQL = "SELECT " + strSQL + " AS SmsContent ," + " ccc.CASE_ID,ccc.REF_NO, v.FullName, (ISNULL(ccc.FIRST_NAME,'')+'  '+ISNULL(ccc.MIDDLE_NAME,'')+'  '+ISNULL(ccc.LAST_NAME,'')) AS APPLICANT_NAME, (ISNULL(ccc.RES_ADD_LINE_1,'')+'  '+ISNULL(ccc.RES_ADD_LINE_2,'')+'  '+ISNULL(ccc.RES_ADD_LINE_3,'')) AS ADDRESS, CONVERT(CHAR(9), ccc.CASE_REC_DATETIME, 3) + LTRIM(SUBSTRING(CONVERT( VARCHAR(20), ccc.CASE_REC_DATETIME, 22), 10, 5) + RIGHT(CONVERT(VARCHAR(20), ccc.CASE_REC_DATETIME, 22), 3)) as REC_DATETIME , ccc.MOBILE FROM CPV_RL_CASE_DETAILS  as ccc  inner join CPV_RL_CASE_FE_MAPPING as ccva on ccc.CASE_ID=ccva.CASE_ID inner join fe_vw as v on v.emp_id = ccva.VERIFIER_id   WHERE CCC.SEND_DATETIME IS NULL AND  ccc.CASE_REC_DATETIME >= '" + sFromDate + "' AND ccc.CASE_REC_DATETIME <  '" + sToDate + "' and  ccc.Centre_id = '" + Session["CentreId"].ToString() + "'   and  ccc.Client_id ='" + Session["ClientId"].ToString() + " ' ";


    //    //    }
    //    //}
    //    //catch (Exception ex)
    //    //{

    //    //    throw new Exception(ex.Message);
    //    //}
    //    //return strSQL;


    //}
    //protected void Gview_RowDataBound(object sender, GridViewRowEventArgs e)
    //{


    //}

    //protected void btnSend_Click(object sender, EventArgs e)
    //{

    //    try
    //    {
    //        obj_GenerateSms.Sms_Date_Time = DateTime.Now;
    //        if (Gview.Rows.Count > 0)
    //        {
    //            int i = 0;
    //            foreach (GridViewRow row in Gview.Rows)
    //            {

    //                CheckBox chk1 = (CheckBox)row.FindControl("ChkSelect");
    //                if (chk1.Checked == true)
    //                {

    //                    chk1.Checked = true;
    //                    i = 1;
    //                }

    //            }



    //            if (i == 1)
    //            {

    //                for (Int32 j = 0; j < Gview.Rows.Count; j++)
    //                {
    //                    GridViewRow dgRow = Gview.Rows[j];
    //                    TextBox txtCell = (TextBox)dgRow.Cells[GridPosition.sms].FindControl("txtMobile");
    //                    TextBox txtSms = (TextBox)dgRow.Cells[GridPosition.mobile].FindControl("txtSms");
    //                    CheckBox chk = (CheckBox)dgRow.FindControl("ChkSelect");
    //                    if (chk.Checked == true)
    //                    {
    //                        obj_GenerateSms.Mobile = txtCell.Text;
    //                        obj_GenerateSms.Sms = txtSms.Text;

    //                        //
    //                        //call fuction
    //                        //


    //                        obj_GenerateSms.CaseId = dgRow.Cells[GridPosition.CaseId].Text;
    //                        obj_GenerateSms.insertGridFieldsRL();
    //                        lblMessage.Text = "Records Send Successfully !! ";

    //                    }


    //                }

    //            }

    //            else
    //            {

    //                lblMessage.Text = "Please Select Atleast One Record !! ";
    //            }
    //        }
    //    }

    //    catch (Exception ex)
    //    {

    //        throw new Exception("Error While Sending " + ex.Message);
    //    }

    //}

    //protected void Gview_Sorting(object sender, GridViewSortEventArgs e)
    //{


    //                string sortExpression = e.SortExpression;

    //                if (GridViewSortDirection == SortDirection.Ascending)

    //                {

    //                GridViewSortDirection = SortDirection.Descending;

    //                SortGridView(sortExpression, DESCENDING);
    //                SortGridView(sortExpression);

    //                }

    //                else

    //                {

    //                GridViewSortDirection = SortDirection.Ascending;

    //                SortGridView(sortExpression, ASCENDING); 
    //                SortGridView(sortExpression); 

    //                } 




    //}


    ////private void SortGridView(string sortExpression, string direction)
    //////private void SortGridView(string sortExpression)
    //// {

    ////     // You can cache the DataTable for improving performance
    ////     DataTable dt = new DataTable();
    ////     String str = finalrecord();
    ////     dt = obj_GenerateSms.GetRecord(str);

    ////    //dt = GetData().Tables[0];

    ////     DataView dv = new DataView(dt);

    ////     dv.Sort = sortExpression + direction;

    ////     Gview.DataSource = dv;

    ////     Gview.DataBind();

    //// }

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




    protected void ddlVerificationId_DataBound(object sender, EventArgs e)
    {
        ddlVerificationId.Items.Insert(0, new ListItem("--Select verification type--", "0"));
    }
   

   
}
