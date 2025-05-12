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
using System.Data.SqlClient;
using System.IO;

public partial class Pages_ApplicationCoveringSheet : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try 
        {
            if (Session["UserInfo"] == null)
            {
                Response.Redirect("InvalidRequest.aspx");            
            }

            if (!IsPostBack)
            {
               
            }


        }
        catch (Exception ex)
        {
            lblMessage.CssClass = "ErrorMessage";
            lblMessage.Visible = true;
            lblMessage.Text = ex.Message;

        }
    }

   
    protected void btnRetrieve_Click(object sender, EventArgs e)
    {
        try
        {
            Get_ApplicationList();
        }
        catch (Exception ex)
        { 
        
        }
    }

    private void Get_ApplicationList()
    {
        try
        {
            Object SaveUSERInfo = (Object)Session["UserInfo"];

            SqlConnection sqlCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);

            sqlCon.Open();
            SqlCommand sqlCom = new SqlCommand();
            sqlCom.Connection = sqlCon;
            sqlCom.CommandType = CommandType.StoredProcedure;
            sqlCom.CommandText = "Get_ApplicationListFor_CoveringLetter";
            SqlDataAdapter sqlDA = new SqlDataAdapter();
            sqlDA.SelectCommand = sqlCom;

            SqlParameter BranchId = new SqlParameter();
            BranchId.SqlDbType = SqlDbType.Int;
            BranchId.Value = Convert.ToInt32(((UserInfo.structUSERInfo)(SaveUSERInfo)).BranchId);
            BranchId.ParameterName = "@BranchId";
            sqlCom.Parameters.Add(BranchId);

            //string strFromDate = "";
            //string strToDate = "";

            //if (txtFromDate.Text != "")
            //{
            //    strFromDate = Convert.ToDateTime(txtFromDate.Text.Trim()).ToString("yyyyMMdd");
            //}
            //if (txtToDate.Text != "")
            //{
            //    strToDate = Convert.ToDateTime(txtToDate.Text.Trim()).ToString("yyyyMMdd");
            //}
            //// NanoApplicationDate.Value = 
          

            SqlParameter FrmDate = new SqlParameter();
            FrmDate.SqlDbType = SqlDbType.VarChar;
            FrmDate.Value = txtFromDate.Text.Trim();
            FrmDate.ParameterName = "@FrmDate";
            sqlCom.Parameters.Add(FrmDate);

            SqlParameter ToDate = new SqlParameter();
            ToDate.SqlDbType = SqlDbType.VarChar;
            ToDate.Value = txtToDate.Text.Trim();
            ToDate.ParameterName = "@ToDate";
            sqlCom.Parameters.Add(ToDate);


            SqlParameter NanoApplicationNo = new SqlParameter();
            NanoApplicationNo.SqlDbType = SqlDbType.VarChar;
            NanoApplicationNo.Value = txtNanoApplicationNo.Text.Trim();
            NanoApplicationNo.ParameterName = "@NanoApplicationNo";
            sqlCom.Parameters.Add(NanoApplicationNo);

            DataTable dt = new DataTable();
            sqlDA.Fill(dt);
            sqlCon.Close();

            if (dt.Rows.Count > 0)
            {

                GrvApplicationList.DataSource = dt;
                GrvApplicationList.DataBind();
                lblMessage.Visible = true;
                lblMessage.CssClass = "UpdateMessage";
                lblMessage.Text = "Records Found :" + Convert.ToString(dt.Rows.Count);

            }
            else
            {
                GrvApplicationList.DataSource = null;
                GrvApplicationList.DataBind();
                lblMessage.Visible = true;
                lblMessage.CssClass = "ErrorMessage";
                lblMessage.Text ="No Records found!!!";
            }


        }
        catch (Exception ex)
        {
            lblMessage.Visible = true;
            lblMessage.CssClass = "ErrorMessage";
            lblMessage.Text = ex.Message;
        }
    
    }

    protected void btnUpdateStatus_Click(object sender, EventArgs e)
    {
        try 
        {
            Update_ApplicationReportDate();
        }
        catch (Exception ex)
        {
            lblMessage.Visible = true;
            lblMessage.CssClass = "ErrorMessage";
            lblMessage.Text = ex.Message;
        }
    }

    private int Update_ApplicationReportStatus(string pNanoApplicationNo, string pPUID)
    {
        try
        {
            Object SaveUSERInfo = (Object)Session["UserInfo"];
                
            SqlConnection sqlCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);

            sqlCon.Open();
            SqlCommand sqlCom = new SqlCommand();
            sqlCom.Connection = sqlCon;
            sqlCom.CommandType = CommandType.StoredProcedure;
            sqlCom.CommandText = "Update_ApplicationReportStatus";
            SqlDataAdapter sqlDA = new SqlDataAdapter();
            sqlDA.SelectCommand = sqlCom;

            SqlParameter BranchId = new SqlParameter();
            BranchId.SqlDbType = SqlDbType.Int;
            BranchId.Value = Convert.ToInt32(((UserInfo.structUSERInfo)(SaveUSERInfo)).BranchId);
            BranchId.ParameterName = "@BranchId";
            sqlCom.Parameters.Add(BranchId);

            SqlParameter NanoApplicationNo = new SqlParameter();
            NanoApplicationNo.SqlDbType = SqlDbType.VarChar;
            NanoApplicationNo.Value =  pNanoApplicationNo;
            NanoApplicationNo.ParameterName = "@NanoApplicationNo";
            sqlCom.Parameters.Add(NanoApplicationNo);


            SqlParameter PUID = new SqlParameter();
            PUID.SqlDbType = SqlDbType.VarChar;
            PUID.Value = pPUID;
            PUID.ParameterName = "@PUID";
            sqlCom.Parameters.Add(PUID);
 
            int intRows=sqlCom.ExecuteNonQuery();
            sqlCon.Close();

            return intRows; 
            
        }
        catch (Exception ex)
        {
            
            lblMessage.Visible = true;
            lblMessage.CssClass = "ErrorMessage";
            lblMessage.Text = ex.Message;
            return 0;
        }
    }
    private void Update_ApplicationReportDate()
    {
        try
        {
            int i=0;
            int RowUpdated = 0; 
            for (i = 0; i <= GrvApplicationList.Rows.Count - 1; i++)
             { 
                CheckBox  Chkbox=(CheckBox)GrvApplicationList.Rows[i].FindControl("Chkbox");
                string NanoNo = GrvApplicationList.Rows[i].Cells[1].Text;
                string PUID = GrvApplicationList.Rows[i].Cells[2].Text;
                if (Chkbox.Checked == true)
                {

                    RowUpdated=Update_ApplicationReportStatus(NanoNo, PUID);       
                }
            

            }
            if (RowUpdated > 0)
            {
                lblMessage.Visible = true;
                lblMessage.CssClass = "UpdateMessage";
                lblMessage.Text = "Updated Succssfully!";
                
                
            }
            GrvApplicationList.DataSource = null;
            GrvApplicationList.DataBind(); 
            //Get_ApplicationList();

        }

        catch (Exception ex)
        {
            lblMessage.Visible = true;
            lblMessage.CssClass = "ErrorMessage";
            lblMessage.Text = ex.Message;
        }
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        try
        {
            Response.Redirect("Menu.aspx", false);
        }
        catch (Exception ex)
        {
            lblMessage.Visible = true;
            lblMessage.CssClass = "ErrorMessage";
            lblMessage.Text = ex.Message;
        }
    }
    protected void btnRetrive_Click1(object sender, EventArgs e)
    {
        try
        {
            
        }

        catch (Exception ex)
        {
            lblMessage.Visible = true;
            lblMessage.CssClass = "ErrorMessage";
            lblMessage.Text = ex.Message;
        }

    }

    private void GenerateReport_CoveringLetter()
    {
        try
        {
            Object SaveUSERInfo = (Object)Session["UserInfo"];
            SqlConnection sqlCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);

            sqlCon.Open();
            SqlCommand sqlCom = new SqlCommand();
            sqlCom.Connection = sqlCon;
            sqlCom.CommandType = CommandType.StoredProcedure;
            sqlCom.CommandText = "GenerateReport_CoveringLetter";

            SqlParameter BranchId = new SqlParameter();
            BranchId.SqlDbType = SqlDbType.Int;
            BranchId.Value = Convert.ToInt32(((UserInfo.structUSERInfo)(SaveUSERInfo)).BranchId);
            BranchId.ParameterName = "@BranchId";
            sqlCom.Parameters.Add(BranchId);


            SqlParameter ApplicationList = new SqlParameter();
            ApplicationList.SqlDbType = SqlDbType.VarChar;
            ApplicationList.Value = GenerateApplicationList();
            ApplicationList.ParameterName = "@ApplicationList";
            sqlCom.Parameters.Add(ApplicationList);
 

            SqlDataAdapter sqlDA = new SqlDataAdapter();
            sqlDA.SelectCommand = sqlCom;
            DataTable dt = new DataTable();
            sqlDA.Fill(dt);
            sqlCon.Close();


            if (dt.Rows.Count > 0)
            {
                GridView1.DataSource = dt;
                GridView1.DataBind();
                lblMessage.Text = "Total Records Found " + dt.Rows.Count;
                lblMessage.CssClass = "UpdateMessage";

            }
            else
            {
                GridView1.DataSource = null;
                GridView1.DataBind();
                lblMessage.Text = " No Records found!";
                lblMessage.CssClass = "ErrorMessage";

            }

            Generate_ExcelFile();
           // return GenerateTXTFile(dt);

        }

        catch (Exception ex)
        {
            lblMessage.Visible = true;
            lblMessage.CssClass = "ErrorMessage";
            lblMessage.Text = ex.Message;
             
        }
    }

    private string GenerateApplicationList()
    {
        try
        {
            string NanoList = "";
        int i=0;

         for (i = 0; i <= GrvApplicationList.Rows.Count - 1; i++)
         {
             CheckBox Chkbox = (CheckBox)GrvApplicationList.Rows[i].FindControl("Chkbox");
             string NanoNo = GrvApplicationList.Rows[i].Cells[1].Text;
             string PUID = GrvApplicationList.Rows[i].Cells[2].Text;
             if (Chkbox.Checked == true)
             {

               //  NanoList +=   ",'" + NanoNo + "'";
                 NanoList += "|" + NanoNo   ;
             }


         }
         NanoList = NanoList.Substring(1, NanoList.Length-1);
         NanoList = NanoList + "|^";
         return NanoList;
        }

        catch (Exception ex)
        {
            lblMessage.Visible = true;
            lblMessage.CssClass = "ErrorMessage";
            lblMessage.Text = ex.Message;
            return "";
        }
    }
    public string GenerateTXTFile(DataTable dt)
    {

        string strHeader = "";
        string Value = "";
        // create a writer and open the file
        string FileName = "";
        string FileSAVEPAth = "";
        string ActualFileWithPath = "";
        FileName = "CVS_" + Convert.ToString(DateTime.Now.ToString("yyyyMMddHHmmss"));
        FileSAVEPAth = "C:\\TEMP\\";
        ActualFileWithPath = FileSAVEPAth + FileName + ".csv";

        TextWriter tw = new StreamWriter(ActualFileWithPath);

        int j;
        for (j = 0; j < dt.Columns.Count - 1; j++)
        {
            Value = Convert.ToString(dt.Columns[j]);
            strHeader = strHeader + Value + ",";
        }

        tw.WriteLine(strHeader);
        //tw.WriteLine("\n");
        int m;
        string strData = "";

        for (j = 0; j <= dt.Rows.Count - 1; j++)
        {

            for (m = 0; m < dt.Columns.Count - 1; m++)
            {
                Value = Convert.ToString(dt.Rows[j][m]);
                strData = strData + Value + ",";
            }

            tw.WriteLine(strData);
            //tw.WriteLine("\n");
            strData = "";
        }
        tw.Close();
        return ActualFileWithPath;
    }

    protected void btnGenrateReport_Click(object sender, EventArgs e)
    {
        try 
        {
            //string FileName = Convert.ToString(GetReportDate());
            //Response.ContentType = "application/x-msexcel";
            //Response.WriteFile(FileName);
            //Response.End();
            GenerateReport_CoveringLetter();

        }
        catch (Exception ex)
        {
            lblMessage.Visible = true;
            lblMessage.CssClass = "ErrorMessage";
            lblMessage.Text = ex.Message;
        }
    }

    public override void VerifyRenderingInServerForm(Control control)
    {

    }
    private void Generate_ExcelFile()
    {
        String attachment = "attachment; filename=Covering List Report.xls";
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
        tblCell1.Text = "<b><font size='4'>PAMAC FINSERVE PVT. LTD., MUMBAI</font></b> <br/>" +
                        "<b><font size='2' color='blue'>Covering Report </font></b> <br/>";
        tblCell1.CssClass = "SuccessMessage";
        tblRow.Cells.Add(tblCell);
        tblRow1.Cells.Add(tblCell1);
        tblRow.Height = 20;
        tblSpace.Rows.Add(tblRow);
        tblSpace.Rows.Add(tblRow1);
        tblSpace.RenderControl(htw);

        Table tbl = new Table();
        GridView1.EnableViewState = false;
        GridView1.GridLines = GridLines.Both;

        tbExport.RenderControl(htw);
        Response.Write(sw.ToString());

        Response.End();
    }
}
