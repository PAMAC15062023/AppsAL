
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

public partial class Administrator_Label_Template_View_Cellular : System.Web.UI.Page
{
    CCommon objCom = new CCommon();
    OleDbDataAdapter da; 
    DataSet ds;
    DataTable d_table = new DataTable();    
    CLabelTemplate objLabel = new CLabelTemplate();
    CGet objGet = new CGet();   
    protected void Page_Load(object sender, EventArgs e)
    {
  
        chkSrNo.Checked = true;
        chkDate.Checked = true;
        ChkVerify.Checked = true;
       
        if (!IsPostBack)
        {      
            funFillActivity("");
            rbtnlst.SelectedValue = "L";
           if (Request.QueryString["templateID"] != null && Request.QueryString["templateID"] != "")
            {
                GetEditRecords();
             
              
            } 
        }
    }
    protected void ddl_activity_SelectedIndexChanged1(object sender, EventArgs e)
    {
        string strActivityID = ddl_activity.SelectedValue.ToString();
        //funFillVerificationType(strActivityID, "");
        funFillProduct(strActivityID, "");
        ddlclient.Items.Clear();
   
    }
    protected void ddlProduct_SelectedIndexChanged1(object sender, EventArgs e)
    {

        string strProductID = ddlProduct.SelectedValue.ToString();
        string strActivityID = ddl_activity.SelectedValue.ToString();
        funFillClients(strProductID, "");
        //if (ddlProduct.SelectedValue == "1014")
        //{
         //   Tbl_other.Visible = false;
        //}
        //if ((rbtnlst.SelectedValue == "S" && ddlProduct.SelectedValue == "1014"))
        //{
        //    funFillVerificationType(strActivityID, "");
        //}
        //else
        //{
            //funFillVerificationType(strActivityID, "");
        //}
    }
    protected void BTNSUBMIT_Click(object sender, EventArgs e)
    {
      
        if ((rbtnlst.SelectedValue == "") && (rbtnlst.SelectedValue == ""))
        {
            lblError.Text = " Please Select Template For Label  or Template For Sms  !!'";
        }
        
     
      else
         
        try
        {

            if (rbtnlst.SelectedValue == "S")
            {
                objLabel.TemplateType = "S";
            }

            if (rbtnlst.SelectedValue == "L")
            {
                objLabel.TemplateType = "L";
            }
            objLabel.ActivityID = ddl_activity.SelectedValue.ToString();
            objLabel.ProductID = ddlProduct.SelectedItem.Value.ToString();
            objLabel.ClientID = ddlclient.SelectedItem.Value.ToString();
            objLabel.VerificationId = ddlVerify.SelectedItem.Value.ToString();
            objLabel.Templatename = (txtTempName.Text).Trim().ToString();
            objLabel.Line_No = ddlLine.SelectedValue;
            objLabel.Charcter = txtchar.Text;
            objLabel.Address1 = txtADD1.Text;
            objLabel.Address2 = txtADD2.Text;  
          if (chkSrNo.Checked == true)
            {
                objLabel.Serialno = "Y";
            }
            else
            {
                objLabel.Serialno = "N";
            }
            if (chkDate.Checked == true)
            {
                objLabel.Printingdate = "Y";
            }
            else
            {
                objLabel.Printingdate = "N";
            }
            if (ChkVerify.Checked == true)
            {
                objLabel.Alltypeverification = "Y";
            }
            else
            {
                objLabel.Alltypeverification = "N";
            }

            DataTable dtPanel = new DataTable();
            dtPanel.Columns.Add("Serialno");
            dtPanel.Columns.Add("Line_No");
            dtPanel.Columns.Add("Tablename");
            dtPanel.Columns.Add("Selectedfield");
            DataRow dr;
            Label lblPanelID;
            DropDownList ddlSrNo;
            int nSrNo;
            int nCount = 0;

            foreach (GridViewRow gvRow in gvMap.Rows)
            {
                CheckBox chk = (CheckBox)gvRow.Cells[GridPosition.SELECTFIELD].FindControl("CheckBox1");
                if (chk.Checked == true)
                {
                    DropDownList ddlSERIALNO = (DropDownList)gvRow.Cells[GridPosition.SERIALNO].FindControl("ddlserial");
                    DropDownList ddlLineNO = (DropDownList)gvRow.Cells[GridPosition.LINE].FindControl("ddlline");
                    dr = dtPanel.NewRow();
                    dtPanel.Rows.Add();
                    dtPanel.Rows[nCount]["Serialno"] = ddlSERIALNO.SelectedValue.ToString();
                    dtPanel.Rows[nCount]["Line_No"] = ddlLineNO.SelectedValue.ToString();
                    dtPanel.Rows[nCount]["Tablename"] = gvRow.Cells[GridPosition.TABLE].Text;
                    dtPanel.Rows[nCount]["Selectedfield"] = gvRow.Cells[GridPosition.FIELD].Text;
                   nCount++;
                   
                }
              
                if (gvRow.Cells[GridPosition.FIELD].Text == "ACTUAL_DATE")
                {
                    lblMsg.Visible = true;
              
                }
            }
            objLabel.dsPanelList = new DataSet();
            objLabel.dsPanelList.Tables.Add(dtPanel);

            Boolean blnIsDuplicate = true;
            string strTemplate_ID = "";

            if (hidTemplateID.Value.ToString() != "")
            {
                strTemplate_ID = hidTemplateID.Value.ToString();
            }
            if (strTemplate_ID == "")
            {
                blnIsDuplicate = objLabel.getDuplicateValue("");
                if (blnIsDuplicate != true)
                {  
                    /*Calling Insert Function....*/
                    objLabel.IS_TYPE_SPECIFIC = "1";
                    objLabel.insertTemplate();
                    lblError.Text = "Template Created Successfully!!";
                }
                else
                {
                    lblError.Text = "Template Already exist!!";
                }
            }
            else
            {
                blnIsDuplicate = objLabel.getDuplicateValue(strTemplate_ID);
                if (blnIsDuplicate != true)
                {
                    objLabel.TemplateId = strTemplate_ID;
                    objLabel.updateTemplate();
                    lblError.Text = "Template Updated Successfully!!";
                }
                else
                {
                    lblError.Text = "Template Already exist!!";
                }
            }
        }
        catch (Exception exp)
        {
            lblError.Text = exp.Message;
        }
   
      
    }
    protected void gvMap_RowDataBound(object sender, GridViewRowEventArgs e)
    {

        DropDownList ddlLineNo;
        DropDownList ddlserialno;
          int ctr = Convert.ToInt32(ViewState["ddlLineSelectedValue"].ToString());
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                ddlLineNo = ((DropDownList)e.Row.FindControl("ddlline"));
                ddlLineNo.Items.Insert(0, new ListItem("Select One", "0"));
                ddlLineNo.DataBind();
                for (int i = 1; i <= ctr; i++)
                {
                    ddlLineNo.Items.Add(i.ToString());
                }
            }
       if (e.Row.RowType == DataControlRowType.DataRow)
        {
            ddlserialno = ((DropDownList)e.Row.FindControl("ddlserial"));
            ddlserialno.Items.Insert(0, new ListItem("Select One", "0"));
            ddlserialno.DataBind();
            for (int i = 1; i <= 35; i++)
            {
                ddlserialno.Items.Add(i.ToString());
            }
        }


        CLabelTemplate commonPrint = new CLabelTemplate();
        DataTable dtSelectedField = new DataTable();
        DataTable D_Total_Field = new DataTable();
        commonPrint.TemplateId = hidTemplateID.Value;
        dtSelectedField = commonPrint.getSelectedField();
        D_Total_Field = commonPrint.Get_Total_Field(objLabel.ActivityID, objLabel.ProductID);
        if (dtSelectedField.Rows.Count > 0)
        {
            foreach (GridViewRow row in gvMap.Rows)
            {
                CheckBox checkBox1 = (CheckBox)row.FindControl("CheckBox1");
                DropDownList ddlserial = (DropDownList)row.FindControl("ddlserial");
                DropDownList ddlline = (DropDownList)row.FindControl("ddlline");

                for (int j = 0; j < D_Total_Field.Rows.Count; j++)
                {

                    for (int i = 0; i < dtSelectedField.Rows.Count; i++)
                    {
                        if (row.Cells[0].Text.Trim() == D_Total_Field.Rows[j]["name"].ToString().Trim())
                        {
                            if (dtSelectedField.Rows[i]["SELECTED_FIELD"].ToString().Trim() == D_Total_Field.Rows[j]["name"].ToString())
                            {
                                checkBox1.Checked = true;
                                ddlserial.SelectedValue = dtSelectedField.Rows[i]["SERIAL_NO"].ToString();
                                ddlline.SelectedValue = dtSelectedField.Rows[i]["Line_NO"].ToString();
                            }
                        }

                    }
                }
            }

        }
    }
    public void FillGridOfSelectedField()
    {
        CLabelTemplate commonPrint = new CLabelTemplate();
        DataTable dtSelectedField = new DataTable();
        dtSelectedField = commonPrint.getSelectedField();
        gvMap.DataSource = dtSelectedField;
        gvMap.DataBind();
    }
    public void FillGridOfTotalField()
    {
        CLabelTemplate commonPrint = new CLabelTemplate();
        DataTable D_Total_Field = new DataTable();
        D_Total_Field = commonPrint.Get_Total_Field(objLabel.ActivityID, objLabel.ProductID);
        gvMap.DataSource = D_Total_Field;
        gvMap.DataBind();
    }
    public void Clear_All()
    {

        txtTempName.Text = "";
        //ddl_activity.SelectedValue = "0";
        //ddlclient.SelectedValue = "0";
        //ddlProduct.SelectedValue = "0";
        txtchar.Text = "";
        txtADD1.Text = "";
        txtADD2.Text = "";
        chkSrNo.Checked = false;
        chkDate.Checked = false;
        ChkVerify.Checked = false;

    }
    public struct GridPosition
    {
        public const int FIELD = 0;
        public const int SERIALNO = 1;
        public const int LINE = 2;
        public const int SELECTFIELD = 3;
        public const int TABLE = 4;

    }
    protected void ddlLine_SelectedIndexChanged(object sender, EventArgs e)
    {
        DataTable d_Tables = new DataTable();
        DataSet ds = new DataSet();
        objLabel.ActivityID = ddl_activity.SelectedValue;
        objLabel.ProductID = ddlProduct.SelectedValue;
        objLabel.Line_No = ddlLine.SelectedValue;
        ViewState["ddlLineSelectedValue"] = ddlLine.SelectedValue;
        ds = objLabel.getfielgrid(objLabel.ActivityID, objLabel.ProductID);
        d_Tables = ds.Tables[0];
        gvMap.DataSource = d_Tables;
        gvMap.DataBind();
    }
    public void GetEditRecords()
    {
        hidTemplateID.Value = Request.QueryString["templateID"].ToString();
        objLabel.TemplateId = hidTemplateID.Value;
        objLabel.getTemplates();
        ddl_activity.SelectedValue = objLabel.ActivityID;
        funFillVerificationType(objLabel.ActivityID, objLabel.VerificationId);
        funFillProduct(objLabel.ActivityID, objLabel.ProductID);
        funFillClients(objLabel.ProductID, objLabel.ClientID);
        txtTempName.Text = objLabel.Templatename;
        txtchar.Text = objLabel.Charcter;
        ddlLine.SelectedItem.Text = objLabel.Line;
        string chkno = objLabel.Serialno;
        string chkdate1 = objLabel.Printingdate;
        string chkveriyed = objLabel.Alltypeverification;
        if (chkno == "Y")
        {
            chkSrNo.Checked = true;
        }
        if (chkdate1 == "Y")
        {
            chkDate.Checked = true;
        }
        if (chkveriyed == "Y")
        {
            ChkVerify.Checked = true;
        }
        
        ViewState["ddlLineSelectedValue"] = objLabel.Line;
        txtADD1.Text = objLabel.Address1;
        txtADD2.Text = objLabel.Address2;
        FillGridOfTotalField();
        if (objLabel.TemplateType == "S")
        {
           
            rbtnlst.SelectedValue = "S";

            
        }
        else
        {
            rbtnlst.SelectedValue = "L";
           
        }
    
    }   
    public OleDbDataReader getinfo()
    {
        OleDbConnection conn = new OleDbConnection(objCom.ConnectionString);
        CLabelTemplate commonPrint = new CLabelTemplate();
        conn.Open();
        String sqlQuery = "";
        sqlQuery = "SELECT LPTM.template_name,apc.client_name,apc.client_id,apc.activity_name,apc.activity_id,apc.product_name,apc.product_id,vtm.verification_type_code ,vtm.verification_type_id  ,lptm.lines,lptm.Charcterlength,lptm.additional1,lptm.additional2,lptm.sr_no,lptm.label_printing_date,lptm.all_verification_type from LABEL_PRINTING_TEMPLATE_MASTER as lptm inner join ce_ac_pr_ct_vw as apc on lptm.client_id=apc.client_id and lptm.activity_id=apc.activity_id and lptm.product_id=apc.product_id inner join verification_type_master as vtm on lptm.verification_type_id=vtm.verification_type_id   where lptm.label_template_id= " + Session["TemplateId"] + " ";
        return commonPrint.getDatainfo(sqlQuery);
    }   
    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.Redirect("Label_Printing_manage_Cellular.aspx");
    }       
    protected void ddlLine_DataBound(object sender, EventArgs e)
    {
        ddlLine.Items.Insert(0, new ListItem("--Select Line No--", "0"));

    }  
    public void FillVerificationType(string strActivityID, string strVeriTypeID)
    {
        DataSet ds = new DataSet();
      
            ds = objLabel.Verification();
            ddlVerify.Items.Clear();
            ListItem liVeriType = new ListItem("--Select Verification Type--", "");
            ddlVerify.Items.Add(liVeriType);

            if (ds != null)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    for (int k = 0; k < ds.Tables[0].Rows.Count; k++)
                    {
                        liVeriType = new ListItem((string)ds.Tables[0].Rows[k]["VERIFICATION_TYPE_CODE"], (string)ds.Tables[0].Rows[k]["VERIFICATION_TYPE_ID"]);
                        ddlVerify.Items.Add(liVeriType);
                    }
                   
                }
            }
            ds.Clear();
       
    }
    public void FillProduct(string strActivityID, string strProductID)
    {
        DataSet ds = new DataSet();
      
            ddl_activity.SelectedValue = strActivityID;
            ds = objLabel.Product();

            ddlProduct.Items.Clear();
            ListItem liProduct = new ListItem("--Select Product--", "");
            ddlProduct.Items.Add(liProduct);

            if (ds != null)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    for (int k = 0; k < ds.Tables[0].Rows.Count; k++)
                    {
                        liProduct = new ListItem((string)ds.Tables[0].Rows[k]["PRODUCT_NAME"], (string)ds.Tables[0].Rows[k]["PRODUCT_ID"]);
                        ddlProduct.Items.Add(liProduct);
                    }
                    if (strProductID != "")
                    {
                        ddlProduct.SelectedValue = strProductID;
                    }

                }
            }
            ds.Clear();
      
}
    public void FillClients(string strProductID, string strClientID)
    {
        DataSet ds = new DataSet();
        CLabelTemplate objLabel = new CLabelTemplate();
      
            ddlProduct.SelectedValue = strProductID;
            ds = objLabel.Client1();
            ddlclient.Items.Clear();
            ListItem liClient = new ListItem("--Select Client--", "");
            ddlclient.Items.Add(liClient);

            if (ds != null)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    for (int k = 0; k < ds.Tables[0].Rows.Count; k++)
                    {
                        liClient = new ListItem((string)ds.Tables[0].Rows[k]["CLIENT_NAME"], (string)ds.Tables[0].Rows[k]["CLIENT_ID"]);
                        ddlclient.Items.Add(liClient);
                    }
                    if (strClientID != "")
                    {
                        ddlclient.SelectedValue = strClientID;
                    }
                }
            }
        }
    public void funFillActivity(string strActivityID)
    {
        DataSet ds = new DataSet();

        if (strActivityID == "")
        {
            ds = objGet.getActivities();
            ddl_activity.Items.Clear();
            ListItem liActivities = new ListItem("--Select Activity--", "");
            ddl_activity.Items.Add(liActivities);

            if (ds != null)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    for (int k = 0; k < ds.Tables[0].Rows.Count; k++)
                    {
                        liActivities = new ListItem((string)ds.Tables[0].Rows[k]["ACTIVITY_NAME"], (string)ds.Tables[0].Rows[k]["ACTIVITY_ID"]);
                        ddl_activity.Items.Add(liActivities);
                    }
                }
            }
            ds.Clear();
        }

        if (strActivityID != "")
        {
            ddl_activity.SelectedValue = strActivityID;
        }
    }
    public void funFillVerificationType(string strActivityID, string strVeriTypeID)
    {
        DataSet ds = new DataSet();
        if (strActivityID != "")
        {
            if ((rbtnlst.SelectedValue == "S") && (ddlProduct.SelectedValue == "1014"))
            {
                ds = objGet.getVerificationTypeForSms("1");
            }
            else
            {
                ds = objGet.getVerificationType(strActivityID);
            }

            ddlVerify.Items.Clear();
            ListItem liVeriType = new ListItem("--Select Verification Type--", "");
            ddlVerify.Items.Add(liVeriType);

            if (ds != null)
            {
                //if (ds.Tables[0].Rows.Count > 0)
                //{
                    //for (int k = 0; k < ds.Tables[0].Rows.Count; k++)
                    //{
                    //    liVeriType = new ListItem((string)ds.Tables[0].Rows[k]["VERIFICATION_TYPE_CODE"], (string)ds.Tables[0].Rows[k]["VERIFICATION_TYPE_ID"]);
                    //    ddlVerify.Items.Add(liVeriType);
                    //}
                    if (strVeriTypeID != "")
                    {
                        ddlVerify.SelectedValue = strVeriTypeID;
                    }
                //}
            }
            ds.Clear();
        }
    }
    public void funFillProduct(string strActivityID, string strProductID)
    {
        DataSet ds = new DataSet();
        if (strActivityID != "")
        {
            ddl_activity.SelectedValue = strActivityID;
            ds = objGet.getProducts(strActivityID);

            ddlProduct.Items.Clear();
            ListItem liProduct = new ListItem("--Select Product--", "");
            ddlProduct.Items.Add(liProduct);

            if (ds != null)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    for (int k = 0; k < ds.Tables[0].Rows.Count; k++)
                    {
                        liProduct = new ListItem((string)ds.Tables[0].Rows[k]["PRODUCT_NAME"], (string)ds.Tables[0].Rows[k]["PRODUCT_ID"]);
                        ddlProduct.Items.Add(liProduct);
                    }
                    if (strProductID != "")
                    {
                        ddlProduct.SelectedValue = strProductID;
                    }

                }
            }
            ds.Clear();
        }
    }
    public void funFillClients(string strProductID, string strClientID)
    {
        DataSet ds = new DataSet();
        if (strProductID != "")
        {
            ddlProduct.SelectedValue = strProductID;
            ds = objGet.getClients(strProductID);
            ddlclient.Items.Clear();
            ListItem liClient = new ListItem("--Select Client--", "");
            ddlclient.Items.Add(liClient);

            if (ds != null)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    for (int k = 0; k < ds.Tables[0].Rows.Count; k++)
                    {
                        liClient = new ListItem((string)ds.Tables[0].Rows[k]["CLIENT_NAME"], (string)ds.Tables[0].Rows[k]["CLIENT_ID"]);
                        ddlclient.Items.Add(liClient);
                    }
                    if (strClientID != "")
                    {
                        ddlclient.SelectedValue = strClientID;
                    }
                }
            }
        }
    }
    protected void rbtnlst_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (rbtnlst.SelectedValue == "S")
        {
           
            txtchar.Enabled = false;
            txtADD1.Enabled = false;
            txtADD2.Enabled = false;
            chkSrNo.Enabled = false;
            chkDate.Enabled = false;
            ChkVerify.Enabled = false;

        }
        else 
        {

            txtchar.Enabled = true;
            txtADD1.Enabled = true;
            txtADD2.Enabled = true;
            chkSrNo.Enabled = true;
            chkDate.Enabled = true;
            ChkVerify.Enabled = true;
        }
       
    }
    protected void ddlProduct_PreRender(object sender, EventArgs e)
    {

    }


}

 





