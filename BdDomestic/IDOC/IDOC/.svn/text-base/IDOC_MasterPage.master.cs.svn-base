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

public partial class IDOC_MasterPage : System.Web.UI.MasterPage
{
    protected void Page_Init(object sender, EventArgs e)
    {
        if (Session.Count == 0)
            Response.Redirect("../../Default.aspx?Message='Session expires. Please login again.'");

        CMaster objMaster = new CMaster();
        if (Request.QueryString.Count != 0)
        {
            if (Request.QueryString["OperationId"] != null)
            {
                Session["OperationId"] = Request.QueryString["OperationId"];
                ArrayList aListPermission = objMaster.GetOperationPermission(Session["OperationId"].ToString(), Session["RoleId"].ToString());
                Session["isAdd"] = aListPermission[0].ToString();
                Session["isEdit"] = aListPermission[1].ToString();
                Session["isDelete"] = aListPermission[2].ToString();
                Session["isView"] = aListPermission[3].ToString();
                aListPermission.Clear();
            }
        }
        else
        {
            if (Session["OperationId"] != null && Session["RoleId"] != null)
            {
                ArrayList aListPermission = objMaster.GetOperationPermission(Session["OperationId"].ToString(), Session["RoleId"].ToString());
                Session["isAdd"] = aListPermission[0].ToString();
                Session["isEdit"] = aListPermission[1].ToString();
                Session["isDelete"] = aListPermission[2].ToString();
                Session["isView"] = aListPermission[3].ToString();
            }
            /*
            Session["isAdd"] = "0";
            Session["isEdit"] = "0";
            Session["isDelete"] = "0";
            Session["isView"] = "0";
             * */
        }
        CLogin objLogin = new CLogin();
        objLogin.UpdateLogoutTime();
    }
    OleDbConnection connection;
    string connString;


    protected void Page_Load(object sender, EventArgs e)
    {
        Response.AddHeader("Pragma", "no-cache");
        if (Session.Count == 0)
            Response.Redirect("Login.aspx");
        else
        {
            CMaster objMaster = new CMaster();
            /*
            if (Request.QueryString["OperationId"] != null)
            {
                Session["OperationId"] = Request.QueryString["OperationId"];
                ArrayList aListPermission = objMaster.GetOperationPermission(Session["OperationId"].ToString(), Session["RoleId"].ToString());
                Session["isAdd"] = aListPermission[0].ToString();
                Session["isEdit"] = aListPermission[1].ToString();
                Session["isDelete"] = aListPermission[2].ToString();
                Session["isView"] = aListPermission[3].ToString();
                aListPermission.Clear();
            }
            */
            objMaster.RoleId = Session["RoleId"].ToString();
            objMaster.UserId = Session["UserId"].ToString();
            objMaster.GetMenu(Session["ProductId"].ToString());
            //objMaster.UserNameLocation();
            //lblUserName.Text = Session["FLName"].ToString(); ;//objMaster.UserName;
            //lblLocation.Text = Session["CId"].ToString();//objMaster.Location;
            //lblDate.Text = System.DateTime.Now.ToString("MMMM dd, yyyy hh:mm:tt");
            if (Menu1.Items.Count == 0)
            {
                objMaster.GetMenu(Session["ProductId"].ToString());
                ArrayList alistMenu = objMaster.Operations;
                ArrayList alistMenyItem;

                string stOperId, strMnuName, strMnuHeader, strUrl, strVisibility, strAccess, strDisplayOrder;
                int iItemCount = 0;
                foreach (Object obj in alistMenu)
                {
                    alistMenyItem = (ArrayList)obj;
                    stOperId = alistMenyItem[0].ToString();
                    strMnuName = alistMenyItem[1].ToString();
                    strMnuHeader = alistMenyItem[2].ToString();
                    strUrl = alistMenyItem[3].ToString();
                    if (strUrl == "")
                        strUrl = "javascript:alert('Under Construction')";
                    strVisibility = alistMenyItem[4].ToString();
                    strAccess = alistMenyItem[5].ToString();
                    strDisplayOrder = alistMenyItem[6].ToString();
                    if (strDisplayOrder == "0")
                    {
                        Menu1.Items.Add(new MenuItem(strMnuName, strMnuName));
                        iItemCount++;
                    }
                    else
                    {
                        if (strVisibility == "y")
                        {
                            MenuItem mnMenuItem = new MenuItem(strMnuName, strMnuName, "", strUrl);
                            if (strAccess == "1")
                            {
                                mnMenuItem.Enabled = true;
                            }
                            else
                            {
                                mnMenuItem.Enabled = false;
                            }
                            Menu1.Items[iItemCount - 1].ChildItems.Add(mnMenuItem);
                        }
                        else
                        {
                            if (strAccess == "1")
                            {
                                MenuItem mnMenuItem = new MenuItem(strMnuName, strMnuName, "", strUrl);
                                Menu1.Items[iItemCount - 1].ChildItems.Add(mnMenuItem);
                            }
                        }
                    }

                }
            }


            if (!IsPostBack)
            {
                try
                {
                    if (Session["CentreId"] != null && Session["ActivityId"] != null && Session["ProductId"] != null && Session["ClientId"] != null)
                    {
                        if (Session["CentreId"].ToString() != "" && Session["ActivityId"].ToString() != "" && Session["ProductId"].ToString() != "" && Session["ClientId"].ToString() != "")
                        {
                            connString = ConfigurationManager.ConnectionStrings["CMConnectionString"].ToString();
                            connection = new OleDbConnection(connString);
                            string strHeirarchy = "SELECT DISTINCT CENTRE_NAME, ACTIVITY_NAME, PRODUCT_NAME, CLIENT_NAME FROM CE_AC_PR_CT_VW WHERE " +
                                                        "CENTRE_ID = ? AND ACTIVITY_ID=? AND PRODUCT_ID=? AND CLIENT_ID=?";

                            OleDbParameter[] paramHeirarchy = new OleDbParameter[4];
                            paramHeirarchy[0] = new OleDbParameter("CENTRE_ID", OleDbType.VarChar);
                            paramHeirarchy[0].Value = Session["CentreId"].ToString();
                            paramHeirarchy[1] = new OleDbParameter("ACTIVITY_ID", OleDbType.VarChar);
                            paramHeirarchy[1].Value = Session["ActivityId"].ToString();
                            paramHeirarchy[2] = new OleDbParameter("PRODUCT_ID", OleDbType.VarChar);
                            paramHeirarchy[2].Value = Session["ProductId"].ToString();
                            paramHeirarchy[3] = new OleDbParameter("CLIENT_ID", OleDbType.VarChar);
                            paramHeirarchy[3].Value = Session["ClientId"].ToString();

                            OleDbDataReader drHeirarchy = OleDbHelper.ExecuteReader(connection, CommandType.Text, strHeirarchy, paramHeirarchy);
                            if (drHeirarchy.Read())
                            {
                                lblHierarchy.Text = drHeirarchy["ACTIVITY_NAME"].ToString() + " - " +
                                                    drHeirarchy["PRODUCT_NAME"].ToString() + " - " +
                                                    drHeirarchy["CLIENT_NAME"].ToString() + " - " +
                                                    drHeirarchy["CENTRE_NAME"].ToString();
                            }
                            drHeirarchy.Close();
                            if (Session["FLName"] != null)
                            {
                                if (Session["FLName"].ToString() != "")
                                {
                                    lblName.Text = Session["FLName"].ToString();
                                }
                            }
                        }
                    }
                }
                catch (Exception exp)
                {
                }
            }
        }
    }
}
