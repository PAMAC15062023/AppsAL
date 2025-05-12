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

public partial class HR_BIS_ENTRY_VIEW : System.Web.UI.Page
{
    CBISENTRY CBE = new CBISENTRY();
    DataSet ds = new DataSet();
    CCommon con = new CCommon();
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            string strRole = Session["RoleID"].ToString();
            string[] strRole1 = strRole.Split(',');

            bool bflag = false;

         
            foreach (string str in strRole1)
            {

                if (str == "22")
                {
                    lblSubcentre.Visible = true;
                    ddlSubcentre.Visible = true;
                    if (!IsPostBack)
                    {
                        ShowGrid();

                       
                       
                            sdsSubcetre.SelectCommand = "Select SubCentreName,SubCentreId from SubCentreMaster where CentreId=" + Session["CentreId"].ToString() + " order by SubCentreName";
                            ddlSubcentre.DataBind();
                       
                    }
                   

                }
                if (str == "23")
                {
                    lblSubcentre.Visible = true;
                    ddlSubcentre.Visible = true;
                    btnshow.Visible = true;
                    lblSubcentreCo.Visible = true;
                    if (!IsPostBack)
                    {

                       
                        
                        bflag = true;
                      
                        if (Request.QueryString["SubCentreID1"] != "" && Request.QueryString["SubCentreID1"] != null)
                        {
                            sdsSubcetre.SelectCommand = "Select SubCentreName,SubCentreId from SubCentreMaster where CentreId=" + Session["CentreId"].ToString() + " order by SubCentreName";
                            ddlSubcentre.DataBind();

                            //ddlSubcentre.SelectedValue = Request.QueryString["SubCentreID1"].ToString().Trim();

                        }
                        else
                        {
                            sdsSubcetre.SelectCommand = "Select SubCentreName,SubCentreId from SubCentreMaster where CentreId=" + Session["CentreId"].ToString() + " order by SubCentreName";
                            ddlSubcentre.DataBind();
                            //ddlSubcentre.SelectedValue = Session["SubcentreID"].ToString();
                        }
                        ShowGrid();
                    }


                }

                if (str == "24")
                {
                    lblSubcentre.Visible = true;
                    ddlSubcentre.Visible = true;
                    lblCentre.Visible = true;
                    ddlCentre.Visible = true;
                    lblCluster.Visible = true;
                    ddlCluter.Visible = true;
                    lblCentreCo.Visible = true;
                    lblSubcentreCo.Visible = true;
                    lblClusterCo.Visible = true;
                 
                  
                    if (!IsPostBack)
                    {
                        bflag = true;

                        if (Request.QueryString["ClusterID1"] != "" && Request.QueryString["ClusterID1"] != null)
                        {
                            ddlCluter.DataBind();
                            ddlCluter.SelectedValue = Request.QueryString["ClusterID1"].ToString().Trim();
                            sdsCentre.SelectCommand = "SELECT [CENTRE_ID], [CENTRE_NAME] FROM [CENTRE_MASTER] where cluster_id=" + Request.QueryString["ClusterID1"].ToString().Trim() + " order by CENTRE_NAME";
                            ddlCentre.DataBind();
                            //ddlCentre.SelectedValue = Request.QueryString["CentreID1"].ToString().Trim();
                            sdsSubcetre.SelectCommand = "Select SubCentreName,SubCentreId from SubCentreMaster where CentreId=" + Request.QueryString["CentreID1"].ToString().Trim() + " order by SubCentreName";
                            ddlSubcentre.DataBind();
                            //ddlSubcentre.SelectedValue = Request.QueryString["SubCentreID1"].ToString().Trim();
                        }
                        else
                        {
                            ddlCluter.DataBind();
                            ddlCluter.SelectedValue = Session["ClusterId"].ToString();
                            sdsCentre.SelectCommand = "SELECT [CENTRE_ID], [CENTRE_NAME] FROM [CENTRE_MASTER] where cluster_id=" + Session["ClusterId"].ToString() + " order by CENTRE_NAME";
                            ddlCentre.DataBind();
                            //ddlCentre.SelectedValue = Session["CentreId"].ToString();
                            sdsSubcetre.SelectCommand = "Select SubCentreName,SubCentreId from SubCentreMaster where CentreId=" + Session["CentreId"].ToString() + " order by SubCentreName";
                            ddlSubcentre.DataBind();
                            //ddlSubcentre.SelectedValue = Session["SubcentreID"].ToString();
                        }
                        ShowGrid();
                    }
                    CBE.UserRole1 = "HO-HR";
                }
                if (str == "25")
                {

                    lblSubcentre.Visible = true;
                    ddlSubcentre.Visible = true;
                    lblCentre.Visible = true;
                    ddlCentre.Visible = true;
                    lblCentreCo.Visible = true;
                    lblSubcentreCo.Visible = true;
                    
                    if (!IsPostBack)
                    {

                        if (Request.QueryString["CentreID1"] != "" && Request.QueryString["CentreID1"] != null)
                        {
                            if (ddlCluter.Visible == true)
                            {
                                sdsCentre.SelectCommand = "SELECT [CENTRE_ID], [CENTRE_NAME] FROM [CENTRE_MASTER] where cluster_id=" + Request.QueryString["ClusterID1"].ToString().Trim() + " order by CENTRE_NAME";
                                ddlCentre.DataBind();
                                //ddlCentre.SelectedValue = Request.QueryString["CentreID1"].ToString().Trim();
                                sdsSubcetre.SelectCommand = "Select SubCentreName,SubCentreId from SubCentreMaster where CentreId=" + Request.QueryString["CentreID1"].ToString().Trim() + " order by SubCentreName";
                                ddlSubcentre.DataBind();

                                //ddlSubcentre.SelectedValue = Request.QueryString["SubCentreID1"].ToString().Trim();

                            }
                            else
                            {
                                sdsCentre.SelectCommand = "SELECT [CENTRE_ID], [CENTRE_NAME] FROM [CENTRE_MASTER] where cluster_id=" + Session["ClusterId"].ToString() + " order by CENTRE_NAME";
                                ddlCentre.DataBind();
                                //ddlCentre.SelectedValue = Request.QueryString["CentreID1"].ToString().Trim();
                                sdsSubcetre.SelectCommand = "Select SubCentreName,SubCentreId from SubCentreMaster where CentreId=" + Request.QueryString["CentreID1"].ToString().Trim() + " order by SubCentreName";
                                ddlSubcentre.DataBind();
                                //ddlSubcentre.SelectedValue = Request.QueryString["SubCentreID1"].ToString().Trim();
                            }

                        }
                        else
                        {
                            sdsCentre.SelectCommand = "SELECT [CENTRE_ID], [CENTRE_NAME] FROM [CENTRE_MASTER] where cluster_id=" + Session["ClusterId"].ToString() + " order by CENTRE_NAME";
                            ddlCentre.DataBind();
                            //ddlCentre.SelectedValue = Session["CentreId"].ToString();
                            sdsSubcetre.SelectCommand = "Select SubCentreName,SubCentreId from SubCentreMaster where CentreId=" + Session["CentreId"].ToString() + " order by SubCentreName";
                            ddlSubcentre.DataBind();
                            //ddlSubcentre.SelectedValue = Session["SubCentreId"].ToString();

                        }
                        ShowGrid();
                    }
                    bflag = true;



                }

            }

            if (Request.QueryString["SubCentreID1"] != "" && Request.QueryString["SubCentreID1"] != null)
            {
                ShowGrid();
            }
        }
        catch (Exception ex)
        {
            
        }
    }
   
   
   
    protected void ddlCentre_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (ddlCluter.Visible == true)
            {
                if (ddlCentre.SelectedIndex == 0)
                {
                    sdsSubcetre.SelectCommand = "Select SubCentreName,SubCentreId from SubCentreMaster order by SubCentreName";
                    ddlSubcentre.DataBind();
                }
                else
                {
                    sdsSubcetre.SelectCommand = "Select SubCentreName,SubCentreId from SubCentreMaster where CentreId=" + ddlCentre.SelectedValue + " order by SubCentreName";
                    ddlSubcentre.DataBind();
                }
            }
            else
            {
                if (ddlCentre.SelectedIndex == 0)
                {
                    sdsSubcetre.SelectCommand = "Select SubCentreName,SubCentreId from SubCentreMaster where  ClusterId ='" + Session["ClusterID"] + "'   order by SubCentreName";
                    ddlSubcentre.DataBind();
                }
                else
                {
                    sdsSubcetre.SelectCommand = "Select SubCentreName,SubCentreId from SubCentreMaster where  ClusterId ='" + Session["ClusterID"] + "' and CentreID='"+ddlCentre.SelectedValue+"'  order by SubCentreName";
                    ddlSubcentre.DataBind();
                }
            }
        }
        catch (Exception ex)
        {
            lblmsg.Text = ex.Message;
            
        }
    }
    protected void ddlCentre_DataBound(object sender, EventArgs e)
    {
        ddlCentre.Items.Insert(0, new ListItem("--All--", "0"));
        
    }
    protected void ddlCluter_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (ddlCluter.SelectedIndex == 0)
            {
                sdsCentre.SelectCommand = "SELECT [CENTRE_ID], [CENTRE_NAME] FROM [CENTRE_MASTER] order by CENTRE_NAME ";
                ddlCentre.DataBind();
            }
            else
            {
                sdsCentre.SelectCommand = "SELECT [CENTRE_ID], [CENTRE_NAME] FROM [CENTRE_MASTER] WHERE ([CLUSTER_ID] = " + ddlCluter.SelectedValue + ") order by CENTRE_NAME";
                ddlCentre.DataBind();
            }
            if (ddlCentre.SelectedIndex == 0)
            {
                string strRole = Session["RoleID"].ToString();
                string[] strRole1 = strRole.Split(',');


                foreach (string str in strRole1)
                {
                    if (str == "25")
                    {
                        sdsSubcetre.SelectCommand = "Select SubCentreName,SubCentreId from SubCentreMaster where ClusterID=" + Session["ClusterId"].ToString() + " order by SubCentreName";
                    }
                    if (str == "24")
                    {
                        sdsSubcetre.SelectCommand = "Select SubCentreName,SubCentreId from SubCentreMaster  order by SubCentreName";

                    }
                }
                ddlSubcentre.DataBind();
            }
            else
            {
                sdsSubcetre.SelectCommand = "Select SubCentreName,SubCentreId from SubCentreMaster where CentreId=" + ddlCentre.SelectedValue + " order by SubCentreName";
                ddlSubcentre.DataBind();
            }
        }
        catch (Exception ex)
        {
            lblmsg.Text = ex.Message;
        }
    }
    protected void ddlCluter_DataBound(object sender, EventArgs e)
    {
        ddlCluter.Items.Insert(0, new ListItem("--All--", "0"));
    }
    protected void ddlSubcentre_DataBound(object sender, EventArgs e)
    {
        ddlSubcentre.Items.Insert(0, new ListItem("--All--", "0"));
       
    }
    protected void btnshow_Click(object sender, EventArgs e)
    {

        ShowGrid();
       
    }
    protected void GV_EMP_VEIW_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            GV_EMP_VEIW.PageIndex = e.NewPageIndex;
            if (ddlCluter.Visible == true && ddlCentre.Visible == true && ddlSubcentre.Visible == true)
            {
                CBE.ClusterID = ddlCluter.SelectedValue;
                CBE.CentreID = ddlCentre.SelectedValue;
                CBE.SubCentreID = ddlSubcentre.SelectedValue;

            }
            else if (ddlCentre.Visible == true && ddlSubcentre.Visible == true)
            {
                CBE.CentreID = ddlCentre.SelectedValue;
                CBE.SubCentreID = ddlSubcentre.SelectedValue;
                CBE.ClusterID = Session["ClusterId"].ToString();
            }
            else if (ddlSubcentre.Visible == true)
            {
                CBE.SubCentreID = ddlSubcentre.SelectedValue;
                CBE.CentreID = Session["CentreId"].ToString();
                CBE.ClusterID = Session["ClusterId"].ToString();
            }
            else
            {
                CBE.SubCentreID = Session["SubcentreID"].ToString();
                CBE.CentreID = Session["CentreId"].ToString();
                CBE.ClusterID = Session["ClusterId"].ToString();
            }

            ds = CBE.FillBISView(txtFromDate.Text.Trim(), txtToDate.Text.Trim());
            GV_EMP_VEIW.DataSource = ds;
            GV_EMP_VEIW.DataBind();
        }
        catch (Exception ex)
        {
            lblmsg.Text = ex.Message;
        }
    }
    protected void btAddNew_Click(object sender, EventArgs e)
    {
       
           
            if (ddlCluter.Visible == true && ddlCentre.Visible == true && ddlSubcentre.Visible == true)
            {
                Response.Redirect("BISENTRY.aspx?SubCentreID=" + ddlSubcentre.SelectedValue + " &CentreID=" + ddlCentre.SelectedValue +" &ClusterID="+ddlCluter.SelectedValue);
            }
            else if(ddlCentre.Visible==true && ddlSubcentre.Visible==true && ddlCluter.Visible == false )
            {
                Response.Redirect("BISENTRY.aspx?SubCentreID=" + ddlSubcentre.SelectedValue + " &CentreID=" + ddlCentre.SelectedValue );
            }
            else if (ddlSubcentre.Visible == true && ddlCluter.Visible == false && ddlCentre.Visible == false)
            {
                Response.Redirect("BISENTRY.aspx?SubCentreID=" + ddlSubcentre.SelectedValue);
            }
            else
            {
                Response.Redirect("BISENTRY.aspx");
 
            }
            
    }

    protected void GV_EMP_VEIW_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        String strEMP_ID = "";
        strEMP_ID = e.CommandArgument.ToString();
        if (e.CommandName == "Ed")
        {
                     
                 

                 string strRole = Session["RoleID"].ToString();
                 string[] strRole1 = strRole.Split(',');


                 if (ddlCluter.Visible == true && ddlCentre.Visible == true && ddlSubcentre.Visible == true)
                 {
                     Response.Redirect("BISENTRY.aspx?SubCentreID=" + ddlSubcentre.SelectedValue + " &CentreID=" + ddlCentre.SelectedValue + " &ClusterID=" + ddlCluter.SelectedValue + " &EMP_ID=" + strEMP_ID);
                 }
                 else if (ddlCentre.Visible == true && ddlSubcentre.Visible == true && ddlCluter.Visible == false)
                 {
                     Response.Redirect("BISENTRY.aspx?SubCentreID=" + ddlSubcentre.SelectedValue + " &CentreID=" + ddlCentre.SelectedValue + "&EMP_ID=" + strEMP_ID);
                 }
                 else if (ddlSubcentre.Visible == true && ddlCluter.Visible == false && ddlCentre.Visible == false)
                 {
                     Response.Redirect("BISENTRY.aspx?SubCentreID=" + ddlSubcentre.SelectedValue + "&EMP_ID=" + strEMP_ID);
                 }
                 else
                 {
                     Response.Redirect("BISENTRY.aspx?EMP_ID=" + strEMP_ID);

                 }
                 
                   
        }

       
        

    }

    public void ShowGrid()
    {
        if (ddlCluter.Visible == true && ddlCentre.Visible == true && ddlSubcentre.Visible == true)
        {
            CBE.ClusterID = ddlCluter.SelectedValue;
            CBE.CentreID = ddlCentre.SelectedValue;
            CBE.SubCentreID = ddlSubcentre.SelectedValue;

        }
        else if (ddlCentre.Visible == true && ddlSubcentre.Visible == true)
        {
            CBE.CentreID = ddlCentre.SelectedValue;
            CBE.SubCentreID = ddlSubcentre.SelectedValue;
            CBE.ClusterID = Session["ClusterId"].ToString();
        }
        else if (ddlSubcentre.Visible == true)
        {
            CBE.SubCentreID = ddlSubcentre.SelectedValue;
            CBE.CentreID = Session["CentreId"].ToString();
            CBE.ClusterID = Session["ClusterId"].ToString();
        }
        else
        {
            CBE.SubCentreID = Session["SubcentreID"].ToString();
            CBE.CentreID = Session["CentreId"].ToString();
            CBE.ClusterID = Session["ClusterId"].ToString();
        }
       
            if (txtEmpCode.Text.Trim() != "")
            {
                CBE.EMPCODE = txtEmpCode.Text.Trim();
            }
            if (txtEmpName.Text.Trim() != "")
            {
                CBE.EMPNAME = txtEmpName.Text.Trim().Replace(' ', '%');
            }
        
        ds = CBE.FillBISView(txtFromDate.Text.Trim(), txtToDate.Text.Trim());
        GV_EMP_VEIW.DataSource = ds;
        GV_EMP_VEIW.DataBind();
    }
}
