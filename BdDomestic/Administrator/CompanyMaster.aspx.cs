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
using System.Data.SqlClient;
using System.Data.OleDb;

public partial class Administrator_CompanyMaster : System.Web.UI.Page
{
    CCommon con = new CCommon();
  
   
    protected void Page_Load(object sender, EventArgs e)
    {
        CCompanyMaster objCM = new CCompanyMaster();

        try
        {

            String strCompanyID = "";
            lblMsg.Text = "";



            if (Request.QueryString["Company_Id"] != null && Request.QueryString["Company_Id"] != "")
            {
                lblMsg.Text = "Edit";
                txtCoCode.ReadOnly = true;
                valComCode.Enabled = false;

                //if (Session["isEdit"].ToString() != "1")
                //{

                //}
                //else
                //{
            }
                    if (!IsPostBack)
                    {
                   
                    strCompanyID = Request.QueryString["Company_ID"].ToString();
                    objCM.Company_Id = strCompanyID;
                    objCM.getCompany();
                    txtCoName.Text = objCM.CompanyName;
                    txtCorAdd1.Text = objCM.CorAdd1;
                    txtCorAdd2.Text = objCM.CorAdd2;
                    txtCorAdd3.Text = objCM.CorAdd3;
                    txtCorCity.Text = objCM.CorCity;
                    txtCorPin.Text = objCM.Corpin;
                    txtRegAdd1.Text = objCM.RegAdd1;
                    txtRegAdd2.Text = objCM.RegAdd2;
                    txtRegAdd3.Text = objCM.RegAdd3;
                    txtRegCity.Text = objCM.RegCity;
                    txtRegPin.Text = objCM.Regpin;
                    txtCoCode.Text = objCM.CompanyCode;
                    //}
                }
                //else
                //{
                //    lblMsg.Text = "";
                //}
            

        }
        catch (Exception exp)
        {
            lblMsg.Text = "Error";
        }
       
       
       
    }


    protected void btnSave_Click(object sender, EventArgs e)
    {
        CCompanyMaster objCM = new CCompanyMaster();

      

        if (lblMsg.Text == "Edit")
        {
           

            objCM.Company_Id = Request.QueryString["Company_ID"].ToString();
            objCM.CompanyName = txtCoName.Text.Trim();
            objCM.CorAdd1 = txtCorAdd1.Text.Trim();
            objCM.CorAdd2 = txtCorAdd2.Text.Trim();
            objCM.CorAdd3 = txtCorAdd3.Text.Trim();
            objCM.CorCity = txtCorCity.Text.Trim();
            objCM.Corpin = txtCorPin.Text.Trim();
            objCM.RegAdd1 = txtRegAdd1.Text.Trim();
            objCM.RegAdd2 = txtRegAdd2.Text.Trim();
            objCM.RegAdd3 = txtRegAdd3.Text.Trim();
            objCM.RegCity = txtRegCity.Text.Trim();
            objCM.Regpin = txtRegPin.Text.Trim();
           
          
                objCM.UpdateCompany();
               // gvCompanyMaster.DataBind();
                lblMsg.Visible = true;
                lblMsg.Text = "Company Updated Successfully";
                Session["msg"] = lblMsg.Text;

        }
       

            
        else 
        {
            objCM.CompanyCode = txtCoCode.Text.Trim();
            objCM.CompanyName = txtCoName.Text.Trim();
            objCM.CorAdd1 = txtCorAdd1.Text.Trim();
            objCM.CorAdd2 = txtCorAdd2.Text.Trim();
            objCM.CorAdd3 = txtCorAdd3.Text.Trim();
            objCM.CorCity = txtCorCity.Text.Trim();
            objCM.Corpin = txtCorPin.Text.Trim();
            objCM.RegAdd1 = txtRegAdd1.Text.Trim();
            objCM.RegAdd2 = txtRegAdd2.Text.Trim();
            objCM.RegAdd3 = txtRegAdd3.Text.Trim();
            objCM.RegCity = txtRegCity.Text.Trim();
            objCM.Regpin = txtRegPin.Text.Trim();
            OleDbParameter CoCode = new OleDbParameter("@CoCode", OleDbType.VarChar, 10);
            CoCode.Value = txtCoCode.Text.Trim();
            string sql = "select count(*) from company_master where COMPANY_CODE=?";
            Object o = new object();
            o = OleDbHelper.ExecuteScalar(con.ConnectionString, CommandType.Text, sql, CoCode);
            if (Convert.ToInt32(o) == 0)
            {
                objCM.InsertCompanyMaster();
               //gvCompanyMaster.DataBind();
                lblMsg.Visible = true;
                lblMsg.Text = "Company Added Successfully ";
                Session["msg"] = lblMsg.Text;
            }
            else
            {
                lblMsg.Visible = true;
                lblMsg.Text = "Duplicate Company Code Should not be Entered";
                Session["msg"] = lblMsg.Text;
            }
        
        }
        txtCoCode.Text  = "";
        txtCoName.Text  = "";
        txtCorAdd1.Text = "";
        txtCorAdd2.Text = "";
        txtCorAdd3.Text = "";
        txtCorCity.Text = "";
        txtCorPin.Text  = "";
        txtRegAdd1.Text = "";
        txtRegAdd2.Text = "";
        txtRegAdd3.Text = "";
        txtRegCity.Text = "";
        txtRegPin.Text  = "";
        Response.Redirect("CompanyViewMaster.aspx");
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        lblMsg.Text    = "";
        txtCoCode.Text = "";
        txtCoName.Text = "";
        txtCorAdd1.Text = "";
        txtCorAdd2.Text = "";
        txtCorAdd3.Text = "";
        txtCorCity.Text = "";
        txtCorPin.Text  = "";
        txtRegAdd1.Text = "";
        txtRegAdd2.Text = "";
        txtRegAdd3.Text = "";
        txtRegCity.Text = "";
        txtRegPin.Text  = "";
        txtCoCode.Enabled = true;
        Session["msg"] = null;
        Response.Redirect("CompanyViewMaster.aspx");
       

    }
   
}
