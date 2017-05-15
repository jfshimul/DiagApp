using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.EnterpriseServices;
using System.Linq;
using System.Web;
using DiagnosticApp.Models;
using DiagnosticApp.UI;
using System.Web.Configuration;
using System.Web.Services.Discovery;

namespace DiagnosticApp.DAL
{
    public class PatientGateway
    {
        //string connectionString = @"Server=PROCIS-W7\MSSQLSERVER_14;DataBase=DiagnosticAppDB;Integrated Security=true;";
        //string connectionString = @"Server=PC-301-29\SQLEXPRESS;DataBase=DiagnosticAppDB;Integrated Security=true;";
        //string connectionString = @"Server=VS-2013\SQLEXPRESS;DataBase=DiagnosticAppDB;Integrated Security=true;";
        string connectionString = WebConfigurationManager.ConnectionStrings["DiagnosticAppDB"].ConnectionString;


        public string GetBillNo()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "SELECT * FROM vwBillNo";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();

            string billNo = "";

            if (reader.HasRows)
            {
                reader.Read();
                billNo = ""+reader["MaxBillNo"].ToString();
                reader.Close();
            }
            connection.Close();
            return billNo;
        }



        //public TestSetup GetDuplicateTestName(string name)
        //{
        //    SqlConnection connection = new SqlConnection(connectionString);
        //    string query = "SELECT * FROM Tests  where TestName='" + name + "'";
        //    SqlCommand command = new SqlCommand(query, connection);
        //    connection.Open();
        //    SqlDataReader reader = command.ExecuteReader();
            
        //    TestSetup aTestSetup = new TestSetup();

        //    if (reader.HasRows)
        //    {
        //        reader.Read();
        //        aTestSetup.TestName = reader["TestName"].ToString();
        //        reader.Close();
        //    }
        //    connection.Close();
        //    return aTestSetup;
        //}

        public List<TestRequestEntry> GetAllTestEnries() 
        {
            List<TestRequestEntry> aTestRequestEntries = new List<TestRequestEntry>();
            SqlConnection connection = new SqlConnection(connectionString);
            //string query = "SELECT * FROM vwTests ORDER BY TestName ASC";
            
            //SqlCommand command = new SqlCommand(query, connection);
            //connection.Open();
            //SqlDataReader reader = command.ExecuteReader();
            
            //int vCnt=0;

            //if (reader.HasRows)
            //{
            //    while (reader.Read())
            //    {
            //        TestSetup testSetup = new TestSetup();
            //        testSetup.TestId = ++vCnt;
            //        testSetup.TestName = reader["TestName"].ToString();
            //        testSetup.Fee = Convert.ToDecimal(reader["Fee"].ToString());
            //        testSetup.TestTypeName = reader["TestTypeName"].ToString();
            //        testNameList.Add(testSetup);
            //    }
            //    reader.Close();
            //}
            //connection.Close();
            return aTestRequestEntries;
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

        //public TestSetup GetTestNameInfo(int testId)
        //{
        //    TestSetup aTestSetup = new TestSetup();
            
        //    SqlConnection connection = new SqlConnection(connectionString);
        //    string query = "SELECT * FROM Tests WHERE testId="+testId+"";

        //    SqlCommand command = new SqlCommand(query, connection);
        //    connection.Open();
        //    SqlDataReader reader = command.ExecuteReader();

        //    if (reader.HasRows)
        //    {
        //        while (reader.Read())
        //        {
        //            aTestSetup.TestId = Convert.ToInt32(reader["TestId"]);
        //            aTestSetup.TestName = reader["TestName"].ToString();
        //            aTestSetup.Fee = Convert.ToDecimal(reader["Fee"]);
        //        }
        //        reader.Close();
        //    }
        //    connection.Close();
        //    return aTestSetup;
        //}


        public int SavePatients(Patients aPatients)
        {
            int PatientId =0;

            PatientId = GetMaxPatientId();

            SqlConnection connection = new SqlConnection(connectionString);

            string query = "INSERT INTO Patients (" +
                           "PatientName                                   ,DateOfBirth                                   ,"+
                           "MobileNo                                      ,BillNo                                        ,"+
                           "PatientId                                     )"+
                           "VALUES('" + aPatients.PatientName + "'        ,CONVERT(DATE,'"+ aPatients.DateOfBirth + "',103)                ,"+ 
                           "'" + aPatients.MobileNo + "'                  ,'"+ aPatients.BillNo +"'                      ,"+
                           "" + ++PatientId + ")";

            SqlCommand command = new SqlCommand(query, connection);
            command.CommandType = CommandType.Text;
            connection.Open();
            //int PatientId =Convert.ToInt32(command.ExecuteScalar());
            
            
            command.ExecuteNonQuery();
            connection.Close();
            return PatientId;
            
        }

        private int GetMaxPatientId()
        {
            int maxPatientID = 0;

            SqlConnection connection = new SqlConnection(connectionString);
            string query = "SELECT ISNULL(MAX(PatientId),1) AS PatientId FROM Patients ";

            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    maxPatientID=Convert.ToInt32(reader["PatientId"]);
                }
                reader.Close();
            }
            connection.Close();

            return maxPatientID;

        }
    }
}