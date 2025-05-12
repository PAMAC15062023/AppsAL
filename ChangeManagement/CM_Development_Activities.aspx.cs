using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;

namespace ChangeManagement
{
    public partial class CM_Development_Activities : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetData_In_Grid();
                panel1.Visible = false;
            }
        }

        private void GetData_In_Grid()
        {
            SqlConnection sqlCon = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());

            SqlCommand sqlCom = new SqlCommand();
            sqlCom.Connection = sqlCon;
            sqlCom.CommandType = CommandType.StoredProcedure;
            sqlCom.CommandText = "CM_GetData_For_VH_Approval_SP";
            sqlCom.CommandTimeout = 0;

            SqlParameter UserID = new SqlParameter();
            UserID.SqlDbType = SqlDbType.VarChar;
            UserID.Value = Convert.ToString(Session["UserID"]);
            UserID.ParameterName = "@UserID";
            sqlCom.Parameters.Add(UserID);

            SqlParameter RoleID = new SqlParameter();
            RoleID.SqlDbType = SqlDbType.VarChar;
            RoleID.Value = Convert.ToString(Session["Roleid"]);
            RoleID.ParameterName = "@RoleID";
            sqlCom.Parameters.Add(RoleID);


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
            }
        }

        protected void Fetch_Values_In_Fields()
        {
            SqlConnection sqlCon = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());

            SqlCommand sqlCom = new SqlCommand();
            sqlCom.Connection = sqlCon;
            sqlCom.CommandType = CommandType.StoredProcedure;
            sqlCom.CommandText = "CM_Bind_CR_Initiation_Details_In_Fields_SP";
            sqlCom.CommandTimeout = 0;

            SqlParameter CRNo = new SqlParameter();
            CRNo.SqlDbType = SqlDbType.VarChar;
            CRNo.Value = Session["CR_No"].ToString();
            CRNo.ParameterName = "@CR_No";
            sqlCom.Parameters.Add(CRNo);

            SqlParameter Roleid = new SqlParameter();
            Roleid.SqlDbType = SqlDbType.Int;
            Roleid.Value = Convert.ToInt32(Session["Roleid"]);
            Roleid.ParameterName = "@RoleID";
            sqlCom.Parameters.Add(Roleid);

            SqlDataAdapter da = new SqlDataAdapter(sqlCom);
            DataSet ds = new DataSet();
            da.Fill(ds);

            if (ds != null && ds.Tables.Count > 0)
            {
                txtCRNo.Text = ds.Tables[0].Rows[0]["CR_No"].ToString();
                txtCRDate.Text = ds.Tables[0].Rows[0]["CR_Date"].ToString(); 
                txtCRRaisedBy.Text = ds.Tables[0].Rows[0]["CR_Raised_By"].ToString();
                txtCRPriority.Text = ds.Tables[0].Rows[0]["CR_Priority"].ToString();
                txtCRType.Text = ds.Tables[0].Rows[0]["CR_Type"].ToString();
                txtVertical.Text = ds.Tables[0].Rows[0]["CR_Vertical"].ToString();
                txtBranch.Text = ds.Tables[0].Rows[0]["BranchName"].ToString();
                txtDepartment.Text = ds.Tables[0].Rows[0]["CR_Department"].ToString();
                txtCRApplicationName.Text = ds.Tables[0].Rows[0]["CR_ApplicationName"].ToString();
                txtCRHardwareName.Text = ds.Tables[0].Rows[0]["CR_HardwareName"].ToString();
                txtCRChangeRequirement.Text = ds.Tables[0].Rows[0]["CR_ChangeRequirement"].ToString();

                if (ds.Tables[0].Rows[0]["CR_File"].ToString() != "")
                {
                    lkbtnxslCRFile.Text = ds.Tables[0].Rows[0]["CR_File"].ToString();
                }
                else
                {
                    lkbtnxslCRFile.Text = "No file Uploaded";
                    lkbtnxslCRFile.Enabled = false;
                }

                txtCRReason.Text = ds.Tables[0].Rows[0]["CR_Reason"].ToString();
                txtCRImpactAnalysis.Text = ds.Tables[0].Rows[0]["CR_ImpactAnalysis"].ToString();
                txtCRAffectedModule.Text = ds.Tables[0].Rows[0]["CR_Affected_Module"].ToString();
                txtCRRemark.Text = ds.Tables[0].Rows[0]["CR_Remark"].ToString();
                txtVHRemark.Text = ds.Tables[0].Rows[0]["VH_Remark"].ToString();
                txtVHApprovalDate.Text = ds.Tables[0].Rows[0]["VH_Approval_date"].ToString();
                txtVHName.Text = ds.Tables[0].Rows[0]["VH_Name"].ToString();
                txtReviewerRemark.Text = ds.Tables[0].Rows[0]["Reviewer_Remark"].ToString();
                txtREVApprovalDate.Text =  ds.Tables[0].Rows[0]["Rev_Approval_date"].ToString();
                txtREVName.Text = ds.Tables[0].Rows[0]["Rev_Name"].ToString();
                if(ds.Tables[0].Rows[0]["Clarification_Required"].ToString()!="")
                {
                    ddlAnyClarificationRequired.SelectedItem.Text = ds.Tables[0].Rows[0]["Clarification_Required"].ToString();
                }
                else
                {
                    ddlAnyClarificationRequired.SelectedIndex = 0;
                }
                
                txtClarification.Text= ds.Tables[0].Rows[0]["Clarification"].ToString();
                if (ds.Tables[0].Rows[0]["First_Clarification_sought_date"].ToString() != "")
                {
                    txtFirstClarificationSoughtDate.Text = strDate(ds.Tables[0].Rows[0]["First_Clarification_sought_date"].ToString());
                }
                else
                {
                    txtFirstClarificationSoughtDate.Text = ds.Tables[0].Rows[0]["First_Clarification_sought_date"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Final_Clarification_received_date"].ToString() != "")
                {
                    txtFinalClarificationReceivedDate.Text = strDate(ds.Tables[0].Rows[0]["Final_Clarification_received_date"].ToString());
                }
                else
                {
                    txtFinalClarificationReceivedDate.Text = ds.Tables[0].Rows[0]["Final_Clarification_received_date"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Estimated_date_of_delivery"].ToString() != "")
                {
                    txtEstimatedDateOfDelivery.Text = strDate(ds.Tables[0].Rows[0]["Estimated_date_of_delivery"].ToString());
                    txtEstimatedDateOfDelivery.Enabled = false;
                }
                else
                {
                    txtEstimatedDateOfDelivery.Text = ds.Tables[0].Rows[0]["Estimated_date_of_delivery"].ToString();
                }
                if(ds.Tables[0].Rows[0]["Allocated_to_developer_date"].ToString()!="")
                {
                    txtAllocatedToDeveloperDate.Text = strDate(ds.Tables[0].Rows[0]["Allocated_to_developer_date"].ToString());
                }
                else
                {
                    txtAllocatedToDeveloperDate.Text = ds.Tables[0].Rows[0]["Allocated_to_developer_date"].ToString();
                }
                if(ds.Tables[0].Rows[0]["Given_for_UAT_date"].ToString()!="")
                {
                    txtGivenForUATDate.Text = strDate(ds.Tables[0].Rows[0]["Given_for_UAT_date"].ToString());
                }
                else
                {
                    txtGivenForUATDate.Text = ds.Tables[0].Rows[0]["Given_for_UAT_date"].ToString();
                }
                if(ds.Tables[0].Rows[0]["UAT_confirmation_received_date"].ToString()!="")
                {
                    txtUATConfirmationReceivedDate.Text = strDate(ds.Tables[0].Rows[0]["UAT_confirmation_received_date"].ToString());
                }
                else
                {
                    txtUATConfirmationReceivedDate.Text = ds.Tables[0].Rows[0]["UAT_confirmation_received_date"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Actual_Date_Of_Delivery"].ToString() != "" && ds.Tables[0].Rows[0]["Actual_Date_Of_Delivery"].ToString() != "01-01-1900 12.00.00 AM" && ds.Tables[0].Rows[0]["Actual_Date_Of_Delivery"].ToString() != "1900-01-01")
                {
                    txtActualDeliveryDate.Text = strDate(ds.Tables[0].Rows[0]["Actual_Date_Of_Delivery"].ToString());
                }
                else
                {
                    txtActualDeliveryDate.Text = ds.Tables[0].Rows[0]["Actual_Date_Of_Delivery"].ToString();
                }
                txtDEVORITRemark.Text = ds.Tables[0].Rows[0]["DEV_Or_IT_Remark"].ToString();

                if(ds.Tables[0].Rows[0]["Clarification_Required"].ToString() == "Yes")
                {
                    ddlAnyClarificationRequired.Enabled = false;

                    lblClarification.Visible = true;
                    txtClarification.Visible = true;
                    txtClarification.Enabled = false;

                    FNFClarification.Visible = true;

                    lblFirstClarificationSoughtDate.Visible = true;
                    txtFirstClarificationSoughtDate.Visible = true;
                    txtFirstClarificationSoughtDate.Enabled = false;

                    lblFinalClarificationReceivedDate.Visible = true;
                    txtFinalClarificationReceivedDate.Visible = true;
                    txtFinalClarificationReceivedDate.Enabled = false;
                }

                if (txtDepartment.Text == "Software")
                {
                    lblHeader.InnerText = "Development Activities";

                    lblCRApplicationName.Visible = true;
                    txtCRApplicationName.Visible = true;
                    txtCRApplicationName.Enabled = false;

                    lblCRHardwareName.Visible = false;
                    txtCRHardwareName.Visible = false;
                    txtCRHardwareName.Enabled = false;

                    lblEstimatedDateOfDelivery.Visible = true;
                    txtEstimatedDateOfDelivery.Visible = true;
                    if(ds.Tables[0].Rows[0]["Estimated_date_of_delivery"].ToString() != "")
                    {
                        txtEstimatedDateOfDelivery.Enabled = false; //Enabled=false in old
                    }
                    else
                    {
                        txtEstimatedDateOfDelivery.Enabled = true; //Enabled=false in old
                    }
                    

                    lblAllocatedToDeveloperDate.Visible = true;
                    txtAllocatedToDeveloperDate.Visible = true;

                    UATDate.Visible = true;
                    lblGivenForUATDate.Visible = true;
                    txtGivenForUATDate.Visible = true;
                    lblUATConfirmationReceivedDate.Visible = true;
                    txtUATConfirmationReceivedDate.Visible = true;

                    lblActualDeliveryDate.Visible = false;
                    txtActualDeliveryDate.Visible = false;
                    lblDEVORITRemark.Visible = true;
                    txtDEVORITRemark.Visible = true;

                }
                else
                {
                    lblHeader.InnerText = "Information Technology Equipment Activities ";

                    lblCRApplicationName.Visible = false;
                    txtCRApplicationName.Visible = false;
                    txtCRApplicationName.Enabled = false;

                    lblCRHardwareName.Visible = true;
                    txtCRHardwareName.Visible = true;
                    txtCRHardwareName.Enabled = false;

                    lblEstimatedDateOfDelivery.Visible = true;
                    txtEstimatedDateOfDelivery.Visible = true;
                    txtEstimatedDateOfDelivery.Enabled = true;

                    lblAllocatedToDeveloperDate.Visible = false;
                    txtAllocatedToDeveloperDate.Visible = false;

                    UATDate.Visible = false;
                    lblGivenForUATDate.Visible = false;
                    txtGivenForUATDate.Visible = false;
                    lblUATConfirmationReceivedDate.Visible = false;
                    txtUATConfirmationReceivedDate.Visible = false;

                    lblActualDeliveryDate.Visible = true;
                    txtActualDeliveryDate.Visible = true;
                    lblDEVORITRemark.Visible = true;
                    txtDEVORITRemark.Visible = true;
                }
                if(ddlAnyClarificationRequired.SelectedItem.Text == "--Select--")
                {
                    lblClarification.Visible = false;
                    txtClarification.Visible = false;
                }
                
            }
            else
            {

            }
        }
        public string strDate(string strInDate)
        {
            string strDD = strInDate.Substring(0, 2);

            string strMM = strInDate.Substring(3, 2);

            string strYYYY = strInDate.Substring(6, 4);

            string strYYYYMMDD = strYYYY + "-" + strMM + "-" + strDD;

            //string strMMDDYYYY = strDD + "/" + strMM + "/" + strYYYY;

            DateTime dtConvertDate = Convert.ToDateTime(strYYYYMMDD);

            string strOutDate = dtConvertDate.ToString("yyyy-MM-dd");

            return strOutDate;
        }
        protected void ClearData()
        {
            txtCRNo.Text = "";
            txtCRDate.Text = "";
            txtCRPriority.Text = "";
            txtCRType.Text = "";
            txtVertical.Text = "";
            txtBranch.Text = "";
            txtDepartment.Text = "";
            txtCRRaisedBy.Text = "";
            txtCRApplicationName.Text = "";
            txtCRHardwareName.Text = "";
            txtCRChangeRequirement.Text = "";
            lkbtnxslCRFile.Attributes.Clear();
            lkbtnxslCRFile.Text = "";
            txtCRReason.Text = "";
            txtCRImpactAnalysis.Text = "";
            txtCRAffectedModule.Text = "";
            txtCRRemark.Text = "";
            txtVHRemark.Text = "";
            txtVHApprovalDate.Text = "";
            txtVHName.Text = "";
            txtReviewerRemark.Text = "";
            txtREVApprovalDate.Text = "";
            txtREVName.Text = "";
            ddlAnyClarificationRequired.SelectedIndex = 0;
            txtClarification.Text = "";
            txtFirstClarificationSoughtDate.Text = "";
            txtFinalClarificationReceivedDate.Text = "";
            txtEstimatedDateOfDelivery.Text = "";
            txtAllocatedToDeveloperDate.Text = "";
            txtGivenForUATDate.Text = "";
            txtUATConfirmationReceivedDate.Text = "";
            txtActualDeliveryDate.Text = "";
            txtDEVORITRemark.Text = "";
            //txtPMApprovalToGoLiveDate.Text = "";
            //txtOtherRemarks.Text = "";
            //txtPlacedInGoLiveDate.Text = "";
            //txtPMApprovalDate.Text = "";
            //txtPMName.Text = "";
        }

        private bool SaveData()
        {
            bool validationresult = true;
            string msg = string.Empty;


            if(txtDepartment.Text!="IT")
            {
                if(txtEstimatedDateOfDelivery.Text=="")
                {
                    msg = msg + "Please enter Estimated Date Of Delivery";
                }

                if (txtAllocatedToDeveloperDate.Text == "")
                {
                    msg = msg + "Please enter Allocated To Developer Date";
                }

                if (txtAllocatedToDeveloperDate.Text != "")
                {
                    if (txtGivenForUATDate.Text == "")
                    {
                        msg = msg + "Please Enter Given For UAT Date";
                    }
                }
                if(ddlAnyClarificationRequired.SelectedItem.Text == "Yes")
                {
                    if(txtClarification.Text=="")
                    {
                        msg = msg + "Please Enter Clarification";
                    }
                    if (txtFirstClarificationSoughtDate.Text == "")
                    {
                        msg = msg + "Please select First Clarification Sought Date";
                    }
                    if (txtFinalClarificationReceivedDate.Text == "")
                    {
                        msg = msg + "Please select Final Clarification Received Date";
                    }
                }

                //if(txtAllocatedToDeveloperDate.Text != "" && txtGivenForUATDate.Text != "")
                //{
                //    if (txtUATConfirmationReceivedDate.Text == "")
                //    {
                //        msg = msg + "Please Enter UAT Confirmation Received Date";
                //    }
                //}
            }
            else
            {
                if (txtEstimatedDateOfDelivery.Text == "")
                {
                    msg = msg + "Please enter Estimated Date Of Delivery";
                }

                if(txtActualDeliveryDate.Text=="")
                {
                    msg = msg + "Please enter Actual Delivery Date";
                }
                if (ddlAnyClarificationRequired.SelectedItem.Text=="Yes")
                {
                    if (txtClarification.Text == "")
                    {
                        msg = msg + "Please Enter Clarification";
                    }
                    if (txtFirstClarificationSoughtDate.Text == "")
                    {
                        msg = msg + "Please select First Clarification Sought Date";
                    }
                    if (txtFinalClarificationReceivedDate.Text == "")
                    {
                        msg = msg + "Please select Final Clarification Received Date";
                    }
                }
            }
            

            if (msg != "")
            {
                validationresult = false;
                ClientScript.RegisterStartupScript(Page.GetType(), "mykey", "alert('" + msg + "');", true);
                return validationresult;
            }

            SqlConnection sqlCon = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());

            SqlCommand cmd = new SqlCommand("CM_InsertOrUpdate_Development_Activities_SP", sqlCon);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@UserID", Convert.ToString(Session["UserID"]));
            cmd.Parameters.AddWithValue("@CR_No", txtCRNo.Text.Trim());
            cmd.Parameters.AddWithValue("@CR_Department", txtDepartment.Text.Trim());

            if (txtAllocatedToDeveloperDate.Text != "" && txtAllocatedToDeveloperDate.Text != "01-01-1900 12.00.00 AM")
            {
                cmd.Parameters.AddWithValue("@Allocated_to_developer_date", txtAllocatedToDeveloperDate.Text.Trim());
            }
            else
            {
                cmd.Parameters.AddWithValue("@Allocated_to_developer_date", DBNull.Value);
            }
            if (txtGivenForUATDate.Text != "" && txtGivenForUATDate.Text != "01-01-1900 12.00.00 AM")
            {
                cmd.Parameters.AddWithValue("@Given_for_UAT_date", txtGivenForUATDate.Text.Trim());
            }
            else
            {
                cmd.Parameters.AddWithValue("@Given_for_UAT_date", DBNull.Value);
            }
            if(txtUATConfirmationReceivedDate.Text!="" && txtUATConfirmationReceivedDate.Text != "01-01-1900 12.00.00 AM" && txtUATConfirmationReceivedDate.Text != "1900-01-01 00:00:00.000")
            {
                cmd.Parameters.AddWithValue("@UAT_confirmation_received_date", txtUATConfirmationReceivedDate.Text.Trim());
            }
            else
            {
                cmd.Parameters.AddWithValue("@UAT_confirmation_received_date", DBNull.Value);
            }
            //if (txtPMApprovalToGoLiveDate.Text != "" && txtPMApprovalToGoLiveDate.Text != "01-01-1900 12.00.00 AM")
            //{
            //    cmd.Parameters.AddWithValue("@PM_Approval_to_Go_live_date", txtPMApprovalToGoLiveDate.Text.Trim());
            //}
            //else
            //{
            //    cmd.Parameters.AddWithValue("@PM_Approval_to_Go_live_date", DBNull.Value);
            //}
            //if (txtPMApprovalDate.Text != "" && txtPMApprovalDate.Text != "01-01-1900 12.00.00 AM")
            //{
            //    cmd.Parameters.AddWithValue("@PM_Approval_Date", txtPMApprovalDate.Text.Trim());
            //}
            //else
            //{
            //    cmd.Parameters.AddWithValue("@PM_Approval_Date", DBNull.Value);
            //}
            //if (txtPlacedInGoLiveDate.Text != "" && txtPlacedInGoLiveDate.Text != "01-01-1900 12.00.00 AM")
            //{
            //    cmd.Parameters.AddWithValue("@Place_in_Go_Live_date", txtPlacedInGoLiveDate.Text.Trim());
            //}
            //else
            //{
            //    cmd.Parameters.AddWithValue("@Place_in_Go_Live_date", DBNull.Value);
            //}

            if (ddlAnyClarificationRequired.SelectedItem.Text != "--Select--")
            {
                cmd.Parameters.AddWithValue("@Clarification_Required", ddlAnyClarificationRequired.SelectedItem.Text.Trim());
            }
            else
            {
                cmd.Parameters.AddWithValue("@Clarification_Required", DBNull.Value);
            }

            if (ddlAnyClarificationRequired.SelectedItem.Text == "Yes")
            {
                cmd.Parameters.AddWithValue("@Clarification", txtClarification.Text.Trim());
                cmd.Parameters.AddWithValue("@First_Clarification_sought_date", txtFirstClarificationSoughtDate.Text.Trim());
                cmd.Parameters.AddWithValue("@Final_Clarification_received_date", txtFinalClarificationReceivedDate.Text.Trim());
            }
            else
            {
                cmd.Parameters.AddWithValue("@Clarification", DBNull.Value);
                cmd.Parameters.AddWithValue("@First_Clarification_sought_date", DBNull.Value);
                cmd.Parameters.AddWithValue("@Final_Clarification_received_date", DBNull.Value);
            }
            if (txtEstimatedDateOfDelivery.Text != "")
            {
                cmd.Parameters.AddWithValue("@Estimated_Date_Of_Delivery", txtEstimatedDateOfDelivery.Text.Trim());
            }
            else
            {
                cmd.Parameters.AddWithValue("@Estimated_Date_Of_Delivery", DBNull.Value);
            }
            if (txtDepartment.Text=="IT" && txtEstimatedDateOfDelivery.Text != "")
            {
                cmd.Parameters.AddWithValue("@Actual_Date_Of_Delivery", txtActualDeliveryDate.Text.Trim());
            }
            else
            {
                cmd.Parameters.AddWithValue("@Actual_Date_Of_Delivery", DBNull.Value);
            }

            cmd.Parameters.AddWithValue("@DEV_Or_IT_Remark", txtDEVORITRemark.Text.Trim());
            

            sqlCon.Open();
            int result = cmd.ExecuteNonQuery();
            sqlCon.Close();

            if (result > 0)
            {
                lblMsgXls.Visible = true;
                lblMsgXls.Text = "Data Saved Successfully";

                ClearData();


            }
            return validationresult;

        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (Session["UserName"] != null)
            {
                int RoleId = Convert.ToInt32(Session["RoleId"]);

                bool result = SaveData();
                if (result)
                {
                    //Session.Clear();
                    lblMsgXls.Visible = true;
                    lblMsgXls.Text = "Data Saved Succesfully";
                    //Response.Redirect("CM_Development_Activities.aspx", false);
                    return;
                }
                //else
                //{
                //    lblMsgXls.Visible = true;
                //    lblMsgXls.Text = "Something went wrong, Data not Saved";
                //    Response.Redirect("CM_Development_Activities.aspx", false);
                //}
            }
            else
            {
                //Session.Clear();
                Response.Redirect("CM_Development_Activities.aspx", false);
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            //Session.Clear();
            Response.Redirect("CM_MenuPage.aspx", false);
        }

        protected void lnkEdit_Click(object sender, EventArgs e)
        {
            lblMsgXls.Text = "";
            try
            {
                for (int i = 0; i <= gvData.Rows.Count - 1; i++)
                {
                    CheckBox chkSelect = (CheckBox)gvData.Rows[i].FindControl("chkSelect");

                    LinkButton WIP = (LinkButton)gvData.Rows[i].FindControl("lnkEdit");

                    if (chkSelect.Checked == true)
                    {
                        txtCRNo.Text = Convert.ToString(gvData.Rows[i].Cells[2].Text.Trim());
                        Session["CR_No"] = txtCRNo.Text;

                        panel1.Visible = true;
                        gvData.Visible = false;
                        panel2.Visible = false;

                        Fetch_Values_In_Fields();
                        Session["filePath"] = lkbtnxslCRFile.Text;
                        //Session["file2Path"] = lkbtnxslCRFile2.Text;
                        //Session["file3Path"] = lkbtnxslCRFile3.Text;
                        //Session["file4Path"] = lkbtnxslCRFile4.Text;

                        

                        if (txtAllocatedToDeveloperDate.Text!="" && txtGivenForUATDate.Text!="")
                        {
                            txtAllocatedToDeveloperDate.Enabled = false;
                            txtGivenForUATDate.Enabled = false;
                            if(txtUATConfirmationReceivedDate.Text=="")
                            {
                                txtUATConfirmationReceivedDate.Enabled = true;
                            }
                            else
                            {
                                txtUATConfirmationReceivedDate.Enabled = false;
                            }
                            
                        }
                    }
                    else
                    {
                        lblMsgXls.Visible = true;
                        lblMsgXls.Text = "Please Select Record...!!!";
                    }
                }



            }
            catch (Exception ex)
            {
                lblMsgXls.Visible = true;
                lblMsgXls.Text = "Error :" + ex.Message;
            }
        }


        protected void lkbtnxslCRFile_Click(object sender, EventArgs e)
        {
            string fileName = Convert.ToString(Session["filePath"]);

            if (!string.IsNullOrEmpty(fileName))
            {
                string filePath = Server.MapPath("~/Uploads/" + fileName);

                if (File.Exists(filePath))
                {
                    Response.ContentType = "application/octet-stream";
                    Response.AppendHeader("Content-Disposition", "attachment; filename=" + fileName); //filename = fileName1");
                    //Response.TransmitFile(Server.MapPath("~/Uploads/fileName1"));
                    Response.TransmitFile(filePath);
                    Response.End();
                }
                else
                {
                    // Handle the case when the file doesn't exist
                    //Response.Write("Error: File not found.");
                    lblMsgXls.Visible = true;
                    lblMsgXls.Text = "Error: File not found.";
                }
            }
            else
            {
                // Handle the case when fileName1 is empty or null
                //Response.Write("Error: File path is invalid.");
                lblMsgXls.Visible = true;
                lblMsgXls.Text = "File path is invalid.";
            }
        }

        private void Search_By_CRNo()
        {
            SqlConnection sqlCon = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());

            try
            {
                SqlCommand sqlCom = new SqlCommand();
                sqlCom.Connection = sqlCon;
                sqlCom.CommandType = CommandType.StoredProcedure;
                sqlCom.CommandText = "CM_CR_No_Search_SP";
                sqlCom.CommandTimeout = 0;

                SqlParameter userid = new SqlParameter();
                userid.SqlDbType = SqlDbType.VarChar;
                userid.Value = Session["UserID"].ToString();
                userid.ParameterName = "@UserID";
                sqlCom.Parameters.Add(userid);

                SqlParameter roleid = new SqlParameter();
                roleid.SqlDbType = SqlDbType.Int;
                roleid.Value = Convert.ToInt32(Session["Roleid"].ToString());
                roleid.ParameterName = "@RoleID";
                sqlCom.Parameters.Add(roleid);


                SqlParameter crno = new SqlParameter();
                crno.SqlDbType = SqlDbType.VarChar;
                if (!string.IsNullOrEmpty(txtsearch_crno.Text)) //(txtsearch_crno.Text != "")
                {
                    crno.Value = txtsearch_crno.Text.Trim();
                }
                else
                {
                    crno.Value = DBNull.Value;
                }
                crno.ParameterName = "@CR_No";
                sqlCom.Parameters.Add(crno);

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



                    DataTable dttest = (DataTable)gvData.DataSource;
                    //gvData.HeaderRow.Cells[gvData.HeaderRow.Cells.Count - 1].Visible = false;

                }
                else
                {
                    //lblcount.Text = "Total Case Count" + " " + "0";

                    gvData.DataSource = null;
                    gvData.DataBind();
                    lblMsgXls.Text = "No Record Found";

                }
            }
            catch (Exception ex)
            {
                lblMsgXls.Visible = true; //lblMsgXls
                lblMsgXls.Text = "Error :" + ex.Message;
            }
            finally
            {
                sqlCon.Close();
                sqlCon.Dispose();
            }
        }

        private void Search_By_DateRange()
        {
            SqlConnection sqlCon = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());

            try
            {
                SqlCommand sqlCom = new SqlCommand();
                sqlCom.Connection = sqlCon;
                sqlCom.CommandType = CommandType.StoredProcedure;
                sqlCom.CommandText = "CM_Date_Range_Search_SP";
                sqlCom.CommandTimeout = 0;

                SqlParameter userid = new SqlParameter();
                userid.SqlDbType = SqlDbType.VarChar;
                userid.Value = Session["UserID"].ToString();
                userid.ParameterName = "@UserID";
                sqlCom.Parameters.Add(userid);

                SqlParameter roleid = new SqlParameter();
                roleid.SqlDbType = SqlDbType.Int;
                roleid.Value = Convert.ToInt32(Session["Roleid"].ToString());
                roleid.ParameterName = "@RoleID";
                sqlCom.Parameters.Add(roleid);


                //SqlParameter crno = new SqlParameter();
                //crno.SqlDbType = SqlDbType.VarChar;
                //if (!string.IsNullOrEmpty(txtsearch_crno.Text)) //(txtsearch_crno.Text != "")
                //{
                //    crno.Value = txtsearch_crno.Text.Trim();
                //}
                //else
                //{
                //    crno.Value = DBNull.Value;
                //}
                //crno.ParameterName = "@CR_No";
                //sqlCom.Parameters.Add(crno);

                SqlParameter fromdate = new SqlParameter();
                fromdate.SqlDbType = SqlDbType.DateTime;
                if (!string.IsNullOrEmpty(txtFromDate.Text)) //(txtFromDate.Text!="")
                {
                    fromdate.Value = strDate(txtFromDate.Text);
                }
                else
                {
                    fromdate.Value = DBNull.Value;
                }

                fromdate.ParameterName = "@FromDate";
                sqlCom.Parameters.Add(fromdate);

                SqlParameter todate = new SqlParameter();
                todate.SqlDbType = SqlDbType.DateTime;
                if (!string.IsNullOrEmpty(txtToDate.Text)) //(txtToDate.Text!="")
                {
                    todate.Value = strDate(txtToDate.Text);
                }
                else
                {
                    todate.Value = DBNull.Value;
                }
                todate.ParameterName = "@ToDate";
                sqlCom.Parameters.Add(todate);

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
                    //lblcount.Visible = true;


                    DataTable dttest = (DataTable)gvData.DataSource;
                    //lblcount.Text = "Total Case Count" + " " + dttest.Rows.Count.ToString();

                    //gvData.HeaderRow.Cells[gvData.HeaderRow.Cells.Count - 1].Visible = false;

                }
                else
                {
                    //lblcount.Text = "Total Case Count" + " " + "0";

                    gvData.DataSource = null;
                    gvData.DataBind();
                    lblMsgXls.Text = "No Record Found";


                }
            }
            catch (Exception ex)
            {
                lblMsgXls.Visible = true; //lblMsgXls
                lblMsgXls.Text = "Error :" + ex.Message;
            }
            finally
            {
                sqlCon.Close();
                sqlCon.Dispose();
            }
        }

        protected void txtsearch_crno_TextChanged(object sender, EventArgs e)
        {
            lblMsgXls.Text = "";


            if (txtsearch_crno.Text.Trim() != "")
            {
                string crno = txtsearch_crno.Text.Trim();

                Search_By_CRNo();
            }
            else
            {
                //Search_By_CRNo();
                lblMsgXls.Text = "CR_No not found";
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            lblMsgXls.Text = "";


            if (txtFromDate.Text.Trim() != "" && txtToDate.Text.Trim() != "")
            {
                Search_By_DateRange();
            }
            else
            {
                //Search_By_DateRange();
                lblMsgXls.Text = "Please select Date";
            }
        }

        protected void ddlAnyClarificationRequired_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(ddlAnyClarificationRequired.SelectedItem.Text == "Yes")
            {
                FNFClarification.Visible = true;
                lblClarification.Visible = true;
                txtClarification.Visible = true;
                lblFirstClarificationSoughtDate.Visible = true;
                txtFirstClarificationSoughtDate.Visible = true;
                lblFinalClarificationReceivedDate.Visible = true;
                txtFinalClarificationReceivedDate.Visible = true;
            }
            else
            {
                FNFClarification.Visible = false;
                lblClarification.Visible = false;
                txtClarification.Visible = false;
                lblFirstClarificationSoughtDate.Visible = false;
                txtFirstClarificationSoughtDate.Visible = false;
                lblFinalClarificationReceivedDate.Visible = false;
                txtFinalClarificationReceivedDate.Visible = false;
            }
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("CM_MenuPage.aspx", false);
        }
    }
}