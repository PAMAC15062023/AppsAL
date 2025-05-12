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

public partial class QueryBuilder_MIS_Centre_VerificationType : System.Web.UI.Page
{
    public string CenterId = "";
    public string ClientId = "";
    public DataTable dtMIS = new DataTable();
    protected void Page_Load(object sender, EventArgs e)
    {
        
        //Description   :  This Code is used To distingusish Repository PMS Database and PMS.
        //Created By    :  Gargi Srivastava
        //Created On    :  23-Nov-2007
        Session["DataBase"] = ddlDataBase.SelectedValue.ToString();
       //End Of Code
        if (!IsPostBack)
        {
            C_QueryBuilderTAT objTAT = new C_QueryBuilderTAT();
            string UserId = Session["UserId"].ToString();
            CenterId = objTAT.GetCenter(UserId);
            ViewState["CenterId"] = CenterId;
        }

    }
    protected void btnReport_Click(object sender, EventArgs e)
    {
        DataTable dt_VV = new DataTable();
        DataTable dt_TV = new DataTable();
        DataTable dt_DV = new DataTable();
        DataTable dt_Centre = new DataTable();
        C_QueryBuilder_MIS obj = new C_QueryBuilder_MIS();
        CCommon ObjCmn = new CCommon();
        try
        {
            obj.FromDate = ObjCmn.string_mm_dd_yy(txtFromDate.Text);
            string TDate = ObjCmn.string_mm_dd_yy(txtToDate.Text);
            string ToDate = Convert.ToDateTime(TDate).AddDays(1.0).ToString("dd/MM/yyyy");
            obj.ToDate = ObjCmn.string_mm_dd_yy(ToDate);
            dt_VV = obj.GetVerificationType_VV();
            dt_TV = obj.GetVerificationType_TV();
            dt_DV = obj.GetVerificationType_DV();
            dt_Centre = obj.GetCenters(ViewState["CenterId"].ToString());

            dtMIS.Columns.Add("Region");
            /*Getting Columns of VV type and adding in to dtMIS DataTable*/
            for (int i = 0; i < dt_VV.Rows.Count; i++)
            {
                dtMIS.Columns.Add(dt_VV.Rows[i]["VERIFICATION_TYPE_CODE"].ToString());
            }
            dtMIS.Columns.Add("Total VV");
            dtMIS.Columns.Add("% Of VV");
            /*Getting Columns of TV type and adding in to dtMIS DataTable*/
            for (int i = 0; i < dt_TV.Rows.Count; i++)
            {
                dtMIS.Columns.Add(dt_TV.Rows[i]["VERIFICATION_TYPE_CODE"].ToString());
            }
            dtMIS.Columns.Add("Total TV");
            dtMIS.Columns.Add("% Of TV");
            /*Getting Columns of DV type and adding in to dtMIS DataTable*/
            for (int i = 0; i < dt_DV.Rows.Count; i++)
            {
                dtMIS.Columns.Add(dt_DV.Rows[i]["VERIFICATION_TYPE_CODE"].ToString());
            }
            dtMIS.Columns.Add("Total DV");
            dtMIS.Columns.Add("% Of DV");


            for (int i = 0; i < dt_Centre.Rows.Count; i++)
            {
                DataRow drMIS;
                drMIS = dtMIS.NewRow();
                int k = 1;
                decimal Total_VV = 0;
                decimal Total_TV = 0;
                decimal Total_DV = 0;
                decimal Total_VV_Percent = 0;
                decimal Total_TV_Percent = 0;
                decimal Total_DV_Percent = 0;
                string dtMIS_ColumnName = dtMIS.Columns[0].ToString();
                drMIS[dtMIS_ColumnName] = dt_Centre.Rows[i]["CENTRE_CODE"].ToString();
                /*--------------Starting adding row for VV Type------------------*/
                for (int j = 0; j < dt_VV.Rows.Count; j++)
                {
                    decimal Sum = 0;
                    Sum = obj.GetSum_VerificationType_CentreWise(dt_VV.Rows[j]["VERIFICATION_TYPE_ID"].ToString(), dt_Centre.Rows[i]["CENTRE_ID"].ToString());
                    drMIS[k] = Sum;
                    Total_VV = Total_VV + Sum;
                    k++;
                }
                Total_VV_Percent = Convert.ToDecimal(Total_VV / dt_VV.Rows.Count);
                drMIS[k] = Total_VV;
                drMIS[++k] = Math.Round(Total_VV_Percent, 2);
                //dtMIS.Rows.Add(drMIS);
                /*--------------Ending adding row for VV Type------------------*/

                /*--------------Starting adding row for TV Type------------------*/
                for (int j = 0; j < dt_TV.Rows.Count; j++)
                {
                    decimal Sum = 0;
                    Sum = obj.GetSum_VerificationType_CentreWise(dt_TV.Rows[j]["VERIFICATION_TYPE_ID"].ToString(), dt_Centre.Rows[i]["CENTRE_ID"].ToString());
                    drMIS[++k] = Sum;
                    Total_TV = Total_TV + Sum;
                }
                Total_TV_Percent = Convert.ToDecimal(Total_TV / dt_TV.Rows.Count);
                drMIS[++k] = Total_TV;
                drMIS[++k] = Math.Round(Total_TV_Percent, 2);
                //dtMIS.Rows.Add(drMIS);
                /*--------------Ending adding row for TV Type------------------*/


                /*--------------Starting adding row for TV Type------------------*/
                for (int j = 0; j < dt_DV.Rows.Count; j++)
                {
                    decimal Sum = 0;
                    Sum = obj.GetSum_VerificationType_CentreWise(dt_DV.Rows[j]["VERIFICATION_TYPE_ID"].ToString(), dt_Centre.Rows[i]["CENTRE_ID"].ToString());
                    drMIS[++k] = Sum;
                    Total_DV = Total_DV + Sum;
                }
                Total_DV_Percent = Convert.ToDecimal(Total_DV / dt_DV.Rows.Count);
                drMIS[++k] = Total_DV;
                drMIS[++k] = Math.Round(Total_DV_Percent, 2);
                dtMIS.Rows.Add(drMIS);
                /*--------------Ending adding row for TV Type------------------*/

                /*----------------Adding row for Grand Total------------------- */


            }
            DataRow dr;
            dr = dtMIS.NewRow();
            dr["Region"] = "Grand Total";
            ArrayList list = new ArrayList();
            int listCount = 0;
            for (int i = 1; i < dtMIS.Columns.Count; i++)
            {
                decimal Total = 0;
                
                for (int j = 0; j < dtMIS.Rows.Count; j++)
                {
                     Total = Total + Convert.ToDecimal(dtMIS.Rows[j][i]);
                }
                list.Add(Total);
                dr[i] = list[listCount];
                listCount++;

            }
            dtMIS.Rows.Add(dr);
            if (dtMIS.Rows.Count > 0)
            {
                tbl.Visible = true;
                gvCentreMIS.DataSource = dtMIS;
                gvCentreMIS.DataBind();

                lblFromDate.Text = txtFromDate.Text;
                lblToDate.Text = txtToDate.Text;
                gvExport.DataSource = dtMIS;
                gvExport.DataBind();


            }
            else
            {
                gvCentreMIS.DataSource = "";
                gvCentreMIS.DataBind();
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
        string attachment = "attachment; filename=CentreWiseMIS.xls";
        Response.ClearContent();
        Response.AddHeader("content-disposition", attachment);
        Response.ContentType = "application/ms-excel";
        StringWriter sw = new StringWriter();
    
        HtmlTextWriter htw = new HtmlTextWriter(sw);

        tblExport.RenderControl(htw);
        Response.Write(sw.ToString());
        Response.End(); 
    }
    public override void VerifyRenderingInServerForm(Control control)
    {

    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("MIS_Centre_VerificationType.aspx");
    }
}
