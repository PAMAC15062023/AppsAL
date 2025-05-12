using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
public partial class Pages_ICICIRPC_Search : System.Web.UI.Page
{
    //SingleUserLogin Login = new SingleUserLogin();
    protected void Page_Load(object sender, EventArgs e)
    {
        //Login.ValidateTokenLoginDetails();
        if (!IsPostBack)
        {

        }
    }


    protected void btnsearch_Click(object sender, EventArgs e)
    {
        if (txtlosno_search.Text != "" || txtaps_id.Text!="")
        {
            cleardata();
            pnllocation.Visible = true;
            Get_displaydata();
            pnlindexing.Visible = true;
            Get_indexingdata();
            pnlqde.Visible = true;
            Get_qdedata();
            Pnlcpvdetails.Visible = true;
            Get_CPVDATA();
        }
        else
        {
            lblMsgXls.Visible = true;
            lblMsgXls.Text = "Please Enter LOS number";
            pnllocation.Visible = false;
            pnlindexing.Visible = false;
           // pnldde.Visible = false;
            pnlqde.Visible = false;
            Pnlcpvdetails.Visible = false;
        }


    }

    private void Get_displaydata()
    {
        Object SaveUSERInfo = (Object)Session["UserInfo"];
        SqlConnection sqlCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);
        sqlCon.Open();

        SqlCommand sqlCom = new SqlCommand();
        sqlCom.Connection = sqlCon;
        sqlCom.CommandType = CommandType.StoredProcedure;
        sqlCom.CommandText = "IRPC_Get_Details_ICICI_New_SP";
        sqlCom.CommandTimeout = 0;

        SqlParameter losno = new SqlParameter();
        losno.SqlDbType = SqlDbType.VarChar;
        losno.Value = txtlosno_search.Text.ToString();
        losno.ParameterName = "@losno";
        sqlCom.Parameters.Add(losno);

        SqlParameter apsid = new SqlParameter();
        apsid.SqlDbType = SqlDbType.VarChar;
        apsid.Value = txtaps_id.Text.ToString();
        apsid.ParameterName = "@aps_id";
        sqlCom.Parameters.Add(apsid);

        int SqlRow = 0;
        SqlRow = sqlCom.ExecuteNonQuery();

        SqlDataAdapter sqlDA = new SqlDataAdapter();
        sqlDA.SelectCommand = sqlCom;
        DataTable dt = new DataTable();
        sqlDA.Fill(dt);
        sqlCon.Close();

        if (dt.Rows.Count > 0)
        {
            lblhub.Text = dt.Rows[0]["LOS Location"].ToString().Trim();
            //lblspoke.Text = dt.Rows[0]["Spoke Location"].ToString().Trim();
            //lbllocation.Text = dt.Rows[0]["RPC Location"].ToString().Trim();

        }





    }
    protected void btncancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Pages/Menu.aspx", true);
    }

    private void Get_indexingdata()
    {
        Object SaveUSERInfo = (Object)Session["UserInfo"];
        SqlConnection sqlCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);
        sqlCon.Open();

        SqlCommand sqlCom = new SqlCommand();
        sqlCom.Connection = sqlCon;
        sqlCom.CommandType = CommandType.StoredProcedure;
        sqlCom.CommandText = "IRPC_Get_Indexing_Data_BDE_ICICI_New_SP";
        sqlCom.CommandTimeout = 0;

        SqlParameter losno = new SqlParameter();
        losno.SqlDbType = SqlDbType.VarChar;
        losno.Value = txtlosno_search.Text.ToString();
        losno.ParameterName = "@losno";
        sqlCom.Parameters.Add(losno);

        SqlParameter apsid = new SqlParameter();
        apsid.SqlDbType = SqlDbType.VarChar;
        apsid.Value = txtaps_id.Text.ToString();
        apsid.ParameterName = "@aps_id";
        sqlCom.Parameters.Add(apsid);

        int SqlRow = 0;
        SqlRow = sqlCom.ExecuteNonQuery();

        SqlDataAdapter sqlDA = new SqlDataAdapter();
        sqlDA.SelectCommand = sqlCom;
        DataTable dt = new DataTable();
        sqlDA.Fill(dt);
        sqlCon.Close();

        if (dt.Rows.Count > 0)
        {

            lblindexer_name.Text = dt.Rows[0]["NAME"].ToString().Trim();
            lblstart_time.Text = dt.Rows[0]["Start"].ToString().Trim();
            lblfinal_status.Text = dt.Rows[0]["Indexing"].ToString().Trim();
            lblremark.Text = dt.Rows[0]["Los_remark"].ToString().Trim();
            lblcompleted_date.Text = dt.Rows[0]["Completed"].ToString().Trim();


        }





    }

    private void Get_qdedata()
    {
        Object SaveUSERInfo = (Object)Session["UserInfo"];
        SqlConnection sqlCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);
        sqlCon.Open();

        SqlCommand sqlCom = new SqlCommand();
        sqlCom.Connection = sqlCon;
        sqlCom.CommandType = CommandType.StoredProcedure;
        sqlCom.CommandText = "IRPC_Get_CAM_Data_New_SP";
        sqlCom.CommandTimeout = 0;

        SqlParameter losno = new SqlParameter();
        losno.SqlDbType = SqlDbType.VarChar;
        losno.Value = txtlosno_search.Text.ToString();
        losno.ParameterName = "@losno";
        sqlCom.Parameters.Add(losno);

        SqlParameter apsid = new SqlParameter();
        apsid.SqlDbType = SqlDbType.VarChar;
        apsid.Value = txtaps_id.Text.ToString();
        apsid.ParameterName = "@aps_id";
        sqlCom.Parameters.Add(apsid);

        int SqlRow = 0;
        SqlRow = sqlCom.ExecuteNonQuery();

        SqlDataAdapter sqlDA = new SqlDataAdapter();
        sqlDA.SelectCommand = sqlCom;
        DataTable dt = new DataTable();
        sqlDA.Fill(dt);
        sqlCon.Close();

        if (dt.Rows.Count > 0)
        {
            lblqdeuser1.Text = dt.Rows[0]["username"].ToString().Trim();
            lblqdes_date.Text = dt.Rows[0]["camtime"].ToString().Trim();
            //lblstart_time.Text = dt.Rows[0]["QDestartstatus"].ToString().Trim();
            lblqdecompleted_date.Text = dt.Rows[0]["camcompletedtime"].ToString().Trim();
           // lblqdefinal_status.Text = dt.Rows[0]["cam_remark"].ToString().Trim();

        }
    }

    //private void Get_ddedata()
    //{
    //    Object SaveUSERInfo = (Object)Session["UserInfo"];
    //    SqlConnection sqlCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);
    //    sqlCon.Open();

    //    SqlCommand sqlCom = new SqlCommand();
    //    sqlCom.Connection = sqlCon;
    //    sqlCom.CommandType = CommandType.StoredProcedure;
    //    sqlCom.CommandText = "get_ddedata";
    //    sqlCom.CommandTimeout = 0;

    //    SqlParameter losno = new SqlParameter();
    //    losno.SqlDbType = SqlDbType.VarChar;
    //    losno.Value = txtlosno_search.Text.ToString();
    //    losno.ParameterName = "@losno";
    //    sqlCom.Parameters.Add(losno);


    //    int SqlRow = 0;
    //    SqlRow = sqlCom.ExecuteNonQuery();

    //    SqlDataAdapter sqlDA = new SqlDataAdapter();
    //    sqlDA.SelectCommand = sqlCom;
    //    DataTable dt = new DataTable();
    //    sqlDA.Fill(dt);
    //    sqlCon.Close();

    //    if (dt.Rows.Count > 0)
    //    {

    //        lbldde_user.Text = dt.Rows[0]["NAME"].ToString().Trim();
    //        lblstart_date.Text = dt.Rows[0]["Start time"].ToString().Trim();
    //        lblremk.Text = dt.Rows[0]["DDERemark"].ToString().Trim();
    //        lblcom_date.Text = dt.Rows[0]["Completed Time"].ToString().Trim();
    //        //lblcom_status.Text = dt.Rows[0]["ddecompletestatus"].ToString().Trim();
    //        lblcom_status.Text = dt.Rows[0]["DDE Status"].ToString().Trim();

    //    }
    //}


    private void Get_CPVDATA()
    {
        Object SaveUSERInfo = (Object)Session["UserInfo"];
        SqlConnection sqlCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);
        sqlCon.Open();

        SqlCommand sqlCom = new SqlCommand();
        sqlCom.Connection = sqlCon;
        sqlCom.CommandType = CommandType.StoredProcedure;
        sqlCom.CommandText = "IRPC_Get_CPV_Data_ICICI_New_SP";
        sqlCom.CommandTimeout = 0;

        SqlParameter losno = new SqlParameter();
        losno.SqlDbType = SqlDbType.VarChar;
        losno.Value = txtlosno_search.Text.ToString();
        losno.ParameterName = "@losno";
        sqlCom.Parameters.Add(losno);

        SqlParameter apsid = new SqlParameter();
        apsid.SqlDbType = SqlDbType.VarChar;
        apsid.Value = txtaps_id.Text.ToString();
        apsid.ParameterName = "@aps_id";
        sqlCom.Parameters.Add(apsid);

        int SqlRow = 0;
        SqlRow = sqlCom.ExecuteNonQuery();

        SqlDataAdapter sqlDA = new SqlDataAdapter();
        sqlDA.SelectCommand = sqlCom;
        DataTable dt = new DataTable();
        sqlDA.Fill(dt);
        sqlCon.Close();

        if (dt.Rows.Count > 0)
        {
            lblcpvuser.Text = dt.Rows[0]["NAME"].ToString().Trim();
            lblstartdate.Text = dt.Rows[0]["starttime"].ToString().Trim();
            lblcpvc_date.Text = dt.Rows[0]["done time"].ToString().Trim();
            lblcpvf_status.Text = dt.Rows[0]["cpvstatus"].ToString().Trim();
            //lblMsgXls.Visible = true;
            //lblMsgXls.Text = "Recond found suceccfully!!!!";

        }
        //else
        //{
        //    lblMsgXls.Visible = true;
        //    lblMsgXls.Text = "Recond Not Found";
        //    pnllocation.Visible = false;
        //    pnlindexing.Visible = false;
        //    pnldde.Visible = false;
        //    pnlqde.Visible = false;
        //    Pnlcpvdetails.Visible = false;

        //}

    }

    public void cleardata()
    {
        lblhub.Text = "";
        lblspoke.Text = "";
        lbllocation.Text = "";

        lblindexer_name.Text = "";
        lblstart_time.Text = "";
        lblfinal_status.Text = "";
        lblremark.Text = "";
        lblcompleted_date.Text = "";

        lblqdeuser1.Text = "";
        lblqdes_date.Text = "";
        lblqdecompleted_date.Text = "";
        lblqdefinal_status.Text = "";

        //lbldde_user.Text = "";
        //lblstart_date.Text = "";
        //lblremk.Text = "";
        //lblcom_date.Text = "";
        //lblcom_status.Text = "";

        lblcpvuser.Text = "";
        lblstartdate.Text = "";
        lblcpvc_date.Text = "";
        lblcpvf_status.Text = "";





    }


    protected void txtlosno_search_TextChanged(object sender, EventArgs e)
    {
        lblMsgXls.Text = "done";
    }
}