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

public partial class CentreSealImageAssignment : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //9769298319
            Session["ImageTable"] = null; ;
            Add_NewColumn();
            Get_CentreList();
            Register_JavascriptControls();
             
        }
    }
    private void Get_CentreList()
    {

        SqlConnection sqlCon = new SqlConnection(ConfigurationSettings.AppSettings["constring"]);

        sqlCon.Open();
        SqlCommand sqlCom = new SqlCommand();
        sqlCom.Connection = sqlCon;
        sqlCom.CommandType = CommandType.StoredProcedure;
        sqlCom.CommandText = "Get_CentreList";

        SqlParameter CentreName = new SqlParameter();
        CentreName.SqlDbType = SqlDbType.VarChar;
        CentreName.Value = txtSearchCentreName.Text.Trim();
        CentreName.ParameterName = "@CentreName";
        sqlCom.Parameters.Add(CentreName);

        SqlDataAdapter sqlDA = new SqlDataAdapter();
        sqlDA.SelectCommand = sqlCom;

        DataTable dt = new DataTable();
        sqlDA.Fill(dt);
        sqlCon.Close();

        ddlCentreList.DataTextField = "Centre_Name";

        ddlCentreList.DataValueField = "CentreID";
        ddlCentreList.DataSource = dt;
        ddlCentreList.DataBind();

        ddlCentreList.Items.Insert(0, "--Select--");
        ddlCentreList.SelectedIndex = 0;    
    
    }
    protected void btnSearchCentre_Click(object sender, EventArgs e)
    {
        Get_CentreList();
    }
    protected void btnAdd_Click(object sender, EventArgs e)
      {
          if (ddlCentreList.SelectedIndex != 0)
          {
              DataTable dt = (DataTable)Session["ImageTable"];
              Add_NewRow(dt, true);
              ddlCentreList.SelectedIndex = 0;
              txtSearchCentreName.Text = "";
          }
    }
    private void Add_NewColumn()
    {

        DataTable dt = new DataTable();


        DataColumn CentreID = new DataColumn();
        CentreID.Unique = true;
        CentreID.DataType = System.Type.GetType("System.Int32");
        CentreID.ColumnName = "Centre_ID";
        CentreID.Caption = "Centre ID";
        dt.Columns.Add(CentreID);


        DataColumn CentreCode = new DataColumn();
        CentreCode.DataType = System.Type.GetType("System.String");
        CentreCode.ColumnName = "Centre_Code";
        CentreCode.Caption = "CentreCode";
        dt.Columns.Add(CentreCode);


        DataColumn Centre_Name = new DataColumn();
        Centre_Name.DataType = System.Type.GetType("System.String");
        Centre_Name.ColumnName = "Centre_Name";
        Centre_Name.Caption = "Centre_Name";
        dt.Columns.Add(Centre_Name);

        DataColumn CENTRE_PAMACSEAL = new DataColumn();
        CENTRE_PAMACSEAL.DataType = System.Type.GetType("System.Array");
        CENTRE_PAMACSEAL.ColumnName = "CENTRE_PAMACSEAL";
        CENTRE_PAMACSEAL.Caption = "CENTRE_PAMACSEAL";
        dt.Columns.Add(CENTRE_PAMACSEAL);
 
        DataColumn ImagePath = new DataColumn();
        ImagePath.DataType = System.Type.GetType("System.String");
        ImagePath.ColumnName = "Image_Path";
        ImagePath.Caption = "Image Path";
        dt.Columns.Add(ImagePath);
          

        Session["ImageTable"] = dt;

    }
    private void Add_NewRow(DataTable dt, Boolean IsNewRow)
    {

        try
        {
            if (IsNewRow)
            {
                DataRow Drow;
                string FileSavePath = "";
                string SavingImagePath = Convert.ToString(ConfigurationSettings.AppSettings["CentrePamacSealImagePath"].ToString());
                string fullSitePath = this.Request.PhysicalApplicationPath + SavingImagePath; //this.Request.PhysicalApplicationPath;
                fullSitePath = fullSitePath.Trim();


                string[] FileFormat_MDB = FileUpload1.FileName.Split('.');
                string FileName_MBB = Convert.ToString(Session["UserId"]) + "_Centre_" + FileFormat_MDB[0] + "." + FileFormat_MDB[FileFormat_MDB.Length - 1];
                FileSavePath = fullSitePath + FileName_MBB;

                FileInfo FFileName_ImageFile = new FileInfo(FileSavePath);
                if (FFileName_ImageFile.Exists)
                {
                    File.Delete(FileSavePath);
                }

                FileUpload1.SaveAs(FileSavePath);


                string[] CentreInfo = ddlCentreList.SelectedItem.Value.Split(':');

                if (CentreInfo.Length > 0)
                {
                    int pCentreID = Convert.ToInt32(CentreInfo[0]);
                    string pCentreCode = CentreInfo[1];

                    Drow = dt.NewRow();

                    Drow["CENTRE_ID"] = pCentreID;
                    Drow["CENTRE_CODE"] = pCentreCode;
                    Drow["CENTRE_NAME"] = ddlCentreList.SelectedItem.Text.Trim();
                    Drow["CENTRE_PAMACSEAL"] = FileUpload1.FileBytes;
                    Drow["Image_Path"] = "~\\" + SavingImagePath + FileName_MBB;//FileSavePath;//FileUpload1.FileName;
                   
                    dt.Rows.Add(Drow);
                }
            }

            Session["ImageTable"] = dt;

            gv_CentreImageList.DataSource = dt;
            gv_CentreImageList.DataBind();
        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
            lblMessage.Visible = true;
        }

    }
    private void Register_JavascriptControls()
    {
        ddlCentreList.Attributes.Add("onchange", "javascript:GetCenter_Code();");
    }
    private void Insert_CentreImages(DataTable dt)
    {
        int RowsEffected = 0;
          int i=0;
          for (i = 0; i <= dt.Rows.Count - 1; i++)
          {

              SqlConnection sqlCon = new SqlConnection(ConfigurationSettings.AppSettings["constring"]);
              sqlCon.Open();
              SqlCommand sqlCom = new SqlCommand();
              sqlCom.Connection = sqlCon;
              sqlCom.CommandType = CommandType.StoredProcedure;
              sqlCom.CommandText = "Insert_CENTRE_MASTER";

              SqlParameter Centre_ID = new SqlParameter();
              Centre_ID.SqlDbType = SqlDbType.Int;
              Centre_ID.Value = Convert.ToInt32(dt.Rows[i]["Centre_ID"]);
              Centre_ID.ParameterName = "@Centre_ID";
              sqlCom.Parameters.Add(Centre_ID);

              SqlParameter CENTRE_PAMACSEAL = new SqlParameter();
              CENTRE_PAMACSEAL.SqlDbType = SqlDbType.Image;
              CENTRE_PAMACSEAL.Value = dt.Rows[i]["CENTRE_PAMACSEAL"];
              CENTRE_PAMACSEAL.ParameterName = "@CENTRE_PAMACSEAL";
              sqlCom.Parameters.Add(CENTRE_PAMACSEAL);              

              RowsEffected = RowsEffected + sqlCom.ExecuteNonQuery(); 
              sqlCon.Close();
          }
          if (RowsEffected>0)
          {
              lblMessage.Text = "Records Update Sucssfully!";
          
          }
    }
    protected void btnUploadAll_Click(object sender, EventArgs e)
    {
        DataTable dt = (DataTable)Session["ImageTable"];
        Insert_CentreImages(dt);
        Refresh_Controls();
    }
    private void Refresh_Controls()
    {
        txtSearchCentreName.Text = "";
        Get_CentreList();       
        Session["ImageTable"] = null;
        Add_NewColumn();
        gv_CentreImageList.DataSource = null;
        gv_CentreImageList.DataBind();
    }
    protected void btnClose_Click(object sender, EventArgs e)
    {
        Session.Remove("ImageTable");

        Response.Redirect("~/Administrator/main.aspx", true);
        
    }
}
