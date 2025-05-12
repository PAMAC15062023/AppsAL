using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using YesBank;

namespace CoreDailyMISAutomation
{
    public partial class CDMA_RateMaster : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindSubVertical();
                BindClientName();
                BindActivity();
                BindProduct();
                BindSubProduct();
                BindStatus();
                BindCoreStaffing();
                BindCentralLocalActivity();
                BindBillingProcess();
                BindPenaltyClause();
                BindMGV();
                BindICLOCL();
                BindBillingMode();
                BindClientCRM();
                pnlRadioButton.Visible = true;
                PnlInsertRateMaster.Visible = true;
                pnlRateMasterGrid.Visible = false;
                pnlDownloadRateMaster.Visible = false;
                btnUpdate.Visible = false;
            }
        }

        protected void BindSubVertical()
        {
            try
            {
                SqlConnection sqlCon = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);

                SqlCommand sqlCom = new SqlCommand();
                sqlCom.Connection = sqlCon;
                sqlCom.CommandType = CommandType.StoredProcedure;
                sqlCom.CommandText = "CDMA_BindSubVertical";
                sqlCom.CommandTimeout = 0;

                SqlDataAdapter da = new SqlDataAdapter(sqlCom);
                DataSet ds = new DataSet();
                da.Fill(ds);

                if (ds != null && ds.Tables.Count > 0)
                {
                    ddlSubVertical.DataTextField = "SubVertical";
                    ddlSubVertical.DataValueField = "ID";
                    ddlSubVertical.DataSource = ds.Tables[0];
                    ddlSubVertical.DataBind();

                    ddlSubVertical.Items.Insert(0, "--Select--");
                    ddlSubVertical.SelectedIndex = 0;

                    ddlSubVerticalEdit.DataTextField = "SubVertical";
                    ddlSubVerticalEdit.DataValueField = "ID";
                    ddlSubVerticalEdit.DataSource = ds.Tables[0];
                    ddlSubVerticalEdit.DataBind();

                    ddlSubVerticalEdit.Items.Insert(0, "--Select--");
                    ddlSubVerticalEdit.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {

            }
        }

        protected void ddlSubVertical_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection sqlCon = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);

            SqlCommand sqlCom = new SqlCommand();
            sqlCom.Connection = sqlCon;
            sqlCom.CommandType = CommandType.StoredProcedure;
            sqlCom.CommandText = "CDMA_OnIndexChangeOfSubVertical_SP";
            sqlCom.CommandTimeout = 0;

            SqlParameter SubVertical = new SqlParameter();
            SubVertical.SqlDbType = SqlDbType.VarChar;
            SubVertical.Value = ddlSubVertical.SelectedValue;
            SubVertical.ParameterName = "@SubVerticalID";
            sqlCom.Parameters.Add(SubVertical);

            sqlCon.Open();

            SqlDataAdapter da = new SqlDataAdapter(sqlCom);
            DataSet ds = new DataSet();
            da.Fill(ds);

            sqlCon.Close();

            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                ddlClientName.DataTextField = "ClientName";
                ddlClientName.DataValueField = "ID";
                ddlClientName.DataSource = ds.Tables[0];
                ddlClientName.DataBind();

                ddlClientName.Items.Insert(0, "--Select--");
                ddlClientName.SelectedIndex = 0;

            }
            else
            {
                ddlClientName.Items.Clear();
            }
        }

        protected void ddlSubVerticalEdit_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection sqlCon = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);

            SqlCommand sqlCom = new SqlCommand();
            sqlCom.Connection = sqlCon;
            sqlCom.CommandType = CommandType.StoredProcedure;
            sqlCom.CommandText = "CDMA_OnIndexChangeOfSubVertical_SP";
            sqlCom.CommandTimeout = 0;

            SqlParameter SubVertical = new SqlParameter();
            SubVertical.SqlDbType = SqlDbType.VarChar;
            SubVertical.Value = ddlSubVerticalEdit.SelectedValue;
            SubVertical.ParameterName = "@SubVerticalID";
            sqlCom.Parameters.Add(SubVertical);

            sqlCon.Open();

            SqlDataAdapter da = new SqlDataAdapter(sqlCom);
            DataSet ds = new DataSet();
            da.Fill(ds);

            sqlCon.Close();

            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {

                ddlClientNameEdit.DataTextField = "ClientName";
                ddlClientNameEdit.DataValueField = "ID";
                ddlClientNameEdit.DataSource = ds.Tables[0];
                ddlClientNameEdit.DataBind();

                ddlClientNameEdit.Items.Insert(0, "--Select--");
                ddlClientNameEdit.SelectedIndex = 0;
            }
            else
            {
                ddlClientNameEdit.Items.Clear();
            }
        }
        protected void BindClientName()
        {
            try
            {
                SqlConnection sqlCon = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);

                SqlCommand sqlCom = new SqlCommand();
                sqlCom.Connection = sqlCon;
                sqlCom.CommandType = CommandType.StoredProcedure;
                sqlCom.CommandText = "CDMA_BindClientName";
                sqlCom.CommandTimeout = 0;

                SqlDataAdapter da = new SqlDataAdapter(sqlCom);
                DataSet ds = new DataSet();
                da.Fill(ds);

                if (ds != null && ds.Tables.Count > 0)
                {
                    ddlClientName.DataTextField = "ClientName";
                    ddlClientName.DataValueField = "ID";
                    ddlClientName.DataSource = ds.Tables[0];
                    ddlClientName.DataBind();

                    ddlClientName.Items.Insert(0, "--Select--");
                    ddlClientName.SelectedIndex = 0;

                    ddlClientNameEdit.DataTextField = "ClientName";
                    ddlClientNameEdit.DataValueField = "ID";
                    ddlClientNameEdit.DataSource = ds.Tables[0];
                    ddlClientNameEdit.DataBind();

                    ddlClientNameEdit.Items.Insert(0, "--Select--");
                    ddlClientNameEdit.SelectedIndex = 0;
                }

            }
            catch (Exception ex)
            {

            }
        }

        protected void ddlClientName_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection sqlCon = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);

            SqlCommand sqlCom = new SqlCommand();
            sqlCom.Connection = sqlCon;
            sqlCom.CommandType = CommandType.StoredProcedure;
            sqlCom.CommandText = "CDMA_OnIndexChangeOfClient_SP";
            sqlCom.CommandTimeout = 0;

            SqlParameter Client = new SqlParameter();
            Client.SqlDbType = SqlDbType.VarChar;
            Client.Value = ddlClientName.SelectedValue;
            Client.ParameterName = "@ClientID";
            sqlCom.Parameters.Add(Client);

            sqlCon.Open();

            SqlDataAdapter da = new SqlDataAdapter(sqlCom);
            DataSet ds = new DataSet();
            da.Fill(ds);

            sqlCon.Close();

            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                ddlActivity.DataTextField = "Activity";
                ddlActivity.DataValueField = "ID";
                ddlActivity.DataSource = ds.Tables[0];
                ddlActivity.DataBind();

                ddlActivity.Items.Insert(0, "--Select--");
                ddlActivity.SelectedIndex = 0;

                ddlProduct.DataTextField = "Product";
                ddlProduct.DataValueField = "ID";
                ddlProduct.DataSource = ds.Tables[1];
                ddlProduct.DataBind();

                ddlProduct.Items.Insert(0, "--Select--");
                ddlProduct.SelectedIndex = 0;

            }
            else
            {
                ddlActivity.Items.Clear();
                ddlProduct.Items.Clear();
            }
        }

        protected void ddlClientNameEdit_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection sqlCon = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);

            SqlCommand sqlCom = new SqlCommand();
            sqlCom.Connection = sqlCon;
            sqlCom.CommandType = CommandType.StoredProcedure;
            sqlCom.CommandText = "CDMA_OnIndexChangeOfClient_SP";
            sqlCom.CommandTimeout = 0;

            SqlParameter Client = new SqlParameter();
            Client.SqlDbType = SqlDbType.VarChar;
            Client.Value = ddlClientNameEdit.SelectedValue;
            Client.ParameterName = "@ClientID";
            sqlCom.Parameters.Add(Client);

            sqlCon.Open();

            SqlDataAdapter da = new SqlDataAdapter(sqlCom);
            DataSet ds = new DataSet();
            da.Fill(ds);

            sqlCon.Close();

            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                ddlActivityEdit.DataTextField = "Activity";
                ddlActivityEdit.DataValueField = "ID";
                ddlActivityEdit.DataSource = ds.Tables[0];
                ddlActivityEdit.DataBind();

                ddlActivityEdit.Items.Insert(0, "--Select--");
                ddlActivityEdit.SelectedIndex = 0;

                ddlProductEdit.DataTextField = "Product";
                ddlProductEdit.DataValueField = "ID";
                ddlProductEdit.DataSource = ds.Tables[1];
                ddlProductEdit.DataBind();

                ddlProductEdit.Items.Insert(0, "--Select--");
                ddlProductEdit.SelectedIndex = 0;


            }
            else
            {
                ddlActivityEdit.Items.Clear();
                ddlProductEdit.Items.Clear();
            }
        }

        protected void BindActivity()
        {
            try
            {
                SqlConnection sqlCon = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);

                SqlCommand sqlCom = new SqlCommand();
                sqlCom.Connection = sqlCon;
                sqlCom.CommandType = CommandType.StoredProcedure;
                sqlCom.CommandText = "CDMA_BindActivity";
                sqlCom.CommandTimeout = 0;

                SqlDataAdapter da = new SqlDataAdapter(sqlCom);
                DataSet ds = new DataSet();
                da.Fill(ds);

                if (ds != null && ds.Tables.Count > 0)
                {
                    ddlActivity.DataTextField = "Activity";
                    ddlActivity.DataValueField = "ID";
                    ddlActivity.DataSource = ds.Tables[0];
                    ddlActivity.DataBind();

                    ddlActivity.Items.Insert(0, "--Select--");
                    ddlActivity.SelectedIndex = 0;

                    ddlActivityEdit.DataTextField = "Activity";
                    ddlActivityEdit.DataValueField = "ID";
                    ddlActivityEdit.DataSource = ds.Tables[0];
                    ddlActivityEdit.DataBind();

                    ddlActivityEdit.Items.Insert(0, "--Select--");
                    ddlActivityEdit.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {

            }
        }

        //protected void ddlActivity_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    SqlConnection sqlCon = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);

        //    SqlCommand sqlCom = new SqlCommand();
        //    sqlCom.Connection = sqlCon;
        //    sqlCom.CommandType = CommandType.StoredProcedure;
        //    sqlCom.CommandText = "CDMA_OnIndexChangeOfActivity_SP";
        //    sqlCom.CommandTimeout = 0;

        //    SqlParameter Client = new SqlParameter();
        //    Client.SqlDbType = SqlDbType.VarChar;
        //    Client.Value = ddlClientName.SelectedValue;
        //    Client.ParameterName = "@ClientID";
        //    sqlCom.Parameters.Add(Client);

        //    SqlParameter SubVertical = new SqlParameter();
        //    SubVertical.SqlDbType = SqlDbType.VarChar;
        //    SubVertical.Value = ddlSubVertical.SelectedValue;
        //    SubVertical.ParameterName = "@SubVerticalID";
        //    sqlCom.Parameters.Add(SubVertical);

        //    sqlCon.Open();

        //    SqlDataAdapter da = new SqlDataAdapter(sqlCom);
        //    DataSet ds = new DataSet();
        //    da.Fill(ds);

        //    sqlCon.Close();

        //    if (ds != null && ds.Tables[0].Rows.Count > 0)
        //    {
        //        ddlProduct.DataTextField = "Product";
        //        ddlProduct.DataValueField = "ID";
        //        ddlProduct.DataSource = ds.Tables[0];
        //        ddlProduct.DataBind();

        //        ddlProduct.Items.Insert(0, "--Select--");
        //        ddlProduct.SelectedIndex = 0;

        //    }
        //    else
        //    {
        //        ddlProduct.Items.Clear();
        //    }
        //}

        //protected void ddlActivityEdit_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    SqlConnection sqlCon = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);

        //    SqlCommand sqlCom = new SqlCommand();
        //    sqlCom.Connection = sqlCon;
        //    sqlCom.CommandType = CommandType.StoredProcedure;
        //    sqlCom.CommandText = "CDMA_OnIndexChangeOfActivity_SP";
        //    sqlCom.CommandTimeout = 0;

        //    SqlParameter Client = new SqlParameter();
        //    Client.SqlDbType = SqlDbType.VarChar;
        //    Client.Value = ddlClientNameEdit.SelectedValue;
        //    Client.ParameterName = "@ClientID";
        //    sqlCom.Parameters.Add(Client);

        //    SqlParameter SubVertical = new SqlParameter();
        //    SubVertical.SqlDbType = SqlDbType.VarChar;
        //    SubVertical.Value = ddlSubVerticalEdit.SelectedValue;
        //    SubVertical.ParameterName = "@SubVerticalID";
        //    sqlCom.Parameters.Add(SubVertical);

        //    sqlCon.Open();

        //    SqlDataAdapter da = new SqlDataAdapter(sqlCom);
        //    DataSet ds = new DataSet();
        //    da.Fill(ds);

        //    sqlCon.Close();

        //    if (ds != null && ds.Tables[0].Rows.Count > 0)
        //    {
        //        ddlProductEdit.DataTextField = "Product";
        //        ddlProductEdit.DataValueField = "ID";
        //        ddlProductEdit.DataSource = ds.Tables[0];
        //        ddlProductEdit.DataBind();

        //        ddlProductEdit.Items.Insert(0, "--Select--");
        //        ddlProductEdit.SelectedIndex = 0;
        //    }
        //    else
        //    {
        //        ddlProductEdit.Items.Clear();
        //    }
        //}

        protected void BindProduct()
        {
            try
            {
                SqlConnection sqlCon = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);

                SqlCommand sqlCom = new SqlCommand();
                sqlCom.Connection = sqlCon;
                sqlCom.CommandType = CommandType.StoredProcedure;
                sqlCom.CommandText = "CDMA_BindProduct";
                sqlCom.CommandTimeout = 0;

                SqlDataAdapter da = new SqlDataAdapter(sqlCom);
                DataSet ds = new DataSet();
                da.Fill(ds);

                if (ds != null && ds.Tables.Count > 0)
                {
                    ddlProduct.DataTextField = "Product";
                    ddlProduct.DataValueField = "ID";
                    ddlProduct.DataSource = ds.Tables[0];
                    ddlProduct.DataBind();

                    ddlProduct.Items.Insert(0, "--Select--");
                    ddlProduct.SelectedIndex = 0;

                    ddlProductEdit.DataTextField = "Product";
                    ddlProductEdit.DataValueField = "ID";
                    ddlProductEdit.DataSource = ds.Tables[0];
                    ddlProductEdit.DataBind();

                    ddlProductEdit.Items.Insert(0, "--Select--");
                    ddlProductEdit.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {

            }
        }

        protected void ddlProduct_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection sqlCon = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);

            SqlCommand sqlCom = new SqlCommand();
            sqlCom.Connection = sqlCon;
            sqlCom.CommandType = CommandType.StoredProcedure;
            sqlCom.CommandText = "CDMA_OnIndexChangeOfProduct_SP";
            sqlCom.CommandTimeout = 0;

            SqlParameter Product = new SqlParameter();
            Product.SqlDbType = SqlDbType.VarChar;
            Product.Value = ddlProduct.SelectedValue;
            Product.ParameterName = "@ProductID";
            sqlCom.Parameters.Add(Product);

            sqlCon.Open();

            SqlDataAdapter da = new SqlDataAdapter(sqlCom);
            DataSet ds = new DataSet();
            da.Fill(ds);

            sqlCon.Close();

            if (ds.Tables[0].Rows.Count > 0 && ds != null)
            {
                ddlSubProduct.DataTextField = "SubProduct";
                ddlSubProduct.DataValueField = "ID";
                ddlSubProduct.DataSource = ds.Tables[0];
                ddlSubProduct.DataBind();

                ddlSubProduct.Items.Insert(0, "--Select--");
                ddlSubProduct.SelectedIndex = 0;
                ddlSubProduct.Enabled = true;
            }
            else
            {
                ddlSubProduct.Enabled = false;
            }
        }

        protected void ddlProductEdit_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection sqlCon = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);

            SqlCommand sqlCom = new SqlCommand();
            sqlCom.Connection = sqlCon;
            sqlCom.CommandType = CommandType.StoredProcedure;
            sqlCom.CommandText = "CDMA_OnIndexChangeOfProduct_SP";
            sqlCom.CommandTimeout = 0;

            SqlParameter Product = new SqlParameter();
            Product.SqlDbType = SqlDbType.VarChar;
            Product.Value = ddlProductEdit.SelectedValue;
            Product.ParameterName = "@ProductID";
            sqlCom.Parameters.Add(Product);

            sqlCon.Open();

            SqlDataAdapter da = new SqlDataAdapter(sqlCom);
            DataSet ds = new DataSet();
            da.Fill(ds);

            sqlCon.Close();

            if (ds.Tables[0].Rows.Count > 0 && ds != null)
            {
                ddlSubProductEdit.DataTextField = "SubProduct";
                ddlSubProductEdit.DataValueField = "ID";
                ddlSubProductEdit.DataSource = ds.Tables[0];
                ddlSubProductEdit.DataBind();

                ddlSubProductEdit.Items.Insert(0, "--Select--");
                ddlSubProductEdit.SelectedIndex = 0;

                ddlSubProductEdit.Enabled = true;
            }
            else
            {
                ddlSubProductEdit.Enabled = false;
            }
        }

        protected void BindSubProduct()
        {
            try
            {
                SqlConnection sqlCon = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);

                SqlCommand sqlCom = new SqlCommand();
                sqlCom.Connection = sqlCon;
                sqlCom.CommandType = CommandType.StoredProcedure;
                sqlCom.CommandText = "CDMA_BindSubProduct";
                sqlCom.CommandTimeout = 0;

                SqlDataAdapter da = new SqlDataAdapter(sqlCom);
                DataSet ds = new DataSet();
                da.Fill(ds);

                if (ds != null && ds.Tables.Count > 0)
                {
                    ddlSubProduct.DataTextField = "SubProduct";
                    ddlSubProduct.DataValueField = "ID";
                    ddlSubProduct.DataSource = ds.Tables[0];
                    ddlSubProduct.DataBind();

                    ddlSubProduct.Items.Insert(0, "--Select--");
                    ddlSubProduct.SelectedIndex = 0;

                    ddlSubProductEdit.DataTextField = "SubProduct";
                    ddlSubProductEdit.DataValueField = "ID";
                    ddlSubProductEdit.DataSource = ds.Tables[0];
                    ddlSubProductEdit.DataBind();

                    ddlSubProductEdit.Items.Insert(0, "--Select--");
                    ddlSubProductEdit.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {

            }
        }

        protected void BindStatus()
        {
            try
            {
                SqlConnection sqlCon = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);

                SqlCommand sqlCom = new SqlCommand();
                sqlCom.Connection = sqlCon;
                sqlCom.CommandType = CommandType.StoredProcedure;
                sqlCom.CommandText = "CDMA_BindStatus";
                sqlCom.CommandTimeout = 0;

                SqlDataAdapter da = new SqlDataAdapter(sqlCom);
                DataSet ds = new DataSet();
                da.Fill(ds);

                if (ds != null && ds.Tables.Count > 0)
                {
                    ddlStatus.DataTextField = "Description";
                    ddlStatus.DataValueField = "ID";
                    ddlStatus.DataSource = ds.Tables[0];
                    ddlStatus.DataBind();

                    ddlStatus.Items.Insert(0, "--Select--");
                    ddlStatus.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {

            }
        }

        protected void BindCoreStaffing()
        {
            try
            {
                SqlConnection sqlCon = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);

                SqlCommand sqlCom = new SqlCommand();
                sqlCom.Connection = sqlCon;
                sqlCom.CommandType = CommandType.StoredProcedure;
                sqlCom.CommandText = "CDMA_BindCoreStaffing";
                sqlCom.CommandTimeout = 0;

                SqlDataAdapter da = new SqlDataAdapter(sqlCom);
                DataSet ds = new DataSet();
                da.Fill(ds);

                if (ds != null && ds.Tables.Count > 0)
                {
                    ddlCoreStaffing.DataTextField = "Description";
                    ddlCoreStaffing.DataValueField = "ID";
                    ddlCoreStaffing.DataSource = ds.Tables[0];
                    ddlCoreStaffing.DataBind();

                    ddlCoreStaffing.Items.Insert(0, "--Select--");
                    ddlCoreStaffing.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {

            }
        }
        protected void BindCentralLocalActivity()
        {
            try
            {
                SqlConnection sqlCon = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);

                SqlCommand sqlCom = new SqlCommand();
                sqlCom.Connection = sqlCon;
                sqlCom.CommandType = CommandType.StoredProcedure;
                sqlCom.CommandText = "CDMA_BindCentralLocalActivity";
                sqlCom.CommandTimeout = 0;

                SqlDataAdapter da = new SqlDataAdapter(sqlCom);
                DataSet ds = new DataSet();
                da.Fill(ds);

                if (ds != null && ds.Tables.Count > 0)
                {
                    ddlCentralLocalActivity.DataTextField = "Description";
                    ddlCentralLocalActivity.DataValueField = "ID";
                    ddlCentralLocalActivity.DataSource = ds.Tables[0];
                    ddlCentralLocalActivity.DataBind();

                    ddlCentralLocalActivity.Items.Insert(0, "--Select--");
                    ddlCentralLocalActivity.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {

            }
        }
        protected void BindBillingProcess()
        {
            try
            {
                SqlConnection sqlCon = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);

                SqlCommand sqlCom = new SqlCommand();
                sqlCom.Connection = sqlCon;
                sqlCom.CommandType = CommandType.StoredProcedure;
                sqlCom.CommandText = "CDMA_BindBillingProcess";
                sqlCom.CommandTimeout = 0;

                SqlDataAdapter da = new SqlDataAdapter(sqlCom);
                DataSet ds = new DataSet();
                da.Fill(ds);

                if (ds != null && ds.Tables.Count > 0)
                {
                    ddlBillingProcess.DataTextField = "Description";
                    ddlBillingProcess.DataValueField = "ID";
                    ddlBillingProcess.DataSource = ds.Tables[0];
                    ddlBillingProcess.DataBind();

                    ddlBillingProcess.Items.Insert(0, "--Select--");
                    ddlBillingProcess.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {

            }
        }
        protected void BindPenaltyClause()
        {
            try
            {
                SqlConnection sqlCon = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);

                SqlCommand sqlCom = new SqlCommand();
                sqlCom.Connection = sqlCon;
                sqlCom.CommandType = CommandType.StoredProcedure;
                sqlCom.CommandText = "CDMA_PenaltyClause";
                sqlCom.CommandTimeout = 0;

                SqlDataAdapter da = new SqlDataAdapter(sqlCom);
                DataSet ds = new DataSet();
                da.Fill(ds);

                if (ds != null && ds.Tables.Count > 0)
                {
                    ddlPenaltyClause.DataTextField = "Description";
                    ddlPenaltyClause.DataValueField = "ID";
                    ddlPenaltyClause.DataSource = ds.Tables[0];
                    ddlPenaltyClause.DataBind();

                    ddlPenaltyClause.Items.Insert(0, "--Select--");
                    ddlPenaltyClause.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {

            }
        }
        protected void BindMGV()
        {
            try
            {
                SqlConnection sqlCon = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);

                SqlCommand sqlCom = new SqlCommand();
                sqlCom.Connection = sqlCon;
                sqlCom.CommandType = CommandType.StoredProcedure;
                sqlCom.CommandText = "CDMA_MGV";
                sqlCom.CommandTimeout = 0;

                SqlDataAdapter da = new SqlDataAdapter(sqlCom);
                DataSet ds = new DataSet();
                da.Fill(ds);

                if (ds != null && ds.Tables.Count > 0)
                {
                    ddlMGV.DataTextField = "Description";
                    ddlMGV.DataValueField = "ID";
                    ddlMGV.DataSource = ds.Tables[0];
                    ddlMGV.DataBind();

                    ddlMGV.Items.Insert(0, "--Select--");
                    ddlMGV.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {

            }
        }
        protected void BindICLOCL()
        {
            try
            {
                SqlConnection sqlCon = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);

                SqlCommand sqlCom = new SqlCommand();
                sqlCom.Connection = sqlCon;
                sqlCom.CommandType = CommandType.StoredProcedure;
                sqlCom.CommandText = "CDMA_BindICLOCL";
                sqlCom.CommandTimeout = 0;

                SqlDataAdapter da = new SqlDataAdapter(sqlCom);
                DataSet ds = new DataSet();
                da.Fill(ds);

                if (ds != null && ds.Tables.Count > 0)
                {
                    ddlICLOCL.DataTextField = "Description";
                    ddlICLOCL.DataValueField = "ID";
                    ddlICLOCL.DataSource = ds.Tables[0];
                    ddlICLOCL.DataBind();

                    ddlICLOCL.Items.Insert(0, "--Select--");
                    ddlICLOCL.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {

            }
        }
        protected void BindBillingMode()
        {
            try
            {
                SqlConnection sqlCon = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);

                SqlCommand sqlCom = new SqlCommand();
                sqlCom.Connection = sqlCon;
                sqlCom.CommandType = CommandType.StoredProcedure;
                sqlCom.CommandText = "CDMA_BindBillingMode";
                sqlCom.CommandTimeout = 0;

                SqlDataAdapter da = new SqlDataAdapter(sqlCom);
                DataSet ds = new DataSet();
                da.Fill(ds);

                if (ds != null && ds.Tables.Count > 0)
                {
                    ddlBillingMode.DataTextField = "Description";
                    ddlBillingMode.DataValueField = "ID";
                    ddlBillingMode.DataSource = ds.Tables[0];
                    ddlBillingMode.DataBind();

                    ddlBillingMode.Items.Insert(0, "--Select--");
                    ddlBillingMode.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {

            }
        }
        protected void BindClientCRM()
        {
            try
            {
                SqlConnection sqlCon = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);

                SqlCommand sqlCom = new SqlCommand();
                sqlCom.Connection = sqlCon;
                sqlCom.CommandType = CommandType.StoredProcedure;
                sqlCom.CommandText = "CDMA_BindClientCRM";
                sqlCom.CommandTimeout = 0;

                SqlDataAdapter da = new SqlDataAdapter(sqlCom);
                DataSet ds = new DataSet();
                da.Fill(ds);

                if (ds != null && ds.Tables.Count > 0)
                {
                    ddlClientCRM.DataTextField = "Description";
                    ddlClientCRM.DataValueField = "ID";
                    ddlClientCRM.DataSource = ds.Tables[0];
                    ddlClientCRM.DataBind();

                    ddlClientCRM.Items.Insert(0, "--Select--");
                    ddlClientCRM.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {

            }
        }
        public string strDate(string strInDate)
        {

            string strMM = strInDate.Substring(3, 2);

            string strDD = strInDate.Substring(0, 2);

            string strYYYY = strInDate.Substring(6, 4);

            string strMMDDYYYY = strYYYY + "-" + strMM + "-" + strDD;

            //string strMMDDYYYY = strDD + "/" + strMM + "/" + strYYYY;

            DateTime dtConvertDate = Convert.ToDateTime(strMMDDYYYY);

            string strOutDate = dtConvertDate.ToString("yyyy-MM-dd");

            return strOutDate;
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {

                string msg = string.Empty;
                DateTime? NullDate = null;

                string SubProduct = string.Empty;
                string ICLOCL = string.Empty;

                if (ddlSubVertical.SelectedItem.Text == "--Select--")
                {
                    msg = msg + "Please Select Sub Vertical.";
                }
                if (ddlClientName.SelectedItem.Text == "--Select--")
                {
                    msg = msg + "Please Select Client Name.";
                }
                if (ddlActivity.SelectedItem.Text == "--Select--")
                {
                    msg = msg + "Please Select Activity.";
                }
                if (ddlProduct.SelectedItem.Text == "--Select--")
                {
                    msg = msg + "Please Select Product.";
                }
                if (ddlStatus.SelectedItem.Text == "--Select--")
                {
                    msg = msg + "Please Select Active / Closed Status.";
                }
                if (ddlCoreStaffing.SelectedItem.Text == "--Select--")
                {
                    msg = msg + "Please Select Core / Staffing.";
                }
                if (ddlCentralLocalActivity.SelectedItem.Text == "--Select--")
                {
                    msg = msg + "Please Select Central or Local activity.";
                }
                if (ddlBillingProcess.SelectedItem.Text == "--Select--")
                {
                    msg = msg + "Please Select Billing Process.";
                }
                if (ddlPenaltyClause.SelectedItem.Text == "--Select--")
                {
                    msg = msg + "Please Select Penalty Clause(Yes/No).";
                }
                if (ddlMGV.SelectedItem.Text == "--Select--")
                {
                    msg = msg + "Please Select MGV(Yes/No).";
                }

                if (ddlSubVertical.SelectedItem.Text == "CORE_PD")
                {
                    if (ddlICLOCL.SelectedItem.Text == "--Select--")
                    {
                        msg = msg + "Please Select ICL or OCL.";
                    }
                }
                if (ddlBillingMode.SelectedItem.Text == "--Select--")
                {
                    msg = msg + "Please Select Billing Mode.";
                }
                if (ddlClientCRM.SelectedItem.Text == "--Select--")
                {
                    msg = msg + "Please Select Client CRM.";
                }
                if (msg != "")
                {
                    ClientScript.RegisterStartupScript(Page.GetType(), "mykey", "alert('" + msg + "');", true);
                    return;
                }
                SqlConnection sqlCon = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);

                SqlCommand cmd = new SqlCommand("CDMA_InsertIntoRateMaster_SP", sqlCon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@SubVertical", ddlSubVertical.SelectedItem.Text);
                cmd.Parameters.AddWithValue("@ClientName", ddlClientName.SelectedItem.Text);
                cmd.Parameters.AddWithValue("@Activity", ddlActivity.SelectedItem.Text);
                cmd.Parameters.AddWithValue("@Product", ddlProduct.SelectedItem.Text);

                if (ddlSubProduct.SelectedItem.Text.Trim() != "--Select--" && ddlSubProduct.SelectedItem.Text.Trim() != "")
                {
                    SubProduct = ddlSubProduct.SelectedItem.Text;
                }

                cmd.Parameters.AddWithValue("@SubProduct", SubProduct);
                cmd.Parameters.AddWithValue("@Status", ddlStatus.SelectedItem.Text);
                cmd.Parameters.AddWithValue("@CoreorStaffing", ddlCoreStaffing.SelectedItem.Text);
                cmd.Parameters.AddWithValue("@CentralorLocalActivity", ddlCentralLocalActivity.SelectedItem.Text);
                cmd.Parameters.AddWithValue("@BillingProcess", ddlBillingProcess.SelectedItem.Text);
                cmd.Parameters.AddWithValue("@ClientAddress", txtClientAddress.Text);
                cmd.Parameters.AddWithValue("@ClientContactPersonName", txtClientContactPerson.Text);
                cmd.Parameters.AddWithValue("@ClientcontactNo", txtClientContactNo.Text);
                cmd.Parameters.AddWithValue("@ClientEmail", txtClientEmail.Text);
                cmd.Parameters.AddWithValue("@ClientGSTNo", txtClientGSTNo.Text);
                cmd.Parameters.AddWithValue("@TANNo", txtTANNo.Text);

                if (txtAgreementExeDate.Text.Trim() != "" && txtAgreementExeDate.Text.Trim() != null)
                {
                    cmd.Parameters.AddWithValue("@AgreementExeDate", strDate(txtAgreementExeDate.Text));
                }
                else
                {
                    cmd.Parameters.AddWithValue("@AgreementExeDate", NullDate);
                }

                if (txtAgreementExpiryDate.Text.Trim() != "" && txtAgreementExpiryDate.Text.Trim() != null)
                {
                    cmd.Parameters.AddWithValue("@AgreementExpiryDate", strDate(txtAgreementExpiryDate.Text));
                }
                else
                {
                    cmd.Parameters.AddWithValue("@AgreementExpiryDate", NullDate);
                }

                cmd.Parameters.AddWithValue("@PenaltyClause", ddlPenaltyClause.SelectedItem.Text);
                cmd.Parameters.AddWithValue("@MGV", ddlMGV.SelectedItem.Text);

                if (ddlICLOCL.SelectedItem.Text.Trim() != "--Select--" && ddlICLOCL.SelectedItem.Text.Trim() != "")
                {
                    ICLOCL = ddlICLOCL.SelectedItem.Text.Trim();
                }

                cmd.Parameters.AddWithValue("@ICLorOCL", ICLOCL);

                cmd.Parameters.AddWithValue("@BillingMode", ddlBillingMode.SelectedItem.Text);
                cmd.Parameters.AddWithValue("@RatePerFile", txtRatePerFile.Text);
                cmd.Parameters.AddWithValue("@ClientCRM", ddlClientCRM.SelectedItem.Text);
                cmd.Parameters.AddWithValue("@Remarks", txtRemarks.Text);
                cmd.Parameters.AddWithValue("@UserID", Convert.ToString(Session["UserID"]));


                sqlCon.Open();
                int result = cmd.ExecuteNonQuery();
                sqlCon.Close();

                if (result > 0)
                {
                    lblMsgXls.Visible = true;
                    lblMsgXls.Text = "Data Successfully added ";

                    ClearData();

                    PnlInsertRateMaster.Visible = true;
                    pnlRateMasterGrid.Visible = false;
                    pnlRadioButton.Visible = true;
                }
                else
                {
                    Session.Clear();
                    Response.Redirect("Login.aspx", false);
                }
            }
            catch (Exception ex)
            {
                lblMsgXls.Visible = true;
                lblMsgXls.Text = ex.ToString();
            }
        }
        protected void BtnBack_Click(object sender, EventArgs e)
        {
            string ComeFromEdit = Convert.ToString(ViewState["ComeFromEdit"]);

            if (ComeFromEdit == "Yes")
            {
                lblMsgXls.Text = "";
                PnlInsertRateMaster.Visible = false;
                pnlRateMasterGrid.Visible = true;
                SearchData();
            }
            else
            {
                Response.Redirect("CDMA_Menu.aspx", false);
            }
        }
        protected void rdFreshEdit_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rdFreshEdit.SelectedValue == "EDIT")
            {
                pnlRadioButton.Visible = false;
                PnlInsertRateMaster.Visible = false;
                pnlRateMasterGrid.Visible = true;
                pnlDownloadRateMaster.Visible = false;
            }
            if (rdFreshEdit.SelectedValue == "Download")
            {
                pnlRadioButton.Visible = false;
                PnlInsertRateMaster.Visible = false;
                pnlRateMasterGrid.Visible = false;
                pnlDownloadRateMaster.Visible = true;
                BindRateMaster();
            }
        }
        protected void SearchData()
        {
            string msg = string.Empty;
            if (ddlSubVerticalEdit.SelectedValue == "--Select--")
            {
                msg = msg + "Please Select Sub Vertical.";
            }
            if (ddlClientNameEdit.SelectedValue == "--Select--")
            {
                msg = msg + "Please Select Client Name.";
            }
            if (ddlActivityEdit.SelectedValue == "--Select--")
            {
                msg = msg + "Please Select Activity.";
            }
            if (ddlProductEdit.SelectedValue == "--Select--")
            {
                msg = msg + "Please Select product.";
            }
            //if (ddlSubProductEdit.SelectedValue == "--Select--")
            //{
            //    msg = msg + "Please Select Sub Product.";
            //}
            if (msg != "")
            {
                ClientScript.RegisterStartupScript(Page.GetType(), "mykey", "alert('" + msg + "');", true);
            }
            SqlConnection sqlCon = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);

            SqlCommand sqlCom = new SqlCommand();
            sqlCom.Connection = sqlCon;
            sqlCom.CommandType = CommandType.StoredProcedure;
            sqlCom.CommandText = "CDMA_SerachDataFromRateMaster_SP";
            sqlCom.CommandTimeout = 0;

            SqlParameter SubVertical = new SqlParameter();
            SubVertical.SqlDbType = SqlDbType.VarChar;
            SubVertical.Value = ddlSubVerticalEdit.SelectedItem.Text;
            SubVertical.ParameterName = "@SubVertical";
            sqlCom.Parameters.Add(SubVertical);

            SqlParameter ClientName = new SqlParameter();
            ClientName.SqlDbType = SqlDbType.VarChar;
            ClientName.Value = ddlClientNameEdit.SelectedItem.Text;
            ClientName.ParameterName = "@ClientName";
            sqlCom.Parameters.Add(ClientName);

            SqlParameter Activity = new SqlParameter();
            Activity.SqlDbType = SqlDbType.VarChar;
            Activity.Value = ddlActivityEdit.SelectedItem.Text;
            Activity.ParameterName = "@Activity";
            sqlCom.Parameters.Add(Activity);

            SqlParameter Product = new SqlParameter();
            Product.SqlDbType = SqlDbType.VarChar;
            Product.Value = ddlProductEdit.SelectedItem.Text;
            Product.ParameterName = "@Product";
            sqlCom.Parameters.Add(Product);

            if (ddlSubProductEdit.SelectedItem.Text.Trim() != "--Select--" && ddlSubProductEdit.SelectedItem.Text.Trim() != "")
            {
                SqlParameter SubProduct = new SqlParameter();
                SubProduct.SqlDbType = SqlDbType.VarChar;
                SubProduct.Value = ddlSubProductEdit.SelectedItem.Text;
                SubProduct.ParameterName = "@SubProduct";
                sqlCom.Parameters.Add(SubProduct);
            }
            else
            {
                SqlParameter SubProduct = new SqlParameter();
                SubProduct.SqlDbType = SqlDbType.VarChar;
                SubProduct.Value = "";
                SubProduct.ParameterName = "@SubProduct";
                sqlCom.Parameters.Add(SubProduct);
            }

            sqlCon.Open();

            SqlDataAdapter sqlDA = new SqlDataAdapter();
            sqlDA.SelectCommand = sqlCom;

            DataTable dt = new DataTable();
            sqlDA.Fill(dt);

            sqlCon.Close();

            if (dt.Rows.Count > 0)
            {
                gvRateMaster.DataSource = dt;
                gvRateMaster.DataBind();

                gvRateMaster.Rows[0].Cells[0].Enabled = false;
                gvRateMaster.Rows[0].Cells[1].Enabled = false;
            }
            else
            {
                gvRateMaster.DataSource = null;
                gvRateMaster.DataBind();

                lblMsgXls.Visible = true;
                lblMsgXls.Text = "No Case Found";
            }
        }
        protected void btnSearch_Click1(object sender, EventArgs e)
        {
            lblMsgXls.Text = "";
            PnlInsertRateMaster.Visible = false;
            pnlRateMasterGrid.Visible = true;
            SearchData();
        }
        protected void btnBackEdit_Click(object sender, EventArgs e)
        {
            Response.Redirect("CDMA_RateMaster.aspx", false);
        }
        protected void lkbtnEdit_Click(object sender, EventArgs e)
        {
            lblMsgXls.Text = "";
            pnlRadioButton.Visible = false;
            pnlRateMasterGrid.Visible = false;
            PnlInsertRateMaster.Visible = true;
            lblMsgXls.Text = "";
            int ifcheked = 0;

            try
            {
                for (int i = 0; i <= gvRateMaster.Rows.Count - 1; i++)
                {
                    CheckBox chkSelect = (CheckBox)gvRateMaster.Rows[i].FindControl("chkbox");

                    LinkButton WIP = (LinkButton)gvRateMaster.Rows[i].FindControl("lkbtnEdit");

                    if (chkSelect.Checked == true)
                    {

                        HdnID.Value = gvRateMaster.DataKeys[i].Value.ToString();
                        ddlSubVertical.SelectedItem.Text = gvRateMaster.Rows[i].Cells[1].Text.Trim();
                        ddlClientName.SelectedItem.Text = gvRateMaster.Rows[i].Cells[2].Text.Trim();
                        ddlActivity.SelectedItem.Text = gvRateMaster.Rows[i].Cells[3].Text.Trim();
                        ddlProduct.SelectedItem.Text = gvRateMaster.Rows[i].Cells[4].Text.Trim();

                        if (gvRateMaster.Rows[i].Cells[5].Text.Trim() != "&nbsp;")
                        {
                            ddlSubProduct.SelectedItem.Text = gvRateMaster.Rows[i].Cells[5].Text.Trim();
                        }

                        if (gvRateMaster.Rows[i].Cells[6].Text.Trim() != "&nbsp;")
                        {
                            ddlStatus.SelectedItem.Text = gvRateMaster.Rows[i].Cells[6].Text.Trim();

                        }

                        if (gvRateMaster.Rows[i].Cells[7].Text.Trim() != "&nbsp;")
                        {
                            ddlCoreStaffing.SelectedItem.Text = gvRateMaster.Rows[i].Cells[7].Text.Trim();

                        }

                        if (gvRateMaster.Rows[i].Cells[8].Text.Trim() != "&nbsp;")
                        {
                            ddlCentralLocalActivity.SelectedItem.Text = gvRateMaster.Rows[i].Cells[8].Text.Trim();

                        }

                        if (gvRateMaster.Rows[i].Cells[9].Text.Trim() != "&nbsp;")
                        {
                            ddlBillingProcess.SelectedItem.Text = gvRateMaster.Rows[i].Cells[9].Text.Trim();

                        }

                        if (gvRateMaster.Rows[i].Cells[10].Text.Trim() != "&nbsp;")
                        {
                            txtClientAddress.Text = gvRateMaster.Rows[i].Cells[10].Text.Trim();

                        }

                        if (gvRateMaster.Rows[i].Cells[11].Text.Trim() != "&nbsp;")
                        {
                            txtClientContactPerson.Text = gvRateMaster.Rows[i].Cells[11].Text.Trim();
                        }

                        if (gvRateMaster.Rows[i].Cells[12].Text.Trim() != "&nbsp;")
                        {
                            txtClientContactNo.Text = gvRateMaster.Rows[i].Cells[12].Text.Trim();
                        }

                        if (gvRateMaster.Rows[i].Cells[13].Text.Trim() != "&nbsp;")
                        {
                            txtClientEmail.Text = gvRateMaster.Rows[i].Cells[13].Text.Trim();
                        }

                        if (gvRateMaster.Rows[i].Cells[14].Text.Trim() != "&nbsp;")
                        {
                            txtClientGSTNo.Text = gvRateMaster.Rows[i].Cells[14].Text.Trim();
                        }

                        if (gvRateMaster.Rows[i].Cells[15].Text.Trim() != "&nbsp;")
                        {
                            txtTANNo.Text = gvRateMaster.Rows[i].Cells[15].Text.Trim();
                        }

                        if (gvRateMaster.Rows[i].Cells[16].Text.Trim() != "&nbsp;")
                        {
                            txtAgreementExeDate.Text = gvRateMaster.Rows[i].Cells[16].Text.Trim();
                        }

                        if (gvRateMaster.Rows[i].Cells[17].Text.Trim() != "&nbsp;")
                        {
                            txtAgreementExpiryDate.Text = gvRateMaster.Rows[i].Cells[17].Text.Trim();
                        }

                        if (gvRateMaster.Rows[i].Cells[18].Text.Trim() != "&nbsp;")
                        {
                            ddlPenaltyClause.SelectedItem.Text = gvRateMaster.Rows[i].Cells[18].Text.Trim();
                        }

                        if (gvRateMaster.Rows[i].Cells[19].Text.Trim() != "&nbsp;")
                        {
                            ddlMGV.SelectedItem.Text = gvRateMaster.Rows[i].Cells[19].Text.Trim();
                        }

                        if (gvRateMaster.Rows[i].Cells[20].Text.Trim() != "&nbsp;")
                        {
                            ddlICLOCL.SelectedItem.Text = gvRateMaster.Rows[i].Cells[20].Text.Trim();
                        }

                        if (gvRateMaster.Rows[i].Cells[21].Text.Trim() != "&nbsp;")
                        {
                            ddlBillingMode.SelectedItem.Text = gvRateMaster.Rows[i].Cells[21].Text.Trim();
                        }

                        if (gvRateMaster.Rows[i].Cells[22].Text.Trim() != "&nbsp;")
                        {
                            txtRatePerFile.Text = gvRateMaster.Rows[i].Cells[22].Text.Trim();
                        }

                        if (gvRateMaster.Rows[i].Cells[23].Text.Trim() != "&nbsp;")
                        {
                            ddlClientCRM.SelectedItem.Text = gvRateMaster.Rows[i].Cells[23].Text.Trim();
                        }

                        if (gvRateMaster.Rows[i].Cells[25].Text.Trim() != "&nbsp;")
                        {
                            txtRemarks.Text = gvRateMaster.Rows[i].Cells[25].Text.Trim();
                        }

                        btnSave.Visible = false;
                        btnUpdate.Visible = true;
                        BtnBack.Visible = true;
                        ifcheked = 1;

                        ViewState["ComeFromEdit"] = "Yes";
                        break;
                    }
                    else
                    {
                        lblMsgXls.Visible = true;
                        lblMsgXls.Text = "Error :";
                    }
                }


                if (ifcheked == 0)
                {
                    pnlRadioButton.Visible = false;
                    PnlInsertRateMaster.Visible = false;
                    pnlRateMasterGrid.Visible = true;
                    pnlDownloadRateMaster.Visible = false;

                    lblMsgXls.Visible = true;
                    lblMsgXls.Text = "Please select one record";
                }
            }
            catch (Exception ex)
            {
                lblMsgXls.Visible = true;
                lblMsgXls.Text = "Error :" + ex.Message;
            }
        }
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                lblMsgXls.Text = "";
                string msg = string.Empty;
                DateTime? NullDate = null;

                string SubProduct = string.Empty;
                string ICLOCL = string.Empty;


                if (ddlSubVertical.SelectedItem.Text == "--Select--")
                {
                    msg = msg + "Please Select Sub Vertical.";
                }
                if (ddlClientName.SelectedItem.Text == "--Select--")
                {
                    msg = msg + "Please Select Client Name.";
                }
                if (ddlActivity.SelectedItem.Text == "--Select--")
                {
                    msg = msg + "Please Select Activity.";
                }
                if (ddlProduct.SelectedItem.Text == "--Select--")
                {
                    msg = msg + "Please Select Product.";
                }
                //if (ddlSubProduct.SelectedItem.Text == "--Select--")
                //{
                //    msg = msg + "Please Select Sub Product.";
                //}
                if (ddlStatus.SelectedItem.Text == "--Select--")
                {
                    msg = msg + "Please Select Active / Closed Status.";
                }
                if (ddlCoreStaffing.SelectedItem.Text == "--Select--")
                {
                    msg = msg + "Please Select Core / Staffing.";
                }
                if (ddlCentralLocalActivity.SelectedItem.Text == "--Select--")
                {
                    msg = msg + "Please Select Central or Local activity.";
                }
                if (ddlBillingProcess.SelectedItem.Text == "--Select--")
                {
                    msg = msg + "Please Select Billing Process.";
                }
                if (ddlPenaltyClause.SelectedItem.Text == "--Select--")
                {
                    msg = msg + "Please Select Penalty Clause(Yes/No).";
                }
                if (ddlMGV.SelectedItem.Text == "--Select--")
                {
                    msg = msg + "Please Select MGV(Yes/No).";
                }

                if (ddlSubVertical.SelectedItem.Text == "CORE_PD")
                {
                    if (ddlICLOCL.SelectedItem.Text == "--Select--")
                    {
                        msg = msg + "Please Select ICL or OCL.";
                    }
                }
                if (ddlBillingMode.SelectedItem.Text == "--Select--")
                {
                    msg = msg + "Please Select Billing Mode.";
                }
                if (ddlClientCRM.SelectedItem.Text == "--Select--")
                {
                    msg = msg + "Please Select Client CRM.";
                }
                if (msg != "")
                {
                    ClientScript.RegisterStartupScript(Page.GetType(), "mykey", "alert('" + msg + "');", true);
                    return;
                }

                SqlConnection sqlCon = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);

                SqlCommand cmd = new SqlCommand("CDMA_UpdateRateMaster_SP", sqlCon);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@ID", Convert.ToInt32(HdnID.Value));
                cmd.Parameters.AddWithValue("@SubVertical", ddlSubVertical.SelectedItem.Text);
                cmd.Parameters.AddWithValue("@ClientName", ddlClientName.SelectedItem.Text);
                cmd.Parameters.AddWithValue("@Activity", ddlActivity.SelectedItem.Text);
                cmd.Parameters.AddWithValue("@Product", ddlProduct.SelectedItem.Text);

                if (ddlSubProduct.SelectedItem.Text.Trim() != "--Select--" && ddlSubProduct.SelectedItem.Text.Trim() != "")
                {
                    SubProduct = ddlSubProduct.SelectedItem.Text;
                }

                cmd.Parameters.AddWithValue("@SubProduct", SubProduct);

                cmd.Parameters.AddWithValue("@Status", ddlStatus.SelectedItem.Text);
                cmd.Parameters.AddWithValue("@CoreorStaffing", ddlCoreStaffing.SelectedItem.Text);
                cmd.Parameters.AddWithValue("@CentralorLocalActivity", ddlCentralLocalActivity.SelectedItem.Text);
                cmd.Parameters.AddWithValue("@BillingProcess", ddlBillingProcess.SelectedItem.Text);
                cmd.Parameters.AddWithValue("@ClientAddress", txtClientAddress.Text);
                cmd.Parameters.AddWithValue("@ClientContactPersonName", txtClientContactPerson.Text);
                cmd.Parameters.AddWithValue("@ClientcontactNo", txtClientContactNo.Text);
                cmd.Parameters.AddWithValue("@ClientEmail", txtClientEmail.Text);
                cmd.Parameters.AddWithValue("@ClientGSTNo", txtClientGSTNo.Text);
                cmd.Parameters.AddWithValue("@TANNo", txtTANNo.Text);

                if (txtAgreementExeDate.Text.Trim() != "" && txtAgreementExeDate.Text.Trim() != null)
                {
                    cmd.Parameters.AddWithValue("@AgreementExeDate", strDate(txtAgreementExeDate.Text));
                }
                else
                {
                    cmd.Parameters.AddWithValue("@AgreementExeDate", NullDate);
                }

                if (txtAgreementExpiryDate.Text.Trim() != "" && txtAgreementExpiryDate.Text.Trim() != null)
                {
                    cmd.Parameters.AddWithValue("@AgreementExpiryDate", strDate(txtAgreementExpiryDate.Text));
                }
                else
                {
                    cmd.Parameters.AddWithValue("@AgreementExpiryDate", NullDate);
                }

                cmd.Parameters.AddWithValue("@PenaltyClause", ddlPenaltyClause.SelectedItem.Text);
                cmd.Parameters.AddWithValue("@MGV", ddlMGV.SelectedItem.Text);

                if (ddlICLOCL.SelectedItem.Text.Trim() != "--Select--" && ddlICLOCL.SelectedItem.Text.Trim() != "")
                {
                    ICLOCL = ddlICLOCL.SelectedItem.Text.Trim();
                }

                cmd.Parameters.AddWithValue("@ICLorOCL", ICLOCL);
                
                cmd.Parameters.AddWithValue("@BillingMode", ddlBillingMode.SelectedItem.Text);
                cmd.Parameters.AddWithValue("@RatePerFile", txtRatePerFile.Text);
                cmd.Parameters.AddWithValue("@ClientCRM", ddlClientCRM.SelectedItem.Text);
                cmd.Parameters.AddWithValue("@Remarks", txtRemarks.Text);
                cmd.Parameters.AddWithValue("@UserID", Convert.ToString(Session["UserID"]));


                sqlCon.Open();
                int result = cmd.ExecuteNonQuery();
                sqlCon.Close();

                if (result > 0)
                {
                    lblMsgXls.Visible = true;
                    lblMsgXls.Text = "Data updated Successfully";

                    SearchData();
                    pnlRadioButton.Visible = false;
                    PnlInsertRateMaster.Visible = false;
                    pnlRateMasterGrid.Visible = true;
                    pnlDownloadRateMaster.Visible = false;
                }
                else
                {
                    Session.Clear();
                    Response.Redirect("Login.aspx", false);
                }
            }
            catch (Exception ex)
            {
                lblMsgXls.Visible = true;
                lblMsgXls.Text = ex.ToString();
            }
        }
        protected void BindRateMaster()
        {
            lblMsgXls.Text = "";
            SqlConnection sqlCon = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);

            SqlCommand sqlCom = new SqlCommand();
            sqlCom.Connection = sqlCon;
            sqlCom.CommandType = CommandType.StoredProcedure;
            sqlCom.CommandText = "CDMA_BindRateMaster";
            sqlCom.CommandTimeout = 0;

            sqlCon.Open();

            SqlDataAdapter sqlDA = new SqlDataAdapter();
            sqlDA.SelectCommand = sqlCom;

            DataTable dt = new DataTable();
            sqlDA.Fill(dt);

            sqlCon.Close();

            if (dt.Rows.Count > 0)
            {
                gvData.DataSource = dt;
                gvData.DataBind();

                gvData.Rows[0].Cells[0].Enabled = false;
                gvData.Rows[0].Cells[1].Enabled = false;
            }
            else
            {
                gvData.DataSource = null;
                gvData.DataBind();

                lblMsgXls.Visible = true;
                lblMsgXls.Text = "No Case Found";
            }
        }
        protected void btnDownloadRateMaster_Click(object sender, EventArgs e)
        {
            Genrate_Excel();
        }
        private void Genrate_Excel()
        {
            String attachment = "attachment; filename=" + "Rate Master" + ".xls";
            Response.AddHeader("content-disposition", attachment);
            Response.ContentType = "application/ms-excel";
            StringWriter sw = new System.IO.StringWriter();
            HtmlTextWriter htw = new HtmlTextWriter(sw);
            Table tblSpace = new Table();
            TableRow tblRow = new TableRow();
            TableCell tblCell = new TableCell();
            tblCell.Text = " ";
            tblCell.ColumnSpan = 30;// 10;
            tblCell.Text = "<b> <font size='2' color='blue'>PAMAC FINSERVE PVT. LTD.</font></span></b> <br/>";
            tblCell.CssClass = "SuccessMessage";
            TableRow tblRow1 = new TableRow();
            TableCell tblCell1 = new TableCell();
            tblCell1.ColumnSpan = 30;// 10;
            tblCell1.CssClass = "SuccessMessage";
            tblRow.Cells.Add(tblCell);
            tblRow1.Cells.Add(tblCell1);
            tblRow.Height = 20;
            tblSpace.Rows.Add(tblRow);
            tblSpace.Rows.Add(tblRow1);
            tblSpace.RenderControl(htw);

            Table tbl1 = new Table();
            gvData.EnableViewState = false;
            gvData.GridLines = GridLines.Both;
            gvData.RenderControl(htw);
            Response.Write(sw.ToString());

            Response.End();
            Response.Write(sw.ToString());
        }
        public override void VerifyRenderingInServerForm(Control control)
        {
            // base.VerifyRenderingInServerForm(control);
        }
        protected void btnBack1_Click(object sender, EventArgs e)
        {
            Response.Redirect("CDMA_RateMaster.aspx", false);
        }
        protected void ClearData()
        {
            ddlSubVertical.SelectedIndex = 0;
            ddlClientName.SelectedIndex = 0;
            ddlActivity.SelectedIndex = 0;
            ddlProduct.SelectedIndex = 0;
            ddlSubProduct.SelectedIndex = 0;
            ddlStatus.SelectedIndex = 0;
            ddlCoreStaffing.SelectedIndex = 0;
            ddlCentralLocalActivity.SelectedIndex = 0;
            ddlBillingProcess.SelectedIndex = 0;
            txtClientAddress.Text = "";
            txtClientContactPerson.Text = "";
            txtClientContactNo.Text = "";
            txtClientEmail.Text = "";
            txtClientGSTNo.Text = "";
            txtTANNo.Text = "";
            txtAgreementExeDate.Text = "";
            txtAgreementExpiryDate.Text = "";
            ddlPenaltyClause.SelectedIndex = 0;
            ddlMGV.SelectedIndex = 0;
            ddlICLOCL.SelectedIndex = 0;
            ddlBillingMode.SelectedIndex = 0;
            txtRatePerFile.Text = "";
            ddlClientCRM.SelectedIndex = 0;
            txtRemarks.Text = "";
        }

        //protected void gvData_PageIndexChanging(object sender, GridViewPageEventArgs e)
        //{
        //    gvData.PageIndex = e.NewPageIndex;
        //    BindRateMaster();
        //}
    }
}