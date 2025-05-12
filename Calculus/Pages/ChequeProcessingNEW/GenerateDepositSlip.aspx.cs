using System;
using System.Data;
using System.Web;
using System.Configuration;
using System.Collections;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using System.IO;
using iTextSharp;
using iTextSharp.text.api;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.html;
using iTextSharp.text.html.simpleparser; 

public partial class Pages_ChequeProcessingNEW_GenerateDepositSlip : System.Web.UI.Page
{
  //  Instead of hidden field better to initialize in public class
    
    string SerialNo;
    string Deposite_SlipNo;
    string IntrumentType;
    string Pickup_Date;
    string Deposit_Date;
    string BankName;
    string BranchName;
    string BranchCity;
    string Instrument_Number;
    string Cheque_Ammount;
    string Instrument_Date;
    string TotalAmount;
    string SummaryIntrumentTypeTotalCount;
    string SummaryDeposit_Date ;
    string SummaryPickup_Date ;
    string SummaryBankName;
    string SummaryBranchName;
    string SummaryType_of_Clearing;
    string SummaryDeposite_SlipNo;
    string SummaryIntrumentTypeCount;
    string SummaryAmount;
    string SummaryTotalAmmount;
    string Type_of_Clearing;
    
    protected void Page_Load(object sender, EventArgs e)
    {

        if (Session["UserInfo"] == null)
        {
            Response.Redirect("~/Pages/InvalidRequest.aspx");

        }
        if (!IsPostBack)
        {
            if (Request.QueryString["Vw"] != null)
            {
                btnGenerateDepositSlip.Visible = false;
            }
            if (Request.QueryString["BN"] != null)
            {
                txtBatchNo.Text = Request.QueryString["BN"].ToString().Trim();
            }
            Get_HeaderDetails(); 
            RegisterControls_WithJavascript();
            GetTotalCount(); 
            DetTotalSummaryData();

            Validation11();
            Validation12();
        }

        //string StrScript = "<script language='javascript'> javascript:Page_load_validation(); </script>";
        //Page.RegisterStartupScript("OnLoad_21", StrScript);
    }

    private void RegisterControls_WithJavascript()
    {
        btnGenerateDepositSlip.Attributes.Add("onclick", "javascript:return Validate_GenerateDepositSlip();");
    }

    private void Get_HeaderDetails()
    {
        Get_BatchDetail_For_Deposit_Generation();
    }

    private void Get_BatchDetail_For_Deposit_Generation()
    {
        try
        {
            Object SaveUSERInfo = (Object)Session["UserInfo"];

            SqlConnection sqlcon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);


            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlcon;
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.CommandText = "Get_BatchDetail_For_Deposit_Generation";
            sqlcmd.CommandTimeout = 0;



            SqlParameter BranchID = new SqlParameter();
            BranchID.SqlDbType = SqlDbType.Int;
            BranchID.Value = Convert.ToInt32(((UserInfo.structUSERInfo)(SaveUSERInfo)).BranchId);
            BranchID.ParameterName = "@BranchID";
            sqlcmd.Parameters.Add(BranchID);

            SqlParameter BatchNo = new SqlParameter();
            BatchNo.SqlDbType = SqlDbType.VarChar;
            BatchNo.Value = txtBatchNo.Text.Trim();
            BatchNo.ParameterName = "@BatchNo";
            sqlcmd.Parameters.Add(BatchNo);


            sqlcon.Open();
            SqlDataAdapter sqlda = new SqlDataAdapter();
            sqlda.SelectCommand = sqlcmd;

            DataSet ds = new DataSet();
            sqlda.Fill(ds);
            sqlcon.Close();

            if (ds.Tables.Count == 2)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    lblBatchDate.Text = ds.Tables[0].Rows[0]["BatchDate"].ToString();
                    lblChequeDepositSlip.Text = ds.Tables[0].Rows[0]["ChequeDepositDate"].ToString();
                    lblChequePickupdate.Text = ds.Tables[0].Rows[0]["ChequePickeupDate"].ToString();
                    lblClientName.Text = ds.Tables[0].Rows[0]["ClientName"].ToString();
                    lblTotalChequeCount.Text = ds.Tables[0].Rows[0]["ChequeCount"].ToString();
                    hdnTotalChequeCaptureCount.Value = ds.Tables[0].Rows[0]["TotalChequeCaptured"].ToString();
                    hdnTotalChequeCount.Value = ds.Tables[0].Rows[0]["TotalChequesCount"].ToString();
                    HdnLocation.Value = ds.Tables[0].Rows[0]["BranchName"].ToString();
                    HdnAccountNoT.Value = ds.Tables[0].Rows[0]["AccountNo"].ToString();
                    if (ds.Tables[1].Rows.Count > 0)
                    {
                        grv_DropboxDetails.DataSource = ds.Tables[1];
                        grv_DropboxDetails.DataBind();
                    }
                }
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

    protected void btnGenerateDepositSlip_Click(object sender, EventArgs e)
    {
        Insert_DepositSlipInfo();
        GeneratePdfReport();    
        //GeneratePdfReport2();
    }

    private void Insert_DepositSlipInfo()
    {
        Object SaveUSERInfo = (Object)Session["UserInfo"];

        SqlConnection sqlcon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);

   
        SqlCommand sqlcmd = new SqlCommand();
        sqlcmd.Connection = sqlcon;
        sqlcmd.CommandType = CommandType.StoredProcedure;
        sqlcmd.CommandText = "Insert_DepositSlipInfo_datewise";
        sqlcmd.CommandTimeout = 0;

       

        SqlParameter BranchID = new SqlParameter();
        BranchID.SqlDbType = SqlDbType.Int;
        BranchID.Value = Convert.ToInt32(((UserInfo.structUSERInfo)(SaveUSERInfo)).BranchId);
        BranchID.ParameterName = "@BranchID";
        sqlcmd.Parameters.Add(BranchID);



        SqlParameter ChequePickeupDate_mdy = new SqlParameter();
        ChequePickeupDate_mdy.SqlDbType = SqlDbType.VarChar;
        ChequePickeupDate_mdy.Value = txtBatchNo.Text.Trim();
        ChequePickeupDate_mdy.ParameterName = "@ChequePickeupDate_mdy";
        sqlcmd.Parameters.Add(ChequePickeupDate_mdy);

        SqlParameter UserID = new SqlParameter();
        UserID.SqlDbType = SqlDbType.VarChar;
        UserID.Value =
        UserID.ParameterName = "@UserID";
        sqlcmd.Parameters.Add(UserID);

        //SqlParameter TotalRecords = new SqlParameter();
        //TotalRecords.SqlDbType = SqlDbType.Int;
        //TotalRecords.Value =Convert.ToInt32(hdnTotalChequeCount.Value.Trim());
        //TotalRecords.ParameterName = "@TotalRecords";
        //sqlcmd.Parameters.Add(TotalRecords);

        SqlParameter VarResult = new SqlParameter();
        VarResult.SqlDbType = SqlDbType.VarChar;
        VarResult.Value = txtBatchNo.Text.Trim();
        VarResult.ParameterName = "@VarResult";
        VarResult.Size = 200;
        VarResult.Direction = ParameterDirection.Output;
        sqlcmd.Parameters.Add(VarResult);

        sqlcon.Close();

        sqlcmd.ExecuteNonQuery();
        string RowEffected = Convert.ToString(sqlcmd.Parameters["@VarResult"].Value);

        sqlcon.Close();

        if (RowEffected != "")
        {
            lblMessage.Text =RowEffected;
            lblMessage.CssClass = "SuccessMessage";
 
            Get_HeaderDetails();
        }

        
    }

    private void DepositSlipGrandSummary()
    {
        HdnNO.Value = "0";
        GetDepositSlipGrandSummaryData();
        DetTotalSummaryData();

        var titleFont = FontFactory.GetFont("Arial", 12, Font.BOLD);
        var subTitleFont = FontFactory.GetFont("Arial", 11, Font.NORMAL);
        var boldTableFont = FontFactory.GetFont("Arial", 10, Font.BOLD);
        var NormalTableFont = FontFactory.GetFont("Arial", 10, Font.NORMAL);
        var endingMessageFont = FontFactory.GetFont("Arial", 10, Font.ITALIC);
        var BoldFont8 = FontFactory.GetFont("Arial", 8, Font.BOLD);

        Document Doc = new Document(PageSize.A4);

        PdfWriter.GetInstance(Doc, Response.OutputStream);
               
        Doc.Open();
        
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

        PdfPCell Cell61 = new PdfPCell(new Phrase(BankName, NormalTableFont));
        Cell61.Colspan = 2;
        Cell61.Border = 0;
        Cell61.HorizontalAlignment = 0;
        Tab.AddCell(Cell61);
        
        PdfPCell Cell2 = new PdfPCell(new Phrase("Report Date   :", boldTableFont));
        Cell2.Colspan = 2;
        Cell2.Border = 0;
        Cell2.HorizontalAlignment = 2;
        Tab.AddCell(Cell2);

        PdfPCell Cell21 = new PdfPCell(new Phrase(lblChequePickupdate.Text.Trim(), NormalTableFont));
        Cell21.Colspan = 1;
        Cell21.Border = 0;
        Cell21.HorizontalAlignment = 0;
        Tab.AddCell(Cell21);
        
        PdfPCell Cell7 = new PdfPCell(new Phrase("Name of the Customer :", boldTableFont));
        Cell7.Colspan = 2;
        Cell7.Border = 0;
        Cell7.HorizontalAlignment = 0;
        Tab.AddCell(Cell7);

        PdfPCell Cell71 = new PdfPCell(new Phrase(lblClientName.Text.Trim(), NormalTableFont));
        Cell71.Colspan = 2;
        Cell71.Border = 0;
        Cell71.HorizontalAlignment = 0;
        Tab.AddCell(Cell71);
        
        PdfPCell Cell4 = new PdfPCell(new Phrase(" Deposit Date :", boldTableFont));
        Cell4.Colspan = 2;
        Cell4.Border = 0;
        Cell4.HorizontalAlignment = 2;
        Tab.AddCell(Cell4);

        PdfPCell Cell41 = new PdfPCell(new Phrase(lblChequeDepositSlip.Text.Trim(), NormalTableFont));
        Cell41.Colspan = 1;
        Cell41.Border = 0;
        Cell41.HorizontalAlignment = 0;
        Tab.AddCell(Cell41);
                
        PdfPCell Cell8 = new PdfPCell(new Phrase("             At :", boldTableFont));
        Cell8.Colspan = 2;
        Cell8.Border = 0;
        Cell8.HorizontalAlignment = 2;
        Tab.AddCell(Cell8);

        PdfPCell Cell81 = new PdfPCell(new Phrase(HdnLocation.Value, NormalTableFont));
        Cell81.Colspan = 5;
        Cell81.Border = 0;
        Cell81.HorizontalAlignment = 0;
        Tab.AddCell(Cell81);

        PdfPCell Cell9 = new PdfPCell(new Phrase("          Account Number :" + HdnAccountNoT.Value, boldTableFont));
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

        for (int i = 0; i <= Convert.ToInt32(HdnDs11Count.Value) - 1; i++)
        {
            
            HdnNO.Value = Convert.ToInt32(i).ToString();
            GetDepositSlipGrandSummaryData();

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

            //SummaryAmount
            PdfPTable nested4 = new PdfPTable(1);
            nested4.AddCell(new PdfPCell(new Phrase(SummaryAmount, NormalTableFont)));
  
            PdfPCell nesthousing4 = new PdfPCell(nested4);
            nesthousing4.Padding = 0f;           
            table.AddCell(nesthousing4);
            
        }

        PdfPTable Bottom1 = new PdfPTable(4);
        Bottom1.TotalWidth = 550f;
        float[] widths1234 = new float[] { 110f, 100f, 100f, 100f };
        Bottom1.SetWidths(widths1234);
        Bottom1.LockedWidth = true;

        PdfPCell ToalCA = new PdfPCell(new Phrase("Total : ", boldTableFont));
        ToalCA.Colspan = 2;
        ToalCA.HorizontalAlignment = 2;
        Bottom1.AddCell(ToalCA);

        PdfPCell ToalCB = new PdfPCell(new Phrase(SummaryIntrumentTypeTotalCount, boldTableFont));
        ToalCB.Colspan = 1;
        ToalCB.HorizontalAlignment = 1;
        Bottom1.AddCell(ToalCB);

        PdfPCell ToalCC = new PdfPCell(new Phrase(SummaryTotalAmmount, boldTableFont));
        ToalCC.Colspan = 1;
        ToalCC.HorizontalAlignment = 1;
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

        Doc.Close();
        Response.ContentType = "application/pdf";
        Response.AddHeader("content-disposition", "attachment; filename=Doc1.pdf");
        Response.End(); 
    }

    private void GeneratePdfReport2()
    {
        iTextSharp.text.Document doc = new iTextSharp.text.Document();
        try
        {
            
            PdfWriter.GetInstance(doc, new FileStream("HelloWorld.pdf", FileMode.Create));
            doc.Open();
            doc.Add(new Paragraph("Hello World!"));
            doc.NewPage();
            doc.Add(new Paragraph("Hello World on a new page!"));
        }
        catch (Exception ex)
        {

        }
        finally
        {
            doc.Close();
        }

    }
    private void GeneratePdfReport()
      {
         HdnNO.Value ="0";
         GetDepositSlipData();
         GetTotalCount();

         var titleFont = FontFactory.GetFont("Arial", 12, Font.BOLD);
         var subTitleFont = FontFactory.GetFont("Arial", 11, Font.NORMAL);
         var boldTableFont = FontFactory.GetFont("Arial", 10, Font.BOLD);
         var NormalTableFont = FontFactory.GetFont("Arial", 10, Font.NORMAL);
         var endingMessageFont = FontFactory.GetFont("Arial", 10, Font.ITALIC);
         var BoldFont8 = FontFactory.GetFont("Arial", 8, Font.BOLD);
         Document Doc = new Document(PageSize.A4);

         PdfWriter.GetInstance(Doc, Response.OutputStream);

         Doc.AddCreator("This Application");
         Doc.AddAuthor("Me");
         Doc.Open();

         //Doc.Add(new Paragraph("Hello World!"));
         //Doc.NewPage();
         //Doc.Add(new Paragraph("Hello World on a new page!"));
         //for (int x = 1; x <= 2; x++)
         //{
        

         Phrase phr = new Phrase(""); //empty phrase for page numbering

        

         
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

             PdfPCell Cell21 = new PdfPCell(new Phrase(lblChequePickupdate.Text.Trim(), NormalTableFont));
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

             PdfPCell Cell41 = new PdfPCell(new Phrase(lblChequeDepositSlip.Text.Trim(), NormalTableFont));
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
             Cell7.HorizontalAlignment = 0;
             Tab.AddCell(Cell7);

             PdfPCell Cell71 = new PdfPCell(new Phrase(lblClientName.Text.Trim(), NormalTableFont));
             Cell71.Colspan = 5;
             Cell71.Border = 0;
             Cell71.HorizontalAlignment = 0;
             Tab.AddCell(Cell71);

             PdfPCell Cell8 = new PdfPCell(new Phrase("             At :", boldTableFont));
             Cell8.Colspan = 2;
             Cell8.Border = 0;
             Cell8.HorizontalAlignment = 2;
             Tab.AddCell(Cell8);

             PdfPCell Cell81 = new PdfPCell(new Phrase(HdnLocation.Value, NormalTableFont));
             Cell81.Colspan = 5;
             Cell81.Border = 0;
             Cell81.HorizontalAlignment = 0;
             Tab.AddCell(Cell81);

             PdfPCell Cell9 = new PdfPCell(new Phrase("          Account Number :" + HdnAccountNoT.Value, boldTableFont));
             Cell9.Colspan = 7;
             Cell9.Border = 0;
             Cell9.HorizontalAlignment = 0;
             Tab.AddCell(Cell9);

             PdfPCell header1 = new PdfPCell(new Phrase(""));
             header1.Colspan = 7;
             header1.Border = 0;
             header1.HorizontalAlignment = 1;
             table.AddCell(header1);

             table.AddCell(new PdfPCell(new Phrase("Sr No.", boldTableFont)));
             table.AddCell(new PdfPCell(new Phrase("Instrument Number", boldTableFont)));
             table.AddCell(new PdfPCell(new Phrase("Instrument Date", boldTableFont)));
             table.AddCell(new PdfPCell(new Phrase("Amount", boldTableFont)));
             table.AddCell(new PdfPCell(new Phrase("Bank Drawn", boldTableFont)));
             table.AddCell(new PdfPCell(new Phrase("Branch Drawn", boldTableFont)));
             table.AddCell(new PdfPCell(new Phrase("City Name", boldTableFont)));

             for (int i = 0; i <= Convert.ToInt32(HdnDsCount.Value) - 1; i++)
             {

                 HdnNO.Value = Convert.ToInt32(i).ToString();
                 GetDepositSlipData();

                 //SerialNo
                 PdfPTable nested = new PdfPTable(1);
                 nested.AddCell(new PdfPCell(new Phrase(SerialNo, NormalTableFont)));

                 PdfPCell nesthousing = new PdfPCell(nested);
                 nesthousing.Padding = 0f;
                 table.AddCell(nesthousing);

                 //Instrument_Number             
                 PdfPTable nested2 = new PdfPTable(1);
                 nested2.AddCell(new PdfPCell(new Phrase(Instrument_Number, NormalTableFont)));

                 PdfPCell nesthousing2 = new PdfPCell(nested2);
                 nesthousing2.Padding = 0f;
                 table.AddCell(nesthousing2);

                 // Instrument_Date
                 PdfPTable nested3 = new PdfPTable(1);
                 nested3.AddCell(new PdfPCell(new Phrase(Instrument_Date, NormalTableFont)));

                 PdfPCell nesthousing3 = new PdfPCell(nested3);
                 nesthousing3.Padding = 0f;
                 table.AddCell(nesthousing3);

                 //Cheque_Ammount
                 PdfPTable nested4 = new PdfPTable(1);
                 nested4.AddCell(new PdfPCell(new Phrase(Cheque_Ammount, NormalTableFont)));

                 PdfPCell nesthousing4 = new PdfPCell(nested4);
                 nesthousing4.Padding = 0f;
                 table.AddCell(nesthousing4);

                 //BankName
                 PdfPTable nested5 = new PdfPTable(1);
                 nested5.AddCell(new PdfPCell(new Phrase(BankName, NormalTableFont)));

                 PdfPCell nesthousing5 = new PdfPCell(nested5);
                 nesthousing5.Padding = 0f;
                 table.AddCell(nesthousing5);

                 //BranchName
                 PdfPTable nested6 = new PdfPTable(1);
                 nested6.AddCell(new PdfPCell(new Phrase(BranchName, NormalTableFont)));

                 PdfPCell nesthousing6 = new PdfPCell(nested6);
                 nesthousing6.Padding = 0f;
                 table.AddCell(nesthousing6);

                 //BranchCity
                 PdfPTable nested7 = new PdfPTable(1);
                 nested7.AddCell(new PdfPCell(new Phrase(BranchCity, NormalTableFont)));

                 PdfPCell nesthousing7 = new PdfPCell(nested7);
                 nesthousing7.Padding = 0f;
                 table.AddCell(nesthousing7);

             }


             PdfPTable Bottom = new PdfPTable(7);
             Bottom.TotalWidth = 550f;
             float[] widths123 = new float[] { 30f, 80f, 80f, 60f, 180f, 180f, 70f };
             Bottom.SetWidths(widths123);
             Bottom.LockedWidth = true;

             PdfPCell TotalCA = new PdfPCell(new Phrase("Total Amount & Amount In Words:", boldTableFont));
             TotalCA.Colspan = 3;
             TotalCA.HorizontalAlignment = 0;
             Bottom.AddCell(TotalCA);

             PdfPCell TotalCB = new PdfPCell(new Phrase(TotalAmount, boldTableFont));
             TotalCB.Colspan = 1;
             TotalCB.HorizontalAlignment = 0;
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




             PdfPTable Maintable  = new PdfPTable(10);
             Maintable.TotalWidth = 550f;

             PdfPCell Maintable1 = new PdfPCell(Head);
             Maintable1.Colspan = 10;
             Maintable1.Border = 0;
             Maintable1.HorizontalAlignment = 0;
             Maintable.AddCell(Maintable1);

             PdfPCell Maintable2 = new PdfPCell(test);
             Maintable2.Colspan = 10;
             Maintable2.Border = 0;
             Maintable2.HorizontalAlignment = 0;
             Maintable.AddCell(Maintable2);

             PdfPCell Maintable3 = new PdfPCell(Tab11);
             Maintable3.Colspan = 10;
             Maintable3.Border = 0;
             Maintable3.HorizontalAlignment = 0;
             Maintable.AddCell(Maintable3);

             PdfPCell Maintable4 = new PdfPCell(Tab);
             Maintable4.Colspan = 10;
             Maintable4.Border = 0;
             Maintable4.HorizontalAlignment = 0;
             Maintable.AddCell(Maintable4);

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



                 Doc.NewPage();
                 Doc.Add(Maintable);
            
               
            
             

             Doc.Close();
         //}

         //Doc.Close();
         Response.ContentType = "application/pdf";
         Response.AddHeader("content-disposition", "attachment; filename=Doc1.pdf");
         Response.End(); 
         
     }  
  
    private void GetDepositSlipData()
    {
        try
        {
            Object SaveUSERInfo = (Object)Session["UserInfo"];

            SqlConnection sqlcon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);


            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlcon;
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.CommandText = "GetDepositSlipData";
            sqlcmd.CommandTimeout = 0;



            SqlParameter BranchID = new SqlParameter();
            BranchID.SqlDbType = SqlDbType.Int;
            BranchID.Value = Convert.ToInt32(((UserInfo.structUSERInfo)(SaveUSERInfo)).BranchId);
            BranchID.ParameterName = "@BranchID";
            sqlcmd.Parameters.Add(BranchID);

            SqlParameter BatchNo = new SqlParameter();
            BatchNo.SqlDbType = SqlDbType.VarChar;
            BatchNo.Value = txtBatchNo.Text.Trim();
            BatchNo.ParameterName = "@BatchNo";
            sqlcmd.Parameters.Add(BatchNo);


            sqlcon.Open();
            SqlDataAdapter sqlda = new SqlDataAdapter();
            sqlda.SelectCommand = sqlcmd;
            DataSet ds = new DataSet();
            sqlda.Fill(ds);

            sqlcon.Close();

            HdnDsCount.Value = ds.Tables[0].Rows.Count.ToString();


            int m = Convert.ToInt32(HdnNO.Value);
            {
                SerialNo = ds.Tables[0].Rows[m]["SerialNo"].ToString();
                Instrument_Number = ds.Tables[0].Rows[m]["Instrument_Number"].ToString();
                Instrument_Date = ds.Tables[0].Rows[m]["Instrument_Date"].ToString();
                Cheque_Ammount = ds.Tables[0].Rows[m]["Cheque_Ammount"].ToString();
                BankName = ds.Tables[0].Rows[m]["BankName"].ToString();
                BranchName = ds.Tables[0].Rows[m]["BranchName"].ToString();
                BranchCity = ds.Tables[0].Rows[m]["BranchCity"].ToString();

                Deposite_SlipNo = ds.Tables[0].Rows[m]["Deposite_SlipNo"].ToString();
                IntrumentType = ds.Tables[0].Rows[m]["IntrumentType"].ToString();

                Deposit_Date = ds.Tables[0].Rows[m]["Deposit_Date"].ToString();
                Pickup_Date = ds.Tables[0].Rows[m]["Pickup_Date"].ToString();
                Type_of_Clearing = ds.Tables[0].Rows[m]["Type_of_Clearing"].ToString();


            }


        }
        catch (Exception ex)
        {
            lblMessage.Text = "Error Record Not Found";

        }

        finally
        { 
        
        
        }
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Pages/Menu.aspx", true);     
    }

    private void GetTotalCount()
    {
        try
        {
            Object SaveUSERInfo = (Object)Session["UserInfo"];

            SqlConnection sqlcon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);



            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlcon;
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.CommandText = "GetTotallAmount";
            sqlcmd.CommandTimeout = 0;


            SqlParameter BranchID = new SqlParameter();
            BranchID.SqlDbType = SqlDbType.Int;
            BranchID.Value = Convert.ToInt32(((UserInfo.structUSERInfo)(SaveUSERInfo)).BranchId);
            BranchID.ParameterName = "@BranchID";
            sqlcmd.Parameters.Add(BranchID);

            SqlParameter BatchNo = new SqlParameter();
            BatchNo.SqlDbType = SqlDbType.VarChar;
            BatchNo.Value = txtBatchNo.Text.Trim();
            BatchNo.ParameterName = "@BatchNo";
            sqlcmd.Parameters.Add(BatchNo);


            sqlcon.Open();
            SqlDataAdapter sqlda = new SqlDataAdapter();
            sqlda.SelectCommand = sqlcmd;
            DataSet ds = new DataSet();
            sqlda.Fill(ds);
            sqlcon.Close();

            TotalAmount = ds.Tables[0].Rows[0]["TotalAmount"].ToString();
            rupees.Value = ds.Tables[0].Rows[0]["TotalAmount"].ToString();


        }
        catch (Exception ex)
        {
            lblMessage.Text = "Error Record Not Found";
        }

        finally
        { 
        
        }
    }

    private void DetTotalSummaryData()
    {
        try
        {
            Object SaveUSERInfo = (Object)Session["UserInfo"];

            SqlConnection sqlcon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);


            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlcon;
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.CommandText = "GetDepositSlipGrandSummaryTotalCount";
            sqlcmd.CommandTimeout = 0;



            SqlParameter Pickupdate = new SqlParameter();
            Pickupdate.SqlDbType = SqlDbType.VarChar;
            Pickupdate.Value = lblChequePickupdate.Text;
            Pickupdate.ParameterName = "@FromDate";
            sqlcmd.Parameters.Add(Pickupdate);

            SqlParameter DepositSlip = new SqlParameter();
            DepositSlip.SqlDbType = SqlDbType.VarChar;
            DepositSlip.Value = lblChequeDepositSlip.Text;
            DepositSlip.ParameterName = "@ToDate";
            sqlcmd.Parameters.Add(DepositSlip);


            sqlcon.Open();
            SqlDataAdapter sqlda = new SqlDataAdapter();
            sqlda.SelectCommand = sqlcmd;
            DataSet ds = new DataSet();
            sqlda.Fill(ds);

            SummaryTotalAmmount = ds.Tables[0].Rows[0]["Amount"].ToString();
            SummaryIntrumentTypeTotalCount = ds.Tables[0].Rows[0]["IntrumentTypeCount"].ToString();
            summaryrupees.Value = ds.Tables[0].Rows[0]["Amount"].ToString();

            sqlcon.Close();
        }
        catch (Exception ex)
        {
            lblMessage.Text = "Error Record Not Found";
        }

        finally
        { }
    }

    private void GetDepositSlipGrandSummaryData()
    {
        try
        {
            Object SaveUSERInfo = (Object)Session["UserInfo"];

            SqlConnection sqlcon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);


            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlcon;
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.CommandText = "GetDepositSlipGrandSummaryData";
            sqlcmd.CommandTimeout = 0;


            SqlParameter Pickupdate = new SqlParameter();
            Pickupdate.SqlDbType = SqlDbType.VarChar;
            Pickupdate.Value = lblChequePickupdate.Text;
            Pickupdate.ParameterName = "@FromDate";
            sqlcmd.Parameters.Add(Pickupdate);

            SqlParameter DepositSlip = new SqlParameter();
            DepositSlip.SqlDbType = SqlDbType.VarChar;
            DepositSlip.Value = lblChequeDepositSlip.Text;
            DepositSlip.ParameterName = "@ToDate";
            sqlcmd.Parameters.Add(DepositSlip);


            sqlcon.Open();
            SqlDataAdapter sqlda = new SqlDataAdapter();
            sqlda.SelectCommand = sqlcmd;
            DataSet ds = new DataSet();
            sqlda.Fill(ds);

            HdnDs11Count.Value = ds.Tables[0].Rows.Count.ToString();

            int m = Convert.ToInt32(HdnNO.Value);
            {
                SummaryIntrumentTypeCount = ds.Tables[0].Rows[m]["IntrumentTypeCount"].ToString();
                SummaryType_of_Clearing = ds.Tables[0].Rows[m]["Type_of_Clearing"].ToString();



                SummaryDeposite_SlipNo = ds.Tables[0].Rows[m]["Deposite_SlipNo"].ToString();
                SummaryAmount = ds.Tables[0].Rows[m]["Amount"].ToString();

            }
            sqlcon.Close();
        }
        catch (Exception ex)
        {
            lblMessage.Text = "Error Record Not Found";
        }
        finally
        { 
        }
    }

    protected void btnGenerateDepositSlipGrandSummary_Click1(object sender, EventArgs e)
    {
        DepositSlipGrandSummary();
    }

    private void Validation11()
    {
        btnGenerateDepositSlip.Attributes.Add("onclick", "javascript:return Convert();");
    }

    private void Validation12()
    {
        btnGenerateDepositSlipGrandSummary.Attributes.Add("onclick", "javascript:return ConvertSummary();");
    }
}
