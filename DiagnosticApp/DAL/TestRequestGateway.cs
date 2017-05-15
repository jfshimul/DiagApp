using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using DiagnosticApp.Models;
using DiagnosticApp.UI;
using System.Web.Configuration;
using Microsoft.Ajax.Utilities;

namespace DiagnosticApp.DAL
{
    public class TestRequestGateway
    {
        //string connectionString = @"Server=PROCIS-W7\MSSQLSERVER_14;DataBase=DiagnosticAppDB;Integrated Security=true;";
        //string connectionString = @"Server=PC-301-29\SQLEXPRESS;DataBase=DiagnosticAppDB;Integrated Security=true;";
        //string connectionString = @"Server=VS-2013\SQLEXPRESS;DataBase=DiagnosticAppDB;Integrated Security=true;";
        string connectionString = WebConfigurationManager.ConnectionStrings["DiagnosticAppDB"].ConnectionString;

        public TestSetup GetDuplicateTestName(string name)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "SELECT * FROM Tests  where TestName='" + name + "'";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            
            TestSetup aTestSetup = new TestSetup();

            if (reader.HasRows)
            {
                reader.Read();
                aTestSetup.TestName = reader["TestName"].ToString();
                reader.Close();
            }
            connection.Close();
            return aTestSetup;
        }


        public List<TestRequestEntry> GetAllTestEnries(Int64 PatientId) 
        {
            List<TestRequestEntry> aTestRequestEntries = new List<TestRequestEntry>();

            SqlConnection connection = new SqlConnection(connectionString);
            string query = "SELECT * FROM vwPatientTests WHERE PatientId="+ PatientId +"";

            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    TestRequestEntry aTests = new TestRequestEntry();
                    aTests.TestId =Convert.ToInt32( reader["TestId"].ToString());
                    aTests.TestName = reader["TestName"].ToString();
                    aTests.Fee = Convert.ToDecimal(reader["Fee"].ToString());
                    aTests.TotalAmount = aTests.TotalAmount + aTests.Fee;

                    aTestRequestEntries.Add(aTests);
                }
                reader.Close();
            }
            connection.Close();
            return aTestRequestEntries;
        }


        public int SaveTestSetup(TestSetup aTestSetup)
        {
            SqlConnection connection = new SqlConnection(connectionString);

            string query = "INSERT INTO Tests (TestName,Fee,TestTypeId)VALUES('" + aTestSetup.TestName + "'," + aTestSetup.Fee + ","+aTestSetup.TestTypeId+")";

            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            int rowAffected = command.ExecuteNonQuery();
            connection.Close();
            return rowAffected;
        }

        public List<TestType> GetAllTestTypes()
        {
            List<TestType> testTypeList = new List<TestType>();
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "SELECT * FROM TestTypes ORDER BY TestTypeName ASC";

            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    TestType testType = new TestType();
                    testType.TestTypeId = (int) reader["TestTypeId"];
                    testType.TestTypeName = reader["TestTypeName"].ToString();
                    testTypeList.Add(testType);
                }
                reader.Close();
            }
            connection.Close();
            return testTypeList;
        }

        public TestSetup GetTestNameInfo(int testId)
        {
            TestSetup aTestSetup = new TestSetup();
            
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "SELECT * FROM Tests WHERE testId="+testId+"";

            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    aTestSetup.TestId = Convert.ToInt32(reader["TestId"]);
                    aTestSetup.TestName = reader["TestName"].ToString();
                    aTestSetup.Fee = Convert.ToDecimal(reader["Fee"]);
                }
                reader.Close();
            }
            connection.Close();
            return aTestSetup;
        }

        public int SavePatientTests(List<TestRequestEntry> aEntries, int patientId)
        {
            TestRequestEntry aTestRequest = new TestRequestEntry();

            SqlConnection connection = new SqlConnection(connectionString);
            int rowAffected = 0;

            foreach (TestRequestEntry aRequest in aEntries)
            {
                aTestRequest.TestId = aRequest.TestId;
                aTestRequest.TestName = aRequest.TestName;
                aTestRequest.Fee = aRequest.Fee;
                aTestRequest.TotalAmount += aRequest.Fee;

                //aTestRequestLists.Add(aTestRequest);

                string query = "INSERT INTO PatientTests (PatientId,TestId,Fee)VALUES(" + patientId + "," +
                               "" + aTestRequest.TestId + "," + aTestRequest.Fee + ")";

                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                
                rowAffected = command.ExecuteNonQuery();
                connection.Close();

            }
            return rowAffected;
            
        }
    }
}