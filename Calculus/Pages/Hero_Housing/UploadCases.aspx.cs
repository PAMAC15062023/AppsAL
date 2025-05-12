using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OleDb;
using System.Data;
using System.IO;
using System.Data.SqlClient;
using System.Configuration;

public partial class Pages_Hero_Housing_UploadCases : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            GetBranch();
        }
    }


    protected void btnupload_Click(object sender, EventArgs e)
    {

        try
        {
            if (xslFileUpload.HasFile)
            {
                String strPath = "";
                String MyFile = "";
                string strDateTime = DateTime.Now.ToString("ddMMyyyyhhmmss");

                strPath = Server.MapPath("~/Pages/Hero_Housing/ImportFiles/");
                MyFile = strDateTime + ".xls";
                strPath = (strPath + MyFile);
                xslFileUpload.PostedFile.SaveAs(strPath);

                string strFileName = xslFileUpload.FileName.ToString();

                FileInfo fi = new FileInfo(strFileName);
                string strExt = fi.Extension;

                if (strExt.ToLower() == ".xls")
                {
                    string strConn = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + strPath + @";Extended Properties=""Excel 8.0;IMEX=1""";

                    OleDbConnection oleCon = new OleDbConnection(strConn);
                    oleCon.Open();

                    OleDbCommand oleCom = new OleDbCommand("SELECT * FROM [sheet1$]");
                    oleCom.Connection = oleCon;

                    OleDbDataAdapter oleDA = new OleDbDataAdapter();
                    oleDA.SelectCommand = oleCom;

                    DataTable dt = new DataTable();
                    oleDA.Fill(dt);
                    oleCon.Close();

                    if (dt.Rows.Count > 0)
                    {
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            insertRecord(dt.Rows[i]);
                        }
                       
                    }


                    string strFile = Server.MapPath("~/Pages/JFS/ImportFiles/") + MyFile;
                    if (File.Exists(strFile))
                    {
                        File.Delete(strFile);
                    }
                }
                else
                {
                    lblMsgXls.Visible = true;
                    lblMsgXls.Text = "It's Not An Excel File...!!!";
                }
            }
            else
            {
                lblMsgXls.Visible = true;
                lblMsgXls.Text = "Please Select Excel File To Import...!!!";
            }
        }
        catch (Exception ex)
        {
            lblMsgXls.Visible = true;
            lblMsgXls.Text = "Error :" + ex.Message;
        }

       

    }

    public void GetBranch()
    {
        Object SaveUSERInfo = (Object)Session["UserInfo"];

        SqlConnection sqlCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);
        try
        {

            sqlCon.Open();
            SqlCommand command = new SqlCommand("Get_AllBranchList", sqlCon);
            command.CommandType = CommandType.StoredProcedure;

            SqlDataAdapter da = new SqlDataAdapter(command);
            DataTable dt = new DataTable();
            da.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                ddlBranch.DataSource = dt;
                ddlBranch.DataTextField = "BranchName";
                ddlBranch.DataValueField = "BranchId";

                ddlBranch.DataBind();

                ddlBranch.Items.Insert(0, new ListItem("Select"));
                ddlBranch.SelectedIndex = 0;
            }


        }
        catch (Exception)
        {
            
            throw;
        }
    }


    public void insertRecord(DataRow dr)
    {

        Object SaveUSERInfo = (Object)Session["UserInfo"];

        SqlConnection sqlCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);
        try
        {
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlCon;
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.CommandText = "Hero_Housing_InsertData2_SP";
            sqlcmd.CommandTimeout = 0;

            SqlParameter loanAppNo = new SqlParameter();
            loanAppNo.SqlDbType = SqlDbType.VarChar;
            loanAppNo.Value = dr["Loan_App_No"].ToString().Trim();
            loanAppNo.ParameterName = "@Loan_App_No";
            sqlcmd.Parameters.Add(loanAppNo);




            SqlParameter LMS_Application_ID = new SqlParameter();
            LMS_Application_ID.SqlDbType = SqlDbType.VarChar;
            LMS_Application_ID.Value = dr["LMS_Application_ID"].ToString().Trim();
            LMS_Application_ID.ParameterName = "@LMS_Application_ID";
            sqlcmd.Parameters.Add(LMS_Application_ID);



            SqlParameter Application_Form_Number = new SqlParameter();
            Application_Form_Number.SqlDbType = SqlDbType.VarChar;
            Application_Form_Number.Value = dr["Application_Form_Number"].ToString().Trim();
            Application_Form_Number.ParameterName = "@Application_Form_Number";
            sqlcmd.Parameters.Add(Application_Form_Number);




            SqlParameter LOB = new SqlParameter();
            LOB.SqlDbType = SqlDbType.VarChar;
            LOB.Value = dr["LOB"].ToString().Trim();
            LOB.ParameterName = "@LOB";
            sqlcmd.Parameters.Add(LOB);



            SqlParameter Branch = new SqlParameter();
            Branch.SqlDbType = SqlDbType.VarChar;
            Branch.Value = dr["Branch"].ToString().Trim();
            Branch.ParameterName = "@Branch";
            sqlcmd.Parameters.Add(Branch);


            if (ddlBranch.SelectedValue.ToString() != "" || ddlBranch.SelectedValue.ToString() != null)
            {

                SqlParameter BranchId = new SqlParameter();
                BranchId.SqlDbType = SqlDbType.VarChar;
                BranchId.Value = dr["BranchId"].ToString().Trim();
                BranchId.ParameterName = "@PMS_Location";
                sqlcmd.Parameters.Add(BranchId);

            }




            SqlParameter Product_Scheme = new SqlParameter();
            Product_Scheme.SqlDbType = SqlDbType.VarChar;
            Product_Scheme.Value = dr["Product_Scheme"].ToString().Trim();
            Product_Scheme.ParameterName = "@Product_Scheme";
            sqlcmd.Parameters.Add(Product_Scheme);


            SqlParameter Transaction_Type = new SqlParameter();
            Transaction_Type.SqlDbType = SqlDbType.VarChar;
            Transaction_Type.Value = dr["Transaction_Type"].ToString().Trim();
            Transaction_Type.ParameterName = "@Transaction_Type";
            sqlcmd.Parameters.Add(Transaction_Type);






            SqlParameter Approved_ROI = new SqlParameter();
            Approved_ROI.SqlDbType = SqlDbType.VarChar;
            Approved_ROI.Value = dr["Approved_ROI"].ToString().Trim();
            Approved_ROI.ParameterName = "@Approved_ROI";
            sqlcmd.Parameters.Add(Approved_ROI);

            SqlParameter Approved_Loan_Amount = new SqlParameter();
            Approved_Loan_Amount.SqlDbType = SqlDbType.VarChar;
            Approved_Loan_Amount.Value = dr["Approved_Loan_Amount"].ToString().Trim();
            Approved_Loan_Amount.ParameterName = "@Approved_Loan_Amount";
            sqlcmd.Parameters.Add(Approved_Loan_Amount);

            SqlParameter Approved_Cross_Sell_Amount = new SqlParameter();
            Approved_Cross_Sell_Amount.SqlDbType = SqlDbType.VarChar;
            Approved_Cross_Sell_Amount.Value = dr["Approved_Cross_Sell_Amount"].ToString().Trim();
            Approved_Cross_Sell_Amount.ParameterName = "@Approved_Cross_Sell_Amount";
            sqlcmd.Parameters.Add(Approved_Cross_Sell_Amount);


            SqlParameter Approved_Processing_Fees = new SqlParameter();
            Approved_Processing_Fees.SqlDbType = SqlDbType.VarChar;
            Approved_Processing_Fees.Value = dr["Approved_Processing_Fees"].ToString().Trim();
            Approved_Processing_Fees.ParameterName = "@Approved_Processing_Fees";
            sqlcmd.Parameters.Add(Approved_Processing_Fees);


            SqlParameter Disbursement_Date = new SqlParameter();
            Disbursement_Date.SqlDbType = SqlDbType.VarChar;
            Disbursement_Date.Value =dr["Disbursement_Date"].ToString().Trim();
             Disbursement_Date.ParameterName = "@Disbursement_Date";
            sqlcmd.Parameters.Add(Disbursement_Date);


            SqlParameter Disbursal_Amount = new SqlParameter();
            Disbursal_Amount.SqlDbType = SqlDbType.VarChar;
            Disbursal_Amount.Value = dr["Disbursal_Amount"].ToString().Trim();
            Disbursal_Amount.ParameterName = "@Disbursal_Amount";
            sqlcmd.Parameters.Add(Disbursal_Amount);

            SqlParameter Credit_Manager = new SqlParameter();
            Credit_Manager.SqlDbType = SqlDbType.VarChar;
            Credit_Manager.Value = dr["Credit_Manager"].ToString().Trim();
            Credit_Manager.ParameterName = "@Credit_Manager";
            sqlcmd.Parameters.Add(Credit_Manager);

            SqlParameter Applicant_Customer_segment = new SqlParameter();
            Applicant_Customer_segment.SqlDbType = SqlDbType.VarChar;
            Applicant_Customer_segment.Value = dr["Applicant_Customer_segment"].ToString().Trim();
            Applicant_Customer_segment.ParameterName = "Applicant_Customer_segment";
            sqlcmd.Parameters.Add(Applicant_Customer_segment);

            SqlParameter Segment = new SqlParameter();
            Segment.SqlDbType = SqlDbType.VarChar;
            Segment.Value = dr["Segment"].ToString().Trim();
            Segment.ParameterName = "@Segment";
            sqlcmd.Parameters.Add(Segment);

            SqlParameter Requested_Loan_Amount = new SqlParameter();
            Requested_Loan_Amount.SqlDbType = SqlDbType.VarChar;
            Requested_Loan_Amount.Value = dr["Requested_Loan_Amount"].ToString().Trim();
            Requested_Loan_Amount.ParameterName = "@Requested_Loan_Amount";
            sqlcmd.Parameters.Add(Requested_Loan_Amount);

            SqlParameter Loan_Application_Number = new SqlParameter();
            Loan_Application_Number.SqlDbType = SqlDbType.VarChar;
            Loan_Application_Number.Value = dr["Loan_Application_Number"].ToString().Trim();
            Loan_Application_Number.ParameterName = "Loan_Application_Number";
            sqlcmd.Parameters.Add(Loan_Application_Number);

            SqlParameter Customer_Customer_Name = new SqlParameter();
            Customer_Customer_Name.SqlDbType = SqlDbType.VarChar;
            Customer_Customer_Name.Value = dr["Customer_Customer_Name"].ToString().Trim();
            Customer_Customer_Name.ParameterName = "Customer_Customer_Name";
            sqlcmd.Parameters.Add(Customer_Customer_Name);

            SqlParameter Stage = new SqlParameter();
            Stage.SqlDbType = SqlDbType.VarChar;
            Stage.Value = dr["Stage"].ToString().Trim();
            Stage.ParameterName = "@Stage";
            sqlcmd.Parameters.Add(Stage);


            SqlParameter Sub_Stage = new SqlParameter();
            Sub_Stage.SqlDbType = SqlDbType.VarChar;
            Sub_Stage.Value = dr["Sub_Stage"].ToString().Trim();
            Sub_Stage.ParameterName = "@Sub_Stage";
            sqlcmd.Parameters.Add(Sub_Stage);


            SqlParameter Previous_Sub_Stage = new SqlParameter();
            Previous_Sub_Stage.SqlDbType = SqlDbType.VarChar;
            Previous_Sub_Stage.Value = dr["Previous_Sub_Stage"].ToString().Trim();
            Previous_Sub_Stage.ParameterName = "@Previous_Sub_Stage";
            sqlcmd.Parameters.Add(Previous_Sub_Stage);


            SqlParameter SM_CBM = new SqlParameter();
            SM_CBM.SqlDbType = SqlDbType.VarChar;
            SM_CBM.Value = dr["SM_CBM"].ToString().Trim();
            SM_CBM.ParameterName = "@SM_CBM";
            sqlcmd.Parameters.Add(SM_CBM);


            SqlParameter Loan_Application_Created_By = new SqlParameter();
            Loan_Application_Created_By.SqlDbType = SqlDbType.VarChar;
            Loan_Application_Created_By.Value = dr["Loan_Application_Created_By"].ToString().Trim();
            Loan_Application_Created_By.ParameterName = "@Loan_Application_Created_By";
            sqlcmd.Parameters.Add(Loan_Application_Created_By);




            SqlParameter Sum_of_IMD = new SqlParameter();
            Sum_of_IMD.SqlDbType = SqlDbType.VarChar;
            Sum_of_IMD.Value = dr["Sum_of_IMD"].ToString().Trim();
            Sum_of_IMD.ParameterName = "@Sum_of_IMD";
            sqlcmd.Parameters.Add(Sum_of_IMD);


            SqlParameter Login_Date = new SqlParameter();
            Login_Date.SqlDbType = SqlDbType.VarChar;
            Login_Date.Value =dr["Login_Date"].ToString().Trim();
            Login_Date.ParameterName = "@Login_Date";
            sqlcmd.Parameters.Add(Login_Date);


            SqlParameter Sub_Stage_Start_Time = new SqlParameter();
            Sub_Stage_Start_Time.SqlDbType = SqlDbType.VarChar;
            Sub_Stage_Start_Time.Value =dr["Sub_Stage_Start_Time"].ToString().Trim();
            Sub_Stage_Start_Time.ParameterName = "Sub_Stage_Start_Time";
            sqlcmd.Parameters.Add(Sub_Stage_Start_Time);


            SqlParameter FTNR_Check = new SqlParameter();
            FTNR_Check.SqlDbType = SqlDbType.VarChar;
            FTNR_Check.Value = dr["FTNR_Check"].ToString().Trim();
            FTNR_Check.ParameterName = "@FTNR_Check";
            sqlcmd.Parameters.Add(FTNR_Check);


            SqlParameter File_Checker = new SqlParameter();
            File_Checker.SqlDbType = SqlDbType.VarChar;
            File_Checker.Value = dr["File_Checker"].ToString().Trim();
            File_Checker.ParameterName = "@File_Checker";
            sqlcmd.Parameters.Add(File_Checker);



            SqlParameter Scan_Data_Checker = new SqlParameter();
            Scan_Data_Checker.SqlDbType = SqlDbType.VarChar;
            Scan_Data_Checker.Value = dr["Scan_Data_Checker"].ToString().Trim();
            Scan_Data_Checker.ParameterName = "@Scan_Data_Checker";
            sqlcmd.Parameters.Add(Scan_Data_Checker);


            SqlParameter Scan_Data_Maker = new SqlParameter();
            Scan_Data_Maker.SqlDbType = SqlDbType.VarChar;
            Scan_Data_Maker.Value = dr["Scan_Data_Maker"].ToString().Trim();
            Scan_Data_Maker.ParameterName = "@Scan_Data_Maker";
            sqlcmd.Parameters.Add(Scan_Data_Maker);


            SqlParameter Credit_Authority_Approver = new SqlParameter();
            Credit_Authority_Approver.SqlDbType = SqlDbType.VarChar;
            Credit_Authority_Approver.Value = dr["Credit_Authority_Approver"].ToString().Trim();
            Credit_Authority_Approver.ParameterName = "@Credit_Authority_Approver";
            sqlcmd.Parameters.Add(Credit_Authority_Approver);


            SqlParameter Comments = new SqlParameter();
            Comments.SqlDbType = SqlDbType.VarChar;
            Comments.Value = dr["Comments"].ToString().Trim();
            Comments.ParameterName = "@Comments";
            sqlcmd.Parameters.Add(Comments);


            SqlParameter Comments_Trail = new SqlParameter();
            Comments_Trail.SqlDbType = SqlDbType.VarChar;
            Comments_Trail.Value = dr["Comments_Trail"].ToString().Trim();
            Comments_Trail.ParameterName = "@Comments_Trail";
            sqlcmd.Parameters.Add(Comments_Trail);

            SqlParameter Owner_Name = new SqlParameter();
            Owner_Name.SqlDbType = SqlDbType.VarChar;
            Owner_Name.Value = dr["Owner_Name"].ToString().Trim();
            Owner_Name.ParameterName = "@Owner_Name";
            sqlcmd.Parameters.Add(Owner_Name);

            SqlParameter Property_Identified = new SqlParameter();
            Property_Identified.SqlDbType = SqlDbType.VarChar;
            Property_Identified.Value = dr["Property_Identified"].ToString().Trim();
            Property_Identified.ParameterName = "@Property_Identified";
            sqlcmd.Parameters.Add(Property_Identified);

            SqlParameter Sanction_Date = new SqlParameter();
            Sanction_Date.SqlDbType = SqlDbType.VarChar;
            Sanction_Date.Value =dr["Sanction_Date"].ToString().Trim();
            Sanction_Date.ParameterName = "@Sanction_Date";
            sqlcmd.Parameters.Add(Sanction_Date);


            sqlCon.Open();
            int RowEffected = 0;

            RowEffected = sqlcmd.ExecuteNonQuery();


            sqlCon.Close();
        }
        catch (Exception ex)
        {
          
        }
        //finally
        //{
        //    sqlCon.Close();
        //    sqlCon.Dispose();
        //}
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {

    }
}