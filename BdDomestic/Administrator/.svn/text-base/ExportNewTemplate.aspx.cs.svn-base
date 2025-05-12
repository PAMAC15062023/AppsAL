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

public partial class Administrator_ExportNewTemplate : System.Web.UI.Page
{
    CCEL_Export objExport = new CCEL_Export();
    HiddenField hdCnt;
    protected void Page_Load(object sender, EventArgs e)
    {
        txtTemplate.Focus();
        hdCnt = new HiddenField();
        if (!IsPostBack)
        {
            DataSet ds = new DataSet();
            ds = objExport.GetExportFields();
            if (ds.Tables.Count > 0)
            {
                hdCnt.Value = ds.Tables[0].Rows.Count.ToString();
            }

            if (Context.Request.QueryString["Op"] != null && Context.Request.QueryString["Op"] != "")
            {
                if (Request.QueryString["Op"].ToString() == "Edit")
                {
                    OleDbDataReader oledbReadTemplate;
                    oledbReadTemplate = objExport.GetTemplateMasterDtl(Request.QueryString["TempId"].ToString());
                    if (oledbReadTemplate.Read() == true)
                    {
                        txtTemplate.Text = oledbReadTemplate["Template_name"].ToString();
                        ddlCaseType.SelectedValue = oledbReadTemplate["Case_Type_Id"].ToString();
                    }
                    oledbReadTemplate.Close();
                    OleDbDataReader oledbReadTempDtl;
                    oledbReadTempDtl = objExport.GetTemplateDtl(Request.QueryString["TempId"].ToString());
                    while (oledbReadTempDtl.Read())
                    {
                        if (gv.Rows.Count > 0)
                        {
                            foreach (GridViewRow row in gv.Rows)
                            {
                                //CheckBox chk = (CheckBox)row.FindControl("chkID");
                                TextBox txtSrNo = (TextBox)row.FindControl("txtSrNo");
                                HiddenField hid = (HiddenField)row.FindControl("HiddenFieldName");
                                if (hid.Value.Trim() == oledbReadTempDtl["FIELD_NAME"].ToString().Trim())
                                {
                                    //chk.Checked = true;
                                    txtSrNo.Text = oledbReadTempDtl["SR_NO"].ToString().Trim();
                                }

                            }
                        }
                    }
                    oledbReadTempDtl.Close();
                }
            }
        }
    }
   
    protected void btnSave_Click(object sender, EventArgs e)
    {
        int iCount = 0;
        objExport.ClientID = Session["ClientID"].ToString();
        try
        {
            OleDbDataReader oledbRead;
            ArrayList arrExportFields = new ArrayList();
            ArrayList arrSrNo = new ArrayList();
            if (gv.Rows.Count > 0)
            {

                foreach (GridViewRow row in gv.Rows)
                {

                    //CheckBox chk = (CheckBox)row.FindControl("chkID");
                    HiddenField hid = (HiddenField)row.FindControl("HiddenFieldName");
                    TextBox txtSrNo = (TextBox)row.FindControl("txtSrNo");
                    if (txtSrNo.Text != "")
                    {
                        arrExportFields.Add(hid.Value);
                        arrSrNo.Add(txtSrNo.Text.ToString());
                    }
                }
            }
            objExport.TemplateName = txtTemplate.Text.Trim();
            objExport.CaseTypeId = ddlCaseType.SelectedValue.ToString();
            oledbRead = objExport.GetExportTemplate(ddlCaseType.SelectedValue.ToString());
            if (oledbRead.Read() != true)
            {
                if (objExport.InsertExportTemplate(arrExportFields, arrSrNo) == 1)
                {
                    lblMsg.Visible = true;
                    lblMsg.Text = "Record added successfully.";
                    lblMsg.ForeColor = System.Drawing.Color.Red;
                    iCount = 1;
                }
            }
            else
            {
                if (Request.QueryString["Op"].ToString() == "Add")
                {
                    lblMsg.Visible = true;
                    lblMsg.Text = "Template already exists for this case type.";
                    lblMsg.ForeColor = System.Drawing.Color.Red;
                }
                else
                {
                    objExport.TemplateId = Request.QueryString["TempId"].ToString();
                    if (objExport.UpdateExportTemplate(arrExportFields, arrSrNo) == 1)
                    {
                        lblMsg.Visible = true;
                        lblMsg.Text = "Record updated successfully.";
                        lblMsg.ForeColor = System.Drawing.Color.Red;
                        iCount = 1;
                    }
                }
            }
            

        }
        catch (Exception ex)
        {
            lblMsg.Visible = true;
            lblMsg.Text = ex.Message;
            lblMsg.ForeColor = System.Drawing.Color.Red;
        }
        if (iCount == 1)
            Response.Redirect("ExportTemplate.aspx?Msg=" + lblMsg.Text.Trim());
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("ExportTemplate.aspx");
    }
    //protected void gv_RowDataBound(object sender, GridViewRowEventArgs e)
    //{
    //    DropDownList ddlSrNo;

    //    if (e.Row.RowType == DataControlRowType.DataRow)
    //    {
    //        ddlSrNo = ((DropDownList)e.Row.FindControl("ddlSrNo"));

    //        //lblTemplateField = ((Label)e.Row.FindControl("lblTemplateField"));

    //        ddlSrNo.Items.Insert(0, new ListItem("Select One", "0"));
    //        ddlSrNo.DataBind();
    //        int iCnt = Convert.ToInt16(hdCnt.Value.ToString());
    //        for (int i = 1; i <= iCnt; i++)
    //        {

    //            ddlSrNo.Items.Add(i.ToString());
    //            //ddlSrNo.SelectedValue = i.ToString();
    //            //ddlSrNo.DataBind();
    //        }



    //    }

    //}
}
