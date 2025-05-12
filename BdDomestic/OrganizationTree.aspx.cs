using System;
using System.Data;
using System.Data.SqlClient;
using System.Data.OleDb;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class OrganizationTree : System.Web.UI.Page
{
    OleDbConnection connection;
    string connString;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session.Count==0)
            Response.Redirect("Default.aspx");

        string[] strRole = Session["RoleId"].ToString().Split(',');
        bool isAdmin = false;
        foreach (string str in strRole)
        {
            if (str == "1")
                isAdmin = true;
        }
        if (isAdmin)
            lnkAdmin.Visible = true;
        else
            lnkAdmin.Visible = false;

        connString = ConfigurationManager.ConnectionStrings["CMConnectionString"].ToString();
        connection = new OleDbConnection(connString);
        if (!IsPostBack)
        {
            /*
            string strSql = "SELECT DISTINCT c.CENTRE_ID, c.CENTRE_NAME, ch1.REF_ID AS activity_id, " +
                "ac.ACTIVITY_NAME, ch2.REF_ID AS product_id, pm.PRODUCT_NAME,  " +
                "ch3.REF_ID AS client_id, cm.CLIENT_NAME FROM COMPANY_HIERARCHY_MASTER ch  " +
                "INNER JOIN COMPANY_HIERARCHY_MASTER ch1 ON ch1.PARENT_ID = ch.HIER_ID AND ch1.TYPE = 'AC'  " +
                "INNER JOIN CENTRE_MASTER c ON ch.REF_ID = c.CENTRE_ID LEFT OUTER JOIN " +
                "COMPANY_HIERARCHY_MASTER ch2 ON ch2.PARENT_ID = ch1.HIER_ID LEFT OUTER JOIN " +
                "PRODUCT_MASTER pm ON ch2.REF_ID = pm.PRODUCT_ID LEFT OUTER JOIN " +
                "ACTIVITY_MASTER ac ON ch1.REF_ID = ac.ACTIVITY_ID LEFT OUTER JOIN " +
                "COMPANY_HIERARCHY_MASTER ch3 ON ch3.PARENT_ID = ch2.HIER_ID LEFT OUTER JOIN " +
                "CLIENT_MASTER cm ON ch3.REF_ID = cm.CLIENT_ID AND ch3.TYPE = 'CT' AND ch2.TYPE = 'PR'where  " +
                "(ch.HIER_ID in (Select Hier_Id from USER_HIERARCHY where user_Id = '" + Session["UserId"].ToString() + "') or  " +
                "ch1.HIER_ID in (Select Hier_Id from USER_HIERARCHY where user_Id = '" + Session["UserId"].ToString() + "') or " +
                "ch2.HIER_ID in (Select Hier_Id from USER_HIERARCHY where user_Id = '" + Session["UserId"].ToString() + "') or " +
                "ch3.HIER_ID in (Select Hier_Id from USER_HIERARCHY where user_Id = '" + Session["UserId"].ToString() + "'))" +
                " and c.CENTRE_ID ='" + Session["CentreId"].ToString() + "'";
            string strCentres, strActivities, strProducts, strClients;
            strCentres = "";
            strActivities = "";
            strProducts = "";
            strClients = "";
            OleDbDataReader odr = OleDbHelper.ExecuteReader(connString, CommandType.Text, strSql);
            while (odr.Read())
            {
                strCentres = strCentres + odr["CENTRE_ID"].ToString() + ",";
                strActivities = strActivities + odr["activity_id"].ToString() + ",";
                strProducts = strProducts + odr["product_id"].ToString() + ",";
                strClients = strClients + odr["client_id"].ToString() + ",";
            }
            */

            string strSelectedHier = "(CHier in (Select Hier_Id from USER_HIERARCHY where user_Id = '" + Session["UserId"].ToString() + "') or  " +
                                     "AHier in (Select Hier_Id from USER_HIERARCHY where user_Id = '" + Session["UserId"].ToString() + "') or " +
                                     "PHier in (Select Hier_Id from USER_HIERARCHY where user_Id = '" + Session["UserId"].ToString() + "') or " +
                                     "CtHier in (Select Hier_Id from USER_HIERARCHY where user_Id = '" + Session["UserId"].ToString() + "'))";
            //get dataset for organization tree
            //string chkHierLevel = "Select 
            Session["ActivityId"] = "";
            Session["ProductId"] = "";
            Session["ClientId"] = "";
            string strCentre = "";
            //if (Convert.ToInt16(Session["HierLevel"]) < 3 )
            //    strCentre = "Select Distinct Centre_Id, Centre_Name from ce_ac_pr_ct_vw " +
            //                "where Client_Id is not null";
            //else
            strCentre = "select Distinct Centre_Id, Centre_Name from HierCeToCtView where centre_ID='" +
                            Session["CentreId"] + "'" + " and " + strSelectedHier + " order by Centre_Name";

            OleDbDataReader drCentre = OleDbHelper.ExecuteReader(connString, CommandType.Text, strCentre);

            TreeNode tnClient, tnProduct, tnActivity, tnCentre;

            while (drCentre.Read())
            {
                tnCentre = new TreeNode(drCentre["Centre_Name"].ToString());
                tnCentre.SelectAction = TreeNodeSelectAction.Expand;
                
                tvOrganization.Nodes.Add(tnCentre);

                string strActivity = "select Distinct Activity_Id, Activity_Name from HierCeToCtView where " +
                                 " Centre_Id = ? and " + strSelectedHier + " order by Activity_Name";

                OleDbParameter paramActivity = new OleDbParameter("CentreId", OleDbType.VarChar);
                paramActivity.Value = drCentre["Centre_Id"].ToString();

                OleDbDataReader drActivity = OleDbHelper.ExecuteReader(connection, CommandType.Text, strActivity, paramActivity);

                while (drActivity.Read())
                {

                    tnActivity = new TreeNode(drActivity["Activity_Name"].ToString());
                    tnActivity.SelectAction = TreeNodeSelectAction.Expand;
                    tnCentre.ChildNodes.Add(tnActivity);

                    string strProduct = "select Distinct Product_Id, Product_name from HierCeToCtView where " +
                                        " Centre_Id = ? and Activity_Id=? and " + strSelectedHier + 
                                        " order by Product_Name";

                    OleDbParameter[] paramProduct = new OleDbParameter[2];
                    paramProduct[0] = new OleDbParameter("CentreId", OleDbType.VarChar);
                    paramProduct[0].Value = drCentre["Centre_Id"].ToString();
                    paramProduct[1] = new OleDbParameter("ActivityId", OleDbType.VarChar);
                    paramProduct[1].Value = drActivity["Activity_Id"].ToString();
                    string strY="";
                    OleDbDataReader drProduct = OleDbHelper.ExecuteReader(connection, CommandType.Text, strProduct, paramProduct);
                    while (drProduct.Read())
                    {

                        tnProduct = new TreeNode(drProduct["Product_Name"].ToString());
                        //tnProduct.SelectAction = TreeNodeSelectAction.Expand;
                        
                        tnActivity.ChildNodes.Add(tnProduct);

                        string strClient = "select Distinct Client_Id, Client_Name from HierCeToCtView where " +
                                            " Centre_Id = ? and Activity_Id=? and Product_Id=?" +
                                            " and " + strSelectedHier + " order by Client_Name";

                        OleDbParameter[] paramClient = new OleDbParameter[3];
                        paramClient[0] = new OleDbParameter("CentreId", OleDbType.VarChar);
                        paramClient[0].Value = drCentre["Centre_Id"].ToString();
                        paramClient[1] = new OleDbParameter("ActivityId", OleDbType.VarChar);
                        paramClient[1].Value = drActivity["Activity_Id"].ToString();
                        paramClient[2] = new OleDbParameter("ProductId", OleDbType.VarChar);
                        paramClient[2].Value = drProduct["Product_Id"].ToString();

                        OleDbDataReader drClient = OleDbHelper.ExecuteReader(connection, CommandType.Text, strClient, paramClient);
                        while (drClient.Read())
                        {
                            //Code added by manoj 02-07-2007 to check if Client Name is not exist
                            if (drClient["Client_Name"].ToString().Trim() != "")
                            {
                            //Code .....//
                                tnClient = new TreeNode(drClient["Client_Name"].ToString());
                                //tnClient.NavigateUrl = drActivity["Activity_Name"].ToString() + "/" +
                                //                      drProduct["Product_Name"].ToString() + "/Default.aspx";
                                tnClient.Value = drActivity["Activity_Id"].ToString() + "," +
                                                 drProduct["Product_Id"].ToString() + "," +
                                                 drClient["Client_Id"].ToString() + "," +
                                                 drActivity["Activity_Name"].ToString() + "/" +
                                                 drProduct["Product_Name"].ToString();
                                tnProduct.ChildNodes.Add(tnClient);
                                strY = "";

                            //Code .....//
                            }
                            else
                            {
                                //If client name is empty that time it sets the strY flag as "Y"
                                strY = "Y";
                            }
                        }
                        drClient.Close();
                        if (strY != "Y")
                        {
                            //If strY flag has "Y" value that means it has clients for that it will create child node
                            tnProduct.SelectAction = TreeNodeSelectAction.Expand;
                            
                        }
                        else
                        {
                            //It is assing the value for session and creating the file path
                            tnProduct.SelectAction = TreeNodeSelectAction.Select;
                            tnProduct.Value=drActivity["Activity_Id"].ToString() + "," +
                                            drProduct["Product_Id"].ToString() + ", ," +
                                            drActivity["Activity_Name"].ToString() + "/" +
                                            drProduct["Product_Name"].ToString();
                            strY="";
                        }
                        //code End By Manoj
                    }
                    drProduct.Close();
                }
                drActivity.Close();
            }
            drCentre.Close();

            //added by hemangi kambli on 26-Nov-2007 ----------------------------
            //Check whether user has rights for Negative dedup search...(admin or Dedup supervisor)
            //added by sandeep khare on 30-Nov-2007 ----------------------------
            //Check whether user has rights for Negative dedup ...(admin or Dedup supervisor)and FE-Tracking search....(admin or FE-Coordinator)
            string[] sRoleId = Session["RoleId"].ToString().Split(',');
            foreach (string str in sRoleId)
            {
                // condition for Negative Dedup Search.
                if (str == "20" || str == "1")
                {
                    lnkDedupSearch.Visible = true;
                }
                else
                {
                    lnkDedupSearch.Visible = false;
                }

                //---------------------------------------------------------------------
                // codition for FE-Tracking       
                if (str == "21" || str == "1")
                {
                    lnkFETracking.Visible = true;
                }
                else
                {
                    lnkFETracking.Visible = false;
                }
            }
            
        } 
    }
    protected void tvOrganization_SelectedNodeChanged(object sender, EventArgs e)
    {
        string[] strParameter = ((TreeView)sender).SelectedValue.Split(',');
        Session["ActivityId"]=strParameter[0];
        Session["ProductId"]=strParameter[1];
        Session["ClientId"]=strParameter[2];
        Response.Redirect(strParameter[3]);
    }
}
