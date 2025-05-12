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

public partial class Administrator_kyc_Export_new_tempate : System.Web.UI.Page
{
    CKYC_Export objExport = new CKYC_Export();

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
                            ddlClient.SelectedValue = oledbReadTemplate["Client_Id"].ToString();
                        }
                        oledbReadTemplate.Close();
                        OleDbDataReader oledbReadTempDtl;
                        oledbReadTempDtl = objExport.GetTemplateDtl(Request.QueryString["TempId"].ToString());
                        try
                        {
                            while (oledbReadTempDtl.Read())
                            {


                                if (gv.Rows.Count > 0)
                                {
                                    foreach (GridViewRow row in gv.Rows)
                                    {
                                        TextBox txt = (TextBox)row.FindControl("txtalias");
                                        TextBox txtsrno = (TextBox)row.FindControl("txtSrNo");
                                        HiddenField hid = (HiddenField)row.FindControl("HiddenFieldName");
                                        string strFieldName1 = oledbReadTempDtl["FIELD_NAME"].ToString();
                                        strFieldName1 = strFieldName1.Substring(0, strFieldName1.LastIndexOf("AS")).ToString();
                                        string strFieldName = oledbReadTempDtl["FIELD_NAME"].ToString();
                                        strFieldName = strFieldName.Substring(strFieldName.LastIndexOf("AS") + 3).ToString();// LastIndexOf("AS").ToString();

                                        if (hid.Value.Trim() == strFieldName1.Trim())
                                        {
                                            txt.Text = strFieldName.TrimEnd(']').TrimStart('[');
                                            txtsrno.Text = oledbReadTempDtl["SR_NO"].ToString().Trim();
                                        }

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
            bool val = true;
            if (gv.Rows.Count > 0)
            {
                
                 foreach (GridViewRow row in gv.Rows)
                {

                   
                    HiddenField hid = (HiddenField)row.FindControl("HiddenFieldName");
                    TextBox txtsrno = (TextBox)row.FindControl("txtSrNo");
                    TextBox txt = (TextBox)row.FindControl("txtalias");
                    if (txtsrno.Text !="")
                    {
                        object o = hid.Value +" " + "AS" + " " +"[" + txt.Text + "]";
                        arrExportFields.Add(o);
                        arrSrNo.Add(txtsrno.Text.Trim().ToString());
                    }
                    if ((txtsrno.Text.Trim() != "") && (txt.Text.Trim() == ""))
                    {
                        val = false;
                    }
                    if ((txtsrno.Text.Trim() == "") && (txt.Text.Trim() != ""))
                    {
                        val = false;
                    }
                }
            }
            objExport.TemplateName = txtTemplate.Text.Trim();
            objExport.ClientID = ddlClient.SelectedValue.ToString();
            oledbRead = objExport.GetExportTemplate(ddlClient.SelectedValue.ToString());
            if (val == true)
            {
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
                        lblMsg.Text = "Template already exists for this Client.";
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
            else
            {
                lblMsg.Visible = true;
                lblMsg.Text = "please select or put the alias name ";
                lblMsg.ForeColor = System.Drawing.Color.Red;
            }

        }
        catch (Exception ex)
        {
            lblMsg.Visible = true;
            lblMsg.Text = ex.Message;
            lblMsg.ForeColor = System.Drawing.Color.Red;
        }
        if (iCount == 1)
            Response.Redirect("kyc_Export_Template.aspx?Msg=" + lblMsg.Text.Trim());
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("kyc_Export_Template.aspx");
    }



    //protected void gv_RowDataBound(object sender, GridViewRowEventArgs e)
    //{
    //    //TextBox txtSrNo;
      
    //    //if (e.Row.RowType == DataControlRowType.DataRow)
    //    //{
    //    //    txtSrNo = ((DropDownList)e.Row.FindControl("ddlSrNo"));
           
    //    //    //lblTemplateField = ((Label)e.Row.FindControl("lblTemplateField"));

    //    //    ddlSrNo.Items.Insert(0, new ListItem("Select One", "0"));
    //    //    ddlSrNo.DataBind();
    //    //    int iCnt=Convert.ToInt16(hdCnt.Value.ToString());
    //    //    for (int i = 1; i <= iCnt; i++)
    //    //    {

    //    //        ddlSrNo.Items.Add(i.ToString());
    //    //        //ddlSrNo.SelectedValue = i.ToString();
    //    //        //ddlSrNo.DataBind();
    //    //    }



    //    //}
    //}


}
