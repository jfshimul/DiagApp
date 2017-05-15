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
    public class UnpaidBillReportGateway
    {
        //string connectionString = @"Server=PROCIS-W7\MSSQLSERVER_14;DataBase=DiagnosticAppDB;Integrated Security=true;";
        //string connectionString = @"Server=PC-301-29\SQLEXPRESS;DataBase=DiagnosticAppDB;Integrated Security=true;";
        //string connectionString = @"Server=VS-2013\SQLEXPRESS;DataBase=DiagnosticAppDB;Integrated Security=true;";
        string connectionString = WebConfigurationManager.ConnectionStrings["DiagnosticAppDB"].ConnectionString;

        public List<Models.ViewModel.UnpaidBillReport> GetAllUnpaidBillReports(DateTime fromDate, DateTime toDate)
        {
            List<UnpaidBillReport> aUnpaidBillReportList = new List<UnpaidBillReport>();
            
            SqlConnection connection = new SqlConnection(connectionString);

            string query =
                "SELECT u.PatientId,u.PatientName, u.MobileNo,u.BillNo,u.TotalFee AS TotalAmount, u.PaidAmount,u.DueAmount " +
                "FROM  vwBillingSummary AS u " +
                "WHERE BillDate BETWEEN CONVERT(DATE, '" + fromDate.ToShortDateString() +"', 103) AND CONVERT(DATE, '" + toDate.ToShortDateString() + "', 103)";
            
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    UnpaidBillReport aUnpaidBillReport = new UnpaidBillReport();
                    aUnpaidBillReport.PatientId = Convert.ToInt32(reader["PatientId"].ToString());
                    aUnpaidBillReport.PatientName = reader["PatientName"].ToString();
                    aUnpaidBillReport.MobileNo = reader["MobileNo"].ToString();
                    aUnpaidBillReport.BillNo = reader["BillNo"].ToString();
                    aUnpaidBillReport.TotalAmount = Convert.ToDecimal(reader["TotalAmount"].ToString());
                    aUnpaidBillReport.PaidAmount = Convert.ToDecimal(reader["PaidAmount"].ToString());
                    aUnpaidBillReport.DueAmount = Convert.ToDecimal(reader["DueAmount"].ToString());
                    aUnpaidBillReport.fromDate = Convert.ToDateTime(fromDate.ToShortDateString());
                    aUnpaidBillReport.toDate = Convert.ToDateTime(toDate.ToShortDateString());

                    aUnpaidBillReportList.Add(aUnpaidBillReport);
                }
                reader.Close();
            }
            connection.Close();
            return aUnpaidBillReportList;

        }
    }
}