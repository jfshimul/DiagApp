using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DiagnosticApp.DAL;
using DiagnosticApp.Models;

namespace DiagnosticApp.BLL
{
    public class PatientManager
    {
        PatientGateway aPatientGateway = new PatientGateway();
        

        //public List<TestType> GetAllTestType()
        //{
        //    List<TestType> tsTypes = testSetupGateway.GetAllTestTypes();
        //    return tsTypes;
        //}

        //public List<TestRequestEntry> GetAllTestRequestEntries()
        //{
        //    List<TestRequestEntry> aTestRequestEntries = aTestRequestGateway.GetAllTestEnries();
        //    return aTestRequestEntries;
        //}


        //public int SaveTestName(TestSetup aTestSetup)
        //{
        //    int row = testSetupGateway.SaveTestSetup(aTestSetup);
        //    return row;
        //}

        //public bool IsTestTypeNameExist(string name)
        //{
        //    bool isTestTypeNameExist = false;
        //    TestSetup aTestSetup = testSetupGateway.GetDuplicateTestName(name);

        //    if (aTestSetup.TestName != null)
        //    {
        //        isTestTypeNameExist = true;
        //    }
        //    return isTestTypeNameExist;
        //}



       
        

        public string GetBillNo()
        {
            return aPatientGateway.GetBillNo();
        }

        public int SavePatients(Patients aPatients)
        {
            return aPatientGateway.SavePatients(aPatients);
        }

    }
}