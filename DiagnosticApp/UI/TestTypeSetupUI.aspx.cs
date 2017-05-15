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
    public partial class TestTypeSetup : System.Web.UI.Page
    {
        TestTypeManager aTestTypeManager = new TestTypeManager();

        protected void Page_Load(object sender, EventArgs e)
        {
            LoadAllTestTypes();
        }

        public void LoadAllTestTypes()
        {
            TestTypeManager testTypeManager = new TestTypeManager();
            List<TestType> testTypeList = testTypeManager.GetAllTestList();

            GridView1.DataSource = testTypeList;
            GridView1.DataBind();
        }

        protected void CloseButton_Click(object sender, EventArgs e)
        {
            
        }

        protected void SaveButton_Click(object sender, EventArgs e)
        {
            if (aTestTypeManager.IsTestTypeNameExist(TestTypeNameTextBox.Text))
            {
                MsgLabel.Text = "This Test Type Name Is, Already Exist.";
                MsgLabel.ForeColor = Color.Red;
            }
            else
            {
                SaveTestType();
                LoadAllTestTypes();
                MsgLabel.ForeColor = Color.Blue;
            }

        }

        private void SaveTestType()
        {
            try
            {
                TestType aTestType = new TestType();
                aTestType.TestTypeName = TestTypeNameTextBox.Text.ToString();
                
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

                    rowAffected = aTestTypeManager.SaveProduct(aTestType);

                    if (rowAffected > 0)
                    {   
                        MsgLabel.Text = "Saved Successfull!";
                    }
                    else
                    {
                        MsgLabel.Text = "Save Failed!";
                    }
                //}

            }
            catch (Exception exception)
            {
                MsgLabel.Text = exception.Message;
            }
        }

    }

}
