using iTextSharp.text;
using iTextSharp.text.pdf;
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

namespace IncidentTracker.Pages
{
    public partial class IT_Report2Page : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                btnExport.Visible = false;
            }
        }
        protected void Search()
        {
            lblMsgXls.Text = "";

            SqlConnection sqlCon = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);

            string proc = string.Empty;

            try
            {

                if (txtIncidentNumber.Text.Trim() != "")
                {

                    proc = "IT_Report2_SP";

                    SqlCommand sqlCom = new SqlCommand();
                    sqlCom.Connection = sqlCon;
                    sqlCom.CommandType = CommandType.StoredProcedure;
                    sqlCom.CommandText = proc;
                    sqlCom.CommandTimeout = 0;

                    SqlParameter FromDate = new SqlParameter();
                    FromDate.SqlDbType = SqlDbType.VarChar;
                    FromDate.Value = txtIncidentNumber.Text.Trim();
                    FromDate.ParameterName = "@IncidentNumber";
                    sqlCom.Parameters.Add(FromDate);


                    SqlDataAdapter adp = new SqlDataAdapter(sqlCom);
                    DataSet ds = new DataSet();

                    adp.Fill(ds);

                    if (ds != null && ds.Tables[0].Rows.Count > 0)
                    {

                        gvDataShow.DataSource = ds;
                        gvDataShow.DataBind();

                        ExportToPdf(ds.Tables[0]);

                        btnExport.Visible = false;
                    }
                    else
                    {
                        btnExport.Visible = false;
                        gvDataShow.DataSource = null;
                        gvDataShow.DataBind();
                        lblMsgXls.Text = "No Record Found ....!!!";
                    }
                }
                else
                {
                    btnExport.Visible = false;
                    lblMsgXls.Text = "Please Enter Incident Number....!!!";
                }


            }
            catch (Exception ex)
            {
                lblMsgXls.Visible = true;
                lblMsgXls.Text = "Error :" + ex.Message;
            }
            finally
            {
                sqlCon.Close();
                sqlCon.Dispose();
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            Search();
        }
        public void ExportToPdf(DataTable myDataTable)
        {
            Session["FirstLine"] = "  PAMAC FINSERVE PRIVATE LIMITED" + "\n"  + " A-21/C-19 Shriram Industrial Estate,13,G.D.Ambeker Road,Wadala";

            Document pdfDoc = new Document(PageSize.A4, 10, 10, 10, 10);
            try
            {
                PdfWriter.GetInstance(pdfDoc, System.Web.HttpContext.Current.Response.OutputStream);
                pdfDoc.Open();

                string clientLogo = Server.MapPath("/IncidentTracker/Images/Calc.jpg");
                string imageFilePath = Server.MapPath("/IncidentTracker/Images/Calc.jpg");
                iTextSharp.text.Image jpg = iTextSharp.text.Image.GetInstance(imageFilePath);
                //Resize image depend upon your need   
                jpg.ScaleToFit(180f, 160f);
                //Give space before image   
                jpg.SpacingBefore = -20f;
                //Give some space after the image   
                jpg.SpacingAfter = 30f;
                jpg.Alignment = Element.HEADER;
                jpg.Alignment = Element.ALIGN_CENTER;
                pdfDoc.Add(jpg);




                Chunk c = new Chunk("" + System.Web.HttpContext.Current.Session["FirstLine"] + "", FontFactory.GetFont("ARIAL BLACK", 15));

                Paragraph p = new Paragraph();
                p.SpacingBefore = 20f;
                p.Alignment = Element.ALIGN_CENTER;
                p.Add(c);
                pdfDoc.Add(p);
                Font font8 = FontFactory.GetFont("ARIAL", 15);
                DataTable dt = myDataTable;
                if (dt != null)
                {
                    //Craete instance of the pdf table and set the number of column in that table  
                    PdfPTable PdfTable = new PdfPTable(dt.Columns.Count);
                    PdfPCell PdfPCell = null;
                    for (int rows = 0; rows < dt.Rows.Count; rows++)
                    {
                        for (int column = 0; column < dt.Columns.Count; column++)
                        {
                            PdfPCell = new PdfPCell(new Phrase(new Chunk(dt.Rows[rows][column].ToString(), font8)));
                            PdfTable.AddCell(PdfPCell);
                        }
                    }

                    PdfTable.SpacingBefore = 20f; // Give some space after the text or it may overlap the table            
                    pdfDoc.Add(PdfTable); // add pdf table to the document   
                }

                pdfDoc.Close();
                Response.ContentType = "application/pdf";
                Response.AddHeader("content-disposition", "attachment; filename=Report.pdf");
                System.Web.HttpContext.Current.Response.Write(pdfDoc);
                Response.Flush();
                Response.End();
                //HttpContext.Current.ApplicationInstance.CompleteRequest();  
            }
            catch (DocumentException de)
            {
                System.Web.HttpContext.Current.Response.Write(de.Message);
            }
            catch (IOException ioEx)
            {
                System.Web.HttpContext.Current.Response.Write(ioEx.Message);
            }
            catch (Exception ex)
            {
                System.Web.HttpContext.Current.Response.Write(ex.Message);
            }
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("IT_MenuPage.aspx", true);
        }
    }
}