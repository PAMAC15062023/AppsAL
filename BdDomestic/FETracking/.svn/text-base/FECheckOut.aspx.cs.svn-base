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

public partial class FETracking_FECheckOut : System.Web.UI.Page
{
    CFE_Tracking objCFE = new CFE_Tracking();
    CCommon objcmn = new CCommon();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            txtDate.Text = DateTime.Today.Date.ToString("dd/MM/yyyy");
          
        }        
        txtTime.Text = DateTime.Now.ToString("hh:mm");
        ddlTimeType.SelectedValue = DateTime.Now.ToString("tt");
    }
   protected void btnGet_Click(object sender, EventArgs e)
    {
        try
        {

        
                string strFECode;
                strFECode = txtFE_Code.Text;
                string strFullName;
                DataSet ds = new DataSet();
                ds = objCFE.getFE_Name(strFECode);
                if (ds.Tables[0].Rows.Count != 0)
                {
                    strFullName = ds.Tables[0].Rows[0][0].ToString();
                    txtFE_Name.Text = strFullName;
                    txtbarcode.Text = "";
                    txtbarcode.Focus();
                    lblMsg.Visible = false;
                    lblReassign.Visible = false;
                    pnlReassign.Visible = false;
                    txtbarcode.Text = "";

                    
                    FillGridOfIssuedCases();
                }
                else
                {
                    lblMsg.Text = "FE Code does not exist.";
                    lblMsg.Visible = true;
                    

                    lblReassign.Visible = false;
                    pnlReassign.Visible = false;
                }
               

        }
        catch (Exception ex)
        {
            lblMsg.Visible = true;
            lblMsg.Text = "Error : " + ex.Message;
        }
        
    }
    protected void FillGridOfIssuedCases()
    {
        //DateTime strdt = Convert.ToDateTime( txtDate.Text.ToString("mm/dd/yyyy"));
        DateTime strdt = objcmn.date_mm_dd_yy(txtDate.Text);
        DateTime strdt1 = strdt.AddDays(1);
      //  DateTime strDt1 = strdt + 1;
        SqlDataSourceCheckOut.SelectCommand = "select ft.Case_ID as[Case Id] ,vtm.verification_type_code as [Verification Type Code] ,pm.PRODUCT_NAME as [Product Name],cm.CLIENT_NAME as [Client Name] From Fe_Tracking ft inner join VERIFICATION_TYPE_MASTER vtm on ft.Verification_type_id=vtm.verification_type_id inner join CLIENT_MASTER cm on cm.Client_ID=ft.Client_id inner join PRODUCT_MASTER pm on pm.Product_id=ft.Product_id where ft.FE_Code='"+txtFE_Code .Text +"' and ft.CheckOut_Date>='" + strdt.ToString("dd-MMM-yyyy") + "' AND ft.CheckOut_Date<'" + strdt1.ToString("dd-MMM-yyyy") +"' and ft.Status='Issued'";
        gvIssued.DataSourceID = "SqlDataSourceCheckOut";
        gvIssued.DataBind();
        //int count;
        //count = objCFE.GetFEcasesPending(strFECode);
        lbCount.Visible = true;
        lbPending.Visible = true;
        lbCount.Text = gvIssued.Rows.Count.ToString();
    }

    protected void btnOk_Click(object sender, EventArgs e)
    {
        try
        {
            string strbarcode = txtbarcode.Text.Trim ();
            string strCase_id = "";
            string strveri_id = "";
            string strproduct_id = "";
            string strPbarcode;
            string strVbarcode;

            string strfecode = txtFE_Code.Text.Trim ();
            strPbarcode = strbarcode.Substring(0, 2);
            strVbarcode = strbarcode.Substring(strbarcode.Length - 2, 2);
            strCase_id = strbarcode.Substring(2, strbarcode.Length - 4);
            strproduct_id = objCFE.getProductId(strPbarcode);
            strveri_id = objCFE.getVerificationId(strVbarcode);
            string strFeName;
            DataSet ds3 = new DataSet();
            ds3 = objCFE.getFE_Name(strfecode);

            strFeName = ds3.Tables[0].Rows[0][0].ToString();
            //----------------REASSIGN FE------------------- 
            string strChanged = objCFE.ReassignFE(strfecode,strFeName, strCase_id, strveri_id, strproduct_id);
            
            string strTable;
            string strPcode = objCFE.getProductCode(strproduct_id);
            string strTB;
            string strTB1;
            if (strPcode == "IDOC")
            {
                strTable = "CPV_IDOC_FE_CASE_MAPPING";
                strTB = "CPV_IDOC_CASE_DETAILS";
                strTB1 = "CPV_IDOC_VERIFICATION_TYPE";
            }
            else if (strPcode == "CELLULAR")
            {
                strTable = "CPV_CELLULAR_FE_CASE_MAPPING";
                strTB = "CPV_CELLULAR_CASES";
                strTB1 = "CPV_CELLULAR_CASE_VERIFICATIONTYPE";
            }
            else if (strPcode == "RL")
            {
                strTable = "CPV_RL_CASE_FE_MAPPING";
                strTB = "CPV_RL_CASE_DETAILS";
                strTB1 = "CPV_RL_CASE_VERIFICATIONTYPE";
            }
            else if (strPcode == "CC")
            {
                strTable = "CPV_CC_FE_CASE_MAPPING";
                strTB = "CPV_CC_CASE_DETAILS";
                strTB1 = "CPV_CC_CASE_VERIFICATIONTYPE";
            }
            else
            {
                strTable = "CPV_" + strPcode + "_FE_MAPPING";
                strTB = "CPV_" + strPcode + "_CASE_DETAILS";
                if (strPcode == "EBC")
                {
                    strTB1 = "CPV_" + strPcode + "_VAERIFICATION_TYPE";
                }
                else
                {
                    strTB1 = "CPV_" + strPcode + "_VERIFICATION_TYPE";
                }

            }
          
            string strfe_id;
            DataSet ds = new DataSet();
            ds = objCFE.getFE_Name(strfecode);

            strfe_id = ds.Tables[0].Rows[0][1].ToString();
            //REASSIGN THE FE AND UPDATE IN FE MAPPING TABLE OF THAT PRODUCT

            if (strChanged == "Changed")
            {
                objCFE.UpdateFE_MappingReAssignFE(strTable, strfe_id, strCase_id, strveri_id);

                lblMsg.Visible = true;
                lblMsg.Text = "Re-Assigned Successfully.";
                txtbarcode.Text = "";
                txtbarcode.Focus ();
                lblReassign.Visible = false;
                pnlReassign.Visible = false;
                FillGridOfIssuedCases();
            }
            else
            {
                txtbarcode.Text = "";
                txtbarcode.Focus();
                lblMsg.Visible = true;
                lblMsg.Text = " This Case is already closed.";
                lblReassign.Visible = false;
                pnlReassign.Visible = false;
            }

            
        }
        catch (Exception ex)
        {
            lblMsg.Visible = true;
            lblMsg.Text = " Error : " + ex.Message; ;
        }


    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        lblMsg.Visible = true;
        lblMsg.Text = "Not Re-Assigned  !";
        lblReassign.Visible = false;
        pnlReassign.Visible = false;
        txtbarcode.Text = "";
        txtbarcode.Focus();
    }
    protected void txtbarcode_TextChanged(object sender, EventArgs e)
    {
        try
        {

            if (txtFE_Name.Text != "")
            {
                string sDate = txtDate.Text.Trim();
                DateTime date = objcmn.date_mm_dd_yy(sDate + ' ' + txtTime.Text + ' ' + ddlTimeType.SelectedItem.Text);
                string strbarcode = txtbarcode.Text.Trim();
                string strCase_id = "";
                string strveri_id = "";
                string strproduct_id = "";
                string strPbarcode;
                string strVbarcode;
                strPbarcode = strbarcode.Substring(0, 2);
                strVbarcode = strbarcode.Substring(strbarcode.Length - 2, 2);
                strCase_id = strbarcode.Substring(2, strbarcode.Length - 4);
                strproduct_id = objCFE.getProductId(strPbarcode);
                strveri_id = objCFE.getVerificationId(strVbarcode);
                objCFE.strFE_Code1 = txtFE_Code.Text.Trim();
                DataSet dsf = new DataSet();
                dsf = objCFE.getFE_Name(txtFE_Code.Text.Trim());
                string strFullName = dsf.Tables[0].Rows[0][0].ToString();
                txtFE_Name.Text = strFullName;

                objCFE.strFE_Name1 = strFullName;

                objCFE.strCase_ID1 = strCase_id;
                objCFE.strVerification_type_Code1 = strveri_id;
                objCFE.strProduct_Code1 = strproduct_id;

                string strTable;
                string strPcode = objCFE.getProductCode(strproduct_id);
                string strTB;
                string strTB1;
                if (strPcode == "IDOC")
                {
                    strTable = "CPV_IDOC_FE_CASE_MAPPING";
                    strTB = "CPV_IDOC_CASE_DETAILS";
                    strTB1 = "CPV_IDOC_VERIFICATION_TYPE";
                }
                else if (strPcode == "CELLULAR")
                {
                    strTable = "CPV_CELLULAR_FE_CASE_MAPPING";
                    strTB = "CPV_CELLULAR_CASES";
                    strTB1 = "CPV_CELLULAR_CASE_VERIFICATIONTYPE";
                }
                else if (strPcode == "RL")
                {
                    strTable = "CPV_RL_CASE_FE_MAPPING";
                    strTB = "CPV_RL_CASE_DETAILS";
                    strTB1 = "CPV_RL_CASE_VERIFICATIONTYPE";
                }
                else if (strPcode == "CC")
                {
                    strTable = "CPV_CC_FE_CASE_MAPPING";
                    strTB = "CPV_CC_CASE_DETAILS";
                    strTB1 = "CPV_CC_CASE_VERIFICATIONTYPE";
                }
                else
                {
                    strTable = "CPV_" + strPcode + "_FE_MAPPING";
                    strTB = "CPV_" + strPcode + "_CASE_DETAILS";
                    if (strPcode == "EBC")
                    {
                        strTB1 = "CPV_" + strPcode + "_VAERIFICATION_TYPE";
                    }
                    else
                    {
                        strTB1 = "CPV_" + strPcode + "_VERIFICATION_TYPE";
                    }

                }

                string strFECode;
                strFECode = txtFE_Code.Text.Trim();
                string strfe_id;
                DataSet ds = new DataSet();
                ds = objCFE.getFE_Name(strFECode);

                strfe_id = ds.Tables[0].Rows[0][1].ToString();
                string centerid = Session["CentreId"].ToString();
                string CID = objCFE.getClientId(strTB, strTB1, strCase_id, strveri_id, centerid);
               
                objCFE.strClient_Code1 = CID;
                objCFE.dtCheckOut1 = date;
                objCFE.dtCheckIn1 = date;
                objCFE.strStatus1 = "Issued";
                objCFE.strCaseStatus1 = ddlCaseStatus.SelectedItem.Text;

                //INSERT / CHECK OUT NEW CASE TO FE 
                string stravbl = objCFE.InsertTrack();


                if (stravbl == "Done")
                {
                    objCFE.UpdateFE_Mapping(strTable, strfe_id, date, strCase_id, strveri_id);
                    lblMsg.Visible = true;
                    lblMsg.Text = "Checked Out Successfully.";
                    lblReassign.Visible = false;
                    pnlReassign.Visible = false;
                    txtbarcode.Text = "";

                    txtbarcode.Focus();
                    FillGridOfIssuedCases();
                }
                else
                {
                    string strFeCode;
                    DataSet ds1 = new DataSet();
                    ds1 = objCFE.GetFERepeat1(strCase_id, strveri_id, strproduct_id);
                    strFeCode = ds1.Tables[0].Rows[0][0].ToString();
                    string strFeName;
                    DataSet ds3 = new DataSet();
                    ds3 = objCFE.getFE_Name(strFeCode);

                    strFeName = ds3.Tables[0].Rows[0][0].ToString();
                    string st;
                    DataSet ds2 = new DataSet();
                    ds2 = objCFE.GetPreStatus(strFeCode, strCase_id, strveri_id, strproduct_id);
                    st = ds2.Tables[0].Rows[0][0].ToString();

                    //IF CASE IS NOT  CLOSED 
                    if (st != "Closed")
                    {
                        lblMsg.Visible = false;
                        lblReassign.Text = "This case has been already assigned to  " + strFeName + " <br/> So Press Ok to Reassign it to "+txtFE_Name.Text +" otherwise Press Cancel";
                        lblReassign.Visible = true;
                        pnlReassign.Visible = true;

                    }
                    else
                    {
                        //IF CASE IS ALREADY CLOSED 
                       
                        lblMsg.Visible = true;
                        lblMsg.Text = "This case is already closed.";
                        lblReassign.Visible = false;
                        pnlReassign.Visible = false;
                        
                    }                                   

                }                              
            }
            else
            {
                lblMsg.Visible = true;
                lblMsg.Text = "please enter FE Code and Get Name  of that FE ";
                lblReassign.Visible = false;
                pnlReassign.Visible = false;
            }



        }
        catch (Exception ex)
        {
            lblMsg.Visible = true;
            lblMsg.Text = "Error : " + ex.Message;
            lblReassign.Visible = false;
            pnlReassign.Visible = false;
        }
    }
}
