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
using System.Data.SqlClient;
using System.IO;
using System.Drawing;


public partial class Pages_LOSTracker_SuperAdmin : System.Web.UI.Page
{

    string proc;

    protected void Page_Load(object sender, EventArgs e)
    {
        Object SaveUSERInfo = (Object)Session["UserInfo"];
        SqlConnection sqlCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);

        if (Session["UserInfo"] == null)
        {
            Response.Redirect("~/Pages/Logout.aspx");

            Response.AppendHeader("Refresh", "2");
        }

        if (!IsPostBack)
        {
            BindLocation();
            BindProduct();
            BindDropDownList1();
            Get_AllPriorityList();
            Get_BranchList();
            Get_DataForIndexing();

            string grupname = Convert.ToString(((UserInfo.structUSERInfo)(SaveUSERInfo)).GroupName);


            ddlchngrpc.Enabled = true;
            ddlrpclocation.Enabled = true;
            Btnchangerpc.Enabled = true;


        }

    }
    protected void BindLocation()
    {
        SqlConnection sqlCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);

            SqlCommand cmd = new SqlCommand("IRPC_MasterSearchCode_SP", sqlCon);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Types", "RPCLocationType");
            cmd.Parameters.AddWithValue("@Level", 1);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            adp.Fill(ds);

            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                ddlrpclocation.DataSource = ds;
                ddlrpclocation.DataValueField = "Code_Id";
                ddlrpclocation.DataTextField = "Description";
                ddlrpclocation.DataBind();
                ddlrpclocation.Items.Insert(0, new ListItem("--Select--", "0"));

                ddlchngrpc.DataSource = ds;
                ddlchngrpc.DataValueField = "Code_Id";
                ddlchngrpc.DataTextField = "Description";
                ddlchngrpc.DataBind();
                ddlchngrpc.Items.Insert(0, new ListItem("--Select--", "0"));
            }
        
    }
    protected void BindProduct()
    {
        SqlConnection sqlCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);

        SqlCommand cmd = new SqlCommand("IRPC_MasterSearchCode_SP", sqlCon);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@Types", "RPCProduct");
        cmd.Parameters.AddWithValue("@Level", 1);
        SqlDataAdapter adp = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        adp.Fill(ds);

        if (ds != null && ds.Tables[0].Rows.Count > 0)
        {
            ddlproduct.DataSource = ds;
            ddlproduct.DataValueField = "Code_Id";
            ddlproduct.DataTextField = "Description";
            ddlproduct.DataBind();
            ddlproduct.Items.Insert(0, new ListItem("--Select--", "0"));
        }
    }
    protected void BindDropDownList1()
    {
        SqlConnection sqlCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);

        SqlCommand cmd = new SqlCommand("IRPC_MasterSearchCode_SP", sqlCon);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@Types", "RPCDDL");
        cmd.Parameters.AddWithValue("@Level", 1);
        SqlDataAdapter adp = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        adp.Fill(ds);

        if (ds != null && ds.Tables[0].Rows.Count > 0)
        {
            DropDownList1.DataSource = ds;
            DropDownList1.DataValueField = "Code_Id";
            DropDownList1.DataTextField = "Description";
            DropDownList1.DataBind();
            DropDownList1.Items.Insert(0, new ListItem("--Select--", "0"));
        }
    }
    private void Get_BranchList()
    {

        Object SaveUSERInfo = (Object)Session["UserInfo"];
        SqlConnection sqlCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);
        try
        {

            SqlCommand sqlCom = new SqlCommand();
            sqlCom.Connection = sqlCon;
            sqlCom.CommandType = CommandType.StoredProcedure;
            sqlCom.CommandText = "IRPC_Get_AllLocationsList_ICICI_SP";
            sqlCom.CommandTimeout = 0;


            if (ddlrpclocation.SelectedIndex == 0)
            {
                SqlParameter BranchId = new SqlParameter();
                BranchId.SqlDbType = SqlDbType.VarChar;
                BranchId.Value = Convert.ToString(((UserInfo.structUSERInfo)(SaveUSERInfo)).BranchId);
                BranchId.ParameterName = "@PMSlocation";
                sqlCom.Parameters.Add(BranchId);
            }
            else
            {
                SqlParameter BranchId = new SqlParameter();
                BranchId.SqlDbType = SqlDbType.VarChar;
                BranchId.Value = ddlrpclocation.SelectedValue.ToString();
                BranchId.ParameterName = "@PMSlocation";
                sqlCom.Parameters.Add(BranchId);
            }

            sqlCon.Open();

            SqlDataAdapter sqlDA = new SqlDataAdapter();
            sqlDA.SelectCommand = sqlCom;

            DataTable dt = new DataTable();
            sqlDA.Fill(dt);

            sqlCon.Close();

            ddlBranchList.DataTextField = "Hub";
            ddlBranchList.DataValueField = "Hub";

            ddlBranchList.DataSource = dt;
            ddlBranchList.DataBind();

            ddlBranchList.Items.Insert(0, new ListItem("--All--", "0"));
            ddlBranchList.SelectedIndex = 0;


        }
        catch (Exception ex)
        {
            lblMessage.Visible = true;
            lblMessage.Text = ex.Message;
            lblMessage.CssClass = "ErrorMessage";
        }
        finally
        {
            sqlCon.Close();
            sqlCon.Dispose();
        }
    }

    private void Get_UserList()
    {

        Object SaveUSERInfo = (Object)Session["UserInfo"];
        SqlConnection sqlCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);

        try
        {

            if (DropDownList1.SelectedValue.ToString() == "BDE")
            {
                proc = "IRPC_GetUserBDEList_SP";
            }
            else if (DropDownList1.SelectedValue.ToString() == "CAM")
            {
                proc = "IRPC_GetUserCAMList_SP";
            }
            else if (DropDownList1.SelectedValue.ToString() == "CPV")
            {
                proc = "IRPC_GetUserCPVList_SP";
            }
            else if (DropDownList1.SelectedValue.ToString() == "Doc_Upload")
            {
                proc = "IRPC_GetUserDOCUploadList_SP";
            }
            else if (DropDownList1.SelectedValue.ToString() == "Bank_Calculation")
            {
                proc = "IRPC_GetUserBankCalList_SP";
            }
            else
            {
                proc = "IRPC_GetUserBDEList_SP";
            }


            SqlCommand sqlCom = new SqlCommand();
            sqlCom.Connection = sqlCon;
            sqlCom.CommandType = CommandType.StoredProcedure;
            sqlCom.CommandText = proc;
            sqlCom.CommandTimeout = 0;




            if (ddlrpclocation.SelectedIndex == 0)
            {
                SqlParameter PMSlocation = new SqlParameter();
                PMSlocation.SqlDbType = SqlDbType.VarChar;
                PMSlocation.Value = Convert.ToString(((UserInfo.structUSERInfo)(SaveUSERInfo)).BranchId);
                PMSlocation.ParameterName = "@PMSlocation";
                sqlCom.Parameters.Add(PMSlocation);
            }
            else
            {
                SqlParameter PMSlocation = new SqlParameter();
                PMSlocation.SqlDbType = SqlDbType.VarChar;
                PMSlocation.Value = ddlrpclocation.SelectedValue.ToString();
                PMSlocation.ParameterName = "@PMSlocation";
                sqlCom.Parameters.Add(PMSlocation);
            }

            sqlCon.Open();

            SqlDataAdapter sqlDA = new SqlDataAdapter();
            sqlDA.SelectCommand = sqlCom;

            DataTable dt = new DataTable();
            sqlDA.Fill(dt);


            sqlCon.Close();

            DropDownList2.DataTextField = "UserName";
            DropDownList2.DataValueField = "UserID";

            DropDownList2.DataSource = dt;
            DropDownList2.DataBind();

            DropDownList2.Items.Insert(0, new ListItem("--Select--", "0"));
            DropDownList2.SelectedIndex = 0;


        }
        catch (Exception ex)
        {
            lblMessage.Visible = true;
            lblMessage.Text = ex.Message;
            lblMessage.CssClass = "ErrorMessage";
        }
        finally
        {
            sqlCon.Close();
            sqlCon.Dispose();
        }
    }

    private void Get_AllPriorityList()
    {
        SqlConnection sqlCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);
        try
        {

            SqlCommand sqlCom = new SqlCommand();
            sqlCom.Connection = sqlCon;
            sqlCom.CommandType = CommandType.StoredProcedure;
            sqlCom.CommandText = "IRPC_GetAllPriorityList_SP";
            sqlCom.CommandTimeout = 0;


            sqlCon.Open();

            SqlDataAdapter sqlDA = new SqlDataAdapter();
            sqlDA.SelectCommand = sqlCom;

            DataTable dt = new DataTable();
            sqlDA.Fill(dt);


            sqlCon.Close();

            ddlPriority.DataTextField = "Priority";
            ddlPriority.DataValueField = "Priority";

            ddlPriority.DataSource = dt;
            ddlPriority.DataBind();

            ddlPriority.Items.Insert(0, new ListItem("--All--", "0"));
            ddlPriority.SelectedIndex = 0;


        }
        catch (Exception ex)
        {
            lblMessage.Visible = true;
            lblMessage.Text = ex.Message;
            lblMessage.CssClass = "ErrorMessage";
        }
        finally
        {
            sqlCon.Close();
            sqlCon.Dispose();
        }
    }

    private void Get_DataForIndexing1()
    {
        Object SaveUSERInfo = (Object)Session["UserInfo"];
        SqlConnection sqlCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);

        try
        {
            string proc;
            if (ddltype.SelectedItem.ToString() == "CAM")
            {
                proc = "IRPC_GetCAMDataSuper1_SP";//"Get_CAMdata_super";
            }
            else if (ddltype.SelectedItem.ToString() == "CPV")
            {
                proc = "IRPC_GetCPVDataSuper1_SP";//"Get_Cpvdata_suer";
            }
            else if (ddltype.SelectedItem.ToString() == "Bank_calculation")
            {
                proc = "IRPC_GetBNKCALDataSuper1_SP";// "Get_BNKCALdata_super";
            }
            else if (ddltype.SelectedItem.ToString() == "DOC_UPLOAD")
            {
                proc = "IRPC_GetDOCUploadData1_SP";//"Get_doc_uploaddata";
            }
            else
            {
                proc = "IRPC_GetBDEData1_SP";
            }



            SqlCommand sqlCom = new SqlCommand();
            sqlCom.Connection = sqlCon;
            sqlCom.CommandType = CommandType.StoredProcedure;
            sqlCom.CommandText = proc;
            sqlCom.CommandTimeout = 0;

            //SqlParameter USERID = new SqlParameter();
            //USERID.SqlDbType = SqlDbType.VarChar;
            //USERID.Value = Convert.ToString(((UserInfo.structUSERInfo)(SaveUSERInfo)).UserId);
            //USERID.ParameterName = "@UserID";
            //sqlCom.Parameters.Add(USERID);

            //SqlParameter GroupID = new SqlParameter();
            //GroupID.SqlDbType = SqlDbType.Int;
            //GroupID.Value = Convert.ToInt32(((UserInfo.structUSERInfo)(SaveUSERInfo)).GroupId);
            //GroupID.ParameterName = "@GroupID";
            //sqlCom.Parameters.Add(GroupID);

            if (ddlrpclocation.SelectedIndex == 0)
            {
                SqlParameter BranchID = new SqlParameter();
                BranchID.SqlDbType = SqlDbType.VarChar;
                BranchID.Value = Convert.ToString(((UserInfo.structUSERInfo)(SaveUSERInfo)).BranchId);
                BranchID.ParameterName = "@BranchID";
                sqlCom.Parameters.Add(BranchID);
            }
            else
            {
                SqlParameter BranchID = new SqlParameter();
                BranchID.SqlDbType = SqlDbType.VarChar;
                BranchID.Value = ddlrpclocation.SelectedValue.ToString();
                BranchID.ParameterName = "@BranchID";
                sqlCom.Parameters.Add(BranchID);
            }

            if (ddlproduct.SelectedIndex != 0)
            {
                SqlParameter Product = new SqlParameter();
                Product.SqlDbType = SqlDbType.VarChar;
                Product.Value = ddlproduct.SelectedValue.ToString();
                Product.ParameterName = "@Product";
                sqlCom.Parameters.Add(Product);
            }
            else
            {
                lblMessage.Text = "Select Product first ...!!!";
                return;
            }


            sqlCon.Open();

            SqlDataAdapter sqlDA = new SqlDataAdapter();
            sqlDA.SelectCommand = sqlCom;

            DataTable dt = new DataTable();
            sqlDA.Fill(dt);

            sqlCon.Close();

            if (dt.Rows.Count > 0)
            {
                grdlos.DataSource = dt;
                grdlos.DataBind();

            }
            else
            {
                grdlos.DataSource = null;
                grdlos.DataBind();
            }
        }

        catch (Exception ex)
        {
            lblMessage.Visible = true;
            lblMessage.Text = "Error :" + ex.Message;
        }
        finally
        {
            sqlCon.Close();
            sqlCon.Dispose();
        }

    }

    private void Get_DataForIndexing()
    {
        Object SaveUSERInfo = (Object)Session["UserInfo"];
        SqlConnection sqlCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);

        try
        {
            string proc;
            if (ddltype.SelectedItem.ToString() == "CAM")
            {
                proc = "IRPC_GetCAMDataSuper_SP";
            }
            else if (ddltype.SelectedItem.ToString() == "CPV")
            {
                proc = "IRPC_GetCPVDataSuper_SP";//"Get_Cpvdata_suer";
            }
            else if (ddltype.SelectedItem.ToString() == "Bank_calculation")
            {
                proc = "IRPC_GetBNKCALDataSuper_SP";
            }
            else if (ddltype.SelectedItem.ToString() == "DOC_UPLOAD")
            {
                proc = "IRPC_GetDOCUploadData_SP";
            }
            else
            {
                proc = "IRPC_GetBDEData_SP";
            }



            SqlCommand sqlCom = new SqlCommand();
            sqlCom.Connection = sqlCon;
            sqlCom.CommandType = CommandType.StoredProcedure;
            sqlCom.CommandText = proc;
            sqlCom.CommandTimeout = 0;

            //SqlParameter USERID = new SqlParameter();
            //USERID.SqlDbType = SqlDbType.VarChar;
            //USERID.Value = Convert.ToString(((UserInfo.structUSERInfo)(SaveUSERInfo)).UserId);
            //USERID.ParameterName = "@UserID";
            //sqlCom.Parameters.Add(USERID);

            //SqlParameter GroupID = new SqlParameter();
            //GroupID.SqlDbType = SqlDbType.Int;
            //GroupID.Value = Convert.ToInt32(((UserInfo.structUSERInfo)(SaveUSERInfo)).GroupId);
            //GroupID.ParameterName = "@GroupID";
            //sqlCom.Parameters.Add(GroupID);

            if (ddlrpclocation.SelectedIndex == 0)
            {
                SqlParameter BranchID = new SqlParameter();
                BranchID.SqlDbType = SqlDbType.VarChar;
                BranchID.Value = Convert.ToString(((UserInfo.structUSERInfo)(SaveUSERInfo)).BranchId);
                BranchID.ParameterName = "@BranchID";
                sqlCom.Parameters.Add(BranchID);
            }
            else
            {
                SqlParameter BranchID = new SqlParameter();
                BranchID.SqlDbType = SqlDbType.VarChar;
                BranchID.Value = ddlrpclocation.SelectedValue.ToString();
                BranchID.ParameterName = "@BranchID";
                sqlCom.Parameters.Add(BranchID);
            }




            sqlCon.Open();

            SqlDataAdapter sqlDA = new SqlDataAdapter();
            sqlDA.SelectCommand = sqlCom;

            DataTable dt = new DataTable();
            sqlDA.Fill(dt);

            sqlCon.Close();

            if (dt.Rows.Count > 0)
            {
                grdlos.DataSource = dt;
                grdlos.DataBind();

            }
            else
            {
                grdlos.DataSource = null;
                grdlos.DataBind();
            }
        }

        catch (Exception ex)
        {
            lblMessage.Visible = true;
            lblMessage.Text = "Error :" + ex.Message;
        }
        finally
        {
            sqlCon.Close();
            sqlCon.Dispose();
        }

    }
    protected void ddltype_SelectedIndexChanged(object sender, EventArgs e)
    {
        Get_DataForIndexing();
    }

    protected void lnkClose_Click(object sender, EventArgs e)
    {
    }

    private void Sp_Assign_LOSTODDE()
    {
        Object SaveUSERInfo = (Object)Session["UserInfo"];
        using (SqlConnection sqlCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]))
        {
            try
            {
                SqlCommand sqlCom = new SqlCommand();
                sqlCom.Connection = sqlCon;
                sqlCom.CommandType = CommandType.StoredProcedure;
                sqlCom.CommandText = "IRPC_GET_LOS_SP";
                sqlCom.CommandTimeout = 0;

                SqlDataAdapter sqlDA = new SqlDataAdapter();
                sqlDA.SelectCommand = sqlCom;

                DataTable dt = new DataTable();
                sqlDA.Fill(dt);

                string los_no = dt.Rows[0]["LOSNo"].ToString();

                SqlCommand sqlCom1 = new SqlCommand();
                sqlCom1.Connection = sqlCon;
                sqlCom1.CommandType = CommandType.StoredProcedure;
                sqlCom1.CommandText = "IRPC_Find_Free_DDE_SP";
                sqlCom1.CommandTimeout = 0;

                SqlDataAdapter sqlDA1 = new SqlDataAdapter();
                sqlDA1.SelectCommand = sqlCom1;

                DataTable dt1 = new DataTable();
                sqlDA1.Fill(dt1);

                string Assignto = dt1.Rows[0]["Assignto"].ToString();

                SqlCommand sqlCom2 = new SqlCommand();
                sqlCom2.Connection = sqlCon;
                sqlCom2.CommandType = CommandType.StoredProcedure;
                sqlCom2.CommandText = "IRPC_Assign_LOS_To_DDE_SP";
                sqlCom2.CommandTimeout = 0;

                SqlDataAdapter sqlDA2 = new SqlDataAdapter();
                sqlDA2.SelectCommand = sqlCom2;

                SqlParameter Assign_to = new SqlParameter();
                Assign_to.SqlDbType = SqlDbType.VarChar;
                Assign_to.Value = Assignto;
                Assign_to.ParameterName = "@Assign_to";
                sqlCom2.Parameters.Add(Assign_to);

                SqlParameter LOSNo = new SqlParameter();
                LOSNo.SqlDbType = SqlDbType.VarChar;
                LOSNo.Value = los_no;
                LOSNo.ParameterName = "@LOSNo";
                sqlCom2.Parameters.Add(LOSNo);

                sqlCon.Open();

                int SqlRow = 0;
                SqlRow = sqlCom2.ExecuteNonQuery();

                sqlCon.Close();

                if (SqlRow > 0)
                {
                }
            }
            catch (Exception ex)
            {
                lblMessage.Visible = true;
                lblMessage.Text = "Error :" + ex.Message;
            }
            finally
            {
                sqlCon.Close();
                sqlCon.Dispose();
            }

        }
    }

    protected void btncancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Pages/Menu.aspx", true);
    }

    protected void ddlBranchList_SelectedIndexChanged(object sender, EventArgs e)
    {
        Get_DataForIndexing();
        lblMessage.Text = "";
        DropDownList1.BackColor = System.Drawing.Color.FromName("White");
        DropDownList2.BackColor = System.Drawing.Color.FromName("White");
    }

    protected void ddlPriority_SelectedIndexChanged(object sender, EventArgs e)
    {
        Get_DataForIndexing();
        lblMessage.Text = "";
        DropDownList1.BackColor = System.Drawing.Color.FromName("White");
        DropDownList2.BackColor = System.Drawing.Color.FromName("White");
    }

    protected void BtnAssign_Click(object sender, EventArgs e)
    {
        Object SaveUSERInfo = (Object)Session["UserInfo"];
        SqlConnection sqlCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);

        try
        {
            if (DropDownList1.SelectedIndex.ToString() != "0")
            {
                if (DropDownList2.SelectedIndex.ToString() != "0")
                {
                    for (int i = 0; i <= grdlos.Rows.Count - 1; i++)
                    {

                        CheckBox chkSelect = (CheckBox)grdlos.Rows[i].FindControl("chkSelect");
                        LinkButton WIP = (LinkButton)grdlos.Rows[i].FindControl("lnkWIP");
                        HdnUID.Value = grdlos.Rows[i].Cells[1].Text.Trim();

                        if (chkSelect.Checked == true)
                        {
                            if (DropDownList1.SelectedValue.ToString() == "BDE")
                            {
                                proc = "IRPC_Assign_BDE_Manual_SP";
                            }
                            else if (DropDownList1.SelectedValue.ToString() == "CAM")
                            {
                                proc = "IRPC_Assign_CAM_Manual_SP";
                            }
                            else if (DropDownList1.SelectedValue.ToString() == "Bank_Calculation")
                            {
                                proc = "IRPC_Assign_BankCal_Useranual_SP";
                            }
                            else if (DropDownList1.SelectedValue.ToString() == "Doc_Upload")
                            {
                                proc = "IRPC_Assign_DOC_Upload_Manual_SP";
                            }
                            else
                            {
                                proc = "IRPC_Assign_CPU_Manual_SP";
                            }

                            SqlCommand sqlCom = new SqlCommand();
                            sqlCom.Connection = sqlCon;
                            sqlCom.CommandType = CommandType.StoredProcedure;
                            sqlCom.CommandText = proc;
                            sqlCom.CommandTimeout = 0;

                            SqlParameter UserID = new SqlParameter();
                            UserID.SqlDbType = SqlDbType.VarChar;
                            UserID.Value = DropDownList2.SelectedValue.ToString();
                            UserID.ParameterName = "@User_ID";
                            sqlCom.Parameters.Add(UserID);

                            SqlParameter LOSNo = new SqlParameter();
                            LOSNo.SqlDbType = SqlDbType.VarChar;
                            LOSNo.Value = HdnUID.Value;
                            LOSNo.ParameterName = "@LOSNo";
                            sqlCom.Parameters.Add(LOSNo);

                            sqlCon.Open();

                            int K = 0;
                            K = sqlCom.ExecuteNonQuery();

                            sqlCon.Close();

                            if (K > 0)
                            {
                                lblMessage.Text = "LOS Assign To :" + DropDownList1.SelectedValue.ToString() + " : " + DropDownList2.SelectedItem.ToString();
                                DropDownList1.BackColor = System.Drawing.Color.FromName("White");
                                DropDownList2.BackColor = System.Drawing.Color.FromName("White");
                            }
                            else
                            {
                                lblMessage.Text = "LOS Already In Process";

                                DropDownList1.BackColor = System.Drawing.Color.FromName("White");
                                DropDownList2.BackColor = System.Drawing.Color.FromName("White");
                            }
                        }
                        else
                        {
                            DropDownList1.BackColor = System.Drawing.Color.FromName("White");
                        }
                    }
                }
                else
                {
                    lblMessage.Text = "Please Select Atleast One Record & User...!!!";
                    DropDownList1.BackColor = System.Drawing.Color.FromName("yellow");
                }
            }
            else
            {
                lblMessage.Text = "Please Select Atleast One Record & Type...!!!";
                DropDownList1.BackColor = System.Drawing.Color.FromName("yellow");
            }
            Get_DataForIndexing();
        }
        catch (Exception ex)
        {
            lblMessage.Visible = true;
            lblMessage.Text = "Error :" + ex.Message;
        }
        finally
        {
            sqlCon.Close();
            sqlCon.Dispose();
        }

    }

    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        Get_UserList();
        DropDownList1.BackColor = System.Drawing.Color.FromName("White");
        DropDownList2.BackColor = System.Drawing.Color.FromName("Yellow");
        lblMessage.Text = "Please Select Atleast One Record & User...!!!";
    }

    protected void btndiscripant_Click(object sender, EventArgs e)
    {
        Object SaveUSERInfo = (Object)Session["UserInfo"];
        SqlConnection sqlCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);
        try
        {

            for (int i = 0; i <= grdlos.Rows.Count - 1; i++)
            {
                CheckBox chkSelect = (CheckBox)grdlos.Rows[i].FindControl("chkSelect");
                HdnUID.Value = grdlos.Rows[i].Cells[1].Text.Trim();
                if (chkSelect.Checked == true)
                {

                    SqlCommand sqlCom2 = new SqlCommand();
                    sqlCom2.Connection = sqlCon;
                    sqlCom2.CommandType = CommandType.StoredProcedure;
                    sqlCom2.CommandText = "IRPC_LOS_Discripant_SP";
                    sqlCom2.CommandTimeout = 0;

                    SqlDataAdapter sqlDA2 = new SqlDataAdapter();
                    sqlDA2.SelectCommand = sqlCom2;

                    SqlParameter LOSNo = new SqlParameter();
                    LOSNo.SqlDbType = SqlDbType.VarChar;
                    LOSNo.Value = HdnUID.Value;
                    LOSNo.ParameterName = "@LOSNo";
                    sqlCom2.Parameters.Add(LOSNo);

                    sqlCon.Open();

                    int SqlRow = 0;
                    SqlRow = sqlCom2.ExecuteNonQuery();

                    sqlCon.Close();

                    if (SqlRow > 0)
                    {
                    }
                }
                else
                {
                }

            }
            Get_DataForIndexing();
        }
        catch (Exception ex)
        {
            lblMessage.Visible = true;
            lblMessage.Text = "Error :" + ex.Message;
        }
        finally
        {
            sqlCon.Close();
            sqlCon.Dispose();
        }
    }

    private void Generate_ExcelFile()
    {
        String attachment = "attachment; filename=MIS.xls";
        Response.ClearHeaders();
        Response.ClearContent();
        Response.Clear();

        Response.AddHeader("content-disposition", attachment);
        Response.ContentType = "application/ms-excel";

        StringWriter sw = new System.IO.StringWriter();
        HtmlTextWriter htw = new HtmlTextWriter(sw);
        Table tblSpace = new Table();
        TableRow tblRow = new TableRow();
        TableCell tblCell = new TableCell();
        tblCell.Text = " ";

        TableRow tblRow1 = new TableRow();
        TableCell tblCell1 = new TableCell();
        tblCell1.ColumnSpan = 20;// 10;
        tblCell1.CssClass = "SuccessMessage";
        tblRow.Cells.Add(tblCell);
        tblRow1.Cells.Add(tblCell1);
        tblRow.Height = 20;
        tblSpace.Rows.Add(tblRow);
        tblSpace.Rows.Add(tblRow1);
        tblSpace.RenderControl(htw);

        Table tbl = new Table();
        grdlos.EnableViewState = false;
        grdlos.GridLines = GridLines.Both;
        tbl.RenderControl(htw);
        Response.Write(sw.ToString());
        Response.End();
    }

    protected void btnExport_Click(object sender, EventArgs e)
    {
        Get_DataForIndexing2();
        Genrate_Exel2();
    }
    private void Genrate_Exel2()
    {
        String attachment = "attachment; filename=" + ddltype.SelectedItem.ToString() + ".xls";
        Response.AddHeader("content-disposition", attachment);
        Response.ContentType = "application/ms-excel";
        StringWriter sw = new System.IO.StringWriter();
        HtmlTextWriter htw = new HtmlTextWriter(sw);
        Table tblSpace = new Table();
        TableRow tblRow = new TableRow();
        TableCell tblCell = new TableCell();
        tblCell.Text = " ";
        tblCell.ColumnSpan = 10;// 10;
        tblCell.Text = "<b> <font size='2' color='blue'>PAMAC FINSERVE PVT. LTD.</font></span></b> <br/>";
        tblCell.CssClass = "SuccessMessage";
        TableRow tblRow1 = new TableRow();
        TableCell tblCell1 = new TableCell();
        tblCell1.ColumnSpan = 20;// 10;
        tblCell1.CssClass = "SuccessMessage";
        tblRow.Cells.Add(tblCell);
        tblRow1.Cells.Add(tblCell1);
        tblRow.Height = 20;
        tblSpace.Rows.Add(tblRow);
        tblSpace.Rows.Add(tblRow1);
        tblSpace.RenderControl(htw);

        Table tbl1 = new Table();
        gvExportReport.EnableViewState = false;
        gvExportReport.GridLines = GridLines.Both;
        tbExport.RenderControl(htw);
        Response.Write(sw.ToString());

        Response.End();
        Response.Write(sw.ToString());
    }

    protected void Btnchangerpc_Click(object sender, EventArgs e)
    {
        Object SaveUSERInfo = (Object)Session["UserInfo"];
        SqlConnection sqlCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);
        try
        {
            if (ddlrpclocation.SelectedIndex.ToString() != "0")
            {
                for (int i = 0; i <= grdlos.Rows.Count - 1; i++)
                {

                    CheckBox chkSelect = (CheckBox)grdlos.Rows[i].FindControl("chkSelect");
                    LinkButton WIP = (LinkButton)grdlos.Rows[i].FindControl("lnkWIP");
                    HdnUID.Value = grdlos.Rows[i].Cells[1].Text.Trim();

                    if (chkSelect.Checked == true)
                    {
                        SqlCommand sqlCom1 = new SqlCommand();
                        sqlCom1.Connection = sqlCon;
                        sqlCom1.CommandType = CommandType.StoredProcedure;
                        sqlCom1.CommandText = "IRPC_Update_RPCLocation_ICICI_SP";
                        sqlCom1.CommandTimeout = 0;

                        SqlParameter Rpclocation = new SqlParameter();
                        Rpclocation.SqlDbType = SqlDbType.VarChar;
                        Rpclocation.Value = ddlchngrpc.SelectedValue.ToString();
                        Rpclocation.ParameterName = "@Rpclocation";
                        sqlCom1.Parameters.Add(Rpclocation);

                        SqlParameter LOSNo1 = new SqlParameter();
                        LOSNo1.SqlDbType = SqlDbType.VarChar;
                        LOSNo1.Value = HdnUID.Value;
                        LOSNo1.ParameterName = "@LOSNo";
                        sqlCom1.Parameters.Add(LOSNo1);

                        sqlCon.Open();

                        int SqlRow = 0;
                        SqlRow = sqlCom1.ExecuteNonQuery();

                        sqlCon.Close();
                    }
                }
                Get_DataForIndexing();
            }
            else
            {
                lblMessage.Text = "Please Select RPC Location !!!";
            }
        }
        catch (Exception ex)
        {
            lblMessage.Visible = true;
            lblMessage.Text = "Error :" + ex.Message;
        }
        finally
        {
            sqlCon.Close();
            sqlCon.Dispose();
        }
    }

    protected void ddlrpclocation_SelectedIndexChanged(object sender, EventArgs e)
    {
        Get_DataForIndexing();
        Get_BranchList();
    }

    private void Genrate_Exel1()
    {
        String attachment = "attachment; filename=" + ddltype.SelectedItem.ToString() + ".xls";
        Response.AddHeader("content-disposition", attachment);
        Response.ContentType = "application/ms-excel";
        StringWriter sw = new System.IO.StringWriter();
        HtmlTextWriter htw = new HtmlTextWriter(sw);
        Table tblSpace = new Table();
        TableRow tblRow = new TableRow();
        TableCell tblCell = new TableCell();
        tblCell.Text = " ";
        tblCell.ColumnSpan = 10;// 10;
        tblCell.Text = "<b> <font size='2' color='blue'>PAMAC FINSERVE PVT. LTD.</font></span></b> <br/>";
        tblCell.CssClass = "SuccessMessage";
        TableRow tblRow1 = new TableRow();
        TableCell tblCell1 = new TableCell();
        tblCell1.ColumnSpan = 20;// 10;
        tblCell1.CssClass = "SuccessMessage";
        tblRow.Cells.Add(tblCell);
        tblRow1.Cells.Add(tblCell1);
        tblRow.Height = 20;
        tblSpace.Rows.Add(tblRow);
        tblSpace.Rows.Add(tblRow1);
        tblSpace.RenderControl(htw);

        Table tbl1 = new Table();
        grdlos.EnableViewState = false;
        grdlos.GridLines = GridLines.Both;
        tbExport.RenderControl(htw);
        Response.Write(sw.ToString());

        Response.End();
        Response.Write(sw.ToString());
    }

    public override void VerifyRenderingInServerForm(Control control)
    {
    }
    private void Get_DataForIndexing2()
    {
        Object SaveUSERInfo = (Object)Session["UserInfo"];
        SqlConnection sqlCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);
        try
        {
            string proc;
            if (ddltype.SelectedItem.ToString() == "CAM")
            {
                //proc = "LOSCompleteMISDDE_12";//origianl
                //proc = "LOSCompleteMISDDE";
                proc = "IRPC_GetCAMDataSuper_SP";
            }
            else if (ddltype.SelectedItem.ToString() == "CPV")
            {
                proc = "IRPC_GetCPVDataSuper_SP";
            }
            else
            {
                //proc = "LOSCompleteMISINDEXER";
                proc = "IRPC_GetBDEData_SP";
            }


            SqlCommand sqlCom = new SqlCommand();
            sqlCom.Connection = sqlCon;
            sqlCom.CommandType = CommandType.StoredProcedure;
            sqlCom.CommandText = proc;
            sqlCom.CommandTimeout = 0;



            if (ddlrpclocation.SelectedIndex == 0)
            {
                SqlParameter BranchID = new SqlParameter();
                BranchID.SqlDbType = SqlDbType.VarChar;
                BranchID.Value = Convert.ToString(((UserInfo.structUSERInfo)(SaveUSERInfo)).BranchId);
                BranchID.ParameterName = "@BranchID";
                sqlCom.Parameters.Add(BranchID);
            }
            else
            {
                SqlParameter BranchID = new SqlParameter();
                BranchID.SqlDbType = SqlDbType.VarChar;
                BranchID.Value = ddlrpclocation.SelectedValue.ToString();
                BranchID.ParameterName = "@BranchID";
                sqlCom.Parameters.Add(BranchID);
            }




            sqlCon.Open();

            SqlDataAdapter sqlDA = new SqlDataAdapter();
            sqlDA.SelectCommand = sqlCom;

            DataTable dt = new DataTable();
            sqlDA.Fill(dt);

            sqlCon.Close();

            if (dt.Rows.Count > 0)
            {
                gvExportReport.DataSource = dt;
                gvExportReport.DataBind();
            }
            else
            {
                gvExportReport.DataSource = null;
                gvExportReport.DataBind();
            }
        }
        catch (Exception ex)
        {
            lblMessage.Visible = true;
            lblMessage.Text = "Error :" + ex.Message;
        }
        finally
        {
            sqlCon.Close();
            sqlCon.Dispose();
        }

    }


    protected void ddlproduct_SelectedIndexChanged(object sender, EventArgs e)
    {
        Get_DataForIndexing1();
    }



    protected void grdlos_RowDataBound1(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string input = "";
                string StrProduct = "";
                try
                {
                    input = e.Row.Cells[8].Text;
                    DateTime asd = Convert.ToDateTime(input);
                    StrProduct = e.Row.Cells[9].Text;
                }
                catch
                {
                    input = e.Row.Cells[8].Text;
                    StrProduct = e.Row.Cells[9].Text;
                }

                string input12 = ddltype.SelectedValue.ToString(); // dropdown select index

                string Inputdate = Convert.ToDateTime(input).Date.ToString("MM/dd/yyyy");

                string Todaydate = System.DateTime.Now.Date.ToString();

                DateTime InDate = Convert.ToDateTime(Inputdate);
                DateTime Toddate = Convert.ToDateTime(Todaydate);

                int Timesapn = InDate.CompareTo(Toddate);


                if (Timesapn == 0)
                {




                    string InputTime = Convert.ToDateTime(input).TimeOfDay.ToString();//ToString("hh:mm:ss");

                    string CurrentTime = System.DateTime.Now.TimeOfDay.ToString();// ("hh:mm:ss");

                    DateTime InputTime1 = Convert.ToDateTime(InputTime);
                    DateTime Currenttime1 = Convert.ToDateTime(CurrentTime);

                    TimeSpan diffTime = Currenttime1.Subtract(InputTime1);

                    if (input12 == "IRPC_GetBDEData_SP")
                    {
                        if (input12 == "IRPC_GetBDEData_SP")//bde stored procedure
                        {
                            if (StrProduct == "AL")
                            {
                                if (diffTime.Hours >= 1)
                                {
                                    e.Row.ForeColor = Color.FromName("green");
                                }
                                else
                                {
                                    e.Row.ForeColor = Color.FromName("black");
                                }
                            }
                            else if (StrProduct == "PL")
                            {
                                if (diffTime.Hours >= 1)
                                {
                                    e.Row.ForeColor = Color.FromName("green");
                                }
                                else
                                {
                                    e.Row.ForeColor = Color.FromName("black");
                                }
                            }
                            else if (StrProduct == "HL")
                            {

                                if (Convert.ToInt32(diffTime.Hours) >= 2)
                                {
                                    e.Row.ForeColor = Color.FromName("green");
                                }
                                else if (Convert.ToInt32(diffTime.Hours) >= 1)
                                {
                                    if (Convert.ToInt32(diffTime.Minutes) > 30)
                                    {
                                        e.Row.ForeColor = Color.FromName("green");
                                    }

                                }
                                else
                                {
                                    e.Row.ForeColor = Color.FromName("black");
                                }
                            }
                            else
                            {
                                e.Row.ForeColor = Color.FromName("red");
                            }
                        }
                    }
                    if (input12 == "IRPC_GetCAMDataSuper_SP")
                    {

                        if (input12 == "IRPC_GetCAMDataSuper_SP")//cam stored procedure
                        {
                            if (StrProduct == "PL")
                            {
                                if (diffTime.Hours >= 1)
                                {
                                    e.Row.ForeColor = Color.FromName("green");
                                }
                                else
                                {
                                    e.Row.ForeColor = Color.FromName("black");
                                }
                            }
                            else if (StrProduct == "AL")
                            {
                                if (diffTime.Hours == 0)
                                {
                                    if (Convert.ToInt32( diffTime.Minutes) >= 30)
                                    {
                                        e.Row.ForeColor = Color.FromName("green");
                                    }
                                }
                                else if (Convert.ToInt32(diffTime.Hours) >= 1)
                                {
                                    e.Row.ForeColor = Color.FromName("green");
                                }
                                else
                                {
                                    e.Row.ForeColor = Color.FromName("black");
                                }
                            }
                            else
                            {
                                e.Row.ForeColor = Color.FromName("red");
                            }
                        }
                    }
                    //if (input12 == "Get_Cpvdata_suer")
                    //{
                    //    if (input12 == "Get_Cpvdata_suer")//cpv peocedure
                    //    {
                    //        //if (diffTime.Hours >= 2)
                    //        //{
                    //        //    e.Row.ForeColor = Color.FromName("green");
                    //        //}
                    //        //else
                    //        //{
                    //        e.Row.ForeColor = Color.FromName("black");
                    //        //}
                    //    }
                    //}


                    if (input12 == "IRPC_GetBNKCALDataSuper_SP")//Bank Calculations
                    {
                        if (StrProduct == "AL")
                        {
                            if (Convert.ToInt32(diffTime.Hours) > 1)
                            {
                                e.Row.ForeColor = Color.FromName("green");
                            }
                            else if (Convert.ToInt32(diffTime.Hours) >= 1)
                            {
                                if (diffTime.Minutes >= 30)
                                {
                                    e.Row.ForeColor = Color.FromName("green");
                                }
                            }

                            else
                            {
                                e.Row.ForeColor = Color.FromName("black");
                            }
                        }
                        else
                        {
                            e.Row.ForeColor = Color.FromName("black");
                        }


                    }

                    if (input12 == "IRPC_GetDOCUploadData_SP")
                    {
                        if (input12 == "IRPC_GetDOCUploadData_SP")//Doc Upload
                        {
                            if (StrProduct == "AL")
                            {
                                if (diffTime.Hours >= 0 && diffTime.Minutes >= 30)
                                {
                                    e.Row.ForeColor = Color.FromName("green");
                                }
                                else if (diffTime.Hours > 0)
                                {
                                    e.Row.ForeColor = Color.FromName("green");
                                }
                                else
                                {
                                    e.Row.ForeColor = Color.FromName("black");
                                }
                            }
                            else
                            {
                                e.Row.ForeColor = Color.FromName("black");
                            }
                        }
                    }


                }
                else
                {
                    if (input12 == "IRPC_GetCPVDataSuper_SP")
                    {
                        if (input12 == "IRPC_GetCPVDataSuper_SP")//cpv peocedure
                        {
                            //if (diffTime.Hours >= 2)
                            //{
                            //    e.Row.ForeColor = Color.FromName("green");
                            //}
                            //else
                            //{
                            e.Row.ForeColor = Color.FromName("black");
                            //}
                        }
                    }
                    else
                    {
                        e.Row.ForeColor = Color.FromName("green");
                    }
                }



            }
        }
        catch (Exception ex)
        {
            //lblMessage.Visible = true;
            //lblMessage.Text = "Error :" + ex.Message;
        }

    }

}

