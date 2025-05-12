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

public partial class Pages_ICICIRPC_QCError : System.Web.UI.Page
{
     //Add By : Akanksha
    //Add Date : 11/10/2010
    //SingleUserLogin Login = new SingleUserLogin();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindErrorType();
        }

        //Login.ValidateTokenLoginDetails();
    }
    protected void BindErrorType()
    {
        SqlConnection sqlCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);

        SqlCommand cmd = new SqlCommand("IRPC_MasterSearchCode_SP", sqlCon);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@Types", "ErrorType");
        cmd.Parameters.AddWithValue("@Level", 1);
        SqlDataAdapter adp = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        adp.Fill(ds);

        if (ds != null && ds.Tables[0].Rows.Count > 0)
        {
            dderrortype.DataSource = ds;
            dderrortype.DataValueField = "Code_Id";
            dderrortype.DataTextField = "Description";
            dderrortype.DataBind();
            dderrortype.Items.Insert(0, new ListItem("--Select--", "0"));
        }
    }
    public void searchdata()
    {
        Object SaveUSERInfo = (Object)Session["UserInfo"];
        SqlConnection sqlCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);
        try
        {

            SqlCommand sqlcmd = new SqlCommand("IRPC_Search_LosNo_Error_ICICI_SP", sqlCon);
            sqlcmd.CommandType = CommandType.StoredProcedure;

            sqlcmd.Parameters.AddWithValue("@lno", txtlosno_search.Text);

            sqlCon.Open();

            SqlDataAdapter sqlDA = new SqlDataAdapter();
            sqlDA.SelectCommand = sqlcmd;

            DataTable dt = new DataTable();
            sqlDA.Fill(dt);

            sqlCon.Close();

            if (dt.Rows.Count > 0)
            {

                lblindexname.Text = dt.Rows[0]["bdeuser"].ToString();
                lblindst.Text = dt.Rows[0]["BDE_status"].ToString();
                lblindremark.Text = dt.Rows[0]["BDE_remark"].ToString();
                lblnameofapp.Text = dt.Rows[0]["cname"].ToString();
                lblsmcode.Text = dt.Rows[0]["ApplicationNumber"].ToString();
                lblddename.Text = dt.Rows[0]["Location"].ToString();
                lblddest.Text = dt.Rows[0]["camuser"].ToString();

                lblcamstatus.Text = dt.Rows[0]["Cam_status"].ToString();
                lblcamremark.Text = dt.Rows[0]["Cam_remark"].ToString();


                //lbldderemark.Text = dt.Rows[0]["DDERemark"].ToString();
                //lblcpvname.Text = dt.Rows[0]["cpvuser"].ToString();
                //lblcpvst.Text = dt.Rows[0]["CPVStatus"].ToString();

            }
        }

        catch (Exception ex)
        {
            lblMsgXls.Visible = true;
            lblMsgXls.Text = "Error :" + ex.Message;
        }
        finally
        {
            sqlCon.Close();
            sqlCon.Dispose();
        }


    }
    //Add By : Akanksha
    //Add Date : 11/10/2010
    public void EditData()
    {
        
            Object SaveUSERInfo = (Object)Session["UserInfo"];
            SqlConnection sqlCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);
            try
            {
                if (lblindexname.Text != "")
                {
                    SqlCommand sqlcmd = new SqlCommand("IRPC_EditData_Tran_Error_Update_ICICI_SP", sqlCon);
                    sqlcmd.CommandType = CommandType.StoredProcedure;

                    sqlcmd.Parameters.AddWithValue("@losno", txtlosno_search.Text.Trim());
                    sqlcmd.Parameters.AddWithValue("@Error_Remark", txterrorup.Text.Trim());
                    sqlcmd.Parameters.AddWithValue("@Error_Type", dderrortype.SelectedValue.ToString());
                    sqlcmd.Parameters.AddWithValue("@Modifyby", Convert.ToString(((UserInfo.structUSERInfo)(SaveUSERInfo)).UserId));


                    sqlCon.Open();

                    int i = sqlcmd.ExecuteNonQuery();

                    sqlCon.Close();

                    lblmsg.Text = "Record Updated ...";

                    txtlosno_search.Text = "";
                    lblindexname.Text = "";
                    lblindst.Text = "";
                    lblindremark.Text = "";
                    lblnameofapp.Text = "";
                    lblsmcode.Text = "";
                    lblddename.Text = "";
                    lblddest.Text = "";
                    //lbldderemark.Text = "";
                    //lblcpvname.Text = "";
                    //lblcpvst.Text = "";
                    txterrorup.Text = "";
                    dderrortype.SelectedValue = "0";

                }
                else
                {
                    lblmsg.Text = "Record Not Updated...";
                }
            }

            catch (Exception ex)
            {
                lblMsgXls.Visible = true;
                lblMsgXls.Text = "Error :" + ex.Message;
            }
            finally
            {
                sqlCon.Close();
                sqlCon.Dispose();
            }
    }
    //Add By : Akanksha
    //Add Date : 11/10/2010
    protected void btnsearch_Click(object sender, EventArgs e)
    {
        searchdata();
    }
    //Add By : Akanksha
    //Add Date : 11/10/2010
    protected void btnedit_Click(object sender, EventArgs e)
    {
        EditData();
    }
    //Add By : Akanksha
    //Add Date : 11/10/2010
    protected void btncancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Pages/Menu.aspx", true);
    }
}
