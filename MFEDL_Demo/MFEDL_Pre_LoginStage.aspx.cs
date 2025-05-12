using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MFEDL_Demo
{
    public partial class MFEDL_Pre_LoginStage : System.Web.UI.Page
    {
        DataTable DataTable = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                InitializeComponent();
                btngotoTVR.Visible = false;

                plDiscrepancy.Visible = false;
                DIV1.Visible = false;


                plLoginHold.Visible = false;

                Case_Assign_To_LoginExecutive();
                Get_DataFor_LoginExecutive();

                Bind_LoginStatus();
                BindDescrepancy();

                //BindObservation();

                BindFTNRStatus();
            }
        }

        private void Case_Assign_To_LoginExecutive()
        {
            Object SaveUSERInfo = (Object)Session["UserInfo"];
            SqlConnection sqlCon = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);

            SqlCommand sqlCom2 = new SqlCommand();
            sqlCom2.Connection = sqlCon;
            sqlCom2.CommandType = CommandType.StoredProcedure;
            sqlCom2.CommandText = "MFEDL_AutoAssignCaseToLoginExecutive_SP";

            SqlParameter UserID = new SqlParameter();
            UserID.SqlDbType = SqlDbType.VarChar;
            UserID.Value = Convert.ToString(Session["UserID"]);
            UserID.ParameterName = "@Userid";
            sqlCom2.Parameters.Add(UserID);

            SqlParameter LocationName = new SqlParameter();
            LocationName.SqlDbType = SqlDbType.VarChar;
            LocationName.Value = Convert.ToString(Session["CPC"]);
            LocationName.ParameterName = "@LocationName";
            sqlCom2.Parameters.Add(LocationName);

            SqlDataAdapter sqlDA2 = new SqlDataAdapter();
            sqlDA2.SelectCommand = sqlCom2;

            sqlCon.Open();

            int SqlRow = 0;
            SqlRow = sqlCom2.ExecuteNonQuery();

            sqlCon.Close();

            if (SqlRow > 0)
            {
            }
        }
        private void Get_DataFor_LoginExecutive()
        {


            SqlConnection sqlCon = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);

            SqlCommand sqlCom = new SqlCommand();
            sqlCom.Connection = sqlCon;
            sqlCom.CommandType = CommandType.StoredProcedure;
            sqlCom.CommandText = "MFEDL_Get_DataLoginExecutive_SP";
            sqlCom.CommandTimeout = 0;

            SqlParameter UserID = new SqlParameter();
            UserID.SqlDbType = SqlDbType.VarChar;
            UserID.Value = Convert.ToString(Session["UserID"]);
            UserID.ParameterName = "@UserID";
            sqlCom.Parameters.Add(UserID);

            sqlCon.Open();

            SqlDataAdapter sqlDA = new SqlDataAdapter();
            sqlDA.SelectCommand = sqlCom;

            DataTable dt = new DataTable();
            sqlDA.Fill(dt);

            sqlCon.Close();

            if (dt.Rows.Count > 0)
            {
                gvData.DataSource = dt;
                gvData.DataBind();
            }
            else
            {
                gvData.DataSource = null;
                gvData.DataBind();

                lblMsgXls.Visible = true;
                lblMsgXls.Text = "No Case Found";
            }
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("MFEDL_MenuPage.aspx", false);
        }

        protected void lnkWIP_Click(object sender, EventArgs e)
        {

            Panel1.Visible = true;
            lblMsgXls.Text = "";
            try
            {
                for (int i = 0; i <= gvData.Rows.Count - 1; i++)
                {
                    CheckBox chkSelect = (CheckBox)gvData.Rows[i].FindControl("chkSelect");

                    LinkButton WIP = (LinkButton)gvData.Rows[i].FindControl("lnkWIP");

                    string ASP_ID = gvData.Rows[i].Cells[2].Text.Trim();

                    txtAPSID.Text = gvData.Rows[i].Cells[2].Text.Trim();

                    string DSA = gvData.Rows[i].Cells[6].Text.Trim();

                    string RM = gvData.Rows[i].Cells[7].Text.Trim();

                    ViewState["ApplicationID"] = gvData.Rows[i].Cells[2].Text.Trim();



                    if (chkSelect.Checked == true)
                    {
                        SqlConnection sqlCon = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);

                        SqlCommand sqlCom = new SqlCommand();
                        sqlCom.Connection = sqlCon;
                        sqlCom.CommandType = CommandType.StoredProcedure;
                        sqlCom.CommandText = "MFEDL_AssignInProcess_LoginExecutive_SP";
                        sqlCom.CommandTimeout = 0;

                        SqlParameter LOSNo = new SqlParameter();
                        LOSNo.SqlDbType = SqlDbType.VarChar;
                        LOSNo.Value = ASP_ID;
                        LOSNo.ParameterName = "@ApplicationID";
                        sqlCom.Parameters.Add(LOSNo);

                        sqlCon.Open();

                        int SqlRow = 0;
                        SqlRow = sqlCom.ExecuteNonQuery();

                        sqlCon.Close();

                        if (SqlRow > 0)
                        {

                            lblMsgXls.Text = "Edit Successfully";
                            chkSelect.Checked = false;
                            chkSelect.Enabled = false;
                        }
                    }
                    else
                    {
                        lblMsgXls.Visible = true;
                        lblMsgXls.Text = "Error :";
                    }
                }


                BindLoginStageDetails();
            }
            catch (Exception ex)
            {
                lblMsgXls.Visible = true;
                lblMsgXls.Text = "Error :" + ex.Message;
            }
        }
        protected void BindLoginStageDetails()
        {
            SqlConnection sqlCon = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);

            SqlCommand sqlCom = new SqlCommand();
            sqlCom.Connection = sqlCon;
            sqlCom.CommandType = CommandType.StoredProcedure;
            sqlCom.CommandText = "MFEDL_BindLoginStageDetails_SP";
            sqlCom.CommandTimeout = 0;

            SqlParameter APSID = new SqlParameter();
            APSID.SqlDbType = SqlDbType.VarChar;
            APSID.Value = txtAPSID.Text.Trim();
            APSID.ParameterName = "@ApplicationID";
            sqlCom.Parameters.Add(APSID);

            SqlDataAdapter da = new SqlDataAdapter(sqlCom);
            DataSet ds = new DataSet();
            da.Fill(ds);



            string LoginHoldRemark = ds.Tables[0].Rows[0]["LoginHoldRemark"].ToString();


            if (LoginHoldRemark != null && LoginHoldRemark != "")
            {
                plLoginHold.Visible = true;

                plDiscrepancy.Visible = false;
                DIV1.Visible = false;

                ddlFTNRStatus.Visible = false;
                lblFTNRStatus.Visible = false;

                txtLoginholdRemark.Text = ds.Tables[0].Rows[0]["LoginHoldRemark"].ToString();
            }

            /*if (ds != null && ds.Tables.Count > 1)
            {

                  txtCOApplicantName.Text = ds.Tables[0].Rows[0]["CoApplicantName"].ToString();
                ddlActivityStartedFrom.SelectedValue = ds.Tables[1].Rows[0]["ActivityStartedFrom"].ToString();
                ddlCOMPANYCATEGORY.SelectedValue = ds.Tables[1].Rows[0]["COMPANYCATEGORY"].ToString();
                ddlSourcedBy.SelectedValue = ds.Tables[1].Rows[0]["SourcedBy"].ToString();
                txtLoanAmount.Text = ds.Tables[1].Rows[0]["LoanAmount"].ToString();

                //  ddlLoginStatus.SelectedValue = ds.Tables[0].Rows[0]["FirstTime_FTR_FTNR_Status"].ToString();
                //txtCompanyName.Text = ds.Tables[0].Rows[0]["CompanyName"].ToString();
                //ddlselfsalaried.SelectedValue = ds.Tables[0].Rows[0]["Self_Salaried"].ToString() == "" ? "Select" : ds.Tables[0].Rows[0]["Self_Salaried"].ToString();

                txtdsa.Text = ds.Tables[1].Rows[0]["DSA"].ToString();
                txtrmname.Text = ds.Tables[1].Rows[0]["RM"].ToString();
                txtdsa.Enabled = true;
                txtrmname.Enabled = true;

                if (ds.Tables.Count > 2)
                {

                    DataTable = ds.Tables[2];

                    InitializeComponent();

                    ViewState["DataTable"] = DataTable;

                    gvdis.DataSource = DataTable;
                    gvdis.DataBind();

                    plDiscrepancy.Visible = true;
                    DIV1.Visible = true;

                    ddlFTNRStatus.Visible = true;
                    lblFTNRStatus.Visible = true;

                    BindFTNRStatus();
                }
            }*/
        }

        protected void Bind_LoginStatus()
        {
            try
            {
                SqlConnection sqlCon = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);

                SqlCommand sqlCom = new SqlCommand();
                sqlCom.Connection = sqlCon;
                sqlCom.CommandType = CommandType.StoredProcedure;
                sqlCom.CommandText = "MFEDL_BindLoginStatus";
                sqlCom.CommandTimeout = 0;

                SqlDataAdapter da = new SqlDataAdapter(sqlCom);
                DataSet ds = new DataSet();
                da.Fill(ds);

                if (ds != null && ds.Tables[0].Rows.Count > 0)
                {
                    if (gvData.Rows.Count > 0)
                    {
                        if (gvData.Rows[0].Cells[6].Text.Trim() == "Introduced")
                        {
                            //ds.Tables[0].Rows[ds.Tables[0].Rows.Count - 1].Delete();

                            ds.Tables[0].Rows[2].Delete();
                            ds.Tables[0].Rows[4].Delete();
                        }
                        //else if (gvData.Rows[0].Cells[9].Text.Trim() == "REWORK")
                        //{
                        //    ds.Tables[0].Rows[0].Delete();
                        //}
                        if (gvData.Rows[0].Cells[6].Text.Trim() == "Returned")
                        {
                            //ds.Tables[0].Rows[ds.Tables[0].Rows.Count - 1].Delete();
                            
                            ds.Tables[0].Rows[0].Delete();
                        }
                        ds.AcceptChanges();
                    }


                    ddlLoginStatus.DataSource = ds;
                    ddlLoginStatus.DataTextField = "Description";
                    ddlLoginStatus.DataValueField = "ID";
                    ddlLoginStatus.DataSource = ds.Tables[0];
                    ddlLoginStatus.DataBind();

                    ddlLoginStatus.Items.Insert(0, "--Select--");
                    ddlLoginStatus.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {

            }
        }
        protected void DisableLoginStatus()
        {
            if (hdfloginstatu.Value == "FTNR Resolved")
            {
                plDiscrepancy.Visible = true;
                DIV1.Visible = true;

                foreach (ListItem item in ddlLoginStatus.Items)
                {

                    if (item.Text == "FTR")
                    {
                        item.Attributes.Add("disabled", "disabled");
                    }
                    if (item.Text == "FTNR")
                    {
                        item.Attributes.Add("disabled", "disabled");
                    }
                    if (item.Text == "Hold")
                    {
                        item.Attributes.Add("disabled", "disabled");
                    }
                    if (item.Text == "Hold resolved")
                    {
                        item.Attributes.Add("disabled", "disabled");
                    }
                }
            }
            if (hdfloginstatu.Value == "FTNR")
            {
                plDiscrepancy.Visible = true;
                DIV1.Visible = true;

                foreach (ListItem item in ddlLoginStatus.Items)
                {

                    if (item.Text == "FTR")
                    {
                        item.Attributes.Add("disabled", "disabled");
                    }

                }
            }
            if (hdfloginstatu.Value == "FTR")
            {

                foreach (ListItem item in ddlLoginStatus.Items)
                {

                    if (item.Text == "FTNR Resolved")
                    {
                        item.Attributes.Add("disabled", "disabled");
                    }
                    if (item.Text == "FTNR")
                    {
                        item.Attributes.Add("disabled", "disabled");
                    }
                    if (item.Text == "Hold Resolved")
                    {
                        item.Attributes.Add("disabled", "disabled");
                    }
                    if (item.Text == "Hold Resolved")
                    {
                        item.Attributes.Add("disabled", "disabled");
                    }
                }
            }
            if (hdfloginstatu.Value == "Hold")
            {
                plLoginHold.Visible = true;
                DIV1.Visible = true;

                foreach (ListItem item in ddlLoginStatus.Items)
                {

                    if (item.Text == "FTR")
                    {
                        item.Attributes.Add("disabled", "disabled");
                    }
                    if (item.Text == "FTNR Resolved")
                    {
                        item.Attributes.Add("disabled", "disabled");
                    }
                }
            }
        }
        protected void BindDescrepancy()
        {
            try
            {
                SqlConnection sqlCon = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);

                SqlCommand sqlCom = new SqlCommand();
                sqlCom.Connection = sqlCon;
                sqlCom.CommandType = CommandType.StoredProcedure;
                sqlCom.CommandText = "MFEDL_BindDescrepancyMaster_SP";
                sqlCom.CommandTimeout = 0;

                SqlDataAdapter da = new SqlDataAdapter(sqlCom);
                DataSet ds = new DataSet();
                da.Fill(ds);

                if (ds != null && ds.Tables.Count > 0)
                {
                    ddlDiscrepancy.DataTextField = "Descrepancy";
                    ddlDiscrepancy.DataValueField = "DescrepancyID";
                    ddlDiscrepancy.DataSource = ds.Tables[0];
                    ddlDiscrepancy.DataBind();

                    ddlDiscrepancy.Items.Insert(0, "--Select--");
                    ddlDiscrepancy.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {

            }
        }


        protected void BindFTNRStatus()
        {
            try
            {
                SqlConnection sqlCon = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);

                SqlCommand sqlCom = new SqlCommand();
                sqlCom.Connection = sqlCon;
                sqlCom.CommandType = CommandType.StoredProcedure;
                sqlCom.CommandText = "MFEDL_Pre_BindFTNRStatus_SP";
                sqlCom.CommandTimeout = 0;

                SqlDataAdapter da = new SqlDataAdapter(sqlCom);
                DataSet ds = new DataSet();
                da.Fill(ds);

                if (ds != null && ds.Tables.Count > 0)
                {
                    ddlFTNRStatus.DataTextField = "Description";
                    ddlFTNRStatus.DataValueField = "FTNRStatusCode";
                    ddlFTNRStatus.DataSource = ds.Tables[0];
                    ddlFTNRStatus.DataBind();

                    ddlFTNRStatus.Items.Insert(0, "--Select--");
                    ddlFTNRStatus.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {

            }
        }
        protected DataTable CreateTableType()
        {
            DataTable dtType = new DataTable();
            dtType.Columns.Add("Loan_Type");
            dtType.Columns.Add("ASP_ID");
            dtType.Columns.Add("Disc_Category");
            dtType.Columns.Add("Disc_Subcategory");
            dtType.Columns.Add("Disc_Observations");
            dtType.Columns.Add("Disc_Remarks");
            dtType.Columns.Add("Is_Active");
            dtType.Columns.Add("Created_BY");


            string ASP_ID = Convert.ToString(ViewState["ASP_ID"]);
            string Loan_Type = "PL";//Convert.ToString(Session["LoanType"]);
            string Created_BY = Convert.ToString(Session["RoleName"]);


            string[] strData = hdnDataDetails.Value.Split('^');
            foreach (string strRows in strData)
            {
                if (strRows != "")
                {
                    string Disc_Category, Disc_Subcategory, Disc_Observations, Disc_Remarks;

                    string[] row = strRows.Split('|');
                    Disc_Category = row[0];
                    Disc_Subcategory = row[1];
                    Disc_Observations = row[2];
                    Disc_Remarks = row[3];

                    dtType.Rows.Add(Loan_Type, ASP_ID, Disc_Category, Disc_Subcategory, Disc_Observations, Disc_Remarks, "1", Created_BY);
                }
            }
            return dtType;
        }
        protected bool SaveData()
        {
            bool validationResult = true;
            string msg = string.Empty;

            string APS_ID = Convert.ToString(ViewState["ApplicationID"]);

            if (APS_ID == "")
            {
                msg = msg + "Please Click On Edit ";
            }

            /*      if (ddlActivityStartedFrom.SelectedValue == "--Select--")
                  {
                      msg = msg + "Please Select Activity Started From ";
                  }

                 if (ddlCOMPANYCATEGORY.SelectedValue == "--Select--")
                  {
                      msg = msg + "Please Select COMPANY CATEGORY ";
                  }*/

            /*if (ddlSourcedBy.SelectedValue == "--Select--")
            {
                msg = msg + "Please Select Sourced By ";
            }*/

            /*if (txtLoanAmount.Text.Trim() == "" || txtLoanAmount.Text.Trim() == null)
            {
                msg = msg + "Please Enter Loan Amount /n";
            }*/

            //if (txtCompanyName.Text.Trim() == "" || txtCompanyName.Text.Trim() == null)
            //{
            //    msg = msg + "Please Enter Company Name /n";
            //}


            // added FTNR Validation
            DataTable dt = new DataTable();
            if (ddlLoginStatus.SelectedItem.Text.Trim() == "FTNR")
            {
                dt = (DataTable)ViewState["DataTable"];
                if (dt.Rows.Count == 0)
                {
                    msg = msg + "Please enter atleast 1 discrepancy to save the record as FTNR !! ";
                }
            }


            if (ddlDiscrepancy.SelectedIndex > 0)
            {
                msg = msg + "Please Add the discrepancy using Add to Grid Button, as you have selected item in Discrepancy  !! ";
            }

            // Added Validation on 15 Nov 2021
            /*if (txtrmname.Text.Trim() == "")
            {
                msg = msg + "Please Enter RM Name !! ";
            }

            // Added Validation on 15 Nov 2021
            if (txtdsa.Text.Trim() == "")
            {
                msg = msg + "Please Enter DSA Name !! ";
            }*/

            //added FTNR Resolved Validation Start
            dt = new DataTable();
            if (ddlLoginStatus.SelectedItem.Text.Trim() == "FTNR Resolved")
            {
                dt = (DataTable)ViewState["DataTable"];
                if (dt.Rows.Count == 0)
                {
                    msg = msg + "Please add  to Grid atleast 1 Record to save the Details as FTNR Resolved /n";
                }
            }

            if (ddlLoginStatus.SelectedItem.Text.Trim() == "FTNR Resolved")
            {

                dt = (DataTable)ViewState["DataTable"];
                foreach (DataRow dr in dt.Rows)
                {
                    string FTNRStatus = Convert.ToString(dr["FTNRStatus"]);
                    if (string.IsNullOrEmpty(FTNRStatus) || FTNRStatus == "--Select--")
                    {
                        msg = msg + "Please resolve all the Discrepancy, to save the record as FTNR Resolved /n";
                        break;
                    }
                }
            }
            //END

            if (msg != "")
            {
                validationResult = false;
                ClientScript.RegisterStartupScript(Page.GetType(), "mykey", "alert('" + msg + "');", true);
                return validationResult;
            }



            SqlConnection sqlCon = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);


            //dt = CreateTableType();
            dt = new DataTable();
            dt = (DataTable)ViewState["DataTable"];


            dt.Columns.Remove("Discrepancy");
            dt.Columns.Remove("FTNRStatus"); 

            // check what is the above data table?
            // fields to be sent to Stored procedure confirm 
            // In sp - update login stage or insert -- update tracking table -- insert / update discrepacny


            dt.AcceptChanges();


           

            SqlCommand cmd = new SqlCommand("MFEDL_InsertOrUpdateLoginStageDetails", sqlCon);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ApplicationID", gvData.Rows[0].Cells[2].Text);
            cmd.Parameters.AddWithValue("@CoApplicantName", txtCOApplicantName.Text);
            cmd.Parameters.AddWithValue("@LoginStatus", ddlLoginStatus.SelectedItem.Text);
            cmd.Parameters.AddWithValue("@LoginDiscrepancyType", dt);
            cmd.Parameters.AddWithValue("@LoginHoldRemark", txtLoginholdRemark.Text);
            cmd.Parameters.AddWithValue("@LoginHoldResolvedRemark", txtLoginholdRemark.Text);
            cmd.Parameters.AddWithValue("@CreatedBy", Convert.ToString(Session["UserID"]));


            sqlCon.Open();
            int result = cmd.ExecuteNonQuery();
            sqlCon.Close();

            if (result > 0)
            {
                lblMsgXls.Visible = true;
                lblMsgXls.Text = "Data Successfully added ";

                ClearData();

                plDiscrepancy.Visible = false;
                DIV1.Visible = false;

            }
            return validationResult;
            //Response.Redirect("YBL_Dashboard.aspx", false);
        }

        protected void btnSaveAndContinue_Click(object sender, EventArgs e)
        {
            if (Session["UserName"] != null)
            {
                int RoleId = Convert.ToInt32(Session["RoleId"]);

                string LoginStatus = ddlLoginStatus.SelectedItem.Text.Trim();

                bool result = SaveData();

                if (result)
                {

                    //Session.Clear();
                    Response.Redirect("MFEDL_Pre_LoginStage.aspx", false);
                }
            }

        }
        //protected void DataSaveAndExit()
        //{

        //    string msg = string.Empty;

        //    string APS_ID = Convert.ToString(ViewState["ASP_ID"]);

        //    if (APS_ID == "")
        //    {
        //        msg = msg + "Please Click On Edit ";
        //    }

        //    /* if (ddlActivityStartedFrom.SelectedValue == "--Select--")
        //     {
        //         msg = msg + "Please Select Activity Started From ";
        //     }

        //     if (ddlCOMPANYCATEGORY.SelectedValue == "--Select--")
        //     {
        //         msg = msg + "Please Select COMPANY CATEGORY ";
        //     }

        //     if (ddlSourcedBy.SelectedValue == "--Select--")
        //     {
        //         msg = msg + "Please Select Sourced By ";
        //     }

        //     if (txtLoanAmount.Text == "" || txtLoanAmount.Text == null)
        //     {
        //         msg = msg + "Please Enter Loan Amount /n";
        //     }*/

        //    if (msg != "")
        //    {
        //        ClientScript.RegisterStartupScript(Page.GetType(), "mykey", "alert('" + msg + "');", true);
        //        return;
        //    }


        //    SqlConnection sqlCon = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);

        //    DataTable dt = new DataTable();
        //    //dt = CreateTableType();

        //    dt = (DataTable)ViewState["DataTable"];


        //    dt.Columns.Remove("Category");
        //    dt.Columns.Remove("Subcategory");
        //    dt.Columns.Remove("Observations");
        //    dt.Columns.Remove("FTNRStatus");


        //    dt.AcceptChanges();

        //    SqlCommand cmd = new SqlCommand("YBL_Insert_Or_Update_LoginStage_SaveOnly_PL", sqlCon);
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    cmd.Parameters.AddWithValue("@APS_ID", Convert.ToString(ViewState["ASP_ID"]));
        //    // cmd.Parameters.AddWithValue("@ActivityStartedFrom", ddlActivityStartedFrom.SelectedValue);
        //    //cmd.Parameters.AddWithValue("@COMPANYCATEGORY", ddlCOMPANYCATEGORY.SelectedValue);
        //    //cmd.Parameters.AddWithValue("@SourcedBy", ddlSourcedBy.SelectedValue);
        //    // cmd.Parameters.AddWithValue("@LoanAmount", txtLoanAmount.Text.Trim());
        //    cmd.Parameters.AddWithValue("@FirstTime_FTR_FTNR_Status", ddlLoginStatus.SelectedValue);
        //    cmd.Parameters.AddWithValue("@CreatedBy", Convert.ToString(Session["LoginName"]));
        //    cmd.Parameters.AddWithValue("@DiscrepancyType", dt);
        //    cmd.Parameters.AddWithValue("@loanType", Session["ProductType"].ToString());


        //    sqlCon.Open();
        //    int result = cmd.ExecuteNonQuery();
        //    sqlCon.Close();

        //    if (result > 0)
        //    {
        //        lblMsgXls.Visible = true;
        //        lblMsgXls.Text = "Data Successfully added ";

        //        ClearData();

        //        plDiscrepancy.Visible = false;
        //        DIV1.Visible = false;

        //    }
        //}
        protected void btnSaveAndExit_Click(object sender, EventArgs e)
        {
            if (Session["UserName"] != null)
            {
                bool result = SaveData();
                if (result)
                {

                    CommonMaster commonMaster = new CommonMaster();
                    int Result = commonMaster.UserLogOut(Convert.ToString(Session["LoginName"]));

                    if (Result == 1)
                    {
                       // Session.Clear();
                        Response.Redirect("MFEDL_MenuPage.aspx", false);
                    }
                }
            }
        }
        //button :goto TVR - redirect to tvr page (? apsid?
        protected void InitializeComponent()
        {
            if (ViewState["DataTable"] == null)
            {
                DataTable.Columns.Add("Discrepancy");
                DataTable.Columns.Add("DiscrepancyID");
                DataTable.Columns.Add("DiscrepancyRemark");
                DataTable.Columns.Add("FTNRStatus");
                DataTable.Columns.Add("FTNRStatusCode");

                ViewState["DataTable"] = DataTable;
            }
        }

        protected void btnAdddis_Click(object sender, EventArgs e)
        {

            string msg = string.Empty;


            if (ddlDiscrepancy.SelectedIndex == 0)
            {
                msg = msg + "Please Select Discrepancy ";
            }
            if (txtDiscrepancyRemarks.Text.Trim() == null || txtDiscrepancyRemarks.Text.Trim() == "")
            {
                msg = msg + "Please Enter Discrepancy Remark";
            }
            if (msg != "")
            {
                ClientScript.RegisterStartupScript(Page.GetType(), "mykey", "alert('" + msg + "');", true);
                return;
            }


            if (hdfloginstatu.Value == "FTNR")
            {
                //plDiscrepancy.Visible = true;
                //DIV1.Visible = true;
                foreach (ListItem item in ddlLoginStatus.Items)
                {

                    if (item.Text == "FTR")
                    {
                        item.Attributes.Add("disabled", "disabled");
                    }
                }
            }


            string FTNRStatus = "";
            string FTNRStatusCode = "0";

            if (ddlFTNRStatus.SelectedItem.Text != "--Select--")
            {
                FTNRStatus = ddlFTNRStatus.SelectedItem.Text;

                FTNRStatusCode = ddlFTNRStatus.SelectedValue;
            }
            else
            {
                ddlFTNRStatus.SelectedIndex = 0;
            }

            DataTable = (DataTable)ViewState["DataTable"];

            DataTable.Rows.Add(ddlDiscrepancy.SelectedItem.Text, ddlDiscrepancy.SelectedValue, txtDiscrepancyRemarks.Text.Trim(), FTNRStatus, FTNRStatusCode);

            gvdis.DataSource = DataTable;
            gvdis.DataBind();

            ddlDiscrepancy.SelectedIndex = 0;
            ddlFTNRStatus.SelectedIndex = 0;
            txtDiscrepancyRemarks.Text = "";


        }

        protected void lkbtnEdit_Click(object sender, EventArgs e)
        {

            ddlFTNRStatus.Visible = true;
            lblFTNRStatus.Visible = true;

            LinkButton btn = (LinkButton)sender;
            GridViewRow gr = (GridViewRow)btn.NamingContainer;
            int index = gr.RowIndex;
            hdgvIDs.Value = Convert.ToString(index);

        
            ddlDiscrepancy.SelectedValue = gvdis.DataKeys[index]["DiscrepancyID"].ToString();


            txtDiscrepancyRemarks.Text = gr.Cells[2].Text.Trim();
            string data = gr.Cells[3].Text.Trim();



            if (txtDiscrepancyRemarks.Text == "&nbsp;")
            {
                txtDiscrepancyRemarks.Text = "";
            }
            else
            {
                txtDiscrepancyRemarks.Text = gr.Cells[2].Text.Trim();
            }



            if (data == "Resolved" || data == "Resolved With Deviation")
            {
                ddlFTNRStatus.ClearSelection();
                ddlFTNRStatus.Items.FindByText(data).Selected = true;
                //ddlFTNRStatus.SelectedValue = gvdis.DataKeys[index]["FTNRStatusCode"].ToString();|| data== "Resolve with" row.Cells[8].Text.ToString().Trim();
            }
            else
            {
                ddlFTNRStatus.SelectedIndex = 0;
            }


            DataTable = (DataTable)ViewState["DataTable"];
            DataTable.Rows[index].Delete();
            DataTable.AcceptChanges();
            gvdis.DataSource = DataTable;
            gvdis.DataBind();


        }
        protected void ClearData()
        {
            ddlLoginStatus.SelectedIndex = 0;

            ddlDiscrepancy.SelectedIndex = 0;



            txtDiscrepancyRemarks.Text = "";

            gvData.DataSource = null;
            gvData.DataBind();

            gvdis.DataSource = null;
            gvdis.DataBind();
        }

        protected void ddlLoginStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sel_loginstatus = ddlLoginStatus.SelectedItem.Text;

            if (sel_loginstatus == "FTR")
            {
                plDiscrepancy.Visible = false;
                DIV1.Visible = false;
                plLoginHold.Visible = false;

                //FTNRResolved.Visible = false;

                ddlFTNRStatus.Visible = false;
                lblFTNRStatus.Visible = false;
                btngotoTVR.Visible = true;


            }
            if (sel_loginstatus == "Hold")
            {
                plLoginHold.Visible = true;

                plDiscrepancy.Visible = false;
                DIV1.Visible = false;

                //FTNRResolved.Visible = false;

                ddlFTNRStatus.Visible = false;
                lblFTNRStatus.Visible = false;
                btngotoTVR.Visible = false;


            }

            if (sel_loginstatus == "FTNR")
            {
                plLoginHold.Visible = false;
                plDiscrepancy.Visible = true;
                DIV1.Visible = true;

                //FTNRResolved.Visible = false;

                ddlFTNRStatus.Visible = false;
                lblFTNRStatus.Visible = false;
                btngotoTVR.Visible = false;



            }
        }

        protected void btngotoTVR_Click(object sender, EventArgs e)
        {
            lblMsgXls.Text = " to be written - go to tvr";
            string APS_ID = Convert.ToString(ViewState["ApplicationID"]);
            if (Session["UserName"] != null)
            {
                bool result = SaveData();
                if (result)
                {

                    //CommonMaster commonMaster = new CommonMaster();
                    //int Result = commonMaster.UserLogOut(Convert.ToString(Session["LoginName"]));

                    //if (Result == 1)
                    //{
                     //   Session.Clear();
                      Response.Redirect("MFEDL_Pre_TVR.aspx?APS_ID=" + APS_ID, false);

                    
                }
            }
        }
    }
}