using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class Pages_JFS_Query_resolved : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
      if(!IsPostBack)
      {
          getbranch_name();
          lblMsgXls.Text = "hi";
          //lblheading.Text = "fgasdgartr";
      }

    }

    public void getbranch_name()
    {
        try
        {

            Object SaveUSERInfo = (Object)Session["UserInfo"];
            SqlConnection sqlCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);

            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlCon;
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.CommandText = "sp_getbranch_name_qr";

            SqlParameter branch_name = new SqlParameter();
            branch_name.SqlDbType = SqlDbType.NVarChar;
            branch_name.Value = Convert.ToString(((UserInfo.structUSERInfo)(SaveUSERInfo)).BranchId);
            branch_name.ParameterName = "@branch_id";
            sqlcmd.Parameters.Add(branch_name);

            SqlDataAdapter sda = new SqlDataAdapter();
            sda.SelectCommand = sqlcmd;

            DataSet MyDs = new DataSet();
            sda.Fill(MyDs);
           
            ddlbranch.DataTextField = "branch_name";
            ddlbranch.DataValueField = "branch_name";
            ddlbranch.DataSource = MyDs;
            ddlbranch.DataBind();
            ddlbranch.Items.Insert(0, new ListItem("--All--", "0"));
        }
        catch
        {
        }

    }
}