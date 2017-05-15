using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DiagnosticApp.DAL;
using DiagnosticApp.Models;

namespace DiagnosticApp.BLL
{
    public class TestTypeManager
    {
        public  TestTypeGateway testTypeGateway = new TestTypeGateway();

        public List<TestType> GetAllTestList()
        {
            List<TestType> testTypes = testTypeGateway.GetAllTestTypes();
            return testTypes;
        }

        public int SaveProduct(TestType aTestType)
        {
            int row = testTypeGateway.SaveTestType(aTestType);
            return row;
        }

        public bool IsTestTypeNameExist(string name)
        {
            bool isTestTypeNameExist = false;
            TestType aTestType = testTypeGateway.GetDuplicateTestTypeName(name);
            
            if (aTestType.TestTypeName != null)
            {
                isTestTypeNameExist = true;
            }
            return isTestTypeNameExist;
        }


    }
}