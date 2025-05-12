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

/// <summary>
/// Made by : Gargi Srivastava at 1-Nov-2007
/// Purpose : For Assigning Query to users of Perticular Centre 
/// </summary>

public partial class Administrator_AssignRights : System.Web.UI.Page
{
    CBuildQuery objBuildQuery = new CBuildQuery();
    DataTable dt = new DataTable();
    DataTable dt1 = new DataTable();
    DataRow dr;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            
        
        
            if (Request.QueryString.Count!= 0)
            {
                if (Request.QueryString["QueryID"].ToString() != null && Request.QueryString["QueryID"].ToString() != "")
                {
                    hidQueryID.Value = Request.QueryString["QueryID"].ToString();
                }
                if ((Request.QueryString["Mode"].ToString() != null) && (Request.QueryString["Mode"].ToString() != ""))
                {
                    hidMode.Value = Request.QueryString["Mode"].ToString();
                }
            }
            SelectQuery();
            SelectCentre();
            if (hidMode.Value == "Edit")
            {
                GetAssignedQuery();
            }

          }
    }
   /// <summary>
   /// This Method is Used to Fill the ListBox Of Saved Query which 
   /// is Saved in the DataBase.
   /// </summary>
    private void SelectQuery()
    {
        DataSet ds = new DataSet();
        try
        {
            ds = objBuildQuery.SelectQuery();
            lstbSelectQuery.DataValueField = "Query_ID";
            lstbSelectQuery.DataTextField = "Query_Defination";
            lstbSelectQuery.DataSource = ds;
            lstbSelectQuery.DataBind();
        }
        catch (Exception exp)
        {
            lblMessage.Text = "Error : " + exp.Message;
        }
        
    }
    /// <summary>
    /// This Method is Used to Fill the ListBox of Centre.
    /// </summary>
    private void SelectCentre()
    {
        DataSet dt = new DataSet();
        try
        {
            dt = objBuildQuery.SelectRole();
            lstbSelectRole.DataValueField = "CENTRE_ID";
            lstbSelectRole.DataTextField = "CENTRE_NAME";
            lstbSelectRole.DataSource = dt;
            lstbSelectRole.DataBind();
        }
        catch (Exception exp)
        {
            lblMessage.Text = "Error : " + exp.Message;
        }
               
    }

    private void ShowUsers()
    {
        DataSet ds = new DataSet();
        lblMessage.Text = "";
        try
        {
          
            if (hidCentreID.Value.ToString() != "")
            {
                ds = objBuildQuery.SelectUsers(hidCentreID.Value);
                
                if (ds.Tables[0].Rows.Count > 0)
                {
                    lstbAssignUsers.DataValueField = "EMP_ID";
                    lstbAssignUsers.DataTextField = "EMP_Name";
                    lstbAssignUsers.DataSource = ds;
                    lstbAssignUsers.DataBind();
                }
                else
                {
                    lstbAssignUsers.DataValueField = "EMP_ID";
                    lstbAssignUsers.DataTextField = "EMP_Name";
                    lstbAssignUsers.DataSource = ds;
                    lstbAssignUsers.DataBind();
                    lblMessage.Text = "No Users Exist For This Centre Name";
                }
            }
            else
            {
                lblMessage.Text = "Please Select the Centre Name";
            }
        }
        catch (Exception exp)
        {
            lblMessage.Text = "Error : " + exp.Message;
        }

    }

    protected void btnShowUsers_Click(object sender, EventArgs e)
    {
        ShowUsers();
    }
/// <summary>
/// This Method is Used to Save the Users Assign
/// for centres and For a Particular Saved Query.
/// </summary>
    private void SaveAssignment()
    {
        OleDbDataReader oledbDataReader;
        try
        {
            foreach (ListItem item in lstbSelectQuery.Items)
            {
                if (item.Selected)
                {
                    objBuildQuery.QueryID = int.Parse(item.Value.ToString());
                    //objBuildQuery.DeleteAssignUsers();
                    foreach (ListItem itemCentre in lstbSelectRole.Items)
                    {
                        if (itemCentre.Selected)
                        {
                            foreach (ListItem itemUsers in lstbAssignUsers.Items)
                            {
                                if (itemUsers.Selected)
                                {
                                    oledbDataReader=objBuildQuery.ReadCentreAndUserExist(itemCentre.Value.ToString(), itemUsers.Value.ToString());
                                    if (oledbDataReader.Read())
                                    {
                                        objBuildQuery.CentreID = itemCentre.Value;
                                        objBuildQuery.QueryID = int.Parse(item.Value.ToString());
                                        objBuildQuery.UserID = itemUsers.Value;
                                        string strCheckDuplicate = string.Empty;
                                        //here we are checking the duplicate emp assigned to the saved query 
                                        strCheckDuplicate = objBuildQuery.funCheckDuplicateRights().ToString();
                                        if (strCheckDuplicate == "FALSE")
                                        {
                                            lblMessage.Text = objBuildQuery.InsertAssignUsers();
                                        }
                                    }
                                }
                            }
                        }
                    }

                }


            }
        }
        catch (Exception exp)
        {
            lblMessage.Text = "Error : " + exp.Message;
        }
  
    }

    protected void btnAssign_Click(object sender, EventArgs e)
    {
            SaveAssignment();
    }
    /// <summary>
    /// This Method is Used to Fill the Grid which Shows the Assigned
    /// users ,Centre,and Saved Query.
    /// </summary>
    public void BindGrid()
    {
        try
        {
            dt.Columns.Add("Sr No");
            dt.Columns.Add("Query");
            dt.Columns.Add("Centre Name");
            dt.Columns.Add("Assigned User");
            dt.Columns.Add("Assign_ID");


            dt1 = objBuildQuery.SearchForAssignedUsers();
            int sr_no;

            if (dt1.Rows.Count > 0)
            {
                sr_no = 1;
                for (int i = 0; i < dt1.Rows.Count; i++)
                {
                    dr = dt.NewRow();
                    dr[0] = sr_no.ToString();
                    dr[1] = dt1.Rows[i]["Query"].ToString();
                    dr[2] = dt1.Rows[i]["Centre Name"];
                    dr[3] = dt1.Rows[i]["Assigned User"];
                    dr[4] = dt1.Rows[i]["Assign_ID"];

                    dt.Rows.Add(dr);
                    sr_no++;
                }

            }
            else
            {
            }
            gvViewForAssignedUsers.DataSource = dt;
            gvViewForAssignedUsers.DataBind();
        }
        catch (Exception exp)
        {
            lblMessage.Text = "Error : " + exp.Message;
        }
  
    }
    /// <summary>
    /// This Method is Used to Read the Assigned Queries.
    /// </summary>
    private void GetAssignedQuery()
    {
        try
        {
            string sCentre = "";
            DataTable dt = new DataTable();
            objBuildQuery.QueryID = int.Parse(hidQueryID.Value);
            lstbSelectQuery.SelectedValue = hidQueryID.Value;
            dt = objBuildQuery.GetAssignedUsers();
            for (int j = 0; j < dt.Rows.Count; j++)
            {
                for (int i = 0; i < lstbSelectRole.Items.Count; i++)
                {
                    if (lstbSelectRole.Items[i].Value.ToString() == dt.Rows[j]["Centre_ID"].ToString().Trim())
                    {
                        lstbSelectRole.Items[i].Selected = true;
                        sCentre += dt.Rows[j]["Centre_ID"].ToString().Trim() + ",";
                    }
                }
            }
            hidCentreID.Value = sCentre.TrimEnd(',');
            DataSet ds = new DataSet();
            if (hidCentreID.Value.ToString() != "")
            {
                ds = objBuildQuery.SelectUsers(hidCentreID.Value);
                lstbAssignUsers.DataValueField = "EMP_ID";
                lstbAssignUsers.DataTextField = "EMP_Name";
                lstbAssignUsers.DataSource = ds;
                lstbAssignUsers.DataBind();
                for (int k = 0; k < dt.Rows.Count; k++)
                {
                    for (int i = 0; i < lstbAssignUsers.Items.Count; i++)
                    {
                        if (lstbAssignUsers.Items[i].Value.ToString() == dt.Rows[k]["EMP_ID"].ToString().Trim())
                        {
                            lstbAssignUsers.Items[i].Selected = true;
                        }

                    }
                }
            }
            dt.Clear();
            dt.Dispose();
            ds.Clear();
            ds.Dispose();
        }
        catch(Exception exp)
        {
            lblMessage.Text = "Error : " + exp.Message;
        }
  
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        try
        {
            lblMessage.Text = "";
            objBuildQuery.QueryDefination = txtQueryWiseSearch.Text.Trim().ToString();
            objBuildQuery.UserName = txtUserWiseSearch.Text.Trim().ToString();
            BindGrid();
        }
        catch (Exception exp)
        {
            lblMessage.Text = "Error : " + exp.Message;
        }
  
    }

   
    protected void btnCancel_Click1(object sender, EventArgs e)
    {
        SelectQuery();
        SelectCentre();
        DataSet ds = new DataSet();
        ds = objBuildQuery.CancelUsers();
        lstbAssignUsers.DataValueField = "EMP_ID";
        lstbAssignUsers.DataTextField = "EMP_Name";
        lstbAssignUsers.DataSource = ds;
        lstbAssignUsers.DataBind();
    }
    protected void gvViewForAssignedUsers_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        string assignID = "";
        if (e.CommandName.Equals("Del"))
        {
            assignID = e.CommandArgument.ToString();
            
            lblMessage.Text = objBuildQuery.DeleteUniqueAssignUsers(assignID);
            BindGrid();
           

        }

    }
   
    protected void gvViewForAssignedUsers_RowEditing(object sender, GridViewEditEventArgs e)
    {

    }
    protected void gvViewForAssignedUsers_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            LinkButton lbDelete = (LinkButton)e.Row.FindControl("lbDelete");

            lbDelete.Attributes.Add("onclick", "javascript:return " +
                          "confirm('Are you sure you want to delete this record')");
        }
    }
}


