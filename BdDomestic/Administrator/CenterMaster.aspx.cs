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

public partial class CenterMaster : System.Web.UI.Page
{
    CCommon con = new CCommon();
    protected void Page_Load(object sender, EventArgs e)
    {
        CCCenterMaster objCM = new CCCenterMaster();
        try
        {

            String strCentreID = "";
            lblMsg.Text = "";



            if (Request.QueryString["Centre_Id"] != null && Request.QueryString["Centre_Id"] != "")
            {
                lblMsg.Text = "Edit";


                //if (Session["isEdit"].ToString() != "1")
                //{

                //}
                //else
                //{
            }
            if (!IsPostBack)
            {

                strCentreID = Request.QueryString["Centre_ID"].ToString();
                objCM.CentreID = Request.QueryString["Centre_ID"].ToString();
                HiddenField1.Value = strCentreID;
                objCM.GetCentre();

                txtCenterName.Text = objCM.CenterName;
                txtCenterCode.Text = objCM.CenterCode;
                ddlCluster.SelectedValue = objCM.ClusterID.ToString();
                txtCenterCode.ReadOnly = true;
                valCentreCode.Enabled = false;

                //objCM.Company_Id = strCompanyID;
                //objCM.getCompany();
                //txtCoName.Text = objCM.CompanyName;
                //txtCorAdd1.Text = objCM.CorAdd1;
                //txtCorAdd2.Text = objCM.CorAdd2;
                //txtCorAdd3.Text = objCM.CorAdd3;
                //txtCorCity.Text = objCM.CorCity;
                //txtCorPin.Text = objCM.Corpin;
                //txtRegAdd1.Text = objCM.RegAdd1;
                //txtRegAdd2.Text = objCM.RegAdd2;
                //txtRegAdd3.Text = objCM.RegAdd3;
                //txtRegCity.Text = objCM.RegCity;
                //txtRegPin.Text = objCM.Regpin;
                //txtCoCode.Text = objCM.CompanyCode;
                //}
            }
            //else
            //{
            //    lblMsg.Text = "";
            //}


        }
        catch (Exception exp)
        {
            lblMsg.Text = "Error";
        }
      
    }
   
    protected void btnSave_Click(object sender, EventArgs e)
    {
        string selected = "";
        string strCluster = "";

        if (Request.QueryString["Centre_Id"] != null && Request.QueryString["Centre_Id"] != "")
        {
            CCCenterMaster objCM = new CCCenterMaster();
                        
            OleDbDataReader dr;
            String Sql = "";
            Sql = "select HIER_ID from company_hierarchy_master chm inner join centre_master cl on( cl.centre_id=chm.ref_id) where chm.type='CE' and cl.centre_id ="+HiddenField1.Value.ToString();
            dr = OleDbHelper.ExecuteReader(con.ConnectionString, CommandType.Text, Sql);
            
            while (dr.Read())
            {
                selected = selected + Convert.ToInt32(dr[0]) + ",";

            }
            dr.Close();
            
            objCM.SelectedHierachyID = selected;
        
            objCM.CentreID = HiddenField1.Value;
            objCM.CenterName = txtCenterName.Text;

            objCM.UpdateCentre();
           
            lblMsg.Visible = true;
            lblMsg.Text = "Centre Updated Succesfully";
            objCM.CentreID = HiddenField1.Value;
            if (ddlCluster.Text!=HiddenField2.Value)
            {
                string sql2 = "select hier_id from company_hierarchy_master co inner join cluster_master cl on (co.ref_id=cl.cluster_id) where  type='CL' and cluster_id=" + ddlCluster.SelectedValue.ToString();

                dr = OleDbHelper.ExecuteReader(con.ConnectionString, CommandType.Text, sql2);
               

                while (dr.Read())
                {
                    strCluster = strCluster + Convert.ToInt32(dr[0]) + ",";

                }
                string sql = "select cluster_id from cluster_master where cluster_id=" + "'" + ddlCluster.SelectedValue + "'";

                objCM.ClusterID = OleDbHelper.ExecuteScalar(con.ConnectionString, CommandType.Text, sql).ToString();

                objCM.ClusterHierID = strCluster;
                objCM.CentreID = HiddenField1.Value;
                objCM.ChangeCentre();
            }
            lblMsg.Text = objCM.Massage;
            Session["msg2"] = lblMsg.Text;
            Response.Redirect("CentreViewMaster.aspx");
        }
        else
        {
            CCCenterMaster objCM = new CCCenterMaster();
            objCM.CenterCode = txtCenterCode.Text.Trim();
            objCM.CenterName = txtCenterName.Text.Trim();
            //query for cluster_id
            string sql = "select cluster_id from cluster_master where cluster_id=" + "'" + ddlCluster.SelectedValue + "'";

            objCM.ClusterID = OleDbHelper.ExecuteScalar(con.ConnectionString, CommandType.Text, sql).ToString();
            //query for SelectedHierachyID
            OleDbDataReader dr;
            string sql2 = "select hier_id from company_hierarchy_master co inner join cluster_master cl on (co.ref_id=cl.cluster_id) where  type='CL' and cluster_id=" +ddlCluster.SelectedValue.ToString();

            dr = OleDbHelper.ExecuteReader(con.ConnectionString, CommandType.Text, sql2);
            

            while (dr.Read())
            {
                selected = selected + Convert.ToInt32(dr[0]) + ",";

            }
            objCM.SelectedHierachyID = selected;
            //query for unique centre_code
            OleDbParameter CentreCode = new OleDbParameter("@CentreCode", OleDbType.VarChar, 10);
            CentreCode.Value = txtCenterCode.Text.Trim();
            string sql1 = "select count(*) from centre_master where CENTRE_CODE=?";
            Object o = new object();
            o = OleDbHelper.ExecuteScalar(con.ConnectionString, CommandType.Text, sql1, CentreCode);
            if (Convert.ToInt32(o) == 0)
            {
                lblMsg.Visible = true;

                objCM.InsertCenterMaster();
                
                lblMsg.Text = "Centre Added Successfully ";
                Session["msg2"] = lblMsg.Text;
                Response.Redirect("CentreViewMaster.aspx");
            }
            else
            {
                lblMsg.Visible = true;
                lblMsg.Text = "Centre Code Should not be Duplicate";
            }
        }

         txtCenterCode.Text = "";
         txtCenterName.Text = "";
         ddlCluster.SelectedIndex = 0;
         txtCorAdd1.Text = "";
         txtCorCity.Text = "";
         txtCorPin.Text  = "";
         txtRegAdd1.Text = "";
         txtRegCity.Text = "";
         txtRegPin.Text  = "";

     }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        txtCenterCode.Text = "";
        txtCenterName.Text = "";
        ddlCluster.SelectedIndex = 0;
        txtCorAdd1.Text = "";
        txtCorCity.Text = "";
        txtCorPin.Text = "";
        txtRegAdd1.Text = "";
        txtRegCity.Text = "";
        txtRegPin.Text = "";
        lblMsg.Text = "";
        txtCenterCode.Enabled = true;
        //ddlCluster.Enabled = true;
        valCentreCode.Enabled = true;
        //valddlCluster.Enabled = true;
        Session["msg2"]=null;
        Response.Redirect("CentreViewMaster.aspx");
    }
   
  
    protected void ddlCluster_DataBound(object sender, EventArgs e)
    {
        ddlCluster.Items.Insert(0, new ListItem("Select Cluster", "0"));
    }
    protected void ddlCluster_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}
