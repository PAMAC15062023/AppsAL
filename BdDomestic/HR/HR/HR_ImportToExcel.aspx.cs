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
using System.IO;
using System.Text;
using System.Configuration.Assemblies;
using Microsoft.Office.Core;
using CrystalDecisions.Shared;
using System.Data.SqlTypes; 

public partial class HR_HR_HR_ImportToExcel : System.Web.UI.Page
{
    //static string strConn = @"Data Source=BIPIN\SQLEXPRESS;Initial Catalog=TestDataBase;Integrated Security=True";
    //string strConn = ConfigurationManager.AppSettings["ConnString"].ToString();
    //SqlConnection sqlConn = new SqlConnection(strConn);    

    CHR_ImportToExcel objImportToExcel = new CHR_ImportToExcel();
    CCommon objComm = new CCommon();
   
    
  
    
    protected void Page_Load(object sender, EventArgs e)
    {
         

    }
     private DataSet GetExcelFileData()
    {
        
         String strConn;

         String strFile = HttpContext.Current.Server.MapPath("../../HRImport/");
         strConn = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + strFile + FileUpload1.FileName+ @";Extended Properties=""Excel 8.0;IMEX=1""";
       

        DataSet ds = new DataSet();
        //you reference in the spreadsheet
        OleDbDataAdapter da = new OleDbDataAdapter("SELECT * FROM [Sheet1$]", strConn);
        //da.TableMappings.Add("Table", "ExcelTest");

        da.Fill(ds);
        return ds;
    }

    //private bool CheckFirstUser()
    //{
    //    bool chkUser = false;
    //    try
    //    {
    //        string strChkEmp = "SELECT COUNT(EMP_CODE) FROM EMPLOYEE_MASTER";
    //        SqlCommand sqlCmd = new SqlCommand(strChkEmp, sqlConn);

    //        sqlConn.Open();
    //        int i = (int)sqlCmd.ExecuteScalar();
    //        sqlConn.Close();

    //        if (i > 0)
    //        {
    //            chkUser = true;
    //        }
    //    }
    //    catch (Exception ex)
    //    {
    //        string strMessage = ex.Message;
    //    }
    //    return chkUser;
    //}

    //private string SelMaxEmpId()
    //{
    //    string strEmpMaxId = "";
    //    try
    //    {
    //        bool chkUser = (bool)CheckFirstUser();
    //        if (chkUser == true)
    //        {
    //            string strSqlMaxId = "SELECT MAX(EMP_ID) FROM EMPLOYEE_MASTER";
    //            SqlCommand sqlCmd = new SqlCommand(strSqlMaxId, sqlConn);

    //            sqlConn.Open();
    //            strEmpMaxId = sqlCmd.ExecuteScalar().ToString();
    //            sqlConn.Close();
    //        }
    //        else
    //        {
    //            strEmpMaxId = "1010";
    //        }

    //    }
    //    catch (Exception ex)
    //    {
    //        string strMessage = ex.Message;
    //    }
    //    return strEmpMaxId;

    //}

    //private DataSet CheckEmpExistence(string strEmpCode)
    //{
    //    DataSet ds = null;
    //    try
    //    {
    //        string strSqlSelectEmp = "SELECT EMP_ID FROM EMPLOYEE_MASTER WHERE EMP_CODE='" + strEmpCode + "'";
    //        SqlDataAdapter sqlDa = new SqlDataAdapter(strSqlSelectEmp, sqlConn);
    //        ds = new DataSet();
    //        sqlDa.Fill(ds, "EMPLOYEE_MASTER");
    //    }
    //    catch (Exception ex)
    //    {
    //        string strMessage = ex.Message;
    //    }
    //    return ds;
    //}

    //private string CreateCustomeEmpId(string strCustID)
    //{
    //    string strCustId = "";
    //    try
    //    {
    //        if (strCustID != "")
    //        {
    //            string strPrifix = strCustID.Substring(0, 3).ToString();
    //            string strSufix = strCustID.Substring(3).ToString();

    //            strCustId = strPrifix + (Convert.ToInt64(strSufix) + 1);
    //        }
    //    }
    //    catch (Exception ex)
    //    {
    //        string strMessage = ex.Message;
    //    }
    //    return strCustId;
    //}

    
    protected void btnImport_Click(object sender, EventArgs e)
    {
        #region CurrentCode 1
        OleDbConnection sqlConn = new OleDbConnection(objComm.ConnectionString);
        int i = 0;
        try
        {
            lblMessage.Text = "";
            //string strFile = FileUpload1.FileName.ToString();
            if (FileUpload1.HasFile)
            {

                String strSql = "";
                String strPath = "";
                String MyFile = "";


                //to get the file extention
                String strFileName = FileUpload1.FileName.ToString();

                FileInfo fi = new FileInfo(strFileName);
                String strExt = fi.Extension;

                if (strExt.ToLower() == ".xls")
                {
                    //Uploading file start.
                    strPath = Server.MapPath("../../HRImport/");

                    strPath = strPath + FileUpload1.FileName;
                    FileUpload1.PostedFile.SaveAs(strPath);
                }


                DataSet ds = (DataSet)GetExcelFileData();
                DataSet dsEmp = null;
                GridView1.DataSource = ds.Tables[0].DefaultView;
                GridView1.DataBind();


                if (ds.Tables[0].Rows.Count > 0)
                {
                    for (i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        if ((ds.Tables[0].Rows[i]["PAMACian Code"].ToString() != "") || (ds.Tables[0].Rows[i]["PAMACian Code"].ToString() == null))
                        {
                            string strEmpCode = ds.Tables[0].Rows[i]["PAMACian Code"].ToString();
                            string strEmpName = ds.Tables[0].Rows[i]["PAMACian Name"].ToString().Trim();
                            string strAddress = ds.Tables[0].Rows[i]["Present Address"].ToString().Trim();
                            string strAddPermanent = ds.Tables[0].Rows[i]["Permanent Address"].ToString().Trim();

                            dsEmp = new DataSet();
                            dsEmp = (DataSet)objImportToExcel.CheckEmpExistence(strEmpCode);//Check if Employee already registered.

                            OleDbCommand sqlCmd = null;

                            string strEmpId = "";
                            string strMode = "";
                            string strFirstName = "";
                            string strMiddleName = "";
                            string strLastName = "";

                            string strADD1 = "";
                            string strADD2 = "";
                            string strADD3 = "";

                            string strPR_ADD1 = "";
                            string strPR_ADD2 = "";
                            string strPR_ADD3 = "";

                            string[] strNameArray = strEmpName.Split(' ');//name
                            string[] strAddressArray = strAddress.Split(',');//address
                            string[] strPermanentAddressArray = strAddPermanent.Split(',');//Permanent address

                            for (int k = 0; k < strNameArray.Length; k++)
                            {
                                if (k == 0)
                                {
                                    strFirstName = strNameArray[k].Trim();

                                }
                                if (k == 1)
                                {
                                    strMiddleName = strNameArray[k].Trim();

                                }
                                if (k == 2)
                                {
                                    strLastName = strNameArray[k].Trim();

                                    break;
                                }
                            }

                            for (int k1 = 0; k1 < strAddressArray.Length; k1++)
                            {
                                if (k1 == 0)
                                {
                                    strADD1 = strAddressArray[k1].Trim();
                                }
                                if (k1 == 1)
                                {
                                    strADD2 = strAddressArray[k1].Trim();
                                }
                                if (k1 == 2)
                                {
                                    strADD3 = strAddressArray[k1].Trim();
                                    break;
                                }
                            }
                            for (int k2 = 0; k2 < strPermanentAddressArray.Length; k2++)
                            {
                                if (k2 == 0)
                                {
                                    strPR_ADD1 = strPermanentAddressArray[k2].Trim();
                                }
                                if (k2 == 1)
                                {
                                    strPR_ADD2 = strPermanentAddressArray[k2].Trim();
                                }
                                if (k2 == 2)
                                {
                                    strPR_ADD3 = strPermanentAddressArray[k2].Trim();
                                    break;
                                }
                            }
                            if (dsEmp.Tables[0].Rows.Count > 0)
                            {
                                strEmpId = dsEmp.Tables[0].Rows[0]["EMP_ID"].ToString();//if employee alredy there select EMP_ID with respect to Emp_code
                                strMode = "U";// If employee already there then set mode for update
                            }
                            else
                            {
                                //string strMaxValue = objImportToExcel.SelMaxEmpId();
                                strEmpId = objComm.GetUniqueID("EMPLOYEE_MASTER", "101").ToString();//if new employee then set EMP_ID with respect to Emp_code
                                strMode = "I";// If employee not already there then set mode for Insert
                            }
                            string strNameOfBank = ds.Tables[0].Rows[i]["Name OF Bank"].ToString();
                            string strSuvidhaAc = ds.Tables[0].Rows[i]["A/C#"].ToString();
                            string strPAN = ds.Tables[0].Rows[i]["PAN#"].ToString();
                            string strFatherName = ds.Tables[0].Rows[i]["Father's Name"].ToString();
                            //DateTime DOB = Convert.ToDateTime(ds.Tables[0].Rows[i]["DOB"].ToString());
                            //DateTime DOB = Convert_mm_dd_yy(ds.Tables[0].Rows[i]["DOB"].ToString());
                            DateTime DOB = Convert.ToDateTime(ds.Tables[0].Rows[i]["DOB"].ToString());
                            string strPHONE_R = ds.Tables[0].Rows[i]["Tel No#Of Present Address"].ToString();
                            //New added
                            string strCITY = ds.Tables[0].Rows[i]["City"].ToString();
                            string strPIN = ds.Tables[0].Rows[i]["Pin Code"].ToString();

                            string strPermanentPhone = ds.Tables[0].Rows[i]["Tel No#Permanent Address"].ToString();

                            string strHEIGHT = ds.Tables[0].Rows[i]["Height"].ToString();
                            string strWEIGHT = ds.Tables[0].Rows[i]["Weight"].ToString();
                            string strBLOOD_GROUP = ds.Tables[0].Rows[i]["Blood Group"].ToString();
                            string strGENDER = ds.Tables[0].Rows[i]["Sex"].ToString();
                            string strMARTAL_STATUS = ds.Tables[0].Rows[i]["Marital Status"].ToString();
                            string strWIFE_NAME = ds.Tables[0].Rows[i]["(If Married) Wife Name"].ToString();
                            string strWIFE_AGE = ds.Tables[0].Rows[i]["Wife Age"].ToString();
                            //DateTime DOJ = Convert_mm_dd_yy(ds.Tables[0].Rows[i]["Date of Joining"].ToString());
                            DateTime DOJ = Convert.ToDateTime(ds.Tables[0].Rows[i]["Date of Joining"].ToString());
                            //Added New
                            DateTime DOL;
                            if ((ds.Tables[0].Rows[i]["Date of Leaving"].ToString() != "") && (ds.Tables[0].Rows[i]["Date of Leaving"].ToString() != null))
                            {
                                DOL = Convert.ToDateTime(ds.Tables[0].Rows[i]["Date of Leaving"].ToString());
                            }
                            else
                                DOL = Convert_mm_dd_yy("01/01/1900");
                            //DOL = "01/01/1900";
                            //DOL = Convert_mm_dd_yy(ds.Tables[0].Rows[i]["Date of Leaving"].ToString());


                            string strDESIGNATION = ds.Tables[0].Rows[i]["Designation"].ToString();
                            //Added New
                            string strDEPARTMENT = ds.Tables[0].Rows[i]["Department"].ToString();
                            string strCENTRE_NAME = ds.Tables[0].Rows[i]["Centre Name"].ToString();
                            string strSUBCENTRE_NAME = ds.Tables[0].Rows[i]["Sub Centre Name"].ToString();
                            string strCLIENT_NAME = ds.Tables[0].Rows[i]["Client Name"].ToString();
                            string strPRODUCT_NAME = ds.Tables[0].Rows[i]["Product Name"].ToString();
                            string strACTIVITY_NAME = ds.Tables[0].Rows[i]["Unit"].ToString();
                            string strCOMPANY_NAME = ds.Tables[0].Rows[i]["Company Code"].ToString();
                            string strAPPROVAL_MAIL_DATE = ds.Tables[0].Rows[i]["Approval Mail Date"].ToString();
                            string strAPPROVED_BY_OTHER = ds.Tables[0].Rows[i]["Approved By"].ToString();
                            string strUSER_ID_ACTIVITYMANAGER = ds.Tables[0].Rows[i]["PAMACian Activity Manager Code"].ToString();

                            string strUSERID_OF_CLUSTER = ds.Tables[0].Rows[i]["PAMACian Cluster HR Code"].ToString();


                            string strKIT_RECEIVED_DATE = ds.Tables[0].Rows[i]["Kit Received Date"].ToString();
                            string strUSERID_OF_HO = ds.Tables[0].Rows[i]["Verified And Updated By"].ToString();//REMOVE SPACE

                            string strVerified_and_updated_on_dtd = ds.Tables[0].Rows[i]["Verified and updated on dtd#"].ToString();//REMOVE SPACE
                            /*string strLANGUAGE_KNOWN = ds.Tables[0].Rows[i]["Language Known"].ToString();*/

                            string strRELATION_WITH_EMPLOYEE = ds.Tables[0].Rows[i]["Are Related To Any PAMACian"].ToString();
                            string strRELATION_NAME_WITH_EMPLOYEE = ds.Tables[0].Rows[i]["(If Related To Any  PAMACian Then) Relationship"].ToString();

                            string strRELATIVE_NAME = ds.Tables[0].Rows[i]["(If Related To Any  PAMACian Then) PAMACian Name"].ToString();
                            string strRELATIVE_CODE = ds.Tables[0].Rows[i]["(If Related To Any  PAMACian Then) PAMACian Code"].ToString();

                            string strCOURT_PROCEEDING = ds.Tables[0].Rows[i]["Have Been Involved In Any Court Proceeding"].ToString();
                            string strDETAIL_OF_COURT_PROCEEDING = ds.Tables[0].Rows[i]["(If Yes Then )Court Proceeding Details"].ToString();

                            string strCONTAGIOUS_DISEASE = ds.Tables[0].Rows[i]["Have Suffered Any Contagious Disease"].ToString();
                            string strCONTAGIOUS_DISEASE_DETAIL = ds.Tables[0].Rows[i]["(If Yes Then)Contagious Disease Detail"].ToString();
                            string strNOMINEE_NAME = ds.Tables[0].Rows[i]["Nominee Name"].ToString();

                            string strTYPE_OF_CATEGORY = ds.Tables[0].Rows[i]["Type Of Category"].ToString();

                            /*-------------------2-EMPLOYEE_CHILDREN_DETAIL--------------------*/
                            string strCHILDNAME1 = ds.Tables[0].Rows[i]["Child Name1"].ToString();
                            string strAge1 = ds.Tables[0].Rows[i]["Child Age1"].ToString();
                            string strCHILDNAME2 = ds.Tables[0].Rows[i]["Child Name2"].ToString();
                            string strAge2 = ds.Tables[0].Rows[i]["Child Age2"].ToString();

                            /*--------------------3-EMPLOYEE_EDUCATION_QUALIFICATION------------*/
                            string strNameOfCollegeInstitution1 = ds.Tables[0].Rows[i]["Name Of College Institution1"].ToString();
                            string strNameOfCollegeInstitution2 = ds.Tables[0].Rows[i]["Name Of College Institution2"].ToString();
                            string strNameOfCollegeInstitution3 = ds.Tables[0].Rows[i]["Name Of College Institution3"].ToString();

                            string strFrom_To_Year1 = ds.Tables[0].Rows[i]["From_To_Year1"].ToString();
                            string strFrom_To_Year2 = ds.Tables[0].Rows[i]["From_To_Year2"].ToString();
                            string strFrom_To_Year3 = ds.Tables[0].Rows[i]["From_To_Year3"].ToString();

                            string strCertificateExamination1 = ds.Tables[0].Rows[i]["Certificate Examination1"].ToString();
                            string strCertificateExamination2 = ds.Tables[0].Rows[i]["Certificate Examination2"].ToString();
                            string strCertificateExamination3 = ds.Tables[0].Rows[i]["Certificate Examination3"].ToString();

                            /*string strQualificationType1 = ds.Tables[0].Rows[i]["QualificationType1"].ToString();
                            string strQualificationType2 = ds.Tables[0].Rows[i]["QualificationType2"].ToString();
                            string strQualificationType3 = ds.Tables[0].Rows[i]["QualificationType3"].ToString();*/

                            string strDivMarks1 = ds.Tables[0].Rows[i]["Div/Marks1"].ToString();
                            string strDivMarks2 = ds.Tables[0].Rows[i]["Div/Marks2"].ToString();
                            string strDivMarks3 = ds.Tables[0].Rows[i]["Div/Marks3"].ToString();

                            string strCopyAttached1 = ds.Tables[0].Rows[i]["Copy Attached1"].ToString();
                            string strCopyAttached2 = ds.Tables[0].Rows[i]["Copy Attached2"].ToString();
                            string strCopyAttached3 = ds.Tables[0].Rows[i]["Copy Attached3"].ToString();

                            /*string strProfessional_NameofCollegeInstitution1 = ds.Tables[0].Rows[i]["Professional_Name of College Institution1"].ToString();*/
                            string strProfessional_From_To_Year1 = ds.Tables[0].Rows[i]["Professional_From_To_Year1"].ToString();
                            string strProfessional_CertificateExamination1 = ds.Tables[0].Rows[i]["Professional_Certificate Examination1"].ToString();
                            /*string strProfessional_QualificationType1 = ds.Tables[0].Rows[i]["Professional_QualificationType1"].ToString();*/
                            string strProfessional_DivMarks1 = ds.Tables[0].Rows[i]["Professional_Div/Marks1"].ToString();
                            string strProfessional_CopyAttached1 = ds.Tables[0].Rows[i]["Professional_Copy Attached1"].ToString();

                            /*----------------4-EMPLOYEE_EMPLOYMENT_DETAIL-------*/
                            string strEmployer_Name = ds.Tables[0].Rows[i]["Employers Name & Address"].ToString();
                            string strDuration_of_Employment = ds.Tables[0].Rows[i]["Employed From-To"].ToString();
                            string strSalary = ds.Tables[0].Rows[i]["Salary"].ToString();
                            string strReason_of_Leaving = ds.Tables[0].Rows[i]["Reason For Leaving"].ToString();
                            string strDesignation_Nature_job = ds.Tables[0].Rows[i]["Designation And Nature Of Job"].ToString();
                            string strContact_No = ds.Tables[0].Rows[i]["Contact No Of Employer"].ToString();



                            /*-----------------5-EMPLOYEE_HOBBY------------------*/
                            string strLiterary_Cultural_Art = ds.Tables[0].Rows[i]["Literary / Cultural / Art"].ToString();
                            string strSports = ds.Tables[0].Rows[i]["Sports"].ToString();
                            string strHobbies = ds.Tables[0].Rows[i]["Hobbies"].ToString();
                            /*-----------------6-EMPLOYEE_REFERENCE_DETAIL--------*/
                            string strReferenceName1 = ds.Tables[0].Rows[i]["Reference Name1"].ToString();
                            string strReferenceName2 = ds.Tables[0].Rows[i]["Reference Name2"].ToString();
                            string strReferenceAddress1 = ds.Tables[0].Rows[i]["Reference Address2"].ToString();
                            string strReferenceAddress2 = ds.Tables[0].Rows[i]["Reference Address2"].ToString();
                            string strRelationWithReference1 = ds.Tables[0].Rows[i]["Relation With Reference1"].ToString();
                            string strRelationWithReference2 = ds.Tables[0].Rows[i]["Relation With Reference2"].ToString();
                            string strOccupationOfReference1 = ds.Tables[0].Rows[i]["Occupation Of Reference1"].ToString();
                            string strOccupationOfReference2 = ds.Tables[0].Rows[i]["Occupation Of Reference2"].ToString();
                            string strContactNoOfReference1 = ds.Tables[0].Rows[i]["Contact No Of Reference1"].ToString();
                            string strContactNoOfReference2 = ds.Tables[0].Rows[i]["Contact No Of Reference2"].ToString();

                            /*----------------7-EMPLOYEE_SALARY_DETAIL-----------*/
                            string strBasic = ds.Tables[0].Rows[i]["Basic"].ToString();
                            string strHRA = ds.Tables[0].Rows[i]["HRA"].ToString();
                            string strSP_All = ds.Tables[0].Rows[i]["SP Allowance"].ToString();
                            string strGross_Amt = ds.Tables[0].Rows[i]["Gross Amt"].ToString();

                            string strSpName = "AddEditEmployeeInformation";

                            sqlCmd = new OleDbCommand(strSpName, sqlConn);
                            sqlCmd.CommandType = CommandType.StoredProcedure;

                            sqlCmd.Parameters.Add("@Mode", SqlDbType.VarChar);
                            sqlCmd.Parameters["@Mode"].Value = strMode;
                            sqlCmd.Parameters["@Mode"].Direction = ParameterDirection.Input;

                            sqlCmd.Parameters.Add("@EMP_ID", SqlDbType.VarChar);
                            sqlCmd.Parameters["@EMP_ID"].Value = strEmpId;
                            sqlCmd.Parameters["@EMP_ID"].Direction = ParameterDirection.Input;

                            sqlCmd.Parameters.Add("@EMP_CODE", SqlDbType.VarChar);
                            sqlCmd.Parameters["@EMP_CODE"].Value = strEmpCode;
                            sqlCmd.Parameters["@EMP_CODE"].Direction = ParameterDirection.Input;

                            sqlCmd.Parameters.Add("@FIRSTNAME", SqlDbType.VarChar);
                            sqlCmd.Parameters["@FIRSTNAME"].Value = strFirstName;
                            sqlCmd.Parameters["@FIRSTNAME"].Direction = ParameterDirection.Input;

                            sqlCmd.Parameters.Add("@MIDDLENAME", SqlDbType.VarChar);
                            sqlCmd.Parameters["@MIDDLENAME"].Value = strMiddleName;
                            sqlCmd.Parameters["@MIDDLENAME"].Direction = ParameterDirection.Input;

                            sqlCmd.Parameters.Add("@LASTNAME", SqlDbType.VarChar);
                            sqlCmd.Parameters["@LASTNAME"].Value = strLastName;
                            sqlCmd.Parameters["@LASTNAME"].Direction = ParameterDirection.Input;

                            sqlCmd.Parameters.Add("@NAME_OF_BANK", SqlDbType.VarChar);
                            sqlCmd.Parameters["@NAME_OF_BANK"].Value = strNameOfBank;
                            sqlCmd.Parameters["@NAME_OF_BANK"].Direction = ParameterDirection.Input;

                            sqlCmd.Parameters.Add("@SUVIDHA_AC", SqlDbType.VarChar);
                            sqlCmd.Parameters["@SUVIDHA_AC"].Value = strSuvidhaAc;
                            sqlCmd.Parameters["@SUVIDHA_AC"].Direction = ParameterDirection.Input;

                            sqlCmd.Parameters.Add("@PAN#", SqlDbType.VarChar);
                            sqlCmd.Parameters["@PAN#"].Value = strPAN;
                            sqlCmd.Parameters["@PAN#"].Direction = ParameterDirection.Input;

                            sqlCmd.Parameters.Add("@FATHER_NAME", SqlDbType.VarChar);
                            sqlCmd.Parameters["@FATHER_NAME"].Value = strFatherName;
                            sqlCmd.Parameters["@FATHER_NAME"].Direction = ParameterDirection.Input;

                            sqlCmd.Parameters.Add("@DOB", SqlDbType.DateTime);
                            sqlCmd.Parameters["@DOB"].Value = DOB;
                            sqlCmd.Parameters["@DOB"].Direction = ParameterDirection.Input;

                            sqlCmd.Parameters.Add("@ADD1", SqlDbType.VarChar);
                            sqlCmd.Parameters["@ADD1"].Value = strADD1;
                            sqlCmd.Parameters["@ADD1"].Direction = ParameterDirection.Input;

                            sqlCmd.Parameters.Add("@ADD2", SqlDbType.VarChar);
                            sqlCmd.Parameters["@ADD2"].Value = strADD2;
                            sqlCmd.Parameters["@ADD2"].Direction = ParameterDirection.Input;

                            sqlCmd.Parameters.Add("@ADD3", SqlDbType.VarChar);
                            sqlCmd.Parameters["@ADD3"].Value = strADD3;
                            sqlCmd.Parameters["@ADD3"].Direction = ParameterDirection.Input;

                            sqlCmd.Parameters.Add("@PHONE_R", SqlDbType.VarChar);
                            sqlCmd.Parameters["@PHONE_R"].Value = strPHONE_R;
                            sqlCmd.Parameters["@PHONE_R"].Direction = ParameterDirection.Input;

                            sqlCmd.Parameters.Add("@CITY", SqlDbType.VarChar);
                            sqlCmd.Parameters["@CITY"].Value = strCITY;
                            sqlCmd.Parameters["@CITY"].Direction = ParameterDirection.Input;

                            sqlCmd.Parameters.Add("@PIN", SqlDbType.VarChar);
                            sqlCmd.Parameters["@PIN"].Value = strPIN;
                            sqlCmd.Parameters["@PIN"].Direction = ParameterDirection.Input;

                            sqlCmd.Parameters.Add("@PR_ADD1", SqlDbType.VarChar);
                            sqlCmd.Parameters["@PR_ADD1"].Value = strPR_ADD1;
                            sqlCmd.Parameters["@PR_ADD1"].Direction = ParameterDirection.Input;

                            sqlCmd.Parameters.Add("@PR_ADD2", SqlDbType.VarChar);
                            sqlCmd.Parameters["@PR_ADD2"].Value = strPR_ADD2;
                            sqlCmd.Parameters["@PR_ADD2"].Direction = ParameterDirection.Input;

                            sqlCmd.Parameters.Add("@PR_ADD3", SqlDbType.VarChar);
                            sqlCmd.Parameters["@PR_ADD3"].Value = strPR_ADD3;
                            sqlCmd.Parameters["@PR_ADD3"].Direction = ParameterDirection.Input;

                            sqlCmd.Parameters.Add("@PHONE_PERMAENT_ADD", SqlDbType.VarChar);
                            sqlCmd.Parameters["@PHONE_PERMAENT_ADD"].Value = strPermanentPhone;
                            sqlCmd.Parameters["@PHONE_PERMAENT_ADD"].Direction = ParameterDirection.Input;

                            sqlCmd.Parameters.Add("@HEIGHT", SqlDbType.VarChar);
                            sqlCmd.Parameters["@HEIGHT"].Value = strHEIGHT;
                            sqlCmd.Parameters["@HEIGHT"].Direction = ParameterDirection.Input;

                            sqlCmd.Parameters.Add("@WEIGHT", SqlDbType.VarChar);
                            sqlCmd.Parameters["@WEIGHT"].Value = strWEIGHT;
                            sqlCmd.Parameters["@WEIGHT"].Direction = ParameterDirection.Input;

                            sqlCmd.Parameters.Add("@BLOOD_GROUP", SqlDbType.VarChar);
                            sqlCmd.Parameters["@BLOOD_GROUP"].Value = strBLOOD_GROUP;
                            sqlCmd.Parameters["@BLOOD_GROUP"].Direction = ParameterDirection.Input;

                            sqlCmd.Parameters.Add("@GENDER", SqlDbType.VarChar);
                            sqlCmd.Parameters["@GENDER"].Value = strGENDER;
                            sqlCmd.Parameters["@GENDER"].Direction = ParameterDirection.Input;

                            sqlCmd.Parameters.Add("@MARTAL_STATUS", SqlDbType.VarChar);
                            sqlCmd.Parameters["@MARTAL_STATUS"].Value = strMARTAL_STATUS;
                            sqlCmd.Parameters["@MARTAL_STATUS"].Direction = ParameterDirection.Input;

                            sqlCmd.Parameters.Add("@WIFE_NAME", SqlDbType.VarChar);
                            sqlCmd.Parameters["@WIFE_NAME"].Value = strWIFE_NAME;
                            sqlCmd.Parameters["@WIFE_NAME"].Direction = ParameterDirection.Input;

                            sqlCmd.Parameters.Add("@WIFE_AGE", SqlDbType.VarChar);
                            sqlCmd.Parameters["@WIFE_AGE"].Value = strWIFE_AGE;
                            sqlCmd.Parameters["@WIFE_AGE"].Direction = ParameterDirection.Input;

                            sqlCmd.Parameters.Add("@DOJ", SqlDbType.DateTime);
                            sqlCmd.Parameters["@DOJ"].Value = DOJ;
                            sqlCmd.Parameters["@DOJ"].Direction = ParameterDirection.Input;

                            sqlCmd.Parameters.Add("@DOL", SqlDbType.DateTime);
                            if (DOL == Convert_mm_dd_yy("01/01/1900"))
                            {
                                sqlCmd.Parameters["@DOL"].Value = System.DBNull.Value;
                            }
                            else
                            {
                                sqlCmd.Parameters["@DOL"].Value = DOL;
                            }
                            sqlCmd.Parameters["@DOL"].Direction = ParameterDirection.Input;

                            sqlCmd.Parameters.Add("@DESIGNATION", SqlDbType.VarChar);
                            sqlCmd.Parameters["@DESIGNATION"].Value = strDESIGNATION;
                            sqlCmd.Parameters["@DESIGNATION"].Direction = ParameterDirection.Input;

                            sqlCmd.Parameters.Add("@DEPARTMENT", SqlDbType.VarChar);
                            sqlCmd.Parameters["@DEPARTMENT"].Value = strDEPARTMENT;
                            sqlCmd.Parameters["@DEPARTMENT"].Direction = ParameterDirection.Input;

                            sqlCmd.Parameters.Add("@CENTRE_NAME", SqlDbType.VarChar);
                            sqlCmd.Parameters["@CENTRE_NAME"].Value = strCENTRE_NAME;
                            sqlCmd.Parameters["@CENTRE_NAME"].Direction = ParameterDirection.Input;

                            sqlCmd.Parameters.Add("@SUBCENTRENAME", SqlDbType.VarChar);
                            sqlCmd.Parameters["@SUBCENTRENAME"].Value = strSUBCENTRE_NAME;
                            sqlCmd.Parameters["@SUBCENTRENAME"].Direction = ParameterDirection.Input;


                            sqlCmd.Parameters.Add("@CLIENT_NAME", SqlDbType.VarChar);
                            sqlCmd.Parameters["@CLIENT_NAME"].Value = strCLIENT_NAME;
                            sqlCmd.Parameters["@CLIENT_NAME"].Direction = ParameterDirection.Input;

                            sqlCmd.Parameters.Add("@PRODUCT_NAME", SqlDbType.VarChar);
                            sqlCmd.Parameters["@PRODUCT_NAME"].Value = strPRODUCT_NAME;
                            sqlCmd.Parameters["@PRODUCT_NAME"].Direction = ParameterDirection.Input;

                            sqlCmd.Parameters.Add("@ACTIVITY_NAME", SqlDbType.VarChar);
                            sqlCmd.Parameters["@ACTIVITY_NAME"].Value = strACTIVITY_NAME;
                            sqlCmd.Parameters["@ACTIVITY_NAME"].Direction = ParameterDirection.Input;

                            sqlCmd.Parameters.Add("@COMPANY_NAME", SqlDbType.VarChar);
                            sqlCmd.Parameters["@COMPANY_NAME"].Value = strCOMPANY_NAME;
                            sqlCmd.Parameters["@COMPANY_NAME"].Direction = ParameterDirection.Input;

                            sqlCmd.Parameters.Add("@APPROVAL_MAIL_DATE", SqlDbType.VarChar);
                            sqlCmd.Parameters["@APPROVAL_MAIL_DATE"].Value = strAPPROVAL_MAIL_DATE;
                            sqlCmd.Parameters["@APPROVAL_MAIL_DATE"].Direction = ParameterDirection.Input;

                            sqlCmd.Parameters.Add("@APPROVED_BY_OTHER", SqlDbType.VarChar);
                            sqlCmd.Parameters["@APPROVED_BY_OTHER"].Value = strAPPROVED_BY_OTHER;
                            sqlCmd.Parameters["@APPROVED_BY_OTHER"].Direction = ParameterDirection.Input;

                            sqlCmd.Parameters.Add("@USER_ID_ACTIVITYMANAGER", SqlDbType.VarChar);
                            sqlCmd.Parameters["@USER_ID_ACTIVITYMANAGER"].Value = strUSER_ID_ACTIVITYMANAGER;
                            sqlCmd.Parameters["@USER_ID_ACTIVITYMANAGER"].Direction = ParameterDirection.Input;

                            sqlCmd.Parameters.Add("@USERID_OF_CLUSTER", SqlDbType.VarChar);
                            sqlCmd.Parameters["@USERID_OF_CLUSTER"].Value = strUSERID_OF_CLUSTER;
                            sqlCmd.Parameters["@USERID_OF_CLUSTER"].Direction = ParameterDirection.Input;



                            sqlCmd.Parameters.Add("@KIT_RECEIVED_DATE", SqlDbType.VarChar);
                            sqlCmd.Parameters["@KIT_RECEIVED_DATE"].Value = strKIT_RECEIVED_DATE;
                            sqlCmd.Parameters["@KIT_RECEIVED_DATE"].Direction = ParameterDirection.Input;

                            sqlCmd.Parameters.Add("@USERID_OF_HO", SqlDbType.VarChar);
                            sqlCmd.Parameters["@USERID_OF_HO"].Value = strUSERID_OF_HO;
                            sqlCmd.Parameters["@USERID_OF_HO"].Direction = ParameterDirection.Input;

                            /*Added  new column*/
                            sqlCmd.Parameters.Add("@APPROVAL_DATE_HOHR", SqlDbType.VarChar);
                            sqlCmd.Parameters["@APPROVAL_DATE_HOHR"].Value = strVerified_and_updated_on_dtd;
                            sqlCmd.Parameters["@APPROVAL_DATE_HOHR"].Direction = ParameterDirection.Input;

                            /*sqlCmd.Parameters.Add("@LANGUAGE_KNOWN", SqlDbType.VarChar);
                            sqlCmd.Parameters["@LANGUAGE_KNOWN"].Value = strLANGUAGE_KNOWN;
                            sqlCmd.Parameters["@LANGUAGE_KNOWN"].Direction = ParameterDirection.Input;*/

                            sqlCmd.Parameters.Add("@RELATION_WITH_EMPLOYEE", SqlDbType.VarChar);
                            sqlCmd.Parameters["@RELATION_WITH_EMPLOYEE"].Value = strRELATION_WITH_EMPLOYEE;
                            sqlCmd.Parameters["@RELATION_WITH_EMPLOYEE"].Direction = ParameterDirection.Input;

                            sqlCmd.Parameters.Add("@RELATION_NAME_WITH_EMPLOYEE", SqlDbType.VarChar);
                            sqlCmd.Parameters["@RELATION_NAME_WITH_EMPLOYEE"].Value = strRELATION_NAME_WITH_EMPLOYEE;
                            sqlCmd.Parameters["@RELATION_NAME_WITH_EMPLOYEE"].Direction = ParameterDirection.Input;

                            sqlCmd.Parameters.Add("@RELATIVE_NAME", SqlDbType.VarChar);
                            sqlCmd.Parameters["@RELATIVE_NAME"].Value = strRELATIVE_NAME;
                            sqlCmd.Parameters["@RELATIVE_NAME"].Direction = ParameterDirection.Input;

                            sqlCmd.Parameters.Add("@RELATIVE_CODE", SqlDbType.VarChar);
                            sqlCmd.Parameters["@RELATIVE_CODE"].Value = strRELATIVE_CODE;
                            sqlCmd.Parameters["@RELATIVE_CODE"].Direction = ParameterDirection.Input;

                            sqlCmd.Parameters.Add("@COURT_PROCEEDING", SqlDbType.VarChar);
                            sqlCmd.Parameters["@COURT_PROCEEDING"].Value = strCOURT_PROCEEDING;
                            sqlCmd.Parameters["@COURT_PROCEEDING"].Direction = ParameterDirection.Input;

                            sqlCmd.Parameters.Add("@DETAIL_OF_COURT_PROCEEDING", SqlDbType.VarChar);
                            sqlCmd.Parameters["@DETAIL_OF_COURT_PROCEEDING"].Value = strDETAIL_OF_COURT_PROCEEDING;
                            sqlCmd.Parameters["@DETAIL_OF_COURT_PROCEEDING"].Direction = ParameterDirection.Input;

                            sqlCmd.Parameters.Add("@CONTAGIOUS_DISEASE", SqlDbType.VarChar);
                            sqlCmd.Parameters["@CONTAGIOUS_DISEASE"].Value = strCONTAGIOUS_DISEASE;
                            sqlCmd.Parameters["@CONTAGIOUS_DISEASE"].Direction = ParameterDirection.Input;

                            sqlCmd.Parameters.Add("@CONTAGIOUS_DISEASE_DETAIL", SqlDbType.VarChar);
                            sqlCmd.Parameters["@CONTAGIOUS_DISEASE_DETAIL"].Value = strCONTAGIOUS_DISEASE_DETAIL;
                            sqlCmd.Parameters["@CONTAGIOUS_DISEASE_DETAIL"].Direction = ParameterDirection.Input;

                            sqlCmd.Parameters.Add("@NOMINEE_NAME", SqlDbType.VarChar);
                            sqlCmd.Parameters["@NOMINEE_NAME"].Value = strNOMINEE_NAME;
                            sqlCmd.Parameters["@NOMINEE_NAME"].Direction = ParameterDirection.Input;

                            /*sqlCmd.Parameters.Add("@PF#", SqlDbType.VarChar);
                            sqlCmd.Parameters["@PF#"].Value = strPF;
                            sqlCmd.Parameters["@PF#"].Direction = ParameterDirection.Input;

                            sqlCmd.Parameters.Add("@ESIC#", SqlDbType.VarChar);
                            sqlCmd.Parameters["@ESIC#"].Value = strESIC;
                            sqlCmd.Parameters["@ESIC#"].Direction = ParameterDirection.Input;*/

                            sqlCmd.Parameters.Add("@TYPE_OF_CATEGORY", SqlDbType.VarChar);
                            sqlCmd.Parameters["@TYPE_OF_CATEGORY"].Value = strTYPE_OF_CATEGORY;
                            sqlCmd.Parameters["@TYPE_OF_CATEGORY"].Direction = ParameterDirection.Input;

                            sqlCmd.Parameters.Add("@CHILDNAME1", SqlDbType.VarChar);
                            sqlCmd.Parameters["@CHILDNAME1"].Value = strCHILDNAME1;
                            sqlCmd.Parameters["@CHILDNAME1"].Direction = ParameterDirection.Input;

                            sqlCmd.Parameters.Add("@Age1 ", SqlDbType.VarChar);
                            sqlCmd.Parameters["@Age1 "].Value = strAge1;
                            sqlCmd.Parameters["@Age1 "].Direction = ParameterDirection.Input;

                            sqlCmd.Parameters.Add("@CHILDNAME2", SqlDbType.VarChar);
                            sqlCmd.Parameters["@CHILDNAME2"].Value = strCHILDNAME2;
                            sqlCmd.Parameters["@CHILDNAME2"].Direction = ParameterDirection.Input;

                            sqlCmd.Parameters.Add("@Age2", SqlDbType.VarChar);
                            sqlCmd.Parameters["@Age2"].Value = strAge2;
                            sqlCmd.Parameters["@Age2"].Direction = ParameterDirection.Input;

                            sqlCmd.Parameters.Add("@NameOfCollegeInstitution1", SqlDbType.VarChar);
                            sqlCmd.Parameters["@NameOfCollegeInstitution1"].Value = strNameOfCollegeInstitution1;
                            sqlCmd.Parameters["@NameOfCollegeInstitution1"].Direction = ParameterDirection.Input;

                            sqlCmd.Parameters.Add("@NameOfCollegeInstitution2", SqlDbType.VarChar);
                            sqlCmd.Parameters["@NameOfCollegeInstitution2"].Value = strNameOfCollegeInstitution2;
                            sqlCmd.Parameters["@NameOfCollegeInstitution2"].Direction = ParameterDirection.Input;

                            sqlCmd.Parameters.Add("@NameOfCollegeInstitution3", SqlDbType.VarChar);
                            sqlCmd.Parameters["@NameOfCollegeInstitution3"].Value = strNameOfCollegeInstitution3;
                            sqlCmd.Parameters["@NameOfCollegeInstitution3"].Direction = ParameterDirection.Input;

                            sqlCmd.Parameters.Add("@From_To_Year1", SqlDbType.VarChar);
                            sqlCmd.Parameters["@From_To_Year1"].Value = strFrom_To_Year1;
                            sqlCmd.Parameters["@From_To_Year1"].Direction = ParameterDirection.Input;

                            sqlCmd.Parameters.Add("@From_To_Year2", SqlDbType.VarChar);
                            sqlCmd.Parameters["@From_To_Year2"].Value = strFrom_To_Year2;
                            sqlCmd.Parameters["@From_To_Year2"].Direction = ParameterDirection.Input;

                            sqlCmd.Parameters.Add("@From_To_Year3", SqlDbType.VarChar);
                            sqlCmd.Parameters["@From_To_Year3"].Value = strFrom_To_Year3;
                            sqlCmd.Parameters["@From_To_Year3"].Direction = ParameterDirection.Input;

                            sqlCmd.Parameters.Add("@CertificateExamination1", SqlDbType.VarChar);
                            sqlCmd.Parameters["@CertificateExamination1"].Value = strCertificateExamination1;
                            sqlCmd.Parameters["@CertificateExamination1"].Direction = ParameterDirection.Input;

                            sqlCmd.Parameters.Add("@CertificateExamination2", SqlDbType.VarChar);
                            sqlCmd.Parameters["@CertificateExamination2"].Value = strCertificateExamination2;
                            sqlCmd.Parameters["@CertificateExamination2"].Direction = ParameterDirection.Input;

                            sqlCmd.Parameters.Add("@CertificateExamination3", SqlDbType.VarChar);
                            sqlCmd.Parameters["@CertificateExamination3"].Value = strCertificateExamination3;
                            sqlCmd.Parameters["@CertificateExamination3"].Direction = ParameterDirection.Input;

                            /*sqlCmd.Parameters.Add("@QualificationType1", SqlDbType.VarChar);
                            sqlCmd.Parameters["@QualificationType1"].Value = strQualificationType1;
                            sqlCmd.Parameters["@QualificationType1"].Direction = ParameterDirection.Input;

                            sqlCmd.Parameters.Add("@QualificationType2", SqlDbType.VarChar);
                            sqlCmd.Parameters["@QualificationType2"].Value = strQualificationType2;
                            sqlCmd.Parameters["@QualificationType2"].Direction = ParameterDirection.Input;

                            sqlCmd.Parameters.Add("@QualificationType3", SqlDbType.VarChar);
                            sqlCmd.Parameters["@QualificationType3"].Value = strQualificationType3;
                            sqlCmd.Parameters["@QualificationType3"].Direction = ParameterDirection.Input;*/

                            sqlCmd.Parameters.Add("@DivMarks1", SqlDbType.VarChar);
                            sqlCmd.Parameters["@DivMarks1"].Value = strDivMarks1;
                            sqlCmd.Parameters["@DivMarks1"].Direction = ParameterDirection.Input;

                            sqlCmd.Parameters.Add("@DivMarks2", SqlDbType.VarChar);
                            sqlCmd.Parameters["@DivMarks2"].Value = strDivMarks2;
                            sqlCmd.Parameters["@DivMarks2"].Direction = ParameterDirection.Input;

                            sqlCmd.Parameters.Add("@DivMarks3", SqlDbType.VarChar);
                            sqlCmd.Parameters["@DivMarks3"].Value = strDivMarks3;
                            sqlCmd.Parameters["@DivMarks3"].Direction = ParameterDirection.Input;

                            sqlCmd.Parameters.Add("@CopyAttached1", SqlDbType.VarChar);
                            sqlCmd.Parameters["@CopyAttached1"].Value = strCopyAttached1;
                            sqlCmd.Parameters["@CopyAttached1"].Direction = ParameterDirection.Input;

                            sqlCmd.Parameters.Add("@CopyAttached2", SqlDbType.VarChar);
                            sqlCmd.Parameters["@CopyAttached2"].Value = strCopyAttached2;
                            sqlCmd.Parameters["@CopyAttached2"].Direction = ParameterDirection.Input;

                            sqlCmd.Parameters.Add("@CopyAttached3", SqlDbType.VarChar);
                            sqlCmd.Parameters["@CopyAttached3"].Value = strCopyAttached3;
                            sqlCmd.Parameters["@CopyAttached3"].Direction = ParameterDirection.Input;

                            /*sqlCmd.Parameters.Add("@Professional_NameofCollegeInstitution1", SqlDbType.VarChar);
                            sqlCmd.Parameters["@Professional_NameofCollegeInstitution1"].Value = strProfessional_NameofCollegeInstitution1;
                            sqlCmd.Parameters["@Professional_NameofCollegeInstitution1"].Direction = ParameterDirection.Input;*/

                            sqlCmd.Parameters.Add("@Professional_From_To_Year1", SqlDbType.VarChar);
                            sqlCmd.Parameters["@Professional_From_To_Year1"].Value = strProfessional_From_To_Year1;
                            sqlCmd.Parameters["@Professional_From_To_Year1"].Direction = ParameterDirection.Input;

                            sqlCmd.Parameters.Add("@Professional_CertificateExamination1", SqlDbType.VarChar);
                            sqlCmd.Parameters["@Professional_CertificateExamination1"].Value = strProfessional_CertificateExamination1;
                            sqlCmd.Parameters["@Professional_CertificateExamination1"].Direction = ParameterDirection.Input;

                            /*sqlCmd.Parameters.Add("@Professional_QualificationType1", SqlDbType.VarChar);
                            sqlCmd.Parameters["@Professional_QualificationType1"].Value = strProfessional_QualificationType1;
                            sqlCmd.Parameters["@Professional_QualificationType1"].Direction = ParameterDirection.Input;*/

                            sqlCmd.Parameters.Add("@Professional_DivMarks1", SqlDbType.VarChar);
                            sqlCmd.Parameters["@Professional_DivMarks1"].Value = strProfessional_DivMarks1;
                            sqlCmd.Parameters["@Professional_DivMarks1"].Direction = ParameterDirection.Input;

                            sqlCmd.Parameters.Add("@Professional_CopyAttached1", SqlDbType.VarChar);
                            sqlCmd.Parameters["@Professional_CopyAttached1"].Value = strProfessional_CopyAttached1;
                            sqlCmd.Parameters["@Professional_CopyAttached1"].Direction = ParameterDirection.Input;

                            sqlCmd.Parameters.Add("@Employer_Name", SqlDbType.VarChar);
                            sqlCmd.Parameters["@Employer_Name"].Value = strEmployer_Name;
                            sqlCmd.Parameters["@Employer_Name"].Direction = ParameterDirection.Input;

                            sqlCmd.Parameters.Add("@Duration_of_Employment", SqlDbType.VarChar);
                            sqlCmd.Parameters["@Duration_of_Employment"].Value = strDuration_of_Employment;
                            sqlCmd.Parameters["@Duration_of_Employment"].Direction = ParameterDirection.Input;

                            sqlCmd.Parameters.Add("@Salary", SqlDbType.VarChar);
                            sqlCmd.Parameters["@Salary"].Value = strSalary;
                            sqlCmd.Parameters["@Salary"].Direction = ParameterDirection.Input;

                            sqlCmd.Parameters.Add("@Reason_of_Leaving", SqlDbType.VarChar);
                            sqlCmd.Parameters["@Reason_of_Leaving"].Value = strReason_of_Leaving;
                            sqlCmd.Parameters["@Reason_of_Leaving"].Direction = ParameterDirection.Input;

                            sqlCmd.Parameters.Add("@Designation_Nature_job", SqlDbType.VarChar);
                            sqlCmd.Parameters["@Designation_Nature_job"].Value = strDesignation_Nature_job;
                            sqlCmd.Parameters["@Designation_Nature_job"].Direction = ParameterDirection.Input;


                            sqlCmd.Parameters.Add("@CONTACT_NO", SqlDbType.VarChar);
                            sqlCmd.Parameters["@CONTACT_NO"].Value = strContact_No;
                            sqlCmd.Parameters["@CONTACT_NO"].Direction = ParameterDirection.Input;

                            sqlCmd.Parameters.Add("@Literary_Cultural_Art", SqlDbType.VarChar);
                            sqlCmd.Parameters["@Literary_Cultural_Art"].Value = strLiterary_Cultural_Art;
                            sqlCmd.Parameters["@Literary_Cultural_Art"].Direction = ParameterDirection.Input;

                            sqlCmd.Parameters.Add("@Sports", SqlDbType.VarChar);
                            sqlCmd.Parameters["@Sports"].Value = strSports;
                            sqlCmd.Parameters["@Sports"].Direction = ParameterDirection.Input;

                            sqlCmd.Parameters.Add("@Hobbies", SqlDbType.VarChar);
                            sqlCmd.Parameters["@Hobbies"].Value = strHobbies;
                            sqlCmd.Parameters["@Hobbies"].Direction = ParameterDirection.Input;


                            sqlCmd.Parameters.Add("@ReferenceName1", SqlDbType.VarChar);
                            sqlCmd.Parameters["@ReferenceName1"].Value = strReferenceName1;
                            sqlCmd.Parameters["@ReferenceName1"].Direction = ParameterDirection.Input;

                            sqlCmd.Parameters.Add("@ReferenceName2", SqlDbType.VarChar);
                            sqlCmd.Parameters["@ReferenceName2"].Value = strReferenceName2;
                            sqlCmd.Parameters["@ReferenceName2"].Direction = ParameterDirection.Input;

                            sqlCmd.Parameters.Add("@ReferenceAddress1", SqlDbType.VarChar);
                            sqlCmd.Parameters["@ReferenceAddress1"].Value = strReferenceAddress1;
                            sqlCmd.Parameters["@ReferenceAddress1"].Direction = ParameterDirection.Input;

                            sqlCmd.Parameters.Add("@ReferenceAddress2", SqlDbType.VarChar);
                            sqlCmd.Parameters["@ReferenceAddress2"].Value = strReferenceAddress2;
                            sqlCmd.Parameters["@ReferenceAddress2"].Direction = ParameterDirection.Input;

                            sqlCmd.Parameters.Add("@RelationWithReference1", SqlDbType.VarChar);
                            sqlCmd.Parameters["@RelationWithReference1"].Value = strRelationWithReference1;
                            sqlCmd.Parameters["@RelationWithReference1"].Direction = ParameterDirection.Input;

                            sqlCmd.Parameters.Add("@RelationWithReference2", SqlDbType.VarChar);
                            sqlCmd.Parameters["@RelationWithReference2"].Value = strRelationWithReference2;
                            sqlCmd.Parameters["@RelationWithReference2"].Direction = ParameterDirection.Input;

                            sqlCmd.Parameters.Add("@OccupationOfReference1", SqlDbType.VarChar);
                            sqlCmd.Parameters["@OccupationOfReference1"].Value = strOccupationOfReference1;
                            sqlCmd.Parameters["@OccupationOfReference1"].Direction = ParameterDirection.Input;

                            sqlCmd.Parameters.Add("@OccupationOfReference2", SqlDbType.VarChar);
                            sqlCmd.Parameters["@OccupationOfReference2"].Value = strOccupationOfReference2;
                            sqlCmd.Parameters["@OccupationOfReference2"].Direction = ParameterDirection.Input;

                            sqlCmd.Parameters.Add("@ContactNoOfReference1", SqlDbType.VarChar);
                            sqlCmd.Parameters["@ContactNoOfReference1"].Value = strContactNoOfReference1;
                            sqlCmd.Parameters["@ContactNoOfReference1"].Direction = ParameterDirection.Input;

                            sqlCmd.Parameters.Add("@ContactNoOfReference2", SqlDbType.VarChar);
                            sqlCmd.Parameters["@ContactNoOfReference2"].Value = strContactNoOfReference2;
                            sqlCmd.Parameters["@ContactNoOfReference2"].Direction = ParameterDirection.Input;

                            sqlCmd.Parameters.Add("@Basic", SqlDbType.VarChar);
                            sqlCmd.Parameters["@Basic"].Value = strBasic;
                            sqlCmd.Parameters["@Basic"].Direction = ParameterDirection.Input;

                            sqlCmd.Parameters.Add("@HRA", SqlDbType.VarChar);
                            sqlCmd.Parameters["@HRA"].Value = strHRA;
                            sqlCmd.Parameters["@HRA"].Direction = ParameterDirection.Input;

                            sqlCmd.Parameters.Add("@SP_All", SqlDbType.VarChar);
                            sqlCmd.Parameters["@SP_All"].Value = strSP_All;
                            sqlCmd.Parameters["@SP_All"].Direction = ParameterDirection.Input;

                            sqlCmd.Parameters.Add("@Gross_Amt", SqlDbType.VarChar);
                            sqlCmd.Parameters["@Gross_Amt"].Value = strGross_Amt;
                            sqlCmd.Parameters["@Gross_Amt"].Direction = ParameterDirection.Input;

                            sqlConn.Open();
                            int chkProc = (int)sqlCmd.ExecuteNonQuery();
                            sqlConn.Close();

                        }
                        else
                        {
                            lblMessage.Text = "Excel is not in the Correct Format.";
                        }
                    }
                }
            }
            else
            {
                lblMessage.Text = "Please Import Valid Excel File only.";
            }

        }
        //end of try

        catch (Exception ex)
        {
            string strMessage = ex.Message;
            lblMessage.Text = ex.Message + Convert.ToString(i+1) + " th row";
            GridView1.DataSource = null;
            GridView1.DataBind();

        }
        finally
        {
            String strFile = Server.MapPath("../../HRImport/");
            if (File.Exists(strFile))
            {
                File.Delete(strFile);
            }
        }
        #endregion

    }
    private DateTime Convert_mm_dd_yy(string strDate)
    {
        string[] D = strDate.Split('/');
        string dd = D[0];
        string mm = D[1];
        string yy = D[2];
        if (Convert.ToInt16(mm) > 12)
        {
            string temp = dd;
            dd = mm;
            mm = temp;
        }
        yy = mm + "/" + dd + "/" + yy;
        DateTime tDate = Convert.ToDateTime(yy);
        return tDate;
    }
}


