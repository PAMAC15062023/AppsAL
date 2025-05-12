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
    public partial class HR_HR_HRBRIDGINGIMPORT : System.Web.UI.Page
    {
        CCommon objcon = new CCommon();
        DataTable dtcentre = new DataTable();
        string mon;
        string paidon;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (ddlyear.Items.Count == 0)
            {
                getyear();
            }
          
            
            if (!IsPostBack)
            {

                dtcentre = centre();
                ddlcentre.DataSource = dtcentre;
                ddlcentre.DataTextField = "Centre_name";
                ddlcentre.DataValueField = "centre_id";
                //d = ddlcentre.SelectedIndex = 1;
                ddlcentre.DataBind();
                string strCentreId = "";
                for (int i = 0; i < dtcentre.Rows.Count; i++)
                {
                    strCentreId = strCentreId + dtcentre.Rows[i]["CENTRE_ID"] + ',';
                }
                strCentreId = strCentreId.TrimEnd(',');
                
                
            }
           
        }
        protected void btnupload_Click(object sender, EventArgs e)
        {
            if (Xlsfile.HasFile)
            {
                HRimport hr = new HRimport();
                hr.GetBatchID();
                String strPath = "";
                String MyFile = "";
                String filename = Xlsfile.FileName.ToString();
                FileInfo fil = new FileInfo(filename);
                String strext = fil.Extension;
                    if (strext.ToLower() == ".xls")
                    {
                        LblXls.Text = "";
                        strPath = Server.MapPath("../../ImportFiles/");
                        MyFile = hr.BatchId.ToString().Trim() + ".xls ";
                        strPath = strPath + MyFile;
                        Xlsfile.PostedFile.SaveAs(strPath);
                        hr.AddedBy = Session["UserId"].ToString();
                        hr.AddOn = DateTime.Now.Date.ToShortDateString() + " " + DateTime.Now.Date.ToShortTimeString();
                        hr.ActivityId = Session["ActivityId"].ToString();//ddlActivity.SelectedValue;
                        //hr.CentreID = Session["CentreId"].ToString();
                        hr.CentreID = ddlcentre.SelectedItem.ToString();
                        hr.ClientId = Session["ClientId"].ToString();
                        hr.ProductId = Session["ProductId"].ToString();
                        hr.ClusterID = Session["ClusterId"].ToString();
                        hr.Prefix = Session["Prefix"].ToString();
                            if (ddlmon.SelectedIndex == 0)
                            {
                               lblmsg.Visible = true;
                               lblmsg.Text = "Please Select the Payout Month";
                            }

                            else
                            {
                                if (ddlcentre.SelectedIndex == 0)
                                {
                                    lblmsg.Visible = true;
                                    lblmsg.Text = "Please select the Centre";
                                }
                                else
                                {
                                    if (ddlpaid.SelectedIndex == 0)
                                    {
                                        lblmsg.Visible = true;
                                        lblmsg.Text = "Please Select The Paid On Slot";
                                    }
                                    else
                                    {
                                        mon = ddlmon.SelectedValue+ ' ' + ddlyear.SelectedValue;
                                        paidon = ddlpaid.SelectedValue;

                                        bool isValidFile = hr.ImportExcel(ddlcentre.SelectedItem.ToString(), mon, paidon,ddlcentre.SelectedValue);
                                        grdviw.DataSource = hr.ImportLog;
                                        grdviw.DataBind();
                                       
                                        if (isValidFile == true)
                                        {
                                            string qry = "";
                                            qry = "update a set emp_id=b.emp_id from employee_salary_detail1 a,employee_master b where a.emp_id=b.emp_code";
                                            OleDbDataReader odr1 = OleDbHelper.ExecuteReader(objcon.ConnectionString, CommandType.Text, qry);
                                            qry = "update employee_salary_detail1 set location='" + ddlcentre.SelectedValue + "' where payout_month='" + mon + "' and paidon='" + paidon + "'";
                                            OleDbDataReader Odr = OleDbHelper.ExecuteReader(objcon.ConnectionString, CommandType.Text, qry);

                                            LblXls.Text = "HR Payout Dump Imported Successfully!!! " + hr.TotalCases + " Rows imported.";
                                        }
                                        }
                                }
                            }
                                String strFile = Server.MapPath("../../ImportFiles/") + MyFile;
                                    if (File.Exists(strFile))
                                    {
                                            File.Delete(strFile);
                                    }
                       }
                else
                {
                        
                    LblXls.Text = "Please select proper excel";
                }
            }
        }
        protected void getyear()
        {
            DataTable dt = new DataTable();
            dt = fillstatus();
            if (dt.Rows.Count > 0)
            {
                    ddlyear.DataSource = dt;
                    ddlyear.DataTextField = "year";
                    ddlyear.DataValueField = "year";
                    ddlyear.DataBind();
                    ddlyear.SelectedIndex = 1;
             }
        }
        protected DataTable centre()
        {       
                DataTable dt = new DataTable();
                DataSet ds = new DataSet();
                string qry = "";
                qry = "Select centre_id,centre_name from centre_master order by centre_name";
                OleDbDataAdapter ol = new OleDbDataAdapter(qry, objcon.ConnectionString);
                ol.Fill(ds, "Search");
                dt = ds.Tables["Search"];
                return dt;                      
        }
       
        public DataTable fillstatus()
        {
            DataTable dtsearch = new DataTable();
            string qry = "";
            DataSet ds = new DataSet();
            qry = " select substring(convert(varchar(11),getdate(),113),7,8) -1  as year union select substring(convert(varchar(11),getdate(),113),7,8) as year " +
                  " Union select substring(convert(varchar(11),getdate(),113),7,8) + 1 as year" ;
            OleDbDataAdapter ola = new OleDbDataAdapter(qry, objcon.ConnectionString);
            ola.Fill(ds, "Search");
            dtsearch = ds.Tables["Search"];
            return dtsearch;
         }

        protected void ddlcentre_SelectedIndexChanged(object sender, EventArgs e)
        {
            

        }
      
}

