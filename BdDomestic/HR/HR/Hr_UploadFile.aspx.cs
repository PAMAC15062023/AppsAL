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

public partial class HR_HR_Hr_UploadFile : System.Web.UI.Page
{
    CHR_UploadFiles objHRUploadFiles = new CHR_UploadFiles();
    CCommon objCom = new CCommon();
    OleDbConnection sqlConn = new OleDbConnection();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            btnBatchUpload.Visible = false;
            tblLable.Visible = false;
        }
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        
        lblMessage.Text = "";
        lblEmpCode.Text = "";
        lblEmpName.Text = "";
        lblClusterName.Text = "";
        lblCentreName.Text = "";
        lblSubCentreName.Text = "";
        PropertySet();
        
        
        if ((txtEmpCode.Text.Trim() != "") && (txtEmployeeName.Text.Trim() == ""))
        {
            btnBatchUpload.Visible = true;
            tblLable.Visible = true;
            FillUploadGrid();
            gvUpload.Visible = true;
            GetLableValues(objHRUploadFiles.EmpCode);
            gvCheckSelect.Visible = false;
        }

        else if ((txtEmpCode.Text.Trim() != "") && (txtEmployeeName.Text.Trim() != ""))
        {
            btnBatchUpload.Visible = true;
            tblLable.Visible = true;
            FillUploadGrid();
            
            GetLableValues(objHRUploadFiles.EmpCode);
            gvUpload.Visible = true;
            gvCheckSelect.Visible = false;
        }
        else 
        {
            gvCheckSelect.Visible = true;
            tblLable.Visible = false;
            FillSelectionGrid();
            gvUpload.Visible = false;
            btnBatchUpload.Visible = false;
        }
        LinkViewVisibility();
       
    }
    private void FillSelectionGrid()
    {
        //DataTable dtNew = new DataTable();
        //DataRow dr;
        DataTable dt = new DataTable();
        //PropertySet();
        dt = objHRUploadFiles.GetUploadSelection();
        //dtNew.Columns.Add("#");
        //dtNew.Columns.Add("EMP Code");
        //dtNew.Columns.Add("Name");
        //dtNew.Columns.Add("Date of Joining");
        //dtNew.Columns.Add("Designation");
        //dtNew.Columns.Add("Department");
        //dtNew.Columns.Add("Unit");
        //dtNew.Columns.Add("Cluster Name");
        //dtNew.Columns.Add("Centre Name");
        //dtNew.Columns.Add("Sub-Centre Name");
        //dtNew.Columns.Add("Kit Received Date");

        if (dt.Rows.Count > 0)
        {
            //int j = 1;
            //for (int i = 0; i < dt.Rows.Count; i++)
            //{
            //    dr = dtNew.NewRow();
            //    dr[0] = j.ToString() + i;

            //    dr[1] = dt.Rows[i]["EMP Code"].ToString();
            //    dr[2] = dt.Rows[i]["Name"].ToString();
            //    dr[3] = dt.Rows[i]["Date of Joining"].ToString();
            //    dr[4] = dt.Rows[i]["Designation"].ToString();
            //    dr[5] = dt.Rows[i]["Department"].ToString();
            //    dr[6] = dt.Rows[i]["Unit"].ToString();
            //    dr[7] = dt.Rows[i]["Cluster Name"].ToString();
            //    dr[8] = dt.Rows[i]["Centre Name"].ToString();
            //    dr[9] = dt.Rows[i]["Sub-Centre Name"].ToString();
            //    dr[10] = dt.Rows[i]["Kit Received Date"].ToString();

            //    dtNew.Rows.Add(dr);
            gvCheckSelect.DataSource = dt;
            gvCheckSelect.DataBind();

        }
        else
        {
            gvCheckSelect.DataSource = null;

            gvCheckSelect.DataBind();
            btnBatchUpload.Visible = false;
            lblMessage.Text = "No Records Found!";
        }

    }
    private void FillUploadGrid()
    {
        //DataTable dtNew = new DataTable();
        //DataRow dr;
        DataTable dt = new DataTable();
        
        dt = objHRUploadFiles.GetUploadSearch();
        //dtNew.Columns.Add("#");
        //dtNew.Columns.Add("EMP Code");
        //dtNew.Columns.Add("Name");
        //dtNew.Columns.Add("Date of Joining");
        //dtNew.Columns.Add("Designation");
        //dtNew.Columns.Add("Department");
        //dtNew.Columns.Add("Unit");
        //dtNew.Columns.Add("Cluster Name");
        //dtNew.Columns.Add("Centre Name");
        //dtNew.Columns.Add("Sub-Centre Name");
        //dtNew.Columns.Add("Kit Received Date");

        if (dt.Rows.Count > 0)
        {
            //int j = 1;
            //for (int i = 0; i < dt.Rows.Count; i++)
            //{
            //    dr = dtNew.NewRow();
            //    dr[0] = j.ToString() + i;

            //    dr[1] = dt.Rows[i]["EMP Code"].ToString();
            //    dr[2] = dt.Rows[i]["Name"].ToString();
            //    dr[3] = dt.Rows[i]["Date of Joining"].ToString();
            //    dr[4] = dt.Rows[i]["Designation"].ToString();
            //    dr[5] = dt.Rows[i]["Department"].ToString();
            //    dr[6] = dt.Rows[i]["Unit"].ToString();
            //    dr[7] = dt.Rows[i]["Cluster Name"].ToString();
            //    dr[8] = dt.Rows[i]["Centre Name"].ToString();
            //    dr[9] = dt.Rows[i]["Sub-Centre Name"].ToString();
            //    dr[10] = dt.Rows[i]["Kit Received Date"].ToString();

            //    dtNew.Rows.Add(dr);
            gvUpload.DataSource=dt;
            gvUpload.DataBind();

            }
        else
        {
            gvUpload.DataSource = null;
            
            gvUpload.DataBind();
            btnBatchUpload.Visible = false;
            tblLable.Visible = false;
            lblMessage.Text = "No Records Found!";
        }
       
    }
    private void PropertySet()
    {
        try
        {
            if (txtEmpCode.Text == "")
            {
                objHRUploadFiles.EmpCode = null;
            }
            else
            {
                objHRUploadFiles.EmpCode = txtEmpCode.Text.Trim();
                hdnEmpCode.Value = txtEmpCode.Text.Trim();
            }
            if (txtEmployeeName.Text == "")
            {
                objHRUploadFiles.EmpName = null;
            }
            else
            {
                objHRUploadFiles.EmpName = txtEmployeeName.Text.Trim().Replace(' ','%');
            }
           
        }
        catch (Exception ex)
        {
            lblMessage.Text = "Error while retreiving records:Property Set " + ex.Message;
        }
    }

    private void CheckSelectedEmp()
    {
        if (gvCheckSelect.Rows.Count > 0)
        {

            for (int i = 0; i < gvCheckSelect.Rows.Count; i++)
            {
                GridViewRow dgRow = gvCheckSelect.Rows[i];
                RadioButton rdoSelect = (RadioButton)dgRow.Cells[0].FindControl("rdoSelect");
                if (rdoSelect.Checked == true)
                {
                    objHRUploadFiles.EmpCode = gvCheckSelect.DataKeys[i]["Employee Code"].ToString();
                    hdnEmpCode.Value = objHRUploadFiles.EmpCode;
                    tblLable.Visible = true;
                    GetLableValues(objHRUploadFiles.EmpCode);


                }
               
            }
        }
        else
        {
            PropertySet();
            tblLable.Visible = true;
            GetLableValues(objHRUploadFiles.EmpCode);
        }
        
               
    }
    private void BatchUploadFile()
    {
        if (gvUpload.Rows.Count > 0)
        {
            for (int i = 0; i < gvUpload.Rows.Count; i++)
            {
                FileUpload FileUploadC = new FileUpload();




                FileUploadC = (FileUpload)gvUpload.Rows[i].FindControl("FileUpload1");
                
                if (FileUploadC.HasFile == true)
                {
                    string strFile = FileUploadC.FileName.ToString();
                    string strFileContentType = FileUploadC.PostedFile.ContentType.ToString();
                    string[] strArrayFileContentType = strFileContentType.Split('/');
                    string[] strArrayFile = strFile.Split('.');
                    //for (int j = 0; j < strArrayFile.Length; j++)
                    //{
                    
                    string strFileType = "";
                    string strFileNameWithEmpCode = "";
                   
                    if (strArrayFile[1] != null && strArrayFile[1].ToString() != "")
                    {
                        
                        if (i == 0)
                        {
                            //if ((strArrayFile[1].ToString() == "bmp") || (strArrayFile[1].ToString() == "gif") || (strArrayFile[1].ToString() == "jpeg") || (strArrayFile[1].ToString() == "jpg") || (strArrayFile[1].ToString() == "png") || (strArrayFile[1].ToString() == "psd") || (strArrayFile[1].ToString() == "psp") || (strArrayFile[1].ToString() == "tif"))
                            //{
                            if (strArrayFileContentType[0] == "image")
                            {

                                //gvUpload.DataKeys[i]["UploadFilePath"].ToString();
                                //string strFilePath = Server.MapPath("Upload") + "\\" + strFile;
                                string strFilePath = Server.MapPath("EmployeePhoto") + "\\" + gvUpload.DataKeys[i]["Employee Code"] + "." + strArrayFile[1].ToString();
                                strFileNameWithEmpCode = gvUpload.DataKeys[i]["Employee Code"] + "." + strArrayFile[1].ToString();
                                DeleteEmployeePhoto(gvUpload.DataKeys[i]["UploadFilePath"].ToString());
                                //string strQuery = "Update Employee_Master set PHOTO_PATH='" + strFile + "' where EMP_ID=" + Convert.ToInt32(gvUpload.DataKeys[i]["ID"]);
                                //OleDbCommand sqlCmd = new OleDbCommand(strQuery, sqlConn);
                                //sqlConn.Open();
                                //int j = (int)sqlCmd.ExecuteNonQuery();
                                //sqlConn.Close();

                                objHRUploadFiles.UploadEmpMaster(strFileNameWithEmpCode, Convert.ToInt32(gvUpload.DataKeys[i]["ID"]));
                                if (FileUploadC.HasFile)
                                    FileUploadC.PostedFile.SaveAs(strFilePath);
                                
                            }
                            else
                            {
                                hidMessage.Value = "Please Select an Image File to Upload the Potograph.";
                            }
                        }
                        //else
                        //{
                        //    lblMessage.Text = "Please Select Valid File Format for Upload...";
                        //}


                        else
                        {
                            if (i >= 1)
                            {

                                //string strFilePath = Server.MapPath("Upload") + "\\" + strFile;
                                string strFilePath = Server.MapPath("EmployeeDocument") + "\\" + gvUpload.DataKeys[i]["Employee Code"] + strArrayFile[0].ToString() + "." + strArrayFile[1].ToString();
                                strFileNameWithEmpCode = gvUpload.DataKeys[i]["Employee Code"] + strArrayFile[0].ToString() + "." + strArrayFile[1].ToString();
                                DeleteEmployeeDocument(gvUpload.DataKeys[i]["UploadFilePath"].ToString());
                                //string strQuery = "Update EMPLOYEE_EDUCATION_QUALIFICATION set File_Path='" + strFile + "' where EMP_ID=" + Convert.ToInt32(gvUpload.DataKeys[i]["ID"]) + " and Education_Qualification_Id=" + Convert.ToInt32(gvUpload.DataKeys[i]["Education_Qualification_Id"]);
                                //SqlCommand sqlCmd = new SqlCommand(strQuery, sqlConn);
                                //sqlConn.Open();
                                //int j = (int)sqlCmd.ExecuteNonQuery();
                                //sqlConn.Close();

                                objHRUploadFiles.UploadEmpQualification(strFileNameWithEmpCode, Convert.ToInt32(gvUpload.DataKeys[i]["ID"]), Convert.ToInt32(gvUpload.DataKeys[i]["Education_Qualification_Id"]), "Yes");
                                FileUploadC.PostedFile.SaveAs(strFilePath);
                               
                            }
                            else
                            {

                            }
                        }

                    }
                }
            }
        }


                   

}
         
     

    private struct GridPosition
    {
        public const int ID = 0;
        public const int EMPLOYEECODE = 1;
        public const int NAME = 2;
        public const int DOCTYPE = 3;
        public const int EDUCATIONQUALIFICATIONID = 4;
        public const int DOCUMENTNAME = 5;
        public const int FILENAME = 6;
        public const int VIEWFILE = 7;


    }
    
    protected void btnBatchUpload_Click(object sender, EventArgs e)
    {
        hidMessage.Value = "";
        BatchUploadFile();

        CheckSelectedEmp();
        objHRUploadFiles.EmpCode=hdnEmpCode.Value;
        FillUploadGrid();

        LinkViewVisibility();
        lblMessage.Text = "";
        if (hidMessage.Value != "")
        {
            lblMessage.Text = hidMessage.Value;
        }
        else
        {
            lblMessage.Text = "File Uploaded Successfully!";
        }
        
    }
    protected void rdoSelect_CheckedChanged(object sender, EventArgs e)
    {

        RadioButton chk = (RadioButton)sender;
        hdnId.Value = chk.ClientID;


        foreach (GridViewRow row in gvCheckSelect.Rows)
        {
            RadioButton chk1 = (RadioButton)(row.FindControl("rdoSelect"));
           // HiddenField hdn = (HiddenField)(row.FindControl("hdnProfileId"));
            if (hdnId.Value == chk1.ClientID)
            {
                chk1.Checked = true;
                //Session["AuthenticatinProfileId"] = hdn.Value;
            }
            else
            {
                chk1.Checked = false;
            }
        }


        gvUpload.Visible = true;
        btnBatchUpload.Visible = true;
        CheckSelectedEmp();
        lblMessage.Text = "";
        FillUploadGrid();
        LinkViewVisibility();
       
    }
    private void GetLableValues(string empCode)
    {
       
        OleDbDataReader oledbDRGet;

        oledbDRGet = objHRUploadFiles.GetRecordsofLable(empCode);
        if (oledbDRGet.Read())
        {
            if (!(oledbDRGet["Employee Code"].ToString().Trim().Length.Equals(0)))
                lblEmpCode.Text = oledbDRGet["Employee Code"].ToString();

            if (!(oledbDRGet["Name"].ToString().Trim().Length.Equals(0)))
                lblEmpName.Text = oledbDRGet["Name"].ToString();

            if (!(oledbDRGet["Cluster Name"].ToString().Trim().Length.Equals(0)))
                lblClusterName.Text = oledbDRGet["Cluster Name"].ToString();

            if (!(oledbDRGet["Centre Name"].ToString().Trim().Length.Equals(0)))
                lblCentreName.Text = oledbDRGet["Centre Name"].ToString();

            if (!(oledbDRGet["Subcentre Name"].ToString().Trim().Length.Equals(0)))
                lblSubCentreName.Text = oledbDRGet["Subcentre Name"].ToString();

        }
        else
        oledbDRGet.Close();
        oledbDRGet.Dispose();
    }

    private void LinkViewVisibility()
    {
        for (int i = 0; i < gvUpload.Rows.Count; i++)
        {
            if (gvUpload.DataKeys[i]["UploadFilePath"].ToString() != null && (gvUpload.DataKeys[i]["UploadFilePath"].ToString()) != "")
            {
                GridViewRow gvRow = gvUpload.Rows[i];
                HyperLink lnkViewPhoto = (HyperLink)gvRow.Cells[GridPosition.VIEWFILE].FindControl("lnkViewPhoto");
                HyperLink lnkViewDocument = (HyperLink)gvRow.Cells[GridPosition.VIEWFILE].FindControl("lnkViewDocument");
                if (i == 0)
                {
                    lnkViewPhoto.Visible = true;
                }
                else if (i >= 1)
                {
                    lnkViewDocument.Visible = true;
                }
            }
        }
    }


    protected void gvUpload_DataBound(object sender, EventArgs e)
    {
        Session["RowCount"] = gvUpload.Rows.Count;
    }
    protected void gvUpload_RowCommand(object sender, GridViewCommandEventArgs e)
    {

            string queryArgument = e.CommandArgument.ToString();
       
            string empID="";
            string qID="";
            string textFileName = "";
            string DocumentName ="";
           string empCode="";
           string[] arrQuery = queryArgument.Split('*');
           // for (int i = 0; i < arrQuery.Length-1; i++)
             // {
                //  if (arrQuery[0].Length > 0)
                // {
                     empCode = arrQuery[0].ToString();
                // }
                 //if (arrQuery[1].Length > 0)
                 //{
                     empID = arrQuery[1].ToString();
                // }
               // if (arrQuery[2].Length > 0)
                // {
                     qID = arrQuery[2].ToString();
                // }
                 //if (arrQuery[3].Length > 0)
                // {
                     DocumentName = arrQuery[3].ToString();
                // }
                //if (arrQuery[4].Length > 0)
                //{
                    textFileName = arrQuery[4].ToString();
                //}
             //}
                     if ((textFileName == "") || (textFileName == null))
                     {
                         this.Page.ClientScript.RegisterStartupScript(this.GetType(),"","<script language=javascript>alert('File does not exists !')</script>");
                     }
                     else
                     {
                         
                         if (DocumentName == "Photograph")
                         {


                             DeleteEmployeePhoto(textFileName);
                             objHRUploadFiles.UploadEmpMaster("", Convert.ToInt32(empID));
                         }


                         else
                         {

                             DeleteEmployeeDocument(textFileName);
                             objHRUploadFiles.UploadEmpQualification("", Convert.ToInt32(empID), Convert.ToInt32(qID),"No");

                         }
                         lblMessage.Text = "File Deteted Successfully.";
                         objHRUploadFiles.EmpCode = empCode;
                         FillUploadGrid();
                         LinkViewVisibility();
                         
                     }

             
        

    }
    protected void gvUpload_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        //if (e.Row.RowType == DataControlRowType.DataRow)
        //{
        //    LinkButton lbDelete = (LinkButton)e.Row.FindControl("lbDelete");

        //    if ((e.Row.Cells[6].Text == "") || (e.Row.Cells[6].Text == null))
        //    {
        //        lbDelete.Attributes.Add("onclick", "javascript:return " +
        //                   "confirm('The File does not Exist')");
        //    }
        //    else
        //    {

        //        lbDelete.Attributes.Add("onclick", "javascript:return " +
        //                      "confirm('Are you sure you want to delete this record')");
        //    }
        //}
    }

    private void DeleteEmployeePhoto(string fileName)
    {
        try
        {
            FileInfo TheFile = new FileInfo(MapPath("EmployeePhoto" + "//" + fileName));
            if (TheFile.Exists)
            {
                File.Delete(MapPath("EmployeePhoto" + "//" + fileName));
            }
            //else
            //{
            //    throw new FileNotFoundException();
            //}
        }
        //catch (FileNotFoundException ex)
        //{
        //    lblMessage.Text += ex.Message;
        //}
        catch (Exception ex)
        {
            lblMessage.Text += ex.Message;
        }
    }

    private void DeleteEmployeeDocument(string fileName)
    {
        try
        {
            FileInfo TheFile = new FileInfo(MapPath("EmployeeDocument" + "//" + fileName));
            if (TheFile.Exists)
            {
                File.Delete(MapPath("EmployeeDocument" + "//" + fileName));
            }
            //else
            //{
            //    throw new FileNotFoundException();
            //}
        }
        //catch (FileNotFoundException ex)
        //{
        //    lblMessage.Text += ex.Message;
        //}
        catch (Exception ex)
        {
            lblMessage.Text += ex.Message;
        }
    }




    
}
