using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DiagnosticApp.DAL;
using DiagnosticApp.Models;

namespace DiagnosticApp.BLL
{
    public class TestRequestManager
    {
        public  TestRequestGateway aTestRequestGateway = new TestRequestGateway();


      
        public List<TestRequestEntry> GetAllRequests(List<TestRequestEntry> aEntries)
        {
            List<TestRequestEntry> aTestRequestLists = new List<TestRequestEntry>();

            TestRequestEntry aTestRequest =new TestRequestEntry();

            foreach ( TestRequestEntry aRequest in aEntries)
            {
                aTestRequest.TestId = aRequest.TestId;
                aTestRequest.TestName = aRequest.TestName;
                aTestRequest.Fee = aRequest.Fee;
                aTestRequest.TotalAmount+=aRequest.Fee;

                aTestRequestLists.Add(aTestRequest);
            }
            return aTestRequestLists;
        }

        public List<TestRequestEntry> GetAllTestEnries(Int64 PatientId)
        {
            return aTestRequestGateway.GetAllTestEnries(PatientId);
        }


        public TestSetup GetTestNameInfo(int testId)
        {
            TestSetup aTestSetup = new TestSetup();
            aTestSetup = aTestRequestGateway.GetTestNameInfo(testId);
            return aTestSetup;
        }

        public int SavePatientTests(List<TestRequestEntry> aEntries,int patientId)
        {
            return aTestRequestGateway.SavePatientTests(aEntries, patientId);
        }
    }
}