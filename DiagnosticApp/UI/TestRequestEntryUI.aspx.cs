using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using DiagnosticApp.BLL;
using DiagnosticApp.Models;
using DiagnosticApp.Reports;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Font = iTextSharp.text.Font;

namespace DiagnosticApp.UI
{
    public partial class TestRequestEntryUI : System.Web.UI.Page
    {
        private string vBillNo;

        List<TestRequestEntry> aTestRequestEntryList = new List<TestRequestEntry>();


        TestRequestManager aTestRequestManager = new TestRequestManager();
        PatientManager aPatientManager = new PatientManager();


        protected void Page_Load(object sender, EventArgs e)
        {
            
            
            if(!IsPostBack)
            {
                LoadTestsList();
                GridView2.DataSource = null;
                GridView2.DataBind();

            }

        }
        protected void addButton_Click(object sender, EventArgs e)
        {
            AddToGridView();
        }

        private void AddToGridView()
        {

            if (Convert.ToInt32(testFeeTextBox.Text.ToString()) <= 0)
            {
                msgTestRequestLabel.Text = "Test Fee Must Be Greater Than Zero!";
                return;
            }

            if (Convert.ToInt32(testNameDropDownList.SelectedIndex.ToString()) == 0)
            {
                msgTestRequestLabel.Text = "Test Name Is Empty!";
                return;
            }


            if (ViewState["TestRequestEntry"] != null)
            {
                aTestRequestEntryList = (List<TestRequestEntry>) ViewState["TestRequestEntry"];
            }
            
            TestRequestEntry aTestRequestEntry = new TestRequestEntry();
            aTestRequestEntry.TestId = Convert.ToInt16( testNameDropDownList.SelectedValue.ToString());
            aTestRequestEntry.TestName = testNameDropDownList.SelectedItem.Text.ToString();
            aTestRequestEntry.Fee=Convert.ToDecimal( testFeeTextBox.Text.ToString());
            
            aTestRequestEntryList.Add(aTestRequestEntry);
            ViewState["TestRequestEntry"] = aTestRequestEntryList;

            //List<TestRequestEntry> aTestRequestAddToGridView = aTestRequestManager.GetAllRequests(aTestRequestEntryList);
            //GridView2.DataSource = aTestRequestAddToGridView;//ViewState["TestRequestEntry"];
            GridView2.DataSource = ViewState["TestRequestEntry"];
            GridView2.DataBind();

        }
       

        public void LoadTestsList()
        {
            TestSetupManager aTestSetupManager = new TestSetupManager();
            List<TestSetup> aTestSetupList = aTestSetupManager.GetAllTestListNames();

            testNameDropDownList.DataSource = aTestSetupList;
            testNameDropDownList.DataTextField = "TestName";
            testNameDropDownList.DataValueField = "TestId";
            testNameDropDownList.DataBind();
            testNameDropDownList.Items.Insert(0, "< Select >");
            
        }

        private decimal total = 0;

        protected void GridView2_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                total += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Fee"));
            }
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                Label totaLabel = (Label)e.Row.FindControl("totalAmountLabel");
                totaLabel.Text = total.ToString();
            }
        }

        protected void testNameDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            TestSetup aTestSetup = aTestRequestManager.GetTestNameInfo(Convert.ToInt32(testNameDropDownList.SelectedValue));
            testFeeTextBox.Text = aTestSetup.TestId.ToString(); ;
            testIdTextBox.Value = aTestSetup.Fee.ToString();
        }

        protected void saveButton_Click(object sender, EventArgs e)
        {
            try
            {
                SavePaitents();
                Report();
                //PrintReport();
                Clear();

            }
            catch (Exception exception)
            {
                msgTestRequestLabel.Text = exception.Message;
            }
        }

        private void PrintReport()
        {
            int columnsCount = GridView2.HeaderRow.Cells.Count;
            PdfPTable pdfTable = new PdfPTable(columnsCount);
            foreach (TableCell gridViewHeaderCell in GridView2.HeaderRow.Cells)
            {
                Font font = new Font();
                font.Color = new BaseColor(GridView2.HeaderStyle.ForeColor);
                PdfPCell pdfCell = new PdfPCell(new Phrase(gridViewHeaderCell.Text, font));
                pdfTable.AddCell(pdfCell);
            }
            foreach (GridViewRow gridViewRow in GridView2.Rows)
            {
                if (gridViewRow.RowType == DataControlRowType.DataRow)
                {
                    foreach (TableCell gridViewCell in gridViewRow.Cells)
                    {
                        Font font = new Font();
                        font.Color = new BaseColor(GridView2.RowStyle.ForeColor);

                        PdfPCell pdfCell = new PdfPCell(new Phrase(gridViewCell.Text, font));

                        pdfTable.AddCell(pdfCell);
                    }
                }
            }

            foreach (TableCell gridViewHeaderCell in GridView2.FooterRow.Cells)
            {
                Font font = new Font();
                font.Color = new BaseColor(GridView2.FooterStyle.ForeColor);
                PdfPCell pdfCell = new PdfPCell(new Phrase(gridViewHeaderCell.Text, font));
                pdfTable.AddCell(pdfCell);
            }

            Document pdfDocument = new Document(PageSize.A4, 20f, 10f, 10f, 10f);
            PdfWriter.GetInstance(pdfDocument, Response.OutputStream);
            string Name = "                                                     Diagnostic Center Bill Management System";
            string moduleName = "                                                                Patient Bill Report";
            pdfDocument.Open();
            pdfDocument.Add(new Paragraph(" \n"));
            pdfDocument.Add(new Paragraph("                                                                                                                 " + DateTime.Now.ToString()));
            pdfDocument.Add(new Paragraph(Name));
            pdfDocument.Add(new Paragraph(" \n"));
            pdfDocument.Add(new Paragraph("\t" + moduleName));
            pdfDocument.Add(new Paragraph(" \n\n"));
            pdfDocument.Add(new Paragraph("Patient Name: " + patientNameTextBox.Text));
            pdfDocument.Add(new Paragraph("Mobile Number: " + mobileNoTextBox.Text));
            pdfDocument.Add(new Paragraph("Bill Number: " + vBillNo));
            pdfDocument.Add(new Paragraph(" \n\n"));
            pdfDocument.Add(new Paragraph(" \n\n"));
            pdfDocument.Add(new Paragraph(" \n\n"));
            pdfDocument.Add(pdfTable);
            pdfDocument.Close();
            Response.ContentType = "application/pdf";
            Response.AppendHeader("content-disposition", "attachment;filename=PatientBillReport.pdf");
            Response.Write(pdfDocument);
            Response.Flush();
            Response.End();
        }

        private void Report()
        {
            
            RequestEntry rp1= new RequestEntry();
            ReportDocument td = rp1;
            string rptTitle = vBillNo.Trim();

            td.SetParameterValue("id", rptTitle);
            //if not works then
            //ParameterDiscreteValue val = new ParameterDiscreteValue();
            //val.Value = rptTitle;

            //ParameterValues paramVals = new ParameterValues();

            //paramVals.Add(val);

            //td.ParameterFields["id"].CurrentValues = paramVals;

            //td.DataDefinition.ParameterFields[0].ApplyCurrentValues(paramVals);
            MemoryStream memoryStream = new MemoryStream();
            Stream oStream = Stream.Null;
            oStream = td.ExportToStream(ExportFormatType.PortableDocFormat);
            CopyStream(oStream, memoryStream);
            
            Response.Clear();
            Response.Buffer = true;
            Response.ContentType = "application/pdf";
            try
            {
                Response.BinaryWrite(memoryStream.ToArray());
            }
            catch (Exception ex)
            {

                Response.Write(ex.Message);
            }
           
            Response.Flush();
            HttpContext.Current.ApplicationInstance.CompleteRequest();
        }
        public static void CopyStream(Stream input, Stream output)
        {
            byte[] buffer = new byte[16 * 1024];
            int read;
            while ((read = input.Read(buffer, 0, buffer.Length)) > 0)
            {
                output.Write(buffer, 0, read);
            }
        }

        private void Clear()
        {
            patientNameTextBox.Text = "";
            dateOfBirthTextBox.Text = "";
            mobileNoTextBox.Text = "";
            testNameDropDownList.SelectedIndex = -1;
            testFeeTextBox.Text = "0.00";

            GridView2.DataSource = null;
            GridView2.DataBind();
        }

        private void SavePaitents()
        {
           try
           {    
               Patients aPatients= new Patients();
               
               aPatients.PatientName = patientNameTextBox.Text.ToString();
               aPatients.DateOfBirth = Convert.ToDateTime(dateOfBirthTextBox.Text);
               aPatients.MobileNo = mobileNoTextBox.Text.ToString();
               //aPatients.BillDate   =Convert.ToDateTime( DateTime.Now());
               aPatients.BillNo = aPatientManager.GetBillNo();
               vBillNo = aPatients.BillNo;

               aPatients.PatientId = aPatientManager.SavePatients(aPatients);
               //int PatinetId = 0;
               //PatinetId = aPatientManager.SavePatients(aPatients);

               if (aPatients.PatientId > 0)
               {
                   SavePaitentTests(Convert.ToInt32( aPatients.PatientId));
               }
                else
                {
                    msgTestRequestLabel.Text = "Save Failed!";
                }
                
            }
            catch (Exception exception)
            {
                msgTestRequestLabel.Text = exception.Message;
            }
        }

        private void SavePaitentTests(int patientId)
        {
            int rowsAffected = 0;
//            rowsAffected = aTestRequestManager.SavePatientTests();

            if (ViewState["TestRequestEntry"] != null)
            {
                aTestRequestEntryList = (List<TestRequestEntry>) ViewState["TestRequestEntry"];

                rowsAffected = aTestRequestManager.SavePatientTests(aTestRequestEntryList, patientId);

                if (rowsAffected > 0)
                {
                    msgTestRequestLabel.Text = "Save Successfully.";
                }
                else
                {
                    msgTestRequestLabel.Text = "Save Failed!";
                }
            }


        }

        protected void GridView2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

       
      
}
    }
