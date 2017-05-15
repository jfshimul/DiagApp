using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using DiagnosticApp.Models;
using DiagnosticApp.UI;
using System.Web.Configuration;

namespace DiagnosticApp.DAL
{
    public class TestSetupGateway
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

        public List<TestSetup> GetAllTestNames() 
        {
            List<TestSetup> testNameList = new List<TestSetup>();
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "SELECT * FROM vwTests ORDER BY TestName ASC";
            
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            
            int vCnt=0;

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    TestSetup testSetup = new TestSetup();
                    testSetup.TestId = ++vCnt;
                    testSetup.TestName = reader["TestName"].ToString();
                    testSetup.Fee = Convert.ToDecimal(reader["Fee"].ToString());
                    testSetup.TestTypeName = reader["TestTypeName"].ToString();
                    testNameList.Add(testSetup);
                }
                reader.Close();
            }
            connection.Close();
            return testNameList;
        }

        public List<TestSetup> GetAllTestList()
        {
            List<TestSetup> testNameList = new List<TestSetup>();
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "SELECT * FROM vwTests ORDER BY TestName ASC";

            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();

            

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    TestSetup testSetup = new TestSetup();
                    testSetup.TestId =Convert.ToInt16( reader["TestId"].ToString());
                    testSetup.TestName = reader["TestName"].ToString();
                    testSetup.Fee = Convert.ToDecimal(reader["Fee"].ToString());
                    testSetup.TestTypeName = reader["TestTypeName"].ToString();
                    testNameList.Add(testSetup);
                }
                reader.Close();
            }
            connection.Close();
            return testNameList;
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

    }
}