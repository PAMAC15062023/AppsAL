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

public partial class HR_HR_BIS_APPROVAL_VIEW : System.Web.UI.Page
{
    CBISENTRY CBE = new CBISENTRY();
    DataSet ds = new DataSet();
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            CBE.Approval = "Approval";

            string strRole = Session["RoleID"].ToString();
            string[] strRole1 = strRole.Split(',');
            if (GV_EMP_VEIW.Rows.Count == 0)
            {
                btnSave.Visible = false;

            }

            string strRoleDes = Session["RoleID"].ToString();
            string[] strRoleDes1 = strRole.Split(',');
            bool bflgSubcentre = false;
            bool bflgCentre = false;
            bool bflgCluster = false;
            bool bflgHO = false;
            foreach (string str in strRoleDes1)
            {
                if (str == "22")
                {
                    
                    bflgSubcentre = true;
                }
                if (str == "23")
                {
                   

                    bflgCentre = true;
                }
                if (str == "24")
                {
                    bflgHO = true;
                   
                  
                }
                if (str == "25")
                {

                    bflgCluster = true;
                  
                }
            }
            if (bflgHO == true)
            {
                CBE.UserRole1 = "HO-HR";
            }
            if (bflgHO == false && bflgCluster == true)
            {
                CBE.UserRole1 = "Cluster-HR";
            }
            if (bflgHO == false && bflgCluster == false && bflgCentre == true)
            {
                CBE.UserRole1 = "CentreHead";
            }
            if (bflgHO == false && bflgCluster == false && bflgCentre == false && bflgSubcentre == true)
            {
                CBE.UserRole1 = "SubCentreHead";
            }
            bool bflag = false;
            foreach (string str in strRole1)
            {
                if (str == "22")
                {

                    if (!IsPostBack)
                    {

                        ShowGrid();
                    }
                   
                        btnShow.Visible = true;
                  
                   
                }
                if (str == "23")
                {
                    lblSubcentre.Visible = true;
                    ddlSubcentre.Visible = true;
                    btnShow.Visible = true;
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
                    btnShow.Visible = true;
                    bflag = true;
                   
                    if (!IsPostBack)
                    {

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
                }
                if (str == "25")
                {

                    lblSubcentre.Visible = true;
                    ddlSubcentre.Visible = true;
                    lblCentre.Visible = true;
                    ddlCentre.Visible = true;
                    lblCentreCo.Visible = true;
                    lblSubcentreCo.Visible = true;
                    btnShow.Visible = true;
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
            lblmsg.Text = ex.Message;
        }
    }
    protected void ddlCentre_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (ddlCentre.SelectedIndex == 0)
            {
                string strRole = Session["RoleID"].ToString();
                string[] strRole1 = strRole.Split(',');


                foreach (string str in strRole1)
                {
                    if (str == "25")
                    {
                        sdsSubcetre.SelectCommand = "Select SubCentreName,SubCentreId from SubCentreMaster where ClusterID=" + Session["ClusterId"].ToString() + " ";
                    }
                    if (str == "24")
                    {
                        sdsSubcetre.SelectCommand = "Select SubCentreName,SubCentreId from SubCentreMaster  ";

                    }
                }
                ddlSubcentre.DataBind();
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
                    sdsSubcetre.SelectCommand = "Select SubCentreName,SubCentreId from SubCentreMaster where  ClusterId ='" + Session["ClusterID"] + "' and CentreID='" + ddlCentre.SelectedValue + "'  order by SubCentreName";
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
                sdsCentre.SelectCommand = "SELECT [CENTRE_ID], [CENTRE_NAME] FROM [CENTRE_MASTER]  ";
                ddlCentre.DataBind();
            }
            else
            {
                sdsCentre.SelectCommand = "SELECT [CENTRE_ID], [CENTRE_NAME] FROM [CENTRE_MASTER] WHERE ([CLUSTER_ID] = " + ddlCluter.SelectedValue + ") ";
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
                        sdsSubcetre.SelectCommand = "Select SubCentreName,SubCentreId from SubCentreMaster where ClusterID=" + Session["ClusterId"].ToString() + " ";
                    }
                    if (str == "24")
                    {
                        sdsSubcetre.SelectCommand = "Select SubCentreName,SubCentreId from SubCentreMaster  ";

                    }
                }
                ddlSubcentre.DataBind();
            }
            else
            {
                sdsSubcetre.SelectCommand = "Select SubCentreName,SubCentreId from SubCentreMaster where CentreId=" + ddlCentre.SelectedValue + " ";
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
    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("EMPID_CL");
            dt.Columns.Add("EMPID_HO");
            dt.Columns.Add("APPRCL");
            dt.Columns.Add("APPRHO");

            CBE.UserRole = hdnField.Value;
            int i = 0;

            foreach (GridViewRow row in GV_EMP_VEIW.Rows)
            {

                DropDownList ddlAppCl;
                DropDownList ddlAppHO;

                HiddenField hidIDCL = (HiddenField)row.FindControl("hidEmpIDCL");
                HiddenField hidIDHO = (HiddenField)row.FindControl("hidEmpIDHO");
                ddlAppCl = (DropDownList)row.FindControl("ddlAppCl");
                ddlAppHO = (DropDownList)row.FindControl("ddlAppHO");

                dt.Rows.Add();
                dt.Rows[i]["EMPID_CL"] = hidIDCL.Value;
                dt.Rows[i]["EMPID_HO"] = hidIDHO.Value;
                dt.Rows[i]["APPRCL"] = ddlAppCl.SelectedValue;
                dt.Rows[i]["APPRHO"] = ddlAppHO.SelectedValue;


                CBE.UserIDCluster = Session["UserID"].ToString();
                CBE.UserIDHO = Session["UserID"].ToString();
                i++;
            }
            CBE.UpdateApproval(dt);
            lblmsg.Text = "Record updated successfully";
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
    protected void GV_EMP_VEIW_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            string strRole = Session["RoleID"].ToString();
            string[] strRole1 = strRole.Split(',');
            DropDownList ddlAppCl;
            DropDownList ddlAppHO;

            bool bCL = false;
            bool bHO = false;
            ddlAppCl = (DropDownList)e.Row.FindControl("ddlAppCl");
            ddlAppHO = (DropDownList)e.Row.FindControl("ddlAppHO");

            HiddenField hidIDCL = (HiddenField)e.Row.FindControl("hidEmpIDCL");
            HiddenField hidIDHO = (HiddenField)e.Row.FindControl("hidEmpIDHO");
            if (e.Row.RowType.ToString() == "DataRow")
            {

                foreach (string str in strRole1)
                {
                    if (str == "22" || str == "23")
                    {
                        if (bCL == false)
                        {
                            ddlAppCl.Enabled = false;

                        }
                        else
                        {
                            ddlAppCl.Enabled = true;


                        }
                        if (bHO == false)
                        {
                            ddlAppHO.Enabled = false;

                        }
                        else
                        {
                            ddlAppHO.Enabled = true;


                        }
                        btnSave.Visible = false;
                       


                    }
                    if (str == "25")
                    {
                        ddlAppCl.Enabled = true;


                        GV_EMP_VEIW.Columns[10].Visible = false;
                        bCL = true;
                        btnSave.Visible = true;
                        btAddNew.Visible = true;
                        CBE.UserRole = "Cluster";

                    }
                    if (str == "24")
                    {
                        ddlAppHO.Enabled = true;


                        GV_EMP_VEIW.Columns[9].Visible = false;
                        bHO = true;
                        btnSave.Visible = true;
                        btAddNew.Visible = true;
                        CBE.UserRole = "HO-HR";
                    }
                    if (bHO == true && bCL == true)
                    {
                        ddlAppCl.Enabled = true;

                        ddlAppHO.Enabled = true;
                        btnSave.Visible = true;
                        btAddNew.Visible = true;
                        CBE.UserRole = "Both";

                        GV_EMP_VEIW.Columns[9].Visible = true;
                        GV_EMP_VEIW.Columns[10].Visible = true;
                    }
                    if (bHO == true || bCL == true)
                    {

                        btnSave.Visible = true;
                        btAddNew.Visible = true;
                    }
                }
                if (CBE.UserRole == "Both")
                {
                    DataRow[] dr = ds.Tables[0].Select("emp_id='" + hidIDCL.Value + "'");
                    ddlAppCl.SelectedValue = dr[0]["APPROVED_BY_CLUSTER"].ToString().Trim();
                    ddlAppHO.SelectedValue = dr[0]["APPROVED_BY_HOHR"].ToString().Trim();
                }
                else if (CBE.UserRole == "HO-HR")
                {
                    DataRow[] dr = ds.Tables[0].Select("emp_id='" + hidIDHO.Value + "'");
                    ddlAppHO.SelectedValue = dr[0]["APPROVED_BY_HOHR"].ToString().Trim();
                }
                else if (CBE.UserRole == "Cluster")
                {
                    DataRow[] dr = ds.Tables[0].Select("emp_id='" + hidIDHO.Value + "'");
                    ddlAppCl.SelectedValue = dr[0]["APPROVED_BY_CLUSTER"].ToString().Trim();
                }
                else
                {
                    DataRow[] dr = ds.Tables[0].Select("emp_id='" + hidIDCL.Value + "'");
                    ddlAppCl.SelectedValue = dr[0]["APPROVED_BY_CLUSTER"].ToString().Trim();
                    ddlAppHO.SelectedValue = dr[0]["APPROVED_BY_HOHR"].ToString().Trim();
                }
            }
            hdnField.Value = CBE.UserRole;
        }
        catch (Exception ex)
        {
            lblmsg.Text = ex.Message;
        }
    }
    protected void btAddNew_Click(object sender, EventArgs e)
    {
        string str2 = "Y";
        string strRole = Session["RoleID"].ToString();
        string[] strRole1 = strRole.Split(',');


        if (ddlCluter.Visible == true && ddlCentre.Visible == true && ddlSubcentre.Visible == true)
        {
            Response.Redirect("BISENTRY.aspx?SubCentreID=" + ddlSubcentre.SelectedValue + " &CentreID=" + ddlCentre.SelectedValue + " &ClusterID=" + ddlCluter.SelectedValue + " &ID=" + str2);
        }
        else if (ddlCentre.Visible == true && ddlSubcentre.Visible == true && ddlCluter.Visible == false)
        {
            Response.Redirect("BISENTRY.aspx?SubCentreID=" + ddlSubcentre.SelectedValue + " &CentreID=" + ddlCentre.SelectedValue + " &ID=" + str2);
        }
        else if (ddlSubcentre.Visible == true && ddlCluter.Visible == false && ddlCentre.Visible == false)
        {
            Response.Redirect("BISENTRY.aspx?SubCentreID=" + ddlSubcentre.SelectedValue + " &ID=" + str2);
        }
        else
        {
            Response.Redirect("BISENTRY.aspx?ID=" + str2);

        }
    }
    protected void btnShow_Click(object sender, EventArgs e)
    {
        ShowGrid();

    }
    protected void GV_EMP_VEIW_PageIndexChanging(object sender, GridViewPageEventArgs e)
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
    protected void GV_EMP_VEIW_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        String strEMP_ID = "";
        strEMP_ID = e.CommandArgument.ToString();
        string str="Y";
        if (e.CommandName == "Ed")
        {


            string strRole = Session["RoleID"].ToString();
            string[] strRole1 = strRole.Split(',');

          
            if (ddlCluter.Visible == true && ddlCentre.Visible == true && ddlSubcentre.Visible == true)
            {
                Response.Redirect("BISENTRY.aspx?SubCentreID=" + ddlSubcentre.SelectedValue + " &CentreID=" + ddlCentre.SelectedValue + " &ClusterID=" + ddlCluter.SelectedValue + " &EMP_ID=" + strEMP_ID + " &ID=" + str);
            }
            else if (ddlCentre.Visible == true && ddlSubcentre.Visible == true && ddlCluter.Visible == false)
            {
                Response.Redirect("BISENTRY.aspx?SubCentreID=" + ddlSubcentre.SelectedValue + " &CentreID=" + ddlCentre.SelectedValue + "&EMP_ID=" + strEMP_ID + " &ID=" + str);
            }
            else if (ddlSubcentre.Visible == true && ddlCluter.Visible == false && ddlCentre.Visible == false)
            {
                Response.Redirect("BISENTRY.aspx?SubCentreID=" + ddlSubcentre.SelectedValue + "&EMP_ID=" + strEMP_ID + " &ID=" + str);
            }
            else
            {
                Response.Redirect("BISENTRY.aspx?EMP_ID=" + strEMP_ID + " &ID=" + str);

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
        if (GV_EMP_VEIW.Rows.Count == 0)
        {
            btnSave.Visible = false;
            
        }
}
}
