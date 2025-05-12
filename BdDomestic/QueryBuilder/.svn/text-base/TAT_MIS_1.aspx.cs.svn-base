using System;
using System.Data;
using System.Data.OleDb;
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

public partial class QueryBuilder_TAT_MIS_1 : System.Web.UI.Page
{
    public string ProductId = "";
    public string PrevProductId = "";
    public string ClientId = "";
    public int Total_Count;
    public int Tat1_Total_Count;
    public int Tat2_Total_Count;
    public int Tat3_Total_Count;
    public decimal Tat1_Per_Count;
    public decimal Tat2_Per_Count;
    public decimal Tat3_Per_Count;
    public decimal Beyond_Count;
    public decimal Pending_Count;
    C_QueryBuilder_TATMIS obj = new C_QueryBuilder_TATMIS();
    protected void Page_Load(object sender, EventArgs e)
    {
        //Description   :  This Code is used To distingusish Repository PMS Database and PMS.
        //Created By    :  Gargi Srivastava
        //Created On    :  23-Nov-2007
        Session["DataBase"] = ddlDataBase.SelectedValue.ToString();
        //End OF Code
        if (!IsPostBack)
        {
            DataTable dtCentre = new DataTable();
            C_QueryBuilderTAT objTAT = new C_QueryBuilderTAT();
            string UserId = Session["UserId"].ToString();
            string CenterId = objTAT.GetCenter(UserId);
            dtCentre = obj.Centers(CenterId);
            ddlCentre.DataSource = dtCentre;
       
            ddlCentre.DataTextField = "CENTRE_NAME";
            ddlCentre.DataValueField = "CENTRE_ID";
            ddlCentre.DataBind();
            //SqlDataSourceCentre.SelectCommand = "SELECT CENTRE_ID, CENTRE_NAME FROM CENTRE_MASTER WHERE (CENTRE_ID ="+CenterId+")";
            //SqlDataSourceCentre.DataBind();
            
        }
    }

    protected void btnReport_Click(object sender, EventArgs e)
    {
        string TableName = "";
        CCommon ObjCmn = new CCommon();
        try
        {
            obj.FromDate = ObjCmn.string_mm_dd_yy(txtFromDate.Text);
            string TDate = ObjCmn.string_mm_dd_yy(txtToDate.Text);
            string ToDate = Convert.ToDateTime(TDate).AddDays(1.0).ToString("dd/MM/yyyy");
            obj.ToDate = ObjCmn.string_mm_dd_yy(ToDate);

            DataTable dt = new DataTable();
            DataTable dtStdHrs = new DataTable();
            DataTable dtTatHrs = new DataTable();
            dt = obj.GET_ALL_Product_Client(ddlCentre.SelectedItem.Value);
            dt.Columns.Add("Std TAT");
            dt.Columns.Add("Total");
            dt.Columns.Add("TAT 1");
            dt.Columns.Add("TAT 1 %");
            dt.Columns.Add("TAT 2");
            dt.Columns.Add("TAT 2 %");
            dt.Columns.Add("TAT 3");
            dt.Columns.Add("TAT 3 %");
            dt.Columns.Add("Beyond");
            dt.Columns.Add("Pending");

            //PrevProductId = dt.Rows[1][0].ToString();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                decimal TAT_1Count = 0;
                decimal TAT_2Count = 0;
                decimal TAT_3Count = 0;
                decimal BeyondTatCount = 0;
                decimal TAT_1_Per = 0;
                decimal TAT_2_Per = 0;
                decimal TAT_3_Per = 0;
                if (PrevProductId != dt.Rows[i]["PRODUCT_ID"].ToString())
                {
                    string ProductName = dt.Rows[i]["PRODUCT_NAME"].ToString();
                    TableName = obj.GetTableName(ProductName);
                }
                ClientId = dt.Rows[i]["CLIENT_ID"].ToString();
                ProductId = dt.Rows[i]["PRODUCT_ID"].ToString();
                obj.StdTatHrs(ProductId, ClientId);
                //dtTatHrs = obj.GetTatHrs(TableName, ClientId);
                //add by kamal matekar
                dtTatHrs = obj.GetTatHrs1(TableName, ClientId, ddlCentre.SelectedItem.Value);
                if (dtTatHrs.Rows.Count > 0)
                {
                    DataView dv_Pending = new DataView(dtTatHrs);
                    DataView dv_Values = new DataView(dtTatHrs);
                    dv_Pending.RowFilter = "TAT_HRS is Null or TAT_HRS=' '";
                    dv_Values.RowFilter = "TAT_HRS is not Null and TAT_HRS <> ''";
                   
                    //dv_Values.RowFilter = "TAT_HRS is not";
                    int Pending = dv_Pending.Count;
                    Pending_Count = Pending_Count + Pending;
                    int TotalCases = dtTatHrs.Rows.Count;
                    Total_Count = Total_Count + TotalCases;
                    /*Checking that Tat_Hrs are with in TAT1 OR TAT2 OR TAT3*/
                    for (int j = 0; j < dv_Values.Count; j++)
                    {
                        decimal Tat_Value = Convert.ToDecimal(dv_Values[j]["TAT_HRS"].ToString().Replace(':', '.'));
                        if (Tat_Value <= obj.StdTAT_1)
                        {
                            TAT_1Count++;
                            Tat1_Total_Count++;
                        }
                        if ((Tat_Value > obj.StdTAT_1 )&&(Tat_Value <= obj.StdTAT_2))
                        {
                            TAT_2Count++;
                            Tat2_Total_Count++;
                        }
                        if ((Tat_Value > obj.StdTAT_1 )&&(Tat_Value > obj.StdTAT_2 )&&(Tat_Value <= obj.StdTAT_3))
                        {
                            TAT_3Count++;
                            Tat3_Total_Count++;
                        }
                        if (Tat_Value > obj.StdTAT_1 && Tat_Value > obj.StdTAT_2 && Tat_Value > obj.StdTAT_3)
                        {
                            BeyondTatCount++;
                            Beyond_Count++;
                        }
                    }
                    TAT_1_Per = Math.Round(((TAT_1Count / Convert.ToDecimal(TotalCases)) * 100), 0);
                    Tat1_Per_Count = Tat1_Per_Count + TAT_1_Per;
                    TAT_2_Per = Math.Round(((TAT_2Count / Convert.ToDecimal(TotalCases)) * 100), 0);
                    Tat2_Per_Count = Tat2_Per_Count + TAT_2_Per;
                    TAT_3_Per = Math.Round(((TAT_3Count / Convert.ToDecimal(TotalCases)) * 100), 0);
                    Tat3_Per_Count = Tat3_Per_Count + TAT_3_Per;
                    dt.Rows[i]["Total"] = TotalCases;
                    dt.Rows[i]["TAT 1"] = TAT_1Count;
                    dt.Rows[i]["TAT 1 %"] = TAT_1_Per;
                    dt.Rows[i]["TAT 2"] = TAT_2Count;
                    dt.Rows[i]["TAT 2 %"] = TAT_2_Per;
                    dt.Rows[i]["TAT 3"] = TAT_3Count;
                    dt.Rows[i]["TAT 3 %"] = TAT_3_Per;
                    dt.Rows[i]["Beyond"] = BeyondTatCount;
                    dt.Rows[i]["Pending"] = Pending;
                }
                else
                {
                    //dt.Rows[i]["Std TAT"] = "0";
                    dt.Rows[i]["Total"] = "0";
                    dt.Rows[i]["TAT 1"] = "0";
                    dt.Rows[i]["TAT 1 %"] = "0";
                    dt.Rows[i]["TAT 2"] = "0";
                    dt.Rows[i]["TAT 2 %"] = "0";
                    dt.Rows[i]["TAT 3"] = "0";
                    dt.Rows[i]["TAT 3 %"] = "0";
                    dt.Rows[i]["Beyond"] = "0";
                    dt.Rows[i]["Pending"] = "0";

                }
                PrevProductId = ProductId;
            }
            DataRow drTotal;
            drTotal = dt.NewRow();
            drTotal["PRODUCT_NAME"] = "Total";
            drTotal["Total"] = Total_Count;
            drTotal["TAT 1"] = Tat1_Total_Count;
            drTotal["TAT 1 %"] = Math.Round(Tat1_Per_Count, 2);
            drTotal["TAT 2"] = Tat2_Total_Count;
            drTotal["TAT 2 %"] = Math.Round(Tat2_Per_Count, 2);
            drTotal["TAT 3"] = Tat3_Total_Count;
            drTotal["TAT 3 %"] = Math.Round(Tat3_Per_Count, 2);
            drTotal["Beyond"] = Beyond_Count;
            drTotal["Pending"] = Pending_Count;
            dt.Rows.Add(drTotal);
            if (dt.Rows.Count > 0)
            {
                tbl.Visible = true;
                gvTATMIS.DataSource = dt;
                gvTATMIS.DataBind();
                lblFromDate.Text = txtFromDate.Text;
                lblToDate.Text = txtToDate.Text;
                lblCentre.Text = ddlCentre.SelectedItem.Text;
                gvExport.DataSource = dt;
                gvExport.DataBind();
            }
            else
            {
                tbl.Visible = false;
                gvTATMIS.DataSource = "";
                gvTATMIS.DataBind();
            }

        }
        catch (Exception ex)
        {
            LblMsg.Visible = true;
            LblMsg.Text = ex.Message.ToString();
        }

    }
     protected void btnExport_Click(object sender, EventArgs e)
    {
        tblExport.Visible = true;
        string attachment = "attachment; filename=TATMIS.xls";
        Response.ClearContent();
        Response.AddHeader("content-disposition", attachment);
        Response.ContentType = "application/ms-excel";
        StringWriter sw = new StringWriter();

        HtmlTextWriter htw = new HtmlTextWriter(sw);

        //gvTATMIS.RenderControl(htw);
        gvExport.GridLines = GridLines.Both;
        tblExport.RenderControl(htw);
        Response.Write(sw.ToString());
        Response.End(); 
    }
    public override void VerifyRenderingInServerForm(Control control)
    {

    }
    
}
