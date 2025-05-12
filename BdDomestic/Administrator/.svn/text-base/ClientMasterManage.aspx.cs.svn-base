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

public partial class Administrator_ClientMasterManage : System.Web.UI.Page
{
    OleDbConnection connection;
    string connString, strClientId;

    protected void Page_Load(object sender, EventArgs e)
    {
        connString = ConfigurationManager.ConnectionStrings["CMConnectionString"].ToString();
        connection = new OleDbConnection(connString);
        if (Request.QueryString.Count != 0)
        {
            strClientId = Request.QueryString["NID"].ToString();
            if (!IsPostBack)
            {
                string strSelectClient = "Select Client_Code, Client_Name from Client_Master where Client_Id=?";
                OleDbConnection conn = new OleDbConnection(connString);

                OleDbCommand cmdClient = new OleDbCommand(strSelectClient, conn);
                OleDbParameter paramSelect = new OleDbParameter("@Client_Id", OleDbType.VarChar, 15);
                paramSelect.Value = strClientId;
                cmdClient.Parameters.Add(paramSelect);
                conn.Open();
                OleDbDataReader Dr = cmdClient.ExecuteReader();
                if (Dr.Read())
                {
                    txtClientCode.Text = Dr["Client_Code"].ToString();
                    txtClientName.Text = Dr["Client_Name"].ToString();
                }

                //get data for tree structere
                CClient objClient = new CClient();
                DataSet dsGetTree = new DataSet();
                dsGetTree = objClient.GetHierCeAcPr();
                //end get data for tree structure

                //build tree
                int nIterater = 0;
                TreeNode tnProduct, tnActivity, tnCentre;

                ArrayList alistExisting = new ArrayList();

                while (nIterater < dsGetTree.Tables[0].Rows.Count)
                {
                    if (strClientId == "0")//Enter new Client
                    {
                        tnProduct = new TreeNode(dsGetTree.Tables[0].Rows[nIterater]["PRODUCT_NAME"].ToString(), dsGetTree.Tables[0].Rows[nIterater]["PRODUCT_ID"].ToString() + "," + dsGetTree.Tables[0].Rows[nIterater]["ACTIVITY_ID"].ToString() + "," + dsGetTree.Tables[0].Rows[nIterater]["CENTRE_ID"].ToString());
                        tnActivity = new TreeNode(dsGetTree.Tables[0].Rows[nIterater]["ACTIVITY_NAME"].ToString());
                        tnCentre = new TreeNode(dsGetTree.Tables[0].Rows[nIterater]["CENTRE_NAME"].ToString());

                        tnActivity.ChildNodes.Add(tnProduct);
                        tnCentre.ChildNodes.Add(tnActivity);

                        tvClient.Nodes[0].ChildNodes.Add(tnCentre);
                    }
                    else//edit existing client. For this we need to get 
                    {

                        bool boolChk = objClient.GetChech(dsGetTree.Tables[0].Rows[nIterater]["CENTRE_ID"].ToString(), dsGetTree.Tables[0].Rows[nIterater]["Product_ID"].ToString(), dsGetTree.Tables[0].Rows[nIterater]["ACTIVITY_ID"].ToString(), strClientId);
                        if (boolChk)
                            alistExisting.Add(dsGetTree.Tables[0].Rows[nIterater]["PRODUCT_ID"].ToString() + "," + dsGetTree.Tables[0].Rows[nIterater]["ACTIVITY_ID"].ToString() + "," + dsGetTree.Tables[0].Rows[nIterater]["CENTRE_ID"].ToString());

                        tnProduct = new TreeNode(dsGetTree.Tables[0].Rows[nIterater]["PRODUCT_NAME"].ToString(), dsGetTree.Tables[0].Rows[nIterater]["PRODUCT_ID"].ToString() + "," + dsGetTree.Tables[0].Rows[nIterater]["ACTIVITY_ID"].ToString() + "," + dsGetTree.Tables[0].Rows[nIterater]["CENTRE_ID"].ToString());
                        tnActivity = new TreeNode(dsGetTree.Tables[0].Rows[nIterater]["ACTIVITY_NAME"].ToString());
                        tnCentre = new TreeNode(dsGetTree.Tables[0].Rows[nIterater]["CENTRE_NAME"].ToString());

                        tnProduct.Checked = boolChk;

                        tnActivity.ChildNodes.Add(tnProduct);
                        tnCentre.ChildNodes.Add(tnActivity);

                        tvClient.Nodes[0].ChildNodes.Add(tnCentre);
                        
                    }

                    nIterater += 1;
                }
                if (strClientId != "0")
                    ViewState["tvOld"] = alistExisting;

                //end build tree


            }
        }
        else
            Response.Redirect("ClientMaster.aspx");
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            if (strClientId == "0")
            {
                //Insert new Client.
                TreeNodeCollection checkedNodes = tvClient.CheckedNodes;
                //String str = "";
                int counter = 0;
                ArrayList alistSelected = new ArrayList();
                while (counter < checkedNodes.Count)
                {
                    alistSelected.Add(checkedNodes[counter].Value);
                    //str = str + checkedNodes[counter].Value + ",";
                    counter += 1;
                }

                CClient objClient = new CClient();
                objClient.ClientCode = txtClientCode.Text;
                objClient.ClientName = txtClientName.Text;

                objClient.alist = alistSelected;

                //chech if client code exist
                OleDbParameter ClientCode = new OleDbParameter("@ProductCode", OleDbType.VarChar, 10);
                ClientCode.Value = txtClientCode.Text.Trim();
                string sql1 = "select count(*) from client_master where Client_CODE=?";
                Object o = new object();
                o = OleDbHelper.ExecuteScalar(connection, CommandType.Text, sql1, ClientCode);
                if (Convert.ToInt32(o) == 0)
                {
                    //insert client. no duplicat
                    objClient.InsertClient();
                    lblMsg.Visible = true;
                    lblMsg.Text = "Client Insert Successfully";
                    Response.Redirect("ClientMaster.aspx?Massage ="+lblMsg.Text);
                }
                else
                {
                    //duplicate client code
                    lblMsg.Visible = true;
                    lblMsg.Text = "Client Code Should not be Duplicate";
                }
            }
            else
            {
                //Update product.
                ArrayList alistOld = (ArrayList)ViewState["tvOld"];

                ArrayList alistNew = new ArrayList();

                TreeNodeCollection checkedNodes = tvClient.CheckedNodes;
                String str = "";
                int counter = 0;
                while (counter < checkedNodes.Count)
                {
                    alistNew.Add(checkedNodes[counter].Value);
                    counter += 1;
                }
                CClient objClient = new CClient();
                objClient.ClientCode = txtClientCode.Text;
                objClient.ClientName = txtClientName.Text;

                objClient.Old = alistOld;
                objClient.New = alistNew;

                objClient.EditClient(Request.QueryString["NID"].ToString());
                lblMsg.Text = objClient.Massage;
                Response.Redirect("ClientMaster.aspx?Massage=" + lblMsg.Text);
            }

        }
        catch (Exception ex)
        {
            lblMsg.Text = ex.Message;
        }
    }


    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("ClientMaster.aspx");
    }
   
}

