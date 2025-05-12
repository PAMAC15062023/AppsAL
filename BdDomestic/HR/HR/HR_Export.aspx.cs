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

public partial class HR_HR_HR_Export : System.Web.UI.Page
{
    CHR_Export objHRExport = new CHR_Export();
    CCommon objCom = new CCommon();
    protected void Page_Load(object sender, EventArgs e)
     {
         
        if (!IsPostBack)
        {
            FillCluster();

            ddlCentre.Items.Insert(0, new ListItem("All", "0"));
            ddlSubCentre.Items.Insert(0, new ListItem("All", "0"));
            Div1.Visible = false;
            btnExport.Visible = false;
            btnExort1.Visible = false;

        }


    }
    private void FillCluster()
    {
        DataTable dtCluster = new DataTable();
        dtCluster = objHRExport.GetClusterName();
        if (dtCluster.Rows.Count > 0)
        {
            ddlCluster.DataValueField = "CLUSTER_ID";
            ddlCluster.DataTextField = "CLUSTER_NAME";
            ddlCluster.DataSource = dtCluster;
            ddlCluster.DataBind();
        }
    }
    private void FillCentre()
    {
        DataTable dtCentre = new DataTable();
        string ClusterID = ddlCluster.SelectedValue;
        dtCentre = objHRExport.GetCentreName(ClusterID);
        if (dtCentre.Rows.Count > 0)
        {
            ddlCentre.DataValueField = "CENTRE_ID";
            ddlCentre.DataTextField = "CENTRE_NAME";
            ddlCentre.DataSource = dtCentre;
            ddlCentre.DataBind();
        }
    }
    private void FillSubCentre()
    {
        DataTable dtSubCentre = new DataTable();
        string CentreID = ddlCentre.SelectedValue;
        dtSubCentre = objHRExport.GetSubCentreName(CentreID);
        if (dtSubCentre.Rows.Count > 0)
        {
            ddlSubCentre.DataValueField = "SubCentreId";
            ddlSubCentre.DataTextField = "SubCentreName";
            ddlSubCentre.DataSource = dtSubCentre;
            ddlSubCentre.DataBind();
        }

    }
    protected void ddlCentre_SelectedIndexChanged(object sender, EventArgs e)
    {
        FillSubCentre();
        //BindNullGrid();
        //btnExort1.Visible = false;
        //btnExport.Visible = false;
        //Div1.Visible = false;
        lblMessage.Text = "";
    }
    protected void ddlCentre_DataBound(object sender, EventArgs e)
    {
        ddlCentre.Items.Insert(0, new ListItem("All", "0"));
    }
    protected void ddlCluster_DataBound(object sender, EventArgs e)
    {
        ddlCluster.Items.Insert(0, new ListItem("All", "0"));
    }
    protected void ddlSubCentre_DataBound(object sender, EventArgs e)
    {
        ddlSubCentre.Items.Insert(0, new ListItem("All", "0"));
    }
    private void PropertySet()
    {
        try
        {
            if (ddlCentre.SelectedValue == "0")
            {
                objHRExport.CentreID = null;
            }
            else
            {
                objHRExport.CentreID = ddlCentre.SelectedValue;
            }
            if (ddlCluster.SelectedValue == "0")
            {
                objHRExport.ClusterID = null;
            }
            else
            {
                objHRExport.ClusterID = ddlCluster.SelectedValue;
            }
            if (ddlSubCentre.SelectedValue == "0")
            {
                objHRExport.SubCentreID = null;
            }
            else
            {
                objHRExport.SubCentreID = ddlSubCentre.SelectedValue;
            }
            //if (txtTempEmpCode.Text == "")
            //{
            //    objHRExport.TempEmpCode = null;
            //}
            //else
            //{
            //    objHRExport.TempEmpCode = txtTempEmpCode.Text.Trim();
            //}

            //if (ddlEMPCode.SelectedValue == "-1")
            //{
            //    objHRExport.EmpCode = null;
            //}
            //else
            //{
            //    objHRExport.EmpCode = ddlEMPCode.SelectedValue;
            //}
            if (txtFrom.Text == "")
            {
                objHRExport.From = null;
            }
            else
            {
                DateTime sFromDate;

                sFromDate = Convert.ToDateTime(objCom.strDate(txtFrom.Text.ToString().Trim()));
                

                objHRExport.From = Convert.ToDateTime(sFromDate).ToString("MM/dd/yyyy");
            }
            if (txtTo.Text == "")
            {
                objHRExport.To = null;
            }
            else
            {
                DateTime sToDate;
                sToDate = Convert.ToDateTime(objCom.strDate(txtTo.Text.Trim())).AddDays(1.0);
                objHRExport.To = Convert.ToDateTime(sToDate).ToString("MM/dd/yyyy");
            }
        }
        catch (Exception ex)
        {
            lblMessage.Text = "Error while retreiving records:Property Set " + ex.Message;
        }
    }

    private DataTable FillGridFunction()
    {
        DataTable dtNew = new DataTable();
        DataRow dr;
        DataTable dt = new DataTable();
        PropertySet();
        dt = objHRExport.GetExportSearch();
        dtNew.Columns.Add("#");
        dtNew.Columns.Add("PAMACian Code");
        dtNew.Columns.Add("PAMACian Name");
        dtNew.Columns.Add("Date of Joining");
        dtNew.Columns.Add("Designation");
        dtNew.Columns.Add("Department");
        dtNew.Columns.Add("Unit");
        dtNew.Columns.Add("Cluster Name");
        dtNew.Columns.Add("Centre Name");
        dtNew.Columns.Add("Sub Centre Name");
        dtNew.Columns.Add("Kit Received Date");
      
        if (dt.Rows.Count > 0)
        {
            int j = 1;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dr = dtNew.NewRow();
                dr[0] = j + i;

                dr[1] = dt.Rows[i]["PAMACian Code"].ToString();
                dr[2] = dt.Rows[i]["PAMACian Name"].ToString();
                if ((dt.Rows[i]["Date of Joining"].ToString() == "") || (dt.Rows[i]["Date of Joining"].ToString() == null))
                    dr[3] = dt.Rows[i]["Date of Joining"].ToString();
                else
                    dr[3] = Convert.ToDateTime(dt.Rows[i]["Date of Joining"].ToString()).ToString("dd/MM/yyyy");
                dr[4] = dt.Rows[i]["Designation"].ToString();
                dr[5] = dt.Rows[i]["Department"].ToString();
                dr[6] = dt.Rows[i]["Unit"].ToString();
                dr[7] = dt.Rows[i]["Cluster Name"].ToString();
                dr[8] = dt.Rows[i]["Centre Name"].ToString();
                dr[9] = dt.Rows[i]["Sub Centre Name"].ToString();
                //if ((dt.Rows[i]["Kit Received Date"].ToString() == "") || (dt.Rows[i]["Kit Received Date"].ToString() == null))
                dr[10] = dt.Rows[i]["Kit Received Date"].ToString();
                //else
                //dr[10] = Convert.ToDateTime(dt.Rows[i]["Kit Received Date"].ToString()).ToString("dd/MM/yyyy");

                dtNew.Rows.Add(dr);

                  
        }
      }
        return dtNew;
   }
    private void FillExportGrid()
    {
        
        DataTable dtExport = new DataTable();
        
        dtExport = FillGridFunction();
        


        if (dtExport.Rows.Count > 0)
        {

            Div1.Visible = true;
            btnExport.Visible = true;
            btnExort1.Visible = true;
            gvExport.DataSource = dtExport;
            gvExport.DataBind();
        }
        else
        {
            Div1.Visible = false;
            btnExport.Visible = false;
            btnExort1.Visible = false;
            gvExport.DataSource = null;
            gvExport.DataBind();
            lblMessage.Text = "No Records Found !";
        }
        }
    
    protected void btnSearch_Click(object sender, EventArgs e)
     {
        lblMessage.Text = "";
        FillExportGrid();
        //hidSearch.Value = "Search";
       
        
    }
    public DataTable CreateDataTable()
    {

        DataTable dtNew = new DataTable();
        DataRow dr;
        DataTable dt = new DataTable();
        try
        {

            PropertySet();
            dt = objHRExport.GetExportSearch();

            dtNew.Columns.Add("#");
            dtNew.Columns.Add("PAMACian Code");
            dtNew.Columns.Add("PAMACian Name");
            dtNew.Columns.Add("Name OF Bank");
            dtNew.Columns.Add("A/C #");
            dtNew.Columns.Add("PAN#");
            dtNew.Columns.Add("Father's Name");
            dtNew.Columns.Add("DOB");
            dtNew.Columns.Add("Present Address");
            dtNew.Columns.Add("Tel No. Of Present Address");
            //New Added
            dtNew.Columns.Add("City");
            dtNew.Columns.Add("Pin Code");
            dtNew.Columns.Add("Permanent Address");
            dtNew.Columns.Add("Tel No.Permanent Address");
            dtNew.Columns.Add("Height");
            dtNew.Columns.Add("Weight");
            dtNew.Columns.Add("Blood Group");
            dtNew.Columns.Add("Sex");
            dtNew.Columns.Add("Marital Status");
            dtNew.Columns.Add("(If Married) Wife Name");
            dtNew.Columns.Add("Wife Age");
            dtNew.Columns.Add("Child Name1");
            dtNew.Columns.Add("Child Name2");
            dtNew.Columns.Add("Child Age1");
            dtNew.Columns.Add("Child Age2");
            dtNew.Columns.Add("Name Of College Institution1");
            dtNew.Columns.Add("Name Of College Institution2");
            dtNew.Columns.Add("Name Of College Institution3");
            dtNew.Columns.Add("From_To_Year1");
            dtNew.Columns.Add("From_To_Year2");
            dtNew.Columns.Add("From_To_Year3");
            dtNew.Columns.Add("Certificate Examination1");
            dtNew.Columns.Add("Certificate Examination2");
            dtNew.Columns.Add("Certificate Examination3");
            //dtNew.Columns.Add("QualificationType1");
            //dtNew.Columns.Add("QualificationType2");
            //dtNew.Columns.Add("QualificationType3");
            dtNew.Columns.Add("Div/Marks1");
            dtNew.Columns.Add("Div/Marks2");
            dtNew.Columns.Add("Div/Marks3");
            dtNew.Columns.Add("Copy Attached1");
            dtNew.Columns.Add("Copy Attached2");
            dtNew.Columns.Add("Copy Attached3");
            dtNew.Columns.Add("Professional Qalification");
            //dtNew.Columns.Add("Professional_Name of College Institution1");
            dtNew.Columns.Add("Professional_From_To_Year1");
            dtNew.Columns.Add("Professional_Certificate Examination1");
            //dtNew.Columns.Add("Professional_QualificationType1");
            dtNew.Columns.Add("Professional_Div/Marks1");
            dtNew.Columns.Add("Professional_Copy Attached1");
            dtNew.Columns.Add("Employers Name & Address");
            dtNew.Columns.Add("Employed From-To");
            dtNew.Columns.Add("Salary");
            dtNew.Columns.Add("Reason For Leaving");
            dtNew.Columns.Add("Designation And Nature Of Job");
            //New added
            dtNew.Columns.Add("Contact No Of Employer");
            dtNew.Columns.Add("Literary / Cultural / Art");
            dtNew.Columns.Add("Sports");
            dtNew.Columns.Add("Hobbies");
            dtNew.Columns.Add("Reference Name1");
            dtNew.Columns.Add("Reference Name2");
            dtNew.Columns.Add("Reference Address1");
            dtNew.Columns.Add("Reference Address2");
            dtNew.Columns.Add("Relation With Reference1");
            dtNew.Columns.Add("Relation With Reference2");
            dtNew.Columns.Add("Occupation Of Reference1");
            dtNew.Columns.Add("Occupation Of Reference2");
            dtNew.Columns.Add("Contact No Of Reference1");
            dtNew.Columns.Add("Contact No Of Reference2");
            dtNew.Columns.Add("Date of Joining");
            //New Added
            dtNew.Columns.Add("Date of Leaving");
            dtNew.Columns.Add("Designation");
            //New added
            dtNew.Columns.Add("Department");
            dtNew.Columns.Add("Centre Name");
            dtNew.Columns.Add("Sub Centre Name");
            dtNew.Columns.Add("Client Name");
            dtNew.Columns.Add("Product Name");
            dtNew.Columns.Add("Unit");
            dtNew.Columns.Add("Basic");
            dtNew.Columns.Add("HRA");
            dtNew.Columns.Add("SP Allowance");
            dtNew.Columns.Add("Gross Amt");
            dtNew.Columns.Add("Company Code");
            dtNew.Columns.Add("Approval Mail Date");
            dtNew.Columns.Add("Approved By");
            dtNew.Columns.Add("PAMACian Activity Manager Code");
            dtNew.Columns.Add("PAMACian Activity Manager Name");
            dtNew.Columns.Add("PAMACian Cluster HR Code");
            dtNew.Columns.Add("PAMACian Cluster HR Name");
            dtNew.Columns.Add("Kit Received Date");
            dtNew.Columns.Add("Verified And Updated By");
            dtNew.Columns.Add("Verified and updated on dtd.");
            //dtNew.Columns.Add("Language Known");
            dtNew.Columns.Add("Are Related To Any PAMACian");
            dtNew.Columns.Add("(If Related To Any PAMACian Then) Relationship");
            //New Added
            dtNew.Columns.Add("(If Related To Any  PAMACian Then) PAMACian Name");
            dtNew.Columns.Add("(If Related To Any  PAMACian Then) PAMACian Code");
            dtNew.Columns.Add("Have Been Involved In Any Court Proceeding");
            dtNew.Columns.Add("(If Yes Then )Court Proceeding Details");
            dtNew.Columns.Add("Have Suffered Any Contagious Disease");
            dtNew.Columns.Add("(If Yes Then)Contagious Disease Detail");
            dtNew.Columns.Add("Nominee Name");
            //dtNew.Columns.Add("PF#");
            //dtNew.Columns.Add("ESIC#");
            dtNew.Columns.Add("Type Of Category");



            if (dt.Rows.Count > 0)
            {
                int j = 1;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    GridViewRow dgRow = gvExport.Rows[i];
                    CheckBox chkSelect = (CheckBox)dgRow.Cells[GridPosition.Chk].FindControl("chkSelect");

                    if (chkSelect.Checked == true)
                    {


                        dr = dtNew.NewRow();
                        dr[0] = j.ToString();


                        dr[1] = dt.Rows[i]["PAMACian Code"].ToString();
                        dr[2] = dt.Rows[i]["PAMACian Name"].ToString();

                        //string strName = dt.Rows[i]["Name OF Bank"].ToString();
                        //string strFirstCahracter = "";

                        //strFirstCahracter = strName.StartsWith(.Substring(strName.Length+5);
                        //strFirstCahracter = strName.StartsWith("Other+");
                        if (dt.Rows[i]["Name OF Bank"].ToString().StartsWith("Other+"))
                        {
                            dr[3] = dt.Rows[i]["Name OF Bank"].ToString().Remove(0, 6);
                        }
                        else
                        {
                            dr[3] = dt.Rows[i]["Name OF Bank"].ToString();
                        }
                        dr[4] = dt.Rows[i]["A/C #"].ToString();
                        dr[5] = dt.Rows[i]["PAN#"].ToString();
                        dr[6] = dt.Rows[i]["Father's Name"].ToString();

                        if ((dt.Rows[i]["DOB"].ToString() == "") || (dt.Rows[i]["DOB"].ToString() == null))
                            dr[7] = dt.Rows[i]["DOB"].ToString();
                        else
                            dr[7] = Convert.ToDateTime(dt.Rows[i]["DOB"].ToString()).ToString("dd/MM/yyyy");

                        dr[8] = dt.Rows[i]["Present Address"].ToString();
                        dr[9] = dt.Rows[i]["Tel No. Of Present Address"].ToString();
                        //New Added
                        dr[10] = dt.Rows[i]["City"].ToString();
                        dr[11] = dt.Rows[i]["Pin Code"].ToString();
                        dr[12] = dt.Rows[i]["Permanent Address"].ToString();
                        dr[13] = dt.Rows[i]["Tel No.Permanent Address"].ToString();
                        dr[14] = dt.Rows[i]["Height"].ToString();
                        dr[15] = dt.Rows[i]["Weight"].ToString();
                        dr[16] = dt.Rows[i]["Blood Group"].ToString();
                        dr[17] = dt.Rows[i]["Sex"].ToString();
                        dr[18] = dt.Rows[i]["Marital Status"].ToString();
                        dr[19] = dt.Rows[i]["(If Married) Wife Name"].ToString();
                        dr[20] = dt.Rows[i]["Wife Age"].ToString();
                        dr[21] = dt.Rows[i]["Child Name1"].ToString();
                        dr[22] = dt.Rows[i]["Child Name2"].ToString();
                        dr[23] = dt.Rows[i]["Child Age1"].ToString();

                        dr[24] = dt.Rows[i]["Child Age2"].ToString();
                        dr[25] = dt.Rows[i]["Name Of College Institution1"].ToString();
                        dr[26] = dt.Rows[i]["Name Of College Institution2"].ToString();
                        dr[27] = dt.Rows[i]["Name Of College Institution3"].ToString();
                        dr[28] = dt.Rows[i]["From_To_Year1"].ToString();
                        dr[29] = dt.Rows[i]["From_To_Year2"].ToString();
                        dr[30] = dt.Rows[i]["From_To_Year3"].ToString();
                        dr[31] = dt.Rows[i]["Certificate Examination1"].ToString();
                        dr[32] = dt.Rows[i]["Certificate Examination2"].ToString();
                        dr[33] = dt.Rows[i]["Certificate Examination3"].ToString();
                        //dr[32] = dt.Rows[i]["QualificationType1"].ToString();
                        //dr[33] = dt.Rows[i]["QualificationType2"].ToString();
                        //dr[34] = dt.Rows[i]["QualificationType3"].ToString();
                        dr[34] = dt.Rows[i]["Div/Marks1"].ToString();
                        dr[35] = dt.Rows[i]["Div/Marks2"].ToString();
                        dr[36] = dt.Rows[i]["Div/Marks3"].ToString();
                        dr[37] = dt.Rows[i]["Copy Attached1"].ToString();
                        dr[38] = dt.Rows[i]["Copy Attached2"].ToString();
                        dr[39] = dt.Rows[i]["Copy Attached3"].ToString();
                        dr[40] = dt.Rows[i]["Professional Qalification"].ToString();
                        //dr[42] = dt.Rows[i]["Professional_Name of College Institution1"].ToString();
                        dr[41] = dt.Rows[i]["Professional_From_To_Year1"].ToString();
                        dr[42] = dt.Rows[i]["Professional_Certificate Examination1"].ToString();
                        //dr[45] = dt.Rows[i]["Professional_QualificationType1"].ToString();

                        dr[43] = dt.Rows[i]["Professional_Div/Marks1"].ToString();
                        dr[44] = dt.Rows[i]["Professional_Copy Attached1"].ToString();
                        dr[45] = dt.Rows[i]["Employers Name & Address"].ToString();
                        dr[46] = dt.Rows[i]["Employed From-To"].ToString();
                        dr[47] = dt.Rows[i]["Salary"].ToString();
                        dr[48] = dt.Rows[i]["Reason For Leaving"].ToString();
                        dr[49] = dt.Rows[i]["Designation And Nature Of Job"].ToString();
                        //New Added
                        dr[50] = dt.Rows[i]["Contact No Of Employer"].ToString();
                        dr[51] = dt.Rows[i]["Literary / Cultural / Art"].ToString();
                        dr[52] = dt.Rows[i]["Sports"].ToString();
                        dr[53] = dt.Rows[i]["Hobbies"].ToString();


                        dr[54] = dt.Rows[i]["Reference Name1"].ToString();
                        dr[55] = dt.Rows[i]["Reference Name2"].ToString();
                        dr[56] = dt.Rows[i]["Reference Address1"].ToString();
                        dr[57] = dt.Rows[i]["Reference Address2"].ToString();
                        dr[58] = dt.Rows[i]["Relation With Reference1"].ToString();
                        dr[59] = dt.Rows[i]["Relation With Reference2"].ToString();
                        dr[60] = dt.Rows[i]["Occupation Of Reference1"].ToString();
                        dr[61] = dt.Rows[i]["Occupation Of Reference2"].ToString();
                        dr[62] = dt.Rows[i]["Contact No Of Reference1"].ToString();
                        dr[63] = dt.Rows[i]["Contact No Of Reference2"].ToString();
                        

                        if ((dt.Rows[i]["Date of Joining"].ToString() == "") || (dt.Rows[i]["Date of Joining"].ToString() == null))
                            dr[64] = dt.Rows[i]["Date of Joining"].ToString();
                        else
                            dr[64] = Convert.ToDateTime(dt.Rows[i]["Date of Joining"].ToString()).ToString("dd/MM/yyyy");

                        //New Added
                        if ((dt.Rows[i]["Date of Leaving"].ToString() == "") || (dt.Rows[i]["Date of Leaving"].ToString() == null))
                            dr[65] = dt.Rows[i]["Date of Leaving"].ToString();
                        else
                            dr[65] = Convert.ToDateTime(dt.Rows[i]["Date of Leaving"].ToString()).ToString("dd/MM/yyyy");
                       
                        dr[66] = dt.Rows[i]["Designation"].ToString();
                        //New Added
                        dr[67] = dt.Rows[i]["Department"].ToString();
                        dr[68] = dt.Rows[i]["Centre Name"].ToString();
                        dr[69] = dt.Rows[i]["Sub Centre Name"].ToString();
                        dr[70] = dt.Rows[i]["Client Name"].ToString();
                        dr[71] = dt.Rows[i]["Product Name"].ToString();
                        dr[72] = dt.Rows[i]["Unit"].ToString();

                        dr[73] = dt.Rows[i]["Basic"].ToString();
                        dr[74] = dt.Rows[i]["HRA"].ToString();
                        dr[75] = dt.Rows[i]["SP Allowance"].ToString();
                        dr[76] = dt.Rows[i]["Gross Amt"].ToString();
                        dr[77] = dt.Rows[i]["Company Code"].ToString();

                        //if ((dt.Rows[i]["Approval Mail Date"].ToString() == "") || (dt.Rows[i]["Approval Mail Date"].ToString() == null))
                        dr[78] = dt.Rows[i]["Approval Mail Date"].ToString();
                        //else
                        //    dr[71] = Convert.ToDateTime(dt.Rows[i]["Approval Mail Date"].ToString()).ToString("dd/MM/yyyy");


                        dr[79] = dt.Rows[i]["Approved By"].ToString();
                        dr[80] = dt.Rows[i]["PAMACian Activity Manager Code"].ToString();
                        dr[81] = dt.Rows[i]["PAMACian Activity Manager Name"].ToString();
                        dr[82] = dt.Rows[i]["PAMACian Cluster HR Code"].ToString();
                        dr[83] = dt.Rows[i]["PAMACian Cluster HR Name"].ToString();

                        //if ((dt.Rows[i]["Kit Received Date"].ToString() == "") || (dt.Rows[i]["Kit Received Date"].ToString() == null))
                        dr[84] = dt.Rows[i]["Kit Received Date"].ToString();
                        //else
                        //    dr[77] = Convert.ToDateTime(dt.Rows[i]["Kit Received Date"].ToString()).ToString("dd/MM/yyyy");


                        dr[85] = dt.Rows[i]["Verified And Updated By"].ToString();
                        //if ((dt.Rows[i]["Verified and updated on dtd."].ToString() == "") || (dt.Rows[i]["Verified and updated on dtd."].ToString() == null))
                        dr[86] = dt.Rows[i]["Verified and updated on dtd."].ToString();
                        //else
                        //    dr[79] = Convert.ToDateTime(dt.Rows[i]["Verified and updated on dtd."].ToString()).ToString("dd/MM/yyyy");

                        //dr[82] = dt.Rows[i]["Language Known"].ToString();
                        dr[87] = dt.Rows[i]["Are Related To Any PAMACian"].ToString();
                        dr[88] = dt.Rows[i]["(If Related To Any PAMACian Then) Relationship"].ToString();
                        //New added
                        dr[89] = dt.Rows[i]["(If Related To Any  PAMACian Then) PAMACian Name"];
                        dr[90] = dt.Rows[i]["(If Related To Any  PAMACian Then) PAMACian Code"];
                        dr[91] = dt.Rows[i]["Have Been Involved In Any Court Proceeding"].ToString();
                        dr[92] = dt.Rows[i]["(If Yes Then )Court Proceeding Details"].ToString();
                        dr[93] = dt.Rows[i]["Have Suffered Any Contagious Disease"].ToString();
                        dr[94] = dt.Rows[i]["(If Yes Then)Contagious Disease Detail"].ToString();
                        dr[95] = dt.Rows[i]["Nominee Name"].ToString();
                        //dr[88] = dt.Rows[i]["PF#"].ToString();
                        //dr[89] = dt.Rows[i]["ESIC#"].ToString();
                        dr[96] = dt.Rows[i]["Type Of Category"].ToString();


                        dtNew.Rows.Add(dr);
                        j = j + 1;

                    }
                    else
                    { 
                    }


                }
            }
            
        }

        catch (Exception ex)
        {
            lblMessage.Text = "Error while retreiving records:Property Set " + ex.Message;
        }

        return dtNew;
    }
    public struct GridPosition
    {
        public const int Chk = 0;

    }

    protected void btnExport_Click(object sender, EventArgs e)
    {
        //Export the GridView to Excel
        String rpt_header = lblreport.Text;
        //lblMessage.Text = "";
        //if (lblSearch.Text == "Search")
        //{
            if (gvExport.Rows.Count > 0)
            {
                //PrepareGridViewForExport(gvExport);

                ExportGridView(rpt_header);
            }
            else
            {

            }
        //}
        //else
        //{
        //    lblMessage.Text = "Please Search for the given data before Export";
        //}

    }
   
    //private void PrepareGridViewForExport(Control gv1)
    //{

    //    LinkButton lb = new LinkButton();
    //    Literal l = new Literal();
    //    string name = String.Empty;
    //    try
    //    {
    //        for (int i = 0; i < gv1.Controls.Count; i++)
    //        {
    //            if (gv1.Controls[i].GetType() == typeof(LinkButton))
    //            {
    //                l.Text = (gv1.Controls[i] as LinkButton).Text;
    //                gv1.Controls.Remove(gv1.Controls[i]);
    //                gv1.Controls.AddAt(i, l);
    //            }
    //            else if (gv1.Controls[i].GetType() == typeof(DropDownList))
    //            {
    //                l.Text = (gv1.Controls[i] as DropDownList).SelectedItem.Text;
    //                gv1.Controls.Remove(gv1.Controls[i]);
    //                gv1.Controls.AddAt(i, l);
    //            }
    //            else if (gv1.Controls[i].GetType() == typeof(CheckBox))
    //            {
    //                l.Text = (gv1.Controls[i] as CheckBox).Checked ? "True" : "False";
    //                gv1.Controls.Remove(gv1.Controls[i]);
    //                gv1.Controls.AddAt(i, l);
    //            }
    //            if (gv1.Controls[i].HasControls())
    //            {
    //                PrepareGridViewForExport(gv1.Controls[i]);
    //            }
    //        }
    //    }
    //    catch (Exception exp)
    //    {
    //        lblMessage.Text = "Error : " + exp.Message;
    //    }
    //}


    private void ExportGridView(String rpt_header)
    {
        try
        {
            GridView gv = new GridView();

            DataTable dtExport = new DataTable();
            dtExport = CreateDataTable();
            //if (dtExport.Rows.Count > 0)
            //{
                gv.DataSource = dtExport;
                gv.DataBind();
                for (int i = 0; i < gv.Rows.Count; i++)
                {
                    gv.Rows[i].Cells[77].Attributes.Add("mso-alignment-format", "HorizontalAlignment.Left");
                }
                string attachment = "attachment; filename=Contacts.xls";
                //Response.ClearContent();
                Response.AddHeader("content-disposition", attachment);
                Response.ContentType = "application/ms-excel";
                StringWriter sw = new System.IO.StringWriter();
                System.Web.HttpContext.Current.Response.Write("<b><centre><font size=3 face=Verdana color=#0000FF>" + rpt_header + "</font></centre></br></b>");
                System.Web.HttpContext.Current.Response.Write("<b><center><font size=3 face=Verdana color=white> " + " gg " + "</font></center></b>");
                System.Web.HttpContext.Current.Response.Write("<b><center><font size=3 face=Verdana color=white> " + " gg " + "</font></center></b>");
                HtmlTextWriter htw = new HtmlTextWriter(sw);

                gv.RenderControl(htw);
                Response.Write(sw.ToString());
                Response.End();
                gv.Dispose();
                dtExport.Dispose();
                dtExport.Clear();
            }
        //    else
        //    {
        //        lblMessage.Text = "Can Not Export to Excel ,Please First Search the Records for the Changed Data.";
        //    }
        //}
        catch (Exception exp)
        {
            lblMessage.Text = "Error : " + exp.Message;
        }
    }
    public override void VerifyRenderingInServerForm(Control control)
    {

    }
    protected void btnExort1_Click(object sender, EventArgs e)
    {
        String rpt_header = lblreport.Text;
        if (gvExport.Rows.Count > 0)
        {
            //PrepareGridViewForExport(gvExport);
            ExportGridView(rpt_header);
        }
        else
        {

        }

    }
    protected void gvExport_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        Session["RecCount"] = gvExport.Rows.Count;
    }
    protected void ddlCluster_SelectedIndexChanged(object sender, EventArgs e)
    {
        FillCentre();
        ddlSubCentre.SelectedIndex = 0;
        //BindNullGrid();
        //btnExort1.Visible = false;
        //btnExport.Visible = false;
        ////Div1.Visible = false;
        lblMessage.Text = "";
       
    }
    private void BindNullGrid()
    {
        gvExport.DataSource = null;
        gvExport.DataBind();
    }
    //protected void ddlSubCentre_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    BindNullGrid();
    //    btnExort1.Visible = false;
    //    btnExport.Visible = false;
    //    Div1.Visible = false;
    //    lblMessage.Text = "";
    //}
}
