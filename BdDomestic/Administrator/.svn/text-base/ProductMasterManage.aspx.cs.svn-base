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


public partial class Administrator_ProductMasterManage : System.Web.UI.Page
{
    OleDbConnection connection;
    string connString, strProductId;
    CProduct objProduct = new CProduct();
    protected void Page_Load(object sender, EventArgs e)
    {
        connString = ConfigurationManager.ConnectionStrings["CMConnectionString"].ToString();
        connection = new OleDbConnection(connString);

        if (Request.QueryString.Count != 0)
        {
            strProductId = Request.QueryString["NID"].ToString();
            if (!IsPostBack)
            {
                //Get data for edit
                string strSelectProduct = "Select Product_Code, Product_Name from Product_Master where Product_Id=?";
                OleDbConnection conn = new OleDbConnection(connString);

                OleDbCommand cmdProduct = new OleDbCommand(strSelectProduct, conn);
                OleDbParameter paramSelect = new OleDbParameter("@Product_Id", OleDbType.VarChar, 15);
                paramSelect.Value = strProductId;
                cmdProduct.Parameters.Add(paramSelect);
                conn.Open();
                OleDbDataReader Dr = cmdProduct.ExecuteReader();
                if (Dr.Read())
                {
                    txtProductCode.Text = Dr["Product_Code"].ToString();
                    txtProductName.Text = Dr["Product_Name"].ToString();
                }
                //end get data for edit

                //get data for tree structere
                
                DataSet dsGetTree = new DataSet();
                dsGetTree = objProduct.GetHierCeAc();
                //end get data for tree structure

                //build tree
                int nIterater = 0;
                TreeNode tnActivity, tnCentre;

                ArrayList alistExisting = new ArrayList();

                while (nIterater < dsGetTree.Tables[0].Rows.Count)
                {
                    if (strProductId == "0")//Enter new product
                    {
                        tnActivity = new TreeNode(dsGetTree.Tables[0].Rows[nIterater]["ACTIVITY_NAME"].ToString(), dsGetTree.Tables[0].Rows[nIterater]["ACTIVITY_ID"].ToString() + "," + dsGetTree.Tables[0].Rows[nIterater]["CENTRE_ID"].ToString());
                        tnCentre = new TreeNode(dsGetTree.Tables[0].Rows[nIterater]["CENTRE_NAME"].ToString());

                        tnCentre.ChildNodes.Add(tnActivity);

                        tvProduct.Nodes[0].ChildNodes.Add(tnCentre);
                    }
                    else//edit existing product. For this we need to get 
                    {
                        bool boolChk = objProduct.GetChech(dsGetTree.Tables[0].Rows[nIterater]["CENTRE_ID"].ToString(), strProductId, dsGetTree.Tables[0].Rows[nIterater]["ACTIVITY_ID"].ToString());
                        if (boolChk)
                            alistExisting.Add(dsGetTree.Tables[0].Rows[nIterater]["ACTIVITY_ID"].ToString() + "," + dsGetTree.Tables[0].Rows[nIterater]["CENTRE_ID"].ToString());
                        tnActivity = new TreeNode(dsGetTree.Tables[0].Rows[nIterater]["ACTIVITY_NAME"].ToString(), dsGetTree.Tables[0].Rows[nIterater]["ACTIVITY_ID"].ToString() + "," + dsGetTree.Tables[0].Rows[nIterater]["CENTRE_ID"].ToString());
                        tnActivity.Checked = boolChk;

                        tnCentre = new TreeNode(dsGetTree.Tables[0].Rows[nIterater]["CENTRE_NAME"].ToString());

                        tnCentre.ChildNodes.Add(tnActivity);

                        tvProduct.Nodes[0].ChildNodes.Add(tnCentre);
                    }
                    nIterater += 1;
                }
                if (strProductId != "0")
                    ViewState["tvOld"] = alistExisting;
                    //Session["alistExisting"] = alistExisting;
                //else
                    //Session.Remove("alistExisting");

                //end build tree

            }
        }
        else
            Response.Redirect("ProductMaster.aspx");
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            if (strProductId == "0")
            {
                //Insert new product.
                TreeNodeCollection checkedNodes = tvProduct.CheckedNodes;
                //String str = "";
                int counter = 0;
                ArrayList alistSelected = new ArrayList();
                while (counter < checkedNodes.Count)
                {
                    alistSelected.Add(checkedNodes[counter].Value);
                    //str = str + checkedNodes[counter].Value + ",";
                    counter += 1;
                }
                CProduct objProduct = new CProduct();
                objProduct.ProductCode = txtProductCode.Text;
                objProduct.ProductName = txtProductName.Text;

                objProduct.alist = alistSelected;
                //objProduct.SelectedActivities = str.TrimEnd(',');

                OleDbParameter ProductCode = new OleDbParameter("@ProductCode", OleDbType.VarChar, 10);
                ProductCode.Value = txtProductCode.Text.Trim();
                string sql1 = "select count(*) from product_master where PRODUCT_CODE=?";
                Object o = new object();
                o = OleDbHelper.ExecuteScalar(connection, CommandType.Text, sql1, ProductCode);
                if (Convert.ToInt32(o) == 0)
                {
                    objProduct.InsertProduct();
                    lblMsg.Visible = true;
                    lblMsg.Text = "product Insert Successfully";
                    Response.Redirect("ProductMaster.aspx?Massage=" + lblMsg.Text);
                }
                else
                {
                    lblMsg.Visible = true;
                    lblMsg.Text = "Product Code Should not be Duplicate";
                }
            }
            else
            {
                //Update product.
                ArrayList alistOld = (ArrayList)ViewState["tvOld"];

                ArrayList alistNew = new ArrayList();

                TreeNodeCollection checkedNodes = tvProduct.CheckedNodes;

                int counter = 0;
                while (counter < checkedNodes.Count)
                {
                    alistNew.Add(checkedNodes[counter].Value);
                    counter += 1;
                }

                CProduct objProduct = new CProduct();
                objProduct.ProductCode = txtProductCode.Text;
                objProduct.ProductName = txtProductName.Text;
                objProduct.Old = alistOld;
                objProduct.New = alistNew;

                //objProduct.SelectedActivities = str.TrimEnd(',');
                objProduct.EditProduct(Request.QueryString["NID"].ToString());
                
                lblMsg.Text =objProduct.Massage ;
                Response.Redirect("ProductMaster.aspx?Massage=" + lblMsg.Text);
            }
            
        }
        catch (Exception ex)
        {
            lblMsg.Text = ex.Message;
        }
        //lblMsg.Text = "Successfully saved changes.";
        //Response.Redirect("ProductMaster.aspx?msg=Successfully saved changes.");
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("ProductMaster.aspx");
    }
}
