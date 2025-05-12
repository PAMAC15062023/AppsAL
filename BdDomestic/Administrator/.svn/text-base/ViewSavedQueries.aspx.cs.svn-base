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
using System.IO;
/// <summary>
/// Made by : Gargi Srivastava at 31-OCt-2007
/// Purpose : To View the Saved Queries in dataBase 
/// </summary>

public partial class Administrator_ViewSavedQueries : System.Web.UI.Page
{
    CBuildQuery objBuildQuery = new CBuildQuery();
    CCommon con = new CCommon();
    DataTable dt = new DataTable();
    DataTable dt1 = new DataTable();
    DataRow dr;
    
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        PropertySet();
        BindGrid();

    }
    protected void btnAddNew_Click(object sender, EventArgs e)
    {
        Response.Redirect("BuildQuery.aspx");
    }
    /// <summary>
    /// This Method is Used to Assign the Controls Values to the Class Properties.
    /// </summary>
    private void PropertySet()
    {
        try
        {
            if (txtCreatedDate.Text.Trim() != "")
            {
                objBuildQuery.AddedDate = con.strDate(txtCreatedDate.Text.Trim());
            }
            objBuildQuery.QueryDefination = txtQueryDefination.Text.Trim().ToString();
        }
        catch (Exception exp)
        {
            lblMessage.Text = "Error : " + exp.Message;
        }
    }
    /// <summary>
    /// This Method is Used to Fill the Grid.
    /// </summary>
    public void BindGrid()
    {
        try
        {
            dt.Columns.Add("Sr No");
            dt.Columns.Add("Query Defination");
            dt.Columns.Add("Created Date");
            dt.Columns.Add("Query_ID");
            dt.Columns.Add("Query_Text_File");


            dt1 = objBuildQuery.SearchQuery();
            int sr_no;

            if (dt1.Rows.Count > 0)
            {
                sr_no = 1;
                for (int i = 0; i < dt1.Rows.Count; i++)
                {
                    dr = dt.NewRow();
                    dr[0] = sr_no.ToString();
                    dr[1] = dt1.Rows[i]["Query Defination"].ToString();
                    dr[2] = dt1.Rows[i]["Created Date"];
                    dr[3] = dt1.Rows[i]["Query_ID"];
                    dr[4] = dt1.Rows[i]["Query_Text_File"];

                    dt.Rows.Add(dr);
                    sr_no++;
                }

            }
            else
            {
            }
            gvSearch.DataSource = dt;
            gvSearch.DataBind();
        }
        catch (Exception exp)
        {
            lblMessage.Text = "Error : " + exp.Message;
        }
    }
    protected void gvSearch_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        string queryID = "";
        if (e.CommandName.Equals("Edit"))
        {
            queryID = e.CommandArgument.ToString();
            Response.Redirect("BuildQuery.aspx?QueryID=" + queryID + "&Mode=Edit");
        }
        if (e.CommandName.Equals("View"))
        {
            queryID = e.CommandArgument.ToString();
            Response.Redirect("BuildQuery.aspx?QueryID=" + queryID + "&Mode=View");
        }
        if (e.CommandName.Equals("Del"))
        {
            string queryArgument = e.CommandArgument.ToString();
            string textFileName = "";
            string[] arrQuery = queryArgument.Split('-');
            for (int i = 0; i < arrQuery.Length-1; i++)
              {
                  if (arrQuery[0].Length > 0)
                 {
                     queryID = arrQuery[0].ToString();
                 }
                 if (arrQuery[1].Length > 0)
                 {
                     textFileName = arrQuery[1].ToString();
                 }
             }

            DeleteTextFile(textFileName);
            lblMessage.Text = objBuildQuery.DeleteQuery(queryID);
            BindGrid();

        }

        if (e.CommandName.Equals("Assign"))
        {
            queryID = e.CommandArgument.ToString();
            Response.Redirect("AssignRights.aspx?QueryID=" + queryID + "&Mode=Edit");
        }

    }
    protected void gvSearch_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            LinkButton lbDelete = (LinkButton)e.Row.FindControl("lbDelete");

            lbDelete.Attributes.Add("onclick", "javascript:return " +
                          "confirm('Are you sure you want to delete this record')");
        }
    }
    /// <summary>
    /// This Method is Used to Delete the Text File Priviously Stored in the DataBase.
    /// </summary>
    /// <param name="fileName"></param>
    private void DeleteTextFile(string fileName)
    {
        try
        {
            FileInfo TheFile = new FileInfo(MapPath("../SavedQueries/" + fileName));
            if (TheFile.Exists)
            {
                File.Delete(MapPath("../SavedQueries/" + fileName));
            }
            else
            {
                throw new FileNotFoundException();
            }
        }
        catch (FileNotFoundException ex)
        {
            lblMessage.Text += ex.Message;
        }
        catch (Exception ex)
        {
            lblMessage.Text += ex.Message;
        }
    }

   

}
