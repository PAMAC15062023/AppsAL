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

public partial class Pages_ChequeProcessing_RenderImage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
          
        int pSr_no =0;
        string pAssignDate="";
        
        if (Context.Request.QueryString["Date"] != null && Context.Request.QueryString["Sr_no"] != "")
        {
            pSr_no=Convert.ToInt32(Context.Request.QueryString["Sr_no"]);
            pAssignDate = Context.Request.QueryString["Date"];
            GenerateImage(pAssignDate, pSr_no);
         }  
          
    }
    private void GenerateImage(string AssignDate1, int Sr_no1)
    {      
        try
        {
            
            Object SaveUSERInfo = (Object)Session["UserInfo"];
            
            SqlConnection sqlCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);

            sqlCon.Open();
            SqlCommand sqlCom = new SqlCommand();
            sqlCom.Connection = sqlCon;
            sqlCom.CommandType = CommandType.StoredProcedure;
            sqlCom.CommandText = "Get_ImageList";

            SqlParameter AssignDate = new SqlParameter();
            AssignDate.SqlDbType = SqlDbType.VarChar;
            AssignDate.Value = AssignDate1;
            AssignDate.ParameterName = "@AssignDate";
            sqlCom.Parameters.Add(AssignDate);

            SqlParameter Sr_no = new SqlParameter();
            Sr_no.SqlDbType = SqlDbType.Int;
            Sr_no.Value = Sr_no1;
            Sr_no.ParameterName = "@Sr_no";
            sqlCom.Parameters.Add(Sr_no);

            SqlParameter BranchId = new SqlParameter();
            BranchId.SqlDbType = SqlDbType.Int;
            BranchId.Value = 1; //Convert.ToInt32(((UserInfo.structUSERInfo)(SaveUSERInfo)).BranchId);
            BranchId.ParameterName = "@BranchId";
            sqlCom.Parameters.Add(BranchId);


            SqlDataAdapter sqlDA = new SqlDataAdapter();
            sqlDA.SelectCommand = sqlCom;
 

            DataTable dt = new DataTable();
            sqlDA.Fill(dt);
            sqlCon.Close();

            if (dt.Rows.Count >0)
            { 
                byte[] Arr =(byte[]) dt.Rows[0][0];
                Response.BinaryWrite(Arr);
                
                //string filePath = @"C:\1.jpg";
                //FileStream f = new FileStream(filePath, FileMode.OpenOrCreate, FileAccess.Write);
                //f.Write(Arr, 0, Convert.ToInt32(Arr.Length));                
                //f.Close();           

            }
           
        }
        catch (Exception ex)
        { 
        }
     
    }

  
}
