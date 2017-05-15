using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DiagnosticApp.DAL;
using DiagnosticApp.Models;

namespace DiagnosticApp.BLL
{
    public class TestSetupManager
    {
        public  TestSetupGateway testSetupGateway = new TestSetupGateway();

        public List<TestType> GetAllTestType()
        {
            List<TestType> tsTypes = testSetupGateway.GetAllTestTypes();
            return tsTypes;
        }

        public List<TestSetup> GetAllTestList()
        {
            List<TestSetup> testSetups = testSetupGateway.GetAllTestNames();
            return testSetups;
        }


        public List<TestSetup>  GetAllTestListNames() 
        {
            List<TestSetup> aTestSutupList = testSetupGateway.GetAllTestList();
            return aTestSutupList;
        }

        public int SaveTestName(TestSetup aTestSetup)
        {
            int row = testSetupGateway.SaveTestSetup(aTestSetup);
            return row;
        }

        public bool IsTestTypeNameExist(string name)
        {
            bool isTestTypeNameExist = false;
            TestSetup aTestSetup = testSetupGateway.GetDuplicateTestName(name);

            if (aTestSetup.TestName != null)
            {
                isTestTypeNameExist = true;
            }
            return isTestTypeNameExist;
        }


    }
}