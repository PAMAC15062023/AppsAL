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
using YesBank;

namespace ChangeManagement
{
    public partial class CM_CR_Initiation : System.Web.UI.Page
    {
        string value;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindVertical();
                BindBranch();
                lblMsgXls.Visible = false;
            }
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
                    //lblMsgXls.Visible = true;
                    //lblMsgXls.Text = "Data Saved Succesfully";

                    lblMsgXls.Visible = true;
                    lblMsgXls.ForeColor = System.Drawing.Color.DarkOliveGreen;
                    lblMsgXls.Text = "CR No is:-" + value;

                    return;
                }
                //else
                //{
                //    lblMsgXls.Visible = true;
                //    lblMsgXls.Text = "Something went wrong, Data not Saved";
                //    Response.Redirect("CM_CR-Initiation.aspx", false);
                //}
            }
            else
            {
                //Session.Clear();
                Response.Redirect("CM_CR-Initiation.aspx", false);
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            //Session.Clear();
            Response.Redirect("CM_MenuPage.aspx", false);
        }

        private string SaveFile(FileUpload fileUpload, string uploadPath)
        {
            if (fileUpload.HasFile)
            {
                string fileName = Path.GetFileName(fileUpload.FileName);
                string filePath = Path.Combine(uploadPath, fileName);
                fileUpload.SaveAs(filePath);
                return fileName; // Return just the file name or relative path if needed
            }
            return null; // Or handle as needed if no file is uploaded
        }

        private bool SaveData()
        {
            bool validationresult = true;
            string msg = string.Empty;

            if (rblCRPriority.SelectedIndex == -1)
            {
                msg = msg + "Please Select CR Priority";
            }

            if (rblCRType.SelectedIndex == -1)
            {
                msg = msg + "Please Select CR Type";
            }

            if (ddlVertical.SelectedIndex == -1)
            {
                msg = msg + "Please Select Vertical ";
            }

            if (ddlBranch.SelectedIndex == -1)
            {
                msg = msg + "Please Select Branch";
            }

            if (ddlDepartmet.SelectedIndex == -1 || ddlDepartmet.SelectedIndex == 0)
            {
                msg = msg + "Please Select Department";
            }

            if (ddlDepartmet.SelectedIndex == 1 || (ddlDepartmet.SelectedIndex != 0 && ddlDepartmet.SelectedIndex != 2))
            {
                if (txtCRApplicationName.Text == "")
                {
                    msg = msg + "Please Enter Application Name";
                }
            }
            else
            {
                if (ddlDepartmet.SelectedIndex == 2)
                {
                    if (txtCRHardwareName.Text == "")
                    {
                        msg = msg + "Please Enter Hardware Name";
                    }
                }
            }

            if (txtCRApplicationName.Text != "" || txtCRHardwareName.Text != "")
            {
                if (txtCRReason.Text == "")
                {
                    msg = msg + "Please Enter Reason";
                }
            }


            if (msg != "")
            {
                validationresult = false;
                ClientScript.RegisterStartupScript(Page.GetType(), "mykey", "alert('" + msg + "');", true);
                return validationresult;
            }


            string uploadPath = Server.MapPath("~/Uploads/"); // Ensure this folder exists
            string filePath = SaveFile(xslCRFile, uploadPath);
            Session["filePath"] = filePath;   //add on 08/11/2024

            SqlConnection sqlCon = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());

            SqlCommand cmd = new SqlCommand("CM_InsertOrUpdate_CR_Initiation_SP", sqlCon);

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@UserID", Session["UserID"].ToString());

            cmd.Parameters.AddWithValue("@CR_Priority", rblCRPriority.SelectedItem.Text);
            cmd.Parameters.AddWithValue("@CR_Type", rblCRType.SelectedItem.Text);
            cmd.Parameters.AddWithValue("@CR_Vertical", ddlVertical.SelectedItem.Text);
            cmd.Parameters.AddWithValue("@CR_Branch", ddlBranch.SelectedValue);
            cmd.Parameters.AddWithValue("@CR_Department", ddlDepartmet.SelectedItem.Text);
            cmd.Parameters.AddWithValue("@CR_ApplicationName", txtCRApplicationName.Text.Trim());
            cmd.Parameters.AddWithValue("@CR_HardwareName", txtCRHardwareName.Text.Trim());
            cmd.Parameters.AddWithValue("@CR_ChangeReq", txtCRChangeRequirement.Text.Trim());
            cmd.Parameters.AddWithValue("@CR_File", string.IsNullOrEmpty(filePath) ? "" : filePath);
            cmd.Parameters.AddWithValue("@CR_Reason", txtCRReason.Text.Trim());
            cmd.Parameters.AddWithValue("@CR_ImpactAnalysis", txtCRImpactAnalysis.Text.Trim());
            cmd.Parameters.AddWithValue("@CR_AffectedModule", txtCRAffectedModule.Text.Trim());
            cmd.Parameters.AddWithValue("@CR_Remark", txtCRRemark.Text.Trim());



            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            sda.Fill(ds);


            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                value = ds.Tables[0].Rows[0]["CR_No"].ToString();
                lblMsgXls.Visible = true;
                lblMsgXls.ForeColor = System.Drawing.Color.DarkOliveGreen;
                lblMsgXls.Text = "CR No is:- " + value;
                ClearData();

                // Debugging line to check if the block is reached
                //Console.WriteLine("CR No is " + value);
            }
            else
            {
                lblMsgXls.Text = "No data found.";
            }

            return validationresult;

        }

        protected void ClearData()
        {

            rblCRPriority.ClearSelection();
            rblCRType.ClearSelection();
            xslCRFile.Attributes.Clear();
            txtCRApplicationName.Text = "";
            txtCRChangeRequirement.Text = "";
            txtCRReason.Text = "";
            txtCRImpactAnalysis.Text = "";
            txtCRAffectedModule.Text = "";
            txtCRHardwareName.Text = "";
            txtCRRemark.Text = "";
            ddlVertical.SelectedIndex = 0;
            ddlBranch.SelectedIndex = 0;
            ddlDepartmet.SelectedIndex = 0;
        }

        private void BrowseFile()
        {
            string newxlsfilename = "";
            try
            {
                lblMsgXls.Text = "";
                //Upload and save the file
                string excelPath = Server.MapPath("~/UploadedFiles/") + Path.GetFileName(xslCRFile.PostedFile.FileName);
                string fileName = Path.GetFileNameWithoutExtension(excelPath);
                string fileExtension = Path.GetExtension(excelPath);

                string datetime = DateTime.Now.ToString("yyyy-MM-dd HH mm ss");

                newxlsfilename = datetime + fileExtension; //"FEDBank_" +

                newxlsfilename = excelPath.Replace(Path.GetFileName(xslCRFile.PostedFile.FileName), newxlsfilename);

                lblMsgXls.Text = "File inserted Successfully";
            }
            catch (Exception ex)
            {
                lblMsgXls.Text = "Error:" + ex.Message;
                lblMsgXls.ForeColor = System.Drawing.Color.Red;

            }
        }

        protected void BindBranch()
        {
            try
            {
                SqlConnection sqlCon = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());

                SqlCommand sqlCom = new SqlCommand();
                sqlCom.Connection = sqlCon;
                sqlCom.CommandType = CommandType.StoredProcedure;
                sqlCom.CommandText = "CM_Branch_Master_SP";
                sqlCom.CommandTimeout = 0;

                SqlDataAdapter da = new SqlDataAdapter(sqlCom);
                DataSet ds = new DataSet();
                da.Fill(ds);

                if (ds != null && ds.Tables.Count > 0)
                {
                    ddlBranch.DataTextField = "BranchName";
                    ddlBranch.DataValueField = "BranchId";
                    ddlBranch.DataSource = ds.Tables[0];
                    ddlBranch.DataBind();

                    ddlBranch.Items.Insert(0, "--Select Branch--");
                    ddlBranch.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
            }
        }

        protected void BindVertical()
        {
            try
            {
                SqlConnection sqlCon = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());

                SqlCommand sqlCom = new SqlCommand();
                sqlCom.Connection = sqlCon;
                sqlCom.CommandType = CommandType.StoredProcedure;
                sqlCom.CommandText = "CM_Vertical_Master_SP";
                sqlCom.CommandTimeout = 0;

                SqlDataAdapter da = new SqlDataAdapter(sqlCom);
                DataSet ds = new DataSet();
                da.Fill(ds);

                if (ds != null && ds.Tables.Count > 0)
                {
                    ddlVertical.DataTextField = "vertical_name";
                    ddlVertical.DataValueField = "vertical_id";
                    ddlVertical.DataSource = ds.Tables[0];
                    ddlVertical.DataBind();

                    ddlVertical.Items.Insert(0, "--Select Vertical--");
                    ddlVertical.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
            }
        }

        protected void ddlDepartmet_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlDepartmet.SelectedItem.Text == "Software")
            {
                tbldept.Visible = true;  // Show the entire table
                department.Visible = true;  // Show the department row
                lblCRApplicationName.Visible = true;
                txtCRApplicationName.Visible = true;
                lblCRHardwareName.Visible = false;
                txtCRHardwareName.Visible = false;
            }
            else
            {
                tbldept.Visible = true;  // Show the entire table
                department.Visible = true;  // Show the department row
                lblCRApplicationName.Visible = false;
                txtCRApplicationName.Visible = false;
                lblCRHardwareName.Visible = true;
                txtCRHardwareName.Visible = true;
            }
        }
    }
}