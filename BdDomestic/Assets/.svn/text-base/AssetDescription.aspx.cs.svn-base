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


public partial class Assets_AssetDescription : System.Web.UI.Page
{
    CCommon objcon = new CCommon();
    object obj;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session.Count <= 0)
        {
            Response.Redirect("../Logout.aspx");
        }
        lblid.Text = "";
        String assetdesccode = "";

        lblid.Text = "";

        if (!IsPostBack)
        {
            string qry = "";
            qry = "Select * from Asset_desc_master";
            OleDbDataAdapter ol = new OleDbDataAdapter(qry, objcon.ConnectionString);
            DataTable dt = new DataTable();
            DataSet ds = new DataSet();
            ol.Fill(ds, "Search");
            dt = ds.Tables["Search"];
            if (dt.Rows.Count > 0)
            {
                grdvw.DataSource = dt;
                grdvw.DataBind();
                grdvw.Visible = true;
            }

            if (Request.QueryString["asset_desc"] != null && Request.QueryString["asset_desc"] != "")
            {

                lblmsg.Text = "Edit";
                txtcode.ReadOnly = true;
                assetdesccode = Request.QueryString["asset_desc"].ToString();
                txttype.Text = assetdesccode;
                qry = "Select asset_desc_code from asset_desc_master where asset_desc = '" + assetdesccode + "'";
                obj = OleDbHelper.ExecuteScalar(objcon.ConnectionString, CommandType.Text, qry);
                txtcode.Text = obj.ToString();
            }
        }

    }
    protected void grdvw_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        String assetdesccode = "";
        if (e.CommandName == "Edit")
        {
            assetdesccode = e.CommandArgument.ToString();
            if (assetdesccode != "")
            {
                Response.Redirect("AssetDescription.aspx?asset_desc="+ assetdesccode);
            }
        }
    }
    protected void grdvw_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            LinkButton l = (LinkButton)e.Row.FindControl("lnkbtn");
        }
    }

    protected void btnid_Click(object sender, EventArgs e)
    {
        try
        {
            string qry = "";
            //lblid.Text = "Edit";
            if (txtcode.Text == "" && txttype.Text == "")
            {
                lblid.Text = "Please Select Asset desc Code and Type";
                lblid.Visible = true;
            }
            else if (lblmsg.Text != "Edit")
            {
                qry = "select asset_desc_code from asset_desc_master where asset_desc='" + txttype.Text + "'";
                 object pre =OleDbHelper.ExecuteScalar(objcon.ConnectionString, CommandType.Text, qry);

                 if (pre != null)
                 {
                     lblid.Text = "This Asset desc is already Exists...";
                     lblid.Visible = true;

                 }
                 else
                 {

                     qry = "Insert into Asset_desc_master values('" + txtcode.Text + "','" + txttype.Text + "')";
                     OleDbHelper.ExecuteNonQuery(objcon.ConnectionString, CommandType.Text, qry);
                     lblid.Text = "Record Saved Successfully.....";
                     lblid.Visible = true;
                 }

            }

            else if (lblmsg.Text == "Edit")
            {
                qry = "Update Asset_desc_master set asset_desc ='" + txttype.Text + "' where asset_desc_code='" + txtcode.Text + "'";
                OleDbHelper.ExecuteScalar(objcon.ConnectionString, CommandType.Text, qry);
                lblid.Text = "Record Updated Successfully.....";
                lblid.Visible = true;
            }

            qry = "Select * from Asset_desc_master";
            OleDbDataAdapter ol = new OleDbDataAdapter(qry, objcon.ConnectionString);
            DataTable dt = new DataTable();
            DataSet ds = new DataSet();
            ol.Fill(ds, "Search");
            dt = ds.Tables["Search"];
            if (dt.Rows.Count > 0)
            {
                grdvw.DataSource = dt;
                grdvw.DataBind();
                grdvw.Visible = true;
            }
            txtcode.Text = "";
            txttype.Text = "";
            txtcode.ReadOnly = false;
            lblmsg.Text = "";


        }
        catch (Exception ex)
        {
            lblid.Text = ex.ToString();
        }
    }
    protected void btncancel_Click(object sender, EventArgs e)
    {
        txtcode.Text = "";
        txttype.Text = "";
        txtcode.ReadOnly = false;
        lblmsg.Text = "";
    }
}
