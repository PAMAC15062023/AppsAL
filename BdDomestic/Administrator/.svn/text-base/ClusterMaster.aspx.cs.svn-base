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

public partial class Administrator_ClusterMaster : System.Web.UI.Page
{
    CCommon con = new CCommon();
    private string strSelected;
    string strallreadyunchecked = "";
    string strAllreadyChecked = "";
    HiddenField hidRefiD;
    CheckBox chkCentreId;
  
    protected void Page_Load(object sender, EventArgs e)
    {
        CCClusterMaster objCM = new CCClusterMaster();
        string strClusterID = "";
        try
        {

            
            lblMsg.Text = "";



            if (Request.QueryString["Cluster_Id"] != null && Request.QueryString["Cluster_Id"] != "")
            {
                lblMsg.Text = "Edit";




                if (!IsPostBack)
                {
                    strClusterID = Request.QueryString["Cluster_Id"].ToString();


                    sdsClustermaster.SelectCommand = "select  distinct cm.company_Id, cm.company_Name, " +
                                                     "cv.company_Id as keycolumn from company_master CM left join " +
                                                     "Cluater_view cv on cm.company_Id = cv.company_Id and " +
                                                     "cv.cluster_Id = '" + strClusterID + "' ";

                    objCM.ClusterID = Request.QueryString["Cluster_ID"].ToString();
                    HiddenField1.Value = strClusterID;
                    objCM.GetCluster();
                    gvCompany.DataBind();

                    txtClusterName.Text = objCM.ClusterName;

                    txtClusterCode.Enabled = false;
                    valClusterCode.Enabled = false;

                    foreach (GridViewRow row in gvCompany.Rows)
                    {
                        hidRefiD = (HiddenField)row.FindControl("HiddenCompanyID");
                        chkCentreId = (CheckBox)row.FindControl("chkHierId");
                        if (!chkCentreId.Checked)
                        {
                            strallreadyunchecked = strallreadyunchecked + hidRefiD.Value + ',';
                        }
                        else
                        {
                            strAllreadyChecked = strAllreadyChecked + hidRefiD.Value + ',';
                        }
                    }
                    hidAllreadunchecked.Value = strallreadyunchecked;
                    hidAllreadychecked.Value = strAllreadyChecked;


                }
            }


        }
        catch (Exception exp)
        {
            lblMsg.Text = "Error";
        }


        sdsClustermaster.SelectCommand = "select  distinct cm.company_Id, cm.company_Name, " +
                                         "cv.company_Id as keycolumn from company_master CM left join " +
                                         "Cluater_view cv on cm.company_Id = cv.company_Id and " +
                                         "cv.cluster_Id ='" + strClusterID + "' ";
        //gvCompany.DataBind();

    }

    protected void btnsave_Click(object sender, EventArgs e)
    {
        bool chkbox = true;
        CCClusterMaster objCM = new CCClusterMaster();
        string strKeyColumn = "";
        string strSelectecompanyID = "";
        HiddenField hidkeycolumn;
        
       
        string strRefid = "";
        string strunselectedCompanyID = "";
        if (Request.QueryString["Cluster_Id"] != null && Request.QueryString["Cluster_Id"] != "")
        {
            objCM.ClusterID = Request.QueryString["Cluster_ID"].ToString();
            foreach (GridViewRow row in gvCompany.Rows)
            {

                hidkeycolumn = (HiddenField)row.FindControl("hidHierId");
                chkCentreId = (CheckBox)row.FindControl("chkHierID"); 
                hidRefiD = (HiddenField)row.FindControl("HiddenCompanyID");

                if (chkCentreId.Checked)
                {
                    strSelectecompanyID = strSelectecompanyID + hidRefiD.Value + ",";

                    strKeyColumn = strKeyColumn + hidkeycolumn.Value + ",";

                   
                    if (hidkeycolumn.Value == "")
                    {
                        strRefid = strRefid + hidRefiD.Value + ",";


                    }

                }
                else
                {
                    strunselectedCompanyID = strunselectedCompanyID + hidRefiD.Value + ",";

                    strRefid = strRefid + hidRefiD.Value + ",";

                }



            }



            
            string[] unselected = strunselectedCompanyID.Split(',');
            string[] Allreadyunchecked = hidAllreadunchecked.Value.Split(',');
            string strforDelete = "";
            ViewState["str1"] = "";
            foreach (string str in unselected)
            {
                if (str != "")
                {

                    foreach (string str1 in Allreadyunchecked)
                    {
                        ViewState["str1"] = str1;
                        if (str1 != "")
                        {
                            if (str == str1)
                            {
                                break;
                            }



                        }
                    }
                    if (ViewState["str1"].ToString() != str)
                        strforDelete = strforDelete + str + ',';
                }


            }

            string[] selectedcentreID = strSelectecompanyID.Split(',');

            string[] AllreadyChecked = hidAllreadychecked.Value.Split(',');
            string strforchange = "";
            ViewState["str2"] = "";

            foreach (string str in selectedcentreID)
            {
                if (str != "")
                {

                    foreach (string str1 in AllreadyChecked)
                    {
                        ViewState["str2"] = str1;
                        if (str1 != "")
                        {
                            if (str == str1)
                            {
                                break;
                            }



                        }
                    }
                    if (ViewState["str2"].ToString() != str)
                        strforchange = strforchange + str + ',';
                }


            }

            try
            {



                if (strforchange != "")
                {
                    objCM.changeCluster(strforchange);
                    lblMsg.Visible = true;

                   
                }

                if (strunselectedCompanyID != "")
                {
                    objCM.DeletCluster(strforDelete);

                    
                }


            }
            catch (Exception ex)
            {

            }
            objCM.ClusterID = HiddenField1.Value;
            objCM.ClusterName = txtClusterName.Text;
         
             objCM.UpdateCluster();
           
             lblMsg.Visible = true;
             lblMsg.Text = "Cluster Updated Succesfully";
             Session["msg1"] = lblMsg.Text;
             Response.Redirect("ClusterViewMaster.aspx");
        }
        else
        {
            objCM.ClusterName = txtClusterName.Text.Trim();

            objCM.SelectedID = getSelected();
            foreach (GridViewRow gvRow in gvCompany.Rows)
            {
                //lblMsg.Text = "ERROR";
              
                if (((CheckBox)gvRow.FindControl("chkHierId")).Checked == true)
                {
                    //lblMsg.Text = "";
                    chkbox = false;
                    break;

                }
                if (chkbox)
                {
                    lblMsg.Visible = true;
                    lblMsg.Text = "Please Select Rows ";

                }
            }
            if (!chkbox)
            {
                lblMsg.Visible = true;

               objCM.insertClustermaster();
               
                lblMsg.Text = "Cluster Added Successfully ";
                //}
                Session["msg1"] = lblMsg.Text;
                Response.Redirect("ClusterViewMaster.aspx");

            }
        }
      
        txtClusterName.Text = "";
        txtClusterCode.Text = "";
       
     
       
        

    }
    private string getSelected()
    {
        strSelected = "";
      
        CheckBox chk;
        HiddenField hid;
        foreach (GridViewRow gvRow in gvCompany.Rows)
        {
            chk = (CheckBox)gvRow.FindControl("chkHierId");
            
            hid = (HiddenField)gvRow.FindControl("hidHierId");
            if (chk.Checked == true)
            {
                strSelected = strSelected + hid.Value + ",";
            }
           
        }
        return strSelected;
    }
    protected void btncalcel_Click(object sender, EventArgs e)
    {
        txtClusterName.Text = "";
        txtClusterCode.Text = "";
       
        lblMsg.Text = "";
        txtClusterCode.Enabled = true;
        valClusterCode.Enabled = true;
        foreach (GridViewRow gvRow in gvCompany.Rows)
        {
            ((CheckBox)gvRow.FindControl("chkHierId")).Checked = false;
        }

        Session["msg1"] = null;
        Response.Redirect("ClusterViewMaster.aspx");
    }
   
    
   
    protected void gvCompany_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (Request.QueryString["CLUSTER_ID"] != null && Request.QueryString["CLUSTER_ID"] != "")
        {

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                HiddenField hf = (HiddenField)e.Row.FindControl("hidHierId");
                if (hf.Value != "")
                {
                    CheckBox chk = (CheckBox)e.Row.FindControl("chkHierId");
                    chk.Checked = true;
                }
            }
        }
    }

    protected void gvCompany_DataBound1(object sender, EventArgs e)
    {
        CheckBox cbHeader = ((CheckBox)(gvCompany.HeaderRow.FindControl("HeaderLevelCheckBox")));
        cbHeader.Attributes["onclick"] = "ChangeAllCheckBoxStates(this.checked);";
        foreach (GridViewRow gvr in gvCompany.Rows)
        {
            // Get a programmatic reference to the CheckBox control
            CheckBox cb = ((CheckBox)(gvr.FindControl("chkHierID")));
            ClientScript.RegisterArrayDeclaration("CheckBoxIDs", string.Concat("\'", cb.ClientID, "\'"));
        }
    }
}
