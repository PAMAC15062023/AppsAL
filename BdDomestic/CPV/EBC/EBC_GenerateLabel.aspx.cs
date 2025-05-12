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
public partial class CPV_EBC_EBC_GenerateLabel : System.Web.UI.Page
{
    CCommon objconn = new CCommon();
    DataSet ds = new DataSet();
    OleDbDataAdapter da = new OleDbDataAdapter();
    DataTable d_table = new DataTable();


    protected void Page_Load(object sender, EventArgs e)
    {
        int k = 0;
        try
        {
            int icount = 0;
            string todate = "";
            CCreditCardGenerateLabel obcCLPrinting = new CCreditCardGenerateLabel();
            obcCLPrinting.Fromdate = Session["fromdate"].ToString();
            obcCLPrinting.Todate = Session["todate"].ToString();
            todate = Convert.ToDateTime(obcCLPrinting.Todate).AddDays(1.0).ToString("dd-MMM-yyyy");
            obcCLPrinting.Activity_ID = Session["ActivityId"].ToString();
            obcCLPrinting.Product_ID = Session["ProductId"].ToString();
            obcCLPrinting.Client_ID = Session["ClientId"].ToString();
            obcCLPrinting.Verification_Type_ID = Session["VerificationId"].ToString();
            obcCLPrinting.Centre_Id = Session["CentreId"].ToString();
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
            DataSet dsLabelQuery = new DataSet();
            dsLabelQuery = obcCLPrinting.getTemplate();
            string fdate = Session["fromdate"].ToString();
            string tdate = Session["todate"].ToString();
            if (dsLabelQuery != null)
            {
                try
                {

                    if (dsLabelQuery.Tables[0].Rows.Count > 0)
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
                    else if (dsLabelQuery.Tables[0].Rows.Count == 0)
                    {
                        icount = 1;
                        //Response.Redirect("CC_LabelPrinting.aspx?Message=No Template Found !!");
                    }
                }
                catch (Exception ex)
                {
                    Response.Write(ex.Message.ToString());
                }
                if (icount == 1)
                {
                    Response.Redirect("EBC_LabelPrinting.aspx?Message=No Template Found !!&FromDt=" + fdate + "&ToDt=" + tdate + " ");
                }
                //Final Querry !!!



                //Final Querry !!!
                // Added by sandeep khare on date 12-oct-2007
                //Code for restriction about Supervisor //
                string strquery1 = "";

                string selectCriteria = "";

                OleDbDataReader dr1;
                string strCaseID1 = "";
                string strFEAssi = "";
                string strResult = "true";
                if (obcCLPrinting.Verification_Type_ID.Trim() != "3" && obcCLPrinting.Verification_Type_ID.Trim() != "4")
                {
                    strFEAssi = " select case (select count(*) from CPV_EBC_VAERIFICATION_TYPE ccv inner join CPV_EBC_CASE_DETAILS cd  on(cd.case_id=ccv.case_id) where verification_type_id='" + obcCLPrinting.Verification_Type_ID + "' and cd.CASE_REC_DATETIME >='" + obcCLPrinting.Fromdate + "' and cd.CASE_REC_DATETIME<'" + todate + "' and cd.CASE_REC_DATETIME<'" + todate + "' and cd.Centre_id = " + obcCLPrinting.Centre_Id + " and  cd.Client_id =" + obcCLPrinting.Client_ID + ")  " +
                                " when (select count(*) from CPV_EBC_FE_MAPPING ccf left outer join CPV_EBC_CASE_DETAILS cd on (ccf.case_id=cd.case_id)  where verification_type_id='" + obcCLPrinting.Verification_Type_ID + "' and cd.CASE_REC_DATETIME >='" + obcCLPrinting.Fromdate + "' and cd.CASE_REC_DATETIME<'" + todate + "' and cd.CASE_REC_DATETIME<'" + todate + "' and cd.Centre_id = " + obcCLPrinting.Centre_Id + " and  cd.Client_id =" + obcCLPrinting.Client_ID + ") " +
                                " then 'true' else 'false' end  as Result";
                    strResult = (string)(OleDbHelper.ExecuteScalar(objconn.ConnectionString, CommandType.Text, strFEAssi));
                }
               
                int l = 0;
                if (strResult == "true")
                {
                   
                    
                    if (Session["RoleId"].ToString() == "2")
                    {
                        strquery1 = "select count(*) from CPV_EBC_VAERIFICATION_TYPE where  IS_LABLE_PRINT='N' ";
                        object o = OleDbHelper.ExecuteScalar(objconn.ConnectionString, CommandType.Text, strquery1);
                        if (Convert.ToInt32(o) != 0)
                        {
                            selectCriteria = " AND IS_LABLE_PRINT='N'";
                        }

                        strSQL =     " SELECT FW.fullname as fe_name,(FW.fullname +'-'+ FW.EMP_CODE) as fe_code,dbo.GetPrBarCode(" + Session["ProductId"].ToString() + ")+a.case_id+dbo.GetVeriBarCode(" + obcCLPrinting.Verification_Type_ID + ") as BrCode, " +
                                     " (a.case_id +'~'+'" + obcCLPrinting.Verification_Type_ID + "' +'~'+'" + Session["ProductId"].ToString() + "'+'~'+'" + Session["ClientId"].ToString() + "') as BarCode, " + strSQL + " FROM " + strTableName + " A INNER JOIN CPV_EBC_VAERIFICATION_TYPE B ON A.CASE_ID=B.CASE_ID " +
                                     " left outer join CPV_EBC_FE_MAPPING CFECM on(CFECM.case_id=a.case_id and CFECM.VERIFICATION_TYPE_ID='" + obcCLPrinting.Verification_Type_ID + "') " +
                                     " left outer join FE_VW FW on(CFECM.FE_ID=FW.EMP_id)  " +
                                     " WHERE b.VERIFICATION_TYPE_ID='" + obcCLPrinting.Verification_Type_ID + "' AND case_rec_datetime >= '" + obcCLPrinting.Fromdate + "'  and " +
                                     " case_rec_datetime < '" + todate + "' and a.Centre_id = " + obcCLPrinting.Centre_Id + " and  Client_id =" + obcCLPrinting.Client_ID + " " + selectCriteria + " order by FW.fullname";

                    }
                    else
                    {
                        strSQL =     " SELECT FW.fullname as fe_name,(FW.fullname +'-'+ FW.EMP_CODE) as fe_code,dbo.GetPrBarCode(" + Session["ProductId"].ToString() + ")+a.case_id+dbo.GetVeriBarCode(" + obcCLPrinting.Verification_Type_ID + ") as BrCode, " +
                                     " (a.case_id +'~'+'" + obcCLPrinting.Verification_Type_ID + "' +'~'+'" + Session["ProductId"].ToString() + "'+'~'+'" + Session["ClientId"].ToString() + "') as BarCode, " + strSQL + " FROM " + strTableName + " A INNER JOIN CPV_EBC_VAERIFICATION_TYPE B ON A.CASE_ID=B.CASE_ID " +
                                     " left outer join CPV_EBC_FE_MAPPING CFECM on(CFECM.case_id=a.case_id and CFECM.VERIFICATION_TYPE_ID='" + obcCLPrinting.Verification_Type_ID + "') " +
                                     " left outer join FE_VW FW on(CFECM.FE_ID=FW.EMP_id)  " +
                                     " WHERE b.VERIFICATION_TYPE_ID='" + obcCLPrinting.Verification_Type_ID + "' AND case_rec_datetime >= '" + obcCLPrinting.Fromdate + "'  and " +
                                     " case_rec_datetime < '" + todate + "' and a.Centre_id = " + obcCLPrinting.Centre_Id + " and  Client_id =" + obcCLPrinting.Client_ID + " " + selectCriteria + " order by FW.fullname ";
                    }
                }
                else
                {
                    lblMsg.Text = "Ensure 100% FE Asssignment for label printing.";
                    l = 1;
                }
                //End of Code for restriction about Supervisor //
              
                using (OleDbConnection con = new OleDbConnection(ConfigurationManager.ConnectionStrings["CMConnectionString"].ConnectionString))
                {
                    //ParameterField p1 = new ParameterField();
                    //ParameterDiscreteValue d1 = new ParameterDiscreteValue();
                    ParameterField p2 = new ParameterField();
                    ParameterDiscreteValue d2 = new ParameterDiscreteValue();
                    ParameterField p3 = new ParameterField();
                    ParameterDiscreteValue d3 = new ParameterDiscreteValue();
                    ParameterFields parcol = new ParameterFields();
                    //p1.Name = "Verification_Type";
                    //d1.Value = Session["Verification_Type"];
                    //p1.CurrentValues.Add(d1);
                    //parcol.Add(p1);

                    p2.Name = "add1";
                    d2.Value = strAdditional1;
                    p2.CurrentValues.Add(d2);
                    parcol.Add(p2);

                    p3.Name = "add2";
                    d3.Value = strAdditional2;
                    p3.CurrentValues.Add(d3);
                    parcol.Add(p3);

                    Session["ParameterCollection"] = parcol;
                    DataSet Ods = new DataSet();
                    con.Open();
                    string str = strSQL;
                    bool flag1 = true;
                    if (l == 0)
                    {
                        OleDbDataAdapter da = new OleDbDataAdapter(str, con);
                        da.Fill(Ods);
                        Ods.Tables[0].TableName = "LblPrinting";
                        Session["dataset"] = Ods;

                        // Added by sandeep khare on date 12-oct-2007
                        if (Session["RoleId"].ToString() == "2")
                        {
                            OleDbDataReader dr;
                            string strquery2 = "";
                            string strCaseID = "";
                            bool flag = false;
                            if (obcCLPrinting.Verification_Type_ID != "3" && obcCLPrinting.Verification_Type_ID != "4")
                            {
                                strquery2 = " select   ccv.case_id from CPV_EBC_VAERIFICATION_TYPE ccv inner join CPV_EBC_CASE_DETAILS cd " +
                                           " on(cd.case_id=ccv.case_id) left  outer join CPV_EBC_FE_MAPPING ccfm " +
                                           " on(ccv.case_id=ccfm.case_id and ccv.verification_type_id=ccfm.verification_type_id) " +
                                           " where ccv.IS_LABLE_PRINT='N' and  ccfm.VERIFICATION_TYPE_ID ='" + obcCLPrinting.Verification_Type_ID + "' AND case_rec_datetime >= '" + obcCLPrinting.Fromdate + "' AND " +
                                           " case_rec_datetime < '" + todate + "' and Centre_id = " + Session["CentreId"].ToString() + " and  Client_id =" + Session["ClientId"].ToString() + " group by ccv.case_id ";
                            }
                            else
                            {
                                strquery2 =   " select   ccv.case_id from CPV_EBC_VAERIFICATION_TYPE ccv inner join CPV_EBC_CASE_DETAILS cd " +
                                              " on(cd.case_id=ccv.case_id) "+
                                              " where ccv.IS_LABLE_PRINT='N' and  ccfm.VERIFICATION_TYPE_ID ='" + obcCLPrinting.Verification_Type_ID + "' AND case_rec_datetime >= '" + obcCLPrinting.Fromdate + "' AND " +
                                              " case_rec_datetime < '" + todate + "' and Centre_id = " + Session["CentreId"].ToString() + " and  Client_id =" + Session["ClientId"].ToString() + " group by ccv.case_id ";
                            }
                            dr = OleDbHelper.ExecuteReader(objconn.ConnectionString, CommandType.Text, strquery2);
                            while (dr.Read())
                            {
                                strCaseID = strCaseID + dr["case_id"].ToString() + ',';
                                flag = true;
                            }
                            dr.Close();

                            if (flag == true)
                            {
                                string strUpdate = "";
                                strUpdate = "update CPV_EBC_VAERIFICATION_TYPE set user_id=" + Session["UserId"].ToString() + " , " +
                                            "IS_LABLE_PRINT ='Y' where IS_LABLE_PRINT = 'N' and VERIFICATION_TYPE_ID=" + obcCLPrinting.Verification_Type_ID + " and case_id in (" + strCaseID.TrimEnd(',') + ")";
                                OleDbHelper.ExecuteNonQuery(objconn.ConnectionString, CommandType.Text, strUpdate);
                            }
                            if (Ods.Tables[0].Rows.Count == 0)
                            {
                                lblMsg.Text = "You are not authorise to reprint the label";
                                flag1 = false;
                            }
                        }
                        if (Ods.Tables[0].Rows.Count == 0 && flag1 == true)
                        {
                            lblMsg.Text = "No record found.";
                            flag1 = false;
                        }
                        // end of Added by sandeep khare on date 12-oct-2007
                        if (flag1 == true)
                        {
                            Session["Path"] = Server.MapPath("CRTest.rpt");
                            Response.Redirect("../../CrystalReportViewer.aspx?bckPgURL=CPV\\EBC\\EBC_LabelPrinting.aspx");
                        }
                    }
                    //Response.Redirect("CC_CrystalReportViewer.aspx?bckPgURL=CPV\\CC\\CC_LabelPrinting.aspx");                                                         
                }
            }
        }
        catch (Exception ex)
        {
            lblMsg.Text = ex.Message.ToString();
           // k = 1;
            
        }
      //  if (k == 1)
       // {
           
      //  }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {

    }
    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("EBC_LabelPrinting.aspx");
    }
}
