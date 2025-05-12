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

public partial class Administrator_StandardTATHour_View : System.Web.UI.Page
{
    C_StandardTatHour objStandardHour = new C_StandardTatHour();
    CCommon objcomman = new CCommon();
    DataSet ds = new DataSet();
    protected void Page_Load(object sender, EventArgs e)
    {
        string Message = Request.QueryString["Message"];
        lblMessage.Text = Message;
        if (!IsPostBack)
        {
            FillStandardTATHourGrid();
            GvView.DataBind();
        }
    }
    private void FillStandardTATHourGrid()
    {
        DataTable dtTatHour = new DataTable();
        dtTatHour = objStandardHour.Show_TatHour();
        GvView.DataSource = dtTatHour;
        GvView.DataBind();

    }
    protected void btnNew_Click(object sender, EventArgs e)
    {
        Response.Redirect("StandarTatHour.aspx");
    }
    protected void GvView_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        string tatId = "";
        tatId = e.CommandArgument.ToString();
        if (e.CommandName == "Edi")
        {
            if (tatId != "")
            {
                Response.Redirect("StandarTatHour.aspx?tatId=" + tatId + " ");
            }
        }
    }
    protected void GvView_RowDataBound(object sender, GridViewRowEventArgs e)
    {

    }
}
