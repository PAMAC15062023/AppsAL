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

public partial class Administrator_SubCentreMaster : System.Web.UI.Page
{

    DataTable dt = new DataTable();
   
    CSubCentreMaster objSCM = new CSubCentreMaster();
    CCommon con = new CCommon();
    protected void Page_Load(object sender, EventArgs e)
    {
     

    }
    protected void ddlCluster_SelectedIndexChanged(object sender, EventArgs e)
    {
        int iClusterId=Convert.ToInt32 (ddlCluster.SelectedValue);
        sdsddlCentre.SelectCommand = "select CENTRE_NAME,CENTRE_ID from CENTRE_MASTER Where CLUSTER_ID="+iClusterId+" order by CENTRE_NAME";
        ddlCentre.DataSource = sdsddlCentre;
        ddlCentre.DataBind();
        sdsgvSubCentre.SelectCommand="";
        gvSubCentre.DataSource = sdsgvSubCentre;
        gvSubCentre.DataBind();
        lblMsg.Text = "";

    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        try
        {

            if (lblMsg.Text == "Edit" && hidSubCentre.Value != "Add")
            {

               
                objSCM.SubCentreId = ViewState["SubCentreId"].ToString();
                objSCM.ClusterId = ddlCluster.SelectedValue.Trim();
                objSCM.CentreId = ddlCentre.SelectedValue.Trim();
                objSCM.SubCentreName = txtSubCentreName.Text.Trim();
              
                objSCM.Address = txtAddress.Text.Trim();
               
               objSCM.updateSubCentre();
                
                lblMsg.Visible = true;
                lblMsg.Text = "Record updated successfully";
            
                txtSubCentreName.Text ="";
                txtAddress.Text = "";
              
               GetSubCentreDetail(ddlCentre.SelectedValue);
               txtSubCentreName.Focus();
            }
            else
            {
           
                 
                     objSCM.SubCentreId= "0";
                     objSCM.ClusterId =ddlCluster.SelectedValue.Trim (); 
                     objSCM.CentreId = ddlCentre.SelectedValue.Trim ();
                     objSCM.SubCentreName = txtSubCentreName.Text.Trim();
                     objSCM.Address =txtAddress.Text.Trim (); 
                     int count = objSCM.GetDulplicateSubCentre(objSCM.CentreId);
                     if (count == 0)
                     {
                         objSCM.InsertSubCentre();
                         lblMsg.Visible = true;
                         lblMsg.Text = "SubCenter Saved successfully";
                         txtSubCentreName.Text = "";
                         txtSubCentreName.Focus();
                         txtAddress.Text = "";
                         GetSubCentreDetail(ddlCentre.SelectedValue);
                     }
                     else
                     {
                         lblMsg.Text = "SubCentre already Exists ";
                         lblMsg.Visible = true;
                         txtSubCentreName.Focus();
                     }

              
               
               
            }
          
        }
        catch (Exception ex)
        {
            lblMsg.Visible = true;
            lblMsg.Text = "Error :" + ex.Message;
        }
    }
   

    protected void ddlCluster_DataBound(object sender, EventArgs e)
    {
        ddlCluster.Items.Insert(0, new ListItem("--Select--", "0"));
    }
    protected void ddlCentre_DataBound(object sender, EventArgs e)
    {
        ddlCentre.Items.Insert(0, new ListItem("--Select--", "0"));
    }

 

protected void  ddlCentre_SelectedIndexChanged(object sender, EventArgs e)
{
    
        GetSubCentreDetail(ddlCentre.SelectedValue);
      
}

     private void GetSubCentreDetail(string sCentreId)
    {
        string sql1 = "select * from SubCentreMaster where CentreId='" + sCentreId + "'";
        OleDbDataReader dr;
        dr = OleDbHelper.ExecuteReader(con.ConnectionString, CommandType.Text, sql1);
        gvSubCentre.DataSource = dr;
        gvSubCentre.DataBind();
        gvSubCentre.AllowSorting = false;
        gvSubCentre.AllowPaging = false;
        if (gvSubCentre.Rows.Count == 0)
        {
            lblMsg1.Text = "No record Found";
            lblMsg1.Visible = true;
        }
        else
        {
            lblMsg1.Visible = false;
        }


      
    }

    protected void gvSubCentre_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        string strid = "";
      
        
        if (e.CommandName == "Edit")
        {
          
                strid = e.CommandArgument.ToString();
                hidSubCentre.Value = e.CommandArgument.ToString();

                ViewState["SubCentreId"] = e.CommandArgument.ToString();
                
                objSCM.SubCentreId = e.CommandArgument.ToString();
                objSCM.GetSubCentre(ddlCentre.SelectedValue.ToString ().Trim());
                txtAddress.Text  = objSCM.Address;
              
                txtSubCentreName.Text =objSCM .SubCentreName;
                lblMsg.Text = "Edit";
                hidDupli.Value = "";
               
                lblMsg.Visible = false;
               // btnAdd.Visible = false;
             
                btnAdd.Visible = true;
               
            }
            else if (e.CommandName == "Delete1")
            {
                ViewState["SubCentreId"] = e.CommandArgument.ToString();
                objSCM.SubCentreId = ViewState["SubCentreId"].ToString();
                string subcenterid = objSCM.SubCentreId;
                objSCM.DeleteSubCentre(subcenterid);
                lblMsg.Text = "Record Deleted successfully ";
                lblMsg.Visible = true;
                GetSubCentreDetail(ddlCentre.SelectedValue);
                txtSubCentreName.Focus();
            }

           
    }
    protected void gvSubCentre_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            LinkButton lnk = (LinkButton)e.Row.FindControl("lnkDelete");

            lnk.Attributes.Add("onclick", "javascript:return " +
                          "confirm('Are you sure you want to delete this record')");
        }
    }

    protected void gvSubCentre_RowEditing(object sender, GridViewEditEventArgs e)
    {

    }

  
}
