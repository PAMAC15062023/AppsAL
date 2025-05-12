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


public partial class CEL_Generate_Label : System.Web.UI.Page
{

    CCommon objconn = new CCommon();
    DataSet ds = new DataSet();
    OleDbDataAdapter da = new OleDbDataAdapter();  
    DataTable d_table = new DataTable();
    protected void Page_Load(object sender, EventArgs e)
    {
            string todate = "";
            int icount = 0;
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
            string fdate = Session["fromdate"].ToString();
            string tdate = Session["todate"].ToString();
            DataSet dsLabelQuery = new DataSet();
            dsLabelQuery = obcCLPrinting.getTemplate();
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
                               strSQL = strSQL+ "+Convert(varchar(24), ' '+ISNULL(" + dsLabelQuery.Tables[0].Rows[i]["SELECTED_FIELD"].ToString() + ",''))";
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
                            if(flage==false)
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
                 else if (dsLabelQuery.Tables[0].Rows.Count == 0)
                 {
                        icount = 1;
                 }
              }               
                catch(Exception ex)
                {
                    lblMsg.Text = ex.Message.ToString();
                }
                if (icount == 1)
                {
                    Response.Redirect("CEL_LabelPrinting.aspx?Message=No Template Found !!&FromDt=" + fdate + "&ToDt=" + tdate + " ");
                }
                using (OleDbConnection con = new OleDbConnection(ConfigurationManager.ConnectionStrings["CMConnectionString"].ConnectionString))
                   {
                       strSQL = strSQL + "," + "CUSTOMER_CLASS,CONVERT(VARCHAR(24),CASE_REC_DATETIME,103) AS CASE_REC_DATETIME,CELL_ACTIVATED_DATE AS CELL_ACTIVATED_DATE,CPV_CELLULAR_CASE_TYPE_MASTER.CASE_TYPE_CODE,CELLNO,CPV_CELLULAR_CUSTOMER_CLASS_MASTER.CUSTOMER_CLASS_CODE,SR_NO,A.CASE_ID ";
                       //Code for restriction about Supervisor //
                      string strquery1 = "";
               
                string selectCriteria = "";

                string strResult = "";
                string strCaseID1="";
                string strFEAssi = "";

///////////////////////add by santosh shelar 28-08-08//////////////////////////
            //    strFEAssi = " select case (select count(*) from CPV_CELLULAR_CASE_VERIFICATIONTYPE ccv inner join CPV_CELLULAR_CASES cd  on(cd.case_id=ccv.case_id) where  cd.CASE_REC_DATETIME >='" + obcCLPrinting.Fromdate + "' and cd.CASE_REC_DATETIME<'" + todate + "' and cd.CASE_REC_DATETIME<'" + todate + "' and cd.Centre_id = " + obcCLPrinting.Centre_Id + " and  cd.Client_id =" + obcCLPrinting.Client_ID + ")  " +
              //                  " when (select count(*) from CPV_CELLULAR_FE_CASE_MAPPING ccf left outer join CPV_CELLULAR_CASES cd on (ccf.case_id=cd.case_id)  where  cd.CASE_REC_DATETIME >='" + obcCLPrinting.Fromdate + "' and cd.CASE_REC_DATETIME<'" + todate + "' and cd.CASE_REC_DATETIME<'" + todate + "' and cd.Centre_id = " + obcCLPrinting.Centre_Id + " and  cd.Client_id =" + obcCLPrinting.Client_ID + ") " +
                //                " then 'true' else 'false' end  as Result";

                strFEAssi = "select case(select count(*) from cpv_cellular_case_verificationtype a,cpv_cellular_cases b where a.case_id=b.case_id " +
                            "and  b.case_rec_datetime>='" + obcCLPrinting.Fromdate + "' and b.case_rec_datetime<'" + todate + "' and b.centre_id=" + obcCLPrinting.Centre_Id + " and b.client_id=" + obcCLPrinting.Client_ID + ")when " +
                            "(select count(*) from cpv_cellular_case_verificationtype c,cpv_cellular_cases d where c.case_id=d.case_id and d.case_rec_datetime>='" + obcCLPrinting.Fromdate + "' and d.case_rec_datetime<'" + todate + "' and " +
                            "d.centre_id=" + obcCLPrinting.Centre_Id + " and client_id=" + obcCLPrinting.Client_ID + ")then 'true' else 'false' end as Result";
                    strResult = (string)(OleDbHelper.ExecuteScalar(objconn.ConnectionString, CommandType.Text, strFEAssi));
                              
                int k = 0;
               
                if (strResult == "true")
                {

                    if (Session["RoleId"].ToString() == "2")
                    {
                        strquery1 = "select count(*) from CPV_CELLULAR_CASE_VERIFICATIONTYPE where  IS_LABLE_PRINT='N' ";
                        object o = OleDbHelper.ExecuteScalar(objconn.ConnectionString, CommandType.Text, strquery1);
                        if (Convert.ToInt32(o) != 0)
                        {
                            selectCriteria = " AND B.IS_LABLE_PRINT='N'";
                        }

                        strSQL = " SELECT FW.fullname as fe_name,(FW.fullname +'-'+ FW.EMP_CODE) as fe_code,dbo.GetPrBarCode(" + Session["ProductId"].ToString() + ")+a.case_id+dbo.GetVeriBarCode('1') as BrCode, " +
                                " (a.case_id +'~'+'" + obcCLPrinting.Verification_Type_ID + "' +'~'+'" + Session["ProductId"].ToString() + "'+'~'+'" + Session["ClientId"].ToString() + "') as BarCode, " + strSQL + " FROM " + strTableName + " A INNER JOIN CPV_CELLULAR_CASE_VERIFICATIONTYPE B ON A.CASE_ID=B.CASE_ID " +
                                " INNER JOIN CPV_CELLULAR_CASE_TYPE_MASTER ON A.CASE_TYPE_ID = CPV_CELLULAR_CASE_TYPE_MASTER.CASE_TYPE_ID LEFT OUTER JOIN CPV_CELLULAR_CUSTOMER_CLASS_MASTER ON " +
                                " A.CUSTOMER_CLASS = CPV_CELLULAR_CUSTOMER_CLASS_MASTER.CUSTOMER_CLASS_NAME INNER JOIN CPV_CELLULAR_CASE_VERIFICATIONTYPE ON A.CASE_ID = CPV_CELLULAR_CASE_VERIFICATIONTYPE.CASE_ID " +
                                " left outer join CPV_CELLULAR_FE_CASE_MAPPING CFECM on(CFECM.case_id=a.case_id and CFECM.VERIFICATION_TYPE_ID='1') " +
                                " left outer join FE_VW FW on(CFECM.FE_ID=FW.EMP_id)  " +
                                " WHERE A.CASE_TYPE_ID='" + obcCLPrinting.Verification_Type_ID + "' AND case_rec_datetime >= '" + obcCLPrinting.Fromdate + "'  " +
                                " AND case_rec_datetime <  '" + todate + "' and A.CENTRE_ID = " + obcCLPrinting.Centre_Id + " and  A.CLIENT_ID =" + obcCLPrinting.Client_ID + " " + selectCriteria + " order by FW.fullname";
                    }
                    else
                    {
                        strSQL = " SELECT FW.fullname as fe_name,(FW.fullname +'-'+ FW.EMP_CODE) as fe_code,dbo.GetPrBarCode(" + Session["ProductId"].ToString() + ")+a.case_id+dbo.GetVeriBarCode('1') as BrCode, " +
                                 " (a.case_id +'~'+'" + obcCLPrinting.Verification_Type_ID + "' +'~'+'" + Session["ProductId"].ToString() + "'+'~'+'" + Session["ClientId"].ToString() + "') as BarCode, " + strSQL + " FROM " + strTableName + " A INNER JOIN CPV_CELLULAR_CASE_VERIFICATIONTYPE B ON A.CASE_ID=B.CASE_ID " +
                                 " INNER JOIN CPV_CELLULAR_CASE_TYPE_MASTER ON A.CASE_TYPE_ID = CPV_CELLULAR_CASE_TYPE_MASTER.CASE_TYPE_ID LEFT OUTER JOIN CPV_CELLULAR_CUSTOMER_CLASS_MASTER ON " +
                                 " A.CUSTOMER_CLASS = CPV_CELLULAR_CUSTOMER_CLASS_MASTER.CUSTOMER_CLASS_NAME INNER JOIN CPV_CELLULAR_CASE_VERIFICATIONTYPE ON A.CASE_ID = CPV_CELLULAR_CASE_VERIFICATIONTYPE.CASE_ID " +
                                 " left outer join CPV_CELLULAR_FE_CASE_MAPPING CFECM on(CFECM.case_id=a.case_id and CFECM.VERIFICATION_TYPE_ID='1') " +
                                 " left outer join FE_VW FW on(CFECM.FE_ID=FW.EMP_id)  " +
                                 " WHERE A.CASE_TYPE_ID='" + obcCLPrinting.Verification_Type_ID + "' AND case_rec_datetime >= '" + obcCLPrinting.Fromdate + "' " +
                                 " AND case_rec_datetime <  '" + todate + "' and A.CENTRE_ID = " + obcCLPrinting.Centre_Id + " and  A.CLIENT_ID =" + obcCLPrinting.Client_ID;

                    }
                }
                else
                {
                    lblMsg.Text = "Ensure 100% FE Asssignment for label printing.";
                    k = 1;
                }
                       //End of Code for restriction about Supervisor //

                      
                     
                        DataSet Ods = new DataSet();
                        con.Open();
                        string str = strSQL;
                        bool flag1 = true;
                        if (k == 0)
                        {
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
                            // Added by sandeep khare on date 12-oct-2007
                            if (Session["RoleId"].ToString() == "2")
                            
                            {
                                OleDbDataReader dr;
                                string strquery2 = "";
                                string strCaseID = "";
                                bool flag = false;
                                
                                    strquery2 = " select   ccv.case_id from CPV_CELLULAR_CASE_VERIFICATIONTYPE ccv inner join CPV_CELLULAR_CASES cd " +
                                                " on(cd.case_id=ccv.case_id) left  outer join CPV_CELLULAR_FE_CASE_MAPPING ccfm " +
                                                " on(ccv.case_id=ccfm.case_id and ccv.verification_type_id=ccfm.verification_type_id) " +
                                                " where ccv.IS_LABLE_PRINT='N' and   case_rec_datetime >= '" + obcCLPrinting.Fromdate + "' AND " +
                                                " case_rec_datetime < '" + todate + "' and Centre_id = " + Session["CentreId"].ToString() + " and  Client_id =" + Session["ClientId"].ToString() + " group by ccv.case_id ";
                                
                               
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
                                    strUpdate = "update CPV_CELLULAR_CASE_VERIFICATIONTYPE set user_id=" + Session["UserId"].ToString() + " , " +
                                                "IS_LABLE_PRINT ='Y' where IS_LABLE_PRINT = 'N' and case_id in (" + strCaseID.TrimEnd(',') + ")";
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
                                Session["Path"] = Server.MapPath("rpt_Cellular.rpt");
                                Response.Redirect("../../CrystalReportViewer.aspx?bckPgURL=CPV\\Cellular\\CEL_LabelPrinting.aspx");
                            }
                        }
                                                                               
                    }                    
                }
             }
    protected void btBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("CEL_LabelPrinting.aspx");
    }
}                     
 
    
    



