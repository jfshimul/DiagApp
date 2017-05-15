using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DiagnosticApp.BLL;
using DiagnosticApp.Models;



namespace DiagnosticApp.UI
{
    public partial class PaymentsUI : System.Web.UI.Page
    {

        List<TestRequestEntry> aTestRequestEntryList = new List<TestRequestEntry>();


        TestRequestManager aTestRequestManager = new TestRequestManager();
        PatientManager aPatientManager = new PatientManager();

        PaymentManager aPaymentManager = new PaymentManager();


        protected void Page_Load(object sender, EventArgs e)
        {
            
            
            if(!IsPostBack)
            {
                LoadTestsList();
                testsGridView.DataSource = null;
                testsGridView.DataBind();

            }

        }
        protected void addButton_Click(object sender, EventArgs e)
        {
            AddToGridView();
        }

        private void AddToGridView()
        {

            //if (Convert.ToInt32(testFeeTextBox.Text.ToString()) <= 0)
            //{
            //    msgTestRequestLabel.Text = "Test Fee Must Be Greater Than Zero!";
            //    return;
            //}

            //if (Convert.ToInt32(testNameDropDownList.SelectedIndex.ToString()) == 0)
            //{
            //    msgTestRequestLabel.Text = "Test Name Is Empty!";
            //    return;
            //}

            //if (ViewState["TestRequestEntry"] != null)
            //{
            //    aTestRequestEntryList = (List<TestRequestEntry>) ViewState["TestRequestEntry"];
            //}
            
            TestRequestEntry aTestRequestEntry = new TestRequestEntry();
            //aTestRequestEntry.TestId = Convert.ToInt16( testNameDropDownList.SelectedValue.ToString());
            //aTestRequestEntry.TestName = testNameDropDownList.SelectedItem.Text.ToString();
            //aTestRequestEntry.Fee=Convert.ToDecimal( testFeeTextBox.Text.ToString());
            
            aTestRequestEntryList.Add(aTestRequestEntry);
            ViewState["TestRequestEntry"] = aTestRequestEntryList;

            List<TestRequestEntry> aTestRequestAddToGridView = aTestRequestManager.GetAllRequests(aTestRequestEntryList);
            //GridView2.DataSource = aTestRequestAddToGridView;//ViewState["TestRequestEntry"];
            testsGridView.DataSource = ViewState["TestRequestEntry"];
            testsGridView.DataBind();

        }
       

        public void LoadTestsList()
        {
            TestSetupManager aTestSetupManager = new TestSetupManager();
            List<TestSetup> aTestSetupList = aTestSetupManager.GetAllTestListNames();

            //testNameDropDownList.DataSource = aTestSetupList;
            //testNameDropDownList.DataTextField = "TestName";
            //testNameDropDownList.DataValueField = "TestId";
            //testNameDropDownList.DataBind();
            //testNameDropDownList.Items.Insert(0, "< Select >");
            
        }

        private void Clear()
        {
            testRequestIdTextBox.Text = "";
            //billNoTextBox.Text = "";
            billDateTextBox.Text = "";
            totalFeeTextBox.Text = "";
            paidAmountTextBox.Text = "";
            dueAmountTextBox.Text = "0.00";

            testsGridView.DataSource = null;
            testsGridView.DataBind();
        }

        private void SavePayment()
        {
           try
           {   
               if ( Convert.ToDecimal( amountTextBox.Text)> Convert.ToDecimal( dueAmountTextBox.Text))
               {
                   msgPaymentErrorLabel.Text = "Payment Amount Must Be Equal Or Less Than Due Amount!";
                    return;
               }

               if (Convert.ToDecimal(amountTextBox.Text) <= 0)
               {
                   msgPaymentErrorLabel.Text = "Payment Amount Must Be Greater Than Zero/Negetive Amount!";
                   return;
               }

               Payments aPayments = new Payments();
               aPayments.PatientId = Convert.ToInt32( testRequestIdTextBox.Text.ToString());
               aPayments.PaidAmount = Convert.ToDecimal( amountTextBox.Text.ToString());

               int rowsAffect = aPaymentManager.SavePayment(aPayments);
               
               if (rowsAffect > 0)
               {
                   msgPaymentErrorLabel.Text = "Payment Saved Successfully.";
                   Clear();
               }
                else
                {
                    msgPaymentErrorLabel.Text = "Payement Saved Failed!";
                }
                
            }
            catch (Exception exception)
            {
                msgPaymentErrorLabel.Text = exception.Message;
            }
        }

        protected void searchButton_Click(object sender, EventArgs e)
        {
            Clear();
            
            SearchBill();

            amountTextBox.Text = "";
            
        }

        private void SearchBill()
        {
            Patients aPatients = new Patients();
            aPatients = aPaymentManager.GetUnpaidBillInfo(billNoTextBox.Text);
            if (aPatients.BillNo != null)
            {
                testRequestIdTextBox.Text =  aPatients.PatientId.ToString();
                billDateTextBox.Text = aPatients.BillDate.ToShortDateString();
                totalFeeTextBox.Text = aPatients.TotalFee.ToString();
                paidAmountTextBox.Text = aPatients.PaidAmount.ToString();
                dueAmountTextBox.Text = aPatients.DueAmount.ToString();
                
                if (testRequestIdTextBox.Text != null)
                {
                    LoadAllTests(aPatients.PatientId);
                }
            }
            else
            {
                msgBillNoLabel.Text = "Bill Number Not Found!";
            }
        }

        private void LoadAllTests(Int64 PatientId)
        {
            List<TestRequestEntry> aTestRequests = aTestRequestManager.GetAllTestEnries(PatientId);
            testsGridView.DataSource = aTestRequests;
            testsGridView.DataBind();
        }

        protected void payButton_Click(object sender, EventArgs e)
        {
            try
            {
                SavePayment();

                

            }
            catch (Exception exception)
            {
                msgPaymentErrorLabel.Text = exception.Message;
            }
        }

        protected void testsGridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            //decimal total =0;

            //if (e.Row.RowType == DataControlRowType.DataRow)
            //{
            //    total += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Fee"));
            //}
            //if (e.Row.RowType == DataControlRowType.Footer)
            //{
            //    Label totaLabel = (Label)e.Row.FindControl("totalAmountLabel");
            //    totaLabel.Text = total.ToString();
            //}
        }

        protected void testsGridView_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        //public void LoadAllTestTypes()
        //{
        //    //TestTypeManager testTypeManager = new TestTypeManager();
        //    //List<TestType> testTypes = testTypeManager.GetAllTestList();
        //    //testNameDropDownList.DataSource = testTypes;
        //    //testNameDropDownList.DataTextField = "TestName";
        //    //testNameDropDownList.DataValueField = "TestId";
        //    //testNameDropDownList.DataBind();
        //}

        //protected void TestSetupSaveButton_Click(object sender, EventArgs e)
        //{
        //    if (aTestSetupManager.IsTestTypeNameExist(patientNameTextBox.Text))
        //    {
        //        msgTestRequestLabel.Text = "Patient Name Is, Already Exist.";
        //        msgTestRequestLabel.ForeColor = Color.Red;
        //    }
        //    else
        //    {
        //        SaveTestSetup();

        //        ClearBox();

        //        LoadAllTestSetup();
        //        msgTestRequestLabel.ForeColor = Color.Blue;
        //    }
        //}

        //private void ClearBox() {
        //    testRequestIdTextBox.Text = "";
        //    patientNameTextBox.Text = "";
        //    //TestFeeTextBox.Text = "0.00";
        //    testNameDropDownList.SelectedIndex = -1;
        //}

        //private void SaveTestSetup()
        //{
        //    try
        //    {
        //        TestSetup aTestSetup = new TestSetup();
        //        aTestSetup.TestName = patientNameTextBox.Text.ToString();
        //        aTestSetup.Fee = Convert.ToDecimal(testFeeTextBox.Text.ToString());
        //        aTestSetup.TestId = Convert.ToInt16( testNameDropDownList.SelectedValue.ToString());


        //        int rowAffected = 0;
        //        //if (saveButton.Text == "Update")
        //        //{
        //        //    if (TestTypeIdTextBox.Text != "")
        //        //    {
        //        //        aProduct.ProductId = Convert.ToInt32(productHiddenField.Value);
        //        //    }
        //        //    rowAffected = productManager.Update(aProduct);

        //        //    if (rowAffected > 0)
        //        //    {
        //        //        msgLabel.Text = "Update Successfull!";
        //        //    }
        //        //    else
        //        //    {
        //        //        msgLabel.Text = "Update Failed!";
        //        //    }
        //        //}
        //        //else
        //        //{

        //        rowAffected = aTestSetupManager.SaveTestName(aTestSetup);

        //        if (rowAffected > 0)
        //        {
        //            msgTestRequestLabel.Text = "Saved Successfull!";
        //        }
        //        else
        //        {
        //            msgTestRequestLabel.Text = "Save Failed!";
        //        }
        //        //}

        //    }
        //    catch (Exception exception)
        //    {
        //        msgTestRequestLabel.Text = exception.Message;
        //    }
        //}
}
    }
