using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using iTextSharp.text.pdf;
using iTextSharp.text;
using System.IO;
using System.Globalization;
public partial class Pages_ChequeProcessingNEW_DS_SearchView : System.Web.UI.Page
{
    int chqCount;
    int Length=0;

    string SerialNo;
    string ChequeNo;
    string ChequeDate;
    string ChequeAmt;
    string D_Bankname;
    string D_Branchname;
    string D_BranchCity;

    string Deposite_SlipNo;
    string IntrumentType;
    string Pickup_Date;
    string Deposit_Date;
    string BankName;
    //string BranchName;
    string BranchCity;
    //string Instrument_Number;
    //string Cheque_Ammount;
    //string Instrument_Date;
    string TotalAmount;
    string SummaryIntrumentTypeTotalCount;
    //string SummaryDeposit_Date;
    //string SummaryPickup_Date;
    //string SummaryBankName;
    //string SummaryBranchName;
    string SummaryType_of_Clearing;
    string SummaryDeposite_SlipNo;
    string SummaryIntrumentTypeCount;
    string SummaryAmount;
    //string SummaryTotalAmmount;
    string Type_of_Clearing;

    protected void Page_Load(object sender, EventArgs e)
    {

 	if (Session["UserInfo"] == null)
            {
                Response.Redirect("~/Pages/InvalidRequest.aspx");
            }

        if (!IsPostBack)
        {
            if (Cache["SBIClientList"] == null)
            {
                Get_AllClientList();
            }
            else
            {
                ddlClientList.DataTextField = "ClientName";
                ddlClientList.DataValueField = "ClientID";

                ddlClientList.DataSource = (DataTable)Cache["SBIClientList"];
                ddlClientList.DataBind();

                ddlClientList.Items.Insert(0, "-Select-");
                ddlClientList.SelectedIndex = 0;
            }
        }
        //pnlPdcCheck.Visible = false;
        
         Object SaveUSERInfo = (Object)Session["UserInfo"];
         lblLocation.Text = Convert.ToString(((UserInfo.structUSERInfo)(SaveUSERInfo)).BranchName);
    }

    private void Get_PendingCount()
    {
        try
        {
            Object SaveUSERInfo = (Object)Session["UserInfo"];

            SqlConnection sqlcon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);


            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlcon;
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.CommandText = "Get_PendingCountForDSnMDB";
            sqlcmd.CommandTimeout = 0;

            SqlParameter BranchID = new SqlParameter();
            BranchID.SqlDbType = SqlDbType.Int;
            BranchID.Value = Convert.ToInt32(((UserInfo.structUSERInfo)(SaveUSERInfo)).BranchId);
            BranchID.ParameterName = "@BranchID";
            sqlcmd.Parameters.Add(BranchID);

            int pClientId = 0;
            if (ddlClientList.SelectedIndex != 0)
            {
                pClientId = Convert.ToInt32(ddlClientList.SelectedItem.Value);
            }

            SqlParameter ClientID = new SqlParameter();
            ClientID.SqlDbType = SqlDbType.Int;
            ClientID.Value = pClientId;
            ClientID.ParameterName = "@ClientID";
            sqlcmd.Parameters.Add(ClientID);

            SqlParameter ChequePickeupDate = new SqlParameter();
            ChequePickeupDate.SqlDbType = SqlDbType.VarChar;
            ChequePickeupDate.Value = txtPickupdate.Text.Trim();
            ChequePickeupDate.ParameterName = "@ChequePickeupDate";
            sqlcmd.Parameters.Add(ChequePickeupDate);

            sqlcon.Open();
            SqlDataAdapter sqlda = new SqlDataAdapter();
            sqlda.SelectCommand = sqlcmd;
            DataTable dt = new DataTable();
            sqlda.Fill(dt);
            sqlcon.Close();

            if (dt.Rows.Count > 0)
            {
                hdnPendingCount.Value = dt.Rows[0]["PendingCount"].ToString();
            }
        }
        catch (Exception ex)
        {
            lblMessage.Visible = true;
            lblMessage.Text = ex.Message;
            lblMessage.CssClass = "ErrorMessage";
        }

        finally
        { 
        
        }

    }

    private void Get_AllClientList()
    {

        try
        {
            SqlConnection sqlcon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);


            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlcon;
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.CommandText = "Get_AllClientList";
            sqlcmd.CommandTimeout = 0;

            SqlParameter Is_Active = new SqlParameter();
            Is_Active.SqlDbType = SqlDbType.Int;
            Is_Active.Value = 1;
            Is_Active.ParameterName = "@Is_Active";
            sqlcmd.Parameters.Add(Is_Active);

            sqlcon.Open();
            SqlDataAdapter sqlda = new SqlDataAdapter();
            sqlda.SelectCommand = sqlcmd;
            DataTable dt = new DataTable();
            sqlda.Fill(dt);
            sqlcon.Close();

            Cache["SBIClientList"] = dt;

            ddlClientList.DataTextField = "ClientName";
            ddlClientList.DataValueField = "ClientID";
            ddlClientList.DataSource = dt;
            ddlClientList.DataBind();

            ddlClientList.Items.Insert(0, "-Select-");
            ddlClientList.SelectedIndex = 0;

        }
        catch (Exception ex)
        {
            lblMessage.Visible = true;
            lblMessage.Text = ex.Message;
            lblMessage.CssClass = "ErrorMessage";

        }
        finally
        { 
        
        
        }

    }

    private void Get_BatchFileDetails_Search()
    {
        try
        {
            Object SaveUSERInfo = (Object)Session["UserInfo"];

            SqlConnection sqlcon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);


            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlcon;
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.CommandText = "Get_BatchFileDetails_SearchNew";
            sqlcmd.CommandTimeout = 0;



            SqlParameter BranchID = new SqlParameter();
            BranchID.SqlDbType = SqlDbType.Int;
            BranchID.Value = Convert.ToInt32(((UserInfo.structUSERInfo)(SaveUSERInfo)).BranchId);
            BranchID.ParameterName = "@BranchID";
            sqlcmd.Parameters.Add(BranchID);

            int pClientId = 0;
            if (ddlClientList.SelectedIndex != 0)
            {
                pClientId = Convert.ToInt32(ddlClientList.SelectedItem.Value);
            }

            SqlParameter ClientID = new SqlParameter();
            ClientID.SqlDbType = SqlDbType.Int;
            ClientID.Value = pClientId;
            ClientID.ParameterName = "@ClientID";
            sqlcmd.Parameters.Add(ClientID);

            SqlParameter ChequePickeupDate = new SqlParameter();
            ChequePickeupDate.SqlDbType = SqlDbType.VarChar;
            ChequePickeupDate.Value = txtPickupdate.Text.Trim();
            ChequePickeupDate.ParameterName = "@ChequePickeupDate";
            sqlcmd.Parameters.Add(ChequePickeupDate);

            SqlParameter ChequeDepositDate = new SqlParameter();
            ChequeDepositDate.SqlDbType = SqlDbType.VarChar;
            ChequeDepositDate.Value = txtDepositdate.Text.Trim();
            ChequeDepositDate.ParameterName = "@ChequeDepositDate";
            sqlcmd.Parameters.Add(ChequeDepositDate);


            sqlcon.Open();
            SqlDataAdapter sqlda = new SqlDataAdapter();
            sqlda.SelectCommand = sqlcmd;
            DataTable dt = new DataTable();
            sqlda.Fill(dt);
            sqlcon.Close();


            if (dt.Rows.Count > 0)
            {
                lblMessage.Text = "Total No of Rows found :" + dt.Rows.Count;
                lblMessage.CssClass = "SuccessMessage";
                pnlButtons.Visible = true;
                grvBatchDetails.DataSource = dt;
                grvBatchDetails.DataBind();
            }
            else
            {

                lblMessage.Text = "No records found ";
                lblMessage.CssClass = "ErrorMessage";
                grvBatchDetails.DataSource = null;
                grvBatchDetails.DataBind();
            }



        }
        catch (Exception ex)
        {
            lblMessage.Visible = true;
            lblMessage.Text = ex.Message;
            lblMessage.CssClass = "ErrorMessage";

        }
        finally
        { 
        
        }

    }
     

    protected void Button1_Click(object sender, EventArgs e)
    {
        lblMessage.Text = "";
        if (ddlClientList.SelectedIndex != 0)
        {
            if (txtPickupdate.Text != "")
            {
                if (txtDepositdate.Text != "")
                {
                    if (hdnPendingCount.Value != null && Convert.ToInt32(hdnPendingCount.Value) == 0)
                    {
                        CheckPDC();
                        Insert_DepositSlipInfoPDCONLY();

                        GeneratePdfReport_PDC();
                    }
                    else
                    {
                        lblMessage.Text = "Deposit Slip cannot be generated.Complete Pending batch(s) first.";
                        lblMessage.CssClass = "ErrorMessage";
                    }
                }
                else
                {
                    lblMessage.Text = "Deposit Date Mandatory.";
                    lblMessage.CssClass = "ErrorMessage";
                }
            }
            else
            {
                lblMessage.Text = "Pickup Date Mandatory.";
                lblMessage.CssClass = "ErrorMessage";
            }

        }
        else
        {
            lblMessage.Text = "Select One Client.";
            lblMessage.CssClass = "ErrorMessage";
        }
        
    }

    private void GeneratePdfReport_PDC()
    {

        Object SaveUSERInfo = (Object)Session["UserInfo"];

        try
        {
            SqlConnection sqlcon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);

          

            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlcon;
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.CommandText = "Get_DSno_mod";
            sqlcmd.CommandTimeout = 0;

          
            SqlParameter BranchID = new SqlParameter();
            BranchID.SqlDbType = SqlDbType.Int;
            BranchID.Value = Convert.ToInt32(((UserInfo.structUSERInfo)(SaveUSERInfo)).BranchId);
            BranchID.ParameterName = "@BranchId";
            sqlcmd.Parameters.Add(BranchID);

            int pClientId = 0;
            if (ddlClientList.SelectedIndex != 0)
            {
                pClientId = Convert.ToInt32(ddlClientList.SelectedItem.Value);
            }

            SqlParameter ClientID = new SqlParameter();
            ClientID.SqlDbType = SqlDbType.Int;
            ClientID.Value = pClientId;
            ClientID.ParameterName = "@ClientID";
            sqlcmd.Parameters.Add(ClientID);

            SqlParameter DepositSlipDate = new SqlParameter();
            DepositSlipDate.SqlDbType = SqlDbType.VarChar;
            DepositSlipDate.Value = txtPickupdate.Text.Trim();
            DepositSlipDate.ParameterName = "@DepositSlipDate ";
            sqlcmd.Parameters.Add(DepositSlipDate);

            sqlcon.Open();
            SqlDataAdapter sqlda = new SqlDataAdapter();
            sqlda.SelectCommand = sqlcmd;

            DataTable dt = new DataTable();
            sqlda.Fill(dt);
            sqlcon.Close();



            if (dt.Rows.Count > 0)
            {
                arr = new string[dt.Rows.Count];
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    arr[i] = dt.Rows[i]["DepositSlipNo"].ToString().Trim();
                }
                Length = arr.Length;
            }
        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
            lblMessage.CssClass = "ErrorMessage";
        }

        var titleFont = FontFactory.GetFont("Arial", 9, Font.BOLD);
        var subTitleFont = FontFactory.GetFont("Arial", 8, Font.NORMAL);
        var boldTableFont = FontFactory.GetFont("Arial", 7, Font.BOLD);
        var NormalTableFont = FontFactory.GetFont("Arial", 7, Font.NORMAL);
        var endingMessageFont = FontFactory.GetFont("Arial", 7, Font.ITALIC);
        var BoldFont8 = FontFactory.GetFont("Arial", 6, Font.BOLD);
        Document Doc = new Document(PageSize.A4);

        PdfWriter.GetInstance(Doc, Response.OutputStream);

        Doc.AddCreator("This Application");
        Doc.AddAuthor("Me");
        Doc.Open();

      
        Phrase phr = new Phrase(""); //empty phrase for page numbering
        if (Length > 0)
        {
            for (int i = 0; i < Length; i++)
            {
                Doc.NewPage();
                //Get_Headers();
                string dsno = arr[i].ToString().Trim();

                SqlConnection sqlcon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);

            

                SqlCommand sqlcmd = new SqlCommand();
                sqlcmd.Connection = sqlcon;
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.CommandText = "Get_HeaderForDS_Rupesh";
                sqlcmd.CommandTimeout = 0;


                SqlParameter DepositSlipNo = new SqlParameter();
                DepositSlipNo.SqlDbType = SqlDbType.VarChar;
                DepositSlipNo.Value = dsno;
                DepositSlipNo.ParameterName = "@DepositSlipNo";
                sqlcmd.Parameters.Add(DepositSlipNo);

                SqlParameter BranchID = new SqlParameter();
                BranchID.SqlDbType = SqlDbType.VarChar;
                BranchID.Value = Convert.ToInt32(((UserInfo.structUSERInfo)(SaveUSERInfo)).BranchId);
                BranchID.ParameterName = "@BranchID ";
                sqlcmd.Parameters.Add(BranchID);

                int pClientId = 0;
                if (ddlClientList.SelectedIndex != 0)
                {
                    pClientId = Convert.ToInt32(ddlClientList.SelectedItem.Value);
                }

                SqlParameter ClientID = new SqlParameter();
                ClientID.SqlDbType = SqlDbType.Int;
                ClientID.Value = pClientId;
                ClientID.ParameterName = "@ClientID";
                sqlcmd.Parameters.Add(ClientID);

                SqlParameter PickupDate = new SqlParameter();
                PickupDate.SqlDbType = SqlDbType.VarChar;
                PickupDate.Value = txtPickupdate.Text.Trim();
                PickupDate.ParameterName = "@PickupDate ";
                sqlcmd.Parameters.Add(PickupDate);

                SqlParameter DepositSlipDatenew = new SqlParameter();
                DepositSlipDatenew.SqlDbType = SqlDbType.VarChar;
                DepositSlipDatenew.Value = txtDepositdate.Text.Trim();
                DepositSlipDatenew.ParameterName = "@DepositSlipDate ";
                sqlcmd.Parameters.Add(DepositSlipDatenew);



                sqlcon.Open();
                SqlDataAdapter sqlda = new SqlDataAdapter();
                sqlda.SelectCommand = sqlcmd;
                DataSet ds = new DataSet();
                sqlda.Fill(ds);
                sqlcon.Close();

                if (ds.Tables.Count > 0)
                {

                    Deposite_SlipNo = ds.Tables[0].Rows[0]["DepositSlipNo"].ToString();
                    Type_of_Clearing = ds.Tables[0].Rows[0]["Type_of_Clearing"].ToString();

                    Deposit_Date = ds.Tables[0].Rows[0]["DepositDate"].ToString();
                    Pickup_Date = ds.Tables[0].Rows[0]["ReportDate"].ToString();
                    IntrumentType = ds.Tables[0].Rows[0]["IntrumentType"].ToString();

                    BankName = ds.Tables[0].Rows[0]["Name_of_customer"].ToString();
                    //BranchName = ds.Tables[0].Rows[0]["BranchName"].ToString();
                    BranchCity = ds.Tables[0].Rows[0]["Location"].ToString();

                    hdnAccountNo.Value = ds.Tables[0].Rows[0]["AccountNo"].ToString();


                    //Is_SBI = ds.Tables[0].Rows[1]["Is_SBI"].ToString();




                    HdnDsCount.Value = ds.Tables[1].Rows[0]["chqcount"].ToString();

                }
                chqCount = Convert.ToInt32(HdnDsCount.Value);


                PdfPTable Head = new PdfPTable(7);
                Head.TotalWidth = 580f;
                float[] widths12 = new float[] { 40f, 40f, 80f, 80f, 100f, 80f, 100f };
                Head.SetWidths(widths12);
                Head.LockedWidth = true;

                PdfPCell C1 = new PdfPCell(new Phrase("Deposit Number :", boldTableFont));
                C1.Colspan = 2;
                C1.Border = 0;
                C1.HorizontalAlignment = 0;
                Head.AddCell(C1);

                PdfPCell C11 = new PdfPCell(new Phrase(Deposite_SlipNo, NormalTableFont));
                C11.Colspan = 3;
                C11.Border = 0;
                C11.HorizontalAlignment = 0;
                Head.AddCell(C11);

                int page = i + 1;

                PdfPCell C2 = new PdfPCell(new Phrase("Page No : " + page, boldTableFont));
                C2.Colspan = 2;
                C2.Border = 0;
                C2.HorizontalAlignment = 2;
                Head.AddCell(C2);


                PdfPTable test = new PdfPTable(7);
                test.TotalWidth = 550f;
                float[] widths11 = new float[] { 40f, 50f, 80f, 100f, 100f, 100f, 60f };
                test.SetWidths(widths11);
                test.LockedWidth = true;




                ///////RUpesh
                PdfPTable table = new PdfPTable(7);
                table.TotalWidth = 550f;
                float[] widths = new float[] { 30f, 80f, 80f, 60f, 180f, 180f, 70f };// Imp
                table.SetWidths(widths);
                table.LockedWidth = true;

                PdfPCell header = new PdfPCell(new Phrase("D E P O S I T  P A Y - I N - S L I P\n\n", titleFont));
                header.Colspan = 7;
                header.Border = 0;
                header.HorizontalAlignment = 1;
                test.AddCell(header);

                PdfPCell Cell1 = new PdfPCell(new Phrase("Type of Clearing :", boldTableFont));
                Cell1.Colspan = 2;
                Cell1.Border = 0;
                Cell1.HorizontalAlignment = 0;
                test.AddCell(Cell1);

                PdfPCell Cell11 = new PdfPCell(new Phrase(Type_of_Clearing, NormalTableFont));
                Cell11.Colspan = 2;
                Cell11.Border = 0;
                Cell11.HorizontalAlignment = 0;
                test.AddCell(Cell11);

                PdfPCell Cell2 = new PdfPCell(new Phrase("Report Date   :", boldTableFont));
                Cell2.Colspan = 2;
                Cell2.Border = 0;
                Cell2.HorizontalAlignment = 2;
                test.AddCell(Cell2);

                // PdfPCell Cell21 = new PdfPCell(new Phrase(Pickup_Date, NormalTableFont));
                PdfPCell Cell21 = new PdfPCell(new Phrase(txtPickupdate.Text.Trim(), NormalTableFont));
                Cell21.Colspan = 1;
                Cell21.Border = 0;
                Cell21.HorizontalAlignment = 0;
                test.AddCell(Cell21);


                PdfPCell Cell3 = new PdfPCell(new Phrase("Instrument Type :", boldTableFont));
                Cell3.Colspan = 2;
                Cell3.Border = 0;
                Cell3.HorizontalAlignment = 0;
                test.AddCell(Cell3);

                PdfPCell Cell31 = new PdfPCell(new Phrase(IntrumentType, NormalTableFont));
                Cell31.Colspan = 2;
                Cell31.Border = 0;
                Cell31.HorizontalAlignment = 0;
                test.AddCell(Cell31);


                PdfPCell Cell4 = new PdfPCell(new Phrase(" Deposit Date :", boldTableFont));
                Cell4.Colspan = 2;
                Cell4.Border = 0;
                Cell4.HorizontalAlignment = 2;
                test.AddCell(Cell4);

                PdfPCell Cell41 = new PdfPCell(new Phrase(txtDepositdate.Text.Trim(), NormalTableFont));
                Cell41.Colspan = 1;
                Cell41.Border = 0;
                Cell41.HorizontalAlignment = 0;
                test.AddCell(Cell41);

                PdfPTable Tab11 = new PdfPTable(7);
                Tab11.TotalWidth = 550f;
                Tab11.LockedWidth = true;

                PdfPCell Cell51 = new PdfPCell(new Phrase("\nPlease quote the deposit serial number in Bank Statement for Credits and Deposit slip Serial number/Instrument sequence number is Bank Statement, debits on account of cheque returned unpaid. Please also mention the same in your returned cheque advice.\n\n", NormalTableFont));
                Cell51.Colspan = 7;
                Cell51.Border = 0;
                Cell51.HorizontalAlignment = 0;
                Tab11.AddCell(Cell51);

                PdfPTable Tab = new PdfPTable(7);
                Tab.TotalWidth = 550f;
                float[] widthsAA = new float[] { 100f, 55f, 80f, 60f, 180f, 180f, 70f };// Imp
                Tab.SetWidths(widthsAA);
                Tab.LockedWidth = true;

                PdfPCell Cell6 = new PdfPCell(new Phrase("  Paid to CREDIT OF :", boldTableFont));
                Cell6.Colspan = 2;
                Cell6.Border = 0;
                Cell6.HorizontalAlignment = 2;
                Tab.AddCell(Cell6);

                PdfPCell Cell61 = new PdfPCell(new Phrase(BankName, NormalTableFont));
                Cell61.Colspan = 5;
                Cell61.Border = 0;
                Cell61.HorizontalAlignment = 0;
                Tab.AddCell(Cell61);

                PdfPCell Cell7 = new PdfPCell(new Phrase("Name of the Customer :", boldTableFont));
                Cell7.Colspan = 2;
                Cell7.Border = 0;
                Cell7.HorizontalAlignment = 2;
                Tab.AddCell(Cell7);

                PdfPCell Cell71 = new PdfPCell(new Phrase("SBI CPSL", NormalTableFont));
                Cell71.Colspan = 5;
                Cell71.Border = 0;
                Cell71.HorizontalAlignment = 0;
                Tab.AddCell(Cell71);

                PdfPCell Cell8 = new PdfPCell(new Phrase("             At :", boldTableFont));
                Cell8.Colspan = 2;
                Cell8.Border = 0;
                Cell8.HorizontalAlignment = 2;
                Tab.AddCell(Cell8);

                PdfPCell Cell81 = new PdfPCell(new Phrase(BranchCity, NormalTableFont));
                Cell81.Colspan = 5;
                Cell81.Border = 0;
                Cell81.HorizontalAlignment = 0;
                Tab.AddCell(Cell81);


                PdfPCell Cell9 = new PdfPCell(new Phrase("SBI CMP Client Code:" + hdnAccountNo.Value, boldTableFont));
                Cell9.Colspan = 7;
                Cell9.Border = 0;
                Cell9.HorizontalAlignment = 0;
                Tab.AddCell(Cell9);

                /////Rupesh

                PdfPTable tableRup = new PdfPTable(7);
                tableRup.TotalWidth = 550f;
                float[] widthsRup = new float[] { 30f, 80f, 80f, 60f, 180f, 180f, 70f };// Imp
                tableRup.SetWidths(widthsRup);
                tableRup.LockedWidth = true;

                PdfPCell TestRup1 = new PdfPCell(Head);
                TestRup1.Colspan = 7;
                TestRup1.Border = 0;
                TestRup1.HorizontalAlignment = 0;
                tableRup.AddCell(TestRup1);

                PdfPCell TestRup2 = new PdfPCell(test);
                TestRup2.Colspan = 7;
                TestRup2.Border = 0;
                TestRup2.HorizontalAlignment = 0;
                tableRup.AddCell(TestRup2);

                PdfPCell TestRup3 = new PdfPCell(Tab11);
                TestRup3.Colspan = 7;
                TestRup3.Border = 0;
                TestRup3.HorizontalAlignment = 0;
                tableRup.AddCell(TestRup3);

                PdfPCell TestRup4 = new PdfPCell(Tab);
                TestRup4.Colspan = 7;
                TestRup4.Border = 0;
                TestRup4.HorizontalAlignment = 0;
                tableRup.AddCell(TestRup4);

                tableRup.AddCell(new PdfPCell(new Phrase("Sr No.", boldTableFont)));
                tableRup.AddCell(new PdfPCell(new Phrase("Instrument Number", boldTableFont)));
                tableRup.AddCell(new PdfPCell(new Phrase("Instrument Date", boldTableFont)));
                tableRup.AddCell(new PdfPCell(new Phrase("Amount", boldTableFont)));
                tableRup.AddCell(new PdfPCell(new Phrase("Bank Drawn", boldTableFont)));
                tableRup.AddCell(new PdfPCell(new Phrase("Branch Drawn", boldTableFont)));
                tableRup.AddCell(new PdfPCell(new Phrase("City Name", boldTableFont)));

                for (int j = 0; j <= chqCount - 1; j++)
                {

                    //HdnNO.Value = Convert.ToInt32(i).ToString();
                    //GetDepositSlipData();
                    //Get_Details();

                    try
                    {
                        SqlConnection sqlCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);

                 
                        SqlCommand sqlCmd = new SqlCommand();
                        sqlCmd.Connection = sqlcon;
                        sqlCmd.CommandType = CommandType.StoredProcedure;
                        //sqlCmd.CommandText = "Get_DSdetails";//08 july 2013 nikhil test
                        sqlCmd.CommandText = "Get_DSdetails_mod";
                        sqlCmd.CommandTimeout = 0;


                   

                        //SqlParameter DepositSlipNo = new SqlParameter();
                        //DepositSlipNo.SqlDbType = SqlDbType.VarChar;
                        //DepositSlipNo.Value = dsno;
                        //DepositSlipNo.ParameterName = "@DepositSlipNo";
                        //sqlcmd.Parameters.Add(DepositSlipNo);

                        SqlParameter DepositeSlipNo = new SqlParameter();
                        DepositeSlipNo.SqlDbType = SqlDbType.VarChar;
                        DepositeSlipNo.Value = Deposite_SlipNo.ToString();
                        DepositeSlipNo.ParameterName = "@DepositSlipNo";
                        sqlCmd.Parameters.Add(DepositeSlipNo);

                        SqlParameter BranchID2 = new SqlParameter();
                        BranchID2.SqlDbType = SqlDbType.VarChar;
                        BranchID2.Value = Convert.ToInt32(((UserInfo.structUSERInfo)(SaveUSERInfo)).BranchId);
                        BranchID2.ParameterName = "@BranchID ";
                        sqlCmd.Parameters.Add(BranchID2);

                        int pClientId2 = 0;
                        if (ddlClientList.SelectedIndex != 0)
                        {
                            pClientId2 = Convert.ToInt32(ddlClientList.SelectedItem.Value);
                        }

                        SqlParameter ClientID2 = new SqlParameter();
                        ClientID2.SqlDbType = SqlDbType.Int;
                        ClientID2.Value = pClientId2;
                        ClientID2.ParameterName = "@ClientID";
                        sqlCmd.Parameters.Add(ClientID2);

                        SqlParameter DepositSlipDate = new SqlParameter();
                        DepositSlipDate.SqlDbType = SqlDbType.VarChar;
                        DepositSlipDate.Value = txtPickupdate.Text.Trim();
                        DepositSlipDate.ParameterName = "@DepositSlipDate ";
                        sqlCmd.Parameters.Add(DepositSlipDate);

                        sqlcon.Open();
                        SqlDataAdapter sqlDa = new SqlDataAdapter();
                        sqlDa.SelectCommand = sqlCmd;
                        DataSet Ds = new DataSet();
                        sqlDa.Fill(Ds);
                        sqlcon.Close();

                        if (Ds.Tables.Count > 0)
                        {
                            SerialNo = Ds.Tables[0].Rows[j]["SerialNo"].ToString();
                            ChequeNo = Ds.Tables[0].Rows[j]["ChequeNo"].ToString();
                            ChequeDate = Ds.Tables[0].Rows[j]["ChequeDate"].ToString();
                            ChequeAmt = Ds.Tables[0].Rows[j]["ChequeAmt"].ToString();
                            D_Bankname = Ds.Tables[0].Rows[j]["BankName"].ToString();
                            D_Branchname = Ds.Tables[0].Rows[j]["BranchName"].ToString();
                            D_BranchCity = Ds.Tables[0].Rows[j]["BranchCity"].ToString();
                        }

                    }
                    catch (Exception ex)
                    {
                        lblMessage.Text = ex.Message;
                        lblMessage.CssClass = "ErrorMessage";
                    }


                    //SerialNo
                    PdfPTable nested = new PdfPTable(1);
                    nested.AddCell(new PdfPCell(new Phrase(SerialNo, NormalTableFont)));

                    PdfPCell nesthousing = new PdfPCell(nested);
                    nesthousing.Padding = 0f;
                    tableRup.AddCell(nesthousing);

                    //Instrument_Number             
                    PdfPTable nested2 = new PdfPTable(1);
                    nested2.AddCell(new PdfPCell(new Phrase(ChequeNo, NormalTableFont)));

                    PdfPCell nesthousing2 = new PdfPCell(nested2);
                    nesthousing2.Padding = 0f;
                    tableRup.AddCell(nesthousing2);

                    // Instrument_Date
                    PdfPTable nested3 = new PdfPTable(1);
                    nested3.AddCell(new PdfPCell(new Phrase(ChequeDate, NormalTableFont)));

                    PdfPCell nesthousing3 = new PdfPCell(nested3);
                    nesthousing3.Padding = 0f;
                    tableRup.AddCell(nesthousing3);

                    //Cheque_Ammount
                    PdfPTable nested4 = new PdfPTable(1);
                    //nested4.HorizontalAlignment = 2;
                    PdfPCell nesthou4 = new PdfPCell(new Phrase(ChequeAmt, NormalTableFont));
                    nesthou4.HorizontalAlignment = 2;
                    nested4.AddCell(nesthou4);


                    PdfPCell nesthousing4 = new PdfPCell(nested4);
                    nesthousing4.Padding = 0f;
                    tableRup.AddCell(nesthousing4);

                    //BankName
                    PdfPTable nested5 = new PdfPTable(1);
                    nested5.AddCell(new PdfPCell(new Phrase(D_Bankname, NormalTableFont)));

                    PdfPCell nesthousing5 = new PdfPCell(nested5);
                    nesthousing5.Padding = 0f;
                    tableRup.AddCell(nesthousing5);

                    //BranchName
                    PdfPTable nested6 = new PdfPTable(1);
                    nested6.AddCell(new PdfPCell(new Phrase(D_Branchname, NormalTableFont)));

                    PdfPCell nesthousing6 = new PdfPCell(nested6);
                    nesthousing6.Padding = 0f;
                    tableRup.AddCell(nesthousing6);

                    //BranchCity
                    PdfPTable nested7 = new PdfPTable(1);
                    nested7.AddCell(new PdfPCell(new Phrase(D_BranchCity, NormalTableFont)));

                    PdfPCell nesthousing7 = new PdfPCell(nested7);
                    nesthousing7.Padding = 0f;
                    tableRup.AddCell(nesthousing7);

                }

                PdfPCell header1 = new PdfPCell(tableRup);
                header1.Colspan = 7;
                header1.Border = 0;
                header1.HorizontalAlignment = 0;
                table.AddCell(header1);

                PdfPTable Bottom = new PdfPTable(7);
                Bottom.TotalWidth = 550f;
                float[] widths123 = new float[] { 30f, 80f, 80f, 60f, 180f, 180f, 70f };
                Bottom.SetWidths(widths123);
                Bottom.LockedWidth = true;

                try
                {

                    SqlConnection sqlconn = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);

              
                    SqlCommand sqlcmd2 = new SqlCommand();
                    sqlcmd2.Connection = sqlconn;
                    sqlcmd2.CommandType = CommandType.StoredProcedure;
                    sqlcmd2.CommandText = "GetTotalAmountNew";
                    sqlcmd2.CommandTimeout = 0;


                    SqlParameter Branch_ID = new SqlParameter();
                    Branch_ID.SqlDbType = SqlDbType.Int;
                    Branch_ID.Value = Convert.ToInt32(((UserInfo.structUSERInfo)(SaveUSERInfo)).BranchId);
                    Branch_ID.ParameterName = "@BranchID";
                    sqlcmd2.Parameters.Add(Branch_ID);

                    SqlParameter DS_No = new SqlParameter();
                    DS_No.SqlDbType = SqlDbType.VarChar;
                    DS_No.Value = dsno;
                    DS_No.ParameterName = "@DepositSlipNo";
                    sqlcmd2.Parameters.Add(DS_No);

                    int pClientId2 = 0;
                    if (ddlClientList.SelectedIndex != 0)
                    {
                        pClientId2 = Convert.ToInt32(ddlClientList.SelectedItem.Value);
                    }

                    SqlParameter ClientID3 = new SqlParameter();
                    ClientID3.SqlDbType = SqlDbType.Int;
                    ClientID3.Value = pClientId;
                    ClientID3.ParameterName = "@ClientID";
                    sqlcmd2.Parameters.Add(ClientID3);

                    SqlParameter DepositSlipDate2 = new SqlParameter();
                    DepositSlipDate2.SqlDbType = SqlDbType.VarChar;
                    DepositSlipDate2.Value = txtPickupdate.Text.Trim();
                    DepositSlipDate2.ParameterName = "@DepositSlipDate ";
                    sqlcmd2.Parameters.Add(DepositSlipDate2);



                    sqlconn.Open();

                    SqlDataAdapter sqlda2 = new SqlDataAdapter();
                    sqlda2.SelectCommand = sqlcmd2;
                    DataSet ds2 = new DataSet();
                    sqlda2.Fill(ds2);

                    sqlconn.Close();

                    if (ds2.Tables.Count > 0)
                    {
                        TotalAmount = ds2.Tables[0].Rows[0]["Total"].ToString();
                        wordValue.Value = ds2.Tables[0].Rows[0]["TotalAmount"].ToString();
                    }
                
                }
                catch (Exception ex)
                {
                    lblMessage.Text = ex.Message;
                    lblMessage.CssClass = "ErrorMessage";
                }


                PdfPCell TotalCA = new PdfPCell(new Phrase("Total Amount & Amount In Words:", boldTableFont));
                TotalCA.Colspan = 3;
                TotalCA.HorizontalAlignment = 0;
                Bottom.AddCell(TotalCA);

                PdfPCell TotalCB = new PdfPCell(new Phrase(TotalAmount, boldTableFont));
                TotalCB.Colspan = 1;
                TotalCB.HorizontalAlignment = 2;
                Bottom.AddCell(TotalCB);

                PdfPCell TotalCC = new PdfPCell(new Phrase(wordValue.Value, boldTableFont));
                TotalCC.Colspan = 3;
                TotalCC.HorizontalAlignment = 0;
                Bottom.AddCell(TotalCC);

                PdfPCell TotalCD = new PdfPCell(new Phrase("\n**************************************** E N D  O F  T H E  B A T C H ******************************************", subTitleFont));
                TotalCD.Colspan = 7;
                TotalCD.Border = 0;
                TotalCD.HorizontalAlignment = 1;
                Bottom.AddCell(TotalCD);




                PdfPTable Maintable = new PdfPTable(10);
                Maintable.TotalWidth = 550f;

                
                PdfPCell Maintable5 = new PdfPCell(table);
                Maintable5.Colspan = 10;
                Maintable5.Border = 0;
                Maintable5.HorizontalAlignment = 0;
                Maintable.AddCell(Maintable5);

           
                PdfPCell Maintable6 = new PdfPCell(Bottom);
                Maintable6.Colspan = 10;
                Maintable6.Border = 0;
                Maintable6.HorizontalAlignment = 0;
                Maintable.AddCell(Maintable6);



                Doc.Add(Maintable);



                //Doc.NewPage();
                //Doc.Add(Maintable);



                //Doc.Add(Head);
                //Doc.Add(test);
                //Doc.Add(Tab11);
                //Doc.Add(Tab);
                //Doc.Add(table);
                //Doc.Add(Bottom);
            }
            Doc.Close();
            Response.ContentType = "application/pdf";
            Response.AddHeader("content-disposition", "attachment; filename=Doc1.pdf");
            Response.End();
        }
        else
        {
            lblMessage.Text = "No Deposit Slip found.";
            lblMessage.CssClass = "ErrorMessage";
        }


        //}

        //Doc.Close();
        //Response.ContentType = "application/pdf";
        //Response.AddHeader("content-disposition", "attachment; filename=Doc1.pdf");
        //Response.End();

    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        lblMessage.Text = "";
        if (ddlClientList.SelectedIndex != 0)
        {
            if (txtPickupdate.Text != "")
            {
                if (txtDepositdate.Text != "")
                {
                    Get_BatchFileDetails_Search();
                    Get_PendingCount();
                    pnlButtons.Visible = true;
                }
                else 
                {
                    lblMessage.Text = "Deposit Date Mandatory.";
                    lblMessage.CssClass = "ErrorMessage";
                }
            }
            else
            {
                lblMessage.Text = "Pickup Date Mandatory.";
                lblMessage.CssClass = "ErrorMessage";
            }
           
        }
        else 
        {
            lblMessage.Text="Select One Client.";
            lblMessage.CssClass = "ErrorMessage";
        }


    }

    protected void btnGenerateDS_Click(object sender, EventArgs e)
    
    {
        lblMessage.Text = "";
        if (ddlClientList.SelectedIndex != 0)
        {
            if (txtPickupdate.Text != "")
            {
                if (txtDepositdate.Text != "")
                        {


                            //if (hdnPendingCount.Value != null && Convert.ToInt32(hdnPendingCount.Value) == 0)
                            //{
                              


                                CheckDSExistence();

                                if (ds_exists == "NO")
                                {
                                    CheckPDC();
                                    Insert_DepositSlipInfo();
                                    GeneratePdfReport();
                                }
                                else
                                {
                                   
                                    GeneratePdfReport();
                                }


                            //}
                            //else
                            //{
                            //    lblMessage.Text = "Deposit Slip cannot be generated.Complete Pending batch(s) first.";
                            //    lblMessage.CssClass = "ErrorMessage";
                            //}
                        }
                else
                {
                    lblMessage.Text = "Deposit Date Mandatory.";
                    lblMessage.CssClass = "ErrorMessage";
                }
            }
            else
            {
                lblMessage.Text = "Pickup Date Mandatory.";
                lblMessage.CssClass = "ErrorMessage";
            }

        }
        else
        {
            lblMessage.Text = "Select One Client.";
            lblMessage.CssClass = "ErrorMessage";
        }
       
        //GenerateDepositSlip_pdf();
        //Response.Redirect("GenerateDepositSlip.aspx?BN=" + hdnTransID.Value.Trim(), true); 

    }

    private void CheckPDC()
    {
        try
        {
            Object SaveUSERInfo = (Object)Session["UserInfo"];
            //IFormatProvider culture = new CultureInfo("en-US", true);


            SqlConnection sqlcon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);


            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlcon;
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.CommandText = "UpdatePDC_mod";
            sqlcmd.CommandTimeout = 0;



            SqlParameter BranchID = new SqlParameter();
            BranchID.SqlDbType = SqlDbType.Int;
            BranchID.Value = Convert.ToInt32(((UserInfo.structUSERInfo)(SaveUSERInfo)).BranchId);
            BranchID.ParameterName = "@BranchID";
            sqlcmd.Parameters.Add(BranchID);

            int pClientId = 0;
            if (ddlClientList.SelectedIndex != 0)
            {
                pClientId = Convert.ToInt32(ddlClientList.SelectedItem.Value);
            }

            SqlParameter ClientID = new SqlParameter();
            ClientID.SqlDbType = SqlDbType.Int;
            ClientID.Value = pClientId;
            ClientID.ParameterName = "@ClientID";
            sqlcmd.Parameters.Add(ClientID);

            SqlParameter PickupDate = new SqlParameter();
            PickupDate.SqlDbType = SqlDbType.VarChar;
            PickupDate.Value = txtPickupdate.Text.Trim();//DateTime.ParseExact(txtDepDate.Text.Trim() + 2013, "ddMMyyyy", CultureInfo.InvariantCulture);//
            PickupDate.ParameterName = "@PickupDate";
            sqlcmd.Parameters.Add(PickupDate);

            SqlParameter DepositDate = new SqlParameter();
            DepositDate.SqlDbType = SqlDbType.VarChar;
            DepositDate.Value = txtDepositdate.Text.Trim();//DateTime.ParseExact(txtDepDate.Text.Trim() + 2013, "ddMMyyyy", CultureInfo.InvariantCulture);//
            DepositDate.ParameterName = "@DepositDate";
            sqlcmd.Parameters.Add(DepositDate);

            sqlcon.Open();
            SqlDataAdapter sqlda = new SqlDataAdapter();
            sqlda.SelectCommand = sqlcmd;
            DataSet ds = new DataSet();
            sqlda.Fill(ds);
            sqlcon.Close();

        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
        }

        finally
        { 
        }

    }

    private void CheckDSExistence()
    {
        Object SaveUSERInfo = (Object)Session["UserInfo"];

        SqlConnection sqlcon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);


        SqlCommand sqlcmd = new SqlCommand();
        sqlcmd.Connection = sqlcon;
        sqlcmd.CommandType = CommandType.StoredProcedure;
        sqlcmd.CommandText = "CheckIfDsExists";
        sqlcmd.CommandTimeout = 0;

  

        SqlParameter BranchID = new SqlParameter();
        BranchID.SqlDbType = SqlDbType.Int;
        BranchID.Value = Convert.ToInt32(((UserInfo.structUSERInfo)(SaveUSERInfo)).BranchId);
        BranchID.ParameterName = "@BranchID";
        sqlcmd.Parameters.Add(BranchID);

        int pClientId = 0;
        if (ddlClientList.SelectedIndex != 0)
        {
            pClientId = Convert.ToInt32(ddlClientList.SelectedItem.Value);
        }

        SqlParameter ClientID = new SqlParameter();
        ClientID.SqlDbType = SqlDbType.Int;
        ClientID.Value = pClientId;
        ClientID.ParameterName = "@ClientID";
        sqlcmd.Parameters.Add(ClientID);

        SqlParameter PickupDate = new SqlParameter();
        PickupDate.SqlDbType = SqlDbType.VarChar;
        PickupDate.Value = txtPickupdate.Text.Trim();
        PickupDate.ParameterName = "@PickupDate";
        sqlcmd.Parameters.Add(PickupDate);

        sqlcon.Open();
        SqlDataAdapter sqlda = new SqlDataAdapter();
        sqlda.SelectCommand = sqlcmd;
        DataSet ds = new DataSet();
        sqlda.Fill(ds);
        sqlcon.Close();


        if (ds.Tables.Count > 0)
        {
            //lblMessage.Visible = true;
            ds_exists = ds.Tables[0].Rows[0]["msg"].ToString();


        }
        else
        {
            lblMessage.Visible = true;
            lblMessage.Text = "No Record Found...!!!";
        }
    }

    public string[] arr;
    public string[] arr2;
    public string Is_SBI;
    public int dscount2=0;
    public int dscount3=1;
    public string ds_exists;

    
    private string Get_DateFormat(string cDate, string cDateFormat)
    {
        try
        {
            string strDate = cDate;
            string[] strArrDate = strDate.Split('/');

            if (strArrDate.Length > 0)
            {
                if (cDateFormat == "yyyy/MM/dd")
                {
                    strDate = strArrDate[2] + "/" + strArrDate[1] + "/" + strArrDate[0];

                }
                else if (cDateFormat == "MM/dd/yyyy")
                {
                    strDate = strArrDate[1] + "/" + strArrDate[0] + "/" + strArrDate[2];

                }
            }

            return strDate;
        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
            lblMessage.CssClass = "ErrorMessage";
            lblMessage.Visible = true;
            return "";
        }

        finally
        {
        
        }

    }
    
    private void GenerateDepositSlip_pdf()
    {
        // Create a Document object
        var document = new Document(PageSize.A4, 50, 50, 25, 25);

        // Create a new PdfWriter object, specifying the output stream
        var output = new FileStream(Server.MapPath("FirstPDF.pdf"), FileMode.Create);
        var writer = PdfWriter.GetInstance(document, output);

        // Open the Document for writing
        document.Open();

        document.Add(new Paragraph("My first PDF"));
        //... Step 3: Add elements to the document! ...

        // Close the Document - this saves the document contents to the output stream
        document.Close();
    }

    //private void Validation11()
    //{
    //    btnGenerateDS.Attributes.Add("onclick", "javascript:return Convert();");
    //}

    //private void Validation12()
    //{
    //    btnGenerateDepositSlipGrandSummary.Attributes.Add("onclick", "javascript:return ConvertSummary();");
    //}

    private void GeneratePdfReport()
    {
        
        Object SaveUSERInfo = (Object)Session["UserInfo"];

        try
        {
            SqlConnection sqlcon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);

      
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlcon;
            sqlcmd.CommandType = CommandType.StoredProcedure;
            //sqlcmd.CommandText = "Get_DSno";
            sqlcmd.CommandText = "Get_DSno_mod";
            sqlcmd.CommandTimeout = 0;

      

            SqlParameter BranchID = new SqlParameter();
            BranchID.SqlDbType = SqlDbType.Int;
            BranchID.Value = Convert.ToInt32(((UserInfo.structUSERInfo)(SaveUSERInfo)).BranchId);
            BranchID.ParameterName = "@BranchId";
            sqlcmd.Parameters.Add(BranchID);

            int pClientId = 0;
            if (ddlClientList.SelectedIndex != 0)
            {
                pClientId = Convert.ToInt32(ddlClientList.SelectedItem.Value);
            }

            SqlParameter ClientID = new SqlParameter();
            ClientID.SqlDbType = SqlDbType.Int;
            ClientID.Value = pClientId;
            ClientID.ParameterName = "@ClientID";
            sqlcmd.Parameters.Add(ClientID);

            SqlParameter DepositSlipDate = new SqlParameter();
            DepositSlipDate.SqlDbType = SqlDbType.VarChar;
            DepositSlipDate.Value = txtPickupdate.Text.Trim();
            DepositSlipDate.ParameterName = "@DepositSlipDate ";
            sqlcmd.Parameters.Add(DepositSlipDate);

            sqlcon.Open();
            SqlDataAdapter sqlda = new SqlDataAdapter();
            sqlda.SelectCommand = sqlcmd;
            DataTable dt = new DataTable();
            sqlda.Fill(dt);
            sqlcon.Close();



            if (dt.Rows.Count > 0)
            {
                arr = new string[dt.Rows.Count];
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    arr[i] = dt.Rows[i]["DepositSlipNo"].ToString().Trim();
                }
                Length = arr.Length;
            }
        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
            lblMessage.CssClass = "ErrorMessage";
        }

        var titleFont = FontFactory.GetFont("Arial", 9, Font.BOLD);
        var subTitleFont = FontFactory.GetFont("Arial", 8, Font.NORMAL);
        var boldTableFont = FontFactory.GetFont("Arial", 7, Font.BOLD);
        var NormalTableFont = FontFactory.GetFont("Arial", 7, Font.NORMAL);
        var endingMessageFont = FontFactory.GetFont("Arial", 7, Font.ITALIC);
        var BoldFont8 = FontFactory.GetFont("Arial", 6, Font.BOLD);
        Document Doc = new Document(PageSize.A4);

        PdfWriter.GetInstance(Doc, Response.OutputStream);

        Doc.AddCreator("This Application");
        Doc.AddAuthor("Me");
        Doc.Open();

       


        Phrase phr = new Phrase(""); //empty phrase for page numbering
        if (Length > 0)
        {
            for (int i = 0; i < Length; i++)
            {
                Doc.NewPage();
                //Get_Headers();
                string dsno = arr[i].ToString().Trim();

                SqlConnection sqlcon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);

         
                SqlCommand sqlcmd = new SqlCommand();
                sqlcmd.Connection = sqlcon;
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.CommandText = "Get_HeaderForDS";
                sqlcmd.CommandTimeout = 0;

             

                SqlParameter DepositSlipNo = new SqlParameter();
                DepositSlipNo.SqlDbType = SqlDbType.VarChar;
                DepositSlipNo.Value = dsno;
                DepositSlipNo.ParameterName = "@DepositSlipNo";
                sqlcmd.Parameters.Add(DepositSlipNo);

                SqlParameter BranchID = new SqlParameter();
                BranchID.SqlDbType = SqlDbType.VarChar;
                BranchID.Value = Convert.ToInt32(((UserInfo.structUSERInfo)(SaveUSERInfo)).BranchId);
                BranchID.ParameterName = "@BranchID";
                sqlcmd.Parameters.Add(BranchID);

                int pClientId = 0;
                if (ddlClientList.SelectedIndex != 0)
                {
                    pClientId = Convert.ToInt32(ddlClientList.SelectedItem.Value);
                }

                SqlParameter ClientID = new SqlParameter();
                ClientID.SqlDbType = SqlDbType.Int;
                ClientID.Value = pClientId;
                ClientID.ParameterName = "@ClientID";
                sqlcmd.Parameters.Add(ClientID);

                SqlParameter PickupDate = new SqlParameter();
                PickupDate.SqlDbType = SqlDbType.VarChar;
                PickupDate.Value = txtPickupdate.Text.Trim();
                PickupDate.ParameterName = "@PickupDate ";
                sqlcmd.Parameters.Add(PickupDate);

                SqlParameter DepositSlipDatenew = new SqlParameter();
                DepositSlipDatenew.SqlDbType = SqlDbType.VarChar;
                DepositSlipDatenew.Value = txtDepositdate.Text.Trim();
                DepositSlipDatenew.ParameterName = "@DepositSlipDate ";
                sqlcmd.Parameters.Add(DepositSlipDatenew);


                sqlcon.Open();
                SqlDataAdapter sqlda = new SqlDataAdapter();
                sqlda.SelectCommand = sqlcmd;
                DataSet ds = new DataSet();
                sqlda.Fill(ds);
                sqlcon.Close();

                if (ds.Tables.Count > 0)
                {
               
                    Deposite_SlipNo = ds.Tables[0].Rows[0]["DepositSlipNo"].ToString();
                    Type_of_Clearing = ds.Tables[0].Rows[0]["Type_of_Clearing"].ToString();

                    Deposit_Date = ds.Tables[0].Rows[0]["DepositDate"].ToString();
                    Pickup_Date = ds.Tables[0].Rows[0]["ReportDate"].ToString();
                    IntrumentType = ds.Tables[0].Rows[0]["IntrumentType"].ToString();

                    BankName = ds.Tables[0].Rows[0]["Name_of_customer"].ToString();
             
                    BranchCity = ds.Tables[0].Rows[0]["Location"].ToString();

                    hdnAccountNo.Value = ds.Tables[0].Rows[0]["AccountNo"].ToString();


        




                    HdnDsCount.Value = ds.Tables[1].Rows[0]["chqcount"].ToString();

                }
                chqCount = Convert.ToInt32(HdnDsCount.Value);


                PdfPTable Head = new PdfPTable(7);
                Head.TotalWidth = 580f;
                float[] widths12 = new float[] { 40f, 40f, 80f, 80f, 100f, 80f, 100f };
                Head.SetWidths(widths12);
                Head.LockedWidth = true;

                PdfPCell C1 = new PdfPCell(new Phrase("Deposit Number :", boldTableFont));
                C1.Colspan = 2;
                C1.Border = 0;
                C1.HorizontalAlignment = 0;
                Head.AddCell(C1);

                PdfPCell C11 = new PdfPCell(new Phrase(Deposite_SlipNo, NormalTableFont));
                C11.Colspan = 3;
                C11.Border = 0;
                C11.HorizontalAlignment = 0;
                Head.AddCell(C11);

                int page = i + 1;

                PdfPCell C2 = new PdfPCell(new Phrase("Page No : " + page, boldTableFont));
                C2.Colspan = 2;
                C2.Border = 0;
                C2.HorizontalAlignment = 2;
                Head.AddCell(C2);


                PdfPTable test = new PdfPTable(7);
                test.TotalWidth = 550f;
                float[] widths11 = new float[] { 40f, 50f, 80f, 100f, 100f, 100f, 60f };
                test.SetWidths(widths11);
                test.LockedWidth = true;




                ///////RUpesh
                PdfPTable table = new PdfPTable(7);
                table.TotalWidth = 550f;
                float[] widths = new float[] { 30f, 80f, 80f, 60f, 180f, 180f, 70f };// Imp
                table.SetWidths(widths);
                table.LockedWidth = true;

                PdfPCell header = new PdfPCell(new Phrase("D E P O S I T  P A Y - I N - S L I P\n\n", titleFont));
                header.Colspan = 7;
                header.Border = 0;
                header.HorizontalAlignment = 1;
                test.AddCell(header);

                PdfPCell Cell1 = new PdfPCell(new Phrase("Type of Clearing :", boldTableFont));
                Cell1.Colspan = 2;
                Cell1.Border = 0;
                Cell1.HorizontalAlignment = 0;
                test.AddCell(Cell1);

                PdfPCell Cell11 = new PdfPCell(new Phrase(Type_of_Clearing, NormalTableFont));
                Cell11.Colspan = 2;
                Cell11.Border = 0;
                Cell11.HorizontalAlignment = 0;
                test.AddCell(Cell11);

                PdfPCell Cell2 = new PdfPCell(new Phrase("Report Date   :", boldTableFont));
                Cell2.Colspan = 2;
                Cell2.Border = 0;
                Cell2.HorizontalAlignment = 2;
                test.AddCell(Cell2);

                // PdfPCell Cell21 = new PdfPCell(new Phrase(Pickup_Date, NormalTableFont));
                PdfPCell Cell21 = new PdfPCell(new Phrase(txtPickupdate.Text.Trim(), NormalTableFont));
                Cell21.Colspan = 1;
                Cell21.Border = 0;
                Cell21.HorizontalAlignment = 0;
                test.AddCell(Cell21);


                PdfPCell Cell3 = new PdfPCell(new Phrase("Instrument Type :", boldTableFont));
                Cell3.Colspan = 2;
                Cell3.Border = 0;
                Cell3.HorizontalAlignment = 0;
                test.AddCell(Cell3);

                PdfPCell Cell31 = new PdfPCell(new Phrase(IntrumentType, NormalTableFont));
                Cell31.Colspan = 2;
                Cell31.Border = 0;
                Cell31.HorizontalAlignment = 0;
                test.AddCell(Cell31);


                PdfPCell Cell4 = new PdfPCell(new Phrase(" Deposit Date :", boldTableFont));
                Cell4.Colspan = 2;
                Cell4.Border = 0;
                Cell4.HorizontalAlignment = 2;
                test.AddCell(Cell4);

                PdfPCell Cell41 = new PdfPCell(new Phrase(txtDepositdate.Text.Trim(), NormalTableFont));
                Cell41.Colspan = 1;
                Cell41.Border = 0;
                Cell41.HorizontalAlignment = 0;
                test.AddCell(Cell41);

                PdfPTable Tab11 = new PdfPTable(7);
                Tab11.TotalWidth = 550f;
                Tab11.LockedWidth = true;

                PdfPCell Cell51 = new PdfPCell(new Phrase("\nPlease quote the deposit serial number in Bank Statement for Credits and Deposit slip Serial number/Instrument sequence number is Bank Statement, debits on account of cheque returned unpaid. Please also mention the same in your returned cheque advice.\n\n", NormalTableFont));
                Cell51.Colspan = 7;
                Cell51.Border = 0;
                Cell51.HorizontalAlignment = 0;
                Tab11.AddCell(Cell51);

                PdfPTable Tab = new PdfPTable(7);
                Tab.TotalWidth = 550f;
                float[] widthsAA = new float[] { 100f, 55f, 80f, 60f, 180f, 180f, 70f };// Imp
                Tab.SetWidths(widthsAA);
                Tab.LockedWidth = true;

                PdfPCell Cell6 = new PdfPCell(new Phrase("  Paid to CREDIT OF :", boldTableFont));
                Cell6.Colspan = 2;
                Cell6.Border = 0;
                Cell6.HorizontalAlignment = 2;
                Tab.AddCell(Cell6);

                PdfPCell Cell61 = new PdfPCell(new Phrase(BankName, NormalTableFont));
                Cell61.Colspan = 5;
                Cell61.Border = 0;
                Cell61.HorizontalAlignment = 0;
                Tab.AddCell(Cell61);

                PdfPCell Cell7 = new PdfPCell(new Phrase("Name of the Customer :", boldTableFont));
                Cell7.Colspan = 2;
                Cell7.Border = 0;
                Cell7.HorizontalAlignment = 2;
                Tab.AddCell(Cell7);

                PdfPCell Cell71 = new PdfPCell(new Phrase("SBI CPSL", NormalTableFont));
                Cell71.Colspan = 5;
                Cell71.Border = 0;
                Cell71.HorizontalAlignment = 0;
                Tab.AddCell(Cell71);

                PdfPCell Cell8 = new PdfPCell(new Phrase("             At :", boldTableFont));
                Cell8.Colspan = 2;
                Cell8.Border = 0;
                Cell8.HorizontalAlignment = 2;
                Tab.AddCell(Cell8);

                PdfPCell Cell81 = new PdfPCell(new Phrase(BranchCity, NormalTableFont));
                Cell81.Colspan = 5;
                Cell81.Border = 0;
                Cell81.HorizontalAlignment = 0;
                Tab.AddCell(Cell81);


                PdfPCell Cell9 = new PdfPCell(new Phrase("SBI CMP Client Code:" + hdnAccountNo.Value, boldTableFont));
                Cell9.Colspan = 7;
                Cell9.Border = 0;
                Cell9.HorizontalAlignment = 0;
                Tab.AddCell(Cell9);

                /////Rupesh

                PdfPTable tableRup = new PdfPTable(7);
                tableRup.TotalWidth = 550f;
                float[] widthsRup = new float[] { 30f, 80f, 80f, 60f, 180f, 180f, 70f };// Imp
                tableRup.SetWidths(widthsRup);
                tableRup.LockedWidth = true;

                PdfPCell TestRup1 = new PdfPCell(Head);
                TestRup1.Colspan = 7;
                TestRup1.Border = 0;
                TestRup1.HorizontalAlignment = 0;
                tableRup.AddCell(TestRup1);

                PdfPCell TestRup2 = new PdfPCell(test);
                TestRup2.Colspan = 7;
                TestRup2.Border = 0;
                TestRup2.HorizontalAlignment = 0;
                tableRup.AddCell(TestRup2);

                PdfPCell TestRup3 = new PdfPCell(Tab11);
                TestRup3.Colspan = 7;
                TestRup3.Border = 0;
                TestRup3.HorizontalAlignment = 0;
                tableRup.AddCell(TestRup3);

                PdfPCell TestRup4 = new PdfPCell(Tab);
                TestRup4.Colspan = 7;
                TestRup4.Border = 0;
                TestRup4.HorizontalAlignment = 0;
                tableRup.AddCell(TestRup4);

                tableRup.AddCell(new PdfPCell(new Phrase("Sr No.", boldTableFont)));
                tableRup.AddCell(new PdfPCell(new Phrase("Instrument Number", boldTableFont)));
                tableRup.AddCell(new PdfPCell(new Phrase("Instrument Date", boldTableFont)));
                tableRup.AddCell(new PdfPCell(new Phrase("Amount", boldTableFont)));
                tableRup.AddCell(new PdfPCell(new Phrase("Bank Drawn", boldTableFont)));
                tableRup.AddCell(new PdfPCell(new Phrase("Branch Drawn", boldTableFont)));
                tableRup.AddCell(new PdfPCell(new Phrase("City Name", boldTableFont)));

                for (int j = 0; j <= chqCount - 1; j++)
                {

                    //HdnNO.Value = Convert.ToInt32(i).ToString();
                    //GetDepositSlipData();
                    //Get_Details();

                    try
                    {
                        SqlConnection sqlCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);

                     
                        SqlCommand sqlCmd = new SqlCommand();
                        sqlCmd.Connection = sqlcon;
                        sqlCmd.CommandType = CommandType.StoredProcedure;
                        //sqlCmd.CommandText = "Get_DSdetails";//08 july 2013 nikhil test
                        sqlCmd.CommandText = "Get_DSdetails_mod";
                        sqlCmd.CommandTimeout = 0;


                    

                        //SqlParameter DepositSlipNo = new SqlParameter();
                        //DepositSlipNo.SqlDbType = SqlDbType.VarChar;
                        //DepositSlipNo.Value = dsno;
                        //DepositSlipNo.ParameterName = "@DepositSlipNo";
                        //sqlcmd.Parameters.Add(DepositSlipNo);

                        SqlParameter DepositeSlipNo = new SqlParameter();
                        DepositeSlipNo.SqlDbType = SqlDbType.VarChar;
                        DepositeSlipNo.Value = Deposite_SlipNo.ToString();
                        DepositeSlipNo.ParameterName = "@DepositSlipNo";
                        sqlCmd.Parameters.Add(DepositeSlipNo);

                        SqlParameter BranchID2 = new SqlParameter();
                        BranchID2.SqlDbType = SqlDbType.VarChar;
                        BranchID2.Value = Convert.ToInt32(((UserInfo.structUSERInfo)(SaveUSERInfo)).BranchId);
                        BranchID2.ParameterName = "@BranchID ";
                        sqlCmd.Parameters.Add(BranchID2);

                        int pClientId2 = 0;
                        if (ddlClientList.SelectedIndex != 0)
                        {
                            pClientId2 = Convert.ToInt32(ddlClientList.SelectedItem.Value);
                        }

                        SqlParameter ClientID2 = new SqlParameter();
                        ClientID2.SqlDbType = SqlDbType.Int;
                        ClientID2.Value = pClientId2;
                        ClientID2.ParameterName = "@ClientID";
                        sqlCmd.Parameters.Add(ClientID2);

                        SqlParameter DepositSlipDate = new SqlParameter();
                        DepositSlipDate.SqlDbType = SqlDbType.VarChar;
                        DepositSlipDate.Value = txtPickupdate.Text.Trim();
                        DepositSlipDate.ParameterName = "@DepositSlipDate ";
                        sqlCmd.Parameters.Add(DepositSlipDate);


                        sqlcon.Open();
                        SqlDataAdapter sqlDa = new SqlDataAdapter();
                        sqlDa.SelectCommand = sqlCmd;
                        DataSet Ds = new DataSet();
                        sqlDa.Fill(Ds);
                        sqlcon.Close();

                        if (Ds.Tables.Count > 0)
                        {
                            SerialNo = Ds.Tables[0].Rows[j]["SerialNo"].ToString();
                            ChequeNo = Ds.Tables[0].Rows[j]["ChequeNo"].ToString();
                            ChequeDate = Ds.Tables[0].Rows[j]["ChequeDate"].ToString();
                            ChequeAmt = Ds.Tables[0].Rows[j]["ChequeAmt"].ToString();
                            D_Bankname = Ds.Tables[0].Rows[j]["BankName"].ToString();
                            D_Branchname = Ds.Tables[0].Rows[j]["BranchName"].ToString();
                            D_BranchCity = Ds.Tables[0].Rows[j]["BranchCity"].ToString();
                        }

                    }
                    catch (Exception ex)
                    {
                        lblMessage.Text = ex.Message;
                        lblMessage.CssClass = "ErrorMessage";
                    }


                    //SerialNo
                    PdfPTable nested = new PdfPTable(1);
                    nested.AddCell(new PdfPCell(new Phrase(SerialNo, NormalTableFont)));

                    PdfPCell nesthousing = new PdfPCell(nested);
                    nesthousing.Padding = 0f;
                    tableRup.AddCell(nesthousing);

                    //Instrument_Number             
                    PdfPTable nested2 = new PdfPTable(1);
                    nested2.AddCell(new PdfPCell(new Phrase(ChequeNo, NormalTableFont)));

                    PdfPCell nesthousing2 = new PdfPCell(nested2);
                    nesthousing2.Padding = 0f;
                    tableRup.AddCell(nesthousing2);

                    // Instrument_Date
                    PdfPTable nested3 = new PdfPTable(1);
                    nested3.AddCell(new PdfPCell(new Phrase(ChequeDate, NormalTableFont)));

                    PdfPCell nesthousing3 = new PdfPCell(nested3);
                    nesthousing3.Padding = 0f;
                    tableRup.AddCell(nesthousing3);

                    //Cheque_Ammount
                    PdfPTable nested4 = new PdfPTable(1);
                    //nested4.HorizontalAlignment = 2;
                    PdfPCell nesthou4 = new PdfPCell(new Phrase(ChequeAmt, NormalTableFont));
                    nesthou4.HorizontalAlignment = 2;
                    nested4.AddCell(nesthou4);


                    PdfPCell nesthousing4 = new PdfPCell(nested4);
                    nesthousing4.Padding = 0f;
                    tableRup.AddCell(nesthousing4);

                    //BankName
                    PdfPTable nested5 = new PdfPTable(1);
                    nested5.AddCell(new PdfPCell(new Phrase(D_Bankname, NormalTableFont)));

                    PdfPCell nesthousing5 = new PdfPCell(nested5);
                    nesthousing5.Padding = 0f;
                    tableRup.AddCell(nesthousing5);

                    //BranchName
                    PdfPTable nested6 = new PdfPTable(1);
                    nested6.AddCell(new PdfPCell(new Phrase(D_Branchname, NormalTableFont)));

                    PdfPCell nesthousing6 = new PdfPCell(nested6);
                    nesthousing6.Padding = 0f;
                    tableRup.AddCell(nesthousing6);

                    //BranchCity
                    PdfPTable nested7 = new PdfPTable(1);
                    nested7.AddCell(new PdfPCell(new Phrase(D_BranchCity, NormalTableFont)));

                    PdfPCell nesthousing7 = new PdfPCell(nested7);
                    nesthousing7.Padding = 0f;
                    tableRup.AddCell(nesthousing7);

                }

                PdfPCell header1 = new PdfPCell(tableRup);
                header1.Colspan = 7;
                header1.Border = 0;
                header1.HorizontalAlignment = 0;
                table.AddCell(header1);

                PdfPTable Bottom = new PdfPTable(7);
                Bottom.TotalWidth = 550f;
                float[] widths123 = new float[] { 30f, 80f, 80f, 60f, 180f, 180f, 70f };
                Bottom.SetWidths(widths123);
                Bottom.LockedWidth = true;

                try
                {

                    SqlConnection sqlconn = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);

                  
                    SqlCommand sqlcmd2 = new SqlCommand();
                    sqlcmd2.Connection = sqlconn;
                    sqlcmd2.CommandType = CommandType.StoredProcedure;
                    sqlcmd2.CommandText = "GetTotalAmountNew";
                    sqlcmd2.CommandTimeout = 0;


                

                    SqlParameter Branch_ID = new SqlParameter();
                    Branch_ID.SqlDbType = SqlDbType.Int;
                    Branch_ID.Value = Convert.ToInt32(((UserInfo.structUSERInfo)(SaveUSERInfo)).BranchId);
                    Branch_ID.ParameterName = "@BranchID";
                    sqlcmd2.Parameters.Add(Branch_ID);

                    SqlParameter DS_No = new SqlParameter();
                    DS_No.SqlDbType = SqlDbType.VarChar;
                    DS_No.Value = dsno;
                    DS_No.ParameterName = "@DepositSlipNo";
                    sqlcmd2.Parameters.Add(DS_No);

                    int pClientId2 = 0;
                    if (ddlClientList.SelectedIndex != 0)
                    {
                        pClientId2 = Convert.ToInt32(ddlClientList.SelectedItem.Value);
                    }

                    SqlParameter ClientID3 = new SqlParameter();
                    ClientID3.SqlDbType = SqlDbType.Int;
                    ClientID3.Value = pClientId;
                    ClientID3.ParameterName = "@ClientID";
                    sqlcmd2.Parameters.Add(ClientID3);

                    SqlParameter DepositSlipDate2 = new SqlParameter();
                    DepositSlipDate2.SqlDbType = SqlDbType.VarChar;
                    DepositSlipDate2.Value = txtPickupdate.Text.Trim();
                    DepositSlipDate2.ParameterName = "@DepositSlipDate ";
                    sqlcmd2.Parameters.Add(DepositSlipDate2);


                    sqlconn.Open();
                    SqlDataAdapter sqlda2 = new SqlDataAdapter();
                    sqlda2.SelectCommand = sqlcmd2;
                    DataSet ds2 = new DataSet();
                    sqlda2.Fill(ds2);
                    if (ds2.Tables.Count > 0)
                    {
                        TotalAmount = ds2.Tables[0].Rows[0]["Total"].ToString();
                        wordValue.Value = ds2.Tables[0].Rows[0]["TotalAmount"].ToString();
                    }
                    sqlconn.Close();
                }
                catch (Exception ex)
                {
                    lblMessage.Text = ex.Message;
                    lblMessage.CssClass = "ErrorMessage";
                }


                PdfPCell TotalCA = new PdfPCell(new Phrase("Total Amount & Amount In Words:", boldTableFont));
                TotalCA.Colspan = 3;
                TotalCA.HorizontalAlignment = 0;
                Bottom.AddCell(TotalCA);

                PdfPCell TotalCB = new PdfPCell(new Phrase(TotalAmount, boldTableFont));
                TotalCB.Colspan = 1;
                TotalCB.HorizontalAlignment = 2;
                Bottom.AddCell(TotalCB);

                PdfPCell TotalCC = new PdfPCell(new Phrase(wordValue.Value, boldTableFont));
                TotalCC.Colspan = 3;
                TotalCC.HorizontalAlignment = 0;
                Bottom.AddCell(TotalCC);

                PdfPCell TotalCD = new PdfPCell(new Phrase("\n**************************************** E N D  O F  T H E  B A T C H ******************************************", subTitleFont));
                TotalCD.Colspan = 7;
                TotalCD.Border = 0;
                TotalCD.HorizontalAlignment = 1;
                Bottom.AddCell(TotalCD);




                PdfPTable Maintable = new PdfPTable(10);
                Maintable.TotalWidth = 550f;

                PdfPCell Maintable5 = new PdfPCell(table);
                Maintable5.Colspan = 10;
                Maintable5.Border = 0;
                Maintable5.HorizontalAlignment = 0;
                Maintable.AddCell(Maintable5);

                PdfPCell Maintable6 = new PdfPCell(Bottom);
                Maintable6.Colspan = 10;
                Maintable6.Border = 0;
                Maintable6.HorizontalAlignment = 0;
                Maintable.AddCell(Maintable6);



                Doc.Add(Maintable);

                                
            }
            Doc.Close();
            Response.ContentType = "application/pdf";
            Response.AddHeader("content-disposition", "attachment; filename=Doc1.pdf");
            Response.End();
        }
        else
        {
            lblMessage.Text = "No Deposit Slip found.";
            lblMessage.CssClass = "ErrorMessage";
        }

       
        //}

        //Doc.Close();
        //Response.ContentType = "application/pdf";
        //Response.AddHeader("content-disposition", "attachment; filename=Doc1.pdf");
        //Response.End();

    }

    private void Get_Details()
    {


    }

    private void Get_Headers()
    {

    }

    private void Insert_DepositSlipInfoPDCONLY()
    {
        try
        {

            Object SaveUSERInfo = (Object)Session["UserInfo"];

            SqlConnection sqlcon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);


            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlcon;
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.CommandText = "Insert_DepositSlipInfo_Rupesh";
            sqlcmd.CommandTimeout = 0;



            SqlParameter BranchID = new SqlParameter();
            BranchID.SqlDbType = SqlDbType.Int;
            BranchID.Value = Convert.ToInt32(((UserInfo.structUSERInfo)(SaveUSERInfo)).BranchId);
            BranchID.ParameterName = "@BranchID";
            sqlcmd.Parameters.Add(BranchID);

            //NIKHIL 14 june 2013
            int pClientId = 0;
            if (ddlClientList.SelectedIndex != 0)
            {
                pClientId = Convert.ToInt32(ddlClientList.SelectedItem.Value);
            }

            SqlParameter ClientID = new SqlParameter();
            ClientID.SqlDbType = SqlDbType.Int;
            ClientID.Value = pClientId;
            ClientID.ParameterName = "@ClientID";
            sqlcmd.Parameters.Add(ClientID);
            //END

            SqlParameter ChequePickeupDate_mdy = new SqlParameter();
            ChequePickeupDate_mdy.SqlDbType = SqlDbType.VarChar;
            ChequePickeupDate_mdy.Value = txtPickupdate.Text.Trim();
            ChequePickeupDate_mdy.ParameterName = "@ChequePickeupDate_mdy";
            sqlcmd.Parameters.Add(ChequePickeupDate_mdy);

            SqlParameter UserID = new SqlParameter();
            UserID.SqlDbType = SqlDbType.VarChar;
            UserID.Value = Convert.ToString(((UserInfo.structUSERInfo)(SaveUSERInfo)).UserId);
            UserID.ParameterName = "@UserID";
            sqlcmd.Parameters.Add(UserID);

            SqlParameter VarResult = new SqlParameter();
            VarResult.SqlDbType = SqlDbType.VarChar;
            VarResult.Value = txtPickupdate.Text;
            VarResult.ParameterName = "@VarResult";
            VarResult.Size = 200;
            VarResult.Direction = ParameterDirection.Output;
            sqlcmd.Parameters.Add(VarResult);


            sqlcon.Open();

            sqlcmd.ExecuteNonQuery();
            string RowEffected = Convert.ToString(sqlcmd.Parameters["@VarResult"].Value);

            sqlcon.Close();

            if (RowEffected != "")
            {
                lblMessage.Text = RowEffected;
                lblMessage.CssClass = "SuccessMessage";

                //Get_HeaderDetails();
            }
        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
            lblMessage.CssClass = "ErrorMessage";
        }
        finally
        { 
        }
    }

    

    private void Insert_DepositSlipInfo()
    {
        try
        {

            Object SaveUSERInfo = (Object)Session["UserInfo"];

            SqlConnection sqlcon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);


            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlcon;
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.CommandText = "Insert_DepositSlipInfo";
            sqlcmd.CommandTimeout = 0;



            SqlParameter BranchID = new SqlParameter();
            BranchID.SqlDbType = SqlDbType.Int;
            BranchID.Value = Convert.ToInt32(((UserInfo.structUSERInfo)(SaveUSERInfo)).BranchId);
            BranchID.ParameterName = "@BranchID";
            sqlcmd.Parameters.Add(BranchID);


            int pClientId = 0;
            if (ddlClientList.SelectedIndex != 0)
            {
                pClientId = Convert.ToInt32(ddlClientList.SelectedItem.Value);
            }

            SqlParameter ClientID = new SqlParameter();
            ClientID.SqlDbType = SqlDbType.Int;
            ClientID.Value = pClientId;
            ClientID.ParameterName = "@ClientID";
            sqlcmd.Parameters.Add(ClientID);


            SqlParameter ChequePickeupDate_mdy = new SqlParameter();
            ChequePickeupDate_mdy.SqlDbType = SqlDbType.VarChar;
            ChequePickeupDate_mdy.Value = txtPickupdate.Text.Trim();
            ChequePickeupDate_mdy.ParameterName = "@ChequePickeupDate_mdy";
            sqlcmd.Parameters.Add(ChequePickeupDate_mdy);

            SqlParameter UserID = new SqlParameter();
            UserID.SqlDbType = SqlDbType.VarChar;
            UserID.Value = Convert.ToString(((UserInfo.structUSERInfo)(SaveUSERInfo)).UserId);
            UserID.ParameterName = "@UserID";
            sqlcmd.Parameters.Add(UserID);

            SqlParameter VarResult = new SqlParameter();
            VarResult.SqlDbType = SqlDbType.VarChar;
            VarResult.Value = txtPickupdate.Text;
            VarResult.ParameterName = "@VarResult";
            VarResult.Size = 200;
            VarResult.Direction = ParameterDirection.Output;
            sqlcmd.Parameters.Add(VarResult);


            sqlcon.Open();

            sqlcmd.ExecuteNonQuery();
            string RowEffected = Convert.ToString(sqlcmd.Parameters["@VarResult"].Value);

            sqlcon.Close();

            if (RowEffected != "")
            {
                lblMessage.Text = RowEffected;
                lblMessage.CssClass = "SuccessMessage";


            }
        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
            lblMessage.CssClass = "ErrorMessage";
        }

        finally
        {
        }

    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
            Response.Redirect("~/Pages/Menu.aspx", true);
    }

    protected void btnGenerateDepositSlipGrandSummary_Click(object sender, EventArgs e)
    {
        lblMessage.Text = "";
        if (ddlClientList.SelectedIndex != 0)
        {
            if (txtPickupdate.Text != "")
            {
                if (txtDepositdate.Text != "")
                {
               // DepositSlipGrandSummary();

                    if (hdnPendingCount.Value != null && Convert.ToInt32(hdnPendingCount.Value) == 0)
                    {
                        DepositSlipGrandSummary();
                    }
                    else
                    {
                        lblMessage.Text = "Deposit Slip Grand Summary cannot be generated.Complete Pending batch(s) first.";
                        lblMessage.CssClass = "ErrorMessage";
                    }

                    
                }
                else
                {
                    lblMessage.Text = "Deposit Date Mandatory.";
                    lblMessage.CssClass = "ErrorMessage";
                }
            }
            else
            {
                lblMessage.Text = "Pickup Date Mandatory.";
                lblMessage.CssClass = "ErrorMessage";
            }

        }
        else
        {
            lblMessage.Text = "Select One Client.";
            lblMessage.CssClass = "ErrorMessage";
        } 
    }

    private void DepositSlipGrandSummary()
    {
        Object SaveUSERInfo = (Object)Session["UserInfo"];
        IFormatProvider culture = new System.Globalization.CultureInfo("en-US", true);

        try
        {
            SqlConnection sqlcon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);

  
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlcon;
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.CommandText = "Get_GrandSummaryForDS";
            sqlcmd.CommandTimeout = 0;

        

            SqlParameter BranchID = new SqlParameter();
            BranchID.SqlDbType = SqlDbType.Int;
            BranchID.Value = Convert.ToInt32(((UserInfo.structUSERInfo)(SaveUSERInfo)).BranchId);
            BranchID.ParameterName = "@BranchID";
            sqlcmd.Parameters.Add(BranchID);

            //NIKHIL 17 june 2013
            int pClientId = 0;
            if (ddlClientList.SelectedIndex != 0)
            {
                pClientId = Convert.ToInt32(ddlClientList.SelectedItem.Value);
            }

            SqlParameter ClientID = new SqlParameter();
            ClientID.SqlDbType = SqlDbType.Int;
            ClientID.Value = pClientId;
            ClientID.ParameterName = "@ClientID";
            sqlcmd.Parameters.Add(ClientID);

            SqlParameter DepositSlipDate = new SqlParameter();
            DepositSlipDate.SqlDbType = SqlDbType.VarChar;
            DepositSlipDate.Value = txtPickupdate.Text.Trim();
            DepositSlipDate.ParameterName = "@DepositSlipDate_mdy ";
            sqlcmd.Parameters.Add(DepositSlipDate);

            sqlcon.Open();
            SqlDataAdapter sqlda = new SqlDataAdapter();
            sqlda.SelectCommand = sqlcmd;
            DataSet Ds = new DataSet();
            sqlda.Fill(Ds);
            sqlcon.Close();

                if (Ds.Tables[0].Rows.Count > 0)
                {
                    arr = new string[Ds.Tables[0].Rows.Count];
                    for (int i = 0; i < Ds.Tables[0].Rows.Count; i++)
                    {
                        arr[i] = Ds.Tables[0].Rows[i]["DepositSlipNo"].ToString();
                    }
                    dscount = arr.Length;
                }

                if (Ds.Tables[1].Rows.Count > 0)
                {
                    arr2 = new string[Ds.Tables[1].Rows.Count];
                    for (int j = 0; j < Ds.Tables[1].Rows.Count;j++)
                    {
                        arr2[j] = Ds.Tables[1].Rows[j]["DepositSlipNo"].ToString();
                    }
                    dscount2 = arr2.Length;
                }


            //DataTable dt = new DataTable();
            //sqlda.Fill(dt);
            //sqlcon.Close();

            //if (dt.Rows.Count > 0)
            //{
            //    arr = new string[dt.Rows.Count];
            //    for (int i = 0; i < dt.Rows.Count; i++)
            //    {
            //        arr[i] = dt.Rows[i]["DepositSlipNo"].ToString().Trim();
            //        arr2[i] = dt.Rows[i]["Is_SBI"].ToString().Trim();
            //    }
            //    dscount = arr.Length;
            //}
        }

        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
        }
        var titleFont = FontFactory.GetFont("Arial", 11, Font.BOLD);
        var subTitleFont = FontFactory.GetFont("Arial", 10, Font.NORMAL);
        var boldTableFont = FontFactory.GetFont("Arial", 9, Font.BOLD);
        var NormalTableFont = FontFactory.GetFont("Arial", 9, Font.NORMAL);
        var endingMessageFont = FontFactory.GetFont("Arial", 9, Font.ITALIC);
        var BoldFont8 = FontFactory.GetFont("Arial", 7, Font.BOLD);


        if (dscount > 0 || dscount2 > 0)
        {

            Document Doc = new Document(PageSize.A4);

            PdfWriter.GetInstance(Doc, Response.OutputStream);

            Doc.Open();
            if (dscount != 0)
            {
                for (int m = 0; m < dscount3; m++)
                {
                    Doc.NewPage();

                    PdfPTable Head = new PdfPTable(2);
                    Head.TotalWidth = 580f;
                    float[] widths12 = new float[] { 100f, 100f };
                    Head.SetWidths(widths12);
                    Head.LockedWidth = true;

                    PdfPCell C2 = new PdfPCell(new Phrase("Page No : 1", boldTableFont));
                    C2.Colspan = 2;
                    C2.Border = 0;
                    C2.HorizontalAlignment = 2;
                    Head.AddCell(C2);

                    PdfPTable test = new PdfPTable(7);
                    test.TotalWidth = 550f;
                    float[] widths11 = new float[] { 40f, 50f, 80f, 100f, 100f, 100f, 60f };
                    test.SetWidths(widths11);
                    test.LockedWidth = true;

                    PdfPTable table = new PdfPTable(4);
                    table.TotalWidth = 550f;
                    float[] widths = new float[] { 110f, 100f, 100f, 100f };// Imp
                    table.SetWidths(widths);
                    table.LockedWidth = true;

                    PdfPCell header = new PdfPCell(new Phrase("DEPOSIT SLIP  GRAND  SUMMARY\n\n", titleFont));
                    header.Colspan = 7;
                    header.Border = 0;
                    header.HorizontalAlignment = 1;
                    test.AddCell(header);

                    PdfPCell Cell1 = new PdfPCell(new Phrase("Type of Clearing :", boldTableFont));
                    Cell1.Colspan = 2;
                    Cell1.Border = 0;
                    Cell1.HorizontalAlignment = 0;
                    test.AddCell(Cell1);

                    PdfPCell Cell11 = new PdfPCell(new Phrase("Value of Clearing :", NormalTableFont));
                    Cell11.Colspan = 2;
                    Cell11.Border = 0;
                    Cell11.HorizontalAlignment = 0;
                    test.AddCell(Cell11);

                    PdfPTable Tab = new PdfPTable(7);
                    Tab.TotalWidth = 550f;
                    float[] widthsAA = new float[] { 100f, 60f, 80f, 60f, 170f, 180f, 90f };// Imp
                    Tab.SetWidths(widthsAA);
                    Tab.LockedWidth = true;

                    PdfPCell Cell6 = new PdfPCell(new Phrase("  Paid to CREDIT OF :", boldTableFont));
                    Cell6.Colspan = 2;
                    Cell6.Border = 0;
                    Cell6.HorizontalAlignment = 2;
                    Tab.AddCell(Cell6);

                    PdfPCell Cell61 = new PdfPCell(new Phrase("STATE BANK OF INDIA", NormalTableFont));
                    Cell61.Colspan = 2;
                    Cell61.Border = 0;
                    Cell61.HorizontalAlignment = 0;
                    Tab.AddCell(Cell61);

                    PdfPCell Cell2 = new PdfPCell(new Phrase("Report Date   :", boldTableFont));
                    Cell2.Colspan = 2;
                    Cell2.Border = 0;
                    Cell2.HorizontalAlignment = 2;
                    Tab.AddCell(Cell2);

                    PdfPCell Cell21 = new PdfPCell(new Phrase(txtPickupdate.Text.Trim(), NormalTableFont));
                    Cell21.Colspan = 1;
                    Cell21.Border = 0;
                    Cell21.HorizontalAlignment = 0;
                    Tab.AddCell(Cell21);

                    PdfPCell Cell7 = new PdfPCell(new Phrase("Name of the Customer :", boldTableFont));
                    Cell7.Colspan = 2;
                    Cell7.Border = 0;
                    Cell7.HorizontalAlignment = 0;
                    Tab.AddCell(Cell7);

                    PdfPCell Cell71 = new PdfPCell(new Phrase("SBI CPSL", NormalTableFont));
                    Cell71.Colspan = 2;
                    Cell71.Border = 0;
                    Cell71.HorizontalAlignment = 0;
                    Tab.AddCell(Cell71);

                    PdfPCell Cell4 = new PdfPCell(new Phrase(" Deposit Date :", boldTableFont));
                    Cell4.Colspan = 2;
                    Cell4.Border = 0;
                    Cell4.HorizontalAlignment = 2;
                    Tab.AddCell(Cell4);

                    PdfPCell Cell41 = new PdfPCell(new Phrase(txtDepositdate.Text.Trim(), NormalTableFont));
                    Cell41.Colspan = 1;
                    Cell41.Border = 0;
                    Cell41.HorizontalAlignment = 0;
                    Tab.AddCell(Cell41);

                    PdfPCell Cell8 = new PdfPCell(new Phrase("             At :", boldTableFont));
                    Cell8.Colspan = 2;
                    Cell8.Border = 0;
                    Cell8.HorizontalAlignment = 2;
                    Tab.AddCell(Cell8);

                    PdfPCell Cell81 = new PdfPCell(new Phrase(Convert.ToString(((UserInfo.structUSERInfo)(SaveUSERInfo)).BranchName), NormalTableFont));
                    Cell81.Colspan = 5;
                    Cell81.Border = 0;
                    Cell81.HorizontalAlignment = 0;
                    Tab.AddCell(Cell81);

                    PdfPCell Cell9 = new PdfPCell(new Phrase("SBI CMP Client Code :" + "000180", boldTableFont));
                    Cell9.Colspan = 7;
                    Cell9.Border = 0;
                    Cell9.HorizontalAlignment = 0;
                    Tab.AddCell(Cell9);

                    PdfPCell header1 = new PdfPCell(new Phrase(""));
                    header1.Colspan = 7;
                    header1.Border = 0;
                    header1.HorizontalAlignment = 1;
                    table.AddCell(header1);

                    table.AddCell(new PdfPCell(new Phrase("Type of Clearing", boldTableFont)));
                    table.AddCell(new PdfPCell(new Phrase("Summary Sheet No.", boldTableFont)));
                    table.AddCell(new PdfPCell(new Phrase("No. Of Instrument", boldTableFont)));
                    table.AddCell(new PdfPCell(new Phrase("Amount", boldTableFont)));

                    for (int i = 0; i <= Convert.ToInt32(dscount) - 1; i++)
                    {

                        try
                        {
                            SqlConnection sqlcon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);

                  
                            SqlCommand sqlCmd = new SqlCommand();
                            sqlCmd.Connection = sqlcon;
                            sqlCmd.CommandType = CommandType.StoredProcedure;
                            sqlCmd.CommandText = "GetDS_Summarydetails";
                            sqlCmd.CommandTimeout = 0;


                          

                            SqlParameter Branch_ID = new SqlParameter();
                            Branch_ID.SqlDbType = SqlDbType.Int;
                            Branch_ID.Value = Convert.ToInt32(((UserInfo.structUSERInfo)(SaveUSERInfo)).BranchId);
                            Branch_ID.ParameterName = "@BranchID";
                            sqlCmd.Parameters.Add(Branch_ID);

                            //NIKHIL 17 june 2013
                            int pClientId = 0;
                            if (ddlClientList.SelectedIndex != 0)
                            {
                                pClientId = Convert.ToInt32(ddlClientList.SelectedItem.Value);
                            }

                            SqlParameter ClientID = new SqlParameter();
                            ClientID.SqlDbType = SqlDbType.Int;
                            ClientID.Value = pClientId;
                            ClientID.ParameterName = "@ClientID";
                            sqlCmd.Parameters.Add(ClientID);
                            //END

                            SqlParameter DepositeSlipNo = new SqlParameter();
                            DepositeSlipNo.SqlDbType = SqlDbType.VarChar;
                            DepositeSlipNo.Value = arr[i];
                            DepositeSlipNo.ParameterName = "@DepositSlipNo";
                            sqlCmd.Parameters.Add(DepositeSlipNo);


                            sqlcon.Open();
                            SqlDataAdapter sqlDa = new SqlDataAdapter();
                            sqlDa.SelectCommand = sqlCmd;
                            DataSet Ds = new DataSet();
                            sqlDa.Fill(Ds);
                            sqlcon.Close();

                            if (Ds.Tables.Count > 0)
                            {
                                SummaryType_of_Clearing = Ds.Tables[0].Rows[0]["SummaryType_of_Clearing"].ToString();
                                SummaryDeposite_SlipNo = Ds.Tables[0].Rows[0]["SummaryDeposite_SlipNo"].ToString();
                                SummaryIntrumentTypeCount = Ds.Tables[0].Rows[0]["SummaryIntrumentTypeCount"].ToString();
                                SummaryAmount = Ds.Tables[0].Rows[0]["SummaryAmount"].ToString();

                            }

                        }
                        catch (Exception ex)
                        {
                            lblMessage.Text = ex.Message;
                        }


                        //Type of Clearing
                        PdfPTable nested = new PdfPTable(1);
                        nested.AddCell(new PdfPCell(new Phrase(SummaryType_of_Clearing, NormalTableFont)));

                        PdfPCell nesthousing = new PdfPCell(nested);
                        nesthousing.Padding = 0f;
                        table.AddCell(nesthousing);

                        //SummaryDeposite_SlipNo             
                        PdfPTable nested2 = new PdfPTable(1);
                        nested2.AddCell(new PdfPCell(new Phrase(SummaryDeposite_SlipNo, NormalTableFont)));

                        PdfPCell nesthousing2 = new PdfPCell(nested2);
                        nesthousing2.Padding = 0f;
                        table.AddCell(nesthousing2);

                        // SummaryIntrumentTypeCount
                        PdfPTable nested3 = new PdfPTable(1);
                        nested3.AddCell(new PdfPCell(new Phrase(SummaryIntrumentTypeCount, NormalTableFont)));

                        PdfPCell nesthousing3 = new PdfPCell(nested3);
                        nesthousing3.Padding = 0f;
                        table.AddCell(nesthousing3);

                        //PdfPTable nested4 = new PdfPTable(1);
                        ////nested4.HorizontalAlignment = 2;
                        //PdfPCell nesthou4 = new PdfPCell(new Phrase(ChequeAmt, NormalTableFont));
                        //nesthou4.HorizontalAlignment = 2;
                        //nested4.AddCell(nesthou4);

                        PdfPTable nested4 = new PdfPTable(1);
                        PdfPCell nesthou4 = new PdfPCell(new Phrase(SummaryAmount, NormalTableFont));
                        nesthou4.HorizontalAlignment = 2;
                        nested4.AddCell(nesthou4);
                        //nested4.AddCell(new PdfPCell(new Phrase(SummaryAmount, NormalTableFont)));

                        PdfPCell nesthousing4 = new PdfPCell(nested4);
                        nesthousing4.Padding = 0f;
                        table.AddCell(nesthousing4);

                    }

                    PdfPTable Bottom1 = new PdfPTable(4);
                    Bottom1.TotalWidth = 550f;
                    float[] widths1234 = new float[] { 110f, 100f, 100f, 100f };
                    Bottom1.SetWidths(widths1234);
                    Bottom1.LockedWidth = true;

                    try
                    {

                        SqlConnection sqlconn = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);

                  
                        SqlCommand sqlcmd2 = new SqlCommand();
                        sqlcmd2.Connection = sqlconn;
                        sqlcmd2.CommandType = CommandType.StoredProcedure;
                        sqlcmd2.CommandText = "GetDS_SummaryTotal";
                        sqlcmd2.CommandTimeout = 0;

                   

                        SqlParameter Branch_ID = new SqlParameter();
                        Branch_ID.SqlDbType = SqlDbType.Int;
                        Branch_ID.Value = Convert.ToInt32(((UserInfo.structUSERInfo)(SaveUSERInfo)).BranchId);
                        Branch_ID.ParameterName = "@BranchID";
                        sqlcmd2.Parameters.Add(Branch_ID);

                        //NIKHIL 17 june 2013
                        int pClientId = 0;
                        if (ddlClientList.SelectedIndex != 0)
                        {
                            pClientId = Convert.ToInt32(ddlClientList.SelectedItem.Value);
                        }

                        SqlParameter ClientID = new SqlParameter();
                        ClientID.SqlDbType = SqlDbType.Int;
                        ClientID.Value = pClientId;
                        ClientID.ParameterName = "@ClientID";
                        sqlcmd2.Parameters.Add(ClientID);
                        //END

                        SqlParameter DepositSlipDate = new SqlParameter();
                        DepositSlipDate.SqlDbType = SqlDbType.VarChar;
                        DepositSlipDate.Value = Get_DateFormat(txtPickupdate.Text.Trim(), "MM/dd/yyyy");
                        DepositSlipDate.ParameterName = "@DepositDate ";
                        sqlcmd2.Parameters.Add(DepositSlipDate);

                        SqlParameter Is_Sbi = new SqlParameter();
                        Is_Sbi.SqlDbType = SqlDbType.Int;
                        Is_Sbi.Value = 1;
                        Is_Sbi.ParameterName = "@Is_Sbi";
                        sqlcmd2.Parameters.Add(Is_Sbi);


                        sqlconn.Open();
                        SqlDataAdapter sqlda2 = new SqlDataAdapter();
                        sqlda2.SelectCommand = sqlcmd2;
                        DataSet ds2 = new DataSet();
                        sqlda2.Fill(ds2);
                        sqlconn.Close();

                        if (ds2.Tables.Count > 0)
                        {
                            SummaryIntrumentTypeTotalCount = ds2.Tables[0].Rows[0]["SummaryIntrumentTypeTotalCount"].ToString();
                            TotalAmount = ds2.Tables[0].Rows[0]["SummaryTotalAmmount"].ToString();
                            wordValue.Value = ds2.Tables[0].Rows[0]["TotalAmountInWords"].ToString();
                        }
                     
                    }
                    catch (Exception ex)
                    {
                        lblMessage.Text = ex.Message;
                    }

                    PdfPCell ToalCA = new PdfPCell(new Phrase("Total : ", boldTableFont));
                    ToalCA.Colspan = 2;
                    ToalCA.HorizontalAlignment = 2;
                    Bottom1.AddCell(ToalCA);

                    PdfPCell ToalCB = new PdfPCell(new Phrase(SummaryIntrumentTypeTotalCount, boldTableFont));
                    ToalCB.Colspan = 1;
                    ToalCB.HorizontalAlignment = 0;
                    Bottom1.AddCell(ToalCB);

       

                    PdfPCell ToalCC = new PdfPCell(new Phrase(TotalAmount, boldTableFont));
                    ToalCC.Colspan = 1;
                    ToalCC.HorizontalAlignment = 2;
                    Bottom1.AddCell(ToalCC);

                    PdfPCell TotalCAA = new PdfPCell(new Phrase("Amount In Words:", boldTableFont));
                    TotalCAA.Colspan = 1;
                    TotalCAA.HorizontalAlignment = 0;
                    Bottom1.AddCell(TotalCAA);

                    PdfPCell TotalCBA = new PdfPCell(new Phrase(wordValue.Value, boldTableFont));
                    TotalCBA.Colspan = 3;
                    TotalCBA.HorizontalAlignment = 0;
                    Bottom1.AddCell(TotalCBA);

                    Doc.Add(Head);
                    Doc.Add(test);
                    Doc.Add(Tab);
                    Doc.Add(table);
                    Doc.Add(Bottom1);


                }
            }

            if (dscount2 != 0)
            {
                for (int n = 0; n < dscount3; n++)
                {
                    Doc.NewPage();

                    PdfPTable Head = new PdfPTable(2);
                    Head.TotalWidth = 580f;
                    float[] widths12 = new float[] { 100f, 100f };
                    Head.SetWidths(widths12);
                    Head.LockedWidth = true;

                    PdfPCell C2 = new PdfPCell(new Phrase("Page No : 1", boldTableFont));
                    C2.Colspan = 2;
                    C2.Border = 0;
                    C2.HorizontalAlignment = 2;
                    Head.AddCell(C2);

                    PdfPTable test = new PdfPTable(7);
                    test.TotalWidth = 550f;
                    float[] widths11 = new float[] { 40f, 50f, 80f, 100f, 100f, 100f, 60f };
                    test.SetWidths(widths11);
                    test.LockedWidth = true;

                    PdfPTable table = new PdfPTable(4);
                    table.TotalWidth = 550f;
                    float[] widths = new float[] { 110f, 100f, 100f, 100f };// Imp
                    table.SetWidths(widths);
                    table.LockedWidth = true;

                    PdfPCell header = new PdfPCell(new Phrase("DEPOSIT SLIP  GRAND  SUMMARY\n\n", titleFont));
                    header.Colspan = 7;
                    header.Border = 0;
                    header.HorizontalAlignment = 1;
                    test.AddCell(header);

                    PdfPCell Cell1 = new PdfPCell(new Phrase("Type of Clearing :", boldTableFont));
                    Cell1.Colspan = 2;
                    Cell1.Border = 0;
                    Cell1.HorizontalAlignment = 0;
                    test.AddCell(Cell1);

                    PdfPCell Cell11 = new PdfPCell(new Phrase("Value of Clearing :", NormalTableFont));
                    Cell11.Colspan = 2;
                    Cell11.Border = 0;
                    Cell11.HorizontalAlignment = 0;
                    test.AddCell(Cell11);

                    PdfPTable Tab = new PdfPTable(7);
                    Tab.TotalWidth = 550f;
                    float[] widthsAA = new float[] { 100f, 60f, 80f, 60f, 170f, 180f, 90f };// Imp
                    Tab.SetWidths(widthsAA);
                    Tab.LockedWidth = true;

                    PdfPCell Cell6 = new PdfPCell(new Phrase("  Paid to CREDIT OF :", boldTableFont));
                    Cell6.Colspan = 2;
                    Cell6.Border = 0;
                    Cell6.HorizontalAlignment = 2;
                    Tab.AddCell(Cell6);

                    PdfPCell Cell61 = new PdfPCell(new Phrase("STATE BANK OF INDIA", NormalTableFont));
                    Cell61.Colspan = 2;
                    Cell61.Border = 0;
                    Cell61.HorizontalAlignment = 0;
                    Tab.AddCell(Cell61);

                    PdfPCell Cell2 = new PdfPCell(new Phrase("Report Date   :", boldTableFont));
                    Cell2.Colspan = 2;
                    Cell2.Border = 0;
                    Cell2.HorizontalAlignment = 2;
                    Tab.AddCell(Cell2);

                    PdfPCell Cell21 = new PdfPCell(new Phrase(txtPickupdate.Text.Trim(), NormalTableFont));
                    Cell21.Colspan = 1;
                    Cell21.Border = 0;
                    Cell21.HorizontalAlignment = 0;
                    Tab.AddCell(Cell21);

                    PdfPCell Cell7 = new PdfPCell(new Phrase("Name of the Customer :", boldTableFont));
                    Cell7.Colspan = 2;
                    Cell7.Border = 0;
                    Cell7.HorizontalAlignment = 0;
                    Tab.AddCell(Cell7);

                    PdfPCell Cell71 = new PdfPCell(new Phrase("SBI CPSL", NormalTableFont));
                    Cell71.Colspan = 2;
                    Cell71.Border = 0;
                    Cell71.HorizontalAlignment = 0;
                    Tab.AddCell(Cell71);

                    PdfPCell Cell4 = new PdfPCell(new Phrase(" Deposit Date :", boldTableFont));
                    Cell4.Colspan = 2;
                    Cell4.Border = 0;
                    Cell4.HorizontalAlignment = 2;
                    Tab.AddCell(Cell4);

                    PdfPCell Cell41 = new PdfPCell(new Phrase(txtDepositdate.Text.Trim(), NormalTableFont));
                    Cell41.Colspan = 1;
                    Cell41.Border = 0;
                    Cell41.HorizontalAlignment = 0;
                    Tab.AddCell(Cell41);

                    PdfPCell Cell8 = new PdfPCell(new Phrase("             At :", boldTableFont));
                    Cell8.Colspan = 2;
                    Cell8.Border = 0;
                    Cell8.HorizontalAlignment = 2;
                    Tab.AddCell(Cell8);

                    PdfPCell Cell81 = new PdfPCell(new Phrase(Convert.ToString(((UserInfo.structUSERInfo)(SaveUSERInfo)).BranchName), NormalTableFont));
                    Cell81.Colspan = 5;
                    Cell81.Border = 0;
                    Cell81.HorizontalAlignment = 0;
                    Tab.AddCell(Cell81);

                    PdfPCell Cell9 = new PdfPCell(new Phrase("SBI CMP Client Code :" + " 000170", boldTableFont));
                    Cell9.Colspan = 7;
                    Cell9.Border = 0;
                    Cell9.HorizontalAlignment = 0;
                    Tab.AddCell(Cell9);

                    PdfPCell header1 = new PdfPCell(new Phrase(""));
                    header1.Colspan = 7;
                    header1.Border = 0;
                    header1.HorizontalAlignment = 1;
                    table.AddCell(header1);

                    table.AddCell(new PdfPCell(new Phrase("Type of Clearing", boldTableFont)));
                    table.AddCell(new PdfPCell(new Phrase("Summary Sheet No.", boldTableFont)));
                    table.AddCell(new PdfPCell(new Phrase("No. Of Instrument", boldTableFont)));
                    table.AddCell(new PdfPCell(new Phrase("Amount", boldTableFont)));

                    for (int i = 0; i <= Convert.ToInt32(dscount2) - 1; i++)
                    {

                        //HdnNO.Value = Convert.ToInt32(i).ToString();
                        //GetDepositSlipGrandSummaryData();

                        try
                        {
                            SqlConnection sqlcon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);

                     
                            SqlCommand sqlCmd = new SqlCommand();
                            sqlCmd.Connection = sqlcon;
                            sqlCmd.CommandType = CommandType.StoredProcedure;
                            sqlCmd.CommandText = "GetDS_Summarydetails";
                            sqlCmd.CommandTimeout = 0;


                            SqlParameter Branch_ID = new SqlParameter();
                            Branch_ID.SqlDbType = SqlDbType.Int;
                            Branch_ID.Value = Convert.ToInt32(((UserInfo.structUSERInfo)(SaveUSERInfo)).BranchId);
                            Branch_ID.ParameterName = "@BranchID";
                            sqlCmd.Parameters.Add(Branch_ID);

                            //NIKHIL 17 june 2013
                            int pClientId = 0;
                            if (ddlClientList.SelectedIndex != 0)
                            {
                                pClientId = Convert.ToInt32(ddlClientList.SelectedItem.Value);
                            }

                            SqlParameter ClientID = new SqlParameter();
                            ClientID.SqlDbType = SqlDbType.Int;
                            ClientID.Value = pClientId;
                            ClientID.ParameterName = "@ClientID";
                            sqlCmd.Parameters.Add(ClientID);
                            //END

                            SqlParameter DepositeSlipNo = new SqlParameter();
                            DepositeSlipNo.SqlDbType = SqlDbType.VarChar;
                            DepositeSlipNo.Value = arr2[i];
                            DepositeSlipNo.ParameterName = "@DepositSlipNo";
                            sqlCmd.Parameters.Add(DepositeSlipNo);


                            sqlcon.Open();
                            SqlDataAdapter sqlDa = new SqlDataAdapter();
                            sqlDa.SelectCommand = sqlCmd;
                            DataSet Ds = new DataSet();
                            sqlDa.Fill(Ds);
                            sqlcon.Close();

                            if (Ds.Tables.Count > 0)
                            {
                                SummaryType_of_Clearing = Ds.Tables[0].Rows[0]["SummaryType_of_Clearing"].ToString();
                                SummaryDeposite_SlipNo = Ds.Tables[0].Rows[0]["SummaryDeposite_SlipNo"].ToString();
                                SummaryIntrumentTypeCount = Ds.Tables[0].Rows[0]["SummaryIntrumentTypeCount"].ToString();
                                SummaryAmount = Ds.Tables[0].Rows[0]["SummaryAmount"].ToString();

                            }

                        }
                        catch (Exception ex)
                        {
                            lblMessage.Text = ex.Message;
                        }


                        //Type of Clearing
                        PdfPTable nested = new PdfPTable(1);
                        nested.AddCell(new PdfPCell(new Phrase(SummaryType_of_Clearing, NormalTableFont)));

                        PdfPCell nesthousing = new PdfPCell(nested);
                        nesthousing.Padding = 0f;
                        table.AddCell(nesthousing);

                        //SummaryDeposite_SlipNo             
                        PdfPTable nested2 = new PdfPTable(1);
                        nested2.AddCell(new PdfPCell(new Phrase(SummaryDeposite_SlipNo, NormalTableFont)));

                        PdfPCell nesthousing2 = new PdfPCell(nested2);
                        nesthousing2.Padding = 0f;
                        table.AddCell(nesthousing2);

                        // SummaryIntrumentTypeCount
                        PdfPTable nested3 = new PdfPTable(1);
                        nested3.AddCell(new PdfPCell(new Phrase(SummaryIntrumentTypeCount, NormalTableFont)));

                        PdfPCell nesthousing3 = new PdfPCell(nested3);
                        nesthousing3.Padding = 0f;
                        table.AddCell(nesthousing3);


                        PdfPTable nested4 = new PdfPTable(1);
                        PdfPCell nesthou4 = new PdfPCell(new Phrase(SummaryAmount, NormalTableFont));
                        nesthou4.HorizontalAlignment = 2;
                        nested4.AddCell(nesthou4);
                        //nested4.AddCell(new PdfPCell(new Phrase(SummaryAmount, NormalTableFont)));

                        PdfPCell nesthousing4 = new PdfPCell(nested4);
                        nesthousing4.Padding = 0f;
                        table.AddCell(nesthousing4);

                    }

                    PdfPTable Bottom1 = new PdfPTable(4);
                    Bottom1.TotalWidth = 550f;
                    float[] widths1234 = new float[] { 110f, 100f, 100f, 100f };
                    Bottom1.SetWidths(widths1234);
                    Bottom1.LockedWidth = true;

                    try
                    {

                        SqlConnection sqlconn = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);

                
                        SqlCommand sqlcmd2 = new SqlCommand();
                        sqlcmd2.Connection = sqlconn;
                        sqlcmd2.CommandType = CommandType.StoredProcedure;
                        sqlcmd2.CommandText = "GetDS_SummaryTotal";
                        sqlcmd2.CommandTimeout = 0;

                  

                        SqlParameter Branch_ID = new SqlParameter();
                        Branch_ID.SqlDbType = SqlDbType.Int;
                        Branch_ID.Value = Convert.ToInt32(((UserInfo.structUSERInfo)(SaveUSERInfo)).BranchId);
                        Branch_ID.ParameterName = "@BranchID";
                        sqlcmd2.Parameters.Add(Branch_ID);

       
                        int pClientId = 0;
                        if (ddlClientList.SelectedIndex != 0)
                        {
                            pClientId = Convert.ToInt32(ddlClientList.SelectedItem.Value);
                        }

                        SqlParameter ClientID = new SqlParameter();
                        ClientID.SqlDbType = SqlDbType.Int;
                        ClientID.Value = pClientId;
                        ClientID.ParameterName = "@ClientID";
                        sqlcmd2.Parameters.Add(ClientID);
                        //END

                        SqlParameter DepositSlipDate = new SqlParameter();
                        DepositSlipDate.SqlDbType = SqlDbType.VarChar;
                        DepositSlipDate.Value = Get_DateFormat(txtPickupdate.Text.Trim(), "MM/dd/yyyy");
                        DepositSlipDate.ParameterName = "@DepositDate ";
                        sqlcmd2.Parameters.Add(DepositSlipDate);

                        SqlParameter Is_Sbi = new SqlParameter();
                        Is_Sbi.SqlDbType = SqlDbType.Int;
                        Is_Sbi.Value = 2;
                        Is_Sbi.ParameterName = "@Is_Sbi";
                        sqlcmd2.Parameters.Add(Is_Sbi);


                        sqlconn.Open();
                        SqlDataAdapter sqlda2 = new SqlDataAdapter();
                        sqlda2.SelectCommand = sqlcmd2;
                        DataSet ds2 = new DataSet();
                        sqlda2.Fill(ds2);
                        sqlconn.Close();

                        if (ds2.Tables.Count > 0)
                        {
                            SummaryIntrumentTypeTotalCount = ds2.Tables[0].Rows[0]["SummaryIntrumentTypeTotalCount"].ToString();
                            TotalAmount = ds2.Tables[0].Rows[0]["SummaryTotalAmmount"].ToString();
                            wordValue.Value = ds2.Tables[0].Rows[0]["TotalAmountInWords"].ToString();
                        }
                       
                    }
                    catch (Exception ex)
                    {
                        lblMessage.Text = ex.Message;
                    }

                    PdfPCell ToalCA = new PdfPCell(new Phrase("Total : ", boldTableFont));
                    ToalCA.Colspan = 2;
                    ToalCA.HorizontalAlignment = 2;
                    Bottom1.AddCell(ToalCA);

                    PdfPCell ToalCB = new PdfPCell(new Phrase(SummaryIntrumentTypeTotalCount, boldTableFont));
                    ToalCB.Colspan = 1;
                    ToalCB.HorizontalAlignment = 0;
                    Bottom1.AddCell(ToalCB);

                    //PdfPTable nest4 = new PdfPTable(1);
                    ////nested4.HorizontalAlignment = 2;
                    //PdfPCell nesthou4 = new PdfPCell(new Phrase(ChequeAmt, NormalTableFont));
                    //nesthou4.HorizontalAlignment = 2;
                    //nested4.AddCell(nesthou4);


                    PdfPCell ToalCC = new PdfPCell(new Phrase(TotalAmount, boldTableFont));
                    ToalCC.Colspan = 1;
                    ToalCC.HorizontalAlignment = 2;
                    Bottom1.AddCell(ToalCC);

                    PdfPCell TotalCAA = new PdfPCell(new Phrase("Amount In Words:", boldTableFont));
                    TotalCAA.Colspan = 1;
                    TotalCAA.HorizontalAlignment = 0;
                    Bottom1.AddCell(TotalCAA);

                    PdfPCell TotalCBA = new PdfPCell(new Phrase(wordValue.Value, boldTableFont));
                    TotalCBA.Colspan = 3;
                    TotalCBA.HorizontalAlignment = 0;
                    Bottom1.AddCell(TotalCBA);

                    Doc.Add(Head);
                    Doc.Add(test);
                    Doc.Add(Tab);
                    Doc.Add(table);
                    Doc.Add(Bottom1);


                }
            }
            Doc.Close();

            Response.ContentType = "application/pdf";
            Response.AddHeader("content-disposition", "attachment; filename=Doc1.pdf");
            Response.End();
        }
        else 
        {
            lblMessage.Text = "No such DepositSlip GrandSummary found.";
            lblMessage.CssClass = "ErrorMessage";
        }
    }

    public int dscount = 0;

    public int pClientId { get; set; }

    protected void ddlClientList_SelectedIndexChanged(object sender, EventArgs e)
    {
        lblMessage.Text = "";
        grvBatchDetails.DataSource = null;
        grvBatchDetails.DataBind();
   

    }

    public string pdc_count { get; set; }

    protected void btnDraft_Click(object sender, EventArgs e)
    {
        lblMessage.Text = "";
        if (ddlClientList.SelectedIndex != 0)
        {
            if (txtPickupdate.Text != "")
            {
                if (txtDepositdate.Text != "")
                {
                    if (hdnPendingCount.Value != null && Convert.ToInt32(hdnPendingCount.Value) == 0)
                    {
                        lblMessage.Text = "";

                        CheckPDC();

                        CheckDSExistence();
                        if (ds_exists == "NO")
                        {
                           
                            Insert_DepositSlipInfo();
                        }

                        GenerateDraftDS();
                       
                    }
                    else
                    {
                        lblMessage.Text = "Deposit Date Mandatory.";
                        lblMessage.CssClass = "ErrorMessage";
                    }
                }
                else
                {
                    lblMessage.Text = "Pickup Date Mandatory.";
                    lblMessage.CssClass = "ErrorMessage";
                }

            }
            else
            {
                lblMessage.Text = "Select One Client.";
                lblMessage.CssClass = "ErrorMessage";
            }
        }
    }

    private void GenerateDraftDS()
    {
        Object SaveUSERInfo = (Object)Session["UserInfo"];

        try
        {
            SqlConnection sqlcon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);


            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlcon;
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.CommandText = "GetDraftDepositSlip";
            sqlcmd.CommandTimeout = 0;




            SqlParameter BranchID = new SqlParameter();
            BranchID.SqlDbType = SqlDbType.Int;
            BranchID.Value = Convert.ToInt32(((UserInfo.structUSERInfo)(SaveUSERInfo)).BranchId);
            BranchID.ParameterName = "@BranchId";
            sqlcmd.Parameters.Add(BranchID);

            int pClientId = 0;
            if (ddlClientList.SelectedIndex != 0)
            {
                pClientId = Convert.ToInt32(ddlClientList.SelectedItem.Value);
            }

            SqlParameter ClientID = new SqlParameter();
            ClientID.SqlDbType = SqlDbType.Int;
            ClientID.Value = pClientId;
            ClientID.ParameterName = "@ClientID";
            sqlcmd.Parameters.Add(ClientID);

            SqlParameter DepositSlipDate = new SqlParameter();
            DepositSlipDate.SqlDbType = SqlDbType.VarChar;
            DepositSlipDate.Value = txtPickupdate.Text.Trim();
            DepositSlipDate.ParameterName = "@DepositSlipDate ";
            sqlcmd.Parameters.Add(DepositSlipDate);


            sqlcon.Open();
            SqlDataAdapter sqlda = new SqlDataAdapter();
            sqlda.SelectCommand = sqlcmd;
            DataTable dt = new DataTable();
            sqlda.Fill(dt);
            sqlcon.Close();

            if (dt.Rows.Count > 0)
            {
                grvBatchDetailsnew.DataSource = dt;
                grvBatchDetailsnew.DataBind();
                grvBatchDetails.DataSource = null;
                grvBatchDetails.DataBind();

                string attachment = "";
                if (ddlClientList.SelectedIndex == 1)
                {
                    attachment = "attachment; filename=SBI_DraftDs.xls";
                }
                if (ddlClientList.SelectedIndex == 2)
                {
                    attachment = "attachment; filename=SOC_DraftDs.xls";
                }
                Response.ClearContent();
                Response.AddHeader("content-disposition", attachment);
                Response.ContentType = "application/ms-excel";
                StringWriter sw = new System.IO.StringWriter();
                HtmlTextWriter htw = new HtmlTextWriter(sw);

                string style = @"<style> TD { mso-number-format:\@; } </style> ";

                grvBatchDetailsnew.EnableViewState = false;

                grvBatchDetailsnew.RenderControl(htw);
                Response.Write(style);
                Response.Write(sw.ToString());

                Response.End();
            }
            else
            {
                lblMessage.Visible = true;
                lblMessage.Text = "No Records Found.";
            }
        }
        catch (Exception Ex)
        {
            lblMessage.Visible = true;
            lblMessage.Text = Ex.Message;
        }

        finally
        { 
        
        }
    }

    public override void VerifyRenderingInServerForm(Control control)
    {

    }
//protected void  DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
//    {
//        if (ddlPDCCheck.SelectedIndex == 0)
//        {
//            lblMessage.Text = "Select Yes or No";
//            ddlPDCCheck.Focus();
            
//        }
//        else

//        if (ddlPDCCheck.SelectedItem.Text == "Yes")
//        {
//            lblMessage.Text = "Complete PDC Updation First.";
//            lblMessage.CssClass = "ErrorMessage";
//        }
//        else
//            {
//                lblMessage.Text = "";
//            GenerateDraftDS();
//            ddlPDCCheck.SelectedIndex = 0;
//            //GetExcelReport();
//            pnlPdcCheck.Visible = false;
//            pnlButtons.Visible = true;
//        }
//    }

private void GetExcelReport()
{
    //string attachment = "";
    //if (ddlClientList.SelectedIndex == 1)
    //{
    //    attachment = "attachment; filename=SBI_DraftDs.xls";
    //}
    //if (ddlClientList.SelectedIndex == 2)
    //{
    //    attachment = "attachment; filename=SOC_DraftDs.xls";
    //}
    //Response.ClearContent();
    //Response.AddHeader("content-disposition", attachment);
    //Response.ContentType = "application/ms-excel";
    //StringWriter sw = new System.IO.StringWriter();
    //HtmlTextWriter htw = new HtmlTextWriter(sw);

    //string style = @"<style> TD { mso-number-format:\@; } </style> ";

    //grvBatchDetailsnew.EnableViewState = false;

    //grvBatchDetailsnew.RenderControl(htw);
    //Response.Write(style);
    //Response.Write(sw.ToString());

    //Response.End();
}
}