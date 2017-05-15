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
    public partial class UnpaidBillReportUI : System.Web.UI.Page
    {

        UnpaidBillReportManager aUnpaidBillReportManager = new UnpaidBillReportManager();

        List<UnpaidBillReport> aUnpaidBillReportLists = new List<UnpaidBillReport>();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                fromDateTextBox.Text = DateTime.Now.ToShortDateString();
                toDateTextBox.Text = DateTime.Now.ToShortDateString();

                unpaidBillReportGridView.DataSource = null;
                unpaidBillReportGridView.DataBind();
            }
        }

        protected void showButton_Click(object sender, EventArgs e)
        {

            showUnpaidBill();
        }

        private void showUnpaidBill()
        {
            List<UnpaidBillReport> aUnpainBillReportList = aUnpaidBillReportManager.GetAllUnpaidBillReports(Convert.ToDateTime(fromDateTextBox.Text), Convert.ToDateTime(toDateTextBox.Text));
            decimal vTotalAmount = 0;
            decimal vDueAmount = 0;

            foreach (UnpaidBillReport aUnpaidBillReport in aUnpainBillReportList)
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
                vTotalAmount += aUnpaidBillReport.TotalAmount;
                vDueAmount += aUnpaidBillReport.DueAmount;
                //aTests.fromDate = aTestWiseReport.fromDate;
                //aTests.toDate = aTestWiseReport.toDate;

                //aTestWiseReportLists.Add(aTests);
                //ViewState["TestRequestEntry"] = aTestWiseReportLists;
            }

            //testWiseReportGridView.DataSource = ViewState["TestRequestEntry"];
            unpaidBillReportGridView.DataSource = aUnpainBillReportList;
            unpaidBillReportGridView.DataBind();
            totalAmountLabel.Text = vTotalAmount.ToString();
            totalDueAmountLabel.Text = vDueAmount.ToString();
        }

        protected void pdfButton_Click(object sender, EventArgs e)
        {
            int columnsCount = unpaidBillReportGridView.HeaderRow.Cells.Count;
            PdfPTable pdfTable = new PdfPTable(columnsCount);
            foreach (TableCell gridViewHeaderCell in unpaidBillReportGridView.HeaderRow.Cells)
            {
                Font font = new Font();
                font.Color =BaseColor.BLACK ;//new BaseColor(unpaidBillReportGridView.HeaderStyle.ForeColor);
                PdfPCell pdfCell = new PdfPCell(new Phrase(gridViewHeaderCell.Text, font));
                pdfTable.AddCell(pdfCell);
            }

            foreach (GridViewRow gridViewRow in unpaidBillReportGridView.Rows)
            {
                if (gridViewRow.RowType == DataControlRowType.DataRow)
                {
                    //foreach (TableCell gridViewCell in gridViewRow.Cells)
                    //{
                    //    Font font = new Font();
                    //    font.Color = BaseColor.BLACK; //new BaseColor(unpaidBillReportGridView.RowStyle.ForeColor);
                    //    //PdfPCell pdfCell = new PdfPCell(new Phrase(gridViewCell.Text, font));
                    //    PdfPCell pdfCell = new PdfPCell(new Phrase("100", font));
                    //    pdfTable.AddCell(pdfCell);
                    //}

                    List<UnpaidBillReport> aUnpainBillReportList = aUnpaidBillReportManager.GetAllUnpaidBillReports(Convert.ToDateTime(fromDateTextBox.Text), Convert.ToDateTime(toDateTextBox.Text));
                    foreach (UnpaidBillReport aUnpaidBillReport in aUnpainBillReportList)
                    {
                        Font font = new Font();
                        font.Color = BaseColor.BLACK; //new BaseColor(unpaidBillReportGridView.RowStyle.ForeColor);
                        PdfPCell pdfCell = new PdfPCell(new Phrase(aUnpaidBillReport.TotalAmount.ToString(), font));
                        PdfPCell pdfCell1 = new PdfPCell(new Phrase(aUnpaidBillReport.BillNo.ToString(), font));
                        PdfPCell pdfCell2 = new PdfPCell(new Phrase(aUnpaidBillReport.BillNo.ToString(), font));

                        pdfTable.AddCell(pdfCell);
                        pdfTable.AddCell(pdfCell1);

                    }


                }
            }

            foreach (TableCell gridViewHeaderCell in unpaidBillReportGridView.FooterRow.Cells)
            {
                Font font = new Font();
                font.Color = BaseColor.BLACK; //new BaseColor(unpaidBillReportGridView.FooterStyle.ForeColor);
                PdfPCell pdfCell = new PdfPCell(new Phrase(gridViewHeaderCell.Text, font));
                pdfTable.AddCell(pdfCell);
            }
            Document pdfDocument = new Document(PageSize.A4, 20f, 10f, 10f, 10f);
            PdfWriter.GetInstance(pdfDocument, Response.OutputStream);
            string Name = "                                                     Diagnostic Center Bill Management System";
            string moduleName = "                                                            Unpaid Bill Report";
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
            Response.AppendHeader("content-disposition", "attachment;filename=UnPaidBillReport.pdf");
            Response.Write(pdfDocument);
            Response.Flush();
            Response.End();
        }

    }
}