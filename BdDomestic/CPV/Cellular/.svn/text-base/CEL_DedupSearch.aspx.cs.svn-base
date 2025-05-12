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
using System.Data.OleDb;
using System.Drawing;

public partial class CPV_Cellular_CEL_DedupSearch : System.Web.UI.Page
{
    CCommon con = new CCommon();
    protected void Page_Load(object sender, EventArgs e)
    {
        lblDedupMsg.Text = "";
    }
    protected void btnDedupSearch_Click(object sender, EventArgs e)
    {
        CEL_CDedupSearch ObjDedup = new CEL_CDedupSearch();
        try
        {
            string strDate = con.strDate(txtDate.Text.Trim());
            string strTime = txtTime.Text.Trim();
            string strTimeType = ddlTimeType.SelectedItem.Text.Trim();
            DataSet ds = ObjDedup.GetAllRecordByBatchID(strDate, strTime, strTimeType, Session["ClusterId"].ToString(), Session["CentreId"].ToString(), Session["ClientID"].ToString());
            DataSet dsex = new DataSet();
            if (ds.Tables[0].Rows.Count != 0)
            {
                btnExport1.Visible = true;
                btnExport2.Visible = true;
                lblDedupMsg.Visible = false;

                //added by hemangi kambli on 12-nov-2007 --
                //----------------------------------------
                GridView gvHeader = new GridView();
                gvHeader.SkinID = "gridviewNoSort";
                gvHeader.AllowPaging = false;
                gvHeader.AllowSorting = false;
                gvHeader.AutoGenerateColumns = true;
                gvHeader.BorderColor = Color.Black;
                DataTable dt = new DataTable();
                dt.Columns.Add("Sr No.");
                dt.Columns.Add("CaseID");
                dt.Columns.Add("Ref No");
                dt.Columns.Add("Rec Date");
                dt.Columns.Add("Name");
                dt.Columns.Add("Resident Address");
                dt.Columns.Add("Resi Street");
                dt.Columns.Add("Resi City");
                dt.Columns.Add("Resi PinCode");
                dt.Columns.Add("Resi Tel1");
                dt.Columns.Add("Resi Tel2");
                dt.Columns.Add("Off Name");
                dt.Columns.Add("Office Address");
                dt.Columns.Add("Office Street");
                dt.Columns.Add("Office City");
                dt.Columns.Add("Office PinCode");
                dt.Columns.Add("Office Tel1");
                dt.Columns.Add("Office Tel2");
                dt.Columns.Add("DOB");
                dt.Columns.Add("Case Type");
                dt.Columns.Add("Case Status");
                //----------------------------------------------
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    //DataTable dt = new DataTable();
                    //dt.Rows.Add();
                    ObjDedup.FirstName = con.FixQuotes(ds.Tables[0].Rows[i]["APP_FNAME"].ToString());
                    ObjDedup.MiddleName = con.FixQuotes(ds.Tables[0].Rows[i]["APP_MNAME"].ToString());
                    ObjDedup.LastName = con.FixQuotes(ds.Tables[0].Rows[i]["APP_LNAME"].ToString());
                    ObjDedup.ResiAdd1 = con.FixQuotes(ds.Tables[0].Rows[i]["APP_ADDR1"].ToString());
                    ObjDedup.ResiAdd2 = con.FixQuotes(ds.Tables[0].Rows[i]["APP_ADDR2"].ToString());
                    ObjDedup.ResiAdd3 = con.FixQuotes(ds.Tables[0].Rows[i]["APP_ADDR3"].ToString());
                    ObjDedup.ResiTel = con.FixQuotes(ds.Tables[0].Rows[i]["APP_PHONE1"].ToString());
                    ObjDedup.ResiTel1 = con.FixQuotes(ds.Tables[0].Rows[i]["APP_PHONE2"].ToString());
                    ObjDedup.ResiPinCode = con.FixQuotes(ds.Tables[0].Rows[i]["APP_PINCODE"].ToString());
                    ObjDedup.ResiStreet = con.FixQuotes(ds.Tables[0].Rows[i]["APP_STREET"].ToString());
                    ObjDedup.OffAdd1 = con.FixQuotes(ds.Tables[0].Rows[i]["COMP_ADDR1"].ToString());
                    ObjDedup.OffAdd2 = con.FixQuotes(ds.Tables[0].Rows[i]["COMP_ADDR2"].ToString());
                    ObjDedup.OffAdd3 = con.FixQuotes(ds.Tables[0].Rows[i]["COMP_ADDR3"].ToString());
                    ObjDedup.OffPinCode = con.FixQuotes(ds.Tables[0].Rows[i]["COMP_PINCODE"].ToString());
                    ObjDedup.OffTel = con.FixQuotes(ds.Tables[0].Rows[i]["COMP_PHONE1"].ToString());
                    ObjDedup.OffTel1 = con.FixQuotes(ds.Tables[0].Rows[i]["COMP_PHONE2"].ToString());
                    ObjDedup.OffStreet = con.FixQuotes(ds.Tables[0].Rows[i]["COMP_STREET"].ToString());
                    ObjDedup.DOB = con.FixQuotes(ds.Tables[0].Rows[i]["APP_DOB"].ToString());
                    ObjDedup.OffCity = con.FixQuotes(ds.Tables[0].Rows[i]["COMP_CITY"].ToString());
                    ObjDedup.ResiCity = ds.Tables[0].Rows[i]["APP_CITY"].ToString();

                    
                    Label lblSpace = new Label();
                    lblSpace.Text = "  ";
                    lblSpace.Height = 15;


                    //GridView gvHeader = new GridView();
                    //gvHeader.SkinID = "gridviewNoSort";
                    //gvHeader.AllowPaging = false;
                    //gvHeader.AllowSorting = false;
                    //gvHeader.AutoGenerateColumns = true;

                    //gvHeader.BorderColor = Color.Black;
                   
                    DataSet ds1 = new DataSet();
                    ds1 = ObjDedup.GetRecordsPerCase(strDate, strTime, strTimeType, Session["ClusterId"].ToString(), Session["CentreId"].ToString(), Session["ClientID"].ToString());
                    //int k = 1;
                    if (ds1.Tables[0].Rows.Count > 0)
                    {
                        DataRow drResultant;
                        drResultant = dt.NewRow();
                        drResultant["Sr No."] = (i + 1) + ".";
                        drResultant["Name"] = ObjDedup.FirstName + " " + ObjDedup.MiddleName + " " + ObjDedup.LastName;
                        drResultant["Resident Address"] = ObjDedup.ResiAdd1 + " " + ObjDedup.ResiAdd2 + " " + ObjDedup.ResiAdd3;
                        drResultant["Resi Tel1"] = ObjDedup.ResiTel;
                        drResultant["Resi Tel2"] = ObjDedup.ResiTel1;
                        drResultant["Resi PinCode"] = ObjDedup.ResiPinCode;
                        drResultant["Resi Street"] = ObjDedup.ResiStreet;
                        drResultant["Office Address"] = ObjDedup.OffAdd1 + " " + ObjDedup.OffAdd2 + " " + ObjDedup.OffAdd3;
                        drResultant["Office Tel1"] = ObjDedup.OffTel;
                        drResultant["Office Tel2"] = ObjDedup.OffTel1;
                        drResultant["Office PinCode"] = ObjDedup.OffPinCode;
                        drResultant["CaseID"] = ds.Tables[0].Rows[i]["CASE_ID"].ToString();
                        drResultant["Ref No"] = ds.Tables[0].Rows[i]["REF_NO"].ToString();
                        drResultant["Resi City"] = ds.Tables[0].Rows[i]["APP_CITY"].ToString();
                        drResultant["Off Name"] = ds.Tables[0].Rows[i]["COMP_NAME"].ToString();
                        drResultant["Office City"] = ds.Tables[0].Rows[i]["COMP_CITY"].ToString();
                        drResultant["DOB"] = ds.Tables[0].Rows[i]["APP_DOB"].ToString();
                        drResultant["Rec Date"] = ds.Tables[0].Rows[i]["CASE_REC_DATETIME"].ToString();
                        drResultant["Case Type"] = ds.Tables[0].Rows[i]["Case Type"].ToString();
                        dt.Rows.Add(drResultant);

                        for (int j = 0; j < ds1.Tables[0].Rows.Count; j++)
                        {
                            //dt.Rows.Add();
                            drResultant = dt.NewRow();
                            drResultant["Sr No."] = j+1;
                            drResultant["Name"] = ds1.Tables[0].Rows[j]["Name"].ToString();
                            drResultant["Resident Address"] = ds1.Tables[0].Rows[j]["Resident Address"].ToString();
                            drResultant["Resi Tel1"] = ds1.Tables[0].Rows[j]["Resi Tel1"].ToString();
                            drResultant["Resi Tel2"] = ds1.Tables[0].Rows[j]["Resi Tel2"].ToString();

                            drResultant["Resi PinCode"] = ds1.Tables[0].Rows[j]["Resi Pin Code"].ToString();
                            drResultant["Resi Street"] = ds1.Tables[0].Rows[j]["Resi Street"].ToString();
                            drResultant["Office Address"] = ds1.Tables[0].Rows[j]["Office Address"].ToString();
                            drResultant["Office Tel1"] = ds1.Tables[0].Rows[j]["Off Tel1"].ToString();
                            drResultant["Office Tel2"] = ds1.Tables[0].Rows[j]["Off Tel2"].ToString();
                            drResultant["Office PinCode"] = ds1.Tables[0].Rows[j]["Off Pin Code"].ToString();
                            drResultant["CaseID"] = ds1.Tables[0].Rows[j]["CaseID"].ToString();
                            drResultant["Ref No"] = ds1.Tables[0].Rows[j]["Ref No"].ToString();
                            drResultant["Resi City"] = ds1.Tables[0].Rows[j]["Resi City"].ToString();
                            drResultant["Off Name"] = ds1.Tables[0].Rows[j]["Off Name"].ToString();
                            drResultant["Office City"] = ds1.Tables[0].Rows[j]["Off City"].ToString();
                            drResultant["DOB"] = ds1.Tables[0].Rows[j]["APP_DOB"].ToString();
                            drResultant["Rec Date"] = ds1.Tables[0].Rows[j]["Rec Date"].ToString();
                            drResultant["Case Type"] = ds1.Tables[0].Rows[j]["Case Type"].ToString();
                            drResultant["Case Status"] = ds1.Tables[0].Rows[j]["Case_Status"].ToString();
                            //k++;
                            dt.Rows.Add(drResultant);
                        }
                    }
                    Label lblCustName = new Label();

                    if (ds1.Tables[0].Rows.Count <= 0)
                    {
                        lblCustName.Text = ObjDedup.FirstName + " " + ObjDedup.MiddleName + " " + ObjDedup.LastName + " - " + "No Reord found for this case.";

                    }
                    //dsex.Tables.Add(dt);
                    //ViewState["v1"] = dsex;
                    //gvHeader.DataSource = dt;
                    gvHeader.DataSource = dt;
                    gvHeader.DataBind();
                    //added by hemangi kambli on 12-nov-2007 ----
                    //formatting grid ---------------------------
                    string str = "";
                    for (int k = 0; k < gvHeader.Rows.Count; k++)
                    {
                        str = gvHeader.Rows[k].Cells[0].Text;
                        if (str.Contains("."))
                        {
                            gvHeader.Rows[k].BackColor = Color.FromName("#FFFFE1");
                            gvHeader.Rows[k].Font.Bold = true;
                        }
                    }
                    //------------------------------------------------
                    plhDedupe.Controls.Add(lblCustName);
                    plhDedupe.Controls.Add(lblSpace);
                    plhDedupe.Controls.Add(gvHeader);
                    plhDedupe.Controls.Add(lblCustName);                    
                    
                    //gvHeader.Rows[0].BackColor = Color.FromName("#FFFFE1");
                    //gvHeader.Rows[0].Font.Bold = true;
                    ds1.Clear();
                    ds1.Dispose();                    
                }
                dsex.Tables.Add(dt);
                ViewState["v1"] = dsex;                
                ds.Clear();
                ds.Dispose();
            }
            else
            {
                lblDedupMsg.Visible = true;
                lblDedupMsg.Text = "No record found.";
                btnExport1.Visible = false;
                btnExport2.Visible = false;
                
            }

        }
        catch (Exception ex)
        {
            lblDedupMsg.Visible = true;
            lblDedupMsg.Text = ex.Message.ToString();
        }
    }
    protected void btnExport1_Click(object sender, EventArgs e)
    {
        try
        {
            DataSet ds = new DataSet();
            ds = (DataSet)ViewState["v1"];
            CEL_CDedupSearch ObjDedup = new CEL_CDedupSearch();
            string attachment = "attachment; filename=InternalDedup.xls";
            Table tblSpace = new Table();
            TableRow tblRow = new TableRow();
            TableCell tblCell = new TableCell();
            tblCell.Text = " ";

            TableRow tblRow1 = new TableRow();
            tblSpace.BackColor = Color.Yellow;
            tblSpace.HorizontalAlign = HorizontalAlign.Center;
            TableCell tblCell1 = new TableCell();
            tblCell1.HorizontalAlign = HorizontalAlign.Center;

            tblCell1.Text = "<br/><b><font size='5'>Dedup Search</font></b> <br/>" +
                            "<b><font size='2'> Date :</font></b> " + txtDate.Text.Trim() + "<br/>";


            tblCell1.CssClass = "label";

            tblRow.Cells.Add(tblCell);
            tblRow1.Cells.Add(tblCell1);

            tblRow.Height = 20;

            tblSpace.Rows.Add(tblRow);
            tblSpace.Rows.Add(tblRow1);


            Response.AddHeader("content-disposition", attachment);

            Response.ContentType = "application/ms-excel";

            StringWriter sw1 = new System.IO.StringWriter();

            HtmlTextWriter htw1 = new HtmlTextWriter(sw1);

            tblRow1.RenderControl(htw1);
            Response.Write(sw1.ToString());

            for (int i = 0; i < ds.Tables.Count; i++)
            {
                Label lblCustName = new Label();
                Label lblSpace = new Label();
                DataTable dt = ds.Tables[i];
                GridView gv = new GridView();
                gv.SkinID = "gridviewNoSort";
                if (ds.Tables[i].Rows.Count == 1)
                {
                    gv.DataSource = dt;
                    gv.DataBind();
                    lblCustName.Text = ObjDedup.FirstName + " " + ObjDedup.MiddleName + " " + ObjDedup.LastName + " - " + "No Reord found for this case.";
                }
                else
                {
                    gv.DataSource = dt;
                    gv.DataBind();
                }
                //added by hemangi kambli on 12-Nov-2007 -------
                //formatting grid  ---------------------------
                string str = "";
                for (int k = 0; k < gv.Rows.Count; k++)
                {
                    str = gv.Rows[k].Cells[0].Text;
                    if (str.Contains("."))
                    {
                        gv.Rows[k].BackColor = Color.FromName("#FFFFE1");
                        gv.Rows[k].Font.Bold = true;
                    }
                }
                //------------------------------------------------
                //gv.Rows[0].BackColor = Color.FromName("#FFFFE1");
                //gv.Rows[0].Font.Bold = true;
                plhDedupe.Controls.Add(lblSpace);
                plhDedupe.Controls.Add(gv);
                plhDedupe.Controls.Add(lblCustName);

                StringWriter sw = new System.IO.StringWriter();

                HtmlTextWriter htw = new HtmlTextWriter(sw);
                lblSpace.RenderControl(htw);
                gv.RenderControl(htw);
                lblCustName.RenderControl(htw);


                Response.Write(sw.ToString());

            }
            Response.End();
            ds.Clear();
            ds.Dispose();
        }
        catch (Exception ex)
        {
            lblDedupMsg.Visible = true;
            lblDedupMsg.Text = ex.Message.ToString();
        }

    }
    public override void VerifyRenderingInServerForm(Control control)
    {



    }
}
