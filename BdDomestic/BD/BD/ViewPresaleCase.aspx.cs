using System;
using System.Data;
using System.Web.UI.WebControls;
public partial class ViewPresaleCase : System.Web.UI.Page
{
    CBDContract oBD = new CBDContract();
    CCommon objCom = new CCommon();

    //sdsIDOC.ConnectionString = objConn.ConnectionString; 
    DataSet ds = new DataSet();



    protected void Page_Load(object sender, EventArgs e)
    {


        //add by kamal matekar***************************
        if (!IsPostBack)
        {
            string UserId = Session["UserId"].ToString();

            //string UserId = "101103573";
            if ("101103545" == UserId || "101190" == UserId || "101566" == UserId || "10133" == UserId || "101335" == UserId || "101103547" == UserId || "101103582" == UserId)
            {
                lblleadby.Visible = true;
                ddlLeadBy.Visible = true;
                lblbd.Visible = true;
                ddlBDManager.Visible = true;
            }

            //showgrid();

            lblMsg.Text = "";
            if (Request.QueryString.Count > 0)
            {
                if (Request.QueryString["Msg"].ToString() != "" || Request.QueryString["Msg"].ToString() != null)
                {
                    lblMsg.Text = Request.QueryString["Msg"].ToString();
                }
            }
            Register_Javascript();

        }

    }

    private void Register_Javascript()
    {
        btnshow.Attributes.Add("onclick", "javascript:return Validate_Search();");
    }


    public void showgrid()
    {

        //bool dateIsValid = false;
        //dateIsValid = FunctioncompareDate();

        //if (dateIsValid == true)
        //{


        string UserId = Session["UserId"].ToString();

        //string UserId = "101335";

        if (ddlMeetinglead.Visible == true)
        {
            oBD.MeetingLead = ddlMeetinglead.SelectedValue;
        }
        if (ddlLeadBy.Visible == true)
        {
            oBD.LeadBy = ddlLeadBy.SelectedValue;
        }
        if (ddlBDManager.Visible == true)
        {
            oBD.BDManager = ddlBDManager.SelectedValue;
        }


        //string sSelectSql = sdsPresaleCase;

        //SqlCommand cmd = new SqlCommand(objCom, sSelectSql);
        //SqlDataAdapter da = new SqlDataAdapter(cmd);

        string sFromDate = fdate.Text.Trim();
        string sToDate = tdate.Text.Trim();




        ds = oBD.fillgridview(UserId, (objCom.strDate(sFromDate)), (objCom.strDate(sToDate)));



        //String sFromDate = txtFromDate.Text.Trim();
        //String sToDate = txtToDate.Text.Trim();


        //ds = oBD.fillgridview(UserId,sFromDate,sToDate);

        //ds = oBD.fillgridview(UserId,txtFromDate.Text.Trim(),txtToDate.Text.Trim());

        //ds = oBD.fillgridview(UserId, txtFromDate.Text, txtToDate.Text);
        //if (txtFromDate.Text.Trim() != "" && txtToDate.Text.Trim()!="")
        //{
        //    ds = oBD.fillgridview(UserId, objCom.strDate(txtFromDate.Text.Trim()).ToString(), objCom.strDate(txtToDate.Text.Trim()).ToString());
        //}
        //else
        //{
        //    ds = oBD.fillgridview(UserId, txtFromDate.Text.Trim(), txtToDate.Text.Trim());
        //}

        //SqlDataAdapter sqlda1 = new SqlDataAdapter();
        //sqlda1.SelectCommand = sqlcmd;

        //DataTable dt1 = new DataTable();
        //sqlda1.Fill(dt1);


        gvPresaleCase.DataSource = ds;
        gvPresaleCase.DataBind();
        //}
    }

    protected void ddlMeetinglead_DataBound(object sender, EventArgs e)
    {
        ddlMeetinglead.Items.Insert(0, new ListItem("--Select--", ""));
    }
    protected void ddlBDManager_DataBound(object sender, EventArgs e)
    {
        ddlBDManager.Items.Insert(0, new ListItem("--Select--", ""));
    }
    protected void ddlLeadBy_DataBound(object sender, EventArgs e)
    {
        ddlLeadBy.Items.Insert(0, new ListItem("--Select--", ""));
    }


    protected void gvPresaleCase_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        String strCont_ID = "";
        if (e.CommandName == "EditMeeting")
        {
            strCont_ID = e.CommandArgument.ToString();
            if (strCont_ID != "")
            {
                Response.Redirect("MeetingDetails.aspx?Mode=A&NID=" + strCont_ID);
            }
        }
        if (e.CommandName == "EditContract")
        {
            strCont_ID = e.CommandArgument.ToString();
            if (strCont_ID != "")
            {
                Response.Redirect("PresaleContractEntry.aspx?Mode=E&NID=" + strCont_ID);
            }
        }
    }
    protected void btnNew_Click(object sender, EventArgs e)
    {
        string UserId = Session["UserId"].ToString();
        if (UserId == "101103548")
        {
            lblMsg.Text = "U are not authorised to add new";

        }
        else
            Response.Redirect("PresaleContractEntry.aspx");

    }
    protected void gvPresaleCase_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvPresaleCase.PageIndex = e.NewPageIndex;



        string UserId = Session["UserId"].ToString();
        if (ddlMeetinglead.Visible == true)
        {
            oBD.MeetingLead = ddlMeetinglead.SelectedValue;
        }
        if (ddlLeadBy.Visible == true)
        {
            oBD.LeadBy = ddlLeadBy.SelectedValue;
        }
        if (ddlBDManager.Visible == true)
        {
            oBD.BDManager = ddlBDManager.SelectedValue;
        }

        // ds = oBD.fillgridview(UserId, objCom.strDate(txtFromDate.Text.Trim()).ToString(), objCom.strDate(txtToDate.Text.Trim()).ToString());

        //if (txtFromDate.Text.Trim() != "" && txtToDate.Text.Trim() != "")
        //{
        //    ds = oBD.fillgridview(UserId, objCom.strDate(txtFromDate.Text.Trim()).ToString(), objCom.strDate(txtToDate.Text.Trim()).ToString());
        //}
        //else
        //{
        //    ds = oBD.fillgridview(UserId, txtFromDate.Text.Trim(), txtToDate.Text.Trim());
        //}

        gvPresaleCase.DataSource = ds;
        gvPresaleCase.DataBind();
    }
    protected void btnshow_Click(object sender, EventArgs e)
    {
        showgrid();
        if (gvPresaleCase.Rows.Count == 0)
            lblMsg.Text = "No record found.";
    }
    protected void btnshow_Click1(object sender, EventArgs e)
    {
        showgrid();
        if (gvPresaleCase.Rows.Count == 0)
            lblMsg.Text = "No record found.";
    }
    protected void btnNew_Click1(object sender, EventArgs e)
    {
        string UserId = Session["UserId"].ToString();
        if (UserId == "101103548")
        {
            lblMsg.Text = "U are not authorised to add new";

        }
        else
            Response.Redirect("PresaleContractEntry.aspx");
    }

    //public bool FunctioncompareDate()
    //{

    //    DateTime sFromDate;
    //    DateTime sToDate;
    //    sFromDate = Convert.ToDateTime(txtFromDate.Text.Trim());
    //    sToDate = Convert.ToDateTime(txtToDate.Text.Trim());     

    //    bool bReturn = true;
    //    if (sFromDate > sToDate)
    //    {
    //        bReturn = false;
    //    }
    //    else
    //    {
    //        bReturn = true;


    //    }
    //    return bReturn;
    //} 

}

