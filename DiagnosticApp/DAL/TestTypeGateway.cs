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
    public class TestTypeGateway
    {
        //string connectionString = @"Server=PROCIS-W7\MSSQLSERVER_14;DataBase=DiagnosticAppDB;Integrated Security=true;";        
        //string connectionString = @"Server=PC-301-29\SQLEXPRESS;DataBase=DiagnosticAppDB;Integrated Security=true;";
        //string connectionString = @"Server=VS-2013\SQLEXPRESS;DataBase=DiagnosticAppDB;Integrated Security=true;";
        string connectionString = WebConfigurationManager.ConnectionStrings["DiagnosticAppDB"].ConnectionString;

        public TestType GetDuplicateTestTypeName(string name)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "SELECT * FROM TestTypes  where TestTypeName='" + name + "'";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            
            TestType aTestType = new TestType();

            if (reader.HasRows)
            {
                reader.Read();
                aTestType.TestTypeName = reader["TestTypeName"].ToString();
                reader.Close();
            }
            connection.Close();
            return aTestType;
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

        public int SaveTestType(TestType aTestType)
        {
            SqlConnection connection = new SqlConnection(connectionString);

            string query = "INSERT INTO TestTypes (TestTypeName)VALUES('" + aTestType.TestTypeName + "')";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            int rowAffected = command.ExecuteNonQuery();
            connection.Close();
            return rowAffected;
        }

    }
}