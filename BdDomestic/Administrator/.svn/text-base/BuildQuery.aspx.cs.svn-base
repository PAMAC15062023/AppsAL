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

/// <summary>
/// Made by : Gargi Srivastava at 29-OCt-2007
/// Purpose : To Save and Update Query 
/// </summary>
public partial class Administrator_BuildQuery : System.Web.UI.Page
{
    CBuildQuery objBuildQuery = new CBuildQuery();
    CCommon con = new CCommon();
    protected void Page_Load(object sender, EventArgs e)
    {
       
        if (!IsPostBack)
        {
           
            if (Request.QueryString.Count!= 0)
            {
                if (Request.QueryString["QueryID"].ToString() != null && Request.QueryString["QueryID"].ToString() != "")
                {
                    hidQueryID.Value = Request.QueryString["QueryID"].ToString();
                }
                if ((Request.QueryString["Mode"].ToString() != null) && (Request.QueryString["Mode"].ToString() != ""))
                {
                    hidMode.Value = Request.QueryString["Mode"].ToString();
                }
            }
           
            if (hidMode.Value == "Edit")
            {
                ReadRecords();
                ReadTextFile();
            }
            if (hidMode.Value == "View")
            {
                ReadRecords();
                ReadTextFile();
                ReadOnly();
            }
            CheckPanel();
        }

    }
    protected void btnAppend_Click(object sender, EventArgs e)
    {
        CCommon obj = new CCommon();
        if (chkIsCriteria.Checked == true)
        {
            string Tdate="";
            string fromdate="";
            if (txtToDate.Text.Trim() != "")
            {
                Tdate = Convert.ToDateTime(con.strDate(txtToDate.Text.Trim())).AddDays(1.0).ToString("dd-MMM-yyyy");
            }

            string firstQuery =obj.FixQuotes(txtWriteQuery.Text.Trim().ToString());
            bool isCreteria=true;
            string alias = txtAlise.Text.Trim().ToString();
            if (txtFromDate.Text.Trim() != "")
            {
                fromdate = con.strDate(txtFromDate.Text.Trim());
            }
            string toDate = Tdate;
            string basedOn = "";
            if(ddlDateType.SelectedValue == "Received Date")
            {
                basedOn = "CASE_REC_DATETIME";
            }
            else if(ddlDateType.SelectedValue == "Send Date")
            {
                basedOn = "SEND_DATETIME";
            }


            string query = objBuildQuery.AppendQuery(firstQuery, isCreteria, alias, fromdate, toDate, basedOn);
            txtWriteQuery.Text = query;
            
        }
    }
    protected void btnSaveQuery_Click(object sender, EventArgs e)
    {
        PropertySet();
        string message = "";
        if (hidMode.Value == "Edit")
        {
            message = objBuildQuery.UpdateQuery();
            string fileName = ViewState["QueryTextFile"].ToString();
            DeleteTextFile(fileName);
            WriteTextFile();
            lblMessage.Text = message;
        }
        else
        {
            message = objBuildQuery.InsertQuery();
            if (message == "Record Saved Sucessfully.")
            {
                WriteTextFile();
            }
            lblMessage.Text = message;
        }
    }
    /// <summary>
    /// This method is used to assign the text value to the Class Properties
    /// </summary>
    private void PropertySet()
    {
        try
        {
            if (hidQueryID.Value != "")
            {
                objBuildQuery.QueryID = int.Parse(hidQueryID.Value.ToString());
            }
            objBuildQuery.QueryText = txtQueryDefination.Text.Trim().ToString() + ".txt";
            objBuildQuery.QueryType = "0";
            objBuildQuery.QueryDefination = txtQueryDefination.Text.Trim().ToString();
            objBuildQuery.Alias = txtAlise.Text.Trim().ToString();
            if (chkIsCriteria.Checked == true)
            {
                objBuildQuery.IsCreteria = "1";
            }
            else
            {
                objBuildQuery.IsCreteria = "0";
            }
            if (hidMode.Value != "Edit")
            {
                objBuildQuery.AddedBy = Session["UserName"].ToString();
                objBuildQuery.AddedDate = DateTime.Now.ToString();
            }
            else if (hidMode.Value == "Edit")
            {
                objBuildQuery.ModifiedBy = Session["UserName"].ToString();
                objBuildQuery.ModifiedDate = DateTime.Now.ToString();
            }
        }
        catch (Exception exp)
        {
            lblMessage.Text = "Error : " + exp.Message;
        }
        
    }
    protected void btnReset_Click(object sender, EventArgs e)
    {
        Reset();
    }
    /// <summary>
    /// This method is used to Reset the default Value to the ASP Controls
    /// </summary>
    private void Reset()
    {
        try
        {
            txtQueryDefination.Text = "";
            txtWriteQuery.Text = "";
            txtToDate.Text = "";
            txtFromDate.Text = "";
            chkIsCriteria.Checked = false;
            ddlDateType.SelectedIndex = 0;
            txtAlise.Text = "";
        }
        catch (Exception exp)
        {
            lblMessage.Text = "Error : " + exp.Message;
        }
        
    }
    /// <summary>
    /// This Method is Used to Execute the Query Writen in the text file.
    /// </summary>
    private void ExecuteQuery()
    {
        try
        {
            string query = txtWriteQuery.Text.Trim().ToString();
            DataSet dsExecute = new DataSet();
            dsExecute = objBuildQuery.ExecuteQuery(query);
            ViewState["v1"] = dsExecute;
            if (dsExecute.Tables.Count > 0)
            {
                gvExecuteQuery.Visible = true;
                gvExecuteQuery.DataSource = dsExecute;
                gvExecuteQuery.DataBind();
            }
            else
            {
                gvExecuteQuery.Visible = false;
            }
        }
        catch (Exception exp)
        {
            lblMessage.Text = "Error : " + exp.Message;
            gvExecuteQuery.Visible = false;
        }
        
    }
    protected void btnExecuteQuery_Click(object sender, EventArgs e)
    {
        lblMessage.Text = "";
        ExecuteQuery();
    }
    /// <summary>
    /// This Method is Used to Read the Records Saved in the 
    /// Database for the Written Query.
    /// </summary>
    private void ReadRecords()
    {
        OleDbDataReader oledbDataReader;
        try
        {
            oledbDataReader = objBuildQuery.ReadQueryRecords(hidQueryID.Value.ToString());
            if (oledbDataReader.Read())
            {

                if (!(oledbDataReader["Query_Defination"].ToString().Trim().Length.Equals(0)))
                
                    txtQueryDefination.Text = oledbDataReader["Query_Defination"].ToString();
                    ViewState["QueryDefinition"] = oledbDataReader["Query_Defination"].ToString();
                
                if (!(oledbDataReader["Query_Text_File"].ToString().Trim().Length.Equals(0)))
                
                    
                    ViewState["QueryTextFile"] = oledbDataReader["Query_Text_File"].ToString();
                

                if (!(oledbDataReader["Is_Creteria"].ToString().Trim().Length.Equals(0)))
                {
                    if (oledbDataReader["Is_Creteria"].ToString() == "0")
                    {
                        chkIsCriteria.Checked = false;
                    }
                    if (oledbDataReader["Is_Creteria"].ToString() == "1")
                    {
                        chkIsCriteria.Checked = true;
                    }
                }

                if (!(oledbDataReader["Alias"].ToString().Trim().Length.Equals(0)))

                    txtAlise.Text = oledbDataReader["Alias"].ToString();

            }
        }
        catch (Exception exp)
        {
            lblMessage.Text = "Error : " + exp.Message;
        }
    }
    /// <summary>
    /// This Metod is Used to Open the Page in Read Only Mode.
    /// </summary>
    private void ReadOnly()
    {
        try
        {
            txtQueryDefination.Enabled = false;
            txtWriteQuery.Enabled = false;
            txtFromDate.Enabled = false;
            txtToDate.Enabled = false;
            ddlDateType.Enabled = false;
            chkIsCriteria.Enabled = false;
            txtAlise.Enabled = false;
            btnAppend.Enabled = false;
            btnReset.Enabled = false;
            btnExecuteQuery.Enabled = false;
            btnSaveQuery.Enabled = false;
            btnExporttoExcel.Enabled = false;
            btnAssignedQuery.Enabled = false;
        }
        catch (Exception exp)
        {
            lblMessage.Text = "Error : " + exp.Message;
        }
    }
    /// <summary>
    /// This Method is Used to Export the Grid View Data to a Excel File
    /// </summary>
    /// <param name="rpt_header"></param>
    //private void ExportGridView(String rpt_header)
    //{
    //    try
    //    {
    //        string attachment = "attachment; filename=Contacts.xls";
    //        Response.ClearContent();
    //        Response.AddHeader("content-disposition", attachment);
    //        Response.ContentType = "application/ms-excel";
    //        StringWriter sw = new StringWriter();
    //        //System.Web.HttpContext.Current.Response.Write("<IMG height='25px' width='150px' src='" + Server.MapPath("../Images/pamaclogo.gif") + "'>");
    //        //System.Web.HttpContext.Current.Response.Write("<b><center><font size=3 face=Verdana color=white> " + " gg " + "</font></center></b>");
    //        //System.Web.HttpContext.Current.Response.Write("<b><center><font size=3 face=Verdana color=white> " + " gg " + "</font></center></b>");
    //        //System.Web.HttpContext.Current.Response.Write("<b><center><font size=3 face=Verdana color=white> " + " gg " + "</font></center></b>");
    //        //System.Web.HttpContext.Current.Response.Write("<b><center><font size=3 face=Verdana color=white> " + " gg " + "</font></center></b>");
    //        System.Web.HttpContext.Current.Response.Write("<b><center><font size=3 face=Verdana color=#0000FF>" + rpt_header + "</font></center></b>");
    //        HtmlTextWriter htw = new HtmlTextWriter(sw);
    //        gvExecuteQuery.RenderControl(htw);
    //        Response.Write(sw.ToString());
    //        Response.End();
    //    }
    //    catch (Exception exp)
    //    {
    //        lblMessage.Text = "Error : " + exp.Message;
    //    }
    //}
  
    //private void PrepareGridViewForExport(Control gv)
    //{

    //    LinkButton lb = new LinkButton();
    //    Literal l = new Literal();
    //    string name = String.Empty;
    //    try
    //    {
    //        for (int i = 0; i < gv.Controls.Count; i++)
    //        {
    //            if (gv.Controls[i].GetType() == typeof(LinkButton))
    //            {
    //                l.Text = (gv.Controls[i] as LinkButton).Text;
    //                gv.Controls.Remove(gv.Controls[i]);
    //                gv.Controls.AddAt(i, l);
    //            }
    //            else if (gv.Controls[i].GetType() == typeof(DropDownList))
    //            {
    //                l.Text = (gv.Controls[i] as DropDownList).SelectedItem.Text;
    //                gv.Controls.Remove(gv.Controls[i]);
    //                gv.Controls.AddAt(i, l);
    //            }
    //            else if (gv.Controls[i].GetType() == typeof(CheckBox))
    //            {
    //                l.Text = (gv.Controls[i] as CheckBox).Checked ? "True" : "False";
    //                gv.Controls.Remove(gv.Controls[i]);
    //                gv.Controls.AddAt(i, l);
    //            }
    //            if (gv.Controls[i].HasControls())
    //            {
    //                PrepareGridViewForExport(gv.Controls[i]);
    //            }
    //        }
    //    }
    //    catch (Exception exp)
    //    {
    //        lblMessage.Text = "Error : " + exp.Message;
    //    }
    //}
    //public override void VerifyRenderingInServerForm(Control control)
    //{
    //}
    protected void btnExporttoExcel_Click(object sender, EventArgs e)
    {
        //Export the GridView to Excel
        String rpt_header = lblreport.Text;
        if (gvExecuteQuery.Rows.Count > 0)
        {
            PrepareGridViewForExport(gvExecuteQuery);
            ExportGridView();
        }
        else
        { 
          
        }
    }
    private void PrepareGridViewForExport(Control gv1)
    {

        LinkButton lb = new LinkButton();
        Literal l = new Literal();
        string name = String.Empty;
        try
        {
            for (int i = 0; i < gv1.Controls.Count; i++)
            {
                if (gv1.Controls[i].GetType() == typeof(LinkButton))
                {
                    l.Text = (gv1.Controls[i] as LinkButton).Text;
                    gv1.Controls.Remove(gv1.Controls[i]);
                    gv1.Controls.AddAt(i, l);
                }
                else if (gv1.Controls[i].GetType() == typeof(DropDownList))
                {
                    l.Text = (gv1.Controls[i] as DropDownList).SelectedItem.Text;
                    gv1.Controls.Remove(gv1.Controls[i]);
                    gv1.Controls.AddAt(i, l);
                }
                else if (gv1.Controls[i].GetType() == typeof(CheckBox))
                {
                    l.Text = (gv1.Controls[i] as CheckBox).Checked ? "True" : "False";
                    gv1.Controls.Remove(gv1.Controls[i]);
                    gv1.Controls.AddAt(i, l);
                }
                if (gv1.Controls[i].HasControls())
                {
                    PrepareGridViewForExport(gv1.Controls[i]);
                }
            }
        }
        catch (Exception exp)
        {
            lblMessage.Text = "Error : " + exp.Message;
        }
    }
    //public override void VerifyRenderingInServerForm(Control control)
    //{
    //}
    
    private void ExportGridView()
    {
        try
        {
            GridView gv = new GridView();
            
            DataSet dsExecute = new DataSet();
            dsExecute = (DataSet)ViewState["v1"];
            gv.DataSource = dsExecute;
            gv.DataBind();
            string attachment = "attachment; filename=Contacts.xls";
            //Response.ClearContent();
            Response.AddHeader("content-disposition", attachment);
            Response.ContentType = "application/ms-excel";
            StringWriter sw = new System.IO.StringWriter();
            //System.Web.HttpContext.Current.Response.Write("<b><left><font size=3 face=Verdana color=#0000FF>" + rpt_header + "</font></left></br></b>");
            HtmlTextWriter htw = new HtmlTextWriter(sw);
            
            gv.RenderControl(htw);
            Response.Write(sw.ToString());
            Response.End();
            gv.Dispose();
            dsExecute.Dispose();
            dsExecute.Clear();
        }
        catch (Exception exp)
        {
            lblMessage.Text = "Error : " + exp.Message;
        }
    }
    public override void VerifyRenderingInServerForm(Control control)
    {

    }
    protected void btnAssignedQuery_Click(object sender, EventArgs e)
    {
        Response.Redirect("AssignRights.aspx");
    }
    /// <summary>
    /// This Method is Used to Write a Text Box Value to a 
    /// Text File in the Application.
    /// </summary>
    private void WriteTextFile()
    {
        try
        {
            System.IO.StreamWriter StreamWriter1 = new System.IO.StreamWriter(Server.MapPath("../SavedQueries/" + txtQueryDefination.Text.Trim() + ".txt"));
            StreamWriter1.WriteLine(txtWriteQuery.Text);
            StreamWriter1.Close();
            lblMessage.Text = "File Succesfully created!";
        }
        catch (Exception exp)
        {
            lblMessage.Text = "Error : " + exp.Message;
        }
    }
    /// <summary>
    /// This Method is used to Read a Text File.
    /// </summary>
    private void ReadTextFile()
    {
        try
        {
            if (System.IO.File.Exists(Server.MapPath("../SavedQueries/" + txtQueryDefination.Text.Trim() + ".txt")))
            {
                System.IO.StreamReader StreamReader1 = new System.IO.StreamReader(Server.MapPath("../SavedQueries/" + txtQueryDefination.Text.Trim() + ".txt"));
                txtWriteQuery.Text = StreamReader1.ReadToEnd();
                StreamReader1.Close();
            }
        }
        catch (Exception exp)
        {
            lblMessage.Text = "Error : " + exp.Message;
        }
    }
    /// <summary>
    /// This Method is Used to Delete a Priviously Stored Text File.
    /// </summary>
    /// <param name="fileName"></param>
    private void DeleteTextFile(string fileName)
    {
        try
        {
            FileInfo TheFile = new FileInfo(MapPath("../SavedQueries/" + fileName));
            if (TheFile.Exists)
            {
                File.Delete(MapPath("../SavedQueries/" + fileName));
            }
            else
            {
                throw new FileNotFoundException();
            }
        }
        catch (FileNotFoundException ex)
        {
            lblMessage.Text += ex.Message;
        }
        catch (Exception ex)
        {
            lblMessage.Text += ex.Message;
        }
    }
    private void CheckPanel()
    {
        if (chkIsCriteria.Checked == true)
        {
            tr_hide.Visible = true;
        }
        else
        {
            tr_hide.Visible = false;
        }
    }
    protected void chkIsCriteria_CheckedChanged(object sender, EventArgs e)
    {
        CheckPanel();
    }
}
