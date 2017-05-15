using System;
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
    public partial class TestSetupUI : System.Web.UI.Page
    {
        TestSetupManager aTestSetupManager = new TestSetupManager();

        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (!IsPostBack)
            {
                LoadAllTestSetup();

            }
        }

        public void LoadAllTestSetup()
        {
            TestSetupManager testSetupManager = new TestSetupManager();
            List<TestSetup> testSetupList = testSetupManager.GetAllTestList();

            GridView2.DataSource = testSetupList;
            GridView2.DataBind();

            LoadAllTestTypes();

        }

        public void LoadAllTestTypes()
        {
            TestTypeManager testTypeManager = new TestTypeManager();
            List<TestType> testTypes = testTypeManager.GetAllTestList();

            TestTypeDropDownList.DataSource = testTypes;
            TestTypeDropDownList.DataTextField = "TestTypeName";
            TestTypeDropDownList.DataValueField = "TestTypeId";
            TestTypeDropDownList.DataBind();
            TestTypeDropDownList.Items.Insert(0, "< Select >");

        }

        protected void TestSetupSaveButton_Click(object sender, EventArgs e)
        {
            if (aTestSetupManager.IsTestTypeNameExist(TestNameTextBox.Text))
            {
                MsgTestSetupLabel.Text = "This Test Name Is, Already Exist.";
                MsgTestSetupLabel.ForeColor = Color.Red;
            }
            else
            {
                SaveTestSetup();

                ClearBox();

                LoadAllTestSetup();
                MsgTestSetupLabel.ForeColor = Color.Blue;
            }
        }

        private void ClearBox() {
            TestSetupIdTextBox.Text = "";
            TestNameTextBox.Text = "";
            TestFeeTextBox.Text = "0.00";
            TestTypeDropDownList.SelectedIndex = -1;
        }

        private void SaveTestSetup()
        {
            try
            {
                TestSetup aTestSetup = new TestSetup();
                aTestSetup.TestName = TestNameTextBox.Text.ToString();
                aTestSetup.Fee = Convert.ToDecimal( TestFeeTextBox.Text.ToString());
                aTestSetup.TestTypeId = Convert.ToInt16( TestTypeDropDownList.SelectedValue.ToString());

                



                int rowAffected = 0;
                //if (saveButton.Text == "Update")
                //{
                //    if (TestTypeIdTextBox.Text != "")
                //    {
                //        aProduct.ProductId = Convert.ToInt32(productHiddenField.Value);
                //    }
                //    rowAffected = productManager.Update(aProduct);

                //    if (rowAffected > 0)
                //    {
                //        msgLabel.Text = "Update Successfull!";
                //    }
                //    else
                //    {
                //        msgLabel.Text = "Update Failed!";
                //    }
                //}
                //else
                //{

                rowAffected = aTestSetupManager.SaveTestName(aTestSetup);

                if (rowAffected > 0)
                {
                    MsgTestSetupLabel.Text = "Saved Successfull!";
                }
                else
                {
                    MsgTestSetupLabel.Text = "Save Failed!";
                }
                //}

            }
            catch (Exception exception)
            {
                MsgTestSetupLabel.Text = exception.Message;
            }
        }

      
    }
}