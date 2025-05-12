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

public partial class QueryBuilder_GeneralQuery : System.Web.UI.Page
{
    C_GeneralQuery objGeneralQuery = new C_GeneralQuery();
    CCommon con = new CCommon();
    

    protected void Page_Load(object sender, EventArgs e)
    {
        Session["DataBase"] = ddlDataBase.SelectedValue.ToString();
        if (!IsPostBack)
        {
            FillSavedQuery();
            ReadQueryType();
            ReadRecords();
            if (hidIsCreteria.Value == "1")
            {
                TR_Hide.Visible = true;
            }
            else
            {
                TR_Hide.Visible = false;
            }
        }

    }
    private void FillSavedQuery()
    {
        try
        {
           
            string userID = Session["UserId"].ToString();
            string centreID = Session["CentreId"].ToString();
            

            DataSet ds = new DataSet();
            if ((userID != null) && (centreID != null))
            {
                ds = objGeneralQuery.SelectSavedQuery(centreID, userID);
            
            ddlSavedQuery.DataValueField = "Query_ID";
            ddlSavedQuery.DataTextField = "Query_Name";
            ddlSavedQuery.DataSource = ds;
            ddlSavedQuery.DataBind();
            }
        }
        catch (Exception exp)
        {
            LblMsg.Text = "Error : " + exp.Message;
        }

    }
    protected void ddlSavedQuery_SelectedIndexChanged(object sender, EventArgs e)
    {
        ReadQueryType();
        ReadRecords();
        if (hidIsCreteria.Value == "1")
        {
            TR_Hide.Visible = true;
            txtFromDate.Text = "";
            txtToDate.Text = "";
        }
        else
        {
            TR_Hide.Visible = false;
        }
    }

    private void ReadRecords()
    {
        OleDbDataReader oledbDataReader;
        try
        {
            oledbDataReader = objGeneralQuery.ReadData(ddlSavedQuery.SelectedValue.ToString(),hidQueryType.Value.ToString());
            if (oledbDataReader.Read())
            {

               

                if (!(oledbDataReader["Query_Text_File"].ToString().Trim().Length.Equals(0)))


                    hidQueryTextFile.Value = oledbDataReader["Query_Text_File"].ToString();


                if (!(oledbDataReader["Is_Creteria"].ToString().Trim().Length.Equals(0)))
                {
                    hidIsCreteria.Value = oledbDataReader["Is_Creteria"].ToString(); 
                    
                }

                if (!(oledbDataReader["Alias"].ToString().Trim().Length.Equals(0)))

                    hidAlias.Value = oledbDataReader["Alias"].ToString();

            }
        }
        catch (Exception exp)
        {
            LblMsg.Text = "Error : " + exp.Message;
        }
    }

    private void ReadQueryType()
    {
        OleDbDataReader oledbDataReader;
        try
        {
            oledbDataReader = objGeneralQuery.ReadQueryType(ddlSavedQuery.SelectedValue.ToString());
            if (oledbDataReader.Read())
            {

                if (!(oledbDataReader["Query_Type"].ToString().Trim().Length.Equals(0)))

                    hidQueryType.Value = oledbDataReader["Query_Type"].ToString();

            }
        }
        catch (Exception exp)
        {
            LblMsg.Text = "Error : " + exp.Message;
        }
    }
   
    private void AppendToQuery()
    {
        
        CCommon obj = new CCommon();
        try
        {
            if (hidIsCreteria.Value == "1")
            {
                string Tdate = "";
                string fromdate = "";
                if (txtToDate.Text.Trim() != "")
                {
                    Tdate = Convert.ToDateTime(con.strDate(txtToDate.Text.Trim())).AddDays(1.0).ToString("dd-MMM-yyyy");
                }

                string firstQuery = (hidWholeQuery.Value.Trim().ToString());

                string alias = hidAlias.Value;
                if (txtFromDate.Text.Trim() != "")
                {
                    fromdate = con.strDate(txtFromDate.Text.Trim());
                }
                string toDate = Tdate;
                string basedOn = "";
                if (ddlDateType.SelectedValue == "Received Date")
                {
                    basedOn = "CASE_REC_DATETIME";
                }
                else if (ddlDateType.SelectedValue == "Send Date")
                {
                    basedOn = "SEND_DATETIME";
                }


                string query = objGeneralQuery.AppendQuery(firstQuery, alias, fromdate, toDate, basedOn);
                hidWholeQuery.Value = query;
            }
        }

        catch (Exception exp)
        {
            LblMsg.Text = "Error : " + exp.Message;
        }

      
    }
    /// <summary>
    /// This Method is used to Read a Text File.
    /// </summary>
    private void ReadTextFile()
    {
        try
        {
            if (System.IO.File.Exists(Server.MapPath("../SavedQueries/" + hidQueryTextFile.Value)))
            {
                System.IO.StreamReader StreamReader1 = new System.IO.StreamReader(Server.MapPath("../SavedQueries/" + hidQueryTextFile.Value));
                hidWholeQuery.Value = StreamReader1.ReadToEnd();
                StreamReader1.Close();
            }
        }
        catch (Exception exp)
        {
            LblMsg.Text = "Error : " + exp.Message;
        }
    }

    /// <summary>
    /// This Method is Used to Execute the Query Writen in the text file.
    /// </summary>
    private void ExecuteQuery()
    {
        try
        {
            string query = hidWholeQuery.Value.Trim().ToString();
            DataSet dsExecute = new DataSet();


            dsExecute = objGeneralQuery.ExecuteQuery(query);
            if (dsExecute.Tables[0].Rows.Count > 0)
            {
                gvSavedQuery.DataSource = dsExecute;
                gvSavedQuery.DataBind();
            }
            else
            {
                LblMsg.Text = "No Records Found..";
            }
        }
        catch (Exception exp)
        {
            LblMsg.Text = "Error : " + exp.Message;
        }

    }

  
    protected void btnExport_Click(object sender, EventArgs e)
    {
        try
        {
            ReadTextFile();
            AppendToQuery();

            ExecuteQuery();

            //Export the GridView to Excel
            String rpt_header = lblreport.Text;
            if (gvSavedQuery.Rows.Count > 0)
            {
                PrepareGridViewForExport(gvSavedQuery);
                ExportGridView(rpt_header, txtFromDate.Text, txtToDate.Text);
            }
           
        }
        catch (Exception exp)
        {
            LblMsg.Text = "Error : " + exp.Message;
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
            LblMsg.Text = "Error : " + exp.Message;
        }
    }
    public override void VerifyRenderingInServerForm(Control control)
    {
    }
    private void ExportGridView(String rpt_header, String fromdate, String todate)
    {
        try
        {
            string attachment = "attachment; filename=Contacts.xls";
            Response.ClearContent();
            Response.AddHeader("content-disposition", attachment);
            Response.ContentType = "application/ms-excel";
            StringWriter sw = new StringWriter();
            //System.Web.HttpContext.Current.Response.Write("<IMG height='25px' width='150px' src='" + Server.MapPath("../Images/pamaclogo.gif") + "'>");
            //System.Web.HttpContext.Current.Response.Write("<b><center><font size=3 face=Verdana color=white> " + " gg " + "</font></center></b>");
            //System.Web.HttpContext.Current.Response.Write("<b><center><font size=3 face=Verdana color=white> " + " gg " + "</font></center></b>");
            //System.Web.HttpContext.Current.Response.Write("<b><center><font size=3 face=Verdana color=white> " + " gg " + "</font></center></b>");
            //System.Web.HttpContext.Current.Response.Write("<b><center><font size=3 face=Verdana color=white> " + " gg " + "</font></center></b>");
            System.Web.HttpContext.Current.Response.Write("<b><left><font size=3 face=Verdana color=#0000FF>" + rpt_header + "</font></left></br></b>");
            System.Web.HttpContext.Current.Response.Write("<b><center><font size=3 face=Verdana color=white> " + " gg " + "</font></center></b>");
            System.Web.HttpContext.Current.Response.Write("<b><left><font size=2 face=Verdana color=Black> " + "From Date:    " + fromdate + "</font></left></br></b>");
            System.Web.HttpContext.Current.Response.Write("<b><center><font size=3 face=Verdana color=white> " + " gg " + "</font></center></b>");
            System.Web.HttpContext.Current.Response.Write("<b><left><font size=2 face=Verdana color=Black> " + "To Date:    " + todate + "</font></left></b>");
            HtmlTextWriter htw = new HtmlTextWriter(sw);
            gvSavedQuery.RenderControl(htw);
            Response.Write(sw.ToString());
            Response.End();
            gvSavedQuery.Visible = false;
        }
        catch (Exception exp)
        {
            LblMsg.Text = "Error : " + exp.Message;
        }
    }

}
