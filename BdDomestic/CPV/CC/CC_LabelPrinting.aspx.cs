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

public partial class CPV_CC_CC_LabelPrinting : System.Web.UI.Page
{
    CCreditCardGenerateLabel generateclass = new CCreditCardGenerateLabel();
    DataSet ds = new DataSet();
    CCreditCardGenerateLabel CardGenerateLabel = new CCreditCardGenerateLabel();
    CCommon objCmn = new CCommon();
    string Message = "";
  
    protected void Page_Load(object sender, EventArgs e)
    {
        txtfrom.Focus();
        if (Request.QueryString["FromDt"] != null)
        {
            txtfrom.Text = Convert.ToDateTime(Request.QueryString["FromDt"]).ToString("dd/MM/yyyy");
        }
        if (Request.QueryString["ToDt"] != null)
        {
            txtto.Text = Convert.ToDateTime(Request.QueryString["ToDt"]).ToString("dd/MM/yyyy");
        }
        //if (Session["fromdate"].ToString() != "" || Session["fromdate"].ToString() != null )
        //{
        //    txtfrom.Text = Session["fromdate"].ToString();

        //}
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
                    
                    string activityid = Session["ActivityId"].ToString();
                    ds = CardGenerateLabel.GetVerificationType_CC(activityid);
                    ddlverify.DataTextField = "VERIFICATION_TYPE_CODE";
                    ddlverify.DataValueField = "VERIFICATION_TYPE_ID";
                    ddlverify.DataSource = ds;
                    ddlverify.DataBind();
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
        if (rdoFromToDate.Checked == true)
        {
            bool CompareDate = CardGenerateLabel.FunctioncompareDate(txtfrom.Text, txtto.Text);
            if (CompareDate == true)
            {
                
                //string FROM_DATE = "";
                //string TO_DATE = "";
                GV.DataSource = "";

                ViewState["FromDate"] = txtfrom.Text;
                ViewState["ToDate"] = txtto.Text;

                string CentreId = Session["CentreId"].ToString();
                string strClient_ID = Session["ClientId"].ToString();
                string strProduct_ID = Session["ProductId"].ToString();
                string Tdate = txtto.Text;
                
                generateclass.Fromdate = objCmn.strDate(txtfrom.Text);                
                generateclass.Todate = Convert.ToDateTime(objCmn.strDate(Tdate)).AddDays(1.0).ToString("dd-MMM-yyyy");

                //bY ASHISH...
                //TO_DATE = Convert.ToDateTime(Tdate).AddDays(1.0).ToString("dd-MMM-yyyy");
                //generateclass.Todate = txtto.Text;           

                ds = generateclass.getGridValue_CC(CentreId, strClient_ID);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    GV.DataSource = ds;
                    GV.DataBind();
                }
                else
                {
                    GV.DataSource = "";
                    GV.DataBind();
                    lblMsg.Text = "Record not found.";
                }

            }
            else
            {
                lblMsg.Visible = true;
                lblMsg.Text = "From date should be less than To Date.";
            }
        }
        else if (rdoDateTime.Checked == true)
        {
           
            //string FROM_DATE = "";
            //string TO_DATE = "";
            GV.DataSource = "";

            ViewState["FromDate"] = objCmn.strDate(txtDate.Text.Trim()) + ' ' + txtTime.Text.Trim() + ' ' + ddlTimeType.SelectedItem.Text.Trim();
            ViewState["ToDate"] = Convert.ToDateTime(objCmn.strDate(txtDate.Text.Trim()) + ' ' + txtTime.Text.Trim() + ' ' + ddlTimeType.SelectedItem.Text.Trim()).AddMinutes(1.0).ToString("dd-MMM-yyyy hh:mm tt");

            string CentreId = Session["CentreId"].ToString();
            string strClient_ID = Session["ClientId"].ToString();
            string strProduct_ID = Session["ProductId"].ToString();
            string Tdate = txtto.Text;
           
            generateclass.Fromdate = objCmn.strDate(txtDate.Text.Trim()) + ' ' + txtTime.Text.Trim() + ' ' + ddlTimeType.SelectedItem.Text.Trim();
            generateclass.Todate = Convert.ToDateTime(objCmn.strDate(txtDate.Text.Trim()) + ' ' + txtTime.Text.Trim() + ' ' + ddlTimeType.SelectedItem.Text.Trim()).AddMinutes(1.0).ToString("dd-MMM-yyyy hh:mm tt");
            
            //bY ASHISH...
            //TO_DATE = Convert.ToDateTime(Tdate).AddDays(1.0).ToString("dd-MMM-yyyy");


            //generateclass.Todate = txtto.Text;           
            ds = generateclass.getGridValue_CC(CentreId, strClient_ID);
            if (ds.Tables[0].Rows.Count > 0)
            {
                GV.DataSource = ds;
                GV.DataBind();
            }

            else
            {
                GV.DataSource = "";
                GV.DataBind();
                lblMsg.Text = "Record not found.";
            }
            
        }

         }
        catch (Exception ex)
        {
            lblMsg.Text = "Error : " + ex.Message;
            lblMsg.Visible = true;
        }
        //try catch is added by supriya on 16th Nov2007 

       
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        try
        {
            if (rdoFromToDate.Checked == true)
            {
                bool CompareDate = CardGenerateLabel.FunctioncompareDate(txtfrom.Text, txtto.Text);
                if (CompareDate == true)
                {
                    Session["VerificationId"] = ddlverify.SelectedValue;
                    Session["Verification_Type"] = ddlverify.SelectedItem.Text;
                    Session["fromdate"] = objCmn.strDate(txtfrom.Text);
                    Session["todate"] = objCmn.strDate(txtto.Text);
                    Response.Redirect("CC_Generate_Label_1.aspx?IsLotWise=N");
                }
                else
                {
                    lblMsg.Visible = true;
                    lblMsg.Text = "From date should be less than To Date.";
                }
            }
            else if (rdoDateTime.Checked == true)
            {
                Session["VerificationId"] = ddlverify.SelectedValue;
                Session["Verification_Type"] = ddlverify.SelectedItem.Text;
                Session["fromdate"] = objCmn.strDate(txtDate.Text.Trim()) + ' ' + txtTime.Text.Trim() + ' ' + ddlTimeType.SelectedItem.Text.Trim();
                Session["todate"] = Convert.ToDateTime(objCmn.strDate(txtDate.Text.Trim()) + ' ' + txtTime.Text.Trim() + ' ' + ddlTimeType.SelectedItem.Text.Trim()).AddMinutes(1.0).ToString("dd-MMM-yyyy hh:mm tt");
                Response.Redirect("CC_Generate_Label_1.aspx?IsLotWise=Y");
            }
        }
        catch (Exception ex)
        {
            lblMsg.Visible = true;
            lblMsg.Text = "Error :" + ex.Message;
        }
        //try catch is added by supriya on 16th Nov2007 
    }
    
    protected void GV_Sorting(object sender, GridViewSortEventArgs e)
    {

    }
}
