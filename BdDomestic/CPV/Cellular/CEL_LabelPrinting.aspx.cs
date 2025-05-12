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

public partial class CEL_LabelPrinting : System.Web.UI.Page
{
    CCreditCardGenerateLabel generateclass = new CCreditCardGenerateLabel();
    DataSet ds = new DataSet();
    CCreditCardGenerateLabel CardGenerateLabel = new CCreditCardGenerateLabel();
    string Message = "";
    CCommon objCmn = new CCommon();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["FromDt"] != null)
        {
            txtfrom.Text = Convert.ToDateTime(Request.QueryString["FromDt"]).ToString("dd/MM/yyyy");
        }
        if (Request.QueryString["ToDt"] != null)
        {
            txtto.Text = Convert.ToDateTime(Request.QueryString["ToDt"]).ToString("dd/MM/yyyy");
        }
        //if (Session["isView"].ToString() != "1")
        //{
        //    Response.Redirect("NoAccess.aspx");
        //}
        //else
        //{
       
            if (Request.QueryString["Message"] != null)
            {
                Message = Request.QueryString["Message"];
                lblMsg.Text = Message;
            }
            else
            {
                lblMsg.Text = "";
            }


            if (Session.Count == 0)
            {
                Response.Redirect("Default.aspx");
            }
            if (!IsPostBack)
            {
                //string activityid = Session["ActivityId"].ToString();
                //ds = CardGenerateLabel.GetVerificationType(activityid);
                //ddlverify.DataTextField = "VERIFICATION_TYPE_CODE";
                //ddlverify.DataValueField = "VERIFICATION_TYPE_ID";
                //ddlverify.DataSource = ds;
                //ddlverify.SelectedItem.Text = "RV";
                //ddlverify.DataBind();
                
            }
            if (Request.QueryString["Msg"] !=null)
            {
                lblMsg.Text = "You have already generate the lables for these  case type cases";
            }
        //}
      
    }
    protected void ddlverify_DataBound(object sender, EventArgs e)
    {
        ddlverify.Items.Insert(0, new ListItem("--Select verification type--", "0"));
    }
    protected void btnsearch_Click(object sender, EventArgs e)
    {
        try
        {
        Button1.Enabled = true;
        bool CompareDate = CardGenerateLabel.FunctioncompareDate(txtfrom.Text, txtto.Text);
        if (CompareDate == true)
        {
            string from = "";
            string to = "";
            GV.DataSource = "";

            string CentreId = Session["CentreId"].ToString();
            string strClient_ID = Session["ClientId"].ToString();
            string strProduct_ID = Session["ProductId"].ToString();
            generateclass.Fromdate = objCmn.strDate(txtfrom.Text.Trim());

            string Tdate = txtto.Text.Trim();
            generateclass.Todate = Convert.ToDateTime(objCmn.strDate(Tdate)).AddDays(1.0).ToString("dd-MMM-yyyy");


            //generateclass.Todate = txtto.Text;           
            ds = generateclass.getGridValue_Cellular(CentreId, strClient_ID);
            if (ds.Tables[0].Rows.Count > 0)
            {
                GV.DataSource = ds;
                GV.DataBind();
            }
            else
            {
                GV.DataSource = "";
                GV.DataBind();
                 lblMsg.Text= "Record not found.";
            }

        }
        else
        {
            lblMsg.Visible = true;
            lblMsg.Text = "From date should be less than To Date.";
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
    protected void Button1_Click(object sender, EventArgs e)
    {
        try
        {
        bool CompareDate = CardGenerateLabel.FunctioncompareDate(txtfrom.Text, txtto.Text);
        if (CompareDate == true)
        {
            Session["VerificationId"] = ddlverify.SelectedValue;
            Session["Verification_Type"] = ddlverify.SelectedItem.Text;
            Session["fromdate"] = objCmn.strDate(txtfrom.Text.Trim());
            Session["todate"] = objCmn.strDate(txtto.Text.Trim());
            Response.Redirect("CEL_Generate_Label.aspx");
        }
        else
        {
            lblMsg.Visible = true;
            lblMsg.Text = "From date should be less than To Date.";
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
}
