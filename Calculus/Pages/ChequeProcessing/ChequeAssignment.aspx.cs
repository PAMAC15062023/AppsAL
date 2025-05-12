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


public partial class Pages_ChequeProcessing_ChequeAssignment : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
             if (Session["UserInfo"] == null)
            {
                Response.Redirect("InvalidRequest.aspx", false);
            }
            else if (!IsPostBack)
            {
                Add_NewColumn();
                Get_ValidUserList();
            }        
        }
    }
    protected void btnAddImages_Click(object sender, EventArgs e)
    {
        try
        {
            //Add_NewColumn();
           
            DataTable dt = (DataTable)Session["ImageTable"];
            Add_NewRow(dt,true);
        }
        catch (Exception ex)
        { 
        
        }
    }
    private void AddImages_ToDataTabse(DataTable dt)
    {
        Object SaveUSERInfo = (Object)Session["UserInfo"];        

        int i=0;
        for (i = 0; i <= dt.Rows.Count - 1; i++)
        {

            SqlConnection sqlCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);
            sqlCon.Open();
            SqlCommand sqlCom = new SqlCommand();
            sqlCom.Connection = sqlCon;
            sqlCom.CommandType = CommandType.StoredProcedure;
            sqlCom.CommandText = "Insert_ChequeAssigninfo";

            SqlParameter IndexNo = new SqlParameter();
            IndexNo.SqlDbType = SqlDbType.Int;
            IndexNo.Value =0;
            IndexNo.ParameterName = "@IndexNo";
            sqlCom.Parameters.Add(IndexNo);

            SqlParameter Sr_No = new SqlParameter();
            Sr_No.SqlDbType = SqlDbType.Int;
            Sr_No.Value = dt.Rows[i]["Sr_No"];
            Sr_No.ParameterName = "@Sr_No";
            sqlCom.Parameters.Add(Sr_No);
            
            SqlParameter AssignDate = new SqlParameter();
            AssignDate.SqlDbType = SqlDbType.VarChar;
            AssignDate.Value = dt.Rows[i]["AssignDate"];
            AssignDate.ParameterName = "@AssignDate";
            sqlCom.Parameters.Add(AssignDate);

            SqlParameter ChequeImage = new SqlParameter();
            ChequeImage.SqlDbType = SqlDbType.Image;
            ChequeImage.Value = dt.Rows[i]["ChequeImage"];
            ChequeImage.ParameterName = "@ChequeImage";
            sqlCom.Parameters.Add(ChequeImage);
            
            SqlParameter AssignedTo = new SqlParameter();
            AssignedTo.SqlDbType = SqlDbType.VarChar;
            AssignedTo.Value = dt.Rows[i]["AssignedTo"];
            AssignedTo.ParameterName = "@AssignedTo";
            sqlCom.Parameters.Add(AssignedTo);

            SqlParameter ImagePath = new SqlParameter();
            ImagePath.SqlDbType = SqlDbType.VarChar;
            ImagePath.Value = dt.Rows[i]["ImagePath"];
            ImagePath.ParameterName = "@ImagePath";
            sqlCom.Parameters.Add(ImagePath);

            SqlParameter ImageType = new SqlParameter();
            ImageType.SqlDbType = SqlDbType.VarChar;
            ImageType.Value = dt.Rows[i]["ImageType"];
            ImageType.ParameterName = "@ImageType";
            sqlCom.Parameters.Add(ImageType);

            SqlParameter CreatedBy = new SqlParameter();
            CreatedBy.SqlDbType = SqlDbType.VarChar;
            CreatedBy.Value = Convert.ToString(((UserInfo.structUSERInfo)(SaveUSERInfo)).UserId); ;
            CreatedBy.ParameterName = "@CreatedBy";
            sqlCom.Parameters.Add(CreatedBy);            
             
            int row = sqlCom.ExecuteNonQuery();
            if (row > 0)
            {
                lblMessage.Text = "Record Updated Successfully";
            } 

            sqlCon.Close();
        }
    }
    private void Add_NewColumn()
    {

        DataTable dt = new DataTable();

        //DataColumn Sr_No, AssignDate, , , ,  = new DataColumn();

        DataColumn Sr_No = new DataColumn();
        Sr_No.DataType = System.Type.GetType("System.Int32");        
        Sr_No.ColumnName ="Sr_No";
        Sr_No.Caption = "Sr No";
        dt.Columns.Add(Sr_No);
          
        DataColumn AssignDate = new DataColumn();
        AssignDate.DataType = System.Type.GetType("System.String");
        AssignDate.ColumnName = "AssignDate";
        AssignDate.Caption = "AssignDateo";
        dt.Columns.Add(AssignDate);

        DataColumn ChequeImage = new DataColumn();
        ChequeImage.DataType = System.Type.GetType("System.Array");
        ChequeImage.ColumnName = "ChequeImage";
        ChequeImage.Caption = "Cheque Image";        
        dt.Columns.Add(ChequeImage);


        DataColumn AssignedTo = new DataColumn();
        AssignedTo.DataType = System.Type.GetType("System.String");
        AssignedTo.ColumnName = "AssignedTo";
        AssignedTo.Caption = "Assigned To";
        dt.Columns.Add(AssignedTo);

        DataColumn ImagePath = new DataColumn();
        ImagePath.DataType = System.Type.GetType("System.String");
        ImagePath.ColumnName = "ImagePath";
        ImagePath.Caption = "Image Path";
        dt.Columns.Add(ImagePath);


        DataColumn ImageType = new DataColumn();
        ImageType.DataType = System.Type.GetType("System.String");
        ImageType.ColumnName = "ImageType";
        ImageType.Caption = "Image Type";
        dt.Columns.Add(ImageType);

        Session["ImageTable"] = dt;

    }
    private void Add_NewRow(DataTable dt, Boolean IsNewRow)
    {
        if (IsNewRow)
        {
            DataRow Drow;
            int MaxRow = dt.Rows.Count;
            MaxRow = MaxRow + 1;

            Drow=dt.NewRow();

            Drow["Sr_No"] = MaxRow;
            Drow["AssignDate"] = Get_DateFormat(txtAssignDate.Text.Trim(),"MM/dd/yyyy");
            Drow["ChequeImage"] = FileUpload1.FileBytes;
            Drow["AssignedTo"] = "infy";
            Drow["ImagePath"] = FileUpload1.FileName;
            Drow["ImageType"] = "jpg";

            dt.Rows.Add(Drow);        
        }
 
        Session["ImageTable"] = dt;

        GridView1.DataSource = dt;
        GridView1.DataBind();  
    
    }
    protected void btnUploadAll_Click(object sender, EventArgs e)
    {
            try
            {
              DataTable dt = (DataTable)Session["ImageTable"];
              AddImages_ToDataTabse(dt);
            }
            catch (Exception ex)
            {
                lblMessage.Text = ex.Message;  
            }
    }
    protected void btnClose_Click(object sender, EventArgs e)
    {
        Response.Redirect("../Menu.aspx", false);
     
    }
    private void Get_ValidUserList()
    {
        try
        {
            Object SaveUSERInfo = (Object)Session["UserInfo"];

            SqlConnection sqlCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);

            sqlCon.Open();
            SqlCommand sqlCom = new SqlCommand();
            sqlCom.Connection = sqlCon;
            sqlCom.CommandType = CommandType.StoredProcedure;
            sqlCom.CommandText = "Get_ChequeAssignUserList";

            SqlParameter BranchId = new SqlParameter();
            BranchId.SqlDbType = SqlDbType.Int;
            BranchId.Value = Convert.ToInt32(((UserInfo.structUSERInfo)(SaveUSERInfo)).BranchId);
            BranchId.ParameterName = "@BranchId";
            sqlCom.Parameters.Add(BranchId);

            SqlParameter ModuleList = new SqlParameter();
            ModuleList.SqlDbType = SqlDbType.VarChar;
            ModuleList.Value = "Cheque Entry";
            ModuleList.ParameterName = "@ModuleList";
            sqlCom.Parameters.Add(ModuleList);
             
            SqlDataAdapter sqlDA = new SqlDataAdapter();
            sqlDA.SelectCommand = sqlCom;
             
            DataTable dt = new DataTable();
            sqlDA.Fill(dt);
            sqlCon.Close();

            ddlAssignTo.DataTextField = "UserDetails";
            ddlAssignTo.DataValueField = "UserID";
            ddlAssignTo.DataSource = dt;
            ddlAssignTo.DataBind();

            ddlAssignTo.Items.Insert(0, "--Select--");
            ddlAssignTo.SelectedIndex = 0;    




        }
        catch (Exception ex)
        {
            lblMessage.Visible = true;
            lblMessage.Text = ex.Message;
            lblMessage.CssClass = "ErrorMessage";
        }
    }
    private string Get_DateFormat(string cDate, string cDateFormat)
    {
        try
        {
            string strDate = cDate;
            string[] strArrDate = strDate.Split('/');

            if (strArrDate.Length > 0)
            {
                if (cDateFormat == "yyyy/MM/dd")
                {
                    strDate = strArrDate[2] + "/" + strArrDate[1] + "/" + strArrDate[0];

                }



                if (cDateFormat == "MM/dd/yyyy")
                {
                    strDate = strArrDate[1] + "/" + strArrDate[0] + "/" + strArrDate[2];

                }


                if (cDateFormat == "dd/MM/yyyy")//MM/dd/yyyy
                {
                    strDate = strArrDate[1] + "/" + strArrDate[0] + "/" + strArrDate[2];
                }

            }
            return strDate;
        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
            lblMessage.CssClass = "ErrorMessage";
            lblMessage.Visible = true;
            return "";
        }

    }
}
