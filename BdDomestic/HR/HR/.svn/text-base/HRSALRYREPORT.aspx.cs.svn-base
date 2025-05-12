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
using System.Drawing;

public partial class HR_HR_HRSALRYREPORT : System.Web.UI.Page
{
        CCommon objcon = new CCommon();
        DataTable Ht1 = new DataTable();
        DataSet dts1 = new DataSet();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (ddlyear.Items.Count == 0)
            {
                 getyear();
            }
        
        }
        protected DataTable fillyear()
        {
            DataTable dt = new DataTable();
            DataSet ds = new DataSet();
            string qry = "";
            qry=" select substring(convert(varchar(11),getdate(),113),7,8) -1  as year union select substring(convert(varchar(11),getdate(),113),7,8) as year " +
                " Union select substring(convert(varchar(11),getdate(),113),7,8) + 1 as year";
            OleDbDataAdapter ole = new OleDbDataAdapter(qry, objcon.ConnectionString);
            ole.Fill(ds, "Search");
            dt = ds.Tables["Search"];
            return dt;
        }
        protected void getyear()
        {
            DataTable dt = new DataTable();
            dt = fillyear();
                if (dt.Rows.Count > 0)
                {
                    ddlyear.DataSource = dt;
                    ddlyear.DataTextField = "year";
                    ddlyear.DataValueField = "year";
                    ddlyear.DataBind();
                }
         }
       protected DataTable getreport()
       {
            DataTable dt = new DataTable();
            DataSet ds = new DataSet();
            string qry = "";
            qry = "exec SALARYREPORT '" + ddlmonth.SelectedValue + ' ' + ddlyear.SelectedValue + "'";
            OleDbDataAdapter ola = new OleDbDataAdapter(qry, objcon.ConnectionString);
            ola.Fill(ds, "Search");
            dt = ds.Tables["Search"];
            return dt;
       }
   
     protected void btnreport_Click(object sender, EventArgs e)
     {
        getbank2();
     }
     protected DataTable getbank()
     {         
          string qry = "";
          qry = "Select distinct bankname, bankid from bank_master order by bankid";
          OleDbDataAdapter odr = new OleDbDataAdapter(qry, objcon.ConnectionString);
          odr.Fill(dts1, "Search");
          Ht1 = dts1.Tables["Search"];   
          return Ht1;
     }
    protected DataTable getbank1()
    {
      DataTable ht2 = new DataTable();
      DataTable SU = new DataTable();
      DataTable dum = new DataTable();
        
      dum = getreport();
       object c = "";
       int a = 0;
        string qry = "";
        ht2 = getbank();
        qry = "UPDATE salary_detail1 set others=0,others#=0,total=0,total#=0";
        OleDbDataReader ODR11 = OleDbHelper.ExecuteReader(objcon.ConnectionString, CommandType.Text, qry);
        //qry = "Update salary_detail1 set total = net, total# = tot#";
        //OleDbDataReader ODR12 = OleDbHelper.ExecuteReader(objcon.ConnectionString, CommandType.Text, qry);
        
            for (int i = 0; i < ht2.Rows.Count; i++)
            {
                            
                object BID = "";
                object bankname = "";
                string bank = "";

                bankname = ht2.Rows[i]["bankname"];
                bank = bankname.ToString();
                
                string bankid = "";
                BID = ht2.Rows[i]["Bankid"];
                bankid = BID.ToString();
                qry = "EXEC SP_RENAME 'SALARY_DETAIL1."+ bankid + "','" + bank + '#' + "','COLUMN'";
                OleDbDataReader ABC = OleDbHelper.ExecuteReader(objcon.ConnectionString, CommandType.Text, qry);
                qry = "select distinct a.emp_type + a.location AS Emp_Type from salary_detail1 a,employee_salary_detail1 b,employee_master c,bank_master d " +
                      " where b.emp_id=c.emp_id and a.emp_type=c.emp_type and b.location=c.centre_id and c.name_of_bank=d.bankname and name_of_bank='" + bank + "' and payout_month='" + ddlmonth.SelectedValue + ' ' + ddlyear.SelectedValue + "'";
                DataSet dts = new DataSet();
                DataTable ht3 = new DataTable();
                OleDbDataAdapter odt = new OleDbDataAdapter(qry, objcon.ConnectionString);
                odt.Fill(dts, "Search");
                ht3 = dts.Tables["Search"];
                    for (int j = 0; j < ht3.Rows.Count;j++)
                    {

                        
                            string emptype = "";
                            object emp = "";
                            emp = ht3.Rows[j]["Emp_type"];
                            
                            emptype = emp.ToString();
                            
                            qry = "EXEC UPDATE_SALARY '" + bank + "', '" + emptype + "','" + ddlmonth.SelectedValue + ' ' + ddlyear.SelectedValue + "'";
                            OleDbDataReader ODR = OleDbHelper.ExecuteReader(objcon.ConnectionString, CommandType.Text, qry);
                            qry = "select charindex(' ','" + bank + "',1) as Value";
                            OleDbDataReader OD = OleDbHelper.ExecuteReader(objcon.ConnectionString, CommandType.Text, qry);
                            OD.Read();
                            c = OD["Value"].ToString();
                            a = Convert.ToInt32(c.ToString());

                        if (a==0)
                        {
                          
                                qry = "update a set " + bank + "=b.netsalary," + bank + '#' + "=b.total from salary_detail1 a,salary_detail2 b where a.emp_type=b.emp_type and a.location=b.location and name_of_bank='" + bank + "' and a.emp_type=left('" + emptype + "',1)";
                                OleDbDataReader oD2 = OleDbHelper.ExecuteReader(objcon.ConnectionString, CommandType.Text, qry);
                                qry = "update a set a.total=a.total+b.netsalary,total#=total#+b.total from salary_detail1 a, salary_detail2 B where A.EMP_TYPE = B.EMP_TYPE AND A.LOCATION = B.LOCATION AND NAME_OF_BANK = '" + bank + "' and a.emp_type=left('" + emptype + "',1)";
                                OleDbDataReader oDR2 = OleDbHelper.ExecuteReader(objcon.ConnectionString, CommandType.Text, qry);
                               
                        
                        }
                            else
                            {
                                qry = "Update A set [" + bank + "] = B.NETSALARY, [" + bank + '#' + "] =b.Total from salary_detail1 a, salary_detail2 B where A.EMP_TYPE = B.EMP_TYPE AND A.LOCATION = B.LOCATION AND NAME_OF_BANK = '" + bank + "' and a.emp_type=left('" + emptype + "',1)";
                                OleDbDataReader DR2 = OleDbHelper.ExecuteReader(objcon.ConnectionString, CommandType.Text, qry);
                                qry = "update a set a.total=a.total+b.netsalary,total#=total#+b.total from salary_detail1 a, salary_detail2 B where A.EMP_TYPE = B.EMP_TYPE AND A.LOCATION = B.LOCATION AND NAME_OF_BANK = '" + bank + "' and a.emp_type=left('" + emptype + "',1)";
                                OleDbDataReader oDR2 = OleDbHelper.ExecuteReader(objcon.ConnectionString, CommandType.Text, qry);
                            }
                            qry = "DRop table salary_detail2";
                            OleDbDataReader Od = OleDbHelper.ExecuteReader(objcon.ConnectionString, CommandType.Text, qry);
                  
                    }
                   
              }
            
        
              qry = "select distinct a.emp_type + a.location AS Emp_Type from salary_detail1 a,employee_salary_detail1 b,employee_master c " +
                    " where b.emp_id=c.emp_id and a.emp_type=c.emp_type and b.location=c.centre_id and payout_month='" + ddlmonth.SelectedValue + ' ' + ddlyear.SelectedValue + "' and name_of_bank not in(Select Bankname from bank_master)";
              DataSet dts4 = new DataSet();
              DataTable ht6 = new DataTable();
              OleDbDataAdapter odt4 = new OleDbDataAdapter(qry, objcon.ConnectionString);
              odt4.Fill(dts4, "Search");
              ht6 = dts4.Tables["Search"];

              for (int j = 0; j < ht6.Rows.Count; j++)
              {
                  string emptype1 = "";
                  object emp1 = "";
                  emp1 = ht6.Rows[j]["Emp_type"];

                  emptype1 = emp1.ToString();
                  //qry = "DRop table salary_detail2";
                  //OleDbDataReader Od = OleDbHelper.ExecuteReader(objcon.ConnectionString, CommandType.Text, qry);
                  qry = "EXEC UPDATE_SALARY '', '" + emptype1 + "', '" + ddlmonth.SelectedValue + ' ' + ddlyear.SelectedValue + "'";
                  OleDbDataReader ODR = OleDbHelper.ExecuteReader(objcon.ConnectionString, CommandType.Text, qry);
                  qry = "UPDATE a SET OTHERS=b.NETSALARY,OTHERS#=B.TOTAL from salary_detail1 a,salary_detail2 b where A.EMP_TYPE = B.EMP_TYPE AND A.LOCATION = B.LOCATION and a.emp_type=left('" + emptype1 + "',1) ";
                  OleDbDataReader ODR1 = OleDbHelper.ExecuteReader(objcon.ConnectionString, CommandType.Text, qry);

                  qry = "update a set a.total=a.total+b.netsalary,total#=total#+b.total from salary_detail1 a, salary_detail2 B where A.EMP_TYPE = B.EMP_TYPE AND A.LOCATION = B.LOCATION and a.emp_type=left('" + emptype1 + "',1)";
                  OleDbDataReader DR2 = OleDbHelper.ExecuteReader(objcon.ConnectionString, CommandType.Text, qry);
              
                  qry = "DRop table salary_detail2";
                  OleDbDataReader Od = OleDbHelper.ExecuteReader(objcon.ConnectionString, CommandType.Text, qry);

                  }
        DataSet SU2=new DataSet();
        qry = "SELECT * FROM SALARY_DETAiL1";
              OleDbDataAdapter SU1 = new OleDbDataAdapter(qry, objcon.ConnectionString);
              SU1.Fill(SU2, "Search");
              SU = SU2.Tables["Search"];
        
            return SU;

     }
     protected void getbank2()
     {
            DataTable ht;
            ht= getbank1();
            if (ht.Rows.Count > 0)
            {
                gvmis.DataSource = ht;
                gvmis.DataBind();
                gvmis.Visible = true;
                lblmsg.Visible = false;
            }
            else
            {
                gvmis.DataSource = ht;
                gvmis.DataBind();
                gvmis.Visible = false;
                lblmsg.Text = "No Data Exists For Selected Month and Year";
                lblmsg.Visible = true;
            }
                string qry = "";
                qry = "drop table salary_detail1";
                OleDbDataReader Odr = OleDbHelper.ExecuteReader(objcon.ConnectionString, CommandType.Text, qry);
                //qry = "drop table salary_detail2";
                //OleDbDataReader Odr1 = OleDbHelper.ExecuteReader(objcon.ConnectionString, CommandType.Text, qry);
     }

    protected void Export_Click(object sender, EventArgs e)
    {
        getbank2();
        if (gvmis.Rows.Count > 0)
        {
            String attachment = "attachment; filename=GROSS PAYOUT MIS.xls";
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
                            "<b><font size='2'>PAMAC GROSS PAYOUT MIS: " + ddlmonth.SelectedValue + ' ' + ddlyear.SelectedValue + " </font></b> <br/>";
            tblCell1.CssClass = "FormHeading";
            tblRow.Cells.Add(tblCell);
            tblRow1.Cells.Add(tblCell1);
            tblRow.Height = 20;
            tblSpace.Rows.Add(tblRow);
            tblSpace.Rows.Add(tblRow1);
            tblSpace.RenderControl(htw);
           
            Table tbl = new Table();
            gvmis.EnableViewState = false;
            gvmis.GridLines = GridLines.Both;
            gvmis.RenderControl(htw);
            Response.Write(sw.ToString());
            
            Response.End();
            
        }
        else
        {
            // lblMsg.Text = "No data to Export";
        }

    }
    public override void VerifyRenderingInServerForm(Control control)
    {

    }
}
