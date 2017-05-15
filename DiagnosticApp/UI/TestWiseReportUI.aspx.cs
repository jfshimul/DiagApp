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
    public partial class TestWiseReportUI : System.Web.UI.Page
    {
        TestWiseReportManager aTestWiseReportManager = new TestWiseReportManager();
        
        List<TestWiseReport> aTestWiseReportLists = new List<TestWiseReport>();


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                fromDateTextBox.Text = DateTime.Now.ToShortDateString();
                toDateTextBox.Text = DateTime.Now.ToShortDateString();

                testWiseReportGridView.DataSource = null;
                testWiseReportGridView.DataBind();
            }
        }

        protected void showButton_Click(object sender, EventArgs e)
        {
            showTestWiseReport();

        }

        private void showTestWiseReport()
        {
            List<TestWiseReport> aTestWiseReportList = aTestWiseReportManager.GetAllTestWiseReport(Convert.ToDateTime(fromDateTextBox.Text), Convert.ToDateTime(toDateTextBox.Text));
            decimal vTotalAmount = 0;

            foreach (TestWiseReport aTestWiseReport in  aTestWiseReportList)
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
                vTotalAmount += aTestWiseReport.TotalAmount;
                //aTests.fromDate = aTestWiseReport.fromDate;
                //aTests.toDate = aTestWiseReport.toDate;

                //aTestWiseReportLists.Add(aTests);
                //ViewState["TestRequestEntry"] = aTestWiseReportLists;
            }

            //testWiseReportGridView.DataSource = ViewState["TestRequestEntry"];
            testWiseReportGridView.DataSource = aTestWiseReportList;
            testWiseReportGridView.DataBind();
            totalAmountLabel.Text = vTotalAmount.ToString();
        }

        protected void pdfButton_Click(object sender, EventArgs e)
        {
            int columnsCount = testWiseReportGridView.HeaderRow.Cells.Count;


            PdfPTable pdfTable = new PdfPTable(columnsCount);


            foreach (TableCell gridViewHeaderCell in testWiseReportGridView.HeaderRow.Cells)
            {

                Font font = new Font();
                font.Color = BaseColor.BLACK;// new BaseColor(testWiseReportGridView.HeaderStyle.ForeColor);

                PdfPCell pdfCell = new PdfPCell(new Phrase(gridViewHeaderCell.Text, font));

                pdfTable.AddCell(pdfCell);
            }

            foreach (GridViewRow gridViewRow in testWiseReportGridView.Rows)
            {
                if (gridViewRow.RowType == DataControlRowType.DataRow)
                {
                    foreach (TableCell gridViewCell in gridViewRow.Cells)
                    {
                        Font font = new Font();
                        font.Color = BaseColor.BLACK; //new BaseColor(testWiseReportGridView.RowStyle.ForeColor);

                        PdfPCell pdfCell = new PdfPCell(new Phrase(gridViewCell.Text, font));

                        pdfTable.AddCell(pdfCell);
                    }
                }
            }

            foreach (TableCell gridViewHeaderCell in testWiseReportGridView.FooterRow.Cells)
            {
                Font font = new Font();
                font.Color = BaseColor.BLACK;// new BaseColor(testWiseReportGridView.FooterStyle.ForeColor);
                PdfPCell pdfCell = new PdfPCell(new Phrase(gridViewHeaderCell.Text, font));
                pdfTable.AddCell(pdfCell);
            }


            Document pdfDocument = new Document(PageSize.A4, 20f, 10f, 10f, 10f);

            PdfWriter.GetInstance(pdfDocument, Response.OutputStream);
            string Name = "                                                     Diagnostic Center Bill Management System";
            string moduleName = "                                                            Test Wise Report";
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
            Response.AppendHeader("content-disposition", "attachment;filename=TesteWiseReport.pdf");
            Response.Write(pdfDocument);
            Response.Flush();
            Response.End();

        }

        protected void testWiseReportGridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            //decimal total = 0;
            //if (e.Row.RowType == DataControlRowType.DataRow)
            //{
            //    total += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "TotalAmount"));
            //}
            //if (e.Row.RowType == DataControlRowType.Footer)
            //{
            //    Label totaLabel = (Label)e.Row.FindControl("totalAmountLabel");
            //    totaLabel.Text = total.ToString();
            //}
        }

        protected void testWiseReportGridView_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}