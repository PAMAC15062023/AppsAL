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

public partial class FETracking_FECheckIn : System.Web.UI.Page
{
    CFE_Tracking objCFE = new CFE_Tracking();
    CCommon objcmn = new CCommon();
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnCheck_Click(object sender, EventArgs e)
    {
        try
        {

            string strFECode;
            strFECode = txtFECode.Text; 
            string strbarcode = txtbarcode.Text.Trim();
            
            string strCase_id="";
            string strveri_id="";
            string strproduct_id="";
           
            string strPbarcode;
            string strVbarcode;
            if (strbarcode.Length >= 5)
            {
                strPbarcode = strbarcode.Substring(0, 2);
                strVbarcode = strbarcode.Substring(strbarcode.Length - 2, 2);
                strCase_id = strbarcode.Substring(2, strbarcode.Length - 4);
                strproduct_id = objCFE.getProductId(strPbarcode);
                strveri_id = objCFE.getVerificationId(strVbarcode);
                DataSet ds2 = new DataSet();

                strFECode = txtFECode.Text.Trim();
                ds2 = objCFE.GetFERepeat(strFECode, strCase_id, strveri_id, strproduct_id);

                if (ds2.Tables[0].Rows.Count != 0)
                {
                   //-------------------------IF FE WITH THIS CASE IS AVAILABLE---------------------------------
                    string sdtCheckin;
                    sdtCheckin = System.DateTime.Now.ToString();

                    DateTime date = System.DateTime.Now;

                   
                    string preCheck;

                    preCheck = objCFE.UpdateStatus(strFECode, strCase_id, strveri_id, strproduct_id, date, ddlCaseStatus.SelectedItem.Text);
                    if (preCheck == "changed")
                    {
                        lblMsg.Visible = true;
                        lblMsg.Text = "Successfully Closed.";
                        txtbarcode.Text = "";
                        txtbarcode.Focus();
                    }
                    else
                    {
                        lblMsg.Visible = true;
                        lblMsg.Text = "Already Closed.";
                        txtbarcode.Text = "";
                        txtbarcode.Focus();
                    }


                
                    int count;
                    count = objCFE.GetFEcasesPending(strFECode);
                    lbCount.Visible = true;
                    lbPending.Visible = true;
                    lbCount.Text = count.ToString();
                  //---------------------------------------------------------------------------
                }
                else
                {

                    //-----------------------IF FE WITH THIS CASE IS NOT AVAILABLE------------------
                    DataSet dss = new DataSet();
                    dss = objCFE.GetFERepeat1(strCase_id, strveri_id, strproduct_id);

                          //----------------IF CASE IS AVAILABLE TO ANOTHER FE-----------------------
                    if (dss.Tables[0].Rows.Count != 0)
                    {
                        string fecode = dss.Tables[0].Rows[0][0].ToString();
                        string strFeName;
                        DataSet dss3 = new DataSet();
                        dss3 = objCFE.getFE_Name(fecode);
                        strFeName = dss3.Tables[0].Rows[0][0].ToString();
                        DataSet dss1 = new DataSet();
                        dss1 = objCFE.GetPreStatus(fecode, strCase_id, strveri_id, strproduct_id);

                        //-----------IF THIS CASE IS ALREADY CLOSED----------
                        if (dss1.Tables[0].Rows[0][0].ToString() == "Closed")
                        {
                            lblMsg.Visible = true;
                            lblMsg.Text = "Already Closed !";
                            txtbarcode.Text = "";
                            txtbarcode.Focus();
                        }
                            //-----------------------------------------
                        else
                        {
                            //---------------IF CASE IS NOT CLOSED ----------------
                            lblAssign.Text = "This case has been already assigned to " + strFeName + "<BR/> , Press OK to Reassign AND CheckIn this case  to "+txtFE_Name.Text +" OR press Cancle";
                            lblAssign.Visible = true;
                            pnlAssign.Visible = true;
                            ViewState["ok"] = "update";
                            //------------------------------------------------------
                        }

                    }
                        //------------------------------------------------------------------------------
                    else
                    {
                        //-----------IF CASE IS NOT AVAILABLE TO ANY FE --------------------
                        lblAssign.Text = "This case is not assigned to any FE  <BR/> , Press OK to Assign AND CheckIn this case  to " + txtFE_Name.Text + "  OR press Cancle";
                        lblAssign.Visible = true;
                        pnlAssign.Visible = true;
                        ViewState["ok"] = "Insert";
                        //-------------------------------------------------------
                    }                 
                 }
                //-------------------------------------------------------------------------
              }

        }
        catch (Exception ex)
        {
            lblMsg.Visible = true;
            lblMsg.Text = "Error : " + ex.Message;
        }
        

    }
    protected void txtFECode_TextChanged(object sender, EventArgs e)
    {
        txtbarcode.Focus();

    }
    protected void btnGet_Click(object sender, EventArgs e)
    {
        try
        {
           
                string strFECode;
                strFECode = txtFECode.Text;
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

                    int count;
                    count = objCFE.GetFEcasesPending(strFECode);
                    lbCount.Visible = true;
                    lbPending.Visible = true;
                    lbCount.Text = count.ToString();
                    lblAssign.Visible = false;
                    pnlAssign.Visible = false;
                    FillGridOfIssuedCases();
                    
                }
                else
                {
                    lblMsg.Text = "FE Code does not exist  !";
                    lblMsg.Visible = true;
                    lbCount.Visible = false ;
                    lbPending.Visible =false ;
                   
                    lblAssign.Visible = false;
                    pnlAssign.Visible = false;
                    txtFE_Name.Text = "";

                }
              
            
        }
        catch (Exception ex)
        {
            lblMsg.Visible = true;
            lblMsg.Text = "Error :" + ex.Message;
        }
    }
   
    protected void btnOk_Click(object sender, EventArgs e)
    {
        try
        {
            string strbarcode = txtbarcode.Text;
            string strCase_id = "";
            string strveri_id = "";
            string strproduct_id = "";
            string strPbarcode;
            string strVbarcode;

            string strfecode = txtFECode.Text;
            strPbarcode = strbarcode.Substring(0, 2);
            strVbarcode = strbarcode.Substring(strbarcode.Length - 2, 2);
            strCase_id = strbarcode.Substring(2, strbarcode.Length - 4);
            strproduct_id = objCFE.getProductId(strPbarcode);
            strveri_id = objCFE.getVerificationId(strVbarcode);

            string strfe_id;
            DataSet ds = new DataSet();
            ds = objCFE.getFE_Name(strfecode);
            String strFeName = ds.Tables[0].Rows[0][0].ToString();
            strfe_id = ds.Tables[0].Rows[0][1].ToString();
            string sdtCheckin;
            sdtCheckin = System.DateTime.Now.ToString();
            DateTime date = System.DateTime.Now; //objcmn.date_mm_dd_yy(sdtCheckin);
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
            //---------------UPDATE IF CASE IS AVAILABLE WITH ANOTHER FE AND NOT CLOSED ALSO, CHECK IN ------------------
            if (ViewState["ok"].ToString() == "update")
            {
                string strChanged = objCFE.ReassignFE(strfecode, strFeName, strCase_id, strveri_id, strproduct_id);
                if (strChanged == "Changed")
                {
                    objCFE.UpdateFE_MappingReAssignFE(strTable, strfe_id, strCase_id, strveri_id);
                    objCFE.UpdateStatus(strfecode, strCase_id, strveri_id, strproduct_id, date, ddlCaseStatus.SelectedItem.Text);
                    lblMsg.Visible = true;
                    lblMsg.Text = "Re-Assigned  and checkedIn  Successfully !";
                    lblAssign.Visible = false;
                    
                }

                txtbarcode.Text = "";
                txtbarcode.Focus();
                pnlAssign.Visible = false;
            }
            //--------------------------------------------------------------------
            else
            {

                //-------------------INSERT IF CASE IS NOT ASSIGNED TO ANY FE ALSO CHECK IN
                objCFE.strFE_Code1 = strfecode;
                objCFE.strFE_Name1 = strFeName;
                objCFE.strCase_ID1 = strCase_id;
                objCFE.strVerification_type_Code1 = strveri_id;
                objCFE.strProduct_Code1 = strproduct_id;
                string centerid = Session["CentreId"].ToString();
                string CID = objCFE.getClientId(strTB, strTB1, strCase_id, strveri_id, centerid);
                
                objCFE.strClient_Code1 = CID;
               
                objCFE.dtCheckIn1 = date;
                objCFE.dtCheckOut1 = date;
                objCFE.strCaseStatus1 = ddlCaseStatus.SelectedItem.Text;
                objCFE.strStatus1 = "Closed";
                string strChanged = objCFE.InsertTrack();
                if (strChanged == "Done")
                {
                    objCFE.UpdateFE_Mapping(strTable, strfe_id, date, strCase_id, strveri_id);
                    lblMsg.Visible = true;
                    lblMsg.Text = " CheckedOut and checkedIn Successfully  !";
                    lblAssign.Visible = false;
                }
                txtbarcode.Text = "";
                txtbarcode.Focus();
                pnlAssign.Visible = false;
                //---------------------------------------------------------------
            }
        }
        catch (Exception ex)
        {
            lblMsg.Visible = true;
            lblMsg.Text = "Error: "+ex.Message;
        }


    }

    protected void FillGridOfIssuedCases()
    {
        //DateTime strdt = Convert.ToDateTime( txtDate.Text.ToString("mm/dd/yyyy"));
        DateTime strdt = DateTime.Now.Date;
      //  DateTime strdt1 = strdt.AddDays(1);
        //  DateTime strDt1 = strdt + 1;
        SqlDataSourceCheckOut.SelectCommand = "select ft.Case_ID as [Case Id],vtm.verification_type_code as[Verification Type Code],pm.PRODUCT_NAME as[Product Name],cm.CLIENT_NAME as[Client Name] From Fe_Tracking ft inner join VERIFICATION_TYPE_MASTER vtm on ft.Verification_type_id=vtm.verification_type_id inner join CLIENT_MASTER cm on cm.Client_ID=ft.Client_id inner join PRODUCT_MASTER pm on pm.Product_id=ft.Product_id where ft.FE_Code='" + txtFECode.Text + "'  and ft.Status='Issued'";//and ft.CheckOut_Date<'" + strdt.ToString("dd-MMM-yyyy") + "';
        gvIssued.DataSourceID = "SqlDataSourceCheckOut";
        gvIssued.DataBind();
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        txtbarcode.Text = "";
        txtbarcode.Focus();
        lblAssign.Visible = false;
        pnlAssign.Visible = false;
        lblMsg.Visible = true;

        lblMsg.Text = "Not assigned/checkedIn !";
    }

    protected void txtbarcode_TextChanged(object sender, EventArgs e)
    {
        try
        {

            if (txtFE_Name.Text != "")
            {
                string strFECode;
                strFECode = txtFECode.Text;
                int flag = 0;
                string strbarcode = txtbarcode.Text;

                string strCase_id = "";
                string strveri_id = "";
                string strproduct_id = "";

                string strPbarcode;
                string strVbarcode;
                if (strbarcode.Length >= 5)
                {
                    strPbarcode = strbarcode.Substring(0, 2);
                    strVbarcode = strbarcode.Substring(strbarcode.Length - 2, 2);
                    strCase_id = strbarcode.Substring(2, strbarcode.Length - 4);
                    strproduct_id = objCFE.getProductId(strPbarcode);
                    strveri_id = objCFE.getVerificationId(strVbarcode);
                    DataSet ds2 = new DataSet();

                    strFECode = txtFECode.Text;
                    ds2 = objCFE.GetFERepeat(strFECode, strCase_id, strveri_id, strproduct_id);

                    if (ds2.Tables[0].Rows.Count != 0)
                    {
                        //-------------------------IF FE WITH THIS CASE IS AVAILABLE---------------------------------
                        string sdtCheckin;
                        sdtCheckin = System.DateTime.Now.ToString();

                        DateTime date = System.DateTime.Now;


                        string preCheck;

                        preCheck = objCFE.UpdateStatus(strFECode, strCase_id, strveri_id, strproduct_id, date, ddlCaseStatus.SelectedItem.Text);
                        if (preCheck == "changed")
                        {
                            lblMsg.Visible = true;
                            lblMsg.Text = "Successfully Closed !";
                            txtbarcode.Text = "";
                            txtbarcode.Focus();
                            lblAssign.Visible = false;
                            pnlAssign.Visible = false;
                            FillGridOfIssuedCases();
                        }
                        else
                        {
                            lblMsg.Visible = true;
                            lblMsg.Text = "Already Closed !";
                            txtbarcode.Text = "";
                            txtbarcode.Focus();
                            lblAssign.Visible = false;
                            pnlAssign.Visible = false;
                        }



                        int count;
                        count = objCFE.GetFEcasesPending(strFECode);
                        lbCount.Visible = true;
                        lbPending.Visible = true;
                        lbCount.Text = count.ToString();
                        //---------------------------------------------------------------------------
                    }
                    else
                    {

                        //-----------------------IF FE WITH THIS CASE IS NOT AVAILABLE------------------
                        DataSet dss = new DataSet();
                        dss = objCFE.GetFERepeat1(strCase_id, strveri_id, strproduct_id);

                        //----------------IF CASE IS AVAILABLE TO ANOTHER FE-----------------------
                        if (dss.Tables[0].Rows.Count != 0)
                        {
                            string fecode = dss.Tables[0].Rows[0][0].ToString();
                            string strFeName;
                            DataSet dss3 = new DataSet();
                            dss3 = objCFE.getFE_Name(fecode);
                            strFeName = dss3.Tables[0].Rows[0][0].ToString();
                            DataSet dss1 = new DataSet();
                            dss1 = objCFE.GetPreStatus(fecode, strCase_id, strveri_id, strproduct_id);

                            //-----------IF THIS CASE IS ALREADY CLOSED----------
                            if (dss1.Tables[0].Rows[0][0].ToString() == "Closed")
                            {
                                lblMsg.Visible = true;
                                lblMsg.Text = "Already Closed !";
                                lblAssign.Visible = false;
                                pnlAssign.Visible = false;
                                txtbarcode.Text = "";
                                txtbarcode.Focus();
                            }
                            //-----------------------------------------
                            else
                            {
                                //---------------IF CASE IS NOT CLOSED ----------------
                                lblAssign.Text = "This case has been already assigned to " + strFeName + "<BR/> , Press OK to Reassign AND CheckIn this case  to " + txtFE_Name.Text + " OR press Cancle";
                                lblAssign.Visible = true;
                                lblMsg.Visible = false;
                                pnlAssign.Visible = true;
                                ViewState["ok"] = "update";
                                //------------------------------------------------------
                            }

                        }
                        //------------------------------------------------------------------------------
                        else
                        {
                            //-----------IF CASE IS NOT AVAILABLE TO ANY FE --------------------
                            lblAssign.Text = "This case is not assigned to any FE  <BR/> , Press OK to Assign AND CheckIn this case  to " + txtFE_Name.Text + "  OR press Cancle";
                            lblAssign.Visible = true;
                            pnlAssign.Visible = true;
                            ViewState["ok"] = "Insert";
                            lblMsg.Visible = false;
                            //-------------------------------------------------------
                        }
                    }
                }


               
                //-------------------------------------------------------------------------
            }
            else
            {
                lblMsg.Visible = true;
                lblMsg.Text = "please enter FE Code and Get Name  of that FE ";
                pnlAssign.Visible = false;
                lblAssign.Visible = false;
            }
            //  hdnCheckIn.Value = "Yes";


        }
        catch (Exception ex)
        {
            lblMsg.Visible = true;
            lblMsg.Text = "Error : " + ex.Message;
        }
        

    }
}
