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
using DiagnosticApp.Models.ViewModel;

namespace DiagnosticApp.DAL
{
    public class TypeWiseReportGateway
    {
        //string connectionString = @"Server=PROCIS-W7\MSSQLSERVER_14;DataBase=DiagnosticAppDB;Integrated Security=true;";
        //string connectionString = @"Server=PC-301-29\SQLEXPRESS;DataBase=DiagnosticAppDB;Integrated Security=true;";
        //string connectionString = @"Server=VS-2013\SQLEXPRESS;DataBase=DiagnosticAppDB;Integrated Security=true;";
        string connectionString = WebConfigurationManager.ConnectionStrings["DiagnosticAppDB"].ConnectionString;

        public List<Models.ViewModel.TypeWiseReport> GetAllTypeWiseReport(DateTime fromDate, DateTime toDate)
        {   
            List<TypeWiseReport> aTypeWiseReportList = new List<TypeWiseReport>();
            
            SqlConnection connection = new SqlConnection(connectionString);

            string query =
                "SELECT TestTypes.TestTypeId, TestTypes.TestTypeName, COUNT(r.TestTypeId) AS TotalTests, ISNULL(SUM(r.Fee), 0) AS TotalAmount " +
                "FROM  ( SELECT TestTypeId, Fee " +
                "FROM  vwPatients AS p " +
                "WHERE BillDate BETWEEN CONVERT(DATE, '" + fromDate.ToShortDateString() + "', 103) AND CONVERT(DATE, '" + toDate.ToShortDateString() + "', 103)) AS r " +
                "RIGHT OUTER JOIN TestTypes ON r.TestTypeId = TestTypes.TestTypeId " +
                "GROUP BY TestTypes.TestTypeId, TestTypes.TestTypeName ";
            
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    TypeWiseReport aTypeWiseReport = new TypeWiseReport();
                    aTypeWiseReport.TestTypeId = Convert.ToInt32(reader["TestTypeId"].ToString());
                    aTypeWiseReport.TestTypeName = reader["TestTypeName"].ToString();
                    aTypeWiseReport.TotalTests = Convert.ToInt32(reader["TotalTests"].ToString());
                    aTypeWiseReport.TotalAmount = Convert.ToDecimal(reader["TotalAmount"].ToString());
                    aTypeWiseReport.fromDate = Convert.ToDateTime(fromDate.ToShortDateString());
                    aTypeWiseReport.toDate = Convert.ToDateTime(toDate.ToShortDateString());

                    aTypeWiseReportList.Add(aTypeWiseReport);
                }
                reader.Close();
            }
            connection.Close();
            return aTypeWiseReportList;

        }
    }
}