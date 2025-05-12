using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.IO;
using System.Drawing;

public partial class Pages_TCFSL_CDLOAN_Superadmin : System.Web.UI.Page
{
    string proc;
    string flagstage = "";
    //SingleUserLogin Login = new SingleUserLogin();
    protected void Page_Load(object sender, EventArgs e)
    {
        Object SaveUSERInfo = (Object)Session["UserInfo"];
        SqlConnection sqlCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);

        if (Session["UserInfo"] == null)
        {
            Response.Redirect("~/Pages/Logout.aspx");

            Response.AppendHeader("Refresh", "2");
        }
        //Login.ValidateTokenLoginDetails();
        if (!IsPostBack)
        {
            //Get_DataForTCFSL();
            //GetUserList();

            BindLocation();
            BindAppType();
        }
    }
    protected void BindLocation()
    {
        SqlConnection sqlCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);

        SqlCommand cmd = new SqlCommand("TCFSL_MasterSearchCode_SP", sqlCon);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@Types", "LocationType");
        cmd.Parameters.AddWithValue("@Level", 1);
        SqlDataAdapter adp = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        adp.Fill(ds);

        if (ds != null && ds.Tables[0].Rows.Count > 0)
        {
            ddllocation.DataSource = ds;
            ddllocation.DataValueField = "Code_Id";
            ddllocation.DataTextField = "Description";
            ddllocation.DataBind();
            ddllocation.Items.Insert(0, new ListItem("--Select--", "0"));
        }
    }
    protected void BindAppType()
    {
        SqlConnection sqlCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);

        SqlCommand cmd = new SqlCommand("TCFSL_MasterSearchCode_SP", sqlCon);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@Types", "AppType");
        cmd.Parameters.AddWithValue("@Level", 1);
        SqlDataAdapter adp = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        adp.Fill(ds);

        if (ds != null && ds.Tables[0].Rows.Count > 0)
        {
            ddlapptyp.DataSource = ds;
            ddlapptyp.DataValueField = "Code_Id";
            ddlapptyp.DataTextField = "Description";
            ddlapptyp.DataBind();
            ddlapptyp.Items.Insert(0, new ListItem("--Select--", "0"));
        }
    }

    protected void ddlQueue_SelectedIndexChanged(object sender, EventArgs e)
    {
        Get_DataForTCFSL();
        GetUserList();
    }
    private void Get_DataForTCFSL()
    {
        Object SaveUSERInfo = (Object)Session["UserInfo"];
        SqlConnection sqlCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);

        try
        {
            string proc;


            if (ddlQueue.SelectedItem.ToString() == "Author Hold")
            {
                proc = "TCFSL_Get_All_Data_Author_RJ1_SP";
            }

            else if (ddlQueue.SelectedItem.ToString() == "Author")
            {
                proc = "TCFSL_USP_Get_All_Data_Author1_SP";

            }
            else if (ddlQueue.SelectedItem.ToString() == "Maker Hold")
            {
                proc = "TCFSL_Get_All_Data_MakerRJ1_SP";

            }
            else if (ddlQueue.SelectedItem.ToString() == "Maker")
            {
                proc = "TCFSL_Get_All_Data_Maker1_SP";

            }
            //else if (ddlQueue.SelectedItem.ToString() == "Screening Reject")
            //{
            //    proc = "sp_getalldata_ScreeningRJ1";

            //}
            //added
            else if (ddlQueue.SelectedItem.ToString() == "Screening QC")
            {
                proc = "TCFSL_USP_GetAllData_Screening1_15052018_SP";//uspGetalldata_ScreeningQC

            }
            else if (ddlQueue.SelectedItem.ToString() == "Screening QC Hold")
            {
                proc = "TCFSL_GetAllData_Screening_Hold1_SP";//uspGetalldata_ScreeningHoldQC

            }
            else if (ddlQueue.SelectedItem.ToString() == "Pending For Finone")
            {
                proc = "TCFSL_Get_All_Data_Screening_PendingQC_SP";

            }//added
            else if (ddlQueue.SelectedItem.ToString() == "Screening Hold")
            {
                proc = "TCFSL_GetAllData_Screening_Hold1_SP";

            }
            //else if (ddlQueue.SelectedItem.ToString() == "Pending For Finone")
            //{
            //    proc = "sp_getalldata_ScreeningPending1";

            //}//added
            else
            {
                proc = "";//uspGetalldata_Screening1

            }


            SqlCommand sqlCom = new SqlCommand();
            sqlCom.Connection = sqlCon;
            sqlCom.CommandType = CommandType.StoredProcedure;
            sqlCom.CommandText = proc;
            sqlCom.CommandTimeout = 0;

            if (ddllocation.SelectedIndex == 0)
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
                BranchID.Value = ddllocation.SelectedValue.ToString();
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


                ViewState["dirState"] = dt;
                ViewState["sortdr"] = "Asc";


                lblCount.Text = "Total cases count is" + " : " + Convert.ToString(dt.Rows.Count);
                lblCount.Visible = true;

            }
            else
            {
                grdlos.DataSource = null;
                grdlos.DataBind();
            }
        }
        catch (Exception ex)
        {
            hiddenResult.Value = "Error :" + ex.Message;
            return;
        }
        finally
        {
            sqlCon.Close();
            sqlCon.Dispose();
        }


    }
    protected void btnExport_Click(object sender, EventArgs e)
    {
        Get_DataForTCFSL1();
    }
    private void Get_DataForTCFSL1()
    {
        Object SaveUSERInfo = (Object)Session["UserInfo"];
        SqlConnection sqlCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);

        try
        {



            if (ddlQueue.SelectedItem.ToString() == "Author Hold")
            {
                proc = "TCFSL_Get_All_Data_Author_RJ1_SP";
            }

            else if (ddlQueue.SelectedItem.ToString() == "Author")
            {
                proc = "TCFSL_USP_Get_All_Data_Author1_SP";

            }
            else if (ddlQueue.SelectedItem.ToString() == "Maker Hold")
            {
                proc = "TCFSL_Get_All_Data_MakerRJ1_SP";

            }
            else if (ddlQueue.SelectedItem.ToString() == "Maker")
            {
                proc = "TCFSL_Get_All_Data_Maker1_SP";

            }

            else if (ddlQueue.SelectedItem.ToString() == "Screening QC")
            {
                proc = "TCFSL_USP_GetAllData_Screening1_15052018_SP";//uspGetalldata_ScreeningQC

            }
            else if (ddlQueue.SelectedItem.ToString() == "Screening QC Hold")
            {
                proc = "TCFSL_GetAllData_Screening_Hold1_SP";//uspGetalldata_ScreeningHoldQC

            }
            else if (ddlQueue.SelectedItem.ToString() == "Pending For Finone")
            {
                proc = "TCFSL_Get_All_Data_Screening_PendingQC_SP";

            }//added
            else if (ddlQueue.SelectedItem.ToString() == "Screening Hold")
            {
                proc = "TCFSL_GetAllData_Screening_Hold1_SP";

            }

            else
            {
                proc = "TCFSL_Get_All_Data_Screening1_SP";

            }


            SqlCommand sqlCom = new SqlCommand();
            sqlCom.Connection = sqlCon;
            sqlCom.CommandType = CommandType.StoredProcedure;
            sqlCom.CommandText = proc;
            sqlCom.CommandTimeout = 0;

            if (ddllocation.SelectedIndex == 0)
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
                BranchID.Value = ddllocation.SelectedValue.ToString();
                BranchID.ParameterName = "@BranchID";
                sqlCom.Parameters.Add(BranchID);
            }

            sqlCon.Open();

            SqlDataAdapter sqlDA = new SqlDataAdapter();
            sqlDA.SelectCommand = sqlCom;

            DataTable ds = new DataTable();
            sqlDA.Fill(ds);

            sqlCon.Close();

            if (ds.Rows.Count > 0)
            {

                string filename = ddlQueue.SelectedItem.ToString() + ".xls";
                System.IO.StringWriter tw = new System.IO.StringWriter();
                System.Web.UI.HtmlTextWriter hw = new System.Web.UI.HtmlTextWriter(tw);
                DataGrid dgGrid = new DataGrid();
                dgGrid.DataSource = ds;
                dgGrid.DataBind();

                //Get the HTML for the control.
                dgGrid.RenderControl(hw);
                //Write the HTML back to the browser.
                Response.ContentType = "application/vnd.ms-excel";
                Response.AppendHeader("Content-Disposition", "attachment; filename=" + filename + "");
                this.EnableViewState = false;
                Response.Write(tw.ToString());
                Response.End();

            }
            else
            {
                grdlos.DataSource = null;
                grdlos.DataBind();
            }
        }
        catch (Exception ex)
        {
            hiddenResult.Value = "Error :" + ex.Message;
            return;
        }
        finally
        {
            sqlCon.Close();
            sqlCon.Dispose();
        }


    }
    public void GetUserList()
    {
        Object SaveUSERInfo = (Object)Session["UserInfo"];
        SqlConnection sqlCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);
        try
        {
            //if ((ddlQueue.SelectedItem.Text == "Screening") || (ddlQueue.SelectedItem.Text == "Screening Hold") || (ddlQueue.SelectedItem.Text == "Pending For Finone"))
            //{
            //    ddlUserlist.Enabled = true;
            //    proc = "GetuserlistSCREEN";
            //}
            //else if ((ddlQueue.SelectedItem.Text == "Screening Reject"))
            //{
            //    ddlUserlist.Enabled = false;
            //    return;
            //}
            //    //added
            //else 
            if ((ddlQueue.SelectedItem.Text == "Screening QC") || (ddlQueue.SelectedItem.Text == "Screening QC Hold") || (ddlQueue.SelectedItem.Text == "Pending For Finone"))
            {
                ddlUserlist.Enabled = true;
                proc = "TCFSL_GetUserList_Screen_QC_23082019_SP";//GetuserlistSCREENQC
            } //added
            else if ((ddlQueue.SelectedItem.Text == "Maker") || (ddlQueue.SelectedItem.Text == "Maker Hold"))
            {
                ddlUserlist.Enabled = true;
                proc = "TCFSL_Get_UserList_MAKER_23082019_SP";
            }
            //else if ((ddlQueue.SelectedItem.Text == "Author") || (ddlQueue.SelectedItem.Text == "Author Hold"))
            //{
            //    proc = "";
            //}
            else
            {
                ddlUserlist.Enabled = true;
                proc = "TCFSL_GetUserList_Author_23082019_SP";
            }
            SqlCommand sqlCom = new SqlCommand();
            sqlCom.Connection = sqlCon;
            sqlCom.CommandType = CommandType.StoredProcedure;
            sqlCom.CommandText = proc;
            sqlCom.CommandTimeout = 0;

            SqlParameter BranchID = new SqlParameter();
            BranchID.SqlDbType = SqlDbType.VarChar;
            BranchID.Value = ddllocation.SelectedValue.ToString();
            BranchID.ParameterName = "@PMSlocation";
            sqlCom.Parameters.Add(BranchID);

            sqlCon.Open();

            SqlDataAdapter sqlDA = new SqlDataAdapter();
            sqlDA.SelectCommand = sqlCom;

            DataTable dt = new DataTable();
            sqlDA.Fill(dt);

            sqlCon.Close();

            if (dt.Rows.Count > 0)
            {

                ddlUserlist.DataTextField = "username";
                ddlUserlist.DataValueField = "userid";
                ddlUserlist.DataSource = dt;
                ddlUserlist.DataBind();

                ddlUserlist.Items.Insert(0, "--Select--");
                ddlUserlist.SelectedIndex = 0;
            }
            else
            {
                ddlUserlist.Items.Clear();
                ddlUserlist.DataSource = null;
                ddlUserlist.DataBind();

                ddlUserlist.Items.Insert(0, "--Select--");
                ddlUserlist.SelectedIndex = 0;
            }
        }

        catch (Exception ex)
        {
            hiddenResult.Value = ex.Message;

        }


    }
    protected void btnsumbit_Click(object sender, EventArgs e)
    {
        Object SaveUSERInfo = (Object)Session["UserInfo"];
        SqlConnection sqlCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);

        try
        {
            if (ddlUserlist.SelectedIndex.ToString() != "0")
            {
                //if ((ddlQueue.SelectedItem.Text == "Screening") || (ddlQueue.SelectedItem.Text == "Screening Hold") )
                //{
                //    flagstage = "SCR";
                //}
                //else 
                    if ((ddlQueue.SelectedItem.Text == "Screening QC") || (ddlQueue.SelectedItem.Text == "Screening QC Hold") || (ddlQueue.SelectedItem.Text == "Pending For Finone"))
                {
                    flagstage = "SCRQC";
                }
                else if ((ddlQueue.SelectedItem.Text == "Maker") || (ddlQueue.SelectedItem.Text == "Maker Hold"))
                {
                    flagstage = "MKR";
                }
                else
                {
                    flagstage = "AUT";
                }

                for (int i = 0; i <= grdlos.Rows.Count - 1; i++)
                {


                    CheckBox chkSelect = (CheckBox)grdlos.Rows[i].FindControl("chkSelect");
                    LinkButton WIP = (LinkButton)grdlos.Rows[i].FindControl("lnkWIP");
                    HdnWeb.Value = grdlos.Rows[i].Cells[2].Text.Trim();
                    HdnCase.Value = grdlos.Rows[i].Cells[3].Text.Trim();
                    HdnAppno.Value = grdlos.Rows[i].Cells[4].Text.Trim();
                    if (chkSelect.Checked == true)
                    {


                        SqlCommand sqlCom = new SqlCommand();
                        sqlCom.Connection = sqlCon;
                        sqlCom.CommandType = CommandType.StoredProcedure;
                        sqlCom.CommandText = "TCFSL_Assign_All_TCFSL_User_NEW1_23082019_SP";//Sp_Assign_ALLTCFSLUSERNEW1
                        sqlCom.CommandTimeout = 0;

                        if (ddlUserlist.SelectedIndex != 0)
                        {
                            SqlParameter UserID = new SqlParameter();
                            UserID.SqlDbType = SqlDbType.VarChar;
                            UserID.Value = ddlUserlist.SelectedValue.ToString();
                            UserID.ParameterName = "@UserID";
                            sqlCom.Parameters.Add(UserID);
                        }
                        else
                        {
                            hiddenResult.Value = "Please Select User...";
                            return;
                        }

                        SqlParameter CaseNo = new SqlParameter();
                        CaseNo.SqlDbType = SqlDbType.VarChar;
                        CaseNo.Value = HdnCase.Value;
                        CaseNo.ParameterName = "@CaseNo";
                        sqlCom.Parameters.Add(CaseNo);

                        SqlParameter WebNo = new SqlParameter();
                        WebNo.SqlDbType = SqlDbType.VarChar;
                        WebNo.Value = HdnWeb.Value;
                        WebNo.ParameterName = "@WebNo";
                        sqlCom.Parameters.Add(WebNo);

                        if (flagstage == "SCR")
                        {
                            SqlParameter AppNo = new SqlParameter();
                            AppNo.SqlDbType = SqlDbType.VarChar;
                            AppNo.Value = "";
                            AppNo.ParameterName = "@AppNo";
                            sqlCom.Parameters.Add(AppNo);
                        }
                        else
                        {
                            SqlParameter AppNo = new SqlParameter();
                            AppNo.SqlDbType = SqlDbType.VarChar;
                            AppNo.Value = HdnAppno.Value;
                            AppNo.ParameterName = "@AppNo";
                            sqlCom.Parameters.Add(AppNo);
                        }

                        SqlParameter flag = new SqlParameter();
                        flag.SqlDbType = SqlDbType.VarChar;
                        flag.Value = flagstage;
                        flag.ParameterName = "@flag";
                        sqlCom.Parameters.Add(flag);

                        sqlCon.Open();
                        int K = 0;
                        K = sqlCom.ExecuteNonQuery();

                        sqlCon.Close();
                        if (K > 0)
                        {
                            hiddenResult.Value = "Request Assign To :" + ddlUserlist.SelectedValue.ToString();
                            ddlUserlist.BackColor = System.Drawing.Color.FromName("White");
                            ddlUserlist.BackColor = System.Drawing.Color.FromName("White");
                        }
                        else
                        {
                            hiddenResult.Value = "Request Already In Process or Not assign to same maker user";
                            ddlUserlist.BackColor = System.Drawing.Color.FromName("White");
                            ddlUserlist.BackColor = System.Drawing.Color.FromName("White");
                        }

                    }
                    else
                    {

                    }
                }
            }
            else
            {
                hiddenResult.Value = "Please Select User Name...";
                return;
            }
            Get_DataForTCFSL();
        }
        catch (Exception ex)
        {
            hiddenResult.Value = ex.Message;

        }
    }
    protected void btncancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Pages/Menu.aspx", true);
    }
    protected void ddlassignuser_SelectedIndexChanged(object sender, EventArgs e)
    {
        GetUserList();
    }
    protected void grdlos_Sorting(object sender, GridViewSortEventArgs e)
    {
        DataTable dtrslt = (DataTable)ViewState["dirState"];
        if (dtrslt.Rows.Count > 0)
        {
            if (Convert.ToString(ViewState["sortdr"]) == "Asc")
            {
                dtrslt.DefaultView.Sort = e.SortExpression + " Desc";
                ViewState["sortdr"] = "Desc";
            }
            else
            {
                dtrslt.DefaultView.Sort = e.SortExpression + " Asc";
                ViewState["sortdr"] = "Asc";
            }
            grdlos.DataSource = dtrslt;
            grdlos.DataBind();


        }

    } 
    protected void grdlos_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string input = "";
                try
                {
                    string input1 = e.Row.Cells[6].Text;
                    if (input1 == "&nbsp;")
                    {
                        input = "1/1/1900 12:00:00 AM";
                        DateTime asd = Convert.ToDateTime(input);
                    }
                    else
                    {
                        input = e.Row.Cells[6].Text;
                        DateTime asd = Convert.ToDateTime(input);
                    }
                }
                catch
                {
                    input = e.Row.Cells[6].Text;
                }

                string input12 = ddlQueue.SelectedValue.ToString(); // dropdown select index

                string Inputdate = Convert.ToDateTime(input).Date.ToString("MM/dd/yyyy"); //Convert.ToDateTime(input).Date.ToString("dd/mm/yyyy");

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

                    if ((input12 == "TCFSL_GetAllData_Screening_SP") || (input12 == "TCFSL_GetAllData_ScreeningHold_SP") || (input12 == "TCFSL_GetAllData_ScreeningPending_SP"))
                    {
                        if ((input12 == "TCFSL_GetAllData_Screening_SP") || (input12 == "TCFSL_GetAllData_ScreeningHold_SP") || (input12 == "TCFSL_GetAllData_ScreeningPending_SP"))//screening stored procedure
                        {

                            //if (diffTime.Hours >= 1)
                            //{
                            //    e.Row.ForeColor = Color.FromName("red");
                            //}
                            //else
                            //{
                            //    e.Row.ForeColor = Color.FromName("black");
                            //}
                            if (diffTime.TotalMinutes >= 45 && diffTime.TotalMinutes < 60)
                            {
                                e.Row.ForeColor = Color.FromName("blue");
                            }
                            else if (diffTime.TotalMinutes >= 60)
                            {
                                e.Row.ForeColor = Color.FromName("red");
                            }
                            else
                            {
                                e.Row.ForeColor = Color.FromName("black");
                            }

                        }
                    }
                    //For QC Added By Omkar START
                    if ((input12 == "TCFSL_GetAllData_ScreeningQC_SP") || (input12 == "TCFSL_Get_All_Data_Screening_Hold_QC_SP") || (input12 == "TCFSL_Get_All_Data_Screening_PendingQC_SP"))
                    {
                        if ((input12 == "TCFSL_GetAllData_ScreeningQC_SP") || (input12 == "TCFSL_Get_All_Data_Screening_Hold_QC_SP") || (input12 == "TCFSL_Get_All_Data_Screening_PendingQC_SP"))//screening stored procedure
                        {

                            //if (diffTime.Hours >= 1)
                            //{
                            //    e.Row.ForeColor = Color.FromName("red");
                            //}
                            //else
                            //{
                            //    e.Row.ForeColor = Color.FromName("black");
                            //}
                            if (diffTime.TotalMinutes >= 45 && diffTime.TotalMinutes < 60)
                            {
                                e.Row.ForeColor = Color.FromName("blue");
                            }
                            else if (diffTime.TotalMinutes >= 60)
                            {
                                e.Row.ForeColor = Color.FromName("red");
                            }
                            else
                            {
                                e.Row.ForeColor = Color.FromName("black");
                            }

                        }
                    }
                    //For QC Added By Omkar END
                    if ((input12 == "TCFSL_GetAllData_Maker_SP") || (input12 == "TCFSL_Get_AllData_MakerRJ_SP"))
                    {

                        if ((input12 == "TCFSL_GetAllData_Maker_SP") || (input12 == "TCFSL_Get_AllData_MakerRJ_SP"))//MAker stored procedure
                        {
                            //if (diffTime.Hours >= 1.15)//1.15
                            //{
                            //    e.Row.ForeColor = Color.FromName("red");
                            //}
                            //else
                            //{
                            //    e.Row.ForeColor = Color.FromName("black");
                            //}
                            if (diffTime.TotalMinutes >= 60 && diffTime.TotalMinutes < 75)
                            {
                                e.Row.ForeColor = Color.FromName("blue");
                            }
                            else if (diffTime.TotalMinutes >= 75)//1.15
                            {
                                e.Row.ForeColor = Color.FromName("red");
                            }
                            else
                            {
                                e.Row.ForeColor = Color.FromName("black");
                            }

                        }
                    }


                    if ((input12 == "TCFSL_USP_GetAllData_Author_SP") || (input12 == "TCFSL_GetAllData_Author_RJ_SP"))
                    {
                        if ((input12 == "TCFSL_USP_GetAllData_Author_SP") || (input12 == "TCFSL_GetAllData_Author_RJ_SP"))//Author peocedure
                        {
                            //if (diffTime.Hours >= 1.50)//1.50
                            //{
                            //    e.Row.ForeColor = Color.FromName("red");
                            //}
                            //else
                            //{
                            //    e.Row.ForeColor = Color.FromName("black");
                            //}
                            if (diffTime.TotalMinutes >= 75 && diffTime.TotalMinutes < 90)
                            {
                                e.Row.ForeColor = Color.FromName("blue");
                            }
                            else if (diffTime.TotalMinutes >= 90)//1.50
                            {
                                e.Row.ForeColor = Color.FromName("red");
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
                    if ((input12 == "") || (input12 == ""))
                    {
                        if ((input12 == "") || (input12 == ""))//Author peocedure
                        {
                            //if (diffTime.Hours >= 2)
                            //{
                            //    e.Row.ForeColor = Color.FromName("red");
                            //}
                            //else
                            //{
                            e.Row.ForeColor = Color.FromName("black");
                            //}
                        }
                    }
                    else
                    {
                        e.Row.ForeColor = Color.FromName("red");
                    }
                }




            }
        }
        catch (Exception ex)
        {
            hiddenResult.Value = "Error :" + ex.Message;
        }

    }
    protected void ddlapptyp_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlQueue.Items.Clear();
        if (ddlapptyp.SelectedItem.Value == "1")
        {
            if (!ddlQueue.Items.Contains(new ListItem("---Select---")))
            {
                ddlQueue.Items.Add(new ListItem("---Select---", "0"));
            }
            if (!ddlQueue.Items.Contains(new ListItem("Screening")))
            {
                ddlQueue.Items.Add(new ListItem("Screening", "TCFSL_GetAllData_Screening_SP")); //added
            }
            //if (!ddlQueue.Items.Contains(new ListItem("Screening Reject")))
            //{
            //    ddlQueue.Items.Add(new ListItem("Screening Reject", "sp_getalldata_ScreeningRJ"));
            //}
            if (!ddlQueue.Items.Contains(new ListItem("Screening Hold")))
            {
                ddlQueue.Items.Add(new ListItem("Screening Hold", "TCFSL_GetAllData_ScreeningHold_SP")); //added
            }
            ddlQueue.SelectedIndex = 0;
            ddlQueue.DataBind();
        }
        else if (ddlapptyp.SelectedItem.Value == "2")
        {
            if (!ddlQueue.Items.Contains(new ListItem("---Select---")))
            {
                ddlQueue.Items.Add(new ListItem("---Select---", "0"));
            }
            if (!ddlQueue.Items.Contains(new ListItem("Maker")))
            {
                ddlQueue.Items.Add(new ListItem("Maker", "TCFSL_GetAllData_Maker_SP"));
            }
            if (!ddlQueue.Items.Contains(new ListItem("Maker Hold")))
            {
                ddlQueue.Items.Add(new ListItem("Maker Hold", "TCFSL_Get_AllData_MakerRJ_SP"));
            }
            ddlQueue.SelectedIndex = 0;
            ddlQueue.DataBind();
        }
        //added
        else if (ddlapptyp.SelectedItem.Value == "QC")
        {
            if (!ddlQueue.Items.Contains(new ListItem("---Select---")))
            {
                ddlQueue.Items.Add(new ListItem("---Select---", "0"));
            }
            if (!ddlQueue.Items.Contains(new ListItem("Screening QC")))
            {
                ddlQueue.Items.Add(new ListItem("Screening QC", "TCFSL_GetAllData_ScreeningQC_SP"));
            }
            if (!ddlQueue.Items.Contains(new ListItem("Screening QC Hold")))
            {
                ddlQueue.Items.Add(new ListItem("Screening QC Hold", "TCFSL_Get_All_Data_Screening_Hold_QC_SP"));
            }
            if (!ddlQueue.Items.Contains(new ListItem("Pending For Finone")))
            {
                ddlQueue.Items.Add(new ListItem("Pending For Finone", "TCFSL_Get_All_Data_Screening_PendingQC_SP"));
            }
            ddlQueue.SelectedIndex = 0;
            ddlQueue.DataBind();
        }//added
        else
        {
            if (!ddlQueue.Items.Contains(new ListItem("---Select---")))
            {
                ddlQueue.Items.Add(new ListItem("---Select---", "0"));
            }
            if (!ddlQueue.Items.Contains(new ListItem("Author")))
            {
                ddlQueue.Items.Add(new ListItem("Author", "TCFSL_USP_GetAllData_Author_SP"));
            }
            if (!ddlQueue.Items.Contains(new ListItem("Author Hold")))
            {
                ddlQueue.Items.Add(new ListItem("Author Hold", "TCFSL_GetAllData_Author_RJ_SP"));
            }
            ddlQueue.SelectedIndex = 0;
            ddlQueue.DataBind();
        }
    }
    protected void pendencyTimer_Tick(object sender, EventArgs e)
    {
        Object SaveUSERInfo = (Object)Session["UserInfo"];
        SqlConnection sqlCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);
        try
        {
            SqlCommand sqlCom = new SqlCommand();
            sqlCom.Connection = sqlCon;
            sqlCom.CommandType = CommandType.StoredProcedure;
            sqlCom.CommandText = "TCFSL_USP_GetPendencyCount_23082019_SP";
            sqlCom.CommandTimeout = 0;


            sqlCon.Open();

            SqlDataAdapter sqlDA = new SqlDataAdapter();
            sqlDA.SelectCommand = sqlCom;

            DataSet ds = new DataSet();
            sqlDA.Fill(ds);

            sqlCon.Close();

            if (ds.Tables.Count>0)
            {
                lblQCCount.Text = ds.Tables[0].Rows.Count > 0 ? ds.Tables[0].Rows[0]["QCScreenCount"].ToString() : "0";
                lblQCHoldCount.Text = ds.Tables[1].Rows.Count > 0 ? ds.Tables[1].Rows[0]["QCScreenHoldCount"].ToString() : "0";
                lblQCPendingFinnOneCount.Text = ds.Tables[2].Rows.Count > 0 ? ds.Tables[2].Rows[0]["QCScreenPendingFinnOneCount"].ToString() : "0";
                lblMakerCount.Text = ds.Tables[3].Rows.Count > 0 ? ds.Tables[3].Rows[0]["MakerCount"].ToString() : "0";
                lblMakerHoldCount.Text = ds.Tables[4].Rows.Count > 0 ? ds.Tables[4].Rows[0]["MakerHoldCount"].ToString() : "0";
                lblAuthorCount.Text = ds.Tables[5].Rows.Count > 0 ? ds.Tables[5].Rows[0]["AuthorCount"].ToString() : "0";
                lblAuthorHoldCount.Text = ds.Tables[6].Rows.Count > 0 ? ds.Tables[6].Rows[0]["AuthorHoldCount"].ToString() : "0";
            }
            else
            {
                lblQCCount.Text = "NA";
                lblQCHoldCount.Text = "NA";
                lblQCPendingFinnOneCount.Text = "NA";
                lblMakerCount.Text = "NA";
                lblMakerHoldCount.Text = "NA";
                lblAuthorCount.Text = "NA";
                lblAuthorHoldCount.Text = "NA";
            }
        }

        catch (Exception ex)
        {
            hiddenResult.Value = ex.Message;

        }
    }
}