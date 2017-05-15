using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DiagnosticApp.BLL;
using DiagnosticApp.Models.ViewModel;

using iTextSharp.text;
using iTextSharp.text.pdf;
using Font = iTextSharp.text.Font;


namespace DiagnosticApp.UI
{
    public partial class TypeWiseReportUI : System.Web.UI.Page
    {
        TypeWiseReportManager aTypeWiseReportManager = new TypeWiseReportManager();


        List<TypeWiseReport> aTypeWiseReportLists = new List<TypeWiseReport>();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                fromDateTextBox.Text = DateTime.Now.ToShortDateString();
                toDateTextBox.Text = DateTime.Now.ToShortDateString();

                typeWiseReportGridView.DataSource = null;
                typeWiseReportGridView.DataBind();
            }
        }

        protected void showButton_Click(object sender, EventArgs e)
        {

            showTypeWiseReport();
        }

        private void showTypeWiseReport()
        {
            List<TypeWiseReport> aTypeWiseReportList = aTypeWiseReportManager.GetAllTypeWiseReport(Convert.ToDateTime(fromDateTextBox.Text), Convert.ToDateTime(toDateTextBox.Text));
            decimal vTotalAmount = 0;

            foreach (TypeWiseReport aTypeWiseReport in aTypeWiseReportList)
            {
                //if (ViewState["TestRequestEntry"] != null)
                //{
                //    aTestWiseReportLists = (List<TestWiseReport>)ViewState["TestRequestEntry"];
                //}

                //TestWiseReport aTests = new TestWiseReport();

                //aTests.fromDate = aTestWiseReport.fromDate;

                //aTests.TestId = aTestWiseReport.TestId;
                //aTests.TestName = aTestWiseReport.TestName;
                //aTests.TotalTests = aTestWiseReport.TotalTests;
                //aTests.TotalAmount = aTestWiseReport.TotalAmount;
                vTotalAmount += aTypeWiseReport.TotalAmount;
                //aTests.fromDate = aTestWiseReport.fromDate;
                //aTests.toDate = aTestWiseReport.toDate;

                //aTestWiseReportLists.Add(aTests);
                //ViewState["TestRequestEntry"] = aTestWiseReportLists;
            }

            //testWiseReportGridView.DataSource = ViewState["TestRequestEntry"];
            typeWiseReportGridView.DataSource = aTypeWiseReportList;
            typeWiseReportGridView.DataBind();
            totalAmountLabel.Text = vTotalAmount.ToString();
        }

        protected void pdfButton_Click(object sender, EventArgs e)
        {
            int columnsCount = typeWiseReportGridView.HeaderRow.Cells.Count;
            PdfPTable pdfTable = new PdfPTable(columnsCount);
            foreach (TableCell gridViewHeaderCell in typeWiseReportGridView.HeaderRow.Cells)
            {
                Font font = new Font();
                font.Color = BaseColor.BLACK; //new BaseColor(typeWiseReportGridView.HeaderStyle.ForeColor);
                PdfPCell pdfCell = new PdfPCell(new Phrase(gridViewHeaderCell.Text, font));
                pdfTable.AddCell(pdfCell);
            }

            foreach (GridViewRow gridViewRow in typeWiseReportGridView.Rows)
            {
                if (gridViewRow.RowType == DataControlRowType.DataRow)
                {
                    foreach (TableCell gridViewCell in gridViewRow.Cells)
                    {
                        Font font = new Font();
                        font.Color = BaseColor.BLACK;// new BaseColor(typeWiseReportGridView.RowStyle.ForeColor);
                        PdfPCell pdfCell = new PdfPCell(new Phrase(gridViewCell.Text, font));
                        pdfTable.AddCell(pdfCell);
                    }
                }
            }

            foreach (TableCell gridViewHeaderCell in typeWiseReportGridView.FooterRow.Cells)
            {
                Font font = new Font();
                font.Color = BaseColor.BLACK; //new BaseColor(typeWiseReportGridView.FooterStyle.ForeColor);
                PdfPCell pdfCell = new PdfPCell(new Phrase(gridViewHeaderCell.Text, font));
                pdfTable.AddCell(pdfCell);
            }
            Document pdfDocument = new Document(PageSize.A4, 20f, 10f, 10f, 10f);
            PdfWriter.GetInstance(pdfDocument, Response.OutputStream);
            string Name = "                                                     Diagnostic Center Bill Management System";
            string moduleName = "                                                            Type Wise Report";
            pdfDocument.Open();
            pdfDocument.Add(new Paragraph(" \n"));
            pdfDocument.Add(new Paragraph("                                                                                                                 " + DateTime.Now.ToString()));
            pdfDocument.Add(new Paragraph(Name));
            pdfDocument.Add(new Paragraph(" \n"));
            pdfDocument.Add(new Paragraph("\t" + moduleName));
            pdfDocument.Add(new Paragraph(" \n\n"));
            pdfDocument.Add(pdfTable);
            pdfDocument.Close();
            Response.ContentType = "application/pdf";
            Response.AppendHeader("content-disposition", "attachment;filename=TypeWiseReport.pdf");
            Response.Write(pdfDocument);
            Response.Flush();
            Response.End();
        }


    }
}