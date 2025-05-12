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

public partial class HR_HR_EISReports : System.Web.UI.Page
{
    C_EIS_Reports objPanReport = new C_EIS_Reports();
    DataTable dt;
    DataView dv;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["RoleId"] != null)
            {
                string Roles = Session["RoleId"].ToString();
                string[] RoleId;
                RoleId = Roles.Split(new char[] { ',' });
                ddlcluster.DataSourceID = "ClusterData";
                ddlcluster.DataBind();
                FillCombos();
                for (int i = 0; i < RoleId.Length; i++)
                {
                    if (RoleId[i].ToString() == "1" || RoleId[i].ToString() == "24")
                    {
                        ddlcentre.Enabled = true;
                        ddlcluster.Enabled = true;
                        ddlsubcentre.Enabled = true;
                        bindGrid();
                        break;
                    }
                    else if (RoleId[i].ToString() == "25")
                    {
                        ddlcluster.SelectedValue = Session["ClusterId"].ToString();
                        ddlcentre.Enabled = true;
                        ddlsubcentre.Enabled = true;
                        FillCombos();
                        BindGridView();
                    }
                    else if (RoleId[i].ToString() == "23")
                    {
                        ddlcluster.SelectedValue = Session["ClusterId"].ToString();
                        ddlcentre.SelectedValue = Session["CentreId"].ToString();
                        ddlsubcentre.Enabled = true;
                        FillCombos();
                        BindGridView();
                    }
                    else if (RoleId[i].ToString() == "22")
                    {
                        ddlcluster.SelectedValue = Session["ClusterId"].ToString();
                        ddlcentre.SelectedValue = Session["CentreId"].ToString();
                        ddlsubcentre.SelectedValue = Session["SubcentreID"].ToString();
                        BindGridView();
                    }
                }
            }
        }
    }
    private void FillCombos()
    {
        if (ddlcluster.Items.Count > 0)
        {
            objPanReport.FillComboList(ddlcentre, "CentreId", "Centre", "SpGetCentre", Convert.ToInt32(ddlcluster.SelectedValue.ToString()));
            if (ddlcentre.Items.Count > 0)
            {
                objPanReport.FillComboList(ddlsubcentre, "SubCentreId", "SubCentreName", "SpGetSubCentre", Convert.ToInt32(ddlcentre.SelectedValue.ToString()));
            }
        }
    }
    private void bindGrid()
    {
        if (ddlReport.SelectedIndex > 0)
        {
            DataSet ds = new DataSet();
            objPanReport.Reportfor = Convert.ToString(ddlReport.SelectedValue.ToString());
            ds = objPanReport.GetPanRecords();            
            Cache["DataView"] = ds;
            GvEmpoyeePan.DataSource = ds;
            if (ds.Tables.Count > 0)
            {
                Setvisibility();
                lblMsg.Text = "";
            }
            else
            {
                lblMsg.Text = "No Record Found !";
            }
                GvEmpoyeePan.DataBind();
        }
    }

    private void Setvisibility()
    {
        if (ddlReport.SelectedValue == "Pan#")
        {
            GvEmpoyeePan.Columns[6].Visible = false;
            GvEmpoyeePan.Columns[7].Visible = true;
            GvEmpoyeePan.Columns[8].Visible = true;
            GvEmpoyeePan.Columns[9].Visible = true;
        }
        else if (ddlReport.SelectedValue == "A/C#")
        {
            GvEmpoyeePan.Columns[6].Visible = true;
            GvEmpoyeePan.Columns[7].Visible = false;
            GvEmpoyeePan.Columns[8].Visible = true;
            GvEmpoyeePan.Columns[9].Visible = true;
        }
        else if (ddlReport.SelectedValue == "Pf#")
        {
            GvEmpoyeePan.Columns[6].Visible = true;
            GvEmpoyeePan.Columns[7].Visible = true;
            GvEmpoyeePan.Columns[8].Visible = false;
            GvEmpoyeePan.Columns[9].Visible = true;
        }
        else if (ddlReport.SelectedValue == "ESIC#")
        {
            GvEmpoyeePan.Columns[6].Visible = true;
            GvEmpoyeePan.Columns[7].Visible = true;
            GvEmpoyeePan.Columns[8].Visible = true;
            GvEmpoyeePan.Columns[9].Visible = false;
        }
        else
        {
            GvEmpoyeePan.Columns[6].Visible = true;
            GvEmpoyeePan.Columns[7].Visible = true;
            GvEmpoyeePan.Columns[8].Visible = true;
            GvEmpoyeePan.Columns[9].Visible = true;
        }
    }
    protected void BtnSearch_Click(object sender, EventArgs e)
    {
        try
        {
            BindGridView();
            ViewState["from"] = txtfromdate.Text.ToString();
            ViewState["to"] = txtToDate.Text.ToString();
            Cache["ReportFor"] = ddlReport.SelectedItem.Text.ToString();
        }
        catch (Exception ex)
        {
            lblMsg.Text = ex.Message;
        }
    }

    private void BindGridView()
    {
        if (ddlReport.SelectedIndex > 0)
        {
            dv = new DataView();
            objPanReport.Reportfor = Convert.ToString(ddlReport.SelectedValue.ToString());
            if (ddlcluster.SelectedIndex > 0)
            {
                objPanReport.ClusterId = Convert.ToInt32(ddlcluster.SelectedValue.ToString());
            }
            else
            {
                objPanReport.ClusterId = 0;
            }
            if (ddlcentre.SelectedIndex > 0)
            {
                objPanReport.CentreId = Convert.ToInt32(ddlcentre.SelectedValue.ToString());
            }
            else
            {
                objPanReport.CentreId = 0;
            }
            if (ddlsubcentre.SelectedIndex > 0)
            {
                objPanReport.SubCentreId = Convert.ToInt32(ddlsubcentre.SelectedValue.ToString());
            }
            else
            {
                objPanReport.SubCentreId = 0;
            }
                if (txtfromdate.Text != "" && txtToDate.Text != "")
                {
                    dv = objPanReport.GetPanSearchRecords(txtfromdate.Text, txtToDate.Text);
                }
                else
                {
                    dv = objPanReport.GetPanSearchRecords("01/01/1910", (DateTime.Now.ToString("dd/MM/yyyy")).ToString());
                }
           
            Cache["DataView"] = dv;
            
                GvEmpoyeePan.DataSource = dv;
                if (ddlReport.SelectedIndex > 0)
                {
                    Setvisibility();
                }
                if (dv.Count > 0)
                {                
                lblMsg.Text = "";
                }
                else
                {
                    lblMsg.Text = "No Record Found !";
                }
                GvEmpoyeePan.DataBind();
        }
    }
    protected void ddlcluster_DataBound(object sender, EventArgs e)
    {
        if (ddlcluster.Items.Count > 0)
        {
            ddlcluster.Items.Insert(0, new ListItem("ALL", "0"));
        }
    }
    protected void ddlcentre_DataBound(object sender, EventArgs e)
    {
        if (ddlcluster.Items.Count > 0)
        {
            ddlcentre.Items.Insert(0, new ListItem("ALL", "0"));
        }
    }
    protected void ddlsubcentre_DataBound(object sender, EventArgs e)
    {
        if (ddlcluster.Items.Count > 0)
        {
            ddlsubcentre.Items.Insert(0, new ListItem("ALL", "0"));
        }
    }
    protected void GvEmpoyeePan_Sorting(object sender, GridViewSortEventArgs e)
    {
        if (ddlReport.SelectedIndex > 0)
        {
            DataView dv = new DataView();
            objPanReport.Reportfor = Convert.ToString(ddlReport.SelectedValue.ToString());
            if (ddlcluster.SelectedIndex > 0)
            {
                objPanReport.ClusterId = Convert.ToInt32(ddlcluster.SelectedValue.ToString());
            }
            else
            {
                objPanReport.ClusterId = 0;
            }
            if (ddlcentre.SelectedIndex > 0)
            {
                objPanReport.CentreId = Convert.ToInt32(ddlcentre.SelectedValue.ToString());
            }
            else
            {
                objPanReport.CentreId = 0;
            }
            if (ddlsubcentre.SelectedIndex > 0)
            {
                objPanReport.SubCentreId = Convert.ToInt32(ddlsubcentre.SelectedValue.ToString());
            }
            else
            {
                objPanReport.SubCentreId = 0;
            }

            if (txtfromdate.Text != "" && txtToDate.Text != "")
            {
                dv = objPanReport.GetPanSearchRecords(txtfromdate.Text, txtToDate.Text);
            }
            else
            {
                dv = objPanReport.GetPanSearchRecords("01/01/1910", (DateTime.Now.ToString("dd/MM/yyyy")).ToString());
            }
            string sortExpression = e.SortExpression;

            if (GridViewSortDirection == SortDirection.Ascending)
            {
                GridViewSortDirection = SortDirection.Descending;
                dv.Sort = sortExpression + " " + "ASC";
            }

            else
            {
                GridViewSortDirection = SortDirection.Ascending;
                dv.Sort = sortExpression + " " + "DESC";
            }
            Cache["DataView"] = dv;
            GvEmpoyeePan.DataSource = dv;
            if (ddlReport.SelectedIndex > 0)
            {
                Setvisibility();
            }
            GvEmpoyeePan.DataBind();
        }
    }
    public SortDirection GridViewSortDirection //This will return Asc or Desc
    {
        get
        {
            if (ViewState["sortDirection"] == null)
                ViewState["sortDirection"] = SortDirection.Ascending;
            return (SortDirection)ViewState["sortDirection"];
        }
        set { ViewState["sortDirection"] = value; }
    }
    protected void GvEmpoyeePan_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GvEmpoyeePan.PageIndex = e.NewPageIndex;
        BindGridView();
    }
    protected void ddlcluster_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlcluster.Items.Count > 0)
        {
            objPanReport.FillComboList(ddlcentre, "CentreId", "Centre", "SpGetCentre", Convert.ToInt32(ddlcluster.SelectedValue.ToString()));
            objPanReport.FillComboList(ddlsubcentre, "SubCentreId", "SubCentreName", "SpGetSubCentre", Convert.ToInt32(ddlcentre.SelectedValue.ToString()));
        }

    }
    protected void ddlcentre_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlcentre.Items.Count > 0)
        {
            objPanReport.FillComboList(ddlsubcentre, "SubCentreId", "SubCentreName", "SpGetSubCentre", Convert.ToInt32(ddlcentre.SelectedValue.ToString()));
        }
    }
    public void CreateTable()
    {
        dt = new DataTable();
        dt.Columns.Add("PAMACianCode");
        dt.Columns.Add("PAMACian");
        dt.Columns.Add("DOJ");
        dt.Columns.Add("Designation");
        dt.Columns.Add("Department");
        if (ddlReport.SelectedValue == "Pan#")
        {
            dt.Columns.Add("A/C#");
            dt.Columns.Add("PF#");
            dt.Columns.Add("ESIC#");
        }
        if (ddlReport.SelectedValue == "A/C#")
        {
            dt.Columns.Add("PAN#");
            dt.Columns.Add("PF#");
            dt.Columns.Add("ESIC#");
        }
        if (ddlReport.SelectedValue == "Pf#")
        {
            dt.Columns.Add("PAN#");
            dt.Columns.Add("A/C#");
            dt.Columns.Add("ESIC#");
        }
        if (ddlReport.SelectedValue == "ESIC#")
        {
            dt.Columns.Add("PAN#");
            dt.Columns.Add("A/C#");
            dt.Columns.Add("PF#");          
        }
        if (ddlReport.SelectedValue == "Join")
        {
            dt.Columns.Add("PAN#");
            dt.Columns.Add("A/C#");
            dt.Columns.Add("PF#");
            dt.Columns.Add("ESIC#");
        }
        dt.Columns.Add("Cluster_Name");
        dt.Columns.Add("Centre_Name");
        dt.Columns.Add("SubCentreName");
    }
    protected void BtnExport_Click(object sender, EventArgs e)
    {
        if (GvEmpoyeePan.Rows.Count > 0)
        {
            DataSet dsExport = new DataSet();
            System.IO.StringWriter tw = new System.IO.StringWriter();
            System.Web.UI.HtmlTextWriter hw = new System.Web.UI.HtmlTextWriter(tw);
            DataGrid dgGrid = new DataGrid();
            //string strSQL = "SELECT S.StudentId, ((M.Marks*100)/100) AS Percentage FROM [Students$] S, [Marks$] M WHERE S.StudentId = M.StudentId ORDER BY S.StudentId";

            //OleDbCommand cmd = new OleDbCommand(strSQL, dbConn);
            //DataSet dsExcel = new DataSet();
            //OleDbDataAdapter daExcel = new OleDbDataAdapter(cmd);

            //daExcel.Fill(Session["DataView"]);
            CreateTable();
            dv = new DataView();
            dv = (DataView)Cache["DataView"];
            for (int i = 0; i < dv.Count; i++)
            {
                DataRow dr;
                dr = dt.NewRow();
                dr["PAMACianCode"] = dv.Table.Rows[i]["PAMACianCode"].ToString();
                dr["PAMACian"] = dv.Table.Rows[i]["PAMACian"].ToString();
                dr["DOJ"] = dv.Table.Rows[i]["DOJ"].ToString();
                dr["Designation"] = dv.Table.Rows[i]["Designation"].ToString();
                dr["Department"] = dv.Table.Rows[i]["Department"].ToString();
                if (ddlReport.SelectedValue == "Pan#")
                {
                    dr["A/C#"] = dv.Table.Rows[i]["AC#"].ToString();
                    dr["PF#"] = dv.Table.Rows[i]["Pf#"].ToString();
                    dr["ESIC#"] = dv.Table.Rows[i]["Esic#"].ToString();
                }
                if (ddlReport.SelectedValue == "A/C#")
                {
                    dr["PAN#"] = dv.Table.Rows[i]["Pan#"].ToString();
                    dr["PF#"] = dv.Table.Rows[i]["Pf#"].ToString();
                    dr["ESIC#"] = dv.Table.Rows[i]["Esic#"].ToString();
                }
                if (ddlReport.SelectedValue == "Pf#")
                {
                    dr["PAN#"] = dv.Table.Rows[i]["Pan#"].ToString();
                    dr["A/C#"] = dv.Table.Rows[i]["AC#"].ToString();
                    dr["ESIC#"] = dv.Table.Rows[i]["Esic#"].ToString();
                }
                if (ddlReport.SelectedValue == "ESIC#")
                {
                    dr["PAN#"] = dv.Table.Rows[i]["Pan#"].ToString();
                    dr["A/C#"] = dv.Table.Rows[i]["AC#"].ToString();
                    dr["PF#"] = dv.Table.Rows[i]["Pf#"].ToString();
                }
                if (ddlReport.SelectedValue == "Join")
                {
                    dr["PAN#"] = dv.Table.Rows[i]["Pan#"].ToString();
                    dr["A/C#"] = dv.Table.Rows[i]["AC#"].ToString();
                    dr["PF#"] = dv.Table.Rows[i]["Pf#"].ToString();
                    dr["ESIC#"] = dv.Table.Rows[i]["Esic#"].ToString();
                }
                dr["Cluster_Name"] = dv.Table.Rows[i]["Cluster_Name"].ToString();
                dr["Centre_Name"] = dv.Table.Rows[i]["Centre_Name"].ToString();
                dr["SubCentreName"] = dv.Table.Rows[i]["SubCentreName"].ToString();
                dt.Rows.Add(dr);
            }
            dgGrid.DataSource = dt;
            
            //   Report Header
            if ((ViewState["from"].ToString() == "") && (ViewState["to"].ToString() ==""))
            {
                hw.WriteLine("<b><u><font size='5'><b><font size='3'>PAMAC FINSERVE PVT. LTD.</font></b> <br/> <b><font size='2'>" + Cache["ReportFor"].ToString() + " Report</font></u></b>");
            }
            else
            {
                hw.WriteLine("<b><u><font size='5'><b><font size='3'>PAMAC FINSERVE PVT. LTD.</font></b> <br/> <b><font size='2'>" + Cache["ReportFor"].ToString() + " Report From : " + ViewState["from"].ToString() + " To " + ViewState["to"].ToString() + "</font></u></b>");
            }
            //   Get the HTML for the control.
            dgGrid.HeaderStyle.Font.Bold = true;
            dgGrid.DataBind();
            dgGrid.RenderControl(hw);

            //'   Write the HTML back to the browser.
            string attachment = "attachment; filename=EISReport.xls";
            Response.AddHeader("content-disposition", attachment);
            Response.ContentType = "application/vnd.ms-excel";
            Response.Write(tw.ToString());
            Response.End();
        }
        else
        {
            lblMsg.Text = "No Record Found !";
        }
    }
}
