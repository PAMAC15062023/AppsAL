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
using System.IO;
using System.Text;
using System.Configuration.Assemblies;
using System.Data.OleDb;


public partial class CPV_EBC_EBC_SearchSms : System.Web.UI.Page
{
    C_Sms_Generation obj_GenerateSms = new C_Sms_Generation();
    CCommon connobj = new CCommon();
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void brnSearch_Click(object sender, EventArgs e)
    {
        GridView Gview = new GridView();
        Gview = GetExcel();
        if (Gview.Rows.Count > 0)
        {
            String rpt_header = "Sms Summary";
            PrepareGridViewForExport(Gview);
            ExportGridView(rpt_header, Gview);
        }
        else
        {
            lblMessage.Text = "Record does not Exists.";
        }


    }
    public GridView GetExcel()
    {

        GridView Gview = new GridView();
        Gview = obj_GenerateSms.ExportToExcelEBC(Convert.ToDateTime(connobj.strDate(txtFromDate.Text.Trim().ToString())), Convert.ToDateTime(connobj.strDate(txtToDate.Text.Trim())).AddDays(1.0), Session["CentreId"].ToString(), Session["ClientId"].ToString());
        return Gview;
    }
    private void PrepareGridViewForExport(Control gv)
    {
        LinkButton lb = new LinkButton();
        Literal l = new Literal();
        string name = String.Empty;
        for (int i = 0; i < gv.Controls.Count; i++)
        {
            if (gv.Controls[i].GetType() == typeof(LinkButton))
            {
                l.Text = (gv.Controls[i] as LinkButton).Text;
                gv.Controls.Remove(gv.Controls[i]);
                gv.Controls.AddAt(i, l);
            }
            else if (gv.Controls[i].GetType() == typeof(DropDownList))
            {
                l.Text = (gv.Controls[i] as DropDownList).SelectedItem.Text;
                gv.Controls.Remove(gv.Controls[i]);
                gv.Controls.AddAt(i, l);
            }
            else if (gv.Controls[i].GetType() == typeof(CheckBox))
            {
                l.Text = (gv.Controls[i] as CheckBox).Checked ? "True" : "False";
                gv.Controls.Remove(gv.Controls[i]);
                gv.Controls.AddAt(i, l);
            }
            if (gv.Controls[i].HasControls())
            {
                PrepareGridViewForExport(gv.Controls[i]);
            }
        }
    }
    private void ExportGridView(String rpt_header, GridView gv)
    {
        string attachment = "attachment; filename=Sms Summary .xls";
        Response.ClearContent();
        Response.AddHeader("content-disposition", attachment);
        Response.ContentType = "application/ms-excel";
        StringWriter sw = new StringWriter();
        //System.Web.HttpContext.Current.Response.Write("<IMG height='25px' width='150px' src='" + Server.MapPath("../Images/pamaclogo.gif") + "'>");
        //System.Web.HttpContext.Current.Response.Write("<b><center><font size=3 face=Verdana color=white> " + " gg " + "</font></center></b>");
        //System.Web.HttpContext.Current.Response.Write("<b><center><font size=3 face=Verdana color=white> " + " gg " + "</font></center></b>");
        //System.Web.HttpContext.Current.Response.Write("<b><center><font size=3 face=Verdana color=white> " + " gg " + "</font></center></b>");
        //System.Web.HttpContext.Current.Response.Write("<b><center><font size=3 face=Verdana color=white> " + " gg " + "</font></center></b>");
        System.Web.HttpContext.Current.Response.Write("<b><center><font size=3 face=Verdana color=#0000FF>" + rpt_header + "</font></center></b>");
        System.Web.HttpContext.Current.Response.Write("<b><center><font size=3 face=Verdana color=white> " + " gg " + "</font></center></b>");
        HtmlTextWriter htw = new HtmlTextWriter(sw);
        gv.RenderControl(htw);
        Response.Write(sw.ToString());
        Response.End();
    }

}

