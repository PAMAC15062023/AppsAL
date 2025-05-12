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
using System.Text;
using System.IO;
using System.Drawing;
using Microsoft.Office.Core;
using System.Configuration.Assemblies;
using CrystalDecisions.Shared;

public partial class Assets_Export : System.Web.UI.Page
{
    CCommon objcon = new CCommon();
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    private struct gridposition
    {
        public const int deptcode= 0;
        public const int dept = 1;
        public const int name = 2;
        public const int location = 3;
        public const int deptloc = 4;
        public const int assettype = 5;
        public const int assetcode = 6;
        public const int descrip = 7;
        public const int assetdescr = 8;
        public const int srno = 9;
        public const int barcode=10;
        public const int check = 11;

    }

    protected void grdview_DataBound(object sender, EventArgs e)
    {
        if (grdview.Rows.Count <= 0)
        {
            //lblMsg.Text = "No record found";
        }
        else
        {
            //tblCaseCount.Visible = true;
            System.Web.UI.WebControls.CheckBox cbHeader = ((System.Web.UI.WebControls.CheckBox)(grdview.HeaderRow.FindControl("HeaderLevelCheckBox")));
            cbHeader.Attributes["onclick"] = "ChangeAllCheckBoxStates(this.checked);";
            foreach (GridViewRow gvr in grdview.Rows)
            {
                // Get a programmatic reference to the CheckBox control
                System.Web.UI.WebControls.CheckBox cb = ((System.Web.UI.WebControls.CheckBox)(gvr.FindControl("chkname")));
                ClientScript.RegisterArrayDeclaration("CheckBoxIDs", string.Concat("\'", cb.ClientID, "\'"));
            }
        }
    }
    protected void export_Click(object sender, EventArgs e)
    {
        HiddenField hid;
        CheckBox cid;
        String str = "";
        String[] bar;
        foreach (GridViewRow row in grdview.Rows)
        {
            hid = (HiddenField)row.FindControl("hdnfld");
            cid = (CheckBox)row.FindControl("chkname");
            if (cid.Checked)
            {
                str += "'" + hid.Value + "'" + ",";
            }
        }
        str = (str.TrimEnd(',')).ToString();
        str = "(" + str.ToString() + ")";
        // str=(str.TrimEnd(',')).ToString();
        string qry = "";
        qry = "select * from asset_summary where barcode in " + str + " ";

        OleDbDataAdapter ol = new OleDbDataAdapter(qry, objcon.ConnectionString);
        DataTable dt = new DataTable();
        DataSet ds = new DataSet();
        ol.Fill(ds, "Search");
        dt = ds.Tables["Search"];
        if (dt.Rows.Count > 0)
        {
            grd.DataSource = dt;
            grd.DataBind();
            grd.Visible = true;
           if (grd.Rows.Count > 0)
            {
                String attachment = "attachment; filename=EXPORT MIS.xls";
                Response.AddHeader("content-disposition", attachment);
                Response.ContentType = "application/ms-excel";
                StringWriter sw = new System.IO.StringWriter();
                HtmlTextWriter htw = new HtmlTextWriter(sw);
                Table tblSpace = new Table();
                TableRow tblRow = new TableRow();
                TableCell tblCell = new TableCell();
                tblCell.Text = " ";

                TableRow tblRow1 = new TableRow();
                TableCell tblCell1 = new TableCell();
                tblCell1.ColumnSpan = 20;// 10;
                tblCell1.Text = "<b><font size='3'>PAMAC FINSERVE PVT. LTD., MUMBAI</font></b> <br/>" +
                                "<b><font size='2'>PAMAC EXPORT MIS: </font></b> <br/>";
                tblCell1.CssClass = "FormHeading";
                tblRow.Cells.Add(tblCell);
                tblRow1.Cells.Add(tblCell1);
                tblRow.Height = 20;
                tblSpace.Rows.Add(tblRow);
                tblSpace.Rows.Add(tblRow1);
                tblSpace.RenderControl(htw);

                Table tbl = new Table();
              grd.EnableViewState = false;
                grd.GridLines = GridLines.Both;
                grd.RenderControl(htw);
                Response.Write(sw.ToString());

                Response.End();

            }
            else
            {
                // lblMsg.Text = "No data to Export";
            }
        }
          
           

        
            
        
       
    }
       
            
    
    public override void VerifyRenderingInServerForm(Control control)
    {

    }


    protected void btnreport_Click(object sender, EventArgs e)
    {

      

    }
}
