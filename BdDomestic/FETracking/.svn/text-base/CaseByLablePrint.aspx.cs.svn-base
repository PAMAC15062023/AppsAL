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
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;

public partial class FETracking_CaseByLablePrint : System.Web.UI.Page
{
    CCommon objconn = new CCommon();
    DataSet ds = new DataSet();
    OleDbDataAdapter da = new OleDbDataAdapter();
    DataTable d_table = new DataTable();
    object o;
    DataSet dsLabelQuery = new DataSet();
    string strVerification_Type_Code = "";
    string strAdditional1 = "";
    string strAdditional2 = "";
    string blnSR_NO = "";
    string blnLabelPrintingDate = "";
    string blnAllVerificationType = "";
    string strTableName = "";
    int nPrevSRNO = 0;
    int nSRNO = 0;
    int nForField = 0;
    string strSQL = "";
    bool msg = true;
    CCreditCardGenerateLabel obcCLPrinting = new CCreditCardGenerateLabel();
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnPrint_Click(object sender, EventArgs e)
    {
        try
        {

            int icount = 0;

           

            obcCLPrinting.Product_ID = ddlProduc.SelectedValue;
            obcCLPrinting.Activity_ID = "1011";
            if (ddlProduc.SelectedValue == "1017")
            {
                obcCLPrinting.Activity_ID = "1012";
            }
            obcCLPrinting.Client_ID = ddlClient.SelectedValue;

            obcCLPrinting.Verification_Type_ID = ddlVeri.SelectedValue;
            obcCLPrinting.Centre_Id = Session["CentreId"].ToString();
           
           
            dsLabelQuery = obcCLPrinting.getTemplate();



            if (dsLabelQuery != null)
            {

                try
                {

                    if (dsLabelQuery.Tables[0].Rows.Count > 0)
                    {
                        if (ddlProduc.SelectedValue == "1011")
                        {
                            CC_LablePrint();
                        }
                        if (ddlProduc.SelectedValue == "1014")
                        {
                            CELL_LablePrint();
                        }
                        if (ddlProduc.SelectedValue == "1016")
                        {
                            EBC_LablePrint();
                        }
                        if (ddlProduc.SelectedValue == "1015")
                        {
                            KYC_LablePrint();
                        }
                        if (ddlProduc.SelectedValue == "1012")
                        {
                            RL_LablePrint();
                        }
                        if (ddlProduc.SelectedValue == "1017")
                        {
                            IDOC_LablePrint();
                        }
                    }
                    else if (dsLabelQuery.Tables[0].Rows.Count == 0)
                    {
                        icount = 1;

                    }
                }
                catch (Exception ex)
                {
                    Response.Write(ex.Message.ToString());
                }
                if (icount != 1)
                {
                    if (ddlProduc.SelectedValue == "1011")
                    {
                        CC_Query();
                    }
                    if (ddlProduc.SelectedValue == "1014")
                    {
                        CELL_Query();
                    }
                    if (ddlProduc.SelectedValue == "1016")
                    {
                        EBC_Query();
                    }
                    if (ddlProduc.SelectedValue == "1015")
                    {
                        KYC_Query();
                    }
                    if (ddlProduc.SelectedValue == "1012")
                    {
                        RL_Query();
                    }
                    if (ddlProduc.SelectedValue == "1017")
                    {
                        IDOC_Query();
                    }

                }
                else
                {
                    msg = false;
                   
                }
            }
            if (Convert.ToInt32(o) == 1)
            {
                using (OleDbConnection con = new OleDbConnection(ConfigurationManager.ConnectionStrings["CMConnectionString"].ConnectionString))
                {
                    DataSet Ods = new DataSet();
                    if (ddlProduc.SelectedValue != "1014")
                    {
                        if (ddlProduc.SelectedValue == "1016" || ddlProduc.SelectedValue == "1015")
                        {
                            ParameterField p2 = new ParameterField();
                            ParameterDiscreteValue d2 = new ParameterDiscreteValue();
                            ParameterField p3 = new ParameterField();
                            ParameterDiscreteValue d3 = new ParameterDiscreteValue();
                            ParameterFields parcol = new ParameterFields();
                            p2.Name = "add1";
                            d2.Value = strAdditional1;
                            p2.CurrentValues.Add(d2);
                            parcol.Add(p2);

                            p3.Name = "add2";
                            d3.Value = strAdditional2;
                            p3.CurrentValues.Add(d3);
                            parcol.Add(p3);

                            Session["ParameterCollection"] = parcol;
                            
                            con.Open();
                            string str = strSQL;
                            OleDbDataAdapter da = new OleDbDataAdapter(str, con);
                            da.Fill(Ods);
                            Ods.Tables[0].TableName = "LblPrinting";
                            Session["dataset"] = Ods;
                        }
                        else
                        {
                            ParameterField p1 = new ParameterField();
                            ParameterDiscreteValue d1 = new ParameterDiscreteValue();
                            ParameterField p2 = new ParameterField();
                            ParameterDiscreteValue d2 = new ParameterDiscreteValue();
                            ParameterField p3 = new ParameterField();
                            ParameterDiscreteValue d3 = new ParameterDiscreteValue();
                            ParameterFields parcol = new ParameterFields();
                            p1.Name = "Verification_Type";
                            d1.Value = ddlVeri.SelectedItem.Text.Trim();
                            p1.CurrentValues.Add(d1);
                            parcol.Add(p1);

                            p2.Name = "add1";
                            d2.Value = strAdditional1;
                            p2.CurrentValues.Add(d2);
                            parcol.Add(p2);

                            p3.Name = "add2";
                            d3.Value = strAdditional2;
                            p3.CurrentValues.Add(d3);
                            parcol.Add(p3);

                            Session["ParameterCollection"] = parcol;
                           
                            con.Open();
                            string str = strSQL;
                            OleDbDataAdapter da = new OleDbDataAdapter(str, con);
                            da.Fill(Ods);
                            Ods.Tables[0].TableName = "LblPrinting";
                            
                            Session["dataset"] = Ods;
                        }
                        if (ddlProduc.SelectedValue == "1011")
                        {
                            Session["Path"] = Server.MapPath("CRTest.rpt");
                        }
                        if (ddlProduc.SelectedValue == "1016")
                        {
                            
                           
                            Session["Path"] = Server.MapPath("CRTest_EBC.rpt");
                        }
                       if (ddlProduc.SelectedValue == "1015")
                        {
                            Session["Path"] = Server.MapPath("CRTest_KYC.rpt");
                        }
                        if (ddlProduc.SelectedValue == "1012")
                        {
                            Ods.Tables[0].TableName = "LblPrinting_RL";
                            Session["Path"] = Server.MapPath("rpt_RL.rpt");
                        }
                        if (ddlProduc.SelectedValue == "1017")
                        {
                            Session["Path"] = Server.MapPath("IDOC_Generate_Label.rpt");
                        }
                        Response.Redirect("../CrystalReportViewer.aspx?bckPgURL=FETracking\\CaseByLablePrint.aspx");
                    }
                    if (ddlProduc.SelectedValue == "1014")
                    {
                        
                        con.Open();
                        string str = strSQL;
                       
                        
                            OleDbDataAdapter da = new OleDbDataAdapter(str, con);
                            da.Fill(Ods);
                            int iCounter = 0;
                            while (iCounter < Ods.Tables[0].Rows.Count)
                            {
                                try
                                {
                                    //DateTime dt;
                                    Ods.Tables[0].Rows[iCounter]["CELL_ACTIVATED_DATE"] = Convert.ToDateTime(Ods.Tables[0].Rows[iCounter]["CELL_ACTIVATED_DATE"].ToString()).ToString("dd/MM/yyyy");

                                }
                                catch (Exception ex)
                                {
                                    continue;
                                }
                                finally
                                {
                                    iCounter++;

                                }
                            }

                            Ods.Tables[0].TableName = "LblPrinting_Cellular";
                            Session["dataset"] = Ods;
                            Session["Path"] = Server.MapPath("rpt_Cellular.rpt");
                            Response.Redirect("../CrystalReportViewer.aspx?bckPgURL=FETracking\\CaseByLablePrint.aspx");
                    }


                }
            }
            else if (msg == false)
            {
                lblmsg.Text = "No template found s";
            }
            else
            {
                lblmsg.Text = " No record found for this case";
            }
           
        }
        catch (Exception ex)
        {
            lblmsg.Text = ex.Message;
        }
        }
    public void CC_LablePrint()
    {
        for (int i = 0; i < dsLabelQuery.Tables[0].Rows.Count; i++)
        {
            strVerification_Type_Code = dsLabelQuery.Tables[0].Rows[i]["VERIFICATION_TYPE_CODE"].ToString();
            strAdditional1 = dsLabelQuery.Tables[0].Rows[i]["ADDITIONAL1"].ToString();
            strAdditional2 = dsLabelQuery.Tables[0].Rows[i]["ADDITIONAL2"].ToString();
            blnSR_NO = dsLabelQuery.Tables[0].Rows[i]["SR_NO"].ToString();
            blnLabelPrintingDate = dsLabelQuery.Tables[0].Rows[i]["LABEL_PRINTING_DATE"].ToString();
            blnAllVerificationType = dsLabelQuery.Tables[0].Rows[i]["ALL_VERIFICATION_TYPE"].ToString();
            strTableName = dsLabelQuery.Tables[0].Rows[i]["TABLE_NAME"].ToString();

            nSRNO = Convert.ToInt32(dsLabelQuery.Tables[0].Rows[i]["LINE_NO"].ToString());


            if (nPrevSRNO == nSRNO)
            {
                if (Convert.ToString(dsLabelQuery.Tables[0].Rows[i]["SELECTED_FIELD"]) == "MOBILE")
                {

                    strSQL = strSQL + "+IsNull(CASE WHEN MOBILE IS NULL OR RTRIM(LTRIM(MOBILE)) = '' THEN NULL ELSE +'(M:) '+ MOBILE END,'')";
                }
                else if (Convert.ToString(dsLabelQuery.Tables[0].Rows[i]["SELECTED_FIELD"]) == "OFF_PHONE")
                {
                    strSQL = strSQL + "+IsNull(CASE WHEN OFF_PHONE IS NULL OR RTRIM(LTRIM(OFF_PHONE)) = '' THEN NULL ELSE +'(OP:) '+ OFF_PHONE END,'')";
                }
                else if (Convert.ToString(dsLabelQuery.Tables[0].Rows[i]["SELECTED_FIELD"]) == "RES_PHONE")
                {
                    strSQL = strSQL + "+IsNull(CASE WHEN RES_PHONE IS NULL OR RTRIM(LTRIM(RES_PHONE)) = '' THEN NULL ELSE +'(RP:) '+ RES_PHONE END,'')";
                }
                //else if (Convert.ToString(dsLabelQuery.Tables[0].Rows[i]["SELECTED_FIELD"]) == "OFF_NAME")
                //{
                //    strSQL = strSQL + "+CASE OFF_NAME WHEN ''THEN ''ELSE '(CO) '+OFF_NAME END";
                //}

                else
                {
                    strSQL = strSQL + "+ ' ' +ISNULL(" + dsLabelQuery.Tables[0].Rows[i]["SELECTED_FIELD"].ToString() + ",'')";
                }
            }
            else if (nPrevSRNO == 0)
            {

                if (Convert.ToString(dsLabelQuery.Tables[0].Rows[i]["SELECTED_FIELD"]) == "MOBILE")
                {

                    strSQL = strSQL + "+IsNull(CASE WHEN MOBILE IS NULL OR RTRIM(LTRIM(MOBILE)) = '' THEN NULL ELSE +'(M:) '+ MOBILE END,'')";
                }
                else if (Convert.ToString(dsLabelQuery.Tables[0].Rows[i]["SELECTED_FIELD"]) == "OFF_PHONE")
                {
                    strSQL = strSQL + "+IsNull(CASE WHEN OFF_PHONE IS NULL OR RTRIM(LTRIM(OFF_PHONE)) = '' THEN NULL ELSE +'(OP:) '+ OFF_PHONE END,'')";
                }
                else if (Convert.ToString(dsLabelQuery.Tables[0].Rows[i]["SELECTED_FIELD"]) == "RES_PHONE")
                {
                    strSQL = strSQL + "+IsNull(CASE WHEN RES_PHONE IS NULL OR RTRIM(LTRIM(RES_PHONE)) = '' THEN NULL ELSE +'(RP:) '+ RES_PHONE END,'')";
                }
                else if (Convert.ToString(dsLabelQuery.Tables[0].Rows[i]["SELECTED_FIELD"]) == "OFF_NAME")
                {
                    strSQL = strSQL + "+ISNULL(CASE OFF_NAME WHEN ''THEN ''ELSE '(CO) '+OFF_NAME END,')";
                }

                else
                {
                    strSQL = strSQL + "+ ' ' +ISNULL(" + dsLabelQuery.Tables[0].Rows[i]["SELECTED_FIELD"].ToString() + ",'')";
                }
            }
            else if (nPrevSRNO != nSRNO)
            {
                bool flage = false;
                if (Convert.ToString(dsLabelQuery.Tables[0].Rows[i]["SELECTED_FIELD"]) == "MOBILE")
                {
                    flage = true;
                    //strSQL = strSQL + "+CASE MOBILE WHEN ''THEN ''ELSE '(M) '+MOBILE END";
                    nForField++;
                    strSQL = strSQL + " AS Field" + nForField + ",IsNull(CASE WHEN MOBILE IS NULL OR RTRIM(LTRIM(MOBILE)) = '' THEN NULL ELSE +'(M:) '+ MOBILE END,'') ";
                }
                if (Convert.ToString(dsLabelQuery.Tables[0].Rows[i]["SELECTED_FIELD"]) == "OFF_PHONE")
                {
                    flage = true;
                    //strSQL = strSQL + "+CASE OFF_PHONE WHEN ''THEN ''ELSE '(0) '+OFF_PHONE END";
                    nForField++;
                    strSQL = strSQL + " AS Field" + nForField + ",IsNull(CASE WHEN OFF_PHONE IS NULL OR RTRIM(LTRIM(OFF_PHONE)) = '' THEN NULL ELSE +'(OP:) '+ OFF_PHONE END,'') ";
                }
                if (Convert.ToString(dsLabelQuery.Tables[0].Rows[i]["SELECTED_FIELD"]) == "RES_PHONE")
                {
                    flage = true;
                    //strSQL = strSQL + "+CASE RES_PHONE WHEN ''THEN ''ELSE '(R) '+RES_PHONE END";
                    nForField++;
                    strSQL = strSQL + " AS Field" + nForField + ",IsNull(CASE WHEN RES_PHONE IS NULL OR RTRIM(LTRIM(RES_PHONE)) = '' THEN NULL ELSE +'(RP:) '+ RES_PHONE END,'')";
                }
                if (Convert.ToString(dsLabelQuery.Tables[0].Rows[i]["SELECTED_FIELD"]) == "OFF_NAME")
                {
                    flage = true;
                    nForField++;
                    //strSQL = strSQL + " AS Field" + nForField + ",+'Co: '+ISNULL(" + dsLabelQuery.Tables[0].Rows[i]["SELECTED_FIELD"].ToString() + ",'')";
                    strSQL = strSQL + " AS Field" + nForField + ",CASE WHEN OFF_NAME IS NULL OR RTRIM(LTRIM(OFF_NAME)) = '' THEN NULL ELSE +'(Co:) '+ OFF_NAME END";
                }

                if (flage == false)
                {
                    nForField++;
                    strSQL = strSQL + " AS Field" + nForField + ",ISNULL(" + dsLabelQuery.Tables[0].Rows[i]["SELECTED_FIELD"].ToString() + ",'')";
                }
                //}
            }

            nPrevSRNO = nSRNO;

        }
        nForField++;
        strSQL = strSQL + " AS Field" + nForField;


        //Final Querry..
        //By Ashish..
        //strSQL = "SELECT " + strSQL + " FROM " + strTableName + " WHERE case_rec_datetime >= '" + obcCLPrinting.Fromdate + "' AND case_rec_datetime < = '" + obcCLPrinting.Todate + "' and Centre_id = " + obcCLPrinting.Centre_Id + " and  Client_id =" + obcCLPrinting.Client_ID + "";
        if (nForField <= 12)
        {
            for (int i = ++nForField; i <= 12; i++)
            {
                strSQL = strSQL + ",'' AS Field" + i;
            }
        }
        if (blnSR_NO == "Y")
        {
            //nForField++;
            strSQL = strSQL + "," + "SR_NO";
        }
        if (blnAllVerificationType == "Y")
        {

            strSQL = strSQL + "," + "VERIFICATION_CODE";
        }
        if (blnLabelPrintingDate == "Y")
        {
            strSQL = strSQL + "," + "Convert(varchar(11),CASE_REC_DATETIME,103) as CASE_REC_DATETIME";
        }
        strSQL = strSQL + "," + " A.CASE_ID";
        //Fianl STR 
    }
    public void CC_Query()
    {
        string strFE = "select count(*) from CPV_CC_FE_CASE_MAPPING ccfm left outer join cpv_cc_case_details cd on(cd.case_id=ccfm.case_id and cd.case_id='" + txtCaseID.Text.Trim() + "' and cd.centre_id='" + Session["CentreId"].ToString() + "')" +
                       " where cd.case_id='" + txtCaseID.Text.Trim() + "' and verification_type_id=" + ddlVeri.SelectedValue + " and client_id=" + ddlClient.SelectedValue + " and ccfm.verification_type_id=" + obcCLPrinting.Verification_Type_ID + " ";
        o = OleDbHelper.ExecuteScalar(objconn.ConnectionString, CommandType.Text, strFE);
        if (Convert.ToInt32(o) == 1)
        {
            strSQL = " SELECT FW.fullname as fe_name,FW.EMP_CODE as fe_code,dbo.GetPrBarCode(" + ddlProduc.SelectedValue + ")+a.case_id+dbo.GetVeriBarCode(" + obcCLPrinting.Verification_Type_ID + ") as BrCode, " +
                     " (a.case_id +'~'+'" + obcCLPrinting.Verification_Type_ID + "' +'~'+'" + ddlProduc.SelectedValue + "'+'~'+'" + ddlClient.SelectedValue + "') as BarCode, " + strSQL + " FROM " + strTableName + " A INNER JOIN CPV_CC_CASE_VERIFICATIONTYPE B ON A.CASE_ID=B.CASE_ID " +
                     " left outer join CPV_CC_FE_CASE_MAPPING CFECM on(CFECM.case_id=a.case_id and CFECM.VERIFICATION_TYPE_ID='" + obcCLPrinting.Verification_Type_ID + "') " +
                     " left outer join FE_VW FW on(CFECM.FE_ID=FW.EMP_id)  " +
                     " WHERE b.VERIFICATION_TYPE_ID='" + ddlVeri.SelectedValue + "' AND  a.case_id =" + txtCaseID.Text.Trim() + " " +
                     " and a.Centre_id = " + obcCLPrinting.Centre_Id + " and  Client_id =" + obcCLPrinting.Client_ID + "  order by FW.fullname ";
        }
    }
    public void CELL_LablePrint()
    {
        for (int i = 0; i < dsLabelQuery.Tables[0].Rows.Count; i++)
        {
            strVerification_Type_Code = dsLabelQuery.Tables[0].Rows[i]["VERIFICATION_TYPE_CODE"].ToString();
            strAdditional1 = dsLabelQuery.Tables[0].Rows[i]["ADDITIONAL1"].ToString();
            strAdditional2 = dsLabelQuery.Tables[0].Rows[i]["ADDITIONAL2"].ToString();
            blnSR_NO = dsLabelQuery.Tables[0].Rows[i]["SR_NO"].ToString();
            blnLabelPrintingDate = dsLabelQuery.Tables[0].Rows[i]["LABEL_PRINTING_DATE"].ToString();
            blnAllVerificationType = dsLabelQuery.Tables[0].Rows[i]["ALL_VERIFICATION_TYPE"].ToString();
            strTableName = dsLabelQuery.Tables[0].Rows[i]["TABLE_NAME"].ToString();

            nSRNO = Convert.ToInt32(dsLabelQuery.Tables[0].Rows[i]["LINE_NO"].ToString());

            if (nPrevSRNO == nSRNO)
            {

                bool flag = false;
                if (Convert.ToString(dsLabelQuery.Tables[0].Rows[i]["SELECTED_FIELD"]) == "APP_PHONE1")
                {
                    flag = true;
                    strSQL = strSQL + "+ ' ' +'(R1:) '++ISNULL(" + dsLabelQuery.Tables[0].Rows[i]["SELECTED_FIELD"].ToString() + ",'')";
                }
                if (Convert.ToString(dsLabelQuery.Tables[0].Rows[i]["SELECTED_FIELD"]) == "APP_PHONE2")
                {
                    flag = true;
                    strSQL = strSQL + "+ ' ' +'(R2:) '++ISNULL(" + dsLabelQuery.Tables[0].Rows[i]["SELECTED_FIELD"].ToString() + ",'')";
                }
                if (Convert.ToString(dsLabelQuery.Tables[0].Rows[i]["SELECTED_FIELD"]) == "COMP_PHONE1")
                {
                    flag = true;
                    strSQL = strSQL + "+ ' ' +'(O1:) '++ISNULL(" + dsLabelQuery.Tables[0].Rows[i]["SELECTED_FIELD"].ToString() + ",'')";
                }
                if (Convert.ToString(dsLabelQuery.Tables[0].Rows[i]["SELECTED_FIELD"]) == "COMP_PHONE2")
                {
                    flag = true;
                    strSQL = strSQL + "+ ' ' +'(O2:) '++ISNULL(" + dsLabelQuery.Tables[0].Rows[i]["SELECTED_FIELD"].ToString() + ",'')";
                }
                if (flag == false)
                {
                    strSQL = strSQL + "+ ' ' +ISNULL(" + dsLabelQuery.Tables[0].Rows[i]["SELECTED_FIELD"].ToString() + ",'')";
                }
            }
            else if (nPrevSRNO == 0)
            {
                if (Convert.ToString(dsLabelQuery.Tables[0].Rows[i]["SELECTED_FIELD"]) == "HOLDER_COUNT")
                {
                    //strSQL = strSQL + "+CASE APP_PHONE1 WHEN ''THEN ''ELSE '(R1)'+APP_PHONE1 END";
                    strSQL = strSQL + "+Convert(varchar(24), ' '+ISNULL(" + dsLabelQuery.Tables[0].Rows[i]["SELECTED_FIELD"].ToString() + ",''))";
                }
                else if (Convert.ToString(dsLabelQuery.Tables[0].Rows[i]["SELECTED_FIELD"]) == "APP_PHONE2")
                {
                    strSQL = strSQL + "+CASE APP_PHONE2 WHEN ''THEN ''ELSE '(R2)'+APP_PHONE2 END";
                }

                else
                {
                    strSQL = strSQL + "+ ' ' +ISNULL(" + dsLabelQuery.Tables[0].Rows[i]["SELECTED_FIELD"].ToString() + ",'')";
                }
            }
            else if (nPrevSRNO != nSRNO)
            {

                bool flage = false;
                if (Convert.ToString(dsLabelQuery.Tables[0].Rows[i]["SELECTED_FIELD"]) == "APP_PHONE1")
                {
                    flage = true;
                    nForField++;
                    strSQL = strSQL + " AS Field" + nForField + ",+'(R1:) '+ISNULL(" + dsLabelQuery.Tables[0].Rows[i]["SELECTED_FIELD"].ToString() + ",'')";
                }
                if (Convert.ToString(dsLabelQuery.Tables[0].Rows[i]["SELECTED_FIELD"]) == "APP_PHONE2")
                {
                    flage = true;
                    nForField++;
                    strSQL = strSQL + " AS Field" + nForField + ",+'(R2:)'+ISNULL(" + dsLabelQuery.Tables[0].Rows[i]["SELECTED_FIELD"].ToString() + ",'')";
                }
                if (Convert.ToString(dsLabelQuery.Tables[0].Rows[i]["SELECTED_FIELD"]) == "COMP_PHONE1")
                {
                    flage = true;
                    nForField++;
                    strSQL = strSQL + " AS Field" + nForField + ",+'(O1:) '+ISNULL(" + dsLabelQuery.Tables[0].Rows[i]["SELECTED_FIELD"].ToString() + ",'')";
                }
                if (Convert.ToString(dsLabelQuery.Tables[0].Rows[i]["SELECTED_FIELD"]) == "COMP_PHONE2")
                {
                    flage = true;
                    nForField++;
                    strSQL = strSQL + " AS Field" + nForField + ",+'(O2:) '+ISNULL(" + dsLabelQuery.Tables[0].Rows[i]["SELECTED_FIELD"].ToString() + ",'')";
                }
                if (flage == false)
                {
                    nForField++;
                    strSQL = strSQL + " AS Field" + nForField + ",ISNULL(" + dsLabelQuery.Tables[0].Rows[i]["SELECTED_FIELD"].ToString() + ",'')";
                }
            }
            nPrevSRNO = nSRNO;
        }
        nForField++;
        strSQL = strSQL + " AS Field" + nForField;

        if (nForField <= 12)
        {
            for (int i = ++nForField; i <= 12; i++)
            {
                strSQL = strSQL + ",'' AS Field" + i;
            }
        }
    }
    public void CELL_Query()
    {
        string strFE = "select count(*) from CPV_CELLULAR_FE_CASE_MAPPING ccfm left outer join CPV_CELLULAR_CASES cd on(cd.case_id=ccfm.case_id and cd.case_id='" + txtCaseID.Text.Trim() + "' and cd.centre_id='" + Session["CentreId"].ToString() + "')" +
                       " where cd.case_id='" + txtCaseID.Text.Trim() + "' and client_id=" + ddlClient.SelectedValue + "  ";
        o = OleDbHelper.ExecuteScalar(objconn.ConnectionString, CommandType.Text, strFE);
        if (Convert.ToInt32(o) == 1)
        {
            strSQL = " SELECT FW.fullname as fe_name,FW.EMP_CODE as fe_code,dbo.GetPrBarCode(" + ddlProduc.SelectedValue + ")+a.case_id+dbo.GetVeriBarCode('1') as BrCode, " +
                     " (a.case_id +'~'+'" + obcCLPrinting.Verification_Type_ID + "' +'~'+'" +ddlProduc.SelectedValue+ "'+'~'+'" + ddlClient.SelectedValue + "') as BarCode, " + strSQL + " FROM " + strTableName + " A INNER JOIN CPV_CELLULAR_CASE_VERIFICATIONTYPE B ON A.CASE_ID=B.CASE_ID " +
                     " INNER JOIN CPV_CELLULAR_CASE_TYPE_MASTER ON A.CASE_TYPE_ID = CPV_CELLULAR_CASE_TYPE_MASTER.CASE_TYPE_ID LEFT OUTER JOIN CPV_CELLULAR_CUSTOMER_CLASS_MASTER ON " +
                     " A.CUSTOMER_CLASS = CPV_CELLULAR_CUSTOMER_CLASS_MASTER.CUSTOMER_CLASS_NAME INNER JOIN CPV_CELLULAR_CASE_VERIFICATIONTYPE ON A.CASE_ID = CPV_CELLULAR_CASE_VERIFICATIONTYPE.CASE_ID " +
                     " left outer join CPV_CELLULAR_FE_CASE_MAPPING CFECM on(CFECM.case_id=a.case_id and CFECM.VERIFICATION_TYPE_ID='1') " +
                     " left outer join FE_VW FW on(CFECM.FE_ID=FW.EMP_id)  " +
                     " WHERE A.CASE_TYPE_ID='" + obcCLPrinting.Verification_Type_ID + "' and a.case_id="+txtCaseID.Text.Trim()+" " +
                     " AND  A.CENTRE_ID = " + obcCLPrinting.Centre_Id + " and  A.CLIENT_ID =" + obcCLPrinting.Client_ID;
        }
    }

    protected void ddlProduc_SelectedIndexChanged(object sender, EventArgs e)
    {       
        
        sdsClient.SelectCommand = "select cm.client_name , cm.Client_id from Client_master cm left outer join  ce_ac_pr_ct_vw cvw on(cm.client_id=cvw.client_id) where   product_id=" + ddlProduc.SelectedValue + " and centre_id=" + Session["CentreId"].ToString() + "";
        ddlClient.DataBind();
        if (ddlProduc.SelectedValue == "1014")
        {
            sdsVeri.SelectCommand = " SELECT [CASE_TYPE_ID], [CASE_TYPE_CODE] FROM [CPV_CELLULAR_CASE_TYPE_MASTER]";
            ddlVeri.DataTextField = "CASE_TYPE_CODE";
            ddlVeri.DataValueField = "CASE_TYPE_ID";
            ddlVeri.DataBind();
        }
        else
        {
            sdsVeri.SelectCommand = "SELECT [VERIFICATION_TYPE_ID], [VERIFICATION_TYPE_CODE] FROM [VERIFICATION_TYPE_MASTER] where Parent_type_code in('vv','dv','tv')";
            ddlVeri.DataTextField = "VERIFICATION_TYPE_CODE";
            ddlVeri.DataValueField = "VERIFICATION_TYPE_ID";
            ddlVeri.DataBind();
        }
    }
    public void EBC_LablePrint()
    {
        for (int i = 0; i < dsLabelQuery.Tables[0].Rows.Count; i++)
        {
            strVerification_Type_Code = dsLabelQuery.Tables[0].Rows[i]["VERIFICATION_TYPE_CODE"].ToString();
            strAdditional1 = dsLabelQuery.Tables[0].Rows[i]["ADDITIONAL1"].ToString();
            strAdditional2 = dsLabelQuery.Tables[0].Rows[i]["ADDITIONAL2"].ToString();
            blnSR_NO = dsLabelQuery.Tables[0].Rows[i]["SR_NO"].ToString();
            blnLabelPrintingDate = dsLabelQuery.Tables[0].Rows[i]["LABEL_PRINTING_DATE"].ToString();
            blnAllVerificationType = dsLabelQuery.Tables[0].Rows[i]["ALL_VERIFICATION_TYPE"].ToString();
            strTableName = dsLabelQuery.Tables[0].Rows[i]["TABLE_NAME"].ToString();
            nSRNO = Convert.ToInt32(dsLabelQuery.Tables[0].Rows[i]["LINE_NO"].ToString());
            if (nPrevSRNO == nSRNO)
            {
                if (Convert.ToString(dsLabelQuery.Tables[0].Rows[i]["SELECTED_FIELD"]) == "MOBILE")
                {

                    strSQL = strSQL + "+CASE MOBILE WHEN ''THEN ''ELSE '(M) '+MOBILE END";
                }
                else if (Convert.ToString(dsLabelQuery.Tables[0].Rows[i]["SELECTED_FIELD"]) == "OFF_PHONE")
                {
                    strSQL = strSQL + "+CASE OFF_PHONE WHEN ''THEN ''ELSE '(0) '+OFF_PHONE END";
                }
                else if (Convert.ToString(dsLabelQuery.Tables[0].Rows[i]["SELECTED_FIELD"]) == "RES_PHONE")
                {
                    strSQL = strSQL + "+CASE RES_PHONE WHEN ''THEN ''ELSE '(R) '+RES_PHONE END";
                }
                //else if (Convert.ToString(dsLabelQuery.Tables[0].Rows[i]["SELECTED_FIELD"]) == "OFF_NAME")
                //{
                //    strSQL = strSQL + "+CASE OFF_NAME WHEN ''THEN ''ELSE '(CO) '+OFF_NAME END";
                //}

                else
                {
                    strSQL = strSQL + "+ ' ' +ISNULL(" + dsLabelQuery.Tables[0].Rows[i]["SELECTED_FIELD"].ToString() + ",'')";
                }
            }
            else if (nPrevSRNO == 0)
            {

                if (Convert.ToString(dsLabelQuery.Tables[0].Rows[i]["SELECTED_FIELD"]) == "MOBILE")
                {

                    strSQL = strSQL + "+CASE MOBILE WHEN ''THEN ''ELSE '(M) '+MOBILE END";
                }
                else if (Convert.ToString(dsLabelQuery.Tables[0].Rows[i]["SELECTED_FIELD"]) == "OFF_PHONE")
                {
                    strSQL = strSQL + "+CASE OFF_PHONE WHEN ''THEN ''ELSE '(0) '+OFF_PHONE END";
                }
                else if (Convert.ToString(dsLabelQuery.Tables[0].Rows[i]["SELECTED_FIELD"]) == "RES_PHONE")
                {
                    strSQL = strSQL + "+CASE RES_PHONE WHEN ''THEN ''ELSE '(R) '+RES_PHONE END";
                }
                else if (Convert.ToString(dsLabelQuery.Tables[0].Rows[i]["SELECTED_FIELD"]) == "OFF_NAME")
                {
                    strSQL = strSQL + "+CASE OFF_NAME WHEN ''THEN ''ELSE '(CO) '+OFF_NAME END";
                }

                else
                {
                    strSQL = strSQL + "+ ' ' +ISNULL(" + dsLabelQuery.Tables[0].Rows[i]["SELECTED_FIELD"].ToString() + ",'')";
                }
            }
            else if (nPrevSRNO != nSRNO)
            {
                bool flage = false;
                if (Convert.ToString(dsLabelQuery.Tables[0].Rows[i]["SELECTED_FIELD"]) == "MOBILE")
                {
                    flage = true;
                    //strSQL = strSQL + "+CASE MOBILE WHEN ''THEN ''ELSE '(M) '+MOBILE END";
                    nForField++;
                    strSQL = strSQL + " AS Field" + nForField + ",CASE WHEN MOBILE IS NULL OR RTRIM(LTRIM(MOBILE)) = '' THEN NULL ELSE +'(M:) '+ MOBILE END ";
                }
                if (Convert.ToString(dsLabelQuery.Tables[0].Rows[i]["SELECTED_FIELD"]) == "OFF_PHONE")
                {
                    flage = true;
                    //strSQL = strSQL + "+CASE OFF_PHONE WHEN ''THEN ''ELSE '(0) '+OFF_PHONE END";
                    nForField++;
                    strSQL = strSQL + " AS Field" + nForField + ",CASE WHEN OFF_PHONE IS NULL OR RTRIM(LTRIM(OFF_PHONE)) = '' THEN NULL ELSE +'(OP:) '+ OFF_PHONE END ";
                }
                if (Convert.ToString(dsLabelQuery.Tables[0].Rows[i]["SELECTED_FIELD"]) == "RES_PHONE")
                {
                    flage = true;
                    //strSQL = strSQL + "+CASE RES_PHONE WHEN ''THEN ''ELSE '(R) '+RES_PHONE END";
                    nForField++;
                    strSQL = strSQL + " AS Field" + nForField + ",CASE WHEN RES_PHONE IS NULL OR RTRIM(LTRIM(RES_PHONE)) = '' THEN NULL ELSE +'(RP:) '+ RES_PHONE END";
                }
                if (Convert.ToString(dsLabelQuery.Tables[0].Rows[i]["SELECTED_FIELD"]) == "OFF_NAME")
                {
                    flage = true;
                    nForField++;
                    //strSQL = strSQL + " AS Field" + nForField + ",+'Co: '+ISNULL(" + dsLabelQuery.Tables[0].Rows[i]["SELECTED_FIELD"].ToString() + ",'')";
                    strSQL = strSQL + " AS Field" + nForField + ",CASE WHEN OFF_NAME IS NULL OR RTRIM(LTRIM(OFF_NAME)) = '' THEN NULL ELSE +'(Co:) '+ OFF_NAME END";
                }

                if (flage == false)
                {
                    nForField++;
                    strSQL = strSQL + " AS Field" + nForField + ",ISNULL(" + dsLabelQuery.Tables[0].Rows[i]["SELECTED_FIELD"].ToString() + ",'')";
                }
                //}
            }

            nPrevSRNO = nSRNO;

        }
        nForField++;
        strSQL = strSQL + " AS Field" + nForField;


        //Final Querry..
        //By Ashish..
        //strSQL = "SELECT " + strSQL + " FROM " + strTableName + " WHERE case_rec_datetime >= '" + obcCLPrinting.Fromdate + "' AND case_rec_datetime < = '" + obcCLPrinting.Todate + "' and Centre_id = " + obcCLPrinting.Centre_Id + " and  Client_id =" + obcCLPrinting.Client_ID + "";
        if (nForField <= 12)
        {
            for (int i = ++nForField; i <= 12; i++)
            {
                strSQL = strSQL + ",'' AS Field" + i;
            }
        }
        if (blnSR_NO == "Y")
        {
            //nForField++;
            strSQL = strSQL + "," + "SR_NO";
        }
        //if (blnAllVerificationType == "Y")
        //{

        //    strSQL = strSQL + "," + "VERIFICATION_CODE";
        //}
        if (blnLabelPrintingDate == "Y")
        {
            strSQL = strSQL + "," + "Convert(varchar(11),CASE_REC_DATETIME,103) as CASE_REC_DATETIME";
        }
        strSQL = strSQL + "," + " A.CASE_ID";
    }
    public void EBC_Query()
    {
        string strFE = "select count(*) from CPV_EBC_FE_MAPPING ccfm left outer join CPV_EBC_CASE_DETAILS cd on(cd.case_id=ccfm.case_id and cd.case_id='" + txtCaseID.Text.Trim() + "' and cd.centre_id='" + Session["CentreId"].ToString() + "')" +
                       " where cd.case_id='" + txtCaseID.Text.Trim() + "' and client_id=" + ddlClient.SelectedValue + " and ccfm.verification_type_id=" + obcCLPrinting.Verification_Type_ID + " ";
        o = OleDbHelper.ExecuteScalar(objconn.ConnectionString, CommandType.Text, strFE);
        if (Convert.ToInt32(o) == 1)
        {
            strSQL = " SELECT FW.fullname as fe_name,FW.EMP_CODE as fe_code,dbo.GetPrBarCode(" + ddlProduc.SelectedValue + ")+a.case_id+dbo.GetVeriBarCode(" + obcCLPrinting.Verification_Type_ID + ") as BrCode, " +
                     " (a.case_id +'~'+'" + obcCLPrinting.Verification_Type_ID + "' +'~'+'" + ddlProduc.SelectedValue + "'+'~'+'" + ddlClient.SelectedValue + "') as BarCode, " + strSQL + " FROM " + strTableName + " A INNER JOIN CPV_EBC_VAERIFICATION_TYPE B ON A.CASE_ID=B.CASE_ID " +
                     " left outer join CPV_EBC_FE_MAPPING CFECM on(CFECM.case_id=a.case_id and CFECM.VERIFICATION_TYPE_ID='" + obcCLPrinting.Verification_Type_ID + "') " +
                     " left outer join FE_VW FW on(CFECM.FE_ID=FW.EMP_id)  " +
                     " WHERE b.VERIFICATION_TYPE_ID='" + obcCLPrinting.Verification_Type_ID + "' AND  a.case_id='" + txtCaseID.Text.Trim() + "' " +
                     " and a.Centre_id = " + obcCLPrinting.Centre_Id + " and  Client_id =" + obcCLPrinting.Client_ID + "  order by FW.fullname ";
        }
    }
    public void KYC_LablePrint()
    {
        for (int i = 0; i < dsLabelQuery.Tables[0].Rows.Count; i++)
        {
            strVerification_Type_Code = dsLabelQuery.Tables[0].Rows[i]["VERIFICATION_TYPE_CODE"].ToString();
            strAdditional1 = dsLabelQuery.Tables[0].Rows[i]["ADDITIONAL1"].ToString();
            strAdditional2 = dsLabelQuery.Tables[0].Rows[i]["ADDITIONAL2"].ToString();
            blnSR_NO = dsLabelQuery.Tables[0].Rows[i]["SR_NO"].ToString();
            blnLabelPrintingDate = dsLabelQuery.Tables[0].Rows[i]["LABEL_PRINTING_DATE"].ToString();
            blnAllVerificationType = dsLabelQuery.Tables[0].Rows[i]["ALL_VERIFICATION_TYPE"].ToString();
            strTableName = dsLabelQuery.Tables[0].Rows[i]["TABLE_NAME"].ToString();
            nSRNO = Convert.ToInt32(dsLabelQuery.Tables[0].Rows[i]["LINE_NO"].ToString());


            if (nPrevSRNO == nSRNO)
            {
                if (Convert.ToString(dsLabelQuery.Tables[0].Rows[i]["SELECTED_FIELD"]) == "MOBILE")
                {

                    strSQL = strSQL + "+CASE MOBILE WHEN ''THEN ''ELSE '(M) '+MOBILE END";
                }
                else if (Convert.ToString(dsLabelQuery.Tables[0].Rows[i]["SELECTED_FIELD"]) == "OFF_PHONE")
                {
                    strSQL = strSQL + "+CASE OFF_PHONE WHEN ''THEN ''ELSE '(0) '+OFF_PHONE END";
                }
                else if (Convert.ToString(dsLabelQuery.Tables[0].Rows[i]["SELECTED_FIELD"]) == "RES_PHONE")
                {
                    strSQL = strSQL + "+CASE RES_PHONE WHEN ''THEN ''ELSE '(R) '+RES_PHONE END";
                }
                //else if (Convert.ToString(dsLabelQuery.Tables[0].Rows[i]["SELECTED_FIELD"]) == "OFF_NAME")
                //{
                //    strSQL = strSQL + "+CASE OFF_NAME WHEN ''THEN ''ELSE '(CO) '+OFF_NAME END";
                //}

                else
                {
                    strSQL = strSQL + "+ ' ' +ISNULL(" + dsLabelQuery.Tables[0].Rows[i]["SELECTED_FIELD"].ToString() + ",'')";
                }
            }
            else if (nPrevSRNO == 0)
            {

                if (Convert.ToString(dsLabelQuery.Tables[0].Rows[i]["SELECTED_FIELD"]) == "MOBILE")
                {

                    strSQL = strSQL + "+CASE MOBILE WHEN ''THEN ''ELSE '(M) '+MOBILE END";
                }
                else if (Convert.ToString(dsLabelQuery.Tables[0].Rows[i]["SELECTED_FIELD"]) == "OFF_PHONE")
                {
                    strSQL = strSQL + "+CASE OFF_PHONE WHEN ''THEN ''ELSE '(0) '+OFF_PHONE END";
                }
                else if (Convert.ToString(dsLabelQuery.Tables[0].Rows[i]["SELECTED_FIELD"]) == "RES_PHONE")
                {
                    strSQL = strSQL + "+CASE RES_PHONE WHEN ''THEN ''ELSE '(R) '+RES_PHONE END";
                }
                else if (Convert.ToString(dsLabelQuery.Tables[0].Rows[i]["SELECTED_FIELD"]) == "OFF_NAME")
                {
                    strSQL = strSQL + "+CASE OFF_NAME WHEN ''THEN ''ELSE '(CO) '+OFF_NAME END";
                }

                else
                {
                    strSQL = strSQL + "+ ' ' +ISNULL(" + dsLabelQuery.Tables[0].Rows[i]["SELECTED_FIELD"].ToString() + ",'')";
                }
            }
            else if (nPrevSRNO != nSRNO)
            {
                bool flage = false;
                if (Convert.ToString(dsLabelQuery.Tables[0].Rows[i]["SELECTED_FIELD"]) == "MOBILE")
                {
                    flage = true;
                    //strSQL = strSQL + "+CASE MOBILE WHEN ''THEN ''ELSE '(M) '+MOBILE END";
                    nForField++;
                    strSQL = strSQL + " AS Field" + nForField + ",CASE WHEN MOBILE IS NULL OR RTRIM(LTRIM(MOBILE)) = '' THEN NULL ELSE +'(M:) '+ MOBILE END ";
                }
                if (Convert.ToString(dsLabelQuery.Tables[0].Rows[i]["SELECTED_FIELD"]) == "OFF_PHONE")
                {
                    flage = true;
                    //strSQL = strSQL + "+CASE OFF_PHONE WHEN ''THEN ''ELSE '(0) '+OFF_PHONE END";
                    nForField++;
                    strSQL = strSQL + " AS Field" + nForField + ",CASE WHEN OFF_PHONE IS NULL OR RTRIM(LTRIM(OFF_PHONE)) = '' THEN NULL ELSE +'(OP:) '+ OFF_PHONE END ";
                }
                if (Convert.ToString(dsLabelQuery.Tables[0].Rows[i]["SELECTED_FIELD"]) == "RES_PHONE")
                {
                    flage = true;
                    //strSQL = strSQL + "+CASE RES_PHONE WHEN ''THEN ''ELSE '(R) '+RES_PHONE END";
                    nForField++;
                    strSQL = strSQL + " AS Field" + nForField + ",CASE WHEN RES_PHONE IS NULL OR RTRIM(LTRIM(RES_PHONE)) = '' THEN NULL ELSE +'(RP:) '+ RES_PHONE END";
                }
                if (Convert.ToString(dsLabelQuery.Tables[0].Rows[i]["SELECTED_FIELD"]) == "OFF_NAME")
                {
                    flage = true;
                    nForField++;
                    //strSQL = strSQL + " AS Field" + nForField + ",+'Co: '+ISNULL(" + dsLabelQuery.Tables[0].Rows[i]["SELECTED_FIELD"].ToString() + ",'')";
                    strSQL = strSQL + " AS Field" + nForField + ",CASE WHEN OFF_NAME IS NULL OR RTRIM(LTRIM(OFF_NAME)) = '' THEN NULL ELSE +'(Co:) '+ OFF_NAME END";
                }

                if (flage == false)
                {
                    nForField++;
                    strSQL = strSQL + " AS Field" + nForField + ",ISNULL(" + dsLabelQuery.Tables[0].Rows[i]["SELECTED_FIELD"].ToString() + ",'')";
                }
                //}
            }

            nPrevSRNO = nSRNO;

        }
        nForField++;
        strSQL = strSQL + " AS Field" + nForField;


        //Final Querry..
        //By Ashish..
        //strSQL = "SELECT " + strSQL + " FROM " + strTableName + " WHERE case_rec_datetime >= '" + obcCLPrinting.Fromdate + "' AND case_rec_datetime < = '" + obcCLPrinting.Todate + "' and Centre_id = " + obcCLPrinting.Centre_Id + " and  Client_id =" + obcCLPrinting.Client_ID + "";
        if (nForField <= 12)
        {
            for (int i = ++nForField; i <= 12; i++)
            {
                strSQL = strSQL + ",'' AS Field" + i;
            }
        }
        if (blnSR_NO == "Y")
        {
            //nForField++;
            strSQL = strSQL + "," + "SR_NO";
        }
        //if (blnAllVerificationType == "Y")
        //{

        //    strSQL = strSQL + "," + "VERIFICATION_CODE";
        //}
        if (blnLabelPrintingDate == "Y")
        {
            strSQL = strSQL + "," + "Convert(varchar(11),CASE_REC_DATETIME,103) as CASE_REC_DATETIME";
        }
        strSQL = strSQL + "," + " A.CASE_ID";
        //Fianl STR  
    }
    public void KYC_Query()
    {
        string strFE = "select count(*) from CPV_KYC_FE_MAPPING ccfm left outer join CPV_KYC_CASE_DETAILS cd on(cd.case_id=ccfm.case_id and cd.case_id='" + txtCaseID.Text.Trim() + "' and cd.centre_id='" + Session["CentreId"].ToString() + "')" +
                       " where cd.case_id='" + txtCaseID.Text.Trim() + "' and client_id=" + ddlClient.SelectedValue + " and ccfm.verification_type_id=" + obcCLPrinting.Verification_Type_ID + " ";
        o = OleDbHelper.ExecuteScalar(objconn.ConnectionString, CommandType.Text, strFE);
        if (Convert.ToInt32(o) == 1)
        {
            strSQL = " SELECT FW.fullname as fe_name,FW.EMP_CODE as fe_code,dbo.GetPrBarCode(" + ddlProduc.SelectedValue + ")+a.case_id+dbo.GetVeriBarCode(" + obcCLPrinting.Verification_Type_ID + ") as BrCode, " +
                     " (a.case_id +'~'+'" + obcCLPrinting.Verification_Type_ID + "' +'~'+'" + ddlProduc.SelectedValue + "'+'~'+'" + ddlClient.SelectedValue + "') as BarCode, " + strSQL + " FROM " + strTableName + " A INNER JOIN CPV_KYC_VERIFICATION_TYPE B ON A.CASE_ID=B.CASE_ID " +
                     " left outer join CPV_KYC_FE_MAPPING CFECM on(CFECM.case_id=a.case_id and CFECM.VERIFICATION_TYPE_ID='" + obcCLPrinting.Verification_Type_ID + "') " +
                     " left outer join FE_VW FW on(CFECM.FE_ID=FW.EMP_id)  " +
                     " WHERE b.VERIFICATION_TYPE_ID='" + obcCLPrinting.Verification_Type_ID + "' AND  a.case_id =" + txtCaseID.Text.Trim() + " and " +
                     " a.Centre_id = " + obcCLPrinting.Centre_Id + " and  Client_id =" + obcCLPrinting.Client_ID + "  order by FW.fullname ";
        }
    }
    public void RL_LablePrint()
    {
        for (int i = 0; i < dsLabelQuery.Tables[0].Rows.Count; i++)
        {
            strVerification_Type_Code = dsLabelQuery.Tables[0].Rows[i]["VERIFICATION_TYPE_CODE"].ToString();
            strAdditional1 = dsLabelQuery.Tables[0].Rows[i]["ADDITIONAL1"].ToString();
            strAdditional2 = dsLabelQuery.Tables[0].Rows[i]["ADDITIONAL2"].ToString();
            blnSR_NO = dsLabelQuery.Tables[0].Rows[i]["SR_NO"].ToString();
            blnLabelPrintingDate = dsLabelQuery.Tables[0].Rows[i]["LABEL_PRINTING_DATE"].ToString();
            blnAllVerificationType = dsLabelQuery.Tables[0].Rows[i]["ALL_VERIFICATION_TYPE"].ToString();
            strTableName = dsLabelQuery.Tables[0].Rows[i]["TABLE_NAME"].ToString();

            nSRNO = Convert.ToInt32(dsLabelQuery.Tables[0].Rows[i]["LINE_NO"].ToString());


            if (nPrevSRNO == nSRNO)
            {
                if (Convert.ToString(dsLabelQuery.Tables[0].Rows[i]["SELECTED_FIELD"]) == "MOBILE")
                {

                    strSQL = strSQL + "+CASE MOBILE WHEN ''THEN ''ELSE '(M) '+MOBILE END";
                }
                else if (Convert.ToString(dsLabelQuery.Tables[0].Rows[i]["SELECTED_FIELD"]) == "OFF_PHONE")
                {
                    strSQL = strSQL + "+CASE OFF_PHONE WHEN ''THEN ''ELSE '(0) '+OFF_PHONE END";
                }
                else if (Convert.ToString(dsLabelQuery.Tables[0].Rows[i]["SELECTED_FIELD"]) == "RES_PHONE")
                {
                    strSQL = strSQL + "+CASE RES_PHONE WHEN ''THEN ''ELSE '(R) '+RES_PHONE END";
                }
                //else if (Convert.ToString(dsLabelQuery.Tables[0].Rows[i]["SELECTED_FIELD"]) == "OFF_NAME")
                //{
                //    strSQL = strSQL + "+CASE OFF_NAME WHEN ''THEN ''ELSE '(CO) '+OFF_NAME END";
                //}

                else
                {
                    strSQL = strSQL + "+ ' ' +ISNULL(" + dsLabelQuery.Tables[0].Rows[i]["SELECTED_FIELD"].ToString() + ",'')";
                }
            }
            else if (nPrevSRNO == 0)
            {

                if (Convert.ToString(dsLabelQuery.Tables[0].Rows[i]["SELECTED_FIELD"]) == "MOBILE")
                {

                    strSQL = strSQL + "+CASE MOBILE WHEN ''THEN ''ELSE '(M) '+MOBILE END";
                }
                else if (Convert.ToString(dsLabelQuery.Tables[0].Rows[i]["SELECTED_FIELD"]) == "OFF_PHONE")
                {
                    strSQL = strSQL + "+CASE OFF_PHONE WHEN ''THEN ''ELSE '(0) '+OFF_PHONE END";
                }
                else if (Convert.ToString(dsLabelQuery.Tables[0].Rows[i]["SELECTED_FIELD"]) == "RES_PHONE")
                {
                    strSQL = strSQL + "+CASE RES_PHONE WHEN ''THEN ''ELSE '(R) '+RES_PHONE END";
                }
                else if (Convert.ToString(dsLabelQuery.Tables[0].Rows[i]["SELECTED_FIELD"]) == "OFF_NAME")
                {
                    strSQL = strSQL + "+CASE OFF_NAME WHEN ''THEN ''ELSE '(CO) '+OFF_NAME END";
                }

                else
                {
                    strSQL = strSQL + "+ ' ' +ISNULL(" + dsLabelQuery.Tables[0].Rows[i]["SELECTED_FIELD"].ToString() + ",'')";
                }
            }
            else if (nPrevSRNO != nSRNO)
            {
                bool flage = false;
                if (Convert.ToString(dsLabelQuery.Tables[0].Rows[i]["SELECTED_FIELD"]) == "MOBILE")
                {
                    flage = true;
                    //strSQL = strSQL + "+CASE MOBILE WHEN ''THEN ''ELSE '(M) '+MOBILE END";
                    nForField++;
                    strSQL = strSQL + " AS Field" + nForField + ",CASE WHEN MOBILE IS NULL OR RTRIM(LTRIM(MOBILE)) = '' THEN NULL ELSE +'(M:) '+ MOBILE END ";
                }
                if (Convert.ToString(dsLabelQuery.Tables[0].Rows[i]["SELECTED_FIELD"]) == "OFF_PHONE")
                {
                    flage = true;
                    //strSQL = strSQL + "+CASE OFF_PHONE WHEN ''THEN ''ELSE '(0) '+OFF_PHONE END";
                    nForField++;
                    strSQL = strSQL + " AS Field" + nForField + ",CASE WHEN OFF_PHONE IS NULL OR RTRIM(LTRIM(OFF_PHONE)) = '' THEN NULL ELSE +'(OP:) '+ OFF_PHONE END ";
                }
                if (Convert.ToString(dsLabelQuery.Tables[0].Rows[i]["SELECTED_FIELD"]) == "RES_PHONE")
                {
                    flage = true;
                    //strSQL = strSQL + "+CASE RES_PHONE WHEN ''THEN ''ELSE '(R) '+RES_PHONE END";
                    nForField++;
                    strSQL = strSQL + " AS Field" + nForField + ",CASE WHEN RES_PHONE IS NULL OR RTRIM(LTRIM(RES_PHONE)) = '' THEN NULL ELSE +'(RP:) '+ RES_PHONE END";
                }
                if (Convert.ToString(dsLabelQuery.Tables[0].Rows[i]["SELECTED_FIELD"]) == "OFF_NAME")
                {
                    flage = true;
                    nForField++;
                    //strSQL = strSQL + " AS Field" + nForField + ",+'Co: '+ISNULL(" + dsLabelQuery.Tables[0].Rows[i]["SELECTED_FIELD"].ToString() + ",'')";
                    strSQL = strSQL + " AS Field" + nForField + ",CASE WHEN OFF_NAME IS NULL OR RTRIM(LTRIM(OFF_NAME)) = '' THEN NULL ELSE +'(Co:) '+ OFF_NAME END";
                }

                if (flage == false)
                {
                    nForField++;
                    strSQL = strSQL + " AS Field" + nForField + ",ISNULL(" + dsLabelQuery.Tables[0].Rows[i]["SELECTED_FIELD"].ToString() + ",'')";
                }
                //}
            }

            nPrevSRNO = nSRNO;

        }
        nForField++;
        strSQL = strSQL + " AS Field" + nForField;


        //Final Querry..
        //By Ashish..
        //strSQL = "SELECT " + strSQL + " FROM " + strTableName + " WHERE case_rec_datetime >= '" + obcCLPrinting.Fromdate + "' AND case_rec_datetime < = '" + obcCLPrinting.Todate + "' and Centre_id = " + obcCLPrinting.Centre_Id + " and  Client_id =" + obcCLPrinting.Client_ID + "";
        if (nForField <= 12)
        {
            for (int i = ++nForField; i <= 12; i++)
            {
                strSQL = strSQL + ",'' AS Field" + i;
            }
        }
        if (blnSR_NO == "Y")
        {
            //nForField++;
            strSQL = strSQL + "," + "SR_NO";
        }
        if (blnAllVerificationType == "Y")
        {

            strSQL = strSQL + "," + "VERIFICATION_CODE";
        }
        if (blnLabelPrintingDate == "Y")
        {
            strSQL = strSQL + "," + "Convert(varchar(11),CASE_REC_DATETIME,103) as CASE_REC_DATETIME";
        }
        strSQL = strSQL + "," + " A.CASE_ID";
        //Fianl STR 
 
    }
    public void RL_Query()
    {
        string strFE = "select count(*) from CPV_RL_CASE_FE_MAPPING ccfm left outer join CPV_RL_CASE_DETAILS cd on(cd.case_id=ccfm.case_id and cd.case_id='" + txtCaseID.Text.Trim() + "' and cd.centre_id='" + Session["CentreId"].ToString() + "')" +
                        " where cd.case_id='" + txtCaseID.Text.Trim() + "' and client_id=" + ddlClient.SelectedValue + " and ccfm.verification_type_id=" + obcCLPrinting.Verification_Type_ID + " ";
        o = OleDbHelper.ExecuteScalar(objconn.ConnectionString, CommandType.Text, strFE);
        if (Convert.ToInt32(o) == 1)
        {
            strSQL = " SELECT FW.fullname as fe_name,FW.EMP_CODE as fe_code,dbo.GetPrBarCode(" + ddlProduc.SelectedValue + ")+a.case_id+dbo.GetVeriBarCode(" + obcCLPrinting.Verification_Type_ID + ") as BrCode, " +
                     " (a.case_id +'~'+'" + obcCLPrinting.Verification_Type_ID + "' +'~'+'" + ddlProduc.SelectedValue + "'+'~'+'" + ddlClient.SelectedValue + "') as BarCode, " + strSQL + " FROM " + strTableName + " A INNER JOIN CPV_RL_CASE_VERIFICATIONTYPE B ON A.CASE_ID=B.CASE_ID " +
                     " left outer join CPV_RL_CASE_FE_MAPPING CFECM on(CFECM.case_id=a.case_id and CFECM.VERIFICATION_TYPE_ID='" + obcCLPrinting.Verification_Type_ID + "') " +
                     " left outer join FE_VW FW on(CFECM.FE_ID=FW.EMP_id)  " +
                     " WHERE b.VERIFICATION_TYPE_ID='" + obcCLPrinting.Verification_Type_ID + "'  AND a.case_id =" + txtCaseID.Text.Trim() + " and " +
                     " a.Centre_id = " + obcCLPrinting.Centre_Id + " and  Client_id =" + obcCLPrinting.Client_ID + "  order by FW.fullname ";
        }
    }
    public void IDOC_LablePrint()
    {
        for (int i = 0; i < dsLabelQuery.Tables[0].Rows.Count; i++)
        {
            strVerification_Type_Code = dsLabelQuery.Tables[0].Rows[i]["VERIFICATION_TYPE_CODE"].ToString();
            strAdditional1 = dsLabelQuery.Tables[0].Rows[i]["ADDITIONAL1"].ToString();
            strAdditional2 = dsLabelQuery.Tables[0].Rows[i]["ADDITIONAL2"].ToString();
            blnSR_NO = dsLabelQuery.Tables[0].Rows[i]["SR_NO"].ToString();
            blnLabelPrintingDate = dsLabelQuery.Tables[0].Rows[i]["LABEL_PRINTING_DATE"].ToString();
            blnAllVerificationType = dsLabelQuery.Tables[0].Rows[i]["ALL_VERIFICATION_TYPE"].ToString();
            strTableName = dsLabelQuery.Tables[0].Rows[i]["TABLE_NAME"].ToString();

            nSRNO = Convert.ToInt32(dsLabelQuery.Tables[0].Rows[i]["LINE_NO"].ToString());

            if (nPrevSRNO == nSRNO)
            {
                strSQL = strSQL + "+ ' ' +ISNULL(" + dsLabelQuery.Tables[0].Rows[i]["SELECTED_FIELD"].ToString() + ",'')";
            }
            else if (nPrevSRNO == 0)
            {
                strSQL = strSQL + "+ ' ' +ISNULL(" + dsLabelQuery.Tables[0].Rows[i]["SELECTED_FIELD"].ToString() + ",'')";
            }
            else if (nPrevSRNO != nSRNO)
            {
                nForField++;
                strSQL = strSQL + " AS Field" + nForField + ",ISNULL(" + dsLabelQuery.Tables[0].Rows[i]["SELECTED_FIELD"].ToString() + ",'')";
            }
            nPrevSRNO = nSRNO;
        }
        nForField++;
        strSQL = strSQL + " AS Field" + nForField;

        if (nForField <= 12)
        {
            for (int i = ++nForField; i <= 12; i++)
            {
                strSQL = strSQL + ",'' AS Field" + i;
            }
        }
        //if (blnSR_NO == "Y")
        //{
        strSQL = strSQL + "," + "SR_NO";
        //}
        //if (blnLabelPrintingDate == "Y")
        //{
        strSQL = strSQL + "," + "Convert(varchar(11),CASE_REC_DATETIME,103) as CASE_REC_DATETIME";
        //}
    }
    public void IDOC_Query()
    {
        string strFE = "select count(*) from CPV_IDOC_FE_CASE_MAPPING ccfm left outer join CPV_IDOC_CASE_DETAILS cd on(cd.case_id=ccfm.case_id and cd.case_id='" + txtCaseID.Text.Trim() + "' and cd.centre_id='" + Session["CentreId"].ToString() + "')" +
                       " where cd.case_id='" + txtCaseID.Text.Trim() + "' and client_id=" + ddlClient.SelectedValue + " and ccfm.verification_type_id=" + obcCLPrinting.Verification_Type_ID + " ";
        o = OleDbHelper.ExecuteScalar(objconn.ConnectionString, CommandType.Text, strFE);
        if (Convert.ToInt32(o) == 1)
        {
            strSQL = " SELECT FW.fullname as fe_name,a.case_id,a.verification_code,FW.EMP_CODE as fe_code,dbo.GetPrBarCode(" + ddlProduc.SelectedValue + ")+a.case_id+dbo.GetVeriBarCode(" + obcCLPrinting.Verification_Type_ID + ") as BrCode, " +
                     " (a.case_id +'~'+'" + obcCLPrinting.Verification_Type_ID + "' +'~'+'" + ddlProduc.SelectedValue + "'+'~'+'" + ddlClient.SelectedValue + "') as BarCode, " + strSQL + " FROM " + strTableName + " A INNER JOIN CPV_IDOC_VERIFICATION_TYPE B ON A.CASE_ID=B.CASE_ID " +
                     " left outer join CPV_IDOC_FE_CASE_MAPPING CFECM on(CFECM.case_id=a.case_id and CFECM.VERIFICATION_TYPE_ID='" + obcCLPrinting.Verification_Type_ID + "') " +
                     " left outer join FE_VW FW on(CFECM.FE_ID=FW.EMP_id)  " +
                     " WHERE b.VERIFICATION_TYPE_ID='" + obcCLPrinting.Verification_Type_ID + "' AND  a.case_id =" + txtCaseID.Text.Trim() + " and " +
                     " a.Centre_id = " + obcCLPrinting.Centre_Id + " and  Client_id =" + obcCLPrinting.Client_ID + "  order by FW.fullname ";
        }
    }
    protected void ddlProduc_DataBound(object sender, EventArgs e)
    {
        ddlProduc.Items.Insert(0, new ListItem("--Select Product--", "0"));
    }
}