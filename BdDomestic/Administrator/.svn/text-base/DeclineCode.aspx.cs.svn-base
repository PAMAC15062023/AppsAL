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

public partial class Administrator_DeclineCode : System.Web.UI.Page
{
    DataTable dt = new DataTable();
    CDeclineCode cd = new CDeclineCode();
    CCommon con = new CCommon();
    protected void Page_Load(object sender, EventArgs e)
    {
        txtDeclineCode.Enabled = true;
        gvDeclineCode.AllowSorting = false;
        gvDeclineCode.AllowPaging = false;
    }
    
    protected void ddlClient_DataBound(object sender, EventArgs e)
    {
        ddlClient.Items.Insert(0, new ListItem("--Select Client--", "0"));
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        hidDeclinedCode.Value = "Add";
        
        if (lblMsg.Text == "Edit")
        {
            ViewState["v1"] = null;
        }
       
        if (ViewState["v1"] != null)
        {
            dt = (DataTable)ViewState["v1"];
        }
        if (ViewState["v1"] == null)
        {
            dt.Columns.Add("Decline Code");
            dt.Columns.Add("Description");
        }
        
        ////Added by hemangi kambli on 11-May-2007 -------------
        DataTable dtTmp=new DataTable();
        dtTmp = dt;
        int iDuplicate = 0;
        if (dtTmp.Rows.Count > 0)
        {
            for (int i = 0; i < dtTmp.Rows.Count; i++)
            {
                if (dtTmp.Rows[i]["Decline Code"].ToString() == txtDeclineCode.Text.Trim())
                {
                    iDuplicate = 1;
                }               
            }
            if (iDuplicate == 0)
            {
                DataRow row;
                row = dt.NewRow();
                row["Decline Code"] = txtDeclineCode.Text;
                row["Description"] = txtDescription.Text;
                dt.Rows.Add(row);
            }
        }
        else
        {
            DataRow row;
            row = dt.NewRow();
            row["Decline Code"] = txtDeclineCode.Text;
            row["Description"] = txtDescription.Text;
            dt.Rows.Add(row);
        }
        hidDupli.Value = "AddNew";
        if (iDuplicate == 1)
        {
            lblMsg.Visible = true;
            lblMsg.Text = "Duplicate declined Code should not be entered";
            hidDupli.Value = "";
        }
        else
        {
            btnSave.Visible = true;
        }
        ////------------------------------------------------------
        /////commented by hemangi kambli on 11-May-2007 -----------
       // DataRow row;
       // row = dt.NewRow();
       // string[] strDup = hidDupli.Value.Split(',');
       // bool bolduplicate = false;
       //    foreach(string str in strDup)
       //    {
       //        if (str == txtDeclineCode.Text)
       //        {
       //            bolduplicate = true;

       //        }
       //    }
       //if (!bolduplicate)
       //{
       //    dt.Rows.Add();
       //    dt.Rows[dt.Rows.Count - 1]["Decline Code"] = txtDeclineCode.Text;
       //    dt.Rows[dt.Rows.Count - 1]["Description"] = txtDescription.Text;
       //}
       //else
       //{
       //    lblMsg.Visible = true;
       //    lblMsg.Text = "Duplicate declined Code should not be entered";
       //}
        //////////////////----------------------------------------------------------
        ViewState["v1"] = dt;
        gvDeclineCode.DataSource = dt;
        gvDeclineCode.DataBind();
        btnSave.Visible = true;
        //hidDupli.Value = hidDupli.Value + txtDeclineCode.Text + ',';
        txtDescription.Text = "";
        txtDeclineCode.Text = "";
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (lblMsg.Text == "Edit"&& hidDeclinedCode.Value != "Add")
        {

            //cd.DeclineCode = hidDeclinedCode.Value;
            ///
            cd.ClientID = ddlClient.SelectedValue;
            cd.DeclineCode = txtDeclineCode.Text.Trim();
            cd.Description = txtDescription.Text.Trim();
            ////
            cd.updateDeclineCode();
            //Commented by hemangi kambli on 11-May-2007 --------------
            //dt = (DataTable)ViewState["v1"];
            //OleDbParameter declinedCode1 = new OleDbParameter("@DeclinedCode", OleDbType.VarChar, 10);
            //declinedCode1.Value = dt.Rows[dt.Rows.Count - 1]["Decline Code"].ToString();
            //string sql2 = "select count(*) from declined_code_master where DECLINED_CODE=?";
            //Object o1 = new object();
            //o1 = OleDbHelper.ExecuteScalar(con.ConnectionString, CommandType.Text, sql2, declinedCode1);
            //if (Convert.ToInt32(o1) == 0)
            //{
            //    for (int i = 0; i < dt.Rows.Count; i++)
            //    {
            //        cd.ClientID = ddlClient.SelectedValue;
            //        cd.DeclineCode = dt.Rows[i]["Decline Code"].ToString();
            //        cd.Description = dt.Rows[i]["Description"].ToString();
            //        cd.InsertDeclineCode();
            //    }
            //    lblMsg.Visible = true;
            //    lblMsg.Text = "Declined Cocde Save successfully";
            //}
            //else
            //{
            //    lblMsg.Visible = true;
            //    lblMsg.Text = "Duplicate declined Code should not be entered";
            //}
            //---------------------------------------------------------------------
            lblMsg.Visible = true;
            lblMsg.Text = "Record updated successfully";
            txtDeclineCode.Text = "";
            txtDescription.Text = "";
            //ddlClient.SelectedIndex = 0;
            gvDeclineCode.DataBind();
        }
        else
        {
            dt = (DataTable)ViewState["v1"];
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string sql1 = "select count(*) from declined_code_master where DECLINED_CODE=? " +
                               " AND CLIENT_ID='" + ddlClient.SelectedValue.ToString() + "'";
                Object o = new object();
                OleDbParameter declinedCode = new OleDbParameter("@DeclinedCode", OleDbType.VarChar, 10);
                declinedCode.Value = dt.Rows[i]["Decline Code"].ToString();
                o = OleDbHelper.ExecuteScalar(con.ConnectionString, CommandType.Text, sql1, declinedCode);
                if (Convert.ToInt32(o) == 0)
                {
                        cd.ClientID = ddlClient.SelectedValue;
                        cd.DeclineCode = dt.Rows[i]["Decline Code"].ToString();
                        cd.Description = dt.Rows[i]["Description"].ToString();
                        cd.InsertDeclineCode();
                }
                //Commented by hemangi kambli on 11-May-2007
                //else
                //{
                //    lblMsg.Visible = true;
                //    lblMsg.Text = "Duplicate declined Code should not be entered";
                //}
                ///------------------------------------------------------
            }
            lblMsg.Visible = true;
            lblMsg.Text = "Declined Code Save successfully";
            txtDeclineCode.Text = "";
            txtDescription.Text = "";
          
        }
        hidDeclinedCode.Value = "Save";
        ViewState["v1"] = null;
        //dt.Columns.Clear();
        //if (hidDupli.Value != "AddNew")
        //    GetDeclineCodeDetail(ddlClient.SelectedValue.ToString());        
        btnAdd.Visible = true;
        txtDeclineCode.Enabled = true;
        if (hidDeclinedCode.Value == "Save")
        {
            dt.Columns.Clear();
            dt.Rows.Clear();
            dt.Clear();
            GetDeclineCodeDetail(ddlClient.SelectedValue);
        }
    }

    protected void gvDeclineCode_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        dt = (DataTable)ViewState["v1"];
        dt.Rows[e.RowIndex].Delete();
        gvDeclineCode.DataSource = dt;
        gvDeclineCode.DataBind();
        ViewState["v1"] = dt;

    }
    protected void ddlClient_SelectedIndexChanged(object sender, EventArgs e)
    {
        ViewState["v1"] = null;
        dt.Columns.Clear();
        dt.Rows.Clear();
        dt.Clear();
        GetDeclineCodeDetail(ddlClient.SelectedValue);
        lblMsg.Visible = false;
    }

    private void GetDeclineCodeDetail(string sClientId)
    {
        string sql1 = "select declined_code,description,id from declined_code_master where client_id='" + sClientId + "'";
        OleDbDataReader dr;
        dr = OleDbHelper.ExecuteReader(con.ConnectionString, CommandType.Text, sql1);
        
        if (ViewState["v1"] == null)
        {
            dt.Columns.Add("Decline Code");
            dt.Columns.Add("Description");
        }
        
        if (ViewState["v1"] != null)
        {
            dt = (DataTable)ViewState["v1"];
        }
        if (dr.HasRows)
        {
            while (dr.Read())
            {
                dt.Rows.Add();
                dt.Rows[dt.Rows.Count - 1]["Decline Code"] = dr[0].ToString();
                dt.Rows[dt.Rows.Count - 1]["Description"] = dr[1].ToString();
            }
            lblMsg1.Text = "";
        }
        else
        {
            dt.Rows.Clear();
            lblMsg1.Visible = true;
            lblMsg1.Text = "Record not found";
        }
        
        gvDeclineCode.DataSource = dt;
        gvDeclineCode.DataBind();
        gvDeclineCode.AllowSorting = false;
        gvDeclineCode.AllowPaging = false;
        ViewState["v1"] = dt;
    }
    protected void gvDeclineCode_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        string strid = "";
        //if (ViewState["v1"] != 0)
        //{
        //    dt = (DataTable)ViewState["v1"];
        //}
        if (e.CommandName == "Edit")
        {
            if (hidDeclinedCode.Value != "Add")
            {
                strid = e.CommandArgument.ToString();
                //hidDeclinedCode.Value = e.CommandArgument.ToString();

                cd.DeclineCode = e.CommandArgument.ToString();
                cd.GetDeclined(ddlClient.SelectedValue.ToString());
                txtDeclineCode.Text = cd.DeclineCode;
                txtDescription.Text = cd.Description;
                ddlClient.SelectedValue = cd.ClientID;
                lblMsg.Text = "Edit";
                hidDupli.Value = "";
                txtDeclineCode.Enabled = false;
                lblMsg.Visible = false;
                btnAdd.Visible = false;
                btnSave.Visible = true;
                txtDescription.Focus();
            }
            else if (hidDeclinedCode.Value == "Add")
            {
                lblMsg.Visible = true;
                lblMsg.Text = "First save all entries.";
            }
        }
    }


    protected void gvDeclineCode_RowEditing(object sender, GridViewEditEventArgs e)
    {

    }
}
