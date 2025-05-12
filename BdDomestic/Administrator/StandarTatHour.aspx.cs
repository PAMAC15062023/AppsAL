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

public partial class Administrator_StandarTatHour : System.Web.UI.Page
{
    C_StandardTatHour objStandardHour = new C_StandardTatHour();
    CCommon objcomman = new CCommon();
    DataSet ds = new DataSet();
    DataTable d_table = new DataTable();
    DataRow dr;
    string Message;
    DataColumn dcol = new DataColumn();
    CGet objGet = new CGet();   
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            funFillActivity("");          
            string tatId = Request.QueryString["tatId"];          


            if (Request.QueryString["tatId"] != null && Request.QueryString["tatId"] != "")
            {              
                objStandardHour.StandardTatHour = Request.QueryString["tatId"];
                GetItem();
            }
        }

    }
    public void funFillActivity(string strActivityID)
    {
        DataSet ds = new DataSet();

        if (strActivityID == "")
        {
            ds = objGet.getActivities();
            ddlActivity.Items.Clear();
            ListItem liActivities = new ListItem("--Select Activity--", "0");
            ddlActivity.Items.Add(liActivities);

            if (ds != null)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    for (int k = 0; k < ds.Tables[0].Rows.Count; k++)
                    {
                        liActivities = new ListItem((string)ds.Tables[0].Rows[k]["ACTIVITY_NAME"], (string)ds.Tables[0].Rows[k]["ACTIVITY_ID"]);
                        ddlActivity.Items.Add(liActivities);
                    }
                }
            }
            ds.Clear();
        }

        if (strActivityID != "")
        {
            ddlActivity.SelectedValue = strActivityID;
        }
    }
    public void funFillProduct(string strActivityID, string strProductID)
    {
        DataSet ds = new DataSet();
        if (strActivityID != "")
        {
            ddlActivity.SelectedValue = strActivityID;
            ds = objGet.getProducts(strActivityID);

            ddlProduct.Items.Clear();
            ListItem liProduct = new ListItem("--Select Product--", "0");
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
            ddlClient.Items.Clear();
            ListItem liClient = new ListItem("--Select Client--", "0");
            ddlClient.Items.Add(liClient);

            if (ds != null)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    for (int k = 0; k < ds.Tables[0].Rows.Count; k++)
                    {
                        liClient = new ListItem((string)ds.Tables[0].Rows[k]["CLIENT_NAME"], (string)ds.Tables[0].Rows[k]["CLIENT_ID"]);
                        ddlClient.Items.Add(liClient);
                    }
                    if (strClientID != "")
                    {
                        ddlClient.SelectedValue = strClientID;
                    }
                }
            }
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
       
        Boolean blnIsDuplicate = true;
        string strTat_ID = "";
        if (hdnField.Value.ToString() != "")
        {
            
            strTat_ID = hdnField.Value.ToString();
        }
       
        objStandardHour.ActivityId = ddlActivity.SelectedValue.ToString();
        objStandardHour.Client = ddlClient.SelectedValue.ToString();      
        objStandardHour.Product = ddlProduct.SelectedValue.ToString();        
        objStandardHour.Hathrs1=txtHrs1.Text.ToString().Replace(":", ".");      
        objStandardHour.Hathrs2 = txtHrs2.Text.ToString().Replace(":", ".");
        objStandardHour.Hathrs3 = txtHrs3.Text.ToString().Replace(":", ".");
        try
        {
            if (strTat_ID == "")
            {
                blnIsDuplicate = objStandardHour.getDuplicateValue("");
                if (blnIsDuplicate != true)
                {
                    objStandardHour.InsertTatHours();
                    lblMessage.Text = "Records Save Successfully!!";
                   
                }
                else
                {
                    lblMessage.Text = "Tat Hours Already exist!!";
                 
                }
            }
            else
            {
                blnIsDuplicate = objStandardHour.getDuplicateValue(strTat_ID);
                if (blnIsDuplicate != true)
                {
                    objStandardHour.StandardTatHour = strTat_ID;
                    objStandardHour.UpdateTatHour(strTat_ID);
                    lblMessage.Text = " Records Updated Successfully!!";
                   
                }
                else
                {
                    lblMessage.Text = "Tat Hours Already exist!!";
                }
            }

           
        }
        catch (Exception ex)
        {
       
            throw new Exception("Error while Submiting " + ex.Message);
        }
        Message = lblMessage.Text;
        Response.Redirect("StandardTATHour_View.aspx?Message=" + Message + " ");
    }   
    protected void ddlActivity_SelectedIndexChanged(object sender, EventArgs e)
    {
        string strActivityID = ddlActivity.SelectedValue.ToString();       
        funFillProduct(strActivityID, "");
        ddlClient.Items.Clear();      
    
    }
    protected void ddlProduct_SelectedIndexChanged(object sender, EventArgs e)
    {
        string strProductID = ddlProduct.SelectedValue.ToString();
        string strActivityID = ddlActivity.SelectedValue.ToString();
        funFillClients(strProductID, "");

    }    
    public struct GridPosition
    {
        public const int STANDARD_TAT_ID = 0;
        public const int Activity = 1;
        public const int product = 2;
        public const int client = 3;        
        public const int STD_HRS1 = 4;
        public const int STD_HRS2 = 5;
        public const int STD_HRS3 = 6;
        
    }
    private void GetItem()
    {

        hdnField.Value = Request.QueryString["tatId"].ToString();
        objStandardHour.StandardTatHour = hdnField.Value;
        OleDbDataReader oledbDR;       
        oledbDR = objStandardHour.GetRecords(objStandardHour.StandardTatHour);
        if (oledbDR.Read())
        {
           
            funFillProduct(oledbDR["Activity_Id"].ToString(), oledbDR["Product_Id"].ToString());
            funFillClients(oledbDR["Product_Id"].ToString(), oledbDR["Client_Id"].ToString());

            if (!(oledbDR["Client_Id"].ToString().Trim().Length.Equals(0)))
                ddlClient.SelectedValue = oledbDR["Client_Id"].ToString();


            if (!(oledbDR["Activity_Id"].ToString().Trim().Length.Equals(0)))

                ddlActivity.SelectedValue = oledbDR["Activity_Id"].ToString();

            if (!(oledbDR["Product_Id"].ToString().Trim().Length.Equals(0)))
                ddlProduct.SelectedValue = oledbDR["Product_Id"].ToString();





            if (!(oledbDR["STD_HRS1"].ToString().Trim().Length.Equals(0)))
                txtHrs1.Text = oledbDR["STD_HRS1"].ToString().Replace(".", ":");


            if (!(oledbDR["STD_HRS2"].ToString().Trim().Length.Equals(0)))
                txtHrs2.Text = oledbDR["STD_HRS2"].ToString().Replace(".", ":");

            if (!(oledbDR["STD_HRS3"].ToString().Trim().Length.Equals(0)))

                txtHrs3.Text = oledbDR["STD_HRS3"].ToString().Replace(".", ":");





        }
        oledbDR.Close();
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("StandardTATHour_View.aspx");
    }
}
